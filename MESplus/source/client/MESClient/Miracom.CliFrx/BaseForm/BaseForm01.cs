using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Miracom.CliFrx
{
    public partial class BaseForm01 : Form
    {

        public BaseForm01()
        {
            InitializeComponent();
            DisabledFormControls = new ArrayList();
        }

        public ArrayList DisabledFormControls;

        private void BaseForm_Load(object sender, System.EventArgs e)
        {

            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
            }

        }
        
        private void BaseForm_Activated(object sender, System.EventArgs e)
        {

            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Activated(this, e);
            }
            
        }

        private void BaseForm_Closed(object sender, FormClosedEventArgs e)
        {

            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Closed(this, e);
            }
            
            if (this.MdiParent == null)
            {
                
            }
            else
            {
                if (this.MdiParent.IsMdiContainer == true)
                {
                    this.Dispose();
                }
            }

            MPCF.FlushMemory();
        }
        
        private void BaseForm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (!(this.ActiveControl == null))
            {
                if (this.ActiveControl is System.Windows.Forms.TextBox || this.ActiveControl is Miracom.UI.Controls.MCCodeView.MCCodeView)
                {
                    if (e.KeyValue != 13 && e.KeyValue != 8)
                    {
                        if (MPCF.CheckMaxLength(this.ActiveControl, 0) == false)
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
        }
        
        //private void BaseForm_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        //{
        //    if (!(this.ActiveControl == null))
        //    {
        //        if (this.ActiveControl is System.Windows.Forms.TextBox || this.ActiveControl is Miracom.UI.Controls.MCCodeView.MCCodeView)
        //        {
        //            if (e.KeyChar == ':')
        //            {
        //                e.Handled = True
        //            }
        //        }
        //    }
        //}
    
    }
}