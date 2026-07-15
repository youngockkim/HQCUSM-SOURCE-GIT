namespace Miracom.WEMCore.Setup
{
    partial class udcStepActionChangeStatusValue
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            this.cdvData = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.spdStatus = new FarPoint.Win.Spread.FpSpread();
            this.spdStatus_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grpActionValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdStatus_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpActionValue
            // 
            this.grpActionValue.Controls.Add(this.spdStatus);
            // 
            // cdvData
            // 
            this.cdvData.BackColor = System.Drawing.SystemColors.Control;
            this.cdvData.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvData.BorderHotColor = System.Drawing.Color.Black;
            this.cdvData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvData.Location = new System.Drawing.Point(0, 0);
            this.cdvData.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvData.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvData.Name = "MCSPCodeView";
            this.cdvData.Size = new System.Drawing.Size(20, 20);
            this.cdvData.SmallImageList = null;
            this.cdvData.TabIndex = 0;
            this.cdvData.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvData.VisibleColumnHeader = false;
            this.cdvData.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvData_SelectedItemChanged);
            // 
            // spdStatus
            // 
            this.spdStatus.AccessibleDescription = "spdStatus, Sheet1, Row 0, Column 0, ";
            this.spdStatus.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
            this.spdStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdStatus.EditModePermanent = true;
            this.spdStatus.EditModeReplace = true;
            this.spdStatus.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdStatus.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdStatus.HorizontalScrollBar.Name = "";
            this.spdStatus.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdStatus.HorizontalScrollBar.TabIndex = 10;
            this.spdStatus.Location = new System.Drawing.Point(3, 16);
            this.spdStatus.Name = "spdStatus";
            this.spdStatus.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdStatus.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdStatus.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdStatus_Sheet1});
            this.spdStatus.Size = new System.Drawing.Size(234, 298);
            this.spdStatus.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdStatus.TabIndex = 0;
            this.spdStatus.TextTipDelay = 200;
            this.spdStatus.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdStatus.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdStatus.VerticalScrollBar.Name = "";
            this.spdStatus.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdStatus.VerticalScrollBar.TabIndex = 11;
            this.spdStatus.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdStatus_ButtonClicked);
            this.spdStatus.ComboCloseUp += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdStatus_ComboCloseUp);
            // 
            // spdStatus_Sheet1
            // 
            this.spdStatus_Sheet1.Reset();
            spdStatus_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdStatus_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdStatus_Sheet1.ColumnCount = 4;
            spdStatus_Sheet1.RowCount = 30;
            this.spdStatus_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdStatus_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdStatus_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdStatus_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdStatus_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Status";
            this.spdStatus_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Change Flag";
            this.spdStatus_Sheet1.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 2;
            this.spdStatus_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Value";
            this.spdStatus_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdStatus_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            this.spdStatus_Sheet1.Columns.Get(0).CellType = comboBoxCellType1;
            this.spdStatus_Sheet1.Columns.Get(0).Label = "Status";
            this.spdStatus_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdStatus_Sheet1.Columns.Get(0).Width = 110F;
            comboBoxCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType2.Items = new string[] {
        "",
        "Y (Change)",
        "+ (Increase)",
        "- (Decrease)",
        "T (Time)",
        "R (Reset)"};
            this.spdStatus_Sheet1.Columns.Get(1).CellType = comboBoxCellType2;
            this.spdStatus_Sheet1.Columns.Get(1).Label = "Change Flag";
            this.spdStatus_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdStatus_Sheet1.Columns.Get(1).Width = 70F;
            this.spdStatus_Sheet1.Columns.Get(2).Label = "Value";
            this.spdStatus_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdStatus_Sheet1.Columns.Get(2).Width = 90F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdStatus_Sheet1.Columns.Get(3).CellType = buttonCellType1;
            this.spdStatus_Sheet1.Columns.Get(3).Width = 20F;
            this.spdStatus_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.spdStatus_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdStatus_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdStatus_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdStatus_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdStatus_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdStatus_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // udcStepActionChangeStatusValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "udcStepActionChangeStatusValue";
            this.grpActionValue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdStatus_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.MCCodeView.MCSPCodeView cdvData;
        private FarPoint.Win.Spread.FpSpread spdStatus;
        private FarPoint.Win.Spread.SheetView spdStatus_Sheet1;
    }
}
