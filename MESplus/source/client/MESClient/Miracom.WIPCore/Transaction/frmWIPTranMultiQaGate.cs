//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranMultiEndLot.vb
//   Description : Multi End Lot Transaction
//
//   MES Version : 4.1.0.0
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
//       - 2008-02-19 : Created by W.Y.Choi
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System.Diagnostics;
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;


namespace Miracom.WIPCore
{
    public partial class frmWIPTranMultiQaGate : Miracom.MESCore.TranForm08
    {
        public frmWIPTranMultiQaGate()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private const int LOT_ID = 1;
        private const int MAT_ID = 2;
        private const int MAT_VER = 3;
        private const int FLOW = 4;
        private const int FLOW_SEQ = 5;
        private const int OPER = 6;
        private const int QTY_1 = 7;
        private const int QTY_2 = 8;
        private const int QTY_3 = 9;
        private const int COL_LAST_HIST_SEQ = 101;

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;

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
                switch (ProcStep)
                {
                    case "1":
                        MPCF.FieldClear(this, grpLoss);
                        MPCF.FieldClear(this, grpComment);
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
        private bool CheckCondition(string FuncName)
        {
            int i;
            int iCount = 0;

            switch (MPCF.Trim(FuncName))
            {
                case "VIEW":
                    if (MPCF.CheckValue(cdvOperation, 1) == false)
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        cdvOperation.Focus();
                        return false;
                    }
                    break;

                case "QA_GATE":
                    for (i = 0; i < lisLotList.Items.Count; i++)
                    {
                        if (lisLotList.Items[i].Checked == true)
                        {
                            iCount++;
                        }
                    }

                    if (iCount == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(199));
                        tabTran.SelectedTab = tbpGeneral;
                        return false;
                    }

                    if (CheckCMFItemValue() == false)
                    {
                        tabTran.SelectedTab = tbpCMF;
                        return false;
                    }
                    break;
            }

            return true;

        }

        // View_Lot_List()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool ViewLotList()
        {
            int i = 0;

            TRSNode in_node = new TRSNode("VIEW_LOT_LIST_DETAIL_BY_SQL_QUERY_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_LIST_DETAIL_OUT");

            MPCF.ClearList(lisLotList);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", MPCF.Trim(cdvOperation.Text));

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Lot_List_Detail_By_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    WIPLIST.DisplayLotListDetail(lisLotList, out_node.GetList(0)[i], 0);
                }

                in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));

            } while (in_node.GetString("NEXT_LOT_ID") != "");

            return true;

        }

        // MultiQaGate()
        //       - Multi QA Gate
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool MultiQaGate(char ProcStep)
        {
            TRSNode in_node = new TRSNode("MULTI_QA_GATE_IN");
            TRSNode out_node = new TRSNode("MULTI_QA_GATE_OUT");
            TRSNode list_item;
            int i;

            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                if (chkTranDateTime.Checked == true)
                {
                    String s_datetime = MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) +
                        MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT);
                    in_node.AddString("BACK_TIME", s_datetime);
                }

                for (i = 0; i < lisLotList.Items.Count; i++)
                {
                    if (lisLotList.Items[i].Checked == true)
                    {
                        list_item = in_node.AddNode("LIST");

                        list_item.AddString("LOT_ID", MPCF.Trim(lisLotList.Items[i].SubItems[1].Text));
                        list_item.AddString("MAT_ID", MPCF.Trim(lisLotList.Items[i].SubItems[2].Text));
                        list_item.AddInt("MAT_VER", MPCF.ToInt(lisLotList.Items[i].SubItems[3].Text));
                        list_item.AddString("FLOW", MPCF.Trim(lisLotList.Items[i].SubItems[4].Text));
                        list_item.AddInt("FLOW_SEQ_NUM", MPCF.ToInt(lisLotList.Items[i].SubItems[5].Text));
                        list_item.AddString("OPER", MPCF.Trim(lisLotList.Items[i].SubItems[6].Text));
                        list_item.AddInt("LAST_HIST_SEQ", MPCF.ToInt(lisLotList.Items[i].SubItems[101].Text));
                    }
                }
                in_node.AddString("QA_OPER", txtQAOper.Text);
                in_node.AddString("ACT_RULE_ID", cdvAction.Text);
                in_node.AddString("SMP_RULE_ID", txtSMPRule.Text);
                in_node.AddString("PASS_FLAG", txtPassFail.Text);

                in_node.AddDouble("SMP_SIZE_1", MPCF.ToDbl(txtSMPSize1.Text));
                in_node.AddDouble("SMP_SIZE_2", MPCF.ToDbl(txtSMPSize2.Text));
                in_node.AddString("RES_ID", cdvResID.Text);
                in_node.AddString("INSPECTOR", txtInspector.Text);
                in_node.AddString("SHIFT", cdvShift.Text);
                in_node.AddString("IRRMRR", txtIRRMRR.Text);

                in_node.AddString("QA_COMMENT", txtComment.Text);

                in_node.AddString("QA_CMF_1", cdvCMF1.Text);
                in_node.AddString("QA_CMF_2", cdvCMF2.Text);
                in_node.AddString("QA_CMF_3", cdvCMF3.Text);
                in_node.AddString("QA_CMF_4", cdvCMF4.Text);
                in_node.AddString("QA_CMF_5", cdvCMF5.Text);
                in_node.AddString("QA_CMF_6", cdvCMF6.Text);
                in_node.AddString("QA_CMF_7", cdvCMF7.Text);
                in_node.AddString("QA_CMF_8", cdvCMF8.Text);
                in_node.AddString("QA_CMF_9", cdvCMF9.Text);
                in_node.AddString("QA_CMF_10", cdvCMF10.Text);

                in_node.AddString("RESV_FIELD_1", cdvCMF11.Text);
                in_node.AddString("RESV_FIELD_2", cdvCMF12.Text);
                in_node.AddString("RESV_FIELD_3", cdvCMF13.Text);
                in_node.AddString("RESV_FIELD_4", cdvCMF14.Text);
                in_node.AddString("RESV_FIELD_5", cdvCMF15.Text);
                in_node.AddString("RESV_FIELD_6", cdvCMF16.Text);
                in_node.AddString("RESV_FIELD_7", cdvCMF17.Text);
                in_node.AddString("RESV_FIELD_8", cdvCMF18.Text);
                in_node.AddString("RESV_FIELD_9", cdvCMF19.Text);
                in_node.AddString("RESV_FIELD_10", cdvCMF20.Text);

                if (MPCR.CallService("NFM", "NFM_Update_Multi_Qa_Gate", in_node, ref out_node) == false)
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

        // ViewQARuleForLot()
        //       - Get QA Rule Information by Lot
        // Return Value
        //       -
        // Arguments
        //
        private bool ViewQARuleForOper()
        {
            TRSNode in_node = new TRSNode("VIEW_QA_RULE_FOR_OPER_IN");
            TRSNode out_node = new TRSNode("VIEW_QA_RULE_FOR_OPER_OU");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("OPER", MPCF.Trim(cdvOperation.Text));

                if (MPCR.CallService("NFM", "NFM_View_QA_Rule_By_Oper", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtQAOper.Text = MPCF.Trim(out_node.GetString("QA_OPER"));
                txtTestCount.Text = MPCF.Trim(out_node.GetInt("TEST_COUNT"));
                txtSMPType.Text = MPCF.Trim(out_node.GetString("SMP_TYPE"));
                txtUnit1SMPSizeType.Text = MPCF.Trim(out_node.GetString("SMP_SIZE_TYPE"));

                txtSMPRule.Text = MPCF.Trim(out_node.GetString("SMP_RULE_ID"));
                txtSMPDesc.Text = MPCF.Trim(out_node.GetString("SMP_RULE_DESC"));

                if (out_node.GetChar("UNIT1_SMP_FLAG") == 'Y')
                    chkSMPUnit1Flag.Checked = true;
                else
                    chkSMPUnit1Flag.Checked = false;

                txtUnit1SMPSizeType.Text = MPCF.Trim(out_node.GetString("UNIT1_SMP_TYPE"));
                txtUnit1SMPSize.Text = out_node.GetDouble("UNIT1_SMP_SIZE").ToString();
                txtUnit1SMPSelType.Text = MPCF.Trim(out_node.GetString("UNIT1_SMP_SEL_TYPE"));


                if (out_node.GetChar("UNIT2_SMP_FLAG") == 'Y')
                    chkSMPUnit2Flag.Checked = true;
                else
                    chkSMPUnit2Flag.Checked = false;

                txtUnit2SMPSizeType.Text = MPCF.Trim(out_node.GetString("UNIT2_SMP_TYPE"));
                txtUnit2SMPSize.Text = out_node.GetDouble("UNIT2_SMP_SIZE").ToString();
                txtUnit2SMPSelType.Text = MPCF.Trim(out_node.GetString("UNIT2_SMP_SEL_TYPE"));
                //Sample Size Control
                if (out_node.GetChar("UNIT1_SMP_FLAG") == 'Y' && out_node.GetChar("UNIT2_SMP_FLAG") == 'Y')
                {
                    txtSMPSize1.Enabled = true;
                    txtSMPSize2.Enabled = true;

                }
                else if (out_node.GetChar("UNIT1_SMP_FLAG") == 'Y')
                {
                    txtSMPSize1.Enabled = true;
                    txtSMPSize2.Enabled = false;
                }
                else if (out_node.GetChar("UNIT2_SMP_FLAG") == 'Y')
                {
                    txtSMPSize1.Enabled = false;
                    txtSMPSize2.Enabled = true;
                }

                if (out_node.GetDouble("UNIT1_SMP_SIZE") != 0)
                {
                    txtSMPSize1.Enabled = false;
                    txtSMPSize1.Text = out_node.GetDouble("SMP_SIZE_1").ToString();

                }
                if (out_node.GetDouble("UNIT2_SMP_SIZE") != 0)
                {
                    txtSMPSize2.Enabled = false;
                    txtSMPSize2.Text = out_node.GetDouble("SMP_SIZE_2").ToString();
                }

                if (txtSMPSize1.Enabled == false)
                    txtSMPSize1.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                else
                    txtSMPSize1.BackColor = Color.FromKnownColor(KnownColor.Window);

                if (txtSMPSize2.Enabled == false)
                    txtSMPSize2.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                else
                    txtSMPSize2.BackColor = Color.FromKnownColor(KnownColor.Window);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }


        public void SetCheckBoxValue(bool bTrue)
        {
            int i;

            for (i = 0; i < lisLotList.Items.Count; i++)
            {
                lisLotList.Items[i].Checked = bTrue;
            }
        }

        public override Control GetFisrtFocusItem()
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

        private void frmWIPTranMultiQaGate_Load(object sender, System.EventArgs e)
        {
            lisLotList.CheckBoxes = true;

            if (this.DesignMode == true)
                pnlTranTime.Visible = true;
            else
                pnlTranTime.Visible = MPGO.UseBackDate();

            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;
        }

        private void frmWIPTranMultiQaGate_Activated(object sender, System.EventArgs e)
        {

            try
            {
                if (b_load_flag == false)
                {
                    ClearData("1");
                    MPCF.InitListView(lisLotList);
                    SetCMFItem(MPGC.TAP_CMF_TRN_QA_GATE);

                    cdvOperation.Init();
                    MPCF.InitListView(cdvOperation.GetListView);
                    cdvOperation.Columns.Add("Oper", 150, HorizontalAlignment.Left);
                    cdvOperation.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                    cdvOperation.SelectedSubItemIndex = 0;
                    cdvOperation.DisplaySubItemIndex = 0;

                    WIPLIST.ViewOperationList(cdvOperation.GetListView, '1');
                    cdvOperation.AddEmptyRow(1);
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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
                cdvOperation.Init();
                MPCF.InitListView(cdvOperation.GetListView);
                cdvOperation.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvOperation.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvOperation.SelectedSubItemIndex = 0;

                if (sFlow.ToString() != "")
                {
                    if (WIPLIST.ViewOperationList(cdvOperation.GetListView, '2', "", 0, sFlow, "", null, "") == false)
                    {
                        return false;
                    }
                }
                else
                {
                    if (WIPLIST.ViewOperationList(cdvOperation.GetListView, '1', "", 0, sFlow, "", null, "") == false)
                    {
                        return false;
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

        private void btnView_Click(object sender, EventArgs e)
        {
            if (CheckCondition("VIEW") == false) return;
            ViewLotList();
        }

        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("QA_GATE") == false) return;

                if (MultiQaGate('1') == false) return;

                if (ViewLotList() == false) return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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

        private void cdvOperation_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            //ClearData("1");
            ViewLotList();
            ViewQARuleForOper();
        }

        private void chkTranDateTime_CheckedChanged(object sender, EventArgs e)
        {
            txtTranDateTime.Visible = !chkTranDateTime.Checked;

            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;

            txtTranDateTime.TabStop = !chkTranDateTime.Checked;
            dtpTranDate.TabStop = chkTranDateTime.Checked;
            dtpTranTime.TabStop = chkTranDateTime.Checked;
        }

        private void cdvAction_ButtonPress(object sender, EventArgs e)
        {
            cdvAction.Init();
            cdvAction.Columns.Add("Pass/Fail", 50, HorizontalAlignment.Left);
            cdvAction.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvAction.SelectedSubItemIndex = 0;

            if (QCMLIST.ViewMFOQARuleList(cdvAction.GetListView, '2', MPGC.TAP_CMF_QA_ACTION_RULE, "", cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, cdvFlow.Sequence , cdvOperation.Text, "", "") == false)
                return;
        }

        private void cdvAction_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvAction.Text == "FAIL")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(958));
                cdvAction.Text = "";
                return;
            }

            TRSNode in_node = new TRSNode("UPDATE_QA_RULE_IN");
            TRSNode out_node = new TRSNode("UPDATE_QA_RULE_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("RULE_ID", cdvAction.Text);
            in_node.AddString("RULE_TYPE", MPGC.TAP_ACTION_RULE);

            if (MPCR.CallService("WIP", "WIP_View_QA_Rule", in_node, ref out_node) == false)
            {
                return;
            }
            txtActionDesc.Text = MPCF.Trim(out_node.GetString("RULE_DESC"));
            txtPassFail.Text = MPCF.Trim(out_node.GetString("PASS_FLAG"));
        }

        private void cdvResID_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.Trim(cdvOperation.Text) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(154) + cdvOperation.Text);
                    return;
                }

                cdvResID.Init();
                cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvResID.SelectedSubItemIndex = 0;
#if _RAS
                if (RASLIST.ViewResourceList(cdvResID.GetListView, cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, cdvOperation.Text, false) == false)
                {
                    return;
                }
#endif
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }		
        }

        private void cdvShift_ButtonPress(object sender, EventArgs e)
        {
            string sql;
            cdvShift.Init();
            cdvShift.Columns.Add("Shift", 50, HorizontalAlignment.Left);
            cdvShift.Columns.Add("Start_Time", 50, HorizontalAlignment.Left);
            cdvShift.SelectedSubItemIndex = 0;

            sql = string.Empty;


            sql = "SELECT 'SHIFT_1' SHIFT ,SHIFT_1_START SHIFT_1 FROM MWIPFACDEF ";
            sql = sql +" WHERE FACTORY = '" + MPGV.gsFactory + "' ";
            sql = sql +" UNION ALL ";
            sql = sql +" SELECT  'SHIFT_2' SHIFT,SHIFT_2_START SHIFT_2 FROM MWIPFACDEF ";
            sql = sql + " WHERE FACTORY = '" + MPGV.gsFactory + "' ";
            sql = sql +" UNION ALL";
            sql = sql +" SELECT  'SHIFT_3' SHIFT,SHIFT_3_START SHIFT_3 FROM MWIPFACDEF ";
            sql = sql + " WHERE FACTORY =  '" + MPGV.gsFactory + "' ";
            sql = sql +" UNION ALL";
            sql = sql + " SELECT  'SHIFT_4' SHIFT,SHIFT_4_START SHIFT_4 FROM MWIPFACDEF ";
            sql = sql + " WHERE FACTORY =  '" + MPGV.gsFactory + "' ";;

            if (BASLIST.ViewQueryList(cdvShift.GetListView, '1', sql, 14, null) == false)
            {
                return;
            }

            //try
            //{
            //    cdvShift.Init();
            //    MPCF.InitListView(cdvShift.GetListView);
            //    cdvShift.Columns.Add("Group Id", 50, HorizontalAlignment.Left);
            //    cdvShift.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            //    cdvShift.SelectedSubItemIndex = 0;
            //    SECLIST.ViewSecGroupList(cdvShift.GetListView, '1', null, "");
            //}
            //catch (Exception ex)
            //{
            //    MPCF.ShowMsgBox(ex.Message);
            //}
        }

        private void cdvFlow_ButtonPress(object sender, EventArgs e)
        {

        }

        private void cdvMaterial_VersionChanged(object sender, EventArgs e)
        {

        }

        private void pnlComment_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cdvMaterial_VersionChanged_1(object sender, EventArgs e)
        {
            cdvFlow.Text = "";
            cdvFlow.Sequence = 0;

            cdvFlow_ButtonPress(null, null);
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

        private void cdvOperation_ButtonPress(object sender, EventArgs e)
        {
            if (GetOperationList(cdvFlow.Text) == false)
            {
                return;
            }
        }
    }
}

