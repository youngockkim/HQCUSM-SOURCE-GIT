
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.UI.Controls;
using Miracom.CliFrx;
using Miracom.TRSCore;

//#If _EDC = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmEDCViewResourceDataByCollectionSet.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-08-20 : Created by CM Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.EDCCore
{
    public class frmEDCViewResourceDataByCollectionSet : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmEDCViewResourceDataByCollectionSet()
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
        



        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblPeriod;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCharacter;
        private System.Windows.Forms.Label lblCharacter;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCollectionSet;
        private System.Windows.Forms.Label lblCollectionSet;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvEvent;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.Label lblResource;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private FarPoint.Win.Spread.FpSpread spdData;
        private FarPoint.Win.Spread.SheetView spdData_Sheet1;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSubResource;
        private Label lblSubResID;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.cdvEvent = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblEvent = new System.Windows.Forms.Label();
            this.lblResource = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCharacter = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCharacter = new System.Windows.Forms.Label();
            this.cdvCollectionSet = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCollectionSet = new System.Windows.Forms.Label();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.cdvSubResource = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSubResID = new System.Windows.Forms.Label();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCollectionSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubResource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.TabIndex = 0;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.Size = new System.Drawing.Size(742, 95);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvSubResource);
            this.grpOption.Controls.Add(this.lblSubResID);
            this.grpOption.Controls.Add(this.lblTo);
            this.grpOption.Controls.Add(this.lblPeriod);
            this.grpOption.Controls.Add(this.dtpTo);
            this.grpOption.Controls.Add(this.dtpFrom);
            this.grpOption.Controls.Add(this.cdvEvent);
            this.grpOption.Controls.Add(this.lblEvent);
            this.grpOption.Controls.Add(this.lblResource);
            this.grpOption.Controls.Add(this.cdvResID);
            this.grpOption.Controls.Add(this.cdvCharacter);
            this.grpOption.Controls.Add(this.lblCharacter);
            this.grpOption.Controls.Add(this.cdvCollectionSet);
            this.grpOption.Controls.Add(this.lblCollectionSet);
            this.grpOption.Size = new System.Drawing.Size(742, 95);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdData);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 95);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 418);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Resource Data By Collection Set";
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
            // 
            // lblTo
            // 
            this.lblTo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTo.Location = new System.Drawing.Point(536, 22);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(9, 14);
            this.lblTo.TabIndex = 8;
            this.lblTo.Text = "~";
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Location = new System.Drawing.Point(332, 19);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(37, 13);
            this.lblPeriod.TabIndex = 6;
            this.lblPeriod.Text = "Period";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(549, 16);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(90, 20);
            this.dtpTo.TabIndex = 9;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(442, 16);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(90, 20);
            this.dtpFrom.TabIndex = 7;
            // 
            // cdvEvent
            // 
            this.cdvEvent.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEvent.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEvent.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEvent.BtnToolTipText = "";
            this.cdvEvent.DescText = "";
            this.cdvEvent.DisplaySubItemIndex = -1;
            this.cdvEvent.DisplayText = "";
            this.cdvEvent.Focusing = null;
            this.cdvEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEvent.Index = 0;
            this.cdvEvent.IsViewBtnImage = false;
            this.cdvEvent.Location = new System.Drawing.Point(442, 40);
            this.cdvEvent.MaxLength = 12;
            this.cdvEvent.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEvent.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEvent.Name = "cdvEvent";
            this.cdvEvent.ReadOnly = false;
            this.cdvEvent.SearchSubItemIndex = 0;
            this.cdvEvent.SelectedDescIndex = -1;
            this.cdvEvent.SelectedSubItemIndex = -1;
            this.cdvEvent.SelectionStart = 0;
            this.cdvEvent.Size = new System.Drawing.Size(200, 20);
            this.cdvEvent.SmallImageList = null;
            this.cdvEvent.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEvent.TabIndex = 11;
            this.cdvEvent.TextBoxToolTipText = "";
            this.cdvEvent.TextBoxWidth = 200;
            this.cdvEvent.VisibleButton = true;
            this.cdvEvent.VisibleColumnHeader = false;
            this.cdvEvent.VisibleDescription = false;
            this.cdvEvent.ButtonPress += new System.EventHandler(this.cdvEvent_ButtonPress);
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent.Location = new System.Drawing.Point(332, 43);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(49, 13);
            this.lblEvent.TabIndex = 10;
            this.lblEvent.Text = "Event ID";
            // 
            // lblResource
            // 
            this.lblResource.AutoSize = true;
            this.lblResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResource.Location = new System.Drawing.Point(15, 67);
            this.lblResource.Name = "lblResource";
            this.lblResource.Size = new System.Drawing.Size(67, 13);
            this.lblResource.TabIndex = 4;
            this.lblResource.Text = "Resource ID";
            // 
            // cdvResID
            // 
            this.cdvResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResID.BtnToolTipText = "";
            this.cdvResID.DescText = "";
            this.cdvResID.DisplaySubItemIndex = -1;
            this.cdvResID.DisplayText = "";
            this.cdvResID.Focusing = null;
            this.cdvResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResID.Index = 0;
            this.cdvResID.IsViewBtnImage = false;
            this.cdvResID.Location = new System.Drawing.Point(120, 64);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(200, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 5;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 200;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            this.cdvResID.TextBoxTextChanged += new System.EventHandler(this.cdvResID_TextBoxTextChanged);
            // 
            // cdvCharacter
            // 
            this.cdvCharacter.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCharacter.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCharacter.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCharacter.BtnToolTipText = "";
            this.cdvCharacter.DescText = "";
            this.cdvCharacter.DisplaySubItemIndex = -1;
            this.cdvCharacter.DisplayText = "";
            this.cdvCharacter.Focusing = null;
            this.cdvCharacter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCharacter.Index = 0;
            this.cdvCharacter.IsViewBtnImage = false;
            this.cdvCharacter.Location = new System.Drawing.Point(120, 40);
            this.cdvCharacter.MaxLength = 25;
            this.cdvCharacter.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCharacter.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCharacter.Name = "cdvCharacter";
            this.cdvCharacter.ReadOnly = false;
            this.cdvCharacter.SearchSubItemIndex = 0;
            this.cdvCharacter.SelectedDescIndex = -1;
            this.cdvCharacter.SelectedSubItemIndex = -1;
            this.cdvCharacter.SelectionStart = 0;
            this.cdvCharacter.Size = new System.Drawing.Size(200, 20);
            this.cdvCharacter.SmallImageList = null;
            this.cdvCharacter.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCharacter.TabIndex = 3;
            this.cdvCharacter.TextBoxToolTipText = "";
            this.cdvCharacter.TextBoxWidth = 200;
            this.cdvCharacter.VisibleButton = true;
            this.cdvCharacter.VisibleColumnHeader = false;
            this.cdvCharacter.VisibleDescription = false;
            this.cdvCharacter.ButtonPress += new System.EventHandler(this.cdvCharacter_ButtonPress);
            // 
            // lblCharacter
            // 
            this.lblCharacter.AutoSize = true;
            this.lblCharacter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCharacter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharacter.Location = new System.Drawing.Point(15, 43);
            this.lblCharacter.Name = "lblCharacter";
            this.lblCharacter.Size = new System.Drawing.Size(53, 13);
            this.lblCharacter.TabIndex = 2;
            this.lblCharacter.Text = "Character";
            // 
            // cdvCollectionSet
            // 
            this.cdvCollectionSet.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCollectionSet.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCollectionSet.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCollectionSet.BtnToolTipText = "";
            this.cdvCollectionSet.DescText = "";
            this.cdvCollectionSet.DisplaySubItemIndex = -1;
            this.cdvCollectionSet.DisplayText = "";
            this.cdvCollectionSet.Focusing = null;
            this.cdvCollectionSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCollectionSet.Index = 0;
            this.cdvCollectionSet.IsViewBtnImage = false;
            this.cdvCollectionSet.Location = new System.Drawing.Point(120, 16);
            this.cdvCollectionSet.MaxLength = 25;
            this.cdvCollectionSet.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCollectionSet.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCollectionSet.Name = "cdvCollectionSet";
            this.cdvCollectionSet.ReadOnly = false;
            this.cdvCollectionSet.SearchSubItemIndex = 0;
            this.cdvCollectionSet.SelectedDescIndex = -1;
            this.cdvCollectionSet.SelectedSubItemIndex = -1;
            this.cdvCollectionSet.SelectionStart = 0;
            this.cdvCollectionSet.Size = new System.Drawing.Size(200, 20);
            this.cdvCollectionSet.SmallImageList = null;
            this.cdvCollectionSet.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCollectionSet.TabIndex = 1;
            this.cdvCollectionSet.TextBoxToolTipText = "";
            this.cdvCollectionSet.TextBoxWidth = 200;
            this.cdvCollectionSet.VisibleButton = true;
            this.cdvCollectionSet.VisibleColumnHeader = false;
            this.cdvCollectionSet.VisibleDescription = false;
            this.cdvCollectionSet.ButtonPress += new System.EventHandler(this.cdvCollectionSet_ButtonPress);
            // 
            // lblCollectionSet
            // 
            this.lblCollectionSet.AutoSize = true;
            this.lblCollectionSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCollectionSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollectionSet.Location = new System.Drawing.Point(15, 19);
            this.lblCollectionSet.Name = "lblCollectionSet";
            this.lblCollectionSet.Size = new System.Drawing.Size(86, 13);
            this.lblCollectionSet.TabIndex = 0;
            this.lblCollectionSet.Text = "Collection Set";
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, Sheet1";
            this.spdData.BackColor = System.Drawing.SystemColors.Control;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 4;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.Location = new System.Drawing.Point(0, 3);
            this.spdData.Name = "spdData";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Renderer = columnHeaderRenderer1;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Renderer = rowHeaderRenderer1;
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
            this.spdData.Size = new System.Drawing.Size(742, 415);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 0;
            this.spdData.TabStop = false;
            this.spdData.TabStripRatio = 0.501972386587771D;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 5;
            this.spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdData.SetActiveViewport(0, -1, -1);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 46;
            spdData_Sheet1.ColumnHeader.RowCount = 2;
            spdData_Sheet1.RowCount = 0;
            this.spdData_Sheet1.ActiveColumnIndex = -1;
            this.spdData_Sheet1.ActiveRowIndex = -1;
            this.spdData_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Resource";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Sub Resource";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Hist Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Del Flag";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Event ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Tran Time";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Recipe ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Recipe Version";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 8).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Collection Set ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 9).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Version";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Character Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Character";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 12).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Character Desc";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 13).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Unit Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 14).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Unit ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 15).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Value Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 16).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Value Type";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 17).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Value Count";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 18).ColumnSpan = 25;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Value";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 43).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 43).Value = "Spec Out Mask";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 44).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 44).Value = "Update User ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 45).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 45).Value = "Update Time";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 9).Value = "Version";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 18).Value = "1";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 19).Value = "2";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 20).Value = "3";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 21).Value = "4";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 22).Value = "5";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 23).Value = "6";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 24).Value = "7";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 25).Value = "8";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 26).Value = "9";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 27).Value = "10";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 28).Value = "11";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 29).Value = "12";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 30).Value = "13";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 31).Value = "14";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 32).Value = "15";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 33).Value = "16";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 34).Value = "17";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 35).Value = "18";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 36).Value = "19";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 37).Value = "20";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 38).Value = "21";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 39).Value = "22";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 40).Value = "23";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 41).Value = "24";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 42).Value = "25";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdData_Sheet1.ColumnHeader.Rows.Get(1).Height = 18F;
            this.spdData_Sheet1.Columns.Get(0).Locked = true;
            this.spdData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Locked = true;
            this.spdData_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(2).Locked = true;
            this.spdData_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(2).Width = 40F;
            this.spdData_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(3).Width = 30F;
            this.spdData_Sheet1.Columns.Get(4).Locked = true;
            this.spdData_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(4).Width = 100F;
            this.spdData_Sheet1.Columns.Get(5).Locked = true;
            this.spdData_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(5).Width = 140F;
            this.spdData_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(6).Locked = true;
            this.spdData_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(6).Width = 100F;
            this.spdData_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(7).Locked = true;
            this.spdData_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(7).Width = 45F;
            this.spdData_Sheet1.Columns.Get(8).Locked = true;
            this.spdData_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(8).Width = 100F;
            this.spdData_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(9).Label = "Version";
            this.spdData_Sheet1.Columns.Get(9).Locked = true;
            this.spdData_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(9).Width = 45F;
            this.spdData_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(10).Locked = true;
            this.spdData_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(10).Width = 58F;
            this.spdData_Sheet1.Columns.Get(11).Locked = true;
            this.spdData_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(11).Width = 100F;
            this.spdData_Sheet1.Columns.Get(12).Locked = true;
            this.spdData_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(12).Width = 110F;
            this.spdData_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(13).Locked = true;
            this.spdData_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(13).Width = 30F;
            this.spdData_Sheet1.Columns.Get(14).Locked = true;
            this.spdData_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(14).Width = 100F;
            this.spdData_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(15).Locked = true;
            this.spdData_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(15).Width = 40F;
            this.spdData_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(16).Locked = true;
            this.spdData_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(16).Width = 40F;
            this.spdData_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(17).Locked = true;
            this.spdData_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(17).Width = 40F;
            this.spdData_Sheet1.Columns.Get(18).Label = "1";
            this.spdData_Sheet1.Columns.Get(18).Locked = true;
            this.spdData_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(19).Label = "2";
            this.spdData_Sheet1.Columns.Get(19).Locked = true;
            this.spdData_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(20).Label = "3";
            this.spdData_Sheet1.Columns.Get(20).Locked = true;
            this.spdData_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(21).Label = "4";
            this.spdData_Sheet1.Columns.Get(21).Locked = true;
            this.spdData_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(22).Label = "5";
            this.spdData_Sheet1.Columns.Get(22).Locked = true;
            this.spdData_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(23).Label = "6";
            this.spdData_Sheet1.Columns.Get(23).Locked = true;
            this.spdData_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(24).Label = "7";
            this.spdData_Sheet1.Columns.Get(24).Locked = true;
            this.spdData_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(25).Label = "8";
            this.spdData_Sheet1.Columns.Get(25).Locked = true;
            this.spdData_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(26).Label = "9";
            this.spdData_Sheet1.Columns.Get(26).Locked = true;
            this.spdData_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(27).Label = "10";
            this.spdData_Sheet1.Columns.Get(27).Locked = true;
            this.spdData_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(28).Label = "11";
            this.spdData_Sheet1.Columns.Get(28).Locked = true;
            this.spdData_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(29).Label = "12";
            this.spdData_Sheet1.Columns.Get(29).Locked = true;
            this.spdData_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(30).Label = "13";
            this.spdData_Sheet1.Columns.Get(30).Locked = true;
            this.spdData_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(31).Label = "14";
            this.spdData_Sheet1.Columns.Get(31).Locked = true;
            this.spdData_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(32).Label = "15";
            this.spdData_Sheet1.Columns.Get(32).Locked = true;
            this.spdData_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(33).Label = "16";
            this.spdData_Sheet1.Columns.Get(33).Locked = true;
            this.spdData_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(34).Label = "17";
            this.spdData_Sheet1.Columns.Get(34).Locked = true;
            this.spdData_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(35).Label = "18";
            this.spdData_Sheet1.Columns.Get(35).Locked = true;
            this.spdData_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(36).Label = "19";
            this.spdData_Sheet1.Columns.Get(36).Locked = true;
            this.spdData_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(37).Label = "20";
            this.spdData_Sheet1.Columns.Get(37).Locked = true;
            this.spdData_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(38).Label = "21";
            this.spdData_Sheet1.Columns.Get(38).Locked = true;
            this.spdData_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(39).Label = "22";
            this.spdData_Sheet1.Columns.Get(39).Locked = true;
            this.spdData_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(40).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(40).Label = "23";
            this.spdData_Sheet1.Columns.Get(40).Locked = true;
            this.spdData_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(41).Label = "24";
            this.spdData_Sheet1.Columns.Get(41).Locked = true;
            this.spdData_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(42).Label = "25";
            this.spdData_Sheet1.Columns.Get(42).Locked = true;
            this.spdData_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(43).Locked = true;
            this.spdData_Sheet1.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(43).Width = 160F;
            this.spdData_Sheet1.Columns.Get(44).Locked = true;
            this.spdData_Sheet1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(44).Width = 85F;
            this.spdData_Sheet1.Columns.Get(45).Locked = true;
            this.spdData_Sheet1.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(45).Width = 110F;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.Rows.Default.Height = 18F;
            this.spdData_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // cdvSubResource
            // 
            this.cdvSubResource.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSubResource.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSubResource.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSubResource.BtnToolTipText = "";
            this.cdvSubResource.DescText = "";
            this.cdvSubResource.DisplaySubItemIndex = -1;
            this.cdvSubResource.DisplayText = "";
            this.cdvSubResource.Focusing = null;
            this.cdvSubResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSubResource.Index = 0;
            this.cdvSubResource.IsViewBtnImage = false;
            this.cdvSubResource.Location = new System.Drawing.Point(442, 64);
            this.cdvSubResource.MaxLength = 20;
            this.cdvSubResource.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSubResource.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSubResource.Name = "cdvSubResource";
            this.cdvSubResource.ReadOnly = false;
            this.cdvSubResource.SearchSubItemIndex = 0;
            this.cdvSubResource.SelectedDescIndex = -1;
            this.cdvSubResource.SelectedSubItemIndex = -1;
            this.cdvSubResource.SelectionStart = 0;
            this.cdvSubResource.Size = new System.Drawing.Size(200, 20);
            this.cdvSubResource.SmallImageList = null;
            this.cdvSubResource.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSubResource.TabIndex = 13;
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
            this.lblSubResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubResID.Location = new System.Drawing.Point(332, 67);
            this.lblSubResID.Name = "lblSubResID";
            this.lblSubResID.Size = new System.Drawing.Size(89, 13);
            this.lblSubResID.TabIndex = 12;
            this.lblSubResID.Text = "Sub Resource ID";
            // 
            // frmEDCViewResourceDataByCollectionSet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmEDCViewResourceDataByCollectionSet";
            this.Text = "View Resource Data By Collection Set";
            this.Activated += new System.EventHandler(this.frmEDCViewResourceDataByCollectionSet_Activated);
            this.Load += new System.EventHandler(this.frmEDCViewResourceDataByCollectionSet_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCollectionSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubResource)).EndInit();
            this.ResumeLayout(false);

        }
        
#endregion
        
        #region " Constant Definition "
        
#endregion
        
        #region " Variable Definition"
        
        bool bLoadFlag;
        
#endregion
        
        #region " Function Definition"
        
        private bool View_Resource_Data_By_ColSet()
        {
            TRSNode in_node = new TRSNode("VIEW_RESOURCE_DATA_BY_COLSET_IN");
            TRSNode out_node = new TRSNode("VIEW_RESOURCE_DATA_BY_COLSET_OUT");

            int i, j;
            int iRow;
            int iMaxValueCount = 0;
            int COL_VALUE = 18;
            int iPrecision = 0;

            try
            {
                MPCF.ClearList(spdData, true);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("COL_SET_ID", MPCF.Trim(cdvCollectionSet.Text));
                in_node.AddString("CHAR_ID", MPCF.Trim(cdvCharacter.Text));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("SUBRES_ID", MPCF.Trim(cdvSubResource.Text));
                in_node.AddString("EVENT_ID", MPCF.Trim(cdvEvent.Text));
                in_node.AddString("FROM_TIME", MPCF.FromDate(dtpFrom));
                in_node.AddString("TO_TIME", MPCF.ToDate(dtpTo));
                in_node.AddChar("INCLUDE_DEL_HIST", 'Y');
                in_node.AddString("NEXT_RES_ID", "");
                in_node.AddInt("NEXT_RES_HIST_SEQ", int.MaxValue);
                in_node.AddInt("NEXT_CHAR_SEQ_NUM", 0);
                in_node.AddInt("NEXT_UNIT_SEQ_NUM", 0);
                in_node.AddInt("NEXT_VALUE_SEQ_NUM", 0);

                do
                {
                    if (MPCR.CallService("EDC", "EDC_View_Resource_Data_By_ColSet", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdData.Sheets[0].RowCount;
                        spdData.Sheets[0].RowCount++;

                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("HIS_DEL_FLAG")) == "Y")
                        {
                            spdData.Sheets[0].Cells[iRow, 0, iRow, spdData.Sheets[0].ColumnCount - 1].ForeColor = Color.Magenta;
                        }
                        else
                        {
                            spdData.Sheets[0].Cells[iRow, 0, iRow, spdData.Sheets[0].ColumnCount - 1].ForeColor = Color.Black;
                        }

                        //CHARACTERÀÇ DISPLAY_PRECISION
                        iPrecision = out_node.GetList(0)[i].GetInt("DISPLAY_PRECISION");

                        spdData.Sheets[0].Cells[iRow, 0].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID"));
                        spdData.Sheets[0].Cells[iRow, 1].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("SUBRES_ID"));
                        spdData.Sheets[0].Cells[iRow, 2].Value = out_node.GetList(0)[i].GetInt("HIST_SEQ");
                        spdData.Sheets[0].Cells[iRow, 3].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("HIS_DEL_FLAG"));
                        spdData.Sheets[0].Cells[iRow, 4].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID"));
                        spdData.Sheets[0].Cells[iRow, 5].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));
                        spdData.Sheets[0].Cells[iRow, 6].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("RECIPE_ID"));
                        spdData.Sheets[0].Cells[iRow, 7].Value = out_node.GetList(0)[i].GetInt("RECIPE_VERSION");
                        spdData.Sheets[0].Cells[iRow, 8].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("COL_SET_ID"));
                        spdData.Sheets[0].Cells[iRow, 9].Value = out_node.GetList(0)[i].GetInt("COL_SET_VERSION");
                        spdData.Sheets[0].Cells[iRow, 10].Value = out_node.GetList(0)[i].GetInt("CHAR_SEQ_NUM");
                        spdData.Sheets[0].Cells[iRow, 11].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_ID"));
                        spdData.Sheets[0].Cells[iRow, 12].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_DESC"));
                        spdData.Sheets[0].Cells[iRow, 13].Value = out_node.GetList(0)[i].GetInt("UNIT_SEQ_NUM");
                        spdData.Sheets[0].Cells[iRow, 14].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UNIT_ID"));
                        spdData.Sheets[0].Cells[iRow, 15].Value = out_node.GetList(0)[i].GetInt("VALUE_SEQ_NUM");
                        spdData.Sheets[0].Cells[iRow, 16].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("VALUE_TYPE"));
                        spdData.Sheets[0].Cells[iRow, 17].Value = out_node.GetList(0)[i].GetInt("VALUE_COUNT");

                        if (out_node.GetList(0)[i].GetChar("VALUE_TYPE") == 'N')
                        {
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_1")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 0].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_1"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_2")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 1].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_2"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_3")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 2].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_3"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_4")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 3].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_4"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_5")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 4].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_5"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_6")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 5].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_6"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_7")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 6].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_7"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_8")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 7].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_8"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_9")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 8].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_9"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_10")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 9].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_10"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_11")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 10].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_11"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_12")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 11].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_12"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_13")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 12].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_13"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_14")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 13].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_14"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_15")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 14].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_15"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_16")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 15].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_16"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_17")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 16].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_17"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_18")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 17].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_18"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_19")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 18].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_19"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_20")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 19].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_20"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_21")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 20].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_21"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_22")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 21].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_22"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_23")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 22].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_23"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_24")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 23].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_24"));
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_25")) != "")
                                spdData.Sheets[0].Cells[iRow, COL_VALUE + 24].Value = MPCF.ToDbl(out_node.GetList(0)[i].GetString("VALUE_25"));
                        }
                        else
                        {
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 0].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_1"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 1].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_2"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 2].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_3"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 3].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_4"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 4].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_5"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 5].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_6"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 6].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_7"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 7].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_8"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 8].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_9"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 9].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_10"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 10].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_11"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 11].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_12"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 12].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_13"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 13].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_14"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 14].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_15"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 15].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_16"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 16].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_17"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 17].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_18"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 18].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_19"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 19].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_20"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 20].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_21"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 21].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_22"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 22].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_23"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 23].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_24"));
                            spdData.Sheets[0].Cells[iRow, COL_VALUE + 24].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_25"));
                        }

                        spdData.Sheets[0].Cells[iRow, 43].Value = out_node.GetList(0)[i].GetString("SPEC_OUT_MASK");
                        spdData.Sheets[0].Cells[iRow, 44].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_USER_ID"));
                        spdData.Sheets[0].Cells[iRow, 45].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_TIME"));

                        for (j = COL_VALUE; j < COL_VALUE + 25; j++)
                        {
                            if (out_node.GetList(0)[i].GetChar("VALUE_TYPE") == 'N')
                            {
                                //DISPLAY PRECISION Àû¿ë
                                if (iPrecision > 0 && spdData.Sheets[0].Cells[iRow, j].Value != null)
                                {
                                    spdData.Sheets[0].Cells[iRow, j].Value = MPCF.SetPrecision(spdData.Sheets[0].Cells[iRow, j].Value.ToString(), iPrecision);
                                }
                                MPCR.SetNumberCell(spdData.Sheets[0].Cells[iRow, j]);
                            }
                            else
                            {
                                MPCR.SetAsciiCell(spdData.Sheets[0].Cells[iRow, j]);
                            }
                        }

                        if (iMaxValueCount < out_node.GetList(0)[i].GetInt("VALUE_COUNT"))
                        {
                            iMaxValueCount = out_node.GetList(0)[i].GetInt("VALUE_COUNT");
                        }
                    }

                    in_node.SetString("NEXT_RES_ID", out_node.GetString("NEXT_RES_ID"));
                    in_node.SetInt("NEXT_RES_HIST_SEQ", out_node.GetInt("NEXT_RES_HIST_SEQ"));
                    in_node.SetInt("NEXT_CHAR_SEQ_NUM", out_node.GetInt("NEXT_CHAR_SEQ_NUM"));
                    in_node.SetInt("NEXT_UNIT_SEQ_NUM", out_node.GetInt("NEXT_UNIT_SEQ_NUM"));
                    in_node.SetInt("NEXT_VALUE_SEQ_NUM", out_node.GetInt("NEXT_VALUE_SEQ_NUM"));

                } while (in_node.GetString("NEXT_RES_ID") != "" ||
                         in_node.GetInt("NEXT_RES_HIST_SEQ") > 0 ||
                         in_node.GetInt("NEXT_CHAR_SEQ_NUM") > 0 ||
                         in_node.GetInt("NEXT_UNIT_SEQ_NUM") > 0 ||
                         in_node.GetInt("NEXT_VALUE_SEQ_NUM") > 0);

                if (spdData.Sheets[0].RowCount > 0)
                {
                    if (iMaxValueCount == 0)
                    {
                        iMaxValueCount = 1;
                    }
                    spdData.Sheets[0].Columns.Get(COL_VALUE, COL_VALUE + iMaxValueCount - 1).Visible = true;
                    if (iMaxValueCount < 25)
                    {
                        spdData.Sheets[0].Columns.Get(COL_VALUE + iMaxValueCount, COL_VALUE + 24).Visible = false;
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
                return this.cdvCollectionSet;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
#endregion
        
        private void frmEDCViewResourceDataByCollectionSet_Load(object sender, System.EventArgs e)
        {
            
            dtpTo.Value = DateTime.Today;
            dtpFrom.Value = dtpTo.Value.AddMonths(- 1);
            
        }
        
        private void frmEDCViewResourceDataByCollectionSet_Activated(object sender, System.EventArgs e)
        {
            
            if (bLoadFlag == false)
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdData, true);
                bLoadFlag = true;
            }
            
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            
            if (MPCF.CheckValue(cdvCollectionSet,  1) == false)
            {
                return;
            }
            
            View_Resource_Data_By_ColSet();
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;
            
            sCond = "Collection Set ID : " + MPCF.Trim(cdvCollectionSet.Text) + "\r";
            sCond = sCond + "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));
            
            MPCF.ExportToExcel(spdData, this.Text, sCond);
            
        }
        
        private void cdvCharacter_ButtonPress(object sender, System.EventArgs e)
        {
            if (MPCF.CheckValue(cdvCollectionSet, 1, false, false ,"","","") == false)
            {
                cdvCharacter.GetListView.Items.Clear();
                return;
            }
            cdvCharacter.Init();
            MPCF.InitListView(cdvCharacter.GetListView);
            cdvCharacter.Columns.Add("Character", 50, HorizontalAlignment.Left);
            cdvCharacter.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCharacter.SelectedSubItemIndex = 0;
            if (EDCLIST.ViewCharacterbyCollection(cdvCharacter.GetListView, '6', cdvCollectionSet.Text, null, "", 'N') == false)
            {
                return;
            }
            
        }
        
        private void cdvCollectionSet_ButtonPress(object sender, System.EventArgs e)
        {
            cdvCollectionSet.Init();
            MPCF.InitListView(cdvCollectionSet.GetListView);
            cdvCollectionSet.Columns.Add("Collection Set", 50, HorizontalAlignment.Left);
            cdvCollectionSet.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCollectionSet.SelectedSubItemIndex = 0;
            EDCLIST.ViewEDCColSetList(cdvCollectionSet.GetListView, '1', null, "", -1, -1, ' ', false);
        }
        
        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvResID.Init();
            MPCF.InitListView(cdvResID.GetListView);
            cdvResID.Columns.Add("Resource", 50, HorizontalAlignment.Left);
            cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResID.SelectedSubItemIndex = 0;
            RASLIST.ViewResourceList(cdvResID.GetListView, false);
        }
        
        private void cdvEvent_ButtonPress(object sender, System.EventArgs e)
        {
            cdvEvent.Init();
            MPCF.InitListView(cdvEvent.GetListView);
            cdvEvent.Columns.Add("Event", 50, HorizontalAlignment.Left);
            cdvEvent.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvEvent.SelectedSubItemIndex = 0;
            RASLIST.ViewEventList(cdvEvent.GetListView, '1', "", null, "");
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

        private void cdvSubResource_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.ClearList(spdData, true);
        }

        private void cdvSubResource_TextBoxTextChanged(object sender, EventArgs e)
        {
            MPCF.ClearList(spdData, true);
        }

        private void cdvResID_TextBoxTextChanged(object sender, EventArgs e)
        {
            cdvSubResource.Text = "";
            MPCF.ClearList(spdData, true);
        }

    }
    
    //#End If
    
    
}
