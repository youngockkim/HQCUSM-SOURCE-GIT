
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
//   File Name   : frmORDViewProductionPlan.vb
//   Description : MES Cient Form View Production Plan
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
//       - 2004-07-14 : Created by CM Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _ORD = True Then

namespace Miracom.ORDCore
{
    public class frmORDViewProductionPlan : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmORDViewProductionPlan()
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
        private FarPoint.Win.Spread.FpSpread spdPlan;
        private FarPoint.Win.Spread.SheetView spdPlan_Sheet1;
        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private System.Windows.Forms.Label lblTo;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.spdPlan = new FarPoint.Win.Spread.FpSpread();
            this.spdPlan_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdPlan_Sheet1)).BeginInit();
            this.pnlPeriod.SuspendLayout();
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
            this.pnlViewTop.Size = new System.Drawing.Size(742, 47);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvMaterial);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Size = new System.Drawing.Size(742, 47);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdPlan);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 47);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 466);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Production Plan";
            // 
            // spdPlan
            // 
            this.spdPlan.AccessibleDescription = "spdPlan, Sheet1, Row 0, Column 0, ";
            this.spdPlan.BackColor = System.Drawing.SystemColors.Control;
            this.spdPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdPlan.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdPlan.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdPlan.HorizontalScrollBar.Name = "";
            this.spdPlan.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdPlan.HorizontalScrollBar.TabIndex = 2;
            this.spdPlan.Location = new System.Drawing.Point(0, 3);
            this.spdPlan.Name = "spdPlan";
            this.spdPlan.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdPlan.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdPlan.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdPlan_Sheet1});
            this.spdPlan.Size = new System.Drawing.Size(742, 463);
            this.spdPlan.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdPlan.TabIndex = 0;
            this.spdPlan.TabStop = false;
            this.spdPlan.TextTipDelay = 200;
            this.spdPlan.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdPlan.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdPlan.VerticalScrollBar.Name = "";
            this.spdPlan.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdPlan.VerticalScrollBar.TabIndex = 3;
            this.spdPlan.SetViewportLeftColumn(0, 0, 2);
            this.spdPlan.SetActiveViewport(0, 0, -1);
            // 
            // spdPlan_Sheet1
            // 
            this.spdPlan_Sheet1.Reset();
            spdPlan_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdPlan_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdPlan_Sheet1.ColumnCount = 2;
            spdPlan_Sheet1.RowCount = 5;
            this.spdPlan_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPlan_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdPlan_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPlan_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdPlan_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Mat ID";
            this.spdPlan_Sheet1.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdPlan_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Mat Ver";
            this.spdPlan_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlan_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPlan_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdPlan_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdPlan_Sheet1.Columns.Get(0).Label = "Mat ID";
            this.spdPlan_Sheet1.Columns.Get(0).Locked = true;
            this.spdPlan_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdPlan_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Top;
            this.spdPlan_Sheet1.Columns.Get(0).Width = 106F;
            this.spdPlan_Sheet1.Columns.Get(1).Label = "Mat Ver";
            this.spdPlan_Sheet1.Columns.Get(1).Locked = true;
            this.spdPlan_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdPlan_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPlan_Sheet1.Columns.Get(1).Width = 106F;
            this.spdPlan_Sheet1.FrozenColumnCount = 2;
            this.spdPlan_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdPlan_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdPlan_Sheet1.RowHeader.Columns.Get(0).Width = 50F;
            this.spdPlan_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPlan_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdPlan_Sheet1.Rows.Get(0).Height = 18F;
            this.spdPlan_Sheet1.Rows.Get(1).Height = 18F;
            this.spdPlan_Sheet1.Rows.Get(2).Height = 18F;
            this.spdPlan_Sheet1.Rows.Get(3).Height = 18F;
            this.spdPlan_Sheet1.Rows.Get(4).Height = 18F;
            this.spdPlan_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPlan_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdPlan_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdPlan_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(475, 16);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(257, 20);
            this.pnlPeriod.TabIndex = 25;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(56, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(90, 20);
            this.dtpFrom.TabIndex = 2;
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.Location = new System.Drawing.Point(0, 3);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(43, 13);
            this.lblPeriod.TabIndex = 26;
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
            this.dtpTo.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(149, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(14, 13);
            this.lblTo.TabIndex = 28;
            this.lblTo.Text = "~";
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMaterial.DisplaySubItemIndex = 0;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(12, 16);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(308, 20);
            this.cdvMaterial.TabIndex = 1;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 108;
            this.cdvMaterial.WidthMaterialAndVersion = 200;
            this.cdvMaterial.WidthVersion = 50;
            // 
            // frmORDViewProductionPlan
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmORDViewProductionPlan";
            this.Text = "View Production Plan";
            this.Activated += new System.EventHandler(this.frmORDViewProductionPlan_Activated);
            this.Load += new System.EventHandler(this.frmORDViewProductionPlan_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdPlan_Sheet1)).EndInit();
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        #endregion
        
        #region " Function Definition "
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName)
        {

            switch (MPCF.Trim(FuncName))
            {
                case "VIEW":
                    
                    if (dtpFrom.Value > dtpTo.Value)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(120));
                        dtpFrom.Value = DateTime.Today.AddMonths(- 1);
                        return false;
                    }
                    break;
                    
            }
            
            return true;
            
        }
        
        private string MakeDate(string sWorkDate)
        {
            return sWorkDate.Substring(0, 4) + "/" + sWorkDate.Substring(4, 2) + "/" + sWorkDate.Substring(6, 2);
        }
        
        private void MakeDateCell()
        {
            int icol;
            DateTime dt;
            string sDate;
            
            dt = dtpFrom.Value;
            while (dt <= dtpTo.Value)
            {
                FarPoint.Win.Spread.SheetView with_1 = spdPlan.Sheets[0];
                sDate =  dt.Year.ToString("0000");
                sDate = sDate + "/" + dt.Month.ToString("00");
                sDate = sDate + "/" + dt.Day.ToString("00");
                
                icol = with_1.ColumnCount;
                with_1.ColumnCount++;
                with_1.ColumnHeader.Cells[0, icol].Text = sDate;
                with_1.Columns[icol].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                with_1.Columns[icol].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                with_1.Columns[icol].Width = 75;
                with_1.Columns[icol].Locked = true;
                
                dt = dt.AddDays(1);
            }
            
        }
        
        private int FindCol(string sStr)
        {
            int i;
            FarPoint.Win.Spread.SheetView with_1 = spdPlan.Sheets[0];
            
            for (i = 1; i <= with_1.ColumnCount - 1; i++)
            {
                if (with_1.ColumnHeader.Cells[0, i].Text.ToUpper() == sStr.ToUpper())
                {
                    return i;
                }
            }
            
            return - 1;
        }
        
        private int FindRow(string sStr1, string sStr2)
        {
            int i;
            string sMatID;
            string sMatVer;
            
            FarPoint.Win.Spread.SheetView with_1 = spdPlan.Sheets[0];
            for (i = 0; i <= with_1.RowCount - 1; i++)
            {
                sMatID = with_1.Cells[i, 0].Text.ToUpper();
                sMatVer = with_1.Cells[i, 1].Text.ToUpper();
                if (sMatID.Substring(0, sMatID.Length - 2) == sStr1.ToUpper() && sMatVer.Substring(0, sMatVer.Length - 2) == sStr2.ToUpper())
                {
                    return i;
                }
            }
            
            return - 1;
        }
        
        private void RemoveMatChar()
        {
            int i;
            string sMat;
            
            for (i = 0; i <= spdPlan.Sheets[0].RowCount - 1; i++)
            {
                sMat = MPCF.Trim(spdPlan.Sheets[0].Cells[i, 0].Value);
                sMat = sMat.Substring(0, sMat.Length - 2);
                spdPlan.Sheets[0].Cells[i, 0].Value = sMat;
            }
        }
        
        private void CalTotalQty()
        {
            int i;
            int j;
            int iLastCol;
            int iLastRow;
            double dTotQty;
            
            FarPoint.Win.Spread.SheetView with_1 = spdPlan.Sheets[0];
            
            if (with_1.RowCount <= 0)
            {
                return;
            }
            
            iLastCol = with_1.ColumnCount;
            with_1.ColumnCount++;
            with_1.ColumnHeader.Cells[0, iLastCol].Text = "TOTAL";
            with_1.Columns[iLastCol].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            with_1.Columns[iLastCol].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            with_1.Columns[iLastCol].Locked = true;
            with_1.Columns[iLastCol].BackColor = Color.LightGoldenrodYellow;
            
            for (i = 0; i <= with_1.RowCount - 1; i++)
            {
                dTotQty = 0;
                for (j = 1; j <= with_1.ColumnCount - 2; j++)
                {
                    dTotQty += MPCF.ToDbl(with_1.Cells[i, j].Value);
                }
                with_1.Cells[i, iLastCol].Value = MPCF.Format("####,##0.###", dTotQty);
            }
            
            iLastRow = with_1.RowCount;
            with_1.RowCount += 2;
            with_1.RowHeader.Cells[iLastRow, 0].RowSpan = 2;
            with_1.RowHeader.Cells[iLastRow, 0].Text = "TOTAL";
            with_1.Cells[iLastRow, 0].Value = "Plan Qty";
            with_1.Cells[iLastRow + 1, 0].Value = "Create Qty";
            with_1.Rows[iLastRow].BackColor = Color.Gainsboro;
            with_1.Rows[iLastRow + 1].BackColor = Color.Gainsboro;
            with_1.Rows[iLastRow].Height = 17;
            with_1.Rows[iLastRow + 1].Height = 17;
            
            j = 1;
            for (i = 0; i <= with_1.RowCount - 3; i += 2)
            {
                with_1.RowHeader.Cells[i, 0].Value = j;
                with_1.Cells[i, 0].RowSpan = 2;
                j++;
            }
            
            for (i = 1; i <= with_1.ColumnCount - 1; i++)
            {
                dTotQty = 0;
                for (j = 0; j <= with_1.RowCount - 3; j += 2)
                {
                    dTotQty += MPCF.ToDbl(with_1.Cells[j, i].Value);
                }
                with_1.Cells[iLastRow, i].Value = MPCF.Format("####,##0.###", dTotQty);
                
                dTotQty = 0;
                for (j = 1; j <= with_1.RowCount - 3; j += 2)
                {
                    dTotQty += MPCF.ToDbl(with_1.Cells[j, i].Value);
                }
                with_1.Cells[iLastRow + 1, i].Value = MPCF.Format("####,##0.###", dTotQty);
            }
            
            for (i = 0; i <= with_1.ColumnCount - 1; i++)
            {
                for (j = 0; j <= with_1.RowCount - 1; j++)
                {
                    if (j % 2 == 0)
                    {
                        with_1.Cells[j, i, j, i].Border = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
                    }
                    else
                    {
                        with_1.Cells[j, i, j, i].Border = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
                    }
                }
            }
            with_1.Cells[with_1.RowCount - 1, 0, with_1.RowCount - 1, with_1.ColumnCount - 1].Border = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine));
            
        }
        
        // View_Plan_List_Detail()
        //       - View all Flow List
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal control As Control                    : Listê°€ ?¤ì–´ê°?control
        //        - ByVal c_step As String                        : ?•ìž¥ Process Step
        //        - Optional ByVal sFilter As String = ""        : sFilterë¡??œìž‘?˜ëŠ” Flow
        //        - Optional ByVal sOper As String = ""        : sOperë¥?ê°€ì§?Flow
        //        - Optional ByVal sMaterial As String = ""    : sMaterialë¥?ê°€ì§?Flow
        //        - Optional ByVal sTreeItem As String = ""    : TreeView ?ì„œ ì¶”ê???Node??Text
        //        - Optional ByVal sExt_Factory As String = "" : ?„ìž¬ Factoryê°€ ?„ë‹Œê²½ìš°???€??Factory
        //
        private bool View_Plan_List_Detail()
        {
            
            int i;
            int iRow;
            int iCol;
            FarPoint.Win.Spread.SheetView sheet;
            
            TRSNode in_node = new TRSNode("View_PlannedLot_List_Detail_In");
            TRSNode out_node = new TRSNode("View_PlannedLot_List_Detail_Out");
            TRSNode plan_list;

            try
            {
                MPCR.SetInMsg(in_node);

                if (cdvMaterial.Text == "")
                {
                    // ê¸°ê°„?¼ë¡œë§?ê²€?‰í•˜??ê²½ìš°
                    in_node.ProcStep = '2';
                }
                else
                {
                    // Material ì¡°ê±´?¼ë¡œ ê²€?‰í•˜??ê²½ìš°
                    in_node.ProcStep = '1';
                }

                in_node.AddString("FROM_DATE", MPCF.FromDate(dtpFrom));
                in_node.AddString("TO_DATE", MPCF.ToDate(dtpTo));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                in_node.AddInt("MAT_VER", cdvMaterial.Version);
                in_node.AddString("MAT_TYPE", "");
                in_node.AddString("MAT_GRP", "");

                MPCF.ClearList(spdPlan, true);
                spdPlan.Sheets[0].ColumnCount = 2;
                MakeDateCell();

                sheet = spdPlan.ActiveSheet;

                do
                {
                    if (MPCR.CallService("ORD", "ORD_View_Plan_List_Detail", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        plan_list = out_node.GetList(0)[i];

                        iRow = FindRow(MPCF.Trim(plan_list.GetString("MAT_ID")), MPCF.Trim(plan_list.GetInt("MAT_VER")));
                        if (iRow == -1)
                        {
                            iRow = sheet.RowCount;
                            sheet.RowCount = sheet.RowCount + 2;
                            sheet.RowHeader.Cells[iRow, 0].RowSpan = 2;
                            sheet.Cells[iRow, 0].Value = MPCF.Trim(plan_list.GetString("MAT_ID")) + "^1";
                            sheet.Cells[iRow + 1, 0].Value = MPCF.Trim(plan_list.GetString("MAT_ID")) + "^2";
                            sheet.Rows[iRow].Height = 15;
                            sheet.Rows[iRow + 1].Height = 15;
                        }
                        iCol = FindCol(MakeDate(plan_list.GetString("WORK_DATE")));

                        sheet.Cells[iRow, iCol].Value = MPCF.Format("####,##0.###", plan_list.GetDouble("PLAN_QTY"));
                        sheet.Cells[iRow + 1, iCol].Value = MPCF.Format("####,##0.###", plan_list.GetDouble("CREATE_LOT_QTY"));

                        if (plan_list.GetDouble("CREATE_LOT_QTY") > plan_list.GetDouble("PLAN_QTY"))
                        {
                            sheet.Cells[iRow + 1, iCol].ForeColor = Color.Blue;
                        }
                        else if (plan_list.GetDouble("CREATE_LOT_QTY") < plan_list.GetDouble("PLAN_QTY"))
                        {
                            sheet.Cells[iRow + 1, iCol].ForeColor = Color.Red;
                        }
                    }

                    in_node.SetString("FROM_DATE", out_node.GetString("NEXT_FROM_DATE"));
                    in_node.SetString("MAT_ID", out_node.GetString("NEXT_MAT_ID"));
                    in_node.SetInt("MAT_VER", out_node.GetInt("NEXT_MAT_VER"));

                } while (in_node.GetString("FROM_DATE") != "" || in_node.GetString("MAT_ID") != "");

                sheet.SortRows(0, true, false);
                RemoveMatChar();
                CalTotalQty();

                MPCF.FitColumnHeader(spdPlan);

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
                return this.cdvMaterial;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmORDViewProductionPlan_Load(object sender, System.EventArgs e)
        {
            
        }
        
        private void frmORDViewProductionPlan_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                
                MPCF.FieldClear(this);
                MPCF.ClearList(spdPlan, true);
                MPCF.FitColumnHeader(spdPlan);
                
                dtpFrom.Value = DateTime.Today.AddDays(- 7);
                dtpTo.Value = DateTime.Today;
                
                b_load_flag = true;
            }
            
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("VIEW") == false)
            {
                return;
            }
            View_Plan_List_Detail();
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Material : " + MPCF.Trim(cdvMaterial.Text) + "\r";
            sCond = sCond + "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));
            MPCF.ExportToExcel(spdPlan, this.Text, sCond);
            
        }
        
        //private void cdvMaterial_MaterialButtonPress(object sender, System.EventArgs e)
        //{
        //    cdvMaterial.Init();
        //    MPCF.InitListView(cdvMaterial.MaterialGetListView);
        //    cdvMaterial.MaterialColumns.Add("Material", 50, HorizontalAlignment.Left);
        //    cdvMaterial.MaterialColumns.Add("Desc", 100, HorizontalAlignment.Left);
        //    cdvMaterial.SelectedSubItemIndex = 0;
        //    WIPLIST.ViewMaterialList(cdvMaterial.MaterialGetListView, '1');
        //}
    }
    //#End If
}
