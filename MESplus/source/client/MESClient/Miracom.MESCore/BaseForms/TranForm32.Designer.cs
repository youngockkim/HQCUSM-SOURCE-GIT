namespace Miracom.MESCore
{
    partial class TranForm32
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
            this.udcLotInfor = new Miracom.MESCore.Controls.udcFlexibleDocument();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Controls.Add(this.udcLotInfor);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm31";
            // 
            // udcLotInfor
            // 
            this.udcLotInfor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcLotInfor.Flow = null;
            this.udcLotInfor.FlowSeqNum = 0;
            this.udcLotInfor.Location = new System.Drawing.Point(3, 3);
            this.udcLotInfor.MatID = null;
            this.udcLotInfor.MatVer = 0;
            this.udcLotInfor.Name = "udcLotInfor";
            this.udcLotInfor.Oper = null;
            this.udcLotInfor.ProcStep = '\0';
            this.udcLotInfor.ResGroup = null;
            this.udcLotInfor.ResID = null;
            this.udcLotInfor.ResType = null;
            this.udcLotInfor.ScreenID = null;
            this.udcLotInfor.Size = new System.Drawing.Size(736, 441);
            this.udcLotInfor.SpreadAutoStretch = false;
            this.udcLotInfor.SpreadHorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.udcLotInfor.SpreadLocked = false;
            this.udcLotInfor.SpreadVerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.udcLotInfor.TabIndex = 0;
            this.udcLotInfor.UseDefaultID = false;
            // 
            // TranForm32
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "TranForm32";
            this.Text = "TranForm32";
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Controls.udcFlexibleDocument udcLotInfor;

    }
}