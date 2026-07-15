namespace Miracom.WEMCore
{
    partial class frmWEMTranDeleteProcessEventHistory
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
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            this.lblProcID = new System.Windows.Forms.Label();
            this.cdvProcID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblProcType = new System.Windows.Forms.Label();
            this.cdvProcType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblProcEventID = new System.Windows.Forms.Label();
            this.cdvProcEventID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.spdHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlComment = new System.Windows.Forms.Panel();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcEventID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).BeginInit();
            this.pnlComment.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlTranTop
            // 
            this.pnlTranTop.Size = new System.Drawing.Size(742, 94);
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Controls.Add(this.spdHistory);
            this.pnlTranCenter.Controls.Add(this.pnlComment);
            this.pnlTranCenter.Location = new System.Drawing.Point(0, 94);
            this.pnlTranCenter.Size = new System.Drawing.Size(742, 412);
            // 
            // grpTranTop
            // 
            this.grpTranTop.Controls.Add(this.lblProcEventID);
            this.grpTranTop.Controls.Add(this.cdvProcEventID);
            this.grpTranTop.Controls.Add(this.lblProcID);
            this.grpTranTop.Controls.Add(this.cdvProcID);
            this.grpTranTop.Controls.Add(this.lblProcType);
            this.grpTranTop.Controls.Add(this.cdvProcType);
            this.grpTranTop.Size = new System.Drawing.Size(736, 94);
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm02";
            // 
            // lblProcID
            // 
            this.lblProcID.AutoSize = true;
            this.lblProcID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcID.Location = new System.Drawing.Point(6, 44);
            this.lblProcID.Name = "lblProcID";
            this.lblProcID.Size = new System.Drawing.Size(69, 13);
            this.lblProcID.TabIndex = 6;
            this.lblProcID.Text = "Process ID";
            // 
            // cdvProcID
            // 
            this.cdvProcID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvProcID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvProcID.BtnToolTipText = "";
            this.cdvProcID.DescText = "";
            this.cdvProcID.DisplaySubItemIndex = -1;
            this.cdvProcID.DisplayText = "";
            this.cdvProcID.Focusing = null;
            this.cdvProcID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvProcID.Index = 0;
            this.cdvProcID.IsViewBtnImage = false;
            this.cdvProcID.Location = new System.Drawing.Point(140, 40);
            this.cdvProcID.MaxLength = 30;
            this.cdvProcID.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcID.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcID.Name = "cdvProcID";
            this.cdvProcID.ReadOnly = true;
            this.cdvProcID.SearchSubItemIndex = 0;
            this.cdvProcID.SelectedDescIndex = -1;
            this.cdvProcID.SelectedSubItemIndex = -1;
            this.cdvProcID.SelectionStart = 0;
            this.cdvProcID.Size = new System.Drawing.Size(590, 20);
            this.cdvProcID.SmallImageList = null;
            this.cdvProcID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvProcID.TabIndex = 7;
            this.cdvProcID.TextBoxToolTipText = "";
            this.cdvProcID.TextBoxWidth = 187;
            this.cdvProcID.VisibleButton = true;
            this.cdvProcID.VisibleColumnHeader = false;
            this.cdvProcID.VisibleDescription = true;
            this.cdvProcID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvProcID_SelectedItemChanged);
            this.cdvProcID.ButtonPress += new System.EventHandler(this.cdvProcID_ButtonPress);
            // 
            // lblProcType
            // 
            this.lblProcType.AutoSize = true;
            this.lblProcType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcType.Location = new System.Drawing.Point(6, 20);
            this.lblProcType.Name = "lblProcType";
            this.lblProcType.Size = new System.Drawing.Size(118, 13);
            this.lblProcType.TabIndex = 4;
            this.lblProcType.Text = "Work Process Type";
            // 
            // cdvProcType
            // 
            this.cdvProcType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvProcType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvProcType.BtnToolTipText = "";
            this.cdvProcType.DescText = "";
            this.cdvProcType.DisplaySubItemIndex = -1;
            this.cdvProcType.DisplayText = "";
            this.cdvProcType.Focusing = null;
            this.cdvProcType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvProcType.Index = 0;
            this.cdvProcType.IsViewBtnImage = false;
            this.cdvProcType.Location = new System.Drawing.Point(140, 16);
            this.cdvProcType.MaxLength = 30;
            this.cdvProcType.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcType.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcType.Name = "cdvProcType";
            this.cdvProcType.ReadOnly = true;
            this.cdvProcType.SearchSubItemIndex = 0;
            this.cdvProcType.SelectedDescIndex = -1;
            this.cdvProcType.SelectedSubItemIndex = -1;
            this.cdvProcType.SelectionStart = 0;
            this.cdvProcType.Size = new System.Drawing.Size(590, 20);
            this.cdvProcType.SmallImageList = null;
            this.cdvProcType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvProcType.TabIndex = 5;
            this.cdvProcType.TextBoxToolTipText = "";
            this.cdvProcType.TextBoxWidth = 187;
            this.cdvProcType.VisibleButton = true;
            this.cdvProcType.VisibleColumnHeader = false;
            this.cdvProcType.VisibleDescription = true;
            this.cdvProcType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvProcType_SelectedItemChanged);
            this.cdvProcType.ButtonPress += new System.EventHandler(this.cdvProcType_ButtonPress);
            // 
            // lblProcEventID
            // 
            this.lblProcEventID.AutoSize = true;
            this.lblProcEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcEventID.Location = new System.Drawing.Point(6, 68);
            this.lblProcEventID.Name = "lblProcEventID";
            this.lblProcEventID.Size = new System.Drawing.Size(106, 13);
            this.lblProcEventID.TabIndex = 8;
            this.lblProcEventID.Text = "Process Event ID";
            // 
            // cdvProcEventID
            // 
            this.cdvProcEventID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvProcEventID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcEventID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcEventID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvProcEventID.BtnToolTipText = "";
            this.cdvProcEventID.DescText = "";
            this.cdvProcEventID.DisplaySubItemIndex = -1;
            this.cdvProcEventID.DisplayText = "";
            this.cdvProcEventID.Focusing = null;
            this.cdvProcEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvProcEventID.Index = 0;
            this.cdvProcEventID.IsViewBtnImage = false;
            this.cdvProcEventID.Location = new System.Drawing.Point(140, 64);
            this.cdvProcEventID.MaxLength = 30;
            this.cdvProcEventID.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcEventID.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcEventID.Name = "cdvProcEventID";
            this.cdvProcEventID.ReadOnly = true;
            this.cdvProcEventID.SearchSubItemIndex = 0;
            this.cdvProcEventID.SelectedDescIndex = -1;
            this.cdvProcEventID.SelectedSubItemIndex = -1;
            this.cdvProcEventID.SelectionStart = 0;
            this.cdvProcEventID.Size = new System.Drawing.Size(590, 20);
            this.cdvProcEventID.SmallImageList = null;
            this.cdvProcEventID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvProcEventID.TabIndex = 9;
            this.cdvProcEventID.TextBoxToolTipText = "";
            this.cdvProcEventID.TextBoxWidth = 187;
            this.cdvProcEventID.VisibleButton = true;
            this.cdvProcEventID.VisibleColumnHeader = false;
            this.cdvProcEventID.VisibleDescription = true;
            this.cdvProcEventID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvProcEventID_SelectedItemChanged);
            this.cdvProcEventID.ButtonPress += new System.EventHandler(this.cdvProcEventID_ButtonPress);
            // 
            // spdHistory
            // 
            this.spdHistory.AccessibleDescription = "spdHistory, Sheet1, Row 0, Column 0, ";
            this.spdHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdHistory.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdHistory.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.HorizontalScrollBar.Name = "";
            this.spdHistory.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdHistory.HorizontalScrollBar.TabIndex = 6;
            this.spdHistory.Location = new System.Drawing.Point(3, 3);
            this.spdHistory.Name = "spdHistory";
            this.spdHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdHistory_Sheet1});
            this.spdHistory.Size = new System.Drawing.Size(736, 385);
            this.spdHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdHistory.TabIndex = 0;
            this.spdHistory.TextTipDelay = 200;
            this.spdHistory.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdHistory.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.VerticalScrollBar.Name = "";
            this.spdHistory.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdHistory.VerticalScrollBar.TabIndex = 7;
            this.spdHistory.SetViewportLeftColumn(0, 0, 5);
            this.spdHistory.SetActiveViewport(0, 0, -1);
            // 
            // spdHistory_Sheet1
            // 
            this.spdHistory_Sheet1.Reset();
            spdHistory_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdHistory_Sheet1.ColumnCount = 14;
            spdHistory_Sheet1.RowCount = 3;
            this.spdHistory_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Tran Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Step ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Proc Status";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Last Step ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Last Step Approver";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Last Step Finish Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Reserved Approver";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Reserved Approver Type";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Tran User ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Tran Comment";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Hist Del Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Hist Del User ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Hist Del Comment";
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory_Sheet1.Columns.Get(0).Border = bevelBorder1;
            this.spdHistory_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Label = "Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(0).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Width = 50F;
            this.spdHistory_Sheet1.Columns.Get(1).Label = "Tran Time";
            this.spdHistory_Sheet1.Columns.Get(1).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(1).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(2).Label = "Step ID";
            this.spdHistory_Sheet1.Columns.Get(2).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(2).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(3).Label = "Proc Status";
            this.spdHistory_Sheet1.Columns.Get(3).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(3).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(4).Label = "Last Step ID";
            this.spdHistory_Sheet1.Columns.Get(4).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(4).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(5).Label = "Last Step Approver";
            this.spdHistory_Sheet1.Columns.Get(5).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(5).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(6).Label = "Last Step Finish Time";
            this.spdHistory_Sheet1.Columns.Get(6).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(6).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(7).Label = "Reserved Approver";
            this.spdHistory_Sheet1.Columns.Get(7).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(7).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(8).Label = "Reserved Approver Type";
            this.spdHistory_Sheet1.Columns.Get(8).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(8).Width = 130F;
            this.spdHistory_Sheet1.Columns.Get(9).Label = "Tran User ID";
            this.spdHistory_Sheet1.Columns.Get(9).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(9).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(10).Label = "Tran Comment";
            this.spdHistory_Sheet1.Columns.Get(10).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(10).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(11).Label = "Hist Del Time";
            this.spdHistory_Sheet1.Columns.Get(11).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(11).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(12).Label = "Hist Del User ID";
            this.spdHistory_Sheet1.Columns.Get(12).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(12).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(13).Label = "Hist Del Comment";
            this.spdHistory_Sheet1.Columns.Get(13).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(13).Width = 120F;
            this.spdHistory_Sheet1.FrozenColumnCount = 5;
            this.spdHistory_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdHistory_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.spdHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdHistory_Sheet1.RowHeader.Visible = false;
            this.spdHistory_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlComment
            // 
            this.pnlComment.Controls.Add(this.txtComment);
            this.pnlComment.Controls.Add(this.lblComment);
            this.pnlComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlComment.Location = new System.Drawing.Point(3, 388);
            this.pnlComment.Name = "pnlComment";
            this.pnlComment.Size = new System.Drawing.Size(736, 24);
            this.pnlComment.TabIndex = 6;
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(70, 3);
            this.txtComment.MaxLength = 400;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(663, 20);
            this.txtComment.TabIndex = 1;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(6, 6);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "Comment";
            // 
            // frmWEMTranDeleteProcessEventHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWEMTranDeleteProcessEventHistory";
            this.Text = "Delete Process Event History";
            this.Activated += new System.EventHandler(this.frmWEMTranDeleteProcessEventHistory_Activated);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcEventID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).EndInit();
            this.pnlComment.ResumeLayout(false);
            this.pnlComment.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread spdHistory;
        private FarPoint.Win.Spread.SheetView spdHistory_Sheet1;
        private System.Windows.Forms.Label lblProcEventID;
        private UI.Controls.MCCodeView.MCCodeView cdvProcEventID;
        private System.Windows.Forms.Label lblProcID;
        private UI.Controls.MCCodeView.MCCodeView cdvProcID;
        private System.Windows.Forms.Label lblProcType;
        private UI.Controls.MCCodeView.MCCodeView cdvProcType;
        private System.Windows.Forms.Panel pnlComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lblComment;
    }
}