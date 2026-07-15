//-----------------------------------------------------------------------------
//
//   System      : MES   
//   File Name   : frmWIPSetupQueueTime.cs
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

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPSetupQueueTime : Miracom.MESCore.SetupForm02
    {
        public frmWIPSetupQueueTime()
        {
            InitializeComponent();
        }

        #region "Constant Definition"

        private enum COL
        {
            PRIORITY = 0,
            MATID,
            MATVER,
            FLOW,
            FLOWSEQ,
            OPER,
            FROM_FACTORY,
            FROM_FLOW,
            FROM_FLOWSEQ,
            FROM_OPER,
            FROM_POINT,
            CHECK_POINT,
            LWL,
            UWL,
            WARN_ALARM,
            LEL,
            UEL,
            ERR_ALARM,
            LOT_CMF1,
            LOT_CMF2,
            LOT_CMF3,
            LOT_CMF4,
            LOT_CMF5,
            LOT_CMF6,
            LOT_CMF7,
            LOT_CMF8,
            LOT_CMF9,
            LOT_CMF10,
            LOT_CMF11,
            LOT_CMF12,
            LOT_CMF13,
            LOT_CMF14,
            LOT_CMF15,
            LOT_CMF16,
            LOT_CMF17,
            LOT_CMF18,
            LOT_CMF19,
            LOT_CMF20
        }
        
        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private bool b_merge_flag;

        #endregion

        #region " Function Definition "

        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1")
        //
        private void ClearData(string ProcStep)
        {
            try
            {
                if (ProcStep == "1")
                {
                    MPCF.FieldClear(grpRange);
                    MPCF.FieldClear(grpCMF);                                      
                }
                else if (ProcStep == "2")
                {
                    MPCF.FieldClear(grpCMF);                    
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }
        
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
            if (MPCF.Trim(udcMFO.SelectLevelChar) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                udcMFO.Focus();
                return false;
            }

            if (cdvMaterial.Enabled == true)
            {
                if (MPCF.Trim(cdvMaterial.Text) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    cdvMaterial.Focus();
                    return false;
                }
            }

            if (cdvFlow.Enabled == true)
            {
                if (MPCF.Trim(cdvFlow.Text) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    cdvFlow.Focus();
                    return false;
                }
            }

            if (MPCF.Trim(cdvOper.Text) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                cdvOper.Focus();
                return false;
            }

            if (cdvFromFlow.Enabled == true)
            {
                if (MPCF.Trim(cdvFromFlow.Text) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    cdvFromFlow.Focus();
                    return false;
                }
            }

            if (MPCF.Trim(cdvFromOper.Text) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                cdvFromOper.Focus();
                return false;
            }
            if ((cdvFromOper.Text == MPCF.Trim(cdvOper.Text)) && (cdvFromFlow.Text == MPCF.Trim(cdvFlow.Text)) && (cboFromPoint.Text == cboCheckPoint.Text))
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(186));
                cdvFromOper.Focus();
                return false;
            }
            //if (udcMFO.SelectedItem != Miracom.MESCore.Controls.TreeSelectedItem.Oper)
            //{
            //    MPCF.ShowMsgBox(MPCF.GetMessage(109));
            //    udcMFO.Focus();
            //    return false;
            //}
            if (ProcStep != MPGC.MP_STEP_DELETE)
            {
                if (nudWarnLQTime.Value > 0 || nudWarnUQTime.Value > 0)
                {
                    if (nudWarnLQTime.Value > nudWarnUQTime.Value && nudWarnUQTime.Value > 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(214));
                        nudWarnUQTime.Focus();
                        return false;
                    }
                }

                if (nudErrorLQTime.Value > 0 || nudErrorUQTime.Value > 0)
                {
                    if (nudErrorLQTime.Value > nudErrorUQTime.Value && nudErrorUQTime.Value > 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(214));
                        nudErrorUQTime.Focus();
                        return false;
                    }
                }

                if (nudErrorLQTime.Value <= 0 && nudWarnLQTime.Value <= 0 && nudErrorUQTime.Value <= 0 && nudWarnUQTime.Value <= 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    nudWarnLQTime.Focus();
                    return false;
                }
                if (MPCF.CheckValue( txtPriority, 1) == false) return false;
                if (MPCF.CheckFormat(MPGC.PROMPT_NUMBER, txtPriority.Text) == false)
                {
                    txtPriority.Focus();
                    return false;
                }
                if (MPCF.ToInt(txtPriority.Text) <= 0)
                {
                    txtPriority.Focus();
                    MPCF.ShowMsgBox(MPCF.GetMessage(114));
                    return false;
                }
                if (chkSubLot.Checked == true)
                {
                    if (rbnCount.Checked == false && rbnPercentage.Checked == false && rbnAverage.Checked == false)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        rbnCount.Checked = true;
                        rbnCount.Focus();
                        return false;
                    }
                    if (rbnCount.Checked == true)
                    {
                        if (MPCF.CheckValue(txtCount, 1) == false) return false;
                        if (MPCF.ToInt(txtCount.Text) <= 0)
                        {
                            txtCount.Focus();
                            MPCF.ShowMsgBox(MPCF.GetMessage(114));
                            return false;
                        }
                    }
                    if (rbnPercentage.Checked == true)
                    {
                        if (MPCF.CheckValue(txtPer, 1) == false) return false;
                        if (MPCF.ToInt(txtPer.Text) <= 0)
                        {
                            txtPer.Focus();
                            MPCF.ShowMsgBox(MPCF.GetMessage(114));
                            return false;
                        }
                    }
                }

                if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                {
                    tabQueueTime.SelectedTab = tbpCMF;
                    return false;
                }
            }
            
            return true;

        }
                
        //
        // ViewMFOQueueTimeList()
        //       - View MFO-Queue Tiem List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewMFOQueueTimeList(char OptLevel, string MatID, int MatVer, string Flow, int FlowVer, string Oper)
        {
            ListViewItem itm;
            int i;

            TRSNode in_node = new TRSNode("VIEW_MFO_QUEUE_TIME_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_MFO_QUEUE_TIME_LIST_OUT");

            MPCF.InitListView(lisQueueTimeList);
            lisQueueTimeList.Items.Clear();

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("MAT_ID", MPCF.Trim(MatID));
                in_node.AddInt("MAT_VER", MatVer);
                in_node.AddString("FLOW", MPCF.Trim(Flow));
                in_node.AddInt("FLOW_SEQ_NUM", FlowVer);
                in_node.AddString("OPER", MPCF.Trim(Oper));
                in_node.AddChar("OPT_LEVEL", OptLevel);

                do
                {
                    if (MPCR.CallService("WIP", "WIP_View_MFO_Queue_Time_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        itm = new ListViewItem(out_node.GetList(0)[i].GetInt("PRIORITY").ToString(), (int)SMALLICON_INDEX.IDX_MATERIAL);

                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("MAT_ID"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetInt("MAT_VER").ToString());
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("FLOW"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM").ToString());
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("OPER"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("FROM_FACTORY"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("FROM_FLOW"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetInt("FROM_FLOW_SEQ_NUM").ToString());
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("FROM_OPER"));

                        switch (out_node.GetList(0)[i].GetChar("FROM_POINT_FLAG"))
                        {
                            case ' ': itm.SubItems.Add("Oper Out"); break;
                            case 'I': itm.SubItems.Add("Oper In"); break;
                            case 'S': itm.SubItems.Add("Start"); break;
                            case 'E': itm.SubItems.Add("End"); break;
                        }
                        itm.SubItems[itm.SubItems.Count - 1].Tag = out_node.GetList(0)[i].GetChar("FROM_POINT_FLAG");

                        switch (out_node.GetList(0)[i].GetChar("CHECK_POINT_FLAG"))
                        {
                            case ' ': itm.SubItems.Add("AnyWhere"); break;
                            case 'O': itm.SubItems.Add("Oper Out"); break;
                            case 'I': itm.SubItems.Add("Oper In"); break;
                            case 'S': itm.SubItems.Add("Start"); break;
                            case 'E': itm.SubItems.Add("End"); break;
                        }
                        itm.SubItems[itm.SubItems.Count - 1].Tag = out_node.GetList(0)[i].GetChar("CHECK_POINT_FLAG");

                        if (out_node.GetList(0)[i].GetInt("LOWER_ERR_QUE_TIME") == 0)
                            itm.SubItems.Add(" ");
                        else
                            itm.SubItems.Add(out_node.GetList(0)[i].GetInt("LOWER_ERR_QUE_TIME").ToString());

                        if (out_node.GetList(0)[i].GetInt("LOWER_WARN_QUE_TIME") == 0)
                            itm.SubItems.Add(" ");
                        else
                            itm.SubItems.Add(out_node.GetList(0)[i].GetInt("LOWER_WARN_QUE_TIME").ToString());

                        if (out_node.GetList(0)[i].GetInt("UPPER_WARN_QUE_TIME") == 0)
                            itm.SubItems.Add(" ");
                        else
                            itm.SubItems.Add(out_node.GetList(0)[i].GetInt("UPPER_WARN_QUE_TIME").ToString());

                         if (out_node.GetList(0)[i].GetInt("UPPER_ERR_QUE_TIME") == 0)
                            itm.SubItems.Add(" ");
                        else
                            itm.SubItems.Add(out_node.GetList(0)[i].GetInt("UPPER_ERR_QUE_TIME").ToString());

                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("WARN_ALARM_ID"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("ERROR_ALARM_ID"));

                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_1"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_2"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_3"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_4"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_5"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_6"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_7"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_8"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_9"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_10"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_11"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_12"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_13"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_14"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_15"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_16"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_17"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_18"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_19"));
                        itm.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_CMF_20"));

                        lisQueueTimeList.Items.Add(itm);
                    }

                    in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));
                } while (in_node.GetInt("NEXT_SEQ") > 0);

                lisQueueTimeList.ListViewItemSorter = new ListViewItemComparer(1, SortOrder.Descending, ListViewItemComparer.SORTING_OPTION.STRING_TYPE);
                lisQueueTimeList.Sort();
                lisQueueTimeList.ListViewItemSorter = null;

                MPCF.FitColumnHeader(lisQueueTimeList, true);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewMFOQueueTime()
        {
            TRSNode in_node = new TRSNode("VIEW_MFO_QUEUE_TIME_IN");
            TRSNode out_node = new TRSNode("VIEW_MFO_QUEUE_TIME_OUT");

            try
            {
                MPCF.FieldClear(grpAlarmInfo);
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("MAT_ID", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.MATID].Text));
                in_node.AddInt("MAT_VER", MPCF.ToInt(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.MATVER].Text));
                in_node.AddString("FLOW", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.FLOW].Text));
                in_node.AddInt("FLOW_SEQ_NUM", MPCF.ToInt(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.FLOWSEQ].Text));
                in_node.AddString("OPER", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.OPER].Text));
                in_node.AddString("FROM_FACTORY", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.FROM_FACTORY].Text));
                in_node.AddString("FROM_FLOW", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.FROM_FLOW].Text));
                in_node.AddInt("FROM_FLOW_SEQ_NUM", MPCF.ToInt(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.FROM_FLOWSEQ].Text));
                in_node.AddString("FROM_OPER", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.FROM_OPER].Text));
                in_node.AddChar("FROM_POINT_FLAG", MPCF.ToChar(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.FROM_POINT].Tag));
                in_node.AddChar("CHECK_POINT_FLAG", MPCF.ToChar(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.CHECK_POINT].Tag));

                in_node.AddString("LOT_CMF_1", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.LOT_CMF1].Text));
                in_node.AddString("LOT_CMF_2", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.LOT_CMF2].Text));
                in_node.AddString("LOT_CMF_3", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.LOT_CMF3].Text));
                in_node.AddString("LOT_CMF_4", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.LOT_CMF4].Text));
                in_node.AddString("LOT_CMF_5", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.LOT_CMF5].Text));
                in_node.AddString("LOT_CMF_6", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.LOT_CMF6].Text));
                in_node.AddString("LOT_CMF_7", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.LOT_CMF7].Text));
                in_node.AddString("LOT_CMF_8", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.LOT_CMF8].Text));
                in_node.AddString("LOT_CMF_9", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.LOT_CMF9].Text));
                in_node.AddString("LOT_CMF_10", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.LOT_CMF10].Text));
                in_node.AddString("LOT_CMF_11", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.LOT_CMF11].Text));
                in_node.AddString("LOT_CMF_12", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.LOT_CMF12].Text));
                in_node.AddString("LOT_CMF_13", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.LOT_CMF13].Text));
                in_node.AddString("LOT_CMF_14", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.LOT_CMF14].Text));
                in_node.AddString("LOT_CMF_15", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.LOT_CMF15].Text));
                in_node.AddString("LOT_CMF_16", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.LOT_CMF16].Text));
                in_node.AddString("LOT_CMF_17", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.LOT_CMF17].Text));
                in_node.AddString("LOT_CMF_18", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.LOT_CMF18].Text));
                in_node.AddString("LOT_CMF_19", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.LOT_CMF19].Text));
                in_node.AddString("LOT_CMF_20", MPCF.Trim(lisQueueTimeList.SelectedItems[0].SubItems[(int)COL.LOT_CMF20].Text));

                if (MPCR.CallService("WIP", "WIP_View_Queue_Time", in_node, ref out_node) == false)
                {
                    return false;
                }
                txtPriority.Text = out_node.GetInt("PRIORITY").ToString();
                if (cdvMaterial.Enabled == true)
                {
                    cdvMaterial.Text = out_node.GetString("MAT_ID");
                    cdvMaterial.Version = out_node.GetInt("MAT_VER");
                }
                if (cdvFlow.Enabled == true)
                {
                    cdvFlow.Text = out_node.GetString("FLOW");
                    cdvFlow.Sequence = out_node.GetInt("FLOW_SEQ_NUM");
                }
                cdvOper.Text = out_node.GetString("OPER");
                cdvFromFactory.Text = out_node.GetString("FROM_FACTORY");
                cdvFromFlow.Text = out_node.GetString("FROM_FLOW");
                cdvFromFlow.Sequence = out_node.GetInt("FROM_FLOW_SEQ_NUM");
                cdvFromOper.Text = out_node.GetString("FROM_OPER");

                switch (out_node.GetChar("FROM_POINT_FLAG"))
                {
                    case ' ': cboFromPoint.SelectedIndex = 0; break;
                    case 'I': cboFromPoint.SelectedIndex = 1; break;
                    case 'S': cboFromPoint.SelectedIndex = 2; break;
                    case 'E': cboFromPoint.SelectedIndex = 3; break;
                }

                switch (out_node.GetChar("CHECK_POINT_FLAG"))
                {
                    case ' ': cboCheckPoint.SelectedIndex = 0; break;
                    case 'O': cboCheckPoint.SelectedIndex = 1; break;
                    case 'I': cboCheckPoint.SelectedIndex = 2; break;
                    case 'S': cboCheckPoint.SelectedIndex = 3; break;
                    case 'E': cboCheckPoint.SelectedIndex = 4; break;
                }

                nudWarnLQTime.Value = out_node.GetInt("LOWER_WARN_QUE_TIME");
                nudWarnUQTime.Value = out_node.GetInt("UPPER_WARN_QUE_TIME");
                cdvWarnAlarmID.Text = out_node.GetString("WARN_ALARM_ID");

                nudErrorLQTime.Value = out_node.GetInt("LOWER_ERR_QUE_TIME");
                nudErrorUQTime.Value = out_node.GetInt("UPPER_ERR_QUE_TIME");
                cdvErrorAlarmID.Text = out_node.GetString("ERROR_ALARM_ID");

                chkSearchMrgHis.Checked = out_node.GetChar("SEARCH_MRG_HIS_FLAG") == 'Y' ? true : false;
                b_merge_flag = chkSearchMrgHis.Checked;
                chkSubLot.Checked = out_node.GetChar("SUBLOT_FLAG") == 'Y' ? true : false;

                if (out_node.GetChar("SUBLOT_FLAG") == 'Y')
                {
                    if (out_node.GetChar("VIO_RULE_FLAG") == 'C')
                    {
                        rbnCount.Checked = true;
                        txtCount.Text = out_node.GetInt("VIO_LIMIT_NUM").ToString();
                    }
                    else if (out_node.GetChar("VIO_RULE_FLAG") == 'P')
                    {
                        rbnPercentage.Checked = true;
                        txtPer.Text = out_node.GetInt("VIO_LIMIT_NUM").ToString();
                    }
                    else if (out_node.GetChar("VIO_RULE_FLAG") == 'A')
                        rbnAverage.Checked = true;
                }

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

                cdvLotCMF1.Text = out_node.GetString("LOT_CMF_1");
                cdvLotCMF2.Text = out_node.GetString("LOT_CMF_2");
                cdvLotCMF3.Text = out_node.GetString("LOT_CMF_3");
                cdvLotCMF4.Text = out_node.GetString("LOT_CMF_4");
                cdvLotCMF5.Text = out_node.GetString("LOT_CMF_5");
                cdvLotCMF6.Text = out_node.GetString("LOT_CMF_6");
                cdvLotCMF7.Text = out_node.GetString("LOT_CMF_7");
                cdvLotCMF8.Text = out_node.GetString("LOT_CMF_8");
                cdvLotCMF9.Text = out_node.GetString("LOT_CMF_9");
                cdvLotCMF10.Text = out_node.GetString("LOT_CMF_10");
                cdvLotCMF11.Text = out_node.GetString("LOT_CMF_11");
                cdvLotCMF12.Text = out_node.GetString("LOT_CMF_12");
                cdvLotCMF13.Text = out_node.GetString("LOT_CMF_13");
                cdvLotCMF14.Text = out_node.GetString("LOT_CMF_14");
                cdvLotCMF15.Text = out_node.GetString("LOT_CMF_15");
                cdvLotCMF16.Text = out_node.GetString("LOT_CMF_16");
                cdvLotCMF17.Text = out_node.GetString("LOT_CMF_17");
                cdvLotCMF18.Text = out_node.GetString("LOT_CMF_18");
                cdvLotCMF19.Text = out_node.GetString("LOT_CMF_19");
                cdvLotCMF20.Text = out_node.GetString("LOT_CMF_20");
                
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

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
            /* Updated By YJJung 151210 Flow Sequence 못가져 와서 오른쪽 화면에 정보 못 뿌리는 Bug Fix */
            if (udcMFO.IncludeFlowSeqNum == true)
            {
                switch (udcMFO.SelectLevel)
                {
                    case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                        sb.Append("SELECT MAT_ID, MAT_VER, FLOW, FLOW_SEQ_NUM, OPER FROM MWIPQTMDEF ");
                        sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND MAT_ID <> ' ' ");
                        sb.Append("AND MAT_VER > 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                        sb.Append("GROUP BY MAT_ID, MAT_VER, FLOW, FLOW_SEQ_NUM, OPER ");
                        sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, FLOW ASC, OPER ASC");
                        break;

                    case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                        sb.Append("SELECT FLOW, FLOW_SEQ_NUM, OPER FROM MWIPQTMDEF ");
                        sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND MAT_ID = ' ' ");
                        sb.Append("AND MAT_VER = 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                        sb.Append("GROUP BY FLOW, FLOW_SEQ_NUM, OPER ");
                        sb.Append("ORDER BY FLOW ASC, OPER ASC");
                        break;

                    case Miracom.MESCore.Controls.MFOSelectLevel.O:
                        sb.Append("SELECT OPER FROM MWIPQTMDEF ");
                        sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND MAT_ID = ' ' ");
                        sb.Append("AND MAT_VER = 0 AND FLOW = ' ' AND OPER <> ' ' ");
                        sb.Append("GROUP BY OPER ");
                        sb.Append("ORDER BY OPER ASC");
                        break;

                }
            }
            else
            {
                switch (udcMFO.SelectLevel)
                {
                    case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                        sb.Append("SELECT MAT_ID, MAT_VER, FLOW, OPER FROM MWIPQTMDEF ");
                        sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND MAT_ID <> ' ' ");
                        sb.Append("AND MAT_VER > 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                        sb.Append("GROUP BY MAT_ID, MAT_VER, FLOW, OPER ");
                        sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, FLOW ASC, OPER ASC");
                        break;

                    case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                        sb.Append("SELECT FLOW, OPER FROM MWIPQTMDEF ");
                        sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND MAT_ID = ' ' ");
                        sb.Append("AND MAT_VER = 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                        sb.Append("GROUP BY FLOW, OPER ");
                        sb.Append("ORDER BY FLOW ASC, OPER ASC");
                        break;

                    case Miracom.MESCore.Controls.MFOSelectLevel.O:
                        sb.Append("SELECT OPER FROM MWIPQTMDEF ");
                        sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND MAT_ID = ' ' ");
                        sb.Append("AND MAT_VER = 0 AND FLOW = ' ' AND OPER <> ' ' ");
                        sb.Append("GROUP BY OPER ");
                        sb.Append("ORDER BY OPER ASC");
                        break;

                }
            }
            /* Updated End */

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
        // UpdateQueueTime()
        //       - Update Queue Time
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal c_step As String : Setp
        //
        private bool UpdateQueueTime(char c_step)
        {

            TRSNode in_node = new TRSNode("UPDATE_QUEUE_TIME_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
            in_node.AddInt("MAT_VER", cdvMaterial.Version);
            in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
            if (udcMFO.SelectLevelChar == '2')
                in_node.AddInt("FLOW_SEQ_NUM", 0);
            else
                in_node.AddInt("FLOW_SEQ_NUM", cdvFlow.Sequence);
            in_node.AddString("OPER", MPCF.Trim(cdvOper.Text));
            in_node.AddString("FROM_FACTORY", MPCF.Trim(cdvFromFactory.Text));
            in_node.AddString("FROM_FLOW", MPCF.Trim(cdvFromFlow.Text));
            in_node.AddInt("FROM_FLOW_SEQ_NUM", cdvFromFlow.Sequence);
            in_node.AddString("FROM_OPER", MPCF.Trim(cdvFromOper.Text));

            switch (cboFromPoint.SelectedIndex)
            {
                case 0: in_node.AddChar("FROM_POINT_FLAG", ' '); break;
                case 1: in_node.AddChar("FROM_POINT_FLAG", 'I'); break;
                case 2: in_node.AddChar("FROM_POINT_FLAG", 'S'); break;
                case 3: in_node.AddChar("FROM_POINT_FLAG", 'E'); break;
                default: in_node.AddChar("FROM_POINT_FLAG", ' '); break;
            }

            switch (cboCheckPoint.SelectedIndex)
            {
                case 0: in_node.AddChar("CHECK_POINT_FLAG", ' '); break;
                case 1: in_node.AddChar("CHECK_POINT_FLAG", 'O'); break;
                case 2: in_node.AddChar("CHECK_POINT_FLAG", 'I'); break;
                case 3: in_node.AddChar("CHECK_POINT_FLAG", 'S'); break;
                case 4: in_node.AddChar("CHECK_POINT_FLAG", 'E'); break;
                default: in_node.AddChar("CHECK_POINT_FLAG", ' '); break;
            }

            in_node.AddChar("OPTION_LEVEL", udcMFO.SelectLevelChar);
            in_node.AddInt("PRIORITY", MPCF.ToInt(txtPriority.Text));

            in_node.AddString("LOT_CMF_1", MPCF.Trim(cdvLotCMF1.Text));
            in_node.AddString("LOT_CMF_2", MPCF.Trim(cdvLotCMF2.Text));
            in_node.AddString("LOT_CMF_3", MPCF.Trim(cdvLotCMF3.Text));
            in_node.AddString("LOT_CMF_4", MPCF.Trim(cdvLotCMF4.Text));
            in_node.AddString("LOT_CMF_5", MPCF.Trim(cdvLotCMF5.Text));
            in_node.AddString("LOT_CMF_6", MPCF.Trim(cdvLotCMF6.Text));
            in_node.AddString("LOT_CMF_7", MPCF.Trim(cdvLotCMF7.Text));
            in_node.AddString("LOT_CMF_8", MPCF.Trim(cdvLotCMF8.Text));
            in_node.AddString("LOT_CMF_9", MPCF.Trim(cdvLotCMF9.Text));
            in_node.AddString("LOT_CMF_10", MPCF.Trim(cdvLotCMF10.Text));
            in_node.AddString("LOT_CMF_11", MPCF.Trim(cdvLotCMF11.Text));
            in_node.AddString("LOT_CMF_12", MPCF.Trim(cdvLotCMF12.Text));
            in_node.AddString("LOT_CMF_13", MPCF.Trim(cdvLotCMF13.Text));
            in_node.AddString("LOT_CMF_14", MPCF.Trim(cdvLotCMF14.Text));
            in_node.AddString("LOT_CMF_15", MPCF.Trim(cdvLotCMF15.Text));
            in_node.AddString("LOT_CMF_16", MPCF.Trim(cdvLotCMF16.Text));
            in_node.AddString("LOT_CMF_17", MPCF.Trim(cdvLotCMF17.Text));
            in_node.AddString("LOT_CMF_18", MPCF.Trim(cdvLotCMF18.Text));
            in_node.AddString("LOT_CMF_19", MPCF.Trim(cdvLotCMF19.Text));
            in_node.AddString("LOT_CMF_20", MPCF.Trim(cdvLotCMF20.Text));

            if (c_step != MPGC.MP_STEP_DELETE)
            {
                in_node.AddInt("UPPER_WARN_QUE_TIME", (int)nudWarnUQTime.Value);
                in_node.AddInt("LOWER_WARN_QUE_TIME", (int)nudWarnLQTime.Value);
                in_node.AddInt("UPPER_ERR_QUE_TIME", (int)nudErrorUQTime.Value);
                in_node.AddInt("LOWER_ERR_QUE_TIME", (int)nudErrorLQTime.Value);

                in_node.AddString("WARN_ALARM_ID", cdvWarnAlarmID.Text);
                in_node.AddString("ERROR_ALARM_ID", cdvErrorAlarmID.Text);

                in_node.AddChar("SEARCH_MRG_HIS_FLAG", chkSearchMrgHis.Checked == true ? 'Y' : ' ');
                in_node.AddChar("SUBLOT_FLAG", chkSubLot.Checked == true ? 'Y' : ' ');
                if (chkSubLot.Checked == true)
                {
                    if (rbnCount.Checked == true)
                    {
                        in_node.AddChar("VIO_RULE_FLAG", 'C');
                        in_node.AddInt("VIO_LIMIT_NUM", MPCF.ToInt(txtCount.Text));
                    }
                    else if (rbnPercentage.Checked == true)
                    {
                        in_node.AddChar("VIO_RULE_FLAG", 'P');
                        in_node.AddInt("VIO_LIMIT_NUM", MPCF.ToInt(txtPer.Text));
                    }
                    else if (rbnAverage.Checked == true)
                    {
                        in_node.AddChar("VIO_RULE_FLAG", 'A');
                        in_node.AddInt("VIO_LIMIT_NUM", 0);
                    }
                }

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

            if (MPCR.CallService("WIP", "WIP_Update_Queue_Time", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);
            return true;

        }
        private void RefreshQueueTimeList()
        {
            string s_mat_id;
            int i_mat_ver;
            string s_flow;
            int i_flow_seq;
            string s_oper;

            try
            {
                s_mat_id = s_flow = "";
                i_mat_ver = i_flow_seq = 0;

                if (cdvMaterial.Enabled == true)
                {
                    s_mat_id = cdvMaterial.Text;
                    i_mat_ver = cdvMaterial.Version;
                }

                if (cdvFlow.Enabled == true)
                {
                    s_flow = cdvFlow.Text;
                    i_flow_seq = cdvFlow.Sequence;
                }

                s_oper = cdvOper.Text;

                ViewMFOQueueTimeList(udcMFO.SelectLevelChar, s_mat_id, i_mat_ver, s_flow, i_flow_seq, s_oper);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }


        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.lisQueueTimeList;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }       

        #endregion

        private void frmWIPSetupQueueTime_Load(object sender, EventArgs e)
        {
            MPCR.SetCMFItem(MPGC.MP_CMF_QUEUETIME, "lblCMF", "cdvCMF", grpCMF);
            MPCR.SetCMFItem(MPGC.MP_CMF_LOT, "lblLotCMF", "cdvLotCMF", grpLotCMF);

            ArrayList lblList;
            Label lblTemp;
            int i;

            lblList = MPCF.GetIndexedControl("lblLotCMF", grpLotCMF);

            for (i = 0; i < 20; i++)
            {
                lisQueueTimeList.Columns[i + (int)COL.LOT_CMF1].Width = 0;
                lisQueueTimeList.Columns[i + (int)COL.LOT_CMF1].Text = "";

                lblTemp = (Label)lblList[i];
                if (MPCF.Trim(lblTemp.Text) != "")
                {
                    lisQueueTimeList.Columns[i + (int)COL.LOT_CMF1].Width = 80;
                    lisQueueTimeList.Columns[i + (int)COL.LOT_CMF1].Text = lblTemp.Text;
                }
            }

            if (MPGO.QueueTimeUnit() == "H")
            {
                this.lblTimeUnit.Text = "(Hour)";
            }
            else
            {
                this.lblTimeUnit.Text = "(Minute)";
            }
        }

        private void frmWIPSetupQueueTime_Activated(object sender, EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    MPCF.FieldClear(this);
                    MPCF.InitListView(lisQueueTimeList);
                    ClearData("1");

                    if (cdvFromFlow.FlowReadOnly == false)
                    {
                        cdvFromFlow.Focus();
                    }
                    else if (cdvFromOper.ReadOnly == false)
                    {
                        cdvFromOper.Focus();
                    }

                    b_load_flag = true;
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
            udcMFO.RefreshSelectedList();
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.ExportToExcel(lisQueueTimeList, this.Text, "");
        }

        private void cdvCmf_ButtonPress(System.Object sender, System.EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }

        private void cdvCMF_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);
        }

        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition(MPGC.MP_STEP_CREATE) == false) return;

                if (MPCF.ShowMsgBox(MPCF.GetMessage(304),  MessageBoxButtons.YesNo, 2) == DialogResult.No) return;
                if (UpdateQueueTime(MPGC.MP_STEP_CREATE) == false) return;

                RefreshQueueTimeList();

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

                if (b_merge_flag != chkSearchMrgHis.Checked)
                {
                    if (MPCF.ShowMsgBox(MPCF.GetMessage(304), MessageBoxButtons.YesNo, 2) == DialogResult.No) return;
                }
                if (UpdateQueueTime(MPGC.MP_STEP_UPDATE) == false) return;

                RefreshQueueTimeList();

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

                if (UpdateQueueTime(MPGC.MP_STEP_DELETE) == false) return;

                RefreshQueueTimeList();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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
            MPCF.FieldClear(tbpGeneral);
            if (MPCF.Trim(udcMFO.Oper) != "")
            {
                ViewMFOQueueTimeList(udcMFO.SelectLevelChar, udcMFO.MatID, udcMFO.MatVersion, udcMFO.Flow, udcMFO.FlowSeqNum, udcMFO.Oper);
                /* Updated By YJJung 151210 Bug Flow Sequence 가 나타나지 않는 현상 */
                //ViewMFOQueueTimeList(udcMFO.SelectLevelChar, udcMFO.MatID, udcMFO.MatVersion, udcMFO.Flow, MPCF.ToInt(udcMFO.SelectLevel) == 0 ? 1 : 0, udcMFO.Oper);
                cdvMaterial.Text = udcMFO.MatID;
                cdvMaterial.Version = udcMFO.MatVersion;
                cdvFlow.Text = udcMFO.Flow;
                if (MPCF.Trim(cdvMaterial.Text) != "" && MPCF.Trim(cdvFlow.Text) != "")
                {
                    cdvFlow_FlowButtonPress(null, null);
                    cdvFlow.Sequence = udcMFO.FlowSeqNum;
                    /* Updated By YJJung 151210 Bug Flow Sequence 가 나타나지 않는 현상 */
                    //cdvFlow.Sequence = 1;
                }
                else if (MPCF.Trim(cdvMaterial.Text) == "" && MPCF.Trim(cdvFlow.Text) != "")
                {
                    cdvFlow_FlowButtonPress(null, null);
                }
                cdvOper.Text = udcMFO.Oper;
            }
        }

        private void udcMFO_GetOnlySetData(object sender, EventArgs e)
        {
            ViewMFOSettingDataList();
        }

        private void udcMFO_SetDataSelectedIndexChanged(object sender, EventArgs e)
        {
            udcMFO_LevelItemSelect(null, null);
        }

        private void udcMFO_SelectLevelChanged(object sender, EventArgs e)
        {
            try
            {
                lisQueueTimeList.Items.Clear();

                cdvMaterial.Visible = false;
                cdvMaterial.Text = "";
                cdvMaterial.Enabled = false;

                cdvFlow.Visible = false;
                cdvFlow.Text = "";
                cdvFlow.Enabled = false;

                cdvOper.Visible = true;
                cdvOper.Text = "";
                cdvOper.Enabled = true;

                cdvFromFactory.Text = "";

                cdvFromFlow.Visible = false;
                cdvFromFlow.Text = "";
                cdvFromFlow.Enabled = false;

                cdvFromOper.Visible = true;
                cdvFromOper.Text = "";
                cdvFromOper.Enabled = true;

                cdvFlow.SequenceReadOnly = false;

                switch (udcMFO.SelectLevel)
                {
                    case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                        cdvMaterial.Visible = true;
                        cdvMaterial.Text = "";
                        cdvMaterial.Enabled = true;

                        cdvFlow.Visible = true;
                        cdvFlow.Text = "";
                        cdvFlow.Enabled = true;

                        cdvFromFlow.Visible = true;
                        cdvFromFlow.Text = "";
                        cdvFromFlow.Enabled = true;
                        break;

                    case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                        cdvFlow.Visible = true;
                        cdvFlow.Text = "";
                        cdvFlow.Enabled = true;
                        cdvFlow.SequenceReadOnly = true;

                        cdvFromFlow.Visible = true;
                        cdvFromFlow.Text = "";
                        cdvFromFlow.Enabled = true;

                        break;

                    case Miracom.MESCore.Controls.MFOSelectLevel.O:
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }

        }

        private void lisQueueTimeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisQueueTimeList.SelectedItems.Count > 0)
            {
                ViewMFOQueueTime();
            }
        }

        private void cdvFlow_FlowButtonPress(object sender, EventArgs e)
        {
            if (cdvMaterial.Text == "")
            {
                cdvFlow.ListCond_Step = '1';
            }
            else
            {
                cdvFlow.ListCond_Step = '2';
                cdvFlow.ListCond_MatID = cdvMaterial.Text;
                cdvFlow.ListCond_MatVersion = cdvMaterial.Version;
            }
        }

        private void cdvFlow_FlowSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvOper.Text = "";
        }

        private void cdvOper_ButtonPress(object sender, EventArgs e)
        {
            if (cdvMaterial.Text != "" && cdvFlow.Text != "")
            {
                cdvOper.ListCond_Step = '3';
                cdvOper.ListCond_MatID = cdvMaterial.Text;
                cdvOper.ListCond_MatVersion = cdvMaterial.Version;
                cdvOper.ListCond_Flow = cdvFlow.Text;
            }
            else
            {
                if (cdvFlow.Text != "")
                {
                    cdvOper.ListCond_Step = '2';
                    cdvOper.ListCond_Flow = cdvFlow.Text;
                }
                else
                {
                    cdvOper.ListCond_Step = '1';
                }
            }
        }

        private void cdvFromFactory_ButtonPress(object sender, EventArgs e)
        {
            cdvFromFactory.Init();
            MPCF.InitListView(cdvFromFactory.GetListView);
            cdvFromFactory.Columns.Add("Factory", 100, HorizontalAlignment.Left);
            cdvFromFactory.Columns.Add("Factory Desc", 100, HorizontalAlignment.Left);
            cdvFromFactory.SelectedSubItemIndex = 0;
            WIPLIST.ViewFactoryList(cdvFromFactory.GetListView, '1', null);
            int i;
            i = 0;
            while (i < cdvFromFactory.Items.Count)
            {
                if (MPCF.Trim(cdvFromFactory.Items[i].Text) == MPGV.gsFactory || MPCF.Trim(cdvFromFactory.Items[i].Text) == MPGV.gsCentralFactory)
                {
                    cdvFromFactory.Items.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }

        private void cdvFromFactory_TextBoxTextChanged(object sender, EventArgs e)
        {
            cdvFromFlow.Text = "";
            cdvFromOper.Text = "";
        }

        private void cdvFromFlow_FlowButtonPress(object sender, EventArgs e)
        {
            if (cdvFromFactory.Text != "")
            {
                cdvFromFlow.ListCond_ExtFactory = cdvFromFactory.Text;
                cdvFromFlow.ListCond_Step = '1';
            }
            else
            {
                cdvFromFlow.ListCond_ExtFactory = "";
                if (cdvMaterial.Text == "")
                {
                    cdvFromFlow.ListCond_Step = '1';
                }
                else
                {
                    cdvFromFlow.ListCond_Step = '2';
                    cdvFromFlow.ListCond_MatID = cdvMaterial.Text;
                    cdvFromFlow.ListCond_MatVersion = cdvMaterial.Version;
                }
            }
        }

        private void cdvFromFlow_FlowSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvFromOper.Text = "";
        }

        private void cdvFromOper_ButtonPress(object sender, EventArgs e)
        {
            cdvFromOper.ListCond_ExtFactory = cdvFromFactory.Text;

            if (cdvFromFlow.Text == "")
            {
                cdvFromOper.ListCond_Step = '1';
            }
            else
            {
                cdvFromOper.ListCond_Step = '2';
                cdvFromOper.ListCond_Flow = cdvFromFlow.Text;
            }
        }

        private void cdvWarnAlarmID_ButtonPress(object sender, EventArgs e)
        {
            cdvWarnAlarmID.Init();
            MPCF.InitListView(cdvWarnAlarmID.GetListView);
            cdvWarnAlarmID.Columns.Add("Alarm ID", 50, HorizontalAlignment.Left);
            cdvWarnAlarmID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvWarnAlarmID.SelectedSubItemIndex = 0;
            ALMLIST.ViewAlarmMsgList(cdvWarnAlarmID.GetListView, '1', ' ');
        }

        private void cdvErrorAlarmID_ButtonPress(object sender, EventArgs e)
        {
            cdvErrorAlarmID.Init();
            MPCF.InitListView(cdvErrorAlarmID.GetListView);
            cdvErrorAlarmID.Columns.Add("Alarm ID", 50, HorizontalAlignment.Left);
            cdvErrorAlarmID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvErrorAlarmID.SelectedSubItemIndex = 0;
            ALMLIST.ViewAlarmMsgList(cdvErrorAlarmID.GetListView, '1', ' ');
        }

        private void chkSubLot_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSubLot.Checked == true)
            {
                grpSublot.Visible = true;
            }
            else
            {
                grpSublot.Visible = false;
            }
        }
                
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (lisQueueTimeList.SelectedItems.Count > 0)
            {
                if (lisQueueTimeList.SelectedItems[0].Index == 0)
                    return;

                if (UpdateQueueTime('1') == true)
                {
                    RefreshQueueTimeList();
                }
            }
        }
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (lisQueueTimeList.SelectedItems.Count > 0)
            {
                if (lisQueueTimeList.SelectedItems[0].Index == lisQueueTimeList.Items.Count - 1)
                    return;

                if (UpdateQueueTime('2') == true)
                {
                    RefreshQueueTimeList();
                }
            }
        }

        private void rbnCount_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnCount.Checked == true)
            {
                txtPer.Text = "";
            }
            else if (rbnPercentage.Checked == true)
            {
                txtCount.Text = "";
            }
            else
            {
                txtCount.Text = "";
                txtPer.Text = "";
            }
        }


    }
}
