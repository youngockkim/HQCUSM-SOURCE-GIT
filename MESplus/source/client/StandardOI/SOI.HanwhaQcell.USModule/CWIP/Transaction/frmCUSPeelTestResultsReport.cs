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
    public partial class frmCUSPeelTestResultsReport : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCUSPeelTestResultsReport()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        public string chk_type;
        public string chk_auto_validation;
        public string chk_auto;
        public enum DATA_LIST
        {
            PEEL_DATE,
            WORK_LINE,
            TOP_BOTTOM,
            BSBR_POS,
            POINT,
            PEAK,
            MENISCUS,
            WIDTH_LEFT,
            WIDTH_RIGHT
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
                    spdPeelTest.Sheets[0].Protect = false;
                    spdPeelTest.SaveExcel(pop.FileName, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders);
                    spdPeelTest.Sheets[0].Protect = true;
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

                if (ViewPeelTestList() == false)
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

                validateData();

                if (validateInputData() == false)
                {
                    
                    return;
                }

                if (UpdatePeelTest(MPGC.MP_STEP_UPDATE) == false)
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
        bool setDataNumberFormat(int row, int col)
        {
            FarPoint.Win.Spread.CellType.NumberCellType dataCellType;
            try
            {
                dataCellType = new FarPoint.Win.Spread.CellType.NumberCellType();

                dataCellType.DecimalPlaces = 1;
                dataCellType.DecimalSeparator = ".";
                dataCellType.FixedPoint = true;
                dataCellType.MaximumValue = 999.9;
                dataCellType.Format("###.0");
                dataCellType.LeadingZero = FarPoint.Win.Spread.CellType.LeadingZero.UseRegional;
                dataCellType.EnableSubEditor = false;                 
                spdPeelTest.Sheets[0].Cells[row, col].CellType = dataCellType;
                spdPeelTest.Sheets[0].Cells[row, col].Value = 0.0;
                spdPeelTest.Sheets[0].Cells[row, col].ForeColor = Color.Red;
                spdPeelTest.Sheets[0].Cells[row, col].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        bool setDataCharFormat(int row, int col)
        {
            FarPoint.Win.Spread.CellType.TextCellType dataCellType;
            try
            {
                dataCellType = new FarPoint.Win.Spread.CellType.TextCellType();
                dataCellType.CharacterCasing = CharacterCasing.Upper;
                dataCellType.EnableSubEditor = false;
                spdPeelTest.Sheets[0].Cells[row, col].CellType = dataCellType;
                spdPeelTest.Sheets[0].Cells[row, col].Value = "";
                spdPeelTest.Sheets[0].Cells[row, col].ForeColor = Color.Red;
                spdPeelTest.Sheets[0].Cells[row, col].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private void validateData()
        {
            for (int row = 0; row < spdPeelTest.Sheets[0].Rows.Count; row++)
            {
                for (int col = (int)DATA_LIST.PEAK; col <= (int)DATA_LIST.WIDTH_RIGHT; col++)
                {
                    if (spdPeelTest.ActiveSheet.Cells[row, col].Value == null)
                        continue;
                    if (col == (int)DATA_LIST.MENISCUS)
                    {
                        validateText(row, col, spdPeelTest.ActiveSheet.Cells[row, col].Value.ToString());
                    } else {
                        validateNumberLimit(row, col, (double)spdPeelTest.ActiveSheet.Cells[row, col].Value);
                    }
                }
            }
        }

        private void validateNumberLimit(int row, int col, double value)
        {
            if ( value > 0)
            {
                spdPeelTest.ActiveSheet.Cells[row, col].ForeColor = Color.White;
            }
            else
            {
                spdPeelTest.ActiveSheet.Cells[row, col].ForeColor = Color.Red;
            }
         
        }

        private void validateText(int row, int col, string value)
        {
            if (value.Equals("PASS") || value.Equals("FAIL") )
            {
                spdPeelTest.ActiveSheet.Cells[row, col].ForeColor = Color.White;
            }
            else
            {
                spdPeelTest.ActiveSheet.Cells[row, col].ForeColor = Color.Red;
            }

        }

        private bool validateInputData()
        {
            string colName = "";

            for (int i = 0; i < spdPeelTest.ActiveSheet.RowCount; i++)
            {
                for (int jnx = (int)DATA_LIST.PEAK; jnx < spdPeelTest.ActiveSheet.ColumnCount; jnx++)
                {
                    if (spdPeelTest.ActiveSheet.Cells[i, jnx].ForeColor == Color.Red)
                    {
                        if (jnx == (int)DATA_LIST.PEAK)
                        {
                            colName = "Peak";
                        }
                        else if (jnx == (int)DATA_LIST.MENISCUS)
                        {
                            colName = "Meniscus";
                        }
                        else if (jnx == (int)DATA_LIST.WIDTH_LEFT)
                        {
                            colName = "Width Left";
                        }
                        else if (jnx == (int)DATA_LIST.WIDTH_RIGHT)
                        {
                            colName = "Width Right";
                        }
                        MPCF.ShowMessage("Please review the input in the '" + colName + "' column, row " + (i+1) + ".", MSG_LEVEL.ERROR, false);
                        return false;
                    }
                }
            }

            return true;
        }

        private bool ViewPeelTestList()
        {
            try
            {
                int i;
                int row = 0;
                DateTime dtpFromDateTimeOut = new DateTime();

                clearData();

                TRSNode in_node = new TRSNode("VIEW_SHIFT_LIST_IN");
                TRSNode out_node = new TRSNode("PEELTESTRESULT_LIST");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("FACTORY", "USGAM1");

                if (dtpDate.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpDate.Value.ToString(), out dtpFromDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("PTST_DATE", dtpFromDateTimeOut.ToString("yyyyMMdd"));
                    }
                }
                in_node.AddString("LINE_ID", MPCF.Trim(this.cdvLineID.Code));

                if (MPCF.CallService("CWIP", "CWIP_View_PeelTestResult_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdPeelTest.Sheets[0].RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];
                    spdPeelTest.Sheets[0].RowCount++;
                    spdPeelTest.ActiveSheet.Cells[i, (int)DATA_LIST.PEEL_DATE].Value = out_list.GetString("PTST_DATE");
                    spdPeelTest.ActiveSheet.Cells[i, (int)DATA_LIST.PEEL_DATE].Locked = true;
                    spdPeelTest.ActiveSheet.Cells[i, (int)DATA_LIST.WORK_LINE].Value = out_list.GetString("LINE_ID");
                    spdPeelTest.ActiveSheet.Cells[i, (int)DATA_LIST.WORK_LINE].Locked = true;
                    spdPeelTest.ActiveSheet.Cells[i, (int)DATA_LIST.TOP_BOTTOM].Value = out_list.GetString("BSBR_POS_NM");
                    spdPeelTest.ActiveSheet.Cells[i, (int)DATA_LIST.TOP_BOTTOM].Locked = true;
                    spdPeelTest.ActiveSheet.Cells[i, (int)DATA_LIST.BSBR_POS].Value = out_list.GetString("BSBR_POS");
                    spdPeelTest.ActiveSheet.Cells[i, (int)DATA_LIST.BSBR_POS].Locked = true;
                    spdPeelTest.ActiveSheet.Cells[i, (int)DATA_LIST.POINT].Value = out_list.GetInt("POS_POINT");
                    spdPeelTest.ActiveSheet.Cells[i, (int)DATA_LIST.POINT].Locked = true;
                    setDataNumberFormat(i, (int)DATA_LIST.PEAK);
                    spdPeelTest.ActiveSheet.Cells[i, (int)DATA_LIST.PEAK].Value = out_list.GetDouble("PEAK");
                    setDataCharFormat(i, (int)DATA_LIST.MENISCUS);
                    spdPeelTest.ActiveSheet.Cells[i, (int)DATA_LIST.MENISCUS].Value = out_list.GetString("MENISCUS");
                    setDataNumberFormat(i, (int)DATA_LIST.WIDTH_LEFT);
                    spdPeelTest.ActiveSheet.Cells[i, (int)DATA_LIST.WIDTH_LEFT].Value = out_list.GetDouble("WIDTH_LEFT");
                    setDataNumberFormat(i, (int)DATA_LIST.WIDTH_RIGHT);
                    spdPeelTest.ActiveSheet.Cells[i, (int)DATA_LIST.WIDTH_RIGHT].Value = out_list.GetDouble("WIDTH_RIGHT");
                }

                MPCF.ShowSuccessMessage(out_node, false);

                validateData();
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool UpdatePeelTest(char ProcStep)
        {
            TRSNode peelList;
             TRSNode out_node = new TRSNode("OUT_NODE");

            try
            {
                TRSNode in_node = new TRSNode("IN_NODE");
                in_node.ProcStep = 'I';
                in_node.AddString("FACTORY", "USGAM1");

                for (int i = 0; i < spdPeelTest.ActiveSheet.RowCount; i++)
                {
                    peelList = in_node.AddNode("PEEL_LIST");
                    peelList.ProcStep = 'I';

                    peelList.AddString("FACTORY", "USGAM1");
                    peelList.AddString("LINE_ID", MPCF.Trim(spdPeelTest.ActiveSheet.Cells[i, (int)DATA_LIST.WORK_LINE].Value.ToString()));
                    peelList.AddString("PTST_DATE", MPCF.Trim(spdPeelTest.ActiveSheet.Cells[i, (int)DATA_LIST.PEEL_DATE].Value.ToString()));
                    peelList.AddString("BSBR_POS", MPCF.Trim(spdPeelTest.ActiveSheet.Cells[i, (int)DATA_LIST.BSBR_POS].Value.ToString()));
                    peelList.AddInt("POS_POINT", MPCF.Trim(spdPeelTest.ActiveSheet.Cells[i, (int)DATA_LIST.POINT].Value));
                    peelList.AddDouble("PEAK", MPCF.Trim(spdPeelTest.ActiveSheet.Cells[i, (int)DATA_LIST.PEAK].Value));
                    peelList.AddString("MENISCUS", MPCF.Trim(spdPeelTest.ActiveSheet.Cells[i, (int)DATA_LIST.MENISCUS].Value.ToString()));
                    peelList.AddDouble("WIDTH_LEFT", MPCF.Trim(spdPeelTest.ActiveSheet.Cells[i, (int)DATA_LIST.WIDTH_LEFT].Value));
                    peelList.AddDouble("WIDTH_RIGHT", MPCF.Trim(spdPeelTest.ActiveSheet.Cells[i, (int)DATA_LIST.WIDTH_RIGHT].Value));
                }

                if (MPCF.CallService("CWIP", "CWIP_Update_PeelTestResult", in_node, ref out_node) == false)
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

                    return false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

            return true;

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
         
           

        private void clearData()
        {
            try
            {
                if (this.spdPeelTest_Sheet1.RowCount > 0)
                {
                    MPCF.ClearList(spdPeelTest);
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
            if (this.spdPeelTest_Sheet1.RowCount > 0)
            {
                MPCF.ClearList(spdPeelTest);
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
            if (ViewPeelTestList() == false)
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
            if (e.Column == (int)DATA_LIST.PEAK || 
                e.Column == (int)DATA_LIST.WIDTH_LEFT || 
                e.Column == (int)DATA_LIST.WIDTH_RIGHT  )
            {
                if (MPCF.CheckNumeric(spdPeelTest.Sheets[0].ActiveCell.Value) == false)
                {
                    MPCF.ShowMessage("'Peak, Width' column data should be number.", MSG_LEVEL.ERROR, false);
                    return;
                }

                validateNumberLimit(e.Row, e.Column, (double)spdPeelTest.Sheets[0].ActiveCell.Value);
            } else if (e.Column == (int)DATA_LIST.MENISCUS)
            {
                validateText(e.Row, e.Column, spdPeelTest.Sheets[0].ActiveCell.Value.ToString());
            }
        }

        private void spdPeelTest_ClipboardPasted(object sender, FarPoint.Win.Spread.ClipboardPastedEventArgs e)
        {
            string clipboardText = Clipboard.GetText();

            if (!string.IsNullOrEmpty(clipboardText))
            {
                string[] lines = clipboardText.Split(new string[] { "\r\n", "\n" }, System.StringSplitOptions.None);

                int startRow = spdPeelTest.ActiveSheet.ActiveRowIndex;
                int startCol = spdPeelTest.ActiveSheet.ActiveColumnIndex;

                for (int r = 0; r < lines.Length; r++)
                {
                    string[] cellsInLine = lines[r].Split('\t');

                    for (int c = 0; c < cellsInLine.Length; c++)
                    {
                        int targetRow = startRow + r;
                        int targetCol = startCol + c;

                        if (targetRow < spdPeelTest.ActiveSheet.RowCount && targetCol < spdPeelTest.ActiveSheet.ColumnCount)
                        {
                            string cellValue = spdPeelTest.ActiveSheet.GetText(targetRow, targetCol);

                            if (targetCol == (int)DATA_LIST.MENISCUS && !string.IsNullOrEmpty(cellValue) )
                            {
                                spdPeelTest.ActiveSheet.Cells[targetRow, targetCol].Value = cellValue.ToUpper();
                            }
                        }
                    }
                }
            }
        }

    }
}
