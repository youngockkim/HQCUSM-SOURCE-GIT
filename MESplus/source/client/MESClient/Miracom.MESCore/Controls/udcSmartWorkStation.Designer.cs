namespace Miracom.MESCore.Controls
{
    partial class udcSmartWorkStation
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
            this.components = new System.ComponentModel.Container();
            this.spdTran = new FarPoint.Win.Spread.FpSpread();
            this.spdTran_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.spdTran)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdTran_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // spdTran
            // 
            this.spdTran.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.spdTran.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdTran.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdTran.Location = new System.Drawing.Point(0, 0);
            this.spdTran.Name = "spdTran";
            this.spdTran.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdTran_Sheet1});
            this.spdTran.Size = new System.Drawing.Size(129, 163);
            this.spdTran.TabIndex = 0;
            this.spdTran.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdTran.VisualStyles = FarPoint.Win.VisualStyles.On;
            this.spdTran.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdTran_ButtonClicked);
            // 
            // spdTran_Sheet1
            // 
            this.spdTran_Sheet1.Reset();
            spdTran_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdTran_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdTran_Sheet1.ColumnCount = 2;
            spdTran_Sheet1.RowCount = 2;
            this.spdTran_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic;
            this.spdTran_Sheet1.ColumnFooter.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdTran_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTran_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdTran_Sheet1.ColumnFooter.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdTran_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTran_Sheet1.ColumnFooterSheetCornerStyle.Parent = "HeaderDefault";
            this.spdTran_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdTran_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTran_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdTran_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdTran_Sheet1.ColumnHeader.Visible = false;
            this.spdTran_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdTran_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdTran_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdTran_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTran_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdTran_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdTran_Sheet1.RowHeader.Visible = false;
            this.spdTran_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTran_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.spdTran_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // imgList
            // 
            this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgList.ImageSize = new System.Drawing.Size(16, 16);
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // udcSmartWorkStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spdTran);
            this.Name = "udcSmartWorkStation";
            this.Size = new System.Drawing.Size(129, 163);
            this.Load += new System.EventHandler(this.udcSmartWorkStation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spdTran)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdTran_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread spdTran;
        private FarPoint.Win.Spread.SheetView spdTran_Sheet1;
        private System.Windows.Forms.ImageList imgList;
    }
}
