namespace SOI.OIFrx.SPCBaseForm
{
    partial class SPCBaseForm03
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
            this.pnlMiddle = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.pnlTop = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.pnlTopMargin = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.lblFromTitle = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.pnlCondition = new SOI.OIFrx.SOIControls.SOIPanel(this.components);
            this.pnlTop.SuspendLayout();
            this.pnlTopMargin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMiddle
            // 
            this.pnlMiddle._UseOITheme = false;
            this.pnlMiddle._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.pnlMiddle.BackColor = System.Drawing.Color.Transparent;
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 96);
            this.pnlMiddle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnlMiddle.Size = new System.Drawing.Size(1240, 664);
            this.pnlMiddle.TabIndex = 4;
            // 
            // pnlTop
            // 
            this.pnlTop._UseOITheme = false;
            this.pnlTop._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.Controls.Add(this.pnlTopMargin);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1240, 45);
            this.pnlTop.TabIndex = 2;
            // 
            // pnlTopMargin
            // 
            this.pnlTopMargin._UseOITheme = false;
            this.pnlTopMargin._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.pnlTopMargin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTopMargin.BackColor = System.Drawing.Color.Transparent;
            this.pnlTopMargin.Controls.Add(this.lblFromTitle);
            this.pnlTopMargin.Location = new System.Drawing.Point(20, 5);
            this.pnlTopMargin.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.pnlTopMargin.Name = "pnlTopMargin";
            this.pnlTopMargin.Size = new System.Drawing.Size(1200, 35);
            this.pnlTopMargin.TabIndex = 2;
            // 
            // lblFromTitle
            // 
            this.lblFromTitle._UseConvertLanguage = true;
            this.lblFromTitle._UseOITheme = false;
            this.lblFromTitle._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            appearance5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Middle";
            this.lblFromTitle.Appearance = appearance5;
            this.lblFromTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFromTitle.Font = new System.Drawing.Font("맑은 고딕", 17F, System.Drawing.FontStyle.Bold);
            this.lblFromTitle.Location = new System.Drawing.Point(0, 0);
            this.lblFromTitle.Margin = new System.Windows.Forms.Padding(1);
            this.lblFromTitle.Name = "lblFromTitle";
            this.lblFromTitle.Size = new System.Drawing.Size(1200, 35);
            this.lblFromTitle.TabIndex = 2;
            this.lblFromTitle.Text = "Title";
            this.lblFromTitle.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.lblFromTitle.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // pnlCondition
            // 
            this.pnlCondition._UseOITheme = false;
            this.pnlCondition._UseStyle = SOI.OIFrx.SOIPanelStyle.TransparentStyle;
            this.pnlCondition.BackColor = System.Drawing.Color.Transparent;
            this.pnlCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCondition.Location = new System.Drawing.Point(0, 45);
            this.pnlCondition.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCondition.Name = "pnlCondition";
            this.pnlCondition.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnlCondition.Size = new System.Drawing.Size(1240, 51);
            this.pnlCondition.TabIndex = 5;
            // 
            // SPCBaseForm03
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1240, 760);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlCondition);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.Name = "SPCBaseForm03";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SPCBaseForm03";
            this.pnlTop.ResumeLayout(false);
            this.pnlTopMargin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public SOIControls.SOIPanel pnlTop;
        public SOIControls.SOIPanel pnlTopMargin;
        public SOIControls.SOILabel lblFromTitle;
        public SOIControls.SOIPanel pnlMiddle;
        public SOIControls.SOIPanel pnlCondition;
    }
}