using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System;
using Miracom.CliFrx;
using Miracom.MESCore;
//-----------------------------------------------------------------------------
//
//   System      : FMBClient
//   File Name   : frmSPCAbout.vb
//   Description : About
//
//   FMB Version : 1.0.0
//
//   Function List
//       -
//
//   Detail Description
//       -
//
//   History
//       - 2005-03-03 : Created by H.K.Kim
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
namespace Miracom.SPCCore
{
    public class frmSPCAbout : System.Windows.Forms.Form
    {
        
        #region " Windows Form Auto Generated Code "
        
        public frmSPCAbout()
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
        



        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.Label lblVersion;
        internal System.Windows.Forms.Label lblDesc;
        internal System.Windows.Forms.LinkLabel lnkWebSite;
        internal System.Windows.Forms.PictureBox picLogin;
        internal System.Windows.Forms.Button btnOK;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCAbout));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lnkWebSite = new System.Windows.Forms.LinkLabel();
            this.picLogin = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(166, 218);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(124, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "SPCClient";
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(166, 237);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(124, 16);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Version 4.2.0";
            // 
            // lblDesc
            // 
            this.lblDesc.Location = new System.Drawing.Point(166, 256);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(152, 16);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Statistical Process Control";
            // 
            // lnkWebSite
            // 
            this.lnkWebSite.AutoSize = true;
            this.lnkWebSite.LinkArea = new System.Windows.Forms.LinkArea(0, 25);
            this.lnkWebSite.Location = new System.Drawing.Point(166, 275);
            this.lnkWebSite.Name = "lnkWebSite";
            this.lnkWebSite.Size = new System.Drawing.Size(136, 13);
            this.lnkWebSite.TabIndex = 7;
            this.lnkWebSite.TabStop = true;
            this.lnkWebSite.Text = "http://www.miracom.co.kr/";
            this.lnkWebSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWebSite_LinkClicked);
            // 
            // picLogin
            // 
            this.picLogin.BackColor = System.Drawing.Color.White;
            this.picLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picLogin.Image = ((System.Drawing.Image)(resources.GetObject("picLogin.Image")));
            this.picLogin.Location = new System.Drawing.Point(0, 0);
            this.picLogin.Name = "picLogin";
            this.picLogin.Size = new System.Drawing.Size(457, 343);
            this.picLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLogin.TabIndex = 9;
            this.picLogin.TabStop = false;
            this.picLogin.Click += new System.EventHandler(this.picLogin_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(359, 306);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 26);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            // 
            // frmSPCAbout
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(457, 343);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lnkWebSite);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picLogin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(457, 343);
            this.Name = "frmSPCAbout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion
        
        #region " Event Implementations"
        
        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Close();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAbout.btnOK_Click()" + "\r\n" + ex.Message, "FMB Client", MessageBoxButtons.OK, 1);
            }
            
        }
        
        private void lnkWebSite_LinkClicked(System.Object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            
            try
            {
                System.Diagnostics.Process.Start(lnkWebSite.Text.Substring(lnkWebSite.LinkArea.Start, lnkWebSite.LinkArea.Length));
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAbout.lnkWebSite_LinkClicked()" + "\r\n" + ex.Message, "FMB Client", MessageBoxButtons.OK, 1);
            }
            
        }
        
        #endregion

        private void picLogin_Click(object sender, EventArgs e)
        {

        }

        
    }
    
}
