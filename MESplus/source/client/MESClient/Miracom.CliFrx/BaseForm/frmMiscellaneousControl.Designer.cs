namespace Miracom.CliFrx
{
    partial class frmMiscellaneousControl
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMiscellaneousControl));
            this.imlUpDown = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imlUpDown
            // 
            this.imlUpDown.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlUpDown.ImageStream")));
            this.imlUpDown.TransparentColor = System.Drawing.Color.Transparent;
            this.imlUpDown.Images.SetKeyName(0, "");
            this.imlUpDown.Images.SetKeyName(1, "");
            // 
            // frmMiscellaneousControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 375);
            this.Name = "frmMiscellaneousControl";
            this.Text = "frmMiscellaneousControl";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ImageList imlUpDown;

    }
}