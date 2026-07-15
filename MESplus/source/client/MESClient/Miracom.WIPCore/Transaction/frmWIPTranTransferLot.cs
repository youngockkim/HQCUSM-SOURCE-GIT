
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranTransferLot.cs
//   Description : Transfer Lot Transaction
//
//   MES Version : 5.2.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - initCodeView() : initial CodeView Control
//       - CheckCondition() : Check the conditions before transaction
//       - View_Lot_Info() : View Lot Information
//       - Transfer_Lot() : Transfer Lot transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2012-03-27 : Created by CM Koo
//
//
//   Copyright(C) 1998-2012 MIRACOM,INC.
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
    public partial class frmWIPTranTransferLot : Miracom.MESCore.TranForm07
    {
        public frmWIPTranTransferLot()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private const string MFO_OPT_TRANSFER_OPER_DEF = "TRANSFER_OPER_DEF";

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;

        #endregion

        #region " Function Definition "
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
                case 1:

                    MPCF.FieldClear(this, txtLotID);
                    txtLotID.Focus();
                    break;
            }
        }

        // ViewLotInfo()
        //       -   View Lot Information
        // Return Value
        //       -
        // Arguments
        //       -
        protected override bool ViewLotInfo(string s_lot_id)
        {
            MPCF.FieldClear(this, txtLotID);
            base.ViewLotInfo(s_lot_id);
            View_Transfer_Oper_List();

            txtLotID.Focus();

            return true;
        }

        // CheckCondition()
        //       -   Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : create/update/delete Function name
        private bool CheckCondition()
        {

            if (MPCF.CheckValue(txtLotID, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvToFactory, 1) == false)
            {
                tabTran.SelectedTab = tbpGeneral;
                cdvToFactory.Focus();
                return false;
            }
            if (MPCF.CheckValue(cdvShipCode, 1) == false)
            {
                tabTran.SelectedTab = tbpGeneral;
                cdvShipCode.Focus();
                return false;
            }
            if (MPCF.CheckValue(udcToFlow, 1) == false)
            {
                tabTran.SelectedTab = tbpGeneral;
                udcToFlow.Focus();
                return false;
            }
            if (MPCF.CheckValue(txtToOper, 1) == false)
            {
                tabTran.SelectedTab = tbpGeneral;
                txtToOper.Focus();
                return false;
            }

            if (CheckCMFItemValue() == false)
            {
                tabTran.SelectedTab = tbpCMF;
                return false;
            }

            return true;
        }

        // Transfer_Lot()
        //       -   Transfer Lot transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool Transfer_Lot()
        {
            TRSNode in_node = new TRSNode("TRANSFER_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

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
                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("TRANSFER_CODE", MPCF.Trim(cdvShipCode.Text));
                in_node.AddString("TO_FACTORY", MPCF.Trim(cdvToFactory.Text));
                in_node.AddString("TO_MAT_ID", MPCF.Trim(udcMatID.Text));
                in_node.AddInt("TO_MAT_VER", udcMatID.Version);
                in_node.AddString("TO_FLOW", MPCF.Trim(udcToFlow.Text));
                in_node.AddString("TO_OPER", MPCF.Trim(txtToOper.Text));

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

                if (MPCR.CallService("WIP", "WIP_Transfer_Lot", in_node, ref out_node) == false)
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

        private bool View_Transfer_Oper_List()
        {
            TRSNode in_node = new TRSNode("VIEW_MFO_OPTION_IN");
            TRSNode out_node = new TRSNode("VIEW_MFO_OPTION_OUT");
            ListViewItem itm;
            int i;

            try
            {
                cdvToFactory.Init();
                MPCF.InitListView(cdvToFactory.GetListView);
                cdvToFactory.Columns.Add("Factory", 150, HorizontalAlignment.Left);
                cdvToFactory.Columns.Add("Flow", 200, HorizontalAlignment.Left);
                cdvToFactory.Columns.Add("Oper", 200, HorizontalAlignment.Left);
                cdvToFactory.Columns.Add("Override Flag", 10, HorizontalAlignment.Left);
                cdvToFactory.SelectedSubItemIndex = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", LOT.GetString("LOT_ID"));
                in_node.AddString("OPTION_NAME", MFO_OPT_TRANSFER_OPER_DEF);
                in_node.AddString("KEY_1", "Y");

                in_node.AddInt("OPTION_SEQ", 0);
                in_node.AddChar("BASE_FLAG", 'M');
                in_node.AddChar("ORDER_FLAG", 'A');
                in_node.AddChar("FIRST_LAST_FLAG", ' ');

                if (MPCR.CallService("WIP", "WIP_View_MFO_Option_Value", in_node, ref out_node) == false)
                {
                    return false;
                }

                for(i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itm = new ListViewItem(out_node.GetList(0)[i].GetString("DATA_1"), (int)SMALLICON_INDEX.IDX_FACTORY);
                    itm.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_2"));
                    itm.SubItems.Add(out_node.GetList(0)[i].GetString("DATA_3"));
                    itm.SubItems.Add(out_node.GetList(0)[i].GetString("KEY_2"));

                    cdvToFactory.Items.Add(itm);
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

        private void frmWIPTranTransferLot_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                ClearData(0);
                SetCMFItem(MPGC.MP_CMF_TRN_SHIP);

                if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                {
                    txtLotID.Text = MPGV.gsCurrentLot_ID;
                    ViewLotInfo(txtLotID.Text);
                }

                b_load_flag = true;
            }
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
            udcToFlow.Text = MPCF.Trim(e.SelectedItem.SubItems[1].Text);
            txtToOper.Text = MPCF.Trim(e.SelectedItem.SubItems[2].Text);

            udcMatID.ListCond_ExtFactory = MPCF.Trim(e.SelectedItem.SubItems[0].Text);
            udcMatID.Text = LOT.GetString("MAT_ID");
            udcMatID.Version = LOT.GetInt("MAT_VER");

            if (MPCF.Trim(e.SelectedItem.SubItems[3].Text) == "Y")
            {
                udcMatID.MaterialReadOnly = false;
                udcMatID.VersionReadOnly = false;
                udcMatID.VisibleMaterialButton = true;
                udcMatID.VisibleVersionButton = true;
            }
            else
            {
                udcMatID.MaterialReadOnly = true;
                udcMatID.VersionReadOnly = true;
                udcMatID.VisibleMaterialButton = false;
                udcMatID.VisibleVersionButton = false;
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
            if (Transfer_Lot() == false) return;

            ClearData(1);
        }

        private void udcMatID_MaterialSelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (udcMatID.Text != "")
            {
                udcToFlow.Text = "";
            }
        }

        /* 2013.06.12. Aiden. Flow 가 없는 경우 To Factory 의 To Material 에 할당된 Flow 를 선택하도록 변경 */
        private void udcFlow_FlowButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(udcMatID, 1) == false) return;

            udcToFlow.ListCond_Step = '2';
            udcToFlow.ListCond_MatID = udcMatID.Text;
            udcToFlow.ListCond_MatVersion = udcMatID.Version;
            udcToFlow.ListCond_ExtFactory = cdvToFactory.Text;
        }

    
    }
}
