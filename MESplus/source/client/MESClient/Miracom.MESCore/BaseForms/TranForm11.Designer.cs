namespace Miracom.MESCore
{
    partial class TranForm11
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TranForm11));
            this.pnlTranTop = new System.Windows.Forms.Panel();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.pnlTranCenter = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlTranTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
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
            // pnlTranTop
            // 
            this.pnlTranTop.Controls.Add(this.grpOption);
            this.pnlTranTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTranTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTranTop.Name = "pnlTranTop";
            this.pnlTranTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlTranTop.Size = new System.Drawing.Size(742, 62);
            this.pnlTranTop.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOption.Location = new System.Drawing.Point(3, 0);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(736, 62);
            this.grpOption.TabIndex = 0;
            this.grpOption.TabStop = false;
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
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(12, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 6;
            // 
            // TranForm11
            // 
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "TranForm11";
            this.Text = "TranForm11";
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTranTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlTranTop;
        protected System.Windows.Forms.Panel pnlTranCenter;
        protected System.Windows.Forms.GroupBox grpOption;
        protected System.Windows.Forms.Button btnExcel;
    }
}
