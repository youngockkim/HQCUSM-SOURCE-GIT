namespace Miracom.WIPCore
{
    partial class frmWIPSetupLotExtension
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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDropScript = new System.Windows.Forms.Button();
            this.btnAddScript = new System.Windows.Forms.Button();
            this.splLot = new System.Windows.Forms.SplitContainer();
            this.grpColumn = new System.Windows.Forms.GroupBox();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grpAddRemove = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtQuery = new System.Windows.Forms.RichTextBox();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splLot)).BeginInit();
            this.splLot.Panel1.SuspendLayout();
            this.splLot.Panel2.SuspendLayout();
            this.splLot.SuspendLayout();
            this.grpColumn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.grpAddRemove.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Enabled = false;
            this.btnCreate.Location = new System.Drawing.Point(444, 7);
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(423, 7);
            this.btnDelete.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(555, 7);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnClear);
            this.pnlBottom.Controls.Add(this.btnDropScript);
            this.pnlBottom.Controls.Add(this.btnAddScript);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnAddScript, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDropScript, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClear, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm01";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(326, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 26);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDropScript
            // 
            this.btnDropScript.Location = new System.Drawing.Point(166, 7);
            this.btnDropScript.Name = "btnDropScript";
            this.btnDropScript.Size = new System.Drawing.Size(154, 26);
            this.btnDropScript.TabIndex = 13;
            this.btnDropScript.Text = "Generate Drop Script";
            this.btnDropScript.UseVisualStyleBackColor = true;
            this.btnDropScript.Click += new System.EventHandler(this.btnDropScript_Click);
            // 
            // btnAddScript
            // 
            this.btnAddScript.Location = new System.Drawing.Point(6, 7);
            this.btnAddScript.Name = "btnAddScript";
            this.btnAddScript.Size = new System.Drawing.Size(154, 26);
            this.btnAddScript.TabIndex = 12;
            this.btnAddScript.Text = "Generate Add Script";
            this.btnAddScript.UseVisualStyleBackColor = true;
            this.btnAddScript.Click += new System.EventHandler(this.btnAddScript_Click);
            // 
            // splLot
            // 
            this.splLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splLot.Location = new System.Drawing.Point(0, 0);
            this.splLot.Name = "splLot";
            this.splLot.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splLot.Panel1
            // 
            this.splLot.Panel1.Controls.Add(this.grpColumn);
            this.splLot.Panel1.Controls.Add(this.grpAddRemove);
            // 
            // splLot.Panel2
            // 
            this.splLot.Panel2.Controls.Add(this.txtQuery);
            this.splLot.Size = new System.Drawing.Size(742, 506);
            this.splLot.SplitterDistance = 241;
            this.splLot.TabIndex = 2;
            // 
            // grpColumn
            // 
            this.grpColumn.Controls.Add(this.spdData);
            this.grpColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpColumn.Location = new System.Drawing.Point(0, 0);
            this.grpColumn.Name = "grpColumn";
            this.grpColumn.Size = new System.Drawing.Size(742, 198);
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
            this.spdData.Size = new System.Drawing.Size(736, 179);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 3;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 7;
            this.spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.EditModeOff += new System.EventHandler(this.spdData_EditModeOff);
            this.spdData.EnterCell += new FarPoint.Win.Spread.EnterCellEventHandler(this.spdData_EnterCell);
            this.spdData.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdData_CellClick);
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
            // grpAddRemove
            // 
            this.grpAddRemove.Controls.Add(this.btnRemove);
            this.grpAddRemove.Controls.Add(this.btnAdd);
            this.grpAddRemove.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpAddRemove.Location = new System.Drawing.Point(0, 198);
            this.grpAddRemove.Name = "grpAddRemove";
            this.grpAddRemove.Size = new System.Drawing.Size(742, 43);
            this.grpAddRemove.TabIndex = 1;
            this.grpAddRemove.TabStop = false;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(649, 11);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(88, 26);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(555, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 26);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtQuery
            // 
            this.txtQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuery.Location = new System.Drawing.Point(0, 0);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ReadOnly = true;
            this.txtQuery.Size = new System.Drawing.Size(742, 261);
            this.txtQuery.TabIndex = 6;
            this.txtQuery.Text = "";
            // 
            // frmWIPSetupLotExtension
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.splLot);
            this.Name = "frmWIPSetupLotExtension";
            this.Text = "Sublot Option Setup";
            this.Activated += new System.EventHandler(this.frmWIPSetupLotExtension_Activated);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.Controls.SetChildIndex(this.splLot, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.splLot.Panel1.ResumeLayout(false);
            this.splLot.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splLot)).EndInit();
            this.splLot.ResumeLayout(false);
            this.grpColumn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.grpAddRemove.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDropScript;
        private System.Windows.Forms.Button btnAddScript;
        private System.Windows.Forms.SplitContainer splLot;
        private System.Windows.Forms.GroupBox grpColumn;
        private FarPoint.Win.Spread.FpSpread spdData;
        private FarPoint.Win.Spread.SheetView spdData_Sheet1;
        private System.Windows.Forms.GroupBox grpAddRemove;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RichTextBox txtQuery;
    }
}