using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;

namespace BOI.WIPCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmWIPViewLotStatus : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private TRSNode ORDER;
        private string _sLotId = string.Empty;

        #endregion

        #region Constructor

        public frmWIPViewLotStatus()
        {
            InitializeComponent();
        }

        public frmWIPViewLotStatus(string args)
        {
            InitializeComponent();
            if (args != "")
            {
                _sLotId = args;
            }
        }


        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWIPViewLotStatus_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
            ORDER = new TRSNode("ORDER_INFO");
        }
        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWIPViewLotStatus_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                

                if (_sLotId != "")
                {
                    txtLotID.Text = _sLotId;
                    btnProcess.PerformClick();
                }
                else
                {
                    MPCF.SetFocus(txtLotID);
                }

                // (Required) 
                bIsShown = true;
            }
        }
        

        /// <summary>
        /// Lot ID Key Down Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLotID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    btnProcess.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        /// <summary>
        /// (Required) Close Button Click
        /// - Form Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // 종료
            this.Close();
        }
        
        #endregion

        #region "Functions"

        ///// <summary>
        ///// CMF Button Visible 여부를 확인합니다.
        ///// </summary>
        //private bool ShowCMFButton(string sItemName)
        //{
        //    bool bReturn = false;

        //    try
        //    {
        //        // 해당 CMF Setup Table 추출
        //        TRSNode in_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_IN");
        //        TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");

        //        MPCF.SetInMsg(in_node);
        //        in_node.ProcStep = '1';
        //        in_node.AddString("ITEM_NAME", sItemName);

        //        if (MPCF.CallService("WIP", "WIP_View_Factory_Cmf_Item", in_node, out_node) == false)
        //        {
        //            btnViewCMF.Visibility = System.Windows.Visibility.Collapsed;
        //            return false;
        //        }

        //        if (out_node.ListCount > 0
        //            && out_node.GetList(0).Count > 0)
        //        {
        //            btnViewCMF.Visibility = System.Windows.Visibility.Collapsed;

        //            for (int i = 0; i < out_node.GetList(0).Count; i++)
        //            {
        //                // PROMPT가 값이 있는 경우 등록
        //                if (out_node.GetList(0)[i].GetString("PROMPT") != "")
        //                {
        //                    btnViewCMF.Visibility = System.Windows.Visibility.Visible;
        //                    bReturn = true;
        //                    return bReturn;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            btnViewCMF.Visibility = System.Windows.Visibility.Collapsed;
        //            return bReturn;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
        //    }

        //    return bReturn;
        //}

       
        /// <summary>
        /// Lot 조회
        /// </summary>
        /// <param name="sLotId"></param>
        /// <returns></returns>
        private bool ViewLot(string sLotId)
        {
            //_cmfDatas = new CMFReturnData();

            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", sLotId);

                if (MPCF.CallService("BINV", "BINV_View_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                //MPCF.SetInMsg(in_node);
                //in_node.ProcStep = '1';
                //in_node.AddString("ORDER_ID", out_node.GetString("ORDER_ID"));

                //if (MPCF.CallService("ORD", "ORD_View_Order", in_node, ref ORDER) == false)
                //{
                //    return false;
                //}

                txtLotDesc.Text = MPCF.Trim(out_node.GetString("LOT_DESC"));
                txtMatID.Text = MPCF.Trim(out_node.GetString("MAT_ID")) + " : " + out_node.GetString("MAT_DESC");
                txtFlow.Text = MPCF.Trim(out_node.GetString("FLOW")) + " : " + out_node.GetString("FLOW_DESC");
                txtOper.Text = MPCF.Trim(out_node.GetString("OPER")) + " : " + out_node.GetString("OPER_DESC");

                txtLotType.Text = MPCF.Trim(out_node.GetChar("LOT_TYPE"));
                //foreach (LotTypeInfo ltinfo in _model.LotTypeList)
                //{
                //    if (_model.kvLotType == ltinfo.Type)
                //    {
                //        _model.kvLotType = ltinfo.Description;
                //        break;
                //    }
                //}

                txtLotStatus.Text = MPCF.Trim(out_node.GetString("LOT_STATUS"));
                txtQty.Text = MPCF.Trim(out_node.GetDouble("QTY_1"));
                txtLotDelCode.Text = MPCF.Trim(out_node.GetString("LOT_DEL_CODE"));
                txtShipCode.Text = MPCF.Trim(out_node.GetString("SHIP_CODE"));

                txtOrderID.Text = MPCF.Trim(out_node.GetString("ORDER_ID")) + " : " + ORDER.GetString("ORDER_DESC");
                txtStartTime.Text = MPCF.MakeDateFormat(out_node.GetString("START_TIME"));
                txtStartResID.Text = MPCF.Trim(out_node.GetString("START_RES_ID"));
                txtEndTime.Text = MPCF.MakeDateFormat(out_node.GetString("END_TIME"));
                txtEndResID.Text = MPCF.Trim(out_node.GetString("END_RES_ID"));
                txtShipTime.Text = MPCF.MakeDateFormat(out_node.GetString("SHIP_TIME"));
                txtSchDueTime.Text = MPCF.MakeDateFormat(out_node.GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE);
                txtHoldCode.Text = MPCF.Trim(out_node.GetString("HOLD_CODE"));

                chkStartFlag.Checked = out_node.GetChar("START_FLAG") == 'Y' ? true : false;
                chkEndFlag.Checked = out_node.GetChar("END_FLAG") == 'Y' ? true : false;
                chkLotDelFlag.Checked = out_node.GetChar("LOT_DEL_FLAG") == 'Y' ? true : false;
                chkHoldFlag.Checked = out_node.GetChar("HOLD_FLAG") == 'Y' ? true : false;
                chkReworkFlag.Checked = out_node.GetChar("RWK_FLAG") == 'Y' ? true : false;
                chkRepairFlag.Checked = out_node.GetChar("REP_FLAG") == 'Y' ? true : false;
                chkInventoryFlag.Checked = out_node.GetChar("INV_FLAG") == 'Y' ? true : false;

                //_cmfDatas.LotCMF1 = out_node.GetString("LOT_CMF_1");
                //_cmfDatas.LotCMF2 = out_node.GetString("LOT_CMF_2");
                //_cmfDatas.LotCMF3 = out_node.GetString("LOT_CMF_3");
                //_cmfDatas.LotCMF4 = out_node.GetString("LOT_CMF_4");
                //_cmfDatas.LotCMF5 = out_node.GetString("LOT_CMF_5");
                //_cmfDatas.LotCMF6 = out_node.GetString("LOT_CMF_6");
                //_cmfDatas.LotCMF7 = out_node.GetString("LOT_CMF_7");
                //_cmfDatas.LotCMF8 = out_node.GetString("LOT_CMF_8");
                //_cmfDatas.LotCMF9 = out_node.GetString("LOT_CMF_9");
                //_cmfDatas.LotCMF10 = out_node.GetString("LOT_CMF_10");
                //_cmfDatas.LotCMF11 = out_node.GetString("LOT_CMF_11");
                //_cmfDatas.LotCMF12 = out_node.GetString("LOT_CMF_12");
                //_cmfDatas.LotCMF13 = out_node.GetString("LOT_CMF_13");
                //_cmfDatas.LotCMF14 = out_node.GetString("LOT_CMF_14");
                //_cmfDatas.LotCMF15 = out_node.GetString("LOT_CMF_15");
                //_cmfDatas.LotCMF16 = out_node.GetString("LOT_CMF_16");
                //_cmfDatas.LotCMF17 = out_node.GetString("LOT_CMF_17");
                //_cmfDatas.LotCMF18 = out_node.GetString("LOT_CMF_18");
                //_cmfDatas.LotCMF19 = out_node.GetString("LOT_CMF_19");
                //_cmfDatas.LotCMF20 = out_node.GetString("LOT_CMF_20");
                //_cmfDatas.TranCMF1 = out_node.GetString("TRAN_CMF_1");
                //_cmfDatas.TranCMF2 = out_node.GetString("TRAN_CMF_2");
                //_cmfDatas.TranCMF3 = out_node.GetString("TRAN_CMF_3");
                //_cmfDatas.TranCMF4 = out_node.GetString("TRAN_CMF_4");
                //_cmfDatas.TranCMF5 = out_node.GetString("TRAN_CMF_5");
                //_cmfDatas.TranCMF6 = out_node.GetString("TRAN_CMF_6");
                //_cmfDatas.TranCMF7 = out_node.GetString("TRAN_CMF_7");
                //_cmfDatas.TranCMF8 = out_node.GetString("TRAN_CMF_8");
                //_cmfDatas.TranCMF9 = out_node.GetString("TRAN_CMF_9");
                //_cmfDatas.TranCMF10 = out_node.GetString("TRAN_CMF_10");
                //_cmfDatas.TranCMF11 = out_node.GetString("TRAN_CMF_11");
                //_cmfDatas.TranCMF12 = out_node.GetString("TRAN_CMF_12");
                //_cmfDatas.TranCMF13 = out_node.GetString("TRAN_CMF_13");
                //_cmfDatas.TranCMF14 = out_node.GetString("TRAN_CMF_14");
                //_cmfDatas.TranCMF15 = out_node.GetString("TRAN_CMF_15");
                //_cmfDatas.TranCMF16 = out_node.GetString("TRAN_CMF_16");
                //_cmfDatas.TranCMF17 = out_node.GetString("TRAN_CMF_17");
                //_cmfDatas.TranCMF18 = out_node.GetString("TRAN_CMF_18");
                //_cmfDatas.TranCMF19 = out_node.GetString("TRAN_CMF_19");
                //_cmfDatas.TranCMF20 = out_node.GetString("TRAN_CMF_20");
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion

        /// <summary>
        /// View Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(txtLotID, false) == false)
            {
                return;
            }

            if (ViewLot(txtLotID.Text) == false)
            {
                return;
            }
        }


      


    }
}
