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
using SOI.DNM;
using BOI.OIFrx;

namespace BOI.INVCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmINVOutInventoryLot : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private string _sInvReqNo = string.Empty;
        private bool _bShipFlag = false;
        private string _sReason = string.Empty;

        private string _sparaInvReqNo = string.Empty;
        private string _sparaReqDate = string.Empty;     

        private enum REQ_MST_COL
        {
            SEQ = 0,
            INV_REQ_NO,
            REQ_DATE,
            REQ_STATUS_DESC,
            REQ_STATUS_CODE,
            FROM_STORE_DESC,
            FROM_STORE_CODE,
            TO_STORE_DESC,
            TO_STORE_CODE,
            REASON_DESC,
            REASON_CODE
        }

        private enum REQ_DTL_COL
        {
            SEQ = 0,
            MAT_ID,
            MAT_DESC,
            QTY,
            UNIT
        }

        private enum LOT_COL
        {
            LOT_ID = 0,
            MAT_DESC,
            MAT_ID,
            QTY_1,
            INV_UNIT
        }

        #endregion

        #region Constructor

        public frmINVOutInventoryLot()
        {
            InitializeComponent();
        }

        public frmINVOutInventoryLot(string args)
        {
            InitializeComponent();
            if (args.Split(':').Length == 2)
            {
                _sparaInvReqNo = args.Split(':')[0];
                _sparaReqDate = args.Split(':')[1];
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

            MPCF.ClearList(spdReqMstList);
            MPCF.ClearList(spdReqDtlList);
            MPCF.ClearList(spdInvLotList);

            dtpDate.SetValueAsDateTime(DateTime.Now);
            dtpTo.SetValueAsDateTime(DateTime.Now);

            InvisibleColumn();
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

                if (_sparaInvReqNo != string.Empty)
                {
                    View_Req_Mst(_sparaReqDate, _sparaInvReqNo);
                }

                // (Required) 
                bIsShown = true;
            }
        }

        private void dtpDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                MPCF.ClearList(spdReqDtlList);
                MPCF.ClearList(spdInvLotList);
                _bShipFlag = false;
                btnCancel.Enabled = true;

                if (View_Req_Mst(dtpDate.GetValueAsString(8), txtLotId.Text.Trim()) == false)
                {
                    //Nothing
                }

                if (spdReqMstList.Sheets[0].RowCount > 0)
                {
                    _sInvReqNo = spdReqMstList.Sheets[0].Cells[0, (int)REQ_MST_COL.INV_REQ_NO].Value.ToString();
                    _sReason = spdReqMstList.Sheets[0].Cells[0, (int)REQ_MST_COL.REASON_CODE].Value.ToString();

                    if (View_Req_Detail(_sInvReqNo,
                                        MPCF.ToChar(spdReqMstList.Sheets[0].Cells[0, (int)REQ_MST_COL.REQ_STATUS_CODE].Value)) == false)
                    {
                        //Nothing
                    }

                    if (spdReqDtlList.Sheets[0].RowCount > 0)
                    {
                        if (View_Picking_Lot(spdReqDtlList.Sheets[0].Cells[0, (int)REQ_DTL_COL.MAT_ID].Value.ToString(),
                                             MPCF.ToInt(spdReqDtlList.Sheets[0].Cells[0, (int)REQ_DTL_COL.SEQ].Value)) == false)
                        {
                            //Nothing
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdReqMstList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            char cReqStatus;

            try
            {
                _sInvReqNo = spdReqMstList.Sheets[0].Cells[e.Row, (int)REQ_MST_COL.INV_REQ_NO].Value.ToString();
                cReqStatus = MPCF.ToChar(spdReqMstList.Sheets[0].Cells[e.Row, (int)REQ_MST_COL.REQ_STATUS_CODE].Value);

                _sReason = spdReqMstList.Sheets[0].Cells[e.Row, (int)REQ_MST_COL.REASON_CODE].Value.ToString();

                if (View_Req_Detail(_sInvReqNo, cReqStatus) == false)
                {
                    //Nothing
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdReqDtlList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            string sMatId = string.Empty;
            int iInvReqSeq = 0;

            try
            {
                sMatId = spdReqDtlList.Sheets[0].Cells[e.Row, (int)REQ_DTL_COL.MAT_ID].Value.ToString();
                iInvReqSeq = MPCF.ToInt(spdReqDtlList.Sheets[0].Cells[e.Row, (int)REQ_DTL_COL.SEQ].Value);

                if (View_Picking_Lot(sMatId, iInvReqSeq) == false)
                {
                    //Nothing
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("OUT_LOT") == true)
                {
                    if (Out_Lot('1') == true)
                    {
                        btnView.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("CANCEL_LOT") == true)
                {
                    if (Out_Lot('C') == true)
                    {
                        btnView.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void txtLotId_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    btnView.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        private void InvisibleColumn()
        {
            try
            {
                spdReqMstList.Sheets[0].Columns[(int)REQ_MST_COL.REQ_STATUS_CODE].Visible = false;
                spdReqMstList.Sheets[0].Columns[(int)REQ_MST_COL.FROM_STORE_CODE].Visible = false;
                spdReqMstList.Sheets[0].Columns[(int)REQ_MST_COL.TO_STORE_CODE].Visible = false;
                spdReqMstList.Sheets[0].Columns[(int)REQ_MST_COL.REASON_CODE].Visible = false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private bool View_Req_Mst(string reqDate)
        {
            return View_Req_Mst(reqDate, "");
        }

        /// <summary>
        /// View Request Master Data
        /// </summary>
        /// <param name="oDate"></param>
        /// <returns></returns>
        private bool View_Req_Mst(string reqDate, string invReqNo)
        {
            try
            {
                MPCF.ClearList(spdReqMstList);

                if (invReqNo == "")
                {

                    TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];
                    DataTable dt = null;
                    string s_column = "";

                    dvcArgu[0].sCondtion_ID = "FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    dvcArgu[1].sCondtion_ID = "REQ_TYPE";
                    dvcArgu[1].sCondition_Value = BIGC.B_REQ_TYPE_DISPENSE;

                    dvcArgu[2].sCondtion_ID = "REQ_DATE";
                    dvcArgu[2].sCondition_Value = reqDate;

                    dvcArgu[3].sCondtion_ID = "TO_DATE";
                    dvcArgu[3].sCondition_Value = dtpTo.GetValueAsDateTime().ToString("yyyyMMdd");


                    if (TPDR.GetDataOne(s_column, ref dt, "CINV2212-005", dvcArgu, false, false) == false)
                    {
                        if (dt != null)
                            dt.Dispose();

                        GC.Collect();
                        return false;
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        spdReqMstList.Sheets[0].RowCount += 1;
                        spdReqMstList.Sheets[0].Cells[spdReqMstList.Sheets[0].RowCount - 1, (int)REQ_MST_COL.SEQ].Value = dt.Rows[i]["SEQ"].ToString();
                        spdReqMstList.Sheets[0].Cells[spdReqMstList.Sheets[0].RowCount - 1, (int)REQ_MST_COL.INV_REQ_NO].Value = dt.Rows[i]["INV_REQ_NO"].ToString();
                        spdReqMstList.Sheets[0].Cells[spdReqMstList.Sheets[0].RowCount - 1, (int)REQ_MST_COL.REQ_DATE].Value = dt.Rows[i]["REQ_DATE"].ToString();
                        spdReqMstList.Sheets[0].Cells[spdReqMstList.Sheets[0].RowCount - 1, (int)REQ_MST_COL.REQ_STATUS_DESC].Value = dt.Rows[i]["REQ_STATUS_DESC"].ToString();
                        spdReqMstList.Sheets[0].Cells[spdReqMstList.Sheets[0].RowCount - 1, (int)REQ_MST_COL.REQ_STATUS_CODE].Value = dt.Rows[i]["REQ_STATUS_CODE"].ToString();
                        spdReqMstList.Sheets[0].Cells[spdReqMstList.Sheets[0].RowCount - 1, (int)REQ_MST_COL.FROM_STORE_DESC].Value = dt.Rows[i]["FROM_STORE_DESC"].ToString();
                        spdReqMstList.Sheets[0].Cells[spdReqMstList.Sheets[0].RowCount - 1, (int)REQ_MST_COL.FROM_STORE_CODE].Value = dt.Rows[i]["FROM_STORE_CODE"].ToString();
                        spdReqMstList.Sheets[0].Cells[spdReqMstList.Sheets[0].RowCount - 1, (int)REQ_MST_COL.TO_STORE_DESC].Value = dt.Rows[i]["TO_STORE_DESC"].ToString();
                        spdReqMstList.Sheets[0].Cells[spdReqMstList.Sheets[0].RowCount - 1, (int)REQ_MST_COL.TO_STORE_CODE].Value = dt.Rows[i]["TO_STORE_CODE"].ToString();
                        spdReqMstList.Sheets[0].Cells[spdReqMstList.Sheets[0].RowCount - 1, (int)REQ_MST_COL.REASON_DESC].Value = dt.Rows[i]["REASON_DESC"].ToString();
                        spdReqMstList.Sheets[0].Cells[spdReqMstList.Sheets[0].RowCount - 1, (int)REQ_MST_COL.REASON_CODE].Value = dt.Rows[i]["REASON_CODE"].ToString();
                    }
                }
                else
                {

                    TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];
                    DataTable dt = null;
                    string s_column = "";

                    dvcArgu[0].sCondtion_ID = "FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    dvcArgu[1].sCondtion_ID = "REQ_TYPE";
                    dvcArgu[1].sCondition_Value = BIGC.B_REQ_TYPE_DISPENSE;

                    dvcArgu[2].sCondtion_ID = "INV_REQ_NO";
                    dvcArgu[2].sCondition_Value = invReqNo;


                    if (TPDR.GetDataOne(s_column, ref dt, "CINV2212-004", dvcArgu, false, false) == false)
                    {
                        if (dt != null)
                            dt.Dispose();

                        GC.Collect();
                        return false;
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        spdReqMstList.Sheets[0].RowCount += 1;
                        spdReqMstList.Sheets[0].Cells[spdReqMstList.Sheets[0].RowCount - 1, (int)REQ_MST_COL.SEQ].Value = dt.Rows[i]["SEQ"].ToString();
                        spdReqMstList.Sheets[0].Cells[spdReqMstList.Sheets[0].RowCount - 1, (int)REQ_MST_COL.INV_REQ_NO].Value = dt.Rows[i]["INV_REQ_NO"].ToString();
                        spdReqMstList.Sheets[0].Cells[spdReqMstList.Sheets[0].RowCount - 1, (int)REQ_MST_COL.REQ_DATE].Value = dt.Rows[i]["REQ_DATE"].ToString();
                        spdReqMstList.Sheets[0].Cells[spdReqMstList.Sheets[0].RowCount - 1, (int)REQ_MST_COL.REQ_STATUS_DESC].Value = dt.Rows[i]["REQ_STATUS_DESC"].ToString();
                        spdReqMstList.Sheets[0].Cells[spdReqMstList.Sheets[0].RowCount - 1, (int)REQ_MST_COL.REQ_STATUS_CODE].Value = dt.Rows[i]["REQ_STATUS_CODE"].ToString();
                        spdReqMstList.Sheets[0].Cells[spdReqMstList.Sheets[0].RowCount - 1, (int)REQ_MST_COL.FROM_STORE_DESC].Value = dt.Rows[i]["FROM_STORE_DESC"].ToString();
                        spdReqMstList.Sheets[0].Cells[spdReqMstList.Sheets[0].RowCount - 1, (int)REQ_MST_COL.FROM_STORE_CODE].Value = dt.Rows[i]["FROM_STORE_CODE"].ToString();
                        spdReqMstList.Sheets[0].Cells[spdReqMstList.Sheets[0].RowCount - 1, (int)REQ_MST_COL.TO_STORE_DESC].Value = dt.Rows[i]["TO_STORE_DESC"].ToString();
                        spdReqMstList.Sheets[0].Cells[spdReqMstList.Sheets[0].RowCount - 1, (int)REQ_MST_COL.TO_STORE_CODE].Value = dt.Rows[i]["TO_STORE_CODE"].ToString();
                        spdReqMstList.Sheets[0].Cells[spdReqMstList.Sheets[0].RowCount - 1, (int)REQ_MST_COL.REASON_DESC].Value = dt.Rows[i]["REASON_DESC"].ToString();
                        spdReqMstList.Sheets[0].Cells[spdReqMstList.Sheets[0].RowCount - 1, (int)REQ_MST_COL.REASON_CODE].Value = dt.Rows[i]["REASON_CODE"].ToString();
                    }
                }

                MPCF.FitColumnHeader(spdReqMstList);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        /// <summary>
        /// View Request Detail Data
        /// </summary>
        /// <param name="oDate"></param>
        /// <returns></returns>
        private bool View_Req_Detail(string sInvReqNo, char cReqStatus)
        {
            try
            {
                MPCF.ClearList(spdReqDtlList);
                MPCF.ClearList(spdInvLotList);
                _bShipFlag = false;
                btnCancel.Enabled = true;

                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
                DataTable dt = null;
                string s_column = "";

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "INV_REQ_NO";
                dvcArgu[1].sCondition_Value = sInvReqNo;

                if (TPDR.GetDataOne(s_column, ref dt, "CINV2212-002", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spdReqDtlList.Sheets[0].RowCount += 1;
                    spdReqDtlList.Sheets[0].Cells[spdReqDtlList.Sheets[0].RowCount - 1, (int)REQ_DTL_COL.SEQ].Value = dt.Rows[i]["SEQ"].ToString();
                    spdReqDtlList.Sheets[0].Cells[spdReqDtlList.Sheets[0].RowCount - 1, (int)REQ_DTL_COL.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    spdReqDtlList.Sheets[0].Cells[spdReqDtlList.Sheets[0].RowCount - 1, (int)REQ_DTL_COL.MAT_DESC].Value = dt.Rows[i]["MAT_DESC"].ToString();
                    spdReqDtlList.Sheets[0].Cells[spdReqDtlList.Sheets[0].RowCount - 1, (int)REQ_DTL_COL.UNIT].Value = dt.Rows[i]["UNIT_1"].ToString();
                    spdReqDtlList.Sheets[0].Cells[spdReqDtlList.Sheets[0].RowCount - 1, (int)REQ_DTL_COL.QTY].Value = dt.Rows[i]["REQ_QTY_1"].ToString();
                }

                MPCF.FitColumnHeader(spdReqDtlList);

                if (cReqStatus == BIGC.B_DLV_STATUS_CLOSE)
                {
                    _bShipFlag = true; //이미 이동 되면 삭제 X
                    btnCancel.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        /// <summary>
        /// View Picking Lot Data
        /// </summary>
        /// <param name="sInvReqNo"></param>
        /// <param name="sMatId"></param>
        /// <param name="iInvReqSeq"></param>
        /// <returns></returns>
        private bool View_Picking_Lot(string sMatId, int iInvReqSeq)
        {
            try
            {
                MPCF.ClearList(spdInvLotList);

                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];
                DataTable dt = null;
                string s_column = "";

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "MAT_ID";
                dvcArgu[1].sCondition_Value = sMatId;

                dvcArgu[2].sCondtion_ID = "INV_REQ_NO";
                dvcArgu[2].sCondition_Value = _sInvReqNo;

                dvcArgu[3].sCondtion_ID = "INV_REQ_SEQ";
                dvcArgu[3].sCondition_Value = iInvReqSeq.ToString();

                if (TPDR.GetDataOne(s_column, ref dt, "CINV2212-003", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spdInvLotList.Sheets[0].RowCount += 1;
                    spdInvLotList.Sheets[0].Cells[spdInvLotList.Sheets[0].RowCount - 1, (int)LOT_COL.LOT_ID].Value = dt.Rows[i]["LOT_ID"].ToString();
                    spdInvLotList.Sheets[0].Cells[spdInvLotList.Sheets[0].RowCount - 1, (int)LOT_COL.MAT_DESC].Value = dt.Rows[i]["MAT_DESC"].ToString();
                    spdInvLotList.Sheets[0].Cells[spdInvLotList.Sheets[0].RowCount - 1, (int)LOT_COL.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    spdInvLotList.Sheets[0].Cells[spdInvLotList.Sheets[0].RowCount - 1, (int)LOT_COL.INV_UNIT].Value = dt.Rows[i]["INV_UNIT"].ToString();
                    spdInvLotList.Sheets[0].Cells[spdInvLotList.Sheets[0].RowCount - 1, (int)LOT_COL.QTY_1].Value = dt.Rows[i]["QTY_1"].ToString();
                }

                MPCF.FitColumnHeader(spdInvLotList);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "OUT_LOT":
                        //INV_LOT_ID
                        if (MPCF.Trim(_sInvReqNo) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            return false;
                        }

                        //SHIP_FLAG 이동 됬는지 확인
                        if (_bShipFlag == true)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(378), MSG_LEVEL.WARNING, true); //CMN378 ERROR - This inventory request number already shiped.
                            return false;
                        }

                        break;

                    case "CANCEL_LOT":
                        //INV_LOT_ID
                        if (MPCF.Trim(_sInvReqNo) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            return false;
                        }

                        if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, MSG_LEVEL.NONE, "") == System.Windows.Forms.DialogResult.No)
                        {
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

        // Out_Lot()
        //       - Out Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Out_Lot(char ProcStep)
        {
            TRSNode in_node = new TRSNode("OUT_LOT_IN");
            TRSNode out_node = new TRSNode("OUT_LOT_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                //창고
                in_node.AddString("INV_REQ_NO", _sInvReqNo);

                //INV_CMF_1 계정그룹
                in_node.AddString("LOT_CMF_1", BIGC.B_INV_ACC_GRP_MOVE_INSIDE);

                //INV_CMF_2 계정상세유형 
                in_node.AddString("LOT_CMF_2", BIGC.B_INV_ACC_DETAIL_MOVE_OUT);

                //사유그룹
                in_node.AddString("LOT_CMF_7", "");

                //사유
                in_node.AddString("LOT_CMF_8", MPCF.Trim(_sReason));

                if (MPCF.CallService("BINV", "BINV_Tran_Out_Return_Inventory_Lot", in_node, ref out_node) == false)
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

        #endregion

    }
}
