namespace Miracom.BASCore
{
    partial class frmBASTranAnswerfortheChecklistPopUp
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
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.lblLot = new System.Windows.Forms.Label();
            this.lblRes = new System.Windows.Forms.Label();
            this.txtLot = new System.Windows.Forms.TextBox();
            this.txtResource = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.pnlAnswer.SuspendLayout();
            this.grpQueryAnswer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdQueryAnswer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdQueryAnswer_Sheet1)).BeginInit();
            this.pnlCheckListInfo.SuspendLayout();
            this.grpCheckListHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChecklistID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChecklistType)).BeginInit();
            this.grpKeyValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdKeyPrompt)).BeginInit();
            this.pnlPeriod.SuspendLayout();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAnswer
            // 
            this.pnlAnswer.Location = new System.Drawing.Point(0, 152);
            this.pnlAnswer.Size = new System.Drawing.Size(742, 272);
            // 
            // grpQueryAnswer
            // 
            this.grpQueryAnswer.Size = new System.Drawing.Size(742, 272);
            // 
            // spdQueryAnswer
            // 
            this.spdQueryAnswer.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdQueryAnswer.HorizontalScrollBar.Name = "";
            this.spdQueryAnswer.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdQueryAnswer.HorizontalScrollBar.TabIndex = 12;
            this.spdQueryAnswer.Size = new System.Drawing.Size(736, 253);
            this.spdQueryAnswer.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdQueryAnswer.VerticalScrollBar.Name = "";
            this.spdQueryAnswer.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdQueryAnswer.VerticalScrollBar.TabIndex = 13;
            // 
            // spdQueryAnswer_Sheet1
            // 
            spdQueryAnswer_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdQueryAnswer_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdQueryAnswer_Sheet1.ColumnCount = 6;
            spdQueryAnswer_Sheet1.RowCount = 1;
            this.spdQueryAnswer_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQueryAnswer_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdQueryAnswer_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQueryAnswer_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdQueryAnswer_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = " ";
            this.spdQueryAnswer_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Seq";
            this.spdQueryAnswer_Sheet1.ColumnHeader.Cells.Get(0, 2).Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.spdQueryAnswer_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "ID";
            this.spdQueryAnswer_Sheet1.ColumnHeader.Cells.Get(0, 3).Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.spdQueryAnswer_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Query";
            this.spdQueryAnswer_Sheet1.ColumnHeader.Cells.Get(0, 4).ColumnSpan = 2;
            this.spdQueryAnswer_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Answer";
            this.spdQueryAnswer_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQueryAnswer_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdQueryAnswer_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdQueryAnswer_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQueryAnswer_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdQueryAnswer_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQueryAnswer_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdQueryAnswer_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlCheckListInfo
            // 
            this.pnlCheckListInfo.Size = new System.Drawing.Size(742, 149);
            // 
            // cdvChecklistID
            // 
            this.cdvChecklistID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChecklistID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChecklistID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChecklistID_SelectedItemChanged);
            // 
            // cdvChecklistType
            // 
            this.cdvChecklistType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChecklistType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(0, 149);
            // 
            // grpKeyValue
            // 
            this.grpKeyValue.Location = new System.Drawing.Point(0, 0);
            this.grpKeyValue.Size = new System.Drawing.Size(742, 149);
            // 
            // spdKeyPrompt
            // 
            this.spdKeyPrompt.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdKeyPrompt.HorizontalScrollBar.Name = "";
            this.spdKeyPrompt.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdKeyPrompt.HorizontalScrollBar.TabIndex = 28;
            this.spdKeyPrompt.Size = new System.Drawing.Size(736, 130);
            this.spdKeyPrompt.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdKeyPrompt.VerticalScrollBar.Name = "";
            this.spdKeyPrompt.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdKeyPrompt.VerticalScrollBar.TabIndex = 29;
            // 
            // btnDelete
            // 
            this.btnDelete.Visible = false;
            // 
            // chkIncludeDelHistory
            // 
            this.chkIncludeDelHistory.Visible = false;
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Visible = false;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.txtResource);
            this.grpOption.Controls.Add(this.txtLot);
            this.grpOption.Controls.Add(this.lblRes);
            this.grpOption.Controls.Add(this.lblLot);
            this.grpOption.Controls.SetChildIndex(this.pnlPeriod, 0);
            this.grpOption.Controls.SetChildIndex(this.chkIncludeDelHistory, 0);
            this.grpOption.Controls.SetChildIndex(this.lblChecklistType, 0);
            this.grpOption.Controls.SetChildIndex(this.cdvChecklistType, 0);
            this.grpOption.Controls.SetChildIndex(this.lblChecklistID, 0);
            this.grpOption.Controls.SetChildIndex(this.cdvChecklistID, 0);
            this.grpOption.Controls.SetChildIndex(this.lblDescription, 0);
            this.grpOption.Controls.SetChildIndex(this.txtDesc, 0);
            this.grpOption.Controls.SetChildIndex(this.lblLot, 0);
            this.grpOption.Controls.SetChildIndex(this.lblRes, 0);
            this.grpOption.Controls.SetChildIndex(this.txtLot, 0);
            this.grpOption.Controls.SetChildIndex(this.txtResource, 0);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnStop);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.chkCompleteFlag, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnStop, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Answer for the Checklist";
            // 
            // lblLot
            // 
            this.lblLot.AutoSize = true;
            this.lblLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblLot.Location = new System.Drawing.Point(419, 16);
            this.lblLot.Name = "lblLot";
            this.lblLot.Size = new System.Drawing.Size(36, 13);
            this.lblLot.TabIndex = 15;
            this.lblLot.Text = "Lot ID";
            this.lblLot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRes
            // 
            this.lblRes.AutoSize = true;
            this.lblRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblRes.Location = new System.Drawing.Point(419, 39);
            this.lblRes.Name = "lblRes";
            this.lblRes.Size = new System.Drawing.Size(53, 13);
            this.lblRes.TabIndex = 17;
            this.lblRes.Text = "Resource";
            this.lblRes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLot
            // 
            this.txtLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLot.Location = new System.Drawing.Point(530, 12);
            this.txtLot.MaxLength = 200;
            this.txtLot.Name = "txtLot";
            this.txtLot.Size = new System.Drawing.Size(200, 20);
            this.txtLot.TabIndex = 18;
            // 
            // txtResource
            // 
            this.txtResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResource.Location = new System.Drawing.Point(530, 38);
            this.txtResource.MaxLength = 200;
            this.txtResource.Name = "txtResource";
            this.txtResource.Size = new System.Drawing.Size(200, 20);
            this.txtResource.TabIndex = 19;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStop.Location = new System.Drawing.Point(555, 8);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(88, 26);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // frmBASTranAnswerfortheChecklistPopUp
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmBASTranAnswerfortheChecklistPopUp";
            this.Text = "Answer to the Checklist";
            this.VisibleHistory = false;
            this.pnlAnswer.ResumeLayout(false);
            this.grpQueryAnswer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdQueryAnswer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdQueryAnswer_Sheet1)).EndInit();
            this.pnlCheckListInfo.ResumeLayout(false);
            this.grpCheckListHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvChecklistID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChecklistType)).EndInit();
            this.grpKeyValue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdKeyPrompt)).EndInit();
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lblRes;
        protected System.Windows.Forms.Label lblLot;
        protected System.Windows.Forms.TextBox txtResource;
        protected System.Windows.Forms.TextBox txtLot;
        protected System.Windows.Forms.Button btnStop;
    }
}