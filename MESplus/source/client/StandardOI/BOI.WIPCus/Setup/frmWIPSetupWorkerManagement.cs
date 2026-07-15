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
using BOI.OIFrx.BOIBaseForm;
using BOI.INVCus;
using BOI.OIFrx;
using SOI.DNM;
using BOI.WIPCus.Popup;

namespace BOI.WIPCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmWIPSetupWorkerManagement : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private enum WORK_MANAGE
        {
            CHECK = 0,
            USER_ID,
            USER_DESC,
            WRK_PART,
            WRK_TYPE,
            WRK_TIME,
            START_TIME,
            END_TIME,
            WRK_ATD,
            LATE_TIME,
            LUNCH_OVER_TIME,
            OVER_TIME,
            LEAVE_EARLY_TIME,
            COMMON_WRK_TIME,
            LAST_CHG_TIME,
            LAST_ATD_TERM_TIME,
            COMMON_WORK
        }

        #endregion

        #region Constructor

        public frmWIPSetupWorkerManagement()
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
        private void frmTempBOIBaseForm02_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);

            MPCF.ClearList(spdWorkerManage);

            dtpOrderDate.Value = System.DateTime.Today;
            chkDayShift.Checked = true;
            chkNightShift.Checked = true;

            GetDefaultValueFromReg();
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempBOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                   
                GetDefaultValueFromReg();        

                // (Required) 
                bIsShown = true;
            }
        }

        private void txtInvLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //string tempLotId;
            //int indexValue;

            try
            {
                if (e.KeyChar == (char)13)
                {
                    //tempLotId = txtInvLotID.Text.Trim();
                    //indexValue = tempLotId.IndexOf(":");

                    //txtInvLotID.Text = tempLotId.Substring(0, indexValue);
                    //txtUnitQty.Value = MPCF.ToDbl(tempLotId.Substring(indexValue + 1));

                    //btnView.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        public void GetDefaultValueFromReg()
        {
            try
            {

                cdvTeam.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvTeam.Tag"));
                cdvTeam.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvTeam.Text"));

                cdvPart.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvPart.Tag"));
                cdvPart.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvPart.Text"));

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        private void SetDefaultValueToReg()
        {
            try
            {
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvTeam.Tag", MPCF.Trim(cdvTeam.Tag));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvTeam.Text", MPCF.Trim(cdvTeam.Text));
                
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvPart.Tag", MPCF.Trim(cdvPart.Tag));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvPart.Text", MPCF.Trim(cdvPart.Text));


            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }



        //View Inventory Lot History
        private bool ViewWorkManageList()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[6];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;
            try
            {

                spdWorkerManage_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "WORK_DATE";
                dvcArgu[1].sCondition_Value = dtpOrderDate.GetValueAsDateTime().ToString("yyyyMMdd");

                dvcArgu[2].sCondtion_ID = "TEAM";
                dvcArgu[2].sCondition_Value = MPCF.Trim(cdvTeam.Tag);

                dvcArgu[3].sCondtion_ID = "PART";
                dvcArgu[3].sCondition_Value = MPCF.Trim(cdvPart.Tag);

                dvcArgu[4].sCondtion_ID = "SHIFT";
                if (chkDayShift.Checked == true && chkNightShift.Checked == false)
                {
                    dvcArgu[4].sCondition_Value = "A";
                }
                else if (chkDayShift.Checked == true && chkNightShift.Checked == true)
                {
                    dvcArgu[4].sCondition_Value = "%";
                }
                else if (chkDayShift.Checked == false && chkNightShift.Checked == true)
                {
                    dvcArgu[4].sCondition_Value = "B";
                }

                dvcArgu[5].sCondtion_ID = "LINE_ID";
                if (MPCF.Trim(cdvLine.Tag) == "")
                {
                    dvcArgu[5].sCondition_Value = "%";
                }
                else
                {
                    dvcArgu[5].sCondition_Value = MPCF.Trim(cdvLine.Tag);
                }
                if (TPDR.GetDataOne("", ref dt, "OWIP2503-001", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdWorkerManage_Sheet1.RowCount++;
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.USER_ID].Value = dt.Rows[i][0].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.USER_DESC].Value = dt.Rows[i][1].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.WRK_PART].Tag = dt.Rows[i][2].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.WRK_PART].Text = dt.Rows[i][3].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.WRK_TYPE].Text = dt.Rows[i][4].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.WRK_TIME].Tag = dt.Rows[i][5].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.WRK_TIME].Text = dt.Rows[i][6].ToString();
                    if (MPCF.Trim(dt.Rows[i][7].ToString()) == "")
                    {
                        spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.START_TIME].Text = "";
                    }
                    else
                    {
                        spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.START_TIME].Text = dt.Rows[i][7].ToString().Substring(8,2);
                    }
                    if (MPCF.Trim(dt.Rows[i][8].ToString()) == "")
                    {
                        spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.END_TIME].Text = "";
                    }
                    else
                    {
                        spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.END_TIME].Text = dt.Rows[i][8].ToString().Substring(8,2);
                    }
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.WRK_ATD].Tag = dt.Rows[i][9].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.WRK_ATD].Text = dt.Rows[i][10].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.USER_ID].Tag = dt.Rows[i][11].ToString(); // FROM TEAM
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.USER_DESC].Tag = dt.Rows[i][12].ToString(); // FROM PART


                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.LATE_TIME].Tag = dt.Rows[i][13].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.LATE_TIME].Text = dt.Rows[i][14].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.LUNCH_OVER_TIME].Tag = dt.Rows[i][15].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.LUNCH_OVER_TIME].Text = dt.Rows[i][16].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.OVER_TIME].Tag = dt.Rows[i][17].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.OVER_TIME].Text = dt.Rows[i][18].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.LEAVE_EARLY_TIME].Tag = dt.Rows[i][19].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.LEAVE_EARLY_TIME].Text = dt.Rows[i][20].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.COMMON_WRK_TIME].Tag = dt.Rows[i][21].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.COMMON_WRK_TIME].Text = dt.Rows[i][22].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.LAST_CHG_TIME].Tag = dt.Rows[i][23].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.LAST_CHG_TIME].Text = dt.Rows[i][24].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.LAST_ATD_TERM_TIME].Tag = dt.Rows[i][25].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.LAST_ATD_TERM_TIME].Text = dt.Rows[i][26].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.COMMON_WORK].Tag = dt.Rows[i][27].ToString();
                    spdWorkerManage_Sheet1.Cells[i, (int)WORK_MANAGE.COMMON_WORK].Text = dt.Rows[i][28].ToString();

                }
                MPCF.FitColumnHeader(spdWorkerManage);
                spdWorkerManage.ActiveSheet.Columns[(int)WORK_MANAGE.CHECK].Width = 25;
                spdWorkerManage.ActiveSheet.Columns[(int)WORK_MANAGE.LATE_TIME].Visible = false;
                spdWorkerManage.ActiveSheet.Columns[(int)WORK_MANAGE.LUNCH_OVER_TIME].Visible = false;
                spdWorkerManage.ActiveSheet.Columns[(int)WORK_MANAGE.OVER_TIME].Visible = false;
                spdWorkerManage.ActiveSheet.Columns[(int)WORK_MANAGE.LEAVE_EARLY_TIME].Visible = false;
                spdWorkerManage.ActiveSheet.Columns[(int)WORK_MANAGE.COMMON_WRK_TIME].Visible = false;
                spdWorkerManage.ActiveSheet.Columns[(int)WORK_MANAGE.LAST_CHG_TIME].Visible = false;
                spdWorkerManage.ActiveSheet.Columns[(int)WORK_MANAGE.LAST_ATD_TERM_TIME].Visible = false;
                spdWorkerManage.ActiveSheet.Columns[(int)WORK_MANAGE.COMMON_WORK].Visible = false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        //
        // Update_Work_Status()
        //       - update Material
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        - ByVal ProcStep As String : MP_STEP_CREATE/UPDATE/DELETE
        //
        private bool Update_Work_Status(char cProcStep, char cFlag)
        {
            int i = 0;
            int iIndex = 0;
            TRSNode in_node = new TRSNode("UPDATE_WORK_DATA");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode node;
            MPCF.SetInMsg(in_node);
            in_node.Factory = MPCF.Trim(MPGV.gsFactory);
            in_node.ProcStep = cProcStep;

            i = spdWorkerManage.ActiveSheet.ActiveRowIndex;
            for (i = 0; i < spdWorkerManage.Sheets[0].RowCount; i++)
            {

                if (Convert.ToBoolean(spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.CHECK].Value) == true)
                {
                    node = in_node.AddNode("LIST");
                    node.SetString("PLN_WRK_DATE", MPCF.Trim(dtpOrderDate.GetValueAsDateTime().ToString("yyyyMMdd")));
                    node.SetString("PLN_TEAM", MPCF.Trim(cdvTeam.Tag));
                    node.SetString("PLN_PART", MPCF.Trim(cdvPart.Tag));
                    node.SetString("USER_ID", MPCF.Trim(spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.USER_ID].Text));
                    //작업자 삭제
                    if (cFlag == 'D')
                    {
                        node.SetChar("MODE", 'D');
                        node.SetChar("DELETE_FLAG", cFlag);
                        node.SetChar("WORKING_FLAG", 'N');
                        if (MPCF.Trim(cdvDeleteReason.Tag) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(457));
                            return false;
                        }
                        else
                        {
                            node.SetString("DELTE_RSN", cdvDeleteReason.Tag);
                        }
                    }
                }
                else
                {
                    //MPCF.ShowMsgBox(MPCF.GetMessage(454));
                    //return false;
                }
            }


            if (MPCF.CallService("BWIP", "BWIP_Multi_Update_Work_Status", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCF.ShowSuccessMessage(out_node, false);
            MPCF.ClearList(spdWorkerManage);
            return true;

        }

        //
        // Confirm_Work_Status()
        //       - update Material
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        - ByVal ProcStep As String : MP_STEP_CREATE/UPDATE/DELETE
        //
        private bool Confirm_Work_Status(char cProcStep)
        {
            int i = 0;
            int iIndex = 0;
            TRSNode in_node = new TRSNode("UPDATE_WORK_DATA");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode node;
            MPCF.SetInMsg(in_node);
            in_node.Factory = MPCF.Trim(MPGV.gsFactory);
            in_node.ProcStep = cProcStep;

            i = spdWorkerManage.ActiveSheet.ActiveRowIndex;
            for (i = 0; i < spdWorkerManage.Sheets[0].RowCount; i++)
            {
                node = in_node.AddNode("LIST");
                node.SetString("PLN_WRK_DATE", MPCF.Trim(dtpOrderDate.GetValueAsDateTime().ToString("yyyyMMdd")));
                node.SetString("PLN_TEAM", MPCF.Trim(cdvTeam.Tag));
                node.SetString("PLN_PART", MPCF.Trim(cdvPart.Tag));
                node.SetString("USER_ID", MPCF.Trim(spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.USER_ID].Text));
                
                node.SetChar("MODE", 'C');//근무 확인
                node.SetChar("WORKING_FLAG", 'Y');
                node.SetString("LAST_WRK_ATD_TYPE", BIGC.B_WRK_ATD_PUN_06); // 출근
                node.SetString("NEXT_DATE", MPCF.Trim(dtpOrderDate.GetValueAsDateTime().AddDays(1).ToString("yyyyMMdd")));
                
            }


            if (MPCF.CallService("BWIP", "BWIP_Multi_Update_Work_Status", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCF.ShowSuccessMessage(out_node, false);
            MPCF.ClearList(spdWorkerManage);
            return true;

        }

        //
        // Lock_Work_Plan()
        //       - update Material
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        - ByVal ProcStep As String : MP_STEP_CREATE/UPDATE/DELETE
        //
        private bool Lock_Work_Plan(char cProcStep)
        {
            int i = 0;
            int iIndex = 0;
            TRSNode in_node = new TRSNode("UPDATE_WORK_DATA");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCF.SetInMsg(in_node);
            in_node.Factory = MPCF.Trim(MPGV.gsFactory);
            in_node.ProcStep = cProcStep;
            in_node.SetString("PLN_WRK_DATE", MPCF.Trim(dtpOrderDate.GetValueAsDateTime().ToString("yyyyMMdd")));
            in_node.SetString("PLN_TEAM", MPCF.Trim(cdvTeam.Tag));
            in_node.SetString("PLN_PART", MPCF.Trim(cdvPart.Tag));
            in_node.SetChar("PLN_LOCK", 'Y');

            if (MPCF.CallService("BWIP", "BWIP_Update_Work_Plan_Lock", in_node, ref out_node) == false)
            {
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
                    case "VIEW_WORK_MANAGE_LIST":
                        //LINE GROUP  
                        if (MPCF.Trim(cdvTeam.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvTeam.Focus();
                            return false;
                        }
                        
                        //LINE
                        if (MPCF.Trim(cdvPart.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvPart.Focus();
                            return false;
                        }
                        
                        //SHIFT
                        if (chkDayShift.Checked == false && chkNightShift.Checked == false)
                        {
                            chkDayShift.Checked = true;
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private void InvisibleColumn()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {

                spdWorkerManage.ActiveSheet.RowCount = 0;

                if (ViewWorkManageList() == false)
                    return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void frmWIPSetupWorkerManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetDefaultValueToReg();
        }

        private void chkDayShift_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if(chkDayShift.Checked == true)
                    chkDayShift.BackColor = Color.Salmon;
                else
                    chkDayShift.BackColor = Color.WhiteSmoke;

                

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        private void chkNightShift_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkNightShift.Checked == true)
                    chkNightShift.BackColor = Color.RoyalBlue;
                else
                    chkNightShift.BackColor = Color.WhiteSmoke;
            
                

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvTeam_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_DATA_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_DEPT_TEAM));

                // CodeView Column Header Setup
                string[] header = new string[] { "Reason", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvTeam.Text = cdvTeam.Show(cdvTeam, "Reason", "BCOM", "BCOM_View_Gcm_Data_List", in_node, "GCM_DATA_LIST", display, header, "DATA_1");

                if (MPCF.Trim(cdvTeam.Text) != "")
                {
                    if (cdvTeam.returnDatas.Count > 0)
                    {
                        cdvTeam.Tag = cdvTeam.returnDatas[0];
                        cdvTeam.Text = cdvTeam.returnDatas[1];
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvPart_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_DATA_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_DEPT_PART));
                in_node.AddString("KEY_1", MPCF.Trim(cdvTeam.Tag));

                // CodeView Column Header Setup
                string[] header = new string[] { "Reason", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_2", "DATA_1" };

                // Show
                cdvPart.Text = cdvPart.Show(cdvTeam, "Reason", "BCOM", "BCOM_View_Gcm_Data_List", in_node, "GCM_DATA_LIST", display, header, "DATA_1");

                if (MPCF.Trim(cdvPart.Text) != "")
                {
                    if (cdvPart.returnDatas.Count > 0)
                    {
                        cdvPart.Tag = cdvPart.returnDatas[0];
                        cdvPart.Text = cdvPart.returnDatas[1];
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvTeam_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                cdvPart.Text = "";
                cdvPart.Tag = "";
                cdvLine.Text = "";
                cdvLine.Tag = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnView_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("VIEW_WORK_MANAGE_LIST") == false)
                {
                    return;
                }

                if (ViewWorkManageList() == false)
                    return;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvPart_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                cdvLine.Text = "";
                cdvLine.Tag = "";

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void dtpOrderDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnAddWorker_Click(object sender, EventArgs e)
        {
            MenuInfoTag selectedMenuInfo;
            if (CheckCondition("VIEW_WORK_MANAGE_LIST") == false)
            {
                
                return;
            }
            else
            {
                frmWIPAddWorker frm = new frmWIPAddWorker(dtpOrderDate.GetValueAsDateTime().ToString("yyyyMMdd"), MPCF.Trim(cdvTeam.Tag), MPCF.Trim(cdvTeam.Text), MPCF.Trim(cdvPart.Tag), MPCF.Trim(cdvPart.Text));
                frm.ShowDialog(this);

                if (CheckCondition("VIEW_WORK_MANAGE_LIST") == false)
                {
                    return;
                }

                if (ViewWorkManageList() == false)
                    return;
            }
        }

        private void btnDeleteWorker_Click(object sender, EventArgs e)
        {

            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[1];

            dvcArgu[0].sCondtion_ID = "FACTORY";
            dvcArgu[0].sCondition_Value = MPGV.gsFactory;

            // CodeView Column Header Setup
            string[] header = new string[] { "Code", "Code Desc" };

            // CodeView Display Column Setup
            string[] display = new string[] { "KEY_1", "DATA_1" };

            // Show

            cdvDeleteReason.Text = cdvDeleteReason.Show(cdvDeleteReason, "Code Desc", "OWIP2503-003", dvcArgu, display, header, "DATA_1", -1);

            if (MPCF.Trim(cdvDeleteReason.Text) != "")
            {
                if (cdvDeleteReason.returnDatas != null && cdvDeleteReason.returnDatas.Count > 0)
                {
                    cdvDeleteReason.Tag = cdvDeleteReason.returnDatas[0];
                    cdvDeleteReason.Text = cdvDeleteReason.returnDatas[1];
                }
                else
                {
                    //cdvDeleteReason.Tag = "";
                    //cdvDeleteReason.Text = "";
                }
            }
            else
            {
                cdvDeleteReason.Tag = "";
                cdvDeleteReason.Text = "";
            }

            if (Update_Work_Status(MPGC.MP_STEP_UPDATE, 'D') == false)
            {
                return;
            }

            if (CheckCondition("VIEW_WORK_MANAGE_LIST") == false)
            {
                return;
            }

            if (ViewWorkManageList() == false)
                return;
        }

        private void btnConfirmWork_Click(object sender, EventArgs e)
        {
            if (Lock_Work_Plan(MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }

            if (Confirm_Work_Status(MPGC.MP_STEP_UPDATE) == false)
            {
                return;
            }

            if (CheckCondition("VIEW_WORK_MANAGE_LIST") == false)
            {
                return;
            }

            if (ViewWorkManageList() == false)
                return;
        }

        private void btnProcessLate_Click(object sender, EventArgs e)
        {
            MenuInfoTag selectedMenuInfo;
            if (CheckCondition("VIEW_WORK_MANAGE_LIST") == false)
            {

                return;
            }
            else
            {
                int selected_count = 0;
                for (int i = 0; i < spdWorkerManage.ActiveSheet.RowCount; i++)
                {
                    if (Convert.ToBoolean(spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.CHECK].Value) == true)
                    {
                        selected_count++;
                    }
                }
                string[] user_id = new string[selected_count];
                string[] user_desc = new string[selected_count];
                string[] late_time = new string[selected_count];
                string[] late_time_desc = new string[selected_count];
                string[] early_leave_time = new string[selected_count];
                string[] early_leave_time_desc = new string[selected_count];
                int j = 0;
                for (int i = 0; i < spdWorkerManage.ActiveSheet.RowCount; i++)
                {
                    if (Convert.ToBoolean(spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.CHECK].Value) == true)
                    {
                        user_id[j] = spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.USER_ID].Text;
                        user_desc[j] = spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.USER_DESC].Text;
                        late_time[j] = spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.LATE_TIME].Tag.ToString();
                        late_time_desc[j] = spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.LATE_TIME].Text;
                        early_leave_time[j] = spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.LEAVE_EARLY_TIME].Tag.ToString();
                        early_leave_time_desc[j] = spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.LEAVE_EARLY_TIME].Text;
                        j++;
                    }
                }
                frmWIPProcessLate frm = new frmWIPProcessLate(dtpOrderDate.GetValueAsDateTime().ToString("yyyyMMdd"), MPCF.Trim(cdvTeam.Tag), MPCF.Trim(cdvTeam.Text), MPCF.Trim(cdvPart.Tag), MPCF.Trim(cdvPart.Text), user_id, user_desc, late_time, late_time_desc, early_leave_time, early_leave_time_desc);
                frm.ShowDialog(this);

                if (CheckCondition("VIEW_WORK_MANAGE_LIST") == false)
                {
                    return;
                }

                if (ViewWorkManageList() == false)
                    return;
            }
        }

        private void btnChangeWork_Click(object sender, EventArgs e)
        {
            MenuInfoTag selectedMenuInfo;
            if (CheckCondition("VIEW_WORK_MANAGE_LIST") == false)
            {

                return;
            }
            else
            {
                int selected_count = 0;
                for (int i = 0; i < spdWorkerManage.ActiveSheet.RowCount; i++)
                {
                    if (Convert.ToBoolean(spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.CHECK].Value) == true)
                    {
                        selected_count++;
                    }
                }
                string[] user_id = new string[selected_count];
                string[] user_desc = new string[selected_count];
                string[] wrk_part = new string[selected_count];
                string[] wrk_part_desc = new string[selected_count];
                string[] lunch_over_time = new string[selected_count];
                string[] lunch_over_time_desc = new string[selected_count];
                string[] over_time = new string[selected_count];
                string[] over_time_desc = new string[selected_count];
                int j = 0;
                for (int i = 0; i < spdWorkerManage.ActiveSheet.RowCount; i++)
                {
                    if (Convert.ToBoolean(spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.CHECK].Value) == true)
                    {
                        user_id[j] = spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.USER_ID].Text;
                        user_desc[j] = spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.USER_DESC].Text;
                        wrk_part[j] = spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.WRK_PART].Tag.ToString();
                        wrk_part_desc[j] = spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.WRK_PART].Text;
                        lunch_over_time[j] = spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.LUNCH_OVER_TIME].Tag.ToString();
                        lunch_over_time_desc[j] = spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.LUNCH_OVER_TIME].Text;
                        over_time[j] = spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.OVER_TIME].Tag.ToString();
                        over_time_desc[j] = spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.OVER_TIME].Text;
                        j++;
                    }
                }
                frmWIPChangeWork frm = new frmWIPChangeWork(dtpOrderDate.GetValueAsDateTime().ToString("yyyyMMdd"), MPCF.Trim(cdvTeam.Tag), MPCF.Trim(cdvTeam.Text), MPCF.Trim(cdvPart.Tag), MPCF.Trim(cdvPart.Text), user_id, user_desc, wrk_part, wrk_part_desc, lunch_over_time, lunch_over_time_desc, over_time, over_time_desc);
                frm.ShowDialog(this);

                if (CheckCondition("VIEW_WORK_MANAGE_LIST") == false)
                {
                    return;
                }

                if (ViewWorkManageList() == false)
                    return;
            }
        }

        private void btnComWork_Click(object sender, EventArgs e)
        {
            MenuInfoTag selectedMenuInfo;
            if (CheckCondition("VIEW_WORK_MANAGE_LIST") == false)
            {

                return;
            }
            else
            {
                int selected_count = 0;
                for (int i = 0; i < spdWorkerManage.ActiveSheet.RowCount; i++)
                {
                    if (Convert.ToBoolean(spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.CHECK].Value) == true)
                    {
                        selected_count++;
                    }
                }
                string[] user_id = new string[selected_count];
                string[] user_desc = new string[selected_count];
                string[] common_work = new string[selected_count];
                string[] common_work_desc = new string[selected_count];
                string[] common_work_time = new string[selected_count];
                string[] common_work_time_desc = new string[selected_count];
                int j = 0;
                for (int i = 0; i < spdWorkerManage.ActiveSheet.RowCount; i++)
                {
                    if (Convert.ToBoolean(spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.CHECK].Value) == true)
                    {
                        user_id[j] = spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.USER_ID].Text;
                        user_desc[j] = spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.USER_DESC].Text;
                        common_work[j] = spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.COMMON_WORK].Tag.ToString();
                        common_work_desc[j] = spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.COMMON_WORK].Text;
                        common_work_time[j] = spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.COMMON_WRK_TIME].Tag.ToString();
                        common_work_time_desc[j] = spdWorkerManage.ActiveSheet.Cells[i, (int)WORK_MANAGE.COMMON_WRK_TIME].Text;
                        j++;
                    }
                }
                frmWIPCommonWork frm = new frmWIPCommonWork(dtpOrderDate.GetValueAsDateTime().ToString("yyyyMMdd"), MPCF.Trim(cdvTeam.Tag), MPCF.Trim(cdvTeam.Text), MPCF.Trim(cdvPart.Tag), MPCF.Trim(cdvPart.Text), user_id, user_desc, common_work, common_work_desc, common_work_time, common_work_time_desc);
                frm.ShowDialog(this);

                if (CheckCondition("VIEW_WORK_MANAGE_LIST") == false)
                {
                    return;
                }

                if (ViewWorkManageList() == false)
                    return;
            }
        }

        private void btnSupportSite_Click(object sender, EventArgs e)
        {
            MenuInfoTag selectedMenuInfo;
            if (CheckCondition("VIEW_WORK_MANAGE_LIST") == false)
            {

                return;
            }
            else
            {
                frmWIPSiteSupport frm = new frmWIPSiteSupport(dtpOrderDate.GetValueAsDateTime().ToString("yyyyMMdd"), MPCF.Trim(cdvTeam.Tag), MPCF.Trim(cdvTeam.Text), MPCF.Trim(cdvPart.Tag), MPCF.Trim(cdvPart.Text));
                frm.ShowDialog(this);

                if (CheckCondition("VIEW_WORK_MANAGE_LIST") == false)
                {
                    return;
                }

                if (ViewWorkManageList() == false)
                    return;
            }
        }

        private void cdvLine_CodeViewButtonClick(object sender, EventArgs e)
        {

            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];

            dvcArgu[0].sCondtion_ID = "FACTORY";
            dvcArgu[0].sCondition_Value = MPGV.gsFactory;

            dvcArgu[1].sCondtion_ID = "TEAM";
            dvcArgu[1].sCondition_Value = MPCF.Trim(cdvTeam.Tag);

            dvcArgu[2].sCondtion_ID = "PART";
            dvcArgu[2].sCondition_Value = MPCF.Trim(cdvPart.Tag);

            string[] header = new string[] { "Line", "Line Desc" };

            // CodeView Display Column Setup
            string[] display = new string[] { "LINE_ID", "LINE_DESC" };

            // Show

            cdvLine.Text = cdvLine.Show(cdvLine, "Line Desc", "OWIP2503-008", dvcArgu, display, header, "LINE_DESC", -1);

            if (MPCF.Trim(cdvLine.Text) != "")
            {
                if (cdvLine.returnDatas != null && cdvLine.returnDatas.Count > 0)
                {
                    cdvLine.Tag = cdvLine.returnDatas[0];
                    cdvLine.Text = cdvLine.returnDatas[1];
                }
                else
                {
                    //cdvLine.Tag = "";
                    //cdvLine.Text = "";
                }
            }
            else
            {
                cdvLine.Tag = "";
                cdvLine.Text = "";
            }
        }

    }
}
