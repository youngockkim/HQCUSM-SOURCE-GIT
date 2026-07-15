namespace Custom.HanwhaQcell.USModule
{
    partial class frmViewProdMonitoring
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
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("DataAreaGrayscale");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.label4 = new System.Windows.Forms.Label();
            this.cdvCategory = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.txtMainCode = new System.Windows.Forms.TextBox();
            this.lblItemDesc = new System.Windows.Forms.Label();
            this.txtSubCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.txtSubCode);
            this.grpOption.Controls.Add(this.label1);
            this.grpOption.Controls.Add(this.txtMainCode);
            this.grpOption.Controls.Add(this.lblItemDesc);
            this.grpOption.Controls.Add(this.label4);
            this.grpOption.Controls.Add(this.cdvCategory);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdList);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 435);
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
            this.lblFormTitle.Text = "View Prod Monitoring";
            // 
            // spdList
            // 
            this.spdList.AccessibleDescription = "spdEquipList, Sheet1, Row 0, Column 0, ";
            this.spdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.HorizontalScrollBar.Name = "";
            this.spdList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdList.HorizontalScrollBar.TabIndex = 76;
            this.spdList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdList.Location = new System.Drawing.Point(0, 0);
            this.spdList.Name = "spdList";
            namedStyle1.BackColor = System.Drawing.Color.Gainsboro;
            namedStyle1.CellType = generalCellType1;
            namedStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Renderer = generalCellType1;
            this.spdList.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1});
            this.spdList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdList_Sheet1});
            this.spdList.Size = new System.Drawing.Size(742, 435);
            this.spdList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdList.TabIndex = 53;
            this.spdList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.VerticalScrollBar.Name = "";
            this.spdList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdList.VerticalScrollBar.TabIndex = 77;
            this.spdList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdList.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // spdList_Sheet1
            // 
            this.spdList_Sheet1.Reset();
            spdList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdList_Sheet1.ColumnCount = 9;
            spdList_Sheet1.RowCount = 1;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Base Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Sub Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Last Tran Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Base D/T";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Login User ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Client Version";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Printer Status";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Status Message";
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
            this.spdList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(0).Label = "Base Code";
            this.spdList_Sheet1.Columns.Get(0).Locked = true;
            this.spdList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(0).Width = 120F;
            this.spdList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(1).Label = "Sub Code";
            this.spdList_Sheet1.Columns.Get(1).Locked = true;
            this.spdList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(1).Width = 100F;
            this.spdList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(2).Label = "Description";
            this.spdList_Sheet1.Columns.Get(2).Locked = true;
            this.spdList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(2).Width = 200F;
            this.spdList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(3).Label = "Last Tran Time";
            this.spdList_Sheet1.Columns.Get(3).Locked = true;
            this.spdList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(3).Width = 140F;
            this.spdList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(4).Label = "Base D/T";
            this.spdList_Sheet1.Columns.Get(4).Locked = true;
            this.spdList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(5).Label = "Login User ID";
            this.spdList_Sheet1.Columns.Get(5).Locked = true;
            this.spdList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(5).Width = 100F;
            this.spdList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(6).Label = "Client Version";
            this.spdList_Sheet1.Columns.Get(6).Locked = true;
            this.spdList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(6).Width = 88F;
            this.spdList_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(7).Label = "Printer Status";
            this.spdList_Sheet1.Columns.Get(7).Locked = true;
            this.spdList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(7).Width = 88F;
            this.spdList_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(8).Label = "Status Message";
            this.spdList_Sheet1.Columns.Get(8).Locked = true;
            this.spdList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(8).Width = 150F;
            this.spdList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdList_Sheet1.RowHeader.Columns.Get(0).Width = 25F;
            this.spdList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(35, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 154;
            this.label4.Text = "Category";
            // 
            // cdvCategory
            // 
            this.cdvCategory.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCategory.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCategory.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCategory.BtnToolTipText = "";
            this.cdvCategory.ButtonWidth = 20;
            this.cdvCategory.DescText = "";
            this.cdvCategory.DisplaySubItemIndex = 0;
            this.cdvCategory.DisplayText = "";
            this.cdvCategory.Focusing = null;
            this.cdvCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCategory.Index = 0;
            this.cdvCategory.IsViewBtnImage = false;
            this.cdvCategory.Location = new System.Drawing.Point(108, 12);
            this.cdvCategory.MaxLength = 20;
            this.cdvCategory.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCategory.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCategory.MultiSelect = false;
            this.cdvCategory.Name = "cdvCategory";
            this.cdvCategory.ReadOnly = false;
            this.cdvCategory.SameWidthHeightOfButton = false;
            this.cdvCategory.SearchSubItemIndex = 0;
            this.cdvCategory.SelectedDescIndex = 1;
            this.cdvCategory.SelectedDescToQueryText = "";
            this.cdvCategory.SelectedSubItemIndex = 0;
            this.cdvCategory.SelectedValueToQueryText = "";
            this.cdvCategory.SelectionStart = 0;
            this.cdvCategory.Size = new System.Drawing.Size(211, 20);
            this.cdvCategory.SmallImageList = null;
            this.cdvCategory.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCategory.TabIndex = 155;
            this.cdvCategory.TextBoxToolTipText = "";
            this.cdvCategory.TextBoxWidth = 85;
            this.cdvCategory.VisibleButton = true;
            this.cdvCategory.VisibleColumnHeader = false;
            this.cdvCategory.VisibleDescription = true;
            this.cdvCategory.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCategory_SelectedItemChanged);
            this.cdvCategory.ButtonPress += new System.EventHandler(this.cdvCategory_ButtonPress);
            // 
            // txtMainCode
            // 
            this.txtMainCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMainCode.Location = new System.Drawing.Point(108, 38);
            this.txtMainCode.MaxLength = 100;
            this.txtMainCode.Name = "txtMainCode";
            this.txtMainCode.Size = new System.Drawing.Size(211, 20);
            this.txtMainCode.TabIndex = 157;
            // 
            // lblItemDesc
            // 
            this.lblItemDesc.AutoSize = true;
            this.lblItemDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblItemDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemDesc.Location = new System.Drawing.Point(35, 42);
            this.lblItemDesc.Name = "lblItemDesc";
            this.lblItemDesc.Size = new System.Drawing.Size(59, 13);
            this.lblItemDesc.TabIndex = 156;
            this.lblItemDesc.Text = "Base Code";
            this.lblItemDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSubCode
            // 
            this.txtSubCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubCode.Location = new System.Drawing.Point(407, 38);
            this.txtSubCode.MaxLength = 100;
            this.txtSubCode.Name = "txtSubCode";
            this.txtSubCode.Size = new System.Drawing.Size(211, 20);
            this.txtSubCode.TabIndex = 159;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(334, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 158;
            this.label1.Text = "Sub Code";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmViewProdMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmViewProdMonitoring";
            this.Text = "View Prod Monitoring";
            this.Activated += new System.EventHandler(this.frmViewProdMonitoring_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        private System.Windows.Forms.Label label4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCategory;
        private System.Windows.Forms.TextBox txtSubCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMainCode;
        private System.Windows.Forms.Label lblItemDesc;
    }
}