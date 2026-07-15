namespace Miracom.MESCore.Controls
{
    partial class udcUploadAttach
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
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.pnlAttachTop = new System.Windows.Forms.Panel();
            this.txtOper = new System.Windows.Forms.TextBox();
            this.txtLOTID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cdvAttachType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblType = new System.Windows.Forms.Label();
            this.pnlAttachBottom = new System.Windows.Forms.Panel();
            this.grpFileAttach = new System.Windows.Forms.GroupBox();
            this.spdFileAttachList = new FarPoint.Win.Spread.FpSpread();
            this.spdFileAttachList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.rdoLotID = new System.Windows.Forms.RadioButton();
            this.rdoDocNo = new System.Windows.Forms.RadioButton();
            this.pnlAttachTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttachType)).BeginInit();
            this.pnlAttachBottom.SuspendLayout();
            this.grpFileAttach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdFileAttachList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdFileAttachList_Sheet1)).BeginInit();
            this.SuspendLayout();
            columnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer1.Name = "columnHeaderRenderer1";
            columnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer1.TextRotationAngle = 0;
            rowHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer1.Name = "rowHeaderRenderer1";
            rowHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer1.TextRotationAngle = 0;
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
            // 
            // pnlAttachTop
            // 
            this.pnlAttachTop.Controls.Add(this.rdoDocNo);
            this.pnlAttachTop.Controls.Add(this.rdoLotID);
            this.pnlAttachTop.Controls.Add(this.txtOper);
            this.pnlAttachTop.Controls.Add(this.txtLOTID);
            this.pnlAttachTop.Controls.Add(this.lblLotID);
            this.pnlAttachTop.Controls.Add(this.btnDel);
            this.pnlAttachTop.Controls.Add(this.btnAdd);
            this.pnlAttachTop.Controls.Add(this.cdvAttachType);
            this.pnlAttachTop.Controls.Add(this.lblType);
            this.pnlAttachTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAttachTop.Location = new System.Drawing.Point(0, 0);
            this.pnlAttachTop.Name = "pnlAttachTop";
            this.pnlAttachTop.Padding = new System.Windows.Forms.Padding(3);
            this.pnlAttachTop.Size = new System.Drawing.Size(685, 29);
            this.pnlAttachTop.TabIndex = 6;
            // 
            // txtOper
            // 
            this.txtOper.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOper.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtOper.Location = new System.Drawing.Point(474, 23);
            this.txtOper.MaxLength = 30;
            this.txtOper.Name = "txtOper";
            this.txtOper.ReadOnly = true;
            this.txtOper.Size = new System.Drawing.Size(66, 20);
            this.txtOper.TabIndex = 70;
            this.txtOper.Visible = false;
            // 
            // txtLOTID
            // 
            this.txtLOTID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLOTID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLOTID.Location = new System.Drawing.Point(357, 23);
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
            this.lblLotID.Location = new System.Drawing.Point(302, 24);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(80, 14);
            this.lblLotID.TabIndex = 68;
            this.lblLotID.Text = "LOT ID";
            this.lblLotID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLotID.Visible = false;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Location = new System.Drawing.Point(604, 5);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(45, 20);
            this.btnDel.TabIndex = 67;
            this.btnDel.Text = "DEL";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(555, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(45, 20);
            this.btnAdd.TabIndex = 66;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.cdvAttachType.Location = new System.Drawing.Point(81, 4);
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
            this.cdvAttachType.VisibleButton = true;
            this.cdvAttachType.VisibleColumnHeader = false;
            this.cdvAttachType.VisibleDescription = false;
            this.cdvAttachType.ButtonPress += new System.EventHandler(this.cdvAttachType_ButtonPress);
            // 
            // lblType
            // 
            this.lblType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(15, 7);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(60, 14);
            this.lblType.TabIndex = 52;
            this.lblType.Text = "Type";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAttachBottom
            // 
            this.pnlAttachBottom.Controls.Add(this.grpFileAttach);
            this.pnlAttachBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttachBottom.Location = new System.Drawing.Point(0, 29);
            this.pnlAttachBottom.Name = "pnlAttachBottom";
            this.pnlAttachBottom.Padding = new System.Windows.Forms.Padding(3);
            this.pnlAttachBottom.Size = new System.Drawing.Size(685, 190);
            this.pnlAttachBottom.TabIndex = 7;
            // 
            // grpFileAttach
            // 
            this.grpFileAttach.Controls.Add(this.spdFileAttachList);
            this.grpFileAttach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFileAttach.Location = new System.Drawing.Point(3, 3);
            this.grpFileAttach.Name = "grpFileAttach";
            this.grpFileAttach.Size = new System.Drawing.Size(679, 184);
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
            this.spdFileAttachList.HorizontalScrollBar.TabIndex = 52;
            this.spdFileAttachList.Location = new System.Drawing.Point(3, 17);
            this.spdFileAttachList.Name = "spdFileAttachList";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.Renderer = columnHeaderRenderer2;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.Renderer = rowHeaderRenderer2;
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
            this.spdFileAttachList.Size = new System.Drawing.Size(673, 164);
            this.spdFileAttachList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdFileAttachList.TabIndex = 3;
            this.spdFileAttachList.TabStop = false;
            this.spdFileAttachList.TextTipDelay = 200;
            this.spdFileAttachList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdFileAttachList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdFileAttachList.VerticalScrollBar.Name = "";
            this.spdFileAttachList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdFileAttachList.VerticalScrollBar.TabIndex = 53;
            this.spdFileAttachList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // spdFileAttachList_Sheet1
            // 
            this.spdFileAttachList_Sheet1.Reset();
            this.spdFileAttachList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdFileAttachList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spdFileAttachList_Sheet1.ColumnCount = 3;
            this.spdFileAttachList_Sheet1.RowCount = 0;
            this.spdFileAttachList_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdFileAttachList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Type";
            this.spdFileAttachList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "File Name";
            this.spdFileAttachList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "File Path";
            this.spdFileAttachList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdFileAttachList_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdFileAttachList_Sheet1.Columns.Get(0).Label = "Type";
            this.spdFileAttachList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFileAttachList_Sheet1.Columns.Get(0).Width = 100F;
            this.spdFileAttachList_Sheet1.Columns.Get(1).Label = "File Name";
            this.spdFileAttachList_Sheet1.Columns.Get(1).Locked = true;
            this.spdFileAttachList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFileAttachList_Sheet1.Columns.Get(1).Width = 160F;
            this.spdFileAttachList_Sheet1.Columns.Get(2).Label = "File Path";
            this.spdFileAttachList_Sheet1.Columns.Get(2).Locked = true;
            this.spdFileAttachList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdFileAttachList_Sheet1.Columns.Get(2).Width = 350F;
            this.spdFileAttachList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdFileAttachList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdFileAttachList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdFileAttachList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdFileAttachList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.spdFileAttachList.SetActiveViewport(0, 1, 0);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // rdoLotID
            // 
            this.rdoLotID.AutoSize = true;
            this.rdoLotID.Checked = true;
            this.rdoLotID.Location = new System.Drawing.Point(299, 7);
            this.rdoLotID.Name = "rdoLotID";
            this.rdoLotID.Size = new System.Drawing.Size(55, 16);
            this.rdoLotID.TabIndex = 71;
            this.rdoLotID.TabStop = true;
            this.rdoLotID.Text = "Lot ID";
            this.rdoLotID.UseVisualStyleBackColor = true;
            // 
            // rdoDocNo
            // 
            this.rdoDocNo.AutoSize = true;
            this.rdoDocNo.Location = new System.Drawing.Point(388, 7);
            this.rdoDocNo.Name = "rdoDocNo";
            this.rdoDocNo.Size = new System.Drawing.Size(100, 16);
            this.rdoDocNo.TabIndex = 72;
            this.rdoDocNo.Text = "Document No";
            this.rdoDocNo.UseVisualStyleBackColor = true;
            // 
            // udcUploadAttach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlAttachBottom);
            this.Controls.Add(this.pnlAttachTop);
            this.Name = "udcUploadAttach";
            this.Size = new System.Drawing.Size(685, 219);
            this.pnlAttachTop.ResumeLayout(false);
            this.pnlAttachTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttachType)).EndInit();
            this.pnlAttachBottom.ResumeLayout(false);
            this.grpFileAttach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdFileAttachList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdFileAttachList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAttachTop;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Panel pnlAttachBottom;
        private System.Windows.Forms.GroupBox grpFileAttach;
        private FarPoint.Win.Spread.SheetView spdFileAttachList_Sheet1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public FarPoint.Win.Spread.FpSpread spdFileAttachList;
        public System.Windows.Forms.Button btnDel;
        public System.Windows.Forms.Button btnAdd;
        public Miracom.UI.Controls.MCCodeView.MCCodeView cdvAttachType;
        protected System.Windows.Forms.TextBox txtLOTID;
        protected System.Windows.Forms.Label lblLotID;
        protected System.Windows.Forms.TextBox txtOper;
        private System.Windows.Forms.RadioButton rdoDocNo;
        private System.Windows.Forms.RadioButton rdoLotID;
    }
}
