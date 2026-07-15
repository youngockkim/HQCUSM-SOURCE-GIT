#if _H101
using SOI.MsgHandlerH101;
#endif
#if _Http
using SOI.MsgHandlerHTTP;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SOI.CliFrx;
using SOI.OIFrx;
using SOI.HanwhaQcell.USModule;

namespace StandardOI
{
    static class StandardOIMain
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // Enable Visual Style
                Application.EnableVisualStyles();

                // Add Message Filter
                //Application.AddMessageFilter(new MESClientMessageFilter());

                // Set Initial Function
                MPIF.gInit = new clsInitialFunctionImp();

                // Set Global Variables
                MPGV.gsProgramID = Application.ProductName;
                MPGV.gIBaseFormEvent = new clsFormEventFunctionImp();
                MPGV.gfrmMDI = new frmMDIMain();
                MPGV.gIMdiForm = (iMdiForm)MPGV.gfrmMDI;
                HQGV.gIHmMdiForm = (SOI.HanwhaQcell.USModule.intHmMdiFormFunction)MPGV.gfrmMDI;

                Application.Run(MPGV.gfrmMDI);

                MPIF.gInit.TermMsgHandler();
            }
            catch (Exception ex)
            {
                MPIF.gInit.TermMsgHandler();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
