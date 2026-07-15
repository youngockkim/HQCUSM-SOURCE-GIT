//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASTranMakeSheet.cs
//   Description : MES Cient Form Attribute Value Class
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - CheckCondition() : Check Update condition
//
//   Detail Description
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2006-07-05 : Created by Aiden Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//Imports

using System.Data;
using System.Collections;
using System.Diagnostics;
using System;
using System.Windows.Forms;
using Miracom.UI.Controls;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.RASCore
{
    public class frmRASTranMakeCheckResult : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "

        public frmRASTranMakeCheckResult()
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
        



        private System.Windows.Forms.Label lblSheetName;
        private System.Windows.Forms.GroupBox grpSheetName;
        private System.Windows.Forms.Panel pnlAttrInfo;
        private Label lblDesc;
        private TextBox txtSheetDesc;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSheetName;
        private System.Windows.Forms.Button btnView;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSheetType;
        private Label lblSheetType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvDataType;
        private Label lblDataType;
        private GroupBox grpSheetData;
        private FarPoint.Win.Spread.FpSpread spdSheetData;
        private FarPoint.Win.Spread.SheetView spdSheetData_Sheet1;
        private GroupBox grpKey;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvKey10;
        private Label lblKey10;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvKey9;
        private Label lblKey9;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvKey8;
        private Label lblKey8;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvKey7;
        private Label lblKey7;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvKey6;
        private Label lblKey6;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvKey5;
        private Label lblKey5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvKey4;
        private Label lblKey4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvKey3;
        private Label lblKey3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvKey2;
        private Label lblKey2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvKey1;
        private Label lblKey1;
        protected Button btnExcel;
        private CheckBox chkCompleteFlag;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvTableData;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRASTranMakeCheckResult));
            this.grpSheetName = new System.Windows.Forms.GroupBox();
            this.cdvDataType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblDataType = new System.Windows.Forms.Label();
            this.cdvSheetType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSheetType = new System.Windows.Forms.Label();
            this.txtSheetDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.cdvSheetName = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSheetName = new System.Windows.Forms.Label();
            this.pnlAttrInfo = new System.Windows.Forms.Panel();
            this.grpSheetData = new System.Windows.Forms.GroupBox();
            this.spdSheetData = new FarPoint.Win.Spread.FpSpread();
            this.spdSheetData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grpKey = new System.Windows.Forms.GroupBox();
            this.cdvKey10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblKey10 = new System.Windows.Forms.Label();
            this.cdvKey9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblKey9 = new System.Windows.Forms.Label();
            this.cdvKey8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblKey8 = new System.Windows.Forms.Label();
            this.cdvKey7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblKey7 = new System.Windows.Forms.Label();
            this.cdvKey6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblKey6 = new System.Windows.Forms.Label();
            this.cdvKey5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblKey5 = new System.Windows.Forms.Label();
            this.cdvKey4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblKey4 = new System.Windows.Forms.Label();
            this.cdvKey3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblKey3 = new System.Windows.Forms.Label();
            this.cdvKey2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblKey2 = new System.Windows.Forms.Label();
            this.cdvKey1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblKey1 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.cdvTableData = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.chkCompleteFlag = new System.Windows.Forms.CheckBox();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpSheetName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetName)).BeginInit();
            this.pnlAttrInfo.SuspendLayout();
            this.grpSheetData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdSheetData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSheetData_Sheet1)).BeginInit();
            this.grpKey.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 2;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.chkCompleteFlag);
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 0;
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.chkCompleteFlag, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlAttrInfo);
            this.pnlCenter.Controls.Add(this.grpSheetName);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "BaseForm03";
            // 
            // grpSheetName
            // 
            this.grpSheetName.Controls.Add(this.cdvDataType);
            this.grpSheetName.Controls.Add(this.lblDataType);
            this.grpSheetName.Controls.Add(this.cdvSheetType);
            this.grpSheetName.Controls.Add(this.lblSheetType);
            this.grpSheetName.Controls.Add(this.txtSheetDesc);
            this.grpSheetName.Controls.Add(this.lblDesc);
            this.grpSheetName.Controls.Add(this.cdvSheetName);
            this.grpSheetName.Controls.Add(this.lblSheetName);
            this.grpSheetName.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSheetName.Location = new System.Drawing.Point(0, 0);
            this.grpSheetName.Name = "grpSheetName";
            this.grpSheetName.Size = new System.Drawing.Size(742, 87);
            this.grpSheetName.TabIndex = 0;
            this.grpSheetName.TabStop = false;
            // 
            // cdvDataType
            // 
            this.cdvDataType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDataType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDataType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvDataType.BtnToolTipText = "";
            this.cdvDataType.DescText = "";
            this.cdvDataType.DisplaySubItemIndex = 0;
            this.cdvDataType.DisplayText = "";
            this.cdvDataType.Focusing = null;
            this.cdvDataType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvDataType.Index = 0;
            this.cdvDataType.IsViewBtnImage = false;
            this.cdvDataType.Location = new System.Drawing.Point(506, 35);
            this.cdvDataType.MaxLength = 20;
            this.cdvDataType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvDataType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvDataType.Name = "cdvDataType";
            this.cdvDataType.ReadOnly = false;
            this.cdvDataType.SearchSubItemIndex = 0;
            this.cdvDataType.SelectedDescIndex = -1;
            this.cdvDataType.SelectedSubItemIndex = 0;
            this.cdvDataType.SelectionStart = 0;
            this.cdvDataType.Size = new System.Drawing.Size(224, 20);
            this.cdvDataType.SmallImageList = null;
            this.cdvDataType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvDataType.TabIndex = 5;
            this.cdvDataType.TextBoxToolTipText = "";
            this.cdvDataType.TextBoxWidth = 224;
            this.cdvDataType.VisibleButton = true;
            this.cdvDataType.VisibleColumnHeader = false;
            this.cdvDataType.VisibleDescription = false;
            this.cdvDataType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvDataType_SelectedItemChanged);
            this.cdvDataType.ButtonPress += new System.EventHandler(this.cdvDataType_ButtonPress);
            // 
            // lblDataType
            // 
            this.lblDataType.AutoSize = true;
            this.lblDataType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDataType.Location = new System.Drawing.Point(397, 38);
            this.lblDataType.Name = "lblDataType";
            this.lblDataType.Size = new System.Drawing.Size(106, 13);
            this.lblDataType.TabIndex = 4;
            this.lblDataType.Text = "Check Data Type";
            // 
            // cdvSheetType
            // 
            this.cdvSheetType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSheetType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSheetType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSheetType.BtnToolTipText = "";
            this.cdvSheetType.DescText = "";
            this.cdvSheetType.DisplaySubItemIndex = 0;
            this.cdvSheetType.DisplayText = "";
            this.cdvSheetType.Focusing = null;
            this.cdvSheetType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSheetType.Index = 0;
            this.cdvSheetType.IsViewBtnImage = false;
            this.cdvSheetType.Location = new System.Drawing.Point(127, 12);
            this.cdvSheetType.MaxLength = 20;
            this.cdvSheetType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSheetType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSheetType.Name = "cdvSheetType";
            this.cdvSheetType.ReadOnly = false;
            this.cdvSheetType.SearchSubItemIndex = 0;
            this.cdvSheetType.SelectedDescIndex = -1;
            this.cdvSheetType.SelectedSubItemIndex = 0;
            this.cdvSheetType.SelectionStart = 0;
            this.cdvSheetType.Size = new System.Drawing.Size(189, 20);
            this.cdvSheetType.SmallImageList = null;
            this.cdvSheetType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSheetType.TabIndex = 1;
            this.cdvSheetType.TextBoxToolTipText = "";
            this.cdvSheetType.TextBoxWidth = 189;
            this.cdvSheetType.VisibleButton = true;
            this.cdvSheetType.VisibleColumnHeader = false;
            this.cdvSheetType.VisibleDescription = false;
            this.cdvSheetType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvSheetType_SelectedItemChanged);
            this.cdvSheetType.ButtonPress += new System.EventHandler(this.cdvSheetType_ButtonPress);
            // 
            // lblSheetType
            // 
            this.lblSheetType.AutoSize = true;
            this.lblSheetType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSheetType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSheetType.Location = new System.Drawing.Point(9, 15);
            this.lblSheetType.Name = "lblSheetType";
            this.lblSheetType.Size = new System.Drawing.Size(65, 13);
            this.lblSheetType.TabIndex = 0;
            this.lblSheetType.Text = "Check Type";
            // 
            // txtSheetDesc
            // 
            this.txtSheetDesc.BackColor = System.Drawing.SystemColors.Menu;
            this.txtSheetDesc.Enabled = false;
            this.txtSheetDesc.Location = new System.Drawing.Point(127, 58);
            this.txtSheetDesc.MaxLength = 200;
            this.txtSheetDesc.Name = "txtSheetDesc";
            this.txtSheetDesc.Size = new System.Drawing.Size(603, 20);
            this.txtSheetDesc.TabIndex = 7;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDesc.Location = new System.Drawing.Point(9, 60);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 6;
            this.lblDesc.Text = "Description";
            // 
            // cdvSheetName
            // 
            this.cdvSheetName.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSheetName.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSheetName.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSheetName.BtnToolTipText = "";
            this.cdvSheetName.DescText = "";
            this.cdvSheetName.DisplaySubItemIndex = 0;
            this.cdvSheetName.DisplayText = "";
            this.cdvSheetName.Focusing = null;
            this.cdvSheetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSheetName.Index = 0;
            this.cdvSheetName.IsViewBtnImage = false;
            this.cdvSheetName.Location = new System.Drawing.Point(127, 35);
            this.cdvSheetName.MaxLength = 50;
            this.cdvSheetName.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSheetName.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSheetName.Name = "cdvSheetName";
            this.cdvSheetName.ReadOnly = false;
            this.cdvSheetName.SearchSubItemIndex = 0;
            this.cdvSheetName.SelectedDescIndex = -1;
            this.cdvSheetName.SelectedSubItemIndex = 0;
            this.cdvSheetName.SelectionStart = 0;
            this.cdvSheetName.Size = new System.Drawing.Size(189, 20);
            this.cdvSheetName.SmallImageList = null;
            this.cdvSheetName.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSheetName.TabIndex = 3;
            this.cdvSheetName.TextBoxToolTipText = "";
            this.cdvSheetName.TextBoxWidth = 189;
            this.cdvSheetName.VisibleButton = true;
            this.cdvSheetName.VisibleColumnHeader = false;
            this.cdvSheetName.VisibleDescription = false;
            this.cdvSheetName.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvSheetName_SelectedItemChanged);
            this.cdvSheetName.ButtonPress += new System.EventHandler(this.cdvSheetName_ButtonPress);
            // 
            // lblSheetName
            // 
            this.lblSheetName.AutoSize = true;
            this.lblSheetName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSheetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSheetName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSheetName.Location = new System.Drawing.Point(9, 38);
            this.lblSheetName.Name = "lblSheetName";
            this.lblSheetName.Size = new System.Drawing.Size(79, 13);
            this.lblSheetName.TabIndex = 2;
            this.lblSheetName.Text = "Check Name";
            // 
            // pnlAttrInfo
            // 
            this.pnlAttrInfo.Controls.Add(this.grpSheetData);
            this.pnlAttrInfo.Controls.Add(this.grpKey);
            this.pnlAttrInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttrInfo.Location = new System.Drawing.Point(0, 87);
            this.pnlAttrInfo.Name = "pnlAttrInfo";
            this.pnlAttrInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlAttrInfo.Size = new System.Drawing.Size(742, 426);
            this.pnlAttrInfo.TabIndex = 1;
            // 
            // grpSheetData
            // 
            this.grpSheetData.Controls.Add(this.spdSheetData);
            this.grpSheetData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSheetData.Location = new System.Drawing.Point(0, 136);
            this.grpSheetData.Name = "grpSheetData";
            this.grpSheetData.Size = new System.Drawing.Size(742, 290);
            this.grpSheetData.TabIndex = 1;
            this.grpSheetData.TabStop = false;
            this.grpSheetData.Text = "Check  Result";
            // 
            // spdSheetData
            // 
            this.spdSheetData.AccessibleDescription = "spdSheetData, Sheet1, Row 0, Column 0, ";
            this.spdSheetData.BackColor = System.Drawing.SystemColors.Control;
            this.spdSheetData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdSheetData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdSheetData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdSheetData.HorizontalScrollBar.Name = "";
            this.spdSheetData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdSheetData.HorizontalScrollBar.TabIndex = 2;
            this.spdSheetData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdSheetData.Location = new System.Drawing.Point(3, 16);
            this.spdSheetData.Name = "spdSheetData";
            this.spdSheetData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdSheetData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdSheetData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdSheetData_Sheet1});
            this.spdSheetData.Size = new System.Drawing.Size(736, 271);
            this.spdSheetData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdSheetData.TabIndex = 0;
            this.spdSheetData.TextTipDelay = 200;
            this.spdSheetData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdSheetData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdSheetData.VerticalScrollBar.Name = "";
            this.spdSheetData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdSheetData.VerticalScrollBar.TabIndex = 3;
            this.spdSheetData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdSheetData.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdSheetData_ButtonClicked);
            this.spdSheetData.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdSheetData_EditChange);
            // 
            // spdSheetData_Sheet1
            // 
            this.spdSheetData_Sheet1.Reset();
            spdSheetData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdSheetData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdSheetData_Sheet1.ColumnCount = 5;
            spdSheetData_Sheet1.RowCount = 3;
            this.spdSheetData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSheetData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdSheetData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSheetData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdSheetData_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.spdSheetData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "ID";
            this.spdSheetData_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.spdSheetData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Query";
            this.spdSheetData_Sheet1.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 2;
            this.spdSheetData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Value";
            this.spdSheetData_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Comment";
            this.spdSheetData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSheetData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdSheetData_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType1.MaxLength = 100;
            textCellType1.WordWrap = true;
            this.spdSheetData_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.spdSheetData_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSheetData_Sheet1.Columns.Get(0).Label = "ID";
            this.spdSheetData_Sheet1.Columns.Get(0).Locked = true;
            this.spdSheetData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSheetData_Sheet1.Columns.Get(0).Width = 68F;
            this.spdSheetData_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType2.MaxLength = 110;
            textCellType2.WordWrap = true;
            this.spdSheetData_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.spdSheetData_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSheetData_Sheet1.Columns.Get(1).Label = "Query";
            this.spdSheetData_Sheet1.Columns.Get(1).Locked = true;
            this.spdSheetData_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSheetData_Sheet1.Columns.Get(1).Width = 405F;
            this.spdSheetData_Sheet1.Columns.Get(2).Label = "Value";
            this.spdSheetData_Sheet1.Columns.Get(2).Width = 196F;
            this.spdSheetData_Sheet1.Columns.Get(3).Width = 25F;
            textCellType3.MaxLength = 200;
            this.spdSheetData_Sheet1.Columns.Get(4).CellType = textCellType3;
            this.spdSheetData_Sheet1.Columns.Get(4).Label = "Comment";
            this.spdSheetData_Sheet1.Columns.Get(4).Width = 410F;
            this.spdSheetData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdSheetData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdSheetData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSheetData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdSheetData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSheetData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdSheetData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpKey
            // 
            this.grpKey.Controls.Add(this.cdvKey10);
            this.grpKey.Controls.Add(this.lblKey10);
            this.grpKey.Controls.Add(this.cdvKey9);
            this.grpKey.Controls.Add(this.lblKey9);
            this.grpKey.Controls.Add(this.cdvKey8);
            this.grpKey.Controls.Add(this.lblKey8);
            this.grpKey.Controls.Add(this.cdvKey7);
            this.grpKey.Controls.Add(this.lblKey7);
            this.grpKey.Controls.Add(this.cdvKey6);
            this.grpKey.Controls.Add(this.lblKey6);
            this.grpKey.Controls.Add(this.cdvKey5);
            this.grpKey.Controls.Add(this.lblKey5);
            this.grpKey.Controls.Add(this.cdvKey4);
            this.grpKey.Controls.Add(this.lblKey4);
            this.grpKey.Controls.Add(this.cdvKey3);
            this.grpKey.Controls.Add(this.lblKey3);
            this.grpKey.Controls.Add(this.cdvKey2);
            this.grpKey.Controls.Add(this.lblKey2);
            this.grpKey.Controls.Add(this.cdvKey1);
            this.grpKey.Controls.Add(this.lblKey1);
            this.grpKey.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpKey.Location = new System.Drawing.Point(0, 5);
            this.grpKey.Name = "grpKey";
            this.grpKey.Size = new System.Drawing.Size(742, 131);
            this.grpKey.TabIndex = 0;
            this.grpKey.TabStop = false;
            this.grpKey.Visible = false;
            // 
            // cdvKey10
            // 
            this.cdvKey10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvKey10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvKey10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvKey10.BtnToolTipText = "";
            this.cdvKey10.DescText = "";
            this.cdvKey10.DisplaySubItemIndex = -1;
            this.cdvKey10.DisplayText = "";
            this.cdvKey10.Focusing = null;
            this.cdvKey10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvKey10.Index = 0;
            this.cdvKey10.IsViewBtnImage = false;
            this.cdvKey10.Location = new System.Drawing.Point(508, 104);
            this.cdvKey10.MaxLength = 20;
            this.cdvKey10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvKey10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvKey10.Name = "cdvKey10";
            this.cdvKey10.ReadOnly = false;
            this.cdvKey10.SearchSubItemIndex = 0;
            this.cdvKey10.SelectedDescIndex = -1;
            this.cdvKey10.SelectedSubItemIndex = -1;
            this.cdvKey10.SelectionStart = 0;
            this.cdvKey10.Size = new System.Drawing.Size(189, 20);
            this.cdvKey10.SmallImageList = null;
            this.cdvKey10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvKey10.TabIndex = 19;
            this.cdvKey10.TextBoxToolTipText = "";
            this.cdvKey10.TextBoxWidth = 189;
            this.cdvKey10.Visible = false;
            this.cdvKey10.VisibleButton = true;
            this.cdvKey10.VisibleColumnHeader = false;
            this.cdvKey10.VisibleDescription = false;
            this.cdvKey10.ButtonPress += new System.EventHandler(this.cdvSheetKey_ButtonPress);
            // 
            // lblKey10
            // 
            this.lblKey10.AutoSize = true;
            this.lblKey10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKey10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey10.Location = new System.Drawing.Point(397, 107);
            this.lblKey10.Name = "lblKey10";
            this.lblKey10.Size = new System.Drawing.Size(68, 13);
            this.lblKey10.TabIndex = 18;
            this.lblKey10.Text = "Check Key";
            this.lblKey10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKey10.Visible = false;
            // 
            // cdvKey9
            // 
            this.cdvKey9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvKey9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvKey9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvKey9.BtnToolTipText = "";
            this.cdvKey9.DescText = "";
            this.cdvKey9.DisplaySubItemIndex = -1;
            this.cdvKey9.DisplayText = "";
            this.cdvKey9.Focusing = null;
            this.cdvKey9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvKey9.Index = 0;
            this.cdvKey9.IsViewBtnImage = false;
            this.cdvKey9.Location = new System.Drawing.Point(127, 104);
            this.cdvKey9.MaxLength = 20;
            this.cdvKey9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvKey9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvKey9.Name = "cdvKey9";
            this.cdvKey9.ReadOnly = false;
            this.cdvKey9.SearchSubItemIndex = 0;
            this.cdvKey9.SelectedDescIndex = -1;
            this.cdvKey9.SelectedSubItemIndex = -1;
            this.cdvKey9.SelectionStart = 0;
            this.cdvKey9.Size = new System.Drawing.Size(189, 20);
            this.cdvKey9.SmallImageList = null;
            this.cdvKey9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvKey9.TabIndex = 9;
            this.cdvKey9.TextBoxToolTipText = "";
            this.cdvKey9.TextBoxWidth = 189;
            this.cdvKey9.Visible = false;
            this.cdvKey9.VisibleButton = true;
            this.cdvKey9.VisibleColumnHeader = false;
            this.cdvKey9.VisibleDescription = false;
            this.cdvKey9.ButtonPress += new System.EventHandler(this.cdvSheetKey_ButtonPress);
            // 
            // lblKey9
            // 
            this.lblKey9.AutoSize = true;
            this.lblKey9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKey9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey9.Location = new System.Drawing.Point(16, 107);
            this.lblKey9.Name = "lblKey9";
            this.lblKey9.Size = new System.Drawing.Size(68, 13);
            this.lblKey9.TabIndex = 8;
            this.lblKey9.Text = "Check Key";
            this.lblKey9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKey9.Visible = false;
            // 
            // cdvKey8
            // 
            this.cdvKey8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvKey8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvKey8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvKey8.BtnToolTipText = "";
            this.cdvKey8.DescText = "";
            this.cdvKey8.DisplaySubItemIndex = -1;
            this.cdvKey8.DisplayText = "";
            this.cdvKey8.Focusing = null;
            this.cdvKey8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvKey8.Index = 0;
            this.cdvKey8.IsViewBtnImage = false;
            this.cdvKey8.Location = new System.Drawing.Point(508, 81);
            this.cdvKey8.MaxLength = 20;
            this.cdvKey8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvKey8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvKey8.Name = "cdvKey8";
            this.cdvKey8.ReadOnly = false;
            this.cdvKey8.SearchSubItemIndex = 0;
            this.cdvKey8.SelectedDescIndex = -1;
            this.cdvKey8.SelectedSubItemIndex = -1;
            this.cdvKey8.SelectionStart = 0;
            this.cdvKey8.Size = new System.Drawing.Size(189, 20);
            this.cdvKey8.SmallImageList = null;
            this.cdvKey8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvKey8.TabIndex = 17;
            this.cdvKey8.TextBoxToolTipText = "";
            this.cdvKey8.TextBoxWidth = 189;
            this.cdvKey8.Visible = false;
            this.cdvKey8.VisibleButton = true;
            this.cdvKey8.VisibleColumnHeader = false;
            this.cdvKey8.VisibleDescription = false;
            this.cdvKey8.ButtonPress += new System.EventHandler(this.cdvSheetKey_ButtonPress);
            // 
            // lblKey8
            // 
            this.lblKey8.AutoSize = true;
            this.lblKey8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKey8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey8.Location = new System.Drawing.Point(397, 84);
            this.lblKey8.Name = "lblKey8";
            this.lblKey8.Size = new System.Drawing.Size(68, 13);
            this.lblKey8.TabIndex = 16;
            this.lblKey8.Text = "Check Key";
            this.lblKey8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKey8.Visible = false;
            // 
            // cdvKey7
            // 
            this.cdvKey7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvKey7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvKey7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvKey7.BtnToolTipText = "";
            this.cdvKey7.DescText = "";
            this.cdvKey7.DisplaySubItemIndex = -1;
            this.cdvKey7.DisplayText = "";
            this.cdvKey7.Focusing = null;
            this.cdvKey7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvKey7.Index = 0;
            this.cdvKey7.IsViewBtnImage = false;
            this.cdvKey7.Location = new System.Drawing.Point(127, 81);
            this.cdvKey7.MaxLength = 20;
            this.cdvKey7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvKey7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvKey7.Name = "cdvKey7";
            this.cdvKey7.ReadOnly = false;
            this.cdvKey7.SearchSubItemIndex = 0;
            this.cdvKey7.SelectedDescIndex = -1;
            this.cdvKey7.SelectedSubItemIndex = -1;
            this.cdvKey7.SelectionStart = 0;
            this.cdvKey7.Size = new System.Drawing.Size(189, 20);
            this.cdvKey7.SmallImageList = null;
            this.cdvKey7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvKey7.TabIndex = 7;
            this.cdvKey7.TextBoxToolTipText = "";
            this.cdvKey7.TextBoxWidth = 189;
            this.cdvKey7.Visible = false;
            this.cdvKey7.VisibleButton = true;
            this.cdvKey7.VisibleColumnHeader = false;
            this.cdvKey7.VisibleDescription = false;
            this.cdvKey7.ButtonPress += new System.EventHandler(this.cdvSheetKey_ButtonPress);
            // 
            // lblKey7
            // 
            this.lblKey7.AutoSize = true;
            this.lblKey7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKey7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey7.Location = new System.Drawing.Point(16, 84);
            this.lblKey7.Name = "lblKey7";
            this.lblKey7.Size = new System.Drawing.Size(68, 13);
            this.lblKey7.TabIndex = 6;
            this.lblKey7.Text = "Check Key";
            this.lblKey7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKey7.Visible = false;
            // 
            // cdvKey6
            // 
            this.cdvKey6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvKey6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvKey6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvKey6.BtnToolTipText = "";
            this.cdvKey6.DescText = "";
            this.cdvKey6.DisplaySubItemIndex = -1;
            this.cdvKey6.DisplayText = "";
            this.cdvKey6.Focusing = null;
            this.cdvKey6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvKey6.Index = 0;
            this.cdvKey6.IsViewBtnImage = false;
            this.cdvKey6.Location = new System.Drawing.Point(508, 58);
            this.cdvKey6.MaxLength = 20;
            this.cdvKey6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvKey6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvKey6.Name = "cdvKey6";
            this.cdvKey6.ReadOnly = false;
            this.cdvKey6.SearchSubItemIndex = 0;
            this.cdvKey6.SelectedDescIndex = -1;
            this.cdvKey6.SelectedSubItemIndex = -1;
            this.cdvKey6.SelectionStart = 0;
            this.cdvKey6.Size = new System.Drawing.Size(189, 20);
            this.cdvKey6.SmallImageList = null;
            this.cdvKey6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvKey6.TabIndex = 15;
            this.cdvKey6.TextBoxToolTipText = "";
            this.cdvKey6.TextBoxWidth = 189;
            this.cdvKey6.Visible = false;
            this.cdvKey6.VisibleButton = true;
            this.cdvKey6.VisibleColumnHeader = false;
            this.cdvKey6.VisibleDescription = false;
            this.cdvKey6.ButtonPress += new System.EventHandler(this.cdvSheetKey_ButtonPress);
            // 
            // lblKey6
            // 
            this.lblKey6.AutoSize = true;
            this.lblKey6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKey6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey6.Location = new System.Drawing.Point(397, 61);
            this.lblKey6.Name = "lblKey6";
            this.lblKey6.Size = new System.Drawing.Size(68, 13);
            this.lblKey6.TabIndex = 14;
            this.lblKey6.Text = "Check Key";
            this.lblKey6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKey6.Visible = false;
            // 
            // cdvKey5
            // 
            this.cdvKey5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvKey5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvKey5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvKey5.BtnToolTipText = "";
            this.cdvKey5.DescText = "";
            this.cdvKey5.DisplaySubItemIndex = -1;
            this.cdvKey5.DisplayText = "";
            this.cdvKey5.Focusing = null;
            this.cdvKey5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvKey5.Index = 0;
            this.cdvKey5.IsViewBtnImage = false;
            this.cdvKey5.Location = new System.Drawing.Point(127, 58);
            this.cdvKey5.MaxLength = 20;
            this.cdvKey5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvKey5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvKey5.Name = "cdvKey5";
            this.cdvKey5.ReadOnly = false;
            this.cdvKey5.SearchSubItemIndex = 0;
            this.cdvKey5.SelectedDescIndex = -1;
            this.cdvKey5.SelectedSubItemIndex = -1;
            this.cdvKey5.SelectionStart = 0;
            this.cdvKey5.Size = new System.Drawing.Size(189, 20);
            this.cdvKey5.SmallImageList = null;
            this.cdvKey5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvKey5.TabIndex = 5;
            this.cdvKey5.TextBoxToolTipText = "";
            this.cdvKey5.TextBoxWidth = 189;
            this.cdvKey5.Visible = false;
            this.cdvKey5.VisibleButton = true;
            this.cdvKey5.VisibleColumnHeader = false;
            this.cdvKey5.VisibleDescription = false;
            this.cdvKey5.ButtonPress += new System.EventHandler(this.cdvSheetKey_ButtonPress);
            // 
            // lblKey5
            // 
            this.lblKey5.AutoSize = true;
            this.lblKey5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKey5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey5.Location = new System.Drawing.Point(16, 61);
            this.lblKey5.Name = "lblKey5";
            this.lblKey5.Size = new System.Drawing.Size(68, 13);
            this.lblKey5.TabIndex = 4;
            this.lblKey5.Text = "Check Key";
            this.lblKey5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKey5.Visible = false;
            // 
            // cdvKey4
            // 
            this.cdvKey4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvKey4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvKey4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvKey4.BtnToolTipText = "";
            this.cdvKey4.DescText = "";
            this.cdvKey4.DisplaySubItemIndex = -1;
            this.cdvKey4.DisplayText = "";
            this.cdvKey4.Focusing = null;
            this.cdvKey4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvKey4.Index = 0;
            this.cdvKey4.IsViewBtnImage = false;
            this.cdvKey4.Location = new System.Drawing.Point(508, 35);
            this.cdvKey4.MaxLength = 20;
            this.cdvKey4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvKey4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvKey4.Name = "cdvKey4";
            this.cdvKey4.ReadOnly = false;
            this.cdvKey4.SearchSubItemIndex = 0;
            this.cdvKey4.SelectedDescIndex = -1;
            this.cdvKey4.SelectedSubItemIndex = -1;
            this.cdvKey4.SelectionStart = 0;
            this.cdvKey4.Size = new System.Drawing.Size(189, 20);
            this.cdvKey4.SmallImageList = null;
            this.cdvKey4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvKey4.TabIndex = 13;
            this.cdvKey4.TextBoxToolTipText = "";
            this.cdvKey4.TextBoxWidth = 189;
            this.cdvKey4.Visible = false;
            this.cdvKey4.VisibleButton = true;
            this.cdvKey4.VisibleColumnHeader = false;
            this.cdvKey4.VisibleDescription = false;
            this.cdvKey4.ButtonPress += new System.EventHandler(this.cdvSheetKey_ButtonPress);
            // 
            // lblKey4
            // 
            this.lblKey4.AutoSize = true;
            this.lblKey4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKey4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey4.Location = new System.Drawing.Point(397, 38);
            this.lblKey4.Name = "lblKey4";
            this.lblKey4.Size = new System.Drawing.Size(68, 13);
            this.lblKey4.TabIndex = 12;
            this.lblKey4.Text = "Check Key";
            this.lblKey4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKey4.Visible = false;
            // 
            // cdvKey3
            // 
            this.cdvKey3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvKey3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvKey3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvKey3.BtnToolTipText = "";
            this.cdvKey3.DescText = "";
            this.cdvKey3.DisplaySubItemIndex = -1;
            this.cdvKey3.DisplayText = "";
            this.cdvKey3.Focusing = null;
            this.cdvKey3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvKey3.Index = 0;
            this.cdvKey3.IsViewBtnImage = false;
            this.cdvKey3.Location = new System.Drawing.Point(127, 35);
            this.cdvKey3.MaxLength = 20;
            this.cdvKey3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvKey3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvKey3.Name = "cdvKey3";
            this.cdvKey3.ReadOnly = false;
            this.cdvKey3.SearchSubItemIndex = 0;
            this.cdvKey3.SelectedDescIndex = -1;
            this.cdvKey3.SelectedSubItemIndex = -1;
            this.cdvKey3.SelectionStart = 0;
            this.cdvKey3.Size = new System.Drawing.Size(189, 20);
            this.cdvKey3.SmallImageList = null;
            this.cdvKey3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvKey3.TabIndex = 3;
            this.cdvKey3.TextBoxToolTipText = "";
            this.cdvKey3.TextBoxWidth = 189;
            this.cdvKey3.Visible = false;
            this.cdvKey3.VisibleButton = true;
            this.cdvKey3.VisibleColumnHeader = false;
            this.cdvKey3.VisibleDescription = false;
            this.cdvKey3.ButtonPress += new System.EventHandler(this.cdvSheetKey_ButtonPress);
            // 
            // lblKey3
            // 
            this.lblKey3.AutoSize = true;
            this.lblKey3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKey3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey3.Location = new System.Drawing.Point(16, 38);
            this.lblKey3.Name = "lblKey3";
            this.lblKey3.Size = new System.Drawing.Size(68, 13);
            this.lblKey3.TabIndex = 2;
            this.lblKey3.Text = "Check Key";
            this.lblKey3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKey3.Visible = false;
            // 
            // cdvKey2
            // 
            this.cdvKey2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvKey2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvKey2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvKey2.BtnToolTipText = "";
            this.cdvKey2.DescText = "";
            this.cdvKey2.DisplaySubItemIndex = -1;
            this.cdvKey2.DisplayText = "";
            this.cdvKey2.Focusing = null;
            this.cdvKey2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvKey2.Index = 0;
            this.cdvKey2.IsViewBtnImage = false;
            this.cdvKey2.Location = new System.Drawing.Point(508, 12);
            this.cdvKey2.MaxLength = 20;
            this.cdvKey2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvKey2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvKey2.Name = "cdvKey2";
            this.cdvKey2.ReadOnly = false;
            this.cdvKey2.SearchSubItemIndex = 0;
            this.cdvKey2.SelectedDescIndex = -1;
            this.cdvKey2.SelectedSubItemIndex = -1;
            this.cdvKey2.SelectionStart = 0;
            this.cdvKey2.Size = new System.Drawing.Size(189, 20);
            this.cdvKey2.SmallImageList = null;
            this.cdvKey2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvKey2.TabIndex = 11;
            this.cdvKey2.TextBoxToolTipText = "";
            this.cdvKey2.TextBoxWidth = 189;
            this.cdvKey2.Visible = false;
            this.cdvKey2.VisibleButton = true;
            this.cdvKey2.VisibleColumnHeader = false;
            this.cdvKey2.VisibleDescription = false;
            this.cdvKey2.ButtonPress += new System.EventHandler(this.cdvSheetKey_ButtonPress);
            // 
            // lblKey2
            // 
            this.lblKey2.AutoSize = true;
            this.lblKey2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKey2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey2.Location = new System.Drawing.Point(397, 15);
            this.lblKey2.Name = "lblKey2";
            this.lblKey2.Size = new System.Drawing.Size(68, 13);
            this.lblKey2.TabIndex = 10;
            this.lblKey2.Text = "Check Key";
            this.lblKey2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKey2.Visible = false;
            // 
            // cdvKey1
            // 
            this.cdvKey1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvKey1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvKey1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvKey1.BtnToolTipText = "";
            this.cdvKey1.DescText = "";
            this.cdvKey1.DisplaySubItemIndex = -1;
            this.cdvKey1.DisplayText = "";
            this.cdvKey1.Focusing = null;
            this.cdvKey1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvKey1.Index = 0;
            this.cdvKey1.IsViewBtnImage = false;
            this.cdvKey1.Location = new System.Drawing.Point(127, 12);
            this.cdvKey1.MaxLength = 20;
            this.cdvKey1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvKey1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvKey1.Name = "cdvKey1";
            this.cdvKey1.ReadOnly = false;
            this.cdvKey1.SearchSubItemIndex = 0;
            this.cdvKey1.SelectedDescIndex = -1;
            this.cdvKey1.SelectedSubItemIndex = -1;
            this.cdvKey1.SelectionStart = 0;
            this.cdvKey1.Size = new System.Drawing.Size(189, 20);
            this.cdvKey1.SmallImageList = null;
            this.cdvKey1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvKey1.TabIndex = 1;
            this.cdvKey1.TextBoxToolTipText = "";
            this.cdvKey1.TextBoxWidth = 189;
            this.cdvKey1.Visible = false;
            this.cdvKey1.VisibleButton = true;
            this.cdvKey1.VisibleColumnHeader = false;
            this.cdvKey1.VisibleDescription = false;
            this.cdvKey1.ButtonPress += new System.EventHandler(this.cdvSheetKey_ButtonPress);
            // 
            // lblKey1
            // 
            this.lblKey1.AutoSize = true;
            this.lblKey1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKey1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey1.Location = new System.Drawing.Point(16, 15);
            this.lblKey1.Name = "lblKey1";
            this.lblKey1.Size = new System.Drawing.Size(68, 13);
            this.lblKey1.TabIndex = 0;
            this.lblKey1.Text = "Check Key";
            this.lblKey1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKey1.Visible = false;
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnView.Location = new System.Drawing.Point(466, 7);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // cdvTableData
            // 
            this.cdvTableData.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvTableData.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableData.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTableData.Location = new System.Drawing.Point(189, 17);
            this.cdvTableData.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableData.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableData.Name = "cdvTableData";
            this.cdvTableData.Size = new System.Drawing.Size(20, 20);
            this.cdvTableData.SmallImageList = null;
            this.cdvTableData.TabIndex = 0;
            this.cdvTableData.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvTableData.VisibleColumnHeader = false;
            this.cdvTableData.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvTableData_SelectedItemChanged);
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(12, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 6;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // chkCompleteFlag
            // 
            this.chkCompleteFlag.AutoSize = true;
            this.chkCompleteFlag.Location = new System.Drawing.Point(53, 13);
            this.chkCompleteFlag.Name = "chkCompleteFlag";
            this.chkCompleteFlag.Size = new System.Drawing.Size(93, 17);
            this.chkCompleteFlag.TabIndex = 7;
            this.chkCompleteFlag.Text = "Complete Flag";
            this.chkCompleteFlag.UseVisualStyleBackColor = true;
            // 
            // frmRASTranMakeCheckResult
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRASTranMakeCheckResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Make Check Result";
            this.Activated += new System.EventHandler(this.frmRASTranMakeSheet_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpSheetName.ResumeLayout(false);
            this.grpSheetName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSheetName)).EndInit();
            this.pnlAttrInfo.ResumeLayout(false);
            this.grpSheetData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdSheetData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSheetData_Sheet1)).EndInit();
            this.grpKey.ResumeLayout(false);
            this.grpKey.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableData)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const int MAX_VALUE_COUNT = 500;
        
        #endregion
        
        #region "VariableDefinition"

        private string sTranTime = null;
        private bool b_call_flag = false;
        private bool b_update_flag = false;
        private string SheetName = null;
        private string DataType = null;
        private string SheetKey1 = null;
        private string SheetKey2 = null;
        private string SheetKey3 = null;
        private string SheetKey4 = null;
        private string SheetKey5 = null;
        private string SheetKey6 = null;
        private string SheetKey7 = null;
        private string SheetKey8 = null;
        private string SheetKey9 = null;
        private string SheetKey10 = null;

        private TRSNode make_sheet = null;

        private bool b_load_flag;
        
        #endregion
        
        #region " Function Definition "

        public void SetDataSheet(string sSheetName, string sDataType,
                         string sSheetKey1, string sSheetKey2, string sSheetKey3, string sSheetKey4, string sSheetKey5,
                         string sSheetKey6, string sSheetKey7, string sSheetKey8, string sSheetKey9, string sSheetKey10,
                         string ssTranTime, bool b_scall_flag, bool b_supdate_flag)
        {
            SetDataSheet(sSheetName, sDataType, 
                                 sSheetKey1, sSheetKey2, sSheetKey3, sSheetKey4, sSheetKey5, 
                                 sSheetKey6, sSheetKey7, sSheetKey8, sSheetKey9, sSheetKey10,
                                 ssTranTime, b_scall_flag, b_supdate_flag, ref make_sheet);
            return;
        }

        public void SetDataSheet(string sSheetName, string sDataType, 
                                 string sSheetKey1, string sSheetKey2, string sSheetKey3, string sSheetKey4, string sSheetKey5, 
                                 string sSheetKey6, string sSheetKey7, string sSheetKey8, string sSheetKey9, string sSheetKey10,
                                 string ssTranTime, bool b_scall_flag, bool b_supdate_flag, ref TRSNode in_make_sheet)
        {
            sTranTime = ssTranTime;
            b_call_flag = b_scall_flag;
            b_update_flag = b_supdate_flag;

            if (MPCF.Trim(sSheetName) != "")
                cdvSheetName.Enabled = false;
            if (MPCF.Trim(sDataType) != "")
                cdvDataType.Enabled = false;
            if (MPCF.Trim(sSheetKey1) != "")
                cdvKey1.Enabled = false;
            if (MPCF.Trim(sSheetKey2) != "")
                cdvKey2.Enabled = false;
            if (MPCF.Trim(sSheetKey3) != "")
                cdvKey3.Enabled = false;
            if (MPCF.Trim(sSheetKey4) != "")
                cdvKey4.Enabled = false;
            if (MPCF.Trim(sSheetKey5) != "")
                cdvKey5.Enabled = false;
            if (MPCF.Trim(sSheetKey6) != "")
                cdvKey6.Enabled = false;
            if (MPCF.Trim(sSheetKey7) != "")
                cdvKey7.Enabled = false;
            if (MPCF.Trim(sSheetKey8) != "")
                cdvKey8.Enabled = false;
            if (MPCF.Trim(sSheetKey9) != "")
                cdvKey9.Enabled = false;
            if (MPCF.Trim(sSheetKey10) != "")
                cdvKey10.Enabled = false;

            SheetName = sSheetName;
            DataType = sDataType;
            SheetKey1 = sSheetKey1;
            SheetKey2 = sSheetKey2;
            SheetKey3 = sSheetKey3;
            SheetKey4 = sSheetKey4;
            SheetKey5 = sSheetKey5;
            SheetKey6 = sSheetKey6;
            SheetKey7 = sSheetKey7;
            SheetKey8 = sSheetKey8;
            SheetKey9 = sSheetKey9;
            SheetKey10 = sSheetKey10;
            make_sheet = in_make_sheet;
        }

        // ViewSheet()
        //       - View PM Sheet
        // Return Value
        //       - boolean : True / False
        private bool ViewSheet()
        {
            int i, i_row;
            FarPoint.Win.Spread.CellType.TextCellType txtCell;
            FarPoint.Win.Spread.CellType.NumberCellType numCell;
            FarPoint.Win.Spread.CellType.ButtonCellType btnCell;

            TRSNode in_node = new TRSNode("VIEW_SHEET_IN");
            TRSNode out_node = new TRSNode("VIEW_SHEET_OUT");


            MPCF.ClearList(spdSheetData, true);
            chkCompleteFlag.Checked = false;
            MPCR.SetInMsg(in_node);

            if(b_update_flag == false)
                in_node.ProcStep = '1';
            else
                in_node.ProcStep = '2';
            
            in_node.AddString("SHEET_NAME", cdvSheetName.Text);
            in_node.AddString("DATA_TYPE", cdvDataType.Text);
            if (cdvKey1.Visible == true)
                in_node.AddString("SHEET_KEY_1", cdvKey1.Text);
            if (cdvKey2.Visible == true)
                in_node.AddString("SHEET_KEY_2", cdvKey2.Text);
            if (cdvKey3.Visible == true)
                in_node.AddString("SHEET_KEY_3", cdvKey3.Text);
            if (cdvKey4.Visible == true)
                in_node.AddString("SHEET_KEY_4", cdvKey4.Text);
            if (cdvKey5.Visible == true)
                in_node.AddString("SHEET_KEY_5", cdvKey5.Text);
            if (cdvKey6.Visible == true)
                in_node.AddString("SHEET_KEY_6", cdvKey6.Text);
            if (cdvKey7.Visible == true)
                in_node.AddString("SHEET_KEY_7", cdvKey7.Text);
            if (cdvKey8.Visible == true)
                in_node.AddString("SHEET_KEY_8", cdvKey8.Text);
            if (cdvKey9.Visible == true)
                in_node.AddString("SHEET_KEY_9", cdvKey9.Text);
            if (cdvKey10.Visible == true)
                in_node.AddString("SHEET_KEY_10", cdvKey10.Text);
            in_node.AddInt("NEXT_SEQ", 0);

            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Sheet_Result", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    i_row = spdSheetData.Sheets[0].RowCount;
                    spdSheetData.Sheets[0].RowCount++;

                    spdSheetData.Sheets[0].Cells[i_row, 0].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("DATA_CODE"));
                    spdSheetData.Sheets[0].Cells[i_row, 1].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("SHEET_DATA"));
                    spdSheetData.Sheets[0].Cells[i_row, 1].Tag = MPCF.Trim(out_node.GetList(0)[i].GetChar("RESULT_TYPE"));
                    spdSheetData.Sheets[0].Cells[i_row, 2].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("RESULT_VALUE"));
                    spdSheetData.Sheets[0].Cells[i_row, 2].Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("CHECK_VALUE"));
                    spdSheetData.Sheets[0].Cells[i_row, 4].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("SHEET_COMMENT"));

                    switch (out_node.GetList(0)[i].GetChar("RESULT_TYPE"))
                    {
                        case 'A':
                            txtCell = new FarPoint.Win.Spread.CellType.TextCellType();
                            txtCell.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Ascii;
                            txtCell.WordWrap = true;

                            spdSheetData.Sheets[0].Cells[i_row, 2].CellType = txtCell;
                            break;
                        case 'N':
                            numCell = new FarPoint.Win.Spread.CellType.NumberCellType();

                            spdSheetData.Sheets[0].Cells[i_row, 2].CellType = numCell;
                            break;
                    }

                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("CHECK_VALUE")) == "")
                    {
                        spdSheetData.Sheets[0].AddSpanCell(i_row, 2, 1, 2);
                    }
                    else
                    {
                        btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        btnCell.Text = "...";
                        spdSheetData.Sheets[0].Cells[i_row, 3].CellType = btnCell;
                        spdSheetData.Sheets[0].Cells[i_row, 3].Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("CHECK_VALUE"));
                    }

                    spdSheetData.Sheets[0].Rows[i_row].Height = spdSheetData.Sheets[0].GetPreferredRowHeight(i_row);
                }

                in_node.SetInt("NEXT_SEQ", in_node.GetInt("NEXT_SEQ"));

            } while (in_node.GetInt("NEXT_SEQ") > 0);

            sTranTime = out_node.GetString("TRAN_TIME");
            return true;

        }

        
        //
        // UpdatePMSheet()
        //       - Change PM Sheet
        // Return Value
        //       - boolean : True / False
        // Arguments
        //
        private bool UpdatePMSheet()
        {
            int i;
            TRSNode list_item;

            if (b_call_flag == true && b_update_flag == false)
            {

                MPCR.SetInMsg(make_sheet);
                make_sheet.ProcStep = MPGC.MP_STEP_CREATE;
                make_sheet.AddString("SHEET_NAME", cdvSheetName.Text);
                make_sheet.AddString("SHEET_KEY_1", cdvKey1.Text);
                make_sheet.AddString("SHEET_KEY_2", cdvKey2.Text);
                make_sheet.AddString("SHEET_KEY_3", cdvKey3.Text);
                make_sheet.AddString("SHEET_KEY_4", cdvKey4.Text);
                make_sheet.AddString("SHEET_KEY_5", cdvKey5.Text);
                make_sheet.AddString("SHEET_KEY_6", cdvKey6.Text);
                make_sheet.AddString("SHEET_KEY_7", cdvKey7.Text);
                make_sheet.AddString("SHEET_KEY_8", cdvKey8.Text);
                make_sheet.AddString("SHEET_KEY_9", cdvKey9.Text);
                make_sheet.AddString("SHEET_KEY_10", cdvKey10.Text);
                make_sheet.AddString("DATA_TYPE", cdvDataType.Text);
                make_sheet.AddString("TRAN_TIME", sTranTime);
                make_sheet.AddChar("COMPLETE_FLAG", chkCompleteFlag.Checked == true ? 'Y' : ' ');

                for (i = 0; i < spdSheetData.Sheets[0].RowCount; i++)
                {
                    list_item = make_sheet.AddNode("DATA_LIST");

                    list_item.AddInt("DATA_SEQ", i + 1);
                    list_item.AddString("DATA_CODE", MPCF.Trim(spdSheetData.Sheets[0].Cells[i, 0].Text));
                    list_item.AddString("RESULT_VALUE", MPCF.Trim(spdSheetData.Sheets[0].Cells[i, 2].Text));
                    list_item.AddString("SHEET_COMMENT", MPCF.Trim(spdSheetData.Sheets[0].Cells[i, 4].Text));
                }
            }
            else
            {
                TRSNode in_node = new TRSNode("MAKE_SHEET_RESULT_IN");
                TRSNode out_node = new TRSNode("CMN_OUT");

                try
                {
                    MPCR.SetInMsg(in_node);
                    if (b_update_flag == false)
                        in_node.ProcStep = MPGC.MP_STEP_CREATE;
                    else
                        in_node.ProcStep = MPGC.MP_STEP_UPDATE;

                    in_node.AddString("SHEET_NAME", cdvSheetName.Text);
                    in_node.AddString("SHEET_KEY_1", cdvKey1.Text);
                    in_node.AddString("SHEET_KEY_2", cdvKey2.Text);
                    in_node.AddString("SHEET_KEY_3", cdvKey3.Text);
                    in_node.AddString("SHEET_KEY_4", cdvKey4.Text);
                    in_node.AddString("SHEET_KEY_5", cdvKey5.Text);
                    in_node.AddString("SHEET_KEY_6", cdvKey6.Text);
                    in_node.AddString("SHEET_KEY_7", cdvKey7.Text);
                    in_node.AddString("SHEET_KEY_8", cdvKey8.Text);
                    in_node.AddString("SHEET_KEY_9", cdvKey9.Text);
                    in_node.AddString("SHEET_KEY_10", cdvKey10.Text);
                    in_node.AddString("DATA_TYPE", cdvDataType.Text);
                    in_node.AddString("TRAN_TIME", sTranTime);
                    in_node.AddChar("COMPLETE_FLAG", chkCompleteFlag.Checked == true ? 'Y' : ' ');

                    for (i = 0; i < spdSheetData.Sheets[0].RowCount; i++)
                    {
                        list_item = in_node.AddNode("DATA_LIST");

                        list_item.AddInt("DATA_SEQ", i + 1);
                        list_item.AddString("DATA_CODE", MPCF.Trim(spdSheetData.Sheets[0].Cells[i, 0].Text));
                        list_item.AddString("RESULT_VALUE", MPCF.Trim(spdSheetData.Sheets[0].Cells[i, 2].Text));
                        list_item.AddString("SHEET_COMMENT", MPCF.Trim(spdSheetData.Sheets[0].Cells[i, 4].Text));
                    }
                    if (MPCR.CallService("RAS", "RAS_Make_Sheet_Result", in_node, ref out_node) == false)
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
            }

            // 장비 PM Event와 연계 하여 동시에 발생 하여야 함
            return true;
        }
        
        // CheckCondition()
        //       - check Create/Update/Delete condition
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String      : Function Name
        //       - Optional ByVal ProcStep As String        : Create/Update/Delete 援щ텇??
        //
        private bool CheckCondition(char ProcStep)
        {
            if (MPCF.CheckValue(cdvSheetName, 1) == false)
            {
                return false;
            }

            if (MPCF.CheckValue(cdvDataType, 1) == false)
            {
                return false;
            }

            if (cdvKey1.Visible == true)
            {
                if (MPCF.CheckValue(cdvKey1, 1) == false)
                {
                    return false;
                }
            }
            if (cdvKey2.Visible == true)
            {
                if (MPCF.CheckValue(cdvKey2, 1) == false)
                {
                    return false;
                }
            }
            if (cdvKey3.Visible == true)
            {
                if (MPCF.CheckValue(cdvKey3, 1) == false)
                {
                    return false;
                }
            }
            if (cdvKey4.Visible == true)
            {
                if (MPCF.CheckValue(cdvKey4, 1) == false)
                {
                    return false;
                }
            }
            if (cdvKey5.Visible == true)
            {
                if (MPCF.CheckValue(cdvKey5, 1) == false)
                {
                    return false;
                }
            }
            if (cdvKey6.Visible == true)
            {
                if (MPCF.CheckValue(cdvKey6, 1) == false)
                {
                    return false;
                }
            }
            if (cdvKey7.Visible == true)
            {
                if (MPCF.CheckValue(cdvKey7, 1) == false)
                {
                    return false;
                }
            }
            if (cdvKey8.Visible == true)
            {
                if (MPCF.CheckValue(cdvKey8, 1) == false)
                {
                    return false;
                }
            }
            if (cdvKey9.Visible == true)
            {
                if (MPCF.CheckValue(cdvKey9, 1) == false)
                {
                    return false;
                }
            }
            if (cdvKey10.Visible == true)
            {
                if (MPCF.CheckValue(cdvKey10, 1) == false)
                {
                    return false;
                }
            }

            return true;
        }

        //
        // View_Sheet_Group()
        //       - View Sheet Group
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal Sheet_Type As String
        //
        private bool View_Sheet_Group(string Sheet_Type)
        {
            int i = 0;

            lblKey1.Visible = false;
            lblKey2.Visible = false;
            lblKey3.Visible = false;
            lblKey4.Visible = false;
            lblKey5.Visible = false;
            lblKey6.Visible = false;
            lblKey7.Visible = false;
            lblKey8.Visible = false;
            lblKey9.Visible = false;
            lblKey10.Visible = false;

            cdvKey1.Visible = false;
            cdvKey2.Visible = false;
            cdvKey3.Visible = false;
            cdvKey4.Visible = false;
            cdvKey5.Visible = false;
            cdvKey6.Visible = false;
            cdvKey7.Visible = false;
            cdvKey8.Visible = false;
            cdvKey9.Visible = false;
            cdvKey10.Visible = false;

            cdvKey1.VisibleButton = false;
            cdvKey2.VisibleButton = false;
            cdvKey3.VisibleButton = false;
            cdvKey4.VisibleButton = false;
            cdvKey5.VisibleButton = false;
            cdvKey6.VisibleButton = false;
            cdvKey7.VisibleButton = false;
            cdvKey8.VisibleButton = false;
            cdvKey9.VisibleButton = false;
            cdvKey10.VisibleButton = false;

            cdvKey1.Text = "";
            cdvKey2.Text = "";
            cdvKey3.Text = "";
            cdvKey4.Text = "";
            cdvKey5.Text = "";
            cdvKey6.Text = "";
            cdvKey7.Text = "";
            cdvKey8.Text = "";
            cdvKey9.Text = "";
            cdvKey10.Text = "";

            grpKey.Height = 41;
            grpKey.Visible = false;

            if (MPCF.Trim(Sheet_Type) == "")
            {
                return true;
            }

            try
            {
                TRSNode in_node = new TRSNode("VIEW_SHEET_TYPE_DEF_IN");
                TRSNode out_node = new TRSNode("VIEW_SHEET_TYPE_DEF_OUT");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SHEET_TYPE", Sheet_Type);
                in_node.AddChar("TYPE_FLAG", 'D');

                if (MPCR.CallService("RAS", "RAS_View_Sheet_Type_Def", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetList(0).Count > 0)
                {
                    grpKey.Visible = true;

                    switch ((int)((out_node.GetList(0).Count + 1) / 2))
                    {
                        case 1:
                            grpKey.Height = 39;
                            break;

                        case 2:
                            grpKey.Height = 62;
                            break;

                        case 3:
                            grpKey.Height = 85;
                            break;

                        case 4:
                            grpKey.Height = 108;
                            break;

                        case 5:
                            grpKey.Height = 131;
                            break;
                    }
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            lblKey1.Visible = true;
                            lblKey1.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_CAPTION"));
                            cdvKey1.Visible = true;

                            if (cdvKey1.Visible == true)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE")) != "")
                                {
                                    cdvKey1.VisibleButton = true;
                                    cdvKey1.Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE"));
                                }
                            }
                            break;
                        case 1:
                            lblKey2.Visible = true;
                            lblKey2.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_CAPTION"));
                            cdvKey2.Visible = true;

                            if (cdvKey2.Visible == true)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE")) != "")
                                {
                                    cdvKey2.VisibleButton = true;
                                    cdvKey2.Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE"));
                                }
                            }
                            break;
                        case 2:
                            lblKey3.Visible = true;
                            lblKey3.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_CAPTION"));
                            cdvKey3.Visible = true;

                            if (cdvKey3.Visible == true)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE")) != "")
                                {
                                    cdvKey3.VisibleButton = true;
                                    cdvKey3.Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE"));
                                }
                            }
                            break;
                        case 3:
                            lblKey4.Visible = true;
                            lblKey4.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_CAPTION"));
                            cdvKey4.Visible = true;

                            if (cdvKey4.Visible == true)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE")) != "")
                                {
                                    cdvKey4.VisibleButton = true;
                                    cdvKey4.Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE"));
                                }
                            }
                            break;
                        case 4:
                            lblKey5.Visible = true;
                            lblKey5.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_CAPTION"));
                            cdvKey5.Visible = true;

                            if (cdvKey5.Visible == true)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE")) != "")
                                {
                                    cdvKey5.VisibleButton = true;
                                    cdvKey5.Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE"));
                                }
                            }
                            break;
                        case 5:
                            lblKey6.Visible = true;
                            lblKey6.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_CAPTION"));
                            cdvKey6.Visible = true;

                            if (cdvKey6.Visible == true)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE")) != "")
                                {
                                    cdvKey6.VisibleButton = true;
                                    cdvKey6.Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE"));
                                }
                            }
                            break;
                        case 6:
                            lblKey7.Visible = true;
                            lblKey7.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_CAPTION"));
                            cdvKey7.Visible = true;

                            if (cdvKey7.Visible == true)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE")) != "")
                                {
                                    cdvKey7.VisibleButton = true;
                                    cdvKey7.Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE"));
                                }
                            }
                            break;
                        case 7:
                            lblKey8.Visible = true;
                            lblKey8.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_CAPTION"));
                            cdvKey8.Visible = true;

                            if (cdvKey8.Visible == true)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE")) != "")
                                {
                                    cdvKey8.VisibleButton = true;
                                    cdvKey8.Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE"));
                                }
                            }
                            break;
                        case 8:
                            lblKey9.Visible = true;
                            lblKey9.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_CAPTION"));
                            cdvKey9.Visible = true;

                            if (cdvKey9.Visible == true)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE")) != "")
                                {
                                    cdvKey9.VisibleButton = true;
                                    cdvKey9.Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE"));
                                }
                            }
                            break;
                        case 9:
                            lblKey10.Visible = true;
                            lblKey10.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_CAPTION"));
                            cdvKey10.Visible = true;

                            if (cdvKey10.Visible == true)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE")) != "")
                                {
                                    cdvKey10.VisibleButton = true;
                                    cdvKey10.Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_TABLE"));
                                }
                            }
                            break;
                    }

                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmRASTranMakeSheet.View_Sheet_Group()\n" + ex.Message);
                return false;
            }
        }

        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.cdvSheetName;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }
        
        #endregion
        
        private void frmRASTranMakeSheet_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                /* 2013.06.12. Aiden. View_Sheet_Group() 에서 에러 발생시 계속 Activate 를 호출하는 문제 해결 */
                b_load_flag = true;

                MPCF.ClearList(spdSheetData, true);

                if (DataType != "")
                {
                    if (View_Sheet_Group(DataType) == false)
                        return;
                }

                cdvSheetName.Text = SheetName;
                cdvDataType.Text = DataType;
                cdvKey1.Text = SheetKey1;
                cdvKey2.Text = SheetKey2;
                cdvKey3.Text = SheetKey3;
                cdvKey4.Text = SheetKey4;
                cdvKey5.Text = SheetKey5;
                cdvKey6.Text = SheetKey6;
                cdvKey7.Text = SheetKey7;
                cdvKey8.Text = SheetKey8;
                cdvKey9.Text = SheetKey9;
                cdvKey10.Text = SheetKey10;

                if(b_update_flag == true)
                    ViewSheet();

            }
        }
        
        private void cdvTableData_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            spdSheetData.Sheets[0].Cells[e.Row, 2].Value = MPCF.Trim(e.SelectedItem.Text);
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition('V') == false)
                return;
            
            ViewSheet();
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            if (b_update_flag == false)
            {
                if (CheckCondition(MPGC.MP_STEP_CREATE) == false)
                    return;
            }
            else
            {
                if (CheckCondition(MPGC.MP_STEP_UPDATE) == false)
                    return;
            }
            
            if(UpdatePMSheet() == false)
                return;

            if (b_call_flag == true && b_update_flag == false)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                btnView.PerformClick();
            }
        }

        private void cdvSheetName_ButtonPress(object sender, EventArgs e)
        {
            //Add by J.S. 2012.01.16 리스트뷰 정의가 누락됨
            cdvSheetName.Init();
            MPCF.InitListView(cdvSheetName.GetListView);
            cdvSheetName.Columns.Add("Sheet Name", 50, HorizontalAlignment.Left);
            cdvSheetName.Columns.Add("Sheet Desc", 50, HorizontalAlignment.Left);

            if (RASLIST.ViewSheetList(cdvSheetName.GetListView, '1', cdvSheetType.Text) == false)
            {
                return;
            }
        }

        private void cdvSheetName_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            // Add by ICBAE 2012.06.14
            // View에 필요한 키가 변경됨. SheetName 하나로 처리할 수 없음
            //spdSheetData.Sheets[0].ClearRange(0, 0, spdSheetData.Sheets[0].RowCount, spdSheetData.Sheets[0].ColumnCount, false);
            ////Add by J.S. 2012.01.16 리스트뷰 정의가 누락됨
            //txtSheetDesc.Text = cdvSheetName.SelectedItem.SubItems[1].Text;

            //if(MPCF.Trim(cdvSheetName.Text) != "" && MPCF.Trim(cdvDataType.Text) != "")
            //    ViewSheet();
        }

        private void spdSheetData_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                cdvTableData.Init();
                cdvTableData.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvTableData.GetListView);
                cdvTableData.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
                cdvTableData.Columns.Add("Table Desc", 50, HorizontalAlignment.Left);
                BASLIST.ViewGCMDataList(cdvTableData.GetListView, '1', MPCF.Trim(spdSheetData.Sheets[0].Cells[e.Row, e.Column].Tag));

                if (cdvTableData.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvSheetType_ButtonPress(object sender, EventArgs e)
        {
            cdvSheetType.Init();
            MPCF.InitListView(cdvSheetType.GetListView);
            cdvSheetType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvSheetType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvSheetType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvSheetType.GetListView, '1', MPGC.MP_SHEET_SHEET_TYPE);
        }

        private void cdvSheetType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvSheetName.Text = "";
            txtSheetDesc.Text = "";

            spdSheetData.Sheets[0].ClearRange(0, 0, spdSheetData.Sheets[0].RowCount, spdSheetData.Sheets[0].ColumnCount, false);
        }

        private void cdvDataType_ButtonPress(object sender, EventArgs e)
        {
            cdvDataType.Init();
            MPCF.InitListView(cdvDataType.GetListView);
            cdvDataType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvDataType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvDataType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvDataType.GetListView, '1', MPGC.MP_SHEET_DATA_TYPE);
        }

        private void cdvDataType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvDataType.Text) != "")
            {
                View_Sheet_Group(MPCF.Trim(cdvDataType.Text));

                //Add by J.S. 2012.01.16
                cdvKey1.Text = SheetKey1;
                cdvKey2.Text = SheetKey2;
                cdvKey3.Text = SheetKey3;
                cdvKey4.Text = SheetKey4;
                cdvKey5.Text = SheetKey5;
                cdvKey6.Text = SheetKey6;
                cdvKey7.Text = SheetKey7;
                cdvKey8.Text = SheetKey8;
                cdvKey9.Text = SheetKey9;
                cdvKey10.Text = SheetKey10;
            }
        }

        private void cdvSheetKey_ButtonPress(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;

            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            if (MPCF.Trim(cdvTemp.Tag) == "") 
                return;

            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("Status", 50, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', MPCF.Trim(cdvTemp.Tag));
        }

        private void spdSheetData_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column != 2 && e.Column != 4) 
                return;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (b_call_flag == true && b_update_flag == false)
            {
                this.DialogResult = DialogResult.Cancel;
            }

            Close();
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Check Name : " + cdvSheetName.Text;

            if (MPCF.Trim(cdvDataType.Text) != "")
            {
                sCond += "\r" + "Check Data Type : " + cdvDataType.Text;
            }
            if (MPCF.Trim(lblKey1.Text) != "" && MPCF.Trim(lblKey1.Text) != "Check Key")
            {
                sCond += "\r" + lblKey1.Text + " : " + cdvKey1.Text;
            }
            if (MPCF.Trim(lblKey2.Text) != "" && MPCF.Trim(lblKey2.Text) != "Check Key")
            {
                sCond += "\r" + lblKey2.Text + " : " + cdvKey2.Text;
            }
            if (MPCF.Trim(lblKey3.Text) != "" && MPCF.Trim(lblKey3.Text) != "Check Key")
            {
                sCond += "\r" + lblKey3.Text + " : " + cdvKey3.Text;
            }
            if (MPCF.Trim(lblKey4.Text) != "" && MPCF.Trim(lblKey4.Text) != "Check Key")
            {
                sCond += "\r" + lblKey4.Text + " : " + cdvKey4.Text;
            }
            if (MPCF.Trim(lblKey5.Text) != "" && MPCF.Trim(lblKey5.Text) != "Check Key")
            {
                sCond += "\r" + lblKey5.Text + " : " + cdvKey5.Text;
            }
            if (MPCF.Trim(lblKey6.Text) != "" && MPCF.Trim(lblKey6.Text) != "Check Key")
            {
                sCond += "\r" + lblKey6.Text + " : " + cdvKey6.Text;
            }
            if (MPCF.Trim(lblKey7.Text) != "" && MPCF.Trim(lblKey7.Text) != "Check Key")
            {
                sCond += "\r" + lblKey7.Text + " : " + cdvKey7.Text;
            }
            if (MPCF.Trim(lblKey8.Text) != "" && MPCF.Trim(lblKey8.Text) != "Check Key")
            {
                sCond += "\r" + lblKey8.Text + " : " + cdvKey8.Text;
            }
            if (MPCF.Trim(lblKey9.Text) != "" && MPCF.Trim(lblKey9.Text) != "Check Key")
            {
                sCond += "\r" + lblKey9.Text + " : " + cdvKey9.Text;
            }
            if (MPCF.Trim(lblKey10.Text) != "" && MPCF.Trim(lblKey10.Text) != "Check Key")
            {
                sCond += "\r" + lblKey10.Text + " : " + cdvKey10.Text;
            }

            MPCF.ExportToExcel(spdSheetData, this.Text, sCond);
        }

    }
}
