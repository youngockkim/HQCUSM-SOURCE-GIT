using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.OIFrx.SOIBaseForm;
using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.CliFrx;
using SOI.OIFrx.SOIModel;
using System.Globalization;

namespace SOI.HanwhaQcell.USModule
{
    public partial class frmCUSLaminatorPullTest : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCUSLaminatorPullTest()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        public int MAX_ROW_COUNT = 16;
        public int DATA_MAX_COLUMN_COUNT = 16;
        public int MAX_MODULE_COUNT = 4;
        public int PULLTEST_PART_GLASS = 3001;
        public int PULLTEST_PART_BACKSHEET = 3002;

        public double GLASS_LOW_LIMIT = 100;
        public double BACKSHEET_LOW_LIMIT = 70;

        public string chk_type;
        public string chk_auto_validation;
        public string chk_auto;
        public enum DATA_LIST
        {
            DATE_TITLE,
            DATE_CONTROL,
            SMPL_DATE,
            MSMT_DATE,
            RES_ID,
            MODULE_NO,
            GLASS_B1,
            GLASS_B2,
            GLASS_B3,
            GLASS_B4,
            GLASS_B5,
            GLASS_B6,
            GLASS_B7,
            GLASS_B8,
            BACK_B1,
            BACK_B2,
            BACK_B3,
            BACK_B4,
            BACK_B5,
            BACK_B6,
            BACK_B7,
            BACK_B8,
        }

        #endregion

        #region [Variable Definition]

        #endregion

        #region Event Handler

        private void frmCUSLaminatorPullTest_Load(object sender, EventArgs e)
        {
            // Init
            dtpDate.Value = DateTime.Now;

            MPCF.ConvertCaption(this);

            getLineLocationList();

        }


        private void frmCUSLaminatorPullTest_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                MPCF.SetFocus(dtpDate);

                bIsShown = true;
            }
        }

        private void btnToExcelModules_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog pop = new SaveFileDialog();
                pop.InitialDirectory = "C:\\";

                pop.FileName = MPCF.Trim(lblFormTitle.Text) + "_" + MPCF.Trim(grpScrapList.Text) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                pop.Filter = "Excel Files(*.xls)|*.xls|All files(*.*)|*.*";
                pop.FilterIndex = 1;

                if (pop.ShowDialog() == DialogResult.OK)
                {
                    spdPullTest.Sheets[0].Protect = false;
                    spdPullTest.SaveExcel(pop.FileName, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders);
                    spdPullTest.Sheets[0].Protect = true;
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
                if (CheckCondition("VIEW") == false)
                {
                    return;
                }

                if (ViewPullTestList() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (CheckCondition("UPDATE") == false)
                {
                    return;
                }

                if (UpdatePullTest(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }

                // Refresh
                btnView.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }



        #endregion

        #region Function

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "VIEW":

                        if (MPCF.CheckValue(cboLineLocation, false) == false)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(595), MSG_LEVEL.ERROR, false);
                            return false;
                        }
                        if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(411), MSG_LEVEL.ERROR, false);
                            return false;
                        }

                        break;

                    case "UPDATE":

                        if (MPCF.CheckValue(cboLineLocation, false) == false)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(595), MSG_LEVEL.ERROR, false);
                            return false;
                        }

                        if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(411), MSG_LEVEL.ERROR, false);
                            return false;
                        }

                        break;
                    case "APPEND":

                        if (MPCF.CheckValue(cboLineLocation, false) == false)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(595), MSG_LEVEL.ERROR, false);
                            return false;
                        }
                        if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(411), MSG_LEVEL.ERROR, false);
                            return false;
                        }

                        break;

                    case "DELETE":


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

        private void validateData()
        {
            for (int row = 0; row < spdPullTest.Sheets[0].Rows.Count; row++)
            {
                for (int col = (int)DATA_LIST.GLASS_B1; col <= (int)DATA_LIST.BACK_B8; col++)
                {
                    if (spdPullTest.ActiveSheet.Cells[row, col].Value == null)
                        continue;
                    validateLimit(row, col, (double)spdPullTest.ActiveSheet.Cells[row, col].Value);
                }
            }
        }

        private void validateLimit(int row, int col, double value)
        {
            if (value > 0)
            {
                spdPullTest.ActiveSheet.Cells[row, col].ForeColor = Color.White;
            }
            else
            {
                spdPullTest.ActiveSheet.Cells[row, col].ForeColor = Color.Red;
            }
            // limit를 추후 체크하는  경우 대비하여 여기서 리턴 처리
            return;

            if (col >= (int)DATA_LIST.GLASS_B1 && col <= (int)DATA_LIST.GLASS_B8)
            {
                if (value < GLASS_LOW_LIMIT)
                {
                    spdPullTest.ActiveSheet.Cells[row, col].ForeColor = Color.Red;
                }
                else
                {
                    spdPullTest.ActiveSheet.Cells[row, col].ForeColor = Color.White;
                }
            }
            else if (col >= (int)DATA_LIST.BACK_B1 && col <= (int)DATA_LIST.BACK_B8 + 1)
            {
                if (value < BACKSHEET_LOW_LIMIT)
                {
                    spdPullTest.ActiveSheet.Cells[row, col].ForeColor = Color.Red;
                }
                else
                {
                    spdPullTest.ActiveSheet.Cells[row, col].ForeColor = Color.White;
                }
            }

        }

        private bool ViewPullTestList()
        {
            try
            {
                int i;
                int row = 0;
                DateTime dtpFromDateTimeOut = new DateTime();

                clearData();

                TRSNode in_node = new TRSNode("VIEW_SHIFT_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_SHIFT_LIST_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (dtpDate.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpDate.Value.ToString(), out dtpFromDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("MSMT_DATE", dtpFromDateTimeOut.ToString("yyyyMMdd"));
                    }
                }
                in_node.AddString("LINE_ID", MPCF.Trim(this.cdvLineID.Code));

                if (MPCF.CallService("CWIP", "CWIP_View_Laminator_Pull_Test_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];
                    if ((PULLTEST_PART_GLASS.ToString()).CompareTo(out_list.GetString("PART_TYPE")) == 0)
                    {
                        spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.MSMT_DATE].Value = out_list.GetString("MSMT_DATE");
                        spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.MODULE_NO].Value = out_list.GetInt("MODULE_NO");
                        spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.RES_ID].Value = out_list.GetString("RES_ID");
                        spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.SMPL_DATE].Value = out_list.GetString("SMPL_DATE");
                        spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.GLASS_B1].Value = out_list.GetDouble("MSMT_POS1");
                        spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.GLASS_B2].Value = out_list.GetDouble("MSMT_POS2");
                        spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.GLASS_B3].Value = out_list.GetDouble("MSMT_POS3");
                        spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.GLASS_B4].Value = out_list.GetDouble("MSMT_POS4");
                        spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.GLASS_B5].Value = out_list.GetDouble("MSMT_POS5");
                        spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.GLASS_B6].Value = out_list.GetDouble("MSMT_POS6");
                        spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.GLASS_B7].Value = out_list.GetDouble("MSMT_POS7");
                        spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.GLASS_B8].Value = out_list.GetDouble("MSMT_POS8");
                        if (row % 4 == 0)
                        {
                            spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.DATE_TITLE].Text = out_list.GetString("RES_ID");
                        }
                        if ((row - 1) % 4 == 0)
                        {
                            spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.DATE_CONTROL].Value = MPCF.ToDate(out_list.GetString("SMPL_DATE"));
                        }
                        else if ((row - 2) % 4 == 0)
                        {
                            spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.DATE_CONTROL].Value = MPCF.ToDate(out_list.GetString("MSMT_DATE"));
                            spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.DATE_CONTROL].Locked = true;
                        }
                        row++;
                    }
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];
                    if ((PULLTEST_PART_BACKSHEET.ToString()).CompareTo(out_list.GetString("PART_TYPE")) == 0)
                    {
                        for (row = 0; row < spdPullTest.Sheets[0].Rows.Count; row++)
                        {
                            string strRes = spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.RES_ID].Value.ToString();
                            string strModule = spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.MODULE_NO].Value.ToString();
                            if (strRes.CompareTo(out_list.GetString("RES_ID")) == 0 &&
                                strModule.CompareTo(out_list.GetInt("MODULE_NO").ToString()) == 0)
                            {
                                spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.BACK_B1].Value = out_list.GetDouble("MSMT_POS1");
                                spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.BACK_B2].Value = out_list.GetDouble("MSMT_POS2");
                                spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.BACK_B3].Value = out_list.GetDouble("MSMT_POS3");
                                spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.BACK_B4].Value = out_list.GetDouble("MSMT_POS4");
                                spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.BACK_B5].Value = out_list.GetDouble("MSMT_POS5");
                                spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.BACK_B6].Value = out_list.GetDouble("MSMT_POS6");
                                spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.BACK_B7].Value = out_list.GetDouble("MSMT_POS7");
                                spdPullTest.ActiveSheet.Cells[row, (int)DATA_LIST.BACK_B8].Value = out_list.GetDouble("MSMT_POS8");
                            }
                        }

                    }
                }

                validateData();

                spdPullTest.ActiveSheet.SetActiveCell(0, (int)DATA_LIST.GLASS_B1);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }




        private bool UpdatePullTest(char ProcStep)
        {
            try
            {
                int i;
                DateTime dtpScrapDateTimeOut = new DateTime();

                TRSNode in_node = new TRSNode("UPDATE_TIME_LIST_IN");
                TRSNode out_node = new TRSNode("UPDATE_TIME_LIST_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                makePullTestData(in_node, PULLTEST_PART_GLASS);
                makePullTestData(in_node, PULLTEST_PART_BACKSHEET);

                if (MPCF.CallService("CWIP", "CWIP_Update_Laminator_Pull_Test", in_node, ref out_node) == false)
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

        private void makePullTestData(TRSNode in_node, int part)
        {
            int pos = part == PULLTEST_PART_GLASS ? 0 : 8;
            TRSNode work_list = null;

            for (int i = 0; i < spdPullTest.Sheets[0].Rows.Count; i++)
            {
                work_list = in_node.AddNode("TRAN_LIST");
                work_list.AddString("FACTORY", MPGV.gsFactory);
                work_list.AddString("MSMT_DATE", spdPullTest.ActiveSheet.Cells[i, (int)DATA_LIST.MSMT_DATE].Value);
                work_list.AddString("LINE_ID", cdvLineID.Code);
                work_list.AddString("RES_ID", spdPullTest.ActiveSheet.Cells[i, (int)DATA_LIST.RES_ID].Value);
                work_list.AddInt("MODULE_NO", spdPullTest.ActiveSheet.Cells[i, (int)DATA_LIST.MODULE_NO].Value);
                work_list.AddString("SMPL_DATE", spdPullTest.ActiveSheet.Cells[i, (int)DATA_LIST.SMPL_DATE].Value);
                work_list.AddString("PART_TYPE", part.ToString());
                for (int jnx = 1; jnx <= 8; jnx++)
                {
                    work_list.AddDouble("MSMT_POS" + jnx, spdPullTest.ActiveSheet.Cells[i, (int)DATA_LIST.MODULE_NO + jnx + pos].Value);
                }
            }
        }
        private bool getLineLocationList()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
                TRSNode out_list;
                MPCF.SetInMsg(in_node);

                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_LOCATION));

                int i;
                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == true)
                {
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        out_list = out_node.GetList(0)[i];

                        cboLineLocation.Items.Add(out_list.GetString("KEY_1"), out_list.GetString("DATA_1"));
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private void setupPullTestDataSheet()
        {
            try
            {

                spdPullTest.Sheets[0].RowCount = MAX_ROW_COUNT;
                spdPullTest.ActiveSheet.Columns[(int)DATA_LIST.DATE_CONTROL].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;

                int jnx = 0;
                for (int inx = 0; inx < MAX_ROW_COUNT; inx++)
                {
                    spdPullTest.ActiveSheet.Cells[inx, (int)DATA_LIST.MODULE_NO].Text = (jnx + 1).ToString();
                    spdPullTest.ActiveSheet.Cells[inx, (int)DATA_LIST.MODULE_NO].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    spdPullTest.ActiveSheet.Cells[inx, (int)DATA_LIST.MODULE_NO].Locked = true;
                    spdPullTest.ActiveSheet.Rows[inx].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;

                    if (inx % 4 == 0)
                    {
                        spdPullTest.ActiveSheet.Cells[inx, (int)DATA_LIST.DATE_TITLE].ColumnSpan = 2;
                        spdPullTest.ActiveSheet.Cells[inx, (int)DATA_LIST.DATE_TITLE].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                        spdPullTest.ActiveSheet.Cells[inx, (int)DATA_LIST.DATE_TITLE].Text = "Lami " + (inx / 4) + ".";
                        spdPullTest.ActiveSheet.Cells[inx, (int)DATA_LIST.DATE_TITLE].Locked = true;
                    }
                    else if ((inx - 1) % 4 == 0)
                    {
                        spdPullTest.ActiveSheet.Cells[inx, (int)DATA_LIST.DATE_TITLE].Text = "Sample Making";
                        spdPullTest.ActiveSheet.Cells[inx, (int)DATA_LIST.DATE_TITLE].Locked = true;
                        InitDateCell(spdPullTest, inx, (int)DATA_LIST.DATE_CONTROL);
                        setSampleMeasurementDate(inx, (int)DATA_LIST.DATE_CONTROL, dtpDate.Value);
                    }
                    else if ((inx - 2) % 4 == 0)
                    {
                        spdPullTest.ActiveSheet.Cells[inx, (int)DATA_LIST.DATE_TITLE].Text = "Measurement";
                        spdPullTest.ActiveSheet.Cells[inx, (int)DATA_LIST.DATE_TITLE].Locked = true;
                        spdPullTest.ActiveSheet.Cells[inx, (int)DATA_LIST.DATE_CONTROL].Locked = true;
                        InitDateCell(spdPullTest, inx, (int)DATA_LIST.DATE_CONTROL);
                        setSampleMeasurementDate(inx, (int)DATA_LIST.DATE_CONTROL, dtpDate.Value);
                    }
                    else if ((inx - 3) % 4 == 0)
                    {
                        spdPullTest.ActiveSheet.Cells[inx, (int)DATA_LIST.DATE_TITLE].ColumnSpan = 2;
                        spdPullTest.ActiveSheet.Cells[inx, (int)DATA_LIST.DATE_TITLE].Text = "";
                        spdPullTest.ActiveSheet.Cells[inx, (int)DATA_LIST.DATE_TITLE].Locked = true;
                    }

                    initDataCell(spdPullTest, inx);
                    jnx = jnx == 3 ? 0 : jnx + 1;
                    spdPullTest.ActiveSheet.Rows[inx].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
                    spdPullTest.ActiveSheet.Rows[inx].Height = 150;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        bool initDataCell(FarPoint.Win.Spread.FpSpread spdData, int row)
        {
            int maxCol = DATA_MAX_COLUMN_COUNT + (int)DATA_LIST.MODULE_NO + 1;
            FarPoint.Win.Spread.CellType.NumberCellType dataCellType;

            try
            {
                for (int col = (int)DATA_LIST.MODULE_NO + 1; col < maxCol; col++)
                {
                    dataCellType = new FarPoint.Win.Spread.CellType.NumberCellType();

                    dataCellType.DecimalPlaces = 1;
                    dataCellType.DecimalSeparator = ".";
                    dataCellType.FixedPoint = false;
                    dataCellType.MaximumValue = 999.9;
                    dataCellType.EnableSubEditor = false;
                    spdData.Sheets[0].Cells[row, col].CellType = dataCellType;
                    spdData.Sheets[0].Cells[row, col].Value = 0.0;
                    spdData.Sheets[0].Cells[row, col].ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        bool InitDateCell(FarPoint.Win.Spread.FpSpread spdData, int i_row, int i_col)
        {
            FarPoint.Win.Spread.CellType.DateTimeCellType dateCellType;

            try
            {
                dateCellType = new FarPoint.Win.Spread.CellType.DateTimeCellType();

                dateCellType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;

                if (MPGV.geLanguageFormat.Equals(LANG_FORMAT.STANDARD) == true)
                {
                    dateCellType.UserDefinedFormat = "MM/dd/yyyy";
                }
                else
                {
                    dateCellType.UserDefinedFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                }
                dateCellType.DropDownButton = true;
                dateCellType.DateDefault = System.DateTime.Today;
                spdData.Sheets[0].Cells[i_row, i_col].CellType = dateCellType;
                dateCellType.MaximumDate = (DateTime)dtpDate.Value;
                spdData.Sheets[0].Cells[i_row, i_col].Value = dtpDate.Value;

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        private void setResIDData()
        {
            String resId = "";

            for (int inx = 0; inx < MAX_ROW_COUNT; inx++)
            {
                int seq = (inx + 4) / 4;
                if (inx % 4 == 0)
                {
                    resId = "US-E" + cdvLineID.Code.Substring(4, 1) + "-LAM-0" + seq.ToString();
                    spdPullTest.ActiveSheet.Cells[inx, (int)DATA_LIST.DATE_TITLE].Text = resId;
                }
                else if ((inx - 1) % 4 == 0)
                {
                    resId = "US-E" + cdvLineID.Code.Substring(4, 1) + "-LAM-0" + seq.ToString();
                }
                else if ((inx - 2) % 4 == 0)
                {
                    resId = "US-E" + cdvLineID.Code.Substring(4, 1) + "-LAM-0" + seq.ToString();
                }
                else if ((inx - 3) % 4 == 0)
                {
                    resId = "US-E" + cdvLineID.Code.Substring(4, 1) + "-LAM-0" + seq.ToString();
                }
                spdPullTest.ActiveSheet.Cells[inx, (int)DATA_LIST.RES_ID].Text = resId;
                spdPullTest.ActiveSheet.Cells[inx, (int)DATA_LIST.RES_ID].Locked = true;
            }
        }

        private void setSampleMeasurementDate(int row, int col, object value)
        {
            int dateRow = -1;
            int dateColumn = -1;
            FarPoint.Win.Spread.CellType.TextCellType dateCellType;

            if ((row - 1) % 4 == 0)
            {
                dateRow = row - 1;
                dateColumn = (int)DATA_LIST.SMPL_DATE;
            }
            else if ((row - 2) % 4 == 0)
            {
                dateRow = row - 2;
                dateColumn = (int)DATA_LIST.MSMT_DATE;
            }

            try
            {
                dateCellType = new FarPoint.Win.Spread.CellType.TextCellType();
                for (int inx = 0; inx < 4; inx++)
                {
                    spdPullTest.ActiveSheet.Cells[dateRow + inx, (int)dateColumn].CellType = dateCellType;
                    String strDate = ((DateTime)value).ToString("yyyyMMdd");
                    spdPullTest.ActiveSheet.Cells[dateRow + inx, (int)dateColumn].Text = strDate;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }

        }

        private void clearData()
        {
            try
            {
                if (this.spdPullTest_Sheet1.RowCount > 0)
                {
                    MPCF.ClearList(spdPullTest);
                }
                setupPullTestDataSheet();

                if (cdvLineID.Code != null && cdvLineID.Code.Length > 0)
                {
                    setResIDData();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }
        #endregion

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (this.spdPullTest_Sheet1.RowCount > 0)
            {
                MPCF.ClearList(spdPullTest);
            }
        }

        private void cboLineLocation_SelectionChanged(object sender, EventArgs e)
        {
            if (CheckCondition("VIEW") == false)
            {
                return;
            }
            cdvLineID.Text = "";
        }

        private void cboShift_SelectionChanged(object sender, EventArgs e)
        {
            if (CheckCondition("VIEW") == false)
            {
                return;
            }
            if (ViewPullTestList() == false)
            {
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void cdvLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cboLineLocation, false) == false)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(593), MSG_LEVEL.ERROR, false);
                    return;
                }

                // Code View Service
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));
                in_node.AddString("LINE_LOCATION", cboLineLocation.Value);

                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Line", "Line Desc" };
                cdvLineID.Text = cdvLineID.Show(cdvLineID, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvLineID.Text) == true)
                {
                    return;
                }

                btnView.PerformClick();

                // Focus
                MPCF.SetFocus(cdvLineID);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdPullTest_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            if (e.Column == (int)DATA_LIST.DATE_CONTROL)
            {
                if (DateTime.Compare((DateTime)spdPullTest.Sheets[0].ActiveCell.Value, (DateTime)dtpDate.Value) > 0)
                {
                    return;
                }
                setSampleMeasurementDate(e.Row, e.Column, spdPullTest.Sheets[0].ActiveCell.Value);
            }
            if (e.Column > (int)DATA_LIST.MODULE_NO && spdPullTest.Sheets[0].ActiveCell.Value != null)
            {
                validateLimit(e.Row, e.Column, (double)spdPullTest.Sheets[0].ActiveCell.Value);
            }
        }

    }
}
