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
using System.Globalization;
using System.Collections;

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm03 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel, Print Option
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCUSOqcDarkChamber : SOIBaseForm03
    {
        #region Property

        // (Required)
        private bool bIsShown = false;


        #endregion

        #region Constructor

        public frmCUSOqcDarkChamber()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm03_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);

            //locList 초기화 나중에 불량 위치정보 유효성검사에 사용
            loc_list = initLocList();

            //defectList 초기화 나중에 불량정보 유효성검사에 사용
            defect_list = initDefectList();

            MPCF.ShowMessage("v1.0.0", MSG_LEVEL.INFO, false);

        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm03_Shown(object sender, EventArgs e)
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


        /// <summary>
        /// Print Spread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpreadPrint_Click(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// Import Excel to Spread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpreadImportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (soiRadioButton1.CheckedIndex == 0)
                {
                    if (!importSIExcel())
                    {
                        return;
                    }
                }
                else if (soiRadioButton1.CheckedIndex == 1)
                {
                    if (!importELExcel())
                    {
                        return;
                    }
                }
                else
                {
                    MPCF.ShowMessage("Radio Index Error Please contact MES Team", MSG_LEVEL.ERROR, false);
                }

                MPCF.ShowMessage("Data Import success!!", MSG_LEVEL.INFO, false);

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
            finally
            {
                soiSpreadImportSI.Visible = false;
                soiSpreadImportEL.Visible = false;
            }
        }

        /// <summary>
        /// Export Excel From Spread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpreadExcelExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (soiRadioButton1.CheckedIndex == 0)
                {
                    btnSpreadExcelExport.RunExport(soiSpreadExportFormatSI);
                }
                else if (soiRadioButton1.CheckedIndex == 1)
                {
                    btnSpreadExcelExport.RunExport(soiSpreadExportFormatEL);
                }
                else
                {
                    MPCF.ShowMessage("Radio Index Error Please contact MES Team", MSG_LEVEL.ERROR, false);
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

      

       

        #endregion


        public enum SI_LIST
        {
            MODULE_ID,
            RESULT,
            INS_TIME,
            EFF,
            RSH,
            RS,
            FF,
            ISC,
            VOC,
            VMPP,
            IMPP,
            PMPP,
            TEMP,
            TREF,
            SURFTEMP,
            SUN
        }




        public enum EL_LIST
        {
            MODULE_ID,
            RESULT,
            INS_TIME,
            DEFECT_CODE
        }

        ArrayList loc_list;

        ArrayList defect_list;

        

        //라디오 버튼 선택
        private void soiRadioButton1_ValueChanged(object sender, EventArgs e)
        {
            if(soiRadioButton1.CheckedIndex == 0)
            {
                initSimulatorGrid();
                soiGroupBox15.Text = "OQC Dark Chamber (Simulator)";
            }
            else if(soiRadioButton1.CheckedIndex == 1)
            {
                initELGrid();
                soiGroupBox15.Text = "OQC Dark Chamber (Backend EL)";
            }
            else
            {
                MPCF.ShowMessage("Radio Index Error Please contact MES Team", MSG_LEVEL.ERROR, false);
            }

        }

        private void initSimulatorGrid()
        {
            soiSpread1.Sheets[0].Columns.Clear();
            soiSpread1.Sheets[0].Rows.Clear();
            soiSpread1.Sheets[0].Columns.Add(0, Enum.GetNames(typeof(SI_LIST)).Length);

            string title;
            float size;
            for (int i = 0; i < Enum.GetNames(typeof(SI_LIST)).Length; i++)
            {
                title = soiSpreadExportFormatSI.Sheets[0].Cells[0, i].Value.ToString();
                size = soiSpreadExportFormatSI.Sheets[0].Columns[i].Width;

                soiSpread1.Sheets[0].ColumnHeader.Cells[0, i].Text = title;
                soiSpread1.Sheets[0].Columns[i].Width = size;
            }
        }


        private void initELGrid()
        {
            soiSpread1.Sheets[0].Columns.Clear();
            soiSpread1.Sheets[0].Rows.Clear();
            soiSpread1.Sheets[0].Columns.Add(0, Enum.GetNames(typeof(EL_LIST)).Length);

            string title;
            float size;
            for (int i = 0; i < Enum.GetNames(typeof(EL_LIST)).Length; i++)
            {
                title = soiSpreadExportFormatEL.Sheets[0].Cells[0, i].Value.ToString();
                size = soiSpreadExportFormatEL.Sheets[0].Columns[i].Width;

                soiSpread1.Sheets[0].ColumnHeader.Cells[0, i].Text = title;
                soiSpread1.Sheets[0].Columns[i].Width = size;
            }
        }

        private bool importSIExcel()
        {
            // (Option 1) Import from OpenFileDialog
            btnSpreadImportExcel.RunImport(soiSpreadImportSI);

            //check column format
            for (int x = 0; x < Enum.GetNames(typeof(SI_LIST)).Length; x++)
            {
                if (!soiSpread1.Sheets[0].Columns[x].Label.Equals(soiSpreadImportSI.Sheets[0].Cells[0, x].Value))
                {
                    MPCF.ShowMessage(String.Format("The Excel Format is different. Please Check {0}({1}) Column name", soiSpreadImportSI.Sheets[0].Cells[0, x].Value, (x + 1)), MSG_LEVEL.ERROR, false);
                    return false;
                }
            }


            string cellValue;
            int y = 1;

            ArrayList lotList = new ArrayList();

            //그리드 클리어
            soiSpread1.Sheets[0].Rows.Clear();
            while (true)
            {

                //현재 그리드의 로우 추가

                //lot id가 없을 때 까지 반복
                if (soiSpreadImportSI.Sheets[0].Cells[y, 0].Value == null)
                {
                    break;
                }

                if (String.IsNullOrEmpty(soiSpreadImportSI.Sheets[0].Cells[y, 0].Value.ToString()))
                {
                    break;
                }


                soiSpread1.Sheets[0].RowCount++;

                for (int x = 0; x < Enum.GetNames(typeof(SI_LIST)).Length; x++)
                {

                    if (soiSpreadImportSI.Sheets[0].Cells[y, x].Value == null && x != (int)SI_LIST.TREF)
                    {
                        MPCF.ShowMessage(String.Format("There is no data. Please Check {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                        soiSpread1.Sheets[0].Rows.Clear();
                        return false;
                    }
                    else if (soiSpreadImportSI.Sheets[0].Cells[y, x].Value == null && x == (int)SI_LIST.TREF)
                    {
                        cellValue = string.Empty;
                    }
                    else
                    {
                        cellValue = soiSpreadImportSI.Sheets[0].Cells[y, x].Value.ToString().ToUpper();
                    }

                    cellValue = MPCF.Trim(cellValue);
                    cellValue = cellValue.Replace("\n", "");
                    cellValue = cellValue.Replace("\r", "");

                    if (String.IsNullOrEmpty(cellValue) && x != (int)SI_LIST.TREF)
                    {
                        MPCF.ShowMessage(String.Format("There is no data. Please Check {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                        soiSpread1.Sheets[0].Rows.Clear();
                        return false;
                    }




                    if (x == 0)
                    {
                        if (cellValue.Length != 18)
                        {
                            MPCF.ShowMessage(String.Format("Please Check Moudle Name {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                            soiSpread1.Sheets[0].Rows.Clear();
                            return false;
                        }


                        if (lotList.Contains(cellValue))
                        {
                            MPCF.ShowMessage(String.Format("There is a dupulicate module id. please check {0} module id in {1} row  {2} cell", cellValue, y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                            soiSpread1.Sheets[0].Rows.Clear();
                            return false;
                        }
                        else
                        {
                            lotList.Add(cellValue);
                        }

                    }
                    else if (x == 1)
                    {
                        if (cellValue != "OK" && cellValue != "NG")
                        {
                            MPCF.ShowMessage(String.Format("Please Check Result {0} row  {1} cell data", y, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                            soiSpread1.Sheets[0].Rows.Clear();
                            return false;
                        }
                    }
                    else if (x == 2)
                    {
                        if (cellValue.Length != 14)
                        {
                            MPCF.ShowMessage(String.Format("There is datetime error. Please Check {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                            soiSpread1.Sheets[0].Rows.Clear();
                            return false;
                        }

                        DateTime dateTime;
                        if (!DateTime.TryParseExact(cellValue, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                        {
                            MPCF.ShowMessage(String.Format("There is datetime error. Please Check {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                            soiSpread1.Sheets[0].Rows.Clear();
                            return false;
                        }
                        else if (dateTime.CompareTo(DateTime.Now) > 0)
                        {
                            MPCF.ShowMessage(String.Format("Date can not be larger than now. Please Check {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                            soiSpread1.Sheets[0].Rows.Clear();
                            return false;
                        }
                    }
                    else if (x > 2)
                    {
                        if (!string.IsNullOrEmpty(cellValue))
                        {
                            double dummyDouble;
                            if (!double.TryParse(cellValue, out dummyDouble))
                            {
                                MPCF.ShowMessage(String.Format("There is number error. Please Check {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                                soiSpread1.Sheets[0].Rows.Clear();
                                return false;

                            }
                            else
                            {
                                cellValue = dummyDouble.ToString();
                            }
                        }

                    }


                    soiSpread1.Sheets[0].Cells[y - 1, x].Value = cellValue;


                }

                y++;


                if (y > 101)
                {
                    MPCF.ShowMessage("100 rows is Maxium.", MSG_LEVEL.ERROR, false);
                    soiSpread1.Sheets[0].Rows.Clear();
                    return false;
                }
            }

            return true;
        }


        private bool importELExcel()
        {
            // (Option 1) Import from OpenFileDialog
            btnSpreadImportExcel.RunImport(soiSpreadImportEL);

            //check column format
            for (int x = 0; x < Enum.GetNames(typeof(EL_LIST)).Length; x++)
            {
                if (!soiSpread1.Sheets[0].Columns[x].Label.Equals(soiSpreadImportEL.Sheets[0].Cells[0, x].Value))
                {
                    MPCF.ShowMessage(String.Format("The Excel Format is different. Please Check {0}({1}) Column name", soiSpreadImportEL.Sheets[0].Cells[0, x].Value, (x + 1)), MSG_LEVEL.ERROR, false);
                    return false;
                }
            }


            string cellValue;
            int y = 1;

            ArrayList lotList = new ArrayList();

            //그리드 클리어
            soiSpread1.Sheets[0].Rows.Clear();
            while (true)
            {

                //현재 그리드의 로우 추가

                //lot id가 없을 때 까지 반복
                if (soiSpreadImportEL.Sheets[0].Cells[y, 0].Value == null)
                {
                    break;
                }

                if (String.IsNullOrEmpty(soiSpreadImportEL.Sheets[0].Cells[y, 0].Value.ToString()))
                {
                    break;
                }


                soiSpread1.Sheets[0].RowCount++;

                for (int x = 0; x < Enum.GetNames(typeof(EL_LIST)).Length; x++)
                {

                    if (x < 3 && soiSpreadImportEL.Sheets[0].Cells[y, x].Value == null)
                    {
                        MPCF.ShowMessage(String.Format("There is no data. Please Check {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                        soiSpread1.Sheets[0].Rows.Clear();
                        return false;
                    }
                    else if (x > 2 && soiSpreadImportEL.Sheets[0].Cells[y, x].Value == null)
                    {
                        cellValue = String.Empty; 
                    }
                    else
                    {
                        cellValue = soiSpreadImportEL.Sheets[0].Cells[y, x].Value.ToString().ToUpper();
                    }


                    cellValue = MPCF.Trim(cellValue);
                    cellValue = cellValue.Replace("\n", "");
                    cellValue = cellValue.Replace("\r", "");

                    if (x < 3 && String.IsNullOrEmpty(cellValue))
                    {
                        MPCF.ShowMessage(String.Format("There is no data. Please Check {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                        soiSpread1.Sheets[0].Rows.Clear();
                        return false;
                    }




                    if (x == 0)
                    {
                        if (cellValue.Length != 18)
                        {
                            MPCF.ShowMessage(String.Format("Please Check Moudle Name {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                            soiSpread1.Sheets[0].Rows.Clear();
                            return false;
                        }


                        if (lotList.Contains(cellValue))
                        {
                            MPCF.ShowMessage(String.Format("There is a dupulicate module id. please check {0} module id in {1} row  {2} cell", cellValue, y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                            soiSpread1.Sheets[0].Rows.Clear();
                            return false;
                        }
                        else
                        {
                            lotList.Add(cellValue);
                        }

                    }
                    else if (x == 1)
                    {
                        if (cellValue != "OK" && cellValue != "NG")
                        {
                            MPCF.ShowMessage(String.Format("Please Check Result {0} row  {1} cell data", y, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                            soiSpread1.Sheets[0].Rows.Clear();
                            return false;
                        }
                    }
                    else if (x == 2)
                    {
                        if (cellValue.Length != 14)
                        {
                            MPCF.ShowMessage(String.Format("There is datetime error. Please Check {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                            soiSpread1.Sheets[0].Rows.Clear();
                            return false;
                        }

                        DateTime dateTime;
                        if (!DateTime.TryParseExact(cellValue, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                        {
                            MPCF.ShowMessage(String.Format("There is datetime error. Please Check {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                            soiSpread1.Sheets[0].Rows.Clear();
                            return false;
                        }
                        else if (dateTime.CompareTo(DateTime.Now) > 0)
                        {
                            MPCF.ShowMessage(String.Format("Date can not be larger than now. Please Check {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                            soiSpread1.Sheets[0].Rows.Clear();
                            return false;
                        }
                    }
                    else if (x > 2)
                    {
                        string resultValue = soiSpreadImportEL.Sheets[0].Cells[y, 1].Value.ToString();

                        //불량은 불량 코드와 위치가 있어야 한다.
                        if (resultValue.Equals("NG"))
                        {
                            if (String.IsNullOrEmpty(cellValue))
                            {
                                MPCF.ShowMessage(String.Format("NG should have defect code and defect location. Please Check {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                                soiSpread1.Sheets[0].Rows.Clear();
                                return false;
                            }

                            cellValue = cellValue.Replace(" ", "");

                            if (!cellValue.StartsWith("(") || !cellValue.EndsWith(")"))
                            {
                                MPCF.ShowMessage(String.Format("defect location should be (defectcode, loaction) format. Please Check {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                                soiSpread1.Sheets[0].Rows.Clear();
                                return false;
                            }

                            string[] stringArray = cellValue.Split(new[] { "),(" }, StringSplitOptions.None);

                            for (int i = 0; i < stringArray.Length; i++)
                            {
                                string[] valueArray = stringArray[i].Split(',');

                                if (valueArray.Length != 2)
                                {
                                    MPCF.ShowMessage(String.Format("defect location should be (defectcode, loaction) format. Please Check {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                                    soiSpread1.Sheets[0].Rows.Clear();
                                    return false;
                                }
                            }
                        }
                    }
                   
                    soiSpread1.Sheets[0].Cells[y - 1, x].Value = cellValue;


                }

                y++;

                if (y > 101)
                {
                    MPCF.ShowMessage("100 rows is Maxium.", MSG_LEVEL.ERROR, false);
                    soiSpread1.Sheets[0].Rows.Clear();
                    return false;
                }
            }

            return true;
        }


        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (soiSpread1.ActiveSheet.RowCount < 1)
            {
                MPCF.ShowMessage("No data to process", MSG_LEVEL.ERROR, false);
                return;
            }

            btnProcess.Enabled = false;

            if (soiRadioButton1.CheckedIndex == 0)
            {   
                sendSimulatorInfo();
            }
            else if (soiRadioButton1.CheckedIndex == 1)
            {   
                sendELInfo();
            }
            else
            {
                MPCF.ShowMessage("Radio Index Error Please contact MES Team", MSG_LEVEL.ERROR, false);
            }


            btnProcess.Enabled = true;
        }

        private void sendSimulatorInfo()
        {
            // IS-21-03-045	Dark Chamber OQC 튜닝
            // 개별 리스트 전송 후 오류 처리
            //TRSNode in_node = new TRSNode("IN_NODE");
            TRSNode out_node = new TRSNode("OUT_NODE");


            TRSNode moduleList;
            TRSNode paramList;
            TRSNode paramItem;

            string lot_id = string.Empty;
            string res_id = string.Empty;
            string line_id = string.Empty;
            string tran_time = string.Empty;
            string sim_result = string.Empty;

            try
            {
                for (int i = 0; i < soiSpread1.ActiveSheet.RowCount; i++)
                {
                    // IS-21-03-045	Dark Chamber OQC 튜닝
                    // 개별 리스트 전송 후 오류 처리
					TRSNode in_node = new TRSNode("IN_NODE");


                    moduleList = in_node.AddNode("MODULE_LIST");

                    MPCF.SetInMsg(moduleList);

                    lot_id = MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)SI_LIST.MODULE_ID].Value.ToString());

                    //core기능으로 lot strat하면 해당 설비에 락이 걸려서 02번으로 OQC용 장비 새로 추가
                    res_id = "US-E" + lot_id.Substring(2, 1) + "-SIM-02";

                    line_id = "MDL0" + lot_id.Substring(2, 1);

                    tran_time = MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)SI_LIST.INS_TIME].Value.ToString());

                    moduleList.ProcStep = '1';
                    moduleList.AddString("LOT_ID", lot_id);              // LOT_ID
                    moduleList.AddString("RES_ID", res_id);              // RES_ID
                    moduleList.AddString("LINE_ID", line_id);              // RES_ID
                    moduleList.AddString("TRAN_TIME", tran_time);     // TRAN_TIME
                    moduleList.AddString("TRAN_TIME_STAMP", tran_time + "000000");     // TRAN_TIME
                    moduleList.AddString("TYPE_FLAG", "2");     // TRAN_TIME
                    moduleList.AddString("CLIENT_ID", "OQC_SCREEN");     // TRAN_TIME
                    moduleList.AddString("RESULT", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)SI_LIST.RESULT].Value.ToString()));     // RESULT

                    if (MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)SI_LIST.RESULT].Value.ToString()).Equals("OK"))
                    {
                        sim_result = "2";
                    }
                    else
                    {
                        sim_result = "3";
                    }

                    //파라미터 리스트 생성
                    paramList = moduleList.AddNode("PARAM_LIST");

                    paramItem = paramList.AddNode("PARAM_ITEM");
                    paramItem.AddString("PARAM_NAME", "I_SIM_01_VOC");
                    paramItem.AddString("PARAM_VALUE", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)SI_LIST.VOC].Value.ToString()));

                    paramItem = paramList.AddNode("PARAM_ITEM");
                    paramItem.AddString("PARAM_NAME", "I_SIM_01_EFF");
                    paramItem.AddString("PARAM_VALUE", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)SI_LIST.EFF].Value.ToString()));

                    paramItem = paramList.AddNode("PARAM_ITEM");
                    paramItem.AddString("PARAM_NAME", "I_SIM_01_ENV_TEMP");
                    paramItem.AddString("PARAM_VALUE", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)SI_LIST.TREF].Value.ToString()));

                    paramItem = paramList.AddNode("PARAM_ITEM");
                    paramItem.AddString("PARAM_NAME", "I_SIM_01_FF");
                    paramItem.AddString("PARAM_VALUE", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)SI_LIST.FF].Value.ToString()));

                    paramItem = paramList.AddNode("PARAM_ITEM");
                    paramItem.AddString("PARAM_NAME", "I_SIM_01_IMAX");
                    paramItem.AddString("PARAM_VALUE", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)SI_LIST.IMPP].Value.ToString()));

                    paramItem = paramList.AddNode("PARAM_ITEM");
                    paramItem.AddString("PARAM_NAME", "I_SIM_01_ISC");
                    paramItem.AddString("PARAM_VALUE", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)SI_LIST.ISC].Value.ToString()));

                    paramItem = paramList.AddNode("PARAM_ITEM");
                    paramItem.AddString("PARAM_NAME", "I_SIM_01_MODULE_TEMP");
                    paramItem.AddString("PARAM_VALUE", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)SI_LIST.TEMP].Value.ToString()));

                    paramItem = paramList.AddNode("PARAM_ITEM");
                    paramItem.AddString("PARAM_NAME", "I_SIM_01_PMAX");
                    paramItem.AddString("PARAM_VALUE", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)SI_LIST.PMPP].Value.ToString()));

                    paramItem = paramList.AddNode("PARAM_ITEM");
                    paramItem.AddString("PARAM_NAME", "I_SIM_01_RESULT");
                    paramItem.AddString("PARAM_VALUE", sim_result);

                    paramItem = paramList.AddNode("PARAM_ITEM");
                    paramItem.AddString("PARAM_NAME", "I_SIM_01_RS");
                    paramItem.AddString("PARAM_VALUE", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)SI_LIST.RS].Value.ToString()));

                    paramItem = paramList.AddNode("PARAM_ITEM");
                    paramItem.AddString("PARAM_NAME", "I_SIM_01_RSH");
                    paramItem.AddString("PARAM_VALUE", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)SI_LIST.RSH].Value.ToString()));

                    paramItem = paramList.AddNode("PARAM_ITEM");
                    paramItem.AddString("PARAM_NAME", "I_SIM_01_SUN");
                    paramItem.AddString("PARAM_VALUE", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)SI_LIST.SUN].Value.ToString()));

                    paramItem = paramList.AddNode("PARAM_ITEM");
                    paramItem.AddString("PARAM_NAME", "I_SIM_01_SURF_TEMP");
                    paramItem.AddString("PARAM_VALUE", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)SI_LIST.SURFTEMP].Value.ToString()));

                    paramItem = paramList.AddNode("PARAM_ITEM");
                    paramItem.AddString("PARAM_NAME", "I_SIM_01_VMAX");
                    paramItem.AddString("PARAM_VALUE", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)SI_LIST.VMPP].Value.ToString()));

                    // IS-21-03-045	Dark Chamber OQC 튜닝
                    // 개별 리스트 전송 후 오류 처리
                    if (MPCF.CallService("CWIP", "CWIP_Collect_Inspection_Data_Oqc", in_node, ref out_node) == false)
					{
						string strErrorType = out_node.GetString("ERROR_TYPE");
						int nLotIndex = out_node.GetInt("LOT_INDEX");
						string strLOTID = out_node.GetString("LOT_ID");
						string strWorkType = out_node.GetString("WORK_TYPE");

						TRSNode FieldMsg = out_node.FieldMsg;
						string strErrorMsg = "";
						string strErrorMsgTemp;
						for (int MemberIndex = 0; FieldMsg.MemberCount > MemberIndex; MemberIndex++)
						{
							if (FieldMsg.Members[MemberIndex].Name == "FMSG_1")
                            {
                                strErrorMsgTemp = FieldMsg.Members[MemberIndex].Value + "\r\n"
                             + "----------------------------------\r\n";
                                strErrorMsg += strErrorMsgTemp;
                            }
                            else 
                            {
                                strErrorMsgTemp = "KEY : " + FieldMsg.Members[MemberIndex].Name + " / VALUE : " + FieldMsg.Members[MemberIndex].Value + "\r\n";
                                strErrorMsg += strErrorMsgTemp;
                            }
						}

						if (strErrorType == "WORK_ERROR")
						{
							soiSpread1.ActiveSheet.Rows[i].BackColor = Color.Red;
							
							// 아래 경우일때만 정상 처리 LOT_ID 삭제 처리 필요
							soiSpread1.ActiveSheet.Rows.Remove(0, i);
							if (soiRadioButton1.CheckedIndex == 0)
							{
								soiSpreadImportSI.ActiveSheet.Rows.Remove(1, i);
							}
							else if (soiRadioButton1.CheckedIndex == 1)
							{
								soiSpreadImportEL.ActiveSheet.Rows.Remove(1, i);
							}

							soiSpread1.ActiveSheet.SetActiveCell(0, 0);
							soiSpread1.ShowRow(0, 0, FarPoint.Win.Spread.VerticalPosition.Nearest);

							string strViewError;
							strViewError = 
							   "LOTID : " + strLOTID + "\r\n"
							 + "INDEX : " + i + "\r\n"
							 + "TYPE : " + strWorkType + "\r\n"
							 + "----------------------------------\r\n"
							 + strErrorMsg;

							// 기본 dll ShowMessage
							MPCF.ShowMessage(strViewError, MSG_LEVEL.ERROR, true);
						}

						MPCF.ShowSuccessMessage(out_node, false);

						return;
					}

					// 정상 처리 파란색 처리
					soiSpread1.ActiveSheet.Rows[i].BackColor = Color.Blue;
					soiSpread1.ActiveSheet.SetActiveCell(i, 0);
					soiSpread1.ShowRow(0, i, FarPoint.Win.Spread.VerticalPosition.Nearest);
                }

                // IS-21-03-045	Dark Chamber OQC 튜닝
                // 개별 리스트 전송 후 오류 처리
                // 주석 처리
                /*
                if (MPCF.CallService("CWIP", "CWIP_Collect_Inspection_Data_Oqc", in_node, ref out_node) == false)
                {
                    return;
                }
                */

                soiSpread1.Sheets[0].Rows.Clear();
                MPCF.ShowSuccessMessage(out_node, true);

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }






        private void sendELInfo()
        {
            // IS-21-03-045	Dark Chamber OQC 튜닝
            // 개별 리스트 전송 후 오류 처리
            //TRSNode in_node = new TRSNode("IN_NODE");
            TRSNode out_node = new TRSNode("OUT_NODE");


            TRSNode moduleList;
            TRSNode defectList;
            TRSNode defectItem;

            string lot_id = string.Empty;
            string res_id = string.Empty;
            string line_id = string.Empty;
            string tran_time = string.Empty;

            try
            {
                for (int i = 0; i < soiSpread1.ActiveSheet.RowCount; i++)
                {
                    // IS-21-03-045	Dark Chamber OQC 튜닝
                    // 개별 리스트 전송 후 오류 처리
                    TRSNode in_node = new TRSNode("IN_NODE");

                    moduleList = in_node.AddNode("MODULE_LIST");

                    MPCF.SetInMsg(moduleList);

                    lot_id = MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)EL_LIST.MODULE_ID].Value.ToString());
                   
                    //core기능으로 lot strat하면 해당 설비에 락이 걸려서 02번으로 OQC용 장비 새로 추가
                    res_id = "US-E" + lot_id.Substring(2, 1) + "-BEL-02";

                    line_id = "MDL0" + lot_id.Substring(2, 1);

                    tran_time = MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)EL_LIST.INS_TIME].Value.ToString());

                    moduleList.ProcStep = '1';
                    moduleList.AddString("LOT_ID", lot_id);              // LOT_ID
                    moduleList.AddString("RES_ID", res_id);              // RES_ID
                    moduleList.AddString("LINE_ID", line_id);              // RES_ID
                    moduleList.AddString("TRAN_TIME", tran_time);     // TRAN_TIME
                    moduleList.AddString("TRAN_TIME_STAMP", tran_time + "000000");     // TRAN_TIME
                    moduleList.AddString("TYPE_FLAG", "2");     // TRAN_TIME
                    moduleList.AddString("CLIENT_ID", "OQC_SCREEN");     // TRAN_TIME
                    moduleList.AddString("RESULT", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)EL_LIST.RESULT].Value.ToString()));     // RESULT


                    if (MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)EL_LIST.RESULT].Value.ToString()) == "NG")
                    {
                        //파라미터 리스트 생성
                        defectList = moduleList.AddNode("DEFECT_LIST");

                        string defectValue = MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)EL_LIST.DEFECT_CODE].Value.ToString());

                        if (!defectValue.StartsWith("(") || !defectValue.EndsWith(")"))
                        {
                            MPCF.ShowMessage(String.Format("defect location should be (defectcode, loaction) format. Please Check {0} row  {1} cell data in excel file", i + 2, getIntToExcelColumn((int)EL_LIST.DEFECT_CODE)), MSG_LEVEL.ERROR, false);
                            return;
                        }
                        else
                        {
                            char[] charsTrim = {'(', ')'};
                            defectValue = defectValue.Trim(charsTrim);
                        }

                        string[] stringArray = defectValue.Split(new[] { "),(" }, StringSplitOptions.None);

                        for (int k = 0; k < stringArray.Length; k++)
                        {
                            string[] valueArray = stringArray[k].Split(',');

                            if (valueArray.Length != 2)
                            {
                                MPCF.ShowMessage(String.Format("defect location should be (defectcode, loaction) format. Please Check {0} row  {1} cell data in excel file", i + 2, getIntToExcelColumn((int)EL_LIST.DEFECT_CODE)), MSG_LEVEL.ERROR, false);
                                return;
                            }
                            else
                            {
                                defectItem = defectList.AddNode("DEFECT_ITEM");

                                if (!defect_list.Contains(valueArray[0]))
                                {
                                    MPCF.ShowMessage(String.Format("Please check the defect code -- row number {0} and {1} cell data in Excel file.", i + 2, getIntToExcelColumn((int)EL_LIST.DEFECT_CODE)), MSG_LEVEL.ERROR, false);
                                    return;
                                }                              

                                defectItem.AddString("REASON_CODE", valueArray[0]);

                                if(!loc_list.Contains(valueArray[1]))
                                {
                                    MPCF.ShowMessage(String.Format("Please Check Defect Locaion format. A01 ~ F24. row number {0} and {1} cell data in Excel file.", i + 2, getIntToExcelColumn((int)EL_LIST.DEFECT_CODE)), MSG_LEVEL.ERROR, false);
                                    return;
                                }

                                defectItem.AddString("LOC_ID", valueArray[1]);
                            }
                        }
                    }

                    // IS-21-03-045	Dark Chamber OQC 튜닝
                    // 개별 리스트 전송 후 오류 처리
                    if (MPCF.CallService("CWIP", "CWIP_Collect_Inspection_Data_Oqc", in_node, ref out_node) == false)
                    {
                        string strErrorType = out_node.GetString("ERROR_TYPE");
                        int nLotIndex = out_node.GetInt("LOT_INDEX");
                        string strLOTID = out_node.GetString("LOT_ID");
                        string strWorkType = out_node.GetString("WORK_TYPE");

                        TRSNode FieldMsg = out_node.FieldMsg;
                        string strErrorMsg = "";
                        string strErrorMsgTemp;
                        for (int MemberIndex = 0; FieldMsg.MemberCount > MemberIndex; MemberIndex++)
                        {
                            if (FieldMsg.Members[MemberIndex].Name == "FMSG_1")
                            {
                                strErrorMsgTemp = FieldMsg.Members[MemberIndex].Value + "\r\n"
                             + "----------------------------------\r\n";
                                strErrorMsg += strErrorMsgTemp;
                            }
                            else
                            {
                                strErrorMsgTemp = "KEY : " + FieldMsg.Members[MemberIndex].Name + " / VALUE : " + FieldMsg.Members[MemberIndex].Value + "\r\n";
                                strErrorMsg += strErrorMsgTemp;
                            }
                        }

                        if (strErrorType == "WORK_ERROR")
                        {
                            soiSpread1.ActiveSheet.Rows[i].BackColor = Color.Red;

                            // 아래 경우일때만 정상 처리 LOT_ID 삭제 처리 필요
                            soiSpread1.ActiveSheet.Rows.Remove(0, i);
                            if (soiRadioButton1.CheckedIndex == 0)
                            {
                                soiSpreadImportSI.ActiveSheet.Rows.Remove(1, i);
                            }
                            else if (soiRadioButton1.CheckedIndex == 1)
                            {
                                soiSpreadImportEL.ActiveSheet.Rows.Remove(1, i);
                            }

                            soiSpread1.ActiveSheet.SetActiveCell(0, 0);
                            soiSpread1.ShowRow(0, 0, FarPoint.Win.Spread.VerticalPosition.Nearest);

                            string strViewError;
                            strViewError =
                               "LOTID : " + strLOTID + "\r\n"
                             + "INDEX : " + i + "\r\n"
                             + "TYPE : " + strWorkType + "\r\n"
                             + "----------------------------------\r\n"
                             + strErrorMsg;

                            // 기본 dll ShowMessage
                            MPCF.ShowMessage(strViewError, MSG_LEVEL.ERROR, true);
                        }

                        MPCF.ShowSuccessMessage(out_node, false);

                        return;
                    }

                    // 정상 처리 파란색 처리
                    soiSpread1.ActiveSheet.Rows[i].BackColor = Color.Blue;
                    soiSpread1.ActiveSheet.SetActiveCell(i, 0);
                    soiSpread1.ShowRow(0, i, FarPoint.Win.Spread.VerticalPosition.Nearest);
                    
                }

                // IS-21-03-045	Dark Chamber OQC 튜닝
                // 개별 리스트 전송 후 오류 처리
                // 주석처리
                /*
                if (MPCF.CallService("CWIP", "CWIP_Collect_Inspection_Data_Oqc", in_node, ref out_node) == false)
                {
                    return;
                }
                */


                soiSpread1.Sheets[0].Rows.Clear();
                MPCF.ShowSuccessMessage(out_node, true);

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }








        /// <summary>
        /// IN Node를 초기설정 합니다.
        /// </summary>
        /// <param name="in_node"></param>
        public static void SetInMsg(TRSNode in_node)
        {
            try
            {
                // Factory
                if (MPGV.gsFactory != null) in_node.Factory = MPGV.gsFactory;
                // Language
                if (MPGV.gcLanguage != 0) in_node.Language = MPGV.gcLanguage;
                // Passport
                if (MPGV.gsPassport != null) in_node.Passport = MPGV.gsPassport;
                // Password
                if (MPGV.gsPassword != null) in_node.Password = MPGV.gsPassword;
                // User ID
                if (MPGV.gsUserID != null) in_node.UserID = MPGV.gsUserID;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        #region Function


        // 숫자를 엑셀 영문자 컬럼으로 변경  
        public string getIntToExcelColumn(int colIndex)  
        {
            colIndex = colIndex + 1;

            if (colIndex <= 26) return Convert.ToChar(colIndex + 64).ToString();  
  
            int div = colIndex / 26;  
            int mod = colIndex % 26;  
            if (mod == 0) { mod = 26; div--; }
            return getIntToExcelColumn(div) + getIntToExcelColumn(mod);  
        }


        private ArrayList initLocList()
        {
            ArrayList arrayList = new ArrayList();

            string[] rows = { "A", "B", "C", "D", "E", "F" };

            for (var i = 1; i < 27; i++)
            {
                for (var k = 0; k < rows.Length; k++)
                {
                    arrayList.Add((rows[k] + i.ToString("D2")));
                }
            }

            return arrayList;
        }


        private ArrayList initDefectList()
        {
            ArrayList arrayList = new ArrayList();


            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DATA_LIST_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("TABLE_NAME", "@DEFECT");
            in_node.AddString("KEY_2", "M2040"); //VOC-5239 [프로그램_변경]MESOI - OQC Dark Chamber
                                                 //Validation 조건 추가.
          

            if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
            {
                return arrayList;
            }

            List<TRSNode> lisData = out_node.GetList("DATA_LIST");
            foreach (TRSNode data in lisData)
            {
                if("MODULE".Equals(data.GetString("DATA_1")))
                    arrayList.Add(data.GetString("KEY_1"));
            }

            return arrayList;

        }

        #endregion

        private void btnSpreadExcelExport_Click2(object sender, EventArgs e)
        {
            try
            {
                if (soiRadioButton1.CheckedIndex == 0)
                {
                    btnSpreadExcelExport2.RunExport(soiSpreadImportSI);
                }
                else if (soiRadioButton1.CheckedIndex == 1)
                {
                    btnSpreadExcelExport2.RunExport(soiSpreadImportEL);
                }
                else
                {
                    MPCF.ShowMessage("Radio Index Error Please contact MES Team", MSG_LEVEL.ERROR, false);
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
       
    }
}
