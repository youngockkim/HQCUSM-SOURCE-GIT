namespace BOI.OIFrx.BOIBaseForm
{
    partial class BOIBasePopup02
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BOIBasePopup02));
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.pbStdOper = new SOI.OIFrx.SOIControls.SOIPictureBox(this.components);
            this.pbHelp = new SOI.OIFrx.SOIControls.SOIPictureBox(this.components);
            this.pnlFavorite = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.pbFavorite = new SOI.OIFrx.SOIControls.SOIPictureBox(this.components);
            this.pnlTopMargin.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlBottomMargin.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlBottomClosePanel.SuspendLayout();
            this.pnlFavorite.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Size = new System.Drawing.Size(978, 50);
            this.lblFormTitle.Text = "Func Description";
            this.lblFormTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblFormTitle_MouseDown);
            this.lblFormTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblFormTitle_MouseMove);
            this.lblFormTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblFormTitle_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 18F);
            this.btnClose.Size = new System.Drawing.Size(110, 75);
            // 
            // pnlTopMargin
            // 
            this.pnlTopMargin.Size = new System.Drawing.Size(978, 50);
            this.pnlTopMargin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTopMargin_MouseDown);
            this.pnlTopMargin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTopMargin_MouseMove);
            this.pnlTopMargin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTopMargin_MouseUp);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(180)))), ((int)(((byte)(181)))));
            this.pnlTop.Size = new System.Drawing.Size(1018, 60);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(234)))), ((int)(((byte)(238)))));
            this.pnlBottom.Location = new System.Drawing.Point(0, 562);
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(5);
            this.pnlBottom.Size = new System.Drawing.Size(1018, 85);
            // 
            // pnlBottomMargin
            // 
            this.pnlBottomMargin.Controls.Add(this.pbStdOper);
            this.pnlBottomMargin.Controls.Add(this.pbHelp);
            this.pnlBottomMargin.Controls.Add(this.pnlFavorite);
            this.pnlBottomMargin.Location = new System.Drawing.Point(5, 5);
            this.pnlBottomMargin.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBottomMargin.Size = new System.Drawing.Size(1008, 75);
            this.pnlBottomMargin.Controls.SetChildIndex(this.pnlBottomClosePanel, 0);
            this.pnlBottomMargin.Controls.SetChildIndex(this.pnlFavorite, 0);
            this.pnlBottomMargin.Controls.SetChildIndex(this.pbHelp, 0);
            this.pnlBottomMargin.Controls.SetChildIndex(this.pbStdOper, 0);
            // 
            // pnlMiddleMargin
            // 
            this.pnlMiddleMargin.AutoScroll = false;
            this.pnlMiddleMargin.AutoSize = true;
            this.pnlMiddleMargin.Location = new System.Drawing.Point(5, 5);
            this.pnlMiddleMargin.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMiddleMargin.Size = new System.Drawing.Size(1008, 492);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.AutoSize = true;
            this.pnlMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(234)))), ((int)(((byte)(238)))));
            this.pnlMiddle.Padding = new System.Windows.Forms.Padding(5);
            this.pnlMiddle.Size = new System.Drawing.Size(1018, 502);
            // 
            // pnlBottomClosePanel
            // 
            this.pnlBottomClosePanel.Location = new System.Drawing.Point(898, 0);
            this.pnlBottomClosePanel.Size = new System.Drawing.Size(110, 75);
            // 
            // pbStdOper
            // 
            this.pbStdOper._UseLotStatusStyle = SOI.OIFrx.SOIPictureBoxStyle.None;
            this.pbStdOper._UseOITheme = false;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Bottom;
            this.pbStdOper.Appearance = appearance4;
            this.pbStdOper.BackColor = System.Drawing.Color.Transparent;
            this.pbStdOper.BorderShadowColor = System.Drawing.Color.Empty;
            this.pbStdOper.Image = ((object)(resources.GetObject("pbStdOper.Image")));
            this.pbStdOper.Location = new System.Drawing.Point(884, 50);
            this.pbStdOper.LotStatus = false;
            this.pbStdOper.Margin = new System.Windows.Forms.Padding(0);
            this.pbStdOper.Name = "pbStdOper";
            this.pbStdOper.Size = new System.Drawing.Size(10, 21);
            this.pbStdOper.TabIndex = 8;
            this.pbStdOper.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.pbStdOper.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.pbStdOper.Visible = false;
            // 
            // pbHelp
            // 
            this.pbHelp._UseLotStatusStyle = SOI.OIFrx.SOIPictureBoxStyle.None;
            this.pbHelp._UseOITheme = false;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Bottom;
            this.pbHelp.Appearance = appearance6;
            this.pbHelp.BackColor = System.Drawing.Color.Transparent;
            this.pbHelp.BorderShadowColor = System.Drawing.Color.Empty;
            this.pbHelp.Image = ((object)(resources.GetObject("pbHelp.Image")));
            this.pbHelp.Location = new System.Drawing.Point(874, 50);
            this.pbHelp.LotStatus = false;
            this.pbHelp.Margin = new System.Windows.Forms.Padding(0);
            this.pbHelp.Name = "pbHelp";
            this.pbHelp.Size = new System.Drawing.Size(10, 21);
            this.pbHelp.TabIndex = 7;
            this.pbHelp.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.pbHelp.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.pbHelp.Visible = false;
            // 
            // pnlFavorite
            // 
            this.pnlFavorite._UseOITheme = false;
            this.pnlFavorite._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.pnlFavorite.BackColor = System.Drawing.Color.Transparent;
            this.pnlFavorite.Controls.Add(this.pbFavorite);
            this.pnlFavorite.Location = new System.Drawing.Point(894, 50);
            this.pnlFavorite.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFavorite.Name = "pnlFavorite";
            this.pnlFavorite.Size = new System.Drawing.Size(2, 21);
            this.pnlFavorite.TabIndex = 9;
            this.pnlFavorite.Visible = false;
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
            this.pbFavorite.Location = new System.Drawing.Point(0, 18);
            this.pbFavorite.LotStatus = false;
            this.pbFavorite.Margin = new System.Windows.Forms.Padding(0);
            this.pbFavorite.Name = "pbFavorite";
            this.pbFavorite.ScaleImage = Infragistics.Win.ScaleImage.Always;
            this.pbFavorite.Size = new System.Drawing.Size(32, 32);
            this.pbFavorite.TabIndex = 0;
            this.pbFavorite.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.pbFavorite.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // BOIBasePopup02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 647);
            this.Name = "BOIBasePopup02";
            this.Text = "BOIBasePopup02";
            this.Load += new System.EventHandler(this.BOIBasePopup02_Load);
            this.pnlTopMargin.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottomMargin.ResumeLayout(false);
            this.pnlMiddle.ResumeLayout(false);
            this.pnlMiddle.PerformLayout();
            this.pnlBottomClosePanel.ResumeLayout(false);
            this.pnlFavorite.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public SOI.OIFrx.SOIControls.SOIPictureBox pbStdOper;
        public SOI.OIFrx.SOIControls.SOIPictureBox pbHelp;
        private SOI.OIFrx.SOIControls.SOIPanel pnlFavorite;
        public SOI.OIFrx.SOIControls.SOIPictureBox pbFavorite;

    }
}