using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI.Controls;
using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASSetupToolEvent.vb
//   Description : Resource Setup Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - SetGroupCmfItem() : Set Group/Cmf property to control
//       - initCodeView() : initial CodeView Control
//       - CheckCondition() : Check the conditions before transaction
//       - Update_Resource() : Create/Update/Delete Resource
//       - View_Resource() : Find Resource and View Resource
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-09 : Created by H.K. Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _TOOL = True Then

namespace Miracom.RASCore
{
    public class frmRASSetupToolEvent : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASSetupToolEvent()
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
        private System.Windows.Forms.Panel pnlType;
        private System.Windows.Forms.Label lblType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvType;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private Miracom.UI.Controls.MCListView.MCListView lisToolEvent;
        private System.Windows.Forms.GroupBox grpResource;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.GroupBox grpChkItem;
        private System.Windows.Forms.CheckBox chkCleanDefectData;
        private System.Windows.Forms.CheckBox chkCollectDefectData;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Panel pnlGeneral;
        private System.Windows.Forms.Label lblToolEvent;
        private System.Windows.Forms.CheckBox chkCleanDefData;
        private System.Windows.Forms.CheckBox chkColDefData;
        private System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.Splitter Splitter1;
        private System.Windows.Forms.Panel Panel3;
        private System.Windows.Forms.TextBox txtToolEventID;
        private FarPoint.Win.Spread.FpSpread spdCheckItem;
        private FarPoint.Win.Spread.SheetView spdCheckItem_Sheet1;
        private FarPoint.Win.Spread.FpSpread spdChangeItem;
        private FarPoint.Win.Spread.SheetView spdChangeItem_Sheet1;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvTableList;
        private System.Windows.Forms.CheckBox chkSystemFlag;
        private UI.Controls.MCCodeView.MCSPCodeView cdvValueFieldList;
        private System.Windows.Forms.Label lblDesc;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer3 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer3 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer4 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer4 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer5 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer5 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer6 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer6 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType3 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle5 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle6 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle7 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer2 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle8 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType2 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType4 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType5 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.pnlType = new System.Windows.Forms.Panel();
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblType = new System.Windows.Forms.Label();
            this.lisToolEvent = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpResource = new System.Windows.Forms.GroupBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.chkSystemFlag = new System.Windows.Forms.CheckBox();
            this.lblToolEvent = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtToolEventID = new System.Windows.Forms.TextBox();
            this.grpChkItem = new System.Windows.Forms.GroupBox();
            this.chkCleanDefectData = new System.Windows.Forms.CheckBox();
            this.chkCollectDefectData = new System.Windows.Forms.CheckBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCleanDefData = new System.Windows.Forms.CheckBox();
            this.chkColDefData = new System.Windows.Forms.CheckBox();
            this.pnlGeneral = new System.Windows.Forms.Panel();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.spdChangeItem = new FarPoint.Win.Spread.FpSpread();
            this.spdChangeItem_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.Splitter1 = new System.Windows.Forms.Splitter();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.spdCheckItem = new FarPoint.Win.Spread.FpSpread();
            this.spdCheckItem_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.cdvTableList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.cdvValueFieldList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).BeginInit();
            this.grpResource.SuspendLayout();
            this.grpChkItem.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.pnlGeneral.SuspendLayout();
            this.Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdChangeItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdChangeItem_Sheet1)).BeginInit();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdCheckItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCheckItem_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValueFieldList)).BeginInit();
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
            this.txtFind.TextChanged += new System.EventHandler(this.txtToolEventID_TextChanged);
            // 
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlGeneral);
            this.pnlRight.Controls.Add(this.GroupBox1);
            this.pnlRight.Controls.Add(this.grpResource);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisToolEvent);
            this.pnlLeft.Controls.Add(this.pnlType);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.pnlLeft.Size = new System.Drawing.Size(232, 513);
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 0;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Tool Event Setup";
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
            columnHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer3.Name = "columnHeaderRenderer3";
            columnHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer3.TextRotationAngle = 0D;
            rowHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer3.Name = "rowHeaderRenderer3";
            rowHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer3.TextRotationAngle = 0D;
            columnHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer4.Name = "columnHeaderRenderer4";
            columnHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer4.TextRotationAngle = 0D;
            rowHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer4.Name = "rowHeaderRenderer4";
            rowHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer4.TextRotationAngle = 0D;
            columnHeaderRenderer5.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer5.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer5.Name = "columnHeaderRenderer5";
            columnHeaderRenderer5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer5.TextRotationAngle = 0D;
            rowHeaderRenderer5.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer5.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer5.Name = "rowHeaderRenderer5";
            rowHeaderRenderer5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer5.TextRotationAngle = 0D;
            columnHeaderRenderer6.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer6.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer6.Name = "columnHeaderRenderer6";
            columnHeaderRenderer6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer6.TextRotationAngle = 0D;
            rowHeaderRenderer6.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer6.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer6.Name = "rowHeaderRenderer6";
            rowHeaderRenderer6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer6.TextRotationAngle = 0D;
            // 
            // pnlType
            // 
            this.pnlType.Controls.Add(this.cdvType);
            this.pnlType.Controls.Add(this.lblType);
            this.pnlType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlType.Location = new System.Drawing.Point(3, 0);
            this.pnlType.Name = "pnlType";
            this.pnlType.Size = new System.Drawing.Size(229, 40);
            this.pnlType.TabIndex = 0;
            // 
            // cdvType
            // 
            this.cdvType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvType.BtnToolTipText = "";
            this.cdvType.DescText = "";
            this.cdvType.DisplaySubItemIndex = -1;
            this.cdvType.DisplayText = "";
            this.cdvType.Focusing = null;
            this.cdvType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvType.Index = 0;
            this.cdvType.IsViewBtnImage = false;
            this.cdvType.Location = new System.Drawing.Point(92, 8);
            this.cdvType.MaxLength = 20;
            this.cdvType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvType.Name = "cdvType";
            this.cdvType.ReadOnly = true;
            this.cdvType.SearchSubItemIndex = 0;
            this.cdvType.SelectedDescIndex = -1;
            this.cdvType.SelectedSubItemIndex = -1;
            this.cdvType.SelectionStart = 0;
            this.cdvType.Size = new System.Drawing.Size(132, 20);
            this.cdvType.SmallImageList = null;
            this.cdvType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvType.TabIndex = 1;
            this.cdvType.TextBoxToolTipText = "";
            this.cdvType.TextBoxWidth = 132;
            this.cdvType.VisibleButton = true;
            this.cdvType.VisibleColumnHeader = false;
            this.cdvType.VisibleDescription = false;
            this.cdvType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvType_SelectedItemChanged);
            this.cdvType.ButtonPress += new System.EventHandler(this.cdvType_ButtonPress);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblType.Location = new System.Drawing.Point(6, 11);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(55, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Tool Type";
            // 
            // lisToolEvent
            // 
            this.lisToolEvent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisToolEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisToolEvent.EnableSort = true;
            this.lisToolEvent.EnableSortIcon = true;
            this.lisToolEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisToolEvent.FullRowSelect = true;
            this.lisToolEvent.Location = new System.Drawing.Point(3, 40);
            this.lisToolEvent.MultiSelect = false;
            this.lisToolEvent.Name = "lisToolEvent";
            this.lisToolEvent.Size = new System.Drawing.Size(229, 470);
            this.lisToolEvent.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lisToolEvent.TabIndex = 1;
            this.lisToolEvent.UseCompatibleStateImageBehavior = false;
            this.lisToolEvent.View = System.Windows.Forms.View.Details;
            this.lisToolEvent.SelectedIndexChanged += new System.EventHandler(this.lisToolEvent_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Tool Event";
            this.ColumnHeader1.Width = 80;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 150;
            // 
            // grpResource
            // 
            this.grpResource.Controls.Add(this.lblDesc);
            this.grpResource.Controls.Add(this.chkSystemFlag);
            this.grpResource.Controls.Add(this.lblToolEvent);
            this.grpResource.Controls.Add(this.txtDesc);
            this.grpResource.Controls.Add(this.txtToolEventID);
            this.grpResource.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResource.Location = new System.Drawing.Point(3, 0);
            this.grpResource.Name = "grpResource";
            this.grpResource.Size = new System.Drawing.Size(500, 71);
            this.grpResource.TabIndex = 0;
            this.grpResource.TabStop = false;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(16, 43);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 3;
            this.lblDesc.Text = "Description";
            // 
            // chkSystemFlag
            // 
            this.chkSystemFlag.AutoSize = true;
            this.chkSystemFlag.Enabled = false;
            this.chkSystemFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSystemFlag.Location = new System.Drawing.Point(374, 16);
            this.chkSystemFlag.Name = "chkSystemFlag";
            this.chkSystemFlag.Size = new System.Drawing.Size(89, 18);
            this.chkSystemFlag.TabIndex = 2;
            this.chkSystemFlag.Text = "System Flag";
            // 
            // lblToolEvent
            // 
            this.lblToolEvent.AutoSize = true;
            this.lblToolEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolEvent.Location = new System.Drawing.Point(15, 19);
            this.lblToolEvent.Name = "lblToolEvent";
            this.lblToolEvent.Size = new System.Drawing.Size(69, 13);
            this.lblToolEvent.TabIndex = 0;
            this.lblToolEvent.Text = "Tool Event";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(142, 40);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(348, 20);
            this.txtDesc.TabIndex = 4;
            // 
            // txtToolEventID
            // 
            this.txtToolEventID.Location = new System.Drawing.Point(142, 16);
            this.txtToolEventID.MaxLength = 12;
            this.txtToolEventID.Name = "txtToolEventID";
            this.txtToolEventID.Size = new System.Drawing.Size(200, 20);
            this.txtToolEventID.TabIndex = 1;
            this.txtToolEventID.TextChanged += new System.EventHandler(this.txtToolEventID_TextChanged);
            this.txtToolEventID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToolEventID_KeyPress);
            // 
            // grpChkItem
            // 
            this.grpChkItem.Controls.Add(this.chkCleanDefectData);
            this.grpChkItem.Controls.Add(this.chkCollectDefectData);
            this.grpChkItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChkItem.Location = new System.Drawing.Point(0, 5);
            this.grpChkItem.Name = "grpChkItem";
            this.grpChkItem.Size = new System.Drawing.Size(500, 41);
            this.grpChkItem.TabIndex = 0;
            this.grpChkItem.TabStop = false;
            // 
            // chkCleanDefectData
            // 
            this.chkCleanDefectData.Location = new System.Drawing.Point(300, 4);
            this.chkCleanDefectData.Name = "chkCleanDefectData";
            this.chkCleanDefectData.Size = new System.Drawing.Size(152, 24);
            this.chkCleanDefectData.TabIndex = 3;
            this.chkCleanDefectData.Text = "Clean Defect Data";
            // 
            // chkCollectDefectData
            // 
            this.chkCollectDefectData.Location = new System.Drawing.Point(48, 4);
            this.chkCollectDefectData.Name = "chkCollectDefectData";
            this.chkCollectDefectData.Size = new System.Drawing.Size(152, 24);
            this.chkCollectDefectData.TabIndex = 2;
            this.chkCollectDefectData.Text = "Collect Defect Data";
            // 
            // Panel1
            // 
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 46);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(500, 386);
            this.Panel1.TabIndex = 1;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.chkCleanDefData);
            this.GroupBox1.Controls.Add(this.chkColDefData);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GroupBox1.Location = new System.Drawing.Point(3, 71);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(500, 41);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            // 
            // chkCleanDefData
            // 
            this.chkCleanDefData.AutoSize = true;
            this.chkCleanDefData.Location = new System.Drawing.Point(170, 15);
            this.chkCleanDefData.Name = "chkCleanDefData";
            this.chkCleanDefData.Size = new System.Drawing.Size(114, 17);
            this.chkCleanDefData.TabIndex = 1;
            this.chkCleanDefData.Text = "Clean Defect Data";
            this.chkCleanDefData.Click += new System.EventHandler(this.chkCleanDefData_Click);
            // 
            // chkColDefData
            // 
            this.chkColDefData.AutoSize = true;
            this.chkColDefData.Location = new System.Drawing.Point(16, 15);
            this.chkColDefData.Name = "chkColDefData";
            this.chkColDefData.Size = new System.Drawing.Size(119, 17);
            this.chkColDefData.TabIndex = 0;
            this.chkColDefData.Text = "Collect Defect Data";
            this.chkColDefData.Click += new System.EventHandler(this.chkColDefData_Click);
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.Controls.Add(this.Panel3);
            this.pnlGeneral.Controls.Add(this.Splitter1);
            this.pnlGeneral.Controls.Add(this.Panel2);
            this.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneral.Location = new System.Drawing.Point(3, 112);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Size = new System.Drawing.Size(500, 398);
            this.pnlGeneral.TabIndex = 2;
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.spdChangeItem);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(0, 188);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(500, 210);
            this.Panel3.TabIndex = 1;
            // 
            // spdChangeItem
            // 
            this.spdChangeItem.AccessibleDescription = "spdChangeItem, Sheet1, Row 0, Column 0, ";
            this.spdChangeItem.BackColor = System.Drawing.SystemColors.Control;
            this.spdChangeItem.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
            this.spdChangeItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdChangeItem.EditModePermanent = true;
            this.spdChangeItem.EditModeReplace = true;
            this.spdChangeItem.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdChangeItem.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdChangeItem.HorizontalScrollBar.Name = "";
            this.spdChangeItem.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdChangeItem.HorizontalScrollBar.TabIndex = 12;
            this.spdChangeItem.Location = new System.Drawing.Point(0, 0);
            this.spdChangeItem.Name = "spdChangeItem";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Renderer = columnHeaderRenderer6;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Renderer = rowHeaderRenderer6;
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
            this.spdChangeItem.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdChangeItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdChangeItem.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdChangeItem.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdChangeItem.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdChangeItem_Sheet1});
            this.spdChangeItem.Size = new System.Drawing.Size(500, 210);
            this.spdChangeItem.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdChangeItem.TabIndex = 0;
            this.spdChangeItem.TabStop = false;
            this.spdChangeItem.TextTipDelay = 200;
            this.spdChangeItem.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdChangeItem.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdChangeItem.VerticalScrollBar.Name = "";
            this.spdChangeItem.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdChangeItem.VerticalScrollBar.TabIndex = 13;
            this.spdChangeItem.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdChangeItem_CellClick);
            this.spdChangeItem.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdChangeItem_ButtonClicked);
            this.spdChangeItem.ComboCloseUp += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdChangeItem_ComboCloseUp);
            this.spdChangeItem.ComboDropDown += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdChangeItem_ComboDropDown);
            this.spdChangeItem.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdChangeItem_EditChange);
            // 
            // spdChangeItem_Sheet1
            // 
            this.spdChangeItem_Sheet1.Reset();
            spdChangeItem_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdChangeItem_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdChangeItem_Sheet1.ColumnCount = 5;
            spdChangeItem_Sheet1.RowCount = 30;
            this.spdChangeItem_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdChangeItem_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdChangeItem_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdChangeItem_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Change Item";
            this.spdChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Change Flag";
            this.spdChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Change Value";
            this.spdChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Require";
            this.spdChangeItem_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdChangeItem_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdChangeItem_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            this.spdChangeItem_Sheet1.Columns.Get(0).CellType = comboBoxCellType1;
            this.spdChangeItem_Sheet1.Columns.Get(0).Label = "Change Item";
            this.spdChangeItem_Sheet1.Columns.Get(0).Width = 130F;
            comboBoxCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType2.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.Index;
            comboBoxCellType2.Items = new string[] {
        "",
        "Y (Change)",
        "N (Not Change)",
        "+ (Increase)",
        "- (Decrease)",
        "* (Multiply)",
        "/ (Division)",
        "mod (MOD)",
        "pow (POW)",
        "R (Reset)",
        "T (Time)"};
            comboBoxCellType2.ListWidth = 100;
            this.spdChangeItem_Sheet1.Columns.Get(1).CellType = comboBoxCellType2;
            this.spdChangeItem_Sheet1.Columns.Get(1).Label = "Change Flag";
            this.spdChangeItem_Sheet1.Columns.Get(1).Locked = true;
            this.spdChangeItem_Sheet1.Columns.Get(1).Width = 85F;
            this.spdChangeItem_Sheet1.Columns.Get(2).Label = "Change Value";
            this.spdChangeItem_Sheet1.Columns.Get(2).Locked = true;
            this.spdChangeItem_Sheet1.Columns.Get(2).Width = 88F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdChangeItem_Sheet1.Columns.Get(3).CellType = buttonCellType1;
            this.spdChangeItem_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Top;
            this.spdChangeItem_Sheet1.Columns.Get(3).Width = 21F;
            comboBoxCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType3.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.Index;
            comboBoxCellType3.Items = new string[] {
        "",
        "Y"};
            this.spdChangeItem_Sheet1.Columns.Get(4).CellType = comboBoxCellType3;
            this.spdChangeItem_Sheet1.Columns.Get(4).Label = "Require";
            this.spdChangeItem_Sheet1.Columns.Get(4).Locked = true;
            this.spdChangeItem_Sheet1.Columns.Get(4).Width = 130F;
            this.spdChangeItem_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(20, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(20, 0).Value = "21";
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(21, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(21, 0).Value = "22";
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(22, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(22, 0).Value = "23";
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(23, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(23, 0).Value = "24";
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(24, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(24, 0).Value = "25";
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(25, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(25, 0).Value = "26";
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(26, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(26, 0).Value = "27";
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(27, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(27, 0).Value = "28";
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(28, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(28, 0).Value = "29";
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(29, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(29, 0).Value = "30";
            this.spdChangeItem_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdChangeItem_Sheet1.RowHeader.Columns.Get(0).Width = 23F;
            this.spdChangeItem_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdChangeItem_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdChangeItem_Sheet1.Rows.Get(0).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(1).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(2).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(3).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(4).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(5).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(6).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(7).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(8).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(9).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(10).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(11).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(12).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(13).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(14).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(15).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(16).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(17).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(18).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(19).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(20).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(21).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(22).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(23).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(24).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(25).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(26).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(27).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(28).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(29).Height = 18F;
            this.spdChangeItem_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdChangeItem_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdChangeItem_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // Splitter1
            // 
            this.Splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Splitter1.Location = new System.Drawing.Point(0, 184);
            this.Splitter1.Name = "Splitter1";
            this.Splitter1.Size = new System.Drawing.Size(500, 4);
            this.Splitter1.TabIndex = 0;
            this.Splitter1.TabStop = false;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.spdCheckItem);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(0, 0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(500, 184);
            this.Panel2.TabIndex = 0;
            // 
            // spdCheckItem
            // 
            this.spdCheckItem.AccessibleDescription = "spdCheckItem, Sheet1, Row 0, Column 0, ";
            this.spdCheckItem.BackColor = System.Drawing.SystemColors.Control;
            this.spdCheckItem.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
            this.spdCheckItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdCheckItem.EditModePermanent = true;
            this.spdCheckItem.EditModeReplace = true;
            this.spdCheckItem.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdCheckItem.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCheckItem.HorizontalScrollBar.Name = "";
            this.spdCheckItem.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdCheckItem.HorizontalScrollBar.TabIndex = 8;
            this.spdCheckItem.Location = new System.Drawing.Point(0, 0);
            this.spdCheckItem.Name = "spdCheckItem";
            namedStyle5.BackColor = System.Drawing.SystemColors.Control;
            namedStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle5.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle5.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle5.Renderer = columnHeaderRenderer5;
            namedStyle5.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle6.BackColor = System.Drawing.SystemColors.Control;
            namedStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle6.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle6.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle6.Renderer = rowHeaderRenderer5;
            namedStyle6.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle7.BackColor = System.Drawing.SystemColors.Control;
            namedStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle7.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle7.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle7.Renderer = cornerRenderer2;
            namedStyle7.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle8.BackColor = System.Drawing.SystemColors.Window;
            namedStyle8.CellType = generalCellType2;
            namedStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle8.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle8.Renderer = generalCellType2;
            this.spdCheckItem.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle5,
            namedStyle6,
            namedStyle7,
            namedStyle8});
            this.spdCheckItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdCheckItem.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdCheckItem.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdCheckItem.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdCheckItem_Sheet1});
            this.spdCheckItem.Size = new System.Drawing.Size(500, 184);
            this.spdCheckItem.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdCheckItem.TabIndex = 0;
            this.spdCheckItem.TabStop = false;
            this.spdCheckItem.TextTipDelay = 200;
            this.spdCheckItem.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdCheckItem.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCheckItem.VerticalScrollBar.Name = "";
            this.spdCheckItem.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdCheckItem.VerticalScrollBar.TabIndex = 9;
            this.spdCheckItem.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.spdCheckItem_Change);
            this.spdCheckItem.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdCheckItem_CellClick);
            this.spdCheckItem.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdCheckItem_ButtonClicked);
            this.spdCheckItem.ComboCloseUp += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdCheckItem_ComboCloseUp);
            this.spdCheckItem.ComboDropDown += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdCheckItem_ComboDropDown);
            this.spdCheckItem.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdCheckItem_EditChange);
            // 
            // spdCheckItem_Sheet1
            // 
            this.spdCheckItem_Sheet1.Reset();
            spdCheckItem_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdCheckItem_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdCheckItem_Sheet1.ColumnCount = 5;
            spdCheckItem_Sheet1.RowCount = 30;
            this.spdCheckItem_Sheet1.Cells.Get(0, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(1, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(2, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(3, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(4, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(5, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(6, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(7, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(8, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(9, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(10, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(11, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(12, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(13, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(14, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(15, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(16, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(17, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(18, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(19, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(20, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(20, 3).Locked = true;
            this.spdCheckItem_Sheet1.Cells.Get(21, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(21, 3).Locked = true;
            this.spdCheckItem_Sheet1.Cells.Get(22, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(22, 3).Locked = true;
            this.spdCheckItem_Sheet1.Cells.Get(23, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(23, 3).Locked = true;
            this.spdCheckItem_Sheet1.Cells.Get(24, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(24, 3).Locked = true;
            this.spdCheckItem_Sheet1.Cells.Get(25, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(25, 3).Locked = true;
            this.spdCheckItem_Sheet1.Cells.Get(26, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(26, 3).Locked = true;
            this.spdCheckItem_Sheet1.Cells.Get(27, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(27, 3).Locked = true;
            this.spdCheckItem_Sheet1.Cells.Get(28, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(28, 3).Locked = true;
            this.spdCheckItem_Sheet1.Cells.Get(29, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(29, 3).Locked = true;
            this.spdCheckItem_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCheckItem_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdCheckItem_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCheckItem_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdCheckItem_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Check Item";
            this.spdCheckItem_Sheet1.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Check Flag";
            this.spdCheckItem_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCheckItem_Sheet1.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Check Value";
            this.spdCheckItem_Sheet1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Check Field";
            this.spdCheckItem_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCheckItem_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdCheckItem_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            comboBoxCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            this.spdCheckItem_Sheet1.Columns.Get(0).CellType = comboBoxCellType4;
            this.spdCheckItem_Sheet1.Columns.Get(0).Label = "Check Item";
            this.spdCheckItem_Sheet1.Columns.Get(0).Width = 130F;
            comboBoxCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType5.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.Index;
            comboBoxCellType5.Items = new string[] {
        "",
        "= (Equal)",
        "! (Not Equal)",
        "N (Not Check)",
        "> (Greater than)",
        "< (Less than)",
        ">= (Greater than or Equal)",
        "<= (Less than or Equal)",
        "T> (Time Greater than)",
        "T< (Time Less than)",
        "T>= (Time Greater than or Equal)",
        "T<= (Time Less than or Equal)"};
            comboBoxCellType5.ListWidth = 200;
            this.spdCheckItem_Sheet1.Columns.Get(1).CellType = comboBoxCellType5;
            this.spdCheckItem_Sheet1.Columns.Get(1).Label = "Check Flag";
            this.spdCheckItem_Sheet1.Columns.Get(1).Locked = false;
            this.spdCheckItem_Sheet1.Columns.Get(1).Width = 85F;
            this.spdCheckItem_Sheet1.Columns.Get(2).CellType = textCellType1;
            this.spdCheckItem_Sheet1.Columns.Get(2).Label = "Check Value";
            this.spdCheckItem_Sheet1.Columns.Get(2).Locked = false;
            this.spdCheckItem_Sheet1.Columns.Get(2).Width = 88F;
            this.spdCheckItem_Sheet1.Columns.Get(3).CellType = textCellType2;
            this.spdCheckItem_Sheet1.Columns.Get(3).Locked = false;
            this.spdCheckItem_Sheet1.Columns.Get(3).Width = 22F;
            this.spdCheckItem_Sheet1.Columns.Get(4).Label = "Check Field";
            this.spdCheckItem_Sheet1.Columns.Get(4).Locked = false;
            this.spdCheckItem_Sheet1.Columns.Get(4).Width = 130F;
            this.spdCheckItem_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(20, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(20, 0).Value = "21";
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(21, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(21, 0).Value = "22";
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(22, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(22, 0).Value = "23";
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(23, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(23, 0).Value = "24";
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(24, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(24, 0).Value = "25";
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(25, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(25, 0).Value = "26";
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(26, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(26, 0).Value = "27";
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(27, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(27, 0).Value = "28";
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(28, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(28, 0).Value = "29";
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(29, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(29, 0).Value = "30";
            this.spdCheckItem_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdCheckItem_Sheet1.RowHeader.Columns.Get(0).Width = 23F;
            this.spdCheckItem_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCheckItem_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdCheckItem_Sheet1.Rows.Get(0).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(1).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(2).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(3).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(4).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(5).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(6).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(7).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(8).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(9).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(10).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(11).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(12).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(13).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(14).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(15).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(16).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(17).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(18).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(19).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(20).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(21).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(22).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(23).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(24).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(25).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(26).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(27).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(28).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(29).Height = 18F;
            this.spdCheckItem_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCheckItem_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdCheckItem_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // cdvTableList
            // 
            this.cdvTableList.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvTableList.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableList.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvTableList.Location = new System.Drawing.Point(372, 17);
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
            // cdvValueFieldList
            // 
            this.cdvValueFieldList.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvValueFieldList.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvValueFieldList.BorderHotColor = System.Drawing.Color.Black;
            this.cdvValueFieldList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvValueFieldList.Location = new System.Drawing.Point(372, 17);
            this.cdvValueFieldList.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvValueFieldList.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvValueFieldList.Name = "cdvTableList";
            this.cdvValueFieldList.Size = new System.Drawing.Size(20, 20);
            this.cdvValueFieldList.SmallImageList = null;
            this.cdvValueFieldList.TabIndex = 0;
            this.cdvValueFieldList.TabStop = false;
            this.cdvValueFieldList.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvValueFieldList.Visible = false;
            this.cdvValueFieldList.VisibleColumnHeader = false;
            this.cdvValueFieldList.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvValueFieldList_SelectedItemChanged);
            // 
            // frmRASSetupToolEvent
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRASSetupToolEvent";
            this.Text = "Tool Event Setup";
            this.Activated += new System.EventHandler(this.frmRASSetupToolEvent_Activated);
            this.Load += new System.EventHandler(this.frmRASSetupToolEvent_Load);
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
            this.pnlType.ResumeLayout(false);
            this.pnlType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).EndInit();
            this.grpResource.ResumeLayout(false);
            this.grpResource.PerformLayout();
            this.grpChkItem.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.pnlGeneral.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdChangeItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdChangeItem_Sheet1)).EndInit();
            this.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdCheckItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCheckItem_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValueFieldList)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region "Const Definition"
        private const string ITEM_TOOL_GRP = "TOOL_GRP";
        private const string ITEM_TOOL_SET_ID = "TOOL_SET_ID";
        private const string ITEM_TOOL_SET_LOCATION = "TOOL_SET_LOCATION";
        private const string ITEM_TOOL_STATUS = "TOOL_STATUS";
        private const string ITEM_LOT_ID = "LOT_ID";
        private const string ITEM_SUBLOT_ID = "SUBLOT_ID";
        private const string ITEM_RES_ID = "RES_ID";
        private const string ITEM_SUBRES_ID = "SUBRES_ID";
        private const string ITEM_AREA_ID = "AREA_ID";
        private const string ITEM_SUB_AREA_ID = "SUB_AREA_ID";
        private const string ITEM_TOOL_LOCATION = "TOOL_LOCATION";
        private const string ITEM_VENDOR_ID = "VENDOR_ID";
        private const string ITEM_MAT_ID = "MAT_ID";
        private const string ITEM_MAT_VER = "MAT_VER";
        private const string ITEM_FLOW = "FLOW";
        private const string ITEM_OPER = "OPER";
        private const string ITEM_GRADE = "GRADE";
        
        private const string ITEM_TOOL_STS_ = "TOOL_STS_";
        
        private const string CHECKSHEET = "CHECKSHEET";
        private const string CHANGESHEET = "CHANGESHEET";
        
        private const string CHK_EQUAL = "= (Equal)";
        private const string CHK_NOT_EQUAL = "! (Not Equal)";
        private const string CHK_GREATER = "> (Greater than)";
        private const string CHK_LESS = "< (Less than)";
        private const string CHK_NOT_CHECK = "N (Not Check)";
        private const string CHK_GREATER_EQUAL = ">= (Greater than or Equal)";
        private const string CHK_LESS_EQUAL = "<= (Less than or Equal)";
        private const string CHK_T_GREATER = "T> (Time Greater than)";
        private const string CHK_T_LESS = "T< (Time Less than)";
        private const string CHK_T_GREATER_EQUAL = "T>= (Time Greater than or Equal)";
        private const string CHK_T_LESS_EQUAL = "T<= (Time Less than or Equal)";

        private const string CHG_INCREASE = "+ (Increase)";
        private const string CHG_DECREASE = "- (Decrease)";
        private const string CHG_MULTIPLY = "* (Multiply)";
        private const string CHG_DIVISION = "/ (Division)";
        private const string CHG_MOD = "mod (MOD)";
        private const string CHG_POW = "pow (POW)";
        private const string CHG_TIME = "T (Time)";
        private const string CHG_RESET = "R (Reset)";
        private const string CHG_CHANGE = "Y (Change)";
        private const string CHG_NOT_CHANGE = "N (Not Change)";
        
        private const string FORMAT_ASCII = "Ascii";
        private const string FORMAT_NUMBER = "Number";
        private const string FORMAT_FLOAT = "Float";
        
        #endregion
        
        #region " Variable definition "
        bool b_load_flag;
        string spdSheet;
        private string sBeforeType;
        string sChkCellValue;
        //string sChgCellValue;

        private Dictionary<string, char> h_change_flag;
        private Dictionary<string, char> h_check_flag;
        
        public struct TypeList
        {
            public string prompt;
            public string field;
            public string format;
            public int size;
            public string table_name;
            public string setup_flag;
            public string event_flag;
            public string opt;
        }
        
        public struct ToolTypeArr
        {
            public string tool_type;
            public string system_flag;
            public TypeList[] typelist;
        }
        
        ToolTypeArr ToolTypeInfo;
        
        #endregion
        
        #region " Function definition "
        
        // ClearData()
        //       - Intialize Form Controls
        // Return Value
        //       - None
        // Arguments
        //       - ByVal ProcStep as String (Optional)
        //
        private void ClearData(char ProcStep)
        {
            int i;
            
            try
            {
                if (ProcStep == '1')
                {
                    chkColDefData.Checked = false;
                    chkCleanDefData.Checked = false;
                    spdCheckItem.ActiveSheet.ClearRange(0, 0, 30, 5, true);
                    spdChangeItem.ActiveSheet.ClearRange(0, 0, 30, 5, true);
                    spdCheckItem.ActiveSheet.SetActiveCell(0, 0);
                    spdChangeItem.ActiveSheet.SetActiveCell(0, 0);

                    spdCheckItem.ActiveSheet.Cells[0, 0, 29, 4].Locked = false;
                    spdCheckItem.ActiveSheet.Cells[0, 0, 29, 4].BackColor = Color.White;
                    spdChangeItem.ActiveSheet.Cells[0, 0, 29, 4].Locked = false;
                    spdChangeItem.ActiveSheet.Cells[0, 0, 29, 4].BackColor = Color.White;

                    for (i = 0; i < 30; i++)
                    {
                        spdCheckItem.ActiveSheet.Cells[i, 2].ColumnSpan = 2;
                        //spdChangeItem.ActiveSheet.Cells[i, 2].ColumnSpan = 2;
                    }
                    
                }
                else if (ProcStep == '2')
                {
                    
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            int j;

            switch (MPCF.Trim(FuncName))
            {
                case "Update_Tool_Event":

                    if (MPCF.CheckValue(cdvType, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(txtToolEventID, 1) == false)
                    {
                        return false;
                    }
                    
                    if (ProcStep == MPGC.MP_STEP_CREATE || ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (this.chkCleanDefData.Checked == true && this.chkColDefData.Checked == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(197));
                            this.chkColDefData.Focus();
                            return false;
                        }

                        try
                        {
                            for (j = 0; j < 30; j++)
                            {
                                if (MPCF.Trim(spdCheckItem.ActiveSheet.GetValue(j, 0)) != "")
                                {
                                    if (MPCF.Trim(spdCheckItem.ActiveSheet.GetText(j, 1)) == "")
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(109) + " [Check Flag]");
                                        spdCheckItem.ActiveSheet.SetActiveCell(j, 1);
                                        spdCheckItem.Focus();
                                        return false;
                                    }
                                }

                                if (MPCF.Trim(spdChangeItem.ActiveSheet.GetValue(j, 0)) != "")
                                {
                                    if (MPCF.Trim(spdChangeItem.ActiveSheet.GetText(j, 1)) == "")
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(109) + " [Change Flag]");
                                        spdChangeItem.ActiveSheet.SetActiveCell(j, 1);
                                        spdChangeItem.Focus();
                                        return false;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return false;
                        }
                    }
                    break;
                    
            }
            
            return true;
            
        }
        
        //
        // Update_Tool_Event()
        //       -  Update Tool Event Action Setup
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //        - ByVal c_step As String     : ?ïÏû• Process Step
        //
        private bool Update_Tool_Event(char c_step)
        {
            TRSNode in_node = new TRSNode("Update_Tool_Event_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            TRSNode chg_list;
            TRSNode chk_list;
            ListViewItem item;
            int i, j;
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("TOOL_EVENT_ID", MPCF.Trim(txtToolEventID.Text));
                in_node.AddString("TOOL_EVENT_DESC", MPCF.Trim(txtDesc.Text));
                in_node.AddString("TOOL_TYPE", MPCF.Trim(cdvType.Text));

                in_node.AddChar("SYSTEM_FLAG", (chkSystemFlag.Checked == true ? 'Y' : ' '));
                in_node.AddChar("COLLECT_DEFECT_FLAG", (chkColDefData.Checked == true ? 'Y' : ' '));
                in_node.AddChar("CLEAN_DEFECT_FLAG", (chkCleanDefData.Checked == true ? 'Y' : ' '));
                
                for (j = 0; j < 30; j++)
                {
                    chk_list = in_node.AddNode("CHK_LIST");
                    chg_list = in_node.AddNode("CHG_LIST");

                    chk_list.AddInt("T", 0);
                    chg_list.AddInt("T", 0);

                    if (MPCF.Trim(spdCheckItem.ActiveSheet.GetValue(j, 0)) != "")
                    {
                        if (CheckToolTypeItem(MPCF.Trim(spdCheckItem.ActiveSheet.GetValue(j, 0)), '2') == true)
                        {
                            for (i = 0; i < 30; i++)
                            {
                                if (ToolTypeInfo.typelist[i].prompt == MPCF.Trim(spdCheckItem.ActiveSheet.GetValue(j, 0)))
                                {
                                    chk_list.AddString("CHK_ITEM", ITEM_TOOL_STS_ + ((int)(i + 1)).ToString());
                                    break;
                                }
                            }
                        }
                        else
                        {
                            chk_list.AddString("CHK_ITEM", MPCF.Trim(spdCheckItem.ActiveSheet.GetValue(j, 0)));
                        }

                        chk_list.AddChar("CHK_FLAG", h_check_flag[MPCF.Trim(spdCheckItem.ActiveSheet.Cells[j, 1].Text)]);
                        chk_list.AddString("CHK_VALUE",  MPCF.Trim(spdCheckItem.ActiveSheet.GetValue(j, 2)));
                        
                        if (CheckToolTypeItem(MPCF.Trim(spdCheckItem.ActiveSheet.GetValue(j, 4)), '2') == true)
                        {
                            for (i = 0; i < 30; i++)
                            {
                                if (ToolTypeInfo.typelist[i].prompt == MPCF.Trim(spdCheckItem.ActiveSheet.GetValue(j, 4)))
                                {
                                    chk_list.AddString("CHK_FIELD",ITEM_TOOL_STS_ + ((int)(i + 1)).ToString());
                                    break;
                                }
                            }
                        }
                        else
                        {
                            chk_list.AddString("CHK_FIELD", MPCF.Trim(spdCheckItem.ActiveSheet.GetValue(j, 4)));
                        }
                    }

                    if (MPCF.Trim(spdChangeItem.ActiveSheet.GetValue(j, 0)) != "")
                    {
                        if (CheckToolTypeItem(MPCF.Trim(spdChangeItem.ActiveSheet.GetValue(j, 0)), '2') == true)
                        {
                            for (i = 0; i < 30; i++)
                            {
                                if (ToolTypeInfo.typelist[i].prompt == MPCF.Trim(spdChangeItem.ActiveSheet.GetValue(j, 0)))
                                {
                                    chg_list.AddString("CHG_ITEM", ITEM_TOOL_STS_ + ((int)(i + 1)).ToString());
                                    break;
                                }
                            }
                        }
                        else
                        {
                            chg_list.AddString("CHG_ITEM", MPCF.Trim(spdChangeItem.ActiveSheet.Cells[j, 0].Text)); 
                        }

                        chg_list.AddChar("CHG_FLAG", h_change_flag[spdChangeItem.ActiveSheet.Cells[j, 1].Text]);
                        chg_list.AddChar("CHG_OPT", MPCF.ToChar(spdChangeItem.ActiveSheet.Cells[j, 4].Text));
                        chg_list.AddString("CHG_FIELD", MPCF.Trim(spdChangeItem.ActiveSheet.Cells[j, 2].Tag));
                        if (chg_list.GetString("CHG_FIELD") == "")
                        {
                            chg_list.AddString("CHG_VALUE", MPCF.Trim(spdChangeItem.ActiveSheet.Cells[j, 2].Text));
                        }
                        else
                        {
                            chg_list.AddString("CHG_VALUE", "");
                        }
                    }
                }
            
                if (MPCR.CallService("RAS", "RAS_Update_Tool_Event", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                if (MPGV.gbListAutoRefresh == false)
                {
                    if (c_step == MPGC.MP_STEP_CREATE)
                    {
                        item = lisToolEvent.Items.Add(txtToolEventID.Text, (int)SMALLICON_INDEX.IDX_TOOL_EVENT);
                        item.SubItems.Add(txtDesc.Text);
                        item.Selected = true;
                        lisToolEvent.Sorting = SortOrder.Ascending;
                        lisToolEvent.Sort();
                        item.EnsureVisible();
                    }
                    else if (c_step == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisToolEvent, MPCF.Trim(txtToolEventID.Text), false) == true)
                        {
                            lisToolEvent.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (c_step == MPGC.MP_STEP_DELETE)
                    {
                        if (MPCF.FindListItem(lisToolEvent, MPCF.Trim(txtToolEventID.Text), false) == true)
                        {
                            MPCF.FieldClear(this.pnlRight);
                            lisToolEvent.SelectedItems[0].Remove();
                        }
                    }
                    lblDataCount.Text = MPCF.Trim(lisToolEvent.Items.Count);
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
        
        private bool View_Tool_Type()
        {

            TRSNode in_node = new TRSNode("View_Tool_Type_In");
            TRSNode out_node = new TRSNode("View_Tool_Type_Out");
            int i;
            
            try
            {
                ToolTypeInfo.tool_type = "";

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TOOL_TYPE", cdvType.Text);

                if (MPCR.CallService("RAS", "RAS_View_Tool_Type", in_node, ref out_node) == false)
                {
                    return false;
                }

                ToolTypeInfo.tool_type = out_node.GetString("TOOL_TYPE");
                ToolTypeInfo.system_flag = out_node.GetChar("SYSTEM_FLAG").ToString();

                
                for (i = 0; i < 30; i++)
                {
                    ToolTypeInfo.typelist[i].prompt = out_node.GetList(0)[i].GetString("PROMPT");
                    ToolTypeInfo.typelist[i].field = out_node.GetList(0)[i].GetString("FIELD");
                    ToolTypeInfo.typelist[i].format = out_node.GetList(0)[i].GetChar("FORMAT").ToString();
                    ToolTypeInfo.typelist[i].size = out_node.GetList(0)[i].GetInt("SIZE");
                    ToolTypeInfo.typelist[i].table_name = out_node.GetList(0)[i].GetString("TABLE_NAME");
                    ToolTypeInfo.typelist[i].setup_flag = out_node.GetList(0)[i].GetChar("SETUP_FLAG").ToString();
                    ToolTypeInfo.typelist[i].event_flag = out_node.GetList(0)[i].GetChar("EVENT_FLAG").ToString();
                    ToolTypeInfo.typelist[i].opt = out_node.GetList(0)[i].GetChar("OPT").ToString();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        private bool View_Tool_Event()
        {
            TRSNode in_node = new TRSNode("View_Tool_Event_In");
            TRSNode out_node = new TRSNode("View_Tool_Event_Out");
            List<TRSNode> list_item;
            int i;
            int j;
            
            try
            {
                ClearData('1');

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TOOL_TYPE", cdvType.Text);
                in_node.AddString("TOOL_EVENT_ID", MPCF.Trim(lisToolEvent.SelectedItems[0].Text));

                if (MPCR.CallService("RAS", "RAS_View_Tool_Event", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtToolEventID.Text = out_node.GetString("TOOL_EVENT_ID");
                txtDesc.Text = out_node.GetString("TOOL_EVENT_DESC");


                if (out_node.GetChar("SYSTEM_FLAG") == 'Y')
                {
                    chkSystemFlag.Checked = true;
                }
                else
                {
                    chkSystemFlag.Checked = false;
                }
                
                if (out_node.GetChar("COLLECT_DEFECT_FLAG") == 'Y')
                {
                    chkColDefData.Checked = true;
                }
                else
                {
                    chkColDefData.Checked = false;
                }
                
                if (out_node.GetChar("CLEAN_DEFECT_FLAG") == 'Y')
                {
                    chkCleanDefData.Checked = true;
                }
                else
                {
                    chkCleanDefData.Checked = false;
                }

                list_item = out_node.GetList("CHK_LIST");
                for (i = 0; i < list_item.Count; i++)
                {
                    if(MPCF.Trim(list_item[i].GetString("CHK_ITEM")) == ""
                        && list_item[i].GetChar("CHK_FLAG") == ' '
                        && MPCF.Trim(list_item[i].GetString("CHK_VALUE")) == ""
                        && MPCF.Trim(list_item[i].GetString("CHK_FIELD")) == "")
                    {
                        continue;
                    }

                    if (CheckToolTypeItem(MPCF.Trim(list_item[i].GetString("CHK_ITEM")), '1') == true)
                    {
                        spdCheckItem.ActiveSheet.SetText(i, 0, ToolTypeInfo.typelist[MPCF.ToInt(list_item[i].GetString("CHK_ITEM").Substring(9)) - 1].prompt);
                    }
                    else
                    {
                        spdCheckItem.ActiveSheet.SetText(i, 0, MPCF.Trim(list_item[i].GetString("CHK_ITEM")));
                    }

                    foreach (KeyValuePair<string, char> kv in h_check_flag)
                    {
                        if (kv.Value == list_item[i].GetChar("CHK_FLAG"))
                        {
                            spdCheckItem.ActiveSheet.Cells[i, 1].Text = kv.Key;
                            break;
                        }
                    }

                    if (CheckToolTypeItem(MPCF.Trim(list_item[i].GetString("CHK_FIELD")), '1') == true)
                    {
                        spdCheckItem.ActiveSheet.SetText(i, 4, ToolTypeInfo.typelist[MPCF.ToInt(list_item[i].GetString("CHK_FIELD").Substring(9)) - 1].prompt);
                    }
                    else
                    {
                        spdCheckItem.ActiveSheet.SetText(i, 4, MPCF.Trim(list_item[i].GetString("CHK_FIELD")));
                    }
                    
                    if (MPCF.Trim(list_item[i].GetString("CHK_ITEM")) != "")
                    {
                        spdCheckItem.ActiveSheet.Cells[i, 1].Locked = false;
                    }
                    if (MPCF.Trim(list_item[i].GetString("CHK_FIELD")) != "")
                    {
                        spdCheckItem.ActiveSheet.Cells[i, 4].Locked = false;
                    }
                    
                    if (CheckToolTypeItem(MPCF.Trim(list_item[i].GetString("CHK_ITEM")), '1') == true)
                    {
                        for (j = 0; j <= 29; j++)
                        {
                            if (ToolTypeInfo.typelist[MPCF.ToInt(list_item[i].GetString("CHK_ITEM").Substring(9)) - 1].prompt == ToolTypeInfo.typelist[j].prompt)
                            {
                                TextLength(i, ToolTypeInfo.typelist[j].size, CHECKSHEET);
                                break;
                            }
                        }
                    }
                    else
                    {
                        View_SheetControl(list_item[i].GetString("CHK_ITEM"), i, CHECKSHEET);
                    }
                    
                    spdCheckItem.ActiveSheet.SetText(i, 2, list_item[i].GetString("CHK_VALUE"));
                    if (list_item[i].GetChar("CHK_FLAG") == 'N')
                    {
                        CellSpan(i, 2, CHECKSHEET);
                        spdCheckItem.ActiveSheet.Cells[i, 2].Locked = true;
                    }
                    else
                    {
                        spdCheckItem.ActiveSheet.Cells[i, 2].Locked = false;
                    }
                    
                }

                list_item = out_node.GetList("CHG_LIST");
                for (i = 0; i < list_item.Count; i++)
                {
                    if (MPCF.Trim(list_item[i].GetString("CHG_ITEM")) == ""
                        && list_item[i].GetChar("CHG_FLAG") == ' '
                        && MPCF.Trim(list_item[i].GetString("CHG_VALUE")) == ""
                        && MPCF.Trim(list_item[i].GetString("CHG_FIELD")) == ""
                        && list_item[i].GetChar("CHG_OPT") == ' ')
                    {
                        continue;
                    }

                    /* CHANGE_ITEM */
                    if (CheckToolTypeItem(MPCF.Trim(list_item[i].GetString("CHG_ITEM")), '1') == true)
                    {
                        spdChangeItem.ActiveSheet.SetText(i, 0, ToolTypeInfo.typelist[MPCF.ToInt(list_item[i].GetString("CHG_ITEM").Substring(9)) - 1].prompt);
                    }
                    else
                    {
                        spdChangeItem.ActiveSheet.SetText(i, 0, MPCF.Trim(list_item[i].GetString("CHG_ITEM")));
                    }

                    /* CHANGE_FLAG */
                    foreach (KeyValuePair<string, char> kv in h_change_flag)
                    {
                        if (kv.Value == list_item[i].GetChar("CHG_FLAG"))
                        {
                            spdChangeItem.ActiveSheet.Cells[i, 1].Text = kv.Key;
                            break;
                        }
                    }

                    if (MPCF.Trim(list_item[i].GetString("CHG_ITEM")) != "")
                    {
                        spdChangeItem.ActiveSheet.Cells[i, 1].Locked = false;
                        spdChangeItem.ActiveSheet.Cells[i, 2].Locked = false;
                    }
                    
                    if (CheckToolTypeItem(MPCF.Trim(list_item[i].GetString("CHG_ITEM")), '1') == true)
                    {
                        for (j = 0; j <= 29; j++)
                        {
                            if (ToolTypeInfo.typelist[MPCF.ToInt(list_item[i].GetString("CHG_ITEM").Substring(9)) - 1].prompt == ToolTypeInfo.typelist[j].prompt)
                            {
                                TextLength(i, ToolTypeInfo.typelist[j].size, CHANGESHEET);
                                break;
                            }
                        }
                    }
                    else
                    {
                        View_SheetControl(list_item[i].GetString("CHG_ITEM"), i, CHANGESHEET);
                    }

                    /* CHANGE_VALUE, CHANGE_FIELD */
                    if (list_item[i].GetString("CHG_VALUE") == "")
                    {
                        spdChangeItem.ActiveSheet.SetTag(i, 2, list_item[i].GetString("CHG_FIELD"));
                        spdChangeItem.ActiveSheet.SetText(i, 2, list_item[i].GetString("CHG_FIELD_DESC"));
                    }
                    else
                    {
                        spdChangeItem.ActiveSheet.SetText(i, 2, list_item[i].GetString("CHG_VALUE"));
                    }

                    /* REQUIRE_FLAG */
                    if (MPCF.Trim(list_item[i].GetString("CHG_ITEM")) != "")
                    {
                        spdChangeItem.ActiveSheet.Cells[i, 4].Text = MPCF.Trim(list_item[i].GetChar("CHG_OPT"));
                        SetChangeOption(i);
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
        
        //Cell??Span?òÍ∏∞
        private void CellSpan(int iRow, int iColSpan, string sheet)
        {
            
            FarPoint.Win.Spread.Cell sheetData;
            if (sheet == CHECKSHEET)
            {
                sheetData = spdCheckItem.ActiveSheet.Cells[iRow, 2];
            }
            else
            {
                sheetData = spdChangeItem.ActiveSheet.Cells[iRow, 2];
            }
            
            sheetData.ColumnSpan = iColSpan;
            
        }
        
        //Cell Text??Í∏∏Ïù¥Ï£ºÍ∏∞
        private void TextLength(int iRow, int iLength, string sheet)
        {
            
            FarPoint.Win.Spread.CellType.TextCellType txt = new FarPoint.Win.Spread.CellType.TextCellType();
            txt.MaxLength = iLength;
            if (sheet == CHECKSHEET)
            {
                spdCheckItem.ActiveSheet.Cells[iRow, 2].CellType = txt;
                spdCheckItem.ActiveSheet.Cells[iRow, 2].Text = "";
            }
            else
            {

                /***  #1069  Developing enhancement  ( 2012-11-21 ) **/
                /**  ±‚∫ª ∞™ Combo Type ¿∏∑Œ ∫Ø∞Ê¿ª ¿ß«ÿ ¡÷ºÆ√≥∏Æ     **/
                //spdChangeItem.ActiveSheet.Cells[iRow, 2].CellType = txt;

                spdChangeItem.ActiveSheet.Cells[iRow, 2].Text = "";
            }
            
        }
        
        //Cell??Î≤ÑÌäºÎßåÎì§Í∏?
        private void SheetBtn(int iRow, string sheet)
        {
            FarPoint.Win.Spread.CellType.ButtonCellType sheetButton = new FarPoint.Win.Spread.CellType.ButtonCellType();
            sheetButton.Text = "...";
            if (sheet == CHECKSHEET)
            {
                spdCheckItem.ActiveSheet.Cells[iRow, 3].CellType = sheetButton;
            }
            else
            {
                spdChangeItem.ActiveSheet.Cells[iRow, 3].ResetCellType();
                spdChangeItem.ActiveSheet.Cells[iRow, 3].CellType = sheetButton;
            }
            
        }

        //Cell¿« Modify(Span, GCMπˆ∆∞, Text±Ê¿Ã, Textº˝¿⁄≈∏¿‘ªÁ¿Ã¡Ó µÓ¿ª º≥¡§«—¥Ÿ.)
        private void SheetModity(string sGCM, int row, string format, int length, string sheetType)
        {
            
            if (sheetType == CHECKSHEET)
            {
                spdCheckItem.ActiveSheet.Cells[row, 2].Text = "";
                
                if (sGCM == "Y")
                {
                    spdCheckItem.ActiveSheet.Cells[row, 3].Locked = false;
                    CellSpan(row, 1, CHECKSHEET);
                    SheetBtn(row, CHECKSHEET);
                }
                else
                {
                    spdCheckItem.ActiveSheet.Cells[row, 3].Locked = true;
                    CellSpan(row, 2, CHECKSHEET);
                }
                
                TextLength(row, length, CHECKSHEET);
                
            }
            else
            {
                spdChangeItem.ActiveSheet.Cells[row, 2].Text = "";
                
                //if (sGCM == "Y")
                //{
                //    spdChangeItem.ActiveSheet.Cells[row, 3].Locked = false;
                //    CellSpan(row, 1, CHANGESHEET);
                //    SheetBtn(row, CHANGESHEET);
                //}
                //else
                //{
                //    spdChangeItem.ActiveSheet.Cells[row, 3].Locked = true;
                //    CellSpan(row, 2, CHANGESHEET);
                //}
                
                TextLength(row, length, CHANGESHEET);
            }
            
        }
        
        /// <summary>
        /// Standard ToolType Status
        /// </summary>
        /// <param name="list"></param>
        private void InitToolItemList(List<string> list)
        {
            list.Add("");
            list.Add("TOOL_GRP");
            list.Add("TOOL_SET_ID");
            list.Add("TOOL_SET_LOCATION");
            list.Add("TOOL_STATUS");
            list.Add("LOT_ID");
            list.Add("SUBLOT_ID");
            list.Add("RES_ID");
            list.Add("SUBRES_ID");
            list.Add("AREA_ID");
            list.Add("SUB_AREA_ID");
            list.Add("TOOL_LOCATION");
            list.Add("VENDOR_ID");
            list.Add("MAT_ID");
            list.Add("MAT_VER");
            list.Add("FLOW");
            list.Add("OPER");
            list.Add("GRADE");
        }

        /// <summary>
        /// Standard ToolType Status
        /// </summary>
        /// <param name="control"></param>
        private void InitToolItemList(Control control)
        {
            if (control is ListView)
            {
                //((ListView)control).Items.Clear();

                ListViewItem[] items = new ListViewItem[17];

                items[0] = new ListViewItem(ITEM_TOOL_GRP, (int)SMALLICON_INDEX.IDX_TOOL);
                items[1] = new ListViewItem(ITEM_TOOL_SET_ID, (int)SMALLICON_INDEX.IDX_TOOL);
                items[2] = new ListViewItem(ITEM_TOOL_SET_LOCATION, (int)SMALLICON_INDEX.IDX_TOOL);
                items[3] = new ListViewItem(ITEM_TOOL_STATUS, (int)SMALLICON_INDEX.IDX_TOOL);
                items[4] = new ListViewItem(ITEM_LOT_ID, (int)SMALLICON_INDEX.IDX_TOOL);
                items[5] = new ListViewItem(ITEM_SUBLOT_ID, (int)SMALLICON_INDEX.IDX_TOOL);
                items[6] = new ListViewItem(ITEM_RES_ID, (int)SMALLICON_INDEX.IDX_TOOL);
                items[7] = new ListViewItem(ITEM_SUBRES_ID, (int)SMALLICON_INDEX.IDX_TOOL);
                items[8] = new ListViewItem(ITEM_AREA_ID, (int)SMALLICON_INDEX.IDX_TOOL);
                items[9] = new ListViewItem(ITEM_SUB_AREA_ID, (int)SMALLICON_INDEX.IDX_TOOL);
                items[10] = new ListViewItem(ITEM_TOOL_LOCATION, (int)SMALLICON_INDEX.IDX_TOOL);
                items[11] = new ListViewItem(ITEM_VENDOR_ID, (int)SMALLICON_INDEX.IDX_TOOL);
                items[12] = new ListViewItem(ITEM_MAT_ID, (int)SMALLICON_INDEX.IDX_TOOL);
                items[13] = new ListViewItem(ITEM_MAT_VER, (int)SMALLICON_INDEX.IDX_TOOL);
                items[14] = new ListViewItem(ITEM_FLOW, (int)SMALLICON_INDEX.IDX_TOOL);
                items[15] = new ListViewItem(ITEM_OPER, (int)SMALLICON_INDEX.IDX_TOOL);
                items[16] = new ListViewItem(ITEM_GRADE, (int)SMALLICON_INDEX.IDX_TOOL);

                items[0].SubItems.Add("Tool Group");
                items[1].SubItems.Add("Tool Set ID");
                items[2].SubItems.Add("Tool Set Location");
                items[3].SubItems.Add("Tool Status");
                items[4].SubItems.Add("Lot ID");
                items[5].SubItems.Add("Sub Lot ID");
                items[6].SubItems.Add("Resource");
                items[7].SubItems.Add("Sub Resource");
                items[8].SubItems.Add("Area ID");
                items[9].SubItems.Add("Sub Area ID");
                items[10].SubItems.Add("Tool Location");
                items[11].SubItems.Add("Vendor");
                items[12].SubItems.Add("Material");
                items[13].SubItems.Add("Material Ver");
                items[14].SubItems.Add("Flow");
                items[15].SubItems.Add("Operation");
                items[16].SubItems.Add("Grade");

                foreach (ListViewItem item in items)
                {
                    item.SubItems[0].Tag = item.SubItems[0].Text;
                }

                ((ListView)control).Items.AddRange(items);
            }
        }
        
        /// <summary>
        /// Init ComboboxCell
        /// </summary>
        /// <returns></returns>
        private bool InitToolItemSheet()
        {
            int i;
            FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType;

            List<string> sCheckList = new List<string>();
            List<string> sChangeList = new List<string>();
            string[] ItemList = null;
            
            try
            {
                //Get Tool Status List of Current ToolType
                if (View_Tool_Type() == false)
                {
                    return false;
                }

                //1. Standard Tool Status List
                InitToolItemList(sCheckList);
                InitToolItemList(sChangeList);

                //2. Additional Tool Status List (by User Setup)
                for (i = 0; i < 30; i++)
                {
                    if (MPCF.Trim(ToolTypeInfo.typelist[i].prompt) != "")
                    {
                        sCheckList.Add(ToolTypeInfo.typelist[i].prompt);
                        
                        if (ToolTypeInfo.typelist[i].event_flag == "Y")
                        {
                            sChangeList.Add(ToolTypeInfo.typelist[i].prompt);
                        }
                    }
                }
                
                //CheckSheet
                ItemList = sCheckList.ToArray();
                cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                cboCellType.Items = ItemList;
                spdCheckItem.ActiveSheet.Columns.Get(0).CellType = cboCellType;
                spdCheckItem.ActiveSheet.Columns.Get(4).CellType = cboCellType;

                //ChangeSheet
                ItemList = sChangeList.ToArray();
                cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                cboCellType.Items = ItemList;
                spdChangeItem.ActiveSheet.Columns.Get(0).CellType = cboCellType;
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        //?ïÏùò???ÑÏù¥?úÏóê ?∞Îùº ?¨Ìä∏Î•?Modify?úÎã§.
        private void View_SheetControl(string chkItem, int row, string sheetType)
        {
            int i;
            
            try
            {
                switch (chkItem)
                {
                    case ITEM_TOOL_LOCATION:
                        SheetModity("N", row, "A", 20, sheetType);
                        break;

                    case ITEM_VENDOR_ID:
                        SheetModity("N", row, "A", 20, sheetType);
                        break;
                    
                    case ITEM_MAT_ID:
                        SheetModity("N", row, "A", 30, sheetType);
                        break;

                    case ITEM_MAT_VER:
                        SheetModity("N", row, "N", 6, sheetType);
                        break;

                    case ITEM_FLOW:
                        SheetModity("N", row, "A", 20, sheetType);
                        break;
                    
                    case ITEM_OPER:
                        SheetModity("N", row, "A", 10, sheetType);
                        break;
                    
                    case ITEM_TOOL_SET_ID:
                        SheetModity("N", row, "A", 20, sheetType);
                        break;
                    
                    case ITEM_TOOL_SET_LOCATION:
                        SheetModity("N", row, "A", 20, sheetType);
                        break;
                    
                    case ITEM_LOT_ID:
                        SheetModity("N", row, "A", 25, sheetType);
                        break;
                    
                    case ITEM_SUBLOT_ID:
                        SheetModity("N", row, "A", 30, sheetType);
                        break;
                    
                    case ITEM_RES_ID:
                        SheetModity("N", row, "A", 20, sheetType);
                        break;
                    
                    case ITEM_SUBRES_ID:
                        SheetModity("N", row, "A", 20, sheetType);
                        break;
                    
                    case "":
                        SheetModity("N", row, "A", 0, sheetType);
                        break;
                    
                    case ITEM_TOOL_GRP:
                        SheetModity("Y", row, "A", 20, sheetType);
                        break;
                    
                    case ITEM_TOOL_STATUS:
                        SheetModity("Y", row, "A", 10, sheetType);
                        break;
                    
                    case ITEM_AREA_ID:
                        SheetModity("Y", row, "A", 20, sheetType);
                        break;
                    
                    case ITEM_SUB_AREA_ID:
                        SheetModity("Y", row, "A", 20, sheetType);
                        break;
                    
                    case ITEM_GRADE:
                        SheetModity("Y", row, "A", 1, sheetType);
                        break;
                    
                    default:
                        if (sheetType == CHECKSHEET)
                        {
                            for (i = 0; i < 30; i++)
                            {
                                if (ToolTypeInfo.typelist[i].prompt == spdCheckItem.ActiveSheet.Cells[row, 0].Text)
                                {
                                    if (ToolTypeInfo.typelist[i].table_name != "")
                                    {
                                        SheetModity("Y", row, ToolTypeInfo.typelist[i].format, ToolTypeInfo.typelist[i].size, sheetType);
                                    }
                                    else
                                    {
                                        SheetModity("N", row, ToolTypeInfo.typelist[i].format, ToolTypeInfo.typelist[i].size, sheetType);
                                    }
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (i = 0; i < 30; i++)
                            {
                                if (ToolTypeInfo.typelist[i].prompt == spdChangeItem.ActiveSheet.Cells[row, 0].Text)
                                {
                                    if (ToolTypeInfo.typelist[i].table_name != "")
                                    {
                                        SheetModity("Y", row, ToolTypeInfo.typelist[i].format, ToolTypeInfo.typelist[i].size, sheetType);
                                    }
                                    else
                                    {
                                        SheetModity("N", row, ToolTypeInfo.typelist[i].format, ToolTypeInfo.typelist[i].size, sheetType);
                                    }
                                    break;
                                }
                            }
                        }
                        break;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        //GCM DataÎ•?Í∞Ä?∏Ïò®??
        private bool View_GCMCodeList(string chkItem, int row)
        {
            int i;
            
            try
            {
                switch (chkItem)
                {
                    case ITEM_TOOL_GRP:
                        
                        BASLIST.ViewGCMDataList(cdvTableList.GetListView, '1', MPGC.MP_RAS_TOOL_GRP);
                        break;
                    case ITEM_TOOL_STATUS:
                        
                        BASLIST.ViewGCMDataList(cdvTableList.GetListView, '1', MPGC.MP_RAS_TOOL_STATUS);
                        break;
                    case ITEM_AREA_ID:

                        BASLIST.ViewGCMDataList(cdvTableList.GetListView, '1', MPGC.MP_RAS_AREA_CODE);
                        break;
                    case ITEM_SUB_AREA_ID:

                        BASLIST.ViewGCMDataList(cdvTableList.GetListView, '1', MPGC.MP_RAS_SUBAREA_CODE);
                        break;
                    case ITEM_GRADE:

                        BASLIST.ViewGCMDataList(cdvTableList.GetListView, '1', MPGC.MP_RAS_TOOL_GRADE);
                        break;
                    default:
                        
                        for (i = 0; i < 30; i++)
                        {
                            if (ToolTypeInfo.typelist[i].prompt == chkItem)
                            {
                                if (MPCF.Trim(ToolTypeInfo.typelist[i].table_name) != "")
                                {
                                    BASLIST.ViewGCMDataList(cdvTableList.GetListView, '1', ToolTypeInfo.typelist[i].table_name);
                                    cdvTableList.InsertEmptyRow(0, 1);
                                    return true;
                                }
                            }
                        }
                        cdvTableList.AddEmptyRow(1);
                        break;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        //?ïÏùò??Tool Type?∏Ï? ?ïÏù∏?úÎã§.
        private bool CheckToolTypeItem(string chkItem, char c_step)
        {
            int i;
            if (chkItem == "")
            {
                return false;
            }
            if (c_step == '1')
            {
                if (chkItem.Length >= 10)
                {
                    if (chkItem.Substring(0, 9) == ITEM_TOOL_STS_)
                    {
                        return true;
                    }
                }
            }
            else if (c_step == '2')
            {
                for (i = 0; i < 30; i++)
                {
                    if (ToolTypeInfo.typelist[i].prompt == MPCF.Trim(chkItem))
                    {
                        return true;
                    }
                }
            }
            
            return false;
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvType;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }

        public virtual bool View_ValueFieldList(Control control)
        {
            return View_ValueFieldList(control, null);
        }
        public virtual bool View_ValueFieldList(Control control, string selected_item_name)
        {
            string table_name;
            int i;

            try
            {
                if (control is ListView)
                {
                    /* GCM Data */
                    if (MPCF.Trim(selected_item_name) != "")
                    {
                        switch (selected_item_name)
                        {
                            case ITEM_TOOL_GRP:
                                table_name = MPGC.MP_RAS_TOOL_GRP;
                                break;
                            case ITEM_TOOL_STATUS:
                                table_name = MPGC.MP_RAS_TOOL_STATUS;
                                break;
                            case ITEM_AREA_ID:
                                table_name = MPGC.MP_RAS_AREA_CODE;
                                break;
                            case ITEM_SUB_AREA_ID:
                                table_name = MPGC.MP_RAS_SUBAREA_CODE;
                                break;
                            case ITEM_GRADE:
                                table_name = MPGC.MP_RAS_TOOL_GRADE;
                                break;
                            default:
                                table_name = MPCF.Trim(GetItemType(selected_item_name).table_name);
                                break;
                        }

                        if (table_name != "")
                        {
                            ListView lisTemp = new ListView();
                            lisTemp.Columns.Add("Code");
                            lisTemp.Columns.Add("Desc");
                            if (BASLIST.ViewGCMDataList(lisTemp, '1', table_name) == true)
                            {
                                for (i = 0; i < lisTemp.Items.Count; i++)
                                {
                                    ListViewItem itemX = new ListViewItem(lisTemp.Items[i].Text, lisTemp.Items[i].ImageIndex);
                                    itemX.SubItems.Add(lisTemp.Items[i].SubItems[1]);
                                    ((ListView)control).Items.Add(itemX);
                                }
                            }
                        }
                    }

                    /* Fixed Status */
                    InitToolItemList(control);

                    /* Custom Status */
                    for (i = 0; i < 30; i++)
                    {
                        if (ToolTypeInfo.typelist[i].prompt == "") continue;

                        ListViewItem itemX = new ListViewItem(ToolTypeInfo.typelist[i].prompt, (int)SMALLICON_INDEX.IDX_TOOL);
                        itemX.SubItems.Add(ToolTypeInfo.typelist[i].field);
                        itemX.SubItems[0].Tag = ToolTypeInfo.typelist[i].field;

                        ((ListView)control).Items.Add(itemX);
                    }


                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        public virtual TypeList GetItemType(string item_name)
        {
            for (int i = 0; i < 30; i++)
            {
                if (ToolTypeInfo.typelist[i].prompt == item_name)
                {
                    return ToolTypeInfo.typelist[i];
                }
            }

            return new TypeList();
        }

        private void SetChangeFlag()
        {
            h_change_flag = new Dictionary<string, char>();
            h_change_flag.Add(CHG_INCREASE, '+');
            h_change_flag.Add(CHG_DECREASE, '-');
            h_change_flag.Add(CHG_MULTIPLY, '*');
            h_change_flag.Add(CHG_DIVISION, '/');
            h_change_flag.Add(CHG_MOD, 'M');
            h_change_flag.Add(CHG_POW, 'P');
            h_change_flag.Add(CHG_RESET, 'R');
            h_change_flag.Add(CHG_CHANGE, 'Y');
            h_change_flag.Add(CHG_NOT_CHANGE, 'N');
            h_change_flag.Add(CHG_TIME, 'T');
        }

        private void SetCheckFlag()
        {
            h_check_flag = new Dictionary<string, char>();
            h_check_flag.Add(CHK_EQUAL, '=');
            h_check_flag.Add(CHK_NOT_EQUAL, '!');
            h_check_flag.Add(CHK_NOT_CHECK, 'N');
            h_check_flag.Add(CHK_GREATER, '>');
            h_check_flag.Add(CHK_LESS, '<');
            h_check_flag.Add(CHK_GREATER_EQUAL, 'G');
            h_check_flag.Add(CHK_LESS_EQUAL, 'L');
            h_check_flag.Add(CHK_T_GREATER, 'A');
            h_check_flag.Add(CHK_T_LESS, 'B');
            h_check_flag.Add(CHK_T_GREATER_EQUAL, 'C');
            h_check_flag.Add(CHK_T_LESS_EQUAL, 'D');
        }

        private void SetChangeOption(int iRow)
        {
            if (spdChangeItem.ActiveSheet.Cells[iRow, 0].Text != "")
            {
                switch (spdChangeItem.ActiveSheet.Cells[iRow, 1].Text)
                {
                    case CHG_CHANGE:
                        if (spdChangeItem.ActiveSheet.Cells[iRow, 2].Text == "")
                        {
                            spdChangeItem.ActiveSheet.Cells[iRow, 4].Locked = false;
                            spdChangeItem.ActiveSheet.Cells[iRow, 4].BackColor = Color.White;
                        }
                        else
                        {
                            spdChangeItem.ActiveSheet.Cells[iRow, 4].Text = "";
                            spdChangeItem.ActiveSheet.Cells[iRow, 4].Locked = true;
                            spdChangeItem.ActiveSheet.Cells[iRow, 4].BackColor = Color.WhiteSmoke;
                        }
                        break;
                    case "":
                            spdChangeItem.ActiveSheet.Cells[iRow, 4].Locked = false;
                            spdChangeItem.ActiveSheet.Cells[iRow, 4].BackColor = Color.White;
                        break;
                    default:
                            spdChangeItem.ActiveSheet.Cells[iRow, 4].Text = "";
                            spdChangeItem.ActiveSheet.Cells[iRow, 4].Locked = true;
                            spdChangeItem.ActiveSheet.Cells[iRow, 4].BackColor = Color.WhiteSmoke;
                        break;
                }
            }
            else
            {
                spdChangeItem.ActiveSheet.Cells[iRow, 4].Locked = false;
                spdChangeItem.ActiveSheet.Cells[iRow, 4].BackColor = Color.White;
            }
        }

        #endregion

        private void frmRASSetupToolEvent_Load(object sender, System.EventArgs e)
        {
            
            MPCF.FieldClear(this);
            MPCF.InitListView(lisToolEvent);
            ToolTypeInfo.typelist = new TypeList[30];
            
        }
        
        private void frmRASSetupToolEvent_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                cdvType.Focus();
                lblDataCount.Text = "";

                SetChangeFlag();
                SetCheckFlag();
                b_load_flag = true;
            }
            
        }
        
        private void cdvType_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            cdvType.Init();
            MPCF.InitListView(cdvType.GetListView);
            cdvType.Columns.Add("Tool Type", 50, HorizontalAlignment.Left);
            cdvType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvType.SelectedSubItemIndex = 0;
            
            RASLIST.ViewToolTypeList(cdvType.GetListView, '1', 'N', 'N', null);
            
        }
        
        private void cdvType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                ClearData('1');
                
                lblDataCount.Text = "";
                MPCF.InitListView(lisToolEvent);
                
                InitToolItemSheet();
                
                if (RASLIST.ViewToolEventList(lisToolEvent, '1', cdvType.Text, 'N', null) == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisToolEvent.Items.Count);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvTableList_SelectedItemChanged(System.Object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            
            if (spdSheet == CHECKSHEET)
            {
                spdCheckItem.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
                spdCheckItem.ActiveSheet.Cells[e.Row, 4].Text = "";
            }
            else
            {
                spdChangeItem.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
                SetChangeOption(e.Row);
            }
        }
        
        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("Update_Tool_Event", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Tool_Event(MPGC.MP_STEP_CREATE) == false)
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
                if (CheckCondition("Update_Tool_Event", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Tool_Event(MPGC.MP_STEP_UPDATE) == false)
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
                if (CheckCondition("Update_Tool_Event", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Tool_Event(MPGC.MP_STEP_DELETE) == true)
                    {
                        
                        if (MPGV.gbListAutoRefresh == true)
                        {
                            MPCF.FieldClear(this.pnlRight);
                            btnRefresh.PerformClick();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            
            MPCF.ExportToExcel(lisToolEvent, this.Text, "");
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            string SelectedItem;
            
            try
            {
                SelectedItem = MPCF.Trim(txtToolEventID.Text);
                spdCheckItem.ActiveSheet.ClearRange(0, 0, 30, 5, true);
                spdChangeItem.ActiveSheet.ClearRange(0, 0, 30, 5, true);
                MPCF.InitListView(lisToolEvent);
                lblDataCount.Text = "";
                
                if (RASLIST.ViewToolEventList(lisToolEvent, '1', cdvType.Text, 'N', null) == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisToolEvent.Items.Count);
                }
                
                if (lisToolEvent.Items.Count > 0 && SelectedItem != "")
                {
                    MPCF.FindListItem(lisToolEvent, SelectedItem, false);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void lisToolEvent_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                ClearData('1');
                
                if (lisToolEvent.SelectedItems.Count > 0)
                {
                    txtToolEventID.Text = lisToolEvent.SelectedItems[0].Text;
                    
                    View_Tool_Event();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void spdChangeItem_ButtonClicked(System.Object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column == 3)
                {
                    cdvValueFieldList.Init();
                    cdvValueFieldList.ViewPosition = Control.MousePosition;
                    MPCF.InitListView(cdvValueFieldList.GetListView);
                    cdvValueFieldList.Columns.Add("Value Field", 100, HorizontalAlignment.Left);
                    cdvValueFieldList.Columns.Add("Field Desc", 100, HorizontalAlignment.Left);

                    View_ValueFieldList(cdvValueFieldList.GetListView, spdChangeItem.ActiveSheet.GetText(e.Row, 0));

                    cdvValueFieldList.InsertEmptyRow(0, 1);

                    //spdSheet = CHANGESHEET;
                    if (cdvValueFieldList.ShowPopupList(e.Row, e.Column) == false)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void spdCheckItem_ButtonClicked(System.Object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string sGCMData;
            
            sGCMData = spdCheckItem.ActiveSheet.Cells[e.Row, 0].Text;
            
            if (spdCheckItem.ActiveSheet.Cells[e.Row, 0].Text != "")
            {
                cdvTableList.Init();
                cdvTableList.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvTableList.GetListView);
                cdvTableList.Columns.Add("Table List", 100, HorizontalAlignment.Left);
                cdvTableList.Columns.Add("Table Desc", 100, HorizontalAlignment.Left);

                // Modified by DM KIM 2013.09.02
                // Cell Text √ ±‚»≠∑Œ ¿Œ«œø© ¡÷ºÆ √≥∏Æ
                //View_SheetControl(sGCMData, e.Row, CHECKSHEET);

                View_GCMCodeList(sGCMData, e.Row);
                spdSheet = CHECKSHEET;

                cdvTableList.InsertEmptyRow(0, 1);

                if (cdvTableList.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
            }
        }
        
        private void spdChangeItem_ComboDropDown(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            sBeforeType = e.EditingControl.Text;
        }
        
        private void spdCheckItem_ComboDropDown(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            sBeforeType = e.EditingControl.Text;
        }
        
        private void spdCheckItem_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            int i;
            int j = 0;
            int k;
            string sTempText;
            string[] CheckItem = null;
            List<string> sCheckList = new List<string>();
            FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType;
            
            try
            {
                if (e.Column == 0)
                {
                    if (sBeforeType != e.EditingControl.Text)
                    {
                        spdCheckItem.ActiveSheet.Cells[e.Row, 1].Text = "";
                        spdCheckItem.ActiveSheet.Cells[e.Row, 2].Text = "";
                        spdCheckItem.ActiveSheet.Cells[e.Row, 4].Text = "";
                        if (spdCheckItem.ActiveSheet.Cells[e.Row, 0].Text == "")
                        {
                            spdCheckItem.ActiveSheet.Cells[e.Row, 1].Locked = true;
                        }
                        else
                        {
                            spdCheckItem.ActiveSheet.Cells[e.Row, 1].Locked = false;
                            spdCheckItem.ActiveSheet.Cells[e.Row, 2].Locked = false;
                            spdCheckItem.ActiveSheet.Cells[e.Row, 4].Locked = false;
                        }
                        
                        View_SheetControl(spdCheckItem.ActiveSheet.Cells[e.Row, 0].Text, e.Row, CHECKSHEET);
                    }
                    
                    if (spdCheckItem.ActiveSheet.Cells[e.Row, 1].Text == "")
                    {
                        spdCheckItem.ActiveSheet.Cells[e.Row, 2].Locked = true;
                        spdCheckItem.ActiveSheet.Cells[e.Row, 3].Locked = true;
                    }
                    
                }
                else if (e.Column == 1)
                {
                    if (spdCheckItem.ActiveSheet.Cells[e.Row, 1].Text == CHK_NOT_CHECK)
                    {
                        CellSpan(e.Row, 2, CHECKSHEET);
                        spdCheckItem.ActiveSheet.Cells[e.Row, 2].Text = "";
                        spdCheckItem.ActiveSheet.Cells[e.Row, 4].Text = "";
                        spdCheckItem.ActiveSheet.Cells[e.Row, 2].Locked = true;
                        spdCheckItem.ActiveSheet.Cells[e.Row, 3].Locked = true;
                        spdCheckItem.ActiveSheet.Cells[e.Row, 4].Locked = true;
                    }
                    else
                    {
                        spdCheckItem.ActiveSheet.Cells[e.Row, 2].Locked = false;
                        spdCheckItem.ActiveSheet.Cells[e.Row, 3].Locked = false;
                        spdCheckItem.ActiveSheet.Cells[e.Row, 4].Locked = false;
                        View_SheetControl(spdCheckItem.ActiveSheet.Cells[e.Row, 0].Text, e.Row, CHECKSHEET);
                    }
                }
                else if (e.Column == 2)
                {
                    if (spdCheckItem.ActiveSheet.Cells[e.Row, 1].Text == CHK_NOT_CHECK)
                    {
                        spdCheckItem.ActiveSheet.Cells[e.Row, 2].Text = "";
                    }
                }
                
                if (spdCheckItem.ActiveSheet.Cells[e.Row, 0].Text != "")
                {
                    
                    if (e.Column == 4)
                    {
                        
                        if (spdCheckItem.ActiveSheet.Cells[e.Row, 0].Text == spdCheckItem.ActiveSheet.Cells[e.Row, 4].Text)
                        {
                            spdCheckItem.ActiveSheet.Cells[e.Row, 4].Text = "";
                        }
                        if (spdCheckItem.ActiveSheet.Cells[e.Row, 1].Text == CHK_NOT_CHECK)
                        {
                            spdCheckItem.ActiveSheet.Cells[e.Row, 4].Text = "";
                        }
                        
                        if (spdCheckItem.ActiveSheet.Cells[e.Row, 4].Text != "")
                        {
                            spdCheckItem.ActiveSheet.Cells[e.Row, 2].Text = "";
                        }
                        
                        spdCheckItem.ActiveSheet.Cells[e.Row, 4].Locked = false;
                        
                        if (CheckToolTypeItem(spdCheckItem.ActiveSheet.Cells[e.Row, 0].Text, '2') == false)
                        {
                            
                            for (i = 0; i < 30; i++)
                            {
                                if (ToolTypeInfo.typelist[i].prompt != "")
                                {
                                    if (ToolTypeInfo.typelist[i].event_flag == "Y")
                                    {
                                        if (ToolTypeInfo.typelist[i].format == FORMAT_ASCII)
                                        {
                                            j++;
                                        }
                                    }
                                }
                            }

                            InitToolItemList(sCheckList);
                            
                            for (i = 0; i < 30; i++)
                            {
                                if (ToolTypeInfo.typelist[i].prompt != "")
                                {
                                    if (ToolTypeInfo.typelist[i].event_flag == "Y")
                                    {
                                        if (ToolTypeInfo.typelist[i].format == FORMAT_ASCII)
                                        {
                                            sCheckList.Add(ToolTypeInfo.typelist[i].prompt);
                                        }
                                    }
                                }
                            }
                            
                            // Add by DM KIM 2013.09.02 º±≈√«ﬂ¥¯ Value ¿”Ω√ ¿˙¿Â
                            sTempText = spdCheckItem.ActiveSheet.Cells[e.Row, 4].Text;


                            CheckItem = new string[sCheckList.Count];
                            for (i = 0; i < sCheckList.Count; i++)
                            {
                                CheckItem[i] = sCheckList[i];
                            }
                            cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                            cboCellType.Items = CheckItem;
                            spdCheckItem.ActiveSheet.Cells[e.Row, 4].CellType = cboCellType;

                            spdCheckItem.ActiveSheet.Cells[e.Row, 4].Text = sTempText;
                            
                        }
                        else
                        {
                            for (k = 0; k <= 29; k++)
                            {
                                if (ToolTypeInfo.typelist[k].prompt == spdCheckItem.ActiveSheet.Cells[e.Row, 0].Text)
                                {
                                    
                                    if (ToolTypeInfo.typelist[k].format == FORMAT_ASCII)
                                    {
                                        for (i = 0; i < 30; i++)
                                        {
                                            if (ToolTypeInfo.typelist[i].prompt != "")
                                            {
                                                if (ToolTypeInfo.typelist[i].event_flag == "Y" && ToolTypeInfo.typelist[i].format == FORMAT_ASCII)
                                                {
                                                    j++;
                                                }
                                            }
                                        }
                                        
                                        InitToolItemList(sCheckList);
                                        
                                        for (i = 0; i < 30; i++)
                                        {
                                            if (ToolTypeInfo.typelist[i].prompt != "")
                                            {
                                                if (ToolTypeInfo.typelist[i].event_flag == "Y" && ToolTypeInfo.typelist[i].format == FORMAT_ASCII)
                                                {
                                                    sCheckList.Add(ToolTypeInfo.typelist[i].prompt);
                                                }
                                            }
                                        }

                                        CheckItem = new string[sCheckList.Count];
                                        for (i = 0; i < sCheckList.Count; i++)
                                        {
                                            CheckItem[i] = sCheckList[i];
                                        }
                                        cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                                        cboCellType.Items = CheckItem;
                                        spdCheckItem.ActiveSheet.Cells[e.Row, 4].CellType = cboCellType;

                                        
                                    }
                                    else if (ToolTypeInfo.typelist[k].format == FORMAT_NUMBER)
                                    {
                                        for (i = 0; i < 30; i++)
                                        {
                                            if (ToolTypeInfo.typelist[i].prompt != "")
                                            {
                                                if (ToolTypeInfo.typelist[i].event_flag == "Y" && ToolTypeInfo.typelist[i].format == FORMAT_NUMBER)
                                                {
                                                    j++;
                                                }
                                            }
                                        }
                                        
                                        for (i = 0; i < 30; i++)
                                        {
                                            if (ToolTypeInfo.typelist[i].prompt != "")
                                            {
                                                if (ToolTypeInfo.typelist[i].event_flag == "Y" && ToolTypeInfo.typelist[i].format == FORMAT_NUMBER)
                                                {
                                                    sCheckList.Add(ToolTypeInfo.typelist[i].prompt);
                                                }
                                            }
                                        }

                                        CheckItem = new string[sCheckList.Count];
                                        for (i = 0; i < sCheckList.Count; i++)
                                        {
                                            CheckItem[i] = sCheckList[i];
                                        }
                                        cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                                        cboCellType.Items = CheckItem;
                                        spdCheckItem.ActiveSheet.Cells[e.Row, 4].CellType = cboCellType;
                                    }
                                    else if (ToolTypeInfo.typelist[k].format == FORMAT_FLOAT)
                                    {
                                        
                                        for (i = 0; i < 30; i++)
                                        {
                                            if (ToolTypeInfo.typelist[i].prompt != "")
                                            {
                                                if (ToolTypeInfo.typelist[i].event_flag == "Y" && ToolTypeInfo.typelist[i].format == FORMAT_FLOAT)
                                                {
                                                    j++;
                                                }
                                            }
                                        }
                                        
                                        for (i = 0; i < 30; i++)
                                        {
                                            if (ToolTypeInfo.typelist[i].prompt != "")
                                            {
                                                if (ToolTypeInfo.typelist[i].event_flag == "Y" && ToolTypeInfo.typelist[i].format == FORMAT_FLOAT)
                                                {
                                                    sCheckList.Add(ToolTypeInfo.typelist[i].prompt);
                                                }
                                            }
                                        }

                                        CheckItem = new string[sCheckList.Count];
                                        for (i = 0; i < sCheckList.Count; i++)
                                        {
                                            CheckItem[i] = sCheckList[i];
                                        }
                                        cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                                        cboCellType.Items = CheckItem;
                                        spdCheckItem.ActiveSheet.Cells[e.Row, 4].CellType = cboCellType;

                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (e.Column == 1)
                    {
                        spdCheckItem.ActiveSheet.Cells[e.Row, 1].Text = "";
                    }
                    if (e.Column == 4)
                    {
                        spdCheckItem.ActiveSheet.Cells[e.Row, 4].Text = "";
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void spdChangeItem_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == 0)
            {
                spdChangeItem.ActiveSheet.Cells[e.Row, 1].Text = "";
                spdChangeItem.ActiveSheet.Cells[e.Row, 2].Text = "";
                spdChangeItem.ActiveSheet.Cells[e.Row, 4].Text = "";

                if (spdChangeItem.ActiveSheet.Cells[e.Row, 0].Text != "")
                {
                    spdChangeItem.ActiveSheet.Cells[e.Row, 1].Locked = false;
                }
                else
                {
                    spdChangeItem.ActiveSheet.Cells[e.Row, 1].Locked = true;
                    spdChangeItem.ActiveSheet.Cells[e.Row, 2].Locked = true;
                }
                
            }
            else if (e.Column == 1)
            {
                
                if (spdChangeItem.ActiveSheet.Cells[e.Row, 1].Text != "")
                {
                    //Modify by J.S 2007/01/27 
                    //Change, Reset, Increase, Decrease
                    if ((spdChangeItem.ActiveSheet.Cells[e.Row, 1].Text == CHG_CHANGE) ||
                        (spdChangeItem.ActiveSheet.Cells[e.Row, 1].Text == CHG_RESET) ||
                        (spdChangeItem.ActiveSheet.Cells[e.Row, 1].Text == CHG_INCREASE) ||
                        (spdChangeItem.ActiveSheet.Cells[e.Row, 1].Text == CHG_DECREASE) ||
                        (spdChangeItem.ActiveSheet.Cells[e.Row, 1].Text == CHG_MULTIPLY) ||
                        (spdChangeItem.ActiveSheet.Cells[e.Row, 1].Text == CHG_DIVISION) ||
                        (spdChangeItem.ActiveSheet.Cells[e.Row, 1].Text == CHG_MOD) ||
                        (spdChangeItem.ActiveSheet.Cells[e.Row, 1].Text == CHG_POW))
                    {
                        View_SheetControl(spdChangeItem.ActiveSheet.Cells[e.Row, 0].Text, e.Row, CHANGESHEET);
                        spdChangeItem.ActiveSheet.Cells[e.Row, 2].Locked = false;
                        spdChangeItem.ActiveSheet.Cells[e.Row, 3].Locked = false;
                    }
                    else
                    {
                        if (spdChangeItem.ActiveSheet.Cells[e.Row, 1].Text == CHG_NOT_CHANGE)
                        {
                            spdChangeItem.ActiveSheet.Cells[e.Row, 2].Locked = true;
                        }
                        else
                        {
                            spdChangeItem.ActiveSheet.Cells[e.Row, 2].Locked = false;
                        }
                        spdChangeItem.ActiveSheet.Cells[e.Row, 2].Text = "";
                        spdChangeItem.ActiveSheet.Cells[e.Row, 3].Locked = true;
                    }
                }
                else
                {
                    
                    //CellSpan(e.Row, 2, CHANGESHEET);
                    spdChangeItem.ActiveSheet.Cells[e.Row, 2].Text = "";
                    spdChangeItem.ActiveSheet.Cells[e.Row, 4].Text = "";
                    spdChangeItem.ActiveSheet.Cells[e.Row, 2].Locked = true;
                    spdChangeItem.ActiveSheet.Cells[e.Row, 3].Locked = true;
                }
            }

            if(e.Column != 4) SetChangeOption(e.Row);
        }
        
        private void chkCleanDefData_Click(object sender, System.EventArgs e)
        {
            if (chkColDefData.Checked == true)
            {
                chkColDefData.Checked = false;
                chkCleanDefData.Checked = true;
            }
        }
        
        private void chkColDefData_Click(object sender, System.EventArgs e)
        {
            if (chkCleanDefData.Checked == true)
            {
                chkCleanDefData.Checked = false;
                chkColDefData.Checked = true;
            }
        }
        
        private void txtToolEventID_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FieldClear(this.pnlRight, txtToolEventID, null, null, null, null, false);
            ClearData('1');
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisToolEvent, txtFind.Text, true, false);
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisToolEvent, txtFind.Text, 0, true, false);
        }
        
        private void txtToolEventID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (MPCF.CheckValue(cdvType, 1) == false)
            {
                e.Handled = true;
            }
        }
        
        private void spdCheckItem_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            string sValue;
            int i;
            int iIndex;
            
            try
            {
                if (e.Column != 2)
                {
                    return;
                }

                sValue = MPCF.Trim(spdCheckItem.ActiveSheet.GetValue(e.Row, e.Column));
                
                if (sValue == null)
                {
                    return;
                }
                
                iIndex = - 1;
                for (i = 0; i < 30; i++)
                {
                    if (MPCF.Trim(ToolTypeInfo.typelist[i].prompt) == MPCF.Trim(spdCheckItem.ActiveSheet.GetValue(e.Row, 0)))
                    {
                        iIndex = i;
                        break;
                    }
                }
                
                if (iIndex == - 1)
                {
                    return;
                }
                
                switch (ToolTypeInfo.typelist[iIndex].format)
                {
                    case FORMAT_FLOAT:
                        
                        if (MPCF.CheckNumeric(sValue) == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(139));
                            if (sChkCellValue == null)
                            {
                                spdCheckItem.ActiveSheet.SetValue(e.Row, e.Column, "");
                            }
                            else
                            {
                                spdCheckItem.ActiveSheet.SetValue(e.Row, e.Column, sChkCellValue);
                            }
                            return;
                        }
                        break;
                    case FORMAT_NUMBER:
                        
                        if (MPCF.CheckNumeric(sValue) == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(139));
                            if (sChkCellValue == null)
                            {
                                spdCheckItem.ActiveSheet.SetValue(e.Row, e.Column, "");
                            }
                            else
                            {
                                spdCheckItem.ActiveSheet.SetValue(e.Row, e.Column, sChkCellValue);
                            }
                            return;
                        }
                        if (sValue.IndexOf(".") > 0 || sValue.IndexOf("-") > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(140));
                            if (sChkCellValue == null)
                            {
                                spdCheckItem.ActiveSheet.SetValue(e.Row, e.Column, "");
                            }
                            else
                            {
                                spdCheckItem.ActiveSheet.SetValue(e.Row, e.Column, sChkCellValue);
                            }
                            return;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void spdCheckItem_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            
            try
            {
                
                if (e.Column == 2)
                {
                    spdCheckItem.ActiveSheet.Cells[e.Row, 4].Text = "";
                }
                if (spdCheckItem.ActiveSheet.Cells[e.Row, 0].Text == "")
                {
                    spdCheckItem.ActiveSheet.Cells[e.Row, 2].Text = "";
                }
                
                if (e.Column == 2)
                {
                    sChkCellValue = MPCF.Trim(spdCheckItem.ActiveSheet.GetValue(e.Row, e.Column));
                    if (sChkCellValue == null)
                    {
                        return;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }
        
        private void spdChangeItem_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column == 2)
                {
                    spdChangeItem.ActiveSheet.Cells[e.Row, 2].Tag = "";
                }
                if (spdChangeItem.ActiveSheet.Cells[e.Row, 0].Text == "")
                {
                    spdChangeItem.ActiveSheet.Cells[e.Row, 2].Text = "";
                    spdChangeItem.ActiveSheet.Cells[e.Row, 2].Tag = "";
                }
                if(e.Column != 4) SetChangeOption(e.Row);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void spdCheckItem_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            spdCheckItem.ActiveSheet.SetActiveCell(e.Row, e.Column);
        }
        
        private void spdChangeItem_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            spdChangeItem.ActiveSheet.SetActiveCell(e.Row, e.Column);
        }

        private void cdvValueFieldList_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            FarPoint.Win.Spread.SheetView svTemp = spdChangeItem.ActiveSheet;
            svTemp.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
            svTemp.Cells[e.Row, e.Col - 1].Tag = e.SelectedItem.SubItems[0].Tag;

            SetChangeOption(e.Row);
        }

    }
    
    //#End If
}
