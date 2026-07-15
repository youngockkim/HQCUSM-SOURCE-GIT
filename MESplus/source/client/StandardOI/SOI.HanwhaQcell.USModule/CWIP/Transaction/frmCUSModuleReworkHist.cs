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
    public partial class frmCUSModuleReworkHist : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private TRSNode nodeLotInfo;
        private List<string> lotList;

        #endregion

        #region Constructor

        public frmCUSModuleReworkHist()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        public enum TEST_LIST
        {
            X,
            LOT_ID,
            LINE_ID,
            CELL_INFO,
            DEFECT_CODE,
            DEFECT_DESC,
            OLD_OPER,
            OLD_OPER_DESC,
            OLD_OPER_TRAN_TIME
        }

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
        private void cdvRework_CodeViewButtonClick(object sender, EventArgs e)
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


                if (cdvCategory.Text == "")
                {
                    MPCF.ShowMsgBox("Please Select Category ID");
                    cdvCategory.Focus();
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "@REWORK_REASON");
                in_node.AddString("KEY_1", cdvCategory.Text);

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_2", "DATA_1" };

                cdvRework.Text = cdvRework.Show(cdvRework, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_2");
                //cdvRework.Text = cdvcdvReworkCW1.Show(cdvRework, "Code List", "CBAS", "CBAS_View_Large_Data_List", in_node, "DATA_LIST", display, header, "KEY_2");


                if (string.IsNullOrEmpty(cdvRework.Text) == true)
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
                            
                Tran_REWORK_input();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        private void cdvCategory_CodeViewButtonClick(object sender, EventArgs e)
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
                in_node.AddString("TABLE_NAME", "@REWORK_CATEGORY");

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvCategory.Text = cdvCategory.Show(cdvCategory, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                if (string.IsNullOrEmpty(cdvCategory.Text) == true)
                {
                    cdvRework.Text = "";
                    cdvRework.Description = "";
                    return;
                }

                cdvRework.Text = "";
                cdvRework.Description = "";

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
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
            string check_string;


            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INS_TYPE", HQGC.INSP_TYPE_FC);
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));
                in_node.AddChar("RE_JUDGE_FLAG", 'Y');  // 재판정 OI에서만 사용

                //마지막 FQC 판정을 읽어온다 없으면 재판정이 아님
                //CEDCLOTRLT.INS_TYPE = FC
                if (MPCF.CallService("CWIP", "CWIP_View_Rework_Result", in_node, ref out_node) == false)
                { 
                    MPCF.ShowMessage(MPCF.GetMessage(154), MSG_LEVEL.ERROR, false);
                    return false;
                }

   
                nodeLotInfo = out_node;
                spdFlashRlt.ActiveSheet.Cells[index, (int)TEST_LIST.X].Value = index+1;
                spdFlashRlt.ActiveSheet.Cells[index, (int)TEST_LIST.LOT_ID].Value = MPCF.Trim(sLotId);
                spdFlashRlt.ActiveSheet.Cells[index, (int)TEST_LIST.LINE_ID].Value = out_node.GetString("LINE_ID");
                spdFlashRlt.ActiveSheet.Cells[index, (int)TEST_LIST.CELL_INFO].Value = out_node.GetString("CELL_INFO");
                spdFlashRlt.ActiveSheet.Cells[index, (int)TEST_LIST.DEFECT_CODE].Value = out_node.GetString("DEFECT_CODE");
                spdFlashRlt.ActiveSheet.Cells[index, (int)TEST_LIST.DEFECT_DESC].Value = out_node.GetString("DEFECT_DESC");
                spdFlashRlt.ActiveSheet.Cells[index, (int)TEST_LIST.OLD_OPER].Value = out_node.GetString("OLD_OPER");
                spdFlashRlt.ActiveSheet.Cells[index, (int)TEST_LIST.OLD_OPER_DESC].Value = out_node.GetString("OLD_OPER_DESC");
                check_string = "";
                check_string = out_node.GetString("OLD_OPER_TRAN_TIME");
                if (string.IsNullOrEmpty(check_string) == false)
                {
                    spdFlashRlt.ActiveSheet.Cells[index, (int)TEST_LIST.OLD_OPER_TRAN_TIME].Value = MPCF.MakeDateFormat(out_node.GetString("OLD_OPER_TRAN_TIME"), DATE_TIME_FORMAT.DATETIME);
                }
                else
                {
                    spdFlashRlt.ActiveSheet.Cells[index, (int)TEST_LIST.OLD_OPER_TRAN_TIME].Value = "";
                }


  
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

      

        private bool Tran_REWORK_input()
        {
            string check_string;
            int errorCode = 0;
            try
            {
              
                if (lotList == null)
                {
                    MPCF.ShowMessage("Invalid Data", MSG_LEVEL.ERROR, false);
                    return false;
                }



                TRSNode in_node = new TRSNode("WORK_LIST");
                TRSNode out_node = new TRSNode("WORK_LIST_OUT");
                TRSNode work_list = null;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = 'I';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                
               
                for (int x = 0; x < lotList.Count; x++)
                {

                    work_list = in_node.AddNode("TRAN_LIST");
                    work_list.AddString("LOT_ID", MPCF.Trim(spdFlashRlt.Sheets[0].Cells[x, 1].Text));
                    work_list.AddString("LINE_ID", MPCF.Trim(spdFlashRlt.Sheets[0].Cells[x, 2].Text));
                    work_list.AddString("REASON_CODE", MPCF.Trim(cdvRework.Text));
					work_list.AddString("OPERATOR_NAME", MPCF.Trim(soiTBOperatorName.Text)); // IS-21-05-007 Rework Log MES OI Update Request
                    work_list.AddString("CELL_INFO", MPCF.Trim(spdFlashRlt.Sheets[0].Cells[x, 3].Text));
                    work_list.AddString("DEFECT_CODE", MPCF.Trim(spdFlashRlt.Sheets[0].Cells[x, 4].Text));
                    work_list.AddString("DEFECT_DESC", MPCF.Trim(spdFlashRlt.Sheets[0].Cells[x, 5].Text));
                    work_list.AddString("OLD_OPER", MPCF.Trim(spdFlashRlt.Sheets[0].Cells[x, 6].Text));
                    work_list.AddString("OLD_OPER_DESC", MPCF.Trim(spdFlashRlt.Sheets[0].Cells[x, 7].Text));
                    check_string = "";
                    check_string = MPCF.Trim(spdFlashRlt.Sheets[0].Cells[x, 8].Text);
                    if (string.IsNullOrEmpty(check_string) == false)
                    {
                        work_list.AddString("OLD_OPER_TRAN_TIME", MPCF.Trim(DateTime.Parse(spdFlashRlt.ActiveSheet.Cells[x, 8].Value.ToString()).ToString("yyyyMMddHHmmss")));
                    }
                    else
                    {
                        work_list.AddString("OLD_OPER_TRAN_TIME", check_string);
                    }



                   
                }


                if (MPCF.CallService("CWIP", "CWIP_Update_Lot_Rework", in_node, ref out_node) == false)
                {
                    return false;
                }
                for (int x = 0; x < lotList.Count; x++)
                {
                    spdFlashRlt.ActiveSheet.RemoveRows(x, 1);
                    lotList.RemoveAt(x);
                    x--;
                }

                cdvRework.Text = "";
                cdvRework.Description = "";
                cdvCategory.Text = "";
                cdvCategory.Description = "";

				soiTBOperatorName.Text = ""; // IS-21-05-007 Rework Log MES OI Update Request
                   
                    
                

               

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

                    if ("RWK".Equals(cdvRework.Text))
                    {
                        for (int i = 0; i < out_node.GetList(0).Count; i++)
                        {
                            out_list = out_node.GetList(0)[i];

                            string grade = out_list.GetString("GRADE");
                            //ArrayList gradeArray = new ArrayList { "G01", "G02", "B", "C", "G06" };
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

                        if (MPCF.CheckValue(cdvRework, false) == false)
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


        #endregion

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

        private void cdvRework_Load(object sender, EventArgs e)
        {

        }

        private void cdvCategory_Load(object sender, EventArgs e)
        {

        }
    }
}