using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.TRSCore;
using Miracom.MESCore;

namespace Miracom.WIPCore.Setup
{
    public partial class udcFutureActionRework : Miracom.WIPCore.Setup.udcFutureActionBase
    {
        public udcFutureActionRework()
        {
            InitializeComponent();
            cboActionType.SelectedIndex = 0;
        }

        private string s_rework_table;

        #region "Functions"

        public override void setMFO(string s_mat_id, int i_mat_ver, string s_flow, string s_oper)
        {
            initControl();
            cboActionType.SelectedIndex = 0;

            base.setMFO(s_mat_id, i_mat_ver, s_flow, s_oper);

            ViewOperation();
            GetReworkCodeList();
        }

        public override void setAction(TRSNode node)
        {
            if (node == null) return;

            cdvRwkCode.Text = node.GetString("DATA_1");
            cdvRwkFlow.Text = node.GetString("DATA_2");
            cdvRwkFlow.Sequence = MPCF.ToInt(node.GetString("DATA_3"));
            cdvRwkOper.Text = node.GetString("DATA_4");
            cdvRetFlow.Text = node.GetString("DATA_5");
            cdvRetFlow.Sequence = MPCF.ToInt(node.GetString("DATA_6"));
            cdvRetOper.Text = node.GetString("DATA_7");

            switch (node.GetString("DATA_8"))
            {
                case "Y": // Clear Rework
                    cboRetOption.SelectedIndex = 1;
                    break;
                case "A": // Clear Rework and Move to Next Oper
                    cboRetOption.SelectedIndex = 2;
                    break;
                case "B": // Keep Rework and Move to Next Oper
                    cboRetOption.SelectedIndex = 3;
                    break;
                default: // keep Rework
                    cboRetOption.SelectedIndex = 0;
                    break;
            }
            cdvRwkStopOper.Text = node.GetString("DATA_9");

            if (node.GetChar("ACTION_TYPE") == '1')
            {
                cboActionType.SelectedIndex = 0;
            }
            else if (node.GetChar("ACTION_TYPE") == '2')
            {
                cboActionType.SelectedIndex = 1;

                cdvRwkCodeFalse.Text = node.GetString("DATA_11");
                cdvRwkFlowFalse.Text = node.GetString("DATA_12");
                cdvRwkFlowFalse.Sequence = MPCF.ToInt(node.GetString("DATA_13"));
                cdvRwkOperFalse.Text = node.GetString("DATA_14");
                cdvRetFlowFalse.Text = node.GetString("DATA_15");
                cdvRetFlowFalse.Sequence = MPCF.ToInt(node.GetString("DATA_16"));
                cdvRetOperFalse.Text = node.GetString("DATA_17");
                switch (node.GetString("DATA_18"))
                {
                    case "Y": // Clear Rework
                        cboRetOptionFalse.SelectedIndex = 1;
                        break;
                    case "A": // Clear Rework and Move to Next Oper
                        cboRetOptionFalse.SelectedIndex = 2;
                        break;
                    case "B": // Keep Rework and Move to Next Oper
                        cboRetOptionFalse.SelectedIndex = 3;
                        break;
                    default: // keep Rework
                        cboRetOptionFalse.SelectedIndex = 0;
                        break;
                }
                cdvRwkStopOperFalse.Text = node.GetString("DATA_19");
            }
        }

        public override bool checkCondition()
        {
            if (MPCF.CheckValue(cdvRwkCode, 1) == false) return false;

            if (cboActionType.SelectedIndex == 1)
            {
                if (MPCF.CheckValue(cdvRwkCodeFalse, 1) == false) return false;
            }

            return true;
        }
        
        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", MPGC.MP_TRAN_CODE_REWORK);

            if (cboActionType.SelectedIndex == 0)
                node.AddChar("ACTION_TYPE", '1');
            else if (cboActionType.SelectedIndex == 1)
                node.AddChar("ACTION_TYPE", '2');

            node.AddString("DATA_1", cdvRwkCode.Text);
            node.AddString("DATA_2", cdvRwkFlow.Text);
            node.AddString("DATA_3", cdvRwkFlow.Sequence.ToString());
            node.AddString("DATA_4", cdvRwkOper.Text);
            node.AddString("DATA_5", cdvRetFlow.Text);
            node.AddString("DATA_6", cdvRetFlow.Sequence.ToString());
            node.AddString("DATA_7", cdvRetOper.Text);
            switch (cboRetOption.SelectedIndex)
            {
                case 0: // Keep Rework
                    node.AddString("DATA_8", " ");
                    break;
                case 1: // Clear Rework
                    node.AddString("DATA_8", "Y");
                    break;
                case 2: // Clear Rework and Move to Next Oper
                    node.AddString("DATA_8", "A");
                    break;
                case 3: // Keep Rework and Move to Next Oper
                    node.AddString("DATA_8", "B");
                    break;
            }
            node.AddString("DATA_9", cdvRwkStopOper.Text);

            node.AddString("DATA_11", cdvRwkCodeFalse.Text);
            node.AddString("DATA_12", cdvRwkFlowFalse.Text);
            node.AddString("DATA_13", cdvRwkFlowFalse.Sequence.ToString());
            node.AddString("DATA_14", cdvRwkOperFalse.Text);
            node.AddString("DATA_15", cdvRetFlowFalse.Text);
            node.AddString("DATA_16", cdvRetFlowFalse.Sequence.ToString());
            node.AddString("DATA_17", cdvRetOperFalse.Text);
            switch (cboRetOptionFalse.SelectedIndex)
            {
                case 0: // Keep Rework
                    node.AddString("DATA_18", " ");
                    break;
                case 1: // Clear Rework
                    node.AddString("DATA_18", "Y");
                    break;
                case 2: // Clear Rework and Move to Next Oper
                    node.AddString("DATA_18", "A");
                    break;
                case 3: // Keep Rework and Move to Next Oper
                    node.AddString("DATA_18", "B");
                    break;
            }
            node.AddString("DATA_19", cdvRwkStopOperFalse.Text);
        }

        private bool ViewOperation()
        {

            TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");
            TRSNode out_node = new TRSNode("VIEW_OPERATION_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", m_s_oper);

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return false;
            }

            s_rework_table = out_node.GetString("REWORK_TBL");

            return true;

        }

        private bool GetReworkCodeList()
        {
            try
            {
                cdvRwkCode.Init();
                MPCF.InitListView(cdvRwkCode.GetListView);
                cdvRwkCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
                cdvRwkCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvRwkCode.SelectedSubItemIndex = 0;

                cdvRwkCodeFalse.Init();
                MPCF.InitListView(cdvRwkCodeFalse.GetListView);
                cdvRwkCodeFalse.Columns.Add("Code", 50, HorizontalAlignment.Left);
                cdvRwkCodeFalse.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvRwkCodeFalse.SelectedSubItemIndex = 0;

                if (s_rework_table == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(195));
                    return false;
                }

                if (BASLIST.ViewGCMDataList(cdvRwkCode.GetListView, '1', s_rework_table) == false)
                {
                    return false;
                }
                if (BASLIST.ViewGCMDataList(cdvRwkCodeFalse.GetListView, '1', s_rework_table) == false)
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

        private bool ViewReworkFlowOperByCode(bool b_positive_case, string sMaterial, int iMatVer, string sFlow, string sOper, string sCode)
        {

            TRSNode in_node = new TRSNode("VIEW_REWORK_FLOW_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_REWORK_FLOW_LIST_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '4';

            in_node.AddString("MAT_ID", MPCF.Trim(sMaterial));
            in_node.AddInt("MAT_VER", iMatVer);
            in_node.AddString("FLOW", MPCF.Trim(sFlow));
            in_node.AddString("OPER", MPCF.Trim(sOper));
            in_node.AddString("RWK_CODE", MPCF.Trim(sCode));

            if (MPCR.CallService("WIP", "WIP_View_Rework_Flow_List", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetList(0).Count > 0)
            {
                if (b_positive_case == true)
                {
                    cdvRwkFlow.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RWK_FLOW"));
                    cdvRwkFlow.Sequence = out_node.GetList(0)[0].GetInt("RWK_FLOW_SEQ_NUM");
                    cdvRwkOper.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RWK_OPER"));
                    cdvRwkStopOper.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RWK_STOP_OPER"));

                    cdvRetFlow.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RET_FLOW"));
                    cdvRetFlow.Sequence = out_node.GetList(0)[0].GetInt("RET_FLOW_SEQ_NUM");
                    cdvRetOper.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RET_OPER"));

                    switch (out_node.GetList(0)[0].GetChar("RET_CLEAR_FLAG"))
                    {
                        case 'Y': // Clear Rework
                            cboRetOption.SelectedIndex = 1;
                            break;
                        case 'A': // Clear Rework and Move to Next Oper
                            cboRetOption.SelectedIndex = 2;
                            break;
                        case 'B': // Keep Rework and Move to Next Oper
                            cboRetOption.SelectedIndex = 3;
                            break;
                        default: // keep Rework
                            cboRetOption.SelectedIndex = 0;
                            break;
                    }
                }
                else
                {
                    cdvRwkFlowFalse.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RWK_FLOW"));
                    cdvRwkFlowFalse.Sequence = out_node.GetList(0)[0].GetInt("RWK_FLOW_SEQ_NUM");
                    cdvRwkOperFalse.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RWK_OPER"));
                    cdvRwkStopOperFalse.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RWK_STOP_OPER"));

                    cdvRetFlowFalse.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RET_FLOW"));
                    cdvRetFlowFalse.Sequence = out_node.GetList(0)[0].GetInt("RET_FLOW_SEQ_NUM");
                    cdvRetOperFalse.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RET_OPER"));

                    switch (out_node.GetList(0)[0].GetChar("RET_CLEAR_FLAG"))
                    {
                        case 'Y': // Clear Rework
                            cboRetOptionFalse.SelectedIndex = 1;
                            break;
                        case 'A': // Clear Rework and Move to Next Oper
                            cboRetOptionFalse.SelectedIndex = 2;
                            break;
                        case 'B': // Keep Rework and Move to Next Oper
                            cboRetOptionFalse.SelectedIndex = 3;
                            break;
                        default: // keep Rework
                            cboRetOptionFalse.SelectedIndex = 0;
                            break;
                    }
                }
            }

            return true;
        }

        private bool ViewReworkFlowList(bool b_positive_case, string s_rwk_code)
        {
            ListViewItem itmX;
            int i;
            int i_flow_seq;

            TRSNode in_node = new TRSNode("VIEW_REWORK_FLOW_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_REWORK_FLOW_LIST_OUT");

            if (b_positive_case == true)
            {
                MPCF.ClearList(cdvRwkFlow.FlowGetListView, false);
            }
            else
            {
                MPCF.ClearList(cdvRwkFlowFalse.FlowGetListView, false);
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '2';

            in_node.AddChar("OPT_LEVEL", '1');
            in_node.AddString("MAT_ID", m_s_mat_id);
            in_node.AddInt("MAT_VER", m_i_mat_ver);
            in_node.AddString("FLOW", m_s_flow);
            in_node.AddString("OPER", m_s_oper);
            in_node.AddString("RWK_CODE", s_rwk_code);

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Rework_Flow_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmX = new ListViewItem(out_node.GetList(0)[i].GetString("RWK_FLOW"), (int)SMALLICON_INDEX.IDX_FLOW);

                    if (out_node.GetList(0)[i].GetString("RWK_FLOW") == "")
                    {
                        itmX.SubItems.Add("");
                    }
                    else
                    {
                        i_flow_seq = out_node.GetList(0)[i].GetInt("RWK_FLOW_SEQ_NUM");
                        if (i_flow_seq < 1)
                        {
                            itmX.SubItems.Add("");
                        }
                        else
                        {
                            itmX.SubItems.Add(i_flow_seq.ToString());
                        }
                    }

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_FLOW_DESC"));

                    if (b_positive_case == true)
                    {
                        cdvRwkFlow.FlowItems.Add(itmX);
                    }
                    else
                    {
                        cdvRwkFlowFalse.FlowItems.Add(itmX);
                    }
                }

                in_node.SetString("NEXT_FLOW", out_node.GetString("NEXT_FLOW"));

            } while (in_node.GetString("NEXT_FLOW") != "");

            return true;
        }

        private bool ViewReworkOperList(bool b_positive_case, string s_rwk_code, string s_rwk_flow, int i_rwk_flow_seq)
        {

            ListViewItem itmX;
            int i;

            TRSNode in_node = new TRSNode("VIEW_REWORK_OPER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_REWORK_OPER_LIST_OUT");

            if (b_positive_case == true)
            {
                cdvRwkOper.Items.Clear();
                cdvRwkStopOper.Items.Clear();
            }
            else
            {
                cdvRwkOperFalse.Items.Clear();
                cdvRwkStopOperFalse.Items.Clear();
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '2';

            in_node.AddChar("OPT_LEVEL", '1');
            in_node.AddString("MAT_ID", m_s_mat_id);
            in_node.AddInt("MAT_VER", m_i_mat_ver);
            in_node.AddString("FLOW", m_s_flow);
            in_node.AddString("OPER", m_s_oper);
            in_node.AddString("RWK_CODE", s_rwk_code);
            in_node.AddString("RWK_FLOW", s_rwk_flow);
            in_node.AddInt("RWK_FLOW_SEQ_NUM", i_rwk_flow_seq);

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Rework_Oper_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmX = new ListViewItem(out_node.GetList(0)[i].GetString("RWK_OPER"), (int)SMALLICON_INDEX.IDX_OPER);
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_OPER_DESC"));

                    if (b_positive_case == true)
                    {
                        cdvRwkOper.Items.Add(itmX);
                    }
                    else
                    {
                        cdvRwkOperFalse.Items.Add(itmX);
                    }
                }

                in_node.SetString("NEXT_OPER", out_node.GetString("NEXT_OPER"));

            } while (in_node.GetString("NEXT_OPER") != "");

            if (b_positive_case == true)
            {
                for (i = 0; i < cdvRwkOper.Items.Count; i++)
                {
                    itmX = new ListViewItem(cdvRwkOper.Items[i].SubItems[0].Text, (int)SMALLICON_INDEX.IDX_OPER);
                    itmX.SubItems.Add(cdvRwkOper.Items[i].SubItems[1].Text);
                    cdvRwkStopOper.Items.Add(itmX);
                }
            }
            else
            {
                for (i = 0; i < cdvRwkOperFalse.Items.Count; i++)
                {
                    itmX = new ListViewItem(cdvRwkOperFalse.Items[i].SubItems[0].Text, (int)SMALLICON_INDEX.IDX_OPER);
                    itmX.SubItems.Add(cdvRwkOperFalse.Items[i].SubItems[1].Text);
                    cdvRwkStopOperFalse.Items.Add(itmX);
                }
            }

            return true;
        }

        private bool ViewReturnFlowOper(bool b_positive_case, string s_rwk_code, string s_rwk_flow, int i_rwk_flow_seq, string s_rwk_oper)
        {

            TRSNode in_node = new TRSNode("VIEW_REWORK_FLOW_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_REWORK_FLOW_LIST_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '3';

            in_node.AddChar("OPT_LEVEL", '1');
            in_node.AddString("MAT_ID", m_s_mat_id);
            in_node.AddInt("MAT_VER", m_i_mat_ver);
            in_node.AddString("FLOW", m_s_flow);
            in_node.AddString("OPER", m_s_oper);
            in_node.AddString("RWK_CODE", s_rwk_code);
            in_node.AddString("RWK_FLOW", s_rwk_flow);
            in_node.AddInt("RWK_FLOW_SEQ_NUM", i_rwk_flow_seq);
            in_node.AddString("RWK_OPER", s_rwk_oper);

            if (MPCR.CallService("WIP", "WIP_View_Rework_Flow_List", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetList(0).Count > 0)
            {
                if (b_positive_case == true)
                {
                    cdvRetFlow.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RET_FLOW"));
                    cdvRetFlow.Sequence = out_node.GetList(0)[0].GetInt("RET_FLOW_SEQ_NUM");
                    cdvRetOper.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RET_OPER"));
                }
                else
                {
                    cdvRetFlowFalse.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RET_FLOW"));
                    cdvRetFlowFalse.Sequence = out_node.GetList(0)[0].GetInt("RET_FLOW_SEQ_NUM");
                    cdvRetOperFalse.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RET_OPER"));
                }
            }

            return true;
        }

#endregion

        private void cboActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboActionType.SelectedIndex == 0)
            {
                grpActionFalse.Visible = false;
                MPCF.FieldClear(grpActionFalse);

                grpActionTrue.Text = "";
            }
            else
            {
                grpActionFalse.Visible = true;
                grpActionTrue.Text = MPCF.FindLanguage("True Action", CAPTION_TYPE.LABEL);
            }
        }

        private void cboActionType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cdvRwkCode_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvRwkFlow.Text = "";
            cdvRwkOper.Text = "";
            cdvRwkStopOper.Text = "";
            cdvRetFlow.Text = "";
            cdvRetOper.Text = "";

            if (ViewReworkFlowOperByCode(true, m_s_mat_id, m_i_mat_ver, m_s_flow, m_s_oper, MPCF.Trim(cdvRwkCode.Text)) == false)
            {
                return;
            }
        }

        private void cdvRwkCodeFalse_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvRwkFlowFalse.Text = "";
            cdvRwkOperFalse.Text = "";
            cdvRwkStopOperFalse.Text = "";
            cdvRetFlowFalse.Text = "";
            cdvRetOperFalse.Text = "";

            if (ViewReworkFlowOperByCode(false, m_s_mat_id, m_i_mat_ver, m_s_flow, m_s_oper, MPCF.Trim(cdvRwkCodeFalse.Text)) == false)
            {
                return;
            }
        }

        private void cdvRwkFlow_FlowButtonPress(object sender, EventArgs e)
        {
            cdvRwkFlow.RefuseEventExec = true;
            cdvRwkFlow.FlowIsPopup = false;

            if (MPCF.CheckValue(cdvRwkCode, 1) == false) return;

            cdvRwkFlow.FlowIsPopup = true;

            if (ViewReworkFlowList(true, MPCF.Trim(cdvRwkCode.Text)) == false)
            {
                return;
            }
        }

        private void cdvRwkFlowFalse_FlowButtonPress(object sender, EventArgs e)
        {
            cdvRwkFlowFalse.RefuseEventExec = true;
            cdvRwkFlowFalse.FlowIsPopup = false;

            if (MPCF.CheckValue(cdvRwkCodeFalse, 1) == false) return;

            cdvRwkFlowFalse.FlowIsPopup = true;

            if (ViewReworkFlowList(false, MPCF.Trim(cdvRwkCodeFalse.Text)) == false)
            {
                return;
            }
        }

        private void cdvRwkFlow_FlowSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvRwkOper.Text = "";
            cdvRwkStopOper.Text = "";
            cdvRetFlow.Text = "";
            cdvRetOper.Text = "";
        }

        private void cdvRwkFlowFalse_FlowSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvRwkOperFalse.Text = "";
            cdvRwkStopOperFalse.Text = "";
            cdvRetFlowFalse.Text = "";
            cdvRetOperFalse.Text = "";
        }

        private void cdvRwkFlow_SeqButtonPress(object sender, EventArgs e)
        {
            cdvRwkFlow.ListCond_MatID = m_s_mat_id;
            cdvRwkFlow.ListCond_MatVersion = m_i_mat_ver;
        }

        private void cdvRwkFlowFalse_SeqButtonPress(object sender, EventArgs e)
        {
            cdvRwkFlowFalse.ListCond_MatID = m_s_mat_id;
            cdvRwkFlowFalse.ListCond_MatVersion = m_i_mat_ver;
        }

        private void cdvRwkOper_ButtonPress(object sender, EventArgs e)
        {
            cdvRwkOper.RefuseEventExec = true;
            cdvRwkOper.IsPopup = false;
            cdvRwkOper.Items.Clear();

            cdvRwkStopOper.RefuseEventExec = true;
            cdvRwkStopOper.IsPopup = false;
            cdvRwkStopOper.Items.Clear();

            if (MPCF.Trim(cdvRwkFlow.Text) != "")
            {
                if (ViewReworkOperList(true, MPCF.Trim(cdvRwkCode.Text), MPCF.Trim(cdvRwkFlow.Text), cdvRwkFlow.Sequence) == false)
                {
                    return;
                }
            }

            if(cdvRwkOper.Items.Count < 1)
            {
                if(MPCF.Trim(cdvRwkFlow.Text) != "")
                {
                    cdvRwkOper.RefuseEventExec = false;
                    cdvRwkOper.ListCond_Step = '2';
                    cdvRwkOper.ListCond_Flow = cdvRwkFlow.Text;

                    cdvRwkStopOper.RefuseEventExec = false;
                    cdvRwkStopOper.ListCond_Step = '2';
                    cdvRwkStopOper.ListCond_Flow = cdvRwkFlow.Text;
                }
                else
                {
                    switch (base.getMFOSelectLevel())
                    {
                        case Miracom.MESCore.Controls.MFOSelectLevel.O:
                        case Miracom.MESCore.Controls.MFOSelectLevel.M:
                        case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                            cdvRwkOper.RefuseEventExec = false;
                            cdvRwkOper.ListCond_Step = '1';
                            cdvRwkOper.ListCond_Flow = "";

                            cdvRwkStopOper.RefuseEventExec = false;
                            cdvRwkStopOper.ListCond_Step = '1';
                            cdvRwkStopOper.ListCond_Flow = "";
                            break;

                        case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                        case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                        case Miracom.MESCore.Controls.MFOSelectLevel.F:
                        case Miracom.MESCore.Controls.MFOSelectLevel.MF:
                            cdvRwkOper.RefuseEventExec = false;
                            cdvRwkOper.ListCond_Step = '2';
                            cdvRwkOper.ListCond_Flow = m_s_flow;

                            cdvRwkStopOper.RefuseEventExec = false;
                            cdvRwkStopOper.ListCond_Step = '2';
                            cdvRwkStopOper.ListCond_Flow = m_s_flow;
                            break;

                        case Miracom.MESCore.Controls.MFOSelectLevel.NONE:
                            return;
                    }
                }
            }

            cdvRwkOper.IsPopup = true;
            cdvRwkStopOper.IsPopup = true;
        }

        private void cdvRwkOperFalse_ButtonPress(object sender, EventArgs e)
        {
            cdvRwkOperFalse.RefuseEventExec = true;
            cdvRwkOperFalse.IsPopup = false;
            cdvRwkOperFalse.Items.Clear();

            cdvRwkStopOperFalse.RefuseEventExec = true;
            cdvRwkStopOperFalse.IsPopup = false;
            cdvRwkStopOperFalse.Items.Clear();

            if (MPCF.Trim(cdvRwkFlowFalse.Text) != "")
            {
                if (ViewReworkOperList(false, MPCF.Trim(cdvRwkCodeFalse.Text), MPCF.Trim(cdvRwkFlowFalse.Text), cdvRwkFlowFalse.Sequence) == false)
                {
                    return;
                }
            }

            if (cdvRwkOperFalse.Items.Count < 1)
            {
                if (MPCF.Trim(cdvRwkFlowFalse.Text) != "")
                {
                    cdvRwkOperFalse.RefuseEventExec = false;
                    cdvRwkOperFalse.ListCond_Step = '2';
                    cdvRwkOperFalse.ListCond_Flow = cdvRwkFlowFalse.Text;

                    cdvRwkStopOperFalse.RefuseEventExec = false;
                    cdvRwkStopOperFalse.ListCond_Step = '2';
                    cdvRwkStopOperFalse.ListCond_Flow = cdvRwkFlowFalse.Text;
                }
                else
                {
                    switch (base.getMFOSelectLevel())
                    {
                        case Miracom.MESCore.Controls.MFOSelectLevel.O:
                        case Miracom.MESCore.Controls.MFOSelectLevel.M:
                        case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                            cdvRwkOperFalse.RefuseEventExec = false;
                            cdvRwkOperFalse.ListCond_Step = '1';
                            cdvRwkOperFalse.ListCond_Flow = "";

                            cdvRwkStopOperFalse.RefuseEventExec = false;
                            cdvRwkStopOperFalse.ListCond_Step = '1';
                            cdvRwkStopOperFalse.ListCond_Flow = "";
                            break;

                        case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                        case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                        case Miracom.MESCore.Controls.MFOSelectLevel.F:
                        case Miracom.MESCore.Controls.MFOSelectLevel.MF:
                            cdvRwkOperFalse.RefuseEventExec = false;
                            cdvRwkOperFalse.ListCond_Step = '2';
                            cdvRwkOperFalse.ListCond_Flow = m_s_flow;

                            cdvRwkStopOperFalse.RefuseEventExec = false;
                            cdvRwkStopOperFalse.ListCond_Step = '2';
                            cdvRwkStopOperFalse.ListCond_Flow = m_s_flow;
                            break;

                        case Miracom.MESCore.Controls.MFOSelectLevel.NONE:
                            return;
                    }
                }
            }

            cdvRwkOperFalse.IsPopup = true;
            cdvRwkStopOperFalse.IsPopup = true;
        }

        private void cdvRwkOper_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvRetFlow.Text = "";
            cdvRetOper.Text = "";

            if (ViewReturnFlowOper(true, MPCF.Trim(cdvRwkCode.Text), MPCF.Trim(cdvRwkFlow.Text), cdvRwkFlow.Sequence, MPCF.Trim(cdvRwkOper.Text)) == false)
            {
                return;
            }
        }

        private void cdvRwkOperFalse_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvRetFlowFalse.Text = "";
            cdvRetOperFalse.Text = "";

            if (ViewReturnFlowOper(false, MPCF.Trim(cdvRwkCodeFalse.Text), MPCF.Trim(cdvRwkFlowFalse.Text), cdvRwkFlowFalse.Sequence, MPCF.Trim(cdvRwkOperFalse.Text)) == false)
            {
                return;
            }
        }

        private void cdvRwkStopOper_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvRwkOper, 1) == false)
            {
                cdvRwkStopOper.RefuseEventExec = true;
                cdvRwkStopOper.IsPopup = false;
                return;
            }
        }

        private void cdvRwkStopOperFalse_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvRwkOperFalse, 1) == false)
            {
                cdvRwkStopOperFalse.RefuseEventExec = true;
                cdvRwkStopOperFalse.IsPopup = false;
                return;
            }
        }

        private void cdvRetFlow_FlowButtonPress(object sender, EventArgs e)
        {
            cdvRetFlow.ListCond_Step = '1';
            cdvRetFlow.ListCond_MatID = "";
            cdvRetFlow.ListCond_MatVersion = 0;
        }

        private void cdvRetFlowFalse_FlowButtonPress(object sender, EventArgs e)
        {
            cdvRetFlowFalse.ListCond_Step = '1';
            cdvRetFlowFalse.ListCond_MatID = "";
            cdvRetFlowFalse.ListCond_MatVersion = 0;
        }

        private void cdvRetFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            cdvRetOper.Text = "";
            if (MPCF.Trim(cdvRetFlow.Text) != "")
            {
                cdvRetFlow.ListCond_Step = '2';
            }

        }

        private void cdvRetFlowFalse_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            cdvRetOperFalse.Text = "";
            if (MPCF.Trim(cdvRetFlowFalse.Text) != "")
            {
                cdvRetFlowFalse.ListCond_Step = '2';
            }

        }

        private void cdvRetFlow_SeqButtonPress(object sender, EventArgs e)
        {
            cdvRetFlow.ListCond_MatID = m_s_mat_id;
            cdvRetFlow.ListCond_MatVersion = m_i_mat_ver;
        }

        private void cdvRetFlowFalse_SeqButtonPress(object sender, EventArgs e)
        {
            cdvRetFlowFalse.ListCond_MatID = m_s_mat_id;
            cdvRetFlowFalse.ListCond_MatVersion = m_i_mat_ver;
        }

        private void cdvRetOper_ButtonPress(object sender, EventArgs e)
        {
            cdvRetOper.RefuseEventExec = true;
            cdvRetOper.IsPopup = false;
            cdvRetOper.Items.Clear();

            if (MPCF.Trim(cdvRetFlow.Text) != "")
            {
                cdvRetOper.RefuseEventExec = false;
                cdvRetOper.ListCond_Step = '2';
                cdvRetOper.ListCond_Flow = cdvRetFlow.Text;
            }
            else
            {
                switch (base.getMFOSelectLevel())
                {
                    case Miracom.MESCore.Controls.MFOSelectLevel.O:
                    case Miracom.MESCore.Controls.MFOSelectLevel.M:
                    case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                        cdvRetOper.RefuseEventExec = false;
                        cdvRetOper.ListCond_Step = '1';
                        cdvRetOper.ListCond_Flow = "";
                        break;

                    case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                    case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                    case Miracom.MESCore.Controls.MFOSelectLevel.F:
                    case Miracom.MESCore.Controls.MFOSelectLevel.MF:
                        cdvRetOper.RefuseEventExec = false;
                        cdvRetOper.ListCond_Step = '2';
                        cdvRetOper.ListCond_Flow = m_s_flow;
                        break;

                    case Miracom.MESCore.Controls.MFOSelectLevel.NONE:
                        return;
                }
            }

            cdvRetOper.IsPopup = true; 
        }

        private void cdvRetOperFalse_ButtonPress(object sender, EventArgs e)
        {
            cdvRetOperFalse.RefuseEventExec = true;
            cdvRetOperFalse.IsPopup = false;
            cdvRetOperFalse.Items.Clear();

            if (MPCF.Trim(cdvRetFlowFalse.Text) != "")
            {
                cdvRetOperFalse.RefuseEventExec = false;
                cdvRetOperFalse.ListCond_Step = '2';
                cdvRetOperFalse.ListCond_Flow = cdvRetFlowFalse.Text;
            }
            else
            {
                switch (base.getMFOSelectLevel())
                {
                    case Miracom.MESCore.Controls.MFOSelectLevel.O:
                    case Miracom.MESCore.Controls.MFOSelectLevel.M:
                    case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                        cdvRetOperFalse.RefuseEventExec = false;
                        cdvRetOperFalse.ListCond_Step = '1';
                        cdvRetOperFalse.ListCond_Flow = "";
                        break;

                    case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                    case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                    case Miracom.MESCore.Controls.MFOSelectLevel.F:
                    case Miracom.MESCore.Controls.MFOSelectLevel.MF:
                        cdvRetOperFalse.RefuseEventExec = false;
                        cdvRetOperFalse.ListCond_Step = '2';
                        cdvRetOperFalse.ListCond_Flow = m_s_flow;
                        break;

                    case Miracom.MESCore.Controls.MFOSelectLevel.NONE:
                        return;
                }
            }

            cdvRetOperFalse.IsPopup = true; 
        }



    }
}

