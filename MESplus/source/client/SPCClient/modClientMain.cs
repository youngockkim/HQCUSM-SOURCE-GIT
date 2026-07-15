
using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;

//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : modClientModule.vb
//   Description : SPC Client Module
//
//   SPC Version : 1.0.0
//
//   Function List
//       - Sub Main
//
//   Detail Description
//       -
//
//   History
//       - 2005-03-04 : Created by H.K.Kim
//
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

namespace Miracom.SPCClient
{
    public sealed class modClientMain
    {
        
        [System.STAThread()]static public void Main()
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
