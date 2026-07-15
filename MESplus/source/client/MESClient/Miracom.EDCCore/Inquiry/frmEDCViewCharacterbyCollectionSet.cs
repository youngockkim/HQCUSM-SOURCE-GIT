
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

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmEDCViewCharacterbyCollectionSet.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -  CheckCondition() : Check the conditions before transaction
//       -  View_Col_Set_Version_List() : View Collection Set Version
//       -  View_Character_By_Collection_List() : View Character List by Collection Set
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-22 : Created by W.Y. Choi
//       - 2008-01-18 : Modified by LAVERWON
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports


namespace Miracom.EDCCore
{
    public class frmEDCViewCharacterbyCollectionSet : Miracom.MESCore.TranForm01
    {

#if _EDC
        
#region " Windows Form auto generated code "
        
        public frmEDCViewCharacterbyCollectionSet()
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
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCollectionSet;
        private System.Windows.Forms.Label lblCollectionSet;
        private System.Windows.Forms.Panel pnlVersion;
        private System.Windows.Forms.Panel pnlCharacterList;
        private System.Windows.Forms.Panel pnlVersionList;
        public System.Windows.Forms.Button btnExcel;
        private FarPoint.Win.Spread.FpSpread spdVersion;
        private FarPoint.Win.Spread.SheetView spdVersion_Sheet1;
        private Splitter spCenter;
        private FarPoint.Win.Spread.FpSpread spdCharacter;
        private FarPoint.Win.Spread.SheetView spdCharacter_Sheet1;
        private System.Windows.Forms.Button btnUnit;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEDCViewCharacterbyCollectionSet));
            this.pnlGrp = new System.Windows.Forms.Panel();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.cdvCollectionSet = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCollectionSet = new System.Windows.Forms.Label();
            this.pnlVersion = new System.Windows.Forms.Panel();
            this.pnlCharacterList = new System.Windows.Forms.Panel();
            this.spdCharacter = new FarPoint.Win.Spread.FpSpread();
            this.spdCharacter_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.spCenter = new System.Windows.Forms.Splitter();
            this.pnlVersionList = new System.Windows.Forms.Panel();
            this.spdVersion = new FarPoint.Win.Spread.FpSpread();
            this.spdVersion_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnUnit = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlGrp.SuspendLayout();
            this.grpOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCollectionSet)).BeginInit();
            this.pnlVersion.SuspendLayout();
            this.pnlCharacterList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCharacter_Sheet1)).BeginInit();
            this.pnlVersionList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(466, 8);
            this.btnProcess.Text = "View";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnUnit);
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 3;
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUnit, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 553);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Character by Collection Set";
            // 
            // pnlGrp
            // 
            this.pnlGrp.Controls.Add(this.grpOption);
            this.pnlGrp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGrp.Location = new System.Drawing.Point(0, 0);
            this.pnlGrp.Name = "pnlGrp";
            this.pnlGrp.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlGrp.Size = new System.Drawing.Size(742, 47);
            this.pnlGrp.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvCollectionSet);
            this.grpOption.Controls.Add(this.lblCollectionSet);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOption.Location = new System.Drawing.Point(3, 0);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(736, 47);
            this.grpOption.TabIndex = 0;
            this.grpOption.TabStop = false;
            // 
            // cdvCollectionSet
            // 
            this.cdvCollectionSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvCollectionSet.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCollectionSet.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCollectionSet.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCollectionSet.BtnToolTipText = "";
            this.cdvCollectionSet.DescText = "";
            this.cdvCollectionSet.DisplaySubItemIndex = 0;
            this.cdvCollectionSet.DisplayText = "";
            this.cdvCollectionSet.Focusing = null;
            this.cdvCollectionSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCollectionSet.Index = 0;
            this.cdvCollectionSet.IsViewBtnImage = false;
            this.cdvCollectionSet.Location = new System.Drawing.Point(120, 16);
            this.cdvCollectionSet.MaxLength = 25;
            this.cdvCollectionSet.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCollectionSet.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCollectionSet.Name = "cdvCollectionSet";
            this.cdvCollectionSet.ReadOnly = false;
            this.cdvCollectionSet.SearchSubItemIndex = 0;
            this.cdvCollectionSet.SelectedDescIndex = 1;
            this.cdvCollectionSet.SelectedSubItemIndex = 0;
            this.cdvCollectionSet.SelectionStart = 0;
            this.cdvCollectionSet.Size = new System.Drawing.Size(420, 20);
            this.cdvCollectionSet.SmallImageList = null;
            this.cdvCollectionSet.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCollectionSet.TabIndex = 0;
            this.cdvCollectionSet.TextBoxToolTipText = "";
            this.cdvCollectionSet.TextBoxWidth = 200;
            this.cdvCollectionSet.VisibleButton = true;
            this.cdvCollectionSet.VisibleColumnHeader = false;
            this.cdvCollectionSet.VisibleDescription = true;
            this.cdvCollectionSet.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCollectionSet_SelectedItemChanged);
            this.cdvCollectionSet.ButtonPress += new System.EventHandler(this.cdvCollectionSet_ButtonPress);
            this.cdvCollectionSet.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCollectionSet_KeyPress);
            this.cdvCollectionSet.TextBoxTextChanged += new System.EventHandler(this.cdvCollectionSet_TextBoxTextChanged);
            // 
            // lblCollectionSet
            // 
            this.lblCollectionSet.AutoSize = true;
            this.lblCollectionSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCollectionSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollectionSet.Location = new System.Drawing.Point(15, 19);
            this.lblCollectionSet.Name = "lblCollectionSet";
            this.lblCollectionSet.Size = new System.Drawing.Size(86, 13);
            this.lblCollectionSet.TabIndex = 0;
            this.lblCollectionSet.Text = "Collection Set";
            // 
            // pnlVersion
            // 
            this.pnlVersion.Controls.Add(this.pnlCharacterList);
            this.pnlVersion.Controls.Add(this.spCenter);
            this.pnlVersion.Controls.Add(this.pnlVersionList);
            this.pnlVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVersion.Location = new System.Drawing.Point(0, 47);
            this.pnlVersion.Name = "pnlVersion";
            this.pnlVersion.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlVersion.Size = new System.Drawing.Size(742, 466);
            this.pnlVersion.TabIndex = 1;
            // 
            // pnlCharacterList
            // 
            this.pnlCharacterList.Controls.Add(this.spdCharacter);
            this.pnlCharacterList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCharacterList.Location = new System.Drawing.Point(3, 206);
            this.pnlCharacterList.Name = "pnlCharacterList";
            this.pnlCharacterList.Size = new System.Drawing.Size(736, 260);
            this.pnlCharacterList.TabIndex = 0;
            // 
            // spdCharacter
            // 
            this.spdCharacter.AccessibleDescription = "spdCharacter, Sheet1, Row 0, Column 0, ";
            this.spdCharacter.BackColor = System.Drawing.SystemColors.Control;
            this.spdCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdCharacter.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdCharacter.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCharacter.HorizontalScrollBar.Name = "";
            this.spdCharacter.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdCharacter.HorizontalScrollBar.TabIndex = 2;
            this.spdCharacter.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCharacter.Location = new System.Drawing.Point(0, 0);
            this.spdCharacter.Name = "spdCharacter";
            this.spdCharacter.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdCharacter.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdCharacter.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Rows;
            this.spdCharacter.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdCharacter_Sheet1});
            this.spdCharacter.Size = new System.Drawing.Size(736, 260);
            this.spdCharacter.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdCharacter.TabIndex = 1;
            this.spdCharacter.TabStop = false;
            this.spdCharacter.TextTipDelay = 200;
            this.spdCharacter.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdCharacter.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCharacter.VerticalScrollBar.Name = "";
            this.spdCharacter.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdCharacter.VerticalScrollBar.TabIndex = 3;
            this.spdCharacter.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCharacter.SetViewportLeftColumn(0, 0, 2);
            this.spdCharacter.SetActiveViewport(0, -1, -1);
            // 
            // spdCharacter_Sheet1
            // 
            this.spdCharacter_Sheet1.Reset();
            spdCharacter_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdCharacter_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdCharacter_Sheet1.ColumnCount = 24;
            spdCharacter_Sheet1.RowCount = 0;
            this.spdCharacter_Sheet1.ActiveColumnIndex = -1;
            this.spdCharacter_Sheet1.ActiveRowIndex = -1;
            this.spdCharacter_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdCharacter_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCharacter_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdCharacter_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCharacter_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Character";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Description";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Unit Count";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Value Count";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Display Precision";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Value Table";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Default Value";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Option Input";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Blank Save";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Default Unit";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Default Unit Ovr.";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Unit Table";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Spec. Type";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Spec. Out Count";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Target Value";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Upper Spec. Limit";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Lower Spec. Limit";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Upper Warn. Limit";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Lower Warn. Limit";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Spec. Information";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Spec. Out Alarm Code";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Warn. Out Alarm Code";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Derived Parameter Flag";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Derived Parameter";
            this.spdCharacter_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCharacter_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdCharacter_Sheet1.ColumnHeader.Rows.Get(0).Height = 32F;
            this.spdCharacter_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCharacter_Sheet1.Columns.Get(0).Label = "Character";
            this.spdCharacter_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(0).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCharacter_Sheet1.Columns.Get(1).Label = "Description";
            this.spdCharacter_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(1).Width = 120F;
            this.spdCharacter_Sheet1.Columns.Get(2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(2).Label = "Unit Count";
            this.spdCharacter_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(2).Width = 40F;
            this.spdCharacter_Sheet1.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(3).Label = "Value Count";
            this.spdCharacter_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(3).Width = 40F;
            this.spdCharacter_Sheet1.Columns.Get(4).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(4).Label = "Display Precision";
            this.spdCharacter_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(4).Width = 55F;
            this.spdCharacter_Sheet1.Columns.Get(5).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCharacter_Sheet1.Columns.Get(5).Label = "Value Table";
            this.spdCharacter_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(5).Width = 40F;
            this.spdCharacter_Sheet1.Columns.Get(6).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdCharacter_Sheet1.Columns.Get(6).Label = "Default Value";
            this.spdCharacter_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(6).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(7).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(7).Label = "Option Input";
            this.spdCharacter_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(7).Width = 40F;
            this.spdCharacter_Sheet1.Columns.Get(8).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(8).Label = "Blank Save";
            this.spdCharacter_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(8).Width = 40F;
            this.spdCharacter_Sheet1.Columns.Get(9).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(9).Label = "Default Unit";
            this.spdCharacter_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(9).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(10).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(10).Label = "Default Unit Ovr.";
            this.spdCharacter_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(11).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCharacter_Sheet1.Columns.Get(11).Label = "Unit Table";
            this.spdCharacter_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(11).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(12).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(12).Label = "Spec. Type";
            this.spdCharacter_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(12).Width = 40F;
            this.spdCharacter_Sheet1.Columns.Get(13).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(13).Label = "Spec. Out Count";
            this.spdCharacter_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(14).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdCharacter_Sheet1.Columns.Get(14).Label = "Target Value";
            this.spdCharacter_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(14).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(15).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(15).Label = "Upper Spec. Limit";
            this.spdCharacter_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(15).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(16).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(16).Label = "Lower Spec. Limit";
            this.spdCharacter_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(16).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(17).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(17).Label = "Upper Warn. Limit";
            this.spdCharacter_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(17).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(18).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(18).Label = "Lower Warn. Limit";
            this.spdCharacter_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(18).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(19).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCharacter_Sheet1.Columns.Get(19).Label = "Spec. Information";
            this.spdCharacter_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(19).Width = 200F;
            this.spdCharacter_Sheet1.Columns.Get(20).Label = "Spec. Out Alarm Code";
            this.spdCharacter_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(20).Width = 80F;
            this.spdCharacter_Sheet1.Columns.Get(21).Label = "Warn. Out Alarm Code";
            this.spdCharacter_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(21).Width = 80F;
            this.spdCharacter_Sheet1.Columns.Get(22).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(22).Label = "Derived Parameter Flag";
            this.spdCharacter_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(22).Width = 85F;
            this.spdCharacter_Sheet1.Columns.Get(23).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCharacter_Sheet1.Columns.Get(23).Label = "Derived Parameter";
            this.spdCharacter_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(23).Width = 200F;
            this.spdCharacter_Sheet1.FrozenColumnCount = 2;
            this.spdCharacter_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdCharacter_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.spdCharacter_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdCharacter_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCharacter_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdCharacter_Sheet1.Rows.Default.Height = 18F;
            this.spdCharacter_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdCharacter_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCharacter_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdCharacter_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdCharacter_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // spCenter
            // 
            this.spCenter.Dock = System.Windows.Forms.DockStyle.Top;
            this.spCenter.Location = new System.Drawing.Point(3, 203);
            this.spCenter.Name = "spCenter";
            this.spCenter.Size = new System.Drawing.Size(736, 3);
            this.spCenter.TabIndex = 4;
            this.spCenter.TabStop = false;
            // 
            // pnlVersionList
            // 
            this.pnlVersionList.Controls.Add(this.spdVersion);
            this.pnlVersionList.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlVersionList.Location = new System.Drawing.Point(3, 3);
            this.pnlVersionList.Name = "pnlVersionList";
            this.pnlVersionList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.pnlVersionList.Size = new System.Drawing.Size(736, 200);
            this.pnlVersionList.TabIndex = 0;
            // 
            // spdVersion
            // 
            this.spdVersion.AccessibleDescription = "spdVersion, Sheet1, Row 0, Column 0, ";
            this.spdVersion.BackColor = System.Drawing.SystemColors.Control;
            this.spdVersion.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
            this.spdVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdVersion.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdVersion.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdVersion.HorizontalScrollBar.Name = "";
            this.spdVersion.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdVersion.HorizontalScrollBar.TabIndex = 2;
            this.spdVersion.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdVersion.Location = new System.Drawing.Point(0, 0);
            this.spdVersion.Name = "spdVersion";
            this.spdVersion.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdVersion.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdVersion.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Rows;
            this.spdVersion.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdVersion_Sheet1});
            this.spdVersion.Size = new System.Drawing.Size(736, 196);
            this.spdVersion.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdVersion.TabIndex = 1;
            this.spdVersion.TabStop = false;
            this.spdVersion.TextTipDelay = 200;
            this.spdVersion.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdVersion.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdVersion.VerticalScrollBar.Name = "";
            this.spdVersion.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdVersion.VerticalScrollBar.TabIndex = 3;
            this.spdVersion.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdVersion.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdVersion_SelectionChanged);
            this.spdVersion.SetViewportLeftColumn(0, 0, 1);
            this.spdVersion.SetActiveViewport(0, -1, -1);
            // 
            // spdVersion_Sheet1
            // 
            this.spdVersion_Sheet1.Reset();
            spdVersion_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdVersion_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdVersion_Sheet1.ColumnCount = 9;
            spdVersion_Sheet1.RowCount = 0;
            this.spdVersion_Sheet1.ActiveColumnIndex = -1;
            this.spdVersion_Sheet1.ActiveRowIndex = -1;
            this.spdVersion_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdVersion_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdVersion_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdVersion_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdVersion_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Version";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Apply Start Time";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Apply End Time";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Approval";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "User ID";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Approval Time";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Release";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "User ID";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Release Time";
            this.spdVersion_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdVersion_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdVersion_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdVersion_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(0).Label = "Version";
            this.spdVersion_Sheet1.Columns.Get(0).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(0).Width = 45F;
            this.spdVersion_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(1).Label = "Apply Start Time";
            this.spdVersion_Sheet1.Columns.Get(1).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(1).Width = 110F;
            this.spdVersion_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(2).Label = "Apply End Time";
            this.spdVersion_Sheet1.Columns.Get(2).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(2).Width = 110F;
            this.spdVersion_Sheet1.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdVersion_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(3).Label = "Approval";
            this.spdVersion_Sheet1.Columns.Get(3).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(3).Width = 55F;
            this.spdVersion_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(4).Label = "User ID";
            this.spdVersion_Sheet1.Columns.Get(4).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(4).Width = 85F;
            this.spdVersion_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(5).Label = "Approval Time";
            this.spdVersion_Sheet1.Columns.Get(5).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(5).Width = 110F;
            this.spdVersion_Sheet1.Columns.Get(6).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdVersion_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(6).Label = "Release";
            this.spdVersion_Sheet1.Columns.Get(6).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(6).Width = 50F;
            this.spdVersion_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(7).Label = "User ID";
            this.spdVersion_Sheet1.Columns.Get(7).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(7).Width = 85F;
            this.spdVersion_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(8).Label = "Release Time";
            this.spdVersion_Sheet1.Columns.Get(8).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(8).Width = 110F;
            this.spdVersion_Sheet1.FrozenColumnCount = 1;
            this.spdVersion_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdVersion_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdVersion_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdVersion_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdVersion_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdVersion_Sheet1.RowHeader.Visible = false;
            this.spdVersion_Sheet1.Rows.Default.Height = 18F;
            this.spdVersion_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdVersion_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdVersion_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdVersion_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdVersion_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdVersion_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(16, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnUnit
            // 
            this.btnUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUnit.Location = new System.Drawing.Point(558, 8);
            this.btnUnit.Name = "btnUnit";
            this.btnUnit.Size = new System.Drawing.Size(88, 26);
            this.btnUnit.TabIndex = 1;
            this.btnUnit.Text = "Default Unit";
            this.btnUnit.Click += new System.EventHandler(this.btnUnit_Click);
            // 
            // frmEDCViewCharacterbyCollectionSet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Controls.Add(this.pnlVersion);
            this.Controls.Add(this.pnlGrp);
            this.Name = "frmEDCViewCharacterbyCollectionSet";
            this.Text = "View Character by Collection Set";
            this.Activated += new System.EventHandler(this.frmEDCViewCharacterbyCollectionSet_Activated);
            this.Load += new System.EventHandler(this.frmEDCViewCharacterbyCollectionSet_Load);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlGrp, 0);
            this.Controls.SetChildIndex(this.pnlVersion, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlGrp.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCollectionSet)).EndInit();
            this.pnlVersion.ResumeLayout(false);
            this.pnlCharacterList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCharacter_Sheet1)).EndInit();
            this.pnlVersionList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
#endregion
        
#region " Variable Definition"
        
        bool LoadFlag;
        DataSet myDataSet = new DataSet();
        
#endregion
        
#region " Constant Defintion"
        
        //spdCharacter
        private const int CHAR_ID = 0;
        private const int UNIT_COUNT = 2;
        
#endregion
        
#region " Function Definition"
        
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
                switch (MPCF.Trim(FuncName))
                {
                    case "View_Col_Set_Version_List":

                        if (MPCF.Trim(cdvCollectionSet.Text) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
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

            
            // CollectionCharacter()
            //       -
            // Return Value
            //       - boolean : True / False
            // Arguments
            //       - ByVal Form_control As Control            : Listê°€ ?¤ì–´ê°?control
            //         - ByVal c_step As String                    : ?•ìž¥ Process Step
            //         - ByVal table_name As String                : GCM??Table_name
            //
            
            public bool CollectionCharacter(ref frmEDCSetupAttachCharacter.Unit_Def[] UnitDef)
            {
                
                try
                {                    
                    UnitDef = new frmEDCSetupAttachCharacter.Unit_Def[1];
                    UnitDef[0].CharacterID = MPCF.Trim(spdCharacter.Sheets[0].GetValue(spdCharacter.Sheets[0].ActiveRowIndex, CHAR_ID));
                    UnitDef[0].UnitCount = MPCF.ToInt(spdCharacter.Sheets[0].GetValue(spdCharacter.Sheets[0].ActiveRowIndex, UNIT_COUNT));
                    
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
                    return this.cdvCollectionSet;
                    
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    return null;
                }
                
            }
            
#endregion
            
        private void frmEDCViewCharacterbyCollectionSet_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdVersion,true);
                MPCF.ClearList(spdCharacter, true);
                
                btnUnit.Enabled = false;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmEDCViewCharacterbyCollectionSet_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (LoadFlag == false)
                {
                    if (EDCLIST.ViewEDCColSetList(cdvCollectionSet.GetListView, '1', null, "", -1, -1, ' ', false) == false)
                    {
                        return;
                    }

                    LoadFlag = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvCollectionSet_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    btnProcess_Click(null, null);
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
                if (CheckCondition("View_Col_Set_Version_List") == true)
                {
                    if (EDCLIST.ViewEDCColSetVersionList(spdVersion, MPCF.Trim(cdvCollectionSet.Text), '2') == true)
                    {
                        if (spdVersion.Sheets[0].RowCount > 0)
                        {
                            MPCR.ChangeControlEnabled(this, btnUnit, true);
                        }
                        else
                        {
                            btnUnit.Enabled = false;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnUnit_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (spdVersion.Sheets[0].SelectionCount > 0 && spdCharacter.Sheets[0].RowCount > 0)
                {
                    if (spdVersion.Sheets[0].RowCount > 0)
                    {
                        frmEDCSetupDefaultUnitSub DefaultUnitform;
                        frmEDCSetupAttachCharacter.Unit_Def[] UnitDef = null;

                        if (CollectionCharacter(ref UnitDef) == false)
                        {
                            return;
                        }

                        DefaultUnitform = new frmEDCSetupDefaultUnitSub(cdvCollectionSet.Text, MPCF.Trim(spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRowIndex, 0)), UnitDef, false);
                        DefaultUnitform.Text = "Default Unit Definition";
                        if (DefaultUnitform.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvCollectionSet_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvCollectionSet.Init();
                MPCF.InitListView(cdvCollectionSet.GetListView);
                cdvCollectionSet.Columns.Add("Collection Set", 50, HorizontalAlignment.Left);
                cdvCollectionSet.Columns.Add("Description", 100, HorizontalAlignment.Left);
                cdvCollectionSet.SelectedSubItemIndex = 0;
                if (EDCLIST.ViewEDCColSetList(cdvCollectionSet.GetListView, '1', null, "", -1, -1, ' ', false) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvCollectionSet_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            try
            {
                btnProcess_Click(null, null);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void spdVersion_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            
            try
            {                
                if (CheckCondition("View_Character_By_Collection_List") == true)
                {
                    
                    if (EDCLIST.ViewAttachCharacterListToVersion(spdCharacter, cdvCollectionSet.Text, MPCF.Trim(spdVersion.Sheets[0].GetValue(e.Range.Row, 0)), 'N') == false)
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
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            try
            {
                sCond = "Collection Set : " + MPCF.Trim(cdvCollectionSet.Text);
                MPCF.ExportToExcel(spdCharacter, this.Text, sCond);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvCollectionSet_TextBoxTextChanged(object sender, System.EventArgs e)
        {

            try
            {
                MPCF.ClearList(spdVersion, true);
                MPCF.ClearList(spdCharacter, true);
                btnUnit.Enabled = false;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

#endif // _EDC
            
    }
        
}
