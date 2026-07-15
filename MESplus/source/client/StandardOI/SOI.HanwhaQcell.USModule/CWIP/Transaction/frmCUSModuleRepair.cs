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
    public partial class frmCUSModuleRepair : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private string s;
        private FarPoint.Win.Spread.Model.CellRange cr;

        #endregion

        #region Constructor

        #region [Constant Definition]

        const int ENTER = 13;

        public enum LOT_LIST
        {
            NO,
            LOSS_TYPE,
            LOSS_CODE,
            LOSS_DESC,
            X,
            Y,
            FLAG,
            LOSS_CATEGORY,
            CELL_ID,
            LOSS_SEQ
        }

        #endregion
        
        public string str_cell;

        public frmCUSModuleRepair()
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
        private void frmTempSOIBaseForm02_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);

            cr = new FarPoint.Win.Spread.Model.CellRange(0, 0, 1, 1);
            s = spdCellMap.ActiveSheet.GetClip(0, 0, 1, 1);
            dtpWorkTime.Value = DateTime.Today;

        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm02_Shown(object sender, EventArgs e)
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
                // Code View Service
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "@LINE_CODE");
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Line", "Line Desc" };
                cdvLineID.Text = cdvLineID.Show(cdvLineID, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Line");

                // Validation
                if (string.IsNullOrEmpty(cdvLineID.Text) == true)
                {
                    return;
                }

                // Focus
                MPCF.SetFocus(cdvLineID);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

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

        private void cdvLossCode_CodeViewButtonClick(object sender, EventArgs e)
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

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@DEFECT"));

                // CodeView Column Header Setup
                string[] header = new string[] { "Defect Code", "Sorting Criteria", "Type", "Defect Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1", "DATA_2", "DATA_3" };

                // Show
                cdvLossCode.Code = cdvLossCode.Show(cdvLossCode, "Loss Code", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");


                // Validation
                if (string.IsNullOrEmpty(cdvLossCode.Text) == true)
                {
                    MPCF.SetFocus(cdvLossCode);
                    return;
                }

                // Focus
                MPCF.SetFocus(cdvLossCode);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckCondition("ADD"))
                return;

            SetCellMap();
        }

        private void cdvLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER && MPCF.Trim(txtLotID.Text) != "")
            {
                txtLotID.Text = MPCF.ToUpper(txtLotID.Text); // 일괄 대문자

                ClearData("1");

                if (!CheckCondition("VIEW"))
                    return;

                if (!ViewLoss(txtLotID.Text))
                    return;

            }
        }

        private void txtPosition_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strXposition = "";
            string strYposition = "";
            string strPosition = "";
            int x = 0;
            int y = 0;

            if (e.KeyChar == ENTER && MPCF.Trim(txtLotID.Text) != "")
            {
                strPosition = MPCF.Trim(txtPosition.Text.ToUpper());
                strXposition = strPosition.Substring(0, 1);
                strYposition = strPosition.Substring(1, strPosition.Length - 1);
                              
                GetPositionValue(strXposition, strYposition, ref x, ref y);

                if (x > 5 || y > 24)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(505), MSG_LEVEL.ERROR, false);
                    txtPosition.Text = "";
                    return;
                }

                y = y - 1;
                if (y < 0)
                    y = 0;

                spdCellMap.ActiveSheet.Cells[x, y].BackColor = System.Drawing.Color.Red;
                AddLossCode(x, y);

            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (!CheckCondition("PROCESS"))
                return;


            if (Module_Loss_Input() == true)
            {
                ViewLoss(txtLotID.Text);
                MPCF.SetFocus(txtLotID);
            }
        }

        private bool Module_Loss_Input()
        {
            TRSNode in_node = new TRSNode("MODULE_LOSS_IN");
            TRSNode out_node = new TRSNode("MODULE_LOSS_OUT");
            DateTime dtpDateTime = new DateTime();

            TRSNode list_item;
            string strPosition = "";
            string strTmpCellID = "";
            string strTmpStringID = "";
            string strRepairDetail = "";

            try
            {
                MPCF.SetInMsg(in_node);

                in_node.ProcStep = '3';  // '3' Module Repair
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));              // LINE ID
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));              // LOT ID
                in_node.AddString("LOSS_CATEGORY", "EL");                      // MODULE_LOSS
                in_node.AddString("WORK_SHIFT", MPCF.Trim(cdvShiftID.Text));        // WORK_SHIFT
                in_node.AddString("STATUS_FLAG", "2");                              // STATUS_FLAG (1" AUTO,  2: MANUAL)

                if (dtpWorkTime.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpWorkTime.Value.ToString(), out dtpDateTime);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpDateTime.ToString("yyyyMMdd"));
                    }
                }

                int iRowCnt = 0;
                for (int i = 0; i < spdRepairInfo.ActiveSheet.RowCount; i++)
                {
                    iRowCnt++;
                }

                for (int k = spdRepairInfo.ActiveSheet.RowCount - 1; k > -1; k--)
                {                    
                    //if (spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.FLAG].Value != "I")
                    //    continue;

                    strTmpCellID = "";
                    strTmpStringID = "";
                    strPosition = spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.X].Value.ToString() + spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.Y].Value.ToString();
                    strTmpCellID = txtLotID.Text + "-" + strPosition;
                    strTmpStringID = txtLotID.Text + "-" + spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.X].Value;

                    list_item = in_node.AddNode("LOSS_LIST");
                    list_item.AddInt("LOSS_SEQ", MPCF.Trim(spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.LOSS_SEQ].Value));
                    list_item.AddString("CELL_ID", strTmpCellID);
                    //list_item.AddString("CELL_ID", txtLotID.Text);
                    list_item.AddString("STRING_ID", strTmpStringID);
                    list_item.AddString("LOCATION_ID", strPosition);
                    list_item.AddString("STATUS_FLAG", "2");                    // '1' : AUTO,  '2' : MANUAL
                    list_item.AddString("TYPE_FLAG", MPCF.Trim(cboLosstype.Text));
                    list_item.AddString("LOSS_GROUP", "EL");
                    list_item.AddString("LOSS_CODE", MPCF.Trim(spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.LOSS_CODE].Value));
                    list_item.AddString("LOSS_TYPE", MPCF.Trim(spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.LOSS_TYPE].Value.ToString()));
                    list_item.AddDouble("LOSS_QTY", 1);
                    list_item.AddString("LOC_X", MPCF.Trim(spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.X].Value));
                    list_item.AddString("LOC_Y", MPCF.Trim(spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.Y].Value));
                    list_item.AddString("CMF_1", MPCF.Trim(cdvRepairTable.Text));   //Repair Table
                    list_item.AddString("CMF_2", MPCF.Trim(cdvSoldering.Text));     //Repair Soldering
                    list_item.AddString("CMF_3", MPCF.Trim(txtWorker.Text));        //Worker
                    list_item.AddString("REP_COMMENT", "");                         //REP_COMMENT
                    list_item.AddString("SAVE_FLAG", MPCF.Trim(spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.FLAG].Value));
                    
                    if (k==0)
                    {
                        strRepairDetail = strRepairDetail + strPosition;
                    }
                    else
                    {
                        strRepairDetail = strRepairDetail + strPosition + ",";
                    }
                }

                in_node.AddString("REPAIR_DETAIL", strRepairDetail);        // REPAIR_DETAIL

                if (MPCF.CallService("CWIP", "CWIP_Update_Module_Repair", in_node, ref out_node) == false)
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

        private bool Module_Loss_Delete(int iDelRow)
        {
            TRSNode in_node = new TRSNode("MODULE_LOSS_DELETE_IN");
            TRSNode out_node = new TRSNode("MODULE_LOSS_DELETE_OUT");


            try
            {
                MPCF.SetInMsg(in_node);

                in_node.ProcStep = '4';  // '4' Delete Module Repair
                in_node.AddString("LOSS_CATEGORY", spdRepairInfo.ActiveSheet.Cells[iDelRow, (int)LOT_LIST.LOSS_CATEGORY].Value);          
                in_node.AddString("CELL_ID", spdRepairInfo.ActiveSheet.Cells[iDelRow, (int)LOT_LIST.CELL_ID].Value);          
                in_node.AddInt("LOSS_SEQ",spdRepairInfo.ActiveSheet.Cells[iDelRow, (int)LOT_LIST.LOSS_SEQ].Value);        

                if (MPCF.CallService("CWIP", "CWIP_Update_Module_Repair", in_node, ref out_node) == false)
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

        private void cdvRepairTable_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Code View Service
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "@REPAIR_TABLE");
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Table", "Table Desc" };
                cdvRepairTable.Text = cdvRepairTable.Show(cdvRepairTable, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Table");

                // Validation
                if (string.IsNullOrEmpty(cdvRepairTable.Text) == true)
                {
                    return;
                }

                // Focus
                MPCF.SetFocus(cdvSoldering);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvSoldering_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Code View Service
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "@REPAIR_SOLDERING");
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Soldering", "Soldering Desc" };
                cdvSoldering.Text = cdvSoldering.Show(cdvSoldering, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Soldering");

                // Validation
                if (string.IsNullOrEmpty(cdvSoldering.Text) == true)
                {
                    return;
                }

                // Focus
                MPCF.SetFocus(txtWorker);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void txtWorker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER && MPCF.Trim(txtWorker.Text) != "")
            {
                // Focus
                MPCF.SetFocus(txtLotID);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string x_position = "";
                string y_position = "";
                int x = 0;
                int y = 0;

                if (spdRepairInfo.ActiveSheet.RowCount == 0)
                {
                    MPCF.ShowErrorMessage(MPCF.GetMessage(192));
                    return;
                }

                x_position = MPCF.Trim(spdRepairInfo.ActiveSheet.Cells[spdRepairInfo.ActiveSheet.ActiveRowIndex, (int)LOT_LIST.X].Value);
                y_position = MPCF.Trim(spdRepairInfo.ActiveSheet.Cells[spdRepairInfo.ActiveSheet.ActiveRowIndex, (int)LOT_LIST.Y].Value);

                GetPositionValue(x_position, y_position, ref x, ref y);

                spdCellMap.ActiveSheet.Cells[x, y-1].BackColor = System.Drawing.Color.Transparent;
                spdCellMap.ActiveSheet.Cells[x, y-1].Text = "";
                if (spdRepairInfo.ActiveSheet.Cells[spdRepairInfo.ActiveSheet.ActiveRowIndex, (int)LOT_LIST.FLAG].Text == "I")
                {
                    spdRepairInfo.ActiveSheet.Rows.Remove(spdRepairInfo.ActiveSheet.ActiveRowIndex, 1);
                }
                else
                {
                    if (Module_Loss_Delete(spdRepairInfo.ActiveSheet.ActiveRowIndex) == false)
                        return;

                    spdRepairInfo.ActiveSheet.Rows.Remove(spdRepairInfo.ActiveSheet.ActiveRowIndex, 1);                    

                }
                int iRowCount = spdRepairInfo.ActiveSheet.RowCount;

                for (int i = 0; i < spdRepairInfo.ActiveSheet.RowCount; i++)
                {
                    spdRepairInfo.ActiveSheet.Cells[i, (int)LOT_LIST.NO].Value = iRowCount;
                    iRowCount--;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void spdCellMap_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {

                cr = spdCellMap.ActiveSheet.GetSelection(0);

                if (cr == null)
                    return;

                s = spdCellMap.ActiveSheet.GetClip(cr.Row, cr.Column, cr.RowCount, cr.ColumnCount);

                lblRow.Text = (cr.Row + 1).ToString();
                lblCol.Text = (cr.Column + 1).ToString();
                lblRows.Text = (cr.Row + cr.RowCount - 1).ToString();
                lblCols.Text = (cr.Column + cr.ColumnCount - 1).ToString();

                lblPosition.Text = "Position : ( " + lblRow.Text + ", " + lblCol.Text + " )" + " ( " + lblRows.Text + ", " + lblCols.Text + " )";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString() + "You did not make a selection!");
                return;
            }
        }

        #endregion

        #region Function

        private bool ViewLoss(string sLotId)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LOT_IN");
                TRSNode out_node = new TRSNode("VIEW_LOT_OUT");
                string strLossCode = "";
                str_cell = "";
                int x = 0;
                int y = 0;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("LOSS_CATEGORY", "EL");
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));

                if (MPCF.CallService("CWIP", "CWIP_Update_Module_Repair", in_node, ref out_node) == false)
                {
                    return false;
                }
                str_cell = out_node.GetString("MAT_CMF_3");


                //GAP LESS에 따른 셀 수량 체크
                if (str_cell == "120")              //20 col
                {
                    spdCellMap_Sheet1.ColumnCount = 20;

                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "20";


                    this.spdCellMap_Sheet1.Columns.Get(19).Label = "20";
                    this.spdCellMap_Sheet1.Columns.Get(19).Width = 36F;


                }
                else if (str_cell == "144")         //"24 col
                {
                    spdCellMap_Sheet1.ColumnCount = 24;

                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "20";
                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "21";
                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "22";
                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "23";
                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "24";


                    this.spdCellMap_Sheet1.Columns.Get(19).Label = "20";
                    this.spdCellMap_Sheet1.Columns.Get(19).Width = 36F;
                    this.spdCellMap_Sheet1.Columns.Get(20).Label = "21";
                    this.spdCellMap_Sheet1.Columns.Get(20).Width = 36F;
                    this.spdCellMap_Sheet1.Columns.Get(21).Label = "22";
                    this.spdCellMap_Sheet1.Columns.Get(21).Width = 36F;
                    this.spdCellMap_Sheet1.Columns.Get(22).Label = "23";
                    this.spdCellMap_Sheet1.Columns.Get(22).Width = 36F;
                    this.spdCellMap_Sheet1.Columns.Get(23).Label = "24";
                    this.spdCellMap_Sheet1.Columns.Get(23).Width = 36F;



                }
                else if (str_cell == "156")         //"26 col
                {
                    spdCellMap_Sheet1.ColumnCount = 26;
                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "20";
                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "21";
                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "22";
                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "23";
                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "24";
                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "25";
                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "26";

                    this.spdCellMap_Sheet1.Columns.Get(19).Label = "20";
                    this.spdCellMap_Sheet1.Columns.Get(19).Width = 36F;
                    this.spdCellMap_Sheet1.Columns.Get(20).Label = "21";
                    this.spdCellMap_Sheet1.Columns.Get(20).Width = 36F;
                    this.spdCellMap_Sheet1.Columns.Get(21).Label = "22";
                    this.spdCellMap_Sheet1.Columns.Get(21).Width = 36F;
                    this.spdCellMap_Sheet1.Columns.Get(22).Label = "23";
                    this.spdCellMap_Sheet1.Columns.Get(22).Width = 36F;
                    this.spdCellMap_Sheet1.Columns.Get(23).Label = "24";
                    this.spdCellMap_Sheet1.Columns.Get(23).Width = 36F;
                    this.spdCellMap_Sheet1.Columns.Get(24).Label = "25";
                    this.spdCellMap_Sheet1.Columns.Get(24).Width = 36F;
                    this.spdCellMap_Sheet1.Columns.Get(25).Label = "26";
                    this.spdCellMap_Sheet1.Columns.Get(25).Width = 36F;
                }
                else if (str_cell == "132")         //"22 col
                {
                    spdCellMap_Sheet1.ColumnCount = 22;


                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "20";
                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "21";
                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "22";


                    this.spdCellMap_Sheet1.Columns.Get(19).Label = "20";
                    this.spdCellMap_Sheet1.Columns.Get(19).Width = 36F;
                    this.spdCellMap_Sheet1.Columns.Get(20).Label = "21";
                    this.spdCellMap_Sheet1.Columns.Get(20).Width = 36F;
                    this.spdCellMap_Sheet1.Columns.Get(21).Label = "22";
                    this.spdCellMap_Sheet1.Columns.Get(21).Width = 36F;


                }
                else
                {
                    spdCellMap_Sheet1.ColumnCount = 24;

                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "20";
                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "21";
                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "22";
                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "23";
                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "24";


                    this.spdCellMap_Sheet1.Columns.Get(19).Label = "20";
                    this.spdCellMap_Sheet1.Columns.Get(19).Width = 36F;
                    this.spdCellMap_Sheet1.Columns.Get(20).Label = "21";
                    this.spdCellMap_Sheet1.Columns.Get(20).Width = 36F;
                    this.spdCellMap_Sheet1.Columns.Get(21).Label = "22";
                    this.spdCellMap_Sheet1.Columns.Get(21).Width = 36F;
                    this.spdCellMap_Sheet1.Columns.Get(22).Label = "23";
                    this.spdCellMap_Sheet1.Columns.Get(22).Width = 36F;
                    this.spdCellMap_Sheet1.Columns.Get(23).Label = "24";
                    this.spdCellMap_Sheet1.Columns.Get(23).Width = 36F;
                }
                //횟수, 결과, 판정, OSC, ESC, EL, 비고, 설비, 생성일자
                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    spdRepairInfo.ActiveSheet.AddRows(0, 1);
                    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.NO].Value = i + 1;
                    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.LOSS_TYPE].Value = out_node.GetList(0)[i].GetString("LOSS_TYPE");
                    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.LOSS_CODE].Value = out_node.GetList(0)[i].GetString("LOSS_CODE");
                    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.LOSS_DESC].Value = out_node.GetList(0)[i].GetString("LOSS_DESC");
                    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.X].Value = out_node.GetList(0)[i].GetString("LOC_X");
                    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.Y].Value = out_node.GetList(0)[i].GetString("LOC_Y");
                    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.FLAG].Value = "";
                    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.LOSS_CATEGORY].Value = out_node.GetList(0)[i].GetString("LOSS_CATEGORY");
                    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.CELL_ID].Value = out_node.GetList(0)[i].GetString("CELL_ID");
                    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.LOSS_SEQ].Value = out_node.GetList(0)[i].GetInt("LOSS_SEQ");                    

                    GetPositionValue(out_node.GetList(0)[i].GetString("LOC_X"), out_node.GetList(0)[i].GetString("LOC_Y"), ref x, ref y);
                    strLossCode = out_node.GetList(0)[i].GetString("LOSS_CODE");

                    //SetInquryCellMap(x, y, strLossCode);

                    y = Convert.ToInt16(out_node.GetList(0)[i].GetString("LOC_Y"));

                    y = y - 1;

                    if (y < 0)
                        y = 0;

                    SetInquryCellMap(x, y, strLossCode);
                }

                //MPCF.FitColumnHeader(spdLoss);


                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool GetPositionValue(string strx, string stry, ref int x, ref int y)
        {

            switch (strx)
            {
                case "A":
                    x = 0;
                    break;
                case "B":
                    x = 1;
                    break;
                case "C":
                    x = 2;
                    break;
                case "D":
                    x = 3;
                    break;
                case "E":
                    x = 4;
                    break;
                case "F":
                    x = 5;
                    break;

                default:
                    break;
            }

            y = Convert.ToInt16(stry);

            return true;

        }

        private bool SetCellMap()
        {
            try
            {
                for (int k = cr.Row; k < cr.Row + cr.RowCount; k++)
                {
                    for (int j = cr.Column; j < cr.Column + cr.ColumnCount; j++)
                    {
                        spdCellMap.ActiveSheet.Cells[k, j].BackColor = System.Drawing.Color.Red;
                        spdCellMap.ActiveSheet.Cells[k, j].Text = cdvLossCode.Text;
                        AddLossCode(k, j);
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

        private bool SetInquryCellMap(int x, int y, string sLossCode)
        {
            try
            {
                //spdCellMap.ActiveSheet.Cells[x, y].BackColor = System.Drawing.Color.Red;
                spdCellMap.ActiveSheet.Cells[x, y].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF0000");

                spdCellMap.ActiveSheet.Cells[x, y].Text = sLossCode;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "ADD":

                        if (string.IsNullOrEmpty(txtLotID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[MAT ID]"));
                            MPCF.SetFocus(txtLotID);
                            return false;
                        }

                        break;

                    case "PROCESS":

                        if (string.IsNullOrEmpty(cdvLineID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[LINE ID]"));
                            MPCF.SetFocus(cdvLineID);
                            return false;
                        }

                        if (string.IsNullOrEmpty(txtLotID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[MAT ID]"));
                            MPCF.SetFocus(txtLotID);
                            return false;
                        }

                        if (string.IsNullOrEmpty(cboLosstype.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[LOSS TYPE]"));
                            MPCF.SetFocus(cboLosstype);
                            return false;
                        }

                        if (spdRepairInfo.ActiveSheet.RowCount == 0)
                        {
                            //MPCF.ShowMsgBox("저장 할 Data가 존재하지 않습니다.");
                            MPCF.ShowMessage(MPCF.GetMessage(462), MSG_LEVEL.ERROR, false);
                            MPCF.SetFocus(spdCellMap);
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

        private bool AddLossCode(int x, int y)
        {
            try
            {
                string strx = "A";
                string stry = "00";

                switch (x)
                {
                    case 0:
                        strx = "A";
                        break;
                    case 1:
                        strx = "B";
                        break;
                    case 2:
                        strx = "C";
                        break;
                    case 3:
                        strx = "D";
                        break;
                    case 4:
                        strx = "E";
                        break;
                    case 5:
                        strx = "F";
                        break;

                    default:
                        break;
                }

                y = y + 101;
                stry = y.ToString();
                stry = stry.Substring(1, 2);

                spdRepairInfo.ActiveSheet.AddRows(0, 1);
                spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.NO].Value = spdRepairInfo.ActiveSheet.RowCount.ToString();
                spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.LOSS_TYPE].Value = "C";
                spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.LOSS_CODE].Value = cdvLossCode.Code;
                spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.LOSS_DESC].Value = cdvLossCode.Description;
                spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.X].Value = strx;
                spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.Y].Value = stry;
                spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.FLAG].Value = "I";

                return true;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private void ClearData(string ProcStep)
        {
            try
            {
                if (ProcStep == "1")
                {
                    ClearMap();
                    MPCF.ClearList(spdRepairInfo);
                }
            }

            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void ClearMap()
        {
            try
            {
                for (int k = 0; k < spdCellMap.ActiveSheet.RowCount; k++)
                {
                    for (int j = 0; j < spdCellMap.ActiveSheet.ColumnCount; j++)
                    {
                        spdCellMap.ActiveSheet.Cells[k, j].BackColor = System.Drawing.Color.Transparent;
                        spdCellMap.ActiveSheet.Cells[k, j].Text = "";
                        AddLossCode(k, j);
                    }

                }

            }

            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        #endregion

        

        
    }
}
