namespace SOI.OIFrx.SOIBaseForm
{
    partial class SOIBaseForm02
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SOIBaseForm02));
            this.btnProcess = new SOI.OIFrx.SOIControls.SOIButton(this.components);
            this.pnlFavorite = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.pbFavorite = new SOI.OIFrx.SOIControls.SOIPictureBox(this.components);
            this.pnlHelp = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.pbHelp = new SOI.OIFrx.SOIControls.SOIPictureBox(this.components);
            this.pnlStdOper = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.pbStdOper = new SOI.OIFrx.SOIControls.SOIPictureBox(this.components);
            this.pnlTopMargin.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlBottomMargin.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlBottomClosePanel.SuspendLayout();
            this.pnlFavorite.SuspendLayout();
            this.pnlHelp.SuspendLayout();
            this.pnlStdOper.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Size = new System.Drawing.Size(1122, 50);
            this.lblFormTitle.Text = "Func Description";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(120, 0);
            // 
            // pnlTopMargin
            // 
            this.pnlTopMargin.Controls.Add(this.pnlStdOper);
            this.pnlTopMargin.Controls.Add(this.pnlHelp);
            this.pnlTopMargin.Controls.Add(this.pnlFavorite);
            this.pnlTopMargin.Controls.SetChildIndex(this.pnlFavorite, 0);
            this.pnlTopMargin.Controls.SetChildIndex(this.pnlHelp, 0);
            this.pnlTopMargin.Controls.SetChildIndex(this.pnlStdOper, 0);
            this.pnlTopMargin.Controls.SetChildIndex(this.lblFormTitle, 0);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(180)))), ((int)(((byte)(181)))));
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(234)))), ((int)(((byte)(238)))));
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(234)))), ((int)(((byte)(238)))));
            // 
            // pnlBottomClosePanel
            // 
            this.pnlBottomClosePanel.Controls.Add(this.btnProcess);
            this.pnlBottomClosePanel.Location = new System.Drawing.Point(1004, 0);
            this.pnlBottomClosePanel.Size = new System.Drawing.Size(230, 40);
            this.pnlBottomClosePanel.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottomClosePanel.Controls.SetChildIndex(this.btnProcess, 0);
            // 
            // btnProcess
            // 
            this.btnProcess._UseOITheme = true;
            this.btnProcess._UseStyle = SOI.OIFrx.SOIButtonStyle.DefaultStyle;
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance1.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance1.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance1.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance1.FontData.BoldAsString = "True";
            appearance1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance1.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnProcess.Appearance = appearance1;
            this.btnProcess.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance2.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            this.btnProcess.HotTrackAppearance = appearance2;
            this.btnProcess.Location = new System.Drawing.Point(0, 0);
            this.btnProcess.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnProcess.Name = "btnProcess";
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance3.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            this.btnProcess.PressedAppearance = appearance3;
            this.btnProcess.ShowFocusRect = false;
            this.btnProcess.ShowOutline = false;
            this.btnProcess.Size = new System.Drawing.Size(110, 40);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnProcess.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnProcess.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // pnlFavorite
            // 
            this.pnlFavorite._UseOITheme = false;
            this.pnlFavorite._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.pnlFavorite.BackColor = System.Drawing.Color.Transparent;
            this.pnlFavorite.Controls.Add(this.pbFavorite);
            this.pnlFavorite.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFavorite.Location = new System.Drawing.Point(1202, 0);
            this.pnlFavorite.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFavorite.Name = "pnlFavorite";
            this.pnlFavorite.Size = new System.Drawing.Size(32, 50);
            this.pnlFavorite.TabIndex = 6;
            // 
            // pbFavorite
            // 
            this.pbFavorite._UseLotStatusStyle = SOI.OIFrx.SOIPictureBoxStyle.None;
            this.pbFavorite._UseOITheme = false;
            appearance5.ImageVAlign = Infragistics.Win.VAlign.Bottom;
            this.pbFavorite.Appearance = appearance5;
            this.pbFavorite.BackColor = System.Drawing.Color.Transparent;
            this.pbFavorite.BorderShadowColor = System.Drawing.Color.Empty;
            this.pbFavorite.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbFavorite.Image = ((object)(resources.GetObject("pbFavorite.Image")));
            this.pbFavorite.Location = new System.Drawing.Point(0, 20);
            this.pbFavorite.LotStatus = false;
            this.pbFavorite.Margin = new System.Windows.Forms.Padding(0);
            this.pbFavorite.Name = "pbFavorite";
            this.pbFavorite.ScaleImage = Infragistics.Win.ScaleImage.Always;
            this.pbFavorite.Size = new System.Drawing.Size(32, 32);
            this.pbFavorite.TabIndex = 0;
            this.pbFavorite.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.pbFavorite.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.pbFavorite.Click += new System.EventHandler(this.pbFavorite_Click);
            // 
            // pnlHelp
            // 
            this.pnlHelp._UseOITheme = false;
            this.pnlHelp._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.pnlHelp.BackColor = System.Drawing.Color.Transparent;
            this.pnlHelp.Controls.Add(this.pbHelp);
            this.pnlHelp.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlHelp.Location = new System.Drawing.Point(1162, 0);
            this.pnlHelp.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.pnlHelp.Name = "pnlHelp";
            this.pnlHelp.Size = new System.Drawing.Size(40, 50);
            this.pnlHelp.TabIndex = 7;
            // 
            // pbHelp
            // 
            this.pbHelp._UseLotStatusStyle = SOI.OIFrx.SOIPictureBoxStyle.None;
            this.pbHelp._UseOITheme = false;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Bottom;
            this.pbHelp.Appearance = appearance6;
            this.pbHelp.BackColor = System.Drawing.Color.Transparent;
            this.pbHelp.BorderShadowColor = System.Drawing.Color.Empty;
            this.pbHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbHelp.Image = ((object)(resources.GetObject("pbHelp.Image")));
            this.pbHelp.Location = new System.Drawing.Point(0, 0);
            this.pbHelp.LotStatus = false;
            this.pbHelp.Margin = new System.Windows.Forms.Padding(0);
            this.pbHelp.Name = "pbHelp";
            this.pbHelp.Size = new System.Drawing.Size(40, 50);
            this.pbHelp.TabIndex = 0;
            this.pbHelp.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.pbHelp.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.pbHelp.Visible = false;
            this.pbHelp.Click += new System.EventHandler(this.pbHelp_Click);
            // 
            // pnlStdOper
            // 
            this.pnlStdOper._UseOITheme = false;
            this.pnlStdOper._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.pnlStdOper.BackColor = System.Drawing.Color.Transparent;
            this.pnlStdOper.Controls.Add(this.pbStdOper);
            this.pnlStdOper.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlStdOper.Location = new System.Drawing.Point(1122, 0);
            this.pnlStdOper.Margin = new System.Windows.Forms.Padding(0);
            this.pnlStdOper.Name = "pnlStdOper";
            this.pnlStdOper.Size = new System.Drawing.Size(40, 50);
            this.pnlStdOper.TabIndex = 8;
            // 
            // pbStdOper
            // 
            this.pbStdOper._UseLotStatusStyle = SOI.OIFrx.SOIPictureBoxStyle.None;
            this.pbStdOper._UseOITheme = false;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Bottom;
            this.pbStdOper.Appearance = appearance4;
            this.pbStdOper.BackColor = System.Drawing.Color.Transparent;
            this.pbStdOper.BorderShadowColor = System.Drawing.Color.Empty;
            this.pbStdOper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbStdOper.Image = ((object)(resources.GetObject("pbStdOper.Image")));
            this.pbStdOper.Location = new System.Drawing.Point(0, 0);
            this.pbStdOper.LotStatus = false;
            this.pbStdOper.Margin = new System.Windows.Forms.Padding(0);
            this.pbStdOper.Name = "pbStdOper";
            this.pbStdOper.Size = new System.Drawing.Size(40, 50);
            this.pbStdOper.TabIndex = 0;
            this.pbStdOper.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.pbStdOper.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.pbStdOper.Visible = false;
            // 
            // SOIBaseForm02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 719);
            this.Name = "SOIBaseForm02";
            this.Text = "SOIBaseForm02";
            this.Load += new System.EventHandler(this.SOIBaseForm02_Load);
            this.pnlTopMargin.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottomMargin.ResumeLayout(false);
            this.pnlMiddle.ResumeLayout(false);
            this.pnlBottomClosePanel.ResumeLayout(false);
            this.pnlFavorite.ResumeLayout(false);
            this.pnlHelp.ResumeLayout(false);
            this.pnlStdOper.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public SOIControls.SOIButton btnProcess;
        private SOIControls.SOIPanel pnlFavorite;
        private SOIControls.SOIPanel pnlHelp;
        private SOIControls.SOIPanel pnlStdOper;
        public SOIControls.SOIPictureBox pbFavorite;
        public SOIControls.SOIPictureBox pbHelp;
        public SOIControls.SOIPictureBox pbStdOper;
    }
}