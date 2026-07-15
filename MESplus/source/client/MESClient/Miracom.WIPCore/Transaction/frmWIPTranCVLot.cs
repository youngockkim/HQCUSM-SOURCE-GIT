
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranCVLot.cs
//   Description : Count Variance Lot Transaction
//
//   MES Version : 5.0.1.5
//
//   Function List
//       - 
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2009-06-10 : Created by AK
//
//
//   Copyright(C) 1998-2009 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.UI;
using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPTranCVLot : Miracom.MESCore.TranForm07
    {
        public frmWIPTranCVLot()
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
            MPCF.FieldClear(this, txtLotID);

            spdUnit1.ActiveSheet.RowCount = 0;
            spdUnit2.ActiveSheet.RowCount = 0;
            spdUnit3.ActiveSheet.RowCount = 0;

            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }
            txtLotDesc.Text = LOT.GetString("LOT_DESC");

            if (MPGO.ProcessZeroQtyLot() == true)
                chkNoAutoTermLot.Checked = true;

            if (View_Operation() == false) return false;

            cdvResID.Text = LOT.GetString("START_RES_ID");

            txtQty1.Text = LOT.GetDouble("QTY_1").ToString("####,##0.###");
            txtQty2.Text = LOT.GetDouble("QTY_2").ToString("####,##0.###");
            txtQty3.Text = LOT.GetDouble("QTY_3").ToString("####,##0.###");

            txtOutQty1.Text = txtQty1.Text;
            txtOutQty2.Text = txtQty2.Text;
            txtOutQty3.Text = txtQty3.Text;

#if _CRR
            cdvCrrID.Init();
            cdvCrrID.Columns.Add("Carrier ID", 50, HorizontalAlignment.Left);
            cdvCrrID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrID.SelectedSubItemIndex = 0;
            if (RASLIST.ViewCarrierList(cdvCrrID.GetListView, txtLotID.Text) == false) return false;
#endif
            return true;
        }

        //
        // View_Operation()
        //       -  View Operation Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Operation()
        {

            TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");
            TRSNode out_node = new TRSNode("VIEW_OPERATION_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", LOT.GetString("OPER"));

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetString("UNIT_1") != "")
            {
                spdUnit1.Visible = true;
                spdUnit1.ActiveSheet.RowCount = 1;
            }
            else
            {
                spdUnit1.Visible = false;
                txtOutQty1.Text = "0";
            }
            if (out_node.GetString("UNIT_2") != "")
            {
                spdUnit2.Visible = true;
                spdUnit2.ActiveSheet.RowCount = 1;
            }
            else
            {
                spdUnit2.Visible = false;
                txtOutQty2.Text = "0";
            }
            if (out_node.GetString("UNIT_3") != "")
            {
                spdUnit3.Visible = true;
                spdUnit3.ActiveSheet.RowCount = 1;
            }
            else
            {
                spdUnit3.Visible = false;
                txtOutQty3.Text = "0";
            }

            return true;
        }

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool CheckCondition()
        {
            if (MPCF.CheckValue(txtLotID, 1) == false)
            {
                return false;
            }

            if (CheckCMFItemValue() == false)
            {
                tabTran.SelectedTab = tbpCMF;
                return false;
            }

            if (LOT.GetInt("SUBLOT_COUNT") > 0)
            {
                if (MPCF.ToDbl(txtCVQty1.Text) > 0)
                {
                    if (cdvSublotGrade.Text == "")
                    {
                        if (MPCF.ShowMsgBox(MPCF.GetMessage(298), MessageBoxButtons.YesNo, 1) == DialogResult.No)
                        {
                            return false;
                        }
                    }
                }
            }
            
            return true;
        }

        //
        // CV_Lot()
        //       - Count Variance Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool CV_Lot()
        {
            TRSNode in_node = new TRSNode("CV_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode cv_item;
            int i;

            string s_cv_code;
            double d_cv_qty;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("CRR_ID", MPCF.Trim(cdvCrrID.Text));
                in_node.AddString("CAUSE_FLOW", MPCF.Trim(cdvCauseFlow.Text));
                in_node.AddString("CAUSE_OPER", MPCF.Trim(cdvCauseOper.Text));
                in_node.AddString("CAUSE_RES_ID", MPCF.Trim(cdvCauseRes.Text));
                in_node.AddString("CHECK_USER_1", MPCF.Trim(txtChkUser1.Text), true);
                in_node.AddString("CHECK_USER_2", MPCF.Trim(txtChkUser2.Text), true);
                in_node.AddString("CHECK_USER_3", MPCF.Trim(txtChkUser3.Text), true);
                
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

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));
                in_node.AddString("CV_COMMENT", MPCF.Trim(txtCVComment.Text));
                in_node.AddChar("NO_AUTOMATIC_TERMINATE_LOT", chkNoAutoTermLot.Checked == true ? 'Y' : ' ');

                in_node.AddChar("GRADE", MPCF.Trim(cdvSublotGrade.Text) == "" ? 'G' : MPCF.ToChar(cdvSublotGrade.Text));

                for (i = 0; i < spdUnit1.ActiveSheet.RowCount; i++)
                {
                    s_cv_code = MPCF.Trim(spdUnit1.ActiveSheet.GetValue(i, 0));
                    d_cv_qty = MPCF.ToDbl(spdUnit1.ActiveSheet.GetValue(i, 2));

                    if (s_cv_code != "" && d_cv_qty != 0)
                    {
                        cv_item = in_node.AddNode("UNIT1");

                        cv_item.AddString("CODE", s_cv_code);
                        cv_item.AddDouble("QTY", d_cv_qty);
                    }
                }

                for (i = 0; i < spdUnit2.ActiveSheet.RowCount; i++)
                {
                    s_cv_code = MPCF.Trim(spdUnit2.ActiveSheet.GetValue(i, 0));
                    d_cv_qty = MPCF.ToDbl(spdUnit2.ActiveSheet.GetValue(i, 2));

                    if (s_cv_code != "" && d_cv_qty != 0)
                    {
                        cv_item = in_node.AddNode("UNIT2");

                        cv_item.AddString("CODE", s_cv_code);
                        cv_item.AddDouble("QTY", d_cv_qty);
                    }
                }

                for (i = 0; i < spdUnit3.ActiveSheet.RowCount; i++)
                {
                    s_cv_code = MPCF.Trim(spdUnit3.ActiveSheet.GetValue(i, 0));
                    d_cv_qty = MPCF.ToDbl(spdUnit3.ActiveSheet.GetValue(i, 2));

                    if (s_cv_code != "" && d_cv_qty != 0)
                    {
                        cv_item = in_node.AddNode("UNIT3");

                        cv_item.AddString("CODE", s_cv_code);
                        cv_item.AddDouble("QTY", d_cv_qty);
                    }
                }
                
                if (MPCR.CallService("WIP", "WIP_CV_Lot", in_node, ref out_node) == false)
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

#endregion

        private void frmWIPTranCVLot_Activated(object sender, EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    this.tabTran.TabPages.Remove(this.tbpCMF);
                    this.tabTran.Controls.Add(this.tbpCMF);
#if _CRR
                    lblCrrID.Visible = true;
                    cdvCrrID.Visible = true;
#endif

                    pnlUnitMid_Resize(null, null);

                    SetCMFItem(MPGC.MP_CMF_TRN_CV);

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

        private void pnlUnitMid_Resize(object sender, EventArgs e)
        {
            int i_pnl_size = (int)Decimal.Round(pnlUnitMid.Width / 3);

            pnlUnit1.Width = i_pnl_size;
            pnlUnit2.Width = i_pnl_size;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (CheckCondition() == false) return;
            if (CV_Lot() == false) return;

            ViewLotInfo(txtLotID.Text);
        }

        private void cdvCauseRes_ButtonPress(object sender, System.EventArgs e)
        {

            try
            {
                if (txtLotID.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    txtLotID.Focus();
                    return;
                }
                if (cdvCauseOper.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvCauseOper.Focus();
                    return;
                }

                cdvCauseRes.Init();
                cdvCauseRes.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                cdvCauseRes.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvCauseRes.SelectedSubItemIndex = 0;
#if _RAS
                if (RASLIST.ViewResourceList(cdvCauseRes.GetListView, "%", 0, cdvCauseFlow.Text, cdvCauseOper.Text, false) == false)
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

        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {

            try
            {
                if (txtLotID.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    txtLotID.Focus();
                    return;
                }
                if (MPCF.Trim(LOT.GetString("OPER")) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                    return;
                }

                cdvResID.Init();
                cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvResID.SelectedSubItemIndex = 0;
#if _RAS
                if (RASLIST.ViewResourceList(cdvResID.GetListView, LOT.GetString("MAT_ID"), LOT.GetInt("MAT_VER"), LOT.GetString("FLOW"), LOT.GetString("OPER"), false) == false)
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

        private void cdvCauseFlow_ButtonPress(object sender, System.EventArgs e)
        {

            try
            {
                if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                    return;
                }

                cdvCauseFlow.Init();
                cdvCauseFlow.Columns.Add("Flow", 50, HorizontalAlignment.Left);
                cdvCauseFlow.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvCauseFlow.SelectedSubItemIndex = 0;

                if (WIPLIST.ViewFlowList(cdvCauseFlow.GetListView, '1', "", 0, "", null, "") == false)
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

        private void cdvCauseFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            try
            {
                cdvCauseOper.Text = "";

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }

        }

        private void cdvCauseOper_ButtonPress(object sender, System.EventArgs e)
        {

            try
            {
                if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                    return;
                }
                if (cdvCauseFlow.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvCauseFlow.Focus();
                    return;
                }

                cdvCauseOper.Init();
                cdvCauseOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvCauseOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvCauseOper.SelectedSubItemIndex = 0;

                if (WIPLIST.ViewOperationList(cdvCauseOper.GetListView, '2', "", 0, cdvCauseFlow.Text, "", null, "") == false)
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

        private void cdvCauseOper_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            try
            {
                cdvCauseRes.Text = "";

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }

        }

        private void cdvSublotGrade_ButtonPress(object sender, EventArgs e)
        {
            cdvSublotGrade.Init();
            MPCF.InitListView(cdvSublotGrade.GetListView);
            cdvSublotGrade.Columns.Add("Grade", 50, HorizontalAlignment.Left);
            cdvSublotGrade.Columns.Add("Desc", 50, HorizontalAlignment.Left);
            cdvSublotGrade.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvSublotGrade.GetListView, '1', MPGC.MP_WIP_SUBLOT_GRADE);
        }

        private void spdUnit_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            FarPoint.Win.Spread.FpSpread spdUnit;
            string s_cv_code;
            int i_code_index;
            int i;

            cdvCVCode.Tag = null;

            cdvCVCode.Init();
            cdvCVCode.ViewPosition = Control.MousePosition;
            MPCF.InitListView(cdvCVCode.GetListView);
            cdvCVCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvCVCode.Columns.Add("Desc", 50, HorizontalAlignment.Left);
            BASLIST.ViewGCMDataList(cdvCVCode.GetListView, '1', MPGC.MP_WIP_CV_CODE);

            if (cdvCVCode.Items.Count > 0)
            {
                spdUnit = (FarPoint.Win.Spread.FpSpread)sender;

                for (i = 0; i < spdUnit.ActiveSheet.RowCount; i++)
                {
                    s_cv_code = MPCF.Trim(spdUnit.ActiveSheet.GetValue(i, 0));
                    if (s_cv_code != "")
                    {
                        i_code_index = MPCF.FindListItemIndex(cdvCVCode.GetListView, s_cv_code, true);
                        if (i_code_index >= 0)
                        {
                            cdvCVCode.Items.RemoveAt(i_code_index);
                        }
                    }
                }

                if (cdvCVCode.Items.Count > 0)
                {
                    if (cdvCVCode.ShowPopupList(e.Row, e.Column) == false)
                    {
                        return;
                    }

                    cdvCVCode.Tag = sender;
                }
            }
        }

        private void cdvCVCode_SelectedItemChanged(System.Object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            if (cdvCVCode.Tag == null) return;

            FarPoint.Win.Spread.FpSpread spdUnit = (FarPoint.Win.Spread.FpSpread)cdvCVCode.Tag;

            spdUnit.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.Text;
        }

        private void spdUnit_EditModeOff(object sender, EventArgs e)
        {
            FarPoint.Win.Spread.FpSpread spdUnit;
            double d_total_cv_qty;
            int i;

            spdUnit = (FarPoint.Win.Spread.FpSpread)sender;

            if (spdUnit.ActiveSheet.ActiveColumnIndex == 2)
            {
                if (spdUnit.ActiveSheet.GetValue(spdUnit.ActiveSheet.ActiveRowIndex, 0) == null ||
                    MPCF.Trim(spdUnit.ActiveSheet.GetValue(spdUnit.ActiveSheet.ActiveRowIndex, 0)) == "")
                {
                    spdUnit.ActiveSheet.SetValue(spdUnit.ActiveSheet.ActiveRowIndex, 2, null);
                    return;
                }

                d_total_cv_qty = 0;

                for (i = 0; i < spdUnit.ActiveSheet.RowCount; i++)
                {
                    d_total_cv_qty += MPCF.ToDbl(spdUnit.ActiveSheet.GetValue(i, 2));
                }

                if (spdUnit.Name == "spdUnit1")
                {
                    txtCVQty1.Text = d_total_cv_qty.ToString("######,##0.###");
                    txtOutQty1.Text = ((double)(MPCF.ToDbl(txtQty1.Text) + d_total_cv_qty)).ToString("######,##0.###");
                }
                else if (spdUnit.Name == "spdUnit2")
                {
                    txtCVQty2.Text = d_total_cv_qty.ToString("######,##0.###");
                    txtOutQty2.Text = ((double)(MPCF.ToDbl(txtQty2.Text) + d_total_cv_qty)).ToString("######,##0.###");
                }
                else if (spdUnit.Name == "spdUnit3")
                {
                    txtCVQty3.Text = d_total_cv_qty.ToString("######,##0.###");
                    txtOutQty3.Text = ((double)(MPCF.ToDbl(txtQty3.Text) + d_total_cv_qty)).ToString("######,##0.###");
                }

                if (spdUnit.ActiveSheet.ActiveRowIndex == spdUnit.ActiveSheet.RowCount - 1)
                {
                    spdUnit.ActiveSheet.RowCount++;
                }
            }
        }


    }
}

