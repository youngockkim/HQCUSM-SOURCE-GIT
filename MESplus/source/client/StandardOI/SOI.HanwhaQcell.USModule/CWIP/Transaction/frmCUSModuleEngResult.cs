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
    public partial class frmCUSModuleEngResult : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private TRSNode nodeLotInfo;

        private bool reJudge = true;
        private string origPower = "";

        #endregion
        
        public string str_cell;


        #region Constructor

        public frmCUSModuleEngResult()
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
            GRADE,
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

        #endregion


        #region Event Handler

        private void frmCUSModuleEngResult_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            MPCF.ConvertCaption(this);

            // Fix Operation
 
        }

        private void frmCUSModuleEngResult_Shown(object sender, EventArgs e)
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

                // Check Required Value
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                cdvGrade.Text = "";
                cdvGrade.Description = "";

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

                if (cdvGrade.Text == "G01")
                {
                    bEnable = false;
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
                               
                if (Tran_FQC_Input())
                {
                    ViewLot(txtLotID.Text);
                    ViewLotHis(txtLotID.Text);
                    ViewTestData(txtLotID.Text);
                    txtLotID.Focus();
                    txtLotID.SelectAll();
                }

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

                if (string.IsNullOrEmpty(txtLotID.Text) == true)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(561), MSG_LEVEL.ERROR, true);
                    return ;
                }
                
                clearFieldTextall();        //필드 클리어
                //// 0.FQC Lot
                if (ViewFQCLot(txtLotID.Text) == false)
                {
                    txtLotID.Focus();
                    txtLotID.SelectAll();
                    return ;
                }

                //// 1.View Lot
                if (ViewLot(txtLotID.Text) == false)
                {
                    txtLotID.SelectAll();
                    return;
                }
                //2.히스토리 조회
                if (ViewLotHis(txtLotID.Text) == false)
                {
                    txtLotID.SelectAll();
                    return;
                }
                //3.테스트 데이터
                if (ViewTestData(txtLotID.Text) == false)
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

        private bool ViewFQCLot(string sLotId)
        {
           
            try
            {
                TRSNode in_node = new TRSNode("VIEW_FQC_IN");
                TRSNode out_node = new TRSNode("VIEW_FQC_OUT");
                str_cell = "";

              
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INS_TYPE", HQGC.INSP_TYPE_FC);
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));
                in_node.AddChar("RE_JUDGE_FLAG", 'Y');

                if (MPCF.CallService("CWIP", "CWIP_View_Fqc_Result", in_node, ref out_node) == false)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(154), MSG_LEVEL.ERROR, false);
                    return false;
                }

                nodeLotInfo = out_node;

                str_cell = out_node.GetString("MAT_CMF_3"); 


            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;


        }

        private bool ViewLot(string sLotId)
        {
            TRSNode in_node = new TRSNode("CWIP_VIEW_OQC_TECHNICIAN");
            TRSNode out_node = new TRSNode("CWIP_VIEW_OQC_TECHNICIAN");

            try
            {              

                //clearFieldTextall();        //필드 클리어

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));
                in_node.AddString("INS_TYPE", "TEC");

                MPCF.CallService("CWIP", "CWIP_View_Oqc_Technician", in_node, ref out_node);

                nodeLotInfo = out_node;
                txtGrade.Text = out_node.GetString("GRADE");
                txtDefect.Text = out_node.GetString("DEFECT_CODE");
                txtCellInfo.Text = out_node.GetString("CELL_INFO");
                txtOQCremark.Text = out_node.GetString("REMARK");
                //txtworker.Text = out_node.GetString("INS_USER_ID");
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
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

        private bool ViewLotHis(string sLotId)
        {
            bool bFoundNewMaterialID = false;

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
                        spdFqcList.ActiveSheet.Cells[i, (int)HIS_LIST.GRADE].Value = out_list.GetString("GRADE");
                        spdFqcList.ActiveSheet.Cells[i, (int)HIS_LIST.POWER].Value = out_list.GetString("POWER");
                        spdFqcList.ActiveSheet.Cells[i, (int)HIS_LIST.ARTICLE_NO].Value = out_list.GetString("ARTICLE_NO");
                        spdFqcList.ActiveSheet.Cells[i, (int)HIS_LIST.COLOR_CLASS].Value = out_list.GetString("COLOR_CLASS");

                        //가장 최근의 자재코드를 기준으로 article code 보여주는 부분 결정
                        if (isNewMaterialID(out_list.GetString("MAT_ID")) == true) 
                        {
                            bFoundNewMaterialID = true;
                        }
                    }

                    MPCF.FitColumnHeader(spdFqcList);

                    if (bFoundNewMaterialID)
                    {
                        spdFqcList_Sheet1.Columns[(int)HIS_LIST.ARTICLE_NO].Width = 0;
                    }
                    else
                    {
                        spdFqcList_Sheet1.Columns[(int)HIS_LIST.ARTICLE_NO].Width = 120;
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
                    ArrayList gradeArray = new ArrayList { "G01", "G02", "B", "C", "G06" };
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
            //
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

            try
            {

                if (string.IsNullOrEmpty(cdvGrade.Text) == true)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(562), MSG_LEVEL.ERROR, true);
                    cdvGrade.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtworker.Text) == true)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(560), MSG_LEVEL.ERROR, true);
                    txtworker.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtLotID.Text) == true)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(561), MSG_LEVEL.ERROR, true);
                    txtLotID.Focus();
                    return false;
                }

                if(cdvGrade.Text != "G01")
                {
                    if (string.IsNullOrEmpty(cdvDefectCode.Text) == true)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(563), MSG_LEVEL.ERROR, true);
                        cdvDefectCode.Focus();
                        return false;

                    }

                    if (string.IsNullOrEmpty(cdvCellLocation.Text) == true)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(564), MSG_LEVEL.ERROR, true);
                        cdvCellLocation.Focus();
                        return false;

                    }
                }


                if (string.IsNullOrEmpty(txtremark.Text) == true)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(565), MSG_LEVEL.ERROR, true);
                    txtremark.Focus();
                    return false;
                }


                if (ViewFQCLot(txtLotID.Text) == false)
                {
                    txtLotID.Focus();
                    txtLotID.SelectAll();
                    return false;
                }


                TRSNode in_node = new TRSNode("CWIP_UPDATE_OQC_TECHNICIAN");
                TRSNode out_node = new TRSNode("CWIP_UPDATE_OQC_TECHNICIAN");
                MPCF.SetInMsg(in_node);
                in_node.AddString("LOT_ID", txtLotID.Text);
                in_node.AddString("INS_TYPE", "ENG");
                in_node.AddString("INS_USER_ID", txtworker.Text);
                in_node.AddString("GRADE", cdvGrade.Text);
                in_node.AddString("DEFECT_CODE", cdvDefectCode.Text);
                in_node.AddString("CELL_INFO", cdvCellLocation.Text);
                in_node.AddString("REMARK", txtremark.Text);
                in_node.AddString("CREATE_USER_ID", MPCF.Trim(MPGV.gsUserID));

                if (MPCF.CallService("CWIP", "CWIP_Update_Oqc_Technician", in_node, ref out_node) == false)
                {
                    return false;
                }
                cdvGrade.Code = null;
                cdvGrade.Description = null;
                cdvDefectCode.Code = null;
                cdvDefectCode.Description = null;
                cdvCellLocation.Code = null;
                cdvCellLocation.Description = null;
                txtremark.Text = "";
                   
                MPCF.ShowSuccessMessage(out_node, false);
                this.cdvDefectCode.Enabled = true;
                this.cdvCellLocation.Enabled = true;

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

                                            
                        if (MPCF.CheckValue(txtLotID, false) == false)
                        {
                            return false;
                        }

                       

                        if (MPCF.CheckValue(cdvGrade, false) == false)
                        {
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

        private bool CheckArticle()
        {
           

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

        private void clearFieldTextall()
        {
            // 그리드 CLear
            MPCF.ClearList(spdFlashRlt);
            MPCF.ClearList(spdFqcList);
            //필드 Clear
            txtGrade.Text = "";
            txtDefect.Text = "";
            txtCellInfo.Text = "";
            txtOQCremark.Text = "";
            txtworker.Text = "";

            cdvGrade.Text = "";
            cdvDefectCode.Text = "";
            cdvCellLocation.Text = "";
            txtremark.Text = "";

            cdvGrade.Description = "";
            cdvDefectCode.Description = "";
            cdvCellLocation.Description = "";
          



        }

        private void clearFieldText()
        {
            //txtLotID.Text = "";
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

        private void btnsearch2_Click(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("TABLE_NAME", "@OQC_WORKER");
            in_node.AddString("KEY_1", "ENGINEER");
            string[] display = new string[] { "KEY_1", "DATA_1" };
            string[] header = new string[] { "TECHNICIAN", "TECHNICIAN Name" };

            cdvTxtWorker.Text = "";
            cdvTxtWorker.Text = txtworker.Text;

            cdvTxtWorker.Text = cdvTxtWorker.Show(cdvTxtWorker, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "TECHNICIAN");

            // Validation
            if (string.IsNullOrEmpty(cdvTxtWorker.Text) == true)
            {
                return;
            }


            txtworker.Text = cdvTxtWorker.Text;
            // Focus
            MPCF.SetFocus(txtworker);
        }

      

   
    }
}