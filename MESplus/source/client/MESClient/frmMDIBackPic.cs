
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;

namespace MESClient
{
    public class frmMDIBackPic : System.Windows.Forms.Form
    {
        
        public string gstrImageFileName;
        
        #region " Windows Form auto generated code "
        
        public frmMDIBackPic()
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
        



        internal System.Windows.Forms.PictureBox pbxBackImage;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.pbxBackImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBackImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxBackImage
            // 
            this.pbxBackImage.Image = global::MESClient.Properties.Resources.MAINPIC1;
            this.pbxBackImage.Location = new System.Drawing.Point(4, 4);
            this.pbxBackImage.Name = "pbxBackImage";
            this.pbxBackImage.Size = new System.Drawing.Size(695, 430);
            this.pbxBackImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxBackImage.TabIndex = 0;
            this.pbxBackImage.TabStop = false;
            this.pbxBackImage.SizeChanged += new System.EventHandler(this.pbxBackImage_SizeChanged);
            // 
            // frmMDIBackPic
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(794, 470);
            this.Controls.Add(this.pbxBackImage);
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMDIBackPic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmMDIBackground";
            this.Load += new System.EventHandler(this.frmMDIBackPic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxBackImage)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        private void frmMDIBackPic_Load(System.Object sender, System.EventArgs e)
        {
            
            if (gstrImageFileName != "")
            {
                pbxBackImage.Image = System.Drawing.Image.FromFile(gstrImageFileName);
               
            }
            
            this.Height = pbxBackImage.Height;
            this.Width = pbxBackImage.Width;
            
            pbxBackImage.Left = 0;
            pbxBackImage.Top = 0;
            
        }
        
        private void pbxBackImage_SizeChanged(System.Object sender, System.EventArgs e)
        {
            this.Height = pbxBackImage.Height;
            this.Width = pbxBackImage.Width;
        }
    }
    
}
