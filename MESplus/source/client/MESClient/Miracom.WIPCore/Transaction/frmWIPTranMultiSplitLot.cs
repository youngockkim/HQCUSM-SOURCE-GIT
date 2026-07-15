//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranMultiSplitLot.cs
//   Description : Multi Split Lot Transaction
//
//   MES Version : 5.2.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - GetResourceIDList() :Get ResourceID List
//       - End_Lot() : Start Lot transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2012-04-06 : Created by DMKIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
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
    public partial class frmWIPTranMultiSplitLot : Miracom.MESCore.TranForm23
    {
        public frmWIPTranMultiSplitLot()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private const int COL_CHILD_LOT_ID = 0;
        private const int COL_QTY_1 = 1;
        private const int COL_QTY_2 = 2;
        private const int COL_QTY_3 = 3;
        private const int COL_CARRIER_ID = 4;

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;

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
            MPCF.FieldClear(this, txtLotID, cboPriority);
            MPCF.ClearList(spdChildLotList);
            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }

            SetLotCMFInfo();
            txtLotDesc.Text = LOT.GetString("LOT_DESC");

            cboPriority.SelectedIndex = 4;

            cdvCreateCode.Text = LOT.GetString("CREATE_CODE");
            cdvOwnerCode.Text = LOT.GetString("OWNER_CODE");
            cdvLotType.Text = LOT.GetChar("LOT_TYPE").ToString();
            chkDueDate.Checked = true;

            if (MPCF.Trim(LOT.GetString("SCH_DUE_TIME")) == "")
            {
                this.dtpDueDate.Value = DateTime.Today;
            }
            else
            {
                this.dtpDueDate.Value = MPCF.ToDate(LOT.GetString("SCH_DUE_TIME"));
            }

            if (MPGO.ProcessZeroQtyLot() == true)
                chkNoAutoTermLot.Checked = true;

            chkGenID.Checked = true;

#if _CRR
            cdvCrrID.Init();
            cdvCrrID.Columns.Add("Carrier ID", 50, HorizontalAlignment.Left);
            cdvCrrID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrID.SelectedSubItemIndex = 0;
            if (RASLIST.ViewCarrierList(cdvCrrID.GetListView, txtLotID.Text) == false)
            {
                txtLotID.Focus();
                return false;
            }
#endif
            return true;
        }

        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2", "3")
        //
        private void ClearData(string ProcStep)
        {
            try
            {
                switch (ProcStep)
                {
                    case "1":

                        //Initialize
                        MPCF.FieldClear(this);
                        MPCF.ClearList(spdChildLotList);
                        cboPriority.SelectedIndex = 4;
                        txtDueDate.Visible = !chkDueDate.Checked;
                        break;

                    case "3":

                        MPCF.FieldClear(this, txtLotID);
                        MPCF.ClearList(spdChildLotList);
                        cboPriority.SelectedIndex = 4;
                        if (base.ViewLotInfo(txtLotID.Text) == false)
                        {
                            txtLotID.Focus();
                            return;
                        }
                        break;
                    case "4":

                        MPCF.FieldClear(this, txtLotID);
                        MPCF.ClearList(spdChildLotList);
                        cboPriority.SelectedIndex = 4;
                        txtDueDate.Visible = !chkDueDate.Checked;
                        break;

                    case "5":
                        MPCF.FieldClear(this, txtLotID);
                        cboPriority.SelectedIndex = 4;
                        txtDueDate.Visible = !chkDueDate.Checked;
                        break;

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
        private bool CheckCondition(string FuncName, char c_step)
        {
            string sQtyChk = "";
            int iCount = 0;
            int i = 0;
            FarPoint.Win.Spread.SheetView lotlist = spdChildLotList.ActiveSheet;

            switch (MPCF.Trim(FuncName))
            {

                case "MULTI_SPLIT_LOT":

                    if (MPCF.CheckValue(txtLotID, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                        txtLotID.Focus();
                        return false;
                    }
                    //if (MPCF.Trim(LOT.GetString("FLOW")) == "")
                    //{
                    //    tabTran.SelectedTab = tbpGeneral;
                    //    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Flow]");
                    //    txtLotID.Focus();
                    //    return false;
                    //}
                    if (MPCF.Trim(LOT.GetString("OPER")) == "")
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                        txtLotID.Focus();
                        return false;
                    }
                    //if (c_step == '1')
                    //{
                    //    if (MPCF.CheckValue(txtChildLotID, 1) == false)
                    //    {
                    //        tabTran.SelectedTab = tbpGeneral;
                    //        txtChildLotID.Focus();
                    //        return false;
                    //    }
                    //}
                    //if (cdvMatID.CheckValue() == false)
                    //{
                    //    tabTran.SelectedTab = tbpGeneral;
                    //    cdvMatID.Focus();
                    //    return false;
                    //}
                    if (MPCF.CheckValue(cdvCreateCode, 1) == false)
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        cdvCreateCode.Focus();
                        return false;
                    }
                    if (MPCF.CheckValue(cdvOwnerCode, 1) == false)
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        cdvOwnerCode.Focus();
                        return false;
                    }

                    if (c_step == '2')
                    {
                        return true;
                    }

                    iCount = lotlist.RowCount;
                    if (iCount == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(199));
                        tabTran.SelectedTab = tbpGeneral;
                        return false;
                    }

                    for (i = 0; i < lotlist.RowCount - 1; i++)
                    {
                        // Generate Child Lot ID In Server
                        if (chkGenID.Checked != true)
                        {
                            if (MPCF.Trim(lotlist.Cells[i, COL_CHILD_LOT_ID].Value) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(187));
                                tabTran.SelectedTab = tbpGeneral;
                                lotlist.ActiveRowIndex = i;
                                return false;
                            }
                        }

                        if (MPCF.Trim(lotlist.Cells[i, COL_QTY_1].Value) == "" || MPCF.ToDbl(lotlist.Cells[i, COL_QTY_1].Value) == 0)
                        {
                            if (MPGO.ProcessZeroQtyLot() == true)
                            {
                                sQtyChk = "Qty1";
                            }
                            else
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                return false;
                            }

                            if (MPCF.CheckNumeric(MPCF.Trim(lotlist.Cells[i, COL_QTY_1].Value)) == false)
                            {
                                tabTran.SelectedTab = tbpGeneral;
                                lotlist.ActiveRowIndex = i;
                                return false;
                            }
                        }

                        //if (MPCF.Trim(lotlist.Cells[i, COL_QTY_2].Value) == "" || MPCF.ToDbl(lotlist.Cells[i, COL_QTY_2].Value) == 0)
                        //{
                        //    if (MPGO.ProcessZeroQtyLot() == true)
                        //    {
                        //        sQtyChk = "Qty2";
                        //    }
                        //    else
                        //    {
                        //        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        //        return false;
                        //    }

                        //    if (MPCF.CheckNumeric(MPCF.Trim(lotlist.Cells[i, COL_QTY_2].Value)) == false)
                        //    {
                        //        tabTran.SelectedTab = tbpGeneral;
                        //        lotlist.ActiveRowIndex = i;
                        //        return false;
                        //    }
                        //}

                        //if (MPCF.Trim(lotlist.Cells[i, COL_QTY_3].Value) == "" || MPCF.ToDbl(lotlist.Cells[i, COL_QTY_3].Value) == 0)
                        //{
                        //    if (MPGO.ProcessZeroQtyLot() == true)
                        //    {
                        //        sQtyChk = "Qty3";
                        //    }
                        //    else
                        //    {
                        //        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        //        return false;
                        //    }

                        //    if (MPCF.CheckNumeric(MPCF.Trim(lotlist.Cells[i, COL_QTY_3].Value)) == false)
                        //    {
                        //        tabTran.SelectedTab = tbpGeneral;
                        //        lotlist.ActiveRowIndex = i;
                        //        return false;
                        //    }
                        //}

                        if (sQtyChk != "")
                        {
                            if (MPCF.ShowMsgBox(MPCF.GetMessage(190), MessageBoxButtons.YesNo, 1) == System.Windows.Forms.DialogResult.No)
                            {
                                switch (sQtyChk)
                                {
                                    case "Qty1":
                                        tabTran.SelectedTab = tbpGeneral;
                                        lotlist.ActiveRowIndex = i;
                                        break;

                                    //case "Qty2":
                                    //    tabTran.SelectedTab = tbpGeneral;
                                    //    lotlist.ActiveRowIndex = i;
                                    //    break;

                                    //case "Qty3":
                                    //    tabTran.SelectedTab = tbpGeneral;
                                    //    lotlist.ActiveRowIndex = i;
                                    //    break;

                                    default:
                                        break;
                                }
                                return false;
                            }
                        }

                        if (MPCF.Trim(lotlist.Cells[i, COL_QTY_1].Value) != "" && MPCF.Trim(lotlist.Cells[i, COL_QTY_1].Value) != "0")
                        {
                            if (LOT.GetDouble("QTY_1") < MPCF.ToDbl(lotlist.Cells[i, COL_QTY_1].Value))
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(135));
                                tabTran.SelectedTab = tbpGeneral;
                                lotlist.ActiveRowIndex = i;
                                return false;
                            }
                        }
                        //if (MPCF.Trim(lotlist.Cells[i, COL_QTY_2].Value) != "" && MPCF.Trim(lotlist.Cells[i, COL_QTY_2].Value) != "0")
                        //{
                        //    if (LOT.GetDouble("QTY_2") < MPCF.ToDbl(lotlist.Cells[i, COL_QTY_2].Value))
                        //    {
                        //        MPCF.ShowMsgBox(MPCF.GetMessage(135));
                        //        tabTran.SelectedTab = tbpGeneral;
                        //        lotlist.ActiveRowIndex = i;
                        //        return false;
                        //    }
                        //}
                        //if (MPCF.Trim(lotlist.Cells[i, COL_QTY_3].Value) != "" && MPCF.Trim(lotlist.Cells[i, COL_QTY_3].Value) != "0")
                        //{
                        //    if (LOT.GetDouble("QTY_3") < MPCF.ToDbl(lotlist.Cells[i, COL_QTY_3].Value))
                        //    {
                        //        MPCF.ShowMsgBox(MPCF.GetMessage(135));
                        //        tabTran.SelectedTab = tbpGeneral;
                        //        lotlist.ActiveRowIndex = i;
                        //        return false;
                        //    }
                        //}

                    }

                    if (MPGO.AutoCalDueDate() == false)
                    {
                        if (chkDueDate.Checked == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            chkDueDate.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        if (chkDueDate.Checked == false)
                        {
                            if (txtDueDate.Text == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                txtDueDate.Focus();
                                return false;
                            }
                        }
                    }
                    if (MPCF.CheckValue(cdvLotType, 1) == false)
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        cdvLotType.Focus();
                        return false;
                    }

                    if (CheckCMFItemValue() == false)
                    {
                        tabTran.SelectedTab = tbpCMF;
                        return false;
                    }
                    if (MPCR.CheckGRPCMFValue("lblCreateCMF", "cdvCreateCMF", grpCreateCMF) == false)
                    {
                        tabTran.SelectedTab = tbpCreateCMF;
                        return false;
                    }
                    break;

            }

            return true;

        }

        //
        // SetDueDate()
        //       - Due Date Auto Calculation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool SetDueDate()
        {

            double dSumQueueTime = 0;
            double dSumProcTime = 0;
            double dSumQueueProcTime = 0;
            double dQty1 = 0;
            string sMatID;
            int iMatVer;
            string sFlow;
            int iFlowSeq;
            string sOperation;

            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;

            FarPoint.Win.Spread.SheetView lotlist = spdChildLotList.ActiveSheet;

            if (lotlist.RowCount > 0)
            {
                if (MPCF.Trim(lotlist.GetValue(0, COL_QTY_1)) == "")
                {
                    dQty1 = 0;
                }
                else
                {
                    dQty1 = MPCF.ToDbl(lotlist.GetValue(0, COL_QTY_1));
                }
            }
            else
            {
                dQty1 = 0;
            }


            // Chile Lot의 M/F/O는 Mother Lot과 동일하게 가져 간다.
            sMatID = LOT.GetString("MAT_ID");
            iMatVer = LOT.GetInt("MAT_VER");
            sFlow = LOT.GetString("FLOW");
            iFlowSeq = LOT.GetInt("FLOW_SEQ_NUM");
            sOperation = LOT.GetString("OPER");


            if (MPCR.GetProcTime(sMatID, iMatVer, sFlow, iFlowSeq, sOperation, dQty1, ref dSumQueueTime, ref dSumProcTime, ref dSumQueueProcTime) == false)
            {
                txtDueDate.Text = "";
                return false;
            }

            //2006.04.25. CM Koo. CycleTime Unit???곕씪 ?뷀븯???쒓컙 ?⑥쐞瑜??щ━ ?곸슜
            if (MPGO.CycleTimeUnit() == "M")
            {
                dtpDueDate.Value = DateTime.Now.AddMinutes(dSumQueueProcTime);
            }
            else
            {
                dtpDueDate.Value = DateTime.Now.AddHours(dSumQueueProcTime);
            }
            txtDueDate.Text = MPCF.MakeDateFormat(MPCF.ToStandardTime(dtpDueDate.Value, MPGC.MP_CONVERT_DATE_FORMAT), DATE_TIME_FORMAT.DATE);
            return true;
        }

        private bool SetLotCMFInfo()
        {
            try
            {
                cdvCreateCMF1.Text = LOT.GetString("LOT_CMF_1");
                cdvCreateCMF2.Text = LOT.GetString("LOT_CMF_2");
                cdvCreateCMF3.Text = LOT.GetString("LOT_CMF_3");
                cdvCreateCMF4.Text = LOT.GetString("LOT_CMF_4");
                cdvCreateCMF5.Text = LOT.GetString("LOT_CMF_5");
                cdvCreateCMF6.Text = LOT.GetString("LOT_CMF_6");
                cdvCreateCMF7.Text = LOT.GetString("LOT_CMF_7");
                cdvCreateCMF8.Text = LOT.GetString("LOT_CMF_8");
                cdvCreateCMF9.Text = LOT.GetString("LOT_CMF_9");
                cdvCreateCMF10.Text = LOT.GetString("LOT_CMF_10");
                cdvCreateCMF11.Text = LOT.GetString("LOT_CMF_11");
                cdvCreateCMF12.Text = LOT.GetString("LOT_CMF_12");
                cdvCreateCMF13.Text = LOT.GetString("LOT_CMF_13");
                cdvCreateCMF14.Text = LOT.GetString("LOT_CMF_14");
                cdvCreateCMF15.Text = LOT.GetString("LOT_CMF_15");
                cdvCreateCMF16.Text = LOT.GetString("LOT_CMF_16");
                cdvCreateCMF17.Text = LOT.GetString("LOT_CMF_17");
                cdvCreateCMF18.Text = LOT.GetString("LOT_CMF_18");
                cdvCreateCMF19.Text = LOT.GetString("LOT_CMF_19");
                cdvCreateCMF20.Text = LOT.GetString("LOT_CMF_20");
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        //
        // Multi_Split_Lot()
        //       - Split Lot Transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool MultiSplitLot(char ProcStep)
        {

            TRSNode in_node = new TRSNode("MULTI_SPLIT_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode list_item;

            int i = 0;
            bool b_proc_alarm_action;

            FarPoint.Win.Spread.SheetView lotlist = spdChildLotList.ActiveSheet;
            try
            {
                /***** Start Check Transaction Confirm Message *****/
                b_proc_alarm_action = false;
                if (MPCR.CheckTranAlarmRelation(this,
                                                MPGC.MP_ALM_TRAN_SPLIT,
                                                LOT.GetString("MAT_ID"),
                                                LOT.GetInt("MAT_VER"),
                                                LOT.GetString("FLOW"),
                                                LOT.GetString("OPER"),
                                                LOT.GetString("LOT_ID"),
                                                "",
                                                "",
                                                ref b_proc_alarm_action) == false)
                {
                    return false;
                }

                if (b_proc_alarm_action == true)
                    in_node.AddChar("PROC_ALARM_FLAG", 'Y');
                /***** End Check Transaction Confirm Message *****/

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));

                in_node.AddString("CRR_ID", MPCF.Trim(cdvCrrID.Text));

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

                in_node.AddString("LOT_CMF_1", MPCF.Trim(cdvCreateCMF1.Text));
                in_node.AddString("LOT_CMF_2", MPCF.Trim(cdvCreateCMF2.Text));
                in_node.AddString("LOT_CMF_3", MPCF.Trim(cdvCreateCMF3.Text));
                in_node.AddString("LOT_CMF_4", MPCF.Trim(cdvCreateCMF4.Text));
                in_node.AddString("LOT_CMF_5", MPCF.Trim(cdvCreateCMF5.Text));
                in_node.AddString("LOT_CMF_6", MPCF.Trim(cdvCreateCMF6.Text));
                in_node.AddString("LOT_CMF_7", MPCF.Trim(cdvCreateCMF7.Text));
                in_node.AddString("LOT_CMF_8", MPCF.Trim(cdvCreateCMF8.Text));
                in_node.AddString("LOT_CMF_9", MPCF.Trim(cdvCreateCMF9.Text));
                in_node.AddString("LOT_CMF_10", MPCF.Trim(cdvCreateCMF10.Text));
                in_node.AddString("LOT_CMF_11", MPCF.Trim(cdvCreateCMF11.Text));
                in_node.AddString("LOT_CMF_12", MPCF.Trim(cdvCreateCMF12.Text));
                in_node.AddString("LOT_CMF_13", MPCF.Trim(cdvCreateCMF13.Text));
                in_node.AddString("LOT_CMF_14", MPCF.Trim(cdvCreateCMF14.Text));
                in_node.AddString("LOT_CMF_15", MPCF.Trim(cdvCreateCMF15.Text));
                in_node.AddString("LOT_CMF_16", MPCF.Trim(cdvCreateCMF16.Text));
                in_node.AddString("LOT_CMF_17", MPCF.Trim(cdvCreateCMF17.Text));
                in_node.AddString("LOT_CMF_18", MPCF.Trim(cdvCreateCMF18.Text));
                in_node.AddString("LOT_CMF_19", MPCF.Trim(cdvCreateCMF19.Text));
                in_node.AddString("LOT_CMF_20", MPCF.Trim(cdvCreateCMF20.Text));

                in_node.AddString("CHILD_MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("CHILD_MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("CHILD_FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("CHILD_FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("CHILD_OPER", LOT.GetString("OPER"));

                in_node.AddString("CHILD_LOT_DESC", MPCF.Trim(txtChildLotDesc.Text));
                in_node.AddString("CHILD_CREATE_CODE", MPCF.Trim(cdvCreateCode.Text));
                in_node.AddString("CHILD_OWNER_CODE", MPCF.Trim(cdvOwnerCode.Text));
                in_node.AddChar("CHILD_LOT_TYPE", MPCF.ToChar(cdvLotType.Text));
                in_node.AddChar("CHILD_PRIORITY", MPCF.ToChar(cboPriority.Text));

                if (chkGenID.Checked)
                {
                    in_node.AddChar("AUTO_GEN_FLAG", 'Y');
                    in_node.AddChar("REL_LEVEL", '1');
                    in_node.AddString("TRAN_CODE", "SPLIT");
                    in_node.AddString("SEQ_KEY_1", MPCF.Trim(txtLotID.Text));
                }
                else
                {
                    in_node.AddChar("AUTO_GEN_FLAG", 'N');
                }

                for (i = 0; i < lotlist.RowCount - 1; i++)
                {
                    list_item = in_node.AddNode("LOT_LIST");

                    list_item.AddString("CHILD_LOT_ID", MPCF.Trim(lotlist.Cells[i, COL_CHILD_LOT_ID].Value));
                    list_item.AddDouble("MOVE_QTY_1", (MPCF.Trim(lotlist.Cells[i, COL_QTY_1].Value) == "") ? -1 : (MPCF.ToDbl(lotlist.Cells[i, COL_QTY_1].Value)));
                    //list_item.AddDouble("MOVE_QTY_2", (MPCF.Trim(lotlist.Cells[i, COL_QTY_2].Value) == "") ? -1 : (MPCF.ToDbl(lotlist.Cells[i, COL_QTY_2].Value)));
                    //list_item.AddDouble("MOVE_QTY_3", (MPCF.Trim(lotlist.Cells[i, COL_QTY_3].Value) == "") ? -1 : (MPCF.ToDbl(lotlist.Cells[i, COL_QTY_3].Value)));
                    list_item.AddDouble("MOVE_QTY_2", (MPCF.Trim(lotlist.Cells[i, COL_QTY_2].Value) == "") ? 0 : (MPCF.ToDbl(lotlist.Cells[i, COL_QTY_2].Value)));
                    list_item.AddDouble("MOVE_QTY_3", (MPCF.Trim(lotlist.Cells[i, COL_QTY_3].Value) == "") ? 0 : (MPCF.ToDbl(lotlist.Cells[i, COL_QTY_3].Value)));
                    list_item.AddString("CHILD_CRR_ID", MPCF.Trim(lotlist.Cells[i, COL_CARRIER_ID].Value));
                }

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }

                in_node.AddString("CHILD_DUE_TIME", MPCF.ToStandardTime(dtpDueDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));
                in_node.AddChar("NO_AUTOMATIC_TERMINATE_LOT", chkNoAutoTermLot.Checked == true ? 'Y' : ' ');

                if (MPCR.CallService("WIP", "WIP_Multi_Split_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (chkGenID.Checked)
                {
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        lotlist.SetValue(i, COL_CHILD_LOT_ID, MPCF.Trim(out_node.GetList(0)[i].GetString("CHILD_LOT_ID")));
                    }
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

        //
        // Generate_ID()
        //       - Generate Child Lot ID
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //       - iRowIndex As int : Child Lot Row Index
        //
        private bool GenerateID(char ProcStep, int iRowIndex)
        {

            TRSNode in_node = new TRSNode("GENERATE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            FarPoint.Win.Spread.SheetView lotlist = spdChildLotList.Sheets[0];

            try
            {
                MPCR.SetInMsg(in_node);

                in_node.ProcStep = '1';
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                in_node.AddChar("REL_LEVEL", '1');
                in_node.AddString("TRAN_CODE", "SPLIT");
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));

                if (MPCR.CallService("WIP", "WIP_Generate_ID", in_node, ref out_node) == false)
                {
                    return false;
                }

                lotlist.SetValue(iRowIndex, COL_CHILD_LOT_ID, MPCF.Trim(out_node.GetString("GEN_ID")));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool SetAutoQtyInfo(FarPoint.Win.Spread.SheetView spdSheet)
        {
            return SetAutoQtyInfo(spdSheet, 0, 0);
        }

        private bool SetAutoQtyInfo(FarPoint.Win.Spread.SheetView spdSheet, double iDivQty)
        {
            return SetAutoQtyInfo(spdSheet, 0, iDivQty);
        }

        private bool SetAutoQtyInfo(FarPoint.Win.Spread.SheetView spdSheet, int iRowCnt)
        {
            return SetAutoQtyInfo(spdSheet, iRowCnt, 0);
        }

        private bool SetAutoQtyInfo(FarPoint.Win.Spread.SheetView spdSheet, int iRowCnt, double iDivQty)
        {
            int i = 0;
            int iCnt = 0;
            double dTmpQty1;
            double dTmpQty2;
            double dTmpQty3;

            // Row Count & Div Qty 동시 입력 불가능 
            try
            {
                if (spdSheet.RowCount == 0)
                {
                    spdSheet.FrozenTrailingRowCount = 0;
                }

                if (spdSheet.FrozenTrailingRowCount == 1)
                {
                    spdSheet.RemoveRows(spdSheet.RowCount - 1, 1);
                    spdSheet.FrozenTrailingRowCount = 0;
                }
                else
                {
                    spdSheet.FrozenTrailingRowCount = 0;
                }

                if (iRowCnt != 0)
                {
                    if (iDivQty != 0)
                    {
                        // Lot Count & Qty
                        dTmpQty1 = LOT.GetDouble("QTY_1");
                        dTmpQty2 = LOT.GetDouble("QTY_2");
                        dTmpQty3 = LOT.GetDouble("QTY_3");

                        spdSheet.RowCount = iRowCnt;
                        for (i = 0; i < spdSheet.RowCount; i++)
                        {
                            if (LOT.GetDouble("QTY_1") != 0)
                            {

                                if (dTmpQty1 > iDivQty)
                                {
                                    dTmpQty1 = dTmpQty1 - iDivQty;
                                    // 나머지 수량을 맨 마지막 Row에 수량에 합산
                                    if (dTmpQty1 > 0 && dTmpQty1 < 0.005)
                                    {
                                        iDivQty = iDivQty + dTmpQty1;
                                    }

                                    //SetValue Occurs Error. Use Cells[#,#].Value = Value
                                    //spdSheet.SetValue(i, COL_QTY_1, MPCF.Format("#######,##0.###", iDivQty));
                                    spdSheet.Cells[i, COL_QTY_1].Value = MPCF.Format("#######,##0.###", iDivQty);
                                }
                                else if (dTmpQty1 < 0)
                                {
                                    //spdSheet.SetValue(i, COL_QTY_1, "0.000");
                                    spdSheet.Cells[i, COL_QTY_1].Value = "0";
                                }
                                else if (dTmpQty1 <= iDivQty)
                                {
                                    //spdSheet.SetValue(i, COL_QTY_1, MPCF.Format("#######,##0.###", dTmpQty1));
                                    spdSheet.Cells[i, COL_QTY_1].Value = MPCF.Format("#######,##0.###", dTmpQty1);
                                    dTmpQty1 = dTmpQty1 - iDivQty;
                                }
                            }
                            else
                            {
                                //spdSheet.SetValue(i, COL_QTY_1, "0.000");
                                spdSheet.Cells[i, COL_QTY_1].Value = "0";
                            }

                            /* 임시로 QTY2, QTY3는 0으로 처리 */
                            //spdSheet.SetValue(i, COL_QTY_2, "0.000");
                            //spdSheet.SetValue(i, COL_QTY_3, "0.000");
                            spdSheet.Cells[i, COL_QTY_2].Value = "0";
                            spdSheet.Cells[i, COL_QTY_3].Value = "0";
                        }
                    }
                    else
                    {
                        // Only Row Count
                        dTmpQty1 = LOT.GetDouble("QTY_1");
                        iDivQty = MPCF.ToDbl(dTmpQty1 / iRowCnt);
                        iCnt = 0;

                        if (iDivQty < 0.0005)
                        {
                            iCnt = 1;
                            iDivQty = dTmpQty1;
                        }
                        else
                        {
                            do
                            {
                                dTmpQty1 = dTmpQty1 - iDivQty;
                                iCnt += 1;
                            } while (dTmpQty1 > 0.0005);
                        }

                        SetAutoQtyInfo(spdSheet, iCnt, iDivQty);
                    }
                }
                else
                {
                    // Only Divide Qty
                    dTmpQty1 = LOT.GetDouble("QTY_1");
                    iCnt = 0;

                    if (iDivQty < 0.0005)
                    {
                        iCnt = 1;
                        iDivQty = dTmpQty1;
                    }
                    else
                    {
                        do
                        {
                            dTmpQty1 = dTmpQty1 - iDivQty;
                            iCnt += 1;
                        } while (dTmpQty1 > 0);
                    }

                    SetAutoQtyInfo(spdSheet, iCnt, iDivQty);
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void SetChildLotQty()
        {
            try
            {
                if (MPCF.CheckValue(txtLotID, 1) == false)
                {
                    return;
                }

                if (txtChildLotQty.Text != "")
                {
                    if (MPCF.CheckNumeric(txtChildLotQty.Text) == false)
                    {
                        return;
                    }
                    else
                    {
                        if (MPCF.ToDbl(txtChildLotQty.Text) > 0)
                        {
                            if (MPCF.Trim(txtChildLotCnt.Text) != "")
                            {
                                if (MPCF.CheckNumeric(txtChildLotCnt.Text) == false)
                                {
                                    return;
                                }
                                else
                                {
                                    if (MPCF.Trim(txtChildLotCnt.Text) != "0")
                                    {
                                        SetAutoQtyInfo(spdChildLotList.ActiveSheet, MPCF.ToInt(txtChildLotCnt.Text), MPCF.ToDbl(txtChildLotQty.Text));
                                    }
                                    else
                                    {
                                        SetAutoQtyInfo(spdChildLotList.ActiveSheet, MPCF.ToDbl(txtChildLotQty.Text));
                                    }
                                }
                            }
                            else
                            {
                                SetAutoQtyInfo(spdChildLotList.ActiveSheet, MPCF.ToDbl(txtChildLotQty.Text));
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void SetChildLotCnt()
        {
            try
            {
                if (MPCF.CheckValue(txtLotID, 1) == false)
                {
                    return;
                }

                if (txtChildLotCnt.Text != "")
                {
                    if (MPCF.CheckNumeric(txtChildLotCnt.Text) == false)
                    {
                        return;
                    }
                    else
                    {
                        if (MPCF.ToInt(txtChildLotCnt.Text) > 0)
                        {
                            if (MPCF.Trim(txtChildLotQty.Text) != "")
                            {
                                if (MPCF.CheckNumeric(txtChildLotQty.Text) == false)
                                {
                                    return;
                                }
                                else
                                {
                                    if (MPCF.ToDbl(txtChildLotQty.Text) > 0)
                                    {
                                        SetAutoQtyInfo(spdChildLotList.ActiveSheet, MPCF.ToInt(txtChildLotCnt.Text), MPCF.ToDbl(txtChildLotQty.Text));
                                    }
                                    else
                                    {
                                        SetAutoQtyInfo(spdChildLotList.ActiveSheet, MPCF.ToInt(txtChildLotCnt.Text));
                                    }
                                }
                            }
                            else
                            {
                                SetAutoQtyInfo(spdChildLotList.ActiveSheet, MPCF.ToInt(txtChildLotCnt.Text));
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void spdCalculate()
        {
            int i = 0;
            int iTotLotCnt = 0;
            double iTotQty1 = 0;
            double iTotQty2 = 0;
            double iTotQty3 = 0;
            int iTotCrrCnt = 0;

            try
            {
                if (spdChildLotList.ActiveSheet.RowCount > 0)
                {
                    if (spdChildLotList.ActiveSheet.FrozenTrailingRowCount == 0)
                        spdChildLotList.ActiveSheet.RowCount++;

                    for (i = 0; i < spdChildLotList.ActiveSheet.RowCount - 1; i++)
                    {
                        iTotLotCnt += 1;

                        if (MPCF.Trim(COL_QTY_1) != "")
                        {
                            iTotQty1 += MPCF.ToDbl(spdChildLotList.ActiveSheet.Cells[i, COL_QTY_1].Value);
                        }

                        if (MPCF.Trim(COL_QTY_2) != "")
                        {
                            iTotQty2 += MPCF.ToDbl(spdChildLotList.ActiveSheet.Cells[i, COL_QTY_2].Value);
                        }

                        if (MPCF.Trim(COL_QTY_3) != "")
                        {
                            iTotQty3 += MPCF.ToDbl(spdChildLotList.ActiveSheet.Cells[i, COL_QTY_3].Value);
                        }

                        if (MPCF.Trim(spdChildLotList.ActiveSheet.Cells[i, COL_CARRIER_ID].Value) != "")
                        {
                            iTotCrrCnt += 1;
                        }
                    }

                    spdChildLotList.ActiveSheet.FrozenTrailingRowCount = 1;
                    spdChildLotList.ActiveSheet.Cells[spdChildLotList.ActiveSheet.RowCount - 1, COL_CHILD_LOT_ID, spdChildLotList.ActiveSheet.RowCount - 1, COL_CARRIER_ID].Locked = true;
                    spdChildLotList.ActiveSheet.Cells[spdChildLotList.ActiveSheet.RowCount - 1, COL_CHILD_LOT_ID, spdChildLotList.ActiveSheet.RowCount - 1, COL_CARRIER_ID].BackColor = Color.Yellow;
                    spdChildLotList.ActiveSheet.Cells[spdChildLotList.ActiveSheet.RowCount - 1, COL_CHILD_LOT_ID, spdChildLotList.ActiveSheet.RowCount - 1, COL_CARRIER_ID].Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    spdChildLotList.ActiveSheet.Cells[spdChildLotList.ActiveSheet.RowCount - 1, COL_CHILD_LOT_ID].Value = iTotLotCnt;
                    spdChildLotList.ActiveSheet.Cells[spdChildLotList.ActiveSheet.RowCount - 1, COL_QTY_1].Value = iTotQty1;
                    spdChildLotList.ActiveSheet.Cells[spdChildLotList.ActiveSheet.RowCount - 1, COL_QTY_2].Value = iTotQty2;
                    spdChildLotList.ActiveSheet.Cells[spdChildLotList.ActiveSheet.RowCount - 1, COL_QTY_3].Value = iTotQty3;
                    spdChildLotList.ActiveSheet.Cells[spdChildLotList.ActiveSheet.RowCount - 1, COL_CARRIER_ID].Value = iTotCrrCnt;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
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

        #endregion

        private void frmWIPTranMultiSplitLot_Activated(object sender, System.EventArgs e)
        {

            try
            {
                if (b_load_flag == false)
                {
#if _CRR
                    lblCrrID.Visible = true;
                    cdvCrrID.Visible = true;
#endif
                    ClearData("1");
                    SetCMFItem(MPGC.MP_CMF_TRN_SPLIT);
                    MPCR.SetCMFItem(MPGC.MP_CMF_LOT, "lblCreateCMF", "cdvCreateCMF", grpCreateCMF);

                    if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                    {
                        txtLotID.Text = MPGV.gsCurrentLot_ID;
                        ViewLotInfo(txtLotID.Text);
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
            int i = 0;
            double dSumQty = 0;
            try
            {
                if (CheckCondition("MULTI_SPLIT_LOT", '1') == false) return;
                for (i = 0; i < spdChildLotList.ActiveSheet.RowCount - 1; i++)
                {
                    dSumQty += MPCF.ToDbl(spdChildLotList.ActiveSheet.Cells[i, COL_QTY_1].Value);
                }

                if (LOT.GetDouble("QTY_1") != 0)
                {
                    if ((LOT.GetDouble("QTY_1") - dSumQty) < 0.0005)
                    {
                        if (MPCF.ShowMsgBox(MPCF.GetMessage(191), MessageBoxButtons.YesNo, 1) == System.Windows.Forms.DialogResult.No)
                        {
                            return;
                        }
                    }
                }

                if (MultiSplitLot('1') == false) return;

                if (!chkGenID.Checked)
                {
                    if ((LOT.GetDouble("QTY_1") - dSumQty) < 0.0005)
                    {
                        ClearData("4");
                    }
                    else
                    {
                        ClearData("3");
                    }
                }
                else
                {
                    ClearData("5");
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnCalculation_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (SetDueDate() == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cdvCreateCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvCreateCode.Init();
            MPCF.InitListView(cdvCreateCode.GetListView);
            cdvCreateCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvCreateCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCreateCode.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvCreateCode.GetListView, '1', MPGC.MP_WIP_CREATE_CODE);
        }

        private void cdvOwnerCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvOwnerCode.Init();
            MPCF.InitListView(cdvOwnerCode.GetListView);
            cdvOwnerCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvOwnerCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOwnerCode.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvOwnerCode.GetListView, '1', MPGC.MP_WIP_OWNER_CODE);

        }

        private void cdvLotType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvLotType.Init();
            MPCF.InitListView(cdvLotType.GetListView);
            cdvLotType.Columns.Add("LotType", 50, HorizontalAlignment.Left);
            cdvLotType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvLotType.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvLotType.GetListView, '1', MPGC.MP_WIP_LOT_TYPE);
        }

        private void chkDueDate_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            txtDueDate.Visible = !chkDueDate.Checked;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (CheckCondition("SPLIT_LOT", '2') == false) return;

            if (spdChildLotList.ActiveSheet.RowCount > 0)
            {
                for (i = 0; i < spdChildLotList.ActiveSheet.RowCount - 1; i++)
                {
                    if (GenerateID('1', i) == false)
                    {
                        return;
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (spdChildLotList.ActiveSheet.RowCount == 0)
                {
                    spdChildLotList.ActiveSheet.Rows.Add(spdChildLotList.ActiveSheet.RowCount, 1);
                }
                else
                {
                    if (spdChildLotList.ActiveSheet.RowCount > 1000)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(126) + "[1000]");
                        return;
                    }

                    if (spdChildLotList.ActiveSheet.FrozenTrailingRowCount == 1)
                    {
                        spdChildLotList.ActiveSheet.Rows.Add(spdChildLotList.ActiveSheet.RowCount - 1, 1);
                    }
                    else
                    {
                        spdChildLotList.ActiveSheet.Rows.Add(spdChildLotList.ActiveSheet.RowCount, 1);
                    }
                }

                spdCalculate();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (spdChildLotList.ActiveSheet.RowCount > 0)
            {
                spdChildLotList.ActiveSheet.Rows.Remove(spdChildLotList.ActiveSheet.ActiveRowIndex, 1);
            }

            if (spdChildLotList.ActiveSheet.RowCount == 0)
            {
                spdChildLotList.ActiveSheet.FrozenTrailingRowCount = 0;
            }
            spdCalculate();
        }

        private void spdChildLotList_EditModeOff(object sender, EventArgs e)
        {
            int i_col, i_row;
            int i;
            string s_crr_id;
            bool b_move_next;

            i_col = spdChildLotList.ActiveSheet.ActiveColumnIndex;
            i_row = spdChildLotList.ActiveSheet.ActiveRowIndex;

            b_move_next = false;

            if (i_col == COL_CARRIER_ID)
            {
                s_crr_id = MPCF.Trim(spdChildLotList.ActiveSheet.Cells[i_row, i_col].Value);

                if (s_crr_id != "")
                {
                    for (i = 0; i < spdChildLotList.ActiveSheet.RowCount - 1; i++)
                    {
                        if (i == i_row) continue;

                        if (s_crr_id == MPCF.Trim(spdChildLotList.ActiveSheet.Cells[i, i_col].Value))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(322));
                            spdChildLotList.ActiveSheet.Cells[i_row, i_col].Value = null;
                            return;
                        }
                    }

                    if (ViewCarrier(s_crr_id) == false)
                    {
                        spdChildLotList.ActiveSheet.Cells[i_row, i_col].Value = null;
                        return;
                    }

                    b_move_next = true;
                }
            }

            if (b_move_next == true && i_row < spdChildLotList.ActiveSheet.RowCount - 2)
            {
                spdChildLotList.ActiveSheet.SetActiveCell(i_row + 1, i_col);
            }

            spdCalculate();
        }

        private void chkChildLotCnt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChildLotCnt.Checked)
            {
                txtChildLotCnt.ReadOnly = false;
                btnAdd.Enabled = false;
                btnDel.Enabled = false;
            }
            else
            {
                txtChildLotCnt.ReadOnly = true;
                txtChildLotCnt.Text = "";
                btnAdd.Enabled = true;
                btnDel.Enabled = true;
            }
        }

        private void chkChildLotQty_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChildLotQty.Checked)
            {
                txtChildLotQty.ReadOnly = false;
                if (chkChildLotCnt.Checked)
                {
                    btnAdd.Enabled = false;
                    btnDel.Enabled = false;
                }
                else
                {
                    btnAdd.Enabled = true;
                    btnDel.Enabled = true;
                }

            }
            else
            {
                txtChildLotQty.ReadOnly = true;
                txtChildLotQty.Text = "";

                if (chkChildLotCnt.Checked)
                {
                    btnAdd.Enabled = false;
                    btnDel.Enabled = false;
                }
                else
                {
                    btnAdd.Enabled = true;
                    btnDel.Enabled = true;
                }
            }
        }

        private void txtChildLotCnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (MPCF.ToInt(txtChildLotCnt.Text) > 1000)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(126) + "[1000]");
                txtChildLotCnt.Text = "";
                return;
            }

            if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                {
                    if (e.KeyChar != (char)46)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (e.KeyChar == (char)13)
            {
                SetChildLotCnt();
                spdCalculate();
            }
        }

        private void txtChildLotQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                {
                    if (e.KeyChar != (char)46)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (e.KeyChar == (char)13)
            {
                SetChildLotQty();
                spdCalculate();
            }
        }

        private void cdvCreateCMF_ButtonPress(object sender, System.EventArgs e)
        {

            MPCR.ProcGRPCMFButtonPress(sender);

        }

        private void cdvCreateCMF_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            MPCR.CheckCMFKeyPress(sender, e);

        }

        private void chkGenID_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGenID.Checked)
            {
                btnGenerate.Enabled = false;
            }
            else
            {
                btnGenerate.Enabled = true;
            }
        }

    }
}
