
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
//   File Name   : frmSPCViewProcessCapability.vb
//   Description : View Process Capability
//
//   MES Version : 1.0.0
//
//   Function List
//       - CheckCondition() : Check the conditions before transaction
//       - View_Process_Capability() : View Process Capability
//
//
//   Detail Description
//       -
//       -
//
//   History
//       -
//
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
namespace Miracom.SPCCore
{
    public class frmSPCViewProcessCapability : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCViewProcessCapability()
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
        internal System.Windows.Forms.Button btnView;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Panel pnlTop;
        internal System.Windows.Forms.GroupBox grpTop;
        internal System.Windows.Forms.Label lblPeriod;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChartID;
        internal System.Windows.Forms.Label lblChartID;
        internal Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtStart;
        internal Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccStart;
        internal Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtEnd;
        internal Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccEnd;
        internal System.Windows.Forms.Panel pnlData;
        private FarPoint.Win.Spread.FpSpread spdData;
        internal FarPoint.Win.Spread.SheetView spdData_Sheet1;
        internal Infragistics.Win.UltraWinEditors.UltraComboEditor cboPeriodFlag;
        internal System.Windows.Forms.Label lblPeriodFlag;
        public System.Windows.Forms.Button btnExcel;
        internal System.Windows.Forms.Button btnFiltering;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChartSetID;
        internal System.Windows.Forms.Label lblChartSet;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCViewProcessCapability));
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType9 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType10 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType11 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType12 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.grpTop = new System.Windows.Forms.GroupBox();
            this.cdvChartSetID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChartSet = new System.Windows.Forms.Label();
            this.btnFiltering = new System.Windows.Forms.Button();
            this.lblPeriodFlag = new System.Windows.Forms.Label();
            this.cboPeriodFlag = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.cdvChartID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChartID = new System.Windows.Forms.Label();
            this.udtStart = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uccStart = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.udtEnd = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uccEnd = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.pnlData = new System.Windows.Forms.Panel();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartSetID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPeriodFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccEnd)).BeginInit();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(742, 40);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(8, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnView.Location = new System.Drawing.Point(557, 7);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(649, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.grpTop);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlTop.Size = new System.Drawing.Size(742, 92);
            this.pnlTop.TabIndex = 0;
            // 
            // grpTop
            // 
            this.grpTop.Controls.Add(this.cdvChartSetID);
            this.grpTop.Controls.Add(this.lblChartSet);
            this.grpTop.Controls.Add(this.btnFiltering);
            this.grpTop.Controls.Add(this.lblPeriodFlag);
            this.grpTop.Controls.Add(this.cboPeriodFlag);
            this.grpTop.Controls.Add(this.lblPeriod);
            this.grpTop.Controls.Add(this.cdvChartID);
            this.grpTop.Controls.Add(this.lblChartID);
            this.grpTop.Controls.Add(this.udtStart);
            this.grpTop.Controls.Add(this.uccStart);
            this.grpTop.Controls.Add(this.udtEnd);
            this.grpTop.Controls.Add(this.uccEnd);
            this.grpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTop.Location = new System.Drawing.Point(3, 0);
            this.grpTop.Name = "grpTop";
            this.grpTop.Size = new System.Drawing.Size(736, 92);
            this.grpTop.TabIndex = 0;
            this.grpTop.TabStop = false;
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
            this.cdvChartSetID.Location = new System.Drawing.Point(120, 17);
            this.cdvChartSetID.MaxLength = 30;
            this.cdvChartSetID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChartSetID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChartSetID.Name = "cdvChartSetID";
            this.cdvChartSetID.ReadOnly = false;
            this.cdvChartSetID.SearchSubItemIndex = 0;
            this.cdvChartSetID.SelectedDescIndex = -1;
            this.cdvChartSetID.SelectedSubItemIndex = -1;
            this.cdvChartSetID.SelectionStart = 0;
            this.cdvChartSetID.Size = new System.Drawing.Size(200, 20);
            this.cdvChartSetID.SmallImageList = null;
            this.cdvChartSetID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChartSetID.TabIndex = 1;
            this.cdvChartSetID.TextBoxToolTipText = "";
            this.cdvChartSetID.TextBoxWidth = 200;
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
            this.lblChartSet.Location = new System.Drawing.Point(15, 20);
            this.lblChartSet.Name = "lblChartSet";
            this.lblChartSet.Size = new System.Drawing.Size(65, 13);
            this.lblChartSet.TabIndex = 0;
            this.lblChartSet.Text = "Chart Set ID";
            // 
            // btnFiltering
            // 
            this.btnFiltering.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltering.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltering.Image")));
            this.btnFiltering.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFiltering.Location = new System.Drawing.Point(324, 40);
            this.btnFiltering.Name = "btnFiltering";
            this.btnFiltering.Size = new System.Drawing.Size(24, 24);
            this.btnFiltering.TabIndex = 4;
            this.btnFiltering.Click += new System.EventHandler(this.btnFiltering_Click);
            // 
            // lblPeriodFlag
            // 
            this.lblPeriodFlag.AutoSize = true;
            this.lblPeriodFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriodFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPeriodFlag.Location = new System.Drawing.Point(15, 69);
            this.lblPeriodFlag.Name = "lblPeriodFlag";
            this.lblPeriodFlag.Size = new System.Drawing.Size(71, 13);
            this.lblPeriodFlag.TabIndex = 5;
            this.lblPeriodFlag.Text = "Period Flag";
            // 
            // cboPeriodFlag
            // 
            this.cboPeriodFlag.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem1.DataValue = "ValueListItem2";
            valueListItem1.DisplayText = "Yearly";
            valueListItem2.DataValue = "ValueListItem1";
            valueListItem2.DisplayText = "Quarterly";
            valueListItem3.DataValue = "ValueListItem0";
            valueListItem3.DisplayText = "Monthly";
            valueListItem4.DataValue = "ValueListItem3";
            valueListItem4.DisplayText = "Weekly";
            valueListItem5.DataValue = "ValueListItem4";
            valueListItem5.DisplayText = "Daily";
            this.cboPeriodFlag.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4,
            valueListItem5});
            this.cboPeriodFlag.Location = new System.Drawing.Point(120, 67);
            this.cboPeriodFlag.Name = "cboPeriodFlag";
            this.cboPeriodFlag.Size = new System.Drawing.Size(158, 19);
            this.cboPeriodFlag.TabIndex = 6;
            this.cboPeriodFlag.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // lblPeriod
            // 
            this.lblPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPeriod.Location = new System.Drawing.Point(485, 20);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(43, 13);
            this.lblPeriod.TabIndex = 7;
            this.lblPeriod.Text = "Period";
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
            this.cdvChartID.Index = 0;
            this.cdvChartID.IsViewBtnImage = false;
            this.cdvChartID.Location = new System.Drawing.Point(120, 42);
            this.cdvChartID.MaxLength = 30;
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
            this.cdvChartID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChartID_SelectedItemChanged);
            this.cdvChartID.ButtonPress += new System.EventHandler(this.cdvChartID_ButtonPress);
            this.cdvChartID.TextBoxTextChanged += new System.EventHandler(this.cdvChartID_TextBoxTextChanged);
            // 
            // lblChartID
            // 
            this.lblChartID.AutoSize = true;
            this.lblChartID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChartID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChartID.Location = new System.Drawing.Point(15, 45);
            this.lblChartID.Name = "lblChartID";
            this.lblChartID.Size = new System.Drawing.Size(46, 13);
            this.lblChartID.TabIndex = 2;
            this.lblChartID.Text = "Chart ID";
            // 
            // udtStart
            // 
            this.udtStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.udtStart.DateTime = new System.DateTime(2005, 5, 26, 0, 0, 0, 0);
            this.udtStart.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.udtStart.FormatString = "";
            this.udtStart.Location = new System.Drawing.Point(653, 17);
            this.udtStart.MaskInput = "hh:mm:ss";
            this.udtStart.Name = "udtStart";
            this.udtStart.Size = new System.Drawing.Size(72, 21);
            this.udtStart.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.udtStart.SpinWrap = true;
            this.udtStart.TabIndex = 9;
            this.udtStart.Value = new System.DateTime(2005, 5, 26, 0, 0, 0, 0);
            // 
            // uccStart
            // 
            this.uccStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uccStart.DateButtons.Add(dateButton1);
            this.uccStart.Location = new System.Drawing.Point(561, 17);
            this.uccStart.Name = "uccStart";
            this.uccStart.NonAutoSizeHeight = 21;
            this.uccStart.Size = new System.Drawing.Size(88, 21);
            this.uccStart.TabIndex = 8;
            this.uccStart.Value = new System.DateTime(2005, 5, 25, 0, 0, 0, 0);
            // 
            // udtEnd
            // 
            this.udtEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.udtEnd.DateTime = new System.DateTime(2005, 5, 4, 23, 59, 59, 0);
            this.udtEnd.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.udtEnd.FormatString = "";
            this.udtEnd.Location = new System.Drawing.Point(653, 42);
            this.udtEnd.MaskInput = "hh:mm:ss";
            this.udtEnd.Name = "udtEnd";
            this.udtEnd.Size = new System.Drawing.Size(72, 21);
            this.udtEnd.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.udtEnd.SpinWrap = true;
            this.udtEnd.TabIndex = 11;
            this.udtEnd.Value = new System.DateTime(2005, 5, 4, 23, 59, 59, 0);
            // 
            // uccEnd
            // 
            this.uccEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uccEnd.DateButtons.Add(dateButton2);
            this.uccEnd.Location = new System.Drawing.Point(561, 42);
            this.uccEnd.Name = "uccEnd";
            this.uccEnd.NonAutoSizeHeight = 21;
            this.uccEnd.Size = new System.Drawing.Size(88, 21);
            this.uccEnd.TabIndex = 10;
            this.uccEnd.Value = new System.DateTime(2005, 5, 25, 0, 0, 0, 0);
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.spdData);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 92);
            this.pnlData.Name = "pnlData";
            this.pnlData.Padding = new System.Windows.Forms.Padding(3);
            this.pnlData.Size = new System.Drawing.Size(742, 414);
            this.pnlData.TabIndex = 2;
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, Sheet1, Row 0, Column 0, ";
            this.spdData.BackColor = System.Drawing.SystemColors.Control;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 2;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.Location = new System.Drawing.Point(3, 3);
            this.spdData.Name = "spdData";
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(736, 408);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 0;
            this.spdData.TabStop = false;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 3;
            this.spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.SetViewportLeftColumn(0, 0, 1);
            this.spdData.SetActiveViewport(0, -1, -1);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 25;
            spdData_Sheet1.RowCount = 0;
            this.spdData_Sheet1.ActiveColumnIndex = -1;
            this.spdData_Sheet1.ActiveRowIndex = -1;
            this.spdData_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Chart ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Period";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Year";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Quarter";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Month";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Week";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Day";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Sigma";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "XBar-Bar";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Rbar";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Range";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Min Value";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Max Value";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Cp";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Cpk";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Cpm";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Pp";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Ppk";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Ppm";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "OOC Count";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "OOC2 Count";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Point Count";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Grade";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Calculation Start Time";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Calculation End Time";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(0).Label = "Chart ID";
            this.spdData_Sheet1.Columns.Get(0).Locked = true;
            this.spdData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Width = 100F;
            this.spdData_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Label = "Period";
            this.spdData_Sheet1.Columns.Get(1).Locked = true;
            this.spdData_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Width = 40F;
            this.spdData_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(2).Label = "Year";
            this.spdData_Sheet1.Columns.Get(2).Locked = true;
            this.spdData_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(2).Width = 31F;
            this.spdData_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(3).Label = "Quarter";
            this.spdData_Sheet1.Columns.Get(3).Locked = true;
            this.spdData_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(3).Width = 45F;
            this.spdData_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(4).Label = "Month";
            this.spdData_Sheet1.Columns.Get(4).Locked = true;
            this.spdData_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(4).Width = 40F;
            this.spdData_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(5).Label = "Week";
            this.spdData_Sheet1.Columns.Get(5).Locked = true;
            this.spdData_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(5).Width = 46F;
            this.spdData_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(6).Label = "Day";
            this.spdData_Sheet1.Columns.Get(6).Locked = true;
            this.spdData_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(6).Width = 29F;
            this.spdData_Sheet1.Columns.Get(7).CellType = textCellType1;
            this.spdData_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(7).Label = "Sigma";
            this.spdData_Sheet1.Columns.Get(7).Locked = true;
            this.spdData_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(7).Width = 70F;
            this.spdData_Sheet1.Columns.Get(8).CellType = textCellType2;
            this.spdData_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(8).Label = "XBar-Bar";
            this.spdData_Sheet1.Columns.Get(8).Locked = true;
            this.spdData_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(8).Width = 70F;
            this.spdData_Sheet1.Columns.Get(9).CellType = textCellType3;
            this.spdData_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(9).Label = "Rbar";
            this.spdData_Sheet1.Columns.Get(9).Locked = true;
            this.spdData_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(9).Width = 70F;
            this.spdData_Sheet1.Columns.Get(10).CellType = textCellType4;
            this.spdData_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(10).Label = "Range";
            this.spdData_Sheet1.Columns.Get(10).Locked = true;
            this.spdData_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(10).Width = 70F;
            this.spdData_Sheet1.Columns.Get(11).CellType = textCellType5;
            this.spdData_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(11).Label = "Min Value";
            this.spdData_Sheet1.Columns.Get(11).Locked = true;
            this.spdData_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(11).Width = 70F;
            this.spdData_Sheet1.Columns.Get(12).CellType = textCellType6;
            this.spdData_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(12).Label = "Max Value";
            this.spdData_Sheet1.Columns.Get(12).Locked = true;
            this.spdData_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(12).Width = 70F;
            this.spdData_Sheet1.Columns.Get(13).CellType = textCellType7;
            this.spdData_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(13).Label = "Cp";
            this.spdData_Sheet1.Columns.Get(13).Locked = true;
            this.spdData_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(13).Width = 70F;
            this.spdData_Sheet1.Columns.Get(14).CellType = textCellType8;
            this.spdData_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(14).Label = "Cpk";
            this.spdData_Sheet1.Columns.Get(14).Locked = true;
            this.spdData_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(14).Width = 70F;
            this.spdData_Sheet1.Columns.Get(15).CellType = textCellType9;
            this.spdData_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(15).Label = "Cpm";
            this.spdData_Sheet1.Columns.Get(15).Locked = true;
            this.spdData_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(15).Width = 70F;
            this.spdData_Sheet1.Columns.Get(16).CellType = textCellType10;
            this.spdData_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(16).Label = "Pp";
            this.spdData_Sheet1.Columns.Get(16).Locked = true;
            this.spdData_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(16).Width = 70F;
            this.spdData_Sheet1.Columns.Get(17).CellType = textCellType11;
            this.spdData_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(17).Label = "Ppk";
            this.spdData_Sheet1.Columns.Get(17).Locked = true;
            this.spdData_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(17).Width = 70F;
            this.spdData_Sheet1.Columns.Get(18).CellType = textCellType12;
            this.spdData_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(18).Label = "Ppm";
            this.spdData_Sheet1.Columns.Get(18).Locked = true;
            this.spdData_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(18).Width = 70F;
            this.spdData_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(19).Label = "OOC Count";
            this.spdData_Sheet1.Columns.Get(19).Locked = true;
            this.spdData_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(19).Width = 85F;
            this.spdData_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(20).Label = "OOC2 Count";
            this.spdData_Sheet1.Columns.Get(20).Locked = true;
            this.spdData_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(20).Width = 110F;
            this.spdData_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(21).Label = "Point Count";
            this.spdData_Sheet1.Columns.Get(21).Locked = true;
            this.spdData_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(21).Width = 65F;
            this.spdData_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(22).Label = "Grade";
            this.spdData_Sheet1.Columns.Get(22).Locked = true;
            this.spdData_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(22).Width = 39F;
            this.spdData_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(23).Label = "Calculation Start Time";
            this.spdData_Sheet1.Columns.Get(23).Locked = true;
            this.spdData_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(23).Width = 120F;
            this.spdData_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(24).Label = "Calculation End Time";
            this.spdData_Sheet1.Columns.Get(24).Locked = true;
            this.spdData_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(24).Width = 120F;
            this.spdData_Sheet1.FrozenColumnCount = 1;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.Rows.Default.Height = 18F;
            this.spdData_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdData_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmSPCViewProcessCapability
            // 
            this.AcceptButton = this.btnView;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(750, 580);
            this.Name = "frmSPCViewProcessCapability";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "View Process Capability";
            this.Load += new System.EventHandler(this.frmSPCViewProcessCapability_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpTop.ResumeLayout(false);
            this.grpTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartSetID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPeriodFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccEnd)).EndInit();
            this.pnlData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Function Implementations"
        
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool CheckCondition()
        {
            
            try
            {
                if (cboPeriodFlag.SelectedIndex == - 1)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cboPeriodFlag.Focus();
                    return false;
                }
                if (this.uccStart.Value == System.DBNull.Value)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    uccStart.Focus();
                    return false;
                }
                if (this.udtStart.Value == System.DBNull.Value)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    udtStart.Focus();
                    return false;
                }
                if (this.uccEnd.Value == System.DBNull.Value)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    uccEnd.Focus();
                    return false;
                }
                if (this.udtEnd.Value == System.DBNull.Value)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    udtEnd.Focus();
                    return false;
                }
                if (MPCF.ToDate((((DateTime)uccStart.Value).ToString("yyyyMMdd")) + (((DateTime)udtStart.Value).ToString("HHmmss"))) >=
                    MPCF.ToDate((((DateTime)uccEnd.Value).ToString("yyyyMMdd")) + (((DateTime)udtEnd.Value).ToString("HHmmss"))))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(214));
                    return false;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewProcessCapability.CheckCondition()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_Process_Capability()
        //       - View Process Capability
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool View_Process_Capability()
        {
            TRSNode in_node = new TRSNode("View_Process_Capability_In");
            TRSNode out_node;
            ArrayList a_list = new ArrayList();
            int i;
            int iRow;
            int iCol;
            
            try
            {
                MPCF.ClearList(spdData, true);
                MPCR.SetInMsg(in_node);

                in_node.AddString("FROM_TIME", ((DateTime)uccStart.Value).ToString("yyyyMMdd") + ((DateTime)udtStart.Value).ToString("HHmmss"));
                in_node.AddString("TO_TIME", ((DateTime)uccEnd.Value).ToString("yyyyMMdd") + ((DateTime)udtEnd.Value).ToString("HHmmss"));
                in_node.AddChar("PERIOD_FLAG", MPCF.ToChar(cboPeriodFlag.Text.Substring(0, 1)));
                in_node.AddString("NEXT_CHART_ID", MPCF.Trim(cdvChartID.Text));
                in_node.AddString("NEXT_KEY", " ");
                in_node.AddString("CHART_SET_ID", MPCF.Trim(cdvChartSetID.Text));

                
                if (cdvChartID.Text != "")
                {
                    in_node.ProcStep = '2';
                }
                else if (cdvChartID.Text == "" && cdvChartSetID.Text != "")
                {
                    in_node.ProcStep = '3';
                }
                else
                {
                    in_node.ProcStep = '1';
                }
                
                do
                {
                    out_node = new TRSNode("View_Process_Capability_Out");
                    if (MPCR.CallService("SPC", "SPC_View_Process_Capability", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    a_list.Add(out_node);
                                        
                    in_node.SetString("NEXT_CHART_ID", out_node.GetString("NEXT_CHART_ID"));
                    in_node.SetString("NEXT_KEY", out_node.GetString("NEXT_KEY"));

                } while (in_node.GetString("NEXT_CHART_ID") != "" || in_node.GetString("NEXT_KEY") != "" );
                  foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdData.Sheets[0].RowCount;
                        spdData.Sheets[0].RowCount++;
                        iCol = 0;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHART_ID"));
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("PERIOD_FLAG"));
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CAL_YEAR"));
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CAL_QUARTER"));
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CAL_MONTH"));
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CAL_WEEK"));
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CAL_DAY"));
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV")), 4);
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("XBARBAR")), 4);
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("RBAR")), 4);
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("RANGE")), 4);
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("MIN_VALUE")), 4);
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("MAX_VALUE")), 4);
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("CP")), 4);
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("CPK")), 4);
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("CPM")), 4);
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("PP")), 4);
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("PPK")), 4);
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("PPM")), 4);
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("OOC_COUNT"));
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("OOC2_COUNT"));
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("POINT_COUNT"));
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("GRADE"));
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CAL_START_TIME"));
                        
                        iCol++;
                        spdData.Sheets[0].Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CAL_END_TIME"));
                        
                        iCol++;
                    }
                }
                    
                
                if (in_node.GetChar("PROCSTEP") == '2')
                {
                    spdData.Sheets[0].Columns[0].Visible = false;
                }
                else
                {
                    spdData.Sheets[0].Columns[0].Visible = true;
                }
                if (cboPeriodFlag.Text.Substring(0, 1) == "Y")
                {
                    spdData.Sheets[0].Columns[3].Visible = false;
                    spdData.Sheets[0].Columns[4].Visible = false;
                    spdData.Sheets[0].Columns[5].Visible = false;
                    spdData.Sheets[0].Columns[6].Visible = false;
                }
                else if (cboPeriodFlag.Text.Substring(0, 1) == "Q")
                {
                    spdData.Sheets[0].Columns[3].Visible = true;
                    spdData.Sheets[0].Columns[4].Visible = false;
                    spdData.Sheets[0].Columns[5].Visible = false;
                    spdData.Sheets[0].Columns[6].Visible = false;
                }
                else if (cboPeriodFlag.Text.Substring(0, 1) == "M")
                {
                    spdData.Sheets[0].Columns[3].Visible = true;
                    spdData.Sheets[0].Columns[4].Visible = true;
                    spdData.Sheets[0].Columns[5].Visible = false;
                    spdData.Sheets[0].Columns[6].Visible = false;
                }
                else if (cboPeriodFlag.Text.Substring(0, 1) == "W")
                {
                    spdData.Sheets[0].Columns[3].Visible = true;
                    spdData.Sheets[0].Columns[4].Visible = true;
                    spdData.Sheets[0].Columns[5].Visible = true;
                    spdData.Sheets[0].Columns[6].Visible = false;
                }
                else
                {
                    spdData.Sheets[0].Columns[3].Visible = true;
                    spdData.Sheets[0].Columns[4].Visible = true;
                    spdData.Sheets[0].Columns[5].Visible = true;
                    spdData.Sheets[0].Columns[6].Visible = true;
                }
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewProcessCapability.View_Process_Capability()\n" + ex.Message);
                return false;
            }
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvChartID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        private void ChartInfo()
        {
            
            try
            {
                cboPeriodFlag.SelectedIndex = 0;
                btnView.PerformClick();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewProcessCapability.ChartInfo()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
        #region " Event Implematations"
        
        private void cdvChartID_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                cdvChartID.Init();
                MPCF.InitListView(cdvChartID.GetListView);
                cdvChartID.Columns.Add("Chart", 50, HorizontalAlignment.Left);
                if (cdvChartSetID.Text == "")
                {
                    cdvChartID.Columns.Add("GraphType", 50, HorizontalAlignment.Left);
                }
                cdvChartID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvChartID.SelectedSubItemIndex = 0;
                if (cdvChartSetID.Text != "")
                {
                    SPCLIST.ViewSPCAttachChartList(cdvChartID.GetListView, '1', cdvChartSetID.Text, "");
                }
                else
                {
                    SPCLIST.ViewChartList(cdvChartID.GetListView, '2', "", 0,"", "", "", ' ', ' ', MPCF.Trim(cdvChartID.Text), "", -1, -1, null, "");
                }
                cdvChartID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewProcessCapability.cdvChartID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                MPCF.ClearList(spdData, true);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewProcessCapability.cdvChartID_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCViewProcessCapability_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                MPCF.SetTextboxStyle(this.Controls);
                
                uccStart.Value = DateTime.Now.AddMonths(- 1);
                udtStart.Value = "000000";
                uccEnd.Value = DateTime.Now;
                udtEnd.Value = "235959";
                
                cdvChartID.Text = modSPCFunctions.GetFilterKey();
                
                if (MPCF.Trim(MPGV.gsChartID) != "")
                {
                    cdvChartID.Text = MPGV.gsChartID;
                    ChartInfo();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewProcessCapability.frmSPCViewProcessCapability_Load()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.ClearList(spdData, true);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewProcessCapability.cdvChartID_TextBoxTextChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Dispose();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewProcessCapability.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition() == false)
                {
                    return;
                }
                if (View_Process_Capability() == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewProcessCapability.btnView_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                string sCond;
                
                sCond = "Chart ID : " + MPCF.Trim(cdvChartID.Text) + "\r";
                sCond = sCond + "Period Flag : " + MPCF.Trim(cboPeriodFlag.Text) + "\r";
                sCond = sCond + "Date : " + ((DateTime)uccStart.Value).ToString("yyyy/MM/dd ") + ((DateTime)udtStart.Value).ToString("HH:mm:ss") + " ~ " + ((DateTime)uccEnd.Value).ToString("yyyy/MM/dd ") + ((DateTime)udtEnd.Value).ToString("HH:mm:ss");
                MPCF.ExportToExcel(spdData, this.Text, sCond);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewProcessCapability.btnExcel_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnFiltering_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                frmSPCViewChartList form = new frmSPCViewChartList();
                form.StartPosition = FormStartPosition.CenterParent;
                if (cdvChartSetID.Text != "")
                {
                    form.cdvChartSetID.Text = cdvChartSetID.Text;
                    form.cdvChartSetID.Enabled = false;
                }
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (form.lisChart.SelectedItems.Count > 0)
                    {
                        cdvChartID.Text = form.lisChart.SelectedItems[0].SubItems[1].Text;
                        ChartInfo();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewAlarmHistory.btnFiltering_Click()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartSetID_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvChartSetID.Init();
                MPCF.InitListView(cdvChartSetID.GetListView);
                cdvChartSetID.Columns.Add("Chart", 50, HorizontalAlignment.Left);
                cdvChartSetID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvChartSetID.SelectedSubItemIndex = 0;
                SPCLIST.ViewChartSetList(cdvChartSetID.GetListView, '1', "",0, "", "", ' ', "", -1, -1, "");
                cdvChartSetID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewSpecHistory.cdvChartSetID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartSetID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                MPCF.ClearList(spdData, true);
                cdvChartID.Text = "";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewSpecHistory.cdvChartSetID_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartSetID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.ClearList(spdData, true);
                cdvChartID.Text = "";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewSpecHistory.cdvChartSetID_TextBoxTextChanged()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
    }
    
    
    //#End If
    
}
