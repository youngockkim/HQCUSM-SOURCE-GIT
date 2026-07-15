
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

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASViewLotbyResourceGroup.vb
//   Description : View Lot List By Resource Group Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - CheckCondition()  :  Check the conditions before transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-08-10 : Created by H.K.Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.RASCore
{
    public class frmRASViewLotByResourceGroup : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASViewLotByResourceGroup()
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
        



        private System.Windows.Forms.Panel pnlGrp;
        private System.Windows.Forms.GroupBox grpOption;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.Label lblOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOper;
        private System.Windows.Forms.Panel pnlMiddle;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvPrt1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGrp1;
        private System.Windows.Forms.Label lblPrt1;
        private System.Windows.Forms.Label lblGrp1;
        private FarPoint.Win.Spread.FpSpread spdLot;
        private FarPoint.Win.Spread.SheetView spdLot_Sheet1;
        public System.Windows.Forms.Button btnExcel;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRASViewLotByResourceGroup));
            this.pnlGrp = new System.Windows.Forms.Panel();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.cdvPrt1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGrp1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPrt1 = new System.Windows.Forms.Label();
            this.lblGrp1 = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.lblOper = new System.Windows.Forms.Label();
            this.cdvOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.spdLot = new FarPoint.Win.Spread.FpSpread();
            this.spdLot_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlGrp.SuspendLayout();
            this.grpOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdLot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLot_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Text = "View";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlMiddle);
            this.pnlCenter.Controls.Add(this.pnlGrp);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Lot List by Resource Group";
            // 
            // pnlGrp
            // 
            this.pnlGrp.Controls.Add(this.grpOption);
            this.pnlGrp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGrp.Location = new System.Drawing.Point(3, 0);
            this.pnlGrp.Name = "pnlGrp";
            this.pnlGrp.Size = new System.Drawing.Size(736, 71);
            this.pnlGrp.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvPrt1);
            this.grpOption.Controls.Add(this.cdvGrp1);
            this.grpOption.Controls.Add(this.lblPrt1);
            this.grpOption.Controls.Add(this.lblGrp1);
            this.grpOption.Controls.Add(this.cdvResID);
            this.grpOption.Controls.Add(this.lblResID);
            this.grpOption.Controls.Add(this.lblOper);
            this.grpOption.Controls.Add(this.cdvOper);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOption.Location = new System.Drawing.Point(0, 0);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(736, 71);
            this.grpOption.TabIndex = 0;
            this.grpOption.TabStop = false;
            // 
            // cdvPrt1
            // 
            this.cdvPrt1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPrt1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPrt1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPrt1.BtnToolTipText = "";
            this.cdvPrt1.DescText = "";
            this.cdvPrt1.DisplaySubItemIndex = -1;
            this.cdvPrt1.DisplayText = "";
            this.cdvPrt1.Focusing = null;
            this.cdvPrt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPrt1.Index = 0;
            this.cdvPrt1.IsViewBtnImage = false;
            this.cdvPrt1.Location = new System.Drawing.Point(120, 16);
            this.cdvPrt1.MaxLength = 30;
            this.cdvPrt1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPrt1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPrt1.Name = "cdvPrt1";
            this.cdvPrt1.ReadOnly = true;
            this.cdvPrt1.SearchSubItemIndex = 0;
            this.cdvPrt1.SelectedDescIndex = -1;
            this.cdvPrt1.SelectedSubItemIndex = -1;
            this.cdvPrt1.SelectionStart = 0;
            this.cdvPrt1.Size = new System.Drawing.Size(200, 20);
            this.cdvPrt1.SmallImageList = null;
            this.cdvPrt1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPrt1.TabIndex = 1;
            this.cdvPrt1.TextBoxToolTipText = "";
            this.cdvPrt1.TextBoxWidth = 200;
            this.cdvPrt1.VisibleButton = true;
            this.cdvPrt1.VisibleColumnHeader = false;
            this.cdvPrt1.VisibleDescription = false;
            this.cdvPrt1.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvPrt1_SelectedItemChanged);
            this.cdvPrt1.ButtonPress += new System.EventHandler(this.cdvPrt1_ButtonPress);
            // 
            // cdvGrp1
            // 
            this.cdvGrp1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrp1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrp1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGrp1.BtnToolTipText = "";
            this.cdvGrp1.DescText = "";
            this.cdvGrp1.DisplaySubItemIndex = -1;
            this.cdvGrp1.DisplayText = "";
            this.cdvGrp1.Focusing = null;
            this.cdvGrp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGrp1.Index = 0;
            this.cdvGrp1.IsViewBtnImage = false;
            this.cdvGrp1.Location = new System.Drawing.Point(525, 16);
            this.cdvGrp1.MaxLength = 30;
            this.cdvGrp1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGrp1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGrp1.Name = "cdvGrp1";
            this.cdvGrp1.ReadOnly = false;
            this.cdvGrp1.SearchSubItemIndex = 0;
            this.cdvGrp1.SelectedDescIndex = -1;
            this.cdvGrp1.SelectedSubItemIndex = -1;
            this.cdvGrp1.SelectionStart = 0;
            this.cdvGrp1.Size = new System.Drawing.Size(200, 20);
            this.cdvGrp1.SmallImageList = null;
            this.cdvGrp1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGrp1.TabIndex = 5;
            this.cdvGrp1.TextBoxToolTipText = "";
            this.cdvGrp1.TextBoxWidth = 200;
            this.cdvGrp1.VisibleButton = true;
            this.cdvGrp1.VisibleColumnHeader = false;
            this.cdvGrp1.VisibleDescription = false;
            this.cdvGrp1.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvGrp1_SelectedItemChanged);
            this.cdvGrp1.ButtonPress += new System.EventHandler(this.cdvGrp1_ButtonPress);
            this.cdvGrp1.TextBoxTextChanged += new System.EventHandler(this.cdvGrp1_TextBoxTextChanged);
            // 
            // lblPrt1
            // 
            this.lblPrt1.AutoSize = true;
            this.lblPrt1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPrt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrt1.Location = new System.Drawing.Point(15, 19);
            this.lblPrt1.Name = "lblPrt1";
            this.lblPrt1.Size = new System.Drawing.Size(84, 13);
            this.lblPrt1.TabIndex = 0;
            this.lblPrt1.Text = "Group Prompt";
            // 
            // lblGrp1
            // 
            this.lblGrp1.AutoSize = true;
            this.lblGrp1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrp1.Location = new System.Drawing.Point(420, 19);
            this.lblGrp1.Name = "lblGrp1";
            this.lblGrp1.Size = new System.Drawing.Size(99, 13);
            this.lblGrp1.TabIndex = 4;
            this.lblGrp1.Text = "Resource Group";
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
            this.cdvResID.Location = new System.Drawing.Point(525, 42);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(200, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 7;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 200;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResID_SelectedItemChanged);
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            this.cdvResID.TextBoxTextChanged += new System.EventHandler(this.cdvResID_TextBoxTextChanged);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(420, 45);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(61, 13);
            this.lblResID.TabIndex = 6;
            this.lblResID.Text = "Resource";
            // 
            // lblOper
            // 
            this.lblOper.AutoSize = true;
            this.lblOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOper.Location = new System.Drawing.Point(15, 45);
            this.lblOper.Name = "lblOper";
            this.lblOper.Size = new System.Drawing.Size(53, 13);
            this.lblOper.TabIndex = 2;
            this.lblOper.Text = "Operation";
            // 
            // cdvOper
            // 
            this.cdvOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOper.BtnToolTipText = "";
            this.cdvOper.DescText = "";
            this.cdvOper.DisplaySubItemIndex = -1;
            this.cdvOper.DisplayText = "";
            this.cdvOper.Focusing = null;
            this.cdvOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOper.Index = 0;
            this.cdvOper.IsViewBtnImage = false;
            this.cdvOper.Location = new System.Drawing.Point(120, 42);
            this.cdvOper.MaxLength = 10;
            this.cdvOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOper.Name = "cdvOper";
            this.cdvOper.ReadOnly = false;
            this.cdvOper.SearchSubItemIndex = 0;
            this.cdvOper.SelectedDescIndex = -1;
            this.cdvOper.SelectedSubItemIndex = -1;
            this.cdvOper.SelectionStart = 0;
            this.cdvOper.Size = new System.Drawing.Size(200, 20);
            this.cdvOper.SmallImageList = null;
            this.cdvOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOper.TabIndex = 3;
            this.cdvOper.TextBoxToolTipText = "";
            this.cdvOper.TextBoxWidth = 200;
            this.cdvOper.VisibleButton = true;
            this.cdvOper.VisibleColumnHeader = false;
            this.cdvOper.VisibleDescription = false;
            this.cdvOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvOper_SelectedItemChanged);
            this.cdvOper.ButtonPress += new System.EventHandler(this.cdvOper_ButtonPress);
            this.cdvOper.TextBoxTextChanged += new System.EventHandler(this.cdvOper_TextBoxTextChanged);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.spdLot);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(3, 71);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlMiddle.Size = new System.Drawing.Size(736, 435);
            this.pnlMiddle.TabIndex = 0;
            // 
            // spdLot
            // 
            this.spdLot.AccessibleDescription = "spdLot, Sheet1";
            this.spdLot.BackColor = System.Drawing.SystemColors.Control;
            this.spdLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdLot.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdLot.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLot.HorizontalScrollBar.Name = "";
            this.spdLot.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdLot.HorizontalScrollBar.TabIndex = 2;
            this.spdLot.Location = new System.Drawing.Point(0, 3);
            this.spdLot.Name = "spdLot";
            this.spdLot.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdLot.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdLot.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdLot_Sheet1});
            this.spdLot.Size = new System.Drawing.Size(736, 432);
            this.spdLot.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdLot.TabIndex = 0;
            this.spdLot.TabStop = false;
            this.spdLot.TextTipDelay = 200;
            this.spdLot.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdLot.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLot.VerticalScrollBar.Name = "";
            this.spdLot.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdLot.VerticalScrollBar.TabIndex = 3;
            this.spdLot.SetActiveViewport(0, -1, -1);
            // 
            // spdLot_Sheet1
            // 
            this.spdLot_Sheet1.Reset();
            spdLot_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdLot_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdLot_Sheet1.ColumnCount = 16;
            spdLot_Sheet1.RowCount = 0;
            this.spdLot_Sheet1.ActiveColumnIndex = -1;
            this.spdLot_Sheet1.ActiveRowIndex = -1;
            this.spdLot_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLot_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdLot_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLot_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Lot ID";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Resource";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Lot Status";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Mat ID";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Mat Ver";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Flow";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Flow Seq Num";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Oper";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Qty1";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Qty2";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Qty3";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Lot Type";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Lot Priority";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Create Code";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Owner Code";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Hold Code";
            this.spdLot_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLot_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdLot_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdLot_Sheet1.Columns.Get(0).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdLot_Sheet1.Columns.Get(0).Label = "Lot ID";
            this.spdLot_Sheet1.Columns.Get(0).Locked = true;
            this.spdLot_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(0).Width = 100F;
            this.spdLot_Sheet1.Columns.Get(1).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(1).Label = "Resource";
            this.spdLot_Sheet1.Columns.Get(1).Locked = true;
            this.spdLot_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(1).Width = 75F;
            this.spdLot_Sheet1.Columns.Get(2).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdLot_Sheet1.Columns.Get(2).Label = "Lot Status";
            this.spdLot_Sheet1.Columns.Get(2).Locked = true;
            this.spdLot_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(2).Width = 75F;
            this.spdLot_Sheet1.Columns.Get(3).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdLot_Sheet1.Columns.Get(3).Label = "Mat ID";
            this.spdLot_Sheet1.Columns.Get(3).Locked = true;
            this.spdLot_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(3).Width = 115F;
            this.spdLot_Sheet1.Columns.Get(4).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(4).Label = "Mat Ver";
            this.spdLot_Sheet1.Columns.Get(4).Locked = true;
            this.spdLot_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(4).Width = 70F;
            this.spdLot_Sheet1.Columns.Get(5).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdLot_Sheet1.Columns.Get(5).Label = "Flow";
            this.spdLot_Sheet1.Columns.Get(5).Locked = true;
            this.spdLot_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(5).Width = 103F;
            this.spdLot_Sheet1.Columns.Get(6).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(6).Label = "Flow Seq Num";
            this.spdLot_Sheet1.Columns.Get(6).Locked = true;
            this.spdLot_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(6).Width = 100F;
            this.spdLot_Sheet1.Columns.Get(7).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdLot_Sheet1.Columns.Get(7).Label = "Oper";
            this.spdLot_Sheet1.Columns.Get(7).Locked = true;
            this.spdLot_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(8).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLot_Sheet1.Columns.Get(8).Label = "Qty1";
            this.spdLot_Sheet1.Columns.Get(8).Locked = true;
            this.spdLot_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(8).Width = 54F;
            this.spdLot_Sheet1.Columns.Get(9).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLot_Sheet1.Columns.Get(9).Label = "Qty2";
            this.spdLot_Sheet1.Columns.Get(9).Locked = true;
            this.spdLot_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(9).Width = 52F;
            this.spdLot_Sheet1.Columns.Get(10).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLot_Sheet1.Columns.Get(10).Label = "Qty3";
            this.spdLot_Sheet1.Columns.Get(10).Locked = true;
            this.spdLot_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(10).Width = 58F;
            this.spdLot_Sheet1.Columns.Get(11).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(11).Label = "Lot Type";
            this.spdLot_Sheet1.Columns.Get(11).Locked = true;
            this.spdLot_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(11).Width = 68F;
            this.spdLot_Sheet1.Columns.Get(12).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLot_Sheet1.Columns.Get(12).Label = "Lot Priority";
            this.spdLot_Sheet1.Columns.Get(12).Locked = true;
            this.spdLot_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(12).Width = 75F;
            this.spdLot_Sheet1.Columns.Get(13).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdLot_Sheet1.Columns.Get(13).Label = "Create Code";
            this.spdLot_Sheet1.Columns.Get(13).Locked = true;
            this.spdLot_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(13).Width = 90F;
            this.spdLot_Sheet1.Columns.Get(14).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdLot_Sheet1.Columns.Get(14).Label = "Owner Code";
            this.spdLot_Sheet1.Columns.Get(14).Locked = true;
            this.spdLot_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(14).Width = 90F;
            this.spdLot_Sheet1.Columns.Get(15).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdLot_Sheet1.Columns.Get(15).Label = "Hold Code";
            this.spdLot_Sheet1.Columns.Get(15).Locked = true;
            this.spdLot_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(15).Width = 90F;
            this.spdLot_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdLot_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdLot_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLot_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdLot_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLot_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdLot_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(10, 6);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // frmRASViewLotByResourceGroup
            // 
            this.AcceptButton = this.btnProcess;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRASViewLotByResourceGroup";
            this.Text = "View Lot List by Resource Group";
            this.Activated += new System.EventHandler(this.frmRASViewLotByResourceGroup_Activated);
            this.Load += new System.EventHandler(this.frmRASViewLotByResourceGroup_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlGrp.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdLot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLot_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable definition "
        string[] sGrpTableName = new string[10];
        bool b_load_flag;
        #endregion
        
        #region "Function Definition"
        
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
                case "VIEW":

                    if (MPCF.CheckValue(cdvPrt1, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvGrp1, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvResID, 1) == false)
                    {
                        return false;
                    }
                    break;
            }
            
            return true;
        }
        
        private void SetGroupCmfItem()
        {
            
            sGrpTableName[0] = MPGC.MP_GCM_RES_GRP_1;
            sGrpTableName[1] = MPGC.MP_GCM_RES_GRP_2;
            sGrpTableName[2] = MPGC.MP_GCM_RES_GRP_3;
            sGrpTableName[3] = MPGC.MP_GCM_RES_GRP_4;
            sGrpTableName[4] = MPGC.MP_GCM_RES_GRP_5;
            sGrpTableName[5] = MPGC.MP_GCM_RES_GRP_6;
            sGrpTableName[6] = MPGC.MP_GCM_RES_GRP_7;
            sGrpTableName[7] = MPGC.MP_GCM_RES_GRP_8;
            sGrpTableName[8] = MPGC.MP_GCM_RES_GRP_9;
            sGrpTableName[9] = MPGC.MP_GCM_RES_GRP_10;
            
        }
        // SetGRPItem()
        //       - Set Group  Property to control
        // Return Value
        //       -
        // Arguments
        //        -
        public void SetGRPItem(params string[] sGrpTableName)
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            ListViewItem itmx = null;
            int i;

            try
            {
                cdvPrt1.Init();
                MPCF.InitListView(cdvPrt1.GetListView);
                cdvPrt1.Columns.Add("Group", 100, HorizontalAlignment.Left);
                cdvPrt1.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvPrt1.SelectedSubItemIndex = 1;
                cdvPrt1.DisplaySubItemIndex = 0;

                if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_GRP_RESOURCE, ref out_node, "", true) == false)
                {
                    return;
                }
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")) != "")
                    {
                        itmx = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")), (int)SMALLICON_INDEX.IDX_CODE_DATA);

                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("TABLE_NAME")) == "")
                        {
                            itmx.SubItems.Add(sGrpTableName[i]);
                        }
                        else
                        {
                            itmx.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TABLE_NAME")));
                        }
                        cdvPrt1.Items.Add(itmx);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvPrt1;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void cdvGrp1_ButtonPress(System.Object sender, System.EventArgs e)
        {
            if (cdvPrt1.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvPrt1.Focus();
                cdvGrp1.IsPopup = false;
                return;
            }
            
            cdvGrp1.Init();
            MPCF.InitListView(cdvGrp1.GetListView);
            cdvGrp1.Columns.Add("Group", 50, HorizontalAlignment.Left);
            cdvGrp1.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvGrp1.SelectedSubItemIndex = 0;
            if (BASLIST.ViewGCMDataList(cdvGrp1.GetListView, '1', cdvPrt1.Text) == false)
            {
                return;
            }
            cdvGrp1.AddEmptyRow(1);
        }
        
        private void frmRASViewLotByResourceGroup_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.ClearList(spdLot, true);
                MPCF.FitColumnHeader(spdLot);
                
                spdLot.Sheets[0].SetColumnAllowAutoSort(0, 13, true);
                MPCF.FitColumnHeader(spdLot);
                SetGroupCmfItem();
                b_load_flag = true;
            }
        }
        
        private void frmRASViewLotByResourceGroup_Load(object sender, System.EventArgs e)
        {
        }
        
        private void cdvPrt1_ButtonPress(object sender, System.EventArgs e)
        {
            SetGRPItem(sGrpTableName);
            cdvPrt1.AddEmptyRow(1);
        }
        private void cdvGrp1_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            cdvResID.Text = "";
            cdvOper.Text = "";
            MPCF.ClearList(spdLot, true);
        }
        private void cdvOper_ButtonPress(System.Object sender, System.EventArgs e)
        {
            cdvOper.Init();
            MPCF.InitListView(cdvOper.GetListView);
            cdvOper.Columns.Add("Oper", 50, HorizontalAlignment.Left);
            cdvOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOper.SelectedSubItemIndex = 0;
            WIPLIST.ViewOperationList(cdvOper.GetListView, '1');
        }
        
        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {
            if (cdvGrp1.Text == "")
            {
                return;
            }
            cdvResID.Init();
            MPCF.InitListView(cdvResID.GetListView);
            cdvResID.Columns.Add("Oper", 50, HorizontalAlignment.Left);
            cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResID.SelectedSubItemIndex = 0;
            RASLIST.ViewResourceListDetailByGroup(cdvResID.GetListView, '1', "", cdvGrp1.Text, cdvPrt1.Text, "", "", "", "", null, "");
        }
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("VIEW") == false)
            {
                return;
            }
            if (RASLIST.ViewLotByResList(spdLot, '1', cdvResID.Text, cdvOper.Text, null, "") == false)
            {
                return;
            }
            
            MPCF.FitColumnHeader(spdLot);
            
        }
        
        private void cdvGrp1_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvResID.Text = "";
            cdvOper.Text = "";
            MPCF.ClearList(spdLot, true);
        }
        
        private void cdvResID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.ClearList(spdLot, true);
        }
        
        private void cdvOper_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.ClearList(spdLot, true);
        }
        
        private void cdvResID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            MPCF.ClearList(spdLot, true);
        }
        
        private void cdvOper_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            MPCF.ClearList(spdLot, true);
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;
            
            sCond = "Group Prompt : " + MPCF.Trim(cdvPrt1.DisplayText) + "\r";
            sCond = sCond + "Reource Group : " + MPCF.Trim(cdvGrp1.DisplayText) + "\r";
            sCond = sCond + "Reource ID : " + MPCF.Trim(cdvResID.DisplayText);
            if (cdvOper.Text != "")
            {
                sCond = sCond + "\r" + "Operation : " + MPCF.Trim(cdvOper.DisplayText);
            }

            MPCF.ExportToExcel(spdLot, this.Text, sCond);
        }
        
        private void cdvPrt1_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvGrp1.DisplayText = "";
            cdvGrp1.Text = "";
        }
        
    }
    
}
