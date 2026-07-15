namespace Miracom.WEMCore.Setup
{
    partial class udcStepActionCarrierEvent
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
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder2 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder1 = new FarPoint.Win.CompoundBorder(bevelBorder1, bevelBorder2);
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.pnlActionTop = new System.Windows.Forms.Panel();
            this.cdvCrrEventID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblEvent = new System.Windows.Forms.Label();
            this.pnlActionMid = new System.Windows.Forms.Panel();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grpActionValue.SuspendLayout();
            this.pnlActionTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrEventID)).BeginInit();
            this.pnlActionMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpActionValue
            // 
            this.grpActionValue.Controls.Add(this.pnlActionMid);
            this.grpActionValue.Controls.Add(this.pnlActionTop);
            // 
            // pnlActionTop
            // 
            this.pnlActionTop.Controls.Add(this.cdvCrrEventID);
            this.pnlActionTop.Controls.Add(this.lblEvent);
            this.pnlActionTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActionTop.Location = new System.Drawing.Point(3, 16);
            this.pnlActionTop.Name = "pnlActionTop";
            this.pnlActionTop.Size = new System.Drawing.Size(234, 30);
            this.pnlActionTop.TabIndex = 0;
            // 
            // cdvCrrEventID
            // 
            this.cdvCrrEventID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvCrrEventID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrrEventID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrrEventID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrrEventID.BtnToolTipText = "";
            this.cdvCrrEventID.DescText = "";
            this.cdvCrrEventID.DisplaySubItemIndex = 1;
            this.cdvCrrEventID.DisplayText = "";
            this.cdvCrrEventID.Focusing = null;
            this.cdvCrrEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrrEventID.Index = 0;
            this.cdvCrrEventID.IsViewBtnImage = false;
            this.cdvCrrEventID.Location = new System.Drawing.Point(97, 4);
            this.cdvCrrEventID.MaxLength = 12;
            this.cdvCrrEventID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrEventID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrEventID.Name = "cdvCrrEventID";
            this.cdvCrrEventID.ReadOnly = true;
            this.cdvCrrEventID.SearchSubItemIndex = 0;
            this.cdvCrrEventID.SelectedDescIndex = 0;
            this.cdvCrrEventID.SelectedSubItemIndex = 0;
            this.cdvCrrEventID.SelectionStart = 0;
            this.cdvCrrEventID.Size = new System.Drawing.Size(134, 20);
            this.cdvCrrEventID.SmallImageList = null;
            this.cdvCrrEventID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrEventID.TabIndex = 9;
            this.cdvCrrEventID.TextBoxToolTipText = "";
            this.cdvCrrEventID.TextBoxWidth = 134;
            this.cdvCrrEventID.VisibleButton = true;
            this.cdvCrrEventID.VisibleColumnHeader = false;
            this.cdvCrrEventID.VisibleDescription = false;
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEvent.Location = new System.Drawing.Point(3, 8);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(68, 13);
            this.lblEvent.TabIndex = 8;
            this.lblEvent.Text = "Carrier Event";
            // 
            // pnlActionMid
            // 
            this.pnlActionMid.Controls.Add(this.spdData);
            this.pnlActionMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActionMid.Location = new System.Drawing.Point(3, 46);
            this.pnlActionMid.Name = "pnlActionMid";
            this.pnlActionMid.Size = new System.Drawing.Size(234, 268);
            this.pnlActionMid.TabIndex = 1;
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, LotInfo, Row 0, Column 0, ";
            this.spdData.BackColor = System.Drawing.SystemColors.Control;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 12;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdData.Location = new System.Drawing.Point(0, 0);
            this.spdData.MoveActiveOnFocus = false;
            this.spdData.Name = "spdData";
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(234, 268);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 1;
            this.spdData.TabStop = false;
            this.spdData.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 13;
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "LotInfo";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 3;
            spdData_Sheet1.RowCount = 3;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Carrier Articles";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).ColumnSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Change Status";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdData_Sheet1.Columns.Get(0).Border = compoundBorder1;
            this.spdData_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.spdData_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdData_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(0).Label = "Carrier Articles";
            this.spdData_Sheet1.Columns.Get(0).Locked = true;
            this.spdData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Width = 100F;
            this.spdData_Sheet1.Columns.Get(1).Label = "Change Status";
            this.spdData_Sheet1.Columns.Get(1).Locked = false;
            this.spdData_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Width = 93F;
            this.spdData_Sheet1.Columns.Get(2).Width = 20F;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.RowHeader.Visible = false;
            this.spdData_Sheet1.Rows.Default.Height = 17F;
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // udcProcessActionCarrierEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "udcProcessActionCarrierEvent";
            this.grpActionValue.ResumeLayout(false);
            this.pnlActionTop.ResumeLayout(false);
            this.pnlActionTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrEventID)).EndInit();
            this.pnlActionMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlActionMid;
        private System.Windows.Forms.Panel pnlActionTop;
        private UI.Controls.MCCodeView.MCCodeView cdvCrrEventID;
        private System.Windows.Forms.Label lblEvent;
        protected FarPoint.Win.Spread.FpSpread spdData;
        protected FarPoint.Win.Spread.SheetView spdData_Sheet1;

    }
}
