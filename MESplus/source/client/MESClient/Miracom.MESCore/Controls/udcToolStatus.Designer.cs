namespace Miracom.MESCore.Controls
{
    partial class udcToolStatus
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder2 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder1 = new FarPoint.Win.CompoundBorder(bevelBorder1, bevelBorder2);
            this.spdToolStatus = new FarPoint.Win.Spread.FpSpread();
            this.spdToolStatus_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.cdvTableList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            ((System.ComponentModel.ISupportInitialize)(this.spdToolStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdToolStatus_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).BeginInit();
            this.SuspendLayout();
            // 
            // spdToolStatus
            // 
            this.spdToolStatus.AccessibleDescription = "spdToolStatus, Sheet1, Row 0, Column 0, ";
            this.spdToolStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdToolStatus.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdToolStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdToolStatus.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdToolStatus.HorizontalScrollBar.Name = "";
            this.spdToolStatus.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdToolStatus.HorizontalScrollBar.TabIndex = 22;
            this.spdToolStatus.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdToolStatus.Location = new System.Drawing.Point(0, 0);
            this.spdToolStatus.MoveActiveOnFocus = false;
            this.spdToolStatus.Name = "spdToolStatus";
            this.spdToolStatus.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdToolStatus.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdToolStatus.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdToolStatus_Sheet1});
            this.spdToolStatus.Size = new System.Drawing.Size(410, 200);
            this.spdToolStatus.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdToolStatus.TabIndex = 0;
            this.spdToolStatus.TabStop = false;
            this.spdToolStatus.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.spdToolStatus.TextTipDelay = 200;
            this.spdToolStatus.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdToolStatus.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdToolStatus.VerticalScrollBar.Name = "";
            this.spdToolStatus.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdToolStatus.VerticalScrollBar.TabIndex = 23;
            this.spdToolStatus.EditModeOff += new System.EventHandler(this.spdToolStatus_EditModeOff);
            this.spdToolStatus.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdToolStatus_ButtonClicked);
            this.spdToolStatus.SetActiveViewport(0, -1, -1);
            // 
            // spdToolStatus_Sheet1
            // 
            this.spdToolStatus_Sheet1.Reset();
            this.spdToolStatus_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdToolStatus_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spdToolStatus_Sheet1.ColumnCount = 5;
            this.spdToolStatus_Sheet1.RowCount = 0;
            this.spdToolStatus_Sheet1.ActiveColumnIndex = -1;
            this.spdToolStatus_Sheet1.ActiveRowIndex = -1;
            this.spdToolStatus_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdToolStatus_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdToolStatus_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdToolStatus_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault";
            this.spdToolStatus_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Tool Articles";
            this.spdToolStatus_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Current Tool Status";
            this.spdToolStatus_Sheet1.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 2;
            this.spdToolStatus_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Tool Status Forecast";
            this.spdToolStatus_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Tool Status Forecast";
            this.spdToolStatus_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdToolStatus_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdToolStatus_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdToolStatus_Sheet1.Columns.Get(0).Border = compoundBorder1;
            this.spdToolStatus_Sheet1.Columns.Get(0).Label = "Tool Articles";
            this.spdToolStatus_Sheet1.Columns.Get(0).Width = 120F;
            this.spdToolStatus_Sheet1.Columns.Get(1).Label = "Current Tool Status";
            this.spdToolStatus_Sheet1.Columns.Get(1).Width = 120F;
            this.spdToolStatus_Sheet1.Columns.Get(2).Label = "Tool Status Forecast";
            this.spdToolStatus_Sheet1.Columns.Get(2).Width = 110F;
            this.spdToolStatus_Sheet1.Columns.Get(3).Width = 21F;
            this.spdToolStatus_Sheet1.Columns.Get(4).BackColor = System.Drawing.SystemColors.Control;
            this.spdToolStatus_Sheet1.Columns.Get(4).Label = "Tool Status Forecast";
            this.spdToolStatus_Sheet1.Columns.Get(4).Width = 120F;
            this.spdToolStatus_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdToolStatus_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdToolStatus_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdToolStatus_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdToolStatus_Sheet1.RowHeader.Visible = false;
            this.spdToolStatus_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdToolStatus_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault";
            this.spdToolStatus_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // cdvTableList
            // 
            this.cdvTableList.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvTableList.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableList.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvTableList.Location = new System.Drawing.Point(180, 17);
            this.cdvTableList.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableList.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableList.Name = "cdvTableList";
            this.cdvTableList.Size = new System.Drawing.Size(20, 20);
            this.cdvTableList.SmallImageList = null;
            this.cdvTableList.TabIndex = 0;
            this.cdvTableList.TabStop = false;
            this.cdvTableList.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvTableList.Visible = false;
            this.cdvTableList.VisibleColumnHeader = false;
            this.cdvTableList.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvTableList_SelectedItemChanged);
            // 
            // udcToolStatus
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.spdToolStatus);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "udcToolStatus";
            this.Size = new System.Drawing.Size(410, 200);
            ((System.ComponentModel.ISupportInitialize)(this.spdToolStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdToolStatus_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected FarPoint.Win.Spread.FpSpread spdToolStatus;
        protected FarPoint.Win.Spread.SheetView spdToolStatus_Sheet1;
        private UI.Controls.MCCodeView.MCSPCodeView cdvTableList;

    }
}
