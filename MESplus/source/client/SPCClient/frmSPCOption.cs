//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : frmSPCOption.vb
//   Description : Setting Options
//
//   SPC Version : 1.0.0
//
//   Function List
//       -
//
//   Detail Description
//       -
//
//   History
//       - 2005-04-26 : Created by H.K.Kim
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MsgHandler;

namespace Miracom.SPCClient
{
    public partial class frmSPCOption : Miracom.MESCore.frmOptionCore
    {
        public frmSPCOption()
        {
            InitializeComponent();
        }

        public frmSPCOption(bool bRestart)
        {
            InitializeComponent();
            
            b_restart_flag = bRestart;
        }

        #region " Variable Definition"

        private bool b_load_flag;

        #endregion

        #region " Event Implematations"

        private void frmSPCOption_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                if (MPGV.gsStyleName == "FLAT")
                {
                    rbnFlat.Checked = true;
                }
                else if (MPGV.gsStyleName == "3D")
                {
                    rbn3D.Checked = true;
                }

                b_load_flag = true;
            }
        }

        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            if (rbnFlat.Checked == true)
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "Style", "1");
                MPGV.gsStyleName = "FLAT";
            }
            else
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "Style", "2");
                MPGV.gsStyleName = "3D";
            }
        }


        #endregion   
    
    }
}

