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
using System.Runtime.Remoting.Lifetime;

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm03 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel, Print Option
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCUSPoChange : SOIBaseForm03
    {
        #region Property

        // (Required)
        private bool bIsShown = false;


        #endregion

        #region Constructor

        public frmCUSPoChange()
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
                if (soiRadioButton1.CheckedIndex == 0) //Module PO
                {
                    if (!importMDExcel())
                    {
                        return;
                    }
                }
                else if (soiRadioButton1.CheckedIndex == 1)
                {
                    if (!importTRExcel())
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
                soiSpreadImportMD.Visible = false;
                soiSpreadImportTR.Visible = false;
            }
        }

        
        #endregion


        public enum MODULE_LIST
        {
            MODULE_ID,
            AS_IS_PO,
            AS_IS_MAT_ID,
            AS_IS_MAT_DESC,
            TO_BE_PO,
            TO_BE_MAT_ID,
            TO_BE_MAT_DESC,
        }

        public enum TRAY_LIST
        {
            TRAY_ID,
            AS_IS_PO,
            AS_IS_MAT_ID,
            AS_IS_MAT_DESC,
            TO_BE_PO,
            TO_BE_MAT_ID,
            TO_BE_MAT_DESC,
        }


        //라디오 버튼 선택
        private void soiRadioButton1_ValueChanged(object sender, EventArgs e)
        {
            if(soiRadioButton1.CheckedIndex == 0)
            {
                initModuleGrid();
                soiGroupBox15.Text = "PO Change (Module)";
            }
            else if (soiRadioButton1.CheckedIndex == 1)
            {
                initTrayGrid();
                soiGroupBox15.Text = "PO Change (Tray)";
            }
            else
            {
                MPCF.ShowMessage("Radio Index Error Please contact MES Team", MSG_LEVEL.ERROR, false);
            }

        }

        private void initModuleGrid()
        {
            soiSpread1.Sheets[0].Columns.Clear();
            soiSpread1.Sheets[0].Rows.Clear();
            soiSpread1.Sheets[0].Columns.Add(0, Enum.GetNames(typeof(MODULE_LIST)).Length);

            string title;
            float size;
            for (int i = 0; i < Enum.GetNames(typeof(MODULE_LIST)).Length; i++)
            {
                title = soiSpreadExportFormatMD.Sheets[0].Cells[0, i].Value.ToString();
                size = soiSpreadExportFormatMD.Sheets[0].Columns[i].Width;

                soiSpread1.Sheets[0].ColumnHeader.Cells[0, i].Text = title;
                soiSpread1.Sheets[0].Columns[i].Width = size;
            }
            soiSpread1.Sheets[0].Columns[1].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            soiSpread1.Sheets[0].Columns[4].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
        }

        private void initTrayGrid()
        {
            soiSpread1.Sheets[0].Columns.Clear();
            soiSpread1.Sheets[0].Rows.Clear();
            soiSpread1.Sheets[0].Columns.Add(0, Enum.GetNames(typeof(TRAY_LIST)).Length);

            string title;
            float size;
            for (int i = 0; i < Enum.GetNames(typeof(TRAY_LIST)).Length; i++)
            {
                title = soiSpreadExportFormatTR.Sheets[0].Cells[0, i].Value.ToString();
                size = soiSpreadExportFormatTR.Sheets[0].Columns[i].Width;

                soiSpread1.Sheets[0].ColumnHeader.Cells[0, i].Text = title;
                soiSpread1.Sheets[0].Columns[i].Width = size;
            }
            soiSpread1.Sheets[0].Columns[1].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            soiSpread1.Sheets[0].Columns[4].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
        }

        /// <summary>
        /// Module Import 관련 Data Type Validation
        /// </summary>
        /// <returns></returns>
        private bool importMDExcel()
        {
            // (Option 1) Import from OpenFileDialog
            btnSpreadImportExcel.RunImport(soiSpreadImportMD);

            //check column format
            for (int x = 0; x < Enum.GetNames(typeof(MODULE_LIST)).Length; x++)
            {
                if (!soiSpread1.Sheets[0].Columns[x].Label.Equals(soiSpreadImportMD.Sheets[0].Cells[0, x].Value))
                {
                    //MPCF.ShowMessage(String.Format("The Excel Format is different. Please Check {0}({1}) Column name", soiSpreadImportMD.Sheets[0].Cells[0, x].Value, (x + 1)), MSG_LEVEL.ERROR, false);
                    MPCF.ShowMessage(String.Format("Selected file could not be loaded. Please check the column of the file."), MSG_LEVEL.ERROR, false);
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
                if (soiSpreadImportMD.Sheets[0].Cells[y, 0].Value == null)
                {
                    break;
                }

                if (String.IsNullOrEmpty(soiSpreadImportMD.Sheets[0].Cells[y, 0].Value.ToString()))
                {
                    break;
                }

                soiSpread1.Sheets[0].RowCount++;

                for (int x = 0; x < Enum.GetNames(typeof(MODULE_LIST)).Length; x++)
                {

                    if (soiSpreadImportMD.Sheets[0].Cells[y, x].Value == null && x != (int)MODULE_LIST.MODULE_ID)
                    {
                        MPCF.ShowMessage(String.Format("There is no data. Please Check {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                        soiSpread1.Sheets[0].Rows.Clear();
                        return false;
                    }
                    else if (soiSpreadImportMD.Sheets[0].Cells[y, x].Value == null && x == (int)MODULE_LIST.MODULE_ID)
                    {
                        cellValue = string.Empty;
                    }
                    else
                    {
                        cellValue = soiSpreadImportMD.Sheets[0].Cells[y, x].Value.ToString().ToUpper();
                    }

                    cellValue = MPCF.Trim(cellValue);
                    cellValue = cellValue.Replace("\n", "");
                    cellValue = cellValue.Replace("\r", "");

                    if (String.IsNullOrEmpty(cellValue) && x != (int)MODULE_LIST.MODULE_ID)
                    {
                        MPCF.ShowMessage(String.Format("There is no data. Please Check {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                        soiSpread1.Sheets[0].Rows.Clear();
                        return false;
                    }



                    // Validation Data type 
                    if (x == 0)
                    {
                        if (cellValue.Length != 18)
                        {
                            //MPCF.ShowMessage(String.Format("Please Check Moudle ID {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                            MPCF.ShowMessage(String.Format("Please Check Moudle ID in row {0} , {1}", getIntToExcelColumn(x), y + 1), MSG_LEVEL.ERROR, false);
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
                        if (cellValue.Length != 12)
                        {
                            //MPCF.ShowMessage(String.Format("Please Check AS-IS P.O {0} row  {1} cell data", y, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                            MPCF.ShowMessage(String.Format("Please Check AS-IS P.O. in row {0} , {1}", getIntToExcelColumn(x), y + 1 ), MSG_LEVEL.ERROR, false);
                            soiSpread1.Sheets[0].Rows.Clear();
                            return false;
                        }
                    }
                    else if (x == 4)
                    {
                        if (cellValue.Length != 12)
                        {
                            //MPCF.ShowMessage(String.Format("Please Check TO-BE P.O {0} row  {1} cell data", y, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                            MPCF.ShowMessage(String.Format("Please Check TO-BE P.O. in row {0} , {1}", getIntToExcelColumn(x), y + 1 ), MSG_LEVEL.ERROR, false);
                            soiSpread1.Sheets[0].Rows.Clear();
                            return false;
                        }
                    }
                    #region
                    //else if (x == 2)
                    //{
                    //    if (cellValue.Length != 14)
                    //    {
                    //        MPCF.ShowMessage(String.Format("There is datetime error. Please Check {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                    //        soiSpread1.Sheets[0].Rows.Clear();
                    //        return false;
                    //    }

                    //    DateTime dateTime;
                    //    if (!DateTime.TryParseExact(cellValue, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                    //    {
                    //        MPCF.ShowMessage(String.Format("There is datetime error. Please Check {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                    //        soiSpread1.Sheets[0].Rows.Clear();
                    //        return false;
                    //    }
                    //    else if (dateTime.CompareTo(DateTime.Now) > 0)
                    //    {
                    //        MPCF.ShowMessage(String.Format("Date can not be larger than now. Please Check {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                    //        soiSpread1.Sheets[0].Rows.Clear();
                    //        return false;
                    //    }
                    //}

                    //else if (x > 7)
                    //{
                    //    if (!string.IsNullOrEmpty(cellValue))
                    //    {
                    //        double dummyDouble;
                    //        if (!double.TryParse(cellValue, out dummyDouble))
                    //        {
                    //            MPCF.ShowMessage(String.Format("There is number error. Please Check {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                    //            soiSpread1.Sheets[0].Rows.Clear();
                    //            return false;

                    //        }
                    //        else
                    //        {
                    //            cellValue = dummyDouble.ToString();
                    //        }
                    //    }

                    //}
                    #endregion



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


        /// <summary>
        /// TRAY Import 관련 Data Type Validation 
        /// </summary>
        /// <returns></returns>
        private bool importTRExcel()
        {
            // (Option 1) Import from OpenFileDialog
            btnSpreadImportExcel.RunImport(soiSpreadImportTR);

            //check column format
            for (int x = 0; x < Enum.GetNames(typeof(TRAY_LIST)).Length; x++)
            {
                if (!soiSpread1.Sheets[0].Columns[x].Label.Equals(soiSpreadImportTR.Sheets[0].Cells[0, x].Value))
                {
                    MPCF.ShowMessage(String.Format("Selected file could not be loaded. Please check the column of the file."), MSG_LEVEL.ERROR, false);
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
                if (soiSpreadImportTR.Sheets[0].Cells[y, 0].Value == null)
                {
                    break;
                }

                if (String.IsNullOrEmpty(soiSpreadImportTR.Sheets[0].Cells[y, 0].Value.ToString()))
                {
                    break;
                }

                soiSpread1.Sheets[0].RowCount++;
                
                for (int x = 0; x < Enum.GetNames(typeof(TRAY_LIST)).Length; x++)
                {
                    
                    if (soiSpreadImportTR.Sheets[0].Cells[y, x].Value == null && x != (int)TRAY_LIST.TRAY_ID)
                    {
                        MPCF.ShowMessage(String.Format("There is no data. Please Check {0} row {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                        soiSpread1.Sheets[0].Rows.Clear();
                        return false;
                    }
                    else if (soiSpreadImportTR.Sheets[0].Cells[y, x].Value == null && x == (int)TRAY_LIST.TRAY_ID)
                    {
                        cellValue = string.Empty;
                    }
                    else
                    {
                        cellValue = soiSpreadImportTR.Sheets[0].Cells[y, x].Value.ToString().ToUpper();
                    }

                    cellValue = MPCF.Trim(cellValue);
                    cellValue = cellValue.Replace("\n", "");
                    cellValue = cellValue.Replace("\r", "");

                    if (String.IsNullOrEmpty(cellValue) && x != (int)TRAY_LIST.TRAY_ID)
                    {
                        MPCF.ShowMessage(String.Format("There is no data. Please Check {0} row  {1} cell data ", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                        soiSpread1.Sheets[0].Rows.Clear();
                        return false;
                    }



                    // Validation Data type 
                    if (x == 0)
                    {
                        if (cellValue.Length != 7)
                        {
                            //MPCF.ShowMessage(String.Format("Please Check Moudle ID {0} row  {1} cell data", y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                            MPCF.ShowMessage(String.Format("Please Check Tray ID in row {0} , {1}", getIntToExcelColumn(x), y + 1), MSG_LEVEL.ERROR, false);
                            soiSpread1.Sheets[0].Rows.Clear();
                            return false;
                        }


                        if (lotList.Contains(cellValue))
                        {
                            MPCF.ShowMessage(String.Format("There is a dupulicate tray id. please check {0} tray id in {1} row  {2} cell", cellValue, y + 1, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
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
                        if (cellValue.Length != 12)
                        {
                            //MPCF.ShowMessage(String.Format("Please Check AS-IS P.O {0} row  {1} cell data", y, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                            MPCF.ShowMessage(String.Format("Please Check AS-IS P.O. in row {0} , {1}", getIntToExcelColumn(x), y + 1), MSG_LEVEL.ERROR, false);
                            soiSpread1.Sheets[0].Rows.Clear();
                            return false;
                        }
                    }
                    else if (x == 4)
                    {
                        if (cellValue.Length != 12)
                        {
                            //MPCF.ShowMessage(String.Format("Please Check TO-BE P.O {0} row  {1} cell data", y, getIntToExcelColumn(x)), MSG_LEVEL.ERROR, false);
                            MPCF.ShowMessage(String.Format("Please Check TO-BE P.O. in row {0} , {1}", getIntToExcelColumn(x), y + 1), MSG_LEVEL.ERROR, false);
                            soiSpread1.Sheets[0].Rows.Clear();
                            return false;
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
                if(sendModuleInfo() == true)
                {
                    if (CMNF.ShowMsgBox("Do you want to proceed with PO Change?", MessageBoxButtons.YesNo, SOI.CliFrx.MSG_LEVEL.WARNING) != System.Windows.Forms.DialogResult.Yes)
                    {
                        btnProcess.Enabled = true;
                        return;
                    }
                    else
                    {
                        btnProcess.Enabled = true;
                        sendModuleCommit();
                    }
                }
            }
            else if (soiRadioButton1.CheckedIndex == 1)
            {
                if (sendTrayInfo() == true)
                {
                    if (CMNF.ShowMsgBox("Do you want to proceed with PO Change?", MessageBoxButtons.YesNo, SOI.CliFrx.MSG_LEVEL.WARNING) != System.Windows.Forms.DialogResult.Yes)
                    {
                        btnProcess.Enabled = true;
                        return;
                    }
                    else
                    {
                        btnProcess.Enabled = true; 
                        sendTrayCommit();
                    }
                }
            }
            else
            {
                MPCF.ShowMessage("Radio Index Error Please contact MES Team", MSG_LEVEL.ERROR, false);
            }

            btnProcess.Enabled = true;
        }

        /// <summary>
        /// Module Validation PO별 데이터 비교
        /// </summary>
        private bool sendModuleInfo()
        {
            // 개별 리스트 전송 후 오류 처리
            //TRSNode in_node = new TRSNode("IN_NODE");
            TRSNode out_node = new TRSNode("OUT_NODE");
            TRSNode moduleList;

            string lot_id = string.Empty;

            try
            {
                for (int i = 0; i < soiSpread1.ActiveSheet.RowCount; i++)
                {
                    // 개별 리스트 전송 후 오류 처리
					TRSNode in_node = new TRSNode("IN_NODE");
                    moduleList = in_node.AddNode("MODULE_LIST");

                    MPCF.SetInMsg(moduleList);

                    lot_id = MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)MODULE_LIST.MODULE_ID].Value.ToString());

                    in_node.ProcStep = '1';
                    moduleList.AddString("LOT_ID", lot_id);              // LOT_ID
                    moduleList.AddString("AS_IS_PO", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)MODULE_LIST.AS_IS_PO].Value.ToString()));     // AS_IS_PO
                    moduleList.AddString("AS_IS_MAT_ID", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)MODULE_LIST.AS_IS_MAT_ID].Value.ToString()));     // AS_IS_MATERIAL_ID
                    moduleList.AddString("AS_IS_MAT_DESC", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)MODULE_LIST.AS_IS_MAT_DESC].Value.ToString()));     // AS_IS_MATERIAL_DESC
                    moduleList.AddString("TO_BE_PO", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)MODULE_LIST.TO_BE_PO].Value.ToString()));     // TO_BE_PO
                    moduleList.AddString("TO_BE_MAT_ID", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)MODULE_LIST.TO_BE_MAT_ID].Value.ToString()));     // TO_BE_MATERIAL_ID
                    moduleList.AddString("TO_BE_MAT_DESC", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)MODULE_LIST.TO_BE_MAT_DESC].Value.ToString()));     // TO_BE_MATERIAL_DESC
                    moduleList.AddString("ROW_SEQ",  i + 1);     // ROW seq

                    // 개별 리스트 전송 후 오류 처리
                    if (MPCF.CallService("CWIP", "CWIP_Module_PO_Change", in_node, ref out_node) == false)
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
                            soiSpread1.ActiveSheet.SetActiveCell(0, 0);
							soiSpread1.ShowRow(0, 0, FarPoint.Win.Spread.VerticalPosition.Nearest);

							string strViewError;
							strViewError = 
							   "LOTID : " + strLOTID + "\r\n"
							 + "INDEX : " + i + 1 + "\r\n"
							 + "TYPE : " + strWorkType + "\r\n"
							 + "----------------------------------\r\n"
							 + strErrorMsg;

							// 기본 dll ShowMessage
							MPCF.ShowMessage(strViewError, MSG_LEVEL.ERROR, true);
						}

						MPCF.ShowSuccessMessage(out_node, false);

						return false;
					}

                    //// 아래 경우일때만 정상 처리 LOT_ID 삭제 처리 필요 // 삭제처리 필요 여부 확인.
                    //soiSpread1.ActiveSheet.Rows.Remove(0, i);
                    //if (soiRadioButton1.CheckedIndex == 0)
                    //{
                    //    soiSpreadImportMD.ActiveSheet.Rows.Remove(1, i);
                    //}

                    //// 정상 처리 파란색 처리 // 원할경우.
                    //soiSpread1.ActiveSheet.Rows[i].BackColor = Color.Blue;
                    //soiSpread1.ActiveSheet.SetActiveCell(i, 0);
                    //soiSpread1.ShowRow(0, i, FarPoint.Win.Spread.VerticalPosition.Nearest);
                }

                MPCF.ShowSuccessMessage(out_node, true);
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Tray Validation PO별 데이터 비교
        /// </summary>
        private bool sendTrayInfo()
        {
            // 개별 리스트 전송 후 오류 처리
            //TRSNode in_node = new TRSNode("IN_NODE");
            TRSNode out_node = new TRSNode("OUT_NODE");
            TRSNode trayList;

            string tray_id = string.Empty;

            try
            {
                for (int i = 0; i < soiSpread1.ActiveSheet.RowCount; i++)
                {
                    // 개별 리스트 전송 후 오류 처리
                    TRSNode in_node = new TRSNode("IN_NODE");
                    trayList = in_node.AddNode("TRAY_LIST");

                    MPCF.SetInMsg(trayList);

                    tray_id = MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)TRAY_LIST.TRAY_ID].Value.ToString());

                    in_node.ProcStep = '1';
                    trayList.AddString("TRAY_ID", tray_id);              // LOT_ID
                    trayList.AddString("AS_IS_PO", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)TRAY_LIST.AS_IS_PO].Value.ToString()));     // AS_IS_PO
                    trayList.AddString("AS_IS_MAT_ID", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)TRAY_LIST.AS_IS_MAT_ID].Value.ToString()));     // AS_IS_MATERIAL_ID
                    trayList.AddString("AS_IS_MAT_DESC", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)TRAY_LIST.AS_IS_MAT_DESC].Value.ToString()));     // AS_IS_MATERIAL_DESC
                    trayList.AddString("TO_BE_PO", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)TRAY_LIST.TO_BE_PO].Value.ToString()));     // TO_BE_PO
                    trayList.AddString("TO_BE_MAT_ID", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)TRAY_LIST.TO_BE_MAT_ID].Value.ToString()));     // TO_BE_MATERIAL_ID
                    trayList.AddString("TO_BE_MAT_DESC", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)TRAY_LIST.TO_BE_MAT_DESC].Value.ToString()));     // TO_BE_MATERIAL_DESC
                    trayList.AddString("ROW_SEQ", i + 1);     // ROW seq

                    // 개별 리스트 전송 후 오류 처리
                    if (MPCF.CallService("CWIP", "CWIP_Tray_PO_Change", in_node, ref out_node) == false)
                    {
                        string strErrorType = out_node.GetString("ERROR_TYPE");
                        int nLotIndex = out_node.GetInt("LOT_INDEX");
                        string strLOTID = out_node.GetString("TRAY_ID");
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
                            soiSpread1.ActiveSheet.SetActiveCell(0, 0);
                            soiSpread1.ShowRow(0, 0, FarPoint.Win.Spread.VerticalPosition.Nearest);

                            string strViewError;
                            strViewError =
                               "LOTID : " + strLOTID + "\r\n"
                             + "INDEX : " + i + 1 + "\r\n"
                             + "TYPE : " + strWorkType + "\r\n"
                             + "----------------------------------\r\n"
                             + strErrorMsg;

                            // 기본 dll ShowMessage
                            MPCF.ShowMessage(strViewError, MSG_LEVEL.ERROR, true);
                        }

                        MPCF.ShowSuccessMessage(out_node, false);

                        return false;
                    }

                    //// 아래 경우일때만 정상 처리 LOT_ID 삭제 처리 필요 // 삭제처리 필요 여부 확인.
                    //soiSpread1.ActiveSheet.Rows.Remove(0, i);
                    //if (soiRadioButton1.CheckedIndex == 0)
                    //{
                    //    soiSpreadImportMD.ActiveSheet.Rows.Remove(1, i);
                    //}

                    //// 정상 처리 파란색 처리 // 원할경우.
                    //soiSpread1.ActiveSheet.Rows[i].BackColor = Color.Blue;
                    //soiSpread1.ActiveSheet.SetActiveCell(i, 0);
                    //soiSpread1.ShowRow(0, i, FarPoint.Win.Spread.VerticalPosition.Nearest);
                }

                //soiSpread1.Sheets[0].Rows.Clear(); // 점검이라 클리어 하지 않음.
                MPCF.ShowSuccessMessage(out_node, true);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Module PO Commit 여부를 확인 후 진행한다.
        /// </summary>
        private void sendModuleCommit()
        {
            // 개별 리스트 전송 후 오류 처리
            TRSNode out_node = new TRSNode("OUT_NODE");


            TRSNode moduleList;

            string lot_id = string.Empty;
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

                    lot_id = MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)MODULE_LIST.MODULE_ID].Value.ToString());

                    moduleList.ProcStep = '2';
                    moduleList.AddString("LOT_ID", lot_id);              // LOT_ID
                    moduleList.AddString("AS_IS_PO", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)MODULE_LIST.AS_IS_PO].Value.ToString()));     // AS_IS_PO
                    moduleList.AddString("AS_IS_MAT_ID", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)MODULE_LIST.AS_IS_MAT_ID].Value.ToString()));     // AS_IS_MATERIAL_ID
                    moduleList.AddString("AS_IS_MAT_DESC", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)MODULE_LIST.AS_IS_MAT_DESC].Value.ToString()));     // AS_IS_MATERIAL_DESC
                    moduleList.AddString("TO_BE_PO", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)MODULE_LIST.TO_BE_PO].Value.ToString()));     // TO_BE_PO
                    moduleList.AddString("TO_BE_MAT_ID", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)MODULE_LIST.TO_BE_MAT_ID].Value.ToString()));     // TO_BE_MATERIAL_ID
                    moduleList.AddString("TO_BE_MAT_DESC", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)MODULE_LIST.TO_BE_MAT_DESC].Value.ToString()));     // TO_BE_MATERIAL_DESC
                    moduleList.AddString("ROW_SEQ", i + 1);     // ROW seq

                    // 개별 리스트 전송 후 오류 처리
                    if (MPCF.CallService("CWIP", "CWIP_Module_PO_Change", in_node, ref out_node) == false)
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
                        MPCF.ShowSuccessMessage(out_node, false);

                        return;
                    }

                    // 정상 처리 파란색 처리
                    soiSpread1.ActiveSheet.Rows[i].BackColor = Color.Blue;
                    soiSpread1.ActiveSheet.SetActiveCell(i, 0);
                    soiSpread1.ShowRow(0, i, FarPoint.Win.Spread.VerticalPosition.Nearest);
                }

                soiSpread1.Sheets[0].Rows.Clear();
                MPCF.ShowSuccessMessage(out_node, true);

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        /// <summary>
        /// Tray PO Commit 여부를 확인 후 진행한다.
        /// </summary>
        private void sendTrayCommit()
        {
            // 개별 리스트 전송 후 오류 처리
            TRSNode out_node = new TRSNode("OUT_NODE");


            TRSNode trayList;

            string lot_id = string.Empty;
            string sim_result = string.Empty;

            try
            {
                for (int i = 0; i < soiSpread1.ActiveSheet.RowCount; i++)
                {
                    // IS-21-03-045	Dark Chamber OQC 튜닝
                    // 개별 리스트 전송 후 오류 처리
                    TRSNode in_node = new TRSNode("IN_NODE");


                    trayList = in_node.AddNode("TRAY_LIST");

                    MPCF.SetInMsg(trayList);

                    lot_id = MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)TRAY_LIST.TRAY_ID].Value.ToString());

                    trayList.ProcStep = '2';
                    trayList.AddString("TRAY_ID", lot_id);              // LOT_ID
                    trayList.AddString("AS_IS_PO", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)TRAY_LIST.AS_IS_PO].Value.ToString()));     // AS_IS_PO
                    trayList.AddString("AS_IS_MAT_ID", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)TRAY_LIST.AS_IS_MAT_ID].Value.ToString()));     // AS_IS_MATERIAL_ID
                    trayList.AddString("AS_IS_MAT_DESC", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)TRAY_LIST.AS_IS_MAT_DESC].Value.ToString()));     // AS_IS_MATERIAL_DESC
                    trayList.AddString("TO_BE_PO", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)TRAY_LIST.TO_BE_PO].Value.ToString()));     // TO_BE_PO
                    trayList.AddString("TO_BE_MAT_ID", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)TRAY_LIST.TO_BE_MAT_ID].Value.ToString()));     // TO_BE_MATERIAL_ID
                    trayList.AddString("TO_BE_MAT_DESC", MPCF.Trim(soiSpread1.ActiveSheet.Cells[i, (int)TRAY_LIST.TO_BE_MAT_DESC].Value.ToString()));     // TO_BE_MATERIAL_DESC
                    trayList.AddString("ROW_SEQ", i + 1);     // ROW seq

                    // 개별 리스트 전송 후 오류 처리
                    if (MPCF.CallService("CWIP", "CWIP_Tray_PO_Change", in_node, ref out_node) == false)
                    {
                        string strErrorType = out_node.GetString("ERROR_TYPE");
                        int nLotIndex = out_node.GetInt("LOT_INDEX");
                        string strLOTID = out_node.GetString("TRAY_ID");
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
                        MPCF.ShowSuccessMessage(out_node, false);

                        return;
                    }

                    // 정상 처리 파란색 처리
                    soiSpread1.ActiveSheet.Rows[i].BackColor = Color.Blue;
                    soiSpread1.ActiveSheet.SetActiveCell(i, 0);
                    soiSpread1.ShowRow(0, i, FarPoint.Win.Spread.VerticalPosition.Nearest);
                }

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


        //private ArrayList initLocList()
        //{
        //    ArrayList arrayList = new ArrayList();

        //    string[] rows = { "A", "B", "C", "D", "E", "F" };

        //    for (var i = 1; i < 27; i++)
        //    {
        //        for (var k = 0; k < rows.Length; k++)
        //        {
        //            arrayList.Add((rows[k] + i.ToString("D2")));
        //        }
        //    }

        //    return arrayList;
        //}


        //private ArrayList initDefectList()
        //{
        //    ArrayList arrayList = new ArrayList();


        //    TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
        //    TRSNode out_node = new TRSNode("VIEW_DATA_LIST_OUT");

        //    MPCF.SetInMsg(in_node);
        //    in_node.ProcStep = '1';
        //    in_node.AddString("TABLE_NAME", "@DEFECT");
        //    in_node.AddString("KEY_2", "M2040"); //VOC-5239 [프로그램_변경]MESOI - OQC Dark Chamber
        //                                         //Validation 조건 추가.


        //    if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
        //    {
        //        return arrayList;
        //    }

        //    List<TRSNode> lisData = out_node.GetList("DATA_LIST");
        //    foreach (TRSNode data in lisData)
        //    {
        //        if("MODULE".Equals(data.GetString("DATA_1")))
        //            arrayList.Add(data.GetString("KEY_1"));
        //    }

        //    return arrayList;

        //}

        #endregion

        private void btnSpreadExcelExport2_Click(object sender, EventArgs e)
        {
            try
            {
                if (soiRadioButton1.CheckedIndex == 0)
                {
                    btnSpreadExcelExport2.RunExport(soiSpreadExportFormatMD);
                }
                else if (soiRadioButton1.CheckedIndex == 1)
                {
                    btnSpreadExcelExport2.RunExport(soiSpreadExportFormatTR);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
    }
}
