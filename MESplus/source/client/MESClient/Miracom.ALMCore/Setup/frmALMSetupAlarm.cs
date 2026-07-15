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
using System.Collections;
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
    public partial class frmALMSetupAlarm : Miracom.MESCore.SetupForm02
    {
        public frmALMSetupAlarm()
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
            switch (ProcStep)
            {
                case MPGC.MP_STEP_CREATE:
                case MPGC.MP_STEP_UPDATE:
                    if (MPCF.CheckValue(txtAlarmID, 1) == false)
                    {
                        tabAlarm.SelectedTab = tbpGeneral;
                        return false;
                    }
                    if (MPCF.CheckValue(txtMsg1, 1) == false)
                    {
                        tabAlarm.SelectedTab = tbpMessage;
                        return false;
                    }

                    if (MPCF.Trim(cboTran.Text) == "PROCESS BLOCKING")
                    {
                        ;
                    }
                    else if(MPCF.Trim(cboTran.Text) != "")
                    {
                        if (MPCF.CheckValue(cdvHoldCode, 1) == false)
                        {
                            tabAlarm.SelectedTab = tbpGeneral;
                            return false;
                        }

                        if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpTranCMF) == false)
                        {
                            tabAlarm.SelectedTab = tbpTranCMF;
                            return false;
                        }

                        switch (MPCF.Trim(cboTran.Text))
                        {
                            case "HOLD":
                                break;

                            case "FUTURE HOLD" :
                                if (MPCF.Trim(cdvReworkOper.Text) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    cdvReworkOper.Focus();
                                    return false;
                                }
                                break;

                            case "REWORK":
                                if (MPCF.Trim(cdvReworkFlow.Text) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    cdvReworkFlow.Focus();
                                    return false;
                                }

                                if (MPCF.Trim(cdvReworkOper.Text) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    cdvReworkOper.Focus();
                                    return false;
                                }
                                break;
                        }
                    }

                    if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpAlarmGroup) == false)
                    {
                        tabAlarm.SelectedTab = tbpAlarmGroup;
                        return false;
                    }
                    if (MPCR.CheckGRPCMFValue("lblAlarmCMF", "cdvAlarmCMF", grpAlarmCMF) == false)
                    {
                        tabAlarm.SelectedTab = tbpAlarmCMF;
                        return false;
                    }

                    break;

                case MPGC.MP_STEP_DELETE:

                    if (MPCF.CheckValue(txtAlarmID, 1) == false)
                    {
                        tabAlarm.SelectedTab = tbpGeneral;
                        return false;
                    }
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
            in_node.ProcStep = '1';
            in_node.AddString("ALARM_ID", txtAlarmID.Text);


            if (MPCR.CallService("ALM", "ALM_View_Alarm_Msg", in_node, ref out_node) == false)
            {                
                return false;
            }

            if (out_node.GetChar("ALARM_TYPE") == MPGC.MP_ALM_NORMAL)
            {
                chkResAlarmFlag.Checked = false;
            }
            else
            {
                chkResAlarmFlag.Checked = true;
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
            {
                cboTran.Text = "FUTURE HOLD";
            }
            else if (out_node.GetString("ALARM_LOT_ACTION") == "PROC_BLOCK")
            {
                cboTran.Text = "PROCESS BLOCKING";
            }
            else
            {
                cboTran.Text = out_node.GetString("ALARM_LOT_ACTION");
            }

            SetLotTran();

            if (out_node.GetString("ALARM_LOT_ACTION") == "HOLD")
            {
                cdvHoldCode.Text = out_node.GetString("HOLD_CODE");
                txtHoldPassword.Text = out_node.GetString("HOLD_PASSWORD");
            }
            else if (out_node.GetString("ALARM_LOT_ACTION") == "FHLD")
            {
                cdvHoldCode.Text = out_node.GetString("HOLD_CODE");
                txtHoldPassword.Text = out_node.GetString("HOLD_PASSWORD");
                cdvReworkFlow.Text = out_node.GetString("FLOW");
                cdvReworkFlow.Sequence = out_node.GetInt("FLOW_SEQ_NUM");
                cdvReworkOper.Text = out_node.GetString("OPER");

            }
            else if (out_node.GetString("ALARM_LOT_ACTION") == "REWORK")
            {
                cdvHoldCode.Text = out_node.GetString("RWK_CODE");
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

            txtDesc.Text = out_node.GetString("ALARM_DESC");

            txtSubject.Text = out_node.GetString("ALARM_SUBJECT");
            txtMsg1.Text = out_node.GetString("ALARM_MSG_1");
            txtMsg2.Text = out_node.GetString("ALARM_MSG_2");
            txtMsg3.Text = out_node.GetString("ALARM_MSG_3");

            // Alarm Comment
            spdComment.ActiveSheet.Cells[0, 0].Value = out_node.GetString("ALARM_COMMENT_1");
            spdComment.ActiveSheet.Cells[1, 0].Value = out_node.GetString("ALARM_COMMENT_2");
            spdComment.ActiveSheet.Cells[2, 0].Value = out_node.GetString("ALARM_COMMENT_3");
            spdComment.ActiveSheet.Cells[3, 0].Value = out_node.GetString("ALARM_COMMENT_4");
            spdComment.ActiveSheet.Cells[4, 0].Value = out_node.GetString("ALARM_COMMENT_5");

            // Image File
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

            
            cdvEvent.Text = out_node.GetString("EVENT_ID");
            if (cdvEvent.Text != "")
            {
                ViewEvent(1, cdvEvent.Text);
            }
            cdvChangeStatus1.Text = out_node.GetString("CHG_STS_1");
            cdvChangeStatus2.Text = out_node.GetString("CHG_STS_2");
            cdvChangeStatus3.Text = out_node.GetString("CHG_STS_3");
            cdvChangeStatus4.Text = out_node.GetString("CHG_STS_4");
            cdvChangeStatus5.Text = out_node.GetString("CHG_STS_5");
            cdvChangeStatus6.Text = out_node.GetString("CHG_STS_6");
            cdvChangeStatus7.Text = out_node.GetString("CHG_STS_7");
            cdvChangeStatus8.Text = out_node.GetString("CHG_STS_8");
            cdvChangeStatus9.Text = out_node.GetString("CHG_STS_9");
            cdvChangeStatus10.Text = out_node.GetString("CHG_STS_10");
            txtResComment.Text = out_node.GetString("RES_COMMENT");

            cdvClearEvent.Text = out_node.GetString("CLEAR_EVENT_ID");
            if (cdvClearEvent.Text != "")
            {
                ViewEvent(2, cdvClearEvent.Text);
            }
            cdvClearChangeStatus1.Text = out_node.GetString("CLEAR_CHG_STS_1");
            cdvClearChangeStatus2.Text = out_node.GetString("CLEAR_CHG_STS_2");
            cdvClearChangeStatus3.Text = out_node.GetString("CLEAR_CHG_STS_3");
            cdvClearChangeStatus4.Text = out_node.GetString("CLEAR_CHG_STS_4");
            cdvClearChangeStatus5.Text = out_node.GetString("CLEAR_CHG_STS_5");
            cdvClearChangeStatus6.Text = out_node.GetString("CLEAR_CHG_STS_6");
            cdvClearChangeStatus7.Text = out_node.GetString("CLEAR_CHG_STS_7");
            cdvClearChangeStatus8.Text = out_node.GetString("CLEAR_CHG_STS_8");
            cdvClearChangeStatus9.Text = out_node.GetString("CLEAR_CHG_STS_9");
            cdvClearChangeStatus10.Text = out_node.GetString("CLEAR_CHG_STS_10");
            txtClearResComment.Text = out_node.GetString("CLEAR_RES_COMMENT");

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

            cdvAlarmCMF1.Text = out_node.GetString("ALARM_CMF_1");
            cdvAlarmCMF2.Text = out_node.GetString("ALARM_CMF_2");
            cdvAlarmCMF3.Text = out_node.GetString("ALARM_CMF_3");
            cdvAlarmCMF4.Text = out_node.GetString("ALARM_CMF_4");
            cdvAlarmCMF5.Text = out_node.GetString("ALARM_CMF_5");
            cdvAlarmCMF6.Text = out_node.GetString("ALARM_CMF_6");
            cdvAlarmCMF7.Text = out_node.GetString("ALARM_CMF_7");
            cdvAlarmCMF8.Text = out_node.GetString("ALARM_CMF_8");
            cdvAlarmCMF9.Text = out_node.GetString("ALARM_CMF_9");
            cdvAlarmCMF10.Text = out_node.GetString("ALARM_CMF_10");
            cdvAlarmCMF11.Text = out_node.GetString("ALARM_CMF_11");
            cdvAlarmCMF12.Text = out_node.GetString("ALARM_CMF_12");
            cdvAlarmCMF13.Text = out_node.GetString("ALARM_CMF_13");
            cdvAlarmCMF14.Text = out_node.GetString("ALARM_CMF_14");
            cdvAlarmCMF15.Text = out_node.GetString("ALARM_CMF_15");
            cdvAlarmCMF16.Text = out_node.GetString("ALARM_CMF_16");
            cdvAlarmCMF17.Text = out_node.GetString("ALARM_CMF_17");
            cdvAlarmCMF18.Text = out_node.GetString("ALARM_CMF_18");
            cdvAlarmCMF19.Text = out_node.GetString("ALARM_CMF_19");
            cdvAlarmCMF20.Text = out_node.GetString("ALARM_CMF_20");

            cdvGroup1.Text = out_node.GetString("ALARM_GRP_1");
            cdvGroup2.Text = out_node.GetString("ALARM_GRP_2");
            cdvGroup3.Text = out_node.GetString("ALARM_GRP_3");
            cdvGroup4.Text = out_node.GetString("ALARM_GRP_4");
            cdvGroup5.Text = out_node.GetString("ALARM_GRP_5");
            cdvGroup6.Text = out_node.GetString("ALARM_GRP_6");
            cdvGroup7.Text = out_node.GetString("ALARM_GRP_7");
            cdvGroup8.Text = out_node.GetString("ALARM_GRP_8");
            cdvGroup9.Text = out_node.GetString("ALARM_GRP_9");
            cdvGroup10.Text = out_node.GetString("ALARM_GRP_10");
            
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

            ListView lisTemp;
            ListViewItem itm;
            int i;
            int ii;
            int i_icon_index;
            string s_rcvr_type;

            MPCF.InitListView(lisRecvList);

            for (i = 0; i < lisUserList.Items.Count; i++)
            {
                if (lisUserList.Items[i].ForeColor == Color.Blue)
                    lisUserList.Items[i].ForeColor = SystemColors.WindowText;
            }
            for (i = 0; i < lisSecGrpList.Items.Count; i++)
            {
                if (lisSecGrpList.Items[i].ForeColor == Color.Blue)
                    lisSecGrpList.Items[i].ForeColor = SystemColors.WindowText;
            }
            for (i = 0; i < lisPrvGrpList.Items.Count; i++)
            {
                if (lisPrvGrpList.Items[i].ForeColor == Color.Blue)
                    lisPrvGrpList.Items[i].ForeColor = SystemColors.WindowText;
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ALARM_ID", txtAlarmID.Text);

            if (MPCR.CallService("ALM", "ALM_View_Alarm_Receiver_List", in_node, ref out_node)  == false)
            {                
                return false;
            }

            i_icon_index = (int)SMALLICON_INDEX.IDX_USER;
            s_rcvr_type = "";
            lisTemp = null;

            for (i = 0; i < out_node.GetList(0).Count ; i++)
            {
                switch (out_node.GetList(0)[i].GetChar("REL_LEVEL"))
                {
                    case 'U':
                        lisTemp = lisUserList;
                        i_icon_index = (int)SMALLICON_INDEX.IDX_USER;
                        s_rcvr_type = RCVR_USER;
                        break;
                    case 'S':
                        lisTemp = lisSecGrpList;
                        i_icon_index = (int)SMALLICON_INDEX.IDX_SEC_GROUP;
                        s_rcvr_type = RCVR_SEC_GROUP;
                        break;
                    case 'P':
                        lisTemp = lisPrvGrpList;
                        i_icon_index = (int)SMALLICON_INDEX.IDX_PRIVILEGE_GROUP;
                        s_rcvr_type = RCVR_PRV_GROUP;
                        break;
                }

                itm = new ListViewItem(out_node.GetList(0)[i].GetString("RCVR_ID"), i_icon_index);
                itm.SubItems.Add(s_rcvr_type);
                itm.SubItems.Add("");

                for (ii = 0; ii < out_node.GetList(0)[i].GetString("RCV_SHIFT").Length ; ii++)
                {
                    if (out_node.GetList(0)[i].GetString("RCV_SHIFT")[ii] != '_')
                        itm.SubItems[2].Text += ((int)(ii + 1)).ToString();
                    else
                        itm.SubItems[2].Text += "_";
                }
                lisRecvList.Items.Add(itm);

                ii = -1;
                ii = MPCF.FindListItemIndex(lisTemp, out_node.GetList(0)[i].GetString("RCVR_ID"), false);
                if (ii >= 0)
                    lisTemp.Items[ii].ForeColor = Color.Blue;
            }

            lisRecvList.ListViewItemSorter = new ListViewItemComparer(1, SortOrder.Descending, ListViewItemComparer.SORTING_OPTION.STRING_TYPE);
            lisRecvList.Sort();
            lisRecvList.ListViewItemSorter = null;

            return true;
        }


        //
        // ViewEvent
        //       - View Event
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool ViewEvent(int i_case, string s_event_id)
        {
            
            #if _RAS

            TRSNode in_node = new TRSNode("VIEW_EVENT_IN");
            TRSNode out_node = new TRSNode("VIEW_EVENT_OUT");

            ClearCodeView(i_case);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("EVENT_ID", s_event_id);


            if (MPCR.CallService("RAS", "RAS_View_Event", in_node, ref out_node) == false)
            {                
                return false;
            }

            // Event
            if (i_case == 1)
            {
                if (out_node.GetChar("CHG_FLAG_1") == OVERRIDE)
                {
                    if (out_node.GetString("TBL_1") != "")
                    {
                        cdvChangeStatus1.VisibleButton = true;
                        cdvChangeStatus1.Tag = out_node.GetString("TBL_1");
                    }
                    else
                    {
                        cdvChangeStatus1.VisibleButton = false;
                        if (out_node.GetString("CHG_STS_1") == "")
                            cdvChangeStatus1.ReadOnly = false;
                        else
                            cdvChangeStatus1.Text = out_node.GetString("CHG_STS_1");
                    }
                    cdvChangeStatus1.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    cdvChangeStatus1.VisibleButton = false;
                    cdvChangeStatus1.ReadOnly = true;
                    cdvChangeStatus1.BackColor = System.Drawing.SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_1") == CHANGE)
                    {
                        cdvChangeStatus1.Text = out_node.GetString("CHG_STS_1");
                    }
                }

                if (out_node.GetChar("CHG_FLAG_2") == OVERRIDE)
                {
                    if (out_node.GetString("TBL_2") != "")
                    {
                        cdvChangeStatus2.VisibleButton = true;
                        cdvChangeStatus2.Tag = out_node.GetString("TBL_2");
                    }
                    else
                    {
                        cdvChangeStatus2.VisibleButton = false;
                        if (out_node.GetString("CHG_STS_2") == "")
                            cdvChangeStatus2.ReadOnly = false;
                        else
                            cdvChangeStatus2.Text = out_node.GetString("CHG_STS_2");
                    }
                    cdvChangeStatus2.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    cdvChangeStatus2.VisibleButton = false;
                    cdvChangeStatus2.ReadOnly = true;
                    cdvChangeStatus2.BackColor = System.Drawing.SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_2") == CHANGE)
                    {
                        cdvChangeStatus2.Text = out_node.GetString("CHG_STS_2");
                    }
                }

                if (out_node.GetChar("CHG_FLAG_3") == OVERRIDE)
                {
                    if (out_node.GetString("TBL_3") != "")
                    {
                        cdvChangeStatus3.VisibleButton = true;
                        cdvChangeStatus3.Tag = out_node.GetString("TBL_3");
                    }
                    else
                    {
                        cdvChangeStatus3.VisibleButton = false;
                        if (out_node.GetString("CHG_STS_3") == "")
                            cdvChangeStatus3.ReadOnly = false;
                        else
                            cdvChangeStatus3.Text = out_node.GetString("CHG_STS_3");
                    }
                    cdvChangeStatus3.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    cdvChangeStatus3.VisibleButton = false;
                    cdvChangeStatus3.ReadOnly = true;
                    cdvChangeStatus3.BackColor = System.Drawing.SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_3") == CHANGE)
                    {
                        cdvChangeStatus3.Text = out_node.GetString("CHG_STS_3");
                    }
                }

                if (out_node.GetChar("CHG_FLAG_4") == OVERRIDE)
                {
                    if (out_node.GetString("TBL_4") != "")
                    {
                        cdvChangeStatus4.VisibleButton = true;
                        cdvChangeStatus4.Tag = out_node.GetString("TBL_4");
                    }
                    else
                    {
                        cdvChangeStatus4.VisibleButton = false;
                        if (out_node.GetString("CHG_STS_4") == "")
                            cdvChangeStatus4.ReadOnly = false;
                        else
                            cdvChangeStatus4.Text = out_node.GetString("CHG_STS_4");
                    }
                    cdvChangeStatus4.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    cdvChangeStatus4.VisibleButton = false;
                    cdvChangeStatus4.ReadOnly = true;
                    cdvChangeStatus4.BackColor = System.Drawing.SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_4") == CHANGE)
                    {
                        cdvChangeStatus4.Text = out_node.GetString("CHG_STS_4");
                    }
                }

                if (out_node.GetChar("CHG_FLAG_5") == OVERRIDE)
                {
                    if (out_node.GetString("TBL_5") != "")
                    {
                        cdvChangeStatus5.VisibleButton = true;
                        cdvChangeStatus5.Tag = out_node.GetString("TBL_5");
                    }
                    else
                    {
                        cdvChangeStatus5.VisibleButton = false;
                        if (out_node.GetString("CHG_STS_5") == "")
                            cdvChangeStatus5.ReadOnly = false;
                        else
                            cdvChangeStatus5.Text = out_node.GetString("CHG_STS_5");
                    }
                    cdvChangeStatus5.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    cdvChangeStatus5.VisibleButton = false;
                    cdvChangeStatus5.ReadOnly = true;
                    cdvChangeStatus5.BackColor = System.Drawing.SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_5") == CHANGE)
                    {
                        cdvChangeStatus5.Text = out_node.GetString("CHG_STS_5");
                    }
                }

                if (out_node.GetChar("CHG_FLAG_6") == OVERRIDE)
                {
                    if (out_node.GetString("TBL_6") != "")
                    {
                        cdvChangeStatus6.VisibleButton = true;
                        cdvChangeStatus6.Tag = out_node.GetString("TBL_6");
                    }
                    else
                    {
                        cdvChangeStatus6.VisibleButton = false;
                        if (out_node.GetString("CHG_STS_6") == "")
                            cdvChangeStatus6.ReadOnly = false;
                        else
                            cdvChangeStatus6.Text = out_node.GetString("CHG_STS_6");
                    }
                    cdvChangeStatus6.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    cdvChangeStatus6.VisibleButton = false;
                    cdvChangeStatus6.ReadOnly = true;
                    cdvChangeStatus6.BackColor = System.Drawing.SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_6") == CHANGE)
                    {
                        cdvChangeStatus6.Text = out_node.GetString("CHG_STS_6");
                    }
                }

                if (out_node.GetChar("CHG_FLAG_7") == OVERRIDE)
                {
                    if (out_node.GetString("TBL_7") != "")
                    {
                        cdvChangeStatus7.VisibleButton = true;
                        cdvChangeStatus7.Tag = out_node.GetString("TBL_7");
                    }
                    else
                    {
                        cdvChangeStatus7.VisibleButton = false;
                        if (out_node.GetString("CHG_STS_7") == "")
                            cdvChangeStatus7.ReadOnly = false;
                        else
                            cdvChangeStatus7.Text = out_node.GetString("CHG_STS_7");
                    }
                    cdvChangeStatus7.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    cdvChangeStatus7.VisibleButton = false;
                    cdvChangeStatus7.ReadOnly = true;
                    cdvChangeStatus7.BackColor = System.Drawing.SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_7") == CHANGE)
                    {
                        cdvChangeStatus7.Text = out_node.GetString("CHG_STS_7");
                    }
                }

                if (out_node.GetChar("CHG_FLAG_8") == OVERRIDE)
                {
                    if (out_node.GetString("TBL_8") != "")
                    {
                        cdvChangeStatus8.VisibleButton = true;
                        cdvChangeStatus8.Tag = out_node.GetString("TBL_8");
                    }
                    else
                    {
                        cdvChangeStatus8.VisibleButton = false;
                        if (out_node.GetString("CHG_STS_8") == "")
                            cdvChangeStatus8.ReadOnly = false;
                        else
                            cdvChangeStatus8.Text = out_node.GetString("CHG_STS_8");
                    }
                    cdvChangeStatus8.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    cdvChangeStatus8.VisibleButton = false;
                    cdvChangeStatus8.ReadOnly = true;
                    cdvChangeStatus8.BackColor = System.Drawing.SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_8") == CHANGE)
                    {
                        cdvChangeStatus8.Text = out_node.GetString("CHG_STS_8");
                    }
                }

                if (out_node.GetChar("CHG_FLAG_9") == OVERRIDE)
                {
                    if (out_node.GetString("TBL_9") != "")
                    {
                        cdvChangeStatus9.VisibleButton = true;
                        cdvChangeStatus9.Tag = out_node.GetString("TBL_9");
                    }
                    else
                    {
                        cdvChangeStatus9.VisibleButton = false;
                        if (out_node.GetString("CHG_STS_9") == "")
                            cdvChangeStatus9.ReadOnly = false;
                        else
                            cdvChangeStatus9.Text = out_node.GetString("CHG_STS_9");
                    }
                    cdvChangeStatus9.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    cdvChangeStatus9.VisibleButton = false;
                    cdvChangeStatus9.ReadOnly = true;
                    cdvChangeStatus9.BackColor = System.Drawing.SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_9") == CHANGE)
                    {
                        cdvChangeStatus9.Text = out_node.GetString("CHG_STS_9");
                    }
                }

                if (out_node.GetChar("CHG_FLAG_10") == OVERRIDE)
                {
                    if (out_node.GetString("TBL_10") != "")
                    {
                        cdvChangeStatus10.VisibleButton = true;
                        cdvChangeStatus10.Tag = out_node.GetString("TBL_10");
                    }
                    else
                    {
                        cdvChangeStatus10.VisibleButton = false;
                        if (out_node.GetString("CHG_STS_10") == "")
                            cdvChangeStatus10.ReadOnly = false;
                        else
                            cdvChangeStatus10.Text = out_node.GetString("CHG_STS_10");
                    }
                    cdvChangeStatus10.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    cdvChangeStatus10.VisibleButton = false;
                    cdvChangeStatus10.ReadOnly = true;
                    cdvChangeStatus10.BackColor = System.Drawing.SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_10") == CHANGE)
                    {
                        cdvChangeStatus10.Text = out_node.GetString("CHG_STS_10");
                    }
                }
            }

            // Clear Event
            else
            {
                if (out_node.GetChar("CHG_FLAG_1") == OVERRIDE)
                {
                    if (out_node.GetString("TBL_1") != "")
                    {
                        cdvClearChangeStatus1.VisibleButton = true;
                        cdvClearChangeStatus1.Tag = out_node.GetString("TBL_1");
                    }
                    else
                    {
                        cdvClearChangeStatus1.VisibleButton = false;
                        if (out_node.GetString("CHG_STS_1") == "")
                            cdvClearChangeStatus1.ReadOnly = false;
                        else
                            cdvClearChangeStatus1.Text = out_node.GetString("CHG_STS_1");
                    }
                    cdvClearChangeStatus1.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    cdvClearChangeStatus1.VisibleButton = false;
                    cdvClearChangeStatus1.ReadOnly = true;
                    cdvClearChangeStatus1.BackColor = System.Drawing.SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_1") == CHANGE)
                    {
                        cdvClearChangeStatus1.Text = out_node.GetString("CHG_STS_1");
                    }
                }

                if (out_node.GetChar("CHG_FLAG_2") == OVERRIDE)
                {
                    if (out_node.GetString("TBL_2") != "")
                    {
                        cdvClearChangeStatus2.VisibleButton = true;
                        cdvClearChangeStatus2.Tag = out_node.GetString("TBL_2");
                    }
                    else
                    {
                        cdvClearChangeStatus2.VisibleButton = false;
                        if (out_node.GetString("CHG_STS_2") == "")
                            cdvClearChangeStatus2.ReadOnly = false;
                        else
                            cdvClearChangeStatus2.Text = out_node.GetString("CHG_STS_2");
                    }
                    cdvClearChangeStatus2.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    cdvClearChangeStatus2.VisibleButton = false;
                    cdvClearChangeStatus2.ReadOnly = true;
                    cdvClearChangeStatus2.BackColor = System.Drawing.SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_2") == CHANGE)
                    {
                        cdvClearChangeStatus2.Text = out_node.GetString("CHG_STS_2");
                    }
                }

                if (out_node.GetChar("CHG_FLAG_3") == OVERRIDE)
                {
                    if (out_node.GetString("TBL_3") != "")
                    {
                        cdvClearChangeStatus3.VisibleButton = true;
                        cdvClearChangeStatus3.Tag = out_node.GetString("TBL_3");
                    }
                    else
                    {
                        cdvClearChangeStatus3.VisibleButton = false;
                        if (out_node.GetString("CHG_STS_3") == "")
                            cdvClearChangeStatus3.ReadOnly = false;
                        else
                            cdvClearChangeStatus3.Text = out_node.GetString("CHG_STS_3");
                    }
                    cdvClearChangeStatus3.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    cdvClearChangeStatus3.VisibleButton = false;
                    cdvClearChangeStatus3.ReadOnly = true;
                    cdvClearChangeStatus3.BackColor = System.Drawing.SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_3") == CHANGE)
                    {
                        cdvClearChangeStatus3.Text = out_node.GetString("CHG_STS_3");
                    }
                }

                if (out_node.GetChar("CHG_FLAG_4") == OVERRIDE)
                {
                    if (out_node.GetString("TBL_4") != "")
                    {
                        cdvClearChangeStatus4.VisibleButton = true;
                        cdvClearChangeStatus4.Tag = out_node.GetString("TBL_4");
                    }
                    else
                    {
                        cdvClearChangeStatus4.VisibleButton = false;
                        if (out_node.GetString("CHG_STS_4") == "")
                            cdvClearChangeStatus4.ReadOnly = false;
                        else
                            cdvClearChangeStatus4.Text = out_node.GetString("CHG_STS_4");
                    }
                    cdvClearChangeStatus4.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    cdvClearChangeStatus4.VisibleButton = false;
                    cdvClearChangeStatus4.ReadOnly = true;
                    cdvClearChangeStatus4.BackColor = System.Drawing.SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_4") == CHANGE)
                    {
                        cdvClearChangeStatus4.Text = out_node.GetString("CHG_STS_4");
                    }
                }

                if (out_node.GetChar("CHG_FLAG_5") == OVERRIDE)
                {
                    if (out_node.GetString("TBL_5") != "")
                    {
                        cdvClearChangeStatus5.VisibleButton = true;
                        cdvClearChangeStatus5.Tag = out_node.GetString("TBL_5");
                    }
                    else
                    {
                        cdvClearChangeStatus5.VisibleButton = false;
                        if (out_node.GetString("CHG_STS_5") == "")
                            cdvClearChangeStatus5.ReadOnly = false;
                        else
                            cdvClearChangeStatus5.Text = out_node.GetString("CHG_STS_5");
                    }
                    cdvClearChangeStatus5.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    cdvClearChangeStatus5.VisibleButton = false;
                    cdvClearChangeStatus5.ReadOnly = true;
                    cdvClearChangeStatus5.BackColor = System.Drawing.SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_5") == CHANGE)
                    {
                        cdvClearChangeStatus5.Text = out_node.GetString("CHG_STS_5");
                    }
                }

                if (out_node.GetChar("CHG_FLAG_6") == OVERRIDE)
                {
                    if (out_node.GetString("TBL_6") != "")
                    {
                        cdvClearChangeStatus6.VisibleButton = true;
                        cdvClearChangeStatus6.Tag = out_node.GetString("TBL_6");
                    }
                    else
                    {
                        cdvClearChangeStatus6.VisibleButton = false;
                        if (out_node.GetString("CHG_STS_6") == "")
                            cdvClearChangeStatus6.ReadOnly = false;
                        else
                            cdvClearChangeStatus6.Text = out_node.GetString("CHG_STS_6");
                    }
                    cdvClearChangeStatus6.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    cdvClearChangeStatus6.VisibleButton = false;
                    cdvClearChangeStatus6.ReadOnly = true;
                    cdvClearChangeStatus6.BackColor = System.Drawing.SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_6") == CHANGE)
                    {
                        cdvClearChangeStatus6.Text = out_node.GetString("CHG_STS_6");
                    }
                }

                if (out_node.GetChar("CHG_FLAG_7") == OVERRIDE)
                {
                    if (out_node.GetString("TBL_7") != "")
                    {
                        cdvClearChangeStatus7.VisibleButton = true;
                        cdvClearChangeStatus7.Tag = out_node.GetString("TBL_7");
                    }
                    else
                    {
                        cdvClearChangeStatus7.VisibleButton = false;
                        if (out_node.GetString("CHG_STS_7") == "")
                            cdvClearChangeStatus7.ReadOnly = false;
                        else
                            cdvClearChangeStatus7.Text = out_node.GetString("CHG_STS_7");
                    }
                    cdvClearChangeStatus7.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    cdvClearChangeStatus7.VisibleButton = false;
                    cdvClearChangeStatus7.ReadOnly = true;
                    cdvClearChangeStatus7.BackColor = System.Drawing.SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_7") == CHANGE)
                    {
                        cdvClearChangeStatus7.Text = out_node.GetString("CHG_STS_7");
                    }
                }

                if (out_node.GetChar("CHG_FLAG_8") == OVERRIDE)
                {
                    if (out_node.GetString("TBL_8") != "")
                    {
                        cdvClearChangeStatus8.VisibleButton = true;
                        cdvClearChangeStatus8.Tag = out_node.GetString("TBL_8");
                    }
                    else
                    {
                        cdvClearChangeStatus8.VisibleButton = false;
                        if (out_node.GetString("CHG_STS_8") == "")
                            cdvClearChangeStatus8.ReadOnly = false;
                        else
                            cdvClearChangeStatus8.Text = out_node.GetString("CHG_STS_8");
                    }
                    cdvClearChangeStatus8.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    cdvClearChangeStatus8.VisibleButton = false;
                    cdvClearChangeStatus8.ReadOnly = true;
                    cdvClearChangeStatus8.BackColor = System.Drawing.SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_8") == CHANGE)
                    {
                        cdvClearChangeStatus8.Text = out_node.GetString("CHG_STS_8");
                    }
                }

                if (out_node.GetChar("CHG_FLAG_9") == OVERRIDE)
                {
                    if (out_node.GetString("TBL_9") != "")
                    {
                        cdvClearChangeStatus9.VisibleButton = true;
                        cdvClearChangeStatus9.Tag = out_node.GetString("TBL_9");
                    }
                    else
                    {
                        cdvClearChangeStatus9.VisibleButton = false;
                        if (out_node.GetString("CHG_STS_9") == "")
                            cdvClearChangeStatus9.ReadOnly = false;
                        else
                            cdvClearChangeStatus9.Text = out_node.GetString("CHG_STS_9");
                    }
                    cdvClearChangeStatus9.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    cdvClearChangeStatus9.VisibleButton = false;
                    cdvClearChangeStatus9.ReadOnly = true;
                    cdvClearChangeStatus9.BackColor = System.Drawing.SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_9") == CHANGE)
                    {
                        cdvClearChangeStatus9.Text = out_node.GetString("CHG_STS_9");
                    }
                }

                if (out_node.GetChar("CHG_FLAG_10") == OVERRIDE)
                {
                    if (out_node.GetString("TBL_10") != "")
                    {
                        cdvClearChangeStatus10.VisibleButton = true;
                        cdvClearChangeStatus10.Tag = out_node.GetString("TBL_10");
                    }
                    else
                    {
                        cdvClearChangeStatus10.VisibleButton = false;
                        if (out_node.GetString("CHG_STS_10") == "")
                            cdvClearChangeStatus10.ReadOnly = false;
                        else
                            cdvClearChangeStatus10.Text = out_node.GetString("CHG_STS_10");
                    }
                    cdvClearChangeStatus10.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    cdvClearChangeStatus10.VisibleButton = false;
                    cdvClearChangeStatus10.ReadOnly = true;
                    cdvClearChangeStatus10.BackColor = System.Drawing.SystemColors.Control;
                    if (out_node.GetChar("CHG_FLAG_10") == CHANGE)
                    {
                        cdvClearChangeStatus10.Text = out_node.GetString("CHG_STS_10");
                    }
                }
            }

            #endif
            
            return true;
            
        }
        
        private void ClearCodeView(int i_case)
        {
            if (i_case == 1)
            {
                foreach (Control control in grpStatus.Controls)
                {
                    if (control is Miracom.UI.Controls.MCCodeView.MCCodeView)
                    {
                        ((Miracom.UI.Controls.MCCodeView.MCCodeView)control).Init();
                        ((Miracom.UI.Controls.MCCodeView.MCCodeView)control).ReadOnly = true;
                        ((Miracom.UI.Controls.MCCodeView.MCCodeView)control).VisibleButton = false;
                        ((Miracom.UI.Controls.MCCodeView.MCCodeView)control).Text = "";
                        ((Miracom.UI.Controls.MCCodeView.MCCodeView)control).Tag = "";
                        ((Miracom.UI.Controls.MCCodeView.MCCodeView)control).BackColor = System.Drawing.SystemColors.Control;
                    }
                }
            }
            else if (i_case == 2)
            {
                foreach (Control control in grpClearChgStatus.Controls)
                {
                    if (control is Miracom.UI.Controls.MCCodeView.MCCodeView)
                    {
                        ((Miracom.UI.Controls.MCCodeView.MCCodeView)control).Init();
                        ((Miracom.UI.Controls.MCCodeView.MCCodeView)control).ReadOnly = true;
                        ((Miracom.UI.Controls.MCCodeView.MCCodeView)control).VisibleButton = false;
                        ((Miracom.UI.Controls.MCCodeView.MCCodeView)control).Text = "";
                        ((Miracom.UI.Controls.MCCodeView.MCCodeView)control).Tag = "";
                        ((Miracom.UI.Controls.MCCodeView.MCCodeView)control).BackColor = System.Drawing.SystemColors.Control;
                    }
                }
            }
        }
        
        //
        // UpdateAlarmMsg()
        //       - Create/Update/Delete Alarm Message
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("I" - Create, "U" - Update, "D" - Delete)
        //
        private bool UpdateAlarmMsg(char ProcStep)
        {
            ListViewItem itm;
            int idx;
            int i;
            
            TRSNode in_node = new TRSNode("UPDATE_ALARM_MSG_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("ALARM_ID", txtAlarmID.Text);
                in_node.AddString("ALARM_DESC", txtDesc.Text);

                in_node.AddChar("ALARM_TYPE", (chkResAlarmFlag.Checked ? 'R' : 'N'));
                
                if (rbnInformation.Checked == true)
                {
                    in_node.AddChar("ALARM_LEVEL_FLAG", MPGC.MP_ALM_LEVEL_INFO);
                }
                else if (rbnWarning.Checked == true)
                {
                    in_node.AddChar("ALARM_LEVEL_FLAG", MPGC.MP_ALM_LEVEL_WARN);
                }
                else if (rbnError.Checked == true)
                {
                    in_node.AddChar("ALARM_LEVEL_FLAG", MPGC.MP_ALM_LEVEL_ERROR);
                }

                in_node.AddChar("SEND_TO_USER_FLAG", (chkSendToUser.Checked ? 'Y' : ' '));
                in_node.AddChar("ACTION_DISPLAY_FLAG", (chkDisplay.Checked ? 'Y' : ' '));
                in_node.AddChar("ACTION_MAIL_FLAG", (chkMail.Checked ? 'Y' : ' '));
                in_node.AddChar("ACTION_MSG_FLAG", (chkMessage.Checked ? 'Y' : ' '));

                switch (MPCF.Trim(cboTran.Text))
                {
                    case "HOLD":
                        in_node.AddString("ALARM_LOT_ACTION", MPCF.Trim(cboTran.Text));
                        in_node.AddString("HOLD_CODE", MPCF.Trim(cdvHoldCode.Text));
                        in_node.AddString("HOLD_PASSWORD", MPCF.Trim(txtHoldPassword.Text), true);
                        break;
                    case "FUTURE HOLD":
                        in_node.AddString("ALARM_LOT_ACTION", "FHLD");
                        in_node.AddString("HOLD_CODE", MPCF.Trim(cdvHoldCode.Text));
                        in_node.AddString("HOLD_PASSWORD", MPCF.Trim(txtHoldPassword.Text), true);
                        in_node.AddString("FLOW", MPCF.Trim(cdvReworkFlow.Text));
                        in_node.AddInt("FLOW_SEQ_NUM", cdvReworkFlow.Sequence);
                        in_node.AddString("OPER", MPCF.Trim(cdvReworkOper.Text));
                        break;
                    case "REWORK":
                        in_node.AddString("ALARM_LOT_ACTION", MPCF.Trim(cboTran.Text));
                        in_node.AddString("RWK_CODE", MPCF.Trim(cdvHoldCode.Text));
                        in_node.AddString("RWK_FLOW", MPCF.Trim(cdvReworkFlow.Text));
                        in_node.AddInt("RWK_FLOW_SEQ_NUM", cdvReworkFlow.Sequence);
                        in_node.AddString("RWK_OPER", MPCF.Trim(cdvReworkOper.Text));
                        in_node.AddString("RWK_STOP_OPER", MPCF.Trim(cdvReworkStopOper.Text));
                        in_node.AddString("RET_FLOW", MPCF.Trim(cdvReturnFlow.Text));
                        in_node.AddInt("RET_FLOW_SEQ_NUM", cdvReturnFlow.Sequence);
                        in_node.AddString("RET_OPER", MPCF.Trim(cdvReturnOper.Text));

                        switch (cboReturnOption.SelectedIndex)
                        {
                            case 0: // Keep Rework
                                in_node.AddChar("RET_CLEAR_FLAG", ' ');
                                break;
                            case 1: // Clear Rework
                                in_node.AddChar("RET_CLEAR_FLAG", 'Y');
                                break;
                            case 2: // Clear Rework and Move to Next Oper
                                in_node.AddChar("RET_CLEAR_FLAG", 'A');
                                break;
                            case 3: // Keep Rework and Move to Next Oper
                                in_node.AddChar("RET_CLEAR_FLAG", 'B');
                                break;
                        }
                        break;
                    case "PROCESS BLOCKING":
                        in_node.AddString("ALARM_LOT_ACTION", "PROC_BLOCK");
                        break;
                }

                in_node.AddString("LOT_COMMENT", MPCF.Trim(txtComment.Text));

                in_node.AddString("ALARM_SUBJECT", MPCF.Trim(txtSubject.Text));
                in_node.AddString("ALARM_MSG_1", MPCF.Trim(txtMsg1.Text));
                in_node.AddString("ALARM_MSG_2", MPCF.Trim(txtMsg2.Text));
                in_node.AddString("ALARM_MSG_3", MPCF.Trim(txtMsg3.Text));

                //Message Comment
                in_node.AddString("ALARM_COMMENT_1", MPCF.Trim(spdComment.ActiveSheet.Cells[0, 0].Value));
                in_node.AddString("ALARM_COMMENT_2", MPCF.Trim(spdComment.ActiveSheet.Cells[1, 0].Value));
                in_node.AddString("ALARM_COMMENT_3", MPCF.Trim(spdComment.ActiveSheet.Cells[2, 0].Value));
                in_node.AddString("ALARM_COMMENT_4", MPCF.Trim(spdComment.ActiveSheet.Cells[3, 0].Value));
                in_node.AddString("ALARM_COMMENT_5", MPCF.Trim(spdComment.ActiveSheet.Cells[4, 0].Value));

                //Image File
                if (MPCF.ToChar(picImage.Tag) == 'U')
                {
                    byte[] img_buffer;

                    img_buffer = null;
                    if (picImage.Image != null)
                    {
                        img_buffer = (byte[])picImage.Image.Tag;
                    }
                    in_node.AddBlob(MPGC.MP_BIN_DATA_1, img_buffer);
                    in_node.AddChar("CHANGE_IMG_FLAG", "Y");
                }

                //PDF File

                
                in_node.AddString("EVENT_ID", MPCF.Trim(cdvEvent.Text));
                in_node.AddString("CHG_STS_1", MPCF.Trim(cdvChangeStatus1.Text));
                in_node.AddString("CHG_STS_2", MPCF.Trim(cdvChangeStatus2.Text));
                in_node.AddString("CHG_STS_3", MPCF.Trim(cdvChangeStatus3.Text));
                in_node.AddString("CHG_STS_4", MPCF.Trim(cdvChangeStatus4.Text));
                in_node.AddString("CHG_STS_5", MPCF.Trim(cdvChangeStatus5.Text));
                in_node.AddString("CHG_STS_6", MPCF.Trim(cdvChangeStatus6.Text));
                in_node.AddString("CHG_STS_7", MPCF.Trim(cdvChangeStatus7.Text));
                in_node.AddString("CHG_STS_8", MPCF.Trim(cdvChangeStatus8.Text));
                in_node.AddString("CHG_STS_9", MPCF.Trim(cdvChangeStatus9.Text));
                in_node.AddString("CHG_STS_10", MPCF.Trim(cdvChangeStatus10.Text));
                in_node.AddString("RES_COMMENT", MPCF.Trim(txtResComment.Text));


                if (chkResAlarmFlag.Checked == true)
                {
                    in_node.AddString("CLEAR_EVENT_ID", MPCF.Trim(cdvClearEvent.Text));
                    in_node.AddString("CLEAR_CHG_STS_1", MPCF.Trim(cdvClearChangeStatus1.Text));
                    in_node.AddString("CLEAR_CHG_STS_2", MPCF.Trim(cdvClearChangeStatus2.Text));
                    in_node.AddString("CLEAR_CHG_STS_3", MPCF.Trim(cdvClearChangeStatus3.Text));
                    in_node.AddString("CLEAR_CHG_STS_4", MPCF.Trim(cdvClearChangeStatus4.Text));
                    in_node.AddString("CLEAR_CHG_STS_5", MPCF.Trim(cdvClearChangeStatus5.Text));
                    in_node.AddString("CLEAR_CHG_STS_6", MPCF.Trim(cdvClearChangeStatus6.Text));
                    in_node.AddString("CLEAR_CHG_STS_7", MPCF.Trim(cdvClearChangeStatus7.Text));
                    in_node.AddString("CLEAR_CHG_STS_8", MPCF.Trim(cdvClearChangeStatus8.Text));
                    in_node.AddString("CLEAR_CHG_STS_9", MPCF.Trim(cdvClearChangeStatus9.Text));
                    in_node.AddString("CLEAR_CHG_STS_10", MPCF.Trim(cdvClearChangeStatus10.Text));
                    in_node.AddString("CLEAR_RES_COMMENT", MPCF.Trim(txtClearResComment.Text));
                }

                if (grpTranCMF.Visible == true)
                {
                    in_node.AddString("CMF_1", MPCF.Trim(cdvCMF1.Text));
                    in_node.AddString("CMF_2", MPCF.Trim(cdvCMF2.Text));
                    in_node.AddString("CMF_3", MPCF.Trim(cdvCMF3.Text));
                    in_node.AddString("CMF_4", MPCF.Trim(cdvCMF4.Text));
                    in_node.AddString("CMF_5", MPCF.Trim(cdvCMF5.Text));
                    in_node.AddString("CMF_6", MPCF.Trim(cdvCMF6.Text));
                    in_node.AddString("CMF_7", MPCF.Trim(cdvCMF7.Text));
                    in_node.AddString("CMF_8", MPCF.Trim(cdvCMF8.Text));
                    in_node.AddString("CMF_9", MPCF.Trim(cdvCMF9.Text));
                    in_node.AddString("CMF_10", MPCF.Trim(cdvCMF10.Text));
                    in_node.AddString("CMF_11", MPCF.Trim(cdvCMF11.Text));
                    in_node.AddString("CMF_12", MPCF.Trim(cdvCMF12.Text));
                    in_node.AddString("CMF_13", MPCF.Trim(cdvCMF13.Text));
                    in_node.AddString("CMF_14", MPCF.Trim(cdvCMF14.Text));
                    in_node.AddString("CMF_15", MPCF.Trim(cdvCMF15.Text));
                    in_node.AddString("CMF_16", MPCF.Trim(cdvCMF16.Text));
                    in_node.AddString("CMF_17", MPCF.Trim(cdvCMF17.Text));
                    in_node.AddString("CMF_18", MPCF.Trim(cdvCMF18.Text));
                    in_node.AddString("CMF_19", MPCF.Trim(cdvCMF19.Text));
                    in_node.AddString("CMF_20", MPCF.Trim(cdvCMF20.Text));
                }

                for (idx = 0; idx < lisRecvList.Items.Count; idx++)
                {
                    TRSNode list = in_node.AddNode("RCVR_LIST");

                    list.AddString("RCVR_ID", lisRecvList.Items[idx].Text);

                    if (MPCF.Trim(lisRecvList.Items[idx].SubItems[1].Text) == RCVR_USER)
                        list.AddChar("REL_LEVEL", 'U');
                    else if (MPCF.Trim(lisRecvList.Items[idx].SubItems[1].Text) == RCVR_SEC_GROUP)
                        list.AddChar("REL_LEVEL", 'S');
                    else if (MPCF.Trim(lisRecvList.Items[idx].SubItems[1].Text) == RCVR_PRV_GROUP)
                        list.AddChar("REL_LEVEL", 'P');

                    string s_recv_shift = MPCF.Trim(lisRecvList.Items[idx].SubItems[2].Text);
                    string rcv_shift = "";

                    for (i = 0; i < s_recv_shift.Length; i++ )
                    {
                        if (s_recv_shift[i] != '_')
                        {
                            rcv_shift += "X";
                        }
                        else
                        {
                            rcv_shift += "_";
                        }
                    }

                    list.AddString("RCV_SHIFT", rcv_shift);
                }

                in_node.AddString("ALARM_CMF_1", MPCF.Trim(cdvAlarmCMF1.Text));
                in_node.AddString("ALARM_CMF_2", MPCF.Trim(cdvAlarmCMF2.Text));
                in_node.AddString("ALARM_CMF_3", MPCF.Trim(cdvAlarmCMF3.Text));
                in_node.AddString("ALARM_CMF_4", MPCF.Trim(cdvAlarmCMF4.Text));
                in_node.AddString("ALARM_CMF_5", MPCF.Trim(cdvAlarmCMF5.Text));
                in_node.AddString("ALARM_CMF_6", MPCF.Trim(cdvAlarmCMF6.Text));
                in_node.AddString("ALARM_CMF_7", MPCF.Trim(cdvAlarmCMF7.Text));
                in_node.AddString("ALARM_CMF_8", MPCF.Trim(cdvAlarmCMF8.Text));
                in_node.AddString("ALARM_CMF_9", MPCF.Trim(cdvAlarmCMF9.Text));
                in_node.AddString("ALARM_CMF_10", MPCF.Trim(cdvAlarmCMF10.Text));
                in_node.AddString("ALARM_CMF_11", MPCF.Trim(cdvAlarmCMF11.Text));
                in_node.AddString("ALARM_CMF_12", MPCF.Trim(cdvAlarmCMF12.Text));
                in_node.AddString("ALARM_CMF_13", MPCF.Trim(cdvAlarmCMF13.Text));
                in_node.AddString("ALARM_CMF_14", MPCF.Trim(cdvAlarmCMF14.Text));
                in_node.AddString("ALARM_CMF_15", MPCF.Trim(cdvAlarmCMF15.Text));
                in_node.AddString("ALARM_CMF_16", MPCF.Trim(cdvAlarmCMF16.Text));
                in_node.AddString("ALARM_CMF_17", MPCF.Trim(cdvAlarmCMF17.Text));
                in_node.AddString("ALARM_CMF_18", MPCF.Trim(cdvAlarmCMF18.Text));
                in_node.AddString("ALARM_CMF_19", MPCF.Trim(cdvAlarmCMF19.Text));
                in_node.AddString("ALARM_CMF_20", MPCF.Trim(cdvAlarmCMF20.Text));

                in_node.AddString("ALARM_GRP_1", MPCF.Trim(cdvGroup1.Text));
                in_node.AddString("ALARM_GRP_2", MPCF.Trim(cdvGroup2.Text));
                in_node.AddString("ALARM_GRP_3", MPCF.Trim(cdvGroup3.Text));
                in_node.AddString("ALARM_GRP_4", MPCF.Trim(cdvGroup4.Text));
                in_node.AddString("ALARM_GRP_5", MPCF.Trim(cdvGroup5.Text));
                in_node.AddString("ALARM_GRP_6", MPCF.Trim(cdvGroup6.Text));
                in_node.AddString("ALARM_GRP_7", MPCF.Trim(cdvGroup7.Text));
                in_node.AddString("ALARM_GRP_8", MPCF.Trim(cdvGroup8.Text));
                in_node.AddString("ALARM_GRP_9", MPCF.Trim(cdvGroup9.Text));
                in_node.AddString("ALARM_GRP_10", MPCF.Trim(cdvGroup10.Text));

                if (MPCR.CallService("ALM", "ALM_Update_Alarm_Msg", in_node, ref out_node) == false)
                {                    
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisAlarm.Items.Add(MPCF.Trim(txtAlarmID.Text), (int)SMALLICON_INDEX.IDX_ALARM);
                        itm.SubItems.Add(txtDesc.Text);
                        itm.Selected = true;
                        lisAlarm.Sorting = SortOrder.Ascending;
                        lisAlarm.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        idx = MPCF.FindListItemIndex(lisAlarm, MPCF.Trim(txtAlarmID.Text), false);
                        if (idx >= 0)
                        {
                            lisAlarm.Items[idx].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisAlarm, MPCF.Trim(txtAlarmID.Text), false);
                        if (idx >= 0)
                        {
                            lisAlarm.Items[idx].Remove();
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
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.txtAlarmID;
                
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
            cdvHoldCode.Visible = false;
            lblHoldPassword.Visible = false;
            txtHoldPassword.Visible = false;
            cdvReworkFlow.Visible = false;
            cdvReworkOper.Visible = false;
            cdvReworkStopOper.Visible = false;
            cdvReturnFlow.Visible = false;
            cdvReturnOper.Visible = false;
            cboReturnOption.Visible = false;
            lblReturnOption.Visible = false;
            grpTranCMF.Visible = false;

            cdvHoldCode.Text = "";
            txtHoldPassword.Text = "";
            cdvReworkFlow.ClearField();
            cdvReworkOper.ClearField();
            cdvReworkStopOper.ClearField();
            cdvReturnFlow.ClearField();
            cdvReturnOper.ClearField();
            cboReturnOption.SelectedIndex = 0;
            txtComment.Text = "";

            if (MPCF.Trim(cboTran.Text) == "HOLD")
            {
                lblHoldCode.Text = MPCF.FindLanguage("Hold Code", CAPTION_TYPE.LABEL);
                lblHoldCode.Visible = true;
                cdvHoldCode.Visible = true;
                lblHoldPassword.Visible = true;
                txtHoldPassword.Visible = true;
                
                grpTranCMF.Visible = true;
            }
            else if (MPCF.Trim(cboTran.Text) == "FUTURE HOLD")
            {
                lblHoldCode.Text = MPCF.FindLanguage("Hold Code", CAPTION_TYPE.LABEL);
                lblHoldCode.Visible = true;
                cdvHoldCode.Visible = true;
                lblHoldPassword.Visible = true;
                txtHoldPassword.Visible = true;
                cdvReworkFlow.Visible = true;
                cdvReworkOper.Visible = true;

                cdvReworkFlow.LabelText = MPCF.FindLanguage("Flow", CAPTION_TYPE.LABEL);
                cdvReworkOper.LabelText = MPCF.FindLanguage("Operation", CAPTION_TYPE.LABEL);
                
                grpTranCMF.Visible = true;
            }
            else if (MPCF.Trim(cboTran.Text) == "REWORK")
            {
                lblHoldCode.Text = MPCF.FindLanguage("Rework Code", CAPTION_TYPE.LABEL);
                lblHoldCode.Visible = true;
                cdvHoldCode.Visible = true;
                cdvReworkFlow.Visible = true;
                cdvReworkOper.Visible = true;
                cdvReworkStopOper.Visible = true;
                cdvReturnFlow.Visible = true;
                cdvReturnOper.Visible = true;
                cboReturnOption.Visible = true;
                lblReturnOption.Visible = true;

                cdvReworkFlow.LabelText = MPCF.FindLanguage("Rework Flow", CAPTION_TYPE.LABEL);
                cdvReworkOper.LabelText = MPCF.FindLanguage("Rework Operation", CAPTION_TYPE.LABEL);

                grpTranCMF.Visible = true;
            }

            if (MPCF.Trim(cboTran.Text) == "HOLD" || MPCF.Trim(cboTran.Text) == "FUTURE HOLD")
            {
                MPCR.SetCMFItem(MPGC.MP_CMF_TRN_HOLD, "lblCMF", "cdvCMF", grpTranCMF);
            }
            else if (MPCF.Trim(cboTran.Text) == "REWORK")
            {
                MPCR.SetCMFItem(MPGC.MP_CMF_TRN_REWORK, "lblCMF", "cdvCMF", grpTranCMF);
            }
        }

        private void SetGroupCmfItem()
        {
            string[] sGrpTableName = new string[10];

            sGrpTableName[0] = MPGC.MP_GCM_ALARM_GRP_1;
            sGrpTableName[1] = MPGC.MP_GCM_ALARM_GRP_2;
            sGrpTableName[2] = MPGC.MP_GCM_ALARM_GRP_3;
            sGrpTableName[3] = MPGC.MP_GCM_ALARM_GRP_4;
            sGrpTableName[4] = MPGC.MP_GCM_ALARM_GRP_5;
            sGrpTableName[5] = MPGC.MP_GCM_ALARM_GRP_6;
            sGrpTableName[6] = MPGC.MP_GCM_ALARM_GRP_7;
            sGrpTableName[7] = MPGC.MP_GCM_ALARM_GRP_8;
            sGrpTableName[8] = MPGC.MP_GCM_ALARM_GRP_9;
            sGrpTableName[9] = MPGC.MP_GCM_ALARM_GRP_10;

            MPCR.SetGRPItem(MPGC.MP_GRP_ALARM, "lblGroup", "cdvGroup", grpAlarmGroup, sGrpTableName);
            MPCR.SetCMFItem(MPGC.MP_CMF_ALARM, "lblAlarmCMF", "cdvAlarmCMF", grpAlarmCMF);
        }

        #endregion

        private void frmALMSetupAlarm_Load(object sender, EventArgs e)
        {
            // 2010.02.08
            // 현재 무료 PDF Viewer 가 없으므로 한시적으로 tbpPDF Tab 은 보이지 않도록 한다.
            tabAlarm.TabPages.Remove(tbpPDF);
        }

        private void frmALMSetupAlarm_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (bLoadFlag == false)
                {
                    MPCF.FieldClear(this);
                    MPCF.InitListView(lisAlarm);
                    MPCF.InitListView(lisRecvList);
                    MPCF.InitListView(lisUserList);
                    MPCF.InitListView(lisSecGrpList);
                    MPCF.InitListView(lisPrvGrpList);

                    ClearCodeView(1);
                    ClearCodeView(2);

                    chkResAlarmFlag.Checked = false;
                    chkResAlarmFlag_CheckedChanged(null, null);

                    rbnInformation.Checked = true;
                    rbnUser.Checked = true;

                    SECLIST.ViewSECUserList(lisUserList);
                    SECLIST.ViewSecGroupList(lisSecGrpList);
                    SECLIST.ViewPrvGroupList(lisPrvGrpList);

                    cboAlarmType.SelectedIndex = 0;

                    SetGroupCmfItem();

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
            
            MPCF.FindListItemNextPartial(lisAlarm, txtFind.Text, true, false);
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {            
            MPCF.FindListItemPartial(lisAlarm, txtFind.Text, 0, true, false);            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            char c_alarm_type;    
            try
            {
                c_alarm_type = ' ';
                switch (cboAlarmType.SelectedIndex)
                {
                    case 0: // all alarm
                        c_alarm_type = ' ';
                        break;
                    case 1: // normal alarm
                        c_alarm_type = 'N';
                        break;
                    case 2: // resource alarm
                        c_alarm_type = 'R';
                        break;
                    case 3: // automatic gathered alarm
                        c_alarm_type = 'A';
                        break;
                }

                lblDataCount.Text = "";
                if (ALMLIST.ViewAlarmMsgList(lisAlarm, '1', c_alarm_type) == true)
                {
                    lblDataCount.Text = lisAlarm.Items.Count.ToString();
                    if (lisAlarm.Items.Count > 0)
                    {
                        if (MPCF.Trim(txtAlarmID.Text) == "")
                            lisAlarm.Items[0].Selected = true;
                        else
                            MPCF.FindListItem(lisAlarm, txtAlarmID.Text, false);
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
            MPCF.ExportToExcel(lisAlarm, this.Text, "");            
        }

        private void cboAlarmType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void chkResAlarmFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (chkResAlarmFlag.Checked == false)
            {
                grpClearEvent.Visible = false;
                grpClearChgStatus.Visible = false;
                grpClearResComment.Visible = false;
            }
            else
            {
                grpClearEvent.Visible = true;
                grpClearChgStatus.Visible = true;
                grpClearResComment.Visible = true;
            }
        }
        
        private void cdvCMF_ButtonPress(System.Object sender, System.EventArgs e)
        {            
            MPCR.ProcGRPCMFButtonPress(sender);            
        }

        private void cdvCMF_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {            
            MPCR.CheckCMFKeyPress(sender, e);            
        }
        
        private void lisAlarm_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FieldClear(this.pnlRight);
            rbnInformation.Checked = true;
            rbnUser.Checked = true;
            if (lisAlarm.SelectedItems.Count > 0)
            {
                txtAlarmID.Text = lisAlarm.SelectedItems[0].Text;
                ViewAlarmMsg();
            }
        }
        
        private void cdvHoldCode_ButtonPress(object sender, System.EventArgs e)
        {
            if (MPCF.Trim(cboTran.Text) == "REWORK")
            {
                cdvHoldCode.Init();
                MPCF.InitListView(cdvHoldCode.GetListView);
                cdvHoldCode.Columns.Add("Rework Code", 150, HorizontalAlignment.Left);
                cdvHoldCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvHoldCode.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdvHoldCode.GetListView, '1', "REWORK_CODE");
            }
            else if (MPCF.Trim(cboTran.Text) == "HOLD" || MPCF.Trim(cboTran.Text) == "FUTURE HOLD")
            {
                cdvHoldCode.Init();
                MPCF.InitListView(cdvHoldCode.GetListView);
                cdvHoldCode.Columns.Add("Hold Code", 150, HorizontalAlignment.Left);
                cdvHoldCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvHoldCode.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdvHoldCode.GetListView, '1', MPGC.MP_WIP_HOLD_CODE);
            }
            else
            {
                cdvHoldCode.IsPopup = false;

                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvHoldCode.Focus();
            }
        }

        private void cdvEvent_ButtonPress(System.Object sender, System.EventArgs e)
        {
            cdvEvent.Init();
            MPCF.InitListView(cdvEvent.GetListView);
            cdvEvent.Columns.Add("Event", 50, HorizontalAlignment.Left);
            cdvEvent.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvEvent.SelectedSubItemIndex = 0;
#if _RAS
            RASLIST.ViewEventList(cdvEvent.GetListView, '1', "", null, "");
#endif
        }

        private void cdvEvent_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvEvent.Text) == "") return;

            ViewEvent(1, cdvEvent.Text);
        }

        private void cdvEvent_TextBoxTextChanged(System.Object sender, System.EventArgs e)
        {
            if (MPCF.Trim(cdvEvent.Text) == "")
                ClearCodeView(1);
        }

        private void cdvClearEvent_ButtonPress(System.Object sender, System.EventArgs e)
        {
            cdvClearEvent.Init();
            MPCF.InitListView(cdvClearEvent.GetListView);
            cdvClearEvent.Columns.Add("Event", 50, HorizontalAlignment.Left);
            cdvClearEvent.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvClearEvent.SelectedSubItemIndex = 0;
#if _RAS
            RASLIST.ViewEventList(cdvClearEvent.GetListView, '1', "", null, "");
#endif
        }

        private void cdvClearEvent_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvClearEvent.Text) == "") return;

            ViewEvent(2, cdvClearEvent.Text);
        }

        private void cdvClearEvent_TextBoxTextChanged(System.Object sender, System.EventArgs e)
        {
            if (MPCF.Trim(cdvClearEvent.Text) == "")
                ClearCodeView(2);
        }

        private void cdvChangeStatus_ButtonPress(System.Object sender, System.EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;

            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            if (MPCF.Trim(cdvTemp.Tag) == "") return;

            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("Status", 50, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', MPCF.Trim(cdvTemp.Tag));

        }

        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {            
            try
            {
                if (CheckCondition(MPGC.MP_STEP_CREATE) == true)
                {
                    if (UpdateAlarmMsg(MPGC.MP_STEP_CREATE) == false)
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
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {            
            try
            {
                if (CheckCondition(MPGC.MP_STEP_UPDATE) == true)
                {
                    if (UpdateAlarmMsg(MPGC.MP_STEP_UPDATE) == false)
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
        
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {            
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (CheckCondition(MPGC.MP_STEP_DELETE) == true)
                {
                    if (UpdateAlarmMsg(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }
                    MPCF.FieldClear(pnlRight);
                    rbnInformation.Checked = true;
                    rbnUser.Checked = true;

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

        private void rbnReceiver_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbnTemp = (RadioButton)sender;

            switch (rbnTemp.Name)
            {
                case "rbnUser":
                    lisUserList.Visible = true;
                    lisSecGrpList.Visible = false;
                    lisPrvGrpList.Visible = false;
                    break;
                case "rbnSecGroup":
                    lisUserList.Visible = false;
                    lisSecGrpList.Visible = true;
                    lisPrvGrpList.Visible = false;
                    break;
                case "rbnPrvGroup":
                    lisUserList.Visible = false;
                    lisSecGrpList.Visible = false;
                    lisPrvGrpList.Visible = true;
                    break;
            }            
        }

        private void btnAttach_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            ListView lisTemp;
            ListViewItem itmX;
            string s_recv_type;
            string s_recv_shift;
            int i_icon_index;

            string s_rcvr_id;

            lisTemp = null;
            s_recv_type = "";
            i_icon_index = (int)SMALLICON_INDEX.IDX_USER;

            if (rbnUser.Checked == true)
            {
                lisTemp = lisUserList;
                s_recv_type = RCVR_USER;
                i_icon_index = (int)SMALLICON_INDEX.IDX_USER;
            }
            else if (rbnSecGroup.Checked == true)
            {
                lisTemp = lisSecGrpList;
                s_recv_type = RCVR_SEC_GROUP;
                i_icon_index = (int)SMALLICON_INDEX.IDX_SEC_GROUP;
            }
            else if (rbnPrvGroup.Checked == true)
            {
                lisTemp = lisPrvGrpList;
                s_recv_type = RCVR_PRV_GROUP;
                i_icon_index = (int)SMALLICON_INDEX.IDX_PRIVILEGE_GROUP;
            }

            if (lisTemp.SelectedItems.Count < 1) return;


            if (chkShift1.Checked == true && chkShift2.Checked == true && chkShift3.Checked == true && chkShift4.Checked == true)
            {
                chkShift1.Checked = false;
                chkShift2.Checked = false;
                chkShift3.Checked = false;
                chkShift4.Checked = false;
            }

            s_recv_shift = "";
            if (chkShift1.Checked == true)
                s_recv_shift += "1";
            else
                s_recv_shift += "_";
            if (chkShift2.Checked == true)
                s_recv_shift += "2";
            else
                s_recv_shift += "_";
            if (chkShift3.Checked == true)
                s_recv_shift += "3";
            else
                s_recv_shift += "_";
            if (chkShift4.Checked == true)
                s_recv_shift += "4";
            else
                s_recv_shift += "_";


            for (i = 0; i < lisTemp.SelectedItems.Count; i++)
            {
                s_rcvr_id = lisTemp.SelectedItems[i].Text;
                if (MPCF.FindListItemIndex(lisRecvList, s_rcvr_id, false) < 0)
                {
                    itmX = new ListViewItem(s_rcvr_id, i_icon_index);
                    itmX.SubItems.Add(s_recv_type);
                    itmX.SubItems.Add(s_recv_shift);
                    lisRecvList.Items.Add(itmX);

                    lisTemp.SelectedItems[i].ForeColor = Color.Blue;
                }
            }
        }

        private void btnDetach_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            string s_rcvr_id;
            string s_recv_type;
            ListView lisTemp;
            int i_source_index;
            ArrayList a_item;

            if (lisRecvList.SelectedItems.Count < 1) return;

            a_item = new ArrayList();
            lisTemp = null;
            for (i = 0; i < lisRecvList.SelectedItems.Count; i++)
            {
                s_rcvr_id = lisRecvList.SelectedItems[i].Text;
                s_recv_type = lisRecvList.SelectedItems[i].SubItems[1].Text;

                lisTemp = null;
                switch (s_recv_type)
                {
                    case RCVR_USER:
                        lisTemp = lisUserList;
                        break;
                    case RCVR_SEC_GROUP:
                        lisTemp = lisSecGrpList;
                        break;
                    case RCVR_PRV_GROUP:
                        lisTemp = lisPrvGrpList;
                        break;
                }

                i_source_index = MPCF.FindListItemIndex(lisTemp, s_rcvr_id, false);
                if (i_source_index >= 0)
                {
                    lisTemp.Items[i_source_index].ForeColor = SystemColors.WindowText;
                }

                a_item.Add(lisRecvList.SelectedItems[i]);
            }

            for (i = 0; i < a_item.Count; i++)
            {
                lisRecvList.Items.Remove((ListViewItem)a_item[i]);
            }
        }

        private void cboTran_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetLotTran();
        }

        private void cdvReworkFlow_FlowSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cboTran.Text) == "REWORK")
            {
                cdvReworkOper.Text = "";
                cdvReworkStopOper.Text = "";
            }
        }

        private void cdvReworkOper_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cboTran.Text) == "REWORK")
            {
                cdvReworkOper.ListCond_Step = '2';
                cdvReworkOper.ListCond_Flow = cdvReworkFlow.Text;
            }
            else
            {
                if (MPCF.Trim(cdvReworkFlow.Text) == "")
                {
                    cdvReworkOper.ListCond_Step = '1';
                }
                else
                {
                    cdvReworkOper.ListCond_Step = '2';
                    cdvReworkOper.ListCond_Flow = cdvReworkFlow.Text;
                }
            }
        }

        private void cdvReworkStopOper_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cboTran.Text) == "REWORK")
            {
                cdvReworkStopOper.ListCond_Step = '2';
                cdvReworkStopOper.ListCond_Flow = cdvReworkFlow.Text;
            }
        }

        private void cdvReturnFlow_FlowSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cboTran.Text) == "REWORK")
            {
                cdvReturnOper.Text = "";
            }
        }

        private void cdvReturnOper_ButtonPress(object sender, EventArgs e)
        {
            cdvReturnOper.ListCond_Flow = cdvReturnFlow.Text;
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
            if (tbpComment.Width - 498 > 0)
            {
                spdComment.ActiveSheet.Columns[0].Width = 414 + (tbpComment.Width - 498);
            }
            else
            {
                spdComment.ActiveSheet.Columns[0].Width = 414;
            }
        }


    }

}
//#End If

