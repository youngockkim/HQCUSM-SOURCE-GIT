namespace SOI.OIFrx.SOIPopup
{
    partial class frmStdOperSelectPopup
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("chk", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("seq", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("fileType", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("fileId", 3);
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            this.gridData = new SOI.OIFrx.SOIControls.SOIGrid(this.components);
            this.btnOk = new SOI.OIFrx.SOIControls.SOIButton(this.components);
            this.pnlPopupTop.SuspendLayout();
            this.pnlPopupBottom.SuspendLayout();
            this.pnlPopupMiddle.SuspendLayout();
            this.pnlPopupTopMargin.SuspendLayout();
            this.pnlPopupBottomMargin.SuspendLayout();
            this.pnlPopupMiddleMargin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPopupTop
            // 
            this.pnlPopupTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            // 
            // pnlPopupBottom
            // 
            this.pnlPopupBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            // 
            // btnClose
            // 
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlPopupMiddle
            // 
            this.pnlPopupMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            // 
            // pnlPopupBottomMargin
            // 
            this.pnlPopupBottomMargin.Controls.Add(this.btnOk);
            this.pnlPopupBottomMargin.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlPopupBottomMargin.Controls.SetChildIndex(this.btnOk, 0);
            // 
            // pnlPopupMiddleMargin
            // 
            this.pnlPopupMiddleMargin.Controls.Add(this.gridData);
            // 
            // gridData
            // 
            this.gridData._UseOITheme = true;
            appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            appearance48.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.gridData.DisplayLayout.Appearance = appearance48;
            this.gridData.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridColumn9.DataType = typeof(bool);
            ultraGridColumn9.Header.Caption = "";
            ultraGridColumn9.Header.VisiblePosition = 0;
            ultraGridColumn9.Width = 50;
            ultraGridColumn1.Header.Caption = "Seq";
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn1.Width = 100;
            ultraGridColumn2.Header.Caption = "File Type";
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn3.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn9,
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3});
            this.gridData.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridData.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridData.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.gridData.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(217)))), ((int)(((byte)(231)))));
            this.gridData.DisplayLayout.DefaultSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            appearance49.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance49.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance49.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance49.BorderColor = System.Drawing.SystemColors.Window;
            this.gridData.DisplayLayout.GroupByBox.Appearance = appearance49;
            appearance50.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridData.DisplayLayout.GroupByBox.BandLabelAppearance = appearance50;
            this.gridData.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridData.DisplayLayout.GroupByBox.Hidden = true;
            appearance51.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance51.BackColor2 = System.Drawing.SystemColors.Control;
            appearance51.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance51.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridData.DisplayLayout.GroupByBox.PromptAppearance = appearance51;
            this.gridData.DisplayLayout.MaxColScrollRegions = 1;
            this.gridData.DisplayLayout.MaxRowScrollRegions = 1;
            this.gridData.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            appearance52.BackColor = System.Drawing.SystemColors.Window;
            appearance52.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridData.DisplayLayout.Override.ActiveCellAppearance = appearance52;
            appearance53.BackColor = System.Drawing.SystemColors.Highlight;
            appearance53.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridData.DisplayLayout.Override.ActiveRowAppearance = appearance53;
            this.gridData.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.gridData.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy;
            this.gridData.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridData.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance54.BackColor = System.Drawing.SystemColors.Window;
            this.gridData.DisplayLayout.Override.CardAreaAppearance = appearance54;
            appearance55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            appearance55.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            appearance55.FontData.BoldAsString = "True";
            appearance55.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            appearance55.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            appearance55.TextVAlignAsString = "Middle";
            this.gridData.DisplayLayout.Override.CellAppearance = appearance55;
            this.gridData.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.gridData.DisplayLayout.Override.CellPadding = 0;
            this.gridData.DisplayLayout.Override.DefaultRowHeight = 40;
            appearance56.BackColor = System.Drawing.SystemColors.Control;
            appearance56.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance56.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance56.BorderColor = System.Drawing.SystemColors.Window;
            this.gridData.DisplayLayout.Override.GroupByRowAppearance = appearance56;
            appearance57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            appearance57.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            appearance57.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            appearance57.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            appearance57.FontData.BoldAsString = "True";
            appearance57.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance57.TextHAlignAsString = "Center";
            this.gridData.DisplayLayout.Override.HeaderAppearance = appearance57;
            this.gridData.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridData.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(214)))), ((int)(((byte)(243)))));
            this.gridData.DisplayLayout.Override.HotTrackRowCellAppearance = appearance92;
            appearance58.BackColor = System.Drawing.SystemColors.Window;
            appearance58.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.gridData.DisplayLayout.Override.RowAppearance = appearance58;
            this.gridData.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.gridData.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance59.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridData.DisplayLayout.Override.TemplateAddRowAppearance = appearance59;
            appearance93.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            scrollBarLook1.ThumbAppearance = appearance93;
            this.gridData.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.gridData.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridData.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridData.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridData.Location = new System.Drawing.Point(0, 0);
            this.gridData.Margin = new System.Windows.Forms.Padding(0);
            this.gridData.Name = "gridData";
            this.gridData.Size = new System.Drawing.Size(776, 484);
            this.gridData.TabIndex = 2;
            this.gridData.Text = "soiGrid3";
            this.gridData.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.gridData.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.gridData.UseSOIContextMenu = true;
            // 
            // btnOk
            // 
            this.btnOk._UseOITheme = true;
            this.btnOk._UseStyle = SOI.OIFrx.SOIButtonStyle.DefaultStyle;
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance44.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance44.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance44.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance44.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance44.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance44.FontData.BoldAsString = "True";
            appearance44.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance44.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnOk.Appearance = appearance44;
            this.btnOk.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance45.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance45.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance45.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            this.btnOk.HotTrackAppearance = appearance45;
            this.btnOk.Location = new System.Drawing.Point(566, 0);
            this.btnOk.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnOk.Name = "btnOk";
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance46.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance46.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance46.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            this.btnOk.PressedAppearance = appearance46;
            this.btnOk.ShowFocusRect = false;
            this.btnOk.ShowOutline = false;
            this.btnOk.Size = new System.Drawing.Size(100, 40);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnOk.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnOk.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmStdOperSelectPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Name = "frmStdOperSelectPopup";
            this.Text = "frmStdOperSelectPopup";
            this.Load += new System.EventHandler(this.frmTempSOIPopup_Load);
            this.pnlPopupTop.ResumeLayout(false);
            this.pnlPopupBottom.ResumeLayout(false);
            this.pnlPopupMiddle.ResumeLayout(false);
            this.pnlPopupTopMargin.ResumeLayout(false);
            this.pnlPopupBottomMargin.ResumeLayout(false);
            this.pnlPopupMiddleMargin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SOIControls.SOIGrid gridData;
        private SOIControls.SOIButton btnOk;
    }
}