namespace Miracom.BASCore.Controls
{
    partial class udcChecklistKeyPrompt
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
            FarPoint.Win.ComplexBorder complexBorder1 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.ComplexBorder complexBorder2 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.ComplexBorder complexBorder3 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            this.spdKeyPrompt = new FarPoint.Win.Spread.FpSpread();
            this.spdKeyPrompt_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.cdvTableList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            ((System.ComponentModel.ISupportInitialize)(this.spdKeyPrompt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdKeyPrompt_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).BeginInit();
            this.SuspendLayout();
            // 
            // spdKeyPrompt
            // 
            this.spdKeyPrompt.AccessibleDescription = "spdKeyPrompt, Sheet1, Row 0, Column 0, ";
            this.spdKeyPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdKeyPrompt.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdKeyPrompt.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdKeyPrompt.HorizontalScrollBar.Name = "";
            this.spdKeyPrompt.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdKeyPrompt.HorizontalScrollBar.TabIndex = 22;
            this.spdKeyPrompt.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdKeyPrompt.Location = new System.Drawing.Point(0, 0);
            this.spdKeyPrompt.Name = "spdKeyPrompt";
            this.spdKeyPrompt.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdKeyPrompt.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdKeyPrompt.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdKeyPrompt_Sheet1});
            this.spdKeyPrompt.Size = new System.Drawing.Size(400, 200);
            this.spdKeyPrompt.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdKeyPrompt.TabIndex = 2;
            this.spdKeyPrompt.TabStop = false;
            this.spdKeyPrompt.TextTipDelay = 200;
            this.spdKeyPrompt.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdKeyPrompt.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdKeyPrompt.VerticalScrollBar.Name = "";
            this.spdKeyPrompt.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdKeyPrompt.VerticalScrollBar.TabIndex = 23;
            this.spdKeyPrompt.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdKeyPrompt.EditModeOff += new System.EventHandler(this.spdKeyPrompt_EditModeOff);
            this.spdKeyPrompt.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdKeyPrompt_ButtonClicked);
            // 
            // spdKeyPrompt_Sheet1
            // 
            this.spdKeyPrompt_Sheet1.Reset();
            spdKeyPrompt_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdKeyPrompt_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdKeyPrompt_Sheet1.ColumnCount = 6;
            spdKeyPrompt_Sheet1.RowCount = 10;
            this.spdKeyPrompt_Sheet1.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(0, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(0, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(0, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(1, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(1, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(1, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(1, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(1, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(1, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(1, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(1, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(1, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(1, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(2, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(2, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(2, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(2, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(2, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(2, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(2, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(2, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(2, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(2, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(2, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(3, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(3, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(3, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(3, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(3, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(3, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(3, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(3, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(3, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(3, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(3, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(4, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(4, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(4, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(4, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(4, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(4, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(4, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(4, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(4, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(4, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(4, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(5, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(5, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(5, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(5, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(5, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(5, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(5, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(5, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(5, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(6, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(6, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(6, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(6, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(6, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(6, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(6, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(6, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(6, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(7, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(7, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(7, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(7, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(7, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(7, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(7, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(7, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(7, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(8, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(8, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(8, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(8, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(8, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(8, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(8, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(8, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(8, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(9, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(9, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(9, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(9, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(9, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(9, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(9, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(9, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(9, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdKeyPrompt_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdKeyPrompt_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdKeyPrompt_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdKeyPrompt_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Key Prompt";
            this.spdKeyPrompt_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Require";
            this.spdKeyPrompt_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Format";
            this.spdKeyPrompt_Sheet1.ColumnHeader.Cells.Get(0, 3).ColumnSpan = 3;
            this.spdKeyPrompt_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Table or Item";
            this.spdKeyPrompt_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Table or Item";
            this.spdKeyPrompt_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdKeyPrompt_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdKeyPrompt_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdKeyPrompt_Sheet1.Columns.Get(0).Border = complexBorder1;
            this.spdKeyPrompt_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.spdKeyPrompt_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdKeyPrompt_Sheet1.Columns.Get(0).Label = "Key Prompt";
            this.spdKeyPrompt_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Columns.Get(0).Width = 140F;
            this.spdKeyPrompt_Sheet1.Columns.Get(1).Border = complexBorder2;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType1.Items = new string[] {
        " ",
        "Y",
        "N"};
            this.spdKeyPrompt_Sheet1.Columns.Get(1).CellType = comboBoxCellType1;
            this.spdKeyPrompt_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Columns.Get(1).Label = "Require";
            this.spdKeyPrompt_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Columns.Get(1).Width = 52F;
            this.spdKeyPrompt_Sheet1.Columns.Get(2).Border = complexBorder3;
            comboBoxCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType2.Items = new string[] {
        "Ascii",
        "Number",
        "Float"};
            this.spdKeyPrompt_Sheet1.Columns.Get(2).CellType = comboBoxCellType2;
            this.spdKeyPrompt_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdKeyPrompt_Sheet1.Columns.Get(2).Label = "Format";
            this.spdKeyPrompt_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Columns.Get(2).Width = 80F;
            this.spdKeyPrompt_Sheet1.Columns.Get(3).CellType = textCellType2;
            this.spdKeyPrompt_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdKeyPrompt_Sheet1.Columns.Get(3).Label = "Table or Item";
            this.spdKeyPrompt_Sheet1.Columns.Get(3).Locked = true;
            this.spdKeyPrompt_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Columns.Get(3).Width = 80F;
            this.spdKeyPrompt_Sheet1.Columns.Get(4).CellType = textCellType3;
            this.spdKeyPrompt_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdKeyPrompt_Sheet1.Columns.Get(4).Label = "Table or Item";
            this.spdKeyPrompt_Sheet1.Columns.Get(4).Locked = true;
            this.spdKeyPrompt_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Columns.Get(4).Width = 120F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdKeyPrompt_Sheet1.Columns.Get(5).CellType = buttonCellType1;
            this.spdKeyPrompt_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Columns.Get(5).Width = 21F;
            this.spdKeyPrompt_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdKeyPrompt_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdKeyPrompt_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdKeyPrompt_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdKeyPrompt_Sheet1.Rows.Get(0).Height = 18F;
            this.spdKeyPrompt_Sheet1.Rows.Get(1).Height = 18F;
            this.spdKeyPrompt_Sheet1.Rows.Get(2).Height = 18F;
            this.spdKeyPrompt_Sheet1.Rows.Get(3).Height = 18F;
            this.spdKeyPrompt_Sheet1.Rows.Get(4).Height = 18F;
            this.spdKeyPrompt_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdKeyPrompt_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdKeyPrompt_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
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
            // udcChecklistKeyPrompt
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.spdKeyPrompt);
            this.Name = "udcChecklistKeyPrompt";
            this.Size = new System.Drawing.Size(400, 200);
            ((System.ComponentModel.ISupportInitialize)(this.spdKeyPrompt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdKeyPrompt_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread spdKeyPrompt;
        private FarPoint.Win.Spread.SheetView spdKeyPrompt_Sheet1;
        private UI.Controls.MCCodeView.MCSPCodeView cdvTableList;
    }
}
