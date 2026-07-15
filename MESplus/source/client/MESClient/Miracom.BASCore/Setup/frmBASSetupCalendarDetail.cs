using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASSetupCalendarDetail.vb
//   Description : Calendar Setup Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - CheckCondition()        : Check the conditions before transaction
//       - Update_Calendar()       : Create/Update/Delete Resource - Event Relation
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-07-21 : Created by Daniel Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


namespace Miracom.BASCore
{
    public class frmBASSetupCalendarDetail : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmBASSetupCalendarDetail()
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
        



        private FarPoint.Win.Spread.SheetView spdCalendar_Sheet1;
        private FarPoint.Win.Spread.FpSpread spdCalendar;
        private UI.Controls.MCCodeView.MCSPCodeView cdvGcmData;
        private System.Windows.Forms.TreeView tvCalendar;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer3 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer3 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType9 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType10 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType11 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType12 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType13 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType14 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType15 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer4 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer4 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.spdCalendar_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.spdCalendar = new FarPoint.Win.Spread.FpSpread();
            this.tvCalendar = new System.Windows.Forms.TreeView();
            this.cdvGcmData = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdCalendar_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCalendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGcmData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // lblDataCount
            // 
            this.lblDataCount.TabIndex = 0;
            this.lblDataCount.Visible = false;
            // 
            // lblDataCountBase
            // 
            this.lblDataCountBase.Visible = false;
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(5, 8);
            // 
            // btnNext
            // 
            this.btnNext.TabIndex = 1;
            this.btnNext.Visible = false;
            // 
            // txtFind
            // 
            this.txtFind.TabIndex = 0;
            this.txtFind.Visible = false;
            // 
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.spdCalendar);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.tvCalendar);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 513);
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(467, 7);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(558, 7);
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
            this.lblFormTitle.Text = "Calendar Setup (Detail)";
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
            // 
            // spdCalendar_Sheet1
            // 
            this.spdCalendar_Sheet1.Reset();
            spdCalendar_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdCalendar_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdCalendar_Sheet1.ColumnCount = 75;
            spdCalendar_Sheet1.RowCount = 31;
            this.spdCalendar_Sheet1.Cells.Get(0, 0).Value = false;
            this.spdCalendar_Sheet1.Cells.Get(0, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCalendar_Sheet1.Cells.Get(0, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalendar_Sheet1.Cells.Get(0, 9).Value = false;
            this.spdCalendar_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCalendar_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdCalendar_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCalendar_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 1).Locked = false;
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Sys Date";
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 2).CellType = textCellType1;
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Julian Day";
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Year";
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 4).CellType = textCellType2;
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 4).Locked = false;
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Quarter";
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 5).CellType = textCellType3;
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Month";
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Week";
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Day";
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Work Hours";
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 9).CellType = textCellType4;
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Holiday";
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Holiday Desc";
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Shift 1";
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Shift 2";
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Shift 3";
            this.spdCalendar_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Shift 4";
            this.spdCalendar_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCalendar_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            checkBoxCellType1.TextAlign = FarPoint.Win.ButtonTextAlign.TextLeftPictRight;
            this.spdCalendar_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdCalendar_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCalendar_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCalendar_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdCalendar_Sheet1.Columns.Get(0).Width = 35F;
            this.spdCalendar_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType5.ReadOnly = true;
            textCellType5.Static = true;
            this.spdCalendar_Sheet1.Columns.Get(1).CellType = textCellType5;
            this.spdCalendar_Sheet1.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCalendar_Sheet1.Columns.Get(1).Label = "Sys Date";
            this.spdCalendar_Sheet1.Columns.Get(1).Locked = true;
            this.spdCalendar_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalendar_Sheet1.Columns.Get(1).Width = 70F;
            this.spdCalendar_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType6.ReadOnly = true;
            textCellType6.Static = true;
            this.spdCalendar_Sheet1.Columns.Get(2).CellType = textCellType6;
            this.spdCalendar_Sheet1.Columns.Get(2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCalendar_Sheet1.Columns.Get(2).Label = "Julian Day";
            this.spdCalendar_Sheet1.Columns.Get(2).Locked = true;
            this.spdCalendar_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType7.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Numeric;
            textCellType7.MaxLength = 4;
            this.spdCalendar_Sheet1.Columns.Get(3).CellType = textCellType7;
            this.spdCalendar_Sheet1.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCalendar_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCalendar_Sheet1.Columns.Get(3).Label = "Year";
            this.spdCalendar_Sheet1.Columns.Get(3).Locked = false;
            this.spdCalendar_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalendar_Sheet1.Columns.Get(3).Width = 34F;
            textCellType8.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Numeric;
            textCellType8.MaxLength = 1;
            this.spdCalendar_Sheet1.Columns.Get(4).CellType = textCellType8;
            this.spdCalendar_Sheet1.Columns.Get(4).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCalendar_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCalendar_Sheet1.Columns.Get(4).Label = "Quarter";
            this.spdCalendar_Sheet1.Columns.Get(4).Locked = false;
            this.spdCalendar_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalendar_Sheet1.Columns.Get(4).Width = 43F;
            textCellType9.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Numeric;
            textCellType9.MaxLength = 2;
            this.spdCalendar_Sheet1.Columns.Get(5).CellType = textCellType9;
            this.spdCalendar_Sheet1.Columns.Get(5).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCalendar_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCalendar_Sheet1.Columns.Get(5).Label = "Month";
            this.spdCalendar_Sheet1.Columns.Get(5).Locked = false;
            this.spdCalendar_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalendar_Sheet1.Columns.Get(5).Width = 37F;
            textCellType10.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Numeric;
            textCellType10.MaxLength = 2;
            this.spdCalendar_Sheet1.Columns.Get(6).CellType = textCellType10;
            this.spdCalendar_Sheet1.Columns.Get(6).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCalendar_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCalendar_Sheet1.Columns.Get(6).Label = "Week";
            this.spdCalendar_Sheet1.Columns.Get(6).Locked = false;
            this.spdCalendar_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalendar_Sheet1.Columns.Get(6).Width = 46F;
            this.spdCalendar_Sheet1.Columns.Get(7).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdCalendar_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCalendar_Sheet1.Columns.Get(7).Label = "Day";
            this.spdCalendar_Sheet1.Columns.Get(7).Locked = true;
            this.spdCalendar_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalendar_Sheet1.Columns.Get(7).Width = 43F;
            numberCellType1.DecimalPlaces = 2;
            numberCellType1.MaximumValue = 24D;
            numberCellType1.MinimumValue = 0D;
            numberCellType1.ShowSeparator = true;
            this.spdCalendar_Sheet1.Columns.Get(8).CellType = numberCellType1;
            this.spdCalendar_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCalendar_Sheet1.Columns.Get(8).Label = "Work Hours";
            this.spdCalendar_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalendar_Sheet1.Columns.Get(8).Width = 66F;
            checkBoxCellType2.TextAlign = FarPoint.Win.ButtonTextAlign.TextLeftPictRight;
            this.spdCalendar_Sheet1.Columns.Get(9).CellType = checkBoxCellType2;
            this.spdCalendar_Sheet1.Columns.Get(9).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCalendar_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCalendar_Sheet1.Columns.Get(9).Label = "Holiday";
            this.spdCalendar_Sheet1.Columns.Get(9).Locked = false;
            this.spdCalendar_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalendar_Sheet1.Columns.Get(9).Width = 43F;
            textCellType11.MaxLength = 200;
            this.spdCalendar_Sheet1.Columns.Get(10).CellType = textCellType11;
            this.spdCalendar_Sheet1.Columns.Get(10).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCalendar_Sheet1.Columns.Get(10).Label = "Holiday Desc";
            this.spdCalendar_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalendar_Sheet1.Columns.Get(10).Width = 163F;
            textCellType12.MaxLength = 20;
            this.spdCalendar_Sheet1.Columns.Get(11).CellType = textCellType12;
            this.spdCalendar_Sheet1.Columns.Get(11).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCalendar_Sheet1.Columns.Get(11).Label = "Shift 1";
            this.spdCalendar_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalendar_Sheet1.Columns.Get(11).Width = 100F;
            textCellType13.MaxLength = 20;
            this.spdCalendar_Sheet1.Columns.Get(12).CellType = textCellType13;
            this.spdCalendar_Sheet1.Columns.Get(12).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCalendar_Sheet1.Columns.Get(12).Label = "Shift 2";
            this.spdCalendar_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalendar_Sheet1.Columns.Get(12).Width = 100F;
            textCellType14.MaxLength = 20;
            this.spdCalendar_Sheet1.Columns.Get(13).CellType = textCellType14;
            this.spdCalendar_Sheet1.Columns.Get(13).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCalendar_Sheet1.Columns.Get(13).Label = "Shift 3";
            this.spdCalendar_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalendar_Sheet1.Columns.Get(13).Width = 100F;
            textCellType15.MaxLength = 20;
            this.spdCalendar_Sheet1.Columns.Get(14).CellType = textCellType15;
            this.spdCalendar_Sheet1.Columns.Get(14).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCalendar_Sheet1.Columns.Get(14).Label = "Shift 4";
            this.spdCalendar_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCalendar_Sheet1.Columns.Get(14).Width = 100F;
            this.spdCalendar_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdCalendar_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdCalendar_Sheet1.RowHeader.Columns.Get(0).Width = 24F;
            this.spdCalendar_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCalendar_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdCalendar_Sheet1.Rows.Get(0).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(1).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(2).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(3).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(4).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(5).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(6).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(7).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(8).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(9).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(10).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(11).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(12).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(13).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(14).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(15).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(16).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(17).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(18).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(19).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(20).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(21).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(22).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(23).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(24).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(25).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(26).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(27).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(28).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(29).Height = 18F;
            this.spdCalendar_Sheet1.Rows.Get(30).Height = 18F;
            this.spdCalendar_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.MultiRange;
            this.spdCalendar_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCalendar_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdCalendar_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // spdCalendar
            // 
            this.spdCalendar.AccessibleDescription = "spdCalendar, Sheet1, Row 0, Column 0, False";
            this.spdCalendar.BackColor = System.Drawing.SystemColors.Control;
            this.spdCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdCalendar.EditModeReplace = true;
            this.spdCalendar.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdCalendar.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCalendar.HorizontalScrollBar.Name = "";
            this.spdCalendar.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdCalendar.HorizontalScrollBar.TabIndex = 14;
            this.spdCalendar.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCalendar.Location = new System.Drawing.Point(0, 3);
            this.spdCalendar.Name = "spdCalendar";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            columnHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer4.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer4.Name = "";
            columnHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer4.TextRotationAngle = 0D;
            namedStyle1.Renderer = columnHeaderRenderer4;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            rowHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer4.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer4.Name = "";
            rowHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer4.TextRotationAngle = 0D;
            namedStyle2.Renderer = rowHeaderRenderer4;
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
            this.spdCalendar.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdCalendar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdCalendar.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdCalendar.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdCalendar.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdCalendar_Sheet1});
            this.spdCalendar.Size = new System.Drawing.Size(503, 510);
            this.spdCalendar.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdCalendar.TabIndex = 0;
            this.spdCalendar.TabStop = false;
            this.spdCalendar.TextTipDelay = 200;
            this.spdCalendar.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdCalendar.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCalendar.VerticalScrollBar.Name = "";
            this.spdCalendar.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdCalendar.VerticalScrollBar.TabIndex = 15;
            this.spdCalendar.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdCalendar_ButtonClicked);
            this.spdCalendar.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdCalendar_EditChange);
            // 
            // tvCalendar
            // 
            this.tvCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCalendar.Location = new System.Drawing.Point(3, 3);
            this.tvCalendar.Name = "tvCalendar";
            this.tvCalendar.Size = new System.Drawing.Size(229, 510);
            this.tvCalendar.TabIndex = 0;
            this.tvCalendar.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCalendar_AfterSelect);
            // 
            // cdvGcmData
            // 
            this.cdvGcmData.BackColor = System.Drawing.SystemColors.Control;
            this.cdvGcmData.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGcmData.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGcmData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGcmData.Location = new System.Drawing.Point(0, 0);
            this.cdvGcmData.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGcmData.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGcmData.Name = "MCSPCodeView";
            this.cdvGcmData.Size = new System.Drawing.Size(20, 20);
            this.cdvGcmData.SmallImageList = null;
            this.cdvGcmData.TabIndex = 0;
            this.cdvGcmData.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvGcmData.VisibleColumnHeader = false;
            this.cdvGcmData.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvGcmData_SelectedItemChanged);
            // 
            // frmBASSetupCalendarDetail
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmBASSetupCalendarDetail";
            this.Text = "Calendar Setup (Detail)";
            this.Activated += new System.EventHandler(this.frmBASSetupCalendarDetail_Activated);
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
            ((System.ComponentModel.ISupportInitialize)(this.spdCalendar_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCalendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGcmData)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const int COL_SEL = 0;
        private const int COL_SYS_DATE = 1;
        private const int COL_JULIAN = 2;
        private const int COL_YEAR = 3;
        private const int COL_QUARTER = 4;
        private const int COL_MONTH = 5;
        private const int COL_WEEK = 6;
        private const int COL_DAY = 7;
        private const int COL_WORK_HOURS = 8;
        private const int COL_HOLIDAY = 9;
        private const int COL_HOLIDESC = 10;
        private const int COL_SHIFT1 = 11;
        private const int COL_SHIFT2 = 12;
        private const int COL_SHIFT3 = 13;
        private const int COL_SHIFT4 = 14;
        private const int COL_CMF_START = 15;
        private const int COL_GRP_START = 55;
        
        #endregion
        
        #region " Variable Definition "
        
        bool LoadFlag;
        
        #endregion
        
        #region " Function Definition "
        
        private bool CheckCondition(char sFuncName, string sProcStep)
        {
            
            int i = 0;
            int iCount = 0;
            
            try
            {
                // Update/Delete 하고자 하는 항목이 1개라도 선택되어 있는지 여부 Check
                for (i = 0; i < spdCalendar.ActiveSheet.RowCount; i++)
                {
                    if (spdCalendar.ActiveSheet.Cells[i, COL_SEL].Value != null && Convert.ToBoolean(spdCalendar.ActiveSheet.Cells[i, COL_SEL].Value) == true)
                    {
                        iCount++;
                    }
                }
                if (iCount == 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    return false;
                }
                
                switch (sFuncName)
                {
                    case MPGC.MP_STEP_CREATE:
                    case MPGC.MP_STEP_UPDATE:

                        for (i = COL_CMF_START; i < spdCalendar.ActiveSheet.ColumnCount; i += 2)
                        {
                            if (spdCalendar.ActiveSheet.Columns[i].Visible == false) continue;
                            if (spdCalendar.ActiveSheet.ColumnHeader.Cells[0, i].Font == null) continue;
                            if (spdCalendar.ActiveSheet.ColumnHeader.Cells[0, i].Font.Bold == false) continue;

                            for(int k = 0; k < spdCalendar.ActiveSheet.RowCount; k++)
                            {
                                if (spdCalendar.ActiveSheet.Cells[k, COL_SEL].Value == null || Convert.ToBoolean(spdCalendar.ActiveSheet.Cells[k, COL_SEL].Value) == false) continue;

                                if (MPCF.Trim(spdCalendar.ActiveSheet.Cells[k, i].Value) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdCalendar.ActiveSheet.SetActiveCell(k, i);
                                    spdCalendar.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Center);
                                    spdCalendar.Focus();
                                    return false;
                                }
                            }
                        }
                        
                        break;
                    case MPGC.MP_STEP_DELETE:
                        
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
        
        private void AddTreeItem(string item, TreeNode parent, int icon)
        {
            TreeNode node;
            TreeNode YearNode;
            TreeNode MonthNode;
            int i;
            int j;
            int iCurYear;
            
            iCurYear = DateTime.Now.Year;
            
            node = parent.Nodes.Add(item);
            node.ImageIndex = icon;
            node.SelectedImageIndex = icon;
            
            for (i = iCurYear - 5; i <= iCurYear + 5; i++)
            {
                YearNode = node.Nodes.Add(i.ToString());
                YearNode.ImageIndex = (int)SMALLICON_INDEX.IDX_YEAR;
                YearNode.SelectedImageIndex = (int)SMALLICON_INDEX.IDX_YEAR;
                
                for (j = 1; j <= 12; j++)
                {
                    MonthNode = YearNode.Nodes.Add(j.ToString());
                    MonthNode.ImageIndex = (int)SMALLICON_INDEX.IDX_MONTH;
                    MonthNode.SelectedImageIndex = (int)SMALLICON_INDEX.IDX_MONTH;
                }
                
            }
            
        }
        
        private bool GetCalendarType()
        {
            TreeNode FactoryNode;
            TreeNode WorkNode;
            
            //tvCalendar.ShowRootLines = False
            FactoryNode = tvCalendar.Nodes.Add("Factory Base");
            FactoryNode.ImageIndex = (int)SMALLICON_INDEX.IDX_CATEGORY;
            FactoryNode.SelectedImageIndex = (int)SMALLICON_INDEX.IDX_CATEGORY;
            
            WorkNode = tvCalendar.Nodes.Add("Work Base");
            WorkNode.ImageIndex = (int)SMALLICON_INDEX.IDX_CATEGORY;
            WorkNode.SelectedImageIndex = (int)SMALLICON_INDEX.IDX_CATEGORY;
            
            AddTreeItem(MPGV.gsFactory, FactoryNode, (int)SMALLICON_INDEX.IDX_FACTORY);
            
            View_Calendar_List('1', WorkNode); // Get Work Calendar ID List
            
            return true;
            
        }
        
        private bool View_Calendar_List(char c_step, TreeNode select_node)
        {
            TRSNode in_node = new TRSNode("VIEW_CALENDAR_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_CALENDAR_LIST_OUT");

            int i;
            int iRow;
            
            MPCF.ClearList(spdCalendar, true);
            
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step; // 1 : Calendar List,  2 : Work Calendar ID List
            
            if (c_step == '1')
            {
                in_node.AddChar("CALENDAR_TYPE", 'W');
            }
            else
            {
                in_node.AddChar("CALENDAR_TYPE", 'F');
            }

            if (select_node.SelectedImageIndex == (int)SMALLICON_INDEX.IDX_MONTH && c_step == '2')
            {
                in_node.AddString("CALENDAR_ID", select_node.Parent.Parent.Text);
                in_node.AddInt("YEAR", MPCF.ToInt(select_node.Parent.Text));
                in_node.AddInt("MONTH", MPCF.ToInt(select_node.Text));                
            }

            if (MPCR.CallService("BAS", "BAS_View_Calendar_List", in_node, ref out_node) == false)
            {
                return false;
            }

            
            if (c_step == '1')
            {
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    AddTreeItem(out_node.GetList(0)[i].GetString("CALENDAR_ID"), select_node, (int)SMALLICON_INDEX.IDX_CALENDAR);
                }
                
            }
            else if (c_step == '2')
            {
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    TRSNode node = out_node.GetList(0)[i];

                    iRow = spdCalendar.ActiveSheet.RowCount;
                    spdCalendar.ActiveSheet.RowCount++;
                    
                    spdCalendar.ActiveSheet.Cells[iRow, COL_SYS_DATE].Value = MPCF.MakeDateFormat(node.GetString("SYS_DATE"), DATE_TIME_FORMAT.DATE);
                    spdCalendar.ActiveSheet.Cells[iRow, COL_JULIAN].Value = node.GetInt("JULIAN_DAY");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_YEAR].Value = node.GetInt("PLAN_YEAR");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_QUARTER].Value = node.GetInt("PLAN_QUARTER");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_MONTH].Value = node.GetInt("PLAN_MONTH");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_WEEK].Value = node.GetInt("PLAN_WEEK");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_WORK_HOURS].Value = node.GetDouble("WORK_HOURS");
                    switch (node.GetChar("HOLIDAY_FLAG"))
                    {
                        case 'Y':
                            
                            spdCalendar.ActiveSheet.Cells[iRow, COL_HOLIDAY].Value = true;
                            spdCalendar.ActiveSheet.Cells[iRow, COL_HOLIDESC].Value = node.GetString("HOLIDAY_DESC");
                            break;
                        case 'N':
                            
                            spdCalendar.ActiveSheet.Cells[iRow, COL_HOLIDAY].Value = false;
                            spdCalendar.ActiveSheet.Cells[iRow, COL_HOLIDESC].Value = "";
                            break;
                        default:
                            
                            spdCalendar.ActiveSheet.Cells[iRow, COL_HOLIDAY].Value = false;
                            spdCalendar.ActiveSheet.Cells[iRow, COL_HOLIDESC].Value = "";
                            break;
                    }
                    spdCalendar.ActiveSheet.Cells[iRow, COL_SHIFT1].Value = node.GetString("SHIFT_1");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_SHIFT2].Value = node.GetString("SHIFT_2");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_SHIFT3].Value = node.GetString("SHIFT_3");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_SHIFT4].Value = node.GetString("SHIFT_4");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_DAY].Value = SetDayoftheWeek(node.GetInt("DAY"));

                    spdCalendar.ActiveSheet.Cells[iRow, COL_CMF_START + 0].Value = node.GetString("CAL_CMF_1");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_CMF_START + 2].Value = node.GetString("CAL_CMF_2");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_CMF_START + 4].Value = node.GetString("CAL_CMF_3");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_CMF_START + 6].Value = node.GetString("CAL_CMF_4");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_CMF_START + 8].Value = node.GetString("CAL_CMF_5");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_CMF_START + 10].Value = node.GetString("CAL_CMF_6");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_CMF_START + 12].Value = node.GetString("CAL_CMF_7");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_CMF_START + 14].Value = node.GetString("CAL_CMF_8");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_CMF_START + 16].Value = node.GetString("CAL_CMF_9");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_CMF_START + 18].Value = node.GetString("CAL_CMF_10");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_CMF_START + 20].Value = node.GetString("CAL_CMF_11");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_CMF_START + 22].Value = node.GetString("CAL_CMF_12");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_CMF_START + 24].Value = node.GetString("CAL_CMF_13");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_CMF_START + 26].Value = node.GetString("CAL_CMF_14");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_CMF_START + 28].Value = node.GetString("CAL_CMF_15");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_CMF_START + 30].Value = node.GetString("CAL_CMF_16");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_CMF_START + 32].Value = node.GetString("CAL_CMF_17");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_CMF_START + 34].Value = node.GetString("CAL_CMF_18");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_CMF_START + 36].Value = node.GetString("CAL_CMF_19");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_CMF_START + 38].Value = node.GetString("CAL_CMF_20");

                    spdCalendar.ActiveSheet.Cells[iRow, COL_GRP_START + 0].Value = node.GetString("CAL_GRP_1");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_GRP_START + 2].Value = node.GetString("CAL_GRP_2");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_GRP_START + 4].Value = node.GetString("CAL_GRP_3");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_GRP_START + 6].Value = node.GetString("CAL_GRP_4");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_GRP_START + 8].Value = node.GetString("CAL_GRP_5");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_GRP_START + 10].Value = node.GetString("CAL_GRP_6");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_GRP_START + 12].Value = node.GetString("CAL_GRP_7");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_GRP_START + 14].Value = node.GetString("CAL_GRP_8");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_GRP_START + 16].Value = node.GetString("CAL_GRP_9");
                    spdCalendar.ActiveSheet.Cells[iRow, COL_GRP_START + 18].Value = node.GetString("CAL_GRP_10");
                }
            }

            for (i = 0; i < 20; i ++)
            {
                if (spdCalendar.ActiveSheet.Columns[(i * 2) + 1 + COL_CMF_START].Visible == false) continue;
                if (MPCF.Trim(spdCalendar.ActiveSheet.Columns[(i * 2) + COL_CMF_START].Tag) != "") continue;

                for (int k = 0; k < spdCalendar.ActiveSheet.RowCount; k++)
                {
                    spdCalendar.ActiveSheet.Cells[k, (i * 2) + COL_CMF_START].ColumnSpan = 2;
                }
            }
            
            return true;
        }
        
        private string SetDayoftheWeek(int iDay)
        {
            string sDay;
            
            switch (iDay)
            {
                case 0:
                    
                    sDay = MPCF.FindLanguage("Sun", 0);
                    break;
                case 1:
                    
                    sDay = MPCF.FindLanguage("Mon", 0);
                    break;
                case 2:
                    
                    sDay = MPCF.FindLanguage("Tues", 0);
                    break;
                case 3:
                    
                    sDay = MPCF.FindLanguage("Wed", 0);
                    break;
                case 4:
                    
                    sDay = MPCF.FindLanguage("Thur", 0);
                    break;
                case 5:
                    
                    sDay = MPCF.FindLanguage("Fri", 0);
                    break;
                case 6:
                    
                    sDay = MPCF.FindLanguage("Sat", 0);
                    break;
                default:
                    
                    sDay = "";
                    break;
            }
            
            return sDay;
            
        }
        
        private bool Update_Calendar_List()
        {
            TRSNode in_node = new TRSNode("UPDATE_CALENDAR_LIST_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode node;

            int i;
            string TempSysDate;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            
            if (!(tvCalendar.SelectedNode == null))
            {
                if (tvCalendar.SelectedNode.SelectedImageIndex == (int)SMALLICON_INDEX.IDX_MONTH)
                {                
                    in_node.AddString("CALENDAR_ID", tvCalendar.SelectedNode.Parent.Parent.Text);
                    if (tvCalendar.SelectedNode.Parent.Parent.SelectedImageIndex == (int)SMALLICON_INDEX.IDX_FACTORY)
                    {
                        in_node.AddChar("CALENDAR_TYPE", 'F');
                    }
                    else
                    {
                        in_node.AddChar("CALENDAR_TYPE", 'W');
                    }
                }
            }

            for (i = 0; i < spdCalendar.ActiveSheet.RowCount; i++)
            {
                if (spdCalendar.ActiveSheet.Cells[i, COL_SEL].Value == null || Convert.ToBoolean(spdCalendar.ActiveSheet.Cells[i, COL_SEL].Value) == false) continue;

                if (spdCalendar.ActiveSheet.Cells[i, COL_YEAR].Text == "" || spdCalendar.ActiveSheet.Cells[i, COL_QUARTER].Text == "" || spdCalendar.ActiveSheet.Cells[i, COL_MONTH].Text == "" || spdCalendar.ActiveSheet.Cells[i, COL_WEEK].Text == "")
                {
                    spdCalendar.ActiveSheet.Cells[i, COL_SEL].Value = false;
                    return false;
                }

                node = in_node.AddNode("DAY_LIST");

                TempSysDate = MPCF.DestroyDateFormat(spdCalendar.ActiveSheet.Cells[i, COL_SYS_DATE].Text, DATE_TIME_FORMAT.DATE);

                node.AddInt("SYS_YEAR", MPCF.ToInt(TempSysDate.Length > 0 ? TempSysDate.Substring(0, 4) : ""));
                node.AddInt("SYS_MONTH", MPCF.ToInt(TempSysDate.Length > 0 ? TempSysDate.Substring(4, 2) : ""));
                node.AddInt("SYS_DAY", MPCF.ToInt(TempSysDate.Length > 0 ? TempSysDate.Substring(6, 2) : ""));
                node.AddString("SYS_DATE", TempSysDate);
                node.AddDouble("WORK_HOURS", MPCF.ToDbl(spdCalendar.ActiveSheet.Cells[i, COL_WORK_HOURS].Text));

                if (spdCalendar.ActiveSheet.Cells[i, COL_HOLIDAY].Value != null && Convert.ToBoolean(spdCalendar.ActiveSheet.Cells[i, COL_HOLIDAY].Value) == true)
                {
                    node.AddChar("HOLIDAY_FLAG", 'Y');
                }

                node.AddString("HOLIDAY_DESC", spdCalendar.ActiveSheet.Cells[i, COL_HOLIDESC].Text);
                node.AddInt("PLAN_YEAR", MPCF.ToInt(spdCalendar.ActiveSheet.Cells[i, COL_YEAR].Text));
                node.AddInt("PLAN_QUARTER", MPCF.ToInt(spdCalendar.ActiveSheet.Cells[i, COL_QUARTER].Text));
                node.AddInt("PLAN_MONTH", MPCF.ToInt(spdCalendar.ActiveSheet.Cells[i, COL_MONTH].Text));
                node.AddInt("PLAN_WEEK", MPCF.ToInt(spdCalendar.ActiveSheet.Cells[i, COL_WEEK].Text));
                node.AddString("SHIFT_1", spdCalendar.ActiveSheet.Cells[i, COL_SHIFT1].Text);
                node.AddString("SHIFT_2", spdCalendar.ActiveSheet.Cells[i, COL_SHIFT2].Text);
                node.AddString("SHIFT_3", spdCalendar.ActiveSheet.Cells[i, COL_SHIFT3].Text);
                node.AddString("SHIFT_4", spdCalendar.ActiveSheet.Cells[i, COL_SHIFT4].Text);

                node.AddString("CAL_CMF_1", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_CMF_START + 0].Value));
                node.AddString("CAL_CMF_2", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_CMF_START + 2].Value));
                node.AddString("CAL_CMF_3", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_CMF_START + 4].Value));
                node.AddString("CAL_CMF_4", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_CMF_START + 6].Value));
                node.AddString("CAL_CMF_5", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_CMF_START + 8].Value));
                node.AddString("CAL_CMF_6", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_CMF_START + 10].Value));
                node.AddString("CAL_CMF_7", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_CMF_START + 12].Value));
                node.AddString("CAL_CMF_8", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_CMF_START + 14].Value));
                node.AddString("CAL_CMF_9", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_CMF_START + 16].Value));
                node.AddString("CAL_CMF_10", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_CMF_START + 18].Value));
                node.AddString("CAL_CMF_11", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_CMF_START + 20].Value));
                node.AddString("CAL_CMF_12", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_CMF_START + 22].Value));
                node.AddString("CAL_CMF_13", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_CMF_START + 24].Value));
                node.AddString("CAL_CMF_14", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_CMF_START + 26].Value));
                node.AddString("CAL_CMF_15", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_CMF_START + 28].Value));
                node.AddString("CAL_CMF_16", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_CMF_START + 30].Value));
                node.AddString("CAL_CMF_17", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_CMF_START + 32].Value));
                node.AddString("CAL_CMF_18", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_CMF_START + 34].Value));
                node.AddString("CAL_CMF_19", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_CMF_START + 36].Value));
                node.AddString("CAL_CMF_20", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_CMF_START + 38].Value));

                node.AddString("CAL_GRP_1", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_GRP_START + 0].Value));
                node.AddString("CAL_GRP_2", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_GRP_START + 2].Value));
                node.AddString("CAL_GRP_3", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_GRP_START + 4].Value));
                node.AddString("CAL_GRP_4", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_GRP_START + 6].Value));
                node.AddString("CAL_GRP_5", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_GRP_START + 8].Value));
                node.AddString("CAL_GRP_6", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_GRP_START + 10].Value));
                node.AddString("CAL_GRP_7", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_GRP_START + 12].Value));
                node.AddString("CAL_GRP_8", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_GRP_START + 14].Value));
                node.AddString("CAL_GRP_9", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_GRP_START + 16].Value));
                node.AddString("CAL_GRP_10", MPCF.Trim(spdCalendar.ActiveSheet.Cells[i, COL_GRP_START + 18].Value));
            }

            if (MPCR.CallService("BAS", "BAS_Update_Calendar_List", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);
            
            return true;
        }
        
        private bool Delete_Calendar_List()
        {
            TRSNode in_node = new TRSNode("DELETE_CALENDAR_LIST_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode node;

            int i;
            string TempDateString;

            in_node.ProcStep = '1';
            
            if (!(tvCalendar.SelectedNode == null))
            {
                if (tvCalendar.SelectedNode.SelectedImageIndex == (int)SMALLICON_INDEX.IDX_MONTH)
                {
                    in_node.AddString("CALENDAR_ID", tvCalendar.SelectedNode.Parent.Parent.Text);
                }
            }
            
            for (i = 0; i < spdCalendar.ActiveSheet.RowCount; i++)
            {
                if (spdCalendar.ActiveSheet.Cells[i, 0].Value != null && Convert.ToBoolean(spdCalendar.ActiveSheet.Cells[i, 0].Value) == true)
                {
                    node = in_node.AddNode("CALENDAR_LIST");

                    TempDateString = MPCF.DestroyDateFormat(spdCalendar.ActiveSheet.Cells[i, COL_SYS_DATE].Text, DATE_TIME_FORMAT.DATE);

                    node.AddInt("SYS_YEAR", MPCF.ToInt(TempDateString.Length > 0 ? TempDateString.Substring(0, 4) : ""));
                    node.AddInt("SYS_MONTH", MPCF.ToInt(TempDateString.Length > 0 ? TempDateString.Substring(4, 2) : ""));
                    node.AddInt("SYS_DAY", MPCF.ToInt(TempDateString.Length > 0 ? TempDateString.Substring(6, 2) : ""));
                }
            }

            if (MPCR.CallService("BAS", "BAS_Delete_Calendar_List", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);
            
            return true;
            
        }

        private bool SetCmfGrpItems()
        {
            TRSNode out_node = new TRSNode("CMF_OUT");
            List<TRSNode> item_list;
            int i;

            if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_CMF_CALENDAR, ref out_node, "", true) == false)
            {
                return false;
            }

            item_list = out_node.GetList("DATA");
            for (i = 0; i < item_list.Count; i++)
            {
                if (item_list[i].GetString("PROMPT") == "")
                {
                    spdCalendar.ActiveSheet.Columns[(i * 2) + COL_CMF_START].Width = 0;
                    spdCalendar.ActiveSheet.Columns[(i * 2) + COL_CMF_START].Resizable = false;
                    spdCalendar.ActiveSheet.Columns[(i * 2) + COL_CMF_START].Visible = false;
                    spdCalendar.ActiveSheet.Columns[(i * 2) + 1 + COL_CMF_START].Width = 0;
                    spdCalendar.ActiveSheet.Columns[(i * 2) + 1 + COL_CMF_START].Resizable = false;
                    spdCalendar.ActiveSheet.Columns[(i * 2) + 1 + COL_CMF_START].Visible = false;
                }

                spdCalendar.ActiveSheet.ColumnHeader.Cells[0, (i * 2) + COL_CMF_START].ColumnSpan = 2;
                spdCalendar.ActiveSheet.ColumnHeader.Cells[0, (i * 2) + COL_CMF_START].Text = item_list[i].GetString("PROMPT");

                spdCalendar.ActiveSheet.Columns[(i * 2) + COL_CMF_START].Width = 80;
                spdCalendar.ActiveSheet.Columns[(i * 2) + COL_CMF_START].Resizable = true;
                spdCalendar.ActiveSheet.Columns[(i * 2) + COL_CMF_START].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                spdCalendar.ActiveSheet.Columns[(i * 2) + 1 + COL_CMF_START].Width = 20;
                spdCalendar.ActiveSheet.Columns[(i * 2) + 1 + COL_CMF_START].Resizable = false;

                if (item_list[i].GetChar("OPT") == 'Y')
                {
                    spdCalendar.ActiveSheet.ColumnHeader.Cells[0, (i * 2) + COL_CMF_START].Font = new Font(spdCalendar.Font, FontStyle.Bold); 
                }

                if (item_list[i].GetChar("FORMAT") == 'A')
                {
                    FarPoint.Win.Spread.CellType.TextCellType textCell = new FarPoint.Win.Spread.CellType.TextCellType();
                    spdCalendar.ActiveSheet.Columns[(i * 2) + COL_CMF_START].CellType = textCell;
                }
                else if (item_list[i].GetChar("FORMAT") == 'N')
                {
                    FarPoint.Win.Spread.CellType.NumberCellType numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                    numCell.DecimalPlaces = 0;
                    numCell.ShowSeparator = true;

                    spdCalendar.ActiveSheet.Columns[(i * 2) + COL_CMF_START].CellType = numCell;
                }
                else if (item_list[i].GetChar("FORMAT") == 'F')
                {
                    FarPoint.Win.Spread.CellType.NumberCellType numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                    numCell.DecimalPlaces = 3;
                    numCell.ShowSeparator = true;

                    spdCalendar.ActiveSheet.Columns[(i * 2) + COL_CMF_START].CellType = numCell;
                }

                if (item_list[i].GetString("TABLE_NAME") != "")
                {
                    FarPoint.Win.Spread.CellType.ButtonCellType btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                    btnCell.Text = "...";
                    spdCalendar.ActiveSheet.Columns[(i * 2) + 1 + COL_CMF_START].CellType = btnCell;
                    spdCalendar.ActiveSheet.Columns[(i * 2) + COL_CMF_START].Locked = true;
                    spdCalendar.ActiveSheet.Columns[(i * 2) + COL_CMF_START].Tag = item_list[i].GetString("TABLE_NAME");
                }
            }

            if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_GRP_CALENDAR, ref out_node, "", true) == false)
            {
                return false;
            }

            FarPoint.Win.Spread.CellType.ButtonCellType btnCell1;
            string s_table_name;

            item_list = out_node.GetList("DATA");
            for (i = 0; i < item_list.Count; i++)
            {
                if (item_list[i].GetString("PROMPT") == "")
                {
                    spdCalendar.ActiveSheet.Columns[(i * 2) + COL_GRP_START].Width = 0;
                    spdCalendar.ActiveSheet.Columns[(i * 2) + COL_GRP_START].Resizable = false;
                    spdCalendar.ActiveSheet.Columns[(i * 2) + COL_GRP_START].Visible = false;
                    spdCalendar.ActiveSheet.Columns[(i * 2) + 1 + COL_GRP_START].Width = 0;
                    spdCalendar.ActiveSheet.Columns[(i * 2) + 1 + COL_GRP_START].Resizable = false;
                    spdCalendar.ActiveSheet.Columns[(i * 2) + 1 + COL_GRP_START].Visible = false;
                }

                spdCalendar.ActiveSheet.Columns[(i * 2) + COL_GRP_START].Width = 80;
                spdCalendar.ActiveSheet.Columns[(i * 2) + COL_GRP_START].Resizable = true;
                spdCalendar.ActiveSheet.Columns[(i * 2) + COL_GRP_START].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                spdCalendar.ActiveSheet.Columns[(i * 2) + 1 + COL_GRP_START].Width = 20;
                spdCalendar.ActiveSheet.Columns[(i * 2) + 1 + COL_GRP_START].Resizable = false;

                spdCalendar.ActiveSheet.ColumnHeader.Cells[0, (i * 2) + COL_GRP_START].ColumnSpan = 2;
                spdCalendar.ActiveSheet.ColumnHeader.Cells[0, (i * 2) + COL_GRP_START].Text = item_list[i].GetString("PROMPT");
                spdCalendar.ActiveSheet.ColumnHeader.Cells[0, (i * 2) + COL_GRP_START].Font = new Font(spdCalendar.Font, FontStyle.Bold);

                s_table_name = item_list[i].GetString("TABLE_NAME");
                if (s_table_name == "")
                {
                    switch (i)
                    {
                        case 0: s_table_name = MPGC.MP_GCM_CALENDAR_GRP_1; break;
                        case 1: s_table_name = MPGC.MP_GCM_CALENDAR_GRP_2; break;
                        case 2: s_table_name = MPGC.MP_GCM_CALENDAR_GRP_3; break;
                        case 3: s_table_name = MPGC.MP_GCM_CALENDAR_GRP_4; break;
                        case 4: s_table_name = MPGC.MP_GCM_CALENDAR_GRP_5; break;
                        case 5: s_table_name = MPGC.MP_GCM_CALENDAR_GRP_6; break;
                        case 6: s_table_name = MPGC.MP_GCM_CALENDAR_GRP_7; break;
                        case 7: s_table_name = MPGC.MP_GCM_CALENDAR_GRP_8; break;
                        case 8: s_table_name = MPGC.MP_GCM_CALENDAR_GRP_9; break;
                        case 9: s_table_name = MPGC.MP_GCM_CALENDAR_GRP_10; break;
                    }
                }

                btnCell1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
                btnCell1.Text = "...";
                spdCalendar.ActiveSheet.Columns[(i * 2) + 1 + COL_GRP_START].CellType = btnCell1;
                spdCalendar.ActiveSheet.Columns[(i * 2) + COL_GRP_START].Locked = true;
                spdCalendar.ActiveSheet.Columns[(i * 2) + COL_GRP_START].Tag = s_table_name;
            }

            return true;
        }

        
        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.tvCalendar;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }
        
        #endregion
        
        private void frmBASSetupCalendarDetail_Activated(object sender, System.EventArgs e)
        {
            if (LoadFlag == false)
            {
                int i;
                
                for (i = COL_SHIFT1; i <= COL_SHIFT4; i++)
                {
                    spdCalendar.ActiveSheet.Columns[i].Visible = false;
                }
                
                MPCF.InitTreeView(tvCalendar);
                if (GetCalendarType() == false)
                {
                    return;
                }

                SetCmfGrpItems();
                
                LoadFlag = true;
            }
        }
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_UPDATE, "1") == false)
            {
                return;
            }
            
            if (Update_Calendar_List() == true)
            {
                if (!(tvCalendar.SelectedNode == null))
                {
                    if (tvCalendar.SelectedNode.SelectedImageIndex == (int)SMALLICON_INDEX.IDX_MONTH)
                    {
                        View_Calendar_List('2', tvCalendar.SelectedNode);
                    }
                    else
                    {
                        MPCF.ClearList(spdCalendar, true);
                    }
                }
            }
            
        }
        
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            
            if (CheckCondition(MPGC.MP_STEP_DELETE, "1") == false)
            {
                return;
            }
            
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            
            if (Delete_Calendar_List() == true)
            {
                if (!(tvCalendar.SelectedNode == null))
                {
                    if (tvCalendar.SelectedNode.SelectedImageIndex == (int)SMALLICON_INDEX.IDX_MONTH)
                    {
                        View_Calendar_List('2', tvCalendar.SelectedNode);
                    }
                    else
                    {
                        MPCF.ClearList(spdCalendar, true);
                    }
                }
            }
            
        }
        
        private void tvCalendar_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            
            if (!(tvCalendar.SelectedNode == null))
            {
                if (tvCalendar.SelectedNode.SelectedImageIndex == (int)SMALLICON_INDEX.IDX_MONTH)
                {
                    View_Calendar_List('2', tvCalendar.SelectedNode);
                }
                else
                {
                    MPCF.ClearList(spdCalendar, true);
                }
            }
        }
        
        private void spdCalendar_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == COL_HOLIDESC)
            {
                if (MPCF.Trim(spdCalendar.ActiveSheet.Cells[e.Row, COL_HOLIDESC].Value) == "")
                {
                    spdCalendar.ActiveSheet.Cells[e.Row, COL_HOLIDAY].Value = false;
                }
                else
                {
                    spdCalendar.ActiveSheet.Cells[e.Row, COL_HOLIDAY].Value = true;
                    spdCalendar.ActiveSheet.Cells[e.Row, COL_WORK_HOURS].Value = 0;
                }
            }
            
            spdCalendar.ActiveSheet.Cells[e.Row, COL_SEL].Value = true;
        }
        
        private void spdCalendar_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == COL_HOLIDAY)
            {
                spdCalendar.ActiveSheet.Cells[e.Row, COL_SEL].Value = true;

                if (spdCalendar.ActiveSheet.Cells[e.Row, COL_HOLIDAY].Value != null &&
                    Convert.ToBoolean(spdCalendar.ActiveSheet.Cells[e.Row, COL_HOLIDAY].Value) == true)
                {
                    spdCalendar.ActiveSheet.Cells[e.Row, COL_WORK_HOURS].Value = 0;
                }
            }
            if (e.Column > COL_CMF_START)
            {
                string s_table_name = MPCF.Trim(spdCalendar.ActiveSheet.Columns[e.Column - 1].Tag);

                cdvGcmData.Init();
                MPCF.InitListView(cdvGcmData.GetListView);
                cdvGcmData.Columns.Add("Data", 50, HorizontalAlignment.Left);
                cdvGcmData.Columns.Add("Desc", 50, HorizontalAlignment.Left);
                if (BASLIST.ViewGCMDataList(cdvGcmData.GetListView, '1', s_table_name) == false) return;
                cdvGcmData.InsertEmptyRow(0, 1);

                if (cdvGcmData.ShowPopupList(e.Row, e.Column) == false) return;
            }
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                MPCF.InitTreeView(tvCalendar);
                if (GetCalendarType() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvGcmData_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            spdCalendar.ActiveSheet.Cells[e.Row, COL_SEL].Value = true;
            spdCalendar.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
        }
    }
    
}
