using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Miracom.CliFrx;
using Miracom.MESCore;
using System.Collections;

namespace Miracom.WIPCore
{
    public partial class frmWIPSetupInputOperationCMF : Form
    {
        public frmWIPSetupInputOperationCMF()
        {
            InitializeComponent();
        }

        #region " Variable Definition "

        private bool b_load_flag = false;

        #endregion

        #region " Properties "

        private frmWIPSetupInputAttributeRelation frmOwner;

        public void setOwner(frmWIPSetupInputAttributeRelation f)
        {
            frmOwner = f;
        }

        #endregion

        #region " Function Definition "

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName)
        {
            switch (MPCF.Trim(FuncName))
            {
                case "APPLY":

                    if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }



        #endregion

        private void frmWIPSetupInputOperationCMF_Load(object sender, EventArgs e)
        {
            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
            }
        }
        
        private void frmWIPSetupInputOperationCMF_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCR.SetCMFItem(MPGC.MP_CMF_INPUT_OPER_VALUE, "lblCMF", "cdvCMF", grpCMF);

                b_load_flag = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ArrayList arrCMF = new ArrayList();

            try
            {
                if (CheckCondition("APPLY") == true)
                {
                    arrCMF.Add(MPCF.Trim(cdvCMF1.Text));
                    arrCMF.Add(MPCF.Trim(cdvCMF2.Text));
                    arrCMF.Add(MPCF.Trim(cdvCMF3.Text));
                    arrCMF.Add(MPCF.Trim(cdvCMF4.Text));
                    arrCMF.Add(MPCF.Trim(cdvCMF5.Text));
                    arrCMF.Add(MPCF.Trim(cdvCMF6.Text));
                    arrCMF.Add(MPCF.Trim(cdvCMF7.Text));
                    arrCMF.Add(MPCF.Trim(cdvCMF8.Text));
                    arrCMF.Add(MPCF.Trim(cdvCMF9.Text));
                    arrCMF.Add(MPCF.Trim(cdvCMF10.Text));
                    arrCMF.Add(MPCF.Trim(cdvCMF11.Text));
                    arrCMF.Add(MPCF.Trim(cdvCMF12.Text));
                    arrCMF.Add(MPCF.Trim(cdvCMF13.Text));
                    arrCMF.Add(MPCF.Trim(cdvCMF14.Text));
                    arrCMF.Add(MPCF.Trim(cdvCMF15.Text));
                    arrCMF.Add(MPCF.Trim(cdvCMF16.Text));
                    arrCMF.Add(MPCF.Trim(cdvCMF17.Text));
                    arrCMF.Add(MPCF.Trim(cdvCMF18.Text));
                    arrCMF.Add(MPCF.Trim(cdvCMF19.Text));
                    arrCMF.Add(MPCF.Trim(cdvCMF20.Text));

                    frmOwner.arrInputOperCMF = arrCMF;

                    this.Close();
                }                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void cdvCMF_ButtonPress(object sender, EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }

        private void cdvCMF_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);
        }

    }
}
