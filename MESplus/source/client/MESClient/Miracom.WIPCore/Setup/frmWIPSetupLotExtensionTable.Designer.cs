namespace Miracom.WIPCore
{
    partial class frmWIPSetupLotExtensionTable
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
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWIPSetupLotExtensionTable));
            this.pnlTableStruct = new System.Windows.Forms.Panel();
            this.grpColumn = new System.Windows.Forms.GroupBox();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlQuery = new System.Windows.Forms.Panel();
            this.txtQuery = new System.Windows.Forms.RichTextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chkOnlyDefinition = new System.Windows.Forms.CheckBox();
            this.btnGenDrop = new System.Windows.Forms.Button();
            this.btnGenAdd = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlTableStruct.SuspendLayout();
            this.grpColumn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.pnlQuery.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Enabled = false;
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 6;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnGenAdd);
            this.pnlBottom.Controls.Add(this.btnGenDrop);
            this.pnlBottom.Controls.Add(this.chkOnlyDefinition);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            this.pnlBottom.Controls.SetChildIndex(this.chkOnlyDefinition, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnGenDrop, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnGenAdd, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlTableStruct);
            this.pnlCenter.Controls.Add(this.splitter1);
            this.pnlCenter.Controls.Add(this.pnlQuery);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm01";
            // 
            // pnlTableStruct
            // 
            this.pnlTableStruct.Controls.Add(this.grpColumn);
            this.pnlTableStruct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTableStruct.Location = new System.Drawing.Point(0, 0);
            this.pnlTableStruct.Name = "pnlTableStruct";
            this.pnlTableStruct.Size = new System.Drawing.Size(742, 300);
            this.pnlTableStruct.TabIndex = 0;
            // 
            // grpColumn
            // 
            this.grpColumn.Controls.Add(this.spdData);
            this.grpColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpColumn.Location = new System.Drawing.Point(0, 0);
            this.grpColumn.Name = "grpColumn";
            this.grpColumn.Size = new System.Drawing.Size(742, 300);
            this.grpColumn.TabIndex = 0;
            this.grpColumn.TabStop = false;
            this.grpColumn.Text = "Table Structure";
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "";
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 6;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.Location = new System.Drawing.Point(3, 16);
            this.spdData.Name = "spdData";
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(736, 281);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 0;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 7;
            this.spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.EditModeOff += new System.EventHandler(this.spdData_EditModeOff);
            this.spdData.SetActiveViewport(0, -1, -1);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 0;
            spdData_Sheet1.RowCount = 0;
            this.spdData_Sheet1.ActiveColumnIndex = -1;
            this.spdData_Sheet1.ActiveRowIndex = -1;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.Columns.Get(0).Width = 38F;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 300);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(742, 3);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // pnlQuery
            // 
            this.pnlQuery.Controls.Add(this.txtQuery);
            this.pnlQuery.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlQuery.Location = new System.Drawing.Point(0, 303);
            this.pnlQuery.Name = "pnlQuery";
            this.pnlQuery.Size = new System.Drawing.Size(742, 203);
            this.pnlQuery.TabIndex = 2;
            // 
            // txtQuery
            // 
            this.txtQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuery.Location = new System.Drawing.Point(0, 0);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ReadOnly = true;
            this.txtQuery.Size = new System.Drawing.Size(742, 203);
            this.txtQuery.TabIndex = 0;
            this.txtQuery.Text = "";
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(5, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(21, 26);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chkOnlyDefinition
            // 
            this.chkOnlyDefinition.AutoSize = true;
            this.chkOnlyDefinition.Location = new System.Drawing.Point(32, 12);
            this.chkOnlyDefinition.Name = "chkOnlyDefinition";
            this.chkOnlyDefinition.Size = new System.Drawing.Size(215, 17);
            this.chkOnlyDefinition.TabIndex = 1;
            this.chkOnlyDefinition.Text = "Change Table Definition Only";
            this.chkOnlyDefinition.UseVisualStyleBackColor = true;
            this.chkOnlyDefinition.Visible = true;
            // 
            // btnGenDrop
            // 
            this.btnGenDrop.Location = new System.Drawing.Point(333, 7);
            this.btnGenDrop.Name = "btnGenDrop";
            this.btnGenDrop.Size = new System.Drawing.Size(100, 26);
            this.btnGenDrop.TabIndex = 3;
            this.btnGenDrop.Text = "Gen Drop Script";
            this.btnGenDrop.UseVisualStyleBackColor = true;
            this.btnGenDrop.Click += new System.EventHandler(this.btnGenDrop_Click);
            // 
            // btnGenAdd
            // 
            this.btnGenAdd.Location = new System.Drawing.Point(230, 7);
            this.btnGenAdd.Name = "btnGenAdd";
            this.btnGenAdd.Size = new System.Drawing.Size(100, 26);
            this.btnGenAdd.TabIndex = 2;
            this.btnGenAdd.Text = "Gen Add Script";
            this.btnGenAdd.UseVisualStyleBackColor = true;
            this.btnGenAdd.Click += new System.EventHandler(this.btnGenAdd_Click);
            // 
            // frmWIPSetupLotExtensionTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPSetupLotExtensionTable";
            this.Text = "Lot Extension Table Setup";
            this.Activated += new System.EventHandler(this.frmWIPSetupLotExtension_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTableStruct.ResumeLayout(false);
            this.grpColumn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.pnlQuery.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlQuery;
        private System.Windows.Forms.RichTextBox txtQuery;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlTableStruct;
        private System.Windows.Forms.GroupBox grpColumn;
        private FarPoint.Win.Spread.FpSpread spdData;
        private FarPoint.Win.Spread.SheetView spdData_Sheet1;
        private System.Windows.Forms.CheckBox chkOnlyDefinition;
        protected System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnGenAdd;
        private System.Windows.Forms.Button btnGenDrop;
    }
}