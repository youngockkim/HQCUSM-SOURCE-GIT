namespace Miracom.QCMCore
{
    partial class frmQCMViewQCBatchHistory
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.txtBatchID = new System.Windows.Forms.TextBox();
            this.lblBatchID = new System.Windows.Forms.Label();
            this.grpHistory = new System.Windows.Forms.GroupBox();
            this.spdHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlPeriod.SuspendLayout();
            this.grpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).BeginInit();
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
            this.pnlViewTop.Size = new System.Drawing.Size(742, 42);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.txtBatchID);
            this.grpOption.Controls.Add(this.lblBatchID);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Size = new System.Drawing.Size(742, 42);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.grpHistory);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 42);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(3);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 471);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "ViewForm01";
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(149, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(14, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            // 
            // dtpTo
            // 
            this.dtpTo.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(167, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(90, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.Location = new System.Drawing.Point(0, 3);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(43, 13);
            this.lblPeriod.TabIndex = 0;
            this.lblPeriod.Text = "Period";
            this.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(56, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(90, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Enabled = false;
            this.pnlPeriod.Location = new System.Drawing.Point(455, 15);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(257, 20);
            this.pnlPeriod.TabIndex = 5;
            this.pnlPeriod.Visible = false;
            // 
            // txtBatchID
            // 
            this.txtBatchID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtBatchID.Location = new System.Drawing.Point(120, 15);
            this.txtBatchID.MaxLength = 30;
            this.txtBatchID.Name = "txtBatchID";
            this.txtBatchID.Size = new System.Drawing.Size(200, 20);
            this.txtBatchID.TabIndex = 13;
            this.txtBatchID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBatchID_KeyPress);
            // 
            // lblBatchID
            // 
            this.lblBatchID.AutoSize = true;
            this.lblBatchID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBatchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatchID.Location = new System.Drawing.Point(15, 19);
            this.lblBatchID.Name = "lblBatchID";
            this.lblBatchID.Size = new System.Drawing.Size(57, 13);
            this.lblBatchID.TabIndex = 12;
            this.lblBatchID.Text = "Batch ID";
            this.lblBatchID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpHistory
            // 
            this.grpHistory.Controls.Add(this.spdHistory);
            this.grpHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHistory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpHistory.Location = new System.Drawing.Point(3, 3);
            this.grpHistory.Name = "grpHistory";
            this.grpHistory.Size = new System.Drawing.Size(736, 465);
            this.grpHistory.TabIndex = 9;
            this.grpHistory.TabStop = false;
            this.grpHistory.Text = "Batch History";
            // 
            // spdHistory
            // 
            this.spdHistory.AccessibleDescription = "spdHistory, Sheet1, Row 0, Column 0, ";
            this.spdHistory.BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdHistory.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdHistory.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.HorizontalScrollBar.Name = "";
            this.spdHistory.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdHistory.HorizontalScrollBar.TabIndex = 2;
            this.spdHistory.Location = new System.Drawing.Point(3, 16);
            this.spdHistory.Name = "spdHistory";
            this.spdHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdHistory.SelectionBlockOptions = ((FarPoint.Win.Spread.SelectionBlockOptions)((FarPoint.Win.Spread.SelectionBlockOptions.Cells | FarPoint.Win.Spread.SelectionBlockOptions.Rows)));
            this.spdHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdHistory_Sheet1});
            this.spdHistory.Size = new System.Drawing.Size(730, 446);
            this.spdHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdHistory.TabIndex = 5;
            this.spdHistory.TabStop = false;
            this.spdHistory.TextTipDelay = 200;
            this.spdHistory.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdHistory.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.VerticalScrollBar.Name = "";
            this.spdHistory.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdHistory.VerticalScrollBar.TabIndex = 3;
            this.spdHistory.SetViewportLeftColumn(0, 0, 4);
            // 
            // spdHistory_Sheet1
            // 
            this.spdHistory_Sheet1.Reset();
            spdHistory_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdHistory_Sheet1.ColumnCount = 25;
            spdHistory_Sheet1.RowCount = 3;
            this.spdHistory_Sheet1.AlternatingRows.Get(0).BackColor = System.Drawing.Color.White;
            this.spdHistory_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Insp Method";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Mat ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Mat Ver";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Insp Set ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Insp Set Version";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Item Count";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Qty";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Insp Step";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Tran Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Final Decision";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Insp Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Bat Cmf 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Bat Cmf 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Bat Cmf 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Bat Cmf 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Bat Cmf 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Bat Cmf 6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Bat Cmf 7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Bat Cmf 8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Bat Cmf 9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Bat Cmf 10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Comment";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Tran User Id";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Tran Time";
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdHistory_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdHistory_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(0).Label = "Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(0).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(1).Label = "Insp Method";
            this.spdHistory_Sheet1.Columns.Get(1).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(1).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(2).Label = "Mat ID";
            this.spdHistory_Sheet1.Columns.Get(2).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(2).Width = 121F;
            this.spdHistory_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(3).Label = "Mat Ver";
            this.spdHistory_Sheet1.Columns.Get(3).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(3).Width = 97F;
            this.spdHistory_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(4).Label = "Insp Set ID";
            this.spdHistory_Sheet1.Columns.Get(4).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(4).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(5).Label = "Insp Set Version";
            this.spdHistory_Sheet1.Columns.Get(5).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(5).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(6).Label = "Item Count";
            this.spdHistory_Sheet1.Columns.Get(6).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(6).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(7).Label = "Qty";
            this.spdHistory_Sheet1.Columns.Get(7).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(7).Width = 82F;
            this.spdHistory_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(8).Label = "Insp Step";
            this.spdHistory_Sheet1.Columns.Get(8).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(9).Label = "Tran Code";
            this.spdHistory_Sheet1.Columns.Get(9).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(9).Width = 91F;
            this.spdHistory_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(10).Label = "Final Decision";
            this.spdHistory_Sheet1.Columns.Get(10).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(10).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(11).Label = "Insp Seq";
            this.spdHistory_Sheet1.Columns.Get(11).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(11).Width = 72F;
            this.spdHistory_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdHistory_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdHistory_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdHistory_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmQCMViewQCBatchHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmQCMViewQCBatchHistory";
            this.Tag = "QCM3002";
            this.Text = "View QC Batch History";
            this.Activated += new System.EventHandler(this.frmQCMViewQCBatchHistory_Activated);
            this.Load += new System.EventHandler(this.frmQCMViewQCBatchHistory_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            this.grpHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        protected System.Windows.Forms.TextBox txtBatchID;
        protected System.Windows.Forms.Label lblBatchID;
        private System.Windows.Forms.GroupBox grpHistory;
        private FarPoint.Win.Spread.FpSpread spdHistory;
        private FarPoint.Win.Spread.SheetView spdHistory_Sheet1;
    }
}
