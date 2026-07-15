namespace StandardOI
{
    partial class frmOpenedMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpenedMenu));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("data", 0);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.lbOpenedFormList = new SOI.OIFrx.SOIControls.SOIListBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbOpenedFormList)).BeginInit();
            this.SuspendLayout();
            // 
            // pbClose
            // 
            this.pbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbClose.BackColor = System.Drawing.Color.Transparent;
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = ((System.Drawing.Image)(resources.GetObject("pbClose.Image")));
            this.pbClose.Location = new System.Drawing.Point(468, 2);
            this.pbClose.Margin = new System.Windows.Forms.Padding(0);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(30, 35);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbClose.TabIndex = 2;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // lbOpenedFormList
            // 
            this.lbOpenedFormList._UseConvertLanguage = false;
            this.lbOpenedFormList._UseOITheme = true;
            this.lbOpenedFormList._UseStyle = SOI.OIFrx.SOIListBoxStyle.MenuStyle;
            this.lbOpenedFormList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            appearance1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbOpenedFormList.DisplayLayout.Appearance = appearance1;
            this.lbOpenedFormList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ultraGridBand1.ColHeadersVisible = false;
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            ultraGridColumn2.CellAppearance = appearance3;
            ultraGridColumn2.Header.VisiblePosition = 0;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn2});
            this.lbOpenedFormList.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.lbOpenedFormList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lbOpenedFormList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.lbOpenedFormList.DisplayLayout.CellHottrackInvalidationStyle = Infragistics.Win.UltraWinGrid.CellHottrackInvalidationStyle.OnlyIfHottrackAppearance;
            this.lbOpenedFormList.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(234)))), ((int)(((byte)(251)))));
            this.lbOpenedFormList.DisplayLayout.DefaultSelectedForeColor = System.Drawing.Color.Empty;
            appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.BorderColor = System.Drawing.SystemColors.Window;
            this.lbOpenedFormList.DisplayLayout.GroupByBox.Appearance = appearance4;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbOpenedFormList.DisplayLayout.GroupByBox.BandLabelAppearance = appearance5;
            this.lbOpenedFormList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lbOpenedFormList.DisplayLayout.GroupByBox.Hidden = true;
            appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance6.BackColor2 = System.Drawing.SystemColors.Control;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbOpenedFormList.DisplayLayout.GroupByBox.PromptAppearance = appearance6;
            this.lbOpenedFormList.DisplayLayout.MaxColScrollRegions = 1;
            this.lbOpenedFormList.DisplayLayout.MaxRowScrollRegions = 1;
            this.lbOpenedFormList.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            appearance7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbOpenedFormList.DisplayLayout.Override.ActiveCellAppearance = appearance7;
            appearance8.BackColor = System.Drawing.SystemColors.Highlight;
            appearance8.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbOpenedFormList.DisplayLayout.Override.ActiveRowAppearance = appearance8;
            this.lbOpenedFormList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            this.lbOpenedFormList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            this.lbOpenedFormList.DisplayLayout.Override.CardAreaAppearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance10.FontData.BoldAsString = "True";
            appearance10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(73)))), ((int)(((byte)(129)))));
            appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.lbOpenedFormList.DisplayLayout.Override.CellAppearance = appearance10;
            this.lbOpenedFormList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.lbOpenedFormList.DisplayLayout.Override.CellPadding = 0;
            this.lbOpenedFormList.DisplayLayout.Override.DefaultRowHeight = 50;
            appearance11.BackColor = System.Drawing.SystemColors.Control;
            appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance11.BorderColor = System.Drawing.SystemColors.Window;
            this.lbOpenedFormList.DisplayLayout.Override.GroupByRowAppearance = appearance11;
            appearance12.TextHAlignAsString = "Left";
            this.lbOpenedFormList.DisplayLayout.Override.HeaderAppearance = appearance12;
            this.lbOpenedFormList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.ExternalSortSingle;
            this.lbOpenedFormList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(214)))), ((int)(((byte)(243)))));
            this.lbOpenedFormList.DisplayLayout.Override.HotTrackRowAppearance = appearance13;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(214)))), ((int)(((byte)(243)))));
            this.lbOpenedFormList.DisplayLayout.Override.HotTrackRowCellAppearance = appearance14;
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            appearance15.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbOpenedFormList.DisplayLayout.Override.RowAppearance = appearance15;
            this.lbOpenedFormList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.lbOpenedFormList.DisplayLayout.Override.RowSpacingAfter = 2;
            this.lbOpenedFormList.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance16.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbOpenedFormList.DisplayLayout.Override.TemplateAddRowAppearance = appearance16;
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            scrollBarLook1.ThumbAppearance = appearance17;
            this.lbOpenedFormList.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.lbOpenedFormList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.lbOpenedFormList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.lbOpenedFormList.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.lbOpenedFormList.Location = new System.Drawing.Point(2, 2);
            this.lbOpenedFormList.Margin = new System.Windows.Forms.Padding(0);
            this.lbOpenedFormList.Name = "lbOpenedFormList";
            this.lbOpenedFormList.Size = new System.Drawing.Size(464, 265);
            this.lbOpenedFormList.TabIndex = 1;
            this.lbOpenedFormList.Text = "soiListBox1";
            this.lbOpenedFormList.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.lbOpenedFormList.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.lbOpenedFormList.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.lbOpenedFormList_AfterSelectChange);
            // 
            // frmOpenedMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(500, 269);
            this.ControlBox = false;
            this.Controls.Add(this.lbOpenedFormList);
            this.Controls.Add(this.pbClose);
            this.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmOpenedMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmOpenedMenu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmOpenedMenu_FormClosed);
            this.Load += new System.EventHandler(this.frmOpenedMenu_Load);
            this.Shown += new System.EventHandler(this.frmOpenedMenu_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbOpenedFormList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SOI.OIFrx.SOIControls.SOIListBox lbOpenedFormList;
        private System.Windows.Forms.PictureBox pbClose;

    }
}