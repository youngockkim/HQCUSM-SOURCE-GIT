namespace Miracom.CliFrx
{
    partial class frmExportProgress
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
            this.progress = new System.Windows.Forms.ProgressBar();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.lblCurrentMessage = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // progress
            // 
            this.progress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progress.Location = new System.Drawing.Point(5, 43);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(432, 23);
            this.progress.TabIndex = 0;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.lblCurrentMessage);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox.Location = new System.Drawing.Point(5, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(432, 40);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            // 
            // lblCurrentMessage
            // 
            this.lblCurrentMessage.AutoSize = true;
            this.lblCurrentMessage.Location = new System.Drawing.Point(6, 17);
            this.lblCurrentMessage.Name = "lblCurrentMessage";
            this.lblCurrentMessage.Size = new System.Drawing.Size(132, 12);
            this.lblCurrentMessage.TabIndex = 0;
            this.lblCurrentMessage.Text = "Excel Export Progress";
            // 
            // frmExportProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 71);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.progress);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 105);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 105);
            this.Name = "frmExportProgress";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.ShowIcon = false;
            this.Text = "Export";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmExportProgress_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label lblCurrentMessage;
        private System.Windows.Forms.Timer timer;
    }
}