namespace Miracom.EDCCore
{
    partial class frmEDCSetupValuePrompt
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
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.lisColSet = new Miracom.UI.Controls.MCListView.MCListView();
            this.colColSet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colColSetDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlPrompt = new System.Windows.Forms.Panel();
            this.spdPrompt = new FarPoint.Win.Spread.FpSpread();
            this.spdPrompt_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grpChart = new System.Windows.Forms.GroupBox();
            this.chkDefaultFlag = new System.Windows.Forms.CheckBox();
            this.cdvVersion = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.txtColSet = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblColSet = new System.Windows.Forms.Label();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlPrompt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdPrompt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdPrompt_Sheet1)).BeginInit();
            this.grpChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvVersion)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExcel
            // 
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlPrompt);
            this.pnlRight.Controls.Add(this.grpChart);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisColSet);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
            // 
            // lisColSet
            // 
            this.lisColSet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colColSet,
            this.colColSetDesc});
            this.lisColSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisColSet.EnableSort = true;
            this.lisColSet.EnableSortIcon = true;
            this.lisColSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisColSet.FullRowSelect = true;
            this.lisColSet.Location = new System.Drawing.Point(0, 0);
            this.lisColSet.MultiSelect = false;
            this.lisColSet.Name = "lisColSet";
            this.lisColSet.Size = new System.Drawing.Size(232, 506);
            this.lisColSet.TabIndex = 0;
            this.lisColSet.UseCompatibleStateImageBehavior = false;
            this.lisColSet.View = System.Windows.Forms.View.Details;
            this.lisColSet.SelectedIndexChanged += new System.EventHandler(this.lisColSet_SelectedIndexChanged);
            // 
            // colColSet
            // 
            this.colColSet.Text = "Collection Set";
            this.colColSet.Width = 100;
            // 
            // colColSetDesc
            // 
            this.colColSetDesc.Text = "Description";
            this.colColSetDesc.Width = 300;
            // 
            // pnlPrompt
            // 
            this.pnlPrompt.Controls.Add(this.spdPrompt);
            this.pnlPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrompt.Location = new System.Drawing.Point(0, 93);
            this.pnlPrompt.Name = "pnlPrompt";
            this.pnlPrompt.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlPrompt.Size = new System.Drawing.Size(506, 413);
            this.pnlPrompt.TabIndex = 1;
            // 
            // spdPrompt
            // 
            this.spdPrompt.AccessibleDescription = "spdPrompt, Sheet1, Row 0, Column 0, ";
            this.spdPrompt.BackColor = System.Drawing.SystemColors.Control;
            this.spdPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdPrompt.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdPrompt.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdPrompt.HorizontalScrollBar.Name = "";
            this.spdPrompt.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdPrompt.HorizontalScrollBar.TabIndex = 2;
            this.spdPrompt.Location = new System.Drawing.Point(0, 5);
            this.spdPrompt.Name = "spdPrompt";
            this.spdPrompt.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdPrompt.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdPrompt.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdPrompt_Sheet1});
            this.spdPrompt.Size = new System.Drawing.Size(506, 408);
            this.spdPrompt.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdPrompt.TabIndex = 0;
            this.spdPrompt.TextTipDelay = 200;
            this.spdPrompt.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdPrompt.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdPrompt.VerticalScrollBar.Name = "";
            this.spdPrompt.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdPrompt.VerticalScrollBar.TabIndex = 3;
            // 
            // spdPrompt_Sheet1
            // 
            this.spdPrompt_Sheet1.Reset();
            spdPrompt_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdPrompt_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdPrompt_Sheet1.ColumnCount = 1;
            spdPrompt_Sheet1.RowCount = 100;
            this.spdPrompt_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPrompt_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdPrompt_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPrompt_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdPrompt_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Prompt";
            this.spdPrompt_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPrompt_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            textCellType1.MaxLength = 20;
            this.spdPrompt_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.spdPrompt_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdPrompt_Sheet1.Columns.Get(0).Label = "Prompt";
            this.spdPrompt_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdPrompt_Sheet1.Columns.Get(0).Width = 300F;
            this.spdPrompt_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdPrompt_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdPrompt_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPrompt_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdPrompt_Sheet1.Rows.Default.Height = 18F;
            this.spdPrompt_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdPrompt_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdPrompt_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpChart
            // 
            this.grpChart.Controls.Add(this.chkDefaultFlag);
            this.grpChart.Controls.Add(this.cdvVersion);
            this.grpChart.Controls.Add(this.txtColSet);
            this.grpChart.Controls.Add(this.txtDesc);
            this.grpChart.Controls.Add(this.lblVersion);
            this.grpChart.Controls.Add(this.lblDesc);
            this.grpChart.Controls.Add(this.lblColSet);
            this.grpChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChart.Location = new System.Drawing.Point(0, 0);
            this.grpChart.Name = "grpChart";
            this.grpChart.Size = new System.Drawing.Size(506, 93);
            this.grpChart.TabIndex = 0;
            this.grpChart.TabStop = false;
            // 
            // chkDefaultFlag
            // 
            this.chkDefaultFlag.AutoSize = true;
            this.chkDefaultFlag.Location = new System.Drawing.Point(359, 66);
            this.chkDefaultFlag.Name = "chkDefaultFlag";
            this.chkDefaultFlag.Size = new System.Drawing.Size(106, 16);
            this.chkDefaultFlag.TabIndex = 6;
            this.chkDefaultFlag.Text = "Default Prompt";
            this.chkDefaultFlag.UseVisualStyleBackColor = true;
            this.chkDefaultFlag.CheckedChanged += new System.EventHandler(this.chkSDefaultFlag_CheckedChanged);
            // 
            // cdvVersion
            // 
            this.cdvVersion.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvVersion.BorderHotColor = System.Drawing.Color.Black;
            this.cdvVersion.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvVersion.BtnToolTipText = "";
            this.cdvVersion.DescText = "";
            this.cdvVersion.DisplaySubItemIndex = -1;
            this.cdvVersion.DisplayText = "";
            this.cdvVersion.Focusing = null;
            this.cdvVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvVersion.Index = 0;
            this.cdvVersion.IsViewBtnImage = false;
            this.cdvVersion.Location = new System.Drawing.Point(120, 64);
            this.cdvVersion.MaxLength = 3;
            this.cdvVersion.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvVersion.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvVersion.Name = "cdvVersion";
            this.cdvVersion.ReadOnly = false;
            this.cdvVersion.SearchSubItemIndex = 0;
            this.cdvVersion.SelectedDescIndex = -1;
            this.cdvVersion.SelectedSubItemIndex = -1;
            this.cdvVersion.SelectionStart = 0;
            this.cdvVersion.Size = new System.Drawing.Size(200, 23);
            this.cdvVersion.SmallImageList = null;
            this.cdvVersion.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvVersion.TabIndex = 5;
            this.cdvVersion.TextBoxToolTipText = "";
            this.cdvVersion.TextBoxWidth = 200;
            this.cdvVersion.VisibleButton = true;
            this.cdvVersion.VisibleColumnHeader = false;
            this.cdvVersion.VisibleDescription = false;
            this.cdvVersion.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvVersion_SelectedItemChanged);
            this.cdvVersion.ButtonPress += new System.EventHandler(this.cdvcdvVersion_ButtonPress);
            // 
            // txtColSet
            // 
            this.txtColSet.Location = new System.Drawing.Point(120, 16);
            this.txtColSet.MaxLength = 25;
            this.txtColSet.Name = "txtColSet";
            this.txtColSet.ReadOnly = true;
            this.txtColSet.Size = new System.Drawing.Size(200, 20);
            this.txtColSet.TabIndex = 1;
            this.txtColSet.TabStop = false;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(120, 40);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(360, 20);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.TabStop = false;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblVersion.Location = new System.Drawing.Point(15, 67);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "Version";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(15, 43);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            // 
            // lblColSet
            // 
            this.lblColSet.AutoSize = true;
            this.lblColSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblColSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColSet.Location = new System.Drawing.Point(15, 19);
            this.lblColSet.Name = "lblColSet";
            this.lblColSet.Size = new System.Drawing.Size(86, 13);
            this.lblColSet.TabIndex = 0;
            this.lblColSet.Text = "Collection Set";
            // 
            // frmEDCSetupValuePrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmEDCSetupValuePrompt";
            this.Text = "Value Prompt Setup";
            this.Activated += new System.EventHandler(this.frmEDCSetupValuePrompt_Activated);
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlPrompt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdPrompt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdPrompt_Sheet1)).EndInit();
            this.grpChart.ResumeLayout(false);
            this.grpChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvVersion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal UI.Controls.MCListView.MCListView lisColSet;
        internal System.Windows.Forms.ColumnHeader colColSet;
        internal System.Windows.Forms.ColumnHeader colColSetDesc;
        internal System.Windows.Forms.Panel pnlPrompt;
        internal FarPoint.Win.Spread.FpSpread spdPrompt;
        internal FarPoint.Win.Spread.SheetView spdPrompt_Sheet1;
        internal System.Windows.Forms.GroupBox grpChart;
        internal System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TextBox txtDesc;
        internal System.Windows.Forms.Label lblDesc;
        internal System.Windows.Forms.Label lblColSet;
        private System.Windows.Forms.TextBox txtColSet;
        private UI.Controls.MCCodeView.MCCodeView cdvVersion;
        private System.Windows.Forms.CheckBox chkDefaultFlag;
    }
}