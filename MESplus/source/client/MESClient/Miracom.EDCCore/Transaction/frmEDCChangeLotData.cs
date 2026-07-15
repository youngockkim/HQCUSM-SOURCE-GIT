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
using FarPoint.Win.Spread;
using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmEDCChangeLotData.vb
//   Description : MES Cient Form View Lot History Class
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - CheckCondition() : Check the conditions before transaction
//       - Change_Lot_Data() : Change Lot Data
//       - View_Lot_Data()  : View all Lot data list
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-16 : Created by CM Koo
//       - 2007-03-13 : HISTORY_COLUMN modified by H.J. Noh
//                      µ•¿Ã≈Õ∞° ¿÷¥¬ ªÛ≈¬ø°º≠ ≈◊Ω∫∆Æ «ÿ∫º « ø‰∞° ¿÷¿Ω 
//       - 2008-01-20 : Modified by LAVERWON                      
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


namespace Miracom.EDCCore
{
    public class frmEDCChangeLotData : Miracom.MESCore.TranForm11
    {

#if _EDC
        
#region " Windows Form auto generated code "
        
        public frmEDCChangeLotData()
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
        



        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.Panel pnlMidMain;
        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private FpSpread spdData;
        private SheetView spdData_Sheet1;
        private Splitter splitter1;
        private Panel pnlLotHistory;
        private FpSpread spdHistory;
        private SheetView spdHistory_Sheet1;
        private System.Windows.Forms.Label lblTo;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer4 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer4 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer3 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer3 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer5 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer5 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer6 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer6 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer7 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer7 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer8 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer8 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer9 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer9 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType4 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType79 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType80 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType81 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType82 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType83 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType84 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType85 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType86 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType87 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType88 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType89 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType90 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType91 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType92 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType93 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType94 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType95 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType96 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType97 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType98 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType99 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType100 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType101 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType102 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType103 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType104 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle5 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle6 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle7 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer2 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle8 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType2 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder4 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.pnlMidMain = new System.Windows.Forms.Panel();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlLotHistory = new System.Windows.Forms.Panel();
            this.spdHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMidMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.pnlLotHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).BeginInit();
            this.pnlPeriod.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTranTop
            // 
            this.pnlTranTop.Location = new System.Drawing.Point(2, 0);
            this.pnlTranTop.Size = new System.Drawing.Size(730, 47);
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Controls.Add(this.pnlMidMain);
            this.pnlTranCenter.Location = new System.Drawing.Point(2, 47);
            this.pnlTranCenter.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pnlTranCenter.Size = new System.Drawing.Size(730, 455);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Controls.Add(this.txtLotID);
            this.grpOption.Controls.Add(this.lblLotID);
            this.grpOption.Size = new System.Drawing.Size(724, 47);
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Visible = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(548, 7);
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(640, 7);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 502);
            this.pnlBottom.Size = new System.Drawing.Size(734, 40);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pnlCenter.Size = new System.Drawing.Size(734, 502);
            // 
            // pnlTop
            // 
            this.pnlTop.Padding = new System.Windows.Forms.Padding(1);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Location = new System.Drawing.Point(1, 1);
            this.lblFormTitle.Size = new System.Drawing.Size(740, 0);
            this.lblFormTitle.Text = "Change Lot Data";
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
            columnHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer4.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer4.Name = "columnHeaderRenderer4";
            columnHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer4.TextRotationAngle = 0D;
            rowHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer4.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer4.Name = "rowHeaderRenderer4";
            rowHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer4.TextRotationAngle = 0D;
            columnHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer3.Name = "columnHeaderRenderer3";
            columnHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer3.TextRotationAngle = 0D;
            rowHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer3.Name = "rowHeaderRenderer3";
            rowHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer3.TextRotationAngle = 0D;
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
            columnHeaderRenderer7.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer7.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer7.Name = "columnHeaderRenderer7";
            columnHeaderRenderer7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer7.TextRotationAngle = 0D;
            rowHeaderRenderer7.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer7.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer7.Name = "rowHeaderRenderer7";
            rowHeaderRenderer7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer7.TextRotationAngle = 0D;
            columnHeaderRenderer8.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer8.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer8.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer8.Name = "columnHeaderRenderer8";
            columnHeaderRenderer8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer8.TextRotationAngle = 0D;
            rowHeaderRenderer8.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer8.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer8.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer8.Name = "rowHeaderRenderer8";
            rowHeaderRenderer8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer8.TextRotationAngle = 0D;
            columnHeaderRenderer9.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer9.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer9.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer9.Name = "columnHeaderRenderer9";
            columnHeaderRenderer9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer9.TextRotationAngle = 0D;
            rowHeaderRenderer9.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer9.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer9.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer9.Name = "rowHeaderRenderer9";
            rowHeaderRenderer9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer9.TextRotationAngle = 0D;
            // 
            // txtLotID
            // 
            this.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLotID.Location = new System.Drawing.Point(120, 16);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(200, 20);
            this.txtLotID.TabIndex = 0;
            this.txtLotID.TextChanged += new System.EventHandler(this.txtLotID_TextChanged);
            this.txtLotID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotID_KeyPress);
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(15, 19);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            this.lblLotID.TabIndex = 0;
            this.lblLotID.Text = "Lot ID";
            this.lblLotID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMidMain
            // 
            this.pnlMidMain.Controls.Add(this.spdData);
            this.pnlMidMain.Controls.Add(this.splitter1);
            this.pnlMidMain.Controls.Add(this.pnlLotHistory);
            this.pnlMidMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMidMain.Location = new System.Drawing.Point(0, 2);
            this.pnlMidMain.Name = "pnlMidMain";
            this.pnlMidMain.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pnlMidMain.Size = new System.Drawing.Size(730, 453);
            this.pnlMidMain.TabIndex = 0;
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, Sheet1";
            this.spdData.BackColor = System.Drawing.SystemColors.Control;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.EditModeReplace = true;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 20;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.Location = new System.Drawing.Point(0, 146);
            this.spdData.Name = "spdData";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Renderer = columnHeaderRenderer7;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
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
            this.spdData.Size = new System.Drawing.Size(730, 307);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 1;
            this.spdData.TabStop = false;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 21;
            this.spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.EditModeOff += new System.EventHandler(this.spdData_EditModeOff);
            this.spdData.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdData_EditChange);
            this.spdData.SetViewportLeftColumn(0, 0, 10);
            this.spdData.SetActiveViewport(0, -1, -1);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 56;
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
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Lot ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Hist Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "TranTime";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Del Flag";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 5;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Factory";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Material";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Flow";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 8).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Oper";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 9).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Measure Resource ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Proc Flow";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Proc Oper";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 12).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Proc Resource ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 13).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Col Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 14).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Collection Set ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 15).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Version";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 16).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Char Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 17).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Character";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 18).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Character Desc";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 19).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Spec";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 20).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Unit Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 21).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Unit ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 22).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = " Value Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 23).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = " Value Type";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 24).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = " Value Count";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 25).ColumnSpan = 25;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Value";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 50).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 50).Value = "Spec Out Mask";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 51).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 51).Value = "Update User ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 52).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 52).Value = "Update Time";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 53).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 53).Value = "Value Type 2";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 54).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 54).Value = "Value Count 2";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 18).Value = "Character Desc";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 19).Value = " ";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 20).Value = " ";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 21).Value = " ";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 22).Value = " ";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 23).Value = " ";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 24).Value = " ";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 25).Value = "1";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 26).Value = "2";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 27).Value = "3";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 28).Value = "4";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 29).Value = "5";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 30).Value = "6";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 31).Value = "7";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 32).Value = "8";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 33).Value = "9";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 34).Value = "10";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 35).Value = "11";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 36).Value = "12";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 37).Value = "13";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 38).Value = "14";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 39).Value = "15";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 40).Value = "16";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 41).Value = "17";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 42).Value = "18";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 43).Value = "19";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 44).Value = "20";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 45).Value = "21";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 46).Value = "22";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 47).Value = "23";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 48).Value = "24";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 49).Value = "25";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnHeader.Rows.Get(0).Height = 16F;
            this.spdData_Sheet1.ColumnHeader.Rows.Get(1).Height = 16F;
            this.spdData_Sheet1.Columns.Get(0).CellType = checkBoxCellType4;
            this.spdData_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Width = 30F;
            this.spdData_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Width = 0F;
            this.spdData_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(2).Width = 0F;
            this.spdData_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(3).Width = 0F;
            this.spdData_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(4).Locked = true;
            this.spdData_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(4).Width = 0F;
            this.spdData_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(5).Width = 0F;
            this.spdData_Sheet1.Columns.Get(6).Locked = true;
            this.spdData_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(6).Width = 0F;
            this.spdData_Sheet1.Columns.Get(7).Locked = true;
            this.spdData_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(7).Width = 0F;
            this.spdData_Sheet1.Columns.Get(8).Locked = true;
            this.spdData_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(8).Width = 0F;
            this.spdData_Sheet1.Columns.Get(9).Locked = true;
            this.spdData_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(9).Width = 0F;
            this.spdData_Sheet1.Columns.Get(10).Locked = true;
            this.spdData_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(10).Width = 0F;
            this.spdData_Sheet1.Columns.Get(11).Locked = true;
            this.spdData_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(11).Width = 0F;
            this.spdData_Sheet1.Columns.Get(12).Locked = true;
            this.spdData_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(12).Width = 0F;
            this.spdData_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(13).Locked = true;
            this.spdData_Sheet1.Columns.Get(13).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdData_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(13).Width = 40F;
            this.spdData_Sheet1.Columns.Get(14).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(14).Locked = true;
            this.spdData_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(14).Width = 100F;
            this.spdData_Sheet1.Columns.Get(15).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(15).Locked = true;
            this.spdData_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(15).Width = 45F;
            this.spdData_Sheet1.Columns.Get(16).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(16).Locked = true;
            this.spdData_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(16).Width = 33F;
            this.spdData_Sheet1.Columns.Get(17).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(17).Locked = true;
            this.spdData_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(17).Width = 100F;
            this.spdData_Sheet1.Columns.Get(18).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(18).Label = "Character Desc";
            this.spdData_Sheet1.Columns.Get(18).Locked = true;
            this.spdData_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(18).Width = 150F;
            this.spdData_Sheet1.Columns.Get(19).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(19).Label = " ";
            this.spdData_Sheet1.Columns.Get(19).Locked = true;
            this.spdData_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(19).Width = 105F;
            this.spdData_Sheet1.Columns.Get(20).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(20).Label = " ";
            this.spdData_Sheet1.Columns.Get(20).Locked = true;
            this.spdData_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(20).Width = 30F;
            textCellType79.MaxLength = 50;
            this.spdData_Sheet1.Columns.Get(21).CellType = textCellType79;
            this.spdData_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(21).Label = " ";
            this.spdData_Sheet1.Columns.Get(21).Locked = false;
            this.spdData_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(21).Width = 120F;
            this.spdData_Sheet1.Columns.Get(22).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(22).Label = " ";
            this.spdData_Sheet1.Columns.Get(22).Locked = true;
            this.spdData_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(22).Width = 39F;
            this.spdData_Sheet1.Columns.Get(23).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(23).Label = " ";
            this.spdData_Sheet1.Columns.Get(23).Locked = true;
            this.spdData_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(23).Width = 40F;
            this.spdData_Sheet1.Columns.Get(24).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(24).Label = " ";
            this.spdData_Sheet1.Columns.Get(24).Locked = true;
            this.spdData_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(24).Width = 40F;
            textCellType80.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(25).CellType = textCellType80;
            this.spdData_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(25).Label = "1";
            this.spdData_Sheet1.Columns.Get(25).Locked = false;
            this.spdData_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType81.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(26).CellType = textCellType81;
            this.spdData_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(26).Label = "2";
            this.spdData_Sheet1.Columns.Get(26).Locked = false;
            this.spdData_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType82.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(27).CellType = textCellType82;
            this.spdData_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(27).Label = "3";
            this.spdData_Sheet1.Columns.Get(27).Locked = false;
            this.spdData_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType83.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(28).CellType = textCellType83;
            this.spdData_Sheet1.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(28).Label = "4";
            this.spdData_Sheet1.Columns.Get(28).Locked = false;
            this.spdData_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType84.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(29).CellType = textCellType84;
            this.spdData_Sheet1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(29).Label = "5";
            this.spdData_Sheet1.Columns.Get(29).Locked = false;
            this.spdData_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType85.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(30).CellType = textCellType85;
            this.spdData_Sheet1.Columns.Get(30).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(30).Label = "6";
            this.spdData_Sheet1.Columns.Get(30).Locked = false;
            this.spdData_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType86.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(31).CellType = textCellType86;
            this.spdData_Sheet1.Columns.Get(31).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(31).Label = "7";
            this.spdData_Sheet1.Columns.Get(31).Locked = false;
            this.spdData_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType87.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(32).CellType = textCellType87;
            this.spdData_Sheet1.Columns.Get(32).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(32).Label = "8";
            this.spdData_Sheet1.Columns.Get(32).Locked = false;
            this.spdData_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType88.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(33).CellType = textCellType88;
            this.spdData_Sheet1.Columns.Get(33).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(33).Label = "9";
            this.spdData_Sheet1.Columns.Get(33).Locked = false;
            this.spdData_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType89.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(34).CellType = textCellType89;
            this.spdData_Sheet1.Columns.Get(34).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(34).Label = "10";
            this.spdData_Sheet1.Columns.Get(34).Locked = false;
            this.spdData_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType90.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(35).CellType = textCellType90;
            this.spdData_Sheet1.Columns.Get(35).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(35).Label = "11";
            this.spdData_Sheet1.Columns.Get(35).Locked = false;
            this.spdData_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType91.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(36).CellType = textCellType91;
            this.spdData_Sheet1.Columns.Get(36).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(36).Label = "12";
            this.spdData_Sheet1.Columns.Get(36).Locked = false;
            this.spdData_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType92.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(37).CellType = textCellType92;
            this.spdData_Sheet1.Columns.Get(37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(37).Label = "13";
            this.spdData_Sheet1.Columns.Get(37).Locked = false;
            this.spdData_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType93.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(38).CellType = textCellType93;
            this.spdData_Sheet1.Columns.Get(38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(38).Label = "14";
            this.spdData_Sheet1.Columns.Get(38).Locked = false;
            this.spdData_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType94.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(39).CellType = textCellType94;
            this.spdData_Sheet1.Columns.Get(39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(39).Label = "15";
            this.spdData_Sheet1.Columns.Get(39).Locked = false;
            this.spdData_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType95.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(40).CellType = textCellType95;
            this.spdData_Sheet1.Columns.Get(40).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(40).Label = "16";
            this.spdData_Sheet1.Columns.Get(40).Locked = false;
            this.spdData_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType96.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(41).CellType = textCellType96;
            this.spdData_Sheet1.Columns.Get(41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(41).Label = "17";
            this.spdData_Sheet1.Columns.Get(41).Locked = false;
            this.spdData_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType97.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(42).CellType = textCellType97;
            this.spdData_Sheet1.Columns.Get(42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(42).Label = "18";
            this.spdData_Sheet1.Columns.Get(42).Locked = false;
            this.spdData_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType98.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(43).CellType = textCellType98;
            this.spdData_Sheet1.Columns.Get(43).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(43).Label = "19";
            this.spdData_Sheet1.Columns.Get(43).Locked = false;
            this.spdData_Sheet1.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType99.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(44).CellType = textCellType99;
            this.spdData_Sheet1.Columns.Get(44).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(44).Label = "20";
            this.spdData_Sheet1.Columns.Get(44).Locked = false;
            this.spdData_Sheet1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType100.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(45).CellType = textCellType100;
            this.spdData_Sheet1.Columns.Get(45).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(45).Label = "21";
            this.spdData_Sheet1.Columns.Get(45).Locked = false;
            this.spdData_Sheet1.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType101.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(46).CellType = textCellType101;
            this.spdData_Sheet1.Columns.Get(46).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(46).Label = "22";
            this.spdData_Sheet1.Columns.Get(46).Locked = false;
            this.spdData_Sheet1.Columns.Get(46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType102.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(47).CellType = textCellType102;
            this.spdData_Sheet1.Columns.Get(47).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(47).Label = "23";
            this.spdData_Sheet1.Columns.Get(47).Locked = false;
            this.spdData_Sheet1.Columns.Get(47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType103.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(48).CellType = textCellType103;
            this.spdData_Sheet1.Columns.Get(48).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(48).Label = "24";
            this.spdData_Sheet1.Columns.Get(48).Locked = false;
            this.spdData_Sheet1.Columns.Get(48).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType104.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(49).CellType = textCellType104;
            this.spdData_Sheet1.Columns.Get(49).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(49).Label = "25";
            this.spdData_Sheet1.Columns.Get(49).Locked = false;
            this.spdData_Sheet1.Columns.Get(49).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(50).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(50).Locked = true;
            this.spdData_Sheet1.Columns.Get(50).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(50).Width = 160F;
            this.spdData_Sheet1.Columns.Get(51).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(51).Locked = true;
            this.spdData_Sheet1.Columns.Get(51).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(51).Width = 91F;
            this.spdData_Sheet1.Columns.Get(52).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(52).Locked = true;
            this.spdData_Sheet1.Columns.Get(52).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(52).Width = 100F;
            this.spdData_Sheet1.Columns.Get(53).Width = 0F;
            this.spdData_Sheet1.Columns.Get(54).Width = 0F;
            this.spdData_Sheet1.Columns.Get(55).Width = 0F;
            this.spdData_Sheet1.FrozenColumnCount = 10;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
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
            this.splitter1.Location = new System.Drawing.Point(0, 143);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(730, 3);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // pnlLotHistory
            // 
            this.pnlLotHistory.Controls.Add(this.spdHistory);
            this.pnlLotHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLotHistory.Location = new System.Drawing.Point(0, 2);
            this.pnlLotHistory.Name = "pnlLotHistory";
            this.pnlLotHistory.Size = new System.Drawing.Size(730, 141);
            this.pnlLotHistory.TabIndex = 2;
            // 
            // spdHistory
            // 
            this.spdHistory.AccessibleDescription = "spdHistory, Sheet1, Row 0, Column 0, ";
            this.spdHistory.BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdHistory.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdHistory.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.HorizontalScrollBar.Name = "";
            this.spdHistory.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdHistory.HorizontalScrollBar.TabIndex = 12;
            this.spdHistory.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdHistory.Location = new System.Drawing.Point(0, 0);
            this.spdHistory.Name = "spdHistory";
            namedStyle5.BackColor = System.Drawing.SystemColors.Control;
            namedStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle5.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle5.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle5.Renderer = columnHeaderRenderer9;
            namedStyle5.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle6.BackColor = System.Drawing.SystemColors.Control;
            namedStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle6.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle6.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle6.Renderer = rowHeaderRenderer9;
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
            this.spdHistory.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle5,
            namedStyle6,
            namedStyle7,
            namedStyle8});
            this.spdHistory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdHistory_Sheet1});
            this.spdHistory.Size = new System.Drawing.Size(730, 141);
            this.spdHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdHistory.TabIndex = 4;
            this.spdHistory.TabStop = false;
            this.spdHistory.TextTipDelay = 200;
            this.spdHistory.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdHistory.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.VerticalScrollBar.Name = "";
            this.spdHistory.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdHistory.VerticalScrollBar.TabIndex = 13;
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
            spdHistory_Sheet1.ColumnCount = 189;
            spdHistory_Sheet1.RowCount = 0;
            this.spdHistory_Sheet1.ActiveColumnIndex = -1;
            this.spdHistory_Sheet1.ActiveRowIndex = -1;
            this.spdHistory_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Tran Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Tran Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Factory";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Mat ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Mat Ver";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Qty 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Carrier";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Lot Type";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Owner Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Create Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Create Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Lot Priority";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Lot Status";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Lot Delete Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Hold Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Hold Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Hold Prv Group";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Oper In Qty 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Oper In Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Oper In Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Create Qty 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Create Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Create Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Start Qty 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Start Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Start Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Inventory Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Transit Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Unit Exist Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "Inventory Unit";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "Rework Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "Rework Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "Rework Count";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "Rework Return Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Rework Return Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Rework Return Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Rework End Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 43).Value = "Rework End Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 44).Value = "Rework End Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 45).Value = "Rework Return Clear Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 46).Value = "Rework Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 47).Value = "NSTD Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 48).Value = "NSTD Return Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 49).Value = "NSTD Return Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 50).Value = "NSTD Return Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 51).Value = "NSTD Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 52).Value = "Repair Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 53).Value = "Repair Return Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 54).Value = "Store Return Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 55).Value = "Store Return Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 56).Value = "Store Return Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 57).Value = "Start Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 58).Value = "Start Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 59).Value = "Start Resource";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 60).Value = "End Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 61).Value = "End Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 62).Value = "End Resource";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 63).Value = "Sample Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 64).Value = "Sample Wait Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 65).Value = "Sample Result";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 66).Value = "From To Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 67).Value = "From To Lot ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 68).Value = "From To Mat ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 69).Value = "From To Mat Version";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 70).Value = "From To Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 71).Value = "From To Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 72).Value = "From To Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 73).Value = "From To Qty 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 74).Value = "From To Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 75).Value = "From To Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 76).Value = "From To Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 77).Value = "Ship Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 78).Value = "Ship Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 79).Value = "Original Due Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 80).Value = "Scheduled Due Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 81).Value = "Factory In Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 82).Value = "Flow In Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 83).Value = "Oper In Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 84).Value = "Reserve Resource";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 85).Value = "Port ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 86).Value = "Batch ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 87).Value = "Batch Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 88).Value = "Order ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 89).Value = "Add Order ID 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 90).Value = "Add Order ID 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 91).Value = "Add Order ID 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 92).Value = "Lot Location 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 93).Value = "Lot Location 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 94).Value = "Lot Location 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 95).Value = "Lot Cmf 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 96).Value = "Lot Cmf 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 97).Value = "Lot Cmf 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 98).Value = "Lot Cmf 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 99).Value = "Lot Cmf 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 100).Value = "Lot Cmf 6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 101).Value = "Lot Cmf 7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 102).Value = "Lot Cmf 8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 103).Value = "Lot Cmf 9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 104).Value = "Lot Cmf 10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 105).Value = "Lot Cmf 11";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 106).Value = "Lot Cmf 12";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 107).Value = "Lot Cmf 13";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 108).Value = "Lot Cmf 14";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 109).Value = "Lot Cmf 15";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 110).Value = "Lot Cmf 16";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 111).Value = "Lot Cmf 17";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 112).Value = "Lot Cmf 18";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 113).Value = "Lot Cmf 19";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 114).Value = "Lot Cmf 20";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 115).Value = "Lot Delete Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 116).Value = "Lot Delete Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 117).Value = "Bom Set ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 118).Value = "Bom Set Version";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 119).Value = "Bom Active Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 120).Value = "Bom Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 121).Value = "Critical Resource";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 122).Value = "Critical Resource Group";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 123).Value = "Save Resource 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 124).Value = "Save Resource 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 125).Value = "Sub Resource";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 126).Value = "Lot Group ID 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 127).Value = "Lot Group ID 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 128).Value = "Lot Group ID 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 129).Value = "Yield 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 130).Value = " Yield 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 131).Value = "Yield 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 132).Value = "Gool Qty";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 133).Value = "Resv Field 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 134).Value = "Resv Field 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 135).Value = "Resv Field 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 136).Value = "Resv Field 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 137).Value = "Resv Field 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 138).Value = "Resv Flag 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 139).Value = "Resv Flag 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 140).Value = "Resv Flag 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 141).Value = "Resv Flag 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 142).Value = "Resv Flag 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 143).Value = "Old Factory";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 144).Value = "Old Mat ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 145).Value = "Old Mat Version";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 146).Value = "Old Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 147).Value = "Old Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 148).Value = "Old Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 149).Value = "Old Qty 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 150).Value = "Old Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 151).Value = "Old Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 152).Value = "Old Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 153).Value = "Old Lot Type";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 154).Value = "Old Owner Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 155).Value = "Old Create Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 156).Value = "Old Factory In Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 157).Value = "Old Flow In Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 158).Value = "Old Oper In Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 159).Value = "Trans Cmf 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 160).Value = "Trans Cmf 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 161).Value = "Trans Cmf 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 162).Value = "Trans Cmf 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 163).Value = "Trans Cmf 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 164).Value = "Trans Cmf 6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 165).Value = "Trans Cmf 7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 166).Value = "Trans Cmf 8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 167).Value = "Trans Cmf 9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 168).Value = "Trans Cmf 10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 169).Value = "Tran Cmf 11";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 170).Value = "Tran Cmf 12";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 171).Value = "Tran Cmf 13";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 172).Value = "Tran Cmf 14";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 173).Value = "Tran Cmf 15";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 174).Value = "Tran Cmf 16";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 175).Value = "Tran Cmf 17";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 176).Value = "Tran Cmf 18";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 177).Value = "Tran Cmf 19";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 178).Value = "Tran Cmf 20";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 179).Value = "Tran User ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 180).Value = "Tran Comment";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 181).Value = "Prev Active Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 182).Value = "Multi Tr Key";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 183).Value = "Multi Tr Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 184).Value = "Hist Delete Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 185).Value = "Hist Delete Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 186).Value = "Hist Delete User ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 187).Value = "Hist Delete Comment";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 188).Value = "Sys Tran Time";
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory_Sheet1.Columns.Get(0).Border = bevelBorder4;
            this.spdHistory_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdHistory_Sheet1.Columns.Get(0).ForeColor = System.Drawing.Color.Black;
            this.spdHistory_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdHistory_Sheet1.Columns.Get(0).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Width = 44F;
            this.spdHistory_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(1).Label = "Tran Code";
            this.spdHistory_Sheet1.Columns.Get(1).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(1).Width = 81F;
            this.spdHistory_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(2).Label = "Tran Time";
            this.spdHistory_Sheet1.Columns.Get(2).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(2).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(3).Label = "Factory";
            this.spdHistory_Sheet1.Columns.Get(3).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(4).Label = "Mat ID";
            this.spdHistory_Sheet1.Columns.Get(4).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(4).Width = 122F;
            this.spdHistory_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(5).Label = "Mat Ver";
            this.spdHistory_Sheet1.Columns.Get(5).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(6).Label = "Flow";
            this.spdHistory_Sheet1.Columns.Get(6).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(6).Width = 92F;
            this.spdHistory_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(7).Label = "Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(7).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(8).Label = "Oper";
            this.spdHistory_Sheet1.Columns.Get(8).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(9).Label = "Qty 1";
            this.spdHistory_Sheet1.Columns.Get(9).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(10).Label = "Qty 2";
            this.spdHistory_Sheet1.Columns.Get(10).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(11).Label = "Qty 3";
            this.spdHistory_Sheet1.Columns.Get(11).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(12).Label = "Carrier";
            this.spdHistory_Sheet1.Columns.Get(12).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(13).Label = "Lot Type";
            this.spdHistory_Sheet1.Columns.Get(13).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(14).Label = "Owner Code";
            this.spdHistory_Sheet1.Columns.Get(14).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(14).Width = 82F;
            this.spdHistory_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(15).Label = "Create Code";
            this.spdHistory_Sheet1.Columns.Get(15).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(15).Width = 86F;
            this.spdHistory_Sheet1.Columns.Get(16).Label = "Create Time";
            this.spdHistory_Sheet1.Columns.Get(16).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(16).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(17).Label = "Lot Priority";
            this.spdHistory_Sheet1.Columns.Get(17).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(17).Width = 79F;
            this.spdHistory_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(18).Label = "Lot Status";
            this.spdHistory_Sheet1.Columns.Get(18).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(18).Width = 67F;
            this.spdHistory_Sheet1.Columns.Get(19).Label = "Lot Delete Time";
            this.spdHistory_Sheet1.Columns.Get(19).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(19).Width = 116F;
            this.spdHistory_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(20).Label = "Hold Flag";
            this.spdHistory_Sheet1.Columns.Get(20).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(20).Width = 62F;
            this.spdHistory_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(21).Label = "Hold Code";
            this.spdHistory_Sheet1.Columns.Get(21).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(21).Width = 69F;
            this.spdHistory_Sheet1.Columns.Get(22).Label = "Hold Prv Group";
            this.spdHistory_Sheet1.Columns.Get(22).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(22).Width = 83F;
            this.spdHistory_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(23).Label = "Oper In Qty 1";
            this.spdHistory_Sheet1.Columns.Get(23).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(23).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(24).Label = "Oper In Qty 2";
            this.spdHistory_Sheet1.Columns.Get(24).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(24).Width = 86F;
            this.spdHistory_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(25).Label = "Oper In Qty 3";
            this.spdHistory_Sheet1.Columns.Get(25).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(25).Width = 84F;
            this.spdHistory_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(26).Label = "Create Qty 1";
            this.spdHistory_Sheet1.Columns.Get(26).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(26).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(27).Label = "Create Qty 2";
            this.spdHistory_Sheet1.Columns.Get(27).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(27).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(28).Label = "Create Qty 3";
            this.spdHistory_Sheet1.Columns.Get(28).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(28).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(29).Label = "Start Qty 1";
            this.spdHistory_Sheet1.Columns.Get(29).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(29).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(30).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(30).Label = "Start Qty 2";
            this.spdHistory_Sheet1.Columns.Get(30).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(30).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(31).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(31).Label = "Start Qty 3";
            this.spdHistory_Sheet1.Columns.Get(31).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(31).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(32).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(32).Label = "Inventory Flag";
            this.spdHistory_Sheet1.Columns.Get(32).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(32).Width = 86F;
            this.spdHistory_Sheet1.Columns.Get(33).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(33).Label = "Transit Flag";
            this.spdHistory_Sheet1.Columns.Get(33).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(33).Width = 84F;
            this.spdHistory_Sheet1.Columns.Get(34).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(34).Label = "Unit Exist Flag";
            this.spdHistory_Sheet1.Columns.Get(34).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(34).Width = 97F;
            this.spdHistory_Sheet1.Columns.Get(35).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(35).Label = "Inventory Unit";
            this.spdHistory_Sheet1.Columns.Get(35).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(35).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(36).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(36).Label = "Rework Flag";
            this.spdHistory_Sheet1.Columns.Get(36).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(36).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(37).Label = "Rework Code";
            this.spdHistory_Sheet1.Columns.Get(37).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(37).Width = 92F;
            this.spdHistory_Sheet1.Columns.Get(38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(38).Label = "Rework Count";
            this.spdHistory_Sheet1.Columns.Get(38).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(38).Width = 93F;
            this.spdHistory_Sheet1.Columns.Get(39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(39).Label = "Rework Return Flow";
            this.spdHistory_Sheet1.Columns.Get(39).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(39).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(40).Label = "Rework Return Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(40).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(40).Width = 135F;
            this.spdHistory_Sheet1.Columns.Get(41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(41).Label = "Rework Return Oper";
            this.spdHistory_Sheet1.Columns.Get(41).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(41).Width = 134F;
            this.spdHistory_Sheet1.Columns.Get(42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(42).Label = "Rework End Flow";
            this.spdHistory_Sheet1.Columns.Get(42).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(42).Width = 123F;
            this.spdHistory_Sheet1.Columns.Get(43).Label = "Rework End Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(43).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(43).Width = 124F;
            this.spdHistory_Sheet1.Columns.Get(44).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(44).Label = "Rework End Oper";
            this.spdHistory_Sheet1.Columns.Get(44).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(44).Width = 108F;
            this.spdHistory_Sheet1.Columns.Get(45).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(45).Label = "Rework Return Clear Flag";
            this.spdHistory_Sheet1.Columns.Get(45).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(45).Width = 160F;
            this.spdHistory_Sheet1.Columns.Get(46).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(46).Label = "Rework Time";
            this.spdHistory_Sheet1.Columns.Get(46).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(46).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(47).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(47).Label = "NSTD Flag";
            this.spdHistory_Sheet1.Columns.Get(47).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(47).Width = 68F;
            this.spdHistory_Sheet1.Columns.Get(48).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(48).Label = "NSTD Return Flow";
            this.spdHistory_Sheet1.Columns.Get(48).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(48).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(48).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(49).Label = "NSTD Return Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(49).Width = 124F;
            this.spdHistory_Sheet1.Columns.Get(50).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(50).Label = "NSTD Return Oper";
            this.spdHistory_Sheet1.Columns.Get(50).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(50).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(50).Width = 111F;
            this.spdHistory_Sheet1.Columns.Get(51).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(51).Label = "NSTD Time";
            this.spdHistory_Sheet1.Columns.Get(51).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(51).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(51).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(52).Label = "Repair Flag";
            this.spdHistory_Sheet1.Columns.Get(52).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(52).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(52).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(53).Label = "Repair Return Oper";
            this.spdHistory_Sheet1.Columns.Get(53).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(53).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(53).Width = 113F;
            this.spdHistory_Sheet1.Columns.Get(54).Label = "Store Return Flow";
            this.spdHistory_Sheet1.Columns.Get(54).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(54).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(54).Width = 119F;
            this.spdHistory_Sheet1.Columns.Get(55).Label = "Store Return Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(55).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(55).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(55).Width = 119F;
            this.spdHistory_Sheet1.Columns.Get(56).Label = "Store Return Oper";
            this.spdHistory_Sheet1.Columns.Get(56).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(56).Width = 119F;
            this.spdHistory_Sheet1.Columns.Get(57).Label = "Start Flag";
            this.spdHistory_Sheet1.Columns.Get(57).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(57).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(58).Label = "Start Time";
            this.spdHistory_Sheet1.Columns.Get(58).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(58).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(58).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(59).Label = "Start Resource";
            this.spdHistory_Sheet1.Columns.Get(59).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(59).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(60).Label = "End Flag";
            this.spdHistory_Sheet1.Columns.Get(60).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(60).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(61).Label = "End Time";
            this.spdHistory_Sheet1.Columns.Get(61).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(61).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(62).Label = "End Resource";
            this.spdHistory_Sheet1.Columns.Get(62).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(62).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(63).Label = "Sample Flag";
            this.spdHistory_Sheet1.Columns.Get(63).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(63).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(63).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(64).Label = "Sample Wait Flag";
            this.spdHistory_Sheet1.Columns.Get(64).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(64).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(64).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(65).Label = "Sample Result";
            this.spdHistory_Sheet1.Columns.Get(65).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(65).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(65).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(66).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(66).Label = "From To Flag";
            this.spdHistory_Sheet1.Columns.Get(66).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(66).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(66).Width = 88F;
            this.spdHistory_Sheet1.Columns.Get(67).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(67).Label = "From To Lot ID";
            this.spdHistory_Sheet1.Columns.Get(67).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(67).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(67).Width = 102F;
            this.spdHistory_Sheet1.Columns.Get(68).Label = "From To Mat ID";
            this.spdHistory_Sheet1.Columns.Get(68).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(68).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(68).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(69).Label = "From To Mat Version";
            this.spdHistory_Sheet1.Columns.Get(69).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(69).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(69).Width = 107F;
            this.spdHistory_Sheet1.Columns.Get(70).Label = "From To Flow";
            this.spdHistory_Sheet1.Columns.Get(70).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(70).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(70).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(71).Label = "From To Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(71).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(71).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(71).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(72).Label = "From To Oper";
            this.spdHistory_Sheet1.Columns.Get(72).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(72).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(72).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(73).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(73).Label = "From To Qty 1";
            this.spdHistory_Sheet1.Columns.Get(73).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(73).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(73).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(74).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(74).Label = "From To Qty 2";
            this.spdHistory_Sheet1.Columns.Get(74).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(74).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(74).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(75).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(75).Label = "From To Qty 3";
            this.spdHistory_Sheet1.Columns.Get(75).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(75).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(75).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(76).Label = "From To Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(76).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(76).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(76).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(77).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(77).Label = "Ship Code";
            this.spdHistory_Sheet1.Columns.Get(77).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(77).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(77).Width = 107F;
            this.spdHistory_Sheet1.Columns.Get(78).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(78).Label = "Ship Time";
            this.spdHistory_Sheet1.Columns.Get(78).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(78).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(78).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(79).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(79).Label = "Original Due Time";
            this.spdHistory_Sheet1.Columns.Get(79).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(79).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(79).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(80).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(80).Label = "Scheduled Due Time";
            this.spdHistory_Sheet1.Columns.Get(80).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(80).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(80).Width = 133F;
            this.spdHistory_Sheet1.Columns.Get(81).Label = "Factory In Time";
            this.spdHistory_Sheet1.Columns.Get(81).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(81).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(82).Label = "Flow In Time";
            this.spdHistory_Sheet1.Columns.Get(82).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(82).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(83).Label = "Oper In Time";
            this.spdHistory_Sheet1.Columns.Get(83).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(83).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(84).Label = "Reserve Resource";
            this.spdHistory_Sheet1.Columns.Get(84).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(84).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(84).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(85).Label = "Port ID";
            this.spdHistory_Sheet1.Columns.Get(85).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(85).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(85).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(86).Label = "Batch ID";
            this.spdHistory_Sheet1.Columns.Get(86).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(86).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(86).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(87).Label = "Batch Seq";
            this.spdHistory_Sheet1.Columns.Get(87).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(87).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(87).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(88).Label = "Order ID";
            this.spdHistory_Sheet1.Columns.Get(88).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(88).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(88).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(89).Label = "Add Order ID 1";
            this.spdHistory_Sheet1.Columns.Get(89).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(89).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(89).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(90).Label = "Add Order ID 2";
            this.spdHistory_Sheet1.Columns.Get(90).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(90).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(90).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(91).Label = "Add Order ID 3";
            this.spdHistory_Sheet1.Columns.Get(91).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(91).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(91).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(92).Label = "Lot Location 1";
            this.spdHistory_Sheet1.Columns.Get(92).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(92).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(92).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(93).Label = "Lot Location 2";
            this.spdHistory_Sheet1.Columns.Get(93).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(93).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(93).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(94).Label = "Lot Location 3";
            this.spdHistory_Sheet1.Columns.Get(94).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(94).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(94).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(95).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(95).Label = "Lot Cmf 1";
            this.spdHistory_Sheet1.Columns.Get(95).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(95).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(95).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(96).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(96).Label = "Lot Cmf 2";
            this.spdHistory_Sheet1.Columns.Get(96).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(96).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(96).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(97).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(97).Label = "Lot Cmf 3";
            this.spdHistory_Sheet1.Columns.Get(97).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(97).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(97).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(98).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(98).Label = "Lot Cmf 4";
            this.spdHistory_Sheet1.Columns.Get(98).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(98).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(98).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(99).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(99).Label = "Lot Cmf 5";
            this.spdHistory_Sheet1.Columns.Get(99).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(99).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(99).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(100).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(100).Label = "Lot Cmf 6";
            this.spdHistory_Sheet1.Columns.Get(100).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(100).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(100).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(101).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(101).Label = "Lot Cmf 7";
            this.spdHistory_Sheet1.Columns.Get(101).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(101).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(101).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(102).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(102).Label = "Lot Cmf 8";
            this.spdHistory_Sheet1.Columns.Get(102).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(102).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(102).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(103).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(103).Label = "Lot Cmf 9";
            this.spdHistory_Sheet1.Columns.Get(103).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(103).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(103).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(104).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(104).Label = "Lot Cmf 10";
            this.spdHistory_Sheet1.Columns.Get(104).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(104).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(104).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(105).Label = "Lot Cmf 11";
            this.spdHistory_Sheet1.Columns.Get(105).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(105).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(105).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(106).Label = "Lot Cmf 12";
            this.spdHistory_Sheet1.Columns.Get(106).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(106).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(106).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(107).Label = "Lot Cmf 13";
            this.spdHistory_Sheet1.Columns.Get(107).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(107).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(107).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(108).Label = "Lot Cmf 14";
            this.spdHistory_Sheet1.Columns.Get(108).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(108).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(108).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(109).Label = "Lot Cmf 15";
            this.spdHistory_Sheet1.Columns.Get(109).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(109).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(109).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(110).Label = "Lot Cmf 16";
            this.spdHistory_Sheet1.Columns.Get(110).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(110).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(110).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(111).Label = "Lot Cmf 17";
            this.spdHistory_Sheet1.Columns.Get(111).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(111).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(111).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(112).Label = "Lot Cmf 18";
            this.spdHistory_Sheet1.Columns.Get(112).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(112).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(112).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(113).Label = "Lot Cmf 19";
            this.spdHistory_Sheet1.Columns.Get(113).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(113).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(113).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(114).Label = "Lot Cmf 20";
            this.spdHistory_Sheet1.Columns.Get(114).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(114).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(114).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(115).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(115).Label = "Lot Delete Flag";
            this.spdHistory_Sheet1.Columns.Get(115).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(115).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(115).Width = 108F;
            this.spdHistory_Sheet1.Columns.Get(116).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(116).Label = "Lot Delete Code";
            this.spdHistory_Sheet1.Columns.Get(116).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(116).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(116).Width = 128F;
            this.spdHistory_Sheet1.Columns.Get(117).Label = "Bom Set ID";
            this.spdHistory_Sheet1.Columns.Get(117).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(117).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(117).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(118).Label = "Bom Set Version";
            this.spdHistory_Sheet1.Columns.Get(118).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(118).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(118).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(119).Label = "Bom Active Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(119).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(119).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(119).Width = 116F;
            this.spdHistory_Sheet1.Columns.Get(120).Label = "Bom Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(120).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(120).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(120).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(121).Label = "Critical Resource";
            this.spdHistory_Sheet1.Columns.Get(121).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(121).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(121).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(122).Label = "Critical Resource Group";
            this.spdHistory_Sheet1.Columns.Get(122).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(122).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(122).Width = 123F;
            this.spdHistory_Sheet1.Columns.Get(123).Label = "Save Resource 1";
            this.spdHistory_Sheet1.Columns.Get(123).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(123).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(123).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(124).Label = "Save Resource 2";
            this.spdHistory_Sheet1.Columns.Get(124).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(124).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(124).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(125).Label = "Sub Resource";
            this.spdHistory_Sheet1.Columns.Get(125).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(125).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(125).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(126).Label = "Lot Group ID 1";
            this.spdHistory_Sheet1.Columns.Get(126).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(126).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(126).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(127).Label = "Lot Group ID 2";
            this.spdHistory_Sheet1.Columns.Get(127).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(127).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(127).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(128).Label = "Lot Group ID 3";
            this.spdHistory_Sheet1.Columns.Get(128).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(128).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(128).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(129).Label = "Yield 1";
            this.spdHistory_Sheet1.Columns.Get(129).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(129).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(129).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(130).Label = " Yield 2";
            this.spdHistory_Sheet1.Columns.Get(130).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(130).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(130).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(131).Label = "Yield 3";
            this.spdHistory_Sheet1.Columns.Get(131).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(131).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(131).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(132).Label = "Gool Qty";
            this.spdHistory_Sheet1.Columns.Get(132).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(132).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(132).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(133).Label = "Resv Field 1";
            this.spdHistory_Sheet1.Columns.Get(133).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(133).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(133).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(134).Label = "Resv Field 2";
            this.spdHistory_Sheet1.Columns.Get(134).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(134).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(134).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(135).Label = "Resv Field 3";
            this.spdHistory_Sheet1.Columns.Get(135).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(135).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(135).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(136).Label = "Resv Field 4";
            this.spdHistory_Sheet1.Columns.Get(136).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(136).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(136).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(137).Label = "Resv Field 5";
            this.spdHistory_Sheet1.Columns.Get(137).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(137).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(137).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(138).Label = "Resv Flag 1";
            this.spdHistory_Sheet1.Columns.Get(138).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(138).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(138).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(139).Label = "Resv Flag 2";
            this.spdHistory_Sheet1.Columns.Get(139).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(139).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(139).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(140).Label = "Resv Flag 3";
            this.spdHistory_Sheet1.Columns.Get(140).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(140).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(140).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(141).Label = "Resv Flag 4";
            this.spdHistory_Sheet1.Columns.Get(141).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(141).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(141).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(142).Label = "Resv Flag 5";
            this.spdHistory_Sheet1.Columns.Get(142).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(142).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(142).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(143).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(143).Label = "Old Factory";
            this.spdHistory_Sheet1.Columns.Get(143).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(143).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(143).Width = 95F;
            this.spdHistory_Sheet1.Columns.Get(144).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(144).Label = "Old Mat ID";
            this.spdHistory_Sheet1.Columns.Get(144).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(144).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(144).Width = 88F;
            this.spdHistory_Sheet1.Columns.Get(145).Label = "Old Mat Version";
            this.spdHistory_Sheet1.Columns.Get(145).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(145).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(145).Width = 92F;
            this.spdHistory_Sheet1.Columns.Get(146).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(146).Label = "Old Flow";
            this.spdHistory_Sheet1.Columns.Get(146).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(146).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(146).Width = 99F;
            this.spdHistory_Sheet1.Columns.Get(147).Label = "Old Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(147).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(147).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(147).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(148).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(148).Label = "Old Oper";
            this.spdHistory_Sheet1.Columns.Get(148).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(148).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(149).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(149).Label = "Old Qty 1";
            this.spdHistory_Sheet1.Columns.Get(149).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(149).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(149).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(150).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(150).Label = "Old Qty 2";
            this.spdHistory_Sheet1.Columns.Get(150).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(150).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(150).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(151).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(151).Label = "Old Qty 3";
            this.spdHistory_Sheet1.Columns.Get(151).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(151).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(151).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(152).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(152).Label = "Old Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(152).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(152).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(152).Width = 98F;
            this.spdHistory_Sheet1.Columns.Get(153).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(153).Label = "Old Lot Type";
            this.spdHistory_Sheet1.Columns.Get(153).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(153).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(153).Width = 101F;
            this.spdHistory_Sheet1.Columns.Get(154).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(154).Label = "Old Owner Code";
            this.spdHistory_Sheet1.Columns.Get(154).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(154).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(154).Width = 123F;
            this.spdHistory_Sheet1.Columns.Get(155).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(155).Label = "Old Create Code";
            this.spdHistory_Sheet1.Columns.Get(155).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(155).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(155).Width = 114F;
            this.spdHistory_Sheet1.Columns.Get(156).Label = "Old Factory In Time";
            this.spdHistory_Sheet1.Columns.Get(156).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(156).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(156).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(157).Label = "Old Flow In Time";
            this.spdHistory_Sheet1.Columns.Get(157).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(157).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(157).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(158).Label = "Old Oper In Time";
            this.spdHistory_Sheet1.Columns.Get(158).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(158).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(158).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(159).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(159).Label = "Trans Cmf 1";
            this.spdHistory_Sheet1.Columns.Get(159).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(159).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(159).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(160).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(160).Label = "Trans Cmf 2";
            this.spdHistory_Sheet1.Columns.Get(160).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(160).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(160).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(161).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(161).Label = "Trans Cmf 3";
            this.spdHistory_Sheet1.Columns.Get(161).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(161).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(161).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(162).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(162).Label = "Trans Cmf 4";
            this.spdHistory_Sheet1.Columns.Get(162).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(162).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(162).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(163).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(163).Label = "Trans Cmf 5";
            this.spdHistory_Sheet1.Columns.Get(163).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(163).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(163).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(164).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(164).Label = "Trans Cmf 6";
            this.spdHistory_Sheet1.Columns.Get(164).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(164).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(164).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(165).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(165).Label = "Trans Cmf 7";
            this.spdHistory_Sheet1.Columns.Get(165).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(165).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(165).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(166).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(166).Label = "Trans Cmf 8";
            this.spdHistory_Sheet1.Columns.Get(166).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(166).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(166).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(167).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(167).Label = "Trans Cmf 9";
            this.spdHistory_Sheet1.Columns.Get(167).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(167).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(167).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(168).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(168).Label = "Trans Cmf 10";
            this.spdHistory_Sheet1.Columns.Get(168).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(168).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(168).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(169).Label = "Tran Cmf 11";
            this.spdHistory_Sheet1.Columns.Get(169).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(169).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(169).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(170).Label = "Tran Cmf 12";
            this.spdHistory_Sheet1.Columns.Get(170).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(170).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(170).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(171).Label = "Tran Cmf 13";
            this.spdHistory_Sheet1.Columns.Get(171).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(171).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(171).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(172).Label = "Tran Cmf 14";
            this.spdHistory_Sheet1.Columns.Get(172).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(172).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(172).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(173).Label = "Tran Cmf 15";
            this.spdHistory_Sheet1.Columns.Get(173).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(173).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(173).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(174).Label = "Tran Cmf 16";
            this.spdHistory_Sheet1.Columns.Get(174).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(174).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(174).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(175).Label = "Tran Cmf 17";
            this.spdHistory_Sheet1.Columns.Get(175).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(175).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(175).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(176).Label = "Tran Cmf 18";
            this.spdHistory_Sheet1.Columns.Get(176).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(176).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(176).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(177).Label = "Tran Cmf 19";
            this.spdHistory_Sheet1.Columns.Get(177).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(177).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(177).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(178).Label = "Tran Cmf 20";
            this.spdHistory_Sheet1.Columns.Get(178).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(178).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(178).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(179).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(179).Label = "Tran User ID";
            this.spdHistory_Sheet1.Columns.Get(179).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(179).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(179).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(180).Label = "Tran Comment";
            this.spdHistory_Sheet1.Columns.Get(180).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(180).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(180).Width = 86F;
            this.spdHistory_Sheet1.Columns.Get(181).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(181).Label = "Prev Active Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(181).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(181).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(181).Width = 131F;
            this.spdHistory_Sheet1.Columns.Get(182).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(182).Label = "Multi Tr Key";
            this.spdHistory_Sheet1.Columns.Get(182).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(182).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(182).Width = 92F;
            this.spdHistory_Sheet1.Columns.Get(183).Label = "Multi Tr Seq";
            this.spdHistory_Sheet1.Columns.Get(183).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(183).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Top;
            this.spdHistory_Sheet1.Columns.Get(183).Width = 74F;
            this.spdHistory_Sheet1.Columns.Get(184).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(184).Label = "Hist Delete Flag";
            this.spdHistory_Sheet1.Columns.Get(184).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(184).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(184).Width = 98F;
            this.spdHistory_Sheet1.Columns.Get(185).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(185).Label = "Hist Delete Time";
            this.spdHistory_Sheet1.Columns.Get(185).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(185).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(185).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(186).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(186).Label = "Hist Delete User ID";
            this.spdHistory_Sheet1.Columns.Get(186).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(186).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(186).Width = 127F;
            this.spdHistory_Sheet1.Columns.Get(187).Label = "Hist Delete Comment";
            this.spdHistory_Sheet1.Columns.Get(187).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(187).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(187).Width = 116F;
            this.spdHistory_Sheet1.Columns.Get(188).Label = "Sys Tran Time";
            this.spdHistory_Sheet1.Columns.Get(188).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(188).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(188).Width = 125F;
            this.spdHistory_Sheet1.FrozenColumnCount = 3;
            this.spdHistory_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdHistory_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdHistory_Sheet1.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.spdHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdHistory_Sheet1.RowHeader.Visible = false;
            this.spdHistory_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdHistory_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdHistory_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(457, 16);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(257, 21);
            this.pnlPeriod.TabIndex = 6;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(56, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(90, 20);
            this.dtpFrom.TabIndex = 0;
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
            this.dtpTo.Location = new System.Drawing.Point(167, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(90, 20);
            this.dtpTo.TabIndex = 1;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(149, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(14, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            // 
            // frmEDCChangeLotData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(734, 542);
            this.Name = "frmEDCChangeLotData";
            this.Text = "Change Lot Data";
            this.Activated += new System.EventHandler(this.frmEDCChangeLotData_Activated);
            this.Load += new System.EventHandler(this.frmEDCChangeLotData_Load);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlMidMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.pnlLotHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).EndInit();
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            this.ResumeLayout(false);

        }
        
#endregion
        
#region " Constant Definition "
        
        private const int MAX_DATA_COUNT = 1000;
        private const int VALUE_START_COL = 25;

        private const int COL_SET_ID = 14;
        private const int COL_CHAR_SEQ = 16;
        private const int COL_CHAR_ID = 17;
        private const int COL_CHAR_DESC = 18;
        private const int COL_UNIT_SEQ = 20;
        private const int COL_VALUE_SEQ = 22;
        private const int COL_VALUE_COUNT = 24;
        private const int COL_SPEC_OUT_MASK = 50;
        private const int COL_UPDATE_TIME = 52;
        
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
            TRAN_CODE = 1,
            TRAN_TIME = 2,
            FACTORY = 3,
            MAT_ID = 4,
            MAT_VER = 5,
            FLOW = 6,
            FLOW_SEQ_NUM = 7,            
            OPER = 8,
            QTY_1 = 9,
            QTY_2 = 10,
            QTY_3 = 11,
            CARRIER = 12,            
            LOT_TYPE = 13,
            OWNER_CODE = 14,
            CREATE_CODE = 15,
            LOT_PRIORITY = 16,
            LOT_STATUS = 17,
            HOLD_FLAG = 18,
            HOLD_CODE = 19,
            RELEASE_CODE = 20,
            OPER_IN_QTY_1 = 21,
            OPER_IN_QTY_2 = 22,
            OPER_IN_QTY_3 = 23,
            CREATE_QTY_1 = 24,
            CREATE_QTY_2 = 25,
            CREATE_QTY_3 = 26,
            START_QTY_1 = 27,
            START_QTY_2 = 28,
            START_QTY_3 = 29,            
            INV_FLAG = 30,
            TRANSIT_FLAG = 31,
            UNIT_TRACE_FLAG = 32,
            INV_UNIT = 33,
            RWK_FLAG = 34,
            RWK_CODE = 35,
            RWK_COUNT = 36,
            RWK_RET_FLOW = 37,            
            RWK_RET_FLOW_SEQ = 38,            
            RWK_RET_OPER = 39,
            RWK_END_FLOW = 40,
            RWK_END_FLOW_SEQ = 41,
            RWK_END_OPER = 42,
            RWK_RET_CLEAR_FLAG = 43,
            RWK_TIME = 44,
            NSTD_FLAG = 45,
            NSTD_RET_FLOW = 46,
            NSTD_RET_FLOW_SEQ = 47,
            NSTD_RET_OPER = 48,
            NSTD_TIME = 49,
            REPAIR_FLAG = 50,
            REPAIR_RET_OPER = 51,
            START_RETURN_FLOW = 52,
            START_RETURN_FLOW_SEQ = 53,
            START_RETURN_OPER = 54,
            START_FLAG = 55,
            START_TIME = 56,
            START_RESOURCE = 57,
            END_FLAG = 58,
            END_TIME = 59,
            END_RESOURCE = 60,
            SAMPLE_FLAG = 61,
            SAMPLE_TIME = 62,
            SAMPLE_RESULT = 63,
            FROM_TO_FLAG = 64,
            FROM_TO_LOT_ID = 65,
            FROM_TO_MAT_ID = 66,
            FROM_TO_MAT_VER = 67,
            FROM_TO_FLOW = 68,
            FROM_TO_FLOW_SEQ = 69,
            FROM_TO_OPER = 70,
            FROM_TO_QTY_1 = 71,
            FROM_TO_QTY_2 = 72,
            FROM_TO_QTY_3 = 73,
            FROM_TO_HIST_SEQ = 74,
            SHIP_CODE = 75,
            SHIP_TIME = 76,
            ORG_DUE_TIME = 77,
            SCH_DUE_TIME = 78,
            FAC_IN_TIME = 79,
            FLOW_IN_TIME = 80,
            OPER_IN_TIME = 81,
            RESERVER_RESOURCE = 82,
            BATCH_ID = 83,
            BATCH_SEQ = 84,
            ORDER_ID = 85,
            ADD_ORDER_ID_1 = 86,
            ADD_ORDER_ID_2 = 87,
            ADD_ORDER_ID_3 = 88,
            LOT_LOCATION = 89,
            LOT_CMF_1 = 90,
            LOT_CMF_2 = 91,
            LOT_CMF_3 = 92,
            LOT_CMF_4 = 93,
            LOT_CMF_5 = 94,
            LOT_CMF_6 = 95,
            LOT_CMF_7 = 96,
            LOT_CMF_8 = 97,
            LOT_CMF_9 = 98,
            LOT_CMF_10 = 99,
            LOT_CMF_11 = 100,
            LOT_CMF_12 = 101,
            LOT_CMF_13 = 102,
            LOT_CMF_14 = 103,
            LOT_CMF_15 = 104,
            LOT_CMF_16 = 105,
            LOT_CMF_17 = 106,
            LOT_CMF_18 = 107,
            LOT_CMF_19 = 107,
            LOT_CMF_20 = 109,
            LOT_DEL_FLAG = 110,
            LOT_DEL_REASON = 111,
            BOM_SET_ID = 112,
            BOM_SET_VER = 113,
            BOM_ACTIVE_HIST_SEQ = 114,
            BOM_HIST_SEQ = 115,
            CRITICAL_RESOURCE = 116,
            CRITICAL_RESOURCE_GROUP = 117,
            SAVE_RESOURCE_1 = 118,
            SAVE_RESOURCE_2 = 119,
            SUB_RESOURCE = 120,
            LOT_GROUP_ID_1 = 121,
            LOT_GROUP_ID_2 = 122,
            LOT_GROUP_ID_3 = 123,
            RESV_FIELD_1 = 124,
            RESV_FIELD_2 = 125,
            RESV_FIELD_3 = 126,
            RESV_FIELD_4 = 127,
            RESV_FIELD_5 = 128,
            RESV_FLAG_1 = 129,
            RESV_FLAG_2 = 130,
            RESV_FLAG_3 = 131,
            RESV_FLAG_4 = 132,
            RESV_FLAG_5 = 133,
            OLD_FACTORY = 134,
            OLD_MAT_ID = 135,
            OLD_MAT_VER = 136,
            OLD_FLOW = 137,
            OLD_FLOW_SEQ = 138,
            OLD_OPER = 139,
            OLD_QTY_1 = 140,
            OLD_QTY_2 = 141,
            OLD_QTY_3 = 142,
            OLD_HIST_SEQ = 143,
            OLD_LOT_TYPE = 144,
            OLD_OWNER_CODE = 145,
            OLD_CREATE_CODE = 146,
            OLD_FACTORY_IN_TIME = 147,
            OLD_FLOW_IN_TIME = 148,
            OLD_OPER_IN_TIME = 149,
            TRAN_CMF_1 = 150,
            TRAN_CMF_2 = 151,
            TRAN_CMF_3 = 152,
            TRAN_CMF_4 = 153,
            TRAN_CMF_5 = 154,
            TRAN_CMF_6 = 155,
            TRAN_CMF_7 = 156,
            TRAN_CMF_8 = 157,
            TRAN_CMF_9 = 158,
            TRAN_CMF_10 = 159,
            TRAN_CMF_11 = 160,
            TRAN_CMF_12 = 161,
            TRAN_CMF_13 = 162,
            TRAN_CMF_14 = 163,
            TRAN_CMF_15 = 164,
            TRAN_CMF_16 = 165,
            TRAN_CMF_17 = 166,
            TRAN_CMF_18 = 167,
            TRAN_CMF_19 = 168,
            TRAN_CMF_20 = 169,
            TRAN_USER_ID = 170,
            TRAN_COMMENT = 171,
            PREV_ACTIVE_HIST_SEQ = 172,
            MULTI_TR_KEY = 173,            
            HIST_START_SEQ = 174,
            HIST_DEL_FLAG = 175,
            HIST_DEL_TIME = 176,
            HIST_DEL_USER_ID = 177,
            HIST_DELETE_COMMENT = 178,
            //
            //ALT_FLAG = 176,        // spdHistoryø° æ¯¿Ω   - spdHistory Column Index∏¶ Over
            //ALT_RET_FLOW = 177,    // spdHistoryø° æ¯¿Ω   - spdHistory Column Index∏¶ Over
            //ALT_RET_OPER = 178,    // spdHistoryø° æ¯¿Ω   - spdHistory Column Index∏¶ Over
            //ALT_END_FLOW = 179,    // spdHistoryø° æ¯¿Ω   - spdHistory Column Index∏¶ Over
            //ALT_END_OPER = 180,    // spdHistoryø° æ¯¿Ω   - spdHistory Column Index∏¶ Over
            //EVENT_ID = 181,        // spdHistoryø° æ¯¿Ω   - spdHistory Column Index∏¶ Over
            //

        }
        
        private enum DATA_COLUMN
        {
            CHECK_COL = 0,
            LOT_ID = 1,
            HIS_SEQ = 2,
            TRAN_TIME = 3,
            HIS_DEL_FLAG = 4,
            FACTORY = 5,
            MAT_ID = 6,
            MAT_VER = 7, 
            FLOW = 7,
            OPER = 8,
            MEAS_RES_ID = 9,
            PROC_FLOW = 10,
            PROC_OPER = 11,
            PROC_RES_ID = 12,
            COL_SEQ = 13,
            COL_SET_ID = 14,
            COL_SET_VER = 15,
            CHAR_SEQ_NUM = 16,
            CHAR_ID = 17,
            CHAR_DESC = 18,
            SPEC = 19,
            UNIT_SEQ_NUM = 20,
            UNIT_ID = 21,
            VALUE_SEQ_NUM = 22,
            VALUE_TYPE = 23,
            VALUE_COUNT = 24,
            VALUE_1 = 25,
            VALUE_2 = 26,
            VALUE_3 = 27,
            VALUE_4 = 28,
            VALUE_5 = 29,
            VALUE_6 = 30,
            VALUE_7 = 31,
            VALUE_8 = 32,
            VALUE_9 = 33,
            VALUE_10 = 34,
            VALUE_11 = 35,
            VALUE_12 = 36,
            VALUE_13 = 37,
            VALUE_14 = 38,
            VALUE_15 = 39,
            VALUE_16 = 40,
            VALUE_17 = 41,
            VALUE_18 = 42,
            VALUE_19 = 43,
            VALUE_20 = 44,
            VALUE_21 = 45,
            VALUE_22 = 46,
            VALUE_23 = 47,
            VALUE_24 = 48,
            VALUE_25 = 49,
            SPEC_OUT_MASK = 50,
            UPDATE_USER_ID = 51,
            UPDATE_TIME = 52,
            VALUE_TYPE_2 = 53,
            VALUE_COUNT_2 = 54,
        }
        
#endregion
        
#region " Variable Definition "

        private bool bLoadFlag;
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
        private bool CheckCondition(string FuncName)
        {
            
            int i = 0;
            int j = 0;
            int iChkCnt = 0;
            
            try
            {
                switch ( MPCF.Trim(FuncName))
                {
                    case "View_Lot_History":
                        
                        
                        if (dtpFrom.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            dtpFrom.Focus();
                            return false;
                        }
                        
                        if (dtpTo.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            dtpTo.Focus();
                            return false;
                        }

                        if (MPCF.ToInt(MPCF.ToStandardTime(dtpFrom.Value, MPGC.MP_CONVERT_DATETIME_FORMAT)) > MPCF.ToInt(MPCF.ToStandardTime(dtpTo.Value, MPGC.MP_CONVERT_DATETIME_FORMAT)))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(160));
                            dtpFrom.Focus();
                            return false;
                        }
                        break;
                        
                    case "View_Lot_Data":
                        
                        
                        if (MPCF.CheckValue(txtLotID, 1) == false)
                        {
                            return false;
                        }
                        
                        if (spdHistory.ActiveSheet.RowCount == 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(107));
                            spdHistory.Select();
                            return false;
                        }
                        
                        if (spdHistory.ActiveSheet.ActiveRowIndex < 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            spdHistory.Select();
                            return false;
                        }
                        break;
                    case "Change_Lot_Data":


                        if (MPCF.CheckValue(txtLotID, 1) == false)
                        {
                            return false;
                        }
                        
                        if (spdHistory.ActiveSheet.RowCount == 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(107));
                            spdHistory.Select();
                            return false;
                        }
                        
                        if (spdHistory.ActiveSheet.ActiveRowIndex < 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            spdHistory.Select();
                            return false;
                        }
                        
                        if (spdHistory.ActiveSheet.GetValue(spdHistory.ActiveSheet.ActiveRowIndex, MPCF.ToInt(HISTORY_COLUMN.MAT_ID)) == null)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(113));
                            spdHistory.ActiveSheet.SetActiveCell(spdHistory.ActiveSheet.ActiveRowIndex, MPCF.ToInt(HISTORY_COLUMN.MAT_ID));
                            spdHistory.Select();
                        }
                        
                        if (spdHistory.ActiveSheet.GetValue(spdHistory.ActiveSheet.ActiveRowIndex, MPCF.ToInt(HISTORY_COLUMN.FLOW)) == null)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(113));
                            spdHistory.ActiveSheet.SetActiveCell(spdHistory.ActiveSheet.ActiveRowIndex, MPCF.ToInt(HISTORY_COLUMN.FLOW));
                            spdHistory.Select();
                        }
                        
                        if (spdHistory.ActiveSheet.GetValue(spdHistory.ActiveSheet.ActiveRowIndex, MPCF.ToInt( HISTORY_COLUMN.OPER)) == null)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(113));
                            spdHistory.ActiveSheet.SetActiveCell(spdHistory.ActiveSheet.ActiveRowIndex, MPCF.ToInt(HISTORY_COLUMN.OPER));
                            spdHistory.Select();
                        }
                        
                        for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                        {
                            if (System.Convert.ToBoolean(spdData.ActiveSheet.GetValue(i, (int)DATA_COLUMN.CHECK_COL)) == true)
                            {
                                if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, (int)DATA_COLUMN.CHAR_ID)) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdData.ActiveSheet.SetActiveCell(i, (int)DATA_COLUMN.CHAR_ID);
                                    spdData.Select();
                                    return false;
                                }
                                if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, (int)DATA_COLUMN.CHAR_SEQ_NUM)) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdData.ActiveSheet.SetActiveCell(i, (int)DATA_COLUMN.CHAR_SEQ_NUM);
                                    spdData.Select();
                                    return false;
                                }
                                if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, (int)DATA_COLUMN.UNIT_SEQ_NUM)) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdData.ActiveSheet.SetActiveCell(i, (int)DATA_COLUMN.UNIT_SEQ_NUM);
                                    spdData.Select();
                                    return false;
                                }
                                if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, (int)DATA_COLUMN.VALUE_SEQ_NUM)) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdData.ActiveSheet.SetActiveCell(i, (int)DATA_COLUMN.VALUE_SEQ_NUM);
                                    spdData.Select();
                                    return false;
                                }

                                if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, (int)DATA_COLUMN.VALUE_TYPE_2)) == "N")
                                {
                                    for (j = VALUE_START_COL; j < VALUE_START_COL + 25; j++)
                                    {
                                        if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, j)) != "")
                                        {
                                            if (MPCF.CheckNumeric(spdData.ActiveSheet.GetValue(i, j)) == false)
                                            {
                                                MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                                spdData.ActiveSheet.SetActiveCell(i, j);
                                                spdData.Select();
                                                return false;
                                            }
                                        }
                                    }
                                }
                                if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, (int)DATA_COLUMN.UNIT_ID)) == "" && MPCF.Trim(spdData.ActiveSheet.Cells[i, (int)DATA_COLUMN.UNIT_ID].Tag) != "NULL")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdData.ActiveSheet.SetActiveCell(i, (int)DATA_COLUMN.UNIT_ID);
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
        
        // View_Lot_Data()
        //       - View Lot Data by Lot
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        - ByVal c_step As String                        : ?ïÏû• Process Step
        //        - ByVal sLotID As String                    : Lot id
        //       - ByVal iHistSeq As Integer                 : History Sequence
        //        - Optional ByVal sIncludeDelHistory As String = ""  : Delete HistoryÍπåÏ? ?¨Ìï®??Í≤ÉÏù∏ÏßÄ?
        //
        private bool View_Lot_Data(char c_step, string sLotID, int iHistSeq)
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

            TRSNode in_node = new TRSNode("VIEW_LOT_DATA_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_DATA_OUT");

            System.Collections.ArrayList a_values = new System.Collections.ArrayList();

            int iMaxValueCount = 0;
            
            try
            {

                MPCF.ClearList(spdData, true);
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));
                in_node.AddInt("HIST_SEQ", iHistSeq);
                in_node.AddChar("INCLUDE_DEL_HIST", 'Y');
                in_node.AddString("NEXT_COL_SET_ID", " ");
                in_node.AddInt("NEXT_CHAR_SEQ_NUM", 0);
                in_node.AddInt("NEXT_UNIT_SEQ_NUM", 0);
                in_node.AddInt("NEXT_VALUE_SEQ_NUM", 0);
                in_node.AddInt("NEXT_COL_SEQ", 0);

                do
                {
                    if (MPCR.CallService("EDC", "EDC_View_Lot_Data", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdData.ActiveSheet.RowCount;
                        spdData.ActiveSheet.RowCount++;

                        if (out_node.GetList(0)[i].GetChar("HIS_DEL_FLAG") == 'Y')
                        {
                            spdData.ActiveSheet.Cells[iRow, 0, iRow, spdData.ActiveSheet.ColumnCount - 1].ForeColor = Color.Magenta;
                            spdData.ActiveSheet.Cells[iRow, 0, iRow, spdData.ActiveSheet.ColumnCount - 1].BackColor = Color.WhiteSmoke;
                            spdData.ActiveSheet.Cells[iRow, 0, iRow, spdData.ActiveSheet.ColumnCount - 1].Locked = true;

                        }

                        if (iRow == 0)
                        {
                            cls_derived_char_list.GetDerivedInfo(MPCF.Trim(out_node.GetList(0)[i].GetString("COL_SET_ID")), out_node.GetList(0)[i].GetInt("COL_SET_VERSION"), MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")), "", "", "");
                        }

                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.LOT_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.HIS_SEQ].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("HIST_SEQ"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.TRAN_TIME].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_TIME"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.HIS_DEL_FLAG].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("HIS_DEL_FLAG"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.FACTORY].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("FACTORY"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.MAT_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_ID"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.MAT_VER].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("MAT_VER"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.FLOW].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("FLOW"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.OPER].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("OPER"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.MEAS_RES_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("MEAS_RES_ID"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.PROC_FLOW].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("PROC_FLOW"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.PROC_OPER].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("PROC_OPER"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.PROC_RES_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("PROC_RES_ID"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.COL_SEQ].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("COL_SEQ"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.COL_SET_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("COL_SET_ID"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.COL_SET_VER].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("COL_SET_VERSION"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.CHAR_SEQ_NUM].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("CHAR_SEQ_NUM"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.CHAR_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_ID"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.CHAR_DESC].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_DESC"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.SPEC].Value = MPCF.GetSpecInfo(out_node.GetList(0)[i].GetString("UPPER_SPEC_LIMIT"), out_node.GetList(0)[i].GetString("LOWER_SPEC_LIMIT"), out_node.GetList(0)[i].GetString("TARGET_VALUE"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.UNIT_SEQ_NUM].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("UNIT_SEQ_NUM"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.UNIT_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UNIT_ID"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.VALUE_SEQ_NUM].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("VALUE_SEQ_NUM"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.VALUE_TYPE].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("VALUE_TYPE"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.VALUE_COUNT].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("VALUE_COUNT"));

                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.SPEC_OUT_MASK].Value = out_node.GetList(0)[i].GetString("SPEC_OUT_MASK");
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.UPDATE_USER_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_USER_ID"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.UPDATE_TIME].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_TIME"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.VALUE_TYPE_2].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("VALUE_TYPE_2"));
                        spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.VALUE_COUNT_2].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("VALUE_COUNT_2"));

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
                            spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.UNIT_ID].Tag = "NULL";
                        }

                        //Unit Count Check
                        if (iUnitCnt == 0)
                        {
                            spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.UNIT_ID].Locked = true;
                            spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.UNIT_ID].BackColor = System.Drawing.Color.WhiteSmoke;
                        }
                        else
                        {
                            if (sDefUnitFlag == "Y" && sDefUnitID != "" && sUnitID == "")
                            {
                                //DEFAULT UNIT
                                spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.UNIT_ID].Value = sDefUnitID;
                                sUnitID = sDefUnitID;
                            }

                            if ((sDefUnitFlag == "Y" && sDefUnitOvrFlag == "Y" && sUnitTbl != "") || (sDefUnitFlag == "" && sUnitTbl != ""))
                            {
                                spdData.ActiveSheet.SetValue(iRow, (int)DATA_COLUMN.UNIT_ID, sUnitID);
                            }
                        }

                        //Value Cell Lock
                        for (j = VALUE_START_COL + iValueCnt; j < spdData.ActiveSheet.ColumnCount; j++)
                        {
                            spdData.ActiveSheet.Cells[iRow, j].Locked = true;
                            spdData.ActiveSheet.Cells[iRow, j].BackColor = System.Drawing.Color.WhiteSmoke;
                        }

                        //Value Tbl Check
                        for (j = VALUE_START_COL; j < iValueCnt + VALUE_START_COL; j++)
                        {
                            if (MPCF.Trim(out_node.GetList(0)[i].GetChar("VALUE_TYPE")) == "N")
                            {
                                MPCR.SetNumberCell(spdData.ActiveSheet.Cells[iRow, j]);
                            }
                            else
                            {
                                MPCR.SetAsciiCell(spdData.ActiveSheet.Cells[iRow, j]);
                            }
                        }

                        iRow++;
                    }

                    in_node.SetString("NEXT_COL_SET_ID", out_node.GetString("NEXT_COL_SET_ID"));
                    in_node.SetInt("NEXT_CHAR_SEQ_NUM", out_node.GetInt("NEXT_CHAR_SEQ_NUM"));
                    in_node.SetInt("NEXT_UNIT_SEQ_NUM", out_node.GetInt("NEXT_UNIT_SEQ_NUM"));
                    in_node.SetInt("NEXT_VALUE_SEQ_NUM", out_node.GetInt("NEXT_VALUE_SEQ_NUM"));
                    in_node.SetInt("NEXT_COL_SEQ", out_node.GetInt("NEXT_COL_SEQ"));

                } while (MPCF.Trim(in_node.GetString("NEXT_COL_SET_ID")) != "" ||
                         in_node.GetInt("NEXT_CHAR_SEQ_NUM") > 0 ||
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

                if (spdData.ActiveSheet.RowCount > 0)
                {
                    if (iMaxValueCount == 0)
                    {
                        iMaxValueCount = 1;
                    }
                    else if (iMaxValueCount > 25)
                    {
                        iMaxValueCount = 25;
                    }
                    spdData.ActiveSheet.Columns.Get(VALUE_START_COL, VALUE_START_COL + iMaxValueCount - 1).Visible = true;
                    if (iMaxValueCount < 25)
                    {
                        spdData.ActiveSheet.Columns.Get(VALUE_START_COL + iMaxValueCount, VALUE_START_COL + 24).Visible = false;
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
        // change_lot_data()
        //       - Change Lot Data
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Change_Lot_Data(char ProcStep)
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
            int  i_col_set = 0;
            string s_unit_seq = "";
            TRSNode in_node = new TRSNode("CHANGE_LOT_DATA_IN");
            TRSNode out_node = new TRSNode("CHANGE_LOT_DATA_OUT");
            TRSNode char_item, value_item, unit_item, value_seq_item;

            CultureInfo ci_inter = new CultureInfo("en-US");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddInt("HIST_SEQ", MPCF.ToInt(spdHistory.ActiveSheet.GetValue(spdHistory.ActiveSheet.ActiveRowIndex, MPCF.ToInt(HISTORY_COLUMN.HIST_SEQ))));
                in_node.AddString("MAT_ID", MPCF.Trim(spdHistory.ActiveSheet.GetValue(spdHistory.ActiveSheet.ActiveRowIndex, MPCF.ToInt(HISTORY_COLUMN.MAT_ID))));
                in_node.AddInt("MAT_VER", MPCF.ToInt(spdHistory.ActiveSheet.GetValue(spdHistory.ActiveSheet.ActiveRowIndex, MPCF.ToInt(HISTORY_COLUMN.MAT_VER))));
                in_node.AddString("FLOW", MPCF.Trim(spdHistory.ActiveSheet.GetValue(spdHistory.ActiveSheet.ActiveRowIndex, MPCF.ToInt(HISTORY_COLUMN.FLOW))));
                in_node.AddString("OPER", MPCF.Trim(spdHistory.ActiveSheet.GetValue(spdHistory.ActiveSheet.ActiveRowIndex, MPCF.ToInt(HISTORY_COLUMN.OPER))));
                in_node.AddString("TRAN_TIME", MPCF.DestroyDateFormat(MPCF.Trim(spdHistory.ActiveSheet.GetValue(spdHistory.ActiveSheet.ActiveRowIndex, MPCF.ToInt(HISTORY_COLUMN.TRAN_TIME)))));

                char_item = in_node.AddNode("CHAR_LIST");
                unit_item = char_item.AddNode("UNIT_LIST");
                for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                {
                    if (System.Convert.ToBoolean(spdData.ActiveSheet.GetValue(i, (int)DATA_COLUMN.CHECK_COL)) == true)
                    {                        
                        iValueCnt = MPCF.ToInt(spdData.ActiveSheet.GetValue(i, (int)DATA_COLUMN.VALUE_COUNT_2));
                        if (iValueCnt > 25)
                        {
                            if (iValueCnt / 25 >= MPCF.ToInt(spdData.ActiveSheet.GetValue(i, (int)DATA_COLUMN.VALUE_SEQ_NUM)))
                            {
                                iValueCnt  = 25;
                            }
                            else
                            {
                                iValueCnt = iValueCnt % 25;
                            }
                        }

                        if (MPCF.Trim(s_char_id) != MPCF.Trim(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(DATA_COLUMN.CHAR_ID)))
                            || i_col_set.Equals(MPCF.ToInt(spdData.ActiveSheet.GetValue(i, (int)DATA_COLUMN.COL_SEQ))) == false)
                        {
                            if (i_count != 0)
                            {
                                char_item = in_node.AddNode("CHAR_LIST");
                            }
                            s_char_id = MPCF.Trim(spdData.ActiveSheet.GetValue(i, MPCF.ToInt(DATA_COLUMN.CHAR_ID)));
                            i_col_set = MPCF.ToInt(spdData.ActiveSheet.GetValue(i, (int)DATA_COLUMN.COL_SEQ));
                            
                            char_item.AddString("COL_SET_ID", MPCF.Trim(spdData.ActiveSheet.GetValue(i, (int)DATA_COLUMN.COL_SET_ID)));
                            char_item.AddInt("COL_SET_VERSION", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, (int)DATA_COLUMN.COL_SET_VER)));

                            char_item.AddInt("COL_SEQ", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, (int)DATA_COLUMN.COL_SEQ)));
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

                if (MessageCaster.CallService("EDC", "EDC_Change_Lot_Data", in_node, ref out_node) == false)
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
                                    if (char_item.GetString("COL_SET_ID") == MPCF.Trim(spdData.ActiveSheet.Cells[k, COL_SET_ID].Value) &&
                                        char_item.GetString("CHAR_ID") == MPCF.Trim(spdData.ActiveSheet.Cells[k, COL_CHAR_ID].Value) &&
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
                                                if (MPCF.Trim(spdData.ActiveSheet.Rows[k].Tag) == "AUTO")
                                                {
                                                    spdData.ActiveSheet.Cells[k, j].BackColor = Color.Cyan;
                                                }
                                                else
                                                {
                                                    spdData.ActiveSheet.Cells[k, j].BackColor = Color.White;
                                                }
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
                    }
                }

                //spdHistory_SelectionChanged(spdHistory, null);
                
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
                        if (Change_Lot_Data('4') == false)
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
                MPCF.ShowMsgBox(ex.Message);
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
                return this.txtLotID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }        
        
#endregion
        
        private void frmEDCChangeLotData_Load(object sender, System.EventArgs e)
        {
            
            dtpFrom.Value = DateTime.Now.AddMonths(- 1);
            dtpTo.Value = DateTime.Now;
            cls_derived_char_list = new clsDerivedCharList();
        }
        
        private void frmEDCChangeLotData_Activated(object sender, System.EventArgs e)
        {
            
            if (bLoadFlag == false)
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdHistory, true);
                MPCF.ClearList(spdData, true);
                MPCR.SetLotCmfPrompt(spdHistory, 95);
                MPCF.FitLotHistoryDefaultColumnHeader(spdHistory);
                
                if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                {
                    txtLotID.Text = MPGV.gsCurrentLot_ID;
                    WIPLIST.ViewLotHistory(spdHistory, '1', txtLotID.Text, "", "", ' ', null, false, MPGC.MP_TRAN_CODE_LOTEDC);
                    MPCF.FitColumnHeader(spdHistory);
                }
                
                bLoadFlag = true;
            }
            
        }
        
        private void spdHistory_SelectionChanged(System.Object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            
            try
            {
                int iRow = 0;
                
                if (txtLotID.Text == "")
                {
                    return;
                }
                if (spdHistory.ActiveSheet.ActiveRowIndex < 0)
                {
                    return;
                }
                
                iRow = spdHistory.ActiveSheet.ActiveRowIndex;

                if (View_Lot_Data('1', txtLotID.Text, MPCF.ToInt(spdHistory.ActiveSheet.GetValue(iRow, MPCF.ToInt(HISTORY_COLUMN.HIST_SEQ)))) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void txtLotID_TextChanged(System.Object sender, System.EventArgs e)
        {
            
            MPCF.ClearList(spdHistory, true);
            MPCF.ClearList(spdData, true);
            
        }
        
        private void txtLotID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            string sFromTime;
            string sToTime;
            
            sFromTime = MPCF.FromDate(dtpFrom);
            sToTime = MPCF.ToDate(dtpTo);
            
            if (e.KeyChar == (char)13)
            {
                if (txtLotID.Text != "")
                {
                    MPCF.ClearList(spdData, true);
                    if (CheckCondition("View_Lot_History") == false)
                    {
                        return;
                    }
                    if (WIPLIST.ViewLotHistory(spdHistory, '1', txtLotID.Text, sFromTime, sToTime, ' ', null, false, MPGC.MP_TRAN_CODE_LOTEDC) == false)
                    {
                        return;
                    }

                    MPCF.FitColumnHeader(spdHistory);                    
                }
            }
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            if (CheckCondition("Change_Lot_Data") == false)
            {
                return;
            }
            if (Change_Lot_Data('1') == true)
            {
                 
                //spdHistory_SelectionChanged(spdHistory, Nothing)
            }
            
        }
        
        private void spdData_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            spdData.ActiveSheet.SetValue(e.Row, (int)DATA_COLUMN.CHECK_COL, true);            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Lot ID : " + MPCF.Trim(txtLotID.Text);
            MPCF.ExportToExcel(spdData, this.Text, sCond);
        }
        
        private void spdData_EditModeOff(object sender, System.EventArgs e)
        {
            try
            {
                int iColumn;
                int iRow;
                
                iColumn = spdData.ActiveSheet.ActiveColumnIndex;
                iRow = spdData.ActiveSheet.ActiveRowIndex;

                {
                    System.Collections.ArrayList a_values = new System.Collections.ArrayList();
                    string s_char_id;
                    string s_derived_char_id;
                    int i_col_seq;
                    int i_unit_seq;
                    int i_value_count;
                    int i;
                    int j;

                    if (MPCF.Trim(spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.VALUE_TYPE].Value) == "N")
                    {
                        s_char_id = MPCF.Trim(spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.CHAR_ID].Value);
                        i_col_seq = MPCF.ToInt(spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.COL_SEQ].Value);
                        i_unit_seq = MPCF.ToInt(spdData.ActiveSheet.Cells[iRow, (int)DATA_COLUMN.UNIT_SEQ_NUM].Value);

                        for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                        {
                            if (s_char_id == MPCF.Trim(spdData.ActiveSheet.Cells[i, (int)DATA_COLUMN.CHAR_ID].Value) 
                                && i_unit_seq == MPCF.ToInt(spdData.ActiveSheet.Cells[i, (int)DATA_COLUMN.UNIT_SEQ_NUM].Value)
                                && i_col_seq == MPCF.ToInt(spdData.ActiveSheet.Cells[i, (int)DATA_COLUMN.COL_SEQ].Value))
                            {
                                i_value_count = MPCF.ToInt(spdData.ActiveSheet.Cells[i, (int)DATA_COLUMN.VALUE_COUNT].Value);

                                for (j = 0; j < i_value_count; j++)
                                {
                                    a_values.Add(spdData.ActiveSheet.Cells[i, (int)DATA_COLUMN.VALUE_1 + j].Value);
                                }
                            }
                        }

                        // Set Derived Char Location
                        for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                        {                            
                            if (MPCF.Trim(spdData.ActiveSheet.Rows[i].Tag) == "AUTO" && i_col_seq == MPCF.ToInt(spdData.ActiveSheet.Cells[i, (int)DATA_COLUMN.COL_SEQ].Value))
                            {
                                s_derived_char_id = MPCF.Trim(spdData.ActiveSheet.Cells[i, (int)DATA_COLUMN.CHAR_ID].Value);
                                i_value_count = MPCF.ToInt(spdData.ActiveSheet.Cells[i, (int)DATA_COLUMN.VALUE_COUNT].Value);

                                for (j = 0; j < i_value_count; j++)
                                {
                                    cls_derived_char_list.SetCharLocation(s_derived_char_id, spdData.ActiveSheet, j, i, (int)DATA_COLUMN.VALUE_1 + j);
                                }
                            }
                        }
                        
                        cls_derived_char_list.SetValue(s_char_id, i_unit_seq, a_values, true);                        
                        MPCR.RecalculateDerivedParam(spdData, cls_derived_char_list, i_col_seq, (int)DATA_COLUMN.COL_SEQ, (int)DATA_COLUMN.CHAR_ID, (int)DATA_COLUMN.VALUE_1, (int)DATA_COLUMN.VALUE_COUNT, (int)DATA_COLUMN.CHECK_COL);
                    }
                }

                spdData.ActiveSheet.Cells[iRow, iColumn].Font = new System.Drawing.Font(this.Font, FontStyle.Bold);
                if (spdData.ActiveSheet.Cells[iRow, iColumn + 1].Locked == false)
                {
                    spdData.ActiveSheet.SetActiveCell(iRow, iColumn + 1);
                }
                else
                {
                    if (iRow + 1 == spdData.ActiveSheet.RowCount)
                    {
                        return;
                    }
                    spdData.ActiveSheet.SetActiveCell(iRow + 1, (int)DATA_COLUMN.VALUE_1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

#endif // _EDC
        
    }

}

