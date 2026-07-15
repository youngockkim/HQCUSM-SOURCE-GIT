using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASTranAnswerfortheChecklist.cs
//   Description : Answer for CheckList
//
//   MES Version : 5.3.0.0
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
//       - 2013-02-21 : Modified by mhim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
namespace Miracom.BASCore
{
    public partial class frmBASTranAnswerfortheChecklist : frmCheckListTranMain
    {
        public frmBASTranAnswerfortheChecklist()
        {
            InitializeComponent();
        }

        #region " Variable Definition "

        bool m_isPopup = false;
        string m_mat_id = "";
        int m_mat_ver = 0;
        string m_flow = "";
        string m_oper = "";
        string m_tran_code = "";
        string m_event_id = "";
        char m_ba_point = ' ';
        int m_relation_count = 0;
        List<TRSNode> m_chklist_list = null;

        [Browsable(false)]
        public string MatId
        {
            get
            {
                return MPCF.Trim(m_mat_id);
            }
            set
            {
                m_mat_id = MPCF.Trim(value);
            }
        }
        [Browsable(false)]
        public int MatVer
        {
            get
            {
                return m_mat_ver;
            }
            set
            {
                m_mat_ver = value;
            }
        }
        [Browsable(false)]
        public string Flow
        {
            get
            {
                return MPCF.Trim(m_flow);
            }
            set
            {
                m_flow = MPCF.Trim(value);
            }
        }
        [Browsable(false)]
        public string Oper
        {
            get
            {
                return MPCF.Trim(m_oper);
            }
            set
            {
                m_oper = MPCF.Trim(value);
            }
        }
        [Browsable(false)]
        public string TranCode
        {
            get
            {
                return MPCF.Trim(m_tran_code);
            }
            set
            {
                m_tran_code = MPCF.Trim(value);
            }
        }
        [Browsable(false)]
        public string EventID
        {
            get
            {
                return MPCF.Trim(m_event_id);
            }
            set
            {
                m_event_id = MPCF.Trim(value);
            }
        }
        [Browsable(false)]
        public char BAPoint
        {
            get
            {
                return m_ba_point;
            }
            set
            {
                m_ba_point = value;
            }
        }
        [Browsable(false)]
        public int RelationCount
        {
            get
            {
                return m_relation_count;
            }
            set
            {
                m_relation_count = value;
            }
        }

        [Browsable(false)]
        public List<TRSNode> CHKLIST_LIST
        {
            set
            {
                m_chklist_list = value;
            }
            get
            {
                if (m_chklist_list == null) m_chklist_list = new List<TRSNode>();
                return m_chklist_list;
            }
        }

        [Browsable(false)]
        public bool IsPopup
        {
            set
            {
                m_isPopup = value;
            }
            get
            {
                return m_isPopup;
            }
        }

        #endregion

        #region " Function Definition "

        /// <summary>
        /// 초가화 오버라이드(이 화면은 신규답변 작성 기능만 존재한다)
        /// </summary>
        /// <returns></returns>
        public override bool InitForm()
        {
            if (base.InitForm() == false) return false;

            if (m_isPopup)
            {
                txtLot.Text = LotID;
                txtLot.ReadOnly = true;

                txtResource.Text = ResourceID;
                txtResource.ReadOnly = true;

                /* 릴레이션이 1개만 존재할 때의 초기화 */
                if (RelationCount == 1)
                {
                    cdvChecklistType.ReadOnly = true;
                    cdvChecklistType.VisibleButton = false;

                    cdvChecklistID.ReadOnly = true;
                    cdvChecklistID.VisibleButton = false;

                    cdvChecklistType.Text = CHKLIST_LIST[0].GetString("CHKLIST_TYPE");
                    ViewChecklist_list();

                    cdvChecklistID.Text = CHKLIST_LIST[0].GetString("CHKLIST_ID");
                    txtDesc.Text = CHKLIST_LIST[0].GetString("CHKLIST_DESC");

                    if (ViewMain(MPCF.Trim(cdvChecklistID.Text)) == false)
                    {
                        return false;
                    }
                }
            }
            else
            {
                btnView.Location = btnProcess.Location;
                btnProcess.Location = btnDelete.Location;
                btnDelete.Visible = false;
                btnStop.Visible = false;
            }

            return true;
        }

        /// <summary>
        /// 체크리스트 정보 조회 오버라이드 함수
        /// </summary>
        /// <param name="chklist_id"></param>
        /// <returns></returns>
        public override bool ViewCheckList(string chklist_id)
        {
            TRSNode in_node = new TRSNode("BAS_View_Checklist_In");
            TRSNode out_node = new TRSNode("BAS_View_Checklist_Out");
            CheckListKeyPrompt key;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHKLIST_ID", chklist_id);

                if (MPCR.CallService("BAS", "BAS_View_Checklist", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtDesc.Text = out_node.GetString("CHKLIST_DESC");

                /*Make KeyPromptArray*/
                m_KeyPrompt_List = new List<CheckListKeyPrompt>(10);
                for (int i = 1; i <= 10; i++)
                {
                    key = new CheckListKeyPrompt();
                    key.KeyIndex = i;
                    key.Prompt = out_node.GetString(string.Format("KEY_{0}_PMT", i));
                    key.Table = out_node.GetString(string.Format("KEY_{0}_TBL", i));
                    key.Item = out_node.GetString(string.Format("KEY_{0}_ITEM", i));
                    key.Format = out_node.GetChar(string.Format("KEY_{0}_FMT", i));
                    key.Require = out_node.GetChar(string.Format("KEY_{0}_REQ", i));
                    key.Value = "";

                    m_KeyPrompt_List.Add(key);
                }

                if (out_node.GetChar("LOT_OR_RES_FLAG") == 'L')
                {
                    txtLot.Text = LotID;
                    txtLot.Visible = true;
                    lblLot.Visible = true;

                    txtResource.Text = "";
                    txtResource.Visible = false;
                    lblRes.Visible = false;
                }
                else if (out_node.GetChar("LOT_OR_RES_FLAG") == 'R')
                {
                    txtResource.Text = ResourceID;
                    txtResource.Visible = true;
                    lblRes.Visible = true;

                    txtLot.Text = "";
                    txtLot.Visible = false;
                    lblLot.Visible = false;
                }

                CHKLIST = out_node;
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        public override bool ViewChecklist_list()
        {
            try
            {
                if (MPCF.CheckValue(cdvChecklistType, 1) == false)
                {
                    cdvChecklistType.Select();
                    return false;
                }

                cdvChecklistID.Init();
                MPCF.InitListView(cdvChecklistID.GetListView);
                cdvChecklistID.Columns.Add("CheckList", 50, HorizontalAlignment.Left);
                cdvChecklistID.Columns.Add("Desc", 50, HorizontalAlignment.Left);
                cdvChecklistID.SelectedSubItemIndex = 0;

                if (!IsPopup)
                {
                    CHKLIST_LIST = new List<TRSNode>();
                    if (txtLot.Text != "")
                    {
                        BASCR.ViewChecklistRelationList(BASCR.CHKLIST_STEP_LOT, "", ' ', txtLot.Text, ref m_chklist_list);
                    }
                    else if (txtResource.Text != "")
                    {
                        BASCR.ViewChecklistRelationList(BASCR.CHKLIST_STEP_RESOURCE, "", ' ', txtResource.Text, ref m_chklist_list);
                    }
                }

                if (CHKLIST_LIST.Count == 0)
                {
                    return BASLIST.ViewChecklistList(cdvChecklistID.GetListView, '2', MPCF.Trim(cdvChecklistType.Text));
                }
                else
                {
                    ListViewItem itemX = null;
                    for (int i = 0; i < CHKLIST_LIST.Count; i++)
                    {
                        if (CHKLIST_LIST[i].GetString("CHKLIST_TYPE").Equals(cdvChecklistType.Text) == false) continue;
                        itemX = new ListViewItem(CHKLIST_LIST[i].GetString("CHKLIST_ID"), (int)SMALLICON_INDEX.IDX_MESSAGE);
                        itemX.SubItems.Add(CHKLIST_LIST[i].GetString("CHKLIST_DESC"));
                        itemX.SubItems[1].Tag = CHKLIST_LIST[i].GetString("REL_KEY");

                        cdvChecklistID.Items.Add(itemX);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ViewChecklistRelation(string s_chklist_id, string s_rel_key)
        {
            TRSNode in_node = new TRSNode("BAS_View_Checklist_Relation_In");
            TRSNode out_node = new TRSNode("BAS_View_Checklist_Relation_Out");
            CheckListKeyPrompt key;

            try
            {
                if (s_rel_key == "") return true;

                in_node.Init();
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("CHKLIST_ID", s_chklist_id);
                in_node.AddString("REL_KEY", s_rel_key);

                if (MPCR.CallService("BAS", "BAS_View_Checklist_Relation", in_node, ref out_node) == false)
                {
                    return false;
                }

                CHKLIST.SetString("REL_KEY", out_node.GetString("REL_KEY"));
                CHKLIST.SetChar("REQ_COMPLETE_FLAG", out_node.GetChar("REQ_COMPLETE_FLAG"));
                CHKLIST.SetString("REQ_COMPLETE_USER_ID", out_node.GetString("COMPLETE_USER_ID"));

                /* Override Key Require Flag by Relation */
                for (int i = 0; i < 10; i++)
                {
                    key = KeyPromptList[i];
                    if (out_node.GetChar(string.Format("KEY_{0}_REQ", i + 1)) != ' ')
                    {
                        key.Require = out_node.GetChar(string.Format("KEY_{0}_REQ", i + 1));
                    }
                    KeyPromptList[i] = key;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewChecklistHistory(char c_step, string s_chklist_id, string s_rel_key, ref int i_hist_seq, string s_base_obj_id)
        {
            TRSNode in_node = new TRSNode("BAS_View_Checklist_History_In");
            TRSNode out_node = new TRSNode("BAS_View_Checklist_History_Out");
            CheckListKeyPrompt key;

            try
            {
                in_node.Init();
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("CHKLIST_ID", s_chklist_id);
                in_node.AddString("BASE_OBJ_ID", s_base_obj_id);
                in_node.AddString("REL_KEY", s_rel_key);
                in_node.AddInt("HIST_SEQ", i_hist_seq);

                if (MPCR.CallService("BAS", "BAS_View_Checklist_History", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (int i = 0; i < 10; i++)
                {
                    key = KeyPromptList[i];
                    key.Value = out_node.GetString(string.Format("KEY_{0}_VALUE", i + 1));
                    KeyPromptList[i] = key;
                }

                i_hist_seq = out_node.GetInt("HIST_SEQ");
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        public override bool ViewMain(string chklist_id)
        {
            int i_hist_seq = 0;
            string s_rel_key = "";

            ClearData("1");

            // Get Checklist Relation Key
            ListViewItem lvItem = null;
            if (cdvChecklistID.SelectedItem != null)
            {
                lvItem = cdvChecklistID.SelectedItem;
            }
            else
            {
                lvItem = cdvChecklistID.Items[MPCF.FindListItemIndex(cdvChecklistID.GetListView, chklist_id, true)];
            }
            s_rel_key = MPCF.Trim(lvItem.SubItems[1].Tag);

            // Get Checklist Information
            if (ViewCheckList(chklist_id) == false)
            {
                return false;
            }

            // Popup이 아닌 상태는 Relation이 없는 Checklist 입력이다.
            if (IsPopup)
            {
                // Get Checklist Relation Information
                if (ViewChecklistRelation(chklist_id, s_rel_key) == false)
                {
                    return false;
                }

                chkCompleteFlag.Enabled = false;
                // Inquiry Uncomplete Checklist Answer
                if (CHKLIST.GetChar("REQ_COMPLETE_FLAG") == 'Y')
                {
                    if (ViewChecklistHistory('3', chklist_id, s_rel_key, ref i_hist_seq, CHKLIST.GetChar("LOT_OR_RES_FLAG") == 'L' ? txtLot.Text : txtResource.Text) == false)
                    {
                        return false;
                    }

                    if (CHKLIST.GetString("REQ_COMPLETE_USER_ID") == "" || CHKLIST.GetString("REQ_COMPLETE_USER_ID").Equals(MPGV.gsUserID))
                    {
                        chkCompleteFlag.Enabled = true;
                    }
                }
            }
            else
            {
                chkCompleteFlag.Visible = false;
            }

            DisplayKeyPrompt();

            if (i_hist_seq > 0)
            {
                if (ViewQueryAnswer(chklist_id, i_hist_seq) == false)
                {
                    return false;
                }

                CHKLIST.SetInt("UNCOMPLETED_HIST_SEQ", i_hist_seq);
            }
            else
            {
                if (MPCF.Trim(txtLot.Text) != "")
                {
                    base.ViewLotInfo(MPCF.Trim(txtLot.Text));
                }
                if (MPCF.Trim(txtResource.Text) != "")
                {
                    base.ViewResourceInfo(MPCF.Trim(txtResource.Text));
                }

                if (ViewQueryList(chklist_id) == false) return false;
            }

            return true;
        }

        public override bool ProcessMain()
        {
            bool bResult = false;

            if (CHKLIST.GetInt("UNCOMPLETED_HIST_SEQ") > 0)
            {
                bResult = base.UpdateAnswer(CHKLIST.GetInt("UNCOMPLETED_HIST_SEQ"));
            }
            else
            {
                bResult = base.CreateAnswer();
            }

            if (bResult == true)
            {
                if (IsPopup)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                    this.Close();
                }
            }

            return bResult;
        }

        #endregion

        private void txtLot_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtLot.Text = MPCF.Trim(txtLot.Text);
            if (e.KeyChar == (char)13 && txtLot.Text != "")
            {
                ClearData("4");
                if (ViewLotInfo(txtLot.Text) == false)
                {
                    txtLot.SelectAll();
                }
            }
        }

        //private void txtLot_Leave(object sender, EventArgs e)
        //{
        //    txtLot.Text = MPCF.Trim(txtLot.Text);
        //    if (txtLot.Text != "" && LOT.GetString("LOT_ID") != txtLot.Text)
        //    {
        //        if (ViewLotInfo(txtLot.Text) == false)
        //        {
        //            txtLot.SelectAll();
        //        }
        //    }
        //}

        private void txtResource_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtResource.Text = MPCF.Trim(txtResource.Text);
            if (e.KeyChar == (char)13 && txtResource.Text != "")
            {
                ClearData("4");
                if (base.ViewResourceInfo(txtResource.Text) == false)
                {
                    txtResource.SelectAll();
                }
            }
        }

        //private void txtResource_Leave(object sender, EventArgs e)
        //{
        //    txtResource.Text = MPCF.Trim(txtResource.Text);
        //    if (txtResource.Text != "" && RESOURCE.GetString("RES_ID") != txtResource.Text)
        //    {
        //        if (base.ViewResourceInfo(txtResource.Text) == false)
        //        {
        //            txtResource.SelectAll();
        //        }
        //    }
        //}

        private void cdvChecklistID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            ViewMain(cdvChecklistID.Text);
        }

        private void txtLot_TextChanged(object sender, EventArgs e)
        {
            LotID = txtLot.Text;
        }

        private void txtResource_TextChanged(object sender, EventArgs e)
        {
            ResourceID = txtResource.Text;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
