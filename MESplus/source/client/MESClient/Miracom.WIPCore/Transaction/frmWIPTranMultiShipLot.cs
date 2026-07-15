//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranMultiShipLot.cs
//   Description : Multi Ship Lot Transaction
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
    public partial class frmWIPTranMultiShipLot : Miracom.MESCore.TranForm12
    {
        public frmWIPTranMultiShipLot()
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
        private const int HOLD_FLAG = 15;
        private const int HOLD_CODE = 16;
        private const int LAST_HIST_SEQ = 101;

        private const int SPD_LOT_ID = 0;
        private const int SPD_SHIP_FACTORY = 1;
        private const int SPD_SHIP_CODE = 3;
        private const int SPD_SHIP_OPERATION = 5;
        private const int SPD_MAT_ID = 6;
        private const int SPD_HOLD_FLAG = 7;
        private const int SPD_HOLD_CODE = 8;
        private const int SPD_QTY_1 = 9;
        private const int SPD_QTY_2 = 10;
        private const int SPD_QTY_3 = 11;

        private const string MP_STR_SHIPPING_ID = "SHIPPING_ID";


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

                case "SHIP_ID":
                    if (MPCF.CheckValue(cdvOperation, 1) == false)
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        cdvOperation.Focus();
                        return false;
                    }
                    break;

                case "SHIP_LOT":

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
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            tabTran.SelectedTab = tbpLotInfo;
                            lotlist.ActiveRowIndex = i;
                            return false;
                        }

                        if (MPCF.Trim(lotlist.Cells[i, SPD_SHIP_FACTORY].Value) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            tabTran.SelectedTab = tbpLotInfo;
                            lotlist.ActiveRowIndex = i;
                            return false;
                        }

                        if (MPCF.Trim(lotlist.Cells[i, SPD_SHIP_CODE].Value) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            tabTran.SelectedTab = tbpLotInfo;
                            lotlist.ActiveRowIndex = i;
                            return false;
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
                    WIPLIST.DisplayLotListDetail(lisLotList, out_node.GetList(0)[i], 0);
                }
            }
            Cursor.Current = Cursors.Default;


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
            catch(Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
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

        // Set_ToFactory_ShipOper()
        //       - Set To Factory & Ship Operation & Ship Code in Spread Sheet
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        - Int IStartRow     : Change Item Start Row
        //        - String sToFactory : Change To Factory Code Value
        //        - String sShipCode  : Change Ship Code Code Value
        //        - String sShipOper  : Change Ship Operation Code Value
        private bool SetShipInfo(int iStartRow, bool b_MultiFlag, string sToFactory, string sShipCode, string sShipOper)
        {
            int iRow;
            FarPoint.Win.Spread.SheetView lotlist = spdSelLotList.ActiveSheet;

            try
            {
                if (b_MultiFlag == true)
                {
                    for (iRow = iStartRow; iRow < lotlist.RowCount; iRow++)
                    {
                       
                        lotlist.SetValue(iRow, SPD_SHIP_FACTORY, sToFactory);
                        lotlist.SetValue(iRow, SPD_SHIP_CODE, sShipCode);
                        lotlist.SetValue(iRow, SPD_SHIP_OPERATION, sShipOper);
                    }
                }
                else
                {
                    if (sToFactory != null)
                    {
                        lotlist.SetValue(iStartRow, SPD_SHIP_FACTORY, sToFactory);
                    }

                    if (sShipCode != null)
                    {
                        lotlist.SetValue(iStartRow, SPD_SHIP_CODE, sShipCode);
                    }

                    if (sShipOper != null)
                    {
                        lotlist.SetValue(iStartRow, SPD_SHIP_OPERATION, sShipOper);
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
                    spdSheet.SetTag(i, SPD_LOT_ID, MPCF.Trim(lisview.Items[iRowIndex].SubItems[LAST_HIST_SEQ].Text));
                    spdSheet.SetValue(i, SPD_MAT_ID, MPCF.Trim(lisview.Items[iRowIndex].SubItems[MAT_ID].Text));
                    spdSheet.SetValue(i, SPD_HOLD_FLAG, MPCF.Trim(lisview.Items[iRowIndex].SubItems[HOLD_FLAG].Text));
                    spdSheet.SetValue(i, SPD_HOLD_CODE, MPCF.Trim(lisview.Items[iRowIndex].SubItems[HOLD_CODE].Text));
                    spdSheet.SetValue(i, SPD_QTY_1, MPCF.Trim(lisview.Items[iRowIndex].SubItems[QTY_1].Text));
                    spdSheet.SetValue(i, SPD_QTY_2, MPCF.Trim(lisview.Items[iRowIndex].SubItems[QTY_2].Text));
                    spdSheet.SetValue(i, SPD_QTY_3, MPCF.Trim(lisview.Items[iRowIndex].SubItems[QTY_3].Text));
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        // Multi_Ship_Lot()
        //       -   Multi Ship Lot transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //       - ByVal iRowIndex As Int   : Row Index
        //
        private bool MultiShipLot(char ProcStep)
        {
            int i = 0;
            TRSNode in_node = new TRSNode("MULTI_SHIP_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode list_item;
            TRSNode item_in;
            TRSNode item_value;

            FarPoint.Win.Spread.SheetView lotlist = spdSelLotList.ActiveSheet;

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
                    list_item.AddString("SHIP_CODE", MPCF.Trim(lotlist.Cells[i, SPD_SHIP_CODE].Value));
                    list_item.AddString("TO_FACTORY", MPCF.Trim(lotlist.Cells[i, SPD_SHIP_FACTORY].Value));
                    list_item.AddString("TO_OPER", MPCF.Trim(lotlist.Cells[i, SPD_SHIP_OPERATION].Value));

                    if (MPCF.Trim(txtShippingID.Text) != "")
                    {
                        item_in = list_item.AddNode("INPUT_ATTRIBUTE");
                        item_in.AddString("ATTR_TYPE", MPGC.MP_ATTR_TYPE_LOT);
                        item_in.AddString("ATTR_KEY", MPCF.Trim(lotlist.Cells[i, SPD_LOT_ID].Value));

                        item_value = item_in.AddNode("VALUE_LIST");
                        item_value.AddString("ATTR_NAME", MP_STR_SHIPPING_ID);
                        item_value.AddString("ATTR_VALUE", MPCF.Trim(txtShippingID.Text));
                    }
                }

              

                if (MPCR.CallService("WIP", "WIP_Multi_Ship_Lot", in_node, ref out_node) == false)
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

        //
        // Generate_ID()
        //       - Generate Shipping ID
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool GenerateID()
        {

            TRSNode in_node = new TRSNode("GENERATE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                //in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                //in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                //in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddString("OPER", MPCF.Trim(cdvOperation.Text));
                in_node.AddChar("REL_LEVEL", '1');
                in_node.AddString("TRAN_CODE", "SHIP");
                //in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                //in_node.AddString("SEQ_KEY_1", MPCF.Trim(txtLotID.Text));

                if (MPCR.CallService("WIP", "WIP_Generate_ID", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtShippingID.Text = MPCF.Trim(out_node.GetString("GEN_ID"));
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
                            dSumQty1 += MPCF.ToDbl(spdSelLotList.ActiveSheet.Cells[i, SPD_QTY_1].Value);

                            // Move Qty2
                            dSumQty2 += MPCF.ToDbl(spdSelLotList.ActiveSheet.Cells[i, SPD_QTY_2].Value);

                            // Move Qty3
                            dSumQty3 += MPCF.ToDbl(spdSelLotList.ActiveSheet.Cells[i, SPD_QTY_3].Value);
                        }
                    }

                    lblTotCnt.Text = MPCF.FindLanguage("Total Count :  ", CAPTION_TYPE.LABEL) + iTotLotCnt;
                    lblTotQty1.Text = MPCF.FindLanguage("Qty1 :  ", CAPTION_TYPE.LABEL) + dSumQty1;
                    lblTotQty2.Text = MPCF.FindLanguage("Qty2 :  ", CAPTION_TYPE.LABEL) + dSumQty2;
                    lblTotQty3.Text = MPCF.FindLanguage("Qty3 :  ", CAPTION_TYPE.LABEL) + dSumQty3;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        #endregion

        private void frmWIPTranMultiShipLot_Load(object sender, System.EventArgs e)
        {
            lisLotList.CheckBoxes = true;

            if (this.DesignMode == true)
                pnlTranTime.Visible = true;
            else
                pnlTranTime.Visible = MPGO.UseBackDate();

            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;
        }

        private void frmWIPTranMultiShipLot_Activated(object sender, System.EventArgs e)
        {

            try
            {
                if (b_load_flag == false)
                {
                    ClearData("1");
                    MPCF.InitListView(lisLotList);
                    SetCMFItem(MPGC.MP_CMF_TRN_SHIP);

                    cdvOperation.Init();
                    MPCF.InitListView(cdvOperation.GetListView);
                    cdvOperation.Columns.Add("Oper", 150, HorizontalAlignment.Left);
                    cdvOperation.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                    cdvOperation.SelectedSubItemIndex = 0;
                    cdvOperation.DisplaySubItemIndex = 0;

                    WIPLIST.ViewOperationList(cdvOperation.GetListView, '7');

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
            ViewLotList();
        }

        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("SHIP_LOT") == false) return;

                if (MultiShipLot('1') == false)
                {
                    return;
                }

                ClearData("2");
                
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

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (spdSelLotList.ActiveSheet.RowCount > 0)
            {
                int iRow = spdSelLotList.ActiveSheet.ActiveRowIndex;
                SetShipInfo(iRow, true, MPCF.Trim(cdvToFactory.Text), MPCF.Trim(cdvShipCode.Text), MPCF.Trim(txtToOper.Text));
            }
        }

        private void btnGenShippingID_Click(object sender, EventArgs e)
        {
            if (CheckCondition("SHIP_ID") == false) return;

            if (GenerateID() == false)
            {
                txtShippingID.Focus();
                return;
            }
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

        private void cdvToFactory_ButtonPress(object sender, System.EventArgs e)
        {
            cdvToFactory.Init();
            MPCF.InitListView(cdvToFactory.GetListView);
            cdvToFactory.Columns.Add("ToFactory", 150, HorizontalAlignment.Left);
            cdvToFactory.Columns.Add("Oper", 200, HorizontalAlignment.Left);
            cdvToFactory.SelectedSubItemIndex = 0;
            WIPLIST.ViewShipFacList(cdvToFactory.GetListView, '1', null, "");

        }

        private void cdvShipCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvShipCode.Init();
            MPCF.InitListView(cdvShipCode.GetListView);
            cdvShipCode.Columns.Add("Code", 150, HorizontalAlignment.Left);
            cdvShipCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvShipCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvShipCode.GetListView, '1', MPGC.MP_WIP_SHIP_CODE);
        }

        private void cdvToFactory_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            txtToOper.Text = MPCF.Trim(e.SelectedItem.SubItems[1].Text);
        }

        private void cdvspdToFactory_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            SetShipInfo(e.Row, false, MPCF.Trim(e.SelectedItem.SubItems[0].Text), null, MPCF.Trim(e.SelectedItem.SubItems[1].Text));
        }

        private void cdvspdShipCode_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            SetShipInfo(e.Row, false, null, MPCF.Trim(e.SelectedItem.SubItems[0].Text), null);
        }

        private void spdSelLotList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column == SPD_SHIP_FACTORY + 1)
                {
                    cdvspdToFactory.Init();
                    cdvspdToFactory.ViewPosition = Control.MousePosition;
                    MPCF.InitListView(cdvspdToFactory.GetListView);
                    cdvspdToFactory.Columns.Add("ToFactory", 150, HorizontalAlignment.Left);
                    cdvspdToFactory.Columns.Add("Oper", 200, HorizontalAlignment.Left); ;
                    WIPLIST.ViewShipFacList(cdvspdToFactory.GetListView, '1', null, "");
                    if (cdvspdToFactory.ShowPopupList(e.Row, e.Column) == false)
                    {
                        return;
                    }
                }
                else if (e.Column == SPD_SHIP_CODE + 1)
                {

                    cdvspdShipCode.Init();
                    cdvspdShipCode.ViewPosition = Control.MousePosition;
                    MPCF.InitListView(cdvspdShipCode.GetListView);
                    cdvspdShipCode.Columns.Add("Code", 150, HorizontalAlignment.Left);
                    cdvspdShipCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                    BASLIST.ViewGCMDataList(cdvspdShipCode.GetListView, '1', MPGC.MP_WIP_SHIP_CODE);
                    if (cdvspdShipCode.ShowPopupList(e.Row, e.Column) == false)
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
