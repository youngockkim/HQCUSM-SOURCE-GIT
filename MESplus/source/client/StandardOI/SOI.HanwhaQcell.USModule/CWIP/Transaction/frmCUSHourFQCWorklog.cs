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
    public partial class frmCUSHourFQCWorklog : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCUSHourFQCWorklog()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]
        string WORK_SHIFT_TIME = "WORK_SHIFT_TIME";
        string m_workShiftTime = "";
        public string chk_type;
        public string chk_auto_validation;
        public string chk_common_line;
        public string chk_auto;

        public enum FQCLOG
        {
            WORK_DATE,
            LINE_ID,
            WORK_SHIFT,
            HIST_SEQ,
            PIC_NAME,
            BEFE_TYPE,
            BEFE_TYPE_NM,
            SIML_TYPE,
            SIML_TYPE_NM,
            DEFECT_CODE,
            DEFECT_CODE_NM,
            WORK_TIME,
            ACTION_STTM,
            ACTION_EDTM,
            MACHINE_NO,
            MACHINE_NO_NM,
            DEFECT_DETAIL,
            ROOT_CAUSE,
            ACTION_PLAN,
            MONITORING_RESULT            
        }


        #endregion

        #region [Variable Definition]
        
        #endregion


        #region Function
        
        private void getSystemSettings()
        { 

            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@SYSTEM_SETTINGS"));

                string[] header = new string[] { "Code", "Name" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == true)
                {
                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        out_list = out_node.GetList(0)[i];
                        if (out_list.GetString("KEY_1").ToUpper().CompareTo(WORK_SHIFT_TIME) == 0)
                        {
                            m_workShiftTime = out_list.GetString("DATA_2");
                        }                        
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {

                    case "CREATE":

                        if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvShift, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvBEFEType, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvSimlType, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtName, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cboTime, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvMachine, false) == false)
                        {
                            return false;
                        }
                        
                        if ( checkStartEndCond() == false )
                            return false;

                        if (MPCF.CheckValue(cdvDefectCode, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtDefectDetail, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtRootCause, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtActionPlan, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtMonitoringResult, false) == false)
                        {
                            return false;
                        }
                        
                        break;

                    case "VIEW":
                        if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvShift, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvBEFEType, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvSimlType, false) == false)
                        {
                            return false;
                        }
                        break;

                    case "UPDATE":

                        if (spdFqcLog.Sheets[0].SelectionCount < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(590));
                            return false;
                        }


                        if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvShift, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvBEFEType, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvSimlType, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtName, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cboTime, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvMachine, false) == false)
                        {
                            return false;
                        }
                        
                        if (checkStartEndCond() == false)
                            return false;


                        if (MPCF.CheckValue(cdvDefectCode, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtDefectDetail, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtRootCause, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtActionPlan, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtMonitoringResult, false) == false)
                        {
                            return false;
                        }

                        break;
                    case "APPEND":
                        
                        if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvShift, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvBEFEType, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvSimlType, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtName, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cboTime, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvMachine, false) == false)
                        {
                            return false;
                        }

                        if (checkStartEndCond() == false)
                            return false;

                        if (MPCF.CheckValue(cdvDefectCode, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtDefectDetail, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtRootCause, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtActionPlan, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtMonitoringResult, false) == false)
                        {
                            return false;
                        }

                        break;

                    case "DELETE":

                        if (spdFqcLog.Sheets[0].SelectionCount < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(591));
                            return false;
                        }

                        if (txtSEQ.Text == "")
                        {
                            txtSEQ.Focus();
                            return false;
                        }

                        if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvShift, false) == false)
                        {
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
        private bool checkStartEndCond() {

            if (cdvSimlType.Text == "SIM" )
            {
                if (soiStartHour.Text == "" || soiStartMin.Text == "")
                {
                    soiStartHour.Focus();
                    MPCF.ShowMessage("Please enter both Start Time and End Time as you selected SIM for Type II.", MSG_LEVEL.ERROR, false);
                    return false;
                }
                if (soiEndHour.Text == "" || soiEndMin.Text == "")
                {
                    soiEndHour.Focus();
                    MPCF.ShowMessage("Please enter both Start Time and End Time as you selected SIM for Type II.", MSG_LEVEL.ERROR, false);
                    return false;
                }

                string strStartTime = getActionDateTime(soiStartDate.Value) + soiStartHour.Text + soiStartMin.Text;
                string strEndTime = getActionDateTime(soiEndDate.Value) + soiEndHour.Text + soiEndMin.Text;

                if (DateTime.ParseExact(strStartTime, "yyyyMMddHHmm", null) >
                        DateTime.ParseExact(strEndTime, "yyyyMMddHHmm", null))
                {
                    soiEndHour.Focus();
                    MPCF.ShowMessage("The Start Date/Time cannot be greater than the End Date/Time, so please check and modify.", MSG_LEVEL.ERROR, false);
                    return false;
                }

            }
            else
            {

                if (soiEndHour.Text == "" || soiEndMin.Text == "")
                {
                    soiEndHour.Focus();
                    MPCF.ShowMessage("Please enter End Time as you selected " + cdvSimlType.Text + " for Type II.", MSG_LEVEL.ERROR, false);
                    return false;
                }
            }

            return true;
        }

        private string getActionDateTime(object actionDate)
        {
            DateTime dtDateout = DateTime.Now;

            if (soiStartDate.Value != null)
            {
                bool bTrySuccess = DateTime.TryParse(actionDate.ToString(), out dtDateout);
                if (bTrySuccess == true)
                {
                    return dtDateout.ToString("yyyyMMdd");
                }
            }

            return dtDateout.ToString("yyyyMMdd");
        }

        private bool ViewWorklogList()
        {
            try
            {
                int i;


                chk_type = "";

                DateTime dtpFromDateTimeOut = new DateTime();

                MPCF.ClearList(spdFqcLog);

                TRSNode in_node = new TRSNode("VIEW_FQCLOG_IN");
                TRSNode out_node = new TRSNode("VIEW_FQCLOG_OUT");
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

                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
                in_node.AddString("WORK_SHIFT", MPCF.Trim(cdvShift.Text));
                in_node.AddString("BEFE_TYPE", MPCF.Trim(cdvBEFEType.Text));
                in_node.AddString("SIML_TYPE", MPCF.Trim(cdvSimlType.Text));

                if (MPCF.CallService("CWIP", "CWIP_View_Hourly_Fqc_Worklog_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                spdFqcLog.ActiveSheet.RowCount = 0;


                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];
                    spdFqcLog.ActiveSheet.RowCount++;
                    spdFqcLog.ActiveSheet.Cells[i, (int)FQCLOG.WORK_DATE].Value = out_list.GetString("WORK_DATE");
                    spdFqcLog.ActiveSheet.Cells[i, (int)FQCLOG.WORK_SHIFT].Value = out_list.GetString("WORK_SHIFT");
                    spdFqcLog.ActiveSheet.Cells[i, (int)FQCLOG.WORK_TIME].Value = out_list.GetString("WORK_TIME");
                    spdFqcLog.ActiveSheet.Cells[i, (int)FQCLOG.HIST_SEQ].Value = out_list.GetInt("HIST_SEQ");
                    spdFqcLog.ActiveSheet.Cells[i, (int)FQCLOG.LINE_ID].Value = out_list.GetString("LINE_ID");
                    spdFqcLog.ActiveSheet.Cells[i, (int)FQCLOG.PIC_NAME].Value = out_list.GetString("PIC_NAME");
                    spdFqcLog.ActiveSheet.Cells[i, (int)FQCLOG.BEFE_TYPE].Value = out_list.GetString("BEFE_TYPE");
                    spdFqcLog.ActiveSheet.Cells[i, (int)FQCLOG.BEFE_TYPE_NM].Value = out_list.GetString("BEFE_TYPE_NM");
                    spdFqcLog.ActiveSheet.Cells[i, (int)FQCLOG.SIML_TYPE].Value = out_list.GetString("SIML_TYPE");
                    spdFqcLog.ActiveSheet.Cells[i, (int)FQCLOG.SIML_TYPE_NM].Value = out_list.GetString("SIML_TYPE_NM");
                    spdFqcLog.ActiveSheet.Cells[i, (int)FQCLOG.MACHINE_NO].Value = out_list.GetString("MACHINE_NO");
                    spdFqcLog.ActiveSheet.Cells[i, (int)FQCLOG.MACHINE_NO_NM].Value = out_list.GetString("MACHINE_NO_NM");
                    spdFqcLog.ActiveSheet.Cells[i, (int)FQCLOG.DEFECT_CODE].Value = out_list.GetString("DEFECT_CODE");
                    spdFqcLog.ActiveSheet.Cells[i, (int)FQCLOG.DEFECT_CODE_NM].Value = out_list.GetString("DEFECT_CODE_NM");
                    spdFqcLog.ActiveSheet.Cells[i, (int)FQCLOG.DEFECT_DETAIL].Value = out_list.GetString("DEFECT_DETAIL");
                    spdFqcLog.ActiveSheet.Cells[i, (int)FQCLOG.ROOT_CAUSE].Value = out_list.GetString("ROOT_CAUSE");
                    spdFqcLog.ActiveSheet.Cells[i, (int)FQCLOG.ACTION_STTM].Value = out_list.GetString("ACTION_STTM");
                    spdFqcLog.ActiveSheet.Cells[i, (int)FQCLOG.ACTION_EDTM].Value = out_list.GetString("ACTION_EDTM");
                    spdFqcLog.ActiveSheet.Cells[i, (int)FQCLOG.ACTION_PLAN].Value = out_list.GetString("ACTION_PLAN");
                    spdFqcLog.ActiveSheet.Cells[i, (int)FQCLOG.MONITORING_RESULT].Value = out_list.GetString("MONITORING_RESULT");
                    if (out_list.GetInt("HIST_SEQ") == 0)
                    {
                        chk_type = "C";
                    }

                    else
                    {
                        chk_type = "U";
                    }
                }

                //MPCF.FitColumnHeader(spdFqcLog);


                if (chk_type == "C")
                {
                    set_create();
                }
                else if (chk_type == "U")
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

        private bool UpdateData(char ProcStep)
        {
            int seqno = 0;

            try
            {
                DateTime dtpScrapDateTimeOut = new DateTime();

                TRSNode in_node = new TRSNode("UPDATE_FQCLOG_IN");
                TRSNode out_node = new TRSNode("UPDATE_FQCLOG_OUT");

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
                if (MPCF.Trim(txtSEQ.Text).Length > 0)
                {
                    int.TryParse(MPCF.Trim(txtSEQ.Text), out seqno);
                }

                string strStartTime = getActionDateTime(soiStartDate.Value) + soiStartHour.Text + soiStartMin.Text;
                string strEndTime = getActionDateTime(soiEndDate.Value) + soiEndHour.Text + soiEndMin.Text;
                
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
                in_node.AddInt("HIST_SEQ", seqno);
                in_node.AddString("BEFE_TYPE", MPCF.Trim(cdvBEFEType.Text));
                in_node.AddString("SIML_TYPE", MPCF.Trim(cdvSimlType.Text));
                in_node.AddString("WORK_SHIFT", MPCF.Trim(cdvShift.Text));
                in_node.AddString("WORK_TIME", cboTime.Text);
                in_node.AddString("PIC_NAME", txtName.Text);
                in_node.AddString("MACHINE_NO", cdvMachine.Text);
                in_node.AddString("DEFECT_CODE", cdvDefectCode.Code);
                in_node.AddString("DEFECT_DETAIL", txtDefectDetail.Text);
                in_node.AddString("ROOT_CAUSE", txtRootCause.Text);
                in_node.AddString("ACTION_STTM", strStartTime);
                in_node.AddString("ACTION_EDTM", strEndTime);
                in_node.AddString("ACTION_PLAN", txtActionPlan.Text);
                in_node.AddString("MONITORING_RESULT", txtMonitoringResult.Text.Replace("%", ""));
                
                if (MPCF.CallService("CWIP", "CWIP_Update_Hourly_Fqc_Worklog", in_node, ref out_node) == false)
                {
                    if (out_node.Msg.Contains("000") == false)
                    {
                        return false;
                    }
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
        private void setWorkShiftTimeData() 
        {
            try
            {
                this.cboTime.Items.Clear();
                string item = cdvShift.Text;
                int workShiftTime;
                if (int.TryParse(m_workShiftTime.Substring(0, 2), out workShiftTime) == false)
                {
                    return;
                };

                if (item.CompareTo("B") == 0 || item.CompareTo("D") == 0)
                {
                    workShiftTime += 12;
                }

                for (int inx = 0; inx < 12; inx++)
                {
                    int temp = inx + workShiftTime;
                    if (temp > 23)
                    {
                        temp = temp - 24;
                    }
                    String strTime = String.Format("{0,1}", temp.ToString("D2"));
                    this.cboTime.Items.Add(strTime);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }
        #endregion

        #region Event Handler

        private void frmCUSHourFQCWorklog_Load(object sender, EventArgs e)
        {
            // Init
            //dtpDate.Value = DateTime.Now.AddDays(-1) ;
            dtpDate.Value = DateTime.Now;
            chk_auto_validation = "";
            chk_auto = "";
            chk_common_line = "";

            getSystemSettings();

            initialize();
            MPCF.ConvertCaption(this);

            txt_clear();
        }


        private void initialize() 
        {
            spdFqcLog.Sheets[0].Columns.Get((int)FQCLOG.BEFE_TYPE).Width = 0;
            spdFqcLog.Sheets[0].Columns.Get((int)FQCLOG.SIML_TYPE).Width = 0;
            spdFqcLog.Sheets[0].Columns.Get((int)FQCLOG.DEFECT_CODE).Width = 0;
            spdFqcLog.Sheets[0].Columns.Get((int)FQCLOG.MACHINE_NO).Width = 0;
        }

        private void frmCUSHourFQCWorklog_Shown(object sender, EventArgs e)
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

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvLineID.Text = cdvLineID.Show(cdvLineID, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }

            if (cdvShift.Text.Trim().Length > 0 && 
                cdvBEFEType.Text.Trim().Length > 0 && 
                cdvSimlType.Text.Trim().Length > 0 ) 
            {
                btnView.PerformClick();
            }

        }
        private void cdvShift_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                if (dtpDate.Value != null)
                {
                    in_node.AddString("SYS_DATE", ((DateTime)(dtpDate.Value)).ToString("yyyyMMdd"));
                }

                string[] header = new string[] { "Shift"};
                string[] display = new string[] { "SHIFT" };

                cdvShift.Text = cdvShift.Show(cdvShift, "Shift List", "CBAS", "CBAS_View_Shift_List", in_node, "LIST", display, header, "SHIFT");

                setWorkShiftTimeData();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }

            if (cdvLineID.Text.Trim().Length > 0 &&
                cdvBEFEType.Text.Trim().Length > 0 &&
                cdvSimlType.Text.Trim().Length > 0)
            {
                btnView.PerformClick();
            }

        }
        private void cdvBEFEType_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@CMN_TYPE_BEFE"));

                string[] header = new string[] { "Type", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvBEFEType.Text = cdvBEFEType.Show(cdvBEFEType, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }

            if (cdvLineID.Text.Trim().Length > 0 &&
                cdvShift.Text.Trim().Length > 0 &&
                cdvSimlType.Text.Trim().Length > 0)
            {
                btnView.PerformClick();
            }
        }
        private void cdvSimlType_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@FQC_WORKLOG_SIMTYPE"));

                string[] header = new string[] { "Code", "Name" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvSimlType.Text = cdvSimlType.Show(cdvSimlType, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }

            if (cdvSimlType.Text == "SIM")
            {
                soiTableLayoutPanel13.Enabled = true;
                soiTableLayoutPanel15.Enabled = true;
            }
            if (cdvSimlType.Text == "FQC" || cdvSimlType.Text == "RWK")
            {
                soiTableLayoutPanel15.Enabled = true;
                soiTableLayoutPanel13.Enabled = false;
            }

            if (cdvLineID.Text.Trim().Length > 0 &&
                cdvBEFEType.Text.Trim().Length > 0 &&
                cdvShift.Text.Trim().Length > 0)
            {
                btnView.PerformClick();
            }
        }
        private void cdvMachine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (cdvBEFEType.Text == "")
                {
                    cdvBEFEType.Focus();
                    MPCF.ShowMsgBox("Please select a relevant option in Type I.");
                    return;

                }

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@FQC_WKLOG_MACHINE"));
                in_node.AddString("KEY_2", MPCF.Trim(this.cdvLineID.Text));
                in_node.AddString("KEY_3", MPCF.Trim(cdvBEFEType.Text));

                string[] header = new string[] { "Res ID", "Process"};
                string[] display = new string[] { "KEY_1", "DATA_1"};

                cdvMachine.Text = cdvMachine.Show(cdvMachine, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }
        private void cdvDefectCode_CodeViewButtonClick(object sender, EventArgs e)
        {

            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);

                string strSimlType = MPCF.Trim(cdvSimlType.Text);

                if (strSimlType == "RWK")
                {
                    strSimlType = "FQC";
                }

                in_node.ProcStep = 'B';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@CMN_DEFECT_TYPE"));
                in_node.AddString("KEY_1", "WORKLOG_FQC");
                in_node.AddString("KEY_2", strSimlType);

                string[] header = new string[] { "System Code", "Defect Info" };
                string[] display = new string[] { "KEY_1", "DATA_1" };
                cdvDefectCode.Text = cdvDefectCode.Show(cdvDefectCode, "Defect Code", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_1");

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
                //    spdFqcLog.Sheets[0].Protect = false;
                //    spdFqcLog.SaveExcel(pop.FileName, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders);
                //    spdFqcLog.Sheets[0].Protect = true;
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void set_view()
        {
            txt_clear();
            btnADD.Enabled = true;
            //btnUpdate.Enabled = true;
            //btnDelete.Enabled = true;
        }

        private void set_update()
        {
            txt_clear();
            btnProcess.Enabled = false;
            btnADD.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            txtName.Enabled = true;
            cboTime.Enabled = true;
            cdvMachine.Enabled = true;
            txtDefectDetail.Enabled = true;
            cdvDefectCode.Enabled = true;
            txtSEQ.Enabled = true;

        }

        private void set_create()
        {
            txt_clear();
            btnProcess.Enabled = true;
            btnUpdate.Enabled = true;
            btnADD.Enabled = false;
            btnDelete.Enabled = false;
            txtName.Enabled = false;
            cboTime.Enabled = false;
            cdvMachine.Enabled = false;
            txtDefectDetail.Enabled = false;
            cdvDefectCode.Enabled = false;
            txtSEQ.Enabled = false;

        }


        private void txt_clear()
        {
            txtName.Text = "";
            cboTime.Text = "";
            cdvMachine.Text = "";
            txtDefectDetail.Text = "";
            cdvDefectCode.Text = "";
            txtSEQ.Text = "";
            cboTime.Text = "";
            cdvMachine.Description = "";
            cdvDefectCode.Description = "";
            txtRootCause.Text = "";
            txtActionPlan.Text = "";
            txtMonitoringResult.Text = "";
            txtMonitoringResult.Text = "";

            soiStartDate.Value = DateTime.Now;//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
            soiStartHour.Text = "";
            soiStartMin.Text = "";
            soiStartSec.SelectedIndex = 0;
            soiEndDate.Value = DateTime.Now;//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
            soiEndHour.Text = "";
            soiEndMin.Text = "";
            soiEndSec.SelectedIndex = 0;
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
                    return;
                }

                if (ViewWorklogList() == false)
                {
                    return;
                }
                set_view();
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

                    if (UpdateData(MPGC.MP_STEP_CREATE) == false)
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

                    if (UpdateData(MPGC.MP_STEP_UPDATE) == false)
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
                if (MPCF.ShowMsgBox(MPCF.GetMessage(451), MessageBoxButtons.YesNo, MSG_LEVEL.NONE, "") == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                if (CheckCondition("DELETE") == false)
                {
                    return;
                }

                if (UpdateData(MPGC.MP_STEP_DELETE) == false)
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

        private void spdFqcLog_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {

                set_update();
                txt_clear();
                txtName.Text = spdFqcLog.Sheets[0].Cells[e.Row, (int)FQCLOG.PIC_NAME].Text;
                cboTime.Text = spdFqcLog.Sheets[0].Cells[e.Row, (int)FQCLOG.WORK_TIME].Text;
                cdvMachine.Text = spdFqcLog.Sheets[0].Cells[e.Row, (int)FQCLOG.MACHINE_NO].Text;
                cdvMachine.Description = spdFqcLog.Sheets[0].Cells[e.Row, (int)FQCLOG.MACHINE_NO_NM].Text;
                cdvDefectCode.Code = spdFqcLog.Sheets[0].Cells[e.Row, (int)FQCLOG.DEFECT_CODE].Text;
                cdvDefectCode.Description = spdFqcLog.Sheets[0].Cells[e.Row, (int)FQCLOG.DEFECT_CODE_NM].Text;
                txtDefectDetail.Text = spdFqcLog.Sheets[0].Cells[e.Row, (int)FQCLOG.DEFECT_DETAIL].Text;
                txtRootCause.Text = spdFqcLog.Sheets[0].Cells[e.Row, (int)FQCLOG.ROOT_CAUSE].Text;
                txtSEQ.Text = spdFqcLog.Sheets[0].Cells[e.Row, (int)FQCLOG.HIST_SEQ].Text;
                txtActionPlan.Text = spdFqcLog.Sheets[0].Cells[e.Row, (int)FQCLOG.ACTION_PLAN].Text;
                txtMonitoringResult.Text = spdFqcLog.Sheets[0].Cells[e.Row, (int)FQCLOG.MONITORING_RESULT].Text;
                String startTime = spdFqcLog.Sheets[0].Cells[e.Row, (int)FQCLOG.ACTION_STTM].Text;

                DateTime dtpFromDateTimeOut = new DateTime();
                if (dtpDate.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpDate.Value.ToString(), out dtpFromDateTimeOut);
                    if (bTrySuccess == true)
                    {

                    }
                }

                if (startTime.Length == 12)
                {
                    soiStartDate.Value = DateTime.ParseExact(startTime, "yyyyMMddHHmm", null);
                    soiStartHour.Text = startTime.Substring(8, 2);
                    soiStartMin.Text = startTime.Substring(10, 2);
                    //soiStartSec.Text = startTime.Substring(12, 2);
                }
                else
                {
                    soiStartDate.Value = dtpFromDateTimeOut;
                    soiStartHour.Text = "00";
                    soiStartMin.Text = "00";
                    soiStartSec.Text = "00";
                }
                String endTime = spdFqcLog.Sheets[0].Cells[e.Row, (int)FQCLOG.ACTION_EDTM].Text;
                if (endTime.Length == 12)
                {
                    soiEndDate.Value = DateTime.ParseExact(endTime, "yyyyMMddHHmm", null);
                    soiEndHour.Text = endTime.Substring(8, 2);
                    soiEndMin.Text = endTime.Substring(10, 2);
                    //soiEndSec.Text = endTime.Substring(12, 2);
                }
                else
                {
                    soiEndDate.Value = dtpFromDateTimeOut;
                    soiEndHour.Text = "00";
                    soiEndMin.Text = "00";
                    //soiEndSec.Text = "00";
                }               

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }               
 
        private void btnADD_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("APPEND") == false)
                {
                    return;
                }


                if (UpdateData(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }

                btnView.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            cdvShift.Text = "";
        }

        private void dtpDate_TextChanged(object sender, EventArgs e)
        {
            cdvShift.Text = "";
        }

        private void cdvLineID_ValueChanged(object sender, EventArgs e)
        {
        }

        private void cboShift_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cdvType_ValueChanged(object sender, EventArgs e)
        {           
        }
         

        #endregion
    }
}
