using System;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;

using Miracom.MsgHandler;
using Miracom.CliFrx;
using Miracom.MESCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : modClientMain.vb
//   Description : MES Client Main
//
//   DB Type     : MS SQL Server 2000
//   DB Version  : MS SQL Server 2000(SP3a)
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - New() : Creator for Object
//       - Select() : Select Table
//       -
//
//   Detail Description
//       - Sub Main() Logic
//           1) Get Client Options
//           2) Set Global Variable
//           3) Initialize Middleware
//           4) Run Application
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-03 : Created by J.H.Baek
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

namespace MESClient
{
    static class MESClientMain
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.AddMessageFilter(new MESClientMessageFilter());

                MPGV.gsProgramID = Application.ProductName;
                MPIF.gInit = new clsInitialFunctionImp();
                MPGV.gIBaseFormEvent = new clsFormEventFunctionImp();

                MPGV.gfrmMDI = new frmMDIMain();
                MPGV.gIMdiForm = (intMdiFormFunction)MPGV.gfrmMDI;

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