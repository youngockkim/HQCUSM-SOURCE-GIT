namespace SOI.OIFrx.SOIBaseForm
{
    partial class SOIBaseForm03
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SOIBaseForm03));
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            this.btnPrintOption = new SOI.OIFrx.SOIControls.SOIButtonPrintOption(this.components);
            this.pnlPrintOption = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.pnlTopMargin.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlBottomMargin.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlBottomClosePanel.SuspendLayout();
            this.pnlPrintOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbHelp
            // 
            this.pbHelp.Image = ((object)(resources.GetObject("pbHelp.Image")));
            // 
            // pbStdOper
            // 
            this.pbStdOper.Image = ((object)(resources.GetObject("pbStdOper.Image")));
            // 
            // pnlBottomMargin
            // 
            this.pnlBottomMargin.Controls.Add(this.pnlPrintOption);
            this.pnlBottomMargin.Controls.SetChildIndex(this.pnlBottomClosePanel, 0);
            this.pnlBottomMargin.Controls.SetChildIndex(this.pnlPrintOption, 0);
            // 
            // btnPrintOption
            // 
            this.btnPrintOption._UseOITheme = true;
            this.btnPrintOption._UseStyle = SOI.OIFrx.SOIButtonPrintOptionStyle.DefaultStyle;
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance31.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance31.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance31.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance31.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance31.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance31.FontData.BoldAsString = "True";
            appearance31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance31.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            appearance31.Image = ((object)(resources.GetObject("appearance31.Image")));
            appearance31.TextHAlignAsString = "Left";
            appearance31.TextVAlignAsString = "Middle";
            this.btnPrintOption.Appearance = appearance31;
            this.btnPrintOption.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
            this.btnPrintOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrintOption.FuncName = null;
            appearance72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance72.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance72.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance72.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(117)))), ((int)(((byte)(179)))));
            appearance72.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPrintOption.HotTrackAppearance = appearance72;
            this.btnPrintOption.ImageSize = new System.Drawing.Size(35, 35);
            this.btnPrintOption.Location = new System.Drawing.Point(0, 0);
            this.btnPrintOption.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnPrintOption.Name = "btnPrintOption";
            appearance73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance73.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance73.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance73.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            this.btnPrintOption.PressedAppearance = appearance73;
            this.btnPrintOption.PrintOption = null;
            this.btnPrintOption.ShowFocusRect = false;
            this.btnPrintOption.ShowOutline = false;
            this.btnPrintOption.Size = new System.Drawing.Size(150, 40);
            this.btnPrintOption.TabIndex = 4;
            this.btnPrintOption.Text = "Print Option";
            this.btnPrintOption.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnPrintOption.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnPrintOption.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnPrintOption.Click += new System.EventHandler(this.btnPrintOption_Click);
            // 
            // pnlPrintOption
            // 
            this.pnlPrintOption._SetAutoScrollPanel = false;
            this.pnlPrintOption._UseOITheme = true;
            this.pnlPrintOption._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.pnlPrintOption.BackColor = System.Drawing.Color.Transparent;
            this.pnlPrintOption.Controls.Add(this.btnPrintOption);
            this.pnlPrintOption.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPrintOption.Location = new System.Drawing.Point(0, 0);
            this.pnlPrintOption.Margin = new System.Windows.Forms.Padding(0);
            this.pnlPrintOption.Name = "pnlPrintOption";
            this.pnlPrintOption.Size = new System.Drawing.Size(150, 40);
            this.pnlPrintOption.TabIndex = 5;
            // 
            // SOIBaseForm03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 719);
            this.Name = "SOIBaseForm03";
            this.Text = "SOIBaseForm03";
            this.Load += new System.EventHandler(this.SOIBaseForm03_Load);
            this.pnlTopMargin.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottomMargin.ResumeLayout(false);
            this.pnlMiddle.ResumeLayout(false);
            this.pnlBottomClosePanel.ResumeLayout(false);
            this.pnlPrintOption.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public SOIControls.SOIButtonPrintOption btnPrintOption;
        public SOIControls.SOIPanel pnlPrintOption;

    }
}