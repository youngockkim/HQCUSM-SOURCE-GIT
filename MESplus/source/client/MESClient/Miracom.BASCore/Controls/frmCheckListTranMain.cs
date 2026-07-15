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
//   File Name   : frmCheckListTranMain.cs
//   Description : Checklist BaseForm
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
//       - 2013-02-21 : Created by mhim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

namespace Miracom.BASCore
{
    public partial class frmCheckListTranMain : Miracom.MESCore.ViewForm01
    {
        public frmCheckListTranMain()
        {
            InitializeComponent();
        }

        protected struct CheckListKeyPrompt
        {
            public int KeyIndex;
            public string Prompt;
            public string Table;
            public string Item;
            public string Value;
            public char Require;
            public char Format;
        }

        protected List<CheckListKeyPrompt> m_KeyPrompt_List;

        #region " Constant Definition "

        public enum ColHISTORY : int
        {
            Seq = 0,
            TranTime,
            TranUser,
            CompleteFlag,
            CompleteUser,
            CompleteTime,
            KeyPrompt1,
            KeyPrompt2,
            KeyPrompt3,
            KeyPrompt4,
            KeyPrompt5,
            KeyPrompt6,
            KeyPrompt7,
            KeyPrompt8,
            KeyPrompt9,
            KeyPrompt10
        }

        public enum ColKEY : int
        {
            Seq = 0,
            Prompt,
            Value,
            ValueBtn,
            Padding,
            Seq2,
            Prompt2,
            Value2,
            ValueBtn2
        }

        public enum ColQUERY : int
        {
            Check = 0,
            Seq,
            ID,
            Query,
            Answer,
            Button
        }

        #endregion

        #region " Variable Definition "

        protected bool b_load_flag = false;
        protected bool b_visible_history = true;
        protected bool b_read_only = false;

        TRSNode m_chklist_info = null;
        TRSNode m_lot_info = null;
        TRSNode m_res_info = null;


        #endregion

        #region " Property Definition "

        public bool VisibleHistory
        {
            get
            {
                return b_visible_history;
            }
            set
            {
                b_visible_history = value;
                grpCheckListHistory.Visible = b_visible_history;
                splitter1.Visible = b_visible_history;
            }
        }

        [Browsable(false)]
        public TRSNode CHKLIST
        {
            get
            {
                if (m_chklist_info == null) m_chklist_info = new TRSNode("");
                return m_chklist_info;
            }
            set
            {
                m_chklist_info = value;
            }
        }

        [Browsable(false)]
        public TRSNode LOT
        {
            get
            {
                if (m_lot_info == null) m_lot_info = new TRSNode("");
                return m_lot_info;
            }
        }

        [Browsable(false)]
        public TRSNode RESOURCE
        {
            get
            {
                if (m_res_info == null) m_res_info = new TRSNode("");
                return m_res_info;
            }
        }

        [Browsable(false)]
        protected List<CheckListKeyPrompt> KeyPromptList
        {
            get
            {
                if (m_KeyPrompt_List == null)
                {
                    if (CHKLIST.GetString("CHKLIST_ID") == "")
                    {
                        m_KeyPrompt_List = new List<CheckListKeyPrompt>(10);
                    }
                    else ViewCheckList(CHKLIST.GetString("CHKLIST_ID"));
                }

                return m_KeyPrompt_List;
            }
        }


        private string m_lot_id;
        private string m_res_id;

        [Browsable(false)]
        public string LotID
        {
            get
            {
                return MPCF.Trim(m_lot_id);
            }
            set
            {
                m_lot_id = MPCF.Trim(value);
            }
        }

        [Browsable(false)]
        public string ResourceID
        {
            get
            {
                return MPCF.Trim(m_res_id);
            }
            set
            {
                m_res_id = MPCF.Trim(value);
            }
        }

        #endregion

        #region " Function Definition "

        public void ClearData(string ProcStep)
        {
            chkCompleteFlag.Checked = false;

            if (ProcStep == "1")
            {
                MPCF.FieldClear(pnlViewMid);

                MPCF.ClearList(lisCheckHistory);

                spdKeyPrompt_Sheet1.RowCount = 0;
                spdKeyPrompt_Sheet1.Columns[(int)ColKEY.Padding, spdKeyPrompt_Sheet1.Columns.Count - 1].Visible = false;

                spdQueryAnswer_Sheet1.RowCount = 0;
            }
            else if(ProcStep == "2")
            {
                MPCF.ClearList(lisCheckHistory);

                spdKeyPrompt_Sheet1.ClearRange(0, (int)ColKEY.Value, 5, 1, true);
                spdKeyPrompt_Sheet1.ClearRange(0, (int)ColKEY.Value2, 5, 1, true);

                spdQueryAnswer_Sheet1.RowCount = 0;
            }
            else if (ProcStep == "3")
            {
                spdKeyPrompt_Sheet1.ClearRange(0, (int)ColKEY.Value, 5, 1, true);
                spdKeyPrompt_Sheet1.ClearRange(0, (int)ColKEY.Value2, 5, 1, true);

                spdQueryAnswer_Sheet1.RowCount = 0;
            }
            else if (ProcStep == "4")
            {
                spdKeyPrompt_Sheet1.ClearRange(0, (int)ColKEY.Value, 5, 1, true);
                spdKeyPrompt_Sheet1.ClearRange(0, (int)ColKEY.Value2, 5, 1, true);
            }
        }

        /// <summary>
        /// 초가화
        /// </summary>
        /// <returns></returns>
        public virtual bool InitForm()
        {
            try
            {
                spdQueryAnswer_Sheet1.Columns[(int)ColQUERY.Check].Visible = false;
                spdQueryAnswer_Sheet1.Columns[(int)ColQUERY.Seq].Visible = false;
                spdQueryAnswer_Sheet1.Columns[(int)ColQUERY.ID].Visible = false;

                for (int i = 0; i < spdKeyPrompt_Sheet1.RowCount; i++)
                {
                    if (spdKeyPrompt_Sheet1.Columns.Count > (int)ColKEY.Value)
                    {
                        spdKeyPrompt_Sheet1.Cells[i, (int)ColKEY.Value].ColumnSpan = 2;
                    }
                }
                for (int i = 0; i < spdKeyPrompt_Sheet1.RowCount; i++)
                {
                    if (spdKeyPrompt_Sheet1.Columns.Count > (int)ColKEY.Value2)
                    {
                        spdKeyPrompt_Sheet1.Cells[i, (int)ColKEY.Value2].ColumnSpan = 2;
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

        /// <summary>
        /// "View"버튼 클릭시 호출되는 함수
        /// </summary>
        /// <param name="chklist_id"></param>
        /// <returns></returns>
        public virtual bool ViewMain(string chklist_id)
        {
            if (ViewCheckList(chklist_id) == true)
            {
                return ViewQueryList(chklist_id);
            }

            return false;
        }

        /// <summary>
        /// "Process"버튼 클릭시 호출되는 함수
        /// </summary>
        /// <returns></returns>
        public virtual bool ProcessMain()
        {
            return CreateAnswer();
        }

        /// <summary>
        /// 체크리스트 정보 조회.(Key셋팅정보 포함)
        /// </summary>
        /// <param name="chklist_id"></param>
        /// <returns></returns>
        public virtual bool ViewCheckList(string chklist_id)
        {
            TRSNode in_node = new TRSNode("BAS_View_Checklist_In");
            TRSNode out_node = new TRSNode("BAS_View_Checklist_Out");
            int i;
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

                m_chklist_info = out_node;
                txtDesc.Text = out_node.GetString("CHKLIST_DESC");

                /*Make KeyPromptArray*/
                m_KeyPrompt_List = new List<CheckListKeyPrompt>(10);
                for (i = 1; i <= 10; i++)
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
                    lblBaseItemId.Text = "Lot ID";
                }
                else if (out_node.GetChar("LOT_OR_RES_FLAG") == 'R')
                {
                    lblBaseItemId.Text = "Res ID";
                }

                DisplayHistoryColums();

                if (VisibleHistory == true)
                {
                    if (ViewHistoryList(chklist_id) == true)
                    {
                        if (lisCheckHistory.Items.Count > 0)
                        {
                            lisCheckHistory.Items[0].Selected = true;
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

        /// <summary>
        /// 질의목록 조회
        /// </summary>
        /// <param name="chklist_id"></param>
        /// <returns></returns>
        public virtual bool ViewQueryList(string chklist_id)
        {
            FarPoint.Win.Spread.CellType.ButtonCellType btnCell;
            
            TRSNode in_node = new TRSNode("BAS_View_Checklist_Query_List_In");
            TRSNode out_node = null;
            ArrayList a_list;
            int i, iRow;
            List<TRSNode> query_list;

            try
            {
                a_list = new ArrayList();
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHKLIST_ID", chklist_id);

                do
                {
                    out_node = new TRSNode("BAS_View_Checklist_Query_List_Out"); 
                    if (MPCR.CallService("BAS", "BAS_View_Checklist_Query_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    a_list.Add(out_node);
                    in_node.SetString("NEXT_QUERY_ID", out_node.GetString("NEXT_QUERY_ID"));
                }
                while (in_node.GetString("NEXT_QUERY_ID") != "");

                spdQueryAnswer.SuspendLayout();
                if (b_read_only == true)
                {
                    spdQueryAnswer_Sheet1.Columns[(int)ColQUERY.Answer].Locked = true;
                    spdQueryAnswer_Sheet1.Columns[(int)ColQUERY.Button].Locked = true;
                }
                else
                {
                    spdQueryAnswer_Sheet1.Columns[(int)ColQUERY.Answer].Locked = false;
                    spdQueryAnswer_Sheet1.Columns[(int)ColQUERY.Button].Locked = false;
                }
                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    query_list = out_node.GetList("QUERY_LIST");

                    for (i = 0; i < query_list.Count; i++)
                    {

                        iRow = spdQueryAnswer_Sheet1.RowCount;
                        spdQueryAnswer_Sheet1.RowCount++;

                        spdQueryAnswer_Sheet1.Cells[iRow, (int)ColQUERY.Seq].Value = query_list[i].GetInt("DISP_SEQ");
                        if (query_list[i].GetChar("REQUIRE_FLAG") == 'Y')
                        {
                            spdQueryAnswer_Sheet1.Cells[iRow, (int)ColQUERY.Query].Font = new Font(spdQueryAnswer.Font, FontStyle.Bold);
                        }
                        spdQueryAnswer_Sheet1.Cells[iRow, (int)ColQUERY.ID].Value = query_list[i].GetString("QUERY_ID");
                        spdQueryAnswer_Sheet1.Cells[iRow, (int)ColQUERY.Query].Value = query_list[i].GetString("QUERY");

                        if (query_list[i].GetString("VALID_TBL_NAME") != "" && query_list[i].GetChar("VALID_TBL_TYPE") == 'A')
                        {
                            spdQueryAnswer_Sheet1.Cells[iRow, (int)ColQUERY.Answer].Locked = true;
                            btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            btnCell.Text = "...";
                            spdQueryAnswer_Sheet1.Cells[iRow, (int)ColQUERY.Button].CellType = btnCell;
                            spdQueryAnswer_Sheet1.Cells[iRow, (int)ColQUERY.Button].Tag = query_list[i].GetString("VALID_TBL_NAME");
                        }
                        else
                        {
                            spdQueryAnswer_Sheet1.Cells[iRow, (int)ColQUERY.Answer].ColumnSpan = 2;
                        }
                    }
                }

                spdQueryAnswer.ResumeLayout();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 질의답변 조회
        /// </summary>
        /// <param name="chklist_id"></param>
        /// <param name="hist_seq"></param>
        /// <returns></returns>
        public virtual bool ViewQueryAnswer(string chklist_id, int hist_seq)
        {
            FarPoint.Win.Spread.CellType.ButtonCellType btnCell;

            TRSNode in_node = new TRSNode("BAS_View_Checklist_Answer_In");
            TRSNode out_node = null;
            ArrayList a_list;
            int i, iRow;

            try
            {
                spdQueryAnswer_Sheet1.RowCount = 0;

                //View Query
                a_list = new ArrayList();
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("CHKLIST_ID", chklist_id);
                in_node.AddInt("HIST_SEQ", hist_seq);

                do
                {
                    out_node = new TRSNode("BAS_View_Checklist_Answer_Out");
                    if (MPCR.CallService("BAS", "BAS_View_Checklist_Answer", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    a_list.Add(out_node);
                    in_node.SetString("NEXT_QUERY_ID", out_node.GetString("NEXT_QUERY_ID"));
                }
                while (in_node.GetString("NEXT_QUERY_ID") != "");

                spdQueryAnswer.SuspendLayout();
                if (b_read_only == true)
                {
                    spdQueryAnswer_Sheet1.Columns[(int)ColQUERY.Answer].Locked = true;
                    spdQueryAnswer_Sheet1.Columns[(int)ColQUERY.Button].Locked = true;
                    spdQueryAnswer_Sheet1.Columns[(int)ColQUERY.Check].Visible = false;
                }
                else
                {
                    spdQueryAnswer_Sheet1.Columns[(int)ColQUERY.Answer].Locked = false;
                    spdQueryAnswer_Sheet1.Columns[(int)ColQUERY.Button].Locked = false;
                    spdQueryAnswer_Sheet1.Columns[(int)ColQUERY.Check].Visible = true;
                }
                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdQueryAnswer_Sheet1.RowCount;
                        spdQueryAnswer_Sheet1.RowCount++;

                        spdQueryAnswer_Sheet1.Cells[iRow, (int)ColQUERY.Seq].Value = out_node.GetList(0)[i].GetInt("DISP_SEQ");
                        if (out_node.GetList(0)[i].GetChar("REQUIRE_FLAG") == 'Y')
                        {
                            spdQueryAnswer_Sheet1.Cells[iRow, (int)ColQUERY.Query].Font = new Font(spdQueryAnswer.Font, FontStyle.Bold);
                        }
                        spdQueryAnswer_Sheet1.Cells[iRow, (int)ColQUERY.ID].Value = out_node.GetList(0)[i].GetString("QUERY_ID");
                        spdQueryAnswer_Sheet1.Cells[iRow, (int)ColQUERY.Query].Value = out_node.GetList(0)[i].GetString("QUERY");

                        spdQueryAnswer_Sheet1.Cells[iRow, (int)ColQUERY.Answer].Value = out_node.GetList(0)[i].GetString("ANSWER");
                        if (out_node.GetList(0)[i].GetString("VALID_TBL_NAME") != "" && out_node.GetList(0)[i].GetChar("VALID_TBL_TYPE") == 'A')
                        {
                            spdQueryAnswer_Sheet1.Cells[iRow, (int)ColQUERY.Answer].Locked = true;
                            btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            btnCell.Text = "...";
                            spdQueryAnswer_Sheet1.Cells[iRow, (int)ColQUERY.Button].CellType = btnCell;
                            spdQueryAnswer_Sheet1.Cells[iRow, (int)ColQUERY.Button].Tag = out_node.GetList(0)[i].GetString("VALID_TBL_NAME");
                        }
                        else
                        {
                            spdQueryAnswer_Sheet1.Cells[iRow, (int)ColQUERY.Answer].ColumnSpan = 2;
                        }

                    }
                }
                //SortRows를 하면 ColumnSpan이 풀림
                //spdQueryAnswer_Sheet1.SortRows((int)ColQUERY.Seq, true, false);
                spdQueryAnswer.ResumeLayout();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// History 목록 조회
        /// </summary>
        /// <param name="chklist_id"></param>
        /// <returns></returns>
        public virtual bool ViewHistoryList(string chklist_id)
        {
            TRSNode in_node = new TRSNode("BAS_View_Checklist_History_In");
            TRSNode out_node = null;
            ArrayList a_list;
            ListViewItem itemX;
            int i;

            string from_date, to_date;

            try
            {
                from_date = MPCF.DestroyDateFormat(MPCF.DateToString(dtpFrom.Value), DATE_TIME_FORMAT.DATE);
                to_date = MPCF.DestroyDateFormat(MPCF.DateToString(dtpTo.Value), DATE_TIME_FORMAT.DATE);

                a_list = new ArrayList();
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("CHKLIST_ID", chklist_id);
                in_node.AddString("BASE_OBJ_ID", txtBaseItemId.Text);
                in_node.AddString("FROM_DATE", from_date);
                in_node.AddString("TO_DATE", to_date);

                if (chkIncludeDelHistory.Checked) in_node.AddChar("INCLUDE_DEL_HIST", 'Y');

                do
                {
                    out_node = new TRSNode("BAS_View_Checklist_History_Out");
                    if (MPCR.CallService("BAS", "BAS_View_Checklist_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    a_list.Add(out_node);
                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                }
                while (in_node.GetInt("NEXT_HIST_SEQ") != 0);

                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        itemX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetInt("HIST_SEQ")), -1);
                        itemX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME")));
                        itemX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_USER_ID")));
                        itemX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("COMPLETE_FLAG")));
                        itemX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("COMPLETE_USER_ID")));
                        itemX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("COMPLETE_TIME")));

                        itemX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("KEY_1_VALUE")));
                        itemX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("KEY_2_VALUE")));
                        itemX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("KEY_3_VALUE")));
                        itemX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("KEY_4_VALUE")));
                        itemX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("KEY_5_VALUE")));
                        itemX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("KEY_6_VALUE")));
                        itemX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("KEY_7_VALUE")));
                        itemX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("KEY_8_VALUE")));
                        itemX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("KEY_9_VALUE")));
                        itemX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("KEY_10_VALUE")));

                        if (out_node.GetList(0)[i].GetChar("DELETE_FLAG") == 'Y')
                        {
                            itemX.ForeColor = Color.Magenta;
                        }

                        lisCheckHistory.Items.Add(itemX);
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

        /// <summary>
        /// History 상세정보 조회
        /// </summary>
        /// <param name="chklist_id"></param>
        /// <param name="check_history_seq"></param>
        /// <returns></returns>
        public virtual bool ViewHistory(string chklist_id, int check_history_seq)
        {
            TRSNode in_node = new TRSNode("BAS_View_Checklist_History_In");
            TRSNode out_node = new TRSNode("BAS_View_Checklist_History_Out");
            int i;
            CheckListKeyPrompt key;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHKLIST_ID", chklist_id);
                in_node.AddInt("HIST_SEQ", check_history_seq);
                if (MPCR.CallService("BAS", "BAS_View_Checklist_History", in_node, ref out_node) == false)
                {
                    return false;
                }

                m_chklist_info.SetInt("HIST_SEQ", out_node.GetInt("HIST_SEQ"));
                m_chklist_info.SetString("REL_KEY", out_node.GetString("REL_KEY"));
                m_chklist_info.SetString("TRAN_TIME", out_node.GetString("TRAN_TIME"));
                m_chklist_info.SetString("TRAN_USER_ID", out_node.GetString("TRAN_USER_ID"));
                m_chklist_info.SetChar("COMPLETE_FLAG", out_node.GetChar("COMPLETE_FLAG"));
                m_chklist_info.SetString("COMPLETE_TIME", out_node.GetString("COMPLETE_TIME"));
                m_chklist_info.SetString("COMPLETE_USER_ID", out_node.GetString("COMPLETE_USER_ID"));
                m_chklist_info.SetChar("DELETE_FLAG", out_node.GetChar("DELETE_FLAG"));
                m_chklist_info.SetString("DELETE_TIME", out_node.GetString("DELETE_TIME"));
                m_chklist_info.SetString("DELETE_USER_ID", out_node.GetString("DELETE_USER_ID"));
                m_chklist_info.SetString("BASE_OBJ_ID", out_node.GetString("BASE_OBJ_ID"));
                m_chklist_info.SetInt("BASE_OBJ_HIST_SEQ", out_node.GetInt("BASE_OBJ_HIST_SEQ"));
                m_chklist_info.SetString("KEY_1_VALUE", out_node.GetString("KEY_1_VALUE"));
                m_chklist_info.SetString("KEY_2_VALUE", out_node.GetString("KEY_2_VALUE"));
                m_chklist_info.SetString("KEY_3_VALUE", out_node.GetString("KEY_3_VALUE"));
                m_chklist_info.SetString("KEY_4_VALUE", out_node.GetString("KEY_4_VALUE"));
                m_chklist_info.SetString("KEY_5_VALUE", out_node.GetString("KEY_5_VALUE"));
                m_chklist_info.SetString("KEY_6_VALUE", out_node.GetString("KEY_6_VALUE"));
                m_chklist_info.SetString("KEY_7_VALUE", out_node.GetString("KEY_7_VALUE"));
                m_chklist_info.SetString("KEY_8_VALUE", out_node.GetString("KEY_8_VALUE"));
                m_chklist_info.SetString("KEY_9_VALUE", out_node.GetString("KEY_9_VALUE"));
                m_chklist_info.SetString("KEY_10_VALUE", out_node.GetString("KEY_10_VALUE"));
                
                if (m_chklist_info.GetString("REL_KEY") == "")
                {
                    m_chklist_info.SetString("REL_KEY", "");
                    m_chklist_info.SetChar("REQ_COMPLETE_FLAG", "");
                    m_chklist_info.SetString("REQ_COMPLETE_USER_ID", "");

                    for (i = 0; i < 10; i++)
                    {
                        key = KeyPromptList[i];
                        key.Require = m_chklist_info.GetChar(string.Format("KEY_{0}_REQ", i + 1));
                        KeyPromptList[i] = key;
                    }
                }
                else
                {
                    in_node.Init();
                    out_node = new TRSNode("BAS_View_Checklist_Relation_Out");
                    MPCR.SetInMsg(in_node);
                    in_node.ProcStep = '2';
                    in_node.AddString("CHKLIST_ID", chklist_id);
                    in_node.AddString("REL_KEY", m_chklist_info.GetString("REL_KEY"));
                    if (MPCR.CallService("BAS", "BAS_View_Checklist_Relation", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    m_chklist_info.SetChar("REQ_COMPLETE_FLAG", out_node.GetChar("REQ_COMPLETE_FLAG"));
                    m_chklist_info.SetString("REQ_COMPLETE_USER_ID", out_node.GetString("COMPLETE_USER_ID"));

                    /* Relation에서 Key Require Flag를 덮어쓰기 할 수 있으므로 RelKey가 존재할 경우 KEY_00_REQ 값을 업데이트 한다 */
                    for (i = 0; i < 10; i++)
                    {
                        key = KeyPromptList[i];
                        key.Require = out_node.GetChar(string.Format("KEY_{0}_REQ", i + 1));
                        KeyPromptList[i] = key;
                    }
                }

                /*Make KeyPrompt Array*/
                for (i = 0; i < 10; i++)
                {
                    key = KeyPromptList[i];
                    key.Value = m_chklist_info.GetString(string.Format("KEY_{0}_VALUE", i + 1));
                    KeyPromptList[i] = key;
                }

                txtBaseItemId.Text = m_chklist_info.GetString("BASE_OBJ_ID");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Lot 정보(History, Attribute 정보 조회)
        /// </summary>
        /// <param name="lot_id"></param>
        /// <returns></returns>
        public virtual bool ViewLotInfo(string lot_id, bool only_info = false)
        {
            TRSNode in_node = new TRSNode("WIP_View_Lot_In");
            TRSNode out_node = new TRSNode("WIP_View_Lot_Out");
            TRSNode col_item, row_item, hist_item, attr_item;
            int i, n;

            try
            {
                m_lot_info = null;
                if (lot_id == "") return true;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(lot_id));

                if (MPCR.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                m_lot_info = out_node;

                if (only_info) return true;

                out_node = new TRSNode("BAS_SQL_Query_In");
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SQL", string.Format("SELECT * FROM MWIPLOTHIS WHERE LOT_ID = '{0}' AND HIST_SEQ = {1}", lot_id, LOT.GetInt("LAST_ACTIVE_HIST_SEQ")));
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                hist_item = m_lot_info.AddNode("HIST_ITEM");
                row_item = out_node.GetList("ROWS")[0];
                for (i = 0; i < out_node.GetList("COLUMNS").Count; i++)
                {
                    col_item = out_node.GetList("COLUMNS")[i];
                    switch (col_item.GetString("TYPE"))
                    {
                        case "INT":
                            hist_item.AddInt(col_item.GetString("NAME"), MPCF.ToInt(row_item.GetList("COLS")[i].GetString("DATA")));
                            break;
                        case "LNG":
                            hist_item.AddLong(col_item.GetString("NAME"), Convert.ToInt64(row_item.GetList("COLS")[i].GetString("DATA")));
                            break;
                        case "DBL":
                            hist_item.AddDouble(col_item.GetString("NAME"), MPCF.ToDbl(row_item.GetList("COLS")[i].GetString("DATA")));
                            break;
                        case "CHR":
                            hist_item.AddChar(col_item.GetString("NAME"), MPCF.ToChar(row_item.GetList("COLS")[i].GetString("DATA")));
                            break;
                        case "STR":
                            hist_item.AddString(col_item.GetString("NAME"), MPCF.Trim(row_item.GetList("COLS")[i].GetString("DATA")));
                            break;
                    }
                }

                //Attribute
                in_node.Init();
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SQL", string.Format("SELECT ATTR_NAME, ATTR_VALUE FROM MATRNAMSTS WHERE FACTORY = '{0}' AND ATTR_TYPE = 'LOT' AND ATTR_KEY = '{1}'", MPGV.gsFactory, lot_id));
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                attr_item = m_lot_info.AddNode("ATTR_ITEM");
                for (n = 0; n < out_node.GetList("ROWS").Count; n++)
                {
                    row_item = out_node.GetList("ROWS")[n];
                    attr_item.AddString(row_item.GetList("COLS")[0].GetString("DATA"), row_item.GetList("COLS")[1].GetString("DATA"));
                }

                CheckListKeyPrompt key;
                int iRow, iCol;
                for (i = 0; i < KeyPromptList.Count && spdKeyPrompt_Sheet1.RowCount > 0; i++)
                {
                    key = KeyPromptList[i];

                    if (i < 5)
                    {
                        iRow = i;
                        iCol = (int)ColKEY.Value;
                    }
                    else
                    {
                        iRow = i - 5;
                        iCol = (int)ColKEY.Value2;
                    }

                    hist_item = LOT.GetList("HIST_ITEM")[0];
                    attr_item = LOT.GetList("ATTR_ITEM")[0];
                    switch (key.Table)
                    {
                        case "$LOT_HISTORY":
                            if (hist_item.GetMember(key.Item) != null && (spdKeyPrompt_Sheet1.Cells[iRow, iCol].Value == null ||
                                spdKeyPrompt_Sheet1.Cells[iRow, iCol].Value.ToString() == ""))
                            {
                                spdKeyPrompt_Sheet1.Cells[iRow, iCol].Value = hist_item.GetMember(key.Item).Value;
                            }
                            break;
                        case "$LOT_ATTR":
                            if (attr_item.GetMember(key.Item) != null && (spdKeyPrompt_Sheet1.Cells[iRow, iCol].Value == null ||
                                spdKeyPrompt_Sheet1.Cells[iRow, iCol].Value.ToString() == ""))
                            {
                                spdKeyPrompt_Sheet1.Cells[iRow, iCol].Value = attr_item.GetMember(key.Item).Value;
                            }
                            break;


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

        /// <summary>
        /// 장비 정보(History, Attribute 정보 조회)
        /// </summary>
        /// <param name="res_id"></param>
        /// <returns></returns>
        public virtual bool ViewResourceInfo(string res_id, bool only_info = false)
        {
            TRSNode in_node = new TRSNode("RAS_View_Resource_In");
            TRSNode out_node = new TRSNode("RAS_View_Resource_Out");
            TRSNode col_item, row_item, hist_item;
            int i;

            try
            {
                m_res_info = null;
                if (res_id == "") return true;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", MPCF.Trim(res_id));

                if (MPCR.CallService("RAS", "RAS_View_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                m_res_info = out_node;

                if (only_info) return true;
                if (RESOURCE.GetInt("LAST_ACTIVE_HIST_SEQ") <= 0) return true;

                out_node = new TRSNode("BAS_SQL_Query_In");
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SQL", string.Format("SELECT * FROM MRASRESHIS WHERE RES_ID = '{0}' AND HIST_SEQ = {1}", res_id, RESOURCE.GetInt("LAST_ACTIVE_HIST_SEQ")));
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                hist_item = m_res_info.AddNode("HIST_ITEM");
                row_item = out_node.GetList("ROWS")[0];
                for (i = 0; i < out_node.GetList("COLUMNS").Count; i++)
                {
                    col_item = out_node.GetList("COLUMNS")[i];
                    switch (col_item.GetString("TYPE"))
                    {
                        case "INT":
                            hist_item.AddInt(col_item.GetString("NAME"), MPCF.ToInt(row_item.GetList("COLS")[i].GetString("DATA")));
                            break;
                        case "LNG":
                            hist_item.AddLong(col_item.GetString("NAME"), Convert.ToInt64(row_item.GetList("COLS")[i].GetString("DATA")));
                            break;
                        case "DBL":
                            hist_item.AddDouble(col_item.GetString("NAME"), MPCF.ToDbl(row_item.GetList("COLS")[i].GetString("DATA")));
                            break;
                        case "CHR":
                            hist_item.AddChar(col_item.GetString("NAME"), MPCF.ToChar(row_item.GetList("COLS")[i].GetString("DATA")));
                            break;
                        case "STR":
                            hist_item.AddString(col_item.GetString("NAME"), MPCF.Trim(row_item.GetList("COLS")[i].GetString("DATA")));
                            break;
                    }
                }

                CheckListKeyPrompt key;
                int iRow, iCol;
                for (i = 0; i < KeyPromptList.Count && spdKeyPrompt_Sheet1.RowCount > 0; i++)
                {
                    key = KeyPromptList[i];

                    if (i < 5)
                    {
                        iRow = i;
                        iCol = (int)ColKEY.Value;
                    }
                    else
                    {
                        iRow = i - 5;
                        iCol = (int)ColKEY.Value2;
                    }

                    hist_item = RESOURCE.GetList("HIST_ITEM")[0];
                    switch (key.Table)
                    {
                        case "$RES_HISTORY":
                            if (hist_item.GetMember(key.Item) != null && (spdKeyPrompt_Sheet1.Cells[iRow, iCol].Value == null ||
                                spdKeyPrompt_Sheet1.Cells[iRow, iCol].Value.ToString() == ""))
                            {
                                spdKeyPrompt_Sheet1.Cells[iRow, iCol].Value = hist_item.GetMember(key.Item).Value;
                            }
                            break;
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

        /// <summary>
        /// Key Column 셋팅을 History 컬럼에 반영한다
        /// </summary>
        public virtual void DisplayHistoryColums()
        {
            int i;
            CheckListKeyPrompt key;

            for (i = 0; i < 10; i++)
            {
                key = KeyPromptList[i];
                /* History Column */
                if (key.Prompt == "")
                {
                    lisCheckHistory.Columns[(int)ColHISTORY.KeyPrompt1 + i].Text = "(none)";
                }
                else
                {
                    lisCheckHistory.Columns[(int)ColHISTORY.KeyPrompt1 + i].Text = key.Prompt;
                }
            }
        }

        /// <summary>
        /// Key Column 셋팅을 컬럼에 반영한다
        /// </summary>
        public virtual void DisplayKeyPrompt()
        {
            int i, iRow, iCol;
            CheckListKeyPrompt key;
            Font BoldFont, RegularFont;
            BoldFont = new Font(spdKeyPrompt.Font, FontStyle.Bold);
            RegularFont = new Font(spdKeyPrompt.Font, FontStyle.Regular);

            spdKeyPrompt_Sheet1.RowCount = 5;

            iRow = 0;
            iCol = 0;
            for (i = 0; i < 10; i++)
            {
                key = KeyPromptList[i];

                if (i < 5)
                {
                    iRow = i;
                    iCol = 0;
                }
                else
                {
                    iRow = i - 5;
                    iCol = (int)ColKEY.Value2 - (int)ColKEY.Value;
                }
                if (key.Prompt == "")
                {
                    spdKeyPrompt_Sheet1.Cells[iRow, (int)ColKEY.Value + iCol].ColumnSpan = 2;
                    continue;
                }

                if (iCol > 0)
                {
                    spdKeyPrompt_Sheet1.Columns[(int)ColKEY.Padding, spdKeyPrompt_Sheet1.Columns.Count - 1].Visible = true;
                    spdKeyPrompt_Sheet1.Cells[0, (int)ColKEY.Padding].RowSpan = spdKeyPrompt_Sheet1.RowCount;
                }
                spdKeyPrompt_Sheet1.Cells[iRow, (int)ColKEY.Seq + iCol].Value = key.KeyIndex;
                spdKeyPrompt_Sheet1.Cells[iRow, (int)ColKEY.Prompt + iCol].Value = key.Prompt;
                spdKeyPrompt_Sheet1.Cells[iRow, (int)ColKEY.Value + iCol].Value = key.Value;
                if (b_read_only)
                {
                    spdKeyPrompt_Sheet1.Cells[iRow, (int)ColKEY.Value + iCol].ColumnSpan = 2;
                    spdKeyPrompt_Sheet1.Cells[iRow, (int)ColKEY.Value + iCol].Locked = true;
                }
                else
                {
                    if (key.Table == "$GCM")
                    {
                        spdKeyPrompt_Sheet1.Cells[iRow, (int)ColKEY.Value + iCol].ColumnSpan = 1;
                        spdKeyPrompt_Sheet1.Cells[iRow, (int)ColKEY.ValueBtn + iCol].Tag = key.Item;
                        spdKeyPrompt_Sheet1.Cells[iRow, (int)ColKEY.Value + iCol].Locked = true;
                    }
                    else
                    {
                        spdKeyPrompt_Sheet1.Cells[iRow, (int)ColKEY.Value + iCol].ColumnSpan = 2;
                        spdKeyPrompt_Sheet1.Cells[iRow, (int)ColKEY.Value + iCol].Locked = false;
                    }
                }
                if (key.Require == 'Y')
                {
                    spdKeyPrompt_Sheet1.Cells[iRow, (int)ColKEY.Prompt + iCol].Font = BoldFont;
                }
                else
                {
                    spdKeyPrompt_Sheet1.Cells[iRow, (int)ColKEY.Prompt + iCol].Font = RegularFont;
                }
            }
        }

        /// <summary>
        /// 답변 신규작성
        /// </summary>
        /// <returns></returns>
        public virtual bool CreateAnswer()
        {
            TRSNode in_node = new TRSNode("BAS_View_Checklist_In");
            TRSNode out_node = new TRSNode("BAS_View_Checklist_Out");
            TRSNode list_item;

            int i;

            try
            {
                if (LotID != "" && LOT.GetString("LOT_ID") == "")
                {
                    ViewLotInfo(LotID, true);
                }
                if (ResourceID != "" && RESOURCE.GetString("RES_ID") == "")
                {
                    ViewResourceInfo(ResourceID, true);
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_CREATE;
                in_node.AddString("CHKLIST_ID", MPCF.Trim(cdvChecklistID.Text));
                in_node.AddString("REL_KEY", CHKLIST.GetString("REL_KEY"));
                in_node.AddString("LOT_ID", LOT.GetString("LOT_ID"));
                in_node.AddString("RES_ID", RESOURCE.GetString("RES_ID"));

                if (chkCompleteFlag.Checked == true) in_node.AddChar("COMPLETE_FLAG", 'Y');

                if (CHKLIST.GetChar("LOT_OR_RES_FLAG") == 'L')
                {
                    in_node.AddString("BASE_OBJ_ID", LOT.GetString("LOT_ID"));
                    in_node.AddInt("BASE_OBJ_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                }
                else if (CHKLIST.GetChar("LOT_OR_RES_FLAG") == 'R')
                {
                    in_node.AddString("BASE_OBJ_ID", RESOURCE.GetString("RES_ID"));
                    in_node.AddInt("BASE_OBJ_HIST_SEQ", RESOURCE.GetInt("LAST_ACTIVE_HIST_SEQ"));
                }

                //KeyPrompt
                for (i = 0; i < 5; i++)
                {
                    in_node.AddString(string.Format("KEY_{0}_VALUE", i+1), spdKeyPrompt_Sheet1.GetText(i, (int)ColKEY.Value));
                    in_node.AddString(string.Format("KEY_{0}_VALUE", i+6), spdKeyPrompt_Sheet1.GetText(i, (int)ColKEY.Value2));
                }
                //Answer
                for (i = 0; i < spdQueryAnswer_Sheet1.RowCount; i++)
                {
                    if (spdQueryAnswer_Sheet1.Cells[i, (int)ColQUERY.Check].Value == null ||
                        Convert.ToBoolean(spdQueryAnswer_Sheet1.Cells[i, (int)ColQUERY.Check].Value) == false)
                    {
                        //continue;
                    }

                    list_item = in_node.AddNode("QUERY_LIST");
                    list_item.AddString("QUERY_ID", MPCF.Trim(spdQueryAnswer_Sheet1.GetText(i, (int)ColQUERY.ID)));
                    list_item.AddString("ANSWER", MPCF.Trim(spdQueryAnswer_Sheet1.GetText(i, (int)ColQUERY.Answer)));
                }

                if (MPCR.CallService("BAS", "BAS_Update_Checklist_Answer", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 답변 수정
        /// </summary>
        /// <param name="iHistSeq"></param>
        /// <returns></returns>
        public virtual bool UpdateAnswer(int iHistSeq)
        {
            TRSNode in_node = new TRSNode("BAS_View_Checklist_In");
            TRSNode out_node = new TRSNode("BAS_View_Checklist_Out");
            TRSNode list_item;

            int i;

            try
            {
                if (LotID != "" && LOT.GetString("LOT_ID") == "")
                {
                    ViewLotInfo(LotID, true);
                }
                if (ResourceID != "" && RESOURCE.GetString("RES_ID") == "")
                {
                    ViewResourceInfo(ResourceID, true);
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_UPDATE;
                in_node.AddString("CHKLIST_ID", MPCF.Trim(cdvChecklistID.Text));
                in_node.AddInt("HIST_SEQ", iHistSeq);
                in_node.AddString("LOT_ID", LOT.GetString("LOT_ID"));
                in_node.AddString("RES_ID", RESOURCE.GetString("RES_ID"));
                in_node.AddString("REL_KEY", CHKLIST.GetString("REL_KEY"));

                if (chkCompleteFlag.Checked == true) in_node.AddChar("COMPLETE_FLAG", 'Y');

                if (CHKLIST.GetChar("LOT_OR_RES_FLAG") == 'L')
                {
                    in_node.AddString("BASE_OBJ_ID", LOT.GetString("LOT_ID"));
                    in_node.AddInt("BASE_OBJ_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                }
                else if (CHKLIST.GetChar("LOT_OR_RES_FLAG") == 'R')
                {
                    in_node.AddString("BASE_OBJ_ID", RESOURCE.GetString("RES_ID"));
                    in_node.AddInt("BASE_OBJ_HIST_SEQ", RESOURCE.GetInt("LAST_ACTIVE_HIST_SEQ"));
                }
                else
                {
                    in_node.AddString("BASE_OBJ_ID", CHKLIST.GetString("RES_ID"));
                    in_node.AddInt("BASE_OBJ_HIST_SEQ", CHKLIST.GetInt("LAST_ACTIVE_HIST_SEQ"));
                }

                //KeyPrompt
                for (i = 0; i < 5; i++)
                {
                    in_node.AddString(string.Format("KEY_{0}_VALUE", i + 1), spdKeyPrompt_Sheet1.GetText(i, (int)ColKEY.Value));
                    in_node.AddString(string.Format("KEY_{0}_VALUE", i + 6), spdKeyPrompt_Sheet1.GetText(i, (int)ColKEY.Value2));
                }
                //Answer
                for (i = 0; i < spdQueryAnswer_Sheet1.RowCount; i++)
                {
                    //if (spdQueryAnswer_Sheet1.Cells[i, (int)ColQUERY.Check].Value == null ||
                    //    Convert.ToBoolean(spdQueryAnswer_Sheet1.Cells[i, (int)ColQUERY.Check].Value) == false)
                    //{
                    //    continue;
                    //}

                    list_item = in_node.AddNode("QUERY_LIST");
                    list_item.AddString("QUERY_ID", MPCF.Trim(spdQueryAnswer_Sheet1.GetText(i, (int)ColQUERY.ID)));
                    list_item.AddString("ANSWER", MPCF.Trim(spdQueryAnswer_Sheet1.GetText(i, (int)ColQUERY.Answer)));
                }

                if (MPCR.CallService("BAS", "BAS_Update_Checklist_Answer", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 답변 삭제
        /// </summary>
        /// <returns></returns>
        public virtual bool DeleteAnswer()
        {
            TRSNode in_node = new TRSNode("BAS_View_Checklist_In");
            TRSNode out_node = new TRSNode("BAS_View_Checklist_Out");

            int iHistSeq;

            try
            {
                iHistSeq = MPCF.ToInt(lisCheckHistory.SelectedItems[0].SubItems[(int)ColHISTORY.Seq].Text);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_DELETE;
                in_node.AddString("CHKLIST_ID", MPCF.Trim(cdvChecklistID.Text));
                in_node.AddInt("HIST_SEQ", iHistSeq);

                if (MPCR.CallService("BAS", "BAS_Update_Checklist_Answer", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        public virtual bool ExcelExport()
        {
            try
            {
                string sCond = string.Empty;

                sCond = "Checklist : " + cdvChecklistID.Text;

                if (lisCheckHistory.Visible)
                {
                    return MPCF.ExportToExcel(lisCheckHistory, this.Text, sCond);
                }
                else
                {
                    return MPCF.ExportToExcel(spdQueryAnswer, this.Text, sCond);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 체크리스트 타입 목록 조회
        /// </summary>
        /// <returns></returns>
        public virtual bool ViewChecklistType_list()
        {
            cdvChecklistType.Init();
            MPCF.InitListView(cdvChecklistType.GetListView);
            cdvChecklistType.Columns.Add("CheckListType", 50, HorizontalAlignment.Left);
            cdvChecklistType.Columns.Add("Desc", 50, HorizontalAlignment.Left);
            cdvChecklistType.SelectedSubItemIndex = 0;

            return BASLIST.ViewGCMDataList(cdvChecklistType.GetListView, '1', "CHECK_LIST_TYPE");
        }

        /// <summary>
        /// 체크리스트 목록 조회
        /// </summary>
        /// <returns></returns>
        public virtual bool ViewChecklist_list()
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

            return BASLIST.ViewChecklistList(cdvChecklistID.GetListView, '2', MPCF.Trim(cdvChecklistType.Text));
        }

        #endregion

        private void frmCheckListTranMain_Activated(object sender, EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    b_load_flag = true;
                    MPCF.FieldClear(this);
                    if (InitForm() == false) this.Close();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvChecklistType_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                ViewChecklistType_list();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvChecklistID_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                ViewChecklist_list();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvChecklistID, 1) == false) return;

                ViewMain(MPCF.Trim(cdvChecklistID.Text));
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProcessMain() == true)
                {
                    ClearData("1");
                    ViewMain(MPCF.Trim(cdvChecklistID.Text));
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                if (DeleteAnswer() == true)
                {
                    ClearData("1");
                    ViewMain(MPCF.Trim(cdvChecklistID.Text));
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void lisCheckHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int iHistSeq = 0;

                ClearData("3");

                if (lisCheckHistory.SelectedIndices != null && lisCheckHistory.SelectedIndices.Count > 0)
                {
                    if (MPCF.Trim(cdvChecklistID.Text) != "" &&
                        MPCF.Trim(lisCheckHistory.SelectedItems[0].SubItems[(int)ColHISTORY.Seq].Text) != "")
                    {
                        iHistSeq = MPCF.ToInt(lisCheckHistory.SelectedItems[0].SubItems[(int)ColHISTORY.Seq].Text);
                        ViewHistory(MPCF.Trim(cdvChecklistID.Text), iHistSeq);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdKeyPrompt_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                string table_name = null;

                if (e.Column == (int)ColKEY.ValueBtn || e.Column == (int)ColKEY.ValueBtn2)
                {
                    table_name = MPCF.Trim(spdKeyPrompt_Sheet1.Cells[e.Row, e.Column].Tag);
                    if (table_name != "")
                    {
                        cdvTableList.Init();
                        MPCF.InitListView(cdvTableList.GetListView);
                        cdvTableList.Columns.Add("Code", 50, HorizontalAlignment.Left);
                        cdvTableList.Columns.Add("Desc", 50, HorizontalAlignment.Left);
                        BASLIST.ViewGCMDataList(cdvTableList.GetListView, '1', table_name);

                        if (cdvTableList.ShowPopupList(e.Row, e.Column) == false)
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvTableList_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            spdKeyPrompt_Sheet1.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
        }

        private void spdQueryAnswer_EditModeOff(object sender, EventArgs e)
        {
            int iRow, iCol;
            iRow = spdQueryAnswer_Sheet1.ActiveRowIndex;
            iCol = spdQueryAnswer_Sheet1.ActiveColumnIndex;
            if (iRow >= 0 && iCol == (int)ColQUERY.Answer)
            {
                spdQueryAnswer_Sheet1.Cells[iRow, (int)ColQUERY.Check].Value = true;
                //if (spdQueryAnswer_Sheet1.Cells[iRow, (int)ColQUERY.Check].CellType is FarPoint.Win.Spread.CellType.CheckBoxCellType)
                //{
                //}
            }
        }

        private void spdQueryAnswer_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                string table_name = null;

                if (e.Column == (int)ColQUERY.Button)
                {
                    table_name = MPCF.Trim(spdQueryAnswer_Sheet1.Cells[e.Row, e.Column].Tag);
                    if (table_name != "")
                    {
                        cdvAnswerList.Init();
                        MPCF.InitListView(cdvAnswerList.GetListView);
                        cdvAnswerList.Columns.Add("Code", 50, HorizontalAlignment.Left);
                        cdvAnswerList.Columns.Add("Desc", 50, HorizontalAlignment.Left);
                        BASLIST.ViewGCMDataList(cdvAnswerList.GetListView, '1', table_name);

                        if (cdvAnswerList.ShowPopupList(e.Row, e.Column) == false)
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvAnswerList_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            spdQueryAnswer_Sheet1.Cells[e.Row, (int)ColQUERY.Check].Value = true;
            spdQueryAnswer_Sheet1.Cells[e.Row, (int)ColQUERY.Answer].Value = e.SelectedItem.SubItems[0].Text;
        }

        private void cdvChecklistID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            ClearData("1");
            if (MPCF.Trim(cdvChecklistID.Text) != "")
            {
                ViewCheckList(MPCF.Trim(cdvChecklistID.Text));
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExcelExport();
        }

        private void cdvChecklistType_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            ClearData("1");
            MPCF.FieldClear(cdvChecklistID);
            txtDesc.Text = "";
        }

        private void cdvChecklistType_TextBoxTextChanged(object sender, EventArgs e)
        {
            ClearData("1");
            MPCF.FieldClear(cdvChecklistID);
            txtDesc.Text = "";
        }

        private void txtBaseItemId_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtBaseItemId.Text = MPCF.Trim(txtBaseItemId.Text);
            if (e.KeyChar == (char)13 && txtBaseItemId.Text != "")
            {
                if (CHKLIST == null) return;

                if (CHKLIST.GetChar("LOT_OR_RES_FLAG") == 'L')
                {
                    if (ViewLotInfo(txtBaseItemId.Text) == false)
                    {
                        txtBaseItemId.SelectAll();
                    }
                }
                else if (CHKLIST.GetChar("LOT_OR_RES_FLAG") == 'R')
                {
                    if (ViewResourceInfo(txtBaseItemId.Text) == false)
                    {
                        txtBaseItemId.SelectAll();
                    }
                }
            }
        }


    }
}
