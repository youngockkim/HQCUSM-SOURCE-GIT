
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
    public class frmWIPViewMaterialByFlow : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPViewMaterialByFlow()
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
        



        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFlow;
        private System.Windows.Forms.Label lblFlow;
        private FarPoint.Win.Spread.FpSpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType7 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType8 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType9 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType10 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType11 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType12 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType13 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType14 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType15 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType16 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType17 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType18 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType19 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType20 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.cdvFlow = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblFlow = new System.Windows.Forms.Label();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).BeginInit();
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
            this.pnlViewTop.Size = new System.Drawing.Size(742, 47);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvFlow);
            this.grpOption.Controls.Add(this.lblFlow);
            this.grpOption.Size = new System.Drawing.Size(742, 47);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdList);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 47);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 459);
            this.pnlViewMid.TabIndex = 2;
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
            this.lblFormTitle.Text = "View Material List By Flow";
            // 
            // cdvFlow
            // 
            this.cdvFlow.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFlow.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFlow.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFlow.BtnToolTipText = "";
            this.cdvFlow.DescText = "";
            this.cdvFlow.DisplaySubItemIndex = -1;
            this.cdvFlow.DisplayText = "";
            this.cdvFlow.Focusing = null;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.Index = 0;
            this.cdvFlow.IsViewBtnImage = false;
            this.cdvFlow.Location = new System.Drawing.Point(120, 16);
            this.cdvFlow.MaxLength = 20;
            this.cdvFlow.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.ReadOnly = false;
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = -1;
            this.cdvFlow.SelectionStart = 0;
            this.cdvFlow.Size = new System.Drawing.Size(200, 20);
            this.cdvFlow.SmallImageList = null;
            this.cdvFlow.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFlow.TabIndex = 1;
            this.cdvFlow.TextBoxToolTipText = "";
            this.cdvFlow.TextBoxWidth = 200;
            this.cdvFlow.VisibleButton = true;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            // 
            // lblFlow
            // 
            this.lblFlow.AutoSize = true;
            this.lblFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlow.Location = new System.Drawing.Point(15, 19);
            this.lblFlow.Name = "lblFlow";
            this.lblFlow.Size = new System.Drawing.Size(33, 13);
            this.lblFlow.TabIndex = 0;
            this.lblFlow.Text = "Flow";
            this.lblFlow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.spdList.Location = new System.Drawing.Point(0, 3);
            this.spdList.Name = "spdList";
            this.spdList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdList_Sheet1});
            this.spdList.Size = new System.Drawing.Size(742, 456);
            this.spdList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdList.TabIndex = 1;
            this.spdList.TabStop = false;
            this.spdList.TextTipDelay = 200;
            this.spdList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.VerticalScrollBar.Name = "";
            this.spdList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdList.VerticalScrollBar.TabIndex = 3;
            this.spdList.SetViewportLeftColumn(0, 0, 2);
            this.spdList.SetActiveViewport(0, 0, -1);
            // 
            // spdList_Sheet1
            // 
            this.spdList_Sheet1.Reset();
            spdList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdList_Sheet1.ColumnCount = 77;
            spdList_Sheet1.RowCount = 5;
            this.spdList_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Type";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Material";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Mat Ver";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Material Desc";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Unit 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Unit 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Unit 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Default Qty 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Default Qty 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Default Qty 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Base Material";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Vendor";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Vendor Material";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Customer";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Customer Material";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "First Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Last Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "MFG Devision";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Subcontract Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Target Yield";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Target Due Day";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Target Qty 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Target Qty 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Target Qty 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Weight Net";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Weight Gross";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Weight Unit";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Volume";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Volume Unit";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Dimension Horizontal";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 30).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Dimension Horizontal Unit";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 31).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Dimension Vertical";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 32).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Dimension Vertical Unit";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 33).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Dimension Height";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 34).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Dimension Height Unit";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 35).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "Pack Type";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 36).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "Pack Lot Count";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "Pack Qty";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "Bom Set ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "Default Inv Operation";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 40).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Low Error";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Low Warning";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "High Error";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 43).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 43).Value = "High Warning";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 44).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 44).Value = "IQC Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 45).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 45).Value = "IQC Sample Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 46).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 46).Value = "IQC Sample Rule";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 47).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 47).Value = "OQC Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 48).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 48).Value = "OQC Sample Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 48).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 49).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 49).Value = "OQC Sample Rule";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 49).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 50).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 50).Value = "Material Group 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 50).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 51).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 51).Value = "Material Group 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 51).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 52).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 52).Value = "Material Group 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 52).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 53).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 53).Value = "Material Group 4";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 53).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 54).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 54).Value = "Material Group 5";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 54).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 55).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 55).Value = "Material Group 6";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 55).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 56).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 56).Value = "Material Group 7";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 57).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 57).Value = "Material Group 8";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 58).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 58).Value = "Material Group 9";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 58).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 59).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 59).Value = "Material Group 10";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 60).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 60).Value = "Material CMF 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 61).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 61).Value = "Material CMF 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 62).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 62).Value = "Material CMF 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 63).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 63).Value = "Material CMF 4";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 63).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 64).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 64).Value = "Material CMF 5";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 64).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 65).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 65).Value = "Material CMF 6";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 65).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 66).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 66).Value = "Material CMF 7";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 66).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 67).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 67).Value = "Material CMF 8";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 67).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 68).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 68).Value = "Material CMF 9";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 68).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 69).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 69).Value = "Material CMF 10";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 69).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 70).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 70).Value = "Create User ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 70).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 71).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 71).Value = "Create Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 71).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 72).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 72).Value = "Update User ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 72).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 73).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 73).Value = "Update Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 73).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 74).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 74).Value = "Delete Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 74).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 75).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 75).Value = "Delete User ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 75).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 76).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 76).Value = "Delete Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 76).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(0).Label = "Type";
            this.spdList_Sheet1.Columns.Get(0).Locked = true;
            this.spdList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(0).Width = 46F;
            this.spdList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(1).Label = "Material";
            this.spdList_Sheet1.Columns.Get(1).Locked = true;
            this.spdList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(1).Width = 110F;
            this.spdList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(2).Label = "Mat Ver";
            this.spdList_Sheet1.Columns.Get(2).Locked = true;
            this.spdList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(3).Label = "Material Desc";
            this.spdList_Sheet1.Columns.Get(3).Locked = true;
            this.spdList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(3).Width = 200F;
            this.spdList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(4).Label = "Unit 1";
            this.spdList_Sheet1.Columns.Get(4).Locked = true;
            this.spdList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(4).Width = 76F;
            this.spdList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(5).Label = "Unit 2";
            this.spdList_Sheet1.Columns.Get(5).Locked = true;
            this.spdList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(5).Width = 76F;
            this.spdList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(6).Label = "Unit 3";
            this.spdList_Sheet1.Columns.Get(6).Locked = true;
            this.spdList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(6).Width = 76F;
            numberCellType1.DecimalPlaces = 3;
            this.spdList_Sheet1.Columns.Get(7).CellType = numberCellType1;
            this.spdList_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(7).Label = "Default Qty 1";
            this.spdList_Sheet1.Columns.Get(7).Locked = true;
            this.spdList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(7).Width = 76F;
            numberCellType2.DecimalPlaces = 3;
            this.spdList_Sheet1.Columns.Get(8).CellType = numberCellType2;
            this.spdList_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(8).Label = "Default Qty 2";
            this.spdList_Sheet1.Columns.Get(8).Locked = true;
            this.spdList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(8).Width = 76F;
            numberCellType3.DecimalPlaces = 3;
            this.spdList_Sheet1.Columns.Get(9).CellType = numberCellType3;
            this.spdList_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(9).Label = "Default Qty 3";
            this.spdList_Sheet1.Columns.Get(9).Locked = true;
            this.spdList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(9).Width = 76F;
            this.spdList_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(10).Label = "Base Material";
            this.spdList_Sheet1.Columns.Get(10).Locked = true;
            this.spdList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(10).Width = 83F;
            this.spdList_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(11).Label = "Vendor";
            this.spdList_Sheet1.Columns.Get(11).Locked = true;
            this.spdList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(11).Width = 76F;
            this.spdList_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(12).Label = "Vendor Material";
            this.spdList_Sheet1.Columns.Get(12).Locked = true;
            this.spdList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(12).Width = 100F;
            this.spdList_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(13).Label = "Customer";
            this.spdList_Sheet1.Columns.Get(13).Locked = true;
            this.spdList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(13).Width = 69F;
            this.spdList_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(14).Label = "Customer Material";
            this.spdList_Sheet1.Columns.Get(14).Locked = true;
            this.spdList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(14).Width = 100F;
            this.spdList_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(15).Label = "First Flow";
            this.spdList_Sheet1.Columns.Get(15).Locked = true;
            this.spdList_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(15).Width = 72F;
            this.spdList_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(16).Label = "Last Flow";
            this.spdList_Sheet1.Columns.Get(16).Locked = true;
            this.spdList_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(16).Width = 72F;
            this.spdList_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(17).Label = "MFG Devision";
            this.spdList_Sheet1.Columns.Get(17).Locked = true;
            this.spdList_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(17).Width = 84F;
            this.spdList_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(18).Label = "Subcontract Flag";
            this.spdList_Sheet1.Columns.Get(18).Locked = true;
            this.spdList_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(18).Width = 107F;
            numberCellType4.DecimalPlaces = 2;
            numberCellType4.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(19).CellType = numberCellType4;
            this.spdList_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(19).Label = "Target Yield";
            this.spdList_Sheet1.Columns.Get(19).Locked = true;
            this.spdList_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(19).Width = 75F;
            numberCellType5.DecimalPlaces = 2;
            numberCellType5.MaximumValue = 999.99D;
            numberCellType5.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(20).CellType = numberCellType5;
            this.spdList_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(20).Label = "Target Due Day";
            this.spdList_Sheet1.Columns.Get(20).Locked = true;
            this.spdList_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(20).Width = 87F;
            numberCellType6.DecimalPlaces = 3;
            this.spdList_Sheet1.Columns.Get(21).CellType = numberCellType6;
            this.spdList_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(21).Label = "Target Qty 1";
            this.spdList_Sheet1.Columns.Get(21).Locked = true;
            this.spdList_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(21).Width = 69F;
            numberCellType7.DecimalPlaces = 3;
            this.spdList_Sheet1.Columns.Get(22).CellType = numberCellType7;
            this.spdList_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(22).Label = "Target Qty 2";
            this.spdList_Sheet1.Columns.Get(22).Locked = true;
            this.spdList_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(22).Width = 69F;
            numberCellType8.DecimalPlaces = 3;
            this.spdList_Sheet1.Columns.Get(23).CellType = numberCellType8;
            this.spdList_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(23).Label = "Target Qty 3";
            this.spdList_Sheet1.Columns.Get(23).Locked = true;
            this.spdList_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(23).Width = 69F;
            numberCellType9.DecimalPlaces = 3;
            this.spdList_Sheet1.Columns.Get(24).CellType = numberCellType9;
            this.spdList_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(24).Label = "Weight Net";
            this.spdList_Sheet1.Columns.Get(24).Locked = true;
            this.spdList_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(24).Width = 64F;
            numberCellType10.DecimalPlaces = 3;
            this.spdList_Sheet1.Columns.Get(25).CellType = numberCellType10;
            this.spdList_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(25).Label = "Weight Gross";
            this.spdList_Sheet1.Columns.Get(25).Locked = true;
            this.spdList_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(25).Width = 84F;
            this.spdList_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(26).Label = "Weight Unit";
            this.spdList_Sheet1.Columns.Get(26).Locked = true;
            this.spdList_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(26).Width = 75F;
            numberCellType11.DecimalPlaces = 3;
            this.spdList_Sheet1.Columns.Get(27).CellType = numberCellType11;
            this.spdList_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(27).Label = "Volume";
            this.spdList_Sheet1.Columns.Get(27).Locked = true;
            this.spdList_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(28).Label = "Volume Unit";
            this.spdList_Sheet1.Columns.Get(28).Locked = true;
            this.spdList_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(28).Width = 77F;
            numberCellType12.DecimalPlaces = 3;
            this.spdList_Sheet1.Columns.Get(29).CellType = numberCellType12;
            this.spdList_Sheet1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(29).Label = "Dimension Horizontal";
            this.spdList_Sheet1.Columns.Get(29).Locked = true;
            this.spdList_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(29).Width = 119F;
            this.spdList_Sheet1.Columns.Get(30).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(30).Label = "Dimension Horizontal Unit";
            this.spdList_Sheet1.Columns.Get(30).Locked = true;
            this.spdList_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(30).Width = 138F;
            numberCellType13.DecimalPlaces = 3;
            this.spdList_Sheet1.Columns.Get(31).CellType = numberCellType13;
            this.spdList_Sheet1.Columns.Get(31).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(31).Label = "Dimension Vertical";
            this.spdList_Sheet1.Columns.Get(31).Locked = true;
            this.spdList_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(31).Width = 106F;
            this.spdList_Sheet1.Columns.Get(32).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(32).Label = "Dimension Vertical Unit";
            this.spdList_Sheet1.Columns.Get(32).Locked = true;
            this.spdList_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(32).Width = 127F;
            numberCellType14.DecimalPlaces = 3;
            this.spdList_Sheet1.Columns.Get(33).CellType = numberCellType14;
            this.spdList_Sheet1.Columns.Get(33).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(33).Label = "Dimension Height";
            this.spdList_Sheet1.Columns.Get(33).Locked = true;
            this.spdList_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(33).Width = 105F;
            this.spdList_Sheet1.Columns.Get(34).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(34).Label = "Dimension Height Unit";
            this.spdList_Sheet1.Columns.Get(34).Locked = true;
            this.spdList_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(34).Width = 131F;
            this.spdList_Sheet1.Columns.Get(35).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(35).Label = "Pack Type";
            this.spdList_Sheet1.Columns.Get(35).Locked = true;
            this.spdList_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            numberCellType15.DecimalPlaces = 0;
            numberCellType15.MaximumValue = 9999D;
            numberCellType15.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(36).CellType = numberCellType15;
            this.spdList_Sheet1.Columns.Get(36).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(36).Label = "Pack Lot Count";
            this.spdList_Sheet1.Columns.Get(36).Locked = true;
            this.spdList_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(36).Width = 99F;
            numberCellType16.DecimalPlaces = 3;
            this.spdList_Sheet1.Columns.Get(37).CellType = numberCellType16;
            this.spdList_Sheet1.Columns.Get(37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(37).Label = "Pack Qty";
            this.spdList_Sheet1.Columns.Get(37).Locked = true;
            this.spdList_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(37).Width = 58F;
            this.spdList_Sheet1.Columns.Get(38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(38).Label = "Bom Set ID";
            this.spdList_Sheet1.Columns.Get(38).Locked = true;
            this.spdList_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(38).Width = 76F;
            this.spdList_Sheet1.Columns.Get(39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(39).Label = "Default Inv Operation";
            this.spdList_Sheet1.Columns.Get(39).Locked = true;
            this.spdList_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(39).Width = 122F;
            numberCellType17.DecimalPlaces = 3;
            this.spdList_Sheet1.Columns.Get(40).CellType = numberCellType17;
            this.spdList_Sheet1.Columns.Get(40).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(40).Label = "Low Error";
            this.spdList_Sheet1.Columns.Get(40).Locked = true;
            this.spdList_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            numberCellType18.DecimalPlaces = 3;
            this.spdList_Sheet1.Columns.Get(41).CellType = numberCellType18;
            this.spdList_Sheet1.Columns.Get(41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(41).Label = "Low Warning";
            this.spdList_Sheet1.Columns.Get(41).Locked = true;
            this.spdList_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(41).Width = 85F;
            numberCellType19.DecimalPlaces = 3;
            this.spdList_Sheet1.Columns.Get(42).CellType = numberCellType19;
            this.spdList_Sheet1.Columns.Get(42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(42).Label = "High Error";
            this.spdList_Sheet1.Columns.Get(42).Locked = true;
            this.spdList_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            numberCellType20.DecimalPlaces = 3;
            this.spdList_Sheet1.Columns.Get(43).CellType = numberCellType20;
            this.spdList_Sheet1.Columns.Get(43).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(43).Label = "High Warning";
            this.spdList_Sheet1.Columns.Get(43).Locked = true;
            this.spdList_Sheet1.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(43).Width = 89F;
            this.spdList_Sheet1.Columns.Get(44).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(44).Label = "IQC Flag";
            this.spdList_Sheet1.Columns.Get(44).Locked = true;
            this.spdList_Sheet1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(45).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(45).Label = "IQC Sample Flag";
            this.spdList_Sheet1.Columns.Get(45).Locked = true;
            this.spdList_Sheet1.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(45).Width = 98F;
            this.spdList_Sheet1.Columns.Get(46).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(46).Label = "IQC Sample Rule";
            this.spdList_Sheet1.Columns.Get(46).Locked = true;
            this.spdList_Sheet1.Columns.Get(46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(46).Width = 104F;
            this.spdList_Sheet1.Columns.Get(47).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(47).Label = "OQC Flag";
            this.spdList_Sheet1.Columns.Get(47).Locked = true;
            this.spdList_Sheet1.Columns.Get(47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(48).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(48).Label = "OQC Sample Flag";
            this.spdList_Sheet1.Columns.Get(48).Locked = true;
            this.spdList_Sheet1.Columns.Get(48).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(48).Width = 104F;
            this.spdList_Sheet1.Columns.Get(49).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(49).Label = "OQC Sample Rule";
            this.spdList_Sheet1.Columns.Get(49).Locked = true;
            this.spdList_Sheet1.Columns.Get(49).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(49).Width = 107F;
            this.spdList_Sheet1.Columns.Get(50).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(50).Label = "Material Group 1";
            this.spdList_Sheet1.Columns.Get(50).Locked = true;
            this.spdList_Sheet1.Columns.Get(50).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(50).Width = 97F;
            this.spdList_Sheet1.Columns.Get(51).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(51).Label = "Material Group 2";
            this.spdList_Sheet1.Columns.Get(51).Locked = true;
            this.spdList_Sheet1.Columns.Get(51).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(51).Width = 97F;
            this.spdList_Sheet1.Columns.Get(52).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(52).Label = "Material Group 3";
            this.spdList_Sheet1.Columns.Get(52).Locked = true;
            this.spdList_Sheet1.Columns.Get(52).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(52).Width = 97F;
            this.spdList_Sheet1.Columns.Get(53).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(53).Label = "Material Group 4";
            this.spdList_Sheet1.Columns.Get(53).Locked = true;
            this.spdList_Sheet1.Columns.Get(53).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(53).Width = 97F;
            this.spdList_Sheet1.Columns.Get(54).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(54).Label = "Material Group 5";
            this.spdList_Sheet1.Columns.Get(54).Locked = true;
            this.spdList_Sheet1.Columns.Get(54).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(54).Width = 97F;
            this.spdList_Sheet1.Columns.Get(55).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(55).Label = "Material Group 6";
            this.spdList_Sheet1.Columns.Get(55).Locked = true;
            this.spdList_Sheet1.Columns.Get(55).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(55).Width = 97F;
            this.spdList_Sheet1.Columns.Get(56).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(56).Label = "Material Group 7";
            this.spdList_Sheet1.Columns.Get(56).Locked = true;
            this.spdList_Sheet1.Columns.Get(56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(56).Width = 97F;
            this.spdList_Sheet1.Columns.Get(57).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(57).Label = "Material Group 8";
            this.spdList_Sheet1.Columns.Get(57).Locked = true;
            this.spdList_Sheet1.Columns.Get(57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(57).Width = 97F;
            this.spdList_Sheet1.Columns.Get(58).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(58).Label = "Material Group 9";
            this.spdList_Sheet1.Columns.Get(58).Locked = true;
            this.spdList_Sheet1.Columns.Get(58).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(58).Width = 97F;
            this.spdList_Sheet1.Columns.Get(59).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(59).Label = "Material Group 10";
            this.spdList_Sheet1.Columns.Get(59).Locked = true;
            this.spdList_Sheet1.Columns.Get(59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(59).Width = 97F;
            this.spdList_Sheet1.Columns.Get(60).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(60).Label = "Material CMF 1";
            this.spdList_Sheet1.Columns.Get(60).Locked = true;
            this.spdList_Sheet1.Columns.Get(60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(60).Width = 97F;
            this.spdList_Sheet1.Columns.Get(61).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(61).Label = "Material CMF 2";
            this.spdList_Sheet1.Columns.Get(61).Locked = true;
            this.spdList_Sheet1.Columns.Get(61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(61).Width = 97F;
            this.spdList_Sheet1.Columns.Get(62).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(62).Label = "Material CMF 3";
            this.spdList_Sheet1.Columns.Get(62).Locked = true;
            this.spdList_Sheet1.Columns.Get(62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(62).Width = 97F;
            this.spdList_Sheet1.Columns.Get(63).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(63).Label = "Material CMF 4";
            this.spdList_Sheet1.Columns.Get(63).Locked = true;
            this.spdList_Sheet1.Columns.Get(63).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(63).Width = 97F;
            this.spdList_Sheet1.Columns.Get(64).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(64).Label = "Material CMF 5";
            this.spdList_Sheet1.Columns.Get(64).Locked = true;
            this.spdList_Sheet1.Columns.Get(64).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(64).Width = 97F;
            this.spdList_Sheet1.Columns.Get(65).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(65).Label = "Material CMF 6";
            this.spdList_Sheet1.Columns.Get(65).Locked = true;
            this.spdList_Sheet1.Columns.Get(65).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(65).Width = 97F;
            this.spdList_Sheet1.Columns.Get(66).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(66).Label = "Material CMF 7";
            this.spdList_Sheet1.Columns.Get(66).Locked = true;
            this.spdList_Sheet1.Columns.Get(66).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(66).Width = 97F;
            this.spdList_Sheet1.Columns.Get(67).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(67).Label = "Material CMF 8";
            this.spdList_Sheet1.Columns.Get(67).Locked = true;
            this.spdList_Sheet1.Columns.Get(67).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(67).Width = 97F;
            this.spdList_Sheet1.Columns.Get(68).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(68).Label = "Material CMF 9";
            this.spdList_Sheet1.Columns.Get(68).Locked = true;
            this.spdList_Sheet1.Columns.Get(68).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(68).Width = 97F;
            this.spdList_Sheet1.Columns.Get(69).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(69).Label = "Material CMF 10";
            this.spdList_Sheet1.Columns.Get(69).Locked = true;
            this.spdList_Sheet1.Columns.Get(69).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(69).Width = 97F;
            this.spdList_Sheet1.Columns.Get(70).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(70).Label = "Create User ID";
            this.spdList_Sheet1.Columns.Get(70).Locked = true;
            this.spdList_Sheet1.Columns.Get(70).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(70).Width = 100F;
            this.spdList_Sheet1.Columns.Get(71).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(71).Label = "Create Time";
            this.spdList_Sheet1.Columns.Get(71).Locked = true;
            this.spdList_Sheet1.Columns.Get(71).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(71).Width = 120F;
            this.spdList_Sheet1.Columns.Get(72).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(72).Label = "Update User ID";
            this.spdList_Sheet1.Columns.Get(72).Locked = true;
            this.spdList_Sheet1.Columns.Get(72).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(72).Width = 100F;
            this.spdList_Sheet1.Columns.Get(73).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(73).Label = "Update Time";
            this.spdList_Sheet1.Columns.Get(73).Locked = true;
            this.spdList_Sheet1.Columns.Get(73).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(73).Width = 120F;
            this.spdList_Sheet1.Columns.Get(74).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(74).Label = "Delete Flag";
            this.spdList_Sheet1.Columns.Get(74).Locked = true;
            this.spdList_Sheet1.Columns.Get(74).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(74).Width = 78F;
            this.spdList_Sheet1.Columns.Get(75).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(75).Label = "Delete User ID";
            this.spdList_Sheet1.Columns.Get(75).Locked = true;
            this.spdList_Sheet1.Columns.Get(75).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(75).Width = 100F;
            this.spdList_Sheet1.Columns.Get(76).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(76).Label = "Delete Time";
            this.spdList_Sheet1.Columns.Get(76).Locked = true;
            this.spdList_Sheet1.Columns.Get(76).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(76).Width = 120F;
            this.spdList_Sheet1.FrozenColumnCount = 2;
            this.spdList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmWIPViewMaterialByFlow
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPViewMaterialByFlow";
            this.Text = "View Material By Flow";
            this.Activated += new System.EventHandler(this.frmWIPViewMaterialByFlow_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        #endregion
        
        #region " Function Definition "
        
        //
        // GetFlowList()
        //       - Get Flow List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool GetFlowList()
        {
            
            try
            {
                cdvFlow.Init();
                MPCF.InitListView(cdvFlow.GetListView);
                cdvFlow.Columns.Add("Flow", 50, HorizontalAlignment.Left);
                cdvFlow.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvFlow.SelectedSubItemIndex = 0;
                
                if (WIPLIST.ViewFlowList(cdvFlow.GetListView, '1', "", 0, "", null, "") == false)
                {
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
        
        private bool ViewMaterialByFlow()
        {
            int i;
            int iLastRow;

            TRSNode in_node = new TRSNode("VIEW_MATERIALBYFLOW_IN");
            TRSNode out_node = new TRSNode("VIEW_MATERIAL_LIST_DETAIL_OUT");

            try
            {
                MPCF.ClearList(spdList, true);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));

                do
                {
                    if (MPCR.CallService("WIP", "WIP_View_Material_List_By_Flow", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iLastRow = spdList.Sheets[0].RowCount;
                        spdList.Sheets[0].RowCount = spdList.Sheets[0].RowCount + 1;

                        spdList.Sheets[0].SetValue(iLastRow, 0, out_node.GetList(0)[i].GetString("MAT_TYPE"));
                        spdList.Sheets[0].SetValue(iLastRow, 1, out_node.GetList(0)[i].GetString("MAT_ID"));
                        spdList.Sheets[0].SetValue(iLastRow, 2, out_node.GetList(0)[i].GetInt("MAT_VER"));
                        spdList.Sheets[0].SetValue(iLastRow, 3, out_node.GetList(0)[i].GetString("MAT_DESC"));
                        spdList.Sheets[0].SetValue(iLastRow, 4, out_node.GetList(0)[i].GetString("UNIT1"));
                        spdList.Sheets[0].SetValue(iLastRow, 5, out_node.GetList(0)[i].GetString("UNIT2"));
                        spdList.Sheets[0].SetValue(iLastRow, 6, out_node.GetList(0)[i].GetString("UNIT3"));
                        spdList.Sheets[0].SetValue(iLastRow, 7, out_node.GetList(0)[i].GetDouble("DEF_QTY_1"));
                        spdList.Sheets[0].SetValue(iLastRow, 8, out_node.GetList(0)[i].GetDouble("DEF_QTY_2"));
                        spdList.Sheets[0].SetValue(iLastRow, 9, out_node.GetList(0)[i].GetDouble("DEF_QTY_3"));
                        spdList.Sheets[0].SetValue(iLastRow, 10, out_node.GetList(0)[i].GetString("BASE_MAT_ID"));
                        spdList.Sheets[0].SetValue(iLastRow, 11, out_node.GetList(0)[i].GetString("VENDOR_ID"));
                        spdList.Sheets[0].SetValue(iLastRow, 12, out_node.GetList(0)[i].GetString("VENDOR_MAT_ID"));
                        spdList.Sheets[0].SetValue(iLastRow, 13, out_node.GetList(0)[i].GetString("CUSTOMER_ID"));
                        spdList.Sheets[0].SetValue(iLastRow, 14, out_node.GetList(0)[i].GetString("CUSTOMER_MAT_ID"));
                        spdList.Sheets[0].SetValue(iLastRow, 15, out_node.GetList(0)[i].GetString("FIRST_FLOW"));
                        spdList.Sheets[0].SetValue(iLastRow, 16, out_node.GetList(0)[i].GetString("LAST_FLOW"));
                        spdList.Sheets[0].SetValue(iLastRow, 17, out_node.GetList(0)[i].GetString("MFG_DEVISION"));
                        spdList.Sheets[0].SetValue(iLastRow, 18, out_node.GetList(0)[i].GetChar("SUBCONTRACT_FLAG"));
                        spdList.Sheets[0].SetValue(iLastRow, 19, out_node.GetList(0)[i].GetDouble("TARGET_YIELD"));
                        spdList.Sheets[0].SetValue(iLastRow, 20, out_node.GetList(0)[i].GetDouble("TARGET_DUE_DAY"));
                        spdList.Sheets[0].SetValue(iLastRow, 21, out_node.GetList(0)[i].GetDouble("TARGET_QTY_1"));
                        spdList.Sheets[0].SetValue(iLastRow, 22, out_node.GetList(0)[i].GetDouble("TARGET_QTY_2"));
                        spdList.Sheets[0].SetValue(iLastRow, 23, out_node.GetList(0)[i].GetDouble("TARGET_QTY_3"));
                        spdList.Sheets[0].SetValue(iLastRow, 24, out_node.GetList(0)[i].GetDouble("WEIGHT_NET"));
                        spdList.Sheets[0].SetValue(iLastRow, 25, out_node.GetList(0)[i].GetDouble("WEIGHT_GROSS"));
                        spdList.Sheets[0].SetValue(iLastRow, 26, out_node.GetList(0)[i].GetString("WEIGHT_UNIT"));
                        spdList.Sheets[0].SetValue(iLastRow, 27, out_node.GetList(0)[i].GetDouble("VOLUME"));
                        spdList.Sheets[0].SetValue(iLastRow, 28, out_node.GetList(0)[i].GetString("VOLUME_UNIT"));
                        spdList.Sheets[0].SetValue(iLastRow, 29, out_node.GetList(0)[i].GetDouble("DIMENSION_HR"));
                        spdList.Sheets[0].SetValue(iLastRow, 30, out_node.GetList(0)[i].GetString("DIMENSION_HR_UNIT"));
                        spdList.Sheets[0].SetValue(iLastRow, 31, out_node.GetList(0)[i].GetDouble("DIMENSION_VT"));
                        spdList.Sheets[0].SetValue(iLastRow, 32, out_node.GetList(0)[i].GetString("DIMENSION_VT_UNIT"));
                        spdList.Sheets[0].SetValue(iLastRow, 33, out_node.GetList(0)[i].GetDouble("DIMENSION_HT"));
                        spdList.Sheets[0].SetValue(iLastRow, 34, out_node.GetList(0)[i].GetString("DIMENSION_HT_UNIT"));
                        spdList.Sheets[0].SetValue(iLastRow, 35, out_node.GetList(0)[i].GetChar("PACK_TYPE"));
                        spdList.Sheets[0].SetValue(iLastRow, 36, out_node.GetList(0)[i].GetInt("PACK_LOT_COUNT"));
                        spdList.Sheets[0].SetValue(iLastRow, 37, out_node.GetList(0)[i].GetDouble("PACK_QTY"));
                        spdList.Sheets[0].SetValue(iLastRow, 38, out_node.GetList(0)[i].GetString("BOM_SET_ID"));
                        spdList.Sheets[0].SetValue(iLastRow, 39, out_node.GetList(0)[i].GetString("DEF_INV_OPER"));
                        spdList.Sheets[0].SetValue(iLastRow, 40, out_node.GetList(0)[i].GetDouble("LE_STOCK_LEVEL"));
                        spdList.Sheets[0].SetValue(iLastRow, 41, out_node.GetList(0)[i].GetDouble("LW_STOCK_LEVEL"));
                        spdList.Sheets[0].SetValue(iLastRow, 42, out_node.GetList(0)[i].GetDouble("HE_STOCK_LEVEL"));
                        spdList.Sheets[0].SetValue(iLastRow, 43, out_node.GetList(0)[i].GetDouble("HW_STOCK_LEVEL"));
                        spdList.Sheets[0].SetValue(iLastRow, 44, out_node.GetList(0)[i].GetChar("IQC_FLAG"));
                        spdList.Sheets[0].SetValue(iLastRow, 45, out_node.GetList(0)[i].GetChar("IQC_SAMPLE_FLAG"));
                        spdList.Sheets[0].SetValue(iLastRow, 46, out_node.GetList(0)[i].GetChar("IQC_SAMPLE_RULE"));
                        spdList.Sheets[0].SetValue(iLastRow, 47, out_node.GetList(0)[i].GetChar("OQC_FLAG"));
                        spdList.Sheets[0].SetValue(iLastRow, 48, out_node.GetList(0)[i].GetChar("OQC_SAMPLE_FLAG"));
                        spdList.Sheets[0].SetValue(iLastRow, 49, out_node.GetList(0)[i].GetChar("OQC_SAMPLE_RULE"));
                        spdList.Sheets[0].SetValue(iLastRow, 50, out_node.GetList(0)[i].GetString("MAT_GRP_1"));
                        spdList.Sheets[0].SetValue(iLastRow, 51, out_node.GetList(0)[i].GetString("MAT_GRP_2"));
                        spdList.Sheets[0].SetValue(iLastRow, 52, out_node.GetList(0)[i].GetString("MAT_GRP_3"));
                        spdList.Sheets[0].SetValue(iLastRow, 53, out_node.GetList(0)[i].GetString("MAT_GRP_4"));
                        spdList.Sheets[0].SetValue(iLastRow, 54, out_node.GetList(0)[i].GetString("MAT_GRP_5"));
                        spdList.Sheets[0].SetValue(iLastRow, 55, out_node.GetList(0)[i].GetString("MAT_GRP_6"));
                        spdList.Sheets[0].SetValue(iLastRow, 56, out_node.GetList(0)[i].GetString("MAT_GRP_7"));
                        spdList.Sheets[0].SetValue(iLastRow, 57, out_node.GetList(0)[i].GetString("MAT_GRP_8"));
                        spdList.Sheets[0].SetValue(iLastRow, 58, out_node.GetList(0)[i].GetString("MAT_GRP_9"));
                        spdList.Sheets[0].SetValue(iLastRow, 59, out_node.GetList(0)[i].GetString("MAT_GRP_10"));
                        spdList.Sheets[0].SetValue(iLastRow, 60, out_node.GetList(0)[i].GetString("MAT_CMF_1"));
                        spdList.Sheets[0].SetValue(iLastRow, 61, out_node.GetList(0)[i].GetString("MAT_CMF_2"));
                        spdList.Sheets[0].SetValue(iLastRow, 62, out_node.GetList(0)[i].GetString("MAT_CMF_3"));
                        spdList.Sheets[0].SetValue(iLastRow, 63, out_node.GetList(0)[i].GetString("MAT_CMF_4"));
                        spdList.Sheets[0].SetValue(iLastRow, 64, out_node.GetList(0)[i].GetString("MAT_CMF_5"));
                        spdList.Sheets[0].SetValue(iLastRow, 65, out_node.GetList(0)[i].GetString("MAT_CMF_6"));
                        spdList.Sheets[0].SetValue(iLastRow, 66, out_node.GetList(0)[i].GetString("MAT_CMF_7"));
                        spdList.Sheets[0].SetValue(iLastRow, 67, out_node.GetList(0)[i].GetString("MAT_CMF_8"));
                        spdList.Sheets[0].SetValue(iLastRow, 68, out_node.GetList(0)[i].GetString("MAT_CMF_9"));
                        spdList.Sheets[0].SetValue(iLastRow, 69, out_node.GetList(0)[i].GetString("MAT_CMF_10"));
                        spdList.Sheets[0].SetValue(iLastRow, 70, out_node.GetList(0)[i].GetString("CREATE_USER_ID"));
                        spdList.Sheets[0].SetValue(iLastRow, 71, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME")));
                        spdList.Sheets[0].SetValue(iLastRow, 72, out_node.GetList(0)[i].GetString("UPDATE_USER_ID"));
                        spdList.Sheets[0].SetValue(iLastRow, 73, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("UPDATE_TIME")));
                        spdList.Sheets[0].SetValue(iLastRow, 74, out_node.GetList(0)[i].GetChar("DELETE_FLAG"));
                        spdList.Sheets[0].SetValue(iLastRow, 75, out_node.GetList(0)[i].GetString("DELETE_USER_ID"));
                        spdList.Sheets[0].SetValue(iLastRow, 76, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("DELETE_TIME")));
                    }
                    in_node.SetString("NEXT_MAT_ID", out_node.GetString("NEXT_MAT_ID"));
                    in_node.SetInt("NEXT_MAT_VER", out_node.GetInt("NEXT_MAT_VER"));  //Add by J.S. 2012.04.02 net mat ver이용하게 수정
                } while (in_node.GetString("NEXT_MAT_ID") != "");

                MPCF.FitColumnHeader(spdList);
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
                return this.cdvFlow;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmWIPViewMaterialByFlow_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdList, true);
                MPCF.FitColumnHeader(spdList);
                
                if (GetFlowList() == false)
                {
                    return;
                }
                b_load_flag = true;
            }
            
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            
            if (cdvFlow.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvFlow.Focus();
                return;
            }
            
            if (ViewMaterialByFlow() == false)
            {
                return;
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Flow : " + MPCF.Trim(cdvFlow.Text);

            if (MPCF.ExportToExcel(spdList, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
            }
            
        }
    }
    
}
