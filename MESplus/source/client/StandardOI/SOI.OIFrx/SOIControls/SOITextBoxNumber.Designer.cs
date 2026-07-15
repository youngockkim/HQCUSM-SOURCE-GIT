namespace SOI.OIFrx.SOIControls
{
    partial class SOITextBoxNumber
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
            // SOITextBoxNumber
            // 
            this.FormatString = "N0";
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.MaskInput = "{LOC}nn,nnn,nnn";
            this.Nullable = true;
            this.PromptChar = ' ';
            this.Size = new System.Drawing.Size(100, 21);
            this.ValueChanged += new System.EventHandler(this.SOITextBoxNumber_ValueChanged);
            this.Enter += new System.EventHandler(this.SOITextBoxNumber_Enter);
            this.Leave += new System.EventHandler(this.SOITextBoxNumber_Leave);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SOITextBoxNumber_MouseClick);
            this.MouseEnter += new System.EventHandler(this.SOITextBoxNumber_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.SOITextBoxNumber_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
