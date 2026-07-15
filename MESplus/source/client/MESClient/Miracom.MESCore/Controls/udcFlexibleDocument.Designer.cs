namespace Miracom.MESCore.Controls
{
    partial class udcFlexibleDocument
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.spdSpread = new FarPoint.Win.Spread.FpSpread();
            this.spdSpread_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.spdSpread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSpread_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // spdSpread
            // 
            this.spdSpread.AccessibleDescription = "";
            this.spdSpread.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdSpread.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdSpread.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdSpread.HorizontalScrollBar.Name = "";
            this.spdSpread.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdSpread.HorizontalScrollBar.TabIndex = 10;
            this.spdSpread.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdSpread.Location = new System.Drawing.Point(0, 0);
            this.spdSpread.Name = "spdSpread";
            this.spdSpread.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdSpread.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdSpread.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdSpread_Sheet1});
            this.spdSpread.Size = new System.Drawing.Size(373, 222);
            this.spdSpread.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdSpread.TabIndex = 0;
            this.spdSpread.TextTipDelay = 200;
            this.spdSpread.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdSpread.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdSpread.VerticalScrollBar.Name = "";
            this.spdSpread.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdSpread.VerticalScrollBar.TabIndex = 11;
            this.spdSpread.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdSpread.VisualStyles = FarPoint.Win.VisualStyles.On;
            this.spdSpread.Resize += new System.EventHandler(this.spdSpread_Resize);
            this.spdSpread.SetActiveViewport(0, -1, -1);
            // 
            // spdSpread_Sheet1
            // 
            this.spdSpread_Sheet1.Reset();
            spdSpread_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdSpread_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdSpread_Sheet1.ColumnCount = 0;
            spdSpread_Sheet1.ColumnHeader.RowCount = 0;
            spdSpread_Sheet1.RowCount = 0;
            spdSpread_Sheet1.RowHeader.ColumnCount = 0;
            this.spdSpread_Sheet1.ActiveColumnIndex = -1;
            this.spdSpread_Sheet1.ActiveRowIndex = -1;
            this.spdSpread_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSpread_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdSpread_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSpread_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdSpread_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSpread_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdSpread_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdSpread_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.spdSpread_Sheet1.PrintInfo.BestFitCols = true;
            this.spdSpread_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdSpread_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSpread_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdSpread_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSpread_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdSpread_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.spdSpread_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // udcFlexibleDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spdSpread);
            this.Name = "udcFlexibleDocument";
            this.Size = new System.Drawing.Size(373, 222);
            ((System.ComponentModel.ISupportInitialize)(this.spdSpread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSpread_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread spdSpread;
        private FarPoint.Win.Spread.SheetView spdSpread_Sheet1;
    }
}
