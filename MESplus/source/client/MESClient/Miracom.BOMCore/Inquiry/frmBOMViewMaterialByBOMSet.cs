
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
//   File Name   : frmBOMViewMaterialByBOMSet.vb
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
    public class frmBOMViewMaterialByBOMSet : Miracom.MESCore.ViewForm01
    {

        #region " Windows Form auto generated code "

        public frmBOMViewMaterialByBOMSet()
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




        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvBOMSet;
        private System.Windows.Forms.Label lblBOMSet;
        private FarPoint.Win.Spread.FpSpread spdMatList;
        private FarPoint.Win.Spread.SheetView spdMatList_Sheet1;
        private FarPoint.Win.Spread.FpSpread spdVersion;
        private FarPoint.Win.Spread.SheetView spdVersion_Sheet1;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.cdvBOMSet = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblBOMSet = new System.Windows.Forms.Label();
            this.spdMatList = new FarPoint.Win.Spread.FpSpread();
            this.spdMatList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.spdVersion = new FarPoint.Win.Spread.FpSpread();
            this.spdVersion_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvBOMSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMatList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMatList_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            this.pnlViewTop.Size = new System.Drawing.Size(742, 47);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvBOMSet);
            this.grpOption.Controls.Add(this.lblBOMSet);
            this.grpOption.Size = new System.Drawing.Size(742, 47);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdMatList);
            this.pnlViewMid.Controls.Add(this.spdVersion);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 47);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 466);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Material List By BOM Set ID";
            // 
            // cdvBOMSet
            // 
            this.cdvBOMSet.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvBOMSet.BorderHotColor = System.Drawing.Color.Black;
            this.cdvBOMSet.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvBOMSet.BtnToolTipText = "";
            this.cdvBOMSet.DescText = "";
            this.cdvBOMSet.DisplaySubItemIndex = -1;
            this.cdvBOMSet.DisplayText = "";
            this.cdvBOMSet.Focusing = null;
            this.cdvBOMSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvBOMSet.Index = 0;
            this.cdvBOMSet.IsViewBtnImage = false;
            this.cdvBOMSet.Location = new System.Drawing.Point(120, 16);
            this.cdvBOMSet.MaxLength = 25;
            this.cdvBOMSet.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvBOMSet.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvBOMSet.Name = "cdvBOMSet";
            this.cdvBOMSet.ReadOnly = false;
            this.cdvBOMSet.SearchSubItemIndex = 0;
            this.cdvBOMSet.SelectedDescIndex = -1;
            this.cdvBOMSet.SelectedSubItemIndex = -1;
            this.cdvBOMSet.SelectionStart = 0;
            this.cdvBOMSet.Size = new System.Drawing.Size(200, 20);
            this.cdvBOMSet.SmallImageList = null;
            this.cdvBOMSet.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvBOMSet.TabIndex = 0;
            this.cdvBOMSet.TextBoxToolTipText = "";
            this.cdvBOMSet.TextBoxWidth = 200;
            this.cdvBOMSet.VisibleButton = true;
            this.cdvBOMSet.VisibleColumnHeader = false;
            this.cdvBOMSet.VisibleDescription = false;
            this.cdvBOMSet.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvBOMSet_SelectedItemChanged);
            this.cdvBOMSet.ButtonPress += new System.EventHandler(this.cdvBOMSet_ButtonPress);
            // 
            // lblBOMSet
            // 
            this.lblBOMSet.AutoSize = true;
            this.lblBOMSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBOMSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBOMSet.Location = new System.Drawing.Point(15, 19);
            this.lblBOMSet.Name = "lblBOMSet";
            this.lblBOMSet.Size = new System.Drawing.Size(78, 13);
            this.lblBOMSet.TabIndex = 0;
            this.lblBOMSet.Text = "BOM Set ID ";
            // 
            // spdMatList
            // 
            this.spdMatList.AccessibleDescription = "spdMatList, Sheet1, Row 0, Column 0, ";
            this.spdMatList.BackColor = System.Drawing.SystemColors.Control;
            this.spdMatList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdMatList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdMatList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMatList.HorizontalScrollBar.Name = "";
            this.spdMatList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdMatList.HorizontalScrollBar.TabIndex = 2;
            this.spdMatList.Location = new System.Drawing.Point(0, 148);
            this.spdMatList.Name = "spdMatList";
            this.spdMatList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdMatList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdMatList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdMatList_Sheet1});
            this.spdMatList.Size = new System.Drawing.Size(742, 318);
            this.spdMatList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdMatList.TabIndex = 1;
            this.spdMatList.TabStop = false;
            this.spdMatList.TextTipDelay = 200;
            this.spdMatList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdMatList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMatList.VerticalScrollBar.Name = "";
            this.spdMatList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdMatList.VerticalScrollBar.TabIndex = 3;
            this.spdMatList.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            // 
            // spdMatList_Sheet1
            // 
            this.spdMatList_Sheet1.Reset();
            spdMatList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdMatList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdMatList_Sheet1.ColumnCount = 25;
            spdMatList_Sheet1.RowCount = 5;
            this.spdMatList_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdMatList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMatList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdMatList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMatList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Mat ID";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Mat Ver";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Version";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Mat Qty";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Part Grp";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Alt Mat Flag";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Mat Unit";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Opt Input Flag";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Auto Input Flag";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = " Serial Input Flag";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = " Serial Type";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Chk Serial Flag";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Flow";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Oper";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Part CMF1";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Part CMF2";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Part CMF3";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Part CMF4";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Part CMF5";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Part CMF6";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Part CMF7";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Part CMF8";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Part CMF9";
            this.spdMatList_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Part CMF10";
            this.spdMatList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMatList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdMatList_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdMatList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMatList_Sheet1.Columns.Get(0).Label = "Mat ID";
            this.spdMatList_Sheet1.Columns.Get(0).Locked = false;
            this.spdMatList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(0).Width = 80F;
            this.spdMatList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(1).Label = "Mat Ver";
            this.spdMatList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMatList_Sheet1.Columns.Get(2).Label = "Description";
            this.spdMatList_Sheet1.Columns.Get(2).Locked = true;
            this.spdMatList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(2).Width = 144F;
            this.spdMatList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(3).Label = "Version";
            this.spdMatList_Sheet1.Columns.Get(3).Locked = true;
            this.spdMatList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(3).Width = 45F;
            this.spdMatList_Sheet1.Columns.Get(4).CellType = textCellType1;
            this.spdMatList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdMatList_Sheet1.Columns.Get(4).Label = "Mat Qty";
            this.spdMatList_Sheet1.Columns.Get(4).Locked = false;
            this.spdMatList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(4).Width = 82F;
            this.spdMatList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMatList_Sheet1.Columns.Get(5).Label = "Part Grp";
            this.spdMatList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(5).Width = 80F;
            this.spdMatList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMatList_Sheet1.Columns.Get(6).Label = "Alt Mat Flag";
            this.spdMatList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(6).Width = 80F;
            this.spdMatList_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMatList_Sheet1.Columns.Get(7).Label = "Mat Unit";
            this.spdMatList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(7).Width = 68F;
            this.spdMatList_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMatList_Sheet1.Columns.Get(8).Label = "Opt Input Flag";
            this.spdMatList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(8).Width = 92F;
            this.spdMatList_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMatList_Sheet1.Columns.Get(9).Label = "Auto Input Flag";
            this.spdMatList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(9).Width = 101F;
            this.spdMatList_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMatList_Sheet1.Columns.Get(10).Label = " Serial Input Flag";
            this.spdMatList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(10).Width = 105F;
            this.spdMatList_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMatList_Sheet1.Columns.Get(11).Label = " Serial Type";
            this.spdMatList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(11).Width = 75F;
            this.spdMatList_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMatList_Sheet1.Columns.Get(12).Label = "Chk Serial Flag";
            this.spdMatList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(12).Width = 98F;
            this.spdMatList_Sheet1.Columns.Get(13).Label = "Flow";
            this.spdMatList_Sheet1.Columns.Get(13).Width = 93F;
            this.spdMatList_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMatList_Sheet1.Columns.Get(14).Label = "Oper";
            this.spdMatList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(14).Width = 66F;
            this.spdMatList_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMatList_Sheet1.Columns.Get(15).Label = "Part CMF1";
            this.spdMatList_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(15).Width = 75F;
            this.spdMatList_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMatList_Sheet1.Columns.Get(16).Label = "Part CMF2";
            this.spdMatList_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(16).Width = 75F;
            this.spdMatList_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMatList_Sheet1.Columns.Get(17).Label = "Part CMF3";
            this.spdMatList_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(17).Width = 75F;
            this.spdMatList_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMatList_Sheet1.Columns.Get(18).Label = "Part CMF4";
            this.spdMatList_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(18).Width = 75F;
            this.spdMatList_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMatList_Sheet1.Columns.Get(19).Label = "Part CMF5";
            this.spdMatList_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(19).Width = 75F;
            this.spdMatList_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMatList_Sheet1.Columns.Get(20).Label = "Part CMF6";
            this.spdMatList_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(20).Width = 75F;
            this.spdMatList_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMatList_Sheet1.Columns.Get(21).Label = "Part CMF7";
            this.spdMatList_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(21).Width = 75F;
            this.spdMatList_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMatList_Sheet1.Columns.Get(22).Label = "Part CMF8";
            this.spdMatList_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(22).Width = 75F;
            this.spdMatList_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMatList_Sheet1.Columns.Get(23).Label = "Part CMF9";
            this.spdMatList_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(23).Width = 75F;
            this.spdMatList_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMatList_Sheet1.Columns.Get(24).Label = "Part CMF10";
            this.spdMatList_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMatList_Sheet1.Columns.Get(24).Width = 75F;
            this.spdMatList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdMatList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdMatList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdMatList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMatList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdMatList_Sheet1.Rows.Get(0).Height = 18F;
            this.spdMatList_Sheet1.Rows.Get(1).Height = 18F;
            this.spdMatList_Sheet1.Rows.Get(2).Height = 18F;
            this.spdMatList_Sheet1.Rows.Get(3).Height = 18F;
            this.spdMatList_Sheet1.Rows.Get(4).Height = 18F;
            this.spdMatList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdMatList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdMatList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMatList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdMatList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // spdVersion
            // 
            this.spdVersion.AccessibleDescription = "";
            this.spdVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.spdVersion.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdVersion.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdVersion.HorizontalScrollBar.Name = "";
            this.spdVersion.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdVersion.HorizontalScrollBar.TabIndex = 2;
            this.spdVersion.Location = new System.Drawing.Point(0, 3);
            this.spdVersion.Name = "spdVersion";
            this.spdVersion.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdVersion.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdVersion.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Rows;
            this.spdVersion.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdVersion_Sheet1});
            this.spdVersion.Size = new System.Drawing.Size(742, 145);
            this.spdVersion.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdVersion.TabIndex = 0;
            this.spdVersion.TabStop = false;
            this.spdVersion.TextTipDelay = 200;
            this.spdVersion.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdVersion.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdVersion.VerticalScrollBar.Name = "";
            this.spdVersion.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdVersion.VerticalScrollBar.TabIndex = 3;
            this.spdVersion.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdVersion.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdVersion_SelectionChanged);
            // 
            // spdVersion_Sheet1
            // 
            this.spdVersion_Sheet1.Reset();
            spdVersion_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdVersion_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdVersion_Sheet1.ColumnCount = 9;
            spdVersion_Sheet1.RowCount = 5;
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
            this.spdVersion_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(0).Label = "Version";
            this.spdVersion_Sheet1.Columns.Get(0).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(0).Width = 50F;
            this.spdVersion_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(1).Label = "Apply Start Time";
            this.spdVersion_Sheet1.Columns.Get(1).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(1).Width = 120F;
            this.spdVersion_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(2).Label = "Apply End Time";
            this.spdVersion_Sheet1.Columns.Get(2).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(2).Width = 120F;
            this.spdVersion_Sheet1.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdVersion_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(3).Label = "Approval";
            this.spdVersion_Sheet1.Columns.Get(3).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(4).Label = "User ID";
            this.spdVersion_Sheet1.Columns.Get(4).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(4).Width = 80F;
            this.spdVersion_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(5).Label = "Approval Time";
            this.spdVersion_Sheet1.Columns.Get(5).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(5).Width = 120F;
            this.spdVersion_Sheet1.Columns.Get(6).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdVersion_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(6).Label = "Release";
            this.spdVersion_Sheet1.Columns.Get(6).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(7).Label = "User ID";
            this.spdVersion_Sheet1.Columns.Get(7).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(7).Width = 80F;
            this.spdVersion_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(8).Label = "Release Time";
            this.spdVersion_Sheet1.Columns.Get(8).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(8).Width = 120F;
            this.spdVersion_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdVersion_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdVersion_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdVersion_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdVersion_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdVersion_Sheet1.RowHeader.Visible = false;
            this.spdVersion_Sheet1.Rows.Get(0).Height = 18F;
            this.spdVersion_Sheet1.Rows.Get(1).Height = 18F;
            this.spdVersion_Sheet1.Rows.Get(2).Height = 18F;
            this.spdVersion_Sheet1.Rows.Get(3).Height = 18F;
            this.spdVersion_Sheet1.Rows.Get(4).Height = 18F;
            this.spdVersion_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdVersion_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdVersion_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdVersion_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdVersion_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmBOMViewMaterialByBOMSet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmBOMViewMaterialByBOMSet";
            this.Text = "View Material List By BOM Set ID";
            this.Activated += new System.EventHandler(this.frmBOMViewMaterialByBOMSet_Activated);
            this.Load += new System.EventHandler(this.frmBOMViewMaterialByBOMSet_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvBOMSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMatList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMatList_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion_Sheet1)).EndInit();
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
                    case "View_BOMSet_Version_List":

                        if (cdvBOMSet.Text != "")
                        {
                            return true;
                        }
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        return false;
                    //                        case "View_Attach_Material_List":
                    //                        
                    //                        if (cdvBOMSet.Text != "")
                    //                        {
                    //                            if (spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRow.Index, 0) != "")
                    //                            {
                    //                                return true;
                    //                                }
                    //                                }
                    //                                modCommonFunction.ShowMsgBox(modLanguageFunction.GetMessage(108));
                    //                                return false;
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
        // View_BOMSet_Version_List()
        //       - View BOM Set Version
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - Optional ByVal c_step As String = "1"
        //       - ByVal sColSetId As String

        private bool View_BOMSet_Version_List(string sBOMSetId, char c_step)
        {

            int i;
            int iCol = 0;
            int iRow = 0;

            TRSNode in_node = new TRSNode("VIEW_BOM_SET_VERSION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_BOM_SET_VERSION_LIST_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("BOM_SET_ID", sBOMSetId);
                in_node.AddInt("NEXT_BOM_SET_VERSION", int.MaxValue);

                do
                {
                    if (MPCR.CallService("BOM", "BOM_View_BOMSet_Version_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        FarPoint.Win.Spread.SheetView with_1 = spdVersion.Sheets[0];

                        iRow = with_1.RowCount;
                        with_1.RowCount++;

                        iCol = 0;

                        with_1.SetValue(iRow, iCol, out_node.GetList(0)[i].GetInt("BOM_SET_VERSION"));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("APPLY_START_TIME"))));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("APPLY_END_TIME"))));

                        iCol++;
                        with_1.SetValue(iRow, iCol, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("APPROVAL_FLAG")) == "Y") ? "V" : ""));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("APPROVAL_USER_ID")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("APPROVAL_TIME"))));

                        iCol++;
                        with_1.SetValue(iRow, iCol, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("RELEASE_FLAG")) == "Y") ? "V" : ""));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("RELEASE_USER_ID")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("RELEASE_TIME"))));

                        iCol++;


                    }

                    in_node.SetInt("NEXT_BOM_SET_VERSION", out_node.GetInt("NEXT_BOM_SET_VERSION"));

                } while (in_node.GetInt("NEXT_BOM_SET_VERSION") > 0);


                MPCF.FitColumnHeader(spdVersion);

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }



        // View_Attach_Material_List()
        //       - View Material List by BOM Set
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal sColSetId As String                        : ColSet
        //        - ByVal sColSetVersion As String                : ColSetVersion
        //        -

        public bool View_Attach_Material_List(string sBOMSetId, string sBOMSetVersion, bool bShowError)
        {

            int i;
            int iCol = 0;
            int iRow = 0;

            TRSNode in_node = new TRSNode("VIEW_ATTACH_MATERIAL_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_ATTACH_MATERIAL_LIST_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1'; //c_step;
                in_node.AddString("BOM_SET_ID", sBOMSetId);
                in_node.AddInt("BOM_SET_VERSION", MPCF.ToInt(sBOMSetVersion));
                in_node.AddInt("NEXT_SEQ_NUM", 0);

                do
                {
                    if (MPCR.CallService("BOM", "BOM_View_Attach_Material_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {

                        FarPoint.Win.Spread.SheetView with_1 = spdMatList.Sheets[0];

                        iRow = with_1.RowCount;
                        with_1.RowCount++;

                        iCol = 0;

                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_ID")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetInt("MAT_VER")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_DESC")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetInt("MAT_VER")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Format("#######,##0.######", out_node.GetList(0)[i].GetDouble("MAT_QTY")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_GRP")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetChar("ALT_MAT_FLAG")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_UNIT")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetChar("OPT_INPUT_FLAG")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetChar("AUTO_INPUT_FLAG")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetChar("SERIAL_INPUT_FLAG")));

                        iCol++;
                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("SERIAL_TYPE")) == "L")
                        {
                            with_1.SetValue(iRow, iCol, "Lot ID");
                        }
                        else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("SERIAL_TYPE")) == "M")
                        {
                            with_1.SetValue(iRow, iCol, "Material");
                        }
                        else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("SERIAL_TYPE")) == "S")
                        {
                            with_1.SetValue(iRow, iCol, "Sub Component");
                        }
                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetChar("CHK_SERIAL_FLAG")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("FLOW")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("OPER")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_1")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_2")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_3")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_4")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_5")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_6")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_7")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_8")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_9")));

                        iCol++;
                        with_1.SetValue(iRow, iCol, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_10")));

                        iCol++;


                    }

                    in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));

                } while (string.IsNullOrEmpty(MPCF.Trim(out_node.GetInt("NEXT_SEQ_NUM"))) != false);

                MPCF.FitColumnHeader(spdMatList);

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
                return this.cdvBOMSet;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmBOMViewMaterialByBOMSet_Load(object sender, System.EventArgs e)
        {
            try
            {

                MPCF.FieldClear(this);

                MPCF.ClearList(spdVersion, true);
                MPCF.ClearList(spdMatList, true);
                MPCF.FitColumnHeader(spdVersion);
                MPCF.FitColumnHeader(spdMatList);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void frmBOMViewMaterialByBOMSet_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {

                    b_load_flag = true;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cdvBOMSet_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            try
            {
                MPCF.ClearList(spdVersion, true);
                MPCF.ClearList(spdMatList, true);
                if (CheckCondition("View_BOMSet_Version_List") == true)
                {
                    if (View_BOMSet_Version_List(e.Text, '1') == false)
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

        private void spdVersion_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {

            try
            {
                MPCF.ClearList(spdMatList, true);
                if (CheckCondition("View_Attach_Material_List") == true)
                {
                    View_Attach_Material_List(cdvBOMSet.Text, MPCF.Trim(spdVersion.Sheets[0].GetValue(e.Range.Row, 0)), false);
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
                MPCF.ClearList(spdVersion, true);
                MPCF.ClearList(spdMatList, true);
                if (CheckCondition("View_BOMSet_Version_List") == true)
                {
                    if (View_BOMSet_Version_List(cdvBOMSet.Text, '1') == false)
                    {
                        cdvBOMSet.Focus();
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

            sCond = "BOM Set ID :" + cdvBOMSet.Text;
            MPCF.ExportToExcel(spdMatList, this.Text, sCond);

        }

        private void cdvBOMSet_ButtonPress(object sender, System.EventArgs e)
        {
            cdvBOMSet.Init();
            MPCF.InitListView(cdvBOMSet.GetListView);
            cdvBOMSet.Columns.Add("BOM Set", 50, HorizontalAlignment.Left);
            cdvBOMSet.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvBOMSet.SelectedSubItemIndex = 0;
            if (BOMLIST.ViewBOMSetList(cdvBOMSet.GetListView, '1', null, "", -1, -1, ' ', false) == false)
            {
                return;
            }
        }
    }
    //'#End If ' _BOM
}
