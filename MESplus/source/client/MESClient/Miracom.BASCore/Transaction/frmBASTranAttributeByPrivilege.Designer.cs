namespace Miracom.BASCore
{
    partial class frmBASTranAttributeByPrivilege
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
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.grpAttribute = new System.Windows.Forms.GroupBox();
            this.chkOnlyPrvAttribute = new System.Windows.Forms.CheckBox();
            this.nudToAttrSeq = new System.Windows.Forms.NumericUpDown();
            this.nudFromAttrSeq = new System.Windows.Forms.NumericUpDown();
            this.cdvAttrKey = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAttrKey = new System.Windows.Forms.Label();
            this.cdvAttrType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAttrSeq = new System.Windows.Forms.Label();
            this.lblAttrType = new System.Windows.Forms.Label();
            this.pnlAttrInfo = new System.Windows.Forms.Panel();
            this.grpAttrInfo = new System.Windows.Forms.GroupBox();
            this.spdAttrValue = new FarPoint.Win.Spread.FpSpread();
            this.spdAttrValue_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnView = new System.Windows.Forms.Button();
            this.cdvTableData = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.btnDelRow = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpAttribute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudToAttrSeq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFromAttrSeq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrType)).BeginInit();
            this.pnlAttrInfo.SuspendLayout();
            this.grpAttrInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdAttrValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAttrValue_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnDelRow);
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelRow, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlAttrInfo);
            this.pnlCenter.Controls.Add(this.grpAttribute);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm01";
            // 
            // grpAttribute
            // 
            this.grpAttribute.Controls.Add(this.chkOnlyPrvAttribute);
            this.grpAttribute.Controls.Add(this.nudToAttrSeq);
            this.grpAttribute.Controls.Add(this.nudFromAttrSeq);
            this.grpAttribute.Controls.Add(this.cdvAttrKey);
            this.grpAttribute.Controls.Add(this.lblAttrKey);
            this.grpAttribute.Controls.Add(this.cdvAttrType);
            this.grpAttribute.Controls.Add(this.label3);
            this.grpAttribute.Controls.Add(this.lblAttrSeq);
            this.grpAttribute.Controls.Add(this.lblAttrType);
            this.grpAttribute.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAttribute.Location = new System.Drawing.Point(0, 0);
            this.grpAttribute.Name = "grpAttribute";
            this.grpAttribute.Size = new System.Drawing.Size(742, 70);
            this.grpAttribute.TabIndex = 0;
            this.grpAttribute.TabStop = false;
            // 
            // chkOnlyPrvAttribute
            // 
            this.chkOnlyPrvAttribute.AutoSize = true;
            this.chkOnlyPrvAttribute.Checked = true;
            this.chkOnlyPrvAttribute.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyPrvAttribute.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOnlyPrvAttribute.Location = new System.Drawing.Point(348, 17);
            this.chkOnlyPrvAttribute.Name = "chkOnlyPrvAttribute";
            this.chkOnlyPrvAttribute.Size = new System.Drawing.Size(182, 17);
            this.chkOnlyPrvAttribute.TabIndex = 4;
            this.chkOnlyPrvAttribute.Text = "Only for Privileged Attribute";
            this.chkOnlyPrvAttribute.UseVisualStyleBackColor = true;
            // 
            // nudToAttrSeq
            // 
            this.nudToAttrSeq.Location = new System.Drawing.Point(528, 40);
            this.nudToAttrSeq.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudToAttrSeq.Name = "nudToAttrSeq";
            this.nudToAttrSeq.Size = new System.Drawing.Size(80, 20);
            this.nudToAttrSeq.TabIndex = 8;
            this.nudToAttrSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudToAttrSeq.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // nudFromAttrSeq
            // 
            this.nudFromAttrSeq.Location = new System.Drawing.Point(408, 40);
            this.nudFromAttrSeq.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudFromAttrSeq.Name = "nudFromAttrSeq";
            this.nudFromAttrSeq.Size = new System.Drawing.Size(80, 20);
            this.nudFromAttrSeq.TabIndex = 6;
            this.nudFromAttrSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cdvAttrKey
            // 
            this.cdvAttrKey.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttrKey.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttrKey.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttrKey.BtnToolTipText = "";
            this.cdvAttrKey.DescText = "";
            this.cdvAttrKey.DisplaySubItemIndex = 0;
            this.cdvAttrKey.DisplayText = "";
            this.cdvAttrKey.Focusing = null;
            this.cdvAttrKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttrKey.Index = 0;
            this.cdvAttrKey.IsViewBtnImage = false;
            this.cdvAttrKey.Location = new System.Drawing.Point(79, 40);
            this.cdvAttrKey.MaxLength = 100;
            this.cdvAttrKey.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAttrKey.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAttrKey.Name = "cdvAttrKey";
            this.cdvAttrKey.ReadOnly = false;
            this.cdvAttrKey.SearchSubItemIndex = 0;
            this.cdvAttrKey.SelectedDescIndex = -1;
            this.cdvAttrKey.SelectedSubItemIndex = 0;
            this.cdvAttrKey.SelectionStart = 0;
            this.cdvAttrKey.Size = new System.Drawing.Size(200, 20);
            this.cdvAttrKey.SmallImageList = null;
            this.cdvAttrKey.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttrKey.TabIndex = 3;
            this.cdvAttrKey.TextBoxToolTipText = "";
            this.cdvAttrKey.TextBoxWidth = 200;
            this.cdvAttrKey.VisibleButton = true;
            this.cdvAttrKey.VisibleColumnHeader = false;
            this.cdvAttrKey.VisibleDescription = false;
            this.cdvAttrKey.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvAttrKey_SelectedItemChanged);
            this.cdvAttrKey.ButtonPress += new System.EventHandler(this.cdvAttrKey_ButtonPress);
            this.cdvAttrKey.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvAttrKey_TextBoxKeyPress);
            // 
            // lblAttrKey
            // 
            this.lblAttrKey.AutoSize = true;
            this.lblAttrKey.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrKey.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrKey.Location = new System.Drawing.Point(16, 44);
            this.lblAttrKey.Name = "lblAttrKey";
            this.lblAttrKey.Size = new System.Drawing.Size(28, 13);
            this.lblAttrKey.TabIndex = 2;
            this.lblAttrKey.Text = "Key";
            // 
            // cdvAttrType
            // 
            this.cdvAttrType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttrType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttrType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttrType.BtnToolTipText = "";
            this.cdvAttrType.DescText = "";
            this.cdvAttrType.DisplaySubItemIndex = 0;
            this.cdvAttrType.DisplayText = "";
            this.cdvAttrType.Focusing = null;
            this.cdvAttrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttrType.Index = 0;
            this.cdvAttrType.IsViewBtnImage = false;
            this.cdvAttrType.Location = new System.Drawing.Point(79, 15);
            this.cdvAttrType.MaxLength = 20;
            this.cdvAttrType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAttrType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAttrType.Name = "cdvAttrType";
            this.cdvAttrType.ReadOnly = false;
            this.cdvAttrType.SearchSubItemIndex = 0;
            this.cdvAttrType.SelectedDescIndex = -1;
            this.cdvAttrType.SelectedSubItemIndex = 0;
            this.cdvAttrType.SelectionStart = 0;
            this.cdvAttrType.Size = new System.Drawing.Size(200, 20);
            this.cdvAttrType.SmallImageList = null;
            this.cdvAttrType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttrType.TabIndex = 1;
            this.cdvAttrType.TextBoxToolTipText = "";
            this.cdvAttrType.TextBoxWidth = 200;
            this.cdvAttrType.VisibleButton = true;
            this.cdvAttrType.VisibleColumnHeader = false;
            this.cdvAttrType.VisibleDescription = false;
            this.cdvAttrType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvAttrType_SelectedItemChanged);
            this.cdvAttrType.ButtonPress += new System.EventHandler(this.cdvAttrType_ButtonPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(501, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "~";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAttrSeq
            // 
            this.lblAttrSeq.AutoSize = true;
            this.lblAttrSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrSeq.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrSeq.Location = new System.Drawing.Point(348, 44);
            this.lblAttrSeq.Name = "lblAttrSeq";
            this.lblAttrSeq.Size = new System.Drawing.Size(56, 13);
            this.lblAttrSeq.TabIndex = 5;
            this.lblAttrSeq.Text = "Sequence";
            // 
            // lblAttrType
            // 
            this.lblAttrType.AutoSize = true;
            this.lblAttrType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrType.Location = new System.Drawing.Point(16, 18);
            this.lblAttrType.Name = "lblAttrType";
            this.lblAttrType.Size = new System.Drawing.Size(35, 13);
            this.lblAttrType.TabIndex = 0;
            this.lblAttrType.Text = "Type";
            // 
            // pnlAttrInfo
            // 
            this.pnlAttrInfo.Controls.Add(this.grpAttrInfo);
            this.pnlAttrInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttrInfo.Location = new System.Drawing.Point(0, 70);
            this.pnlAttrInfo.Name = "pnlAttrInfo";
            this.pnlAttrInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlAttrInfo.Size = new System.Drawing.Size(742, 443);
            this.pnlAttrInfo.TabIndex = 1;
            // 
            // grpAttrInfo
            // 
            this.grpAttrInfo.Controls.Add(this.spdAttrValue);
            this.grpAttrInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAttrInfo.Location = new System.Drawing.Point(0, 5);
            this.grpAttrInfo.Name = "grpAttrInfo";
            this.grpAttrInfo.Size = new System.Drawing.Size(742, 438);
            this.grpAttrInfo.TabIndex = 0;
            this.grpAttrInfo.TabStop = false;
            this.grpAttrInfo.Text = "Attribute Information";
            // 
            // spdAttrValue
            // 
            this.spdAttrValue.AccessibleDescription = "spdAttrValue, Sheet1, Row 0, Column 0, ";
            this.spdAttrValue.BackColor = System.Drawing.SystemColors.Control;
            this.spdAttrValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdAttrValue.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdAttrValue.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdAttrValue.HorizontalScrollBar.Name = "";
            this.spdAttrValue.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdAttrValue.HorizontalScrollBar.TabIndex = 8;
            this.spdAttrValue.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdAttrValue.Location = new System.Drawing.Point(3, 16);
            this.spdAttrValue.Name = "spdAttrValue";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle3.BackColor = System.Drawing.SystemColors.Control;
            namedStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle3.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle3.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle3.Renderer = cornerRenderer1;
            namedStyle3.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle4.BackColor = System.Drawing.SystemColors.Window;
            namedStyle4.CellType = generalCellType1;
            namedStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle4.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle4.Renderer = generalCellType1;
            this.spdAttrValue.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdAttrValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdAttrValue.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdAttrValue.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdAttrValue.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdAttrValue_Sheet1});
            this.spdAttrValue.Size = new System.Drawing.Size(736, 419);
            this.spdAttrValue.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdAttrValue.TabIndex = 0;
            this.spdAttrValue.TextTipDelay = 200;
            this.spdAttrValue.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdAttrValue.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdAttrValue.VerticalScrollBar.Name = "";
            this.spdAttrValue.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdAttrValue.VerticalScrollBar.TabIndex = 9;
            this.spdAttrValue.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdAttrValue.EnterCell += new FarPoint.Win.Spread.EnterCellEventHandler(this.spdAttrValue_EnterCell);
            this.spdAttrValue.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdAttrValue_CellDoubleClick);
            this.spdAttrValue.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdAttrValue_ButtonClicked);
            this.spdAttrValue.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdAttrValue_EditChange);
            // 
            // spdAttrValue_Sheet1
            // 
            this.spdAttrValue_Sheet1.Reset();
            spdAttrValue_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdAttrValue_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdAttrValue_Sheet1.ColumnCount = 14;
            spdAttrValue_Sheet1.RowCount = 3;
            this.spdAttrValue_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttrValue_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdAttrValue_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttrValue_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Name";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Current Value";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 4).ColumnSpan = 2;
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 4).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "New Value";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Null";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Array Type";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Array Separator";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Value Format";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Value Size";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Valid Table";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Table Type";
            this.spdAttrValue_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Allow Blank";
            this.spdAttrValue_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttrValue_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdAttrValue_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.WhiteSmoke;
            checkBoxCellType1.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            this.spdAttrValue_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdAttrValue_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdAttrValue_Sheet1.Columns.Get(0).Locked = true;
            this.spdAttrValue_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(0).Width = 24F;
            this.spdAttrValue_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdAttrValue_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAttrValue_Sheet1.Columns.Get(1).Label = "Name";
            this.spdAttrValue_Sheet1.Columns.Get(1).Locked = true;
            this.spdAttrValue_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdAttrValue_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(1).Width = 167F;
            this.spdAttrValue_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdAttrValue_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAttrValue_Sheet1.Columns.Get(2).Label = "Description";
            this.spdAttrValue_Sheet1.Columns.Get(2).Locked = true;
            this.spdAttrValue_Sheet1.Columns.Get(2).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdAttrValue_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(2).Width = 170F;
            this.spdAttrValue_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdAttrValue_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAttrValue_Sheet1.Columns.Get(3).Label = "Current Value";
            this.spdAttrValue_Sheet1.Columns.Get(3).Locked = true;
            this.spdAttrValue_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(3).Width = 130F;
            this.spdAttrValue_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdAttrValue_Sheet1.Columns.Get(4).Label = "New Value";
            this.spdAttrValue_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(4).Width = 150F;
            this.spdAttrValue_Sheet1.Columns.Get(5).Resizable = false;
            this.spdAttrValue_Sheet1.Columns.Get(5).Width = 25F;
            checkBoxCellType2.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            this.spdAttrValue_Sheet1.Columns.Get(6).CellType = checkBoxCellType2;
            this.spdAttrValue_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(6).Label = "Null";
            this.spdAttrValue_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdAttrValue_Sheet1.Columns.Get(6).Width = 30F;
            this.spdAttrValue_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdAttrValue_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdAttrValue_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttrValue_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdAttrValue_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdAttrValue_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdAttrValue_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnView.Location = new System.Drawing.Point(466, 7);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // cdvTableData
            // 
            this.cdvTableData.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvTableData.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableData.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTableData.Location = new System.Drawing.Point(189, 17);
            this.cdvTableData.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableData.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableData.Name = "cdvTableData";
            this.cdvTableData.Size = new System.Drawing.Size(20, 20);
            this.cdvTableData.SmallImageList = null;
            this.cdvTableData.TabIndex = 0;
            this.cdvTableData.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvTableData.VisibleColumnHeader = false;
            this.cdvTableData.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvTableData_SelectedItemChanged);
            // 
            // btnDelRow
            // 
            this.btnDelRow.Enabled = false;
            this.btnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelRow.Location = new System.Drawing.Point(12, 7);
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.Size = new System.Drawing.Size(88, 26);
            this.btnDelRow.TabIndex = 3;
            this.btnDelRow.Text = "Delete Row";
            this.btnDelRow.Click += new System.EventHandler(this.btnDelRow_Click);
            // 
            // frmBASTranAttributeByPrivilege
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmBASTranAttributeByPrivilege";
            this.Text = "Input Attribute Value by Privilege";
            this.Activated += new System.EventHandler(this.frmBASTranAttributeByPrivilege_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpAttribute.ResumeLayout(false);
            this.grpAttribute.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudToAttrSeq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFromAttrSeq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrType)).EndInit();
            this.pnlAttrInfo.ResumeLayout(false);
            this.grpAttrInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdAttrValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdAttrValue_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAttribute;
        private System.Windows.Forms.NumericUpDown nudToAttrSeq;
        private System.Windows.Forms.NumericUpDown nudFromAttrSeq;
        private UI.Controls.MCCodeView.MCCodeView cdvAttrKey;
        private System.Windows.Forms.Label lblAttrKey;
        private UI.Controls.MCCodeView.MCCodeView cdvAttrType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAttrSeq;
        private System.Windows.Forms.Label lblAttrType;
        private System.Windows.Forms.Panel pnlAttrInfo;
        private System.Windows.Forms.GroupBox grpAttrInfo;
        private FarPoint.Win.Spread.FpSpread spdAttrValue;
        private FarPoint.Win.Spread.SheetView spdAttrValue_Sheet1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.CheckBox chkOnlyPrvAttribute;
        private UI.Controls.MCCodeView.MCSPCodeView cdvTableData;
        private System.Windows.Forms.Button btnDelRow;
    }
}