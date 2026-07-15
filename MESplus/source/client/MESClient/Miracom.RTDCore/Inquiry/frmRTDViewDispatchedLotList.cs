using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;
namespace Miracom.RTDCore
{
    public partial class frmRTDViewDispatchedLotList : Miracom.MESCore.ViewForm01
    {
        public frmRTDViewDispatchedLotList()
        {
            InitializeComponent();            
        }

        private bool CheckCondition()
        {
            if (rbnOper.Checked == false && rbnResource.Checked == false)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                rbnOper.Checked = true;
                return false;
            }
            if (rbnOper.Checked == true)
            {
                if (MPCF.CheckValue(cdvOper, 1) == false)
                {
                    return false;
                }
            }
            if (rbnResource.Checked == true)
            {
                if (MPCF.CheckValue(cdvResource, 1) == false)
                {
                    return false;
                }
            }

            return true;
        }
        
        private void frmRTDViewDispatchedLotList_Load(object sender, EventArgs e)
        {
            MPCF.InitListView(lisDispatcher);
            rbnResource.Checked = true;
        }

        private void cdvOper_TextBoxTextChanged(object sender, EventArgs e)
        {
            MPCF.InitListView(lisDispatcher);
            if (MPCF.Trim(cdvOper.Text) != "")
            {
                rbnOper.Checked = true;
            }
        }

        private void cdvResource_TextBoxTextChanged(object sender, EventArgs e)
        {
            MPCF.InitListView(lisDispatcher);
            if (MPCF.Trim(cdvResource.Text) != "")
            {
                rbnResource.Checked = true;
            }
        }

        private void cdvOper_ButtonPress(object sender, EventArgs e)
        {
            cdvOper.Init();
            MPCF.InitListView(cdvOper.GetListView);
            cdvOper.Columns.Add("Oper", 50, HorizontalAlignment.Left);
            cdvOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOper.SelectedSubItemIndex = 0;
            WIPLIST.ViewOperationList(cdvOper.GetListView, '1', "", 0, "", "", null, "");
        }

        private void cdvResource_ButtonPress(object sender, EventArgs e)
        {
            cdvResource.Init();
            MPCF.InitListView(cdvResource.GetListView);
            cdvResource.Columns.Add("Resource", 50, HorizontalAlignment.Left);
            cdvResource.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResource.SelectedSubItemIndex = 0;
            RASLIST.ViewResourceList(cdvResource.GetListView, false);

        }

        private void rbnResource_CheckedChanged(object sender, EventArgs e)
        {
            MPCF.InitListView(lisDispatcher);
            if (rbnOper.Checked == true)
            {
                cdvOper.Enabled = true;
                cdvResource.Text = "";
                cdvResource.Enabled = false;
            }
            else if (rbnResource.Checked == true)
            {
                cdvResource.Enabled = true;
                cdvOper.Text = "";
                cdvOper.Enabled = false;
            }

        }
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                char c_step;
                char c_res_oper_flag;
                string s_res_oper_id;
                if (CheckCondition() == false)
                {
                    return;
                }
                if (rbnOper.Checked == true)
                {
                    c_res_oper_flag = 'O';
                    s_res_oper_id = cdvOper.Text;
                }
                else
                {
                    c_res_oper_flag = 'R';
                    s_res_oper_id = cdvResource.Text;
                }

                //Modify by J.S. 2009.03.16 for uncapable
                c_step = '1';

                RTDLIST.ViewDispatchedLotList(lisDispatcher, c_step, c_res_oper_flag, s_res_oper_id, 
                    MPCF.ToInt(txtMaxCount.Text), chkUnselect.Checked, chkUncapable.Checked, chkReserveLot.Checked, chkStartLot.Checked, chkIncludeZeroQty.Checked);
                 MPCF.FitColumnHeader(lisDispatcher);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string sCond;

            sCond = "";
            if (rbnResource.Checked == true)
            {
                sCond = sCond + "Resource : " + cdvResource.Text + "\r";
            }
            else
            {
                sCond = sCond + "Operation : " + cdvOper.Text + "\r";
            }

            if (MPCF.ExportToExcel(lisDispatcher, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
            }
        }

    }
}

