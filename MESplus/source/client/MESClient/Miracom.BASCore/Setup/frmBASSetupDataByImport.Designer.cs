namespace Miracom.BASCore
{
    partial class frmBASSetupDataByImport
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
            this.lblModelFile = new System.Windows.Forms.Label();
            this.btnSaveResult = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txtModelFile = new System.Windows.Forms.TextBox();
            this.spdModel = new FarPoint.Win.Spread.FpSpread();
            this.spdModel_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grpModelItem = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnValHead = new System.Windows.Forms.Button();
            this.cboModelItem = new System.Windows.Forms.ComboBox();
            this.lblModelItem = new System.Windows.Forms.Label();
            this.btnValValue = new System.Windows.Forms.Button();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.sfdFile = new System.Windows.Forms.SaveFileDialog();
            this.grpProgress = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblErrCnt = new System.Windows.Forms.Label();
            this.lblErr = new System.Windows.Forms.Label();
            this.lblOkCnt = new System.Windows.Forms.Label();
            this.lblOk = new System.Windows.Forms.Label();
            this.lblTotalCnt = new System.Windows.Forms.Label();
            this.lblPercent = new System.Windows.Forms.Label();
            this.prgBar = new System.Windows.Forms.ProgressBar();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdModel_Sheet1)).BeginInit();
            this.grpModelItem.SuspendLayout();
            this.grpProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(0, 17);
            this.btnRefresh.Visible = false;
            // 
            // pnlTranTop
            // 
            this.pnlTranTop.Size = new System.Drawing.Size(742, 44);
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Controls.Add(this.spdModel);
            this.pnlTranCenter.Controls.Add(this.grpProgress);
            this.pnlTranCenter.Location = new System.Drawing.Point(0, 44);
            this.pnlTranCenter.Size = new System.Drawing.Size(742, 452);
            // 
            // grpTranTop
            // 
            this.grpTranTop.Controls.Add(this.lblModelFile);
            this.grpTranTop.Controls.Add(this.btnSaveResult);
            this.grpTranTop.Controls.Add(this.btnImport);
            this.grpTranTop.Controls.Add(this.btnOpenFile);
            this.grpTranTop.Controls.Add(this.txtModelFile);
            this.grpTranTop.Size = new System.Drawing.Size(736, 44);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(558, 16);
            this.btnProcess.TabIndex = 13;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(649, 16);
            this.btnClose.TabIndex = 14;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.grpModelItem);
            this.pnlBottom.Location = new System.Drawing.Point(0, 496);
            this.pnlBottom.Size = new System.Drawing.Size(742, 50);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            this.pnlBottom.Controls.SetChildIndex(this.grpModelItem, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 496);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblFormTitle.Text = "";
            // 
            // lblModelFile
            // 
            this.lblModelFile.AutoSize = true;
            this.lblModelFile.Location = new System.Drawing.Point(9, 20);
            this.lblModelFile.Name = "lblModelFile";
            this.lblModelFile.Size = new System.Drawing.Size(98, 13);
            this.lblModelFile.TabIndex = 1;
            this.lblModelFile.Text = "Modeling Excel File";
            // 
            // btnSaveResult
            // 
            this.btnSaveResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveResult.Location = new System.Drawing.Point(642, 13);
            this.btnSaveResult.Name = "btnSaveResult";
            this.btnSaveResult.Size = new System.Drawing.Size(88, 26);
            this.btnSaveResult.TabIndex = 5;
            this.btnSaveResult.Text = "Save Result";
            this.btnSaveResult.UseVisualStyleBackColor = true;
            this.btnSaveResult.Click += new System.EventHandler(this.btnSaveResult_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(551, 13);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(88, 26);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.Location = new System.Drawing.Point(514, 15);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(24, 21);
            this.btnOpenFile.TabIndex = 3;
            this.btnOpenFile.Text = "...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // txtModelFile
            // 
            this.txtModelFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModelFile.Location = new System.Drawing.Point(115, 16);
            this.txtModelFile.Name = "txtModelFile";
            this.txtModelFile.Size = new System.Drawing.Size(398, 20);
            this.txtModelFile.TabIndex = 2;
            // 
            // spdModel
            // 
            this.spdModel.AccessibleDescription = "spdModel, Sheet1, Row 0, Column 0, ";
            this.spdModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdModel.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdModel.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdModel.HorizontalScrollBar.Name = "";
            this.spdModel.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdModel.HorizontalScrollBar.TabIndex = 0;
            this.spdModel.Location = new System.Drawing.Point(3, 3);
            this.spdModel.Name = "spdModel";
            this.spdModel.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdModel.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdModel.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdModel_Sheet1});
            this.spdModel.Size = new System.Drawing.Size(736, 409);
            this.spdModel.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdModel.TabIndex = 6;
            this.spdModel.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdModel.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdModel.VerticalScrollBar.Name = "";
            this.spdModel.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdModel.VerticalScrollBar.TabIndex = 1;
            this.spdModel.ActiveSheetChanged += new System.EventHandler(this.spdModel_ActiveSheetChanged);
            // 
            // spdModel_Sheet1
            // 
            this.spdModel_Sheet1.Reset();
            spdModel_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdModel_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spdModel_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdModel_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdModel_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdModel_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdModel_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdModel_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdModel_Sheet1.ColumnHeader.Visible = false;
            this.spdModel_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdModel_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdModel_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdModel_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdModel_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdModel_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpModelItem
            // 
            this.grpModelItem.Controls.Add(this.chkAll);
            this.grpModelItem.Controls.Add(this.btnValHead);
            this.grpModelItem.Controls.Add(this.cboModelItem);
            this.grpModelItem.Controls.Add(this.lblModelItem);
            this.grpModelItem.Controls.Add(this.btnValValue);
            this.grpModelItem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpModelItem.Location = new System.Drawing.Point(0, 3);
            this.grpModelItem.Name = "grpModelItem";
            this.grpModelItem.Size = new System.Drawing.Size(742, 47);
            this.grpModelItem.TabIndex = 3;
            this.grpModelItem.TabStop = false;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Checked = true;
            this.chkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAll.Location = new System.Drawing.Point(15, 18);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(78, 16);
            this.chkAll.TabIndex = 7;
            this.chkAll.Text = "All Check";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkSelect_CheckedChanged);
            // 
            // btnValHead
            // 
            this.btnValHead.Location = new System.Drawing.Point(322, 13);
            this.btnValHead.Name = "btnValHead";
            this.btnValHead.Size = new System.Drawing.Size(105, 26);
            this.btnValHead.TabIndex = 11;
            this.btnValHead.Text = "Validation Header";
            this.btnValHead.UseVisualStyleBackColor = true;
            this.btnValHead.Click += new System.EventHandler(this.btnValHead_Click);
            // 
            // cboModelItem
            // 
            this.cboModelItem.FormattingEnabled = true;
            this.cboModelItem.Items.AddRange(new object[] {
            "Operation",
            "Material",
            "Flow",
            "Resource",
            "User",
            "GCM Table",
            "GCM Data"});
            this.cboModelItem.Location = new System.Drawing.Point(197, 16);
            this.cboModelItem.Name = "cboModelItem";
            this.cboModelItem.Size = new System.Drawing.Size(119, 21);
            this.cboModelItem.TabIndex = 10;
            this.cboModelItem.SelectedIndexChanged += new System.EventHandler(this.cboModelItem_SelectedIndexChanged);
            // 
            // lblModelItem
            // 
            this.lblModelItem.AutoSize = true;
            this.lblModelItem.Location = new System.Drawing.Point(125, 20);
            this.lblModelItem.Name = "lblModelItem";
            this.lblModelItem.Size = new System.Drawing.Size(59, 13);
            this.lblModelItem.TabIndex = 9;
            this.lblModelItem.Text = "Model Item";
            // 
            // btnValValue
            // 
            this.btnValValue.Location = new System.Drawing.Point(435, 13);
            this.btnValValue.Name = "btnValValue";
            this.btnValValue.Size = new System.Drawing.Size(105, 26);
            this.btnValValue.TabIndex = 12;
            this.btnValValue.Text = "Validation Value";
            this.btnValValue.UseVisualStyleBackColor = true;
            this.btnValValue.Click += new System.EventHandler(this.btnValValue_Click);
            // 
            // grpProgress
            // 
            this.grpProgress.Controls.Add(this.btnCancel);
            this.grpProgress.Controls.Add(this.lblErrCnt);
            this.grpProgress.Controls.Add(this.lblErr);
            this.grpProgress.Controls.Add(this.lblOkCnt);
            this.grpProgress.Controls.Add(this.lblOk);
            this.grpProgress.Controls.Add(this.lblTotalCnt);
            this.grpProgress.Controls.Add(this.lblPercent);
            this.grpProgress.Controls.Add(this.prgBar);
            this.grpProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpProgress.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpProgress.Location = new System.Drawing.Point(3, 412);
            this.grpProgress.Name = "grpProgress";
            this.grpProgress.Size = new System.Drawing.Size(736, 40);
            this.grpProgress.TabIndex = 7;
            this.grpProgress.TabStop = false;
            this.grpProgress.Text = "Progress";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Enabled = false;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(661, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 24);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblErrCnt
            // 
            this.lblErrCnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErrCnt.AutoSize = true;
            this.lblErrCnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrCnt.ForeColor = System.Drawing.Color.Red;
            this.lblErrCnt.Location = new System.Drawing.Point(597, 16);
            this.lblErrCnt.Name = "lblErrCnt";
            this.lblErrCnt.Size = new System.Drawing.Size(15, 15);
            this.lblErrCnt.TabIndex = 34;
            this.lblErrCnt.Text = "4";
            this.lblErrCnt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblErr
            // 
            this.lblErr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErr.AutoSize = true;
            this.lblErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErr.ForeColor = System.Drawing.Color.Red;
            this.lblErr.Location = new System.Drawing.Point(534, 16);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(63, 15);
            this.lblErr.TabIndex = 33;
            this.lblErr.Text = "FAILURE :";
            // 
            // lblOkCnt
            // 
            this.lblOkCnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOkCnt.AutoSize = true;
            this.lblOkCnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOkCnt.ForeColor = System.Drawing.Color.Green;
            this.lblOkCnt.Location = new System.Drawing.Point(473, 16);
            this.lblOkCnt.Name = "lblOkCnt";
            this.lblOkCnt.Size = new System.Drawing.Size(23, 15);
            this.lblOkCnt.TabIndex = 32;
            this.lblOkCnt.Text = "20";
            this.lblOkCnt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOk
            // 
            this.lblOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOk.AutoSize = true;
            this.lblOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOk.ForeColor = System.Drawing.Color.Green;
            this.lblOk.Location = new System.Drawing.Point(403, 16);
            this.lblOk.Name = "lblOk";
            this.lblOk.Size = new System.Drawing.Size(70, 15);
            this.lblOk.TabIndex = 31;
            this.lblOk.Text = "SUCCESS :";
            // 
            // lblTotalCnt
            // 
            this.lblTotalCnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCnt.AutoSize = true;
            this.lblTotalCnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCnt.Location = new System.Drawing.Point(328, 16);
            this.lblTotalCnt.Name = "lblTotalCnt";
            this.lblTotalCnt.Size = new System.Drawing.Size(38, 15);
            this.lblTotalCnt.TabIndex = 30;
            this.lblTotalCnt.Text = "24/30";
            this.lblTotalCnt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPercent
            // 
            this.lblPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercent.Location = new System.Drawing.Point(273, 16);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(40, 15);
            this.lblPercent.TabIndex = 29;
            this.lblPercent.Text = "(87%)";
            this.lblPercent.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // prgBar
            // 
            this.prgBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.prgBar.Location = new System.Drawing.Point(9, 15);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(258, 21);
            this.prgBar.TabIndex = 22;
            this.prgBar.Value = 87;
            // 
            // frmBASSetupDataByImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmBASSetupDataByImport";
            this.Text = "Modeling Data Import from Excel";
            this.Load += new System.EventHandler(this.frmBASSetupDataByImport_Load);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdModel_Sheet1)).EndInit();
            this.grpModelItem.ResumeLayout(false);
            this.grpModelItem.PerformLayout();
            this.grpProgress.ResumeLayout(false);
            this.grpProgress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblModelFile;
        private System.Windows.Forms.Button btnSaveResult;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox txtModelFile;
        private FarPoint.Win.Spread.FpSpread spdModel;
        private FarPoint.Win.Spread.SheetView spdModel_Sheet1;
        private System.Windows.Forms.GroupBox grpModelItem;
        private System.Windows.Forms.Button btnValHead;
        private System.Windows.Forms.ComboBox cboModelItem;
        private System.Windows.Forms.Label lblModelItem;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnValValue;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.SaveFileDialog sfdFile;
        private System.Windows.Forms.GroupBox grpProgress;
        private System.Windows.Forms.ProgressBar prgBar;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Label lblTotalCnt;
        private System.Windows.Forms.Label lblErrCnt;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.Label lblOkCnt;
        private System.Windows.Forms.Label lblOk;
        private System.Windows.Forms.Button btnCancel;




    }
}