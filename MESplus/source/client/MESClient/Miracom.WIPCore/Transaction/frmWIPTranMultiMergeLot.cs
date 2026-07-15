//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranMultiMergeLot.cs
//   Description : Multi Merge Lot Transaction
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
    public partial class frmWIPTranMultiMergeLot : Miracom.MESCore.TranForm12
    {
        public frmWIPTranMultiMergeLot()
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
        private const int SPD_MOVE_QTY_1 = 1;
        private const int SPD_MOVE_QTY_2 = 2;
        private const int SPD_MOVE_QTY_3 = 3;
        private const int SPD_CARRIER_ID = 4;
        private const int SPD_MAT_ID = 6;
        private const int SPD_HOLD_FLAG = 7;
        private const int SPD_HOLD_CODE = 8;
        private const int SPD_QTY_1 = 9;
        private const int SPD_QTY_2 = 10;
        private const int SPD_QTY_3 = 11;

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private bool b_view_flag;
        private TRSNode TLOT = new TRSNode("");

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
                        MPCF.FieldClear(grpMergeInfo);
                        MPCF.FieldClear(grpTranInfo);
                        MPCF.ClearList(spdSelLotList);
                        MPCF.FieldClear(grpCMF);
                        udcLotInfor.InitFlexibleScreen();
                        rbnAllQty.Checked = true;
                        EnableQtyControl(true);

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

            TRSNode LOT = new TRSNode("");

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

                case "MERGE_LOT":

                    iCount = lotlist.RowCount;
                    if (iCount == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(199));
                        tabTran.SelectedTab = tbpGeneral;
                        return false;
                    }

                    if (MPCF.CheckValue(txtTargetLotID, 1) == false)
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        txtTargetLotID.Focus();
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

                        if (MPCF.Trim(lotlist.Cells[i, SPD_MOVE_QTY_1].Value) != "")
                        {
                            if (MPCF.CheckNumeric(MPCF.Trim(lotlist.Cells[i, SPD_MOVE_QTY_1].Value)) == false)
                            {
                                tabTran.SelectedTab = tbpLotInfo;
                                lotlist.ActiveRowIndex = i;
                                return false;
                            }
                        }

                        if (MPCF.Trim(lotlist.Cells[i, SPD_MOVE_QTY_2].Value) != "")
                        {
                            if (MPCF.CheckNumeric(MPCF.Trim(lotlist.Cells[i, SPD_MOVE_QTY_2].Value)) == false)
                            {
                                tabTran.SelectedTab = tbpLotInfo;
                                lotlist.ActiveRowIndex = i;
                                return false;
                            }
                        }

                        if (MPCF.Trim(lotlist.Cells[i, SPD_MOVE_QTY_3].Value) != "")
                        {
                            if (MPCF.CheckNumeric(MPCF.Trim(lotlist.Cells[i, SPD_MOVE_QTY_3].Value)) == false)
                            {
                                tabTran.SelectedTab = tbpLotInfo;
                                lotlist.ActiveRowIndex = i;
                                return false;
                            }
                        }

                        if (MPCF.Trim(lotlist.Cells[i, SPD_LOT_ID].Value) == MPCF.Trim(txtTargetLotID.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(306));
                            tabTran.SelectedTab = tbpLotInfo;
                            txtTargetLotID.Focus();
                            return false;
                        }

                        getLotInfo(lisLotList, MPCF.Trim(lotlist.Cells[i, SPD_LOT_ID].Value), ref LOT);

                        if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                            tabTran.SelectedTab = tbpLotInfo;
                            lotlist.ActiveRowIndex = i;
                            return false;
                        }

                        if (MPCF.Trim(LOT.GetString("OPER")) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                            tabTran.SelectedTab = tbpLotInfo;
                            lotlist.ActiveRowIndex = i;
                            return false;
                        }

                        if (MPGO.MergeDiffMatID() == true)
                        {
                            if (LOT.GetString("MAT_ID") != TLOT.GetString("MAT_ID"))
                            {
                                if (MPCF.ShowMsgBox(MPCF.GetMessage(162), MessageBoxButtons.YesNo, 1) == System.Windows.Forms.DialogResult.No)
                                {
                                    tabTran.SelectedTab = tbpLotInfo;
                                    lotlist.ActiveRowIndex = i;
                                    return false;
                                }
                            }
                        }

                        if (MPGO.MergeDiffOper() == true)
                        {
                            if (LOT.GetString("OPER") != TLOT.GetString("OPER"))
                            {
                                if (MPCF.ShowMsgBox(MPCF.GetMessage(163), MessageBoxButtons.YesNo, 1) == System.Windows.Forms.DialogResult.No)
                                {
                                    tabTran.SelectedTab = tbpLotInfo;
                                    lotlist.ActiveRowIndex = i;
                                    return false;
                                }
                            }
                        }

                        if (MPCF.Trim(lotlist.Cells[i, SPD_MOVE_QTY_1].Value) != "" && MPCF.Trim(lotlist.Cells[i, SPD_MOVE_QTY_3].Value) != "0")
                        {
                            if (LOT.GetDouble("QTY_1") < MPCF.ToDbl(lotlist.Cells[i, SPD_MOVE_QTY_1].Value))
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(136));
                                tabTran.SelectedTab = tbpLotInfo;
                                lotlist.ActiveRowIndex = i;
                                lotlist.SetValue(i, SPD_MOVE_QTY_1, "0");
                                return false;
                            }
                        }
                        if (MPCF.Trim(lotlist.Cells[i, SPD_MOVE_QTY_2].Value) != "" && MPCF.Trim(lotlist.Cells[i, SPD_MOVE_QTY_2].Value) != "0")
                        {
                            if (LOT.GetDouble("QTY_2") < MPCF.ToDbl(lotlist.Cells[i, SPD_MOVE_QTY_2].Value))
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(136));
                                tabTran.SelectedTab = tbpLotInfo;
                                lotlist.ActiveRowIndex = i;
                                lotlist.SetValue(i, SPD_MOVE_QTY_2, "0");
                                return false;
                            }
                        }
                        if (MPCF.Trim(lotlist.Cells[i, SPD_MOVE_QTY_3].Value) != "" && MPCF.Trim(lotlist.Cells[i, SPD_MOVE_QTY_3].Value) != "0")
                        {
                            if (LOT.GetDouble("QTY_3") < MPCF.ToDbl(lotlist.Cells[i, SPD_MOVE_QTY_3].Value))
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(136));
                                tabTran.SelectedTab = tbpLotInfo;
                                lotlist.ActiveRowIndex = i;
                                lotlist.SetValue(i, SPD_MOVE_QTY_3, "0");
                                return false;
                            }
                        }


                    }

                    if (MPCF.CheckValue(txtTargetLotID, 1) == false)
                    {
                        tabTran.SelectedTab = tbpLotInfo;
                        txtTargetLotID.Focus();
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

        //
        // EnableQtyControl()
        //       - Qty Relation Control Enable / Disable
        // Return Value
        //       - 
        // Arguments
        //       - Boolean : True or False
        //
        private void EnableQtyControl(bool b_set_flag)
        {
            
            if (b_set_flag)
            {
                txtMoveQty1.ReadOnly = true;
                txtMoveQty2.ReadOnly = true;
                txtMoveQty3.ReadOnly = true;
                txtMoveQty1.Text = "";
                txtMoveQty2.Text = "";
                txtMoveQty3.Text = "";
                if (cdvOperation.Text != "")
                {
                    /* Added By YJJung 150708 to choose whether to enable Move Qty 1/2/3 based on unit of operation */
                    spdSelLotList.ActiveSheet.Columns[1].BackColor = Color.WhiteSmoke;
                    spdSelLotList.ActiveSheet.Columns[1].Locked = true;
                    spdSelLotList.ActiveSheet.Columns[2].BackColor = Color.WhiteSmoke;
                    spdSelLotList.ActiveSheet.Columns[2].Locked = true;
                    spdSelLotList.ActiveSheet.Columns[3].BackColor = Color.WhiteSmoke;
                    spdSelLotList.ActiveSheet.Columns[3].Locked = true;
                    spdSelLotList.Refresh();
                    /* Added End */
                }
            }
            else
            {
                if (cdvOperation.Text != "")
                {
                    /* Added By YJJung 150708 to choose whether to enable Move Qty 1/2/3 based on unit of operation */
                    TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");
                    TRSNode out_node = new TRSNode("VIEW_OPERATION_OUT");

                    MPCR.SetInMsg(in_node);
                    in_node.ProcStep = '1';
                    in_node.AddString("OPER", MPCF.Trim(cdvOperation.Text));

                    if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
                    {
                        txtMoveQty1.ReadOnly = false;
                        txtMoveQty2.ReadOnly = false;
                        txtMoveQty3.ReadOnly = false;
                        txtMoveQty1.Text = "0";
                        txtMoveQty2.Text = "0";
                        txtMoveQty3.Text = "0";
                        return;
                    }
         
                    if (MPCF.Trim(out_node.GetString("UNIT_1")) != "")
                    {
                        txtMoveQty1.ReadOnly = false;
                        txtMoveQty1.Text = "0";
                        spdSelLotList.ActiveSheet.Columns[1].BackColor = Color.White;
                        spdSelLotList.ActiveSheet.Columns[1].Locked = false;

                    }
                    else
                    {
                        spdSelLotList.ActiveSheet.Columns[1].BackColor = Color.WhiteSmoke;
                        spdSelLotList.ActiveSheet.Columns[1].Locked = true;
                    }
                    if (MPCF.Trim(out_node.GetString("UNIT_2")) != "")
                    {
                        txtMoveQty2.ReadOnly = false;
                        txtMoveQty2.Text = "0";
                        spdSelLotList.ActiveSheet.Columns[2].BackColor = Color.White;
                        spdSelLotList.ActiveSheet.Columns[2].Locked = false;
                    }
                    else
                    {
                        spdSelLotList.ActiveSheet.Columns[2].BackColor = Color.WhiteSmoke;
                        spdSelLotList.ActiveSheet.Columns[2].Locked = true;
                    }
                    if (MPCF.Trim(out_node.GetString("UNIT_3")) != "")
                    {
                        txtMoveQty3.ReadOnly = false;
                        txtMoveQty3.Text = "0";
                        spdSelLotList.ActiveSheet.Columns[3].BackColor = Color.White;
                        spdSelLotList.ActiveSheet.Columns[3].Locked = false;
                    }
                    else
                    {
                        spdSelLotList.ActiveSheet.Columns[3].BackColor = Color.WhiteSmoke;
                        spdSelLotList.ActiveSheet.Columns[3].Locked = true;
                    }
                    spdSelLotList.Refresh();
                }
                    /* Added End */
            }
            
        }

        //
        // getLotInfo()
        //       - Get Lot Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private void getLotInfo(ListView lisView, string sLotID, ref TRSNode tmp_node)
        {
            int iRowIndex = 0;

            TRSNode LOT = new TRSNode("");

            try
            {
                LOT.SetString("LOT_ID", sLotID);

                iRowIndex = MPCF.FindListItemIndex(lisView, sLotID, LOT_ID, false);
                LOT.SetString("MAT_ID",  MPCF.Trim(lisView.Items[iRowIndex].SubItems[MAT_ID].Text));
                LOT.SetString("OPER",  MPCF.Trim(lisView.Items[iRowIndex].SubItems[OPER].Text));
                LOT.SetDouble("QTY_1",  MPCF.ToDbl(lisView.Items[iRowIndex].SubItems[QTY_1].Text));
                LOT.SetDouble("QTY_2",  MPCF.ToDbl(lisView.Items[iRowIndex].SubItems[QTY_2].Text));
                LOT.SetDouble("QTY_3",  MPCF.ToDbl(lisView.Items[iRowIndex].SubItems[QTY_3].Text));

                tmp_node = LOT;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        //
        // ViewLotInfo()
        //       - View Lot Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool ViewLotInfo(string s_lot_id)
        {
            s_lot_id = MPCF.Trim(s_lot_id);
            if (s_lot_id == "") return false;

            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", s_lot_id);

                if (MPCR.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                udcLotInfor.ScreenSpread.Tag = "Change Cell";
                udcLotInfor.ProcStep = '1';
                udcLotInfor.LotID = s_lot_id;
                if (udcLotInfor.LoadDesign() == false) return false;
                if (udcLotInfor.SetDataToScreen(out_node) == false) return false;

                TLOT = out_node;
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        // ViewTargetLotInfo()
        //       -   View Target Lot Information
        // Return Value
        //       -
        // Arguments
        //       -
        private bool ViewTargetLotInfo(string s_lot_id)
        {
            if (ViewLotInfo(s_lot_id) == false)
            {
                txtTargetLotID.Focus();
                return false;
            }
            txtTargetLotID.Text = TLOT.GetString("LOT_ID");
            txtTargetLotDesc.Text = TLOT.GetString("LOT_DESC");

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
            b_view_flag = false;

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

            b_view_flag = true;
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
                    spdSearchItem(spdSelLotList.ActiveSheet, a_item);
                    spdSelLotList.ActiveSheet.AutoSortColumn(SPD_LOT_ID, true);
                }
                else
                {
                    spdSelLotList.ActiveSheet.Rows.Clear();
                }

                // Set Lot Info
                SetLotInfo(spdSelLotList.ActiveSheet, lisLotList, 0, true);
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
        public void SetLotInfo(FarPoint.Win.Spread.SheetView spdSheet, int iStartRow, bool b_qty_flag)
        {
            SetLotInfo(spdSheet, null, iStartRow, 0, 0, 0, b_qty_flag);
        }

        public void SetLotInfo(FarPoint.Win.Spread.SheetView spdSheet, ListView lisView, int iStartRow, bool b_qty_flag)
        {
            SetLotInfo(spdSheet, lisView, iStartRow, 0, 0, 0, b_qty_flag);
        }

        public void SetLotInfo(FarPoint.Win.Spread.SheetView spdSheet, int iStartRow, double dMoveQty1, bool b_qty_flag)
        {
            SetLotInfo(spdSheet, null, iStartRow, dMoveQty1, 0, 0, b_qty_flag);
        }

        public void SetLotInfo(FarPoint.Win.Spread.SheetView spdSheet, int iStartRow, double dMoveQty1, double dMoveQty2, bool b_qty_flag)
        {
            SetLotInfo(spdSheet, null, iStartRow, dMoveQty1, dMoveQty2, 0, b_qty_flag);
        }

        public void SetLotInfo(FarPoint.Win.Spread.SheetView spdSheet, int iStartRow, double dMoveQty1, double dMoveQty2, double dMoveQty3, bool b_qty_flag)
        {
            SetLotInfo(spdSheet, null, iStartRow, dMoveQty1, dMoveQty2, dMoveQty3, b_qty_flag);
        }

        public void SetLotInfo(FarPoint.Win.Spread.SheetView spdSheet, ListView lisview, int iStartRow, double dMoveQty1, double dMoveQty2, double dMoveQty3, bool b_qty_flag)
        {
            int i = 0;
            int iRowIndex = 0;
            try
            {
                for (i = iStartRow; i < spdSheet.RowCount; i++)
                {
                    if (lisview != null)
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

                    if (b_qty_flag == true)
                    {
                        /* 150810 Deleted By YJJung 알수 없는 기능 */
                        //if (MPCF.Trim(spdSheet.RowHeader.Rows[i].Tag) == "CHG") continue;

                        // Set All Qty
                        spdSheet.SetValue(i, SPD_MOVE_QTY_1, MPCF.Trim(lisview.Items[iRowIndex].SubItems[QTY_1].Text));
                        spdSheet.SetValue(i, SPD_MOVE_QTY_2, MPCF.Trim(lisview.Items[iRowIndex].SubItems[QTY_2].Text));
                        spdSheet.SetValue(i, SPD_MOVE_QTY_3, MPCF.Trim(lisview.Items[iRowIndex].SubItems[QTY_3].Text));
                    }
                    else
                    {
                        SetNewQty(spdSelLotList.ActiveSheet, lisLotList, i, iRowIndex, dMoveQty1, dMoveQty2, dMoveQty3); 
                        //// Set Input Qty
                        //spdSheet.SetValue(i, SPD_MOVE_QTY_1, MPCF.Format("#######,##0.###", dMoveQty1));
                        //spdSheet.SetValue(i, SPD_MOVE_QTY_2, MPCF.Format("#######,##0.###", dMoveQty2));
                        //spdSheet.SetValue(i, SPD_MOVE_QTY_3, MPCF.Format("#######,##0.###", dMoveQty3));
                    }
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
                        if (sCarrier != null)
                        {
                            lotlist.SetValue(iRow, SPD_CARRIER_ID, sCarrier);
                        }
                    }
                }
                else
                {
                    if (sCarrier != null)
                    {
                        lotlist.SetValue(iStartRow, SPD_CARRIER_ID, sCarrier);
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

        //
        // Multi_Merge_Lot()
        //       - Multi Merge Lot Transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool MultiMergeLot(char ProcStep)
        {

            TRSNode in_node = new TRSNode("MERGE_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode list_item;

            int i = 0;
            FarPoint.Win.Spread.SheetView lotlist = spdSelLotList.ActiveSheet;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                //in_node.AddString("CRR_ID", MPCF.Trim(cdvCrrID.Text));

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

                in_node.AddString("INTO_LOT_ID", MPCF.Trim(txtTargetLotID.Text));

                for (i = 0; i < lotlist.RowCount; i++)
                {
                    list_item = in_node.AddNode("LOT_LIST");

                    list_item.AddString("LOT_ID", MPCF.Trim(lotlist.Cells[i, SPD_LOT_ID].Value));
                    list_item.AddInt("LAST_ACTIVE_HIST_SEQ", MPCF.Trim(lotlist.Cells[i, SPD_LOT_ID].Tag));
                    list_item.AddDouble("MOVE_QTY_1", (MPCF.Trim(lotlist.Cells[i, SPD_MOVE_QTY_1].Value) == "") ? -1 : (MPCF.ToDbl(lotlist.Cells[i, SPD_MOVE_QTY_1].Value)));
                    list_item.AddDouble("MOVE_QTY_2", (MPCF.Trim(lotlist.Cells[i, SPD_MOVE_QTY_2].Value) == "") ? -1 : (MPCF.ToDbl(lotlist.Cells[i, SPD_MOVE_QTY_2].Value)));
                    list_item.AddDouble("MOVE_QTY_3", (MPCF.Trim(lotlist.Cells[i, SPD_MOVE_QTY_3].Value) == "") ? -1 : (MPCF.ToDbl(lotlist.Cells[i, SPD_MOVE_QTY_3].Value)));
                    list_item.AddString("INTO_CRR_ID", MPCF.Trim(lotlist.Cells[i, SPD_CARRIER_ID].Value));
                }

                in_node.AddChar("NO_AUTOMATIC_TERMINATE_LOT", chkNoAutoTermLot.Checked == true ? 'Y' : ' ');
                in_node.AddChar("BIND_SAME_TR_FLAG", chkBindSameTr.Checked == true ? 'Y' : ' ');

                if (MPCR.CallService("WIP", "WIP_Multi_Merge_Lot", in_node, ref out_node) == false)
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

        // spdCalculate()
        //       -  Spread Total Summary Calculation
        // Return Value
        //       - 
        // Arguments
        //       - 
        //
        private void spdCalculate()
        {
            int i = 0;
            int iTotLotCnt = 0;
            double dMoveSumQty1 = 0;
            double dMoveSumQty2 = 0;
            double dMoveSumQty3 = 0;
            double dSumQty1 = 0;
            double dSumQty2 = 0;
            double dSumQty3 = 0;

            try
            {
                lblTotCnt.Text = "";
                lblTotMoveQty1.Text = "";
                lblTotMoveQty2.Text = "";
                lblTotMoveQty3.Text = "";
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
                            dMoveSumQty1 += MPCF.ToDbl(spdSelLotList.ActiveSheet.Cells[i, SPD_MOVE_QTY_1].Value);

                            // Move Qty2
                            dMoveSumQty2 += MPCF.ToDbl(spdSelLotList.ActiveSheet.Cells[i, SPD_MOVE_QTY_2].Value);

                            // Move Qty3
                            dMoveSumQty3 += MPCF.ToDbl(spdSelLotList.ActiveSheet.Cells[i, SPD_MOVE_QTY_3].Value);

                            // Qty1
                            dSumQty1 += MPCF.ToDbl(spdSelLotList.ActiveSheet.Cells[i, SPD_QTY_1].Value);

                            // Qty2
                            dSumQty2 += MPCF.ToDbl(spdSelLotList.ActiveSheet.Cells[i, SPD_QTY_2].Value);

                            // Qty3
                            dSumQty3 += MPCF.ToDbl(spdSelLotList.ActiveSheet.Cells[i, SPD_QTY_3].Value);
                        }
                    }

                    lblTotCnt.Text = MPCF.FindLanguage("Total Count :  ", CAPTION_TYPE.LABEL) + iTotLotCnt;
                    lblTotMoveQty1.Text = MPCF.FindLanguage("Move Qty1 :  ", CAPTION_TYPE.LABEL) + dMoveSumQty1;
                    lblTotMoveQty2.Text = MPCF.FindLanguage("Move Qty2 :  ", CAPTION_TYPE.LABEL) + dMoveSumQty2;
                    lblTotMoveQty3.Text = MPCF.FindLanguage("Move Qty3 :  ", CAPTION_TYPE.LABEL) + dMoveSumQty3;

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

        private void SetNewQty(FarPoint.Win.Spread.SheetView spdSheet, ListView lisview, int ispdRow, int ilisRow, double dMoveQty1, double dMoveQty2, double dMoveQty3)
        {
            try
            {
                
                if (MPCF.ToDbl(MPCF.Trim(lisview.Items[ilisRow].SubItems[QTY_1].Text)) < dMoveQty1)
                {
                    spdSheet.SetValue(ispdRow, SPD_MOVE_QTY_1, MPCF.Format("#######,##0.###", MPCF.Trim(lisview.Items[ilisRow].SubItems[QTY_1].Text)));
                }
                else
                {
                    spdSheet.SetValue(ispdRow, SPD_MOVE_QTY_1, MPCF.Format("#######,##0.###", dMoveQty1));
                }

                if (MPCF.ToDbl(MPCF.Trim(lisview.Items[ilisRow].SubItems[QTY_2].Text)) < dMoveQty2)
                {
                    spdSheet.SetValue(ispdRow, SPD_MOVE_QTY_2, MPCF.Format("#######,##0.###", MPCF.Trim(lisview.Items[ilisRow].SubItems[QTY_2].Text)));
                }
                else
                {
                    spdSheet.SetValue(ispdRow, SPD_MOVE_QTY_2, MPCF.Format("#######,##0.###", dMoveQty2));
                }

                if (MPCF.ToDbl(MPCF.Trim(lisview.Items[ilisRow].SubItems[QTY_3].Text)) < dMoveQty3)
                {
                    spdSheet.SetValue(ispdRow, SPD_MOVE_QTY_3, MPCF.Format("#######,##0.###", MPCF.Trim(lisview.Items[ilisRow].SubItems[QTY_3].Text)));
                }
                else
                {
                    spdSheet.SetValue(ispdRow, SPD_MOVE_QTY_3, MPCF.Format("#######,##0.###", dMoveQty3));
                }
            }
            catch(Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        #endregion

        private void frmWIPTranMultiMergeLot_Load(object sender, System.EventArgs e)
        {
            lisLotList.CheckBoxes = true;

            if (this.DesignMode == true)
                pnlTranTime.Visible = true;
            else
                pnlTranTime.Visible = MPGO.UseBackDate();

            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;
        }

        private void frmWIPTranMultiMergeLot_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    ClearData("1");
                    MPCF.InitListView(lisLotList);
                    SetCMFItem(MPGC.MP_CMF_TRN_MERGE);

                    cdvOperation.Init();
                    MPCF.InitListView(cdvOperation.GetListView);
                    cdvOperation.Columns.Add("Oper", 150, HorizontalAlignment.Left);
                    cdvOperation.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                    cdvOperation.SelectedSubItemIndex = 0;
                    cdvOperation.DisplaySubItemIndex = 0;

                    WIPLIST.ViewOperationList(cdvOperation.GetListView, '1');
                    cdvOperation.AddEmptyRow(1);

                    rbnAllQty.Checked = true;
                    EnableQtyControl(true);
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
                if (CheckCondition("MERGE_LOT") == false) return;

                if (MultiMergeLot('1') == false)
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

        private void spdSelLotList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column == SPD_CARRIER_ID + 1)
                {
                    if (TLOT.GetDouble("QTY_1") > 0 || TLOT.GetDouble("QTY_2") > 0 || TLOT.GetDouble("QTY_3") > 0)
                    {
#if _CRR

                        cdvspdCrrID.Init();
                        cdvspdCrrID.ViewPosition = Control.MousePosition;
                        MPCF.InitListView(cdvspdCrrID.GetListView);
                        cdvspdCrrID.Columns.Add("Carrier ID", 50, HorizontalAlignment.Left);
                        cdvspdCrrID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                        if (RASLIST.ViewCarrierList(cdvspdCrrID.GetListView, txtTargetLotID.Text) == false)
                        {
                            return;
                        }

                        if (cdvspdCrrID.ShowPopupList(e.Row, e.Column) == false)
                        {
                            return;
                        }
#endif
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
            if (b_view_flag == false) return;

            SetLotList();
            if (MPGO.ProcessZeroQtyLot() == true)
                chkNoAutoTermLot.Checked = true;
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

        private void cdvspdCrrID_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            SetCarrierInfo(e.Row, false, MPCF.Trim(e.SelectedItem.SubItems[0].Text));
        }

        private void spdSelLotList_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (spdSelLotList.ActiveSheet.RowCount > 0)
                {

                    int iRow = spdSelLotList.ActiveSheet.ActiveRowIndex;
                    if (rbnAllQty.Checked)
                    {
                        //SetLotInfo(spdSelLotList.ActiveSheet, lisLotList, iRow, true);
                        /* 151030 Updated By YJJung Bug Fix All Qty 선택 시 선택된 로우부터 Qty가 재설정 되고 그 위에 row는 유지되는 Bug Fix */
                        SetLotInfo(spdSelLotList.ActiveSheet, lisLotList, 0, true);
                    }
                    else
                    {
                        SetLotInfo(spdSelLotList.ActiveSheet, lisLotList, iRow, MPCF.ToDbl(txtMoveQty1.Text), MPCF.ToDbl(txtMoveQty2.Text), MPCF.ToDbl(txtMoveQty2.Text), false);
                    }
                    spdCalculate();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void txtTargetLotID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ViewTargetLotInfo(MPCF.Trim(txtTargetLotID.Text));
            }
        }

        private void spdSelLotList_EditModeOff(object sender, EventArgs e)
        {
            spdCalculate();
            spdSelLotList.ActiveSheet.RowHeader.Rows[spdSelLotList.ActiveSheet.ActiveRowIndex].Tag = "CHG";
        }

        private void rbnPartialQty_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnAllQty.Checked)
            {
                EnableQtyControl(true);

                if (cdvOperation.Text != "")
                {
                    btnApply_Click(null, null);
                }
            }
            else
            {
                EnableQtyControl(false);
            }
        }
        /* Added By YJJung 150708  Only Numeric value is allowed, and automatically hit apply button*/
        private void txtMoveQty1_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void txtMoveQty2_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void txtMoveQty3_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void txtMoveQty1_TextChanged(object sender, EventArgs e)
        {
            /* Deleted By YJJung 150810 자동으로 APPLY 버튼 클릭 제거 */
            //if (spdSelLotList.ActiveSheet.Cells[SPD_LOT_ID, SPD_LOT_ID].Text != "")
            //{
            //    KeyPressEventArgs ea = new KeyPressEventArgs((char)13);
            //    btnApply_Click(sender, ea);
            //}
        }

        private void txtMoveQty2_TextChanged(object sender, EventArgs e)
        {
            //if (spdSelLotList.ActiveSheet.Cells[SPD_LOT_ID, SPD_LOT_ID].Text != "")
            //{
            //    KeyPressEventArgs ea = new KeyPressEventArgs((char)13);
            //    btnApply_Click(sender, ea);
            //}
        }

        private void txtMoveQty3_TextChanged(object sender, EventArgs e)
        {
            //if (spdSelLotList.ActiveSheet.Cells[SPD_LOT_ID, SPD_LOT_ID].Text != "")
            //{
            //    KeyPressEventArgs ea = new KeyPressEventArgs((char)13);
            //    btnApply_Click(sender, ea);
            //}
        }

        private void spdSelLotList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            // Do Nothing
            //if (e.ColumnHeader == true && e.Column != 0)
            //{
            //    spdSelLotList.ActiveSheet.Cells[e.Row, e.Column].
            //}
        }
        /* Added End */
    }
}
