namespace Miracom.MESCore
{
    partial class TranForm03
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
            this.txtLotDesc = new System.Windows.Forms.TextBox();
            this.lblLotDesc = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.pnlTranTop.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTranTop
            // 
            this.grpTranTop.Controls.Add(this.txtLotDesc);
            this.grpTranTop.Controls.Add(this.lblLotDesc);
            this.grpTranTop.Controls.Add(this.txtLotID);
            this.grpTranTop.Controls.Add(this.lblLotID);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm02";
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLotDesc.Location = new System.Drawing.Point(120, 36);
            this.txtLotDesc.MaxLength = 200;
            this.txtLotDesc.Name = "txtLotDesc";
            this.txtLotDesc.ReadOnly = true;
            this.txtLotDesc.Size = new System.Drawing.Size(604, 20);
            this.txtLotDesc.TabIndex = 3;
            // 
            // lblLotDesc
            // 
            this.lblLotDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotDesc.Location = new System.Drawing.Point(15, 38);
            this.lblLotDesc.Name = "lblLotDesc";
            this.lblLotDesc.Size = new System.Drawing.Size(100, 14);
            this.lblLotDesc.TabIndex = 2;
            this.lblLotDesc.Text = "Description";
            this.lblLotDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLotID
            // 
            this.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLotID.Location = new System.Drawing.Point(120, 12);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(200, 20);
            this.txtLotID.TabIndex = 1;
            // 
            // lblLotID
            // 
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(15, 14);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(100, 14);
            this.lblLotID.TabIndex = 0;
            this.lblLotID.Text = "Lot ID";
            this.lblLotID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TranForm03
            // 
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "TranForm03";
            this.Text = "TranForm03";
            this.pnlTranTop.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lblLotID;
        protected System.Windows.Forms.Label lblLotDesc;
        protected System.Windows.Forms.TextBox txtLotID;
        protected System.Windows.Forms.TextBox txtLotDesc;
    }
}
