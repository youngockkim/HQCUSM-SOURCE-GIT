
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI.Controls;
using FarPoint.Win.Spread;
using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmEDCSetupDefaultUnitSub.vb
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


namespace Miracom.EDCCore
{
    public class frmEDCSetupDefaultUnitSub : System.Windows.Forms.Form
    {

#if _EDC
        
#region " Windows Form auto generated code "
        
        public frmEDCSetupDefaultUnitSub()
        {
            
            
            InitializeComponent();
            
            
            
        }
        
        public frmEDCSetupDefaultUnitSub(string sColset, string sVersion, frmEDCSetupAttachCharacter.Unit_Def[] UnitDef, bool ButtonCheck)
        {
            
            
            InitializeComponent();
            
            
            
            Unit = UnitDef;
            
            txtColSet.Text = sColset;
            txtVersion.Text = sVersion;
            this.btnOk.Visible = ButtonCheck;
            this.spdUnit.Sheets[0].Columns[2].Locked = ButtonCheck == false ? true : false;
            
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
        



        private System.Windows.Forms.Panel pnlBotton;
        protected System.Windows.Forms.Button btnOk;
        protected System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlFill;
        private System.Windows.Forms.Panel pnlMainTop;
        private System.Windows.Forms.GroupBox grpTop;
        private System.Windows.Forms.TextBox txtColSet;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label lblColSet;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel pnlMainFill;
        private System.Windows.Forms.GroupBox grpUnit;
        private FarPoint.Win.Spread.FpSpread spdUnit;
        private FarPoint.Win.Spread.SheetView spdUnit_Sheet1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
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
            this.txtColSet = new System.Windows.Forms.TextBox();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.lblColSet = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pnlBotton.SuspendLayout();
            this.pnlFill.SuspendLayout();
            this.pnlMainFill.SuspendLayout();
            this.grpUnit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit_Sheet1)).BeginInit();
            this.pnlMainTop.SuspendLayout();
            this.grpTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBotton
            // 
            this.pnlBotton.Controls.Add(this.btnOk);
            this.pnlBotton.Controls.Add(this.btnClose);
            this.pnlBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotton.Location = new System.Drawing.Point(0, 375);
            this.pnlBotton.Name = "pnlBotton";
            this.pnlBotton.Size = new System.Drawing.Size(572, 40);
            this.pnlBotton.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOk.Location = new System.Drawing.Point(384, 8);
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
            this.btnClose.Location = new System.Drawing.Point(476, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Cancel";
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.pnlMainFill);
            this.pnlFill.Controls.Add(this.pnlMainTop);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 0);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFill.Size = new System.Drawing.Size(572, 375);
            this.pnlFill.TabIndex = 0;
            // 
            // pnlMainFill
            // 
            this.pnlMainFill.Controls.Add(this.grpUnit);
            this.pnlMainFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainFill.Location = new System.Drawing.Point(5, 76);
            this.pnlMainFill.Name = "pnlMainFill";
            this.pnlMainFill.Size = new System.Drawing.Size(562, 294);
            this.pnlMainFill.TabIndex = 7;
            // 
            // grpUnit
            // 
            this.grpUnit.Controls.Add(this.spdUnit);
            this.grpUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUnit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpUnit.Location = new System.Drawing.Point(0, 0);
            this.grpUnit.Name = "grpUnit";
            this.grpUnit.Size = new System.Drawing.Size(562, 294);
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
            this.spdUnit.Size = new System.Drawing.Size(556, 275);
            this.spdUnit.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdUnit.TabIndex = 0;
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
            spdUnit_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdUnit_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdUnit_Sheet1.ColumnCount = 4;
            spdUnit_Sheet1.RowCount = 5;
            this.spdUnit_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdUnit_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdUnit_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Character";
            this.spdUnit_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Unit Seq";
            this.spdUnit_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Nullable";
            this.spdUnit_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Unit Definition";
            this.spdUnit_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdUnit_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdUnit_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdUnit_Sheet1.Columns.Get(0).Label = "Character";
            this.spdUnit_Sheet1.Columns.Get(0).Locked = true;
            this.spdUnit_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdUnit_Sheet1.Columns.Get(0).Width = 100F;
            this.spdUnit_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdUnit_Sheet1.Columns.Get(1).Label = "Unit Seq";
            this.spdUnit_Sheet1.Columns.Get(1).Locked = true;
            this.spdUnit_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdUnit_Sheet1.Columns.Get(1).Width = 58F;
            this.spdUnit_Sheet1.Columns.Get(2).CellType = checkBoxCellType1;
            this.spdUnit_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdUnit_Sheet1.Columns.Get(2).Label = "Nullable";
            this.spdUnit_Sheet1.Columns.Get(2).Locked = true;
            this.spdUnit_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdUnit_Sheet1.Columns.Get(2).Width = 55F;
            this.spdUnit_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdUnit_Sheet1.Columns.Get(3).Label = "Unit Definition";
            this.spdUnit_Sheet1.Columns.Get(3).Locked = true;
            this.spdUnit_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdUnit_Sheet1.Columns.Get(3).Width = 270F;
            this.spdUnit_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdUnit_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdUnit_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdUnit_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdUnit_Sheet1.Rows.Get(0).Height = 18F;
            this.spdUnit_Sheet1.Rows.Get(1).Height = 18F;
            this.spdUnit_Sheet1.Rows.Get(2).Height = 18F;
            this.spdUnit_Sheet1.Rows.Get(3).Height = 18F;
            this.spdUnit_Sheet1.Rows.Get(4).Height = 18F;
            this.spdUnit_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
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
            this.pnlMainTop.Size = new System.Drawing.Size(562, 71);
            this.pnlMainTop.TabIndex = 6;
            // 
            // grpTop
            // 
            this.grpTop.Controls.Add(this.txtColSet);
            this.grpTop.Controls.Add(this.txtVersion);
            this.grpTop.Controls.Add(this.lblColSet);
            this.grpTop.Controls.Add(this.lblVersion);
            this.grpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTop.Location = new System.Drawing.Point(0, 0);
            this.grpTop.Name = "grpTop";
            this.grpTop.Size = new System.Drawing.Size(562, 71);
            this.grpTop.TabIndex = 0;
            this.grpTop.TabStop = false;
            this.grpTop.Text = "General";
            // 
            // txtColSet
            // 
            this.txtColSet.Location = new System.Drawing.Point(120, 16);
            this.txtColSet.MaxLength = 50;
            this.txtColSet.Name = "txtColSet";
            this.txtColSet.ReadOnly = true;
            this.txtColSet.Size = new System.Drawing.Size(200, 20);
            this.txtColSet.TabIndex = 0;
            this.txtColSet.TabStop = false;
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(120, 40);
            this.txtVersion.MaxLength = 20;
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size(200, 20);
            this.txtVersion.TabIndex = 1;
            this.txtVersion.TabStop = false;
            // 
            // lblColSet
            // 
            this.lblColSet.AutoSize = true;
            this.lblColSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblColSet.Location = new System.Drawing.Point(15, 19);
            this.lblColSet.Name = "lblColSet";
            this.lblColSet.Size = new System.Drawing.Size(72, 13);
            this.lblColSet.TabIndex = 0;
            this.lblColSet.Text = "Collection Set";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblVersion.Location = new System.Drawing.Point(15, 43);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "Version";
            // 
            // frmEDCSetupDefaultUnitSub
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(572, 415);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBotton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEDCSetupDefaultUnitSub";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmEDCSetupDefaultUnitSub";
            this.Load += new System.EventHandler(this.frmEDCSetupDefaultUnitSub_Load);
            this.pnlBotton.ResumeLayout(false);
            this.pnlFill.ResumeLayout(false);
            this.pnlMainFill.ResumeLayout(false);
            this.grpUnit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdUnit_Sheet1)).EndInit();
            this.pnlMainTop.ResumeLayout(false);
            this.grpTop.ResumeLayout(false);
            this.grpTop.PerformLayout();
            this.ResumeLayout(false);

        }
        
#endregion
        
#region " Variable Definition"
        
        public frmEDCSetupAttachCharacter.Unit_Def[] Unit;

        private const int CHAR_ID_COL = 0;
        private const int SEQ_COL = 1;
        private const int NULL_COL = 2;
        private const int UNIT_COL = 3;
        
#endregion
        
#region "Function Difinition"
        
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            
            int i = 0;

            try
            {
                switch (MPCF.Trim(FuncName))
                {
                    case "UpdateDefaultList":
                    
                        if (txtColSet.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            txtColSet.Focus();
                            return false;
                        }
                        
                        if (txtVersion.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            txtVersion.Focus();
                            return false;
                        }
                        
                        for (i = 0; i <= spdUnit.Sheets[0].RowCount - 1; i++)
                        {
                            if (Convert.ToBoolean(spdUnit.Sheets[0].Cells[i, NULL_COL].Value) == false)
                            {
                                if (MPCF.Trim(spdUnit.Sheets[0].Cells[i, UNIT_COL].Value) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdUnit.Sheets[0].SetActiveCell(i, UNIT_COL);
                                    return false;
                                }
                            }
                        }
                        
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
    
    
        //
        // ViewDefaultList()
        //       - View Default Unit List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool ViewDefaultList()
        {
            TRSNode in_node = new TRSNode("VIEW_DEFAULT_UNIT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DEFAULT_UNIT_LIST_OUT");

            int i = 0;
            int j = 0;
            int LastRow = 0;
        
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("COL_SET_ID", txtColSet.Text);
                in_node.AddInt("COL_SET_VERSION", MPCF.ToInt(txtVersion.Text));

                MPCF.ClearList(spdUnit);
                FarPoint.Win.Spread.SheetView spdUnitView = spdUnit.Sheets[0];
                
                for (i = 0; i <= (Unit.Length - 1); i++)
                {
                    in_node.SetString("CHAR_ID", Unit[i].CharacterID);

                    if (MPCR.CallService("EDC", "EDC_View_Default_Unit_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    if (out_node.GetList(0).Count > 0)
                    {

                        if (Unit[i].UnitCount >= out_node.GetList(0).Count)
                        {
                            for (j = 0; j <= Unit[i].UnitCount - 1; j++)
                            {
                                if (j <= out_node.GetList(0).Count - 1)
                                {
                                    spdUnitView.RowCount++;
                                    spdUnitView.SetValue(LastRow, 0, Unit[i].CharacterID);
                                    spdUnitView.SetValue(LastRow, 1, j + 1);

                                    if (MPCF.Trim(out_node.GetList(0)[i].GetChar("NULL_FLAG")) == "Y")
                                    {
                                        spdUnitView.SetValue(LastRow, NULL_COL, true);
                                    }
                                    else
                                    {
                                        spdUnitView.SetValue(LastRow, NULL_COL, false);
                                    }
                                    
                                    spdUnitView.SetValue(LastRow, UNIT_COL, MPCF.Trim(out_node.GetList(0)[j].GetString("DEF_UNIT_ID")));
                                    
                                    if (MPCF.Trim(Unit[i].UnitTable) != "")
                                    {
                                        if (BASLIST.ViewGCMDataList(spdUnit, '1', Unit[i].UnitTable, -1, null, "", false, UNIT_COL, LastRow, null) == false)
                                        {
                                            return false;
                                        }
                                    }

                                    LastRow++;
                                }
                                else
                                {
                                    spdUnitView.RowCount++;
                                    spdUnitView.SetValue(LastRow, 0, Unit[i].CharacterID);
                                    spdUnitView.SetValue(LastRow, 1, j + 1);
                                    
                                    if (MPCF.Trim(Unit[i].UnitTable) != "")
                                    {
                                        if (BASLIST.ViewGCMDataList(spdUnit, '1', Unit[i].UnitTable, -1, null, "", false, UNIT_COL, LastRow, null) == false)
                                        {
                                            return false;
                                        }
                                    }

                                    LastRow++;
                                }
                            }
                            
                        }
                        else if (Unit[i].UnitCount < out_node.GetList(0).Count)
                        {
                            for (j = 0; j <= Unit[i].UnitCount - 1; j++)
                            {
                                if (j <= out_node.GetList(0).Count - 1)
                                {
                                    spdUnitView.RowCount++;
                                    spdUnitView.SetValue(LastRow, 0, Unit[i].CharacterID);
                                    spdUnitView.SetValue(LastRow, 1, j + 1);

                                    if (MPCF.Trim(out_node.GetList(0)[i].GetChar("NULL_FLAG")) == "Y")
                                    {
                                        spdUnitView.SetValue(LastRow, NULL_COL, true);
                                    }
                                    else
                                    {
                                        spdUnitView.SetValue(LastRow, NULL_COL, false);
                                    }
                                    
                                    spdUnitView.SetValue(LastRow, UNIT_COL, MPCF.Trim(out_node.GetList(0)[j].GetString("DEF_UNIT_ID")));
                                    
                                    if (MPCF.Trim(Unit[i].UnitTable) != "")
                                    {
                                        if (BASLIST.ViewGCMDataList(spdUnit, '1', Unit[i].UnitTable, -1, null, "", false, UNIT_COL, LastRow, null) == false)
                                        {
                                            return false;
                                        }
                                    }

                                    LastRow++;
                                }
                            }
                        }                       
                    }
                    else if (out_node.GetList(0).Count == 0)
                    {
                        for (j = 0; j <= Unit[i].UnitCount - 1; j++)
                        {
                            spdUnitView.RowCount++;
                            spdUnitView.SetValue(LastRow, 0, Unit[i].CharacterID);
                            spdUnitView.SetValue(LastRow, 1, j + 1);
                            
                            if (MPCF.Trim(Unit[i].UnitTable) != "")
                            {
                                if (BASLIST.ViewGCMDataList(spdUnit, '1', Unit[i].UnitTable, -1, null, "", false, UNIT_COL, LastRow, null) == false)
                                {
                                    return false;
                                }
                            }

                            LastRow++;
                        }
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
        
        //
        // UpdateDefaultList()
        //       - View Default Unit List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool UpdateDefaultList(char c_step)
        {
            TRSNode in_node = new TRSNode("UPDATE_DEFAULT_UNIT_LIST_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode msg_list;

            int i = 0;
            
            try
            {
                MPCR.SetInMsg(in_node);

                in_node.ProcStep = c_step;
                in_node.AddString("COL_SET_ID", txtColSet.Text);
                in_node.AddInt("COL_SET_VERSION", MPCF.ToInt(txtVersion.Text));
                in_node.AddString("UNIT_TBL", Unit[0].UnitTable);

                msg_list = in_node.AddNode("UNIT_LIST");

                for (i = 0; i <= spdUnit.Sheets[0].RowCount - 1; i++)
                {
                    msg_list.AddString("CHAR_ID", MPCF.Trim(spdUnit.Sheets[0].GetValue(i, 0)));
                    msg_list.AddInt("UNIT_SEQ_NUM", MPCF.ToInt(spdUnit.Sheets[0].GetValue(i, 1)));
                    msg_list.AddString("DEF_UNIT_ID", MPCF.Trim(spdUnit.Sheets[0].GetValue(i, UNIT_COL)));
                }

                if (MPCR.CallService("EDC", "EDC_UPDATE_DEFAULT_UNIT_LIST", in_node, ref out_node) == false)
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
            
        }
    
#endregion
    
        private void btnOk_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (CheckCondition("UpdateDefaultList", MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                if (UpdateDefaultList(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void frmEDCSetupDefaultUnitSub_Load(object sender, System.EventArgs e)
        {

            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);

                if (ViewDefaultList() == false)
                {
                    return;
                }

                //spdUnit.Sheets[0].SetColumnMerge(0, FarPoint.Win.Spread.Model.MergePolicy.Always);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

#endif // _EDC
    
    }

}
