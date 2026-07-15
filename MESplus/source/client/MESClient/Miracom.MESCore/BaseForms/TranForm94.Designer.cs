namespace Miracom.MESCore
{
    partial class TranForm94
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
            this.pnlTranTime = new System.Windows.Forms.Panel();
            this.lblTranTime = new System.Windows.Forms.Label();
            this.txtTranDateTime = new System.Windows.Forms.TextBox();
            this.dtpTranTime = new System.Windows.Forms.DateTimePicker();
            this.dtpTranDate = new System.Windows.Forms.DateTimePicker();
            this.tabTran = new System.Windows.Forms.TabControl();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlTranTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.Size = new System.Drawing.Size(777, 23);
            // 
            // pnlTranTop
            // 
            this.pnlTranTop.Size = new System.Drawing.Size(915, 62);
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Controls.Add(this.tabTran);
            this.pnlTranCenter.Size = new System.Drawing.Size(915, 564);
            // 
            // grpTranTop
            // 
            this.grpTranTop.Controls.Add(this.pnlTranTime);
            this.grpTranTop.Size = new System.Drawing.Size(909, 62);
            this.grpTranTop.Controls.SetChildIndex(this.lblLotID, 0);
            this.grpTranTop.Controls.SetChildIndex(this.lblLotDesc, 0);
            this.grpTranTop.Controls.SetChildIndex(this.txtLotID, 0);
            this.grpTranTop.Controls.SetChildIndex(this.txtLotDesc, 0);
            this.grpTranTop.Controls.SetChildIndex(this.pnlTranTime, 0);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(731, 7);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(822, 7);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 626);
            this.pnlBottom.Size = new System.Drawing.Size(915, 40);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(915, 626);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(915, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Size = new System.Drawing.Size(911, 0);
            this.lblFormTitle.Text = "TranForm03";
            // 
            // pnlTranTime
            // 
            this.pnlTranTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTranTime.Controls.Add(this.lblTranTime);
            this.pnlTranTime.Controls.Add(this.txtTranDateTime);
            this.pnlTranTime.Controls.Add(this.dtpTranTime);
            this.pnlTranTime.Controls.Add(this.dtpTranDate);
            this.pnlTranTime.Location = new System.Drawing.Point(428, 12);
            this.pnlTranTime.Name = "pnlTranTime";
            this.pnlTranTime.Size = new System.Drawing.Size(296, 20);
            this.pnlTranTime.TabIndex = 4;
            // 
            // lblTranTime
            // 
            this.lblTranTime.AutoSize = true;
            this.lblTranTime.Location = new System.Drawing.Point(15, 1);
            this.lblTranTime.Name = "lblTranTime";
            this.lblTranTime.Size = new System.Drawing.Size(118, 17);
            this.lblTranTime.TabIndex = 3;
            this.lblTranTime.Text = "Transcation Time";
            // 
            // txtTranDateTime
            // 
            this.txtTranDateTime.BackColor = System.Drawing.SystemColors.Window;
            this.txtTranDateTime.Location = new System.Drawing.Point(139, -2);
            this.txtTranDateTime.Name = "txtTranDateTime";
            this.txtTranDateTime.Size = new System.Drawing.Size(157, 23);
            this.txtTranDateTime.TabIndex = 1;
            this.txtTranDateTime.TabStop = false;
            // 
            // dtpTranTime
            // 
            this.dtpTranTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTranTime.Checked = false;
            this.dtpTranTime.CustomFormat = "HH:mm:ss";
            this.dtpTranTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTranTime.Location = new System.Drawing.Point(225, 0);
            this.dtpTranTime.Name = "dtpTranTime";
            this.dtpTranTime.ShowUpDown = true;
            this.dtpTranTime.Size = new System.Drawing.Size(71, 23);
            this.dtpTranTime.TabIndex = 2;
            // 
            // dtpTranDate
            // 
            this.dtpTranDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTranDate.Checked = false;
            this.dtpTranDate.CustomFormat = "";
            this.dtpTranDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTranDate.Location = new System.Drawing.Point(139, 0);
            this.dtpTranDate.Name = "dtpTranDate";
            this.dtpTranDate.Size = new System.Drawing.Size(86, 23);
            this.dtpTranDate.TabIndex = 2;
            // 
            // tabTran
            // 
            this.tabTran.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTran.Location = new System.Drawing.Point(3, 3);
            this.tabTran.Name = "tabTran";
            this.tabTran.SelectedIndex = 0;
            this.tabTran.Size = new System.Drawing.Size(909, 561);
            this.tabTran.TabIndex = 0;
            // 
            // TranForm94
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.ClientSize = new System.Drawing.Size(915, 666);
            this.Name = "TranForm94";
            this.Text = "TranForm94";
            this.Load += new System.EventHandler(this.TranForm94_Load);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlTranTime;
        protected System.Windows.Forms.TextBox txtTranDateTime;
        protected System.Windows.Forms.DateTimePicker dtpTranTime;
        protected System.Windows.Forms.DateTimePicker dtpTranDate;
        protected System.Windows.Forms.TabControl tabTran;
        private System.Windows.Forms.Label lblTranTime;
    }
}
