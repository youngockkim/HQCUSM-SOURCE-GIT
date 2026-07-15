
//#If _BOM = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBOMTranAssembly.vb
//   Description : BOM Assembly Lot Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-07-21 : Created by CM Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

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


namespace Miracom.BOMCore
{
    public class frmBOMTranAssembly : Miracom.MESCore.TranForm07
    {
        
        #region " Windows Form auto generated code "
        
        public frmBOMTranAssembly()
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
        



        private System.Windows.Forms.GroupBox grpAssm;
        private System.Windows.Forms.Panel pnlAssmLeft;
        private System.Windows.Forms.TextBox txtMatQty;
        private System.Windows.Forms.TextBox txtMatSerial;
        private System.Windows.Forms.Label lblMatQty;
        private System.Windows.Forms.Label lblMatSerial;
        private System.Windows.Forms.Panel pnlAssemMid;
        private System.Windows.Forms.Panel pnlAssmMidTop;
        private System.Windows.Forms.Panel pnlAssmMidMid;
        private FarPoint.Win.Spread.FpSpread spdBomMatList;
        private FarPoint.Win.Spread.SheetView spdBomMatList_Sheet1;
        private System.Windows.Forms.Label lblBomSetID;
        private System.Windows.Forms.Label lblBomSetVersion;
        private System.Windows.Forms.TextBox txtBomSetID;
        private System.Windows.Forms.TextBox txtBomSetVersion;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.grpAssm = new System.Windows.Forms.GroupBox();
            this.pnlAssemMid = new System.Windows.Forms.Panel();
            this.pnlAssmMidMid = new System.Windows.Forms.Panel();
            this.spdBomMatList = new FarPoint.Win.Spread.FpSpread();
            this.spdBomMatList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlAssmMidTop = new System.Windows.Forms.Panel();
            this.txtBomSetVersion = new System.Windows.Forms.TextBox();
            this.txtBomSetID = new System.Windows.Forms.TextBox();
            this.lblBomSetVersion = new System.Windows.Forms.Label();
            this.lblBomSetID = new System.Windows.Forms.Label();
            this.pnlAssmLeft = new System.Windows.Forms.Panel();
            this.txtMatQty = new System.Windows.Forms.TextBox();
            this.txtMatSerial = new System.Windows.Forms.TextBox();
            this.lblMatQty = new System.Windows.Forms.Label();
            this.lblMatSerial = new System.Windows.Forms.Label();
            this.pnlTranInfo.SuspendLayout();
            this.pnlGeneralTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo)).BeginInit();
            this.grpLotInfo.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlTran.SuspendLayout();
            this.pnlComment.SuspendLayout();
            this.tbpCMF.SuspendLayout();
            this.grpComment.SuspendLayout();
            this.grpCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF11)).BeginInit();
            this.pnlTranTime.SuspendLayout();
            this.tabTran.SuspendLayout();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpAssm.SuspendLayout();
            this.pnlAssemMid.SuspendLayout();
            this.pnlAssmMidMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdBomMatList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdBomMatList_Sheet1)).BeginInit();
            this.pnlAssmMidTop.SuspendLayout();
            this.pnlAssmLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpAssm);
            // 
            // spdLotInfo
            // 
            this.spdLotInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.HorizontalScrollBar.Name = "";
            this.spdLotInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdLotInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdLotInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.VerticalScrollBar.Name = "";
            this.spdLotInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdLotInfo.VerticalScrollBar.TabIndex = 3;
            // 
            // tbpCMF
            // 
            this.tbpCMF.Size = new System.Drawing.Size(728, 422);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            // 
            // cdvCMF9
            // 
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.TabIndex = 8;
            // 
            // cdvCMF8
            // 
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.TabIndex = 7;
            // 
            // cdvCMF7
            // 
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.TabIndex = 6;
            // 
            // cdvCMF6
            // 
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.TabIndex = 5;
            // 
            // cdvCMF5
            // 
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.TabIndex = 4;
            // 
            // cdvCMF4
            // 
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.TabIndex = 3;
            // 
            // cdvCMF3
            // 
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.TabIndex = 2;
            // 
            // cdvCMF2
            // 
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.TabIndex = 1;
            // 
            // cdvCMF10
            // 
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.TabIndex = 9;
            // 
            // cdvCMF1
            // 
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.TabIndex = 0;
            // 
            // cdvCMF19
            // 
            this.cdvCMF19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.TabIndex = 18;
            // 
            // cdvCMF18
            // 
            this.cdvCMF18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.TabIndex = 17;
            // 
            // cdvCMF17
            // 
            this.cdvCMF17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.TabIndex = 16;
            // 
            // cdvCMF16
            // 
            this.cdvCMF16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.TabIndex = 15;
            // 
            // cdvCMF15
            // 
            this.cdvCMF15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.TabIndex = 14;
            // 
            // cdvCMF14
            // 
            this.cdvCMF14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.TabIndex = 13;
            // 
            // cdvCMF13
            // 
            this.cdvCMF13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.TabIndex = 12;
            // 
            // cdvCMF12
            // 
            this.cdvCMF12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.TabIndex = 11;
            // 
            // cdvCMF20
            // 
            this.cdvCMF20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.TabIndex = 19;
            // 
            // cdvCMF11
            // 
            this.cdvCMF11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.TabIndex = 10;
            // 
            // txtTranDateTime
            // 
            this.txtTranDateTime.TabIndex = 0;
            // 
            // dtpTranTime
            // 
            this.dtpTranTime.TabIndex = 1;
            this.dtpTranTime.TabStop = false;
            // 
            // chkTranDateTime
            // 
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.Location = new System.Drawing.Point(13, 3);
            this.chkTranDateTime.Size = new System.Drawing.Size(114, 18);
            // 
            // dtpTranDate
            // 
            this.dtpTranDate.TabStop = false;
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            // 
            // lblLotDesc
            // 
            this.lblLotDesc.AutoSize = true;
            this.lblLotDesc.Size = new System.Drawing.Size(60, 13);
            // 
            // txtLotID
            // 
            this.txtLotID.TabIndex = 0;
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.MaxLength = 200;
            this.txtLotDesc.TabIndex = 1;
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Assembly Lot";
            // 
            // grpAssm
            // 
            this.grpAssm.Controls.Add(this.pnlAssemMid);
            this.grpAssm.Controls.Add(this.pnlAssmLeft);
            this.grpAssm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAssm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpAssm.Location = new System.Drawing.Point(0, 0);
            this.grpAssm.Name = "grpAssm";
            this.grpAssm.Size = new System.Drawing.Size(722, 242);
            this.grpAssm.TabIndex = 0;
            this.grpAssm.TabStop = false;
            // 
            // pnlAssemMid
            // 
            this.pnlAssemMid.Controls.Add(this.pnlAssmMidMid);
            this.pnlAssemMid.Controls.Add(this.pnlAssmMidTop);
            this.pnlAssemMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAssemMid.Location = new System.Drawing.Point(123, 16);
            this.pnlAssemMid.Name = "pnlAssemMid";
            this.pnlAssemMid.Size = new System.Drawing.Size(596, 223);
            this.pnlAssemMid.TabIndex = 0;
            // 
            // pnlAssmMidMid
            // 
            this.pnlAssmMidMid.Controls.Add(this.spdBomMatList);
            this.pnlAssmMidMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAssmMidMid.Location = new System.Drawing.Point(0, 24);
            this.pnlAssmMidMid.Name = "pnlAssmMidMid";
            this.pnlAssmMidMid.Size = new System.Drawing.Size(596, 199);
            this.pnlAssmMidMid.TabIndex = 0;
            // 
            // spdBomMatList
            // 
            this.spdBomMatList.AccessibleDescription = "spdBomMatList, Sheet1, Row 0, Column 0, ";
            this.spdBomMatList.BackColor = System.Drawing.SystemColors.Control;
            this.spdBomMatList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdBomMatList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdBomMatList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdBomMatList.HorizontalScrollBar.Name = "";
            this.spdBomMatList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdBomMatList.HorizontalScrollBar.TabIndex = 2;
            this.spdBomMatList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdBomMatList.Location = new System.Drawing.Point(0, 0);
            this.spdBomMatList.Name = "spdBomMatList";
            this.spdBomMatList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdBomMatList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdBomMatList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdBomMatList_Sheet1});
            this.spdBomMatList.Size = new System.Drawing.Size(596, 199);
            this.spdBomMatList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdBomMatList.TabIndex = 0;
            this.spdBomMatList.TabStop = false;
            this.spdBomMatList.TextTipDelay = 200;
            this.spdBomMatList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdBomMatList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdBomMatList.VerticalScrollBar.Name = "";
            this.spdBomMatList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdBomMatList.VerticalScrollBar.TabIndex = 3;
            this.spdBomMatList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdBomMatList.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdBomMatList_CellClick);
            this.spdBomMatList.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdBomMatList_ButtonClicked);
            // 
            // spdBomMatList_Sheet1
            // 
            this.spdBomMatList_Sheet1.Reset();
            spdBomMatList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdBomMatList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdBomMatList_Sheet1.ColumnCount = 15;
            spdBomMatList_Sheet1.RowCount = 4;
            this.spdBomMatList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdBomMatList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdBomMatList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdBomMatList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdBomMatList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdBomMatList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Part Group";
            this.spdBomMatList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Mat ID";
            this.spdBomMatList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Version";
            this.spdBomMatList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Mat Qty";
            this.spdBomMatList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Mat Unit";
            this.spdBomMatList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Serial ID";
            this.spdBomMatList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Attach Qty";
            this.spdBomMatList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "ALT_MAT_FLAG";
            this.spdBomMatList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "OPT_INPUT_FLAG";
            this.spdBomMatList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "AUTO_INPUT_FLAG";
            this.spdBomMatList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "SERIAL_INPUT_FLAG";
            this.spdBomMatList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "SERIAL_TYPE";
            this.spdBomMatList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "CHK_SERIAL_FLAG";
            this.spdBomMatList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Already Assembled";
            this.spdBomMatList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdBomMatList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdBomMatList_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdBomMatList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBomMatList_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdBomMatList_Sheet1.Columns.Get(0).Locked = false;
            this.spdBomMatList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBomMatList_Sheet1.Columns.Get(0).Width = 55F;
            this.spdBomMatList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBomMatList_Sheet1.Columns.Get(1).Label = "Part Group";
            this.spdBomMatList_Sheet1.Columns.Get(1).Locked = true;
            this.spdBomMatList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBomMatList_Sheet1.Columns.Get(1).Width = 80F;
            this.spdBomMatList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBomMatList_Sheet1.Columns.Get(2).Label = "Mat ID";
            this.spdBomMatList_Sheet1.Columns.Get(2).Locked = true;
            this.spdBomMatList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBomMatList_Sheet1.Columns.Get(2).Width = 110F;
            this.spdBomMatList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdBomMatList_Sheet1.Columns.Get(3).Label = "Version";
            this.spdBomMatList_Sheet1.Columns.Get(3).Locked = true;
            this.spdBomMatList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBomMatList_Sheet1.Columns.Get(3).Width = 45F;
            this.spdBomMatList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdBomMatList_Sheet1.Columns.Get(4).Label = "Mat Qty";
            this.spdBomMatList_Sheet1.Columns.Get(4).Locked = true;
            this.spdBomMatList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBomMatList_Sheet1.Columns.Get(4).Width = 75F;
            this.spdBomMatList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBomMatList_Sheet1.Columns.Get(5).Label = "Mat Unit";
            this.spdBomMatList_Sheet1.Columns.Get(5).Locked = true;
            this.spdBomMatList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBomMatList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBomMatList_Sheet1.Columns.Get(6).Label = "Serial ID";
            this.spdBomMatList_Sheet1.Columns.Get(6).Locked = true;
            this.spdBomMatList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBomMatList_Sheet1.Columns.Get(6).Width = 100F;
            this.spdBomMatList_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdBomMatList_Sheet1.Columns.Get(7).Label = "Attach Qty";
            this.spdBomMatList_Sheet1.Columns.Get(7).Locked = true;
            this.spdBomMatList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBomMatList_Sheet1.Columns.Get(7).Width = 75F;
            this.spdBomMatList_Sheet1.Columns.Get(8).BackColor = System.Drawing.Color.Gray;
            this.spdBomMatList_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBomMatList_Sheet1.Columns.Get(8).Label = "ALT_MAT_FLAG";
            this.spdBomMatList_Sheet1.Columns.Get(8).Locked = true;
            this.spdBomMatList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBomMatList_Sheet1.Columns.Get(8).Width = 110F;
            this.spdBomMatList_Sheet1.Columns.Get(9).BackColor = System.Drawing.Color.Gray;
            this.spdBomMatList_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBomMatList_Sheet1.Columns.Get(9).Label = "OPT_INPUT_FLAG";
            this.spdBomMatList_Sheet1.Columns.Get(9).Locked = true;
            this.spdBomMatList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBomMatList_Sheet1.Columns.Get(9).Width = 126F;
            this.spdBomMatList_Sheet1.Columns.Get(10).BackColor = System.Drawing.Color.Gray;
            this.spdBomMatList_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBomMatList_Sheet1.Columns.Get(10).Label = "AUTO_INPUT_FLAG";
            this.spdBomMatList_Sheet1.Columns.Get(10).Locked = true;
            this.spdBomMatList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBomMatList_Sheet1.Columns.Get(10).Width = 123F;
            this.spdBomMatList_Sheet1.Columns.Get(11).BackColor = System.Drawing.Color.Gray;
            this.spdBomMatList_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBomMatList_Sheet1.Columns.Get(11).Label = "SERIAL_INPUT_FLAG";
            this.spdBomMatList_Sheet1.Columns.Get(11).Locked = true;
            this.spdBomMatList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBomMatList_Sheet1.Columns.Get(11).Width = 136F;
            this.spdBomMatList_Sheet1.Columns.Get(12).BackColor = System.Drawing.Color.Gray;
            this.spdBomMatList_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBomMatList_Sheet1.Columns.Get(12).Label = "SERIAL_TYPE";
            this.spdBomMatList_Sheet1.Columns.Get(12).Locked = true;
            this.spdBomMatList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBomMatList_Sheet1.Columns.Get(12).Width = 102F;
            this.spdBomMatList_Sheet1.Columns.Get(13).BackColor = System.Drawing.Color.Gray;
            this.spdBomMatList_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBomMatList_Sheet1.Columns.Get(13).Label = "CHK_SERIAL_FLAG";
            this.spdBomMatList_Sheet1.Columns.Get(13).Locked = true;
            this.spdBomMatList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBomMatList_Sheet1.Columns.Get(13).Width = 131F;
            this.spdBomMatList_Sheet1.Columns.Get(14).BackColor = System.Drawing.Color.Gray;
            this.spdBomMatList_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBomMatList_Sheet1.Columns.Get(14).Label = "Already Assembled";
            this.spdBomMatList_Sheet1.Columns.Get(14).Locked = true;
            this.spdBomMatList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBomMatList_Sheet1.Columns.Get(14).Width = 135F;
            this.spdBomMatList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdBomMatList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdBomMatList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdBomMatList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdBomMatList_Sheet1.RowHeader.Visible = false;
            this.spdBomMatList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdBomMatList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdBomMatList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlAssmMidTop
            // 
            this.pnlAssmMidTop.Controls.Add(this.txtBomSetVersion);
            this.pnlAssmMidTop.Controls.Add(this.txtBomSetID);
            this.pnlAssmMidTop.Controls.Add(this.lblBomSetVersion);
            this.pnlAssmMidTop.Controls.Add(this.lblBomSetID);
            this.pnlAssmMidTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAssmMidTop.Location = new System.Drawing.Point(0, 0);
            this.pnlAssmMidTop.Name = "pnlAssmMidTop";
            this.pnlAssmMidTop.Size = new System.Drawing.Size(596, 24);
            this.pnlAssmMidTop.TabIndex = 0;
            // 
            // txtBomSetVersion
            // 
            this.txtBomSetVersion.Location = new System.Drawing.Point(416, 0);
            this.txtBomSetVersion.MaxLength = 3;
            this.txtBomSetVersion.Name = "txtBomSetVersion";
            this.txtBomSetVersion.ReadOnly = true;
            this.txtBomSetVersion.Size = new System.Drawing.Size(100, 20);
            this.txtBomSetVersion.TabIndex = 3;
            this.txtBomSetVersion.TabStop = false;
            // 
            // txtBomSetID
            // 
            this.txtBomSetID.Location = new System.Drawing.Point(118, 0);
            this.txtBomSetID.MaxLength = 25;
            this.txtBomSetID.Name = "txtBomSetID";
            this.txtBomSetID.ReadOnly = true;
            this.txtBomSetID.Size = new System.Drawing.Size(150, 20);
            this.txtBomSetID.TabIndex = 1;
            this.txtBomSetID.TabStop = false;
            // 
            // lblBomSetVersion
            // 
            this.lblBomSetVersion.AutoSize = true;
            this.lblBomSetVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBomSetVersion.Location = new System.Drawing.Point(310, 3);
            this.lblBomSetVersion.Name = "lblBomSetVersion";
            this.lblBomSetVersion.Size = new System.Drawing.Size(88, 13);
            this.lblBomSetVersion.TabIndex = 2;
            this.lblBomSetVersion.Text = "BOM Set Version";
            // 
            // lblBomSetID
            // 
            this.lblBomSetID.AutoSize = true;
            this.lblBomSetID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBomSetID.Location = new System.Drawing.Point(12, 3);
            this.lblBomSetID.Name = "lblBomSetID";
            this.lblBomSetID.Size = new System.Drawing.Size(64, 13);
            this.lblBomSetID.TabIndex = 0;
            this.lblBomSetID.Text = "BOM Set ID";
            // 
            // pnlAssmLeft
            // 
            this.pnlAssmLeft.Controls.Add(this.txtMatQty);
            this.pnlAssmLeft.Controls.Add(this.txtMatSerial);
            this.pnlAssmLeft.Controls.Add(this.lblMatQty);
            this.pnlAssmLeft.Controls.Add(this.lblMatSerial);
            this.pnlAssmLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAssmLeft.Location = new System.Drawing.Point(3, 16);
            this.pnlAssmLeft.Name = "pnlAssmLeft";
            this.pnlAssmLeft.Size = new System.Drawing.Size(120, 223);
            this.pnlAssmLeft.TabIndex = 0;
            // 
            // txtMatQty
            // 
            this.txtMatQty.Location = new System.Drawing.Point(12, 97);
            this.txtMatQty.MaxLength = 11;
            this.txtMatQty.Name = "txtMatQty";
            this.txtMatQty.ReadOnly = true;
            this.txtMatQty.Size = new System.Drawing.Size(96, 20);
            this.txtMatQty.TabIndex = 1;
            this.txtMatQty.TabStop = false;
            this.txtMatQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatQty_KeyPress);
            this.txtMatQty.LostFocus += new System.EventHandler(this.txtMatQty_LostFocus);
            // 
            // txtMatSerial
            // 
            this.txtMatSerial.Location = new System.Drawing.Point(12, 42);
            this.txtMatSerial.MaxLength = 30;
            this.txtMatSerial.Name = "txtMatSerial";
            this.txtMatSerial.ReadOnly = true;
            this.txtMatSerial.Size = new System.Drawing.Size(96, 20);
            this.txtMatSerial.TabIndex = 0;
            this.txtMatSerial.TabStop = false;
            this.txtMatSerial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatSerial_KeyPress);
            this.txtMatSerial.LostFocus += new System.EventHandler(this.txtMatSerial_LostFocus);
            // 
            // lblMatQty
            // 
            this.lblMatQty.AutoSize = true;
            this.lblMatQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMatQty.Location = new System.Drawing.Point(12, 82);
            this.lblMatQty.Name = "lblMatQty";
            this.lblMatQty.Size = new System.Drawing.Size(63, 13);
            this.lblMatQty.TabIndex = 2;
            this.lblMatQty.Text = "Material Qty";
            // 
            // lblMatSerial
            // 
            this.lblMatSerial.AutoSize = true;
            this.lblMatSerial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMatSerial.Location = new System.Drawing.Point(12, 27);
            this.lblMatSerial.Name = "lblMatSerial";
            this.lblMatSerial.Size = new System.Drawing.Size(73, 13);
            this.lblMatSerial.TabIndex = 0;
            this.lblMatSerial.Text = "Material Serial";
            // 
            // frmBOMTranAssembly
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmBOMTranAssembly";
            this.Text = "Assemble";
            this.Activated += new System.EventHandler(this.frmBOMTranAssembly_Activated);
            this.pnlTranInfo.ResumeLayout(false);
            this.pnlGeneralTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo)).EndInit();
            this.grpLotInfo.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlTran.ResumeLayout(false);
            this.pnlComment.ResumeLayout(false);
            this.tbpCMF.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.grpCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF11)).EndInit();
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            this.tabTran.ResumeLayout(false);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpAssm.ResumeLayout(false);
            this.pnlAssemMid.ResumeLayout(false);
            this.pnlAssmMidMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdBomMatList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdBomMatList_Sheet1)).EndInit();
            this.pnlAssmMidTop.ResumeLayout(false);
            this.pnlAssmMidTop.PerformLayout();
            this.pnlAssmLeft.ResumeLayout(false);
            this.pnlAssmLeft.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const int COL_SEQ = 0;
        private const int COL_PART_GRP = 1;
        private const int COL_MAT_ID = 2;
        private const int COL_MAT_VER = 3;
        private const int COL_MAT_QTY = 4;
        private const int COL_MAT_UNIT = 5;
        private const int COL_SERIAL_ID = 6;
        private const int COL_ATTACH_QTY = 7;
        private const int COL_ALT_MAT_FLAG = 8;
        private const int COL_OPT_IN_FLAG = 9;
        private const int COL_AUTO_IN_FLAG = 10;
        private const int COL_SERIAL_IN_FLAG = 11;
        private const int COL_SERIAL_TYPE = 12;
        private const int COL_CHK_SERIAL_FLAG = 13;
        private const int COL_ALREADY_ASSEMBLED = 14;
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        #endregion
        
        #region " Function Definition "

        // ViewLotInfo()
        //       -   View Lot Information
        // Return Value
        //       -
        // Arguments
        //       -
        protected override bool ViewLotInfo(string s_lot_id)
        {
            MPCF.FieldClear(this, txtLotID);
            MPCF.ClearList(spdBomMatList, true);

            txtMatSerial.ReadOnly = true;
            txtMatQty.ReadOnly = true;

            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }
            txtLotDesc.Text = LOT.GetString("LOT_DESC");

            if (GetBomSetVersion() == false)
            {
                txtLotID.Focus();
                return false;
            }
            if (GetBomAttachMaterialList() == false)
            {
                txtLotID.Focus();
                return false;
            }
            if (GetAssembledMaterialList() == false)
            {
                txtLotID.Focus();
                return false;
            }

            return true;
        }

        // ClearData()
        //       -   Clear Form Control Data
        // Return Value
        //       -
        // Arguments
        //       -
        private void ClearData(int iStep)
        {

            ClearLotSpread();
            MPCF.ClearList(spdBomMatList, true);
            
            txtMatSerial.ReadOnly = true;
            txtMatQty.ReadOnly = true;
            
            switch (iStep)
            {
                case 0:
                    
                    MPCF.FieldClear(this);
                    break;
            }
        }
        
        private bool GetBomSetVersion()
        {
            TRSNode in_node = new TRSNode("FIND_BOM_SET_VERSION_IN");
            TRSNode out_node = new TRSNode("FIND_BOM_SET_VERSION_OUT");

            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));

                if (MPCR.CallService("BOM", "BOM_Find_Bom_Set_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtBomSetID.Text = out_node.GetString("BOM_SET_ID");
                txtBomSetVersion.Text = out_node.GetInt("BOM_SET_VERSION").ToString();

                if (MPCF.Trim(LOT.GetString("BOM_SET_ID")) != "" && LOT.GetInt("BOM_SET_VERSION") != 0)
                {
                    if (MPGO.DiffBomSetVersion() == false)
                    {
                        if (LOT.GetString("BOM_SET_ID") != out_node.GetString("BOM_SET_ID") ||
                            LOT.GetInt("BOM_SET_VERSION") != out_node.GetInt("BOM_SET_VERSION"))
                        {
                            if (MPCF.ShowMsgBox(MPCF.GetMessage(167), MessageBoxButtons.YesNo, 2) == DialogResult.No)
                            {
                                return false;
                            }

                            txtBomSetID.Text = LOT.GetString("BOM_SET_ID");
                            txtBomSetVersion.Text = LOT.GetInt("BOM_SET_VERSION").ToString();
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

        private bool GetBomAttachMaterialList()
        {
            TRSNode in_node = new TRSNode("VIEW_ATTACH_MATERIAL_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_ATTACH_MATERIAL_LIST_OUT");
            int i;
            int iRow;
            FarPoint.Win.Spread.SheetView sheet;

            try
            {

                MPCF.ClearList(spdBomMatList, true);
                sheet = spdBomMatList.Sheets[0];

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("BOM_SET_ID", MPCF.Trim(txtBomSetID.Text));
                in_node.AddInt("BOM_SET_VERSION", MPCF.ToInt(txtBomSetVersion.Text));
                in_node.AddString("FLOW", MPCF.Trim(LOT.GetString("FLOW")));
                in_node.AddString("OPER", MPCF.Trim(LOT.GetString("OPER")));

                do
                {
                    if (MPCR.CallService("BOM", "BOM_View_Attach_Material_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = sheet.RowCount;
                        sheet.RowCount++;

                        sheet.Cells[iRow, COL_SEQ].CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();

                        ((FarPoint.Win.Spread.CellType.CheckBoxCellType) sheet.Cells[iRow, COL_SEQ].CellType).Caption = out_node.GetList(0)[i].GetInt("SEQ_NUM").ToString();
                        sheet.Cells[iRow, COL_PART_GRP].Value = out_node.GetList(0)[i].GetString("PART_GRP");
                        sheet.Cells[iRow, COL_MAT_ID].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                        sheet.Cells[iRow, COL_MAT_VER].Value = out_node.GetList(0)[i].GetInt("MAT_VER");
                        sheet.Cells[iRow, COL_MAT_QTY].Value = MPCF.Format("#####,##0.###", out_node.GetList(0)[i].GetDouble("MAT_QTY"));
                        sheet.Cells[iRow, COL_MAT_UNIT].Value = out_node.GetList(0)[i].GetString("MAT_UNIT");

                        sheet.Cells[iRow, COL_ALT_MAT_FLAG].Value = out_node.GetList(0)[i].GetChar("ALT_MAT_FLAG");
                        sheet.Cells[iRow, COL_OPT_IN_FLAG].Value = out_node.GetList(0)[i].GetChar("OPT_INPUT_FLAG");
                        sheet.Cells[iRow, COL_AUTO_IN_FLAG].Value = out_node.GetList(0)[i].GetChar("AUTO_INPUT_FLAG");
                        sheet.Cells[iRow, COL_SERIAL_IN_FLAG].Value = out_node.GetList(0)[i].GetChar("SERIAL_INPUT_FLAG");
                        sheet.Cells[iRow, COL_SERIAL_TYPE].Value = out_node.GetList(0)[i].GetChar("SERIAL_TYPE");
                        sheet.Cells[iRow, COL_CHK_SERIAL_FLAG].Value = out_node.GetList(0)[i].GetChar("CHK_SERIAL_FLAG");

                        if (out_node.GetList(0)[i].GetChar("OPT_INPUT_FLAG") == 'Y')
                        {
                            sheet.Rows[iRow].Font = new Font(spdBomMatList.Font.Name, spdBomMatList.Font.Size, FontStyle.Bold);
                        }
                        if (out_node.GetList(0)[i].GetChar("AUTO_INPUT_FLAG") == 'Y')
                        {
                            sheet.Rows[iRow].BackColor = Color.WhiteSmoke;
                            sheet.Cells[iRow, COL_SEQ].Value = true;
                            sheet.Cells[iRow, COL_SEQ].Locked = true;
                            sheet.Cells[iRow, COL_ATTACH_QTY].Value = MPCF.Format("#####,##0.###", out_node.GetList(0)[i].GetDouble("MAT_QTY"));
                            sheet.Cells[iRow, COL_SERIAL_IN_FLAG].Value = "";
                        }
                        if (out_node.GetList(0)[i].GetChar("AUTO_INPUT_FLAG") != 'Y' && out_node.GetList(0)[i].GetChar("SERIAL_INPUT_FLAG") == 'Y')
                        {
                            sheet.Cells[iRow, COL_SERIAL_ID].BackColor = Color.White;
                        }
                        else
                        {
                            sheet.Cells[iRow, COL_SERIAL_ID].BackColor = Color.WhiteSmoke;
                        }

                    }

                    in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));
                } while (out_node.GetInt("NEXT_SEQ_NUM") > 0);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);

                return false;
            }

            return true;

        }

        private bool GetAssembledMaterialList()
        {

            int i;
            int iRow;
            FarPoint.Win.Spread.SheetView sheet;

            TRSNode in_node = new TRSNode("VIEW_LOT_STATUS_FOR_ASSEMBLY_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_STATUS_FOR_ASSEMBLY_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("BOM_SET_ID", MPCF.Trim(txtBomSetID.Text));
                in_node.AddInt("BOM_SET_VERSION", MPCF.ToInt(txtBomSetVersion.Text));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddString("OPER", LOT.GetString("OPER"));

                sheet = spdBomMatList.Sheets[0];

                do
                {
                    if (MPCR.CallService("BOM", "BOM_View_Lot_Status_For_Assembly", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = FindRow(out_node.GetList(0)[i].GetInt("SEQ_NUM"));
                        if (iRow >= 0)
                        {
                            if (MPCF.Trim(sheet.Cells[iRow, COL_MAT_ID].Value) == out_node.GetList(0)[i].GetString("MAT_ID"))
                            {
                                sheet.Rows[iRow].ForeColor = Color.LightSeaGreen;
                                sheet.Cells[iRow, COL_ALREADY_ASSEMBLED].Value = "Y";
                                sheet.Cells[iRow, COL_SEQ].Value = true;
                                sheet.Cells[iRow, COL_SEQ].Locked = true;
                                sheet.Cells[iRow, COL_SERIAL_ID].Value = out_node.GetList(0)[i].GetString("SERIAL_ID");
                                sheet.Cells[iRow, COL_ATTACH_QTY].Value = MPCF.Format("#####,##0.###", out_node.GetList(0)[i].GetDouble("MAT_ATT_QTY"));
                            }
                        }
                    }

                    in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));
                    in_node.SetInt("NEXT_SERIAL_SEQ_NUM", out_node.GetInt("NEXT_SERIAL_SEQ_NUM"));

                } while (out_node.GetInt("NEXT_SEQ_NUM") > 0 || out_node.GetInt("NEXT_SERIAL_SEQ_NUM") > 0);


                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
        private int FindRow(int iSeqNum)
        {
            int i;
            
            FarPoint.Win.Spread.SheetView with_1 = spdBomMatList.Sheets[0];
            for (i = 0; i <= with_1.RowCount - 1; i++)
            {
                if (MPCF.ToInt(((FarPoint.Win.Spread.CellType.CheckBoxCellType) with_1.Cells[i, COL_SEQ].CellType).Caption) == iSeqNum)
                {
                    return i;
                }
            }
            
            return - 1;
        }
        
        // CheckCondition()
        //       -   Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : create/update/delete Function name
        private bool CheckCondition()
        {
            int i;
            int iCount;

            try
            {
                if (MPCF.CheckValue(txtLotID, 1) == false)
                {
                    return false;
                }

                FarPoint.Win.Spread.SheetView with_1 = spdBomMatList.Sheets[0];
                if (with_1.RowCount < 1)
                {
                    return false;
                }

                iCount = 0;
                for (i = 0; i <= with_1.RowCount - 1; i++)
                {
                    if (with_1.Cells[i, COL_SEQ].Value != null)
                    {
                        if (Convert.ToBoolean(with_1.Cells[i, COL_SEQ].Value) == true && (MPCF.Trim(with_1.Cells[i, COL_ALREADY_ASSEMBLED].Value) != "Y"))
                        {

                            if (MPCF.Trim(with_1.Cells[i, COL_SERIAL_IN_FLAG].Value) == "Y")
                            {
                                if (MPCF.Trim(with_1.Cells[i, COL_SERIAL_ID].Value) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(107));
                                    tabTran.SelectedTab = tbpGeneral;
                                    with_1.SetActiveCell(i, COL_SERIAL_ID);
                                    with_1.Cells[i, COL_SEQ].Value = true;

                                    FarPoint.Win.Spread.EditorNotifyEventArgs ea = new FarPoint.Win.Spread.EditorNotifyEventArgs(null, null, i, COL_SEQ);
                                    spdBomMatList_ButtonClicked(null, ea);
                                    txtMatSerial.Focus();
                                    return false;
                                }
                            }

                            if (MPCF.Trim(with_1.Cells[i, COL_ATTACH_QTY].Value) == "" || MPCF.ToDbl(with_1.Cells[i, COL_ATTACH_QTY].Value) < 0.00005)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                                tabTran.SelectedTab = tbpGeneral;
                                with_1.SetActiveCell(i, COL_ATTACH_QTY);
                                with_1.Cells[i, COL_SEQ].Value = true;

                                FarPoint.Win.Spread.EditorNotifyEventArgs ea = new FarPoint.Win.Spread.EditorNotifyEventArgs(null, null, i, COL_SEQ);
                                spdBomMatList_ButtonClicked(null, ea);
                                txtMatQty.Focus();
                                return false;
                            }

                            iCount++;

                        }
                    }
                }

                if (iCount == 0)
                {
                    return false;
                }

                if (CheckCMFItemValue() == false)
                {
                    tabTran.SelectedTab = tbpCMF;
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
        
        // Assembly_Lot()
        //       -   Assembly_Lot transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool Assembly_Lot()
        {
            TRSNode in_node = new TRSNode("ASSEMBLY_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode mat_item;
            TRSNode serial_item;

            int i;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddString("OPER", LOT.GetString("OPER"));

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }

                in_node.AddString("CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("CMF_10", MPCF.Trim(cdvCMF10.Text));
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

                in_node.AddString("BOM_SET_ID", MPCF.Trim(txtBomSetID.Text));
                in_node.AddInt("BOM_SET_VERSION", MPCF.ToInt(txtBomSetVersion.Text));

                FarPoint.Win.Spread.SheetView matList = spdBomMatList.Sheets[0];
                for (i = 0; i < matList.RowCount; i++)
                {
                    if (matList.Cells[i, COL_SEQ].Value != null)
                    {
                        if (Convert.ToBoolean(matList.Cells[i, COL_SEQ].Value) == true && (MPCF.Trim(matList.Cells[i, COL_ALREADY_ASSEMBLED].Value) != "Y"))
                        {
                            mat_item = in_node.AddNode("MAT_LIST");
                            mat_item.AddInt("SEQ_NUM", MPCF.ToInt(((FarPoint.Win.Spread.CellType.CheckBoxCellType)matList.Cells[i, COL_SEQ].CellType).Caption));

                            serial_item = mat_item.AddNode("SERIAL_LIST");
                            serial_item.AddInt("SERIAL_SEQ_NUM", 1);
                            serial_item.AddString("PART_GRP", MPCF.Trim(matList.Cells[i, COL_PART_GRP].Value));
                            serial_item.AddChar("ALT_MAT_FLAG", MPCF.ToChar(MPCF.Trim(matList.Cells[i, COL_ALT_MAT_FLAG].Value)));
                            serial_item.AddString("MAT_ID", MPCF.Trim(matList.Cells[i, COL_MAT_ID].Value));
                            serial_item.AddInt("MAT_VER", MPCF.ToInt(matList.Cells[i, COL_MAT_VER].Value));
                            serial_item.AddDouble("MAT_QTY", MPCF.ToDbl(MPCF.Trim(matList.Cells[i, COL_MAT_QTY].Value)));
                            serial_item.AddString("MAT_UNIT", MPCF.Trim(matList.Cells[i, COL_MAT_UNIT].Value));
                            serial_item.AddDouble("MAT_ATT_QTY", MPCF.ToDbl(MPCF.Trim(matList.Cells[i, COL_ATTACH_QTY].Value)));
                            serial_item.AddString("SERIAL_ID", MPCF.Trim(matList.Cells[i, COL_SERIAL_ID].Value));
                            serial_item.AddChar("SERIAL_TYPE", MPCF.ToChar(MPCF.Trim(matList.Cells[i, COL_SERIAL_TYPE].Value)));
                        }
                    }
                }

                if (MPCR.CallService("BOM", "BOM_Assembly_Lot", in_node, ref out_node) == false)
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
        
        private void frmBOMTranAssembly_Activated(object sender, System.EventArgs e)
        {
            int i;
            
            if (b_load_flag == false)
            {
                ClearData(0);
                for (i = COL_ALT_MAT_FLAG; i <= COL_ALREADY_ASSEMBLED; i++)
                {
                    spdBomMatList.Sheets[0].Columns[i].Visible = false;
                }
                
                SetCMFItem(MPGC.MP_CMF_TRN_ASSEMBLY);
                
                if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                {
                    txtLotID.Text = MPGV.gsCurrentLot_ID;
                    ViewLotInfo(txtLotID.Text);
                }
                txtLotID.Focus();
                
                b_load_flag = true;
            }
        }
        
        private void txtLotID_TextChanged(object sender, System.EventArgs e)
        {
            if (txtLotID.Text == "")
            {
                ClearData(0);
            }
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition() == false) return;
            if (Assembly_Lot() == false) return;

            ViewLotInfo(txtLotID.Text);
        }
        
        private void spdBomMatList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column != COL_SEQ)
            {
                return;
            }
            if (e.Row < 0)
            {
                return;
            }
            
            FarPoint.Win.Spread.SheetView with_1 = spdBomMatList.Sheets[0];
            if (with_1.Cells[e.Row, COL_SEQ].Value != null && Convert.ToBoolean(with_1.Cells[e.Row, COL_SEQ].Value) == true)
            {
                if (MPCF.Trim(with_1.Cells[e.Row, COL_SERIAL_IN_FLAG].Value) == "Y")
                {
                    txtMatSerial.ReadOnly = false;
                    txtMatSerial.SelectAll();
                }
                else
                {
                    txtMatSerial.ReadOnly = true;
                    txtMatSerial.Text = "";
                }
                
                txtMatQty.ReadOnly = false;
                txtMatQty.Text =  MPCF.Trim(with_1.Cells[e.Row, COL_MAT_QTY].Value);
                
                txtMatSerial.Focus();
            }
            else
            {
                txtMatSerial.Text = "";
                txtMatQty.Text = "";
                txtMatSerial.ReadOnly = true;
                txtMatQty.ReadOnly = true;

                if (MPCF.Trim(with_1.Cells[e.Row, COL_SERIAL_IN_FLAG].Value) == "Y")
                {
                    with_1.Cells[e.Row, COL_SERIAL_ID].Value = "";
                }
                with_1.Cells[e.Row, COL_ATTACH_QTY].Value = "";
            }
            
        }
        
        private void spdBomMatList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.RowHeader == true)
            {
                return;
            }
            if (e.ColumnHeader == true)
            {
                return;
            }
            
            if (e.Column != COL_SEQ)
            {
                return;
            }
            if (e.Row < 0)
            {
                return;
            }
            
            if (spdBomMatList.Sheets[0].Cells[e.Row, COL_SEQ].Locked == false)
            {
                return;
            }
            
            txtMatSerial.Text = "";
            txtMatQty.Text = "";
            txtMatSerial.ReadOnly = true;
            txtMatQty.ReadOnly = true;
            
        }
        
        private void txtMatSerial_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (txtMatSerial.Text != "")
            {
                if (e.KeyChar == (char)13)
                {
                    FarPoint.Win.Spread.SheetView with_1 = spdBomMatList.Sheets[0];
                    with_1.Cells[with_1.ActiveRowIndex, COL_SERIAL_ID].Value = txtMatSerial.Text;
                }
            }
        }
        
        private void txtMatSerial_LostFocus(object sender, System.EventArgs e)
        {
            KeyPressEventArgs ea = new KeyPressEventArgs((char)13);
            txtMatSerial_KeyPress(sender, ea);
            txtMatQty.Focus();
        }
        
        private void txtMatQty_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (txtMatQty.Text != "")
            {
                if (MPCF.CheckNumeric(txtMatQty.Text) == false)
                {
                    txtMatQty.Text = "";
                    return;
                }
                if (e.KeyChar == (char)13)
                {
                    FarPoint.Win.Spread.SheetView with_1 = spdBomMatList.Sheets[0];
                    with_1.Cells[with_1.ActiveRowIndex, COL_ATTACH_QTY].Value = MPCF.Format("#####,##0.###", MPCF.ToDbl(txtMatQty.Text));
                }
            }
        }
        
        private void txtMatQty_LostFocus(object sender, System.EventArgs e)
        {
            KeyPressEventArgs ea = new KeyPressEventArgs((char)13);
            txtMatQty_KeyPress(sender, ea);
        }
    }
    //#End If ' _BOM
}
