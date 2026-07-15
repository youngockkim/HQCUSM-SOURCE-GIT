using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPSetupPriorityControl : SetupForm02
    {
        public frmWIPSetupPriorityControl()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        bool b_load_flag;
        #endregion

        #region " Function Definition "

        private void SetCmfItem()
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            int i;

            spdLotCMF.ActiveSheet.ClearRange(0, 1, 20, 1, true);
            spdResCMF.ActiveSheet.ClearRange(0, 1, 20, 1, true);
            spdResGRP.ActiveSheet.ClearRange(0, 1, 10, 1, true);

            if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_CMF_LOT, ref out_node, "", true) == false)
            {
                return;
            }
            spdLotCMF.ActiveSheet.Cells[0, 1].Value = out_node.GetString("PRT_1");
            spdLotCMF.ActiveSheet.Cells[1, 1].Value = out_node.GetString("PRT_2");
            spdLotCMF.ActiveSheet.Cells[2, 1].Value = out_node.GetString("PRT_3");
            spdLotCMF.ActiveSheet.Cells[3, 1].Value = out_node.GetString("PRT_4");
            spdLotCMF.ActiveSheet.Cells[4, 1].Value = out_node.GetString("PRT_5");
            spdLotCMF.ActiveSheet.Cells[5, 1].Value = out_node.GetString("PRT_6");
            spdLotCMF.ActiveSheet.Cells[6, 1].Value = out_node.GetString("PRT_7");
            spdLotCMF.ActiveSheet.Cells[7, 1].Value = out_node.GetString("PRT_8");
            spdLotCMF.ActiveSheet.Cells[8, 1].Value = out_node.GetString("PRT_9");
            spdLotCMF.ActiveSheet.Cells[9, 1].Value = out_node.GetString("PRT_10");
            spdLotCMF.ActiveSheet.Cells[10, 1].Value = out_node.GetString("PRT_11");
            spdLotCMF.ActiveSheet.Cells[11, 1].Value = out_node.GetString("PRT_12");
            spdLotCMF.ActiveSheet.Cells[12, 1].Value = out_node.GetString("PRT_13");
            spdLotCMF.ActiveSheet.Cells[13, 1].Value = out_node.GetString("PRT_14");
            spdLotCMF.ActiveSheet.Cells[14, 1].Value = out_node.GetString("PRT_15");
            spdLotCMF.ActiveSheet.Cells[15, 1].Value = out_node.GetString("PRT_16");
            spdLotCMF.ActiveSheet.Cells[16, 1].Value = out_node.GetString("PRT_17");
            spdLotCMF.ActiveSheet.Cells[17, 1].Value = out_node.GetString("PRT_18");
            spdLotCMF.ActiveSheet.Cells[18, 1].Value = out_node.GetString("PRT_19");
            spdLotCMF.ActiveSheet.Cells[19, 1].Value = out_node.GetString("PRT_20");

            for (i = 0; i < 20; i++)
            {
                spdLotCMF.ActiveSheet.Cells[i, 0].Value = false;

                if (MPCF.Trim(spdLotCMF.ActiveSheet.Cells[i, 1].Value) == "")
                {
                    spdLotCMF.ActiveSheet.Rows[i].Height = 0;
                    spdLotCMF.ActiveSheet.Rows[i].Resizable = false;
                    spdLotCMF.ActiveSheet.Rows[i].Visible = false;
                }
            }

            if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_CMF_RESOURCE, ref out_node, "", true) == false)
            {
                return;
            }
            spdResCMF.ActiveSheet.Cells[0, 1].Value = out_node.GetString("PRT_1");
            spdResCMF.ActiveSheet.Cells[1, 1].Value = out_node.GetString("PRT_2");
            spdResCMF.ActiveSheet.Cells[2, 1].Value = out_node.GetString("PRT_3");
            spdResCMF.ActiveSheet.Cells[3, 1].Value = out_node.GetString("PRT_4");
            spdResCMF.ActiveSheet.Cells[4, 1].Value = out_node.GetString("PRT_5");
            spdResCMF.ActiveSheet.Cells[5, 1].Value = out_node.GetString("PRT_6");
            spdResCMF.ActiveSheet.Cells[6, 1].Value = out_node.GetString("PRT_7");
            spdResCMF.ActiveSheet.Cells[7, 1].Value = out_node.GetString("PRT_8");
            spdResCMF.ActiveSheet.Cells[8, 1].Value = out_node.GetString("PRT_9");
            spdResCMF.ActiveSheet.Cells[9, 1].Value = out_node.GetString("PRT_10");
            spdResCMF.ActiveSheet.Cells[10, 1].Value = out_node.GetString("PRT_11");
            spdResCMF.ActiveSheet.Cells[11, 1].Value = out_node.GetString("PRT_12");
            spdResCMF.ActiveSheet.Cells[12, 1].Value = out_node.GetString("PRT_13");
            spdResCMF.ActiveSheet.Cells[13, 1].Value = out_node.GetString("PRT_14");
            spdResCMF.ActiveSheet.Cells[14, 1].Value = out_node.GetString("PRT_15");
            spdResCMF.ActiveSheet.Cells[15, 1].Value = out_node.GetString("PRT_16");
            spdResCMF.ActiveSheet.Cells[16, 1].Value = out_node.GetString("PRT_17");
            spdResCMF.ActiveSheet.Cells[17, 1].Value = out_node.GetString("PRT_18");
            spdResCMF.ActiveSheet.Cells[18, 1].Value = out_node.GetString("PRT_19");
            spdResCMF.ActiveSheet.Cells[19, 1].Value = out_node.GetString("PRT_20");

            for (i = 0; i < 20; i++)
            {
                spdResCMF.ActiveSheet.Cells[i, 0].Value = false;

                if (MPCF.Trim(spdResCMF.ActiveSheet.Cells[i, 1].Value) == "")
                {
                    spdResCMF.ActiveSheet.Rows[i].Height = 0;
                    spdResCMF.ActiveSheet.Rows[i].Resizable = false;
                    spdResCMF.ActiveSheet.Rows[i].Visible = false;
                }
            }

            if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_GRP_RESOURCE, ref out_node, "", true) == false)
            {
                return;
            }
            spdResGRP.ActiveSheet.Cells[0, 1].Value = out_node.GetString("PRT_1");
            spdResGRP.ActiveSheet.Cells[1, 1].Value = out_node.GetString("PRT_2");
            spdResGRP.ActiveSheet.Cells[2, 1].Value = out_node.GetString("PRT_3");
            spdResGRP.ActiveSheet.Cells[3, 1].Value = out_node.GetString("PRT_4");
            spdResGRP.ActiveSheet.Cells[4, 1].Value = out_node.GetString("PRT_5");
            spdResGRP.ActiveSheet.Cells[5, 1].Value = out_node.GetString("PRT_6");
            spdResGRP.ActiveSheet.Cells[6, 1].Value = out_node.GetString("PRT_7");
            spdResGRP.ActiveSheet.Cells[7, 1].Value = out_node.GetString("PRT_8");
            spdResGRP.ActiveSheet.Cells[8, 1].Value = out_node.GetString("PRT_9");
            spdResGRP.ActiveSheet.Cells[9, 1].Value = out_node.GetString("PRT_10");

            for (i = 0; i < 10; i++)
            {
                spdResGRP.ActiveSheet.Cells[i, 0].Value = false;

                if (MPCF.Trim(spdResGRP.ActiveSheet.Cells[i, 1].Value) == "")
                {
                    spdResGRP.ActiveSheet.Rows[i].Height = 0;
                    spdResGRP.ActiveSheet.Rows[i].Resizable = false;
                    spdResGRP.ActiveSheet.Rows[i].Visible = false;
                }
            }
        }


        private void SetCheckItem(string s_check_item)
        {
            string s_temp;
            int i;

            s_temp = s_check_item.PadRight(100, ' ');

            if (s_temp[0] == 'Y') chkMatID.Checked = true;
            if (s_temp[1] == 'Y') chkMatVer.Checked = true;
            if (s_temp[2] == 'Y') chkFlow.Checked = true;
            if (s_temp[3] == 'Y') chkOper.Checked = true;
            if (s_temp[4] == 'Y') chkResource.Checked = true;
            if (s_temp[5] == 'Y') chkResType.Checked = true;
            if (s_temp[6] == 'Y') chkResGroup.Checked = true;

            for (i = 0; i < 20; i++)
            {
                spdLotCMF.ActiveSheet.Cells[i, 0].Value = false;
                if (s_temp[7 + i] == 'Y')
                {
                    spdLotCMF.ActiveSheet.Cells[i, 0].Value = true;
                }
            }

            for (i = 0; i < 20; i++)
            {
                spdResCMF.ActiveSheet.Cells[i, 0].Value = false;
                if (s_temp[27 + i] == 'Y')
                {
                    spdResCMF.ActiveSheet.Cells[i, 0].Value = true;
                }
            }

            for (i = 0; i < 10; i++)
            {
                spdResGRP.ActiveSheet.Cells[i, 0].Value = false;
                if (s_temp[47 + i] == 'Y')
                {
                    spdResGRP.ActiveSheet.Cells[i, 0].Value = true;
                }
            }
        }

        private string GetCheckItem()
        {
            string s_temp;
            int i;

            s_temp = "";
            s_temp += chkMatID.Checked == true ? "Y" : "N";
            s_temp += chkMatVer.Checked == true ? "Y" : "N";
            s_temp += chkFlow.Checked == true ? "Y" : "N";
            s_temp += chkOper.Checked == true ? "Y" : "N";
            s_temp += chkResource.Checked == true ? "Y" : "N";
            s_temp += chkResType.Checked == true ? "Y" : "N";
            s_temp += chkResGroup.Checked == true ? "Y" : "N";

            for (i = 0; i < 20; i++)
            {
                if (spdLotCMF.ActiveSheet.Cells[i, 0].Value == null ||
                   Convert.ToBoolean(spdLotCMF.ActiveSheet.Cells[i, 0].Value) == false)
                {
                    s_temp += "N";
                }
                else
                {
                    s_temp += "Y";
                }
            }

            for (i = 0; i < 20; i++)
            {
                if (spdResCMF.ActiveSheet.Cells[i, 0].Value == null ||
                   Convert.ToBoolean(spdResCMF.ActiveSheet.Cells[i, 0].Value) == false)
                {
                    s_temp += "N";
                }
                else
                {
                    s_temp += "Y";
                }
            }

            for (i = 0; i < 10; i++)
            {
                if (spdResGRP.ActiveSheet.Cells[i, 0].Value == null ||
                   Convert.ToBoolean(spdResGRP.ActiveSheet.Cells[i, 0].Value) == false)
                {
                    s_temp += "N";
                }
                else
                {
                    s_temp += "Y";
                }
            }

            return s_temp;
        }
        
        private bool UpdatePriority(char c_step)
        {
            TRSNode in_node = new TRSNode("Update_Priority_In");
            TRSNode out_node = new TRSNode("Update_Priority_Out");
            string s_check_item;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("PRI_TYPE", MPCF.Trim(cdvPriorityType.Text));
                in_node.AddInt("PRIORITY", numPriority.Value);

                if (c_step != MPGC.MP_STEP_DELETE)
                {
                    in_node.AddString("PRI_DESC", MPCF.Trim(txtPriorityDesc.Text));
                    s_check_item = GetCheckItem();
                    in_node.AddString("CHECK_ITEM", s_check_item);
                }

                if (MPCR.CallService("WIP", "WIP_Update_Priority", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowMsgBox(MPCF.GetMessage(52));
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool ViewPriority(int i_bin_pri)
        {
            TRSNode in_node = new TRSNode("View_Priority_In");
            TRSNode out_node = new TRSNode("View_Priority_Out");

            try
            {
                MPCF.FieldClear(pnlRight);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("PRI_TYPE", MPCF.Trim(cdvPriorityType.Text));
                in_node.AddInt("PRIORITY", i_bin_pri);

                if (MPCR.CallService("WIP", "WIP_View_Priority", in_node, ref out_node) == false)
                {
                    return false;
                }

                numPriority.Value = out_node.GetInt("PRIORITY");
                txtPriorityDesc.Text = out_node.GetString("PRI_DESC");

                txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                SetCheckItem(out_node.GetString("CHECK_ITEM"));
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool ViewPriorityList()
        {
            TRSNode in_node = new TRSNode("View_Priority_List_In");
            TRSNode out_node = new TRSNode("View_Priority_List_Out");
            ListViewItem itmx;
            List<TRSNode> pri_list;

            try
            {
                MPCF.InitListView(lisPriority);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("PRI_TYPE", MPCF.Trim(cdvPriorityType.Text));

                do
                {
                    if (MPCR.CallService("WIP", "WIP_View_Priority_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    pri_list = out_node.GetList("PRIORITY_LIST");
                    for (int i = 0; i < pri_list.Count; i++)
                    {
                        itmx = new ListViewItem(pri_list[i].GetInt("PRIORITY").ToString(), (int)SMALLICON_INDEX.IDX_PRIORITY);
                        itmx.SubItems.Add(pri_list[i].GetString("PRI_DESC"));

                        lisPriority.Items.Add(itmx);
                    }

                    in_node.SetInt("NEXT_PRIORITY", out_node.GetInt("NEXT_PRIORITY"));
                } while (in_node.GetInt("NEXT_PRIORITY") > 0);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.numPriority;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion

        private void frmWIPSetupPriorityControl_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    MPCF.InitListView(lisPriority);
                    SetCmfItem();

                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                MPCF.FindListItemNextPartial(lisPriority, txtFind.Text, true, false);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                MPCF.FindListItemPartial(lisPriority, txtFind.Text, 0, true, false);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                lblDataCount.Text = "";
                if (ViewPriorityList() == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisPriority.Items.Count);
                    if (lisPriority.Items.Count > 0)
                    {
                        MPCF.FindListItem(lisPriority, numPriority.Value.ToString(), false);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (lisPriority.Items.Count > 0)
                {
                    MPCF.ExportToExcel(lisPriority, this.Text, "");
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvPriorityType_ButtonPress(object sender, EventArgs e)
        {
            cdvPriorityType.Init();
            MPCF.InitListView(cdvPriorityType.GetListView);
            cdvPriorityType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvPriorityType.Columns.Add("Desc", 50, HorizontalAlignment.Left);
            cdvPriorityType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvPriorityType.GetListView, '1', MPGC.MP_PRIORITY_TYPE_TBL_DEF);
        }

        private void cdvPriorityType_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvPriorityType.Text != "")
            {
                MPCF.FieldClear(pnlRight);
                ViewPriorityList();
            }
        }

        private void lisPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisPriority.SelectedItems.Count > 0)
            {
                ViewPriority(MPCF.ToInt(lisPriority.SelectedItems[0].Text));
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvPriorityType, 1) == false) return;
            if (numPriority.Value < 1)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                numPriority.Focus();
                return;
            }

            if (UpdatePriority(MPGC.MP_STEP_CREATE) == false) return;
            btnRefresh.PerformClick();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvPriorityType, 1) == false) return;
            if (numPriority.Value < 1)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                numPriority.Focus();
                return;
            }

            if (UpdatePriority(MPGC.MP_STEP_UPDATE) == false) return;
            btnRefresh.PerformClick();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvPriorityType, 1) == false) return;
            if (numPriority.Value < 1)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                numPriority.Focus();
                return;
            }

            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;
            if (UpdatePriority(MPGC.MP_STEP_DELETE) == false) return;

            MPCF.FieldClear(pnlRight);
            btnRefresh.PerformClick();
        }

        private void pnlCMF_Resize(object sender, EventArgs e)
        {
            int i_width = pnlCMF.Width / 3;

            spdLotCMF.Width = i_width;
            spdResCMF.Width = i_width;
            spdResGRP.Width = i_width;

            if (i_width - 65 > 100)
            {
                spdLotCMF.ActiveSheet.Columns[1].Width = i_width - 65;
                spdResCMF.ActiveSheet.Columns[1].Width = i_width - 65;
                spdResGRP.ActiveSheet.Columns[1].Width = i_width - 65;
            }
            else
            {
                spdLotCMF.ActiveSheet.Columns[1].Width = 100;
                spdResCMF.ActiveSheet.Columns[1].Width = 100;
                spdResGRP.ActiveSheet.Columns[1].Width = 100;
            }
        }


    }
}
