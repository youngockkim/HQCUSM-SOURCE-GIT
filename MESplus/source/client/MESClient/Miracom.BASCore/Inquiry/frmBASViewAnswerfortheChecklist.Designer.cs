namespace Miracom.BASCore
{
    partial class frmBASViewAnswerfortheChecklist
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
            // chkCompleteFlag
            // 
            this.chkCompleteFlag.Visible = false;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(367, 7);
            this.btnProcess.Visible = false;
            // 
            // spdQueryAnswer
            // 
            this.spdQueryAnswer.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdQueryAnswer.HorizontalScrollBar.Name = "";
            this.spdQueryAnswer.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdQueryAnswer.HorizontalScrollBar.TabIndex = 12;
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
            // cdvChecklistID
            // 
            this.cdvChecklistID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChecklistID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvChecklistType
            // 
            this.cdvChecklistType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChecklistType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // spdKeyPrompt
            // 
            this.spdKeyPrompt.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdKeyPrompt.HorizontalScrollBar.Name = "";
            this.spdKeyPrompt.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdKeyPrompt.HorizontalScrollBar.TabIndex = 28;
            this.spdKeyPrompt.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdKeyPrompt.VerticalScrollBar.Name = "";
            this.spdKeyPrompt.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdKeyPrompt.VerticalScrollBar.TabIndex = 29;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(461, 7);
            this.btnDelete.Visible = false;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(555, 7);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Answer for the Checklist";
            // 
            // frmBASViewAnswerfortheChecklist
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmBASViewAnswerfortheChecklist";
            this.Text = "View Answer of Checklist";
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

    }
}