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
using System.Text.RegularExpressions;

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm03 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel, Print Option
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCUSPeelTestInput : SOIBaseForm03
    {
        class PeelTestPK
        {
            public string factory,
                          line,
                          work_date,
                          work_time,
                          tab_no,
                          tb_lr,
                          type;
            public PeelTestPK(string factory, string line, string work_date, string work_time, string tab_no, string tb_lr, string type)
            {
                this.factory = factory;
                this.line = line;
                this.work_date = work_date;
                this.work_time = work_time;
                this.tab_no = tab_no;
                this.tb_lr = tb_lr;
                this.type = type;
            }
        }

        class PeelTestGroupInfo
        {
            public PeelTestPK pk;
            public int i_StartRow,
                       i_EndRow;
            public bool b_LeftValid,
                        b_RightValid;
            public int i_OutOfSpecificationEachColumn;
            public int i_OutOfSpecificationColumnCount;

            public PeelTestGroupInfo(PeelTestPK target)
            {
                this.pk = target;
                this.i_OutOfSpecificationEachColumn = 0;
                this.i_OutOfSpecificationColumnCount = 0;
                if (target.tb_lr == "L")
                {
                    this.b_LeftValid = true;
                }
                else if (pk.tb_lr == "R")
                {
                    this.b_RightValid = true;
                }
            }

            public bool equals(PeelTestPK target)
            {
                return MPCF.Trim(target.factory).Equals(this.pk.factory) &&
                    MPCF.Trim(target.work_date).Equals(this.pk.work_date) &&
                    MPCF.Trim(target.work_time).Equals(this.pk.work_time) &&
                    MPCF.Trim(target.line).Equals(this.pk.line) &&
                    MPCF.Trim(target.tab_no).Equals(this.pk.tab_no) &&
                    MPCF.Trim(target.tb_lr).Equals(this.pk.tb_lr) &&
                    MPCF.Trim(target.type).Equals(this.pk.type);
            }

            public bool checkSameGroup(PeelTestPK target)
            {
                return MPCF.Trim(target.factory).Equals(this.pk.factory) &&
                    MPCF.Trim(target.work_date).Equals(this.pk.work_date) &&
                    MPCF.Trim(target.work_time).Equals(this.pk.work_time) &&
                    MPCF.Trim(target.line).Equals(this.pk.line) &&
                    MPCF.Trim(target.tab_no).Equals(this.pk.tab_no) &&
                    MPCF.Trim(target.type).Equals(this.pk.type);
            }
        }

        struct PeelTestBaseInfo
        {
            public bool b_LOAD_SUCCESS;
            public int i_12BB_FR_ROW_CNT,
                       i_12BB_RE_ROW_CNT,
                       i_6BB_FR_ROW_CNT,
                       i_6BB_RE_ROW_CNT,
                       i_12BB_FR_OI_START_IDX,
                       i_12BB_RE_OI_START_IDX,
                       i_6BB_LANE_END_IDX,
                       i_6BB_FR_OI_START_IDX,
                       i_6BB_RE_OI_START_IDX,
                       i_6BB_RE_RS_START_IDX;
            public float f_FR_RE_PASS_CRITERIA,
                         f_REAR_SOLDER_LENGTH;

        }

        #region Property

        // (Required)
        private bool bIsShown = false;
        private bool m_bPeelTestPKError = false;
        private PeelTestBaseInfo stPeelTestBaseInfo;
        private List<PeelTestGroupInfo> m_listPeelTestGroup = new List<PeelTestGroupInfo>();

        #endregion

        #region Constructor

        public frmCUSPeelTestInput()
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

            MPCF.ShowMessage("v1.0.0", MSG_LEVEL.INFO, false);

            this.stPeelTestBaseInfo.b_LOAD_SUCCESS = true;
            if (!loadPassAndMaxLimitFromGCM())
            {
                this.stPeelTestBaseInfo.b_LOAD_SUCCESS = false;
            }

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

        private bool loadPassAndMaxLimitFromGCM()
        {
            TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
            TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
            TRSNode out_list;
            MPCF.SetInMsg(in_node);

            in_node.ProcStep = '1';
            in_node.AddString("FACTORY", "USGAM1");
            in_node.AddString("TYPE_1", "PEEL_TEST");
            int i;
            if (MPCF.CallService("CBAS", "CBAS_View_CGCMTBLDAT_List", in_node, ref out_node) == true)
            {
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];
                    String key = out_list.GetString("TYPE_2");
                    String value = out_list.GetString("DATA_1");
                    int i_result;
                    float d_result;

                    switch ( key )
                    {
                        case  "6BB_FR_ROW_CNT":
                            if (int.TryParse(value, out i_result))
                            {
                                this.stPeelTestBaseInfo.i_6BB_FR_ROW_CNT = i_result;
                            }
                            break;
                        case "6BB_RE_ROW_CNT":
                            if (int.TryParse(value, out i_result))
                            {
                                this.stPeelTestBaseInfo.i_6BB_RE_ROW_CNT = i_result;
                            }
                            break;
                        case "12BB_FR_ROW_CNT":
                            if (int.TryParse(value, out i_result))
                            {
                                this.stPeelTestBaseInfo.i_12BB_FR_ROW_CNT = i_result;
                            }
                            break;
                        case "12BB_RE_ROW_CNT":
                            if (int.TryParse(value, out i_result))
                            {
                                this.stPeelTestBaseInfo.i_12BB_RE_ROW_CNT = i_result;
                            }
                            break;
                        case "FR_RE_PASS_CRITERIA":
                            if (float.TryParse(value, out d_result))
                            {
                                this.stPeelTestBaseInfo.f_FR_RE_PASS_CRITERIA = d_result;
                            }
                            break;
                        case "REAR_SOLDER_LENGTH":
                            if (float.TryParse(value, out d_result))
                            {
                                this.stPeelTestBaseInfo.f_REAR_SOLDER_LENGTH = d_result;
                            }
                            break;
                        case "12BB_FR_OI_START_IDX":
                            if (int.TryParse(value, out i_result))
                            {
                                this.stPeelTestBaseInfo.i_12BB_FR_OI_START_IDX = i_result;
                            }
                            break;
                        case "12BB_RE_OI_START_IDX":
                            if (int.TryParse(value, out i_result))
                            {
                                this.stPeelTestBaseInfo.i_12BB_RE_OI_START_IDX = i_result;
                            }
                            break;
                        case "6BB_LANE_END_IDX":
                            if (int.TryParse(value, out i_result))
                            {
                                this.stPeelTestBaseInfo.i_6BB_LANE_END_IDX = i_result;
                            }
                            break;
                        case "6BB_RE_RS_START_IDX":
                            if (int.TryParse(value, out i_result))
                            {
                                this.stPeelTestBaseInfo.i_6BB_RE_RS_START_IDX = i_result;
                            }
                            break;
                        case "6BB_FR_OI_START_IDX":
                            if (int.TryParse(value, out i_result))
                            {
                                this.stPeelTestBaseInfo.i_6BB_FR_OI_START_IDX = i_result;
                            }
                            break;
                        case "6BB_RE_OI_START_IDX":
                            if (int.TryParse(value, out i_result))
                            {
                                this.stPeelTestBaseInfo.i_6BB_RE_OI_START_IDX = i_result;
                            }
                            break;                            
                        default:
                            break;
                    };
                }
            }
            return true;
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
                this.m_bPeelTestPKError = false;

                if (!this.stPeelTestBaseInfo.b_LOAD_SUCCESS)
                {
                    MPCF.ShowMessage("Load Pass/Fail and Limit GCM Info Fetch failed!!", MSG_LEVEL.ERROR, false);
                    return;
                }

                if (!importExcel())
                {
                    this.btnProcess.Enabled = false;
                    return;
                }
                else
                {
                    this.btnProcess.Enabled = true;
                    MPCF.ShowMessage("Data Import success!!", MSG_LEVEL.INFO, false);
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
            finally
            {
                soiSpreadImport.Visible = false;
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
                btnSpreadExcelExport.RunExport(soiSpreadExportFormat);

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }     
        #endregion


        public enum PL_LIST
        {
            FACTORY,
            WORK_DATE,
            TIME,
            TYPE,
            LINE_ID,
            TAB_NO,
            TB_LR,
            POS,
            POS_FR_1,
            POS_FR_2,
            POS_FR_3,
            POS_FR_4,
            POS_FR_5,
            POS_FR_6,
            POS_FR_7,
            POS_FR_8,
            POS_FR_9,
            POS_FR_10,
            POS_FR_11,
            POS_FR_12,
            POS_RE_1,
            POS_RE_2,
            POS_RE_3,
            POS_RE_4,
            POS_RE_5,
            POS_RE_6,
            POS_RE_7,
            POS_RE_8,
            POS_RE_9,
            POS_RE_10,
            POS_RE_11,
            POS_RE_12
        }

        

        //라디오 버튼 선택
        private void soiRadioButton1_ValueChanged(object sender, EventArgs e)
        {
            if (soiRadioButton1.CheckedIndex == 0)
            {
                soiGroupBox15.Text = "Peel Off Test Result (6BB)";
            }
            else if (soiRadioButton1.CheckedIndex == 1)
            {
                soiGroupBox15.Text = "Peel Off Test Result (12BB)";
            }
            else
            {
                MPCF.ShowMessage("Radio Index Error Please contact MES Team", MSG_LEVEL.ERROR, false);
            }

            initPeelDataGrid();

        }

        private void initPeelDataGrid()
        {
            soiSpread1.Sheets[0].Columns.Clear();
            soiSpread1.Sheets[0].Rows.Clear();
            soiSpread1.Sheets[0].Columns.Add(0, Enum.GetNames(typeof(PL_LIST)).Length);

            string title;
            float size;
            for (int i = 0; i < Enum.GetNames(typeof(PL_LIST)).Length; i++)
            {
                title = soiSpreadExportFormat.Sheets[0].Cells[0, i].Value.ToString();
                size = soiSpreadExportFormat.Sheets[0].Columns[i].Width;

                soiSpread1.Sheets[0].ColumnHeader.Cells[0, i].Text = title;
                soiSpread1.Sheets[0].Columns[i].Width = size;
            }
        }
        
        //날짜검증
        private bool isYYYYMMDD(string date)
        {
            if ( !Regex.IsMatch(date, @"^(19[7-9][0-9]|20\d{2})(0[1-9]|1[0-2])(0[1-9]|[1-2][0-9]|3[0-1])$") )
                return false;
            return true;

        }

        //시간검증
        private bool isHH24MI(string time)
        {
            return Regex.IsMatch(time, @"^(0[0-9]|1[0-9]|2[0-3])([0-5][0-9])$");

        }

       
        //컬럼 형식 검증
        private bool validateColumnFormat()
        {
            //check column format
            for (int x = 0; x < Enum.GetNames(typeof(PL_LIST)).Length; x++)
            {
                if (!soiSpread1.Sheets[0].Columns[x].Label.Equals(soiSpreadImport.Sheets[0].Cells[0, x].Value))
                {
                    MPCF.ShowMessage(String.Format("The Excel Format is different. Please Check {0}({1}) Column name", soiSpreadImport.Sheets[0].Cells[0, x].Value, (x + 1)), MSG_LEVEL.ERROR, false);
                    return false;
                }
            }


            return true;
        }

        //BB유형 검증( 3번째 컬럼 )
        private bool validateBBType(int row, int col, string cellValue) 
        {
            if (!cellValue.Equals("6") && !cellValue.Equals("12") ) 
            {
                soiSpread1.ActiveSheet.Cells[row - 1, col].Note = "Please enter relevant type: either 6 or 12.";
                return false;
            }

            if (soiRadioButton1.CheckedIndex == 0)
            {
                if (cellValue == "12")
                {
                    soiSpread1.ActiveSheet.Cells[row-1, col].Note = "6BB is selected. But, data is 12BB";
                    return false;
                }
            }
            else
            {
                if (cellValue == "6")
                {
                    soiSpread1.ActiveSheet.Cells[row - 1, col].Note = "12BB is selected. But, data is 6BB"; 
                    return false;
                }
            }
            return true;
        }

        //숫자여부/Null 값 여부 검증
        private bool validateNumber(PeelTestGroupInfo item, int row, int col, string cellValue, string colPrefix, int min, int max, int decPoint, float limitValue, bool bAllowEmpty)
        {
            if (bAllowEmpty && cellValue.Trim().Length <= 0)
                return true;

            float result;

            NumberStyles style = NumberStyles.Number | NumberStyles.AllowDecimalPoint;
            if (float.TryParse(cellValue, style, CultureInfo.InvariantCulture, out result) == false)
            {
                soiSpread1.ActiveSheet.Cells[row - 1, col].Note = colPrefix + min + " to " + colPrefix + max + "'s value should be numeric.";
                return false;
            }
            if (result < 0 || cellValue.Trim().Length <= 0)
            {
                soiSpread1.ActiveSheet.Cells[row - 1, col].Note = "Numeric value should be greater than or equal to 0.";
                return false;
            }

            //if (decPoint == 1)
            //{
            //    cellValue = string.Format("{0:0.0}", result);
            //    soiSpread1.ActiveSheet.Cells[row - 1, col].Tag = cellValue;
            //}
            //else if (decPoint == 2)
            //{
            //    cellValue = string.Format("{0:0.00}", result);
            //    soiSpread1.ActiveSheet.Cells[row - 1, col].Tag = cellValue;
            //}

            int posPoint = cellValue.IndexOf(".");
            if ( posPoint > 0 && cellValue.Length - posPoint > 2 ) 
            {
                soiSpread1.ActiveSheet.Cells[row - 1, col].Note = "Please check the decimal places. You should only enter up to 1 decimal point.";
                return false;
            }
            if ( result < limitValue)
            {
                soiSpread1.ActiveSheet.Cells[row - 1, col].BackColor = Color.FromArgb(50, 255, 165, 0);
                soiSpread1.ActiveSheet.Cells[row - 1, col].ForeColor = Color.Red;
                String msg = String.Format("Pass: {0:F1} or above {0:F1} | Fail: Below {0:F1}", limitValue);
                soiSpread1.ActiveSheet.Cells[row - 1, col].Note = msg;
                item.i_OutOfSpecificationEachColumn++;
            }
            return true;
        }

        //문자여부/Null 값 여부 검증
        private bool validateCharacter(int row, int col, string cellValue, string colPrefix, int min, int max)
        {
            int result;
            int.TryParse(cellValue, out result);

            if (cellValue.Length >= 1 && ((int)cellValue[0] >= 97 && (int)cellValue[0] <= 122))
            {
                cellValue = cellValue.ToUpper();
                soiSpread1.ActiveSheet.Cells[row - 1, col].Tag = cellValue.ToUpper();
            }
            

            if (cellValue.Length >= 1 && ((int)cellValue[0] < 65 || (int)cellValue[0] > 90))
            {
                //colPrefix + min + " to " + colPrefix + (max - 1) + " should be A to Z character Only";
                soiSpread1.ActiveSheet.Cells[row - 1, col].Note = "Optimal Inspection result should only be in character (A to Z).";
                return false;
            }

            if (cellValue.Trim().Length <= 0)
            {
                soiSpread1.ActiveSheet.Cells[row - 1, col].Note = "A to Z character Only"; 
                return false;
            }

            return true;
        }

        //값이 없는 빈 셀 검증
        private bool validateBeEmpty(int row, int col, string cellValue, string colPrefix, int min, int max)
        {
            if (cellValue.Length > 0)
            {
                soiSpread1.ActiveSheet.Cells[row - 1, col].Note = colPrefix + min + " to " + colPrefix + max + " should be empty";
                return false;
            }
            return true;
        }

        //값이 있는 셀 검증
        private bool validateNotBeEmpty(int row, int col, string cellValue, string colPrefix, int min, int max)
        {
            if (cellValue.Trim().Length <= 0)
            {
                soiSpread1.ActiveSheet.Cells[row - 1, col].Note = colPrefix + min + " to " + colPrefix + max + " should not be empty";
                return false;
            }

            return true;
        }
        
        //LINE ID 검증
        private bool validateLineID(int row, int col, string cellValue)
        {
            if (!cellValue.Trim().Equals("MDL01") &&
                !cellValue.Trim().Equals("MDL02") &&
                !cellValue.Trim().Equals("MDL03") )
            {
                soiSpread1.ActiveSheet.Cells[row - 1, col].Note = "Please enter relevant line id: from MDL01 - MDL03.";
                return false;
            }

            return true;
        }

        //TAB NO 검증
        private bool validateTabNo(int row, int col, string cellValue)
        {
            float result;

            NumberStyles style = NumberStyles.Number | NumberStyles.AllowDecimalPoint;
            if (( float.TryParse(cellValue, style, CultureInfo.InvariantCulture, out result) == false)  || 
                (  result > 12 || result < 1 ) )
            {
                soiSpread1.ActiveSheet.Cells[row - 1, col].Note = "Please enter relevant Tabber Equipment Number: from 1 - 12.";
                return false;
            }

            return true;
        }



        //TB_LR 검증
        private bool validateTbLR(int row, int col, string cellValue)
        {
            if (!cellValue.Trim().Equals("L") && 
                !cellValue.Trim().Equals("R")  )
            {
                soiSpread1.ActiveSheet.Cells[row - 1, col].Note = "Please enter relevant Tabber side: either L or R.";
                return false;
            }

            return true;
        }

        private bool validateCommonArea(PeelTestGroupInfo item, int rowGroup, int row, int col, string cellValue)
        {
            switch (col)
            {
                //work_date
                case 0:
                    if (cellValue != "USGAM1")
                        return false;
                    break;
                //work_date
                case 1:
                    if (!isYYYYMMDD(cellValue))
                    {
                        soiSpread1.ActiveSheet.Cells[row - 1, col].Note = cellValue + " is not a valid work date format. A valid work date should be in YYYYMMDD format (20220101).";
                        return false;
                    }
                    break;
                //time
                case 2:
                    if (!isHH24MI(cellValue))
                    {
                        soiSpread1.ActiveSheet.Cells[row - 1, col].Note = cellValue + " is not a valid time format. A valid  time should be in HH24MI format (1135 or 1730).";
                        return false;
                    }
                    break;
                //type
                case 3:
                    if (!validateBBType(row, col, cellValue))
                        return false;
                    break;
                //type
                case 4:
                    if (!validateLineID(row, col, cellValue))
                        return false;
                    break;
                //type
                case 5:
                    if (!validateTabNo(row, col, cellValue))
                        return false;
                    break;
                //type
                case 6:
                    if (!validateTbLR(row, col, cellValue))
                        return false;
                    break;
                default:
                    break;
            }
            return true;
        }

        //Front Area 데이터 검증
        private bool validateFrontExcelData(PeelTestGroupInfo item, int rowGroup, int row, int col, string cellValue)
        {
            int laneRearXMinPos = 20;
            int laneFrontMinXPos = soiRadioButton1.CheckedIndex == 0 ? 8 : 8;
            int laneFrontMaxXPos = soiRadioButton1.CheckedIndex == 0 ? 13 : 19;
            int laneFrontPosYCount = soiRadioButton1.CheckedIndex == 0 ?
                rowGroup + this.stPeelTestBaseInfo.i_6BB_FR_OI_START_IDX - 1 : rowGroup + this.stPeelTestBaseInfo.i_12BB_FR_OI_START_IDX - 1;
            int posMaxYCount = soiRadioButton1.CheckedIndex == 0 ? rowGroup + this.stPeelTestBaseInfo.i_6BB_FR_ROW_CNT : rowGroup + this.stPeelTestBaseInfo.i_12BB_FR_ROW_CNT;
            string colName = "POS_FR_";
           
            if (row >= 0 + rowGroup && row < laneFrontPosYCount)
            {
                if (col >= laneFrontMinXPos && col <= laneFrontMaxXPos)
                {
                    if (!validateNumber(item, row, col, cellValue, colName, 1, laneFrontMaxXPos - laneFrontMinXPos +1, 2, this.stPeelTestBaseInfo.f_FR_RE_PASS_CRITERIA, false ))
                        return false;
                }
                else if (col > laneFrontMaxXPos && col < laneRearXMinPos )
                {
                    if (!validateBeEmpty(row, col, cellValue, colName, laneFrontMaxXPos - laneFrontMinXPos + 1, 12))
                        return false;
                }
            }
            else if (row >= laneFrontPosYCount && row <= posMaxYCount ) 
            {
                if (col >= laneFrontMinXPos && col <= laneFrontMaxXPos )
                {
                    if (!validateCharacter(row, col, cellValue, colName, 1, laneFrontMaxXPos - laneFrontMinXPos))
                        return false;
                }
                else if ( (col > laneFrontMaxXPos && col < laneRearXMinPos)  &&  soiRadioButton1.CheckedIndex == 0 )
                {
                    if (!validateBeEmpty(row, col, cellValue, colName, 12 - laneFrontMaxXPos, 12))
                        return false;
                }
            }
            else if (row > posMaxYCount)
            {
                soiSpread1.ActiveSheet.Cells[row - 1, col].Note = posMaxYCount + " rows is Maxium."; 
                return false;
            }
            return true;
        }

        //Rear Area 데이터 검증
        private bool validateRearExcelData(PeelTestGroupInfo item, int rowGroup, int row, int col, string cellValue)
        {
            int laneRearXMinPos = 20;
            int laneRearYMaxPos = rowGroup + 4;
            int laneRearXMaxPos = soiRadioButton1.CheckedIndex == 0 ? 25 : 32;
            int posMaxYCount = soiRadioButton1.CheckedIndex == 0 ? rowGroup + this.stPeelTestBaseInfo.i_6BB_FR_ROW_CNT : 
                rowGroup + this.stPeelTestBaseInfo.i_12BB_FR_ROW_CNT; 
            
            string colName = "POS_RE_";

            if (col < laneRearXMinPos || row < 1 ) 
                return true;

            if (this.m_bPeelTestPKError)
                return false;

            if (soiRadioButton1.CheckedIndex == 0)
            {
                if (row >= rowGroup && row < laneRearYMaxPos && col <= laneRearXMaxPos)
                {
                    if (!validateNumber(item, row, col, cellValue, colName, 1, laneRearXMaxPos - laneRearXMinPos + 1, 2, this.stPeelTestBaseInfo.f_FR_RE_PASS_CRITERIA, false))
                        return false;
                }
                else if (row >= laneRearYMaxPos && row < laneRearYMaxPos + 4 && col <= laneRearXMaxPos )
                {
                    if (!validateBeEmpty(row, col, cellValue, colName, 1, laneRearXMaxPos - laneRearXMinPos + 1))
                        return false;
                }
                else if (row >= laneRearYMaxPos + 4 && row < laneRearYMaxPos + 8 && col <= laneRearXMaxPos)
                {
                    if (!validateCharacter(row, col, cellValue, colName, 12 - laneRearXMinPos, 12))
                        return false;
                }
                else if (row >= laneRearYMaxPos + 8 && row < laneRearYMaxPos + 12 && col <= laneRearXMaxPos)
                {
                    //&&!validateBeEmpty(row, col, cellValue, colName, 1, laneRearXMaxPos - laneRearXMinPos + 1)
                    if ( !validateNumber(item, row, col, cellValue, colName, 1, laneRearXMaxPos - laneRearXMinPos, 1, this.stPeelTestBaseInfo.f_REAR_SOLDER_LENGTH, true) )
                        return false;
                }
                if (col > laneRearXMaxPos)
                {
                    if (!validateBeEmpty(row, col, cellValue, colName, laneRearXMaxPos, 32))
                        return false;
                }
            } else if (soiRadioButton1.CheckedIndex == 1)
            {
                if (row >= rowGroup && row < laneRearYMaxPos)
                {
                    if (!validateNumber(item, row, col, cellValue, colName, 1, laneRearXMaxPos - laneRearXMinPos, 2, this.stPeelTestBaseInfo.f_FR_RE_PASS_CRITERIA,false))
                        return false;
                }
                else if (row >= laneRearYMaxPos && row < laneRearYMaxPos + 4 )
                {
                    if (!validateCharacter(row, col, cellValue, colName, 1, 12))
                        return false;
                }
                else if (row >= laneRearYMaxPos + 4 )
                {
                    if (!validateBeEmpty(row, col, cellValue, colName, 1, 12))
                        return false;
                }
            }

            return true;

        }
        
        //Rear Area 데이터 검증
        private bool validateSpecification()
        {
            int limitRearSpecification = soiRadioButton1.CheckedIndex == 0 ? 2 : 2;
            int limitFrontSpecification = soiRadioButton1.CheckedIndex == 0 ? 3 : 3;
            int laneRearXMaxPos = soiRadioButton1.CheckedIndex == 0 ? 25 : 32;
            int laneFrontMaxXPos = soiRadioButton1.CheckedIndex == 0 ? 13 : 19;
            int laneMinXPos = soiRadioButton1.CheckedIndex == 0 ? 8 : 8;
            int i_OutofSpecification = 0;

            foreach (PeelTestGroupInfo item in m_listPeelTestGroup)
            {
                for (int col = laneMinXPos; col < laneFrontMaxXPos; col++)
                {
                    i_OutofSpecification = 0;
                    for (int row = item.i_StartRow-1; row < item.i_EndRow; row++)
                    {
                        String note = soiSpread1.ActiveSheet.Cells[row, col].Note;
                        String value = (string)soiSpread1.ActiveSheet.Cells[row, col].Value;
                        if (note.Length > 0) 
                            i_OutofSpecification++;
                    }
                    if (i_OutofSpecification >= limitFrontSpecification)
                        return false;
                }


                for (int col = laneFrontMaxXPos ; col < laneRearXMaxPos; col++)
                {
                    i_OutofSpecification = 0;
                    for (int row = item.i_StartRow-1; row < item.i_EndRow; row++)
                    {
                        String note = soiSpread1.ActiveSheet.Cells[row, col].Note;
                        String value = (string)soiSpread1.ActiveSheet.Cells[row, col].Value;
                        if (note.Length > 0) 
                            i_OutofSpecification++;
                    }
                    if (i_OutofSpecification >= limitRearSpecification)
                        return false;
                }
            }
            return true;
        }
        private PeelTestPK getPeelTestPKInfo(int row)
        {

            string factory = MPCF.Trim(soiSpreadImport.Sheets[0].Cells[row, (int)PL_LIST.FACTORY].Value.ToString());
            string line = MPCF.Trim(soiSpreadImport.Sheets[0].Cells[row, (int)PL_LIST.LINE_ID].Value.ToString());
            string work_date = MPCF.Trim(soiSpreadImport.Sheets[0].Cells[row, (int)PL_LIST.WORK_DATE].Value.ToString());
            string work_time = MPCF.Trim(soiSpreadImport.Sheets[0].Cells[row, (int)PL_LIST.TIME].Value.ToString());
            string tab_no = MPCF.Trim(soiSpreadImport.Sheets[0].Cells[row, (int)PL_LIST.TAB_NO].Value.ToString());
            string tb_lr = MPCF.Trim(soiSpreadImport.Sheets[0].Cells[row, (int)PL_LIST.TB_LR].Value.ToString());
            string type = MPCF.Trim(soiSpreadImport.Sheets[0].Cells[row, (int)PL_LIST.TYPE].Value.ToString());

            return new PeelTestPK(factory, line, work_date, work_time, tab_no, tb_lr, type ); 
        }

        //import 데이터에 대한 grouping정보 생성
        private bool checkImportDataGrouping()
        {
            int row = 1;

            for (int inx = this.m_listPeelTestGroup.Count - 1; inx >=0 ; inx--) 
            {
                this.m_listPeelTestGroup.RemoveAt(inx);
            }

            PeelTestGroupInfo currentGroup = new PeelTestGroupInfo(getPeelTestPKInfo(row));
            currentGroup.i_StartRow = 1;
            this.m_listPeelTestGroup.Add(currentGroup);

            while (true)
            {
                //현재 그리드의 로우 추가
                if (soiSpreadImport.Sheets[0].Cells[row, 0].Value == null ||
                    String.IsNullOrEmpty(soiSpreadImport.Sheets[0].Cells[row, 0].Value.ToString()))
                {
                    break;
                }
                PeelTestPK pk = getPeelTestPKInfo(row);
                if (!currentGroup.equals(pk))
                {
                    currentGroup.i_EndRow = row - 1;
                    currentGroup = new PeelTestGroupInfo(getPeelTestPKInfo(row));
                    currentGroup.i_StartRow = row;
                    this.m_listPeelTestGroup.Add(currentGroup);
                }

                row++;

            }
            currentGroup.i_EndRow = row - 1;

            //Left, Right 존재 여부 확인
            foreach (PeelTestGroupInfo item in m_listPeelTestGroup)
            {
                foreach (PeelTestGroupInfo item1 in m_listPeelTestGroup)
                {
                    if (item.checkSameGroup(item1.pk) ) 
                    {
                        if (item.b_LeftValid && item1.b_RightValid)
                            item.b_RightValid = true;
                        else if (item.b_RightValid && item1.b_LeftValid)
                            item.b_LeftValid = true;
                    }
                }
            }

            return true;
        }


        //엑셀 Import
        private bool importExcel()
        {
            int mismatchCount = 0;
            string cellValue;

            btnSpreadImportExcel.RunImport(soiSpreadImport);

            if (!validateColumnFormat())
                return false;
           
            if (!checkImportDataGrouping())
            {
                return false;
            }

            soiSpread1.Sheets[0].Rows.Clear();
            foreach (PeelTestGroupInfo item in m_listPeelTestGroup)
            {
                for (int row = item.i_StartRow; row <= item.i_EndRow; row++)
                {
                    //현재 그리드의 로우 추가
                    if (soiSpreadImport.Sheets[0].Cells[row, 0].Value == null)
                    {
                        break;
                    }
                    if (String.IsNullOrEmpty(soiSpreadImport.Sheets[0].Cells[row, 0].Value.ToString()))
                    {
                        break;
                    }

                    soiSpread1.Sheets[0].RowCount++;

                    for (int x = 0; x < Enum.GetNames(typeof(PL_LIST)).Length; x++)
                    {
                        if (soiSpreadImport.Sheets[0].Cells[row, x].Value == null)
                        {
                            cellValue = " ";
                        }
                        else
                        {
                            cellValue = soiSpreadImport.Sheets[0].Cells[row, x].Value.ToString();
                        }
                        cellValue = MPCF.Trim(cellValue);
                        cellValue = cellValue.Replace("\n", "");
                        cellValue = cellValue.Replace("\r", "");

                        soiSpread1.ActiveSheet.Cells[row - 1, x].Tag = "";
                        soiSpread1.ActiveSheet.Cells[row - 1, x].ForeColor = Color.White;

                        if (!validateCommonArea(item, item.i_StartRow, row, x, cellValue))
                        {
                            soiSpread1.ActiveSheet.Cells[row - 1, x].BackColor = Color.Red;
                            soiSpread1.ActiveSheet.Cells[row - 1, x].ForeColor = Color.White;
                            ++mismatchCount;
                            this.m_bPeelTestPKError = true;
                        }

                        if (!this.m_bPeelTestPKError)
                        {
                            if (!validateFrontExcelData(item, item.i_StartRow, row, x, cellValue) ||
                                !validateRearExcelData(item, item.i_StartRow, row, x, cellValue))
                            {
                                soiSpread1.ActiveSheet.Cells[row - 1, x].BackColor = Color.Red;
                                soiSpread1.ActiveSheet.Cells[row - 1, x].ForeColor = Color.White;
                                ++mismatchCount;
                            }

                            
                            if ((!item.b_LeftValid || !item.b_RightValid) && (x == (int)PL_LIST.TB_LR))
                            {
                                soiSpread1.ActiveSheet.Cells[row - 1, x].BackColor = Color.Red;
                                soiSpread1.ActiveSheet.Cells[row - 1, x].ForeColor = Color.White;
                                if (!item.b_LeftValid)
                                {
                                    soiSpread1.ActiveSheet.Cells[row - 1, x].Note = "Left Value was not found. check TB_LR Left Value.";
                                }
                                else if (!item.b_RightValid)
                                {
                                    soiSpread1.ActiveSheet.Cells[row - 1, x].Note = "Right Value was not found. check TB_LR Right Value.";
                                }

                                ++mismatchCount;
                            }
                        }
                        if ((string)(soiSpread1.ActiveSheet.Cells[row - 1, x]).Tag != "")
                        {
                            soiSpread1.Sheets[0].Cells[row - 1, x].Value = soiSpread1.Sheets[0].Cells[row - 1, x].Tag;
                        }
                        else
                        {
                            soiSpread1.Sheets[0].Cells[row - 1, x].Value = cellValue;
                        }
                    }
                }

            }
            if (mismatchCount > 0)
            {
                MPCF.ShowMessage( "Total number of " + mismatchCount + " data is not valid. Please click the colored cell to navigate the issue.", MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            TRSNode out_node = new TRSNode("OUT_NODE");

            if (!validateSpecification())
            {
                MPCF.ShowMessage("Out of specification.", MSG_LEVEL.WARNING, false);
                return;
            }
            
            if (soiSpread1.ActiveSheet.RowCount < 1)
            {
                MPCF.ShowMessage("No data to process", MSG_LEVEL.ERROR, false);
                return;
            }

            btnProcess.Enabled = false;

            foreach (PeelTestGroupInfo item in m_listPeelTestGroup)
            {
                sendPeelDataInfo(item.i_StartRow, item.i_EndRow, out_node);
            }
            
            soiSpread1.Sheets[0].Rows.Clear();
            MPCF.ShowSuccessMessage(out_node, true);

            btnProcess.Enabled = true;
        }

        private void sendPeelDataInfo(int rowStart, int rowEnd, TRSNode out_node)
        {
            TRSNode peelList;

            string line_id = string.Empty;
            string sim_result = string.Empty;

            try
            {
                TRSNode in_node = new TRSNode("IN_NODE");
                in_node.ProcStep = 'I';
                in_node.AddString("FACTORY", "USGAM1");

                for (int i = rowStart-1; i < rowEnd; i++)
                {
                    peelList = in_node.AddNode("PEEL_LIST");
                    peelList.ProcStep = 'I';
                    peelList.AddString("FACTORY", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.FACTORY].Value.ToString()));
                    peelList.AddString("WORK_DATE", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.WORK_DATE].Value.ToString()));
                    peelList.AddString("WORK_TIME", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.TIME].Value.ToString()));
                    peelList.AddString("TYPE", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.TYPE].Value.ToString()));
                    peelList.AddString("LINE_ID", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.LINE_ID].Value.ToString()));
                    peelList.AddInt("TAB_NO", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.TAB_NO].Value));
                    peelList.AddString("LR", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.TB_LR].Value.ToString()));
                    peelList.AddInt("POS", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS].Value));
                    peelList.AddString("POS_FR_1", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_FR_1].Value.ToString()));
                    peelList.AddString("POS_FR_2", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_FR_2].Value.ToString()));
                    peelList.AddString("POS_FR_3", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_FR_3].Value.ToString()));
                    peelList.AddString("POS_FR_4", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_FR_4].Value.ToString()));
                    peelList.AddString("POS_FR_5", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_FR_5].Value.ToString()));
                    peelList.AddString("POS_FR_6", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_FR_6].Value.ToString()));
                    peelList.AddString("POS_FR_7", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_FR_7].Value.ToString()));
                    peelList.AddString("POS_FR_8", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_FR_8].Value.ToString()));
                    peelList.AddString("POS_FR_9", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_FR_9].Value.ToString()));
                    peelList.AddString("POS_FR_10", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_FR_10].Value.ToString()));
                    peelList.AddString("POS_FR_11", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_FR_11].Value.ToString()));
                    peelList.AddString("POS_FR_12", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_FR_12].Value.ToString()));
                    peelList.AddString("POS_RE_1", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_RE_1].Value.ToString()));
                    peelList.AddString("POS_RE_2", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_RE_2].Value.ToString()));
                    peelList.AddString("POS_RE_3", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_RE_3].Value.ToString()));
                    peelList.AddString("POS_RE_4", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_RE_4].Value.ToString()));
                    peelList.AddString("POS_RE_5", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_RE_5].Value.ToString()));
                    peelList.AddString("POS_RE_6", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_RE_6].Value.ToString()));
                    peelList.AddString("POS_RE_7", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_RE_7].Value.ToString()));
                    peelList.AddString("POS_RE_8", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_RE_8].Value.ToString()));
                    peelList.AddString("POS_RE_9", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_RE_9].Value.ToString()));
                    peelList.AddString("POS_RE_10", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_RE_10].Value.ToString()));
                    peelList.AddString("POS_RE_11", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_RE_11].Value.ToString()));
                    peelList.AddString("POS_RE_12", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)PL_LIST.POS_RE_12].Value.ToString()));
                    peelList.AddString("INS_USER_ID", MPGV.gsUserID);
                    // 정상 처리 파란색 처리
                    soiSpread1.ActiveSheet.Rows[i].BackColor = Color.Blue;
                    soiSpread1.ActiveSheet.SetActiveCell(i, 0);
                    soiSpread1.ShowRow(0, i, FarPoint.Win.Spread.VerticalPosition.Nearest);
                }

                if (MPCF.CallService("CWIP", "CWIP_Collect_Peel_Test_Data", in_node, ref out_node) == false)
                {
                    string strErrorType = out_node.GetString("ERROR_TYPE");

                    TRSNode FieldMsg = out_node.FieldMsg;
                    string strErrorMsg = "";
                    string strErrorMsgTemp;
                    for (int MemberIndex = 0; FieldMsg.MemberCount > MemberIndex; MemberIndex++)
                    {
                        strErrorMsgTemp = "KEY : " + FieldMsg.Members[MemberIndex].Name + " / VALUE : " + FieldMsg.Members[MemberIndex].Value + "\r\n";
                        strErrorMsg += strErrorMsgTemp;
                    }

                    MPCF.ShowSuccessMessage(out_node, false);

                    return;
                }
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

            if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
            {
                return arrayList;
            }

            List<TRSNode> lisData = out_node.GetList("DATA_LIST");
            foreach (TRSNode data in lisData)
            {
                arrayList.Add(data.GetString("KEY_1"));
            }

            return arrayList;

        }

        #endregion

        private void btnSpreadExcelExport_Click2(object sender, EventArgs e)
        {
            try
            {
                btnSpreadExcelExport2.RunExport(soiSpreadImport);

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void soiSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            string msg = ((SOI.OIFrx.SOIControls.SOISpread)sender).ActiveSheet.Cells[e.Row, e.Column].Note;
            if (msg.Length <= 0) 
            {
                MPCF.ShowMessage("v1.0.0", MSG_LEVEL.INFO, false);
            } else 
            {
                MPCF.ShowMessage( msg, MSG_LEVEL.ERROR, false);
            }
        }

       
    }
}
