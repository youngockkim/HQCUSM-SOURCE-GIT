//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmCUSTranLossLot.cs
//   Description :
//
//   MES Version : 5.3.5.0
//
//   Function List
//       - 
//
//   Detail Description
//       -
//
//   Use Service Module
//      Service
//       - 
//      Query
//       - 
//       - 
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2017-08-09 : Created by bkwoo
//
//
//   Copyright(C) 1998-2017 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using BOI.OIFrx;
using BOI.OIFrx.BOIBaseForm;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.DNM;
using SOI.CliFrx;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using BOI.OIFrx.BOIControls;

namespace SOI.Solar
{
    public partial class frmCUSTranLossLot : BOIBaseForm02
    {
        #region [Property]

        const int ENTER = 13;

        #endregion

        public frmCUSTranLossLot()
        {
            InitializeComponent();
        }

        #region [Constant Definition]

        private enum LOT_LIST : int
        {
            SEQ,
            LOT_ID,
            PROD_LOT_ID,
            MAT_ID,
            MAT_DESC,
            QTY_1,
            UNIT_1
        }

        private enum LOSS_COL
        {
            LOSS_CODE,
            LOSS_DESC,
            LOSS_QTY
        }

        public string gLotID { private get; set; } // LOT ID

        #endregion

        #region [Variable Definition]

        private bool bIsShown = false;

        #endregion

        #region [FormDefinition]


        #endregion

        #region [Function Definition]

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
                if (ProcStep == "1")
                {
                    MPCF.ClearList(spdLotInfo);
                    txtLotID.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private bool AddRow()
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
                    return false;
                }

                iRow = spdLossList.Sheets[0].RowCount;

                if (iRow == 0)
                {
                    if (MPCF.ToDbl(spdLotInfo.ScreenSpread.ActiveSheet.Cells[3, 1].Text) < MPCF.ToDbl(txtLossQty.Value))
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(198), MSG_LEVEL.WARNING, true);
                        txtLossQty.Focus();
                        return false;
                    }

                    if(MPCF.ToDbl(txtLossQty.Value) == 0)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                        txtLossQty.Focus();
                        return false;
                    }
                }

                for (int i = 0; i < iRow; i++)
                {
                    if (spdLossList.Sheets[0].Cells[i, (int)LOSS_COL.LOSS_CODE].Value.ToString() == cdvLossCode.Tag.ToString())
                    {
                        tempQty = spdLossList.Sheets[0].Cells[i, (int)LOSS_COL.LOSS_QTY].Value;
                        spdLossList.Sheets[0].Cells[i, (int)LOSS_COL.LOSS_QTY].Value = txtLossQty.Value;
                        b_update_flag = true;
                    }

                    dTotalLossQty += MPCF.ToDbl(spdLossList.Sheets[0].Cells[i, (int)LOSS_COL.LOSS_QTY].Value);

                    if (MPCF.ToDbl(spdLotInfo.ScreenSpread.ActiveSheet.Cells[3, 1].Text) < dTotalLossQty)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(198), MSG_LEVEL.WARNING, true);
                        txtLossQty.Focus();
                        spdLossList.Sheets[0].Cells[i, (int)LOSS_COL.LOSS_QTY].Value = tempQty;
                        return false;
                    }
                }

                if (b_update_flag != true)
                {
                    dTotalLossQty += MPCF.ToDbl(txtLossQty.Value);

                    if (MPCF.ToDbl(spdLotInfo.ScreenSpread.ActiveSheet.Cells[3, 1].Text) < dTotalLossQty)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(198), MSG_LEVEL.WARNING, true);
                        txtLossQty.Focus();
                        return false;
                    }

                    spdLossList.Sheets[0].RowCount = iRow + 1;
                    spdLossList.Sheets[0].Cells[iRow, (int)LOSS_COL.LOSS_CODE].Value = cdvLossCode.Tag.ToString();
                    spdLossList.Sheets[0].Cells[iRow, (int)LOSS_COL.LOSS_DESC].Value = cdvLossCode.Text;
                    spdLossList.Sheets[0].Cells[iRow, (int)LOSS_COL.LOSS_QTY].Value = txtLossQty.Value;
                }

                MPCF.FitColumnHeader(spdLossList);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// View Lot
        /// </summary>
        /// <param name="sLotID"></param>
        /// <returns></returns>
        private bool Tran_Loss_Lot(string sLotID)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");
            TRSNode list_item;
            double d_sum = 0;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '4';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));
                in_node.AddString("INV_LOT_ID", MPCF.Trim(sLotID));
                in_node.AddString("LOSS_CODE", MPCF.Trim(cdvLossCode.Tag));
                in_node.AddString("OPER", spdLotInfo.ScreenSpread.ActiveSheet.Cells[1, 1].Text);

                for (int i = 0; i < spdLossList.Sheets[0].RowCount; i++)
                {
                    list_item = in_node.AddNode("UNIT1");
                    list_item.AddString("CODE", MPCF.Trim(spdLossList.Sheets[0].Cells[i, (int)LOSS_COL.LOSS_CODE].Value));
                    list_item.AddString("CODE_DESC", MPCF.Trim(spdLossList.Sheets[0].Cells[i, (int)LOSS_COL.LOSS_DESC].Value));
                    list_item.AddDouble("QTY", MPCF.Trim(spdLossList.Sheets[0].Cells[i, (int)LOSS_COL.LOSS_QTY].Value));

                    d_sum = d_sum + MPCF.ToDbl(spdLossList.Sheets[0].Cells[i, (int)LOSS_COL.LOSS_QTY].Value) ;
                }

                in_node.AddDouble("OUT_QTY_1", MPCF.ToDbl(spdLotInfo.ScreenSpread.ActiveSheet.Cells[3,1].Text) - MPCF.ToDbl(d_sum));

                if (MPCF.CallService("CUS", "CWIP_Tran_Defect_Register", in_node, ref out_node) == false)
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

        private bool ViewLotInfo(string sLotID)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LOT_IN");
                TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", sLotID);

                if (MPCF.CallService("TIV", "TIV_View_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }
                //spdLotInfo.InitFlexibleScreen();
                //spdLotInfo.ScreenSpread.Tag = "Change Cell";

                //if (spdLotInfo.LoadDesign("INV_LOT_INFO") == false)
                //    return false;
                if (spdLotInfo.SetDataToScreen(out_node) == false)
                    return false;

                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void SetLotID()
        {
            if (string.IsNullOrEmpty(MPGV.gsCurrentLot_ID) == false)
            {
                txtLotID.Text = MPGV.gsCurrentLot_ID;

                if (ViewLotInfo(txtLotID.Text) == false)
                {
                    MPCF.SetFocus(txtLotID);
                    return;
                }
            }
        }

        #endregion

        #region [Event Definition]

        private void frmCUSTranLossLot_Load(object sender, EventArgs e)
        {
            spdLotInfo.InitFlexibleScreen();
            spdLotInfo.ScreenSpread.Tag = "Change Cell";

            if (spdLotInfo.LoadDesign("INV_LOT_INFO") == false)
                return;

            MPCF.ConvertCaption(this);
            MPCF.ClearList(spdLossList);

            cdvOper.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvOper.Tag"));
            cdvOper.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvOper.Text"));

            if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
            {
                txtLotID.Text = MPGV.gsCurrentLot_ID;
				cdvOper.Text = MPGV.gsCurrentOperID;

                if (ViewLotInfo(txtLotID.Text) == false)
                {
                    MPCF.SetFocus(txtLotID);
                    return;
                }
            }
        }

        private void frmCUSTranLossLot_Activated(object sender, EventArgs e)
        {
            SetLotID();
        }

        private void frmCUSTranLossLot_Shown(object sender, EventArgs e)
        {
            // 최초 1회 실행
            if (bIsShown == false)
            {
                // Lot ID Focus
                MPCF.SetFocus(txtLotID);

                bIsShown = true;
            }
        }

        private void frmCUSTranLossLot_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvOper.Tag", MPCF.Trim(cdvOper.Tag));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvOper.Text", MPCF.Trim(cdvOper.Text));
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
            }
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER && MPCF.Trim(txtLotID.Text) != "")
                {
                    txtLotID.Text = MPCF.ToUpper(txtLotID.Text); // 일괄 대문자

                    if (ViewLotInfo(txtLotID.Text) == false)
                    {
                        MPCF.SetFocus(txtLotID);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (txtLotID.Text == "")
            {
                MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, false);
                txtLotID.Focus();
                return;
            }

            if(spdLossList.ActiveSheet.RowCount == 0)
            {
                MPCF.ShowErrorMessage("불량 내역을 추가 후 진행바랍니다.");
                return;
            }

            if (Tran_Loss_Lot(txtLotID.Text) == false)
            {
                MPCF.SetFocus(txtLotID);
                return;
            }

            MPCF.ClearList(spdLossList);

            if (ViewLotInfo(txtLotID.Text) == true)
            {
                txtLotID.Text = "";
                MPCF.SetFocus(txtLotID);
            }
        }

        private void cdvLossCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // 20171030-clearlim-공정별 불량 의뢰 적용
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TABLE_NAME_01";
                dvcArgu[1].sCondition_Value = "C@LOSS_REQ_OPER";

                dvcArgu[2].sCondtion_ID = "$OPER";
                dvcArgu[2].sCondition_Value = cdvOper.Tag;

                dvcArgu[3].sCondtion_ID = "$TABLE_NAME_02";
                dvcArgu[3].sCondition_Value = "C@LOSS_REQUEST";

                // CodeView Column Header Setup
                string[] header = new string[] { "Code", "Code Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvLossCode.Text = cdvLossCode.Show(cdvLossCode, "Code Desc", "VIEW_LOSS_REQUEST_OPER", dvcArgu, display, header, "DATA_1", -1);

                if (MPCF.Trim(cdvLossCode.Text) != "")
                {
                    if (cdvLossCode.returnDatas != null && cdvLossCode.returnDatas.Count > 0)
                    {
                        cdvLossCode.Tag = cdvLossCode.returnDatas[0];
                        cdvLossCode.Text = cdvLossCode.returnDatas[0];
                    }
                }
                else
                {
                    cdvLossCode.Tag = string.Empty;
                    cdvLossCode.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (AddRow() == true)
            {
                cdvLossCode.Text = "";
                txtLossQty.Value = "0";
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // 데이터가 없는 경우 종료
                if (spdLossList.ActiveSheet.Rows.Count < 1)
                {
                    return;
                }

                spdLossList.Sheets[0].Rows[spdLossList.ActiveSheet.ActiveRowIndex].Remove();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnCellBatch_Click(object sender, EventArgs e)
        {
            try
            {
                //셀배치작업 화면
                BICF.OpenMenu("SOI3004");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            } 
        }

        private void btnRawInstall_Click(object sender, EventArgs e)
        {
            try
            {
                //자재장착관리 화면
                BICF.OpenMenu("SOI3003");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            } 

        }

        private void cdvOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[1];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                string[] header = new string[] { "Code", "Code Desc" };
                string[] display = new string[] { "OPER", "OPER_DESC" };

                cdvOper.Text = cdvOper.Show(cdvOper, "Code Desc", "VIEW_OPER_LIST", dvcArgu, display, header, "OPER", -1);

                if (cdvOper.returnDatas != null && cdvOper.returnDatas.Count > 0)
                {
                    cdvOper.Tag = cdvOper.returnDatas[0];
                    cdvOper.Text = cdvOper.returnDatas[0];
                }
                else
                {
                    cdvOper.Tag = string.Empty;
                    cdvOper.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

    }
}
