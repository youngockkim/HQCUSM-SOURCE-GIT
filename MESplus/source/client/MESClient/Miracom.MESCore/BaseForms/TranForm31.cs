using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using Miracom.CliFrx;

namespace Miracom.MESCore
{
    public partial class TranForm31 : Miracom.MESCore.TranForm03
    {
        public TranForm31()
        {
            InitializeComponent();
        }
        
        protected virtual void ClearData(int i_case)
        {
            try
            {
                switch (i_case)
                {
                    case 1:
                        MPCF.FieldClear(this, txtLotID);
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        protected virtual void ClearData(int i_case, object ExceptCtl1,
            [Optional, DefaultParameterValue(null)] object ExceptCtl2,
            [Optional, DefaultParameterValue(null)] object ExceptCtl3,
            [Optional, DefaultParameterValue(null)] object ExceptCtl4)
        {
            try
            {
                switch (i_case)
                {
                    case 1:
                        MPCF.FieldClear(this, txtLotID, ExceptCtl1, ExceptCtl2, ExceptCtl3, ExceptCtl4, false);
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        protected virtual bool CheckCondition()
        {
            try
            {
                if (MPCF.CheckValue(txtLotID, 1) == false)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }


    }
}
