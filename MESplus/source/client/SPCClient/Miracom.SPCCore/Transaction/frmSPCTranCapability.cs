
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
//   File Name   : frmSPCTranCapability.vb
//   Description : View Capability Analasys
//
//   SPC Version : 1.0.0
//
//   Function List
//       - CheckCondition : Check the conditions before transaction
//       - View_Chart : View Chart Information
//       - View_Spec : View Spec Information
//       - ClearChartInfo : Clear Chart Information Control
//       - ClearDataInfo : Clear Data Information Control
//       - InitChart : Initialize Chart Options
//       - View_Histogram : View Histogram
//       - ChartIDSelected : Action after Chart ID Selected
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
    public class frmSPCTranCapability : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCTranCapability()
        {
            
            
            InitializeComponent();
            
            
            this.spdChartInfo.Tag = "Change Cell";
            this.spdDataInfo.Tag = "Change Cell";
            
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
        


        //ì½”ë“œ ?¸ì§‘ê¸°ë? ?¬ìš©?˜ì—¬ ?˜ì •?˜ì? ë§ˆì‹­?œì˜¤.
        internal FarPoint.Win.Spread.SheetView spdDataInfo_Sheet1;
        internal System.Windows.Forms.Panel pnlFill;
        internal System.Windows.Forms.Panel pnlFillFill;
        internal System.Windows.Forms.Panel pnlChart;
        internal System.Windows.Forms.Panel pnlFillTop;
        internal System.Windows.Forms.GroupBox grpTop;
        internal System.Windows.Forms.Label lblGraphType;
        internal Infragistics.Win.UltraWinEditors.UltraComboEditor cboGraphType;
        internal System.Windows.Forms.Label lblPeriod;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChartID;
        internal System.Windows.Forms.Label lblChartID;
        internal Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtStart;
        internal Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccStart;
        internal Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtEnd;
        internal Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccEnd;
        internal System.Windows.Forms.Panel pnlFillRight;
        internal System.Windows.Forms.GroupBox grpChartOptions;
        internal System.Windows.Forms.GroupBox grpChartInfo;
        internal System.Windows.Forms.Panel pnlFillBottom;
        internal System.Windows.Forms.Panel pnlBottom;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewChartOptions;
        internal System.Windows.Forms.Button btnClose;
        internal SPCHistogram.SPCHistogram Chart;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkIsViewNormalLine;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewGridLine;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewFreqText;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewSpecLimit;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkView3sLine;
        internal System.Windows.Forms.GroupBox grpCapability;
        private FarPoint.Win.Spread.FpSpread spdDataInfo;
        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.Button btnViewRawData;
        internal System.Windows.Forms.Button btnView;
        internal System.Windows.Forms.Button btnGraph;
        internal System.Windows.Forms.Panel pnlFillMiddle;
        internal System.Windows.Forms.GroupBox grpSpecOption;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtTARGET;
        internal System.Windows.Forms.Label lblTARGET;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtLSL;
        internal System.Windows.Forms.Label lblLSL;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtUSL;
        internal System.Windows.Forms.Label lblUSL;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkUseSpec;
        internal System.Windows.Forms.Label lblUserSpec;
        internal System.Windows.Forms.Button btnPrint;
        internal System.Windows.Forms.Button btnSaveImage;
        internal System.Windows.Forms.Button btnCopyImage;
        internal FarPoint.Win.Spread.FpSpread spdChartInfo;
        internal FarPoint.Win.Spread.SheetView spdChartInfo_Sheet1;
        internal UltraTextEditor txtBinSize;
        internal Label lblUserInputSize;
        internal UltraCheckEditor chkUserInputSize;
        internal UltraCheckEditor chkAutoRefresh;
        private Timer tmrAutoRefresh;
        private NumericUpDown numRefreshSec;
        internal System.Windows.Forms.Button btnFiltering;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.BevelBorder bevelBorder2 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.BevelBorder bevelBorder3 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.BevelBorder bevelBorder4 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCTranCapability));
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder5 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.spdDataInfo_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlFill = new System.Windows.Forms.Panel();
            this.pnlFillMiddle = new System.Windows.Forms.Panel();
            this.pnlFillFill = new System.Windows.Forms.Panel();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.Chart = new SPCHistogram.SPCHistogram();
            this.pnlFillTop = new System.Windows.Forms.Panel();
            this.grpTop = new System.Windows.Forms.GroupBox();
            this.btnFiltering = new System.Windows.Forms.Button();
            this.lblGraphType = new System.Windows.Forms.Label();
            this.cboGraphType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.cdvChartID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChartID = new System.Windows.Forms.Label();
            this.udtStart = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uccStart = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.udtEnd = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uccEnd = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.pnlFillRight = new System.Windows.Forms.Panel();
            this.grpChartOptions = new System.Windows.Forms.GroupBox();
            this.txtBinSize = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblUserInputSize = new System.Windows.Forms.Label();
            this.chkUserInputSize = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lblUserSpec = new System.Windows.Forms.Label();
            this.chkUseSpec = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewFreqText = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkIsViewNormalLine = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewGridLine = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkView3sLine = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewSpecLimit = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.grpSpecOption = new System.Windows.Forms.GroupBox();
            this.txtTARGET = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblTARGET = new System.Windows.Forms.Label();
            this.txtLSL = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblLSL = new System.Windows.Forms.Label();
            this.txtUSL = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblUSL = new System.Windows.Forms.Label();
            this.grpChartInfo = new System.Windows.Forms.GroupBox();
            this.spdChartInfo = new FarPoint.Win.Spread.FpSpread();
            this.spdChartInfo_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlFillBottom = new System.Windows.Forms.Panel();
            this.grpCapability = new System.Windows.Forms.GroupBox();
            this.spdDataInfo = new FarPoint.Win.Spread.FpSpread();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.chkAutoRefresh = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.btnCopyImage = new System.Windows.Forms.Button();
            this.btnGraph = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chkViewChartOptions = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.btnViewRawData = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tmrAutoRefresh = new System.Windows.Forms.Timer(this.components);
            this.numRefreshSec = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.spdDataInfo_Sheet1)).BeginInit();
            this.pnlFill.SuspendLayout();
            this.pnlFillFill.SuspendLayout();
            this.pnlChart.SuspendLayout();
            this.pnlFillTop.SuspendLayout();
            this.grpTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGraphType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccEnd)).BeginInit();
            this.pnlFillRight.SuspendLayout();
            this.grpChartOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBinSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUserInputSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseSpec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewFreqText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsViewNormalLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewGridLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkView3sLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewSpecLimit)).BeginInit();
            this.grpSpecOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTARGET)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSL)).BeginInit();
            this.grpChartInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdChartInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdChartInfo_Sheet1)).BeginInit();
            this.pnlFillBottom.SuspendLayout();
            this.grpCapability.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdDataInfo)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewChartOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshSec)).BeginInit();
            this.SuspendLayout();
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
            // 
            // spdDataInfo_Sheet1
            // 
            this.spdDataInfo_Sheet1.Reset();
            spdDataInfo_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdDataInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdDataInfo_Sheet1.ColumnCount = 8;
            spdDataInfo_Sheet1.RowCount = 4;
            this.spdDataInfo_Sheet1.Cells.Get(0, 0).Value = "Mean";
            this.spdDataInfo_Sheet1.Cells.Get(0, 2).Value = "Sigma (S.D.)";
            this.spdDataInfo_Sheet1.Cells.Get(0, 4).Value = "Sample Count";
            this.spdDataInfo_Sheet1.Cells.Get(0, 6).Value = "Lot/Res Count";
            this.spdDataInfo_Sheet1.Cells.Get(1, 0).Value = "Max Value";
            this.spdDataInfo_Sheet1.Cells.Get(1, 2).Value = "Min Value";
            this.spdDataInfo_Sheet1.Cells.Get(1, 4).Value = "OOC Count";
            this.spdDataInfo_Sheet1.Cells.Get(1, 6).Value = "OOC2 Count";
            this.spdDataInfo_Sheet1.Cells.Get(2, 0).Value = "Cp";
            this.spdDataInfo_Sheet1.Cells.Get(2, 2).Value = "Cpk";
            this.spdDataInfo_Sheet1.Cells.Get(2, 4).Value = "CPL";
            this.spdDataInfo_Sheet1.Cells.Get(2, 6).Value = "CPU";
            this.spdDataInfo_Sheet1.Cells.Get(3, 0).Value = "Pp";
            this.spdDataInfo_Sheet1.Cells.Get(3, 2).Value = "Ppk";
            this.spdDataInfo_Sheet1.Cells.Get(3, 4).Value = "PPL";
            this.spdDataInfo_Sheet1.Cells.Get(3, 6).Value = "PPU";
            this.spdDataInfo_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDataInfo_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdDataInfo_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDataInfo_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdDataInfo_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDataInfo_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdDataInfo_Sheet1.ColumnHeader.Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdDataInfo_Sheet1.Columns.Get(0).Border = bevelBorder1;
            this.spdDataInfo_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(0).Width = 97F;
            this.spdDataInfo_Sheet1.Columns.Get(1).CellType = textCellType1;
            this.spdDataInfo_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1).Width = 97F;
            this.spdDataInfo_Sheet1.Columns.Get(2).BackColor = System.Drawing.SystemColors.Control;
            this.spdDataInfo_Sheet1.Columns.Get(2).Border = bevelBorder2;
            this.spdDataInfo_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(2).Width = 97F;
            this.spdDataInfo_Sheet1.Columns.Get(3).CellType = textCellType2;
            this.spdDataInfo_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(3).Width = 97F;
            this.spdDataInfo_Sheet1.Columns.Get(4).BackColor = System.Drawing.SystemColors.Control;
            this.spdDataInfo_Sheet1.Columns.Get(4).Border = bevelBorder3;
            this.spdDataInfo_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(4).Width = 97F;
            this.spdDataInfo_Sheet1.Columns.Get(5).CellType = textCellType3;
            this.spdDataInfo_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(5).Width = 97F;
            this.spdDataInfo_Sheet1.Columns.Get(6).BackColor = System.Drawing.SystemColors.Control;
            this.spdDataInfo_Sheet1.Columns.Get(6).Border = bevelBorder4;
            this.spdDataInfo_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(6).Width = 97F;
            this.spdDataInfo_Sheet1.Columns.Get(7).CellType = textCellType4;
            this.spdDataInfo_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(7).Width = 97F;
            this.spdDataInfo_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdDataInfo_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDataInfo_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdDataInfo_Sheet1.RowHeader.Visible = false;
            this.spdDataInfo_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDataInfo_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdDataInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.pnlFillMiddle);
            this.pnlFill.Controls.Add(this.pnlFillFill);
            this.pnlFill.Controls.Add(this.pnlFillTop);
            this.pnlFill.Controls.Add(this.pnlFillRight);
            this.pnlFill.Controls.Add(this.pnlFillBottom);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 0);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(792, 596);
            this.pnlFill.TabIndex = 0;
            // 
            // pnlFillMiddle
            // 
            this.pnlFillMiddle.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFillMiddle.Location = new System.Drawing.Point(569, 75);
            this.pnlFillMiddle.Name = "pnlFillMiddle";
            this.pnlFillMiddle.Size = new System.Drawing.Size(3, 419);
            this.pnlFillMiddle.TabIndex = 3;
            // 
            // pnlFillFill
            // 
            this.pnlFillFill.Controls.Add(this.pnlChart);
            this.pnlFillFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFillFill.Location = new System.Drawing.Point(0, 75);
            this.pnlFillFill.Name = "pnlFillFill";
            this.pnlFillFill.Padding = new System.Windows.Forms.Padding(3);
            this.pnlFillFill.Size = new System.Drawing.Size(572, 419);
            this.pnlFillFill.TabIndex = 1;
            // 
            // pnlChart
            // 
            this.pnlChart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlChart.Controls.Add(this.Chart);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(3, 3);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(566, 413);
            this.pnlChart.TabIndex = 0;
            // 
            // Chart
            // 
            this.Chart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Chart.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(121)))), ((int)(((byte)(214)))));
            this.Chart.BarCount = 0;
            this.Chart.BGColor = System.Drawing.Color.WhiteSmoke;
            this.Chart.BottomTitle = "";
            this.Chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Chart.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chart.IsView3sLine = true;
            this.Chart.IsViewBarFreqText = true;
            this.Chart.IsViewGridLine = true;
            this.Chart.IsViewNormalLine = true;
            this.Chart.IsViewSpecLimit = true;
            this.Chart.IsXAxisAutoInterval = true;
            this.Chart.IsYAxisAutoInteval = true;
            this.Chart.LeftTitle = "";
            this.Chart.Location = new System.Drawing.Point(0, 0);
            this.Chart.LSL = 1.7976931348623157E+308D;
            this.Chart.MainTitle = "";
            this.Chart.Name = "Chart";
            this.Chart.PageMode = 0;
            this.Chart.Precision = 4;
            this.Chart.PrecisionFormat = "#,##0.0000";
            this.Chart.Size = new System.Drawing.Size(562, 409);
            this.Chart.StdDev = 1.7976931348623157E+308D;
            this.Chart.TabIndex = 0;
            this.Chart.Target = 1.7976931348623157E+308D;
            this.Chart.USL = 1.7976931348623157E+308D;
            this.Chart.XAxisMax = 1.7976931348623157E+308D;
            this.Chart.XAxisMin = 1.7976931348623157E+308D;
            this.Chart.YAxisInterval = 0;
            this.Chart.YAxisMax = 1.7976931348623157E+308D;
            this.Chart.YAxisMin = 1.7976931348623157E+308D;
            // 
            // pnlFillTop
            // 
            this.pnlFillTop.Controls.Add(this.grpTop);
            this.pnlFillTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFillTop.Location = new System.Drawing.Point(0, 0);
            this.pnlFillTop.Name = "pnlFillTop";
            this.pnlFillTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlFillTop.Size = new System.Drawing.Size(572, 75);
            this.pnlFillTop.TabIndex = 0;
            // 
            // grpTop
            // 
            this.grpTop.Controls.Add(this.btnFiltering);
            this.grpTop.Controls.Add(this.lblGraphType);
            this.grpTop.Controls.Add(this.cboGraphType);
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
            this.grpTop.Size = new System.Drawing.Size(566, 72);
            this.grpTop.TabIndex = 0;
            this.grpTop.TabStop = false;
            // 
            // btnFiltering
            // 
            this.btnFiltering.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltering.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltering.Image")));
            this.btnFiltering.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFiltering.Location = new System.Drawing.Point(300, 15);
            this.btnFiltering.Name = "btnFiltering";
            this.btnFiltering.Size = new System.Drawing.Size(24, 24);
            this.btnFiltering.TabIndex = 2;
            this.btnFiltering.Click += new System.EventHandler(this.btnFiltering_Click);
            // 
            // lblGraphType
            // 
            this.lblGraphType.AutoSize = true;
            this.lblGraphType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGraphType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGraphType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGraphType.Location = new System.Drawing.Point(15, 44);
            this.lblGraphType.Name = "lblGraphType";
            this.lblGraphType.Size = new System.Drawing.Size(63, 13);
            this.lblGraphType.TabIndex = 3;
            this.lblGraphType.Text = "Graph Type";
            // 
            // cboGraphType
            // 
            this.cboGraphType.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.cboGraphType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboGraphType.Location = new System.Drawing.Point(117, 42);
            this.cboGraphType.Name = "cboGraphType";
            this.cboGraphType.ReadOnly = true;
            this.cboGraphType.Size = new System.Drawing.Size(179, 19);
            this.cboGraphType.TabIndex = 4;
            this.cboGraphType.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // lblPeriod
            // 
            this.lblPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPeriod.Location = new System.Drawing.Point(332, 20);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(43, 13);
            this.lblPeriod.TabIndex = 5;
            this.lblPeriod.Text = "Period";
            // 
            // cdvChartID
            // 
            this.cdvChartID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChartID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChartID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChartID.BtnToolTipText = "";
            this.cdvChartID.ButtonWidth = 20;
            this.cdvChartID.DescText = "";
            this.cdvChartID.DisplaySubItemIndex = -1;
            this.cdvChartID.DisplayText = "";
            this.cdvChartID.Focusing = null;
            this.cdvChartID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChartID.Index = 0;
            this.cdvChartID.IsViewBtnImage = false;
            this.cdvChartID.Location = new System.Drawing.Point(117, 17);
            this.cdvChartID.MaxLength = 30;
            this.cdvChartID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChartID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChartID.Name = "cdvChartID";
            this.cdvChartID.ReadOnly = false;
            this.cdvChartID.SameWidthHeightOfButton = false;
            this.cdvChartID.SearchSubItemIndex = 0;
            this.cdvChartID.SelectedDescIndex = -1;
            this.cdvChartID.SelectedSubItemIndex = -1;
            this.cdvChartID.SelectionStart = 0;
            this.cdvChartID.Size = new System.Drawing.Size(179, 20);
            this.cdvChartID.SmallImageList = null;
            this.cdvChartID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChartID.TabIndex = 1;
            this.cdvChartID.TextBoxToolTipText = "";
            this.cdvChartID.TextBoxWidth = 179;
            this.cdvChartID.VisibleButton = true;
            this.cdvChartID.VisibleColumnHeader = false;
            this.cdvChartID.VisibleDescription = false;
            this.cdvChartID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChartID_SelectedItemChanged);
            this.cdvChartID.ButtonPress += new System.EventHandler(this.cdvChartID_ButtonPress);
            // 
            // lblChartID
            // 
            this.lblChartID.AutoSize = true;
            this.lblChartID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChartID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChartID.Location = new System.Drawing.Point(15, 20);
            this.lblChartID.Name = "lblChartID";
            this.lblChartID.Size = new System.Drawing.Size(54, 13);
            this.lblChartID.TabIndex = 0;
            this.lblChartID.Text = "Chart ID";
            // 
            // udtStart
            // 
            this.udtStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.udtStart.DateTime = new System.DateTime(2005, 5, 26, 0, 0, 0, 0);
            this.udtStart.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.udtStart.FormatString = "";
            this.udtStart.Location = new System.Drawing.Point(485, 17);
            this.udtStart.MaskInput = "hh:mm:ss";
            this.udtStart.Name = "udtStart";
            this.udtStart.Size = new System.Drawing.Size(72, 21);
            this.udtStart.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.udtStart.SpinWrap = true;
            this.udtStart.TabIndex = 7;
            this.udtStart.Value = new System.DateTime(2005, 5, 26, 0, 0, 0, 0);
            // 
            // uccStart
            // 
            this.uccStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uccStart.DateButtons.Add(dateButton1);
            this.uccStart.Location = new System.Drawing.Point(397, 17);
            this.uccStart.Name = "uccStart";
            this.uccStart.NonAutoSizeHeight = 21;
            this.uccStart.Size = new System.Drawing.Size(88, 21);
            this.uccStart.TabIndex = 6;
            this.uccStart.Value = new System.DateTime(2005, 5, 26, 0, 0, 0, 0);
            // 
            // udtEnd
            // 
            this.udtEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.udtEnd.DateTime = new System.DateTime(2005, 5, 4, 23, 59, 59, 0);
            this.udtEnd.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.udtEnd.FormatString = "";
            this.udtEnd.Location = new System.Drawing.Point(485, 41);
            this.udtEnd.MaskInput = "hh:mm:ss";
            this.udtEnd.Name = "udtEnd";
            this.udtEnd.Size = new System.Drawing.Size(72, 21);
            this.udtEnd.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.udtEnd.SpinWrap = true;
            this.udtEnd.TabIndex = 9;
            this.udtEnd.Value = new System.DateTime(2005, 5, 4, 23, 59, 59, 0);
            // 
            // uccEnd
            // 
            this.uccEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uccEnd.DateButtons.Add(dateButton2);
            this.uccEnd.Location = new System.Drawing.Point(397, 41);
            this.uccEnd.Name = "uccEnd";
            this.uccEnd.NonAutoSizeHeight = 21;
            this.uccEnd.Size = new System.Drawing.Size(88, 21);
            this.uccEnd.TabIndex = 8;
            this.uccEnd.Value = new System.DateTime(2005, 5, 26, 0, 0, 0, 0);
            // 
            // pnlFillRight
            // 
            this.pnlFillRight.Controls.Add(this.grpChartOptions);
            this.pnlFillRight.Controls.Add(this.grpSpecOption);
            this.pnlFillRight.Controls.Add(this.grpChartInfo);
            this.pnlFillRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFillRight.Location = new System.Drawing.Point(572, 0);
            this.pnlFillRight.Name = "pnlFillRight";
            this.pnlFillRight.Padding = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.pnlFillRight.Size = new System.Drawing.Size(220, 494);
            this.pnlFillRight.TabIndex = 1;
            // 
            // grpChartOptions
            // 
            this.grpChartOptions.Controls.Add(this.txtBinSize);
            this.grpChartOptions.Controls.Add(this.lblUserInputSize);
            this.grpChartOptions.Controls.Add(this.chkUserInputSize);
            this.grpChartOptions.Controls.Add(this.lblUserSpec);
            this.grpChartOptions.Controls.Add(this.chkUseSpec);
            this.grpChartOptions.Controls.Add(this.chkViewFreqText);
            this.grpChartOptions.Controls.Add(this.chkIsViewNormalLine);
            this.grpChartOptions.Controls.Add(this.chkViewGridLine);
            this.grpChartOptions.Controls.Add(this.chkView3sLine);
            this.grpChartOptions.Controls.Add(this.chkViewSpecLimit);
            this.grpChartOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChartOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChartOptions.Location = new System.Drawing.Point(0, 169);
            this.grpChartOptions.Name = "grpChartOptions";
            this.grpChartOptions.Size = new System.Drawing.Size(217, 147);
            this.grpChartOptions.TabIndex = 1;
            this.grpChartOptions.TabStop = false;
            this.grpChartOptions.Text = "Chart Options";
            // 
            // txtBinSize
            // 
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.txtBinSize.Appearance = appearance3;
            this.txtBinSize.Location = new System.Drawing.Point(162, 119);
            this.txtBinSize.MaxLength = 3;
            this.txtBinSize.Name = "txtBinSize";
            this.txtBinSize.Size = new System.Drawing.Size(43, 21);
            this.txtBinSize.TabIndex = 9;
            this.txtBinSize.Visible = false;
            // 
            // lblUserInputSize
            // 
            this.lblUserInputSize.AutoSize = true;
            this.lblUserInputSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUserInputSize.Location = new System.Drawing.Point(29, 122);
            this.lblUserInputSize.Name = "lblUserInputSize";
            this.lblUserInputSize.Size = new System.Drawing.Size(101, 13);
            this.lblUserInputSize.TabIndex = 6;
            this.lblUserInputSize.Text = "Use User Input Size";
            // 
            // chkUserInputSize
            // 
            this.chkUserInputSize.AutoSize = true;
            this.chkUserInputSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUserInputSize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkUserInputSize.Location = new System.Drawing.Point(10, 122);
            this.chkUserInputSize.Name = "chkUserInputSize";
            this.chkUserInputSize.Size = new System.Drawing.Size(125, 17);
            this.chkUserInputSize.TabIndex = 5;
            this.chkUserInputSize.Text = "Use User Input Spec";
            this.chkUserInputSize.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkUserInputSize.CheckedChanged += new System.EventHandler(this.chkUserInputSize_CheckedChanged);
            // 
            // lblUserSpec
            // 
            this.lblUserSpec.AutoSize = true;
            this.lblUserSpec.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUserSpec.Location = new System.Drawing.Point(29, 143);
            this.lblUserSpec.Name = "lblUserSpec";
            this.lblUserSpec.Size = new System.Drawing.Size(106, 13);
            this.lblUserSpec.TabIndex = 8;
            this.lblUserSpec.Text = "Use User Input Spec";
            // 
            // chkUseSpec
            // 
            this.chkUseSpec.AutoSize = true;
            this.chkUseSpec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUseSpec.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkUseSpec.Location = new System.Drawing.Point(10, 143);
            this.chkUseSpec.Name = "chkUseSpec";
            this.chkUseSpec.Size = new System.Drawing.Size(125, 17);
            this.chkUseSpec.TabIndex = 7;
            this.chkUseSpec.Text = "Use User Input Spec";
            this.chkUseSpec.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkUseSpec.CheckedChanged += new System.EventHandler(this.chkUseSpec_CheckedChanged);
            // 
            // chkViewFreqText
            // 
            this.chkViewFreqText.AutoSize = true;
            this.chkViewFreqText.Checked = true;
            this.chkViewFreqText.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewFreqText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkViewFreqText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewFreqText.Location = new System.Drawing.Point(10, 100);
            this.chkViewFreqText.Name = "chkViewFreqText";
            this.chkViewFreqText.Size = new System.Drawing.Size(128, 17);
            this.chkViewFreqText.TabIndex = 4;
            this.chkViewFreqText.Text = "View Frequence Text";
            this.chkViewFreqText.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewFreqText.CheckedChanged += new System.EventHandler(this.chkViewFreqText_CheckedChanged);
            // 
            // chkIsViewNormalLine
            // 
            this.chkIsViewNormalLine.AutoSize = true;
            this.chkIsViewNormalLine.Checked = true;
            this.chkIsViewNormalLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsViewNormalLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsViewNormalLine.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkIsViewNormalLine.Location = new System.Drawing.Point(10, 20);
            this.chkIsViewNormalLine.Name = "chkIsViewNormalLine";
            this.chkIsViewNormalLine.Size = new System.Drawing.Size(110, 17);
            this.chkIsViewNormalLine.TabIndex = 0;
            this.chkIsViewNormalLine.Text = "View Normal Line";
            this.chkIsViewNormalLine.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkIsViewNormalLine.CheckedChanged += new System.EventHandler(this.chkIsViewNormalLine_CheckedChanged);
            // 
            // chkViewGridLine
            // 
            this.chkViewGridLine.AutoSize = true;
            this.chkViewGridLine.Checked = true;
            this.chkViewGridLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewGridLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkViewGridLine.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewGridLine.Location = new System.Drawing.Point(10, 80);
            this.chkViewGridLine.Name = "chkViewGridLine";
            this.chkViewGridLine.Size = new System.Drawing.Size(95, 17);
            this.chkViewGridLine.TabIndex = 3;
            this.chkViewGridLine.Text = "View Grid Line";
            this.chkViewGridLine.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewGridLine.CheckedChanged += new System.EventHandler(this.chkViewGridLine_CheckedChanged);
            // 
            // chkView3sLine
            // 
            this.chkView3sLine.AutoSize = true;
            this.chkView3sLine.Checked = true;
            this.chkView3sLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkView3sLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkView3sLine.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkView3sLine.Location = new System.Drawing.Point(10, 60);
            this.chkView3sLine.Name = "chkView3sLine";
            this.chkView3sLine.Size = new System.Drawing.Size(115, 17);
            this.chkView3sLine.TabIndex = 2;
            this.chkView3sLine.Text = "View 3 Sigma Line";
            this.chkView3sLine.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkView3sLine.CheckedChanged += new System.EventHandler(this.chkView3sLine_CheckedChanged);
            // 
            // chkViewSpecLimit
            // 
            this.chkViewSpecLimit.AutoSize = true;
            this.chkViewSpecLimit.Checked = true;
            this.chkViewSpecLimit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewSpecLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkViewSpecLimit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewSpecLimit.Location = new System.Drawing.Point(10, 40);
            this.chkViewSpecLimit.Name = "chkViewSpecLimit";
            this.chkViewSpecLimit.Size = new System.Drawing.Size(126, 17);
            this.chkViewSpecLimit.TabIndex = 1;
            this.chkViewSpecLimit.Text = "View Spec Limit Line";
            this.chkViewSpecLimit.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewSpecLimit.CheckedChanged += new System.EventHandler(this.chkViewSpecLimit_CheckedChanged);
            // 
            // grpSpecOption
            // 
            this.grpSpecOption.Controls.Add(this.txtTARGET);
            this.grpSpecOption.Controls.Add(this.lblTARGET);
            this.grpSpecOption.Controls.Add(this.txtLSL);
            this.grpSpecOption.Controls.Add(this.lblLSL);
            this.grpSpecOption.Controls.Add(this.txtUSL);
            this.grpSpecOption.Controls.Add(this.lblUSL);
            this.grpSpecOption.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpSpecOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSpecOption.Location = new System.Drawing.Point(0, 316);
            this.grpSpecOption.Name = "grpSpecOption";
            this.grpSpecOption.Size = new System.Drawing.Size(217, 175);
            this.grpSpecOption.TabIndex = 2;
            this.grpSpecOption.TabStop = false;
            this.grpSpecOption.Text = "Spec Options";
            this.grpSpecOption.Visible = false;
            // 
            // txtTARGET
            // 
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.txtTARGET.Appearance = appearance1;
            this.txtTARGET.Location = new System.Drawing.Point(64, 42);
            this.txtTARGET.MaxLength = 20;
            this.txtTARGET.Name = "txtTARGET";
            this.txtTARGET.Size = new System.Drawing.Size(120, 21);
            this.txtTARGET.TabIndex = 3;
            this.txtTARGET.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // lblTARGET
            // 
            this.lblTARGET.AutoSize = true;
            this.lblTARGET.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTARGET.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTARGET.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTARGET.Location = new System.Drawing.Point(10, 45);
            this.lblTARGET.Name = "lblTARGET";
            this.lblTARGET.Size = new System.Drawing.Size(51, 13);
            this.lblTARGET.TabIndex = 2;
            this.lblTARGET.Text = "TARGET";
            // 
            // txtLSL
            // 
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.txtLSL.Appearance = appearance2;
            this.txtLSL.Location = new System.Drawing.Point(64, 67);
            this.txtLSL.MaxLength = 20;
            this.txtLSL.Name = "txtLSL";
            this.txtLSL.Size = new System.Drawing.Size(120, 21);
            this.txtLSL.TabIndex = 5;
            this.txtLSL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // lblLSL
            // 
            this.lblLSL.AutoSize = true;
            this.lblLSL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLSL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLSL.Location = new System.Drawing.Point(10, 70);
            this.lblLSL.Name = "lblLSL";
            this.lblLSL.Size = new System.Drawing.Size(26, 13);
            this.lblLSL.TabIndex = 4;
            this.lblLSL.Text = "LSL";
            // 
            // txtUSL
            // 
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.txtUSL.Appearance = appearance4;
            this.txtUSL.Location = new System.Drawing.Point(64, 17);
            this.txtUSL.MaxLength = 20;
            this.txtUSL.Name = "txtUSL";
            this.txtUSL.Size = new System.Drawing.Size(120, 21);
            this.txtUSL.TabIndex = 1;
            this.txtUSL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // lblUSL
            // 
            this.lblUSL.AutoSize = true;
            this.lblUSL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUSL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUSL.Location = new System.Drawing.Point(10, 20);
            this.lblUSL.Name = "lblUSL";
            this.lblUSL.Size = new System.Drawing.Size(28, 13);
            this.lblUSL.TabIndex = 0;
            this.lblUSL.Text = "USL";
            // 
            // grpChartInfo
            // 
            this.grpChartInfo.Controls.Add(this.spdChartInfo);
            this.grpChartInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChartInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChartInfo.Location = new System.Drawing.Point(0, 0);
            this.grpChartInfo.Name = "grpChartInfo";
            this.grpChartInfo.Size = new System.Drawing.Size(217, 169);
            this.grpChartInfo.TabIndex = 0;
            this.grpChartInfo.TabStop = false;
            this.grpChartInfo.Text = "Chart Information";
            // 
            // spdChartInfo
            // 
            this.spdChartInfo.AccessibleDescription = "spdChartInfo, Sheet1, Row 0, Column 0, Material ID";
            this.spdChartInfo.BackColor = System.Drawing.SystemColors.Control;
            this.spdChartInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdChartInfo.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdChartInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdChartInfo.HorizontalScrollBar.Name = "";
            this.spdChartInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdChartInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdChartInfo.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdChartInfo.Location = new System.Drawing.Point(3, 16);
            this.spdChartInfo.Name = "spdChartInfo";
            this.spdChartInfo.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdChartInfo.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdChartInfo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdChartInfo_Sheet1});
            this.spdChartInfo.Size = new System.Drawing.Size(211, 150);
            this.spdChartInfo.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdChartInfo.TabIndex = 0;
            this.spdChartInfo.TabStop = false;
            this.spdChartInfo.TextTipDelay = 200;
            this.spdChartInfo.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdChartInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdChartInfo.VerticalScrollBar.Name = "";
            this.spdChartInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdChartInfo.VerticalScrollBar.TabIndex = 3;
            // 
            // spdChartInfo_Sheet1
            // 
            this.spdChartInfo_Sheet1.Reset();
            spdChartInfo_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdChartInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdChartInfo_Sheet1.ColumnCount = 2;
            spdChartInfo_Sheet1.RowCount = 19;
            this.spdChartInfo_Sheet1.Cells.Get(0, 0).Value = "Material ID";
            this.spdChartInfo_Sheet1.Cells.Get(1, 0).Value = "Mat Ver";
            this.spdChartInfo_Sheet1.Cells.Get(1, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.spdChartInfo_Sheet1.Cells.Get(2, 0).Value = "Flow";
            this.spdChartInfo_Sheet1.Cells.Get(3, 0).Value = "Operation";
            this.spdChartInfo_Sheet1.Cells.Get(4, 0).Value = "Resource ID";
            this.spdChartInfo_Sheet1.Cells.Get(5, 0).Value = "Character ID";
            this.spdChartInfo_Sheet1.Cells.Get(6, 0).Value = "Lot or Res";
            this.spdChartInfo_Sheet1.Cells.Get(7, 0).Value = "Unit Use";
            this.spdChartInfo_Sheet1.Cells.Get(8, 0).Value = "Unit Count";
            this.spdChartInfo_Sheet1.Cells.Get(9, 0).Value = "Sample Size";
            this.spdChartInfo_Sheet1.Cells.Get(10, 0).Value = "USL";
            this.spdChartInfo_Sheet1.Cells.Get(10, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(11, 0).Value = "TARGET";
            this.spdChartInfo_Sheet1.Cells.Get(11, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(12, 0).Value = "LSL";
            this.spdChartInfo_Sheet1.Cells.Get(12, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(13, 0).Value = "UCL";
            this.spdChartInfo_Sheet1.Cells.Get(13, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(14, 0).Value = "CL";
            this.spdChartInfo_Sheet1.Cells.Get(14, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(15, 0).Value = "LCL";
            this.spdChartInfo_Sheet1.Cells.Get(15, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(16, 0).Value = "UCL2";
            this.spdChartInfo_Sheet1.Cells.Get(16, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(17, 0).Value = "CL2";
            this.spdChartInfo_Sheet1.Cells.Get(17, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(18, 0).Value = "LCL2";
            this.spdChartInfo_Sheet1.Cells.Get(18, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdChartInfo_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdChartInfo_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdChartInfo_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdChartInfo_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdChartInfo_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdChartInfo_Sheet1.ColumnHeader.Visible = false;
            this.spdChartInfo_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdChartInfo_Sheet1.Columns.Get(0).Border = bevelBorder5;
            this.spdChartInfo_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChartInfo_Sheet1.Columns.Get(0).Locked = true;
            this.spdChartInfo_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Columns.Get(0).Width = 71F;
            this.spdChartInfo_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Columns.Get(1).Locked = true;
            this.spdChartInfo_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Columns.Get(1).Width = 118F;
            this.spdChartInfo_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdChartInfo_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdChartInfo_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdChartInfo_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdChartInfo_Sheet1.RowHeader.Visible = false;
            this.spdChartInfo_Sheet1.Rows.Get(0).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(1).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(2).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(3).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(4).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(5).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(6).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(7).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(8).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(9).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(10).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(12).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(13).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(14).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(15).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(16).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(17).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(18).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.spdChartInfo_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdChartInfo_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdChartInfo_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdChartInfo_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdChartInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlFillBottom
            // 
            this.pnlFillBottom.Controls.Add(this.grpCapability);
            this.pnlFillBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFillBottom.Location = new System.Drawing.Point(0, 494);
            this.pnlFillBottom.Name = "pnlFillBottom";
            this.pnlFillBottom.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlFillBottom.Size = new System.Drawing.Size(792, 102);
            this.pnlFillBottom.TabIndex = 2;
            // 
            // grpCapability
            // 
            this.grpCapability.Controls.Add(this.spdDataInfo);
            this.grpCapability.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCapability.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCapability.Location = new System.Drawing.Point(3, 0);
            this.grpCapability.Name = "grpCapability";
            this.grpCapability.Size = new System.Drawing.Size(786, 102);
            this.grpCapability.TabIndex = 0;
            this.grpCapability.TabStop = false;
            this.grpCapability.Text = "Capability Index";
            // 
            // spdDataInfo
            // 
            this.spdDataInfo.AccessibleDescription = "spdDataInfo, Sheet1, Row 0, Column 0, Mean";
            this.spdDataInfo.BackColor = System.Drawing.SystemColors.Control;
            this.spdDataInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdDataInfo.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdDataInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDataInfo.HorizontalScrollBar.Name = "";
            this.spdDataInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdDataInfo.HorizontalScrollBar.TabIndex = 8;
            this.spdDataInfo.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdDataInfo.Location = new System.Drawing.Point(3, 16);
            this.spdDataInfo.Name = "spdDataInfo";
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
            this.spdDataInfo.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdDataInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdDataInfo.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdDataInfo.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdDataInfo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdDataInfo_Sheet1});
            this.spdDataInfo.Size = new System.Drawing.Size(780, 83);
            this.spdDataInfo.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdDataInfo.TabIndex = 0;
            this.spdDataInfo.TabStop = false;
            this.spdDataInfo.TextTipDelay = 200;
            this.spdDataInfo.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdDataInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDataInfo.VerticalScrollBar.Name = "";
            this.spdDataInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdDataInfo.VerticalScrollBar.TabIndex = 9;
            this.spdDataInfo.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdDataInfo.Resize += new System.EventHandler(this.spdDataInfo_Resize);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.numRefreshSec);
            this.pnlBottom.Controls.Add(this.chkAutoRefresh);
            this.pnlBottom.Controls.Add(this.btnPrint);
            this.pnlBottom.Controls.Add(this.btnSaveImage);
            this.pnlBottom.Controls.Add(this.btnCopyImage);
            this.pnlBottom.Controls.Add(this.btnGraph);
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.chkViewChartOptions);
            this.pnlBottom.Controls.Add(this.btnViewRawData);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 596);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(792, 40);
            this.pnlBottom.TabIndex = 0;
            // 
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.AutoSize = true;
            this.chkAutoRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAutoRefresh.Location = new System.Drawing.Point(266, 14);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(96, 17);
            this.chkAutoRefresh.TabIndex = 9;
            this.chkAutoRefresh.Text = "Auto Refresh";
            this.chkAutoRefresh.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkAutoRefresh.CheckedChanged += new System.EventHandler(this.chkAutoRefresh_CheckedChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrint.Location = new System.Drawing.Point(92, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(24, 24);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveImage.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveImage.Image")));
            this.btnSaveImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSaveImage.Location = new System.Drawing.Point(64, 8);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(24, 24);
            this.btnSaveImage.TabIndex = 6;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // btnCopyImage
            // 
            this.btnCopyImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCopyImage.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyImage.Image")));
            this.btnCopyImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCopyImage.Location = new System.Drawing.Point(36, 8);
            this.btnCopyImage.Name = "btnCopyImage";
            this.btnCopyImage.Size = new System.Drawing.Size(24, 24);
            this.btnCopyImage.TabIndex = 5;
            this.btnCopyImage.Click += new System.EventHandler(this.btnCopyImage_Click);
            // 
            // btnGraph
            // 
            this.btnGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGraph.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGraph.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGraph.Location = new System.Drawing.Point(516, 7);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(88, 26);
            this.btnGraph.TabIndex = 1;
            this.btnGraph.Text = "Control Chart";
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnView.Location = new System.Drawing.Point(424, 7);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(8, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chkViewChartOptions
            // 
            this.chkViewChartOptions.AutoSize = true;
            this.chkViewChartOptions.Checked = true;
            this.chkViewChartOptions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewChartOptions.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewChartOptions.Location = new System.Drawing.Point(128, 14);
            this.chkViewChartOptions.Name = "chkViewChartOptions";
            this.chkViewChartOptions.Size = new System.Drawing.Size(132, 17);
            this.chkViewChartOptions.TabIndex = 8;
            this.chkViewChartOptions.Text = "View Chart Options";
            this.chkViewChartOptions.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewChartOptions.CheckedChanged += new System.EventHandler(this.chkViewChartOptions_CheckedChanged);
            // 
            // btnViewRawData
            // 
            this.btnViewRawData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewRawData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnViewRawData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnViewRawData.Location = new System.Drawing.Point(608, 7);
            this.btnViewRawData.Name = "btnViewRawData";
            this.btnViewRawData.Size = new System.Drawing.Size(88, 26);
            this.btnViewRawData.TabIndex = 2;
            this.btnViewRawData.Text = "Raw Data";
            this.btnViewRawData.Click += new System.EventHandler(this.btnViewRawData_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(700, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tmrAutoRefresh
            // 
            this.tmrAutoRefresh.Interval = 5000;
            this.tmrAutoRefresh.Tick += new System.EventHandler(this.tmrAutoRefresh_Tick);
            // 
            // numRefreshSec
            // 
            this.numRefreshSec.Location = new System.Drawing.Point(364, 12);
            this.numRefreshSec.Name = "numRefreshSec";
            this.numRefreshSec.Size = new System.Drawing.Size(40, 20);
            this.numRefreshSec.TabIndex = 10;
            this.numRefreshSec.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // frmSPCTranCapability
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(792, 636);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(800, 670);
            this.Name = "frmSPCTranCapability";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Capability Analysis";
            this.Activated += new System.EventHandler(this.frmSPCTranCapability_Activated);
            this.Load += new System.EventHandler(this.frmSPCTranCapability_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spdDataInfo_Sheet1)).EndInit();
            this.pnlFill.ResumeLayout(false);
            this.pnlFillFill.ResumeLayout(false);
            this.pnlChart.ResumeLayout(false);
            this.pnlFillTop.ResumeLayout(false);
            this.grpTop.ResumeLayout(false);
            this.grpTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGraphType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccEnd)).EndInit();
            this.pnlFillRight.ResumeLayout(false);
            this.grpChartOptions.ResumeLayout(false);
            this.grpChartOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBinSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUserInputSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseSpec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewFreqText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsViewNormalLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewGridLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkView3sLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewSpecLimit)).EndInit();
            this.grpSpecOption.ResumeLayout(false);
            this.grpSpecOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTARGET)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSL)).EndInit();
            this.grpChartInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdChartInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdChartInfo_Sheet1)).EndInit();
            this.pnlFillBottom.ResumeLayout(false);
            this.grpCapability.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdDataInfo)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewChartOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshSec)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition"
        
        bool b_load_flag;
        int giPrecision = 4;
        private const int MAT_ID_COL = 0;
        private const int MAT_VER_COL = 1;
        private const int FLOW_COL = 2;
        private const int OPER_COL = 3;
        private const int RES_COL = 4;
        private const int CHAR_COL = 5;
        private const int LOT_OR_RES_COL = 6;
        private const int USE_UNIT_COL = 7;
        private const int UNIT_COUNT_COL = 8;
        private const int SAMPLE_SIZE_COL = 9;
        private const int USL_COL = 10;
        private const int TARGET_COL = 11;
        private const int LSL_COL = 12;
        private const int UCL_COL = 13;
        private const int CL_COL = 14;
        private const int LCL_COL = 15;
        private const int UCL2_COL = 16;
        private const int CL2_COL = 17;
        private const int LCL2_COL = 18;
        
        #endregion
        
        #region " Functions Implementation"
        
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
                if (cdvChartID.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvChartID.Focus();
                    return false;
                }
                if (cboGraphType.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cboGraphType.Focus();
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
                
                if (chkUseSpec.Checked == true)
                {
                    
                    if (txtUSL.Text != "")
                    {
                        if (MPCF.CheckNumeric(txtUSL.Text) == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(116));
                            txtUSL.Focus();
                            return false;
                        }
                        if (MPCF.ToDbl(txtUSL.Text) < modSPCConstants.MIN_VALUE)
                        {
                            if (MPGV.gcLanguage == '2')
                            {
                                MPCF.ShowMsgBox(MPCF.GetErrorMsgParse(234, modSPCConstants.MIN_VALUE + " ") + MPCF.GetMessage(234));
                            }
                            else
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(234) + " " + modSPCConstants.MIN_VALUE);
                            }
                            txtUSL.Focus();
                            return false;
                        }
                        if (MPCF.ToDbl(txtUSL.Text) > modSPCConstants.MAX_VALUE)
                        {
                            if (MPGV.gcLanguage == '2')
                            {
                                MPCF.ShowMsgBox(MPCF.GetErrorMsgParse(235, modSPCConstants.MAX_VALUE + " ") + MPCF.GetMessage(235));
                            }
                            else
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(235) + " " + modSPCConstants.MAX_VALUE);
                            }
                            txtUSL.Focus();
                            return false;
                        }
                    }
                    if (txtTARGET.Text != "")
                    {
                        if (MPCF.CheckNumeric(txtTARGET.Text) == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(116));
                            txtTARGET.Focus();
                            return false;
                        }
                        if (MPCF.ToDbl(txtTARGET.Text) < modSPCConstants.MIN_VALUE)
                        {
                            if (MPGV.gcLanguage == '2')
                            {
                                MPCF.ShowMsgBox(MPCF.GetErrorMsgParse(234, modSPCConstants.MIN_VALUE + " ") + MPCF.GetMessage(234));
                            }
                            else
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(234) + " " + modSPCConstants.MIN_VALUE);
                            }
                            txtTARGET.Focus();
                            return false;
                        }
                        if (MPCF.ToDbl(txtTARGET.Text) > modSPCConstants.MAX_VALUE)
                        {
                            if (MPGV.gcLanguage == '2')
                            {
                                MPCF.ShowMsgBox(MPCF.GetErrorMsgParse(235, modSPCConstants.MAX_VALUE + " ") + MPCF.GetMessage(235));
                            }
                            else
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(235) + " " + modSPCConstants.MAX_VALUE);
                            }
                            txtTARGET.Focus();
                            return false;
                        }
                    }
                    if (txtLSL.Text != "")
                    {
                        if (MPCF.CheckNumeric(txtLSL.Text) == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(116));
                            txtLSL.Focus();
                            return false;
                        }
                        if (MPCF.ToDbl(txtLSL.Text) < modSPCConstants.MIN_VALUE)
                        {
                            if (MPGV.gcLanguage == '2')
                            {
                                MPCF.ShowMsgBox(MPCF.GetErrorMsgParse(234, modSPCConstants.MIN_VALUE + " ") + MPCF.GetMessage(234));
                            }
                            else
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(234) + " " + modSPCConstants.MIN_VALUE);
                            }
                            txtLSL.Focus();
                            return false;
                        }
                        if (MPCF.ToDbl(txtLSL.Text) > modSPCConstants.MAX_VALUE)
                        {
                            if (MPGV.gcLanguage == '2')
                            {
                                MPCF.ShowMsgBox(MPCF.GetErrorMsgParse(235, modSPCConstants.MAX_VALUE + " ") + MPCF.GetMessage(235));
                            }
                            else
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(235) + " " + modSPCConstants.MAX_VALUE);
                            }
                            txtLSL.Focus();
                            return false;
                        }
                    }
                    if (txtUSL.Text != "" && txtLSL.Text != "")
                    {
                        if (MPCF.ToDbl(txtUSL.Text) <= MPCF.ToDbl(txtLSL.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(145));
                            txtLSL.Focus();
                            return false;
                        }
                    }
                    if (txtUSL.Text != "" && txtTARGET.Text != "")
                    {
                        if (MPCF.ToDbl(txtUSL.Text) <= MPCF.ToDbl(txtTARGET.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(218));
                            txtTARGET.Focus();
                            return false;
                        }
                    }
                    if (txtTARGET.Text != "" && txtLSL.Text != "")
                    {
                        if (MPCF.ToDbl(txtTARGET.Text) <= MPCF.ToDbl(txtLSL.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(219));
                            txtLSL.Focus();
                            return false;
                        }
                    }
                }

                // ±¸°£ Å©±â ¼³Á¤ Ã¼Å©

                if (chkUserInputSize.Checked == true)
                {
                    if (MPCF.CheckNumeric(txtBinSize.Text) == false)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(116));
                        txtBinSize.Focus();
                        return false;
                    }

                    if (MPCF.ToInt(txtBinSize.Text) < 1)
                    {
                        if (MPGV.gcLanguage == '2')
                        {
                            MPCF.ShowMsgBox(MPCF.GetErrorMsgParse(234, 0 + " ") + MPCF.GetMessage(234));
                        }
                        else
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(234) + " " + 0);
                        }
                        txtBinSize.Focus();
                        return false;
                    }

                    if (MPCF.ToInt(txtBinSize.Text) > 100)
                    {
                        if (MPGV.gcLanguage == '2')
                        {
                            MPCF.ShowMsgBox(MPCF.GetErrorMsgParse(235, 100 + " ") + MPCF.GetMessage(235));
                        }
                        else
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(235) + " " + 100);
                        }
                        txtBinSize.Focus();
                        return false;
                    }
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.CheckCondition()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_Chart()
        //       - View Chart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Chart()
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Chart_In");
                TRSNode out_node = new TRSNode("View_Chart_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", cdvChartID.Text);

                if (MPCR.CallService("SPC", "SPC_View_Chart", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPCF.Trim(out_node.GetString("GRAPH_TYPE")) == "")
                {
                    cboGraphType.SelectedIndex = - 1;
                }
                else
                {
                    cboGraphType.SelectedIndex = (int)Enum.Parse(typeof(eGraphType), MPCF.Trim(out_node.GetString("GRAPH_TYPE")));
                }
                
                if (cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.ZBARS) )
                {
                    chkUseSpec.Checked = true;
                    chkUseSpec.Enabled = false;
                }
                else
                {
                    chkUseSpec.Enabled = true;
                }

                spdChartInfo.Sheets[0].SetValue(MAT_ID_COL, 1, MPCF.Trim(out_node.GetString("MAT_ID")));
                spdChartInfo.Sheets[0].SetValue(MAT_VER_COL, 1, MPCF.Trim(out_node.GetInt("MAT_VER")));
                spdChartInfo.Sheets[0].SetValue(FLOW_COL, 1, MPCF.Trim(out_node.GetString("FLOW")));
                spdChartInfo.Sheets[0].SetValue(OPER_COL, 1, MPCF.Trim(out_node.GetString("OPER")));
                spdChartInfo.Sheets[0].SetValue(RES_COL, 1, MPCF.Trim(out_node.GetString("RES_ID")));
                spdChartInfo.Sheets[0].SetValue(CHAR_COL, 1, MPCF.Trim(out_node.GetString("CHAR_ID")));
                spdChartInfo.Sheets[0].SetValue(LOT_OR_RES_COL, 1, MPCF.Trim(out_node.GetChar("LOT_RES_FLAG")));
                spdChartInfo.Sheets[0].SetValue(USE_UNIT_COL, 1, MPCF.Trim(out_node.GetChar("UNIT_USE_FLAG")));
                spdChartInfo.Sheets[0].SetValue(UNIT_COUNT_COL, 1, MPCF.Trim(out_node.GetInt("UNIT_COUNT")));
                spdChartInfo.Sheets[0].SetValue(SAMPLE_SIZE_COL, 1, MPCF.Trim(out_node.GetInt("SAMPLE_SIZE")));

                giPrecision = out_node.GetInt("PRECISION_LIMIT");
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.View_Chart()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_Spec()
        //       - View Spec
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iVer As Integer : Version
        //
        private bool View_Spec(int iVer)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Spec_In");
                TRSNode out_node = new TRSNode("View_Spec_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", cdvChartID.Text);
                in_node.AddInt("VERSION", iVer);
                
                if (MPCR.CallService("SPC", "SPC_View_Spec", in_node, ref out_node, true) == false)
                {
                    return false;
                }

                spdChartInfo.Sheets[0].SetValue(USL_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("USL")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(TARGET_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("TARGET")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(LSL_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("LSL")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(UCL_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("UCL")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(CL_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("CL")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(LCL_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("LCL")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(UCL2_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("UCL2")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(CL2_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("CL2")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(LCL2_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("LCL2")), giPrecision));
                
                if (cboGraphType.SelectedIndex != MPCF.ToInt(eGraphType.ZBARS) )
                {
                    txtUSL.Text = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("USL")), giPrecision);
                    txtTARGET.Text = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("TARGET")), giPrecision);
                    txtLSL.Text = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("LSL")), giPrecision);
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.View_Spec()\n" + ex.Message);
                return false;
            }
            
        }
        
        // ClearChartInfo()
        //       - Clear spdChartInfo
        // Return Value
        //       -
        // Arguments
        //       -
        //
        public void ClearChartInfo()
        {
            
            try
            {
                int i;
                for (i = 0; i <= spdChartInfo.Sheets[0].RowCount - 1; i++)
                {
                    spdChartInfo.Sheets[0].SetValue(i, 1, "");
                }
                
                txtUSL.Text = "";
                txtTARGET.Text = "";
                txtLSL.Text = "";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.ClearChartInfo()\n" + ex.Message);
            }
            
        }
        
        // ClearDataInfo()
        //       - Clear spdDataInfo
        // Return Value
        //       -
        // Arguments
        //       -
        //
        public void ClearDataInfo()
        {
            
            try
            {
                int i;
                for (i = 0; i <= spdDataInfo.Sheets[0].RowCount - 1; i++)
                {
                    spdDataInfo.Sheets[0].SetValue(i, 1, "");
                    spdDataInfo.Sheets[0].SetValue(i, 3, "");
                    spdDataInfo.Sheets[0].SetValue(i, 5, "");
                    spdDataInfo.Sheets[0].SetValue(i, 7, "");
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.ClearDataInfo()\n" + ex.Message);
            }
            
        }
        
        // InitChart()
        //       - Initialize Chart Options
        // Return Value
        //       -
        // Arguments
        //       -
        //
        public void InitChart()
        {
            
            try
            {
                Chart.ResetChartData();
                
                Chart.IsViewNormalLine = this.chkIsViewNormalLine.Checked;
                Chart.IsViewSpecLimit = this.chkViewSpecLimit.Checked;
                Chart.IsView3sLine = this.chkView3sLine.Checked;
                Chart.IsViewGridLine = this.chkViewGridLine.Checked;
                Chart.IsViewBarFreqText = this.chkViewFreqText.Checked;
                Chart.Precision = giPrecision;
                
                Chart.MainTitle = "Capability Analysis";
                Chart.BottomTitle = "X-Axis Interval";
                Chart.LeftTitle = "Count";
                
                Chart.RefreshChartData();
                Chart.Refresh();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.InitChart()\n" + ex.Message);
            }
            
        }
        
        // View_Histogram()
        //       - View Histogram
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public bool View_Histogram()
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Raw_Data_In");
                TRSNode out_node;
                ArrayList a_list = new ArrayList();
                int i;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", cdvChartID.Text);
                in_node.AddString("FROM_TIME", ((DateTime)uccStart.Value).ToString("yyyyMMdd") + ((DateTime)udtStart.Value).ToString("HHmmss"));
                in_node.AddString("TO_TIME", ((DateTime)uccEnd.Value).ToString("yyyyMMdd") + ((DateTime)udtEnd.Value).ToString("HHmmss"));
                in_node.AddInt("NEXT_HIST_SEQ", 0);
                in_node.AddInt("NEXT_UNIT_SEQ", 0);
                in_node.AddInt("NEXT_VALUE_SEQ", 0);
                in_node.AddInt("NEXT_VALUE_COUNT", 0);
                in_node.AddDouble("NEXT_SUM", 0);
                in_node.AddDouble("NEXT_SUMOFSQUARE", 0);
                in_node.AddDouble("NEXT_MIN_VALUE", StatGlobalVariable.DOUBLE_NULL_DATA);
                in_node.AddDouble("NEXT_MAX_VALUE", StatGlobalVariable.DOUBLE_NULL_DATA);

                InitChart();
                ClearDataInfo();
                if (chkUseSpec.Checked == true || cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.ZBARS) )
                {
                    if (txtUSL.Text == "")
                    {
                        Chart.USL = StatGlobalVariable.DOUBLE_NULL_DATA;
                        in_node.AddString("USL", "");

                    }
                    else
                    {
                        Chart.USL = MPCF.ToDbl(txtUSL.Text);
                        in_node.AddString("USL", txtUSL.Text);
                    }
                }
                else
                {
                    if (MPCF.Trim(this.spdChartInfo.Sheets[0].Cells[USL_COL, 1].Text) == "")
                    {
                        Chart.USL = StatGlobalVariable.DOUBLE_NULL_DATA;
                        in_node.AddString("USL", "");
                    }
                    else
                    {
                        Chart.USL = MPCF.ToDbl(this.spdChartInfo.Sheets[0].Cells[USL_COL, 1].Text);
                        in_node.AddString("USL", this.spdChartInfo.Sheets[0].Cells[USL_COL, 1].Text);
                    }
                }
                if (chkUseSpec.Checked == true || cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.ZBARS))
                {
                    if (txtLSL.Text == "")
                    {
                        Chart.LSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                        in_node.AddString("LSL", "");
                    }
                    else
                    {
                        Chart.LSL = MPCF.ToDbl(txtLSL.Text);
                        in_node.AddString("LSL", txtLSL.Text);
                    }
                }
                else
                {
                    if (MPCF.Trim(this.spdChartInfo.Sheets[0].Cells[LSL_COL, 1].Text) == "")
                    {
                        Chart.LSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                        in_node.AddString("LSL", "");
                    }
                    else
                    {
                        Chart.LSL = MPCF.ToDbl(this.spdChartInfo.Sheets[0].Cells[LSL_COL, 1].Text);
                        in_node.AddString("LSL", this.spdChartInfo.Sheets[0].Cells[LSL_COL, 1].Text);
                    }
                }
                if (chkUseSpec.Checked == true || cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.ZBARS) )
                {
                    if (txtTARGET.Text == "")
                    {
                        Chart.Target = StatGlobalVariable.DOUBLE_NULL_DATA;
                        in_node.AddDouble("TARGET", StatGlobalVariable.DOUBLE_NULL_DATA);
                    }
                    else
                    {
                        Chart.Target = MPCF.ToDbl(txtTARGET.Text);
                        in_node.AddDouble("TARGET", MPCF.ToDbl(txtTARGET.Text));
                    }
                }
                else
                {
                    if (MPCF.Trim(this.spdChartInfo.Sheets[0].Cells[TARGET_COL, 1].Text) == "")
                    {
                        Chart.Target = StatGlobalVariable.DOUBLE_NULL_DATA;
                        in_node.AddDouble("TARGET", StatGlobalVariable.DOUBLE_NULL_DATA);
                    }
                    else
                    {
                        Chart.Target = MPCF.ToDbl(this.spdChartInfo.Sheets[0].Cells[TARGET_COL, 1].Text);
                        in_node.AddDouble("TARGET", MPCF.ToDbl(this.spdChartInfo.Sheets[0].Cells[TARGET_COL, 1].Text));
                    }
                    
                }

                if (chkUserInputSize.Checked == true)
                {
                    Chart.DataSet.BinSize = MPCF.ToInt(txtBinSize.Text);
                }                
                
                do
                {
                     out_node = new TRSNode("View_Raw_Data_Out");
                    if (MPCR.CallService("SPC", "SPC_View_Raw_Data", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    a_list.Add(out_node);
                                        
                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                    in_node.SetInt("NEXT_UNIT_SEQ", out_node.GetInt("NEXT_UNIT_SEQ"));
                    in_node.SetInt("NEXT_VALUE_SEQ", out_node.GetInt("NEXT_VALUE_SEQ"));
                    in_node.SetInt("NEXT_VALUE_COUNT", out_node.GetInt("NEXT_VALUE_COUNT"));
                    in_node.SetDouble("NEXT_SUM", out_node.GetDouble("NEXT_SUM"));
                    in_node.SetDouble("NEXT_SUMOFSQUARE", out_node.GetDouble("NEXT_SUMOFSQUARE"));
                    in_node.SetDouble("NEXT_MIN_VALUE", out_node.GetDouble("NEXT_MIN_VALUE"));
                    in_node.SetDouble("NEXT_MAX_VALUE", out_node.GetDouble("NEXT_MAX_VALUE"));

                } while (in_node.GetInt("NEXT_HIST_SEQ") > 0 || in_node.GetInt("NEXT_UNIT_SEQ") > 0 || in_node.GetInt("NEXT_VALUE_SEQ") > 0);

                 foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                       if (MPCF.CheckNumeric(out_node.GetList(0)[i].GetString("VALUE")) == true)
                        {
                            if (Chart.AddChartData(MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE"))) == false)
                            {
                                return false;
                            }
                        }
                    }
                }    
                    
                
                spdDataInfo.Sheets[0].SetValue(0, 5, out_node.GetInt("VALUE_COUNT"));
                spdDataInfo.Sheets[0].SetValue(0, 7, out_node.GetInt("LOT_RES_COUNT"));
                
                if (out_node.GetInt("VALUE_COUNT") < 2)
                {
                    Chart.Refresh();
                    return true;
                }
                
                spdDataInfo.Sheets[0].SetValue(0, 1, MPCF.SetPrecision(Convert.ToString(out_node.GetDouble("MEAN")), giPrecision));
                spdDataInfo.Sheets[0].SetValue(0, 3, MPCF.SetPrecision(Convert.ToString(out_node.GetDouble("SIGMA")), giPrecision));
                spdDataInfo.Sheets[0].SetValue(1, 1, MPCF.SetPrecision(Convert.ToString(out_node.GetDouble("MAX_VALUE")), giPrecision));
                spdDataInfo.Sheets[0].SetValue(1, 3, MPCF.SetPrecision(Convert.ToString(out_node.GetDouble("MIN_VALUE")), giPrecision));
                spdDataInfo.Sheets[0].SetValue(1, 5, out_node.GetInt("OOCTYPE_COUNT"));
                spdDataInfo.Sheets[0].SetValue(1, 7, out_node.GetInt("OOCTYPE2_COUNT"));
                
                if (out_node.GetDouble("CP") != StatGlobalVariable.DOUBLE_NULL_DATA)
                {
                    spdDataInfo.Sheets[0].SetValue(2, 1, MPCF.SetPrecision(Convert.ToString(out_node.GetDouble("CP")), giPrecision));
                }
                if (out_node.GetDouble("CPK") != StatGlobalVariable.DOUBLE_NULL_DATA)
                {
                    spdDataInfo.Sheets[0].SetValue(2, 3, MPCF.SetPrecision(Convert.ToString(out_node.GetDouble("CPK")), giPrecision));
                }
                /* 131223 Added By Yjjung For the correction of Cp, Pp */
                if (out_node.GetDouble("CPL") != StatGlobalVariable.DOUBLE_NULL_DATA)
                {
                    spdDataInfo.Sheets[0].SetValue(2, 5, MPCF.SetPrecision(Convert.ToString(out_node.GetDouble("CPL")), giPrecision));
                }
                if (out_node.GetDouble("CPU") != StatGlobalVariable.DOUBLE_NULL_DATA)
                {
                    spdDataInfo.Sheets[0].SetValue(2, 7, MPCF.SetPrecision(Convert.ToString(out_node.GetDouble("CPU")), giPrecision));
                }
                if (out_node.GetDouble("PP") != StatGlobalVariable.DOUBLE_NULL_DATA)
                {
                    spdDataInfo.Sheets[0].SetValue(3, 1, MPCF.SetPrecision(Convert.ToString(out_node.GetDouble("PP")), giPrecision));
                }
                if (out_node.GetDouble("PPK") != StatGlobalVariable.DOUBLE_NULL_DATA)
                {
                    spdDataInfo.Sheets[0].SetValue(3, 3, MPCF.SetPrecision(Convert.ToString(out_node.GetDouble("PPK")), giPrecision));
                }
                if (out_node.GetDouble("PPL") != StatGlobalVariable.DOUBLE_NULL_DATA)
                {
                    spdDataInfo.Sheets[0].SetValue(3, 5, MPCF.SetPrecision(Convert.ToString(out_node.GetDouble("PPL")), giPrecision));
                }
                if (out_node.GetDouble("PPU") != StatGlobalVariable.DOUBLE_NULL_DATA)
                {
                    spdDataInfo.Sheets[0].SetValue(3, 7, MPCF.SetPrecision(Convert.ToString(out_node.GetDouble("PPU")), giPrecision));
                }
                /* Update End 131223 by YJJUNG*/
                if (Chart.RefreshChartData() == false)
                {
                    return false;
                }
                

                Chart.SetMean(MPCF.ToDbl(MPCF.SetPrecision(Convert.ToString(out_node.GetDouble("MEAN")), giPrecision)));
                Chart.SetSigma(MPCF.ToDbl(MPCF.SetPrecision(Convert.ToString(out_node.GetDouble("SIGMA")), giPrecision)));
                
                Chart.Refresh();

                txtBinSize.Text = Chart.DataSet.BinSize.ToString();
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.View_Histogram()\n" + ex.Message);
                return false;
            }
            
        }
        
        // ChartIDSelected()
        //       - Action after Chart ID Selected
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public void ChartIDSelected()
        {
            
            try
            {
                int iVer = StatGlobalVariable.INTEGER_NULL_DATA;
                
                InitChart();
                ClearChartInfo();
                ClearDataInfo();
                chkUseSpec.Checked = false;
                if (cdvChartID.Text == "")
                {
                    return;
                }
                if (View_Chart() == false)
                {
                    return;
                }
                if (MPCR.Find_Spec_Version('1', cdvChartID.Text, ref iVer, true) == true)
                {
                    if (View_Spec(iVer) == false)
                    {
                        return;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmSPCTranCapability.ChartIDSelected()\n" + ex.Message);
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
                ChartIDSelected();
                btnView.PerformClick();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.ChartInfo()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
        #region " Event Implematations"
        
        private void frmSPCTranCapability_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                MPCF.SetTextboxStyle(this.Controls);

                MPCF.FieldClear(this.pnlFillTop);
                uccStart.Value = DateTime.Now.AddMonths(- 1);
                udtStart.Value = "000000";
                uccEnd.Value = DateTime.Now;
                udtEnd.Value = "235959";
                modSPCFunctions.SetGraphList(cboGraphType);
                InitChart();
                
                pnlFillRight.Visible = chkViewChartOptions.Checked;
                cdvChartID.Text = modSPCFunctions.GetFilterKey();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.frmSPCTranCapability_Load()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCTranCapability_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    if (MPCF.Trim(MPGV.gsChartID) != "")
                    {
                        cdvChartID.Text = MPGV.gsChartID;
                        ChartInfo();
                    }
                    b_load_flag = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.frmSPCTranCapability_Activated()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartID_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                cdvChartID.Init();
                MPCF.InitListView(cdvChartID.GetListView);
                cdvChartID.Columns.Add("Chart", 50, HorizontalAlignment.Left);
                cdvChartID.Columns.Add("GraphType", 50, HorizontalAlignment.Left);
                cdvChartID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvChartID.SelectedSubItemIndex = 0;
                SPCLIST.ViewChartList(cdvChartID.GetListView, '2', "", 0,"", "", "", ' ', ' ', MPCF.Trim(cdvChartID.Text), "", -1, -1, null, "");
                cdvChartID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.cdvChartID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                ChartIDSelected();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmSPCTranCapability.cdvChartID_SelectedItemChanged()\n" + ex.Message);
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
                if (View_Histogram() == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmSPCTranCapability.btnView_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                this.Dispose();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.btnClose_Click()\n" + ex.Message);
            }
            
        }

        private void chkAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            tmrAutoRefresh.Enabled = chkAutoRefresh.Checked;
            tmrAutoRefresh.Interval = MPCF.ToInt(numRefreshSec.Value) * 1000;
        }

        private void tmrAutoRefresh_Tick(object sender, EventArgs e)
        {
            if (cdvChartID.Text == "") return;

            btnView.PerformClick();
        }

        private void chkViewChartOptions_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                pnlFillRight.Visible = chkViewChartOptions.Checked;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.chkViewChartOptions_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void chkIsViewNormalLine_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                Chart.IsViewNormalLine = chkIsViewNormalLine.Checked;
                Chart.Refresh();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.chkIsViewNormalLine_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void chkViewSpecLimit_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                Chart.IsViewSpecLimit = chkViewSpecLimit.Checked;
                Chart.Refresh();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.chkViewSpecLimit_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void chkView3sLine_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                Chart.IsView3sLine = chkView3sLine.Checked;
                Chart.Refresh();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.chkView3sLine_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void chkViewGridLine_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                Chart.IsViewGridLine = chkViewGridLine.Checked;
                Chart.Refresh();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.chkViewGridLine_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void chkViewFreqText_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                Chart.IsViewBarFreqText = chkViewFreqText.Checked;
                Chart.Refresh();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.chkViewFreqText_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                ChartIDSelected();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.btnRefresh_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnGraph_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                System.Windows.Forms.Form form;

                try
                {
                    form = MPCF.GetChildForm(MPGV.gfrmMDI, "frmSPCTranControlChart");
                    if (form == null)
                    {
                        form = new frmSPCTranControlChart();
                        form.MdiParent = MPGV.gfrmMDI;
                        form.Show();
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

                
                ((frmSPCTranControlChart) form).uccStart.Value = this.uccStart.Value;
                ((frmSPCTranControlChart) form).udtStart.Value = this.udtStart.Value;
                ((frmSPCTranControlChart) form).uccEnd.Value = this.uccEnd.Value;
                ((frmSPCTranControlChart) form).udtEnd.Value = this.udtEnd.Value;
                ((frmSPCTranControlChart) form).cdvChartID.Text = this.cdvChartID.Text;
                if (((frmSPCTranControlChart) form).cdvChartID.Text != "")
                {
                    ((frmSPCTranControlChart) form).ChartIDSelected();
                    ((frmSPCTranControlChart) form).btnView.PerformClick();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.btnGraph_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnViewRawData_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                System.Windows.Forms.Form form;

                try
                {
                    form = MPCF.GetChildForm(MPGV.gfrmMDI, "frmSPCViewEDCData");
                    if (form == null)
                    {
                        form = new frmSPCViewEDCData();
                        form.MdiParent = MPGV.gfrmMDI;
                        form.Show();
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
                
                ((frmSPCViewEDCData) form).uccStart.Value = this.uccStart.Value;
                ((frmSPCViewEDCData) form).udtStart.Value = this.udtStart.Value;
                ((frmSPCViewEDCData) form).uccEnd.Value = this.uccEnd.Value;
                ((frmSPCViewEDCData) form).udtEnd.Value = this.udtEnd.Value;
                ((frmSPCViewEDCData) form).cdvChartID.Text = this.cdvChartID.Text;
                if (((frmSPCViewEDCData) form).cdvChartID.Text != "")
                {
                    ((frmSPCViewEDCData) form).Set_Data();
                    ((frmSPCViewEDCData) form).btnView.PerformClick();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.btnViewRawData_Click()\n" + ex.Message);
            }
            
        }
        
        private void spdDataInfo_Resize(object sender, System.EventArgs e)
        {
            
            try
            {
                int iDiffSize;
                
                iDiffSize = (spdDataInfo.Size.Width - 780) / 4;
                
                if (iDiffSize >= 0)
                {
                    spdDataInfo.Sheets[0].Columns[1].Width = 97 + iDiffSize;
                    spdDataInfo.Sheets[0].Columns[3].Width = 97 + iDiffSize;
                    spdDataInfo.Sheets[0].Columns[5].Width = 97 + iDiffSize;
                    spdDataInfo.Sheets[0].Columns[7].Width = 97 + iDiffSize;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.spdDataInfo_Resize()\n" + ex.Message);
            }
            
        }
        
        private void chkUseSpec_CheckedChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                grpSpecOption.Visible = chkUseSpec.Checked;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.chkUseSpec_CheckedChanged()\n" + ex.Message);
            }
            
        }

        private void chkUserInputSize_CheckedChanged(object sender, System.EventArgs e)
        {

            try
            {
                txtBinSize.Visible = chkUserInputSize.Checked;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.chkUserInputSize_CheckedChanged()\n" + ex.Message);
            }

        }
        
        private void txtNumber_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            try
            {
                if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
                {
                    if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                    {
                        if (e.KeyChar == (char)46)
                        {
                            if (((UltraTextEditor) sender).Text == "" || ((UltraTextEditor)sender).Text.Contains(".") == true)
                            {
                                e.Handled = true;
                            }
                        }
                        else if (e.KeyChar == (char)45)
                        {
                            if ((((UltraTextEditor) sender).SelectedText == "" && ((UltraTextEditor) sender).Text != "") || ((UltraTextEditor)sender).Text.Contains("-") == true)
                            {
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.txtNumber_KeyPress()\n" + ex.Message);
            }
            
        }
        
        private void btnCopyImage_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (Chart.CopyImage() == true)
                {
                    //Do Nothing
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.btnCopyImage_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnSaveImage_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Png Image|*.png";
                dlg.Title = "Save an Image File";
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Chart.SaveImage(dlg.FileName);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.btnSaveImage_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnPrint_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (Chart.Print() == true)
                {
                    //Do Nothing
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCapability.btnPrint_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnFiltering_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                frmSPCViewChartList form = new frmSPCViewChartList();
                form.StartPosition = FormStartPosition.CenterParent;
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
                MPCF.ShowMsgBox("frmSPCTranCapability.btnFiltering_Click()\n" + ex.Message);
            }
            
        }
        
        #endregion


    }
    
    
    //#End If
    
}
