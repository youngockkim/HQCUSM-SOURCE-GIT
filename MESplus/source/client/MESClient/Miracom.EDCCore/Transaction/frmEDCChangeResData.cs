
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Globalization;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI.Controls;
using FarPoint.Win.Spread;
using Miracom.TRSCore;


//#If _EDC = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmEDCChangeResData.vb
//   Description : Changing Resource Data Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - CheckCondition() : Check the conditions before transaction
//       - Change_Res_Data() : Change Resource Data
//       - View_Resource_Data()  : View all Resource data list
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-07-08 : Created by W.Y. Choi
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


namespace Miracom.EDCCore
{
    public class frmEDCChangeResData : Miracom.MESCore.TranForm11
    {
        
#region " Windows Form auto generated code "
        
        public frmEDCChangeResData()
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
        



        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvEventID;
        private System.Windows.Forms.Label lblEvent;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.Panel pnlResourceData;
        private FarPoint.Win.Spread.FpSpread spdData;
        private FarPoint.Win.Spread.SheetView spdData_Sheet1;
        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private FpSpread spdHistory;
        private Splitter splitter1;
        private SheetView spdHistory_Sheet1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSubResource;
        private Label lblSubResID;
        private Button btnView;
        private System.Windows.Forms.Label lblTo;
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType13 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType14 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType15 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType16 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType17 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType18 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType19 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType20 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType21 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType22 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType23 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType24 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType25 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType26 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.cdvEventID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblEvent = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.pnlResourceData = new System.Windows.Forms.Panel();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.spdHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.cdvSubResource = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSubResID = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEventID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.pnlResourceData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).BeginInit();
            this.pnlPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubResource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranTop
            // 
            this.pnlTranTop.Size = new System.Drawing.Size(742, 102);
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Controls.Add(this.pnlResourceData);
            this.pnlTranCenter.Location = new System.Drawing.Point(0, 102);
            this.pnlTranCenter.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pnlTranCenter.Size = new System.Drawing.Size(742, 404);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvSubResource);
            this.grpOption.Controls.Add(this.lblSubResID);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Controls.Add(this.cdvEventID);
            this.grpOption.Controls.Add(this.cdvResID);
            this.grpOption.Controls.Add(this.lblEvent);
            this.grpOption.Controls.Add(this.lblResID);
            this.grpOption.Size = new System.Drawing.Size(736, 102);
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Visible = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.TabIndex = 0;
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            // 
            // pnlTop
            // 
            this.pnlTop.Padding = new System.Windows.Forms.Padding(1);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Location = new System.Drawing.Point(1, 1);
            this.lblFormTitle.Size = new System.Drawing.Size(740, 0);
            this.lblFormTitle.Text = "Change Resource Data";
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
            // cdvEventID
            // 
            this.cdvEventID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEventID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEventID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEventID.BtnToolTipText = "";
            this.cdvEventID.ButtonWidth = 20;
            this.cdvEventID.DescText = "";
            this.cdvEventID.DisplaySubItemIndex = -1;
            this.cdvEventID.DisplayText = "";
            this.cdvEventID.Focusing = null;
            this.cdvEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEventID.Index = 0;
            this.cdvEventID.IsViewBtnImage = false;
            this.cdvEventID.Location = new System.Drawing.Point(120, 64);
            this.cdvEventID.MaxLength = 12;
            this.cdvEventID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEventID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEventID.MultiSelect = false;
            this.cdvEventID.Name = "cdvEventID";
            this.cdvEventID.ReadOnly = true;
            this.cdvEventID.SameWidthHeightOfButton = false;
            this.cdvEventID.SearchSubItemIndex = 0;
            this.cdvEventID.SelectedDescIndex = -1;
            this.cdvEventID.SelectedDescToQueryText = "";
            this.cdvEventID.SelectedSubItemIndex = -1;
            this.cdvEventID.SelectedValueToQueryText = "";
            this.cdvEventID.SelectionStart = 0;
            this.cdvEventID.Size = new System.Drawing.Size(200, 20);
            this.cdvEventID.SmallImageList = null;
            this.cdvEventID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEventID.TabIndex = 5;
            this.cdvEventID.TextBoxToolTipText = "";
            this.cdvEventID.TextBoxWidth = 200;
            this.cdvEventID.VisibleButton = true;
            this.cdvEventID.VisibleColumnHeader = false;
            this.cdvEventID.VisibleDescription = false;
            this.cdvEventID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvEventID_SelectedItemChanged);
            this.cdvEventID.ButtonPress += new System.EventHandler(this.cdvEventID_ButtonPress);
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent.Location = new System.Drawing.Point(15, 67);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(49, 13);
            this.lblEvent.TabIndex = 4;
            this.lblEvent.Text = "Event ID";
            // 
            // cdvResID
            // 
            this.cdvResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResID.BtnToolTipText = "";
            this.cdvResID.ButtonWidth = 20;
            this.cdvResID.DescText = "";
            this.cdvResID.DisplaySubItemIndex = -1;
            this.cdvResID.DisplayText = "";
            this.cdvResID.Focusing = null;
            this.cdvResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResID.Index = 0;
            this.cdvResID.IsViewBtnImage = false;
            this.cdvResID.Location = new System.Drawing.Point(120, 16);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MultiSelect = false;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = true;
            this.cdvResID.SameWidthHeightOfButton = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedDescToQueryText = "";
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectedValueToQueryText = "";
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(200, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 1;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 200;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResID_SelectedItemChanged);
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(15, 19);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(78, 13);
            this.lblResID.TabIndex = 0;
            this.lblResID.Text = "Resource ID";
            // 
            // pnlResourceData
            // 
            this.pnlResourceData.Controls.Add(this.spdData);
            this.pnlResourceData.Controls.Add(this.splitter1);
            this.pnlResourceData.Controls.Add(this.spdHistory);
            this.pnlResourceData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResourceData.Location = new System.Drawing.Point(0, 2);
            this.pnlResourceData.Name = "pnlResourceData";
            this.pnlResourceData.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pnlResourceData.Size = new System.Drawing.Size(742, 402);
            this.pnlResourceData.TabIndex = 0;
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, Sheet1";
            this.spdData.BackColor = System.Drawing.SystemColors.Control;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.EditModeReplace = true;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 10;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.Location = new System.Drawing.Point(0, 166);
            this.spdData.Name = "spdData";
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
            this.spdData.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(742, 236);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 1;
            this.spdData.TabStop = false;
            this.spdData.TabStripRatio = 0.501972386587771D;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 11;
            this.spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.EditModeOff += new System.EventHandler(this.spdData_EditModeOff);
            this.spdData.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdData_EditChange);
            this.spdData.SetViewportLeftColumn(0, 0, 9);
            this.spdData.SetActiveViewport(0, -1, -1);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 47;
            spdData_Sheet1.ColumnHeader.RowCount = 2;
            spdData_Sheet1.RowCount = 0;
            this.spdData_Sheet1.ActiveColumnIndex = -1;
            this.spdData_Sheet1.ActiveRowIndex = -1;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Factory";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Resource";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Hist Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Event ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Collection Set ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Version";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Char Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 8).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Character";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 9).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Character Desc";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Spec";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Unit Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 12).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Unit ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 13).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = " Value Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 14).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = " Value Type";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 15).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = " Value Count";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 16).ColumnSpan = 25;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Value";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 41).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Spec Out Mask";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 42).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Update User ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 43).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 43).Value = "Update Time";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 44).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 44).Value = "Value Type 2";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 45).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 45).Value = "Value Count 2";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 1).Value = "Factory";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 2).Value = "Resource";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 3).Value = "Hist Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 4).Value = "Event ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 5).Value = "Collection Set ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 10).Value = "Spec";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 16).Value = "1";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 17).Value = "2";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 18).Value = "3";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 19).Value = "4";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 20).Value = "5";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 21).Value = "6";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 22).Value = "7";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 23).Value = "8";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 24).Value = "9";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 25).Value = "10";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 26).Value = "11";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 27).Value = "12";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 28).Value = "13";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 29).Value = "14";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 30).Value = "15";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 31).Value = "16";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 32).Value = "17";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 33).Value = "18";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 34).Value = "19";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 35).Value = "20";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 36).Value = "21";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 37).Value = "22";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 38).Value = "23";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 39).Value = "24";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 40).Value = "25";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnHeader.Rows.Get(0).Height = 16F;
            this.spdData_Sheet1.ColumnHeader.Rows.Get(1).Height = 16F;
            this.spdData_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdData_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Locked = true;
            this.spdData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Width = 26F;
            this.spdData_Sheet1.Columns.Get(1).Label = "Factory";
            this.spdData_Sheet1.Columns.Get(1).Locked = true;
            this.spdData_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Width = 0F;
            this.spdData_Sheet1.Columns.Get(2).Label = "Resource";
            this.spdData_Sheet1.Columns.Get(2).Locked = true;
            this.spdData_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(2).Width = 0F;
            this.spdData_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(3).Label = "Hist Seq";
            this.spdData_Sheet1.Columns.Get(3).Locked = true;
            this.spdData_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(3).Width = 0F;
            this.spdData_Sheet1.Columns.Get(4).Label = "Event ID";
            this.spdData_Sheet1.Columns.Get(4).Locked = true;
            this.spdData_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(4).Width = 0F;
            this.spdData_Sheet1.Columns.Get(5).Label = "Collection Set ID";
            this.spdData_Sheet1.Columns.Get(5).Locked = true;
            this.spdData_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(5).Width = 0F;
            this.spdData_Sheet1.Columns.Get(6).Locked = true;
            this.spdData_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(6).Width = 0F;
            this.spdData_Sheet1.Columns.Get(7).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(7).Locked = true;
            this.spdData_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(7).Width = 36F;
            this.spdData_Sheet1.Columns.Get(8).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(8).Locked = true;
            this.spdData_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(8).Width = 100F;
            this.spdData_Sheet1.Columns.Get(9).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(9).Locked = true;
            this.spdData_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(9).Width = 120F;
            this.spdData_Sheet1.Columns.Get(10).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(10).Label = "Spec";
            this.spdData_Sheet1.Columns.Get(10).Locked = true;
            this.spdData_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(10).Width = 100F;
            this.spdData_Sheet1.Columns.Get(11).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(11).Locked = true;
            this.spdData_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(11).Width = 30F;
            textCellType1.MaxLength = 50;
            this.spdData_Sheet1.Columns.Get(12).CellType = textCellType1;
            this.spdData_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(12).Width = 100F;
            this.spdData_Sheet1.Columns.Get(13).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(13).Locked = true;
            this.spdData_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(13).Width = 40F;
            this.spdData_Sheet1.Columns.Get(14).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(14).Locked = true;
            this.spdData_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(14).Width = 40F;
            this.spdData_Sheet1.Columns.Get(15).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(15).Locked = true;
            this.spdData_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(15).Width = 40F;
            textCellType2.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(16).CellType = textCellType2;
            this.spdData_Sheet1.Columns.Get(16).Label = "1";
            this.spdData_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType3.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(17).CellType = textCellType3;
            this.spdData_Sheet1.Columns.Get(17).Label = "2";
            this.spdData_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType4.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(18).CellType = textCellType4;
            this.spdData_Sheet1.Columns.Get(18).Label = "3";
            this.spdData_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType5.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(19).CellType = textCellType5;
            this.spdData_Sheet1.Columns.Get(19).Label = "4";
            this.spdData_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType6.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(20).CellType = textCellType6;
            this.spdData_Sheet1.Columns.Get(20).Label = "5";
            this.spdData_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType7.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(21).CellType = textCellType7;
            this.spdData_Sheet1.Columns.Get(21).Label = "6";
            this.spdData_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType8.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(22).CellType = textCellType8;
            this.spdData_Sheet1.Columns.Get(22).Label = "7";
            this.spdData_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType9.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(23).CellType = textCellType9;
            this.spdData_Sheet1.Columns.Get(23).Label = "8";
            this.spdData_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType10.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(24).CellType = textCellType10;
            this.spdData_Sheet1.Columns.Get(24).Label = "9";
            this.spdData_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType11.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(25).CellType = textCellType11;
            this.spdData_Sheet1.Columns.Get(25).Label = "10";
            this.spdData_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType12.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(26).CellType = textCellType12;
            this.spdData_Sheet1.Columns.Get(26).Label = "11";
            this.spdData_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType13.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(27).CellType = textCellType13;
            this.spdData_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(27).Label = "12";
            this.spdData_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType14.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(28).CellType = textCellType14;
            this.spdData_Sheet1.Columns.Get(28).Label = "13";
            this.spdData_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType15.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(29).CellType = textCellType15;
            this.spdData_Sheet1.Columns.Get(29).Label = "14";
            this.spdData_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType16.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(30).CellType = textCellType16;
            this.spdData_Sheet1.Columns.Get(30).Label = "15";
            this.spdData_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType17.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(31).CellType = textCellType17;
            this.spdData_Sheet1.Columns.Get(31).Label = "16";
            this.spdData_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType18.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(32).CellType = textCellType18;
            this.spdData_Sheet1.Columns.Get(32).Label = "17";
            this.spdData_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType19.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(33).CellType = textCellType19;
            this.spdData_Sheet1.Columns.Get(33).Label = "18";
            this.spdData_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType20.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(34).CellType = textCellType20;
            this.spdData_Sheet1.Columns.Get(34).Label = "19";
            this.spdData_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType21.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(35).CellType = textCellType21;
            this.spdData_Sheet1.Columns.Get(35).Label = "20";
            this.spdData_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType22.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(36).CellType = textCellType22;
            this.spdData_Sheet1.Columns.Get(36).Label = "21";
            this.spdData_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType23.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(37).CellType = textCellType23;
            this.spdData_Sheet1.Columns.Get(37).Label = "22";
            this.spdData_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType24.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(38).CellType = textCellType24;
            this.spdData_Sheet1.Columns.Get(38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(38).Label = "23";
            this.spdData_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType25.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(39).CellType = textCellType25;
            this.spdData_Sheet1.Columns.Get(39).Label = "24";
            this.spdData_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType26.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(40).CellType = textCellType26;
            this.spdData_Sheet1.Columns.Get(40).Label = "25";
            this.spdData_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(41).Locked = true;
            this.spdData_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(41).Width = 160F;
            this.spdData_Sheet1.Columns.Get(42).Locked = true;
            this.spdData_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(42).Width = 85F;
            this.spdData_Sheet1.Columns.Get(43).Locked = true;
            this.spdData_Sheet1.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(43).Width = 110F;
            this.spdData_Sheet1.Columns.Get(44).Locked = true;
            this.spdData_Sheet1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(44).Width = 0F;
            this.spdData_Sheet1.Columns.Get(45).Locked = true;
            this.spdData_Sheet1.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(45).Width = 0F;
            this.spdData_Sheet1.Columns.Get(46).Width = 0F;
            this.spdData_Sheet1.FrozenColumnCount = 9;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.Columns.Get(0).Width = 23F;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.Rows.Default.Height = 18F;
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 162);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(742, 4);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // spdHistory
            // 
            this.spdHistory.AccessibleDescription = "spdResHistory, Sheet1";
            this.spdHistory.BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.spdHistory.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdHistory.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.HorizontalScrollBar.Name = "";
            this.spdHistory.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdHistory.HorizontalScrollBar.TabIndex = 4;
            this.spdHistory.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdHistory.Location = new System.Drawing.Point(0, 2);
            this.spdHistory.Name = "spdHistory";
            this.spdHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdHistory_Sheet1});
            this.spdHistory.Size = new System.Drawing.Size(742, 160);
            this.spdHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdHistory.TabIndex = 0;
            this.spdHistory.TabStop = false;
            this.spdHistory.TextTipDelay = 200;
            this.spdHistory.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdHistory.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.VerticalScrollBar.Name = "";
            this.spdHistory.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdHistory.VerticalScrollBar.TabIndex = 5;
            this.spdHistory.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdHistory.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdHistory_SelectionChanged);
            this.spdHistory.SetViewportLeftColumn(0, 0, 3);
            this.spdHistory.SetActiveViewport(0, -1, -1);
            // 
            // spdHistory_Sheet1
            // 
            this.spdHistory_Sheet1.Reset();
            spdHistory_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdHistory_Sheet1.ColumnCount = 43;
            spdHistory_Sheet1.RowCount = 0;
            this.spdHistory_Sheet1.ActiveColumnIndex = -1;
            this.spdHistory_Sheet1.ActiveRowIndex = -1;
            this.spdHistory_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Numbers;
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Tran Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Event";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Up/Down";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Primary Status";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "New Status 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "New Status 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "New Status 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "New Status 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "New Status 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "New Status 6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "New Status 7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "New Status 8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "New Status 9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "New Status 10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Tran Cmf 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Tran Cmf 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Tran Cmf 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Tran Cmf 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Tran Cmf 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Tran Cmf 6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Tran Cmf 7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Tran Cmf 8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Tran Cmf 9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Tran Cmf 10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Tran Cmf 11";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Tran Cmf 12";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Tran Cmf 13";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Tran Cmf 14";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Tran Cmf 15";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Tran Cmf 16";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Tran Cmf 17";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Tran Cmf 18";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Tran Cmf 19";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Tran Cmf 20";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "Process Mode";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "Control Mode";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "User Name";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "Comment";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "Hist Delete Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Hist Delete Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Hist Delete User Name";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Hist Delete Comment";
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdHistory_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdHistory_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Width = 30F;
            this.spdHistory_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(1).Label = "Tran Time";
            this.spdHistory_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(1).Width = 140F;
            this.spdHistory_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(2).Label = "Event";
            this.spdHistory_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(2).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(4).Label = "Primary Status";
            this.spdHistory_Sheet1.Columns.Get(4).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(5).Label = "New Status 1";
            this.spdHistory_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(5).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(6).Label = "New Status 2";
            this.spdHistory_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(6).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(7).Label = "New Status 3";
            this.spdHistory_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(7).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(8).Label = "New Status 4";
            this.spdHistory_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(8).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(9).Label = "New Status 5";
            this.spdHistory_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(9).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(10).Label = "New Status 6";
            this.spdHistory_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(10).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(11).Label = "New Status 7";
            this.spdHistory_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(11).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(12).Label = "New Status 8";
            this.spdHistory_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(12).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(13).Label = "New Status 9";
            this.spdHistory_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(13).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(14).Label = "New Status 10";
            this.spdHistory_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(14).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(15).Label = "Tran Cmf 1";
            this.spdHistory_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(15).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(16).Label = "Tran Cmf 2";
            this.spdHistory_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(16).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(17).Label = "Tran Cmf 3";
            this.spdHistory_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(17).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(18).Label = "Tran Cmf 4";
            this.spdHistory_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(18).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(19).Label = "Tran Cmf 5";
            this.spdHistory_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(19).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(20).Label = "Tran Cmf 6";
            this.spdHistory_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(20).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(21).Label = "Tran Cmf 7";
            this.spdHistory_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(21).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(22).Label = "Tran Cmf 8";
            this.spdHistory_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(22).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(23).Label = "Tran Cmf 9";
            this.spdHistory_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(23).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(24).Label = "Tran Cmf 10";
            this.spdHistory_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(24).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(25).Label = "Tran Cmf 11";
            this.spdHistory_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(25).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(26).Label = "Tran Cmf 12";
            this.spdHistory_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(26).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(27).Label = "Tran Cmf 13";
            this.spdHistory_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(27).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(28).Label = "Tran Cmf 14";
            this.spdHistory_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(28).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(29).Label = "Tran Cmf 15";
            this.spdHistory_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(29).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(30).Label = "Tran Cmf 16";
            this.spdHistory_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(30).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(31).Label = "Tran Cmf 17";
            this.spdHistory_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(31).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(32).Label = "Tran Cmf 18";
            this.spdHistory_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(32).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(33).Label = "Tran Cmf 19";
            this.spdHistory_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(33).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(34).Label = "Tran Cmf 20";
            this.spdHistory_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(34).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(35).Label = "Process Mode";
            this.spdHistory_Sheet1.Columns.Get(35).Width = 103F;
            this.spdHistory_Sheet1.Columns.Get(36).Label = "Control Mode";
            this.spdHistory_Sheet1.Columns.Get(36).Width = 103F;
            this.spdHistory_Sheet1.Columns.Get(37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(37).Label = "User Name";
            this.spdHistory_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(37).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(38).Label = "Comment";
            this.spdHistory_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(38).Width = 150F;
            this.spdHistory_Sheet1.Columns.Get(39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(39).Label = "Hist Delete Flag";
            this.spdHistory_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(39).Width = 92F;
            this.spdHistory_Sheet1.Columns.Get(40).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(40).Label = "Hist Delete Time";
            this.spdHistory_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(40).Width = 95F;
            this.spdHistory_Sheet1.Columns.Get(41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(41).Label = "Hist Delete User Name";
            this.spdHistory_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(41).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(42).Label = "Hist Delete Comment";
            this.spdHistory_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(42).Width = 116F;
            this.spdHistory_Sheet1.DefaultStyle.Locked = false;
            this.spdHistory_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdHistory_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.FrozenColumnCount = 3;
            this.spdHistory_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.spdHistory_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdHistory_Sheet1.RowHeader.Visible = false;
            this.spdHistory_Sheet1.Rows.Default.Height = 18F;
            this.spdHistory_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdHistory_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdHistory_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(484, 16);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(241, 20);
            this.pnlPeriod.TabIndex = 6;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(56, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(85, 20);
            this.dtpFrom.TabIndex = 1;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.Location = new System.Drawing.Point(0, 3);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(43, 13);
            this.lblPeriod.TabIndex = 0;
            this.lblPeriod.Text = "Period";
            this.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTo
            // 
            this.dtpTo.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(156, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(85, 20);
            this.dtpTo.TabIndex = 3;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(144, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(14, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            // 
            // cdvSubResource
            // 
            this.cdvSubResource.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSubResource.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSubResource.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSubResource.BtnToolTipText = "";
            this.cdvSubResource.ButtonWidth = 20;
            this.cdvSubResource.DescText = "";
            this.cdvSubResource.DisplaySubItemIndex = -1;
            this.cdvSubResource.DisplayText = "";
            this.cdvSubResource.Focusing = null;
            this.cdvSubResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSubResource.Index = 0;
            this.cdvSubResource.IsViewBtnImage = false;
            this.cdvSubResource.Location = new System.Drawing.Point(120, 40);
            this.cdvSubResource.MaxLength = 20;
            this.cdvSubResource.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSubResource.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSubResource.MultiSelect = false;
            this.cdvSubResource.Name = "cdvSubResource";
            this.cdvSubResource.ReadOnly = false;
            this.cdvSubResource.SameWidthHeightOfButton = false;
            this.cdvSubResource.SearchSubItemIndex = 0;
            this.cdvSubResource.SelectedDescIndex = -1;
            this.cdvSubResource.SelectedDescToQueryText = "";
            this.cdvSubResource.SelectedSubItemIndex = -1;
            this.cdvSubResource.SelectedValueToQueryText = "";
            this.cdvSubResource.SelectionStart = 0;
            this.cdvSubResource.Size = new System.Drawing.Size(200, 20);
            this.cdvSubResource.SmallImageList = null;
            this.cdvSubResource.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSubResource.TabIndex = 3;
            this.cdvSubResource.TextBoxToolTipText = "";
            this.cdvSubResource.TextBoxWidth = 200;
            this.cdvSubResource.VisibleButton = true;
            this.cdvSubResource.VisibleColumnHeader = false;
            this.cdvSubResource.VisibleDescription = false;
            this.cdvSubResource.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvSubResource_SelectedItemChanged);
            this.cdvSubResource.ButtonPress += new System.EventHandler(this.cdvSubResource_ButtonPress);
            this.cdvSubResource.TextBoxTextChanged += new System.EventHandler(this.cdvSubResource_TextBoxTextChanged);
            // 
            // lblSubResID
            // 
            this.lblSubResID.AutoSize = true;
            this.lblSubResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubResID.Location = new System.Drawing.Point(15, 43);
            this.lblSubResID.Name = "lblSubResID";
            this.lblSubResID.Size = new System.Drawing.Size(89, 13);
            this.lblSubResID.TabIndex = 2;
            this.lblSubResID.Text = "Sub Resource ID";
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(466, 7);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // frmEDCChangeResData
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmEDCChangeResData";
            this.Text = "Change Resource Data";
            this.Activated += new System.EventHandler(this.frmEDCViewResourceData_Activated);
            this.Load += new System.EventHandler(this.frmEDCViewResourceData_Load);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvEventID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.pnlResourceData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).EndInit();
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubResource)).EndInit();
            this.ResumeLayout(false);

        }
        
#endregion
        
#region " Constant Definition "
        
        private const int MAX_DATA_COUNT = 1000;
        private const int VALUE_START_COL = 16;
        private const int CHAR_ID = 8;
        private const int UNIT_SEQ = 11;
        
        //private bool bEditFlag = false;
        private const int COL_CHAR_SEQ = 7;
        private const int COL_CHAR_ID = 8;
        private const int COL_UNIT_SEQ = 11;
        private const int COL_VALUE_SEQ = 13;
        private const int COL_VALUE_COUNT = 15;
        private const int COL_SPEC_OUT_MASK = 41;
        private const int COL_UPDATE_TIME = 43;


        private const int OUT_SEQ = 0;
        private const int OUT_CHAR = 1;
        private const int OUT_UNIT_ID = 2;
        private const int OUT_RULE_TYPE = 3;
        private const int OUT_RULE_DESC = 4;
#endregion
        
#region "Enum Definition"
        
        private enum HISTORY_COLUMN
        {
            HIST_SEQ = 0,
            TRAN_TIME = 1,
            EVENT_ID = 2
        }
        
        private enum DATA_COLUMN
        {
            CHECK_COL = 0,
            FACTORY = 1,
            RES_ID = 2,
            HIS_SEQ = 3,
            EVENT_id = 4,
            COL_SET_ID = 5,
            COL_SET_VERSION = 6,
            CHAR_SEQ_NUM = 7,
            CHAR_ID = 8,
            CHAR_DESC = 9,
            SPEC = 10,
            UNIT_SEQ_NUM = 11,
            UNIT_ID = 12,
            VALUE_SEQ_NUM = 13,
            VALUE_TYPE = 14,
            VALUE_COUNT = 15,
            VALUE_1 = 16,
            VALUE_2 = 17,
            VALUE_3 = 18,
            VALUE_4 = 19,
            VALUE_5 = 20,
            VALUE_6 = 21,
            VALUE_7 = 22,
            VALUE_8 = 23,
            VALUE_9 = 24,
            VALUE_10 = 25,
            VALUE_11 = 26,
            VALUE_12 = 27,
            VALUE_13 = 28,
            VALUE_14 = 29,
            VALUE_15 = 30,
            VALUE_16 = 31,
            VALUE_17 = 32,
            VALUE_18 = 33,
            VALUE_19 = 34,
            VALUE_20 = 35,
            VALUE_21 = 36,
            VALUE_22 = 37,
            VALUE_23 = 38,
            VALUE_24 = 39,
            VALUE_25 = 40,
            SPEC_OUT_MASK = 41,
            UPDATE_USER_ID = 42,
            UPDATE_TIME = 43,
            VALUE_TYPE_2 = 44,
            VALUE_COUNT_2 = 45,
        }
        
#endregion
        
#region " Variable Definition"
        
        //int iLastSeq = 3;
        bool LoadFlag;
        private string sColSet = "";
        private int iColVer = 0;
        private clsDerivedCharList cls_derived_char_list;

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
                switch ( MPCF.Trim(FuncName))
                {
                    
                case "View_Resouece_Data":


                    if (MPCF.CheckValue(cdvResID, 1) == false)
                    {
                        return false;
                    }
                    
                    if (spdHistory.Sheets[0].RowCount == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(107));
                        spdHistory.Select();
                        return false;
                    }
                    
                    if (spdHistory.Sheets[0].ActiveRowIndex < 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        spdHistory.Select();
                        return false;
                    }
                    break;
                case "Change_Res_Data":


                    if (MPCF.CheckValue(cdvResID, 1) == false)
                    {
                        return false;
                    }
                    
                    if (spdHistory.Sheets[0].RowCount == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(107));
                        spdHistory.Select();
                        return false;
                    }
                    
                    if (spdHistory.Sheets[0].ActiveRowIndex < 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        spdHistory.Select();
                        return false;
                    }
                    
                    if (spdHistory.Sheets[0].GetValue(spdHistory.Sheets[0].ActiveRowIndex, MPCF.ToInt(HISTORY_COLUMN.EVENT_ID)) == null)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(113));
                        spdHistory.Sheets[0].SetActiveCell(spdHistory.Sheets[0].ActiveRowIndex, MPCF.ToInt(HISTORY_COLUMN.EVENT_ID));
                        spdHistory.Select();
                    }
                    
                    if (spdHistory.Sheets[0].GetValue(spdHistory.Sheets[0].ActiveRowIndex, MPCF.ToInt(HISTORY_COLUMN.HIST_SEQ)) == null)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(113));
                        spdHistory.Sheets[0].SetActiveCell(spdHistory.Sheets[0].ActiveRowIndex, MPCF.ToInt(HISTORY_COLUMN.HIST_SEQ));
                        spdHistory.Select();
                    }
                    
                    for (i = 0; i <= spdData.Sheets[0].RowCount - 1; i++)
                    {
                        if (System.Convert.ToBoolean(spdData.Sheets[0].GetValue(i, (int)DATA_COLUMN.CHECK_COL)) == true)
                        {
                            if (MPCF.Trim(spdData.Sheets[0].GetValue(i, (int)DATA_COLUMN.COL_SET_ID)) == null)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(157));
                                spdData.Sheets[0].SetActiveCell(i, (int)DATA_COLUMN.COL_SET_ID);
                                spdData.Select();
                            }
                            
                            if (MPCF.Trim(spdData.Sheets[0].GetValue(i, (int)DATA_COLUMN.COL_SET_VERSION)) == null)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(158));
                                spdData.Sheets[0].SetActiveCell(i, (int)DATA_COLUMN.COL_SET_VERSION);
                                spdData.Select();
                            }
                            
                            if (MPCF.Trim(spdData.Sheets[0].GetValue(i, (int)DATA_COLUMN.CHAR_ID)) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                spdData.Sheets[0].SetActiveCell(i, (int)DATA_COLUMN.CHAR_ID);
                                spdData.Select();
                                return false;
                            }
                            if (MPCF.Trim(spdData.Sheets[0].GetValue(i, (int)DATA_COLUMN.CHAR_SEQ_NUM)) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                spdData.Sheets[0].SetActiveCell(i, (int)DATA_COLUMN.CHAR_SEQ_NUM);
                                spdData.Select();
                                return false;
                            }
                            if (MPCF.Trim(spdData.Sheets[0].GetValue(i, (int)DATA_COLUMN.UNIT_SEQ_NUM)) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                spdData.Sheets[0].SetActiveCell(i, (int)DATA_COLUMN.UNIT_SEQ_NUM);
                                spdData.Select();
                                return false;
                            }
                            if (MPCF.Trim(spdData.Sheets[0].GetValue(i, (int)DATA_COLUMN.VALUE_SEQ_NUM)) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                spdData.Sheets[0].SetActiveCell(i, (int)DATA_COLUMN.VALUE_SEQ_NUM);
                                spdData.Select();
                                return false;
                            }
                            if (MPCF.Trim(spdData.Sheets[0].GetValue(i, (int)DATA_COLUMN.VALUE_TYPE_2)) == "N")
                            {
                                for (j = VALUE_START_COL; j <= VALUE_START_COL + 24; j++)
                                {
                                    if (MPCF.Trim(spdData.Sheets[0].GetValue(i, j)) != "")
                                    {
                                        if (MPCF.CheckNumeric(spdData.Sheets[0].GetValue(i, j)) == false)
                                        {
                                            MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                            spdData.Sheets[0].SetActiveCell(i, j);
                                            spdData.Select();
                                            return false;
                                        }
                                    }
                                }
                            }
                            if (MPCF.Trim(spdData.Sheets[0].GetValue(i, (int)DATA_COLUMN.UNIT_ID)) == "" && 
                                MPCF.Trim(spdData.Sheets[0].Cells[i, (int)DATA_COLUMN.UNIT_ID].Tag) != "NULL")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                spdData.Sheets[0].SetActiveCell(i, (int)DATA_COLUMN.UNIT_ID);
                                spdData.Select();
                                return false;
                            }
                            iChkCnt++;
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

        private bool View_SubResource_History()
        {
            FarPoint.Win.Spread.SheetView sheetX;
            int i;
            int iRow;

            TRSNode in_node = new TRSNode("VIEW_SUB_RESOURCE_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_SUB_RESOURCE_HISTORY_OUT");

            try
            {
                MPCF.ClearList(spdHistory, true);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("RES_ID", cdvResID.Text);
                in_node.AddString("SUBRES_ID", cdvSubResource.Text);
                in_node.AddInt("NEXT_HIST_SEQ", int.MaxValue);
                in_node.AddString("FROM_TIME", MPCF.FromDate(dtpFrom));
                in_node.AddString("TO_TIME", MPCF.ToDate(dtpTo));
                in_node.AddString("EVENT_ID", cdvEventID.Text);
                in_node.AddChar("INCLUDE_DEL_HIST", 'Y');

                do
                {
                    if (MPCR.CallService("RAS", "RAS_View_Sub_Resource_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        sheetX = spdHistory.ActiveSheet;
                        iRow = sheetX.RowCount;
                        sheetX.RowCount++;

                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG")) == "Y")
                        {
                            sheetX.Cells[iRow, 0, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Magenta;
                        }
                        else
                        {
                            sheetX.Cells[iRow, 0, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Black;
                        }

                        sheetX.Cells[iRow, 0].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("HIST_SEQ"));
                        sheetX.Cells[iRow, 1].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_TIME")));
                        sheetX.Cells[iRow, 2].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID"));
                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("NEW_UP_DOWN_FLAG")) == "D")
                        {
                            sheetX.Cells[iRow, 3].Value = "DOWN";
                        }
                        else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("NEW_UP_DOWN_FLAG")) == "U")
                        {
                            sheetX.Cells[iRow, 3].Value = "UP";
                        }
                        sheetX.Cells[iRow, 4].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_PRI_STS"));
                        sheetX.Cells[iRow, 5].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_1"));
                        sheetX.Cells[iRow, 6].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_2"));
                        sheetX.Cells[iRow, 7].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_3"));
                        sheetX.Cells[iRow, 8].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_4"));
                        sheetX.Cells[iRow, 9].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_5"));
                        sheetX.Cells[iRow, 10].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_6"));
                        sheetX.Cells[iRow, 11].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_7"));
                        sheetX.Cells[iRow, 12].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_8"));
                        sheetX.Cells[iRow, 13].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_9"));
                        sheetX.Cells[iRow, 14].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_10"));
                        sheetX.Cells[iRow, 15].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_1"));
                        sheetX.Cells[iRow, 16].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_2"));
                        sheetX.Cells[iRow, 17].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_3"));
                        sheetX.Cells[iRow, 18].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_4"));
                        sheetX.Cells[iRow, 19].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_5"));
                        sheetX.Cells[iRow, 20].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_6"));
                        sheetX.Cells[iRow, 21].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_7"));
                        sheetX.Cells[iRow, 22].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_8"));
                        sheetX.Cells[iRow, 23].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_9"));
                        sheetX.Cells[iRow, 24].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_10"));
                        sheetX.Cells[iRow, 25].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_11"));
                        sheetX.Cells[iRow, 26].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_12"));
                        sheetX.Cells[iRow, 27].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_13"));
                        sheetX.Cells[iRow, 28].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_14"));
                        sheetX.Cells[iRow, 29].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_15"));
                        sheetX.Cells[iRow, 30].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_16"));
                        sheetX.Cells[iRow, 31].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_17"));
                        sheetX.Cells[iRow, 32].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_18"));
                        sheetX.Cells[iRow, 33].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_19"));
                        sheetX.Cells[iRow, 34].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_20"));
                        sheetX.Cells[iRow, 35].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_USER_ID"));
                        sheetX.Cells[iRow, 36].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_COMMENT"));
                        sheetX.Cells[iRow, 37].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG"));
                        sheetX.Cells[iRow, 38].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("HIST_DEL_TIME")));
                        sheetX.Cells[iRow, 39].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("HIST_DEL_USER_ID"));
                        sheetX.Cells[iRow, 40].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("HIST_DEL_COMMENT"));                                  
                    }

                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                } while (in_node.GetInt("NEXT_HIST_SEQ") > 0);

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }
    
    // View_Resource_Data()
    //       - View res Data by res
    // Return Value
    //       - boolean : True / False
    // Arguments
    //        - ByVal c_step As String                        : ?ïÏû• Process Step
    //        - ByVal sresID As String                    : res id
    //       - ByVal iHistSeq As Integer                 : History Sequence
    //        - Optional ByVal sIncludeDelHistory As String = ""  : Delete HistoryÍπåÏ? ?¨Ìï®??Í≤ÉÏù∏ÏßÄ?
    //
    private bool View_Resource_Data(char c_step, string sResID, int iHistSeq, string sEventID)
    {

        int i;
        int j;
        int k;
        int iRow;
        int iUnitCnt = 0;
        int iValueCnt = 0;

        string sDefaultValue;
        string sUnitTbl;
        string sValueTbl;
        string sDefUnitFlag;
        string sDefUnitOvrFlag;
        string sDefUnitID;
        string sUnitID;

        string s_value_name;
        
        TRSNode in_node = new TRSNode("VIEW_RESOURCE_DATA_IN");
        TRSNode out_node = new TRSNode("VIEW_RESOURCE_DATA_OUT");

        System.Collections.ArrayList a_values = new System.Collections.ArrayList();

        int iMaxValueCount = 0;

        try
        {
            
            MPCF.ClearList(spdData, true);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddString("RES_ID", sResID);
            in_node.AddString("SUBRES_ID", cdvSubResource.Text);
            in_node.AddInt("HIST_SEQ", iHistSeq);
            in_node.AddString("EVENT_ID", sEventID);
            in_node.AddChar("INCLUDE_DEL_HIST", ' ');
            in_node.AddString("COL_SET_ID", "");
            in_node.AddString("CHAR_ID", "");
            in_node.AddString("START_TRAN_TIME", "");
            in_node.AddString("END_TRAN_TIME", "");
            in_node.AddInt("NEXT_COL_SEQ", 0);
            in_node.AddInt("NEXT_CHAR_SEQ_NUM", 0);
            in_node.AddInt("NEXT_UNIT_SEQ_NUM", 0);
            in_node.AddInt("NEXT_VALUE_SEQ_NUM", 0);
            
            do
            {
                if (MPCR.CallService("EDC", "EDC_View_Resource_Data", in_node, ref out_node) == false)
                {
                    return false;
                }

                FarPoint.Win.Spread.SheetView with_1 = spdData.Sheets[0];
                
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    iRow = with_1.RowCount;
                    spdData.ActiveSheet.RowCount++;

                    if (iRow == 0)
                    {
                        cls_derived_char_list.GetDerivedInfo(MPCF.Trim(out_node.GetList(0)[i].GetString("COL_SET_ID")), out_node.GetList(0)[i].GetInt("COL_SET_VERSION"), "", MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID")), "", "");
                    }

                    with_1.Cells[iRow, (int)DATA_COLUMN.RES_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID"));
                    with_1.Cells[iRow, (int)DATA_COLUMN.HIS_SEQ].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("HIST_SEQ"));
                    with_1.Cells[iRow, (int)DATA_COLUMN.FACTORY].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("FACTORY"));
                    with_1.Cells[iRow, (int)DATA_COLUMN.EVENT_id].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID"));
                    with_1.Cells[iRow, (int)DATA_COLUMN.COL_SET_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("COL_SET_ID"));
                    with_1.Cells[iRow, (int)DATA_COLUMN.COL_SET_VERSION].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("COL_SET_VERSION"));
                    with_1.Cells[iRow, (int)DATA_COLUMN.CHAR_SEQ_NUM].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("CHAR_SEQ_NUM"));
                    with_1.Cells[iRow, (int)DATA_COLUMN.CHAR_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_ID"));
                    with_1.Cells[iRow, (int)DATA_COLUMN.CHAR_DESC].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_DESC"));
                    with_1.Cells[iRow, (int)DATA_COLUMN.SPEC].Value = MPCF.GetSpecInfo(out_node.GetList(0)[i].GetString("UPPER_SPEC_LIMIT"), out_node.GetList(0)[i].GetString("LOWER_SPEC_LIMIT"), out_node.GetList(0)[i].GetString("TARGET_VALUE"));
                    with_1.Cells[iRow, (int)DATA_COLUMN.UNIT_SEQ_NUM].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("UNIT_SEQ_NUM"));
                    with_1.Cells[iRow, (int)DATA_COLUMN.UNIT_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UNIT_ID"));
                    with_1.Cells[iRow, (int)DATA_COLUMN.VALUE_SEQ_NUM].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("VALUE_SEQ_NUM"));
                    with_1.Cells[iRow, (int)DATA_COLUMN.VALUE_TYPE].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("VALUE_TYPE"));
                    with_1.Cells[iRow, (int)DATA_COLUMN.VALUE_COUNT].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("VALUE_COUNT"));                                       
                    
                    with_1.Cells[iRow, (int)DATA_COLUMN.SPEC_OUT_MASK].Value = out_node.GetList(0)[i].GetString("SPEC_OUT_MASK");
                    with_1.Cells[iRow, (int)DATA_COLUMN.UPDATE_USER_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_USER_ID"));
                    with_1.Cells[iRow, (int)DATA_COLUMN.UPDATE_TIME].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_TIME")));
                    with_1.Cells[iRow, (int)DATA_COLUMN.VALUE_TYPE_2].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("VALUE_TYPE_2"));
                    with_1.Cells[iRow, (int)DATA_COLUMN.VALUE_COUNT_2].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("VALUE_COUNT_2"));

                    sColSet = MPCF.Trim(out_node.GetList(0)[i].GetString("COL_SET_ID"));
                    iColVer = out_node.GetList(0)[i].GetInt("COL_SET_VERSION");

                    iUnitCnt = out_node.GetList(0)[i].GetInt("UNIT_COUNT");
                    iValueCnt = out_node.GetList(0)[i].GetInt("VALUE_COUNT");
                    
                    if (iValueCnt > 25)
                    {
                        iValueCnt = 25;
                    }

                    for (k = 1; k <= iValueCnt; k++)
                    {
                        s_value_name = "VALUE_" + k.ToString();

                        if (out_node.GetList(0)[i].GetChar("VALUE_TYPE") == 'N')
                        {
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString(s_value_name)) != "")
                            {
                                spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.VALUE_1 + (k - 1)].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString(s_value_name));
                            }
                        }
                        else
                        {
                            spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.VALUE_1 + (k - 1)].Value = MPCF.Trim(out_node.GetList(0)[i].GetString(s_value_name));
                        }

                        if (out_node.GetList(0)[i].GetChar("DERIVED_PARAM_FLAG") == 'Y')
                        {
                            spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.VALUE_1 + (k - 1)].Locked = true;
                            spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.VALUE_1 + (k - 1)].BackColor = System.Drawing.Color.Cyan;
                            spdData.ActiveSheet.Rows[iRow].Tag = "AUTO";

                            cls_derived_char_list.SetCharLocation(out_node.GetList(0)[i].GetString("CHAR_ID"), spdData.ActiveSheet, k - 1, iRow, (int)DATA_COLUMN.VALUE_1 + (k - 1));
                        }
                    }

                    // Max Value Count ∞ËªÍ
                    if (iMaxValueCount < iValueCnt)
                    {
                        iMaxValueCount = iValueCnt;
                    }
                    sDefaultValue = MPCF.Trim(out_node.GetList(0)[i].GetString("DEF_VALUE"));
                    sUnitTbl = MPCF.Trim(out_node.GetList(0)[i].GetString("UNIT_TBL"));
                    sValueTbl = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_TBL"));
                    sDefUnitFlag = MPCF.Trim(out_node.GetList(0)[i].GetChar("DEF_UNIT_FLAG"));
                    sDefUnitOvrFlag = MPCF.Trim(out_node.GetList(0)[i].GetChar("DEF_UNIT_OVR_FLAG"));
                    sUnitID = MPCF.Trim(out_node.GetList(0)[i].GetString("UNIT_ID"));
                    sDefUnitID = MPCF.Trim(out_node.GetList(0)[i].GetString("DEF_UNIT_ID"));

                    if (sDefUnitID == "")
                    {
                        with_1.Cells[iRow, (int)DATA_COLUMN.UNIT_ID].Tag = "NULL";
                    }

                    //Unit Count Check
                    if (iUnitCnt == 0)
                    {
                        with_1.Cells[iRow, (int)DATA_COLUMN.UNIT_ID].Locked = true;
                        with_1.Cells[iRow, (int)DATA_COLUMN.UNIT_ID].BackColor = System.Drawing.Color.WhiteSmoke;
                    }
                    else
                    {
                        if (sDefUnitFlag == "Y" && sDefUnitID != "" && sUnitID == "")
                        {
                            //DEFAULT UNIT
                            with_1.Cells[iRow, (int)DATA_COLUMN.UNIT_ID].Value = sDefUnitID;
                            sUnitID = sDefUnitID;
                        }

                        if ((sDefUnitFlag == "Y" && sDefUnitOvrFlag == "Y" && sUnitTbl != "") || (sDefUnitFlag == "" && sUnitTbl != ""))
                        {
                            with_1.SetValue(iRow, (int)DATA_COLUMN.UNIT_ID, sUnitID);                            
                        }
                    }

                    //Value Cell Lock
                    for (j = VALUE_START_COL + iValueCnt; j <= with_1.ColumnCount - 1; j++)
                    {
                        with_1.Cells[iRow, j].Locked = true;
                        with_1.Cells[iRow, j].BackColor = System.Drawing.Color.WhiteSmoke;
                    }

                    //Value Tbl Check
                    for (j = VALUE_START_COL; j <= iValueCnt + VALUE_START_COL - 1; j++)
                    {
                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("VALUE_TYPE")) == "N")
                        {
                            MPCR.SetNumberCell(with_1.Cells[iRow, j]);
                        }
                        else
                        {
                            MPCR.SetAsciiCell(with_1.Cells[iRow, j]);
                        }
                    }

                    iRow++;
                }

                in_node.SetInt("NEXT_COL_SEQ", out_node.GetInt("NEXT_COL_SEQ"));
                in_node.SetInt("NEXT_CHAR_SEQ_NUM", out_node.GetInt("NEXT_CHAR_SEQ_NUM"));
                in_node.SetInt("NEXT_UNIT_SEQ_NUM", out_node.GetInt("NEXT_UNIT_SEQ_NUM"));
                in_node.SetInt("NEXT_VALUE_SEQ_NUM", out_node.GetInt("NEXT_VALUE_SEQ_NUM"));

            } while (in_node.GetInt("NEXT_CHAR_SEQ_NUM") > 0 || 
                     in_node.GetInt("NEXT_UNIT_SEQ_NUM") > 0 ||
                     in_node.GetInt("NEXT_VALUE_SEQ_NUM") > 0 ||
                     in_node.GetInt("NEXT_COL_SEQ") > 0);

            // Derived Parameter Setting
            {
                string s_char_id;
                int i_unit_seq;
                string s_next_char_id = "";
                int i_next_unit_seq = 0;
                int i_value_count;

                a_values.Clear();

                for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                {
                    if (MPCF.Trim(spdData.ActiveSheet.Cells[i, (int)DATA_COLUMN.VALUE_TYPE].Value) != "N")
                    {
                        continue;
                    }

                    s_char_id = MPCF.Trim(spdData.ActiveSheet.Cells[i, (int)DATA_COLUMN.CHAR_ID].Value);
                    i_unit_seq = MPCF.ToInt(spdData.ActiveSheet.Cells[i, (int)DATA_COLUMN.UNIT_SEQ_NUM].Value);

                    if (i < spdData.ActiveSheet.RowCount - 1)
                    {
                        s_next_char_id = MPCF.Trim(spdData.ActiveSheet.Cells[i + 1, (int)DATA_COLUMN.CHAR_ID].Value);
                        i_next_unit_seq = MPCF.ToInt(spdData.ActiveSheet.Cells[i + 1, (int)DATA_COLUMN.UNIT_SEQ_NUM].Value);
                    }
                    else
                    {
                        s_next_char_id = "";
                        i_next_unit_seq = 0;
                    }

                    i_value_count = MPCF.ToInt(spdData.ActiveSheet.Cells[i, (int)DATA_COLUMN.VALUE_COUNT].Value);

                    for (j = 0; j < i_value_count; j++)
                    {
                        a_values.Add(spdData.ActiveSheet.Cells[i, (int)DATA_COLUMN.VALUE_1 + j].Value);
                    }


                    if (s_next_char_id != s_char_id || i_next_unit_seq != i_unit_seq)
                    {
                        cls_derived_char_list.SetValue(MPCF.Trim(spdData.ActiveSheet.Cells[i, (int)DATA_COLUMN.CHAR_ID].Value), i_unit_seq, a_values, false);
                        a_values.Clear();
                    }
                }
            }

            FarPoint.Win.Spread.SheetView with_2 = spdData.Sheets[0];

            if (with_2.RowCount > 0)
            {
                if (iMaxValueCount == 0)
                {
                    iMaxValueCount = 1;
                }
                else if (iMaxValueCount > 25)
                {
                    iMaxValueCount = 25;
                }
                with_2.Columns.Get(VALUE_START_COL, VALUE_START_COL + iMaxValueCount - 1).Visible = true;
                if (iMaxValueCount < 25)
                {
                    with_2.Columns.Get(VALUE_START_COL + iMaxValueCount, VALUE_START_COL + 24).Visible = false;
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
    
    private bool View_Resource_History()
    {
        string sFromTime;
        string sToTime;
        
        if (MPCF.CheckValue(cdvResID, 1) == false)
        {
            return false;
        }
        
        sFromTime = MPCF.FromDate(dtpFrom);
        sToTime = MPCF.ToDate(dtpTo);

        if (MPCF.Trim(cdvSubResource.Text) == "")
        {
            if (RASLIST.ViewResourceHistory(spdHistory, '2', cdvResID.Text, 'Y', cdvEventID.Text, sFromTime, sToTime, null, false) == false)
            {
                return false;
            }
        }
        else
        {
            View_SubResource_History();
        }
        
        return true;
        
    }
    
    //
    // Change_Res_Data()
    //       - Change Resource Data
    // Return Value
    //       - Boolean : True or False
    // Arguments
    //       - ByVal ProcStep As String : Process Step
    //
    private bool Change_Res_Data(char ProcStep)
    {
        int i = 0;
        int j = 0;
        int k = 0;
        int m = 0;
        int n = 0;
        int iValueCnt = 0;
        int i_count = 0;
        int i_unit_count = 0;

        string s_char_id = "";
        string s_unit_seq = "";
        TRSNode in_node = new TRSNode("CHANGE_RES_DATA_IN");
        TRSNode out_node = new TRSNode("CHANGE_RES_DATA_OUT");
        TRSNode char_item, value_item, unit_item, value_seq_item;

        CultureInfo ci_inter = new CultureInfo("en-US");

        try
        {
            FarPoint.Win.Spread.SheetView with_1 = spdHistory.Sheets[0];
            FarPoint.Win.Spread.SheetView with_2 = spdData.Sheets[0];

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = ProcStep;
            in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
            if (MPCF.Trim(cdvSubResource.Text) != "")
            {
                in_node.AddString("SUBRES_ID", MPCF.Trim(cdvSubResource.Text));
                in_node.AddChar("SUBRES_FLAG", 'Y');
            }
            in_node.AddInt("HIST_SEQ", MPCF.ToInt(with_1.GetValue(with_1.ActiveRowIndex, MPCF.ToInt(HISTORY_COLUMN.HIST_SEQ))));
            in_node.AddString("EVENT_ID", MPCF.Trim(with_1.GetValue(with_1.ActiveRowIndex, MPCF.ToInt(HISTORY_COLUMN.EVENT_ID))));
            in_node.AddString("TRAN_TIME", MPCF.DestroyDateFormat(MPCF.Trim(with_1.GetValue(with_1.ActiveRowIndex, MPCF.ToInt(HISTORY_COLUMN.TRAN_TIME)))));

            char_item = in_node.AddNode("CHAR_LIST");
            unit_item = char_item.AddNode("UNIT_LIST");
            for (i = 0; i <= with_2.RowCount - 1; i++)
            {
                if (System.Convert.ToBoolean(with_2.GetValue(i, (int)DATA_COLUMN.CHECK_COL)) == true)
                {
                    iValueCnt = MPCF.ToInt(spdData.ActiveSheet.GetValue(i, (int)DATA_COLUMN.VALUE_COUNT_2));
                    if (iValueCnt > 25)
                    {
                        if (iValueCnt / 25 >= MPCF.ToInt(spdData.ActiveSheet.GetValue(i, (int)DATA_COLUMN.VALUE_SEQ_NUM)))
                        {
                            iValueCnt = 25;
                        }
                        else
                        {
                            iValueCnt = iValueCnt % 25;
                        }
                    }
                    in_node.SetString("COL_SET_ID", MPCF.Trim(with_2.GetValue(i, (int)DATA_COLUMN.COL_SET_ID)));
                    if (MPCF.CheckNumeric(with_2.GetValue(i, (int)DATA_COLUMN.COL_SET_VERSION)) == true)
                    {
                        in_node.SetInt("COL_SET_VERSION", MPCF.ToInt(with_2.GetValue(i, (int)DATA_COLUMN.COL_SET_VERSION)));
                    }
                    else
                    {
                        in_node.SetInt("COL_SET_VERSION", 0);
                    }

                    if (MPCF.Trim(s_char_id) != MPCF.Trim(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(DATA_COLUMN.CHAR_ID))))
                    {
                        if (i_count != 0)
                        {
                            char_item = in_node.AddNode("CHAR_LIST");
                        }
                        s_char_id = MPCF.Trim(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(DATA_COLUMN.CHAR_ID)));

                        char_item.AddInt("CHAR_SEQ_NUM", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, (int)DATA_COLUMN.CHAR_SEQ_NUM)));
                        char_item.AddString("CHAR_ID", MPCF.Trim(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(DATA_COLUMN.CHAR_ID))));

                        s_unit_seq = "";
                        i_count++;
                    }

                    //2008.02.19 √ﬂ∞° - LAVERWON
                    if (MPCF.Trim(s_unit_seq) != MPCF.Trim(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(DATA_COLUMN.UNIT_SEQ_NUM))))
                    {
                        if (i_unit_count != 0)
                        {
                            unit_item = char_item.AddNode("UNIT_LIST");
                        }
                        unit_item.AddInt("UNIT_SEQ_NUM", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, (int)DATA_COLUMN.UNIT_SEQ_NUM)));
                        unit_item.AddString("UNIT_ID", MPCF.Trim(spdData.ActiveSheet.GetValue(i, (int)DATA_COLUMN.UNIT_ID)));

                        s_unit_seq = MPCF.Trim(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(DATA_COLUMN.UNIT_SEQ_NUM)));

                        i_unit_count++;
                    }
                    value_seq_item = unit_item.AddNode("VALUE_SEQ_LIST");
                    value_seq_item.AddInt("VALUE_SEQ_NUM", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, (int)DATA_COLUMN.VALUE_SEQ_NUM)));

                    for (k = 0; k < iValueCnt; k++)
                    {
                        value_item = value_seq_item.AddNode("VALUE_LIST");

                        if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, (int)DATA_COLUMN.VALUE_TYPE_2)) == "N" && MPCF.CheckNumeric(spdData.ActiveSheet.GetValue(i, k + VALUE_START_COL)) == true)
                        {
                            value_item.AddString("VALUE", MPCF.ToDbl(spdData.ActiveSheet.GetValue(i, k + VALUE_START_COL)).ToString(ci_inter.NumberFormat));
                        }
                        else
                        {
                            value_item.AddString("VALUE", MPCF.Trim(spdData.ActiveSheet.GetValue(i, k + VALUE_START_COL)));
                        }
                    }       
                    
                }
            }

            if (MessageCaster.CallService("EDC", "EDC_Change_Res_Data", in_node, ref out_node) == false)
            {
                MPCF.ShowMsgBox(MPMH.StatusMessage);
                return false;
            }
            if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
            {
                MPCR.CheckContinueProc(out_node);
                return false;
            }

            if (ProcStep == '1')
            {
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    char_item = out_node.GetList("CHAR_LIST")[i];
                    for (m = 0; m < char_item.GetList(0).Count; m++)
                    {
                        unit_item = char_item.GetList("UNIT_LIST")[m];
                        for (n = 0; n < unit_item.GetList(0).Count; n++)
                        {
                            value_seq_item = unit_item.GetList("VALUE_SEQ_LIST")[n];
                            for (k = 0; k < spdData.ActiveSheet.RowCount; k++)
                            {
                                if (char_item.GetString("CHAR_ID") == MPCF.Trim(spdData.ActiveSheet.Cells[k, COL_CHAR_ID].Value) &&
                                    MPCF.ToInt(unit_item.GetInt("UNIT_SEQ_NUM")) == MPCF.ToInt(spdData.ActiveSheet.Cells[k, COL_UNIT_SEQ].Value) &&
                                    MPCF.ToInt(value_seq_item.GetInt("VALUE_SEQ_NUM")) == MPCF.ToInt(spdData.ActiveSheet.Cells[k, COL_VALUE_SEQ].Value))
                                {
                                    iValueCnt = MPCF.ToInt(spdData.ActiveSheet.GetValue(k, (int)DATA_COLUMN.VALUE_COUNT));

                                    for (j = VALUE_START_COL; j < VALUE_START_COL + iValueCnt; j++)
                                    {
                                        if (MPCF.Mid(value_seq_item.GetString("SPEC_OUT_MASK"), j - VALUE_START_COL, 1) == "1" ||
                                             MPCF.Mid(value_seq_item.GetString("SPEC_OUT_MASK"), j - VALUE_START_COL, 1) == "4" ||
                                             MPCF.Mid(value_seq_item.GetString("SPEC_OUT_MASK"), j - VALUE_START_COL, 1) == "5")
                                        {
                                            spdData.ActiveSheet.Cells[k, j].BackColor = Color.Red;
                                        }
                                        else if (MPCF.Mid(value_seq_item.GetString("SPEC_OUT_MASK"), j - VALUE_START_COL, 1) == "2" ||
                                                  MPCF.Mid(value_seq_item.GetString("SPEC_OUT_MASK"), j - VALUE_START_COL, 1) == "3")
                                        {
                                            spdData.ActiveSheet.Cells[k, j].BackColor = Color.Yellow;
                                        }
                                        else
                                        {
                                            spdData.ActiveSheet.Cells[k, j].BackColor = Color.White;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (out_node.StatusValue == MPGC.MP_TRBL_STATUS)
                {
                    if (Result_Management(out_node) == false)
                    {
                        return false;
                    }
                }
                else if (out_node.StatusValue == MPGC.MP_SUCCESS_STATUS)
                {
                    MPCR.ShowSuccessMsg(out_node);
                    spdHistory_SelectionChanged(spdHistory, null);
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
    
    // Result_Management()
    //       - Manage result of data collection
    // Return Value
    //       - Boolean : True or False
    // Arguments
    //       - ByVal Collect_EDC_Data_Out As SPC_Collect_EDC_Data_Out_Tag
    //
        private bool Result_Management(TRSNode out_node)
    {
        try
        {
            if (out_node.StatusValue == MPGC.MP_TRBL_STATUS)
            {
                frmConfirmCollectData f = new frmConfirmCollectData();
                object temp_object = f.spdResult;
                View_Result(f.spdResult, out_node);
                f.ShowDialog(this);
                
                //Pending
                if (f.DialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    //Data Commit
                    //OOC History Insert
                    if (Change_Res_Data('4') == false)
                    {
                        return false;
                    }
                    spdHistory_SelectionChanged(spdHistory, null);
                    //Data Change
                }
                else if (f.DialogResult == System.Windows.Forms.DialogResult.No)
                {
                    f.Dispose();
                    spdData.Select();
                    return false;
                }
                else if (f.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                {
                    f.Dispose();
                    spdData.Select();
                    return false;
                }
            }
            return true;
            
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox("frmEDCChangeResData.Result_Management()\n" + ex.Message);
            return false;
        }
        
    }
    
    // View_Result()
    //       - View Result of Data Collection
    // Return Value
    //       - Boolean : True or False
    // Arguments
    //       - ByRef spdResult As FpSpread - Í≤∞Í≥º ?úÏãú ?§ÌîÑ?àÎìú
    //       - ByVal Result_Out._C As SPC_Collect_EDC_Data_Out_Tag : Data Collection Out ?úÍ∑∏
    //       - ByVal c_step As String
    //
        public void View_Result(FpSpread spdResult, TRSNode out_node)
        {

            int i, m;
            TRSNode char_item, unit_item;
            try
            {
                MPCF.ClearList(spdResult, true);

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    char_item = out_node.GetList("CHAR_LIST")[i];
                    for (m = 0; m < char_item.GetList(0).Count; m++)
                    {
                        unit_item = char_item.GetList("UNIT_LIST")[m];
                        if (unit_item.GetChar("SPEC_OUT_TYPE") == ' ')
                        {

                        }
                        else
                        {
                            spdResult.Sheets[0].RowCount++;
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_SEQ].Value = i + 1;
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_CHAR].Value = char_item.GetString("CHAR_ID");
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_UNIT_ID].Value = unit_item.GetString("UNIT_ID");

                            if (unit_item.GetChar("SPEC_OUT_TYPE") == 'W')
                            {
                                spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_RULE_TYPE].Value = "OOW";
                                spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_RULE_DESC].Value = MPCF.SetRuleDescription('W', out_node);
                            }
                            else if (unit_item.GetChar("SPEC_OUT_TYPE") == 'S')
                            {
                                spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_RULE_TYPE].Value = "OOS";
                                spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_RULE_DESC].Value = MPCF.SetRuleDescription('S', out_node);
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
    
    public virtual Control GetFisrtFocusItem()
    {
        
        try
        {
            return this.cdvResID;
            
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
            return null;
        }
        
    }
    
#endregion
    
    private void frmEDCViewResourceData_Load(object sender, System.EventArgs e)
    {
        
        try
        {
            
            MPCF.FieldClear(this);
            
            dtpFrom.Value = DateTime.Now.AddMonths(- 1);
            dtpTo.Value = DateTime.Now;

            cls_derived_char_list = new clsDerivedCharList();
            
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
        }
        
    }
    
    private void frmEDCViewResourceData_Activated(object sender, System.EventArgs e)
    {
        
        if (LoadFlag == false)
        {
            
            MPCF.ClearList(spdHistory, true);
            MPCF.ClearList(spdData, true);
            
            if (MPCF.Trim(MPGV.gsCurrentRes_ID) != "")
            {
                cdvResID.Text = MPGV.gsCurrentRes_ID;
                View_Resource_History();
            }
            
            LoadFlag = true;
        }
        
    }
    
    private void cdvResID_ButtonPress(object sender, System.EventArgs e)
    {
        cdvResID.Init();
        MPCF.InitListView(cdvResID.GetListView);
        cdvResID.Columns.Add("Resource", 50, HorizontalAlignment.Left);
        cdvResID.Columns.Add("Description", 100, HorizontalAlignment.Left);
        cdvResID.SelectedSubItemIndex = 0;
        if (RASLIST.ViewResourceList(cdvResID.GetListView, false) == false)
        {
            return;
        }
        cdvResID.AddEmptyRow(1);
    }
    
    private void btnProcess_Click(System.Object sender, System.EventArgs e)
    {
        if (CheckCondition("Change_Res_Data", '1') == false)
        {
            return;
        }
        if (Change_Res_Data('1') == true)
        {
            //spdHistory_SelectionChanged(spdHistory, Nothing)
        }
        
    }
    
    private void cdvEventID_ButtonPress(object sender, System.EventArgs e)
    {
        cdvEventID.Init();
        MPCF.InitListView(cdvEventID.GetListView);
        cdvEventID.Columns.Add("Event ID", 50, HorizontalAlignment.Left);
        cdvEventID.Columns.Add("Description", 100, HorizontalAlignment.Left);
        cdvEventID.SelectedSubItemIndex = 0;
        if (cdvResID.Text != "")
        {
            if (MPCF.Trim(cdvSubResource.Text) == "")
            {
                if (RASLIST.ViewResEventList(cdvEventID.GetListView, '1', cdvResID.Text, null, "") == false)
                {
                    return;
                }
            }
            else
            {
                if (RASLIST.ViewSubResEventList(cdvEventID.GetListView, '1', cdvResID.Text,cdvSubResource.Text, null, "") == false)
                {
                    return;
                }
            }
            cdvEventID.AddEmptyRow(1);
        }
        else
        {
            cdvEventID.GetListView.Clear();
        }
        
    }
    
    private void spdHistory_SelectionChanged(System.Object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
    {
        
        try
        {
            int iRow = 0;
            
            if (cdvResID.Text == "")
            {
                return;
            }
            if (spdHistory.Sheets[0].ActiveRowIndex < 0)
            {
                return;
            }
            
            iRow = spdHistory.Sheets[0].ActiveRowIndex;
            
            View_Resource_Data('2', cdvResID.Text, MPCF.ToInt(spdHistory.Sheets[0].GetValue(iRow, MPCF.ToInt(HISTORY_COLUMN.HIST_SEQ))), MPCF.Trim(spdHistory.Sheets[0].GetValue(iRow, MPCF.ToInt(HISTORY_COLUMN.EVENT_ID))));
            
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
        }
        
    }
    
    private void cdvResID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
    {
        MPCF.ClearList(spdData, true);
        cdvSubResource.Text = "";
    }
    
    private void cdvEventID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
    {
        MPCF.ClearList(spdHistory, true);
        MPCF.ClearList(spdData, true);
    
    }
    
    private void dtpFrom_ValueChanged(System.Object sender, System.EventArgs e)
    {
    }
    
    private void dtpTo_ValueChanged(System.Object sender, System.EventArgs e)
    {
    }
    
    private void btnExcel_Click(System.Object sender, System.EventArgs e)
    {
        string sCond;

        sCond = "Resource ID : " + MPCF.Trim(cdvResID.Text) + "\r";
        sCond = sCond + "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom), DATE_TIME_FORMAT.NONE ) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));
        MPCF.ExportToExcel(spdData, this.Text, sCond);
    }
    
    private void spdData_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
    {
        spdData.Sheets[0].Cells[e.Row, (int)DATA_COLUMN.CHECK_COL].Value = true;
        
    }
    
    private void spdData_EditModeOff(object sender, System.EventArgs e)
    {
        try
        {
            int iColumn;
            int iRow;
            
            iColumn = spdData.Sheets[0].ActiveColumnIndex;
            iRow = spdData.Sheets[0].ActiveRowIndex;

            {
                System.Collections.ArrayList a_values = new System.Collections.ArrayList();
                string s_char_id;
                int i_unit_seq;
                int i_value_count;
                int i;
                int j;

                if (MPCF.Trim(spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.VALUE_TYPE].Value) == "N")
                {
                    s_char_id = MPCF.Trim(spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.CHAR_ID].Value);
                    i_unit_seq = MPCF.ToInt(spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.UNIT_SEQ_NUM].Value);

                    for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                    {
                        if (s_char_id == MPCF.Trim(spdData.ActiveSheet.Cells[i, (int)DATA_COLUMN.CHAR_ID].Value) && i_unit_seq == MPCF.ToInt(spdData.ActiveSheet.Cells[i, (int)DATA_COLUMN.UNIT_SEQ_NUM].Value))
                        {
                            i_value_count = MPCF.ToInt(spdData.ActiveSheet.Cells[i, (int)DATA_COLUMN.VALUE_COUNT].Value);

                            for (j = 0; j < i_value_count; j++)
                            {
                                a_values.Add(spdData.ActiveSheet.Cells[i, (int)DATA_COLUMN.VALUE_1 + j].Value);
                            }
                        }
                    }
                    cls_derived_char_list.SetValue(s_char_id, i_unit_seq, a_values, true);
                    MPCR.RecalculateDerivedParam(spdData, cls_derived_char_list, 0, 0, (int)DATA_COLUMN.CHAR_ID, (int)DATA_COLUMN.VALUE_1, (int)DATA_COLUMN.VALUE_COUNT, (int)DATA_COLUMN.CHECK_COL);
                }
            }

            spdData.Sheets[0].Cells[iRow, iColumn].Font = new System.Drawing.Font(this.Font, FontStyle.Bold);
            if (spdData.Sheets[0].Cells[iRow, iColumn + 1].Locked == false)
            {
                spdData.Sheets[0].SetActiveCell(iRow, iColumn + 1);
            }
            else
            {
                if (iRow + 1 == spdData.Sheets[0].RowCount)
                {
                    return;
                }
                spdData.Sheets[0].SetActiveCell(iRow + 1, (int)DATA_COLUMN.VALUE_1);
            }
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
        }
    }

        private void cdvSubResource_ButtonPress(object sender, EventArgs e)
        {
            cdvSubResource.Init();
            MPCF.InitListView(cdvSubResource.GetListView);
            cdvSubResource.Columns.Add("Resource", 50, HorizontalAlignment.Left);
            cdvSubResource.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvSubResource.SelectedSubItemIndex = 0;

            RASLIST.ViewSubResourceList(cdvSubResource.GetListView, '5', cdvResID.Text);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            View_Resource_History();
        }

        private void cdvSubResource_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.ClearList(spdHistory, true);
            MPCF.ClearList(spdData, true);
        }

        private void cdvSubResource_TextBoxTextChanged(object sender, EventArgs e)
        {
            MPCF.ClearList(spdHistory, true);
            MPCF.ClearList(spdData, true);
        }
}

//#End If

}
