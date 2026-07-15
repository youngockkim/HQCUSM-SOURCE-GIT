namespace SOI.HanwhaQcell.USModule
{
    partial class frmCUSTranLotInspectionChange
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCUSTranLotInspectionChange));
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer1 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer2 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            this.soiTableLayoutPanel4 = new SOI.OIFrx.SOIControls.SOITableLayoutPanel(this.components);
            this.spdList = new SOI.OIFrx.SOIControls.SOISpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.soiGroupBox11 = new SOI.OIFrx.SOIControls.SOIGroupBox(this.components);
            this.soiPanel7 = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.soiTableLayoutPanel9 = new SOI.OIFrx.SOIControls.SOITableLayoutPanel(this.components);
            this.soiPanel14 = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.soiTableLayoutPanel3 = new SOI.OIFrx.SOIControls.SOITableLayoutPanel(this.components);
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.txtLotId = new SOI.OIFrx.SOIControls.SOITextBox(this.components);
            this.lblPalletID = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.pnlPrintOption.SuspendLayout();
            this.pnlTopMargin.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlBottomMargin.SuspendLayout();
            this.pnlMiddleMargin.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlBottomClosePanel.SuspendLayout();
            this.soiTableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox11)).BeginInit();
            this.soiGroupBox11.SuspendLayout();
            this.soiPanel7.SuspendLayout();
            this.soiTableLayoutPanel9.SuspendLayout();
            this.soiPanel14.SuspendLayout();
            this.soiTableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotId)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrintOption
            // 
            this.btnPrintOption.Click += new System.EventHandler(this.btnPrintOption_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pbHelp
            // 
            this.pbHelp.Image = ((object)(resources.GetObject("pbHelp.Image")));
            // 
            // pbStdOper
            // 
            this.pbStdOper.Image = ((object)(resources.GetObject("pbStdOper.Image")));
            // 
            // btnClose
            // 
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlMiddleMargin
            // 
            this.pnlMiddleMargin.Controls.Add(this.soiTableLayoutPanel4);
            // 
            // soiTableLayoutPanel4
            // 
            this.soiTableLayoutPanel4._UseOITheme = true;
            this.soiTableLayoutPanel4.BackColor = System.Drawing.Color.Transparent;
            this.soiTableLayoutPanel4.ColumnCount = 1;
            this.soiTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel4.Controls.Add(this.spdList, 0, 2);
            this.soiTableLayoutPanel4.Controls.Add(this.soiGroupBox11, 0, 0);
            this.soiTableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiTableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.soiTableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.soiTableLayoutPanel4.Name = "soiTableLayoutPanel4";
            this.soiTableLayoutPanel4.RowCount = 3;
            this.soiTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.soiTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.soiTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 289F));
            this.soiTableLayoutPanel4.Size = new System.Drawing.Size(1234, 599);
            this.soiTableLayoutPanel4.TabIndex = 4;
            // 
            // spdList
            // 
            this.spdList._UseAutoHeight = true;
            this.spdList._UseOITheme = true;
            this.spdList.AccessibleDescription = "spdList, Sheet1, Row 0, Column 0, ";
            this.spdList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.HorizontalScrollBar.Name = "";
            enhancedScrollBarRenderer1.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer1.ArrowHoveredColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer1.ArrowSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer1.ButtonBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            enhancedScrollBarRenderer1.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            enhancedScrollBarRenderer1.ButtonHoveredBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer1.ButtonHoveredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer1.ButtonSelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer1.ButtonSelectedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer1.TrackBarBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            enhancedScrollBarRenderer1.TrackBarSelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.spdList.HorizontalScrollBar.Renderer = enhancedScrollBarRenderer1;
            this.spdList.HorizontalScrollBar.TabIndex = 12;
            this.spdList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdList.Location = new System.Drawing.Point(0, 70);
            this.spdList.Margin = new System.Windows.Forms.Padding(0);
            this.spdList.Name = "spdList";
            this.spdList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdList_Sheet1});
            this.spdList.Size = new System.Drawing.Size(1234, 529);
            this.spdList.SOICellHeight = 25;
            this.spdList.SOIColumnHeight = 30;
            this.spdList.TabIndex = 3;
            this.spdList.TabStop = false;
            this.spdList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdList.UseSOIContextMenu = true;
            this.spdList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.VerticalScrollBar.Name = "";
            enhancedScrollBarRenderer2.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer2.ArrowHoveredColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer2.ArrowSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer2.ButtonBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            enhancedScrollBarRenderer2.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            enhancedScrollBarRenderer2.ButtonHoveredBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer2.ButtonHoveredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer2.ButtonSelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer2.ButtonSelectedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer2.TrackBarBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            enhancedScrollBarRenderer2.TrackBarSelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.spdList.VerticalScrollBar.Renderer = enhancedScrollBarRenderer2;
            this.spdList.VerticalScrollBar.TabIndex = 13;
            this.spdList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdList.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdList.SetActiveViewport(0, -1, -1);
            // 
            // spdList_Sheet1
            // 
            this.spdList_Sheet1.Reset();
            spdList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdList_Sheet1.ColumnCount = 5;
            spdList_Sheet1.RowCount = 0;
            this.spdList_Sheet1.ActiveColumnIndex = -1;
            this.spdList_Sheet1.ActiveRowIndex = -1;
            this.spdList_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic1;
            this.spdList_Sheet1.ColumnFooter.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdList_Sheet1.ColumnFooter.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "No.";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Item.";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Item Description.";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Current Value.";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Change Value.";
            this.spdList_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdList_Sheet1.ColumnHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdList_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdList_Sheet1.ColumnHeader.Rows.Get(0).Height = 30F;
            this.spdList_Sheet1.ColumnHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdList_Sheet1.Columns.Get(0).Label = "No.";
            this.spdList_Sheet1.Columns.Get(0).Width = 100F;
            this.spdList_Sheet1.Columns.Get(1).Label = "Item.";
            this.spdList_Sheet1.Columns.Get(1).Width = 200F;
            this.spdList_Sheet1.Columns.Get(2).Label = "Item Description.";
            this.spdList_Sheet1.Columns.Get(2).Width = 450F;
            this.spdList_Sheet1.Columns.Get(3).Label = "Current Value.";
            this.spdList_Sheet1.Columns.Get(3).Width = 250F;
            this.spdList_Sheet1.Columns.Get(4).Label = "Change Value.";
            this.spdList_Sheet1.Columns.Get(4).Width = 250F;
            this.spdList_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdList_Sheet1.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdList_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.spdList_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdList_Sheet1.GrayAreaBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdList_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdList_Sheet1.PrintInfo.ShowColor = true;
            this.spdList_Sheet1.PrintInfo.SmartPrintRules = ((FarPoint.Win.Spread.SmartPrintRulesCollection)(resources.GetObject("resource.SmartPrintRules")));
            this.spdList_Sheet1.PrintInfo.UseMax = false;
            this.spdList_Sheet1.PrintInfo.UseSmartPrint = true;
            this.spdList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdList_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdList_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdList_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdList_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdList_Sheet1.RowHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdList_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdList_Sheet1.RowHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdList_Sheet1.RowHeader.Visible = false;
            this.spdList_Sheet1.SelectionStyle = FarPoint.Win.Spread.SelectionStyles.SelectionColors;
            this.spdList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdList_Sheet1.SheetCornerHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdList_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdList_Sheet1.SheetCornerStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdList_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdList_Sheet1.SheetCornerVerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdList_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // soiGroupBox11
            // 
            this.soiGroupBox11._UseOITheme = true;
            this.soiGroupBox11._UseStyle = SOI.OIFrx.SOIGroupBoxStyle.DefaultStyle;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            appearance16.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.soiGroupBox11.Appearance = appearance16;
            this.soiGroupBox11.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance43.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.soiGroupBox11.ContentAreaAppearance = appearance43;
            this.soiGroupBox11.Controls.Add(this.soiPanel7);
            this.soiGroupBox11.Dock = System.Windows.Forms.DockStyle.Fill;
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            appearance22.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            appearance22.FontData.BoldAsString = "True";
            appearance22.FontData.SizeInPoints = 14F;
            appearance22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            appearance22.TextHAlignAsString = "Right";
            this.soiGroupBox11.HeaderAppearance = appearance22;
            this.soiGroupBox11.Location = new System.Drawing.Point(0, 0);
            this.soiGroupBox11.Margin = new System.Windows.Forms.Padding(0);
            this.soiGroupBox11.Name = "soiGroupBox11";
            this.soiGroupBox11.Size = new System.Drawing.Size(1234, 60);
            this.soiGroupBox11.TabIndex = 2;
            this.soiGroupBox11.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005;
            // 
            // soiPanel7
            // 
            this.soiPanel7._SetAutoScrollPanel = false;
            this.soiPanel7._UseOITheme = true;
            this.soiPanel7._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.soiPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.soiPanel7.BackColor = System.Drawing.Color.Transparent;
            this.soiPanel7.Controls.Add(this.soiTableLayoutPanel9);
            this.soiPanel7.Location = new System.Drawing.Point(11, 5);
            this.soiPanel7.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.soiPanel7.Name = "soiPanel7";
            this.soiPanel7.Size = new System.Drawing.Size(1212, 49);
            this.soiPanel7.TabIndex = 0;
            // 
            // soiTableLayoutPanel9
            // 
            this.soiTableLayoutPanel9._UseOITheme = true;
            this.soiTableLayoutPanel9.BackColor = System.Drawing.Color.Transparent;
            this.soiTableLayoutPanel9.ColumnCount = 5;
            this.soiTableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.soiTableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.soiTableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.soiTableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.soiTableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.soiTableLayoutPanel9.Controls.Add(this.soiPanel14, 0, 0);
            this.soiTableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiTableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
            this.soiTableLayoutPanel9.Margin = new System.Windows.Forms.Padding(0);
            this.soiTableLayoutPanel9.Name = "soiTableLayoutPanel9";
            this.soiTableLayoutPanel9.RowCount = 1;
            this.soiTableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel9.Size = new System.Drawing.Size(1212, 49);
            this.soiTableLayoutPanel9.TabIndex = 1;
            // 
            // soiPanel14
            // 
            this.soiPanel14._SetAutoScrollPanel = false;
            this.soiPanel14._UseOITheme = true;
            this.soiPanel14._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.soiPanel14.BackColor = System.Drawing.Color.Transparent;
            this.soiPanel14.Controls.Add(this.soiTableLayoutPanel3);
            this.soiPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiPanel14.Location = new System.Drawing.Point(0, 0);
            this.soiPanel14.Margin = new System.Windows.Forms.Padding(0);
            this.soiPanel14.Name = "soiPanel14";
            this.soiPanel14.Size = new System.Drawing.Size(397, 49);
            this.soiPanel14.TabIndex = 1;
            // 
            // soiTableLayoutPanel3
            // 
            this.soiTableLayoutPanel3._UseOITheme = true;
            this.soiTableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.soiTableLayoutPanel3.ColumnCount = 3;
            this.soiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.soiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.soiTableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.soiTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.soiTableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.soiTableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.soiTableLayoutPanel3.Name = "soiTableLayoutPanel3";
            this.soiTableLayoutPanel3.RowCount = 1;
            this.soiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel3.Size = new System.Drawing.Size(397, 50);
            this.soiTableLayoutPanel3.TabIndex = 3;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblPalletID, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(30, 5);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(347, 40);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.txtLotId, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(140, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(207, 40);
            this.tableLayoutPanel5.TabIndex = 5;
            // 
            // txtLotId
            // 
            this.txtLotId._DecimalCount = 3;
            this.txtLotId._UseOITheme = true;
            this.txtLotId._UseOnlyNumeric = false;
            this.txtLotId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            appearance2.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            appearance2.FontData.BoldAsString = "True";
            appearance2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            appearance2.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.txtLotId.Appearance = appearance2;
            this.txtLotId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtLotId.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtLotId.Location = new System.Drawing.Point(0, 0);
            this.txtLotId.Margin = new System.Windows.Forms.Padding(0);
            this.txtLotId.MaxLength = 100;
            this.txtLotId.Name = "txtLotId";
            this.txtLotId.Size = new System.Drawing.Size(207, 29);
            this.txtLotId.TabIndex = 1;
            this.txtLotId.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtLotId.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.txtLotId.UseSOIContextMenu = true;
            this.txtLotId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLotId_KeyDown);
            // 
            // lblPalletID
            // 
            this.lblPalletID._UseConvertLanguage = true;
            this.lblPalletID._UseOITheme = true;
            this.lblPalletID._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            appearance48.BackColor = System.Drawing.Color.Transparent;
            appearance48.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance48.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance48.TextVAlignAsString = "Middle";
            this.lblPalletID.Appearance = appearance48;
            this.lblPalletID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPalletID.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPalletID.Location = new System.Drawing.Point(0, 0);
            this.lblPalletID.Margin = new System.Windows.Forms.Padding(0);
            this.lblPalletID.Name = "lblPalletID";
            this.lblPalletID.Size = new System.Drawing.Size(140, 40);
            this.lblPalletID.TabIndex = 2;
            this.lblPalletID.Text = "Lot ID";
            this.lblPalletID.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.lblPalletID.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // frmCUSTranLotInspectionChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 719);
            this.Name = "frmCUSTranLotInspectionChange";
            this.Text = "MESOI_Item_BaseForm03_Template1";
            this.Load += new System.EventHandler(this.frmTempSOIBaseForm03_Load);
            this.Shown += new System.EventHandler(this.frmTempSOIBaseForm03_Shown);
            this.pnlPrintOption.ResumeLayout(false);
            this.pnlTopMargin.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottomMargin.ResumeLayout(false);
            this.pnlMiddleMargin.ResumeLayout(false);
            this.pnlMiddle.ResumeLayout(false);
            this.pnlBottomClosePanel.ResumeLayout(false);
            this.soiTableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox11)).EndInit();
            this.soiGroupBox11.ResumeLayout(false);
            this.soiPanel7.ResumeLayout(false);
            this.soiTableLayoutPanel9.ResumeLayout(false);
            this.soiPanel14.ResumeLayout(false);
            this.soiTableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotId)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OIFrx.SOIControls.SOITableLayoutPanel soiTableLayoutPanel4;
        private OIFrx.SOIControls.SOISpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        private OIFrx.SOIControls.SOIGroupBox soiGroupBox11;
        private OIFrx.SOIControls.SOIPanel soiPanel7;
        private OIFrx.SOIControls.SOITableLayoutPanel soiTableLayoutPanel9;
        private OIFrx.SOIControls.SOIPanel soiPanel14;
        private OIFrx.SOIControls.SOITableLayoutPanel soiTableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private OIFrx.SOIControls.SOITextBox txtLotId;
        private OIFrx.SOIControls.SOILabel lblPalletID;
    }
}