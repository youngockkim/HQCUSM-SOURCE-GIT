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
    public partial class frmWIPTranMultiStartLot : Miracom.MESCore.TranForm08
    {
        public frmWIPTranMultiStartLot()
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

                        MPCF.FieldClear(this, cdvOperation);
                        udcCondition.QueryText = "";
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

                case "START_LOT":
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

                    if (cdvResID.Items.Count > 0)
                    {
                        if (cdvResID.CheckValue() == false)
                        {
                            cdvResID.Focus();
                            return false;
                        }
                    }
                    break;
            }

            return true;

        }

        //
        // GetLastHistSeq()
        //       - Get Last Hist Seq by Selected Row of LotList
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iRow As Integer : Selected Row
        //
        private string GetLastHistSeq(int iRow)
        {

            string sActiveLastHistSeq = "";
            try
            {
                sActiveLastHistSeq = lisLotList.Items[iRow].SubItems[COL_LAST_HIST_SEQ].Text;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return sActiveLastHistSeq;

        }

        //
        // GetLotID()
        //       - Get LotID by Selected Row of LotList
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iRow As Integer : Selected Row
        //
        private string GetLotID(int iRow)
        {

            string sLotID = "";
            try
            {
                sLotID = lisLotList.Items[iRow].SubItems[LOT_ID].Text;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return sLotID;

        }

        //
        // GetMaterial()
        //       - Get Material by Selected Row of LotList
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iRow As Integer : Selected Row
        //
        private string GetMaterial(int iRow)
        {

            string sMaterial = "";
            try
            {
                sMaterial = lisLotList.Items[iRow].SubItems[MAT_ID].Text;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return sMaterial;

        }

        private int GetMaterialVer(int iRow)
        {

            int iMatVer = 0;
            try
            {
                iMatVer = System.Convert.ToInt32(lisLotList.Items[iRow].SubItems[MAT_VER].Text);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return iMatVer;

        }

        //
        // GetFlow()
        //       - Get Flow by Selected Row of LotList
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iRow As Integer : Selected Row
        //
        private string GetFlow(int iRow)
        {

            string sFlow = "";
            try
            {
                sFlow = lisLotList.Items[iRow].SubItems[FLOW].Text;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return sFlow;

        }

        private int GetFlowSeq(int iRow)
        {

            int iFlowSeq = 0;
            try
            {
                iFlowSeq = System.Convert.ToInt32(lisLotList.Items[iRow].SubItems[FLOW_SEQ].Text);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return iFlowSeq;

        }

        //
        // GetOperation()
        //       - Get Operation by Selected Row of LotList
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iRow As Integer : Selected Row
        //
        private string GetOperation(int iRow)
        {

            string sOperation = "";
            try
            {
                sOperation = lisLotList.Items[iRow].SubItems[OPER].Text;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return sOperation;

        }

        //
        // GetQty()
        //       - Get Qty by Selected Row of LotList
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iRow As Integer : Selected Row
        //
        private string GetQty(int iRow, int iQtyType)
        {

            string sQty = "";
            try
            {
                switch (iQtyType)
                {
                    case 1:

                        sQty = lisLotList.Items[iRow].SubItems[QTY_1].Text;
                        break;
                    case 2:

                        sQty = lisLotList.Items[iRow].SubItems[QTY_2].Text;
                        break;
                    case 3:

                        sQty = lisLotList.Items[iRow].SubItems[QTY_3].Text;
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return sQty;

        }

        // ViewAttributeNameList()
        //       - View Attribute Name list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - 
        //
        public bool ViewAttributeNameList()
        {

            int i;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("LIST_IN");
            TRSNode out_node = new TRSNode("LIST_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ATTR_TYPE", MPGC.MP_ATTR_TYPE_LOT);

            try
            {
                do
                {
                    if (MPCR.CallService("BAS", "BAS_View_Attribute_Name_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetInt("ATTR_SEQ").ToString(), (int)SMALLICON_INDEX.IDX_KEY);

                        if (out_node.GetList(0)[i].GetString("VALID_TBL") != "")
                        {
                            itmX.Tag = out_node.GetList(0)[i].GetString("VALID_TBL");
                        }
                        else
                        {
                            itmX.Tag = "";
                        }

                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("ATTR_NAME")));
                        cdvAttributeName.GetListView.Items.Add(itmX);
                    }

                    in_node.SetString("NEXT_ATTR_NAME", out_node.GetString("NEXT_ATTR_NAME"));
                    in_node.SetInt("NEXT_ATTR_SEQ", out_node.GetInt("NEXT_ATTR_SEQ"));

                } while (in_node.GetString("NEXT_ATTR_NAME") != "" || in_node.GetInt("NEXT_ATTR_SEQ") > 0);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
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
            TRSNode out_node;
            ArrayList a_list;

            MPCF.ClearList(lisLotList);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
            in_node.AddInt("MAT_VER", cdvMaterial.Version);
            in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
            in_node.AddInt("FLOW_SEQ_NUM", cdvFlow.Sequence);
            in_node.AddString("OPER", MPCF.Trim(cdvOperation.Text));
            //in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
            in_node.AddChar("ZERO_QTY_FLAG", chkZeroQuantityLot.Checked ? 'Y' : ' ');
            in_node.AddChar("START_END_FLAG", chkOnlyWaitLot.Checked ? 'W' : ' ');
            in_node.AddString("ATTR_NAME", MPCF.Trim(cdvAttributeName.Text));
            in_node.AddString("ATTR_VALUE", MPCF.Trim(cdvAttributeValue.Text));
            in_node.AddString("SQL", MPCF.Trim(udcCondition.QueryText));

            a_list = new ArrayList();

            do
            {
                out_node = new TRSNode("VIEW_LOT_LIST_DETAIL_OUT");

                if (MPCR.CallService("WIP", "WIP_View_Lot_List_Detail_By_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
            } while (in_node.GetString("NEXT_LOT_ID") != "");

            Cursor.Current = Cursors.WaitCursor;
            foreach (object obj in a_list)
            {
                out_node = (TRSNode)obj;
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (out_node.GetList(0)[i].GetChar("HOLD_FLAG") == 'Y'
                            || out_node.GetList(0)[i].GetChar("START_FLAG") == 'Y')
                    {
                        continue;
                    }
                    else
                    {
                        WIPLIST.DisplayLotListDetail(lisLotList, out_node.GetList(0)[i], 0);
                    }
                }
            }
            Cursor.Current = Cursors.Default;

            return true;

        }

        // Start_Lot()
        //       - Start Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool StartLot(char ProcStep, int iRowIndex, TRSNode out_node)
        {
            bool b_have_port;
            bool b_change_carrier;
            bool b_proc_alarm_action;

            TRSNode in_node = new TRSNode("START_LOT_IN");

            try
            {
                if (MPCF.ToDbl(GetQty(iRowIndex, 1)) > 0 || MPCF.ToDbl(GetQty(iRowIndex, 2)) > 0 || MPCF.ToDbl(GetQty(iRowIndex, 3)) > 0)
                {
                    //Multi Transaction can not transact Transaction with other Transaction at the same time 
                    b_have_port = false;
                    b_change_carrier = false;
                    b_proc_alarm_action = false;

                    if (MPGO.ChangePortStateWithLotTran() == true && MPCF.Trim(cdvResID.Text) != "")
                    {
                        if (MPCR.CheckResourceHavePort(cdvResID.Text, ref b_have_port) == false)
                        {
                            return false;
                        }

                        if (b_have_port == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(270));
                            return false;
                        }
                    }

                    if (MPCR.CheckCarrierChangeOption(GetMaterial(iRowIndex),
                                                   GetMaterialVer(iRowIndex),
                                                   GetFlow(iRowIndex),
                                                   GetOperation(iRowIndex),
                                                   'S',
                                                   ref b_change_carrier) == false)
                    {
                        return false;
                    }

                    if (b_change_carrier == true)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(267));
                        return false;
                    }

                    if (MPCR.CheckTranAlarmRelation(this,
                                                    MPGC.MP_ALM_TRAN_END,
                                                    GetMaterial(iRowIndex),
                                                    GetMaterialVer(iRowIndex),
                                                    GetFlow(iRowIndex),
                                                    GetOperation(iRowIndex),
                                                    GetLotID(iRowIndex),
                                                    "START_LOT",
                                                    cdvResID.Text,
                                                    ref b_proc_alarm_action) == false)
                    {
                        return false;
                    }

                    if (b_proc_alarm_action == true)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(269));
                        return false;
                    }
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                if (chkTranDateTime.Checked == true)
                {
                    String s_datetime = MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) +
                        MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT);
                    in_node.AddString("BACK_TIME", s_datetime);
                }

                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", MPCF.ToInt(GetLastHistSeq(iRowIndex)));
                in_node.AddString("LOT_ID", GetLotID(iRowIndex));
                in_node.AddString("MAT_ID", GetMaterial(iRowIndex));
                in_node.AddInt("MAT_VER", GetMaterialVer(iRowIndex));
                in_node.AddString("FLOW", GetFlow(iRowIndex));
                in_node.AddInt("FLOW_SEQ_NUM", GetFlowSeq(iRowIndex));
                in_node.AddString("OPER", GetOperation(iRowIndex));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));

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

                if (MPCR.CallService("WIP", "WIP_Start_Lot", in_node, ref out_node) == false)
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

        private void frmWIPTranMultiStartLot_Load(object sender, System.EventArgs e)
        {
            lisLotList.CheckBoxes = true;

            if (this.DesignMode == true)
                pnlTranTime.Visible = true;
            else
                pnlTranTime.Visible = MPGO.UseBackDate();

            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;
        }

        private void frmWIPTranMultiStartLot_Activated(object sender, System.EventArgs e)
        {

            try
            {
                if (b_load_flag == false)
                {
                    ClearData("1");
                    MPCF.InitListView(lisLotList);
                    SetCMFItem(MPGC.MP_CMF_TRN_START);

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

        private void btnView_Click(object sender, EventArgs e)
        {
            if (CheckCondition("VIEW") == false) return;
            ViewLotList();
        }

        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            bool b_success_flag;
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                if (CheckCondition("START_LOT") == false) return;
                b_success_flag = true;

                for (i = 0; i < lisLotList.Items.Count; i++)
                {
                    if (lisLotList.Items[i].Checked == true)
                    {
                        b_success_flag = true;
                        if (StartLot('1', i, out_node) == false)
                        {
                            b_success_flag = false;
                            break;
                        }
                    }
                }

                if (b_success_flag == true)
                {
                    MPCR.ShowSuccessMsg(out_node);

                    if (ViewLotList() == false) return;
                }
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

        private void cdvMaterial_VersionChanged(object sender, EventArgs e)
        {
            cdvFlow.Text = "";
            cdvFlow.Sequence = 0;

            cdvFlow_ButtonPress(null, null);
        }

        private void cdvFlow_ButtonPress(object sender, System.EventArgs e)
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

        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {
            MPCF.InitListView(cdvResID.GetListView);

            if (MPCF.Trim(cdvOperation.Text) == "")
            {
                cdvResID.RefuseEventExec = true;

                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                cdvOperation.Focus();
                return;
            }
            
            cdvResID.ListCond_Step = '2';
            cdvResID.ListCond_MatID = MPCF.Trim(cdvMaterial.Text);
            cdvResID.ListCond_MatVersion = cdvMaterial.Version;
            cdvResID.ListCond_Flow = MPCF.Trim(cdvFlow.Text);
            cdvResID.ListCond_Oper = MPCF.Trim(cdvOperation.Text);
            cdvResID.ListCond_IncludeDeleteResource = false;
        }

        private void cdvAttributeName_ButtonPress(object sender, EventArgs e)
        {
            cdvAttributeName.Init();
            MPCF.InitListView(cdvAttributeName.GetListView);
            cdvAttributeName.Columns.Add("Attribute Name", 150, HorizontalAlignment.Left);
            cdvAttributeName.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAttributeName.SelectedSubItemIndex = 1;
            cdvAttributeName.DisplaySubItemIndex = 1;

            ViewAttributeNameList();

            cdvAttributeName.AddEmptyRow(1);
        }

        private void cdvOperation_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            ClearData("1");
        }

        private void cdvAttributeValue_ButtonPress(object sender, EventArgs e)
        {
            cdvAttributeValue.Init();
            MPCF.InitListView(cdvAttributeValue.GetListView);
            cdvAttributeValue.Columns.Add("Attribute Value", 150, HorizontalAlignment.Left);
            cdvAttributeValue.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAttributeValue.SelectedSubItemIndex = 0;
            cdvAttributeValue.DisplaySubItemIndex = 0;

            if (string.IsNullOrEmpty(cdvAttributeName.Text) == true) return;

            BASLIST.ViewGCMDataList(cdvAttributeValue.GetListView, '1', cdvAttributeName.GetListView.SelectedItems[0].Tag.ToString());
        }

        private void cdvAttributeName_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvAttributeValue.Text = "";

            if (string.IsNullOrEmpty(cdvAttributeName.Text) == true) return;

            if (string.IsNullOrEmpty(cdvAttributeName.GetListView.SelectedItems[0].Tag.ToString()) == true)
            {
                cdvAttributeValue.VisibleButton = false;
            }
            else
            {
                cdvAttributeValue.VisibleButton = true;
            }
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
    }
}

