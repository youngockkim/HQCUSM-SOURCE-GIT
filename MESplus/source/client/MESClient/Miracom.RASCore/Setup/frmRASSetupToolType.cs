
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

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASSetupToolType.vb
//   Description : Tool Type Definition Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - initCodeView : initial CodeView Control
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - View_Tool_Type() : View Tool Type definition
//       - Update_Tool_Type() : Create/Update/Delete Tool Type definition
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-07 : Created by Jerome
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _TOOL = True Then


namespace Miracom.RASCore
{
    public class frmRASSetupToolType : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASSetupToolType()
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
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.GroupBox grbTable;
        private System.Windows.Forms.Panel pnlRightBottom;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.TextBox txtToolType;
        private FarPoint.Win.Spread.FpSpread spdToolType;
        private FarPoint.Win.Spread.SheetView spdToolType_Sheet1;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvTableList;
        protected Button btnTolTypExcel;
        private Miracom.UI.Controls.MCListView.MCListView lisToolType;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType7 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType8 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType9 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType10 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType11 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType12 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType13 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType14 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType15 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType16 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType17 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType18 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType19 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType20 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType21 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType22 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType23 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType24 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType25 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType26 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType27 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType28 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType29 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType30 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.ComplexBorder complexBorder1 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.ComplexBorder complexBorder2 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType3 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType2 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRASSetupToolType));
            this.lisToolType = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbTable = new System.Windows.Forms.GroupBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtToolType = new System.Windows.Forms.TextBox();
            this.lblTable = new System.Windows.Forms.Label();
            this.pnlRightBottom = new System.Windows.Forms.Panel();
            this.spdToolType = new FarPoint.Win.Spread.FpSpread();
            this.spdToolType_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.cdvTableList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.btnTolTypExcel = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.spdToolType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdToolType_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.TabIndex = 1;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.TabIndex = 0;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlRightBottom);
            this.pnlRight.Controls.Add(this.grbTable);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisToolType);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
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
            this.pnlBottom.Controls.Add(this.btnTolTypExcel);
            this.pnlBottom.TabIndex = 0;
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.pnlFind, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnTolTypExcel, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Tool Type Setup";
            // 
            // lisToolType
            // 
            this.lisToolType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisToolType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisToolType.EnableSort = true;
            this.lisToolType.EnableSortIcon = true;
            this.lisToolType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisToolType.FullRowSelect = true;
            this.lisToolType.HideSelection = false;
            this.lisToolType.Location = new System.Drawing.Point(3, 3);
            this.lisToolType.MultiSelect = false;
            this.lisToolType.Name = "lisToolType";
            this.lisToolType.Size = new System.Drawing.Size(229, 500);
            this.lisToolType.TabIndex = 0;
            this.lisToolType.UseCompatibleStateImageBehavior = false;
            this.lisToolType.View = System.Windows.Forms.View.Details;
            this.lisToolType.SelectedIndexChanged += new System.EventHandler(this.lisToolType_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Tool Type";
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
            this.grbTable.Controls.Add(this.txtToolType);
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
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            // txtToolType
            // 
            this.txtToolType.Location = new System.Drawing.Point(120, 16);
            this.txtToolType.MaxLength = 20;
            this.txtToolType.Name = "txtToolType";
            this.txtToolType.Size = new System.Drawing.Size(200, 20);
            this.txtToolType.TabIndex = 1;
            this.txtToolType.TextChanged += new System.EventHandler(this.txtToolType_TextChanged);
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTable.Location = new System.Drawing.Point(15, 19);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(64, 13);
            this.lblTable.TabIndex = 0;
            this.lblTable.Text = "Tool Type";
            this.lblTable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlRightBottom
            // 
            this.pnlRightBottom.Controls.Add(this.spdToolType);
            this.pnlRightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightBottom.Location = new System.Drawing.Point(3, 71);
            this.pnlRightBottom.Name = "pnlRightBottom";
            this.pnlRightBottom.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlRightBottom.Size = new System.Drawing.Size(500, 432);
            this.pnlRightBottom.TabIndex = 1;
            // 
            // spdToolType
            // 
            this.spdToolType.AccessibleDescription = "spdToolType, Sheet1, Row 0, Column 0, ";
            this.spdToolType.BackColor = System.Drawing.SystemColors.Control;
            this.spdToolType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdToolType.EditModePermanent = true;
            this.spdToolType.EditModeReplace = true;
            this.spdToolType.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdToolType.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdToolType.HorizontalScrollBar.Name = "";
            this.spdToolType.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdToolType.HorizontalScrollBar.TabIndex = 2;
            this.spdToolType.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdToolType.Location = new System.Drawing.Point(0, 5);
            this.spdToolType.Name = "spdToolType";
            this.spdToolType.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdToolType.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdToolType.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdToolType_Sheet1});
            this.spdToolType.Size = new System.Drawing.Size(500, 427);
            this.spdToolType.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdToolType.TabIndex = 0;
            this.spdToolType.TabStop = false;
            this.spdToolType.TextTipDelay = 200;
            this.spdToolType.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdToolType.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdToolType.VerticalScrollBar.Name = "";
            this.spdToolType.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdToolType.VerticalScrollBar.TabIndex = 3;
            this.spdToolType.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdToolType.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.spdToolType_Change);
            this.spdToolType.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdToolType_CellClick);
            this.spdToolType.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdToolType_ButtonClicked);
            this.spdToolType.MouseDown += new System.Windows.Forms.MouseEventHandler(this.spdToolType_MouseDown);
            // 
            // spdToolType_Sheet1
            // 
            this.spdToolType_Sheet1.Reset();
            spdToolType_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdToolType_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdToolType_Sheet1.ColumnCount = 10;
            spdToolType_Sheet1.RowCount = 30;
            this.spdToolType_Sheet1.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdToolType_Sheet1.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolType_Sheet1.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdToolType_Sheet1.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.MaximumValue = 30D;
            numberCellType1.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(0, 2).CellType = numberCellType1;
            this.spdToolType_Sheet1.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdToolType_Sheet1.Cells.Get(1, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolType_Sheet1.Cells.Get(1, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdToolType_Sheet1.Cells.Get(1, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            numberCellType2.DecimalPlaces = 0;
            numberCellType2.MaximumValue = 30D;
            numberCellType2.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(1, 2).CellType = numberCellType2;
            this.spdToolType_Sheet1.Cells.Get(1, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(2, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdToolType_Sheet1.Cells.Get(2, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolType_Sheet1.Cells.Get(2, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdToolType_Sheet1.Cells.Get(2, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            numberCellType3.DecimalPlaces = 0;
            numberCellType3.MaximumValue = 30D;
            numberCellType3.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(2, 2).CellType = numberCellType3;
            this.spdToolType_Sheet1.Cells.Get(2, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(3, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdToolType_Sheet1.Cells.Get(3, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolType_Sheet1.Cells.Get(3, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdToolType_Sheet1.Cells.Get(3, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            numberCellType4.DecimalPlaces = 0;
            numberCellType4.MaximumValue = 30D;
            numberCellType4.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(3, 2).CellType = numberCellType4;
            this.spdToolType_Sheet1.Cells.Get(3, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(4, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType5.DecimalPlaces = 0;
            numberCellType5.MaximumValue = 30D;
            numberCellType5.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(4, 2).CellType = numberCellType5;
            this.spdToolType_Sheet1.Cells.Get(4, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(5, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType6.DecimalPlaces = 0;
            numberCellType6.MaximumValue = 30D;
            numberCellType6.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(5, 2).CellType = numberCellType6;
            this.spdToolType_Sheet1.Cells.Get(5, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(6, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType7.DecimalPlaces = 0;
            numberCellType7.MaximumValue = 30D;
            numberCellType7.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(6, 2).CellType = numberCellType7;
            this.spdToolType_Sheet1.Cells.Get(6, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(7, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType8.DecimalPlaces = 0;
            numberCellType8.MaximumValue = 30D;
            numberCellType8.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(7, 2).CellType = numberCellType8;
            this.spdToolType_Sheet1.Cells.Get(7, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(8, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType9.DecimalPlaces = 0;
            numberCellType9.MaximumValue = 30D;
            numberCellType9.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(8, 2).CellType = numberCellType9;
            this.spdToolType_Sheet1.Cells.Get(8, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(9, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType10.DecimalPlaces = 0;
            numberCellType10.MaximumValue = 30D;
            numberCellType10.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(9, 2).CellType = numberCellType10;
            this.spdToolType_Sheet1.Cells.Get(9, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(10, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType11.DecimalPlaces = 0;
            numberCellType11.MaximumValue = 30D;
            numberCellType11.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(10, 2).CellType = numberCellType11;
            this.spdToolType_Sheet1.Cells.Get(10, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(11, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType12.DecimalPlaces = 0;
            numberCellType12.MaximumValue = 30D;
            numberCellType12.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(11, 2).CellType = numberCellType12;
            this.spdToolType_Sheet1.Cells.Get(11, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(12, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType13.DecimalPlaces = 0;
            numberCellType13.MaximumValue = 30D;
            numberCellType13.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(12, 2).CellType = numberCellType13;
            this.spdToolType_Sheet1.Cells.Get(12, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(13, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType14.DecimalPlaces = 0;
            numberCellType14.MaximumValue = 30D;
            numberCellType14.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(13, 2).CellType = numberCellType14;
            this.spdToolType_Sheet1.Cells.Get(13, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(14, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType15.DecimalPlaces = 0;
            numberCellType15.MaximumValue = 30D;
            numberCellType15.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(14, 2).CellType = numberCellType15;
            this.spdToolType_Sheet1.Cells.Get(14, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(15, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType16.DecimalPlaces = 0;
            numberCellType16.MaximumValue = 30D;
            numberCellType16.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(15, 2).CellType = numberCellType16;
            this.spdToolType_Sheet1.Cells.Get(15, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(16, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType17.DecimalPlaces = 0;
            numberCellType17.MaximumValue = 30D;
            numberCellType17.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(16, 2).CellType = numberCellType17;
            this.spdToolType_Sheet1.Cells.Get(16, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(17, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType18.DecimalPlaces = 0;
            numberCellType18.MaximumValue = 30D;
            numberCellType18.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(17, 2).CellType = numberCellType18;
            this.spdToolType_Sheet1.Cells.Get(17, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(18, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType19.DecimalPlaces = 0;
            numberCellType19.MaximumValue = 30D;
            numberCellType19.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(18, 2).CellType = numberCellType19;
            this.spdToolType_Sheet1.Cells.Get(18, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(19, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType20.DecimalPlaces = 0;
            numberCellType20.MaximumValue = 30D;
            numberCellType20.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(19, 2).CellType = numberCellType20;
            this.spdToolType_Sheet1.Cells.Get(19, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(20, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType21.DecimalPlaces = 0;
            numberCellType21.MaximumValue = 30D;
            numberCellType21.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(20, 2).CellType = numberCellType21;
            this.spdToolType_Sheet1.Cells.Get(20, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(21, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType22.DecimalPlaces = 0;
            numberCellType22.MaximumValue = 30D;
            numberCellType22.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(21, 2).CellType = numberCellType22;
            this.spdToolType_Sheet1.Cells.Get(21, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(22, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType23.DecimalPlaces = 0;
            numberCellType23.MaximumValue = 30D;
            numberCellType23.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(22, 2).CellType = numberCellType23;
            this.spdToolType_Sheet1.Cells.Get(22, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(23, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType24.DecimalPlaces = 0;
            numberCellType24.MaximumValue = 30D;
            numberCellType24.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(23, 2).CellType = numberCellType24;
            this.spdToolType_Sheet1.Cells.Get(23, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(24, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType25.DecimalPlaces = 0;
            numberCellType25.MaximumValue = 30D;
            numberCellType25.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(24, 2).CellType = numberCellType25;
            this.spdToolType_Sheet1.Cells.Get(24, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(25, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType26.DecimalPlaces = 0;
            numberCellType26.MaximumValue = 30D;
            numberCellType26.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(25, 2).CellType = numberCellType26;
            this.spdToolType_Sheet1.Cells.Get(25, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(26, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType27.DecimalPlaces = 0;
            numberCellType27.MaximumValue = 30D;
            numberCellType27.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(26, 2).CellType = numberCellType27;
            this.spdToolType_Sheet1.Cells.Get(26, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(27, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType28.DecimalPlaces = 0;
            numberCellType28.MaximumValue = 30D;
            numberCellType28.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(27, 2).CellType = numberCellType28;
            this.spdToolType_Sheet1.Cells.Get(27, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(28, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            numberCellType29.DecimalPlaces = 0;
            numberCellType29.MaximumValue = 30D;
            numberCellType29.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(28, 2).CellType = numberCellType29;
            this.spdToolType_Sheet1.Cells.Get(28, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Cells.Get(29, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdToolType_Sheet1.Cells.Get(29, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolType_Sheet1.Cells.Get(29, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdToolType_Sheet1.Cells.Get(29, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            numberCellType30.DecimalPlaces = 0;
            numberCellType30.MaximumValue = 30D;
            numberCellType30.MinimumValue = 0D;
            this.spdToolType_Sheet1.Cells.Get(29, 2).CellType = numberCellType30;
            this.spdToolType_Sheet1.Cells.Get(29, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdToolType_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdToolType_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdToolType_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdToolType_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Prompt";
            this.spdToolType_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Format";
            this.spdToolType_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Size";
            this.spdToolType_Sheet1.ColumnHeader.Cells.Get(0, 3).ColumnSpan = 2;
            this.spdToolType_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "GCM Table";
            this.spdToolType_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "j";
            this.spdToolType_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Setup";
            this.spdToolType_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Event";
            this.spdToolType_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Require";
            this.spdToolType_Sheet1.ColumnHeader.Cells.Get(0, 8).ColumnSpan = 2;
            this.spdToolType_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Default Create Value";
            this.spdToolType_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdToolType_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdToolType_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdToolType_Sheet1.Columns.Get(0).Border = complexBorder1;
            textCellType1.MaxLength = 40;
            this.spdToolType_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.spdToolType_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdToolType_Sheet1.Columns.Get(0).Label = "Prompt";
            this.spdToolType_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolType_Sheet1.Columns.Get(0).Width = 110F;
            this.spdToolType_Sheet1.Columns.Get(1).Border = complexBorder2;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType1.Items = new string[] {
        "Ascii",
        "Number",
        "Float"};
            this.spdToolType_Sheet1.Columns.Get(1).CellType = comboBoxCellType1;
            this.spdToolType_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdToolType_Sheet1.Columns.Get(1).Label = "Format";
            this.spdToolType_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolType_Sheet1.Columns.Get(1).Width = 68F;
            this.spdToolType_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdToolType_Sheet1.Columns.Get(2).Label = "Size";
            this.spdToolType_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolType_Sheet1.Columns.Get(2).Width = 35F;
            textCellType2.MaxLength = 20;
            this.spdToolType_Sheet1.Columns.Get(3).CellType = textCellType2;
            this.spdToolType_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdToolType_Sheet1.Columns.Get(3).Label = "GCM Table";
            this.spdToolType_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolType_Sheet1.Columns.Get(3).Width = 100F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdToolType_Sheet1.Columns.Get(4).CellType = buttonCellType1;
            this.spdToolType_Sheet1.Columns.Get(4).Label = "j";
            this.spdToolType_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolType_Sheet1.Columns.Get(4).Width = 22F;
            this.spdToolType_Sheet1.Columns.Get(5).CellType = checkBoxCellType1;
            this.spdToolType_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdToolType_Sheet1.Columns.Get(5).Label = "Setup";
            this.spdToolType_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolType_Sheet1.Columns.Get(5).Width = 40F;
            this.spdToolType_Sheet1.Columns.Get(6).CellType = checkBoxCellType2;
            this.spdToolType_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdToolType_Sheet1.Columns.Get(6).Label = "Event";
            this.spdToolType_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolType_Sheet1.Columns.Get(6).Width = 45F;
            this.spdToolType_Sheet1.Columns.Get(7).CellType = checkBoxCellType3;
            this.spdToolType_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdToolType_Sheet1.Columns.Get(7).Label = "Require";
            this.spdToolType_Sheet1.Columns.Get(7).Locked = false;
            this.spdToolType_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolType_Sheet1.Columns.Get(7).Width = 46F;
            this.spdToolType_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdToolType_Sheet1.Columns.Get(8).Label = "Default Create Value";
            this.spdToolType_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdToolType_Sheet1.Columns.Get(8).Width = 100F;
            buttonCellType2.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType2.Text = "...";
            this.spdToolType_Sheet1.Columns.Get(9).CellType = buttonCellType2;
            this.spdToolType_Sheet1.Columns.Get(9).Width = 23F;
            this.spdToolType_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdToolType_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdToolType_Sheet1.RowHeader.Columns.Get(0).Width = 27F;
            this.spdToolType_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdToolType_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdToolType_Sheet1.Rows.Get(0).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(1).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(2).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(3).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(4).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(5).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(6).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(7).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(8).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(9).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(10).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(11).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(12).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(13).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(14).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(15).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(16).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(17).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(18).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(19).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(20).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(21).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(22).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(23).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(24).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(25).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(26).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(27).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(28).Height = 18F;
            this.spdToolType_Sheet1.Rows.Get(29).Height = 18F;
            this.spdToolType_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdToolType_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdToolType_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // cdvTableList
            // 
            this.cdvTableList.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvTableList.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableList.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvTableList.Location = new System.Drawing.Point(189, 17);
            this.cdvTableList.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableList.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableList.Name = "cdvTableList";
            this.cdvTableList.Size = new System.Drawing.Size(20, 20);
            this.cdvTableList.SmallImageList = null;
            this.cdvTableList.TabIndex = 0;
            this.cdvTableList.TabStop = false;
            this.cdvTableList.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvTableList.Visible = false;
            this.cdvTableList.VisibleColumnHeader = false;
            this.cdvTableList.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvTableList_SelectedItemChanged);
            // 
            // btnTolTypExcel
            // 
            this.btnTolTypExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTolTypExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTolTypExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnTolTypExcel.Image")));
            this.btnTolTypExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTolTypExcel.Location = new System.Drawing.Point(239, 8);
            this.btnTolTypExcel.Name = "btnTolTypExcel";
            this.btnTolTypExcel.Size = new System.Drawing.Size(24, 24);
            this.btnTolTypExcel.TabIndex = 24;
            this.btnTolTypExcel.Click += new System.EventHandler(this.btnTolTypExcel_Click);
            // 
            // frmRASSetupToolType
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRASSetupToolType";
            this.Text = "Tool Type Setup";
            this.Activated += new System.EventHandler(this.frmRASToolTYPE_Activated);
            this.Load += new System.EventHandler(this.frmRASToolTYPE_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.spdToolType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdToolType_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        private bool bCellEdit;
        
        #endregion
        
        #region " Function Definition "
        
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ('1', "2", "3")
        //
        private void ClearData(char ProcStep)
        {
            try
            {
                if (ProcStep == '1')
                {
                    txtToolType.Text = "";
                    txtDesc.Text = "";
                    spdToolType.ActiveSheet.ClearRange(0, 0, 30, 10, true);
                }
                else if (ProcStep == '2')
                {
                    MPCF.InitListView(lisToolType);
                }
                else if (ProcStep == '3')
                {
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
            
            switch (MPCF.Trim(FuncName))
            {
                case "UPDATE_TOOL_TYPE":
                    
                    if (txtToolType.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        txtToolType.Select();
                        return false;
                    }

                    switch (MPCF.ToChar(MPCF.Trim(ProcStep)))
                    {
                        case MPGC.MP_STEP_CREATE:
                            
                            for (i = 0; i <= spdToolType.ActiveSheet.RowCount - 1; i++)
                            {
                                if (MPCF.Trim(spdToolType.ActiveSheet.GetValue(i, 0)) == "" && MPCF.Trim(spdToolType.ActiveSheet.GetValue(i, 1)) == "" && MPCF.Trim(spdToolType.ActiveSheet.GetValue(i, 2)) == "")
                                {
                                }
                                else if (MPCF.Trim(spdToolType.ActiveSheet.GetValue(i, 0)) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdToolType.ActiveSheet.SetActiveCell(i, 0);
                                    spdToolType.EditModePermanent = true;
                                    spdToolType.EditMode = true;
                                    return false;
                                }
                                else if (MPCF.Trim(spdToolType.ActiveSheet.GetValue(i, 1)) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdToolType.ActiveSheet.SetActiveCell(i, 1);
                                    spdToolType.EditModePermanent = true;
                                    spdToolType.EditMode = true;
                                    return false;
                                }
                                else if (MPCF.ToDbl(spdToolType.ActiveSheet.GetValue(i, 2)) < 0 || MPCF.ToDbl(spdToolType.ActiveSheet.GetValue(i, 2)) > 30 || MPCF.Trim(spdToolType.ActiveSheet.GetValue(i, 2)) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(130));
                                    spdToolType.ActiveSheet.SetActiveCell(i, 2);
                                    spdToolType.EditModePermanent = true;
                                    spdToolType.EditMode = true;
                                    return false;
                                }
                            }
                            break;
                            
                            
                        case MPGC.MP_STEP_UPDATE:
                            
                            
                            for (i = 0; i <= spdToolType.ActiveSheet.RowCount - 1; i++)
                            {
                                if (MPCF.Trim(spdToolType.ActiveSheet.GetValue(i, 0)) == "" && MPCF.Trim(spdToolType.ActiveSheet.GetValue(i, 1)) == "" && MPCF.Trim(spdToolType.ActiveSheet.GetValue(i, 2)) == "")
                                {
                                }
                                else if (MPCF.Trim(spdToolType.ActiveSheet.GetValue(i, 0)) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdToolType.ActiveSheet.SetActiveCell(i, 0);
                                    spdToolType.EditModePermanent = true;
                                    spdToolType.EditMode = true;
                                    return false;
                                }
                                else if (MPCF.Trim(spdToolType.ActiveSheet.GetValue(i, 1)) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdToolType.ActiveSheet.SetActiveCell(i, 1);
                                    spdToolType.EditModePermanent = true;
                                    spdToolType.EditMode = true;
                                    return false;
                                }
                                else if (MPCF.ToDbl(spdToolType.ActiveSheet.GetValue(i, 2)) < 0 || MPCF.ToDbl(spdToolType.ActiveSheet.GetValue(i, 2)) > 30 || MPCF.Trim(spdToolType.ActiveSheet.GetValue(i, 2)) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(130));
                                    spdToolType.ActiveSheet.SetActiveCell(i, 2);
                                    spdToolType.EditModePermanent = true;
                                    spdToolType.EditMode = true;
                                    return false;
                                }
                            }
                            break;
                            
                        case MPGC.MP_STEP_DELETE:
                            
                            break;
                            
                    }
                    break;
                    
            }
            return true;
        }
        
        //
        // View_Tool_Type()
        //       - View General Code Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Tool_Type()
        {
            int i;

            TRSNode in_node = new TRSNode("VIEW_TOOL_TYPE_IN");
            TRSNode out_node = new TRSNode("VIEW_TOOL_TYPE_OUT");

            try
            {
                ClearData('1');

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TOOL_TYPE", lisToolType.SelectedItems[0].Text);

                if (MPCR.CallService("RAS", "RAS_View_Tool_Type", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtToolType.Text = MPCF.Trim(out_node.GetString("TOOL_TYPE"));
                txtDesc.Text = MPCF.Trim(out_node.GetString("TOOL_TYPE_DESC"));

                for (i = 0; i < 30; i++)
                {

                    if (out_node.GetList(0)[i].GetString("PROMPT") == "")
                    {
                        spdToolType.ActiveSheet.Cells[i, 1].Value = "";
                        spdToolType.ActiveSheet.Cells[i, 2].Value = "";
                        spdToolType.ActiveSheet.Cells[i, 3].Value = "";
                        spdToolType.ActiveSheet.Cells[i, 5].Value = false;
                        spdToolType.ActiveSheet.Cells[i, 6].Value = false;
                        spdToolType.ActiveSheet.Cells[i, 7].Value = false;
                        spdToolType.ActiveSheet.Cells[i, 7].Locked = true;
                        spdToolType.ActiveSheet.Cells[i, 8].Value = "";
                        spdToolType.ActiveSheet.Cells[i, 8].Locked = true;
                    }
                    else
                    {

                        spdToolType.ActiveSheet.SetValue(i, 0, MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")));

                        switch (out_node.GetList(0)[i].GetChar("FORMAT"))
                        {
                            case 'A':

                                spdToolType.ActiveSheet.Cells[i, 1].Value = "Ascii";
                                break;
                            case 'N':

                                spdToolType.ActiveSheet.Cells[i, 1].Value = "Number";
                                break;
                            case 'F':

                                spdToolType.ActiveSheet.Cells[i, 1].Value = "Float";
                                break;
                            default:

                                spdToolType.ActiveSheet.Cells[i, 1].Value = "";
                                break;
                        }

                        spdToolType.ActiveSheet.SetValue(i, 2, out_node.GetList(0)[i].GetInt("SIZE").ToString());
                        spdToolType.ActiveSheet.SetValue(i, 3, MPCF.Trim(out_node.GetList(0)[i].GetString("TABLE_NAME")));
                        if (out_node.GetList(0)[i].GetChar("SETUP_FLAG") == 'Y')
                        {
                            spdToolType.ActiveSheet.SetValue(i, 5, true);
                        }
                        else
                        {
                            spdToolType.ActiveSheet.SetValue(i, 5, false);
                        }

                        if (out_node.GetList(0)[i].GetChar("EVENT_FLAG") == 'Y')
                        {
                            spdToolType.ActiveSheet.SetValue(i, 6, true);
                        }
                        else
                        {
                            spdToolType.ActiveSheet.SetValue(i, 6, false);
                        }

                        if (out_node.GetList(0)[i].GetChar("OPT") == 'Y')
                        {
                            spdToolType.ActiveSheet.SetValue(i, 7, true);
                        }
                        else
                        {
                            spdToolType.ActiveSheet.SetValue(i, 7, false);
                        }

                        if (out_node.GetList(0)[i].GetChar("SETUP_FLAG") == 'Y')
                        {
                            spdToolType.ActiveSheet.Cells[i, 7].Locked = false;
                        }
                        else
                        {
                            spdToolType.ActiveSheet.Cells[i, 7].Locked = true;
                        }

                        spdToolType.ActiveSheet.SetValue(i, 8, MPCF.Trim(out_node.GetList(0)[i].GetString("CRT_VALUE")));

                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("TABLE_NAME")) == "")
                        {
                            spdToolType.ActiveSheet.Cells[i, 8].Locked = false;
                        }
                        else
                        {
                            spdToolType.ActiveSheet.Cells[i, 8].Locked = true;
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

        
        //
        // Update_Tool_Type()
        //       - Create/Update/Delete General Code Table Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("1" - Create, "2" - Update, "3" - Delete)
        //
        private bool Update_Tool_Type(char ProcStep)
        {
            int j;
            ListViewItem itm;

            TRSNode in_node = new TRSNode("UPDATE_TOOL_TYPE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode list_item;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("TOOL_TYPE", txtToolType.Text);
                in_node.AddString("TOOL_TYPE_DESC", txtDesc.Text);

                for (j = 0; j < 30; j++)
                {
                    list_item = in_node.AddNode("DATA_LIST");

                    list_item.AddString("PROMPT", MPCF.Trim(spdToolType.ActiveSheet.GetValue(j, 0)));
                    list_item.AddChar("FORMAT", MPCF.ToChar(spdToolType.ActiveSheet.GetValue(j, 1)));
                    list_item.AddInt("SIZE", MPCF.ToInt(spdToolType.ActiveSheet.GetValue(j, 2)));
                    list_item.AddString("TABLE_NAME", MPCF.Trim(spdToolType.ActiveSheet.GetValue(j, 3)));

                    if (spdToolType.ActiveSheet.Cells[j, 5].Value != null && Convert.ToBoolean(spdToolType.ActiveSheet.Cells[j, 5].Value) == true)
                    {
                        list_item.AddChar("SETUP_FLAG", 'Y');
                    }
                    else
                    {
                        list_item.AddChar("SETUP_FLAG", ' ');
                    }

                    if (spdToolType.ActiveSheet.Cells[j, 6].Value != null && Convert.ToBoolean(spdToolType.ActiveSheet.Cells[j, 6].Value) == true)
                    {
                        list_item.AddChar("EVENT_FLAG", 'Y');
                    }
                    else
                    {
                        list_item.AddChar("EVENT_FLAG", ' ');
                    }

                    if (spdToolType.ActiveSheet.Cells[j, 7].Value != null && Convert.ToBoolean(spdToolType.ActiveSheet.Cells[j, 7].Value) == true)
                    {
                        list_item.AddChar("OPT", 'Y');
                    }
                    else
                    {
                        list_item.AddChar("OPT", ' ');
                    }

                    list_item.AddString("CRT_VALUE", MPCF.Trim(spdToolType.ActiveSheet.GetValue(j, 8)));
                }
                
                if (MPCR.CallService("RAS", "RAS_Update_Tool_Type", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisToolType.Items.Add(MPCF.Trim(txtToolType.Text), (int)SMALLICON_INDEX.IDX_TOOL_TYPE);
                        itm.SubItems.Add(MPCF.Trim(txtDesc.Text));
                        itm.Selected = true;
                        lisToolType.Sorting = SortOrder.Ascending;
                        lisToolType.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisToolType, MPCF.Trim(txtToolType.Text), false) == true)
                        {
                            lisToolType.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    lblDataCount.Text = MPCF.Trim(lisToolType.Items.Count);
                }
                MPCR.ShowSuccessMsg(out_node);
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
                return this.lisToolType;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmRASToolTYPE_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    lisToolType.Focus();
                    
                    lblDataCount.Text = "";
                    if (RASLIST.ViewToolTypeList(lisToolType, '1', 'N', 'N', null) == true)
                    {
                        lblDataCount.Text = MPCF.Trim(lisToolType.Items.Count);
                    }
                    else
                    {
                        return;
                    }
                    if (lisToolType.Items.Count > 0)
                    {
                        lisToolType.Items[0].Selected = true;
                    }
                    
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void frmRASToolTYPE_Load(object sender, System.EventArgs e)
        {
            try
            {
                MPCF.InitListView(lisToolType);
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
                if (CheckCondition("UPDATE_TOOL_TYPE", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Tool_Type(MPGC.MP_STEP_CREATE) == false)
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
                if (CheckCondition("UPDATE_TOOL_TYPE", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Tool_Type(MPGC.MP_STEP_UPDATE) == false)
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
                
                if (CheckCondition("UPDATE_TOOL_TYPE", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_Tool_Type(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }
                    
                    ClearData('1');
                    btnRefresh.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void lisToolType_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            ClearData('1');
            spdToolType.ActiveSheet.SetActiveCell(0, 0);
            
            try
            {
                if (lisToolType.SelectedItems.Count > 0)
                {
                    View_Tool_Type();
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
                lblDataCount.Text = "";
                if (RASLIST.ViewToolTypeList(lisToolType, '1', 'N', 'N', null) == false)
                {
                    return;
                }
                lblDataCount.Text = MPCF.Trim(lisToolType.Items.Count);
                if (lisToolType.Items.Count > 0)
                {
                    MPCF.FindListItem(lisToolType, txtToolType.Text, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.ExportToExcel(lisToolType, this.Text, "");
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisToolType, txtFind.Text, true, false);
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisToolType, txtFind.Text, 0, true, false);
        }
        
        private void spdToolType_Change(System.Object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            
            try
            {
                if (e.Column != 0)
                {
                    return;
                }
                
                if (MPCF.Trim(spdToolType.ActiveSheet.GetValue(e.Row, e.Column)) == "")
                {
                    spdToolType.ActiveSheet.SetValue(e.Row, 1, "");
                    spdToolType.ActiveSheet.SetValue(e.Row, 2, "");
                    spdToolType.ActiveSheet.SetValue(e.Row, 3, "");
                    spdToolType.ActiveSheet.SetValue(e.Row, 5, false);
                    spdToolType.ActiveSheet.SetValue(e.Row, 6, false);
                    spdToolType.ActiveSheet.SetValue(e.Row, 7, false);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void spdToolType_CellClick(System.Object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            
            int i;
            
            for (i = 0; i < 30; i++)
            {
                if (MPCF.Trim(spdToolType.ActiveSheet.GetValue(i, 0)) == "")
                {
                    spdToolType.ActiveSheet.SetValue(i, 1, "");
                    spdToolType.ActiveSheet.SetValue(i, 2, "");
                    spdToolType.ActiveSheet.SetValue(i, 3, "");
                    spdToolType.ActiveSheet.SetValue(i, 5, false);
                    spdToolType.ActiveSheet.SetValue(i, 6, false);
                    spdToolType.ActiveSheet.SetValue(i, 7, false);
                    spdToolType.ActiveSheet.Cells[i, 7].Locked = true;
                }
            }
            
            if (bCellEdit == false &&(e.Column == 0 || e.Column == 3))
            {
                if (spdToolType.EditModePermanent == true)
                {
                    return;
                }
            }
            
            if (bCellEdit == true &&(e.Column == 0 || e.Column == 3))
            {
                spdToolType.EditModePermanent = true;
                if (spdToolType.ActiveSheet.RowCount > 0)
                {
                    spdToolType.EditMode = true;
                }
                bCellEdit = false;
            }
            else
            {
                spdToolType.EditModePermanent = false;
                bCellEdit = true;
            }
            
        }
        
        private void spdToolType_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.X < spdToolType.ActiveSheet.RowHeader.Columns[0].Width)
            {
                spdToolType.EditModePermanent = false;
                spdToolType.ActiveSheet.ActiveColumnIndex = 1;
                bCellEdit = false;
            }
            
        }
        
        private void spdToolType_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == 4)
            {
                cdvTableList.Init();
                cdvTableList.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvTableList.GetListView);
                cdvTableList.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
                cdvTableList.Columns.Add("Table Desc", 50, HorizontalAlignment.Left);
                BASLIST.ViewGCMTableList(cdvTableList.GetListView, '1');
                cdvTableList.InsertEmptyRow(0, 1);
                if (cdvTableList.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
            }
            else if (e.Column == 5)
            {
                if (spdToolType.ActiveSheet.Cells[e.Row, 5].Value != null && Convert.ToBoolean(spdToolType.ActiveSheet.Cells[e.Row, 5].Value) == true)
                {
                    spdToolType.ActiveSheet.Cells[e.Row, 7].Locked = false;
                    spdToolType.ActiveSheet.Cells[e.Row, 7].Value = false;
                }
                else
                {
                    spdToolType.ActiveSheet.Cells[e.Row, 7].Locked = true;
                    spdToolType.ActiveSheet.Cells[e.Row, 7].Value = false;
                }
            }
            if (e.Column == 9)
            {
                string s_table_name = MPCF.Trim(spdToolType.ActiveSheet.Cells[e.Row, 3].Value);
                if (s_table_name != "")
                {
                    cdvTableList.Init();
                    cdvTableList.ViewPosition = Control.MousePosition;
                    MPCF.InitListView(cdvTableList.GetListView);
                    cdvTableList.Columns.Add("Code", 50, HorizontalAlignment.Left);
                    cdvTableList.Columns.Add("Desc", 50, HorizontalAlignment.Left);
                    BASLIST.ViewGCMDataList(cdvTableList.GetListView, '1', s_table_name);
                    cdvTableList.InsertEmptyRow(0, 1);
                    if (cdvTableList.ShowPopupList(e.Row, e.Column) == false)
                    {
                        return;
                    }
                }
            }
        }
        
        private void cdvTableList_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(spdToolType.ActiveSheet.Cells[e.Row, e.Col - 1].Value) != e.SelectedItem.SubItems[0].Text)
            {
                spdToolType.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
                if (e.Col == 4)
                {
                    spdToolType.ActiveSheet.Cells[e.Row, 8].Value = "";
                    if (MPCF.Trim(spdToolType.ActiveSheet.Cells[e.Row, e.Col - 1].Value) != "")
                    {
                        spdToolType.ActiveSheet.Cells[e.Row, 8].Locked = true;
                    }
                    else
                    {
                        spdToolType.ActiveSheet.Cells[e.Row, 8].Locked = false;
                    }
                }
            }
        }
        
        private void txtToolType_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FieldClear(this, txtToolType, txtFind, null, null, null, false);
            spdToolType.ActiveSheet.ClearRange(0, 0, 30, 10, true);
        }

        private void btnTolTypExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond = string.Empty;


                sCond = "Tool Type : " + lisToolType.SelectedItems[0].Text;


                MPCF.ExportToExcel(spdToolType, this.Text, sCond);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

       
        
    }
    
    //#End If
}
