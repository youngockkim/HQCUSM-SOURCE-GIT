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
    public partial class frmCUSModuleFQCResult : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private TRSNode nodeLotInfo;

        private bool reJudge = true;
        private string origPower = "";

        #endregion

        #region Constructor

        public frmCUSModuleFQCResult()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        public enum HIS_LIST
        {
            INS_CNT,
            RES_ID,
            INS_TIME,
            INS_VALUE,
            RESULT_TIME,
            RESULT_VALUE,
            DEFECT_CODE,
            CELL_LOCATION,
            GRADE,
            REJUDGMENT,
            POWER,
            ARTICLE_NO,
            COLOR_CLASS
        }

        public enum TEST_LIST
        {
            LOT_ID,
            VOC,
            ISC,
            VMPP,
            IMPP,
            FF,
            EFF,
            PMPP,
            DIODE
        }
        public string str_cell;

        #endregion


        #region Event Handler

        private void frmCUSModuleFQCResult_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            MPCF.ConvertCaption(this);

            // Fix Operation
            cdvOper.Text = HQGC.OPER_M3110; // FQC
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

        private void cdvLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // New Version
                TRSNode in_node = new TRSNode("VIEW_LINE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvLineID.Text = cdvLineID.Show(cdvLineID, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Old Version
                /*
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "@LINE_CODE");
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Line", "Line Desc" };
                cdvLineID.Text = cdvLineID.Show(cdvLineID, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Line");
                */

                // Validation
                if (string.IsNullOrEmpty(cdvLineID.Text) == true)
                {
                    return;
                }

                // Clear Equipment
                MPCF.FieldClear(cdvEquipID);

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvOperID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));

                string[] header = new string[] { "Oper", "Description" };
                string[] display = new string[] { "OPER", "OPER_DESC" };

                cdvOper.Text = cdvOper.Show(cdvOper, "View Operation List", "CWIP", "CWIP_View_Operation_List", in_node, "LIST", display, header, "OPER");

                if (cdvOper.Text == null || cdvOper.Text == string.Empty)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvEquipID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", cdvLineID.Text);
                in_node.AddString("OPER", cdvOper.Text);

                // Display and Header Text Setup
                string[] header = new string[] { "Equip ID", "Equip Desc" };
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                // Show CodeView and Get Return
                cdvEquipID.Text = cdvEquipID.Show(cdvEquipID, "View Resource List", "CRAS", "CRAS_View_Resource_List_By_Line", in_node, "RES_LIST", display, header, "RES_ID");

                // Validation
                if (string.IsNullOrEmpty(cdvEquipID.Text) == true)
                {
                    MPCF.SetFocus(cdvEquipID);
                    return;
                }

                // Focus
                MPCF.SetFocus(txtLotID);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        //등급 변경시
        private void cdvGrade_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                bool bEnable = true;
                String strGrade = cdvGrade.Text;
                String strPower = txtPower.Text;

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

                //RWK이 아닌경우 @POWER_RANGE와 @ARTICLE을 확인하고 없는경우 기존데이터로 복구한다
                if (cdvGrade.Text != "RWK" && !CheckArticle())
                {
                    cdvGrade.Text = strGrade;
                    txtPower.Text = strPower;
                    return;
                }

                if (cdvGrade.Text == "G01")
                {
                    txtResult.Text = "A";
                    txtJudge.Text = "CL510";
                    bEnable = false;
                }
                else if (cdvGrade.Text == "G02")
                {
                    txtResult.Text = "A";
                    txtJudge.Text = "CL511";
                    //bEnable = false;
                    //IS-20-09-050 FQC Judgement (MES OI) logic change request 
                    //존 요청으로 G02여도 Defect, Cell location 등록 가능하도록 변경함
                }
                else if (cdvGrade.Text == "G03")        //--[G03/G04 로직 추가]
                {
                    txtResult.Text = "A";
                    txtJudge.Text = "CL520";
                    //bEnable = false;
                }
                else if (cdvGrade.Text == "G04")        //--[G03/G04 로직 추가]
                {
                    txtResult.Text = "A";
                    txtJudge.Text = "CL530";
                    //bEnable = false;
                }
                else if (cdvGrade.Text == "B")
                {
                    txtResult.Text = "B";
                    txtJudge.Text = "CL512";
                    bEnable = true;
                }
                else if (cdvGrade.Text == "C")
                {
                    txtResult.Text = "C";
                    txtJudge.Text = "CL514";
                    bEnable = true;
                }
                else if (cdvGrade.Text == "G06")
                {
                    txtResult.Text = "SC";
                    txtJudge.Text = "CL207";
                    bEnable = true;
                }
                else if (cdvGrade.Text == "RWK")
                {
                    txtResult.Text = "RW";
                    txtJudge.Text = "RWK";
                    bEnable = true;
                }

                this.cdvDefectCode.Enabled = bEnable;
                this.cdvCellLocation.Enabled = bEnable;
                if (!bEnable)
                {
                    this.cdvDefectCode.Text = "";
                    this.cdvDefectCode.Description = "";
                    this.cdvCellLocation.Text = "";
                    this.cdvCellLocation.Description = "";
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

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                InitViews();
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCondition("PROCESS"))
                {
                    return;
                }

                if (checkReJudgmentGrade() == false)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(553), MSG_LEVEL.ERROR, false);
                    return;
                }
                string code = validateForFQCRejudgment();

                if (code.Trim().StartsWith("WIP"))
                {
                    return;
                }
                else if (Int32.Parse(code) != 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(Int32.Parse(code)), MSG_LEVEL.ERROR, false);
                    return;
                }

                if (MPCF.ShowMsgBox(MPCF.GetMessage(539), MessageBoxButtons.YesNo, MSG_LEVEL.WARNING) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                if (Tran_FQC_Input())
                {
                    ViewLot(txtLotID.Text);
                    ViewLotHis(txtLotID.Text);
                    ViewTestData(txtLotID.Text);
                }

                txtLotID.Focus();
                txtLotID.SelectAll();
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
            reJudge = true;
            origPower = "";
            try
            {
                // Lot ID Check
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                // View Lot
                if (ViewLot(txtLotID.Text) == false)
                {
                    txtLotID.SelectAll();
                    return;
                }

                if (ViewLotHis(txtLotID.Text) == false)
                {
                    txtLotID.SelectAll();
                    return;
                }

                if (ViewTestData(txtLotID.Text) == false)
                {
                    txtLotID.SelectAll();
                    return;
                }

                //등급이 비어있거나 (첫판정) RWK인경우는 제외하고 @POWER_RANGE와 @ARTICLE을 확인한다
                if (!cdvGrade.Text.Equals("") && !cdvGrade.Text.Equals("RWK") && !CheckArticle())
                {
                    txtLotID.SelectAll();
                    return;
                }

                txtLotID.Focus();
                txtLotID.SelectAll();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private bool ViewLot(string sLotId)
        {
            TRSNode in_node = new TRSNode("VIEW_FQC_IN");
            TRSNode out_node = new TRSNode("VIEW_FQC_OUT");

            try
            {
                // FieldClear
                MPCF.ClearList(spdFlashRlt);
                MPCF.ClearList(spdFqcList);
                MPCF.FieldClear(pnlMiddleMargin, txtLotID);
                str_cell = "";

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INS_TYPE", HQGC.INSP_TYPE_FC);
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));
                in_node.AddChar("RE_JUDGE_FLAG", 'Y');  // 재판정 OI에서만 사용

                //마지막 FQC 판정을 읽어온다 없으면 재판정이 아님
                //CEDCLOTRLT.INS_TYPE = FC
                if (MPCF.CallService("CWIP", "CWIP_View_Fqc_Result", in_node, ref out_node) == false)
                {
                    if (out_node.MsgCode == "WIP-0616")
                    {
                        // WIP-0616 
                    }
                    else
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(154), MSG_LEVEL.ERROR, false);
                    }
                    return false;
                }

                reJudge = out_node.GetString("RE_JUDGE").Equals("Y");

                // 재판정임에도 LOT 정보 없으면 모든 필드 초기화
                if (reJudge && out_node.GetString("RES_ID") == "")
                {
                    MPCF.ShowMessage(MPCF.GetMessage(154), MSG_LEVEL.ERROR, false);
                    return false;
                }

                nodeLotInfo = out_node;

                str_cell = out_node.GetString("MAT_CMF_3");


                //재판정인 경우 out_node에서 결과값을 가져온다
                if (reJudge)
                {
                    cdvLineID.Text = out_node.GetString("LINE_ID");
                    cdvOper.Text = out_node.GetString("OPER");
                    cdvEquipID.Text = out_node.GetString("RES_ID");

                    cdvGrade.Text = out_node.GetString("GRADE");
                    cdvGrade.Description = string.Empty;

                    txtResult.Text = out_node.GetString("RESULT_VALUE");
                    txtJudge.Text = out_node.GetString("INS_VALUE");
                    txtRemark.Text = out_node.GetString("RLT_COMMENT");
                    txtMatID.Text = out_node.GetString("MAT_ID");


                    //if (cdvGrade.Text == "G01" || cdvGrade.Text == "G02") //IS-20-09-050 FQC Judgement (MES OI) logic change request 
                    //존 요청으로 G02여도 Defect, Cell location 등록 가능하도록 변경함
                    if (cdvGrade.Text == "G01")
                    {
                        this.cdvDefectCode.Enabled = false;
                        this.cdvCellLocation.Enabled = false;
                    }
                    else
                    {
                        this.cdvDefectCode.Enabled = true;
                        this.cdvCellLocation.Enabled = true;
                    }
                }
                //재판정이 아니면 라인, 공정, 설비 이름 생성
                else
                {
                    int line_cd;
                    line_cd = int.Parse(MPCF.Trim(txtLotID.Text).Substring(2, 1));

                    cdvLineID.Text = "MDL0" + MPCF.Trim(txtLotID.Text).Substring(2, 1);
                    cdvOper.Text = "M3110";
                    
                    if ( line_cd <= 3 ) 
                    {
                        cdvEquipID.Text = "US-E" + line_cd + "-FQC-02";
                    } else {
                        cdvEquipID.Text = "US-E" + line_cd + "-FQC-03";
                    }
                    txtMatID.Text = out_node.GetString("MAT_ID");
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool ViewLotHis(string sLotId)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_FQC_HIS_IN");
                TRSNode out_node = new TRSNode("VIEW_FQC_HIS_OUT");
                TRSNode out_list;

                MPCF.ClearList(spdFqcList);

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
                    //기록이 없으면 스킵한다
                    if (out_node.GetList(0) == null)
                    {
                        return true;
                    }

                    spdFqcList.ActiveSheet.RowCount = 0;

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        out_list = out_node.GetList(0)[i];
                        spdFqcList.ActiveSheet.RowCount++;

                        spdFqcList.ActiveSheet.Cells[i, (int)HIS_LIST.INS_CNT].Value = out_list.GetInt("INS_CNT");
                        spdFqcList.ActiveSheet.Cells[i, (int)HIS_LIST.RES_ID].Value = out_list.GetString("RES_ID");
                        spdFqcList.ActiveSheet.Cells[i, (int)HIS_LIST.INS_TIME].Value = MPCF.MakeDateFormat(out_list.GetString("INS_TIME"));
                        spdFqcList.ActiveSheet.Cells[i, (int)HIS_LIST.INS_VALUE].Value = out_list.GetString("INS_VALUE");
                        spdFqcList.ActiveSheet.Cells[i, (int)HIS_LIST.RESULT_TIME].Value = MPCF.MakeDateFormat(out_list.GetString("RESULT_TIME"));
                        spdFqcList.ActiveSheet.Cells[i, (int)HIS_LIST.RESULT_VALUE].Value = out_list.GetString("RESULT_VALUE");
                        spdFqcList.ActiveSheet.Cells[i, (int)HIS_LIST.DEFECT_CODE].Value = out_list.GetString("DEFECT_CODE");
                        spdFqcList.ActiveSheet.Cells[i, (int)HIS_LIST.CELL_LOCATION].Value = out_list.GetString("CELL_INFO");
                        spdFqcList.ActiveSheet.Cells[i, (int)HIS_LIST.GRADE].Value = out_list.GetString("GRADE");
                        spdFqcList.ActiveSheet.Cells[i, (int)HIS_LIST.REJUDGMENT].Value = out_list.GetString("REJUDGMENT");
                        spdFqcList.ActiveSheet.Cells[i, (int)HIS_LIST.POWER].Value = out_list.GetString("POWER");
                        spdFqcList.ActiveSheet.Cells[i, (int)HIS_LIST.ARTICLE_NO].Value = out_list.GetString("ARTICLE_NO");
                        spdFqcList.ActiveSheet.Cells[i, (int)HIS_LIST.COLOR_CLASS].Value = out_list.GetString("COLOR_CLASS");
                    }

                    MPCF.FitColumnHeader(spdFqcList);
                    // ARTICLE 관리종료에 따른 영향도 조사후 반영 구 자재코드에서만 활성화( 2023/03/23 by KBC)
                    if (isNewMaterialID() == true)
                    {
                        this.spdFqcList_Sheet1.Columns[11].Width = 0;
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

        private bool ViewTestData(string sLotId)
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

                for (int i = 0; i < out_node3.GetList(0).Count; i++)
                {
                    spdFlashRlt.ActiveSheet.AddRows(0, 1);
                    spdFlashRlt.ActiveSheet.Cells[0, (int)TEST_LIST.LOT_ID].Value = out_node3.GetList(0)[i].GetString("LOT_ID");
                    spdFlashRlt.ActiveSheet.Cells[0, (int)TEST_LIST.VOC].Value = out_node3.GetList(0)[i].GetString("VOC");
                    spdFlashRlt.ActiveSheet.Cells[0, (int)TEST_LIST.ISC].Value = out_node3.GetList(0)[i].GetString("ISC");
                    spdFlashRlt.ActiveSheet.Cells[0, (int)TEST_LIST.VMPP].Value = out_node3.GetList(0)[i].GetString("VMPP");
                    spdFlashRlt.ActiveSheet.Cells[0, (int)TEST_LIST.IMPP].Value = out_node3.GetList(0)[i].GetString("IMPP");
                    spdFlashRlt.ActiveSheet.Cells[0, (int)TEST_LIST.FF].Value = out_node3.GetList(0)[i].GetString("FF");
                    spdFlashRlt.ActiveSheet.Cells[0, (int)TEST_LIST.EFF].Value = out_node3.GetList(0)[i].GetString("EFF");
                    spdFlashRlt.ActiveSheet.Cells[0, (int)TEST_LIST.PMPP].Value = out_node3.GetList(0)[i].GetString("PMPP");
                    spdFlashRlt.ActiveSheet.Cells[0, (int)TEST_LIST.DIODE].Value = out_node3.GetList(0)[i].GetString("ESC");
                    origPower = out_node3.GetList(0)[i].GetString("PMPP");
                }

                MPCF.FitColumnHeader(spdFlashRlt);

                //검사값이 없으면 에러 배출
                if (out_node3.GetList(0).Count == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(550), MSG_LEVEL.ERROR, false);
                    clearFieldText();
                    return false;
                }
                //파워값을 입력한다
                txtPower.Text = origPower;

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        // FQC판정시 특정모듈이 1회 이상 G01,G02,B,C,G06 판정이 난 이력이 있는경우 Rework 판정할수 없도록 수정
        private bool checkReJudgmentGrade()
        {
            Resources dSrc = (Resources)spdFlashRlt.ActiveSheet.DataSource;
            bool normalJudge = false;

            if ("RWK".Equals(cdvGrade.Text))
            {
                for (int i = 0; i < spdFqcList.ActiveSheet.RowCount; i++)
                {
                    string grade = spdFqcList.ActiveSheet.GetText(i, 7);
                    ArrayList gradeArray = new ArrayList { "G01", "G02", "G03", "G04", "B", "C", "G06" };     ///--[G03/G04 로직 추가]
                    if (gradeArray.IndexOf(grade) > -1)
                    {
                        normalJudge = true;
                        break;
                    }
                }
                // 정상판정 이력이 있기때문에 RWK 로 재판정 할 수 없습니다
                if (normalJudge)
                {
                    return false;
                }
            }

            return true;
        }

        private string validateForFQCRejudgment()
        {
            TRSNode in_node = new TRSNode("VALIDATE_FQC_IN");
            TRSNode out_node = new TRSNode("VALIDATE_FQC_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
            in_node.AddString("GRADE", MPCF.Trim(cdvGrade.Text));

            /* - [GERP PROJECT] 시작****************************************************************/
            in_node.AddString("INS_VALUE", MPCF.Trim(txtJudge.Text));           // Inspection Value
            in_node.AddString("POWER", MPCF.Trim(txtPower.Text));               // Power
            /* - [GERP PROJECT] 끝*****************************************************************/

            if (MPCF.CallService("CWIP", "CWIP_Validate_For_Fqc_Rejudgment", in_node, ref out_node) == false)
            {
                ///item.Trim().StartsWith("<")
                // if(out_node.MsgCode.ToString().Trim().StartsWith("WIP"){

                // return Int32.Parse(out_node.MsgCode.ToString());
                return out_node.MsgCode.ToString();
            }
            return "0";
        }

        private bool Tran_FQC_Input()
        {

            TRSNode in_node = new TRSNode("FQC_RESULT_IN");
            TRSNode out_node = new TRSNode("FQC_RESULT_OUT");

            int iInsCnt;

            try
            {
                MPCF.SetInMsg(in_node);

                //if (nodeLotInfo.GetList(0) == null)
                if (nodeLotInfo == null)
                {
                    iInsCnt = 0;
                }
                else
                {
                    iInsCnt = nodeLotInfo.GetInt("INS_CNT");
                }

                in_node.ProcStep = '1';
                in_node.AddString("INS_TYPE", HQGC.INSP_TYPE_FC);                   // Inspection TYPE (FC:FQC)
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));              // Module ID
                in_node.AddString("RES_ID", MPCF.Trim(cdvEquipID.Text));            // Res ID
                in_node.AddInt("QTY", 1);
                //in_node.AddInt("INS_CNT", iInsCnt);                                 
                in_node.AddString("INS_VALUE", MPCF.Trim(txtJudge.Text));           // Inspection Value
                in_node.AddString("RESULT_VALUE", MPCF.Trim(txtResult.Text));       // Result Value
                in_node.AddString("RLT_COMMENT", MPCF.Trim(txtRemark.Text));         // FQC Remark
                in_node.AddChar("TYPE_FLAG", '2');                                  // '1': Inspected by Equipment, '2': Inspected by Workers
                in_node.AddString("GRADE", MPCF.Trim(cdvGrade.Text));               // Grade
                in_node.AddString("POWER", MPCF.Trim(txtPower.Text));               // Power
                //in_node.AddString("WORK_SHIFT", MPCF.Trim(cdvShiftID.Text));      // Shift 
                in_node.AddString("WORK_LINE", MPCF.Trim(cdvLineID.Text));          // Line
                in_node.AddString("OPER", MPCF.Trim(cdvOper.Text));                 // Operation

                in_node.AddString("INS_USER_ID", in_node.UserID);                   // Inspection User ID
                in_node.AddString("RESULT_USER_ID", in_node.UserID);                // Result User ID

                in_node.AddString("DEFECT_CODE", MPCF.Trim(cdvDefectCode.Text));            // Defect Code
                in_node.AddString("CELL_INFO", MPCF.Trim(cdvCellLocation.Text));             // Loss Code

                in_node.AddString("REJUDGMENT", MPCF.Trim(cdvRejudgment.Text));             // Rejudgment Code

                //in_node.AddString("OSC", MPCF.Trim(txtOSC.Text));        
                //in_node.AddString("ESC", MPCF.Trim(txtESC.Text));        
                //in_node.AddString("EL", MPCF.Trim(txtlEL.Text));        

                if (MPCF.CallService("CWIP", "CWIP_Update_Fqc_Result", in_node, ref out_node) == false)
                {
                    return false;
                }

                cdvDefectCode.Code = null;
                cdvDefectCode.Description = null;

                cdvCellLocation.Code = null;
                cdvCellLocation.Description = null;

                cdvRejudgment.Code = null;
                cdvRejudgment.Description = null;

                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "PROCESS":

                        if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvOper, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvEquipID, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(txtLotID, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(txtResult, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvGrade, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(txtPower, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(txtJudge, false) == false)
                        {
                            return false;
                        }

                        if (cdvGrade.Text != "G01" && cdvGrade.Text != "G02" && cdvGrade.Text != "G03" && cdvGrade.Text != "G04")   //--[G03/G04 로직 추가]
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

        private bool CheckArticle()
        {
            TRSNode tran_in_node_pr = new TRSNode("VIEW_POWER_RANGE_IN");
            TRSNode tran_out_node_pr = new TRSNode("VIEW_POWER_RANGE_OUT");

            MPCF.SetInMsg(tran_in_node_pr);
            tran_in_node_pr.ProcStep = '3';
            tran_in_node_pr.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_POWER_RANGE));
            tran_in_node_pr.AddString("KEY_1", MPCF.Trim(txtMatID.Text));
            tran_in_node_pr.AddString("KEY_2", MPCF.Trim(cdvGrade.Text));
            tran_in_node_pr.AddString("DATA_2", MPCF.Trim(txtPower.Text));

            // @POWER_RANGE 정보가 없으면 오류 처리
            if (MPCF.CallService("CBAS", "CBAS_view_Module_grade_list", tran_in_node_pr, ref tran_out_node_pr) == false)
            {
                cdvGrade.Text = "";
                MPCF.ShowMessage(MPCF.GetMessage(522), MSG_LEVEL.ERROR, true);
                return false;
            }

            // @POWER_RANGE 정보가 없으면 오류 처리
            if (tran_out_node_pr.GetString("DATA_1") == "")
            {
                cdvGrade.Text = "";
                MPCF.ShowMessage(MPCF.GetMessage(522), MSG_LEVEL.ERROR, true);
                return false;
            }

            // @POWER_RANGE에서 가져온 파워값을 입력
            txtPower.Text = tran_out_node_pr.GetString("DATA_1");

            // RWK가 아니면 ARTICLE 정보 체크 로직 추가 (2019.07.12 sy7.kwon)
            // ARTICLE 관리종료에 따른 영향도 사후 반영 신규 제품코드에서만 활성화( 2023/03/23 by KBC)
            if (isNewMaterialID() == false)
            {

                TRSNode tran_in_node = new TRSNode("VIEW_ARTICLE_IN");
                TRSNode tran_out_node = new TRSNode("VIEW_ARTICLE_OUT");

                MPCF.SetInMsg(tran_in_node);
                tran_in_node.ProcStep = '1';
                tran_in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_ARTICLE));
                tran_in_node.AddString("KEY_1", MPCF.Trim(txtMatID.Text));
                tran_in_node.AddString("DATA_1", MPCF.Trim(txtPower.Text));
                tran_in_node.AddString("DATA_2", MPCF.Trim(cdvGrade.Text));

                // @ARTICLE 정보가 없으면 오류 처리
                if (MPCF.CallService("CBAS", "CBAS_view_article_list", tran_in_node, ref tran_out_node) == false)
                {
                    cdvGrade.Text = "";
                    MPCF.ShowMessage(MPCF.GetMessage(528), MSG_LEVEL.ERROR, true);
                    return false;
                }

                // @ARTICLE 정보가 없으면 오류 처리
                if (tran_out_node.GetString("KEY_1") == "")
                {
                    cdvGrade.Text = "";
                    MPCF.ShowMessage(MPCF.GetMessage(528), MSG_LEVEL.ERROR, true);
                    return false;
                }
            }

            return true;
        }


        #endregion

        private void cdvGrade_Load(object sender, EventArgs e)
        {

        }

        private void cdvDefect_Load(object sender, EventArgs e)
        {

        }

        private void cdvDefectCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Required Value
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_LOSS_IN");
                TRSNode out_node = new TRSNode("VIEW_LOSS_OUT");

                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '4';

                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_DEFECT));
                in_node.AddString("KEY_2", "M3110");
                in_node.AddString("KEY_1", "E90");

                // CodeView Column Header Setup
                string[] header = new string[] { "Defect Code", "Defect Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_4" };

                // Show

                cdvDefectCode.Text = cdvDefectCode.Show(cdvDefectCode, "Defect Code", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_1");

                if (MPCF.Trim(cdvDefectCode.Text) != "")
                {
                    if (cdvDefectCode.returnDatas.Count > 0)
                    {
                        cdvDefectCode.Tag = cdvDefectCode.returnDatas[1];
                    }

                }

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

                frmCWIPCellLocationPopup f = new frmCWIPCellLocationPopup(cdvCellLocation.Text, str_cell);
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
        
        private bool isNewMaterialID()
        {
            double result;

            if (txtMatID.Value.ToString().Length > 0 &&
                double.TryParse(txtMatID.Value.ToString().TrimStart('0'), out result) == false)
            {

                return true;
            }

            return false;
        }

        private void clearFieldText()
        {
            txtLotID.Text = "";
            /*
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

        private void txtLotID_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cdvCellLocation_Load(object sender, EventArgs e)
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