//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASTranAttributeValue.vb
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
using System.Collections.Generic;
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Globalization;

using Miracom.UI.Controls;
using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.BASCore
{
    public class frmBASTranAttribute : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmBASTranAttribute()
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
        



        private System.Windows.Forms.Label lblAttrType;
        private System.Windows.Forms.GroupBox grpAttribute;
        private System.Windows.Forms.Panel pnlAttrInfo;
        private System.Windows.Forms.GroupBox grpAttrInfo;
        private FarPoint.Win.Spread.FpSpread spdAttrValue;
        private FarPoint.Win.Spread.SheetView spdAttrValue_Sheet1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAttrType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAttrKey;
        private System.Windows.Forms.Label lblAttrKey;
        private System.Windows.Forms.Button btnView;
        private Label lblAttrSeq;
        private Label lblAttrName;
        private NumericUpDown nudToAttrSeq;
        private NumericUpDown nudFromAttrSeq;
        private Label label3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAttrName;
        private Button btnDelRow;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvTableData;
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
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer7 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer7 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBASTranAttribute));
            this.grpAttribute = new System.Windows.Forms.GroupBox();
            this.cdvAttrName = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.nudToAttrSeq = new System.Windows.Forms.NumericUpDown();
            this.nudFromAttrSeq = new System.Windows.Forms.NumericUpDown();
            this.cdvAttrKey = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAttrKey = new System.Windows.Forms.Label();
            this.cdvAttrType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAttrSeq = new System.Windows.Forms.Label();
            this.lblAttrName = new System.Windows.Forms.Label();
            this.lblAttrType = new System.Windows.Forms.Label();
            this.pnlAttrInfo = new System.Windows.Forms.Panel();
            this.grpAttrInfo = new System.Windows.Forms.GroupBox();
            this.spdAttrValue = new FarPoint.Win.Spread.FpSpread();
            this.spdAttrValue_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnView = new System.Windows.Forms.Button();
            this.cdvTableData = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.btnDelRow = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpAttribute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudToAttrSeq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFromAttrSeq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrType)).BeginInit();
            this.pnlAttrInfo.SuspendLayout();
            this.grpAttrInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdAttrValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAttrValue_Sheet1)).BeginInit();
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
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnDelRow);
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelRow, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlAttrInfo);
            this.pnlCenter.Controls.Add(this.grpAttribute);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "BaseForm03";
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
            // grpAttribute
            // 
            this.grpAttribute.Controls.Add(this.cdvAttrName);
            this.grpAttribute.Controls.Add(this.nudToAttrSeq);
            this.grpAttribute.Controls.Add(this.nudFromAttrSeq);
            this.grpAttribute.Controls.Add(this.cdvAttrKey);
            this.grpAttribute.Controls.Add(this.lblAttrKey);
            this.grpAttribute.Controls.Add(this.cdvAttrType);
            this.grpAttribute.Controls.Add(this.label3);
            this.grpAttribute.Controls.Add(this.lblAttrSeq);
            this.grpAttribute.Controls.Add(this.lblAttrName);
            this.grpAttribute.Controls.Add(this.lblAttrType);
            this.grpAttribute.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAttribute.Location = new System.Drawing.Point(0, 0);
            this.grpAttribute.Name = "grpAttribute";
            this.grpAttribute.Size = new System.Drawing.Size(742, 70);
            this.grpAttribute.TabIndex = 0;
            this.grpAttribute.TabStop = false;
            // 
            // cdvAttrName
            // 
            this.cdvAttrName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvAttrName.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttrName.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttrName.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttrName.BtnToolTipText = "";
            this.cdvAttrName.DescText = "";
            this.cdvAttrName.DisplaySubItemIndex = 0;
            this.cdvAttrName.DisplayText = "";
            this.cdvAttrName.Focusing = null;
            this.cdvAttrName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttrName.Index = 0;
            this.cdvAttrName.IsViewBtnImage = false;
            this.cdvAttrName.Location = new System.Drawing.Point(408, 15);
            this.cdvAttrName.MaxLength = 100;
            this.cdvAttrName.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAttrName.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAttrName.Name = "cdvAttrName";
            this.cdvAttrName.ReadOnly = false;
            this.cdvAttrName.SearchSubItemIndex = 0;
            this.cdvAttrName.SelectedDescIndex = -1;
            this.cdvAttrName.SelectedSubItemIndex = 0;
            this.cdvAttrName.SelectionStart = 0;
            this.cdvAttrName.Size = new System.Drawing.Size(328, 20);
            this.cdvAttrName.SmallImageList = null;
            this.cdvAttrName.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttrName.TabIndex = 5;
            this.cdvAttrName.TextBoxToolTipText = "";
            this.cdvAttrName.TextBoxWidth = 328;
            this.cdvAttrName.VisibleButton = true;
            this.cdvAttrName.VisibleColumnHeader = false;
            this.cdvAttrName.VisibleDescription = false;
            this.cdvAttrName.ButtonPress += new System.EventHandler(this.cdvAttrName_ButtonPress);
            // 
            // nudToAttrSeq
            // 
            this.nudToAttrSeq.Location = new System.Drawing.Point(528, 40);
            this.nudToAttrSeq.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudToAttrSeq.Name = "nudToAttrSeq";
            this.nudToAttrSeq.Size = new System.Drawing.Size(80, 20);
            this.nudToAttrSeq.TabIndex = 9;
            this.nudToAttrSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudToAttrSeq.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // nudFromAttrSeq
            // 
            this.nudFromAttrSeq.Location = new System.Drawing.Point(408, 40);
            this.nudFromAttrSeq.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudFromAttrSeq.Name = "nudFromAttrSeq";
            this.nudFromAttrSeq.Size = new System.Drawing.Size(80, 20);
            this.nudFromAttrSeq.TabIndex = 7;
            this.nudFromAttrSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cdvAttrKey
            // 
            this.cdvAttrKey.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttrKey.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttrKey.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttrKey.BtnToolTipText = "";
            this.cdvAttrKey.DescText = "";
            this.cdvAttrKey.DisplaySubItemIndex = 0;
            this.cdvAttrKey.DisplayText = "";
            this.cdvAttrKey.Focusing = null;
            this.cdvAttrKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttrKey.Index = 0;
            this.cdvAttrKey.IsViewBtnImage = false;
            this.cdvAttrKey.Location = new System.Drawing.Point(79, 40);
            this.cdvAttrKey.MaxLength = 100;
            this.cdvAttrKey.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAttrKey.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAttrKey.Name = "cdvAttrKey";
            this.cdvAttrKey.ReadOnly = false;
            this.cdvAttrKey.SearchSubItemIndex = 0;
            this.cdvAttrKey.SelectedDescIndex = -1;
            this.cdvAttrKey.SelectedSubItemIndex = 0;
            this.cdvAttrKey.SelectionStart = 0;
            this.cdvAttrKey.Size = new System.Drawing.Size(200, 20);
            this.cdvAttrKey.SmallImageList = null;
            this.cdvAttrKey.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttrKey.TabIndex = 3;
            this.cdvAttrKey.TextBoxToolTipText = "";
            this.cdvAttrKey.TextBoxWidth = 200;
            this.cdvAttrKey.VisibleButton = true;
            this.cdvAttrKey.VisibleColumnHeader = false;
            this.cdvAttrKey.VisibleDescription = false;
            this.cdvAttrKey.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvAttrKey_SelectedItemChanged);
            this.cdvAttrKey.ButtonPress += new System.EventHandler(this.cdvAttrKey_ButtonPress);
            this.cdvAttrKey.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvAttrKey_TextBoxKeyPress);
            this.cdvAttrKey.TextBoxTextChanged += new System.EventHandler(this.cdvAttrKey_TextBoxTextChanged);
            // 
            // lblAttrKey
            // 
            this.lblAttrKey.AutoSize = true;
            this.lblAttrKey.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrKey.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrKey.Location = new System.Drawing.Point(16, 44);
            this.lblAttrKey.Name = "lblAttrKey";
            this.lblAttrKey.Size = new System.Drawing.Size(28, 13);
            this.lblAttrKey.TabIndex = 2;
            this.lblAttrKey.Text = "Key";
            // 
            // cdvAttrType
            // 
            this.cdvAttrType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttrType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttrType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttrType.BtnToolTipText = "";
            this.cdvAttrType.DescText = "";
            this.cdvAttrType.DisplaySubItemIndex = 0;
            this.cdvAttrType.DisplayText = "";
            this.cdvAttrType.Focusing = null;
            this.cdvAttrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttrType.Index = 0;
            this.cdvAttrType.IsViewBtnImage = false;
            this.cdvAttrType.Location = new System.Drawing.Point(79, 15);
            this.cdvAttrType.MaxLength = 20;
            this.cdvAttrType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAttrType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAttrType.Name = "cdvAttrType";
            this.cdvAttrType.ReadOnly = false;
            this.cdvAttrType.SearchSubItemIndex = 0;
            this.cdvAttrType.SelectedDescIndex = -1;
            this.cdvAttrType.SelectedSubItemIndex = 0;
            this.cdvAttrType.SelectionStart = 0;
            this.cdvAttrType.Size = new System.Drawing.Size(200, 20);
            this.cdvAttrType.SmallImageList = null;
            this.cdvAttrType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttrType.TabIndex = 1;
            this.cdvAttrType.TextBoxToolTipText = "";
            this.cdvAttrType.TextBoxWidth = 200;
            this.cdvAttrType.VisibleButton = true;
            this.cdvAttrType.VisibleColumnHeader = false;
            this.cdvAttrType.VisibleDescription = false;
            this.cdvAttrType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvAttrType_SelectedItemChanged);
            this.cdvAttrType.ButtonPress += new System.EventHandler(this.cdvAttrType_ButtonPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(501, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "~";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAttrSeq
            // 
            this.lblAttrSeq.AutoSize = true;
            this.lblAttrSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrSeq.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrSeq.Location = new System.Drawing.Point(345, 44);
            this.lblAttrSeq.Name = "lblAttrSeq";
            this.lblAttrSeq.Size = new System.Drawing.Size(56, 13);
            this.lblAttrSeq.TabIndex = 6;
            this.lblAttrSeq.Text = "Sequence";
            // 
            // lblAttrName
            // 
            this.lblAttrName.AutoSize = true;
            this.lblAttrName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrName.Location = new System.Drawing.Point(345, 18);
            this.lblAttrName.Name = "lblAttrName";
            this.lblAttrName.Size = new System.Drawing.Size(35, 13);
            this.lblAttrName.TabIndex = 4;
            this.lblAttrName.Text = "Name";
            // 
            // lblAttrType
            // 
            this.lblAttrType.AutoSize = true;
            this.lblAttrType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrType.Location = new System.Drawing.Point(16, 18);
            this.lblAttrType.Name = "lblAttrType";
            this.lblAttrType.Size = new System.Drawing.Size(35, 13);
            this.lblAttrType.TabIndex = 0;
            this.lblAttrType.Text = "Type";
            // 
            // pnlAttrInfo
            // 
            this.pnlAttrInfo.Controls.Add(this.grpAttrInfo);
            this.pnlAttrInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttrInfo.Location = new System.Drawing.Point(0, 70);
            this.pnlAttrInfo.Name = "pnlAttrInfo";
            this.pnlAttrInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlAttrInfo.Size = new System.Drawing.Size(742, 443);
            this.pnlAttrInfo.TabIndex = 1;
            // 
            // grpAttrInfo
            // 
            this.grpAttrInfo.Controls.Add(this.spdAttrValue);
            this.grpAttrInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAttrInfo.Location = new System.Drawing.Point(0, 5);
            this.grpAttrInfo.Name = "grpAttrInfo";
            this.grpAttrInfo.Size = new System.Drawing.Size(742, 438);
            this.grpAttrInfo.TabIndex = 0;
            this.grpAttrInfo.TabStop = false;
            this.grpAttrInfo.Text = "Attribute Information";
            // 
            // spdAttrValue
            // 
            this.spdAttrValue.AccessibleDescription = "spdAttrValue, Sheet1, Row 0, Column 0, ";
            this.spdAttrValue.BackColor = System.Drawing.SystemColors.Control;
            this.spdAttrValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdAttrValue.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdAttrValue.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdAttrValue.HorizontalScrollBar.Name = "";
            this.spdAttrValue.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdAttrValue.HorizontalScrollBar.TabIndex = 18;
            this.spdAttrValue.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdAttrValue.Location = new System.Drawing.Point(3, 16);
            this.spdAttrValue.Name = "spdAttrValue";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            columnHeaderRenderer7.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer7.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer7.Name = "";
            columnHeaderRenderer7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer7.TextRotationAngle = 0D;
            namedStyle1.Renderer = columnHeaderRenderer7;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            rowHeaderRenderer7.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer7.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer7.Name = "";
            rowHeaderRenderer7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer7.TextRotationAngle = 0D;
            namedStyle2.Renderer = rowHeaderRenderer7;
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
            this.spdAttrValue.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdAttrValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdAttrValue.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdAttrValue.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdAttrValue.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdAttrValue_Sheet1});
            this.spdAttrValue.Size = new System.Drawing.Size(736, 419);
            this.spdAttrValue.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdAttrValue.TabIndex = 0;
            this.spdAttrValue.TextTipDelay = 200;
            this.spdAttrValue.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdAttrValue.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdAttrValue.VerticalScrollBar.Name = "";
            this.spdAttrValue.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdAttrValue.VerticalScrollBar.TabIndex = 19;
            this.spdAttrValue.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdAttrValue.EnterCell += new FarPoint.Win.Spread.EnterCellEventHandler(this.spdAttrValue_EnterCell);
            this.spdAttrValue.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdAttrValue_CellDoubleClick);
            this.spdAttrValue.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdAttrValue_ButtonClicked);
            this.spdAttrValue.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdAttrValue_EditChange);
            // 
            // spdAttrValue_Sheet1
            // 
            this.spdAttrValue_Sheet1.Reset();
            spdAttrValue_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdAttrValue_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdAttrValue_Sheet1.ColumnCount = 14;
            spdAttrValue_Sheet1.RowCount = 3;
            this.spdAttrValue_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttrValue_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdAttrValue_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttrValue_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Name";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Current Value";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 4).ColumnSpan = 2;
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 4).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "New Value";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Null";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Array Type Flag";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Array Separator";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Value Format";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Value Size";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Valid Table";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Valid Table Type";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Allow Blank";
            this.spdAttrValue_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttrValue_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdAttrValue_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.WhiteSmoke;
            checkBoxCellType1.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            this.spdAttrValue_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdAttrValue_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdAttrValue_Sheet1.Columns.Get(0).Locked = true;
            this.spdAttrValue_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(0).Width = 24F;
            this.spdAttrValue_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdAttrValue_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAttrValue_Sheet1.Columns.Get(1).Label = "Name";
            this.spdAttrValue_Sheet1.Columns.Get(1).Locked = true;
            this.spdAttrValue_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdAttrValue_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(1).Width = 167F;
            this.spdAttrValue_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdAttrValue_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAttrValue_Sheet1.Columns.Get(2).Label = "Description";
            this.spdAttrValue_Sheet1.Columns.Get(2).Locked = true;
            this.spdAttrValue_Sheet1.Columns.Get(2).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdAttrValue_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(2).Width = 170F;
            this.spdAttrValue_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdAttrValue_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAttrValue_Sheet1.Columns.Get(3).Label = "Current Value";
            this.spdAttrValue_Sheet1.Columns.Get(3).Locked = true;
            this.spdAttrValue_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(3).Width = 130F;
            this.spdAttrValue_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAttrValue_Sheet1.Columns.Get(4).Label = "New Value";
            this.spdAttrValue_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(4).Width = 150F;
            this.spdAttrValue_Sheet1.Columns.Get(5).Resizable = false;
            this.spdAttrValue_Sheet1.Columns.Get(5).Width = 25F;
            checkBoxCellType2.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            this.spdAttrValue_Sheet1.Columns.Get(6).CellType = checkBoxCellType2;
            this.spdAttrValue_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(6).Label = "Null";
            this.spdAttrValue_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(6).Width = 30F;
            this.spdAttrValue_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdAttrValue_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdAttrValue_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttrValue_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdAttrValue_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttrValue_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdAttrValue_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
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
            // btnDelRow
            // 
            this.btnDelRow.Enabled = false;
            this.btnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelRow.Location = new System.Drawing.Point(12, 7);
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.Size = new System.Drawing.Size(88, 26);
            this.btnDelRow.TabIndex = 3;
            this.btnDelRow.Text = "Delete Row";
            this.btnDelRow.Click += new System.EventHandler(this.btnDelRow_Click);
            // 
            // frmBASTranAttribute
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBASTranAttribute";
            this.Text = "Input Attribute Value";
            this.Activated += new System.EventHandler(this.frmBASTranAttributeValue_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpAttribute.ResumeLayout(false);
            this.grpAttribute.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudToAttrSeq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFromAttrSeq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrType)).EndInit();
            this.pnlAttrInfo.ResumeLayout(false);
            this.grpAttrInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdAttrValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAttrValue_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableData)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const int MAX_VALUE_COUNT = 500;
        
        #endregion
        
        #region "VariableDefinition"
        
        private bool b_load_flag;
        
        #endregion
        
        #region " Function Definition "
        
        // ViewAttributeValue()
        //       - View Attribute Value
        // Return Value
        //       - boolean : True / False
        private bool ViewAttributeValue()
        {
            int i, i_row = 0;
            CultureInfo ci_local = CultureInfo.CurrentCulture;
            TRSNode in_node = new TRSNode("ATTR_IN");
            TRSNode out_node = new TRSNode("ATTR_OUT");
            List<TRSNode> value_list;

            MPCF.ClearList(spdAttrValue, true);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ATTR_TYPE", MPCF.Trim(cdvAttrType.Text));
            in_node.AddString("ATTR_KEY", MPCF.Trim(cdvAttrKey.Text));
            in_node.AddString("ATTR_NAME", MPCF.Trim(cdvAttrName.Text));
            in_node.AddInt("ATTR_FROM", (int)nudFromAttrSeq.Value);
            in_node.AddInt("ATTR_TO", (int)nudToAttrSeq.Value);
            in_node.AddString("NEXT_ATTR_NAME", "");
            in_node.AddInt("NEXT_ATTR_SEQ", 0);

            try
            {
                do
                {
                    if (MPCR.CallService("BAS", "BAS_View_Attribute_Value_Brief", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    value_list = out_node.GetList("VALUE_LIST");
                    for (i = 0; i < value_list.Count; i++)
                    { 
                        /** Array Type 일 경우 Row 추가 부분 변경 **/
                        /** End of  2012-11-15   **/
                        if (value_list[i].GetChar("ARRAY_TYPE_FLAG") == 'Y')
                        {
                            string[] sa_attr_values = value_list[i].GetString("ATTR_VALUE").Split(value_list[i].GetChar("ARRAY_SEPARATOR"));
                            for (int i_cnt = 0; i_cnt < sa_attr_values.Length; i_cnt++)
                            {
                                /* ROW 추가 */
                                i_row = spdAttrValue.ActiveSheet.RowCount;
                                spdAttrValue.ActiveSheet.RowCount++;

                                /** 값 설정  **/
                                spdAttrValue.ActiveSheet.Cells[i_row, 1].Value = value_list[i].GetString("ATTR_NAME");
                                spdAttrValue.ActiveSheet.Cells[i_row, 2].Value = value_list[i].GetString("ATTR_DESC");
                                spdAttrValue.ActiveSheet.Cells[i_row, 1].Tag = value_list[i].GetInt("LAST_ACTIVE_HIST_SEQ");
                                spdAttrValue.ActiveSheet.Cells[i_row, 4].Tag = value_list[i].GetChar("LONG_LENGTH_ATTR_VALUE_FLAG");

                                spdAttrValue.ActiveSheet.Cells[i_row, 7].Value = value_list[i].GetChar("ARRAY_TYPE_FLAG");
                                spdAttrValue.ActiveSheet.Cells[i_row, 8].Value = value_list[i].GetChar("ARRAY_SEPARATOR");
                                spdAttrValue.ActiveSheet.Cells[i_row, 9].Value = value_list[i].GetChar("ATTR_FMT");
                                spdAttrValue.ActiveSheet.Cells[i_row, 10].Value = value_list[i].GetInt("ATTR_SIZE");
                                spdAttrValue.ActiveSheet.Cells[i_row, 11].Value = value_list[i].GetString("VALID_TBL");
                                spdAttrValue.ActiveSheet.Cells[i_row, 12].Value = value_list[i].GetChar("VALID_TBL_TYPE");
                                spdAttrValue.ActiveSheet.Cells[i_row, 13].Value = value_list[i].GetChar("ALLOW_BLANK");
                                
                                spdAttrValue.ActiveSheet.Cells[i_row, 3].Value = sa_attr_values[i_cnt];
                                //spdAttrValue.ActiveSheet.Cells[i_row, 4].Value = sa_attr_values[i_cnt];

                                if(i_cnt > 0)
                                {
                                    spdAttrValue.ActiveSheet.Cells[i_row, 6].Locked = true;
                                }

                                /* Cell 타입 지정 */
                                SetCellTypeByAttribute(value_list[i], spdAttrValue.ActiveSheet.Cells[i_row, 4]);

                                if (value_list[i].GetChar("NULL_FLAG") == 'Y')
                                {
                                    spdAttrValue.ActiveSheet.Cells[i_row, 3].Value = "[Null]";
                                }
                            }
                            if (value_list[i].GetChar("NULL_FLAG") == 'Y' || (sa_attr_values.Length == 1 && sa_attr_values[0] == ""))
                            {
                                ;
                            }
                            else
                            {
                                AddArrayTypeRow(i_row, false);
                            }
                        }
                        else
                        {
                            /* ROW 추가 */
                            i_row = spdAttrValue.ActiveSheet.RowCount;
                            spdAttrValue.ActiveSheet.RowCount++;

                            /** 값 설정  **/
                            spdAttrValue.ActiveSheet.Cells[i_row, 1].Value = value_list[i].GetString("ATTR_NAME");
                            spdAttrValue.ActiveSheet.Cells[i_row, 2].Value = value_list[i].GetString("ATTR_DESC");
                            spdAttrValue.ActiveSheet.Cells[i_row, 1].Tag = value_list[i].GetInt("LAST_ACTIVE_HIST_SEQ");
                            spdAttrValue.ActiveSheet.Cells[i_row, 4].Tag = value_list[i].GetChar("LONG_LENGTH_ATTR_VALUE_FLAG");

                            spdAttrValue.ActiveSheet.Cells[i_row, 7].Value = value_list[i].GetChar("ARRAY_TYPE_FLAG");
                            spdAttrValue.ActiveSheet.Cells[i_row, 8].Value = value_list[i].GetChar("ARRAY_SEPARATOR");
                            spdAttrValue.ActiveSheet.Cells[i_row, 9].Value = value_list[i].GetChar("ATTR_FMT");
                            spdAttrValue.ActiveSheet.Cells[i_row, 10].Value = value_list[i].GetInt("ATTR_SIZE");
                            spdAttrValue.ActiveSheet.Cells[i_row, 11].Value = value_list[i].GetString("VALID_TBL");
                            spdAttrValue.ActiveSheet.Cells[i_row, 12].Value = value_list[i].GetChar("VALID_TBL_TYPE");
                            spdAttrValue.ActiveSheet.Cells[i_row, 13].Value = value_list[i].GetChar("ALLOW_BLANK");

                            /* Cell 타입 지정 */
                            SetCellTypeByAttribute(value_list[i], spdAttrValue.ActiveSheet.Cells[i_row, 4]);

                            if (value_list[i].GetChar("LONG_LENGTH_ATTR_VALUE_FLAG") == 'Y')
                            {
                                string value = value_list[i].GetString("ATTR_VALUE");
                                value_list[i].SetString("ATTR_VALUE", value += " ...");
                            }

                            if (value_list[i].GetChar("NULL_FLAG") == 'Y')
                            {
                                spdAttrValue.ActiveSheet.Cells[i_row, 3].Value = "[Null]";
                            }
                            else
                            {
                                spdAttrValue.ActiveSheet.Cells[i_row, 3].Value = value_list[i].GetString("ATTR_VALUE");
                            }

                            spdAttrValue.ActiveSheet.Rows[i_row].Height = spdAttrValue.ActiveSheet.GetPreferredRowHeight(i_row);
                        }
                    }

                    in_node.SetString("NEXT_ATTR_NAME", out_node.GetString("NEXT_ATTR_NAME"));
                    in_node.SetInt("NEXT_ATTR_SEQ", out_node.GetInt("NEXT_ATTR_SEQ"));

                } while (in_node.GetString("NEXT_ATTR_NAME") != "" || in_node.GetInt("NEXT_ATTR_SEQ") > 0);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            return true;
        }
        
        //
        // UpdateAttributeValue()
        //       - Change Attribute Value information
        // Return Value
        //       - boolean : True / False
        // Arguments
        //
        private bool UpdateAttributeValue()
        {
            TRSNode in_node = new TRSNode("ATTR_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode list_item = null;
            int i, iStart, iCount;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ATTR_TYPE", MPCF.Trim(cdvAttrType.Text));
            in_node.AddString("ATTR_KEY", MPCF.Trim(cdvAttrKey.Text));
                
            iStart = 0;
            iCount = spdAttrValue.ActiveSheet.RowCount;

            try
            {
                do
                {
                    if (iCount > MAX_VALUE_COUNT) 
                        iCount = MAX_VALUE_COUNT;

                    for (i = iStart; i < iCount + iStart; i++)
                    {
                        if (spdAttrValue.ActiveSheet.Cells[i, 0].Value != null && (bool)spdAttrValue.ActiveSheet.Cells[i, 0].Value == true)
                        {
                            if (spdAttrValue.ActiveSheet.Cells[i, 6].Value != null && (bool)spdAttrValue.ActiveSheet.Cells[i, 6].Value == true)
                            {
                                list_item = in_node.AddNode("VALUE_LIST");

                                list_item.AddString("ATTR_NAME", MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value));
                                list_item.AddChar("NULL_FLAG", 'Y');
                                list_item.AddInt("LAST_ACTIVE_HIST_SEQ", MPCF.ToInt(spdAttrValue.ActiveSheet.Cells[i, 1].Tag));

                                if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 7].Value) == "Y")
                                {
                                    //Array Type
                                    string s_attr_name = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value);
                                    while (i < spdAttrValue.ActiveSheet.RowCount)
                                    {
                                        if (s_attr_name != MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value)) break;
                                        i++;
                                    }
                                    i--;
                                }
                            }
                            else
                            {
                                if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 7].Value) == "Y")
                                {
                                    //Array Type 일경우  병합해서 전송함
                                    string s_attr_name = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value);
                                    string s_separator = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 8].Value);
                                    string s_attr_value = "";
                                    int i_last_active_hist_seq = MPCF.ToInt(spdAttrValue.ActiveSheet.Cells[i, 1].Tag);
                                    int i_array_value_count = 0;

                                    while (i < spdAttrValue.ActiveSheet.RowCount)
                                    {
                                        if (s_attr_name != MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value)) break;

                                        if (i_array_value_count < 1)
                                        {
                                            if (spdAttrValue.ActiveSheet.Cells[i, 4].CellType is FarPoint.Win.Spread.CellType.NumberCellType == true)
                                            {
                                                s_attr_value = MPCF.Trim(MPCF.ToRegionNumber(spdAttrValue.ActiveSheet.Cells[i, 4].Value));
                                            }
                                            else
                                            {
                                                s_attr_value = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 4].Value);
                                            }
                                        }
                                        else
                                        {
                                            if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 3].Value) == "" &&
                                                MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 4].Value) == "" &&
                                                (i + 1 == spdAttrValue.ActiveSheet.RowCount ||
                                                 s_attr_name != MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i + 1, 1].Value)))
                                            {
                                                ; // 위 조건일때 제외
                                            }
                                            else
                                            {
                                                if (spdAttrValue.ActiveSheet.Cells[i, 4].CellType is FarPoint.Win.Spread.CellType.NumberCellType == true)
                                                {
                                                    s_attr_value = s_attr_value + s_separator + MPCF.Trim(MPCF.ToRegionNumber(spdAttrValue.ActiveSheet.Cells[i, 4].Value));
                                                }
                                                else
                                                {
                                                    s_attr_value = s_attr_value + s_separator + MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 4].Value);
                                                }
                                            }
                                        }

                                        i++;
                                        i_array_value_count++;
                                    }
                                    i--;

                                    list_item = in_node.AddNode("VALUE_LIST");

                                    list_item.AddString("ATTR_NAME", s_attr_name);
                                    list_item.AddString("ATTR_VALUE", s_attr_value);
                                    list_item.AddInt("LAST_ACTIVE_HIST_SEQ", i_last_active_hist_seq);
                                }
                                else //기존 저장 로직 부분
                                {
                                    if (spdAttrValue.ActiveSheet.Cells[i, 4].CellType is FarPoint.Win.Spread.CellType.TextCellType == true)
                                    { //Add by J.S. 2011.04.11 Ascii Type인 경우 어떠한 변환도 없이 처리 해야 한다.
                                        list_item = in_node.AddNode("VALUE_LIST");

                                        list_item.AddString("ATTR_NAME", MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value));
                                        list_item.AddString("ATTR_VALUE", MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 4].Value));
                                        list_item.AddInt("LAST_ACTIVE_HIST_SEQ", MPCF.ToInt(spdAttrValue.ActiveSheet.Cells[i, 1].Tag));
                                    }
                                    else if (spdAttrValue.ActiveSheet.Cells[i, 4].CellType is FarPoint.Win.Spread.CellType.NumberCellType == true)
                                    {
                                        list_item = in_node.AddNode("VALUE_LIST");

                                        list_item.AddString("ATTR_NAME", MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value));
                                        list_item.AddString("ATTR_VALUE", MPCF.Trim(MPCF.ToRegionNumber(spdAttrValue.ActiveSheet.Cells[i, 4].Value)));
                                        list_item.AddInt("LAST_ACTIVE_HIST_SEQ", MPCF.ToInt(spdAttrValue.ActiveSheet.Cells[i, 1].Tag));
                                    }
                                }
                            }
                        }
                    }


                    if (MPCR.CallService("BAS", "BAS_Update_Attribute_Value", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    if (spdAttrValue.ActiveSheet.RowCount - (iCount + iStart) > 0)
                    {
                        iStart += iCount;
                        iCount = spdAttrValue.ActiveSheet.RowCount - iCount;
                    }
                    else
                    {
                        iStart = 0;
                        iCount = 0;
                    }

                } while (iStart != 0 || iCount != 0);

                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }
        
        // CheckCondition()
        //       - check Create/Update/Delete condition
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String      : Function Name
        //       - Optional ByVal ProcStep As String        : Create/Update/Delete 구분??
        //
        private bool CheckCondition(char ProcStep)
        {
            if (MPCF.CheckValue(cdvAttrType, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvAttrKey, 1) == false)
            {
                return false;
            }

            switch (ProcStep)
            {
                case 'V':
                    
                    break;
                case MPGC.MP_STEP_UPDATE:
                    bool bCheck = false;
                    bool bNullCheck = false;
                    int i, iRows = spdAttrValue.ActiveSheet.RowCount;
                    for (i = 0; i < iRows; i++)
                    {
                        if (spdAttrValue.ActiveSheet.Cells[i, 0].Value != null)
                        {
                            bCheck = true;
                        }
                        if (Convert.ToBoolean(spdAttrValue.ActiveSheet.Cells[i, 6].Value) == true)
                        {
                            bNullCheck = true;
                            break;
                        }
                    }

                    if (!bCheck) return false;
                    if (bNullCheck)
                    {
                        if (MPCF.ShowMsgBox(MPCF.GetMessage(64), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                            return false;
                    }
                    break;
            }
            
            return true;
            
        }

        private void SetCellTypeByAttribute(TRSNode out_node, FarPoint.Win.Spread.Cell cell)
        {
            FarPoint.Win.Spread.CellType.TextCellType txtCell;
            FarPoint.Win.Spread.CellType.NumberCellType numCell;
            FarPoint.Win.Spread.CellType.ButtonCellType btnCell;
            CultureInfo ci_local = CultureInfo.CurrentCulture;

            int i_row = cell.Row.Index;

            switch (out_node.GetChar("ATTR_FMT"))
            {
                case 'A':
                    txtCell = new FarPoint.Win.Spread.CellType.TextCellType();
                    txtCell.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Ascii;
                    txtCell.MaxLength = out_node.GetInt("ATTR_SIZE");
                    txtCell.WordWrap = true;
                    txtCell.Multiline = true;

                    cell.CellType = txtCell;
                    break;
                case 'N':
                    numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                    numCell.DecimalPlaces = 0;
                    {
                        string s_max_value = "";
                        double d_max_value = 0;
                        for (int i = 0; i < out_node.GetInt("ATTR_SIZE"); i++)
                        {
                            s_max_value += "9";
                        }
                        d_max_value = MPCF.ToDbl(s_max_value);
                        numCell.MaximumValue = d_max_value;
                        numCell.MinimumValue = d_max_value * -1;
                    }
                    numCell.Separator = ci_local.NumberFormat.NumberGroupSeparator;

                    cell.CellType = numCell;
                    break;
                case 'F':
                    numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                    numCell.DecimalPlaces = 3;
                    {
                        string s_max_value = "";
                        double d_max_value = 0;
                        for (int i = 0; i < out_node.GetInt("ATTR_SIZE"); i++)
                        {
                            s_max_value += "9";
                        }
                        d_max_value = MPCF.ToDbl(s_max_value);
                        numCell.MaximumValue = d_max_value;
                        numCell.MinimumValue = d_max_value * -1;
                    }
                    numCell.Separator = ci_local.NumberFormat.NumberGroupSeparator;
                    numCell.DecimalSeparator = ci_local.NumberFormat.NumberDecimalSeparator;

                    cell.CellType = numCell;
                    break;
            }

            if (out_node.GetString("VALID_TBL") == "")
            {
                spdAttrValue.ActiveSheet.AddSpanCell(i_row, 4, 1, 2);
            }
            else
            {
                // Cell 타입 지정
                if (out_node.GetChar("VALID_TBL_TYPE") == 'A' || out_node.GetChar("VALID_TBL_TYPE") == 'Q')
                {
                    btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                    btnCell.Text = "...";
                    spdAttrValue.ActiveSheet.Cells[i_row, 5].CellType = btnCell;
                    spdAttrValue.ActiveSheet.Cells[i_row, 5].Tag = out_node.GetString("VALID_TBL");
                }
                else
                {
                    spdAttrValue.ActiveSheet.AddSpanCell(i_row, 4, 1, 2);
                }

                if (out_node.GetChar("ALLOW_BLANK") == 'Y')
                    spdAttrValue.ActiveSheet.Cells[i_row, 3].Tag = 'Y';
            }
        }

        private void SetCellTypeByAttribute(FarPoint.Win.Spread.SheetView spdView, FarPoint.Win.Spread.Cell cell)
        {
            TRSNode a_node;
            int i_row = cell.Row.Index;

            a_node = new TRSNode("Cell Format");
            a_node.AddChar("ATTR_FMT", MPCF.ToChar(spdView.Cells[cell.Row.Index, 9].Value));
            a_node.AddInt("ATTR_SIZE", MPCF.ToInt(spdView.Cells[cell.Row.Index, 10].Value));
            a_node.AddString("VALID_TBL", MPCF.Trim(spdView.Cells[cell.Row.Index, 11].Value));
            a_node.AddChar("VALID_TBL_TYPE", MPCF.ToChar(spdView.Cells[cell.Row.Index, 12].Value));
            a_node.AddChar("ALLOW_BLANK", MPCF.ToChar(spdView.Cells[cell.Row.Index, 13].Value));

            SetCellTypeByAttribute(a_node, cell);
        }

        private void AddArrayTypeRow(int i_row, bool b_update_check)
        {
            bool b_insert_row;
            try
            {
                if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i_row, 7].Value) != "Y") return;

                b_insert_row = false;
                if (i_row + 1 < spdAttrValue.ActiveSheet.RowCount)
                {
                    if (spdAttrValue.ActiveSheet.Cells[i_row, 1].Value != spdAttrValue.ActiveSheet.Cells[i_row + 1, 1].Value)
                    {
                        b_insert_row = true;
                        //신규 Row 추가
                        spdAttrValue.ActiveSheet.Rows.Add(i_row + 1, 1);
                    }
                }
                else if (i_row + 1 == spdAttrValue.ActiveSheet.RowCount)
                {
                    b_insert_row = true;
                    //신규 Row 추가
                    spdAttrValue.ActiveSheet.RowCount++;
                }

                if (b_insert_row == true)
                {
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 1].Value = spdAttrValue.ActiveSheet.Cells[i_row, 1].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 2].Value = spdAttrValue.ActiveSheet.Cells[i_row, 2].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 1].Tag = spdAttrValue.ActiveSheet.Cells[i_row, 1].Tag;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 4].Tag = spdAttrValue.ActiveSheet.Cells[i_row, 4].Tag;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 7].Value = spdAttrValue.ActiveSheet.Cells[i_row, 7].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 8].Value = spdAttrValue.ActiveSheet.Cells[i_row, 8].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 9].Value = spdAttrValue.ActiveSheet.Cells[i_row, 9].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 10].Value = spdAttrValue.ActiveSheet.Cells[i_row, 10].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 11].Value = spdAttrValue.ActiveSheet.Cells[i_row, 11].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 12].Value = spdAttrValue.ActiveSheet.Cells[i_row, 12].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 13].Value = spdAttrValue.ActiveSheet.Cells[i_row, 13].Value;

                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 6].Locked = true; // Null Flag

                    SetCellTypeByAttribute(spdAttrValue.ActiveSheet, spdAttrValue.ActiveSheet.Cells[i_row + 1, 4]);
                }

                if (b_update_check == true)
                {
                    //Row 삽입시 이전 이후 체크박스 체크 처리
                    for (int i = i_row; i >= 0; i--)
                    {
                        if (spdAttrValue.ActiveSheet.Cells[i, 1].Value != spdAttrValue.ActiveSheet.Cells[i_row, 1].Value) break;
                        spdAttrValue.ActiveSheet.Cells[i, 0].Value = true;
                    }

                    for (int i = i_row + 1; i < spdAttrValue.ActiveSheet.RowCount -1; i++)
                    {
                        if (spdAttrValue.ActiveSheet.Cells[i + 1, 1].Value != spdAttrValue.ActiveSheet.Cells[i_row, 1].Value) break;
                        spdAttrValue.ActiveSheet.Cells[i, 0].Value = true;
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
                return this.cdvAttrType;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmBASTranAttributeValue_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.ClearList(spdAttrValue, true);
                MPCF.FieldClear(this);
                nudToAttrSeq.Value = 10000;

                spdAttrValue.ActiveSheet.Columns[7].Visible = false;
                spdAttrValue.ActiveSheet.Columns[8].Visible = false;
                spdAttrValue.ActiveSheet.Columns[9].Visible = false;
                spdAttrValue.ActiveSheet.Columns[10].Visible = false;
                spdAttrValue.ActiveSheet.Columns[11].Visible = false;
                spdAttrValue.ActiveSheet.Columns[12].Visible = false;
                spdAttrValue.ActiveSheet.Columns[13].Visible = false;

                b_load_flag = true;
            }
        }
        
        private void cdvAttrType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvAttrType.Init();
            MPCF.InitListView(cdvAttrType.GetListView);
            cdvAttrType.Columns.Add("Type", 150, HorizontalAlignment.Left);
            cdvAttrType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAttrType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvAttrType.GetListView, '1', MPGC.MP_ATTR_TYPE_TABLE);
        }
        
        private void cdvAttrType_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            cdvAttrKey.Text = "";
            cdvAttrKey.VisibleButton = true;
            
            switch (cdvAttrType.Text)
            {
                case MPGC.MP_ATTR_TYPE_FACTORY:
                    
                    break;
                case MPGC.MP_ATTR_TYPE_MATERIAL:
                    
                    break;
                case MPGC.MP_ATTR_TYPE_FLOW:
                    
                    break;
                case MPGC.MP_ATTR_TYPE_OPER:
                    
                    break;
                case MPGC.MP_ATTR_TYPE_BOM:
                    
                    break;
                case MPGC.MP_ATTR_TYPE_RESOURCE:
                    
                    break;
                case MPGC.MP_ATTR_TYPE_CARRIER:

                    break;
                default:
                    
                    cdvAttrKey.VisibleButton = false;
                    break;
            }
            
        }
        
        private void cdvAttrKey_ButtonPress(object sender, System.EventArgs e)
        {
            if (MPCF.CheckValue(cdvAttrType, 1) == false)
            {
                return;
            }
            
            cdvAttrKey.Init();
            MPCF.InitListView(cdvAttrKey.GetListView);
            cdvAttrKey.Columns.Add("Key", 150, HorizontalAlignment.Left);
            cdvAttrKey.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAttrKey.SelectedSubItemIndex = 0;
            
            switch (cdvAttrType.Text)
            {
                case MPGC.MP_ATTR_TYPE_FACTORY:
                    
                    WIPLIST.ViewFactoryList(cdvAttrKey.GetListView, '1', null);
                    break;
                case MPGC.MP_ATTR_TYPE_MATERIAL:

                    cdvAttrKey.Columns.Add("Desc", 200, HorizontalAlignment.Left);

                    WIPLIST.ViewMaterialList(cdvAttrKey.GetListView, '1');
                    break;
                case MPGC.MP_ATTR_TYPE_FLOW:
                    
                    WIPLIST.ViewFlowList(cdvAttrKey.GetListView, '1', "", 0,"", null, "");
                    break;
                case MPGC.MP_ATTR_TYPE_OPER:
                    
                    WIPLIST.ViewOperationList(cdvAttrKey.GetListView, '1', "",0, "", "", null, "");
                    break;
                case MPGC.MP_ATTR_TYPE_BOM:
                    
                    #if _BOM
                    BOMLIST.ViewBOMSetList(cdvAttrKey.GetListView, '1', null, "", -1, -1, ' ', true);
                    #endif
                    break;
                case MPGC.MP_ATTR_TYPE_RESOURCE:

                    RASLIST.ViewResourceList(cdvAttrKey.GetListView, false);
                    break;
                case MPGC.MP_ATTR_TYPE_CARRIER:

                    if (MPGO.RequireCarrierFilter() == true)
                    {
                        if (MPCF.Trim(cdvAttrKey.Text) == "")
                        {
                            cdvAttrKey.IsPopup = false;
                            MPCF.ShowMsgBox(MPCF.GetMessage(258));
                            cdvAttrKey.Focus();
                            return;
                        }
                    }
                    RASLIST.ViewCarrierList(cdvAttrKey.GetListView, '1', "", "", cdvAttrKey.Text);
                    break;
            }
            
        }
        
        private void cdvAttrKey_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvAttrType.Text == MPGC.MP_ATTR_TYPE_MATERIAL)
                if (e != null)
                    cdvAttrKey.Text = e.SelectedItem.SubItems[0].Text + " : " + e.SelectedItem.SubItems[1].Text;

            btnView.PerformClick();
        }

        private void cdvAttrKey_TextBoxTextChanged(object sender, EventArgs e)
        {
            cdvAttrName.Text = String.Empty;
            cdvAttrName.VisibleButton = true;
        }

        private void cdvAttrKey_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (MPCF.Trim(cdvAttrKey.Text) != "")
            {
                if (e.KeyChar == (char)13)
                {
                    btnView.PerformClick();
                }
            }
        }

        private void cdvTableData_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            spdAttrValue.ActiveSheet.Cells[e.Row, 4].Value = MPCF.Trim(e.SelectedItem.Text);
            spdAttrValue.ActiveSheet.Cells[e.Row, 0].Value = true;
            AddArrayTypeRow(e.Row, true);
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition('V') == false)
                return;
            
            ViewAttributeValue();
            MPCR.ChangeControlEnabled(this, btnDelRow, false);
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_UPDATE) == false) return;
            if (UpdateAttributeValue() == false) return;

            btnView.PerformClick();
        }

        private void spdAttrValue_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column == 6)
                {
                    spdAttrValue.ActiveSheet.Cells[e.Row, 0].Value = true;

                    if (Convert.ToBoolean(spdAttrValue.ActiveSheet.Cells[e.Row, 6].Value) == true)
                    {
                        if (spdAttrValue.ActiveSheet.Cells[e.Row, 4].CellType is FarPoint.Win.Spread.CellType.NumberCellType == true)
                        {
                            spdAttrValue.ActiveSheet.Cells[e.Row, 4].Value = "";
                            spdAttrValue.ActiveSheet.Cells[e.Row, 4].Locked = false;
                            spdAttrValue.ActiveSheet.Cells[e.Row, 5].Locked = false;
                        }
                        else
                        {
                            spdAttrValue.ActiveSheet.Cells[e.Row, 4].Value = "[Null]";
                            spdAttrValue.ActiveSheet.Cells[e.Row, 4].Locked = true;
                            spdAttrValue.ActiveSheet.Cells[e.Row, 5].Locked = true;
                        }
                    }
                    else
                    {
                        spdAttrValue.ActiveSheet.Cells[e.Row, 4].Value = "";
                        spdAttrValue.ActiveSheet.Cells[e.Row, 4].Locked = false;
                        spdAttrValue.ActiveSheet.Cells[e.Row, 5].Locked = false;
                    }

                    for (int i = e.Row + 1; i < spdAttrValue.ActiveSheet.RowCount; i++)
                    {
                        if (spdAttrValue.ActiveSheet.Cells[i, 1].Value == spdAttrValue.ActiveSheet.Cells[e.Row, 1].Value)
                        {
                            if (i < spdAttrValue.ActiveSheet.RowCount -1 && spdAttrValue.ActiveSheet.Cells[i + 1, 1].Value == spdAttrValue.ActiveSheet.Cells[e.Row, 1].Value)
                            {
                                spdAttrValue.ActiveSheet.Cells[i, 0].Value = true;
                            }
                            spdAttrValue.ActiveSheet.Cells[i, 4].Value = "";
                            spdAttrValue.ActiveSheet.Cells[i, 4].Locked = spdAttrValue.ActiveSheet.Cells[e.Row, 4].Locked;
                            spdAttrValue.ActiveSheet.Cells[i, 5].Locked = spdAttrValue.ActiveSheet.Cells[e.Row, 5].Locked;
                        }
                    }

                    return;
                }

                cdvTableData.Init();
                cdvTableData.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvTableData.GetListView);
                cdvTableData.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
                cdvTableData.Columns.Add("Table Desc", 50, HorizontalAlignment.Left);

                if (BASLIST.ViewGCMDataList(cdvTableData.GetListView, '1', MPCF.Trim(spdAttrValue.ActiveSheet.Cells[e.Row, e.Column].Tag)) == false)
                {
                    return;
                }

                if (MPCF.ToChar(spdAttrValue.ActiveSheet.Cells[e.Row, 3].Tag) == 'Y')
                    cdvTableData.InsertEmptyRow(0, 1);

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

        private void spdAttrValue_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == 4)
            {
                spdAttrValue.ActiveSheet.Cells[e.Row, 0].Value = true;
                AddArrayTypeRow(e.Row, true);
            }
        }

        private void spdAttrValue_EnterCell(object sender, FarPoint.Win.Spread.EnterCellEventArgs e)
        {
            if (e.Column == 4)
            {
                if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[e.Row, 4].Tag) == "Y")
                {
                    frmBASTranAttributeDetail f = new frmBASTranAttributeDetail();
                    f.AttributeKey = cdvAttrKey.Text;
                    f.AttributeType = cdvAttrType.Text;
                    f.AttributeName = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[e.Row, 1].Value);
                    f.AttributeDesc = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[e.Row, 2].Value);
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        spdAttrValue.ActiveSheet.Cells[e.Row, 4].Value = f.AttributeValue;
                        spdAttrValue.ActiveSheet.Cells[e.Row, 0].Value = true;
                        spdAttrValue.ActiveSheet.Rows[e.Row].Height = spdAttrValue.ActiveSheet.GetPreferredRowHeight(e.Row);
                    }

                    if (f.IsDisposed == false) f.Dispose();
                }
            }

            if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[e.Row, 7].Value) == "Y" &&
                e.Row != spdAttrValue.ActiveSheet.RowCount -1 &&
                spdAttrValue.ActiveSheet.Cells[e.Row +1, 1].Value == spdAttrValue.ActiveSheet.Cells[e.Row, 1].Value)
            {
                MPCR.ChangeControlEnabled(this, btnDelRow, true);
            }
            else
            {
                MPCR.ChangeControlEnabled(this, btnDelRow, false);
            }
        }

        private void spdAttrValue_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Column != 4) return;

            if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[e.Row, 4].Tag) == "Y")
            {
                frmBASTranAttributeDetail f = new frmBASTranAttributeDetail();
                f.AttributeKey = cdvAttrKey.Text;
                f.AttributeType = cdvAttrType.Text;
                f.AttributeName = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[e.Row, 1].Value);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    spdAttrValue.ActiveSheet.Cells[e.Row, 4].Value = f.AttributeValue;
                    spdAttrValue.ActiveSheet.Cells[e.Row, 0].Value = true;
                    spdAttrValue.ActiveSheet.Rows[e.Row].Height = spdAttrValue.ActiveSheet.GetPreferredRowHeight(e.Row);
                }
                spdAttrValue.EditModePermanent = false;

                if (f.IsDisposed == false) f.Dispose();
            }
        }

        private void cdvAttrName_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvAttrType, 1) == false) return;

            cdvAttrName.Init();
            MPCF.InitListView(cdvAttrName.GetListView);
            cdvAttrName.Columns.Add("Attribute Seq", 150, HorizontalAlignment.Left);
            cdvAttrName.Columns.Add("Attribute Name", 150, HorizontalAlignment.Left);
            cdvAttrName.Columns.Add("Attribute Type", 200, HorizontalAlignment.Left);
            cdvAttrName.Columns.Add("Attribute Desc", 200, HorizontalAlignment.Left);
            cdvAttrName.SelectedSubItemIndex = 1;
            cdvAttrName.DisplaySubItemIndex = 1;
            BASLIST.ViewAttributeNameList(cdvAttrName.GetListView, '1', cdvAttrType.Text);
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            int i_row = spdAttrValue.ActiveSheet.ActiveRowIndex;

            for (int i = i_row; i >= 0; i--)
            {
                if (spdAttrValue.ActiveSheet.Cells[i, 1].Value != spdAttrValue.ActiveSheet.Cells[i_row, 1].Value) break;
                spdAttrValue.ActiveSheet.Cells[i, 0].Value = true;
            }

            for (int i = i_row + 1; i < spdAttrValue.ActiveSheet.RowCount -1 ; i++)
            {
                if (spdAttrValue.ActiveSheet.Cells[i +1, 1].Value != spdAttrValue.ActiveSheet.Cells[i_row, 1].Value) break;
                spdAttrValue.ActiveSheet.Cells[i, 0].Value = true;
            }

            spdAttrValue.ActiveSheet.Rows[i_row].Remove();

            if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i_row, 7].Value) == "Y" &&
                i_row != spdAttrValue.ActiveSheet.RowCount - 1 &&
                spdAttrValue.ActiveSheet.Cells[i_row + 1, 1].Value == spdAttrValue.ActiveSheet.Cells[i_row, 1].Value)
            {
                MPCR.ChangeControlEnabled(this, btnDelRow, true);
            }
            else
            {
                MPCR.ChangeControlEnabled(this, btnDelRow, false);
            }
        }         


    }    
}
