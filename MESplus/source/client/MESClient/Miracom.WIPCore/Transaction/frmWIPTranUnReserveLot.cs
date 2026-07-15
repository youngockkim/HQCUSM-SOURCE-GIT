
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranUnReserveLot.vb
//   Description : UnReserve lot to specific resource Transaction
//
//   MES Version : 4.2.0.0
//
//   Function List
//      -
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2008-08-23 : Created by Aiden
//
//
//   Copyright(C) 1998-2008 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

using Miracom.UI;
using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;
using Miracom.MsgHandler;

namespace Miracom.WIPCore
{
    public partial class frmWIPTranUnReserveLot : Miracom.MESCore.TranForm08
    {
        public frmWIPTranUnReserveLot()
        {
            InitializeComponent();

            this.spdResInfo1.Tag = "Change Cell";
            this.spdResInfo2.Tag = "Change Cell";
            this.spdLotInfo2.Tag = "Change Cell";
        }

        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private TRSNode LOT;

        #endregion

        #region " Function Definition "

        // ViewLotInfo()
        //       -   View Lot Information
        // Return Value
        //       -
        // Arguments
        //       -
        protected bool ViewLotInfo(string s_lot_id)
        {
            MPCF.FieldClear(this.tbpLot, txtLotID);

            s_lot_id = MPCF.Trim(s_lot_id);
            if (MPCR.SetLotInfoSpread(spdLotInfo2, s_lot_id, ref LOT) == false)
            {
                txtLotID.Focus();
                return false;
            }
            txtLotDesc.Text = LOT.GetString("LOT_DESC");
            txtResID2.Text = LOT.GetString("RESERVE_RES_ID");
            txtSubResID2.Text = LOT.GetString("SUBRES_ID");
            txtPortID2.Text = LOT.GetString("PORT_ID");

            InitResInfo2();
            if (txtResID2.Text != "")
            {
                View_Resource(txtResID2.Text, spdResInfo2);
            }

            return true;
        }

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

                        MPCF.FieldClear(this);
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
        private bool CheckCondition()
        {
            if (tabUnreserveTran.SelectedTab == tbpLot)
            {
                if (MPCF.CheckValue(txtLotID, 1) == false)
                {
                    return false;
                }
            }
            else
            {
                if (MPCF.Trim(cdvResID1.Text) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvResID1.Focus();
                    return false;
                }
                if (lisLot.SelectedItems.Count < 1)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109) + " - LOT");
                    lisLot.Focus();
                    return false;
                }
            }

            if (CheckCMFItemValue() == false)
            {
                tabTran.SelectedTab = tbpCMF;
                return false;
            }

            return true;

        }

        private void InitResInfo1()
        {
            //Initilize spdResInfo
            spdResInfo1.Sheets[0].Cells[0, 1].Text = "";
            spdResInfo1.Sheets[0].Cells[0, 3].Text = "";
            spdResInfo1.Sheets[0].Cells[1, 0].Text = "";
            spdResInfo1.Sheets[0].Cells[1, 1].Text = "";
            spdResInfo1.Sheets[0].Cells[1, 2].Text = "";
            spdResInfo1.Sheets[0].Cells[1, 3].Text = "";
            spdResInfo1.Sheets[0].Cells[2, 0].Text = "";
            spdResInfo1.Sheets[0].Cells[2, 1].Text = "";
            spdResInfo1.Sheets[0].Cells[2, 2].Text = "";
            spdResInfo1.Sheets[0].Cells[2, 3].Text = "";
            spdResInfo1.Sheets[0].Cells[3, 0].Text = "";
            spdResInfo1.Sheets[0].Cells[3, 1].Text = "";
            spdResInfo1.Sheets[0].Cells[3, 2].Text = "";
            spdResInfo1.Sheets[0].Cells[3, 3].Text = "";
            spdResInfo1.Sheets[0].Cells[4, 0].Text = "";
            spdResInfo1.Sheets[0].Cells[4, 1].Text = "";
            spdResInfo1.Sheets[0].Cells[4, 2].Text = "";
            spdResInfo1.Sheets[0].Cells[4, 3].Text = "";
            spdResInfo1.Sheets[0].Cells[5, 0].Text = "";
            spdResInfo1.Sheets[0].Cells[5, 1].Text = "";
            spdResInfo1.Sheets[0].Cells[5, 2].Text = "";
            spdResInfo1.Sheets[0].Cells[5, 3].Text = "";
        }

        private void InitResInfo2()
        {
            //Initilize spdResInfo
            spdResInfo2.Sheets[0].Cells[0, 1].Text = "";
            spdResInfo2.Sheets[0].Cells[0, 3].Text = "";
            spdResInfo2.Sheets[0].Cells[1, 0].Text = "";
            spdResInfo2.Sheets[0].Cells[1, 1].Text = "";
            spdResInfo2.Sheets[0].Cells[1, 2].Text = "";
            spdResInfo2.Sheets[0].Cells[1, 3].Text = "";
            spdResInfo2.Sheets[0].Cells[2, 0].Text = "";
            spdResInfo2.Sheets[0].Cells[2, 1].Text = "";
            spdResInfo2.Sheets[0].Cells[2, 2].Text = "";
            spdResInfo2.Sheets[0].Cells[2, 3].Text = "";
            spdResInfo2.Sheets[0].Cells[3, 0].Text = "";
            spdResInfo2.Sheets[0].Cells[3, 1].Text = "";
            spdResInfo2.Sheets[0].Cells[3, 2].Text = "";
            spdResInfo2.Sheets[0].Cells[3, 3].Text = "";
            spdResInfo2.Sheets[0].Cells[4, 0].Text = "";
            spdResInfo2.Sheets[0].Cells[4, 1].Text = "";
            spdResInfo2.Sheets[0].Cells[4, 2].Text = "";
            spdResInfo2.Sheets[0].Cells[4, 3].Text = "";
            spdResInfo2.Sheets[0].Cells[5, 0].Text = "";
            spdResInfo2.Sheets[0].Cells[5, 1].Text = "";
            spdResInfo2.Sheets[0].Cells[5, 2].Text = "";
            spdResInfo2.Sheets[0].Cells[5, 3].Text = "";
        }

        //
        // View_Resource()
        //       - Get ResourceID Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Resource(String s_res_id, FarPoint.Win.Spread.FpSpread spdResInfo)
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

                if (out_node.GetChar("RES_UP_DOWN_FLAG") == 'U')
                {
                    spdResInfo.Sheets[0].Cells[0, 1].Text = "UP";
                }
                else if (out_node.GetChar("RES_UP_DOWN_FLAG") == 'D')
                {
                    spdResInfo.Sheets[0].Cells[0, 1].Text = "DOWN";
                }
                spdResInfo.Sheets[0].Cells[0, 3].Text = MPCF.Trim(out_node.GetString("RES_PRI_STS"));

                spdResInfo.Sheets[0].Cells[1, 1].Text = MPCF.Trim(out_node.GetString("RES_STS_1"));
                spdResInfo.Sheets[0].Cells[1, 3].Text = MPCF.Trim(out_node.GetString("RES_STS_2"));
                spdResInfo.Sheets[0].Cells[2, 1].Text = MPCF.Trim(out_node.GetString("RES_STS_3"));
                spdResInfo.Sheets[0].Cells[2, 3].Text = MPCF.Trim(out_node.GetString("RES_STS_4"));
                spdResInfo.Sheets[0].Cells[3, 1].Text = MPCF.Trim(out_node.GetString("RES_STS_5"));
                spdResInfo.Sheets[0].Cells[3, 3].Text = MPCF.Trim(out_node.GetString("RES_STS_6"));
                spdResInfo.Sheets[0].Cells[4, 1].Text = MPCF.Trim(out_node.GetString("RES_STS_7"));
                spdResInfo.Sheets[0].Cells[4, 3].Text = MPCF.Trim(out_node.GetString("RES_STS_8"));
                spdResInfo.Sheets[0].Cells[5, 1].Text = MPCF.Trim(out_node.GetString("RES_STS_9"));
                spdResInfo.Sheets[0].Cells[5, 3].Text = MPCF.Trim(out_node.GetString("RES_STS_10"));

                if (out_node.GetChar("USE_FAC_PRT_FLAG") == 'Y')
                {
                    View_Factory_ResStatus(spdResInfo);
                }
                else
                {
                    spdResInfo.Sheets[0].Cells[1, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_1"));
                    spdResInfo.Sheets[0].Cells[1, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_2"));
                    spdResInfo.Sheets[0].Cells[2, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_3"));
                    spdResInfo.Sheets[0].Cells[2, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_4"));
                    spdResInfo.Sheets[0].Cells[3, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_5"));
                    spdResInfo.Sheets[0].Cells[3, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_6"));
                    spdResInfo.Sheets[0].Cells[4, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_7"));
                    spdResInfo.Sheets[0].Cells[4, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_8"));
                    spdResInfo.Sheets[0].Cells[5, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_9"));
                    spdResInfo.Sheets[0].Cells[5, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_10"));
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
        // View_Reserve_Lot_List()
        //       - Get Reserved Lot Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Reserve_Lot_List(string s_res_id, string s_subres_id, string s_port_id)
        {
            TRSNode in_node = new TRSNode("VIEW_RESERVE_LOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_RESERVE_LOT_LIST_OUT");
            int i;
            ListViewItem item;

            try
            {
                MPCF.InitListView(lisLot);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("RES_ID", MPCF.Trim(s_res_id));
                in_node.AddString("SUBRES_ID", MPCF.Trim(s_subres_id));
                in_node.AddString("PORT_ID", MPCF.Trim(s_port_id));

                do
                {
                    if (MPCR.CallService("WIP", "WIP_View_Reserve_Lot_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList("LIST").Count; i++)
                    {
                        item = new ListViewItem(((int)(lisLot.Items.Count + 1)).ToString(), (int)SMALLICON_INDEX.IDX_LOT);
                        item.SubItems.Add(out_node.GetList(0)[i].GetString("LOT_ID"));
                        item.SubItems.Add(out_node.GetList(0)[i].GetString("MAT_ID"));
                        item.SubItems.Add(out_node.GetList(0)[i].GetInt("MAT_VER").ToString());
                        item.SubItems.Add(out_node.GetList(0)[i].GetString("FLOW"));
                        item.SubItems.Add(out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM").ToString());
                        item.SubItems.Add(out_node.GetList(0)[i].GetString("OPER"));
                        item.SubItems.Add(out_node.GetList(0)[i].GetDouble("QTY_1").ToString("######,##0.###"));
                        item.SubItems.Add(out_node.GetList(0)[i].GetDouble("QTY_2").ToString("######,##0.###"));
                        item.SubItems.Add(out_node.GetList(0)[i].GetDouble("QTY_3").ToString("######,##0.###"));
                        item.SubItems.Add(out_node.GetList(0)[i].GetInt("LAST_ACTIVE_HIST_SEQ").ToString());

                        lisLot.Items.Add(item);
                    }

                    in_node.SetString("LOT_ID", out_node.GetString("NEXT_LOT_ID"));
                } while (in_node.GetString("LOT_ID") != "");

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return true;
        }

        //
        // View_Factory_ResStatus()
        //       - Get Resource Status Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Factory_ResStatus(FarPoint.Win.Spread.FpSpread spdResInfo)
        {

            TRSNode in_node = new TRSNode("VIEW_FACTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_FACTORY_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (MPCR.CallService("WIP", "WIP_View_Factory", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdResInfo.Sheets[0].Cells[1, 0].Text = out_node.GetString("RES_STS_1");
                spdResInfo.Sheets[0].Cells[1, 2].Text = out_node.GetString("RES_STS_2");
                spdResInfo.Sheets[0].Cells[2, 0].Text = out_node.GetString("RES_STS_3");
                spdResInfo.Sheets[0].Cells[2, 2].Text = out_node.GetString("RES_STS_4");
                spdResInfo.Sheets[0].Cells[3, 0].Text = out_node.GetString("RES_STS_5");
                spdResInfo.Sheets[0].Cells[3, 2].Text = out_node.GetString("RES_STS_6");
                spdResInfo.Sheets[0].Cells[4, 0].Text = out_node.GetString("RES_STS_7");
                spdResInfo.Sheets[0].Cells[4, 2].Text = out_node.GetString("RES_STS_8");
                spdResInfo.Sheets[0].Cells[5, 0].Text = out_node.GetString("RES_STS_9");
                spdResInfo.Sheets[0].Cells[5, 2].Text = out_node.GetString("RES_STS_10");

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        //
        // UnReserve_Lot()
        //       - UnReserve Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool UnReserve_Lot()
        {

            TRSNode in_node = new TRSNode("UNRESERVE_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            int i;

            try
            {
                MPCR.SetInMsg(in_node);

                in_node.ProcStep = '1';
                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }

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

                if (tabUnreserveTran.SelectedTab == tbpResource)
                {
                    for (i = 0; i < lisLot.SelectedItems.Count; i++)
                    {
                        in_node.SetInt("LAST_ACTIVE_HIST_SEQ", MPCF.ToInt(lisLot.SelectedItems[i].SubItems[10].Text));
                        in_node.SetString("LOT_ID", lisLot.SelectedItems[i].SubItems[1].Text);
                        in_node.SetString("MAT_ID", lisLot.SelectedItems[i].SubItems[2].Text);
                        in_node.SetInt("MAT_VER", MPCF.ToInt(lisLot.SelectedItems[i].SubItems[3].Text));
                        in_node.SetString("FLOW", lisLot.SelectedItems[i].SubItems[4].Text);
                        in_node.SetInt("FLOW_SEQ_NUM", MPCF.ToInt(lisLot.SelectedItems[i].SubItems[5].Text));
                        in_node.SetString("OPER", lisLot.SelectedItems[i].SubItems[6].Text);

                        if (MPCR.CallService("WIP", "WIP_Unreserve_Lot", in_node, ref out_node) == false)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                    in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                    in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                    in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                    in_node.AddString("FLOW", LOT.GetString("FLOW"));
                    in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                    in_node.AddString("OPER", LOT.GetString("OPER"));

                    if (MPCR.CallService("WIP", "WIP_Unreserve_Lot", in_node, ref out_node) == false)
                    {
                        return false;
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

        public override Control GetFisrtFocusItem()
        {
            try
            {
                return this.cdvResID1;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion

        private void frmWIPTranUnReserveLot_Activated(object sender, System.EventArgs e)
        {

            try
            {
                if (b_load_flag == false)
                {
                    pnlTranTime.Visible = MPGO.UseBackDate();
                    dtpTranDate.Enabled = chkTranDateTime.Checked;
                    dtpTranTime.Enabled = chkTranDateTime.Checked;

                    MPCF.InitListView(lisLot);
                    MPCR.ClearLotSpread(spdLotInfo2);

                    SetCMFItem(MPGC.MP_CMF_TRN_UNRESERVE);

                    ClearData("1");
                    if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                    {
                        tabUnreserveTran.SelectedTab = tbpLot;

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

        private void chkTranDateTime_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            txtTranDateTime.Visible = !chkTranDateTime.Checked;
            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;

            txtTranDateTime.TabStop = !chkTranDateTime.Checked;
            dtpTranDate.TabStop = chkTranDateTime.Checked;
            dtpTranTime.TabStop = chkTranDateTime.Checked;
        }

        private void spdResInfo_Resize(object sender, System.EventArgs e)
        {
            int iDiffSize;
            FarPoint.Win.Spread.FpSpread spdResInfo = (FarPoint.Win.Spread.FpSpread)sender;

            try
            {
                iDiffSize = (spdResInfo.Width - 702) / 2;
                if (iDiffSize >= 0)
                {
                    spdResInfo.Sheets[0].Columns[1].Width = 192 + iDiffSize;
                    spdResInfo.Sheets[0].Columns[3].Width = 192 + iDiffSize;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void spdLotInfo_Resize(System.Object sender, System.EventArgs e)
        {
            int iDiffSize;
            FarPoint.Win.Spread.FpSpread spdLotInfo = (FarPoint.Win.Spread.FpSpread)sender;

            try
            {
                iDiffSize = (spdLotInfo.Size.Width - 702) / 3;

                if (iDiffSize >= 0)
                {
                    spdLotInfo.ActiveSheet.Columns[1].Width = 124 + iDiffSize;
                    spdLotInfo.ActiveSheet.Columns[3].Width = 124 + iDiffSize;
                    spdLotInfo.ActiveSheet.Columns[5].Width = 124 + iDiffSize;
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

                if (UnReserve_Lot() == false) return;

                if (tabUnreserveTran.SelectedTab == tbpLot)
                {
                    ViewLotInfo(txtLotID.Text);
                }
                else
                {
                    cdvResID1_SelectedItemChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }



        private void cdvResID1_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            if (cdvResID1.Text != "")
            {
                InitResInfo1();
                MPCF.InitListView(lisLot);

                if (View_Resource(cdvResID1.Text, spdResInfo1) == false)
                {
                    return;
                }

                View_Reserve_Lot_List(cdvResID1.Text, cdvSubResID1.Text, cdvPortID1.Text);
            }
        }

        private void cdvResID1_TextBoxTextChanged(object sender, System.EventArgs e)
        {

            if (cdvResID1.Text == "")
            {
                InitResInfo1();
            }
        }

        private void cdvResID1_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cdvResID1_SelectedItemChanged(null, null);
            }
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ViewLotInfo(txtLotID.Text);
            }
        }

        private void cdvSubResID1_ButtonPress(object sender, EventArgs e)
        {
            cdvSubResID1.Init();
            MPCF.InitListView(cdvSubResID1.GetListView);
            cdvSubResID1.Columns.Add("Sub Resource ID", 50, HorizontalAlignment.Left);
            cdvSubResID1.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvSubResID1.SelectedSubItemIndex = 0;
            RASLIST.ViewSubResourceList(cdvSubResID1.GetListView, '1', cdvResID1.Text);
        }

        private void cdvSubResID1_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            cdvPortID1.Text = "";

            if (cdvResID1.Text != "")
            {
                View_Reserve_Lot_List(cdvResID1.Text, cdvSubResID1.Text, cdvPortID1.Text);
            }
        }

        private void cdvPortID1_ButtonPress(object sender, EventArgs e)
        {
            cdvPortID1.Init();
            MPCF.InitListView(cdvPortID1.GetListView);
            cdvPortID1.Columns.Add("Port ID", 50, HorizontalAlignment.Left);
            cdvPortID1.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvPortID1.SelectedSubItemIndex = 0;
            RASLIST.ViewPortList(cdvPortID1.GetListView, '1', cdvResID1.Text, cdvSubResID1.Text);
        }

        private void cdvPortID1_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvResID1.Text != "")
            {
                View_Reserve_Lot_List(cdvResID1.Text, cdvSubResID1.Text, cdvPortID1.Text);
            }
        }



    
    }
}

