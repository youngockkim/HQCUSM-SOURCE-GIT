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
    public partial class frmWIPViewBinHistory : ViewForm01
    {
        public frmWIPViewBinHistory()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;

        #endregion

        #region " Function Definition "

        private bool ViewBinHistory()
        {
            TRSNode in_node = new TRSNode("VIEW_BIN_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_BIN_HISTORY_OUT");
            List<TRSNode> hist_list;
            int i;
            int i_row;
            int i_col;

            MPCF.ClearList(spdHistory);
            MPCF.ClearList(spdBinGrade);
            MPCF.ClearList(spdSUT);
            MPCF.ClearList(spdSG);
            MPCF.ClearList(spdSGD);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
            in_node.AddString("FROM_TIME", MPCF.FromDate(dtpFrom));
            in_node.AddString("TO_TIME", MPCF.ToDate(dtpTo));
            in_node.AddChar("INCLUDE_DEL_HIST", chkIncludeDelHistory.Checked == true ? 'Y' : ' ');

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Bin_History", in_node, ref out_node) == false)
                {
                    return false;
                }

                hist_list = out_node.GetList("HIST_LIST");
                for (i = 0; i < hist_list.Count; i++)
                {
                    i_row = spdHistory.ActiveSheet.RowCount;
                    spdHistory.ActiveSheet.RowCount++;

                    if (hist_list[i].GetChar("BIN_RESULT_FLAG") == 'F')
                    {
                        spdHistory.ActiveSheet.Rows[i_row].Font = new Font(spdHistory.Font, FontStyle.Bold);
                    }

                    if (hist_list[i].GetChar("LOW_YIELD_FLAG") == 'Y')
                    {
                        spdHistory.ActiveSheet.Rows[i_row].ForeColor = Color.Red;
                    }
                    else if (hist_list[i].GetChar("HIST_DEL_FLAG") == 'Y')
                    {
                        spdHistory.ActiveSheet.Rows[i_row].ForeColor = Color.Magenta;
                    }

                    i_col = 0;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetInt("HIST_SEQ"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetInt("BIN_COL_SEQ"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = MPCF.MakeDateFormat(hist_list[i].GetString("TRAN_TIME")); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("BIN_ID"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetInt("BIN_VERSION"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("BIN_UNIT"); i_col++;

                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetChar("COL_BASE_FLAG"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetChar("BIN_RESULT_FLAG"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetChar("LOW_YIELD_FLAG"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetDouble("TOT_YIELD_BASE_QTY"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetDouble("TOT_YIELD"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetChar("YIELD_CALC_TYPE"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("BASE_LYL"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("BASE_UYL"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetDouble("TOT_INPUT_QTY"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetDouble("TOT_PASS_QTY"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetDouble("TOT_FAIL_QTY"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_ALARM_ID"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("MAT_ID"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetInt("MAT_VER"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("FLOW"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetInt("FLOW_SEQ_NUM"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("OPER"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("RES_ID"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetDouble("QTY_1"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetDouble("QTY_2"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetDouble("QTY_3"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_1"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_2"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_3"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_4"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_5"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_6"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_7"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_8"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_9"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_10"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_11"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_12"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_13"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_14"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_15"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_16"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_17"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_18"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_19"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_20"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_USER_ID"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_COMMENT_1"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_COMMENT_2"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_COMMENT_3"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("BIN_COMMENT_1"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("BIN_COMMENT_2"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("BIN_COMMENT_3"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetChar("HIST_DEL_FLAG"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = MPCF.MakeDateFormat(hist_list[i].GetString("HIST_DEL_TIME")); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("HIST_DEL_USER_ID"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("HIST_DEL_COMMENT"); i_col++;
                    spdHistory.ActiveSheet.Cells[i_row, i_col].Value = MPCF.MakeDateFormat(hist_list[i].GetString("SYS_TRAN_TIME")); i_col++;
                }

                in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                in_node.SetInt("NEXT_BIN_COL_SEQ", out_node.GetInt("NEXT_BIN_COL_SEQ"));
            } while (in_node.GetInt("NEXT_HIST_SEQ") > 0 || in_node.GetInt("NEXT_BIN_COL_SEQ") > 0);

            MPCF.FitColumnHeader(spdHistory);
            return true;
        }

        private bool ViewBinHistoryGrade(int i_hist_seq, int i_bin_col_seq)
        {
            TRSNode in_node = new TRSNode("VIEW_BIN_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_BIN_HISTORY_OUT");
            List<TRSNode> hist_list;
            int i;
            int i_row;
            int i_col;

            MPCF.ClearList(spdBinGrade);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
            in_node.AddInt("HIST_SEQ", i_hist_seq);
            in_node.AddInt("BIN_COL_SEQ", i_bin_col_seq);
            in_node.AddChar("INCLUDE_DEL_HIST", chkIncludeDelHistory.Checked == true ? 'Y' : ' ');

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Bin_History_Grade", in_node, ref out_node) == false)
                {
                    return false;
                }

                hist_list = out_node.GetList("HIST_LIST");
                for (i = 0; i < hist_list.Count; i++)
                {
                    i_row = spdBinGrade.ActiveSheet.RowCount;
                    spdBinGrade.ActiveSheet.RowCount++;

                    if (hist_list[i].GetChar("LOW_YIELD_FLAG") == 'Y')
                    {
                        spdBinGrade.ActiveSheet.Rows[i_row].ForeColor = Color.Red;
                    }

                    i_col = 0;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetInt("BIN_SEQ").ToString("000"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("BIN_PROMPT"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("BIN_PROMPT_DESC"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetDouble("BIN_QTY"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetChar("BIN_TYPE"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetChar("LOW_YIELD_FLAG"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("CHECK_RESULT"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetChar("LOGICAL_BIN_FLAG"); i_col++;

                    if (hist_list[i].GetInt("SPLIT_BY_BIN_SEQ") > 0)
                    {
                        spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetInt("SPLIT_BY_BIN_SEQ").ToString("000"); i_col++;
                    }
                    else
                    {
                        i_col++;
                    }

                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("FAIL_REASON_CODE"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetChar("KEEP_LOT_QTY_FAIL"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("CHILD_LOT_ID"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("CHILD_MAT_ID"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetInt("CHILD_MAT_VER"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("CHILD_FLOW"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetInt("CHILD_FLOW_SEQ_NUM"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("CHILD_OPER"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetDouble("CHILD_QTY_1"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetDouble("CHILD_QTY_2"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetDouble("CHILD_QTY_3"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetChar("CHILD_LOT_TYPE"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetChar("CHILD_LOT_PRIORITY"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("CHILD_CREATE_CODE"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("CHILD_OWNER_CODE"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("CHILD_CRR_ID"); i_col++;

                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CODE"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_KEY_CODE_1"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_KEY_CODE_2"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_KEY_CODE_3"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_COMMENT_1"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_COMMENT_2"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_COMMENT_3"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("BIN_COMMENT_1"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("BIN_COMMENT_2"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("BIN_COMMENT_3"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetChar("HIST_DEL_FLAG"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = MPCF.MakeDateFormat(hist_list[i].GetString("HIST_DEL_TIME")); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("HIST_DEL_USER_ID"); i_col++;
                    spdBinGrade.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("HIST_DEL_COMMENT"); i_col++;
                }

                in_node.SetInt("NEXT_BIN_SEQ", out_node.GetInt("NEXT_BIN_SEQ"));
            } while (in_node.GetInt("NEXT_BIN_SEQ") > 0);

            MPCF.FitColumnHeader(spdBinGrade);
            return true;
        }

        private bool ViewBinHistorySublotGrade(int i_hist_seq, int i_bin_col_seq)
        {
            TRSNode in_node = new TRSNode("VIEW_BIN_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_BIN_HISTORY_OUT");
            List<TRSNode> hist_list;
            int i;
            int i_row;
            int i_col;

            string s_prev_sublot_id;

            MPCF.ClearList(spdSG);
            MPCF.ClearList(spdSGD);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
            in_node.AddInt("HIST_SEQ", i_hist_seq);
            in_node.AddInt("BIN_COL_SEQ", i_bin_col_seq);
            in_node.AddChar("INCLUDE_DEL_HIST", chkIncludeDelHistory.Checked == true ? 'Y' : ' ');

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Bin_History_Sublot_Grade", in_node, ref out_node) == false)
                {
                    return false;
                }

                s_prev_sublot_id = "";
                hist_list = out_node.GetList("HIST_LIST");
                for (i = 0; i < hist_list.Count; i++)
                {
                    i_row = spdSGD.ActiveSheet.RowCount;
                    spdSGD.ActiveSheet.RowCount++;

                    if (hist_list[i].GetChar("LOW_YIELD_FLAG") == 'Y')
                    {
                        spdSGD.ActiveSheet.Rows[i_row].ForeColor = Color.Red;
                    }

                    i_col = 0;
                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("SUBLOT_ID"); i_col++;
                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetInt("HIST_SEQ"); i_col++;
                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetInt("BIN_SEQ").ToString("000"); i_col++;
                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("BIN_PROMPT"); i_col++;
                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("BIN_PROMPT_DESC"); i_col++;
                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetDouble("BIN_QTY"); i_col++;
                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetChar("BIN_TYPE"); i_col++;
                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetChar("LOW_YIELD_FLAG"); i_col++;
                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("CHECK_RESULT"); i_col++;

                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CODE"); i_col++;
                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_KEY_CODE_1"); i_col++;
                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_KEY_CODE_2"); i_col++;
                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_KEY_CODE_3"); i_col++;
                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_COMMENT_1"); i_col++;
                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_COMMENT_2"); i_col++;
                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_COMMENT_3"); i_col++;
                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("BIN_COMMENT_1"); i_col++;
                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("BIN_COMMENT_2"); i_col++;
                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("BIN_COMMENT_3"); i_col++;
                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetChar("HIST_DEL_FLAG"); i_col++;
                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = MPCF.MakeDateFormat(hist_list[i].GetString("HIST_DEL_TIME")); i_col++;
                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("HIST_DEL_USER_ID"); i_col++;
                    spdSGD.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("HIST_DEL_COMMENT"); i_col++;

                    if (hist_list[i].GetChar("LOGICAL_BIN_FLAG") == 'Y') continue;


                    i_row = spdSG.ActiveSheet.RowCount - 1;
                    if (s_prev_sublot_id != hist_list[i].GetString("SUBLOT_ID"))
                    {
                        s_prev_sublot_id = hist_list[i].GetString("SUBLOT_ID");

                        i_row = spdSG.ActiveSheet.RowCount;
                        spdSG.ActiveSheet.RowCount++;

                        spdSG.ActiveSheet.Cells[i_row, 0].Value = hist_list[i].GetString("SUBLOT_ID");
                    }

                    for (i_col = 4; i_col < spdSG.ActiveSheet.ColumnCount; i_col++)
                    {
                        if (MPCF.ToInt(spdSG.ActiveSheet.ColumnHeader.Cells[0, i_col].Tag) == hist_list[i].GetInt("BIN_SEQ"))
                        {
                            break;
                        }
                    }
                    if (i_col >= spdSG.ActiveSheet.ColumnCount)
                    {
                        AddColumnForUnit2(hist_list[i]);
                    }

                    spdSG.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetDouble("BIN_QTY");
                    if (hist_list[i].GetChar("LOW_YIELD_FLAG") == 'Y')
                    {
                        spdSG.ActiveSheet.Cells[i_row, i_col].Font = new Font(spdSG.Font, FontStyle.Bold);
                        spdSG.ActiveSheet.Cells[i_row, i_col].ForeColor = Color.Red;
                    }
                }

                in_node.SetInt("NEXT_BIN_SEQ", out_node.GetInt("NEXT_BIN_SEQ"));
            } while (in_node.GetInt("NEXT_BIN_SEQ") > 0);

            MPCF.FitColumnHeader(spdSGD);

            spdSG.ActiveSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            for (i = 0; i < spdSG.ActiveSheet.RowCount; i++)
            {
                spdSG.ActiveSheet.Cells[i, 1].Formula = "SUM(RC[1]:RC[2])";
            }//end for

            i_row = spdSG.ActiveSheet.RowCount;
            spdSG.ActiveSheet.RowCount++;
            for (i = 1; i < spdSG.ActiveSheet.ColumnCount; i++)
            {
                spdSG.ActiveSheet.Cells[i_row, i].Formula = "SUM(R[" + (i_row * -1).ToString() + "]C:R[-1]C)";
            }//end for
            spdSG.ActiveSheet.Cells[i_row, 0].Value = MPCF.FindLanguage("Total", CAPTION_TYPE.LABEL);
            spdSG.ActiveSheet.Rows[i_row].BackColor = Color.Moccasin;
            spdSG.ActiveSheet.FrozenTrailingRowCount = 1;

            double d_pass_bin_qty;
            double d_fail_bin_qty;
            double d_bin_qty;

            for (i_row = 0; i_row < spdSG.ActiveSheet.RowCount - 1; i_row++)
            {
                d_pass_bin_qty = d_fail_bin_qty = 0;

                for (i_col = 4; i_col < spdSG.ActiveSheet.ColumnCount; i_col++)
                {
                    d_bin_qty = MPCF.ToDbl(spdSG.ActiveSheet.Cells[i_row, i_col].Value);

                    if (MPCF.Trim(spdSG.ActiveSheet.Columns[i_col].Tag) == "P")
                    {
                        d_pass_bin_qty += d_bin_qty;
                    }
                    else if (MPCF.Trim(spdSG.ActiveSheet.Columns[i_col].Tag) == "F")
                    {
                        d_fail_bin_qty += d_bin_qty;
                    }
                }

                spdSG.ActiveSheet.Cells[i_row, 2].Value = d_pass_bin_qty;
                spdSG.ActiveSheet.Cells[i_row, 3].Value = d_fail_bin_qty;
            }

            MPCF.FitColumnHeader(spdSG);

            return true;
        }

        private bool ViewBinHistorySublotUnitTotal(int i_hist_seq, int i_bin_col_seq)
        {
            TRSNode in_node = new TRSNode("VIEW_BIN_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_BIN_HISTORY_OUT");
            List<TRSNode> hist_list;
            int i;
            int i_row;
            int i_col;

            MPCF.ClearList(spdSUT);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
            in_node.AddInt("HIST_SEQ", i_hist_seq);
            in_node.AddInt("BIN_COL_SEQ", i_bin_col_seq);
            in_node.AddChar("INCLUDE_DEL_HIST", chkIncludeDelHistory.Checked == true ? 'Y' : ' ');

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Bin_History_Sublot_Unit_Total", in_node, ref out_node) == false)
                {
                    return false;
                }

                hist_list = out_node.GetList("HIST_LIST");
                for (i = 0; i < hist_list.Count; i++)
                {
                    i_row = spdSUT.ActiveSheet.RowCount;
                    spdSUT.ActiveSheet.RowCount++;

                    if (hist_list[i].GetChar("LOW_YIELD_FLAG") == 'Y')
                    {
                        spdSUT.ActiveSheet.Rows[i_row].ForeColor = Color.Red;
                    }

                    i_col = 0;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("SUBLOT_ID"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetInt("HIST_SEQ"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = MPCF.MakeDateFormat(hist_list[i].GetString("TRAN_TIME")); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetChar("LOW_YIELD_FLAG"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetDouble("TOT_YIELD_BASE_QTY"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetDouble("TOT_YIELD"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetChar("YIELD_CALC_TYPE"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("BASE_LYL"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("BASE_UYL"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetDouble("TOT_INPUT_QTY"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetDouble("TOT_PASS_QTY"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetDouble("TOT_FAIL_QTY"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_ALARM_ID"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("MAT_ID"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetInt("MAT_VER"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("FLOW"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetInt("FLOW_SEQ_NUM"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("OPER"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("RES_ID"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetDouble("QTY_2"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetDouble("QTY_3"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_1"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_2"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_3"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_4"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_5"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_6"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_7"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_8"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_9"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_10"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_11"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_12"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_13"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_14"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_15"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_16"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_17"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_18"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_19"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_CMF_20"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_USER_ID"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_COMMENT_1"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_COMMENT_2"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("TRAN_COMMENT_3"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("BIN_COMMENT_1"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("BIN_COMMENT_2"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("BIN_COMMENT_3"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetChar("HIST_DEL_FLAG"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = MPCF.MakeDateFormat(hist_list[i].GetString("HIST_DEL_TIME")); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("HIST_DEL_USER_ID"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = hist_list[i].GetString("HIST_DEL_COMMENT"); i_col++;
                    spdSUT.ActiveSheet.Cells[i_row, i_col].Value = MPCF.MakeDateFormat(hist_list[i].GetString("SYS_TRAN_TIME")); i_col++;
                }

                in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                in_node.SetInt("NEXT_BIN_COL_SEQ", out_node.GetInt("NEXT_BIN_COL_SEQ"));
            } while (in_node.GetInt("NEXT_HIST_SEQ") > 0 || in_node.GetInt("NEXT_BIN_COL_SEQ") > 0);

            MPCF.FitColumnHeader(spdSUT);
            return true;
        }

        private void AddColumnForUnit2(TRSNode hist_node)
        {
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType;
            int i_col;

            i_col = spdSG.ActiveSheet.ColumnCount;
            spdSG.ActiveSheet.ColumnCount++;

            spdSG.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = hist_node.GetString("BIN_PROMPT");
            spdSG.ActiveSheet.ColumnHeader.Cells[0, i_col].Tag = hist_node.GetInt("BIN_SEQ");

            if (hist_node.GetChar("BIN_TYPE") == 'P')
            {
                spdSG.ActiveSheet.ColumnHeader.Cells[0, i_col].BackColor = Color.PaleGreen;
                spdSG.ActiveSheet.ColumnHeader.Cells[0, i_col].VisualStyles = FarPoint.Win.VisualStyles.Off;
            }
            else if (hist_node.GetChar("BIN_TYPE") == 'F')
            {
                spdSG.ActiveSheet.ColumnHeader.Cells[0, i_col].BackColor = Color.Linen;
                spdSG.ActiveSheet.ColumnHeader.Cells[0, i_col].VisualStyles = FarPoint.Win.VisualStyles.Off;
            }

            spdSG.ActiveSheet.Columns[i_col].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            spdSG.ActiveSheet.Columns[i_col].Locked = true;
            numberCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
            numberCellType.DecimalPlaces = 0;
            numberCellType.MaximumValue = 10000000D;
            numberCellType.MinimumValue = 0D;
            numberCellType.ShowSeparator = true;
            spdSG.ActiveSheet.Columns[i_col].CellType = numberCellType;
            spdSG.ActiveSheet.Columns[i_col].Tag = hist_node.GetChar("BIN_TYPE");
        }


        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.txtLotID;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion

        private void frmWIPViewBinHistory_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                dtpTo.Value = DateTime.Today;
                dtpFrom.Value = dtpTo.Value.AddDays(-7);

                tabBinHistory.TabPages.Remove(tbpSublotUnitTotal);
                tabBinHistory.TabPages.Remove(tbpSublotGrade);
                tabBinHistory.TabPages.Remove(tbpSublotGradeDetail);

                MPCF.FieldClear(this);
                MPCF.ClearList(spdHistory);
                MPCF.ClearList(spdBinGrade);
                MPCF.ClearList(spdSUT);
                MPCF.ClearList(spdSG);
                MPCF.ClearList(spdSGD);

                /* 2013.06.12. Aiden. MPGV.gsCurrentLot_ID = null 인 경우 에러발생하는 문제 해결 */
                if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                {
                    txtLotID.Text = MPGV.gsCurrentLot_ID;
                    btnView.PerformClick();
                }

                b_load_flag = true;
            }
        }

        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            if (MPCF.CheckValue(txtLotID, 1) == false) return;
            if (ViewBinHistory() == false) return;
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Lot ID : " + MPCF.Trim(txtLotID.Text) + "\r";
            sCond = sCond + "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));

            if (tabBinHistory.SelectedTab == tbpBinGrade)
            {
                MPCF.ExportToExcel(spdBinGrade, this.Text, sCond);
            }
            else if (tabBinHistory.SelectedTab == tbpSublotUnitTotal)
            {
                MPCF.ExportToExcel(spdSUT, this.Text, sCond);
            }
            else if (tabBinHistory.SelectedTab == tbpSublotGrade)
            {
                MPCF.ExportToExcel(spdSG, this.Text, sCond);
            }
            else if (tabBinHistory.SelectedTab == tbpSublotGradeDetail)
            {
                MPCF.ExportToExcel(spdSGD, this.Text, sCond);
            }
        }

        private void spdHistory_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            int i_hist_seq;
            int i_bin_col_seq;
            char c_col_base_flag;

            if (e.RowHeader == true) return;
            if (e.ColumnHeader == true) return;

            i_hist_seq = MPCF.ToInt(spdHistory.ActiveSheet.Cells[e.Row, 0].Value);
            i_bin_col_seq = MPCF.ToInt(spdHistory.ActiveSheet.Cells[e.Row, 1].Value);
            c_col_base_flag = MPCF.ToChar(spdHistory.ActiveSheet.Cells[e.Row, 6].Value);

            if (ViewBinHistoryGrade(i_hist_seq, i_bin_col_seq) == false) return;
            
            if (c_col_base_flag == 'S')
            {
                tbpBinGrade.Text = MPCF.FindLanguage("BIN Grade Total", CAPTION_TYPE.LABEL);

                if (tabBinHistory.TabPages.Contains(tbpSublotUnitTotal) == false)
                {
                    tabBinHistory.TabPages.Add(tbpSublotUnitTotal);
                }
                if (tabBinHistory.TabPages.Contains(tbpSublotGrade) == false)
                {
                    tabBinHistory.TabPages.Add(tbpSublotGrade);
                }
                if (tabBinHistory.TabPages.Contains(tbpSublotGradeDetail) == false)
                {
                    tabBinHistory.TabPages.Add(tbpSublotGradeDetail);
                }

                if (ViewBinHistorySublotUnitTotal(i_hist_seq, i_bin_col_seq) == false) return;
                if (ViewBinHistorySublotGrade(i_hist_seq, i_bin_col_seq) == false) return;
            }
            else
            {
                tbpBinGrade.Text = MPCF.FindLanguage("BIN Grade", CAPTION_TYPE.LABEL);

                if (tabBinHistory.TabPages.Contains(tbpSublotUnitTotal) == true)
                {
                    tabBinHistory.TabPages.Remove(tbpSublotUnitTotal);
                }
                if (tabBinHistory.TabPages.Contains(tbpSublotGrade) == true)
                {
                    tabBinHistory.TabPages.Remove(tbpSublotGrade);
                }
                if (tabBinHistory.TabPages.Contains(tbpSublotGradeDetail) == true)
                {
                    tabBinHistory.TabPages.Remove(tbpSublotGradeDetail);
                }
            }

        }




    }
}
