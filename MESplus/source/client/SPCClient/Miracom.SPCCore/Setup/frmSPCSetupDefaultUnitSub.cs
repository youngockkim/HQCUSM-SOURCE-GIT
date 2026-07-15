
using Miracom.CliFrx;
using System.Data;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Diagnostics;
using Miracom.MsgHandler;
using Miracom.Stat;
using Miracom.MESCore;
using Miracom.UI.Controls;
using FarPoint.Win.Spread;
using Miracom.TRSCore;
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmSPCSetupDefaultUnitSub.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -  CheckCondition() : Check the conditions before transaction
//       -  ViewDefaultList() : View Default Unit List
//       -  UpdateDefaultList() : View Default Unit List
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-22 : Created by W.Y. Choi
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


namespace Miracom.SPCCore
{
    public class frmSPCSetupDefaultUnitSub : System.Windows.Forms.Form
    {
        
        
        #region " Windows Form auto generated code "
        
        public frmSPCSetupDefaultUnitSub()
        {
            
            
            InitializeComponent();
            
            
            
        }
        
        public frmSPCSetupDefaultUnitSub(string sChartID, int iUnitCount, string sUnitTable)
        {
            
            
            InitializeComponent();
            
            
            
            txtChart.Text = MPCF.Trim(sChartID);
            giUnitCount = iUnitCount;
            gsUnitTable = MPCF.Trim(sUnitTable);
            
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
        



        internal System.Windows.Forms.Panel pnlBotton;
        protected System.Windows.Forms.Button btnOk;
        protected System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Panel pnlFill;
        internal System.Windows.Forms.Panel pnlMainTop;
        internal System.Windows.Forms.GroupBox grpTop;
        internal System.Windows.Forms.Label lblColSet;
        internal System.Windows.Forms.Panel pnlMainFill;
        internal System.Windows.Forms.GroupBox grpUnit;
        internal FarPoint.Win.Spread.FpSpread spdUnit;
        internal FarPoint.Win.Spread.SheetView spdUnit_Sheet1;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtChart;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.pnlBotton = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlFill = new System.Windows.Forms.Panel();
            this.pnlMainFill = new System.Windows.Forms.Panel();
            this.grpUnit = new System.Windows.Forms.GroupBox();
            this.spdUnit = new FarPoint.Win.Spread.FpSpread();
            this.spdUnit_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlMainTop = new System.Windows.Forms.Panel();
            this.grpTop = new System.Windows.Forms.GroupBox();
            this.txtChart = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblColSet = new System.Windows.Forms.Label();
            this.pnlBotton.SuspendLayout();
            this.pnlFill.SuspendLayout();
            this.pnlMainFill.SuspendLayout();
            this.grpUnit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit_Sheet1)).BeginInit();
            this.pnlMainTop.SuspendLayout();
            this.grpTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtChart)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotton
            // 
            this.pnlBotton.Controls.Add(this.btnOk);
            this.pnlBotton.Controls.Add(this.btnClose);
            this.pnlBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotton.Location = new System.Drawing.Point(0, 268);
            this.pnlBotton.Name = "pnlBotton";
            this.pnlBotton.Size = new System.Drawing.Size(426, 40);
            this.pnlBotton.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOk.Location = new System.Drawing.Point(238, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(88, 26);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(330, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Cancel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.pnlMainFill);
            this.pnlFill.Controls.Add(this.pnlMainTop);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 0);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFill.Size = new System.Drawing.Size(426, 268);
            this.pnlFill.TabIndex = 0;
            // 
            // pnlMainFill
            // 
            this.pnlMainFill.Controls.Add(this.grpUnit);
            this.pnlMainFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainFill.Location = new System.Drawing.Point(5, 50);
            this.pnlMainFill.Name = "pnlMainFill";
            this.pnlMainFill.Size = new System.Drawing.Size(416, 213);
            this.pnlMainFill.TabIndex = 7;
            // 
            // grpUnit
            // 
            this.grpUnit.Controls.Add(this.spdUnit);
            this.grpUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUnit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpUnit.Location = new System.Drawing.Point(0, 0);
            this.grpUnit.Name = "grpUnit";
            this.grpUnit.Size = new System.Drawing.Size(416, 213);
            this.grpUnit.TabIndex = 0;
            this.grpUnit.TabStop = false;
            // 
            // spdUnit
            // 
            this.spdUnit.AccessibleDescription = "spdUnit, Sheet1, Row 0, Column 0, ";
            this.spdUnit.BackColor = System.Drawing.SystemColors.Control;
            this.spdUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdUnit.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdUnit.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdUnit.HorizontalScrollBar.Name = "";
            this.spdUnit.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdUnit.HorizontalScrollBar.TabIndex = 2;
            this.spdUnit.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdUnit.Location = new System.Drawing.Point(3, 16);
            this.spdUnit.Name = "spdUnit";
            this.spdUnit.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdUnit.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdUnit.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdUnit_Sheet1});
            this.spdUnit.Size = new System.Drawing.Size(410, 194);
            this.spdUnit.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdUnit.TabIndex = 3;
            this.spdUnit.TabStop = false;
            this.spdUnit.TextTipDelay = 200;
            this.spdUnit.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdUnit.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdUnit.VerticalScrollBar.Name = "";
            this.spdUnit.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdUnit.VerticalScrollBar.TabIndex = 3;
            this.spdUnit.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // spdUnit_Sheet1
            // 
            this.spdUnit_Sheet1.Reset();
            this.spdUnit_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdUnit_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spdUnit_Sheet1.ColumnCount = 4;
            this.spdUnit_Sheet1.RowCount = 5;
            this.spdUnit_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdUnit_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Nullable";
            this.spdUnit_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Unit Definition";
            this.spdUnit_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdUnit_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdUnit_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdUnit_Sheet1.Columns.Get(0).Border = bevelBorder1;
            this.spdUnit_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdUnit_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdUnit_Sheet1.Columns.Get(0).Locked = true;
            this.spdUnit_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdUnit_Sheet1.Columns.Get(0).Width = 44F;
            this.spdUnit_Sheet1.Columns.Get(1).CellType = checkBoxCellType1;
            this.spdUnit_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdUnit_Sheet1.Columns.Get(1).Label = "Nullable";
            this.spdUnit_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdUnit_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdUnit_Sheet1.Columns.Get(2).Label = "Unit Definition";
            this.spdUnit_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdUnit_Sheet1.Columns.Get(2).Width = 250F;
            this.spdUnit_Sheet1.Columns.Get(3).Visible = false;
            this.spdUnit_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdUnit_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdUnit_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdUnit_Sheet1.RowHeader.Visible = false;
            this.spdUnit_Sheet1.Rows.Default.Height = 18F;
            this.spdUnit_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdUnit_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdUnit_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlMainTop
            // 
            this.pnlMainTop.Controls.Add(this.grpTop);
            this.pnlMainTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainTop.Location = new System.Drawing.Point(5, 5);
            this.pnlMainTop.Name = "pnlMainTop";
            this.pnlMainTop.Size = new System.Drawing.Size(416, 45);
            this.pnlMainTop.TabIndex = 6;
            // 
            // grpTop
            // 
            this.grpTop.Controls.Add(this.txtChart);
            this.grpTop.Controls.Add(this.lblColSet);
            this.grpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTop.Location = new System.Drawing.Point(0, 0);
            this.grpTop.Name = "grpTop";
            this.grpTop.Size = new System.Drawing.Size(416, 45);
            this.grpTop.TabIndex = 0;
            this.grpTop.TabStop = false;
            // 
            // txtChart
            // 
            this.txtChart.Location = new System.Drawing.Point(120, 16);
            this.txtChart.MaxLength = 50;
            this.txtChart.Name = "txtChart";
            this.txtChart.ReadOnly = true;
            this.txtChart.Size = new System.Drawing.Size(200, 20);
            this.txtChart.TabIndex = 1;
            this.txtChart.TabStop = false;
            // 
            // lblColSet
            // 
            this.lblColSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblColSet.Location = new System.Drawing.Point(15, 19);
            this.lblColSet.Name = "lblColSet";
            this.lblColSet.Size = new System.Drawing.Size(100, 14);
            this.lblColSet.TabIndex = 0;
            this.lblColSet.Text = "Chart ID";
            // 
            // frmSPCSetupDefaultUnitSub
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(426, 308);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBotton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSPCSetupDefaultUnitSub";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Default Unit Setup";
            this.Load += new System.EventHandler(this.frmSPCSetupDefaultUnitSub_Load);
            this.pnlBotton.ResumeLayout(false);
            this.pnlFill.ResumeLayout(false);
            this.pnlMainFill.ResumeLayout(false);
            this.grpUnit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit_Sheet1)).EndInit();
            this.pnlMainTop.ResumeLayout(false);
            this.grpTop.ResumeLayout(false);
            this.grpTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtChart)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition"
        
        private const int SEQ_COL = 0;
        private const int NULL_COL = 1;
        private const int UNIT_COL = 2;
        
        private int giUnitCount = - 1;
        private string gsUnitTable = "";
        
        #endregion
        
        #region "Function Difinition"
        
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool CheckCondition()
        {
            
            int i;
            
            try
            {
                if (txtChart.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    txtChart.Focus();
                    return false;
                }
                
                for (i = 0; i <= spdUnit.Sheets[0].RowCount - 1; i++)
                {
                    if (spdUnit.Sheets[0].Cells[i, NULL_COL].Value == null || 
                        Convert.ToBoolean(spdUnit.Sheets[0].Cells[i, NULL_COL].Value) == false)
                    {
                        if (MPCF.Trim(spdUnit.Sheets[0].Cells[i, UNIT_COL].Value) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            spdUnit.Sheets[0].SetActiveCell(i, UNIT_COL);
                            return false;
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
        // ViewDefaultList()
        //       - View Default Unit List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool ViewDefaultList()
        {
            
            int j;
            int LastRow = 0;

            TRSNode in_node = new TRSNode("View_Default_Unit_List_In");
            TRSNode out_node = new TRSNode("View_Default_Unit_List_Out");
            ArrayList a_list = new ArrayList();
            
            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", txtChart.Text);
                
                MPCF.ClearList(spdUnit, true);

                if (MPCR.CallService("SPC", "SPC_View_Default_Unit_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;
                    if (out_node.GetList(0).Count> 0)
                    {
                        if (giUnitCount >= out_node.GetList(0).Count)
                        {
                            for (j = 0; j <= giUnitCount - 1; j++)
                            {
                                if (j <= out_node.GetList(0).Count- 1)
                                {
                                    FarPoint.Win.Spread.SheetView with_1 = spdUnit.Sheets[0];
                                    spdUnit.Sheets[0].RowCount++;
                                    with_1.SetValue(LastRow, SEQ_COL, j + 1);
                                    if (MPCF.Trim(out_node.GetList(0)[j].GetString("DEF_UNIT_ID")) == "")
                                    {
                                        with_1.SetValue(LastRow, NULL_COL, true);
                                    }
                                    else
                                    {
                                        with_1.SetValue(LastRow, NULL_COL, false);
                                    }
                                    with_1.SetValue(LastRow, UNIT_COL, MPCF.Trim(out_node.GetList(0)[j].GetString("DEF_UNIT_ID")));
                                    if (gsUnitTable != "")
                                    {
                                        BASLIST.ViewGCMDataList(spdUnit, '1', gsUnitTable, -1, null, "", false, UNIT_COL, LastRow, null);
                                    }
                                    LastRow++;
                                }
                                else
                                {
                                    FarPoint.Win.Spread.SheetView with_2 = spdUnit.Sheets[0];
                                    spdUnit.Sheets[0].RowCount++;
                                    with_2.SetValue(LastRow, SEQ_COL, j + 1);
                                    if (gsUnitTable != "")
                                    {
                                        BASLIST.ViewGCMDataList(spdUnit, '1', gsUnitTable, -1, null, "", false, UNIT_COL, LastRow, null);
                                    }
                                    LastRow++;
                                }
                            }

                        }
                        else if (giUnitCount < out_node.GetList(0).Count)
                        {
                            for (j = 0; j <= giUnitCount - 1; j++)
                            {
                                if (j <= out_node.GetList(0).Count- 1)
                                {
                                    FarPoint.Win.Spread.SheetView with_3 = spdUnit.Sheets[0];
                                    spdUnit.Sheets[0].RowCount++;
                                    with_3.SetValue(LastRow, SEQ_COL, j + 1);
                                    if (MPCF.Trim(out_node.GetList(0)[j].GetString("DEF_UNIT_ID")) == "")
                                    {
                                        with_3.SetValue(LastRow, NULL_COL, true);
                                    }
                                    else
                                    {
                                        with_3.SetValue(LastRow, NULL_COL, false);
                                    }
                                    with_3.SetValue(LastRow, UNIT_COL, MPCF.Trim(out_node.GetList(0)[j].GetString("DEF_UNIT_ID")));
                                    if (gsUnitTable != "")
                                    {
                                        BASLIST.ViewGCMDataList(spdUnit, '1', gsUnitTable, -1, null, "", false, UNIT_COL, LastRow, null);
                                    }
                                    LastRow++;
                                }
                            }
                        }


                    }
                    else if (out_node.GetList(0).Count== 0)
                    {
                        for (j = 0; j <= giUnitCount - 1; j++)
                        {
                            FarPoint.Win.Spread.SheetView with_4 = spdUnit.Sheets[0];
                            spdUnit.Sheets[0].RowCount++;
                            with_4.SetValue(LastRow, SEQ_COL, j + 1);
                            if (gsUnitTable != "")
                            {
                                BASLIST.ViewGCMDataList(spdUnit, '1', gsUnitTable, -1, null, "", false, UNIT_COL, LastRow, null);
                            }
                            LastRow++;
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
        
        // UpdateDefaultList()
        //       - View Default Unit List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool UpdateDefaultList(char c_step)
        {
            
            
            int i = 0;
            int iIndex = 0;
            TRSNode in_node = new TRSNode("Update_Default_Unit_List_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            
            try
            {

                MPCR.SetInMsg(in_node);
                in_node.AddString("CHART_ID", txtChart.Text);
                in_node.AddString("UNIT_TBL", gsUnitTable);

                iIndex = 0;
                for (i = 0; i <= spdUnit.Sheets[0].RowCount - 1; i++)
                {
                    TRSNode list = in_node.AddNode("UNIT_LIST");
                    list.AddInt("UNIT_SEQ_NUM", MPCF.ToInt(spdUnit.Sheets[0].GetValue(i, SEQ_COL)));
                    list.AddString("DEF_UNIT_ID", MPCF.Trim(spdUnit.Sheets[0].GetValue(i, UNIT_COL)));
                    iIndex++;
                    
                }
                if (MPCR.CallService("SPC", "SPC_Update_Default_Unit_List", in_node, ref out_node) == false)
                {
                    return false;
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
        
        #endregion
        
        #region " Form Control Event Routine "
        
        private void btnOk_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition() == false)
                {
                    return;
                }
                if (UpdateDefaultList(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupDefaultUnitSub.btnOk_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                //this.Dispose(false);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupDefaultUnitSub.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCSetupDefaultUnitSub_Load(object sender, System.EventArgs e)
        {
            try
            {

                MPGV.gIBaseFormEvent.Form_Load(this, e);
                
                if (ViewDefaultList() == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupDefaultUnitSub.frmSPCSetupDefaultUnitSub_Load()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
    }
    
}
