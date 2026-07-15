
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPViewLotDefectList.vb
//   Description : View Lot Defect List
//
//   MES Version : 4.1.0.0
//
//   Function List
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-07 : Created by SKJIN
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public class frmWIPViewLotDefectList : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPViewLotDefectList()
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
        private System.Windows.Forms.CheckBox chkIncludeDelHistory;
        protected FarPoint.Win.Spread.FpSpread spdDefectData;
        protected FarPoint.Win.Spread.SheetView spdDefectData_LotInfo;
        private System.Windows.Forms.CheckBox chkIncludeCleanHistory;
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
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.chkIncludeDelHistory = new System.Windows.Forms.CheckBox();
            this.spdDefectData = new FarPoint.Win.Spread.FpSpread();
            this.spdDefectData_LotInfo = new FarPoint.Win.Spread.SheetView();
            this.chkIncludeCleanHistory = new System.Windows.Forms.CheckBox();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefectData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefectData_LotInfo)).BeginInit();
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
            this.pnlViewTop.Size = new System.Drawing.Size(742, 50);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.chkIncludeCleanHistory);
            this.grpOption.Controls.Add(this.txtLotID);
            this.grpOption.Controls.Add(this.lblLotID);
            this.grpOption.Controls.Add(this.chkIncludeDelHistory);
            this.grpOption.Size = new System.Drawing.Size(742, 50);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdDefectData);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 50);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 456);
            this.pnlViewMid.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 506);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Lot Defect List";
            // 
            // txtLotID
            // 
            this.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLotID.Location = new System.Drawing.Point(120, 16);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(200, 20);
            this.txtLotID.TabIndex = 1;
            this.txtLotID.TextChanged += new System.EventHandler(this.txtLotID_TextChanged);
            this.txtLotID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotID_KeyPress);
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(16, 19);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            this.lblLotID.TabIndex = 0;
            this.lblLotID.Text = "Lot ID";
            // 
            // chkIncludeDelHistory
            // 
            this.chkIncludeDelHistory.AutoSize = true;
            this.chkIncludeDelHistory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIncludeDelHistory.Location = new System.Drawing.Point(508, 19);
            this.chkIncludeDelHistory.Name = "chkIncludeDelHistory";
            this.chkIncludeDelHistory.Size = new System.Drawing.Size(136, 18);
            this.chkIncludeDelHistory.TabIndex = 3;
            this.chkIncludeDelHistory.Text = "Include Delete History";
            // 
            // spdDefectData
            // 
            this.spdDefectData.AccessibleDescription = "spdDefectData, LotInfo, Row 0, Column 0, ";
            this.spdDefectData.BackColor = System.Drawing.SystemColors.Control;
            this.spdDefectData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdDefectData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdDefectData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDefectData.HorizontalScrollBar.Name = "";
            this.spdDefectData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdDefectData.HorizontalScrollBar.TabIndex = 2;
            this.spdDefectData.Location = new System.Drawing.Point(0, 0);
            this.spdDefectData.MoveActiveOnFocus = false;
            this.spdDefectData.Name = "spdDefectData";
            this.spdDefectData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdDefectData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdDefectData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdDefectData_LotInfo});
            this.spdDefectData.Size = new System.Drawing.Size(742, 456);
            this.spdDefectData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdDefectData.TabIndex = 0;
            this.spdDefectData.TabStop = false;
            this.spdDefectData.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.spdDefectData.TextTipDelay = 200;
            this.spdDefectData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdDefectData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDefectData.VerticalScrollBar.Name = "";
            this.spdDefectData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdDefectData.VerticalScrollBar.TabIndex = 3;
            // 
            // spdDefectData_LotInfo
            // 
            this.spdDefectData_LotInfo.Reset();
            spdDefectData_LotInfo.SheetName = "LotInfo";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdDefectData_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdDefectData_LotInfo.ColumnCount = 34;
            spdDefectData_LotInfo.RowCount = 1;
            this.spdDefectData_LotInfo.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefectData_LotInfo.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdDefectData_LotInfo.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefectData_LotInfo.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 0).Value = "Tran Time";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 1).Value = "Defect Code";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 2).Value = "Sub Lot ID";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 3).Value = "Count";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 4).Value = "Loc X";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 5).Value = "Loc Y";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 6).Value = "Loc Z";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 7).Value = "Cell X";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 8).Value = "Cell Y";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 9).Value = "Cell Z";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 10).Value = "Hist Seq.";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 11).Value = "Tran User ID";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 12).Value = "Clean Flag";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 13).Value = "Clean Histoy Seq.";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 14).Value = "Clean User ID";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 15).Value = "Clean Time";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 16).Value = "Material ID";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 17).Value = "Mat Ver";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 18).Value = "Flow";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 19).Value = "Operation";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 20).Value = "Resource ID";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 21).Value = "SubResource ID";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 22).Value = "Cause Flow";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 23).Value = "Cause Operation";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 24).Value = "Cause Resource ID";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 25).Value = "Cause SubResource ID";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 26).Value = "Check User 1";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 27).Value = "Check User 2";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 28).Value = "Attach File 1";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 29).Value = "Attach File 2";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 30).Value = "Attach File 3";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 31).Value = "Attach File 4";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 32).Value = "Attach File 5";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 33).Value = "Comment";
            this.spdDefectData_LotInfo.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefectData_LotInfo.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdDefectData_LotInfo.Columns.Get(0).Label = "Tran Time";
            this.spdDefectData_LotInfo.Columns.Get(0).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(0).Width = 106F;
            this.spdDefectData_LotInfo.Columns.Get(1).BackColor = System.Drawing.Color.White;
            this.spdDefectData_LotInfo.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdDefectData_LotInfo.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDefectData_LotInfo.Columns.Get(1).Label = "Defect Code";
            this.spdDefectData_LotInfo.Columns.Get(1).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefectData_LotInfo.Columns.Get(1).Width = 76F;
            this.spdDefectData_LotInfo.Columns.Get(2).Label = "Sub Lot ID";
            this.spdDefectData_LotInfo.Columns.Get(2).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(2).Width = 114F;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.MaximumValue = 9999999D;
            numberCellType1.MinimumValue = 0D;
            this.spdDefectData_LotInfo.Columns.Get(3).CellType = numberCellType1;
            this.spdDefectData_LotInfo.Columns.Get(3).Label = "Count";
            this.spdDefectData_LotInfo.Columns.Get(3).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(3).Width = 52F;
            this.spdDefectData_LotInfo.Columns.Get(4).CellType = numberCellType2;
            this.spdDefectData_LotInfo.Columns.Get(4).Label = "Loc X";
            this.spdDefectData_LotInfo.Columns.Get(4).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(4).Width = 54F;
            this.spdDefectData_LotInfo.Columns.Get(5).CellType = numberCellType3;
            this.spdDefectData_LotInfo.Columns.Get(5).Label = "Loc Y";
            this.spdDefectData_LotInfo.Columns.Get(5).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(5).Width = 53F;
            this.spdDefectData_LotInfo.Columns.Get(6).CellType = numberCellType4;
            this.spdDefectData_LotInfo.Columns.Get(6).Label = "Loc Z";
            this.spdDefectData_LotInfo.Columns.Get(6).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(6).Width = 52F;
            numberCellType5.DecimalPlaces = 0;
            numberCellType5.MaximumValue = 9999999D;
            numberCellType5.MinimumValue = 0D;
            this.spdDefectData_LotInfo.Columns.Get(7).CellType = numberCellType5;
            this.spdDefectData_LotInfo.Columns.Get(7).Label = "Cell X";
            this.spdDefectData_LotInfo.Columns.Get(7).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(7).Width = 56F;
            numberCellType6.DecimalPlaces = 0;
            numberCellType6.MaximumValue = 9999999D;
            numberCellType6.MinimumValue = 0D;
            this.spdDefectData_LotInfo.Columns.Get(8).CellType = numberCellType6;
            this.spdDefectData_LotInfo.Columns.Get(8).Label = "Cell Y";
            this.spdDefectData_LotInfo.Columns.Get(8).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(8).Width = 55F;
            numberCellType7.DecimalPlaces = 0;
            numberCellType7.MaximumValue = 9999999D;
            numberCellType7.MinimumValue = 0D;
            this.spdDefectData_LotInfo.Columns.Get(9).CellType = numberCellType7;
            this.spdDefectData_LotInfo.Columns.Get(9).Label = "Cell Z";
            this.spdDefectData_LotInfo.Columns.Get(9).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(9).Width = 52F;
            this.spdDefectData_LotInfo.Columns.Get(10).Label = "Hist Seq.";
            this.spdDefectData_LotInfo.Columns.Get(10).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(11).Label = "Tran User ID";
            this.spdDefectData_LotInfo.Columns.Get(11).Width = 74F;
            this.spdDefectData_LotInfo.Columns.Get(12).Label = "Clean Flag";
            this.spdDefectData_LotInfo.Columns.Get(12).Width = 70F;
            this.spdDefectData_LotInfo.Columns.Get(13).Label = "Clean Histoy Seq.";
            this.spdDefectData_LotInfo.Columns.Get(13).Width = 102F;
            this.spdDefectData_LotInfo.Columns.Get(14).Label = "Clean User ID";
            this.spdDefectData_LotInfo.Columns.Get(14).Width = 87F;
            this.spdDefectData_LotInfo.Columns.Get(15).Label = "Clean Time";
            this.spdDefectData_LotInfo.Columns.Get(15).Width = 80F;
            this.spdDefectData_LotInfo.Columns.Get(16).Label = "Material ID";
            this.spdDefectData_LotInfo.Columns.Get(16).Width = 69F;
            this.spdDefectData_LotInfo.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefectData_LotInfo.Columns.Get(17).Label = "Mat Ver";
            this.spdDefectData_LotInfo.Columns.Get(17).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefectData_LotInfo.Columns.Get(18).Label = "Flow";
            this.spdDefectData_LotInfo.Columns.Get(18).Width = 54F;
            this.spdDefectData_LotInfo.Columns.Get(20).Label = "Resource ID";
            this.spdDefectData_LotInfo.Columns.Get(20).Width = 76F;
            this.spdDefectData_LotInfo.Columns.Get(21).Label = "SubResource ID";
            this.spdDefectData_LotInfo.Columns.Get(21).Width = 89F;
            this.spdDefectData_LotInfo.Columns.Get(22).Label = "Cause Flow";
            this.spdDefectData_LotInfo.Columns.Get(22).Width = 82F;
            this.spdDefectData_LotInfo.Columns.Get(23).Label = "Cause Operation";
            this.spdDefectData_LotInfo.Columns.Get(23).Width = 95F;
            this.spdDefectData_LotInfo.Columns.Get(24).Label = "Cause Resource ID";
            this.spdDefectData_LotInfo.Columns.Get(24).Width = 121F;
            this.spdDefectData_LotInfo.Columns.Get(25).Label = "Cause SubResource ID";
            this.spdDefectData_LotInfo.Columns.Get(25).Width = 129F;
            this.spdDefectData_LotInfo.Columns.Get(26).Label = "Check User 1";
            this.spdDefectData_LotInfo.Columns.Get(26).Width = 96F;
            this.spdDefectData_LotInfo.Columns.Get(27).Label = "Check User 2";
            this.spdDefectData_LotInfo.Columns.Get(27).Width = 86F;
            this.spdDefectData_LotInfo.Columns.Get(28).Label = "Attach File 1";
            this.spdDefectData_LotInfo.Columns.Get(28).Width = 76F;
            this.spdDefectData_LotInfo.Columns.Get(29).Label = "Attach File 2";
            this.spdDefectData_LotInfo.Columns.Get(29).Width = 76F;
            this.spdDefectData_LotInfo.Columns.Get(30).Label = "Attach File 3";
            this.spdDefectData_LotInfo.Columns.Get(30).Width = 72F;
            this.spdDefectData_LotInfo.Columns.Get(31).Label = "Attach File 4";
            this.spdDefectData_LotInfo.Columns.Get(31).Width = 74F;
            this.spdDefectData_LotInfo.Columns.Get(32).Label = "Attach File 5";
            this.spdDefectData_LotInfo.Columns.Get(32).Width = 69F;
            this.spdDefectData_LotInfo.Columns.Get(33).Label = "Comment";
            this.spdDefectData_LotInfo.Columns.Get(33).Width = 137F;
            this.spdDefectData_LotInfo.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdDefectData_LotInfo.RowHeader.Columns.Default.Resizable = false;
            this.spdDefectData_LotInfo.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefectData_LotInfo.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdDefectData_LotInfo.Rows.Default.Height = 17F;
            this.spdDefectData_LotInfo.Rows.Get(0).Height = 20F;
            this.spdDefectData_LotInfo.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdDefectData_LotInfo.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefectData_LotInfo.SheetCornerStyle.Parent = "CornerDefault";
            this.spdDefectData_LotInfo.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdDefectData_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // chkIncludeCleanHistory
            // 
            this.chkIncludeCleanHistory.AutoSize = true;
            this.chkIncludeCleanHistory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIncludeCleanHistory.Location = new System.Drawing.Point(336, 19);
            this.chkIncludeCleanHistory.Name = "chkIncludeCleanHistory";
            this.chkIncludeCleanHistory.Size = new System.Drawing.Size(132, 18);
            this.chkIncludeCleanHistory.TabIndex = 2;
            this.chkIncludeCleanHistory.Text = "Include Clean History";
            // 
            // frmWIPViewLotDefectList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPViewLotDefectList";
            this.Text = "View Lot Defect List";
            this.Activated += new System.EventHandler(this.frmWIPViewLotDefectList_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdDefectData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefectData_LotInfo)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        
        #endregion
        
        #region " Variable Definition "
        
        bool LoadFlag;
        
        #endregion
        
        #region " Function Definition "
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2", "3")
        //
        private void ClearData(string ProcStep)
        {
            try
            {
                if (ProcStep == "1")
                {
                    MPCF.FieldClear(this);
                    spdDefectData.Sheets[0].RowCount = 0;
                }
                else if (ProcStep == "2")
                {
                    MPCF.FieldClear(this, txtLotID);
                    spdDefectData.Sheets[0].RowCount = 0;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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
        private bool CheckCondition(string ProcStep)
        {

            if (MPCF.CheckValue(txtLotID, 1) == false)
            {
                return false;
            }
            
            return true;
            
        }
        
        
        //
        // CheckCondition()
        //       - View Lot Defect List
        // Return Value
        //       - Boolean : True or False
        //
        private bool ViewLotDefectList()
        {

            int i;
            int iRow;

            TRSNode in_node = new TRSNode("VIEW_LOT_DEFECT_LIST_DETAIL_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_DEFECT_LIST_DETAIL_OUT");


            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));

            if (chkIncludeCleanHistory.Checked == true)
            {
                in_node.AddChar("INCLUDE_CLEAN_HIST", 'Y');
            }
            else
            {
                in_node.AddChar("INCLUDE_CLEAN_HIST", ' ');
            }
            if (chkIncludeDelHistory.Checked == true)
            {
                in_node.AddChar("INCLUDE_DEL_HIST", 'Y');
            }
            else
            {
                in_node.AddChar("INCLUDE_DEL_HIST", ' ');
            }

            spdDefectData.Sheets[0].RowCount = 0;
            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Lot_Defect_List_Detail", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {

                    FarPoint.Win.Spread.SheetView with_1 = spdDefectData.Sheets[0];

                    iRow = with_1.RowCount;
                    with_1.RowCount++;

                    with_1.Cells[iRow, 0].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));
                    with_1.Cells[iRow, 1].Value = out_node.GetList(0)[i].GetString("DEFECT_CODE");
                    with_1.Cells[iRow, 2].Value = out_node.GetList(0)[i].GetString("SUBLOT_ID");
                    with_1.Cells[iRow, 3].Value = out_node.GetList(0)[i].GetDouble("DEFECT_QTY");
                    with_1.Cells[iRow, 4].Value = out_node.GetList(0)[i].GetDouble("LOC_X");
                    with_1.Cells[iRow, 5].Value = out_node.GetList(0)[i].GetDouble("LOC_Y");
                    with_1.Cells[iRow, 6].Value = out_node.GetList(0)[i].GetDouble("LOC_Z");
                    with_1.Cells[iRow, 7].Value = out_node.GetList(0)[i].GetInt("CELL_X");
                    with_1.Cells[iRow, 8].Value = out_node.GetList(0)[i].GetInt("CELL_Y");
                    with_1.Cells[iRow, 9].Value = out_node.GetList(0)[i].GetInt("CELL_Z");
                    with_1.Cells[iRow, 10].Value = out_node.GetList(0)[i].GetInt("HIST_SEQ");

                    with_1.Cells[iRow, 11].Value = out_node.GetList(0)[i].GetString("TRAN_USER_ID");
                    with_1.Cells[iRow, 12].Value = out_node.GetList(0)[i].GetChar("CLEAN_FLAG");
                    with_1.Cells[iRow, 13].Value = out_node.GetList(0)[i].GetInt("CLEAN_HIST_SEQ");
                    with_1.Cells[iRow, 14].Value = out_node.GetList(0)[i].GetString("CLEAN_USER_ID");
                    with_1.Cells[iRow, 15].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CLEAN_TIME"));
                    with_1.Cells[iRow, 16].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                    with_1.Cells[iRow, 16].Value = out_node.GetList(0)[i].GetInt("MAT_VER");
                    with_1.Cells[iRow, 17].Value = out_node.GetList(0)[i].GetString("FLOW");
                    with_1.Cells[iRow, 18].Value = out_node.GetList(0)[i].GetString("OPER");
                    with_1.Cells[iRow, 19].Value = out_node.GetList(0)[i].GetString("RES_ID");
                    with_1.Cells[iRow, 20].Value = out_node.GetList(0)[i].GetString("SUBRES_ID");

                    with_1.Cells[iRow, 21].Value = out_node.GetList(0)[i].GetString("CAUSE_FLOW");
                    with_1.Cells[iRow, 22].Value = out_node.GetList(0)[i].GetString("CAUSE_OPER");
                    with_1.Cells[iRow, 23].Value = out_node.GetList(0)[i].GetString("CAUSE_RES_ID");
                    with_1.Cells[iRow, 24].Value = out_node.GetList(0)[i].GetString("CAUSE_SUBRES_ID");
                    with_1.Cells[iRow, 25].Value = out_node.GetList(0)[i].GetString("CHK_USER_ID_1");
                    with_1.Cells[iRow, 26].Value = out_node.GetList(0)[i].GetString("CHK_USER_ID_2");
                    with_1.Cells[iRow, 27].Value = out_node.GetList(0)[i].GetString("ATTACH_FILE_1");
                    with_1.Cells[iRow, 28].Value = out_node.GetList(0)[i].GetString("ATTACH_FILE_2");
                    with_1.Cells[iRow, 29].Value = out_node.GetList(0)[i].GetString("ATTACH_FILE_3");
                    with_1.Cells[iRow, 30].Value = out_node.GetList(0)[i].GetString("ATTACH_FILE_4");
                    with_1.Cells[iRow, 31].Value = out_node.GetList(0)[i].GetString("ATTACH_FILE_5");
                    with_1.Cells[iRow, 32].Value = out_node.GetList(0)[i].GetString("DEFECT_COMMENT");
                }

                in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));

            } while (in_node.GetInt("NEXT_HIST_SEQ") > 0 || in_node.GetInt("NEXT_SEQ_NUM") > 0);

            MPCF.FitColumnHeader(spdDefectData);

            return true;

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
        
        private void frmWIPViewLotDefectList_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (LoadFlag == false)
                {
                    
                    //Lot ?•ë³´ ê°€?¸ì˜¤ê¸?
                    ClearData("1");
                    
                    LoadFlag = true;
                    
                    if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                    {
                        txtLotID.Text = MPGV.gsCurrentLot_ID;
                        if (ViewLotDefectList() == false)
                        {
                            return;
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("1") == false)
                {
                    return;
                }
                if (ViewLotDefectList() == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void txtLotID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (ViewLotDefectList() == false)
                {
                    txtLotID.Focus();
                    return;
                }
            }
        }
        
        private void txtLotID_TextChanged(object sender, System.EventArgs e)
        {
            if (txtLotID.Text == "")
            {
                ClearData("1");
            }
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;
            
            sCond = "Lot ID : " + txtLotID.Text;
            if (chkIncludeCleanHistory.Checked == true)
            {
                sCond = sCond + "\r" + "Include Clean History : Y";
            }
            else
            {
                sCond = sCond + "\r" + "Include Clean History : N";
            }
            if (chkIncludeDelHistory.Checked == true)
            {
                sCond = sCond + "\r" + "Include Delete History : Y";
            }
            else
            {
                sCond = sCond + "\r" + "Include Delete History : N";
            }

            MPCF.ExportToExcel(spdDefectData, this.Text, sCond);
            
        }
    }
    
}
