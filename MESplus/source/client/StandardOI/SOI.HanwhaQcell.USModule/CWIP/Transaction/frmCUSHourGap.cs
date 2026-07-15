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

namespace SOI.HanwhaQcell.USModule
{
    public partial class frmCUSHourGap : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCUSHourGap()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]
        public string chk_type;
        public string chk_auto_validation;
        public string chk_common_line;
        public string chk_auto;
        public enum HOUR_LIST
        {
            WORK_SHIFT,
            WORK_TIME,
            HIST_SEQ,
            TARGET_QTY,
            FEL_QTY,
            DIFF_QTY,   
            TIME_LOSS,
            TYPE_4M,
            TYPE_4M_DESC,
            PROCESS_TYPE,
            EQ,
            DOWN_TIME,
            EFF_TIME,
            //HOUR_DESC,
            HOUR_DESC,
            CMF_2, //Root Cause
            CMF_3, //Action Plan
            EQ_MAX,
            CMF_4, //Humidity
            CMF_1
            //WORK_DATE,
            //LINE_ID,
            //HOUR_TYPE,

        }

        #endregion

        #region [Variable Definition]
        private int FEBE_HUMIDITY_MAX = 3;
        private int FQC_HUMIDITY_MAX = 2;
        #endregion

        #region Event Handler

        private void frmCUSHourGap_Load(object sender, EventArgs e)
        {
            // Init
            //dtpDate.Value = DateTime.Now.AddDays(-1) ;
            dtpDate.Value = DateTime.Now;
            chk_auto_validation = "";
            chk_auto = "";
            chk_common_line = "";

            set_view();
           
            MPCF.ConvertCaption(this);

            getLineLocationList();  

        }

        private void frmCUSHourGap_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                MPCF.SetFocus(dtpDate);

                bIsShown = true;
            }
        }

        private void cdvLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LINE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));
                in_node.AddString("LINE_LOCATION", cboLineLocation.Value);

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvLineID.Text = cdvLineID.Show(cdvLineID, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvType_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@HOUR_GAP_TYPE"));

                string[] header = new string[] { "Shift", "Description" };
                string[] display = new string[] { "DATA_1", "DATA_2" };

                cdvType.Text = cdvType.Show(cdvType, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "DATA_1");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvShift_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_SHIFT));

                string[] header = new string[] { "Shift", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                //cdvShift.Text = cdvShift.Show(cdvShift, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }
        
     

        private void btnToExcelModules_Click(object sender, EventArgs e)
        {
            try
            {
                //SaveFileDialog pop = new SaveFileDialog();
                //pop.InitialDirectory = "C:\\";

                //pop.FileName = MPCF.Trim(lblFormTitle.Text) + "_" + MPCF.Trim(grpScrapList.Text) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                //pop.Filter = "Excel Files(*.xls)|*.xls|All files(*.*)|*.*";
                //pop.FilterIndex = 1;

                //if (pop.ShowDialog() == DialogResult.OK)
                //{
                //    spdHour.Sheets[0].Protect = false;
                //    spdHour.SaveExcel(pop.FileName, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders);
                //    spdHour.Sheets[0].Protect = true;
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
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

        private void set_view()
        {
            txt_clear();
            btnProcess.Enabled = false;
            btnADD.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            cdv4M.Enabled = false;
            cdvPro.Enabled = false;
            cdvEQ.Enabled = false;
            txtdown.Enabled = false;
            txtEfftime.Enabled = false;
            txtdesc.Enabled = false;
            cdvTIME.Enabled = false;
            txtSEQ.Enabled = false;




        }

        private void set_update()
        {
            txt_clear();
            btnProcess.Enabled = false;
            btnADD.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            cdv4M.Enabled = true;
            cdvPro.Enabled = true;
            cdvEQ.Enabled = true;
            txtdown.Enabled = true;
            txtEfftime.Enabled = false;
            txtdesc.Enabled = true;
            cdvTIME.Enabled = true;
            txtSEQ.Enabled = true;

        }

        private void set_create()
        {
            txt_clear();
            btnProcess.Enabled = true;
            btnUpdate.Enabled = true;
            btnADD.Enabled = false;
            btnDelete.Enabled = false;
            cdv4M.Enabled = false;
            cdvPro.Enabled = false;
            cdvEQ.Enabled = false;
            txtdown.Enabled = false;
            txtEfftime.Enabled = false;
            txtdesc.Enabled = false;
            cdvTIME.Enabled = false;
            txtSEQ.Enabled = false;

        }


        private void txt_clear()
        {
            cdv4M.Text = "";
            cdvPro.Text = "";
            cdvEQ.Text = "";
            txtdown.Text = "";
            txtdesc.Text = "";
            cdvTIME.Text = "";
            txtSEQ.Text = "";
            cdv4M.Description = "";
            cdvPro.Description = "";
            cdvEQ.Description = "";
            cdvTIME.Description = "";
            txtRootCause.Text = "";
            txtActionPlan.Text = "";
            txtHumidity.Text = "";
        }

        
        private void btnClear_Click(object sender, EventArgs e)
        {
            txt_clear();
    
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("VIEW") == false)
                {
                    set_view();
                    return;
                }

                if (ViewHourList() == false)
                {
                    set_view();
                    setHumidityColumn();
                    return;
                }
                setHumidityColumn();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("CREATE") == false)
                {
                    return;
                }

                if (UpdateHourRpt(MPGC.MP_STEP_CREATE) == false)
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (chk_type == "C")
                {
                    if (CheckCondition("CREATE") == false)
                    {
                        return;
                    }

                    if (UpdateHourRpt(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }
                }
                else
                {
                    if (CheckCondition("UPDATE") == false)
                    {
                        return;
                    }

                    if (UpdateHourRpt(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }
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
                if (CheckCondition("DELETE") == false)
                {
                    return;
                }

                if (UpdateHourRpt(MPGC.MP_STEP_DELETE) == false)
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

        private void spdHour_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {

                txt_clear();
                cdv4M.Text = spdHour.Sheets[0].Cells[e.Row, (int)HOUR_LIST.TYPE_4M].Text;
                cdv4M.Description = spdHour.Sheets[0].Cells[e.Row, (int)HOUR_LIST.TYPE_4M_DESC].Text;
                cdvPro.Text = spdHour.Sheets[0].Cells[e.Row, (int)HOUR_LIST.PROCESS_TYPE].Text;
                cdvEQ.Text = spdHour.Sheets[0].Cells[e.Row, (int)HOUR_LIST.EQ].Text;
                cdvEQ.Description = spdHour.Sheets[0].Cells[e.Row, (int)HOUR_LIST.EQ_MAX].Text;
                txtdown.Value = spdHour.Sheets[0].Cells[e.Row, (int)HOUR_LIST.DOWN_TIME].Text;
                txtdesc.Text = spdHour.Sheets[0].Cells[e.Row, (int)HOUR_LIST.HOUR_DESC].Text;
                cdvTIME.Description = spdHour.Sheets[0].Cells[e.Row, (int)HOUR_LIST.WORK_TIME].Text;
                cdvTIME.Text = spdHour.Sheets[0].Cells[e.Row, (int)HOUR_LIST.WORK_TIME].Text;
                txtSEQ.Text = spdHour.Sheets[0].Cells[e.Row, (int)HOUR_LIST.HIST_SEQ].Text;

                if (spdHour.Sheets[0].Cells[e.Row, (int)HOUR_LIST.CMF_1].Text == "Scheduled") 
                {
                    soiRadioButton1.Value = "1";
                }
                else if (spdHour.Sheets[0].Cells[e.Row, (int)HOUR_LIST.CMF_1].Text == "Non-Scheduled")
                {
                    soiRadioButton1.Value = "2";
                }
                else
                {
                    soiRadioButton1.Value = "2";
                }
                txtRootCause.Text = spdHour.Sheets[0].Cells[e.Row, (int)HOUR_LIST.CMF_2].Text;
                txtActionPlan.Text = spdHour.Sheets[0].Cells[e.Row, (int)HOUR_LIST.CMF_3].Text;
                txtHumidity.Text = spdHour.Sheets[0].Cells[e.Row, (int)HOUR_LIST.CMF_4].Text.Replace("%", "");


            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        #endregion
        
        #region Function

        private bool CheckCondition(string FuncName)
        {
            int maxHumidity = this.FEBE_HUMIDITY_MAX;
            if (cdvType.Code != "FE" &&
                 cdvType.Code != "BE")
            {
                maxHumidity = FQC_HUMIDITY_MAX;
            }

            try
            {
                switch (FuncName)
                {
   
                    case "CREATE":

                       if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cboShift, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvType, false) == false)
                        {
                            return false;
                        }


                        break;

                    case "VIEW":
                        if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cboShift, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvType, false) == false)
                        {
                            return false;
                        }

                        break;

                    case "UPDATE":

                        if (spdHour.Sheets[0].SelectionCount < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(568));
                            return false;
                        }

                        if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cboShift, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvType, false) == false)
                        {
                            return false;
                        }

                        if (cdv4M.Text == "")
                        {
                            cdv4M.Focus();
                            MPCF.ShowMsgBox("Please Selected 4M");
                            return false;
                        }
                        if (cdvPro.Text == "")
                        {
                            cdvPro.Focus();
                            MPCF.ShowMsgBox("Please Selected Process");
                            return false;
                        }

                        if (cdvEQ.Text == "")
                        {
                            cdvEQ.Focus();
                            MPCF.ShowMsgBox("Please Selected EQ");
                            return false;
                        }

                        if (cdvEQ.Description == "")
                        {
                            cdvEQ.Focus();
                            MPCF.ShowMsgBox("Please Check  EQ Max Value");
                            return false;
                        }

                        if (cdvTIME.Description == "")
                        {
                            cdvTIME.Focus();
                            MPCF.ShowMsgBox("Please Selected Time");
                            return false;
                        }

                        if (txtSEQ.Text == "")
                        {
                            txtSEQ.Focus();
                            MPCF.ShowMsgBox("Please Selected Item");
                            return false;
                        }

                        if (Convert.ToInt32(txtdown.Value) == 0)
                        {
                            MPCF.ShowMsgBox("Please Enter Down Time");
                            txtdown.Focus();
                            return false;
                        }

                        if (Convert.ToInt32(txtdown.Value) > 60)
                        {
                            MPCF.ShowMsgBox("Downtime must be less than 60.");
                            txtdown.Focus();
                            return false;
                        }

                        if (txtHumidity.Text != "")
                        {
                            if (txtHumidity.Text.IndexOf('.') != -1)
                            {
                                MPCF.ShowMsgBox("You can only enter up to 3 digits numerical value in the H-Racks Count (FE) / A-Frame Count (BE) field.");

                                txtHumidity.Focus();
                                return false;
                            }
                            else
                            {

                                if (txtHumidity.Text.Length > maxHumidity)
                                {
                                    MPCF.ShowMsgBox("You can only enter up to 3 digits numerical value in the H-Racks Count (FE) / A-Frame Count (BE) field.");

                                    txtHumidity.Focus();
                                    return false;
                                }
                            }
                        }
           
                       
                        break;
                    case "APPEND":

                        if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cboShift, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvType, false) == false)
                        {
                            return false;
                        }

                        if (cdv4M.Text == "")
                        {
                            cdv4M.Focus();
                            MPCF.ShowMsgBox("Please Selected 4M");
                            return false;
                        }
                        if (cdvPro.Text == "")
                        {
                            cdvPro.Focus();
                            MPCF.ShowMsgBox("Please Selected Process");
                            return false;
                        }

                        if (cdvEQ.Text == "")
                        {
                            cdvEQ.Focus();
                            MPCF.ShowMsgBox("Please Selected EQ");
                            return false;
                        }

                        if (cdvEQ.Description == "")
                        {
                            cdvEQ.Focus();
                            MPCF.ShowMsgBox("Please Check  EQ Max Value");
                            return false;
                        }


                        if (cdvTIME.Description == "")
                        {
                            cdvTIME.Focus();
                            MPCF.ShowMsgBox("Please Selected Time");
                            return false;
                        }


                        if (Convert.ToInt32(txtdown.Value) == 0)
                        {
                            MPCF.ShowMsgBox("Please Enter Down Time");
                            txtdown.Focus();
                            return false;
                        }

                        if (Convert.ToInt32(txtdown.Value) > 60)
                        {
                            MPCF.ShowMsgBox("Downtime must be less than 60.");
                            txtdown.Focus();
                            return false;
                        }

                        if (txtHumidity.Text != "")
                        {
                            if (txtHumidity.Text.IndexOf('.') != -1)
                            {
                                MPCF.ShowMsgBox("You can only enter up to 3 digits numerical value in the H-Racks Count (FE) / A-Frame Count (BE) field.");

                                txtHumidity.Focus();
                                return false;
                            }
                            else
                            {

                                if (txtHumidity.Text.Length > maxHumidity)
                                {
                                    MPCF.ShowMsgBox("You can only enter up to 3 digits numerical value in the H-Racks Count (FE) / A-Frame Count (BE) field.");

                                    txtHumidity.Focus();
                                    return false;
                                }
                            }
                        }

                        break;

                    case "DELETE":

                        if (spdHour.Sheets[0].SelectionCount < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(568));
                            return false;
                        }

                        if (txtSEQ.Text == "")
                        {
                            txtSEQ.Focus();
                            MPCF.ShowMsgBox("Please Selected Item");
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

        private bool ViewHourList()
        {
            try
            {
                int i;
            

                chk_type = "";

                DateTime dtpFromDateTimeOut = new DateTime();
              
                MPCF.ClearList(spdHour);

                TRSNode in_node = new TRSNode("VIEW_HOUR_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_HOUR_LIST_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (dtpDate.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpDate.Value.ToString(), out dtpFromDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpFromDateTimeOut.ToString("yyyyMMdd"));
                    }
                }
             
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
                in_node.AddString("WORK_SHIFT", MPCF.Trim(cboShift.Text));
                in_node.AddString("HOUR_TYPE", MPCF.Trim(cdvType.Text));

                if (MPCF.CallService("CRAS", "CRAS_View_Hour_Gap_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                spdHour.ActiveSheet.RowCount = 0;
           
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];
                    spdHour.ActiveSheet.RowCount++;

                    spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.WORK_SHIFT].Value = out_list.GetString("WORK_SHIFT");
                    spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.WORK_TIME].Value = out_list.GetString("WORK_TIME");
                    spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.HIST_SEQ].Value = out_list.GetInt("HIST_SEQ");
                    if (out_list.GetInt("HIST_SEQ") == 0)
                    {
                        chk_type = "C";
                    }
                    
                    else
                    {
                        chk_type = "U";
                    }

                    spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.TARGET_QTY].Value = MPCF.MakeNumberFormat(out_list.GetInt("TARGET_QTY"), 0);
                    spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.FEL_QTY].Value = MPCF.MakeNumberFormat(out_list.GetInt("FEL_QTY"), 0);
                    spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.DIFF_QTY].Value = MPCF.MakeNumberFormat(out_list.GetInt("DIFF_QTY"), 0);
                    spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.TIME_LOSS].Value = MPCF.MakeNumberFormat(out_list.GetInt("TIME_LOSS"), 0);

                    spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.TYPE_4M].Value = out_list.GetString("TYPE_4M");
                    spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.TYPE_4M_DESC].Value = out_list.GetString("TYPE_4M_DESC");
                    spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.PROCESS_TYPE].Value = out_list.GetString("PROCESS_TYPE");
                    spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.EQ].Value = out_list.GetString("EQ");
                    spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.DOWN_TIME].Value = MPCF.MakeNumberFormat(out_list.GetInt("DOWN_TIME"), 0);
                    spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.EFF_TIME].Value = MPCF.MakeNumberFormat(out_list.GetInt("EFF_TIME"), 0);

                    if (out_list.GetString("CMF_1") == "1")
                    {
                        spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.CMF_1].Value = "Scheduled";
                    }
                    else if (out_list.GetString("CMF_1") == "2")
                    {
                        spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.CMF_1].Value = "Non-Scheduled";
                    }

                    //spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.CMF_1].Value = out_list.GetString("CMF_1");

                    spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.HOUR_DESC].Value = out_list.GetString("HOUR_DESC");
                    spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.CMF_2].Value = out_list.GetString("CMF_2");
                    spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.CMF_3].Value = out_list.GetString("CMF_3");
                   

                    spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.EQ_MAX].Value = MPCF.MakeNumberFormat(out_list.GetInt("EQ_MAX"), 0);
                    spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.CMF_4].Value = out_list.GetString("CMF_4").Replace("%", "");

                        
                }

                MPCF.FitColumnHeader(spdHour);
                

                if(chk_type == "C")
                {
                    set_create(); 
                }
                else if(chk_type == "U")
                {
                    set_update();
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }
        
        private bool UpdateHourRpt(char ProcStep)
        {
            try
            {
                int i;
    
                TRSNode work_list = null;
                String strValue;
                DateTime dtpScrapDateTimeOut = new DateTime();

                TRSNode in_node = new TRSNode("UPDATE_HOUR_LIST_IN");
                TRSNode out_node = new TRSNode("UPDATE_HOUR_LIST_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("FACTORY", MPGV.gsFactory);

                // Scrap Date
                if (dtpDate.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpDate.Value.ToString(), out dtpScrapDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpScrapDateTimeOut.ToString("yyyyMMdd"));
                    }
                }
                //header
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
                in_node.AddString("HOUR_TYPE", MPCF.Trim(cdvType.Text));
                in_node.AddString("WORK_SHIFT", MPCF.Trim(cboShift.Text));
                //detail
                if (ProcStep == 'I')        //create
                {

                    for (i = 0; i < spdHour.Sheets[0].Rows.Count; i++)
                    {
                        work_list = in_node.AddNode("TRAN_LIST");
                        work_list.AddString("WORK_TIME", spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.WORK_TIME].Value);
                        work_list.AddInt("TARGET_QTY", Convert.ToInt32(spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.TARGET_QTY].Text.Replace(",", "")));
                        work_list.AddInt("FEL_QTY", Convert.ToInt32(spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.FEL_QTY].Text.Replace(",", "")));
                        work_list.AddInt("DIFF_QTY", Convert.ToInt32(spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.DIFF_QTY].Text.Replace(",", "")));
                        work_list.AddInt("TIME_LOSS", Convert.ToInt32(spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.TIME_LOSS].Text.Replace(",", "")));
                        work_list.AddString("TYPE_4M", spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.TYPE_4M].Value);
                        work_list.AddString("PROCESS_TYPE", spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.PROCESS_TYPE].Value);
                        work_list.AddString("EQ", spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.EQ].Value);
                        strValue = spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.DOWN_TIME].Text.Replace(",", "");
                        if (strValue.Length > 0)
                        {
                            work_list.AddInt("DOWN_TIME", Convert.ToInt32(strValue));
                        }
                        strValue = spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.EFF_TIME].Text.Replace(",", "");
                        if (strValue.Length > 0)
                        {
                            work_list.AddInt("EFF_TIME", Convert.ToInt32(strValue));
                        }
                        work_list.AddString("HOUR_DESC", spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.HOUR_DESC].Value);
                        work_list.AddString("CMF_2", spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.CMF_2].Value);
                        work_list.AddString("CMF_3", spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.CMF_3].Value);
                        work_list.AddString("CMF_4", spdHour.ActiveSheet.Cells[i, (int)HOUR_LIST.CMF_4].Text.Replace("%", ""));
                    }
                }   
                else if (ProcStep == 'A')  //append 
                {
                        work_list = in_node.AddNode("TRAN_LIST");
                        work_list.AddString("WORK_TIME", cdvTIME.Description);
                      
                        //work_list.AddInt("TARGET_QTY", txtTarget.Text.Replace(",", ""))  ;
                        //work_list.AddInt("FEL_QTY", 0);
                        //work_list.AddInt("FEL_QTYS", txtTarget.Text.Replace(",", ""));
                        //work_list.AddInt("DIFF_QTY", 0);
                        //work_list.AddInt("TIME_LOSS", 0);
                        int row = spdHour.ActiveSheet.ActiveRowIndex;
                        work_list.AddInt("FEL_QTY", Convert.ToInt32(spdHour.ActiveSheet.Cells[row, (int)HOUR_LIST.FEL_QTY].Text.Replace(",", "")));
                        work_list.AddInt("DIFF_QTY", Convert.ToInt32(spdHour.ActiveSheet.Cells[row, (int)HOUR_LIST.DIFF_QTY].Text.Replace(",", "")));
                        work_list.AddInt("TIME_LOSS", Convert.ToInt32(spdHour.ActiveSheet.Cells[row, (int)HOUR_LIST.TIME_LOSS].Text.Replace(",", "")));

                        work_list.AddString("CMF_1", soiRadioButton1.Value);
                        work_list.AddString("CMF_2", txtRootCause.Text);
                        work_list.AddString("CMF_3", txtActionPlan.Text);
                        work_list.AddString("CMF_4", txtHumidity.Text.Replace("%", ""));
                        work_list.AddString("TYPE_4M", cdv4M.Text);
                        work_list.AddString("PROCESS_TYPE", cdvPro.Text);
                        work_list.AddString("EQ", cdvEQ.Text);
                        work_list.AddInt("DOWN_TIME", txtdown.Text.Replace(",",""));
                        work_list.AddInt("EFF_TIME", txtEfftime.Text.Replace(",", ""));
                        work_list.AddString("HOUR_DESC", txtdesc.Text);
                        work_list.AddInt("EQ_MAX", cdvEQ.Description);
                }
                else if (ProcStep == 'U')  //UPDATE
                {
                    work_list = in_node.AddNode("TRAN_LIST");
                    work_list.AddString("WORK_TIME", cdvTIME.Description);
                    
                    //work_list.AddInt("TARGET_QTY", 0);
                    //work_list.AddInt("FEL_QTY", 0);
                    //work_list.AddInt("DIFF_QTY", 0);
                    //work_list.AddInt("TIME_LOSS", 0);

                    int row = spdHour.ActiveSheet.ActiveRowIndex;
                    work_list.AddInt("FEL_QTY", Convert.ToInt32(spdHour.ActiveSheet.Cells[row, (int)HOUR_LIST.FEL_QTY].Text.Replace(",", "")));
                    work_list.AddInt("DIFF_QTY", Convert.ToInt32(spdHour.ActiveSheet.Cells[row, (int)HOUR_LIST.DIFF_QTY].Text.Replace(",", "")));
                    work_list.AddInt("TIME_LOSS", Convert.ToInt32(spdHour.ActiveSheet.Cells[row, (int)HOUR_LIST.TIME_LOSS].Text.Replace(",", "")));

                    work_list.AddString("CMF_1", soiRadioButton1.Value);
                    work_list.AddString("CMF_2", txtRootCause.Text);
                    work_list.AddString("CMF_3", txtActionPlan.Text);
                    work_list.AddString("CMF_4", txtHumidity.Text.Replace("%", ""));
                    work_list.AddString("TYPE_4M", cdv4M.Text);
                    work_list.AddString("PROCESS_TYPE", cdvPro.Text);
                    work_list.AddString("EQ", cdvEQ.Text);
                    work_list.AddInt("EQ_MAX", cdvEQ.Description);
                    work_list.AddInt("DOWN_TIME", txtdown.Text.Replace(",", ""));
                    work_list.AddInt("EFF_TIME", txtEfftime.Text.Replace(",", ""));
                    work_list.AddString("HOUR_DESC", txtdesc.Text);
                    work_list.AddInt("HIST_SEQ", txtSEQ.Text.Replace(",", ""));
                }
                else if (ProcStep == 'D')  //DELETE
                {
                    work_list = in_node.AddNode("TRAN_LIST");
                    work_list.AddString("WORK_TIME", cdvTIME.Description);
                    work_list.AddInt("HIST_SEQ", txtSEQ.Text.Replace(",", ""));

                }
                if (MPCF.CallService("CRAS", "CRAS_Update_Hour_Gap", in_node, ref out_node) == false)
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
        #endregion

        private void soiLabel16_Click(object sender, EventArgs e)
        {

        }

        private void pnlScrapInfo_Paint(object sender, PaintEventArgs e)
        {

        }


        private void cdv4M_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@4M_KIND"));

                string[] header = new string[] { "4M_Type", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdv4M.Text = cdv4M.Show(cdv4M, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
            
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdv4M_Load(object sender, EventArgs e)
        {

        }

        private void cdvPro_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                cdvEQ.Text = "";
                cdvEQ.Description = "";
                chk_common_line = "";
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@HOURLY_GAP_PROCESS"));
                in_node.AddString("KEY_1", MPCF.Trim(cdvType.Text));
                in_node.AddString("KEY_4", " ");  //삭제 안된것만 조회
               

                string[] header = new string[] { "Type", "Process" };
                string[] display = new string[] { "KEY_1", "KEY_2" };

                cdvPro.Text = cdvPro.Show(cdvPro, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_2");



                //라인이 공용인지 체크 
                chk_common_line = "";
                TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
                TRSNode out_list;
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@HOURLY_GAP_PROCESS"));
                in_node.AddString("KEY_1", MPCF.Trim(cdvType.Text));
                in_node.AddString("KEY_2", MPCF.Trim(cdvPro.Text));
                in_node.AddString("KEY_4", " ");  //삭제 안된것만 조회
              

                MPCF.SetInMsg(in_node);
                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                {
                    return;
                }
                if (out_node.GetList(0).Count < 1)
                {
                    return;
                }

                MPCF.ShowSuccessMessage(out_node, false);
                out_list = out_node.GetList(0)[0];

                chk_common_line = out_list.GetString("DATA_4");          //공용 여부

               //.chk_common_line.chk_common_line/chk_common_line.chk_common_line

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvEQ_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if(cdvPro.Text == "")
                {
                    cdvPro.Focus();
                    MPCF.ShowMsgBox("Please Selected Process");
                    return;

                }

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@HOURLY_GAP_EQP"));
                in_node.AddString("KEY_1", MPCF.Trim(cdvPro.Text));
                if(chk_common_line == "V")
                {
                    in_node.AddString("KEY_3", " ");
                }
                else
                {
                    in_node.AddString("KEY_3", MPCF.Trim(cdvLineID.Text));
                }
                string[] header = new string[] {  "EQ", "Max EQ", "Equipment" };
                string[] display = new string[] { "DATA_1", "DATA_2", "KEY_2" };

                cdvEQ.Text = cdvEQ.Show(cdvEQ, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "DATA_1");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvTIME_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                
                if (spdHour.Sheets[0].Rows.Count < 2)
                {
                    MPCF.ShowMsgBox("Please Click View At First all");
                    return;
                }
               

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@HOURLY_GAP_TIME"));

                if (spdHour.ActiveSheet.Cells[(int)0, (int)1].Text == "06" | spdHour.ActiveSheet.Cells[(int)0, (int)1].Text == "07"
                | spdHour.ActiveSheet.Cells[(int)0, (int)1].Text == "08" | spdHour.ActiveSheet.Cells[(int)0, (int)1].Text == "09"
                | spdHour.ActiveSheet.Cells[(int)0, (int)1].Text == "10" | spdHour.ActiveSheet.Cells[(int)0, (int)1].Text == "11"
                | spdHour.ActiveSheet.Cells[(int)0, (int)1].Text == "12" | spdHour.ActiveSheet.Cells[(int)0, (int)1].Text == "13"
                | spdHour.ActiveSheet.Cells[(int)0, (int)1].Text == "14" | spdHour.ActiveSheet.Cells[(int)0, (int)1].Text == "15"
                | spdHour.ActiveSheet.Cells[(int)0, (int)1].Text == "16" | spdHour.ActiveSheet.Cells[(int)0, (int)1].Text == "17") 
                {
                    in_node.AddString("KEY_1", MPCF.Trim("DAY"));
                }
                else
                {
                    in_node.AddString("KEY_1", MPCF.Trim("NIGHT"));
                }


                string[] header = new string[] { "Time_Type", "Time" };
                string[] display = new string[] { "KEY_1", "KEY_2" };

                cdvTIME.Text = cdvTIME.Show(cdvEQ, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_2");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvTIME_Load(object sender, EventArgs e)
        {

        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            try
            {
                btnADD.Enabled = false;
                if (CheckCondition("APPEND") == false)
                {
                    btnADD.Enabled = true;
                    return;
                }
                

                if (UpdateHourRpt(MPGC.MP_STEP_APPROVAL) == false)
                {
                    btnADD.Enabled = true;
                    return;
                }

                btnView.PerformClick();
                btnADD.Enabled = true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvEQ_Load(object sender, EventArgs e)
        {

        }

        private void txtdown_ValueChanged(object sender, EventArgs e)
        {
                          

            if (cdvEQ.Text == "" && (int)txtdown.Value != 0)            
            {
                //txtdown.Text = "0";
                //cdvEQ.Focus();
                //MPCF.ShowMsgBox("Please Selected EQ");

                return;

            }

            if (chk_auto_validation == "")
            {
                chk_auto_validation = "X";
                TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
                TRSNode out_list;
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);

                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@HOURLY_GAP_PROCESS"));
                in_node.AddString("KEY_1", MPCF.Trim(cdvType.Text));
                in_node.AddString("KEY_2", MPCF.Trim(cdvPro.Text));


                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                {
                    return;
                }
                if (out_node.GetList(0).Count < 1)
                {
                    return;
                }

                MPCF.ShowSuccessMessage(out_node, false);
                out_list = out_node.GetList(0)[0];

                //chk_auto = out_list.GetString("DATA_1");
                //[2024.04.25] 이글1,이글2에 따라 설정값이 다른 부분 반영 start
                if (cdvLineID.Text == "MDL01" ||
                    cdvLineID.Text == "MDL02" ||
                    cdvLineID.Text == "MDL03")
                {
                    chk_auto = out_list.GetString("DATA_2");
                }
                else
                {
                    chk_auto = out_list.GetString("DATA_3");
                }
                //[2024.04.25] 이글1,이글2에 따라 설정값이 다른 부분 반영 end
            }



            if (chk_auto == "V")
            {
                if ((Convert.ToString(txtdown.Value) != "" && cdvEQ.Description != "") && (Convert.ToInt32(txtdown.Value) > 0 && Convert.ToInt32(cdvEQ.Description) > 0))
                {
                    txtEfftime.Value = Math.Ceiling(Convert.ToDouble(txtdown.Value) / Convert.ToDouble(cdvEQ.Description));
                }
                else
                {
                    txtEfftime.Value = 0;
                }
            }
            else
            {
                txtEfftime.Value = txtdown.Value;
            }
        }

        private void cdvEQ_ValueChanged(object sender, EventArgs e)
        {
            chk_auto_validation = "";
            txtdown.Value = 0;
            txtEfftime.Value = 0;
            chk_auto_validation = "";
            chk_auto_validation = "";
        }

        private void cdvPro_Load(object sender, EventArgs e)
        {

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            set_view();

            getShiftList();
        }

        private void dtpDate_TextChanged(object sender, EventArgs e)
        {
            set_view();
        }

        private void cdvLineID_ValueChanged(object sender, EventArgs e)
        {
            set_view();
        }

        private void cdvShift_ValueChanged(object sender, EventArgs e)
        {
            set_view();
        }

        private void cdvType_ValueChanged(object sender, EventArgs e)
        {
            set_view();
            setHumidityColumn();
            btnView.PerformClick();
        }

        private void cdvPro_ValueChanged(object sender, EventArgs e)
        {
            cdvEQ.Text = "";
            cdvEQ.Description = "";
            txtdown.Value = 0;
            txtEfftime.Value = 0;
            chk_auto_validation = "";
            chk_common_line = "";
        }

        private void setHumidityColumn()
        {
            string code = cdvType.Code;
            if (code.Equals("FE"))
            {
                soiLabel14.Visible = true;
                soiLabel10.Visible = true;
                txtHumidity.Visible = true;
                soiLabel14.Text = "H-Racks Count";
                soiLabel10.Text = "(000) Format";
                spdHour.ActiveSheet.ColumnHeader.Columns["Humidity"].Label = "H-Racks Count";
                spdHour.ActiveSheet.ColumnHeader.Columns["Humidity"].Width = 150;
                spdHour.ActiveSheet.ColumnHeader.Columns["Qty"].Label = "FE Qty";
                spdHour.ActiveSheet.ColumnHeader.Columns["Qty"].Width = 122;
            }
            else if (code.Equals("BE"))
            {
                soiLabel14.Visible = true;
                soiLabel10.Visible = true;
                txtHumidity.Visible = true;
                soiLabel14.Text = "A-Frame Count";
                soiLabel10.Text = "(000) Format";
                spdHour.ActiveSheet.ColumnHeader.Columns["Humidity"].Label = "A-Frame Count";
                spdHour.ActiveSheet.ColumnHeader.Columns["Humidity"].Width = 150;
                spdHour.ActiveSheet.ColumnHeader.Columns["Qty"].Label = "FE Qty";
                spdHour.ActiveSheet.ColumnHeader.Columns["Qty"].Width = 122;
            }
            else if ( code.Equals("FQ"))
            {
                soiLabel14.Visible = false;
                soiLabel10.Visible = false;
                txtHumidity.Visible = false;
                spdHour.ActiveSheet.ColumnHeader.Columns["Humidity"].Width = 0;
                spdHour.ActiveSheet.ColumnHeader.Columns["Qty"].Label = "FQC Qty";
                spdHour.ActiveSheet.ColumnHeader.Columns["Qty"].Width = 122;
            }
            else
            {
                soiLabel14.Visible = false;
                soiLabel10.Visible = false;
                txtHumidity.Visible = false;
                spdHour.ActiveSheet.ColumnHeader.Columns["Humidity"].Width = 0;
            }
        }

        private bool getShiftList()
        {
            try
            {
                cboShift.Items.Clear();
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                if (dtpDate.Value != null)
                {
                    in_node.AddString("SYS_DATE", ((DateTime)(dtpDate.Value)).ToString("yyyyMMdd"));
                }

                int i;
                if (MPCF.CallService("CBAS", "CBAS_View_Shift_List", in_node, ref out_node) == true)
                {
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        out_list = out_node.GetList(0)[i];

                        cboShift.Items.Add(out_list.GetString("shift"), out_list.GetString("SHIFT"));
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

        private void txtHumidity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( !(char.IsDigit(e.KeyChar) ) ) 
            {
                e.Handled = true;
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

        
    }
}
