
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;


namespace MESClient
{
    public class clsFormEventFunctionImp : intFormEventFunction
    {
        public void Form_Load(System.Windows.Forms.Form frm, System.EventArgs e)
        {
            try
            {
				/* Middleware 를 통한 통신이 가능한지 확인 */
                if (MPIF.gInit.IsAvailableSendMessage == true)
                {
                    if (MPGO.DisplayColHeadCodeView() == true)
                    {
                        MPCR.SetCodeViewVisibleColumnHeader(frm, true, null, null, null, null, null, null, null, null, null, null);
                    }
                }

                MPCF.ToClientLanguage(frm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public void Form_Activated(System.Windows.Forms.Form frm, System.EventArgs e)
        {
            
        }

        public void Form_Closed(System.Windows.Forms.Form frm, FormClosedEventArgs e)
        {
            
        }
        
    }
    
}
