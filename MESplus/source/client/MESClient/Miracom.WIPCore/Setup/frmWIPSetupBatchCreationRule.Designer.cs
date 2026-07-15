namespace Miracom.WIPCore
{
    partial class frmWIPSetupBatchCreationRule
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
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType3 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType4 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType5 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            this.lisRule = new Miracom.UI.Controls.MCListView.MCListView();
            this.columnHeader37 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader38 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpTop = new System.Windows.Forms.GroupBox();
            this.lblRuleDesc = new System.Windows.Forms.Label();
            this.lblRule = new System.Windows.Forms.Label();
            this.txtRuleDesc = new System.Windows.Forms.TextBox();
            this.txtRule = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCurrentOper = new System.Windows.Forms.CheckBox();
            this.chkUnder = new System.Windows.Forms.CheckBox();
            this.spdBatch = new FarPoint.Win.Spread.FpSpread();
            this.spdBatch_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.lblHour = new System.Windows.Forms.Label();
            this.chkOperMatch = new System.Windows.Forms.CheckBox();
            this.chkMatVerMatch = new System.Windows.Forms.CheckBox();
            this.chkMixflag = new System.Windows.Forms.CheckBox();
            this.chkOvrFlag = new System.Windows.Forms.CheckBox();
            this.chkFlowMatch = new System.Windows.Forms.CheckBox();
            this.chkMaterialMatch = new System.Windows.Forms.CheckBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtQtime = new System.Windows.Forms.TextBox();
            this.lblQTime = new System.Windows.Forms.Label();
            this.cdvBatchType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblBatchType = new System.Windows.Forms.Label();
            this.cdvGenRule = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblGenRule = new System.Windows.Forms.Label();
            this.grpDispatch = new System.Windows.Forms.GroupBox();
            this.rbnHigh = new System.Windows.Forms.RadioButton();
            this.rbnOnTime = new System.Windows.Forms.RadioButton();
            this.grpNPW = new System.Windows.Forms.GroupBox();
            this.grpNPWPosition = new System.Windows.Forms.GroupBox();
            this.chkMiddle = new System.Windows.Forms.CheckBox();
            this.chkAfter = new System.Windows.Forms.CheckBox();
            this.chkBefore = new System.Windows.Forms.CheckBox();
            this.chkBetween = new System.Windows.Forms.CheckBox();
            this.txtNPWCount = new System.Windows.Forms.TextBox();
            this.lbllNPWCount = new System.Windows.Forms.Label();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdBatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdBatch_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvBatchType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGenRule)).BeginInit();
            this.grpDispatch.SuspendLayout();
            this.grpNPW.SuspendLayout();
            this.grpNPWPosition.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.TabIndex = 1;
            // 
            // txtFind
            // 
            this.txtFind.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.groupBox1);
            this.pnlRight.Controls.Add(this.grpNPW);
            this.pnlRight.Controls.Add(this.grpTop);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisRule);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
            // 
            // lisRule
            // 
            this.lisRule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader37,
            this.columnHeader38});
            this.lisRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisRule.EnableSort = true;
            this.lisRule.EnableSortIcon = true;
            this.lisRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisRule.FullRowSelect = true;
            this.lisRule.Location = new System.Drawing.Point(3, 3);
            this.lisRule.MultiSelect = false;
            this.lisRule.Name = "lisRule";
            this.lisRule.Size = new System.Drawing.Size(226, 503);
            this.lisRule.TabIndex = 0;
            this.lisRule.UseCompatibleStateImageBehavior = false;
            this.lisRule.View = System.Windows.Forms.View.Details;
            this.lisRule.SelectedIndexChanged += new System.EventHandler(this.lisRule_SelectedIndexChanged);
            // 
            // columnHeader37
            // 
            this.columnHeader37.Text = "Creation Rule ID";
            this.columnHeader37.Width = 100;
            // 
            // columnHeader38
            // 
            this.columnHeader38.Text = "Description";
            this.columnHeader38.Width = 120;
            // 
            // grpTop
            // 
            this.grpTop.Controls.Add(this.lblRuleDesc);
            this.grpTop.Controls.Add(this.lblRule);
            this.grpTop.Controls.Add(this.txtRuleDesc);
            this.grpTop.Controls.Add(this.txtRule);
            this.grpTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTop.Location = new System.Drawing.Point(3, 0);
            this.grpTop.Name = "grpTop";
            this.grpTop.Size = new System.Drawing.Size(500, 64);
            this.grpTop.TabIndex = 0;
            this.grpTop.TabStop = false;
            // 
            // lblRuleDesc
            // 
            this.lblRuleDesc.AutoSize = true;
            this.lblRuleDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRuleDesc.Location = new System.Drawing.Point(12, 40);
            this.lblRuleDesc.Name = "lblRuleDesc";
            this.lblRuleDesc.Size = new System.Drawing.Size(60, 13);
            this.lblRuleDesc.TabIndex = 2;
            this.lblRuleDesc.Text = "Description";
            this.lblRuleDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRule
            // 
            this.lblRule.AutoSize = true;
            this.lblRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRule.Location = new System.Drawing.Point(12, 16);
            this.lblRule.Name = "lblRule";
            this.lblRule.Size = new System.Drawing.Size(101, 13);
            this.lblRule.TabIndex = 0;
            this.lblRule.Text = "Creation Rule ID";
            this.lblRule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRuleDesc
            // 
            this.txtRuleDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRuleDesc.Location = new System.Drawing.Point(137, 37);
            this.txtRuleDesc.MaxLength = 200;
            this.txtRuleDesc.Name = "txtRuleDesc";
            this.txtRuleDesc.Size = new System.Drawing.Size(361, 20);
            this.txtRuleDesc.TabIndex = 3;
            // 
            // txtRule
            // 
            this.txtRule.Location = new System.Drawing.Point(137, 13);
            this.txtRule.MaxLength = 30;
            this.txtRule.Name = "txtRule";
            this.txtRule.Size = new System.Drawing.Size(158, 20);
            this.txtRule.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkCurrentOper);
            this.groupBox1.Controls.Add(this.chkUnder);
            this.groupBox1.Controls.Add(this.spdBatch);
            this.groupBox1.Controls.Add(this.lblHour);
            this.groupBox1.Controls.Add(this.chkOperMatch);
            this.groupBox1.Controls.Add(this.chkMatVerMatch);
            this.groupBox1.Controls.Add(this.chkMixflag);
            this.groupBox1.Controls.Add(this.chkOvrFlag);
            this.groupBox1.Controls.Add(this.chkFlowMatch);
            this.groupBox1.Controls.Add(this.chkMaterialMatch);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Controls.Add(this.txtQtime);
            this.groupBox1.Controls.Add(this.lblQTime);
            this.groupBox1.Controls.Add(this.cdvBatchType);
            this.groupBox1.Controls.Add(this.lblBatchType);
            this.groupBox1.Controls.Add(this.cdvGenRule);
            this.groupBox1.Controls.Add(this.lblGenRule);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 270);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // chkCurrentOper
            // 
            this.chkCurrentOper.AutoSize = true;
            this.chkCurrentOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkCurrentOper.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCurrentOper.Location = new System.Drawing.Point(292, 227);
            this.chkCurrentOper.Name = "chkCurrentOper";
            this.chkCurrentOper.Size = new System.Drawing.Size(204, 17);
            this.chkCurrentOper.TabIndex = 14;
            this.chkCurrentOper.Text = "First Use Current Operation Lot";
            this.chkCurrentOper.Visible = false;
            // 
            // chkUnder
            // 
            this.chkUnder.AutoSize = true;
            this.chkUnder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkUnder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkUnder.Location = new System.Drawing.Point(324, 130);
            this.chkUnder.Name = "chkUnder";
            this.chkUnder.Size = new System.Drawing.Size(119, 17);
            this.chkUnder.TabIndex = 11;
            this.chkUnder.Text = "Under First Item";
            // 
            // spdBatch
            // 
            this.spdBatch.AccessibleDescription = "spdBatch, Sheet1, Row 0, Column 0, ";
            this.spdBatch.BackColor = System.Drawing.SystemColors.Control;
            this.spdBatch.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdBatch.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdBatch.HorizontalScrollBar.Name = "";
            this.spdBatch.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdBatch.HorizontalScrollBar.TabIndex = 2;
            this.spdBatch.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdBatch.Location = new System.Drawing.Point(12, 127);
            this.spdBatch.Name = "spdBatch";
            this.spdBatch.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdBatch_Sheet1});
            this.spdBatch.Size = new System.Drawing.Size(304, 83);
            this.spdBatch.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdBatch.TabIndex = 10;
            this.spdBatch.TabStop = false;
            this.spdBatch.TextTipDelay = 200;
            this.spdBatch.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdBatch.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdBatch.VerticalScrollBar.Name = "";
            this.spdBatch.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdBatch.VerticalScrollBar.TabIndex = 3;
            this.spdBatch.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdBatch.ComboCloseUp += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdBatch_ComboCloseUp);
            // 
            // spdBatch_Sheet1
            // 
            this.spdBatch_Sheet1.Reset();
            spdBatch_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdBatch_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdBatch_Sheet1.ColumnCount = 5;
            spdBatch_Sheet1.ColumnHeader.RowCount = 0;
            spdBatch_Sheet1.RowCount = 4;
            spdBatch_Sheet1.RowHeader.ColumnCount = 0;
            this.spdBatch_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdBatch_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdBatch_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdBatch_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdBatch_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdBatch_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdBatch_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            this.spdBatch_Sheet1.Columns.Get(0).CellType = comboBoxCellType1;
            this.spdBatch_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdBatch_Sheet1.Columns.Get(0).Locked = false;
            this.spdBatch_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            comboBoxCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            this.spdBatch_Sheet1.Columns.Get(1).CellType = comboBoxCellType2;
            this.spdBatch_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdBatch_Sheet1.Columns.Get(1).Locked = false;
            this.spdBatch_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            comboBoxCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            this.spdBatch_Sheet1.Columns.Get(2).CellType = comboBoxCellType3;
            comboBoxCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            this.spdBatch_Sheet1.Columns.Get(3).CellType = comboBoxCellType4;
            comboBoxCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            this.spdBatch_Sheet1.Columns.Get(4).CellType = comboBoxCellType5;
            this.spdBatch_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdBatch_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdBatch_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdBatch_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdBatch_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdBatch_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdBatch_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // lblHour
            // 
            this.lblHour.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHour.Location = new System.Drawing.Point(311, 72);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(82, 14);
            this.lblHour.TabIndex = 8;
            this.lblHour.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkOperMatch
            // 
            this.chkOperMatch.AutoSize = true;
            this.chkOperMatch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOperMatch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkOperMatch.Location = new System.Drawing.Point(156, 245);
            this.chkOperMatch.Name = "chkOperMatch";
            this.chkOperMatch.Size = new System.Drawing.Size(123, 17);
            this.chkOperMatch.TabIndex = 16;
            this.chkOperMatch.Text = "Operation Match";
            // 
            // chkMatVerMatch
            // 
            this.chkMatVerMatch.AutoSize = true;
            this.chkMatVerMatch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkMatVerMatch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMatVerMatch.Location = new System.Drawing.Point(14, 245);
            this.chkMatVerMatch.Name = "chkMatVerMatch";
            this.chkMatVerMatch.Size = new System.Drawing.Size(159, 17);
            this.chkMatVerMatch.TabIndex = 15;
            this.chkMatVerMatch.Text = "Material version Match";
            // 
            // chkMixflag
            // 
            this.chkMixflag.AutoSize = true;
            this.chkMixflag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkMixflag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMixflag.Location = new System.Drawing.Point(311, 47);
            this.chkMixflag.Name = "chkMixflag";
            this.chkMixflag.Size = new System.Drawing.Size(210, 17);
            this.chkMixflag.TabIndex = 5;
            this.chkMixflag.Text = "Allow mix sublot of different lots";
            // 
            // chkOvrFlag
            // 
            this.chkOvrFlag.AutoSize = true;
            this.chkOvrFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOvrFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkOvrFlag.Location = new System.Drawing.Point(311, 22);
            this.chkOvrFlag.Name = "chkOvrFlag";
            this.chkOvrFlag.Size = new System.Drawing.Size(161, 17);
            this.chkOvrFlag.TabIndex = 2;
            this.chkOvrFlag.Text = "Allow override Batch ID";
            // 
            // chkFlowMatch
            // 
            this.chkFlowMatch.AutoSize = true;
            this.chkFlowMatch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkFlowMatch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkFlowMatch.Location = new System.Drawing.Point(156, 227);
            this.chkFlowMatch.Name = "chkFlowMatch";
            this.chkFlowMatch.Size = new System.Drawing.Size(96, 17);
            this.chkFlowMatch.TabIndex = 13;
            this.chkFlowMatch.Text = "Flow Match";
            // 
            // chkMaterialMatch
            // 
            this.chkMaterialMatch.AutoSize = true;
            this.chkMaterialMatch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkMaterialMatch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMaterialMatch.Location = new System.Drawing.Point(14, 227);
            this.chkMaterialMatch.Name = "chkMaterialMatch";
            this.chkMaterialMatch.Size = new System.Drawing.Size(114, 17);
            this.chkMaterialMatch.TabIndex = 12;
            this.chkMaterialMatch.Text = "Material Match";
            // 
            // Label1
            // 
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(12, 105);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(119, 14);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "Batch Count";
            // 
            // txtQtime
            // 
            this.txtQtime.Location = new System.Drawing.Point(137, 69);
            this.txtQtime.MaxLength = 30;
            this.txtQtime.Name = "txtQtime";
            this.txtQtime.Size = new System.Drawing.Size(158, 20);
            this.txtQtime.TabIndex = 7;
            // 
            // lblQTime
            // 
            this.lblQTime.AutoSize = true;
            this.lblQTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQTime.Location = new System.Drawing.Point(12, 72);
            this.lblQTime.Name = "lblQTime";
            this.lblQTime.Size = new System.Drawing.Size(85, 13);
            this.lblQTime.TabIndex = 6;
            this.lblQTime.Text = "Minimum Q-Time";
            this.lblQTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvBatchType
            // 
            this.cdvBatchType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvBatchType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvBatchType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvBatchType.BtnToolTipText = "";
            this.cdvBatchType.DescText = "";
            this.cdvBatchType.DisplaySubItemIndex = -1;
            this.cdvBatchType.DisplayText = "";
            this.cdvBatchType.Focusing = null;
            this.cdvBatchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvBatchType.Index = 0;
            this.cdvBatchType.IsViewBtnImage = false;
            this.cdvBatchType.Location = new System.Drawing.Point(137, 44);
            this.cdvBatchType.MaxLength = 20;
            this.cdvBatchType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvBatchType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvBatchType.Name = "cdvBatchType";
            this.cdvBatchType.ReadOnly = false;
            this.cdvBatchType.SearchSubItemIndex = 0;
            this.cdvBatchType.SelectedDescIndex = -1;
            this.cdvBatchType.SelectedSubItemIndex = -1;
            this.cdvBatchType.SelectionStart = 0;
            this.cdvBatchType.Size = new System.Drawing.Size(158, 20);
            this.cdvBatchType.SmallImageList = null;
            this.cdvBatchType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvBatchType.TabIndex = 4;
            this.cdvBatchType.TextBoxToolTipText = "";
            this.cdvBatchType.TextBoxWidth = 158;
            this.cdvBatchType.VisibleButton = true;
            this.cdvBatchType.VisibleColumnHeader = false;
            this.cdvBatchType.VisibleDescription = false;
            this.cdvBatchType.ButtonPress += new System.EventHandler(this.cdvBatchType_ButtonPress);
            // 
            // lblBatchType
            // 
            this.lblBatchType.AutoSize = true;
            this.lblBatchType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBatchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatchType.Location = new System.Drawing.Point(12, 47);
            this.lblBatchType.Name = "lblBatchType";
            this.lblBatchType.Size = new System.Drawing.Size(72, 13);
            this.lblBatchType.TabIndex = 3;
            this.lblBatchType.Text = "Batch Type";
            this.lblBatchType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvGenRule
            // 
            this.cdvGenRule.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGenRule.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGenRule.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGenRule.BtnToolTipText = "";
            this.cdvGenRule.DescText = "";
            this.cdvGenRule.DisplaySubItemIndex = -1;
            this.cdvGenRule.DisplayText = "";
            this.cdvGenRule.Focusing = null;
            this.cdvGenRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGenRule.Index = 0;
            this.cdvGenRule.IsViewBtnImage = false;
            this.cdvGenRule.Location = new System.Drawing.Point(137, 19);
            this.cdvGenRule.MaxLength = 20;
            this.cdvGenRule.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGenRule.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGenRule.Name = "cdvGenRule";
            this.cdvGenRule.ReadOnly = false;
            this.cdvGenRule.SearchSubItemIndex = 0;
            this.cdvGenRule.SelectedDescIndex = -1;
            this.cdvGenRule.SelectedSubItemIndex = -1;
            this.cdvGenRule.SelectionStart = 0;
            this.cdvGenRule.Size = new System.Drawing.Size(158, 20);
            this.cdvGenRule.SmallImageList = null;
            this.cdvGenRule.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGenRule.TabIndex = 1;
            this.cdvGenRule.TextBoxToolTipText = "";
            this.cdvGenRule.TextBoxWidth = 158;
            this.cdvGenRule.VisibleButton = true;
            this.cdvGenRule.VisibleColumnHeader = false;
            this.cdvGenRule.VisibleDescription = false;
            this.cdvGenRule.ButtonPress += new System.EventHandler(this.cdvGenRule_ButtonPress);
            // 
            // lblGenRule
            // 
            this.lblGenRule.AutoSize = true;
            this.lblGenRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGenRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenRule.Location = new System.Drawing.Point(12, 22);
            this.lblGenRule.Name = "lblGenRule";
            this.lblGenRule.Size = new System.Drawing.Size(106, 13);
            this.lblGenRule.TabIndex = 0;
            this.lblGenRule.Text = "Generate Rule ID";
            this.lblGenRule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpDispatch
            // 
            this.grpDispatch.Controls.Add(this.rbnHigh);
            this.grpDispatch.Controls.Add(this.rbnOnTime);
            this.grpDispatch.Location = new System.Drawing.Point(273, 24);
            this.grpDispatch.Name = "grpDispatch";
            this.grpDispatch.Size = new System.Drawing.Size(168, 77);
            this.grpDispatch.TabIndex = 4;
            this.grpDispatch.TabStop = false;
            this.grpDispatch.Text = "Dispatch Priority";
            this.grpDispatch.Visible = false;
            // 
            // rbnHigh
            // 
            this.rbnHigh.AutoSize = true;
            this.rbnHigh.Location = new System.Drawing.Point(10, 52);
            this.rbnHigh.Name = "rbnHigh";
            this.rbnHigh.Size = new System.Drawing.Size(117, 16);
            this.rbnHigh.TabIndex = 1;
            this.rbnHigh.TabStop = true;
            this.rbnHigh.Text = "High Productivity";
            // 
            // rbnOnTime
            // 
            this.rbnOnTime.AutoSize = true;
            this.rbnOnTime.Location = new System.Drawing.Point(10, 25);
            this.rbnOnTime.Name = "rbnOnTime";
            this.rbnOnTime.Size = new System.Drawing.Size(123, 16);
            this.rbnOnTime.TabIndex = 0;
            this.rbnOnTime.TabStop = true;
            this.rbnOnTime.Text = "Due date On-time";
            // 
            // grpNPW
            // 
            this.grpNPW.Controls.Add(this.grpNPWPosition);
            this.grpNPW.Controls.Add(this.txtNPWCount);
            this.grpNPW.Controls.Add(this.lbllNPWCount);
            this.grpNPW.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpNPW.Location = new System.Drawing.Point(3, 334);
            this.grpNPW.Name = "grpNPW";
            this.grpNPW.Size = new System.Drawing.Size(500, 169);
            this.grpNPW.TabIndex = 2;
            this.grpNPW.TabStop = false;
            // 
            // grpNPWPosition
            // 
            this.grpNPWPosition.Controls.Add(this.grpDispatch);
            this.grpNPWPosition.Controls.Add(this.chkMiddle);
            this.grpNPWPosition.Controls.Add(this.chkAfter);
            this.grpNPWPosition.Controls.Add(this.chkBefore);
            this.grpNPWPosition.Controls.Add(this.chkBetween);
            this.grpNPWPosition.Location = new System.Drawing.Point(9, 54);
            this.grpNPWPosition.Name = "grpNPWPosition";
            this.grpNPWPosition.Size = new System.Drawing.Size(468, 109);
            this.grpNPWPosition.TabIndex = 2;
            this.grpNPWPosition.TabStop = false;
            this.grpNPWPosition.Text = "NPW Position";
            // 
            // chkMiddle
            // 
            this.chkMiddle.AutoSize = true;
            this.chkMiddle.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkMiddle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMiddle.Location = new System.Drawing.Point(23, 79);
            this.chkMiddle.Name = "chkMiddle";
            this.chkMiddle.Size = new System.Drawing.Size(110, 17);
            this.chkMiddle.TabIndex = 3;
            this.chkMiddle.Text = "Middle of a lot";
            // 
            // chkAfter
            // 
            this.chkAfter.AutoSize = true;
            this.chkAfter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkAfter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAfter.Location = new System.Drawing.Point(23, 61);
            this.chkAfter.Name = "chkAfter";
            this.chkAfter.Size = new System.Drawing.Size(96, 17);
            this.chkAfter.TabIndex = 2;
            this.chkAfter.Text = "After last lot";
            // 
            // chkBefore
            // 
            this.chkBefore.AutoSize = true;
            this.chkBefore.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkBefore.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkBefore.Location = new System.Drawing.Point(23, 43);
            this.chkBefore.Name = "chkBefore";
            this.chkBefore.Size = new System.Drawing.Size(107, 17);
            this.chkBefore.TabIndex = 1;
            this.chkBefore.Text = "Before first lot";
            // 
            // chkBetween
            // 
            this.chkBetween.AutoSize = true;
            this.chkBetween.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkBetween.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkBetween.Location = new System.Drawing.Point(23, 25);
            this.chkBetween.Name = "chkBetween";
            this.chkBetween.Size = new System.Drawing.Size(138, 17);
            this.chkBetween.TabIndex = 0;
            this.chkBetween.Text = "Between lot and lot";
            // 
            // txtNPWCount
            // 
            this.txtNPWCount.Location = new System.Drawing.Point(115, 25);
            this.txtNPWCount.MaxLength = 6;
            this.txtNPWCount.Name = "txtNPWCount";
            this.txtNPWCount.Size = new System.Drawing.Size(180, 20);
            this.txtNPWCount.TabIndex = 1;
            // 
            // lbllNPWCount
            // 
            this.lbllNPWCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbllNPWCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllNPWCount.Location = new System.Drawing.Point(12, 28);
            this.lbllNPWCount.Name = "lbllNPWCount";
            this.lbllNPWCount.Size = new System.Drawing.Size(82, 14);
            this.lbllNPWCount.TabIndex = 0;
            this.lbllNPWCount.Text = "NPW Count";
            this.lbllNPWCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmWIPSetupBatchCreationRule
            // 
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPSetupBatchCreationRule";
            this.Text = "Batch Creation Rule Setup";
            this.Load += new System.EventHandler(this.frmWIPSetupBatchCreationRule_Load);
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
            this.grpTop.ResumeLayout(false);
            this.grpTop.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdBatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdBatch_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvBatchType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGenRule)).EndInit();
            this.grpDispatch.ResumeLayout(false);
            this.grpDispatch.PerformLayout();
            this.grpNPW.ResumeLayout(false);
            this.grpNPW.PerformLayout();
            this.grpNPWPosition.ResumeLayout(false);
            this.grpNPWPosition.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Miracom.UI.Controls.MCListView.MCListView lisRule;
        private System.Windows.Forms.ColumnHeader columnHeader37;
        private System.Windows.Forms.ColumnHeader columnHeader38;
        private System.Windows.Forms.GroupBox grpTop;
        private System.Windows.Forms.Label lblRuleDesc;
        private System.Windows.Forms.Label lblRule;
        private System.Windows.Forms.TextBox txtRuleDesc;
        private System.Windows.Forms.TextBox txtRule;
        private System.Windows.Forms.GroupBox groupBox1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGenRule;
        private System.Windows.Forms.Label lblGenRule;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvBatchType;
        private System.Windows.Forms.Label lblBatchType;
        private System.Windows.Forms.TextBox txtQtime;
        private System.Windows.Forms.Label lblQTime;
        private System.Windows.Forms.CheckBox chkOperMatch;
        private System.Windows.Forms.CheckBox chkMatVerMatch;
        private System.Windows.Forms.CheckBox chkMixflag;
        private System.Windows.Forms.CheckBox chkOvrFlag;
        private System.Windows.Forms.CheckBox chkFlowMatch;
        private System.Windows.Forms.CheckBox chkMaterialMatch;
        private System.Windows.Forms.GroupBox grpNPW;
        private System.Windows.Forms.GroupBox grpNPWPosition;
        private System.Windows.Forms.CheckBox chkBefore;
        private System.Windows.Forms.CheckBox chkBetween;
        private System.Windows.Forms.TextBox txtNPWCount;
        private System.Windows.Forms.Label lbllNPWCount;
        private System.Windows.Forms.CheckBox chkMiddle;
        private System.Windows.Forms.CheckBox chkAfter;
        private System.Windows.Forms.Label lblHour;
        private FarPoint.Win.Spread.FpSpread spdBatch;
        private FarPoint.Win.Spread.SheetView spdBatch_Sheet1;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.CheckBox chkUnder;
        private System.Windows.Forms.GroupBox grpDispatch;
        private System.Windows.Forms.RadioButton rbnOnTime;
        private System.Windows.Forms.RadioButton rbnHigh;
        private System.Windows.Forms.CheckBox chkCurrentOper;
    }
}
