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
using Infragistics.Win;

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button


    public partial class frmCUSModuleRepairManagement_NgTray : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private string s;
        private FarPoint.Win.Spread.Model.CellRange cr;
        private string strImagePath = "";
        private string strRejectImagePath = "";
        private string m_nas_conn_failed = "";
        private Dictionary<String, String> m_settings;
        #endregion

        #region Constructor
        public string str_cell;
        private string strELImagePath = "";
        private string strELImagePath1 = "";
        private string strELImagePath2 = "";
        private string strELImagePath3 = "";
        private string strELImagePath4 = "";

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

        private enum SPD_STRING_INSP_LIST
        {
            NO,
            INS_TYPE,
            LOT_ID,
            INS_TIME,
            IMG_PATH,
            IMG_PATH2,
            IMG_PATH3,
            IMG_PATH4
        }

        #endregion

        public frmCUSModuleRepairManagement_NgTray()
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
            //dtpWorkTime.Value = DateTime.Today;
            MPCF.SetFocus(txtTrayID1);

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

        private void cdvLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == ENTER && MPCF.Trim(txtTrayID1.Text) != "")
            //{
            //    txtTrayID1.Text = MPCF.ToUpper(txtTrayID1.Text); // 일괄 대문자

            //    ClearData("1");

            //    if (!CheckCondition("VIEW"))
            //        return;

            //    if (!ViewLoss(txtTrayID1.Text))
            //        return;

            //}
        }



        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (!CheckCondition("SAVE"))
                return;

            if (SearchRepairStringInfoByTrayId() == true)
            {
                if (SaveRepairStringInfoWithRepairman() == true)
                {
                    SearchRepairStringInfoByTrayId2();
                    spdNgStringList.Sheets[0].Rows.Clear();
                    ClearData("1");
                    txtTrayID1.Text = "";
                    MPCF.ShowMessage("Data was saved successfully.", MSG_LEVEL.INFO, false);
                }
            }

        }

        private bool SaveRepairStringInfoWithRepairman()
        {
            TRSNode in_node = new TRSNode("VIEW_TRAY_IN");
            TRSNode out_node = new TRSNode("VIEW_TRAY_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("FACTORY", "USGAM1");
            in_node.AddString("USER_ID", MPCF.Trim(cdvWorker1.Text));
            in_node.AddString("TRAY_ID", MPCF.Trim(txtTrayID1.Text));
            in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
            in_node.AddInt("REPAIR_QTY", MPCF.Trim(txtRepairQTY.Text));

            in_node.AddInt("LINE_ID", MPCF.Trim(cdvLineID.Text));

            if (MPCF.CallService("CWIP", "CWIP_Update_Tray", in_node, ref out_node) == false)
            {
                MPCF.ShowMessage(MPCF.GetMessage(154), MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        // Search
        private bool SearchRepairStringInfoByTrayId()
        {
            TRSNode in_node = new TRSNode("VIEW_TRAY_IN");
            TRSNode out_node = new TRSNode("VIEW_TRAY_OUT");
            //TRSNode out_list;

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("TRAY_ID", MPCF.Trim(txtTrayID1.Text));


            if (MPCF.CallService("CWIP", "CWIP_View_Tray", in_node, ref out_node) == false)
            {
                MPCF.ShowMessage(MPCF.GetMessage(154), MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        // Search
        private void SearchRepairStringInfoByTrayId2()
        {
            TRSNode in_node = new TRSNode("VIEW_TRAY_IN");
            TRSNode out_node = new TRSNode("VIEW_TRAY_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '2';

            in_node.AddString("TRAY_ID", MPCF.Trim(txtTrayID1.Text));

            if (MPCF.CallService("CWIP", "CWIP_View_Tray", in_node, ref out_node) == false)
            {
                MPCF.ShowMessage(MPCF.GetMessage(154), MSG_LEVEL.ERROR, false);
            }

            txtTrayID1.Text = out_node.GetString("TRAY_ID");

            txtRepairQTY.Text = MPCF.MakeNumberFormat(out_node.GetInt("REPAIR_QTY"));

            //if (String.IsNullOrWhiteSpace(MPCF.MakeDateFormat(out_node.GetString("ENT_TIME")).ToString()))
            //{
            //    btnProcess.Enabled = true;
            //}
            //else
            //{
            //    btnProcess.Enabled = false;
            //}

            MPCF.SetFocus(txtTrayID1);
            txtTrayID1.SelectAll();

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



                //strRejectImagePath = "http://10.60.110.42/el_img/US-E1-FEL-01/2021/05/17/Auto-Inspection/Reject/20131201541101385/20131201541101385.jpg";
                //strRejectImagePath = "http://10.60.110.42/el_img/US-E1-FEL-01/2021/05/17/Auto-Inspection/Reject/20131201541101385/20131201541101385.jpASDSDg";

                strRejectImagePath = "";
                //strRejectImagePath = "http://10.60.110.42/el_img/US-" + con_line + "-FEL-01/" + con_yyyy + "/" + con_mm + "/" + con_dd + "/Auto-Inspection/Reject/" + p_lot_id + "/" + p_lot_id + ".jpg";

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





        // PWJ START
        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "VIEW":

                        if (MPCF.CheckValue(txtTrayID1, false) == false)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(594), MSG_LEVEL.ERROR, false);
                            return false;
                        }
                        break;

                    case "SAVE":
                        if (string.IsNullOrEmpty(txtTrayID1.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Tray ID]"));
                            MPCF.SetFocus(txtTrayID1);
                            txtTrayID1.SelectAll();
                            return false;
                        }

                        if ((string.IsNullOrEmpty(cdvWorker1.Text) == true))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[WORKER]"));
                            MPCF.SetFocus(cdvWorker1);
                            return false;
                        }

                        if ((string.IsNullOrEmpty(cdvLineID.Text) == true))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[LINE ID]"));
                            MPCF.SetFocus(cdvLineID);
                            return false;
                        }

                        if (string.IsNullOrEmpty(txtRepairQTY.Text) == true || Int32.Parse(txtRepairQTY.Text) == 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Repair QTY]"));
                            MPCF.SetFocus(txtRepairQTY);
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

        private bool ViewStringInfoList()
        {
            try
            {
                var RES_ID = "";

                spdNgStringList.Sheets[0].Rows.Clear();

                // NG 트레이 정보를 조회한다 어디서 온 트레이인지 확인 후 리스트를 생성한다.
                TRSNode in_node2 = new TRSNode("VIEW_STRING_LIST_IN");
                TRSNode out_node2 = new TRSNode("VIEW_STRING_LIST_OUT");
                TRSNode out_list2;

                MPCF.SetInMsg(in_node2);
                in_node2.ProcStep = '2';
                in_node2.AddString("TRAY_ID", MPCF.Trim(txtTrayID1.Text));

                if (MPCF.CallService("CWIP", "CWIP_View_Tray_Ng_Management", in_node2, ref out_node2) == false)
                {
                    // Error Message
                    if (string.IsNullOrEmpty(out_node2.GetString("MSG")) == false)
                    {
                        MPCF.ShowMessage(out_node2.GetString("MSG"), CliFrx.MSG_LEVEL.ERROR, false);
                    }
                    return false;
                }

                //MPCF.ShowSuccessMessage(out_node, false);

                spdNgStringList.ActiveSheet.RowCount = 0;

                txtTraceEq.Text = out_node2.GetString("RES_ID2");

                for (int i = 0; i < out_node2.GetList(0).Count; i++)
                {
                    out_list2 = out_node2.GetList(0)[i];
                    //모듈에서 온 2(LAYUP) , A(EMPTY 자동채번), 5(MLU-6), 6(SR) 로 시작되는 스트링은 보이지 않도록 한다.
                    if (MPCF.ToUpper(out_list2.GetString("STRING_ID").Substring(0, 1)) != "7")
                    {
                        return false;
                    }
                    spdNgStringList.ActiveSheet.RowCount++;
                    spdNgStringList.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.NO].Value = out_node2.GetList(0).Count - i; // i + 1;
                    spdNgStringList.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.LOT_ID].Value = out_list2.GetString("STRING_ID");
                    //spdNgStringList.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.RES_ID].Value = out_list2.GetString("RES_ID");
                    //spdString1.ActiveSheet.Cells[i, 1].CellType = txt;
                    //spdString1.ActiveSheet.Cells[i, 1].BackColor = Color.White;
                    //spdString1.ActiveSheet.Cells[i, 1].ForeColor = Color.Black;
                }

                RES_ID = out_node2.GetString("RES_ID");

                // S_EQ 추후 사용. 현재는 R_EQ 만 사용 한다.
                //if (RES_ID.ToString() == "S_EQ")
                //{
                //    for (int i = 0; i < spdNgStringList.ActiveSheet.RowCount; i++)
                //    {
                //        TRSNode in_node = new TRSNode("VIEW_STRING_LIST_IN");
                //        TRSNode out_node = new TRSNode("VIEW_STRING_LIST_OUT");
                //        //TRSNode out_list;


                //        MPCF.SetInMsg(in_node);
                //        in_node.ProcStep = '4';
                //        in_node.AddString("TRAY_ID", MPCF.Trim(txtTrayID1.Text));
                //        //in_node.AddString("STRING_ID", MPCF.Trim(spdNgStringList.ActiveSheet.Cells[i, (int)SPD_TRAY_STRING_LIST.STRING_ID].Value.ToString()));
                //        if (MPCF.CallService("CWIP", "CWIP_View_Tray_Ng_Management", in_node, ref out_node) == false)
                //        {
                //            //return false;
                //        }

                //        MPCF.ShowSuccessMessage(out_node, false);

                //        int iRow = 0;

                //        for (int j = 0; j < out_node.GetList(0).Count; j++)
                //        {
                //            iRow = spdNgStringList.Sheets[0].Rows.Count;
                //            spdNgStringList.Sheets[0].RowCount++;

                //            spdNgStringList.Sheets[0].Cells[iRow, (int)SPD_STRING_INSP_LIST.NO].Value = MPCF.Trim(spdNgStringList.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.NO].Value.ToString());
                //            spdNgStringList.Sheets[0].Cells[iRow, (int)SPD_STRING_INSP_LIST.INS_TYPE].Value = out_node.GetList(0)[j].GetString("INS_TYPE");
                //            spdNgStringList.Sheets[0].Cells[iRow, (int)SPD_STRING_INSP_LIST.LOT_ID].Value = out_node.GetList(0)[j].GetString("LOT_ID");
                //            spdNgStringList.Sheets[0].Cells[iRow, (int)SPD_STRING_INSP_LIST.INS_TIME].Value = out_node.GetList(0)[j].GetString("INS_TIME");
                //            spdNgStringList.Sheets[0].Cells[iRow, (int)SPD_STRING_INSP_LIST.IMG_PATH].Value = out_node.GetList(0)[j].GetString("IMAGE_PATH");
                //        }

                //    }
                //}
                //else 
                if (RES_ID.ToString() == "R_EQ")
                {
                    for (int i = 0; i < spdNgStringList.ActiveSheet.RowCount; i++)
                    {
                        TRSNode in_node = new TRSNode("VIEW_STRING_LIST_IN");
                        TRSNode out_node = new TRSNode("VIEW_STRING_LIST_OUT");

                        MPCF.SetInMsg(in_node);
                        in_node.ProcStep = '3';
                        in_node.AddString("STRING_ID", MPCF.Trim(spdNgStringList.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.LOT_ID].Value.ToString()));
                        in_node.AddString("IMAGE_TYPE", "AMRR");
                        in_node.AddString("INS_TYPE", "AU");
                        //in_node.AddString("STRING_ID", MPCF.Trim(spdNgStringList.ActiveSheet.Cells[spdNgStringList.ActiveSheet.ActiveRowIndex, 0].Text)); // 선택하는것 사용시

                        if (MPCF.CallService("CWIP", "CWIP_View_Tray_Ng_Management", in_node, ref out_node) == false)
                        {
                            //return false;
                        }

                        MPCF.ShowSuccessMessage(out_node, false);

                        //spdNgStringList.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.LOT_ID].Value = out_node.GetString("LOT_ID");
                        spdNgStringList.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.IMG_PATH].Value = out_node.GetString("IMAGE_PATH");
                        //spdNgStringList.ActiveSheet.RowCount++;
                        //spdNgStringList.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.NO].Value = spdNgStringList.ActiveSheet.RowCount - i;//i + 1;
                        //spdNgStringList.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.INS_TYPE].Value = out_node.GetString("INS_TYPE");
                        //spdNgStringList.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.INS_TIME].Value = out_node.GetString("INS_TIME");

                    }
                    for (int i = 0; i < spdNgStringList.ActiveSheet.RowCount; i++)
                    {
                        TRSNode in_node = new TRSNode("VIEW_STRING_LIST_IN");
                        TRSNode out_node = new TRSNode("VIEW_STRING_LIST_OUT");

                        MPCF.SetInMsg(in_node);
                        in_node.ProcStep = '3';
                        in_node.AddString("STRING_ID", MPCF.Trim(spdNgStringList.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.LOT_ID].Value.ToString()));
                        in_node.AddString("IMAGE_TYPE", "AMRE");
                        in_node.AddString("INS_TYPE", "AB");

                        if (MPCF.CallService("CWIP", "CWIP_View_Tray_Ng_Management", in_node, ref out_node) == false)
                        {
                            //return false;
                        }

                        MPCF.ShowSuccessMessage(out_node, false);
                        if (out_node.GetString("INS_TYPE") != "")
                        {
                            spdNgStringList.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.IMG_PATH2].Value = out_node.GetString("IMAGE_PATH");
                            //spdNgStringList.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.NO].Value = spdNgStringList.ActiveSheet.RowCount - i;//i + 1;
                            //spdNgStringList.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.INS_TYPE].Value = out_node.GetString("INS_TYPE");
                            //spdNgStringList.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.LOT_ID].Value = out_node.GetString("LOT_ID");
                            //spdNgStringList.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.INS_TIME].Value = out_node.GetString("INS_TIME");
                        }
                    }
                }

                //txtStringID.Text = spdNgStringList.ActiveSheet.Cells[0, (int)SPD_STRING_INSP_LIST.LOT_ID].Value.ToString();
                //strELImagePath = spdNgStringList.ActiveSheet.Cells[0, (int)SPD_STRING_INSP_LIST.IMG_PATH].Value.ToString();
                //strELImagePath2 = spdNgStringList.ActiveSheet.Cells[0, (int)SPD_STRING_INSP_LIST.IMG_PATH2].Value.ToString();
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

                strELImagePath = spdNgStringList.ActiveSheet.Cells[0, (int)SPD_STRING_INSP_LIST.IMG_PATH].Value.ToString();

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
                        for (int i = 0; i < spdNgStringList.ActiveSheet.RowCount; i++)
                        {
                            pop = new frmCWIPStringCellImagePopup(strELImagePath, type, (spdNgStringList.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.NO].Value).ToString());

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
                                               "String Number ( " + (spdNgStringList.ActiveSheet.Cells[i, (int)SPD_STRING_INSP_LIST.NO].Value).ToString() + " )" + "\r\n"
                                             + "----------------------------------\r\n"
                                             + strErrorMsg;

                                // 기본 dll ShowMessage
                                MPCF.ShowMessage(strViewError, MSG_LEVEL.ERROR, true);
                            }

                            pop.ShowDialog();
                            type = pop._Type;

                            if (type == "1" && (i + 1) == spdNgStringList.ActiveSheet.RowCount)
                            {
                                return false;
                            }
                            else if (type == "1")
                            {
                                strELImagePath = spdNgStringList.ActiveSheet.Cells[i + 1, (int)SPD_STRING_INSP_LIST.IMG_PATH].Value.ToString();
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

                MPCF.SetFocusAndSelectAll(txtTrayID1);

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return false;
        }

        private object GetForm(string formName)
        {
            foreach (Form frm in Application.OpenForms)
                if (frm.Name == formName)
                    return frm;

            return null;
        }

        private bool ViewLoss(string sLotId)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LOT_IN");
                TRSNode out_node = new TRSNode("VIEW_LOT_OUT");
                string strLossCode = "";
                string strDisplayText = "";
                string strTabberNo = "";

                int x = 0;
                int y = 0;

                str_cell = "";


                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                //in_node.AddString("LOSS_CATEGORY", "AD");
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));

                if (MPCF.CallService("CWIP", "CWIP_View_Tray_Ng_Management", in_node, ref out_node) == false)
                {
                    return false;
                }

                ClearMap();

                str_cell = out_node.GetString("MAT_CMF_3");
                if (str_cell != " ")
                {
                    int Line = Convert.ToInt32(str_cell) / 12;
                    spdCellMap_Sheet1.ColumnCount = Line;

                    for (int l = 0; l < Line; l++)
                    {
                        this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, l).Value = l + 1;
                        this.spdCellMap_Sheet1.Columns.Get(l).Label = (l + 1).ToString();
                        this.spdCellMap_Sheet1.Columns.Get(l).Width = 75F;
                        //this.spdCellMap_Sheet1.Rows.Get(l).Height = 160F;
                        //this.spdCellMap_Sheet1.Rows.Default.Height = 160F;
                    }
                }
                else
                {
                    for (int l = 0; l < 26; l++)
                    {
                        this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, l).Value = l + 1;
                        this.spdCellMap_Sheet1.Columns.Get(l).Label = (l + 1).ToString();
                        this.spdCellMap_Sheet1.Columns.Get(l).Width = 75F;
                        //this.spdCellMap_Sheet1.Rows.Get(l).Height = 160F;
                    }
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
                    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.BACK_COLOR].Value = out_node.GetList(0)[i].GetString("BACK_COLOR");
                    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.DATA_TYPE].Value = out_node.GetList(0)[i].GetString("SAVE_TYPE");
                    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.CHANGE_QTY].Value = out_node.GetList(0)[i].GetString("CHANGE_QTY"); //CHANGED CELL QTY
                    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.LOCATION_ID].Value = out_node.GetList(0)[i].GetString("LOCATION_ID");

                    //GetPositionValue(out_node.GetList(0)[i].GetString("LOC_X"), out_node.GetList(0)[i].GetString("LOC_Y"), ref x, ref y);
                    strLossCode = out_node.GetList(0)[i].GetString("LOSS_CODE");
                    strTabberNo = out_node.GetList(0)[i].GetString("TAB_RES_ID");

                    y = Convert.ToInt16(out_node.GetList(0)[i].GetString("LOC_Y"));

                    y = y - 1;

                    if (y < 0)
                        y = 0;

                    if (spdCellMap.ActiveSheet.Cells[x, y].Text == "")
                    {
                        strDisplayText = strLossCode + " \r\n " + out_node.GetList(0)[i].GetString("LOSS_DESC").Replace(" ", " \r\n ");
                    }
                    else
                    {
                        strDisplayText = strDisplayText + " \r\n " + strLossCode + " \r\n " + out_node.GetList(0)[i].GetString("LOSS_DESC").Replace(" ", " \r\n ");
                    }



                    y = Convert.ToInt16(out_node.GetList(0)[i].GetString("LOC_Y"));

                    y = y - 1;

                    if (y < 0)
                        y = 0;

                    if (out_node.GetList(0)[i].GetString("SAVE_TYPE") == "MRP")
                    {
                        if (spdCellMap.ActiveSheet.Cells[x, y].BackColor == Color.Red)
                        {
                            SetInquryCellMap(x, y, strDisplayText, Color.Red);
                        }
                        else
                            SetInquryCellMap(x, y, strDisplayText, Color.Red);
                    }


                    //else if (out_node.GetList(0)[i].GetString("SAVE_TYPE") == "MEL")
                    //    SetInquryCellMap(x, y, strDisplayText, Color.Orange);
                    //else
                    //{
                    //    if (MPCF.Trim(out_node.GetList(0)[i].GetString("CHANGE_QTY")) != "")
                    //    {
                    //        strDisplayText = strDisplayText + " \r\n " + "(" + out_node.GetList(0)[i].GetString("CHANGE_QTY") + ")";
                    //    }
                    //    if (string.IsNullOrEmpty(out_node.GetList(0)[i].GetString("BACK_COLOR")) == false)
                    //    {
                    //        i_rgbColor = Convert.ToInt32(out_node.GetList(0)[i].GetString("BACK_COLOR"));
                    //        SetInquryCellMap(x, y, strDisplayText, Color.FromArgb(i_rgbColor));
                    //    }
                    //    else
                    //    {
                    //        SetInquryCellMap(x, y, strDisplayText, Color.White);
                    //    }
                    //}
                }


                MPCF.SetFocusAndSelectAll(txtTrayID1);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }


        private bool SetInquryCellMap(int x, int y, string sDisplayText, Color bColor)
        {
            try
            {
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

        private void ClearData(string ProcStep)
        {
            try
            {
                if (ProcStep == "1")
                {
                    ClearMap();
                    MPCF.ClearList(spdRepairInfo);
                    strImagePath = "";
                    m_nas_conn_failed = "";
                    txtTraceEq.Text = "";
                    txtStringID.Text = "";
                    //txtTrayID1.Text = "";
                    //cdvLineID.Text = "";
                    //cdvWorker1.Text = "";
                    //strRedId = "";
                    //strLineId = "";
                    //strModeCode = "";
                    //strLotId = "";

                    // IS-21-11-013 [신규]모듈 리페어 과검 프로세스 도입
                    //chkOverKill.Visible = false;
                    //chkOverKill.Checked = false;
                }
            }

            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }





        private void spdNgStringList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                //이미지 추후 정리
                txtStringID.Text = MPCF.Trim(spdNgStringList.ActiveSheet.Cells[e.Row, (int)SPD_STRING_INSP_LIST.LOT_ID].Text).ToString();
                strELImagePath1 = MPCF.Trim(spdNgStringList.ActiveSheet.Cells[e.Row, (int)SPD_STRING_INSP_LIST.IMG_PATH].Value).ToString();
                strELImagePath2 = MPCF.Trim(spdNgStringList.ActiveSheet.Cells[e.Row, (int)SPD_STRING_INSP_LIST.IMG_PATH2].Value).ToString();
                strELImagePath3 = MPCF.Trim(spdNgStringList.ActiveSheet.Cells[e.Row, (int)SPD_STRING_INSP_LIST.IMG_PATH3].Value).ToString();
                strELImagePath4 = MPCF.Trim(spdNgStringList.ActiveSheet.Cells[e.Row, (int)SPD_STRING_INSP_LIST.IMG_PATH4].Value).ToString();

                if (!ViewLoss(MPCF.Trim(spdNgStringList.ActiveSheet.Cells[e.Row, (int)SPD_STRING_INSP_LIST.LOT_ID].Text).ToString()))
                    return;

                if (spdNgStringList.ActiveSheet.Cells[e.Row, (int)SPD_STRING_INSP_LIST.NO].BackColor == Color.DeepPink)
                {
                    spdNgStringList.ActiveSheet.Cells[e.Row, (int)SPD_STRING_INSP_LIST.NO].BackColor = Color.Empty;
                }
                else
                {
                    spdNgStringList.ActiveSheet.Cells[e.Row, (int)SPD_STRING_INSP_LIST.NO].BackColor = Color.DeepPink;
                }

            }
            catch (Exception)
            {
                throw;
            }


        }

        // PWJ END





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
                if (cdvLossCode.Text.ToString().ToString().StartsWith("R"))
                {
                    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.LOSS_CATEGORY].Value = "E1";
                }
                else
                {
                    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.LOSS_CATEGORY].Value = "B1";
                }




                //if ((Convert.ToBoolean(spdRepairCode.ActiveSheet.Cells[spdRepairCode.ActiveSheet.RowCount - 1, 0].Value) == true) &&
                //        MPCF.Trim(spdRepairCode.ActiveSheet.Cells[spdRepairCode.ActiveSheet.RowCount - 1, 1].Value) != "")
                //{
                //    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.CHANGE_QTY].Value = spdRepairCode.ActiveSheet.Cells[spdRepairCode.ActiveSheet.RowCount - 1, 1].Value; //CHANGED CELL QTY
                //}

                return true;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
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
            if (e.KeyChar == ENTER && MPCF.Trim(txtTrayID1.Text) != "")
            {
                txtTrayID1.Text = MPCF.ToUpper(txtTrayID1.Text); // 일괄 대문자

                ClearData("1");

                if (!CheckCondition("VIEW"))
                    return;

                if (!ViewStringInfoList())
                {
                    MPCF.SetFocusAndSelectAll(txtTrayID1);
                    return;
                }

                txtRepairQTY.Text = "24";
                txtStringID.Text = "";

                //MPCF.SetFocus(spdNgStringList);

                //if (!PopupView())
                //{
                //    MPCF.SetFocusAndSelectAll(txtTrayID1);
                //    return;
                //}

                MPCF.SetFocusAndSelectAll(txtTrayID1);
            }
        }

        private void cdvLossCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Required Value
                if (MPCF.CheckValue(txtTrayID1, false) == false)
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
                string[] display = new string[] { "KEY_1", "DATA_2", };

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



        private void soiSpread1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //try
            //{
            //    if (spdRepairCode.ActiveSheet.Cells[e.Row, e.Column].Tag == null)
            //        return;
            //    //20190920 전단버스바 Repair Code 추가시 더비 버튼 추가.
            //    if (spdRepairCode.ActiveSheet.Cells[e.Row, e.Column].Tag.ToString().Equals("-"))
            //        return;

            //    if (spdRepairCode.ActiveSheet.Cells[e.Row, e.Column].Tag.ToString() == "ChangeCell")
            //    {

            //    }
            //    else
            //    {
            //        cdvLossCode.Text = spdRepairCode.ActiveSheet.Cells[e.Row, e.Column].Tag.ToString(); //Repair Code
            //        cdvLossCode.Description = spdRepairCode.ActiveSheet.Cells[e.Row, e.Column].Note; // Repair 설명
            //        cdvLossCode.BackColor = spdRepairCode.ActiveSheet.Cells[e.Row, e.Column].NoteIndicatorColor;
            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}


        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                txtTrayID1.Text = MPCF.ToUpper(txtTrayID1.Text); // 일괄 대문자

                ClearData("1");

                if (!CheckCondition("VIEW"))
                    return;

                //if (!ViewLoss(txtTrayID1.Text))
                //    return;
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


        void checkbox_CheckChanged(object sender, EventArgs e)
        {
            //현재 사용중인 셀이 1,1일떄 이벤트 발생 
            try
            {
                int irow = 0;
                int icol = 0;

                //irow = spdRepairCode.Sheets[0].ActiveColumnIndex;
                //icol = spdRepairCode.Sheets[0].ActiveRowIndex;
                //if (Convert.ToBoolean(spdRepairCode.ActiveSheet.Cells[icol, 0].Value) == false)
                //{
                //   // spdRepairCode.ActiveSheet.Cells[icol, 0].Value = true;
                //    spdRepairCode.ActiveSheet.Cells[icol, 0].ColumnSpan = 2;
                //}
                //else
                //{
                //  //  spdRepairCode.ActiveSheet.Cells[icol, 0].Value = false;
                //    spdRepairCode.ActiveSheet.Cells[icol, 0].ColumnSpan = 1;
                //    //spdRepairCode.ActiveSheet.Cells[icol, 1].te = Color.Black;
                //}
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
                TRSNode in_node = new TRSNode("VIEW_WORKER_IN");
                TRSNode out_node = new TRSNode("VIEW_WORKER_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("FACTORY", "USGAM1");
                in_node.AddString("TABLE_NAME", "@WORKER_MASTER");

                // CodeView Column Header Setup
                string[] header = new string[] { "Name", "ID" };

                // CodeView Display Column Setup
                string[] display = new string[] { "DATA_1", "KEY_1" };

                // Show
                //cdvWorker1.Text = cdvWorker1.Show(cdvWorker1, "WORKER", "CBAS", "CBAS_View_Large_Data_List", in_node, "DATA_LIST", display, header, "DATA_3");
                cdvWorker1.Text = cdvWorker1.Show(cdvWorker1, "WORKER", "CBAS", "CBAS_View_Large_Data_List", in_node, "DATA_LIST", display, header, "DATA_1");


                // Validation
                if (string.IsNullOrEmpty(cdvWorker1.Text) == true)
                {
                    MPCF.SetFocus(cdvWorker1);
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }




        private void soiTextBoxA_MouseMove(object sender, MouseEventArgs e)
        {
            if (soiTextBoxA.Text.Equals(" "))
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
                if (strELImagePath1 != "")
                {
                    if (m_nas_conn_failed.Trim().Equals("1"))
                    {
                        MPCF.ShowMessage("EL image cannot be displayed due to connection issues. The rest module repair steps on this page can still be proceeded.", MSG_LEVEL.ERROR, false);
                    }
                    else
                    {
                        frmCWIPFullCellImageMultiDpPopup pop = new frmCWIPFullCellImageMultiDpPopup(strELImagePath1);

                        pop.WindowState = FormWindowState.Maximized;
                        pop.Show();
                        //pop.Owner = MPGV.gfrmMDI;
                        //pop.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void soiButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (strELImagePath2 != "")
                {
                    if (m_nas_conn_failed.Trim().Equals("1"))
                    {
                        MPCF.ShowMessage("Vision image cannot be displayed due to connection issues. The rest module repair steps on this page can still be proceeded.", MSG_LEVEL.ERROR, false);
                    }
                    else
                    {
                        frmCWIPFullCellImageMultiDpPopup pop = new frmCWIPFullCellImageMultiDpPopup(strELImagePath2);
                        pop.WindowState = FormWindowState.Maximized;
                        pop.Show();
                        //pop.Owner = MPGV.gfrmMDI;
                        //pop.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void txtRepairQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            //Repair 수량을 수정하여 24가 아닌 경우 enter키를 누르면 저장되도록 함
            //2023년1월26일 손혜윤엔지니어요청사항
            //위험해서 일단 뻄 = 20250502
            //if (txtRepairQTY.Value != null && txtRepairQTY.Value.Equals("24") == false && e.KeyChar == (char)13)
            //{
            //    if (!CheckCondition("SAVE"))
            //        return;


            //    if (SaveRepairStringInfoWithRepairman() == true)
            //    {
            //        SearchRepairStringInfoByTrayId2();
            //        MPCF.ShowMessage("Data was saved successfully.", MSG_LEVEL.INFO, false);
            //    }
            //}
        }
    }
}
