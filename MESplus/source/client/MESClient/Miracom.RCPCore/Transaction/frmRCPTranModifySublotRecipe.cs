
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
using Miracom.TRSCore;


//#If _RCP = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRCPTranModifySublotRecipe.vb
//   Description : Modify Sublot Recipe
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - GetResourceIDList() :Get ResourceID List
//       - LOT.GetString("OPER") : Get Operation
//       - LOT.GetInt("LAST_HIST_SEQ") : Get Last History Seq.
//       - View_SubLot_Recipe() : Get SubLot Recipe Information
//       - Update_SubLot_Recipe() : Update  SubLot Recipe
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-06-30 : Created by HS KIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


namespace Miracom.RCPCore
{
    public class frmRCPTranModifySublotRecipe : Miracom.MESCore.TranForm11
    {
        
        #region " Windows Form auto generated code "
        
        public frmRCPTranModifySublotRecipe()
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
        



        private System.Windows.Forms.Panel pnlLotInfoMain;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.GroupBox grpResID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.Panel pnlRecipeInfo;
        private System.Windows.Forms.TabControl tbpRecipe;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.CheckBox chkModify;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvColSetID;
        private System.Windows.Forms.Label lblProcTime;
        private System.Windows.Forms.TextBox txtReticleID;
        private System.Windows.Forms.TextBox txtCoatPPID;
        private System.Windows.Forms.TextBox txtPPId;
        private System.Windows.Forms.Label lblColSetID;
        private System.Windows.Forms.Label lblReticleID;
        private System.Windows.Forms.Label lblCoatPPId;
        private System.Windows.Forms.Label lblPPId;
        private System.Windows.Forms.TabPage tbpParameter;
        private System.Windows.Forms.GroupBox grbParameter;
        private FarPoint.Win.Spread.FpSpread spdParameter;
        private FarPoint.Win.Spread.SheetView spdParameter_Sheet1;
        private System.Windows.Forms.GroupBox grpSublotInfo;
        private FarPoint.Win.Spread.FpSpread spdSubLotInfo;
        private FarPoint.Win.Spread.SheetView spdSubLotInfo_LotInfo;
        protected System.Windows.Forms.TextBox txtSublotID;
        protected System.Windows.Forms.Label lblSublotID;
        protected System.Windows.Forms.TextBox txtSlotNo;
        protected System.Windows.Forms.Label lblSlotNo;
        protected System.Windows.Forms.TextBox txtLotID;
        protected System.Windows.Forms.Label lblLotID;
        protected System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Label lblMinute;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.NumericUpDown nudSecond;
        private System.Windows.Forms.NumericUpDown nudMinute;
        private System.Windows.Forms.NumericUpDown nudHour;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder2 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder1 = new FarPoint.Win.CompoundBorder(bevelBorder1, bevelBorder2);
            FarPoint.Win.BevelBorder bevelBorder3 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder4 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder2 = new FarPoint.Win.CompoundBorder(bevelBorder3, bevelBorder4);
            FarPoint.Win.BevelBorder bevelBorder5 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder6 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder3 = new FarPoint.Win.CompoundBorder(bevelBorder5, bevelBorder6);
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRCPTranModifySublotRecipe));
            this.pnlLotInfoMain = new System.Windows.Forms.Panel();
            this.grpSublotInfo = new System.Windows.Forms.GroupBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.spdSubLotInfo = new FarPoint.Win.Spread.FpSpread();
            this.spdSubLotInfo_LotInfo = new FarPoint.Win.Spread.SheetView();
            this.grpResID = new System.Windows.Forms.GroupBox();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.pnlRecipeInfo = new System.Windows.Forms.Panel();
            this.tbpRecipe = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.lblSecond = new System.Windows.Forms.Label();
            this.lblMinute = new System.Windows.Forms.Label();
            this.lblHour = new System.Windows.Forms.Label();
            this.nudSecond = new System.Windows.Forms.NumericUpDown();
            this.nudMinute = new System.Windows.Forms.NumericUpDown();
            this.nudHour = new System.Windows.Forms.NumericUpDown();
            this.chkModify = new System.Windows.Forms.CheckBox();
            this.cdvColSetID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblProcTime = new System.Windows.Forms.Label();
            this.txtReticleID = new System.Windows.Forms.TextBox();
            this.txtCoatPPID = new System.Windows.Forms.TextBox();
            this.txtPPId = new System.Windows.Forms.TextBox();
            this.lblColSetID = new System.Windows.Forms.Label();
            this.lblReticleID = new System.Windows.Forms.Label();
            this.lblCoatPPId = new System.Windows.Forms.Label();
            this.lblPPId = new System.Windows.Forms.Label();
            this.tbpParameter = new System.Windows.Forms.TabPage();
            this.grbParameter = new System.Windows.Forms.GroupBox();
            this.spdParameter = new FarPoint.Win.Spread.FpSpread();
            this.spdParameter_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.txtSublotID = new System.Windows.Forms.TextBox();
            this.lblSublotID = new System.Windows.Forms.Label();
            this.txtSlotNo = new System.Windows.Forms.TextBox();
            this.lblSlotNo = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlLotInfoMain.SuspendLayout();
            this.grpSublotInfo.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdSubLotInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSubLotInfo_LotInfo)).BeginInit();
            this.grpResID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.pnlRecipeInfo.SuspendLayout();
            this.tbpRecipe.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvColSetID)).BeginInit();
            this.tbpParameter.SuspendLayout();
            this.grbParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdParameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdParameter_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Controls.Add(this.pnlRecipeInfo);
            this.pnlTranCenter.Controls.Add(this.grpResID);
            this.pnlTranCenter.Controls.Add(this.pnlLotInfoMain);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.txtSublotID);
            this.grpOption.Controls.Add(this.lblSublotID);
            this.grpOption.Controls.Add(this.txtSlotNo);
            this.grpOption.Controls.Add(this.lblSlotNo);
            this.grpOption.Controls.Add(this.txtLotID);
            this.grpOption.Controls.Add(this.lblLotID);
            // 
            // btnExcel
            // 
            this.btnExcel.Enabled = false;
            this.btnExcel.Visible = false;
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Modify SubLot Recipe";
            // 
            // pnlLotInfoMain
            // 
            this.pnlLotInfoMain.Controls.Add(this.grpSublotInfo);
            this.pnlLotInfoMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLotInfoMain.Location = new System.Drawing.Point(3, 3);
            this.pnlLotInfoMain.Name = "pnlLotInfoMain";
            this.pnlLotInfoMain.Padding = new System.Windows.Forms.Padding(1);
            this.pnlLotInfoMain.Size = new System.Drawing.Size(736, 124);
            this.pnlLotInfoMain.TabIndex = 2;
            // 
            // grpSublotInfo
            // 
            this.grpSublotInfo.Controls.Add(this.Panel1);
            this.grpSublotInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSublotInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSublotInfo.Location = new System.Drawing.Point(1, 1);
            this.grpSublotInfo.Name = "grpSublotInfo";
            this.grpSublotInfo.Size = new System.Drawing.Size(734, 122);
            this.grpSublotInfo.TabIndex = 1;
            this.grpSublotInfo.TabStop = false;
            this.grpSublotInfo.Text = "Sub Lot Information";
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.spdSubLotInfo);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(3, 16);
            this.Panel1.Name = "Panel1";
            this.Panel1.Padding = new System.Windows.Forms.Padding(1);
            this.Panel1.Size = new System.Drawing.Size(728, 103);
            this.Panel1.TabIndex = 0;
            // 
            // spdSubLotInfo
            // 
            this.spdSubLotInfo.AccessibleDescription = "";
            this.spdSubLotInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdSubLotInfo.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdSubLotInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdSubLotInfo.HorizontalScrollBar.Name = "";
            this.spdSubLotInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdSubLotInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdSubLotInfo.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdSubLotInfo.Location = new System.Drawing.Point(1, 1);
            this.spdSubLotInfo.MoveActiveOnFocus = false;
            this.spdSubLotInfo.Name = "spdSubLotInfo";
            this.spdSubLotInfo.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdSubLotInfo.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdSubLotInfo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdSubLotInfo_LotInfo});
            this.spdSubLotInfo.Size = new System.Drawing.Size(726, 101);
            this.spdSubLotInfo.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdSubLotInfo.TabIndex = 1;
            this.spdSubLotInfo.TabStop = false;
            this.spdSubLotInfo.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.spdSubLotInfo.TextTipDelay = 200;
            this.spdSubLotInfo.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdSubLotInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdSubLotInfo.VerticalScrollBar.Name = "";
            this.spdSubLotInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdSubLotInfo.VerticalScrollBar.TabIndex = 3;
            // 
            // spdSubLotInfo_LotInfo
            // 
            this.spdSubLotInfo_LotInfo.Reset();
            spdSubLotInfo_LotInfo.SheetName = "LotInfo";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdSubLotInfo_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdSubLotInfo_LotInfo.ColumnCount = 6;
            spdSubLotInfo_LotInfo.RowCount = 17;
            this.spdSubLotInfo_LotInfo.Cells.Get(0, 0).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(0, 0).Value = "Sub Lot ID";
            this.spdSubLotInfo_LotInfo.Cells.Get(0, 2).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(0, 2).Value = "Slot No";
            this.spdSubLotInfo_LotInfo.Cells.Get(0, 4).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(0, 4).Value = "Carrier ID";
            this.spdSubLotInfo_LotInfo.Cells.Get(1, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdSubLotInfo_LotInfo.Cells.Get(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(1, 0).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(1, 0).Value = "Lot ID";
            this.spdSubLotInfo_LotInfo.Cells.Get(1, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(1, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(1, 2).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(1, 2).Value = "Material";
            this.spdSubLotInfo_LotInfo.Cells.Get(1, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(1, 4).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(1, 4).Value = "Flow";
            this.spdSubLotInfo_LotInfo.Cells.Get(2, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(2, 0).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(2, 0).Value = "Operation";
            this.spdSubLotInfo_LotInfo.Cells.Get(2, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(2, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(2, 2).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(2, 2).Value = "Qty 2/3";
            this.spdSubLotInfo_LotInfo.Cells.Get(2, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(2, 4).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(2, 4).Value = "Sub Lot Status";
            this.spdSubLotInfo_LotInfo.Cells.Get(3, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(3, 0).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(3, 0).Value = "Create Code";
            this.spdSubLotInfo_LotInfo.Cells.Get(3, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(3, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(3, 2).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(3, 2).Value = "Owner Code";
            this.spdSubLotInfo_LotInfo.Cells.Get(3, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(3, 4).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(3, 4).Value = "Hold Flag/Code";
            this.spdSubLotInfo_LotInfo.Cells.Get(4, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(4, 0).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(4, 0).Value = "Start Flag";
            this.spdSubLotInfo_LotInfo.Cells.Get(4, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(4, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(4, 2).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(4, 2).Value = "End Flag";
            this.spdSubLotInfo_LotInfo.Cells.Get(4, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(4, 4).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(4, 4).Value = "Rework Flag/Code";
            this.spdSubLotInfo_LotInfo.Cells.Get(5, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(5, 0).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(5, 0).Value = "Transit Flag";
            this.spdSubLotInfo_LotInfo.Cells.Get(5, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(5, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(5, 2).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(5, 2).Value = "Inventory Flag";
            this.spdSubLotInfo_LotInfo.Cells.Get(5, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(5, 4).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(5, 4).Value = "Non Standard Flag";
            this.spdSubLotInfo_LotInfo.Cells.Get(6, 0).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(6, 0).Value = "Last Tran Code";
            this.spdSubLotInfo_LotInfo.Cells.Get(6, 2).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(6, 2).Value = "Last Tran Time";
            this.spdSubLotInfo_LotInfo.Cells.Get(6, 4).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(6, 4).Value = "Last Hist Seq";
            this.spdSubLotInfo_LotInfo.Cells.Get(7, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(7, 0).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(7, 0).Value = "Grade";
            this.spdSubLotInfo_LotInfo.Cells.Get(7, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(7, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(7, 2).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(7, 2).Value = "Grade Code";
            this.spdSubLotInfo_LotInfo.Cells.Get(7, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(7, 4).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(7, 4).Value = "Cell Grade";
            this.spdSubLotInfo_LotInfo.Cells.Get(8, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(8, 0).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(8, 0).Value = "Oper In Qty 2/3";
            this.spdSubLotInfo_LotInfo.Cells.Get(8, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(8, 2).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(8, 2).Value = "Create Qty 2/3";
            this.spdSubLotInfo_LotInfo.Cells.Get(8, 4).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(8, 4).Value = "Start Time";
            this.spdSubLotInfo_LotInfo.Cells.Get(9, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(9, 0).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(9, 0).Value = "Start Res ID";
            this.spdSubLotInfo_LotInfo.Cells.Get(9, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(9, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(9, 2).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(9, 2).Value = "End Time";
            this.spdSubLotInfo_LotInfo.Cells.Get(9, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(9, 4).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(9, 4).Value = "End Res ID";
            this.spdSubLotInfo_LotInfo.Cells.Get(10, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(10, 0).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(10, 0).Value = "Rework Ret Flow";
            this.spdSubLotInfo_LotInfo.Cells.Get(10, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(10, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(10, 2).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(10, 2).Value = "Rework Ret Oper";
            this.spdSubLotInfo_LotInfo.Cells.Get(10, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(10, 4).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(10, 4).Value = "Rework Count";
            this.spdSubLotInfo_LotInfo.Cells.Get(11, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(11, 0).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(11, 0).Value = "Rework End Flow";
            this.spdSubLotInfo_LotInfo.Cells.Get(11, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(11, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(11, 2).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(11, 2).Value = "Rework End Oper";
            this.spdSubLotInfo_LotInfo.Cells.Get(11, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(11, 4).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(11, 4).Value = "Rework Time";
            this.spdSubLotInfo_LotInfo.Cells.Get(12, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(12, 0).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(12, 0).Value = "NSTD Ret Flow";
            this.spdSubLotInfo_LotInfo.Cells.Get(12, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(12, 2).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(12, 2).Value = "NSTD Ret Oper";
            this.spdSubLotInfo_LotInfo.Cells.Get(12, 4).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(12, 4).Value = "NSTD Time";
            this.spdSubLotInfo_LotInfo.Cells.Get(13, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(13, 0).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(13, 0).Value = "Repair Flag";
            this.spdSubLotInfo_LotInfo.Cells.Get(13, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(13, 2).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(13, 2).Value = "Repair Ret Oper";
            this.spdSubLotInfo_LotInfo.Cells.Get(13, 4).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(13, 4).Value = "Sub Lot Location";
            this.spdSubLotInfo_LotInfo.Cells.Get(14, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(14, 0).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(14, 0).Value = "Sample Flag";
            this.spdSubLotInfo_LotInfo.Cells.Get(14, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(14, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(14, 2).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(14, 2).Value = "Sample Wait Flag";
            this.spdSubLotInfo_LotInfo.Cells.Get(14, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(14, 4).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(14, 4).Value = "Sample Result";
            this.spdSubLotInfo_LotInfo.Cells.Get(15, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(15, 0).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(15, 0).Value = "Lot Base";
            this.spdSubLotInfo_LotInfo.Cells.Get(15, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(15, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(15, 2).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(15, 2).Value = "Reserve Res ID";
            this.spdSubLotInfo_LotInfo.Cells.Get(15, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(15, 4).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(15, 4).Value = "Sub Lot Del Flag";
            this.spdSubLotInfo_LotInfo.Cells.Get(16, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(16, 0).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(16, 0).Value = "Sub Lot Del Time";
            this.spdSubLotInfo_LotInfo.Cells.Get(16, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(16, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Cells.Get(16, 2).ParseFormatString = "G";
            this.spdSubLotInfo_LotInfo.Cells.Get(16, 2).Value = "Sub Lot Del Reason";
            this.spdSubLotInfo_LotInfo.Cells.Get(16, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSubLotInfo_LotInfo.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdSubLotInfo_LotInfo.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSubLotInfo_LotInfo.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdSubLotInfo_LotInfo.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSubLotInfo_LotInfo.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdSubLotInfo_LotInfo.ColumnHeader.Visible = false;
            this.spdSubLotInfo_LotInfo.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdSubLotInfo_LotInfo.Columns.Get(0).Border = compoundBorder1;
            this.spdSubLotInfo_LotInfo.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdSubLotInfo_LotInfo.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Columns.Get(0).Locked = true;
            this.spdSubLotInfo_LotInfo.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSubLotInfo_LotInfo.Columns.Get(0).Width = 105F;
            this.spdSubLotInfo_LotInfo.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdSubLotInfo_LotInfo.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Columns.Get(1).Locked = false;
            this.spdSubLotInfo_LotInfo.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSubLotInfo_LotInfo.Columns.Get(1).Width = 127F;
            this.spdSubLotInfo_LotInfo.Columns.Get(2).BackColor = System.Drawing.SystemColors.Control;
            this.spdSubLotInfo_LotInfo.Columns.Get(2).Border = compoundBorder2;
            this.spdSubLotInfo_LotInfo.Columns.Get(2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdSubLotInfo_LotInfo.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Columns.Get(2).Locked = true;
            this.spdSubLotInfo_LotInfo.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSubLotInfo_LotInfo.Columns.Get(2).Width = 105F;
            this.spdSubLotInfo_LotInfo.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdSubLotInfo_LotInfo.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Columns.Get(3).Locked = false;
            this.spdSubLotInfo_LotInfo.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdSubLotInfo_LotInfo.Columns.Get(3).Width = 127F;
            this.spdSubLotInfo_LotInfo.Columns.Get(4).BackColor = System.Drawing.SystemColors.Control;
            this.spdSubLotInfo_LotInfo.Columns.Get(4).Border = compoundBorder3;
            this.spdSubLotInfo_LotInfo.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Columns.Get(4).Locked = true;
            this.spdSubLotInfo_LotInfo.Columns.Get(4).Width = 105F;
            this.spdSubLotInfo_LotInfo.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdSubLotInfo_LotInfo.Columns.Get(5).Locked = false;
            this.spdSubLotInfo_LotInfo.Columns.Get(5).Width = 127F;
            this.spdSubLotInfo_LotInfo.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdSubLotInfo_LotInfo.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.spdSubLotInfo_LotInfo.RowHeader.Columns.Default.Resizable = false;
            this.spdSubLotInfo_LotInfo.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSubLotInfo_LotInfo.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdSubLotInfo_LotInfo.RowHeader.Visible = false;
            this.spdSubLotInfo_LotInfo.Rows.Get(0).Height = 17F;
            this.spdSubLotInfo_LotInfo.Rows.Get(1).Height = 17F;
            this.spdSubLotInfo_LotInfo.Rows.Get(2).Height = 17F;
            this.spdSubLotInfo_LotInfo.Rows.Get(3).Height = 17F;
            this.spdSubLotInfo_LotInfo.Rows.Get(4).Height = 17F;
            this.spdSubLotInfo_LotInfo.Rows.Get(5).Height = 17F;
            this.spdSubLotInfo_LotInfo.Rows.Get(6).Height = 17F;
            this.spdSubLotInfo_LotInfo.Rows.Get(7).Height = 17F;
            this.spdSubLotInfo_LotInfo.Rows.Get(8).Height = 17F;
            this.spdSubLotInfo_LotInfo.Rows.Get(9).Height = 17F;
            this.spdSubLotInfo_LotInfo.Rows.Get(10).Height = 17F;
            this.spdSubLotInfo_LotInfo.Rows.Get(11).Height = 17F;
            this.spdSubLotInfo_LotInfo.Rows.Get(12).Height = 17F;
            this.spdSubLotInfo_LotInfo.Rows.Get(13).Height = 17F;
            this.spdSubLotInfo_LotInfo.Rows.Get(14).Height = 17F;
            this.spdSubLotInfo_LotInfo.Rows.Get(15).Height = 17F;
            this.spdSubLotInfo_LotInfo.Rows.Get(16).Height = 17F;
            this.spdSubLotInfo_LotInfo.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSubLotInfo_LotInfo.SheetCornerStyle.Parent = "CornerDefault";
            this.spdSubLotInfo_LotInfo.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdSubLotInfo_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpResID
            // 
            this.grpResID.Controls.Add(this.cdvResID);
            this.grpResID.Controls.Add(this.lblResID);
            this.grpResID.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResID.Location = new System.Drawing.Point(3, 127);
            this.grpResID.Name = "grpResID";
            this.grpResID.Size = new System.Drawing.Size(736, 44);
            this.grpResID.TabIndex = 3;
            this.grpResID.TabStop = false;
            // 
            // cdvResID
            // 
            this.cdvResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResID.BtnToolTipText = "";
            this.cdvResID.DescText = "";
            this.cdvResID.DisplaySubItemIndex = -1;
            this.cdvResID.DisplayText = "";
            this.cdvResID.Focusing = null;
            this.cdvResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResID.Index = 0;
            this.cdvResID.IsViewBtnImage = false;
            this.cdvResID.Location = new System.Drawing.Point(125, 16);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(185, 19);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 1;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 185;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResID_SelectedItemChanged);
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            this.cdvResID.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvResID_TextBoxKeyPress);
            this.cdvResID.TextBoxTextChanged += new System.EventHandler(this.cdvResID_TextBoxTextChanged);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(12, 18);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(78, 13);
            this.lblResID.TabIndex = 0;
            this.lblResID.Text = "Resource ID";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlRecipeInfo
            // 
            this.pnlRecipeInfo.Controls.Add(this.tbpRecipe);
            this.pnlRecipeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRecipeInfo.Location = new System.Drawing.Point(3, 171);
            this.pnlRecipeInfo.Name = "pnlRecipeInfo";
            this.pnlRecipeInfo.Size = new System.Drawing.Size(736, 273);
            this.pnlRecipeInfo.TabIndex = 4;
            // 
            // tbpRecipe
            // 
            this.tbpRecipe.Controls.Add(this.tbpGeneral);
            this.tbpRecipe.Controls.Add(this.tbpParameter);
            this.tbpRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbpRecipe.Location = new System.Drawing.Point(0, 0);
            this.tbpRecipe.Name = "tbpRecipe";
            this.tbpRecipe.SelectedIndex = 0;
            this.tbpRecipe.Size = new System.Drawing.Size(736, 273);
            this.tbpRecipe.TabIndex = 1;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.grpInfo);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Size = new System.Drawing.Size(728, 247);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.lblSecond);
            this.grpInfo.Controls.Add(this.lblMinute);
            this.grpInfo.Controls.Add(this.lblHour);
            this.grpInfo.Controls.Add(this.nudSecond);
            this.grpInfo.Controls.Add(this.nudMinute);
            this.grpInfo.Controls.Add(this.nudHour);
            this.grpInfo.Controls.Add(this.chkModify);
            this.grpInfo.Controls.Add(this.cdvColSetID);
            this.grpInfo.Controls.Add(this.lblProcTime);
            this.grpInfo.Controls.Add(this.txtReticleID);
            this.grpInfo.Controls.Add(this.txtCoatPPID);
            this.grpInfo.Controls.Add(this.txtPPId);
            this.grpInfo.Controls.Add(this.lblColSetID);
            this.grpInfo.Controls.Add(this.lblReticleID);
            this.grpInfo.Controls.Add(this.lblCoatPPId);
            this.grpInfo.Controls.Add(this.lblPPId);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInfo.Location = new System.Drawing.Point(0, 0);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(728, 247);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSecond.Location = new System.Drawing.Point(311, 114);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(29, 13);
            this.lblSecond.TabIndex = 14;
            this.lblSecond.Text = "Sec.";
            // 
            // lblMinute
            // 
            this.lblMinute.AutoSize = true;
            this.lblMinute.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMinute.Location = new System.Drawing.Point(237, 114);
            this.lblMinute.Name = "lblMinute";
            this.lblMinute.Size = new System.Drawing.Size(27, 13);
            this.lblMinute.TabIndex = 12;
            this.lblMinute.Text = "Min.";
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHour.Location = new System.Drawing.Point(161, 114);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(30, 13);
            this.lblHour.TabIndex = 10;
            this.lblHour.Text = "Hour";
            // 
            // nudSecond
            // 
            this.nudSecond.Location = new System.Drawing.Point(271, 112);
            this.nudSecond.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudSecond.Name = "nudSecond";
            this.nudSecond.Size = new System.Drawing.Size(36, 20);
            this.nudSecond.TabIndex = 13;
            this.nudSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudMinute
            // 
            this.nudMinute.Location = new System.Drawing.Point(197, 112);
            this.nudMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudMinute.Name = "nudMinute";
            this.nudMinute.Size = new System.Drawing.Size(36, 20);
            this.nudMinute.TabIndex = 11;
            this.nudMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudHour
            // 
            this.nudHour.Location = new System.Drawing.Point(121, 112);
            this.nudHour.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudHour.Name = "nudHour";
            this.nudHour.Size = new System.Drawing.Size(36, 20);
            this.nudHour.TabIndex = 9;
            this.nudHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkModify
            // 
            this.chkModify.AutoSize = true;
            this.chkModify.Enabled = false;
            this.chkModify.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkModify.Location = new System.Drawing.Point(15, 142);
            this.chkModify.Name = "chkModify";
            this.chkModify.Size = new System.Drawing.Size(86, 18);
            this.chkModify.TabIndex = 15;
            this.chkModify.Text = "Modify Flag";
            this.chkModify.CheckedChanged += new System.EventHandler(this.chkModify_CheckedChanged);
            // 
            // cdvColSetID
            // 
            this.cdvColSetID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvColSetID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvColSetID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvColSetID.BtnToolTipText = "";
            this.cdvColSetID.DescText = "";
            this.cdvColSetID.DisplaySubItemIndex = -1;
            this.cdvColSetID.DisplayText = "";
            this.cdvColSetID.Focusing = null;
            this.cdvColSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvColSetID.Index = 0;
            this.cdvColSetID.IsViewBtnImage = false;
            this.cdvColSetID.Location = new System.Drawing.Point(121, 88);
            this.cdvColSetID.MaxLength = 25;
            this.cdvColSetID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvColSetID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvColSetID.Name = "cdvColSetID";
            this.cdvColSetID.ReadOnly = false;
            this.cdvColSetID.SearchSubItemIndex = 0;
            this.cdvColSetID.SelectedDescIndex = -1;
            this.cdvColSetID.SelectedSubItemIndex = -1;
            this.cdvColSetID.SelectionStart = 0;
            this.cdvColSetID.Size = new System.Drawing.Size(185, 20);
            this.cdvColSetID.SmallImageList = null;
            this.cdvColSetID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvColSetID.TabIndex = 7;
            this.cdvColSetID.TextBoxToolTipText = "";
            this.cdvColSetID.TextBoxWidth = 185;
            this.cdvColSetID.VisibleButton = true;
            this.cdvColSetID.VisibleColumnHeader = false;
            this.cdvColSetID.VisibleDescription = false;
            this.cdvColSetID.ButtonPress += new System.EventHandler(this.cdvColSetID_ButtonPress);
            // 
            // lblProcTime
            // 
            this.lblProcTime.AutoSize = true;
            this.lblProcTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblProcTime.Location = new System.Drawing.Point(15, 115);
            this.lblProcTime.Name = "lblProcTime";
            this.lblProcTime.Size = new System.Drawing.Size(55, 13);
            this.lblProcTime.TabIndex = 8;
            this.lblProcTime.Text = "Proc Time";
            // 
            // txtReticleID
            // 
            this.txtReticleID.Location = new System.Drawing.Point(121, 63);
            this.txtReticleID.MaxLength = 50;
            this.txtReticleID.Name = "txtReticleID";
            this.txtReticleID.Size = new System.Drawing.Size(185, 20);
            this.txtReticleID.TabIndex = 5;
            // 
            // txtCoatPPID
            // 
            this.txtCoatPPID.Location = new System.Drawing.Point(121, 39);
            this.txtCoatPPID.MaxLength = 25;
            this.txtCoatPPID.Name = "txtCoatPPID";
            this.txtCoatPPID.Size = new System.Drawing.Size(185, 20);
            this.txtCoatPPID.TabIndex = 3;
            // 
            // txtPPId
            // 
            this.txtPPId.Location = new System.Drawing.Point(121, 15);
            this.txtPPId.MaxLength = 25;
            this.txtPPId.Name = "txtPPId";
            this.txtPPId.Size = new System.Drawing.Size(185, 20);
            this.txtPPId.TabIndex = 1;
            // 
            // lblColSetID
            // 
            this.lblColSetID.AutoSize = true;
            this.lblColSetID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblColSetID.Location = new System.Drawing.Point(15, 91);
            this.lblColSetID.Name = "lblColSetID";
            this.lblColSetID.Size = new System.Drawing.Size(55, 13);
            this.lblColSetID.TabIndex = 6;
            this.lblColSetID.Text = "Col Set ID";
            // 
            // lblReticleID
            // 
            this.lblReticleID.AutoSize = true;
            this.lblReticleID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReticleID.Location = new System.Drawing.Point(15, 67);
            this.lblReticleID.Name = "lblReticleID";
            this.lblReticleID.Size = new System.Drawing.Size(54, 13);
            this.lblReticleID.TabIndex = 4;
            this.lblReticleID.Text = "Reticle ID";
            // 
            // lblCoatPPId
            // 
            this.lblCoatPPId.AutoSize = true;
            this.lblCoatPPId.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCoatPPId.Location = new System.Drawing.Point(15, 43);
            this.lblCoatPPId.Name = "lblCoatPPId";
            this.lblCoatPPId.Size = new System.Drawing.Size(60, 13);
            this.lblCoatPPId.TabIndex = 2;
            this.lblCoatPPId.Text = "Coat PP ID";
            // 
            // lblPPId
            // 
            this.lblPPId.AutoSize = true;
            this.lblPPId.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPPId.Location = new System.Drawing.Point(15, 19);
            this.lblPPId.Name = "lblPPId";
            this.lblPPId.Size = new System.Drawing.Size(35, 13);
            this.lblPPId.TabIndex = 0;
            this.lblPPId.Text = "PP ID";
            // 
            // tbpParameter
            // 
            this.tbpParameter.Controls.Add(this.grbParameter);
            this.tbpParameter.Location = new System.Drawing.Point(4, 22);
            this.tbpParameter.Name = "tbpParameter";
            this.tbpParameter.Size = new System.Drawing.Size(728, 247);
            this.tbpParameter.TabIndex = 1;
            this.tbpParameter.Text = "Parameter";
            this.tbpParameter.Visible = false;
            // 
            // grbParameter
            // 
            this.grbParameter.Controls.Add(this.spdParameter);
            this.grbParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbParameter.Location = new System.Drawing.Point(0, 0);
            this.grbParameter.Name = "grbParameter";
            this.grbParameter.Size = new System.Drawing.Size(728, 247);
            this.grbParameter.TabIndex = 0;
            this.grbParameter.TabStop = false;
            this.grbParameter.Text = "Parameter";
            // 
            // spdParameter
            // 
            this.spdParameter.AccessibleDescription = "";
            this.spdParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdParameter.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdParameter.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdParameter.HorizontalScrollBar.Name = "";
            this.spdParameter.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdParameter.HorizontalScrollBar.TabIndex = 2;
            this.spdParameter.Location = new System.Drawing.Point(3, 16);
            this.spdParameter.Name = "spdParameter";
            this.spdParameter.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdParameter.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdParameter.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdParameter_Sheet1});
            this.spdParameter.Size = new System.Drawing.Size(722, 228);
            this.spdParameter.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdParameter.TabIndex = 0;
            this.spdParameter.TabStop = false;
            this.spdParameter.TextTipDelay = 200;
            this.spdParameter.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdParameter.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdParameter.VerticalScrollBar.Name = "";
            this.spdParameter.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdParameter.VerticalScrollBar.TabIndex = 3;
            this.spdParameter.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.spdParameter_Change);
            this.spdParameter.SetViewportLeftColumn(0, 0, 2);
            this.spdParameter.SetActiveViewport(0, 0, -1);
            // 
            // spdParameter_Sheet1
            // 
            this.spdParameter_Sheet1.Reset();
            spdParameter_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdParameter_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdParameter_Sheet1.ColumnCount = 6;
            spdParameter_Sheet1.RowCount = 5;
            this.spdParameter_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdParameter_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdParameter_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdParameter_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdParameter_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdParameter_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdParameter_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdParameter_Sheet1.ColumnHeader.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdParameter_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Seq";
            this.spdParameter_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Parameter ID";
            this.spdParameter_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Value";
            this.spdParameter_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Description";
            this.spdParameter_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Modify Flag";
            this.spdParameter_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdParameter_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdParameter_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdParameter_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdParameter_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdParameter_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdParameter_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdParameter_Sheet1.Columns.Get(0).Width = 25F;
            this.spdParameter_Sheet1.Columns.Get(1).Label = "Seq";
            this.spdParameter_Sheet1.Columns.Get(1).Locked = true;
            this.spdParameter_Sheet1.Columns.Get(1).Width = 38F;
            this.spdParameter_Sheet1.Columns.Get(2).CellType = textCellType1;
            this.spdParameter_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdParameter_Sheet1.Columns.Get(2).Label = "Parameter ID";
            this.spdParameter_Sheet1.Columns.Get(2).Locked = true;
            this.spdParameter_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdParameter_Sheet1.Columns.Get(2).Width = 96F;
            this.spdParameter_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdParameter_Sheet1.Columns.Get(3).Label = "Value";
            this.spdParameter_Sheet1.Columns.Get(3).Locked = false;
            this.spdParameter_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdParameter_Sheet1.Columns.Get(3).Width = 100F;
            this.spdParameter_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdParameter_Sheet1.Columns.Get(4).Label = "Description";
            this.spdParameter_Sheet1.Columns.Get(4).Locked = true;
            this.spdParameter_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdParameter_Sheet1.Columns.Get(4).Width = 100F;
            this.spdParameter_Sheet1.Columns.Get(5).CellType = textCellType2;
            this.spdParameter_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdParameter_Sheet1.Columns.Get(5).Label = "Modify Flag";
            this.spdParameter_Sheet1.Columns.Get(5).Locked = true;
            this.spdParameter_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdParameter_Sheet1.Columns.Get(5).Width = 76F;
            this.spdParameter_Sheet1.FrozenColumnCount = 2;
            this.spdParameter_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdParameter_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdParameter_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdParameter_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdParameter_Sheet1.Rows.Get(0).Height = 18F;
            this.spdParameter_Sheet1.Rows.Get(1).Height = 18F;
            this.spdParameter_Sheet1.Rows.Get(2).Height = 18F;
            this.spdParameter_Sheet1.Rows.Get(3).Height = 18F;
            this.spdParameter_Sheet1.Rows.Get(4).Height = 18F;
            this.spdParameter_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdParameter_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdParameter_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdParameter_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdParameter_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // txtSublotID
            // 
            this.txtSublotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSublotID.Location = new System.Drawing.Point(126, 17);
            this.txtSublotID.MaxLength = 30;
            this.txtSublotID.Name = "txtSublotID";
            this.txtSublotID.Size = new System.Drawing.Size(185, 20);
            this.txtSublotID.TabIndex = 8;
            this.txtSublotID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSublotID_KeyPress);
            // 
            // lblSublotID
            // 
            this.lblSublotID.AutoSize = true;
            this.lblSublotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSublotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSublotID.Location = new System.Drawing.Point(14, 19);
            this.lblSublotID.Name = "lblSublotID";
            this.lblSublotID.Size = new System.Drawing.Size(68, 13);
            this.lblSublotID.TabIndex = 7;
            this.lblSublotID.Text = "Sub Lot ID";
            this.lblSublotID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSlotNo
            // 
            this.txtSlotNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSlotNo.Location = new System.Drawing.Point(566, 37);
            this.txtSlotNo.MaxLength = 6;
            this.txtSlotNo.Name = "txtSlotNo";
            this.txtSlotNo.ReadOnly = true;
            this.txtSlotNo.Size = new System.Drawing.Size(157, 20);
            this.txtSlotNo.TabIndex = 12;
            this.txtSlotNo.TabStop = false;
            // 
            // lblSlotNo
            // 
            this.lblSlotNo.AutoSize = true;
            this.lblSlotNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSlotNo.Location = new System.Drawing.Point(431, 43);
            this.lblSlotNo.Name = "lblSlotNo";
            this.lblSlotNo.Size = new System.Drawing.Size(42, 13);
            this.lblSlotNo.TabIndex = 11;
            this.lblSlotNo.Text = "Slot No";
            this.lblSlotNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLotID
            // 
            this.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLotID.Location = new System.Drawing.Point(126, 41);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.ReadOnly = true;
            this.txtLotID.Size = new System.Drawing.Size(185, 20);
            this.txtLotID.TabIndex = 10;
            this.txtLotID.TabStop = false;
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(14, 43);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(36, 13);
            this.lblLotID.TabIndex = 9;
            this.lblLotID.Text = "Lot ID";
            this.lblLotID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(10, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 2;
            // 
            // frmRCPTranModifySublotRecipe
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRCPTranModifySublotRecipe";
            this.Text = "Modify Sublot Recipe";
            this.Activated += new System.EventHandler(this.frmRCPTranModifySublotRecipe_Activated);
            this.Load += new System.EventHandler(this.frmRCPTranModifySublotRecipe_Renamed);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlLotInfoMain.ResumeLayout(false);
            this.grpSublotInfo.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdSubLotInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSubLotInfo_LotInfo)).EndInit();
            this.grpResID.ResumeLayout(false);
            this.grpResID.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.pnlRecipeInfo.ResumeLayout(false);
            this.tbpRecipe.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvColSetID)).EndInit();
            this.tbpParameter.ResumeLayout(false);
            this.grbParameter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdParameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdParameter_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        private bool bParaInsertFlag;
        private TRSNode SUBLOT = new TRSNode("");
        
        #endregion
        
        #region " Function Definition "
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1")
        //
        private void ClearData(char ProcStep)
        {

            try
            {
                switch (ProcStep)
                {
                    case '1':

                        MPCF.FieldClear(this);
                        chkModify.Checked = true;
                        break;
                    case '2':

                        MPCF.FieldClear(this, txtSublotID);
                        chkModify.Checked = true;
                        if (MPCR.SetSublotInfoSpread(spdSubLotInfo, txtSublotID.Text, ref SUBLOT) == false)
                        {
                            txtSublotID.Focus();
                            return;
                        }
                        GetResourceIDList();
                        break;
                    case '3':

                        MPCF.FieldClear(pnlRecipeInfo);
                        chkModify.Checked = true;
                        MPCF.ClearList(spdParameter, true);
                        MPCF.FitColumnHeader(spdParameter);
                        break;
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
        //
        private bool CheckCondition(string FuncName)
        {
            
            switch (MPCF.Trim(FuncName))
            {
                case "Update_Sublot_Recipe":

                    if (MPCF.CheckValue(txtSublotID, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.Trim(SUBLOT.GetString("OPER")) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                        txtLotID.Focus();
                        return false;
                    }
                    if (cdvResID.Items.Count > 0)
                    {
                        if (MPCF.CheckValue(cdvResID, 1) == false)
                        {
                            cdvResID.Focus();
                            return false;
                        }
                    }
                    break;
            }
            
            return true;
            
        }
        
        //
        // GetResourceIDList()
        //       - Get ResourceID List by Operation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool GetResourceIDList()
        {
            
            try
            {
                cdvResID.Init();
                MPCF.InitListView(cdvResID.GetListView);
                cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvResID.SelectedSubItemIndex = 0;
                #if _RAS
                if (RASLIST.ViewResourceList(cdvResID.GetListView, SUBLOT.GetString("MAT_ID"), SUBLOT.GetInt("MAT_VER"), SUBLOT.GetString("FLOW"), SUBLOT.GetString("OPER"), false) == false)
                {
                    return false;
                }
                #endif
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        //
        // View_Sublot_Recipe()
        //       - Get SubLot Recipe Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Sublot_Recipe()
        {
            
            int i;
            int iLastSeq;
            int LastRow = 0;

            TRSNode in_node = new TRSNode("VIEW_SUBLOT_RECIPE_IN");
            TRSNode out_node = new TRSNode("VIEW_SUBLOT_RECIPE_OUT");

            try
            {
                ClearData('3');

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", SUBLOT.GetString("LOT_ID"));
                in_node.AddString("SUBLOT_ID", MPCF.Trim(txtSublotID.Text));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));

                if (MPCR.CallService("RCP", "RCP_View_Sublot_Recipe", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtPPId.Text = out_node.GetString("PP_ID");
                txtCoatPPID.Text = out_node.GetString("COAT_PP_ID");
                txtReticleID.Text = out_node.GetString("RETICLE_ID");
                cdvColSetID.Text = out_node.GetString("COL_SET_ID");
                if (out_node.GetString("PROC_TIME") != "")
                {
                    nudHour.Value = MPCF.ToInt(out_node.GetString("PROC_TIME").Substring(0, 2));
                    nudMinute.Value = MPCF.ToInt(out_node.GetString("PROC_TIME").Substring(2, 2));
                    nudSecond.Value = MPCF.ToInt(out_node.GetString("PROC_TIME").Substring(4, 2));
                }

                if (MPCF.Trim(out_node.GetChar("MODIFY_FLAG")) == "Y")
                {
                    chkModify.Checked = true;
                }
                else
                {
                    chkModify.Checked = false;
                }
                
                iLastSeq = 0;
                
                bParaInsertFlag = true;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    
                    bParaInsertFlag = false;
                    
                    spdParameter.Sheets[0].RowCount++;
                    LastRow = spdParameter.Sheets[0].RowCount - 1;
                    
                    FarPoint.Win.Spread.SheetView with_1 = spdParameter.Sheets[0];

                    with_1.SetValue(LastRow, 1, MPCF.Trim(out_node.GetList(0)[i].GetInt("PARA_SEQ")));
                    with_1.SetValue(LastRow, 2, MPCF.Trim(out_node.GetList(0)[i].GetString("PARA_ID")));
                    with_1.SetValue(LastRow, 3, MPCF.Trim(out_node.GetList(0)[i].GetString("PARA_VALUE")));
                    with_1.SetValue(LastRow, 4, MPCF.Trim(out_node.GetList(0)[i].GetString("PARA_DESC")));
                    with_1.SetValue(LastRow, 5, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("MODIFY_FLAG")) == "Y") ? "V" : " "));

                    if (MPCF.Trim(out_node.GetList(0)[i].GetChar("MODIFY_FLAG")) != "Y")
                    {
                        with_1.Cells[LastRow, 3].Locked = true;
                    }

                    iLastSeq = MPCF.ToInt(MPCF.Trim(out_node.GetList(0)[i].GetInt("PARA_SEQ")));
                    
                    
                }
                
                if (bParaInsertFlag == true)
                {
                    
                    spdParameter.Sheets[0].RowCount++;
                    
                    spdParameter.Sheets[0].SetValue(spdParameter.Sheets[0].RowCount - 1, 1, iLastSeq + 1);
                    spdParameter.Sheets[0].SetValue(spdParameter.Sheets[0].RowCount - 1, 5, "V");
                    
                    for (i = 1; i <= spdParameter.Sheets[0].ColumnCount - 1; i++)
                    {
                        spdParameter.Sheets[0].Cells.Get(spdParameter.Sheets[0].RowCount - 1, i).BackColor = System.Drawing.Color.WhiteSmoke;
                        spdParameter.Sheets[0].Cells[spdParameter.Sheets[0].RowCount - 1, i].Locked = false;
                    }
                    
                    spdParameter.Sheets[0].Cells[spdParameter.Sheets[0].RowCount - 1, i - 1].Locked = true;
                    spdParameter.Sheets[0].Cells[spdParameter.Sheets[0].RowCount - 1, 1].Locked = true;
                    
                }
                
                MPCF.FitColumnHeader(spdParameter);
                
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return true;
            
        }
        
        //'
        // Update_Sublot_Recipe()
        //       - Update SubLot Recipe
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Update_Sublot_Recipe(char ProcStep)
        {
            
            int i = 0;

            TRSNode in_node = new TRSNode("UPDATE_SUBLOT_RECIPE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode msg_list;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("LOT_ID", SUBLOT.GetString("LOT_ID"));
                in_node.AddString("SUBLOT_ID", MPCF.Trim(txtSublotID.Text));
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", SUBLOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("PP_ID", MPCF.Trim(txtPPId.Text));
                in_node.AddString("COAT_PP_ID", MPCF.Trim(txtCoatPPID.Text));
                in_node.AddString("COL_SET_ID", MPCF.Trim(cdvColSetID.Text));
                in_node.AddString("RETICLE_ID", MPCF.Trim(txtReticleID.Text));
                in_node.AddString("PROC_TIME", MPCF.Format("00", nudHour.Value) + MPCF.Format("00", nudMinute.Value) + MPCF.Format("00", nudSecond.Value));
                in_node.AddChar("MODIFY_FLAG", (chkModify.Checked ? 'Y' : ' '));

                FarPoint.Win.Spread.SheetView with_1 = spdParameter.Sheets[0];

                for (i = 0; i <= spdParameter.Sheets[0].RowCount - 1; i++)
                {
                    msg_list = out_node.AddNode("PARA_VERSION_LIST");

                    //?섏젙?щ????곴??놁씠 ?꾩넚?쒕떎.
                    //If .GetValue(i, 0) = True Then
                    msg_list.AddInt("PARA_SEQ", MPCF.ToInt(with_1.GetValue(i, 1)));
                    msg_list.AddString("PARA_ID", MPCF.Trim(with_1.GetValue(i, 2)));
                    msg_list.AddString("PARA_VALUE", MPCF.Trim(with_1.GetValue(i, 3)));
                    msg_list.AddString("PARA_DESC", MPCF.Trim(with_1.GetValue(i, 4)));
                    msg_list.AddChar("MODIFY_FLAG", (MPCF.Trim(with_1.GetValue(i, 5)) == "V") ? 'Y' : ' ');

                    //End If
                }

                if (MPCR.CallService("RCP", "RCP_Update_Sublot_Recipe", in_node, ref out_node) == false)
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
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.txtSublotID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmRCPTranModifySublotRecipe_Renamed(object sender, System.EventArgs e)
        {
            
        }
        
        private void frmRCPTranModifySublotRecipe_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    ClearData('1');
                    //Sublot이 대상이므로 이런 코드는 필요 없다.
                    //if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                    //{
                    //    txtLotID.Text = MPGV.gsCurrentLot_ID;
                    //    ClearData('2');
                    //}
                    
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void txtSublotID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)13)
            {
                if (txtSublotID.Text != "")
                {
                    ClearData('2');
                }
            }
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("Update_Sublot_Recipe") == true)
                {
                    if (Update_Sublot_Recipe('1') == false)
                    {
                        return;
                    }

                    ClearData('2');
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {

            if (MPCF.Trim(SUBLOT.GetString("OPER")) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                txtSublotID.Focus();
                return;
            }
            
        }
        
        private void cdvResID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            if (cdvResID.Text != "")
            {
                if (View_Sublot_Recipe() == false)
                {
                    return;
                }
            }
            
        }     
     
        
        private void cdvResID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            if (cdvResID.Text == "")
            {
                ClearData('3');
            }
            
        }
        
        private void spdParameter_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            int i = 0;
            int iLastSeq = 0;
            
            if (e.Column > 0 && e.Row >= 0)
            {
                
                spdParameter.Sheets[0].SetValue(e.Row, 0, true);
                
                if (bParaInsertFlag == true)
                {
                    
                    if (spdParameter.Sheets[0].GetValue(e.Row, 0) != null &&
                        Convert.ToBoolean(spdParameter.Sheets[0].GetValue(e.Row, 0)) == true)
                    {
                        if (e.Row == spdParameter.Sheets[0].RowCount - 1)
                        {
                            
                            iLastSeq = MPCF.ToInt(spdParameter.Sheets[0].GetValue(e.Row, 1));
                            
                            spdParameter.Sheets[0].RowCount++;
                            
                            spdParameter.Sheets[0].SetValue(spdParameter.Sheets[0].RowCount - 1, 1, iLastSeq + 1);
                            spdParameter.Sheets[0].SetValue(spdParameter.Sheets[0].RowCount - 1, 5, "V");
                            
                            for (i = 1; i <= spdParameter.Sheets[0].ColumnCount - 1; i++)
                            {
                                spdParameter.Sheets[0].Cells.Get(spdParameter.Sheets[0].RowCount - 1, i).BackColor = System.Drawing.Color.WhiteSmoke;
                                spdParameter.Sheets[0].Cells[spdParameter.Sheets[0].RowCount - 1, i].Locked = false;
                            }
                            
                            spdParameter.Sheets[0].Cells[spdParameter.Sheets[0].RowCount - 1, i - 1].Locked = true;
                            spdParameter.Sheets[0].Cells[spdParameter.Sheets[0].RowCount - 1, 1].Locked = true;
                            
                        }
                    }
                }
            }
        }
        
        private void chkModify_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            txtPPId.ReadOnly = ! chkModify.Checked;
            txtCoatPPID.ReadOnly = ! chkModify.Checked;
            txtReticleID.ReadOnly = ! chkModify.Checked;
            cdvColSetID.Enabled = chkModify.Checked;
            nudHour.ReadOnly = ! chkModify.Checked;
            nudMinute.ReadOnly = ! chkModify.Checked;
            nudSecond.ReadOnly = ! chkModify.Checked;
            
        }
        
        private void cdvColSetID_ButtonPress(object sender, System.EventArgs e)
        {
            
            //Initialize ListView
            cdvColSetID.Init();
            MPCF.InitListView(cdvColSetID.GetListView);
            cdvColSetID.Columns.Add("Collection Set", 50, HorizontalAlignment.Left);
            cdvColSetID.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvColSetID.SelectedSubItemIndex = 0;
            #if _EDC
            if (EDCLIST.ViewEDCColSetList(cdvColSetID.GetListView, '1', null, "", -1, -1, ' ', false) == false)
            {
                return;
            }
            #endif
        }

        private void cdvResID_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (cdvResID.Text != "")
                {
                    if (View_Sublot_Recipe() == false)
                    {
                        return;
                    }
                }
            }
        }
    }
    //#End If
}
