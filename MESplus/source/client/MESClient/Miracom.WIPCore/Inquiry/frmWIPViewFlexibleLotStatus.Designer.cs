namespace Miracom.WIPCore
{
    partial class frmWIPViewFlexibleLotStatus
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
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.udcLotInfor = new Miracom.MESCore.Controls.udcFlexibleScreen();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.Size = new System.Drawing.Size(742, 43);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.txtLotID);
            this.grpOption.Controls.Add(this.lblLotID);
            this.grpOption.Size = new System.Drawing.Size(742, 43);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.udcLotInfor);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 43);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 470);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "ViewForm01";
            // 
            // txtLotID
            // 
            this.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLotID.Location = new System.Drawing.Point(117, 15);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(200, 20);
            this.txtLotID.TabIndex = 3;
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(12, 18);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            this.lblLotID.TabIndex = 2;
            this.lblLotID.Text = "Lot ID";
            // 
            // udcLotInfor
            // 
            this.udcLotInfor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcLotInfor.Flow = null;
            this.udcLotInfor.FlowSeqNum = 0;
            this.udcLotInfor.Location = new System.Drawing.Point(0, 0);
            this.udcLotInfor.MatID = null;
            this.udcLotInfor.MatVer = 0;
            this.udcLotInfor.Name = "udcLotInfor";
            this.udcLotInfor.Oper = null;
            this.udcLotInfor.ProcStep = '\0';
            this.udcLotInfor.ResGroup = null;
            this.udcLotInfor.ResID = null;
            this.udcLotInfor.ResType = null;
            this.udcLotInfor.ScreenID = null;
            this.udcLotInfor.Size = new System.Drawing.Size(742, 470);
            this.udcLotInfor.TabIndex = 0;
            // 
            // frmWIPViewFlexibleLotStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPViewFlexibleLotStatus";
            this.Text = "View Flexible Lot Status";
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.Label lblLotID;
        private MESCore.Controls.udcFlexibleScreen udcLotInfor;

    }
}