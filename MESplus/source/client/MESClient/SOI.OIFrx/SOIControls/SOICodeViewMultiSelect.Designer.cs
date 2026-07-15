namespace SOI.OIFrx.SOIControls
{
    partial class SOICodeViewMultiSelect
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
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // SOICodeViewMultiSelect
            // 
            this.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.ReadOnly = true;
            this.Size = new System.Drawing.Size(100, 19);
            this.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.TextChanged += new System.EventHandler(this.SOICodeViewMultiSelect_TextChanged);
            this.Click += new System.EventHandler(this.SOICodeViewMultiSelect_Click);
            this.Enter += new System.EventHandler(this.SOICodeViewMultiSelect_Enter);
            this.Leave += new System.EventHandler(this.SOICodeViewMultiSelect_Leave);
            this.MouseEnter += new System.EventHandler(this.SOICodeViewMultiSelect_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.SOICodeViewMultiSelect_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
