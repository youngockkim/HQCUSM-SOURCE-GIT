
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
    public class frmWIPViewFlowByOperation : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPViewFlowByOperation()
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
        



        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOperation;
        private System.Windows.Forms.Label lblOperation;
        private FarPoint.Win.Spread.FpSpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.cdvOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOperation = new System.Windows.Forms.Label();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).BeginInit();
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
            this.grpOption.Controls.Add(this.cdvOperation);
            this.grpOption.Controls.Add(this.lblOperation);
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
            this.lblFormTitle.Text = "View Flow List By Operation";
            // 
            // cdvOperation
            // 
            this.cdvOperation.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOperation.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOperation.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOperation.BtnToolTipText = "";
            this.cdvOperation.DescText = "";
            this.cdvOperation.DisplaySubItemIndex = -1;
            this.cdvOperation.DisplayText = "";
            this.cdvOperation.Focusing = null;
            this.cdvOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOperation.Index = 0;
            this.cdvOperation.IsViewBtnImage = false;
            this.cdvOperation.Location = new System.Drawing.Point(120, 16);
            this.cdvOperation.MaxLength = 10;
            this.cdvOperation.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.Name = "cdvOperation";
            this.cdvOperation.ReadOnly = false;
            this.cdvOperation.SearchSubItemIndex = 0;
            this.cdvOperation.SelectedDescIndex = -1;
            this.cdvOperation.SelectedSubItemIndex = -1;
            this.cdvOperation.SelectionStart = 0;
            this.cdvOperation.Size = new System.Drawing.Size(200, 20);
            this.cdvOperation.SmallImageList = null;
            this.cdvOperation.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOperation.TabIndex = 1;
            this.cdvOperation.TextBoxToolTipText = "";
            this.cdvOperation.TextBoxWidth = 200;
            this.cdvOperation.VisibleButton = true;
            this.cdvOperation.VisibleColumnHeader = false;
            this.cdvOperation.VisibleDescription = false;
            this.cdvOperation.ButtonPress += new System.EventHandler(this.cdvOperation_ButtonPress);
            // 
            // lblOperation
            // 
            this.lblOperation.AutoSize = true;
            this.lblOperation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperation.Location = new System.Drawing.Point(15, 19);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(62, 13);
            this.lblOperation.TabIndex = 0;
            this.lblOperation.Text = "Operation";
            this.lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spdList
            // 
            this.spdList.AccessibleDescription = "";
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
            this.spdList.TabIndex = 0;
            this.spdList.TabStop = false;
            this.spdList.TextTipDelay = 200;
            this.spdList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.VerticalScrollBar.Name = "";
            this.spdList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdList.VerticalScrollBar.TabIndex = 3;
            this.spdList.SetActiveViewport(0, -1, -1);
            // 
            // spdList_Sheet1
            // 
            this.spdList_Sheet1.Reset();
            spdList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdList_Sheet1.ColumnCount = 28;
            spdList_Sheet1.RowCount = 0;
            this.spdList_Sheet1.ActiveColumnIndex = -1;
            this.spdList_Sheet1.ActiveRowIndex = -1;
            this.spdList_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Flow Desc";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "First Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Last Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Flow Group 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Flow Group 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Flow Group 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Flow Group 4";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Flow Group 5";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Flow Group 6";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Flow Group 7";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Flow Group 8";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Flow Group 9";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Flow Group 10";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Flow CMF 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Flow CMF 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Flow CMF 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Flow CMF 4";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Flow CMF 5";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Flow CMF 6";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Flow CMF 7";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Flow CMF 8";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Flow CMF 9";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Flow CMF 10";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Create User ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Create Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Update User ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Update Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(0).Label = "Flow";
            this.spdList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(0).Width = 103F;
            this.spdList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(1).Label = "Flow Desc";
            this.spdList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(1).Width = 126F;
            this.spdList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(2).Label = "First Oper";
            this.spdList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(2).Width = 68F;
            this.spdList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(3).Label = "Last Oper";
            this.spdList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(3).Width = 68F;
            this.spdList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(4).Label = "Flow Group 1";
            this.spdList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(4).Width = 96F;
            this.spdList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(5).Label = "Flow Group 2";
            this.spdList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(5).Width = 96F;
            this.spdList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(6).Label = "Flow Group 3";
            this.spdList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(6).Width = 96F;
            this.spdList_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(7).Label = "Flow Group 4";
            this.spdList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(7).Width = 96F;
            this.spdList_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(8).Label = "Flow Group 5";
            this.spdList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(8).Width = 96F;
            this.spdList_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(9).Label = "Flow Group 6";
            this.spdList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(9).Width = 96F;
            this.spdList_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(10).Label = "Flow Group 7";
            this.spdList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(10).Width = 96F;
            this.spdList_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(11).Label = "Flow Group 8";
            this.spdList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(11).Width = 96F;
            this.spdList_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(12).Label = "Flow Group 9";
            this.spdList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(12).Width = 96F;
            this.spdList_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(13).Label = "Flow Group 10";
            this.spdList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(13).Width = 96F;
            this.spdList_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(14).Label = "Flow CMF 1";
            this.spdList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(14).Width = 96F;
            this.spdList_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(15).Label = "Flow CMF 2";
            this.spdList_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(15).Width = 96F;
            this.spdList_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(16).Label = "Flow CMF 3";
            this.spdList_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(16).Width = 96F;
            this.spdList_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(17).Label = "Flow CMF 4";
            this.spdList_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(17).Width = 96F;
            this.spdList_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(18).Label = "Flow CMF 5";
            this.spdList_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(18).Width = 96F;
            this.spdList_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(19).Label = "Flow CMF 6";
            this.spdList_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(19).Width = 96F;
            this.spdList_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(20).Label = "Flow CMF 7";
            this.spdList_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(20).Width = 96F;
            this.spdList_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(21).Label = "Flow CMF 8";
            this.spdList_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(21).Width = 96F;
            this.spdList_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(22).Label = "Flow CMF 9";
            this.spdList_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(22).Width = 96F;
            this.spdList_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(23).Label = "Flow CMF 10";
            this.spdList_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(23).Width = 96F;
            this.spdList_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(24).Label = "Create User ID";
            this.spdList_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(24).Width = 100F;
            this.spdList_Sheet1.Columns.Get(25).CellType = textCellType1;
            this.spdList_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(25).Label = "Create Time";
            this.spdList_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(25).Width = 127F;
            this.spdList_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(26).Label = "Update User ID";
            this.spdList_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(26).Width = 100F;
            this.spdList_Sheet1.Columns.Get(27).CellType = textCellType2;
            this.spdList_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(27).Label = "Update Time";
            this.spdList_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(27).Width = 127F;
            this.spdList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdList_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmWIPViewFlowByOperation
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPViewFlowByOperation";
            this.Text = "View Flow By Operation";
            this.Activated += new System.EventHandler(this.frmWIPViewFlowByOperation_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        #endregion
        
        #region " Function Definition "
        
        private bool ViewFlowByOperation()
        {

            int i;
            int iLastRow;

            TRSNode in_node = new TRSNode("VIEW_FLOW_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_FLOW_LIST_OUT");

            try
            {
                MPCF.ClearList(spdList, true);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("OPER", MPCF.Trim(cdvOperation.Text));

                do
                {
                    if (MPCR.CallService("WIP", "WIP_View_Flow_List_By_Operation", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iLastRow = spdList.Sheets[0].RowCount;
                        spdList.Sheets[0].RowCount = spdList.Sheets[0].RowCount + 1;
                        FarPoint.Win.Spread.SheetView with_1 = spdList.Sheets[0];

                        with_1.SetValue(iLastRow, 0, out_node.GetList(0)[i].GetString("FLOW"));
                        with_1.SetValue(iLastRow, 1, out_node.GetList(0)[i].GetString("FLOW_DESC"));
                        with_1.SetValue(iLastRow, 2, out_node.GetList(0)[i].GetString("FIRST_OPER"));
                        with_1.SetValue(iLastRow, 3, out_node.GetList(0)[i].GetString("LAST_OPER"));
                        with_1.SetValue(iLastRow, 4, out_node.GetList(0)[i].GetString("FLOW_GRP_1"));
                        with_1.SetValue(iLastRow, 5, out_node.GetList(0)[i].GetString("FLOW_GRP_2"));
                        with_1.SetValue(iLastRow, 6, out_node.GetList(0)[i].GetString("FLOW_GRP_3"));
                        with_1.SetValue(iLastRow, 7, out_node.GetList(0)[i].GetString("FLOW_GRP_4"));
                        with_1.SetValue(iLastRow, 8, out_node.GetList(0)[i].GetString("FLOW_GRP_5"));
                        with_1.SetValue(iLastRow, 9, out_node.GetList(0)[i].GetString("FLOW_GRP_6"));
                        with_1.SetValue(iLastRow, 10, out_node.GetList(0)[i].GetString("FLOW_GRP_7"));
                        with_1.SetValue(iLastRow, 11, out_node.GetList(0)[i].GetString("FLOW_GRP_8"));
                        with_1.SetValue(iLastRow, 12, out_node.GetList(0)[i].GetString("FLOW_GRP_9"));
                        with_1.SetValue(iLastRow, 13, out_node.GetList(0)[i].GetString("FLOW_GRP_10"));
                        with_1.SetValue(iLastRow, 14, out_node.GetList(0)[i].GetString("FLOW_CMF_1"));
                        with_1.SetValue(iLastRow, 15, out_node.GetList(0)[i].GetString("FLOW_CMF_2"));
                        with_1.SetValue(iLastRow, 16, out_node.GetList(0)[i].GetString("FLOW_CMF_3"));
                        with_1.SetValue(iLastRow, 17, out_node.GetList(0)[i].GetString("FLOW_CMF_4"));
                        with_1.SetValue(iLastRow, 18, out_node.GetList(0)[i].GetString("FLOW_CMF_5"));
                        with_1.SetValue(iLastRow, 19, out_node.GetList(0)[i].GetString("FLOW_CMF_6"));
                        with_1.SetValue(iLastRow, 20, out_node.GetList(0)[i].GetString("FLOW_CMF_7"));
                        with_1.SetValue(iLastRow, 21, out_node.GetList(0)[i].GetString("FLOW_CMF_8"));
                        with_1.SetValue(iLastRow, 22, out_node.GetList(0)[i].GetString("FLOW_CMF_9"));
                        with_1.SetValue(iLastRow, 23, out_node.GetList(0)[i].GetString("FLOW_CMF_10"));
                        with_1.SetValue(iLastRow, 24, out_node.GetList(0)[i].GetString("CREATE_USER_ID"));
                        with_1.SetValue(iLastRow, 25, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME")));
                        with_1.SetValue(iLastRow, 26, out_node.GetList(0)[i].GetString("UPDATE_USER_ID"));
                        with_1.SetValue(iLastRow, 27, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("UPDATE_TIME")));
                    }
                    
                    in_node.SetString("NEXT_FLOW", out_node.GetString("NEXT_FLOW"));
                } while (in_node.GetString("NEXT_FLOW") != "");

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
                return this.cdvOperation;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmWIPViewFlowByOperation_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                MPCF.ClearList(spdList, true);
                MPCF.FitColumnHeader(spdList);

                MPCF.FieldClear(this);
                b_load_flag = true;
            }
            
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            
            if (cdvOperation.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvOperation.Focus();
                return;
            }
            
            if (ViewFlowByOperation() == false)
            {
                return;
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Operation : " + MPCF.Trim(cdvOperation.Text);
            MPCF.ExportToExcel(spdList, this.Text, sCond);
            
        }
        
        private void cdvOperation_ButtonPress(object sender, System.EventArgs e)
        {
            cdvOperation.Init();
            MPCF.InitListView(cdvOperation.GetListView);
            cdvOperation.Columns.Add("Operation", 50, HorizontalAlignment.Left);
            cdvOperation.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOperation.SelectedSubItemIndex = 0;
            
            WIPLIST.ViewOperationList(cdvOperation.GetListView, '1', "", 0, "", "", null, "");
            
        }
    }
    
}
