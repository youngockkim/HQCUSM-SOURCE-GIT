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
    public partial class frmWIPSiteSupport : frmPopupBase
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
            SUPPORT_TIME,
            SUPPORT_TIME_BTN
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

        public frmWIPSiteSupport(string sWorkDate, string sTeam, string sTeamDesc, string sPart, string sPartDesc)
        {
            InitializeComponent();
            txtTeam.Tag = sTeam;
            txtTeam.Text = sTeamDesc;
            txtPart.Tag = sPart;
            txtPart.Text = sPartDesc;
            sWorkDate_1 = sWorkDate;

            ViewWorker();
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

        private bool ViewWorker()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[5];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;
            try
            {
                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "TEAM";
                dvcArgu[1].sCondition_Value = MPCF.Trim(txtTeam.Tag);

                dvcArgu[2].sCondtion_ID = "PART";
                dvcArgu[2].sCondition_Value = MPCF.Trim(txtPart.Tag);

                dvcArgu[3].sCondtion_ID = "USER_ID";
                dvcArgu[3].sCondition_Value = MPCF.Trim(spdWorkerList.ActiveSheet.Cells[i, (int)WORK_MANAGE.USER_ID].Text);

                dvcArgu[4].sCondtion_ID = "WORK_DATE";
                dvcArgu[4].sCondition_Value = MPCF.Trim(sWorkDate_1);


                if (TPDR.GetDataOne("", ref dt, "OWIP2503-007", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt.DataSet == null)
                    {
                        return true;
                    }

                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }
                spdWorkerList_Sheet1.Cells[i, (int)WORK_MANAGE.SUPPORT_TIME].Tag = dt.Rows[i][0].ToString();
                spdWorkerList_Sheet1.Cells[i, (int)WORK_MANAGE.SUPPORT_TIME].Value = dt.Rows[i][1].ToString();

                MPCF.FitColumnHeader(spdWorkerList);
                spdWorkerList.ActiveSheet.Columns[(int)WORKER.CHECK].Width = 25;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        //
        // Create_Work_Status()
        //       - update Material
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        - ByVal ProcStep As String : MP_STEP_CREATE/UPDATE/DELETE
        //
        private bool Create_Work_Status(char cProcStep)
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

                    node.SetString("WRK_PART", BIGC.B_WRK_MANUAL_W_04);
                    //node.SetString("WRK_TIME", " ");
                    //node.SetString("FROM_TEAM", MPCF.Trim(spdWorkerList.ActiveSheet.Cells[i, (int)WORK_MANAGE.USER_ID].Tag));
                    //node.SetString("FROM_PART", MPCF.Trim(spdWorkerList.ActiveSheet.Cells[i, (int)WORK_MANAGE.USER_DESC].Tag));


                    node.SetChar("MODE", 'S');//현장 지원
                    node.SetString("MHR_CMF_2", spdWorkerList.ActiveSheet.Cells[i, (int)WORK_MANAGE.SUPPORT_TIME].Tag.ToString());
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
                if (e.Column == (int)WORK_MANAGE.SUPPORT_TIME_BTN)
                {

                    TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[1];

                    dvcArgu[0].sCondtion_ID = "FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    // CodeView Column Header Setup
                    string[] header = new string[] { "Code", "Code Desc" };

                    // CodeView Display Column Setup
                    string[] display = new string[] { "KEY_1", "DATA_1" };

                    // Show
                    cdvWorkTime.Text = cdvWorkTime.Show(cdvWorkTime, "Code Desc", "OWIP2503-004", dvcArgu, display, header, "DATA_1", -1);

                    if (MPCF.Trim(cdvWorkTime.Text) != "")
                    {
                        if (cdvWorkTime.returnDatas != null && cdvWorkTime.returnDatas.Count > 0)
                        {
                            spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.SUPPORT_TIME].Tag = cdvWorkTime.returnDatas[0];
                            spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.SUPPORT_TIME].Text = cdvWorkTime.returnDatas[1];
                            spdWorkerList.ActiveSheet.Rows[e.Row].BackColor = Color.Salmon;
                            spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.CHECK].Value = true;
                        }
                        else
                        {
                            spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.SUPPORT_TIME].Tag = "";
                            spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.SUPPORT_TIME].Text = "";
                        }
                    }
                    else
                    {
                        spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.SUPPORT_TIME].Tag = "";
                        spdWorkerList.ActiveSheet.Cells[e.Row, (int)WORK_MANAGE.SUPPORT_TIME].Text = "";
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
            if (Create_Work_Status(MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }


            ViewWorker();
        }

    }
}
