using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.CliFrx;

namespace SOI.HanwhaQcell.USModule
{
    
    public partial class frmCWIPModuleRepairNgTrayManagement : SOIBaseForm02
    {
        #region Property

        // (Required)         
        private List<string> m_listLaminator = new List<string>();
        
        // (Required) 
        private bool bIsShown = false;

        #endregion
        
        #region [Constant Definition]
        int ROWHEIGHT = 37;
        int MAX_COL_COUNT = 7;
        int DATA_START_COL = 3;
        String EQUIPMENT_TYPE_LAMINATOR = "LAMINATOR";
        Color CELL_NULL_COLOR = Color.Tomato;
        const int ENTER = 13;
        private string strELImagePath = "";
        private string strVISIONImagePath = "";

        int MAXPOSITION = 0;
        int NOWPOSITION = 0;

        private enum SPD_TRAY_STRING_LIST
        {
            NO,
            STRING_ID,
            RES_ID
        }

        private enum SPD_STRING_INSP_LIST
        {
            NO,
            INS_TYPE,
            LOT_ID,
            INS_TIME,
            IMG_PATH
        }

        private string gStringID = string.Empty;
        private string gInsType = string.Empty;
        private string gImgPath = string.Empty;

        #endregion

        #region Constructor

        public frmCWIPModuleRepairNgTrayManagement()
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
        private void frmCWIPModuleRepairNgTrayManagement_Load(object sender, EventArgs e)
        {
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);

            MPCF.ClearList(spdString1);
            MPCF.ClearList(spdString2);

            //dtpDate.Value = DateTime.Now;

            //this.spdString1._UseAutoHeight = false;
            //this.spdString2._UseAutoHeight = false;

            //getLineLocationList();
        }

        private void frmCWIPModuleRepairNgTrayManagement_Shown(object sender, EventArgs e)
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

        private void cboLineLocation_SelectionChanged(object sender, EventArgs e)
        {
            //cdvLineID.Text = "";
            //cdvLineID.Description = "";

            //cleardata();

            //this.btnVision.Enabled = false;
            this.btnCreate.Enabled = false;
            //this.btnView.Enabled = false;
        }
        #endregion

        #region Functions
        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "VIEW":

                        if (MPCF.CheckValue(txtTrayID, false) == false)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(594), MSG_LEVEL.ERROR, false);
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

        private void ClearData()
        {
            try
            {
                MPCF.ClearList(spdString1);
                MPCF.ClearList(spdString2);
                
                strELImagePath = "";
                strVISIONImagePath = "";
            }

            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }


        private bool setInputDataToSpread(SOISpread spread, TRSNode data)
        {
            for (int row = 0; row < spdString1.ActiveSheet.RowCount; row++)
            {
                if (data.GetString("CHMB_CD") != spread.ActiveSheet.Cells[row, 0].Value.ToString() ||
                    data.GetString("CHMB_ATTR") != spread.ActiveSheet.Cells[row, 1].Value.ToString()
                   )
                {
                    continue;
                }

                for (int col = DATA_START_COL; col < MAX_COL_COUNT; col++)
                {
                    int col_lami = m_listLaminator.Count - (MAX_COL_COUNT - col);
                    if (col_lami < 0 || col_lami >= m_listLaminator.Count)
                    {
                        continue;
                    }
                    if (data.GetString("RES_ID") == m_listLaminator[col_lami])
                    {
                        string itemVal = data.GetDouble("ATTR_VAL").ToString();
                        spread.ActiveSheet.Cells[row, col].Value = itemVal=="-999999999"?null:itemVal;
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        

        private void resetData()
        {
            //cleardata();
            //getLaminatorResource();

            checkCellEdited(spdString1);
            checkCellEdited(spdString2);
        }

        private bool validateRule()
        {
            if (checkCellEdited(spdString1) == false ||
                checkCellEdited(spdString2) == false)
            {
                MPCF.ShowMessage("All cells must be filled out", MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        //Only when users enter new set of data--all cells must be filled out. 
        private bool checkCellEdited(SOISpread spread)
        {
            bool bAllEdited = true;

            for (int row = 0; row < spread.ActiveSheet.RowCount; row++)
            {
                for (int col = 3; col < MAX_COL_COUNT; col++)
                {
                    if (spread.ActiveSheet.Cells[row, 0].Value == null ||
                        spread.ActiveSheet.Cells[row, 1].Value == null)
                    {
                        continue;
                    }
                    if (spread.ActiveSheet.Cells[row, col].Value == null)
                    {
                        spread.ActiveSheet.Cells[row, col].BackColor = CELL_NULL_COLOR;// Color.FromArgb(255, 200, 0, 0);
                        bAllEdited = false;
                    }
                    else
                    {
                        spread.ActiveSheet.Cells[row, col].BackColor = Color.FromArgb(61,69,80);
                    }

                }
            }

            return bAllEdited;
        }


        private void spdChmb2_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            FarPoint.Win.Spread.Cell activeCell = ((FarPoint.Win.Spread.SheetView)sender).ActiveCell;
            if (activeCell.Value == null)
            {
                activeCell.BackColor = CELL_NULL_COLOR;
            }
            else
            {
                if (activeCell.Column.Index > 2)
                {
                    activeCell.BackColor = Color.FromArgb(61, 69, 80);
                }
            }
        }

        private void spdChmb1_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            FarPoint.Win.Spread.Cell activeCell = ((FarPoint.Win.Spread.SheetView)sender).ActiveCell;
            if (activeCell.Value == null)
            {
                activeCell.BackColor = CELL_NULL_COLOR;
            }
            else
            {
                if (activeCell.Column.Index > 2)
                {
                    activeCell.BackColor = Color.FromArgb(61, 69, 80);
                }
            }
        }

        private void soiRadioButton1_ValueChanged(object sender, EventArgs e)
        {
            if (soiRadioButton1.CheckedIndex == 0)
            {
                //initModuleGrid();
                //soiGroupBox15.Text = "PO Change (Module)";
            }
            else if (soiRadioButton1.CheckedIndex == 1)
            {
                //initTrayGrid();
                //soiGroupBox15.Text = "PO Change (Tray)";
            }
            else
            {
                MPCF.ShowMessage("Radio Index Error Please contact MES Team", MSG_LEVEL.ERROR, false);
            }
        }

        // 사용 안함.
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckCondition("VIEW") == false)
                //{
                //    return;
                //}

                //if (!ViewTrayStringList(txtTrayID.Text))
                //{
                //    return;
                //}

                //if (!ViewStringInfoList(txtTrayID.Text) == false)
                //{
                //    return;
                //}

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
        
        private bool ViewTrayStringList(string sTrayId)
        {
            try
            {
                int i;

                FarPoint.Win.Spread.CellType.TextCellType txt = new FarPoint.Win.Spread.CellType.TextCellType();

                txt.MaxLength = 450;

                //MPCF.ClearList(spdString1);
                //MPCF.ClearList(spdString2);

                TRSNode in_node = new TRSNode("VIEW_STRING_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_STRING_LIST_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TRAY_ID", MPCF.Trim(txtTrayID.Text));

                //cdvLineID.Text = cdvLineID.Show(cdvLineID, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                if (MPCF.CallService("CWIP", "CWIP_View_Tray_String_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                spdString1.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];
                    spdString1.ActiveSheet.RowCount++;
                    spdString1.ActiveSheet.Cells[i, (int)SPD_TRAY_STRING_LIST.NO].Value = out_node.GetList(0).Count - i; // i + 1;
                    spdString1.ActiveSheet.Cells[i, (int)SPD_TRAY_STRING_LIST.STRING_ID].Value = out_list.GetString("STRING_ID");
                    spdString1.ActiveSheet.Cells[i, (int)SPD_TRAY_STRING_LIST.RES_ID].Value = out_list.GetString("RES_ID");
                    spdString1.ActiveSheet.Cells[i, 1].CellType = txt;
                    //spdString1.ActiveSheet.Cells[i, 1].BackColor = Color.White;
                    //spdString1.ActiveSheet.Cells[i, 1].ForeColor = Color.Black;
                }
                //spdString1.Sheets[0].Columns[0].Width = 70;
                //spdString1.Sheets[0].Columns[1].Width = 200;
                
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ViewStringInfoList(string sTrayId)
        {
            try
            {
                int i;

                FarPoint.Win.Spread.CellType.TextCellType txt = new FarPoint.Win.Spread.CellType.TextCellType();

                txt.MaxLength = 499;

                //MPCF.ClearList(spdString2);

                TRSNode in_node = new TRSNode("VIEW_STRING_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_STRING_LIST_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("TRAY_ID", MPCF.Trim(txtTrayID.Text));
                //in_node.AddString("STRING_ID", MPCF.Trim(spdString1.ActiveSheet.Cells[spdString1.ActiveSheet.ActiveRowIndex, 0].Text));

                if (MPCF.CallService("CWIP", "CWIP_View_Tray_String_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                spdString2.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];
                    spdString2.ActiveSheet.RowCount++;
                    spdString2.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.NO].Value = i + 1;
                    spdString2.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.INS_TYPE].Value = out_list.GetString("INS_TYPE");
                    spdString2.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.LOT_ID].Value = out_list.GetString("LOT_ID");
                    spdString2.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.INS_TIME].Value = out_list.GetString("INS_TIME");
                    spdString2.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.IMG_PATH].Value = out_list.GetString("IMAGE_PATH");
                    //spdString1.ActiveSheet.Cells[i, 3].CellType = txt; 
                    //spdString1.ActiveSheet.Cells[i, 3].BackColor = Color.White;
                    //spdString1.ActiveSheet.Cells[i, 3].ForeColor = Color.Black;
                }
                spdString2.Sheets[0].Columns[0].Width = 70;
                spdString2.Sheets[0].Columns[1].Width = 100;
                spdString2.Sheets[0].Columns[2].Width = 200;
                spdString2.Sheets[0].Columns[3].Width = 150;
                spdString2.Sheets[0].Columns[4].Width = 150;

                strELImagePath = spdString2.ActiveSheet.Cells[0, (int)SPD_STRING_INSP_LIST.IMG_PATH].Value.ToString();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ViewStringInfoList2()
        {
            try
            {
                spdString2.Sheets[0].Rows.Clear();

                var sresid = spdString1.ActiveSheet.Cells[0, (int)SPD_TRAY_STRING_LIST.RES_ID].Value;

                if (sresid.ToString() == "S_EQ")
                {
                    for (int i = 0; i < spdString1.ActiveSheet.RowCount; i++)
                    {
                        TRSNode in_node = new TRSNode("VIEW_STRING_LIST_IN");
                        TRSNode out_node = new TRSNode("VIEW_STRING_LIST_OUT");
                        //TRSNode stringList;


                        MPCF.SetInMsg(in_node);
                        in_node.ProcStep = '4';
                        in_node.AddString("TRAY_ID", MPCF.Trim(txtTrayID.Text));
                        in_node.AddString("STRING_ID", MPCF.Trim(spdString1.ActiveSheet.Cells[i, (int)SPD_TRAY_STRING_LIST.STRING_ID].Value.ToString()));
                        if (MPCF.CallService("CWIP", "CWIP_View_Tray_String_List", in_node, ref out_node) == false)
                        {
                            //return false;
                        }

                        MPCF.ShowSuccessMessage(out_node, false);

                        int iRow = 0;

                        for (int j = 0; j < out_node.GetList(0).Count; j++)
                        {
                            iRow = spdString2.Sheets[0].Rows.Count;
                            spdString2.Sheets[0].RowCount++;

                            spdString2.Sheets[0].Cells[iRow, (int)SPD_STRING_INSP_LIST.NO].Value = MPCF.Trim(spdString1.ActiveSheet.Cells[i, (int)SPD_TRAY_STRING_LIST.NO].Value.ToString());
                            spdString2.Sheets[0].Cells[iRow, (int)SPD_STRING_INSP_LIST.INS_TYPE].Value = out_node.GetList(0)[j].GetString("INS_TYPE");
                            spdString2.Sheets[0].Cells[iRow, (int)SPD_STRING_INSP_LIST.LOT_ID].Value = out_node.GetList(0)[j].GetString("LOT_ID");
                            spdString2.Sheets[0].Cells[iRow, (int)SPD_STRING_INSP_LIST.INS_TIME].Value = out_node.GetList(0)[j].GetString("INS_TIME"); 
                            spdString2.Sheets[0].Cells[iRow, (int)SPD_STRING_INSP_LIST.IMG_PATH].Value = out_node.GetList(0)[j].GetString("IMAGE_PATH");
                        }

                    }
                }
                else
                {
                    for (int i = 0; i < spdString1.ActiveSheet.RowCount; i++)
                    {
                        TRSNode in_node = new TRSNode("VIEW_STRING_LIST_IN");
                        TRSNode out_node = new TRSNode("VIEW_STRING_LIST_OUT");

                        MPCF.SetInMsg(in_node);
                        in_node.ProcStep = '3';
                        in_node.AddString("STRING_ID", MPCF.Trim(spdString1.ActiveSheet.Cells[i, (int)SPD_TRAY_STRING_LIST.STRING_ID].Value.ToString()));
                        in_node.AddString("IMAGE_TYPE", "AMRR");
                        in_node.AddString("INS_TYPE", "AU");
                        //in_node.AddString("STRING_ID", MPCF.Trim(spdString1.ActiveSheet.Cells[spdString1.ActiveSheet.ActiveRowIndex, 0].Text)); // 선택하는것 사용시

                        if (MPCF.CallService("CWIP", "CWIP_View_Tray_String_List", in_node, ref out_node) == false)
                        {
                            //return false;
                        }

                        MPCF.ShowSuccessMessage(out_node, false);

                        spdString2.ActiveSheet.RowCount++;
                        spdString2.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.NO].Value = spdString1.ActiveSheet.RowCount - i;//i + 1;
                        spdString2.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.INS_TYPE].Value = out_node.GetString("INS_TYPE");
                        spdString2.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.LOT_ID].Value = out_node.GetString("LOT_ID");
                        spdString2.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.INS_TIME].Value = out_node.GetString("INS_TIME");
                        spdString2.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.IMG_PATH].Value = out_node.GetString("IMAGE_PATH");
                    }
                    for (int i = 0; i < spdString1.ActiveSheet.RowCount; i++)
                    {
                        TRSNode in_node = new TRSNode("VIEW_STRING_LIST_IN");
                        TRSNode out_node = new TRSNode("VIEW_STRING_LIST_OUT");

                        MPCF.SetInMsg(in_node);
                        in_node.ProcStep = '3';
                        in_node.AddString("STRING_ID", MPCF.Trim(spdString1.ActiveSheet.Cells[i, (int)SPD_TRAY_STRING_LIST.STRING_ID].Value.ToString()));
                        in_node.AddString("IMAGE_TYPE", "AMRE");
                        in_node.AddString("INS_TYPE", "AB");

                        if (MPCF.CallService("CWIP", "CWIP_View_Tray_String_List", in_node, ref out_node) == false)
                        {
                            //return false;
                        }

                        MPCF.ShowSuccessMessage(out_node, false);
                        if (out_node.GetString("INS_TYPE") != "")
                        {
                            spdString2.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.NO].Value = spdString1.ActiveSheet.RowCount - i;//i + 1;
                            spdString2.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.INS_TYPE].Value = out_node.GetString("INS_TYPE");
                            spdString2.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.LOT_ID].Value = out_node.GetString("LOT_ID");
                            spdString2.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.INS_TIME].Value = out_node.GetString("INS_TIME");
                            spdString2.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.IMG_PATH].Value = out_node.GetString("IMAGE_PATH");
                        }
                    }
                }

                

                strELImagePath = spdString2.ActiveSheet.Cells[0, (int)SPD_STRING_INSP_LIST.IMG_PATH].Value.ToString();
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool PopupView()
        {
            //strELImagePath 이미지 순차적으로 한장씩 보여줌.
            try
            {
                
                strELImagePath = spdString2.ActiveSheet.Cells[0, (int)SPD_STRING_INSP_LIST.IMG_PATH].Value.ToString();

                if (strELImagePath == "")
                {
                    return true;
                }

                if(strELImagePath != "")
                {
                    frmCWIPStringCellImagePopup pop;
                    pop = (frmCWIPStringCellImagePopup)GetForm("frmCWIPStringCellImagePopup");

                    var type = "1"; // Next

                    try
                    {
                        for (int i = 0; i < spdString2.ActiveSheet.RowCount; i++)
                        {
                            pop = new frmCWIPStringCellImagePopup(strELImagePath, type  , (spdString2.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.NO].Value).ToString());

                            Screen[] scr = Screen.AllScreens;

                            if (scr.Length > 1)
                            {
                                Screen screen = (scr[0].WorkingArea.Contains(this.Location)) ? scr[1] : scr[0]; // 현재모니터 찾기                        
                                pop.Location = screen.Bounds.Location; // 모니터위치 변경
                            }

                            pop.Owner = MPGV.gfrmMDI;
                            pop.WindowState = FormWindowState.Maximized;
                            pop.TopMost = true;

                            if (strELImagePath == null || strELImagePath == "" || strELImagePath == " ")
                            {

                                string strViewError;
                                string strErrorMsg = "The string does not have an image.";
                                strViewError =
                                               "String Number ( " +  (spdString2.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.NO].Value).ToString() + " )" + "\r\n"
                                             + "----------------------------------\r\n"
                                             + strErrorMsg;

                                // 기본 dll ShowMessage
                                MPCF.ShowMessage(strViewError, MSG_LEVEL.ERROR, true);
                            }

                            pop.ShowDialog();
                            type = pop._Type;

                            if (type == "1" && (i + 1) == spdString1.ActiveSheet.RowCount) 
                            {
                                return false;
                            }
                            else if (type == "1")
                            {
                                strELImagePath = spdString2.ActiveSheet.Cells[i + 1, (int)SPD_STRING_INSP_LIST.IMG_PATH].Value.ToString();
                            }
                            else
                                return false;
                        }

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }

                MPCF.SetFocusAndSelectAll(txtTrayID);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return false;
        }

        private bool PopupView2()
        {
            try
            {

                strELImagePath = spdString2.ActiveSheet.Cells[0, (int)SPD_STRING_INSP_LIST.IMG_PATH].Value.ToString();

                if (strELImagePath == "")
                {
                    return true;
                }

                if (strELImagePath != "")
                {
                    frmCWIPStringCellImagePopup pop;
                    pop = (frmCWIPStringCellImagePopup)GetForm("frmCWIPStringCellImagePopup");

                    var type = "1"; // Next

                    try
                    {
                        for (int i = 0; i < spdString2.ActiveSheet.RowCount; i++)
                        {
                            pop = new frmCWIPStringCellImagePopup(strELImagePath, type, (spdString2.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.NO].Value).ToString());

                            Screen[] scr = Screen.AllScreens;

                            if (scr.Length > 1)
                            {
                                Screen screen = (scr[0].WorkingArea.Contains(this.Location)) ? scr[1] : scr[0]; // 현재모니터 찾기                        
                                pop.Location = screen.Bounds.Location; // 모니터위치 변경
                            }

                            pop.Owner = MPGV.gfrmMDI;
                            pop.WindowState = FormWindowState.Maximized;
                            pop.TopMost = true;

                            if (strELImagePath == null || strELImagePath == "" || strELImagePath == " ")
                            {

                                string strViewError;
                                string strErrorMsg = "The string does not have an image.";
                                strViewError =
                                               "String Number ( " + (spdString2.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.NO].Value).ToString() + " )" + "\r\n"
                                             + "----------------------------------\r\n"
                                             + strErrorMsg;

                                // 기본 dll ShowMessage
                                MPCF.ShowMessage(strViewError, MSG_LEVEL.ERROR, true);
                            }

                            pop.ShowDialog();
                            type = pop._Type;

                            if (type == "1" && (i + 1) == spdString1.ActiveSheet.RowCount)
                            {
                                return false;
                            }
                            else if (type == "1")
                            {
                                strELImagePath = spdString2.ActiveSheet.Cells[i + 1, (int)SPD_STRING_INSP_LIST.IMG_PATH].Value.ToString();
                            }
                            else
                                return false;
                        }

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }

                MPCF.SetFocusAndSelectAll(txtTrayID);

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return false;
        }

        private void btnVision_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtTrayID.Text) == true)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Tray ID]"));
                MPCF.SetFocusAndSelectAll(txtTrayID);
                return;
            }

            if (strELImagePath.Equals("") || strELImagePath.Equals(" "))
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(551) + Environment.NewLine + MPCF.FindLanguage("[String ID]"));
                MPCF.SetFocusAndSelectAll(txtTrayID);
                return;
            }
            else// if(strELImagePath != "")
            {
                frmCWIPFullCellImageMultiDpPopup pop;
                pop = (frmCWIPFullCellImageMultiDpPopup)GetForm("frmCWIPFullCellImageMultiDpPopup");

                if (pop == null)
                {
                    try
                    {
                        pop = new frmCWIPFullCellImageMultiDpPopup(strELImagePath);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    pop.setPic(strELImagePath);
                    MPCF.SetFocusAndSelectAll(txtTrayID);

                    return;
                }

                Screen[] scr = Screen.AllScreens;

                if (scr.Length > 1)
                {
                    Screen screen = (scr[0].WorkingArea.Contains(this.Location)) ? scr[1] : scr[0]; // 현재모니터 찾기                        
                    pop.Location = screen.Bounds.Location; // 모니터위치 변경
                }

                pop.Owner = MPGV.gfrmMDI;
                pop.WindowState = FormWindowState.Maximized;
                pop.TopMost = true;
                pop.Show();

            }

            MPCF.SetFocusAndSelectAll(txtTrayID);

        }

        private void spdString1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (spdString1.Sheets[0].RowCount > 0)
            {
                //gsClear();

                gStringID = spdString1.Sheets[0].Cells[e.Row, (int)SPD_TRAY_STRING_LIST.STRING_ID].Text;
            }
        }

        private void spdString2_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (spdString2.Sheets[0].RowCount > 0)
            {
                //gsClear();

                gInsType = spdString2.Sheets[0].Cells[e.Row, (int)SPD_STRING_INSP_LIST.INS_TYPE].Text;
                gImgPath = spdString2.Sheets[0].Cells[e.Row, (int)SPD_STRING_INSP_LIST.IMG_PATH].Text;
                strELImagePath = spdString2.Sheets[0].Cells[e.Row, (int)SPD_STRING_INSP_LIST.IMG_PATH].Text;
            }
        }

        private void txtTrayID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER && MPCF.Trim(txtTrayID.Text) != "")
            {
                ClearData();

                txtTrayID.Text = MPCF.ToUpper(txtTrayID.Text); // 일괄 대문자

                if (!CheckCondition("VIEW"))
                {
                    MPCF.SetFocusAndSelectAll(txtTrayID);
                    return;
                }

                if (!ViewTrayStringList(txtTrayID.Text))
                {
                    MPCF.SetFocusAndSelectAll(txtTrayID);
                    return;
                }

                //procstrp = 3 // 기존 속도 이슈 -> 데이터 이슈로 엎어쳐야함.
                if (!ViewStringInfoList2())
                {
                    MPCF.SetFocusAndSelectAll(txtTrayID);
                    return;
                }

                if(!PopupView())
                {
                    MPCF.SetFocusAndSelectAll(txtTrayID);
                    return;
                }

                #region
                //if (string.IsNullOrEmpty(txtLotID.Text) == true)
                //{
                //    MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[MODULE ID]"));
                //    MPCF.SetFocusAndSelectAll(txtLotID);
                //    return;
                //}

                //if (strImagePath.Equals("") || strImagePath.Equals(" "))
                //{
                //    MPCF.ShowMsgBox(MPCF.GetMessage(551) + Environment.NewLine + MPCF.FindLanguage("[MODULE ID]"));
                //    MPCF.SetFocusAndSelectAll(txtLotID);
                //    return;
                //}
                //else// if(strImagePath != "")
                //{
                //    frmCWIPFullCellImageMultiDpPopup pop;
                //    pop = (frmCWIPFullCellImageMultiDpPopup)GetForm("frmCWIPFullCellImageMultiDpPopup");

                //    if (pop == null)
                //    {
                //        try
                //        {
                //            pop = new frmCWIPFullCellImageMultiDpPopup(strImagePath);
                //        }
                //        catch (Exception ex)
                //        {
                //            throw ex;
                //        }
                //    }
                //    else
                //    {
                //        pop.setPic(strImagePath);
                //        MPCF.SetFocusAndSelectAll(txtLotID);

                //        return;
                //    }

                //    Screen[] scr = Screen.AllScreens;

                //    if (scr.Length > 1)
                //    {
                //        Screen screen = (scr[0].WorkingArea.Contains(this.Location)) ? scr[1] : scr[0]; // 현재모니터 찾기                        
                //        pop.Location = screen.Bounds.Location; // 모니터위치 변경
                //    }

                //    pop.Owner = MPGV.gfrmMDI;
                //    pop.WindowState = FormWindowState.Maximized;
                //    pop.TopMost = true;
                //    pop.Show();

                //}
                #endregion

                MPCF.SetFocusAndSelectAll(txtTrayID);
            }
        }

        private object GetForm(string formName)
        {
            foreach (Form frm in Application.OpenForms)
                if (frm.Name == formName)
                    return frm;

            return null;
        }
    }
}
