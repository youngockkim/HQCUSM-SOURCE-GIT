#if _H101
using SOI.MsgHandlerH101;
#endif
#if _Http
using SOI.MsgHandlerHTTP;
#endif
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Data;
using SOI.CliFrx;
using SOI.OIFrx;

namespace StandardOI
{
    public class clsFormEventFunctionImp : iFormEventFunction
    {
        public void Form_Load(System.Windows.Forms.Form frm, System.EventArgs e)
        {
            try
            {
                /* Middleware 를 통한 통신이 가능한지 확인 */
                if (MPIF.gInit.IsAvailableSendMessage == true)
                {
                    //if (MPGO.DisplayColHeadCodeView() == true)
                    //{
                    //    MPCR.SetCodeViewVisibleColumnHeader(frm, true, null, null, null, null, null, null, null, null, null, null);
                    //}
                }

                MPCF.ConvertCaption(frm);
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
