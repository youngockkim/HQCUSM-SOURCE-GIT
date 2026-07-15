
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPSetupGradeRule.vb
//   Description : Sub Resource Setup Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - SetGroupCmfItem() : Set Group/Cmf property to control
//       - initCodeView() : initial CodeView Control
//       - CheckCondition() : Check the conditions before transaction
//       - Update_Sub_Resource() : Create/Update/Delete Sub Resource
//       - View_Grade_Rule() : Find Sub Resource and SubView Resource
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-03-21 : Created by Daniel Kim
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
    public class frmWIPSetupGradeRule : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPSetupGradeRule()
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
        



        private System.Windows.Forms.Panel pnlGeneral;
        private System.Windows.Forms.MonthCalendar MonthCalendar1;
        protected FarPoint.Win.Spread.FpSpread spdGrade;
        protected FarPoint.Win.Spread.SheetView spdGrade_Grade;
        private Miracom.MESCore.Controls.udcMFOTreeList tvMFO;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvTableList;

        [System.Diagnostics.DebuggerStepThrough]
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType3 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType2 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType4 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.pnlGeneral = new System.Windows.Forms.Panel();
            this.spdGrade = new FarPoint.Win.Spread.FpSpread();
            this.spdGrade_Grade = new FarPoint.Win.Spread.SheetView();
            this.MonthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.cdvTableList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.tvMFO = new Miracom.MESCore.Controls.udcMFOTreeList();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdGrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdGrade_Grade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExcel
            // 
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlGeneral);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.tvMFO);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.cdvTableList);
            this.pnlBottom.Controls.Add(this.MonthCalendar1);
            this.pnlBottom.TabIndex = 5;
            this.pnlBottom.Controls.SetChildIndex(this.MonthCalendar1, 0);
            this.pnlBottom.Controls.SetChildIndex(this.cdvTableList, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.pnlFind, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Resource Setup";
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.Controls.Add(this.spdGrade);
            this.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneral.Location = new System.Drawing.Point(3, 0);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlGeneral.Size = new System.Drawing.Size(500, 503);
            this.pnlGeneral.TabIndex = 1;
            // 
            // spdGrade
            // 
            this.spdGrade.AccessibleDescription = "spdGrade";
            this.spdGrade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdGrade.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdGrade.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdGrade.HorizontalScrollBar.Name = "";
            this.spdGrade.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdGrade.HorizontalScrollBar.TabIndex = 2;
            this.spdGrade.Location = new System.Drawing.Point(0, 5);
            this.spdGrade.MoveActiveOnFocus = false;
            this.spdGrade.Name = "spdGrade";
            this.spdGrade.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdGrade.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdGrade.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdGrade_Grade});
            this.spdGrade.Size = new System.Drawing.Size(500, 498);
            this.spdGrade.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdGrade.TabIndex = 2;
            this.spdGrade.TabStop = false;
            this.spdGrade.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.spdGrade.TextTipDelay = 200;
            this.spdGrade.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdGrade.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdGrade.VerticalScrollBar.Name = "";
            this.spdGrade.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdGrade.VerticalScrollBar.TabIndex = 3;
            // 
            // spdGrade_Grade
            // 
            this.spdGrade_Grade.Reset();
            spdGrade_Grade.SheetName = "Grade";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdGrade_Grade.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdGrade_Grade.ColumnCount = 12;
            spdGrade_Grade.RowCount = 1;
            this.spdGrade_Grade.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdGrade_Grade.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdGrade_Grade.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdGrade_Grade.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdGrade_Grade.ColumnHeader.Cells.Get(0, 0).Value = "Grade";
            this.spdGrade_Grade.ColumnHeader.Cells.Get(0, 1).Value = "Rule Type";
            this.spdGrade_Grade.ColumnHeader.Cells.Get(0, 2).Value = "Spec M";
            this.spdGrade_Grade.ColumnHeader.Cells.Get(0, 3).ColumnSpan = 2;
            this.spdGrade_Grade.ColumnHeader.Cells.Get(0, 3).Value = "Check Grade 1";
            this.spdGrade_Grade.ColumnHeader.Cells.Get(0, 5).Value = "Comp.";
            this.spdGrade_Grade.ColumnHeader.Cells.Get(0, 6).Value = "Value 1";
            this.spdGrade_Grade.ColumnHeader.Cells.Get(0, 7).Value = "Operator";
            this.spdGrade_Grade.ColumnHeader.Cells.Get(0, 8).ColumnSpan = 2;
            this.spdGrade_Grade.ColumnHeader.Cells.Get(0, 8).Value = "Check Grade 2";
            this.spdGrade_Grade.ColumnHeader.Cells.Get(0, 10).Value = "Comp.";
            this.spdGrade_Grade.ColumnHeader.Cells.Get(0, 11).Value = "Value 2";
            this.spdGrade_Grade.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdGrade_Grade.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdGrade_Grade.ColumnHeader.Rows.Get(0).Height = 33F;
            this.spdGrade_Grade.Columns.Get(0).Label = "Grade";
            this.spdGrade_Grade.Columns.Get(0).Locked = true;
            this.spdGrade_Grade.Columns.Get(0).Width = 41F;
            this.spdGrade_Grade.Columns.Get(1).BackColor = System.Drawing.Color.White;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType1.Items = new string[] {
        "",
        "Spec_N / Spec_M",
        "Percent(%)",
        "Number"};
            this.spdGrade_Grade.Columns.Get(1).CellType = comboBoxCellType1;
            this.spdGrade_Grade.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdGrade_Grade.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdGrade_Grade.Columns.Get(1).Label = "Rule Type";
            this.spdGrade_Grade.Columns.Get(1).Locked = true;
            this.spdGrade_Grade.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdGrade_Grade.Columns.Get(1).Width = 62F;
            numberCellType1.FixedPoint = false;
            numberCellType1.MaximumValue = 99999.99D;
            numberCellType1.MinimumValue = -99999.99D;
            this.spdGrade_Grade.Columns.Get(2).CellType = numberCellType1;
            this.spdGrade_Grade.Columns.Get(2).Label = "Spec M";
            this.spdGrade_Grade.Columns.Get(2).Locked = true;
            this.spdGrade_Grade.Columns.Get(2).Width = 40F;
            numberCellType2.DecimalPlaces = 0;
            numberCellType2.MaximumValue = 9999999D;
            numberCellType2.MinimumValue = 0D;
            this.spdGrade_Grade.Columns.Get(3).CellType = numberCellType2;
            this.spdGrade_Grade.Columns.Get(3).Label = "Check Grade 1";
            this.spdGrade_Grade.Columns.Get(3).Locked = true;
            this.spdGrade_Grade.Columns.Get(3).Width = 40F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdGrade_Grade.Columns.Get(4).CellType = buttonCellType1;
            this.spdGrade_Grade.Columns.Get(4).Width = 20F;
            comboBoxCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType2.Items = new string[] {
        "",
        ">",
        "<",
        ">=",
        "<=",
        "=",
        "!"};
            this.spdGrade_Grade.Columns.Get(5).CellType = comboBoxCellType2;
            this.spdGrade_Grade.Columns.Get(5).Label = "Comp.";
            this.spdGrade_Grade.Columns.Get(5).Locked = true;
            this.spdGrade_Grade.Columns.Get(5).Width = 40F;
            numberCellType3.MaximumValue = 99999.99D;
            numberCellType3.MinimumValue = -99999.99D;
            this.spdGrade_Grade.Columns.Get(6).CellType = numberCellType3;
            this.spdGrade_Grade.Columns.Get(6).Label = "Value 1";
            this.spdGrade_Grade.Columns.Get(6).Locked = true;
            this.spdGrade_Grade.Columns.Get(6).Width = 50F;
            comboBoxCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType3.Items = new string[] {
        "",
        "AND",
        "OR"};
            this.spdGrade_Grade.Columns.Get(7).CellType = comboBoxCellType3;
            this.spdGrade_Grade.Columns.Get(7).Label = "Operator";
            this.spdGrade_Grade.Columns.Get(7).Locked = true;
            this.spdGrade_Grade.Columns.Get(7).Width = 53F;
            numberCellType4.DecimalPlaces = 0;
            numberCellType4.MaximumValue = 9999999D;
            numberCellType4.MinimumValue = 0D;
            this.spdGrade_Grade.Columns.Get(8).CellType = numberCellType4;
            this.spdGrade_Grade.Columns.Get(8).Label = "Check Grade 2";
            this.spdGrade_Grade.Columns.Get(8).Locked = true;
            this.spdGrade_Grade.Columns.Get(8).Width = 40F;
            buttonCellType2.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType2.Text = "...";
            this.spdGrade_Grade.Columns.Get(9).CellType = buttonCellType2;
            this.spdGrade_Grade.Columns.Get(9).Width = 20F;
            comboBoxCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType4.Items = new string[] {
        "",
        ">",
        "<",
        ">=",
        "<=",
        "=",
        "!"};
            this.spdGrade_Grade.Columns.Get(10).CellType = comboBoxCellType4;
            this.spdGrade_Grade.Columns.Get(10).Label = "Comp.";
            this.spdGrade_Grade.Columns.Get(10).Locked = true;
            this.spdGrade_Grade.Columns.Get(10).Width = 40F;
            numberCellType5.MaximumValue = 100000D;
            numberCellType5.MinimumValue = -100000D;
            this.spdGrade_Grade.Columns.Get(11).CellType = numberCellType5;
            this.spdGrade_Grade.Columns.Get(11).Label = "Value 2";
            this.spdGrade_Grade.Columns.Get(11).Locked = true;
            this.spdGrade_Grade.Columns.Get(11).Width = 52F;
            this.spdGrade_Grade.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdGrade_Grade.RowHeader.Columns.Default.Resizable = true;
            this.spdGrade_Grade.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdGrade_Grade.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdGrade_Grade.RowHeader.Visible = false;
            this.spdGrade_Grade.Rows.Default.Height = 17F;
            this.spdGrade_Grade.Rows.Get(0).Height = 20F;
            this.spdGrade_Grade.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdGrade_Grade.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdGrade_Grade.SheetCornerStyle.Parent = "CornerDefault";
            this.spdGrade_Grade.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // MonthCalendar1
            // 
            this.MonthCalendar1.Location = new System.Drawing.Point(0, 0);
            this.MonthCalendar1.Name = "MonthCalendar1";
            this.MonthCalendar1.TabIndex = 5;
            // 
            // cdvTableList
            // 
            this.cdvTableList.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvTableList.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableList.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTableList.Location = new System.Drawing.Point(274, 6);
            this.cdvTableList.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableList.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableList.Name = "cdvTableList";
            this.cdvTableList.Size = new System.Drawing.Size(30, 28);
            this.cdvTableList.SmallImageList = null;
            this.cdvTableList.TabIndex = 6;
            this.cdvTableList.TabStop = false;
            this.cdvTableList.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvTableList.Visible = false;
            this.cdvTableList.VisibleColumnHeader = false;
            // 
            // tvMFO
            // 
            this.tvMFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMFO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvMFO.IncludeFlowSeqNum = true;
            this.tvMFO.ListCond_ExtFactory = "";
            this.tvMFO.ListCond_Step = '1';
            this.tvMFO.Location = new System.Drawing.Point(3, 0);
            this.tvMFO.MaterialType = "";
            this.tvMFO.Name = "tvMFO";
            this.tvMFO.Size = new System.Drawing.Size(229, 503);
            this.tvMFO.TabIndex = 0;
            this.tvMFO.VisibleLevel1MFO = true;
            this.tvMFO.VisibleLevel2FO = true;
            this.tvMFO.VisibleLevel3O = true;
            this.tvMFO.VisibleLevel4MO = false;
            this.tvMFO.VisibleLevel5MF = false;
            this.tvMFO.VisibleLevel6M = false;
            this.tvMFO.VisibleLevel7F = false;
            this.tvMFO.VisibleLevel8Factory = false;
            this.tvMFO.VisibleMaterialIncludeDeleteCheck = false;
            this.tvMFO.VisibleMaterialType = false;
            this.tvMFO.VisibleOnlySetData = false;
            this.tvMFO.VisibleViewType = true;
            this.tvMFO.LevelItemSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMFO_LevelItemSelect);
            // 
            // frmWIPSetupGradeRule
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPSetupGradeRule";
            this.Text = "Grade Rule Setup";
            this.Activated += new System.EventHandler(this.frmWIPSetupGradeRule_Activated);
            this.Load += new System.EventHandler(this.frmWIPSetupGradeRule_Load);
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
            this.pnlGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdGrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdGrade_Grade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion

        #region " Variable definition "
        bool b_load_flag;
        string sMatID;
        int iMatVer;
        string sFlow;
        string sOper;
        #endregion

        #region " Function definition "

        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName)
        {

            switch (MPCF.Trim(FuncName))
            {
                case "CREATE":

                    break;

                case "DELETE":

                    break;

            }

            return true;

        }

        //
        // View_Grade_Rule()
        //       -  View Sub Resource
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Grade_Rule()
        {
            TRSNode in_node = new TRSNode("VIEW_GRADE_RULE_IN");
            TRSNode out_node = new TRSNode("VIEW_GRADE_RULE_OUT");

            TreeNode nodeX = new TreeNode();

            try
            {
                MPCF.FieldClear(this.pnlRight);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MAT_ID", sMatID);
                in_node.AddInt("MAT_VER", iMatVer);
                in_node.AddString("FLOW", sFlow);
                in_node.AddString("OPER", sOper);

                if (sMatID == "" && sFlow == "" && sOper == "")
                {
                    return false;
                }

                if (MPCR.CallService("WIP", "WIP_View_MFO_Grade_Rule_List", in_node, ref out_node) == false)
                {
                    return false;
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
        // Update_Sub_Resource()
        //       -  Update Sub Resource
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //        - ByVal c_step As String     : ?•ìž¥Process Step
        //
        private bool Update_Sub_Resource(char c_step)
        {

            TRSNode in_node = new TRSNode("UPDATE_SUB_RESOURCE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TreeNode nodeX = new TreeNode();
            string sResID = string.Empty;
            int i;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                i = tvMFO.SelectedNode.Parent.ImageIndex;
                if (tvMFO.SelectedNode.Parent.ImageIndex == (int)SMALLICON_INDEX.IDX_SUB_EQUIP)
                {
                    if (c_step == MPGC.MP_STEP_CREATE)
                    {
                        in_node.AddString("PARENTS_SUBRES_ID", tvMFO.SelectedNode.Text.Substring(0, tvMFO.SelectedNode.Text.IndexOf(":") - 2));
                    }
                    else if (c_step == MPGC.MP_STEP_UPDATE || c_step == MPGC.MP_STEP_DELETE)
                    {
                        in_node.AddString("PARENTS_SUBRES_ID", tvMFO.SelectedNode.Parent.Text.Substring(0, tvMFO.SelectedNode.Parent.Text.IndexOf(":") - 2));
                    }
                }
                else if (tvMFO.SelectedNode.Parent.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE || tvMFO.SelectedNode.Parent.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN)
                {
                    if (tvMFO.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_SUB_EQUIP && c_step == MPGC.MP_STEP_CREATE)
                    {
                        in_node.AddString("PARENTS_SUBRES_ID", tvMFO.SelectedNode.Text.Substring(0, tvMFO.SelectedNode.Text.IndexOf(":") - 2));
                    }
                    else
                    {
                        sResID = tvMFO.SelectedNode.Parent.Text.Substring(0, tvMFO.SelectedNode.Parent.Text.IndexOf(":") - 2);
                    }
                }
                else if (tvMFO.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE || tvMFO.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN)
                {
                    sResID = tvMFO.SelectedNode.Text.Substring(0, tvMFO.SelectedNode.Text.IndexOf(":") - 2);
                }
                in_node.AddString("RES_ID", sResID);


                if (MPCR.CallService("RAS", "RAS_Update_Sub_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                //if (MPGV.gbListAutoRefresh == false)
                //{
                //    if (c_step == MPGC.MP_STEP_CREATE)
                //    {
                //        //nodeX = New TreeNode(RTrim(txtSubResource.Text) & " : " & RTrim(txtDesc.Text, (int)SMALLICON_INDEX.IDX_SUB_EQUIP, (int)SMALLICON_INDEX.IDX_SUB_EQUIP)
                //        if (!(tvMFO.SelectedNode.Parent == null))
                //        {
                //            tvMFO.SelectedNode.Nodes.Add(nodeX);
                //        }
                //        else
                //        {
                //            tvMFO.Nodes.Add(nodeX);
                //        }
                //        tvMFO.SelectedNode = nodeX;
                //        nodeX.EnsureVisible();
                //        lblDataCount.Text = tvMFO.GetNodeCount(false).ToString();
                //    }
                //    else if (c_step == MPGC.MP_STEP_UPDATE)
                //    {
                //        //tvMFO.SelectedNode.Text = RTrim(txtSubResource.Text) & " : " & RTrim(txtDesc.Text)
                //    }
                //    else if (c_step == MPGC.MP_STEP_DELETE)
                //    {
                //        //If chkDeleteRes.Checked = True Then
                //        //tvMFO.SelectedNode.ForeColor = Color.Magenta
                //        //Else
                //        //tvMFO.SelectedNode.ForeColor = Color.Magenta
                //        //End If

                //    }
                //    else if (c_step == MPGC.MP_STEP_UNDELETE)
                //    {
                //        tvMFO.SelectedNode.ForeColor = tvMFO.SelectedNode.Parent.ForeColor;
                //    }

                //}

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return true;

        }


        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.tvMFO;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmWIPSetupGradeRule_Load(object sender, System.EventArgs e)
        {

            MPCF.FieldClear(this);

        }

        private void frmWIPSetupGradeRule_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                tvMFO.SelectLevel = Miracom.MESCore.Controls.MFOSelectLevel.MFO;

                b_load_flag = true;
            }

        }

        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            string sSubResID;

            try
            {
                if (CheckCondition("CREATE") == true)
                {
                    if (tvMFO.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_FACTORY)
                    {

                    }
                    else if (tvMFO.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE || tvMFO.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN)
                    {
                        if (Update_Sub_Resource(MPGC.MP_STEP_CREATE) == false)
                        {
                            return;
                        }
                    }
                    else if (tvMFO.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_SUB_EQUIP)
                    {
                        if (Update_Sub_Resource(MPGC.MP_STEP_CREATE) == false)
                        {
                            return;
                        }
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        //btnRefresh.PerformClick()
                        if (tvMFO.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE || tvMFO.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN)
                        {
                            sSubResID = "";
                        }
                        else
                        {
                            sSubResID = tvMFO.SelectedNode.Text.Substring(0, tvMFO.SelectedNode.Text.IndexOf(":") - 2);
                        }

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
                if (btnUpdate.Text == MPCF.FindLanguage("Update", 1))
                {
                    if (CheckCondition("CREATE") == true)
                    {
                        if (Update_Sub_Resource(MPGC.MP_STEP_UPDATE) == false)
                        {
                            return;
                        }
                        if (MPGV.gbListAutoRefresh == true)
                        {

                        }
                    }
                }
                else if (btnUpdate.Text == MPCF.FindLanguage("Undelete", 1))
                {
                    if (MPCF.ShowMsgBox(MPCF.GetMessage(156), MessageBoxButtons.YesNo, 1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (Update_Sub_Resource(MPGC.MP_STEP_UNDELETE) == false)
                        {
                            return;
                        }
                        if (MPGV.gbListAutoRefresh == true)
                        {

                        }
                    }
                    else
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

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (CheckCondition("DELETE") == true)
                {
                    if (Update_Sub_Resource(MPGC.MP_STEP_CONFIRM) == true)
                    {
                        if (Update_Sub_Resource(MPGC.MP_STEP_DELETE) == true)
                        {
                            MPCF.FieldClear(this.pnlRight);
                            if (MPGV.gbListAutoRefresh == true)
                            {
                                //btnRefresh.PerformClick()
                                if (tvMFO.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_SUB_EQUIP)
                                {

                                    tvMFO.SelectedNode.Remove();
                                }
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

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.ExportToExcel(spdGrade, this.Text, "");

        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                tvMFO.RefreshSelectedList();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void tvMFO_LevelItemSelect(System.Object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (tvMFO.SelectedItem == Miracom.MESCore.Controls.TreeSelectedItem.None) return;

            sMatID = tvMFO.MatID;
            iMatVer = tvMFO.MatVersion;
            sFlow = tvMFO.Flow;
            sOper = tvMFO.Oper;

            lblDataCount.Text = MPCF.Trim(tvMFO.SelectedNode.GetNodeCount(false));

            View_Grade_Rule();
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            tvMFO.GetTreeView.SelectedNode = MPCF.FindTreeNode(tvMFO.GetTreeView.TopNode, tvMFO.GetTreeView.TopNode.FullPath + tvMFO.GetTreeView.PathSeparator + txtFind.Text);
        }

        private void cdvTableList_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            spdGrade.Sheets[0].Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
        }

        private void spdGrade_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            cdvTableList.Init();
            cdvTableList.ViewPosition = Control.MousePosition;
            MPCF.InitListView(cdvTableList.GetListView);
            cdvTableList.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
            cdvTableList.Columns.Add("Table Desc", 50, HorizontalAlignment.Left);
            BASLIST.ViewGCMTableList(cdvTableList.GetListView, '1');
            if (cdvTableList.ShowPopupList(e.Row, e.Column) == false)
            {
                return;
            }

        }

        private void spdGrade_ComboSelChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {

            if (e.Column == 1)
            {
                if (spdGrade.Sheets[0].Cells[e.Row, 2].Text == "Spec_N / Spec_M")
                {
                    spdGrade.Sheets[0].Cells[e.Row, 2].Locked = true;
                }
                else
                {
                    spdGrade.Sheets[0].Cells[e.Row, 2].Locked = false;
                }
            }

        }

    }
    
}
