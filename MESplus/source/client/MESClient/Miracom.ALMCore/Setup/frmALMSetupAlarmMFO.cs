//#If _ALM = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmALMSetupAlarm.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - View_Alarm_Msg() : View Lot Alarm Message
//       - View_Event() : View Event
//       - UpdateAlarmMsg() : Create/Update/Delete Lot Alarm Message
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2007-12-13 : Created by Aiden
//
//
//   Copyright(C) 1998-2007 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Miracom.UI.Controls;
using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;

using Miracom.TRSCore;

namespace Miracom.ALMCore
{
    public partial class frmALMSetupAlarmMFO : Miracom.MESCore.SetupForm02
    {
        public frmALMSetupAlarmMFO()
        {
            InitializeComponent();
        }

        #region "Constant Definition"
        private const char CHANGE = 'Y';
        private const string NOTCHANGE = "N";
        private const string INCREASE = "+";
        private const string DECREASE = "-";
        private const char OVERRIDE = 'O';
        private const string TIME = "T";

        private const string RCVR_USER = "User";
        private const string RCVR_SEC_GROUP = "Sec Group";
        private const string RCVR_PRV_GROUP = "Prv Group";

        #endregion

        #region " Variable Definition "

        private bool bLoadFlag;
        private char lm_res_rel_level;
        private string lm_res_type;
        private string lm_res_group;
        private string lm_res_id;

        #endregion

        #region " Function Definition "

        // CheckCondition()
        //       - check Create/Update/Delete condition
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String      : Function Name
        //       - Optional ByVal ProcStep As String        : Create/Update/Delete 구분??
        //
        private bool CheckCondition(char ProcStep)
        {
            if (MPCF.CheckValue(cdvAlarmID, 1) == false) return false;
            if (tabRelation.SelectedTab == tbpMFO)
            {
                if (udcMFO.SelectedItem != Miracom.MESCore.Controls.TreeSelectedItem.Oper)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    udcMFO.Focus();
                    return false;
                }
            }

            if (ProcStep == MPGC.MP_STEP_CREATE)
            {
                if (chkFromTime.Checked == true)
                {
                    if (MPCF.ToStandardTime(DateTime.Now, MPGC.MP_CONVERT_DATE_FORMAT).CompareTo(MPCF.ToStandardTime(dtpFromDate.Value, MPGC.MP_CONVERT_DATE_FORMAT)) > 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(177) + "\n" + "From Date");
                        dtpFromDate.Focus();
                        return false;
                    }
                    if (MPCF.ToStandardTime(DateTime.Now, MPGC.MP_CONVERT_DATETIME_FORMAT).CompareTo(MPCF.ToStandardTime(dtpFromDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpFromTime.Value, MPGC.MP_CONVERT_TIME_FORMAT)) > 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(177) + "\n" + "From Date Time");
                        dtpFromTime.Focus();
                        return false;
                    }
                }
            }

            switch (ProcStep)
            {
                case MPGC.MP_STEP_CREATE:
                case MPGC.MP_STEP_UPDATE:
                    if (chkToTime.Checked == true)
                    {
                        if (MPCF.ToStandardTime(DateTime.Now, MPGC.MP_CONVERT_DATE_FORMAT).CompareTo(MPCF.ToStandardTime(dtpToDate.Value, MPGC.MP_CONVERT_DATE_FORMAT)) > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(177) + "\n" + "To Date");
                            dtpToDate.Focus();
                            return false;
                        }
                        if (MPCF.ToStandardTime(DateTime.Now, MPGC.MP_CONVERT_DATETIME_FORMAT).CompareTo(MPCF.ToStandardTime(dtpToDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpToTime.Value, MPGC.MP_CONVERT_TIME_FORMAT)) > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(177) + "\n" + "To Date Time");
                            dtpToTime.Focus();
                            return false;
                        }
                    }

                    if (tabRelation.SelectedTab == tbpMFO)
                    {
                        if (rbtStart.Checked == false && rbtSplit.Checked == false && rbtEnd.Checked == false && rbtRework.Checked == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            rbtStart.Focus();
                            return false;
                        }
                    }

                    break;

                case MPGC.MP_STEP_DELETE:

                    break;
            }

            return true;

        }

        //
        // ViewAlarmMsg
        //       - View Alarm Message
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool ViewAlarmMsg()
        {
            TRSNode in_node = new TRSNode("VIEW_ALARM_MSG_IN");
            TRSNode out_node = new TRSNode("VIEW_ALARM_MSG_OUT");
            byte[] bt_buffer;

            MPCR.SetInMsg(in_node);
            
            in_node.ProcStep = '2';
            in_node.AddString("ALARM_ID", cdvAlarmID.Text);

            if (tabRelation.SelectedTab == tbpMFO)
            {
                in_node.AddChar("REL_LEVEL", udcMFO.SelectLevelChar);
                in_node.AddString("MAT_ID", udcMFO.MatID);
                in_node.AddInt("MAT_VER", udcMFO.MatVersion);
                in_node.AddString("FLOW", udcMFO.Flow);
                in_node.AddString("OPER", udcMFO.Oper);
                in_node.AddString("RES_TYPE", "");
                in_node.AddString("RESG_ID", "");
                in_node.AddString("RES_ID", "");

                if (chkRaiseAlarmAfterTran.Checked == true)
                {
                    if (rbtStart.Checked == true)
                        in_node.AddChar("TRAN_POINT", MPGC.MP_ALM_TRAN_START_AFTER);
                    else if (rbtSplit.Checked == true)
                        in_node.AddChar("TRAN_POINT", MPGC.MP_ALM_TRAN_SPLIT_AFTER);
                    else if (rbtEnd.Checked == true)
                        in_node.AddChar("TRAN_POINT", MPGC.MP_ALM_TRAN_END_AFTER);
                    else if (rbtRework.Checked == true)
                        in_node.AddChar("TRAN_POINT", MPGC.MP_ALM_TRAN_REWORK_AFTER);
                }
                else
                {
                    if (rbtStart.Checked == true)
                        in_node.AddChar("TRAN_POINT", MPGC.MP_ALM_TRAN_START);
                    else if (rbtSplit.Checked == true)
                        in_node.AddChar("TRAN_POINT", MPGC.MP_ALM_TRAN_SPLIT);
                    else if (rbtEnd.Checked == true)
                        in_node.AddChar("TRAN_POINT", MPGC.MP_ALM_TRAN_END);
                    else if (rbtRework.Checked == true)
                        in_node.AddChar("TRAN_POINT", MPGC.MP_ALM_TRAN_REWORK);
                }
            }
            else 
            {            
                in_node.AddChar("REL_LEVEL", lm_res_rel_level);
                in_node.AddString("MAT_ID", "");
                in_node.AddInt("MAT_VER", 0);
                in_node.AddString("FLOW", "");
                in_node.AddString("OPER", "");
                in_node.AddString("RES_TYPE", lm_res_type);
                in_node.AddString("RESG_ID", lm_res_group);
                in_node.AddString("RES_ID", lm_res_id); 
            }

            in_node.AddString("LOT_ID", txtLotID.Text);
            in_node.AddString("EVENT_ID", cdvEventID.Text);

            if (MPCR.CallService("ALM", "ALM_View_Alarm_Msg", in_node, ref out_node) == false)
            {                
                return false;
            }

            if (out_node.GetChar("ALARM_LEVEL_FLAG") == MPGC.MP_ALM_LEVEL_INFO)
            {
                rbnInformation.Checked = true;
            }
            else if (out_node.GetChar("ALARM_LEVEL_FLAG") == MPGC.MP_ALM_LEVEL_WARN)
            {
                rbnWarning.Checked = true;
            }
            else if (out_node.GetChar("ALARM_LEVEL_FLAG") == MPGC.MP_ALM_LEVEL_ERROR)
            {
                rbnError.Checked = true;
            }

            if (out_node.GetChar("SEND_TO_USER_FLAG") == 'Y')
            {
                chkSendToUser.Checked = true;
            }

            if (out_node.GetChar("ACTION_DISPLAY_FLAG") == 'Y')
            {
                chkDisplay.Checked = true;
            }

            if (out_node.GetChar("ACTION_MAIL_FLAG") == 'Y')
            {
                chkMail.Checked = true;
            }

            if (out_node.GetChar("ACTION_MSG_FLAG") == 'Y')
            {
                chkMessage.Checked = true;
            }

            if (out_node.GetString("ALARM_LOT_ACTION") == "FHLD")
                txtTran.Text = "FUTURE HOLD";
            else
                txtTran.Text = out_node.GetString("ALARM_LOT_ACTION");

            SetLotTran();

            if (out_node.GetString("ALARM_LOT_ACTION") == "HOLD")
            {
                txtHoldCode.Text = out_node.GetString("HOLD_CODE");
                txtHoldPassword.Text = out_node.GetString("HOLD_PASSWORD");

            }
            else if (out_node.GetString("ALARM_LOT_ACTION") == "FHLD")
            {
                txtHoldCode.Text = out_node.GetString("HOLD_CODE");
                txtHoldPassword.Text = out_node.GetString("HOLD_PASSWORD");
                cdvReworkFlow.Text = out_node.GetString("FLOW");
                cdvReworkFlow.Sequence = out_node.GetInt("FLOW_SEQ_NUM");
                cdvReworkOper.Text = out_node.GetString("OPER");
            }
            else if (out_node.GetString("ALARM_LOT_ACTION") == "REWORK")
            {
                txtHoldCode.Text = out_node.GetString("RWK_CODE");
                cdvReworkFlow.Text = out_node.GetString("RWK_FLOW");
                cdvReworkFlow.Sequence = out_node.GetInt("RWK_FLOW_SEQ_NUM");
                cdvReworkOper.Text = out_node.GetString("RWK_OPER");
                cdvReworkStopOper.Text = out_node.GetString("RWK_STOP_OPER");

                cdvReturnFlow.Text = out_node.GetString("RET_FLOW");
                cdvReworkFlow.Sequence = out_node.GetInt("RET_FLOW_SEQ_NUM");
                cdvReturnOper.Text = out_node.GetString("RET_OPER");

                switch (out_node.GetChar("RET_CLEAR_FLAG"))
                {
                    case 'Y': // Clear Rework
                        cboReturnOption.SelectedIndex = 1;
                        break;
                    case 'A': // Clear Rework and Move to Next Oper
                        cboReturnOption.SelectedIndex = 2;
                        break;
                    case 'B': // Keep Rework and Move to Next Oper
                        cboReturnOption.SelectedIndex = 3;
                        break;
                    default: // keep Rework
                        cboReturnOption.SelectedIndex = 0;
                        break;
                }

            }

            txtComment.Text = out_node.GetString("LOT_COMMENT");

            chkOverrideMsg.Checked = (out_node.GetChar("OVERRIDE_MSG_FLAG") == 'Y' ? true : false);
            txtSubject.Text = out_node.GetString("ALARM_SUBJECT");
            txtMsg1.Text = out_node.GetString("ALARM_MSG_1");
            txtMsg2.Text = out_node.GetString("ALARM_MSG_2");
            txtMsg3.Text = out_node.GetString("ALARM_MSG_3");
                        
            // Alarm Comment
            chkOverrideComment.Checked = (out_node.GetChar("OVERRIDE_COMMENT_FLAG") == 'Y' ? true : false);
            spdComment.ActiveSheet.Cells[0, 0].Value = out_node.GetString("ALARM_COMMENT_1");
            spdComment.ActiveSheet.Cells[1, 0].Value = out_node.GetString("ALARM_COMMENT_2");
            spdComment.ActiveSheet.Cells[2, 0].Value = out_node.GetString("ALARM_COMMENT_3");
            spdComment.ActiveSheet.Cells[3, 0].Value = out_node.GetString("ALARM_COMMENT_4");
            spdComment.ActiveSheet.Cells[4, 0].Value = out_node.GetString("ALARM_COMMENT_5");

            // Image File
            chkOverrideImg.Checked = (out_node.GetChar("OVERRIDE_IMAGE_FLAG") == 'Y' ? true : false);
            picImage.Image = null;
            picImage.Tag = ' ';

            if ((bt_buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_1)) != null)
            {
                MemoryStream ms_buffer;

                try
                {
                    ms_buffer = new MemoryStream();
                    ms_buffer.Write(bt_buffer, 0, bt_buffer.Length);
                    ms_buffer.Position = 0;

                    picImage.Image = Image.FromStream(ms_buffer);
                    picImage.Image.Tag = bt_buffer;
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
            }

            // PDF File
            chkOverridePDF.Checked = (out_node.GetChar("OVERRIDE_PDF_FLAG") == 'Y' ? true : false);

            spdEvent.ActiveSheet.Cells[0, 0].Value = out_node.GetString("EVENT_ID");
            spdEvent.ActiveSheet.Cells[1, 0].Value = out_node.GetString("CHG_STS_1");
            spdEvent.ActiveSheet.Cells[2, 0].Value = out_node.GetString("CHG_STS_2");
            spdEvent.ActiveSheet.Cells[3, 0].Value = out_node.GetString("CHG_STS_3");
            spdEvent.ActiveSheet.Cells[4, 0].Value = out_node.GetString("CHG_STS_4");
            spdEvent.ActiveSheet.Cells[5, 0].Value = out_node.GetString("CHG_STS_5");
            spdEvent.ActiveSheet.Cells[6, 0].Value = out_node.GetString("CHG_STS_6");
            spdEvent.ActiveSheet.Cells[7, 0].Value = out_node.GetString("CHG_STS_7");
            spdEvent.ActiveSheet.Cells[8, 0].Value = out_node.GetString("CHG_STS_8");
            spdEvent.ActiveSheet.Cells[9, 0].Value = out_node.GetString("CHG_STS_9");
            spdEvent.ActiveSheet.Cells[10, 0].Value = out_node.GetString("CHG_STS_10");
            spdEvent.ActiveSheet.Cells[11, 0].Value = out_node.GetString("RES_COMMENT");

            spdClearEvent.ActiveSheet.Cells[0, 0].Value = out_node.GetString("CLEAR_EVENT_ID");
            spdClearEvent.ActiveSheet.Cells[1, 0].Value = out_node.GetString("CLEAR_CHG_STS_1");
            spdClearEvent.ActiveSheet.Cells[2, 0].Value = out_node.GetString("CLEAR_CHG_STS_2");
            spdClearEvent.ActiveSheet.Cells[3, 0].Value = out_node.GetString("CLEAR_CHG_STS_3");
            spdClearEvent.ActiveSheet.Cells[4, 0].Value = out_node.GetString("CLEAR_CHG_STS_4");
            spdClearEvent.ActiveSheet.Cells[5, 0].Value = out_node.GetString("CLEAR_CHG_STS_5");
            spdClearEvent.ActiveSheet.Cells[6, 0].Value = out_node.GetString("CLEAR_CHG_STS_6");
            spdClearEvent.ActiveSheet.Cells[7, 0].Value = out_node.GetString("CLEAR_CHG_STS_7");
            spdClearEvent.ActiveSheet.Cells[8, 0].Value = out_node.GetString("CLEAR_CHG_STS_8");
            spdClearEvent.ActiveSheet.Cells[9, 0].Value = out_node.GetString("CLEAR_CHG_STS_9");
            spdClearEvent.ActiveSheet.Cells[10, 0].Value = out_node.GetString("CLEAR_CHG_STS_10");
            spdClearEvent.ActiveSheet.Cells[11, 0].Value = out_node.GetString("CLEAR_RES_COMMENT");

            cdvCMF1.Text = out_node.GetString("CMF_1");
            cdvCMF2.Text = out_node.GetString("CMF_2");
            cdvCMF3.Text = out_node.GetString("CMF_3");
            cdvCMF4.Text = out_node.GetString("CMF_4");
            cdvCMF5.Text = out_node.GetString("CMF_5");
            cdvCMF6.Text = out_node.GetString("CMF_6");
            cdvCMF7.Text = out_node.GetString("CMF_7");
            cdvCMF8.Text = out_node.GetString("CMF_8");
            cdvCMF9.Text = out_node.GetString("CMF_9");
            cdvCMF10.Text = out_node.GetString("CMF_10");
            cdvCMF11.Text = out_node.GetString("CMF_11");
            cdvCMF12.Text = out_node.GetString("CMF_12");
            cdvCMF13.Text = out_node.GetString("CMF_13");
            cdvCMF14.Text = out_node.GetString("CMF_14");
            cdvCMF15.Text = out_node.GetString("CMF_15");
            cdvCMF16.Text = out_node.GetString("CMF_16");
            cdvCMF17.Text = out_node.GetString("CMF_17");
            cdvCMF18.Text = out_node.GetString("CMF_18");
            cdvCMF19.Text = out_node.GetString("CMF_19");
            cdvCMF20.Text = out_node.GetString("CMF_20");

            ViewAlarmReceiverList();

            return true;

        }

        //
        // ViewAlarmReceiverList
        //       - View Alarm Receiver List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool ViewAlarmReceiverList()
        {
            TRSNode in_node = new TRSNode("VIEW_ALARM_RECEIVER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_ALARM_RECEIVER_LIST_OUT");

            MPCF.InitListView(lisRecvList);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ALARM_ID", cdvAlarmID.Text);

            if (MPCR.CallService("ALM", "ALM_View_Alarm_Receiver_List", in_node, ref out_node) == false)
            {               
                return false;
            }

            List<TRSNode> rcvr_list;
            ListViewItem itm;
            int i;
            int ii;
            int i_icon_index;
            string s_rcvr_type;

            i_icon_index = (int)SMALLICON_INDEX.IDX_USER;
            s_rcvr_type = "";

            rcvr_list = out_node.GetList("RCVR_LIST");
            for (i = 0; i < rcvr_list.Count; i++)
            {
                switch (rcvr_list[i].GetChar("REL_LEVEL"))
                {
                    case 'U':
                        i_icon_index = (int)SMALLICON_INDEX.IDX_USER;
                        s_rcvr_type = RCVR_USER;
                        break;
                    case 'S':
                        i_icon_index = (int)SMALLICON_INDEX.IDX_SEC_GROUP;
                        s_rcvr_type = RCVR_SEC_GROUP;
                        break;
                    case 'P':
                        i_icon_index = (int)SMALLICON_INDEX.IDX_PRIVILEGE_GROUP;
                        s_rcvr_type = RCVR_PRV_GROUP;
                        break;
                }

                itm = new ListViewItem(rcvr_list[i].GetString("RCVR_ID"), i_icon_index);
                itm.SubItems.Add(s_rcvr_type);
                itm.SubItems.Add("");

                for (ii = 0; ii < rcvr_list[i].GetString("RCV_SHIFT").Length; ii++)
                {
                    if (rcvr_list[i].GetString("RCV_SHIFT")[ii] != '_')
                        itm.SubItems[2].Text += ((int)(ii + 1)).ToString();
                    else
                        itm.SubItems[2].Text += "_";
                }
                lisRecvList.Items.Add(itm);
            }

            lisRecvList.ListViewItemSorter = new ListViewItemComparer(1, SortOrder.Descending, ListViewItemComparer.SORTING_OPTION.STRING_TYPE);
            lisRecvList.Sort();
            lisRecvList.ListViewItemSorter = null;

            return true;

        }

        //
        // ViewAlarmRelationList
        //       - View Alarm Relation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool ViewAlarmRelationList(char c_rel_level, string s_mat_id, int i_mat_ver, string s_flow, string s_oper, string s_res_type, string s_res_grp, string s_res_id)
        {
            TRSNode in_node = new TRSNode("VIEW_ALARM_RELATION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_ALARM_RELATION_LIST_OUT");

            MPCF.InitListView(lisAlarmList);
            MPCF.InitListView(lisResAlarmList);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddChar("REL_LEVEL", c_rel_level);
            in_node.AddString("MAT_ID", s_mat_id);
            in_node.AddInt("MAT_VER", i_mat_ver);
            in_node.AddString("FLOW", s_flow);
            in_node.AddString("OPER", s_oper);
            in_node.AddString("RES_TYPE", s_res_type);
            in_node.AddString("RESG_ID", s_res_grp);
            in_node.AddString("RES_ID", s_res_id);

            in_node.AddString("ALARM_ID", cdvAlarmID.Text);

            if (MPCR.CallService("ALM", "ALM_View_Alarm_Relation_List", in_node, ref out_node) == false)
            {                
                return false;
            }

            List<TRSNode> alarm_list;
            ListViewItem itm;
            int i;
            string s_temp;

            alarm_list = out_node.GetList("ALARM_LIST");
            for (i = 0; i < alarm_list.Count; i++)
            {
                itm = new ListViewItem(alarm_list[i].GetString("ALARM_ID"), (int)SMALLICON_INDEX.IDX_ALARM);

                switch (alarm_list[i].GetChar("ALARM_LEVEL"))
                {
                    case MPGC.MP_ALM_LEVEL_INFO:
                        itm.SubItems.Add("Information");
                        break;
                    case MPGC.MP_ALM_LEVEL_WARN:
                        itm.SubItems.Add("Warning");
                        break;
                    case MPGC.MP_ALM_LEVEL_ERROR:
                        itm.SubItems.Add("Error");
                        break;
                    default:
                        itm.SubItems.Add("");
                        break;
                }

                if (tabRelation.SelectedTab == tbpMFO)
                {
                    switch (alarm_list[i].GetChar("TRAN_POINT"))
                    {
                        case MPGC.MP_ALM_TRAN_START:
                            itm.SubItems.Add("Start");
                            break;
                        case MPGC.MP_ALM_TRAN_SPLIT:
                            itm.SubItems.Add("Split");
                            break;
                        case MPGC.MP_ALM_TRAN_END:
                            itm.SubItems.Add("End");
                            break;
                        case MPGC.MP_ALM_TRAN_REWORK:
                            itm.SubItems.Add("Rework");
                            break;
                        case MPGC.MP_ALM_TRAN_START_AFTER:
                            itm.SubItems.Add("After Start");
                            break;
                        case MPGC.MP_ALM_TRAN_SPLIT_AFTER:
                            itm.SubItems.Add("After Split");
                            break;
                        case MPGC.MP_ALM_TRAN_END_AFTER:
                            itm.SubItems.Add("After End");
                            break;
                        case MPGC.MP_ALM_TRAN_REWORK_AFTER:
                            itm.SubItems.Add("After Rework");
                            break;
                    }

                    itm.SubItems.Add(alarm_list[i].GetString("LOT_ID"));
                    itm.SubItems[3].Tag = alarm_list[i].GetChar("INHERIT_CHILD_FLAG");                    
                }
                else
                {
                    itm.SubItems.Add(alarm_list[i].GetString("EVENT_ID"));
                    itm.SubItems[2].Tag = alarm_list[i].GetChar("NEED_CONFIRM_FLAG");
                }

                s_temp = "";
                if (alarm_list[i].GetString("APPLY_FROM_TIME") != "" || alarm_list[i].GetString("APPLY_TO_TIME") != "")
                {
                    s_temp = MPCF.MakeDateFormat(alarm_list[i].GetString("APPLY_FROM_TIME")) + " ~ " + MPCF.MakeDateFormat(alarm_list[i].GetString("APPLY_TO_TIME"));
                }
                itm.SubItems.Add(s_temp);
                
                s_temp = (alarm_list[i].GetString("APPLY_FROM_TIME") == "" ? "              " : alarm_list[i].GetString("APPLY_FROM_TIME")) + ";" +
                         (alarm_list[i].GetString("APPLY_TO_TIME") == "" ? "              " : alarm_list[i].GetString("APPLY_TO_TIME"));
                itm.SubItems[1].Tag = s_temp;

                if (tabRelation.SelectedTab == tbpMFO)
                    lisAlarmList.Items.Add(itm);
                else
                    lisResAlarmList.Items.Add(itm);

            }

            return true;

        }

        private void InitResourceTree()
        {
            MPCF.InitTreeView(tvResList);

            if (rbtFactory.Checked == true)
            {
                TreeNode node;
                node = tvResList.Nodes.Add(MPGV.gsFactory);
                node.ImageIndex = (int)SMALLICON_INDEX.IDX_FACTORY;
                node.SelectedImageIndex = (int)SMALLICON_INDEX.IDX_FACTORY;
                node.Expand();
            }
            else if (rbtResType.Checked == true)
            {
                if (BASLIST.ViewGCMDataList(tvResList, '1', MPGC.MP_RAS_RES_TYPE) == false) return;
            }
            else if (rbtResGroup.Checked == true)
            {
                if (RASLIST.ViewResourceGroupList(tvResList, '1') == false) return;
            }
        }

        private void ViewResourceItem(TreeNode ParentNode)
        {
            string s_resg_id = "";
            string s_res_type = "";

            if (rbtResType.Checked == true)
            {
                s_res_type = MPCF.Trim(ParentNode.Text);
                s_res_type = MPCF.SubtractString(s_res_type, ":", false, false);
            }
            else if (rbtResGroup.Checked == true)
            {
                s_resg_id = MPCF.Trim(ParentNode.Text);
                s_resg_id = MPCF.SubtractString(s_resg_id, ":", false, false);
            }

            if (RASLIST.ViewResourceList(tvResList, '1', s_resg_id, s_res_type, "", "", "", 0, "", "", ' ', "", false, ParentNode, "") == false) return;
            ParentNode.Expand();
        }


        //
        // ViewMFOSettingDataList()
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

            StringBuilder sb;

            MPCF.InitListView(udcMFO.GetListView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            sb = new StringBuilder();

            switch (udcMFO.SelectLevel)
            {
                case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                    sb.Append("SELECT MAT_ID, MAT_VER, FLOW, OPER FROM MALMMFORES ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, FLOW, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                    sb.Append("SELECT MAT_ID, MAT_VER, OPER FROM MALMMFORES ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW = ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                    sb.Append("SELECT FLOW, OPER FROM MALMMFORES ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY FLOW, OPER ");
                    sb.Append("ORDER BY FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.O:
                    sb.Append("SELECT OPER FROM MALMMFORES ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW = ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY OPER ");
                    sb.Append("ORDER BY OPER ASC");
                    break;

            }

            in_node.AddString("SQL", sb.ToString());

            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {                    
                    return false;
                }

                MPCR.FillDataView(udcMFO.GetListView, out_node, false, (int)SMALLICON_INDEX.IDX_MODULE, false);

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
        private bool ViewResourceSettingDataList()
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            StringBuilder sb;
            char[] c_rel_level;

            MPCF.InitListView(lisResList);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            c_rel_level = new char[2];
            c_rel_level[0] = ' ';
            c_rel_level[1] = ' ';
            
            if (rbtFactory.Checked == true)
            {
                c_rel_level[0] = 'F';
            }
            else if (rbtResType.Checked == true)
            {
                c_rel_level[0] = 'T';
                c_rel_level[1] = 'R';
            }
            else if (rbtResGroup.Checked == true)
            {
                c_rel_level[0] = 'G';
                c_rel_level[1] = 'R';
            }

            sb = new StringBuilder();

            sb.Append("SELECT FACTORY, RES_TYPE, RESG_ID, RES_ID FROM MALMMFORES ");
            sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
            sb.Append("AND REL_LEVEL IN ('" + c_rel_level[0].ToString() + "', '" + c_rel_level[1].ToString() + "' ) ");
            sb.Append("GROUP BY FACTORY, RES_TYPE, RESG_ID, RES_ID ");
            sb.Append("ORDER BY FACTORY, RES_TYPE, RESG_ID, RES_ID");

            in_node.AddString("SQL", sb.ToString());

            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {                    
                    return false;
                }

                MPCR.FillDataView(lisResList, out_node, false, (int)SMALLICON_INDEX.IDX_MODULE, false);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (in_node.GetInt("NEXT_ROW") > 0);

            return true;
        }


        private bool UpdateAlarmRelation(char ProcStep)
        {
            TRSNode in_node = new TRSNode("UPDATE_ALARM_RELATION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                if (tabRelation.SelectedTab == tbpMFO)
                {
                    in_node.AddChar("REL_LEVEL", udcMFO.SelectLevelChar);
                    in_node.AddString("MAT_ID", udcMFO.MatID);
                    in_node.AddInt("MAT_VER", udcMFO.MatVersion);
                    in_node.AddString("FLOW", udcMFO.Flow);
                    in_node.AddString("OPER", udcMFO.Oper);

                    in_node.AddString("LOT_ID", txtLotID.Text);
                    in_node.AddChar("INHERIT_CHILD_FLAG", (chkInheritChild.Checked ? 'Y' : ' '));

                    if (chkRaiseAlarmAfterTran.Checked == true)
                    {
                        if (rbtStart.Checked == true)
                            in_node.AddChar("TRAN_POINT", MPGC.MP_ALM_TRAN_START_AFTER);
                        else if (rbtSplit.Checked == true)
                            in_node.AddChar("TRAN_POINT", MPGC.MP_ALM_TRAN_SPLIT_AFTER);
                        else if (rbtEnd.Checked == true)
                            in_node.AddChar("TRAN_POINT", MPGC.MP_ALM_TRAN_END_AFTER);
                        else if (rbtRework.Checked == true)
                            in_node.AddChar("TRAN_POINT", MPGC.MP_ALM_TRAN_REWORK_AFTER);
                    }
                    else
                    {
                        if (rbtStart.Checked == true)
                            in_node.AddChar("TRAN_POINT", MPGC.MP_ALM_TRAN_START);
                        else if (rbtSplit.Checked == true)
                            in_node.AddChar("TRAN_POINT", MPGC.MP_ALM_TRAN_SPLIT);
                        else if (rbtEnd.Checked == true)
                            in_node.AddChar("TRAN_POINT", MPGC.MP_ALM_TRAN_END);
                        else if (rbtRework.Checked == true)
                            in_node.AddChar("TRAN_POINT", MPGC.MP_ALM_TRAN_REWORK);
                    }
                }
                else
                {
                    in_node.AddChar("REL_LEVEL", lm_res_rel_level);
                    in_node.AddString("RES_TYPE", lm_res_type);
                    in_node.AddString("RESG_ID", lm_res_group);
                    in_node.AddString("RES_ID", lm_res_id);

                    in_node.AddString("EVENT_ID", cdvEventID.Text);
                    in_node.AddChar("NEED_CONFIRM_FLAG", (chkNeedConfirm.Checked ? 'Y' : ' '));
                }

                in_node.AddString("ALARM_ID", cdvAlarmID.Text);

                if (chkFromTime.Checked == true)
                    in_node.AddString("APPLY_FROM_TIME", MPCF.ToStandardTime(dtpFromDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpFromTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));

                if (chkToTime.Checked == true)
                    in_node.AddString("APPLY_TO_TIME", MPCF.ToStandardTime(dtpToDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpToTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                
                if (chkOverrideMsg.Checked == true)
                {
                    in_node.AddChar("OVERRIDE_MSG_FLAG", "Y");
                    in_node.AddString("ALARM_SUBJECT", MPCF.Trim(txtSubject.Text));
                    in_node.AddString("ALARM_MSG_1", MPCF.Trim(txtMsg1.Text));
                    in_node.AddString("ALARM_MSG_2", MPCF.Trim(txtMsg2.Text));
                    in_node.AddString("ALARM_MSG_3", MPCF.Trim(txtMsg3.Text));
                }

                if (chkOverrideComment.Checked == true)
                {
                    in_node.AddChar("OVERRIDE_COMMENT_FLAG", "Y");
                    in_node.AddString("ALARM_COMMENT_1", MPCF.Trim(spdComment.ActiveSheet.Cells[0, 0].Value));
                    in_node.AddString("ALARM_COMMENT_2", MPCF.Trim(spdComment.ActiveSheet.Cells[1, 0].Value));
                    in_node.AddString("ALARM_COMMENT_3", MPCF.Trim(spdComment.ActiveSheet.Cells[2, 0].Value));
                    in_node.AddString("ALARM_COMMENT_4", MPCF.Trim(spdComment.ActiveSheet.Cells[3, 0].Value));
                    in_node.AddString("ALARM_COMMENT_5", MPCF.Trim(spdComment.ActiveSheet.Cells[4, 0].Value));
                }

                if (chkOverrideImg.Checked == true)
                {
                    byte[] img_buffer;

                    img_buffer = null;
                    if (picImage.Image != null)
                    {
                        img_buffer = (byte[])picImage.Image.Tag;
                    }
                    in_node.AddBlob(MPGC.MP_BIN_DATA_1, img_buffer);
                    in_node.AddChar("OVERRIDE_IMAGE_FLAG", "Y");
                }

                if (chkOverridePDF.Checked == true)
                {
                    //byte[] img_buffer;

                    //img_buffer = null;
                    //if (picImage.Image != null)
                    //{
                    //    img_buffer = (byte[])picImage.Image.Tag;
                    //}
                    //in_node.AddBlob(MPGC.MP_BIN_DATA_2, img_buffer);
                    in_node.AddChar("OVERRIDE_PDF_FLAG", "Y");
                }

                
                if (MPCR.CallService("ALM", "ALM_Update_Alarm_Relation", in_node, ref out_node) == false)
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

        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.cdvAlarmID;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }


        //
        // SetLotTran()
        //       - Set Field For Each Tran
        // Return Value
        //       - Void
        // Arguments
        //
        private void SetLotTran()
        {
            lblHoldCode.Visible = false;
            txtHoldCode.Visible = false;
            lblHoldPassword.Visible = false;
            txtHoldPassword.Visible = false;
            cdvReworkFlow.Visible = false;
            cdvReworkOper.Visible = false;
            cdvReworkStopOper.Visible = false;
            cdvReturnFlow.Visible = false;
            cdvReturnOper.Visible = false;
            lblReturnOption.Visible = false;
            cboReturnOption.Visible = false;
            grpCMF.Visible = false;

            txtHoldCode.Text = "";
            txtHoldPassword.Text = "";
            cdvReworkFlow.ClearField();
            cdvReworkOper.ClearField();
            cdvReworkStopOper.ClearField();
            cdvReturnFlow.ClearField();
            cdvReturnOper.ClearField();
            cboReturnOption.SelectedIndex = 0;
            txtComment.Text = "";

            if (MPCF.Trim(txtTran.Text) == "HOLD")
            {
                lblHoldCode.Text = MPCF.FindLanguage("Hold Code", CAPTION_TYPE.LABEL);

                lblHoldCode.Visible = true;
                txtHoldCode.Visible = true;
                lblHoldPassword.Visible = true;
                txtHoldPassword.Visible = true;
                grpCMF.Visible = true;
            }
            else if (MPCF.Trim(txtTran.Text) == "FUTURE HOLD")
            {
                lblHoldCode.Text = MPCF.FindLanguage("Hold Code", CAPTION_TYPE.LABEL);

                lblHoldCode.Visible = true;
                txtHoldCode.Visible = true;
                lblHoldPassword.Visible = true;
                txtHoldPassword.Visible = true;
                cdvReworkFlow.Visible = true;
                cdvReworkOper.Visible = true;
                grpCMF.Visible = true;

                cdvReworkFlow.LabelText = MPCF.FindLanguage("Flow", CAPTION_TYPE.LABEL);
                cdvReworkOper.LabelText = MPCF.FindLanguage("Operation", CAPTION_TYPE.LABEL);
            }
            else if (MPCF.Trim(txtTran.Text) == "REWORK")
            {
                lblHoldCode.Text = MPCF.FindLanguage("Rework Code", CAPTION_TYPE.LABEL);

                lblHoldCode.Visible = true;
                txtHoldCode.Visible = true;
                cdvReworkFlow.Visible = true;
                cdvReworkOper.Visible = true;
                cdvReworkStopOper.Visible = true;
                cdvReturnFlow.Visible = true;
                cdvReturnOper.Visible = true;
                lblReturnOption.Visible = true;
                cboReturnOption.Visible = true;
                grpCMF.Visible = true;

                cdvReworkFlow.LabelText = MPCF.FindLanguage("Rework Flow", CAPTION_TYPE.LABEL);
                cdvReworkOper.LabelText = MPCF.FindLanguage("Rework Operation", CAPTION_TYPE.LABEL);
            }

            if (MPCF.Trim(txtTran.Text) == "HOLD" || MPCF.Trim(txtTran.Text) == "FUTURE HOLD")
            {
                MPCR.SetCMFItem(MPGC.MP_CMF_TRN_HOLD, "lblCMF", "cdvCMF", grpCMF);
            }
            else if (MPCF.Trim(txtTran.Text) == "REWORK")
            {
                MPCR.SetCMFItem(MPGC.MP_CMF_TRN_REWORK, "lblCMF", "cdvCMF", grpCMF);
            }
        }

        #endregion

        private void frmALMSetupAlarmMFO_Load(object sender, EventArgs e)
        {
            // 2010.02.08
            // 현재 무료 PDF Viewer 가 없으므로 한시적으로 tbpPDF Tab 은 보이지 않도록 한다.
            tabAlarm.TabPages.Remove(tbpPDF);
        }

        private void frmALMSetupAlarmMFO_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (bLoadFlag == false)
                {
                    MPCF.FieldClear(this);
                    MPCF.InitListView(lisAlarmList);
                    MPCF.InitListView(lisResAlarmList);
                    MPCF.InitListView(lisRecvList);

                    dtpFromDate.Value = DateTime.Now;
                    dtpFromTime.Value = DateTime.Now;
                    dtpToDate.Value = DateTime.Now.AddMonths(1);
                    dtpToTime.Value = DateTime.Now.AddMonths(1);

                    tabRelation_SelectedIndexChanged(null, null);

                    rbtFactory.Checked = true;

                    bLoadFlag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            udcMFO.GetNext(txtFind.Text);
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && MPCF.Trim(txtFind.Text) != "")
            {
                btnNext_Click(null, null);
            }
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            if (tabRelation.SelectedTab == tbpMFO)
                udcMFO.RefreshSelectedList();
            else
                chkOnlySettingData_CheckedChanged(null, null);
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            if (tabRelation.SelectedTab == tbpMFO)
                MPCF.ExportToExcel(lisAlarmList, this.Text, "");
            else
                MPCF.ExportToExcel(lisResAlarmList, this.Text, "");
        }

        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (CheckCondition(MPGC.MP_STEP_CREATE) == false) return;

                if (UpdateAlarmRelation(MPGC.MP_STEP_CREATE) == false) return;

                if (tabRelation.SelectedTab == tbpMFO)
                    ViewAlarmRelationList(udcMFO.SelectLevelChar, udcMFO.MatID, udcMFO.MatVersion, udcMFO.Flow, udcMFO.Oper, "", "", "");
                else
                    ViewAlarmRelationList(lm_res_rel_level, "", 0, "", "", lm_res_type, lm_res_group, lm_res_id);

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
                if (CheckCondition(MPGC.MP_STEP_UPDATE) == false) return;

                if (UpdateAlarmRelation(MPGC.MP_STEP_UPDATE) == false) return;

                if (tabRelation.SelectedTab == tbpMFO)
                    ViewAlarmRelationList(udcMFO.SelectLevelChar, udcMFO.MatID, udcMFO.MatVersion, udcMFO.Flow, udcMFO.Oper, "", "", "");
                else
                    ViewAlarmRelationList(lm_res_rel_level, "", 0, "", "", lm_res_type, lm_res_group, lm_res_id);

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
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;
                if (CheckCondition(MPGC.MP_STEP_DELETE) == false) return;

                if (UpdateAlarmRelation(MPGC.MP_STEP_DELETE) == false) return;

                if (tabRelation.SelectedTab == tbpMFO)
                    ViewAlarmRelationList(udcMFO.SelectLevelChar, udcMFO.MatID, udcMFO.MatVersion, udcMFO.Flow, udcMFO.Oper, "", "", "");
                else
                    ViewAlarmRelationList(lm_res_rel_level, "", 0, "", "", lm_res_type, lm_res_group, lm_res_id);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }
        
        private void lisAlarmList_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            string s_datetime;

            if (lisAlarmList.SelectedItems.Count > 0)
            {
                cdvAlarmID.Text = lisAlarmList.SelectedItems[0].Text;

                chkInheritChild.Checked = false;
                chkFromTime.Checked = false;
                chkToTime.Checked = false;

                s_datetime = lisAlarmList.SelectedItems[0].SubItems[1].Tag.ToString().Substring(0, 14).Trim();
                if (s_datetime != "")
                {
                    dtpFromDate.Value = MPCF.ToDate(s_datetime);
                    dtpFromTime.Value = dtpFromDate.Value;
                    chkFromTime.Checked = true;
                }
                s_datetime = lisAlarmList.SelectedItems[0].SubItems[1].Tag.ToString().Substring(15, 14).Trim();
                if (s_datetime != "")
                {
                    dtpToDate.Value = MPCF.ToDate(s_datetime);
                    dtpToDate.Value = dtpToDate.Value;
                    chkToTime.Checked = true;
                }

                chkRaiseAlarmAfterTran.Checked = false;
                switch (MPCF.Trim(lisAlarmList.SelectedItems[0].SubItems[2].Text))
                {
                    case "Start":
                        rbtStart.Checked = true;
                        break;
                    case "Split":
                        rbtSplit.Checked = true;
                        break;
                    case "End":
                        rbtEnd.Checked = true;
                        break;
                    case "Rework":
                        rbtRework.Checked = true;
                        break;
                    case "After Start":
                        rbtStart.Checked = true;
                        chkRaiseAlarmAfterTran.Checked = true;
                        break;
                    case "After Split":
                        rbtSplit.Checked = true;
                        chkRaiseAlarmAfterTran.Checked = true;
                        break;
                    case "After End":
                        rbtEnd.Checked = true;
                        chkRaiseAlarmAfterTran.Checked = true;
                        break;
                    case "After Rework":
                        rbtRework.Checked = true;
                        chkRaiseAlarmAfterTran.Checked = true;
                        break;
                }

                txtLotID.Text = MPCF.Trim(lisAlarmList.SelectedItems[0].SubItems[3].Text);
                if (MPCF.Trim(lisAlarmList.SelectedItems[0].SubItems[3].Tag) != "")
                    chkInheritChild.Checked = true;

                MPCF.FieldClear(this.grpAlarmInfo);
                ViewAlarmMsg();

            }
        }

        private void lisResAlarmList_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            string s_datetime;

            if (lisResAlarmList.SelectedItems.Count > 0)
            {
                cdvAlarmID.Text = lisResAlarmList.SelectedItems[0].Text;

                chkNeedConfirm.Checked = false;
                chkFromTime.Checked = false;
                chkToTime.Checked = false;

                s_datetime = lisResAlarmList.SelectedItems[0].SubItems[1].Tag.ToString().Substring(0, 14).Trim();
                if (s_datetime != "")
                {
                    dtpFromDate.Value = MPCF.ToDate(s_datetime);
                    dtpFromTime.Value = dtpFromDate.Value;
                    chkFromTime.Checked = true;
                }
                s_datetime = lisResAlarmList.SelectedItems[0].SubItems[1].Tag.ToString().Substring(15, 14).Trim();
                if (s_datetime != "")
                {
                    dtpToDate.Value = MPCF.ToDate(s_datetime);
                    dtpToDate.Value = dtpToDate.Value;
                    chkToTime.Checked = true;
                }

                cdvEventID.Text = MPCF.Trim(lisResAlarmList.SelectedItems[0].SubItems[2].Text);
                if (MPCF.Trim(lisResAlarmList.SelectedItems[0].SubItems[2].Tag) != "")
                    chkNeedConfirm.Checked = true;

                cdvEventID_SelectedItemChanged(null, null);

                MPCF.FieldClear(this.grpAlarmInfo);
                ViewAlarmMsg();

            }
        }

        private void tabRelation_SelectedIndexChanged(object sender, EventArgs e)
        {
            MPCF.FieldClear(grpCondition);
            MPCF.FieldClear(grpAlarmInfo);
            MPCF.InitListView(lisAlarmList);
            MPCF.InitListView(lisResAlarmList);
            MPCF.InitListView(lisRecvList);

            spdComment.ActiveSheet.Cells[0, 0].Value = "";
            spdComment.ActiveSheet.Cells[1, 0].Value = "";
            spdComment.ActiveSheet.Cells[2, 0].Value = "";
            spdComment.ActiveSheet.Cells[3, 0].Value = "";
            spdComment.ActiveSheet.Cells[4, 0].Value = "";

            if (tabRelation.SelectedTab == tbpRes)
            {
                lisAlarmList.Visible = false;
                lisResAlarmList.Visible = true;
                pnlLotAlarm.Visible = false;
                pnlResAlarm.Visible = true;
            }
            else
            {
                lisAlarmList.Visible = true;
                lisResAlarmList.Visible = false;
                pnlLotAlarm.Visible = true;
                pnlResAlarm.Visible = false;
            }
        }

        private void chkFromTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFromTime.Checked == true)
            {
                dtpFromDate.Enabled = true;
                dtpFromTime.Enabled = true;
            }
            else
            {
                dtpFromDate.Enabled = false;
                dtpFromTime.Enabled = false;
            }
        }

        private void chkToTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkToTime.Checked == true)
            {
                dtpToDate.Enabled = true;
                dtpToTime.Enabled = true;
            }
            else
            {
                dtpToDate.Enabled = false;
                dtpToTime.Enabled = false;
            }
        }

        private void cdvAlarmID_ButtonPress(object sender, EventArgs e)
        {
            cdvAlarmID.Init();
            MPCF.InitListView(cdvAlarmID.GetListView);
            cdvAlarmID.Columns.Add("Alarm ID", 50, HorizontalAlignment.Left);
            cdvAlarmID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvAlarmID.SelectedSubItemIndex = 0;
            ALMLIST.ViewAlarmMsgList(cdvAlarmID.GetListView, '1', (chkOnlyNormal.Checked == true ? 'N' : ' '));
        }

        private void cdvAlarmID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.FieldClear(this.grpCondition, cdvAlarmID, chkOnlyNormal);
            MPCF.FieldClear(this.grpAlarmInfo);
            ViewAlarmMsg();
        }

        private void chkOnlyNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOnlyNormal.Checked == true)
            {
                cdvAlarmID.Text = "";
                MPCF.FieldClear(this.grpAlarmInfo);
                MPCF.InitListView(lisRecvList);
            }
        }

        private void cdvEventID_ButtonPress(object sender, EventArgs e)
        {
            cdvEventID.Init();
            MPCF.InitListView(cdvEventID.GetListView);
            cdvEventID.Columns.Add("Event ID", 50, HorizontalAlignment.Left);
            cdvEventID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvEventID.SelectedSubItemIndex = 0;
            RASLIST.ViewEventList(cdvEventID.GetListView, '1', "", null, "");
            cdvEventID.InsertEmptyRow(0, 1);
        }

        private void cdvEventID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvEventID.Text) == "")
            {
                chkNeedConfirm.Checked = false;
                chkNeedConfirm.Enabled = false;
            }
            else
            {
                chkNeedConfirm.Enabled = true;
            }
        }

        private void txtLotID_TextChanged(object sender, EventArgs e)
        {
            if (MPCF.Trim(txtLotID.Text) == "")
            {
                chkInheritChild.Checked = false;
                chkInheritChild.Enabled = false;
            }
            else
            {
                if (chkInheritChild.Enabled == false)
                {
                    if (MPGO.InheritAlarmToChild() == true)
                        chkInheritChild.Checked = true;

                    chkInheritChild.Enabled = true;
                }
            }
        }

        private void udcMFO_AfterGetTree(object sender, EventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(udcMFO.GetTreeView.GetNodeCount(false));
        }

        private void udcMFO_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(udcMFO.SelectedNode.GetNodeCount(false));
        }

        private void udcMFO_LevelItemSelect(object sender, TreeViewEventArgs e)
        {
            ViewAlarmRelationList(udcMFO.SelectLevelChar, udcMFO.MatID, udcMFO.MatVersion, udcMFO.Flow, udcMFO.Oper, "", "", "");
        }

        private void udcMFO_GetOnlySetData(object sender, EventArgs e)
        {
            ViewMFOSettingDataList();
        }

        private void udcMFO_SetDataSelectedIndexChanged(object sender, EventArgs e)
        {
            MPCF.FieldClear(grpCondition); 
            MPCF.FieldClear(grpAlarmInfo);

            spdComment.ActiveSheet.Cells[0, 0].Value = "";
            spdComment.ActiveSheet.Cells[1, 0].Value = "";
            spdComment.ActiveSheet.Cells[2, 0].Value = "";
            spdComment.ActiveSheet.Cells[3, 0].Value = "";
            spdComment.ActiveSheet.Cells[4, 0].Value = "";

            udcMFO_LevelItemSelect(null, null);
        }

        private void tvResList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string s_res_type = "";
            string s_resg_id = "";
            string s_res_id = "";
            char c_rel_level = ' ';

            if (e.Action == TreeViewAction.Collapse || e.Action == TreeViewAction.Expand || e.Action == TreeViewAction.Unknown) return;

            switch (e.Node.Level)
            {
                case 0:
                    if (rbtFactory.Checked == true)
                    {
                        c_rel_level = 'F';
                    }
                    else if (rbtResType.Checked == true)
                    {
                        c_rel_level = 'T';

                        s_res_type = MPCF.Trim(e.Node.Text);
                        s_res_type = MPCF.SubtractString(s_res_type, ":", false, false);
                        
                        if (e.Node.GetNodeCount(true) < 1)
                        {
                            ViewResourceItem(e.Node);
                        }
                    }
                    else if (rbtResGroup.Checked == true)
                    {
                        c_rel_level = 'G';

                        s_resg_id = MPCF.Trim(e.Node.Text);
                        s_resg_id = MPCF.SubtractString(s_resg_id, ":", false, false);

                        if (e.Node.GetNodeCount(true) < 1)
                        {
                            ViewResourceItem(e.Node);
                        }
                    }
                    break;

                case 1:
                    c_rel_level = 'R';

                    s_res_id = MPCF.Trim(e.Node.Text);
                    s_res_id = MPCF.SubtractString(s_res_id, ":", false, false);
                    break;
            }

            lm_res_rel_level = c_rel_level;
            lm_res_type = s_res_type;
            lm_res_group = s_resg_id;
            lm_res_id = s_res_id;

            ViewAlarmRelationList(c_rel_level, "", 0, "", "", s_res_type, s_resg_id, s_res_id);
        }

        private void tvResList_Click(object sender, EventArgs e)
        {
            tvResList.SelectedNode = null;
        }

        private void rbtResSelLevel_CheckedChanged(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Checked == true)
                chkOnlySettingData_CheckedChanged(null, null);
        }

        private void chkOnlySettingData_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOnlySettingData.Checked == true)
            {
                lisResList.Visible = true;
                tvResList.Visible = false;

                ViewResourceSettingDataList();
            }
            else
            {
                lisResList.Visible = false;
                tvResList.Visible = true;

                InitResourceTree();
            }
        }

        private void lisResList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s_res_type = "";
            string s_resg_id = "";
            string s_res_id = "";
            char c_rel_level = ' ';

            if (lisResList.SelectedItems.Count < 1) return;

            if (rbtFactory.Checked == true)
            {
                c_rel_level = 'F';
            }
            else if (rbtResType.Checked == true)
            {
                c_rel_level = 'T';

                s_res_type = MPCF.Trim(lisResList.SelectedItems[0].SubItems[1].Text);
                s_res_id = MPCF.Trim(lisResList.SelectedItems[0].SubItems[3].Text);

                if (s_res_id != "")
                    c_rel_level = 'R';
            }
            else if (rbtResGroup.Checked == true)
            {
                c_rel_level = 'G';

                s_resg_id = MPCF.Trim(lisResList.SelectedItems[0].SubItems[2].Text);
                s_res_id = MPCF.Trim(lisResList.SelectedItems[0].SubItems[3].Text);

                if (s_res_id != "")
                    c_rel_level = 'R';
            }

            lm_res_rel_level = c_rel_level;
            lm_res_type = s_res_type;
            lm_res_group = s_resg_id;
            lm_res_id = s_res_id;

            ViewAlarmRelationList(c_rel_level, "", 0, "", "", s_res_type, s_resg_id, s_res_id);
        }

        private void chkOverrideMsg_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOverrideMsg.Checked == true)
            {
                txtSubject.ReadOnly = false;
                txtMsg1.ReadOnly = false;
                txtMsg2.ReadOnly = false;
                txtMsg3.ReadOnly = false;
            }
            else
            {
                txtSubject.ReadOnly = true;
                txtMsg1.ReadOnly = true;
                txtMsg2.ReadOnly = true;
                txtMsg3.ReadOnly = true;
            }
        }

        private void chkOverrideComment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOverrideComment.Checked == true)
            {
                spdComment.ActiveSheet.Columns[0].Locked = false;
                spdComment.ActiveSheet.Columns[0].BackColor = Color.White;
            }
            else
            {
                spdComment.ActiveSheet.Columns[0].Locked = true;
                spdComment.ActiveSheet.Columns[0].BackColor = Color.WhiteSmoke;
            }
        }

        private void chkOverridePDF_CheckedChanged(object sender, EventArgs e)
        {
            btnPDFOpen.Enabled = chkOverridePDF.Checked;
            btnPDFRemove.Enabled = chkOverridePDF.Checked;
        }

        private void chkOverrideImg_CheckedChanged(object sender, EventArgs e)
        {
            btnImgOpen.Enabled = chkOverrideImg.Checked;
            btnImgRemove.Enabled = chkOverrideImg.Checked;
        }

        private void btnImgOpen_Click(object sender, EventArgs e)
        {
            FileInfo finfo;
            BinaryReader br;
            byte[] file_buffer;

            ofdFile.Filter = "JPEG File(*.jpg)|*.jpg";
            ofdFile.FileName = "";

            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                picImage.Image = Image.FromFile(ofdFile.FileName);

                finfo = new FileInfo(ofdFile.FileName);
                if (finfo.Exists == true)
                {
                    br = new BinaryReader(finfo.OpenRead());
                    file_buffer = br.ReadBytes((int)finfo.Length);
                    picImage.Image.Tag = file_buffer;
                    br.Close();

                    if (MPCF.ToChar(picImage.Tag) == ' ')
                    {
                        picImage.Tag = 'U';
                    }
                }
            }
        }

        private void btnImgRemove_Click(object sender, EventArgs e)
        {
            picImage.Image = null;

            if (MPCF.ToChar(picImage.Tag) == ' ')
            {
                picImage.Tag = 'U';
            }
        }

        private void tbpComment_Resize(object sender, EventArgs e)
        {
            if (tbpComment.Width - 492 > 0)
            {
                spdComment.ActiveSheet.Columns[0].Width = 405 + (tbpComment.Width - 492);
            }
            else
            {
                spdComment.ActiveSheet.Columns[0].Width = 405;
            }
        }

    
    }
}

//#End If
