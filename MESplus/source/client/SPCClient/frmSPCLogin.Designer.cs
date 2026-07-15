namespace Miracom.SPCClient
{
    partial class frmSPCLogin
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
            this.lblSPCTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lblSPCTitle);
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
            this.pnlMain.Controls.SetChildIndex(this.lblSPCTitle, 0);
            // 
            // lblSPCTitle
            // 
            this.lblSPCTitle.AutoSize = true;
            this.lblSPCTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSPCTitle.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSPCTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSPCTitle.Location = new System.Drawing.Point(7, 192);
            this.lblSPCTitle.Name = "lblSPCTitle";
            this.lblSPCTitle.Size = new System.Drawing.Size(190, 16);
            this.lblSPCTitle.TabIndex = 8;
            this.lblSPCTitle.Text = "Statistical Process Control";
            // 
            // frmSPCLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 344);
            this.Name = "frmSPCLogin";
            this.Text = "SPC - Login";
            this.Load += new System.EventHandler(this.frmSPCLogin_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSPCTitle;
    }
}
