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
    class clsPerformanceTestRunner
    {
        private const string TEST_MAT_ID = "MAT_1";
        private const string TEST_FLOW = "FLOW_1";
        private const string TEST_START_OPER = "1000";
        private const char   TEST_LOT_TYPE = 'T';
        private const string TEST_CREATE_CODE = "TEST";
        private const string TEST_OWNER_CODE = "PROD";
        private const string TEST_COL_SET = "TEST_EDC";
        private const int    TEST_COL_SET_VER = 1;
        private const string TEST_CHAR_1 = "CHAR_1";
        private const string TEST_CHAR_2 = "CHAR_2";
        private const string TEST_CHAR_3 = "CHAR_3";
        private const string TEST_CHAR_4 = "CHAR_4";
        private const string TEST_CHAR_5 = "CHAR_5";

        private frmUTLPerformanceTest mf_TEST_FORM;

        private double md_total_elapsed_time;
        private int mi_total_call_service_count;
        private double md_minumum_time;
        private double md_maximum_time;

        private bool mb_stop_flag;
        private bool mb_last_flow_oper_flag;

        private int mi_thread_seq;
        private bool mb_error_ignore_flag;

        private string ms_test_lot_id;
        private int mi_test_lot_count;
        private int mi_test_lot_qty;
        private bool mb_random_qty_flag;

        private string ms_test_res_id;

        private ArrayList al_split_time;
        private ArrayList al_edc_time;
        private ArrayList al_merge_time;
        private ArrayList al_end_time;
        private ArrayList al_start_time;

        public clsPerformanceTestRunner()
        {
            al_split_time = new ArrayList();
            al_edc_time = new ArrayList();
            al_merge_time = new ArrayList();
            al_end_time = new ArrayList();
            al_start_time = new ArrayList();

            mf_TEST_FORM = null;

            md_total_elapsed_time = 0;
            mi_total_call_service_count = 0;
            md_minumum_time = 99999;
            md_maximum_time = 0;

            mb_stop_flag = false;
            mb_last_flow_oper_flag = false;
            mi_thread_seq = 0;
            mb_error_ignore_flag = false;
            ms_test_lot_id = "";
            mi_test_lot_count = 0;
            mi_test_lot_qty = 0;
            mb_random_qty_flag = false;
            ms_test_res_id = "";
        }

        public void setTestLotInfo(string s_lot_id, int i_lot_count, int i_lot_qty, bool b_random_qty)
        {
            ms_test_lot_id = s_lot_id;
            mi_test_lot_count = i_lot_count;
            mi_test_lot_qty = i_lot_qty;
            mb_random_qty_flag = b_random_qty;
        }

        public void setTestThread(frmUTLPerformanceTest f, int i_thread_seq, bool b_ignore_error)
        {
            mf_TEST_FORM = f;
            mi_thread_seq = i_thread_seq;
            mb_error_ignore_flag = b_ignore_error;
        }

        public void setStopFlag(bool b_stop)
        {
            mb_stop_flag = b_stop;
        }

        public void ProcessTest()
        {
            TRSNode LOT;
            TRSNode OPER;
            int i, m;
            int i_lot_count, i_child_lot_count;
            string s_lot_id;
            string s_child_lot_id;
            bool b_splitted_flag;
            bool b_break_flag;

            Stopwatch watch;
            Stopwatch watch_lot;
            Random rd;
            int i_random_seq_for_lot;

            LOT = new TRSNode("Lot");
            OPER = new TRSNode("Operation");

            watch = new Stopwatch();
            watch_lot = new Stopwatch();

            mf_TEST_FORM.setStartTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff"));

            watch.Start();

            s_lot_id = "";

            rd = new Random();
            i_random_seq_for_lot = rd.Next(0, 100);

            try
            {
                i_lot_count = mi_test_lot_count;

                for (i = 0; i < i_lot_count; i++)
                {
                    try
                    {
                        watch_lot.Restart();

                        al_split_time.Clear();
                        al_edc_time.Clear();
                        al_merge_time.Clear();
                        al_end_time.Clear();
                        al_start_time.Clear();

                        s_lot_id = ms_test_lot_id;
                        switch (s_lot_id)
                        {
                            case "$DATETIME":
                                s_lot_id = GetDateTimeString(); // length 9
                                break;
                            case "$DATE":
                                s_lot_id = DateTime.Now.ToString("yyMMdd");
                                break;
                            case "$TIME":
                                s_lot_id = DateTime.Now.ToString("HHmmss");
                                break;
                        }

                        s_lot_id += mi_thread_seq.ToString();
                        s_lot_id += (i_random_seq_for_lot + i).ToString("00000");

                        b_splitted_flag = false;
                        mb_last_flow_oper_flag = false;
                        if (A01_Create_Lot(s_lot_id) == false) return;

                        while(true)
                        {
                            if (mb_stop_flag == true) return;

                            LOT.Init();
                            OPER.Init();

                            if (ViewLot(s_lot_id, LOT) == false) break;
                            if (LOT.GetChar("HOLD_FLAG") == 'Y') break;

                            if (ViewOperation(LOT.GetString("OPER"), OPER) == false) break;
                            if (OPER.GetChar("END_OPER_FLAG") == 'Y') break;

                            // Start
                            if (LOT.GetChar("START_FLAG") != 'Y' && OPER.GetChar("START_REQUIRE_FLAG") == 'Y')
                            {
                                i_child_lot_count = 1;
                                if (b_splitted_flag == true)
                                {
                                    i_child_lot_count = mi_test_lot_qty;
                                }

                                b_break_flag = false;
                                for (m = 0; m < i_child_lot_count; m++)
                                {
                                    if (mb_stop_flag == true) return;

                                    s_child_lot_id = s_lot_id;
                                    if (b_splitted_flag == true)
                                    {
                                        s_child_lot_id += "-" + m.ToString("00000");
                                    }

                                    if (A02_Start_Lot(s_child_lot_id, OPER.GetString("OPER")) == false)
                                    {
                                        b_break_flag = true;
                                        break;
                                    }
                                }//end for End lot

                                if (b_break_flag == true) break;
                            }

                            // Split
                            if (mb_random_qty_flag == false && OPER.GetString("OPER_CMF_1") == "Y")
                            {
                                LOT.Init();
                                if (ViewLot(s_lot_id, LOT) == false) break;
                                if (A04_Split_Lot(LOT) == false) break;
                                b_splitted_flag = true;
                            }

                            // EDC
                            if (OPER.GetString("OPER_CMF_2") == "Y")
                            {
                                i_child_lot_count = 1;
                                if(b_splitted_flag == true)
                                {
                                    i_child_lot_count = mi_test_lot_qty;
                                }

                                b_break_flag = false;
                                for (m = 0; m < i_child_lot_count; m++)
                                {
                                    if (mb_stop_flag == true) return;

                                    s_child_lot_id = s_lot_id;
                                    if (b_splitted_flag == true)
                                    {
                                        s_child_lot_id += "-" + m.ToString("00000");
                                    }

                                    LOT.Init();
                                    if (ViewLot(s_child_lot_id, LOT) == false)
                                    {
                                        b_break_flag = true;
                                        break;
                                    }
                                    if (A05_Collect_Lot_Data(LOT) == false)
                                    {
                                        b_break_flag = true;
                                        break;
                                    }
                                }
                                if (b_break_flag == true) break;
                            }

                            // Merge
                            if (OPER.GetString("OPER_CMF_3") == "Y")
                            {
                                if (b_splitted_flag == true)
                                {
                                    i_child_lot_count = mi_test_lot_qty;

                                    b_break_flag = false;
                                    for (m = 0; m < i_child_lot_count; m++)
                                    {
                                        if (mb_stop_flag == true) return;

                                        s_child_lot_id = s_lot_id + "-";
                                        s_child_lot_id += m.ToString("00000");

                                        if (A06_Merge_Lot(s_child_lot_id, s_lot_id) == false)
                                        {
                                            b_break_flag = true;
                                            break;
                                        }
                                    }
                                    b_splitted_flag = false;

                                    if (b_break_flag == true) break;
                                }
                            }

                            // End Lot
                            i_child_lot_count = 1;
                            if (b_splitted_flag == true)
                            {
                                i_child_lot_count = mi_test_lot_qty;
                                if (OPER.GetChar("START_REQUIRE_FLAG") == 'Y')
                                {
                                    if (ViewLot(s_lot_id, LOT) == false) break;
                                    if (LOT.GetChar("START_FLAG") != 'Y')
                                    {
                                        if (A02_Start_Lot(s_lot_id, OPER.GetString("OPER")) == false) break;
                                    }
                                }
                                if (A03_End_Lot(s_lot_id, OPER.GetString("OPER"), "") == false) break;
                            }

                            b_break_flag = false;
                            for (m = 0; m < i_child_lot_count; m++)
                            {
                                if (mb_stop_flag == true) return;

                                s_child_lot_id = s_lot_id;
                                if (b_splitted_flag == true)
                                {
                                    s_child_lot_id += "-" + m.ToString("00000");
                                }

                                if (A03_End_Lot(s_child_lot_id, OPER.GetString("OPER"), "") == false)
                                {
                                    b_break_flag = true;
                                    break;
                                }
                            }//end for End lot
                            if (b_break_flag == true) break;
                            

                            // end lot process
                            if (mb_last_flow_oper_flag == true) break;
                        }// end while
                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMsgBox(ex.Message);
                        return;
                    }
                    finally
                    {
                        string s_elapsed_time;
                        ListViewItem itm;
                        double d_elapsed_time;
                        int i_index;

                        watch_lot.Stop();
                        s_elapsed_time = watch_lot.Elapsed.TotalSeconds.ToString("#############,##0.###");

                        itm = new ListViewItem(mi_thread_seq.ToString(), (int)SMALLICON_INDEX.IDX_LOT);

                        itm.SubItems.Add((i + 1).ToString());
                        itm.SubItems.Add(s_lot_id);
                        itm.SubItems.Add(OPER.GetString("OPER"));
                        itm.SubItems.Add(s_elapsed_time);

                        for (d_elapsed_time = 0, i_index = 0; i_index < al_start_time.Count; i_index++)
                        {
                            d_elapsed_time += (double)al_start_time[i_index];
                        }
                        d_elapsed_time = d_elapsed_time / al_start_time.Count;
                        itm.SubItems.Add(d_elapsed_time.ToString("#############,##0.###"));

                        for (d_elapsed_time = 0, i_index = 0; i_index < al_end_time.Count; i_index++)
                        {
                            d_elapsed_time += (double)al_end_time[i_index];
                        }
                        d_elapsed_time = d_elapsed_time / al_end_time.Count;
                        itm.SubItems.Add(d_elapsed_time.ToString("#############,##0.###"));

                        for (d_elapsed_time = 0, i_index = 0; i_index < al_split_time.Count; i_index++)
                        {
                            d_elapsed_time += (double)al_split_time[i_index];
                        }
                        d_elapsed_time = d_elapsed_time / al_split_time.Count;
                        itm.SubItems.Add(d_elapsed_time.ToString("#############,##0.###"));

                        for (d_elapsed_time = 0, i_index = 0; i_index < al_merge_time.Count; i_index++)
                        {
                            d_elapsed_time += (double)al_merge_time[i_index];
                        }
                        d_elapsed_time = d_elapsed_time / al_merge_time.Count;
                        itm.SubItems.Add(d_elapsed_time.ToString("#############,##0.###"));

                        for (d_elapsed_time = 0, i_index = 0; i_index < al_edc_time.Count; i_index++)
                        {
                            d_elapsed_time += (double)al_edc_time[i_index];
                        }
                        d_elapsed_time = d_elapsed_time / al_edc_time.Count;
                        itm.SubItems.Add(d_elapsed_time.ToString("#############,##0.###"));

                        mf_TEST_FORM.setTranTimeData(itm);
                        mf_TEST_FORM.setTotalProgress(1);
                    }

                    if (mb_random_qty_flag == true && i % 10 == 0)
                    {
                        A99_Delete_Lot_History(s_lot_id);
                    }
                }//end for lot count

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
            finally
            {
                watch.Stop();

                mf_TEST_FORM.setElapsedTime(watch.Elapsed.TotalSeconds.ToString("#############,##0.###"));
                mf_TEST_FORM.setEndTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff"));

                mf_TEST_FORM.setMinTime(md_minumum_time);
                mf_TEST_FORM.setMaxTime(md_maximum_time);
                mf_TEST_FORM.setAvgTime(md_total_elapsed_time / mi_total_call_service_count);
                mf_TEST_FORM.setServiceCount(mi_total_call_service_count);

                mf_TEST_FORM.setFinishTestRunner();
            }
        }

        private string GetDateTimeString()
        {
            string s;
            DateTime dt = DateTime.Now;

            s = Convert.ToChar(dt.Year - 2014 + 65).ToString();
            s += dt.Month > 9 ? Convert.ToChar(dt.Month - 10 + 65).ToString() : dt.Month.ToString();
            s += dt.Day > 9 ? Convert.ToChar(dt.Day - 10 + 65).ToString() : dt.Day.ToString();
            s += dt.Hour > 9 ? Convert.ToChar(dt.Hour - 10 + 65).ToString() : dt.Hour.ToString();

            if (dt.Minute > 35) s += Convert.ToChar(dt.Minute - 36 + 97).ToString();
            else if (dt.Minute > 9) s += Convert.ToChar(dt.Minute - 10 + 65).ToString();
            else s += dt.Minute.ToString();

            if (dt.Second > 35) s += Convert.ToChar(dt.Second - 36 + 97).ToString();
            else if (dt.Second > 9) s += Convert.ToChar(dt.Second - 10 + 65).ToString();
            else s += dt.Second.ToString();

            s += dt.Millisecond.ToString("000");

            return s;
        }

        private void SetElapsedTimePerService(string s_service_elapsed_time)
        {
            double d_val;

            d_val = MPCF.ToDbl(s_service_elapsed_time);
            d_val /= 1000;

            mi_total_call_service_count++;
            md_total_elapsed_time += d_val;

            if (d_val < md_minumum_time)
            {
                md_minumum_time = d_val;
            }
            if (d_val > md_maximum_time)
            {
                md_maximum_time = d_val;
            }

            if (mi_total_call_service_count % 100 == 0)
            {
                double d_avg;

                mf_TEST_FORM.setNowTime(d_val);
                mf_TEST_FORM.setMinTime(md_minumum_time);
                mf_TEST_FORM.setMaxTime(md_maximum_time);

                d_avg = md_total_elapsed_time / mi_total_call_service_count;
                mf_TEST_FORM.setAvgTime(d_avg);
                mf_TEST_FORM.setServiceCount(mi_total_call_service_count);
            }
        }

        private bool ViewLot(string s_lot_id, TRSNode LOT)
        {
            TRSNode in_node = new TRSNode("View_Lot_In");

            MPCR.SetInMsg(in_node);
            in_node.UserID = "PFM_RUNNER_" + mi_thread_seq.ToString();

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

			// Delete Lot History 무한 반복 문제로 인하여 추가. 2017.02.10 이환노수석 제공
            if (LOT.GetChar("MSGCATE") == 'E')
                return false;

            SetElapsedTimePerService(MsgHandler.MessageCaster.ExeTimeString);

            return true;
        }

        private bool ViewOperation(string s_oper, TRSNode OPER)
        {
            TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");

            MPCR.SetInMsg(in_node);
            in_node.UserID = "PFM_RUNNER_" + mi_thread_seq.ToString();

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
            SetElapsedTimePerService(MsgHandler.MessageCaster.ExeTimeString);

            return true;
        }

        private string GetResource(string s_mat_id, int i_mat_ver, string s_flow, string s_oper)
        {
            TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_RESOURCE_LIST_OUT");

            MPCR.SetInMsg(in_node);
            in_node.UserID = "PFM_RUNNER_" + mi_thread_seq.ToString();

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

            if(out_node.GetList(0).Count < 1)
            {
                return "";
            }

            return out_node.GetList(0)[0].GetString("RES_ID");
        }


#region " Calling Services "
        private bool A01_Create_Lot(string s_lot_id)
        {
            TRSNode in_node = new TRSNode("CREATE_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.UserID = "PFM_RUNNER_" + mi_thread_seq.ToString();

                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", s_lot_id);
                in_node.AddString("LOT_DESC", "Performance Test Lot");

                in_node.AddString("MAT_ID", TEST_MAT_ID);
                in_node.AddInt("MAT_VER", 1);
                in_node.AddString("FLOW", TEST_FLOW);
                in_node.AddInt("FLOW_SEQ_NUM", 1);
                in_node.AddString("OPER",TEST_START_OPER);
                in_node.AddChar("LOT_TYPE", TEST_LOT_TYPE);

                if (mb_random_qty_flag == true)
                {
                    Random rd = new Random();
                    in_node.AddDouble("QTY_1", rd.Next(1, 100));
                }
                else
                {
                    in_node.AddDouble("QTY_1", mi_test_lot_qty);
                }
                in_node.AddString("CREATE_CODE", TEST_CREATE_CODE);
                in_node.AddString("OWNER_CODE", TEST_OWNER_CODE);
                in_node.AddChar("LOT_PRIORITY", '5');
                in_node.AddString("DUE_TIME", DateTime.Now.AddMonths(1).ToString("yyyyMMdd"));
                in_node.AddString("COMMENT", "Performance Test for Creation lot");

                if (MessageCaster.CallService("WIP", "WIP_Create_Lot", in_node, ref out_node) == false)
                {
                    if (mb_error_ignore_flag == false)
                    {
                        MessageBox.Show(MPMH.StatusMessage);
                    }
                    return false;
                }
                SetElapsedTimePerService(MsgHandler.MessageCaster.ExeTimeString);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool A02_Start_Lot(string s_lot_id, string s_oper)
        {
            TRSNode in_node = new TRSNode("START_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            Stopwatch watch;

            try
            {
                watch = new Stopwatch();
                watch.Start();

                MPCR.SetInMsg(in_node);
                in_node.UserID = "PFM_RUNNER_" + mi_thread_seq.ToString();

                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", s_lot_id);
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", 0);
                in_node.AddString("COMMENT", "Performance Test for Starting lot");
                in_node.AddString("RES_ID", GetResource(TEST_MAT_ID, 1, TEST_FLOW, s_oper));

                if (MessageCaster.CallService("WIP", "WIP_Start_Lot", in_node, ref out_node) == false)
                {
                    if (mb_error_ignore_flag == false)
                    {
                        MessageBox.Show(MPMH.StatusMessage);
                    }
                    return false;
                }
                SetElapsedTimePerService(MsgHandler.MessageCaster.ExeTimeString);

                watch.Stop();
                al_start_time.Add(watch.Elapsed.TotalSeconds);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool A03_End_Lot(string s_lot_id, string s_oper, string s_to_oper)
        {
            TRSNode in_node = new TRSNode("END_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            Stopwatch watch;

            try
            {
                watch = new Stopwatch();
                watch.Start();

                MPCR.SetInMsg(in_node);
                in_node.UserID = "PFM_RUNNER_" + mi_thread_seq.ToString();

                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", s_lot_id);
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", 0);
                in_node.AddString("RES_ID", GetResource(TEST_MAT_ID, 1, TEST_FLOW, s_oper));
                in_node.AddString("COMMENT", "Performance Test for Ending lot to target operation");

                if (s_to_oper != "")
                {
                    in_node.AddString("TO_FLOW", TEST_FLOW);
                    in_node.AddInt("TO_FLOW_SEQ_NUM", 1);
                    in_node.AddString("TO_OPER", s_to_oper);
                }

                if (MessageCaster.CallService("WIP", "WIP_End_Lot", in_node, ref out_node) == false)
                {
                    if (out_node.MsgCode == "WIP-0390")
                    {
                        mb_last_flow_oper_flag = true;
                    }
                    else
                    {
                        if (mb_error_ignore_flag == false)
                        {
                            MessageBox.Show(MPMH.StatusMessage);
                        }
                        return false;
                    }
                }
                SetElapsedTimePerService(MsgHandler.MessageCaster.ExeTimeString);

                watch.Stop();
                al_end_time.Add(watch.Elapsed.TotalSeconds);

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
            int i;
            int i_qty;
            string s_lot_id;
            string s_child_lot_id;

            Stopwatch watch;

            try
            {
                s_lot_id = LOT.GetString("LOT_ID");
                i_qty = MPCF.ToInt(LOT.GetDouble("QTY_1"));

                watch = new Stopwatch();

                for (i = 0; i < i_qty; i++)
                {
                    watch.Restart();

                    MPCR.SetInMsg(in_node);
                    in_node.UserID = "PFM_RUNNER_" + mi_thread_seq.ToString();

                    in_node.ProcStep = '1';
                    in_node.AddInt("LAST_ACTIVE_HIST_SEQ", 0);
                    in_node.AddString("LOT_ID", s_lot_id);

                    s_child_lot_id = s_lot_id + "-";
                    s_child_lot_id += i.ToString("00000");

                    in_node.AddString("CHILD_LOT_ID", s_child_lot_id);
                    in_node.AddString("CHILD_LOT_DESC", "Performance Test Child Lot");
                    in_node.AddDouble("MOVE_QTY_1", 1);
                    in_node.AddString("CHILD_DUE_TIME", DateTime.Now.AddMonths(1).ToString("yyyyMMdd"));
                    in_node.AddString("COMMENT", "Performance Test for Splitting lot");
                    in_node.AddChar("NO_AUTOMATIC_TERMINATE_LOT", 'Y');

                    if (MessageCaster.CallService("WIP", "WIP_Split_Lot", in_node, ref out_node) == false)
                    {
                        if (mb_error_ignore_flag == false)
                        {
                            MessageBox.Show(MPMH.StatusMessage);
                        }
                        return false;
                    }
                    SetElapsedTimePerService(MsgHandler.MessageCaster.ExeTimeString);

                    watch.Stop();
                    al_split_time.Add(watch.Elapsed.TotalSeconds);

                    in_node.Init();
                    out_node.Init();
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool A05_Collect_Lot_Data(TRSNode LOT)
        {
            TRSNode in_node = new TRSNode("COLLECT_LOT_DATA_IN");
            TRSNode out_node = new TRSNode("COLLECT_LOT_DATA_OUT");
            TRSNode char_item, unit_item, value_item;

            Stopwatch watch;

            Random rv = new Random();

            try
            {
                watch = new Stopwatch();
                watch.Start();

                MPCR.SetInMsg(in_node);
                in_node.UserID = "PFM_RUNNER_" + mi_thread_seq.ToString();

                in_node.ProcStep = '4';
                in_node.AddString("LOT_ID", LOT.GetString("LOT_ID"));

                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));

                in_node.AddString("COL_SET_ID", TEST_COL_SET);
                in_node.AddInt("COL_SET_VERSION", TEST_COL_SET_VER);

                char_item = in_node.AddNode("CHAR_LIST");
                char_item.AddString("CHAR_ID", TEST_CHAR_1);

                unit_item = char_item.AddNode("UNIT_LIST");
                unit_item.AddString("UNIT_ID", "a");
                unit_item.AddInt("UNIT_SEQ_NUM", 1);

                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));

                char_item = in_node.AddNode("CHAR_LIST");
                char_item.AddString("CHAR_ID", TEST_CHAR_2);

                unit_item = char_item.AddNode("UNIT_LIST");
                unit_item.AddString("UNIT_ID", "a");
                unit_item.AddInt("UNIT_SEQ_NUM", 1);

                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));

                char_item = in_node.AddNode("CHAR_LIST");
                char_item.AddString("CHAR_ID", TEST_CHAR_3);

                unit_item = char_item.AddNode("UNIT_LIST");
                unit_item.AddString("UNIT_ID", "a");
                unit_item.AddInt("UNIT_SEQ_NUM", 1);

                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));

                char_item = in_node.AddNode("CHAR_LIST");
                char_item.AddString("CHAR_ID", TEST_CHAR_4);

                unit_item = char_item.AddNode("UNIT_LIST");
                unit_item.AddString("UNIT_ID", "a");
                unit_item.AddInt("UNIT_SEQ_NUM", 1);

                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));

                char_item = in_node.AddNode("CHAR_LIST");
                char_item.AddString("CHAR_ID", TEST_CHAR_5);

                unit_item = char_item.AddNode("UNIT_LIST");
                unit_item.AddString("UNIT_ID", "a");
                unit_item.AddInt("UNIT_SEQ_NUM", 1);

                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));
                value_item = unit_item.AddNode("VALUE_LIST"); value_item.AddString("VALUE", rv.Next(0, 100));


                if (MessageCaster.CallService("EDC", "EDC_Collect_Lot_Data", in_node, ref out_node) == false)
                {
                    if (mb_error_ignore_flag == false)
                    {
                        MessageBox.Show(MPMH.StatusMessage);
                    }
                    return false;
                }
                SetElapsedTimePerService(MsgHandler.MessageCaster.ExeTimeString);

                watch.Stop();
                al_edc_time.Add(watch.Elapsed.TotalSeconds);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool A06_Merge_Lot(string s_src_lot_id, string s_into_lot_id)
        {
            TRSNode in_node = new TRSNode("MERGE_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            Stopwatch watch;

            try
            {
                watch = new Stopwatch();
                watch.Start();

                MPCR.SetInMsg(in_node);
                in_node.UserID = "PFM_RUNNER_" + mi_thread_seq.ToString();

                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", s_src_lot_id);
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", 0);

                in_node.AddString("INTO_LOT_ID", s_into_lot_id);
                in_node.AddDouble("MOVE_QTY_1", 1);
                in_node.AddString("COMMENT", "Performance Test for Merging lot");

                if (MessageCaster.CallService("WIP", "WIP_Merge_Lot", in_node, ref out_node) == false)
                {
                    if (mb_error_ignore_flag == false)
                    {
                        MessageBox.Show(MPMH.StatusMessage);
                    }
                    return false;
                }
                SetElapsedTimePerService(MsgHandler.MessageCaster.ExeTimeString);

                watch.Stop();
                al_merge_time.Add(watch.Elapsed.TotalSeconds);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool A07_Resource_Event(string s_event_id)
        {
            TRSNode in_node = new TRSNode("RESOURCE_EVENT_IN");
            TRSNode out_node = new TRSNode("RESOURCE_EVENT_OUT");

            //Stopwatch watch;

            try
            {
                //watch = new Stopwatch();
                //watch.Start();

                MPCR.SetInMsg(in_node);
                in_node.UserID = "PFM_RUNNER_" + mi_thread_seq.ToString();

                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", ms_test_res_id);
                in_node.AddString("EVENT_ID", s_event_id);
                in_node.AddString("TRAN_COMMENT", "Performance Test for Resource Event");

                if (MessageCaster.CallService("RAS", "RAS_Resource_Event", in_node, ref out_node) == false)
                {
                    if (mb_error_ignore_flag == false)
                    {
                        MessageBox.Show(MPMH.StatusMessage);
                    }
                    return false;
                }
                SetElapsedTimePerService(MsgHandler.MessageCaster.ExeTimeString);

                //watch.Stop();
                //txtElapsedTime.Text = watch.Elapsed.TotalSeconds.ToString();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool A99_Delete_Lot_History(string s_lot_id)
        {
            TRSNode in_node = new TRSNode("DELETE_LOT_HISTORY_IN");
            TRSNode out_node = new TRSNode("DELETE_LOT_HISTORY_OUT");
            TRSNode LOT = new TRSNode("LOT_STATUS");

            //Stopwatch watch;

            try
            {
                //watch = new Stopwatch();
                //watch.Start();

                while (ViewLot(s_lot_id, LOT) == true)
                {
                    MPCR.SetInMsg(in_node);
                    in_node.UserID = "PFM_RUNNER_" + mi_thread_seq.ToString();

                    in_node.ProcStep = '1';
                    in_node.AddString("LOT_ID", s_lot_id);
                    in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                    in_node.AddString("COMMENT", "Performance Test for delete lot history");

                    if (MessageCaster.CallService("WIP", "WIP_Delete_Lot_History", in_node, ref out_node) == false)
                    {
                        if (mb_error_ignore_flag == false)
                        {
                            MessageBox.Show(MPMH.StatusMessage);
                        }
                        return false;
                    }

                    SetElapsedTimePerService(MsgHandler.MessageCaster.ExeTimeString);

                    in_node.Init();
                    out_node.Init();
                    LOT.Init();
                }

                //watch.Stop();
                //txtElapsedTime.Text = watch.Elapsed.TotalSeconds.ToString();

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
