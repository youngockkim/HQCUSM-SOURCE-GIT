namespace BOI.OIFrx.BOIControls
{
    partial class H101TunerStatusBar
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
            this.lblOnOff = new SOI.OIFrx.SOIControls.SOILabel(this.components);
            this.SuspendLayout();
            // 
            // lblOnOff
            // 
            this.lblOnOff._UseConvertLanguage = true;
            this.lblOnOff._UseOITheme = false;
            this.lblOnOff._UseStyle = SOI.OIFrx.SOILabelStyle.KeyStyle;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(195)))), ((int)(((byte)(120)))));
            appearance8.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance8.FontData.BoldAsString = "True";
            appearance8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            appearance8.TextHAlignAsString = "Center";
            appearance8.TextVAlignAsString = "Middle";
            this.lblOnOff.Appearance = appearance8;
            this.lblOnOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOnOff.Location = new System.Drawing.Point(0, 0);
            this.lblOnOff.Margin = new System.Windows.Forms.Padding(0);
            this.lblOnOff.Name = "lblOnOff";
            this.lblOnOff.Size = new System.Drawing.Size(80, 26);
            this.lblOnOff.TabIndex = 8;
            this.lblOnOff.Text = "H101";
            this.lblOnOff.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.lblOnOff.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.lblOnOff.TextChanged += new System.EventHandler(this.lblOnOff_TextChanged);
            this.lblOnOff.Click += new System.EventHandler(this.lblOnOff_Click);
            // 
            // H101TunerStatusBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblOnOff);
            this.Name = "H101TunerStatusBar";
            this.Size = new System.Drawing.Size(80, 26);
            this.Load += new System.EventHandler(this.H101TunerStatusBar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SOI.OIFrx.SOIControls.SOILabel lblOnOff;
        
    }
}
