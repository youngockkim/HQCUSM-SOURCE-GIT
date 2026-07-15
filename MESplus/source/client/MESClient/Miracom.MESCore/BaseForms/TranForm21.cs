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
    public partial class TranForm21 : Miracom.MESCore.TranForm04
    {
        public TranForm21()
        {
            InitializeComponent();
        }

        private void cdvCMF_ButtonPress(System.Object sender, System.EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }

        private void cdvCMF_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);
        }

        protected void SetCMFItem(string s_item_name)
        {
            MPCR.SetCMFItem(s_item_name, "lblCMF", "cdvCMF", grpCMF);
        }

        protected bool CheckCMFItemValue()
        {
            return MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF);
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
                    tabTran.SelectedTab = tbpGeneral;
                    return false;
                }

                if (CheckCMFItemValue() == false)
                {
                    tabTran.SelectedTab = tbpCMF;
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
