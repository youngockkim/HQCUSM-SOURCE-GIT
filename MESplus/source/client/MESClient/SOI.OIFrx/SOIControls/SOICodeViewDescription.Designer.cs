namespace SOI.OIFrx.SOIControls
{
    partial class SOICodeViewDescription
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("CodeViewButton");
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SOICodeViewDescription));
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            this.tlpVerticalCenterCode = new SOI.OIFrx.SOIControls.SOITableLayoutPanel(this.components);
            this.cdvCode = new SOI.OIFrx.SOIControls.SOICodeView(this.components);
            this.tlpVerticalCenterDesc = new SOI.OIFrx.SOIControls.SOITableLayoutPanel(this.components);
            this.txtDesc = new SOI.OIFrx.SOIControls.SOITextBox(this.components);
            this.pnlCode = new System.Windows.Forms.Panel();
            this.pnlMargin = new System.Windows.Forms.Panel();
            this.pnlDesc = new System.Windows.Forms.Panel();
            this.tlpVerticalCenterCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCode)).BeginInit();
            this.tlpVerticalCenterDesc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).BeginInit();
            this.pnlCode.SuspendLayout();
            this.pnlDesc.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpVerticalCenterCode
            // 
            this.tlpVerticalCenterCode._UseOITheme = true;
            this.tlpVerticalCenterCode.BackColor = System.Drawing.Color.Transparent;
            this.tlpVerticalCenterCode.ColumnCount = 1;
            this.tlpVerticalCenterCode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpVerticalCenterCode.Controls.Add(this.cdvCode, 0, 1);
            this.tlpVerticalCenterCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpVerticalCenterCode.Location = new System.Drawing.Point(0, 0);
            this.tlpVerticalCenterCode.Margin = new System.Windows.Forms.Padding(0);
            this.tlpVerticalCenterCode.Name = "tlpVerticalCenterCode";
            this.tlpVerticalCenterCode.RowCount = 3;
            this.tlpVerticalCenterCode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpVerticalCenterCode.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpVerticalCenterCode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpVerticalCenterCode.Size = new System.Drawing.Size(200, 40);
            this.tlpVerticalCenterCode.TabIndex = 11;
            // 
            // cdvCode
            // 
            this.cdvCode._UseOITheme = true;
            this.cdvCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            appearance8.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            appearance8.FontData.BoldAsString = "True";
            appearance8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            appearance8.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.cdvCode.Appearance = appearance8;
            this.cdvCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.cdvCode.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(127)))), ((int)(((byte)(189)))));
            appearance12.Image = ((object)(resources.GetObject("appearance12.Image")));
            editorButton1.Appearance = appearance12;
            editorButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.FlatBorderless;
            editorButton1.Key = "CodeViewButton";
            editorButton1.Width = 30;
            this.cdvCode.ButtonsRight.Add(editorButton1);
            this.cdvCode.Location = new System.Drawing.Point(0, 10);
            this.cdvCode.Margin = new System.Windows.Forms.Padding(0);
            this.cdvCode.Name = "cdvCode";
            this.cdvCode.ReadOnly = true;
            this.cdvCode.Size = new System.Drawing.Size(200, 19);
            this.cdvCode.TabIndex = 0;
            this.cdvCode.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.cdvCode.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.cdvCode.CodeViewButtonClick += new System.EventHandler(this.cdvDesc_CodeViewButtonClick);
            // 
            // tlpVerticalCenterDesc
            // 
            this.tlpVerticalCenterDesc._UseOITheme = true;
            this.tlpVerticalCenterDesc.BackColor = System.Drawing.Color.Transparent;
            this.tlpVerticalCenterDesc.ColumnCount = 1;
            this.tlpVerticalCenterDesc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpVerticalCenterDesc.Controls.Add(this.txtDesc, 0, 1);
            this.tlpVerticalCenterDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpVerticalCenterDesc.Location = new System.Drawing.Point(0, 0);
            this.tlpVerticalCenterDesc.Margin = new System.Windows.Forms.Padding(0);
            this.tlpVerticalCenterDesc.Name = "tlpVerticalCenterDesc";
            this.tlpVerticalCenterDesc.RowCount = 3;
            this.tlpVerticalCenterDesc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpVerticalCenterDesc.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpVerticalCenterDesc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpVerticalCenterDesc.Size = new System.Drawing.Size(40, 40);
            this.tlpVerticalCenterDesc.TabIndex = 11;
            // 
            // txtDesc
            // 
            this.txtDesc._UseOITheme = true;
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            appearance29.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(37)))), ((int)(((byte)(60)))));
            appearance29.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            appearance29.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            appearance29.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            appearance29.FontData.BoldAsString = "True";
            appearance29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            appearance29.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.txtDesc.Appearance = appearance29;
            this.txtDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtDesc.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtDesc.Location = new System.Drawing.Point(0, 10);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(0);
            this.txtDesc.MaxLength = 100;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(40, 19);
            this.txtDesc.TabIndex = 0;
            this.txtDesc.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtDesc.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.txtDesc.UseSOIContextMenu = true;
            // 
            // pnlCode
            // 
            this.pnlCode.Controls.Add(this.tlpVerticalCenterCode);
            this.pnlCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCode.Location = new System.Drawing.Point(0, 0);
            this.pnlCode.Name = "pnlCode";
            this.pnlCode.Size = new System.Drawing.Size(200, 40);
            this.pnlCode.TabIndex = 1;
            // 
            // pnlMargin
            // 
            this.pnlMargin.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMargin.Location = new System.Drawing.Point(200, 0);
            this.pnlMargin.Name = "pnlMargin";
            this.pnlMargin.Size = new System.Drawing.Size(10, 40);
            this.pnlMargin.TabIndex = 2;
            // 
            // pnlDesc
            // 
            this.pnlDesc.Controls.Add(this.tlpVerticalCenterDesc);
            this.pnlDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesc.Location = new System.Drawing.Point(210, 0);
            this.pnlDesc.Name = "pnlDesc";
            this.pnlDesc.Size = new System.Drawing.Size(40, 40);
            this.pnlDesc.TabIndex = 3;
            // 
            // SOICodeViewDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlDesc);
            this.Controls.Add(this.pnlMargin);
            this.Controls.Add(this.pnlCode);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SOICodeViewDescription";
            this.Size = new System.Drawing.Size(250, 40);
            this.tlpVerticalCenterCode.ResumeLayout(false);
            this.tlpVerticalCenterCode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCode)).EndInit();
            this.tlpVerticalCenterDesc.ResumeLayout(false);
            this.tlpVerticalCenterDesc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).EndInit();
            this.pnlCode.ResumeLayout(false);
            this.pnlDesc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SOITableLayoutPanel tlpVerticalCenterCode;
        private SOICodeView cdvCode;
        private SOITableLayoutPanel tlpVerticalCenterDesc;
        private SOITextBox txtDesc;
        private System.Windows.Forms.Panel pnlCode;
        private System.Windows.Forms.Panel pnlMargin;
        private System.Windows.Forms.Panel pnlDesc;
    }
}
