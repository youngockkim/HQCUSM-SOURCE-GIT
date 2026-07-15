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
using FarPoint.Excel.EntityClassLibrary.SpreadsheetML;

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button


    public partial class frmCUSModuleRepairManagement_PreCheck : SOIBaseForm02
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

        public frmCUSModuleRepairManagement_PreCheck()
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
                    return;
                }
                icnt = out_node.GetList(0).Count;

                if (icnt % 2 == 0)
                    spdRepairCode.ActiveSheet.RowCount = icnt / 2;
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
                if (p_res_id.Substring(6, 1) == "M")
                {
                    strRejectImagePath = p_emiaddr + "/US-" + con_line + "-MEL-01/" + con_yyyy + "/" + con_mm + "/" + con_dd + "/Auto-Inspection/Reject/" + p_lot_id + "/" + p_lot_id + ".jpg";
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
                string strTabberNo = "";

                int x = 0;
                int y = 0;
                int i_rgbColor = 0;
                int tbCnt = 0;


                str_cell = "";
                string strEMIAddr = "";
                string strVirtualDir = "";

                string strline = "";


                txtTabber1.Text = "";
                txtTabber2.Text = "";

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("LOSS_CATEGORY", "AD");
                in_node.AddString("LOT_ID", MPCF.Trim(sLotId));

                if (MPCF.CallService("CWIP", "CWIP_View_Module_Repair_Precheck", in_node, ref out_node) == false)
                {
                    return false;
                }

                cdvLineID.Text = out_node.GetString("LINE_ID");

                //2024-11-30 Page Modification: Management Module Repair Precheck - START
                if (out_node.GetString("TABBER_ID").IndexOf("MLU-06") > 0)
                {
                    txtTabber1.Text = "MLU-06";
                }


                strImagePath = out_node.GetString("ME_IMAGE_PATH");
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
                    //strImagePath = strImagePath.Replace("\\\\" + nassrv2.First().Value, strEMIAddr).Replace("\\", "/");
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

                if (strRejectImagePath != "")
                {
                    strImagePath = strRejectImagePath;
                }

                str_cell = out_node.GetString("MAT_CMF_3");

                strline = out_node.GetString("LINE_ID");

                if (strline == "MDL05" || strline == "MDL07")
                {
                    this.spdCellMap_Sheet1.RowHeader.Cells.Get(0, 0).Value = "A";
                    this.spdCellMap_Sheet1.RowHeader.Cells.Get(1, 0).Value = "B";
                    this.spdCellMap_Sheet1.RowHeader.Cells.Get(2, 0).Value = "C";
                    this.spdCellMap_Sheet1.RowHeader.Cells.Get(3, 0).Value = "D";
                    this.spdCellMap_Sheet1.RowHeader.Cells.Get(4, 0).Value = "E";
                    this.spdCellMap_Sheet1.RowHeader.Cells.Get(5, 0).Value = "F";

                    if (str_cell != " ")
                    {
                        int Line = Convert.ToInt32(str_cell) / 6;
                        spdCellMap_Sheet1.ColumnCount = Line;

                        for (int l = 0; l < Line; l++)
                        {
                            this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, l).Value = l + 1;
                            this.spdCellMap_Sheet1.Columns.Get(l).Label = (l + 1).ToString();
                            this.spdCellMap_Sheet1.Columns.Get(l).Width = 50F;
                        }
                    }
                    else
                    {
                        for (int l = 0; l < 26; l++)
                        {
                            this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, l).Value = l + 1;
                            this.spdCellMap_Sheet1.Columns.Get(l).Label = (l + 1).ToString();
                            this.spdCellMap_Sheet1.Columns.Get(l).Width = 50F;
                        }
                    }

                    //GAP LESS에 따른 셀 수량 체크

                    soiTextBoxA.Text = "";
                    soiTextBoxB.Text = "";
                    soiTextBoxC.Text = "";

                    //횟수, 결과, 판정, OSC, ESC, EL, 비고, 설비, 생성일자
                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        //2024-11-30 Page Modification: Management Module Repair Precheck - START
                        if (out_node.GetList(0)[i].GetString("LOSS_CATEGORY") != null &&
                            out_node.GetList(0)[i].GetString("LOSS_CATEGORY").Length >= 2 &&
                            out_node.GetList(0)[i].GetString("LOSS_CATEGORY").Substring(0, 2) != "R-")
                        {
                            checkTabberCount(++tbCnt, out_node.GetList(0)[i].GetString("TAB_RES_ID"));
                        }
                        //2024-11-30 Page Modification: Management Module Repair Precheck - END

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

                        //GetPositionValue(out_node.GetList(0)[i].GetString("LOC_X"), out_node.GetList(0)[i].GetString("LOC_Y"), ref x, ref y);
                        GetPositionValue(out_node.GetList(0)[i].GetString("LOC_X"), out_node.GetList(0)[i].GetString("LOC_Y"), ref x, ref y);
                        strLossCode = out_node.GetList(0)[i].GetString("LOSS_CODE");
                        strTabberNo = out_node.GetList(0)[i].GetString("TAB_RES_ID");
                        if (strTabberNo.Length > 10)
                        {
                            strDisplayText = strLossCode + " \r\n " + out_node.GetList(0)[i].GetString("LOSS_DESC").Replace(" ", " \r\n ");// + "\r\n" + strTabberNo.Substring(strTabberNo.Length - 5, 5);
                        }
                        else
                        {
                            strDisplayText = strLossCode + " \r\n " + out_node.GetList(0)[i].GetString("LOSS_DESC").Replace(" ", " \r\n ");
                        }
                        //SetInquryCellMap(x, y, strLossCode);

                        y = Convert.ToInt16(out_node.GetList(0)[i].GetString("LOC_Y"));

                        y = y - 1;

                        if (y < 0)
                            y = 0;

                        if (out_node.GetList(0)[i].GetString("SAVE_TYPE") == "GAP")
                        {
                            if (spdCellMap.ActiveSheet.Cells[x, y].BackColor == Color.SkyBlue)
                            {
                                SetInquryCellMap(x, y, strDisplayText, Color.SkyBlue);
                            }
                            else if (spdCellMap.ActiveSheet.Cells[x, y].BackColor == Color.Orange)
                            {
                                SetInquryCellMap(x, y, strDisplayText, Color.SkyBlue);
                            }
                            else
                            {
                                SetInquryCellMap(x, y, strDisplayText, Color.Red);
                            }
                        }
                        else if (out_node.GetList(0)[i].GetString("SAVE_TYPE") == "MEL")
                            SetInquryCellMap(x, y, strDisplayText, Color.Orange);
                        else if (out_node.GetList(0)[i].GetString("SAVE_TYPE") == "REPAIR")
                        {
                            if (spdCellMap.ActiveSheet.Cells[x, y].BackColor == Color.SkyBlue)
                            {
                                SetInquryCellMap(x, y, strDisplayText, Color.SkyBlue);
                            }
                            else if (spdCellMap.ActiveSheet.Cells[x, y].BackColor == Color.Orange)
                            {
                                SetInquryCellMap(x, y, strDisplayText, Color.SkyBlue);
                            }
                            else
                            {
                                SetInquryCellMap(x, y, strDisplayText, Color.Green); // 수리정보
                            }
                        }
                        else if (out_node.GetList(0)[i].GetString("SAVE_TYPE") == "DUST")
                        {
                            if (spdCellMap.ActiveSheet.Cells[x, y].BackColor == Color.SkyBlue)
                            {
                                SetInquryCellMap(x, y, strDisplayText, Color.SkyBlue);
                            }
                            else if (spdCellMap.ActiveSheet.Cells[x, y].BackColor == Color.Orange)
                            {
                                SetInquryCellMap(x, y, strDisplayText, Color.SkyBlue);
                            }
                            else
                            {
                                SetInquryCellMap(x, y, strDisplayText, Color.Red); // DUST 정보
                            }
                        }
                        else
                        {
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("CHANGE_QTY")) != "")
                            {
                                if (strTabberNo.Length > 10)
                                {
                                    //CHANGE QTY 가 있는경우
                                    strDisplayText = strDisplayText + " \r\n " + "(" + out_node.GetList(0)[i].GetString("CHANGE_QTY") + ")";// + "\r\n" + strTabberNo.Substring(strTabberNo.Length - 5, 5); ;
                                }
                                else
                                {
                                    //CHANGE QTY 가 있는경우
                                    strDisplayText = strDisplayText + " \r\n " + "(" + out_node.GetList(0)[i].GetString("CHANGE_QTY") + ")";
                                }
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

                    if (tbCnt > 0 && txtTabber1.Text == "")
                    {
                        txtTabber1.Text = "MISSING";
                    }
                }
                else
                {
                    this.spdCellMap_Sheet1.RowHeader.Cells.Get(0, 0).Value = "F";
                    this.spdCellMap_Sheet1.RowHeader.Cells.Get(1, 0).Value = "E";
                    this.spdCellMap_Sheet1.RowHeader.Cells.Get(2, 0).Value = "D";
                    this.spdCellMap_Sheet1.RowHeader.Cells.Get(3, 0).Value = "C";
                    this.spdCellMap_Sheet1.RowHeader.Cells.Get(4, 0).Value = "B";
                    this.spdCellMap_Sheet1.RowHeader.Cells.Get(5, 0).Value = "A";

                    if (str_cell != " ")
                    {
                        int Line = Convert.ToInt32(str_cell) / 6;
                        spdCellMap_Sheet1.ColumnCount = Line;

                        for (int l = 0; l < Line; l++)
                        {
                            this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, l).Value = Line - l;
                            this.spdCellMap_Sheet1.Columns.Get(l).Label = (Line - l).ToString();
                            this.spdCellMap_Sheet1.Columns.Get(l).Width = 50F;
                        }
                    }
                    else
                    {
                        for (int l = 0; l < 26; l++)
                        {
                            this.spdCellMap_Sheet1.ColumnHeader.Cells.Get(0, l).Value = 26 - l;
                            this.spdCellMap_Sheet1.Columns.Get(l).Label = (26 - l).ToString();
                            this.spdCellMap_Sheet1.Columns.Get(l).Width = 50F;
                        }
                    }


                    //GAP LESS에 따른 셀 수량 체크

                    soiTextBoxA.Text = "";
                    soiTextBoxB.Text = "";
                    soiTextBoxC.Text = "";

                    //횟수, 결과, 판정, OSC, ESC, EL, 비고, 설비, 생성일자
                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        //2024-11-30 Page Modification: Management Module Repair Precheck - START
                        if (out_node.GetList(0)[i].GetString("LOSS_CATEGORY") != null &&
                            out_node.GetList(0)[i].GetString("LOSS_CATEGORY").Length >= 2 &&
                            out_node.GetList(0)[i].GetString("LOSS_CATEGORY").Substring(0, 2) != "R-")
                        {
                            checkTabberCount(++tbCnt, out_node.GetList(0)[i].GetString("TAB_RES_ID"));
                        }
                        //2024-11-30 Page Modification: Management Module Repair Precheck - END

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

                        GetPositionValue2(out_node.GetList(0)[i].GetString("LOC_X"), out_node.GetList(0)[i].GetString("LOC_Y"), ref x, ref y);
                        strLossCode = out_node.GetList(0)[i].GetString("LOSS_CODE");
                        strTabberNo = out_node.GetList(0)[i].GetString("TAB_RES_ID");
                        if (strTabberNo.Length > 10)
                        {
                            strDisplayText = strLossCode + " \r\n " + out_node.GetList(0)[i].GetString("LOSS_DESC").Replace(" ", " \r\n ") + "\r\n";// + strTabberNo.Substring(strTabberNo.Length - 5, 5);
                        }
                        else
                        {
                            strDisplayText = strLossCode + " \r\n " + out_node.GetList(0)[i].GetString("LOSS_DESC").Replace(" ", " \r\n ");
                        }
                        //SetInquryCellMap(x, y, strLossCode);

                        //y = Convert.ToInt16(out_node.GetList(0)[i].GetString("LOC_Y"));
                        //y = (Convert.ToInt16(str_cell) / 6) - Convert.ToInt16(out_node.GetList(0)[i].GetString("LOC_Y"));

                        //y = y;

                        if (y < 0)
                            y = 0;

                        if (out_node.GetList(0)[i].GetString("SAVE_TYPE") == "GAP")
                        {
                            if (spdCellMap.ActiveSheet.Cells[x, y].BackColor == Color.SkyBlue)
                            {
                                SetInquryCellMap(x, y, strDisplayText, Color.SkyBlue);
                            }
                            else if (spdCellMap.ActiveSheet.Cells[x, y].BackColor == Color.Orange)
                            {
                                SetInquryCellMap(x, y, strDisplayText, Color.SkyBlue);
                            }
                            else
                            {
                                SetInquryCellMap(x, y, strDisplayText, Color.Red);
                            }
                        }
                        else if (out_node.GetList(0)[i].GetString("SAVE_TYPE") == "MEL")
                            SetInquryCellMap(x, y, strDisplayText, Color.Orange);
                        else if (out_node.GetList(0)[i].GetString("SAVE_TYPE") == "REPAIR")
                        {
                            if (spdCellMap.ActiveSheet.Cells[x, y].BackColor == Color.SkyBlue)
                            {
                                SetInquryCellMap(x, y, strDisplayText, Color.SkyBlue);
                            }
                            else if (spdCellMap.ActiveSheet.Cells[x, y].BackColor == Color.Orange)
                            {
                                SetInquryCellMap(x, y, strDisplayText, Color.SkyBlue);
                            }
                            else
                            {
                                SetInquryCellMap(x, y, strDisplayText, Color.Green); // 수리정보
                            }
                        }
                        else if (out_node.GetList(0)[i].GetString("SAVE_TYPE") == "DUST")
                        {
                            if (spdCellMap.ActiveSheet.Cells[x, y].BackColor == Color.SkyBlue)
                            {
                                SetInquryCellMap(x, y, strDisplayText, Color.SkyBlue);
                            }
                            else if (spdCellMap.ActiveSheet.Cells[x, y].BackColor == Color.Orange)
                            {
                                SetInquryCellMap(x, y, strDisplayText, Color.SkyBlue);
                            }
                            else
                            {
                                SetInquryCellMap(x, y, strDisplayText, Color.Red); // DUST 정보
                            }
                        }
                        else
                        {
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("CHANGE_QTY")) != "")
                            {
                                if (strTabberNo.Length > 10)
                                {
                                    //CHANGE QTY 가 있는경우
                                    strDisplayText = strDisplayText + " \r\n " + "(" + out_node.GetList(0)[i].GetString("CHANGE_QTY") + ")" + "\r\n";// + strTabberNo.Substring(strTabberNo.Length - 5, 5); ;
                                }
                                else
                                {
                                    //CHANGE QTY 가 있는경우
                                    strDisplayText = strDisplayText + " \r\n " + "(" + out_node.GetList(0)[i].GetString("CHANGE_QTY") + ")";
                                }
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

                    if (tbCnt > 0 && txtTabber1.Text == "")
                    {
                        txtTabber1.Text = "MISSING";
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

        private void checkTabberCount(int tbCnt, String resName)
        {
            //2024-11-30 Page Modification: Management Module Repair Precheck - START
            if (resName != null &&
                resName.Length > 9 &&
                resName.Substring(6, 2).Equals("TB"))
            {

                if (tbCnt == 1)
                {
                    txtTabber1.Text = resName;
                }
                else if (tbCnt == 2 && txtTabber1.Text != resName)
                {
                    txtTabber2.Text = resName;
                }
            }
            //2024-11-30 Page Modification: Management Module Repair Precheck - END
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

        private bool GetPositionValue2(string strx, string stry, ref int x, ref int y)
        {

            switch (strx)
            {
                case "F":
                    x = 0;
                    break;
                case "E":
                    x = 1;
                    break;
                case "D":
                    x = 2;
                    break;
                case "C":
                    x = 3;
                    break;
                case "B":
                    x = 4;
                    break;
                case "A":
                    x = 5;
                    break;

                default:
                    break;
            }

            //y = Convert.ToInt16(stry);
            y = (Convert.ToInt16(str_cell) / 6) - (Convert.ToInt16(stry));

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
                            Convert.ToBoolean(spdRepairCode.ActiveSheet.Cells[spdRepairCode.ActiveSheet.RowCount - 1, 0].Value) == false)
                        {
                            spdCellMap.ActiveSheet.Cells[k, j].BackColor = cdvLossCode.BackColor;
                            spdCellMap.ActiveSheet.Cells[k, j].Text = cdvLossCode.Text + " \r\n " + cdvLossCode.Description.Replace(" ", " \r\n ") + " \r\n ";
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
                if (cdvLossCode.Text.ToString().ToString().StartsWith("R"))
                {
                    spdRepairInfo.ActiveSheet.Cells[0, (int)LOT_LIST.LOSS_CATEGORY].Value = "E1";
                }
                else
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

                    txtTabber1.Text = "";
                    txtTabber1.Text = "";
                    txtSolder1.Text = "";

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

                if (!ViewLoss(txtLotID.Text))
                {
                    MPCF.SetFocusAndSelectAll(txtLotID);
                    return;
                }

                if (string.IsNullOrEmpty(txtLotID.Text) == true)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[MODULE ID]"));
                    MPCF.SetFocusAndSelectAll(txtLotID);
                    return;
                }

                /*
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
                        try
                        {
                            pop = new frmCWIPFullCellImageMultiDpPopup(strImagePath);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
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
                */

                MPCF.SetFocusAndSelectAll(txtLotID);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmCWIPFullCellImageMultiDpPopup pop;
            pop = (frmCWIPFullCellImageMultiDpPopup)GetForm("frmCWIPFullCellImageMultiDpPopup");

            if (pop != null)
            {
                pop.Dispose();
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '3';
            in_node.AddString("INS_TYPE", "NG");
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));

            if (MPCF.CallService("CWIP", "CWIP_View_Module_Repair_Precheck", in_node, ref out_node) == false)
            {
                //string strViewError;
                ////string strErrorMsg = "The LOT has already been recorded.";
                //strViewError =
                //               "LOT_ID = " + MPCF.Trim(txtLotID.Text) + "\r\n"
                //             + "----------------------------------\r\n"
                //             + strErrorMsg;

                //// 기본 dll ShowMessage
                //MPCF.ShowMessage(strViewError, MSG_LEVEL.ERROR, true);

                if (string.IsNullOrEmpty(out_node.GetString("MSG")) == false)
                {
                    MPCF.ShowMessage(out_node.GetString("MSG"), CliFrx.MSG_LEVEL.ERROR, false);
                }

                return;
            }


        }
    }
}
