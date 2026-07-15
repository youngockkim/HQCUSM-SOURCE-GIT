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
using FarPoint.Win.Spread;
using com.miracom.transceiverx.message;

namespace SOI.HanwhaQcell.USModule
{
    public partial class frmCUSmoduleMoveReq : SOIBaseForm02
    {

        #region Property

        // (Required) 
        private bool bIsShown = false;
        private bool bSearchView = false;
        private bool bResultView = false;
        #endregion

        #region Constructor

        public frmCUSmoduleMoveReq()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        private void frmCUSmoduleMoveReq_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);

            MPCF.SetFocus(txtModuleId);

            dtpFrom.Value = DateTime.Today;
        }

        private void frmCUSmoduleMoveReq_Shown(object sender, EventArgs e)
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
                cdvGrade.Text = cdvGrade.Show(cdvGrade, "View Grade", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "GRADE");

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
            try
            {
                // Code View Service
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '3';

                string[] header = new string[] { "POWER" };
                string[] display = new string[] { "POWER" };

                cdvPower.Text = cdvPower.Show(cdvPower, "Power List", "CWIP", "CWIP_View_Port_Operation_List", in_node, "LIST", display, header, "POWER");

                if (cdvPower.Text == null || cdvPower.Text == string.Empty)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvFromOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            //@SL_MAPPING_PRV
            try
            {
                MPCF.FieldClear(this, cdvFromOper);

                // Code View Service
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("KEY_2", MPCF.Trim("FR"));

                string[] header = new string[] { "Oper", "Description" };
                string[] display = new string[] { "OPER", "OPER_SHORT_DESC" };

                cdvFromOper.Text = cdvFromOper.Show(cdvFromOper, "View Port Operation List", "CWIP", "CWIP_View_Port_Operation_List", in_node, "LIST", display, header, "OPER");

                if (cdvFromOper.Text == null || cdvFromOper.Text == string.Empty)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvToOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Code View Service
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("KEY_2", MPCF.Trim("TO"));

                string[] header = new string[] { "Oper", "Description" };
                string[] display = new string[] { "OPER", "OPER_SHORT_DESC" };

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

        private void cdvDestOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Code View Service
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("KEY_2", MPCF.Trim("TO"));

                string[] header = new string[] { "Oper", "Description" };
                string[] display = new string[] { "OPER", "OPER_SHORT_DESC" };

                cdvDestOper.Text = cdvDestOper.Show(cdvDestOper, "View Port Operation List", "CWIP", "CWIP_View_Port_Operation_List", in_node, "LIST", display, header, "OPER");

                if (cdvDestOper.Text == null || cdvDestOper.Text == string.Empty)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                MPCF.ShowMessageClear();

                if (MPCF.CheckValue(cdvFromOper, false) == false)
                {
                    return;
                }

                //조회 버튼 클릭 유무 체크 
                if (ViewReqList() == false)
                {
                    return;
                }
                
                if (ViewFromOperModuleList() == false)
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (RemoveToOperRow() == false)
                {
                    grpConfirm.Text = "Confirm List [Module Count : " + MPCF.Trim(spdFromList.ActiveSheet.RowCount) + "]";
                    return;
                }
                grpConfirm.Text = "Confirm List [ Module Count : " + MPCF.Trim(spdFromList.ActiveSheet.RowCount) + "]";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (spdReq.ActiveSheet.Rows.Count == 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(578));
                    return;
                }

                //취소 하시겠습니까>
                MPCF.ShowMessageClear();

                int iRow = this.spdReq.ActiveSheet.ActiveRowIndex;
                string moduleId = MPCF.Trim(spdReq.ActiveSheet.Cells[iRow, (int)ReqList.lotId].Text);
                if (MPCF.ShowMsgBox("MODULE_ID : " + moduleId + "\r\n" + MPCF.GetMessage(581), MessageBoxButtons.YesNo, MSG_LEVEL.INFO) == System.Windows.Forms.DialogResult.Yes) //LOT 이동을 취소 하시겠습니까?
                {
                    TranReqMoveCancel(iRow);
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
                if (MPCF.CheckValue(cdvToOper, false) == false)
                {
                    return;
                }

                MPCF.ShowMessageClear();

                int rowCnt = 0;

                for (int i = 0; i < spdFromList.ActiveSheet.RowCount; i++)
                {
                    if (Convert.ToBoolean(spdFromList.ActiveSheet.Cells[i, (int)FromModuleList.chk].Value) == true)
                    {
                        rowCnt++;
                    }
                }

                if (rowCnt == 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(578));
                    return;
                }

                if (MPCF.ShowMsgBox(MPCF.GetMessage(577), MessageBoxButtons.YesNo, MSG_LEVEL.INFO) == System.Windows.Forms.DialogResult.Yes)
                {
                    /*
                    if (MPCF.Trim(cdvToOper.Code) == HQGC.OPER_M4030)
                    {
                        if (TranReqOQCMove() == false) return;
                    }
                    else
                    {
                        if (TranReqMove() == false) return;
                    }
                    */
                    if (TranReqMove() == false) return;

                    if (cdvFromOper.Text != "" && spdToList.ActiveSheet.RowCount == 0)
                    {
                        bResultView = true;
                        btnView.PerformClick();
                    }

                    bResultView = false;

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void spdReq_CellDoubleClick(object sender, CellClickEventArgs e)
        {
            try
            {
                if (spdReq.ActiveSheet.Rows.Count == 0) return;

                /*
                if (e.Column == (int)ReqList.del)
                {
                    //취소 하시겠습니까>
                    MPCF.ShowMessageClear();

                    if (MPCF.ShowMsgBox(MPCF.GetMessage(581), MessageBoxButtons.YesNo, MSG_LEVEL.INFO) == System.Windows.Forms.DialogResult.Yes) //LOT 이동을 취소 하시겠습니까?
                    {
                        TranReqMoveCancel(e.Row);
                    }
                }
                */

                if (e.Column == (int)ReqList.lotId)
                {
                    string status = MPCF.Trim(spdReq.ActiveSheet.Cells[e.Row, (int)ReqList.reqStatus].Text);
                    if (status == "REJECT")
                    {
                        txtModuleId.Text = MPCF.Trim(MPCF.Trim(spdReq.ActiveSheet.Cells[e.Row, (int)ReqList.lotId].Text));
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CheckConfirmModuleList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            spdToList.ActiveSheet.Rows.Count = 0;
            spdFromList.ActiveSheet.Rows.Count = 0;
            grpConfirm.Text = "Confirm List";
            grpErr.Text = "Error List";
        }

        private bool RemoveToOperRow()
        {
            try
            {
                MPCF.ShowMessageClear();
                FarPoint.Win.Spread.SheetView with_1 = spdFromList.ActiveSheet;
                if (with_1.RowCount > 0)
                {
                    for (int i = with_1.RowCount - 1; i >= 0; i--)
                    {
                        if (Convert.ToBoolean(with_1.Cells[i, (int)FromModuleList.chk].Value) == true)
                        {
                            with_1.RemoveRows(i, 1);
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

        #endregion

        #region function

        private bool ViewFromOperModuleList()
        {
            try
            {
                MPCF.ClearList(spdFromList);
                bSearchView = true;

                TRSNode in_node = new TRSNode("VIEW_FROM_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_FROM_LIST_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '5';
                in_node.AddString("FROM_OPER", MPCF.Trim(cdvFromOper.Code));
                in_node.AddString("GRADE", MPCF.Trim(cdvGrade.Code));
                in_node.AddString("POWER", MPCF.Trim(cdvPower.Text));

                if (MPCF.CallService("CWIP", "CWIP_View_Port_Operation_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdFromList.ActiveSheet.RowCount = 0;

                if (!bResultView)
                    spdToList.ActiveSheet.RowCount = 0;

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];

                    spdFromList.ActiveSheet.RowCount++;
                    spdFromList.ActiveSheet.Cells[i, (int)FromModuleList.chk].Value = 0;
                    spdFromList.ActiveSheet.Cells[i, (int)FromModuleList.operCode].Value = out_list.GetString("OPER");
                    spdFromList.ActiveSheet.Cells[i, (int)FromModuleList.operDesc].Value = out_list.GetString("OPER_DESC");
                    spdFromList.ActiveSheet.Cells[i, (int)FromModuleList.matId].Value = out_list.GetString("MAT_ID");
                    spdFromList.ActiveSheet.Cells[i, (int)FromModuleList.matDesc].Value = out_list.GetString("MAT_DESC");
                    spdFromList.ActiveSheet.Cells[i, (int)FromModuleList.lotId].Value = out_list.GetString("LOT_ID");
                    spdFromList.ActiveSheet.Cells[i, (int)FromModuleList.grade].Value = out_list.GetString("GRADE");
                    spdFromList.ActiveSheet.Cells[i, (int)FromModuleList.power].Value = out_list.GetString("POWER");

                }

                MPCF.FitColumnHeader(spdFromList);
                MPCF.ShowSuccessMessage(out_node, false);

                if (spdFromList.ActiveSheet.RowCount == 0) 
                    grpConfirm.Text = "Confirm List";
                else
                    grpConfirm.Text = "Confirm List [Module Count : " + MPCF.Trim(spdFromList.ActiveSheet.RowCount) + "]";

                if (spdToList.ActiveSheet.RowCount == 0) 
                    grpErr.Text = "Error List";
                else
                    spdToList.Text = "Error List [Module Count : " + MPCF.Trim(spdToList.ActiveSheet.RowCount) + "]";

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
                if (MPCF.CheckValue(cdvFromOper, false) == false)
                {
                    return false;
                }

                MPCF.ClearList(spdReq);

                bSearchView = true;

                DateTime dtpDateTimeOut = new DateTime();
                TRSNode in_node = new TRSNode("VIEW_REQ_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_REQ_LIST_OUT");

                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '4';
                in_node.AddString("FROM_OPER", MPCF.Trim(cdvFromOper.Code));
                in_node.AddString("GRADE", MPCF.Trim(cdvGrade.Code));
                in_node.AddString("POWER", MPCF.Trim(cdvPower.Text));
                in_node.AddString("TO_OPER", MPCF.Trim(cdvDestOper.Code));
                in_node.SetString("LOT_ID", "");
                if (dtpFrom.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpFrom.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("FROM_DATE", dtpDateTimeOut.ToString("yyyyMMdd"));
                    }
                }

                int reqCnt = 0;
                int rejCnt = 0;

                //조회 모듈 LIST가 있다면 ROW 별로 
                if (MPCF.Trim(txtLotId.Text) != "")
                {
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

                        out_node = new TRSNode("VIEW_REQ_LIST_OUT");
                        in_node.SetString("LOT_ID", module);
                        if (MPCF.CallService("CWIP", "CWIP_View_Port_Operation_List", in_node, ref out_node) == false)
                        {
                            //return false;
                        }
                        else
                        {
                            for (int i = 0; i < out_node.GetList(0).Count; i++)
                            {
                                out_list = out_node.GetList(0)[i];

                                spdReq.ActiveSheet.RowCount++;

                                spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.reqNo].Value = out_list.GetString("REQ_NO");
                                spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.reqDate].Value = MPCF.MakeDateFormat(out_list.GetString("REQ_DATE"), DATE_TIME_FORMAT.DATE);
                                spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.reqStatus].Value = out_list.GetString("REQ_STATUS");
                                spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.lotId].Value = out_list.GetString("LOT_ID");
                                spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.reqQty].Value = out_list.GetString("REQ_QTY");
                                spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.fromOper].Value = out_list.GetString("FROM_OPER");
                                spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.fromOperDesc].Value = out_list.GetString("FROM_OPER_DESC");
                                spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.toOper].Value = out_list.GetString("TO_OPER");
                                spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.toOperDesc].Value = out_list.GetString("TO_OPER_DESC");
                                spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.reqUserId].Value = out_list.GetString("REQ_USER_ID");
                                spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.reqUserDesc].Value = out_list.GetString("REQ_USER_DESC");
                                spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.reqTime].Value = MPCF.MakeDateFormat(out_list.GetString("REQ_TIME"), DATE_TIME_FORMAT.DATETIME);

                                if (MPCF.Trim(out_list.GetString("REQ_STATUS")) == "REJECT")
                                {
                                    spdReq.ActiveSheet.Rows[spdReq.ActiveSheet.RowCount - 1].BackColor = Color.Red;
                                    spdReq.ActiveSheet.Rows[spdReq.ActiveSheet.RowCount - 1].ForeColor = Color.White;
                                    rejCnt++;
                                }
                                else
                                {
                                    reqCnt++;
                                }
                            }
                        }                        
                    }
                }
                else
                {                    
                    if (MPCF.CallService("CWIP", "CWIP_View_Port_Operation_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        out_list = out_node.GetList(0)[i];

                        spdReq.ActiveSheet.RowCount++;

                        spdReq.ActiveSheet.Cells[i, (int)ReqList.reqNo].Value = out_list.GetString("REQ_NO");
                        spdReq.ActiveSheet.Cells[i, (int)ReqList.reqDate].Value = MPCF.MakeDateFormat(out_list.GetString("REQ_DATE"), DATE_TIME_FORMAT.DATE);
                        spdReq.ActiveSheet.Cells[i, (int)ReqList.reqStatus].Value = out_list.GetString("REQ_STATUS");
                        spdReq.ActiveSheet.Cells[i, (int)ReqList.lotId].Value = out_list.GetString("LOT_ID");
                        spdReq.ActiveSheet.Cells[i, (int)ReqList.reqQty].Value = out_list.GetString("REQ_QTY");
                        spdReq.ActiveSheet.Cells[i, (int)ReqList.fromOper].Value = out_list.GetString("FROM_OPER");
                        spdReq.ActiveSheet.Cells[i, (int)ReqList.fromOperDesc].Value = out_list.GetString("FROM_OPER_DESC");
                        spdReq.ActiveSheet.Cells[i, (int)ReqList.toOper].Value = out_list.GetString("TO_OPER");
                        spdReq.ActiveSheet.Cells[i, (int)ReqList.toOperDesc].Value = out_list.GetString("TO_OPER_DESC");
                        spdReq.ActiveSheet.Cells[i, (int)ReqList.reqUserId].Value = out_list.GetString("REQ_USER_ID");
                        spdReq.ActiveSheet.Cells[i, (int)ReqList.reqUserDesc].Value = out_list.GetString("REQ_USER_DESC");
                        spdReq.ActiveSheet.Cells[i, (int)ReqList.reqTime].Value = MPCF.MakeDateFormat(out_list.GetString("REQ_TIME"), DATE_TIME_FORMAT.DATETIME);

                        if (MPCF.Trim(out_list.GetString("REQ_STATUS")) == "REJECT")
                        {
                            spdReq.ActiveSheet.Rows[spdReq.ActiveSheet.RowCount - 1].BackColor = Color.Red;
                            spdReq.ActiveSheet.Rows[spdReq.ActiveSheet.RowCount - 1].ForeColor = Color.White;
                            rejCnt++;
                        }
                        else
                        {
                            reqCnt++;
                        }
                    }
                }

                MPCF.FitColumnHeader(spdReq);
                MPCF.ShowSuccessMessage(out_node, false);

                if (spdReq.ActiveSheet.RowCount == 0) grpReq.Text = "Req List";
                else
                    grpReq.Text = "Req List [ Request Count : " + reqCnt + " | Reject Count : " + rejCnt + " ]";

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

        }

        private bool TranReqMove()
        {
            try
            {
                TRSNode list_item;
                TRSNode out_list;
                TRSNode in_node;
                TRSNode out_node;

                FarPoint.Win.Spread.SheetView with_1 = spdFromList.ActiveSheet;
                spdToList.ActiveSheet.RowCount = 0;

                for (int i = 0; i < with_1.RowCount; i++)
                {
                    if (Convert.ToBoolean(with_1.Cells[i, (int)FromModuleList.chk].Value) == true)
                    {
                        in_node = new TRSNode("TRAN_REQ_LIST_IN");
                        out_node = new TRSNode("TRAN_REQ_LIST_OUT");
                        MPCF.SetInMsg(in_node);

                        if (MPCF.Trim(cdvToOper.Code) == HQGC.OPER_M4030)
                        {
                            in_node.ProcStep = '1';
                        }
                        else
                        {
                            in_node.ProcStep = '3';
                        }

                        in_node.AddString("TO_OPER", MPCF.Trim(cdvToOper.Code));
                        list_item = in_node.AddNode("REQ_LOT_LIST");
                        list_item.AddString("OPER", MPCF.Trim(with_1.Cells[i, (int)FromModuleList.operCode].Text));
                        list_item.AddString("LOT_ID", MPCF.Trim(with_1.Cells[i, (int)FromModuleList.lotId].Text));

                        if (MPCF.CallService("CWIP", "CWIP_Update_Move_Request", in_node, ref out_node) == false)
                        {
                            spdToList.ActiveSheet.RowCount++;
                            spdToList.ActiveSheet.Cells[spdToList.ActiveSheet.RowCount - 1, (int)ToModuleList.operCode].Value = MPCF.Trim(cdvToOper.Code);
                            spdToList.ActiveSheet.Cells[spdToList.ActiveSheet.RowCount - 1, (int)ToModuleList.operDesc].Value = MPCF.Trim(cdvToOper.Description);
                            spdToList.ActiveSheet.Cells[spdToList.ActiveSheet.RowCount - 1, (int)ToModuleList.lotId].Value = MPCF.Trim(with_1.Cells[i, (int)FromModuleList.lotId].Text);
                            spdToList.ActiveSheet.Cells[spdToList.ActiveSheet.RowCount - 1, (int)ToModuleList.comm].Value = out_node.GetString("MSG");
                        }

                        MPCF.ShowSuccessMessage(out_node, false);
                    }
                }
                     
                spdFromList.ActiveSheet.RowCount = 0;
                grpConfirm.Text = "Confirm List";

                MPCF.FitColumnHeader(spdToList);
                MPCF.FitColumnHeader(spdFromList);

                if (spdToList.ActiveSheet.RowCount == 0) grpErr.Text = "Error List";
                else
                    grpErr.Text = "Error List [Module Count : " + MPCF.Trim(spdToList.ActiveSheet.RowCount) + "]";

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// 요청/거부 취소 : 창고<->창고 까리 가능 OQC 불가능
        /// </summary>
        /// <returns></returns>
        /*
        private bool TranReqOQCMove()
        {
            TRSNode in_node = new TRSNode("TRAN_REQ_LIST_IN");
            TRSNode out_node = new TRSNode("TRAN_REQ_LIST_OUT");
            TRSNode list_item;
            TRSNode out_list;

            try
            {
                string lotId = "";
                bool chkFlag = false;

                FarPoint.Win.Spread.SheetView with_1 = spdFromList.ActiveSheet;

                // 모듈 1개에 REQ NO 1개로 변경 
                for (int i = 0; i < with_1.RowCount; i++)
                {
                    if (Convert.ToBoolean(with_1.Cells[i, (int)FromModuleList.chk].Value) == true)
                    {
                        lotId = MPCF.Trim(with_1.Cells[i, (int)FromModuleList.lotId].Text);

                        MPCF.SetInMsg(in_node);
                        in_node.ProcStep = '1';
                        in_node.AddString("TO_OPER", MPCF.Trim(cdvToOper.Code));
                        list_item = in_node.AddNode("REQ_LOT_LIST");
                        list_item.AddString("LOT_ID", lotId);

                        if (MPCF.CallService("CWIP", "CWIP_Update_Move_Request", in_node, ref out_node) == false)
                        {
                            spdToList.ActiveSheet.RowCount++;
                            spdToList.ActiveSheet.Cells[spdToList.ActiveSheet.RowCount - 1, (int)ToModuleList.operCode].Value = MPCF.Trim(cdvToOper.Code);
                            spdToList.ActiveSheet.Cells[spdToList.ActiveSheet.RowCount - 1, (int)ToModuleList.operDesc].Value = MPCF.Trim(cdvToOper.Description);
                            spdToList.ActiveSheet.Cells[spdToList.ActiveSheet.RowCount - 1, (int)ToModuleList.lotId].Value = lotId;
                            spdToList.ActiveSheet.Cells[spdToList.ActiveSheet.RowCount - 1, (int)ToModuleList.comm].Value = out_node.GetString("MSG");
                        }
                        else
                        {
                            if (out_node.GetList(0).Count > 0)
                            {
                                out_list = out_node.GetList(0)[0];

                                spdToList.ActiveSheet.RowCount++;

                                spdToList.ActiveSheet.Cells[spdToList.ActiveSheet.RowCount - 1, (int)ToModuleList.operCode].Value = MPCF.Trim(cdvToOper.Code);
                                spdToList.ActiveSheet.Cells[spdToList.ActiveSheet.RowCount - 1, (int)ToModuleList.operDesc].Value = MPCF.Trim(cdvToOper.Description);
                                spdToList.ActiveSheet.Cells[spdToList.ActiveSheet.RowCount - 1, (int)ToModuleList.lotId].Value = out_list.GetString("LOT_ID");
                                spdToList.ActiveSheet.Cells[spdToList.ActiveSheet.RowCount - 1, (int)ToModuleList.comm].Value = out_list.GetString("ERR_DESC");
                            }

                        }
                        MPCF.ShowSuccessMessage(out_node, false);
                        chkFlag = true;
                    }
                }

                if (!chkFlag)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(578));
                    return false;
                }


                spdFromList.ActiveSheet.RowCount = 0;
                grpConfirm.Text = "Confirm List";

                MPCF.FitColumnHeader(spdToList);

                if (spdToList.ActiveSheet.RowCount == 0) grpErr.Text = "Error List";
                else
                    grpErr.Text = "Error List [Module Count : " + MPCF.Trim(spdToList.ActiveSheet.RowCount) + "]";

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }
        */

        private bool TranReqMoveCancel(int row)
        {
            try
            {
                TRSNode in_node = new TRSNode("TRAN_CANCEL_IN");
                TRSNode out_node = new TRSNode("TRAN_CANCEL_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("REQ_NO", MPCF.Trim(spdReq.ActiveSheet.Cells[row, (int)ReqList.reqNo].Text));
                in_node.AddString("LOT_ID", MPCF.Trim(spdReq.ActiveSheet.Cells[row, (int)ReqList.lotId].Text));
                in_node.AddString("TO_OPER", MPCF.Trim(spdReq.ActiveSheet.Cells[row, (int)ReqList.toOper].Text));
                in_node.AddString("FROM_OPER", MPCF.Trim(spdReq.ActiveSheet.Cells[row, (int)ReqList.fromOper].Text));
                if (MPCF.CallService("CWIP", "CWIP_Update_Move_Request", in_node, ref out_node) == false)
                {
                    return false;
                }

                btnView.PerformClick();
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
            del,
            reqNo,
            reqDate,
            reqStatus,
            lotId,
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
            grade,
            power,
            comm,
            error_flag
        }

        /// <summary>
        /// TO OPER MODULE 정보
        /// </summary>
        private enum ToModuleList
        {
            chk = 0,
            operCode,
            operDesc,
            lotId,
            comm
        }
        #endregion

        private void txtModuleId_KeyPress(object sender, KeyPressEventArgs e)
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
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void CheckConfirmModuleList()
        {
            TRSNode in_node = new TRSNode("TRAN_REQ_LIST_IN");
            TRSNode out_node = new TRSNode("TRAN_REQ_LIST_OUT");
            TRSNode list_item;
            TRSNode out_list;
            string[] arrModule;
            try
            {
                //view 버튼 클릭 시 그리드 init 후 insert 
                if (bSearchView == true)
                {
                    spdFromList.ActiveSheet.Rows.Count = 0;
                    grpConfirm.Text = "Confirm List";
                    grpErr.Text = "Error List";
                    bSearchView = false;
                }

                if (MPCF.Trim(txtModuleId.Text) == "") return;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '9';
                arrModule = txtModuleId.Text.Split('\r');

                for (int i = 0; i < arrModule.Length; i++)
                {
                    string str = arrModule[i];
                    arrModule[i] = MPCF.Trim(str);
                }

                string[] modules = arrModule.Distinct().ToArray();

                foreach (var module in modules)
                {
                    if (MPCF.Trim(module) == "") continue;

                    bool bExist = false;
                    // 동일 모듈 있는지 확인 
                    for (int i = 0; i < spdFromList.ActiveSheet.RowCount; i++)
                    {
                        string grdLot = MPCF.Trim(spdFromList.ActiveSheet.Cells[i, (int)FromModuleList.lotId].Value);
                        if (grdLot == MPCF.Trim(module))
                        {
                            bExist = true;
                            break;
                        }
                    }

                    if (!bExist)
                    {
                        list_item = in_node.AddNode("REQ_LOT_LIST");
                        list_item.AddString("LOT_ID", MPCF.Trim(module));
                    }
                }

                if (MPCF.CallService("CWIP", "CWIP_View_Port_Operation_List", in_node, ref out_node) == false)
                {
                    return;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];
                                       

                    if (out_list.GetChar("ERR_FLAG") == 'Y')
                    {
                        spdToList.ActiveSheet.RowCount++;
                        spdToList.ActiveSheet.Cells[spdToList.ActiveSheet.RowCount - 1, (int)ToModuleList.lotId].Value = MPCF.Trim(out_list.GetString("LOT_ID"));
                        spdToList.ActiveSheet.Cells[spdToList.ActiveSheet.RowCount - 1, (int)ToModuleList.operCode].Value = MPCF.Trim(out_list.GetString("OPER"));
                        spdToList.ActiveSheet.Cells[spdToList.ActiveSheet.RowCount - 1, (int)ToModuleList.operDesc].Value = MPCF.Trim(out_list.GetString("OPER_DESC"));
                        spdToList.ActiveSheet.Cells[spdToList.ActiveSheet.RowCount - 1, (int)ToModuleList.comm].Value = MPCF.Trim(out_list.GetString("ERR_DESC"));
                    }
                    else
                    {

                        spdFromList.ActiveSheet.RowCount++;
                        spdFromList.ActiveSheet.Cells[spdFromList.ActiveSheet.RowCount - 1, (int)FromModuleList.chk].Value = true;
                        spdFromList.ActiveSheet.Cells[spdFromList.ActiveSheet.RowCount - 1, (int)FromModuleList.operCode].Value = MPCF.Trim(out_list.GetString("OPER"));
                        spdFromList.ActiveSheet.Cells[spdFromList.ActiveSheet.RowCount - 1, (int)FromModuleList.operDesc].Value = MPCF.Trim(out_list.GetString("OPER_DESC"));
                        spdFromList.ActiveSheet.Cells[spdFromList.ActiveSheet.RowCount - 1, (int)FromModuleList.lotId].Value = MPCF.Trim(out_list.GetString("LOT_ID"));
                        spdFromList.ActiveSheet.Cells[spdFromList.ActiveSheet.RowCount - 1, (int)FromModuleList.matId].Value = MPCF.Trim(out_list.GetString("MAT_ID"));
                        spdFromList.ActiveSheet.Cells[spdFromList.ActiveSheet.RowCount - 1, (int)FromModuleList.matDesc].Value = MPCF.Trim(out_list.GetString("MAT_DESC"));
                        spdFromList.ActiveSheet.Cells[spdFromList.ActiveSheet.RowCount - 1, (int)FromModuleList.power].Value = MPCF.Trim(out_list.GetString("POWER"));
                        spdFromList.ActiveSheet.Cells[spdFromList.ActiveSheet.RowCount - 1, (int)FromModuleList.grade].Value = MPCF.Trim(out_list.GetString("GRADE"));
                    }
                }

                MPCF.FitColumnHeader(spdFromList);
                MPCF.FitColumnHeader(spdToList);

                if (spdToList.ActiveSheet.RowCount == 0) 
                    grpErr.Text = "Error List";
                else
                    grpErr.Text = "Error List [Module Count : " + MPCF.Trim(spdToList.ActiveSheet.RowCount) + "]";

                if (spdFromList.ActiveSheet.RowCount > 0) 
                    grpConfirm.Text = "Confirm List [Module Count : " + MPCF.Trim(spdFromList.ActiveSheet.RowCount) + "]";
                else 
                    grpConfirm.Text = "Confirm List";

                txtModuleId.Text = "";

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }
    }
}
