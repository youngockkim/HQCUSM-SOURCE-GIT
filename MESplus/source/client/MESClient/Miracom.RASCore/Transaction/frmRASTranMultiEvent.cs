//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASTranMultiEvent.cs
//   Description : Multi Event Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - GetResourceIDList() :Get ResourceID List
//       - Event() : Start Lot transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2008-02-22 : Created by W.Y.Choi
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI.Controls;
using Miracom.TRSCore;
namespace Miracom.RASCore
{
    public partial class frmRASTranMultiEvent : Miracom.MESCore.TranForm01
    {
        public frmRASTranMultiEvent()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private const char CHANGE = 'Y';
        private const char NOTCHANGE = 'N';
        private const char INCREASE = '+';
        private const char DECREASE = '-';
        private const char OVERRIDE = 'O';
        private const char TIME = 'T';

        #endregion

        #region " Variable Definition "

        bool b_load_flag;
        string[] sGrpTableName = new string[10];

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
        private void ClearData(char ProcStep)
        {

            try
            {
                if (ProcStep == '1')
                {
                    //MPCF.FieldClear(this, cdvResID, null, null, null, null, false);
                }
                else
                {
                    //MPCF.FieldClear(this, cdvResID, cdvEventID, null, null, null, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName)
        {
            int i;
            int iCount = 0;

            if (MPCF.CheckValue(cdvEventID, 1) == false)
            {
                tabResource.SelectedTab = tbpEvent;
                cdvEventID.Focus();
                return false;
            }

            for (i = 0; i < lisResourceList.Items.Count; i++)
            {
                if (lisResourceList.Items[i].Checked == true)
                {
                    iCount++;
                }
            }

            if (iCount == 0)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(272));
                tabTran.SelectedTab = tbpGeneral;
                return false;
            }

            if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
            {
                tabResource.SelectedTab = tbpCMF;
                return false;
            }

            return true;

        }

        private void SetGroupCmfItem()
        {

            sGrpTableName[0] = MPGC.MP_GCM_RES_GRP_1;
            sGrpTableName[1] = MPGC.MP_GCM_RES_GRP_2;
            sGrpTableName[2] = MPGC.MP_GCM_RES_GRP_3;
            sGrpTableName[3] = MPGC.MP_GCM_RES_GRP_4;
            sGrpTableName[4] = MPGC.MP_GCM_RES_GRP_5;
            sGrpTableName[5] = MPGC.MP_GCM_RES_GRP_6;
            sGrpTableName[6] = MPGC.MP_GCM_RES_GRP_7;
            sGrpTableName[7] = MPGC.MP_GCM_RES_GRP_8;
            sGrpTableName[8] = MPGC.MP_GCM_RES_GRP_9;
            sGrpTableName[9] = MPGC.MP_GCM_RES_GRP_10;

        }

        // SetGRPItem()
        //       - Set Group  Property to control
        // Return Value
        //       -
        // Arguments
        //        -
        public void SetGRPItem(params string[] sGrpTableName)
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            ListViewItem itmx = null;
            int i;

            try
            {
                cdvPrt1.Init();
                MPCF.InitListView(cdvPrt1.GetListView);
                cdvPrt1.Columns.Add("Group", 100, HorizontalAlignment.Left);
                cdvPrt1.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvPrt1.SelectedSubItemIndex = 1;
                cdvPrt1.DisplaySubItemIndex = 0;

                if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_GRP_RESOURCE, ref out_node, "", true) == false)
                {
                    return;
                }
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")) != "")
                    {
                        itmx = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")), (int)SMALLICON_INDEX.IDX_CODE_DATA);

                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("TABLE_NAME")) == "")
                        {
                            itmx.SubItems.Add(sGrpTableName[i]);
                        }
                        else
                        {
                            itmx.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TABLE_NAME")));
                        }
                        cdvPrt1.Items.Add(itmx);
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private bool GetEventIDList()
        {

            try
            {
                cdvEventID.Init();
                MPCF.InitListView(cdvEventID.GetListView);
                cdvEventID.Columns.Add("EventID", 50, HorizontalAlignment.Left);
                cdvEventID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvEventID.SelectedSubItemIndex = 0;

                if (RASLIST.ViewEventList(cdvEventID.GetListView, '1', "", null, "") == false)
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

        private bool View_Resource_List()
        {
            char cMFO_level = ' ';
            char cUpDownFlag = ' ';

            if (MPCF.Trim(cdvResGroup.Text) != "" &&
                (MPCF.Trim(cdvMaterial.Text) != "" ||
                 MPCF.Trim(cdvFlow.Text) != "" ||
                 MPCF.Trim(cdvOperation.Text) != ""))
            {
                cMFO_level = 'G';
            }
            else if (MPCF.Trim(cdvResGroup.Text) == "" &&
                     (MPCF.Trim(cdvMaterial.Text) != "" ||
                      MPCF.Trim(cdvFlow.Text) != "" ||
                      MPCF.Trim(cdvOperation.Text) != ""))
            {
                cMFO_level = ' ';
            }

            if (rbtDown.Checked == true)
            {
                cUpDownFlag = 'D';
            }
            else if (rbtUp.Checked == true)
            {
                cUpDownFlag = 'U';
            }

            RASLIST.ViewResourceListDetail(lisResourceList, 
                                           MPCF.Trim(cdvType.Text), MPCF.Trim(cdvGrp1.Text), "", "", 
                                           MPCF.Trim(cdvMaterial.Text),
                                           cdvMaterial.Version,
                                           MPCF.Trim(cdvFlow.Text),
                                           MPCF.Trim(cdvOperation.Text),
                                           MPCF.Trim(cdvLastEvent.Text), 
                                           cUpDownFlag,
                                           MPCF.Trim(cdvResGroup.Text),
                                           cMFO_level, 
                                           "", false, false, "", false);

            return true;
        }

        private bool Resource_Event(int iRowIndex)
        {

            TRSNode in_node = new TRSNode("RESOURCE_EVENT_IN");
            TRSNode out_node = new TRSNode("RESOURCE_EVENT_OUT");

            string sSpecCheckType = string.Empty;
            string tmpStr = string.Empty;
            bool b_proc_alarm_action;

            try
            {
                /***** Start Check Transaction Confirm Message *****/
                b_proc_alarm_action = false;
                if (MPCR.CheckTranAlarmRelation(this,
                                                ' ',
                                                "",
                                                0,
                                                "",
                                                "",
                                                "",
                                                MPCF.Trim(cdvEventID.Text),
                                                MPCF.Trim(lisResourceList.Items[iRowIndex].SubItems[1].Text),
                                                ref b_proc_alarm_action) == false)
                {
                    return false;
                }

                if (b_proc_alarm_action == true)
                {
                    if (MPCF.ShowMsgBox(MPCF.GetMessage(269), MessageBoxButtons.OKCancel, 2) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return false;
                    }

                    return true;
                }
                /***** End Check Transaction Confirm Message *****/

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", lisResourceList.Items[iRowIndex].SubItems[1].Text);
                in_node.AddString("EVENT_ID", cdvEventID.Text);

                if (MPCF.Trim(cdvPrimaryChange.Text) == "")
                {
                    in_node.AddString("CHG_PRI_STS", lisResourceList.Items[iRowIndex].SubItems[5].Text);
                }
                else
                {
                    if (cdvPrimaryChange.Tag == null)
                    {
                        in_node.AddString("CHG_PRI_STS", cdvPrimaryChange.Text);
                    }
                    else if (cdvPrimaryChange.Tag.ToString() == "+")
                    {
                        in_node.AddString("CHG_PRI_STS", Convert.ToString(MPCF.ToDbl(lisResourceList.Items[iRowIndex].SubItems[5].Text) + MPCF.ToDbl(cdvPrimaryChange.Text)));
                    }
                    else if (cdvPrimaryChange.Tag.ToString() == "-")
                    {
                        in_node.AddString("CHG_PRI_STS", Convert.ToString(MPCF.ToDbl(lisResourceList.Items[iRowIndex].SubItems[5].Text) - MPCF.ToDbl(cdvPrimaryChange.Text)));
                    }
                    else
                    {
                        in_node.AddString("CHG_PRI_STS", cdvPrimaryChange.Text);
                    }
                }

                if (MPCF.Trim(cdvChangeStatus1.Text) == "")
                {
                    in_node.AddString("CHG_STS_1", lisResourceList.Items[iRowIndex].SubItems[16].Text);
                }
                else
                {
                    if (cdvChangeStatus1.Tag == null)
                    {
                        in_node.AddString("CHG_STS_1", cdvChangeStatus1.Text);
                    }
                    else if (cdvChangeStatus1.Tag.ToString() == "+")
                    {
                        in_node.AddString("CHG_STS_1", Convert.ToString(MPCF.ToDbl(lisResourceList.Items[iRowIndex].SubItems[16].Text) + MPCF.ToDbl(cdvChangeStatus1.Text)));
                    }
                    else if (cdvChangeStatus1.Tag.ToString() == "-")
                    {
                        in_node.AddString("CHG_STS_1", Convert.ToString(MPCF.ToDbl(lisResourceList.Items[iRowIndex].SubItems[16].Text) - MPCF.ToDbl(cdvChangeStatus1.Text)));
                    }
                    else
                    {
                        in_node.AddString("CHG_STS_1", cdvChangeStatus1.Text);
                    }
                }

                if (MPCF.Trim(cdvChangeStatus2.Text) == "")
                {
                    in_node.AddString("CHG_STS_2", lisResourceList.Items[iRowIndex].SubItems[17].Text);
                }
                else
                {
                    if (cdvChangeStatus2.Tag == null)
                    {
                        in_node.AddString("CHG_STS_2", cdvChangeStatus2.Text);
                    }
                    else if (cdvChangeStatus2.Tag.ToString() == "+")
                    {
                        in_node.AddString("CHG_STS_2", Convert.ToString(MPCF.ToDbl(lisResourceList.Items[iRowIndex].SubItems[17].Text) + MPCF.ToDbl(cdvChangeStatus2.Text)));
                    }
                    else if (cdvChangeStatus2.Tag.ToString() == "-")
                    {
                        in_node.AddString("CHG_STS_2", Convert.ToString(MPCF.ToDbl(lisResourceList.Items[iRowIndex].SubItems[17].Text) - MPCF.ToDbl(cdvChangeStatus2.Text)));
                    }
                    else
                    {
                        in_node.AddString("CHG_STS_2", cdvChangeStatus2.Text);
                    }
                }

                if (MPCF.Trim(cdvChangeStatus3.Text) == "")
                {
                    in_node.AddString("CHG_STS_3", lisResourceList.Items[iRowIndex].SubItems[18].Text);
                }
                else
                {
                    if (cdvChangeStatus3.Tag == null)
                    {
                        in_node.AddString("CHG_STS_3", cdvChangeStatus3.Text);
                    }
                    else if (cdvChangeStatus3.Tag.ToString() == "+")
                    {
                        in_node.AddString("CHG_STS_3", Convert.ToString(MPCF.ToDbl(lisResourceList.Items[iRowIndex].SubItems[18].Text) + MPCF.ToDbl(cdvChangeStatus3.Text)));
                    }
                    else if (cdvChangeStatus3.Tag.ToString() == "-")
                    {
                        in_node.AddString("CHG_STS_3", Convert.ToString(MPCF.ToDbl(lisResourceList.Items[iRowIndex].SubItems[18].Text) - MPCF.ToDbl(cdvChangeStatus3.Text)));
                    }
                    else
                    {
                        in_node.AddString("CHG_STS_3", cdvChangeStatus3.Text);
                    }
                }

                if (MPCF.Trim(cdvChangeStatus4.Text) == "")
                {
                    in_node.AddString("CHG_STS_4", lisResourceList.Items[iRowIndex].SubItems[19].Text);
                }
                else
                {
                    if (cdvChangeStatus4.Tag == null)
                    {
                        in_node.AddString("CHG_STS_4", cdvChangeStatus4.Text);
                    }
                    else if (cdvChangeStatus4.Tag.ToString() == "+")
                    {
                        in_node.AddString("CHG_STS_4", Convert.ToString(MPCF.ToDbl(lisResourceList.Items[iRowIndex].SubItems[19].Text) + MPCF.ToDbl(cdvChangeStatus4.Text)));
                    }
                    else if (cdvChangeStatus4.Tag.ToString() == "-")
                    {
                        in_node.AddString("CHG_STS_4", Convert.ToString(MPCF.ToDbl(lisResourceList.Items[iRowIndex].SubItems[19].Text) - MPCF.ToDbl(cdvChangeStatus4.Text)));
                    }
                    else
                    {
                        in_node.AddString("CHG_STS_4", cdvChangeStatus4.Text);
                    }
                }

                if (MPCF.Trim(cdvChangeStatus5.Text) == "")
                {
                    in_node.AddString("CHG_STS_5", lisResourceList.Items[iRowIndex].SubItems[20].Text);
                }
                else
                {
                    if (cdvChangeStatus5.Tag == null)
                    {
                        in_node.AddString("CHG_STS_5", cdvChangeStatus5.Text);
                    }
                    else if (cdvChangeStatus5.Tag.ToString() == "+")
                    {
                        in_node.AddString("CHG_STS_5", Convert.ToString(MPCF.ToDbl(lisResourceList.Items[iRowIndex].SubItems[20].Text) + MPCF.ToDbl(cdvChangeStatus5.Text)));
                    }
                    else if (cdvChangeStatus5.Tag.ToString() == "-")
                    {
                        in_node.AddString("CHG_STS_5", Convert.ToString(MPCF.ToDbl(lisResourceList.Items[iRowIndex].SubItems[20].Text) - MPCF.ToDbl(cdvChangeStatus5.Text)));
                    }
                    else
                    {
                        in_node.AddString("CHG_STS_5", cdvChangeStatus5.Text);
                    }
                }

                if (MPCF.Trim(cdvChangeStatus6.Text) == "")
                {
                    in_node.AddString("CHG_STS_6", lisResourceList.Items[iRowIndex].SubItems[21].Text);
                }
                else
                {
                    if (cdvChangeStatus6.Tag == null)
                    {
                        in_node.AddString("CHG_STS_6", cdvChangeStatus6.Text);
                    }
                    else if (cdvChangeStatus6.Tag.ToString() == "+")
                    {
                        in_node.AddString("CHG_STS_6", Convert.ToString(MPCF.ToDbl(lisResourceList.Items[iRowIndex].SubItems[21].Text) + MPCF.ToDbl(cdvChangeStatus6.Text)));
                    }
                    else if (cdvChangeStatus6.Tag.ToString() == "-")
                    {
                        in_node.AddString("CHG_STS_6", Convert.ToString(MPCF.ToDbl(lisResourceList.Items[iRowIndex].SubItems[21].Text) - MPCF.ToDbl(cdvChangeStatus6.Text)));
                    }
                    else
                    {
                        in_node.AddString("CHG_STS_6", cdvChangeStatus6.Text);
                    }
                }

                if (MPCF.Trim(cdvChangeStatus7.Text) == "")
                {
                    in_node.AddString("CHG_STS_7", lisResourceList.Items[iRowIndex].SubItems[22].Text);
                }
                else
                {
                    if (cdvChangeStatus7.Tag == null)
                    {
                        in_node.AddString("CHG_STS_7", cdvChangeStatus7.Text);
                    }
                    else if (cdvChangeStatus7.Tag.ToString() == "+")
                    {
                        in_node.AddString("CHG_STS_7", Convert.ToString(MPCF.ToDbl(lisResourceList.Items[iRowIndex].SubItems[22].Text) + MPCF.ToDbl(cdvChangeStatus7.Text)));
                    }
                    else if (cdvChangeStatus7.Tag.ToString() == "-")
                    {
                        in_node.AddString("CHG_STS_7", Convert.ToString(MPCF.ToDbl(lisResourceList.Items[iRowIndex].SubItems[22].Text) - MPCF.ToDbl(cdvChangeStatus7.Text)));
                    }
                    else
                    {
                        in_node.AddString("CHG_STS_7", cdvChangeStatus7.Text);
                    }
                }

                if (MPCF.Trim(cdvChangeStatus8.Text) == "")
                {
                    in_node.AddString("CHG_STS_8", lisResourceList.Items[iRowIndex].SubItems[23].Text);
                }
                else
                {
                    if (cdvChangeStatus8.Tag == null)
                    {
                        in_node.AddString("CHG_STS_8", cdvChangeStatus8.Text);
                    }
                    else if (cdvChangeStatus8.Tag.ToString() == "+")
                    {
                        in_node.AddString("CHG_STS_8", Convert.ToString(MPCF.ToDbl(lisResourceList.Items[iRowIndex].SubItems[23].Text) + MPCF.ToDbl(cdvChangeStatus8.Text)));
                    }
                    else if (cdvChangeStatus8.Tag.ToString() == "-")
                    {
                        in_node.AddString("CHG_STS_8", Convert.ToString(MPCF.ToDbl(lisResourceList.Items[iRowIndex].SubItems[23].Text) - MPCF.ToDbl(cdvChangeStatus8.Text)));
                    }
                    else
                    {
                        in_node.AddString("CHG_STS_8", cdvChangeStatus8.Text);
                    }
                }

                if (MPCF.Trim(cdvChangeStatus9.Text) == "")
                {
                    in_node.AddString("CHG_STS_9", lisResourceList.Items[iRowIndex].SubItems[24].Text);
                }
                else
                {
                    if (cdvChangeStatus9.Tag == null)
                    {
                        in_node.AddString("CHG_STS_9", cdvChangeStatus9.Text);
                    }
                    else if (cdvChangeStatus9.Tag.ToString() == "+")
                    {
                        in_node.AddString("CHG_STS_9", Convert.ToString(MPCF.ToDbl(lisResourceList.Items[iRowIndex].SubItems[24].Text) + MPCF.ToDbl(cdvChangeStatus9.Text)));
                    }
                    else if (cdvChangeStatus9.Tag.ToString() == "-")
                    {
                        in_node.AddString("CHG_STS_9", Convert.ToString(MPCF.ToDbl(lisResourceList.Items[iRowIndex].SubItems[24].Text) - MPCF.ToDbl(cdvChangeStatus9.Text)));
                    }
                    else
                    {
                        in_node.AddString("CHG_STS_9", cdvChangeStatus9.Text);
                    }
                }

                if (MPCF.Trim(cdvChangeStatus10.Text) == "")
                {
                    in_node.AddString("CHG_STS_10", lisResourceList.Items[iRowIndex].SubItems[25].Text);
                }
                else
                {
                    if (cdvChangeStatus10.Tag == null)
                    {
                        in_node.AddString("CHG_STS_10", cdvChangeStatus10.Text);
                    }
                    else if (cdvChangeStatus10.Tag.ToString() == "+")
                    {
                        in_node.AddString("CHG_STS_10", Convert.ToString(MPCF.ToDbl(lisResourceList.Items[iRowIndex].SubItems[25].Text) + MPCF.ToDbl(cdvChangeStatus10.Text)));
                    }
                    else if (cdvChangeStatus10.Tag.ToString() == "-")
                    {
                        in_node.AddString("CHG_STS_10", Convert.ToString(MPCF.ToDbl(lisResourceList.Items[iRowIndex].SubItems[25].Text) - MPCF.ToDbl(cdvChangeStatus10.Text)));
                    }
                    else
                    {
                        in_node.AddString("CHG_STS_10", cdvChangeStatus10.Text);
                    }
                }

                in_node.AddString("TRAN_CMF_1", cdvCMF1.Text);
                in_node.AddString("TRAN_CMF_2", cdvCMF2.Text);
                in_node.AddString("TRAN_CMF_3", cdvCMF3.Text);
                in_node.AddString("TRAN_CMF_4", cdvCMF4.Text);
                in_node.AddString("TRAN_CMF_5", cdvCMF5.Text);
                in_node.AddString("TRAN_CMF_6", cdvCMF6.Text);
                in_node.AddString("TRAN_CMF_7", cdvCMF7.Text);
                in_node.AddString("TRAN_CMF_8", cdvCMF8.Text);
                in_node.AddString("TRAN_CMF_9", cdvCMF9.Text);
                in_node.AddString("TRAN_CMF_10", cdvCMF10.Text);
                in_node.AddString("TRAN_CMF_11", cdvCMF11.Text);
                in_node.AddString("TRAN_CMF_12", cdvCMF12.Text);
                in_node.AddString("TRAN_CMF_13", cdvCMF13.Text);
                in_node.AddString("TRAN_CMF_14", cdvCMF14.Text);
                in_node.AddString("TRAN_CMF_15", cdvCMF15.Text);
                in_node.AddString("TRAN_CMF_16", cdvCMF16.Text);
                in_node.AddString("TRAN_CMF_17", cdvCMF17.Text);
                in_node.AddString("TRAN_CMF_18", cdvCMF18.Text);
                in_node.AddString("TRAN_CMF_19", cdvCMF19.Text);
                in_node.AddString("TRAN_CMF_20", cdvCMF20.Text);

                in_node.AddString("TRAN_COMMENT", txtComment.Text);
                in_node.AddInt("CONFIRM_CHAR_SEQ", 0);
                in_node.AddInt("CONFIRM_UNIT_SEQ", 0);
                in_node.AddInt("CONFIRM_VALUE_SEQ", 0);
               
                if (MPCR.CallService("RAS", "RAS_Resource_Event", in_node, ref out_node) == false)
                {
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

        private bool View_Event()
        {


            TRSNode in_node = new TRSNode("VIEW_EVENT_IN");
            TRSNode out_node = new TRSNode("VIEW_EVENT_OUT");
            DateTime ThisMoment = DateTime.Now;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("EVENT_ID", cdvEventID.Text);

            if (MPCR.CallService("RAS", "RAS_View_Event", in_node, ref out_node) == false)
            {
                return false;
            }

            if (MPCF.Trim(out_node.GetString("COL_SET_ID")) != "")
            {
#if _EDC
                MPCF.ShowMsgBox(MPCF.GetMessage(273));
                return false;
#endif
            }

            txtChangeUpDown.Visible = true;
            if (out_node.GetChar("CHG_UP_DOWN_FLAG") == CHANGE)
            {
                if (MPCF.Trim(out_node.GetChar("CHG_UP_DOWN")) == "U")
                {
                    txtChangeUpDown.Text = "UP";
                }
                else if (MPCF.Trim(out_node.GetChar("CHG_UP_DOWN")) == "D")
                {
                    txtChangeUpDown.Text = "DOWN";
                }
            }
            else
            {
                txtChangeUpDown.Text = "";
            }

            if (out_node.GetChar("CHG_PRI_STS_FLAG") == OVERRIDE)
            {
                if (MPCF.Trim(out_node.GetString("TBL_PRI_STS")) != "")
                {
                    cdvPrimaryChange.VisibleButton = true;
                    cdvPrimaryChange.Tag = out_node.GetString("TBL_PRI_STS");
                }
                else
                {
                    cdvPrimaryChange.VisibleButton = false;
                }
                cdvPrimaryChange.Visible = true;
                cdvPrimaryChange.Text = out_node.GetString("CHG_PRI_STS");
                cdvPrimaryChange.ReadOnly = false;
                cdvPrimaryChange.BackColor = SystemColors.Window;
            }
            else
            {
                cdvPrimaryChange.Visible = true;
                cdvPrimaryChange.VisibleButton = false;
                cdvPrimaryChange.ReadOnly = true;
                cdvPrimaryChange.BackColor = SystemColors.Control;
                if (out_node.GetChar("CHG_PRI_STS_FLAG") == CHANGE)
                {
                    cdvPrimaryChange.Text = out_node.GetString("CHG_PRI_STS");
                }
                else if (out_node.GetChar("CHG_PRI_STS_FLAG") == INCREASE)
                {
                    cdvPrimaryChange.Text = "+" + out_node.GetString("CHG_PRI_STS");
                    cdvPrimaryChange.Tag = "+";
                }
                else if (out_node.GetChar("CHG_PRI_STS_FLAG") == DECREASE)
                {
                    cdvPrimaryChange.Text = "-" + out_node.GetString("CHG_PRI_STS");
                    cdvPrimaryChange.Tag = "-";
                }
                else if (out_node.GetChar("CHG_PRI_STS_FLAG") == NOTCHANGE)
                {

                }
                else if (out_node.GetChar("CHG_PRI_STS_FLAG") == TIME)
                {
                    cdvPrimaryChange.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                }
            }

            if (out_node.GetChar("CHG_FLAG_1") == OVERRIDE)
            {
                if (MPCF.Trim(out_node.GetString("TBL_1")) != "")
                {
                    cdvChangeStatus1.VisibleButton = true;
                    cdvChangeStatus1.Tag = out_node.GetString("TBL_1");
                }
                else
                {
                    cdvChangeStatus1.VisibleButton = false;
                }
                cdvChangeStatus1.Visible = true;
                cdvChangeStatus1.Text = out_node.GetString("CHG_STS_1");
                cdvChangeStatus1.ReadOnly = false;
                cdvChangeStatus1.BackColor = SystemColors.Window;
            }
            else
            {
                cdvChangeStatus1.Visible = true;
                cdvChangeStatus1.VisibleButton = false;
                cdvChangeStatus1.ReadOnly = true;
                cdvChangeStatus1.BackColor = SystemColors.Control;
                if (out_node.GetChar("CHG_FLAG_1") == CHANGE)
                {
                    cdvChangeStatus1.Text = out_node.GetString("CHG_STS_1");
                }
                else if (out_node.GetChar("CHG_FLAG_1") == INCREASE)
                {
                    cdvChangeStatus1.Text = "+" + out_node.GetString("CHG_STS_1");
                    cdvChangeStatus1.Tag = "+";
                }
                else if (out_node.GetChar("CHG_FLAG_1") == DECREASE)
                {
                    cdvChangeStatus1.Text = "-" + out_node.GetString("CHG_STS_1");
                    cdvChangeStatus1.Tag = "-";
                }
                else if (out_node.GetChar("CHG_FLAG_1") == NOTCHANGE)
                {

                }
                else if (out_node.GetChar("CHG_FLAG_1") == TIME)
                {
                    cdvChangeStatus1.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                }
            }

            if (out_node.GetChar("CHG_FLAG_2") == OVERRIDE)
            {
                if (MPCF.Trim(out_node.GetString("TBL_2")) != "")
                {
                    cdvChangeStatus2.VisibleButton = true;
                    cdvChangeStatus2.Tag = out_node.GetString("TBL_2");
                }
                else
                {
                    cdvChangeStatus2.VisibleButton = false;
                }
                cdvChangeStatus2.Visible = true;
                cdvChangeStatus2.Text = out_node.GetString("CHG_STS_2");
                cdvChangeStatus2.ReadOnly = false;
                cdvChangeStatus2.BackColor = SystemColors.Window;
            }
            else
            {
                cdvChangeStatus2.Visible = true;
                cdvChangeStatus2.VisibleButton = false;
                cdvChangeStatus2.ReadOnly = true;
                cdvChangeStatus2.BackColor = SystemColors.Control;
                if (out_node.GetChar("CHG_FLAG_2") == CHANGE)
                {
                    cdvChangeStatus2.Text = out_node.GetString("CHG_STS_2");
                }
                else if (out_node.GetChar("CHG_FLAG_2") == INCREASE)
                {
                    cdvChangeStatus2.Text = "+" + out_node.GetString("CHG_STS_2");
                    cdvChangeStatus2.Tag = "+";
                }
                else if (out_node.GetChar("CHG_FLAG_2") == DECREASE)
                {
                    cdvChangeStatus2.Text = "-" + out_node.GetString("CHG_STS_2");
                    cdvChangeStatus2.Tag = "-";
                }
                else if (out_node.GetChar("CHG_FLAG_2") == NOTCHANGE)
                {

                }
                else if (out_node.GetChar("CHG_FLAG_2") == TIME)
                {
                    cdvChangeStatus2.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                }
            }

            if (out_node.GetChar("CHG_FLAG_3") == OVERRIDE)
            {
                if (MPCF.Trim(out_node.GetString("TBL_3")) != "")
                {
                    cdvChangeStatus3.VisibleButton = true;
                    cdvChangeStatus3.Tag = out_node.GetString("TBL_3");
                }
                else
                {
                    cdvChangeStatus3.VisibleButton = false;
                }
                cdvChangeStatus3.Visible = true;
                cdvChangeStatus3.Text = out_node.GetString("CHG_STS_3");
                cdvChangeStatus3.ReadOnly = false;
                cdvChangeStatus3.BackColor = SystemColors.Window;
            }
            else
            {
                cdvChangeStatus3.Visible = true;
                cdvChangeStatus3.VisibleButton = false;
                cdvChangeStatus3.ReadOnly = true;
                cdvChangeStatus3.BackColor = SystemColors.Control;
                if (out_node.GetChar("CHG_FLAG_3") == CHANGE)
                {
                    cdvChangeStatus3.Text = out_node.GetString("CHG_STS_3");
                }
                else if (out_node.GetChar("CHG_FLAG_3") == INCREASE)
                {
                    cdvChangeStatus3.Text = "+" + out_node.GetString("CHG_STS_3");
                    cdvChangeStatus3.Tag = "+";
                }
                else if (out_node.GetChar("CHG_FLAG_3") == DECREASE)
                {
                    cdvChangeStatus3.Text = "-" + out_node.GetString("CHG_STS_3");
                    cdvChangeStatus3.Tag = "-";
                }
                else if (out_node.GetChar("CHG_FLAG_3") == NOTCHANGE)
                {

                }
                else if (out_node.GetChar("CHG_FLAG_3") == TIME)
                {
                    cdvChangeStatus3.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                }
            }

            if (out_node.GetChar("CHG_FLAG_4") == OVERRIDE)
            {
                if (MPCF.Trim(out_node.GetString("TBL_4")) != "")
                {
                    cdvChangeStatus4.VisibleButton = true;
                    cdvChangeStatus4.Tag = out_node.GetString("TBL_4");
                }
                else
                {
                    cdvChangeStatus4.VisibleButton = false;
                }
                cdvChangeStatus4.Visible = true;
                cdvChangeStatus4.Text = out_node.GetString("CHG_STS_4");
                cdvChangeStatus4.ReadOnly = false;
                cdvChangeStatus4.BackColor = SystemColors.Window;
            }
            else
            {
                cdvChangeStatus4.Visible = true;
                cdvChangeStatus4.VisibleButton = false;
                cdvChangeStatus4.ReadOnly = true;
                cdvChangeStatus4.BackColor = SystemColors.Control;
                if (out_node.GetChar("CHG_FLAG_4") == CHANGE)
                {
                    cdvChangeStatus4.Text = out_node.GetString("CHG_STS_4");
                }
                else if (out_node.GetChar("CHG_FLAG_4") == INCREASE)
                {
                    cdvChangeStatus4.Text = "+" + out_node.GetString("CHG_STS_4");
                    cdvChangeStatus4.Tag = "+";
                }
                else if (out_node.GetChar("CHG_FLAG_4") == DECREASE)
                {
                    cdvChangeStatus4.Text = "-" + out_node.GetString("CHG_STS_4");
                    cdvChangeStatus4.Tag = "-";
                }
                else if (out_node.GetChar("CHG_FLAG_4") == NOTCHANGE)
                {

                }
                else if (out_node.GetChar("CHG_FLAG_4") == TIME)
                {
                    MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                }
            }

            if (out_node.GetChar("CHG_FLAG_5") == OVERRIDE)
            {
                if (MPCF.Trim(out_node.GetString("TBL_5")) != "")
                {
                    cdvChangeStatus5.VisibleButton = true;
                    cdvChangeStatus5.Tag = out_node.GetString("TBL_5");
                }
                else
                {
                    cdvChangeStatus5.VisibleButton = false;
                }
                cdvChangeStatus5.Visible = true;
                cdvChangeStatus5.Text = out_node.GetString("CHG_STS_5");
                cdvChangeStatus5.ReadOnly = false;
                cdvChangeStatus5.BackColor = SystemColors.Window;
            }
            else
            {
                cdvChangeStatus5.Visible = true;
                cdvChangeStatus5.VisibleButton = false;
                cdvChangeStatus5.ReadOnly = true;
                cdvChangeStatus5.BackColor = SystemColors.Control;
                if (out_node.GetChar("CHG_FLAG_5") == CHANGE)
                {
                    cdvChangeStatus5.Text = out_node.GetString("CHG_STS_5");
                }
                else if (out_node.GetChar("CHG_FLAG_5") == INCREASE)
                {
                    cdvChangeStatus5.Text = "+" + out_node.GetString("CHG_STS_5");
                    cdvChangeStatus5.Tag = "+";
                }
                else if (out_node.GetChar("CHG_FLAG_5") == DECREASE)
                {
                    cdvChangeStatus5.Text = "-" + out_node.GetString("CHG_STS_5");
                    cdvChangeStatus5.Tag = "-";
                }
                else if (out_node.GetChar("CHG_FLAG_5") == NOTCHANGE)
                {

                }
                else if (out_node.GetChar("CHG_FLAG_5") == TIME)
                {
                    cdvChangeStatus5.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                }
            }

            if (out_node.GetChar("CHG_FLAG_6") == OVERRIDE)
            {
                if (MPCF.Trim(out_node.GetString("TBL_6")) != "")
                {
                    cdvChangeStatus6.VisibleButton = true;
                    cdvChangeStatus6.Tag = out_node.GetString("TBL_6");
                }
                else
                {
                    cdvChangeStatus6.VisibleButton = false;
                }
                cdvChangeStatus6.Visible = true;
                cdvChangeStatus6.Text = out_node.GetString("CHG_STS_6");
                cdvChangeStatus6.ReadOnly = false;
                cdvChangeStatus6.BackColor = SystemColors.Window;
            }
            else
            {
                cdvChangeStatus6.Visible = true;
                cdvChangeStatus6.VisibleButton = false;
                cdvChangeStatus6.ReadOnly = true;
                cdvChangeStatus6.BackColor = SystemColors.Control;
                if (out_node.GetChar("CHG_FLAG_6") == CHANGE)
                {
                    cdvChangeStatus6.Text = out_node.GetString("CHG_STS_6");
                }
                else if (out_node.GetChar("CHG_FLAG_6") == INCREASE)
                {
                    cdvChangeStatus6.Text = "+" + out_node.GetString("CHG_STS_6");
                    cdvChangeStatus6.Tag = "+";
                }
                else if (out_node.GetChar("CHG_FLAG_6") == DECREASE)
                {
                    cdvChangeStatus6.Text = "-" + out_node.GetString("CHG_STS_6");
                    cdvChangeStatus6.Tag = "-";
                }
                else if (out_node.GetChar("CHG_FLAG_6") == NOTCHANGE)
                {

                }
                else if (out_node.GetChar("CHG_FLAG_6") == TIME)
                {
                    cdvChangeStatus6.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                }
            }

            if (out_node.GetChar("CHG_FLAG_7") == OVERRIDE)
            {
                if (MPCF.Trim(out_node.GetString("TBL_7")) != "")
                {
                    cdvChangeStatus7.VisibleButton = true;
                    cdvChangeStatus7.Tag = out_node.GetString("TBL_7");
                }
                else
                {
                    cdvChangeStatus7.VisibleButton = false;
                }
                cdvChangeStatus7.Visible = true;
                cdvChangeStatus7.Text = out_node.GetString("CHG_STS_7");
                cdvChangeStatus7.ReadOnly = false;
                cdvChangeStatus7.BackColor = SystemColors.Window;
            }
            else
            {
                cdvChangeStatus7.Visible = true;
                cdvChangeStatus7.VisibleButton = false;
                cdvChangeStatus7.ReadOnly = true;
                cdvChangeStatus7.BackColor = SystemColors.Control;
                if (out_node.GetChar("CHG_FLAG_7") == CHANGE)
                {
                    cdvChangeStatus7.Text = out_node.GetString("CHG_STS_7");
                }
                else if (out_node.GetChar("CHG_FLAG_7") == INCREASE)
                {
                    cdvChangeStatus7.Text = "+" + out_node.GetString("CHG_STS_7");
                    cdvChangeStatus7.Tag = "+";
                }
                else if (out_node.GetChar("CHG_FLAG_7") == DECREASE)
                {
                    cdvChangeStatus7.Text = "-" + out_node.GetString("CHG_STS_7");
                    cdvChangeStatus7.Tag = "-";
                }
                else if (out_node.GetChar("CHG_FLAG_7") == NOTCHANGE)
                {

                }
                else if (out_node.GetChar("CHG_FLAG_7") == TIME)
                {
                    cdvChangeStatus7.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                }
            }

            if (out_node.GetChar("CHG_FLAG_8") == OVERRIDE)
            {
                if (MPCF.Trim(out_node.GetString("TBL_8")) != "")
                {
                    cdvChangeStatus8.VisibleButton = true;
                    cdvChangeStatus8.Tag = out_node.GetString("TBL_8");
                }
                else
                {
                    cdvChangeStatus8.VisibleButton = false;
                }
                cdvChangeStatus8.Visible = true;
                cdvChangeStatus8.Text = out_node.GetString("CHG_STS_8");
                cdvChangeStatus8.ReadOnly = false;
                cdvChangeStatus8.BackColor = SystemColors.Window;
            }
            else
            {
                cdvChangeStatus8.Visible = true;
                cdvChangeStatus8.VisibleButton = false;
                cdvChangeStatus8.ReadOnly = true;
                cdvChangeStatus8.BackColor = SystemColors.Control;
                if (out_node.GetChar("CHG_FLAG_8") == CHANGE)
                {
                    cdvChangeStatus8.Text = out_node.GetString("CHG_STS_8");
                }
                else if (out_node.GetChar("CHG_FLAG_8") == INCREASE)
                {
                    cdvChangeStatus8.Text = "+" + out_node.GetString("CHG_STS_8");
                    cdvChangeStatus8.Tag = "+";
                }
                else if (out_node.GetChar("CHG_FLAG_8") == DECREASE)
                {
                    cdvChangeStatus8.Text = "-" + out_node.GetString("CHG_STS_8");
                    cdvChangeStatus8.Tag = "-";
                }
                else if (out_node.GetChar("CHG_FLAG_8") == NOTCHANGE)
                {

                }
                else if (out_node.GetChar("CHG_FLAG_8") == TIME)
                {
                    cdvChangeStatus8.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                }
            }

            if (out_node.GetChar("CHG_FLAG_9") == OVERRIDE)
            {
                if (MPCF.Trim(out_node.GetString("TBL_9")) != "")
                {
                    cdvChangeStatus9.VisibleButton = true;
                    cdvChangeStatus9.Tag = out_node.GetString("TBL_9");
                }
                else
                {
                    cdvChangeStatus9.VisibleButton = false;
                }
                cdvChangeStatus9.Visible = true;
                cdvChangeStatus9.Text = out_node.GetString("CHG_STS_9");
                cdvChangeStatus9.ReadOnly = false;
                cdvChangeStatus9.BackColor = SystemColors.Window;
            }
            else
            {
                cdvChangeStatus9.Visible = true;
                cdvChangeStatus9.VisibleButton = false;
                cdvChangeStatus9.ReadOnly = true;
                cdvChangeStatus9.BackColor = SystemColors.Control;
                if (out_node.GetChar("CHG_FLAG_9") == CHANGE)
                {
                    cdvChangeStatus9.Text = out_node.GetString("CHG_STS_9");
                }
                else if (out_node.GetChar("CHG_FLAG_9") == INCREASE)
                {
                    cdvChangeStatus9.Text = "+" + out_node.GetString("CHG_STS_9");
                    cdvChangeStatus9.Tag = "+";
                }
                else if (out_node.GetChar("CHG_FLAG_9") == DECREASE)
                {
                    cdvChangeStatus9.Text = "-" + out_node.GetString("CHG_STS_9");
                    cdvChangeStatus9.Tag = "-";
                }
                else if (out_node.GetChar("CHG_FLAG_9") == NOTCHANGE)
                {

                }
                else if (out_node.GetChar("CHG_FLAG_9") == TIME)
                {
                    cdvChangeStatus9.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                }
            }

            if (out_node.GetChar("CHG_FLAG_10") == OVERRIDE)
            {
                if (MPCF.Trim(out_node.GetString("TBL_10")) != "")
                {
                    cdvChangeStatus10.VisibleButton = true;
                    cdvChangeStatus10.Tag = out_node.GetString("TBL_10");
                }
                else
                {
                    cdvChangeStatus10.VisibleButton = false;
                }
                cdvChangeStatus10.Visible = true;
                cdvChangeStatus10.Text = out_node.GetString("CHG_STS_10");
                cdvChangeStatus10.ReadOnly = false;
                cdvChangeStatus10.BackColor = SystemColors.Window;
            }
            else
            {
                cdvChangeStatus10.Visible = true;
                cdvChangeStatus10.VisibleButton = false;
                cdvChangeStatus10.ReadOnly = true;
                cdvChangeStatus10.BackColor = SystemColors.Control;
                if (out_node.GetChar("CHG_FLAG_10") == CHANGE)
                {
                    cdvChangeStatus10.Text = out_node.GetString("CHG_STS_10");
                }
                else if (out_node.GetChar("CHG_FLAG_10") == INCREASE)
                {
                    cdvChangeStatus10.Text = "+" + out_node.GetString("CHG_STS_10");
                    cdvChangeStatus10.Tag = "+";
                }
                else if (out_node.GetChar("CHG_FLAG_10") == DECREASE)
                {
                    cdvChangeStatus10.Text = "-" + out_node.GetString("CHG_STS_10");
                    cdvChangeStatus10.Tag = "-";
                }
                else if (out_node.GetChar("CHG_FLAG_10") == NOTCHANGE)
                {

                }
                else if (out_node.GetChar("CHG_FLAG_10") == TIME)
                {
                    cdvChangeStatus10.Text = MPCF.ToStandardTime(ThisMoment, MPGC.MP_CONVERT_DATETIME_FORMAT);
                }
            }

            return true;

        }


        private void ChangeStatusClear()
        {
            txtChangeUpDown.Text = "";
            cdvPrimaryChange.Text = "";
            cdvChangeStatus1.Text = "";
            cdvChangeStatus2.Text = "";
            cdvChangeStatus3.Text = "";
            cdvChangeStatus4.Text = "";
            cdvChangeStatus5.Text = "";
            cdvChangeStatus6.Text = "";
            cdvChangeStatus7.Text = "";
            cdvChangeStatus8.Text = "";
            cdvChangeStatus9.Text = "";
            cdvChangeStatus10.Text = "";
        }

        private void ChangeFieldVisible()
        {
            txtChangeUpDown.Visible = false;
            cdvPrimaryChange.Visible = false;
            cdvChangeStatus1.Visible = false;
            cdvChangeStatus2.Visible = false;
            cdvChangeStatus3.Visible = false;
            cdvChangeStatus4.Visible = false;
            cdvChangeStatus5.Visible = false;
            cdvChangeStatus6.Visible = false;
            cdvChangeStatus7.Visible = false;
            cdvChangeStatus8.Visible = false;
            cdvChangeStatus9.Visible = false;
            cdvChangeStatus10.Visible = false;
        }

        private void ChangeFieldReadOnly()
        {
            //txtChangeUpDown.Visible = false;
            cdvPrimaryChange.ReadOnly = true;
            cdvPrimaryChange.BackColor = SystemColors.Control;
            cdvPrimaryChange.VisibleButton = false;
            cdvChangeStatus1.ReadOnly = true;
            cdvChangeStatus1.BackColor = SystemColors.Control;
            cdvChangeStatus1.VisibleButton = false;
            cdvChangeStatus2.ReadOnly = true;
            cdvChangeStatus2.BackColor = SystemColors.Control;
            cdvChangeStatus2.VisibleButton = false;
            cdvChangeStatus3.ReadOnly = true;
            cdvChangeStatus3.BackColor = SystemColors.Control;
            cdvChangeStatus3.VisibleButton = false;
            cdvChangeStatus4.ReadOnly = true;
            cdvChangeStatus4.BackColor = SystemColors.Control;
            cdvChangeStatus4.VisibleButton = false;
            cdvChangeStatus5.ReadOnly = true;
            cdvChangeStatus5.BackColor = SystemColors.Control;
            cdvChangeStatus5.VisibleButton = false;
            cdvChangeStatus6.ReadOnly = true;
            cdvChangeStatus6.BackColor = SystemColors.Control;
            cdvChangeStatus6.VisibleButton = false;
            cdvChangeStatus7.ReadOnly = true;
            cdvChangeStatus7.BackColor = SystemColors.Control;
            cdvChangeStatus7.VisibleButton = false;
            cdvChangeStatus8.ReadOnly = true;
            cdvChangeStatus8.BackColor = SystemColors.Control;
            cdvChangeStatus8.VisibleButton = false;
            cdvChangeStatus9.ReadOnly = true;
            cdvChangeStatus9.BackColor = SystemColors.Control;
            cdvChangeStatus9.VisibleButton = false;
            cdvChangeStatus10.ReadOnly = true;
            cdvChangeStatus10.BackColor = SystemColors.Control;
            cdvChangeStatus10.VisibleButton = false;
        }

        private void InitCodeView()
        {
            cdvPrimaryChange.DisplaySubItemIndex = 0;
            cdvChangeStatus1.DisplaySubItemIndex = 0;
            cdvChangeStatus2.DisplaySubItemIndex = 0;
            cdvChangeStatus3.DisplaySubItemIndex = 0;
            cdvChangeStatus4.DisplaySubItemIndex = 0;
            cdvChangeStatus5.DisplaySubItemIndex = 0;
            cdvChangeStatus6.DisplaySubItemIndex = 0;
            cdvChangeStatus7.DisplaySubItemIndex = 0;
            cdvChangeStatus8.DisplaySubItemIndex = 0;
            cdvChangeStatus9.DisplaySubItemIndex = 0;
            cdvChangeStatus10.DisplaySubItemIndex = 0;

            cdvPrimaryChange.SelectedSubItemIndex = 0;
            cdvChangeStatus1.SelectedSubItemIndex = 0;
            cdvChangeStatus2.SelectedSubItemIndex = 0;
            cdvChangeStatus3.SelectedSubItemIndex = 0;
            cdvChangeStatus4.SelectedSubItemIndex = 0;
            cdvChangeStatus5.SelectedSubItemIndex = 0;
            cdvChangeStatus6.SelectedSubItemIndex = 0;
            cdvChangeStatus7.SelectedSubItemIndex = 0;
            cdvChangeStatus8.SelectedSubItemIndex = 0;
            cdvChangeStatus9.SelectedSubItemIndex = 0;
            cdvChangeStatus10.SelectedSubItemIndex = 0;
        }

        public void SetCheckBoxValue(bool bTrue)
        {
            int i;

            for (i = 0; i < lisResourceList.Items.Count; i++)
            {
                lisResourceList.Items[i].Checked = bTrue;
            }
        }

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.tabTran;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmRASTranMultiEvent_Load(object sender, EventArgs e)
        {

        }

        private void frmRASTranMultiEvent_Activated(object sender, EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    ChangeFieldReadOnly();
                    ClearData('1');
                    MPCR.SetCMFItem(MPGC.MP_CMF_TRN_EVENT, "lblCMF", "cdvCMF", grpCMF);
                    SetGroupCmfItem();
                    InitCodeView();

                    lisResourceList.CheckBoxes = true;

                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvMaterial_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvFlow.Text = "";
            cdvOperation.Text = "";
        }

        private void cdvFlow_FlowButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvMaterial.Text) == "")
            {
                cdvFlow.ListCond_Step = '1';
                cdvFlow.ListCond_MatID = "";
                cdvFlow.ListCond_MatVersion = 0;
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
            cdvOperation.Text = "";
        }

        private void cdvOperation_ButtonPress(object sender, EventArgs e)
        {
            cdvOperation.Init();
            MPCF.InitListView(cdvOperation.GetListView);
            cdvOperation.Columns.Add("Oper", 50, HorizontalAlignment.Left);
            cdvOperation.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOperation.SelectedSubItemIndex = 0;

            if (MPCF.Trim(cdvFlow.Text) == "")
            {
                WIPLIST.ViewOperationList(cdvOperation.GetListView, '1', "", 0, "", "", null, "");
                cdvOperation.AddEmptyRow(1);
            }
            else
            {
                WIPLIST.ViewOperationList(cdvOperation.GetListView, '2', "", 0, MPCF.Trim(cdvFlow.Text), "", null, "");
                cdvOperation.AddEmptyRow(1);
            }

        }

        private void cdvType_ButtonPress(object sender, EventArgs e)
        {
            cdvType.Init();
            MPCF.InitListView(cdvType.GetListView);
            cdvType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvType.GetListView, '1', MPGC.MP_RAS_RES_TYPE);
            cdvType.AddEmptyRow(1);
        }

        private void cdvLastEvent_ButtonPress(object sender, EventArgs e)
        {
            cdvLastEvent.Init();
            MPCF.InitListView(cdvLastEvent.GetListView);
            cdvLastEvent.Columns.Add("Event", 50, HorizontalAlignment.Left);
            cdvLastEvent.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvLastEvent.SelectedSubItemIndex = 0;
            RASLIST.ViewEventList(cdvLastEvent.GetListView, '1', "", null, "");
            cdvLastEvent.AddEmptyRow(1);
        }

        private void cdvEventID_ButtonPress(object sender, EventArgs e)
        {
            cdvEventID.Init();
            MPCF.InitListView(cdvEventID.GetListView);
            cdvEventID.Columns.Add("Event", 50, HorizontalAlignment.Left);
            cdvEventID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvEventID.SelectedSubItemIndex = 0;
            RASLIST.ViewEventList(cdvEventID.GetListView, '1', "", null, "");
            cdvEventID.AddEmptyRow(1);
        }

        private void cdvEventID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvEventID.DescText = cdvEventID.SelectedItem.SubItems[1].Text;
            ChangeStatusClear();

            if (View_Event() == false)
            {
                cdvEventID.Text = "";
                cdvEventID.DescText = "";
                return;
            }
        }

        private void cdvPrt1_ButtonPress(object sender, System.EventArgs e)
        {
            SetGRPItem(sGrpTableName);
            cdvPrt1.AddEmptyRow(1);
        }

        private void cdvPrt1_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvGrp1.DisplayText = "";
            cdvGrp1.Text = "";
        }

        private void cdvGrp1_ButtonPress(System.Object sender, System.EventArgs e)
        {
            if (cdvPrt1.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvPrt1.Focus();
                cdvGrp1.IsPopup = false;
                return;
            }

            cdvGrp1.Init();
            MPCF.InitListView(cdvGrp1.GetListView);
            cdvGrp1.Columns.Add("Group", 50, HorizontalAlignment.Left);
            cdvGrp1.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvGrp1.SelectedSubItemIndex = 0;
            if (BASLIST.ViewGCMDataList(cdvGrp1.GetListView, '1', cdvPrt1.Text) == false)
            {
                return;
            }

            cdvGrp1.AddEmptyRow(1);
        }

        private void cdvResGroup_ButtonPress(object sender, EventArgs e)
        {
            cdvResGroup.Init();
            MPCF.InitListView(cdvResGroup.GetListView);
            cdvResGroup.Columns.Add("Group", 50, HorizontalAlignment.Left);
            cdvResGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResGroup.SelectedSubItemIndex = 0;

            if (MPCF.Trim(cdvMaterial.Text) != "" ||
                MPCF.Trim(cdvFlow.Text) != "" ||
                MPCF.Trim(cdvOperation.Text) != "")
            {
                if (RASLIST.ViewResourceGroupList(cdvResGroup.GetListView, '3', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, cdvOperation.Text) == false) return;
                cdvResGroup.AddEmptyRow(1);
            }
            else
            {
                if (RASLIST.ViewResourceGroupList(cdvResGroup.GetListView, '1') == false) return;
                cdvResGroup.AddEmptyRow(1);
            }
        }

        private void cdvPrimaryChange_ButtonPress(System.Object sender, System.EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;

            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', MPCF.Trim(cdvTemp.Tag));

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (View_Resource_List() == true)
            {
                MPCF.FieldClear(tabResource, cdvEventID);
                cdvEventID.Text = "";
                cdvEventID.DescText = "";
                ChangeFieldReadOnly();
            }
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            SetCheckBoxValue(true);
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            SetCheckBoxValue(false);
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            int i;

            if (CheckCondition("EVENT") == false) return;

            for (i = 0;i < lisResourceList.Items.Count; i++)
            {
                if (lisResourceList.Items[i].Checked == true)
                {
                    if (Resource_Event(i) == false)
                    {
                        break;
                    }
                }            
            }

            View_Resource_List();
        }
    }
}

