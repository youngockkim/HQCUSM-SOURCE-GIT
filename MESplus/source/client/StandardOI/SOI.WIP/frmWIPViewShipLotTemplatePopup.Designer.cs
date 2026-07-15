namespace SOI.WIP
{
    partial class frmWIPViewShipLotTemplatePopup
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
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            this.spdDocument = new SOI.OIFrx.SOIControls.SOISpread();
            this.spdDocument_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnInput = new SOI.OIFrx.SOIControls.SOIButton(this.components);
            this.pnlPopupTop.SuspendLayout();
            this.pnlPopupBottom.SuspendLayout();
            this.pnlPopupMiddle.SuspendLayout();
            this.pnlPopupTopMargin.SuspendLayout();
            this.pnlPopupBottomMargin.SuspendLayout();
            this.pnlPopupMiddleMargin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDocument_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPopupTitle
            // 
            this.lblPopupTitle.Size = new System.Drawing.Size(1146, 38);
            this.lblPopupTitle.Text = "Input Ship Data";
            // 
            // pnlPopupTop
            // 
            this.pnlPopupTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.pnlPopupTop.Size = new System.Drawing.Size(1166, 48);
            // 
            // pnlPopupBottom
            // 
            this.pnlPopupBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlPopupBottom.Location = new System.Drawing.Point(2, 688);
            this.pnlPopupBottom.Size = new System.Drawing.Size(1166, 50);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1046, 0);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlPopupMiddle
            // 
            this.pnlPopupMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlPopupMiddle.Size = new System.Drawing.Size(1166, 634);
            // 
            // pnlPopupTopMargin
            // 
            this.pnlPopupTopMargin.Size = new System.Drawing.Size(1146, 38);
            // 
            // pnlPopupBottomMargin
            // 
            this.pnlPopupBottomMargin.Controls.Add(this.btnInput);
            this.pnlPopupBottomMargin.Size = new System.Drawing.Size(1146, 40);
            this.pnlPopupBottomMargin.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlPopupBottomMargin.Controls.SetChildIndex(this.btnInput, 0);
            // 
            // pnlPopupMiddleMargin
            // 
            this.pnlPopupMiddleMargin.Controls.Add(this.spdDocument);
            this.pnlPopupMiddleMargin.Size = new System.Drawing.Size(1146, 624);
            // 
            // spdDocument
            // 
            this.spdDocument._UseAutoHeight = false;
            this.spdDocument._UseOITheme = false;
            this.spdDocument.AccessibleDescription = "spdDocument, Sheet1, Row 0, Column 0, Input Ship Data";
            this.spdDocument.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spdDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdDocument.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDocument.HorizontalScrollBar.Name = "";
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
            this.spdDocument.HorizontalScrollBar.Renderer = enhancedScrollBarRenderer1;
            this.spdDocument.HorizontalScrollBar.TabIndex = 46;
            this.spdDocument.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdDocument.Location = new System.Drawing.Point(0, 0);
            this.spdDocument.Margin = new System.Windows.Forms.Padding(0);
            this.spdDocument.Name = "spdDocument";
            this.spdDocument.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdDocument.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdDocument.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdDocument_Sheet1});
            this.spdDocument.Size = new System.Drawing.Size(1146, 624);
            this.spdDocument.SOICellHeight = 25;
            this.spdDocument.SOIColumnHeight = 30;
            this.spdDocument.TabIndex = 2;
            this.spdDocument.TabStop = false;
            this.spdDocument.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdDocument.UseSOIContextMenu = true;
            this.spdDocument.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDocument.VerticalScrollBar.Name = "";
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
            this.spdDocument.VerticalScrollBar.Renderer = enhancedScrollBarRenderer2;
            this.spdDocument.VerticalScrollBar.TabIndex = 47;
            this.spdDocument.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdDocument.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // spdDocument_Sheet1
            // 
            this.spdDocument_Sheet1.Reset();
            spdDocument_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdDocument_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdDocument_Sheet1.ColumnCount = 9;
            spdDocument_Sheet1.RowCount = 11;
            this.spdDocument_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic1;
            this.spdDocument_Sheet1.Cells.Get(0, 0).ColumnSpan = 9;
            this.spdDocument_Sheet1.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(0, 0).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(0, 0).Value = "Input Ship Data";
            this.spdDocument_Sheet1.Cells.Get(0, 1).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(0, 2).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(0, 3).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(0, 4).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(0, 5).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(0, 6).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(0, 7).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(0, 8).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(1, 0).ColumnSpan = 9;
            this.spdDocument_Sheet1.Cells.Get(1, 0).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(1, 1).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(1, 2).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(1, 3).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(1, 4).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(1, 5).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(1, 6).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(1, 7).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(1, 8).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(2, 0).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(2, 0).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(2, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 0).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(2, 0).Value = "Customer";
            this.spdDocument_Sheet1.Cells.Get(2, 1).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(2, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 1).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(2, 2).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(2, 2).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(2, 2).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(2, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 2).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(2, 2).Value = "Lot ID";
            this.spdDocument_Sheet1.Cells.Get(2, 3).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(2, 4).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(2, 4).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(2, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 4).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(2, 5).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(2, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 5).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(2, 6).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(2, 6).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(2, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 6).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(2, 6).Value = "Lot Qty";
            this.spdDocument_Sheet1.Cells.Get(2, 7).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(2, 7).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(2, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 7).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(2, 8).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(2, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(2, 8).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(3, 0).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(3, 0).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(3, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(3, 0).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(3, 0).Value = "Supplier";
            this.spdDocument_Sheet1.Cells.Get(3, 1).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(3, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(3, 1).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(3, 2).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(3, 2).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(3, 2).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(3, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(3, 2).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(3, 2).Value = "Material";
            this.spdDocument_Sheet1.Cells.Get(3, 3).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(3, 4).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(3, 4).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(3, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(3, 4).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(3, 5).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(3, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(3, 5).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(3, 6).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(3, 6).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(3, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(3, 6).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(3, 6).Value = "Work Order";
            this.spdDocument_Sheet1.Cells.Get(3, 7).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(3, 7).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(3, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(3, 7).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(3, 8).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(3, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(3, 8).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(4, 0).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(4, 0).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(4, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(4, 0).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(4, 0).Value = "Inspect Operation";
            this.spdDocument_Sheet1.Cells.Get(4, 1).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(4, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(4, 1).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(4, 2).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(4, 2).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(4, 2).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(4, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(4, 2).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(4, 2).Value = "Inspect Date";
            this.spdDocument_Sheet1.Cells.Get(4, 3).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(4, 4).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(4, 4).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(4, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(4, 4).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(4, 5).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(4, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(4, 5).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(4, 6).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(4, 6).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(4, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(4, 6).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(4, 6).Value = "Inspector";
            this.spdDocument_Sheet1.Cells.Get(4, 7).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(4, 7).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(4, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(4, 7).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(4, 8).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(4, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(4, 8).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(5, 0).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(5, 0).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(5, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(5, 0).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(5, 0).Value = "Line";
            this.spdDocument_Sheet1.Cells.Get(5, 1).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(5, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(5, 1).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(5, 2).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(5, 2).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(5, 2).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(5, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(5, 2).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(5, 3).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(5, 4).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(5, 4).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(5, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(5, 4).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(5, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(5, 5).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(5, 6).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(5, 6).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(5, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(5, 6).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(5, 7).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(5, 7).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(5, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(5, 7).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(5, 8).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(5, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(5, 8).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(6, 0).ColumnSpan = 9;
            this.spdDocument_Sheet1.Cells.Get(6, 0).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(6, 0).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(6, 1).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(6, 1).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(6, 2).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(6, 2).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(6, 3).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(6, 4).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(6, 4).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(6, 5).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(6, 6).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(6, 6).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(6, 7).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(6, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(6, 7).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(6, 8).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(6, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(6, 8).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(7, 0).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(7, 0).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(7, 0).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(7, 0).Value = "Inspect Item";
            this.spdDocument_Sheet1.Cells.Get(7, 1).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(7, 1).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(7, 1).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(7, 1).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(7, 1).Value = "Result";
            this.spdDocument_Sheet1.Cells.Get(7, 2).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(7, 2).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(7, 2).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(7, 2).Value = "Material ID";
            this.spdDocument_Sheet1.Cells.Get(7, 3).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(7, 3).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(7, 3).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(7, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(7, 3).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(7, 3).Value = "Remark";
            this.spdDocument_Sheet1.Cells.Get(7, 4).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(7, 4).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(7, 4).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(7, 4).Value = "Material Name";
            this.spdDocument_Sheet1.Cells.Get(7, 5).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(7, 5).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(7, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(7, 5).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(7, 5).Value = "Inspect Item";
            this.spdDocument_Sheet1.Cells.Get(7, 6).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(7, 6).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(7, 6).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(7, 6).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(7, 6).Value = "Result";
            this.spdDocument_Sheet1.Cells.Get(7, 7).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(7, 8).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.Cells.Get(7, 8).Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(7, 8).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(7, 8).Value = "Remark";
            this.spdDocument_Sheet1.Cells.Get(8, 0).Font = new System.Drawing.Font("Malgun Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(8, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(8, 0).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(8, 0).Value = "Appearance";
            this.spdDocument_Sheet1.Cells.Get(8, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(8, 1).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(8, 1).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(8, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(8, 1).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(8, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(8, 2).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(8, 2).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(8, 3).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(8, 3).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(8, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDocument_Sheet1.Cells.Get(8, 3).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(8, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(8, 4).Font = new System.Drawing.Font("Malgun Gothic", 11F);
            this.spdDocument_Sheet1.Cells.Get(8, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDocument_Sheet1.Cells.Get(8, 4).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(8, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(8, 5).Font = new System.Drawing.Font("Malgun Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(8, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(8, 5).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(8, 5).Value = "Assembly";
            this.spdDocument_Sheet1.Cells.Get(8, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(8, 6).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(8, 6).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(8, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(8, 6).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(8, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(8, 7).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(8, 7).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(8, 8).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(8, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDocument_Sheet1.Cells.Get(8, 8).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(8, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(9, 0).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(9, 0).Value = "Function";
            this.spdDocument_Sheet1.Cells.Get(9, 1).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(9, 1).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(9, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(9, 1).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(9, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(9, 2).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(9, 2).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(9, 3).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(9, 3).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(9, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDocument_Sheet1.Cells.Get(9, 3).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(9, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(9, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDocument_Sheet1.Cells.Get(9, 4).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(9, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(9, 5).Font = new System.Drawing.Font("Malgun Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(9, 5).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(9, 5).Value = "Packaging";
            this.spdDocument_Sheet1.Cells.Get(9, 6).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(9, 6).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(9, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(9, 6).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(9, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(9, 7).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(9, 7).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(9, 8).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(9, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDocument_Sheet1.Cells.Get(9, 8).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(9, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(10, 0).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(10, 0).Value = "Component";
            this.spdDocument_Sheet1.Cells.Get(10, 1).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(10, 1).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(10, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(10, 1).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(10, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(10, 2).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(10, 2).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(10, 3).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(10, 3).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(10, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDocument_Sheet1.Cells.Get(10, 3).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(10, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(10, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDocument_Sheet1.Cells.Get(10, 4).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(10, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(10, 5).Font = new System.Drawing.Font("Malgun Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Cells.Get(10, 5).Locked = true;
            this.spdDocument_Sheet1.Cells.Get(10, 5).Value = "Comment";
            this.spdDocument_Sheet1.Cells.Get(10, 6).ColumnSpan = 2;
            this.spdDocument_Sheet1.Cells.Get(10, 6).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(10, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(10, 6).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(10, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Cells.Get(10, 7).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(10, 7).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(10, 8).Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.spdDocument_Sheet1.Cells.Get(10, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDocument_Sheet1.Cells.Get(10, 8).Locked = false;
            this.spdDocument_Sheet1.Cells.Get(10, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.ColumnFooter.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDocument_Sheet1.ColumnFooter.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdDocument_Sheet1.ColumnFooter.DefaultStyle.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.ColumnFooter.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.spdDocument_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDocument_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdDocument_Sheet1.ColumnFooter.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDocument_Sheet1.ColumnFooter.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDocument_Sheet1.ColumnFooterSheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdDocument_Sheet1.ColumnFooterSheetCornerStyle.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.ColumnFooterSheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.spdDocument_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDocument_Sheet1.ColumnFooterSheetCornerStyle.Parent = "HeaderDefault";
            this.spdDocument_Sheet1.ColumnFooterSheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDocument_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDocument_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdDocument_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdDocument_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDocument_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdDocument_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDocument_Sheet1.ColumnHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDocument_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDocument_Sheet1.ColumnHeader.Rows.Get(0).Height = 30F;
            this.spdDocument_Sheet1.ColumnHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDocument_Sheet1.ColumnHeader.Visible = false;
            this.spdDocument_Sheet1.Columns.Get(0).Locked = true;
            this.spdDocument_Sheet1.Columns.Get(0).Width = 167F;
            this.spdDocument_Sheet1.Columns.Get(1).Locked = true;
            this.spdDocument_Sheet1.Columns.Get(1).Width = 163F;
            this.spdDocument_Sheet1.Columns.Get(2).Locked = true;
            this.spdDocument_Sheet1.Columns.Get(2).Width = 64F;
            this.spdDocument_Sheet1.Columns.Get(3).Width = 78F;
            this.spdDocument_Sheet1.Columns.Get(4).Locked = true;
            this.spdDocument_Sheet1.Columns.Get(4).Width = 64F;
            this.spdDocument_Sheet1.Columns.Get(5).Width = 168F;
            this.spdDocument_Sheet1.Columns.Get(6).Locked = true;
            this.spdDocument_Sheet1.Columns.Get(6).Width = 131F;
            this.spdDocument_Sheet1.Columns.Get(7).Width = 64F;
            this.spdDocument_Sheet1.Columns.Get(8).Locked = true;
            this.spdDocument_Sheet1.Columns.Get(8).Width = 130F;
            this.spdDocument_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.spdDocument_Sheet1.DefaultStyle.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.spdDocument_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDocument_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdDocument_Sheet1.GrayAreaBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdDocument_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDocument_Sheet1.PrintInfo.ShowColor = true;
            this.spdDocument_Sheet1.PrintInfo.UseSmartPrint = true;
            this.spdDocument_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdDocument_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDocument_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdDocument_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdDocument_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDocument_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdDocument_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDocument_Sheet1.RowHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDocument_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDocument_Sheet1.RowHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDocument_Sheet1.RowHeader.Visible = false;
            this.spdDocument_Sheet1.Rows.Get(0).Font = new System.Drawing.Font("Malgun Gothic", 22F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.Rows.Get(0).Height = 70F;
            this.spdDocument_Sheet1.Rows.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Rows.Get(1).Height = 10F;
            this.spdDocument_Sheet1.Rows.Get(2).Height = 30F;
            this.spdDocument_Sheet1.Rows.Get(3).Height = 30F;
            this.spdDocument_Sheet1.Rows.Get(4).Height = 30F;
            this.spdDocument_Sheet1.Rows.Get(5).Height = 30F;
            this.spdDocument_Sheet1.Rows.Get(6).Height = 10F;
            this.spdDocument_Sheet1.Rows.Get(7).Height = 30F;
            this.spdDocument_Sheet1.Rows.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Rows.Get(8).Font = new System.Drawing.Font("Malgun Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.spdDocument_Sheet1.Rows.Get(8).Height = 100F;
            this.spdDocument_Sheet1.Rows.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Rows.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Rows.Get(9).Font = new System.Drawing.Font("Malgun Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.spdDocument_Sheet1.Rows.Get(9).Height = 100F;
            this.spdDocument_Sheet1.Rows.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Rows.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.Rows.Get(10).Font = new System.Drawing.Font("Malgun Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.spdDocument_Sheet1.Rows.Get(10).Height = 100F;
            this.spdDocument_Sheet1.Rows.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDocument_Sheet1.Rows.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDocument_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdDocument_Sheet1.SheetCornerHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDocument_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdDocument_Sheet1.SheetCornerStyle.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.spdDocument_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdDocument_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDocument_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.spdDocument_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDocument_Sheet1.SheetCornerVerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDocument_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdDocument_Sheet1.ZoomFactor = 1.1F;
            this.spdDocument_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnInput
            // 
            this.btnInput._UseOITheme = true;
            this.btnInput._UseStyle = SOI.OIFrx.SOIButtonStyle.DefaultStyle;
            this.btnInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance44.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance44.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance44.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance44.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance44.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance44.FontData.BoldAsString = "True";
            appearance44.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance44.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnInput.Appearance = appearance44;
            this.btnInput.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnInput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInput.DialogResult = System.Windows.Forms.DialogResult.OK;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance45.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance45.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance45.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            this.btnInput.HotTrackAppearance = appearance45;
            this.btnInput.Location = new System.Drawing.Point(936, 0);
            this.btnInput.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnInput.Name = "btnInput";
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance46.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance46.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance46.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            this.btnInput.PressedAppearance = appearance46;
            this.btnInput.ShowFocusRect = false;
            this.btnInput.ShowOutline = false;
            this.btnInput.Size = new System.Drawing.Size(100, 40);
            this.btnInput.TabIndex = 4;
            this.btnInput.Text = "Save";
            this.btnInput.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnInput.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnInput.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // frmWIPViewShipLotTemplatePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 740);
            this.Name = "frmWIPViewShipLotTemplatePopup";
            this.Text = "frmWIPViewShipLotTemplatePopup";
            this.Load += new System.EventHandler(this.frmTempSOIPopup_Load);
            this.pnlPopupTop.ResumeLayout(false);
            this.pnlPopupBottom.ResumeLayout(false);
            this.pnlPopupMiddle.ResumeLayout(false);
            this.pnlPopupTopMargin.ResumeLayout(false);
            this.pnlPopupBottomMargin.ResumeLayout(false);
            this.pnlPopupMiddleMargin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDocument_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OIFrx.SOIControls.SOISpread spdDocument;
        private FarPoint.Win.Spread.SheetView spdDocument_Sheet1;
        private OIFrx.SOIControls.SOIButton btnInput;
    }
}