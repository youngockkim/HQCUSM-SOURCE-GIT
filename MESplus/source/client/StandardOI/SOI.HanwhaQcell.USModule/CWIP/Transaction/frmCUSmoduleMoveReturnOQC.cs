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
namespace SOI.HanwhaQcell.USModule
{
    public partial class frmCUSmoduleMoveReturnOQC : SOIBaseForm02
    {

        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCUSmoduleMoveReturnOQC()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        private void frmCUSmoduleMoveReturn_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);

        }

        private void frmCUSmoduleMoveReturn_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                

                // (Required) 
                bIsShown = true;
            }
        }

        private void cdvGrade_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Code View Service
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "@GRADE");
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "GRADE", "GRADE Desc" };
                cdvGrade.Text = cdvGrade.Show(cdvGrade, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "GRADE");

                // Validation
                if (string.IsNullOrEmpty(cdvGrade.Text) == true)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvPower_CodeViewButtonClick(object sender, EventArgs e)
        {

        }

        //private void cdvFromOper_CodeViewButtonClick(object sender, EventArgs e)
        //{
        //    //@SL_MAPPING_PRV
        //    try
        //    {
        //        // Code View Service
        //        // In Node Setup
        //        TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
        //        MPCF.SetInMsg(in_node);
        //        in_node.ProcStep = '1';
        //        in_node.AddString("KEY_2", MPCF.Trim("FR"));

        //        string[] header = new string[] { "Oper", "Description" };
        //        string[] display = new string[] { "OPER", "OPER_DESC" };

        //        cdvFromOper.Text = cdvFromOper.Show(cdvFromOper, "View Port Operation List", "CWIP", "CWIP_view_Port_Operation_list", in_node, "LIST", display, header, "OPER");

        //        if (cdvFromOper.Text == null || cdvFromOper.Text == string.Empty)
        //        {
        //            return;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
        //    }
        //}

        private void cdvToOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Code View Service
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("KEY_2", MPCF.Trim("FR"));

                string[] header = new string[] { "Oper", "Description" };
                string[] display = new string[] { "OPER", "OPER_DESC" };

                cdvToOper.Text = cdvToOper.Show(cdvToOper, "View Port Operation List", "CWIP", "CWIP_View_Port_Operation_List", in_node, "LIST", display, header, "OPER");

                if (cdvToOper.Text == null || cdvToOper.Text == string.Empty)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region function


        private void CheckConfirmModuleList()
        {
            try
            {
                if (MPCF.Trim(txtLotId.Text) == "") return;

                string[] arrModule = txtLotId.Text.Split('\r');

                for (int i = 0; i < arrModule.Length; i++)
                {
                    string str = arrModule[i];
                    arrModule[i] = MPCF.Trim(str);
                }

                string[] modules = arrModule.Distinct().ToArray();

                foreach (var module in modules)
                {
                    if (MPCF.Trim(module) == "") continue;

                    // 동일 모듈 있는지 확인 
                    for (int i = 0; i < spdToList.ActiveSheet.RowCount; i++)
                    {
                        string grdLot = MPCF.Trim(spdToList.ActiveSheet.Cells[i, (int)ToModuleList.lotId].Text);
                        if (grdLot == MPCF.Trim(module))
                        {
                            spdToList.ActiveSheet.Cells[i, (int)ToModuleList.chk].Value = true;
                            break;
                        }
                    }
                }

                int checkedCnt = 0;
                for (int i = 0; i < spdToList.ActiveSheet.RowCount; i++)
                {
                    if (Convert.ToBoolean(spdToList.ActiveSheet.Cells[i, (int)ToModuleList.chk].Value) == true)
                    {
                        checkedCnt++;
                    }
                }

                if (spdToList.ActiveSheet.RowCount > 0) grpConfirm.Text = "Confirm List [Module Count : " + checkedCnt + "/" + MPCF.Trim(spdToList.ActiveSheet.RowCount) + "]";
                else grpConfirm.Text = "Confirm List";

                if (spdToList.ActiveSheet.RowCount == checkedCnt) btnProcess.Enabled = true;
                else btnProcess.Enabled = false;

                if (checkedCnt == spdToList.ActiveSheet.RowCount)
                {
                    btnReject.Enabled = true;
                    btnProcess.Enabled = true;
                }

                txtLotId.Text = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private bool checkeToOperLotId(FarPoint.Win.Spread.SheetView ToSpd, string lotId)
        {
            try
            {
                if (ToSpd.RowCount > 0)
                {
                    for (int i = 0; i <= ToSpd.RowCount - 1; i++)
                    {
                        if (MPCF.Trim(ToSpd.Cells[i, (int)ToModuleList.lotId].Text) == MPCF.Trim(lotId))
                        {
                            ///이미 선택 되어 있는 Module ID 입니다.
                            MPCF.ShowMsgBox(MPCF.GetMessage(572) + " (" + lotId + ")");
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool FromToMove(int index, FarPoint.Win.Spread.SheetView FromSpd, FarPoint.Win.Spread.SheetView ToSpd)
        {
            try
            {
                FarPoint.Win.Spread.SheetView with_2 = spdToList.ActiveSheet;
                with_2.RowCount++;

                with_2.Cells[ToSpd.RowCount - 1, (int)ToModuleList.chk].Value = true;
                with_2.Cells[ToSpd.RowCount - 1, (int)ToModuleList.operCode].Value = FromSpd.Cells[index, (int)FromModuleList.operCode].Value;
                with_2.Cells[ToSpd.RowCount - 1, (int)ToModuleList.operDesc].Value = FromSpd.Cells[index, (int)FromModuleList.operDesc].Value;
                with_2.Cells[ToSpd.RowCount - 1, (int)ToModuleList.lotId].Value = FromSpd.Cells[index, (int)FromModuleList.lotId].Value;
                with_2.Cells[ToSpd.RowCount - 1, (int)ToModuleList.matId].Value = FromSpd.Cells[index, (int)FromModuleList.matId].Value;
                with_2.Cells[ToSpd.RowCount - 1, (int)ToModuleList.matDesc].Value = FromSpd.Cells[index, (int)FromModuleList.matDesc].Value;
                with_2.Cells[ToSpd.RowCount - 1, (int)ToModuleList.port].Value = FromSpd.Cells[index, (int)FromModuleList.port].Value;
                with_2.Cells[ToSpd.RowCount - 1, (int)ToModuleList.grade].Value = FromSpd.Cells[index, (int)FromModuleList.grade].Value;
                with_2.Cells[ToSpd.RowCount - 1, (int)ToModuleList.power].Value = FromSpd.Cells[index, (int)FromModuleList.power].Value;
                with_2.Cells[ToSpd.RowCount - 1, (int)ToModuleList.holdCode].Value = FromSpd.Cells[index, (int)FromModuleList.holdCode].Value;
                with_2.Cells[ToSpd.RowCount - 1, (int)ToModuleList.inTime].Value = FromSpd.Cells[index, (int)FromModuleList.inTime].Value;
                ToSpd.Cells[ToSpd.RowCount - 1, (int)ToModuleList.resTime].Value = FromSpd.Cells[index, (int)FromModuleList.resTime].Value;
                MPCF.FitColumnHeader(spdToList);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private int ScanModuleId(FarPoint.Win.Spread.SheetView FromSpd, string lotId)
        {
            try
            {
                int index = 0;
                FarPoint.Win.Spread.SheetView with_to_oper = spdToList.ActiveSheet;
                for (int i = 0; i <= FromSpd.RowCount - 1; i++)
                {
                    if (MPCF.Trim(FromSpd.Cells[i, (int)FromModuleList.lotId].Text) == MPCF.Trim(lotId))
                    {
                        index = i;
                    }
                }

                return index;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return 0;
            }
        }


        private bool ViewToOperModuleList(String ReqNo)
        {
            try
            {
                txtLotId.Text = "";
                MPCF.ClearList(spdToList);

                TRSNode in_node = new TRSNode("VIEW_TO_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_TO_LIST_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '8';
                in_node.AddString("REQ_NO", MPCF.Trim(ReqNo));
                if (MPCF.CallService("CWIP", "CWIP_View_Port_Operation_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdToList.ActiveSheet.RowCount = 0;

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];

                    spdToList.ActiveSheet.RowCount++;
                    //spdToList.ActiveSheet.Cells[i, (int)ToModuleList.chk].Value = 1;
                    spdToList.ActiveSheet.Cells[i, (int)ToModuleList.reqNo].Value = out_list.GetString("REQ_NO");
                    spdToList.ActiveSheet.Cells[i, (int)ToModuleList.operCode].Value = out_list.GetString("OPER");
                    spdToList.ActiveSheet.Cells[i, (int)ToModuleList.operDesc].Value = out_list.GetString("OPER_DESC");
                    spdToList.ActiveSheet.Cells[i, (int)ToModuleList.lotId].Value = out_list.GetString("LOT_ID");
                    spdToList.ActiveSheet.Cells[i, (int)ToModuleList.matId].Value = out_list.GetString("MAT_ID");
                    spdToList.ActiveSheet.Cells[i, (int)ToModuleList.matDesc].Value = out_list.GetString("MAT_DESC");
                    spdToList.ActiveSheet.Cells[i, (int)ToModuleList.port].Value = out_list.GetString("PORT");
                    spdToList.ActiveSheet.Cells[i, (int)ToModuleList.grade].Value = out_list.GetString("GRADE");
                    spdToList.ActiveSheet.Cells[i, (int)ToModuleList.power].Value = out_list.GetString("POWER");
                    spdToList.ActiveSheet.Cells[i, (int)ToModuleList.holdCode].Value = out_list.GetString("HOLD_CODE");
                    spdToList.ActiveSheet.Cells[i, (int)ToModuleList.inTime].Value = MPCF.MakeDateFormat(out_list.GetString("TRAN_TIME"), DATE_TIME_FORMAT.DATETIME);
                    spdToList.ActiveSheet.Cells[i, (int)ToModuleList.resTime].Value = out_list.GetString("DT_TIME");

                }

                MPCF.FitColumnHeader(spdToList);
                MPCF.ShowSuccessMessage(out_node, false);


                if (spdToList.ActiveSheet.RowCount > 0) grpConfirm.Text = "Confirm List [Module Count : 0/" + MPCF.Trim(spdToList.ActiveSheet.RowCount) + "]";
                else grpConfirm.Text = "Confirm List";

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ViewReqList()
        {
            try
            {
                if (MPCF.CheckValue(cdvToOper, false) == false)
                {
                    return false;
                }

                MPCF.ClearList(spdReq);
                MPCF.ClearList(spdToList);

                TRSNode in_node = new TRSNode("VIEW_REQ_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_REQ_LIST_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = 'A';
                in_node.AddString("TO_OPER", MPCF.Trim(cdvToOper.Code));
                in_node.AddString("LOT_ID", MPCF.Trim(txtModuleId.Text));
                in_node.AddString("GRADE", MPCF.Trim(cdvGrade.Code));
                in_node.AddString("POWER", MPCF.Trim(cdvPower.Text)); 

                if (MPCF.CallService("CWIP", "CWIP_View_Port_Operation_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdReq.ActiveSheet.RowCount = 0;

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];

                    spdReq.ActiveSheet.RowCount++;

                    spdReq.ActiveSheet.Cells[i, (int)ReqList.reqNo].Value = out_list.GetString("REQ_NO");
                    spdReq.ActiveSheet.Cells[i, (int)ReqList.reqDate].Value = MPCF.MakeDateFormat(out_list.GetString("REQ_DATE"), DATE_TIME_FORMAT.DATE);
                    spdReq.ActiveSheet.Cells[i, (int)ReqList.reqStatus].Value = out_list.GetString("REQ_STATUS");
                    spdReq.ActiveSheet.Cells[i, (int)ReqList.reqQty].Value = out_list.GetString("REQ_QTY");
                    spdReq.ActiveSheet.Cells[i, (int)ReqList.fromOper].Value = out_list.GetString("FROM_OPER");
                    spdReq.ActiveSheet.Cells[i, (int)ReqList.fromOperDesc].Value = out_list.GetString("FROM_OPER_DESC");
                    spdReq.ActiveSheet.Cells[i, (int)ReqList.toOper].Value = out_list.GetString("TO_OPER");
                    spdReq.ActiveSheet.Cells[i, (int)ReqList.toOperDesc].Value = out_list.GetString("TO_OPER_DESC");
                    spdReq.ActiveSheet.Cells[i, (int)ReqList.reqUserId].Value = out_list.GetString("REQ_USER_ID");
                    spdReq.ActiveSheet.Cells[i, (int)ReqList.reqUserDesc].Value = out_list.GetString("REQ_USER_DESC");
                    spdReq.ActiveSheet.Cells[i, (int)ReqList.reqTime].Value = MPCF.MakeDateFormat(out_list.GetString("REQ_TIME"), DATE_TIME_FORMAT.DATETIME);

                }

                MPCF.FitColumnHeader(spdReq);
                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

        }

        private bool TranReqMove(char sProc = '1')
        {
            try
            {

                if (MPCF.CheckValue(cdvToOper, false) == false)
                {
                    return false;
                }

                TRSNode in_node = new TRSNode("TRAN_REQ_LIST_IN");
                TRSNode out_node = new TRSNode("TRAN_REQ_LIST_OUT");
                TRSNode list_item;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = sProc;
                in_node.AddString("TO_OPER", MPCF.Trim(cdvToOper.Code));
                FarPoint.Win.Spread.SheetView with_1 = spdToList.ActiveSheet;

                bool chkFlag = false;
                for (int i = 0; i < with_1.RowCount; i++)
                {
                    if (Convert.ToBoolean(with_1.Cells[i, (int)ToModuleList.chk].Value) == true)
                    {
                        list_item = in_node.AddNode("REQ_LOT_LIST");
                        list_item.AddString("REQ_NO", MPCF.Trim(with_1.Cells[i, (int)ToModuleList.reqNo].Text));
                        list_item.AddString("LOT_ID", MPCF.Trim(with_1.Cells[i, (int)ToModuleList.lotId].Text));
                        list_item.AddString("GRADE", MPCF.Trim(with_1.Cells[i, (int)ToModuleList.grade].Text));
                        list_item.AddString("POWER", MPCF.Trim(with_1.Cells[i, (int)ToModuleList.power].Text));
                        chkFlag = true;
                    }

                }

                if (!chkFlag)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(578));
                    return false;
                }

                if (MPCF.CallService("CWIP", "CWIP_Update_Move_Confirm", in_node, ref out_node) == false)
                {
                    return false;
                }

                btnView.PerformClick();
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

        #region model

        /// <summary>
        /// REQ 정보
        /// </summary>
        private enum ReqList
        {
            reqNo,
            reqDate,
            reqStatus,
            reqQty,
            fromOper,
            fromOperDesc,
            toOper,
            toOperDesc,
            reqUserId,
            reqUserDesc,
            reqTime
        }

        /// <summary>
        /// FROM OPER MODULE 정보
        /// </summary>
        private enum FromModuleList
        {
            chk = 0,
            operCode,
            operDesc,
            lotId,
            matId,
            matDesc,
            port,
            grade,
            power,
            holdCode,
            inTime,
            resTime
        }

        /// <summary>
        /// TO OPER MODULE 정보
        /// </summary>
        private enum ToModuleList
        {
            chk = 0,
            reqNo,
            operCode,
            operDesc,
            lotId,
            matId,
            matDesc,
            port,
            grade,
            power,
            holdCode,
            inTime,
            resTime
        }

        #endregion

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                MPCF.ShowMessageClear();
                if (ViewReqList() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                MPCF.ShowMessageClear();

                if (MPCF.ShowMsgBox(MPCF.GetMessage(577), MessageBoxButtons.YesNo, MSG_LEVEL.INFO) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (TranReqMove() == false)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void spdReq_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (spdReq.ActiveSheet != null)
                {
                    ViewToOperModuleList(spdReq.ActiveSheet.Cells[e.Row, 0].Text);
                }

                btnProcess.Enabled = false;
                btnReject.Enabled = false;

                MPCF.ShowMessageClear();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }
        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                MPCF.ShowMessageClear();

                if (MPCF.ShowMsgBox(MPCF.GetMessage(580), MessageBoxButtons.YesNo, MSG_LEVEL.INFO) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (TranReqMove('2') == false)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void spdToList_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            try
            {
                /*
                int checkedCnt = 0;
                for (int i = 0; i < spdToList.ActiveSheet.RowCount; i++)
                {
                    if (Convert.ToBoolean(spdToList.ActiveSheet.Cells[i, (int)ToModuleList.chk].Value) == true)
                    {
                        checkedCnt++;
                    }
                }

                if (spdToList.ActiveSheet.RowCount > 0) grpConfirm.Text = "Confirm List [Module Count : " + checkedCnt + "/" + MPCF.Trim(spdToList.ActiveSheet.RowCount) + "]";
                else grpConfirm.Text = "Confirm List";

                if (spdToList.ActiveSheet.RowCount == checkedCnt) btnProcess.Enabled = true;
                else btnProcess.Enabled = false;
                */
            }
            catch (Exception ex)
            {
                //MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CheckConfirmModuleList();
        }

        private void txtLotId_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    CheckConfirmModuleList();
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
