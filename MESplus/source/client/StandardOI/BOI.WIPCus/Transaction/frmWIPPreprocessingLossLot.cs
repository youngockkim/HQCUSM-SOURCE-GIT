using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using BOI.OIFrx.BOIBaseForm;
using BOI.OIFrx;

namespace BOI.WIPCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmWIPPreprocessingLossLot : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        public string _sLotId = string.Empty;

        private enum LOSS_COL
        {
            LOSS_CODE,
            LOSS_DESC,
            LOSS_QTY
        }

        #endregion

        #region Constructor

        public frmWIPPreprocessingLossLot()
        {
            InitializeComponent();
        }

        public frmWIPPreprocessingLossLot(string args)
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
        private void frmTempBOIBaseForm02_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempBOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                


                MPCF.ClearList(spdLossList);

                if (_sLotId != "")
                {
                    boiLotInfo.View_Lot_Info(_sLotId);
                }

                cdvWorkUser.Text = MPGV.gsUserID;
                txtColSetID.Text = "";
                txtColSetID.Tag = "";

                // (Required) 
                bIsShown = true;
            }
        }

        private void cdvLossCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                MenuInfoTag selectedMenuInfo;

                BOI.WIPCus.Popup.frmWIPSelectLossCode frm = new BOI.WIPCus.Popup.frmWIPSelectLossCode(txtColSetID.Tag.ToString() + ":" + txtColSetID.Text);

                selectedMenuInfo = new MenuInfoTag();
                selectedMenuInfo.s_func_desc = "Loss";
                frm.Tag = selectedMenuInfo;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.Oper = boiLotInfo.Oper;
                frm.ShowDialog();

                cdvLossCode.Text = frm.lossDesc;
                cdvLossCode.Tag = frm.lossCode;
                txtColSetID.Text = frm.colSetDesc;
                txtColSetID.Tag = frm.colSetId;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

            //try
            //{
            //    TRSNode in_node = new TRSNode("VIEW_LOSS_CODE_IN");
            //    TRSNode out_node = new TRSNode("VIEW_LOSS_CODE_OUT");

            //    // In Node Setup
            //    in_node.Init();
            //    MPCF.SetInMsg(in_node);
            //    in_node.ProcStep = '1';
            //    in_node.AddString("OPER", boiLotInfo.Oper);
            //    in_node.AddString("COL_GRP_1", BIGC.B_COL_GRP_1_PQ);

            //    // CodeView Column Header Setup
            //    string[] header = new string[] { "Loss Code", "Description" };

            //    // CodeView Display Column Setup
            //    string[] display = new string[] { "LOSS_CODE", "LOSS_DESC" };

            //    // Show
            //    cdvLossCode.Text = cdvLossCode.Show(cdvLossCode, "Loss", "BWIP", "BWIP_View_Collection_Character", in_node, "DATA_LIST", display, header, "LOSS_DESC");

            //    if (MPCF.Trim(cdvLossCode.Text) != "")
            //    {
            //        if (cdvLossCode.returnDatas != null && cdvLossCode.returnDatas.Count > 0)
            //        {
            //            cdvLossCode.Tag = cdvLossCode.returnDatas[0];
            //            cdvLossCode.Text = cdvLossCode.returnDatas[1];

            //            txtLossQty.Value = 0;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            //}
        }

        private void txtLossQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    AddRow();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        private void AddRow()
        {
            int iRow = 0;
            double dTotalLossQty = 0;
            bool b_update_flag = false;
            object tempQty = 0;

            try
            {
                if (MPCF.Trim(cdvLossCode.Text) == "" || MPCF.Trim(cdvLossCode.Tag) == "")
                {
                    MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                    cdvLossCode.Focus();
                    return;
                }

                iRow = spdLossList.Sheets[0].RowCount;

                if(iRow == 0)
                {
                    if (boiLotInfo.LotQty < MPCF.ToDbl(txtLossQty.Value))
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(198), MSG_LEVEL.WARNING, true);
                        txtLossQty.Focus();
                        return;
                    }
                }

                for (int i = 0; i < iRow; i++)
                {
                    if (spdLossList.Sheets[0].Cells[i, (int)LOSS_COL.LOSS_CODE].Value.ToString() == cdvLossCode.Tag.ToString())
                    {
                        tempQty = spdLossList.Sheets[0].Cells[i, (int)LOSS_COL.LOSS_QTY].Value;
                        //MPCF.ShowMessage(MPCF.GetMessage(428), MSG_LEVEL.WARNING, true);
                        //cdvLossCode.Focus();
                        spdLossList.Sheets[0].Cells[i, (int)LOSS_COL.LOSS_QTY].Value = txtLossQty.Value;
                        b_update_flag = true;
                        //return;
                    }
                   
                    dTotalLossQty += MPCF.ToDbl(spdLossList.Sheets[0].Cells[i, (int)LOSS_COL.LOSS_QTY].Value);

                    if (boiLotInfo.LotQty < dTotalLossQty)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(198), MSG_LEVEL.WARNING, true);
                        txtLossQty.Focus();
                        spdLossList.Sheets[0].Cells[i, (int)LOSS_COL.LOSS_QTY].Value = tempQty;
                        return;
                    }
                }

                if (b_update_flag != true)
                {
                    dTotalLossQty += MPCF.ToDbl(txtLossQty.Value);

                    if (boiLotInfo.LotQty < dTotalLossQty)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(198), MSG_LEVEL.WARNING, true);
                        txtLossQty.Focus();
                        return;
                    }

                    spdLossList.Sheets[0].RowCount = iRow + 1;
                    spdLossList.Sheets[0].Cells[iRow, (int)LOSS_COL.LOSS_CODE].Value = cdvLossCode.Tag.ToString();
                    spdLossList.Sheets[0].Cells[iRow, (int)LOSS_COL.LOSS_DESC].Value = cdvLossCode.Text;
                    spdLossList.Sheets[0].Cells[iRow, (int)LOSS_COL.LOSS_QTY].Value = txtLossQty.Value;
                }

                MPCF.FitColumnHeader(spdLossList);

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("LOSS_LOT") == true)
                {
                    if (Loss_Lot('1') == true)
                    {
                        MPCF.ClearList(spdLossList);
                        boiLotInfo.View_Lot_Info(_sLotId);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "LOSS_LOT":

                        if (spdLossList.Sheets[0].RowCount < 1)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(429), MSG_LEVEL.WARNING, true);
                            return false;
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        // Loss_Lot()
        //       - Loss Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Loss_Lot(char ProcStep)
        {
            TRSNode in_node = new TRSNode("LOSS_LOT_IN");
            TRSNode out_node = new TRSNode("LOSS_LOT_OUT");
            TRSNode list_item;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("LOT_ID", _sLotId);
                in_node.AddString("LOSS_CODE_TYPE", BIGC.B_LOSS_CODE_TYPE_P);

                for (int i = 0; i < spdLossList.Sheets[0].RowCount; i++)
                {
                    list_item = in_node.AddNode("UNIT1");
                    list_item.AddString("CODE", MPCF.Trim(spdLossList.Sheets[0].Cells[i, (int)LOSS_COL.LOSS_CODE].Value));
                    list_item.AddString("CODE_DESC", MPCF.Trim(spdLossList.Sheets[0].Cells[i, (int)LOSS_COL.LOSS_DESC].Value));
                    list_item.AddDouble("QTY", MPCF.Trim(spdLossList.Sheets[0].Cells[i, (int)LOSS_COL.LOSS_QTY].Value));
                }

                if (MPCF.CallService("BWIP", "BWIP_Tran_Loss_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private void spdLossList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (e.Column == (int)LOSS_COL.LOSS_CODE)
                {
                    spdLossList.Sheets[0].RemoveRows(e.Row, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdLossList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (e.Column != (int)LOSS_COL.LOSS_CODE)
                {
                    cdvLossCode.Text = spdLossList.Sheets[0].Cells[e.Row, (int)LOSS_COL.LOSS_DESC].Value.ToString();
                    cdvLossCode.Tag = spdLossList.Sheets[0].Cells[e.Row, (int)LOSS_COL.LOSS_CODE].Value.ToString();
                    txtLossQty.Value = spdLossList.Sheets[0].Cells[e.Row, (int)LOSS_COL.LOSS_QTY].Value; 
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
    }
}
