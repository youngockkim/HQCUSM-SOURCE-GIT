namespace MESClient
{
    partial class frmLogin
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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pictureBox3);
            this.pnlMain.Controls.SetChildIndex(this.pictureBox3, 0);
            this.pnlMain.Controls.SetChildIndex(this.btnOption, 0);
            this.pnlMain.Controls.SetChildIndex(this.btnOK, 0);
            this.pnlMain.Controls.SetChildIndex(this.btnExit, 0);
            this.pnlMain.Controls.SetChildIndex(this.lblFactory, 0);
            this.pnlMain.Controls.SetChildIndex(this.lblUserID, 0);
            this.pnlMain.Controls.SetChildIndex(this.lblPassword, 0);
            this.pnlMain.Controls.SetChildIndex(this.txtFactory, 0);
            this.pnlMain.Controls.SetChildIndex(this.txtUserID, 0);
            this.pnlMain.Controls.SetChildIndex(this.txtPassword, 0);
            this.pnlMain.Controls.SetChildIndex(this.lblVersion, 0);
            this.pnlMain.Controls.SetChildIndex(this.lblSiteID, 0);
            this.pnlMain.Controls.SetChildIndex(this.txtSiteID, 0);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox3.Image = global::MESClient.Properties.Resources.QCELL_LOGO;
            this.pictureBox3.Location = new System.Drawing.Point(7, 284);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(159, 53);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // frmLogin
            // 
            this.ClientSize = new System.Drawing.Size(456, 344);
            this.Name = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox3;

    }
}