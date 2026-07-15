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
using BOI.OIFrx;
using System.Collections;
using SOI.DNM;

namespace BOI.WIPCus.Popup
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmWIPAddWorker : frmPopupBase
    {
        private enum WORKER
        {
            CHECK = 0,
            USER_ID,
            USER_DESC
        }

        private enum WORK_MANAGE
        {
            CHECK = 0,
            USER_ID,
            USER_DESC,
            WRK_PART,
            WRK_PART_BTN,
            WRK_TIME,
            WRK_TIME_BTN
        }

        private string sWorkDate_1;
        private string sPlanTeam;
        private string sPlanPart;


        #region Property

        /// <summary>
        /// (Required) Show form after drawing is finished.
        /// Form 내에 있는 모든 컨트롤들의 Rendering을 완료한 이후에 Form을 표시한다.
        /// Load Event 이후에 발생하므로 Focus 등의 이벤트들은 Activated 이벤트에 할당해야 한다.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000;
                return createParams;
            }
        }

        #endregion

        #region Constructor

        public frmWIPAddWorker(string sWorkDate, string sTeam, string sTeamDesc, string sPart, string sPartDesc)
        {
            InitializeComponent();
            cdvTeam.Tag = sTeam;
            cdvTeam.Text = sTeamDesc;
            cdvPart.Tag = sPart;
            cdvPart.Text = sPartDesc;
            
        
            sPlanTeam = sTeam;
            sPlanPart = sPart;
            sWorkDate_1 = sWorkDate;
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// - Form Activate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIPopup_Load(object sender, EventArgs e)
        {
            // Caption 변경
            MPCF.ConvertCaption(this);

            MPCF.ClearList(spdWorker);
            MPCF.ClearList(spdAddList);

            btnView.PerformClick();

            // 활성화
            this.Activate();
        }

        /// <summary>
        /// (Required) Close Button Click
        /// - Form Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // 종료
            this.Close();
        }

        #endregion


        #region Function

        //View Inventory Lot History
        private bool ViewWorkerList()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[5];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;
            try
            {

                spdWorker_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "TEAM";
                dvcArgu[1].sCondition_Value = "%" + MPCF.Trim(cdvTeam.Tag) + "%";

                dvcArgu[2].sCondtion_ID = "PART";
                dvcArgu[2].sCondition_Value = "%" + MPCF.Trim(cdvPart.Tag) + "%";

                dvcArgu[3].sCondtion_ID = "USER_ID";
                dvcArgu[3].sCondition_Value = "%" + MPCF.Trim(txtUserID.Text) + "%";

                dvcArgu[4].sCondtion_ID = "USER_DESC";
                dvcArgu[4].sCondition_Value = "%" + MPCF.Trim(txtWorkerName.Text) + "%";

                if (TPDR.GetDataOne("", ref dt, "OWIP2503-002", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdWorker_Sheet1.RowCount++;
                    spdWorker_Sheet1.Cells[i, (int)WORKER.USER_ID].Value = dt.Rows[i][0].ToString();
                    spdWorker_Sheet1.Cells[i, (int)WORKER.USER_ID].Tag = dt.Rows[i][2].ToString(); // from Team
                    spdWorker_Sheet1.Cells[i, (int)WORKER.USER_DESC].Value = dt.Rows[i][1].ToString();
                    spdWorker_Sheet1.Cells[i, (int)WORKER.USER_DESC].Tag = dt.Rows[i][3].ToString(); // from Part
                }
                MPCF.FitColumnHeader(spdWorker);
                spdWorker.ActiveSheet.Columns[(int)WORKER.CHECK].Width = 25;
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
        private bool Update_Work_Status(char cProcStep)
        {
            int i = 0;
            int iIndex = 0;
            TRSNode in_node = new TRSNode("UPDATE_WORK_DATA");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode node;
            MPCF.SetInMsg(in_node);
            in_node.Factory = MPCF.Trim(MPGV.gsFactory);
            in_node.ProcStep = cProcStep;

            i = spdAddList.ActiveSheet.ActiveRowIndex;
            for (i = 0; i < spdAddList.Sheets[0].RowCount; i++)
            {

                if (Convert.ToBoolean(spdAddList.ActiveSheet.Cells[i,(int)WORK_MANAGE.CHECK].Value) == true)
                {
                    node = in_node.AddNode("LIST");
                    node.SetString("PLN_WRK_DATE", MPCF.Trim(sWorkDate_1));
                    node.SetString("PLN_TEAM", MPCF.Trim(sPlanTeam));
                    node.SetString("PLN_PART", MPCF.Trim(sPlanPart));
                    node.SetString("USER_ID", MPCF.Trim(spdAddList.ActiveSheet.Cells[i, (int)WORK_MANAGE.USER_ID].Text));
                    node.SetString("USER_DESC", MPCF.Trim(spdAddList.ActiveSheet.Cells[i, (int)WORK_MANAGE.USER_DESC].Text));
                    node.SetString("WRK_PART", MPCF.Trim(spdAddList.ActiveSheet.Cells[i, (int)WORK_MANAGE.WRK_PART].Tag));
                    node.SetString("WRK_TIME", MPCF.Trim(spdAddList.ActiveSheet.Cells[i, (int)WORK_MANAGE.WRK_TIME].Tag));
                    node.SetString("FROM_TEAM", MPCF.Trim(spdAddList.ActiveSheet.Cells[i, (int)WORK_MANAGE.USER_ID].Tag));
                    node.SetString("FROM_PART", MPCF.Trim(spdAddList.ActiveSheet.Cells[i, (int)WORK_MANAGE.USER_DESC].Tag));
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
            MPCF.ClearList(spdAddList);
            return true;

        }

        #endregion

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewWorkerList() == false)
                {
                    return;
                }
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
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnDetach_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i < spdWorker.ActiveSheet.RowCount; i++)
                {
                    if(Convert.ToBoolean(spdWorker.ActiveSheet.Cells[i, (int)WORKER.CHECK].Value) == true)
                    {
                        for (int j = 0; j < spdAddList.ActiveSheet.RowCount; j++)
                        {
                            if (MPCF.Trim(spdAddList.ActiveSheet.Cells[j, (int)WORK_MANAGE.USER_ID].Text) == MPCF.Trim(spdWorker.ActiveSheet.Cells[i, (int)WORKER.USER_ID].Text))
                            {
                                MPCF.ShowMessage(MPCF.GetMessage(456), MSG_LEVEL.WARNING, true);
                                return;
                            }
                            
                        }
                        spdAddList.ActiveSheet.AddRows(spdAddList.ActiveSheet.RowCount, 1);
                        spdAddList.ActiveSheet.Cells[spdAddList.ActiveSheet.RowCount - 1, (int)WORK_MANAGE.USER_ID].Text = spdWorker.ActiveSheet.Cells[i, (int)WORKER.USER_ID].Text;
                        spdAddList.ActiveSheet.Cells[spdAddList.ActiveSheet.RowCount - 1, (int)WORK_MANAGE.USER_ID].Tag = spdWorker.ActiveSheet.Cells[i, (int)WORKER.USER_ID].Tag;
                        spdAddList.ActiveSheet.Cells[spdAddList.ActiveSheet.RowCount - 1, (int)WORK_MANAGE.USER_DESC].Text = spdWorker.ActiveSheet.Cells[i, (int)WORKER.USER_DESC].Text;
                        spdAddList.ActiveSheet.Cells[spdAddList.ActiveSheet.RowCount - 1, (int)WORK_MANAGE.USER_DESC].Tag = spdWorker.ActiveSheet.Cells[i, (int)WORKER.USER_DESC].Tag;
                        spdWorker.ActiveSheet.Cells[i, (int)WORKER.CHECK].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < spdAddList.ActiveSheet.RowCount; i++)
                {
                    if (Convert.ToBoolean(spdAddList.ActiveSheet.Cells[i, (int)WORKER.CHECK].Value) == true)
                    {
                        spdAddList.ActiveSheet.RemoveRows(i, 1);
                        i--;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdAddList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column == (int)WORK_MANAGE.WRK_PART_BTN)
                {

                    TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];

                    dvcArgu[0].sCondtion_ID = "FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    dvcArgu[1].sCondtion_ID = "TEAM";
                    dvcArgu[1].sCondition_Value = MPCF.Trim(sPlanTeam);

                    dvcArgu[2].sCondtion_ID = "PART";
                    dvcArgu[2].sCondition_Value = MPCF.Trim(sPlanPart);

                    // CodeView Column Header Setup
                    string[] header = new string[] { "Work", "Work Desc" };

                    // CodeView Display Column Setup
                    string[] display = new string[] { "WORK", "WORK_DESC" };

                    // Show
                    cdvWorkPart.Text = cdvWorkPart.Show(cdvWorkPart, "Work Desc", "CWIP2501-006", dvcArgu, display, header, "WORK_DESC", -1);

                    if (MPCF.Trim(cdvWorkPart.Text) != "")
                    {
                        if (cdvWorkPart.returnDatas != null && cdvWorkPart.returnDatas.Count > 0)
                        {
                            spdAddList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.WRK_PART].Tag = cdvWorkPart.returnDatas[0];
                            spdAddList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.WRK_PART].Text = cdvWorkPart.returnDatas[1];
                        }
                        else
                        {
                            spdAddList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.WRK_PART].Tag = "";
                            spdAddList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.WRK_PART].Text = "";
                        }
                    }
                    else
                    {
                        spdAddList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.WRK_PART].Tag = "";
                        spdAddList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.WRK_PART].Text = "";
                    }
                    

                }
                else if (e.Column == (int)WORK_MANAGE.WRK_TIME_BTN)
                {

                    TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[1];

                    dvcArgu[0].sCondtion_ID = "FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    // CodeView Column Header Setup
                    string[] header = new string[] { "Time", "Time Desc", "Start Time", "End Time" };

                    // CodeView Display Column Setup
                    string[] display = new string[] { "KEY_1", "DATA_1", "START_TIME", "END_TIME" };

                    // Show
                    cdvWorkTime.Text = cdvWorkTime.Show(cdvWorkTime, "Time Desc", "CWIP2501-007", dvcArgu, display, header, "DATA_1", -1);

                    if (MPCF.Trim(cdvWorkTime.Text) != "")
                    {
                        if (cdvWorkTime.returnDatas != null && cdvWorkTime.returnDatas.Count > 0)
                        {
                            spdAddList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.WRK_TIME].Tag = cdvWorkTime.returnDatas[0];
                            spdAddList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.WRK_TIME].Text = cdvWorkTime.returnDatas[1];
                            spdAddList.ActiveSheet.Rows[e.Row].BackColor = Color.Salmon;
                            spdAddList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.CHECK].Value = true;
                        }
                        else
                        {
                            spdAddList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.WRK_TIME].Tag = "";
                            spdAddList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.WRK_TIME].Text = "";
                        }
                    }
                    else
                    {
                        spdAddList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.WRK_TIME].Tag = "";
                        spdAddList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.WRK_TIME].Text = "";
                    }


                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (Update_Work_Status(MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
        }

    }
}
