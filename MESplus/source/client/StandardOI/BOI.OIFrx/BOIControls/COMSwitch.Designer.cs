namespace BOI.OIFrx.BOIControls
{
    partial class COMSwitch
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.soiTableLayoutPanel1 = new SOI.OIFrx.SOIControls.SOITableLayoutPanel(this.components);
            this.lblOnOffCOM4 = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.lblOnOffCOM3 = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.lblOnOffCOM2 = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.btnSetup = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.lblOnOffCOM1 = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.soiTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // soiTableLayoutPanel1
            // 
            this.soiTableLayoutPanel1._UseOITheme = true;
            this.soiTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.soiTableLayoutPanel1.ColumnCount = 9;
            this.soiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.soiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.soiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.soiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.soiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.soiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.soiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.soiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.soiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.soiTableLayoutPanel1.Controls.Add(this.lblOnOffCOM4, 6, 0);
            this.soiTableLayoutPanel1.Controls.Add(this.lblOnOffCOM3, 4, 0);
            this.soiTableLayoutPanel1.Controls.Add(this.lblOnOffCOM2, 2, 0);
            this.soiTableLayoutPanel1.Controls.Add(this.btnSetup, 8, 0);
            this.soiTableLayoutPanel1.Controls.Add(this.lblOnOffCOM1, 0, 0);
            this.soiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.soiTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.soiTableLayoutPanel1.Name = "soiTableLayoutPanel1";
            this.soiTableLayoutPanel1.RowCount = 1;
            this.soiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel1.Size = new System.Drawing.Size(231, 21);
            this.soiTableLayoutPanel1.TabIndex = 0;
            // 
            // lblOnOffCOM4
            // 
            this.lblOnOffCOM4._UseConvertLanguage = true;
            this.lblOnOffCOM4._UseOITheme = false;
            this.lblOnOffCOM4._UseStyle = SOI.OIFrx.SOILabelStyle.KeyStyle;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            appearance4.FontData.BoldAsString = "True";
            appearance4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            appearance4.TextHAlignAsString = "Center";
            appearance4.TextVAlignAsString = "Middle";
            this.lblOnOffCOM4.Appearance = appearance4;
            this.lblOnOffCOM4.Font = new System.Drawing.Font("굴림", 8F);
            this.lblOnOffCOM4.Location = new System.Drawing.Point(138, 0);
            this.lblOnOffCOM4.Margin = new System.Windows.Forms.Padding(0);
            this.lblOnOffCOM4.Name = "lblOnOffCOM4";
            this.lblOnOffCOM4.Size = new System.Drawing.Size(44, 20);
            this.lblOnOffCOM4.TabIndex = 11;
            this.lblOnOffCOM4.Text = "COM";
            this.lblOnOffCOM4.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.lblOnOffCOM4.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblOnOffCOM3
            // 
            this.lblOnOffCOM3._UseConvertLanguage = true;
            this.lblOnOffCOM3._UseOITheme = false;
            this.lblOnOffCOM3._UseStyle = SOI.OIFrx.SOILabelStyle.KeyStyle;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            appearance2.FontData.BoldAsString = "True";
            appearance2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.lblOnOffCOM3.Appearance = appearance2;
            this.lblOnOffCOM3.Font = new System.Drawing.Font("굴림", 8F);
            this.lblOnOffCOM3.Location = new System.Drawing.Point(92, 0);
            this.lblOnOffCOM3.Margin = new System.Windows.Forms.Padding(0);
            this.lblOnOffCOM3.Name = "lblOnOffCOM3";
            this.lblOnOffCOM3.Size = new System.Drawing.Size(44, 20);
            this.lblOnOffCOM3.TabIndex = 12;
            this.lblOnOffCOM3.Text = "COM";
            this.lblOnOffCOM3.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.lblOnOffCOM3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblOnOffCOM2
            // 
            this.lblOnOffCOM2._UseConvertLanguage = true;
            this.lblOnOffCOM2._UseOITheme = false;
            this.lblOnOffCOM2._UseStyle = SOI.OIFrx.SOILabelStyle.KeyStyle;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            appearance8.FontData.BoldAsString = "True";
            appearance8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            appearance8.TextHAlignAsString = "Center";
            appearance8.TextVAlignAsString = "Middle";
            this.lblOnOffCOM2.Appearance = appearance8;
            this.lblOnOffCOM2.Font = new System.Drawing.Font("굴림", 8F);
            this.lblOnOffCOM2.Location = new System.Drawing.Point(46, 0);
            this.lblOnOffCOM2.Margin = new System.Windows.Forms.Padding(0);
            this.lblOnOffCOM2.Name = "lblOnOffCOM2";
            this.lblOnOffCOM2.Size = new System.Drawing.Size(44, 20);
            this.lblOnOffCOM2.TabIndex = 13;
            this.lblOnOffCOM2.Text = "COM";
            this.lblOnOffCOM2.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.lblOnOffCOM2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // btnSetup
            // 
            this.btnSetup._UseConvertLanguage = true;
            this.btnSetup._UseOITheme = false;
            this.btnSetup._UseStyle = SOI.OIFrx.SOILabelStyle.KeyStyle;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            appearance3.FontData.BoldAsString = "True";
            appearance3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.btnSetup.Appearance = appearance3;
            this.btnSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetup.Font = new System.Drawing.Font("굴림", 8F);
            this.btnSetup.Location = new System.Drawing.Point(184, 0);
            this.btnSetup.Margin = new System.Windows.Forms.Padding(0);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(44, 20);
            this.btnSetup.TabIndex = 14;
            this.btnSetup.Text = "Setup";
            this.btnSetup.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnSetup.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // lblOnOffCOM1
            // 
            this.lblOnOffCOM1._UseConvertLanguage = true;
            this.lblOnOffCOM1._UseOITheme = false;
            this.lblOnOffCOM1._UseStyle = SOI.OIFrx.SOILabelStyle.KeyStyle;
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            appearance1.FontData.BoldAsString = "True";
            appearance1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.lblOnOffCOM1.Appearance = appearance1;
            this.lblOnOffCOM1.Font = new System.Drawing.Font("굴림", 8F);
            this.lblOnOffCOM1.Location = new System.Drawing.Point(0, 0);
            this.lblOnOffCOM1.Margin = new System.Windows.Forms.Padding(0);
            this.lblOnOffCOM1.Name = "lblOnOffCOM1";
            this.lblOnOffCOM1.Size = new System.Drawing.Size(44, 20);
            this.lblOnOffCOM1.TabIndex = 10;
            this.lblOnOffCOM1.Text = "COM";
            this.lblOnOffCOM1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.lblOnOffCOM1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // COMSwitch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.soiTableLayoutPanel1);
            this.Name = "COMSwitch";
            this.Size = new System.Drawing.Size(231, 21);
            this.Load += new System.EventHandler(this.COMSwitch_Load);
            this.soiTableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SOI.OIFrx.SOIControls.SOITableLayoutPanel soiTableLayoutPanel1;
        private SOI.OIFrx.SOIControls.SOILabel lblOnOffCOM4;
        private SOI.OIFrx.SOIControls.SOILabel lblOnOffCOM3;
        private SOI.OIFrx.SOIControls.SOILabel lblOnOffCOM2;
        private SOI.OIFrx.SOIControls.SOILabel lblOnOffCOM1;
        private SOI.OIFrx.SOIControls.SOILabel btnSetup;



    }
}
