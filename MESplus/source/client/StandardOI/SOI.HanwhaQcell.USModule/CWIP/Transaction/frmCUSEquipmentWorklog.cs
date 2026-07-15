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
    public partial class frmCUSEquipmentWorklog : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCUSEquipmentWorklog()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]
        public string chk_type;
        public string chk_auto_validation;
        public string chk_auto;
        public bool soiStartDateLoadflag;
        public bool soiEndDateLoadflag;
        public enum EQUIPMENT_WORKLOG_LIST
        {
            WORK_SHIFT,
            WORK_TIME,
            HIST_SEQ,
            MACHINE,
            MACHINE_NUMBER,
            PM,
            START_TIME,
            END_TIME,
            REPAIR_TIME,
            ISSUES,
            ISSUES_DETAILS,
            ROOT_CAUSES,
            PART_REPLACEMENT,
            PART_REPLACEMENT_QUANTITIES,
            ENG_TEC_NAME,//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
            REQUEST,
            REQUEST_DESC,
            PITCHBELT,
            PITCHBELT_DESC
        }

        #endregion

        #region [Variable Definition]
        
        #endregion

        #region Event Handler

        private void frmCUSEquipmentWorklog_Load(object sender, EventArgs e)
        {
            // Init
            dtpDate.Value = DateTime.Now;
            soiStartDate.Value = DateTime.Now;
            soiEndDate.Value = DateTime.Now;
            soiStartDateLoadflag = true;
            soiEndDateLoadflag = true;
            chk_auto_validation = "";
            chk_auto = "";

            set_view();

            if (MPGV.gsUserGroup != "OI_EQ_Worklog_Group")
            {
                btnView.Enabled = false;
            }

            if (MPGV.gsUserID == "ADMIN") 
            {
                btnView.Enabled = true;
            }

            getRequestData();

            getPitchBeltData();

            getPMData();

            initialize();

            MPCF.ConvertCaption(this);
        }

        private void initialize()
        {
            spdWorklog.ActiveSheet.Columns.Get((int)EQUIPMENT_WORKLOG_LIST.REQUEST).Width = 0;
            spdWorklog.ActiveSheet.Columns.Get((int)EQUIPMENT_WORKLOG_LIST.PITCHBELT).Width = 0; 
        }

        private void getPMData()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LINE_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
                TRSNode out_list;
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@EQ_WORKLOG_PM"));

                string[] header = new string[] { "Type", "Description" };
                string[] display = new string[] { "DATA_1", "DATA_2" };

                int i;
                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == true)
                {
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        out_list = out_node.GetList(0)[i];

                        cboPM.Items.Add(out_list.GetString("KEY_1"), out_list.GetString("DATA_1"));
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }
        private void getRequestData()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LINE_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
                TRSNode out_list;
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@EQLOG_REQUEST"));

                string[] header = new string[] { "Type", "Description" };
                string[] display = new string[] { "DATA_1", "DATA_2" };

                int i;
                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == true)
                {
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        out_list = out_node.GetList(0)[i];

                        cboRequest.Items.Add(out_list.GetString("KEY_1"), out_list.GetString("DATA_1"));
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void getPitchBeltData()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LINE_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
                TRSNode out_list;
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@EQLOG_PITCHBELT"));

                string[] header = new string[] { "Type", "Description" };
                string[] display = new string[] { "DATA_1", "DATA_2" };

                int i;
                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == true)
                {
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        out_list = out_node.GetList(0)[i];

                        cboPitchBelt.Items.Add(out_list.GetString("KEY_1"), out_list.GetString("DATA_1"));
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void frmCUSEquipmentWorklog_Shown(object sender, EventArgs e)
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
                in_node.AddString("LINE_LOCATION", "E1");//Eagle2 - 2023/08/28 이글1만 나오도록 수정

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
                in_node.AddString("TABLE_NAME", MPCF.Trim("@EQUIP_WORK_TYPE"));

                string[] header = new string[] { "Type", "Description" };
                string[] display = new string[] { "DATA_1", "DATA_2" };

                cdvType.Text = cdvType.Show(cdvType, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "DATA_1");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void set_view()
        {
            if (soiStartDateLoadflag == false && soiEndDateLoadflag == false)
            {
                txt_clear();
            }
            
            btnProcess.Enabled = false;
            btnADD.Enabled = false;
            btnUpdate.Enabled = false;
			btnCOPY.Enabled = false; //IS-21-08-024 [프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
            btnDelete.Enabled = false;
            cdvMachine.Enabled = false;
            cdvMachineNum.Enabled = false;
            cboPM.Enabled = false;
            soiStartDate.Enabled = false;
            soiStartHour.Enabled = false;
            soiStartMin.Enabled = false;
            soiStartSec.Enabled = false;
            soiEndDate.Enabled = false;
            soiEndHour.Enabled = false;
            soiEndMin.Enabled = false;
            soiEndSec.Enabled = false;
            txtRootCause.Enabled = false;
            txtRepParts.Enabled = false;
            txtRepQuant.Enabled = false;
            txtIssues.Enabled = false;
            txtIssuesDesc.Enabled = false;
            //IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
            txtEngTecName.Enabled = false;
        }

        private void set_update()
        {
            txt_clear();
            btnProcess.Enabled = false;
            btnADD.Enabled = true;
			btnUpdate.Enabled = true;
			btnCOPY.Enabled = true; //IS-21-08-024 [프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
            btnDelete.Enabled = true;
            cdvMachine.Enabled = true;
            cdvMachineNum.Enabled = true;
            cboPM.Enabled = true;
            soiStartDate.Enabled = true;
            soiStartHour.Enabled = true;
            //soiStartHour.ReadOnly = false;//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
            soiStartMin.Enabled = true;
            soiStartSec.Enabled = true;
            soiEndDate.Enabled = true;
            soiEndHour.Enabled = true;
            //soiEndHour.ReadOnly = false;//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
            soiEndMin.Enabled = true;
            soiEndSec.Enabled = true;
            txtRootCause.Enabled = true;
            txtRepParts.Enabled = true;
            txtRepQuant.Enabled = true;
            txtIssues.Enabled = true;
            txtIssuesDesc.Enabled = true;
            txtEngTecName.Enabled = true;//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
        }

        private void set_create()
        {
            txt_clear();
            btnProcess.Enabled = true;
            btnUpdate.Enabled = true;
            btnADD.Enabled = false;
            btnCOPY.Enabled = false; //IS-21-08-024 [프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
            btnDelete.Enabled = false;
            cdvMachine.Enabled = false;
            cdvMachineNum.Enabled = false;
            cboPM.Enabled = false;
            soiStartDate.Enabled = false;
            soiStartHour.Enabled = false;
            soiStartMin.Enabled = false;
            soiStartSec.Enabled = false;
            soiEndDate.Enabled = false;
            soiEndHour.Enabled = false;
            soiEndMin.Enabled = false;
            soiEndSec.Enabled = false;
            txtRootCause.Enabled = false;
            txtRepParts.Enabled = false;
            txtRepQuant.Enabled = false;
            txtIssues.Enabled = false;
            txtIssuesDesc.Enabled = false;
            txtEngTecName.Enabled = false;//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
        }

        private void txt_clear()
        {
            cdvMachine.Text = "";
            cdvMachineNum.Text = "";
            cboPM.Text = "";
            cdvMachine.Description = "";
            cdvMachineNum.Description = "";
            soiStartDate.Value = DateTime.Now;//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog

            if (cboShift.Text == "A" || cboShift.Text == "C")
            {
                soiStartHour.Text = "06";
                soiEndHour.Text = "06";
            }
            else if (cboShift.Text == "B" || cboShift.Text == "D")
            {
                soiStartHour.Text = "18";
                soiEndHour.Text = "18";
            }
            else
            {

            }
             
            //soiStartHour.Text = "00";
            soiStartMin.Text = "00";
            soiStartSec.Text = "00";
            soiEndDate.Value = DateTime.Now;//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
            //soiEndHour.Text = "00";
            soiEndMin.Text = "00";
            soiEndSec.Text = "00";
            txtRootCause.Text = "";
            txtRepParts.Text = "";
            txtRepQuant.Text = "0";
            txtIssues.Text = "";
            txtIssuesDesc.Text = "";
            cboRequest.Value = "";
            cboPitchBelt.Value = "";
            txtEngTecName.Text = "";//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
        }

        private void calculate_repair_time()
        {
            //IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
            if (soiStartHour.Text == "" || soiStartMin.Text == "" || soiStartSec.Text == "" || soiEndHour.Text == "" || soiEndMin.Text == "" || soiEndSec.Text == "")
            {
                return;
            }
            int EndHour = int.Parse(soiEndHour.Text);
            int EndMin = int.Parse(soiEndMin.Text);
            int EndSec = int.Parse(soiEndSec.Text);

            int StartHour = int.Parse(soiStartHour.Text);
            int StartMin = int.Parse(soiStartMin.Text);
            int StartSec = int.Parse(soiStartSec.Text);

            int calHour = EndHour - StartHour;
            int calMin = EndMin - StartMin;
            int calSec = EndSec - StartSec;

            DateTime T1 = DateTime.Parse(soiStartDate.Text);
            DateTime T2 = DateTime.Parse(soiEndDate.Text);
            TimeSpan TS = T2 - T1;

            int diffDay = TS.Days;
            //int genSec = diffDay * 24 * 60 * 60 +
            //    calHour * 60 * 60 +
            //    calMin * 60 +
            //    calSec;

            int genSec = diffDay * 24 * 60 * 60 +
            calHour * 60 * 60 +
            calMin * 60 +
            calSec;

            TimeSpan time = TimeSpan.FromSeconds(genSec);

            txtRepTime.Text = time.TotalMinutes.ToString();

            //txtRepTime.Text = genSec.ToString();
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
                
                if (ViewEQWorklogList() == false)
                {
                    set_view();
                    return;
                }
                 
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

                if (UpdateEQWorklog(MPGC.MP_STEP_CREATE) == false)
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

                    if (UpdateEQWorklog(MPGC.MP_STEP_CREATE) == false)
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

                    if (UpdateEQWorklog(MPGC.MP_STEP_UPDATE) == false)
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

                if (UpdateEQWorklog(MPGC.MP_STEP_DELETE) == false)
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

        private void spdWorklog_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
				DateTime dtpFromDateTimeOut = new DateTime();
				if (dtpDate.Value != null)
				{
					bool bTrySuccess = DateTime.TryParse(dtpDate.Value.ToString(), out dtpFromDateTimeOut);
					if (bTrySuccess == true)
					{
						
					}
				}

                txt_clear();
                cdvMachine.Text = spdWorklog.Sheets[0].Cells[e.Row, (int)EQUIPMENT_WORKLOG_LIST.MACHINE].Text;
                cdvMachineNum.Text = spdWorklog.Sheets[0].Cells[e.Row, (int)EQUIPMENT_WORKLOG_LIST.MACHINE_NUMBER].Text;
                cboPM.Value = spdWorklog.Sheets[0].Cells[e.Row, (int)EQUIPMENT_WORKLOG_LIST.PM].Value;
                txtTime.Text = spdWorklog.Sheets[0].Cells[e.Row, (int)EQUIPMENT_WORKLOG_LIST.WORK_TIME].Text;
                cdvMachine.Description = spdWorklog.Sheets[0].Cells[e.Row, (int)EQUIPMENT_WORKLOG_LIST.MACHINE].Text;
                cdvMachineNum.Description = spdWorklog.Sheets[0].Cells[e.Row, (int)EQUIPMENT_WORKLOG_LIST.MACHINE_NUMBER].Text;
                cboRequest.Value = spdWorklog.Sheets[0].Cells[e.Row, (int)EQUIPMENT_WORKLOG_LIST.REQUEST].Value;
                cboPitchBelt.Value = spdWorklog.Sheets[0].Cells[e.Row, (int)EQUIPMENT_WORKLOG_LIST.PITCHBELT].Value;
                String startTime = spdWorklog.Sheets[0].Cells[e.Row, (int)EQUIPMENT_WORKLOG_LIST.START_TIME].Text;
                if (startTime.Length == 14)
                {
                    soiStartDate.Value = DateTime.ParseExact(startTime, "yyyyMMddHHmmss", null);
                    soiStartHour.Text = startTime.Substring(8, 2);
                    soiStartMin.Text = startTime.Substring(10, 2);
                    soiStartSec.Text = startTime.Substring(12, 2);
                }
                else
                {
					soiStartDate.Value = dtpFromDateTimeOut;
                    //IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
                    //if (txtTime.Text == "01" || txtTime.Text == "02" || txtTime.Text == "03" || txtTime.Text == "04" || txtTime.Text == "05")
					if (txtTime.Text == "00" || txtTime.Text == "01" || txtTime.Text == "02" || txtTime.Text == "03" || txtTime.Text == "04" || txtTime.Text == "05")
                    {
                        soiStartDate.Value = dtpFromDateTimeOut.AddDays(1);
                    }
					soiStartHour.Text = txtTime.Text;
                    soiStartMin.Text = "00";
                    soiStartSec.Text = "00";
                }
                String endTime = spdWorklog.Sheets[0].Cells[e.Row, (int)EQUIPMENT_WORKLOG_LIST.END_TIME].Text;
				if (endTime.Length == 14)
                {
                    soiEndDate.Value = DateTime.ParseExact(endTime, "yyyyMMddHHmmss", null);
					soiEndHour.Text = endTime.Substring(8, 2);
					soiEndMin.Text = endTime.Substring(10, 2);
					soiEndSec.Text = endTime.Substring(12, 2);
                }
                else
                {
					soiEndDate.Value = dtpFromDateTimeOut;
                    //IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
                    //if (txtTime.Text == "01" || txtTime.Text == "02" || txtTime.Text == "03" || txtTime.Text == "04" || txtTime.Text == "05")
					if (txtTime.Text == "00" || txtTime.Text == "01" || txtTime.Text == "02" || txtTime.Text == "03" || txtTime.Text == "04" || txtTime.Text == "05")
                    {
                        soiEndDate.Value = dtpFromDateTimeOut.AddDays(1);
                    }
					soiEndHour.Text = txtTime.Text;
                    soiEndMin.Text = "00";
                    soiEndSec.Text = "00";
                }               

				txtRepTime.Value = spdWorklog.Sheets[0].Cells[e.Row, (int)EQUIPMENT_WORKLOG_LIST.REPAIR_TIME].Text;
				txtRootCause.Text = spdWorklog.Sheets[0].Cells[e.Row, (int)EQUIPMENT_WORKLOG_LIST.ROOT_CAUSES].Text;
                txtRepParts.Text = spdWorklog.Sheets[0].Cells[e.Row, (int)EQUIPMENT_WORKLOG_LIST.PART_REPLACEMENT].Text;
                txtRepQuant.Text = spdWorklog.Sheets[0].Cells[e.Row, (int)EQUIPMENT_WORKLOG_LIST.PART_REPLACEMENT_QUANTITIES].Text;
                txtIssues.Text = spdWorklog.Sheets[0].Cells[e.Row, (int)EQUIPMENT_WORKLOG_LIST.ISSUES].Text;
                txtIssuesDesc.Text = spdWorklog.Sheets[0].Cells[e.Row, (int)EQUIPMENT_WORKLOG_LIST.ISSUES_DETAILS].Text;
                txtEngTecName.Text = spdWorklog.Sheets[0].Cells[e.Row, (int)EQUIPMENT_WORKLOG_LIST.ENG_TEC_NAME].Text;//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
                txtSEQ.Text = spdWorklog.Sheets[0].Cells[e.Row, (int)EQUIPMENT_WORKLOG_LIST.HIST_SEQ].Text;
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

                        if (spdWorklog.Sheets[0].SelectionCount < 1)
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

                        if (cdvMachine.Text == "")
                        {
                            cdvMachine.Focus();
                            MPCF.ShowMsgBox("Please select a machine.");
                            return false;
                        }
                        if (cdvMachineNum.Text == "")
                        {
                            cdvMachineNum.Focus();
                            MPCF.ShowMsgBox("Please select a machine number.");
                            return false;
                        }

                        if (cboPM.Text == "")
                        {
                            cdvMachineNum.Focus();
                            MPCF.ShowMsgBox("Please select an option from the dropdown list in Down Type field.");
                            return false;
                        }
                        
                        if (soiStartDate.Text == "")
                        {
                            soiStartDate.Focus();
                            MPCF.ShowMsgBox("Please Selected Start Date");
                            return false;
                        }

                        if (soiStartHour.Text == "")
                        {
                            soiStartHour.Focus();
                            MPCF.ShowMsgBox("Please Select Selected Hour");
                            return false;
                        }


                        if (soiStartMin.Text == "")
                        {
                            soiStartMin.Focus();
                            MPCF.ShowMsgBox("Please Select Selected Minute");
                            return false;
                        }

                        if (soiStartSec.Text == "")
                        {
                            soiStartSec.Focus();
                            MPCF.ShowMsgBox("Please Select Selected Seconds");
                            return false;
                        }

                        if (soiEndDate.Text == "")
                        {
                            soiEndDate.Focus();
                            MPCF.ShowMsgBox("Please Select End Date");
                            return false;
                        }

                        if (soiEndHour.Text == "")
                        {
                            soiEndHour.Focus();
                            MPCF.ShowMsgBox("Please Select End Hour");
                            return false;
                        }


                        if (soiEndMin.Text == "")
                        {
                            soiEndMin.Focus();
                            MPCF.ShowMsgBox("Please Select End Minute");
                            return false;
                        }
                        if (Convert.ToInt32(soiEndMin.Text) < Convert.ToInt32(soiStartMin.Text))
                        {
                            soiEndMin.Focus();
                            MPCF.ShowMsgBox("The end time must be greater than the start time.");
                            return false;
                        }

                        if (soiEndSec.Text == "")
                        {
                            soiEndSec.Focus();
                            MPCF.ShowMsgBox("Please Select End Seconds");
                            return false;
                        }

                        if (txtRepTime.Text == "")
                        {
                            soiEndSec.Focus();
                            MPCF.ShowMsgBox("Please check the start/end times");
                            return false;
                        }

						if (Convert.ToInt32(txtRepTime.Text) < 0)
						{
							soiEndSec.Focus();
							MPCF.ShowMsgBox("Please check the start/end times");
							return false;
						}
                        if (Convert.ToInt32(txtRepTime.Text) == 0)
                        {
                            soiEndSec.Focus();
                            MPCF.ShowMsgBox("Please check the start/end times");
                            return false;
                        }


                        if (txtRootCause.Text == "")
                        {
                            txtRootCause.Focus();
                            MPCF.ShowMsgBox("Please enter root cause.");
                            return false;
                        }



                        if (txtIssues.Text == "")
                        {
                            txtIssues.Focus();
                            MPCF.ShowMsgBox("Please enter issues.");
                            return false;
                        }

                        if (txtIssuesDesc.Text == "")
                        {
                            txtIssuesDesc.Focus();
                            MPCF.ShowMsgBox("Please enter issue details.");
                            return false;
                        }

                        if (txtEngTecName.Text == "")
                        {
                            txtEngTecName.Focus();
                            MPCF.ShowMsgBox("Please enter engineer/technician's name.");
                            return false;
                        }
                       

                        if (cboRequest.Text == "")
                        {
                            cboRequest.Focus();
                            MPCF.ShowMsgBox("Please select an option from the dropdown list in Request field.");
                            return false;
                        }

                        if (cboPitchBelt.Text == "")
                        {
                            cboPitchBelt.Focus();
                            MPCF.ShowMsgBox("Please select an option from the dropdown list in Direction field.");
                            return false;
                        }
                        break;
                    case "APPEND":

                        if (cdvMachine.Text == "")
                        {
                            cdvMachine.Focus();
                            MPCF.ShowMsgBox("Please select a machine.");
                            return false;
                        }
                        if (cdvMachineNum.Text == "")
                        {
                            cdvMachineNum.Focus();
                            MPCF.ShowMsgBox("Please select a machine number.");
                            return false;
                        }


                        if (cboPM.Text == "")
                        {
                            cboPM.Focus();
                            MPCF.ShowMsgBox("Please select an option from the dropdown list in Down Type field.");
                            return false;
                        }

                        if (soiStartDate.Text == "")
                        {
                            soiStartDate.Focus();
                            MPCF.ShowMsgBox("Please Select Start Date");
                            return false;
                        }

                        if (soiStartHour.Text == "")
                        {
                            soiStartHour.Focus();
                            MPCF.ShowMsgBox("Please Select Selected Hour");
                            return false;
                        }


                        if (soiStartMin.Text == "")
                        {
                            soiStartMin.Focus();
                            MPCF.ShowMsgBox("Please Select Selected Minute");
                            return false;
                        }

                        if (soiStartSec.Text == "")
                        {
                            soiStartSec.Focus();
                            MPCF.ShowMsgBox("Please Select Selected Seconds");
                            return false;
                        }

                        if (soiEndDate.Text == "")
                        {
                            soiEndDate.Focus();
                            MPCF.ShowMsgBox("Please Select End Date");
                            return false;
                        }

                        if (soiEndHour.Text == "")
                        {
                            soiEndHour.Focus();
                            MPCF.ShowMsgBox("Please Select End Hour");
                            return false;
                        }


                        if (soiEndMin.Text == "")
                        {
                            soiEndMin.Focus();
                            MPCF.ShowMsgBox("Please Select End Minute");
                            return false;
                        }

                        if (Convert.ToInt32(soiEndMin.Text) < Convert.ToInt32(soiStartMin.Text))
                        {
                            soiEndMin.Focus();
                            MPCF.ShowMsgBox("The end time must be greater than the start time.");
                            return false;
                        }
                        if (soiEndSec.Text == "")
                        {
                            soiEndSec.Focus();
                            MPCF.ShowMsgBox("Please Select End Seconds");
                            return false;
                        }

                        if (txtRepTime.Text == "")
                        {
                            soiEndSec.Focus();
                            MPCF.ShowMsgBox("Please check the start/end times");
                            return false;
                        }

						if (Convert.ToInt32(txtRepTime.Text) < 0)
						{
							soiEndSec.Focus();
							MPCF.ShowMsgBox("Please check the start/end times");
							return false;
						}
                        if (Convert.ToInt32(txtRepTime.Text) == 0)
                        {
                            soiEndSec.Focus();
                            MPCF.ShowMsgBox("Please check the start/end times");
                            return false;
                        }




                        if (txtRootCause.Text == "")
                        {
                            txtRootCause.Focus();
                            MPCF.ShowMsgBox("Please enter root cause.");
                            return false;
                        }


                        if (txtIssues.Text == "")
                        {
                            txtIssues.Focus();
                            MPCF.ShowMsgBox("Please enter issues.");
                            return false;
                        }

                        if (txtIssuesDesc.Text == "")
                        {
                            txtIssuesDesc.Focus();
                            MPCF.ShowMsgBox("Please enter issue details.");
                            return false;
                        }

                        if (txtEngTecName.Text == "")
                        {
                            txtEngTecName.Focus();
                            MPCF.ShowMsgBox("Please enter engineer/technician's name.");
                            return false;
                        }


                        if (cboRequest.Text == "")
                        {
                            cboRequest.Focus();
                            MPCF.ShowMsgBox("Please select an option from the dropdown list in Request field.");
                            return false;
                        }

                        if (cboPitchBelt.Text == "")
                        {
                            cboPitchBelt.Focus();
                            MPCF.ShowMsgBox("Please select an option from the dropdown list in Direction field.");
                            return false;
                        }
                        break;

					case "COPY":

						if (cdvMachine.Text == "")
						{
							cdvMachine.Focus();
                            MPCF.ShowMsgBox("Please select a machine.");
							return false;
						}
						if (cdvMachineNum.Text == "")
						{
							cdvMachineNum.Focus();
                            MPCF.ShowMsgBox("Please select a machine number.");
							return false;
						}
                        if (cboPM.Text == "")
                        {
                            cboPM.Focus();
                            MPCF.ShowMsgBox("Please select an option from the dropdown list in Down Type field.");
                            return false;
                        }


						if (soiStartDate.Text == "")
						{
							soiStartDate.Focus();
							MPCF.ShowMsgBox("Please Select Start Date");
							return false;
						}

						if (soiStartHour.Text == "")
						{
							soiStartHour.Focus();
							MPCF.ShowMsgBox("Please Select Selected Hour");
							return false;
						}

						if (soiStartHour.Text == "05" || soiStartHour.Text == "17")
						{
							soiStartHour.Focus();
							MPCF.ShowMsgBox("Copying is not possible at 05:00 and 17:00.");
							return false;
						}


						if (soiStartMin.Text == "")
						{
							soiStartMin.Focus();
							MPCF.ShowMsgBox("Please Select Selected Minute");
							return false;
						}

						if (soiStartSec.Text == "")
						{
							soiStartSec.Focus();
							MPCF.ShowMsgBox("Please Select Selected Seconds");
							return false;
						}

						if (soiEndDate.Text == "")
						{
							soiEndDate.Focus();
							MPCF.ShowMsgBox("Please Select End Date");
							return false;
						}

						if (soiEndHour.Text == "")
						{
							soiEndHour.Focus();
							MPCF.ShowMsgBox("Please Select End Hour");
							return false;
						}


						if (soiEndMin.Text == "")
						{
							soiEndMin.Focus();
							MPCF.ShowMsgBox("Please Select End Minute");
							return false;
						}

                        if (Convert.ToInt32(soiEndMin.Text) < Convert.ToInt32(soiStartMin.Text))
                        {
                            soiEndMin.Focus();
                            MPCF.ShowMsgBox("The end time must be greater than the start time.");
                            return false;
                        }
						if (soiEndSec.Text == "")
						{
							soiEndSec.Focus();
							MPCF.ShowMsgBox("Please Select End Seconds");
							return false;
						}

						if (txtRepTime.Text == "")
						{
							soiEndSec.Focus();
							MPCF.ShowMsgBox("Please check the start/end times");
							return false;
						}

						if (Convert.ToInt32(txtRepTime.Text) < 0)
						{
							soiEndSec.Focus();
							MPCF.ShowMsgBox("Please check the start/end times");
							return false;
						}
						if (Convert.ToInt32(txtRepTime.Text) == 0)
						{
							soiEndSec.Focus();
							MPCF.ShowMsgBox("Please check the start/end times");
							return false;
						}




						if (txtRootCause.Text == "")
						{
							txtRootCause.Focus();
                            MPCF.ShowMsgBox("Please enter root cause.");
							return false;
						}


						if (txtIssues.Text == "")
						{
							txtIssues.Focus();
                            MPCF.ShowMsgBox("Please enter issues.");
							return false;
						}

						if (txtIssuesDesc.Text == "")
						{
							txtIssuesDesc.Focus();
                            MPCF.ShowMsgBox("Please enter issue details.");
							return false;
						}

						if (txtEngTecName.Text == "")
						{
							txtEngTecName.Focus();
                            MPCF.ShowMsgBox("Please enter engineer/technician's name.");
							return false;
						}

                        if (cboRequest.Text == "")
                        {
                            cboRequest.Focus();
                            MPCF.ShowMsgBox("Please select an option from the dropdown list in Request field.");
                            return false;
                        }

                        if (cboPitchBelt.Text == "")
                        {
                            cboPitchBelt.Focus();
                            MPCF.ShowMsgBox("Please select an option from the dropdown list in Direction field.");
                            return false;
                        }
						break;

                    case "DELETE":

                        if (spdWorklog.Sheets[0].SelectionCount < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(568));
                            return false;
                        }

                        if (txtSEQ.Text == "")
                        {
                            txtSEQ.Focus();
                            MPCF.ShowMsgBox("Please Select Item");
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
        
        private bool ViewEQWorklogList()
        {
            try
            {
                int i;
            

                chk_type = "";

                DateTime dtpFromDateTimeOut = new DateTime();
              
                MPCF.ClearList(spdWorklog);

                TRSNode in_node = new TRSNode("VIEW_EQ_WORKLOG_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_EQ_WORKLOG_LIST_OUT");
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
                in_node.AddString("WORK_SHIFT", MPCF.Trim(cboShift.Text));
                in_node.AddString("HOUR_TYPE", MPCF.Trim(cdvType.Text));

                if (MPCF.CallService("CRAS", "CRAS_View_equipment_work_log_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                spdWorklog.ActiveSheet.RowCount = 0;
           
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];
                    spdWorklog.ActiveSheet.RowCount++;

                    spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.WORK_SHIFT].Value = out_list.GetString("WORK_SHIFT");
                    spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.WORK_TIME].Value = out_list.GetString("WORK_TIME");
                    spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.HIST_SEQ].Value = out_list.GetInt("HIST_SEQ");
                    if (out_list.GetInt("HIST_SEQ") == 0)
                    {
                        chk_type = "C";
                    }
                    
                    else
                    {
                        chk_type = "U";
                    }

                    spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.MACHINE].Value = out_list.GetString("MACHINE");
                    spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.MACHINE_NUMBER].Value = out_list.GetString("MACHINE_NUMBER");
                    spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.PM].Value = out_list.GetString("PM");

                    spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.START_TIME].Value = out_list.GetString("START_TIME");
                    spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.END_TIME].Value = out_list.GetString("END_TIME");
                    
                    spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.REPAIR_TIME].Value = out_list.GetString("REPAIR_TIME");
                    spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.ISSUES].Value = out_list.GetString("ISSUES");
                    spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.ISSUES_DETAILS].Value = out_list.GetString("ISSUES_DETAILS");
                    spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.ROOT_CAUSES].Value = out_list.GetString("ROOT_CAUSES");
                    spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.PART_REPLACEMENT].Value = out_list.GetString("PART_REPLACEMENT");
                    spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.PART_REPLACEMENT_QUANTITIES].Value = MPCF.MakeNumberFormat(out_list.GetInt("PART_REPLACEMENT_QUANTITIES"), 0);
                    spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.ENG_TEC_NAME].Value = out_list.GetString("ENG_TEC_NAME");  //IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog  
                    spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.REQUEST].Value = out_list.GetString("REQUEST");
                    spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.REQUEST_DESC].Value = out_list.GetString("REQUEST_DESC");
                    spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.PITCHBELT].Value = out_list.GetString("PITCHBELT");
                    spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.PITCHBELT_DESC].Value = out_list.GetString("PITCHBELT_DESC");
                }

                if (chk_type == "C")
                {
                    set_create();
                }
                if(chk_type == "U")
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

        private bool UpdateEQWorklog(char ProcStep)
        {
            try
            {
                int i;
    
                TRSNode work_list = null;

                DateTime dtpScrapDateTimeOut = new DateTime();

                TRSNode in_node = new TRSNode("UPDATE_EQ_WORKLOG_LIST_IN");
                TRSNode out_node = new TRSNode("UPDATE_EQ_WORKLOG_LIST_OUT");

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
                    for (i = 0; i < spdWorklog.Sheets[0].Rows.Count; i++)
                    {
                        work_list = in_node.AddNode("TRAN_LIST");
                        work_list.AddString("WORK_SHIFT", spdWorklog.ActiveSheet.Cells[i,  (int)EQUIPMENT_WORKLOG_LIST.WORK_SHIFT].Value);
                        work_list.AddString("WORK_TIME", spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.WORK_TIME].Value);
                        work_list.AddInt("HIST_SEQ", Convert.ToInt32(spdWorklog.ActiveSheet.Cells[i,  (int)EQUIPMENT_WORKLOG_LIST.HIST_SEQ].Text.Replace(",", "")));
                        work_list.AddString("MACHINE", spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.MACHINE].Value);
                        work_list.AddString("MACHINE_NUMBER", spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.MACHINE_NUMBER].Value);
                        work_list.AddString("PM", spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.PM].Value);
                        work_list.AddString("START_TIME", spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.START_TIME].Value);
                        work_list.AddString("END_TIME", spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.END_TIME].Value);
                        work_list.AddString("REPAIR_TIME", spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.REPAIR_TIME].Value);
                        work_list.AddString("ISSUES", spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.ISSUES].Value);
                        work_list.AddString("ISSUES_DETAILS", spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.ISSUES_DETAILS].Value);
                        work_list.AddString("ROOT_CAUSES", spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.ROOT_CAUSES].Value);
                        work_list.AddString("PART_REPLACEMENT", spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.PART_REPLACEMENT].Value);
                        work_list.AddString("ENG_TEC_NAME", spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.ENG_TEC_NAME].Value);//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
                        work_list.AddString("REQUEST", spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.REQUEST].Value);
                        work_list.AddString("PITCHBELT", spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.PITCHBELT].Value);
                        work_list.AddInt("PART_REPLACEMENT_QUANTITIES", Convert.ToInt32(spdWorklog.ActiveSheet.Cells[i, (int)EQUIPMENT_WORKLOG_LIST.PART_REPLACEMENT_QUANTITIES].Text.Replace(",", "")));

                    }
                }   
                else if (ProcStep == 'A')  //append 
                {
                    work_list = in_node.AddNode("TRAN_LIST");

                    // soiStartDate
                    //string strStartTime = soiStartDate.Text.Replace("-","") + soiStartHour.Text + soiStartMin.Text + soiStartSec.Text;
                    //string strEndTime = soiEndDate.Text.Replace("-","") + soiEndHour.Text + soiEndMin.Text + soiEndSec.Text;
					DateTime dtStartDateout = DateTime.Now;
					DateTime dtEndDateout = DateTime.Now;

					if (soiStartDate.Value != null)
					{
						bool bTrySuccess = DateTime.TryParse(soiStartDate.Value.ToString(), out dtStartDateout);
						if (bTrySuccess == true)
						{
							//in_node.AddString("FROM_TIME", dtStartDateout.ToString("yyyyMMdd"));
						}
					}
					if (soiEndDate.Value != null)
					{
						bool bTrySuccess = DateTime.TryParse(soiEndDate.Value.ToString(), out dtEndDateout);
						if (bTrySuccess == true)
						{
							//in_node.AddString("TO_TIME", dtEndDateout.ToString("yyyyMMdd"));
						}
					}

					string strStartTime = dtStartDateout.ToString("yyyyMMdd") + soiStartHour.Text + soiStartMin.Text + soiStartSec.Text;
					string strEndTime = dtEndDateout.ToString("yyyyMMdd") + soiEndHour.Text + soiEndMin.Text + soiEndSec.Text;
                    //work_list.AddString("LOGIN_GROUP", MPGV.gsUserGroup);
                    work_list.AddString("LOGIN_USER", MPGV.gsUserID);
                    work_list.AddString("WORK_TIME", txtTime.Text);
                    work_list.AddString("MACHINE", cdvMachine.Text);
                    work_list.AddString("MACHINE_NUMBER", cdvMachineNum.Text);
                    work_list.AddString("PM", cboPM.Value);
                    work_list.AddString("START_TIME", strStartTime);
                    work_list.AddString("END_TIME", strEndTime);
                    work_list.AddString("REPAIR_TIME", txtRepTime.Text);
                    work_list.AddString("ISSUES", txtIssues.Text);
                    work_list.AddString("ISSUES_DETAILS", txtIssuesDesc.Text);
                    work_list.AddString("ROOT_CAUSES", txtRootCause.Text);
                    work_list.AddString("PART_REPLACEMENT", txtRepParts.Text);
                    work_list.AddString("ENG_TEC_NAME", txtEngTecName.Text);//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
                    work_list.AddString("REQUEST", cboRequest.Value);//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
                    work_list.AddString("PITCHBELT", cboPitchBelt.Value);//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
                    work_list.AddInt("PART_REPLACEMENT_QUANTITIES", Convert.ToInt32(txtRepQuant.Text.Replace(",", "")));
                }
				// IS-21-08-024 [프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
				else if (ProcStep == 'C')  //append or copy
				{
					work_list = in_node.AddNode("TRAN_LIST");


                    // soiStartDate
                    //string strStartTime = soiStartDate.Text.Replace("-","") + soiStartHour.Text + soiStartMin.Text + soiStartSec.Text;
                    //string strEndTime = soiEndDate.Text.Replace("-","") + soiEndHour.Text + soiEndMin.Text + soiEndSec.Text;
                    DateTime dtStartDateout = DateTime.Now;
                    DateTime dtEndDateout = DateTime.Now;

                    if (soiStartDate.Value != null)
                    {
                        bool bTrySuccess = DateTime.TryParse(soiStartDate.Value.ToString(), out dtStartDateout);
                        if (bTrySuccess == true)
                        {
                            //in_node.AddString("FROM_TIME", dtStartDateout.ToString("yyyyMMdd"));
                        }
                    }
                    if (soiEndDate.Value != null)
                    {
                        bool bTrySuccess = DateTime.TryParse(soiEndDate.Value.ToString(), out dtEndDateout);
                        if (bTrySuccess == true)
                        {
                            //in_node.AddString("TO_TIME", dtEndDateout.ToString("yyyyMMdd"));
                        }
                    }


                    int nTimeCheck = dtStartDateout.Hour;

					int nWorkTimePlus=0;
					int nStartTimePlus = 0;
					int nEndTimePlus = 0;
					Int32.TryParse(txtTime.Text, out nWorkTimePlus);
					Int32.TryParse(txtTime.Text, out nStartTimePlus);
					Int32.TryParse(txtTime.Text, out nEndTimePlus);
					/*
					string strWorkTimePlus = string.Format("{0:D2}", nWorkTimePlus+1);
					string strStartTimePlus = string.Format("{0:D2}", nStartTimePlus + 1);
					string strEndTimePlus = string.Format("{0:D2}", nEndTimePlus + 1);
					*/

					string strWorkTimePlus ="";
                    string strStartTimePlus = "";
                    string strEndTimePlus = "";

                    if (nTimeCheck == 23)
                    {
                        dtStartDateout = dtStartDateout.AddDays(1);
                        dtEndDateout = dtEndDateout.AddDays(1);
                        strWorkTimePlus = "00";
                        strStartTimePlus = "00";
                        strEndTimePlus = "00";
                    }
                    else
                    {
                        strWorkTimePlus = string.Format("{0:D2}", nWorkTimePlus + 1);
                        strStartTimePlus = string.Format("{0:D2}", nStartTimePlus + 1);
                        strEndTimePlus = string.Format("{0:D2}", nEndTimePlus + 1);
                    }

                    string strStartTime = dtStartDateout.ToString("yyyyMMdd") + strStartTimePlus + soiStartMin.Text + soiStartSec.Text;
                    string strEndTime = dtEndDateout.ToString("yyyyMMdd") + strEndTimePlus + soiEndMin.Text + soiEndSec.Text;


					//work_list.AddString("LOGIN_GROUP", MPGV.gsUserGroup);
					work_list.AddString("LOGIN_USER", MPGV.gsUserID);
					work_list.AddString("WORK_TIME", strWorkTimePlus);
					work_list.AddString("MACHINE", cdvMachine.Text);
					work_list.AddString("MACHINE_NUMBER", cdvMachineNum.Text);
                    work_list.AddString("PM", cboPM.Value);
                    work_list.AddString("START_TIME", strStartTime);
                    work_list.AddString("END_TIME", strEndTime);
					work_list.AddString("REPAIR_TIME", txtRepTime.Text);
					work_list.AddString("ISSUES", txtIssues.Text);
					work_list.AddString("ISSUES_DETAILS", txtIssuesDesc.Text);
					work_list.AddString("ROOT_CAUSES", txtRootCause.Text);
					work_list.AddString("PART_REPLACEMENT", txtRepParts.Text);
					work_list.AddString("ENG_TEC_NAME", txtEngTecName.Text);//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
                    work_list.AddString("REQUEST", cboRequest.Value);
                    work_list.AddString("PITCHBELT", cboPitchBelt.Value); 
                    work_list.AddInt("PART_REPLACEMENT_QUANTITIES", Convert.ToInt32(txtRepQuant.Text.Replace(",", "")));
				}
                else if (ProcStep == 'U')  //UPDATE
                {
                    work_list = in_node.AddNode("TRAN_LIST");

                    // soiStartDate
                    //string strStartTime = soiStartDate.Text.Replace("-", "") + soiStartHour.Text + soiStartMin.Text + soiStartSec.Text;
                    //string strEndTime = soiEndDate.Text.Replace("-", "") + soiEndHour.Text + soiEndMin.Text + soiEndSec.Text;
					DateTime dtStartDateout = DateTime.Now;
					DateTime dtEndDateout = DateTime.Now;

					if (soiStartDate.Value != null)
					{
						bool bTrySuccess = DateTime.TryParse(soiStartDate.Value.ToString(), out dtStartDateout);
						if (bTrySuccess == true)
						{
							//in_node.AddString("FROM_TIME", dtStartDateout.ToString("yyyyMMdd"));
						}
					}
					if (soiEndDate.Value != null)
					{
						bool bTrySuccess = DateTime.TryParse(soiEndDate.Value.ToString(), out dtEndDateout);
						if (bTrySuccess == true)
						{
							//in_node.AddString("TO_TIME", dtEndDateout.ToString("yyyyMMdd"));
						}
					}

					string strStartTime = dtStartDateout.ToString("yyyyMMdd") + soiStartHour.Text + soiStartMin.Text + soiStartSec.Text;
					string strEndTime = dtEndDateout.ToString("yyyyMMdd") + soiEndHour.Text + soiEndMin.Text + soiEndSec.Text;

                    //work_list.AddString("LOGIN_GROUP", MPGV.gsUserGroup);
                    
                    work_list.AddString("LOGIN_USER", MPGV.gsUserID);
                    work_list.AddString("WORK_TIME", txtTime.Text);
                    work_list.AddString("MACHINE", cdvMachine.Text);
                    work_list.AddString("MACHINE_NUMBER", cdvMachineNum.Text);
                    work_list.AddString("PM", cboPM.Value);
                    work_list.AddString("START_TIME", strStartTime);
                    work_list.AddString("END_TIME", strEndTime);
					work_list.AddString("REPAIR_TIME", txtRepTime.Text);
                    work_list.AddString("ISSUES", txtIssues.Text);
                    work_list.AddString("ISSUES_DETAILS", txtIssuesDesc.Text);
                    work_list.AddString("ROOT_CAUSES", txtRootCause.Text);
                    work_list.AddString("PART_REPLACEMENT", txtRepParts.Text);
                    work_list.AddInt("PART_REPLACEMENT_QUANTITIES", Convert.ToInt32(txtRepQuant.Text.Replace(",", "")));
                    work_list.AddString("ENG_TEC_NAME", txtEngTecName.Text);//IS-21-08-024	[프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
                    work_list.AddString("REQUEST", cboRequest.Value);
                    work_list.AddString("PITCHBELT", cboPitchBelt.Value); 
                    work_list.AddInt("HIST_SEQ", Convert.ToInt32(txtSEQ.Text.Replace(",", "")));
                }
                else if (ProcStep == 'D')  //DELETE
                {
                    work_list = in_node.AddNode("TRAN_LIST");
                    work_list.AddString("WORK_TIME", txtTime.Text);
                    work_list.AddInt("HIST_SEQ", txtSEQ.Text.Replace(",", ""));

                }
                if (MPCF.CallService("CRAS", "CRAS_Update_equipment_work_log", in_node, ref out_node) == false)
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


        private void cdvMachine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                cdvMachineNum.Text = "";
                cdvMachineNum.Description = "";

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@EQ_WORKLOG_MACHINE"));
                in_node.AddString("KEY_2", MPCF.Trim(cdvType.Text));

                string[] header = new string[] { "Process", "Type", "Machine" };
                string[] display = new string[] { "KEY_1", "KEY_2", "KEY_3" };


                cdvMachine.Text = cdvMachine.Show(cdvMachine, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_3");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvMachineNum_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (cdvMachine.Text == "")
                {
                    cdvMachine.Focus();
                    MPCF.ShowMsgBox("Please Selected Machine");
                    return;

                }

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@EQ_WORKLOG_MC_NUM"));
                in_node.AddString("KEY_1", MPCF.Trim(cdvMachine.Text));



                string[] header = new string[] { "Machine", "MachineNum" };
                string[] display = new string[] { "KEY_1", "DATA_1" };



                cdvMachineNum.Text = cdvMachineNum.Show(cdvMachineNum, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "DATA_1");



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
                

                if (UpdateEQWorklog(MPGC.MP_STEP_APPROVAL) == false)
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
            getShiftList();
            set_view();
        }

        private void dtpDate_TextChanged(object sender, EventArgs e)
        {
            set_view();
        }

        private void cdvLineID_ValueChanged(object sender, EventArgs e)
        {
            set_view();
        }


        private void cdvType_ValueChanged(object sender, EventArgs e)
        {
            set_view();
            
        }
        private void cboShift_ValueChanged(object sender, EventArgs e)
        {
            set_view();
        }
        private void cdvMachine_ValueChanged(object sender, EventArgs e)
        {
            cdvMachineNum.Enabled = true;
        }

        private void soiStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (soiStartDateLoadflag == false)
            {
                calculate_repair_time();
            }
            else
            {
                soiStartDateLoadflag = false;
            }

        }

        private void soiStartHour_ValueChanged(object sender, EventArgs e)
        {
            calculate_repair_time();
        }

        private void soiStartMin_ValueChanged(object sender, EventArgs e)
        {
            calculate_repair_time();
        }

        private void soiStartSec_ValueChanged(object sender, EventArgs e)
        {
            calculate_repair_time();
        }

        private void soiEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (soiEndDateLoadflag == false)
            {
                calculate_repair_time();
            }
            else
            {
                soiEndDateLoadflag = false;
            }

        }

        private void soiEndHour_ValueChanged(object sender, EventArgs e)
        {
            calculate_repair_time();
        }

        private void soiEndMin_ValueChanged(object sender, EventArgs e)
        {
            calculate_repair_time();
        }
        private void soiEndSec_ValueChanged(object sender, EventArgs e)
        {
            calculate_repair_time();
        }

        private void cdvMachine_Load(object sender, EventArgs e)
        {

        }

		// IS-21-08-024 [프로그램변경]MES OI Client 수정 개발 - Equipment Worklog
		private void btnCOPY_Click(object sender, EventArgs e)
		{
			try
			{
				if (CheckCondition("COPY") == false)
				{
					return;
				}

				if (UpdateEQWorklog(MPGC.MP_STEP_COPY) == false)
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


    }
}
