
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using FarPoint.Win.Spread;
using Miracom.UI.Controls;
using Miracom.CliFrx;

using Miracom.TRSCore;
//'#If _BOM = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBOMViewLotStatusForAssembly.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -  CheckCondition() : Check the conditions before transaction
//       -  View_BOMSet_Version_List() : View BOM Set Version
//       -  View_Attach_Material_List() : View Material List by BOM Set
//       -  Update_Attach_Material() : Create/Update/Delete Material
//       -  Update_BOMSet_Version() : Approval & Release Update
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-07-21 : Created by WKIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.BOMCore
{
    public class frmBOMViewLotStatusForAssembly : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmBOMViewLotStatusForAssembly()
        {
            
            
            InitializeComponent();
            
            
            this.spdLotInfo.Tag = "Change Cell";
            
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
        



        private System.Windows.Forms.Panel pnlLot;
        private System.Windows.Forms.GroupBox grpLot;
        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.Panel pnlLotStatus;
        private System.Windows.Forms.TabControl tabLotStatus;
        private System.Windows.Forms.TabPage tbpGeneral;
        protected System.Windows.Forms.Panel pnlGeneralTop;
        protected System.Windows.Forms.GroupBox grpLotInfo;
        protected System.Windows.Forms.Panel pnlLotInfoMain;
        private System.Windows.Forms.Panel pnlAssemblyStatus;
        private System.Windows.Forms.GroupBox grpLotAssyInfo;
        private FarPoint.Win.Spread.FpSpread spdLotAssyInfo;
        private FarPoint.Win.Spread.SheetView spdLotAssyInfo_Sheet1;
        private FpSpread spdLotInfo;
        private SheetView spdLotInfo_Sheet1;
        private Button btnHistory;
        private System.Windows.Forms.TextBox txtLotDesc;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder2 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder3 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder1 = new FarPoint.Win.CompoundBorder(bevelBorder2, bevelBorder3);
            FarPoint.Win.BevelBorder bevelBorder4 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder5 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder2 = new FarPoint.Win.CompoundBorder(bevelBorder4, bevelBorder5);
            FarPoint.Win.BevelBorder bevelBorder6 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder7 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder3 = new FarPoint.Win.CompoundBorder(bevelBorder6, bevelBorder7);
            this.pnlLot = new System.Windows.Forms.Panel();
            this.grpLot = new System.Windows.Forms.GroupBox();
            this.txtLotDesc = new System.Windows.Forms.TextBox();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblLotID = new System.Windows.Forms.Label();
            this.pnlLotStatus = new System.Windows.Forms.Panel();
            this.tabLotStatus = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.pnlAssemblyStatus = new System.Windows.Forms.Panel();
            this.grpLotAssyInfo = new System.Windows.Forms.GroupBox();
            this.spdLotAssyInfo = new FarPoint.Win.Spread.FpSpread();
            this.spdLotAssyInfo_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlGeneralTop = new System.Windows.Forms.Panel();
            this.grpLotInfo = new System.Windows.Forms.GroupBox();
            this.pnlLotInfoMain = new System.Windows.Forms.Panel();
            this.spdLotInfo = new FarPoint.Win.Spread.FpSpread();
            this.spdLotInfo_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnHistory = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlLot.SuspendLayout();
            this.grpLot.SuspendLayout();
            this.pnlLotStatus.SuspendLayout();
            this.tabLotStatus.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlAssemblyStatus.SuspendLayout();
            this.grpLotAssyInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotAssyInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotAssyInfo_Sheet1)).BeginInit();
            this.pnlGeneralTop.SuspendLayout();
            this.grpLotInfo.SuspendLayout();
            this.pnlLotInfoMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(461, 7);
            this.btnProcess.Text = "View";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnHistory);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 0;
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnHistory, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlLotStatus);
            this.pnlCenter.Controls.Add(this.pnlLot);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Lot Assembly Status";
            // 
            // pnlLot
            // 
            this.pnlLot.Controls.Add(this.grpLot);
            this.pnlLot.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLot.Location = new System.Drawing.Point(0, 0);
            this.pnlLot.Name = "pnlLot";
            this.pnlLot.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlLot.Size = new System.Drawing.Size(742, 71);
            this.pnlLot.TabIndex = 0;
            // 
            // grpLot
            // 
            this.grpLot.Controls.Add(this.txtLotDesc);
            this.grpLot.Controls.Add(this.txtLotID);
            this.grpLot.Controls.Add(this.lblDesc);
            this.grpLot.Controls.Add(this.lblLotID);
            this.grpLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLot.Location = new System.Drawing.Point(3, 0);
            this.grpLot.Name = "grpLot";
            this.grpLot.Size = new System.Drawing.Size(736, 71);
            this.grpLot.TabIndex = 0;
            this.grpLot.TabStop = false;
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLotDesc.Location = new System.Drawing.Point(120, 40);
            this.txtLotDesc.MaxLength = 200;
            this.txtLotDesc.Name = "txtLotDesc";
            this.txtLotDesc.ReadOnly = true;
            this.txtLotDesc.Size = new System.Drawing.Size(604, 20);
            this.txtLotDesc.TabIndex = 3;
            this.txtLotDesc.TabStop = false;
            // 
            // txtLotID
            // 
            this.txtLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLotID.Location = new System.Drawing.Point(120, 16);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(200, 20);
            this.txtLotID.TabIndex = 1;
            this.txtLotID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotID_KeyPress);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(15, 43);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(15, 19);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            this.lblLotID.TabIndex = 0;
            this.lblLotID.Text = "Lot ID";
            // 
            // pnlLotStatus
            // 
            this.pnlLotStatus.Controls.Add(this.tabLotStatus);
            this.pnlLotStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLotStatus.Location = new System.Drawing.Point(0, 71);
            this.pnlLotStatus.Name = "pnlLotStatus";
            this.pnlLotStatus.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.pnlLotStatus.Size = new System.Drawing.Size(742, 442);
            this.pnlLotStatus.TabIndex = 1;
            // 
            // tabLotStatus
            // 
            this.tabLotStatus.Controls.Add(this.tbpGeneral);
            this.tabLotStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabLotStatus.ItemSize = new System.Drawing.Size(60, 18);
            this.tabLotStatus.Location = new System.Drawing.Point(3, 5);
            this.tabLotStatus.Name = "tabLotStatus";
            this.tabLotStatus.SelectedIndex = 0;
            this.tabLotStatus.Size = new System.Drawing.Size(736, 437);
            this.tabLotStatus.TabIndex = 0;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.pnlAssemblyStatus);
            this.tbpGeneral.Controls.Add(this.pnlGeneralTop);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Size = new System.Drawing.Size(728, 411);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // pnlAssemblyStatus
            // 
            this.pnlAssemblyStatus.Controls.Add(this.grpLotAssyInfo);
            this.pnlAssemblyStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAssemblyStatus.Location = new System.Drawing.Point(0, 144);
            this.pnlAssemblyStatus.Name = "pnlAssemblyStatus";
            this.pnlAssemblyStatus.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlAssemblyStatus.Size = new System.Drawing.Size(728, 267);
            this.pnlAssemblyStatus.TabIndex = 1;
            // 
            // grpLotAssyInfo
            // 
            this.grpLotAssyInfo.Controls.Add(this.spdLotAssyInfo);
            this.grpLotAssyInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLotAssyInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLotAssyInfo.Location = new System.Drawing.Point(3, 5);
            this.grpLotAssyInfo.Name = "grpLotAssyInfo";
            this.grpLotAssyInfo.Size = new System.Drawing.Size(722, 259);
            this.grpLotAssyInfo.TabIndex = 0;
            this.grpLotAssyInfo.TabStop = false;
            this.grpLotAssyInfo.Text = "Lot Assembly Information";
            // 
            // spdLotAssyInfo
            // 
            this.spdLotAssyInfo.AccessibleDescription = "spdLotAssyInfo, Sheet1, Row 0, Column 0, ";
            this.spdLotAssyInfo.BackColor = System.Drawing.SystemColors.Control;
            this.spdLotAssyInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdLotAssyInfo.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdLotAssyInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdLotAssyInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotAssyInfo.HorizontalScrollBar.Name = "";
            this.spdLotAssyInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdLotAssyInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdLotAssyInfo.Location = new System.Drawing.Point(3, 16);
            this.spdLotAssyInfo.Name = "spdLotAssyInfo";
            this.spdLotAssyInfo.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdLotAssyInfo.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdLotAssyInfo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdLotAssyInfo_Sheet1});
            this.spdLotAssyInfo.Size = new System.Drawing.Size(716, 240);
            this.spdLotAssyInfo.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdLotAssyInfo.TabIndex = 0;
            this.spdLotAssyInfo.TabStop = false;
            this.spdLotAssyInfo.TextTipDelay = 200;
            this.spdLotAssyInfo.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdLotAssyInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotAssyInfo.VerticalScrollBar.Name = "";
            this.spdLotAssyInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdLotAssyInfo.VerticalScrollBar.TabIndex = 3;
            this.spdLotAssyInfo.SetViewportLeftColumn(0, 0, 3);
            this.spdLotAssyInfo.SetActiveViewport(0, 0, -1);
            // 
            // spdLotAssyInfo_Sheet1
            // 
            this.spdLotAssyInfo_Sheet1.Reset();
            spdLotAssyInfo_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdLotAssyInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdLotAssyInfo_Sheet1.ColumnCount = 19;
            spdLotAssyInfo_Sheet1.RowCount = 5;
            spdLotAssyInfo_Sheet1.RowHeader.ColumnCount = 0;
            this.spdLotAssyInfo_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdLotAssyInfo_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotAssyInfo_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotAssyInfo_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotAssyInfo_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdLotAssyInfo_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdLotAssyInfo_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Serial Seq";
            this.spdLotAssyInfo_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "BOM Set ID";
            this.spdLotAssyInfo_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "BOM Set Version";
            this.spdLotAssyInfo_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Part Grp";
            this.spdLotAssyInfo_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Alt Mat Flag";
            this.spdLotAssyInfo_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Mat ID";
            this.spdLotAssyInfo_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Version";
            this.spdLotAssyInfo_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Mat Qty";
            this.spdLotAssyInfo_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Mat Unit";
            this.spdLotAssyInfo_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Mat Att Qty";
            this.spdLotAssyInfo_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Serial ID";
            this.spdLotAssyInfo_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Serial Type";
            this.spdLotAssyInfo_Sheet1.ColumnHeader.Cells.Get(0, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.spdLotAssyInfo_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Flow";
            this.spdLotAssyInfo_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Oper";
            this.spdLotAssyInfo_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Create User ID";
            this.spdLotAssyInfo_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Create Time";
            this.spdLotAssyInfo_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Update User ID";
            this.spdLotAssyInfo_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Update Time";
            this.spdLotAssyInfo_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotAssyInfo_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotAssyInfo_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdLotAssyInfo_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdLotAssyInfo_Sheet1.Columns.Get(0).Border = bevelBorder1;
            this.spdLotAssyInfo_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdLotAssyInfo_Sheet1.Columns.Get(0).ForeColor = System.Drawing.Color.Black;
            this.spdLotAssyInfo_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotAssyInfo_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdLotAssyInfo_Sheet1.Columns.Get(0).Locked = true;
            this.spdLotAssyInfo_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdLotAssyInfo_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotAssyInfo_Sheet1.Columns.Get(0).Width = 55F;
            this.spdLotAssyInfo_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotAssyInfo_Sheet1.Columns.Get(1).Label = "Serial Seq";
            this.spdLotAssyInfo_Sheet1.Columns.Get(1).Locked = true;
            this.spdLotAssyInfo_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotAssyInfo_Sheet1.Columns.Get(1).Width = 71F;
            this.spdLotAssyInfo_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotAssyInfo_Sheet1.Columns.Get(2).Label = "BOM Set ID";
            this.spdLotAssyInfo_Sheet1.Columns.Get(2).Locked = true;
            this.spdLotAssyInfo_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotAssyInfo_Sheet1.Columns.Get(2).Width = 125F;
            this.spdLotAssyInfo_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotAssyInfo_Sheet1.Columns.Get(3).Label = "BOM Set Version";
            this.spdLotAssyInfo_Sheet1.Columns.Get(3).Locked = true;
            this.spdLotAssyInfo_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotAssyInfo_Sheet1.Columns.Get(3).Width = 111F;
            this.spdLotAssyInfo_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotAssyInfo_Sheet1.Columns.Get(4).Label = "Part Grp";
            this.spdLotAssyInfo_Sheet1.Columns.Get(4).Locked = true;
            this.spdLotAssyInfo_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotAssyInfo_Sheet1.Columns.Get(4).Width = 92F;
            this.spdLotAssyInfo_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotAssyInfo_Sheet1.Columns.Get(5).Label = "Alt Mat Flag";
            this.spdLotAssyInfo_Sheet1.Columns.Get(5).Locked = true;
            this.spdLotAssyInfo_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotAssyInfo_Sheet1.Columns.Get(5).Width = 81F;
            this.spdLotAssyInfo_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotAssyInfo_Sheet1.Columns.Get(6).Label = "Mat ID";
            this.spdLotAssyInfo_Sheet1.Columns.Get(6).Locked = true;
            this.spdLotAssyInfo_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotAssyInfo_Sheet1.Columns.Get(6).Width = 109F;
            this.spdLotAssyInfo_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotAssyInfo_Sheet1.Columns.Get(7).Label = "Version";
            this.spdLotAssyInfo_Sheet1.Columns.Get(7).Locked = true;
            this.spdLotAssyInfo_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotAssyInfo_Sheet1.Columns.Get(7).Width = 45F;
            this.spdLotAssyInfo_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotAssyInfo_Sheet1.Columns.Get(8).Label = "Mat Qty";
            this.spdLotAssyInfo_Sheet1.Columns.Get(8).Locked = true;
            this.spdLotAssyInfo_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotAssyInfo_Sheet1.Columns.Get(8).Width = 71F;
            this.spdLotAssyInfo_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotAssyInfo_Sheet1.Columns.Get(9).Label = "Mat Unit";
            this.spdLotAssyInfo_Sheet1.Columns.Get(9).Locked = true;
            this.spdLotAssyInfo_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotAssyInfo_Sheet1.Columns.Get(9).Width = 68F;
            this.spdLotAssyInfo_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotAssyInfo_Sheet1.Columns.Get(10).Label = "Mat Att Qty";
            this.spdLotAssyInfo_Sheet1.Columns.Get(10).Locked = true;
            this.spdLotAssyInfo_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotAssyInfo_Sheet1.Columns.Get(10).Width = 76F;
            this.spdLotAssyInfo_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotAssyInfo_Sheet1.Columns.Get(11).Label = "Serial ID";
            this.spdLotAssyInfo_Sheet1.Columns.Get(11).Locked = true;
            this.spdLotAssyInfo_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotAssyInfo_Sheet1.Columns.Get(11).Width = 104F;
            this.spdLotAssyInfo_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotAssyInfo_Sheet1.Columns.Get(12).Label = "Serial Type";
            this.spdLotAssyInfo_Sheet1.Columns.Get(12).Locked = true;
            this.spdLotAssyInfo_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotAssyInfo_Sheet1.Columns.Get(12).Width = 86F;
            this.spdLotAssyInfo_Sheet1.Columns.Get(13).Label = "Flow";
            this.spdLotAssyInfo_Sheet1.Columns.Get(13).Width = 105F;
            this.spdLotAssyInfo_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotAssyInfo_Sheet1.Columns.Get(14).Label = "Oper";
            this.spdLotAssyInfo_Sheet1.Columns.Get(14).Locked = true;
            this.spdLotAssyInfo_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotAssyInfo_Sheet1.Columns.Get(14).Width = 62F;
            this.spdLotAssyInfo_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotAssyInfo_Sheet1.Columns.Get(15).Label = "Create User ID";
            this.spdLotAssyInfo_Sheet1.Columns.Get(15).Locked = true;
            this.spdLotAssyInfo_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotAssyInfo_Sheet1.Columns.Get(15).Width = 97F;
            this.spdLotAssyInfo_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotAssyInfo_Sheet1.Columns.Get(16).Label = "Create Time";
            this.spdLotAssyInfo_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotAssyInfo_Sheet1.Columns.Get(16).Width = 119F;
            this.spdLotAssyInfo_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotAssyInfo_Sheet1.Columns.Get(17).Label = "Update User ID";
            this.spdLotAssyInfo_Sheet1.Columns.Get(17).Locked = true;
            this.spdLotAssyInfo_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotAssyInfo_Sheet1.Columns.Get(17).Width = 97F;
            this.spdLotAssyInfo_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotAssyInfo_Sheet1.Columns.Get(18).Label = "Update Time";
            this.spdLotAssyInfo_Sheet1.Columns.Get(18).Locked = true;
            this.spdLotAssyInfo_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotAssyInfo_Sheet1.Columns.Get(18).Width = 119F;
            this.spdLotAssyInfo_Sheet1.FrozenColumnCount = 3;
            this.spdLotAssyInfo_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdLotAssyInfo_Sheet1.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.spdLotAssyInfo_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdLotAssyInfo_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotAssyInfo_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdLotAssyInfo_Sheet1.Rows.Get(0).Height = 18F;
            this.spdLotAssyInfo_Sheet1.Rows.Get(1).Height = 18F;
            this.spdLotAssyInfo_Sheet1.Rows.Get(2).Height = 18F;
            this.spdLotAssyInfo_Sheet1.Rows.Get(3).Height = 18F;
            this.spdLotAssyInfo_Sheet1.Rows.Get(4).Height = 18F;
            this.spdLotAssyInfo_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotAssyInfo_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdLotAssyInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlGeneralTop
            // 
            this.pnlGeneralTop.Controls.Add(this.grpLotInfo);
            this.pnlGeneralTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGeneralTop.Location = new System.Drawing.Point(0, 0);
            this.pnlGeneralTop.Name = "pnlGeneralTop";
            this.pnlGeneralTop.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.pnlGeneralTop.Size = new System.Drawing.Size(728, 144);
            this.pnlGeneralTop.TabIndex = 0;
            // 
            // grpLotInfo
            // 
            this.grpLotInfo.Controls.Add(this.pnlLotInfoMain);
            this.grpLotInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLotInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLotInfo.Location = new System.Drawing.Point(3, 5);
            this.grpLotInfo.Name = "grpLotInfo";
            this.grpLotInfo.Size = new System.Drawing.Size(722, 139);
            this.grpLotInfo.TabIndex = 0;
            this.grpLotInfo.TabStop = false;
            this.grpLotInfo.Text = "Lot Information";
            // 
            // pnlLotInfoMain
            // 
            this.pnlLotInfoMain.Controls.Add(this.spdLotInfo);
            this.pnlLotInfoMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLotInfoMain.Location = new System.Drawing.Point(3, 16);
            this.pnlLotInfoMain.Name = "pnlLotInfoMain";
            this.pnlLotInfoMain.Padding = new System.Windows.Forms.Padding(1);
            this.pnlLotInfoMain.Size = new System.Drawing.Size(716, 120);
            this.pnlLotInfoMain.TabIndex = 0;
            // 
            // spdLotInfo
            // 
            this.spdLotInfo.AccessibleDescription = "spdLotInfo, LotInfo, Row 0, Column 0, ";
            this.spdLotInfo.BackColor = System.Drawing.SystemColors.Control;
            this.spdLotInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdLotInfo.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdLotInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.HorizontalScrollBar.Name = "";
            this.spdLotInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdLotInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdLotInfo.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdLotInfo.Location = new System.Drawing.Point(1, 1);
            this.spdLotInfo.MoveActiveOnFocus = false;
            this.spdLotInfo.Name = "spdLotInfo";
            this.spdLotInfo.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdLotInfo.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdLotInfo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdLotInfo_Sheet1});
            this.spdLotInfo.Size = new System.Drawing.Size(714, 118);
            this.spdLotInfo.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdLotInfo.TabIndex = 0;
            this.spdLotInfo.TabStop = false;
            this.spdLotInfo.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.spdLotInfo.TextTipAppearance = tipAppearance1;
            this.spdLotInfo.TextTipDelay = 200;
            this.spdLotInfo.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdLotInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.VerticalScrollBar.Name = "";
            this.spdLotInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdLotInfo.VerticalScrollBar.TabIndex = 3;
            // 
            // spdLotInfo_Sheet1
            // 
            this.spdLotInfo_Sheet1.Reset();
            spdLotInfo_Sheet1.SheetName = "LotInfo";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdLotInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdLotInfo_Sheet1.ColumnCount = 6;
            spdLotInfo_Sheet1.RowCount = 19;
            this.spdLotInfo_Sheet1.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdLotInfo_Sheet1.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(0, 0).Value = "Lot ID";
            this.spdLotInfo_Sheet1.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(0, 2).Value = "Material";
            this.spdLotInfo_Sheet1.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(0, 4).Value = "Flow";
            this.spdLotInfo_Sheet1.Cells.Get(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(1, 0).Value = "Operation";
            this.spdLotInfo_Sheet1.Cells.Get(1, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(1, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(1, 2).Value = "Qty 1/2/3";
            this.spdLotInfo_Sheet1.Cells.Get(1, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(1, 4).Value = "Lot Type";
            this.spdLotInfo_Sheet1.Cells.Get(2, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(2, 0).Value = "Create Code";
            this.spdLotInfo_Sheet1.Cells.Get(2, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(2, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(2, 2).Value = "Owner Code";
            this.spdLotInfo_Sheet1.Cells.Get(2, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(2, 4).Value = "Due Date";
            this.spdLotInfo_Sheet1.Cells.Get(3, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(3, 0).Value = "Lot Status";
            this.spdLotInfo_Sheet1.Cells.Get(3, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(3, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(3, 2).Value = "Lot Priority";
            this.spdLotInfo_Sheet1.Cells.Get(3, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(3, 4).Value = "Hold Flag/Code";
            this.spdLotInfo_Sheet1.Cells.Get(4, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(4, 0).Value = "Start Flag";
            this.spdLotInfo_Sheet1.Cells.Get(4, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(4, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(4, 2).Value = "End Flag";
            this.spdLotInfo_Sheet1.Cells.Get(4, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(4, 4).Value = "Rework Flag/Code";
            this.spdLotInfo_Sheet1.Cells.Get(5, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(5, 0).Value = "Transit Flag";
            this.spdLotInfo_Sheet1.Cells.Get(5, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(5, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(5, 2).Value = "Inventory Flag";
            this.spdLotInfo_Sheet1.Cells.Get(5, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(5, 4).Value = "Non Standard Flag";
            this.spdLotInfo_Sheet1.Cells.Get(6, 0).Value = "Last Tran Code";
            this.spdLotInfo_Sheet1.Cells.Get(6, 2).Value = "Last Tran Time";
            this.spdLotInfo_Sheet1.Cells.Get(6, 4).Value = "Last Hist Seq";
            this.spdLotInfo_Sheet1.Cells.Get(7, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(7, 0).Value = "Ship Code";
            this.spdLotInfo_Sheet1.Cells.Get(7, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(7, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(7, 2).Value = "Ship Time";
            this.spdLotInfo_Sheet1.Cells.Get(7, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(7, 4).Value = "Sample Flag";
            this.spdLotInfo_Sheet1.Cells.Get(8, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(8, 0).Value = "Oper In Qty 1/2/3";
            this.spdLotInfo_Sheet1.Cells.Get(8, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(8, 2).Value = "Create Qty 1/2/3";
            this.spdLotInfo_Sheet1.Cells.Get(8, 4).Value = "Start Time";
            this.spdLotInfo_Sheet1.Cells.Get(9, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(9, 0).Value = "Start Res ID";
            this.spdLotInfo_Sheet1.Cells.Get(9, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(9, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(9, 2).Value = "End Time";
            this.spdLotInfo_Sheet1.Cells.Get(9, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(9, 4).Value = "End Res ID";
            this.spdLotInfo_Sheet1.Cells.Get(10, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(10, 0).Value = "Rework Ret Flow";
            this.spdLotInfo_Sheet1.Cells.Get(10, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(10, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(10, 2).Value = "Rework Ret Oper";
            this.spdLotInfo_Sheet1.Cells.Get(10, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(10, 4).Value = "Rework Count";
            this.spdLotInfo_Sheet1.Cells.Get(11, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(11, 0).Value = "Rework End Flow";
            this.spdLotInfo_Sheet1.Cells.Get(11, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(11, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(11, 2).Value = "Rework End Oper";
            this.spdLotInfo_Sheet1.Cells.Get(11, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(11, 4).Value = "Rework Time";
            this.spdLotInfo_Sheet1.Cells.Get(12, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(12, 0).Value = "NSTD Ret Flow";
            this.spdLotInfo_Sheet1.Cells.Get(12, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(12, 2).Value = "NSTD Ret Oper";
            this.spdLotInfo_Sheet1.Cells.Get(12, 4).Value = "NSTD Time";
            this.spdLotInfo_Sheet1.Cells.Get(13, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(13, 0).Value = "Order ID";
            this.spdLotInfo_Sheet1.Cells.Get(13, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(13, 2).Value = "Lot Location";
            this.spdLotInfo_Sheet1.Cells.Get(13, 4).Value = "Batch ID";
            this.spdLotInfo_Sheet1.Cells.Get(14, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(14, 0).Value = "Create Time";
            this.spdLotInfo_Sheet1.Cells.Get(14, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(14, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(14, 2).Value = "Factory In Time";
            this.spdLotInfo_Sheet1.Cells.Get(14, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(14, 4).Value = "Flow In Time";
            this.spdLotInfo_Sheet1.Cells.Get(15, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(15, 0).Value = "Oper In Time";
            this.spdLotInfo_Sheet1.Cells.Get(15, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(15, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(15, 2).Value = "From To Lot ID";
            this.spdLotInfo_Sheet1.Cells.Get(15, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(15, 4).Value = "Reserve Res ID";
            this.spdLotInfo_Sheet1.Cells.Get(16, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(16, 0).Value = "BOM Set ID";
            this.spdLotInfo_Sheet1.Cells.Get(16, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(16, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(16, 2).Value = "BOM Set Version";
            this.spdLotInfo_Sheet1.Cells.Get(16, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(16, 4).Value = "BOM Act Hist Seq";
            this.spdLotInfo_Sheet1.Cells.Get(17, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(17, 0).Value = "Lot Del Flag";
            this.spdLotInfo_Sheet1.Cells.Get(17, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(17, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(17, 2).Value = "Lot Del Time";
            this.spdLotInfo_Sheet1.Cells.Get(17, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(17, 4).Value = "Lot Del Code";
            this.spdLotInfo_Sheet1.Cells.Get(18, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(18, 0).Value = "Start Qty 1/2/3";
            this.spdLotInfo_Sheet1.Cells.Get(18, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(18, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(18, 2).Value = "Carrier ID";
            this.spdLotInfo_Sheet1.Cells.Get(18, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(18, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(18, 4).Value = "Last Active Hist Seq";
            this.spdLotInfo_Sheet1.Cells.Get(18, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotInfo_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotInfo_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotInfo_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdLotInfo_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotInfo_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotInfo_Sheet1.ColumnHeader.Visible = false;
            this.spdLotInfo_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdLotInfo_Sheet1.Columns.Get(0).Border = compoundBorder1;
            this.spdLotInfo_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdLotInfo_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(0).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(0).Width = 105F;
            this.spdLotInfo_Sheet1.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdLotInfo_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(1).Locked = false;
            this.spdLotInfo_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(1).Width = 126F;
            this.spdLotInfo_Sheet1.Columns.Get(2).BackColor = System.Drawing.SystemColors.Control;
            this.spdLotInfo_Sheet1.Columns.Get(2).Border = compoundBorder2;
            this.spdLotInfo_Sheet1.Columns.Get(2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdLotInfo_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(2).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(2).Width = 105F;
            this.spdLotInfo_Sheet1.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdLotInfo_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(3).Locked = false;
            this.spdLotInfo_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(3).Width = 126F;
            this.spdLotInfo_Sheet1.Columns.Get(4).BackColor = System.Drawing.SystemColors.Control;
            this.spdLotInfo_Sheet1.Columns.Get(4).Border = compoundBorder3;
            this.spdLotInfo_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(4).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(4).Width = 105F;
            this.spdLotInfo_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(5).Locked = false;
            this.spdLotInfo_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(5).Width = 126F;
            this.spdLotInfo_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdLotInfo_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.spdLotInfo_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdLotInfo_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotInfo_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdLotInfo_Sheet1.RowHeader.Visible = false;
            this.spdLotInfo_Sheet1.Rows.Get(0).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(1).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(2).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(3).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(4).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(5).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(6).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(7).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(8).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(9).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(10).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(11).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(12).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(13).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(14).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(15).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(16).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(17).Height = 17F;
            this.spdLotInfo_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotInfo_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistory.Location = new System.Drawing.Point(555, 7);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(88, 26);
            this.btnHistory.TabIndex = 1;
            this.btnHistory.Text = "History";
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // frmBOMViewLotStatusForAssembly
            // 
            this.AcceptButton = this.btnProcess;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmBOMViewLotStatusForAssembly";
            this.Text = "View Lot Status For Assembly";
            this.Activated += new System.EventHandler(this.frmBOMViewLotStatusForAssembly_Activated);
            this.Load += new System.EventHandler(this.frmBOMViewLotStatusForAssembly_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlLot.ResumeLayout(false);
            this.grpLot.ResumeLayout(false);
            this.grpLot.PerformLayout();
            this.pnlLotStatus.ResumeLayout(false);
            this.tabLotStatus.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlAssemblyStatus.ResumeLayout(false);
            this.grpLotAssyInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdLotAssyInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotAssyInfo_Sheet1)).EndInit();
            this.pnlGeneralTop.ResumeLayout(false);
            this.grpLotInfo.ResumeLayout(false);
            this.pnlLotInfoMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition"
        
        bool b_load_flag;
        
        #endregion
        
        #region " Function Definition"
        
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        
        private bool CheckCondition(string FuncName)
        {
            
            try
            {
                switch (FuncName)
                {
                    case "1":
                        
                        if (txtLotID.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            txtLotID.Focus();
                            return false;
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
        // ViewLotStatusForAssembly()
        //       - View Lot Status For Assembly
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sLotID As String
        //

        private bool ViewLotStatusForAssembly(string sLotID)
        {
            int i;
            int iCol = 0;
            int iRow = 0;

            TRSNode in_node = new TRSNode("VIEW_LOT_STATUS_FOR_ASSEMBLY_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_STATUS_FOR_ASSEMBLY_OUT");

            MPCF.ClearList(spdLotAssyInfo, true);
            try
            {
                if (MPCR.SetLotInfoSpread(spdLotInfo, txtLotID.Text, ref out_node) == false)
                {
                    txtLotID.Focus();
                    return false;
                }
                txtLotDesc.Text = out_node.GetString("LOT_DESC");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", sLotID);
                in_node.AddInt("NEXT_SEQ_NUM", 0);
                in_node.AddInt("NEXT_SERIAL_SEQ_NUM", 0);

                do
                {
                    if (MPCR.CallService("BOM", "BOM_View_Lot_Status_For_Assembly", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        FarPoint.Win.Spread.SheetView with_1 = spdLotAssyInfo.Sheets[0];

                        iRow = with_1.RowCount;
                        with_1.RowCount++;

                        iCol = 0;

                        with_1.SetValue(iRow, iCol, out_node.GetList(0)[i].GetInt("SEQ_NUM"));

                        iCol++;
                        with_1.SetValue(iRow, iCol, out_node.GetList(0)[i].GetInt("SERIAL_SEQ_NUM"));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("BOM_SET_ID")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, out_node.GetList(0)[i].GetInt("BOM_SET_VERSION"));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_GRP")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetChar("ALT_MAT_FLAG")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_ID")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, out_node.GetList(0)[i].GetInt("MAT_VER"));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("MAT_QTY")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_UNIT")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("MAT_ATT_QTY")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("SERIAL_ID")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetChar("SERIAL_TYPE")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("FLOW")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("OPER")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_USER_ID")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_TIME"))));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_USER_ID")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_TIME"))));

                        iCol++;


                    }
                    in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));
                    in_node.SetInt("NEXT_SERIAL_SEQ_NUM", out_node.GetInt("NEXT_SERIAL_SEQ_NUM"));

                } while (in_node.GetInt("NEXT_SERIAL_SEQ_NUM") !=0);

                MPCF.FitColumnHeader(spdLotAssyInfo);

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
                return this.txtLotID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmBOMViewLotStatusForAssembly_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldClear(this);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmBOMViewLotStatusForAssembly_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    MPCF.FieldClear(this);
                    MPCF.ClearList(spdLotAssyInfo, true);
                    MPCF.FitColumnHeader(spdLotAssyInfo);
                    
                    if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                    {
                        txtLotID.Text = MPGV.gsCurrentLot_ID;
                        btnProcess.PerformClick();
                    }
                    
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void txtLotID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (CheckCondition("1") == true)
                    {
                        if (ViewLotStatusForAssembly(txtLotID.Text) == false)
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
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.ClearList(spdLotAssyInfo, true);
                if (CheckCondition("1") == true)
                {
                    if (ViewLotStatusForAssembly(txtLotID.Text) == false)
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
        
        private void spdLotInfo_Resize(object sender, System.EventArgs e)
        {
            int iDiffSize;
            
            try
            {
                iDiffSize = (spdLotInfo.Size.Width - 714) / 3;
                
                if (iDiffSize >= 0)
                {
                    spdLotInfo.Sheets[0].Columns[1].Width = 126 + iDiffSize;
                    spdLotInfo.Sheets[0].Columns[3].Width = 126 + iDiffSize;
                    spdLotInfo.Sheets[0].Columns[5].Width = 126 + iDiffSize;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (txtLotID.Text == "")
                return;

            MPGV.gsCurrentLot_ID = txtLotID.Text;

            try
            {
                Form f = MPCF.GetChildForm(MPGV.gfrmMDI, "frmBOMViewLotHistoryForAssembly");
                if (f != null)
                {
                    f.BringToFront();
                    f.Show();
                }
                else
                {
                    f = new frmBOMViewLotHistoryForAssembly();
                    f.MdiParent = MPGV.gfrmMDI;
                    f.BringToFront();
                    f.Show();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
    }
    //'#End If ' _BOM
}
