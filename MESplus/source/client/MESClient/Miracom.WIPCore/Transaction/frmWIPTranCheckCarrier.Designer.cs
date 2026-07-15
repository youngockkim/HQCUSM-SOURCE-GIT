namespace Miracom.WIPCore
{
    partial class frmWIPTranCheckCarrier
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
            this.grpLotInfo = new System.Windows.Forms.GroupBox();
            this.txtCrrID = new System.Windows.Forms.TextBox();
            this.lblCrrID = new System.Windows.Forms.Label();
            this.txtOper = new System.Windows.Forms.TextBox();
            this.lblOper = new System.Windows.Forms.Label();
            this.txtFlow = new System.Windows.Forms.TextBox();
            this.lblFlow = new System.Windows.Forms.Label();
            this.txtQty3 = new System.Windows.Forms.TextBox();
            this.txtQty2 = new System.Windows.Forms.TextBox();
            this.txtQty1 = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.pnlOk = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.spdCarrier = new FarPoint.Win.Spread.FpSpread();
            this.spdCarrier_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grpLotInfo.SuspendLayout();
            this.pnlOk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdCarrier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCarrier_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpLotInfo
            // 
            this.grpLotInfo.Controls.Add(this.txtCrrID);
            this.grpLotInfo.Controls.Add(this.lblCrrID);
            this.grpLotInfo.Controls.Add(this.txtOper);
            this.grpLotInfo.Controls.Add(this.lblOper);
            this.grpLotInfo.Controls.Add(this.txtFlow);
            this.grpLotInfo.Controls.Add(this.lblFlow);
            this.grpLotInfo.Controls.Add(this.txtQty3);
            this.grpLotInfo.Controls.Add(this.txtQty2);
            this.grpLotInfo.Controls.Add(this.txtQty1);
            this.grpLotInfo.Controls.Add(this.lblQty);
            this.grpLotInfo.Controls.Add(this.txtMaterial);
            this.grpLotInfo.Controls.Add(this.lblMaterial);
            this.grpLotInfo.Controls.Add(this.txtLotID);
            this.grpLotInfo.Controls.Add(this.lblLotID);
            this.grpLotInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLotInfo.Location = new System.Drawing.Point(0, 0);
            this.grpLotInfo.Name = "grpLotInfo";
            this.grpLotInfo.Size = new System.Drawing.Size(258, 164);
            this.grpLotInfo.TabIndex = 0;
            this.grpLotInfo.TabStop = false;
            this.grpLotInfo.Text = "Lot Information";
            // 
            // txtCrrID
            // 
            this.txtCrrID.Location = new System.Drawing.Point(102, 137);
            this.txtCrrID.MaxLength = 20;
            this.txtCrrID.Name = "txtCrrID";
            this.txtCrrID.Size = new System.Drawing.Size(150, 20);
            this.txtCrrID.TabIndex = 13;
            this.txtCrrID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCrrID_KeyPress);
            // 
            // lblCrrID
            // 
            this.lblCrrID.AutoSize = true;
            this.lblCrrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrID.Location = new System.Drawing.Point(12, 140);
            this.lblCrrID.Name = "lblCrrID";
            this.lblCrrID.Size = new System.Drawing.Size(61, 13);
            this.lblCrrID.TabIndex = 12;
            this.lblCrrID.Text = "Carrier ID";
            // 
            // txtOper
            // 
            this.txtOper.Location = new System.Drawing.Point(102, 88);
            this.txtOper.MaxLength = 10;
            this.txtOper.Name = "txtOper";
            this.txtOper.ReadOnly = true;
            this.txtOper.Size = new System.Drawing.Size(150, 20);
            this.txtOper.TabIndex = 7;
            // 
            // lblOper
            // 
            this.lblOper.AutoSize = true;
            this.lblOper.Location = new System.Drawing.Point(12, 92);
            this.lblOper.Name = "lblOper";
            this.lblOper.Size = new System.Drawing.Size(53, 13);
            this.lblOper.TabIndex = 6;
            this.lblOper.Text = "Operation";
            // 
            // txtFlow
            // 
            this.txtFlow.Location = new System.Drawing.Point(102, 64);
            this.txtFlow.MaxLength = 20;
            this.txtFlow.Name = "txtFlow";
            this.txtFlow.ReadOnly = true;
            this.txtFlow.Size = new System.Drawing.Size(150, 20);
            this.txtFlow.TabIndex = 5;
            // 
            // lblFlow
            // 
            this.lblFlow.AutoSize = true;
            this.lblFlow.Location = new System.Drawing.Point(12, 68);
            this.lblFlow.Name = "lblFlow";
            this.lblFlow.Size = new System.Drawing.Size(29, 13);
            this.lblFlow.TabIndex = 4;
            this.lblFlow.Text = "Flow";
            // 
            // txtQty3
            // 
            this.txtQty3.Location = new System.Drawing.Point(204, 112);
            this.txtQty3.MaxLength = 11;
            this.txtQty3.Name = "txtQty3";
            this.txtQty3.ReadOnly = true;
            this.txtQty3.Size = new System.Drawing.Size(48, 20);
            this.txtQty3.TabIndex = 11;
            // 
            // txtQty2
            // 
            this.txtQty2.Location = new System.Drawing.Point(153, 112);
            this.txtQty2.MaxLength = 11;
            this.txtQty2.Name = "txtQty2";
            this.txtQty2.ReadOnly = true;
            this.txtQty2.Size = new System.Drawing.Size(48, 20);
            this.txtQty2.TabIndex = 10;
            // 
            // txtQty1
            // 
            this.txtQty1.Location = new System.Drawing.Point(102, 112);
            this.txtQty1.MaxLength = 11;
            this.txtQty1.Name = "txtQty1";
            this.txtQty1.ReadOnly = true;
            this.txtQty1.Size = new System.Drawing.Size(48, 20);
            this.txtQty1.TabIndex = 9;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(12, 116);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(54, 13);
            this.lblQty.TabIndex = 8;
            this.lblQty.Text = "Qty 1/2/3";
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(102, 40);
            this.txtMaterial.MaxLength = 30;
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.ReadOnly = true;
            this.txtMaterial.Size = new System.Drawing.Size(150, 20);
            this.txtMaterial.TabIndex = 3;
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Location = new System.Drawing.Point(12, 44);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(44, 13);
            this.lblMaterial.TabIndex = 2;
            this.lblMaterial.Text = "Material";
            // 
            // txtLotID
            // 
            this.txtLotID.Location = new System.Drawing.Point(102, 16);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(150, 20);
            this.txtLotID.TabIndex = 1;
            this.txtLotID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotID_KeyPress);
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(12, 20);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            this.lblLotID.TabIndex = 0;
            this.lblLotID.Text = "Lot ID";
            // 
            // pnlOk
            // 
            this.pnlOk.Controls.Add(this.btnClose);
            this.pnlOk.Controls.Add(this.btnOk);
            this.pnlOk.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlOk.Location = new System.Drawing.Point(0, 489);
            this.pnlOk.Name = "pnlOk";
            this.pnlOk.Size = new System.Drawing.Size(258, 38);
            this.pnlOk.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(182, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 24);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(109, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 24);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // spdCarrier
            // 
            this.spdCarrier.AccessibleDescription = "spdCarrier, Sheet1, Row 0, Column 0, ";
            this.spdCarrier.BackColor = System.Drawing.SystemColors.Control;
            this.spdCarrier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdCarrier.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdCarrier.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCarrier.HorizontalScrollBar.Name = "";
            this.spdCarrier.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdCarrier.HorizontalScrollBar.TabIndex = 8;
            this.spdCarrier.Location = new System.Drawing.Point(0, 164);
            this.spdCarrier.Name = "spdCarrier";
            this.spdCarrier.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdCarrier.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdCarrier.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdCarrier_Sheet1});
            this.spdCarrier.Size = new System.Drawing.Size(258, 325);
            this.spdCarrier.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdCarrier.TabIndex = 1;
            this.spdCarrier.TabStop = false;
            this.spdCarrier.TextTipDelay = 200;
            this.spdCarrier.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdCarrier.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCarrier.VerticalScrollBar.Name = "";
            this.spdCarrier.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdCarrier.VerticalScrollBar.TabIndex = 9;
            // 
            // spdCarrier_Sheet1
            // 
            this.spdCarrier_Sheet1.Reset();
            spdCarrier_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdCarrier_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdCarrier_Sheet1.ColumnCount = 3;
            spdCarrier_Sheet1.RowCount = 3;
            this.spdCarrier_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdCarrier_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCarrier_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdCarrier_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCarrier_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdCarrier_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Carrier ID";
            this.spdCarrier_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Check";
            this.spdCarrier_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Qty 1";
            this.spdCarrier_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCarrier_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdCarrier_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdCarrier_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCarrier_Sheet1.Columns.Get(0).Label = "Carrier ID";
            this.spdCarrier_Sheet1.Columns.Get(0).Locked = true;
            this.spdCarrier_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCarrier_Sheet1.Columns.Get(0).Width = 90F;
            this.spdCarrier_Sheet1.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.spdCarrier_Sheet1.Columns.Get(1).ForeColor = System.Drawing.Color.Black;
            this.spdCarrier_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCarrier_Sheet1.Columns.Get(1).Label = "Check";
            this.spdCarrier_Sheet1.Columns.Get(1).Locked = true;
            this.spdCarrier_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCarrier_Sheet1.Columns.Get(1).Width = 50F;
            this.spdCarrier_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCarrier_Sheet1.Columns.Get(2).Label = "Qty 1";
            this.spdCarrier_Sheet1.Columns.Get(2).Locked = true;
            this.spdCarrier_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCarrier_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdCarrier_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdCarrier_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCarrier_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdCarrier_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCarrier_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdCarrier_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmWIPTranCheckCarrier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 527);
            this.Controls.Add(this.spdCarrier);
            this.Controls.Add(this.pnlOk);
            this.Controls.Add(this.grpLotInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmWIPTranCheckCarrier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Check Carrier";
            this.Activated += new System.EventHandler(this.frmWIPTranCheckCarrier_Activated);
            this.Load += new System.EventHandler(this.frmWIPTranCheckCarrier_Load);
            this.grpLotInfo.ResumeLayout(false);
            this.grpLotInfo.PerformLayout();
            this.pnlOk.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdCarrier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCarrier_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLotInfo;
        private System.Windows.Forms.TextBox txtOper;
        private System.Windows.Forms.Label lblOper;
        private System.Windows.Forms.TextBox txtFlow;
        private System.Windows.Forms.Label lblFlow;
        private System.Windows.Forms.TextBox txtQty3;
        private System.Windows.Forms.TextBox txtQty2;
        private System.Windows.Forms.TextBox txtQty1;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.Panel pnlOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private FarPoint.Win.Spread.FpSpread spdCarrier;
        private FarPoint.Win.Spread.SheetView spdCarrier_Sheet1;
        private System.Windows.Forms.TextBox txtCrrID;
        private System.Windows.Forms.Label lblCrrID;
    }
}