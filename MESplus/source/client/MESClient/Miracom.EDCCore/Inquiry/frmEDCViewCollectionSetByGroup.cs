
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
//   File Name   : frmEDCViewCollectionSetByGroup.vb
//   Description : MES Cient Form View Collection Set By Group
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - SetTableName() : Set Collection Set Group Table Name
//       - initCodeView() : initial CodeView Control
//       - SetColSetGroupPrompt() : Set Group Property to control
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
    public class frmEDCViewCollectionSetByGroup : Miracom.MESCore.ViewForm01
    {

#if _EDC
        
#region " Windows Form auto generated code "
        
        public frmEDCViewCollectionSetByGroup()
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
        



        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvValue;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvPrompt;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblPrompt;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvColSetID;
        private FarPoint.Win.Spread.FpSpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        private System.Windows.Forms.Label lblColSetID;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.cdvValue = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvPrompt = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.cdvColSetID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblColSetID = new System.Windows.Forms.Label();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrompt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvColSetID)).BeginInit();
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
            this.pnlViewTop.Size = new System.Drawing.Size(742, 100);
            this.pnlViewTop.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvColSetID);
            this.grpOption.Controls.Add(this.cdvValue);
            this.grpOption.Controls.Add(this.cdvPrompt);
            this.grpOption.Controls.Add(this.lblColSetID);
            this.grpOption.Controls.Add(this.lblValue);
            this.grpOption.Controls.Add(this.lblPrompt);
            this.grpOption.Location = new System.Drawing.Point(0, 5);
            this.grpOption.Size = new System.Drawing.Size(742, 95);
            this.grpOption.Text = "Collection Set Group";
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdList);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 100);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 413);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Collection Set by Group";
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
            this.cdvValue.TabIndex = 3;
            this.cdvValue.TextBoxToolTipText = "";
            this.cdvValue.TextBoxWidth = 200;
            this.cdvValue.VisibleButton = true;
            this.cdvValue.VisibleColumnHeader = false;
            this.cdvValue.VisibleDescription = true;
            this.cdvValue.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvValue_SelectedItemChanged);
            this.cdvValue.ButtonPress += new System.EventHandler(this.cdvValue_ButtonPress);
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
            this.cdvPrompt.TabIndex = 1;
            this.cdvPrompt.TextBoxToolTipText = "";
            this.cdvPrompt.TextBoxWidth = 200;
            this.cdvPrompt.VisibleButton = true;
            this.cdvPrompt.VisibleColumnHeader = false;
            this.cdvPrompt.VisibleDescription = true;
            this.cdvPrompt.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvPrompt_SelectedItemChanged);
            this.cdvPrompt.ButtonPress += new System.EventHandler(this.cdvPrompt_ButtonPress);
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.Location = new System.Drawing.Point(15, 43);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(39, 13);
            this.lblValue.TabIndex = 2;
            this.lblValue.Text = "Value";
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
            // cdvColSetID
            // 
            this.cdvColSetID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvColSetID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvColSetID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvColSetID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvColSetID.BtnToolTipText = "";
            this.cdvColSetID.DescText = "";
            this.cdvColSetID.DisplaySubItemIndex = 0;
            this.cdvColSetID.DisplayText = "";
            this.cdvColSetID.Focusing = null;
            this.cdvColSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvColSetID.Index = 0;
            this.cdvColSetID.IsViewBtnImage = false;
            this.cdvColSetID.Location = new System.Drawing.Point(120, 64);
            this.cdvColSetID.MaxLength = 25;
            this.cdvColSetID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvColSetID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvColSetID.Name = "cdvColSetID";
            this.cdvColSetID.ReadOnly = false;
            this.cdvColSetID.SearchSubItemIndex = 0;
            this.cdvColSetID.SelectedDescIndex = 1;
            this.cdvColSetID.SelectedSubItemIndex = 0;
            this.cdvColSetID.SelectionStart = 0;
            this.cdvColSetID.Size = new System.Drawing.Size(420, 20);
            this.cdvColSetID.SmallImageList = null;
            this.cdvColSetID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvColSetID.TabIndex = 5;
            this.cdvColSetID.TextBoxToolTipText = "";
            this.cdvColSetID.TextBoxWidth = 200;
            this.cdvColSetID.VisibleButton = true;
            this.cdvColSetID.VisibleColumnHeader = false;
            this.cdvColSetID.VisibleDescription = true;
            this.cdvColSetID.ButtonPress += new System.EventHandler(this.cdvColSetID_ButtonPress);
            // 
            // lblColSetID
            // 
            this.lblColSetID.AutoSize = true;
            this.lblColSetID.Location = new System.Drawing.Point(15, 67);
            this.lblColSetID.Name = "lblColSetID";
            this.lblColSetID.Size = new System.Drawing.Size(86, 13);
            this.lblColSetID.TabIndex = 4;
            this.lblColSetID.Text = "Collection Set ID";
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
            this.spdList.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Rows;
            this.spdList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdList_Sheet1});
            this.spdList.Size = new System.Drawing.Size(742, 408);
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
            this.spdList.SetActiveViewport(0, -1, -1);
            // 
            // spdList_Sheet1
            // 
            this.spdList_Sheet1.Reset();
            spdList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdList_Sheet1.ColumnCount = 36;
            spdList_Sheet1.RowCount = 0;
            this.spdList_Sheet1.ActiveColumnIndex = -1;
            this.spdList_Sheet1.ActiveRowIndex = -1;
            this.spdList_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Collection Set ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Description";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Character Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Character";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Description";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Unit Count";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Value Count";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Display Precision";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Value Table";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Default Value";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Option Input";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Blank Save";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Default Unit";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Default Unit Ovr.";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Unit Table";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Spec. Type";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Spec. Out Count";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Target Value";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Upper Spec. Limit";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Lower Spec. Limit";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Upper Warn. Limit";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Lower Warn. Limit";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Spec. Information";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Spec. Out Alarm Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Warn. Out Alarm Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Derived Parameter Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Derived Parameter";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Approval Require Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Approval User ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Delete Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Delete User ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Delete Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Create User ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Create Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Update User ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "Update Time";
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnHeader.Rows.Get(0).Height = 32F;
            this.spdList_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(0).Label = "Collection Set ID";
            this.spdList_Sheet1.Columns.Get(0).Locked = true;
            this.spdList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(0).Width = 100F;
            this.spdList_Sheet1.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(1).Label = "Description";
            this.spdList_Sheet1.Columns.Get(1).Locked = true;
            this.spdList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(1).Width = 120F;
            this.spdList_Sheet1.Columns.Get(2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(2).Label = "Character Seq";
            this.spdList_Sheet1.Columns.Get(2).Locked = true;
            this.spdList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(2).Width = 58F;
            this.spdList_Sheet1.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(3).Label = "Character";
            this.spdList_Sheet1.Columns.Get(3).Locked = true;
            this.spdList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(3).Width = 100F;
            this.spdList_Sheet1.Columns.Get(4).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(4).Label = "Description";
            this.spdList_Sheet1.Columns.Get(4).Locked = true;
            this.spdList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(4).Width = 120F;
            this.spdList_Sheet1.Columns.Get(5).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(5).Label = "Unit Count";
            this.spdList_Sheet1.Columns.Get(5).Locked = true;
            this.spdList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(5).Width = 40F;
            this.spdList_Sheet1.Columns.Get(6).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(6).Label = "Value Count";
            this.spdList_Sheet1.Columns.Get(6).Locked = true;
            this.spdList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(6).Width = 40F;
            this.spdList_Sheet1.Columns.Get(7).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(7).Label = "Display Precision";
            this.spdList_Sheet1.Columns.Get(7).Locked = true;
            this.spdList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(7).Width = 55F;
            this.spdList_Sheet1.Columns.Get(8).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(8).Label = "Value Table";
            this.spdList_Sheet1.Columns.Get(8).Locked = true;
            this.spdList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(8).Width = 100F;
            this.spdList_Sheet1.Columns.Get(9).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdList_Sheet1.Columns.Get(9).Label = "Default Value";
            this.spdList_Sheet1.Columns.Get(9).Locked = true;
            this.spdList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(9).Width = 100F;
            this.spdList_Sheet1.Columns.Get(10).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(10).Label = "Option Input";
            this.spdList_Sheet1.Columns.Get(10).Locked = true;
            this.spdList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(10).Width = 40F;
            this.spdList_Sheet1.Columns.Get(11).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(11).Label = "Blank Save";
            this.spdList_Sheet1.Columns.Get(11).Locked = true;
            this.spdList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(11).Width = 40F;
            this.spdList_Sheet1.Columns.Get(12).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(12).Label = "Default Unit";
            this.spdList_Sheet1.Columns.Get(12).Locked = true;
            this.spdList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(12).Width = 45F;
            this.spdList_Sheet1.Columns.Get(13).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(13).Label = "Default Unit Ovr.";
            this.spdList_Sheet1.Columns.Get(13).Locked = true;
            this.spdList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(13).Width = 55F;
            this.spdList_Sheet1.Columns.Get(14).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(14).Label = "Unit Table";
            this.spdList_Sheet1.Columns.Get(14).Locked = true;
            this.spdList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(14).Width = 100F;
            this.spdList_Sheet1.Columns.Get(15).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(15).Label = "Spec. Type";
            this.spdList_Sheet1.Columns.Get(15).Locked = true;
            this.spdList_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(15).Width = 40F;
            this.spdList_Sheet1.Columns.Get(16).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(16).Label = "Spec. Out Count";
            this.spdList_Sheet1.Columns.Get(16).Locked = true;
            this.spdList_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(17).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdList_Sheet1.Columns.Get(17).Label = "Target Value";
            this.spdList_Sheet1.Columns.Get(17).Locked = true;
            this.spdList_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(17).Width = 100F;
            this.spdList_Sheet1.Columns.Get(18).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(18).Label = "Upper Spec. Limit";
            this.spdList_Sheet1.Columns.Get(18).Locked = true;
            this.spdList_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(18).Width = 100F;
            this.spdList_Sheet1.Columns.Get(19).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(19).Label = "Lower Spec. Limit";
            this.spdList_Sheet1.Columns.Get(19).Locked = true;
            this.spdList_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(19).Width = 100F;
            this.spdList_Sheet1.Columns.Get(20).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(20).Label = "Upper Warn. Limit";
            this.spdList_Sheet1.Columns.Get(20).Locked = true;
            this.spdList_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(20).Width = 100F;
            this.spdList_Sheet1.Columns.Get(21).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(21).Label = "Lower Warn. Limit";
            this.spdList_Sheet1.Columns.Get(21).Locked = true;
            this.spdList_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(21).Width = 100F;
            this.spdList_Sheet1.Columns.Get(22).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(22).Label = "Spec. Information";
            this.spdList_Sheet1.Columns.Get(22).Locked = true;
            this.spdList_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(22).Width = 200F;
            this.spdList_Sheet1.Columns.Get(23).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(23).Label = "Spec. Out Alarm Code";
            this.spdList_Sheet1.Columns.Get(23).Locked = true;
            this.spdList_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(23).Width = 80F;
            this.spdList_Sheet1.Columns.Get(24).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(24).Label = "Warn. Out Alarm Code";
            this.spdList_Sheet1.Columns.Get(24).Locked = true;
            this.spdList_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(24).Width = 80F;
            this.spdList_Sheet1.Columns.Get(25).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(25).Label = "Derived Parameter Flag";
            this.spdList_Sheet1.Columns.Get(25).Locked = true;
            this.spdList_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(25).Width = 85F;
            this.spdList_Sheet1.Columns.Get(26).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(26).Label = "Derived Parameter";
            this.spdList_Sheet1.Columns.Get(26).Locked = true;
            this.spdList_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(26).Width = 200F;
            this.spdList_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(27).Label = "Approval Require Flag";
            this.spdList_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(27).Width = 75F;
            this.spdList_Sheet1.Columns.Get(28).Label = "Approval User ID";
            this.spdList_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(28).Width = 90F;
            this.spdList_Sheet1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(29).Label = "Delete Flag";
            this.spdList_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(29).Width = 40F;
            this.spdList_Sheet1.Columns.Get(30).Label = "Delete User ID";
            this.spdList_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(30).Width = 85F;
            this.spdList_Sheet1.Columns.Get(31).Label = "Delete Time";
            this.spdList_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(31).Width = 110F;
            this.spdList_Sheet1.Columns.Get(32).Label = "Create User ID";
            this.spdList_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(32).Width = 85F;
            this.spdList_Sheet1.Columns.Get(33).Label = "Create Time";
            this.spdList_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(33).Width = 110F;
            this.spdList_Sheet1.Columns.Get(34).Label = "Update User ID";
            this.spdList_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(34).Width = 85F;
            this.spdList_Sheet1.Columns.Get(35).Label = "Update Time";
            this.spdList_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(35).Width = 110F;
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
            // frmEDCViewCollectionSetByGroup
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmEDCViewCollectionSetByGroup";
            this.Text = "View Collection Set by Group";
            this.Activated += new System.EventHandler(this.frmEDCViewCharacterByGroup_Activated);
            this.Load += new System.EventHandler(this.frmEDCViewCharacterByGroup_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrompt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvColSetID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
#endregion
        
#region " Constant Definition "
        
        private const int COL_COL_SET_ID = 0;
        private const int COL_COL_SET_DESC = 1;
        private const int COL_SEQ_NUM = 2;
        private const int COL_CHAR_ID = 3;
        private const int COL_CHAR_DESC = 4;
        private const int COL_UNIT_COUNT = 5;
        private const int COL_VALUE_COUNT = 6;
        private const int COL_DISPLAY_PRECISION = 7;
        private const int COL_VALUE_TBL = 8;
        private const int COL_DEF_VALUE = 9;
        private const int COL_OPT_INPUT_FLAG = 10;
        private const int COL_BLANK_REC_SAVE_FLAG = 11;
        private const int COL_DEF_UNIT_FLAG = 12;
        private const int COL_DEF_UNIT_OVR_FLAG = 13;
        private const int COL_UNIT_TBL = 14;
        private const int COL_SPEC_TYPE = 15;
        private const int COL_SPEC_OUT_COUNT = 16;
        private const int COL_TARGET_VALUE = 17;
        private const int COL_UPPER_SPEC_LIMIT = 18;
        private const int COL_LOWER_SPEC_LIMIT = 19;
        private const int COL_UPPER_WARN_LIMIT = 20;
        private const int COL_LOWER_WARN_LIMIT = 21;
        private const int COL_SPEC_INFO = 22;
        private const int COL_SPEC_OUT_ALARM = 23;
        private const int COL_WARN_OUT_ALARM = 24;
        private const int COL_DERIVED_PARAM_FLAG = 25;
        private const int COL_DERIVED_PARAMETER = 26;
        private const int COL_APPROVAL_REQUIRE_FLAG = 27;
        private const int COL_APPROVAL_USER_ID = 28;
        private const int COL_DELETE_FLAG = 29;
        private const int COL_DELETE_USER_ID = 30;
        private const int COL_DELETE_TIME = 31;
        private const int COL_CREATE_USER_ID = 32;
        private const int COL_CREATE_TIME = 33;
        private const int COL_UPDATE_USER_ID = 34;
        private const int COL_UPDATE_TIME = 35;
                          
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
                sGroupTableName[0] = MPGC.MP_GCM_COL_GRP_1;
                sGroupTableName[1] = MPGC.MP_GCM_COL_GRP_2;
                sGroupTableName[2] = MPGC.MP_GCM_COL_GRP_3;
                sGroupTableName[3] = MPGC.MP_GCM_COL_GRP_4;
                sGroupTableName[4] = MPGC.MP_GCM_COL_GRP_5;
                sGroupTableName[5] = MPGC.MP_GCM_COL_GRP_6;
                sGroupTableName[6] = MPGC.MP_GCM_COL_GRP_7;
                sGroupTableName[7] = MPGC.MP_GCM_COL_GRP_8;
                sGroupTableName[8] = MPGC.MP_GCM_COL_GRP_9;
                sGroupTableName[9] = MPGC.MP_GCM_COL_GRP_10;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        // SetColSetGroupPrompt()
        //       - Set Group Property to control
        // Return Value
        //       -
        // Arguments
        //        -
        //
        
        private bool SetColSetGroupPrompt(Miracom.UI.Controls.MCCodeView.MCCodeView cdvList)
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            ListViewItem itmx = null;
            int i = 0;

            try
            {
                cdvList.Items.Clear();

                if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_GRP_COL_SET, ref out_node, "", true) == false)
                {
                    return false;
                }
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")) != "")
                    {
                        itmx = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")), (int)SMALLICON_INDEX.IDX_CODE_DATA);

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


        // View_ColSet_List_By_Group()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool View_ColSet_List_By_Group(ListView lisList)
        {
            TRSNode in_node = new TRSNode("View_Col_Set_List_In");
            TRSNode out_node = new TRSNode("View_Col_Set_List_Out");
            int i = 0;
            ListViewItem itmX = null;

            try
            {
                MPCF.ClearList(lisList, true);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("GRP_TABLE_NAME", MPCF.Trim(cdvPrompt.DescText));
                in_node.AddString("GRP_VALUE", MPCF.Trim(cdvValue.Text));
                in_node.AddString("NEXT_COL_SET_ID", "");
                in_node.AddChar("LOT_OR_RES_FLAG", ' ');
                in_node.AddChar("INCLUDE_DEL_FLAG", ' ');

                do
                {
                    if (MPCR.CallService("EDC", "EDC_View_Col_Set_List_By_Group", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("COL_SET_ID")), (int)SMALLICON_INDEX.IDX_COL_SET);
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("COL_SET_DESC")));
                        lisList.Items.Add(itmX);
                    }

                    in_node.SetString("NEXT_COL_SET_ID", out_node.GetString("NEXT_COL_SET_ID"));
                } while (in_node.GetString("NEXT_COL_SET_ID") != "");

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
        }
        
        // View_ColSet_List()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool View_ColSet_List()
        {
            TRSNode in_node = new TRSNode("View_Col_Set_List_Detail_In");
            TRSNode out_node = new TRSNode("View_Col_Set_List_Detail_Out");
            int i = 0;
            int iRow = 0;

            try
            {
                MPCF.ClearList(spdList, true);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("GRP_TABLE_NAME", MPCF.Trim(cdvPrompt.DescText));
                in_node.AddString("GRP_VALUE", MPCF.Trim(cdvValue.Text));
                in_node.AddString("NEXT_COL_SET_ID", MPCF.Trim(cdvColSetID.Text));
                in_node.AddInt("NEXT_CHAR_SEQ", 0);
                in_node.AddChar("LOT_OR_RES_FLAG", ' ');
                in_node.AddChar("INCLUDE_DEL_FLAG", ' ');
                
                if (cdvColSetID.Text == "")
                {
                    in_node.ProcStep = '1';  // All
                }
                else
                {
                    in_node.ProcStep = '2';  // Selected Collection Set
                }

                do
                {
                    if (MPCR.CallService("EDC", "EDC_View_Col_Set_List_Detail", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdList.Sheets[0].RowCount;
                        spdList.Sheets[0].RowCount++;

                        spdList.Sheets[0].Cells[iRow, COL_COL_SET_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("COL_SET_ID)"));
                        spdList.Sheets[0].Cells[iRow, COL_COL_SET_DESC].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("COL_SET_DESC"));
                        spdList.Sheets[0].Cells[iRow, COL_SEQ_NUM].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("SEQ_NUM"));
                        spdList.Sheets[0].Cells[iRow, COL_CHAR_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_ID"));
                        spdList.Sheets[0].Cells[iRow, COL_CHAR_DESC].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CHAR_DESC"));
                        spdList.Sheets[0].Cells[iRow, COL_UNIT_COUNT].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("UNIT_COUNT"));
                        spdList.Sheets[0].Cells[iRow, COL_VALUE_COUNT].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("VALUE_COUNT"));
                        spdList.Sheets[0].Cells[iRow, COL_DISPLAY_PRECISION].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("DISPLAY_PRECISION"));
                        spdList.Sheets[0].Cells[iRow, COL_VALUE_TBL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("VALUE_TBL"));
                        spdList.Sheets[0].Cells[iRow, COL_DEF_VALUE].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("DEF_VALUE"));
                        spdList.Sheets[0].Cells[iRow, COL_OPT_INPUT_FLAG].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("OPT_INPUT_FLAG"));
                        spdList.Sheets[0].Cells[iRow, COL_BLANK_REC_SAVE_FLAG].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("BLANK_REC_SAVE_FLAG"));
                        spdList.Sheets[0].Cells[iRow, COL_DEF_UNIT_FLAG].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("DEF_UNIT_FLAG"));
                        spdList.Sheets[0].Cells[iRow, COL_DEF_UNIT_OVR_FLAG].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("DEF_UNIT_OVR_FLAG"));
                        spdList.Sheets[0].Cells[iRow, COL_UNIT_TBL].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UNIT_TBL"));
                        spdList.Sheets[0].Cells[iRow, COL_SPEC_TYPE].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("SPEC_TYPE"));
                        spdList.Sheets[0].Cells[iRow, COL_SPEC_OUT_COUNT].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("SPEC_OUT_COUNT"));
                        spdList.Sheets[0].Cells[iRow, COL_TARGET_VALUE].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TARGET_VALUE"));
                        spdList.Sheets[0].Cells[iRow, COL_UPPER_SPEC_LIMIT].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UPPER_SPEC_LIMIT"));
                        spdList.Sheets[0].Cells[iRow, COL_LOWER_SPEC_LIMIT].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOWER_SPEC_LIMIT"));
                        spdList.Sheets[0].Cells[iRow, COL_UPPER_WARN_LIMIT].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UPPER_WARN_LIMIT"));
                        spdList.Sheets[0].Cells[iRow, COL_LOWER_WARN_LIMIT].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("LOWER_WARN_LIMIT"));
                        spdList.Sheets[0].Cells[iRow, COL_SPEC_INFO].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("SPEC_INFO"));
                        spdList.Sheets[0].Cells[iRow, COL_SPEC_OUT_ALARM].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("SPEC_OUT_ALARM"));
                        spdList.Sheets[0].Cells[iRow, COL_WARN_OUT_ALARM].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("WARN_OUT_ALARM"));
                        spdList.Sheets[0].Cells[iRow, COL_DERIVED_PARAM_FLAG].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("DERIVED_PARAM_FLAG"));
                        spdList.Sheets[0].Cells[iRow, COL_DERIVED_PARAMETER].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("DERIVED_PARAMETER"));
                        spdList.Sheets[0].Cells[iRow, COL_APPROVAL_REQUIRE_FLAG].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("APPROVAL_REQUIRE_FLAG"));
                        spdList.Sheets[0].Cells[iRow, COL_APPROVAL_USER_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("APPROVAL_USER_ID"));
                        spdList.Sheets[0].Cells[iRow, COL_DELETE_FLAG].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("DELETE_FLAG"));
                        spdList.Sheets[0].Cells[iRow, COL_DELETE_USER_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("DELETE_USER_ID"));
                        spdList.Sheets[0].Cells[iRow, COL_DELETE_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("DELETE_TIME"));
                        spdList.Sheets[0].Cells[iRow, COL_CREATE_USER_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_USER_ID"));
                        spdList.Sheets[0].Cells[iRow, COL_CREATE_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME"));
                        spdList.Sheets[0].Cells[iRow, COL_UPDATE_USER_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_USER_ID"));
                        spdList.Sheets[0].Cells[iRow, COL_UPDATE_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("UPDATE_TIME"));

                    }

                    in_node.SetString("NEXT_COL_SET_ID", out_node.GetString("NEXT_COL_SET_ID"));
                    in_node.SetInt("NEXT_CHAR_SEQ", out_node.GetInt("NEXT_CHAR_SEQ"));

                } while (in_node.GetString("NEXT_COL_SET_ID") != "" || in_node.GetInt("NEXT_CHAR_SEQ") > 0);

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

                if (SetColSetGroupPrompt((Miracom.UI.Controls.MCCodeView.MCCodeView)sender) == false)
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
        
        private void cdvValue_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            try
            {
                cdvColSetID.Text = "";
                cdvColSetID.DescText = "";

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
                if (MPCF.CheckValue(cdvPrompt, 1) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvValue, 1) == false)
                {
                    return;
                }
                if (View_ColSet_List() == false)
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
                sCond = "Collection Set Group - " + cdvPrompt.Text + " : " + cdvValue.Text;
                if (cdvColSetID.Text != "")
                {
                    sCond = sCond + "\r" + "Collection Set ID : " + cdvColSetID.Text;
                }

                if (MPCF.ExportToExcel(spdList, this.Text, sCond, true, true, true, -1, -1) == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }    
            
        }
        
        private void cdvColSetID_ButtonPress(object sender, System.EventArgs e)
        {

            try
            {
                if (MPCF.CheckValue(cdvPrompt, 1) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvValue, 1) == false)
                {
                    return;
                }

                cdvColSetID.Init();
                MPCF.InitListView(cdvColSetID.GetListView);
                cdvColSetID.Columns.Add("Value", 50, HorizontalAlignment.Left);
                cdvColSetID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvColSetID.SelectedSubItemIndex = 0;
                cdvColSetID.SelectedDescIndex = 1;

                if (View_ColSet_List_By_Group(cdvColSetID.GetListView) == false)
                {
                    return;
                }

                cdvColSetID.AddEmptyRow(1);

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
                cdvValue.Text = "";
                cdvValue.DisplayText = "";

                cdvColSetID.Text = "";
                cdvColSetID.DescText = "";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
#endif // _EDC
        
    }
    
}
