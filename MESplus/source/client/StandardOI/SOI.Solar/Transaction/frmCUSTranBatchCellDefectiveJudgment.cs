using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOI.CliFrx;
using SOI.DNM;
using SOI.OIFrx;
using BOI.OIFrx;
using Miracom.TRSCore;

namespace SOI.Solar
{
    public partial class frmCUSTranBatchCellDefectiveJudgment : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        #region [Property]

        const string NG = "NG";
        private bool bIsShown = false;

        #endregion

        public frmCUSTranBatchCellDefectiveJudgment()
        {
            InitializeComponent();
        }

        #region [Constant Definition]

        #endregion

        #region [Variable Definition]

        private enum BATCH_LIST
        {
            CHK,
            BATCH_ID,
            TOTAL_QTY,
            OK_QTY,
            NG_QTY
        }

        private enum ADD_LIST
        {
            BATCH_ID,
            DEFECT_CODE,
            DEFECT_CODE_DESC,
            NG_QTY
        }

        #endregion

        #region [FormDefinition]

        #endregion

        #region [Function Definition]

        private bool CheckCondition(string FuncName, int Case = 0)
        {
            try
            {
                switch (FuncName)
                {
                    case CSGC.MP_CHECK_VIEW:

                        if (Case.Equals(0))
                        {
                            if (string.IsNullOrEmpty(cdvResID.Text))
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(410));
                                MPCF.SetFocus(cdvResID);
                                return false;
                            }
                        }
                        else if (Case.Equals(1))
                        {
                            if (string.IsNullOrEmpty(cdvLine.Text))
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(411));
                                MPCF.SetFocus(cdvLine);
                                return false;
                            }
                        }
                        else if (Case.Equals(2))
                        {
                            if (string.IsNullOrEmpty(cdvOper.Text))
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(412));
                                MPCF.SetFocus(cdvOper);
                                return false;
                            }
                        }

                        break;

                    case CSGC.MP_CHECK_CREATE:

                        //if (spdBatchAddList.ActiveSheet.RowCount <= 0)
                        //{
                        //    MPCF.ShowMsgBox(MPCF.GetMessage(122));
                        //    return false;
                        //}

                        break;

                    case CSGC.MP_CHECK_UPDATE:

                        if (string.IsNullOrEmpty(txtBatchID.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(452));
                            return false;
                        }
                        if (int.Parse(txtNgQty.Text) <= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(453));
                            MPCF.SetFocus(txtNgQty);
                            return false;
                        }

                        if (string.IsNullOrEmpty(cdvDefectCode.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(450));
                            MPCF.SetFocus(cdvDefectCode);
                            return false;
                        }

                        bool dupFlag = false;

                        for (int i = 0; i < spdBatchAddList.ActiveSheet.RowCount; i++)
                        {
                            if (txtBatchID.Text.Equals(spdBatchAddList.ActiveSheet.Cells[i, (int)ADD_LIST.BATCH_ID].Value.ToString()) &&
                                cdvDefectCode.Text.Equals(spdBatchAddList.ActiveSheet.Cells[i, (int)ADD_LIST.DEFECT_CODE].Value.ToString()))
                            {
                                dupFlag = true;
                                break;
                            }
                        }

                        if (dupFlag)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(111));
                            return false;
                        }

                        break;

                    case CSGC.MP_CHECK_DELETE:

                        if (spdBatchAddList.ActiveSheet.ActiveRowIndex < 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(272));
                            return false;
                        }

                        break;

                    default:

                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void initCtrl()
        {
            try
            {
                MPCF.ClearList(this.spdBatchList);
                MPCF.ClearList(this.spdBatchAddList);
                txtBatchID.Text = string.Empty;
                txtNgQty.Value = 0;
                cdvDefectCode.Text = string.Empty;
                txtDefectCodeDesc.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private bool ViewLotBatchCellList()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            MPCF.ClearList(this.spdBatchList);

            try
            {
                sViewID = "VIEW_BATCH_CELL_JUDGE_LIST";
                i_cond_cnt = 3;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$RES_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(cdvResID.Text);

                ArrDVC[2].sCondtion_ID = "$TYPE";
                ArrDVC[2].sCondition_Value = NG;

                if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    spdBatchList.ActiveSheet.RowCount++;
                    spdBatchList.ActiveSheet.Cells[spdBatchList.ActiveSheet.RowCount - 1, (int)BATCH_LIST.BATCH_ID].Value = MPCF.Trim(dt.Rows[r]["MAT_LOT_ID"].ToString());
                    spdBatchList.ActiveSheet.Cells[spdBatchList.ActiveSheet.RowCount - 1, (int)BATCH_LIST.TOTAL_QTY].Value = MPCF.Trim(dt.Rows[r]["TOTAL_QTY"].ToString());
                    spdBatchList.ActiveSheet.Cells[spdBatchList.ActiveSheet.RowCount - 1, (int)BATCH_LIST.OK_QTY].Value = MPCF.Trim(dt.Rows[r]["TOTAL_QTY"].ToString());
                    spdBatchList.ActiveSheet.Cells[spdBatchList.ActiveSheet.RowCount - 1, (int)BATCH_LIST.NG_QTY].Value = 0;
                }

                MPCF.FitColumnHeader(this.spdBatchList);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return false;
            }
        }

        private bool AddBatchCell()
        {
            try
            {
                spdBatchAddList.ActiveSheet.RowCount++;
                spdBatchAddList.ActiveSheet.Cells[spdBatchAddList.ActiveSheet.RowCount - 1, (int)ADD_LIST.BATCH_ID].Value = MPCF.Trim(txtBatchID.Text);
                spdBatchAddList.ActiveSheet.Cells[spdBatchAddList.ActiveSheet.RowCount - 1, (int)ADD_LIST.DEFECT_CODE].Value = MPCF.Trim(cdvDefectCode.Text);
                spdBatchAddList.ActiveSheet.Cells[spdBatchAddList.ActiveSheet.RowCount - 1, (int)ADD_LIST.DEFECT_CODE_DESC].Value = MPCF.Trim(txtDefectCodeDesc.Text);
                spdBatchAddList.ActiveSheet.Cells[spdBatchAddList.ActiveSheet.RowCount - 1, (int)ADD_LIST.NG_QTY].Value = MPCF.Trim(txtNgQty.Text);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return false;
            }
        }

        private void SetBatchQty()
        {
            int ngQty = 0;

            try
            {
                for (int i = 0; i < spdBatchList.ActiveSheet.RowCount; i++)
                {
                    string baseBatchID = spdBatchList.ActiveSheet.Cells[i, (int)BATCH_LIST.BATCH_ID].Value.ToString();

                    for (int j = 0; j < spdBatchAddList.ActiveSheet.RowCount; j++)
                    {
                        string addBatchID = spdBatchAddList.ActiveSheet.Cells[j, (int)ADD_LIST.BATCH_ID].Value.ToString();

                        if (baseBatchID.Equals(addBatchID))
                        {
                            ngQty += int.Parse(spdBatchAddList.ActiveSheet.Cells[j, (int)ADD_LIST.NG_QTY].Value.ToString());
                        }
                    }

                    spdBatchList.ActiveSheet.Cells[i, (int)BATCH_LIST.NG_QTY].Value = ngQty;
                    spdBatchList.ActiveSheet.Cells[i, (int)BATCH_LIST.OK_QTY].Value = int.Parse(spdBatchList.ActiveSheet.Cells[i, (int)BATCH_LIST.TOTAL_QTY].Value.ToString()) - ngQty;
                    ngQty = 0;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return;
            }
        }

        private bool CheckOverBatchQty()
        {
            try
            {
                for (int i = 0; i < spdBatchList.ActiveSheet.RowCount; i++)
                {
                    int baseBatchOkQty = int.Parse(spdBatchList.ActiveSheet.Cells[i, (int)BATCH_LIST.OK_QTY].Value.ToString());

                    if (baseBatchOkQty < 0) // 초과 수량을 OK Qty 로 판단
                    {
                        string baseBatchID = spdBatchList.ActiveSheet.Cells[i, (int)BATCH_LIST.BATCH_ID].Value.ToString();

                        for (int j = spdBatchAddList.ActiveSheet.RowCount - 1; j >= 0; j--)
                        {
                            string addBatchID = spdBatchAddList.ActiveSheet.Cells[j, (int)ADD_LIST.BATCH_ID].Value.ToString();

                            if (baseBatchID.Equals(addBatchID))
                            {
                                spdBatchAddList_Sheet1.RemoveRows(j, 1);
                                return false; // 초과수량 발생알림
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return false;
            }
        }

        private bool ProcessCellJudge()
        {
            TRSNode in_node = new TRSNode("CUS_CELL_JUDGMENT_LIST_IN");
            TRSNode out_node = new TRSNode("CUS_CELL_JUDGMENT_LIST_OUT");
            TRSNode list_item;

            bool batchExist = false;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_CREATE;

                //리스트에 있는 CELL을 OK 판정
                if (spdBatchAddList.ActiveSheet.RowCount == 0)
                {
                    for (int i = 0; i < spdBatchList.ActiveSheet.RowCount; i++)
                    {
                        if (Convert.ToBoolean(spdBatchList.ActiveSheet.Cells[i, (int)BATCH_LIST.CHK].Value) == true)
                        {
                            list_item = in_node.AddNode("BATCH_OK_LIST");
                            list_item.AddString("BATCH_ID", MPCF.Trim(spdBatchList.ActiveSheet.Cells[i, (int)BATCH_LIST.BATCH_ID].Value));
                            list_item.AddInt("OK_QTY", MPCF.Trim(spdBatchList.ActiveSheet.Cells[i, (int)BATCH_LIST.OK_QTY].Value));
                            list_item.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                        }
                    }
                }
                else
                {
                    in_node.AddChar("NG_FLAG", 'Y');

                    // 불량코드별 ADD 된 BATCH 아이디 NG 리스트
                    for (int i = 0; i < spdBatchAddList.ActiveSheet.RowCount; i++)
                    {
                        list_item = in_node.AddNode("BATCH_LIST");
                        list_item.AddString("BATCH_ID", MPCF.Trim(spdBatchAddList.ActiveSheet.Cells[i, (int)ADD_LIST.BATCH_ID].Value));
                        list_item.AddString("DEFECT_CODE", MPCF.Trim(spdBatchAddList.ActiveSheet.Cells[i, (int)ADD_LIST.DEFECT_CODE].Value));
                        list_item.AddInt("NG_QTY", MPCF.Trim(spdBatchAddList.ActiveSheet.Cells[i, (int)ADD_LIST.NG_QTY].Value));
                        list_item.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                    }

                    // 불량코드에서 제외된 BATCH 아이디 OK 리스트
                    for (int k = 0; k < spdBatchList.ActiveSheet.RowCount; k++)
                    {
                        string baseBatchID = spdBatchList.ActiveSheet.Cells[k, (int)BATCH_LIST.BATCH_ID].Value.ToString();

                        for (int i = 0; i < spdBatchAddList.ActiveSheet.RowCount; i++)
                        {
                            if (baseBatchID.Equals(spdBatchAddList.ActiveSheet.Cells[i, (int)ADD_LIST.BATCH_ID].Value.ToString()))
                            {
                                batchExist = true;
                                break;
                            }
                        }

                        // ADD리스트에 추가된 BATCH 아이디만 OK 리스트(ADD된 NG 리스트에서 사용되고 남은 수량)에 추가함
                        if (batchExist)
                        {
                            list_item = in_node.AddNode("BATCH_OK_LIST");
                            list_item.AddString("BATCH_ID", MPCF.Trim(baseBatchID));
                            list_item.AddInt("OK_QTY", MPCF.Trim(spdBatchList.ActiveSheet.Cells[k, (int)BATCH_LIST.OK_QTY].Value));
                            list_item.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                            batchExist = false;
                        }
                    }
                }

                if (MPCF.CallService("CUS", "CUS_Defect_Cell_Judgment", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, true);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        #region [Event Definition]

        private void frmCUSTranBatchCellDefectiveJudgment_Load(object sender, EventArgs e)
        {
            MPCF.ClearList(spdBatchList);
            MPCF.ClearList(spdBatchAddList);

            cdvLine.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvLine.Tag"));
            cdvLine.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvLine.Text"));
            txtLineDesc.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "txtLineDesc.Text"));

            cdvOper.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvOper.Tag"));
            cdvOper.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvOper.Text"));
            txtOperDesc.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "txtOperDesc.Text"));

            cdvResID.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvResID.Tag"));
            cdvResID.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvResID.Text"));
            txtResDesc.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "txtResDesc.Text"));

        }

        private void frmCUSTranBatchCellDefectiveJudgment_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                bIsShown = true;
            }
        }

        private void frmCUSTranBatchCellDefectiveJudgment_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvLine.Tag", MPCF.Trim(cdvLine.Tag));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvLine.Text", MPCF.Trim(cdvLine.Text));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "txtLineDesc.Text", MPCF.Trim(txtLineDesc.Text));

                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvOper.Tag", MPCF.Trim(cdvOper.Tag));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvOper.Text", MPCF.Trim(cdvOper.Text));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "txtOperDesc.Text", MPCF.Trim(txtOperDesc.Text));

                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvResID.Tag", MPCF.Trim(cdvResID.Tag));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvResID.Text", MPCF.Trim(cdvResID.Text));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "txtResDesc.Text", MPCF.Trim(txtResDesc.Text));
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
            }
        }

        private void cdvLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(MPGC.MP_RAS_AREA_CODE));

                string[] header = new string[] { "Line", "Line Desc" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvLine.Text = cdvLine.Show(cdvLine, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                cdvOper.Text = string.Empty;
                txtOperDesc.Text = string.Empty;
                cdvResID.Text = string.Empty;
                txtResDesc.Text = string.Empty;

                if (cdvLine.returnDatas != null && cdvLine.returnDatas.Count > 0)
                {
                    cdvLine.Tag = cdvLine.returnDatas[0];
                    cdvLine.Text = cdvLine.returnDatas[0];
                    txtLineDesc.Text = cdvLine.returnDatas[1];
                }
                else
                {
                    cdvLine.Text = string.Empty;
                    txtLineDesc.Text = string.Empty;
                }
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
                if (!CheckCondition(CSGC.MP_CHECK_VIEW, 1)) { return; }

                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[1];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                string[] header = new string[] { "Code", "Code Desc" };
                string[] display = new string[] { "OPER", "OPER_DESC" };

                cdvOper.Text = cdvOper.Show(cdvOper, "Code Desc", "VIEW_OPER_LIST", dvcArgu, display, header, "OPER", -1);

                cdvResID.Text = string.Empty;
                txtResDesc.Text = string.Empty;

                if (cdvOper.returnDatas != null && cdvOper.returnDatas.Count > 0)
                {
                    cdvOper.Tag = cdvOper.returnDatas[0];
                    cdvOper.Text = cdvOper.returnDatas[0];
                    txtOperDesc.Text = cdvOper.returnDatas[1];
                }
                else
                {
                    cdvOper.Tag = string.Empty;
                    txtOperDesc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvResID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCondition(CSGC.MP_CHECK_VIEW, 2)) { return; }

                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$OPER";
                dvcArgu[1].sCondition_Value = cdvOper.Tag;

                string[] header = new string[] { "Code", "Code Desc" };
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                cdvResID.Text = cdvResID.Show(cdvResID, "Code Desc", "VIEW_MFO_RES_LIST", dvcArgu, display, header, "RES_ID", -1);

                if (MPCF.Trim(cdvResID.Text) != "")
                {
                    if (cdvResID.returnDatas != null && cdvResID.returnDatas.Count > 0)
                    {
                        cdvResID.Tag = cdvResID.returnDatas[0];
                        cdvResID.Text = cdvResID.returnDatas[0];
                        txtResDesc.Text = cdvResID.returnDatas[1];
                    }
                }
                else
                {
                    cdvResID.Tag = string.Empty;
                    txtResDesc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnDefectCode_CodeViewButtonClick(object sender, EventArgs e)
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

                string[] header = new string[] { "Code", "Code Desc" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvDefectCode.Text = cdvDefectCode.Show(cdvDefectCode, "Code Desc", "VIEW_LOSS_REQUEST_OPER", dvcArgu, display, header, "DATA_1", -1);

                if (cdvDefectCode.returnDatas != null && cdvDefectCode.returnDatas.Count > 0)
                {
                    cdvDefectCode.Tag = cdvDefectCode.returnDatas[0];
                    cdvDefectCode.Text = cdvDefectCode.returnDatas[0];
                    txtDefectCodeDesc.Text = cdvDefectCode.returnDatas[1];
                }
                else
                {
                    cdvDefectCode.Tag = string.Empty;
                    txtDefectCodeDesc.Text = string.Empty;
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
                if (!CheckCondition(CSGC.MP_CHECK_VIEW, 0)) { return; }

                initCtrl();
                ViewLotBatchCellList();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdBatchList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (spdBatchList.ActiveSheet.ActiveRowIndex < 0)
                    return;

                txtNgQty.Text = string.Empty;
                txtBatchID.Text = spdBatchList.ActiveSheet.Cells[e.Row, (int)BATCH_LIST.BATCH_ID].Value.ToString();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            initCtrl();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCondition(CSGC.MP_CHECK_UPDATE)) { return; }

                if (AddBatchCell()) // ADD 리스트 추가
                {
                    SetBatchQty(); // OK / NG 수량 표시

                    if (!CheckOverBatchQty()) // 초과 수량 확인시 입력 데이터 삭제
                    {
                        SetBatchQty(); // 수량 초과시 OK / NG 수량 재조회
                        MPCF.ShowMsgBox(MPCF.GetMessage(200)); // 초과됨 메세지
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCondition(CSGC.MP_CHECK_DELETE)) { return; }

                spdBatchAddList_Sheet1.RemoveRows(spdBatchAddList.ActiveSheet.ActiveRowIndex, 1);

                SetBatchQty(); // ADD 리스트 삭제 후 수량 재조회
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (!CheckCondition(CSGC.MP_CHECK_CREATE)) { return; }
            
            if (ProcessCellJudge())
            {
                initCtrl(); // 프로세스 완료 후 초기화
                btnView.PerformClick(); // 조회조건은 초기화 안한 상태에서 재조회
            }
        }

        private void cdvResID_ValueChanged(object sender, EventArgs e)
        {
            btnView.PerformClick();
        }

        #endregion

    }
}
