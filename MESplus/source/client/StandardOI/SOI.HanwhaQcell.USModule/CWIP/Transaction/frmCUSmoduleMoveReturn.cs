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
    public partial class frmCUSmoduleMoveReturn : SOIBaseForm02
    {

        #region Property

        // (Required) 
        private bool bIsShown = false;
        private bool bSearchView = false;
        #endregion

        #region Constructor

        public frmCUSmoduleMoveReturn()
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

            dtpFrom.Value = DateTime.Today;
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

        #endregion

        #region function

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

        private int ScanModuleId(FarPoint.Win.Spread.SheetView FromSpd, string lotId)
        {
            try
            {
                int index = 0;
                FarPoint.Win.Spread.SheetView with_to_oper = spdToList.ActiveSheet;
                for (int i = 0; i <= FromSpd.RowCount - 1; i++)
                {
                    if (MPCF.Trim(FromSpd.Cells[i, (int)ToModuleList.lotId].Text) == MPCF.Trim(lotId))
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

        private bool RemoveToOperRow()
        {
            try
            {
                MPCF.ShowMessageClear();
                FarPoint.Win.Spread.SheetView with_1 = spdReq.ActiveSheet;
                if (with_1.RowCount > 0)
                {
                    for (int i = with_1.RowCount - 1; i >= 0; i--)
                    {
                        if (Convert.ToBoolean(with_1.Cells[i, (int)ReqList.chk].Value) == true)
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

        private bool ViewReqList(bool bNonFlag = true)
        {
            try
            {
                if (MPCF.CheckValue(cdvToOper, false) == false)
                {
                    return false;
                }

                bSearchView = true;
                DateTime dtpDateTimeOut = new DateTime();

                MPCF.ClearList(spdReq);
                if(bNonFlag) MPCF.ClearList(spdToList);

                TRSNode in_node = new TRSNode("VIEW_REQ_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_REQ_LIST_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = 'A';
                in_node.AddString("TO_OPER", MPCF.Trim(cdvToOper.Code));
                in_node.AddString("LOT_ID", MPCF.Trim(txtModuleId.Text));
                in_node.AddString("GRADE", MPCF.Trim(cdvGrade.Code));
                in_node.AddString("POWER", MPCF.Trim(cdvPower.Text));
                in_node.AddChar("RECV_OPER", 'Y');

                if (dtpFrom.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpFrom.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("FROM_DATE", dtpDateTimeOut.ToString("yyyyMMdd"));
                    }
                }

                if (MPCF.CallService("CWIP", "CWIP_View_Port_Operation_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ClearList(spdReq);
                spdReq.ActiveSheet.RowCount = 0;

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];

                    spdReq.ActiveSheet.RowCount++;

                    spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.chk].Locked = false;

                    spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.reqNo].Value = out_list.GetString("REQ_NO");
                    spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.reqDate].Value = MPCF.MakeDateFormat(out_list.GetString("REQ_DATE"), DATE_TIME_FORMAT.DATE);
                    spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.lotId].Value = out_list.GetString("LOT_ID");
                    spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.fromOper].Value = out_list.GetString("FROM_OPER");
                    spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.fromOperDesc].Value = out_list.GetString("FROM_OPER_DESC");
                    spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.grade].Value = out_list.GetString("GRADE");
                    spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.power].Value = out_list.GetString("POWER");
                    spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.comm].Value = out_list.GetString("ERR_DESC");
                }

                MPCF.FitColumnHeader(spdReq);
                MPCF.ShowSuccessMessage(out_node, false);

                if (spdReq.ActiveSheet.RowCount == 0) grpReq.Text = "Confirm List";
                else
                    grpReq.Text = "Confirm List [Module Count : " + MPCF.Trim(spdReq.ActiveSheet.RowCount) + "]";

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
                
                TRSNode list_item;
                TRSNode out_list;               
                FarPoint.Win.Spread.SheetView with_1 = spdReq.ActiveSheet;

                bool chkFlag = false;
                for (int i = 0; i < with_1.RowCount; i++)
                {
                    if (Convert.ToBoolean(with_1.Cells[i, (int)ReqList.chk].Value) == true)
                    {
                        TRSNode in_node = new TRSNode("TRAN_REQ_LIST_IN");
                        TRSNode out_node = new TRSNode("TRAN_REQ_LIST_OUT");
                        MPCF.SetInMsg(in_node);
                        in_node.ProcStep = sProc;
                        in_node.AddString("TO_OPER", MPCF.Trim(cdvToOper.Code));

                        list_item = in_node.AddNode("REQ_LOT_LIST");
                        list_item.AddString("REQ_NO", MPCF.Trim(with_1.Cells[i, (int)ReqList.reqNo].Text));
                        list_item.AddString("LOT_ID", MPCF.Trim(with_1.Cells[i, (int)ReqList.lotId].Text));
                        list_item.AddString("GRADE", MPCF.Trim(with_1.Cells[i, (int)ReqList.grade].Text));
                        list_item.AddString("POWER", MPCF.Trim(with_1.Cells[i, (int)ReqList.power].Text));
                        chkFlag = true;

                        if (MPCF.CallService("CWIP", "CWIP_Update_Move_Confirm", in_node, ref out_node) == false)
                        {
                            spdToList.ActiveSheet.RowCount++;
                            spdToList.ActiveSheet.Cells[spdToList.ActiveSheet.Rows.Count - 1, (int)ToModuleList.lotId].Value = MPCF.Trim(with_1.Cells[i, (int)ReqList.lotId].Text);
                            spdToList.ActiveSheet.Cells[spdToList.ActiveSheet.RowCount - 1, (int)ToModuleList.comm].Value = out_node.GetString("MSG");
                        }
                        else
                        {
                            /** ERROR LIST CHECK ***/
                            if (out_node.GetList(0).Count > 0)
                            {
                                out_list = out_node.GetList(0)[0];

                                spdToList.ActiveSheet.RowCount++;
                                spdToList.ActiveSheet.Cells[spdToList.ActiveSheet.Rows.Count - 1, (int)ToModuleList.operCode].Value = MPCF.Trim(cdvToOper.Code);
                                spdToList.ActiveSheet.Cells[spdToList.ActiveSheet.Rows.Count - 1, (int)ToModuleList.operDesc].Value = MPCF.Trim(cdvToOper.Description);
                                spdToList.ActiveSheet.Cells[spdToList.ActiveSheet.Rows.Count - 1, (int)ToModuleList.lotId].Value = out_list.GetString("LOT_ID");
                                spdToList.ActiveSheet.Cells[spdToList.ActiveSheet.Rows.Count - 1, (int)ToModuleList.comm].Value = out_list.GetString("ERR_DESC");
                            }
                        }
                    }

                }

                if (!chkFlag)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(578));
                    return false;
                }

                MPCF.FitColumnHeader(spdToList);

                ViewReqList(false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }


        private void CheckConfirmModuleList()
        {
            TRSNode in_node = new TRSNode("TRAN_REQ_LIST_IN");
            TRSNode out_node = new TRSNode("TRAN_REQ_LIST_OUT");
            TRSNode list_item;
            TRSNode out_list;
            string[] arrModule;
            bool bExist = false;

            try
            {
                if (MPCF.CheckValue(cdvToOper, false) == false)
                {
                    return;
                }

                if (MPCF.Trim(txtLotId.Text) == "") return;

                //view 버튼 클릭 시 그리드 init 후 insert 
                if (bSearchView == true)
                {
                    spdReq.ActiveSheet.Rows.Count = 0;
                    grpReq.Text = "Confirm List";
                    bSearchView = false;
                }

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = 'B';
                arrModule = txtLotId.Text.Split('\r'); //.Distinct().ToArray();

                for (int i = 0; i < arrModule.Length; i++)
                {
                    string str = arrModule[i];
                    arrModule[i] = MPCF.Trim(str);
                }

                string[] modules = arrModule.Distinct().ToArray();

                foreach (var module in modules)
                {
                    if (MPCF.Trim(module) == "") continue;

                    for (int i = 0; i < spdReq.ActiveSheet.RowCount; i++)
                    {
                        string grdLot = MPCF.Trim(spdReq.ActiveSheet.Cells[i, (int)ReqList.lotId].Value);
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
                        list_item.AddString("TO_OPER", MPCF.Trim(cdvToOper.Code));
                    }
                }

                if (MPCF.CallService("CWIP", "CWIP_View_Port_Operation_List", in_node, ref out_node) == false)
                {
                    return;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];

                    spdReq.ActiveSheet.RowCount++;

                    spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.reqNo].Value = out_list.GetString("REQ_NO");
                    spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.reqDate].Value = MPCF.MakeDateFormat(out_list.GetString("REQ_DATE"), DATE_TIME_FORMAT.DATE);
                    spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.lotId].Value = out_list.GetString("LOT_ID");
                    spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.fromOper].Value = out_list.GetString("FROM_OPER");
                    spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.fromOperDesc].Value = out_list.GetString("FROM_OPER_DESC");
                    spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.grade].Value = out_list.GetString("GRADE");
                    spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.power].Value = out_list.GetString("POWER");
                    spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.comm].Value = MPCF.Trim(out_list.GetString("ERR_DESC"));

                    if (out_list.GetChar("ERR_FLAG") == 'Y')
                    {
                        spdReq.ActiveSheet.Rows[spdReq.ActiveSheet.RowCount - 1].BackColor = Color.DarkGray;
                        spdReq.ActiveSheet.Rows[spdReq.ActiveSheet.RowCount - 1].ForeColor = Color.Red;
                        spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.chk].Locked = true;
                    }
                    else
                    {
                        spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.chk].Locked = false;
                        spdReq.ActiveSheet.Cells[spdReq.ActiveSheet.RowCount - 1, (int)ReqList.chk].Value = true;
                    }
                }

                MPCF.FitColumnHeader(spdReq);

                if (spdReq.ActiveSheet.RowCount > 0) grpReq.Text = "Confirm List [Module Count : " + MPCF.Trim(spdReq.ActiveSheet.RowCount) + "]";
                else grpReq.Text = "Confirm List";

                txtLotId.Text = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }
        #endregion

        #region model

        /// <summary>
        /// REQ 정보
        /// </summary>
        private enum ReqList
        {
            chk = 0,
            reqNo,
            reqDate,
            lotId,
            fromOper,
            fromOperDesc,
            grade,
            power,
            comm
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

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                MPCF.ShowMessageClear();

                //조회 버튼 클릭 유무 체크 
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

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                MPCF.ShowMessageClear();

                if (MPCF.ShowMsgBox(MPCF.GetMessage(582), MessageBoxButtons.YesNo, MSG_LEVEL.INFO) == System.Windows.Forms.DialogResult.Yes)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CheckConfirmModuleList();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (RemoveToOperRow() == false)
                {
                    grpReq.Text = "Confirm List [Module Count : " + MPCF.Trim(spdReq.ActiveSheet.RowCount) + "]";
                    return;
                }
                grpReq.Text = "Confirm List [ Module Count : " + MPCF.Trim(spdReq.ActiveSheet.RowCount) + "]";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                spdToList.ActiveSheet.Rows.Count = 0;
                spdReq.ActiveSheet.Rows.Count = 0;
                grpReq.Text = "Confirm List";
                grpErr.Text = "Error List";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (spdReq.ActiveSheet.RowCount == 0)
                {
                    return;
                }

                // Excel Export
                if (MPCF.ExportToExcel(spdReq, this.Text, "", true, true, true, -1, -1) == false)
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
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }
    }

}
