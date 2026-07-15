namespace Miracom.BASCore
{
    partial class frmBASSetupDocumentDesign
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components == null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBASSetupDocumentDesign));
            this.cdvTextFont = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.cdvBarcodeFont = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.cdvRotate = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.cdvData = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.spdDesign_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grpSheet = new System.Windows.Forms.GroupBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtFormat = new System.Windows.Forms.TextBox();
            this.lblBOMSet = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabDesign = new System.Windows.Forms.TabControl();
            this.tbpDocDesign = new System.Windows.Forms.TabPage();
            this.pnlTemplate = new System.Windows.Forms.Panel();
            this.pnlAllTemp = new System.Windows.Forms.Panel();
            this.grbAllTemplate = new System.Windows.Forms.GroupBox();
            this.lisAvailTemplate = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlAttachLabelMid = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlAttached = new System.Windows.Forms.Panel();
            this.grbAttachTemplate = new System.Windows.Forms.GroupBox();
            this.lisAttachTemplate = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.txtStop = new System.Windows.Forms.TextBox();
            this.txtKeepLine = new System.Windows.Forms.TextBox();
            this.chkKeepLine = new System.Windows.Forms.CheckBox();
            this.chkPageBreak = new System.Windows.Forms.CheckBox();
            this.chkHeaderFlag = new System.Windows.Forms.CheckBox();
            this.lblLeft = new System.Windows.Forms.Label();
            this.lblFrozen = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.txtSpaceCount = new System.Windows.Forms.TextBox();
            this.lblSpaceCount = new System.Windows.Forms.Label();
            this.txtLeft = new System.Windows.Forms.TextBox();
            this.grpMakeTemplate = new System.Windows.Forms.GroupBox();
            this.pgcMake = new System.Windows.Forms.ProgressBar();
            this.btnMake = new System.Windows.Forms.Button();
            this.tbpPreview = new System.Windows.Forms.TabPage();
            this.spdDesign = new FarPoint.Win.Spread.FpSpread();
            this.pgcPreview = new System.Windows.Forms.ProgressBar();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTextFont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvBarcodeFont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRotate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDesign_Sheet1)).BeginInit();
            this.grpSheet.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabDesign.SuspendLayout();
            this.tbpDocDesign.SuspendLayout();
            this.pnlTemplate.SuspendLayout();
            this.pnlAllTemp.SuspendLayout();
            this.grbAllTemplate.SuspendLayout();
            this.pnlAttachLabelMid.SuspendLayout();
            this.pnlAttached.SuspendLayout();
            this.grbAttachTemplate.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.grpMakeTemplate.SuspendLayout();
            this.tbpPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdDesign)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(660, 7);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(566, 8);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(754, 7);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(848, 7);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.pgcPreview);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.pnlBottom.Size = new System.Drawing.Size(941, 40);
            this.pnlBottom.TabIndex = 0;
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            this.pnlBottom.Controls.SetChildIndex(this.pgcPreview, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.panel1);
            this.pnlCenter.Controls.Add(this.grpSheet);
            this.pnlCenter.Size = new System.Drawing.Size(941, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Template Design Setup";
            // 
            // cdvTextFont
            // 
            this.cdvTextFont.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvTextFont.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTextFont.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTextFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTextFont.Location = new System.Drawing.Point(17, 17);
            this.cdvTextFont.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTextFont.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTextFont.Name = "cdvTextFont";
            this.cdvTextFont.Size = new System.Drawing.Size(20, 20);
            this.cdvTextFont.SmallImageList = null;
            this.cdvTextFont.TabIndex = 0;
            this.cdvTextFont.TabStop = false;
            this.cdvTextFont.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvTextFont.Visible = false;
            this.cdvTextFont.VisibleColumnHeader = false;
            // 
            // cdvBarcodeFont
            // 
            this.cdvBarcodeFont.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvBarcodeFont.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvBarcodeFont.BorderHotColor = System.Drawing.Color.Black;
            this.cdvBarcodeFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvBarcodeFont.Location = new System.Drawing.Point(135, 17);
            this.cdvBarcodeFont.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvBarcodeFont.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvBarcodeFont.Name = "cdvBarcodeFont";
            this.cdvBarcodeFont.Size = new System.Drawing.Size(20, 20);
            this.cdvBarcodeFont.SmallImageList = null;
            this.cdvBarcodeFont.TabIndex = 0;
            this.cdvBarcodeFont.TabStop = false;
            this.cdvBarcodeFont.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvBarcodeFont.Visible = false;
            this.cdvBarcodeFont.VisibleColumnHeader = false;
            this.cdvBarcodeFont.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvRotate_SelectedItemChanged);
            // 
            // cdvRotate
            // 
            this.cdvRotate.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvRotate.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRotate.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvRotate.Location = new System.Drawing.Point(273, 17);
            this.cdvRotate.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRotate.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRotate.Name = "cdvRotate";
            this.cdvRotate.Size = new System.Drawing.Size(20, 20);
            this.cdvRotate.SmallImageList = null;
            this.cdvRotate.TabIndex = 0;
            this.cdvRotate.TabStop = false;
            this.cdvRotate.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvRotate.Visible = false;
            this.cdvRotate.VisibleColumnHeader = false;
            this.cdvRotate.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvRotate_SelectedItemChanged);
            // 
            // cdvData
            // 
            this.cdvData.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvData.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvData.BorderHotColor = System.Drawing.Color.Black;
            this.cdvData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvData.Location = new System.Drawing.Point(379, 17);
            this.cdvData.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvData.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvData.Name = "cdvData";
            this.cdvData.Size = new System.Drawing.Size(20, 20);
            this.cdvData.SmallImageList = null;
            this.cdvData.TabIndex = 0;
            this.cdvData.TabStop = false;
            this.cdvData.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvData.Visible = false;
            this.cdvData.VisibleColumnHeader = false;
            this.cdvData.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvRotate_SelectedItemChanged);
            // 
            // spdDesign_Sheet1
            // 
            this.spdDesign_Sheet1.Reset();
            spdDesign_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdDesign_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdDesign_Sheet1.ColumnCount = 0;
            spdDesign_Sheet1.ColumnFooter.RowCount = 0;
            spdDesign_Sheet1.RowCount = 0;
            this.spdDesign_Sheet1.ActiveColumnIndex = -1;
            this.spdDesign_Sheet1.ActiveRowIndex = -1;
            this.spdDesign_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDesign_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdDesign_Sheet1.ColumnFooter.RowCount = 0;
            this.spdDesign_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDesign_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdDesign_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDesign_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdDesign_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdDesign_Sheet1.FrozenColumnCount = 8;
            this.spdDesign_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdDesign_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdDesign_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDesign_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdDesign_Sheet1.RowHeader.Visible = false;
            this.spdDesign_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDesign_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdDesign_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpSheet
            // 
            this.grpSheet.Controls.Add(this.txtDesc);
            this.grpSheet.Controls.Add(this.txtFormat);
            this.grpSheet.Controls.Add(this.lblBOMSet);
            this.grpSheet.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSheet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSheet.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpSheet.Location = new System.Drawing.Point(0, 0);
            this.grpSheet.Name = "grpSheet";
            this.grpSheet.Size = new System.Drawing.Size(941, 48);
            this.grpSheet.TabIndex = 0;
            this.grpSheet.TabStop = false;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Enabled = false;
            this.txtDesc.Location = new System.Drawing.Point(310, 17);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(618, 20);
            this.txtDesc.TabIndex = 2;
            this.txtDesc.TabStop = false;
            // 
            // txtFormat
            // 
            this.txtFormat.Enabled = false;
            this.txtFormat.Location = new System.Drawing.Point(127, 16);
            this.txtFormat.MaxLength = 25;
            this.txtFormat.Name = "txtFormat";
            this.txtFormat.Size = new System.Drawing.Size(177, 20);
            this.txtFormat.TabIndex = 1;
            this.txtFormat.TabStop = false;
            // 
            // lblBOMSet
            // 
            this.lblBOMSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBOMSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBOMSet.Location = new System.Drawing.Point(15, 19);
            this.lblBOMSet.Name = "lblBOMSet";
            this.lblBOMSet.Size = new System.Drawing.Size(100, 14);
            this.lblBOMSet.TabIndex = 0;
            this.lblBOMSet.Text = "Document Format";
            this.lblBOMSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabDesign);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(941, 465);
            this.panel1.TabIndex = 5;
            // 
            // tabDesign
            // 
            this.tabDesign.Controls.Add(this.tbpDocDesign);
            this.tabDesign.Controls.Add(this.tbpPreview);
            this.tabDesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDesign.Location = new System.Drawing.Point(0, 0);
            this.tabDesign.Name = "tabDesign";
            this.tabDesign.SelectedIndex = 0;
            this.tabDesign.Size = new System.Drawing.Size(941, 465);
            this.tabDesign.TabIndex = 0;
            this.tabDesign.SelectedIndexChanged += new System.EventHandler(this.tabDesign_SelectedIndexChanged);
            // 
            // tbpDocDesign
            // 
            this.tbpDocDesign.Controls.Add(this.pnlTemplate);
            this.tbpDocDesign.Controls.Add(this.pnlLeft);
            this.tbpDocDesign.Location = new System.Drawing.Point(4, 22);
            this.tbpDocDesign.Name = "tbpDocDesign";
            this.tbpDocDesign.Size = new System.Drawing.Size(933, 439);
            this.tbpDocDesign.TabIndex = 0;
            this.tbpDocDesign.Text = "Document Design";
            // 
            // pnlTemplate
            // 
            this.pnlTemplate.Controls.Add(this.pnlAllTemp);
            this.pnlTemplate.Controls.Add(this.pnlAttachLabelMid);
            this.pnlTemplate.Controls.Add(this.pnlAttached);
            this.pnlTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTemplate.Location = new System.Drawing.Point(249, 0);
            this.pnlTemplate.Name = "pnlTemplate";
            this.pnlTemplate.Size = new System.Drawing.Size(684, 439);
            this.pnlTemplate.TabIndex = 8;
            // 
            // pnlAllTemp
            // 
            this.pnlAllTemp.Controls.Add(this.grbAllTemplate);
            this.pnlAllTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAllTemp.Location = new System.Drawing.Point(351, 0);
            this.pnlAllTemp.Name = "pnlAllTemp";
            this.pnlAllTemp.Size = new System.Drawing.Size(333, 439);
            this.pnlAllTemp.TabIndex = 30;
            // 
            // grbAllTemplate
            // 
            this.grbAllTemplate.Controls.Add(this.lisAvailTemplate);
            this.grbAllTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbAllTemplate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbAllTemplate.Location = new System.Drawing.Point(0, 0);
            this.grbAllTemplate.Name = "grbAllTemplate";
            this.grbAllTemplate.Size = new System.Drawing.Size(333, 439);
            this.grbAllTemplate.TabIndex = 0;
            this.grbAllTemplate.TabStop = false;
            this.grbAllTemplate.Text = "All Templates";
            // 
            // lisAvailTemplate
            // 
            this.lisAvailTemplate.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader5,
            this.ColumnHeader6});
            this.lisAvailTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAvailTemplate.EnableSort = true;
            this.lisAvailTemplate.EnableSortIcon = true;
            this.lisAvailTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAvailTemplate.FullRowSelect = true;
            this.lisAvailTemplate.Location = new System.Drawing.Point(3, 16);
            this.lisAvailTemplate.MultiSelect = false;
            this.lisAvailTemplate.Name = "lisAvailTemplate";
            this.lisAvailTemplate.Size = new System.Drawing.Size(327, 420);
            this.lisAvailTemplate.TabIndex = 0;
            this.lisAvailTemplate.UseCompatibleStateImageBehavior = false;
            this.lisAvailTemplate.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "Template";
            this.ColumnHeader5.Width = 100;
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "Description";
            this.ColumnHeader6.Width = 165;
            // 
            // pnlAttachLabelMid
            // 
            this.pnlAttachLabelMid.Controls.Add(this.btnDel);
            this.pnlAttachLabelMid.Controls.Add(this.btnAdd);
            this.pnlAttachLabelMid.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAttachLabelMid.Location = new System.Drawing.Point(318, 0);
            this.pnlAttachLabelMid.Name = "pnlAttachLabelMid";
            this.pnlAttachLabelMid.Size = new System.Drawing.Size(33, 439);
            this.pnlAttachLabelMid.TabIndex = 29;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Location = new System.Drawing.Point(4, 222);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(24, 24);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = ">";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Location = new System.Drawing.Point(4, 193);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "<";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlAttached
            // 
            this.pnlAttached.Controls.Add(this.grbAttachTemplate);
            this.pnlAttached.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAttached.Location = new System.Drawing.Point(0, 0);
            this.pnlAttached.Name = "pnlAttached";
            this.pnlAttached.Size = new System.Drawing.Size(318, 439);
            this.pnlAttached.TabIndex = 28;
            // 
            // grbAttachTemplate
            // 
            this.grbAttachTemplate.Controls.Add(this.lisAttachTemplate);
            this.grbAttachTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbAttachTemplate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbAttachTemplate.Location = new System.Drawing.Point(0, 0);
            this.grbAttachTemplate.Name = "grbAttachTemplate";
            this.grbAttachTemplate.Size = new System.Drawing.Size(318, 439);
            this.grbAttachTemplate.TabIndex = 0;
            this.grbAttachTemplate.TabStop = false;
            this.grbAttachTemplate.Text = "Attached Templates";
            // 
            // lisAttachTemplate
            // 
            this.lisAttachTemplate.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader3,
            this.ColumnHeader4});
            this.lisAttachTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAttachTemplate.EnableSort = false;
            this.lisAttachTemplate.EnableSortIcon = true;
            this.lisAttachTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAttachTemplate.FullRowSelect = true;
            this.lisAttachTemplate.Location = new System.Drawing.Point(3, 16);
            this.lisAttachTemplate.MultiSelect = false;
            this.lisAttachTemplate.Name = "lisAttachTemplate";
            this.lisAttachTemplate.Size = new System.Drawing.Size(312, 420);
            this.lisAttachTemplate.TabIndex = 0;
            this.lisAttachTemplate.UseCompatibleStateImageBehavior = false;
            this.lisAttachTemplate.View = System.Windows.Forms.View.Details;
            this.lisAttachTemplate.SelectedIndexChanged += new System.EventHandler(this.lisAttachTemplate_SelectedIndexChanged);
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Template";
            this.ColumnHeader3.Width = 100;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Description";
            this.ColumnHeader4.Width = 165;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grpOption);
            this.pnlLeft.Controls.Add(this.grpMakeTemplate);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(249, 439);
            this.pnlLeft.TabIndex = 9;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.txtStop);
            this.grpOption.Controls.Add(this.txtKeepLine);
            this.grpOption.Controls.Add(this.chkKeepLine);
            this.grpOption.Controls.Add(this.chkPageBreak);
            this.grpOption.Controls.Add(this.chkHeaderFlag);
            this.grpOption.Controls.Add(this.lblLeft);
            this.grpOption.Controls.Add(this.lblFrozen);
            this.grpOption.Controls.Add(this.txtStart);
            this.grpOption.Controls.Add(this.lblStart);
            this.grpOption.Controls.Add(this.txtSpaceCount);
            this.grpOption.Controls.Add(this.lblSpaceCount);
            this.grpOption.Controls.Add(this.txtLeft);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOption.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpOption.Location = new System.Drawing.Point(0, 0);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(249, 380);
            this.grpOption.TabIndex = 1;
            this.grpOption.TabStop = false;
            this.grpOption.Text = "Template Option";
            // 
            // txtStop
            // 
            this.txtStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStop.Location = new System.Drawing.Point(144, 95);
            this.txtStop.MaxLength = 50;
            this.txtStop.Name = "txtStop";
            this.txtStop.Size = new System.Drawing.Size(91, 20);
            this.txtStop.TabIndex = 3;
            // 
            // txtKeepLine
            // 
            this.txtKeepLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeepLine.Location = new System.Drawing.Point(144, 120);
            this.txtKeepLine.MaxLength = 50;
            this.txtKeepLine.Name = "txtKeepLine";
            this.txtKeepLine.Size = new System.Drawing.Size(91, 20);
            this.txtKeepLine.TabIndex = 4;
            this.txtKeepLine.Visible = false;
            // 
            // chkKeepLine
            // 
            this.chkKeepLine.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkKeepLine.Location = new System.Drawing.Point(19, 124);
            this.chkKeepLine.Name = "chkKeepLine";
            this.chkKeepLine.Size = new System.Drawing.Size(109, 14);
            this.chkKeepLine.TabIndex = 8;
            this.chkKeepLine.Text = "Keep Line Flag";
            this.chkKeepLine.CheckedChanged += new System.EventHandler(this.chkKeepLine_CheckedChanged);
            // 
            // chkPageBreak
            // 
            this.chkPageBreak.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkPageBreak.Location = new System.Drawing.Point(19, 176);
            this.chkPageBreak.Name = "chkPageBreak";
            this.chkPageBreak.Size = new System.Drawing.Size(109, 14);
            this.chkPageBreak.TabIndex = 11;
            this.chkPageBreak.Text = "Page Break";
            // 
            // chkHeaderFlag
            // 
            this.chkHeaderFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkHeaderFlag.Location = new System.Drawing.Point(19, 150);
            this.chkHeaderFlag.Name = "chkHeaderFlag";
            this.chkHeaderFlag.Size = new System.Drawing.Size(109, 14);
            this.chkHeaderFlag.TabIndex = 10;
            this.chkHeaderFlag.Text = "Header Flag";
            // 
            // lblLeft
            // 
            this.lblLeft.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeft.Location = new System.Drawing.Point(19, 23);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(100, 14);
            this.lblLeft.TabIndex = 0;
            this.lblLeft.Text = "Left Position";
            this.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFrozen
            // 
            this.lblFrozen.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFrozen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrozen.Location = new System.Drawing.Point(19, 98);
            this.lblFrozen.Name = "lblFrozen";
            this.lblFrozen.Size = new System.Drawing.Size(119, 14);
            this.lblFrozen.TabIndex = 6;
            this.lblFrozen.Text = "Stop Page of Header";
            this.lblFrozen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStart
            // 
            this.txtStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStart.Location = new System.Drawing.Point(144, 70);
            this.txtStart.MaxLength = 50;
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(91, 20);
            this.txtStart.TabIndex = 2;
            // 
            // lblStart
            // 
            this.lblStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.Location = new System.Drawing.Point(19, 73);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(119, 14);
            this.lblStart.TabIndex = 4;
            this.lblStart.Text = "Start Page of Header";
            this.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSpaceCount
            // 
            this.txtSpaceCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSpaceCount.Location = new System.Drawing.Point(144, 45);
            this.txtSpaceCount.MaxLength = 50;
            this.txtSpaceCount.Name = "txtSpaceCount";
            this.txtSpaceCount.Size = new System.Drawing.Size(91, 20);
            this.txtSpaceCount.TabIndex = 1;
            // 
            // lblSpaceCount
            // 
            this.lblSpaceCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSpaceCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpaceCount.Location = new System.Drawing.Point(19, 48);
            this.lblSpaceCount.Name = "lblSpaceCount";
            this.lblSpaceCount.Size = new System.Drawing.Size(100, 14);
            this.lblSpaceCount.TabIndex = 2;
            this.lblSpaceCount.Text = "Space Count";
            this.lblSpaceCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLeft
            // 
            this.txtLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLeft.Location = new System.Drawing.Point(144, 20);
            this.txtLeft.MaxLength = 25;
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.Size = new System.Drawing.Size(91, 20);
            this.txtLeft.TabIndex = 0;
            // 
            // grpMakeTemplate
            // 
            this.grpMakeTemplate.Controls.Add(this.pgcMake);
            this.grpMakeTemplate.Controls.Add(this.btnMake);
            this.grpMakeTemplate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpMakeTemplate.Location = new System.Drawing.Point(0, 380);
            this.grpMakeTemplate.Name = "grpMakeTemplate";
            this.grpMakeTemplate.Size = new System.Drawing.Size(249, 59);
            this.grpMakeTemplate.TabIndex = 2;
            this.grpMakeTemplate.TabStop = false;
            this.grpMakeTemplate.Text = "Make Template";
            // 
            // pgcMake
            // 
            this.pgcMake.Location = new System.Drawing.Point(8, 22);
            this.pgcMake.Name = "pgcMake";
            this.pgcMake.Size = new System.Drawing.Size(143, 22);
            this.pgcMake.TabIndex = 12;
            this.pgcMake.Visible = false;
            // 
            // btnMake
            // 
            this.btnMake.Location = new System.Drawing.Point(155, 20);
            this.btnMake.Name = "btnMake";
            this.btnMake.Size = new System.Drawing.Size(88, 26);
            this.btnMake.TabIndex = 13;
            this.btnMake.Text = "Make";
            this.btnMake.UseVisualStyleBackColor = true;
            this.btnMake.Click += new System.EventHandler(this.btnMake_Click);
            // 
            // tbpPreview
            // 
            this.tbpPreview.AutoScroll = true;
            this.tbpPreview.Controls.Add(this.spdDesign);
            this.tbpPreview.Location = new System.Drawing.Point(4, 22);
            this.tbpPreview.Name = "tbpPreview";
            this.tbpPreview.Size = new System.Drawing.Size(933, 439);
            this.tbpPreview.TabIndex = 1;
            this.tbpPreview.Text = "Preview";
            this.tbpPreview.Visible = false;
            // 
            // spdDesign
            // 
            this.spdDesign.AccessibleDescription = "spdSpread, Sheet1, Row 0, Column 0, ";
            this.spdDesign.BackColor = System.Drawing.SystemColors.Control;
            this.spdDesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdDesign.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdDesign.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDesign.HorizontalScrollBar.Name = "";
            this.spdDesign.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdDesign.HorizontalScrollBar.TabIndex = 1;
            this.spdDesign.Location = new System.Drawing.Point(0, 0);
            this.spdDesign.Name = "spdDesign";
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
            this.spdDesign.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdDesign.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdDesign.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdDesign_Sheet1});
            this.spdDesign.Size = new System.Drawing.Size(933, 439);
            this.spdDesign.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdDesign.TabIndex = 4;
            this.spdDesign.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDesign.VerticalScrollBar.Name = "";
            this.spdDesign.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdDesign.VerticalScrollBar.TabIndex = 2;
            this.spdDesign.SetViewportLeftColumn(0, 0, 8);
            this.spdDesign.SetActiveViewport(0, -1, -1);
            // 
            // pgcPreview
            // 
            this.pgcPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pgcPreview.Location = new System.Drawing.Point(40, 9);
            this.pgcPreview.Name = "pgcPreview";
            this.pgcPreview.Size = new System.Drawing.Size(708, 22);
            this.pgcPreview.TabIndex = 1;
            this.pgcPreview.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(10, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmBASSetupDocumentDesign
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(941, 553);
            this.MinimumSize = new System.Drawing.Size(957, 591);
            this.Name = "frmBASSetupDocumentDesign";
            this.Text = "Document Format Design";
            this.Activated += new System.EventHandler(this.frmBASSetupDocumentDesign_Activated);
            this.Load += new System.EventHandler(this.frmBASSetupDocumentDesign_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvTextFont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvBarcodeFont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRotate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDesign_Sheet1)).EndInit();
            this.grpSheet.ResumeLayout(false);
            this.grpSheet.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabDesign.ResumeLayout(false);
            this.tbpDocDesign.ResumeLayout(false);
            this.pnlTemplate.ResumeLayout(false);
            this.pnlAllTemp.ResumeLayout(false);
            this.grbAllTemplate.ResumeLayout(false);
            this.pnlAttachLabelMid.ResumeLayout(false);
            this.pnlAttached.ResumeLayout(false);
            this.grbAttachTemplate.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.grpMakeTemplate.ResumeLayout(false);
            this.tbpPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdDesign)).EndInit();
            this.ResumeLayout(false);

        }

        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvTextFont;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvBarcodeFont;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvRotate;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvData;
        private FarPoint.Win.Spread.SheetView spdDesign_Sheet1;
        private System.Windows.Forms.GroupBox grpSheet;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtFormat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabDesign;
        private System.Windows.Forms.TabPage tbpDocDesign;
        private System.Windows.Forms.TabPage tbpPreview;
        private FarPoint.Win.Spread.FpSpread spdDesign;
        private System.Windows.Forms.GroupBox grpOption;
        private System.Windows.Forms.CheckBox chkPageBreak;
        private System.Windows.Forms.CheckBox chkHeaderFlag;
        private System.Windows.Forms.Label lblLeft;        
        private System.Windows.Forms.Label lblFrozen;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.TextBox txtSpaceCount;
        private System.Windows.Forms.Label lblSpaceCount;
        private System.Windows.Forms.TextBox txtLeft;
        private System.Windows.Forms.Panel pnlTemplate;
        private System.Windows.Forms.Button btnMake;
        private System.Windows.Forms.ProgressBar pgcMake;                     
        private System.Windows.Forms.Label lblBOMSet;
        private System.Windows.Forms.CheckBox chkKeepLine;
        private System.Windows.Forms.TextBox txtKeepLine;
        private System.Windows.Forms.TextBox txtStop;
        private System.Windows.Forms.ProgressBar pgcPreview;
        protected System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.GroupBox grpMakeTemplate;
        private System.Windows.Forms.Panel pnlAllTemp;
        private System.Windows.Forms.GroupBox grbAllTemplate;
        private UI.Controls.MCListView.MCListView lisAvailTemplate;
        private System.Windows.Forms.ColumnHeader ColumnHeader5;
        private System.Windows.Forms.ColumnHeader ColumnHeader6;
        private System.Windows.Forms.Panel pnlAttachLabelMid;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlAttached;
        private System.Windows.Forms.GroupBox grbAttachTemplate;
        private UI.Controls.MCListView.MCListView lisAttachTemplate;
        private System.Windows.Forms.ColumnHeader ColumnHeader3;
        private System.Windows.Forms.ColumnHeader ColumnHeader4;                      
	}
}