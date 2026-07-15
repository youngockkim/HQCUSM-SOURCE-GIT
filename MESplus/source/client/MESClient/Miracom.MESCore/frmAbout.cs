
using Miracom.MsgHandler;
using System.Data;
using Miracom.CliFrx;
using System.Collections;

using System.Diagnostics;
using System;


namespace Miracom.MESCore
{
    public class frmAbout : System.Windows.Forms.Form
    {
        #region " Constant Definition "
        /* Added By YJJung 150721 Product Version 추가 */
        private const string PRODUCT_VERSION = "V5.3.6.1";

        #endregion

        #region " Windows Form auto generated code "

        public frmAbout()
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




        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Label lblVersion;
        public System.Windows.Forms.Label lblDescription;
        public System.Windows.Forms.LinkLabel lnkWebSite;
        public System.Windows.Forms.Label lblProductVer;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picAbout;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lnkWebSite = new System.Windows.Forms.LinkLabel();
            this.lblProductVer = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picAbout = new System.Windows.Forms.PictureBox();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAbout)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(188, 213);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(141, 13);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Site Version : MES_V1.0.0.0";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(188, 250);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(162, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Manufacturing Execution System";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(359, 278);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 26);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lnkWebSite
            // 
            this.lnkWebSite.AutoSize = true;
            this.lnkWebSite.LinkArea = new System.Windows.Forms.LinkArea(0, 25);
            this.lnkWebSite.Location = new System.Drawing.Point(188, 269);
            this.lnkWebSite.Name = "lnkWebSite";
            this.lnkWebSite.Size = new System.Drawing.Size(136, 13);
            this.lnkWebSite.TabIndex = 6;
            this.lnkWebSite.TabStop = true;
            this.lnkWebSite.Text = "http://www.miracom.co.kr/";
            this.lnkWebSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWebSite_LinkClicked);
            // 
            // lblProductVer
            // 
            this.lblProductVer.AutoSize = true;
            this.lblProductVer.Location = new System.Drawing.Point(188, 232);
            this.lblProductVer.Name = "lblProductVer";
            this.lblProductVer.Size = new System.Drawing.Size(160, 13);
            this.lblProductVer.TabIndex = 8;
            this.lblProductVer.Text = "Product Version : MES_V1.0.0.0";
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.pictureBox1);
            this.pnlMain.Controls.Add(this.picAbout);
            this.pnlMain.Controls.Add(this.lblProductVer);
            this.pnlMain.Controls.Add(this.lnkWebSite);
            this.pnlMain.Controls.Add(this.lblDescription);
            this.pnlMain.Controls.Add(this.lblVersion);
            this.pnlMain.Controls.Add(this.btnOK);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(457, 314);
            this.pnlMain.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(29, 216);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // picAbout
            // 
            this.picAbout.BackColor = System.Drawing.Color.Transparent;
            this.picAbout.Dock = System.Windows.Forms.DockStyle.Top;
            this.picAbout.Image = ((System.Drawing.Image)(resources.GetObject("picAbout.Image")));
            this.picAbout.Location = new System.Drawing.Point(0, 0);
            this.picAbout.Name = "picAbout";
            this.picAbout.Size = new System.Drawing.Size(455, 210);
            this.picAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picAbout.TabIndex = 9;
            this.picAbout.TabStop = false;
            // 
            // frmAbout
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(457, 314);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAbout)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            
            this.Close();
            
        }
        
        private void lnkWebSite_LinkClicked(System.Object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            
            try
            {
                System.Diagnostics.Process.Start(lnkWebSite.Text.Substring(lnkWebSite.LinkArea.Start, lnkWebSite.LinkArea.Length));
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.ToString());
            }
            
        }
        
        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "Site Version : " + MPGV.gsClientVersion;
            /* Added By YJJung 150721 Product Version 추가 */
            lblProductVer.Text = "Product Version : " + PRODUCT_VERSION;
        }
    }
    
}
