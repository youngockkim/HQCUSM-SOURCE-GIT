namespace Miracom.WEMCore
{
    partial class frmWEMViewWorkProcessEventStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWEMViewWorkProcessEventStatus));
            this.pnlProcStatus = new System.Windows.Forms.Panel();
            this.spdProgress = new FarPoint.Win.Spread.FpSpread();
            this.spdProgress_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlProcEventID = new System.Windows.Forms.Panel();
            this.txtEventStatus = new System.Windows.Forms.TextBox();
            this.lblEventStatus = new System.Windows.Forms.Label();
            this.txtEventDesc = new System.Windows.Forms.TextBox();
            this.cdvProcEventID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblProcEventID = new System.Windows.Forms.Label();
            this.lblProcID = new System.Windows.Forms.Label();
            this.cdvProcID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblProcType = new System.Windows.Forms.Label();
            this.cdvProcType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.btnExpand = new System.Windows.Forms.Button();
            this.btnCollapse = new System.Windows.Forms.Button();
            this.splProcEventID = new System.Windows.Forms.Splitter();
            this.pnlComment = new System.Windows.Forms.Panel();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.udcScreen = new Miracom.MESCore.Controls.udcFlexibleScreen();
            this.btnToPDF = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.sfdPDF = new System.Windows.Forms.SaveFileDialog();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlProcStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdProgress_Sheet1)).BeginInit();
            this.pnlProcEventID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcEventID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcType)).BeginInit();
            this.pnlComment.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Controls.Add(this.btnToPDF);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnToPDF, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.udcScreen);
            this.pnlCenter.Controls.Add(this.pnlComment);
            this.pnlCenter.Controls.Add(this.btnExpand);
            this.pnlCenter.Controls.Add(this.btnCollapse);
            this.pnlCenter.Controls.Add(this.splProcEventID);
            this.pnlCenter.Controls.Add(this.pnlProcEventID);
            this.pnlCenter.Controls.Add(this.pnlProcStatus);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "ViewForm01";
            // 
            // pnlProcStatus
            // 
            this.pnlProcStatus.Controls.Add(this.spdProgress);
            this.pnlProcStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProcStatus.Location = new System.Drawing.Point(0, 0);
            this.pnlProcStatus.Name = "pnlProcStatus";
            this.pnlProcStatus.Size = new System.Drawing.Size(742, 35);
            this.pnlProcStatus.TabIndex = 0;
            // 
            // spdProgress
            // 
            this.spdProgress.AccessibleDescription = "spdProgress, Sheet1, Row 0, Column 0, ";
            this.spdProgress.BackColor = System.Drawing.SystemColors.Control;
            this.spdProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spdProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdProgress.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdProgress.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdProgress.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdProgress.HorizontalScrollBar.Name = "";
            this.spdProgress.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdProgress.HorizontalScrollBar.TabIndex = 16;
            this.spdProgress.HorizontalScrollBarHeight = 13;
            this.spdProgress.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdProgress.Location = new System.Drawing.Point(0, 0);
            this.spdProgress.Name = "spdProgress";
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
            this.spdProgress.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdProgress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdProgress.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdProgress.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdProgress.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Cells;
            this.spdProgress.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdProgress_Sheet1});
            this.spdProgress.Size = new System.Drawing.Size(742, 35);
            this.spdProgress.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdProgress.TabIndex = 0;
            this.spdProgress.TabStop = false;
            this.spdProgress.TextTipDelay = 200;
            this.spdProgress.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdProgress.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdProgress.VerticalScrollBar.Name = "";
            this.spdProgress.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdProgress.VerticalScrollBar.TabIndex = 17;
            this.spdProgress.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdProgress.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdProgress_CellDoubleClick);
            // 
            // spdProgress_Sheet1
            // 
            this.spdProgress_Sheet1.Reset();
            spdProgress_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdProgress_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdProgress_Sheet1.ColumnCount = 100;
            spdProgress_Sheet1.ColumnHeader.RowCount = 0;
            spdProgress_Sheet1.RowCount = 1;
            spdProgress_Sheet1.RowHeader.ColumnCount = 0;
            this.spdProgress_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdProgress_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdProgress_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdProgress_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdProgress_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdProgress_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdProgress_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdProgress_Sheet1.DefaultStyle.Locked = true;
            this.spdProgress_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdProgress_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdProgress_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdProgress_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.spdProgress_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdProgress_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdProgress_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdProgress_Sheet1.Rows.Get(0).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.spdProgress_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdProgress_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdProgress_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.spdProgress_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlProcEventID
            // 
            this.pnlProcEventID.Controls.Add(this.txtEventStatus);
            this.pnlProcEventID.Controls.Add(this.lblEventStatus);
            this.pnlProcEventID.Controls.Add(this.txtEventDesc);
            this.pnlProcEventID.Controls.Add(this.cdvProcEventID);
            this.pnlProcEventID.Controls.Add(this.lblProcEventID);
            this.pnlProcEventID.Controls.Add(this.lblProcID);
            this.pnlProcEventID.Controls.Add(this.cdvProcID);
            this.pnlProcEventID.Controls.Add(this.lblProcType);
            this.pnlProcEventID.Controls.Add(this.cdvProcType);
            this.pnlProcEventID.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlProcEventID.Location = new System.Drawing.Point(0, 35);
            this.pnlProcEventID.Name = "pnlProcEventID";
            this.pnlProcEventID.Size = new System.Drawing.Size(200, 478);
            this.pnlProcEventID.TabIndex = 1;
            // 
            // txtEventStatus
            // 
            this.txtEventStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEventStatus.Location = new System.Drawing.Point(8, 263);
            this.txtEventStatus.MaxLength = 100;
            this.txtEventStatus.Name = "txtEventStatus";
            this.txtEventStatus.ReadOnly = true;
            this.txtEventStatus.Size = new System.Drawing.Size(186, 20);
            this.txtEventStatus.TabIndex = 8;
            // 
            // lblEventStatus
            // 
            this.lblEventStatus.AutoSize = true;
            this.lblEventStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventStatus.Location = new System.Drawing.Point(6, 245);
            this.lblEventStatus.Name = "lblEventStatus";
            this.lblEventStatus.Size = new System.Drawing.Size(109, 13);
            this.lblEventStatus.TabIndex = 7;
            this.lblEventStatus.Text = "Process Event Status";
            // 
            // txtEventDesc
            // 
            this.txtEventDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEventDesc.Location = new System.Drawing.Point(9, 130);
            this.txtEventDesc.MaxLength = 200;
            this.txtEventDesc.Multiline = true;
            this.txtEventDesc.Name = "txtEventDesc";
            this.txtEventDesc.ReadOnly = true;
            this.txtEventDesc.Size = new System.Drawing.Size(186, 109);
            this.txtEventDesc.TabIndex = 6;
            // 
            // cdvProcEventID
            // 
            this.cdvProcEventID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvProcEventID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcEventID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcEventID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvProcEventID.BtnToolTipText = "";
            this.cdvProcEventID.DescText = "";
            this.cdvProcEventID.DisplaySubItemIndex = -1;
            this.cdvProcEventID.DisplayText = "";
            this.cdvProcEventID.Focusing = null;
            this.cdvProcEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvProcEventID.Index = 0;
            this.cdvProcEventID.IsViewBtnImage = false;
            this.cdvProcEventID.Location = new System.Drawing.Point(8, 106);
            this.cdvProcEventID.MaxLength = 30;
            this.cdvProcEventID.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcEventID.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcEventID.Name = "cdvProcEventID";
            this.cdvProcEventID.ReadOnly = true;
            this.cdvProcEventID.SearchSubItemIndex = 0;
            this.cdvProcEventID.SelectedDescIndex = -1;
            this.cdvProcEventID.SelectedSubItemIndex = -1;
            this.cdvProcEventID.SelectionStart = 0;
            this.cdvProcEventID.Size = new System.Drawing.Size(187, 20);
            this.cdvProcEventID.SmallImageList = null;
            this.cdvProcEventID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvProcEventID.TabIndex = 5;
            this.cdvProcEventID.TextBoxToolTipText = "";
            this.cdvProcEventID.TextBoxWidth = 187;
            this.cdvProcEventID.VisibleButton = true;
            this.cdvProcEventID.VisibleColumnHeader = false;
            this.cdvProcEventID.VisibleDescription = false;
            this.cdvProcEventID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvProcEventID_SelectedItemChanged);
            this.cdvProcEventID.ButtonPress += new System.EventHandler(this.cdvProcEventID_ButtonPress);
            // 
            // lblProcEventID
            // 
            this.lblProcEventID.AutoSize = true;
            this.lblProcEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcEventID.Location = new System.Drawing.Point(6, 88);
            this.lblProcEventID.Name = "lblProcEventID";
            this.lblProcEventID.Size = new System.Drawing.Size(106, 13);
            this.lblProcEventID.TabIndex = 4;
            this.lblProcEventID.Text = "Process Event ID";
            // 
            // lblProcID
            // 
            this.lblProcID.AutoSize = true;
            this.lblProcID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcID.Location = new System.Drawing.Point(6, 45);
            this.lblProcID.Name = "lblProcID";
            this.lblProcID.Size = new System.Drawing.Size(59, 13);
            this.lblProcID.TabIndex = 2;
            this.lblProcID.Text = "Process ID";
            // 
            // cdvProcID
            // 
            this.cdvProcID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvProcID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvProcID.BtnToolTipText = "";
            this.cdvProcID.DescText = "";
            this.cdvProcID.DisplaySubItemIndex = -1;
            this.cdvProcID.DisplayText = "";
            this.cdvProcID.Focusing = null;
            this.cdvProcID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvProcID.Index = 0;
            this.cdvProcID.IsViewBtnImage = false;
            this.cdvProcID.Location = new System.Drawing.Point(8, 63);
            this.cdvProcID.MaxLength = 30;
            this.cdvProcID.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcID.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcID.Name = "cdvProcID";
            this.cdvProcID.ReadOnly = true;
            this.cdvProcID.SearchSubItemIndex = 0;
            this.cdvProcID.SelectedDescIndex = -1;
            this.cdvProcID.SelectedSubItemIndex = -1;
            this.cdvProcID.SelectionStart = 0;
            this.cdvProcID.Size = new System.Drawing.Size(187, 20);
            this.cdvProcID.SmallImageList = null;
            this.cdvProcID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvProcID.TabIndex = 3;
            this.cdvProcID.TextBoxToolTipText = "";
            this.cdvProcID.TextBoxWidth = 187;
            this.cdvProcID.VisibleButton = true;
            this.cdvProcID.VisibleColumnHeader = false;
            this.cdvProcID.VisibleDescription = false;
            this.cdvProcID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvProcID_SelectedItemChanged);
            this.cdvProcID.ButtonPress += new System.EventHandler(this.cdvProcID_ButtonPress);
            // 
            // lblProcType
            // 
            this.lblProcType.AutoSize = true;
            this.lblProcType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcType.Location = new System.Drawing.Point(6, 4);
            this.lblProcType.Name = "lblProcType";
            this.lblProcType.Size = new System.Drawing.Size(101, 13);
            this.lblProcType.TabIndex = 0;
            this.lblProcType.Text = "Work Process Type";
            // 
            // cdvProcType
            // 
            this.cdvProcType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvProcType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvProcType.BtnToolTipText = "";
            this.cdvProcType.DescText = "";
            this.cdvProcType.DisplaySubItemIndex = -1;
            this.cdvProcType.DisplayText = "";
            this.cdvProcType.Focusing = null;
            this.cdvProcType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvProcType.Index = 0;
            this.cdvProcType.IsViewBtnImage = false;
            this.cdvProcType.Location = new System.Drawing.Point(8, 22);
            this.cdvProcType.MaxLength = 30;
            this.cdvProcType.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcType.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcType.Name = "cdvProcType";
            this.cdvProcType.ReadOnly = true;
            this.cdvProcType.SearchSubItemIndex = 0;
            this.cdvProcType.SelectedDescIndex = -1;
            this.cdvProcType.SelectedSubItemIndex = -1;
            this.cdvProcType.SelectionStart = 0;
            this.cdvProcType.Size = new System.Drawing.Size(187, 20);
            this.cdvProcType.SmallImageList = null;
            this.cdvProcType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvProcType.TabIndex = 1;
            this.cdvProcType.TextBoxToolTipText = "";
            this.cdvProcType.TextBoxWidth = 187;
            this.cdvProcType.VisibleButton = true;
            this.cdvProcType.VisibleColumnHeader = false;
            this.cdvProcType.VisibleDescription = false;
            this.cdvProcType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvProcType_SelectedItemChanged);
            this.cdvProcType.ButtonPress += new System.EventHandler(this.cdvProcType_ButtonPress);
            // 
            // btnExpand
            // 
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExpand.Image = ((System.Drawing.Image)(resources.GetObject("btnExpand.Image")));
            this.btnExpand.Location = new System.Drawing.Point(200, 272);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(9, 24);
            this.btnExpand.TabIndex = 3;
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnCollapse
            // 
            this.btnCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCollapse.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapse.Image")));
            this.btnCollapse.Location = new System.Drawing.Point(200, 245);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(9, 24);
            this.btnCollapse.TabIndex = 2;
            this.btnCollapse.UseVisualStyleBackColor = true;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // splProcEventID
            // 
            this.splProcEventID.Location = new System.Drawing.Point(200, 35);
            this.splProcEventID.Name = "splProcEventID";
            this.splProcEventID.Size = new System.Drawing.Size(9, 478);
            this.splProcEventID.TabIndex = 2;
            this.splProcEventID.TabStop = false;
            this.splProcEventID.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splProcEventID_SplitterMoved);
            // 
            // pnlComment
            // 
            this.pnlComment.Controls.Add(this.txtComment);
            this.pnlComment.Controls.Add(this.lblComment);
            this.pnlComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlComment.Location = new System.Drawing.Point(209, 489);
            this.pnlComment.Name = "pnlComment";
            this.pnlComment.Size = new System.Drawing.Size(533, 24);
            this.pnlComment.TabIndex = 5;
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(70, 2);
            this.txtComment.MaxLength = 400;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(460, 20);
            this.txtComment.TabIndex = 1;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(6, 5);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "Comment";
            // 
            // udcScreen
            // 
            this.udcScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcScreen.Location = new System.Drawing.Point(209, 35);
            this.udcScreen.Name = "udcScreen";
            this.udcScreen.ScreenAutoStretch = false;
            this.udcScreen.ScreenID = null;
            this.udcScreen.ScreenLock = false;
            this.udcScreen.ScreenLockBackColor = System.Drawing.Color.Empty;
            this.udcScreen.Size = new System.Drawing.Size(533, 454);
            this.udcScreen.TabIndex = 4;
            // 
            // btnToPDF
            // 
            this.btnToPDF.Location = new System.Drawing.Point(8, 7);
            this.btnToPDF.Name = "btnToPDF";
            this.btnToPDF.Size = new System.Drawing.Size(88, 26);
            this.btnToPDF.TabIndex = 0;
            this.btnToPDF.Text = "To PDF";
            this.btnToPDF.UseVisualStyleBackColor = true;
            this.btnToPDF.Click += new System.EventHandler(this.btnToPDF_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(558, 7);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // frmWEMViewWorkProcessEventStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWEMViewWorkProcessEventStatus";
            this.Text = "View Work Process Event Status";
            this.Activated += new System.EventHandler(this.frmWEMViewWorkProcessEventStatus_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlProcStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdProgress_Sheet1)).EndInit();
            this.pnlProcEventID.ResumeLayout(false);
            this.pnlProcEventID.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcEventID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcType)).EndInit();
            this.pnlComment.ResumeLayout(false);
            this.pnlComment.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlProcStatus;
        private FarPoint.Win.Spread.FpSpread spdProgress;
        private FarPoint.Win.Spread.SheetView spdProgress_Sheet1;
        private System.Windows.Forms.Panel pnlProcEventID;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Button btnCollapse;
        private System.Windows.Forms.Splitter splProcEventID;
        private System.Windows.Forms.Panel pnlComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lblComment;
        private MESCore.Controls.udcFlexibleScreen udcScreen;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnToPDF;
        private System.Windows.Forms.Label lblProcEventID;
        private System.Windows.Forms.Label lblProcID;
        private UI.Controls.MCCodeView.MCCodeView cdvProcID;
        private System.Windows.Forms.Label lblProcType;
        private UI.Controls.MCCodeView.MCCodeView cdvProcType;
        private UI.Controls.MCCodeView.MCCodeView cdvProcEventID;
        private System.Windows.Forms.TextBox txtEventDesc;
        private System.Windows.Forms.SaveFileDialog sfdPDF;
        private System.Windows.Forms.TextBox txtEventStatus;
        private System.Windows.Forms.Label lblEventStatus;
    }
}