using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.MESCore;
using Miracom.TRSCore;
using Miracom.CliFrx;

namespace Miracom.BASCore
{
    public partial class frmBASSetupMenuGroup : SetupForm02
    {
        public frmBASSetupMenuGroup()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private const char ATTACH_MENU = '1';
        private const char DETACH_MENU = '2';
        private const char UP_SEQ_MENU = '3';
        private const char DOWN_SEQ_MENU = '4';

        // Available Function List 
        private const int COL_AVAIL_FUNC_DESC = 0;
        private const int COL_AVAIL_FUNC_NAME = 1;

        // Attached Function List
        private const int COL_FUNC_SEQ = 0;
        private const int COL_FUNC_DESC = 1;
        private const int COL_REQUIRED_FLAG = 2;
        private const int COL_PRIORITY = 3;
        private const int COL_TRAN_CODE = 4;

        #endregion

        #region " Valiable Definition "

        private bool b_activated_flag = false;
        private bool b_is_processing = false;
        private bool b_desc_changed = false;

        #endregion

        #region " Function Definition "

        private bool CheckCondition(char cStep)
        {
            if (MPCF.CheckValue(txtMenuGrp, 1) == false) return false;

            switch (cStep)
            {
                case ATTACH_MENU:
                    if (lisAvailFunc.SelectedItems.Count <= 0 || lisAttachedMenu.SelectedItems.Count <= 0)
                    {
                        return false;
                    }
                    break;

                case DETACH_MENU:
                    if (lisAttachedMenu.SelectedItems.Count <= 0)
                    {
                        return false;
                    }
                    if (lisAttachedMenu.SelectedItems[0].Index >= lisAttachedMenu.Items.Count - 1)
                    {
                        return false;
                    }
                    break;

                case MPGC.MP_STEP_UPDATE:

                    // Add by DM KIM 2013.08.30 Update 처리시 Select한 Item이 없으면 Return False
                    if (lisAttachedMenu.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(305));
                        return false;
                    }

                    break;
            }
            return true;
        }

        private bool UpdateMenuGroup(char cStep)
        {
            return UpdateMenuGroup(cStep, 0, 0, true);
        }
        private bool UpdateMenuGroup(char cStep, int iFromIndex, int iToIndex, bool bShowMsg)
        {
            TRSNode in_node = new TRSNode("UPDATE_MENU_GRP_IN");
            TRSNode out_node = new TRSNode("UPDATE_MENU_GRP_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = cStep;
                in_node.AddString("GROUP_CATEGORY", cboCategory.Text);
                in_node.AddString("MENU_GRP_ID", txtMenuGrp.Text);
                in_node.AddString("MENU_GRP_DESC", txtDesc.Text);


                if (cStep == ATTACH_MENU || cStep == MPGC.MP_STEP_UPDATE)
                {
                    if (MPCF.Trim(lisAttachedMenu.Items[iToIndex].SubItems[COL_FUNC_SEQ].Text) == "")
                        in_node.AddInt("TRAN_SEQ", lisAttachedMenu.Items.Count);
                    else
                        in_node.AddInt("TRAN_SEQ", MPCF.ToInt(lisAttachedMenu.Items[iToIndex].SubItems[COL_FUNC_SEQ].Text));
                    
                    if (cStep == ATTACH_MENU)
                        in_node.AddString("FUNC_NAME", MPCF.Trim(lisAvailFunc.Items[iFromIndex].SubItems[COL_AVAIL_FUNC_NAME].Text));
                    in_node.AddChar("REQUIRED_FLAG", chkRequired.Checked ? 'Y' : 'N');
                    in_node.AddInt("PRIORITY", MPCF.ToInt(numPriority.Value));
                    in_node.AddString("TRAN_CODE", cdvTranCode.Text);
                }
                else if (cStep == DETACH_MENU || cStep == UP_SEQ_MENU || cStep == DOWN_SEQ_MENU)
                {
                    in_node.AddInt("TRAN_SEQ", MPCF.ToInt(lisAttachedMenu.Items[iToIndex].SubItems[COL_FUNC_SEQ].Text));
                }
                else if (cStep == MPGC.MP_STEP_COPY)
                {
                    in_node.AddString("TO_MENU_GRP_ID", txtToMenuGrp.Text);
                }

                if (MPCR.CallService("BAS", "BAS_Update_Menu_Group", in_node, ref out_node, false) == false)
                {
                    return false;
                }

                if (bShowMsg == true) MPCR.ShowSuccessMsg(out_node);
                
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewMenuGroup()
        {
            return ViewMenuGroup(false);
        }
        private bool ViewMenuGroup(bool b_select_index)
        {
            TRSNode in_node = new TRSNode("MENU_GRP_IN");
            TRSNode out_node = new TRSNode("MENU_GRP_OUT");

            ListViewItem itmX;
            int iPrevIndex = 0;

            try
            {
                iPrevIndex = (lisAttachedMenu.SelectedItems.Count > 0) ? lisAttachedMenu.SelectedItems[0].Index : 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MENU_GRP_ID", MPCF.Trim(txtMenuGrp.Text));

                MPCF.InitListView(lisAttachedMenu);
                if (MPCR.CallService("BAS", "BAS_View_Menu_Group", in_node, ref out_node) == true)
                {
                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        itmX = lisAttachedMenu.Items.Insert(lisAttachedMenu.Items.Count, "", (int)SMALLICON_INDEX.IDX_FUNCTION);
                    }

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        itmX = lisAttachedMenu.Items[out_node.GetList(0)[i].GetInt("TRAN_SEQ") - 1];
                        itmX.SubItems[0].Text = out_node.GetList(0)[i].GetInt("TRAN_SEQ").ToString(); 
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("FUNC_DESC")); 
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("REQUIRED_FLAG").ToString()); 
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("PRIORITY").ToString());
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("TRAN_CODE"));
                        itmX.SubItems[COL_FUNC_DESC].Tag = out_node.GetList(0)[i].GetString("FUNC_NAME");
                    }
                }

                itmX = lisAttachedMenu.Items.Insert(lisAttachedMenu.Items.Count, "");
                itmX.SubItems[COL_FUNC_SEQ].Tag = lisAttachedMenu.Items.Count.ToString();
                itmX.SubItems.Add("Attach ...");
                itmX.SubItems[COL_FUNC_DESC].Tag = "Attach ...";
                itmX.SubItems.Add("");
                itmX.SubItems.Add("");
                itmX.SubItems.Add("");
                itmX.SubItems.Add("");

                if (b_select_index == true)
                    lisAttachedMenu.Items[iPrevIndex].Selected = true;
                else
                    lisAttachedMenu.Items[0].Selected = true;

                lisAttachedMenu.EnsureVisible(lisAttachedMenu.SelectedItems[0].Index);

                b_desc_changed = false;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewMenuGroupList()
        {
            return ViewMenuGroupList('1');
        }
        private bool ViewMenuGroupList(char c_step)
        {
            TRSNode in_node = new TRSNode("MENU_GRP_LIST_IN");
            TRSNode out_node = new TRSNode("MENU_GRP_LIST_OUT");

            ListViewItem itmX;

            int iIndex = -1;

            try
            {
                if (lisMenuGrp.SelectedItems.Count > 0)
                    iIndex = lisMenuGrp.SelectedItems[0].Index;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                MPCF.InitListView(lisMenuGrp);
                if (MPCR.CallService("BAS", "BAS_View_Menu_Group_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmX = lisMenuGrp.Items.Insert(lisMenuGrp.Items.Count, out_node.GetList(0)[i].GetString("MENU_GRP_ID"), (int)SMALLICON_INDEX.IDX_FUNCTION); // Group Id
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MENU_GRP_DESC"));  // Description
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("GROUP_CATEGORY"));  // CATEGORY
                }

                lblDataCount.Text = lisMenuGrp.Items.Count.ToString();
                if (lisMenuGrp.Items.Count > 0)
                {
                    if (txtMenuGrp.Text != "")
                    {
                        foreach (ListViewItem item in lisMenuGrp.Items)
                        {
                            if (item.SubItems[0].Text == txtMenuGrp.Text)
                            {
                                item.Selected = true;
                                return true;
                            }
                        }
                    }
                    
                    lisMenuGrp.Items[0].Selected = true;
                }
                else
                {
                    if (lisAttachedMenu.Items.Count == 0)
                    {
                        InitAttachedList();
                    }
                }
                

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool InitCdvTranCode()
        {
            try
            {
                cdvTranCode.Init();
                MPCF.InitListView(cdvTranCode.GetListView);
                cdvTranCode.Columns.Add("Tran Code", 100, HorizontalAlignment.Left);
                cdvTranCode.Columns.Add("Description", 150, HorizontalAlignment.Left);
                cdvTranCode.SelectedSubItemIndex = 0;
                BASLIST.ViewTranCodeList(cdvTranCode.GetListView, '1');

                cdvTranCode.InsertEmptyRow(0, 1);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewFunctionList()
        {
            try
            {
                if (SECLIST.ViewFunctionList(lisAvailFunc, '1', "", "", cdvFGroup.Text, 'F', null, "", false, false) == false)
                {
                    return false;
                }

                MPCF.FitColumnHeader(lisAvailFunc);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewMenu()
        {
            TRSNode in_node = new TRSNode("VIEW_MENU_IN");
            TRSNode out_node = new TRSNode("VIEW_MENU_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPGC.MP_GCM_MENU_GROUP);
                in_node.AddString("KEY_1", txtMenuGrp.Text);
                in_node.AddString("KEY_2", lisAttachedMenu.SelectedItems[0].SubItems[COL_FUNC_SEQ].Text);

                if (MPCR.CallService("BAS", "BAS_View_Data", in_node, ref out_node) == false)
                    return false;

                chkRequired.Checked = (out_node.GetString("DATA_3") == "Y") ? true : false;
                numPriority.Value = MPCF.ToInt(out_node.GetString("DATA_4"));
                cdvTranCode.Text = out_node.GetString("DATA_5");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void ListReOrder()
        {
            int i;

            for (i = 0; i < lisAttachedMenu.Items.Count - 1; i++)
            {
                lisAttachedMenu.Items[i].SubItems[0].Text = (i + 1).ToString();
            }
        }

        private void SwapListItem(int iFromSeq, int iToSeq)
        {
            ListViewItem lisFromX, lisToX;

            lisAttachedMenu.Items[iFromSeq].SubItems[COL_FUNC_SEQ].Text = (lisAttachedMenu.Items[iToSeq].Index + 1).ToString();
            lisAttachedMenu.Items[iToSeq].SubItems[COL_FUNC_SEQ].Text = (lisAttachedMenu.Items[iFromSeq].Index + 1).ToString();
            lisFromX = (ListViewItem)lisAttachedMenu.Items[iFromSeq].Clone();
            lisToX = (ListViewItem)lisAttachedMenu.Items[iToSeq].Clone();

            lisAttachedMenu.Items[iFromSeq] = lisToX;
            lisAttachedMenu.Items[iToSeq] = lisFromX;
        }

        private void InitAttachedList()
        {
            MPCF.InitListView(lisAttachedMenu);

            ListViewItem itmX;
            itmX = lisAttachedMenu.Items.Insert(0, "");
            itmX.SubItems[COL_FUNC_SEQ].Tag = "0";
            itmX.SubItems.Add("Attach ...");
            itmX.SubItems[COL_FUNC_DESC].Tag = "Attach ...";
            itmX.SubItems.Add("");
            itmX.SubItems.Add("");
            itmX.SubItems.Add("");
            itmX.SubItems.Add("");
        }

        private void Init(string s_step)
        {
            switch (s_step)
            {
                case "INPUT_ID":
                    txtDesc.Text = "";
                    InitAttachedList();
                    chkRequired.Checked = false;
                    numPriority.Value = 0;
                    cdvTranCode.Text = "";
                break;
            }
        }

        #endregion

        private void frmBASSetupMenuGroup_Activated(object sender, EventArgs e)
        {
            if (b_activated_flag == false)
            {
                pnlUserMid_Resize(null, null);

                if (ViewMenuGroupList() == false) return;

                if (ViewFunctionList() == false) return;

                if (InitCdvTranCode() == false) return;
              
                b_activated_flag = true;
            }
        }

        private void cdvFGroup_ButtonPress(object sender, EventArgs e)
        {
            cdvFGroup.Init();
            MPCF.InitListView(cdvFGroup.GetListView);
            cdvFGroup.Columns.Add("Group", 50, HorizontalAlignment.Left);
            cdvFGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvFGroup.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvFGroup.GetListView, '1', MPGC.MP_SEC_FUNCTION_GROUP);
            cdvFGroup.InsertEmptyRow(0, 1);
        }

        private void cdvFGroup_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            ViewFunctionList();
        }

        private void btnMenuRefresh_Click(object sender, EventArgs e)
        {
            ViewFunctionList();
        }

        private void lisMenuGrp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lisMenuGrp.SelectedItems.Count < 1) return;
                txtMenuGrp.Text = lisMenuGrp.SelectedItems[0].SubItems[0].Text;
                txtDesc.Text = lisMenuGrp.SelectedItems[0].SubItems[1].Text;
                cboCategory.Text = lisMenuGrp.SelectedItems[0].SubItems[2].Text;

                ViewMenuGroup();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string sFromMenu;
                string sToMenu;
                ListViewItem itmX;
                int idx;
                int i, j;

                if (CheckCondition(ATTACH_MENU) == false)
                {
                    return;
                }

                for (i = 0; i <= lisAvailFunc.SelectedItems.Count - 1; i++)
                {
                    sFromMenu = lisAvailFunc.SelectedItems[i].SubItems[COL_AVAIL_FUNC_NAME].Text;
                    sToMenu = MPCF.Trim(lisAttachedMenu.SelectedItems[0].SubItems[COL_FUNC_DESC].Tag);

                    if (sToMenu == "Attach ...")
                    {
                        sToMenu = "";
                    }

                    if (UpdateMenuGroup(ATTACH_MENU,
                                        lisAvailFunc.SelectedItems[i].Index,
                                        lisAttachedMenu.SelectedItems[0].Index,
                                        false) == true)
                    {
                        if (lisAttachedMenu.Items.Count > 1)
                        {
                            itmX = new ListViewItem("0", (int)SMALLICON_INDEX.IDX_FUNCTION);
                            itmX.SubItems.Add(lisAvailFunc.SelectedItems[i].SubItems[COL_AVAIL_FUNC_DESC].Text);
                            itmX.SubItems.Add(chkRequired.Checked == true ? "Y" : "N");
                            itmX.SubItems.Add(numPriority.Value.ToString());
                            itmX.SubItems.Add(cdvTranCode.Text);
                            lisAttachedMenu.Items.Insert(lisAttachedMenu.SelectedItems[0].Index, itmX);

                            ListReOrder();
                        }
                        else
                        {
                            for (j = 0; j < lisMenuGrp.Items.Count; j++)
                            {
                                if (lisMenuGrp.Items[j].SubItems[0].Text == txtMenuGrp.Text) break;
                            }

                            if (j == lisMenuGrp.Items.Count)
                                ViewMenuGroupList('2');
                        }
                    }
                }

                if (lisAvailFunc.SelectedItems.Count == 1)
                {
                    idx = lisAvailFunc.SelectedItems[0].Index;
                    if (idx + 1 < lisAvailFunc.Items.Count)
                    {
                        lisAvailFunc.Items[idx].Selected = false;
                        lisAvailFunc.Items[idx + 1].Selected = true;
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int iIdx = 0;
            int i;

            try
            {
                if (CheckCondition(DETACH_MENU) == false)
                {
                    return;
                }

                for (i = lisAttachedMenu.SelectedItems.Count - 1; i >= 0; i--)
                {
                    if (lisAttachedMenu.SelectedItems[i].Text != "Attach ...")
                    {
                        // 마지막 남은 메뉴를 제거하면 Menu Group가 삭제되야 한다
                        if (lisAttachedMenu.Items.Count == 2)
                        {
                            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                            {
                                return;
                            }

                            if (UpdateMenuGroup(MPGC.MP_STEP_DELETE) == true)
                            {
                                btnRefresh.PerformClick();
                            }

                            return;
                        }
                        else
                        {
                            if (UpdateMenuGroup(DETACH_MENU,
                                                0,
                                                lisAttachedMenu.SelectedItems[i].Index,
                                                false) == true)
                            {
                                iIdx = lisAttachedMenu.SelectedItems[i].Index;
                                lisAttachedMenu.Items.RemoveAt(iIdx);

                                ListReOrder();
                            }
                        }
                    }
                }

                if (lisAttachedMenu.Items.Count - 1 == iIdx && iIdx > 0)
                {
                    iIdx--;
                }
                lisAttachedMenu.Items[iIdx].Selected = true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int iCurrentSeq, iPrevSeq;
            ListView.SelectedListViewItemCollection lisItems = lisAttachedMenu.SelectedItems;

            try
            {
                // 리스트에 아이템이 Attach를 제외하고 한개만 존재할때는 동작하지 않도록 함
                if (lisAttachedMenu.Items.Count < 3)
                    return;

                // 선택된 아이템이 없는 경우 동작하지 않도록 함
                if (lisItems.Count == 0)
                    return;

                // 선택된 아이템이 전체를 천택한 경우 동작하지 않도록 함
                if (lisItems.Count > lisAttachedMenu.Items.Count - 2)
                    return;

                if (b_is_processing == false)
                {
                    b_is_processing = true;
                    for (int i = 0; i < lisItems.Count; i++)
                    {
                        if (lisItems[i].Index == 0)
                            continue;

                        if (lisItems[i].Index > lisAttachedMenu.Items.Count - 2)
                            continue;

                        iCurrentSeq = lisItems[i].Index;
                        iPrevSeq = iCurrentSeq - 1;

                        if (lisAttachedMenu.Items[iPrevSeq].Selected == true)
                            continue;

                        // Index 번호와 실제 번호 사이의 차이값 1을 Seq Num에 더해줌
                        if (UpdateMenuGroup(UP_SEQ_MENU, 0, iCurrentSeq, false) == true)
                        {
                            SwapListItem(iCurrentSeq, iPrevSeq);
                            lisAttachedMenu.Items[iPrevSeq].Selected = true;
                        }
                    }

                    lisAttachedMenu.Focus();
                    b_is_processing = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int iCurrentSeq, iNextSeq;
            ListView.SelectedListViewItemCollection lisItems = lisAttachedMenu.SelectedItems;

            try
            {
                // 리스트에 아이템이 Attach를 제외하고 한개만 존재할때는 동작하지 않도록 함
                if (lisAttachedMenu.Items.Count < 3)
                    return;

                // 선택된 아이템이 없는 경우 동작하지 않도록 함
                if (lisItems.Count == 0)
                    return;

                // 선택된 아이템이 전체를 선택한 경우 동작하지 않도록 함
                if (lisItems.Count > lisAttachedMenu.Items.Count - 2)
                    return;

                if (b_is_processing == false)
                {
                    b_is_processing = true;
                    for (int i = lisItems.Count - 1; i >= 0; i--)
                    {
                        if (lisItems[i].Index > lisAttachedMenu.Items.Count - 3)
                            continue;

                        iCurrentSeq = lisItems[i].Index;
                        iNextSeq = iCurrentSeq + 1;

                        if (lisAttachedMenu.Items[iNextSeq].Selected == true)
                            continue;

                        // Index 번호와 실제 번호 사이의 차이값 1을 Seq Num에 더해줌
                        if (UpdateMenuGroup(DOWN_SEQ_MENU, 0, iCurrentSeq, false) == true)
                        {
                            SwapListItem(iCurrentSeq, iNextSeq);
                            lisAttachedMenu.Items[iNextSeq].Selected = true;
                        }
                    }

                    lisAttachedMenu.Focus();
                    b_is_processing = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition(MPGC.MP_STEP_UPDATE) == false) return;

                if (UpdateMenuGroup(MPGC.MP_STEP_UPDATE,
                                    0,
                                    lisAttachedMenu.SelectedItems[0].Index,
                                    true) == true)
                {
                    lisAttachedMenu.SelectedItems[0].SubItems[COL_REQUIRED_FLAG].Text = chkRequired.Checked == true ? "Y" : "N";
                    lisAttachedMenu.SelectedItems[0].SubItems[COL_PRIORITY].Text = numPriority.Value.ToString();
                    lisAttachedMenu.SelectedItems[0].SubItems[COL_TRAN_CODE].Text = cdvTranCode.Text;
                }

                if (b_desc_changed == true)
                    btnRefresh.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void lisAttachedMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisAttachedMenu.SelectedItems.Count < 1) return;

            if (lisAttachedMenu.SelectedItems[0].SubItems[COL_FUNC_DESC].Text == "Attach ...")
                return;

            ViewMenu();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            if (CheckCondition(MPGC.MP_STEP_DELETE) == false) return;

            if (UpdateMenuGroup(MPGC.MP_STEP_DELETE) == false) return;

            btnRefresh.PerformClick();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ViewMenuGroupList();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            MPCF.FindListItemPartial(lisMenuGrp, txtFind.Text, 0, true, false);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisMenuGrp, txtFind.Text, true, false);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MPCF.ExportToExcel(lisMenuGrp, this.Text, "");
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_COPY) == false) return;

            if (UpdateMenuGroup(MPGC.MP_STEP_COPY) == false) return;

            btnRefresh.PerformClick();
        }

        private void btnAttachedRefresh_Click(object sender, EventArgs e)
        {
            ViewMenuGroup(true);
        }

        private void tabMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMenu.SelectedTab == tbpCopy)
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void txtMenuGrp_TextChanged(object sender, EventArgs e)
        {
            Init("INPUT_ID");
        }

        private void pnlUserMid_Resize(object sender, EventArgs e)
        {
            MPCF.FieldAdjust(pnlUserMid, pnlUserMidLeft, pnlUserMidRight, pnlUserMidMid, 40);
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            b_desc_changed = true;
        }
    }
}
