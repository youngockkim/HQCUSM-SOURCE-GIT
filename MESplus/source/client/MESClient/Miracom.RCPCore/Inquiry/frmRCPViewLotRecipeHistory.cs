
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

//#If _RCP = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRCPViewLotRecipeHistory.vb
//   Description : MES Cient Form View Lot Recipe History Class
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - CheckCondition() : Check the conditions before transaction
//       - InitRecipeInfo() : Initialize the Recipe Info
//       - View_Lot_Recipe_History() :View Lot Recipe History
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-07-01 : Created by HS KIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


namespace Miracom.RCPCore
{
    public class frmRCPViewLotRecipeHistory : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRCPViewLotRecipeHistory()
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
        private System.Windows.Forms.TextBox txtHistSeq;
        private System.Windows.Forms.Label lblHistSeq;
        private System.Windows.Forms.GroupBox grbGeneral;
        private System.Windows.Forms.GroupBox grbParameter;
        private FarPoint.Win.Spread.FpSpread spdParameter;
        private FarPoint.Win.Spread.SheetView spdParameter_Sheet1;
        protected FarPoint.Win.Spread.FpSpread spdRecipe;
        protected FarPoint.Win.Spread.SheetView spdRecipe_LotInfo;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder2 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder1 = new FarPoint.Win.CompoundBorder(bevelBorder1, bevelBorder2);
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.BevelBorder bevelBorder3 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder4 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder2 = new FarPoint.Win.CompoundBorder(bevelBorder3, bevelBorder4);
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.txtHistSeq = new System.Windows.Forms.TextBox();
            this.lblHistSeq = new System.Windows.Forms.Label();
            this.grbGeneral = new System.Windows.Forms.GroupBox();
            this.spdRecipe = new FarPoint.Win.Spread.FpSpread();
            this.spdRecipe_LotInfo = new FarPoint.Win.Spread.SheetView();
            this.grbParameter = new System.Windows.Forms.GroupBox();
            this.spdParameter = new FarPoint.Win.Spread.FpSpread();
            this.spdParameter_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grbGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdRecipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdRecipe_LotInfo)).BeginInit();
            this.grbParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdParameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdParameter_Sheet1)).BeginInit();
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
            // grpOption
            // 
            this.grpOption.Controls.Add(this.txtHistSeq);
            this.grpOption.Controls.Add(this.lblHistSeq);
            this.grpOption.Controls.Add(this.txtLotID);
            this.grpOption.Controls.Add(this.lblLotID);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.grbParameter);
            this.pnlViewMid.Controls.Add(this.grbGeneral);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 435);
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
            this.lblFormTitle.Text = "View Lot Recipe History";
            // 
            // txtLotID
            // 
            this.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLotID.Location = new System.Drawing.Point(119, 17);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(200, 20);
            this.txtLotID.TabIndex = 3;
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(15, 19);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            this.lblLotID.TabIndex = 2;
            this.lblLotID.Text = "Lot ID";
            // 
            // txtHistSeq
            // 
            this.txtHistSeq.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtHistSeq.Location = new System.Drawing.Point(119, 41);
            this.txtHistSeq.MaxLength = 10;
            this.txtHistSeq.Name = "txtHistSeq";
            this.txtHistSeq.Size = new System.Drawing.Size(200, 20);
            this.txtHistSeq.TabIndex = 5;
            // 
            // lblHistSeq
            // 
            this.lblHistSeq.AutoSize = true;
            this.lblHistSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHistSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistSeq.Location = new System.Drawing.Point(15, 43);
            this.lblHistSeq.Name = "lblHistSeq";
            this.lblHistSeq.Size = new System.Drawing.Size(76, 13);
            this.lblHistSeq.TabIndex = 4;
            this.lblHistSeq.Text = "History Seq.";
            // 
            // grbGeneral
            // 
            this.grbGeneral.Controls.Add(this.spdRecipe);
            this.grbGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbGeneral.Location = new System.Drawing.Point(0, 0);
            this.grbGeneral.Name = "grbGeneral";
            this.grbGeneral.Size = new System.Drawing.Size(742, 166);
            this.grbGeneral.TabIndex = 0;
            this.grbGeneral.TabStop = false;
            this.grbGeneral.Text = "General";
            // 
            // spdRecipe
            // 
            this.spdRecipe.AccessibleDescription = "";
            this.spdRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdRecipe.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdRecipe.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdRecipe.HorizontalScrollBar.Name = "";
            this.spdRecipe.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdRecipe.HorizontalScrollBar.TabIndex = 2;
            this.spdRecipe.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdRecipe.Location = new System.Drawing.Point(3, 16);
            this.spdRecipe.MoveActiveOnFocus = false;
            this.spdRecipe.Name = "spdRecipe";
            this.spdRecipe.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdRecipe.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdRecipe.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdRecipe_LotInfo});
            this.spdRecipe.Size = new System.Drawing.Size(736, 147);
            this.spdRecipe.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdRecipe.TabIndex = 1;
            this.spdRecipe.TabStop = false;
            this.spdRecipe.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.spdRecipe.TextTipDelay = 200;
            this.spdRecipe.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdRecipe.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdRecipe.VerticalScrollBar.Name = "";
            this.spdRecipe.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdRecipe.VerticalScrollBar.TabIndex = 3;
            // 
            // spdRecipe_LotInfo
            // 
            this.spdRecipe_LotInfo.Reset();
            spdRecipe_LotInfo.SheetName = "LotInfo";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdRecipe_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdRecipe_LotInfo.ColumnCount = 4;
            spdRecipe_LotInfo.RowCount = 8;
            this.spdRecipe_LotInfo.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(0, 0).ParseFormatString = "G";
            this.spdRecipe_LotInfo.Cells.Get(0, 0).Value = "Lot ID";
            this.spdRecipe_LotInfo.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(0, 2).ParseFormatString = "G";
            this.spdRecipe_LotInfo.Cells.Get(0, 2).Value = "History Seq.";
            this.spdRecipe_LotInfo.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(1, 0).ParseFormatString = "G";
            this.spdRecipe_LotInfo.Cells.Get(1, 0).Value = "Tran Code";
            this.spdRecipe_LotInfo.Cells.Get(1, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(1, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(1, 2).ParseFormatString = "G";
            this.spdRecipe_LotInfo.Cells.Get(1, 2).Value = "Tran Time";
            this.spdRecipe_LotInfo.Cells.Get(1, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(2, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(2, 0).ParseFormatString = "G";
            this.spdRecipe_LotInfo.Cells.Get(2, 0).Value = "Res ID";
            this.spdRecipe_LotInfo.Cells.Get(2, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(2, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(2, 2).ParseFormatString = "G";
            this.spdRecipe_LotInfo.Cells.Get(2, 2).Value = "SubRes ID";
            this.spdRecipe_LotInfo.Cells.Get(2, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(3, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(3, 0).ParseFormatString = "G";
            this.spdRecipe_LotInfo.Cells.Get(3, 0).Value = "Recipe";
            this.spdRecipe_LotInfo.Cells.Get(3, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(3, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(3, 2).ParseFormatString = "G";
            this.spdRecipe_LotInfo.Cells.Get(3, 2).Value = "Recipe Version";
            this.spdRecipe_LotInfo.Cells.Get(3, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(4, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(4, 0).ParseFormatString = "G";
            this.spdRecipe_LotInfo.Cells.Get(4, 0).Value = "PP ID";
            this.spdRecipe_LotInfo.Cells.Get(4, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(4, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(4, 2).ParseFormatString = "G";
            this.spdRecipe_LotInfo.Cells.Get(4, 2).Value = "Coat PP ID";
            this.spdRecipe_LotInfo.Cells.Get(4, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(5, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(5, 0).ParseFormatString = "G";
            this.spdRecipe_LotInfo.Cells.Get(5, 0).Value = "Reticle ID";
            this.spdRecipe_LotInfo.Cells.Get(5, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(5, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(5, 2).ParseFormatString = "G";
            this.spdRecipe_LotInfo.Cells.Get(5, 2).Value = "Col Set ID";
            this.spdRecipe_LotInfo.Cells.Get(5, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(6, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(6, 0).ParseFormatString = "G";
            this.spdRecipe_LotInfo.Cells.Get(6, 0).Value = "Proc Time";
            this.spdRecipe_LotInfo.Cells.Get(6, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(6, 2).ParseFormatString = "G";
            this.spdRecipe_LotInfo.Cells.Get(6, 2).Value = "Modify Flag";
            this.spdRecipe_LotInfo.Cells.Get(7, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Cells.Get(7, 0).ParseFormatString = "G";
            this.spdRecipe_LotInfo.Cells.Get(7, 0).Value = "Inline Modify";
            this.spdRecipe_LotInfo.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdRecipe_LotInfo.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdRecipe_LotInfo.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdRecipe_LotInfo.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdRecipe_LotInfo.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdRecipe_LotInfo.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdRecipe_LotInfo.ColumnHeader.Visible = false;
            this.spdRecipe_LotInfo.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdRecipe_LotInfo.Columns.Get(0).Border = compoundBorder1;
            this.spdRecipe_LotInfo.Columns.Get(0).CellType = textCellType3;
            this.spdRecipe_LotInfo.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdRecipe_LotInfo.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdRecipe_LotInfo.Columns.Get(0).Locked = true;
            this.spdRecipe_LotInfo.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRecipe_LotInfo.Columns.Get(0).Width = 148F;
            this.spdRecipe_LotInfo.Columns.Get(1).CellType = textCellType4;
            this.spdRecipe_LotInfo.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdRecipe_LotInfo.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Columns.Get(1).Locked = true;
            this.spdRecipe_LotInfo.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRecipe_LotInfo.Columns.Get(1).Width = 199F;
            this.spdRecipe_LotInfo.Columns.Get(2).BackColor = System.Drawing.SystemColors.Control;
            this.spdRecipe_LotInfo.Columns.Get(2).Border = compoundBorder2;
            this.spdRecipe_LotInfo.Columns.Get(2).CellType = textCellType5;
            this.spdRecipe_LotInfo.Columns.Get(2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdRecipe_LotInfo.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdRecipe_LotInfo.Columns.Get(2).Locked = true;
            this.spdRecipe_LotInfo.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRecipe_LotInfo.Columns.Get(2).Width = 148F;
            this.spdRecipe_LotInfo.Columns.Get(3).CellType = textCellType6;
            this.spdRecipe_LotInfo.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdRecipe_LotInfo.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdRecipe_LotInfo.Columns.Get(3).Locked = true;
            this.spdRecipe_LotInfo.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRecipe_LotInfo.Columns.Get(3).Width = 199F;
            this.spdRecipe_LotInfo.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdRecipe_LotInfo.RowHeader.Columns.Default.Resizable = false;
            this.spdRecipe_LotInfo.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdRecipe_LotInfo.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdRecipe_LotInfo.RowHeader.Visible = false;
            this.spdRecipe_LotInfo.Rows.Get(0).Height = 17F;
            this.spdRecipe_LotInfo.Rows.Get(1).Height = 17F;
            this.spdRecipe_LotInfo.Rows.Get(2).Height = 17F;
            this.spdRecipe_LotInfo.Rows.Get(3).Height = 17F;
            this.spdRecipe_LotInfo.Rows.Get(4).Height = 17F;
            this.spdRecipe_LotInfo.Rows.Get(5).Height = 17F;
            this.spdRecipe_LotInfo.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdRecipe_LotInfo.SheetCornerStyle.Parent = "CornerDefault";
            this.spdRecipe_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grbParameter
            // 
            this.grbParameter.Controls.Add(this.spdParameter);
            this.grbParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbParameter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbParameter.Location = new System.Drawing.Point(0, 166);
            this.grbParameter.Name = "grbParameter";
            this.grbParameter.Size = new System.Drawing.Size(742, 269);
            this.grbParameter.TabIndex = 1;
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
            this.spdParameter.Size = new System.Drawing.Size(736, 250);
            this.spdParameter.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdParameter.TabIndex = 5;
            this.spdParameter.TabStop = false;
            this.spdParameter.TextTipDelay = 200;
            this.spdParameter.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdParameter.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdParameter.VerticalScrollBar.Name = "";
            this.spdParameter.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdParameter.VerticalScrollBar.TabIndex = 3;
            this.spdParameter.SetViewportLeftColumn(0, 0, 2);
            this.spdParameter.SetActiveViewport(0, 0, -1);
            // 
            // spdParameter_Sheet1
            // 
            this.spdParameter_Sheet1.Reset();
            spdParameter_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdParameter_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdParameter_Sheet1.ColumnCount = 5;
            spdParameter_Sheet1.RowCount = 5;
            this.spdParameter_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdParameter_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdParameter_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdParameter_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdParameter_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdParameter_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdParameter_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Parameter ID";
            this.spdParameter_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Value";
            this.spdParameter_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Description";
            this.spdParameter_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Modify Flag";
            this.spdParameter_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdParameter_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdParameter_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdParameter_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdParameter_Sheet1.Columns.Get(0).Width = 38F;
            this.spdParameter_Sheet1.Columns.Get(1).CellType = textCellType1;
            this.spdParameter_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdParameter_Sheet1.Columns.Get(1).Label = "Parameter ID";
            this.spdParameter_Sheet1.Columns.Get(1).Locked = false;
            this.spdParameter_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdParameter_Sheet1.Columns.Get(1).Width = 96F;
            this.spdParameter_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdParameter_Sheet1.Columns.Get(2).Label = "Value";
            this.spdParameter_Sheet1.Columns.Get(2).Locked = true;
            this.spdParameter_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdParameter_Sheet1.Columns.Get(2).Width = 100F;
            this.spdParameter_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdParameter_Sheet1.Columns.Get(3).Label = "Description";
            this.spdParameter_Sheet1.Columns.Get(3).Locked = false;
            this.spdParameter_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdParameter_Sheet1.Columns.Get(3).Width = 100F;
            this.spdParameter_Sheet1.Columns.Get(4).CellType = textCellType2;
            this.spdParameter_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdParameter_Sheet1.Columns.Get(4).Label = "Modify Flag";
            this.spdParameter_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdParameter_Sheet1.Columns.Get(4).Width = 76F;
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
            this.spdParameter_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmRCPViewLotRecipeHistory
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRCPViewLotRecipeHistory";
            this.Text = "View Lot Recipe History";
            this.Activated += new System.EventHandler(this.frmRCPViewLotRecipeHistory_Activated);
            this.Load += new System.EventHandler(this.frmRCPViewLotRecipeHistory_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grbGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdRecipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdRecipe_LotInfo)).EndInit();
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
        
        #endregion
        
        #region " Function Definition "
        
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        
        private bool CheckCondition(string FuncName)
        {
            
            try
            {
                switch (FuncName)
                {
                    case "View_Lot_Recipe_History":
                        
                        if (txtLotID.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            txtLotID.Focus();
                            return false;
                        }
                        
                        if (txtHistSeq.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            txtHistSeq.Focus();
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
            
//            return true;
//            
        }
        
        //
        // InitRecipeInfo()
        //       - Initialize the Recipe Info
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        
        private void InitRecipeInfo()
        {
            
            //Initilize spdRecipe
            spdRecipe.Sheets[0].Cells[0, 1].Text = "";
            spdRecipe.Sheets[0].Cells[0, 3].Text = "";
            spdRecipe.Sheets[0].Cells[1, 1].Text = "";
            spdRecipe.Sheets[0].Cells[1, 3].Text = "";
            spdRecipe.Sheets[0].Cells[2, 1].Text = "";
            spdRecipe.Sheets[0].Cells[2, 3].Text = "";
            spdRecipe.Sheets[0].Cells[3, 1].Text = "";
            spdRecipe.Sheets[0].Cells[3, 3].Text = "";
            spdRecipe.Sheets[0].Cells[4, 1].Text = "";
            spdRecipe.Sheets[0].Cells[4, 3].Text = "";
            spdRecipe.Sheets[0].Cells[5, 1].Text = "";
            spdRecipe.Sheets[0].Cells[5, 3].Text = "";
            spdRecipe.Sheets[0].Cells[6, 1].Text = "";
            spdRecipe.Sheets[0].Cells[6, 3].Text = "";
            spdRecipe.Sheets[0].Cells[7, 1].Text = "";
            spdRecipe.Sheets[0].Cells[7, 3].Text = "";
            
        }
        
        // View_Lot_Recipe_History()
        //       - View Lot Recipe History
        // Return Value
        //       - Boolean : True / False
        // Arguments
        //        -
        //
        private bool View_Lot_Recipe_History(char c_step, string sLot_id, int iHistSeq)
        {
            int i;
            int LastRow = 0;

            TRSNode in_node = new TRSNode("VIEW_LOT_RECIPE_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_RECIPE_HISTORY_OUT");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("LOT_ID", MPCF.Trim(sLot_id));
                in_node.AddInt("HIST_SEQ", iHistSeq);

                if (MPCR.CallService("RCP", "RCP_View_Lot_Recipe_History", in_node, ref out_node) == false)
                {
                    return false;
                }

                FarPoint.Win.Spread.SheetView with_1 = spdRecipe.Sheets[0];

                with_1.Cells[0, 1].Value = MPCF.Trim(sLot_id);
                with_1.Cells[0, 3].Value = iHistSeq;
                with_1.Cells[1, 1].Value = out_node.GetString("TRAN_CODE");
                with_1.Cells[1, 3].Value = MPCF.MakeDateFormat(out_node.GetString("TRAN_TIME"));
                with_1.Cells[2, 1].Value = out_node.GetString("RES_ID");
                with_1.Cells[2, 3].Value = out_node.GetString("SUBRES_ID");
                with_1.Cells[3, 1].Value = out_node.GetString("RECIPE");
                with_1.Cells[3, 3].Value = out_node.GetInt("RECIPE_VERSION");
                with_1.Cells[4, 1].Value = out_node.GetString("PP_ID");
                with_1.Cells[4, 3].Value = out_node.GetString("COAT_PP_ID");
                with_1.Cells[5, 1].Value = out_node.GetString("RETICLE_ID");
                with_1.Cells[5, 3].Value = out_node.GetString("COL_SET_ID");
                with_1.Cells[6, 1].Value = out_node.GetString("PROC_TIME");
                with_1.Cells[6, 3].Value = out_node.GetChar("MODIFY_FLAG");
                with_1.Cells[7, 1].Value = out_node.GetChar("INLINE_MODIFY");


                spdParameter.Sheets[0].RowCount = out_node.GetList(0).Count;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    
                    FarPoint.Win.Spread.SheetView with_2 = spdParameter.Sheets[0];

                    with_2.SetValue(LastRow, 0, MPCF.Trim(out_node.GetList(0)[i].GetInt("PARA_SEQ")));
                    with_2.SetValue(LastRow, 1, MPCF.Trim(out_node.GetList(0)[i].GetString("PARA_ID")));
                    with_2.SetValue(LastRow, 2, MPCF.Trim(out_node.GetList(0)[i].GetString("PARA_VALUE")));
                    with_2.SetValue(LastRow, 3, MPCF.Trim(out_node.GetList(0)[i].GetString("PARA_DESC")));
                    with_2.SetValue(LastRow, 4, MPCF.Trim(out_node.GetList(0)[i].GetChar("MODIFY_FLAG")));
                    
                    LastRow++;
                    
                }
                
                MPCF.FitColumnHeader(spdParameter);
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            return true;
        }
        
        public void ActiveFormNow()
        {
            if (MPGV.gsCurrentLot_ID != "" && MPGV.giCurrentHistSeq > 0)
            {
                txtLotID.Text = MPGV.gsCurrentLot_ID;
                txtHistSeq.Text = MPGV.giCurrentHistSeq.ToString();
                
                btnView.PerformClick();
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
        
        private void frmRCPViewLotRecipeHistory_Load(object sender, System.EventArgs e)
        {
            try
            {

                MPCF.FieldClear(this);
                
                InitRecipeInfo();
                MPCF.ClearList(spdParameter, true);
                MPCF.FitColumnHeader(spdParameter);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmRCPViewLotRecipeHistory_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    ActiveFormNow();
                    
                    b_load_flag = true;
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
                InitRecipeInfo();
                MPCF.ClearList(spdParameter, true);
                if (CheckCondition("View_Lot_Recipe_History") == true)
                {
                    if (View_Lot_Recipe_History('1', txtLotID.Text, MPCF.ToInt(txtHistSeq.Text)) == false)
                    {
                        txtLotID.Focus();
                        return;
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
            string sCond;
            
            sCond = "Lot ID :" + txtLotID.Text + "Hist Seq. : " + txtHistSeq.Text;
            MPCF.ExportToExcel(spdParameter, this.Text, sCond);
            
        }
        
    }
    //#End If
}
