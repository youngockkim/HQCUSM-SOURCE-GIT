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
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCUSMultiModuleFQCResult : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private TRSNode nodeLotInfo;

        #endregion

        #region Constructor

        public frmCUSMultiModuleFQCResult()
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
            PMPP
        }

        #endregion

        #region Event Handler

        private void frmCUSMultiModuleFQCResult_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            MPCF.ConvertCaption(this);

            // Fix Operation
            cdvOper.Text = HQGC.OPER_M3110; // FQC
        }

        private void frmCUSMultiModuleFQCResult_Shown(object sender, EventArgs e)
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

        private void cdvGrade_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_GRADE));

                string[] header = new string[] { "Grade", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvGrade.Text = cdvGrade.Show(cdvGrade, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvGrade.Text) == true)
                {
                    return;
                }

                if (cdvGrade.Text == "G01")
                {
                    txtResult.Text = "A";
                    txtJudge.Text = "CL510";
                }
                else if (cdvGrade.Text == "G02")
                {
                    txtResult.Text = "A";
                    txtJudge.Text = "CL511";
                }
                else if (cdvGrade.Text == "B")
                {
                    txtResult.Text = "B";
                    txtJudge.Text = "CL512";
                }
                else if (cdvGrade.Text == "C")
                {
                    txtResult.Text = "C";
                    txtJudge.Text = "CL514";
                }
                else if (cdvGrade.Text == "G06")
                {
                    txtResult.Text = "SC";
                    txtJudge.Text = "CL207";
                }
                else if (cdvGrade.Text == "RWK")
                {
                    txtResult.Text = "RW";
                    txtJudge.Text = "RWK";
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        /*
        private void cdvShiftID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {

                // Code View Service
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "@SHIFT");

                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Shift", "Description" };

                cdvShiftID.Text = cdvShiftID.Show(cdvShiftID, "View Shift", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Shift");

                // Validation
                if (string.IsNullOrEmpty(cdvShiftID.Text) == true)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
        */

        private void btnSearch_Click(object sender, EventArgs e)
        {
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

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
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
                        //return;
                    }

                    if (ViewLotHis(txtLotID.Text) == false)
                    {
                        txtLotID.SelectAll();
                        //return;
                    }

                    if (ViewTestData(txtLotID.Text) == false)
                    {
                        txtLotID.SelectAll();
                        //return;
                    }

                    txtLotID.Focus();
                    txtLotID.SelectAll();
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
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

                if (MPCF.ShowMsgBox(MPCF.GetMessage(539), MessageBoxButtons.YesNo, MSG_LEVEL.WARNING) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                if (Tran_FQC_Input())
                {
                    ViewLot(txtLotID.Text);
                    ViewLotHis(txtLotID.Text);
                    ViewTestData(txtLotID.Text);
                    //return;
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

        private bool ViewLot(string sLotId)
        {
            TRSNode in_node = new TRSNode("VIEW_FQC_IN");
            TRSNode out_node = new TRSNode("VIEW_FQC_OUT");

            try
            {
                // FieldClear
                MPCF.ClearList(spdFlashRlt);
                MPCF.ClearList(spdFqcList);

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INS_TYPE", HQGC.INSP_TYPE_FC);
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));

                if (MPCF.CallService("CWIP", "CWIP_View_Fqc_Result", in_node, ref out_node) == false)
                {
                    return false;
                }

                nodeLotInfo = out_node;

                cdvLineID.Text = out_node.GetString("LINE_ID");
                cdvOper.Text = out_node.GetString("OPER");
                cdvEquipID.Text = out_node.GetString("RES_ID");

                cdvGrade.Text = out_node.GetString("GRADE");
                cdvGrade.Description = string.Empty;

                txtPower.Text = out_node.GetString("POWER");
                txtResult.Text = out_node.GetString("RESULT_VALUE");
                txtJudge.Text = out_node.GetString("INS_VALUE");
                txtRemark.Text = out_node.GetString("RLT_COMMENT");

                //txtOSC.Text = out_node.GetString("OSC");
                //txtESC.Text = out_node.GetString("ESC");
                //txtlEL.Text = out_node.GetString("EL");

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

                if (MPCF.CallService("CWIP", "CWIP_View_Fqc_List", in_node, ref out_node) == false)
                {
                    return false;
                }

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
                    spdFqcList.ActiveSheet.Cells[i, (int)HIS_LIST.GRADE].Value = out_list.GetString("GRADE");
                    spdFqcList.ActiveSheet.Cells[i, (int)HIS_LIST.POWER].Value = out_list.GetString("POWER");
                    spdFqcList.ActiveSheet.Cells[i, (int)HIS_LIST.ARTICLE_NO].Value = out_list.GetString("ARTICLE_NO");
                    spdFqcList.ActiveSheet.Cells[i, (int)HIS_LIST.COLOR_CLASS].Value = out_list.GetString("COLOR_CLASS");
                }

                MPCF.FitColumnHeader(spdFqcList);

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
                }

                MPCF.FitColumnHeader(spdFlashRlt);

                /*
                cdvGrade.Text = out_node3.GetList(0)[0].GetString("GRADE");
                txtPower.Text = out_node3.GetList(0)[0].GetString("POWER");
                txtOSC.Text = out_node3.GetList(0)[0].GetString("OSC");
                txtESC.Text = out_node3.GetList(0)[0].GetString("ESC");
                txtlEL.Text = out_node3.GetList(0)[0].GetString("EL");
                */

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


                //in_node.AddString("OSC", MPCF.Trim(txtOSC.Text));        
                //in_node.AddString("ESC", MPCF.Trim(txtESC.Text));        
                //in_node.AddString("EL", MPCF.Trim(txtlEL.Text));        

                if (MPCF.CallService("CWIP", "CWIP_Update_Fqc_Result", in_node, ref out_node) == false)
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

        private void cdvGrade_Load(object sender, EventArgs e)
        {

        }








    }
}