
using System.Data;
using System.Collections;

using System.Diagnostics;
using System;
using System.Windows.Forms;
using Miracom.UI.Controls;
using Miracom.CliFrx;
using Miracom.MESCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmUTLPublishMessage.vb
//   Description : MES Cient Form Publish Message Class
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-08-10 : Created by WKIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


namespace Miracom.UTLCore
{
    public class frmUTLPublishMessage : Miracom.CliFrx.BaseForm04
    {
        
        #region " Windows Form auto generated code "
        delegate void SetMessageDelegate(string sMsg);

        private SetMessageDelegate _SetMessageDelegate;
        public frmUTLPublishMessage()
        {
            
            
            InitializeComponent();
            
            
            _SetMessageDelegate = new SetMessageDelegate(SetMessage);
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
        



        public System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnClear;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.txtMessage);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Message";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnClear);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClear, 0);
            // 
            // txtMessage
            // 
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Location = new System.Drawing.Point(3, 3);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(736, 503);
            this.txtMessage.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClear.Location = new System.Drawing.Point(558, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 26);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmUTLPublishMessage
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.MinimumSize = new System.Drawing.Size(0, 0);
            this.Name = "frmUTLPublishMessage";
            this.Text = "Message";
            this.Activated += new System.EventHandler(this.frmUTLPublishMessage_Activated);
            this.Load += new System.EventHandler(this.frmUTLPublishMessage_Load);
            this.pnlCenter.ResumeLayout(false);
            this.pnlCenter.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition"
        
        public bool b_load_flag;
        
        #endregion
        
        #region " Event Implematations"
        
        private void frmUTLPublishMessage_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                Control.ControlCollection temp_object = this.Controls;
                MPCF.SetTextboxStyle( temp_object);
                
                this.MinimumSize = new System.Drawing.Size(0, 0);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Dispose();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmUTLPublishMessage.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        private void frmUTLPublishMessage_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    if (MPGV.gsMessage != "" && MPGV.gsMessage != txtMessage.Text)
                    {
                        txtMessage.Text = MPCF.Trim(MPGV.gsMessage);
                        txtMessage.SelectionStart = txtMessage.TextLength;
                        txtMessage.ScrollToCaret();
                        ((frmMDIMainCore)MPGV.gfrmMDI).VisibleMessagePanel(false);
                    }
                    b_load_flag = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmUTLPublishMessage.frmUTLPublishMessage_Activated()\n" + ex.Message);
            }
            
        }
        
        private void btnClear_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                txtMessage.Text = "";
                MPGV.gsMessage = "";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmUTLPublishMessage.btnClear_Click()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.txtMessage;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        public void SetMessageEvent(string sMsg)
        {
            try
            {
               IAsyncResult r = BeginInvoke(_SetMessageDelegate, new object[] {sMsg});
                EndInvoke(r);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmUTLPublishMessage.SetMessageEvent()\n" + ex.Message);
            }
 
        }
        private void SetMessage(string sMsg)
        {
            try
            {
                txtMessage.Text = MPCF.RTrim(sMsg);
                txtMessage.SelectionStart = txtMessage.TextLength;
                txtMessage.ScrollToCaret();
                this.Focus();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmUTLPublishMessage.SetMessage()\n" + ex.Message);
            }
        }
        
    }
    
}
