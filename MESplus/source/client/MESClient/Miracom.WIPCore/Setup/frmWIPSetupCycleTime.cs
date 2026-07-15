
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPSetupCycleTime.vb
//   Description : Cycle Time Setup
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - View_MFO_CycleTime_List() : View Cycle Time List MFO Relation
//       - Update_CycleTime() : Update Cycle Time MFO Relation
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-25 : Created by CM Koo
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
using System.Globalization;


namespace Miracom.WIPCore
{
    public class frmWIPSetupCycleTime : Miracom.MESCore.SetupForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPSetupCycleTime()
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
        


        //ì½”ë“œ ?¸ì§‘ê¸°ë? ?¬ìš©?˜ì—¬ ?˜ì •?˜ì? ë§ˆì‹­?œì˜¤.
        private System.Windows.Forms.TabControl tabOptLevel;
        private System.Windows.Forms.TabPage tbpOper;
        private System.Windows.Forms.TabPage tbpFlowOper;
        private System.Windows.Forms.TabPage tbpMatFlowOper;
        private System.Windows.Forms.Panel pnlFOTop;
        private System.Windows.Forms.Panel pnlFOMid;
        private FarPoint.Win.Spread.FpSpread spdFO;
        private FarPoint.Win.Spread.SheetView spdFO_Sheet1;
        private FarPoint.Win.Spread.FpSpread spdOper;
        private FarPoint.Win.Spread.SheetView spdOper_Sheet1;
        private FarPoint.Win.Spread.FpSpread spdMFO;
        private FarPoint.Win.Spread.SheetView spdMFO_Sheet1;
        private System.Windows.Forms.Panel pnlMFOMid;
        private System.Windows.Forms.Panel pnlMFOTop;
        private System.Windows.Forms.GroupBox grpFlow;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFlow;
        private System.Windows.Forms.Label lblFlow;
        private System.Windows.Forms.GroupBox grpMat;
        private Miracom.MESCore.Controls.udcMaterial cdvMatID;
        protected Button btnExcel;
        private System.Windows.Forms.Button btnRefresh;
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
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType3 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType4 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType5 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType7 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType6 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType8 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer5 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer6 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType7 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType9 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType10 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType8 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType11 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType9 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType12 = new FarPoint.Win.Spread.CellType.NumberCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWIPSetupCycleTime));
            this.tabOptLevel = new System.Windows.Forms.TabControl();
            this.tbpOper = new System.Windows.Forms.TabPage();
            this.spdOper = new FarPoint.Win.Spread.FpSpread();
            this.spdOper_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tbpFlowOper = new System.Windows.Forms.TabPage();
            this.pnlFOMid = new System.Windows.Forms.Panel();
            this.spdFO = new FarPoint.Win.Spread.FpSpread();
            this.spdFO_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlFOTop = new System.Windows.Forms.Panel();
            this.grpFlow = new System.Windows.Forms.GroupBox();
            this.cdvFlow = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblFlow = new System.Windows.Forms.Label();
            this.tbpMatFlowOper = new System.Windows.Forms.TabPage();
            this.pnlMFOMid = new System.Windows.Forms.Panel();
            this.spdMFO = new FarPoint.Win.Spread.FpSpread();
            this.spdMFO_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlMFOTop = new System.Windows.Forms.Panel();
            this.grpMat = new System.Windows.Forms.GroupBox();
            this.cdvMatID = new Miracom.MESCore.Controls.udcMaterial();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tabOptLevel.SuspendLayout();
            this.tbpOper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdOper_Sheet1)).BeginInit();
            this.tbpFlowOper.SuspendLayout();
            this.pnlFOMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdFO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdFO_Sheet1)).BeginInit();
            this.pnlFOTop.SuspendLayout();
            this.grpFlow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).BeginInit();
            this.tbpMatFlowOper.SuspendLayout();
            this.pnlMFOMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdMFO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMFO_Sheet1)).BeginInit();
            this.pnlMFOTop.SuspendLayout();
            this.grpMat.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Visible = false;
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
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.TabIndex = 0;
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.tabOptLevel);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm01";
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
            // 
            // tabOptLevel
            // 
            this.tabOptLevel.Controls.Add(this.tbpOper);
            this.tabOptLevel.Controls.Add(this.tbpFlowOper);
            this.tabOptLevel.Controls.Add(this.tbpMatFlowOper);
            this.tabOptLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOptLevel.ItemSize = new System.Drawing.Size(66, 17);
            this.tabOptLevel.Location = new System.Drawing.Point(0, 0);
            this.tabOptLevel.Name = "tabOptLevel";
            this.tabOptLevel.SelectedIndex = 0;
            this.tabOptLevel.Size = new System.Drawing.Size(742, 506);
            this.tabOptLevel.TabIndex = 0;
            // 
            // tbpOper
            // 
            this.tbpOper.Controls.Add(this.spdOper);
            this.tbpOper.Location = new System.Drawing.Point(4, 21);
            this.tbpOper.Name = "tbpOper";
            this.tbpOper.Padding = new System.Windows.Forms.Padding(2);
            this.tbpOper.Size = new System.Drawing.Size(734, 481);
            this.tbpOper.TabIndex = 0;
            this.tbpOper.Text = "Operation";
            // 
            // spdOper
            // 
            this.spdOper.AccessibleDescription = "spdOper, Sheet1, Row 0, Column 0, ";
            this.spdOper.BackColor = System.Drawing.SystemColors.Control;
            this.spdOper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdOper.EditModeReplace = true;
            this.spdOper.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdOper.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdOper.HorizontalScrollBar.Name = "";
            this.spdOper.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdOper.HorizontalScrollBar.TabIndex = 8;
            this.spdOper.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdOper.Location = new System.Drawing.Point(2, 2);
            this.spdOper.Name = "spdOper";
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
            this.spdOper.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdOper.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdOper.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdOper.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdOper.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdOper_Sheet1});
            this.spdOper.Size = new System.Drawing.Size(730, 477);
            this.spdOper.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdOper.TabIndex = 0;
            this.spdOper.TabStop = false;
            this.spdOper.TextTipDelay = 200;
            this.spdOper.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdOper.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdOper.VerticalScrollBar.Name = "";
            this.spdOper.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdOper.VerticalScrollBar.TabIndex = 9;
            this.spdOper.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.O_FO_EditChange);
            // 
            // spdOper_Sheet1
            // 
            this.spdOper_Sheet1.Reset();
            spdOper_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdOper_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdOper_Sheet1.ColumnCount = 9;
            spdOper_Sheet1.RowCount = 3;
            this.spdOper_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOper_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdOper_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOper_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Oper";
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Oper Desc";
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Queue Time";
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Proc Time";
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 5).ColumnSpan = 2;
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Hour per Unit";
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 7).ColumnSpan = 2;
            this.spdOper_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Unit per Hour";
            this.spdOper_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOper_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdOper_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            checkBoxCellType1.TextAlign = FarPoint.Win.ButtonTextAlign.TextLeftPictRight;
            this.spdOper_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdOper_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdOper_Sheet1.Columns.Get(0).Width = 25F;
            this.spdOper_Sheet1.Columns.Get(1).Label = "Oper";
            this.spdOper_Sheet1.Columns.Get(1).Locked = true;
            this.spdOper_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(1).Width = 70F;
            this.spdOper_Sheet1.Columns.Get(2).Label = "Oper Desc";
            this.spdOper_Sheet1.Columns.Get(2).Locked = true;
            this.spdOper_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(2).Width = 200F;
            numberCellType1.DecimalPlaces = 3;
            numberCellType1.DecimalSeparator = ".";
            numberCellType1.MaximumValue = 9999999.999D;
            numberCellType1.MinimumValue = 0D;
            numberCellType1.Separator = ",";
            numberCellType1.SpinButton = true;
            numberCellType1.SpinDecimalIncrement = 0.001F;
            this.spdOper_Sheet1.Columns.Get(3).CellType = numberCellType1;
            this.spdOper_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdOper_Sheet1.Columns.Get(3).Label = "Queue Time";
            this.spdOper_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(3).Width = 80F;
            numberCellType2.DecimalPlaces = 3;
            numberCellType2.DecimalSeparator = ".";
            numberCellType2.MaximumValue = 9999999.999D;
            numberCellType2.MinimumValue = 0D;
            numberCellType2.Separator = ",";
            numberCellType2.SpinButton = true;
            numberCellType2.SpinDecimalIncrement = 0.001F;
            this.spdOper_Sheet1.Columns.Get(4).CellType = numberCellType2;
            this.spdOper_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdOper_Sheet1.Columns.Get(4).Label = "Proc Time";
            this.spdOper_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(4).Width = 80F;
            checkBoxCellType2.TextAlign = FarPoint.Win.ButtonTextAlign.TextLeftPictRight;
            this.spdOper_Sheet1.Columns.Get(5).CellType = checkBoxCellType2;
            this.spdOper_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(5).Label = "Hour per Unit";
            this.spdOper_Sheet1.Columns.Get(5).Locked = true;
            this.spdOper_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(5).Width = 25F;
            numberCellType3.DecimalPlaces = 3;
            numberCellType3.DecimalSeparator = ".";
            numberCellType3.MaximumValue = 9999999.999D;
            numberCellType3.MinimumValue = 0D;
            numberCellType3.Separator = ",";
            numberCellType3.SpinButton = true;
            numberCellType3.SpinDecimalIncrement = 0.001F;
            this.spdOper_Sheet1.Columns.Get(6).CellType = numberCellType3;
            this.spdOper_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdOper_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(6).Width = 80F;
            checkBoxCellType3.TextAlign = FarPoint.Win.ButtonTextAlign.TextLeftPictRight;
            this.spdOper_Sheet1.Columns.Get(7).CellType = checkBoxCellType3;
            this.spdOper_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(7).Label = "Unit per Hour";
            this.spdOper_Sheet1.Columns.Get(7).Locked = true;
            this.spdOper_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(7).Width = 25F;
            numberCellType4.DecimalPlaces = 3;
            numberCellType4.DecimalSeparator = ".";
            numberCellType4.MaximumValue = 9999999.999D;
            numberCellType4.MinimumValue = 0D;
            numberCellType4.Separator = ",";
            numberCellType4.SpinButton = true;
            numberCellType4.SpinDecimalIncrement = 0.001F;
            this.spdOper_Sheet1.Columns.Get(8).CellType = numberCellType4;
            this.spdOper_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdOper_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdOper_Sheet1.Columns.Get(8).Width = 80F;
            this.spdOper_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdOper_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdOper_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOper_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdOper_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOper_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdOper_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tbpFlowOper
            // 
            this.tbpFlowOper.Controls.Add(this.pnlFOMid);
            this.tbpFlowOper.Controls.Add(this.pnlFOTop);
            this.tbpFlowOper.Location = new System.Drawing.Point(4, 21);
            this.tbpFlowOper.Name = "tbpFlowOper";
            this.tbpFlowOper.Size = new System.Drawing.Size(734, 481);
            this.tbpFlowOper.TabIndex = 1;
            this.tbpFlowOper.Text = "Flow-Operation";
            // 
            // pnlFOMid
            // 
            this.pnlFOMid.Controls.Add(this.spdFO);
            this.pnlFOMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFOMid.Location = new System.Drawing.Point(0, 47);
            this.pnlFOMid.Name = "pnlFOMid";
            this.pnlFOMid.Padding = new System.Windows.Forms.Padding(2);
            this.pnlFOMid.Size = new System.Drawing.Size(734, 434);
            this.pnlFOMid.TabIndex = 0;
            // 
            // spdFO
            // 
            this.spdFO.AccessibleDescription = "spdFO, Sheet1, Row 0, Column 0, ";
            this.spdFO.BackColor = System.Drawing.SystemColors.Control;
            this.spdFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdFO.EditModeReplace = true;
            this.spdFO.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdFO.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdFO.HorizontalScrollBar.Name = "";
            this.spdFO.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdFO.HorizontalScrollBar.TabIndex = 2;
            this.spdFO.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdFO.Location = new System.Drawing.Point(2, 2);
            this.spdFO.Name = "spdFO";
            this.spdFO.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdFO.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdFO.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdFO_Sheet1});
            this.spdFO.Size = new System.Drawing.Size(730, 430);
            this.spdFO.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdFO.TabIndex = 0;
            this.spdFO.TabStop = false;
            this.spdFO.TextTipDelay = 200;
            this.spdFO.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdFO.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdFO.VerticalScrollBar.Name = "";
            this.spdFO.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdFO.VerticalScrollBar.TabIndex = 3;
            this.spdFO.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.O_FO_EditChange);
            // 
            // spdFO_Sheet1
            // 
            this.spdFO_Sheet1.Reset();
            spdFO_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdFO_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdFO_Sheet1.ColumnCount = 9;
            spdFO_Sheet1.RowCount = 3;
            this.spdFO_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFO_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdFO_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFO_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Oper";
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Oper Desc";
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Queue Time";
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Proc Time";
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 5).ColumnSpan = 2;
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Hour per Unit";
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 7).ColumnSpan = 2;
            this.spdFO_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Unit per Hour";
            this.spdFO_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFO_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdFO_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            checkBoxCellType4.TextAlign = FarPoint.Win.ButtonTextAlign.TextLeftPictRight;
            this.spdFO_Sheet1.Columns.Get(0).CellType = checkBoxCellType4;
            this.spdFO_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdFO_Sheet1.Columns.Get(0).Width = 25F;
            this.spdFO_Sheet1.Columns.Get(1).Label = "Oper";
            this.spdFO_Sheet1.Columns.Get(1).Locked = true;
            this.spdFO_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(1).Width = 70F;
            this.spdFO_Sheet1.Columns.Get(2).Label = "Oper Desc";
            this.spdFO_Sheet1.Columns.Get(2).Locked = true;
            this.spdFO_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(2).Width = 200F;
            numberCellType5.DecimalPlaces = 3;
            numberCellType5.DecimalSeparator = ".";
            numberCellType5.MaximumValue = 9999999.999D;
            numberCellType5.MinimumValue = 0D;
            numberCellType5.Separator = ",";
            numberCellType5.SpinButton = true;
            numberCellType5.SpinDecimalIncrement = 0.001F;
            this.spdFO_Sheet1.Columns.Get(3).CellType = numberCellType5;
            this.spdFO_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdFO_Sheet1.Columns.Get(3).Label = "Queue Time";
            this.spdFO_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(3).Width = 80F;
            numberCellType6.DecimalPlaces = 3;
            numberCellType6.DecimalSeparator = ".";
            numberCellType6.MaximumValue = 9999999.999D;
            numberCellType6.MinimumValue = 0D;
            numberCellType6.Separator = ",";
            numberCellType6.SpinButton = true;
            numberCellType6.SpinDecimalIncrement = 0.001F;
            this.spdFO_Sheet1.Columns.Get(4).CellType = numberCellType6;
            this.spdFO_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdFO_Sheet1.Columns.Get(4).Label = "Proc Time";
            this.spdFO_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(4).Width = 80F;
            checkBoxCellType5.TextAlign = FarPoint.Win.ButtonTextAlign.TextLeftPictRight;
            this.spdFO_Sheet1.Columns.Get(5).CellType = checkBoxCellType5;
            this.spdFO_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(5).Label = "Hour per Unit";
            this.spdFO_Sheet1.Columns.Get(5).Locked = true;
            this.spdFO_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(5).Width = 25F;
            numberCellType7.DecimalPlaces = 3;
            numberCellType7.DecimalSeparator = ".";
            numberCellType7.MaximumValue = 9999999.999D;
            numberCellType7.MinimumValue = 0D;
            numberCellType7.Separator = ",";
            numberCellType7.SpinButton = true;
            numberCellType7.SpinDecimalIncrement = 0.001F;
            this.spdFO_Sheet1.Columns.Get(6).CellType = numberCellType7;
            this.spdFO_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdFO_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(6).Width = 80F;
            checkBoxCellType6.TextAlign = FarPoint.Win.ButtonTextAlign.TextLeftPictRight;
            this.spdFO_Sheet1.Columns.Get(7).CellType = checkBoxCellType6;
            this.spdFO_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(7).Label = "Unit per Hour";
            this.spdFO_Sheet1.Columns.Get(7).Locked = true;
            this.spdFO_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(7).Width = 25F;
            numberCellType8.DecimalPlaces = 3;
            numberCellType8.DecimalSeparator = ".";
            numberCellType8.MaximumValue = 9999999.999D;
            numberCellType8.MinimumValue = 0D;
            numberCellType8.Separator = ",";
            numberCellType8.SpinButton = true;
            numberCellType8.SpinDecimalIncrement = 0.001F;
            this.spdFO_Sheet1.Columns.Get(8).CellType = numberCellType8;
            this.spdFO_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdFO_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFO_Sheet1.Columns.Get(8).Width = 80F;
            this.spdFO_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdFO_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdFO_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFO_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdFO_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdFO_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdFO_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdFO_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlFOTop
            // 
            this.pnlFOTop.Controls.Add(this.grpFlow);
            this.pnlFOTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFOTop.Location = new System.Drawing.Point(0, 0);
            this.pnlFOTop.Name = "pnlFOTop";
            this.pnlFOTop.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pnlFOTop.Size = new System.Drawing.Size(734, 47);
            this.pnlFOTop.TabIndex = 0;
            // 
            // grpFlow
            // 
            this.grpFlow.Controls.Add(this.cdvFlow);
            this.grpFlow.Controls.Add(this.lblFlow);
            this.grpFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpFlow.Location = new System.Drawing.Point(2, 0);
            this.grpFlow.Name = "grpFlow";
            this.grpFlow.Size = new System.Drawing.Size(730, 47);
            this.grpFlow.TabIndex = 0;
            this.grpFlow.TabStop = false;
            // 
            // cdvFlow
            // 
            this.cdvFlow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvFlow.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFlow.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFlow.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFlow.BtnToolTipText = "";
            this.cdvFlow.DescText = "";
            this.cdvFlow.DisplaySubItemIndex = -1;
            this.cdvFlow.DisplayText = "";
            this.cdvFlow.Focusing = null;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.Index = 0;
            this.cdvFlow.IsViewBtnImage = false;
            this.cdvFlow.Location = new System.Drawing.Point(120, 16);
            this.cdvFlow.MaxLength = 20;
            this.cdvFlow.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.ReadOnly = false;
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = 1;
            this.cdvFlow.SelectedSubItemIndex = -1;
            this.cdvFlow.SelectionStart = 0;
            this.cdvFlow.Size = new System.Drawing.Size(602, 20);
            this.cdvFlow.SmallImageList = null;
            this.cdvFlow.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFlow.TabIndex = 1;
            this.cdvFlow.TextBoxToolTipText = "";
            this.cdvFlow.TextBoxWidth = 200;
            this.cdvFlow.VisibleButton = true;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = true;
            this.cdvFlow.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_SelectedItemChanged);
            this.cdvFlow.ButtonPress += new System.EventHandler(this.cdvFlow_ButtonPress);
            // 
            // lblFlow
            // 
            this.lblFlow.AutoSize = true;
            this.lblFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlow.Location = new System.Drawing.Point(15, 19);
            this.lblFlow.Name = "lblFlow";
            this.lblFlow.Size = new System.Drawing.Size(33, 13);
            this.lblFlow.TabIndex = 0;
            this.lblFlow.Text = "Flow";
            // 
            // tbpMatFlowOper
            // 
            this.tbpMatFlowOper.Controls.Add(this.pnlMFOMid);
            this.tbpMatFlowOper.Controls.Add(this.pnlMFOTop);
            this.tbpMatFlowOper.Location = new System.Drawing.Point(4, 21);
            this.tbpMatFlowOper.Name = "tbpMatFlowOper";
            this.tbpMatFlowOper.Size = new System.Drawing.Size(734, 481);
            this.tbpMatFlowOper.TabIndex = 2;
            this.tbpMatFlowOper.Text = "Material-Flow-Operation";
            // 
            // pnlMFOMid
            // 
            this.pnlMFOMid.Controls.Add(this.spdMFO);
            this.pnlMFOMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMFOMid.Location = new System.Drawing.Point(0, 47);
            this.pnlMFOMid.Name = "pnlMFOMid";
            this.pnlMFOMid.Padding = new System.Windows.Forms.Padding(2);
            this.pnlMFOMid.Size = new System.Drawing.Size(734, 434);
            this.pnlMFOMid.TabIndex = 0;
            // 
            // spdMFO
            // 
            this.spdMFO.AccessibleDescription = "spdMFO, Sheet1, Row 0, Column 0, ";
            this.spdMFO.BackColor = System.Drawing.SystemColors.Control;
            this.spdMFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdMFO.EditModeReplace = true;
            this.spdMFO.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdMFO.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMFO.HorizontalScrollBar.Name = "";
            this.spdMFO.HorizontalScrollBar.Renderer = defaultScrollBarRenderer5;
            this.spdMFO.HorizontalScrollBar.TabIndex = 2;
            this.spdMFO.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdMFO.Location = new System.Drawing.Point(2, 2);
            this.spdMFO.Name = "spdMFO";
            this.spdMFO.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdMFO.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdMFO.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdMFO_Sheet1});
            this.spdMFO.Size = new System.Drawing.Size(730, 430);
            this.spdMFO.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdMFO.TabIndex = 0;
            this.spdMFO.TabStop = false;
            this.spdMFO.TextTipDelay = 200;
            this.spdMFO.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdMFO.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMFO.VerticalScrollBar.Name = "";
            this.spdMFO.VerticalScrollBar.Renderer = defaultScrollBarRenderer6;
            this.spdMFO.VerticalScrollBar.TabIndex = 3;
            this.spdMFO.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.MFO_EditChange);
            // 
            // spdMFO_Sheet1
            // 
            this.spdMFO_Sheet1.Reset();
            spdMFO_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdMFO_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdMFO_Sheet1.ColumnCount = 11;
            spdMFO_Sheet1.RowCount = 3;
            this.spdMFO_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMFO_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdMFO_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMFO_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Flow";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "F Seq";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Oper";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Oper Desc";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Queue Time";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Proc Time";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 7).ColumnSpan = 2;
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Hour per Unit";
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 9).ColumnSpan = 2;
            this.spdMFO_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Unit per Hour";
            this.spdMFO_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMFO_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdMFO_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            checkBoxCellType7.TextAlign = FarPoint.Win.ButtonTextAlign.TextLeftPictRight;
            this.spdMFO_Sheet1.Columns.Get(0).CellType = checkBoxCellType7;
            this.spdMFO_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdMFO_Sheet1.Columns.Get(0).Width = 25F;
            this.spdMFO_Sheet1.Columns.Get(1).Label = "Flow";
            this.spdMFO_Sheet1.Columns.Get(1).Locked = true;
            this.spdMFO_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(1).Width = 100F;
            this.spdMFO_Sheet1.Columns.Get(2).Label = "F Seq";
            this.spdMFO_Sheet1.Columns.Get(2).Locked = true;
            this.spdMFO_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(2).Width = 37F;
            this.spdMFO_Sheet1.Columns.Get(3).Label = "Oper";
            this.spdMFO_Sheet1.Columns.Get(3).Locked = true;
            this.spdMFO_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(4).Label = "Oper Desc";
            this.spdMFO_Sheet1.Columns.Get(4).Locked = true;
            this.spdMFO_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(4).Width = 120F;
            numberCellType9.DecimalPlaces = 3;
            numberCellType9.DecimalSeparator = ".";
            numberCellType9.MaximumValue = 9999999.999D;
            numberCellType9.MinimumValue = 0D;
            numberCellType9.Separator = ",";
            numberCellType9.SpinButton = true;
            numberCellType9.SpinDecimalIncrement = 0.001F;
            this.spdMFO_Sheet1.Columns.Get(5).CellType = numberCellType9;
            this.spdMFO_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdMFO_Sheet1.Columns.Get(5).Label = "Queue Time";
            this.spdMFO_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(5).Width = 70F;
            numberCellType10.DecimalPlaces = 3;
            numberCellType10.DecimalSeparator = ".";
            numberCellType10.MaximumValue = 9999999.999D;
            numberCellType10.MinimumValue = 0D;
            numberCellType10.Separator = ",";
            numberCellType10.SpinButton = true;
            numberCellType10.SpinDecimalIncrement = 0.001F;
            this.spdMFO_Sheet1.Columns.Get(6).CellType = numberCellType10;
            this.spdMFO_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdMFO_Sheet1.Columns.Get(6).Label = "Proc Time";
            this.spdMFO_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(6).Width = 70F;
            checkBoxCellType8.TextAlign = FarPoint.Win.ButtonTextAlign.TextLeftPictRight;
            this.spdMFO_Sheet1.Columns.Get(7).CellType = checkBoxCellType8;
            this.spdMFO_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(7).Label = "Hour per Unit";
            this.spdMFO_Sheet1.Columns.Get(7).Locked = true;
            this.spdMFO_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(7).Width = 25F;
            numberCellType11.DecimalPlaces = 3;
            numberCellType11.DecimalSeparator = ".";
            numberCellType11.MaximumValue = 9999999.999D;
            numberCellType11.MinimumValue = 0D;
            numberCellType11.Separator = ",";
            numberCellType11.SpinButton = true;
            numberCellType11.SpinDecimalIncrement = 0.001F;
            this.spdMFO_Sheet1.Columns.Get(8).CellType = numberCellType11;
            this.spdMFO_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdMFO_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(8).Width = 70F;
            checkBoxCellType9.TextAlign = FarPoint.Win.ButtonTextAlign.TextLeftPictRight;
            this.spdMFO_Sheet1.Columns.Get(9).CellType = checkBoxCellType9;
            this.spdMFO_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(9).Label = "Unit per Hour";
            this.spdMFO_Sheet1.Columns.Get(9).Locked = true;
            this.spdMFO_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(9).Width = 25F;
            numberCellType12.DecimalPlaces = 3;
            numberCellType12.DecimalSeparator = ".";
            numberCellType12.MaximumValue = 9999999.999D;
            numberCellType12.MinimumValue = 0D;
            numberCellType12.Separator = ",";
            numberCellType12.SpinButton = true;
            numberCellType12.SpinDecimalIncrement = 0.001F;
            this.spdMFO_Sheet1.Columns.Get(10).CellType = numberCellType12;
            this.spdMFO_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdMFO_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMFO_Sheet1.Columns.Get(10).Width = 70F;
            this.spdMFO_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdMFO_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdMFO_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMFO_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdMFO_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMFO_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdMFO_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdMFO_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlMFOTop
            // 
            this.pnlMFOTop.Controls.Add(this.grpMat);
            this.pnlMFOTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMFOTop.Location = new System.Drawing.Point(0, 0);
            this.pnlMFOTop.Name = "pnlMFOTop";
            this.pnlMFOTop.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pnlMFOTop.Size = new System.Drawing.Size(734, 47);
            this.pnlMFOTop.TabIndex = 0;
            // 
            // grpMat
            // 
            this.grpMat.Controls.Add(this.cdvMatID);
            this.grpMat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMat.Location = new System.Drawing.Point(2, 0);
            this.grpMat.Name = "grpMat";
            this.grpMat.Size = new System.Drawing.Size(730, 47);
            this.grpMat.TabIndex = 0;
            this.grpMat.TabStop = false;
            // 
            // cdvMatID
            // 
            this.cdvMatID.AddEmptyRowToLast = false;
            this.cdvMatID.AddEmptyRowToTop = false;
            this.cdvMatID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvMatID.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMatID.DisplaySubItemIndex = 0;
            this.cdvMatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMatID.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMatID.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMatID.LabelText = "Material";
            this.cdvMatID.ListCond_ExtFactory = "";
            this.cdvMatID.ListCond_StepMaterial = '1';
            this.cdvMatID.ListCond_StepVersion = '1';
            this.cdvMatID.Location = new System.Drawing.Point(12, 15);
            this.cdvMatID.MaterialEnabled = true;
            this.cdvMatID.MaterialReadOnly = false;
            this.cdvMatID.Name = "cdvMatID";
            this.cdvMatID.SearchSubItemIndex = 0;
            this.cdvMatID.SelectedDescIndex = 2;
            this.cdvMatID.SelectedSubItemIndex = 0;
            this.cdvMatID.Size = new System.Drawing.Size(710, 20);
            this.cdvMatID.TabIndex = 0;
            this.cdvMatID.VersionEnabled = true;
            this.cdvMatID.VersionReadOnly = false;
            this.cdvMatID.VisibleColumnHeader = false;
            this.cdvMatID.VisibleDescription = true;
            this.cdvMatID.VisibleMaterialButton = true;
            this.cdvMatID.VisibleVersionButton = true;
            this.cdvMatID.WidthButton = 20;
            this.cdvMatID.WidthLabel = 108;
            this.cdvMatID.WidthMaterialAndVersion = 200;
            this.cdvMatID.WidthVersion = 50;
            this.cdvMatID.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMatID_SelectedItemChanged);
            this.cdvMatID.VersionSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMatID_VersionSelectedItemChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(10, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(40, 6);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // frmWIPSetupCycleTime
            // 
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPSetupCycleTime";
            this.Text = "Cycle Time Setup";
            this.Activated += new System.EventHandler(this.frmWIPSetupCycleTime_Activated);
            this.Load += new System.EventHandler(this.frmWIPSetupCycleTime_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.tabOptLevel.ResumeLayout(false);
            this.tbpOper.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdOper_Sheet1)).EndInit();
            this.tbpFlowOper.ResumeLayout(false);
            this.pnlFOMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdFO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdFO_Sheet1)).EndInit();
            this.pnlFOTop.ResumeLayout(false);
            this.grpFlow.ResumeLayout(false);
            this.grpFlow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).EndInit();
            this.tbpMatFlowOper.ResumeLayout(false);
            this.pnlMFOMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdMFO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMFO_Sheet1)).EndInit();
            this.pnlMFOTop.ResumeLayout(false);
            this.grpMat.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const int MAX_CYCLETIME_UPDATE_CNT = 1000;
        private const int COL_HPU = 5;
        private const int COL_UPH = 7;
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        #endregion
        
        #region " Function Definition "
        
        // CheckCondition()
        //       -   Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : create/update/delete Function name
        private bool CheckCondition(string sProc)
        {
            FarPoint.Win.Spread.SheetView sheet = new FarPoint.Win.Spread.SheetView();
            
            int i;
            bool bCheck;
            //string sOptLevel;
            
            if (tabOptLevel.SelectedTab == tbpOper)
            {
                //sOptLevel = "3";
                sheet = spdOper.ActiveSheet;
            }
            else if (tabOptLevel.SelectedTab == tbpFlowOper)
            {
                //sOptLevel = "2";
                sheet = spdFO.ActiveSheet;
            }
            else if (tabOptLevel.SelectedTab == tbpMatFlowOper)
            {
                //sOptLevel = "1";
                sheet = spdMFO.ActiveSheet;
            }
            
            if (sheet.RowCount <= 0)
            {
                return false;
            }
            
            bCheck = false;
            for (i = 0; i <= sheet.RowCount - 1; i++)
            {
                if (sheet.Cells[i, 0].Value != null && Convert.ToBoolean(sheet.Cells[i, 0].Value) == true)
                {
                    bCheck = true;
                    break;
                }
            }
            
            if (bCheck == false)
            {
                return false;
            }
            
            switch (sProc)
            {
                case "UPDATE":
                    
                    break;
                case "DELETE":
                    
                    break;
            }
            
            return true;
        }
        
        // View_MFO_CycleTime_List()
        //       - View MFO-Cycle Time Relation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool View_MFO_CycleTime_List(char OptLevel)
        {

            TRSNode in_node = new TRSNode("VIEW_CYCLETIME_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_CYCLETIME_LIST_OUT");
            int i;
            int iLastRow;
            FarPoint.Win.Spread.SheetView sheet = new FarPoint.Win.Spread.SheetView();

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddChar("OPT_LEVEL", OptLevel);

                switch (OptLevel)
                {
                    case '1':

                        in_node.AddString("MAT_ID", cdvMatID.Text);
                        in_node.AddInt("MAT_VER", cdvMatID.Version);

                        sheet = spdMFO.ActiveSheet;
                        break;
                    case '2':

                        in_node.AddString("FLOW", cdvFlow.Text);

                        sheet = spdFO.ActiveSheet;
                        break;
                    case '3':

                        sheet = spdOper.ActiveSheet;
                        break;
                }

                sheet.RowCount = 0;

                if (OptLevel == '1')
                {
                    do
                    {
                        if (MPCR.CallService("WIP", "WIP_View_CycleTime_List", in_node, ref out_node) == false)
                        {
                            return false;
                        }

                        for (i = 0; i < out_node.GetList(0).Count; i++)
                        {
                            iLastRow = sheet.RowCount;
                            sheet.RowCount++;

                            sheet.SetValue(iLastRow, 1, MPCF.Trim(out_node.GetList(0)[i].GetString("FLOW")));
                            sheet.SetValue(iLastRow, 2, MPCF.Trim(out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM")));
                            sheet.SetValue(iLastRow, 3, MPCF.Trim(out_node.GetList(0)[i].GetString("OPER")));
                            sheet.SetValue(iLastRow, 4, MPCF.Trim(out_node.GetList(0)[i].GetString("OPER_DESC")));
                            sheet.SetValue(iLastRow, 5, out_node.GetList(0)[i].GetDouble("QUEUE_TIME"));
                            sheet.SetValue(iLastRow, 6, out_node.GetList(0)[i].GetDouble("PROC_TIME"));
                            if (out_node.GetList(0)[i].GetChar("HPU_FLAG") == 'Y')
                            {
                                sheet.SetValue(iLastRow, 7, true);
                            }
                            else
                            {
                                sheet.SetValue(iLastRow, 7, false);
                            }
                            sheet.SetValue(iLastRow, 8, out_node.GetList(0)[i].GetDouble("HPU_PROC_TIME"));
                            if (out_node.GetList(0)[i].GetChar("UPH_FLAG") == 'Y')
                            {
                                sheet.SetValue(iLastRow, 9, true);
                            }
                            else
                            {
                                sheet.SetValue(iLastRow, 9, false);
                            }
                            sheet.SetValue(iLastRow, 10, out_node.GetList(0)[i].GetDouble("UPH_PROC_TIME"));
                        }

                        in_node.SetString("FLOW", out_node.GetString("FLOW"));
                        in_node.SetInt("FLOW_SEQ_NUM", out_node.GetInt("FLOW_SEQ_NUM"));
                        in_node.SetString("OPER", out_node.GetString("OPER"));

                    } while (in_node.GetString("OPER") != "");

                    sheet.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
                    sheet.Columns.Get(2).BackColor = System.Drawing.Color.WhiteSmoke;
                    sheet.Columns.Get(3).BackColor = System.Drawing.Color.WhiteSmoke;
                    sheet.Columns.Get(4).BackColor = System.Drawing.Color.WhiteSmoke;
                }
                else
                {
                    do
                    {
                        if (MPCR.CallService("WIP", "WIP_View_CycleTime_List", in_node, ref out_node) == false)
                        {
                            return false;
                        }

                        for (i = 0; i < out_node.GetList(0).Count; i++)
                        {
                            iLastRow = sheet.RowCount;
                            sheet.RowCount++;

                            sheet.SetValue(iLastRow, 1, MPCF.Trim(out_node.GetList(0)[i].GetString("OPER")));
                            sheet.SetValue(iLastRow, 2, MPCF.Trim(out_node.GetList(0)[i].GetString("OPER_DESC")));
                            sheet.SetValue(iLastRow, 3, out_node.GetList(0)[i].GetDouble("QUEUE_TIME"));
                            sheet.SetValue(iLastRow, 4, out_node.GetList(0)[i].GetDouble("PROC_TIME"));
                            if (out_node.GetList(0)[i].GetChar("HPU_FLAG") == 'Y')
                            {
                                sheet.SetValue(iLastRow, 5, true);
                            }
                            else
                            {
                                sheet.SetValue(iLastRow, 5, false);
                            }
                            sheet.SetValue(iLastRow, 6, out_node.GetList(0)[i].GetDouble("HPU_PROC_TIME"));
                            if (out_node.GetList(0)[i].GetChar("UPH_FLAG") == 'Y')
                            {
                                sheet.SetValue(iLastRow, 7, true);
                            }
                            else
                            {
                                sheet.SetValue(iLastRow, 7, false);
                            }
                            sheet.SetValue(iLastRow, 8, out_node.GetList(0)[i].GetDouble("UPH_PROC_TIME"));
                        }

                        in_node.SetString("OPER", out_node.GetString("OPER"));

                    } while (in_node.GetString("OPER") != "");

                    sheet.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
                    sheet.Columns.Get(2).BackColor = System.Drawing.Color.WhiteSmoke;
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        // Update_CycleTime()
        //       - Update MFO-Cycle Time Relation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool Update_CycleTime(char ProcStep)
        {

            TRSNode in_node = new TRSNode("UPDATE_CYCLETIME_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode list_item;
            int i;

            char sOptLevel = ' ';
            string sMatID;
            int iMatVer;
            string sFlow;
            int iFlowSeq;

            int iOperIdx;
            int iQueIdx;
            int iProcIdx;
            int iHpuFlagIdx;
            int iHpuProcIdx;
            int iUphFlagIdx;
            int iUphProcIdx;

            FarPoint.Win.Spread.SheetView sheet = new FarPoint.Win.Spread.SheetView();

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                sMatID = "";
                iMatVer = 0;
                sFlow = "";
                iFlowSeq = 0;

                iOperIdx = 1;
                iQueIdx = 3;
                iProcIdx = 4;
                iHpuFlagIdx = 5;
                iHpuProcIdx = 6;
                iUphFlagIdx = 7;
                iUphProcIdx = 8;

                if (tabOptLevel.SelectedTab == tbpOper)
                {
                    sOptLevel = '3';
                    sheet = spdOper.ActiveSheet;
                }
                else if (tabOptLevel.SelectedTab == tbpFlowOper)
                {
                    sOptLevel = '2';
                    sheet = spdFO.ActiveSheet;
                    sFlow = MPCF.Trim(cdvFlow.Text);
                }
                else if (tabOptLevel.SelectedTab == tbpMatFlowOper)
                {
                    sOptLevel = '1';
                    sheet = spdMFO.ActiveSheet;
                    sMatID = MPCF.Trim(cdvMatID.Text);
                    iMatVer = cdvMatID.Version;

                    iOperIdx = 3;
                    iQueIdx = 5;
                    iProcIdx = 6;
                    iHpuFlagIdx = 7;
                    iHpuProcIdx = 8;
                    iUphFlagIdx = 9;
                    iUphProcIdx = 10;
                }

                for (i = 0; i < sheet.RowCount; i++)
                {
                    if (sheet.Cells[i, 0].Value != null && Convert.ToBoolean(sheet.Cells[i, 0].Value) == true)
                    {
                        list_item = in_node.AddNode("LIST");

                        list_item.AddChar("OPT_LEVEL", sOptLevel);
                        list_item.AddString("MAT_ID", sMatID);
                        list_item.AddInt("MAT_VER", iMatVer);

                        if (sOptLevel == '1')
                        {
                            sFlow = MPCF.Trim(sheet.Cells[i, 1].Value);
                            iFlowSeq = MPCF.ToInt(sheet.Cells[i, 2].Value);
                        }

                        list_item.AddString("FLOW", sFlow);
                        list_item.AddInt("FLOW_SEQ_NUM", iFlowSeq);
                        list_item.AddString("OPER", MPCF.Trim(sheet.Cells[i, iOperIdx].Value));

                        list_item.AddDouble("QUEUE_TIME", MPCF.ToDbl(sheet.Cells[i, iQueIdx].Value));
                        list_item.AddDouble("PROC_TIME", MPCF.ToDbl(sheet.Cells[i, iProcIdx].Value));
                        list_item.AddChar("HPU_FLAG", (System.Convert.ToBoolean(sheet.Cells[i, iHpuFlagIdx].Value) == true) ? 'Y' : ' ');
                        list_item.AddDouble("HPU_PROC_TIME", MPCF.ToDbl(sheet.Cells[i, iHpuProcIdx].Value));
                        list_item.AddChar("UPH_FLAG", (System.Convert.ToBoolean(sheet.Cells[i, iUphFlagIdx].Value) == true) ? 'Y' : ' ');
                        list_item.AddDouble("UPH_PROC_TIME", MPCF.ToDbl(sheet.Cells[i, iUphProcIdx].Value));

                        if (in_node.GetList(0).Count >= MAX_CYCLETIME_UPDATE_CNT)
                        {
                            if (MPCR.CallService("WIP", "WIP_Update_CycleTime", in_node, ref out_node) == false)
                            {
                                return false;
                            }
                        }
                    }
                }

                if (in_node.GetList(0).Count > 0)
                {
                    if (MPCR.CallService("WIP", "WIP_Update_CycleTime", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                }

                MPCR.ShowSuccessMsg(out_node);

                if (ProcStep == MPGC.MP_STEP_DELETE)
                {
                    sheet.RowCount = 0;
                    View_MFO_CycleTime_List(sOptLevel);
                }
                else
                {
                    for (i = 0; i <= sheet.RowCount - 1; i++)
                    {
                        if (sheet.Cells[i, 0].Value != null && Convert.ToBoolean(sheet.Cells[i, 0].Value) == true)
                        {
                            sheet.Cells[i, 0].Value = false;
                        }
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.tabOptLevel;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmWIPSetupCycleTime_Load(object sender, System.EventArgs e)
        {
            if (MPGO.CycleTimeUnit() == "M")
            {
                this.spdOper.ActiveSheet.ColumnHeader.Cells.Get(0, COL_HPU).Text = "Minute per Unit";
                this.spdOper.ActiveSheet.ColumnHeader.Cells.Get(0, COL_UPH).Text = "Unit per Minute";
                
                this.spdFO.ActiveSheet.ColumnHeader.Cells.Get(0, COL_HPU).Text = "Minute per Unit";
                this.spdFO.ActiveSheet.ColumnHeader.Cells.Get(0, COL_UPH).Text = "Unit per Minute";
                
                this.spdMFO.ActiveSheet.ColumnHeader.Cells.Get(0, COL_HPU + 2).Text = "Minute per Unit";
                this.spdMFO.ActiveSheet.ColumnHeader.Cells.Get(0, COL_UPH + 2).Text = "Unit per Minute";
            }
        }
        
        private void frmWIPSetupCycleTime_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdOper);
                MPCF.ClearList(spdFO);
                MPCF.ClearList(spdMFO);

                tabOptLevel.SelectedTab = tbpOper;
                View_MFO_CycleTime_List('3');
                b_load_flag = true;
            }
            
        }
        
        private void cdvMatID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvMatID.Text) != "")
            {
                MPCF.ClearList(spdMFO);
                View_MFO_CycleTime_List('1');
            }
        }
        
        private void cdvFlow_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvFlow.Text) != "")
            {
                MPCF.ClearList(spdFO);
                View_MFO_CycleTime_List('2');
            }
        }
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            
            if (CheckCondition("UPDATE") == false)
            {
                return;
            }
            if (Update_CycleTime(MPGC.MP_STEP_UPDATE) == true)
            {
            }
            
        }
        
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            
            if (CheckCondition("DELETE") == false)
            {
                return;
            }
            if (Update_CycleTime(MPGC.MP_STEP_DELETE) == true)
            {
            }
            
        }
        
        private void O_FO_EditChange(System.Object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            const int COL_SEL = 0;
            const int COL_QUEUE = 3;
            const int COL_PROC = 4;
            const int COL_HPU = 6;
            const int COL_UPH = 8;
            
            FarPoint.Win.Spread.SheetView sheet =  new FarPoint.Win.Spread.SheetView();
            
            if (!(e.Column == COL_QUEUE || e.Column == COL_PROC || e.Column == COL_HPU || e.Column == COL_UPH))
            {
                return;
            }
            sheet = ((FarPoint.Win.Spread.FpSpread) sender).ActiveSheet;
            sheet.Cells[e.Row, COL_SEL].Value = true;
            
            if (e.Column == COL_QUEUE || e.Column == COL_PROC)
            {
                return;
            }

            if (MPCF.ToDbl(sheet.Cells[e.Row, e.Column].Value) > -0.0005 && MPCF.ToDbl(sheet.Cells[e.Row, e.Column].Value) < 0.0005)
            {
                sheet.Cells[e.Row, e.Column].Value = 0;
                if (e.Column == COL_HPU)
                {
                    sheet.Cells[e.Row, COL_UPH].Value = 0;
                }
                else
                {
                    sheet.Cells[e.Row, COL_HPU].Value = 0;
                }
                sheet.Cells[e.Row, COL_HPU - 1].Value = false;
                sheet.Cells[e.Row, COL_UPH - 1].Value = false;
                return;
            }
            
            if (e.Column == COL_HPU)
            {
                sheet.Cells[e.Row, COL_UPH].Value = 1 / MPCF.ToDbl(sheet.Cells[e.Row, e.Column].Value);
                sheet.Cells[e.Row, COL_HPU - 1].Value = true;
                sheet.Cells[e.Row, COL_UPH - 1].Value = false;
            }
            else
            {
                sheet.Cells[e.Row, COL_HPU].Value = 1 / MPCF.ToDbl(sheet.Cells[e.Row, e.Column].Value);
                sheet.Cells[e.Row, COL_UPH - 1].Value = true;
                sheet.Cells[e.Row, COL_HPU - 1].Value = false;
            }
        }

        private void MFO_EditChange(System.Object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            const int COL_SEL = 0;
            const int COL_QUEUE = 5;
            const int COL_PROC = 6;
            const int COL_HPU = 8;
            const int COL_UPH = 10;

            FarPoint.Win.Spread.SheetView sheet = new FarPoint.Win.Spread.SheetView();

            if (!(e.Column == COL_QUEUE || e.Column == COL_PROC || e.Column == COL_HPU || e.Column == COL_UPH))
            {
                return;
            }
            sheet = ((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet;
            sheet.Cells[e.Row, COL_SEL].Value = true;

            if (e.Column == COL_QUEUE || e.Column == COL_PROC)
            {
                return;
            }

            if (MPCF.ToDbl(sheet.Cells[e.Row, e.Column].Value) > -0.0005 && MPCF.ToDbl(sheet.Cells[e.Row, e.Column].Value) < 0.0005)
            {
                sheet.Cells[e.Row, e.Column].Value = 0;
                if (e.Column == COL_HPU)
                {
                    sheet.Cells[e.Row, COL_UPH].Value = 0;
                }
                else
                {
                    sheet.Cells[e.Row, COL_HPU].Value = 0;
                }
                sheet.Cells[e.Row, COL_HPU - 1].Value = false;
                sheet.Cells[e.Row, COL_UPH - 1].Value = false;
                return;
            }

            if (e.Column == COL_HPU)
            {
                sheet.Cells[e.Row, COL_UPH].Value = 1 / MPCF.ToDbl(sheet.Cells[e.Row, e.Column].Value);
                sheet.Cells[e.Row, COL_HPU - 1].Value = true;
                sheet.Cells[e.Row, COL_UPH - 1].Value = false;
            }
            else
            {
                sheet.Cells[e.Row, COL_HPU].Value = 1 / MPCF.ToDbl(sheet.Cells[e.Row, e.Column].Value);
                sheet.Cells[e.Row, COL_UPH - 1].Value = true;
                sheet.Cells[e.Row, COL_HPU - 1].Value = false;
            }
        }
                
        private void cdvFlow_ButtonPress(object sender, System.EventArgs e)
        {
            cdvFlow.Init();
            MPCF.InitListView(cdvFlow.GetListView);
            cdvFlow.Columns.Add("Flow", 150, HorizontalAlignment.Left);
            cdvFlow.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvFlow.SelectedSubItemIndex = 0;
            cdvFlow.DisplaySubItemIndex = 0;
            cdvFlow.SelectedDescIndex = 1;
            cdvFlow.ReadOnly = true;
            WIPLIST.ViewFlowList(cdvFlow.GetListView, '1');
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                CultureInfo ci_local = CultureInfo.CurrentCulture;
                if (tabOptLevel.SelectedTab == this.tbpOper)
                {
                    MPCF.ClearList(spdOper);
                    View_MFO_CycleTime_List('3');
                }
                else if (tabOptLevel.SelectedTab == this.tbpFlowOper)
                {
                    if (MPCF.Trim(cdvFlow.Text) != "")
                    {
                        MPCF.ClearList(spdFO);
                        View_MFO_CycleTime_List('2');
                    }
                }
                else if (tabOptLevel.SelectedTab == this.tbpMatFlowOper)
                {
                    if (MPCF.Trim(cdvMatID.Text) != "")
                    {
                        MPCF.ClearList(spdMFO);
                        View_MFO_CycleTime_List('1');
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvMatID_VersionSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvMatID.Version > 0)
            {
                MPCF.ClearList(spdMFO);
                View_MFO_CycleTime_List('1');
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond = string.Empty;


                if (tabOptLevel.SelectedIndex == 0)
                {
                    MPCF.ExportToExcel(spdOper, this.Text, sCond);
                }
                else if (tabOptLevel.SelectedIndex == 1)
                {
                    sCond = "Flow : " + cdvFlow.Text;
                    MPCF.ExportToExcel(spdFO, this.Text, sCond);
                }
                else if (tabOptLevel.SelectedIndex == 2)
                {
                    sCond = "Material : " + cdvMatID.Text;
                    MPCF.ExportToExcel(spdMFO, this.Text, sCond);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
    }
    
}
