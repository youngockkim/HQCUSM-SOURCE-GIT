namespace BOI.OIFrx.BOIBaseForm
{
    partial class BOIBaseForm12
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
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BOIBaseForm12));
            this.pnlFavorite = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.pbFavorite = new SOI.OIFrx.SOIControls.SOIPictureBox(this.components);
            this.pnlHelp = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.pbHelp = new SOI.OIFrx.SOIControls.SOIPictureBox(this.components);
            this.pnlStdOper = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.pbStdOper = new SOI.OIFrx.SOIControls.SOIPictureBox(this.components);
            this.pnlTop.SuspendLayout();
            this.pnlTopMargin.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlRightMargin.SuspendLayout();
            this.pnlRightClosePanel.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlFavorite.SuspendLayout();
            this.pnlHelp.SuspendLayout();
            this.pnlStdOper.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(180)))), ((int)(((byte)(181)))));
            this.pnlTop.Size = new System.Drawing.Size(1018, 60);
            // 
            // pnlTopMargin
            // 
            this.pnlTopMargin.Controls.Add(this.pnlStdOper);
            this.pnlTopMargin.Controls.Add(this.pnlHelp);
            this.pnlTopMargin.Controls.Add(this.pnlFavorite);
            this.pnlTopMargin.Size = new System.Drawing.Size(978, 50);
            this.pnlTopMargin.Controls.SetChildIndex(this.pnlFavorite, 0);
            this.pnlTopMargin.Controls.SetChildIndex(this.pnlHelp, 0);
            this.pnlTopMargin.Controls.SetChildIndex(this.pnlStdOper, 0);
            this.pnlTopMargin.Controls.SetChildIndex(this.lblFormTitle, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Size = new System.Drawing.Size(866, 50);
            this.lblFormTitle.Text = "Func Description";
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(234)))), ((int)(((byte)(238)))));
            this.pnlRight.Location = new System.Drawing.Point(908, 60);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(5);
            this.pnlRight.Size = new System.Drawing.Size(110, 587);
            // 
            // pnlRightMargin
            // 
            this.pnlRightMargin.Size = new System.Drawing.Size(100, 577);
            // 
            // pnlRightClosePanel
            // 
            this.pnlRightClosePanel.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.pnlRightClosePanel.Location = new System.Drawing.Point(0, 502);
            this.pnlRightClosePanel.Size = new System.Drawing.Size(100, 75);
            // 
            // btnClose
            // 
            this.btnClose.Size = new System.Drawing.Size(100, 75);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.AutoSize = true;
            this.pnlMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(234)))), ((int)(((byte)(238)))));
            this.pnlMiddle.Padding = new System.Windows.Forms.Padding(5);
            this.pnlMiddle.Size = new System.Drawing.Size(908, 587);
            // 
            // pnlMiddleMargin
            // 
            this.pnlMiddleMargin.AutoScroll = false;
            this.pnlMiddleMargin.AutoSize = true;
            this.pnlMiddleMargin.Location = new System.Drawing.Point(5, 5);
            this.pnlMiddleMargin.Size = new System.Drawing.Size(898, 577);
            // 
            // pnlRightButtonsPanel
            // 
            this.pnlRightButtonsPanel.Size = new System.Drawing.Size(100, 502);
            // 
            // pnlFavorite
            // 
            this.pnlFavorite._UseOITheme = false;
            this.pnlFavorite._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.pnlFavorite.BackColor = System.Drawing.Color.Transparent;
            this.pnlFavorite.Controls.Add(this.pbFavorite);
            this.pnlFavorite.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFavorite.Location = new System.Drawing.Point(946, 0);
            this.pnlFavorite.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFavorite.Name = "pnlFavorite";
            this.pnlFavorite.Size = new System.Drawing.Size(32, 50);
            this.pnlFavorite.TabIndex = 7;
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
            this.pnlHelp.Location = new System.Drawing.Point(906, 0);
            this.pnlHelp.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.pnlHelp.Name = "pnlHelp";
            this.pnlHelp.Size = new System.Drawing.Size(40, 50);
            this.pnlHelp.TabIndex = 8;
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
            this.pnlStdOper.Location = new System.Drawing.Point(866, 0);
            this.pnlStdOper.Margin = new System.Windows.Forms.Padding(0);
            this.pnlStdOper.Name = "pnlStdOper";
            this.pnlStdOper.Size = new System.Drawing.Size(40, 50);
            this.pnlStdOper.TabIndex = 9;
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
            // BOIBaseForm12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 647);
            this.Name = "BOIBaseForm12";
            this.Text = "BOIBaseForm12";
            this.Load += new System.EventHandler(this.BOIBaseForm12_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTopMargin.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlRightMargin.ResumeLayout(false);
            this.pnlRightClosePanel.ResumeLayout(false);
            this.pnlMiddle.ResumeLayout(false);
            this.pnlMiddle.PerformLayout();
            this.pnlFavorite.ResumeLayout(false);
            this.pnlHelp.ResumeLayout(false);
            this.pnlStdOper.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SOI.OIFrx.SOIControls.SOIPanel pnlFavorite;
        public SOI.OIFrx.SOIControls.SOIPictureBox pbFavorite;
        private SOI.OIFrx.SOIControls.SOIPanel pnlHelp;
        public SOI.OIFrx.SOIControls.SOIPictureBox pbHelp;
        private SOI.OIFrx.SOIControls.SOIPanel pnlStdOper;
        public SOI.OIFrx.SOIControls.SOIPictureBox pbStdOper;
    }
}