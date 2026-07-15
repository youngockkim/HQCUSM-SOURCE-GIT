using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.MsgHandler;
using Miracom.TRSCore;

namespace Miracom.UTLCore
{
    class clsGenerateLotDataRunner
    {
        private int mi_thread_seq;
        private bool mb_stop_flag;
        private bool mb_error_ignore_flag;
        private bool mb_last_flow_oper_flag;
        private DateTime md_start_date;
        private DateTime md_end_date;

        private frmUTLGenerateLotData mf_FORM;

        public clsGenerateLotDataRunner()
        {
            mb_stop_flag = false;
            mb_last_flow_oper_flag = false;
            mi_thread_seq = 0;
            mb_error_ignore_flag = false;
        }

        public void setThread(frmUTLGenerateLotData f, int i_thread_seq, bool b_ignore_error, DateTime d_start, DateTime d_end)
        {
            mf_FORM = f;
            mi_thread_seq = i_thread_seq;
            mb_error_ignore_flag = b_ignore_error;
            md_start_date = d_start;
            md_end_date = d_end;
        }

        public void setStopFlag(bool b_stop)
        {
            mb_stop_flag = b_stop;
        }

        public void ProcessTest()
        {
            TRSNode LOT;
            TRSNode OPER;
            TRSNode ORDER;
            TRSNode ORDERLIST;
            TRSNode EDC;
            List<TRSNode> orderList;
            Random rd = new Random();
            int i_loop_count;
            int i_proc_order_count;
            string s_order_id;
            string s_lot_id;
            string s_res_id;

            try
            {
                do
                {
                    LOT = new TRSNode("LOT_INFO");
                    OPER = new TRSNode("OPER_INFO");
                    EDC = new TRSNode("EDC_INFO");
                    ORDER = new TRSNode("ORDER_INFO");
                    ORDERLIST = new TRSNode("ORDER_LIST_INFO");

                    if (ViewOrderList(md_start_date.ToString("yyyyMMdd"), ORDERLIST) == false) return;

                    orderList = ORDERLIST.GetList("ORD_LIST");
                    if (orderList.Count < 1)
                    {
                        orderList = ORDERLIST.GetList("ORDER_LIST");
                    }

                    i_proc_order_count = 0;

                    foreach (TRSNode ordNode in orderList)
                    {
                        i_proc_order_count++;
                        mf_FORM.setProgress((i_proc_order_count / orderList.Count) * 100);

                        s_order_id = ordNode.GetString("ORDER_ID");
                        if (ViewOrder(s_order_id, ORDER) == false) continue;

                        while ((ORDER.GetDouble("ORD_QTY") - ORDER.GetDouble("ORD_IN_QTY")) > 0.0005)
                        {
                            mb_last_flow_oper_flag = false;
                            s_lot_id = "";

                            try
                            {
                                if (A01_Create_Lot(s_order_id, ref s_lot_id) == false) break;

                                i_loop_count = rd.Next(0, 20);
                                for (int i_loop_index = 0; i_loop_index < i_loop_count; i_loop_index++)
                                {
                                    if (mb_stop_flag == true) return;

                                    LOT.Init();
                                    OPER.Init();

                                    if (ViewLot(s_lot_id, LOT) == false) break;
                                    if (LOT.GetChar("HOLD_FLAG") == 'Y') break;

                                    if (ViewOperation(LOT.GetString("OPER"), OPER) == false) break;
                                    if (OPER.GetChar("END_OPER_FLAG") == 'Y') break;

                                    s_res_id = GetResource(LOT.GetString("MAT_ID"), LOT.GetInt("MAT_VER"), LOT.GetString("FLOW"), LOT.GetString("OPER"));

                                    // Start
                                    if (LOT.GetChar("START_FLAG") != 'Y' && OPER.GetChar("START_REQUIRE_FLAG") == 'Y')
                                    {
                                        if (A02_Start_Lot(s_lot_id, s_res_id) == false) break;
                                    }

                                    // Split
                                    if (OPER.GetString("OPER_CMF_20") == "S")
                                    {
                                        if (A04_Split_Lot(LOT) == false) break;
                                    }

                                    // EDC
                                    if (OPER.GetString("OPER_CMF_20") == "E")
                                    {
                                        EDC.Init();
                                        if (GetCollectionInfo(LOT, EDC) == true)
                                        {
                                            if (A05_Collect_Lot_Data(LOT, EDC) == false) break;

                                            if (ViewLot(s_lot_id, LOT) == false) break;
                                            if (LOT.GetChar("HOLD_FLAG") == 'Y') break;
                                        }
                                    }

                                    // Loss
                                    if (OPER.GetString("OPER_CMF_20") == "L")
                                    {
                                        if (A07_Loss_Lot(LOT, OPER) == false) break;
                                    }

                                    // End Lot
                                    if (A03_End_Lot(s_lot_id, s_res_id) == false) break;

                                    // end lot process
                                    if (mb_last_flow_oper_flag == true) break;
                                }//end for

                            }
                            catch (Exception ex)
                            {
                                MPCF.ShowMsgBox(ex.Message);
                                return;
                            }
                            finally
                            {
                                if (MPCF.Trim(s_lot_id) != "")
                                {
                                    if (ViewLot(s_lot_id, LOT) == true)
                                    {
                                        ListViewItem itm = new ListViewItem(mi_thread_seq.ToString(), (int)SMALLICON_INDEX.IDX_LOT);
                                        itm.SubItems.Add(s_lot_id);
                                        itm.SubItems.Add(LOT.GetString("OPER"));
                                        itm.SubItems.Add(LOT.GetString("MAT_ID"));

                                        mf_FORM.addLot(itm);
                                    }
                                }
                            }//end finally

                            if (ViewOrder(s_order_id, ORDER) == false) break;
                        }//end while
                    }//end foreach

                    md_start_date = md_start_date.AddDays(1);
                } while (md_start_date <= md_end_date);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
            finally
            {
                mf_FORM.setFinishRunner();
            }
        }

        private bool ViewLot(string s_lot_id, TRSNode LOT)
        {
            TRSNode in_node = new TRSNode("View_Lot_In");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '3';
            in_node.AddString("LOT_ID", MPCF.Trim(s_lot_id));

            if (MessageCaster.CallService("WIP", "WIP_View_Lot", in_node, ref LOT) == false)
            {
                if (mb_error_ignore_flag == false)
                {
                    MessageBox.Show(MPMH.StatusMessage);
                }
                return false;
            }
            if (LOT.StatusValue == MPGC.MP_FAIL_STATUS)
            {
                if (mb_error_ignore_flag == false)
                {
                    MessageBox.Show(LOT.Msg);
                }
                return false;
            }

            return true;
        }

        private bool ViewOperation(string s_oper, TRSNode OPER)
        {
            TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", s_oper);

            if (MessageCaster.CallService("WIP", "WIP_View_Operation", in_node, ref OPER) == false)
            {
                if (mb_error_ignore_flag == false)
                {
                    MessageBox.Show(MPMH.StatusMessage);
                }
                return false;
            }
            if (OPER.StatusValue == MPGC.MP_FAIL_STATUS)
            {
                if (mb_error_ignore_flag == false)
                {
                    MessageBox.Show(OPER.Msg);
                }
                return false;
            }

            return true;
        }

        private bool ViewOrder(string s_order_id, TRSNode ORDER)
        {
            TRSNode in_node = new TRSNode("VIEW_ORDER_IN");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ORDER_ID", s_order_id);

            if (MessageCaster.CallService("ORD", "ORD_View_Order", in_node, ref ORDER) == false)
            {
                if (mb_error_ignore_flag == false)
                {
                    MessageBox.Show(MPMH.StatusMessage);
                }
                return false;
            }
            if (ORDER.StatusValue == MPGC.MP_FAIL_STATUS)
            {
                if (mb_error_ignore_flag == false)
                {
                    MessageBox.Show(ORDER.Msg);
                }
                return false;
            }

            return true;
        }

        private bool ViewOrderList(string s_work_date, TRSNode ORDERLIST)
        {
            TRSNode in_node = new TRSNode("View_Order_List_Detail_In");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("FROM_DATE", s_work_date);
            in_node.AddString("TO_DATE", s_work_date);
            in_node.AddChar("ORD_STATUS_FLAG", ' ');

            if (MessageCaster.CallService("ORD", "ORD_View_Order_List_Detail", in_node, ref ORDERLIST) == false)
            {
                if (mb_error_ignore_flag == false)
                {
                    MessageBox.Show(MPMH.StatusMessage);
                }
                return false;
            }
            if (ORDERLIST.StatusValue == MPGC.MP_FAIL_STATUS)
            {
                if (mb_error_ignore_flag == false)
                {
                    MessageBox.Show(ORDERLIST.Msg);
                }
                return false;
            }

            return true;
        }

        private string GetFirstOper(string s_flow)
        {
            TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_OPERATION_LIST_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '2';
            in_node.AddString("FLOW", s_flow);

            if (MessageCaster.CallService("WIP", "WIP_View_Operation_List", in_node, ref out_node) == false)
            {
                if (mb_error_ignore_flag == false)
                {
                    MessageBox.Show(MPMH.StatusMessage);
                }
                return "";
            }
            if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
            {
                if (mb_error_ignore_flag == false)
                {
                    MessageBox.Show(out_node.Msg);
                }
                return "";
            }

            return out_node.GetList(0)[0].GetString("OPER");
        }

        private string GetResource(string s_mat_id, int i_mat_ver, string s_flow, string s_oper)
        {
            TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_RESOURCE_LIST_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '2';
            in_node.AddString("MAT_ID", s_mat_id);
            in_node.AddInt("MAT_VER", i_mat_ver);
            in_node.AddString("FLOW", s_flow);
            in_node.AddString("OPER", s_oper);

            if (MessageCaster.CallService("RAS", "RAS_View_Resource_List", in_node, ref out_node) == false)
            {
                if (mb_error_ignore_flag == false)
                {
                    MessageBox.Show(MPMH.StatusMessage);
                }
                return "";
            }
            if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
            {
                if (mb_error_ignore_flag == false)
                {
                    MessageBox.Show(out_node.Msg);
                }
                return "";
            }

            List<TRSNode> resList = out_node.GetList("RES_LIST");
            if (resList.Count < 1)
            {
                return "";
            }

            string s_res_id = "";
            int i = (new Random()).Next(resList.Count);
            if (resList[i].GetChar("RES_UP_DOWN_FLAG") == 'U')
            {
                s_res_id = resList[i].GetString("RES_ID");
            }
            else
            {
                if (i + 1 < resList.Count - 1 && resList[i + 1].GetChar("RES_UP_DOWN_FLAG") == 'U')
                {
                    s_res_id = resList[i + 1].GetString("RES_ID");
                }
                else if (i - 1 >= 0 && resList[i - 1].GetChar("RES_UP_DOWN_FLAG") == 'U')
                {
                    s_res_id = resList[i - 1].GetString("RES_ID");
                }
            }

            return s_res_id;
        }

        private string GetLotId(string s_oper, string s_tran_code, string s_mat_id)
        {
            TRSNode in_node = new TRSNode("GENERATE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                //in_node.ProcStep = '1';
                //in_node.AddString("OPER", s_oper);
                //in_node.AddChar("REL_LEVEL", '3');
                //in_node.AddString("TRAN_CODE", s_tran_code);
                //in_node.AddString("MAT_ID", s_mat_id);

                in_node.ProcStep = '2';
                in_node.AddString("RULE_ID", "DEF_LOT_ID_RULE");
                in_node.AddString("MAT_ID", s_mat_id);

                if (MessageCaster.CallService("WIP", "WIP_Generate_ID", in_node, ref out_node) == false)
                {
                    if (mb_error_ignore_flag == false)
                    {
                        MessageBox.Show(MPMH.StatusMessage);
                    }
                    return "";
                }
                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    if (mb_error_ignore_flag == false)
                    {
                        MessageBox.Show(out_node.Msg);
                    }
                    return "";
                }

                return MPCF.Trim(out_node.GetString("GEN_ID"));
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return "";
            }
        }

        private bool GetCollectionInfo(TRSNode LOT, TRSNode EDC)
        {
            TextBox txtColSet = new TextBox();

            if (MPCR.ViewMFOColSet('2', LOT.GetString("MAT_ID"), LOT.GetInt("MAT_VER"), LOT.GetString("FLOW"), LOT.GetString("OPER"), 'M', txtColSet) == false)
            {
                return false;
            }

            TRSNode in_node = new TRSNode("FIND_COL_SET_VERSION_IN");
            TRSNode out_node = new TRSNode("FIND_COL_SET_VERSION_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", LOT.GetString("LOT_ID"));
            in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
            in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
            in_node.AddString("FLOW", LOT.GetString("FLOW"));
            in_node.AddString("OPER", LOT.GetString("OPER"));
            in_node.AddString("COL_SET_ID", txtColSet.Text);
            in_node.AddChar("LOT_OR_RES_FLAG", 'L');

            if (MessageCaster.CallService("EDC", "EDC_Find_Col_Set_Version", in_node, ref out_node) == false)
            {
                if (mb_error_ignore_flag == false)
                {
                    MessageBox.Show(MPMH.StatusMessage);
                }
                return false;
            }
            if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
            {
                if (mb_error_ignore_flag == false)
                {
                    MessageBox.Show(out_node.Msg);
                }
                return false;
            }

            in_node.Init();

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '5';
            in_node.AddString("COL_SET_ID", out_node.GetString("COL_SET_ID"));
            in_node.AddInt("COL_SET_VERSION", out_node.GetInt("COL_SET_VERSION"));
            in_node.AddString("LOT_ID", LOT.GetString("LOT_ID"));

            if (MessageCaster.CallService("EDC", "EDC_View_Attach_Character_List", in_node, ref EDC) == false)
            {
                if (mb_error_ignore_flag == false)
                {
                    MessageBox.Show(MPMH.StatusMessage);
                }
                return false;
            }
            if (EDC.StatusValue == MPGC.MP_FAIL_STATUS)
            {
                if (mb_error_ignore_flag == false)
                {
                    MessageBox.Show(EDC.Msg);
                }
                return false;
            }

            EDC.AddString("COL_SET_ID", out_node.GetString("COL_SET_ID"));
            EDC.AddInt("COL_SET_VERSION", out_node.GetInt("COL_SET_VERSION"));

            return true;
        }


        #region " Calling Services "

        private bool A01_Create_Lot(string s_order_id, ref string s_lot_id)
        {
            TRSNode in_node = new TRSNode("CREATE_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode ORDER = new TRSNode("ORDER_INFO");
            string s_oper;
            double d_qty;

            if (ViewOrder(s_order_id, ORDER) == false) return false;
            if ((ORDER.GetDouble("ORD_QTY") - ORDER.GetDouble("ORD_IN_QTY")) < 0.0005) return false;

            s_oper = GetFirstOper(ORDER.GetString("FLOW"));
            s_lot_id = GetLotId(s_oper, "CREATE", ORDER.GetString("MAT_ID"));
            if (s_lot_id == "") return false;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.UserID = "OP_" + mi_thread_seq.ToString();

                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", s_lot_id);

                in_node.AddString("MAT_ID", ORDER.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", ORDER.GetInt("MAT_VER"));
                in_node.AddString("FLOW", ORDER.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", ORDER.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", s_oper);
                in_node.AddChar("LOT_TYPE", ORDER.GetChar("LOT_TYPE"));
                in_node.AddString("CREATE_CODE", ORDER.GetString("CREATE_CODE"));
                in_node.AddString("OWNER_CODE", ORDER.GetString("OWNER_CODE"));
                in_node.AddChar("LOT_PRIORITY", ORDER.GetChar("LOT_PRIORITY"));
                in_node.AddString("DUE_TIME", ORDER.GetString("ORG_DUE_TIME"));

                d_qty = ORDER.GetDouble("QTY");
                if ((ORDER.GetDouble("ORD_QTY") - ORDER.GetDouble("ORD_IN_QTY")) < d_qty)
                {
                    d_qty = ORDER.GetDouble("ORD_QTY") - ORDER.GetDouble("ORD_IN_QTY");
                }
                in_node.AddDouble("QTY_1", d_qty);

                in_node.AddChar("IN_CASE", '1');
                in_node.AddString("ORDER_ID", ORDER.GetString("ORDER_ID"));

                if (MessageCaster.CallService("ORD", "ORD_Create_Lot", in_node, ref out_node) == false)
                {
                    if (mb_error_ignore_flag == false)
                    {
                        MessageBox.Show(MPMH.StatusMessage);
                    }
                    return false;
                }
                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    if (mb_error_ignore_flag == false)
                    {
                        MessageBox.Show(out_node.Msg);
                    }
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

        private bool A02_Start_Lot(string s_lot_id, string s_res_id)
        {
            TRSNode in_node = new TRSNode("START_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.UserID = "OP_" + mi_thread_seq.ToString();

                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", s_lot_id);
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", 0);
                in_node.AddString("RES_ID", s_res_id);

                if (MessageCaster.CallService("WIP", "WIP_Start_Lot", in_node, ref out_node) == false)
                {
                    if (mb_error_ignore_flag == false)
                    {
                        MessageBox.Show(MPMH.StatusMessage);
                    }
                    return false;
                }
                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    if (mb_error_ignore_flag == false)
                    {
                        MessageBox.Show(out_node.Msg);
                    }
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

        private bool A03_End_Lot(string s_lot_id, string s_res_id)
        {
            TRSNode in_node = new TRSNode("END_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.UserID = "OP_" + mi_thread_seq.ToString();

                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", s_lot_id);
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", 0);
                in_node.AddString("RES_ID", s_res_id);

                if (MessageCaster.CallService("WIP", "WIP_End_Lot", in_node, ref out_node) == false)
                {
                    if (mb_error_ignore_flag == false)
                    {
                        MessageBox.Show(MPMH.StatusMessage);
                    }
                    return false;
                }
                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    if (out_node.MsgCode == "WIP-0390")
                    {
                        mb_last_flow_oper_flag = true;
                    }
                    else
                    {
                        if (mb_error_ignore_flag == false)
                        {
                            MessageBox.Show(out_node.Msg);
                        }
                    }
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

        private bool A04_Split_Lot(TRSNode LOT)
        {
            TRSNode in_node = new TRSNode("SPLIT_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            string s_child_lot_id = GetLotId(LOT.GetString("OPER"), "SPLIT", LOT.GetString("MAT_ID"));

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.UserID = "OP_" + mi_thread_seq.ToString();

                in_node.ProcStep = '1';
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", 0);
                in_node.AddString("LOT_ID", LOT.GetString("LOT_ID"));

                in_node.AddString("CHILD_LOT_ID", s_child_lot_id);
                in_node.AddDouble("MOVE_QTY_1", MPCF.ToInt(LOT.GetDouble("QTY_1") / 3));
                in_node.AddString("CHILD_DUE_TIME", DateTime.Now.AddMonths(1).ToString("yyyyMMdd"));
                in_node.AddChar("NO_AUTOMATIC_TERMINATE_LOT", 'Y');

                if (MessageCaster.CallService("WIP", "WIP_Split_Lot", in_node, ref out_node) == false)
                {
                    if (mb_error_ignore_flag == false)
                    {
                        MessageBox.Show(MPMH.StatusMessage);
                    }
                    return false;
                }
                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    if (mb_error_ignore_flag == false)
                    {
                        MessageBox.Show(out_node.Msg);
                    }
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

        private bool A05_Collect_Lot_Data(TRSNode LOT, TRSNode EDC)
        {
            TRSNode in_node = new TRSNode("COLLECT_LOT_DATA_IN");
            TRSNode out_node = new TRSNode("COLLECT_LOT_DATA_OUT");
            TRSNode char_item, unit_item, value_item;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '4';
                in_node.AddString("LOT_ID", LOT.GetString("LOT_ID"));

                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));

                in_node.AddString("COL_SET_ID", EDC.GetString("COL_SET_ID"));
                in_node.AddInt("COL_SET_VERSION", EDC.GetInt("COL_SET_VERSION"));

                List<TRSNode> charList = EDC.GetList("CHAR_LIST");
                Random rv = new Random();

                double d_usl;
                double d_lsl;
                double d_value;
                bool b_spec_exist;

                foreach (TRSNode CHAR in charList)
                {
                    char_item = in_node.AddNode("CHAR_LIST");
                    char_item.AddString("CHAR_ID", CHAR.GetString("CHAR_ID"));

                    d_usl = 100;
                    d_lsl = 0;
                    b_spec_exist = false;

                    if (CHAR.GetString("UPPER_SPEC_LIMIT") != "")
                    {
                        d_usl = MPCF.ToDbl(CHAR.GetString("UPPER_SPEC_LIMIT"));
                        b_spec_exist = true;
                    }
                    if (CHAR.GetString("LOWER_SPEC_LIMIT") != "")
                    {
                        d_lsl = MPCF.ToDbl(CHAR.GetString("LOWER_SPEC_LIMIT"));
                        b_spec_exist = true;
                    }

                    if (b_spec_exist == true)
                    {
                        d_usl = d_usl + ((d_usl - d_lsl) / 3);
                        d_lsl = d_lsl - ((d_usl - d_lsl) / 3);
                    }

                    for (int u = 0; u < CHAR.GetInt("UNIT_COUNT"); u++)
                    {
                        unit_item = char_item.AddNode("UNIT_LIST");
                        unit_item.AddString("UNIT_ID", "*");
                        unit_item.AddInt("UNIT_SEQ_NUM", u + 1);

                        for (int v = 0; v < CHAR.GetInt("VALUE_COUNT"); v++)
                        {
                            value_item = unit_item.AddNode("VALUE_LIST");

                            if (CHAR.GetChar("VALUE_TYPE") == 'A')
                            {
                                value_item.AddString("VALUE", "Y");
                            }
                            else
                            {
                                double d_usl1;
                                double d_lsl1;
                                double d_usl2;
                                double d_lsl2;
                                int i_random;

                                d_lsl1 = ((d_usl - d_lsl) / 3) + d_lsl;
                                d_usl1 = d_usl - ((d_usl - d_lsl) / 3);

                                d_lsl2 = ((d_usl1 - d_lsl1) / 3) + d_lsl1;
                                d_usl2 = d_usl1 - ((d_usl1 - d_lsl1) / 3);

                                d_value = rv.NextDouble() * (d_usl2 - d_lsl2) + d_lsl2;

                                i_random = rv.Next(1, 9);
                                if (i_random % 3 == 0)
                                {
                                    d_value = rv.NextDouble() * (d_usl - d_lsl) + d_lsl;
                                }
                                else if (i_random % 2 == 0)
                                {
                                    d_value = rv.NextDouble() * (d_usl1 - d_lsl1) + d_lsl1;
                                }

                                value_item.AddString("VALUE", d_value.ToString("##.##"));
                            }
                        }
                    }
                }

                if (MessageCaster.CallService("EDC", "EDC_Collect_Lot_Data", in_node, ref out_node) == false)
                {
                    if (mb_error_ignore_flag == false)
                    {
                        MessageBox.Show(MPMH.StatusMessage);
                    }
                    return false;
                }
                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    if (mb_error_ignore_flag == false)
                    {
                        MessageBox.Show(out_node.Msg);
                    }
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

        private bool A06_Merge_Lot(TRSNode SRC_LOT, string s_into_lot_id)
        {
            TRSNode in_node = new TRSNode("MERGE_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.UserID = "OP_" + mi_thread_seq.ToString();

                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", SRC_LOT.GetString("LOT_ID"));
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", 0);

                in_node.AddString("INTO_LOT_ID", s_into_lot_id);
                in_node.AddDouble("MOVE_QTY_1", SRC_LOT.GetDouble("QTY_1"));

                if (MessageCaster.CallService("WIP", "WIP_Merge_Lot", in_node, ref out_node) == false)
                {
                    if (mb_error_ignore_flag == false)
                    {
                        MessageBox.Show(MPMH.StatusMessage);
                    }
                    return false;
                }
                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    if (mb_error_ignore_flag == false)
                    {
                        MessageBox.Show(out_node.Msg);
                    }
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

        private bool A07_Loss_Lot(TRSNode LOT, TRSNode OPER)
        {
            ListView lisLossCode = new ListView();
            lisLossCode.Columns.Add("Code");
            lisLossCode.Columns.Add("Desc");

            BASLIST.ViewGCMDataList(lisLossCode, '1', OPER.GetString("LOSS_TBL"));
            if (lisLossCode.Items.Count < 1) return true;

            TRSNode in_node = new TRSNode("LOSS_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode unitItem;
            Random rv = new Random();
            int i_code_index1 = 0;
            int i_code_index2 = 0;
            int i_code_index3 = 0;
            int i_loss_qty = 0;
            int i_loss_total = 0;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.UserID = "OP_" + mi_thread_seq.ToString();

                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", LOT.GetString("LOT_ID"));
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", 0);

                i_loss_qty = rv.Next(15); i_loss_total += i_loss_qty;
                if (LOT.GetDouble("QTY_1") > i_loss_total)
                {
                    unitItem = in_node.AddNode("UNIT1");

                    i_code_index1 = rv.Next(lisLossCode.Items.Count - 1);
                    unitItem.AddString("CODE", lisLossCode.Items[i_code_index1].Text);
                    unitItem.AddDouble("QTY", i_loss_qty);
                }

                i_loss_qty = rv.Next(15); i_loss_total += i_loss_qty;
                if (LOT.GetDouble("QTY_1") > i_loss_total)
                {
                    unitItem = in_node.AddNode("UNIT1");

                    do { i_code_index2 = rv.Next(lisLossCode.Items.Count - 1); } while (i_code_index1 == i_code_index2);
                    unitItem.AddString("CODE", lisLossCode.Items[i_code_index2].Text);
                    unitItem.AddDouble("QTY", i_loss_qty);
                }

                i_loss_qty = rv.Next(15); i_loss_total += i_loss_qty;
                if (LOT.GetDouble("QTY_1") > i_loss_total)
                {
                    unitItem = in_node.AddNode("UNIT1");
                    do { i_code_index3 = rv.Next(lisLossCode.Items.Count - 1); } while (i_code_index1 == i_code_index3 || i_code_index2 == i_code_index3);
                    unitItem.AddString("CODE", lisLossCode.Items[i_code_index3].Text);
                    unitItem.AddDouble("QTY", i_loss_qty);
                }

                in_node.AddDouble("OUT_QTY_1", LOT.GetDouble("QTY_1") - i_loss_total);
                in_node.AddDouble("OUT_QTY_2", LOT.GetDouble("QTY_2"));
                in_node.AddDouble("OUT_QTY_3", LOT.GetDouble("QTY_3"));
                
                if (MessageCaster.CallService("WIP", "WIP_Loss_Lot", in_node, ref out_node) == false)
                {
                    if (mb_error_ignore_flag == false)
                    {
                        MessageBox.Show(MPMH.StatusMessage);
                    }
                    return false;
                }
                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    if (mb_error_ignore_flag == false)
                    {
                        MessageBox.Show(out_node.Msg);
                    }
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

        
        
        
        
        #endregion

    }
}
