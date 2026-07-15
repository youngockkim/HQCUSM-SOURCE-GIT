namespace SOI.HanwhaQcell.USModule.CWIP.Popup
{
    partial class frmCWIPSiliconeMIAttachResultPopup
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.panel2 = new System.Windows.Forms.Panel();
            this.soiLabel2 = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtMIAttach1 = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.soiLabel1 = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtMIAttach2 = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.pnlPopupTop.SuspendLayout();
            this.pnlPopupBottom.SuspendLayout();
            this.pnlPopupMiddle.SuspendLayout();
            this.pnlPopupTopMargin.SuspendLayout();
            this.pnlPopupBottomMargin.SuspendLayout();
            this.pnlPopupMiddleMargin.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
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
            this.pnlPopupMiddleMargin.Controls.Add(this.panel4);
            this.pnlPopupMiddleMargin.Controls.Add(this.panel1);
            this.pnlPopupMiddleMargin.Controls.Add(this.panel3);
            this.pnlPopupMiddleMargin.Controls.Add(this.panel2);
            this.pnlPopupMiddleMargin.Size = new System.Drawing.Size(535, 188);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.soiLabel2);
            this.panel2.Location = new System.Drawing.Point(24, 84);
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
            this.soiLabel2.TabIndex = 7;
            this.soiLabel2.Text = "MIAttach1";
            this.soiLabel2.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.soiLabel2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.Controls.Add(this.txtMIAttach1);
            this.panel3.Location = new System.Drawing.Point(269, 84);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(243, 34);
            this.panel3.TabIndex = 2;
            // 
            // txtMIAttach1
            // 
            this.txtMIAttach1._UseConvertLanguage = true;
            this.txtMIAttach1._UseOITheme = true;
            this.txtMIAttach1._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.FontData.BoldAsString = "True";
            appearance1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.txtMIAttach1.Appearance = appearance1;
            this.txtMIAttach1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMIAttach1.Location = new System.Drawing.Point(0, 0);
            this.txtMIAttach1.Margin = new System.Windows.Forms.Padding(0);
            this.txtMIAttach1.Name = "txtMIAttach1";
            this.txtMIAttach1.Size = new System.Drawing.Size(243, 34);
            this.txtMIAttach1.TabIndex = 9;
            this.txtMIAttach1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtMIAttach1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.soiLabel1);
            this.panel1.Location = new System.Drawing.Point(24, 120);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 34);
            this.panel1.TabIndex = 2;
            // 
            // soiLabel1
            // 
            this.soiLabel1._UseConvertLanguage = true;
            this.soiLabel1._UseOITheme = true;
            this.soiLabel1._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.FontData.BoldAsString = "True";
            appearance5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance5.TextHAlignAsString = "Center";
            appearance5.TextVAlignAsString = "Middle";
            this.soiLabel1.Appearance = appearance5;
            this.soiLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiLabel1.Location = new System.Drawing.Point(0, 0);
            this.soiLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.soiLabel1.Name = "soiLabel1";
            this.soiLabel1.Size = new System.Drawing.Size(243, 34);
            this.soiLabel1.TabIndex = 7;
            this.soiLabel1.Text = "MIAttach2";
            this.soiLabel1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.soiLabel1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkGray;
            this.panel4.Controls.Add(this.txtMIAttach2);
            this.panel4.Location = new System.Drawing.Point(269, 120);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(243, 34);
            this.panel4.TabIndex = 3;
            // 
            // txtMIAttach2
            // 
            this.txtMIAttach2._UseConvertLanguage = true;
            this.txtMIAttach2._UseOITheme = true;
            this.txtMIAttach2._UseStyle = SOI.OIFrx.SOILabelStyle.DefaultStyle;
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.FontData.BoldAsString = "True";
            appearance3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.txtMIAttach2.Appearance = appearance3;
            this.txtMIAttach2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMIAttach2.Location = new System.Drawing.Point(0, 0);
            this.txtMIAttach2.Margin = new System.Windows.Forms.Padding(0);
            this.txtMIAttach2.Name = "txtMIAttach2";
            this.txtMIAttach2.Size = new System.Drawing.Size(243, 34);
            this.txtMIAttach2.TabIndex = 10;
            this.txtMIAttach2.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtMIAttach2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // frmCWIPSiliconeMIAttachResultPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 310);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmCWIPSiliconeMIAttachResultPopup";
            this.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Text = "frmCWIPSiliconeWeightResultPopup";
            this.pnlPopupTop.ResumeLayout(false);
            this.pnlPopupBottom.ResumeLayout(false);
            this.pnlPopupMiddle.ResumeLayout(false);
            this.pnlPopupTopMargin.ResumeLayout(false);
            this.pnlPopupBottomMargin.ResumeLayout(false);
            this.pnlPopupMiddleMargin.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private OIFrx.SOIControls.SOILabel soiLabel1;
        private OIFrx.SOIControls.SOILabel soiLabel2;
        public OIFrx.SOIControls.SOILabel txtMIAttach2;
        public OIFrx.SOIControls.SOILabel txtMIAttach1;

    }
}