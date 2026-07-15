
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
//   File Name   : frmEDCViewCharacterByGroup.vb
//   Description : MES Cient Form View Character By Group
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - SetTableName() : Set Character Group Table Name
//       - initCodeView() : initial CodeView Control
//       - SetCharGroupPrompt() : Set Group Property to control
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-08-10 : Created by CM Koo
//       - 2008-01-18 : Modified by LAVERWON
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------



namespace Miracom.EDCCore
{
    public class frmEDCViewCharacterByGroup : Miracom.MESCore.ViewForm01
    {

#if _EDC
        
#region " Windows Form auto generated code "
        
        public frmEDCViewCharacterByGroup()
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
        



        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.Label lblValue;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvPrompt;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvValue;
        private FarPoint.Win.Spread.FpSpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.cdvPrompt = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvValue = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrompt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).BeginInit();
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
            this.pnlViewTop.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlViewTop.Size = new System.Drawing.Size(742, 75);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvValue);
            this.grpOption.Controls.Add(this.cdvPrompt);
            this.grpOption.Controls.Add(this.lblValue);
            this.grpOption.Controls.Add(this.lblPrompt);
            this.grpOption.Location = new System.Drawing.Point(0, 5);
            this.grpOption.Size = new System.Drawing.Size(742, 70);
            this.grpOption.Text = "Character Group";
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdList);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 75);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 438);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Character by Group";
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrompt.Location = new System.Drawing.Point(15, 19);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(46, 13);
            this.lblPrompt.TabIndex = 0;
            this.lblPrompt.Text = "Prompt";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.Location = new System.Drawing.Point(15, 43);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(39, 13);
            this.lblValue.TabIndex = 1;
            this.lblValue.Text = "Value";
            // 
            // cdvPrompt
            // 
            this.cdvPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvPrompt.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPrompt.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPrompt.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPrompt.BtnToolTipText = "";
            this.cdvPrompt.DescText = "";
            this.cdvPrompt.DisplaySubItemIndex = 0;
            this.cdvPrompt.DisplayText = "";
            this.cdvPrompt.Focusing = null;
            this.cdvPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPrompt.Index = 0;
            this.cdvPrompt.IsViewBtnImage = false;
            this.cdvPrompt.Location = new System.Drawing.Point(120, 16);
            this.cdvPrompt.MaxLength = 20;
            this.cdvPrompt.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPrompt.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPrompt.Name = "cdvPrompt";
            this.cdvPrompt.ReadOnly = false;
            this.cdvPrompt.SearchSubItemIndex = 0;
            this.cdvPrompt.SelectedDescIndex = 1;
            this.cdvPrompt.SelectedSubItemIndex = 0;
            this.cdvPrompt.SelectionStart = 0;
            this.cdvPrompt.Size = new System.Drawing.Size(420, 20);
            this.cdvPrompt.SmallImageList = null;
            this.cdvPrompt.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPrompt.TabIndex = 0;
            this.cdvPrompt.TextBoxToolTipText = "";
            this.cdvPrompt.TextBoxWidth = 200;
            this.cdvPrompt.VisibleButton = true;
            this.cdvPrompt.VisibleColumnHeader = false;
            this.cdvPrompt.VisibleDescription = true;
            this.cdvPrompt.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvPrompt_SelectedItemChanged);
            this.cdvPrompt.ButtonPress += new System.EventHandler(this.cdvPrompt_ButtonPress);
            // 
            // cdvValue
            // 
            this.cdvValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvValue.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvValue.BorderHotColor = System.Drawing.Color.Black;
            this.cdvValue.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvValue.BtnToolTipText = "";
            this.cdvValue.DescText = "";
            this.cdvValue.DisplaySubItemIndex = 0;
            this.cdvValue.DisplayText = "";
            this.cdvValue.Focusing = null;
            this.cdvValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvValue.Index = 0;
            this.cdvValue.IsViewBtnImage = false;
            this.cdvValue.Location = new System.Drawing.Point(120, 40);
            this.cdvValue.MaxLength = 20;
            this.cdvValue.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvValue.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvValue.Name = "cdvValue";
            this.cdvValue.ReadOnly = false;
            this.cdvValue.SearchSubItemIndex = 0;
            this.cdvValue.SelectedDescIndex = 1;
            this.cdvValue.SelectedSubItemIndex = 0;
            this.cdvValue.SelectionStart = 0;
            this.cdvValue.Size = new System.Drawing.Size(420, 20);
            this.cdvValue.SmallImageList = null;
            this.cdvValue.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvValue.TabIndex = 1;
            this.cdvValue.TextBoxToolTipText = "";
            this.cdvValue.TextBoxWidth = 200;
            this.cdvValue.VisibleButton = true;
            this.cdvValue.VisibleColumnHeader = false;
            this.cdvValue.VisibleDescription = true;
            this.cdvValue.ButtonPress += new System.EventHandler(this.cdvValue_ButtonPress);
            // 
            // spdList
            // 
            this.spdList.AccessibleDescription = "spdList, Sheet1, Row 0, Column 0, ";
            this.spdList.BackColor = System.Drawing.SystemColors.Control;
            this.spdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.HorizontalScrollBar.Name = "";
            this.spdList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdList.HorizontalScrollBar.TabIndex = 2;
            this.spdList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdList.Location = new System.Drawing.Point(0, 5);
            this.spdList.Name = "spdList";
            this.spdList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdList_Sheet1});
            this.spdList.Size = new System.Drawing.Size(742, 433);
            this.spdList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdList.TabIndex = 0;
            this.spdList.TabStop = false;
            this.spdList.TextTipDelay = 200;
            this.spdList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.VerticalScrollBar.Name = "";
            this.spdList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdList.VerticalScrollBar.TabIndex = 3;
            this.spdList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdList.SetViewportLeftColumn(0, 0, 2);
            this.spdList.SetActiveViewport(0, -1, -1);
            // 
            // spdList_Sheet1
            // 
            this.spdList_Sheet1.Reset();
            spdList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdList_Sheet1.ColumnCount = 34;
            spdList_Sheet1.RowCount = 0;
            this.spdList_Sheet1.ActiveColumnIndex = -1;
            this.spdList_Sheet1.ActiveRowIndex = -1;
            this.spdList_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Factory";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Character";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Value Type";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Unit";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Target Value";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Upper Spec. Limit";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Lower Spec. Limit";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Upper Warn. Limit";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Lower Warn. Limit";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Char Group 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Char Group 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Char Group 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Char Group 4";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Char Group 5";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Char Group 6";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Char Group 7";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Char Group 8";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Char Group 9";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Char Group 10";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Char Cmf 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Char Cmf 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Char Cmf 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Char Cmf 4";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Char Cmf 5";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Char Cmf 6";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Char Cmf 7";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Char Cmf 8";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Char Cmf 9";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Char Cmf 10";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Create User";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Create Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Update User";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Update Time";
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdList_Sheet1.Columns.Get(0).Label = "Factory";
            this.spdList_Sheet1.Columns.Get(0).Locked = true;
            this.spdList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(1).Label = "Character";
            this.spdList_Sheet1.Columns.Get(1).Locked = true;
            this.spdList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(1).Width = 100F;
            this.spdList_Sheet1.Columns.Get(2).Label = "Description";
            this.spdList_Sheet1.Columns.Get(2).Locked = true;
            this.spdList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(2).Width = 120F;
            this.spdList_Sheet1.Columns.Get(3).Label = "Value Type";
            this.spdList_Sheet1.Columns.Get(3).Locked = true;
            this.spdList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(3).Width = 70F;
            this.spdList_Sheet1.Columns.Get(4).Label = "Unit";
            this.spdList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(4).Width = 36F;
            this.spdList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(5).Label = "Target Value";
            this.spdList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(5).Width = 100F;
            this.spdList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(6).Label = "Upper Spec. Limit";
            this.spdList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(6).Width = 100F;
            this.spdList_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(7).Label = "Lower Spec. Limit";
            this.spdList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(7).Width = 100F;
            this.spdList_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(8).Label = "Upper Warn. Limit";
            this.spdList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(8).Width = 100F;
            this.spdList_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(9).Label = "Lower Warn. Limit";
            this.spdList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(9).Width = 100F;
            this.spdList_Sheet1.Columns.Get(10).Label = "Char Group 1";
            this.spdList_Sheet1.Columns.Get(10).Locked = true;
            this.spdList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(10).Width = 100F;
            this.spdList_Sheet1.Columns.Get(11).Label = "Char Group 2";
            this.spdList_Sheet1.Columns.Get(11).Locked = true;
            this.spdList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(11).Width = 100F;
            this.spdList_Sheet1.Columns.Get(12).Label = "Char Group 3";
            this.spdList_Sheet1.Columns.Get(12).Locked = true;
            this.spdList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(12).Width = 100F;
            this.spdList_Sheet1.Columns.Get(13).Label = "Char Group 4";
            this.spdList_Sheet1.Columns.Get(13).Locked = true;
            this.spdList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(13).Width = 100F;
            this.spdList_Sheet1.Columns.Get(14).Label = "Char Group 5";
            this.spdList_Sheet1.Columns.Get(14).Locked = true;
            this.spdList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(14).Width = 100F;
            this.spdList_Sheet1.Columns.Get(15).Label = "Char Group 6";
            this.spdList_Sheet1.Columns.Get(15).Locked = true;
            this.spdList_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(15).Width = 100F;
            this.spdList_Sheet1.Columns.Get(16).Label = "Char Group 7";
            this.spdList_Sheet1.Columns.Get(16).Locked = true;
            this.spdList_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(16).Width = 100F;
            this.spdList_Sheet1.Columns.Get(17).Label = "Char Group 8";
            this.spdList_Sheet1.Columns.Get(17).Locked = true;
            this.spdList_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(17).Width = 100F;
            this.spdList_Sheet1.Columns.Get(18).Label = "Char Group 9";
            this.spdList_Sheet1.Columns.Get(18).Locked = true;
            this.spdList_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(18).Width = 100F;
            this.spdList_Sheet1.Columns.Get(19).Label = "Char Group 10";
            this.spdList_Sheet1.Columns.Get(19).Locked = true;
            this.spdList_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(19).Width = 100F;
            this.spdList_Sheet1.Columns.Get(20).Label = "Char Cmf 1";
            this.spdList_Sheet1.Columns.Get(20).Locked = true;
            this.spdList_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(20).Width = 100F;
            this.spdList_Sheet1.Columns.Get(21).Label = "Char Cmf 2";
            this.spdList_Sheet1.Columns.Get(21).Locked = true;
            this.spdList_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(21).Width = 100F;
            this.spdList_Sheet1.Columns.Get(22).Label = "Char Cmf 3";
            this.spdList_Sheet1.Columns.Get(22).Locked = true;
            this.spdList_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(22).Width = 100F;
            this.spdList_Sheet1.Columns.Get(23).Label = "Char Cmf 4";
            this.spdList_Sheet1.Columns.Get(23).Locked = true;
            this.spdList_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(23).Width = 100F;
            this.spdList_Sheet1.Columns.Get(24).Label = "Char Cmf 5";
            this.spdList_Sheet1.Columns.Get(24).Locked = true;
            this.spdList_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(24).Width = 100F;
            this.spdList_Sheet1.Columns.Get(25).Label = "Char Cmf 6";
            this.spdList_Sheet1.Columns.Get(25).Locked = true;
            this.spdList_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(25).Width = 100F;
            this.spdList_Sheet1.Columns.Get(26).Label = "Char Cmf 7";
            this.spdList_Sheet1.Columns.Get(26).Locked = true;
            this.spdList_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(26).Width = 100F;
            this.spdList_Sheet1.Columns.Get(27).Label = "Char Cmf 8";
            this.spdList_Sheet1.Columns.Get(27).Locked = true;
            this.spdList_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(27).Width = 100F;
            this.spdList_Sheet1.Columns.Get(28).Label = "Char Cmf 9";
            this.spdList_Sheet1.Columns.Get(28).Locked = true;
            this.spdList_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(28).Width = 100F;
            this.spdList_Sheet1.Columns.Get(29).Label = "Char Cmf 10";
            this.spdList_Sheet1.Columns.Get(29).Locked = true;
            this.spdList_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(29).Width = 100F;
            this.spdList_Sheet1.Columns.Get(30).Label = "Create User";
            this.spdList_Sheet1.Columns.Get(30).Locked = true;
            this.spdList_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(30).Width = 85F;
            this.spdList_Sheet1.Columns.Get(31).Label = "Create Time";
            this.spdList_Sheet1.Columns.Get(31).Locked = true;
            this.spdList_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(31).Width = 110F;
            this.spdList_Sheet1.Columns.Get(32).Label = "Update User";
            this.spdList_Sheet1.Columns.Get(32).Locked = true;
            this.spdList_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(32).Width = 85F;
            this.spdList_Sheet1.Columns.Get(33).Label = "Update Time";
            this.spdList_Sheet1.Columns.Get(33).Locked = true;
            this.spdList_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(33).Width = 110F;
            this.spdList_Sheet1.FrozenColumnCount = 2;
            this.spdList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.spdList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdList_Sheet1.Rows.Default.Height = 18F;
            this.spdList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmEDCViewCharacterByGroup
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmEDCViewCharacterByGroup";
            this.Text = "View Character by Group";
            this.Activated += new System.EventHandler(this.frmEDCViewCharacterByGroup_Activated);
            this.Load += new System.EventHandler(this.frmEDCViewCharacterByGroup_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrompt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
#endregion
        
#region " Constant Definition "
        
        private const int COL_FACTORY = 0;
        private const int COL_CHAR_ID = 1;
        private const int COL_CHAR_DESC = 2;
        private const int COL_VALUE_TYPE = 3;
        private const int COL_UNIT = 4;
        private const int COL_TARGET_VALUE = 5;
        private const int COL_UPPER_SPEC_LIMIT = 6;
        private const int COL_LOWER_SPEC_LIMIT = 7;
        private const int COL_UPPER_WARN_LIMIT = 8;
        private const int COL_LOWER_WARN_LIMIT = 9;
        private const int COL_GRP_1 = 10;
        private const int COL_GRP_2 = 11;
        private const int COL_GRP_3 = 12;
        private const int COL_GRP_4 = 13;
        private const int COL_GRP_5 = 14;
        private const int COL_GRP_6 = 15;
        private const int COL_GRP_7 = 16;
        private const int COL_GRP_8 = 17;
        private const int COL_GRP_9 = 18;
        private const int COL_GRP_10 = 19;
        private const int COL_CMF_1 = 20;
        private const int COL_CMF_2 = 21;
        private const int COL_CMF_3 = 22;
        private const int COL_CMF_4 = 23;
        private const int COL_CMF_5 = 24;
        private const int COL_CMF_6 = 25;
        private const int COL_CMF_7 = 26;
        private const int COL_CMF_8 = 27;
        private const int COL_CMF_9 = 28;
        private const int COL_CMF_10 = 29;
        private const int COL_CREATE_USER = 30;
        private const int COL_CREATE_TIME = 31;
        private const int COL_UPDATE_USER = 32;
        private const int COL_UPDATE_TIME = 33;
        
#endregion
        
#region " Variable Definition "
        
        private bool LoadFlag;
        
        private string[] sGroupTableName = new string[10];
        
#endregion
        
#region " Function Definition "
        
        // SetTableName()
        //       - Set Operation Group Table Name
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private void SetTableName()
        {

            try
            {
                sGroupTableName[0] = MPGC.MP_GCM_CHAR_GRP_1;
                sGroupTableName[1] = MPGC.MP_GCM_CHAR_GRP_2;
                sGroupTableName[2] = MPGC.MP_GCM_CHAR_GRP_3;
                sGroupTableName[3] = MPGC.MP_GCM_CHAR_GRP_4;
                sGroupTableName[4] = MPGC.MP_GCM_CHAR_GRP_5;
                sGroupTableName[5] = MPGC.MP_GCM_CHAR_GRP_6;
                sGroupTableName[6] = MPGC.MP_GCM_CHAR_GRP_7;
                sGroupTableName[7] = MPGC.MP_GCM_CHAR_GRP_8;
                sGroupTableName[8] = MPGC.MP_GCM_CHAR_GRP_9;
                sGroupTableName[9] = MPGC.MP_GCM_CHAR_GRP_10;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        // SetCharGroupPrompt()
        //       - Set Group Property to control
        // Return Value
        //       -
        // Arguments
        //        -
        //
        
        private bool SetCharGroupPrompt(Miracom.UI.Controls.MCCodeView.MCCodeView cdvList)
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");

            ListViewItem itmx = null;
            int i = 0;

            try
            {
                cdvList.Items.Clear();

                if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_GRP_CHARACTER, ref out_node, "", true) == false)
                {
                    return false;
                }


                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")) != "")
                    {
                        itmx = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")), (int)(SMALLICON_INDEX.IDX_CODE_DATA));
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("TABLE_NAME")) == "")
                        {
                            itmx.SubItems.Add(sGroupTableName[i]);
                        }
                        else
                        {
                            itmx.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TABLE_NAME")));
                        }

                        cdvList.Items.Add(itmx);
                    }
                }

                cdvList.AddEmptyRow(1);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }        

        
        private bool View_Character_List()
        {
            TRSNode in_node = new TRSNode("View_Character_List_Detail_In");
            TRSNode out_node = new TRSNode("View_Character_List_Detail_Out");
            int i = 0;
            int iRow = 0;

            try
            {
                MPCR.SetInMsg(in_node);
                MPCF.ClearList(spdList, true);
                in_node.ProcStep = '1';
                in_node.AddString("GRP_TABLE_NAME", MPCF.Trim(cdvPrompt.DescText));
                in_node.AddString("GRP_VALUE", MPCF.Trim(cdvValue.Text));
                in_node.AddString("NEXT_CHAR_ID", "");

                do
                {
                    if (MPCR.CallService("EDC", "EDC_View_Character_List_Detail", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdList.Sheets[0].RowCount;
                        spdList.Sheets[0].RowCount++;

                        spdList.Sheets[0].Cells[iRow, COL_FACTORY].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("FACTORY"));
                        spdList.Sheets[0].Cells[iRow, COL_CHAR_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_ID"));
                        spdList.Sheets[0].Cells[iRow, COL_CHAR_DESC].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_DESC"));
                        spdList.Sheets[0].Cells[iRow, COL_VALUE_TYPE].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("VALUE_TYPE"));
                        spdList.Sheets[0].Cells[iRow, COL_UNIT].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UNIT"));
                        spdList.Sheets[0].Cells[iRow, COL_TARGET_VALUE].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TARGET_VALUE"));
                        spdList.Sheets[0].Cells[iRow, COL_UPPER_SPEC_LIMIT].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UPPER_SPEC_LIMIT"));
                        spdList.Sheets[0].Cells[iRow, COL_LOWER_SPEC_LIMIT].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOWER_SPEC_LIMIT"));
                        spdList.Sheets[0].Cells[iRow, COL_UPPER_WARN_LIMIT].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UPPER_WARN_LIMIT"));
                        spdList.Sheets[0].Cells[iRow, COL_LOWER_WARN_LIMIT].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOWER_WARN_LIMIT"));
                        spdList.Sheets[0].Cells[iRow, COL_GRP_1].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_GRP_1"));
                        spdList.Sheets[0].Cells[iRow, COL_GRP_2].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_GRP_2"));
                        spdList.Sheets[0].Cells[iRow, COL_GRP_3].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_GRP_3"));
                        spdList.Sheets[0].Cells[iRow, COL_GRP_4].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_GRP_4"));
                        spdList.Sheets[0].Cells[iRow, COL_GRP_5].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_GRP_5"));
                        spdList.Sheets[0].Cells[iRow, COL_GRP_6].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_GRP_6"));
                        spdList.Sheets[0].Cells[iRow, COL_GRP_7].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_GRP_7"));
                        spdList.Sheets[0].Cells[iRow, COL_GRP_8].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_GRP_8"));
                        spdList.Sheets[0].Cells[iRow, COL_GRP_9].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_GRP_9"));
                        spdList.Sheets[0].Cells[iRow, COL_GRP_10].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_GRP_10"));
                        spdList.Sheets[0].Cells[iRow, COL_CMF_1].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_CMF_1"));
                        spdList.Sheets[0].Cells[iRow, COL_CMF_2].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_CMF_2"));
                        spdList.Sheets[0].Cells[iRow, COL_CMF_3].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_CMF_3"));
                        spdList.Sheets[0].Cells[iRow, COL_CMF_4].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_CMF_4"));
                        spdList.Sheets[0].Cells[iRow, COL_CMF_5].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_CMF_5"));
                        spdList.Sheets[0].Cells[iRow, COL_CMF_6].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_CMF_6"));
                        spdList.Sheets[0].Cells[iRow, COL_CMF_7].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_CMF_7"));
                        spdList.Sheets[0].Cells[iRow, COL_CMF_8].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_CMF_8"));
                        spdList.Sheets[0].Cells[iRow, COL_CMF_9].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_CMF_9"));
                        spdList.Sheets[0].Cells[iRow, COL_CMF_10].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_CMF_10"));
                        spdList.Sheets[0].Cells[iRow, COL_CREATE_USER].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_USER_ID"));
                        spdList.Sheets[0].Cells[iRow, COL_CREATE_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME"));
                        spdList.Sheets[0].Cells[iRow, COL_UPDATE_USER].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_USER_ID"));
                        spdList.Sheets[0].Cells[iRow, COL_UPDATE_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("UPDATE_TIME"));

                    }

                    in_node.SetString("NEXT_CHAR_ID", out_node.GetString("NEXT_CHAR_ID"));
                } while (in_node.GetString("NEXT_CHAR_ID") != "");

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvPrompt;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
#endregion
        
        private void frmEDCViewCharacterByGroup_Load(object sender, System.EventArgs e)
        {
            
            try
            {

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmEDCViewCharacterByGroup_Activated(object sender, System.EventArgs e)
        {

            try
            {
                if (LoadFlag == false)
                {
                    MPCF.FieldClear(this);
                    MPCF.ClearList(spdList, true);
                    
                    SetTableName();
                    LoadFlag = true;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }        
            
        }
        
        private void cdvPrompt_ButtonPress(object sender, System.EventArgs e)
        {

            try
            {
                cdvPrompt.Init();
                MPCF.InitListView(cdvPrompt.GetListView);
                cdvPrompt.Columns.Add("Prompt", 50, HorizontalAlignment.Left);
                cdvPrompt.Columns.Add("TableName", 100, HorizontalAlignment.Left);
                cdvPrompt.SelectedSubItemIndex = 0;
                cdvPrompt.SelectedDescIndex = 1;
                cdvPrompt.ReadOnly = true;

                if (SetCharGroupPrompt((Miracom.UI.Controls.MCCodeView.MCCodeView)sender) == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvValue_ButtonPress(object sender, System.EventArgs e)
        {

            try
            {
                if (cdvPrompt.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvPrompt.Focus();
                    return;
                }
                
                cdvValue.Init();
                MPCF.InitListView(cdvValue.GetListView);
                cdvValue.Columns.Add("Group", 50, HorizontalAlignment.Left);
                cdvValue.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvValue.SelectedSubItemIndex = 0;
                cdvValue.SelectedDescIndex = 1;

                if (BASLIST.ViewGCMDataList(cdvValue.GetListView, '1', cdvPrompt.DescText) == false)
                {
                    return;
                }
                cdvValue.AddEmptyRow(1);

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
                if (MPCF.CheckValue(cdvPrompt, 1,false, false, "", "", "") == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvValue, 1) == false)
                {
                    return;
                }
                if (View_Character_List() == false)
                {
                    return;
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

            try
            {
                sCond = "Character Group - " + cdvPrompt.Text + " : " + cdvValue.Text;
                MPCF.ExportToExcel(spdList, this.Text, sCond);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvPrompt_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            try
            {
                cdvValue.DisplayText = "";
                cdvValue.Text = "";

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

#endif // _EDC
        
    }
    
}
