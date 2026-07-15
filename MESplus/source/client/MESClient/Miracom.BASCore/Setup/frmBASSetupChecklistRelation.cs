using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASSetupChecklistRelation.cs
//   Description : Setup Checklist Relation
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - 
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2012-11-14 : Created by Yeonggon Son
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

namespace Miracom.BASCore
{
    public partial class frmBASSetupChecklistRelation : Miracom.MESCore.SetupForm02
    {
        #region " Variable Definition "

        bool b_load_flag = false;
        TRSNode m_chklist_info = null;

        #endregion

        #region " Property Definition "

        TRSNode CHKLIST
        {
            get
            {
                if (m_chklist_info == null) m_chklist_info = new TRSNode("");
                return m_chklist_info;
            }
        }
        #endregion

        #region " Constant Definition "

        #endregion

        #region " Form Definition "

        public frmBASSetupChecklistRelation()
        {
            InitializeComponent();
        }        

        #endregion

        #region " Functions Definition "

        private bool ChangeTabPage()
        {
            try
            {
                if (this.tabRelation.SelectedTab == this.tbpMFO)
                {
                    lisEventChecklist.Visible = false;
                    lisTranChecklist.Visible = true;

                    grpLotBaseRelation.Dock = DockStyle.Fill;
                    grpResourceBaseRelation.Dock = DockStyle.None;
                    grpLotBaseRelation.Visible = true;
                    grpResourceBaseRelation.Visible = false;
                }

                else if (this.tabRelation.SelectedTab == this.tbpResource)
                {
                    lisEventChecklist.Visible = true;
                    lisTranChecklist.Visible = false;

                    grpLotBaseRelation.Dock = DockStyle.None;
                    grpResourceBaseRelation.Dock = DockStyle.Fill;
                    grpLotBaseRelation.Visible = false;
                    grpResourceBaseRelation.Visible = true;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ChangeTopListItem()
        {
            try
            {
                if (this.tabRelation.SelectedTab == this.tbpMFO)
                {
                    BASLIST.ViewChecklistRelationList(lisTranChecklist, '1', udcMFO.SelectLevelChar, udcMFO.MatID, udcMFO.MatVersion, udcMFO.Flow, udcMFO.Oper, "", "", "");
                }
                else if (this.tabRelation.SelectedTab == this.tbpResource)
                {
                    BASLIST.ViewChecklistRelationList(lisEventChecklist, '1', udcResourceTreeList.SelectLevelChar, "", 0, "", "", udcResourceTreeList.ResourceGroup, udcResourceTreeList.ResourceType, udcResourceTreeList.Resource);
                }
                
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ClearField(char cStep)
        {
            try
            {
                if (cStep == '2')
                {
                    cdvChecklistID.ResetText();
                    MPCF.ClearList(lisEventChecklist);
                    MPCF.ClearList(lisTranChecklist);
                }

                m_chklist_info = null;

                txtDesc.ResetText();

                chkFromTime.Checked = false;
                chkToTime.Checked = false;
                dtpFromDate.Enabled = false;
                dtpFromDate.ResetText();
                dtpFromTime.Enabled = false;
                dtpFromTime.ResetText();
                dtpToDate.Enabled = false;
                dtpToDate.ResetText();
                dtpToTime.Enabled = false;
                dtpToTime.ResetText();

                chkRequire.Checked = false;
                cdvCompleteUser.ResetText();

                txtLotID.ResetText();
                chkInheritChild.Checked = false;
                chkInheritChild.Enabled = false;

                cdvEvent.ResetText();
                rdoEventAfter.Checked = false;
                rdoEventAfter.Enabled = false;
                rdoEventBefore.Checked = false;
                rdoEventBefore.Enabled = false;

                cboTransaction.ResetText();
                rdoTranAfter.Checked = false;
                rdoTranAfter.Enabled = false;
                rdoTranBefore.Checked = false;
                rdoTranBefore.Enabled = false;

                cdvChecklistKeyPrompt.Clear();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // UpdateChecklistRelation()
        //       - Update Checklist - MFO or Resource Relation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - Optional ByVal cProcStep As Char : Process Step
        //
        private bool UpdateChecklistRelation(char ProcStep)
        {
            TRSNode in_node = new TRSNode("UPDATE_CHECKLIST_RELATION_IN");
            TRSNode out_node = new TRSNode("UPDATE_CHECKLIST_RELATION_OUT");
            string sNaming = string.Empty;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                if (this.tabRelation.SelectedTab == this.tbpMFO)
                {
                    in_node.SetChar("REL_LEVEL", udcMFO.SelectLevelChar);
                    in_node.SetString("MAT_ID", udcMFO.MatID);
                    in_node.SetInt("MAT_VER", udcMFO.MatVersion);
                    in_node.SetString("FLOW", udcMFO.Flow);
                    in_node.SetString("OPER", udcMFO.Oper);
                    in_node.SetString("LOT_ID", MPCF.Trim(txtLotID.Text));
                    in_node.SetString("TRAN_CODE", MPCF.Trim(cboTransaction.Text));

                    if(MPCF.Trim(cboTransaction.Text) != "")
                    {
                        if (rdoTranBefore.Checked) in_node.AddChar("BA_POINT", 'B');
                        else if (rdoTranAfter.Checked) in_node.AddChar("BA_POINT", 'A');
                    }
                }
                else if (this.tabRelation.SelectedTab == this.tbpResource)
                {
                    in_node.SetChar("REL_LEVEL", udcResourceTreeList.SelectLevelChar);
                    in_node.SetString("RESG_ID", udcResourceTreeList.ResourceGroup);
                    in_node.SetString("RES_TYPE", udcResourceTreeList.ResourceType);
                    in_node.SetString("RES_ID", udcResourceTreeList.Resource);
                    in_node.SetString("EVENT_ID", cdvEvent.Text.ToString());

                    if (MPCF.Trim(cdvEvent.Text) != "")
                    {
                        if (rdoEventBefore.Checked) in_node.AddChar("BA_POINT", 'B');
                        else if (rdoEventAfter.Checked) in_node.AddChar("BA_POINT", 'A');
                    }
                }
               
                in_node.SetString("CHKLIST_ID", cdvChecklistID.Text.ToString());

                if (chkFromTime.Checked == true)
                {
                    in_node.SetString("APPLY_FROM_TIME", dtpFromDate.Value.ToString("yyyyMMdd") + dtpFromTime.Value.ToString("HHmmss"));
                }
                if (chkToTime.Checked == true)
                {
                    in_node.SetString("APPLY_TO_TIME", dtpToDate.Value.ToString("yyyyMMdd") + dtpToTime.Value.ToString("HHmmss"));
                }

                in_node.SetChar("REQ_COMPLETE_FLAG", chkRequire.Checked ? 'Y' : 'N');
                in_node.SetString("COMPLETE_USER_ID", MPCF.Trim(cdvCompleteUser.Text.ToString()));
                in_node.SetChar("INHERIT_CHILD_FLAG", chkInheritChild.Checked ? 'Y' : 'N');

                cdvChecklistKeyPrompt.FillKeyPromptSetup(ref in_node);

                if (MPCR.CallService("BAS", "BAS_Update_Checklist_Relation", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPGV.gbListAutoRefresh == false)
                {
                    ListView lisChecklist = null;
                    ListViewItem itmX = null;
                    int selected_index = -1;
                    string ApplyTime = null;

                    if (this.tabRelation.SelectedTab == this.tbpMFO)
                    {
                        lisChecklist = lisTranChecklist;
                        if (lisTranChecklist.SelectedIndices != null && lisTranChecklist.SelectedIndices.Count > 0)
                            selected_index = lisTranChecklist.SelectedIndices[0];
                    }
                    else
                    {
                        lisChecklist = lisEventChecklist;
                        if (lisTranChecklist.SelectedIndices != null && lisTranChecklist.SelectedIndices.Count > 0)
                            selected_index = lisEventChecklist.SelectedIndices[0];
                    }

                    ApplyTime = "";
                    if (MPCF.Trim(in_node.GetString("APPLY_FROM_TIME")) != "")
                    {
                        ApplyTime = MPCF.MakeDateFormat(in_node.GetString("APPLY_FROM_TIME")) + " ~ ";
                    }
                    if (MPCF.Trim(in_node.GetString("APPLY_TO_TIME")) != "")
                    {
                        if (ApplyTime == "") ApplyTime = " ~ ";
                        ApplyTime += MPCF.MakeDateFormat(in_node.GetString("APPLY_TO_TIME"));
                    }

                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itmX = new ListViewItem(MPCF.Trim(in_node.GetString("CHKLIST_ID")), (int)SMALLICON_INDEX.IDX_MESSAGE);
                        if (tabRelation.SelectedTab == tbpMFO)
                        {
                            itmX.SubItems.Add(MPCF.Trim(in_node.GetString("LOT_ID")));
                            itmX.SubItems.Add(MPCF.Trim(in_node.GetChar("INHERIT_CHILD_FLAG")));
                            itmX.SubItems.Add(MPCF.Trim(in_node.GetChar("REQ_COMPLETE_FLAG")));
                            itmX.SubItems.Add(MPCF.Trim(in_node.GetString("TRAN_CODE")));
                            if (in_node.GetChar("BA_POINT") == 'B')
                            {
                                itmX.SubItems.Add("Before");
                            }
                            else if (in_node.GetChar("BA_POINT") == 'A')
                            {
                                itmX.SubItems.Add("After");
                            }
                            else
                            {
                                itmX.SubItems.Add("");
                            }
                            itmX.SubItems[itmX.SubItems.Count -1].Tag = in_node.GetChar("BA_POINT");
                            itmX.SubItems.Add(ApplyTime);
                        }
                        else
                        {
                            itmX.SubItems.Add(MPCF.Trim(in_node.GetChar("REQ_COMPLETE_FLAG")));
                            itmX.SubItems.Add(MPCF.Trim(in_node.GetString("EVENT_ID")));
                            if (in_node.GetChar("BA_POINT") == 'B')
                            {
                                itmX.SubItems.Add("Before");
                            }
                            else if (in_node.GetChar("BA_POINT") == 'A')
                            {
                                itmX.SubItems.Add("After");
                            }
                            else
                            {
                                itmX.SubItems.Add("");
                            }
                            itmX.SubItems[itmX.SubItems.Count - 1].Tag = in_node.GetChar("BA_POINT");
                            itmX.SubItems.Add(ApplyTime);
                        }

                        lisChecklist.Items.Add(itmX);
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (selected_index >= 0)
                        {
                            if (tabRelation.SelectedTab == tbpMFO)
                            {
                                lisChecklist.Items[selected_index].SubItems[colApplyFromTo1.Index].Text = ApplyTime;
                                lisChecklist.Items[selected_index].SubItems[colRequireCompleteFlag1.Index].Text = MPCF.Trim(in_node.GetChar("REQ_COMPLETE_FLAG"));
                                lisChecklist.Items[selected_index].SubItems[colInheritChildLotFlag.Index].Text = MPCF.Trim(in_node.GetChar("INHERIT_CHILD_FLAG"));
                            }
                            else
                            {
                                lisChecklist.Items[selected_index].SubItems[colApplyFromTo2.Index].Text = ApplyTime;
                                lisChecklist.Items[selected_index].SubItems[colRequireCompleteFlag2.Index].Text = MPCF.Trim(in_node.GetChar("REQ_COMPLETE_FLAG"));
                            }
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        /*
                         * MFO 탭이 선택되어 있을 경우 lisTranChecklist에 등록된 Checklist ID 삭제
                         * RESOURCE 탭이 선택되어 있을 경우 lisEventChecklist에 등록된 Checklist ID 삭제
                         */
                        if (selected_index >= 0)
                        {
                            lisChecklist.Items[selected_index].Remove();
                        }
                    }
                }

                MPCR.ShowSuccessMsg(out_node);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewChecklistRelationList_MFO(Control control, char rel_level, string mat_id, int mat_ver, string flow, string oper)
        {
            int i;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("VIEW_CHECKLIST_RELATION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_CHECKLIST_RELATION_LIST_OUT");

            string ApplyTime;

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, true);
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddChar("REL_LEVEL", rel_level);
            in_node.AddString("MAT_ID", mat_id);
            in_node.AddInt("MAT_VER", mat_ver);
            in_node.AddString("FLOW", flow);
            in_node.AddString("OPER", oper);
            in_node.AddString("NEXT_CHKLIST_ID", "");

            do
            {
                if (MPCR.CallService("BAS", "BAS_View_Checklist_Relation_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    ApplyTime = "";

                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("CHKLIST_ID")), (int)SMALLICON_INDEX.IDX_MESSAGE);
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("INHERIT_CHILD_FLAG")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("REQ_COMPLETE_FLAG")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CODE")));
                        if (out_node.GetList(0)[i].GetChar("BA_POINT") == 'B')
                        {
                            itmX.SubItems.Add("Before");
                        }
                        else if (out_node.GetList(0)[i].GetChar("BA_POINT") == 'A')
                        {
                            itmX.SubItems.Add("After");
                        }
                        else
                        {
                            itmX.SubItems.Add("");
                        }
                        itmX.SubItems[colBAPoint1.DisplayIndex].Tag = out_node.GetList(0)[i].GetChar("BA_POINT");

                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("APPLY_FROM_TIME")) != "")
                        {
                            ApplyTime = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("APPLY_FROM_TIME")) + " ~ ";
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("APPLY_TO_TIME")) != "")
                        {
                            if (ApplyTime == "") ApplyTime = " ~ ";
                            ApplyTime += MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("APPLY_TO_TIME"));
                        }

                        itmX.SubItems.Add(ApplyTime);

                        ((ListView)control).Items.Add(itmX);
                    }
                }
                in_node.SetString("NEXT_CHKLIST_ID", out_node.GetString("NEXT_CHKLIST_ID"));
            } while (in_node.GetString("NEXT_CHKLIST_ID") != "");

            return true;
        }

        private bool ViewChecklistRelationList_RAS(Control control, char rel_level, string res_type, string resg_id, string res_id)
        {
            int i;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("VIEW_CHECKLIST_RELATION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_CHECKLIST_RELATION_LIST_OUT");

            string ApplyTime;

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }
            else if (!(control is TreeView))
            {
                MPCF.ClearList(control, true);
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddChar("REL_LEVEL", rel_level);
            in_node.AddString("RES_TYPE", res_type);
            in_node.AddString("RESG_ID", resg_id);
            in_node.AddString("RES_ID", res_id);
            in_node.AddString("NEXT_CHKLIST_ID", "");

            do
            {
                if (MPCR.CallService("BAS", "BAS_View_Checklist_Relation_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    ApplyTime = "";

                    if (control is ListView)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("CHKLIST_ID")), (int)SMALLICON_INDEX.IDX_MESSAGE);
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("REQ_COMPLETE_FLAG")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID")));
                        if (out_node.GetList(0)[i].GetChar("BA_POINT") == 'B')
                        {
                            itmX.SubItems.Add("Before");
                        }
                        else if (out_node.GetList(0)[i].GetChar("BA_POINT") == 'A')
                        {
                            itmX.SubItems.Add("After");
                        }
                        else
                        {
                            itmX.SubItems.Add("");
                        }
                        itmX.SubItems[colBAPoint2.DisplayIndex].Tag = out_node.GetList(0)[i].GetChar("BA_POINT");

                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("APPLY_FROM_TIME")) != "")
                        {
                            ApplyTime = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("APPLY_FROM_TIME")) + " ~ ";
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("APPLY_TO_TIME")) != "")
                        {
                            if (ApplyTime == "") ApplyTime = " ~ ";
                            ApplyTime += MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("APPLY_TO_TIME"));
                        }

                        itmX.SubItems.Add(ApplyTime);

                        ((ListView)control).Items.Add(itmX);
                    }
                }
                in_node.SetString("NEXT_CHKLIST_ID", out_node.GetString("NEXT_CHKLIST_ID"));
            } while (in_node.GetString("NEXT_CHKLIST_ID") != "");

            return true;
        }

        //
        // ViewChecklistRelation()
        //       - View Checklist Relation - MFO or Resource Relation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool ViewChecklistRelation()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_CHECKLIST_RELATION_IN");
                TRSNode out_node = new TRSNode("VIEW_CHECKLIST_RELATION_OUT");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (this.tabRelation.SelectedTab == this.tbpMFO)
                {
                    if (lisTranChecklist.SelectedItems.Count == 0) return true;

                    in_node.AddString("REL_LEVEL", udcMFO.SelectLevelChar);
                    in_node.AddString("MAT_ID", udcMFO.MatID);
                    in_node.AddInt("MAT_VER", udcMFO.MatVersion);
                    in_node.AddString("FLOW", udcMFO.Flow);
                    in_node.AddString("OPER", udcMFO.Oper);
                    in_node.AddString("CHKLIST_ID", MPCF.Trim(lisTranChecklist.SelectedItems[0].Text));
                    in_node.AddString("TRAN_CODE", MPCF.Trim(lisTranChecklist.SelectedItems[0].SubItems[colTranCode.DisplayIndex].Text));
                    in_node.AddChar("BA_POINT", MPCF.ToChar(lisTranChecklist.SelectedItems[0].SubItems[colBAPoint1.DisplayIndex].Tag));
                    in_node.AddString("LOT_ID", MPCF.Trim(lisTranChecklist.SelectedItems[0].SubItems[colLotID.DisplayIndex].Text));
                }
                else if (this.tabRelation.SelectedTab == this.tbpResource)
                {
                    if (lisEventChecklist.SelectedItems.Count == 0) return true;

                    in_node.AddString("REL_LEVEL", udcResourceTreeList.SelectLevelChar);
                    in_node.AddString("RESG_ID", udcResourceTreeList.ResourceGroup);
                    in_node.AddString("RES_TYPE", udcResourceTreeList.ResourceType);
                    in_node.AddString("RES_ID", udcResourceTreeList.Resource);
                    in_node.AddString("CHKLIST_ID", MPCF.Trim(lisEventChecklist.SelectedItems[0].Text));
                    in_node.AddString("EVENT_ID", MPCF.Trim(lisEventChecklist.SelectedItems[0].SubItems[colEventID.DisplayIndex].Text));
                    in_node.AddChar("BA_POINT", MPCF.ToChar(lisEventChecklist.SelectedItems[0].SubItems[colBAPoint2.DisplayIndex].Tag));
                }

                if (MPCR.CallService("BAS", "BAS_View_Checklist_Relation", in_node, ref out_node) == false)
                {
                    return false;
                }

                m_chklist_info = out_node;

                cdvChecklistID.Text = MPCF.Trim(out_node.GetString("CHKLIST_ID"));
                txtDesc.Text = MPCF.Trim(out_node.GetString("CHKLIST_DESC"));

                if (MPCF.Trim(out_node.GetString("APPLY_FROM_TIME")) != "")
                {
                    chkFromTime.Checked = true;
                    dtpFromDate.Text = MPCF.MakeDateFormat(out_node.GetString("APPLY_FROM_TIME"), DATE_TIME_FORMAT.DATE);
                    dtpFromTime.Text = MPCF.MakeDateFormat(out_node.GetString("APPLY_FROM_TIME").Substring(8), DATE_TIME_FORMAT.TIME);
                }

                if (MPCF.Trim(out_node.GetString("APPLY_TO_TIME")) != "")
                {
                    chkToTime.Checked = true;
                    dtpToDate.Text = MPCF.MakeDateFormat(out_node.GetString("APPLY_TO_TIME"), DATE_TIME_FORMAT.DATE);
                    dtpToTime.Text = MPCF.MakeDateFormat(out_node.GetString("APPLY_TO_TIME").Substring(8), DATE_TIME_FORMAT.TIME);
                }

                if (out_node.GetChar("REQ_COMPLETE_FLAG") == 'Y')
                {
                    chkRequire.Checked = true;
                    cdvCompleteUser.Text = out_node.GetString("COMPLETE_USER_ID");
                }

                if (string.IsNullOrEmpty(out_node.GetString("LOT_ID")) == false)
                {
                    txtLotID.Text = out_node.GetString("LOT_ID");

                    if (out_node.GetChar("INHERIT_CHILD_FLAG") == 'Y')
                    {
                        chkInheritChild.Checked = true;
                    }
                }

                if (string.IsNullOrEmpty(out_node.GetString("EVENT_ID")) == false)
                {
                    cdvEvent.Text = out_node.GetString("EVENT_ID");
                    rdoEventAfter.Enabled = true;
                    rdoEventBefore.Enabled = true;
                }
                else
                {
                    rdoEventAfter.Enabled = false;
                    rdoEventBefore.Enabled = false;
                }

                if (string.IsNullOrEmpty(out_node.GetString("TRAN_CODE")) == false)
                {
                    cboTransaction.Text = out_node.GetString("TRAN_CODE");
                    rdoTranAfter.Enabled = true;
                    rdoTranBefore.Enabled = true;
                }

                if (this.tabRelation.SelectedTab == this.tbpMFO)
                {
                    if (out_node.GetChar("BA_POINT") == 'A')
                    {
                        rdoTranAfter.Checked = true;
                    }
                    else if (out_node.GetChar("BA_POINT") == 'B')
                    {
                        rdoTranBefore.Checked = true;
                    }
                }
                else if (this.tabRelation.SelectedTab == this.tbpResource)
                {
                    if (out_node.GetChar("BA_POINT") == 'A')
                    {
                        rdoEventAfter.Checked = true;
                    }
                    else if (out_node.GetChar("BA_POINT") == 'B')
                    {
                        rdoEventBefore.Checked = true;
                    }
                }

                cdvChecklistKeyPrompt.DisplayKeyPromptSetup(ref out_node);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // ViewResourceSettingDataList()
        //       - Get setting data list
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool ViewResourceSettingDataList()
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            System.Text.StringBuilder sb;

            MPCF.InitListView(udcResourceTreeList.GetListView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            sb = new System.Text.StringBuilder();

            switch (udcResourceTreeList.SelectLevel)
            {
                case MESCore.Controls.ResourceSelectLevel.R:
                    sb.Append("SELECT RES_ID FROM MBASCHKLSR ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND REL_LEVEL = 'R' ");
                    sb.Append("GROUP BY RES_ID ");
                    sb.Append("ORDER BY RES_ID");
                    break;

                case MESCore.Controls.ResourceSelectLevel.TR:
                    sb.Append("SELECT RES_TYPE, RES_ID FROM MBASCHKLSR ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND REL_LEVEL = 'T' ");
                    sb.Append("GROUP BY RES_TYPE, RES_ID ");
                    sb.Append("ORDER BY RES_TYPE, RES_ID");
                    break;

                case MESCore.Controls.ResourceSelectLevel.GR:
                    sb.Append("SELECT RESG_ID, RES_ID FROM MBASCHKLSR ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND REL_LEVEL = 'G' ");
                    sb.Append("GROUP BY RESG_ID, RES_ID ");
                    sb.Append("ORDER BY RESG_ID, RES_ID");
                    break;
                default:
                    return false;
            }

            in_node.AddString("SQL", sb.ToString());

            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(udcResourceTreeList.GetListView, out_node, false, (int)SMALLICON_INDEX.IDX_RESOURCE, false);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (in_node.GetInt("NEXT_ROW") > 0);

            return true;
        }

        //
        // ViewResourceSettingDataList()
        //       - Get setting data list
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool ViewMFOSettingDataList()
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            System.Text.StringBuilder sb;
            char[] c_rel_level;

            MPCF.InitListView(udcMFO.GetListView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            c_rel_level = new char[2];
            c_rel_level[0] = ' ';
            c_rel_level[1] = ' ';


            sb = new System.Text.StringBuilder();

            switch (udcMFO.SelectLevel)
            {
                case MESCore.Controls.MFOSelectLevel.M:
                    sb.AppendFormat("SELECT MAT_ID, MAT_VER FROM MBASCHKLSR ");
                    sb.AppendFormat("WHERE FACTORY = '{0}' ", MPGV.gsFactory);
                    sb.AppendFormat("AND REL_LEVEL = '{0}' ", udcMFO.SelectLevelChar);
                    sb.Append("GROUP BY MAT_ID, MAT_VER ");
                    sb.Append("ORDER BY MAT_ID, MAT_VER");
                    break;
                case MESCore.Controls.MFOSelectLevel.MF:
                    sb.AppendFormat("SELECT MAT_ID, MAT_VER, FLOW FROM MBASCHKLSR ");
                    sb.AppendFormat("WHERE FACTORY = '{0}' ", MPGV.gsFactory);
                    sb.AppendFormat("AND REL_LEVEL = '{0}' ", udcMFO.SelectLevelChar);
                    sb.Append("GROUP BY MAT_ID, MAT_VER, FLOW ");
                    sb.Append("ORDER BY MAT_ID, MAT_VER, FLOW");
                    break;
                case MESCore.Controls.MFOSelectLevel.MO:
                    sb.AppendFormat("SELECT MAT_ID, MAT_VER, OPER FROM MBASCHKLSR ");
                    sb.AppendFormat("WHERE FACTORY = '{0}' ", MPGV.gsFactory);
                    sb.AppendFormat("AND REL_LEVEL = '{0}' ", udcMFO.SelectLevelChar);
                    sb.Append("GROUP BY MAT_ID, MAT_VER, OPER ");
                    sb.Append("ORDER BY MAT_ID, MAT_VER, OPER");
                    break;
                case MESCore.Controls.MFOSelectLevel.MFO:
                    sb.AppendFormat("SELECT MAT_ID, MAT_VER, FLOW, OPER FROM MBASCHKLSR ");
                    sb.AppendFormat("WHERE FACTORY = '{0}' ", MPGV.gsFactory);
                    sb.AppendFormat("AND REL_LEVEL = '{0}' ", udcMFO.SelectLevelChar);
                    sb.Append("GROUP BY MAT_ID, MAT_VER, FLOW, OPER ");
                    sb.Append("ORDER BY MAT_ID, MAT_VER, FLOW, OPER");
                    break;
                case MESCore.Controls.MFOSelectLevel.F:
                    sb.AppendFormat("SELECT FLOW FROM MBASCHKLSR ");
                    sb.AppendFormat("WHERE FACTORY = '{0}' ", MPGV.gsFactory);
                    sb.AppendFormat("AND REL_LEVEL = '{0}' ", udcMFO.SelectLevelChar);
                    sb.Append("GROUP BY FLOW ");
                    sb.Append("ORDER BY FLOW");
                    break;
                case MESCore.Controls.MFOSelectLevel.FO:
                    sb.AppendFormat("SELECT FLOW, OPER FROM MBASCHKLSR ");
                    sb.AppendFormat("WHERE FACTORY = '{0}' ", MPGV.gsFactory);
                    sb.AppendFormat("AND REL_LEVEL = '{0}' ", udcMFO.SelectLevelChar);
                    sb.Append("GROUP BY FLOW, OPER ");
                    sb.Append("ORDER BY FLOW, OPER");
                    break;
                case MESCore.Controls.MFOSelectLevel.O:
                    sb.AppendFormat("SELECT OPER FROM MBASCHKLSR ");
                    sb.AppendFormat("WHERE FACTORY = '{0}' ", MPGV.gsFactory);
                    sb.AppendFormat("AND REL_LEVEL = '{0}' ", udcMFO.SelectLevelChar);
                    sb.Append("GROUP BY OPER ");
                    sb.Append("ORDER BY OPER");
                    break;
                case MESCore.Controls.MFOSelectLevel.Factory:
                    sb.AppendFormat("SELECT FACTORY FROM MBASCHKLSR ");
                    sb.AppendFormat("WHERE FACTORY = '{0}' ", MPGV.gsFactory);
                    sb.AppendFormat("AND REL_LEVEL = '{0}' ", udcMFO.SelectLevelChar);
                    sb.Append("GROUP BY FACTORY ");
                    sb.Append("ORDER BY FACTORY");
                    break;

                default:
                    return false;
            }

            in_node.AddString("SQL", sb.ToString());

            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(udcMFO.GetListView, out_node, false, (int)SMALLICON_INDEX.IDX_MESSAGE, false);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (in_node.GetInt("NEXT_ROW") > 0);

            lblDataCount.Text = MPCF.Trim(udcMFO.GetListView.Items.Count);

            return true;
        }

        private void CheckModify()
        {
            if (CHKLIST.GetString("CHKLIST_ID") == MPCF.Trim(cdvChecklistID.Text))
            {
                if (tabRelation.SelectedTab == tbpMFO)
                {
                    if (CHKLIST.GetString("LOT_ID") != MPCF.Trim(txtLotID.Text) ||
                        CHKLIST.GetString("TRAN_CODE") != MPCF.Trim(cboTransaction.Text) ||
                        (CHKLIST.GetChar("BA_POINT") == 'B' && rdoTranBefore.Checked == false) ||
                        (CHKLIST.GetChar("BA_POINT") == 'A' && rdoTranAfter.Checked == false))
                    {
                        btnCreate.Enabled = true;
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;
                        return;
                    }
                }
                else if (tabRelation.SelectedTab == tbpResource)
                {
                    if (CHKLIST.GetString("EVENT_ID") != MPCF.Trim(cdvEvent.Text) ||
                        (CHKLIST.GetChar("BA_POINT") == 'B' && rdoEventBefore.Checked == false) ||
                        (CHKLIST.GetChar("BA_POINT") == 'A' && rdoEventAfter.Checked == false))
                    {
                        btnCreate.Enabled = true;
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;
                        return;
                    }
                }
                btnCreate.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void InitData()
        {
            ChangeTabPage();
            cdvChecklistKeyPrompt.LockColumn_Prompt = true;
            cdvChecklistKeyPrompt.LockColumn_Format = true;
            cdvChecklistKeyPrompt.LockColumn_TableItem = true;

            cboTransaction.Items.AddRange(
                new string[]
                {
                    MPGC.MP_TRAN_CODE_CREATE,
                    MPGC.MP_TRAN_CODE_START,
                    MPGC.MP_TRAN_CODE_END,
                    MPGC.MP_TRAN_CODE_MOVE,
                    MPGC.MP_TRAN_CODE_REWORK,
                    MPGC.MP_TRAN_CODE_SPLIT,
                    MPGC.MP_TRAN_CODE_MERGE,
                    MPGC.MP_TRAN_CODE_COMBINE,
                    MPGC.MP_TRAN_CODE_HOLD,
                    MPGC.MP_TRAN_CODE_RELEASE,
                    MPGC.MP_TRAN_CODE_SHIP,
                    MPGC.MP_TRAN_CODE_RECEIVE,
                    MPGC.MP_TRAN_CODE_LOSS,
                    MPGC.MP_TRAN_CODE_BONUS,
                    MPGC.MP_TRAN_CODE_SKIP
                });
        }
        /* Added By YJJung 161024 Validation 누락 */
        private bool CheckCondition(char c_step)
        {
            try
            {
                if (c_step == MPGC.MP_STEP_CREATE)
                {
                    if (MPCF.Trim(cdvChecklistID.Text) == "") return false;
                }
                else if (c_step == MPGC.MP_STEP_DELETE)
                {
                    if (lisEventChecklist.Items.Count == 0 || lisEventChecklist.SelectedItems.Count == 0)
                        return false;
                }

                if (udcMFO.SelectedItem != Miracom.MESCore.Controls.TreeSelectedItem.Oper && udcMFO.SelectedItem != Miracom.MESCore.Controls.TreeSelectedItem.Factory)
                {
                    tabRelation.SelectedTab = tbpMFO;
                    MPCF.ShowMsgBox(MPCF.GetMessage(184));
                    udcMFO.Focus();
                    return false;
                }
                
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        /* Added End */
        #endregion

        private void frmBASSetupChecklistRelation_Activated(object sender, EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    ClearField('2');
                    InitData();
                }

                b_load_flag = true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (this.tabRelation.SelectedTab == this.tbpMFO)
                {
                    udcMFO.GetNext(txtFind.Text);
                }
                else if (this.tabRelation.SelectedTab == this.tbpResource)
                {
                    udcResourceTreeList.GetNext(txtFind.Text);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == 13 && MPCF.Trim(txtFind.Text) != "")
                {
                    btnNext_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            int selected_index = 0;

            try
            {
                //MPCF.FieldClear(this);
                MPCF.ClearList(lisTranChecklist);

                if (this.tabRelation.SelectedTab == this.tbpMFO)
                {
                    if (udcMFO.OnlySetDataList)
                    {
                        if (udcMFO.GetListView.SelectedIndices != null && udcMFO.GetListView.SelectedIndices.Count > 0)
                        {
                            selected_index = udcMFO.GetListView.SelectedIndices[0];
                        }

                        udcMFO.RefreshSelectedList();
                        lblDataCount.Text = MPCF.Trim(udcMFO.GetListView.Items.Count);

                        if (udcMFO.GetListView.Items.Count > 0)
                            udcMFO.GetListView.Items[selected_index].Selected = true;
                    }
                    else
                    {
                        Miracom.MESCore.Controls.TreeSelectedItem prev_item = udcMFO.SelectedItem;
                        udcMFO.RefreshSelectedList();
                        udcMFO.SelectedItem = prev_item;
                    }
                }
                else if (this.tabRelation.SelectedTab == this.tbpResource)
                {
                    
                    if (udcResourceTreeList.OnlySetDataList)
                    {
                        if (udcResourceTreeList.GetListView.SelectedIndices != null && udcResourceTreeList.GetListView.SelectedIndices.Count > 0)
                        {
                            selected_index = udcResourceTreeList.GetListView.SelectedIndices[0];
                        }

                        udcResourceTreeList.RefreshSelectedList();
                        lblDataCount.Text = MPCF.Trim(udcResourceTreeList.GetListView.Items.Count);

                        if (udcResourceTreeList.GetListView.Items.Count > 0)
                            udcResourceTreeList.GetListView.Items[selected_index].Selected = true;
                    }
                    else
                    {
                        Miracom.MESCore.Controls.TreeSelectedItem prev_item = udcResourceTreeList.SelectedItem;
                        udcResourceTreeList.RefreshSelectedList();
                        udcResourceTreeList.SelectedItem = prev_item;
                    }

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tabRelation.SelectedTab == this.tbpMFO && udcMFO.OnlySetDataList == true)
                {
                    MPCF.ExportToExcel(udcMFO.GetListView, this.Text, "");
                }
                else if (this.tabRelation.SelectedTab == this.tbpResource && udcResourceTreeList.OnlySetDataList == true)
                {
                    MPCF.ExportToExcel(udcResourceTreeList.GetListView, this.Text, "");
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void chkFromTime_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkFromTime.Checked == true)
                {
                    dtpFromDate.Value = DateTime.Today;
                    dtpFromTime.Value = DateTime.Now;
                    dtpFromDate.Enabled = true;
                    dtpFromTime.Enabled = true;
                }
                else
                {
                    dtpFromDate.Enabled = false;
                    dtpFromTime.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void chkToTime_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkToTime.Checked == true)
                {
                    dtpToDate.Value = DateTime.Today;
                    dtpToTime.Value = DateTime.Now;
                    dtpToDate.Enabled = true;
                    dtpToTime.Enabled = true;
                }
                else
                {
                    dtpToDate.Enabled = false;
                    dtpToTime.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void chkRequire_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkRequire.Checked == true)
                {
                    cdvCompleteUser.Enabled = true;
                }
                else
                {
                    cdvCompleteUser.ResetText();
                    cdvCompleteUser.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvChecklistID_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvChecklistID.Init();
                MPCF.InitListView(cdvChecklistID.GetListView);
                cdvChecklistID.Columns.Add("Checklist ID", 150, HorizontalAlignment.Left);
                cdvChecklistID.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvChecklistID.SelectedSubItemIndex = 0;
                BASLIST.ViewChecklistList(cdvChecklistID.GetListView, '1', "");
                cdvChecklistID.InsertEmptyRow(0, 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvEvent_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvEvent.Init();
                MPCF.InitListView(cdvEvent.GetListView);
                cdvEvent.Columns.Add("Tran Code", 150, HorizontalAlignment.Left);
                cdvEvent.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvEvent.SelectedSubItemIndex = 0;
                RASLIST.ViewEventList(cdvEvent.GetListView, '1', "", null, "");
                cdvEvent.InsertEmptyRow(0, 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvEvent_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cdvEvent.Text.ToString().Trim()) != true)
                {
                    rdoEventAfter.Enabled = true;
                    rdoEventBefore.Enabled = true;
                }
                else
                {
                    rdoEventAfter.Enabled = false;
                    rdoEventAfter.Checked = false;
                    rdoEventBefore.Enabled = false;
                    rdoEventBefore.Checked = false;
                }
                CheckModify();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvCompleteUser_ButtonPress(object sender, EventArgs e)
        {
            cdvEvent.Init();
            MPCF.InitListView(cdvCompleteUser.GetListView);
            cdvCompleteUser.Columns.Add("User ID", 150, HorizontalAlignment.Left);
            cdvCompleteUser.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvCompleteUser.SelectedSubItemIndex = 0;
            SECLIST.ViewSECUserList(cdvCompleteUser.GetListView, '1', -1, null, "", "");
            cdvCompleteUser.InsertEmptyRow(0, 1);
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.Compare(MPCF.ToDate(dtpFromDate).ToString(), MPCF.ToDate(dtpToDate).ToString()) > 0)
                {
                    dtpToDate.Value = dtpFromDate.Value;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.Compare(MPCF.ToDate(dtpFromDate).ToString(), MPCF.ToDate(dtpToDate).ToString()) > 0)
                {
                    dtpFromDate.Value = dtpToDate.Value;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void rdoTranAfter_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoTranAfter.Checked == true)
                {
                    rdoTranBefore.Checked = false;
                }
                CheckModify();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void rdoTranBefore_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoTranBefore.Checked == true)
                {
                    rdoTranAfter.Checked = false;
                }
                CheckModify();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void rdoEventAfter_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoEventAfter.Checked == true)
                {
                    rdoEventBefore.Checked = false;
                }
                CheckModify();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void rdoEventBefore_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoEventBefore.Checked == true)
                {
                    rdoEventAfter.Checked = false;
                }
                CheckModify();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void tabRelation_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                ChangeTabPage();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
                if (UpdateChecklistRelation(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }

                btnRefresh.PerformClick();

                //if (tabRelation.SelectedTab == tbpMFO && udcMFO.SelectedItem != null)
                //{
                //    udcMFO_LevelItemSelect(null, null);
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                if (UpdateChecklistRelation(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }

                btnRefresh.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                if (UpdateChecklistRelation(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }

                btnRefresh.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void lisTranChecklist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lisTranChecklist.SelectedIndices.Count > 0)
                {
                    ClearField('1');

                    if (ViewChecklistRelation() == false)
                    {
                        return;
                    }

                    btnCreate.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void lisEventChecklist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lisEventChecklist.SelectedIndices.Count > 0)
                {

                    ClearField('1');

                    if (ViewChecklistRelation() == false)
                    {
                        return;
                    }

                    btnCreate.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void txtLotID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLotID.Text.ToString().Trim()) == false)
                {
                    chkInheritChild.Enabled = true;
                }
                else
                {
                    chkInheritChild.Enabled = false;
                    chkInheritChild.Checked = false;
                }

                CheckModify();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvChecklistID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                if (MPCF.Trim(cdvChecklistID.Text) == "") return;

                TRSNode in_node = new TRSNode("VIEW_CHECKLIST_IN");
                TRSNode out_node = new TRSNode("VIEW_CHECKLIST_OUT");
                string sNaming = string.Empty;

                ClearField('1');

                btnCreate.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.SetString("CHKLIST_ID", MPCF.Trim(cdvChecklistID.Text));

                if (MPCR.CallService("BAS", "BAS_View_Checklist", in_node, ref out_node) == false)
                {
                    return;
                }

                txtDesc.Text = out_node.GetString("CHKLIST_DESC").ToString().Trim();

                cdvChecklistKeyPrompt.DisplayKeyPromptSetup(ref out_node);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvTableList_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
        }

        private void udcMFO_LevelItemSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                ClearField('2');
                ViewChecklistRelationList_MFO(lisTranChecklist, udcMFO.SelectLevelChar, udcMFO.MatID, udcMFO.MatVersion, udcMFO.Flow, udcMFO.Oper);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void udcMFO_SetDataSelectedIndexChanged(object sender, EventArgs e)
        {
            ClearField('2');
            ViewChecklistRelationList_MFO(lisTranChecklist, udcMFO.SelectLevelChar, udcMFO.MatID, udcMFO.MatVersion, udcMFO.Flow, udcMFO.Oper);
        }

        private void udcResourceTreeList_SetDataSelectedIndexChanged(object sender, EventArgs e)
        {
            ClearField('2');
            ViewChecklistRelationList_RAS(lisEventChecklist, udcResourceTreeList.SelectLevelCharEx, udcResourceTreeList.ResourceType, udcResourceTreeList.ResourceGroup, udcResourceTreeList.Resource);
            //if (udcResourceTreeList.OnlySetDataList)
            //{
            //    ClearField('2');
            //    ViewChecklistRelationList_RAS(lisEventChecklist, udcResourceTreeList.SelectLevelCharEx, udcResourceTreeList.ResourceType, udcResourceTreeList.ResourceGroup, udcResourceTreeList.Resource);
            //}
            //else
            //{
            //    udcResourceTreeList.Init();
            //}
        }

        private void udcResourceTreeList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                ClearField('2');
                ViewChecklistRelationList_RAS(lisEventChecklist, udcResourceTreeList.SelectLevelCharEx, udcResourceTreeList.ResourceType, udcResourceTreeList.ResourceGroup, udcResourceTreeList.Resource);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void udcResourceTreeList_GetOnlySetData(object sender, EventArgs e)
        {
            ClearField('2');
            if (udcResourceTreeList.OnlySetDataList)
            {
                ViewResourceSettingDataList();
                lblDataCount.Text = MPCF.Trim(udcResourceTreeList.GetListView.Items.Count);
            }
            else
            {
                udcResourceTreeList.Init();
            }
        }

        private void udcMFO_GetOnlySetData(object sender, EventArgs e)
        {
            ClearField('2');
            if (udcMFO.OnlySetDataList)
            {
                ViewMFOSettingDataList();
                lblDataCount.Text = MPCF.Trim(udcMFO.GetListView.Items.Count);
            }
            else
            {
                udcMFO.Init();
            }
        }

        private void cboTransaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cboTransaction.Text) != true)
                {
                    rdoTranAfter.Enabled = true;
                    rdoTranBefore.Enabled = true;
                }
                else
                {
                    rdoTranAfter.Enabled = false;
                    rdoTranAfter.Checked = false;
                    rdoTranBefore.Enabled = false;
                    rdoTranBefore.Checked = false;
                }

                CheckModify();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void udcMFO_AfterGetTree(object sender, EventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(udcMFO.GetTreeView.GetNodeCount(false));
        }

        private void udcResourceTreeList_AfterGetTree(object sender, EventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(udcResourceTreeList.GetTreeView.GetNodeCount(false));
        }
    }
}
