namespace Custom.HanwhaQcell.USModule
{
    partial class frmViewOrderPopup
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
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.PnlTop1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cdvLine = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label2 = new System.Windows.Forms.Label();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.lblCalibrationInstituteName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpOrderDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpOrderDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.spdOrderList = new FarPoint.Win.Spread.FpSpread();
            this.spdOrderList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.PnlTop1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLine)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdOrderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdOrderList_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlMain);
            this.pnlCenter.Controls.Add(this.PnlTop1);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Work Order";
            // 
            // PnlTop1
            // 
            this.PnlTop1.Controls.Add(this.btnSearch);
            this.PnlTop1.Controls.Add(this.cdvLine);
            this.PnlTop1.Controls.Add(this.label2);
            this.PnlTop1.Controls.Add(this.cdvMaterial);
            this.PnlTop1.Controls.Add(this.txtOrderID);
            this.PnlTop1.Controls.Add(this.lblCalibrationInstituteName);
            this.PnlTop1.Controls.Add(this.label1);
            this.PnlTop1.Controls.Add(this.dtpOrderDateTo);
            this.PnlTop1.Controls.Add(this.dtpOrderDateFrom);
            this.PnlTop1.Controls.Add(this.label4);
            this.PnlTop1.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop1.Location = new System.Drawing.Point(0, 0);
            this.PnlTop1.Name = "PnlTop1";
            this.PnlTop1.Size = new System.Drawing.Size(742, 84);
            this.PnlTop1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(623, 55);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(88, 26);
            this.btnSearch.TabIndex = 124;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cdvLine
            // 
            this.cdvLine.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLine.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLine.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLine.BtnToolTipText = "";
            this.cdvLine.ButtonWidth = 20;
            this.cdvLine.DescText = "";
            this.cdvLine.DisplaySubItemIndex = 0;
            this.cdvLine.DisplayText = "";
            this.cdvLine.Focusing = null;
            this.cdvLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLine.Index = 0;
            this.cdvLine.IsViewBtnImage = false;
            this.cdvLine.Location = new System.Drawing.Point(448, 9);
            this.cdvLine.MaxLength = 40;
            this.cdvLine.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvLine.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvLine.MultiSelect = false;
            this.cdvLine.Name = "cdvLine";
            this.cdvLine.ReadOnly = false;
            this.cdvLine.SameWidthHeightOfButton = false;
            this.cdvLine.SearchSubItemIndex = 0;
            this.cdvLine.SelectedDescIndex = 1;
            this.cdvLine.SelectedDescToQueryText = "";
            this.cdvLine.SelectedSubItemIndex = 0;
            this.cdvLine.SelectedValueToQueryText = "";
            this.cdvLine.SelectionStart = 0;
            this.cdvLine.Size = new System.Drawing.Size(263, 21);
            this.cdvLine.SmallImageList = null;
            this.cdvLine.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLine.TabIndex = 122;
            this.cdvLine.TextBoxToolTipText = "";
            this.cdvLine.TextBoxWidth = 100;
            this.cdvLine.VisibleButton = true;
            this.cdvLine.VisibleColumnHeader = false;
            this.cdvLine.VisibleDescription = true;
            this.cdvLine.ButtonPress += new System.EventHandler(this.cdvLine_ButtonPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(374, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 123;
            this.label2.Text = "Line No.";
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
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
            this.cdvMaterial.Location = new System.Drawing.Point(374, 31);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(337, 20);
            this.cdvMaterial.TabIndex = 121;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = true;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = false;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 74;
            this.cdvMaterial.WidthMaterialAndVersion = 131;
            this.cdvMaterial.WidthVersion = 0;
            // 
            // txtOrderID
            // 
            this.txtOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderID.Location = new System.Drawing.Point(110, 31);
            this.txtOrderID.MaxLength = 100;
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(222, 20);
            this.txtOrderID.TabIndex = 120;
            // 
            // lblCalibrationInstituteName
            // 
            this.lblCalibrationInstituteName.AutoSize = true;
            this.lblCalibrationInstituteName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCalibrationInstituteName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalibrationInstituteName.Location = new System.Drawing.Point(8, 35);
            this.lblCalibrationInstituteName.Name = "lblCalibrationInstituteName";
            this.lblCalibrationInstituteName.Size = new System.Drawing.Size(47, 13);
            this.lblCalibrationInstituteName.TabIndex = 119;
            this.lblCalibrationInstituteName.Text = "Order ID";
            this.lblCalibrationInstituteName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(218, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 118;
            this.label1.Text = "~";
            // 
            // dtpOrderDateTo
            // 
            this.dtpOrderDateTo.Checked = false;
            this.dtpOrderDateTo.CustomFormat = "";
            this.dtpOrderDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDateTo.Location = new System.Drawing.Point(232, 5);
            this.dtpOrderDateTo.Name = "dtpOrderDateTo";
            this.dtpOrderDateTo.Size = new System.Drawing.Size(100, 20);
            this.dtpOrderDateTo.TabIndex = 117;
            // 
            // dtpOrderDateFrom
            // 
            this.dtpOrderDateFrom.Checked = false;
            this.dtpOrderDateFrom.CustomFormat = "";
            this.dtpOrderDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDateFrom.Location = new System.Drawing.Point(110, 5);
            this.dtpOrderDateFrom.Name = "dtpOrderDateFrom";
            this.dtpOrderDateFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpOrderDateFrom.TabIndex = 115;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(8, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 116;
            this.label4.Text = "Order Start Date";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.spdOrderList);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 84);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(742, 422);
            this.pnlMain.TabIndex = 1;
            // 
            // spdOrderList
            // 
            this.spdOrderList.AccessibleDescription = "spdOrderList, Sheet1, Row 0, Column 0, ";
            this.spdOrderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdOrderList.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdOrderList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdOrderList.HorizontalScrollBar.Name = "";
            this.spdOrderList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdOrderList.HorizontalScrollBar.TabIndex = 50;
            this.spdOrderList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdOrderList.Location = new System.Drawing.Point(0, 0);
            this.spdOrderList.Name = "spdOrderList";
            this.spdOrderList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdOrderList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdOrderList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdOrderList_Sheet1});
            this.spdOrderList.Size = new System.Drawing.Size(742, 422);
            this.spdOrderList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdOrderList.TabIndex = 12;
            this.spdOrderList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdOrderList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdOrderList.VerticalScrollBar.Name = "";
            this.spdOrderList.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdOrderList.VerticalScrollBar.TabIndex = 51;
            this.spdOrderList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdOrderList.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdOrderList_CellDoubleClick);
            this.spdOrderList.SetViewportLeftColumn(0, 0, 5);
            this.spdOrderList.SetActiveViewport(0, 0, -1);
            // 
            // spdOrderList_Sheet1
            // 
            this.spdOrderList_Sheet1.Reset();
            spdOrderList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdOrderList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdOrderList_Sheet1.ColumnCount = 11;
            spdOrderList_Sheet1.RowCount = 2;
            this.spdOrderList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOrderList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdOrderList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOrderList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Order ID";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Material Code";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Material Name";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Line Code";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Line Name";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Start Date";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Order Qty.";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Manager ID";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Manager Name";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "DEPT Code";
            this.spdOrderList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Alarm Code";
            this.spdOrderList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOrderList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdOrderList_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
            this.spdOrderList_Sheet1.Columns.Get(0).Label = "Order ID";
            this.spdOrderList_Sheet1.Columns.Get(0).Width = 100F;
            this.spdOrderList_Sheet1.Columns.Get(1).Label = "Material Code";
            this.spdOrderList_Sheet1.Columns.Get(1).Width = 110F;
            this.spdOrderList_Sheet1.Columns.Get(2).Label = "Material Name";
            this.spdOrderList_Sheet1.Columns.Get(2).Width = 230F;
            this.spdOrderList_Sheet1.Columns.Get(4).Label = "Line Name";
            this.spdOrderList_Sheet1.Columns.Get(4).Width = 110F;
            this.spdOrderList_Sheet1.Columns.Get(5).Label = "Start Date";
            this.spdOrderList_Sheet1.Columns.Get(5).Width = 90F;
            this.spdOrderList_Sheet1.Columns.Get(6).Label = "Order Qty.";
            this.spdOrderList_Sheet1.Columns.Get(6).Width = 70F;
            this.spdOrderList_Sheet1.Columns.Get(7).Label = "Manager ID";
            this.spdOrderList_Sheet1.Columns.Get(7).Visible = false;
            this.spdOrderList_Sheet1.Columns.Get(8).Label = "Manager Name";
            this.spdOrderList_Sheet1.Columns.Get(8).Visible = false;
            this.spdOrderList_Sheet1.Columns.Get(9).Label = "DEPT Code";
            this.spdOrderList_Sheet1.Columns.Get(9).Visible = false;
            this.spdOrderList_Sheet1.Columns.Get(10).Label = "Alarm Code";
            this.spdOrderList_Sheet1.Columns.Get(10).Visible = false;
            this.spdOrderList_Sheet1.FrozenColumnCount = 5;
            this.spdOrderList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdOrderList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdOrderList_Sheet1.RowHeader.Columns.Get(0).Width = 27F;
            this.spdOrderList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOrderList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdOrderList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdOrderList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdOrderList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdOrderList_Sheet1.ShowRowSelector = true;
            this.spdOrderList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmViewOrderPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmViewOrderPopup";
            this.Text = "View Work Order";
            this.Activated += new System.EventHandler(this.frmViewOrderPopup_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.PnlTop1.ResumeLayout(false);
            this.PnlTop1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLine)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdOrderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdOrderList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlTop1;
        private System.Windows.Forms.Panel pnlMain;
        private FarPoint.Win.Spread.FpSpread spdOrderList;
        private FarPoint.Win.Spread.SheetView spdOrderList_Sheet1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpOrderDateTo;
        private System.Windows.Forms.DateTimePicker dtpOrderDateFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Label lblCalibrationInstituteName;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private System.Windows.Forms.Button btnSearch;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLine;
        private System.Windows.Forms.Label label2;
    }
}