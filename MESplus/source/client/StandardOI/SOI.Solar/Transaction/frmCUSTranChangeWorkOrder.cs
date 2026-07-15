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
using Infragistics.Win.UltraWinGrid;
using System.IO;
using SOI.DNM;

namespace SOI.Solar
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCUSTranChangeWorkOrder : SOIBaseForm03
    {
        #region " Constant Definition "

        public enum SOURCE_LIST
        {
            ORDER_ID = 0,
            ORDER_DESC,
            MAT_ID
        }

        public enum ORDER_LIST
        {
            NO = 0,
            WORK_DATE,
            ORDER_ID,
            ORDER_DESC,
            MAT_ID,
            MAT_VER,
            SHIFT,
            MAT_MODEL,
            ORD_QTY,
            START_QTY,
            PROC_QTY,
            REPAIR_QTY,
            LOT_TYPE,
            OWNER_CODE,
            CREATE_CODE,
            LOT_PRIORITY,
            ORG_DUE_TIME,
            ORD_STATUS_FLAG,
            PLAN_START_TIME,
            PLAN_END_TIME,
            CREATE_USER_ID,
            CREATE_TIME,
            UPDATE_USER_ID,
            UPDATE_TIME

            //OPER,
            //WORK_CENTER,
            //FINAL_ORDER_ID,
            //FINAL_MAT_ID,
            //FINAL_MAT_VER,
            //PBA_ORDER_ID,
            //PBA_MAT_ID,
            //PBA_MAT_VER,
            //CUST_MAT_ID,
            //ORDER_TYPE,
            //SCRAP_QTY,
            //REPAIR_REQ_QTY,
            //REPAIR_SCRAP_QTY,
            //NO_REPAIR_QTY,
            //PRINT_QTY,
            //INF_QTY,
            //BOX_PRINT_QTY,
        }

        public enum LOT_LIST
        {
            NO = 0,
            CHK_FLAG,
            LOT_ID,
            LOT_DESC,
            MAT_ID,
            OPER,
            OPER_DESC,
            QTY_1,
            LOT_TYPE,
            LOT_STATUS,
            ORDER_ID,
            CREATE_TIME,
        }

        #endregion

        #region Property

        // (Required) 
        private bool bIsShown = false;

        private enum COLS_SCREEN_LIST
        {
            SCREEN_ID = 0,
            SCREEN_DESCRIPTION
        }

        #endregion

        #region " Variable Definition "

        bool b_load_flag;
 
        #endregion

        #region Constructor

        public frmCUSTranChangeWorkOrder()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler
              

        /// <summary>
        /// Form Load
        /// Caption Convert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCUSTranChangeWorkOrder_Load(object sender, EventArgs e)
        {
            ClearData('1');

            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
        }

        private void frmCUSTranChangeWorkOrder_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                dtpFrom.Value = DateTime.Today.AddDays(-7);
                dtpTo.Value = DateTime.Today;

                b_load_flag = true;
            }
        }

        /// <summary>
        /// Form Shown (Load --> Activate --> Shown)
        /// Focus control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCUSTranChangeWorkOrder_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                //ViewScreenList(string.Empty);
                ViewSourceOrderList();
                ViewTargetOrderList();

                // (Required) 
                bIsShown = true;
            }
        }

        

        /// <summary>
        /// Find Screen ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFindScreenID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //if (ViewScreenList(txtFindScreenID.Text) == false)
                    //{
                    //    return;
                    //}
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Find Screen ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ViewScreenList(txtFindScreenID.Text) == false)
                //{
                //    return;
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Refresh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ViewScreenList(string.Empty) == false)
                //{
                //    return;
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Print Spread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                // Label Print 합니다.
                //MPCF.PrintFlexibleScreen(this, base.printOption, udcScreen, true);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        
        private void ClearData(char ProcStep)
        {
            try
            {
                if (ProcStep == '1')
                {
                    MPCF.FieldClear(cdvSourceOrderID);
                    MPCF.FieldClear(cdvTargetOrderID);
                    MPCF.ClearList(spdSourceOrder);
                    MPCF.ClearList(spdTargetOrder);
                    MPCF.ClearList(spdSourceLot);
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }


        private bool ViewSourceOrderList()
        {
            int i_cond_cnt;
            string sViewID;
            DataTable dt = new DataTable();

            MPCF.ClearList(spdSourceOrder);
            spdSourceOrder.ActiveSheet.RowCount = 0;

            try
            {
                i_cond_cnt = 6;
                sViewID = "CUS3001-001";

                TPDR.DirectViewCond[] a = new TPDR.DirectViewCond[i_cond_cnt];

                a[0].sCondtion_ID = "$FACTORY";
                a[0].sCondition_Value = MPGV.gsFactory;

                a[1].sCondtion_ID = "$FROM_DATE";
                a[1].sCondition_Value = MPCF.ToStandardTime(dtpFrom.GetValueAsDateTime(), MPGC.MP_CONVERT_DATE_FORMAT);

                a[2].sCondtion_ID = "$TO_DATE";
                a[2].sCondition_Value = MPCF.ToStandardTime(dtpTo.GetValueAsDateTime(), MPGC.MP_CONVERT_DATE_FORMAT);

                a[3].sCondtion_ID = "$MAT_ID";
                a[3].sCondition_Value = MPCF.Trim(cdvMaterial.Text);

                a[4].sCondtion_ID = "$ORDER_ID";
                a[4].sCondition_Value = MPCF.Trim(cdvSourceOrderID.Text);

                a[5].sCondtion_ID = "$SHIFT";
                if (MPCF.Trim(cdvShift.Text) == "ALL")
                    a[5].sCondition_Value = "";
                else
                    a[5].sCondition_Value = MPCF.Trim(cdvShift.Text);

                if (TPDR.DirectViewOne(spdSourceOrder, sViewID, ref dt, false, false, a, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                MPCF.FitColumnHeader(spdSourceOrder);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewTargetOrderList()
        {
            int i_cond_cnt;
            string sViewID;
            DataTable dt = new DataTable();

            MPCF.ClearList(spdTargetOrder);
            spdTargetOrder.ActiveSheet.RowCount = 0;

            try
            {
                i_cond_cnt = 6;
                sViewID = "CUS3001-001";

                TPDR.DirectViewCond[] a = new TPDR.DirectViewCond[i_cond_cnt];

                a[0].sCondtion_ID = "$FACTORY";
                a[0].sCondition_Value = MPGV.gsFactory;

                a[1].sCondtion_ID = "$FROM_DATE";
                a[1].sCondition_Value = MPCF.ToStandardTime(dtpFrom.GetValueAsDateTime(), MPGC.MP_CONVERT_DATE_FORMAT);

                a[2].sCondtion_ID = "$TO_DATE";
                a[2].sCondition_Value = MPCF.ToStandardTime(dtpTo.GetValueAsDateTime(), MPGC.MP_CONVERT_DATE_FORMAT);

                a[3].sCondtion_ID = "$MAT_ID";
                a[3].sCondition_Value = MPCF.Trim(cdvMaterial.Text);

                a[4].sCondtion_ID = "$ORDER_ID";
                a[4].sCondition_Value = MPCF.Trim(cdvTargetOrderID.Text);

                a[5].sCondtion_ID = "$SHIFT";
                if (MPCF.Trim(cdvShift.Text) == "ALL")
                    a[5].sCondition_Value = "";
                else
                    a[5].sCondition_Value = MPCF.Trim(cdvShift.Text);

                if (TPDR.DirectViewOne(spdTargetOrder, sViewID, ref dt, false, false, a, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                MPCF.FitColumnHeader(spdTargetOrder);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private string MakeDate(string sWorkDate)
        {
            return sWorkDate.Substring(0, 4) + "/" + sWorkDate.Substring(4, 2) + "/" + sWorkDate.Substring(6, 2);
        }

        private bool ViewSourceLotList()
        {
            int iRow;
            int i_cond_cnt;
            string sViewID;
            DataTable dt = new DataTable();
            string sOrderID;

            MPCF.ClearList(spdSourceLot);
            spdSourceLot.ActiveSheet.RowCount = 0;


            iRow = spdSourceOrder.ActiveSheet.ActiveRowIndex;
            if (iRow < 0) return false;

            sOrderID = MPCF.Trim(spdSourceOrder.ActiveSheet.Cells[iRow, (int)ORDER_LIST.ORDER_ID].Value);
            if (sOrderID == "") return false;


            try
            {
                i_cond_cnt = 3;
                sViewID = "CUS3003-001";

                TPDR.DirectViewCond[] arr = new TPDR.DirectViewCond[i_cond_cnt];

                arr[0].sCondtion_ID = "$FACTORY";
                arr[0].sCondition_Value = MPGV.gsFactory;

                arr[1].sCondtion_ID = "$LOT_CMF_3";
                arr[1].sCondition_Value = sOrderID;

                arr[2].sCondtion_ID = "$OPER";
                arr[2].sCondition_Value = MPCF.Trim(cdvSourceOper.Text);

                if (TPDR.DirectViewOne(spdSourceLot, sViewID, ref dt, false, false, arr, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                // Set 1st column as checkbox
                if (dt.Rows.Count > 0)
                {
                    FarPoint.Win.Spread.CellType.CheckBoxCellType ckbxcell = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                    spdSourceLot.Sheets[0].Columns[1].CellType = ckbxcell;
                    spdSourceLot.Sheets[0].Columns[1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    spdSourceLot.Sheets[0].Columns[1].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                }

                MPCF.FitColumnHeader(spdSourceLot);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewTargetLotList()
        {
            int iRow;
            int i_cond_cnt;
            string sViewID;
            DataTable dt = new DataTable();
            string sOrderID;

            MPCF.ClearList(spdTargetLot);
            spdTargetLot.ActiveSheet.RowCount = 0;


            iRow = spdTargetOrder.ActiveSheet.ActiveRowIndex;
            if (iRow < 0) return false;

            sOrderID = MPCF.Trim(spdTargetOrder.ActiveSheet.Cells[iRow, (int)ORDER_LIST.ORDER_ID].Value);
            if (sOrderID == "") return false;


            try
            {
                i_cond_cnt = 3;
                sViewID = "CUS3003-001";

                TPDR.DirectViewCond[] arr = new TPDR.DirectViewCond[i_cond_cnt];

                arr[0].sCondtion_ID = "$FACTORY";
                arr[0].sCondition_Value = MPGV.gsFactory;

                arr[1].sCondtion_ID = "$LOT_CMF_3";
                arr[1].sCondition_Value = sOrderID;

                arr[2].sCondtion_ID = "$OPER";
                arr[2].sCondition_Value = MPCF.Trim(cdvTargetOper.Text);

                if (TPDR.DirectViewOne(spdTargetLot, sViewID, ref dt, false, false, arr, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                // Set 1st column as checkbox
                if (dt.Rows.Count > 0)
                {
                    FarPoint.Win.Spread.CellType.CheckBoxCellType ckbxcell = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                    spdTargetLot.Sheets[0].Columns[1].CellType = ckbxcell;
                    spdTargetLot.Sheets[0].Columns[1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    spdTargetLot.Sheets[0].Columns[1].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                }

                MPCF.FitColumnHeader(spdTargetLot);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool CheckCondition(string FuncName)
        {

            switch (MPCF.Trim(FuncName))
            {
                case "VIEW":
                    if (dtpFrom.GetValueAsDateTime() > dtpTo.GetValueAsDateTime())
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(82));
                        dtpFrom.Value = DateTime.Today.AddMonths(-1);
                        return false;
                    }
                    break;
                case "AdaptOrderLotToTarget":
                    {
                        string sSourceOrderID = string.Empty;
                        string sTargetOrderID = string.Empty;
                        int iRow;

                        iRow = spdSourceOrder.ActiveSheet.ActiveRowIndex;
                        if (iRow >= 0)
                            sSourceOrderID = MPCF.Trim(spdSourceOrder.ActiveSheet.Cells[iRow, (int)ORDER_LIST.ORDER_ID].Value);

                        if (sSourceOrderID == "")
                        {
                            MPCF.ShowMsgBox("선택된 Source Order가 없습니다.");
                            return false;
                        }

                        iRow = spdTargetOrder.ActiveSheet.ActiveRowIndex;
                        if (iRow >= 0)
                            sTargetOrderID = MPCF.Trim(spdTargetOrder.ActiveSheet.Cells[iRow, (int)ORDER_LIST.ORDER_ID].Value);

                        if (sTargetOrderID == "")
                        {
                            MPCF.ShowMsgBox("선택된 Target Order가 없습니다.");
                            return false;
                        }

                        if (sSourceOrderID == sTargetOrderID)
                        {
                            MPCF.ShowMsgBox("같은 Work Order로 변경할 수 없습니다.");
                            return false;
                        }
                    }



                    // comment text 가 empty인지 확인
                    //if (txtSourceComment.Text == "")
                    //{
                    //    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    //    txtSourceComment.Focus();
                    //    return false;
                    //}
                    break;
                case "AdaptOrderLotToSource":
                    {
                        string sSourceOrderID = string.Empty;
                        string sTargetOrderID = string.Empty;
                        int iRow;

                        iRow = spdSourceOrder.ActiveSheet.ActiveRowIndex;
                        if (iRow >= 0)
                            sSourceOrderID = MPCF.Trim(spdSourceOrder.ActiveSheet.Cells[iRow, (int)ORDER_LIST.ORDER_ID].Value);

                        if (sSourceOrderID == "")
                        {
                            MPCF.ShowMsgBox("선택된 Source Order가 없습니다.");
                            return false;
                        }

                        iRow = spdTargetOrder.ActiveSheet.ActiveRowIndex;
                        if (iRow >= 0)
                            sTargetOrderID = MPCF.Trim(spdTargetOrder.ActiveSheet.Cells[iRow, (int)ORDER_LIST.ORDER_ID].Value);

                        if (sTargetOrderID == "")
                        {
                            MPCF.ShowMsgBox("선택된 Target Order가 없습니다.");
                            return false;
                        }

                        if (sSourceOrderID == sTargetOrderID)
                        {
                            MPCF.ShowMsgBox("같은 Work Order로 변경할 수 없습니다.");
                            return false;
                        }
                    }

                    // comment text 가 empty인지 확인
                    //if (txtTargetComment.Text == "")
                    //{
                    //    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    //    txtSourceComment.Focus();
                    //    return false;
                    //}
                    break;
            }

            return true;

        }

        private bool CalcOrderQty(bool bToTarget, int iAdaptCount, int iRepairCount)
        {
            string sOrderID;
            int iStartQty = 0;
            int iProcQty = 0;
            int iRepairQty = 0;
            int iRow = 0;

            FarPoint.Win.Spread.FpSpread spdSrcOrd = null;
            FarPoint.Win.Spread.FpSpread spdTgtOrd = null;
            FarPoint.Win.Spread.FpSpread spdSrcLot = null;


            if (bToTarget == true)
            {
                spdSrcOrd = spdSourceOrder;
                spdTgtOrd = spdTargetOrder;
                spdSrcLot = spdSourceLot;
            }
            else
            {
                spdSrcOrd = spdTargetOrder;
                spdTgtOrd = spdSourceOrder;
                spdSrcLot = spdTargetLot;
            }
            // Repair 상태   R : Request, C : Complete
            //sLotCmf13 = MPCF.Trim(spdSrcLot.ActiveSheet.Cells[iLotIndex, (int)LOT_LIST.LOT_CMF_13].Value);

            // source order 감소 처리 (start qty, proc qty)
            iRow = spdSrcOrd.ActiveSheet.ActiveRowIndex;
            if (iRow < 0) return false;

            sOrderID = MPCF.Trim(spdSrcOrd.ActiveSheet.Cells[iRow, (int)ORDER_LIST.ORDER_ID].Value);
            if (sOrderID == "") return false;

            iStartQty = MPCF.ToInt(spdSrcOrd.ActiveSheet.Cells[iRow, (int)ORDER_LIST.START_QTY].Value);
            iProcQty = MPCF.ToInt(spdSrcOrd.ActiveSheet.Cells[iRow, (int)ORDER_LIST.PROC_QTY].Value);
            iRepairQty = MPCF.ToInt(spdSrcOrd.ActiveSheet.Cells[iRow, (int)ORDER_LIST.REPAIR_QTY].Value);

            iStartQty -= iAdaptCount;
            iProcQty -= iAdaptCount;
            iRepairQty -= iRepairCount;

            if (UpdateWorkOrder(sOrderID, iStartQty, iProcQty, iRepairQty) == false)
            {
                return false;
            }


            // target order 증가 처리 (start qty, proc qty)
            iRow = spdTgtOrd.ActiveSheet.ActiveRowIndex;
            if (iRow < 0) return false;

            sOrderID = MPCF.Trim(spdTgtOrd.ActiveSheet.Cells[iRow, (int)ORDER_LIST.ORDER_ID].Value);
            if (sOrderID == "") return false;

            iStartQty = MPCF.ToInt(spdTgtOrd.ActiveSheet.Cells[iRow, (int)ORDER_LIST.START_QTY].Value);
            iProcQty = MPCF.ToInt(spdTgtOrd.ActiveSheet.Cells[iRow, (int)ORDER_LIST.PROC_QTY].Value);
            iRepairQty = MPCF.ToInt(spdTgtOrd.ActiveSheet.Cells[iRow, (int)ORDER_LIST.REPAIR_QTY].Value);

            iStartQty += iAdaptCount;
            iProcQty += iAdaptCount;
            iRepairQty += iRepairCount;

            if (UpdateWorkOrder(sOrderID, iStartQty, iProcQty, iRepairQty) == false)
            {
                return false;
            }

            return true;
        }

        private bool UpdateWorkOrder(string sOrderID, int iStartQty, int iProcQty, int iRepairQty)
        {
            TRSNode in_node = new TRSNode("CUS_UPDATE_ORDER_IN");
            TRSNode out_node = new TRSNode("CUS_UPDATE_ORDER_OUT");

            if (iStartQty < 0) iStartQty = 0;
            if (iProcQty < 0) iProcQty = 0;
            if (iRepairQty < 0) iRepairQty = 0;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_UPDATE;

                in_node.AddString("ORDER_ID", MPCF.Trim(sOrderID));
                in_node.AddInt("START_QTY", iStartQty);
                in_node.AddInt("PROC_QTY", iProcQty);
                if (iStartQty < 1)
                {
                    in_node.AddChar("ORD_STATUS_FLAG", ' ');
                }
                in_node.AddInt("REPAIR_QTY", iRepairQty);

                if (MPCF.CallService("CUS", "CUS_Change_Order", in_node, ref out_node) == false)
                {
                    return false;
                }

                //MPCF.ShowSuccessMsg(out_node);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool AdaptOrderLotToTarget()
        {
            int i = 0;
            int iAdaptLotCount = 0;
            int iRepairLotCount = 0;
            string sLotID;
            string sLotCmf13;

            TRSNode in_node = new TRSNode("ADAPT_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            string sOrderID;
            string sMatID;
            int iRow;

            iRow = spdTargetOrder.ActiveSheet.ActiveRowIndex;
            if (iRow < 0) return false;

            sOrderID = MPCF.Trim(spdTargetOrder.ActiveSheet.Cells[iRow, (int)ORDER_LIST.ORDER_ID].Value);
            if (sOrderID == "") return false;

            // TO_MAT_ID로 넣어주자
            sMatID = MPCF.Trim(spdTargetOrder.ActiveSheet.Cells[iRow, (int)ORDER_LIST.MAT_ID].Value);

            // Adapt Lot
            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", string.Empty);
            in_node.AddString("TO_MAT_ID", sMatID);
            in_node.AddString("LOT_CMF_3", MPCF.Trim(sOrderID));
            in_node.AddString("COMMENT", MPCF.Trim(txtSourceComment.Text));

            try
            {
                for (i = 0; i < spdSourceLot.ActiveSheet.RowCount; i++)
                {
                    if (spdSourceLot.ActiveSheet.GetValue(i, (int)LOT_LIST.CHK_FLAG) != null)
                    {
                        if (Convert.ToBoolean(spdSourceLot.ActiveSheet.GetValue(i, (int)LOT_LIST.CHK_FLAG)) == true)
                        {
                            sLotID = MPCF.Trim(spdSourceLot.ActiveSheet.GetValue(i, (int)LOT_LIST.LOT_ID));

                            // Adapt Lot
                            in_node.SetString("LOT_ID", sLotID);

                            if (MPCF.CallService("WIP", "WIP_Adapt_Lot", in_node, ref out_node) == false)
                            {
                                return false;
                            }

                            // Repair 상태   R : Request, C : Complete
                            sLotCmf13 = MPCF.Trim(spdSourceLot.ActiveSheet.Cells[i, (int)LOT_LIST.ORDER_ID].Value);

                            iAdaptLotCount++;
                            if (sLotCmf13 == "R") iRepairLotCount++;

                        }
                    }
                }

                if (CalcOrderQty(true, iAdaptLotCount, iRepairLotCount) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        private bool AdaptOrderLotToSource()
        {
            int i = 0;
            int iAdaptLotCount = 0;
            int iRepairLotCount = 0;
            string sLotID;
            string sLotCmf13;

            TRSNode in_node = new TRSNode("ADAPT_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            string sOrderID;
            string sMatID;
            int iRow;

            iRow = spdSourceOrder.ActiveSheet.ActiveRowIndex;
            if (iRow < 0) return false;

            sOrderID = MPCF.Trim(spdSourceOrder.ActiveSheet.Cells[iRow, (int)ORDER_LIST.ORDER_ID].Value);
            if (sOrderID == "") return false;

            // TO_MAT_ID로 넣어주자
            sMatID = MPCF.Trim(spdSourceOrder.ActiveSheet.Cells[iRow, (int)ORDER_LIST.MAT_ID].Value);

            // Adapt Lot
            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", string.Empty);
            in_node.AddString("TO_MAT_ID", sMatID);
            in_node.AddString("LOT_CMF_3", sOrderID);
            in_node.AddString("COMMENT", MPCF.Trim(txtSourceComment.Text));

            try
            {
                for (i = 0; i < spdTargetLot.ActiveSheet.RowCount; i++)
                {
                    if (spdTargetLot.ActiveSheet.GetValue(i, (int)LOT_LIST.CHK_FLAG) != null)
                    {
                        if (Convert.ToBoolean(spdTargetLot.ActiveSheet.GetValue(i, (int)LOT_LIST.CHK_FLAG)) == true)
                        {
                            sLotID = MPCF.Trim(spdTargetLot.ActiveSheet.GetValue(i, (int)LOT_LIST.LOT_ID));

                            // Adapt Lot
                            in_node.SetString("LOT_ID", sLotID);

                            if (MPCF.CallService("WIP", "WIP_Adapt_Lot", in_node, ref out_node) == false)
                            {
                                return false;
                            }

                            // Repair 상태   R : Request, C : Complete
                            sLotCmf13 = MPCF.Trim(spdTargetLot.ActiveSheet.Cells[i, (int)LOT_LIST.ORDER_ID].Value);

                            iAdaptLotCount++;
                            if (sLotCmf13 == "R") iRepairLotCount++;
                        }
                    }
                }

                if (CalcOrderQty(false, iAdaptLotCount, iRepairLotCount) == false)
                {
                    return false;
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

        

        private void cdvTargetOrderID_CodeViewButtonClick(object sender, EventArgs e)
        {

        }

        private void spdSourceOrder_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            cdvSourceOper.Text = "";
            ViewSourceLotList();
        }

        private void spdTargetOrder_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            try
            {
                string sOrderID;
                int iRow = spdTargetOrder.ActiveSheet.ActiveRowIndex;
                if (iRow < 0) return;

                sOrderID = MPCF.Trim(spdTargetOrder.ActiveSheet.Cells[iRow, 0].Value);
                if (sOrderID == "") return;

                cdvTargetOrderID.Text = sOrderID;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvMaterial_Click(object sender, EventArgs e)
        {

            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];

            try
            {

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$MAT_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(cdvMaterial.Text);

                dvcArgu[2].sCondtion_ID = "$MAT_TYPE";
                dvcArgu[2].sCondition_Value = CSGC.MP_MAT_TYPE_FG;

                 // CodeView Column Header Setup
                string[] header = new string[] { "Material ID", "Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "MAT_ID", "MAT_DESC" };

                // Show by RPTServer
                cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "Material", "COM0001-001", dvcArgu, display, header, "MAT_ID", -1);

                if (cdvMaterial.returnDatas != null && cdvMaterial.returnDatas.Count > 0)
                {
                    cdvMaterial.Tag = cdvMaterial.returnDatas[0];
                    cdvMaterial.Text = cdvMaterial.returnDatas[0];
                }

                //cdvMaterial.InsertEmptyRow(0, 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (CheckCondition("VIEW") == true)
            {
                cdvSourceOper.Text = "";
                MPCF.ClearList(spdSourceLot);
                cdvTargetOper.Text = "";
                MPCF.ClearList(spdTargetLot);

                ViewSourceOrderList();
                ViewTargetOrderList();
            }
        }

        private void cdvSourceOrderID_Click(object sender, EventArgs e)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[6];

            try
            {
                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$ORDER_ID";
                dvcArgu[1].sCondition_Value = ""; // MPCF.Trim(cdvSourceOrderID.Text);

                dvcArgu[2].sCondtion_ID = "$FROM_DATE";
                dvcArgu[2].sCondition_Value = MPCF.ToStandardTime(dtpFrom.GetValueAsDateTime(), MPGC.MP_CONVERT_DATE_FORMAT);

                dvcArgu[3].sCondtion_ID = "$TO_DATE";
                dvcArgu[3].sCondition_Value = MPCF.ToStandardTime(dtpTo.GetValueAsDateTime(), MPGC.MP_CONVERT_DATE_FORMAT);

                dvcArgu[4].sCondtion_ID = "$MAT_ID";
                dvcArgu[4].sCondition_Value = MPCF.Trim(cdvMaterial.Text);

                dvcArgu[5].sCondtion_ID = "$SHIFT";
                if (MPCF.Trim(cdvShift.Text) == "ALL")
                    dvcArgu[5].sCondition_Value = "";
                else
                    dvcArgu[5].sCondition_Value = MPCF.Trim(cdvShift.Text);

                // CodeView Column Header Setup
                string[] header = new string[] { "Order ID", "Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "ORDER_ID", "ORDER_DESC" };

                // Show by RPTServer
                cdvSourceOrderID.Text = cdvSourceOrderID.Show(cdvSourceOrderID, "Order", "COM0001-011", dvcArgu, display, header, "ORDER_ID", -1);

                if (cdvSourceOrderID.returnDatas != null && cdvSourceOrderID.returnDatas.Count > 0)
                {
                    cdvSourceOrderID.Tag = cdvSourceOrderID.returnDatas[0];
                    cdvSourceOrderID.Text = cdvSourceOrderID.returnDatas[0];
                }

                //cdvSourceOrderID.InsertEmptyRow(0, 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvTargetOrderID_Click(object sender, EventArgs e)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[6];

            try
            {
                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$ORDER_ID";
                dvcArgu[1].sCondition_Value = ""; // MPCF.Trim(cdvTargetOrderID.Text);

                dvcArgu[2].sCondtion_ID = "$FROM_DATE";
                dvcArgu[2].sCondition_Value = MPCF.ToStandardTime(dtpFrom.GetValueAsDateTime(), MPGC.MP_CONVERT_DATE_FORMAT);

                dvcArgu[3].sCondtion_ID = "$TO_DATE";
                dvcArgu[3].sCondition_Value = MPCF.ToStandardTime(dtpTo.GetValueAsDateTime(), MPGC.MP_CONVERT_DATE_FORMAT);

                dvcArgu[4].sCondtion_ID = "$MAT_ID";
                dvcArgu[4].sCondition_Value = MPCF.Trim(cdvMaterial.Text);

                dvcArgu[5].sCondtion_ID = "$SHIFT";
                if (MPCF.Trim(cdvShift.Text) == "ALL")
                    dvcArgu[5].sCondition_Value = "";
                else
                    dvcArgu[5].sCondition_Value = MPCF.Trim(cdvShift.Text);

                // CodeView Column Header Setup
                string[] header = new string[] { "Order ID", "Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "ORDER_ID", "ORDER_DESC" };

                // Show by RPTServer
                cdvTargetOrderID.Text = cdvTargetOrderID.Show(cdvTargetOrderID, "Order", "COM0001-011", dvcArgu, display, header, "ORDER_ID", -1);

                if (cdvTargetOrderID.returnDatas != null && cdvTargetOrderID.returnDatas.Count > 0)
                {
                    cdvTargetOrderID.Tag = cdvTargetOrderID.returnDatas[0];
                    cdvTargetOrderID.Text = cdvTargetOrderID.returnDatas[0];
                }

                //cdvSourceOrderID.InsertEmptyRow(0, 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvSourceOrderID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cdvSourceOper.Text = "";
                MPCF.ClearList(spdSourceLot);
                ViewSourceOrderList();
            }
        }

        private void cdvTargetOrderID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cdvTargetOper.Text = "";
                MPCF.ClearList(spdTargetLot);
                ViewTargetOrderList();

            }
        }

        private void cdvSourceOper_Click(object sender, EventArgs e)
        {
            int iRow = 0;
            string sOrderID = string.Empty;

            iRow = spdSourceOrder.ActiveSheet.ActiveRowIndex;
            if (iRow < 0) return;

            sOrderID = MPCF.Trim(spdSourceOrder.ActiveSheet.Cells[iRow, (int)ORDER_LIST.ORDER_ID].Value);
            if (sOrderID == "") return;

            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

            try
            {
                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$LOT_CMF_3";
                dvcArgu[1].sCondition_Value = sOrderID;

                // CodeView Column Header Setup
                string[] header = new string[] { "Oper ID", "Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "OPER", "OPER_DESC" };

                // Show by RPTServer
                cdvSourceOper.Text = cdvSourceOper.Show(cdvSourceOper, "Oper", "CUS3001-011", dvcArgu, display, header, "OPER", -1);

                if (cdvSourceOper.returnDatas != null && cdvSourceOper.returnDatas.Count > 0)
                {
                    cdvSourceOper.Tag = cdvSourceOper.returnDatas[0];
                    cdvSourceOper.Text = cdvSourceOper.returnDatas[0];
                }

                //cdvSourceOper.InsertEmptyRow(0, 1);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvSourceOper_ValueChanged(object sender, EventArgs e)
        {
            ViewSourceLotList();
        }

        private void cdvSourceOper_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ViewSourceLotList();
            }
        }

        private void cdvTargetOper_Click(object sender, EventArgs e)
        {
            int iRow = 0;
            string sOrderID = string.Empty;

            iRow = spdTargetOrder.ActiveSheet.ActiveRowIndex;
            if (iRow < 0) return;

            sOrderID = MPCF.Trim(spdTargetOrder.ActiveSheet.Cells[iRow, (int)ORDER_LIST.ORDER_ID].Value);
            if (sOrderID == "") return;

            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

            try
            {
                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$LOT_CMF_3";
                dvcArgu[1].sCondition_Value = sOrderID;

                // CodeView Column Header Setup
                string[] header = new string[] { "Oper ID", "Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "OPER", "OPER_DESC" };

                // Show by RPTServer
                cdvTargetOper.Text = cdvTargetOper.Show(cdvTargetOper, "Oper", "CUS3001-011", dvcArgu, display, header, "OPER", -1);

                if (cdvTargetOper.returnDatas != null && cdvTargetOper.returnDatas.Count > 0)
                {
                    cdvTargetOper.Tag = cdvTargetOper.returnDatas[0];
                    cdvTargetOper.Text = cdvTargetOper.returnDatas[0];
                }

                //cdvTargetOper.InsertEmptyRow(0, 1);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvTargetOper_ValueChanged(object sender, EventArgs e)
        {
            ViewTargetLotList();
        }

        private void cdvTargetOper_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ViewTargetLotList();
            }
        }

        private void cdvMaterial_Click_1(object sender, EventArgs e)
        {

        }

        private void cdvShift_Click(object sender, EventArgs e)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[1];

            try
            {
                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                // CodeView Column Header Setup
                string[] header = new string[] { "Shift", "Shift Start" };

                // CodeView Display Column Setup
                string[] display = new string[] { "SHIFT", "SHIFT_START" };

                // Show by RPTServer
                cdvShift.Text = cdvShift.Show(cdvSourceOper, "Shift", "CUS3003-002", dvcArgu, display, header, "SHIFT", -1);

                if (cdvShift.returnDatas != null && cdvShift.returnDatas.Count > 0)
                {
                    cdvShift.Tag = cdvShift.returnDatas[0];
                    cdvShift.Text = cdvShift.returnDatas[0];
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }

            // CodeView
            //TRSNode in_node = new TRSNode("VIEW_FACTORY_IN");
            //MPCF.SetInMsg(in_node);
            //in_node.ProcStep = '1';
            //string[] header = new string[] { "Resource ID", "Resource Description" };
            //string[] display = new string[] { "RES_ID", "RES_DESC" };
            //cdvResId.Text = cdvResId.Show(cdvResId, "Resource ID", "WIP", "WIP_View_Factory", in_node, "RES_LIST", display, header, "RES_ID");



            //ListViewItem itmX;
            //cdvShift.Init();
            //MPCF.InitListView(cdvShift.GetListView);
            //cdvShift.Columns.Add("Shift", 50, HorizontalAlignment.Left);
            //cdvShift.Columns.Add("Start", 100, HorizontalAlignment.Left);
            //cdvShift.SelectedSubItemIndex = 0;

            //cdvShift.AddEmptyRow(1);
            //itmX = new ListViewItem("ALL", (int)SMALLICON_INDEX.IDX_CODE_DATA);
            //itmX.SubItems.Add("ALL SHIFT");
            //cdvShift.Items.Add(itmX);
            //WIPLIST.ViewFactoryShiftList(cdvShift.GetListView, '1');
        }
    }
}
