//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranRegenerateLot.vb
//   Description : Regenerate Lot Transaction
//
//   MES Version : 5.1.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - initCodeView() : initial CodeView Control
//       - CheckCondition() : Check the conditions before transaction
//       - View_Lot_Info() : View Lot Information
//       - Hold_Lot() : Adapt Lot transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2010-02-22 : Created by Aiden
//
//
//   Copyright(C) 1998-2010 MIRACOM,INC.
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

using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPTranRegenerateLot : Miracom.MESCore.TranForm07
    {
        public frmWIPTranRegenerateLot()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private string sQty1 = "";
        private string sQty2 = "";
        private string sQty3 = "";
        private bool bMFOCheckFlag = false;

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
            TRSNode lot_info = null;
            MPCF.FieldClear(this, txtLotID);
            if (MPCR.SetLotInfoSpread(spdLotInfo, '2', txtLotID.Text, ref lot_info) == false)
            {
                txtLotID.Focus();
                return false;
            }

            txtLotDesc.Text = lot_info.GetString("LOT_DESC");

            return true;
        }

        // ClearData()
        //       -   Clear Form Control Data
        // Return Value
        //       -
        // Arguments
        //       -
        private void ClearData(int iStep)
        {

            ClearLotSpread();

            switch (iStep)
            {
                case 0:

                    MPCF.FieldClear(this);
                    break;
            }
        }

        // CheckCondition()
        //       -   Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : create/update/delete Function name
        private bool CheckCondition()
        {
            string sQtyChk = "";

            if (MPCF.CheckValue(txtLotID, 1) == false)
            {
                return false;
            }
            if (cdvMaterial.CheckValue() == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvOperation, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvLotType, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvCreateCode, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvOwnerCode, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvLotType, 1) == false)
            {
                return false;
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
            
            if (CheckCMFItemValue() == false)
            {
                tabTran.SelectedTab = tbpCMF;
                return false;
            }

            if (MPCR.CheckGRPCMFValue("lblCrtCMF", "cdvCrtCMF", grpCrtCmf) == false)
            {
                tabTran.SelectedTab = tbpCreateCmf;
                return false;
            }

            return true;
        }

        private bool GetOperationList(string sFlow)
        {

            try
            {
                cdvOperation.Init();
                MPCF.InitListView(cdvOperation.GetListView);
                cdvOperation.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvOperation.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvOperation.SelectedSubItemIndex = 0;

                if (WIPLIST.ViewOperationList(cdvOperation.GetListView, '2', "", 0, sFlow, "", null, "") == false)
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
        private bool View_Material()
        {

            TRSNode in_node = new TRSNode("View_Material_In");
            TRSNode out_node = new TRSNode("View_Material_Out");

            bMFOCheckFlag = false;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
            in_node.AddInt("MAT_VER", cdvMaterial.Version);

            if (MPCR.CallService("WIP", "WIP_View_Material", in_node, ref out_node) == false)
            {
                return false;
            }

            bMFOCheckFlag = true;

            sQty1 = out_node.GetDouble("DEF_QTY_1").ToString();
            sQty2 = out_node.GetDouble("DEF_QTY_2").ToString();
            sQty3 = out_node.GetDouble("DEF_QTY_3").ToString();

            cdvFlow.Text = MPCF.Trim(out_node.GetString("FIRST_FLOW"));
            cdvFlow.Sequence = out_node.GetInt("FIRST_FLOW_SEQ_NUM");
            cdvOperation.Text = MPCF.Trim(out_node.GetString("FIRST_OPER"));

            if (MPCF.Trim(cdvOperation.Text) != "")
            {
                if (View_Operation() == false)
                {
                    return false;
                }
            }

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

            TRSNode in_node = new TRSNode("View_Flow_In");
            TRSNode out_node = new TRSNode("View_Flow_Out");

            bMFOCheckFlag = false;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));

            if (MPCR.CallService("WIP", "WIP_View_Flow", in_node, ref out_node) == false)
            {
                return false;
            }

            bMFOCheckFlag = true;

            cdvOperation.Text = MPCF.Trim(out_node.GetString("FIRST_OPER"));

            if (View_Operation() == false)
            {
                return false;
            }

            return true;

        }

        // View_Operation()
        //       -  View Operation Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Operation()
        {

            TRSNode in_node = new TRSNode("View_Operation_In");
            TRSNode out_node = new TRSNode("View_Operation_Out");

            bMFOCheckFlag = false;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", MPCF.Trim(cdvOperation.Text));

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return false;
            }

            bMFOCheckFlag = true;

            if (MPCF.Trim(out_node.GetString("UNIT_1")) != "")
            {
                txtQty1.ReadOnly = false;
                txtQty1.Text = sQty1;
                lblUnit1.Text = MPCF.Trim(out_node.GetString("UNIT_1"));
            }
            else
            {
                txtQty1.ReadOnly = true;
                txtQty1.Text = "";
                lblUnit1.Text = "";
            }
            if (MPCF.Trim(out_node.GetString("UNIT_2")) != "")
            {
                txtQty2.ReadOnly = false;
                txtQty2.Text = sQty2;
                lblUnit2.Text = MPCF.Trim(out_node.GetString("UNIT_2"));
            }
            else
            {
                txtQty2.ReadOnly = true;
                txtQty2.Text = "";
                lblUnit2.Text = "";
            }
            if (MPCF.Trim(out_node.GetString("UNIT_3")) != "")
            {
                txtQty3.ReadOnly = false;
                txtQty3.Text = sQty3;
                lblUnit3.Text = MPCF.Trim(out_node.GetString("UNIT_3"));
            }
            else
            {
                txtQty3.ReadOnly = true;
                txtQty3.Text = "";
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

            if (bMFOCheckFlag == false)
            {
                return false;
            }

            if (txtQty1.Text == "")
            {
                txtQty1.Text = "0";
            }

            if (cdvMaterial.CheckValue() == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvFlow, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvOperation, 1) == false)
            {
                return false;
            }

            dQty1 = MPCF.ToDbl(txtQty1.Text);

            if (MPCR.GetProcTime(cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, cdvFlow.Sequence, cdvOperation.Text, dQty1, ref dSumQueueTime, ref dSumProcTime, ref dSumQueueProcTime) == false)
            {
                txtDueDate.Text = "";
                return false;
            }

            //2006.04.25. CM Koo. CycleTime Unit???∞Îùº ?îÌïò???úÍ∞Ñ ?®ÏúÑÎ•??¨Î¶¨ ?ÅÏö©
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

        // Regenerate_Lot()
        //       -   Regenerate Lot transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool Regenerate_Lot()
        {
            TRSNode in_node = new TRSNode("REGENERATE_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("LOT_DESC", MPCF.Trim(txtLotDesc.Text));
                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                in_node.AddInt("MAT_VER", cdvMaterial.Version);
                in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
                in_node.AddInt("FLOW_SEQ_NUM", cdvFlow.Sequence);
                in_node.AddString("OPER", MPCF.Trim(cdvOperation.Text));
                in_node.AddChar("LOT_TYPE", MPCF.ToChar(cdvLotType.Text));
                if (txtQty1.Text != "")
                {
                    in_node.AddDouble("QTY_1", MPCF.ToDbl(txtQty1.Text));
                }
                else
                {
                    in_node.AddDouble("QTY_1", 0);
                }
                if (txtQty2.Text != "")
                {
                    in_node.AddDouble("QTY_2", MPCF.ToDbl(txtQty2.Text));
                }
                else
                {
                    in_node.AddDouble("QTY_2", 0);
                }
                if (txtQty3.Text != "")
                {
                    in_node.AddDouble("QTY_3", MPCF.ToDbl(txtQty3.Text));
                }
                else
                {
                    in_node.AddDouble("QTY_3", 0);
                }
                in_node.AddString("CREATE_CODE", MPCF.Trim(cdvCreateCode.Text));
                in_node.AddString("OWNER_CODE", MPCF.Trim(cdvOwnerCode.Text));
#if _CRR
                in_node.AddString("CRR_ID", MPCF.Trim(cdvCarrier.Text));
#endif
                in_node.AddChar("LOT_PRIORITY", MPCF.ToChar(cboPriority.Text));
                in_node.AddString("DUE_TIME", MPCF.ToStandardTime(dtpDueDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));
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

                in_node.AddString("LOT_CMF_1", MPCF.Trim(cdvCrtCmf1.Text));
                in_node.AddString("LOT_CMF_2", MPCF.Trim(cdvCrtCmf2.Text));
                in_node.AddString("LOT_CMF_3", MPCF.Trim(cdvCrtCmf3.Text));
                in_node.AddString("LOT_CMF_4", MPCF.Trim(cdvCrtCmf4.Text));
                in_node.AddString("LOT_CMF_5", MPCF.Trim(cdvCrtCmf5.Text));
                in_node.AddString("LOT_CMF_6", MPCF.Trim(cdvCrtCmf6.Text));
                in_node.AddString("LOT_CMF_7", MPCF.Trim(cdvCrtCmf7.Text));
                in_node.AddString("LOT_CMF_8", MPCF.Trim(cdvCrtCmf8.Text));
                in_node.AddString("LOT_CMF_9", MPCF.Trim(cdvCrtCmf9.Text));
                in_node.AddString("LOT_CMF_10", MPCF.Trim(cdvCrtCmf10.Text));
                in_node.AddString("LOT_CMF_11", MPCF.Trim(cdvCrtCmf11.Text));
                in_node.AddString("LOT_CMF_12", MPCF.Trim(cdvCrtCmf12.Text));
                in_node.AddString("LOT_CMF_13", MPCF.Trim(cdvCrtCmf13.Text));
                in_node.AddString("LOT_CMF_14", MPCF.Trim(cdvCrtCmf14.Text));
                in_node.AddString("LOT_CMF_15", MPCF.Trim(cdvCrtCmf15.Text));
                in_node.AddString("LOT_CMF_16", MPCF.Trim(cdvCrtCmf16.Text));
                in_node.AddString("LOT_CMF_17", MPCF.Trim(cdvCrtCmf17.Text));
                in_node.AddString("LOT_CMF_18", MPCF.Trim(cdvCrtCmf18.Text));
                in_node.AddString("LOT_CMF_19", MPCF.Trim(cdvCrtCmf19.Text));
                in_node.AddString("LOT_CMF_20", MPCF.Trim(cdvCrtCmf20.Text));

                if (MPCR.CallService("WIP", "WIP_Regenerate_Lot", in_node, ref out_node) == false)
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

        private void frmWIPTranRegenerateLot_Load(object sender, EventArgs e)
        {
            this.tabTran.TabPages.Remove(this.tbpCMF);
            this.tabTran.Controls.Add(this.tbpCMF);
#if _CRR
            lblCarrier.Visible = true;
            cdvCarrier.Visible = true;
#endif
        }

        private void frmWIPTranRegenerateLot_Activated(object sender, System.EventArgs e)
        {

            if (b_load_flag == false)
            {

                ClearData(0);
                SetCMFItem(MPGC.MP_CMF_TRN_REGENERATE);
                MPCR.SetCMFItem(MPGC.MP_CMF_LOT, "lblCrtCMF", "cdvCrtCMF", grpCrtCmf);

                b_load_flag = true;
            }
        }

        private void txtLotID_TextChanged(object sender, System.EventArgs e)
        {
            if (txtLotID.Text == "")
            {
                ClearData(0);
            }
        }

        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition() == false) return;
            
            if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_REGENERATE, LOT.GetString("LOT_ID"), "", "", 'B') == false) return;
            if (Regenerate_Lot() == false) return;
            if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_REGENERATE, LOT.GetString("LOT_ID"), "", "", 'A') == false) return;

            ViewLotInfo(txtLotID.Text);
        }


        private void cdvCrtCmf_ButtonPress(object sender, System.EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);

        }

        private void cdvCrtCmf_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);

        }

        private void cdvMaterial_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            cdvFlow.Text = "";
            cdvOperation.Text = "";

            cdvFlow.ListCond_MatID = cdvMaterial.Text;
            cdvFlow.ListCond_MatVersion = cdvMaterial.Version;

            if (View_Material() == false)
            {
                return;
            }

        }

        private void cdvMaterial_TextBoxTextChanged(object sender, System.EventArgs e)
        {

            chkDueDate.Checked = false;
            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;

        }

        private void cdvFlow_FlowButtonPress(object sender, EventArgs e)
        {
            if (cdvMaterial.CheckValue() == false) return;
        }

        private void cdvFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            View_Flow();

        }

        private void cdvFlow_TextBoxTextChanged(object sender, System.EventArgs e)
        {

            chkDueDate.Checked = false;
            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;

        }

        private void cdvOperation_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {

            if (View_Operation() == false)
            {
                return;
            }

        }

        private void cdvOperation_ButtonPress(object sender, System.EventArgs e)
        {

            if (cdvMaterial.CheckValue() == false)
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

        private void cdvOperation_TextBoxTextChanged(object sender, System.EventArgs e)
        {

            chkDueDate.Checked = false;
            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;

        }


        private void chkDueDate_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            txtDueDate.Visible = !chkDueDate.Checked;
        }

        private void txtQty1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (MPGO.AutoCalDueDate() == true)
                {
                    if (SetDueDate() == false)
                    {
                        return;
                    }
                }
            }

        }

        private void cdvCarrier_ButtonPress(object sender, System.EventArgs e)
        {
#if _CRR
            try
            {
                cdvCarrier.Init();
                MPCF.InitListView(cdvCarrier.GetListView);
                cdvCarrier.Columns.Add("Code", 50, HorizontalAlignment.Left);
                cdvCarrier.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvCarrier.SelectedSubItemIndex = 0;

                if (RASLIST.ViewCarrierList(cdvCarrier.GetListView, '2', "", "", "", ' ', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, cdvOperation.Text, "", "", cdvCarrier.Text, null, "") == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
#endif
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

        private void cdvOperation_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (cdvOperation.Text != "")
                {
                    if (View_Operation() == false)
                    {
                        return;
                    }
                }
            }
        }


    }
}