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
    public partial class frmCUSTabberCleanMngV1 : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private string m_strTransactionMode = "N";
        private Color m_clrSelectedCellBackground;

        private String[] CONST_DAY_SHIFT = { "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17" };
        private String[] CONST_NIGHT_SHIFT = { "18", "19", "20", "21", "22", "23", "00", "01", "02", "03", "04", "05" };

        #endregion

        #region Constructor

        public frmCUSTabberCleanMngV1()
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
            CLNG_DATE,
            WORK_LINE,
            SHIFT,
            TIME,
            TABBER,
            CLNG_TYPE,
            CLNG_TYPE_NM,
            COMMENTS,
            DEPARTMENT,
            RQST_DPMT_NM,
            CLNG_PLAN,
            CLNG_PLAN_NM,
            USER,
        }

        #endregion

        #region [Variable Definition]

        #endregion

        #region Event Handler



        private void frmCUSTabberCleanMngV1_Load(object sender, EventArgs e)
        {
            // Init
            dtpDate.Value = DateTime.Now;
            dtpCleaningDate.Value = DateTime.Now;

            chk_auto_validation = "";
            chk_auto = "";

            spdData.ActiveSheet.RowCount = 0;
            set_view();

            getLineLocationList();

            spdData.ActiveSheet.ColumnHeader.Rows[0].Height = 60;
            MPCF.ConvertCaption(this);
        }

        private void cdvLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cboLineLocation, false) == false)
            {
                MPCF.SetFocus(cboLineLocation);
                MPCF.ShowMessage("Factory No. is required.", MSG_LEVEL.ERROR, false);
                return;
            }

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

                cdvLineID.Text = cdvLineID.Show(cdvLineID, "Work Line", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");
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

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
          
        private void set_view()
        {
            txt_clear();

            if (spdData.ActiveSheet.ActiveRow == null || spdData.ActiveSheet.RowCount <= 0 )
            {
                setEditComponentDisable(false);
                setCommandModeCreate(true);
                return;
            }

            int row = spdData.ActiveSheet.ActiveRow.Index;
            if (spdData.ActiveSheet.Cells[row, (int)DATA_LIST.CLNG_DATE].Value == null ||
                spdData.ActiveSheet.Cells[row, (int)DATA_LIST.WORK_LINE].Value == null )
            {
                return;
            }

            dtpCleaningDate.Value = MPCF.ToDate(spdData.ActiveSheet.Cells[row, (int)DATA_LIST.CLNG_DATE].Value.ToString());
            cdvLineID2.Text = spdData.ActiveSheet.Cells[row, (int)DATA_LIST.WORK_LINE].Value.ToString();
            cdvTabber.Text = spdData.ActiveSheet.Cells[row, (int)DATA_LIST.TABBER].Value.ToString();
            cboShift.Text = spdData.ActiveSheet.Cells[row, (int)DATA_LIST.SHIFT].Value.ToString();
            cdvCleaningType.Text = spdData.ActiveSheet.Cells[row, (int)DATA_LIST.CLNG_TYPE].Value.ToString();
            cdvCleaningType.Description = spdData.ActiveSheet.Cells[row, (int)DATA_LIST.CLNG_TYPE_NM].Value.ToString();
            cdvDepartment.Text = spdData.ActiveSheet.Cells[row, (int)DATA_LIST.DEPARTMENT].Value.ToString();
            cdvDepartment.Description = spdData.ActiveSheet.Cells[row, (int)DATA_LIST.RQST_DPMT_NM].Value.ToString();
            if (spdData.ActiveSheet.Cells[row, (int)DATA_LIST.TIME].Value.ToString().Length > 4)
            {
                soiHour.Text = spdData.ActiveSheet.Cells[row, (int)DATA_LIST.TIME].Value.ToString().Substring(0, 2);
                soiMin.Text = spdData.ActiveSheet.Cells[row, (int)DATA_LIST.TIME].Value.ToString().Substring(3, 2);
            }
            rdoScheduled.Value = spdData.ActiveSheet.Cells[row, (int)DATA_LIST.CLNG_PLAN].Value.ToString();
            txtComments.Text = spdData.ActiveSheet.Cells[row, (int)DATA_LIST.COMMENTS].Value.ToString();

            if (spdData.ActiveSheet.Cells[row, (int)DATA_LIST.CLNG_PLAN].Value.Equals("Y"))
            {
                rdoScheduled.Value = 1;
            }
            else
            {
                rdoScheduled.Value = 2;
            }
            setEditComponentDisable(true);
            setCommandModeCreate(false);
        }

        private void setEditComponentDisable(bool bDIsable)
        {

            dtpCleaningDate.Enabled = !bDIsable;
            cdvLineID2.Enabled = !bDIsable;
            cdvTabber.Enabled = !bDIsable;
            cboShift.Enabled = !bDIsable;
            soiHour.Enabled = !bDIsable;
            soiMin.Enabled = !bDIsable; 
        }
        
        private void setCommandModeCreate(bool bModeCreate)
        {
            btnProcess.Enabled = bModeCreate;
            btnUpdate.Enabled = !bModeCreate;
            btnDelete.Enabled = !bModeCreate;             
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

        private void txt_clear()
        {
            cdvLineID2.Text = "";
            cdvLineID2.Description = "";
            cdvTabber.Text = "";
            cdvTabber.Description = "";
            cboShift.Text = "";
            cboShift.Value = "";
            cdvCleaningType.Text = "";
            cdvCleaningType.Description = "";
            cdvDepartment.Text = "";
            cdvDepartment.Description = "";
            txtComments.Text = "";
            soiMin.SelectedIndex = 0;

        }

        private void txt_clear2()
        {
            //lblcol.Text = "";
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            txt_clear();

            setEditComponentDisable(false);

            setCommandModeCreate(true);
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
                 
                 
                if (ViewList() == false)
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

                if (UpdateData(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }

                txt_clear();
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

                if (CheckCondition("UPDATE") == false)
                {
                    return;
                }

                if (UpdateData(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }


                // Refresh
                txt_clear();
                btnView.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox("Do you want to delete?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            if (UpdateData(MPGC.MP_STEP_DELETE) == false)
            {
                return;
            }
            // Refresh
            txt_clear();
            btnView.PerformClick();
        }


        private void spdData_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

        }

        private void dtpCleaningDate_ValueChanged(object sender, EventArgs e)
        {
            getShiftList();
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
                        if (MPCF.CheckValue(dtpCleaningDate, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvLineID2, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvTabber, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cboShift, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvCleaningType, false) == false)
                        {
                            return false;
                        } 

                        if (MPCF.CheckValue(cdvDepartment, false) == false)
                        {
                            return false;
                        } 
                        if (MPCF.CheckValue(soiHour, false) == false)
                        {
                            return false;
                        }
                        if (checkDuplication() == true)
                        {
                            MPCF.ShowMessage("Duplicate entry. Please check and enter different cleaning time data.", MSG_LEVEL.ERROR, false);
                            return false;
                        }
                        break;

                    case "VIEW":
                        if (MPCF.CheckValue(dtpDate, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cboLineLocation, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvLineID, false) == false)
                        {
                            return false;
                        }

                        break;

                    case "UPDATE":
                        if (MPCF.CheckValue(dtpCleaningDate, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvLineID2, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvTabber, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cboShift, false) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvCleaningType, false) == false)
                        {
                            return false;
                        } 

                        if (MPCF.CheckValue(cdvDepartment, false) == false)
                        {
                            return false;
                        } 
                        if (MPCF.CheckValue(soiHour, false) == false)
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

        private bool checkDuplication()
        {
            DateTime dtpFromDateTimeOut = new DateTime();

            for (int row = 0; row < spdData.ActiveSheet.RowCount; row++)
            {
                if (dtpCleaningDate.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpCleaningDate.Value.ToString(), out dtpFromDateTimeOut);
                    if (bTrySuccess == true && 
                        dtpFromDateTimeOut.ToString("yyyyMMdd") != spdData.ActiveSheet.Cells[row, (int)DATA_LIST.CLNG_DATE].Value.ToString())
                    {
                        continue;
                    }
                }


                if (cdvLineID2.Text != spdData.ActiveSheet.Cells[row, (int)DATA_LIST.WORK_LINE].Value.ToString())
                {

                    continue;
                }
                if (cdvTabber.Text != spdData.ActiveSheet.Cells[row, (int)DATA_LIST.TABBER].Value.ToString())
                {
                    continue;
                }
                if (cboShift.Text != spdData.ActiveSheet.Cells[row, (int)DATA_LIST.SHIFT].Value.ToString())
                {
                    continue;
                }
                if (soiHour.Text + soiMin.Text != spdData.ActiveSheet.Cells[row, (int)DATA_LIST.TIME].Value.ToString().Substring(0, 2) +
                                   spdData.ActiveSheet.Cells[row, (int)DATA_LIST.TIME].Value.ToString().Substring(3, 2))
                {
                    continue;
                }
                return true;
            }

            return false;
        }

        private bool ViewList()
        {
            try
            {
                int i;


                chk_type = "";

                DateTime dtpFromDateTimeOut = new DateTime();

                MPCF.ClearList(spdData);

                TRSNode in_node = new TRSNode("LIST_IN");
                TRSNode out_node = new TRSNode("LIST_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (dtpDate.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpDate.Value.ToString(), out dtpFromDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("CLNG_DATE", dtpFromDateTimeOut.ToString("yyyyMMdd"));
                    }
                }
                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("FACTORY_NO", MPCF.Trim(cboLineLocation.Value));
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
                in_node.AddString("CLNG_DATE", MPCF.Trim(dtpDate.Value));

                if (MPCF.CallService("CWIP", "CWIP_View_Tb_Cleaning_Schedule_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                txt_clear();

                spdData.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];
                    spdData.ActiveSheet.RowCount++;

                    spdData.ActiveSheet.Cells[i, (int)DATA_LIST.CLNG_DATE].Value = out_list.GetString("CLNG_DATE");
                    spdData.ActiveSheet.Cells[i, (int)DATA_LIST.WORK_LINE].Value = out_list.GetString("LINE_ID");
                    spdData.ActiveSheet.Cells[i, (int)DATA_LIST.SHIFT].Value = out_list.GetString("WORK_SHIFT");
                    spdData.ActiveSheet.Cells[i, (int)DATA_LIST.TABBER].Value = out_list.GetString("RES_ID");
                    if (out_list.GetString("CLNG_TIME").Length == 4)
                    {
                        spdData.ActiveSheet.Cells[i, (int)DATA_LIST.TIME].Value = out_list.GetString("CLNG_TIME").Substring(0, 2) + ":" + out_list.GetString("CLNG_TIME").Substring(2, 2);
                    }
                    spdData.ActiveSheet.Cells[i, (int)DATA_LIST.CLNG_TYPE].Value = out_list.GetString("CLNG_TYPE");
                    spdData.ActiveSheet.Cells[i, (int)DATA_LIST.CLNG_TYPE_NM].Value = out_list.GetString("CLNG_TYPE_NM");
                    spdData.ActiveSheet.Cells[i, (int)DATA_LIST.COMMENTS].Value = out_list.GetString("CLNG_CMMT");

                    spdData.ActiveSheet.Cells[i, (int)DATA_LIST.DEPARTMENT].Value = out_list.GetString("RQST_DPMT");
                    spdData.ActiveSheet.Cells[i, (int)DATA_LIST.RQST_DPMT_NM].Value = out_list.GetString("RQST_DPMT_NM");
                    spdData.ActiveSheet.Cells[i, (int)DATA_LIST.CLNG_PLAN].Value = out_list.GetString("CLNG_PLAN");
                    if (out_list.GetString("CLNG_PLAN").Equals("Y"))
                    {
                        spdData.ActiveSheet.Cells[i, (int)DATA_LIST.CLNG_PLAN_NM].Value = "Scheduled";
                    }
                    else
                    {
                        spdData.ActiveSheet.Cells[i, (int)DATA_LIST.CLNG_PLAN_NM].Value = "UnScheduled";
                    }
                    spdData.ActiveSheet.Cells[i, (int)DATA_LIST.USER].Value = out_list.GetString("CREATE_USER_ID");


                }
                set_view();
                if (spdData.ActiveSheet.RowCount > 0)
                {
                    spdData.ActiveSheet.SetActiveCell(0, 0);
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
            try
            {
                int i;

                TRSNode work_list = null;

                DateTime dtpScrapDateTimeOut = new DateTime();

                TRSNode in_node = new TRSNode("TB_CLNG_LIST_IN");
                TRSNode out_node = new TRSNode("TB_CLNG_LIST_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("FACTORY", MPGV.gsFactory);

                //header
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID2.Text));
                in_node.AddString("WORK_SHIFT", MPCF.Trim(cboShift.Text));
                in_node.AddString("RES_ID", cdvTabber.Text);

                //detail
                if (dtpDate.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpCleaningDate.Value.ToString(), out dtpScrapDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("CLNG_DATE", dtpScrapDateTimeOut.ToString("yyyyMMdd"));
                    }
                }
                in_node.AddString("CLNG_TIME", soiHour.Text + soiMin.Text );
                in_node.AddString("CLNG_TYPE", cdvCleaningType.Text );
                in_node.AddString("RQST_DPMT", cdvDepartment.Text);
                if (rdoScheduled.Value == "1")
                {
                    in_node.AddString("CLNG_PLAN", "Y");
                }
                else
                {
                    in_node.AddString("CLNG_PLAN", "N");
                }
                in_node.AddString("CLNG_CMMT", txtComments.Text);

                if (MPCF.CallService("CWIP", "CWIP_Update_Tb_Cleaning_Schedule", in_node, ref out_node) == false)
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
                    in_node.AddString("SYS_DATE", ((DateTime)(dtpCleaningDate.Value)).ToString("yyyyMMdd"));
                }

                int i;
                if (MPCF.CallService("CBAS", "CBAS_View_Shift_List", in_node, ref out_node) == true)
                {
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        out_list = out_node.GetList(0)[i];

                        cboShift.Items.Add(out_list.GetString("SHIFT"), out_list.GetString("SHIFT"));
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
        #endregion
         

        private void pnlScrapInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (cdvLineID.Text.Length > 0 && cboLineLocation.Text.Length > 0)
            {
                txt_clear();
                btnView.PerformClick();
            }
            else
            {
                set_view();
            }
        }


        private void cdvType_ValueChanged(object sender, EventArgs e)
        {
            set_view();

        }

        private void txtMin_ValueChanged(object sender, EventArgs e)
        {
            int result;
        }

        private void cdvTabber_CodeViewButtonClick(object sender, EventArgs e)
        {
            //view클릭시 모든 태버를 가져오므로 선택이 필요없어서 비활성화(2025/06/19)
            try
            {
                if (MPCF.CheckValue(cdvLineID, false) == false)
                {
                    return;
                }
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = 'F';
                in_node.AddString("TABLE_NAME", "@E10_EQP");
                in_node.AddString("KEY_1", "TABBER");
                in_node.AddString("KEY_2", MPCF.Trim(cboLineLocation.Value));
                in_node.AddString("KEY_3", MPCF.Trim(cdvLineID2.Text));

                string[] header = new string[] { "Line ID", "Tabber EQ ID" };
                string[] display = new string[] { "KEY_3", "KEY_4" };
                cdvTabber.Text = cdvTabber.Show(cdvTabber, "Tabber EQ", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_4");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvLineID2_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                cdvTabber.ResetText();

                TRSNode in_node = new TRSNode("VIEW_LINE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));
                in_node.AddString("LINE_LOCATION", cboLineLocation.Value);

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvLineID2.Text = cdvLineID2.Show(cdvLineID2, "Work Line", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvCleaningType_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = 'G';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_TBCLN_CLNG_TYP_LINE));
                in_node.AddString("KEY_1", cboLineLocation.Value);

                string[] header = new string[] { "Type Code", "Description" };
                string[] display = new string[] { "KEY_2", "DATA_1" };

                cdvCleaningType.Text = cdvCleaningType.Show(cdvCleaningType, "Cleaning Type", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_2");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvDepartment_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = 'G';
                in_node.AddString("TABLE_NAME", "@DEPT_CODE_LINE");
                in_node.AddString("KEY_1", cboLineLocation.Value);

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_2", "DATA_1" };

                cdvDepartment.Text = cdvDepartment.Show(cdvDepartment, "Requested Department", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_2");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }

        }

        private void spdData_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            set_view();
        }

        private void soiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void cdvDepartment_Load(object sender, EventArgs e)
        {

        }

        private void cboShift_SelectionChanged(object sender, EventArgs e)
        {
            soiHour.Items.Clear();
            if (((SOI.OIFrx.SOIControls.SOIComboBox)sender).Text == "A" ||
                ((SOI.OIFrx.SOIControls.SOIComboBox)sender).Text == "C")
            {
                for (int inx = 0; inx < CONST_DAY_SHIFT.Length; inx++)
                {
                    soiHour.Items.Add(CONST_DAY_SHIFT[inx]);
                }
            }
            else
            {
                for (int inx = 0; inx < CONST_NIGHT_SHIFT.Length; inx++)
                {
                    soiHour.Items.Add(CONST_NIGHT_SHIFT[inx]);
                }
            }
         }

        private void cboLineLocation_SelectionChanged(object sender, EventArgs e)
        {
            MPCF.ClearList(spdData);
            txt_clear();
            cdvLineID.Text = "";
            cdvLineID.Code = "";
            cdvLineID.Description = "";
            cdvLineID.Focus();

        }

        private void cdvLineID_ValueChanged(object sender, EventArgs e)
        {
            btnView.PerformClick();
            set_view();
        }

        private void cdvLineID2_ValueChanged(object sender, EventArgs e)
        {
            cdvTabber.Text = "";
            cdvTabber.Description = "";
        }

    }
}
