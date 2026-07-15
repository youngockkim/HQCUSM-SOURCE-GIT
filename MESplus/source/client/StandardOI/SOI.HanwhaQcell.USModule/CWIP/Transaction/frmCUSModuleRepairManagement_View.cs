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

using System.IO;
using System.Net;

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    

    public partial class frmCUSModuleRepairManagement_View : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private string s;
        private FarPoint.Win.Spread.Model.CellRange cr;
        private string strImagePath = "";
        private string strRejectImagePath = "";
        private Dictionary<String, String> m_settings;

        #endregion

        #region Constructor
        public string str_cell;


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
            LOSS_SEQ,
            BACK_COLOR,
            DATA_TYPE,
            CHANGE_QTY,
            LOCATION_ID
        }

        #endregion

        public frmCUSModuleRepairManagement_View()
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
            SetRepairCodeMaster();
            MPCF.SetFocus(txtLotID);

            m_settings = new Dictionary<string, string>();

            getSystemSettings();
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

        private void cdvShift_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {

                // Ver 1. View All Shift Codes
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "@SHIFT");

                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Shift", "Description" };

                cdvShift.Text = cdvShift.Show(cdvShift, "View Shift", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Shift");

                // Validation
                if (string.IsNullOrEmpty(cdvShift.Text) == true)
                {
                    return;
                }


                // Ver 2. View Shift Codes by Date
                /*
                DateTime dtpWorkTimeOut = new DateTime();

                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (dtpWorkTime.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpWorkTime.Value.ToString(), out dtpWorkTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("SYS_DATE", dtpWorkTimeOut.ToString("yyyyMMdd"));
                    }
                }


                string[] display = new string[] { "SHIFT" };
                string[] header = new string[] { "Shift" };

                cdvShift.Text = cdvShift.Show(cdvShift, "View Shift", "CBAS", "CBAS_View_Shift_List", in_node, "LIST", display, header, "SHIFT");

                MPCF.FieldClear(cdvWorker1);
                MPCF.FieldClear(cdvWorker2);

                // Validation
                if (string.IsNullOrEmpty(cdvShift.Text) == true)
                {
                    return;
                }
                */

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
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
            string strLossCategory = "";
            string strLocationID = "";
            int xx = 0;

            try
            {
                MPCF.SetInMsg(in_node);

                in_node.ProcStep = '3';  // '3' Module Repair
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));              // LINE ID
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));              // LOT ID
                in_node.AddString("LOSS_CATEGORY", "EL");                      // MODULE_LOSS
                in_node.AddString("WORK_SHIFT", 'A');        // WORK_SHIFT
                in_node.AddString("STATUS_FLAG", "2");                              // STATUS_FLAG (1" AUTO,  2: MANUAL)

                in_node.AddString("REP_TABLE", MPCF.Trim(cdvRepairTable.Text));   //Repair Table
                in_node.AddString("REP_SOLDER", MPCF.Trim(cdvSoldering.Text));     //Repair Soldering IRON
                in_node.AddString("REP_WORKER", MPCF.Trim(cdvWorker1.Text));        //Worker1
                in_node.AddString("REP_WORKER2", MPCF.Trim(cdvWorker2.Text));        //Worker2

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

                    strLossCategory = MPCF.Trim((string)spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.LOSS_CATEGORY].Value);
                    strLocationID = MPCF.Trim((string)spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.LOCATION_ID].Value);
                    //if (strLossCategory.Equals("B2") || strLossCategory == "")
                    if (strLossCategory.Equals("B1") && 
                        (strLocationID.Equals("A") )|| 
                        (strLocationID.Equals("B") )|| 
                        (strLocationID.Equals("C") )                                               
                       )
                    {
                        continue;
                    }

                    if ((strLossCategory.Equals("B1")) || strLossCategory.Equals("R-B1"))
                    {
                        list_item.AddString("LOSS_CATEGORY", "R-B1");
                        list_item.AddString("LOSS_GROUP", "BUSBAR");
                    }
                    else
                    {
                        list_item.AddString("LOSS_CATEGORY", "R-E1");
                        list_item.AddString("LOSS_GROUP", "EL");
                    }
                    
                    list_item.AddInt("LOSS_SEQ", MPCF.Trim(spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.LOSS_SEQ].Value));
                    list_item.AddString("CELL_ID", strTmpCellID);
                    //list_item.AddString("CELL_ID", txtLotID.Text);
                    list_item.AddString("STRING_ID", strTmpStringID);
                    list_item.AddString("LOCATION_ID", strPosition);
                    list_item.AddString("STATUS_FLAG", "2");                    // '1' : AUTO,  '2' : MANUAL
                    list_item.AddString("TYPE_FLAG",'2');
                    /*
                    if (spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.LOSS_CATEGORY].Value.Equals("B1") ||
                        spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.LOSS_CATEGORY].Value.Equals("B2"))
                    {
                        list_item.AddString("LOSS_GROUP", "BUSBAR");
                    }
                    else
                    {
                        list_item.AddString("LOSS_GROUP", "EL");
                    }
                    */
                    //list_item.AddString("LOSS_GROUP", "EL");
                    list_item.AddString("LOSS_CODE", MPCF.Trim(spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.LOSS_CODE].Value));
                    list_item.AddString("LOSS_TYPE", MPCF.Trim(spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.LOSS_TYPE].Value.ToString()));
                    list_item.AddDouble("LOSS_QTY", 1);
                    list_item.AddString("LOC_X", MPCF.Trim(spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.X].Value));
                    list_item.AddString("LOC_Y", MPCF.Trim(spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.Y].Value));
                    list_item.AddString("CMF_1", MPCF.Trim(cdvRepairTable.Text));   //Repair Table
                    list_item.AddString("CMF_2", MPCF.Trim(cdvSoldering.Text));     //Repair Soldering
                    list_item.AddString("WORKER", MPCF.Trim(cdvWorker1.Text));        //Worker1
                    list_item.AddString("WORKER2", MPCF.Trim(cdvWorker2.Text));        //Worker2
                    list_item.AddString("REP_COMMENT", "");                         //REP_COMMENT
                    list_item.AddString("SAVE_FLAG", MPCF.Trim(spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.FLAG].Value));
                    list_item.AddString("SAVE_COLOR", spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.BACK_COLOR].Value);
                    list_item.AddString("SAVE_TYPE", spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.DATA_TYPE].Value);
                    list_item.AddString("CHANGE_QTY", spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.CHANGE_QTY].Value);
                    //20190917 전단 버스바 추가.
                    list_item.AddString("LOCATION_ID", spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.LOCATION_ID].Value);
                    
                    

                    
                    //list_item.AddString("LOSS_CATEGORY", strLossCategory);
                    //list_item.AddString("LOSS_CATEGORY", "R-E1");




                    

                    
                    

                    if (MPCF.Trim(spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.DATA_TYPE].Value) != "LOSS")
                    {
                        if ((xx == 0) && (MPCF.Trim(spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.DATA_TYPE].Value) == "REPAIR"))
                        {
                            strRepairDetail = MPCF.Trim(spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.LOSS_CODE].Value) + ":" + strPosition;
                            xx++;
                        }
                        else if (MPCF.Trim(spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.DATA_TYPE].Value) == "REPAIR")
                        {
                            strRepairDetail = strRepairDetail + "," + strPosition;
                        }
                    }
                    
                }

                if (xx < 1)
                {
                    //수리데이터 입력없음
                    MPCF.ShowMessage(MPCF.GetMessage(462), MSG_LEVEL.ERROR, false);
                    MPCF.SetFocus(spdCellMap);
                    return false;
                }
                in_node.AddString("REPAIR_DETAIL", strRepairDetail);        // REPAIR_DETAIL

                if (MPCF.CallService("CWIP", "CWIP_Update_Module_Repair", in_node, ref out_node) == false)
                {
                    return false;
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
                MPCF.SetFocus(cdvWorker1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
  
        private void spdCellMap_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (chkMultiSelect.OnOffState == SOICheckBoxOnOffState.OnState)
                {
                    cr = spdCellMap.ActiveSheet.GetSelection(0);

                    if (cr == null)
                        return;

                    s = spdCellMap.ActiveSheet.GetClip(cr.Row, cr.Column, cr.RowCount, cr.ColumnCount);

                    lblRow.Text = (cr.Row + 1).ToString();
                    lblCol.Text = (cr.Column + 1).ToString();
                    lblRows.Text = (cr.Row + cr.RowCount - 1).ToString();
                    lblCols.Text = (cr.Column + cr.ColumnCount - 1).ToString();

                  
                    //lblPosition.Text = "Position : ( " + lblRow.Text + ", " + lblCol.Text + " )" + " ( " + lblRows.Text + ", " + lblCols.Text + " )";
                    

                }
                else
                {
                    cr = spdCellMap.ActiveSheet.GetSelection(0);

                    if (cr == null)
                        return;

                    if ((cr.RowCount) > 1 || (cr.ColumnCount > 1))
                    {
                        MessageBox.Show("You can not make multiple selections.! please Select options for multiple selection ");
                         return;
                    }

                    s = spdCellMap.ActiveSheet.GetClip(cr.Row, cr.Column, cr.RowCount, cr.ColumnCount);

                    lblRow.Text = (cr.Row + 1).ToString();
                    lblCol.Text = (cr.Column + 1).ToString();
                    lblRows.Text = (cr.Row + cr.RowCount - 1).ToString();
                    lblCols.Text = (cr.Column + cr.ColumnCount - 1).ToString();

                    //lblPosition.Text = "Position : ( " + lblRow.Text + ", " + lblCol.Text + " )" + " ( " + lblRows.Text + ", " + lblCols.Text + " )";
                  
                }

                //1을 A 로 C# 에서 어찌빠꿨는지 생각이 안나..
                if (lblRow.Text == "1")
                    lblRow.Tag = "A";
                else if (lblRow.Text == "2")
                    lblRow.Tag = "B";
                else if (lblRow.Text == "3")
                    lblRow.Tag = "C";
                else if (lblRow.Text == "4")
                    lblRow.Tag = "D";
                else if (lblRow.Text == "5")
                    lblRow.Tag = "E";
                else if (lblRow.Text == "6")
                    lblRow.Tag = "F";
                else
                    lblRow.Tag = lblRow.Text;

                lblPosition.Text = "Position : ( " + lblRow.Text + ", " + lblCol.Text + " )" + " ( " + lblRow.Tag + ", " + lblCol.Text + " )";

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString() + "You did not make a selection!");
                return;
            }
        }

        #endregion

        #region Function

        private void SetRepairCodeMaster()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_DATA_OUT");
                int x = 0;
                int y = 0;
                int icnt = 0;
                int i_rgbColor = 0;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "@REPAIR_CODE");
             
                if (MPCF.CallService("CBAS", "CBAS_View_Data_List", in_node, ref out_node) == false)
                {
                    return ;
                }
                icnt = out_node.GetList(0).Count ;

                if (icnt % 2 == 0)
                    spdRepairCode.ActiveSheet.RowCount = icnt / 2 ;
                else
                    spdRepairCode.ActiveSheet.RowCount = icnt / 2 + 1;

                
                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    x = (i) / 2;
                    y = (i) % 2;

                    //button text
                    ((FarPoint.Win.Spread.CellType.ButtonCellType)(spdRepairCode.ActiveSheet.GetCellType(x, y))).Text = 
                                    out_node.GetList(0)[i].GetString("KEY_1") + "-" + out_node.GetList(0)[i].GetString("DATA_2");

                    //button color
                    i_rgbColor = Convert.ToInt32(out_node.GetList(0)[i].GetString("DATA_4"));
                    ((FarPoint.Win.Spread.CellType.ButtonCellType)(spdRepairCode.ActiveSheet.GetCellType(x, y))).ButtonColor = Color.FromArgb(i_rgbColor);

                    
                    spdRepairCode.ActiveSheet.Cells[x, y].Tag = out_node.GetList(0)[i].GetString("KEY_1");  //CODE
                    spdRepairCode.ActiveSheet.Cells[x, y].Note = out_node.GetList(0)[i].GetString("DATA_2"); //TEXT
                    spdRepairCode.ActiveSheet.Cells[x, y].NoteIndicatorColor = Color.FromArgb(i_rgbColor);  //Color
                }

                //CHANGE CELL QTY COLUMN 다시추가
                //spdRepairCode.ActiveSheet.RowCount = spdRepairCode.ActiveSheet.RowCount + 1;

                //FarPoint.Win.Spread.CellType.CheckBoxCellType chk = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                //spdRepairCode.ActiveSheet.Cells[spdRepairCode.ActiveSheet.RowCount-1, 0].CellType = chk;
                //spdRepairCode.ActiveSheet.Cells[spdRepairCode.ActiveSheet.RowCount-1, 0].ColumnSpan = 2;
                //spdRepairCode.ActiveSheet.Cells[spdRepairCode.ActiveSheet.RowCount - 1, 0].Tag = "ChangeCell";
                //((FarPoint.Win.Spread.CellType.CheckBoxCellType)(spdRepairCode.ActiveSheet.GetCellType(spdRepairCode.ActiveSheet.RowCount-1, 0))).Caption =
                //                "Changed Cell Qty ->";
                //spdRepairCode.ActiveSheet.Cells[spdRepairCode.ActiveSheet.RowCount - 1, 0].Value = true;
                //spdRepairCode.ActiveSheet.Cells[spdRepairCode.ActiveSheet.RowCount - 1, 0].ColumnSpan = 1;
                //spdRepairCode.ActiveSheet.Cells[spdRepairCode.ActiveSheet.RowCount - 1, 1].ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }
        private void check_img(string p_emiaddr, string p_time, string p_line, string p_lot_id, string p_res_id)
        {
            try
            {
                long check_file;
                string con_yyyy;
                string con_mm;
                string con_dd;
                string con_line;

                con_line = p_line.Replace("MDL0", "E");

                con_yyyy = p_time.Substring(0, 4);
                con_mm = p_time.Substring(4, 2);
                con_dd = p_time.Substring(6, 2);

                strRejectImagePath = "";

                // IS-21-05-017 p_res_id
                string tempvalue = p_res_id.Substring(6, 1);
                if (p_res_id.Substring(6, 1) == "F")
                {
                    strRejectImagePath = p_emiaddr + "/US-" + con_line + "-FEL-01/" + con_yyyy + "/" + con_mm + "/" + con_dd + "/Auto-Inspection/Reject/" + p_lot_id + "/" + p_lot_id + ".jpg";
                }
                else
                {
                    strRejectImagePath = p_emiaddr + "/US-" + con_line + "-REL-01/" + con_yyyy + "/" + con_mm + "/" + con_dd + "/Auto-Inspection/Reject/" + p_lot_id + "/" + p_lot_id + ".jpg";
                }


                WebRequest request = WebRequest.Create(strRejectImagePath);
                request.Method = "HEAD";
                using (WebResponse response = request.GetResponse())
                {
                    check_file = response.ContentLength;
                    response.Close();

                }
            }
            catch (Exception ex)
            {
                strRejectImagePath = "";
            }

        }         

        private bool ViewLoss(string sLotId)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LOT_IN");
                TRSNode out_node = new TRSNode("VIEW_LOT_OUT");
                string strLossCode = "";
                string strDisplayText = "";
                int x = 0;
                int y = 0;
                int i_rgbColor = 0;
                str_cell = "";
                string strEMIAddr = "";
                string strVirtualDir = "";


                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("LOSS_CATEGORY", "EL");
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));

                if (MPCF.CallService("CWIP", "CWIP_Update_Module_Repair", in_node, ref out_node) == false)
                {
                    return false;
                }

                cdvLineID.Text = out_node.GetString("LINE_ID");
                txtTabber.Text = out_node.GetString("TABBER_ID");
                //if (out_node.GetString("OVER_KILL").Equals("OK"))
                //{
                //    soiRejudgeButton.Enabled = true;
                //}

                
                strImagePath = out_node.GetString("EL_IMAGE_PATH");
                //strImagePath = strImagePath.Replace("\\\\10.60.0.100", "http://10.60.110.42").Replace("\\", "/");
                //[2024.05.14] nas 교체이후 수정 start
                var emiaddr = from env1 in m_settings where env1.Key == "EMI_SERVER_VIP" select env1;
                if (emiaddr.Count() > 0)
                {
                    strEMIAddr = emiaddr.First().Value;
                }
                var emivir1 = from env1 in m_settings where env1.Key == "NAS_VIR_EL_1" select env1;
                var emivir2 = from env1 in m_settings where env1.Key == "NAS_VIR_EL_2" select env1;
                var nassrv1 = from env1 in m_settings where env1.Key == "NAS_SERVER_1" select env1;
                var nassrv2 = from env1 in m_settings where env1.Key == "NAS_SERVER_2" select env1;

                if (strImagePath.IndexOf(nassrv1.First().Value) > 0)
                {
                    strImagePath = strImagePath.Replace("\\\\" + nassrv1.First().Value, strEMIAddr).Replace("\\", "/");
                    if (nassrv1.Count() > 0 && emivir1.Count() > 0)
                    {
                        strVirtualDir = emivir1.First().Value;
                    }
                }
                else if (strImagePath.IndexOf(nassrv2.First().Value) > 0)
                {
                    strImagePath = strImagePath.Replace("\\\\" + nassrv2.First().Value, strEMIAddr).Replace("\\", "/");
                    if (nassrv2.Count() > 0 && emivir1.Count() > 0 && emivir2.Count() > 0)
                    {
                        strVirtualDir = emivir2.First().Value;
                        strImagePath = strImagePath.Replace(emivir1.First().Value, emivir2.First().Value);
                    }
                }

                //[2024.04.23]NAS장애시 이미지 뷰어만 제외하도록 수정 start 
                TRSNode in_gcm_node = new TRSNode("VIEW_GCM_DATA_IN");
                TRSNode out_gcm_node = new TRSNode("VIEW_GCM_DATA_OUT");
                MPCF.SetInMsg(in_gcm_node);
                in_gcm_node.ProcStep = '1';
                in_gcm_node.AddString("TABLE_NAME", MPCF.Trim("@CMN_EMERGENCY"));
                in_gcm_node.AddString("KEY_1", MPCF.Trim("NAS_CONN_FAILED"));

                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_gcm_node, ref out_gcm_node) == false)
                {
                    return false;
                }
                string nas_conn_failed = out_gcm_node.GetList(0)[0].GetString("DATA_1");
                if (nas_conn_failed.Equals("0"))
                {
                    check_img(strEMIAddr + "/" + strVirtualDir, out_node.GetString("INS_TIME"), out_node.GetString("LINE_ID"), sLotId, out_node.GetString("RES_ID"));
                }
                else if (nas_conn_failed.Equals("1"))
                {
                    MPCF.ShowMessage("EL image cannot be displayed due to connection issues. The rest module repair steps on this page can still be proceeded.", MSG_LEVEL.ERROR, false);
                }
                //[2024.04.23]NAS장애시 이미지 뷰어만 제외하도록 수정 end 

                if(strRejectImagePath != "")
                {
                    strImagePath = strRejectImagePath;
                }

                str_cell = out_node.GetString("MAT_CMF_3");

                //GAP LESS에 따른 셀 수량 체크
                if (str_cell == "120")              //20 col
                {
                    spdCellMap_Sheet1.ColumnCount = 20;

                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "20";


                    this.spdCellMap_Sheet1.Columns.Get(19).Label = "20";
                    this.spdCellMap_Sheet1.Columns.Get(19).Width = 50F;


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
                    this.spdCellMap_Sheet1.Columns.Get(19).Width = 50F;
                    this.spdCellMap_Sheet1.Columns.Get(20).Label = "21";
                    this.spdCellMap_Sheet1.Columns.Get(20).Width = 50F;
                    this.spdCellMap_Sheet1.Columns.Get(21).Label = "22";
                    this.spdCellMap_Sheet1.Columns.Get(21).Width = 50F;
                    this.spdCellMap_Sheet1.Columns.Get(22).Label = "23";
                    this.spdCellMap_Sheet1.Columns.Get(22).Width = 50F;
                    this.spdCellMap_Sheet1.Columns.Get(23).Label = "24";
                    this.spdCellMap_Sheet1.Columns.Get(23).Width = 50F;



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
                    this.spdCellMap_Sheet1.Columns.Get(19).Width = 50F;
                    this.spdCellMap_Sheet1.Columns.Get(20).Label = "21";
                    this.spdCellMap_Sheet1.Columns.Get(20).Width = 50F;
                    this.spdCellMap_Sheet1.Columns.Get(21).Label = "22";
                    this.spdCellMap_Sheet1.Columns.Get(21).Width = 50F;
                    this.spdCellMap_Sheet1.Columns.Get(22).Label = "23";
                    this.spdCellMap_Sheet1.Columns.Get(22).Width = 50F;
                    this.spdCellMap_Sheet1.Columns.Get(23).Label = "24";
                    this.spdCellMap_Sheet1.Columns.Get(23).Width = 50F;
                    this.spdCellMap_Sheet1.Columns.Get(24).Label = "25";
                    this.spdCellMap_Sheet1.Columns.Get(24).Width = 50F;
                    this.spdCellMap_Sheet1.Columns.Get(25).Label = "26";
                    this.spdCellMap_Sheet1.Columns.Get(25).Width = 50F;
                }
                else if (str_cell == "132")         //"22 col
                {
                    spdCellMap_Sheet1.ColumnCount = 22;


                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "20";
                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "21";
                    this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "22";
          

                    this.spdCellMap_Sheet1.Columns.Get(19).Label = "20";
                    this.spdCellMap_Sheet1.Columns.Get(19).Width = 50F;
                    this.spdCellMap_Sheet1.Columns.Get(20).Label = "21";
                    this.spdCellMap_Sheet1.Columns.Get(20).Width = 50F;
                    this.spdCellMap_Sheet1.Columns.Get(21).Label = "22";
                    this.spdCellMap_Sheet1.Columns.Get(21).Width = 50F;


                }
                else if (str_cell == "108")         //"18 col
                {
                    spdCellMap_Sheet1.ColumnCount = 18;
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
                    this.spdCellMap_Sheet1.Columns.Get(19).Width = 50F;
                    this.spdCellMap_Sheet1.Columns.Get(20).Label = "21";
                    this.spdCellMap_Sheet1.Columns.Get(20).Width = 50F;
                    this.spdCellMap_Sheet1.Columns.Get(21).Label = "22";
                    this.spdCellMap_Sheet1.Columns.Get(21).Width = 50F;
                    this.spdCellMap_Sheet1.Columns.Get(22).Label = "23";
                    this.spdCellMap_Sheet1.Columns.Get(22).Width = 50F;
                    this.spdCellMap_Sheet1.Columns.Get(23).Label = "24";
                    this.spdCellMap_Sheet1.Columns.Get(23).Width = 50F;
                }
                //GAP LESS에 따른 셀 수량 체크



                //strRedId = out_node.GetString("RES_ID");
                //strLineId = out_node.GetString("LINE_ID");
                //strModeCode = out_node.GetChar("MODE_CODE").ToString();
                // 0:Manual, 1:Semi Auto, 2:Semi Full Auto, 3:Full Auto
                // Full Auto Mode 일때만 과검 판정 가능하도록 수정.

                //strLotId = MPCF.Trim(sLotId);

                //전단 버스바 20190920 soiTextBoxA.Text를 전역 변수로 사용하여 soiTextBoxA.Text = " "로 설정하여 포커스를 잃었을 때 BackColor 변하지 않토록 사용.
                soiTextBoxA.Text = "";
                soiTextBoxB.Text = "";
                soiTextBoxC.Text = "";
                //횟수, 결과, 판정, OSC, ESC, EL, 비고, 설비, 생성일자
                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (out_node.GetList(0)[i].GetString("LOSS_CATEGORY") == "B1" &&
                        out_node.GetList(0)[i].GetString("LOCATION_ID").Equals("") &&
                        out_node.GetList(0)[i].GetString("LOSS_CODE") == "0"
                        )
                    {
                        continue;
                    }
                    if (out_node.GetList(0)[i].GetString("LOSS_CATEGORY") == "B1" &&
                        out_node.GetList(0)[i].GetString("LOCATION_ID").Equals("A") ||
                        out_node.GetList(0)[i].GetString("LOCATION_ID").Equals("B") ||
                        out_node.GetList(0)[i].GetString("LOCATION_ID").Equals("C")
                        )
                    {
                        //if (out_node.GetList(0)[i].GetString("LOCATION_ID").Equals("A"))
                        //{
                        //    //soiTextBoxA.Focused  = false;
                        //    soiTextBoxA.BackColor = Color.Red;
                        //    soiTextBoxA.ForeColor = Color.Red;
                        //    soiTextBoxA.Text = " ";
                        //    //soiTextBoxA.ReadOnly = true;
                        //    //soiTextBoxB.BackColor = Color.FromKnownColor(KnownColor.Control);
                        //    //soiTextBoxC.BackColor = Color.FromKnownColor(KnownColor.Control);
                        //}
                        //else if (out_node.GetList(0)[i].GetString("LOCATION_ID").Equals("B"))
                        //{
                        //    //soiTextBoxB.Text = "B";
                        //    soiTextBoxB.BackColor = Color.Red;
                        //    soiTextBoxB.ForeColor = Color.Red;
                        //    soiTextBoxB.Text = " ";
                        //    //soiTextBoxB.ReadOnly = true;
                        //    //soiTextBoxA.BackColor = Color.FromKnownColor(KnownColor.Control);
                        //    //soiTextBoxC.BackColor = Color.FromKnownColor(KnownColor.Control);
                        //}else if (out_node.GetList(0)[i].GetString("LOCATION_ID").Equals("C"))
                        //{
                        //    //soiTextBoxC.Text = "C";
                        //    soiTextBoxC.BackColor = Color.Red;
                        //    soiTextBoxC.ForeColor = Color.Red;
                        //    soiTextBoxC.Text = " ";
                        //    //soiTextBoxC.ReadOnly = true;
                        //    //soiTextBoxA.BackColor = Color.FromKnownColor(KnownColor.Control);
                        //    //soiTextBoxB.BackColor = Color.FromKnownColor(KnownColor.Control);
                        //}
                        //soiTextBoxA.Text = out_node.GetList(0)[i].GetString("LOCATION_ID");
                        //soiTextBoxB.Text = out_node.GetList(0)[i].GetString("LOCATION_ID");
                        //soiTextBoxC.Text = out_node.GetList(0)[i].GetString("LOCATION_ID");

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
                        spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.BACK_COLOR].Value = out_node.GetList(0)[i].GetString("BACK_COLOR");
                        spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.DATA_TYPE].Value = out_node.GetList(0)[i].GetString("SAVE_TYPE");
                        spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.CHANGE_QTY].Value = out_node.GetList(0)[i].GetString("CHANGE_QTY"); //CHANGED CELL QTY
                        spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.LOCATION_ID].Value = out_node.GetList(0)[i].GetString("LOCATION_ID");

                        //GetPositionValue(out_node.GetList(0)[i].GetString("LOC_X"), out_node.GetList(0)[i].GetString("LOC_Y"), ref x, ref y);
                        strLossCode = out_node.GetList(0)[i].GetString("LOSS_CODE");
                        //strDisplayText = strLossCode + " \r\n " + out_node.GetList(0)[i].GetString("LOSS_DESC");
                        //SetInquryCellMap(x, y, strLossCode);
                        /*
                        y = Convert.ToInt16(out_node.GetList(0)[i].GetString("LOC_Y"));

                        y = y - 1;

                        if (y < 0)
                            y = 0;
                       

                        if (out_node.GetList(0)[i].GetString("SAVE_TYPE") == "LOSS")
                            SetInquryCellMap(x, y, strDisplayText, Color.Red);
                        else
                        {
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("CHANGE_QTY")) != "")
                            {
                                //CHANGE QTY 가 있는경우
                                strDisplayText = strDisplayText + " \r\n " + "(" + out_node.GetList(0)[i].GetString("CHANGE_QTY") + ")";
                            }
                            if (string.IsNullOrEmpty(out_node.GetList(0)[i].GetString("BACK_COLOR")) == false)
                            {
                                i_rgbColor = Convert.ToInt32(out_node.GetList(0)[i].GetString("BACK_COLOR"));
                                SetInquryCellMap(x, y, strDisplayText, Color.FromArgb(i_rgbColor));
                            }
                            else
                            {
                                SetInquryCellMap(x, y, strDisplayText, Color.White);
                            }
                        }
                        */
                    }
                    else
                    {
                        //soiTextBoxA.BackColor = Color.FromKnownColor(KnownColor.Control);
                        //soiTextBoxB.BackColor = Color.FromKnownColor(KnownColor.Control);
                        //soiTextBoxC.BackColor = Color.FromKnownColor(KnownColor.Control);
                        //soiTextBoxA.BackColor = Color.FromKnownColor(KnownColor.GrayText);
                        //soiTextBoxB.BackColor = Color.FromKnownColor(KnownColor.GrayText);
                        //soiTextBoxC.BackColor = Color.FromKnownColor(KnownColor.GrayText);
                        soiTextBoxA.Text = "";
                        soiTextBoxB.Text = "";
                        soiTextBoxC.Text = "";
                        soiTextBoxA.ReadOnly = true;
                        soiTextBoxB.ReadOnly = true;
                        soiTextBoxC.ReadOnly = true;
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
                        spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.BACK_COLOR].Value = out_node.GetList(0)[i].GetString("BACK_COLOR");
                        spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.DATA_TYPE].Value = out_node.GetList(0)[i].GetString("SAVE_TYPE");
                        spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.CHANGE_QTY].Value = out_node.GetList(0)[i].GetString("CHANGE_QTY"); //CHANGED CELL QTY
                        spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.LOCATION_ID].Value = out_node.GetList(0)[i].GetString("LOCATION_ID");

                        GetPositionValue(out_node.GetList(0)[i].GetString("LOC_X"), out_node.GetList(0)[i].GetString("LOC_Y"), ref x, ref y);
                        strLossCode = out_node.GetList(0)[i].GetString("LOSS_CODE");
                        strDisplayText = strLossCode + " \r\n " + out_node.GetList(0)[i].GetString("LOSS_DESC").Replace(" ", " \r\n ");
                        //SetInquryCellMap(x, y, strLossCode);

                        y = Convert.ToInt16(out_node.GetList(0)[i].GetString("LOC_Y"));

                        y = y - 1;

                        if (y < 0)
                            y = 0;

                        if (out_node.GetList(0)[i].GetString("SAVE_TYPE") == "LOSS")
                            SetInquryCellMap(x, y, strDisplayText, Color.Red);
                        else
                        {
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("CHANGE_QTY")) != "")
                            {
                                //CHANGE QTY 가 있는경우
                                strDisplayText = strDisplayText + " \r\n " + "(" + out_node.GetList(0)[i].GetString("CHANGE_QTY") + ")";
                            }
                            if (string.IsNullOrEmpty(out_node.GetList(0)[i].GetString("BACK_COLOR")) == false)
                            {
                                i_rgbColor = Convert.ToInt32(out_node.GetList(0)[i].GetString("BACK_COLOR"));
                                SetInquryCellMap(x, y, strDisplayText, Color.FromArgb(i_rgbColor));
                            }
                            else
                            {
                                SetInquryCellMap(x, y, strDisplayText, Color.White);
                            }
                        }
                    }

                }
                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (out_node.GetList(0)[i].GetString("LOSS_CATEGORY") == "B1")
                    {
                        if (out_node.GetList(0)[i].GetString("LOCATION_ID").Equals("A"))
                        {
                            //soiTextBoxA.Focused  = false;
                            soiTextBoxA.BackColor = Color.Red;
                            soiTextBoxA.ForeColor = Color.Red;
                            soiTextBoxA.Text = " ";
                            //soiTextBoxB.Text = "";
                            //soiTextBoxC.Text = "";
                            //soiTextBoxA.ReadOnly = true;
                            //soiTextBoxB.BackColor = Color.FromKnownColor(KnownColor.Control);
                            //soiTextBoxC.BackColor = Color.FromKnownColor(KnownColor.Control);
                        }
                        else if (out_node.GetList(0)[i].GetString("LOCATION_ID").Equals("B"))
                        {
                            //soiTextBoxB.Text = "B";
                            soiTextBoxB.BackColor = Color.Red;
                            soiTextBoxB.ForeColor = Color.Red;
                            soiTextBoxB.Text = " ";
                            //soiTextBoxA.Text = "";
                            //soiTextBoxC.Text = "";
                            //soiTextBoxB.ReadOnly = true;
                            //soiTextBoxA.BackColor = Color.FromKnownColor(KnownColor.Control);
                            //soiTextBoxC.BackColor = Color.FromKnownColor(KnownColor.Control);
                        }
                        else if (out_node.GetList(0)[i].GetString("LOCATION_ID").Equals("C"))
                        {
                            //soiTextBoxC.Text = "C";
                            soiTextBoxC.BackColor = Color.Red;
                            soiTextBoxC.ForeColor = Color.Red;
                            soiTextBoxC.Text = " ";
                            //soiTextBoxA.Text = "";
                            //soiTextBoxB.Text = "";
                            //soiTextBoxC.ReadOnly = true;
                            //soiTextBoxA.BackColor = Color.FromKnownColor(KnownColor.Control);
                            //soiTextBoxB.BackColor = Color.FromKnownColor(KnownColor.Control);
                        }
                    }
                }
                //MPCF.FitColumnHeader(spdLoss);
                MPCF.SetFocusAndSelectAll(txtLotID);

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
                        if (spdRepairCode.ActiveSheet.Cells[spdRepairCode.ActiveSheet.RowCount - 1, 1].Value == null)
                            spdRepairCode.ActiveSheet.Cells[spdRepairCode.ActiveSheet.RowCount - 1, 1].Value = "0";

                        if ((spdRepairCode.ActiveSheet.Cells[spdRepairCode.ActiveSheet.RowCount - 1, 1].Value.ToString() == "0") ||
                            Convert.ToBoolean(spdRepairCode.ActiveSheet.Cells[spdRepairCode.ActiveSheet.RowCount - 1,0].Value) == false)
                        {
                            spdCellMap.ActiveSheet.Cells[k, j].BackColor = cdvLossCode.BackColor;
                            spdCellMap.ActiveSheet.Cells[k, j].Text = cdvLossCode.Text + " \r\n " + cdvLossCode.Description.Replace(" "," \r\n " ) +" \r\n ";
                            //List<string> lossCategories = getLossCategoriesByLocation(k, j);
                            //foreach (string strLossCategory in lossCategories)
                            //{
                                AddLossCode(k, j);
                            //    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.LOSS_CATEGORY].Value = strLossCategory;
                            //}
                            
                        }
                        else
                        {
                            spdCellMap.ActiveSheet.Cells[k, j].BackColor = cdvLossCode.BackColor;
                            spdCellMap.ActiveSheet.Cells[k, j].Text = cdvLossCode.Text + " \r\n " + cdvLossCode.Description.Replace(" ", " \r\n ") + " \r\n " + "(" +
                                                                spdRepairCode.ActiveSheet.Cells[spdRepairCode.ActiveSheet.RowCount - 1, 1].Value.ToString() + ")";
                            //List<string> lossCategories = getLossCategoriesByLocation(k, j);
                            //foreach (string strLossCategory in lossCategories)
                            //{
                                AddLossCode(k, j);
                            //    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.LOSS_CATEGORY].Value = strLossCategory;
                            //}
                        }
                       
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

        private bool SetInquryCellMap(int x, int y, string sDisplayText, Color bColor)
        {
            try
            {
                //spdCellMap.ActiveSheet.Cells[x, y].BackColor = System.Drawing.Color.Red;
                //spdCellMap.ActiveSheet.Cells[x, y].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFF0000");
                spdCellMap.ActiveSheet.Cells[x, y].BackColor = bColor;

                spdCellMap.ActiveSheet.Cells[x, y].Text = sDisplayText;

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
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[MODULE ID]"));
                            MPCF.SetFocus(txtLotID);
                            return false;
                        }

                        if (string.IsNullOrEmpty(cdvLossCode.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[REPAIR CODE]"));
                            MPCF.SetFocus(cdvLossCode);
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
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[MODULE ID]"));
                            MPCF.SetFocus(txtLotID);
                            return false;
                        }

                        if (string.IsNullOrEmpty(cdvRepairTable.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[REPAIR TABLE]"));
                            MPCF.SetFocus(cdvRepairTable);
                            return false;
                        }

                        if ((string.IsNullOrEmpty(cdvWorker1.Text) == true) && (string.IsNullOrEmpty(cdvWorker2.Text) == true))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[WORKER]"));
                            MPCF.SetFocus(cdvWorker1);
                            return false;
                        }

                        if (string.IsNullOrEmpty(cdvSoldering.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Soldering Iron]"));
                            MPCF.SetFocus(cdvSoldering);
                            return false;
                        }

                        if (string.IsNullOrEmpty(cdvShift.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Shift]"));
                            MPCF.SetFocus(cdvSoldering);
                            return false;
                        }

                        if (string.IsNullOrEmpty(cdvWorker1.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Worker1]"));
                            MPCF.SetFocus(cdvWorker1);
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
                //string strLossCategory = "";
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
                //strLossCategory = getLossCategoryByLocation(strx, stry);
                spdRepairInfo.ActiveSheet.AddRows(0, 1);
                spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.NO].Value = spdRepairInfo.ActiveSheet.RowCount.ToString();
                spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.LOSS_TYPE].Value = "C";
                spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.LOSS_CODE].Value = cdvLossCode.Code;
                spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.LOSS_DESC].Value = cdvLossCode.Description;
                spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.X].Value = strx;
                spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.Y].Value = stry;
                spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.FLAG].Value = "I";
                spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.BACK_COLOR].Value = cdvLossCode.BackColor.ToArgb().ToString();
                spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.DATA_TYPE].Value = "REPAIR";

                //20190920 전단 버스바
                if(cdvLossCode.Text.ToString().ToString().StartsWith("R"))
                {
                    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.LOSS_CATEGORY].Value = "E1";
                }else
                {
                    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.LOSS_CATEGORY].Value = "B1";
                }
                

 

                if ((Convert.ToBoolean(spdRepairCode.ActiveSheet.Cells[spdRepairCode.ActiveSheet.RowCount - 1, 0].Value) == true) &&
                        MPCF.Trim(spdRepairCode.ActiveSheet.Cells[spdRepairCode.ActiveSheet.RowCount - 1, 1].Value) != "")
                {
                    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.CHANGE_QTY].Value = spdRepairCode.ActiveSheet.Cells[spdRepairCode.ActiveSheet.RowCount - 1, 1].Value; //CHANGED CELL QTY
                }
                
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
                    SetRepairCodeMaster();
                    strImagePath = "";
                    //strRedId = "";
                    //strLineId = "";
                    //strModeCode = "";
                    //strLotId = "";
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
                //change qty 사용안함
                //CHANGE CELL QTY COLUMN 다시추가
                //FarPoint.Win.Spread.CellType.CheckBoxCellType chk = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                //spdRepairCode.ActiveSheet.Cells[spdRepairCode.ActiveSheet.RowCount-1, 0].CellType = chk;
                //spdRepairCode.ActiveSheet.Cells[spdRepairCode.ActiveSheet.RowCount-1, 0].ColumnSpan = 2;

                //((FarPoint.Win.Spread.CellType.CheckBoxCellType)(spdRepairCode.ActiveSheet.GetCellType(spdRepairCode.ActiveSheet.RowCount-1, 0))).Caption =
                //                "True";

            }

            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void getSystemSettings()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@SYSTEM_SETTINGS"));

                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                {
                    return;
                }
                for (int inx = 0; inx < out_node.GetList(0).Count; inx++)
                {
                    m_settings.Add(out_node.GetList(0)[inx].GetString("KEY_1"),
                        out_node.GetList(0)[inx].GetString("DATA_2"));
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
        #endregion

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER && MPCF.Trim(txtLotID.Text) != "")
            {
                txtLotID.Text = MPCF.ToUpper(txtLotID.Text); // 일괄 대문자

                ClearData("1");

                if (!CheckCondition("VIEW"))
                {
                    MPCF.SetFocusAndSelectAll(txtLotID);
                    return;
                }

                if (!ViewLoss(txtLotID.Text)) { 
                MPCF.SetFocusAndSelectAll(txtLotID);
                return;
                }

                if (string.IsNullOrEmpty(txtLotID.Text) == true)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[MODULE ID]"));
                    MPCF.SetFocusAndSelectAll(txtLotID);
                    return;
                }

                if (strImagePath.Equals("") || strImagePath.Equals(" "))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(551) + Environment.NewLine + MPCF.FindLanguage("[MODULE ID]"));
                    MPCF.SetFocusAndSelectAll(txtLotID);
                    return;
                }
                else// if(strImagePath != "")
                {
                    frmCWIPFullCellImageMultiDpPopup pop;
                    pop = (frmCWIPFullCellImageMultiDpPopup)GetForm("frmCWIPFullCellImageMultiDpPopup");

                    if (pop == null)
                    {
                        pop = new frmCWIPFullCellImageMultiDpPopup(strImagePath);
                    }
                    else
                    {
                        pop.setPic(strImagePath);
                        MPCF.SetFocusAndSelectAll(txtLotID);

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

                MPCF.SetFocusAndSelectAll(txtLotID);
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
                in_node.AddString("TABLE_NAME", MPCF.Trim("@REPAIR"));

                // CodeView Column Header Setup
                string[] header = new string[] { "Repair Code", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1","DATA_2", };

                // Show
                cdvLossCode.Code = cdvLossCode.Show(cdvLossCode, "Repair Code", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");


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

                cr = spdCellMap.ActiveSheet.GetSelection(0);

                if (cr == null)
                    return;

                if ((cr.RowCount) > 1 || (cr.ColumnCount > 1))
                {
                    MessageBox.Show("You can not delete for multiple recird.! please Select options for multiple selection and one cell select ");
                    return;
                }

                x_position = MPCF.Trim(spdRepairInfo.ActiveSheet.Cells[spdRepairInfo.ActiveSheet.ActiveRowIndex, (int)LOT_LIST.X].Value);
                y_position = MPCF.Trim(spdRepairInfo.ActiveSheet.Cells[spdRepairInfo.ActiveSheet.ActiveRowIndex, (int)LOT_LIST.Y].Value);

                x_position = lblRow.Tag.ToString();
                y_position = lblCol.Text;
                GetPositionValue(x_position, y_position, ref x, ref y);

                spdCellMap.ActiveSheet.Cells[x, y - 1].BackColor = System.Drawing.Color.Transparent;
                spdCellMap.ActiveSheet.Cells[x, y - 1].Text = "";
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

       

        private void soiSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (spdRepairCode.ActiveSheet.Cells[e.Row, e.Column].Tag == null)
                    return;
                //20190920 전단버스바 Repair Code 추가시 더비 버튼 추가.
                if (spdRepairCode.ActiveSheet.Cells[e.Row, e.Column].Tag.ToString().Equals("-"))
                    return;

                if (spdRepairCode.ActiveSheet.Cells[e.Row, e.Column].Tag.ToString() == "ChangeCell")
                {
                    //change qty 사용안함
                    //if (spdRepairCode.ActiveSheet.Cells[e.Row, e.Column].Text == "True")
                    //{
                    //    spdRepairCode.ActiveSheet.Cells[e.Row, e.Column].Text = "False";
                    //    spdRepairCode.ActiveSheet.Cells[e.Row, e.Column].ColumnSpan = 2;
                    //}
                    //else
                    //{
                    //    spdRepairCode.ActiveSheet.Cells[e.Row, e.Column].Text = "True";
                    //    spdRepairCode.ActiveSheet.Cells[e.Row, e.Column].ColumnSpan = 1;
                    //}
                    //spdRepairCode.ActiveSheet.Cells[e.Row, e.Column].ColumnSpan = 1;
                }
                else
                {
                    cdvLossCode.Text = spdRepairCode.ActiveSheet.Cells[e.Row, e.Column].Tag.ToString(); //Repair Code
                    cdvLossCode.Description = spdRepairCode.ActiveSheet.Cells[e.Row, e.Column].Note; // Repair 설명
                    cdvLossCode.BackColor = spdRepairCode.ActiveSheet.Cells[e.Row, e.Column].NoteIndicatorColor;
                    //spdRepairCode.ActiveSheet.Cells[spdRepairCode.ActiveSheet.RowCount-1, 0].Text = "False";
                    //spdRepairCode.ActiveSheet.Cells[spdRepairCode.ActiveSheet.RowCount - 1, 0].ColumnSpan = 2;
                }
            }
            catch (Exception)
            {
                throw;
            }

            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                txtLotID.Text = MPCF.ToUpper(txtLotID.Text); // 일괄 대문자

                ClearData("1");

                if (!CheckCondition("VIEW"))
                    return;

                if (!ViewLoss(txtLotID.Text))
                    return;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void lblPosition_Click(object sender, EventArgs e)
        {

        }

        private void spdCellMap_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
               
            }
            catch (Exception)
            {
                throw;
            }
            
            
        }

        private void soiTableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void spdRepairCode_EditModeOn(object sender, EventArgs e)
        {
            FarPoint.Win.FpCheckBox checkbox = spdRepairCode.EditingControl as FarPoint.Win.FpCheckBox;
            if (checkbox != null)
            {
                checkbox.CheckChanged -= new EventHandler(checkbox_CheckChanged);
                checkbox.CheckChanged += new EventHandler(checkbox_CheckChanged);
            }
        }
        void checkbox_CheckChanged(object sender, EventArgs e)
        {
            //현재 사용중인 셀이 1,1일떄 이벤트 발생 
            try
            {
                int irow = 0;
                int icol = 0;

                irow = spdRepairCode.Sheets[0].ActiveColumnIndex;
                icol = spdRepairCode.Sheets[0].ActiveRowIndex;
                if (Convert.ToBoolean(spdRepairCode.ActiveSheet.Cells[icol, 0].Value) == false)
                {
                   // spdRepairCode.ActiveSheet.Cells[icol, 0].Value = true;
                    spdRepairCode.ActiveSheet.Cells[icol, 0].ColumnSpan = 2;
                }
                else
                {
                  //  spdRepairCode.ActiveSheet.Cells[icol, 0].Value = false;
                    spdRepairCode.ActiveSheet.Cells[icol, 0].ColumnSpan = 1;
                    //spdRepairCode.ActiveSheet.Cells[icol, 1].te = Color.Black;
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            
        }

        private void cdvWorker1_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Required Value
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(cdvShift, false) == false)
                {
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_WORKER_IN");
                TRSNode out_node = new TRSNode("VIEW_WORKER_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("WORKER", MPCF.Trim(cdvWorker2.Text));
                in_node.AddString("SHIFT", MPCF.Trim(cdvShift.Text));

                // CodeView Column Header Setup
                string[] header = new string[] { "Worker", "Name" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_2", "DATA_1" };

                // Show
                cdvWorker1.Text = cdvWorker1.Show(cdvWorker1, "WORKER", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_2");


                // Validation
                if (string.IsNullOrEmpty(cdvWorker1.Text) == true)
                {
                    MPCF.SetFocus(cdvWorker1);
                    return;
                }

                // Focus
                MPCF.SetFocus(cdvWorker2);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private void cdvWorker2_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Required Value
                if (MPCF.CheckValue(txtLotID, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(cdvShift, false) == false)
                {
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_WORKER_IN");
                TRSNode out_node = new TRSNode("VIEW_WORKER_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("WORKER", MPCF.Trim(cdvWorker1.Text));
                in_node.AddString("SHIFT", MPCF.Trim(cdvShift.Text));

                // CodeView Column Header Setup
                string[] header = new string[] { "Worker", "Name" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_2", "DATA_1" };

                // Show
                cdvWorker2.Text = cdvWorker2.Show(cdvWorker2, "WORKER", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_2");


                // Validation
                if (string.IsNullOrEmpty(cdvWorker2.Text) == true)
                {
                    MPCF.SetFocus(cdvWorker2);
                    return;
                }

                // Focus
                MPCF.SetFocus(cdvWorker2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cdvWorker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpWorkTime_AfterCloseUp(object sender, EventArgs e)
        {
            MPCF.FieldClear(cdvShift);
        }

        private void soiTableLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void soiTextBoxA_MouseMove(object sender, MouseEventArgs e)
        {
            if(soiTextBoxA.Text.Equals(" "))
            {
                soiTextBoxA.BackColor = Color.Red;
                soiTextBoxA.ForeColor = Color.Red;
            }
            //soiTextBoxA.BackColor = Color.FromKnownColor(KnownColor.Control);
            //soiTextBoxA.Enabled = false;
            //soiTextBoxA.Enabled = true;
        }

        private void soiTextBoxA_MouseLeave(object sender, EventArgs e)
        {
            if (soiTextBoxA.Text.Equals(" "))
            {
                soiTextBoxA.BackColor = Color.Red;
                soiTextBoxA.ForeColor = Color.Red;
            }
            //soiTextBoxA.Enabled = false;
            //soiTextBoxA.Enabled = true;
        }

        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            ((TextBox)sender).Parent.Focus();
        }

        private List<string> getLossCategoriesByLocation(int x, int y)
        {
            List<string> list = new List<string>();


            string strx = "A";
            string stry = "00";
            //string strLossCategory = "";
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


            for (int k = spdRepairInfo.ActiveSheet.RowCount - 1; k > -1; k--)
            {

                if (spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.X].Value.ToString().Equals(strx) == true &&
                Int32.Parse(spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.Y].Value.ToString()) == Int32.Parse(stry) &&
                spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.DATA_TYPE].Value.ToString().Equals("LOSS") == true)
                {
                    list.Add(spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.LOSS_CATEGORY].Value.ToString());
                }
            }
            return list;
        }

        private object GetForm(string formName) 
        {
            foreach (Form frm in Application.OpenForms)
                if (frm.Name == formName)
                    return frm;

            return null;
        }


        private string getLossCategoryByLocation(int x, int y)
        {
            string retVal = "";

            string strx = "A";
            string stry = "00";
            //string strLossCategory = "";
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

            for (int k = spdRepairInfo.ActiveSheet.RowCount - 1; k > -1; k--)
            {
                if (spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.X].Value.ToString().Equals(strx) == true &&
                Int32.Parse(spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.Y].Value.ToString()) == Int32.Parse(stry) && 
                spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.DATA_TYPE].Value.ToString().Equals("LOSS") == true)
                {
                    retVal = spdRepairInfo.ActiveSheet.Cells[k, (int)LOT_LIST.LOSS_CATEGORY].Value.ToString();
                    break;
                }
            }
            return retVal;
        }

        private void soiTextBoxB_MouseEnter(object sender, EventArgs e)
        {

        }

        private void soiTextBoxB_MouseMove(object sender, MouseEventArgs e)
        {
            if (soiTextBoxB.Text.Equals(" "))
            {
                soiTextBoxB.BackColor = Color.Red;
                soiTextBoxB.ForeColor = Color.Red;
            }
        }

        private void soiTextBoxB_MouseLeave(object sender, EventArgs e)
        {
            if (soiTextBoxB.Text.Equals(" "))
            {
                soiTextBoxB.BackColor = Color.Red;
                soiTextBoxB.ForeColor = Color.Red;
            }
        }

        private void soiTextBoxC_ValueChanged(object sender, EventArgs e)
        {

        }

        private void soiTextBoxC_MouseMove(object sender, MouseEventArgs e)
        {
            if (soiTextBoxC.Text.Equals(" "))
            {
                soiTextBoxC.BackColor = Color.Red;
                soiTextBoxC.ForeColor = Color.Red;
            }
        }

        private void soiTextBoxC_MouseLeave(object sender, EventArgs e)
        {
            if (soiTextBoxC.Text.Equals(" "))
            {
                soiTextBoxC.BackColor = Color.Red;
                soiTextBoxC.ForeColor = Color.Red;
            }
        }

        private void soiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (strImagePath != "")
                {
                    Screen[] scr = Screen.AllScreens;

                    frmCWIPFullCellImagePopup pop = new frmCWIPFullCellImagePopup(strImagePath);

                    if (scr.Length > 1)
                    {
                        Screen screen = (scr[0].WorkingArea.Contains(this.Location)) ? scr[1] : scr[0]; // 현재모니터 찾기                        

                        pop.Location = screen.Bounds.Location; // 모니터위치 변경

                        pop.FormBorderStyle = FormBorderStyle.FixedDialog;
                        pop.WindowState = FormWindowState.Normal;
                    }
                    
                    pop.Owner = MPGV.gfrmMDI;
                    pop.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void soiButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLotID.Text) == true)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[MODULE ID]"));
                    MPCF.SetFocus(txtLotID);
                    return;
                }

                if (strImagePath.Equals("") || strImagePath.Equals(" "))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(551) + Environment.NewLine + MPCF.FindLanguage("[MODULE ID]"));
                    MPCF.SetFocus(txtLotID);
                    return;
                }else// if(strImagePath != "")
                {
                    frmCWIPFullCellImageMultiDpPopup pop;
                    pop = (frmCWIPFullCellImageMultiDpPopup)GetForm("frmCWIPFullCellImageMultiDpPopup");

                    if(pop == null)
                    {
                        pop = new frmCWIPFullCellImageMultiDpPopup(strImagePath);
                    }
                    else
                    {
                        pop.setPic(strImagePath);
                        MPCF.SetFocusAndSelectAll(txtLotID);
                        
                        return;
                    }


                    Screen[] scr = Screen.AllScreens;

                    if (scr.Length > 1)
                    {
                        Screen screen = (scr[0].WorkingArea.Contains(this.Location)) ? scr[1] : scr[0]; // 현재모니터 찾기                        
                        pop.Location = screen.Bounds.Location; // 모니터위치 변경
                        //pop.SetDesktopLocation(screen.Bounds.X, screen.Bounds.Y);
                        //pop.SetDesktopBounds(screen.Bounds.X, screen.Bounds.Y, screen.Bounds.Width, screen.Bounds.Height);
                        //pop.SetBounds(screen.Bounds.X, screen.Bounds.Y, screen.Bounds.Width, screen.Bounds.Height);
                    }

                    //pop.Owner = MPGV.gfrmMDI;
                    //pop.ShowDialog();
                    pop.WindowState = FormWindowState.Maximized;
                    pop.Show();
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void txtLotID_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmCWIPFullCellImageMultiDpPopup pop;
            pop = (frmCWIPFullCellImageMultiDpPopup)GetForm("frmCWIPFullCellImageMultiDpPopup");

            if (pop != null)
            {
                pop.Dispose();
            }
        }
    }
}
