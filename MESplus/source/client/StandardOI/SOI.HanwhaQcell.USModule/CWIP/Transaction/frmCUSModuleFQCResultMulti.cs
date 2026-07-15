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
using SOI.DNM;
using Infragistics.Win.UltraWinGrid;
using SOI.HanwhaQcell.USModule.CWIP.Popup;
using System.Collections;

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCUSModuleFQCResultMulti : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private TRSNode nodeLotInfo;
        private List<string> lotList;

        #endregion

        #region Constructor

        public frmCUSModuleFQCResultMulti()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        public enum TEST_LIST
        {
            X,
            LOT_ID,
            MAT_ID,
            LINE_ID,
            RES_ID,
            GRADE,
            PMPP,
            POWER
        }

        public string str_cell_qty = "99999";

        #endregion


        #region Event Handler

        private void frmCUSModuleFQCResult_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            MPCF.ConvertCaption(this);
        }

        private void frmCUSModuleFQCResult_Shown(object sender, EventArgs e)
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

        //등급 변경시
        private void cdvGrade_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {

                if (lotList == null)
                {
                    MPCF.ShowMsgBox("Please Check Module Id");
                    txtLotID.Focus();

                    return;
                }
                //Empty the Power
                if (txtLotID.Text == "")
                {
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_GRADE));

                string[] header = new string[] { "Grade", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvGrade.Text = cdvGrade.Show(cdvGrade, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                if (string.IsNullOrEmpty(cdvGrade.Text) == true)
                {
                    return;
                }


                for (int x = 0; x < lotList.Count; x++)
                {
                    spdFlashRlt.ActiveSheet.Cells[x, (int)TEST_LIST.POWER].Value = "";
                }

                //RWK이 아닌경우 @POWER_RANGE와 @ARTICLE을 확인한다
                if (cdvGrade.Text != "RWK" && !CheckArticle())
                {
                    cdvGrade.Text = "";
                    return;
                }

                //Disable Defect codes and cell location when G01 and G02 are selected
                //if (cdvGrade.Text == "G01" || cdvGrade.Text == "G02")
                if (cdvGrade.Text == "G01")
                {
                    this.cdvDefectCode.Enabled = false;
                    this.cdvCellLocation.Enabled = false;
                    this.cdvDefectCode.Text = "";
                    this.cdvDefectCode.Description = "";
                    this.cdvCellLocation.Text = "";
                    this.cdvCellLocation.Description = "";
                }
                else
                {
                    this.cdvDefectCode.Enabled = true;
                    this.cdvCellLocation.Enabled = true;
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
            InitViews();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCondition("PROCESS"))
                {
                    return;
                }

                if (MPCF.ShowMsgBox(MPCF.GetMessage(539), MessageBoxButtons.YesNo, MSG_LEVEL.WARNING) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                Tran_FQC_Input();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        private void InitViews()
        {
            try
            {
                // Lot ID Check
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                // FieldClear
                MPCF.FieldClear(pnlMiddleMargin, txtLotID);
                //MPCF.ClearList(spdFlashRlt);

                str_cell_qty = "99999";

                lotList = txtLotID.Text.Replace("\r", "").Trim().Split('\n').Distinct().ToList();
                if (lotList.Count > 100)
                {
                    MPCF.ShowMessage("You can input up to 100", MSG_LEVEL.ERROR, false);
                    return;
                }

                spdFlashRlt.ActiveSheet.RowCount = 0;
                for (int x = 0; x < lotList.Count; x++)
                {
                    spdFlashRlt.ActiveSheet.RowCount++;
                    // View Lot
                    if (ViewLot(lotList[x], x) == false)
                    {
                        txtLotID.SelectAll();
                        lotList = null;
                        return;
                    }

                    if (ViewTestData(lotList[x], x) == false)
                    {
                        txtLotID.SelectAll();
                        lotList = null;
                        return;
                    }
                }

                txtLotID.Focus();
                txtLotID.SelectAll();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private bool ViewLot(string sLotId, int index)
        {
            TRSNode in_node = new TRSNode("VIEW_FQC_IN");
            TRSNode out_node = new TRSNode("VIEW_FQC_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INS_TYPE", HQGC.INSP_TYPE_FC);
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));
                in_node.AddChar("RE_JUDGE_FLAG", 'Y');  // 재판정 OI에서만 사용

                //마지막 FQC 판정을 읽어온다 없으면 재판정이 아님
                //CEDCLOTRLT.INS_TYPE = FC
                if (MPCF.CallService("CWIP", "CWIP_View_Fqc_Result", in_node, ref out_node) == false)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(154), MSG_LEVEL.ERROR, false);
                    return false;
                }

                // 재판정임에도 LOT 정보 없으면 모든 필드 초기화
                if (out_node.GetString("RE_JUDGE").Equals("Y") && (out_node.GetString("RES_ID") == "" || out_node.GetString("LINE_ID") == ""))
                {
                    MPCF.ShowMessage(MPCF.GetMessage(154), MSG_LEVEL.ERROR, false);
                    return false;
                }

                nodeLotInfo = out_node;

                //CELL QTY 최소값을 str_cell_qty에 저장해둠.
                int result = 0;
                if (Int32.TryParse(out_node.GetString("MAT_CMF_3"), out result))
                {
                    if (Int32.Parse(str_cell_qty) > result)
                        str_cell_qty = result.ToString();
                }
                else
                {
                    MPCF.ShowMessage("CELL Qty(MAT_CMF_3) Error", MSG_LEVEL.ERROR, false);
                    return false;
                }


                spdFlashRlt.ActiveSheet.Cells[index, (int)TEST_LIST.X].Value = index + 1;
                spdFlashRlt.ActiveSheet.Cells[index, (int)TEST_LIST.LOT_ID].Value = MPCF.Trim(sLotId);
                spdFlashRlt.ActiveSheet.Cells[index, (int)TEST_LIST.MAT_ID].Value = out_node.GetString("MAT_ID");

                // Read Line and Equipment ID if rejudge
                if (out_node.GetString("RE_JUDGE").Equals("Y"))
                {
                    spdFlashRlt.ActiveSheet.Cells[index, (int)TEST_LIST.LINE_ID].Value = out_node.GetString("LINE_ID");
                    spdFlashRlt.ActiveSheet.Cells[index, (int)TEST_LIST.RES_ID].Value = out_node.GetString("RES_ID");
                    spdFlashRlt.ActiveSheet.Cells[index, (int)TEST_LIST.GRADE].Value = out_node.GetString("GRADE");
                }
                // Generate otherwise
                else
                {
                    spdFlashRlt.ActiveSheet.Cells[index, (int)TEST_LIST.LINE_ID].Value = "MDL0" + MPCF.Trim(sLotId).Substring(2, 1);
                    int line_cd;
                    line_cd = int.Parse(MPCF.Trim(sLotId).Substring(2, 1));
                    string strRes = "US-E" + line_cd + "-FQC-02";

                    if (line_cd > 3)
                    {
                        strRes = "US-E" + line_cd + "-FQC-03";
                    }
                    spdFlashRlt.ActiveSheet.Cells[index, (int)TEST_LIST.RES_ID].Value = strRes;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool ViewTestData(string sLotId, int index)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node3 = new TRSNode("VIEW_INSP_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));

                //가장 최근 검사값을 불러온다
                //MWIPELTSTS
                if (MPCF.CallService("CWIP", "CWIP_View_Fqc_Flash_List", in_node, ref out_node3) == false)
                {
                    return false;
                }

                if (out_node3.GetList(0) == null)
                {
                    return true;
                }

                spdFlashRlt.ActiveSheet.Cells[index, (int)TEST_LIST.PMPP].Value = out_node3.GetList(0)[0].GetString("PMPP");

                MPCF.FitColumnHeader(spdFlashRlt);

                //검사값이 없으면 에러 배출
                if (out_node3.GetList(0).Count == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(550), MSG_LEVEL.ERROR, false);
                    clearFieldText();
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool Tran_FQC_Input()
        {

            TRSNode in_node = new TRSNode("FQC_RESULT_IN");
            TRSNode out_node = new TRSNode("FQC_RESULT_OUT");
            string result = "", judge = "";
            int errorCode = 0;

            try
            {
                MPCF.SetInMsg(in_node);

                if (lotList == null)
                {
                    MPCF.ShowMessage("Invalid Data", MSG_LEVEL.ERROR, false);
                    return false;
                }

                if (cdvGrade.Text == "G01")
                {
                    result = "A";
                    judge = "CL510";
                }
                else if (cdvGrade.Text == "G02")
                {
                    result = "A";
                    judge = "CL511";
                }
                else if (cdvGrade.Text == "G03")         //--[G03/G04 로직 추가]
                {
                    result = "A";
                    judge = "CL520";
                }
                else if (cdvGrade.Text == "G04")         //--[G03/G04 로직 추가]
                {
                    result = "A";
                    judge = "CL530";
                }
                else if (cdvGrade.Text == "B")
                {
                    result = "B";
                    judge = "CL512";
                }
                else if (cdvGrade.Text == "C")
                {
                    result = "C";
                    judge = "CL514";
                }
                else if (cdvGrade.Text == "G06")
                {
                    result = "SC";
                    judge = "CL207";
                }
                else if (cdvGrade.Text == "RWK")
                {
                    result = "RW";
                    judge = "RWK";
                }

                for (int x = 0; x < lotList.Count; x++)
                {
                    in_node.ProcStep = '1';
                    in_node.SetString("INS_TYPE", HQGC.INSP_TYPE_FC);                   // Inspection TYPE (FC:FQC)
                    in_node.SetString("LOT_ID", MPCF.Trim(lotList[x]));                 // Module ID
                    in_node.SetString("RES_ID", MPCF.Trim(spdFlashRlt.ActiveSheet.Cells[x, (int)TEST_LIST.RES_ID].Value));            // Res ID
                    in_node.SetInt("QTY", 1);
                    in_node.SetString("INS_VALUE", MPCF.Trim(judge));                   // Inspection Value
                    in_node.SetString("RESULT_VALUE", MPCF.Trim(result));               // Result Value
                    in_node.SetString("RLT_COMMENT", MPCF.Trim(txtRemark.Text));        // FQC Remark
                    in_node.SetChar("TYPE_FLAG", '2');                                  // '1': Inspected by Equipment, '2': Inspected by Workers
                    in_node.SetString("GRADE", MPCF.Trim(cdvGrade.Text));               // Grade
                    in_node.SetString("POWER", MPCF.Trim(spdFlashRlt.ActiveSheet.Cells[x, (int)TEST_LIST.POWER].Value));               // Power
                    in_node.SetString("WORK_LINE", MPCF.Trim(spdFlashRlt.ActiveSheet.Cells[x, (int)TEST_LIST.LINE_ID].Value));          // Line
                    in_node.SetString("OPER", MPCF.Trim(HQGC.OPER_M3110));                 // Operation

                    in_node.SetString("INS_USER_ID", in_node.UserID);                   // Inspection User ID
                    in_node.SetString("RESULT_USER_ID", in_node.UserID);                // Result User ID

                    in_node.SetString("DEFECT_CODE", MPCF.Trim(cdvDefectCode.Text));             // Defect Code
                    in_node.SetString("CELL_INFO", MPCF.Trim(cdvCellLocation.Text));             // Loss Code

                    in_node.AddString("REJUDGMENT", MPCF.Trim(cdvRejudgment.Text));             // Rejudgment Code


                    bool rejudge = true;
                    if (ViewLotHisAndCheckReJudgmentGrade(lotList[x]) == false)
                    {
                        errorCode = 553;
                        rejudge = false;
                    }
                    //string eCode = validateForFQCRejudgment(lotList[x]);
                    //[GERP Project] [ERP 23.05.23] 추가 INS VALUE / POWER 추가 
                    string eCode = validateForFQCRejudgment(lotList[x], MPCF.Trim(judge), MPCF.Trim(spdFlashRlt.ActiveSheet.Cells[x, (int)TEST_LIST.POWER].Value));
                    if (eCode.Trim().StartsWith("WIP"))
                    {
                        rejudge = false;
                        return false;
                    }
                    else if (Int32.Parse(eCode) != 0)
                    {
                        errorCode = Int32.Parse(eCode);
                        rejudge = false;
                    }


                    if (rejudge)
                    {
                        if (MPCF.CallService("CWIP", "CWIP_Update_Fqc_Result", in_node, ref out_node) == false)
                        {
                            return false;
                        }

                        spdFlashRlt.ActiveSheet.RemoveRows(x, 1);
                        lotList.RemoveAt(x);
                        x--;
                    }
                }

                cdvDefectCode.Code = null;
                cdvDefectCode.Description = null;

                cdvCellLocation.Code = null;
                cdvCellLocation.Description = null;

                cdvRejudgment.Code = null;
                cdvRejudgment.Description = null;

                MPCF.ShowSuccessMessage(out_node, false);
                if (errorCode > 0) MPCF.ShowMessage(MPCF.GetMessage(errorCode), MSG_LEVEL.ERROR, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ViewLotHisAndCheckReJudgmentGrade(string sLotId)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_FQC_HIS_IN");
                TRSNode out_node = new TRSNode("VIEW_FQC_HIS_OUT");
                TRSNode out_list;
                bool reJudge = true;
                bool normalJudge = false;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));

                //FQC 판정들을 읽어온다 없으면 재판정이 아님
                //CEDCLOTRLH.INS_TYPE = FC
                if (MPCF.CallService("CWIP", "CWIP_View_Fqc_List", in_node, ref out_node) == false)
                {
                    reJudge = false;
                }
                if (reJudge)
                {
                    //기록이 없으면 판정한다
                    if (out_node.GetList(0) == null)
                    {
                        return true;
                    }

                    if ("RWK".Equals(cdvGrade.Text))
                    {
                        for (int i = 0; i < out_node.GetList(0).Count; i++)
                        {
                            out_list = out_node.GetList(0)[i];

                            string grade = out_list.GetString("GRADE");
                            ArrayList gradeArray = new ArrayList { "G01", "G02", "G03", "G04", "B", "C", "G06" }; //--[G03/G04 로직 추가]
                            if (gradeArray.IndexOf(grade) > -1)
                            {
                                normalJudge = true;
                                break;
                            }
                        }
                        // 정상 판정 이력이 있기때문에 RWK 로 재판정 할 수 없습니다
                        if (normalJudge)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private string validateForFQCRejudgment(string sLotId, string sInsValue, string sPower)
        {
            TRSNode in_node = new TRSNode("VALIDATE_FQC_IN");
            TRSNode out_node = new TRSNode("VALIDATE_FQC_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(sLotId));
            in_node.AddString("GRADE", MPCF.Trim(cdvGrade.Text));
            //[GERP Project][ERP 23.05.23]추가 
            in_node.AddString("POWER", MPCF.Trim(sPower));
            in_node.AddString("INS_VALUE", MPCF.Trim(sInsValue));
            //
            if (MPCF.CallService("CWIP", "CWIP_Validate_For_Fqc_Rejudgment", in_node, ref out_node) == false)
            {
                //return Int32.Parse(out_node.MsgCode.ToString());
                return out_node.MsgCode.ToString();
            }
            return "0";
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "PROCESS":

                        if (MPCF.CheckValue(txtLotID, false) == false)
                        {
                            return false;
                        }

                        if (spdFlashRlt.ActiveSheet.RowCount < 1)
                        {
                            MPCF.ShowMessage("No data to process. Please search Lot first.", MSG_LEVEL.ERROR, false);
                            return false;
                        }

                        if (MPCF.CheckValue(cdvGrade, false) == false)
                        {
                            return false;
                        }

                        //if (cdvGrade.Text != "G01" && cdvGrade.Text != "G02")
                        if (cdvGrade.Text != "G01")
                        {
                            if (MPCF.CheckValue(cdvDefectCode, false) == false)
                            {
                                return false;
                            }

                            if (MPCF.CheckValue(cdvCellLocation, false) == false)
                            {
                                return false;
                            }
                        }


                        //rwk가 아니면 파워값 체크
                        if (!cdvGrade.Text.Equals("RWK"))
                        {
                            string power = string.Empty;

                            for (int i = 0; i < spdFlashRlt.ActiveSheet.RowCount; i++)
                            {
                                ///* -  [ERP 23.05.23]  시작****************************************************************/
                                //if (isNewMaterialID(MPCF.Trim(spdFlashRlt.ActiveSheet.Cells[i, (int)TEST_LIST.MAT_ID].Value)) == false)
                                //{
                                    power = MPCF.Trim(spdFlashRlt.ActiveSheet.Cells[i, (int)TEST_LIST.POWER].Value);

                                    if (String.IsNullOrEmpty(power))
                                    {
                                        MPCF.ShowMessage("No Power Data. Please check power column.", MSG_LEVEL.ERROR, false);
                                        return false;
                                    }

                                //}                               

                                /* -  [ERP 23.05.23]  끝*****************************************************************/
                            }

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

        private bool isNewMaterialID(String matId)
        {
            double result;

            if (matId.Length > 0 &&
                double.TryParse(matId.TrimStart('0'), out result) == false)
            {

                return true;
            }

            return false;
        }

        private bool CheckArticle()
        {

            if (lotList == null)
            {
                MPCF.ShowMessage("Invalid Data", MSG_LEVEL.ERROR, false);
                return false;
            }

            for (int x = 0; x < lotList.Count; x++)
            {
                TRSNode tran_in_node_pr = new TRSNode("VIEW_POWER_RANGE_IN");
                TRSNode tran_out_node_pr = new TRSNode("VIEW_POWER_RANGE_OUT");

                MPCF.SetInMsg(tran_in_node_pr);
                tran_in_node_pr.ProcStep = '3';
                tran_in_node_pr.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_POWER_RANGE));
                tran_in_node_pr.AddString("KEY_1", MPCF.Trim(spdFlashRlt.ActiveSheet.Cells[x, (int)TEST_LIST.MAT_ID].Value));
                tran_in_node_pr.AddString("KEY_2", MPCF.Trim(cdvGrade.Text));
                tran_in_node_pr.AddString("DATA_2", MPCF.Trim(spdFlashRlt.ActiveSheet.Cells[x, (int)TEST_LIST.PMPP].Value));

                // @POWER_RANGE 정보가 없으면 오류 처리
                if (MPCF.CallService("CBAS", "CBAS_view_Module_grade_list", tran_in_node_pr, ref tran_out_node_pr) == false)
                {
                    cdvGrade.Text = "";
                    MPCF.ShowMessage(MPCF.GetMessage(522), MSG_LEVEL.ERROR, false);
                    return false;
                }

                // @POWER_RANGE 정보가 없으면 오류 처리
                if (tran_out_node_pr.GetString("DATA_1") == "")
                {
                    cdvGrade.Text = "";
                    MPCF.ShowMessage(MPCF.GetMessage(522), MSG_LEVEL.ERROR, false);
                    return false;
                }
                // ARTICLE 관리종료 반영 운영에서만 활성화( 2023/03/23 by KBC)
                if (isNewMaterialID(MPCF.Trim(spdFlashRlt.ActiveSheet.Cells[x, (int)TEST_LIST.MAT_ID].Value)) == false)
                {
                    // RWK가 아니면 ARTICLE 정보 체크 로직 추가 (2019.07.12 sy7.kwon)
                    TRSNode tran_in_node = new TRSNode("VIEW_ARTICLE_IN");
                    TRSNode tran_out_node = new TRSNode("VIEW_ARTICLE_OUT");
                    string power = tran_out_node_pr.GetString("DATA_1");
                    MPCF.SetInMsg(tran_in_node);
                    tran_in_node.ProcStep = '1';
                    tran_in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_ARTICLE));
                    tran_in_node.AddString("KEY_1", MPCF.Trim(spdFlashRlt.ActiveSheet.Cells[x, (int)TEST_LIST.MAT_ID].Value));
                    tran_in_node.AddString("DATA_1", power);
                    tran_in_node.AddString("DATA_2", MPCF.Trim(cdvGrade.Text));

                    // @ARTICLE 정보가 없으면 오류 처리
                    if (MPCF.CallService("CBAS", "CBAS_view_article_list", tran_in_node, ref tran_out_node) == false)
                    {
                        cdvGrade.Text = "";
                        MPCF.ShowMessage(MPCF.GetMessage(528), MSG_LEVEL.ERROR, false);
                        return false;
                    }

                    // @ARTICLE 정보가 없으면 오류 처리
                    if (tran_out_node.GetString("KEY_1") == "")
                    {
                        cdvGrade.Text = "";
                        MPCF.ShowMessage(MPCF.GetMessage(528), MSG_LEVEL.ERROR, false);
                        return false;
                    }
                    // @POWER_RANGE에서 가져온 파워값을 입력
                    spdFlashRlt.ActiveSheet.Cells[x, (int)TEST_LIST.POWER].Value = power;
                }
                else
                {
                    string power = tran_out_node_pr.GetString("DATA_1");
                    spdFlashRlt.ActiveSheet.Cells[x, (int)TEST_LIST.POWER].Value = power;
                }

            }

            return true;
        }


        #endregion

        private void cdvDefectCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Required Value
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                if (lotList == null)
                {
                    MPCF.ShowMsgBox("Please Check Module Id");
                    txtLotID.Focus();

                    return;
                }



                TRSNode in_node = new TRSNode("VIEW_LOSS_IN");
                TRSNode out_node = new TRSNode("VIEW_LOSS_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '4';

                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_DEFECT));
                in_node.AddString("KEY_2", MPCF.Trim("M3110"));
                in_node.AddString("KEY_1", "E90");

                // CodeView Column Header Setup
                string[] header = new string[] { "Defect Code", "Defect Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_4" };

                // Show
                cdvDefectCode.Text = cdvDefectCode.Show(cdvDefectCode, "Defect Code", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_1");


                // Validation
                if (string.IsNullOrEmpty(cdvDefectCode.Text) == true)
                {
                    MPCF.SetFocus(cdvDefectCode);
                    return;
                }

                // Focus
                MPCF.SetFocus(cdvDefectCode);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvCellLocation_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {



                DialogResult drResult;

                frmCWIPCellLocationPopup f = new frmCWIPCellLocationPopup(cdvCellLocation.Text, str_cell_qty);
                f.Owner = MPGV.gfrmMDI;
                drResult = f.ShowDialog();

                // 아이템을 선택한 경우
                if (drResult == DialogResult.OK)
                {
                    cdvCellLocation.Text = f.ReturnValue;
                    //SetValidationOff();
                }
                if (drResult == DialogResult.No)
                {
                    cdvCellLocation.Text = f.ReturnValue;
                    //SetValidationOff();
                }
                else
                {
                    // 아무것도 하지 않음
                }
            }
            catch (Exception ex) 
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void clearFieldText()
        {
            /*
            txtLotID.Text = "";
            cdvEquipID.Text = "";
            txtJudge.Text = "";
            txtResult.Text = "";
            txtRemark.Text = "";
            cdvGrade.Text = "";
            txtPower.Text = "";
            cdvLineID.Text = "";
            cdvOper.Text = "";
            cdvDefectCode.Text = "";
            cdvCellLocation.Text = "";
            */
        }

        private void cdvDefectCode_Load(object sender, EventArgs e)
        {

        }

        private void cdvRejudgment_CodeViewButtonClick(object sender, EventArgs e)
        {

            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_REJUDGMENT));

                string[] header = new string[] { "Code", "Name" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvRejudgment.Text = cdvRejudgment.Show(cdvRejudgment, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                if (string.IsNullOrEmpty(cdvGrade.Text) == true)
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
    }
}