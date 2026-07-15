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
    public partial class frmWIPTranEndLotExt2 : TranForm29
    {
        public frmWIPTranEndLotExt2()
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

        /*** Carrier and Loss Logic (2012.04.17 by Aiden.Koo) ***/
        private const int MAX_CARRIER_SLOT_NO = 25;
        private const string LOSS_REUSABLE_TYPE_SCRAP = "S";
        private const string LOSS_REUSABLE_TYPE_NO_SCRAP = "N";

        private bool b_change_carrier;
        private ListView m_lis_loss_code;
        /*** End of Add (2012.04.17 by Aiden.Koo) ***/

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
            //cdvResID.Items.Clear();
            cdvResIDSP.Items.Clear();
            MPCF.ClearList(spdResource);

            base.SetResID("");
            if (base.ViewLotInfo(txtLotID.Text) == false)
            {
                txtLotID.Focus();
                return false;
            }

            GetResourceIDList();

            ViewProcOperList();
            //cdvResID.Text = LOT.GetString("START_RES_ID");

            //if (cdvResID.Text != "")
            //{
            //    base.SetResID(cdvResID.Text);
            //    base.ViewToolInfo();
            //}
            for (int i = 0; i < LOT.GetList("START_RES_LIST").Count; i++)
            {
                spdResource.ActiveSheet.RowCount++;
                ViewResource(LOT.GetList("START_RES_LIST")[i].GetString("RES_ID"), spdResource, i);
                spdResource.ActiveSheet.SetValue(i, (int)RES_COL.QTY_1, LOT.GetList("START_RES_LIST")[i].GetDouble("QTY_1"));
                spdResource.ActiveSheet.SetValue(i, (int)RES_COL.QTY_2, LOT.GetList("START_RES_LIST")[i].GetDouble("QTY_2"));
                spdResource.ActiveSheet.SetValue(i, (int)RES_COL.QTY_3, LOT.GetList("START_RES_LIST")[i].GetDouble("QTY_3"));
            }
            if (cdvResIDSP.Items.Count > 0)
            {
                if (spdResource.ActiveSheet.RowCount > 0)
                {
                    base.SetResID(MPCF.Trim(spdResource.ActiveSheet.GetValue(0, (int)RES_COL.RES_ID)));
                }

                spdResource.ActiveSheet.RowCount++;
            }

            base.ViewToolInfo();

            CalculateTotal();
            /*** End of Modification (2012.04.09) ***/

            /*** Carrier and Loss Logic (2012.04.17 by Aiden.Koo) ***/
            if (ViewCarrierLotList() == false) return false;
            if (ViewLossCode() == false) return false;
            /*** End of Add (2012.04.17 by Aiden.Koo) ***/

            //Add by Kelly Jung 20160304
            //Change Carrier......
            if (LOT.GetInt("SUBLOT_COUNT") > 0)
            {
                tabTran.TabPages["tbpCarrier"].Dispose();
            }

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

            try
            {
                /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
                //cdvResID.Init();
                //MPCF.InitListView(cdvResID.GetListView);
                //cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                //cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                //cdvResID.SelectedSubItemIndex = 0;

//#if _RAS
                //if (RASLIST.ViewResourceList(cdvResID.GetListView, LOT.GetString("MAT_ID"), LOT.GetInt("MAT_VER"), LOT.GetString("FLOW"), LOT.GetString("OPER"), false) == false)
                //{
                //    return false;
                //}
//#endif
                cdvResIDSP.Init();
                MPCF.InitListView(cdvResIDSP.GetListView);
                cdvResIDSP.Columns.Add("Resource", 150, HorizontalAlignment.Left);
                cdvResIDSP.Columns.Add("Desc", 200, HorizontalAlignment.Left);
#if _RAS
                RASLIST.ViewResourceList(cdvResIDSP.GetListView, LOT.GetString("MAT_ID"), LOT.GetInt("MAT_VER"), LOT.GetString("FLOW"), LOT.GetString("OPER"), false);
#endif
                if (cdvResIDSP.Items.Count > 0)
                {
                    cdvResIDSP.InsertEmptyRow(0, 1);
                    pnlTotal.Visible = true;
                }
                else
                {
                    pnlTotal.Visible = false;
                }
                /*** End of Modification (2012.04.09) ***/
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

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
            if (base.CheckCondition() == false) return false;

            if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                tabTran.SelectedTab = tbpGeneral;
                txtLotID.Focus();
                return false;
            }
            if (MPCF.Trim(LOT.GetString("FLOW")) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Flow]");
                tabTran.SelectedTab = tbpGeneral;
                txtLotID.Focus();
                return false;
            }
            if (MPCF.Trim(LOT.GetString("OPER")) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                tabTran.SelectedTab = tbpGeneral;
                txtLotID.Focus();
                return false;
            }
            //if (cdvToFlow.Text == "" && cdvToOperation.Text != "")
            //{
            //    MPCF.ShowMsgBox(MPCF.GetMessage(108));
            //    tabTran.SelectedTab = tbpGeneral;
            //    cdvToFlow.Focus();
            //    return false;
            //}
            if (cdvToFlow.Text != "" && cdvToOperation.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                tabTran.SelectedTab = tbpGeneral;
                cdvToOperation.Focus();
                return false;
            }
            if (cdvReturnFlow.Text == "" && cdvRetOperation.Text != "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                tabTran.SelectedTab = tbpGeneral;
                cdvReturnFlow.FlowFocus();
                return false;
            }
            if (cdvReturnFlow.Text != "" && cdvRetOperation.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                tabTran.SelectedTab = tbpGeneral;
                cdvRetOperation.Focus();
                return false;
            }
            if (cdvReturnFlow.Text != "" && cdvRetOperation.Text != "")
            {
                if (cdvToFlow.Text == "" || cdvToOperation.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    tabTran.SelectedTab = tbpGeneral;
                    if (cdvToFlow.Text == "")
                    {
                        cdvToFlow.Focus();
                        return false;
                    }
                    if (cdvToOperation.Text == "")
                    {
                        cdvToOperation.Focus();
                        return false;
                    }
                }
            }
            if (LOT.GetDouble("QTY_1") > 0 || LOT.GetDouble("QTY_2") > 0 || LOT.GetDouble("QTY_3") > 0)
            {
                /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
                //if (cdvResID.Items.Count > 0)
                //{
                //    if (MPCF.CheckValue(cdvResID, 1) == false)
                //    {
                //        tabTran.SelectedTab = tbpGeneral;
                //        cdvResID.Focus();
                //        return false;
                //    }
                //}
                if (cdvResIDSP.Items.Count > 1)
                {
                    int i;
                    double dQty1 = 0;
                    double dQty2 = 0;
                    double dQty3 = 0;

                    for (i = 0; i < spdResource.ActiveSheet.RowCount; i++)
                    {
                        if (MPCF.Trim(spdResource.ActiveSheet.GetValue(i, (int)RES_COL.RES_ID)) == "")
                        {
                            spdResource.ActiveSheet.RemoveRows(i, 1);
                        }
                    }
                    if (spdResource.ActiveSheet.RowCount < 1)
                    {
                        spdResource.ActiveSheet.RowCount++;
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Resource ID]");
                        tabTran.SelectedTab = tbpGeneral;
                        spdResource.ActiveSheet.SetActiveCell(0, (int)RES_COL.RES_ID);
                        return false;
                    }
                    if (spdResource.ActiveSheet.RowCount == 1 &&
                        MPCF.Trim(spdResource.ActiveSheet.GetValue(0, (int)RES_COL.RES_ID)) != "")
                    {
                        if (spdCarrierLoss.ActiveSheet.RowCount < 1)
                        {
                            spdResource.ActiveSheet.SetValue(0, (int)RES_COL.QTY_1, LOT.GetDouble("QTY_1"));
                            spdResource.ActiveSheet.SetValue(0, (int)RES_COL.QTY_2, LOT.GetDouble("QTY_2"));
                            spdResource.ActiveSheet.SetValue(0, (int)RES_COL.QTY_3, LOT.GetDouble("QTY_3"));
                        }
                        else
                        {
                            spdResource.ActiveSheet.SetValue(0, (int)RES_COL.QTY_1, spdCarrierLoss.ActiveSheet.Cells[spdCarrierLoss.ActiveSheet.RowCount - 1, 4].Value);
                            spdResource.ActiveSheet.SetValue(0, (int)RES_COL.QTY_2, LOT.GetDouble("QTY_2"));
                            spdResource.ActiveSheet.SetValue(0, (int)RES_COL.QTY_3, LOT.GetDouble("QTY_3"));
                        }
                    }

                    for (i = 0; i < spdResource.ActiveSheet.RowCount; i++)
                    {
                        dQty1 += MPCF.ToDbl(spdResource.ActiveSheet.GetValue(i, (int)RES_COL.QTY_1));
                        dQty2 += MPCF.ToDbl(spdResource.ActiveSheet.GetValue(i, (int)RES_COL.QTY_2));
                        dQty3 += MPCF.ToDbl(spdResource.ActiveSheet.GetValue(i, (int)RES_COL.QTY_3));
                    }

                    if (spdCarrierLoss.ActiveSheet.RowCount < 1)
                    {
                        if (Math.Abs(dQty1 - LOT.GetDouble("QTY_1")) > 0.0005)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            MPCF.ShowMsgBox(MPCF.GetMessage(202) + " [Qty 1]");
                            spdResource.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        if (Math.Abs(dQty1 - MPCF.ToDbl(spdCarrierLoss.ActiveSheet.Cells[spdCarrierLoss.ActiveSheet.RowCount - 1, 4].Value)) > 0.0005)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            MPCF.ShowMsgBox(MPCF.GetMessage(202) + " [Qty 1]");
                            spdResource.Focus();
                            return false;
                        }
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
                /*** End of Modification (2012.04.09) ***/
            }

            if (txtNewQty1.Text != "")
            {
                if (MPCF.CheckValue(txtNewQty1, 2) == false)
                {
                    tabTran.SelectedTab = tbpGeneral;
                    txtNewQty1.Focus();
                    return false;
                }
            }
            if (txtNewQty2.Text != "")
            {
                if (MPCF.CheckValue(txtNewQty2, 2) == false)
                {
                    tabTran.SelectedTab = tbpGeneral;
                    txtNewQty2.Focus();
                    return false;
                }
            }
            if (txtNewQty3.Text != "")
            {
                if (MPCF.CheckValue(txtNewQty3, 2) == false)
                {
                    tabTran.SelectedTab = tbpGeneral;
                    txtNewQty3.Focus();
                    return false;
                }
            }


            /*** Carrier and Loss Logic (2012.04.17 by Aiden.Koo) ***/

            //Change by Kelly Jung 20160304
            //Change Carrier......
            //if (spdCarrierLoss.ActiveSheet.RowCount > 0)
            if (spdCarrierLoss.ActiveSheet.RowCount > 0 && LOT.GetInt("SUBLOT_COUNT")<=0)
            {
                if (MPCF.ToInt(spdCarrierLoss.ActiveSheet.Cells[spdCarrierLoss.ActiveSheet.RowCount - 1, 1].Value)
                    != MPCF.ToInt(spdCarrierLoss.ActiveSheet.Cells[spdCarrierLoss.ActiveSheet.RowCount - 1, 3].Value))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(323));
                    tabTran.SelectedTab = tbpCarrier;
                    spdCarrierLoss.Focus();
                    spdCarrierLoss.ActiveSheet.SetActiveCell(0, 3);
                    return false;
                }

                if (b_change_carrier == true)
                {
                    int i;
                    int i_change_crr_count;
                    int i_to_qty;
                    string s_to_crr_id;

                    i_change_crr_count = 0;

                    for (i = 0; i < spdCarrierLoss.ActiveSheet.RowCount - 1; i++)
                    {
                        s_to_crr_id = MPCF.Trim(spdCarrierLoss.ActiveSheet.Cells[i, 2].Value);
                        i_to_qty = MPCF.ToInt(spdCarrierLoss.ActiveSheet.Cells[i, 4].Value);

                        if (i_to_qty > 0)
                        {
                            if (s_to_crr_id != "")
                            {
                                //if (MPCF.Trim(spdCarrierLoss.ActiveSheet.Cells[i, 0].Value) != s_to_crr_id)
                                //{
                                i_change_crr_count++;
                                //}
                            }
                            else
                            {
                                if (MPCF.Trim(spdCarrierLoss.ActiveSheet.Cells[i, 0].Value) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(324));
                                    tabTran.SelectedTab = tbpCarrier;
                                    spdCarrierLoss.Focus();
                                    spdCarrierLoss.ActiveSheet.SetActiveCell(i, 2);
                                    return false;
                                }
                            }
                        }
                        else if (i_to_qty < 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(325));
                            tabTran.SelectedTab = tbpCarrier;
                            spdCarrierLoss.Focus();
                            spdCarrierLoss.ActiveSheet.SetActiveCell(i, 3);
                            return false;
                        }
                        else
                        {
                            if (MPCF.Trim(spdCarrierLoss.ActiveSheet.Cells[i, 0].Value) == "" && s_to_crr_id != "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(326));
                                tabTran.SelectedTab = tbpCarrier;
                                spdCarrierLoss.Focus();
                                spdCarrierLoss.ActiveSheet.SetActiveCell(i, 3);
                                return false;
                            }
                        }
                    }

                    if (i_change_crr_count < 1)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(327));
                        tabTran.SelectedTab = tbpCarrier;
                        spdCarrierLoss.Focus();
                        spdCarrierLoss.ActiveSheet.SetActiveCell(0, 2);
                        return false;
                    }
                }
            }
            /*** End of Add (2012.04.17 by Aiden.Koo) ***/

            return true;
        }

        // GetToOperationList()
        //       - Get Operation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sFlow As String : Flow Name
        //
        private bool GetToOperationList(string sFlow)
        {

            try
            {
                cdvToOperation.Init();
                MPCF.InitListView(cdvToOperation.GetListView);
                cdvToOperation.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvToOperation.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvToOperation.SelectedSubItemIndex = 0;

                if (WIPLIST.ViewOperationList(cdvToOperation.GetListView, '2', "", 0, sFlow, "", null, "") == false)
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
        //
        // GetRetOperationList()
        //       - Get Operation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sFlow As String : Flow Name
        //
        private bool GetRetOperationList(string sFlow)
        {

            try
            {
                cdvRetOperation.Init();
                MPCF.InitListView(cdvRetOperation.GetListView);
                cdvRetOperation.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvRetOperation.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvRetOperation.SelectedSubItemIndex = 0;

                if (WIPLIST.ViewOperationList(cdvRetOperation.GetListView, '2', "", 0, sFlow, "", null, "") == false)
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

        private void ViewProcOperList()
        {

            WIPLIST.ViewProcessedOperationList(lisProcOperList, '1', txtLotID.Text, null);
            if (lisProcOperList.Items.Count > 0)
            {

                cdvToFlow.Size = new Size(279, 20);
                cdvToOperation.Size = new Size(172, 20);
                /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
                //cdvResID.Size = new Size(172, 20);
                /*** End of Delete (2012.04.09) ***/

                txtNewQty1.Size = new Size(57, 20);
                txtNewQty2.Size = new Size(57, 20);
                txtNewQty3.Size = new Size(57, 20);

                lblRetOper.Location = new Point(308, 46);
                cdvReturnFlow.Location = new Point(307, 17);
                cdvRetOperation.Location = new Point(414, 42);
                cdvReturnFlow.Size = new Size(279, 20);
                cdvRetOperation.Size = new Size(172, 20);

                txtNewQty1.Location = new Point(118, 67);
                txtNewQty2.Location = new Point(176, 67);
                txtNewQty3.Location = new Point(234, 67);

                lisProcOperList.Visible = true;

            }
            else
            {

                cdvToFlow.Size = new Size(307, 20);
                cdvToOperation.Size = new Size(200, 20);
                /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
                //cdvResID.Size = new Size(200, 20);
                /*** End of Delete (2012.04.09) ***/

                txtNewQty1.Size = new Size(66, 20);
                txtNewQty2.Size = new Size(66, 20);
                txtNewQty3.Size = new Size(66, 20);

                lblRetOper.Location = new Point(352, 46);
                cdvReturnFlow.Location = new Point(352, 17);
                cdvRetOperation.Location = new Point(458, 42);
                cdvReturnFlow.Size = new Size(307, 20);
                cdvRetOperation.Size = new Size(200, 20);

                txtNewQty1.Location = new Point(118, 67);
                txtNewQty2.Location = new Point(185, 67);
                txtNewQty3.Location = new Point(252, 67);

                lisProcOperList.Visible = false;

            }

        }

        /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
        //
        // End_Lot()
        //       - End Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool EndLot(char ProcStep)
        {

            TRSNode in_node = new TRSNode("END_LOT_IN");
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
                in_node.AddDouble("QTY_1", (txtNewQty1.Text == "") ? -1 : (MPCF.ToDbl(txtNewQty1.Text)));
                in_node.AddDouble("QTY_2", (txtNewQty2.Text == "") ? -1 : (MPCF.ToDbl(txtNewQty2.Text)));
                in_node.AddDouble("QTY_3", (txtNewQty3.Text == "") ? -1 : (MPCF.ToDbl(txtNewQty3.Text)));

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }

                in_node.AddString("TO_FLOW", MPCF.Trim(cdvToFlow.Text));
                in_node.AddInt("TO_FLOW_SEQ_NUM", cdvToFlow.Sequence);
                in_node.AddString("TO_OPER", MPCF.Trim(cdvToOperation.Text));
                in_node.AddString("RET_FLOW", MPCF.Trim(cdvReturnFlow.Text));
                in_node.AddInt("RET_FLOW_SEQ_NUM", cdvReturnFlow.Sequence);
                in_node.AddString("RET_OPER", MPCF.Trim(cdvRetOperation.Text));
                //in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                for (int i = 0; i < spdResource.ActiveSheet.RowCount; i++)
                {
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


                /***** Start Check Input Port and Change Carrier *****/
                if (CheckResourcePortAndCarrierChange(ref in_node) == false) return false;
                if (in_node.GetList("CHANGE_PORT_STATUS").Count > 0)
                {
                    in_node.AddString("SUBRES_ID", in_node.GetList("CHANGE_PORT_STATUS")[0].GetString("SUBRES_ID"));
                    in_node.AddString("PORT_ID", in_node.GetList("CHANGE_PORT_STATUS")[0].GetString("PORT_ID"));

                    if (chkTranDateTime.Checked == true)
                    {
                        String s_datetime = MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) +
                            MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT);
                        in_node.GetList("CHANGE_PORT_STATUS")[0].AddString("BACK_TIME", s_datetime);
                    }

                }
                if (in_node.GetList("CHANGE_CARRIER").Count > 0)
                {
                    if (chkTranDateTime.Checked == true)
                    {
                        String s_datetime = MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) +
                            MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT);
                        in_node.GetList("CHANGE_CARRIER")[0].AddString("BACK_TIME", s_datetime);
                    }

                }
                /***** End Check Input Port and Change Carrier *****/


                /***** Start Check Transaction Confirm Message *****/
                b_proc_alarm_action = false;
                if (spdResource.ActiveSheet.RowCount > 0)
                {
                    if (MPCR.CheckTranAlarmRelation(this,
                                                    MPGC.MP_ALM_TRAN_END,
                                                    LOT.GetString("MAT_ID"),
                                                    LOT.GetInt("MAT_VER"),
                                                    LOT.GetString("FLOW"),
                                                    LOT.GetString("OPER"),
                                                    LOT.GetString("LOT_ID"),
                                                    "END_LOT",
                                                    MPCF.Trim(spdResource.ActiveSheet.GetValue(0, (int)RES_COL.RES_ID)),
                                                    ref b_proc_alarm_action) == false)
                    {
                        return false;
                    }
                }
                else
                {
                    if (MPCR.CheckTranAlarmRelation(this,
                                                    MPGC.MP_ALM_TRAN_END,
                                                    LOT.GetString("MAT_ID"),
                                                    LOT.GetInt("MAT_VER"),
                                                    LOT.GetString("FLOW"),
                                                    LOT.GetString("OPER"),
                                                    LOT.GetString("LOT_ID"),
                                                    "END_LOT",
                                                    "",
                                                    ref b_proc_alarm_action) == false)
                    {
                        return false;
                    }
                }

                if (b_proc_alarm_action == true)
                {
                    in_node.AddChar("PROC_ALARM_FLAG", 'Y');
                }
                /***** End Check Transaction Confirm Message *****/


                /***** Start Set Attribute & Tool Information *****/
                if (base.SetItemValue(in_node) == false)
                {
                    return false;
                }
                /***** End Set Attribute & Tool Information *****/

                /***** Start Set Collect Lot Data Information *****/
                if (base.SetCollectLotData(in_node) == false)
                {
                    return false;
                }
                /***** End Set Collect Lot Data Information *****/

                /*** Carrier and Loss Logic (2012.04.17 by Aiden.Koo) ***/
                /***** Start Set Change Carrier Information *****/
                if (SetChangeCarrierInfor(in_node) == false)
                {
                    return false;
                }
                /***** End Set Change Carrier Information *****/

                /***** Start Set Loss Information *****/
                if (SetLossInfor(in_node) == false)
                {
                    return false;
                }
                /***** End Set Loss Information *****/

                /*** End of Add (2012.04.17 by Aiden.Koo) ***/

                /***** Start Collect BIN Data *****/
                bool b_proc_end_lot_by_bin_flag = false;
                if (CollectBinData(ref b_proc_end_lot_by_bin_flag, in_node) == false)
                {
                    return false;
                }
                /***** End Collect BIN Data *****/

                if (b_proc_end_lot_by_bin_flag == false)
                {
                    if (MPCR.CallService("WIP", "WIP_End_Lot_Ext", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    MPCR.ShowSuccessMsg(out_node);
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }
        /*** End of Modification (2012.04.09) ***/

        /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
        private bool CheckResourcePortAndCarrierChange(ref TRSNode in_node)
        {
            bool b_have_port;

            //------------------------
            //Add by Kelly Jung 20160304
            //Change Carrier......
            bool b_change_carrier;
            //-------------------------

            frmWIPTranChangePortCarrier frmChangePortCarrier;
            frmWIPTranChangePortCarrierExt frmChangePortCarrierExt;
            TRSNode port_in = null;
            TRSNode crr_in = null;

            b_have_port = false;
            


            //------------------------------------------------------
            //Add by Kelly Jung 20160304
            //Change Carrier......
            b_change_carrier = false;

            if (LOT.GetDouble("QTY_1") > 0 || LOT.GetDouble("QTY_2") > 0 || LOT.GetDouble("QTY_3") > 0)
            {
                if (MPCR.CheckCarrierChangeOption(LOT.GetString("MAT_ID"),
                                                  LOT.GetInt("MAT_VER"),
                                                  LOT.GetString("FLOW"),
                                                  LOT.GetString("OPER"),
                                                  'E',
                                                  ref b_change_carrier) == false)
                {
                    return false;
                }
            }
            //------------------------------------------------------

            if (spdResource.ActiveSheet.RowCount <= 1)
            {
                string sTmpResID = "";
                if (MPGO.ChangePortStateWithLotTran() == true && spdResource.ActiveSheet.RowCount > 0)
                {
                    sTmpResID = MPCF.Trim(spdResource.ActiveSheet.GetValue(0, (int)RES_COL.RES_ID));
                    if (sTmpResID != "")
                    {
                        if (MPCR.CheckResourceHavePort(sTmpResID, ref b_have_port) == false)
                        {
                            return false;
                        }
                    }
                }

                //------------------------------------------------------
                //Change by Kelly Jung 20160304
                //Change Carrier......
                //if (b_have_port == false) return true;
                //frmChangePortCarrier = new frmWIPTranChangePortCarrier();
                //frmChangePortCarrier.SetLayout(ChangePortCarrierLayout.PORT);
                //port_in = in_node.AddNode("CHANGE_PORT_STATUS");


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
                //------------------------------------------------------

                frmChangePortCarrier.SetInformation(LOT.GetString("LOT_ID"),
                                                    LOT.GetString("LOT_DESC"),
                                                    LOT.GetString("MAT_ID"),
                                                    LOT.GetInt("MAT_VER"),
                                                    LOT.GetString("FLOW"),
                                                    LOT.GetString("OPER"),
                                                    sTmpResID,
                                                    'E',
                                                    "",
                                                    ref port_in,
                                                    ref crr_in);

                if (frmChangePortCarrier.ShowDialog(this) != DialogResult.OK) return false;

                if (frmChangePortCarrier.IsDisposed == false)
                    frmChangePortCarrier.Dispose();
            }
            else if (spdResource.ActiveSheet.RowCount > 1)
            {
                if (MPGO.ChangePortStateWithLotTran() == true && MPCF.Trim(spdResource.ActiveSheet.GetValue(0, (int)RES_COL.RES_ID)) != "")
                {
                    if (MPCR.CheckResourceHavePort(MPCF.Trim(spdResource.ActiveSheet.GetValue(0, (int)RES_COL.RES_ID)), ref b_have_port) == false)
                    {
                        return false;
                    }
                }

                //------------------------------------------------------
                //Change by Kelly Jung 20160304
                //Change Carrier......
                //if (b_have_port == false) return true;
                //frmChangePortCarrierExt = new frmWIPTranChangePortCarrierExt();
                //frmChangePortCarrierExt.SetLayout(ChangePortCarrierLayout.PORT);


                if (b_have_port == false && b_change_carrier == false) return true;

                frmChangePortCarrierExt = new frmWIPTranChangePortCarrierExt();

                if (b_have_port == true && b_change_carrier == true)
                {
                    frmChangePortCarrierExt.SetLayout(ChangePortCarrierLayout.PORT_and_CARRIER);
                    port_in = in_node.AddNode("CHANGE_PORT_STATUS");
                    crr_in = in_node.AddNode("CHANGE_CARRIER");
                }
                else if (b_have_port == true && b_change_carrier == false)
                {
                    frmChangePortCarrierExt.SetLayout(ChangePortCarrierLayout.PORT);
                    port_in = in_node.AddNode("CHANGE_PORT_STATUS");
                }
                else if (b_have_port == false && b_change_carrier == true)
                {
                    frmChangePortCarrierExt.SetLayout(ChangePortCarrierLayout.CARRIER);
                    crr_in = in_node.AddNode("CHANGE_CARRIER");
                }
                //------------------------------------------------------

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
                                                       'E',
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
            int iResCount = 0;
            double dQty1 = 0;
            double dQty2 = 0;
            double dQty3 = 0;
            double dOutQty1 = 0;

            try
            {
                for (int i = 0; i < spdResource.ActiveSheet.RowCount; i++)
                {
                    if (MPCF.Trim(spdResource.ActiveSheet.GetValue(i, (int)RES_COL.RES_ID)) != "")
                    {
                        iResCount++;
                        dQty1 += MPCF.ToDbl(spdResource.ActiveSheet.GetValue(i, (int)RES_COL.QTY_1));
                        dQty2 += MPCF.ToDbl(spdResource.ActiveSheet.GetValue(i, (int)RES_COL.QTY_2));
                        dQty3 += MPCF.ToDbl(spdResource.ActiveSheet.GetValue(i, (int)RES_COL.QTY_3));
                    }
                }

                dOutQty1 = LOT.GetDouble("QTY_1");
                if (spdCarrierLoss.ActiveSheet.RowCount > 0)
                {
                    dOutQty1 = MPCF.ToDbl(spdCarrierLoss.ActiveSheet.Cells[spdCarrierLoss.ActiveSheet.RowCount - 1, 4].Value);
                }

                txtResCount.Text = iResCount.ToString();
                txtTotalQty1.Text = String.Format("{0:#,##0.###}/{1:#,##0.###},{2:#,##0.###}", dQty1, dOutQty1, dOutQty1 - dQty1);
                txtTotalQty2.Text = String.Format("{0:#,##0.###}/{1:#,##0.###},{2:#,##0.###}", dQty2, LOT.GetDouble("QTY_2"), LOT.GetDouble("QTY_2") - dQty2);
                txtTotalQty3.Text = String.Format("{0:#,##0.###}/{1:#,##0.###},{2:#,##0.###}", dQty3, LOT.GetDouble("QTY_3"), LOT.GetDouble("QTY_3") - dQty3);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        /*** End of Modification (2012.04.09) ***/

        /*** Carrier and Loss Logic (2012.04.17 by Aiden.Koo) ***/
        private bool ViewCarrierLotList()
        {
            int i;
            int i_row;

            TRSNode in_node = new TRSNode("VIEW_CARRIER_LOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_CARRIER_LOT_LIST_OUT");
            List<TRSNode> l_crr_list;

            try
            {
                MPCF.ClearList(spdCarrierLoss);
                spdCarrierLoss.ActiveSheet.ColumnCount = 5;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("LOT_ID", LOT.GetString("LOT_ID"));

                do
                {
                    if (MPCR.CallService("RAS", "RAS_View_Carrier_Lot_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    l_crr_list = out_node.GetList(0);
                    for (i = 0; i < l_crr_list.Count; i++)
                    {
                        i_row = spdCarrierLoss.ActiveSheet.RowCount;
                        spdCarrierLoss.ActiveSheet.RowCount++;

                        spdCarrierLoss.ActiveSheet.Cells[i_row, 0].Value = l_crr_list[i].GetString("CRR_ID");
                        spdCarrierLoss.ActiveSheet.Cells[i_row, 1].Value = l_crr_list[i].GetDouble("CRR_LOT_QTY_1");
                        spdCarrierLoss.ActiveSheet.Cells[i_row, 3].Value = l_crr_list[i].GetDouble("CRR_LOT_QTY_1");
                    }

                    in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
                    in_node.SetString("NEXT_CRR_ID", out_node.GetString("NEXT_CRR_ID"));
                } while (out_node.GetString("NEXT_LOT_ID") != "" ||
                         out_node.GetString("NEXT_CRR_ID") != "");

                b_change_carrier = false;

                MPCR.CheckCarrierChangeOption(LOT.GetString("MAT_ID"), LOT.GetInt("MAT_VER"), LOT.GetString("FLOW"), LOT.GetString("OPER"), 'E', ref b_change_carrier);

                if (b_change_carrier == true)
                {
                    spdCarrierLoss.ActiveSheet.Columns[2].Locked = false; spdCarrierLoss.ActiveSheet.Columns[2].BackColor = Color.White;
                }
                else
                {
                    spdCarrierLoss.ActiveSheet.Columns[2].Locked = true; spdCarrierLoss.ActiveSheet.Columns[2].BackColor = Color.Gainsboro;
                }

                if (spdCarrierLoss.ActiveSheet.RowCount > 0)
                {
                    i_row = spdCarrierLoss.ActiveSheet.RowCount;
                    spdCarrierLoss.ActiveSheet.RowCount++;

                    int i_from = i_row * -1;

                    spdCarrierLoss.ActiveSheet.RowHeader.Cells[i_row, 0].Value = "Total";
                    spdCarrierLoss.ActiveSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
                    spdCarrierLoss.ActiveSheet.Cells[i_row, 0].Formula = "ROWS(R[" + i_from.ToString() + "]C:R[-1]C)-COUNTBLANK(R[" + i_from.ToString() + "]C:R[-1]C)";
                    spdCarrierLoss.ActiveSheet.Cells[i_row, 1].Formula = "SUM(R[" + i_from.ToString() + "]C:R[-1]C)";
                    spdCarrierLoss.ActiveSheet.Cells[i_row, 2].Formula = "ROWS(R[" + i_from.ToString() + "]C:R[-1]C)-COUNTBLANK(R[" + i_from.ToString() + "]C:R[-1]C)";
                    spdCarrierLoss.ActiveSheet.Cells[i_row, 3].Formula = "SUM(R[" + i_from.ToString() + "]C:R[-1]C)";
                    spdCarrierLoss.ActiveSheet.Cells[i_row, 4].Formula = "SUM(R[" + i_from.ToString() + "]C:R[-1]C)";
                    spdCarrierLoss.ActiveSheet.Rows[i_row].Locked = true; spdCarrierLoss.ActiveSheet.Cells[i_row, 0, i_row, 4].BackColor = Color.Yellow;
                    spdCarrierLoss.ActiveSheet.Rows[i_row].Font = new Font(spdCarrierLoss.Font, FontStyle.Bold);
                    spdCarrierLoss.ActiveSheet.FrozenTrailingRowCount = 1;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewLossCode()
        {
            TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");
            TRSNode out_node = new TRSNode("VIEW_OPERATION_OUT");
            string s_loss_table;
            int i;
            int i_col;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", LOT.GetString("OPER"));

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return false;
            }

            s_loss_table = "";
            s_loss_table = MPCR.GetExtCodeTable(LOT.GetString("LOT_ID"), MPGC.MP_MFO_EXT_LOSS_TBL_DEF);
            if (s_loss_table == "")
            {
                s_loss_table = out_node.GetString("LOSS_TBL");
            }

            if (s_loss_table != "")
            {
                if (m_lis_loss_code != null)
                {
                    m_lis_loss_code.Items.Clear();
                }
                else
                {
                    m_lis_loss_code = new ListView();
                    m_lis_loss_code.Columns.Add("Loss Code");             // 0
                    m_lis_loss_code.Columns.Add("Desc");                  // 1
                    m_lis_loss_code.Columns.Add("Reusable Type");         // 2
                }

                MPCF.InitListView(m_lis_loss_code);

                if (BASLIST.ViewGCMDataList(m_lis_loss_code, '1', s_loss_table) == false)
                {
                    return false;
                }

                for (i = 0; i < m_lis_loss_code.Items.Count; i++)
                {
                    i_col = spdCarrierLoss.ActiveSheet.ColumnCount;
                    spdCarrierLoss.ActiveSheet.ColumnCount++;

                    spdCarrierLoss.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = m_lis_loss_code.Items[i].SubItems[0].Text; // Code
                    spdCarrierLoss.ActiveSheet.Columns[i_col].Tag = m_lis_loss_code.Items[i];

                    if (MPCF.Trim(m_lis_loss_code.Items[i].SubItems[2].Text) == LOSS_REUSABLE_TYPE_NO_SCRAP)
                    {
                        spdCarrierLoss.ActiveSheet.Columns[i_col].BackColor = Color.LightBlue;
                    }
                }
            }

            if (spdCarrierLoss.ActiveSheet.ColumnCount > 5)
            {
                int i_rej_col;
                int i_rej_col_idx;
                StringBuilder sb_rej_col;
                ListViewItem reject_item;

                sb_rej_col = new StringBuilder();
                for (i_rej_col = 5; i_rej_col < spdCarrierLoss.ActiveSheet.ColumnCount; i_rej_col++)
                {
                    reject_item = (ListViewItem)spdCarrierLoss.ActiveSheet.Columns[i_rej_col].Tag;
                    if (reject_item != null && 
                        (MPCF.Trim(reject_item.SubItems[2].Text) == LOSS_REUSABLE_TYPE_SCRAP || MPCF.Trim(reject_item.SubItems[2].Text) == ""))
                    {
                        if (sb_rej_col.ToString() != "")
                        {
                            sb_rej_col.Append(",");
                        }

                        i_rej_col_idx = i_rej_col - 4;
                        sb_rej_col.Append("RC[" + i_rej_col_idx.ToString() + "]");
                    }
                }

                i_col = spdCarrierLoss.ActiveSheet.ColumnCount;
                spdCarrierLoss.ActiveSheet.ColumnCount++;
                spdCarrierLoss.ActiveSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
                spdCarrierLoss.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = "Total";

                int i_from = (i_col - 5) * -1;

                for (i = 0; i < spdCarrierLoss.ActiveSheet.RowCount - 1; i++)
                {
                    spdCarrierLoss.ActiveSheet.Cells[i, 4].Formula = "RC[-1]-(SUM(" + sb_rej_col.ToString() + "))";
                    spdCarrierLoss.ActiveSheet.Cells[i, i_col].Formula = "SUM(RC[" + i_from.ToString() + "]:RC[-1])";
                }

                spdCarrierLoss.ActiveSheet.Columns[i_col].Locked = true;
                spdCarrierLoss.ActiveSheet.Columns[i_col].BackColor = Color.Yellow;
                spdCarrierLoss.ActiveSheet.Columns[i_col].Font = new Font(spdCarrierLoss.Font, FontStyle.Bold);
                spdCarrierLoss.ActiveSheet.FrozenTrailingColumnCount = 1;

                if (spdCarrierLoss.ActiveSheet.RowCount > 0)
                {
                    i = spdCarrierLoss.ActiveSheet.RowCount - 1;
                    i_from = i * -1;

                    for (i_col = 5; i_col < spdCarrierLoss.ActiveSheet.ColumnCount; i_col++)
                    {
                        spdCarrierLoss.ActiveSheet.Cells[i, i_col].Formula = "SUM(R[" + i_from.ToString() + "]C:R[-1]C)";
                    }
                    spdCarrierLoss.ActiveSheet.Cells[i, 5, i, i_col - 1].BackColor = Color.PaleGreen;
                }
            }

            MPCF.FitColumnHeader(spdCarrierLoss);

            return true;
        }

        private bool ViewCarrier(string s_crr_id)
        {
            TRSNode in_node = new TRSNode("View_Carrier_In");
            TRSNode out_node = new TRSNode("View_Carrier_Out");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CRR_ID", s_crr_id);

                if (MPCR.CallService("RAS", "RAS_View_Carrier", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetString("LOT_ID") != "")
                {
                    if (out_node.GetString("LOT_ID") != LOT.GetString("LOT_ID"))
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(328) + "\n[" + out_node.GetString("LOT_ID") + "]");
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

        private bool SetChangeCarrierInfor(TRSNode in_node)
        {
            TRSNode attach_crr_in = null;
            TRSNode detach_crr_in = null;

            bool b_change_crr_flag;
            string s_crr_id;
            string s_new_crr_id;
            int i_crr_qty;
            int i_new_crr_qty;
            int i;

            if (b_change_carrier == false)
            {
                for (i = 0; i < spdCarrierLoss.ActiveSheet.RowCount - 1; i++)
                {
                    i_crr_qty = MPCF.ToInt(spdCarrierLoss.ActiveSheet.Cells[i, 1].Value);
                    i_new_crr_qty = MPCF.ToInt(spdCarrierLoss.ActiveSheet.Cells[i, 4].Value);

                    if (i_crr_qty != i_new_crr_qty) break;
                }
                if (i >= spdCarrierLoss.ActiveSheet.RowCount - 1) return true;
            }

            b_change_crr_flag = false;

            for (i = 0; i < spdCarrierLoss.ActiveSheet.RowCount - 1; i++)
            {
                s_crr_id = MPCF.Trim(spdCarrierLoss.ActiveSheet.Cells[i, 0].Value);
                i_crr_qty = MPCF.ToInt(spdCarrierLoss.ActiveSheet.Cells[i, 1].Value);
                s_new_crr_id = MPCF.Trim(spdCarrierLoss.ActiveSheet.Cells[i, 2].Value);
                i_new_crr_qty = MPCF.ToInt(spdCarrierLoss.ActiveSheet.Cells[i, 4].Value);

                if (s_crr_id == "" && s_new_crr_id != "" && i_new_crr_qty > 0)
                {
                    attach_crr_in = in_node.AddNode("ATTACH_CARRIER");

                    MPCR.SetInMsg(attach_crr_in);
                    attach_crr_in.ProcStep = '1';

                    attach_crr_in.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                    attach_crr_in.AddString("FROM_CRR_ID", s_crr_id);
                    attach_crr_in.AddString("NEW_CRR_ID", s_new_crr_id);
                    attach_crr_in.AddDouble("QTY_1", i_new_crr_qty);

                    b_change_crr_flag = true;
                }
                else if (s_crr_id != "" && i_crr_qty > 0 && i_new_crr_qty < 1)
                {
                    detach_crr_in = in_node.AddNode("DETACH_CARRIER");

                    MPCR.SetInMsg(detach_crr_in);
                    detach_crr_in.ProcStep = '1';

                    detach_crr_in.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                    detach_crr_in.AddString("CRR_ID", s_crr_id);
                    detach_crr_in.AddDouble("QTY_1", i_crr_qty);

                    b_change_crr_flag = true;
                }
                else if (s_crr_id != "" && s_new_crr_id != "" && s_crr_id != s_new_crr_id)
                {
                    detach_crr_in = in_node.AddNode("DETACH_CARRIER");

                    MPCR.SetInMsg(detach_crr_in);
                    detach_crr_in.ProcStep = '1';

                    detach_crr_in.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                    detach_crr_in.AddString("CRR_ID", s_crr_id);
                    detach_crr_in.AddDouble("QTY_1", i_crr_qty);

                    attach_crr_in = in_node.AddNode("ATTACH_CARRIER");

                    MPCR.SetInMsg(attach_crr_in);
                    attach_crr_in.ProcStep = '1';

                    attach_crr_in.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                    attach_crr_in.AddString("FROM_CRR_ID", s_crr_id);
                    attach_crr_in.AddString("NEW_CRR_ID", s_new_crr_id);
                    attach_crr_in.AddDouble("QTY_1", i_new_crr_qty);

                    b_change_crr_flag = true;
                }
                else if (((s_new_crr_id != "" && s_crr_id == s_new_crr_id)
                            || (s_new_crr_id == "" && s_crr_id != ""))
                        && i_crr_qty != i_new_crr_qty)
                {
                    if (i_crr_qty < i_new_crr_qty)
                    {
                        attach_crr_in = in_node.AddNode("ATTACH_CARRIER");

                        MPCR.SetInMsg(attach_crr_in);
                        attach_crr_in.ProcStep = '1';

                        if (s_new_crr_id == "" && s_crr_id != "")
                        {
                            s_new_crr_id = s_crr_id;
                        }

                        attach_crr_in.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                        attach_crr_in.AddString("FROM_CRR_ID", s_crr_id);
                        attach_crr_in.AddString("NEW_CRR_ID", s_new_crr_id);
                        attach_crr_in.AddDouble("QTY_1", i_new_crr_qty - i_crr_qty);
                    }
                    else
                    {
                        detach_crr_in = in_node.AddNode("DETACH_CARRIER");

                        MPCR.SetInMsg(detach_crr_in);
                        detach_crr_in.ProcStep = '1';

                        detach_crr_in.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                        detach_crr_in.AddString("CRR_ID", s_crr_id);
                        detach_crr_in.AddDouble("QTY_1", i_crr_qty - i_new_crr_qty);
                    }

                    b_change_crr_flag = true;
                }
            }

            if (b_change_crr_flag == true)
            {
                if (ChangeCarrierSeq(in_node) == false) return false;
            }

            return true;
        }

        private bool ChangeCarrierSeq(TRSNode in_node)
        {
            int i;
            int i_seq;
            string s_crr_id;
            string s_new_crr_id;
            int i_new_crr_qty;

            TRSNode seq_crr;

            seq_crr = null;

            i_seq = 0;
            for (i = 0; i < spdCarrierLoss.ActiveSheet.RowCount - 1; i++)
            {
                s_crr_id = MPCF.Trim(spdCarrierLoss.ActiveSheet.Cells[i, 0].Value);
                s_new_crr_id = MPCF.Trim(spdCarrierLoss.ActiveSheet.Cells[i, 2].Value);
                i_new_crr_qty = MPCF.ToInt(spdCarrierLoss.ActiveSheet.Cells[i, 4].Value);

                if (i_new_crr_qty > 0)
                {
                    if (s_new_crr_id == "" && s_crr_id != "")
                    {
                        s_new_crr_id = s_crr_id;
                    }

                    if (s_new_crr_id != "")
                    {
                        i_seq++;
                        seq_crr = in_node.AddNode("CARRIER_SEQ");
                        seq_crr.AddString("CRR_ID", s_new_crr_id);
                        seq_crr.AddInt("CRR_SEQ", i_seq);
                    }
                }
            }

            return true;
        }

        private bool SetLossInfor(TRSNode in_node)
        {
            TRSNode loss_item;
            TRSNode loss_in;

            string s_code;
            string s_cate;
            double d_qty;
            double d_out_qty;
            int i;

            ListViewItem reject_item;

            if (spdCarrierLoss.ActiveSheet.ColumnCount < 6) return true;
            if (spdCarrierLoss.ActiveSheet.RowCount < 1) return true;
            if (MPCF.ToInt(spdCarrierLoss.ActiveSheet.Cells[spdCarrierLoss.ActiveSheet.RowCount - 1, spdCarrierLoss.ActiveSheet.ColumnCount - 1].Value) < 1) return true;

            loss_in = in_node.AddNode("LOSS_LOT");

            MPCR.SetInMsg(loss_in);
            loss_in.ProcStep = '1';

            d_out_qty = LOT.GetDouble("QTY_1");

            loss_in.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
            loss_in.AddString("RES_ID", GetResID());

            for (i = 5; i < spdCarrierLoss.ActiveSheet.ColumnCount - 1; i++)
            {
                reject_item = (ListViewItem)spdCarrierLoss.ActiveSheet.Columns[i].Tag;

                //("Reject Code");           // 0
                //("Desc");                  // 1
                //("Reusable Type");         // 2

                s_code = reject_item.SubItems[0].Text;
                s_cate = reject_item.SubItems[2].Text;

                d_qty = MPCF.ToDbl(spdCarrierLoss.ActiveSheet.Cells[spdCarrierLoss.ActiveSheet.RowCount - 1, i].Value);

                if (s_code != "" && d_qty != 0)
                {
                    loss_item = loss_in.AddNode("UNIT1");

                    loss_item.AddString("CODE", s_code);
                    loss_item.AddDouble("QTY", d_qty);

                    if (s_cate == LOSS_REUSABLE_TYPE_NO_SCRAP)
                    {
                        loss_item.AddChar("NO_SCRAP_FLAG", 'Y');
                    }
                    else
                    {
                        d_out_qty -= d_qty;
                    }
                }
            }

            loss_in.AddDouble("OUT_QTY_1", d_out_qty);
            loss_in.AddDouble("OUT_QTY_2", LOT.GetDouble("QTY_2"));
            loss_in.AddDouble("OUT_QTY_3", LOT.GetDouble("QTY_3"));

            return true;
        }

        /*** End of Add (2012.04.17 by Aiden.Koo) ***/

        private bool CollectBinData(ref bool b_proc_end_lot_by_bin_flag, TRSNode end_lot_in)
        {
            if (MPGO.UseBinManagement() == false) return true;
            if (MPCR.IsBinCollectionOper(txtLotID.Text) == false) return true;

            MPGV.gsCurrentLot_ID = txtLotID.Text;
            frmWIPTranCollectBinData f = new frmWIPTranCollectBinData();
            f.Width = this.Width;
            f.Height = this.Height;
            f.SetPopupAction(true, end_lot_in);
            f.StartPosition = FormStartPosition.CenterParent;

            if (f.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
            {
                return false;
            }

            if (MPGV.gtBinLot.low_yield_flag == true) return false;

            b_proc_end_lot_by_bin_flag = true;

            return true;
        }

        #endregion

        private void frmWIPTranEndLotExt2_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    base.SetInputValuePoint(MESCore.Controls.INPUT_VALUE_POINT.END);

                    /*** #987 Multi Resource (2012.04.09 by JYPARK) ***/
                    MPCF.ClearList(spdResource);
                    /*** End of Add (2012.04.09) ***/

                    /*** Carrier and Loss Logic (2012.04.17 by Aiden.Koo) ***/
                    MPCF.ClearList(spdCarrierLoss);
                    /*** End of Add (2012.04.17 by Aiden.Koo) ***/

                    SetCMFItem(MPGC.MP_CMF_TRN_END);
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
                            ViewResource(sResourceID, spdResource, 0);
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

        private void cdvToFlow_FlowButtonPress(object sender, EventArgs e)
        {
            cdvToFlow.ListCond_Step = '1';
            cdvToFlow.ListCond_MatID = "";
            cdvToFlow.ListCond_MatVersion = 0;
        }

        private void cdvToFlow_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvToOperation.Text = "";
            if (MPCF.Trim(cdvToFlow.Text) != "")
            {
                cdvToFlow.ListCond_Step = '2';
                cdvToFlow.ListCond_MatID = LOT.GetString("MAT_ID");
                cdvToFlow.ListCond_MatVersion = LOT.GetInt("MAT_VER");
            }
        }

        private void cdvReturnFlow_FlowButtonPress(object sender, EventArgs e)
        {
            cdvReturnFlow.ListCond_Step = '1';
            cdvReturnFlow.ListCond_MatID = "";
            cdvReturnFlow.ListCond_MatVersion = 0;
        }

        private void cdvRetFlow_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            cdvRetOperation.Text = "";
            if (MPCF.Trim(cdvReturnFlow.Text) != "")
            {
                cdvReturnFlow.ListCond_Step = '2';
                cdvReturnFlow.ListCond_MatID = LOT.GetString("MAT_ID");
                cdvReturnFlow.ListCond_MatVersion = LOT.GetInt("MAT_VER");
            }

        }

        private void cdvToOperation_ButtonPress(System.Object sender, System.EventArgs e)
        {
            if (cdvToFlow.Text.Trim() == "" && LOT.GetString("FLOW").Trim() == "")
            {
                cdvToOperation.Init();
                cdvToOperation.Text = "";
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvToFlow.Focus();
                return;
            }

            if (cdvToFlow.Text.Trim() == "")
            {
                if (GetToOperationList(LOT.GetString("FLOW")) == false)
                {
                    return;
                }
            }
            else
            {
                if (GetToOperationList(cdvToFlow.Text) == false)
                {
                    return;
                }
            }
        }

        private void cdvRetOperation_ButtonPress(System.Object sender, System.EventArgs e)
        {

            if (cdvReturnFlow.CheckValue() == false) return;

            if (GetRetOperationList(cdvReturnFlow.Text) == false)
            {
                return;
            }

        }

        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (CheckCondition() == true)
                {
                    string s_res_id = "";
                    if (spdResource.ActiveSheet.RowCount > 0)
                    {
                        s_res_id = MPCF.Trim(spdResource.ActiveSheet.Cells[0, (int)RES_COL.RES_ID].Value);
                    }

                    if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_END, LOT.GetString("LOT_ID"), s_res_id, "END_LOT", 'B') == false) return;
                    if (EndLot('1') == false) return;
                    if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_END, LOT.GetString("LOT_ID"), s_res_id, "END_LOT", 'A') == false) return;

                    ViewLotInfo(txtLotID.Text);
                }
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

                    cdvResIDSP.Init();
                    cdvResIDSP.ViewPosition = Control.MousePosition;
                    MPCF.InitListView(cdvResIDSP.GetListView);
                    cdvResIDSP.Columns.Add("Resource", 150, HorizontalAlignment.Left);
                    cdvResIDSP.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                    RASLIST.ViewResourceList(cdvResIDSP.GetListView, LOT.GetString("MAT_ID"), LOT.GetInt("MAT_VER"), LOT.GetString("FLOW"), LOT.GetString("OPER"), false);
                    cdvResIDSP.InsertEmptyRow(0, 1);
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
                        if (MPCF.Trim(spdResource.ActiveSheet.Cells[e.Row, (int)RES_COL.RES_ID].Value) != "")
                        {
                            spdResource.ActiveSheet.RowCount++;
                        }
                    }
                    else
                    {
                        spdResource.ActiveSheet.Cells[e.Row, (int)RES_COL.RES_ID].Value = "";
                        spdResource.ActiveSheet.Cells[e.Row, (int)RES_COL.RES_DESC, e.Row, (int)RES_COL.PRIMARY_STATUS].Value = "";
                        CalculateTotal();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        /*** End of Add (2012.04.09) ***/

        /*** Carrier and Loss Logic (2012.04.17 by Aiden.Koo) ***/
        private void spdCarrierLoss_EditModeOff(object sender, EventArgs e)
        {
            int i_col, i_row;
            int i_qty;
            int i;
            string s_crr_id;
            bool b_move_next;

            i_col = spdCarrierLoss.ActiveSheet.ActiveColumnIndex;
            i_row = spdCarrierLoss.ActiveSheet.ActiveRowIndex;

            b_move_next = false;

            if (i_col == 2)
            {
                s_crr_id = MPCF.Trim(spdCarrierLoss.ActiveSheet.Cells[i_row, i_col].Value);

                if (s_crr_id != "")
                {
                    for (i = 0; i < spdCarrierLoss.ActiveSheet.RowCount - 1; i++)
                    {
                        if (i == i_row) continue;

                        if (s_crr_id == MPCF.Trim(spdCarrierLoss.ActiveSheet.Cells[i, i_col].Value))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(322));
                            spdCarrierLoss.ActiveSheet.Cells[i_row, i_col].Value = null;
                            return;
                        }
                    }

                    if (ViewCarrier(s_crr_id) == false)
                    {
                        spdCarrierLoss.ActiveSheet.Cells[i_row, i_col].Value = null;
                        return;
                    }

                    b_move_next = true;
                }
            }
            else if (i_col == 3)
            {
                i_qty = MPCF.ToInt(spdCarrierLoss.ActiveSheet.Cells[i_row, i_col].Value);
                if (i_qty > MAX_CARRIER_SLOT_NO)
                {
                    spdCarrierLoss.ActiveSheet.Cells[i_row, i_col].Value = 0;
                    return;
                }

                i_qty = MPCF.ToInt(spdCarrierLoss.ActiveSheet.Cells[spdCarrierLoss.ActiveSheet.RowCount - 1, 3].Value);
                if (i_qty > MPCF.ToInt(spdCarrierLoss.ActiveSheet.Cells[spdCarrierLoss.ActiveSheet.RowCount - 1, 1].Value))
                {
                    spdCarrierLoss.ActiveSheet.Cells[i_row, i_col].Value = 0;
                    return;
                }

                CalculateTotal();

                b_move_next = true;
            }
            else if (i_col > 4)
            {
                i_qty = MPCF.ToInt(spdCarrierLoss.ActiveSheet.Cells[i_row, i_col].Value);
                if (i_qty > MAX_CARRIER_SLOT_NO)
                {
                    spdCarrierLoss.ActiveSheet.Cells[i_row, i_col].Value = 0;
                    return;
                }

                i_qty = MPCF.ToInt(spdCarrierLoss.ActiveSheet.Cells[i_row, 4].Value);
                if (i_qty < 0)
                {
                    spdCarrierLoss.ActiveSheet.Cells[i_row, i_col].Value = 0;
                    return;
                }

                CalculateTotal();

                b_move_next = true;
            }

            if (i_col < 5)
            {
                if (b_move_next == true && i_row < spdCarrierLoss.ActiveSheet.RowCount - 2)
                {
                    spdCarrierLoss.ActiveSheet.SetActiveCell(i_row + 1, i_col);
                }
            }
            if (i_col > 4)
            {
                if (b_move_next == true && i_col < spdCarrierLoss.ActiveSheet.ColumnCount - 2)
                {
                    spdCarrierLoss.ActiveSheet.SetActiveCell(i_row, i_col + 1);
                }
            }
        }

        private void btnAddCarrier_Click(object sender, EventArgs e)
        {
            int i_row;
            int i_col;
            int i_from;

            if (spdCarrierLoss.ActiveSheet.RowCount < 2) return;

            i_row = spdCarrierLoss.ActiveSheet.RowCount - 1;
            spdCarrierLoss.ActiveSheet.Rows.Add(i_row, 1);
            spdCarrierLoss.ActiveSheet.Rows[i_row].Tag = "A";

            if (spdCarrierLoss.ActiveSheet.Columns[2].Locked == true)
            {
                if (b_change_carrier == false) b_change_carrier = true;
                spdCarrierLoss.ActiveSheet.Cells[i_row, 2].BackColor = Color.White;
                spdCarrierLoss.ActiveSheet.Cells[i_row, 2].Locked = false;
            }

            i_row++;
            i_from = i_row * -1;

            spdCarrierLoss.ActiveSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdCarrierLoss.ActiveSheet.Cells[i_row, 0].Formula = "ROWS(R[" + i_from.ToString() + "]C:R[-1]C)-COUNTBLANK(R[" + i_from.ToString() + "]C:R[-1]C)";
            spdCarrierLoss.ActiveSheet.Cells[i_row, 1].Formula = "SUM(R[" + i_from.ToString() + "]C:R[-1]C)";
            spdCarrierLoss.ActiveSheet.Cells[i_row, 2].Formula = "ROWS(R[" + i_from.ToString() + "]C:R[-1]C)-COUNTBLANK(R[" + i_from.ToString() + "]C:R[-1]C)";
            spdCarrierLoss.ActiveSheet.Cells[i_row, 3].Formula = "SUM(R[" + i_from.ToString() + "]C:R[-1]C)";
            spdCarrierLoss.ActiveSheet.Cells[i_row, 4].Formula = "SUM(R[" + i_from.ToString() + "]C:R[-1]C)";

            if (spdCarrierLoss.ActiveSheet.ColumnCount > 5)
            {
                int i_loss_col;
                int i_loss_col_idx;
                StringBuilder sb_loss_col;
                ListViewItem loss_item;

                sb_loss_col = new StringBuilder();
                for (i_loss_col = 5; i_loss_col < spdCarrierLoss.ActiveSheet.ColumnCount - 1; i_loss_col++)
                {
                    loss_item = (ListViewItem)spdCarrierLoss.ActiveSheet.Columns[i_loss_col].Tag;
                    if (loss_item != null && 
                        (MPCF.Trim(loss_item.SubItems[2].Text) == LOSS_REUSABLE_TYPE_SCRAP || MPCF.Trim(loss_item.SubItems[2].Text) == ""))
                    {
                        if (sb_loss_col.ToString() != "")
                        {
                            sb_loss_col.Append(",");
                        }

                        i_loss_col_idx = i_loss_col - 4;
                        sb_loss_col.Append("RC[" + i_loss_col_idx.ToString() + "]");
                    }
                }

                i_col = spdCarrierLoss.ActiveSheet.ColumnCount - 1;
                i_from = (i_col - 5) * -1;

                spdCarrierLoss.ActiveSheet.Cells[i_row - 1, 4].Formula = "RC[-1]-(SUM(" + sb_loss_col.ToString() + "))";
                spdCarrierLoss.ActiveSheet.Cells[i_row - 1, i_col].Formula = "SUM(RC[" + i_from.ToString() + "]:RC[-1])";

                if (spdCarrierLoss.ActiveSheet.RowCount > 0)
                {
                    i_from = i_row * -1;

                    for (i_col = 5; i_col < spdCarrierLoss.ActiveSheet.ColumnCount; i_col++)
                    {
                        spdCarrierLoss.ActiveSheet.Cells[i_row, i_col].Formula = "SUM(R[" + i_from.ToString() + "]C:R[-1]C)";
                    }
                }
            }

        }

        private void btnDelCarrier_Click(object sender, EventArgs e)
        {
            int i_row;
            int i_col;
            int i_from;

            if (spdCarrierLoss.ActiveSheet.RowCount < 2) return;

            i_row = spdCarrierLoss.ActiveSheet.RowCount - 2;
            if (MPCF.Trim(spdCarrierLoss.ActiveSheet.Rows[i_row].Tag) != "A") return;

            spdCarrierLoss.ActiveSheet.Rows[i_row].Remove();

            i_from = i_row * -1;

            spdCarrierLoss.ActiveSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdCarrierLoss.ActiveSheet.Cells[i_row, 0].Formula = "ROWS(R[" + i_from.ToString() + "]C:R[-1]C)-COUNTBLANK(R[" + i_from.ToString() + "]C:R[-1]C)";
            spdCarrierLoss.ActiveSheet.Cells[i_row, 1].Formula = "SUM(R[" + i_from.ToString() + "]C:R[-1]C)";
            spdCarrierLoss.ActiveSheet.Cells[i_row, 2].Formula = "ROWS(R[" + i_from.ToString() + "]C:R[-1]C)-COUNTBLANK(R[" + i_from.ToString() + "]C:R[-1]C)";
            spdCarrierLoss.ActiveSheet.Cells[i_row, 3].Formula = "SUM(R[" + i_from.ToString() + "]C:R[-1]C)";
            spdCarrierLoss.ActiveSheet.Cells[i_row, 4].Formula = "SUM(R[" + i_from.ToString() + "]C:R[-1]C)";

            if (spdCarrierLoss.ActiveSheet.ColumnCount > 5)
            {
                if (spdCarrierLoss.ActiveSheet.RowCount > 0)
                {
                    i_from = i_row * -1;

                    for (i_col = 5; i_col < spdCarrierLoss.ActiveSheet.ColumnCount; i_col++)
                    {
                        spdCarrierLoss.ActiveSheet.Cells[i_row, i_col].Formula = "SUM(R[" + i_from.ToString() + "]C:R[-1]C)";
                    }
                }
            }

            i_row -= 1;
            if (MPCF.Trim(spdCarrierLoss.ActiveSheet.Rows[i_row].Tag) != "A"
                && spdCarrierLoss.ActiveSheet.Columns[2].Locked == true)
            {
                if (b_change_carrier == true) b_change_carrier = false;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string sCond;

            if (spdCarrierLoss.ActiveSheet.RowCount > 0)
            {
                sCond = "Lot ID : " + MPCF.Trim(txtLotID.Text) + "\r";

                if (MPCF.ExportToExcel(spdCarrierLoss, this.Text, sCond, true, true, true, -1, -1) == false)
                {
                    return;
                }
            }
        }
        
        /*** End of Add (2012.04.17 by Aiden.Koo) ***/

    }
}
