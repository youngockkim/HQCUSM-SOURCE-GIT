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
    public partial class frmCUSTranRawMaterialJudgement : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        #region [Property]

        const int ENTER = 13;

        //LOT
        const string INV_LOT_ID = "Inv Lot ID";                 // 자재 LotID
        const string MAT_ID = "Mat ID";                         // 제품
        const string MAT_DESC = "Mat Desc";                     // 제품 설명
        const string QTY = "Qty";                               // 수량
        const string UNIT = "Unit";                             // 중량단위
        const string LOT_ID = "Lot ID";                         // Lot ID
        const string REASON_CODE = "Reason Code";               // 사유 코드
        const string REASON_CODE_DESC = "Reason Code Desc";     // 사유 코드명
        const string RESULT_CODE = "Result Code";               // 결과 코드
        const string RESULT_CODE_DESC = "Result Code Desc";     // 결과 코드 설명
        const string QC_RESULT = "QC Result";                   // QC 결과
        const string QC_LOSS_CODE = "QC Loss Code";             // QC 불량코드
        const string QC_LOSS_CODE_DESC = "QC Loss Code Desc";   // QC 불량코드명
        const string TRAN_USER_ID = "Tran User ID";             // 사용자
        const string TRAN_TIME = "Tran Time";                   // 트랜잭션 시간
        //MODULE
        const string OPER = "Oper";
        const string STEP = "Step";
        const string ORDER_ID = "Order ID";
        const string MAT_VER = "Mat Ver";
        const string HIST_SEQ = "Hist Seq";
        //CELL
        const string CELL_ID = "Cell ID";
        const string OLD_STRING_ID = "Old String ID";

        #endregion

        public frmCUSTranRawMaterialJudgement()
        {
            InitializeComponent();
        }

        #region [Constant Definition]

        public enum MAT
        {
            CHK, 
            INV_LOT_ID,
            MAT_ID,
            MAT_DESC,
            QTY_1,
            UNIT_1,
            LOT_ID,
            REASON_CODE,
            REASON_CODE_DESC,
            RESULT_CODE,
            RESULT_CODE_DESC,
            QC_RESULT,
            QC_LOSS_CODE,
            QC_LOSS_CODE_DESC,
            TRAN_USER_ID,
            TRAN_TIME
        }

        public enum MODULE
        {
            CHK,
            REQUEST_DATE,
            QC_DATE,
            LOT_ID,
            MAT_ID,
            MAT_DESC,
            OPER,
            OPER_DESC,
            ORDER_ID,
            LOSS_CODE,
            LOSS_CODE_DESC,
            RESULT_CODE,
            RESULT_CODE_DESC,
            QC_RESULT           
        }

        public enum CELL
        {
            CHK,
            CELL_ID,
            OLD_STRING_ID,
            LOSS_CODE,
            LOSS_CODE_DESC,            
            RESULT_CODE,
            RESULT_CODE_DESC,
            QC_RESULT,
            TRAN_TIME
        }

        private enum LOSS_COL
        {
            LOSS_CODE,
            LOSS_DESC
        }

        #endregion

        #region [Variable Definition]

        private bool bIsShown = false;

        #endregion

        #region [FormDefinition]

        #endregion

        #region [Function Definition]

        private void ClearData(string ProcStep)
        {
            try
            {
                if (ProcStep == "1")
                {
                    MPCF.ClearList(spdUseMaterial);
                }
            }

            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                int i_cnt = 0;

                switch (FuncName)
                {
                    case "VIEW":

                        //if (string.IsNullOrEmpty(txtLotID.Text) == true)
                        //{
                        //    MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Lot ID]"));
                        //    MPCF.SetFocus(txtLotID);
                        //    return false;
                        //}

                        break;

                    case "PROCESS":

                        if (string.IsNullOrEmpty(cdvQCJudgement.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Judgement]"));
                            MPCF.SetFocus(cdvQCJudgement);
                            return false;
                        }

                        if (string.IsNullOrEmpty(cdvResultCode.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Result Code]"));
                            MPCF.SetFocus(cdvResultCode);
                            return false;
                        }

                        for (int k = 0; k < spdUseMaterial.ActiveSheet.RowCount; k++)
                        {
                            if (Convert.ToBoolean(spdUseMaterial.ActiveSheet.Cells[k, (int)MAT.CHK].Value) == true)
                            {
                                if (rdbMat.Checked)
                                {

                                }
                                else if (rdbModule.Checked)
                                {
                                    if (MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[k, (int)MODULE.QC_RESULT].Value) == "NG")
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(455) + Environment.NewLine + MPCF.FindLanguage("[" + MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[k, (int)MODULE.LOT_ID].Value) + "]"));
                                        return false;
                                    }
                                }
                                else if (rdbCell.Checked)
                                {

                                }

                                i_cnt++;
                            }
                        }

                        if(i_cnt == 0)
                        {
                            MPCF.ShowMsgBox("판정할 대상 LOT을 선택 후 진행해주세요.");
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

        private bool ViewUseMaterial()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];
            DataTable dt = null;
            string s_sql = "";

            string sViewID = string.Empty;

            try
            {
                MPCF.ShowMessageClear();

                //Tag 값 입력 후 체크로직
                if (!CheckCondition(CSGC.MP_CHECK_VIEW))
                    return false;

                ClearData("1");

                if (rdbMat.Checked)
                    sViewID = "VIEW_QC_REQUEST_LOT_LIST"; // QC_RESULT OK
                else if (rdbModule.Checked)
                    sViewID = "VIEW_QC_MODULE_LOT_LIST_2";  // STEP R/C
                else if (rdbCell.Checked)
                    sViewID = "VIEW_QC_CELL_LOT_LIST";    // QC_RESULT ' ' / OK / NG

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$FROM_DATE";
                dvcArgu[1].sCondition_Value = MPCF.Trim(this.dtFrDate.GetValueAsString(8));

                dvcArgu[2].sCondtion_ID = "$TO_DATE";
                dvcArgu[2].sCondition_Value = MPCF.Trim(this.dtToDate.GetValueAsString(8));

                if (TPDR.GetDataOne("", ref dt, sViewID, dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();

                    return false;
                }

                if (rdbModule.Checked)
                {
                    if (!string.IsNullOrEmpty(MPCF.Trim(txtLotID.Text)))
                        dt = dt.Select(string.Format("LOT_ID='{0}'", MPCF.Trim(txtLotID.Text))).CopyToDataTable<DataRow>();
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (chkComplete.Checked == false)
                    {
                        if (dt.Rows[i]["QC_RESULT"].ToString() != " ")
                        {
                            continue;
                        }

                        //"QC 판전 완료 포함"이 체크되지 않은 경우에 삭제된 LOT 화면에서 제외
                        if (dt.Rows[i]["LOT_DEL_FLAG"].ToString() == "Y")
                        {
                            continue;
                        }

                    }

                    spdUseMaterial.ActiveSheet.RowCount++;
                    spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.CHK].Value = false;

                    if (rdbMat.Checked)
                    {
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.INV_LOT_ID].Value = dt.Rows[i]["LOT_ID"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.MAT_DESC].Value = dt.Rows[i]["MAT_DESC"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.QTY_1].Value = dt.Rows[i]["QTY_1"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.UNIT_1].Value = dt.Rows[i]["UNIT"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.LOT_ID].Value = dt.Rows[i]["PROD_LOT_ID"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.REASON_CODE].Value = dt.Rows[i]["REASON_CODE"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.REASON_CODE_DESC].Value = dt.Rows[i]["REASON_CODE_DESC"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.RESULT_CODE].Value = dt.Rows[i]["RESULT_CODE"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.RESULT_CODE_DESC].Value = dt.Rows[i]["RESULT_CODE_DESC"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.QC_RESULT].Value = dt.Rows[i]["QC_RESULT"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.QC_LOSS_CODE].Value = dt.Rows[i]["QC_LOSS_CODE"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.QC_LOSS_CODE_DESC].Value = dt.Rows[i]["QC_LOSS_CODE_DESC"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.TRAN_USER_ID].Value = dt.Rows[i]["TRAN_USER_ID"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.TRAN_TIME].Value = dt.Rows[i]["TRAN_TIME"].ToString();

                        if (dt.Rows[i]["QC_RESULT"].ToString() == "NG")
                        {
                            spdUseMaterial.ActiveSheet.Rows[spdUseMaterial.ActiveSheet.RowCount - 1].BackColor = Color.PaleVioletRed;
                        }
                    }
                    else if (rdbModule.Checked)
                    {
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MODULE.REQUEST_DATE].Value = dt.Rows[i]["REQUEST_DATE"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MODULE.QC_DATE].Value = dt.Rows[i]["QC_DATE"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MODULE.LOT_ID].Value = dt.Rows[i]["LOT_ID"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MODULE.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MODULE.MAT_DESC].Value = dt.Rows[i]["MAT_DESC"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MODULE.OPER].Value = dt.Rows[i]["OPER"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MODULE.OPER_DESC].Value = dt.Rows[i]["OPER_DESC"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MODULE.ORDER_ID].Value = dt.Rows[i]["ORDER_ID"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MODULE.LOSS_CODE].Value = dt.Rows[i]["LOSS_CODE"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MODULE.LOSS_CODE_DESC].Value = dt.Rows[i]["LOSS_CODE_DESC"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MODULE.RESULT_CODE].Value = dt.Rows[i]["QC_RST_CODE"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MODULE.RESULT_CODE_DESC].Value = dt.Rows[i]["QC_RST_CODE_DESC"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MODULE.QC_RESULT].Value = dt.Rows[i]["QC_RESULT"].ToString();

                        if (dt.Rows[i]["QC_RESULT"].ToString() == "NG")
                        {
                            spdUseMaterial.ActiveSheet.Rows[spdUseMaterial.ActiveSheet.RowCount - 1].BackColor = Color.PaleVioletRed;
                        }
                    }
                    else if (rdbCell.Checked)
                    {
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)CELL.CELL_ID].Value = dt.Rows[i]["CELL_ID"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)CELL.OLD_STRING_ID].Value = dt.Rows[i]["OLD_STRING_ID"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)CELL.LOSS_CODE].Value = dt.Rows[i]["LOSS_CODE"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)CELL.LOSS_CODE_DESC].Value = dt.Rows[i]["LOSS_CODE_DESC"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)CELL.RESULT_CODE].Value = dt.Rows[i]["QC_RST_CODE"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)CELL.RESULT_CODE_DESC].Value = dt.Rows[i]["QC_RST_CODE_DESC"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)CELL.QC_RESULT].Value = dt.Rows[i]["QC_RESULT"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)CELL.TRAN_TIME].Value = dt.Rows[i]["TRAN_TIME"].ToString();

                        if (dt.Rows[i]["QC_RESULT"].ToString() == "NG")
                        {
                            spdUseMaterial.ActiveSheet.Rows[spdUseMaterial.ActiveSheet.RowCount - 1].BackColor = Color.PaleVioletRed;
                        }
                    }
                }

                if (rdbModule.Checked)
                {
                    string sLotID = string.Empty;
                    int iSpanCnt = 0;

                    for(int j=0; j < spdUseMaterial.ActiveSheet.RowCount; j ++)
                    {
                        if (sLotID != MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[j, (int)MODULE.LOT_ID].Text))
                        {
                            iSpanCnt = 1;
                            sLotID = MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[j, (int)MODULE.LOT_ID].Text);
                        }
                        else
                        {
                            iSpanCnt++;
                        }

                        //for (int k = 0; k < (int)MODULE.OPER; k++)
                        //{
                        //    spdUseMaterial.ActiveSheet.Cells[(j - (iSpanCnt - 1)), k].RowSpan = iSpanCnt;
                        //}
                    }
                }

                MPCF.FitColumnHeader(spdUseMaterial);

                if (rdbMat.Checked)
                    spdUseMaterial.ActiveSheet.Columns[(int)MAT.MAT_DESC].Width = 220F;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private void SetMatSpread()
        {
            MPCF.ClearList(this.spdUseMaterial);

            spdUseMaterial.ActiveSheet.ColumnCount = 16;
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[1].Label = INV_LOT_ID; // 자재 LotID
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[2].Label = MAT_ID; // 제품
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[3].Label = MAT_DESC; // 제품 설명
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[4].Label = QTY; // 수량
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[5].Label = UNIT; // 중량단위
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[6].Label = LOT_ID; // Lot ID
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[7].Label = REASON_CODE; // 사유 코드
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[8].Label = REASON_CODE_DESC; // 사유 코드명
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[9].Label = RESULT_CODE; // 결과 코드
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[10].Label = RESULT_CODE_DESC; // 결과 코드 설명
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[11].Label = QC_RESULT; // QC 결과
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[12].Label = QC_LOSS_CODE; // QC 불량코드
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[13].Label = QC_LOSS_CODE_DESC; // QC 불량코드명
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[14].Label = TRAN_USER_ID; // 사용자
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[15].Label = TRAN_TIME; // 트랜잭션 시간

            for (int c = 0; c < spdUseMaterial.ActiveSheet.ColumnCount; c++)
            {
                if (c == 0)
                {
                    spdUseMaterial_Sheet1.Columns[c].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                }
                else if (c == 4)
                {
                    spdUseMaterial_Sheet1.Columns[c].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                }
                else
                {
                    spdUseMaterial_Sheet1.Columns[c].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                }

                spdUseMaterial_Sheet1.Columns[c].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }

            MPCF.ConvertCaption(spdUseMaterial);
        }

        private void SetModuleSpread()
        {
            MPCF.ClearList(this.spdUseMaterial);

            spdUseMaterial.ActiveSheet.ColumnCount = 14;
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[1].Label = "불량등록일자";
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[2].Label = "QC판정일자"; 
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[3].Label = LOT_ID;
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[4].Label = MAT_ID;
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[5].Label = "Mat Desc";
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[6].Label = OPER;
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[7].Label = "Oper Desc";
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[8].Label = ORDER_ID;
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[9].Label = "Loss Code";
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[10].Label = "Loss Code Desc";
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[11].Label = "Result Code";
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[12].Label = "Result Code Desc";
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[13].Label = QC_RESULT;

            FarPoint.Win.Spread.CellType.TextCellType txt = new FarPoint.Win.Spread.CellType.TextCellType();

            for (int c = 1; c < spdUseMaterial.ActiveSheet.ColumnCount; c++)
            {
                spdUseMaterial_Sheet1.Columns[c].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                spdUseMaterial.Sheets[0].Columns[c].CellType = txt;                
                spdUseMaterial_Sheet1.Columns[c].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }

            MPCF.ConvertCaption(spdUseMaterial);
        }

        private void SetCellSpread()
        {
            MPCF.ClearList(this.spdUseMaterial);

            spdUseMaterial.ActiveSheet.ColumnCount = 9;
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[1].Label = CELL_ID;
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[2].Label = OLD_STRING_ID;
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[3].Label = "Loss Code";
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[4].Label = "Loss Code Desc";
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[5].Label = "Result Code";
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[6].Label = "Result Code Desc";
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[7].Label = QC_RESULT;
            spdUseMaterial.ActiveSheet.ColumnHeader.Columns[8].Label = TRAN_TIME;

            FarPoint.Win.Spread.CellType.TextCellType txt = new FarPoint.Win.Spread.CellType.TextCellType();

            for (int c = 1; c < spdUseMaterial.ActiveSheet.ColumnCount; c++)
            {
                spdUseMaterial_Sheet1.Columns[c].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                spdUseMaterial_Sheet1.Columns[c].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                spdUseMaterial.Sheets[0].Columns[c].CellType = txt;
            }

            MPCF.ConvertCaption(spdUseMaterial);
        }

        private bool Tran_Loss_Lot_Process()
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");
            TRSNode data_list;
            string sLotID = string.Empty;

            try
            {
                MPCF.SetInMsg(in_node);

                if (rdbMat.Checked)
                    in_node.ProcStep = '1';
                else if (rdbModule.Checked)
                    in_node.ProcStep = '2';
                else if (rdbCell.Checked)
                    in_node.ProcStep = '3';

                in_node.AddString("QC_RESULT", MPCF.Trim(cdvQCJudgement.Text));
                in_node.AddString("QC_LOSS_CODE", MPCF.Trim(cdvResultCode.Text));
                in_node.AddString("QC_DATE", dtQCDate.GetValueAsString(8));

                if (string.IsNullOrEmpty(cdvShift.Text) == false)
                {
                    in_node.AddString("SHIFT_CODE", MPCF.Trim(cdvShift.Text));
                }

                for (int k = 0; k < spdUseMaterial.ActiveSheet.RowCount; k++)
                {
                    if (Convert.ToBoolean(spdUseMaterial.ActiveSheet.Cells[k, (int)MAT.CHK].Value) == true)
                    {
                        data_list = in_node.AddNode("DATA_LIST");

                        if (rdbModule.Checked)
                        {                            
                            data_list.AddString("LOT_ID", MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[k, (int)MODULE.LOT_ID].Value));
                            data_list.AddString("OPER", MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[k, (int)MODULE.OPER].Value));
                            data_list.AddString("LOSS_CODE", MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[k, (int)MODULE.LOSS_CODE].Value));                            
                        }
                        else if (rdbMat.Checked)
                        {
                            data_list.AddString("LOT_ID", MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[k, (int)MAT.LOT_ID].Value));
                            data_list.AddString("INV_LOT_ID", MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[k, (int)MAT.INV_LOT_ID].Value));
                        }
                        else if (rdbCell.Checked)
                        {
                            data_list.AddString("CELL_ID", MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[k, (int)CELL.CELL_ID].Value));
                            data_list.AddString("TRAN_TIME", DateTime.Parse(spdUseMaterial.ActiveSheet.Cells[k, (int)CELL.TRAN_TIME].Value.ToString()).ToString("yyyyMMddHHmmss"));
                        }                        
                    }
                }

                if (MPCF.CallService("CUS", "CWIP_Tran_QC_Lot_Process", in_node, ref out_node) == false)
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

        #region [Event Definition]

        private void frmCUSTranRawMaterialJudgement_Load(object sender, EventArgs e)
        {
            dtQCDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;
            dtFrDate.Value = DateTime.Today.AddDays(-7);

            MPCF.ClearList(spdUseMaterial);
        }

        private void frmCUSTranRawMaterialJudgement_Activated(object sender, EventArgs e)
        {
            SetModuleSpread();
        }

        private void frmCUSTranRawMaterialJudgement_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                bIsShown = true;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCondition("VIEW"))
                    return;

                ViewUseMaterial();

                txtLotID.Focus();
                txtLotID.SelectAll();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (!CheckCondition("PROCESS"))
                return;

            DialogResult dr = MPCF.ShowMsgBox(MPCF.GetMessage(377), MessageBoxButtons.OKCancel, SOI.CliFrx.MSG_LEVEL.WARNING);
            if (dr != System.Windows.Forms.DialogResult.OK) return;

            if (Tran_Loss_Lot_Process() == true)
            {
                cdvResultCode.Text = "";
                cdvQCJudgement.Text = "";
                txtCodeDesc.Text = "";
                txtQCDesc.Text = "";
                cdvShift.Text = "";
                btnView.PerformClick(); 
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void spdUseMaterial_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (spdUseMaterial.ActiveSheet.RowCount == 0) return;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvResultCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TABLE_NAME";
                dvcArgu[1].sCondition_Value = "C@LOSS_CODE";

                // CodeView Column Header Setup
                string[] header = new string[] { "Code", "Code Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvResultCode.Text = cdvResultCode.Show(cdvResultCode, "Code Desc", "VIEW_GCM_DATA", dvcArgu, display, header, "DATA_1", -1);

                if (MPCF.Trim(cdvResultCode.Text) != "")
                {
                    if (cdvResultCode.returnDatas != null && cdvResultCode.returnDatas.Count > 0)
                    {
                        cdvResultCode.Text = cdvResultCode.returnDatas[0];
                        txtCodeDesc.Text = cdvResultCode.returnDatas[1];
                    }
                }
                else
                {
                    cdvResultCode.Text = "";
                    txtCodeDesc.Text = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvQCJudgement_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TABLE_NAME";
                dvcArgu[1].sCondition_Value = "OKNG";

                // CodeView Column Header Setup
                string[] header = new string[] { "Code", "Code Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvQCJudgement.Text = cdvQCJudgement.Show(cdvQCJudgement, "Code Desc", "VIEW_GCM_DATA", dvcArgu, display, header, "DATA_1", -1);

                if (MPCF.Trim(cdvQCJudgement.Text) != "")
                {
                    if (cdvQCJudgement.returnDatas != null && cdvQCJudgement.returnDatas.Count > 0)
                    {
                        cdvQCJudgement.Text = cdvQCJudgement.returnDatas[0];
                        txtQCDesc.Text = cdvQCJudgement.returnDatas[1];
                    }
                }
                else
                {
                    cdvQCJudgement.Text = "";
                    txtQCDesc.Text = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void rdbButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMat.Checked)
            {
                lblLotID.Visible = false;
                txtLotID.Visible = false;
                SetMatSpread();
            }
            else if (rdbModule.Checked)
            {
                lblLotID.Visible = true;
                txtLotID.Visible = true;
                SetModuleSpread();
            }
            else if (rdbCell.Checked)
            {
                lblLotID.Visible = false;
                txtLotID.Visible = false;
                SetCellSpread();
            }

            MPCF.FitColumnHeader(spdUseMaterial);
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER)
            {
                MPCF.ShowMessage("", MSG_LEVEL.NONE, false);

                btnView.PerformClick();

                txtLotID.Focus();
                txtLotID.SelectAll();
            }
        }

        #endregion

        private void cdvShift_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TABLE_NAME";
                dvcArgu[1].sCondition_Value = "WRGR_CODE";

                // CodeView Column Header Setup
                string[] header = new string[] { "Code", "Code Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_3" };

                // Show
                cdvShift.Text = cdvShift.Show(cdvShift, "Code Desc", "VIEW_SHIFT_CODE", dvcArgu, display, header, "DATA_3", -1);

                if (MPCF.Trim(cdvShift.Text) != "")
                {
                    if (cdvShift.returnDatas != null && cdvShift.returnDatas.Count > 0)
                    {
                        cdvShift.Tag = cdvShift.returnDatas[0];
                    }
                }
                else
                {
                    cdvShift.Tag = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

    }
}