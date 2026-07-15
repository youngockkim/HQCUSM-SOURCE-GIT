namespace BOI.WIPCus
{
    partial class frmWIPViewBomListPopup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer1 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer2 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            this.spdBOMList = new BOI.OIFrx.BOIControls.BOISpread();
            this.spdBOMList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlPopupTop.SuspendLayout();
            this.pnlPopupBottom.SuspendLayout();
            this.pnlPopupMiddle.SuspendLayout();
            this.pnlPopupTopMargin.SuspendLayout();
            this.pnlPopupBottomMargin.SuspendLayout();
            this.pnlPopupMiddleMargin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdBOMList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdBOMList_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPopupTitle
            // 
            this.lblPopupTitle.Text = "Bom List";
            // 
            // pnlPopupTop
            // 
            this.pnlPopupTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            // 
            // pnlPopupBottom
            // 
            this.pnlPopupBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            // 
            // btnClose
            // 
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlPopupMiddle
            // 
            this.pnlPopupMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            // 
            // pnlPopupMiddleMargin
            // 
            this.pnlPopupMiddleMargin.Controls.Add(this.spdBOMList);
            // 
            // spdBOMList
            // 
            this.spdBOMList._UseAutoHeight = false;
            this.spdBOMList._UseOITheme = true;
            this.spdBOMList.AccessibleDescription = "spdBOMList, Sheet1, Row 0, Column 0, ";
            this.spdBOMList.AllowUserZoom = false;
            this.spdBOMList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdBOMList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spdBOMList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdBOMList.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.spdBOMList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdBOMList.HorizontalScrollBar.Name = "";
            enhancedScrollBarRenderer1.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer1.ArrowHoveredColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer1.ArrowSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer1.ButtonBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            enhancedScrollBarRenderer1.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            enhancedScrollBarRenderer1.ButtonHoveredBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer1.ButtonHoveredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer1.ButtonSelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer1.ButtonSelectedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer1.TrackBarBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            enhancedScrollBarRenderer1.TrackBarSelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.spdBOMList.HorizontalScrollBar.Renderer = enhancedScrollBarRenderer1;
            this.spdBOMList.HorizontalScrollBar.TabIndex = 144;
            this.spdBOMList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdBOMList.Location = new System.Drawing.Point(0, 0);
            this.spdBOMList.Margin = new System.Windows.Forms.Padding(0);
            this.spdBOMList.Name = "spdBOMList";
            this.spdBOMList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdBOMList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdBOMList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdBOMList_Sheet1});
            this.spdBOMList.Size = new System.Drawing.Size(776, 484);
            this.spdBOMList.SOICellHeight = 50;
            this.spdBOMList.SOIColumnHeight = 30;
            this.spdBOMList.TabIndex = 20;
            this.spdBOMList.TabStop = false;
            this.spdBOMList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdBOMList.UseEnterKeyForMove = true;
            this.spdBOMList.UseKeyPad = true;
            this.spdBOMList.UseSOIContextMenu = true;
            this.spdBOMList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdBOMList.VerticalScrollBar.Name = "";
            enhancedScrollBarRenderer2.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer2.ArrowHoveredColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer2.ArrowSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer2.ButtonBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            enhancedScrollBarRenderer2.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            enhancedScrollBarRenderer2.ButtonHoveredBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer2.ButtonHoveredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer2.ButtonSelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer2.ButtonSelectedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer2.TrackBarBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            enhancedScrollBarRenderer2.TrackBarSelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.spdBOMList.VerticalScrollBar.Renderer = enhancedScrollBarRenderer2;
            this.spdBOMList.VerticalScrollBar.TabIndex = 145;
            this.spdBOMList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdBOMList.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdBOMList.SetActiveViewport(0, -1, -1);
            // 
            // spdBOMList_Sheet1
            // 
            this.spdBOMList_Sheet1.Reset();
            spdBOMList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdBOMList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdBOMList_Sheet1.ColumnCount = 5;
            spdBOMList_Sheet1.RowCount = 0;
            spdBOMList_Sheet1.RowHeader.ColumnCount = 0;
            this.spdBOMList_Sheet1.ActiveColumnIndex = -1;
            this.spdBOMList_Sheet1.ActiveRowIndex = -1;
            this.spdBOMList_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic1;
            this.spdBOMList_Sheet1.ColumnFooter.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdBOMList_Sheet1.ColumnFooter.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdBOMList_Sheet1.ColumnFooter.DefaultStyle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.spdBOMList_Sheet1.ColumnFooter.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.spdBOMList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdBOMList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdBOMList_Sheet1.ColumnFooter.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdBOMList_Sheet1.ColumnFooter.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdBOMList_Sheet1.ColumnFooterSheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdBOMList_Sheet1.ColumnFooterSheetCornerStyle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.spdBOMList_Sheet1.ColumnFooterSheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.spdBOMList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdBOMList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "HeaderDefault";
            this.spdBOMList_Sheet1.ColumnFooterSheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdBOMList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Material";
            this.spdBOMList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Material Desc";
            this.spdBOMList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Type";
            this.spdBOMList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Qty";
            this.spdBOMList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Unit";
            this.spdBOMList_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdBOMList_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdBOMList_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdBOMList_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdBOMList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdBOMList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdBOMList_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdBOMList_Sheet1.ColumnHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdBOMList_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdBOMList_Sheet1.ColumnHeader.Rows.Get(0).Height = 47F;
            this.spdBOMList_Sheet1.ColumnHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdBOMList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBOMList_Sheet1.Columns.Get(0).Label = "Material";
            this.spdBOMList_Sheet1.Columns.Get(0).Locked = true;
            this.spdBOMList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBOMList_Sheet1.Columns.Get(0).Width = 101F;
            this.spdBOMList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBOMList_Sheet1.Columns.Get(1).Label = "Material Desc";
            this.spdBOMList_Sheet1.Columns.Get(1).Locked = true;
            this.spdBOMList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBOMList_Sheet1.Columns.Get(1).Width = 301F;
            this.spdBOMList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdBOMList_Sheet1.Columns.Get(2).Label = "Type";
            this.spdBOMList_Sheet1.Columns.Get(2).Locked = true;
            this.spdBOMList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBOMList_Sheet1.Columns.Get(2).Width = 52F;
            this.spdBOMList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdBOMList_Sheet1.Columns.Get(3).Label = "Qty";
            this.spdBOMList_Sheet1.Columns.Get(3).Locked = true;
            this.spdBOMList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBOMList_Sheet1.Columns.Get(3).Width = 100F;
            this.spdBOMList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdBOMList_Sheet1.Columns.Get(4).Label = "Unit";
            this.spdBOMList_Sheet1.Columns.Get(4).Locked = true;
            this.spdBOMList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBOMList_Sheet1.Columns.Get(4).Width = 65F;
            this.spdBOMList_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdBOMList_Sheet1.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdBOMList_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.spdBOMList_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdBOMList_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdBOMList_Sheet1.GrayAreaBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdBOMList_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdBOMList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdBOMList_Sheet1.PrintInfo.ShowColor = true;
            this.spdBOMList_Sheet1.PrintInfo.UseSmartPrint = true;
            this.spdBOMList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdBOMList_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdBOMList_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdBOMList_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdBOMList_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdBOMList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdBOMList_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdBOMList_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdBOMList_Sheet1.RowHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdBOMList_Sheet1.RowHeader.Rows.Default.Resizable = true;
            this.spdBOMList_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdBOMList_Sheet1.RowHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdBOMList_Sheet1.RowHeader.Visible = false;
            this.spdBOMList_Sheet1.Rows.Default.Height = 50F;
            this.spdBOMList_Sheet1.Rows.Default.Resizable = true;
            this.spdBOMList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdBOMList_Sheet1.SelectionStyle = FarPoint.Win.Spread.SelectionStyles.SelectionColors;
            this.spdBOMList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdBOMList_Sheet1.SheetCornerHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdBOMList_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdBOMList_Sheet1.SheetCornerStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdBOMList_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdBOMList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdBOMList_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.spdBOMList_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdBOMList_Sheet1.SheetCornerVerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdBOMList_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdBOMList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmWIPViewBomListPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Name = "frmWIPViewBomListPopup";
            this.Text = "frmWIPViewBomListPopup";
            this.Load += new System.EventHandler(this.frmWIPViewBomListPopup_Load);
            this.pnlPopupTop.ResumeLayout(false);
            this.pnlPopupBottom.ResumeLayout(false);
            this.pnlPopupMiddle.ResumeLayout(false);
            this.pnlPopupTopMargin.ResumeLayout(false);
            this.pnlPopupBottomMargin.ResumeLayout(false);
            this.pnlPopupMiddleMargin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdBOMList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdBOMList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OIFrx.BOIControls.BOISpread spdBOMList;
        private FarPoint.Win.Spread.SheetView spdBOMList_Sheet1;
    }
}