
using System.Data;
using System.Collections;
using System.Diagnostics;
using System;

namespace Miracom.CliFrx
{
    public class frmStatusMessageBox : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmStatusMessageBox()
        {
            
            
            InitializeComponent();
            
            
            
        }
        
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components == null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        
        private System.ComponentModel.Container components = null;
        



        private System.Windows.Forms.Label lblMessage;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(5, 5);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(500, 36);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmStatusMessageBox
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(510, 46);
            this.Controls.Add(this.lblMessage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "frmStatusMessageBox";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStatusMessageBox";
            this.TopMost = true;
            this.Closed += new System.EventHandler(this.frmStatusMessageBox_Closed);
            this.ResumeLayout(false);

        }
        
        #endregion
        
        private void frmStatusMessageBox_Closed(object sender, System.EventArgs e)
        {
            
            this.Dispose();
            
        }
        
        public void SetMessage(string sMsg)
        {

            lblMessage.Text = MPCF.Trim(sMsg);
            
        }
    }
    
}
