namespace Miracom.MESCore
{
    partial class TranForm02
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TranForm02));
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlTranTop = new System.Windows.Forms.Panel();
            this.grpTranTop = new System.Windows.Forms.GroupBox();
            this.pnlTranCenter = new System.Windows.Forms.Panel();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlTranTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlTranCenter);
            this.pnlCenter.Controls.Add(this.pnlTranTop);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm01";
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(8, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 0;
            // 
            // pnlTranTop
            // 
            this.pnlTranTop.Controls.Add(this.grpTranTop);
            this.pnlTranTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTranTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTranTop.Name = "pnlTranTop";
            this.pnlTranTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlTranTop.Size = new System.Drawing.Size(742, 62);
            this.pnlTranTop.TabIndex = 0;
            // 
            // grpTranTop
            // 
            this.grpTranTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTranTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTranTop.Location = new System.Drawing.Point(3, 0);
            this.grpTranTop.Name = "grpTranTop";
            this.grpTranTop.Size = new System.Drawing.Size(736, 62);
            this.grpTranTop.TabIndex = 0;
            this.grpTranTop.TabStop = false;
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTranCenter.Location = new System.Drawing.Point(0, 62);
            this.pnlTranCenter.Name = "pnlTranCenter";
            this.pnlTranCenter.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlTranCenter.Size = new System.Drawing.Size(742, 444);
            this.pnlTranCenter.TabIndex = 1;
            // 
            // TranForm02
            // 
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "TranForm02";
            this.Text = "TranForm02";
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTranTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button btnRefresh;
        protected System.Windows.Forms.Panel pnlTranTop;
        protected System.Windows.Forms.Panel pnlTranCenter;
        protected System.Windows.Forms.GroupBox grpTranTop;
    }
}
