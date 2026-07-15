namespace SOI.HanwhaQcell.USModule.CWIP.Popup
{
    partial class frmCWIPSiliconeRatioResultPopup
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.panel2 = new System.Windows.Forms.Panel();
            this.soiLabel2 = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.soiLabel1 = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.ratioRs = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.ratioRs2 = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnlPopupTop.SuspendLayout();
            this.pnlPopupBottom.SuspendLayout();
            this.pnlPopupMiddle.SuspendLayout();
            this.pnlPopupTopMargin.SuspendLayout();
            this.pnlPopupBottomMargin.SuspendLayout();
            this.pnlPopupMiddleMargin.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPopupTitle
            // 
            this.lblPopupTitle.Size = new System.Drawing.Size(535, 38);
            this.lblPopupTitle.Text = "Cell Location";
            // 
            // pnlPopupTop
            // 
            this.pnlPopupTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.pnlPopupTop.Location = new System.Drawing.Point(3, 4);
            this.pnlPopupTop.Size = new System.Drawing.Size(555, 48);
            // 
            // pnlPopupBottom
            // 
            this.pnlPopupBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlPopupBottom.Location = new System.Drawing.Point(3, 254);
            this.pnlPopupBottom.Size = new System.Drawing.Size(555, 52);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Location = new System.Drawing.Point(0, 0);
            this.btnClose.Size = new System.Drawing.Size(535, 42);
            this.btnClose.Text = "OK";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlPopupMiddle
            // 
            this.pnlPopupMiddle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlPopupMiddle.Location = new System.Drawing.Point(3, 56);
            this.pnlPopupMiddle.Size = new System.Drawing.Size(555, 198);
            // 
            // pnlPopupTopMargin
            // 
            this.pnlPopupTopMargin.Size = new System.Drawing.Size(535, 38);
            // 
            // pnlPopupBottomMargin
            // 
            this.pnlPopupBottomMargin.Size = new System.Drawing.Size(535, 42);
            // 
            // pnlPopupMiddleMargin
            // 
            this.pnlPopupMiddleMargin.Controls.Add(this.panel3);
            this.pnlPopupMiddleMargin.Controls.Add(this.panel2);
            this.pnlPopupMiddleMargin.Controls.Add(this.panel4);
            this.pnlPopupMiddleMargin.Controls.Add(this.panel5);
            this.pnlPopupMiddleMargin.Size = new System.Drawing.Size(535, 188);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.soiLabel2);
            this.panel2.Location = new System.Drawing.Point(24, 68);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(243, 34);
            this.panel2.TabIndex = 1;
            // 
            // soiLabel2
            // 
            this.soiLabel2._UseConvertLanguage = true;
            this.soiLabel2._UseOITheme = true;
            this.soiLabel2._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.FontData.BoldAsString = "True";
            appearance2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.soiLabel2.Appearance = appearance2;
            this.soiLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiLabel2.Location = new System.Drawing.Point(0, 0);
            this.soiLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.soiLabel2.Name = "soiLabel2";
            this.soiLabel2.Size = new System.Drawing.Size(243, 34);
            this.soiLabel2.TabIndex = 4;
            this.soiLabel2.Text = "Ratio";
            this.soiLabel2.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.soiLabel2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // soiLabel1
            // 
            this.soiLabel1._UseConvertLanguage = true;
            this.soiLabel1._UseOITheme = true;
            this.soiLabel1._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.FontData.BoldAsString = "True";
            appearance3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.soiLabel1.Appearance = appearance3;
            this.soiLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiLabel1.Location = new System.Drawing.Point(0, 0);
            this.soiLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.soiLabel1.Name = "soiLabel1";
            this.soiLabel1.Size = new System.Drawing.Size(243, 34);
            this.soiLabel1.TabIndex = 5;
            this.soiLabel1.Text = "Ratio2";
            this.soiLabel1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.soiLabel1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.Controls.Add(this.ratioRs);
            this.panel3.Location = new System.Drawing.Point(269, 68);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(243, 34);
            this.panel3.TabIndex = 2;
            // 
            // ratioRs
            // 
            this.ratioRs._UseConvertLanguage = true;
            this.ratioRs._UseOITheme = true;
            this.ratioRs._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.FontData.BoldAsString = "True";
            appearance1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.ratioRs.Appearance = appearance1;
            this.ratioRs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ratioRs.Location = new System.Drawing.Point(0, 0);
            this.ratioRs.Margin = new System.Windows.Forms.Padding(0);
            this.ratioRs.Name = "ratioRs";
            this.ratioRs.Size = new System.Drawing.Size(243, 34);
            this.ratioRs.TabIndex = 5;
            this.ratioRs.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.ratioRs.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ratioRs2
            // 
            this.ratioRs2._UseConvertLanguage = true;
            this.ratioRs2._UseOITheme = true;
            this.ratioRs2._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.FontData.BoldAsString = "True";
            appearance4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance4.TextHAlignAsString = "Center";
            appearance4.TextVAlignAsString = "Middle";
            this.ratioRs2.Appearance = appearance4;
            this.ratioRs2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ratioRs2.Location = new System.Drawing.Point(0, 0);
            this.ratioRs2.Margin = new System.Windows.Forms.Padding(0);
            this.ratioRs2.Name = "ratioRs2";
            this.ratioRs2.Size = new System.Drawing.Size(243, 34);
            this.ratioRs2.TabIndex = 0;
            this.ratioRs2.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.ratioRs2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkGray;
            this.panel4.Controls.Add(this.soiLabel1);
            this.panel4.Location = new System.Drawing.Point(24, 106);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(243, 34);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkGray;
            this.panel5.Controls.Add(this.ratioRs2);
            this.panel5.Location = new System.Drawing.Point(268, 106);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(243, 34);
            this.panel5.TabIndex = 1;
            // 
            // frmCWIPSiliconeRatioResultPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 310);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmCWIPSiliconeRatioResultPopup";
            this.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Text = "frmCWIPSiliconeWeightResultPopup";
            this.Load += new System.EventHandler(this.frmCWIPSiliconeWeightResultPopup_Load);
            this.pnlPopupTop.ResumeLayout(false);
            this.pnlPopupBottom.ResumeLayout(false);
            this.pnlPopupMiddle.ResumeLayout(false);
            this.pnlPopupTopMargin.ResumeLayout(false);
            this.pnlPopupBottomMargin.ResumeLayout(false);
            this.pnlPopupMiddleMargin.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private OIFrx.SOIControls.SOILabel ratioRs;
        private OIFrx.SOIControls.SOILabel ratioRs2;
        private OIFrx.SOIControls.SOILabel soiLabel2;
        private OIFrx.SOIControls.SOILabel soiLabel1;


    }
}