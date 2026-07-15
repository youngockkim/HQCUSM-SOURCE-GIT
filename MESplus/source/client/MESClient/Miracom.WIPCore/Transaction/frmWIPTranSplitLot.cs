
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.MsgHandler;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPTranSplitLot : Miracom.MESCore.TranForm07
    {
        public frmWIPTranSplitLot()
        {
            InitializeComponent();
        }

#region " Constant Definition "

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
            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }
            /* Added by DM KIM 2012.04.20  Set Lot Cmf Field Function */
            SetLotCMFInfo();
            /* Added by DM KIM 2012.04.20  Set Lot Cmf Field Function */

            txtLotDesc.Text = LOT.GetString("LOT_DESC");

            if (View_Operation(LOT.GetString("OPER")) == false)
            {
                txtLotID.Focus();
                return false;
            }

            cdvMatID.Text = LOT.GetString("MAT_ID");
            cdvMatID.Version = LOT.GetInt("MAT_VER");
            cdvFlow.Text = LOT.GetString("FLOW");
            cdvFlow.Sequence = LOT.GetInt("FLOW_SEQ_NUM");
            cdvOper.Text = LOT.GetString("OPER");
            cboPriority.SelectedIndex = 4;

            cdvCreateCode.Text = LOT.GetString("CREATE_CODE");
            cdvOwnerCode.Text = LOT.GetString("OWNER_CODE");
            cdvLotType.Text = LOT.GetChar("LOT_TYPE").ToString();
            chkDueDate.Checked = true;
            // 2006.05.24. CM Koo.
            // GetSPDueDate ê°€ "" ??ê²½ìš°??ì²˜ë¦¬ ì¶”ê?
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
                        ClearLotSpread();
                        cboPriority.SelectedIndex = 4;
                        txtDueDate.Visible = !chkDueDate.Checked;
                        break;

                    case "3":

                        MPCF.FieldClear(this, txtLotID);
                        cboPriority.SelectedIndex = 4;
                        if (base.ViewLotInfo(txtLotID.Text) == false)
                        {
                            txtLotID.Focus();
                            return;
                        }
                        break;
                    case "4":

                        MPCF.FieldClear(this, txtLotID);
                        ClearLotSpread();
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

            switch (MPCF.Trim(FuncName))
            {
                case "SPLIT_LOT":

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
                    if (c_step == '1')
                    {
                        if (MPCF.CheckValue(txtChildLotID, 1) == false)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            txtChildLotID.Focus();
                            return false;
                        }
                    }
                    if (cdvMatID.CheckValue() == false)
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        cdvMatID.Focus();
                        return false;
                    }
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


                    if (txtQty1.ReadOnly == false)
                    {
                        if (txtQty1.Text == "" || MPCF.ToDbl(txtQty1.Text) == 0)
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
                        }
                        if (txtQty1.Text == "")
                        {
                            txtQty1.Text = "0";
                        }
                        if (MPCF.CheckValue(txtQty1, 2) == false)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            txtQty1.Focus();
                            return false;
                        }
                    }
                    if (txtQty2.ReadOnly == false)
                    {
                        if (txtQty2.Text == "" || MPCF.ToDbl(txtQty2.Text) == 0)
                        {
                            if (MPGO.ProcessZeroQtyLot() == true)
                            {
                                if (sQtyChk == "")
                                    sQtyChk = "Qty2";
                            }
                            else
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                return false;
                            }
                        }
                        if (txtQty2.Text == "")
                        {
                            txtQty2.Text = "0";
                        }
                        if (MPCF.CheckValue(txtQty2, 2) == false)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            txtQty2.Focus();
                            return false;
                        }
                    }
                    if (txtQty3.ReadOnly == false)
                    {
                        if (txtQty3.Text == "" || MPCF.ToDbl(txtQty3.Text) == 0)
                        {
                            if (MPGO.ProcessZeroQtyLot() == true)
                            {
                                if (sQtyChk == "")
                                    sQtyChk = "Qty3";
                            }
                            else
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                return false;
                            }
                        }
                        if (txtQty3.Text == "")
                        {
                            txtQty3.Text = "0";
                        }
                        if (MPCF.CheckValue(txtQty3, 2) == false)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            txtQty3.Focus();
                            return false;
                        }
                    }

                    if (sQtyChk != "")
                    {
                        if (MPCF.ShowMsgBox(MPCF.GetMessage(190), MessageBoxButtons.YesNo, 1) == System.Windows.Forms.DialogResult.No)
                        {
                            switch (sQtyChk)
                            {
                                case "Qty1":
                                    txtQty1.Focus();
                                    break;

                                case "Qty2":
                                    txtQty2.Focus();
                                    break;

                                case "Qty3":
                                    txtQty3.Focus();
                                    break;

                                default:
                                    break;
                            }

                            return false;
                        }
                    }

                    if (txtQty1.Text != "" && txtQty1.Text != "0")
                    {
                        if (LOT.GetDouble("QTY_1") < MPCF.ToDbl(txtQty1.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(135));
                            tabTran.SelectedTab = tbpGeneral;
                            txtQty1.Text = "0";
                            txtQty1.Focus();
                            return false;
                        }
                    }
                    if (txtQty2.Text != "" && txtQty2.Text != "0")
                    {
                        if (LOT.GetDouble("QTY_2") < MPCF.ToDbl(txtQty2.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(135));
                            tabTran.SelectedTab = tbpGeneral;
                            txtQty2.Text = "0";
                            txtQty2.Focus();
                            return false;
                        }
                    }
                    if (txtQty3.Text != "" && txtQty3.Text != "0")
                    {
                        if (LOT.GetDouble("QTY_3") < MPCF.ToDbl(txtQty3.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(135));
                            tabTran.SelectedTab = tbpGeneral;
                            txtQty3.Text = "0";
                            txtQty3.Focus();
                            return false;
                        }
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

        /* Added by DM KIM 2012.04.20  Set Lot Cmf Field Function */
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
        // GetOperationList()
        //       - Get Operation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sFlow As String : Flow Name
        //
        private bool GetOperationList(string sFlow)
        {

            try
            {
                cdvOper.Init();
                MPCF.InitListView(cdvOper.GetListView);
                cdvOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvOper.SelectedSubItemIndex = 0;

                if (WIPLIST.ViewOperationList(cdvOper.GetListView, '2', "", 0,sFlow, "", null, "") == false)
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
        // View_Material()
        //       - View Material Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Material(string sMatID, int iMatVer)
        {

            TRSNode in_node = new TRSNode("VIEW_MATERIAL_IN");
            TRSNode out_node = new TRSNode("VIEW_MATERIAL_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MAT_ID", sMatID);
            in_node.AddInt("MAT_VER", iMatVer);

            if (MPCR.CallService("WIP", "WIP_View_Material", in_node, ref out_node) == false)
            {
                return false;
            }

            cdvFlow.Text = MPCF.Trim(out_node.GetString("FIRST_FLOW"));
            cdvFlow.Sequence = out_node.GetInt("FIRST_FLOW_SEQ_NUM");
            cdvOper.Text = MPCF.Trim(out_node.GetString("FIRST_OPER"));

            return true;

        }

        //
        // View_Flow()
        //       - View Flow Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Flow()
        {

            TRSNode in_node = new TRSNode("VIEW_FLOW_IN");
            TRSNode out_node = new TRSNode("VIEW_FLOW_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));

            if (MPCR.CallService("WIP", "WIP_View_Flow", in_node, ref out_node) == false)
            {
                return false;
            }

            cdvOper.Text = MPCF.Trim(out_node.GetString("FIRST_OPER"));

            return true;

        }

        //
        // View_Operation()
        //       -  View Operation Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Operation(string sOperation)
        {

            TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");
            TRSNode out_node = new TRSNode("VIEW_OPERATION_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", sOperation);

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetString("UNIT_1") != "")
            {
                txtQty1.Text = LOT.GetDouble("QTY_1").ToString("####,##0.###");
                txtQty1.ReadOnly = false;
                lblUnit1.Text = out_node.GetString("UNIT_1");
            }
            else
            {
                txtQty1.ReadOnly = true;
                lblUnit1.Text = "";
            }
            if (out_node.GetString("UNIT_2") != "")
            {
                txtQty2.Text = LOT.GetDouble("QTY_2").ToString("####,##0.###");
                txtQty2.ReadOnly = false;
                lblUnit2.Text = out_node.GetString("UNIT_2");
            }
            else
            {
                txtQty2.ReadOnly = true;
                lblUnit2.Text = "";
            }
            if (out_node.GetString("UNIT_3") != "")
            {
                txtQty3.Text = LOT.GetDouble("QTY_3").ToString("####,##0.###");
                txtQty3.ReadOnly = false;
                lblUnit3.Text = out_node.GetString("UNIT_3");
            }
            else
            {
                txtQty3.ReadOnly = true;
                lblUnit3.Text = "";
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
            string sFlow;
            int iFlowSeq;
            string sOperation;

            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;

            if (cdvMatID.CheckValue() == false) return false;

            if (cdvFlow.Text != "" && cdvOper.Text != "")
            {
                sFlow = cdvFlow.Text;
                iFlowSeq = cdvFlow.Sequence;
                sOperation = cdvOper.Text;
            }
            else
            {
                //if (MPCF.Trim(LOT.GetString("FLOW")) == "")
                //{
                //    tabTran.SelectedTab = tbpGeneral;
                //    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Flow]");
                //    txtLotID.Focus();
                //}
                //if (MPCF.Trim(LOT.GetString("OPER")) == "")
                //{
                //    tabTran.SelectedTab = tbpGeneral;
                //    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                //    txtLotID.Focus();
                //}
                sFlow = LOT.GetString("FLOW");
                iFlowSeq = LOT.GetInt("FLOW_SEQ_NUM");
                sOperation = LOT.GetString("OPER");
            }


            if (txtQty1.Text == "")
            {
                dQty1 = 0;
            }
            else
            {
                dQty1 = MPCF.ToDbl(txtQty1.Text);
            }

            if (MPCR.GetProcTime(cdvMatID.Text, cdvMatID.Version, sFlow, iFlowSeq, sOperation, dQty1, ref dSumQueueTime, ref dSumProcTime, ref dSumQueueProcTime) == false)
            {
                txtDueDate.Text = "";
                return false;
            }

            //2006.04.25. CM Koo. CycleTime Unit???°ë¼ ?”í•˜???œê°„ ?¨ìœ„ë¥??¬ë¦¬ ?ìš©
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

        //
        // Split_Lot()
        //       - Split Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Split_Lot(char ProcStep)
        {

            TRSNode in_node = new TRSNode("SPLIT_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            bool b_proc_alarm_action;

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

                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));

                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));

                in_node.AddString("CRR_ID", MPCF.Trim(cdvCrrID.Text));
                in_node.AddString("CHILD_CRR_ID", MPCF.Trim(cdvChildCrrID.Text));

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

                in_node.AddString("CHILD_LOT_ID", MPCF.Trim(txtChildLotID.Text));
                in_node.AddString("CHILD_LOT_DESC", MPCF.Trim(txtChildLotDesc.Text));
                in_node.AddString("CHILD_MAT_ID", MPCF.Trim(cdvMatID.Text));
                in_node.AddInt("CHILD_MAT_VER", cdvMatID.Version);
                in_node.AddString("CHILD_FLOW", MPCF.Trim(cdvFlow.Text));
                in_node.AddInt("CHILD_FLOW_SEQ_NUM", cdvFlow.Sequence);
                in_node.AddString("CHILD_OPER", MPCF.Trim(cdvOper.Text));
                in_node.AddString("CHILD_CREATE_CODE", MPCF.Trim(cdvCreateCode.Text));
                in_node.AddString("CHILD_OWNER_CODE", MPCF.Trim(cdvOwnerCode.Text));
                in_node.AddChar("CHILD_LOT_TYPE", MPCF.ToChar(cdvLotType.Text));
                in_node.AddChar("CHILD_PRIORITY", MPCF.ToChar(cboPriority.Text));
                if (txtQty1.Text != "")
                {
                    in_node.AddDouble("MOVE_QTY_1", MPCF.ToDbl(txtQty1.Text));
                }
                else
                {
                    in_node.AddDouble("MOVE_QTY_1", 0);
                }
                if (txtQty2.Text != "")
                {
                    in_node.AddDouble("MOVE_QTY_2", MPCF.ToDbl(txtQty2.Text));
                }
                else
                {
                    in_node.AddDouble("MOVE_QTY_2", 0);
                }
                if (txtQty3.Text != "")
                {
                    in_node.AddDouble("MOVE_QTY_3", MPCF.ToDbl(txtQty3.Text));
                }
                else
                {
                    in_node.AddDouble("MOVE_QTY_3", 0);
                }
                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("CHILD_DUE_TIME", MPCF.ToStandardTime(dtpDueDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));
                in_node.AddChar("NO_AUTOMATIC_TERMINATE_LOT", chkNoAutoTermLot.Checked == true ? 'Y' : ' ');

                if (MPCR.CallService("WIP", "WIP_Split_Lot", in_node, ref out_node) == false)
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

        private bool Generate_ID()
        {

            TRSNode in_node = new TRSNode("GENERATE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);

                in_node.ProcStep = '1';
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMatID.Text));
                in_node.AddInt("MAT_VER", cdvMatID.Version);
                in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
                in_node.AddString("OPER", MPCF.Trim(cdvOper.Text));
                in_node.AddChar("REL_LEVEL", '1');
                in_node.AddString("TRAN_CODE", "SPLIT");
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));

                if (MPCR.CallService("WIP", "WIP_Generate_ID", in_node, ref out_node) == false)
                {
                    return false;
                }

               txtChildLotID.Text = MPCF.Trim(out_node.GetString("GEN_ID"));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

#endregion

        private void frmWIPTranSplitLot_Activated(object sender, System.EventArgs e)
        {

            try
            {
                if (b_load_flag == false)
                {
#if _CRR
                    lblCrrID.Visible = true;
                    cdvCrrID.Visible = true;
                    lblChildCrrID.Visible = true;
                    cdvChildCrrID.Visible = true;
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

        private void txtChildLotID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                txtChildLotDesc.Focus();
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

        private void cdvMatID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvFlow.Text = "";
            cdvOper.Text = "";

            if (View_Material(cdvMatID.Text, cdvMatID.Version) == false)
            {
                return;
            }

        }

        private void cdvMatID_TextBoxTextChanged(object sender, System.EventArgs e)
        {

            chkDueDate.Checked = false;
            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;

        }

        private void cdvFlow_ButtonPress(object sender, System.EventArgs e)
        {
            if (cdvMatID.CheckValue() == false) return;

            cdvFlow.ListCond_MatID = cdvMatID.Text;
            cdvFlow.ListCond_MatVersion = cdvMatID.Version;
        }

        private void cdvFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            if (View_Flow() == false)
            {
                return;
            }

        }

        private void cdvFlow_TextBoxTextChanged(object sender, System.EventArgs e)
        {

            chkDueDate.Checked = false;
            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;

        }

        private void cdvOper_ButtonPress(object sender, System.EventArgs e)
        {

            if (cdvMatID.CheckValue() == false)
            {
                return;
            }
            if (cdvFlow.CheckValue() == false)
            {
                return;
            }

            if (GetOperationList(cdvFlow.Text) == false)
            {
                return;
            }

        }

        private void cdvOper_TextBoxTextChanged(object sender, System.EventArgs e)
        {

            chkDueDate.Checked = false;
            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;

        }

        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (CheckCondition("SPLIT_LOT", '1') == false) return;

                if(LOT.GetDouble("QTY_1") != 0)
                {
                    if ((LOT.GetDouble("QTY_1") - MPCF.ToDbl(txtQty1.Text)) < 0.0005)
                    {
                        if (MPCF.ShowMsgBox(MPCF.GetMessage(191), MessageBoxButtons.YesNo, 1) == System.Windows.Forms.DialogResult.No)
                        {
                            return;
                        }
                    }
                }

                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_SPLIT, LOT.GetString("LOT_ID"), "", "", 'B') == false) return;
                if (Split_Lot('1') == false) return;
                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_SPLIT, LOT.GetString("LOT_ID"), "", "", 'A') == false) return;

                if ((LOT.GetDouble("QTY_1") - MPCF.ToDbl(txtQty1.Text)) < 0.0005)
                {
                    ClearData("4");
                }
                else
                {
                    ClearData("3");
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtQty1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                if (txtQty1.Text == "")
                {
                    txtQty1.Text = "0";
                }

                if (MPGO.AutoCalDueDate() == true)
                {
                    if (SetDueDate() == false)
                    {
                        return;
                    }
                }
            }

        }

        private void cdvChildCrrID_ButtonPress(System.Object sender, System.EventArgs e)
        {
#if _CRR
            cdvChildCrrID.Init();
            MPCF.InitListView(cdvChildCrrID.GetListView);
            cdvChildCrrID.Columns.Add("Carrier", 50, HorizontalAlignment.Left);
            cdvChildCrrID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvChildCrrID.SelectedSubItemIndex = 0;

            RASLIST.ViewCarrierList(cdvChildCrrID.GetListView, '2', "", "", "", ' ', cdvMatID.Text, cdvMatID.Version, cdvFlow.Text, cdvOper.Text, LOT.GetString("START_RES_ID"), LOT.GetString("PORT_ID"), cdvChildCrrID.Text, null, "");
#endif //_CRR
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
            if (CheckCondition("SPLIT_LOT", '2') == false) return;
            Generate_ID();
        }

     
    }
}

