namespace Miracom.MESCore.Controls
{
    partial class udcViewAttach
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
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer3 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer3 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer4 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer4 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType2 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            this.pnlAttachBottom = new System.Windows.Forms.Panel();
            this.grpFileAttach = new System.Windows.Forms.GroupBox();
            this.spdFileAttachList = new FarPoint.Win.Spread.FpSpread();
            this.spdFileAttachList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.txtLOTID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.cdvAttachType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlAttachTop = new System.Windows.Forms.Panel();
            this.txtDocType = new System.Windows.Forms.TextBox();
            this.lblDocType = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pnlAttachBottom.SuspendLayout();
            this.grpFileAttach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdFileAttachList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdFileAttachList_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttachType)).BeginInit();
            this.pnlAttachTop.SuspendLayout();
            this.SuspendLayout();
            columnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer1.Name = "columnHeaderRenderer1";
            columnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer1.TextRotationAngle = 0;
            columnHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer3.Name = "columnHeaderRenderer3";
            columnHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer3.TextRotationAngle = 0;
            rowHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer3.Name = "rowHeaderRenderer3";
            rowHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer3.TextRotationAngle = 0;
            columnHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer2.Name = "columnHeaderRenderer2";
            columnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer2.TextRotationAngle = 0;
            rowHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer2.Name = "rowHeaderRenderer2";
            rowHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer2.TextRotationAngle = 0;
            rowHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer1.Name = "rowHeaderRenderer1";
            rowHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer1.TextRotationAngle = 0;
            // 
            // pnlAttachBottom
            // 
            this.pnlAttachBottom.Controls.Add(this.grpFileAttach);
            this.pnlAttachBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttachBottom.Location = new System.Drawing.Point(0, 10);
            this.pnlAttachBottom.Name = "pnlAttachBottom";
            this.pnlAttachBottom.Padding = new System.Windows.Forms.Padding(3);
            this.pnlAttachBottom.Size = new System.Drawing.Size(688, 222);
            this.pnlAttachBottom.TabIndex = 13;
            // 
            // grpFileAttach
            // 
            this.grpFileAttach.Controls.Add(this.spdFileAttachList);
            this.grpFileAttach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFileAttach.Location = new System.Drawing.Point(3, 3);
            this.grpFileAttach.Name = "grpFileAttach";
            this.grpFileAttach.Size = new System.Drawing.Size(682, 216);
            this.grpFileAttach.TabIndex = 0;
            this.grpFileAttach.TabStop = false;
            this.grpFileAttach.Text = "File Attatch List";
            // 
            // spdFileAttachList
            // 
            this.spdFileAttachList.AccessibleDescription = "spdFileAttachList, Sheet1, Row 0, Column 0, ";
            this.spdFileAttachList.BackColor = System.Drawing.SystemColors.Control;
            this.spdFileAttachList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdFileAttachList.EditModeReplace = true;
            this.spdFileAttachList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdFileAttachList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdFileAttachList.HorizontalScrollBar.Name = "";
            this.spdFileAttachList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdFileAttachList.HorizontalScrollBar.TabIndex = 64;
            this.spdFileAttachList.Location = new System.Drawing.Point(3, 17);
            this.spdFileAttachList.Name = "spdFileAttachList";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            columnHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer4.Name = "";
            columnHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer4.TextRotationAngle = 0;
            namedStyle1.Renderer = columnHeaderRenderer4;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            rowHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer4.Name = "";
            rowHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer4.TextRotationAngle = 0;
            namedStyle2.Renderer = rowHeaderRenderer4;
            namedStyle2.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle3.BackColor = System.Drawing.SystemColors.Control;
            namedStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle3.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle3.Renderer = cornerRenderer1;
            namedStyle3.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle4.BackColor = System.Drawing.SystemColors.Window;
            namedStyle4.CellType = generalCellType1;
            namedStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle4.Renderer = generalCellType1;
            this.spdFileAttachList.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdFileAttachList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdFileAttachList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdFileAttachList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdFileAttachList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdFileAttachList_Sheet1});
            this.spdFileAttachList.Size = new System.Drawing.Size(676, 196);
            this.spdFileAttachList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdFileAttachList.TabIndex = 3;
            this.spdFileAttachList.TabStop = false;
            this.spdFileAttachList.TextTipDelay = 200;
            this.spdFileAttachList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdFileAttachList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdFileAttachList.VerticalScrollBar.Name = "";
            this.spdFileAttachList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdFileAttachList.VerticalScrollBar.TabIndex = 65;
            this.spdFileAttachList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdFileAttachList.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdFileAttachList_ButtonClicked);
            // 
            // spdFileAttachList_Sheet1
            // 
            this.spdFileAttachList_Sheet1.Reset();
            this.spdFileAttachList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdFileAttachList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spdFileAttachList_Sheet1.ColumnCount = 5;
            this.spdFileAttachList_Sheet1.RowCount = 1;
            this.spdFileAttachList_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdFileAttachList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Type";
            this.spdFileAttachList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "File Name";
            this.spdFileAttachList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "File Path";
            this.spdFileAttachList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "File Open";
            this.spdFileAttachList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "File Down";
            this.spdFileAttachList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdFileAttachList_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdFileAttachList_Sheet1.Columns.Get(0).Label = "Type";
            this.spdFileAttachList_Sheet1.Columns.Get(0).SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.Ascending;
            this.spdFileAttachList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFileAttachList_Sheet1.Columns.Get(0).Width = 144F;
            this.spdFileAttachList_Sheet1.Columns.Get(1).Label = "File Name";
            this.spdFileAttachList_Sheet1.Columns.Get(1).Locked = true;
            this.spdFileAttachList_Sheet1.Columns.Get(1).SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.Ascending;
            this.spdFileAttachList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFileAttachList_Sheet1.Columns.Get(1).Width = 350F;
            this.spdFileAttachList_Sheet1.Columns.Get(2).Label = "File Path";
            this.spdFileAttachList_Sheet1.Columns.Get(2).Locked = true;
            this.spdFileAttachList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFileAttachList_Sheet1.Columns.Get(2).Visible = false;
            this.spdFileAttachList_Sheet1.Columns.Get(2).Width = 350F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "View";
            this.spdFileAttachList_Sheet1.Columns.Get(3).CellType = buttonCellType1;
            this.spdFileAttachList_Sheet1.Columns.Get(3).Label = "File Open";
            this.spdFileAttachList_Sheet1.Columns.Get(3).Visible = false;
            this.spdFileAttachList_Sheet1.Columns.Get(3).Width = 100F;
            buttonCellType2.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType2.Text = "Download";
            this.spdFileAttachList_Sheet1.Columns.Get(4).CellType = buttonCellType2;
            this.spdFileAttachList_Sheet1.Columns.Get(4).Label = "File Down";
            this.spdFileAttachList_Sheet1.Columns.Get(4).Width = 120F;
            this.spdFileAttachList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdFileAttachList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdFileAttachList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdFileAttachList_Sheet1.Rows.Get(0).Height = 19F;
            this.spdFileAttachList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdFileAttachList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // txtLOTID
            // 
            this.txtLOTID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLOTID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLOTID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLOTID.Location = new System.Drawing.Point(347, 16);
            this.txtLOTID.MaxLength = 30;
            this.txtLOTID.Name = "txtLOTID";
            this.txtLOTID.ReadOnly = true;
            this.txtLOTID.Size = new System.Drawing.Size(111, 20);
            this.txtLOTID.TabIndex = 69;
            this.txtLOTID.Visible = false;
            // 
            // lblLotID
            // 
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(276, 17);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(80, 14);
            this.lblLotID.TabIndex = 68;
            this.lblLotID.Text = "LOT ID";
            this.lblLotID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLotID.Visible = false;
            // 
            // cdvAttachType
            // 
            this.cdvAttachType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttachType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttachType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttachType.BtnToolTipText = "";
            this.cdvAttachType.DescText = "";
            this.cdvAttachType.DisplaySubItemIndex = -1;
            this.cdvAttachType.DisplayText = "";
            this.cdvAttachType.Focusing = null;
            this.cdvAttachType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttachType.Index = 0;
            this.cdvAttachType.IsViewBtnImage = false;
            this.cdvAttachType.Location = new System.Drawing.Point(81, 11);
            this.cdvAttachType.MaxLength = 10;
            this.cdvAttachType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAttachType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAttachType.Name = "cdvAttachType";
            this.cdvAttachType.ReadOnly = false;
            this.cdvAttachType.SearchSubItemIndex = 0;
            this.cdvAttachType.SelectedDescIndex = -1;
            this.cdvAttachType.SelectedSubItemIndex = -1;
            this.cdvAttachType.SelectionStart = 0;
            this.cdvAttachType.Size = new System.Drawing.Size(170, 20);
            this.cdvAttachType.SmallImageList = null;
            this.cdvAttachType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttachType.TabIndex = 51;
            this.cdvAttachType.TextBoxToolTipText = "";
            this.cdvAttachType.TextBoxWidth = 170;
            this.cdvAttachType.Visible = false;
            this.cdvAttachType.VisibleButton = true;
            this.cdvAttachType.VisibleColumnHeader = false;
            this.cdvAttachType.VisibleDescription = false;
            this.cdvAttachType.ButtonPress += new System.EventHandler(this.cdvAttachType_ButtonPress);
            // 
            // pnlAttachTop
            // 
            this.pnlAttachTop.Controls.Add(this.txtDocType);
            this.pnlAttachTop.Controls.Add(this.lblDocType);
            this.pnlAttachTop.Controls.Add(this.txtLOTID);
            this.pnlAttachTop.Controls.Add(this.lblLotID);
            this.pnlAttachTop.Controls.Add(this.cdvAttachType);
            this.pnlAttachTop.Controls.Add(this.lblType);
            this.pnlAttachTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAttachTop.Location = new System.Drawing.Point(0, 0);
            this.pnlAttachTop.Name = "pnlAttachTop";
            this.pnlAttachTop.Padding = new System.Windows.Forms.Padding(3);
            this.pnlAttachTop.Size = new System.Drawing.Size(688, 10);
            this.pnlAttachTop.TabIndex = 12;
            // 
            // txtDocType
            // 
            this.txtDocType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDocType.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtDocType.Location = new System.Drawing.Point(548, 15);
            this.txtDocType.MaxLength = 30;
            this.txtDocType.Name = "txtDocType";
            this.txtDocType.ReadOnly = true;
            this.txtDocType.Size = new System.Drawing.Size(111, 20);
            this.txtDocType.TabIndex = 71;
            this.txtDocType.Visible = false;
            // 
            // lblDocType
            // 
            this.lblDocType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDocType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocType.Location = new System.Drawing.Point(477, 16);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(80, 14);
            this.lblDocType.TabIndex = 70;
            this.lblDocType.Text = "Doc Type";
            this.lblDocType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDocType.Visible = false;
            // 
            // lblType
            // 
            this.lblType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(15, 17);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(60, 14);
            this.lblType.TabIndex = 52;
            this.lblType.Text = "Type";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblType.Visible = false;
            // 
            // udcViewAttach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(columnHeaderRenderer1);
            this.Controls.Add(this.pnlAttachBottom);
            this.Controls.Add(columnHeaderRenderer2);
            this.Controls.Add(rowHeaderRenderer2);
            this.Controls.Add(rowHeaderRenderer1);
            this.Controls.Add(this.pnlAttachTop);
            this.Name = "udcViewAttach";
            this.Size = new System.Drawing.Size(688, 232);
            this.pnlAttachBottom.ResumeLayout(false);
            this.grpFileAttach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdFileAttachList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdFileAttachList_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttachType)).EndInit();
            this.pnlAttachTop.ResumeLayout(false);
            this.pnlAttachTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAttachBottom;
        private System.Windows.Forms.GroupBox grpFileAttach;
        public FarPoint.Win.Spread.FpSpread spdFileAttachList;
        private FarPoint.Win.Spread.SheetView spdFileAttachList_Sheet1;
        protected System.Windows.Forms.TextBox txtLOTID;
        protected System.Windows.Forms.Label lblLotID;
        public Miracom.UI.Controls.MCCodeView.MCCodeView cdvAttachType;
        private System.Windows.Forms.Panel pnlAttachTop;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        protected System.Windows.Forms.TextBox txtDocType;
        protected System.Windows.Forms.Label lblDocType;
    }
}
