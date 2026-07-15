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
    public partial class frmWIPChangeWork : frmPopupBase
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
            WORK_PART,
            WORK_PART_BTN,
            LUNCH_OVER_TIME,
            LUNCH_OVER_TIME_BTN,
            OVER_TIME,
            OVER_TIME_BTN
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

        public frmWIPChangeWork(string sWorkDate, string sTeam, string sTeamDesc, string sPart, string sPartDesc, string[] user_id, string[] user_desc, string[] wrk_part, string[] wrk_part_desc, string[] lunch_over_time, string[] lunch_over_time_desc, string[] over_time, string[] over_time_desc)
        {
            InitializeComponent();
            txtTeam.Tag = sTeam;
            txtTeam.Text = sTeamDesc;
            txtPart.Tag = sPart;
            txtPart.Text = sPartDesc;
            sWorkDate_1 = sWorkDate;

            MPCF.ClearList(spdWorkerList);
            for (int i = 0; i < user_id.Length; i++)
            {
                spdWorkerList.ActiveSheet.AddRows(spdWorkerList.ActiveSheet.RowCount, 1);
                spdWorkerList.ActiveSheet.Cells[i, (int)WORK_MANAGE.USER_ID].Text = user_id[i];
                spdWorkerList.ActiveSheet.Cells[i, (int)WORK_MANAGE.USER_DESC].Text = user_desc[i];
                spdWorkerList.ActiveSheet.Cells[i, (int)WORK_MANAGE.WORK_PART].Tag = wrk_part[i];
                spdWorkerList.ActiveSheet.Cells[i, (int)WORK_MANAGE.WORK_PART].Text = wrk_part_desc[i];
                //spdWorkerList.ActiveSheet.Cells[i, (int)WORK_MANAGE.LUNCH_OVER_TIME].Tag = lunch_over_time[i];
                //spdWorkerList.ActiveSheet.Cells[i, (int)WORK_MANAGE.LUNCH_OVER_TIME].Text = lunch_over_time_desc[i];
                spdWorkerList.ActiveSheet.Cells[i, (int)WORK_MANAGE.OVER_TIME].Tag = over_time[i];
                spdWorkerList.ActiveSheet.Cells[i, (int)WORK_MANAGE.OVER_TIME].Text = over_time_desc[i];
            }
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


            //btnView.PerformClick();

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

            i = spdWorkerList.ActiveSheet.ActiveRowIndex;
            for (i = 0; i < spdWorkerList.Sheets[0].RowCount; i++)
            {

                if (Convert.ToBoolean(spdWorkerList.ActiveSheet.Cells[i,(int)WORK_MANAGE.CHECK].Value) == true)
                {
                    node = in_node.AddNode("LIST");
                    node.SetString("PLN_WRK_DATE", MPCF.Trim(sWorkDate_1));
                    node.SetString("PLN_TEAM", MPCF.Trim(txtTeam.Tag));
                    node.SetString("PLN_PART", MPCF.Trim(txtPart.Tag));
                    node.SetString("USER_ID", MPCF.Trim(spdWorkerList.ActiveSheet.Cells[i, (int)WORK_MANAGE.USER_ID].Text));
                    node.SetString("USER_DESC", MPCF.Trim(spdWorkerList.ActiveSheet.Cells[i, (int)WORK_MANAGE.USER_DESC].Text));


                    node.SetChar("MODE", 'O');
                    //업무 변경(서버에서 현재 업무랑 비교해서 함)
                    node.SetString("WRK_PART", MPCF.Trim(spdWorkerList.ActiveSheet.Cells[i, (int)WORK_MANAGE.WORK_PART].Tag));
                    //중식 초과
                    //if (MPCF.Trim(spdWorkerList.ActiveSheet.Cells[i, (int)WORK_MANAGE.LUNCH_OVER_TIME].Tag.ToString()) != "")
                    //{
                    //    node.SetChar("LUNCH_OVER_FLAG", 'Y');
                    //    node.SetInt("LUNCH_OVER_TIME", MPCF.ToInt(spdWorkerList.ActiveSheet.Cells[i, (int)WORK_MANAGE.LUNCH_OVER_TIME].Tag.ToString()));
                    //}
                    if (MPCF.Trim(spdWorkerList.ActiveSheet.Cells[i, (int)WORK_MANAGE.OVER_TIME].Tag.ToString()) != "")
                    {
                        node.SetChar("OVER_FLAG", 'Y');
                        node.SetInt("OVER_TIME", MPCF.ToInt(spdWorkerList.ActiveSheet.Cells[i, (int)WORK_MANAGE.OVER_TIME].Tag.ToString()));
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
            MPCF.ClearList(spdWorkerList);
            return true;

        }

        #endregion

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                
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
                if (e.Column == (int)WORK_MANAGE.WORK_PART_BTN)
                {

                    TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];

                    dvcArgu[0].sCondtion_ID = "FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    dvcArgu[1].sCondtion_ID = "TEAM";
                    dvcArgu[1].sCondition_Value = MPCF.Trim(txtTeam.Tag);

                    dvcArgu[2].sCondtion_ID = "PART";
                    dvcArgu[2].sCondition_Value = MPCF.Trim(txtPart.Tag);

                    // CodeView Column Header Setup
                    string[] header = new string[] { "Work", "Work Desc" };

                    // CodeView Display Column Setup
                    string[] display = new string[] { "WORK", "WORK_DESC" };

                    // Show
                    cdvWorkTime.Text = cdvWorkTime.Show(cdvWorkTime, "Code Desc", "CWIP2501-006", dvcArgu, display, header, "WORK_DESC", -1);

                    if (MPCF.Trim(cdvWorkTime.Text) != "")
                    {
                        if (cdvWorkTime.returnDatas != null && cdvWorkTime.returnDatas.Count > 0)
                        {
                            spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.WORK_PART].Tag = cdvWorkTime.returnDatas[0];
                            spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.WORK_PART].Text = cdvWorkTime.returnDatas[1];
                            spdWorkerList.ActiveSheet.Rows[e.Row].BackColor = Color.Salmon;
                            spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.CHECK].Value = true;
                        }
                        else
                        {
                            spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.WORK_PART].Tag = "";
                            spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.WORK_PART].Text = "";
                        }
                    }
                    else
                    {
                        spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.WORK_PART].Tag = "";
                        spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.WORK_PART].Text = "";
                    }


                }
                else if (e.Column == (int)WORK_MANAGE.LUNCH_OVER_TIME_BTN)
                {

                    TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[1];

                    dvcArgu[0].sCondtion_ID = "FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    // CodeView Column Header Setup
                    string[] header = new string[] { "Code", "Code Desc" };

                    // CodeView Display Column Setup
                    string[] display = new string[] { "KEY_1", "DATA_1" };
                    
                    // Show
                    cdvLunchOverTime.Text = cdvLunchOverTime.Show(cdvLunchOverTime, "Code Desc", "OWIP2503-004", dvcArgu, display, header, "DATA_1", -1);

                    if (MPCF.Trim(cdvLunchOverTime.Text) != "")
                    {
                        if (cdvLunchOverTime.returnDatas != null && cdvLunchOverTime.returnDatas.Count > 0)
                        {
                            spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.LUNCH_OVER_TIME].Tag = cdvLunchOverTime.returnDatas[0];
                            spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.LUNCH_OVER_TIME].Text = cdvLunchOverTime.returnDatas[1];
                            spdWorkerList.ActiveSheet.Rows[e.Row].BackColor = Color.Salmon;
                            spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.CHECK].Value = true;
                        }
                        else
                        {
                            spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.LUNCH_OVER_TIME].Tag = "";
                            spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.LUNCH_OVER_TIME].Text = "";
                        }
                    }
                    else
                    {
                        spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.LUNCH_OVER_TIME].Tag = "";
                        spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.LUNCH_OVER_TIME].Text = "";
                    }
                }
                else if (e.Column == (int)WORK_MANAGE.OVER_TIME_BTN)
                {

                    TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[1];

                    dvcArgu[0].sCondtion_ID = "FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    // CodeView Column Header Setup
                    string[] header = new string[] { "Code", "Code Desc" };

                    // CodeView Display Column Setup
                    string[] display = new string[] { "KEY_1", "DATA_1" };
                    
                    // Show
                    cdvOverTime.Text = cdvOverTime.Show(cdvOverTime, "Code Desc", "OWIP2503-004", dvcArgu, display, header, "DATA_1", -1);

                    if (MPCF.Trim(cdvOverTime.Text) != "")
                    {
                        if (cdvOverTime.returnDatas != null && cdvOverTime.returnDatas.Count > 0)
                        {
                            spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.OVER_TIME].Tag = cdvOverTime.returnDatas[0];
                            spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.OVER_TIME].Text = cdvOverTime.returnDatas[1];
                            spdWorkerList.ActiveSheet.Rows[e.Row].BackColor = Color.Salmon;
                            spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.CHECK].Value = true;
                        }
                        else
                        {
                            spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.OVER_TIME].Tag = "";
                            spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.OVER_TIME].Text = "";
                        }
                    }
                    else
                    {
                        spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.OVER_TIME].Tag = "";
                        spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.OVER_TIME].Text = "";
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
            if (Update_Work_Status(MPGC.MP_STEP_UPDATE) == false)
            {
                return;
            }
        }

    }
}
