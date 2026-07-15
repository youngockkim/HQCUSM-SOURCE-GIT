namespace Miracom.RASCore
{
    partial class frmRASViewResourceByMFO
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
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label1 = new System.Windows.Forms.Label();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.lblType = new System.Windows.Forms.Label();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOperation = new System.Windows.Forms.Label();
            this.spdRes = new FarPoint.Win.Spread.FpSpread();
            this.spdRes_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.ctxCopyMenu = new System.Windows.Forms.ContextMenu();
            this.ctxCopy = new System.Windows.Forms.MenuItem();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdRes_Sheet1)).BeginInit();
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
            this.pnlViewTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlViewTop.Size = new System.Drawing.Size(742, 99);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvMaterial);
            this.grpOption.Controls.Add(this.lblOperation);
            this.grpOption.Controls.Add(this.cdvType);
            this.grpOption.Controls.Add(this.cdvOperation);
            this.grpOption.Controls.Add(this.cdvResGroup);
            this.grpOption.Controls.Add(this.cdvFlow);
            this.grpOption.Controls.Add(this.label1);
            this.grpOption.Controls.Add(this.lblType);
            this.grpOption.Location = new System.Drawing.Point(3, 0);
            this.grpOption.Size = new System.Drawing.Size(736, 99);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdRes);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 99);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 414);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Resource List by MFO";
            // 
            // cdvType
            // 
            this.cdvType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvType.BtnToolTipText = "";
            this.cdvType.DescText = "";
            this.cdvType.DisplaySubItemIndex = -1;
            this.cdvType.DisplayText = "";
            this.cdvType.Focusing = null;
            this.cdvType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvType.Index = 0;
            this.cdvType.IsViewBtnImage = false;
            this.cdvType.Location = new System.Drawing.Point(516, 42);
            this.cdvType.MaxLength = 20;
            this.cdvType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvType.Name = "cdvType";
            this.cdvType.ReadOnly = true;
            this.cdvType.SearchSubItemIndex = 0;
            this.cdvType.SelectedDescIndex = -1;
            this.cdvType.SelectedSubItemIndex = -1;
            this.cdvType.SelectionStart = 0;
            this.cdvType.Size = new System.Drawing.Size(200, 20);
            this.cdvType.SmallImageList = null;
            this.cdvType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvType.TabIndex = 10;
            this.cdvType.TextBoxToolTipText = "";
            this.cdvType.TextBoxWidth = 200;
            this.cdvType.VisibleButton = true;
            this.cdvType.VisibleColumnHeader = false;
            this.cdvType.VisibleDescription = false;
            this.cdvType.ButtonPress += new System.EventHandler(this.cdvType_ButtonPress);
            // 
            // cdvResGroup
            // 
            this.cdvResGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResGroup.BtnToolTipText = "";
            this.cdvResGroup.DescText = "";
            this.cdvResGroup.DisplaySubItemIndex = -1;
            this.cdvResGroup.DisplayText = "";
            this.cdvResGroup.Focusing = null;
            this.cdvResGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResGroup.Index = 0;
            this.cdvResGroup.IsViewBtnImage = false;
            this.cdvResGroup.Location = new System.Drawing.Point(516, 18);
            this.cdvResGroup.MaxLength = 20;
            this.cdvResGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResGroup.Name = "cdvResGroup";
            this.cdvResGroup.ReadOnly = false;
            this.cdvResGroup.SearchSubItemIndex = 0;
            this.cdvResGroup.SelectedDescIndex = -1;
            this.cdvResGroup.SelectedSubItemIndex = -1;
            this.cdvResGroup.SelectionStart = 0;
            this.cdvResGroup.Size = new System.Drawing.Size(200, 20);
            this.cdvResGroup.SmallImageList = null;
            this.cdvResGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResGroup.TabIndex = 5;
            this.cdvResGroup.TextBoxToolTipText = "";
            this.cdvResGroup.TextBoxWidth = 200;
            this.cdvResGroup.VisibleButton = true;
            this.cdvResGroup.VisibleColumnHeader = false;
            this.cdvResGroup.VisibleDescription = false;
            this.cdvResGroup.ButtonPress += new System.EventHandler(this.cdvResGroup_ButtonPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(389, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Resource Group";
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = true;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMaterial.DisplaySubItemIndex = 0;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(18, 18);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(320, 20);
            this.cdvMaterial.TabIndex = 0;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 120;
            this.cdvMaterial.WidthMaterialAndVersion = 200;
            this.cdvMaterial.WidthVersion = 50;
            this.cdvMaterial.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_SelectedItemChanged);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblType.Location = new System.Drawing.Point(389, 45);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(80, 13);
            this.lblType.TabIndex = 9;
            this.lblType.Text = "Resource Type";
            // 
            // cdvFlow
            // 
            this.cdvFlow.AddEmptyRowToLast = true;
            this.cdvFlow.AddEmptyRowToTop = false;
            this.cdvFlow.DisplaySubItemIndex = 0;
            this.cdvFlow.FlowReadOnly = false;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelText = "Flow";
            this.cdvFlow.LabelWidth = 120;
            this.cdvFlow.ListCond_ExtFactory = "";
            this.cdvFlow.ListCond_Step = '2';
            this.cdvFlow.Location = new System.Drawing.Point(18, 42);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = false;
            this.cdvFlow.Size = new System.Drawing.Size(320, 20);
            this.cdvFlow.TabIndex = 1;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.VisibleFlowButton = true;
            this.cdvFlow.VisibleSequenceButton = true;
            this.cdvFlow.WidthButton = 20;
            this.cdvFlow.WidthFlowAndSequence = 200;
            this.cdvFlow.WidthSequence = 50;
            this.cdvFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_FlowSelectedItemChanged);
            this.cdvFlow.FlowButtonPress += new System.EventHandler(this.cdvFlow_FlowButtonPress);
            // 
            // cdvOperation
            // 
            this.cdvOperation.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOperation.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOperation.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOperation.BtnToolTipText = "";
            this.cdvOperation.DescText = "";
            this.cdvOperation.DisplaySubItemIndex = -1;
            this.cdvOperation.DisplayText = "";
            this.cdvOperation.Focusing = null;
            this.cdvOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOperation.Index = 0;
            this.cdvOperation.IsViewBtnImage = false;
            this.cdvOperation.Location = new System.Drawing.Point(138, 66);
            this.cdvOperation.MaxLength = 10;
            this.cdvOperation.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.Name = "cdvOperation";
            this.cdvOperation.ReadOnly = false;
            this.cdvOperation.SearchSubItemIndex = 0;
            this.cdvOperation.SelectedDescIndex = -1;
            this.cdvOperation.SelectedSubItemIndex = -1;
            this.cdvOperation.SelectionStart = 0;
            this.cdvOperation.Size = new System.Drawing.Size(200, 20);
            this.cdvOperation.SmallImageList = null;
            this.cdvOperation.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOperation.TabIndex = 3;
            this.cdvOperation.TextBoxToolTipText = "";
            this.cdvOperation.TextBoxWidth = 200;
            this.cdvOperation.VisibleButton = true;
            this.cdvOperation.VisibleColumnHeader = false;
            this.cdvOperation.VisibleDescription = false;
            this.cdvOperation.ButtonPress += new System.EventHandler(this.cdvOperation_ButtonPress);
            // 
            // lblOperation
            // 
            this.lblOperation.AutoSize = true;
            this.lblOperation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperation.Location = new System.Drawing.Point(18, 69);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(53, 13);
            this.lblOperation.TabIndex = 2;
            this.lblOperation.Text = "Operation";
            this.lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spdRes
            // 
            this.spdRes.AccessibleDescription = "";
            this.spdRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdRes.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdRes.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdRes.HorizontalScrollBar.Name = "";
            this.spdRes.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdRes.HorizontalScrollBar.TabIndex = 2;
            this.spdRes.Location = new System.Drawing.Point(3, 5);
            this.spdRes.Name = "spdRes";
            this.spdRes.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdRes.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdRes.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdRes_Sheet1});
            this.spdRes.Size = new System.Drawing.Size(736, 406);
            this.spdRes.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdRes.TabIndex = 1;
            this.spdRes.TabStop = false;
            this.spdRes.TextTipDelay = 200;
            this.spdRes.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdRes.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdRes.VerticalScrollBar.Name = "";
            this.spdRes.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdRes.VerticalScrollBar.TabIndex = 3;
            this.spdRes.SetActiveViewport(0, -1, -1);
            // 
            // spdRes_Sheet1
            // 
            this.spdRes_Sheet1.Reset();
            spdRes_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdRes_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdRes_Sheet1.ColumnCount = 27;
            spdRes_Sheet1.RowCount = 0;
            this.spdRes_Sheet1.ActiveColumnIndex = -1;
            this.spdRes_Sheet1.ActiveRowIndex = -1;
            this.spdRes_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdRes_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdRes_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdRes_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Res ID";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Res Desc";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Res Type";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Use Fac";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Area ID";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Sub Area ID";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Res Location";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Proc Rule";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Max Proc";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "PM Sch Enable";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Unit Base";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Sec Chk";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Create UserID";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Create Time";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Update UserID";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Update Time";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Up Down";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Primary Status";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Proc Mode";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Ctrl Mode";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Proc Count";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Last Start Time";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Last End Time";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Last Event";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Last Event Time";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Last Act Hist Seq";
            this.spdRes_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Last Hist Seq";
            this.spdRes_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdRes_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdRes_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdRes_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(0).Label = "Res ID";
            this.spdRes_Sheet1.Columns.Get(0).Locked = true;
            this.spdRes_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(0).Width = 100F;
            this.spdRes_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(1).Label = "Res Desc";
            this.spdRes_Sheet1.Columns.Get(1).Locked = true;
            this.spdRes_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(1).Width = 130F;
            this.spdRes_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(2).Label = "Res Type";
            this.spdRes_Sheet1.Columns.Get(2).Locked = true;
            this.spdRes_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(2).Width = 80F;
            this.spdRes_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(3).Label = "Use Fac";
            this.spdRes_Sheet1.Columns.Get(3).Locked = true;
            this.spdRes_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(3).Width = 59F;
            this.spdRes_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(4).Label = "Area ID";
            this.spdRes_Sheet1.Columns.Get(4).Locked = true;
            this.spdRes_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(4).Width = 80F;
            this.spdRes_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(5).Label = "Sub Area ID";
            this.spdRes_Sheet1.Columns.Get(5).Locked = true;
            this.spdRes_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(5).Width = 80F;
            this.spdRes_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(6).Label = "Res Location";
            this.spdRes_Sheet1.Columns.Get(6).Locked = true;
            this.spdRes_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(6).Width = 90F;
            this.spdRes_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(7).Label = "Proc Rule";
            this.spdRes_Sheet1.Columns.Get(7).Locked = true;
            this.spdRes_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdRes_Sheet1.Columns.Get(8).Label = "Max Proc";
            this.spdRes_Sheet1.Columns.Get(8).Locked = true;
            this.spdRes_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(8).Width = 55F;
            this.spdRes_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(9).Label = "PM Sch Enable";
            this.spdRes_Sheet1.Columns.Get(9).Locked = true;
            this.spdRes_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(9).Width = 92F;
            this.spdRes_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(10).Label = "Unit Base";
            this.spdRes_Sheet1.Columns.Get(10).Locked = true;
            this.spdRes_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(10).Width = 55F;
            this.spdRes_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(11).Label = "Sec Chk";
            this.spdRes_Sheet1.Columns.Get(11).Locked = true;
            this.spdRes_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(11).Width = 50F;
            this.spdRes_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(12).Label = "Create UserID";
            this.spdRes_Sheet1.Columns.Get(12).Locked = true;
            this.spdRes_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(12).Width = 80F;
            this.spdRes_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(13).Label = "Create Time";
            this.spdRes_Sheet1.Columns.Get(13).Locked = true;
            this.spdRes_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(13).Width = 120F;
            this.spdRes_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(14).Label = "Update UserID";
            this.spdRes_Sheet1.Columns.Get(14).Locked = true;
            this.spdRes_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(14).Width = 104F;
            this.spdRes_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(15).Label = "Update Time";
            this.spdRes_Sheet1.Columns.Get(15).Locked = true;
            this.spdRes_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(15).Width = 120F;
            this.spdRes_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(16).Label = "Up Down";
            this.spdRes_Sheet1.Columns.Get(16).Locked = true;
            this.spdRes_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(17).Label = "Primary Status";
            this.spdRes_Sheet1.Columns.Get(17).Locked = true;
            this.spdRes_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(17).Width = 83F;
            this.spdRes_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(18).Label = "Proc Mode";
            this.spdRes_Sheet1.Columns.Get(18).Locked = true;
            this.spdRes_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(18).Width = 74F;
            this.spdRes_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdRes_Sheet1.Columns.Get(20).Label = "Proc Count";
            this.spdRes_Sheet1.Columns.Get(20).Locked = true;
            this.spdRes_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(20).Width = 76F;
            this.spdRes_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(21).Label = "Last Start Time";
            this.spdRes_Sheet1.Columns.Get(21).Locked = true;
            this.spdRes_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(21).Width = 120F;
            this.spdRes_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(22).Label = "Last End Time";
            this.spdRes_Sheet1.Columns.Get(22).Locked = true;
            this.spdRes_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(22).Width = 120F;
            this.spdRes_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(23).Label = "Last Event";
            this.spdRes_Sheet1.Columns.Get(23).Locked = true;
            this.spdRes_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(23).Width = 100F;
            this.spdRes_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdRes_Sheet1.Columns.Get(24).Label = "Last Event Time";
            this.spdRes_Sheet1.Columns.Get(24).Locked = true;
            this.spdRes_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(24).Width = 120F;
            this.spdRes_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdRes_Sheet1.Columns.Get(25).Label = "Last Act Hist Seq";
            this.spdRes_Sheet1.Columns.Get(25).Locked = true;
            this.spdRes_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(25).Width = 94F;
            this.spdRes_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdRes_Sheet1.Columns.Get(26).Label = "Last Hist Seq";
            this.spdRes_Sheet1.Columns.Get(26).Locked = true;
            this.spdRes_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdRes_Sheet1.Columns.Get(26).Width = 80F;
            this.spdRes_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdRes_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdRes_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdRes_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdRes_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdRes_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdRes_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // ctxCopyMenu
            // 
            this.ctxCopyMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ctxCopy});
            // 
            // ctxCopy
            // 
            this.ctxCopy.Index = 0;
            this.ctxCopy.Text = "Copy";
            // 
            // frmRASViewResourceByMFO
            // 
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRASViewResourceByMFO";
            this.Text = "View Resource By MFO";
            this.Activated += new System.EventHandler(this.frmRASViewResourceByMFO_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdRes_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResGroup;
        private System.Windows.Forms.Label label1;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private System.Windows.Forms.Label lblType;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvFlow;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOperation;
        private System.Windows.Forms.Label lblOperation;
        private FarPoint.Win.Spread.FpSpread spdRes;
        private FarPoint.Win.Spread.SheetView spdRes_Sheet1;
        private System.Windows.Forms.ContextMenu ctxCopyMenu;
        private System.Windows.Forms.MenuItem ctxCopy;
    }
}
