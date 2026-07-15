namespace SOI.OIFrx
{
    partial class UIBaseForm01
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(7, 9);
            this.btnRefresh.Size = new System.Drawing.Size(21, 26);
            // 
            // pnlTranTop
            // 
            this.pnlTranTop.Size = new System.Drawing.Size(734, 67);
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Location = new System.Drawing.Point(0, 67);
            this.pnlTranCenter.Size = new System.Drawing.Size(734, 482);
            // 
            // grpTranTop
            // 
            this.grpTranTop.Size = new System.Drawing.Size(728, 67);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(560, 8);
            this.btnProcess.Size = new System.Drawing.Size(75, 28);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(647, 8);
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 549);
            this.pnlBottom.Size = new System.Drawing.Size(734, 43);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(734, 549);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm02";
            // 
            // TranForm50
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 592);
            this.MinimumSize = new System.Drawing.Size(645, 38);
            this.Name = "UIBaseForm01";
            this.Text = "UIBaseForm01";
            this.Activated += new System.EventHandler(this.UIBaseForm01_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UIBaseForm01_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UIBaseForm01_FormClosed);
            this.Load += new System.EventHandler(this.UIBaseForm01_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UIBaseForm01_KeyUp);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion




    }
}