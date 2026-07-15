namespace Miracom.WEMCore.Setup
{
    partial class udcStepActionToolEvent
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
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder2 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder1 = new FarPoint.Win.CompoundBorder(bevelBorder1, bevelBorder2);
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.pnlActionMid = new System.Windows.Forms.Panel();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlActionTop = new System.Windows.Forms.Panel();
            this.cdvToolID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblToolID = new System.Windows.Forms.Label();
            this.cdvToolType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblToolType = new System.Windows.Forms.Label();
            this.cdvToolEventID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblEvent = new System.Windows.Forms.Label();
            this.cdvData = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.grpActionValue.SuspendLayout();
            this.pnlActionMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.pnlActionTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolEventID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvData)).BeginInit();
            this.SuspendLayout();
            // 
            // grpActionValue
            // 
            this.grpActionValue.Controls.Add(this.pnlActionMid);
            this.grpActionValue.Controls.Add(this.pnlActionTop);
            // 
            // pnlActionMid
            // 
            this.pnlActionMid.Controls.Add(this.spdData);
            this.pnlActionMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActionMid.Location = new System.Drawing.Point(3, 91);
            this.pnlActionMid.Name = "pnlActionMid";
            this.pnlActionMid.Size = new System.Drawing.Size(234, 223);
            this.pnlActionMid.TabIndex = 1;
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, LotInfo, Row 0, Column 0, Tool Group";
            this.spdData.BackColor = System.Drawing.SystemColors.Control;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 18;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdData.Location = new System.Drawing.Point(0, 0);
            this.spdData.MoveActiveOnFocus = false;
            this.spdData.Name = "spdData";
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(234, 223);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 0;
            this.spdData.TabStop = false;
            this.spdData.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.toolTip.SetToolTip(this.spdData, "Each Change Status allow input Fixed Value or Status Name of Work process event a" +
        "s \'$LOT_ID\'");
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 19;
            this.spdData.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdData_ButtonClicked);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "LotInfo";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 3;
            spdData_Sheet1.RowCount = 17;
            this.spdData_Sheet1.Cells.Get(0, 0).Value = "Tool Group";
            this.spdData_Sheet1.Cells.Get(1, 0).Value = "Tool Set ID";
            this.spdData_Sheet1.Cells.Get(2, 0).Value = "Tool Set Location";
            this.spdData_Sheet1.Cells.Get(3, 0).Value = "Tool Status";
            this.spdData_Sheet1.Cells.Get(4, 0).Value = "Lot ID";
            this.spdData_Sheet1.Cells.Get(5, 0).Value = "Sublot ID";
            this.spdData_Sheet1.Cells.Get(6, 0).Value = "Resource ID";
            this.spdData_Sheet1.Cells.Get(7, 0).Value = "Sub Resource ID";
            this.spdData_Sheet1.Cells.Get(8, 0).Value = "Area ID";
            this.spdData_Sheet1.Cells.Get(9, 0).Value = "Sub Area ID";
            this.spdData_Sheet1.Cells.Get(10, 0).Value = "Tool Location";
            this.spdData_Sheet1.Cells.Get(11, 0).Value = "Vendor ID";
            this.spdData_Sheet1.Cells.Get(12, 0).Value = "Material ID";
            this.spdData_Sheet1.Cells.Get(13, 0).Value = "Material Version";
            this.spdData_Sheet1.Cells.Get(14, 0).Value = "Flow";
            this.spdData_Sheet1.Cells.Get(15, 0).Value = "Operation";
            this.spdData_Sheet1.Cells.Get(16, 0).Value = "Grade";
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Tool Articles";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).ColumnSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Change Status";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdData_Sheet1.Columns.Get(0).Border = compoundBorder1;
            this.spdData_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.spdData_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdData_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(0).Label = "Tool Articles";
            this.spdData_Sheet1.Columns.Get(0).Locked = false;
            this.spdData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Width = 100F;
            this.spdData_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(1).Label = "Change Status";
            this.spdData_Sheet1.Columns.Get(1).Locked = false;
            this.spdData_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Width = 93F;
            this.spdData_Sheet1.Columns.Get(2).Resizable = false;
            this.spdData_Sheet1.Columns.Get(2).Width = 20F;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.RowHeader.Visible = false;
            this.spdData_Sheet1.Rows.Default.Height = 17F;
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlActionTop
            // 
            this.pnlActionTop.Controls.Add(this.cdvToolID);
            this.pnlActionTop.Controls.Add(this.lblToolID);
            this.pnlActionTop.Controls.Add(this.cdvToolType);
            this.pnlActionTop.Controls.Add(this.lblToolType);
            this.pnlActionTop.Controls.Add(this.cdvToolEventID);
            this.pnlActionTop.Controls.Add(this.lblEvent);
            this.pnlActionTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActionTop.Location = new System.Drawing.Point(3, 16);
            this.pnlActionTop.Name = "pnlActionTop";
            this.pnlActionTop.Size = new System.Drawing.Size(234, 75);
            this.pnlActionTop.TabIndex = 0;
            // 
            // cdvToolID
            // 
            this.cdvToolID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToolID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToolID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToolID.BtnToolTipText = "";
            this.cdvToolID.DescText = "";
            this.cdvToolID.DisplaySubItemIndex = -1;
            this.cdvToolID.DisplayText = "";
            this.cdvToolID.Focusing = null;
            this.cdvToolID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToolID.Index = 0;
            this.cdvToolID.IsViewBtnImage = false;
            this.cdvToolID.Location = new System.Drawing.Point(97, 50);
            this.cdvToolID.MaxLength = 30;
            this.cdvToolID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToolID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToolID.Name = "cdvToolID";
            this.cdvToolID.ReadOnly = false;
            this.cdvToolID.SearchSubItemIndex = 0;
            this.cdvToolID.SelectedDescIndex = -1;
            this.cdvToolID.SelectedSubItemIndex = -1;
            this.cdvToolID.SelectionStart = 0;
            this.cdvToolID.Size = new System.Drawing.Size(134, 20);
            this.cdvToolID.SmallImageList = null;
            this.cdvToolID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToolID.TabIndex = 5;
            this.cdvToolID.TextBoxToolTipText = "It allow input Empty or Status Name of Work process event as \'$TOOL_ID\'";
            this.cdvToolID.TextBoxWidth = 134;
            this.cdvToolID.VisibleButton = true;
            this.cdvToolID.VisibleColumnHeader = false;
            this.cdvToolID.VisibleDescription = false;
            this.cdvToolID.ButtonPress += new System.EventHandler(this.cdvToolID_ButtonPress);
            // 
            // lblToolID
            // 
            this.lblToolID.AutoSize = true;
            this.lblToolID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblToolID.Location = new System.Drawing.Point(3, 54);
            this.lblToolID.Name = "lblToolID";
            this.lblToolID.Size = new System.Drawing.Size(42, 13);
            this.lblToolID.TabIndex = 4;
            this.lblToolID.Text = "Tool ID";
            // 
            // cdvToolType
            // 
            this.cdvToolType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvToolType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToolType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToolType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToolType.BtnToolTipText = "";
            this.cdvToolType.DescText = "";
            this.cdvToolType.DisplaySubItemIndex = -1;
            this.cdvToolType.DisplayText = "";
            this.cdvToolType.Focusing = null;
            this.cdvToolType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToolType.Index = 0;
            this.cdvToolType.IsViewBtnImage = false;
            this.cdvToolType.Location = new System.Drawing.Point(97, 2);
            this.cdvToolType.MaxLength = 20;
            this.cdvToolType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToolType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToolType.Name = "cdvToolType";
            this.cdvToolType.ReadOnly = true;
            this.cdvToolType.SearchSubItemIndex = 0;
            this.cdvToolType.SelectedDescIndex = -1;
            this.cdvToolType.SelectedSubItemIndex = -1;
            this.cdvToolType.SelectionStart = 0;
            this.cdvToolType.Size = new System.Drawing.Size(134, 20);
            this.cdvToolType.SmallImageList = null;
            this.cdvToolType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToolType.TabIndex = 1;
            this.cdvToolType.TextBoxToolTipText = "";
            this.cdvToolType.TextBoxWidth = 134;
            this.cdvToolType.VisibleButton = true;
            this.cdvToolType.VisibleColumnHeader = false;
            this.cdvToolType.VisibleDescription = true;
            this.cdvToolType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToolType_SelectedItemChanged);
            this.cdvToolType.ButtonPress += new System.EventHandler(this.cdvToolType_ButtonPress);
            // 
            // lblToolType
            // 
            this.lblToolType.AutoSize = true;
            this.lblToolType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblToolType.Location = new System.Drawing.Point(3, 6);
            this.lblToolType.Name = "lblToolType";
            this.lblToolType.Size = new System.Drawing.Size(64, 13);
            this.lblToolType.TabIndex = 0;
            this.lblToolType.Text = "Tool Type";
            // 
            // cdvToolEventID
            // 
            this.cdvToolEventID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvToolEventID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToolEventID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToolEventID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToolEventID.BtnToolTipText = "";
            this.cdvToolEventID.DescText = "";
            this.cdvToolEventID.DisplaySubItemIndex = -1;
            this.cdvToolEventID.DisplayText = "";
            this.cdvToolEventID.Focusing = null;
            this.cdvToolEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToolEventID.Index = 0;
            this.cdvToolEventID.IsViewBtnImage = false;
            this.cdvToolEventID.Location = new System.Drawing.Point(97, 26);
            this.cdvToolEventID.MaxLength = 12;
            this.cdvToolEventID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToolEventID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToolEventID.Name = "cdvToolEventID";
            this.cdvToolEventID.ReadOnly = true;
            this.cdvToolEventID.SearchSubItemIndex = 0;
            this.cdvToolEventID.SelectedDescIndex = -1;
            this.cdvToolEventID.SelectedSubItemIndex = -1;
            this.cdvToolEventID.SelectionStart = 0;
            this.cdvToolEventID.Size = new System.Drawing.Size(134, 20);
            this.cdvToolEventID.SmallImageList = null;
            this.cdvToolEventID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToolEventID.TabIndex = 3;
            this.cdvToolEventID.TextBoxToolTipText = "";
            this.cdvToolEventID.TextBoxWidth = 134;
            this.cdvToolEventID.VisibleButton = true;
            this.cdvToolEventID.VisibleColumnHeader = false;
            this.cdvToolEventID.VisibleDescription = true;
            this.cdvToolEventID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToolEventID_SelectedItemChanged);
            this.cdvToolEventID.ButtonPress += new System.EventHandler(this.cdvToolEventID_ButtonPress);
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEvent.Location = new System.Drawing.Point(3, 30);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(69, 13);
            this.lblEvent.TabIndex = 2;
            this.lblEvent.Text = "Tool Event";
            // 
            // cdvData
            // 
            this.cdvData.BackColor = System.Drawing.Color.PaleTurquoise;
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
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            // 
            // udcStepActionToolEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "udcStepActionToolEvent";
            this.grpActionValue.ResumeLayout(false);
            this.pnlActionMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.pnlActionTop.ResumeLayout(false);
            this.pnlActionTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolEventID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlActionMid;
        protected FarPoint.Win.Spread.FpSpread spdData;
        protected FarPoint.Win.Spread.SheetView spdData_Sheet1;
        private System.Windows.Forms.Panel pnlActionTop;
        private UI.Controls.MCCodeView.MCCodeView cdvToolEventID;
        private System.Windows.Forms.Label lblEvent;
        private UI.Controls.MCCodeView.MCCodeView cdvToolType;
        private System.Windows.Forms.Label lblToolType;
        private UI.Controls.MCCodeView.MCSPCodeView cdvData;
        private System.Windows.Forms.ToolTip toolTip;
        private UI.Controls.MCCodeView.MCCodeView cdvToolID;
        private System.Windows.Forms.Label lblToolID;
    }
}
