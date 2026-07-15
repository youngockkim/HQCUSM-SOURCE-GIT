//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranMultiReceiveLot.cs
//   Description : Multi Receive Lot Transaction
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
//       - 2012-04-09 : Created by DMKIM
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
    public partial class frmWIPTranMultiReceiveLot : Miracom.MESCore.TranForm12
    {
        public frmWIPTranMultiReceiveLot()
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
        private const int OWNER_CODE = 11;
        private const int CREATE_CODE = 12;
        private const int LOT_PRIORITY = 13;
        private const int HOLD_FLAG = 15;
        private const int HOLD_CODE = 16;
        private const int LAST_HIST_SEQ = 101;

        private const int SPD_LOT_ID = 0;
        private const int SPD_NEW_QTY_1 = 1;
        private const int SPD_NEW_QTY_2 = 2;
        private const int SPD_NEW_QTY_3 = 3;
        private const int SPD_CARRIER_ID = 4;
        private const int SPD_CARRIER_ID_BTN = 5;
        private const int SPD_MAT_ID = 6;
        private const int SPD_MAT_ID_BTN = 7;
        private const int SPD_MAT_VER = 8;
        private const int SPD_MAT_VER_BTN = 9;
        private const int SPD_FLOW = 10;
        private const int SPD_FLOW_BTN = 11;
        private const int SPD_FLOW_SEQ = 12;
        private const int SPD_OPER = 13;
        private const int SPD_OPER_BTN = 14;
        private const int SPD_CREATE_CODE = 15;
        private const int SPD_CREATE_CODE_BTN = 16;
        private const int SPD_OWNER_CODE = 17;
        private const int SPD_OWNER_CODE_BTN = 18;
        private const int SPD_PRIORITY = 19;
        private const int SPD_DUE_TIME = 20;
        private const int SPD_CALCULATE_BTN = 21;
        private const int SPD_HOLD_FLAG = 22;
        private const int SPD_HOLD_CODE = 23;

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
                        break;

                    case "2":
                        MPCF.FieldClear(pnlLotInfo);
                        MPCF.ClearList(spdSelLotList);
                        MPCF.FieldClear(grpCMF);

                        lblTotCnt.Text = "";
                        lblTotQty1.Text = "";
                        lblTotQty2.Text = "";
                        lblTotQty3.Text = "";

                        txtComment.Text = "";
                        break;

                    case "3":
                        MPCF.ClearList(spdSelLotList);

                        lblTotCnt.Text = "";
                        lblTotQty1.Text = "";
                        lblTotQty2.Text = "";
                        lblTotQty3.Text = "";

                        txtComment.Text = "";
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
            FarPoint.Win.Spread.SheetView lotlist = spdSelLotList.ActiveSheet;

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

                case "RECEIVE_LOT":

                    iCount = lotlist.RowCount;
                    if (iCount == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(199));
                        tabTran.SelectedTab = tbpLotInfo;
                        return false;
                    }

                    for (i = 0; i < lotlist.RowCount; i++)
                    {
                        if (MPCF.Trim(lotlist.Cells[i, SPD_LOT_ID].Value) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(187));
                            tabTran.SelectedTab = tbpLotInfo;
                            lotlist.ActiveRowIndex = i;
                            return false;
                        }


                        if (MPCF.Trim(lotlist.Cells[i, SPD_NEW_QTY_1].Value) != "")
                        {
                            if (MPCF.CheckNumeric(MPCF.Trim(lotlist.Cells[i, SPD_NEW_QTY_1].Value)) == false)
                            {
                                tabTran.SelectedTab = tbpLotInfo;
                                lotlist.ActiveRowIndex = i;
                                return false;
                            }
                        }

                        if (MPCF.Trim(lotlist.Cells[i, SPD_NEW_QTY_2].Value) != "")
                        {
                            if (MPCF.CheckNumeric(MPCF.Trim(lotlist.Cells[i, SPD_NEW_QTY_2].Value)) == false)
                            {
                                tabTran.SelectedTab = tbpLotInfo;
                                lotlist.ActiveRowIndex = i;
                                return false;
                            }
                        }

                        if (MPCF.Trim(lotlist.Cells[i, SPD_NEW_QTY_3].Value) != "")
                        {
                            if (MPCF.CheckNumeric(MPCF.Trim(lotlist.Cells[i, SPD_NEW_QTY_3].Value)) == false)
                            {
                                tabTran.SelectedTab = tbpLotInfo;
                                lotlist.ActiveRowIndex = i;
                                return false;
                            }
                        }
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
        private bool ViewLotList(char ProcStep)
        {
            int i = 0;

            TRSNode in_node = new TRSNode("VIEW_LOT_LIST_DETAIL_BY_SQL_QUERY_IN");
            TRSNode out_node;
            ArrayList a_list;

            MPCF.ClearList(lisLotList);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = ProcStep;
            in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
            in_node.AddInt("MAT_VER", cdvMaterial.Version);
            in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
            in_node.AddInt("FLOW_SEQ_NUM", cdvFlow.Sequence);
            in_node.AddString("OPER", MPCF.Trim(cdvOperation.Text));
            in_node.AddString("ATTR_NAME", MPCF.Trim(cdvAttributeName.Text));
            in_node.AddString("ATTR_VALUE", MPCF.Trim(cdvAttributeValue.Text));
            in_node.AddChar("ZERO_QTY_FLAG", chkZeroQuantityLot.Checked ? 'Y' : ' ');
            in_node.AddChar("START_END_FLAG", chkOnlyWaitLot.Checked ? 'W' : ' ');

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
                    WIPLIST.DisplayLotListDetail(lisLotList, out_node.GetList(0)[i], 0);
                }
            }
            Cursor.Current = Cursors.Default;

            return true;

        }

        private bool ViewLotListbyShippingID(char ProcStep, string sAttrName, string aAttrValue)
        {
            int i = 0;
            int iRow;
            TRSNode in_node = new TRSNode("VIEW_LOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_LIST_IN");
            ArrayList a_list;

            FarPoint.Win.Spread.SheetView lotlist = spdSelLotList.ActiveSheet;

            //MPCF.ClearList(spdSelLotList);
            //2013.08.29 Midified by DM KIM 조회시 Set Lot List와 관련된 정보 Clear 
            ClearData("3");

            // 2013.08.29 Modified by DM KIM Shipping ID로 조회를 할 경우에는 General Tab에 있는 Lot List의 CheckBox를 모두 해제 한다.
            SetCheckBoxValue(false);

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("ATTR_NAME", sAttrName);
                in_node.AddString("ATTR_VALUE", aAttrValue);

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
                        iRow = lotlist.RowCount;
                        lotlist.RowCount++;

                        lotlist.Cells[iRow, SPD_LOT_ID].Value = out_node.GetList(0)[i].GetString("LOT_ID");
                        lotlist.Cells[iRow, SPD_LOT_ID].Tag = MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("LAST_ACTIVE_HIST_SEQ"));
                        lotlist.Cells[iRow, SPD_NEW_QTY_1].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_1"));
                        lotlist.Cells[iRow, SPD_NEW_QTY_2].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2"));
                        lotlist.Cells[iRow, SPD_NEW_QTY_3].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3"));
                        lotlist.Cells[iRow, SPD_CARRIER_ID].Value = out_node.GetList(0)[i].GetString("CRR_ID");
                        lotlist.Cells[iRow, SPD_MAT_ID].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                        lotlist.Cells[iRow, SPD_MAT_VER].Value = out_node.GetList(0)[i].GetInt("MAT_VER");
                        lotlist.Cells[iRow, SPD_CREATE_CODE].Value = out_node.GetList(0)[i].GetString("CREATE_CODE");
                        lotlist.Cells[iRow, SPD_OWNER_CODE].Value = out_node.GetList(0)[i].GetString("OWNER_CODE");
                        lotlist.Cells[iRow, SPD_PRIORITY].Value = out_node.GetList(0)[i].GetString("PRIORITY");

                        lotlist.Cells[iRow, SPD_HOLD_FLAG].Value = out_node.GetList(0)[i].GetChar("HOLD_FLAG");
                        lotlist.Cells[iRow, SPD_HOLD_CODE].Value = out_node.GetList(0)[i].GetString("HOLD_CODE");
                    }
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            return true;
        }

        //
        // SetCheckBoxValue()
        //       - Setting CheckBox 
        // Return Value
        //       - 
        // Arguments
        //       - ByVal bTrue As Boolean : True Or False 
        //
        public void SetCheckBoxValue(bool bTrue)
        {
            int i;

            for (i = 0; i < lisLotList.Items.Count; i++)
            {
                lisLotList.Items[i].Checked = bTrue;
            }
        }

        //
        // GetFisrtFocusItem()
        //       - Set First Focus Item
        // Return Value
        //       
        // Arguments
        //
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

        // Set_Lot_List()
        //       - Select Lot List To Set Spread Sheet
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        -
        //
        private bool SetLotList()
        {
            int i;
            ArrayList a_item;
            FarPoint.Win.Spread.SheetView lotlist = spdSelLotList.ActiveSheet;

            try
            {
                a_item = new ArrayList();
                for (i = 0; i < lisLotList.Items.Count; i++)
                {
                    if (lisLotList.Items[i].Checked == true)
                    {
                        a_item.Add(lisLotList.Items[i].SubItems[LOT_ID].Text);
                    }
                }

                // Set Lot List To Spread Sheet
                if (a_item.Count > 0)
                {
                    spdSearchItem(lotlist, a_item);
                    lotlist.AutoSortColumn(SPD_LOT_ID, true);
                }
                else
                {
                    lotlist.Rows.Clear();
                }

                // Set Lot Info
                SetLotInfo(lotlist, lisLotList);
                spdCalculate();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        // SetLotInfo()
        //       - Set Lot Information In Spread Sheet 
        // Return Value
        //       -
        // Arguments
        //       - FarPoint.Win.Spread.SheetView spdSheet : Spread SheetView
        //       - ListView lisview : List View
        //
        public void SetLotInfo(FarPoint.Win.Spread.SheetView spdSheet, ListView lisview)
        {
            int i = 0;
            int iRowIndex;
            try
            {
                for (i = 0; i < spdSheet.RowCount; i++)
                {
                    string sTmpLotID = "";
                    sTmpLotID = MPCF.Trim(spdSheet.GetValue(i, SPD_LOT_ID));
                    iRowIndex = MPCF.FindListItemIndex(lisview, sTmpLotID, LOT_ID, false);

                    spdSheet.Cells[i, SPD_LOT_ID].Tag = MPCF.Trim(lisview.Items[iRowIndex].SubItems[LAST_HIST_SEQ].Text);
                    spdSheet.Cells[i, SPD_NEW_QTY_1].Value = MPCF.Trim(lisview.Items[iRowIndex].SubItems[QTY_1].Text);
                    spdSheet.Cells[i, SPD_NEW_QTY_2].Value = MPCF.Trim(lisview.Items[iRowIndex].SubItems[QTY_2].Text);
                    spdSheet.Cells[i, SPD_NEW_QTY_3].Value = MPCF.Trim(lisview.Items[iRowIndex].SubItems[QTY_3].Text);
                    spdSheet.Cells[i, SPD_MAT_ID].Value = MPCF.Trim(lisview.Items[iRowIndex].SubItems[MAT_ID].Text);
                    spdSheet.Cells[i, SPD_MAT_VER].Value = MPCF.Trim(lisview.Items[iRowIndex].SubItems[MAT_VER].Text);
                    //spdSheet.SetValue(i, SPD_FLOW, MPCF.Trim(lisview.Items[iRowIndex].SubItems[FLOW].Text));
                    //spdSheet.SetValue(i, SPD_FLOW_SEQ, MPCF.Trim(lisview.Items[iRowIndex].SubItems[FLOW_SEQ].Text));
                    //spdSheet.SetValue(i, SPD_OPER, MPCF.Trim(lisview.Items[iRowIndex].SubItems[OPER].Text));
                    spdSheet.Cells[i, SPD_CREATE_CODE].Value = MPCF.Trim(lisview.Items[iRowIndex].SubItems[CREATE_CODE].Text);
                    spdSheet.Cells[i, SPD_OWNER_CODE].Value = MPCF.Trim(lisview.Items[iRowIndex].SubItems[OWNER_CODE].Text);
                    spdSheet.Cells[i, SPD_PRIORITY].Value = MPCF.Trim(lisview.Items[iRowIndex].SubItems[LOT_PRIORITY].Text);

                    spdSheet.Cells[i, SPD_HOLD_FLAG].Value = MPCF.Trim(lisview.Items[iRowIndex].SubItems[HOLD_FLAG].Text);
                    spdSheet.Cells[i, SPD_HOLD_CODE].Value = MPCF.Trim(lisview.Items[iRowIndex].SubItems[HOLD_CODE].Text);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        // spdModifyRow()
        //       - Spread Sheet Modified Row
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - FarPoint.Win.Spread.SheetView spdSheet : Spread SheetView
        //       - ArrayList a_item : Lot ID Array List
        //       - int iRowIndex    : Modify Row Index
        //       - strin sCase      : Delete Or Add
        //
        public void spdModifyRow(FarPoint.Win.Spread.SheetView spdSheet, ArrayList a_item, int iRowIndex, string sCase)
        {
            try
            {
                if (sCase == "ADD")
                {
                    // Add Spread Sheet & ArrayList Item
                    spdSheet.Rows.Add(iRowIndex, 1);
                    spdSheet.SetValue(iRowIndex, SPD_LOT_ID, MPCF.Trim(a_item[iRowIndex]));
                }
                else if (sCase == "DEL")
                {
                    // Delete Spread Sheet & ArrayList Item
                    spdSheet.Rows.Remove(iRowIndex, 1);
                }
                else if (sCase == "CHG")
                {
                    spdSheet.SetValue(iRowIndex, SPD_LOT_ID, MPCF.Trim(a_item[iRowIndex]));
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        // spdSearchItem()
        //       - Spread Sheet Serch Item
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - FarPoint.Win.Spread.SheetView spdSheet : Spread SheetView
        //       - ArrayList a_item : Lot ID Array List
        //
        public bool spdSearchItem(FarPoint.Win.Spread.SheetView spdSheet, ArrayList a_item)
        {
            int i, j;
            string sLot;
            bool b_exist_flag = false;
            try
            {
                if (a_item.Count > spdSheet.RowCount)
                {
                    // Add
                    for (i = 0; i < a_item.Count; i++)
                    {
                        if (spdSheet.RowCount > 0)
                        {

                            b_exist_flag = false;
                            for (j = 0; j < spdSheet.RowCount; j++)
                            {
                                sLot = MPCF.Trim(spdSheet.Cells[j, SPD_LOT_ID].Value);
                                if (MPCF.Trim(a_item[i]) == sLot)
                                {
                                    b_exist_flag = true;
                                    break;
                                }
                            }

                            if (b_exist_flag == false)
                            {
                                spdModifyRow(spdSelLotList.ActiveSheet, a_item, i, "ADD");
                                //spdSearchItem(spdSelLotList.ActiveSheet, a_item);
                            }
                        }
                        else
                        {
                            spdModifyRow(spdSelLotList.ActiveSheet, a_item, i, "ADD");
                            //spdSearchItem(spdSelLotList.ActiveSheet, a_item);
                        }
                    }
                }
                else if (a_item.Count < spdSheet.RowCount)
                {
                    if (a_item.Count > 0)
                    {
                        // Delete 

                        for (i = 0; i < spdSheet.RowCount; i++)
                        {
                            b_exist_flag = false;
                            for (j = 0; j < a_item.Count; j++)
                            {
                                sLot = MPCF.Trim(a_item[j]);
                                if (MPCF.Trim(spdSheet.Cells[i, SPD_LOT_ID].Value) == sLot)
                                {
                                    b_exist_flag = true;
                                    break;
                                }
                            }

                            if (b_exist_flag == false)
                            {
                                spdModifyRow(spdSelLotList.ActiveSheet, a_item, i, "DEL");
                                //spdSearchItem(spdSelLotList.ActiveSheet, a_item);
                            }
                        }
                    }
                }
                //else
                //{
                //    if (a_item.Count > 0)
                //    {
                //        int iCnt = 0;
                //        for (i = 0; i < spdSheet.RowCount; i++)
                //        {
                //            sLot = MPCF.Trim(a_item[i]);
                //            if (MPCF.Trim(spdSheet.Cells[i, SPD_LOT_ID].Value) == sLot)
                //            {

                //                iCnt += 1;
                //            }
                //            else
                //            {
                //                spdModifyRow(spdSelLotList.ActiveSheet, a_item, i, "CHG");
                //                spdSearchItem(spdSelLotList.ActiveSheet, a_item);
                //            }

                //        }

                //        if (iCnt == spdSheet.RowCount)
                //        {
                //            return true;
                //        }
                //    }
                //}
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        // SetReceiveInfo()
        //       - Set Carrier ID Information in Spread Sheet
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        - Int IStartRow        : Change Item Start Row
        //        - String sCarrier     : Change Hold Code Value
        //        - String sReleaseCode  : Change Release Code Value
        //        - String sPassword     : Change Password Value
        private bool SetCarrierInfo(int iStartRow, bool b_MultiFlag, string sCarrier)
        {
            int iRow;
            FarPoint.Win.Spread.SheetView lotlist = spdSelLotList.ActiveSheet;

            try
            {
                if (b_MultiFlag == true)
                {
                    for (iRow = iStartRow; iRow < lotlist.RowCount; iRow++)
                    {
                        lotlist.SetValue(iRow, SPD_CARRIER_ID, sCarrier);
                    }
                }
                else
                {
                    lotlist.SetValue(iStartRow, SPD_CARRIER_ID, sCarrier);
                }
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        // View_Material()
        //       - View Material Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool ViewMaterial()
        {
            return ViewMaterial(-1);
        }

        // View_Material()
        //       - View Material Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool ViewMaterial(int iRow)
        {

            TRSNode in_node = new TRSNode("VIEW_MATERIAL_IN");
            TRSNode out_node = new TRSNode("VIEW_MATERIAL_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            if (iRow == -1)
            {
                in_node.AddString("MAT_ID", MPCF.Trim(cdvToMaterial.Text));
                in_node.AddInt("MAT_VER", cdvToMaterial.Version);
            }
            else if (iRow < spdSelLotList_Sheet1.RowCount)
            {
                in_node.AddString("MAT_ID", MPCF.Trim(spdSelLotList_Sheet1.Cells[iRow, SPD_MAT_ID].Value));
                in_node.AddInt("MAT_VER", MPCF.ToInt(spdSelLotList_Sheet1.Cells[iRow, SPD_MAT_VER].Value));
            }

            if (MPCR.CallService("WIP", "WIP_View_Material", in_node, ref out_node, true) == false)
            {
                return false;
            }

            if (iRow == -1)
            {
                cdvToFlow.Text = out_node.GetString("FIRST_FLOW");
                cdvToFlow.Sequence = out_node.GetInt("FIRST_FLOW_SEQ_NUM");
                cdvToOper.Text = out_node.GetString("FIRST_OPER");
            }
            else if (iRow < spdSelLotList_Sheet1.RowCount)
            {
                spdSelLotList_Sheet1.Cells[iRow, SPD_FLOW].Value = out_node.GetString("FIRST_FLOW");
                spdSelLotList_Sheet1.Cells[iRow, SPD_FLOW_SEQ].Value = out_node.GetInt("FIRST_FLOW_SEQ_NUM");
                spdSelLotList_Sheet1.Cells[iRow, SPD_OPER].Value = out_node.GetString("FIRST_OPER");
            }

            return true;

        }

        // View_Flow()
        //       - View Flow Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewFlow()
        {

            TRSNode in_node = new TRSNode("VIEW_FLOW_IN");
            TRSNode out_node = new TRSNode("VIEW_FLOW_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("FLOW", MPCF.Trim(cdvToFlow.Text));

            if (MPCR.CallService("WIP", "WIP_View_Flow", in_node, ref out_node) == false)
            {
                return false;
            }

            cdvToOper.Text = out_node.GetString("FIRST_OPER");

            return true;
        }

        // View_Flow()
        //       - View Flow Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewFlow(int iRow)
        {

            TRSNode in_node = new TRSNode("VIEW_FLOW_IN");
            TRSNode out_node = new TRSNode("VIEW_FLOW_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            if (iRow == -1)
            {
                in_node.AddString("FLOW", MPCF.Trim(cdvToFlow.Text));
            }
            else if (iRow < spdSelLotList_Sheet1.RowCount)
            {
                in_node.AddString("FLOW", MPCF.Trim(spdSelLotList_Sheet1.Cells[iRow, SPD_FLOW].Value));
            }

            if (MPCR.CallService("WIP", "WIP_View_Flow", in_node, ref out_node) == false)
            {
                return false;
            }

            if (iRow == -1)
            {
                cdvToOper.Text = out_node.GetString("FIRST_OPER");
            }
            else if (iRow < spdSelLotList_Sheet1.RowCount)
            {
                spdSelLotList_Sheet1.Cells[iRow, SPD_OPER].Value = out_node.GetString("FIRST_OPER");
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

            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;

            FarPoint.Win.Spread.SheetView lotlist = spdSelLotList.ActiveSheet;

            if (cdvToMaterial.CheckValue() == false)
            {
                return false;
            }
            if (cdvToFlow.CheckValue() == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvToOper, 1) == false)
            {
                return false;
            }


            if (lotlist.RowCount > 0)
            {
                if (MPCF.Trim(lotlist.GetValue(0, SPD_NEW_QTY_1)) == "")
                {
                    dQty1 = 0;
                }
                else
                {
                    dQty1 = MPCF.ToDbl(lotlist.GetValue(0, SPD_NEW_QTY_1));
                }
            }
            else
            {
                dQty1 = 0;
            }

            if (MPCR.GetProcTime(MPCF.Trim(cdvToMaterial.Text), cdvToMaterial.Version, MPCF.Trim(cdvToFlow.Text), cdvToFlow.Sequence, MPCF.Trim(cdvToOper.Text), dQty1, ref dSumQueueTime, ref dSumProcTime, ref dSumQueueProcTime) == false)
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

        //
        // SetDueDate()
        //       - Due Date Auto Calculation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool SetDueDate(int iRow)
        {

            double dSumQueueTime = 0;
            double dSumProcTime = 0;
            double dSumQueueProcTime = 0;
            double dQty1 = 0;

            FarPoint.Win.Spread.SheetView lotlist = spdSelLotList.ActiveSheet;

            if (MPCF.Trim(lotlist.GetValue(iRow, SPD_MAT_ID)) == "" ||
                MPCF.ToInt(lotlist.GetValue(iRow, SPD_MAT_VER)) == 0 ||
                MPCF.Trim(lotlist.GetValue(iRow, SPD_FLOW)) == "" ||
                MPCF.ToInt(lotlist.GetValue(iRow, SPD_FLOW_SEQ)) == 0 ||
                MPCF.Trim(lotlist.GetValue(iRow, SPD_OPER)) == "")
            {
                lotlist.Cells[iRow, SPD_DUE_TIME].Value = "";
                return false;
            }

            dQty1 = MPCF.ToDbl(lotlist.GetValue(iRow, SPD_NEW_QTY_1));

            if (MPCR.GetProcTime(MPCF.Trim(lotlist.GetValue(iRow, SPD_MAT_ID)),
                                    MPCF.ToInt(lotlist.GetValue(iRow, SPD_MAT_VER)),
                                    MPCF.Trim(lotlist.GetValue(iRow, SPD_FLOW)),
                                    MPCF.ToInt(lotlist.GetValue(iRow, SPD_FLOW_SEQ)),
                                    MPCF.Trim(lotlist.GetValue(iRow, SPD_OPER)),
                                    dQty1,
                                    ref dSumQueueTime,
                                    ref dSumProcTime,
                                    ref dSumQueueProcTime) == false)
            {
                lotlist.Cells[iRow, SPD_DUE_TIME].Value = "";
                return false;
            }

            if (MPGO.CycleTimeUnit() == "M")
            {
                lotlist.Cells[iRow, SPD_DUE_TIME].Value = DateTime.Now.AddMinutes(dSumQueueProcTime);
            }
            else
            {
                lotlist.Cells[iRow, SPD_DUE_TIME].Value = DateTime.Now.AddHours(dSumQueueProcTime);
            }
            //txtDueDate.Text = MPCF.MakeDateFormat(MPCF.ToStandardTime(dtpDueDate.Value, MPGC.MP_CONVERT_DATE_FORMAT), DATE_TIME_FORMAT.DATE);
            return true;
        }

        // Multi_Receive_Lot()
        //       - Multi Receive Lot transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - char ProcStep : Process Step
        private bool MultiReceiveLot(char ProcStep)
        {
            TRSNode in_node = new TRSNode("MULTI_RECEIVE_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode list_item;

            DateTime due_time = DateTime.MinValue;

            FarPoint.Win.Spread.SheetView lotlist = spdSelLotList.ActiveSheet;
            int i = 0;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }

                if (chkCommitCond.Checked == true)
                    in_node.AddChar("EACH_COMMIT_FLAG", 'Y');
                else
                    in_node.AddChar("EACH_COMMIT_FLAG", 'N');

                in_node.AddChar("AUTO_GET_MFO", 'Y');

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
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

                in_node.AddChar("BIND_SAME_TR_FLAG", chkBindSameTr.Checked == true ? 'Y' : ' ');

                for (i = 0; i < lotlist.RowCount; i++)
                {
                    list_item = in_node.AddNode("LOT_LIST");

                    list_item.AddString("LOT_ID", MPCF.Trim(lotlist.Cells[i, SPD_LOT_ID].Value));
                    list_item.AddInt("LAST_ACTIVE_HIST_SEQ", MPCF.Trim(lotlist.Cells[i, SPD_LOT_ID].Tag));
                    list_item.AddDouble("QTY_1", (MPCF.Trim(lotlist.Cells[i, SPD_NEW_QTY_1].Value) == "") ? -1 : (MPCF.ToDbl(lotlist.Cells[i, SPD_NEW_QTY_1].Value)));
                    list_item.AddDouble("QTY_2", (MPCF.Trim(lotlist.Cells[i, SPD_NEW_QTY_2].Value) == "") ? -1 : (MPCF.ToDbl(lotlist.Cells[i, SPD_NEW_QTY_2].Value)));
                    list_item.AddDouble("QTY_3", (MPCF.Trim(lotlist.Cells[i, SPD_NEW_QTY_3].Value) == "") ? -1 : (MPCF.ToDbl(lotlist.Cells[i, SPD_NEW_QTY_3].Value)));
                    list_item.AddString("TO_MAT_ID", MPCF.Trim(lotlist.Cells[i, SPD_MAT_ID].Value));
                    list_item.AddInt("TO_MAT_VER", MPCF.ToInt(lotlist.Cells[i, SPD_MAT_VER].Value));
                    list_item.AddString("TO_FLOW", MPCF.Trim(lotlist.Cells[i, SPD_FLOW].Value));
                    list_item.AddInt("TO_FLOW_SEQ_NUM", MPCF.ToInt(lotlist.Cells[i, SPD_FLOW_SEQ].Value));
                    list_item.AddString("TO_OPER", MPCF.Trim(lotlist.Cells[i, SPD_OPER].Value));
                    list_item.AddString("CREATE_CODE", MPCF.Trim(lotlist.Cells[i, SPD_CREATE_CODE].Value));
                    list_item.AddString("OWNER_CODE", MPCF.Trim(lotlist.Cells[i, SPD_OWNER_CODE].Value));
                    list_item.AddChar("LOT_PRIORITY", (MPCF.Trim(lotlist.Cells[i, SPD_PRIORITY].Value) == "") ? '5' : (MPCF.ToChar(lotlist.Cells[i, SPD_PRIORITY].Value)));
                    if (MPCF.Trim(spdSelLotList_Sheet1.Cells[i, SPD_DUE_TIME].Value) != "")
                    {
                        DateTime.TryParse(lotlist.Cells[i, SPD_DUE_TIME].Value.ToString(), out due_time);
                        list_item.AddString("DUE_TIME", MPCF.ToStandardTime(due_time, MPGC.MP_CONVERT_DATE_FORMAT));
                    }

#if _CRR
                    list_item.AddString("CRR_ID", MPCF.Trim(lotlist.Cells[i, SPD_CARRIER_ID].Value));
#endif //_CRR
                }

                if (MPCR.CallService("WIP", "WIP_Multi_Receive_Lot", in_node, ref out_node) == false)
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

        private void spdCalculate()
        {
            int i = 0;
            int iTotLotCnt = 0;
            double dSumQty1 = 0;
            double dSumQty2 = 0;
            double dSumQty3 = 0;

            try
            {
                lblTotCnt.Text = "";
                lblTotQty1.Text = "";
                lblTotQty2.Text = "";
                lblTotQty3.Text = "";
                if (spdSelLotList.ActiveSheet.RowCount > 0)
                {
                    for (i = 0; i < spdSelLotList.ActiveSheet.RowCount; i++)
                    {
                        // Lot Count
                        if (MPCF.Trim(spdSelLotList.ActiveSheet.Cells[i, SPD_LOT_ID].Value) != "")
                        {
                            iTotLotCnt += 1;

                            // Move Qty1
                            dSumQty1 += MPCF.ToDbl(spdSelLotList.ActiveSheet.Cells[i, SPD_NEW_QTY_1].Value);

                            // Move Qty2
                            dSumQty2 += MPCF.ToDbl(spdSelLotList.ActiveSheet.Cells[i, SPD_NEW_QTY_2].Value);

                            // Move Qty3
                            dSumQty3 += MPCF.ToDbl(spdSelLotList.ActiveSheet.Cells[i, SPD_NEW_QTY_3].Value);
                        }
                    }

                    lblTotCnt.Text = MPCF.FindLanguage("Total Count :  ", CAPTION_TYPE.LABEL) + iTotLotCnt;
                    lblTotQty1.Text = MPCF.FindLanguage("New Qty1 :  ", CAPTION_TYPE.LABEL) + dSumQty1;
                    lblTotQty2.Text = MPCF.FindLanguage("New Qty2 :  ", CAPTION_TYPE.LABEL) + dSumQty2;
                    lblTotQty3.Text = MPCF.FindLanguage("New Qty3 :  ", CAPTION_TYPE.LABEL) + dSumQty3;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private bool SetRecieveInfo()
        {
            FarPoint.Win.Spread.SheetView lotlist = spdSelLotList.ActiveSheet;
            int i;

            try
            {
                for (i = 0; i < lotlist.RowCount; i++)
                {
                    SetRecieveInfo(i);
                }
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        private bool SetRecieveInfo(int iRow)
        {
            FarPoint.Win.Spread.SheetView lotlist = spdSelLotList.ActiveSheet;

            try
            {
                if (MPCF.Trim(cdvToMaterial.Text) != "" && cdvToMaterial.Version > 0)
                {
                    lotlist.Cells[iRow, SPD_MAT_ID].Value = MPCF.Trim(cdvToMaterial.Text);
                    lotlist.Cells[iRow, SPD_MAT_VER].Value = cdvToMaterial.Version;
                }
                if (MPCF.Trim(cdvToFlow.Text) != "" && cdvToFlow.Sequence > 0)
                {
                    lotlist.Cells[iRow, SPD_FLOW].Value = MPCF.Trim(cdvToFlow.Text);
                    lotlist.Cells[iRow, SPD_FLOW_SEQ].Value = cdvToFlow.Sequence;
                }
                if (MPCF.Trim(cdvToOper.Text) != "")
                {
                    lotlist.Cells[iRow, SPD_OPER].Value = MPCF.Trim(cdvToOper.Text);
                }
                if (MPCF.Trim(cdvCreateCode.Text) != "")
                {
                    lotlist.Cells[iRow, SPD_CREATE_CODE].Value = MPCF.Trim(cdvCreateCode.Text);
                }
                if (MPCF.Trim(cdvOwnerCode.Text) != "")
                {
                    lotlist.Cells[iRow, SPD_OWNER_CODE].Value = MPCF.Trim(cdvOwnerCode.Text);
                }
                if (cboPriority.Text != "")
                {
                    lotlist.Cells[iRow, SPD_PRIORITY].Value = MPCF.Trim(cboPriority.Text);
                }
                if (chkDueDate.Checked == true)
                {
                    lotlist.Cells[iRow, SPD_DUE_TIME].Value = MPCF.Trim(dtpDueDate.Value);
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

        private void frmWIPTranMultiReceiveLot_Load(object sender, System.EventArgs e)
        {
            lisLotList.CheckBoxes = true;

            if (this.DesignMode == true)
                pnlTranTime.Visible = true;
            else
                pnlTranTime.Visible = MPGO.UseBackDate();

            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;
        }

        private void frmWIPTranMultiReceiveLot_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    ClearData("1");
                    MPCF.InitListView(lisLotList);
                    SetCMFItem(MPGC.MP_CMF_TRN_RECEIVE);

                    cdvOperation.Init();
                    MPCF.InitListView(cdvOperation.GetListView);
                    cdvOperation.Columns.Add("Oper", 150, HorizontalAlignment.Left);
                    cdvOperation.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                    cdvOperation.SelectedSubItemIndex = 0;
                    cdvOperation.DisplaySubItemIndex = 0;

                    WIPLIST.ViewOperationList(cdvOperation.GetListView, '5');

                    FarPoint.Win.Spread.CellType.ButtonCellType CellButton = null;
                    CellButton = (FarPoint.Win.Spread.CellType.ButtonCellType)spdSelLotList_Sheet1.Columns[SPD_CALCULATE_BTN].CellType;
                    CellButton.Text = MPCF.FindLanguage("Caculation", CAPTION_TYPE.BUTTON);
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
            ClearData("2");
            ViewLotList('1');
            tabTran.SelectedTab = tbpGeneral;
        }

        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("RECEIVE_LOT") == false) return;

                if (MultiReceiveLot('1') == false)
                {
                    return;
                }

                ClearData("2");

                if (ViewLotList('1') == false) return;
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

        private void btnApply_Click(object sender, EventArgs e)
        {
            SetRecieveInfo();
        }

        private void btnShippingIDView_Click(object sender, EventArgs e)
        {
            
            if (MPCF.CheckValue(cdvShippingID, 1) == false)
            {
                tabTran.SelectedTab = tbpLotInfo;
                cdvShippingID.Focus();
                return;
            }

            // 2013.08.29 Modified by DM KIM 출하번호로 조회시 General Tab에 있는 정보도 같이 Clear
            ViewLotListbyShippingID('1', "SHIPPING_ID", MPCF.Trim(cdvShippingID.Text));
            spdCalculate();
        }

        private void spdSelLotList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                string s_mat_id = MPCF.Trim(spdSelLotList_Sheet1.Cells[e.Row, SPD_MAT_ID].Value);
                int i_mat_ver = MPCF.ToInt(spdSelLotList_Sheet1.Cells[e.Row, SPD_MAT_VER].Value);
                string s_flow = MPCF.Trim(spdSelLotList_Sheet1.Cells[e.Row, SPD_FLOW].Value);
                string s_oper = MPCF.Trim(spdSelLotList_Sheet1.Cells[e.Row, SPD_OPER].Value);

                if (e.Column == SPD_CARRIER_ID_BTN)
                {
#if _CRR
                    try
                    {
                        cdvSpdCrrID.Init();
                        cdvSpdCrrID.ViewPosition = Control.MousePosition;
                        MPCF.InitListView(cdvSpdCrrID.GetListView);
                        cdvSpdCrrID.Columns.Add("Code", 50, HorizontalAlignment.Left);
                        cdvSpdCrrID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                        if (RASLIST.ViewCarrierList(cdvSpdCrrID.GetListView, '2', "", "", "", ' ', s_mat_id, i_mat_ver, s_flow, s_oper, "", "", "", null, "") == false)
                        {
                            return;
                        }
                        if (cdvSpdCrrID.ShowPopupList(e.Row, e.Column) == false)
                        {
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMsgBox(ex.Message);
                    }
#endif //_CRR
                }
                else if (e.Column == SPD_CALCULATE_BTN)
                {
                    SetDueDate(e.Row);
                }
                else
                {
                    cdvCodeView.Init();
                    MPCF.InitListView(cdvCodeView.GetListView);
                    switch (e.Column)
                    {
                        case SPD_MAT_ID_BTN:
                            cdvCodeView.Columns.Add("Code", 50, HorizontalAlignment.Left);
                            cdvCodeView.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                            cdvCodeView.Columns.Add("Ver", 50, HorizontalAlignment.Left);
                            WIPLIST.ViewMaterialList(cdvCodeView.GetListView, '1', true);
                            break;
                        case SPD_MAT_VER_BTN:
                            cdvCodeView.Columns.Add("Ver", 50, HorizontalAlignment.Left);
                            WIPLIST.ViewMaterialVersionList(cdvCodeView.GetListView, '1', s_mat_id);
                            break;
                        case SPD_FLOW_BTN:
                            cdvCodeView.Columns.Add("Flow", 100, HorizontalAlignment.Left);
                            cdvCodeView.Columns.Add("Sequence", 100, HorizontalAlignment.Left);
                            cdvCodeView.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                            WIPLIST.ViewFlowList(cdvCodeView.GetListView, '2', s_mat_id, i_mat_ver);
                            break;
                        case SPD_OPER_BTN:
                            cdvCodeView.Columns.Add("Code", 50, HorizontalAlignment.Left);
                            cdvCodeView.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                            WIPLIST.ViewOperationList(cdvCodeView.GetListView, '2', s_mat_id, i_mat_ver, s_flow, "", null, "");
                            break;
                        case SPD_CREATE_CODE_BTN:
                            cdvCodeView.Columns.Add("Code", 50, HorizontalAlignment.Left);
                            cdvCodeView.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                            BASLIST.ViewGCMDataList(cdvCodeView.GetListView, '1', MPGC.MP_WIP_CREATE_CODE);
                            break;
                        case SPD_OWNER_CODE_BTN:
                            cdvCodeView.Columns.Add("Code", 50, HorizontalAlignment.Left);
                            cdvCodeView.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                            BASLIST.ViewGCMDataList(cdvCodeView.GetListView, '1', MPGC.MP_WIP_OWNER_CODE);
                            break;
                    }

                    cdvCodeView.ViewPosition = Control.MousePosition;
                    cdvCodeView.ShowPopupList(e.Row, e.Column);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdSelLotList_EditModeOff(object sender, EventArgs e)
        {
            spdCalculate();
        }

        private void lisLotList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            SetLotList();
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

        private void chkDueDate_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            txtDueDate.Visible = !chkDueDate.Checked;
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

        private void cdvToMaterial_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            cdvToFlow.Text = "";
            cdvToOper.Text = "";

            if (ViewMaterial() == false)
            {
                return;
            }

        }

        private void cdvToMaterial_TextBoxTextChanged(object sender, System.EventArgs e)
        {

            chkDueDate.Checked = false;
            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;

            cdvToFlow.Text = "";
            cdvToOper.Text = "";

        }

        private void cdvToFlow_ButtonPress(object sender, System.EventArgs e)
        {

            if (cdvToMaterial.CheckValue() == false) return;

            cdvToFlow.ListCond_MatID = cdvToMaterial.Text;
            cdvToFlow.ListCond_MatVersion = cdvToMaterial.Version;
        }

        private void cdvToFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            if (ViewFlow() == false)
            {
                return;
            }

        }

        private void cdvToFlow_TextBoxTextChanged(object sender, System.EventArgs e)
        {

            chkDueDate.Checked = false;
            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;

            cdvToOper.Text = "";

        }

        private void cdvToOper_TextBoxTextChanged(object sender, System.EventArgs e)
        {

            chkDueDate.Checked = false;
            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;

            //txtNewQty1.Text = "";
            //txtNewQty2.Text = "";
            //txtNewQty3.Text = "";

        }

        private void cdvToOper_ButtonPress(object sender, System.EventArgs e)
        {

            if (cdvToMaterial.CheckValue() == false) return;
            if (cdvToFlow.CheckValue() == false) return;

            cdvToOper.Init();
            MPCF.InitListView(cdvToOper.GetListView);
            cdvToOper.Columns.Add("Oper", 150, HorizontalAlignment.Left);
            cdvToOper.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvToOper.SelectedSubItemIndex = 0;

            WIPLIST.ViewOperationList(cdvToOper.GetListView, '2', "", 0, cdvToFlow.Text, "", null, "");

        }

        private void cdvCreateCode_ButtonPress(object sender, System.EventArgs e)
        {

            cdvCreateCode.Init();
            MPCF.InitListView(cdvCreateCode.GetListView);
            cdvCreateCode.Columns.Add("Code", 150, HorizontalAlignment.Left);
            cdvCreateCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvCreateCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvCreateCode.GetListView, '1', MPGC.MP_WIP_CREATE_CODE);

        }

        private void cdvOwnerCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvOwnerCode.Init();
            MPCF.InitListView(cdvOwnerCode.GetListView);
            cdvOwnerCode.Columns.Add("Code", 150, HorizontalAlignment.Left);
            cdvOwnerCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvOwnerCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvOwnerCode.GetListView, '1', MPGC.MP_WIP_OWNER_CODE);
        }

        private void cdvSpdCrrID_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            SetCarrierInfo(e.Row, false, MPCF.Trim(e.SelectedItem.SubItems[0].Text));
        }

        private void cdvShippingID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnShippingIDView.PerformClick();
            }
        }

        private void cdvCodeView_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            try
            {
                switch (e.Col)
                {
                    case (int)SPD_MAT_ID_BTN:
                        spdSelLotList_Sheet1.Cells[e.Row, (int)SPD_MAT_ID].Value = e.SelectedItem.Text;
                        spdSelLotList_Sheet1.Cells[e.Row, (int)SPD_MAT_VER].Value = e.SelectedItem.SubItems[1].Text;
                        spdSelLotList_Sheet1.Cells[e.Row, (int)SPD_FLOW].Value = "";
                        spdSelLotList_Sheet1.Cells[e.Row, (int)SPD_FLOW_SEQ].Value = "";
                        spdSelLotList_Sheet1.Cells[e.Row, (int)SPD_OPER].Value = "";
                        spdSelLotList_Sheet1.Cells[e.Row, (int)SPD_DUE_TIME].Value = "";
                        break;
                    case (int)SPD_MAT_VER_BTN:
                        spdSelLotList_Sheet1.Cells[e.Row, (int)SPD_MAT_VER].Value = e.SelectedItem.Text;
                        spdSelLotList_Sheet1.Cells[e.Row, (int)SPD_FLOW].Value = "";
                        spdSelLotList_Sheet1.Cells[e.Row, (int)SPD_FLOW_SEQ].Value = "";
                        spdSelLotList_Sheet1.Cells[e.Row, (int)SPD_OPER].Value = "";
                        spdSelLotList_Sheet1.Cells[e.Row, (int)SPD_DUE_TIME].Value = "";
                        break;
                    case (int)SPD_FLOW_BTN:
                        spdSelLotList_Sheet1.Cells[e.Row, (int)SPD_FLOW].Value = e.SelectedItem.Text;
                        spdSelLotList_Sheet1.Cells[e.Row, (int)SPD_FLOW_SEQ].Value = e.SelectedItem.SubItems[1].Text;
                        spdSelLotList_Sheet1.Cells[e.Row, (int)SPD_OPER].Value = "";
                        spdSelLotList_Sheet1.Cells[e.Row, (int)SPD_DUE_TIME].Value = "";
                        break;
                    case (int)SPD_OPER_BTN:
                        spdSelLotList_Sheet1.Cells[e.Row, (int)SPD_OPER].Value = e.SelectedItem.Text;
                        spdSelLotList_Sheet1.Cells[e.Row, (int)SPD_DUE_TIME].Value = "";
                        break;
                    case (int)SPD_CREATE_CODE_BTN:
                        spdSelLotList_Sheet1.Cells[e.Row, (int)SPD_CREATE_CODE].Value = e.SelectedItem.Text;
                        break;
                    case (int)SPD_OWNER_CODE_BTN:
                        spdSelLotList_Sheet1.Cells[e.Row, (int)SPD_OWNER_CODE].Value = e.SelectedItem.Text;
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtScanLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && MPCF.Trim(txtScanLotID.Text) != "" && lisLotList.Items.Count > 0)
            {
                int i_lot_index = MPCF.FindListItemIndex(lisLotList, txtScanLotID.Text, 1, false);
                if (i_lot_index < 0) return;

                lisLotList.Items[i_lot_index].Checked = true;
                txtScanLotID.Text = "";
            }
        }


    }
}
