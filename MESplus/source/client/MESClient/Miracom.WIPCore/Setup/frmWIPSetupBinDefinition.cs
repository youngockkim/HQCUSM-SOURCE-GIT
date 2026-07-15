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

namespace Miracom.WIPCore
{
    public partial class frmWIPSetupBinDefinition : SetupForm02
    {
        public frmWIPSetupBinDefinition()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        bool b_load_flag;
        #endregion

        #region " Function Definition "

        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2", "3")
        //
        private void ClearData(char ProcStep)
        {
            try
            {
                dtpStartDate.Enabled = false;
                dtpStartTime.Enabled = false;
                dtpEndDate.Enabled = false;
                dtpEndTime.Enabled = false;

                if (ProcStep == '1')
                {
                    MPCF.FieldClear(this.pnlRight);
                    MPCF.ClearList(lisBinVersion, true);
                }
                else if (ProcStep == '2')
                {
                    txtBinVersion.Text = "";
                    chkApprovalFlag.Checked = false;
                    txtApprovalUser.Text = "";
                    txtApprovalTime.Text = "";
                    chkReleaseFlag.Checked = false;
                    txtReleaseUser.Text = "";
                    txtReleaseTime.Text = "";
                    txtBinVerCreateUser.Text = "";
                    txtBinVerCreateTime.Text = "";
                    txtBinVerUpdateUser.Text = "";
                    txtBinVerUpdateTime.Text = "";
                    chkStart.Checked = false;
                    chkEnd.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            try
            {
                switch (MPCF.Trim(FuncName))
                {
                    case "UpdateBinDef":

                        if (MPCF.CheckValue(txtBinDef, 1) == false)
                        {
                            return false;
                        }

                        switch (ProcStep)
                        {
                            case MPGC.MP_STEP_CREATE:
                            case MPGC.MP_STEP_UPDATE:
                                if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpGroup) == false)
                                {
                                    return false;
                                }

                                //CMF Validation Check
                                if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                                {
                                    return false;
                                }
                                break;

                            case MPGC.MP_STEP_DELETE:

                                break;

                            case MPGC.MP_STEP_UNDELETE:

                                break;

                        }
                        break;

                    case "UpdateBinVersion":

                        if (MPCF.CheckValue(txtBinDef, 1) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtBinVersion, 1) == false)
                        {
                            return false;
                        }

                        switch (ProcStep)
                        {
                            case MPGC.MP_STEP_CREATE:

                                break;

                            case MPGC.MP_STEP_UPDATE:

                                break;

                            case MPGC.MP_STEP_DELETE:

                                break;

                        }
                        break;
                    case "CopyBinVersion":

                        if (MPCF.CheckValue(txtBinDef, 1) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtBinVersion, 1) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtToVersion, 1) == false)
                        {
                            return false;
                        }
                        break;
                    case "CopyBinDef":

                        if (lisBinDef.SelectedItems.Count == 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisBinDef.Focus();
                            return false;
                        }
                        if (MPCF.CheckValue(cdvVersion, 1) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtToBinDef, 1) == false)
                        {
                            return false;
                        }
                        break;
                    default:

                        MPCF.ShowMsgBox("Invalid Case");
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

        //
        // SetGroupCmfItem()
        //       - Set Group & CMF according to Factory GRP/CMF Item
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool SetGroupCmfItem()
        {
            string[] s_bin_def_group_tables = new string[10];

            try
            {
                s_bin_def_group_tables[0] = MPGC.MP_GCM_BIN_DEF_GRP_1;
                s_bin_def_group_tables[1] = MPGC.MP_GCM_BIN_DEF_GRP_2;
                s_bin_def_group_tables[2] = MPGC.MP_GCM_BIN_DEF_GRP_3;
                s_bin_def_group_tables[3] = MPGC.MP_GCM_BIN_DEF_GRP_4;
                s_bin_def_group_tables[4] = MPGC.MP_GCM_BIN_DEF_GRP_5;
                s_bin_def_group_tables[5] = MPGC.MP_GCM_BIN_DEF_GRP_6;
                s_bin_def_group_tables[6] = MPGC.MP_GCM_BIN_DEF_GRP_7;
                s_bin_def_group_tables[7] = MPGC.MP_GCM_BIN_DEF_GRP_8;
                s_bin_def_group_tables[8] = MPGC.MP_GCM_BIN_DEF_GRP_9;
                s_bin_def_group_tables[9] = MPGC.MP_GCM_BIN_DEF_GRP_10;

                MPCR.SetGRPItem(MPGC.MP_GRP_BIN_DEF, "lblGroup", "cdvGroup", grpGroup, s_bin_def_group_tables);
                MPCR.SetCMFItem(MPGC.MP_CMF_BIN_DEF, "lblCMF", "cdvCMF", grpCMF);

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        //
        // View_Col_Set()
        //       - View Collection Set Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewBinDef(string s_bin_id)
        {
            TRSNode in_node = new TRSNode("VIEW_BIN_DEF_IN");
            TRSNode out_node = new TRSNode("VIEW_BIN_DEF_OUT");

            try
            {
                ClearData('1');
                MPCF.ClearList(lisBinVersion, true);
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("BIN_ID", s_bin_id);

                if (MPCR.CallService("WIP", "WIP_View_Bin_Definition", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtBinDef.Text = MPCF.Trim(out_node.GetString("BIN_ID"));
                txtDesc.Text = MPCF.Trim(out_node.GetString("BIN_DESC"));
                cdvGroup1.Text = MPCF.Trim(out_node.GetString("BIN_DEF_GRP_1"));
                cdvGroup2.Text = MPCF.Trim(out_node.GetString("BIN_DEF_GRP_2"));
                cdvGroup3.Text = MPCF.Trim(out_node.GetString("BIN_DEF_GRP_3"));
                cdvGroup4.Text = MPCF.Trim(out_node.GetString("BIN_DEF_GRP_4"));
                cdvGroup5.Text = MPCF.Trim(out_node.GetString("BIN_DEF_GRP_5"));
                cdvGroup6.Text = MPCF.Trim(out_node.GetString("BIN_DEF_GRP_6"));
                cdvGroup7.Text = MPCF.Trim(out_node.GetString("BIN_DEF_GRP_7"));
                cdvGroup8.Text = MPCF.Trim(out_node.GetString("BIN_DEF_GRP_8"));
                cdvGroup9.Text = MPCF.Trim(out_node.GetString("BIN_DEF_GRP_9"));
                cdvGroup10.Text = MPCF.Trim(out_node.GetString("BIN_DEF_GRP_10"));
                cdvCMF1.Text = MPCF.Trim(out_node.GetString("BIN_DEF_CMF_1"));
                cdvCMF2.Text = MPCF.Trim(out_node.GetString("BIN_DEF_CMF_2"));
                cdvCMF3.Text = MPCF.Trim(out_node.GetString("BIN_DEF_CMF_3"));
                cdvCMF4.Text = MPCF.Trim(out_node.GetString("BIN_DEF_CMF_4"));
                cdvCMF5.Text = MPCF.Trim(out_node.GetString("BIN_DEF_CMF_5"));
                cdvCMF6.Text = MPCF.Trim(out_node.GetString("BIN_DEF_CMF_6"));
                cdvCMF7.Text = MPCF.Trim(out_node.GetString("BIN_DEF_CMF_7"));
                cdvCMF8.Text = MPCF.Trim(out_node.GetString("BIN_DEF_CMF_8"));
                cdvCMF9.Text = MPCF.Trim(out_node.GetString("BIN_DEF_CMF_9"));
                cdvCMF10.Text = MPCF.Trim(out_node.GetString("BIN_DEF_CMF_10"));

                chkAppRequireFlag.Checked = (MPCF.Trim(out_node.GetChar("APPROVAL_REQUIRE_FLAG")) == "Y") ? true : false;
                if (chkAppRequireFlag.Checked == true)
                {
                    this.cdvAppUserID.Enabled = true;
                }
                else
                {
                    this.cdvAppUserID.Text = "";
                    this.cdvAppUserID.Enabled = false;
                }
                cdvAppUserID.Text = MPCF.Trim(out_node.GetString("APPROVAL_USER_ID"));
                if (MPCF.Trim(out_node.GetChar("DELETE_FLAG")) == "Y")
                {
                    chkDeleteFlag.Checked = true;
                }
                else
                {
                    chkDeleteFlag.Checked = false;
                }

                txtDeleteUser.Text = MPCF.Trim(out_node.GetString("DELETE_USER_ID"));
                txtDeleteTime.Text = MPCF.MakeDateFormat(out_node.GetString("DELETE_TIME"), DATE_TIME_FORMAT.NONE);
                txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        //
        // Update_Col_Set()
        //       - Create/Update/Delete Collection Set Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("I" - Create, "U" - Update, "D" - Delete, "R" - Undelete)
        //
        private bool UpdateBinDef(char ProcStep)
        {
            ListViewItem itm;

            TRSNode in_node = new TRSNode("UPDATE_BIN_DEF_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("BIN_ID", txtBinDef.Text);
                in_node.AddString("BIN_DESC", txtDesc.Text);

                in_node.AddString("BIN_DEF_GRP_1", MPCF.Trim(cdvGroup1.Text));
                in_node.AddString("BIN_DEF_GRP_2", MPCF.Trim(cdvGroup2.Text));
                in_node.AddString("BIN_DEF_GRP_3", MPCF.Trim(cdvGroup3.Text));
                in_node.AddString("BIN_DEF_GRP_4", MPCF.Trim(cdvGroup4.Text));
                in_node.AddString("BIN_DEF_GRP_5", MPCF.Trim(cdvGroup5.Text));
                in_node.AddString("BIN_DEF_GRP_6", MPCF.Trim(cdvGroup6.Text));
                in_node.AddString("BIN_DEF_GRP_7", MPCF.Trim(cdvGroup7.Text));
                in_node.AddString("BIN_DEF_GRP_8", MPCF.Trim(cdvGroup8.Text));
                in_node.AddString("BIN_DEF_GRP_9", MPCF.Trim(cdvGroup9.Text));
                in_node.AddString("BIN_DEF_GRP_10", MPCF.Trim(cdvGroup10.Text));

                in_node.AddString("BIN_DEF_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("BIN_DEF_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("BIN_DEF_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("BIN_DEF_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("BIN_DEF_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("BIN_DEF_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("BIN_DEF_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("BIN_DEF_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("BIN_DEF_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("BIN_DEF_CMF_10", MPCF.Trim(cdvCMF10.Text));

                in_node.AddChar("APPROVAL_REQUIRE_FLAG", chkAppRequireFlag.Checked == true ? 'Y' : ' ');
                in_node.AddString("APPROVAL_USER_ID", MPCF.Trim(cdvAppUserID.Text), true);

                if (MPCR.CallService("WIP", "WIP_Update_Bin_Definition", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        chkDeleteFlag.Checked = false;
                        itm = lisBinDef.Items.Add(MPCF.Trim(txtBinDef.Text), (int)(SMALLICON_INDEX.IDX_COL_SET));
                        itm.SubItems.Add(MPCF.Trim(txtDesc.Text));
                        itm.Selected = true;
                        lisBinDef.Sorting = SortOrder.Ascending;
                        lisBinDef.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisBinDef, MPCF.Trim(txtBinDef.Text), false) == true)
                        {
                            lisBinDef.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        chkDeleteFlag.Checked = true;
                        if (MPCF.FindListItem(lisBinDef, MPCF.Trim(txtBinDef.Text), false) == true)
                        {
                            lisBinDef.SelectedItems[0].ImageIndex = MPCF.ToInt(SMALLICON_INDEX.IDX_COL_SET_DELETE);
                            lisBinDef.SelectedItems[0].ForeColor = Color.Magenta;
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_UNDELETE)
                    {
                        chkDeleteFlag.Checked = false;
                        if (MPCF.FindListItem(lisBinDef, MPCF.Trim(txtBinDef.Text), false) == true)
                        {
                            lisBinDef.SelectedItems[0].ImageIndex = MPCF.ToInt(SMALLICON_INDEX.IDX_COL_SET);
                            lisBinDef.SelectedItems[0].ForeColor = Color.Black;
                        }
                    }
                    lblDataCount.Text = MPCF.Trim(lisBinDef.Items.Count);
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        //
        // View_Col_Set_Version()
        //       - View Collection Set Version
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewBinVersion()
        {
            TRSNode in_node = new TRSNode("VIEW_BIN_VERSION_IN");
            TRSNode out_node = new TRSNode("VIEW_BIN_VERSION_OUT");

            try
            {
                ClearData('2');

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("BIN_ID", lisBinDef.SelectedItems[0].Text);
                in_node.AddInt("BIN_VERSION", MPCF.ToInt(lisBinVersion.SelectedItems[0].Text));

                if (MPCR.CallService("WIP", "WIP_View_Bin_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtBinVersion.Text = out_node.GetInt("BIN_VERSION").ToString();
                if (out_node.GetString("APPLY_START_TIME") == "")
                {
                    chkStart.Checked = false;
                    dtpStartDate.Enabled = false;
                    dtpStartTime.Enabled = false;
                }
                else
                {
                    chkStart.Checked = true;
                    dtpStartDate.Enabled = true;
                    dtpStartTime.Enabled = true;
                    if (out_node.GetString("APPLY_START_TIME") != null)
                    {
                        dtpStartDate.Value = MPCF.ToDate(out_node.GetString("APPLY_START_TIME"));
                        dtpStartTime.Value = MPCF.ToDate(out_node.GetString("APPLY_START_TIME"));
                    }
                }
                if (out_node.GetString("APPLY_END_TIME") == "")
                {
                    chkEnd.Checked = false;
                    dtpEndDate.Enabled = false;
                    dtpEndTime.Enabled = false;
                }
                else
                {
                    chkEnd.Checked = true;
                    dtpEndDate.Enabled = true;
                    dtpEndTime.Enabled = true;
                    if (out_node.GetString("APPLY_END_TIME") != null)
                    {
                        dtpEndDate.Value = MPCF.ToDate(out_node.GetString("APPLY_END_TIME"));
                        dtpEndTime.Value = MPCF.ToDate(out_node.GetString("APPLY_END_TIME"));
                    }
                }

                chkApprovalFlag.Checked = (MPCF.Trim(out_node.GetChar("APPROVAL_FLAG")) == "Y") ? true : false;
                txtApprovalUser.Text = MPCF.Trim(out_node.GetString("APPROVAL_USER_ID"));
                txtApprovalTime.Text = MPCF.MakeDateFormat(out_node.GetString("APPROVAL_TIME"));
                chkReleaseFlag.Checked = (MPCF.Trim(out_node.GetChar("RELEASE_FLAG")) == "Y") ? true : false;
                txtReleaseUser.Text = MPCF.Trim(out_node.GetString("RELEASE_USER_ID"));
                txtReleaseTime.Text = MPCF.MakeDateFormat(out_node.GetString("RELEASE_TIME"));
                txtBinVerCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
                txtBinVerCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtBinVerUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
                txtBinVerUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        //
        // Update_Col_Set_Version()
        //       - Create/Update/Delete Collection Set Version
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("I" - Create, "U" - Update, "D" - Delete)
        //
        private bool UpdateBinVersion(char ProcStep)
        {

            ListViewItem itm = null;
            int idx = 0;

            TRSNode in_node = new TRSNode("UPDATE_BIN_VERSION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("BIN_ID", lisBinDef.SelectedItems[0].Text);
                in_node.AddInt("BIN_VERSION", MPCF.ToInt(txtBinVersion.Text));

                if (chkStart.Checked == true)
                {
                    String s_datetime = MPCF.ToStandardTime(dtpStartDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) +
                        MPCF.ToStandardTime(dtpStartTime.Value, MPGC.MP_CONVERT_TIME_FORMAT);
                    in_node.AddString("APPLY_START_TIME", s_datetime);
                }

                if (chkEnd.Checked == true)
                {
                    String s_datetime = MPCF.ToStandardTime(dtpEndDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) +
                        MPCF.ToStandardTime(dtpEndTime.Value, MPGC.MP_CONVERT_TIME_FORMAT);
                    in_node.AddString("APPLY_END_TIME", s_datetime);
                }

                if (MPCR.CallService("WIP", "WIP_Update_Bin_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisBinVersion.Items.Add(MPCF.Trim(txtBinVersion.Text), (int)(SMALLICON_INDEX.IDX_COL_SET_VERSION));
                        itm.Selected = true;
                        lisBinVersion.Sorting = SortOrder.Ascending;
                        lisBinVersion.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        //Do Nothing
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisBinVersion, MPCF.Trim(txtBinVersion.Text), false);
                        if (idx != -1)
                        {
                            lisBinVersion.Items[idx].Remove();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        //
        // Copy_Col_Set_Version()
        //       - Copy Collection Set Version and it's attached character
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool CopyBinVersion(char ProcStep)
        {

            ListViewItem itm;

            TRSNode in_node = new TRSNode("COPY_BIN_VERSION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("BIN_ID", MPCF.Trim(txtBinDef.Text));
                in_node.AddInt("BIN_VERSION", MPCF.ToInt(MPCF.Trim(txtToVersion.Text)));
                in_node.AddInt("FROM_BIN_VERSION", MPCF.ToInt(MPCF.Trim(txtBinVersion.Text)));

                if (MPCR.CallService("WIP", "WIP_Copy_Bin_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_COPY)
                    {
                        itm = lisBinVersion.Items.Add(MPCF.Trim(txtToVersion.Text), (int)SMALLICON_INDEX.IDX_COL_SET_VERSION);
                        itm.Selected = true;
                        itm.EnsureVisible();
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        //
        // Copy_Col_Set()
        //       - Copy Collection Set and it's attached character
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool CopyBinDef()
        {
            ListViewItem itm;

            TRSNode in_node = new TRSNode("COPY_BIN_DEF_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_COPY;
                in_node.AddString("FROM_BIN_ID", MPCF.Trim(lisBinDef.SelectedItems[0].Text));
                in_node.AddInt("FROM_BIN_VERSION", MPCF.ToInt(MPCF.Trim(cdvVersion.Text)));
                in_node.AddString("TO_BIN_ID", MPCF.Trim(txtToBinDef.Text));

                if (MPCR.CallService("WIP", "WIP_Copy_Bin_Definition", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (lisBinDef.Items.Count > 0)
                    {
                        if (MPCF.FindListItem(lisBinDef, txtToBinDef.Text, false) == false)
                        {
                            itm = lisBinDef.Items.Add(MPCF.Trim(txtToBinDef.Text), (int)SMALLICON_INDEX.IDX_COL_SET);
                            itm.Selected = true;
                            itm.EnsureVisible();
                        }
                    }
                    else
                    {
                        itm = lisBinDef.Items.Add(MPCF.Trim(txtToBinDef.Text), (int)SMALLICON_INDEX.IDX_COL_SET);
                        itm.Selected = true;
                        itm.EnsureVisible();
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        private bool GenerateID()
        {
            TRSNode in_node = new TRSNode("GENERATE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddChar("REL_LEVEL", '8');
                in_node.AddString("TRAN_CODE", "CREATE_BIN");

                if (MPCR.CallService("WIP", "WIP_Generate_ID", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtBinDef.Text = MPCF.Trim(out_node.GetString("GEN_ID"));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }


        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.lisBinDef;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmWIPSetupBinDefinition_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    MPCF.InitListView(lisBinDef);
                    MPCF.InitListView(lisBinVersion);

                    if (SetGroupCmfItem() == false)
                    {
                        return;
                    }

                    if (cdvAppUserID.DisplaySubItemIndex != cdvAppUserID.SelectedSubItemIndex)
                    {
                        cdvAppUserID_ButtonPress(null, null);
                    }

                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("UpdateBinDef", MPGC.MP_STEP_CREATE) == true)
                {
                    if (UpdateBinDef(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnVerCreate_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("UpdateBinVersion", MPGC.MP_STEP_CREATE) == true)
                {
                    if (UpdateBinVersion(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (WIPLIST.ViewBinVersionList(lisBinVersion, txtBinDef.Text) == false)
                        {
                            return;
                        }
                        if (lisBinVersion.Items.Count > 0)
                        {
                            MPCF.FindListItem(lisBinVersion, txtBinVersion.Text, false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("UpdateBinDef", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (UpdateBinDef(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnVerUpdate_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("UpdateBinVersion", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (UpdateBinVersion(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (WIPLIST.ViewBinVersionList(lisBinVersion, txtBinDef.Text) == false)
                        {
                            return;
                        }
                        if (lisBinVersion.Items.Count > 0)
                        {
                            MPCF.FindListItem(lisBinVersion, txtBinVersion.Text, false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (CheckCondition("UpdateBinDef", MPGC.MP_STEP_DELETE) == true)
                {
                    if (UpdateBinDef(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnVerDelete_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (CheckCondition("UpdateBinVersion", MPGC.MP_STEP_DELETE) == true)
                {
                    if (UpdateBinVersion(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }

                    ClearData('2');
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        WIPLIST.ViewBinVersionList(lisBinVersion, txtBinDef.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnUndelete_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (tabBinDef.SelectedTab.TabIndex > 3)
                {
                    return;
                }
                if (CheckCondition("UpdateBinDef", MPGC.MP_STEP_UNDELETE) == true)
                {
                    if (UpdateBinDef(MPGC.MP_STEP_UNDELETE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void lisBinDef_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (lisBinDef.SelectedIndices.Count > 0)
                {
                    if (ViewBinDef(lisBinDef.SelectedItems[0].Text) == false)
                    {
                        return;
                    }
                    if (WIPLIST.ViewBinVersionList(lisBinVersion, lisBinDef.SelectedItems[0].Text) == false)
                    {
                        return;
                    }
                    if (lisBinVersion.Items.Count > 0)
                    {
                        lisBinVersion.Items[0].Selected = true;
                    }
                }
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
                /* 2013.06.12. Aiden. Filter 추가 */
                if (WIPLIST.ViewBinDefList(lisBinDef, chkIncludeDeleteBIN.Checked, txtFilter.Text) == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisBinDef.Items.Count);
                    if (lisBinDef.Items.Count > 0)
                    {
                        MPCF.FindListItem(lisBinDef, txtBinDef.Text, false);
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
                if (lisBinDef.Items.Count > 0)
                {
                    MPCF.ExportToExcel(lisBinDef, this.Text, "");
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void lisBinVersion_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (lisBinVersion.SelectedItems.Count > 0)
                {
                    ViewBinVersion();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvGroupCmf_ButtonPress(object sender, System.EventArgs e)
        {
            try
            {
                MPCR.ProcGRPCMFButtonPress(sender);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtBinVersion_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13 || e.KeyChar == (char)8)
                {
                    return;
                }
                else if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvCMF_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                MPCR.CheckCMFKeyPress(sender, e);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void chkStart_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (chkStart.Checked == true)
                {
                    dtpStartDate.Enabled = true;
                    dtpStartTime.Enabled = true;
                }
                else
                {
                    dtpStartDate.Enabled = false;
                    dtpStartTime.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void chkEnd_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (chkEnd.Checked == true)
                {
                    dtpEndDate.Enabled = true;
                    dtpEndTime.Enabled = true;
                }
                else
                {
                    dtpEndDate.Enabled = false;
                    dtpEndTime.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void tabBinDef_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (!(tabBinDef.SelectedTab == tbpBinVersion))
                {
                    MPCR.ChangeControlEnabled(this, btnCreate, true);
                    MPCR.ChangeControlEnabled(this, btnUpdate, true);
                    MPCR.ChangeControlEnabled(this, btnDelete, true);
                    MPCR.ChangeControlEnabled(this, btnUndelete, true);
                }
                else
                {
                    btnCreate.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnUndelete.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnCopy_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("CopyBinVersion", MPGC.MP_STEP_COPY) == true)
                {
                    if (CopyBinVersion(MPGC.MP_STEP_COPY) == false)
                    {
                        return;
                    }
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (WIPLIST.ViewBinVersionList(lisBinVersion, txtBinDef.Text) == false)
                        {
                            return;
                        }
                        if (lisBinVersion.Items.Count > 0)
                        {
                            MPCF.FindListItem(lisBinVersion, txtToVersion.Text, false);
                        }
                    }
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
                MPCF.FindListItemNextPartial(lisBinDef, txtFind.Text, true, false);
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
                MPCF.FindListItemPartial(lisBinDef, txtFind.Text, 0, true, false);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void tabVersion_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (!(tabVersion.SelectedTab == tbpCopy))
                {
                    MPCR.ChangeControlEnabled(this, btnVerCreate, true);
                    MPCR.ChangeControlEnabled(this, btnVerUpdate, true);
                    MPCR.ChangeControlEnabled(this, btnVerDelete, true);
                }
                else
                {
                    btnVerCreate.Enabled = false;
                    btnVerUpdate.Enabled = false;
                    btnVerDelete.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvAppUserID_ButtonPress(object sender, System.EventArgs e)
        {
            try
            {
                cdvAppUserID.Init();
                MPCF.InitListView(cdvAppUserID.GetListView);
                cdvAppUserID.Columns.Add("UserID", 100, HorizontalAlignment.Left);
                cdvAppUserID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvAppUserID.SelectedSubItemIndex = 0;

                if (SECLIST.ViewSECUserList(cdvAppUserID.GetListView) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvVersion_ButtonPress(object sender, System.EventArgs e)
        {
            try
            {
                cdvVersion.Init();
                MPCF.InitListView(cdvVersion.GetListView);
                cdvVersion.Columns.Add("Version", 50, HorizontalAlignment.Left);
                cdvVersion.SelectedSubItemIndex = 0;
                if (WIPLIST.ViewBinVersionList(cdvVersion.GetListView, txtBinDef.Text) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnBinCopy_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("CopyBinDef", MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
                if (CopyBinDef() == false)
                {
                    return;
                }
                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void chkAppRequireFlag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAppRequireFlag.Checked == true)
                {
                    this.cdvAppUserID.Enabled = true;
                }
                else
                {
                    this.cdvAppUserID.Text = "";
                    this.cdvAppUserID.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnGenerateID_Click(object sender, EventArgs e)
        {
            GenerateID();
        }

        /* 2013.06.12. Aiden. Filter 추가 */
        private void btnFilterView_Click(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
        }


    }
}
