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
using Miracom.MsgHandler;

namespace Miracom.WIPCore
{
    public partial class frmWIPTranStartLotExt : Miracom.MESCore.TranForm24
    {
        public frmWIPTranStartLotExt()
        {
            InitializeComponent();
        }


        #region " Constant Definition "
        /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
        private enum RES_COL
        {
            RES_ID,
            RES_BTN,
            RES_DESC,
            QTY_1,
            QTY_2,
            QTY_3,
            UP_DOWN_FLAG,
            PRIMARY_STATUS
        }
        /*** End of Add (2012.04.09) ***/
        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        public bool b_dispatcher_flag = false;
        public string sLotID = "";
        public string sResourceID = "";

        #endregion

        #region " Function Definition "

        // ViewLotInfo()
        //       -   View Lot Information
        // Return Value
        //       -
        // Arguments
        //       -
        protected override bool ViewLotInfo(string s_lot_id)
        {
            base.ClearData(1);
            /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
            cdvResIDSP.Items.Clear();
            MPCF.ClearList(spdResource);
            /*** End of Modification (2012.04.09) ***/

            base.SetResID("");
            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }

            GetResourceIDList();

            btnCheckCarrier.Enabled = false;
            if (LOT.GetList("CRR_LIST").Count > 0)
            {
                btnCheckCarrier.Enabled = true;
            }

            /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
            CalculateTotal();
            /*** End of Add (2012.04.09) ***/

            return true;
        }

        //
        // GetResourceIDList()
        //       - Get ResourceID List by Operation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool GetResourceIDList()
        {
            /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
            cdvResIDSP.Init();
            MPCF.InitListView(cdvResIDSP.GetListView);
            cdvResIDSP.Columns.Add("Resource", 150, HorizontalAlignment.Left);
            cdvResIDSP.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            RASLIST.ViewResourceList(cdvResIDSP.GetListView, LOT.GetString("MAT_ID"), LOT.GetInt("MAT_VER"), LOT.GetString("FLOW"), LOT.GetString("OPER"), false);

            if(cdvResIDSP.Items.Count > 0)
            {
                cdvResIDSP.InsertEmptyRow(0, 1);
                spdResource.ActiveSheet.RowCount = 1;
                pnlTotal.Visible = true;
            }
            else
            {
                pnlTotal.Visible = false;
            }
            /*** End of Modification (2012.04.09) ***/

            return true;

        }

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        protected override bool CheckCondition()
        {
            if(base.CheckCondition() == false) return false;

            if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                tabTran.SelectedTab = tbpGeneral;
                txtLotID.Focus();
                return false;
            }
            //if (MPCF.Trim(LOT.GetString("FLOW")) == "")
            //{
            //    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Flow]");
            //    tabTran.SelectedTab = tbpGeneral;
            //    txtLotID.Focus();
            //    return false;
            //}
            if (MPCF.Trim(LOT.GetString("OPER")) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                tabTran.SelectedTab = tbpGeneral;
                txtLotID.Focus();
                return false;
            }

            if (LOT.GetDouble("QTY_1") > 0 || LOT.GetDouble("QTY_2") > 0 || LOT.GetDouble("QTY_3") > 0)
            {
                /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
                //if (cdvResID.Items.Count > 0)
                //{
                //    if (cdvResID.CheckValue() == false)
                //    {
                //        tabTran.SelectedTab = tbpGeneral;
                //        cdvResID.Focus();
                //        return false;
                //    }
                //}
                if (cdvResIDSP.Items.Count > 1)
                {
                    double dQty1 = 0;
                    double dQty2 = 0;
                    double dQty3 = 0;
                    for (int i = 0; i < spdResource.ActiveSheet.RowCount; i++)
                    {
                        if (MPCF.Trim(spdResource.ActiveSheet.GetValue(i, (int)RES_COL.RES_ID)) == "")
                        {
                            spdResource.ActiveSheet.RemoveRows(i, 1);
                        }
                    }
                    for (int i = 0; i < spdResource.ActiveSheet.RowCount; i++)
                    {
                        dQty1 += MPCF.ToDbl(spdResource.ActiveSheet.GetValue(i, (int)RES_COL.QTY_1));
                        dQty2 += MPCF.ToDbl(spdResource.ActiveSheet.GetValue(i, (int)RES_COL.QTY_2));
                        dQty3 += MPCF.ToDbl(spdResource.ActiveSheet.GetValue(i, (int)RES_COL.QTY_3));
                    }
                    if (spdResource.ActiveSheet.RowCount == 0)
                    {
                        spdResource.ActiveSheet.RowCount++;
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Resource ID]");
                        tabTran.SelectedTab = tbpGeneral;
                        spdResource.ActiveSheet.SetActiveCell(0, (int)RES_COL.RES_ID);
                        return false;
                    }
                    else if (spdResource.ActiveSheet.RowCount == 1 &&
                             MPCF.Trim(spdResource.ActiveSheet.GetValue(0, (int)RES_COL.RES_ID)) != "")
                    {
                        dQty1 = LOT.GetDouble("QTY_1");
                        dQty2 = LOT.GetDouble("QTY_2");
                        dQty3 = LOT.GetDouble("QTY_3");
                        spdResource.ActiveSheet.SetValue(0, (int)RES_COL.QTY_1, dQty1);
                        spdResource.ActiveSheet.SetValue(0, (int)RES_COL.QTY_2, dQty2);
                        spdResource.ActiveSheet.SetValue(0, (int)RES_COL.QTY_3, dQty3);
                    }
                    else
                    {
                        if (Math.Abs(dQty1 - LOT.GetDouble("QTY_1")) > 0.0005)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            MPCF.ShowMsgBox(MPCF.GetMessage(202) + " [Qty 1]");
                            spdResource.Focus();
                            return false;
                        }
                        if (Math.Abs(dQty2 - LOT.GetDouble("QTY_2")) > 0.0005)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            MPCF.ShowMsgBox(MPCF.GetMessage(202) + " [Qty 2]");
                            spdResource.Focus();
                            return false;
                        }
                        if (Math.Abs(dQty3 - LOT.GetDouble("QTY_3")) > 0.0005)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            MPCF.ShowMsgBox(MPCF.GetMessage(202) + " [Qty 3]");
                            spdResource.Focus();
                            return false;
                        }
                    }
                }
                /*** End of Modification (2012.04.09) ***/
            }

            return true;
        }

        /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
        //
        // Start_Lot()
        //       - Start Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool StartLot(char ProcStep)
        {
            TRSNode in_node = new TRSNode("START_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode res_list;
            bool b_proc_alarm_action;

            try
            {
                MPCR.SetInMsg(in_node);

                in_node.ProcStep = ProcStep;
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                //in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                for (int i = 0; i < spdResource.ActiveSheet.RowCount; i++)
                {
                    if (MPCF.Trim(spdResource.ActiveSheet.Cells[i, (int)RES_COL.RES_ID].Value) == "") continue;

                    res_list = in_node.AddNode("RES_LIST");
                    res_list.AddString("RES_ID", MPCF.Trim(spdResource.ActiveSheet.Cells[i, (int)RES_COL.RES_ID].Value));
                    res_list.AddDouble("LOT_QTY_1", MPCF.Trim(spdResource.ActiveSheet.Cells[i, (int)RES_COL.QTY_1].Value));
                    res_list.AddDouble("LOT_QTY_2", MPCF.Trim(spdResource.ActiveSheet.Cells[i, (int)RES_COL.QTY_2].Value));
                    res_list.AddDouble("LOT_QTY_3", MPCF.Trim(spdResource.ActiveSheet.Cells[i, (int)RES_COL.QTY_3].Value));
                }
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

                in_node.AddString("TRAN_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("TRAN_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("TRAN_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("TRAN_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("TRAN_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("TRAN_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("TRAN_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("TRAN_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("TRAN_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("TRAN_CMF_10", MPCF.Trim(cdvCMF10.Text));
                in_node.AddString("TRAN_CMF_11", MPCF.Trim(cdvCMF11.Text));
                in_node.AddString("TRAN_CMF_12", MPCF.Trim(cdvCMF12.Text));
                in_node.AddString("TRAN_CMF_13", MPCF.Trim(cdvCMF13.Text));
                in_node.AddString("TRAN_CMF_14", MPCF.Trim(cdvCMF14.Text));
                in_node.AddString("TRAN_CMF_15", MPCF.Trim(cdvCMF15.Text));
                in_node.AddString("TRAN_CMF_16", MPCF.Trim(cdvCMF16.Text));
                in_node.AddString("TRAN_CMF_17", MPCF.Trim(cdvCMF17.Text));
                in_node.AddString("TRAN_CMF_18", MPCF.Trim(cdvCMF18.Text));
                in_node.AddString("TRAN_CMF_19", MPCF.Trim(cdvCMF19.Text));
                in_node.AddString("TRAN_CMF_20", MPCF.Trim(cdvCMF20.Text));

                in_node.AddChar("NO_CHECK_QUEUE_TIME_FLAG", 'Y');

                /***** Start Check Input Port and Change Carrier *****/
                if (CheckResourcePortAndCarrierChange(ref in_node) == false) return false;
                if (in_node.GetList("CHANGE_PORT_STATUS").Count > 0)
                {
                    in_node.AddString("SUBRES_ID", in_node.GetList("CHANGE_PORT_STATUS")[0].GetString("SUBRES_ID"));
                    in_node.AddString("PORT_ID", in_node.GetList("CHANGE_PORT_STATUS")[0].GetString("PORT_ID"));
                }
                /***** End Check Input Port and Change Carrier *****/

                /***** Start Check Transaction Confirm Message *****/
                b_proc_alarm_action = false;
                //if (MPCR.CheckTranAlarmRelation(this,
                //                                MPGC.MP_ALM_TRAN_START,
                //                                LOT.GetString("MAT_ID"),
                //                                LOT.GetInt("MAT_VER"),
                //                                LOT.GetString("FLOW"),
                //                                LOT.GetString("OPER"),
                //                                LOT.GetString("LOT_ID"),
                //                                "START_LOT",
                //                                MPCF.Trim(cdvResID.Text),
                //                                ref b_proc_alarm_action) == false)
                //{
                //    return false;
                //}
                if (MPCR.CheckTranAlarmRelation(this,
                                                MPGC.MP_ALM_TRAN_START,
                                                LOT.GetString("MAT_ID"),
                                                LOT.GetInt("MAT_VER"),
                                                LOT.GetString("FLOW"),
                                                LOT.GetString("OPER"),
                                                LOT.GetString("LOT_ID"),
                                                "START_LOT",
                                                (spdResource.ActiveSheet.RowCount > 0 ? MPCF.Trim(spdResource.ActiveSheet.GetValue(0, (int)RES_COL.RES_ID)) : ""),
                                                ref b_proc_alarm_action) == false)
                {
                    return false;
                }

                if (b_proc_alarm_action == true)
                    in_node.AddChar("PROC_ALARM_FLAG", 'Y');
                /***** End Check Transaction Confirm Message *****/

                /***** Start Set Attribute & Tool Information *****/
                if (base.SetItemValue(in_node) == false)
                {
                    return false;
                }
                /***** End Set Attribute & Tool Information *****/


                if (MPCR.CallService("WIP", "WIP_Start_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }
        /*** End of Modification (2012.04.09) ***/

        //
        // Check_Queue_Time()
        //       - Check Queue Time
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool CheckQueueTime(char ProcStep)
        {

            TRSNode in_node = new TRSNode("CHECK_QUEUE_TIME_IN");
            TRSNode out_node = new TRSNode("CHECK_QUEUE_TIME_OUT");
            DialogResult dr;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddChar("CHECK_POINT_FLAG", 'S');

                if (MPCR.CallService("WIP", "WIP_Check_Queue_Time", in_node, ref out_node, true) == false)
                {
                    if (out_node.MsgCode == "WIP-0302")
                    {
                        dr = MPCF.ShowMsgBox(MPCF.MakeErrorMsg(out_node.MsgCode, MPCF.GetMessage(58), out_node.DBErrMsg, out_node.FieldMsg), MessageBoxButtons.YesNoCancel, 1);
                        if (dr == System.Windows.Forms.DialogResult.No)
                        {
                            in_node.ProcStep = '2';
                            in_node.SetString("LOT_ID", MPCF.Trim(txtLotID.Text));

                            if (MessageCaster.CallService("WIP", "WIP_Check_Queue_Time", in_node, ref out_node) == false)
                            {
                                MPCF.ShowMsgBox(MPMH.StatusMessage);
                                return false;
                            }
                            if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                            {
                                if (MPCR.CheckContinueProc(out_node) == false)
                                {
                                    return false;
                                }
                            }
                        }
                        else if (dr == System.Windows.Forms.DialogResult.Cancel)
                        {
                            return false;
                        }

                    }
                    else
                    {
                        MPCR.CheckContinueProc(out_node);
                        return false;
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

        /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
        private bool CheckResourcePortAndCarrierChange(ref TRSNode in_node)
        {
            bool b_have_port;
            bool b_change_carrier;
            frmWIPTranChangePortCarrier frmChangePortCarrier;
            frmWIPTranChangePortCarrierExt frmChangePortCarrierExt;
            TRSNode port_in = null;
            TRSNode crr_in = null;

            b_have_port = false;
            b_change_carrier = false;

            if (spdResource.ActiveSheet.RowCount == 1)
            {
                string sTmpResID = MPCF.Trim(spdResource.ActiveSheet.GetValue(0, (int)RES_COL.RES_ID));
                if (MPGO.ChangePortStateWithLotTran() == true && sTmpResID != "")
                {
                    if (MPCR.CheckResourceHavePort(sTmpResID, ref b_have_port) == false)
                    {
                        return false;
                    }
                }

                if (LOT.GetDouble("QTY_1") > 0 || LOT.GetDouble("QTY_2") > 0 || LOT.GetDouble("QTY_3") > 0)
                {
                    if (MPCR.CheckCarrierChangeOption(LOT.GetString("MAT_ID"),
                                                      LOT.GetInt("MAT_VER"),
                                                      LOT.GetString("FLOW"),
                                                      LOT.GetString("OPER"),
                                                      'S',
                                                      ref b_change_carrier) == false)
                    {
                        return false;
                    }
                }

                if (b_have_port == false && b_change_carrier == false) return true;

                frmChangePortCarrier = new frmWIPTranChangePortCarrier();

                if (b_have_port == true && b_change_carrier == true)
                {
                    frmChangePortCarrier.SetLayout(ChangePortCarrierLayout.PORT_and_CARRIER);
                    port_in = in_node.AddNode("CHANGE_PORT_STATUS");
                    crr_in = in_node.AddNode("CHANGE_CARRIER");
                }
                else if (b_have_port == true && b_change_carrier == false)
                {
                    frmChangePortCarrier.SetLayout(ChangePortCarrierLayout.PORT);
                    port_in = in_node.AddNode("CHANGE_PORT_STATUS");
                }
                else if (b_have_port == false && b_change_carrier == true)
                {
                    frmChangePortCarrier.SetLayout(ChangePortCarrierLayout.CARRIER);
                    crr_in = in_node.AddNode("CHANGE_CARRIER");
                }

                frmChangePortCarrier.SetInformation(LOT.GetString("LOT_ID"),
                                                    LOT.GetString("LOT_DESC"),
                                                    LOT.GetString("MAT_ID"),
                                                    LOT.GetInt("MAT_VER"),
                                                    LOT.GetString("FLOW"),
                                                    LOT.GetString("OPER"),
                                                    sTmpResID,
                                                    'S',
                                                    "",
                                                    ref port_in,
                                                    ref crr_in);

                if (frmChangePortCarrier.ShowDialog(this) != DialogResult.OK) return false;

                if (frmChangePortCarrier.IsDisposed == false)
                    frmChangePortCarrier.Dispose();
            }
            else
            {
                if (spdResource.ActiveSheet.RowCount > 0)
                {
                    if (MPGO.ChangePortStateWithLotTran() == true && MPCF.Trim(spdResource.ActiveSheet.GetValue(0, (int)RES_COL.RES_ID)) != "")
                    {
                        if (MPCR.CheckResourceHavePort(MPCF.Trim(spdResource.ActiveSheet.GetValue(0, (int)RES_COL.RES_ID)), ref b_have_port) == false)
                        {
                            return false;
                        }
                    }
                }

                if (LOT.GetDouble("QTY_1") > 0 || LOT.GetDouble("QTY_2") > 0 || LOT.GetDouble("QTY_3") > 0)
                {
                    if (MPCR.CheckCarrierChangeOption(LOT.GetString("MAT_ID"),
                                                      LOT.GetInt("MAT_VER"),
                                                      LOT.GetString("FLOW"),
                                                      LOT.GetString("OPER"),
                                                      'S',
                                                      ref b_change_carrier) == false)
                    {
                        return false;
                    }
                }

                if (b_have_port == false && b_change_carrier == false) return true;

                frmChangePortCarrierExt = new frmWIPTranChangePortCarrierExt();

                if (b_have_port == true && b_change_carrier == true)
                {
                    frmChangePortCarrierExt.SetLayout(ChangePortCarrierLayout.PORT_and_CARRIER);
                }
                else if (b_have_port == true && b_change_carrier == false)
                {
                    frmChangePortCarrierExt.SetLayout(ChangePortCarrierLayout.PORT);
                }
                else if (b_have_port == false && b_change_carrier == true)
                {
                    frmChangePortCarrierExt.SetLayout(ChangePortCarrierLayout.CARRIER);
                }

                System.Collections.ArrayList aResList = new System.Collections.ArrayList();
                System.Collections.ArrayList aResDescList = new System.Collections.ArrayList();
                for (int i = 0; i < spdResource.ActiveSheet.RowCount; i++)
                {
                    if (MPCF.Trim(spdResource.ActiveSheet.GetValue(i, (int)RES_COL.RES_ID)) != "")
                    {
                        aResList.Add(MPCF.Trim(spdResource.ActiveSheet.GetValue(i, (int)RES_COL.RES_ID)));
                        aResDescList.Add(MPCF.Trim(spdResource.ActiveSheet.GetValue(i, (int)RES_COL.RES_DESC)));
                    }
                }
                frmChangePortCarrierExt.SetInformation(LOT.GetString("LOT_ID"),
                                                       LOT.GetString("LOT_DESC"),
                                                       LOT.GetString("MAT_ID"),
                                                       LOT.GetInt("MAT_VER"),
                                                       LOT.GetString("FLOW"),
                                                       LOT.GetString("OPER"),
                                                       aResList,
                                                       aResDescList,
                                                       'S',
                                                       null,
                                                       ref in_node);

                if (frmChangePortCarrierExt.ShowDialog(this) != DialogResult.OK) return false;

                if (frmChangePortCarrierExt.IsDisposed == false)
                    frmChangePortCarrierExt.Dispose();

            }

            return true;
        }

        //
        // View_Resource()
        //       - Get ResourceID Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewResource(String s_res_id, FarPoint.Win.Spread.FpSpread spdRes, int iRow)
        {

#if _RAS
            TRSNode in_node = new TRSNode("VIEW_RESOURCE_IN");
            TRSNode out_node = new TRSNode("VIEW_RESOURCE_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", MPCF.Trim(s_res_id));

                if (MPCR.CallService("RAS", "RAS_View_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdRes.ActiveSheet.SetValue(iRow, (int)RES_COL.RES_ID, out_node.GetString("RES_ID"));
                spdRes.ActiveSheet.SetValue(iRow, (int)RES_COL.RES_DESC, out_node.GetString("RES_DESC"));
                spdRes.ActiveSheet.SetValue(iRow, (int)RES_COL.PRIMARY_STATUS, out_node.GetString("RES_PRI_STS"));

                if (out_node.GetChar("RES_UP_DOWN_FLAG") == 'U')
                {
                    spdRes.ActiveSheet.SetValue(iRow, (int)RES_COL.UP_DOWN_FLAG, "UP");
                }
                else if (out_node.GetChar("RES_UP_DOWN_FLAG") == 'D')
                {
                    spdRes.ActiveSheet.SetValue(iRow, (int)RES_COL.UP_DOWN_FLAG, "DOWN");
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
#endif
            return true;

        }

        //
        // CalculateTotal()
        //       - Calculate 
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private void CalculateTotal()
        {
            double dResCount = 0;
            double dQty1 = 0;
            double dQty2 = 0;
            double dQty3 = 0;

            try
            {
                for (int i = 0; i < spdResource.ActiveSheet.RowCount; i++)
                {
                    if (MPCF.Trim(spdResource.ActiveSheet.GetValue(i, (int)RES_COL.RES_ID)) != "")
                    {
                        dResCount++;
                        dQty1 += MPCF.ToDbl(spdResource.ActiveSheet.GetValue(i, (int)RES_COL.QTY_1));
                        dQty2 += MPCF.ToDbl(spdResource.ActiveSheet.GetValue(i, (int)RES_COL.QTY_2));
                        dQty3 += MPCF.ToDbl(spdResource.ActiveSheet.GetValue(i, (int)RES_COL.QTY_3));
                    }
                }
                txtResCount.Text = dResCount.ToString();
                txtTotalQty1.Text = String.Format("{0:#,##0.###}/{1:#,##0.###},{2:#,##0.###}", dQty1, LOT.GetDouble("QTY_1"), LOT.GetDouble("QTY_1") - dQty1);
                txtTotalQty2.Text = String.Format("{0:#,##0.###}/{1:#,##0.###},{2:#,##0.###}", dQty2, LOT.GetDouble("QTY_2"), LOT.GetDouble("QTY_2") - dQty2);
                txtTotalQty3.Text = String.Format("{0:#,##0.###}/{1:#,##0.###},{2:#,##0.###}", dQty3, LOT.GetDouble("QTY_3"), LOT.GetDouble("QTY_3") - dQty3);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        /*** End of Modification (2012.04.09) ***/

        #endregion

        private void frmWIPTranStartLot_Activated(object sender, System.EventArgs e)
        {

            try
            {
                if (b_load_flag == false)
                {
                    base.SetInputValuePoint(MESCore.Controls.INPUT_VALUE_POINT.START);

                    SetCMFItem(MPGC.MP_CMF_TRN_START);

                    /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
                    MPCF.ClearList(spdResource);
                    /*** End of Add (2012.04.09) ***/

                    if (b_dispatcher_flag == true)
                    {
                        if (sLotID != "")
                        {
                            txtLotID.Text = sLotID;
                            ViewLotInfo(txtLotID.Text);
                        }
                        if (sResourceID != "" && spdResource.ActiveSheet.RowCount > 0)
                        {
                            /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
                            //cdvResID.Text = sResourceID;
                            //base.SetResID(cdvResID.Text);
                            spdResource.ActiveSheet.SetValue(0, (int)RES_COL.RES_ID, sResourceID);
                            base.SetResID(sResourceID);
                            base.ViewToolInfo();
                            /*** End of Modification (2012.04.09) ***/
                        }
                    }
                    else
                    {
                        ClearData(1);
                        if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                        {
                            txtLotID.Text = MPGV.gsCurrentLot_ID;
                            ViewLotInfo(txtLotID.Text);
                        }
                    }

                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition() == false) return;
                if (CheckQueueTime('1') == false) return;
                if (base.ViewLotInfo(txtLotID.Text, false) == false) return;

                string s_res_id = "";
                if (spdResource.ActiveSheet.RowCount > 0)
                {
                    s_res_id = MPCF.Trim(spdResource.ActiveSheet.Cells[0, (int)RES_COL.RES_ID].Value);
                }

                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_START, LOT.GetString("LOT_ID"), s_res_id, "START_LOT", 'B') == false) return;
                if (StartLot('1') == false) return;
                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_START, LOT.GetString("LOT_ID"), s_res_id, "START_LOT", 'A') == false) return;

                ViewLotInfo(txtLotID.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
        private void spdResource_EditModeOff(object sender, EventArgs e)
        {
            int i_col;
            int i_row;

            try
            {
                i_col = spdResource.ActiveSheet.ActiveColumnIndex;
                i_row = spdResource.ActiveSheet.ActiveRowIndex;

                //Add 1 Row
                if (i_row == spdResource.ActiveSheet.RowCount - 1)
                {
                    if (MPCF.Trim(spdResource.ActiveSheet.Cells[i_row, (int)RES_COL.RES_ID].Value) != "")
                    {
                        spdResource.ActiveSheet.RowCount++;
                    }
                }
                CalculateTotal();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdResource_EnterCell(object sender, FarPoint.Win.Spread.EnterCellEventArgs e)
        {
            try
            {
                //Add 1 Row
                if (e.Row == spdResource.ActiveSheet.RowCount - 1)
                {
                    if (MPCF.Trim(spdResource.ActiveSheet.Cells[e.Row, (int)RES_COL.RES_ID].Value) != "")
                    {
                        spdResource.ActiveSheet.RowCount++;                        
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdResource_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column == (int)RES_COL.RES_BTN)
                {
                    if (MPCF.Trim(LOT.GetString("OPER")) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                        txtLotID.Focus();
                        return;
                    }

                    if (cdvResIDSP.ShowPopupList(e.Row, e.Column) == false)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvResIDSP_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            try
            {
                string sResID = MPCF.Trim(e.SelectedItem.SubItems[0].Text);
                if (MPCF.Trim(spdResource.ActiveSheet.GetValue(e.Row, e.Col - 1)) != sResID)
                {
                    for (int i = 0; i < spdResource.ActiveSheet.RowCount; i++)
                    {
                        if (MPCF.Trim(spdResource.ActiveSheet.GetValue(i, e.Col - 1)) == sResID &&
                            MPCF.Trim(spdResource.ActiveSheet.GetValue(i, e.Col - 1)) != "")
                        {
                            return;
                        }
                    }

                    if (sResID != "")
                    {
                        ViewResource(sResID, spdResource, e.Row);
                        base.SetResID(sResID);
                        base.ViewToolInfo();
                        if (e.Row == spdResource.ActiveSheet.RowCount - 1)
                        {
                            if (MPCF.Trim(spdResource.ActiveSheet.Cells[e.Row, (int)RES_COL.RES_ID].Value) != "")
                            {
                                spdResource.ActiveSheet.RowCount++;
                            }
                        }
                    }
                    else
                    {
                        spdResource.ActiveSheet.Cells[e.Row, (int)RES_COL.RES_ID].Value = "";
                        spdResource.ActiveSheet.Cells[e.Row, (int)RES_COL.RES_DESC, e.Row, (int)RES_COL.PRIMARY_STATUS].Value = "";
                        CalculateTotal();
                    }
                }
                if (sResID != "")
                {
                    MPCR.PopupInformNote(null, "", "", "", "", "", sResID);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        /*** End of Add (2012.04.09) ***/

        private void btnCheckCarrier_Click(object sender, EventArgs e)
        {
            if (LOT.GetList("CRR_LIST").Count < 1) return;

            MPGV.gsCurrentLot_ID = txtLotID.Text;

            frmWIPTranCheckCarrier checkCarrier = new frmWIPTranCheckCarrier();
            checkCarrier.ShowDialog(this);
        }

    }
}
