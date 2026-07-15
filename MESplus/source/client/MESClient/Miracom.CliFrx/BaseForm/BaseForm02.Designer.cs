namespace Miracom.CliFrx
{
    partial class BaseForm02
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlTop.Controls.Add(this.lblFormTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(2);
            this.pnlTop.Size = new System.Drawing.Size(742, 0);
            this.pnlTop.TabIndex = 0;
            this.pnlTop.Visible = false;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblFormTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFormTitle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFormTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFormTitle.Location = new System.Drawing.Point(2, 2);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(738, 0);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Form Title";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFormTitle.DoubleClick += new System.EventHandler(this.lblFormTitle_DoubleClick);
            // 
            // BaseForm02
            // 
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlTop);
            this.Name = "BaseForm02";
            this.Text = "BaseForm02";
            this.Resize += new System.EventHandler(this.BaseForm_Resize);
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlTop;
        protected System.Windows.Forms.Label lblFormTitle;
    }
}
