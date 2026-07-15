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

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCUSManage4mNew : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private static string FM_TYPE = "PT";
        private const string BASE_OPERATION_CODE = "000000";

        public static string WORK_DATE = "";

        public enum FM_LIST
        {
            WORK_DATE,
            APPLY_TIME,
            KIND,
            WORK_LINE,
            OPERATION1,
            OPERATION2,
            RES_ID,
            EQ_DESCRIPTION,
            BEFORE,
            AFTER,
            REMARK,
            DEPARTMENT,
            NAME,
            CREATE_USER,
            CREATE_TIME,
            UPDATE_USER,
            UPDATE_TIME
        }

        #endregion

        #region Constructor

        public frmCUSManage4mNew()
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
            // Init
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
            dtpApplyTime.Value = DateTime.Now;

            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
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
                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// Work Line CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvWorkLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrEmpty(cdvPlant.Text) == true)
                {
                    MPCF.ShowMessage("There is no factory.", MSG_LEVEL.ERROR, false);
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));
                in_node.AddString("LINE_LOCATION", cdvPlant.Tag);

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvWorkLine.Text = cdvWorkLine.Show(cdvWorkLine, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                cdEQ.Text = "";
                cdEQ.Description = "";

                // Validation
                if (string.IsNullOrEmpty(cdvWorkLine.Text) == true)
                {
                    return;
                }

                return;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }
        

        /// <summary>
        /// Excel Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.ExportToExcel(spdE10TroubleList, this.Text, "", true, true, true, -1, -1) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {               
                if (ViewE10TroubleList() == false)
                {
                    return;
                }
                btnReset.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }      

        #endregion
        
        #region Functions

        /// <summary>
        /// View Productivity
        /// </summary>
        /// <returns></returns>
        private bool ViewE10TroubleList()
        {
            try
            {
                //WORK_DATE 값 초기화
                WORK_DATE = "";

                TRSNode in_node = new TRSNode("VIEW_E0_TROUBLE_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_E0_TROUBLE_LIST_OUT");

                //  Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("FM_TYPE", FM_TYPE);
                
                if (dtpFrom.Value != null)
                {
                    DateTime dtpDateTimeOut = new DateTime();
                    bool bTrySuccess = DateTime.TryParse(dtpFrom.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("FROM_DATE", dtpDateTimeOut.ToString("yyyyMMdd") + "060000");
                    }
                }
                
                if (dtpTo.Value != null)
                {
                    DateTime dtpDateTimeOut = new DateTime();
                    bool bTrySuccess = DateTime.TryParse(dtpTo.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("TO_DATE", dtpDateTimeOut.AddDays(1).ToString("yyyyMMdd") + "055959");
                    }
                }
                if (cdvPlant.Text != null && cdvPlant.Text != "")
                {
                    in_node.AddString("FACTORY_NO", MPCF.Trim(cdvPlant.Tag));
                }

                if (cdvWorkLineCond.Text != null && cdvWorkLineCond.Text != "")
                {
                    in_node.AddString("LINE_ID", MPCF.Trim(cdvWorkLineCond.Tag));
                }
                else
                {
                    in_node.AddString("LINE_ID", "%");
                }


                if (cdvDepartmentCond.Text != null && cdvDepartmentCond.Text.ToString() != "")
                {
                    in_node.AddString("DEPARTMENT", MPCF.Trim(cdvDepartmentCond.Tag.ToString()));
                }
                else
                {
                    in_node.AddString("DEPARTMENT", "%");
                }



                if (cdvKindCond.Text != null && cdvKindCond.Text.ToString() != "")
                {
                    in_node.AddString("KIND", MPCF.Trim(cdvKindCond.Tag.ToString()));
                }
                else
                {
                    in_node.AddString("KIND", "%");
                }



                if (cdvEQCond.Text != null && cdvEQCond.Text.ToString() != "")
                {
                    in_node.AddString("RES_ID", MPCF.Trim(cdvEQCond.Tag.ToString()));
                }
                else
                {
                    in_node.AddString("RES_ID", "%");
                }


                if (cdvOperation1Cond.Text != null && cdvOperation1Cond.Text.ToString() != "")
                {
                    in_node.AddString("OPER1", MPCF.Trim(cdvOperation1Cond.Tag.ToString()));
                }
                else
                {
                    in_node.AddString("OPER1", "%");
                }

                if (cdvOperation2Cond.Text != null && cdvOperation2Cond.Text.ToString() != "")
                {
                    in_node.AddString("OPER2", MPCF.Trim(cdvOperation2Cond.Tag.ToString()));
                }
                else
                {
                    in_node.AddString("OPER2", "%");
                }

                if (MPCF.CallService("CWIP", "CWIP_View_4m_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Clear
                MPCF.ClearList(this.spdE10TroubleList);
                
                // Bind
                spdE10TroubleList.ActiveSheet.RowCount = out_node.GetList(0).Count;
                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    spdE10TroubleList.ActiveSheet.RowHeader.Cells[i, 0].Tag = out_node.GetList(0)[i].GetInt("SEQ_NUM");

                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.WORK_DATE].Tag = out_node.GetList(0)[i].GetString("WORK_DATE");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.WORK_DATE].Value = MPCF.ToDate(out_node.GetList(0)[i].GetString("WORK_DATE"));
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.APPLY_TIME].Tag = out_node.GetList(0)[i].GetString("APPLY_TIME");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.APPLY_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("APPLY_TIME"), DATE_TIME_FORMAT.DATETIME);
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.KIND].Value = out_node.GetList(0)[i].GetString("KIND_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.KIND].Tag = out_node.GetList(0)[i].GetString("KIND");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.WORK_LINE].Value = out_node.GetList(0)[i].GetString("LINE_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.WORK_LINE].Tag = out_node.GetList(0)[i].GetString("LINE_ID");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.OPERATION1].Value = out_node.GetList(0)[i].GetString("OPER1_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.OPERATION1].Tag = out_node.GetList(0)[i].GetString("OPER1");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.OPERATION2].Value = out_node.GetList(0)[i].GetString("OPER2_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.OPERATION2].Tag = out_node.GetList(0)[i].GetString("OPER2");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.RES_ID].Value = out_node.GetList(0)[i].GetString("RES_ID");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.EQ_DESCRIPTION].Value = out_node.GetList(0)[i].GetString("EQ_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.BEFORE].Value = out_node.GetList(0)[i].GetString("BEFORE");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.AFTER].Value = out_node.GetList(0)[i].GetString("AFTER");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.REMARK].Value = out_node.GetList(0)[i].GetString("UNUSUAL_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.DEPARTMENT].Value = out_node.GetList(0)[i].GetString("DEPT_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.DEPARTMENT].Tag = out_node.GetList(0)[i].GetString("DEPARTMENT");

                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.NAME].Value = out_node.GetList(0)[i].GetString("CMF_2");


                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.CREATE_USER].Value = out_node.GetList(0)[i].GetString("CREATE_USER_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.CREATE_USER].Tag = out_node.GetList(0)[i].GetString("CREATE_USER_ID");

                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_TIME")) == "")
                    {
                    }
                    else
                    {
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.CREATE_TIME].Tag = out_node.GetList(0)[i].GetString("CREATE_TIME");
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.CREATE_TIME].Value = MPCF.ToDate(out_node.GetList(0)[i].GetString("CREATE_TIME"));
                    }

                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.UPDATE_USER].Value = out_node.GetList(0)[i].GetString("UPDATE_USER_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.UPDATE_USER].Tag = out_node.GetList(0)[i].GetString("UPDATE_USER_ID");

                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_TIME")) == "")
                    {
                    }
                    else
                    {
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.UPDATE_TIME].Tag = out_node.GetList(0)[i].GetString("UPDATE_TIME");
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.UPDATE_TIME].Value = MPCF.ToDate(out_node.GetList(0)[i].GetString("UPDATE_TIME"));
                    }
                }

                // Fit Column Hedaer
                MPCF.FitColumnHeader(spdE10TroubleList);

                lblSumQty_W.Text = spdE10TroubleList.ActiveSheet.RowCount.ToString();



                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool View4mData(int row)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_E0_TROUBLE_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_E0_TROUBLE_LIST_OUT");

                //  Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '4';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("FM_TYPE", FM_TYPE);

                if (spdE10TroubleList.ActiveSheet.Cells[row, (int)FM_LIST.WORK_DATE].Tag != null || MPCF.Trim(spdE10TroubleList.ActiveSheet.Cells[row, (int)FM_LIST.WORK_DATE].Tag.ToString()) == "")
                {
                    in_node.AddString("WORK_DATE", spdE10TroubleList.ActiveSheet.Cells[row, (int)FM_LIST.WORK_DATE].Tag.ToString());
                }


                if (spdE10TroubleList.ActiveSheet.Cells[row, (int)FM_LIST.WORK_LINE].Tag != null && MPCF.Trim(spdE10TroubleList.ActiveSheet.Cells[row, (int)FM_LIST.WORK_LINE].Tag.ToString()) != "")
                {
                    in_node.AddString("LINE_ID", MPCF.Trim(spdE10TroubleList.ActiveSheet.Cells[row, (int)FM_LIST.WORK_LINE].Tag.ToString()));
                }
                else
                {
                    return false;
                }

                if (spdE10TroubleList.ActiveSheet.RowHeader.Cells[row, 0].Tag != null)
                {
                    in_node.AddInt("SEQ_NUM", spdE10TroubleList.ActiveSheet.RowHeader.Cells[row, 0].Tag);
                }
                else
                {
                    return false;
                }


                if (MPCF.CallService("CWIP", "CWIP_View_4m_List", in_node, ref out_node) == false)
                {
                    return false;
                }
                txtSeq.Text = out_node.GetInt("SEQ_NUM").ToString();
                if (MPCF.Trim(out_node.GetString("APPLY_TIME")) == "")
                {
                }
                else
                {
                    dtpApplyTime.Value = MPCF.ToDate(out_node.GetString("APPLY_TIME"));
                }

                cdvKind.Text = out_node.GetString("KIND");
                cdvKind.Description = out_node.GetString("KIND_DESC");
                cdvOperation1.Text = out_node.GetString("OPER1");
                cdvOperation1.Description = out_node.GetString("OPER1_DESC");
                cdvOperation2.Text = out_node.GetString("OPER2");
                cdvOperation2.Description = out_node.GetString("OPER2_DESC");
                cdvWorkLine.Text = out_node.GetString("LINE_ID");
                cdvWorkLine.Description = out_node.GetString("LINE_DESC");
                cdEQ.Text = out_node.GetString("RES_ID");
                cdEQ.Description = out_node.GetString("EQ_DESC");
                txtBefore.Text = out_node.GetString("BEFORE");
                txtAfter.Text = out_node.GetString("AFTER");
                cdvDepartment.Text = out_node.GetString("DEPARTMENT");
                cdvDepartment.Description = out_node.GetString("DEPT_DESC");
                txtName.Text = out_node.GetString("CMF_2");
                txtUnusualDesc.Text = out_node.GetString("UNUSUAL_DESC");


                //UPDATE를 위해 WORK_DATE 정보를 미리 저장해 놓는다.
                WORK_DATE = spdE10TroubleList.ActiveSheet.Cells[row, (int)FM_LIST.WORK_DATE].Tag.ToString();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }


        /// <summary>
        /// User 정보 조회
        /// </summary>
        /// <param name="sUserId"></param>
        /// <returns></returns>
        public string ViewUserInfo(string sUserId)
        {
            TRSNode in_node = new TRSNode("VIEW_USER_IN");
            TRSNode out_node = new TRSNode("VIEW_USER_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("USER_ID", sUserId);

                if (MPCF.CallService("SEC", "SEC_View_User", in_node, ref out_node) == false)
                {
                    return "";
                }


                return out_node.GetString("USER_DESC");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
                return "";
            }
        }

        private bool Update_Daily_Work_List(char cProcStep)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = cProcStep;

                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("FM_TYPE", FM_TYPE);
                DateTime dtpDateTimeOut = new DateTime();

                if (cProcStep == MPGC.MP_STEP_CREATE)
                {
                    //PC를 켜고 > Manager 4M을 실행시켜 놓으면, dtpApplyTime 시간이 현재 시간과 많은 차이 발생하게 됨.
                    //버튼 클릭시에 현재 시간 적용하도록 변경하는 것이 맞음.
                    //bool bTrySuccess = DateTime.TryParse(dtpApplyTime.Value.ToString(), out dtpDateTimeOut);
                    //if (bTrySuccess == true)
                    //{
                    //    in_node.AddString("WORK_DATE", dtpDateTimeOut.ToString("yyyyMMdd"));
                    //    in_node.AddString("APPLY_TIME", dtpDateTimeOut.ToString("yyyyMMddHHmmss"));
                    //}

                    //Modified by htkim
                    //Create 버튼을 클릭했을 때의 시간을 사용.
                    dtpDateTimeOut = DateTime.Now;
                    int iCurrTime = int.Parse(dtpDateTimeOut.ToString("HH"));
                    if (iCurrTime >= 0 && iCurrTime <= 5)
                    {
                        TimeSpan duration = new TimeSpan(1, 0, 0, 0); //1일 빼기
                        DateTime work_date = dtpDateTimeOut.Subtract(duration);
                        in_node.AddString("WORK_DATE", work_date.ToString("yyyyMMdd"));
                    }
                    else
                    {
                        in_node.AddString("WORK_DATE", dtpDateTimeOut.ToString("yyyyMMdd"));
                    }
                    in_node.AddString("APPLY_TIME", dtpDateTimeOut.ToString("yyyyMMddHHmmss"));
                    //


                    in_node.AddString("LINE_ID", MPCF.Trim(cdvWorkLine.Text));
                    in_node.AddString("OPER1", MPCF.Trim(cdvOperation1.Text));
                    in_node.AddString("OPER2", MPCF.Trim(cdvOperation2.Text));
                    in_node.AddString("KIND", MPCF.Trim(cdvKind.Text));
                    in_node.AddString("RES_ID", MPCF.Trim(cdEQ.Text));
                    in_node.AddString("BEFORE", MPCF.Trim(txtBefore.Text));
                    in_node.AddString("AFTER", MPCF.Trim(txtAfter.Text));
                    in_node.AddString("UNUSUAL_DESC", MPCF.Trim(txtUnusualDesc.Text));
                    in_node.AddString("DEPARTMENT", MPCF.Trim(cdvDepartment.Text));
                    in_node.AddString("NAME", MPCF.Trim(txtName.Text));
                }
                else if ((cProcStep == MPGC.MP_STEP_UPDATE) || (cProcStep == MPGC.MP_STEP_DELETE))
                {

                    bool bTrySuccess = DateTime.TryParse(dtpApplyTime.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        
                        //int iCurrTime = int.Parse(dtpDateTimeOut.ToString("HH"));
                        //if (iCurrTime >= 0 && iCurrTime <= 5)
                        //{
                        //    TimeSpan duration = new TimeSpan(1, 0, 0, 0); //1일 빼기
                        //    DateTime work_date = dtpDateTimeOut.Subtract(duration);
                        //    in_node.AddString("WORK_DATE", work_date.ToString("yyyyMMdd"));
                        //}
                        //else
                        //{
                        //    in_node.AddString("WORK_DATE", dtpDateTimeOut.ToString("yyyyMMdd"));
                        //}

                        //Modified by htkim
                        in_node.AddString("WORK_DATE", WORK_DATE); // <- 선택되어진 Row의 WORK_DATE
                        in_node.AddString("APPLY_TIME", dtpDateTimeOut.ToString("yyyyMMddHHmmss"));
                    }
                    in_node.AddInt("SEQ_NUM", MPCF.ToInt(MPCF.Trim(txtSeq.Text)));
                    in_node.AddString("LINE_ID", MPCF.Trim(cdvWorkLine.Text));
                    in_node.AddString("OPER1", MPCF.Trim(cdvOperation1.Text));
                    in_node.AddString("OPER2", MPCF.Trim(cdvOperation2.Text));
                    in_node.AddString("KIND", MPCF.Trim(cdvKind.Text));
                    in_node.AddString("RES_ID", MPCF.Trim(cdEQ.Text));
                    in_node.AddString("BEFORE", MPCF.Trim(txtBefore.Text));
                    in_node.AddString("AFTER", MPCF.Trim(txtAfter.Text));
                    in_node.AddString("UNUSUAL_DESC", MPCF.Trim(txtUnusualDesc.Text));
                    in_node.AddString("DEPARTMENT", MPCF.Trim(cdvDepartment.Text));
                    in_node.AddString("NAME", MPCF.Trim(txtName.Text));
                }

                if (MPCF.CallService("CWIP", "CWIP_Update_4m", in_node, ref out_node) == false)
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

        private void cdvWorkLineE_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvPlant.Text = cdvPlant.Show(cdvPlant, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvPlant.Text) == true)
                {
                    return;
                }

                return;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition() == false)
                {
                    return;
                }

                if (txtSeq.Text == string.Empty )
                {
                    MPCF.ShowMessage(MPCF.GetMessage(597), MSG_LEVEL.ERROR, false);
                    return;
                }

                if (Update_Daily_Work_List(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                else
                {
                    btnProcess.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnToExcelW_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.ExportToExcel(spdE10TroubleList, this.Text, "", true, true, true, -1, -1) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }             

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if ( CheckCondition() == false)
                {
                    return;
                }

                if (Update_Daily_Work_List(MPGC.MP_STEP_CREATE) == false)                
                {
                    return;
                }
                else
                {
                    btnProcess.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private bool checkAuthorityForData(int row)
        {
            if (MPGV.gsUserID.Equals("ADMIN") ||
                MPGV.gsUserID.Equals(spdE10TroubleList.ActiveSheet.Cells[row, (int)FM_LIST.CREATE_USER].Tag))
                return true;

            return false;
        }

        private void spdE10TroubleList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Row < 0 || e.ColumnHeader == true)
            {
                return;
            }
            if (checkAuthorityForData(e.Row) == false)
            {
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            }

            if (View4mData(e.Row) == false)
            {
                return;
            }
        }      

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(txtSeq, false) == false)
                {
                    return;
                }


                if (spdE10TroubleList.ActiveSheet.RowCount == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(591), MSG_LEVEL.ERROR, false);
                    return;
                }

                if (Update_Daily_Work_List(MPGC.MP_STEP_DELETE) == false)                
                {
                    return;
                }
                else
                {
                    btnProcess.PerformClick();
                    txtSeq.Text = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }
        
         

        public void resetButtonClick(object sender, EventArgs e)
        {
            //WORK_DATE 값 초기화
            WORK_DATE = "";

            cdvKind.Text = string.Empty;
            cdvKind.Description = string.Empty;
            cdvWorkLine.Text = string.Empty;
            cdvWorkLine.Description = string.Empty;
            cdvOperation1.Text = string.Empty;
            cdvOperation1.Description = string.Empty;
            cdvOperation2.Text = string.Empty;
            cdvOperation2.Description = string.Empty;
            cdEQ.Text = string.Empty;
            cdEQ.Description = string.Empty;
            cdvDepartment.Text = string.Empty;
            cdvDepartment.Description = string.Empty;
            txtBefore.Text = string.Empty;
            txtAfter.Text = string.Empty;
            txtName.Text = string.Empty; 
            txtUnusualDesc.Text = string.Empty;
            txtSeq.Text = string.Empty;
        } 

        private void cdvDepartment_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = 'E';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_DEPARTMENT));
                in_node.AddString("DATA_2", "Y");
                in_node.AddString("DATA_4", "E");

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvDepartment.Text = cdvDepartment.Show(cdvDepartment, "Code List", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvDepartment.Text) == true)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvKind_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_4M_KIND));

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvKind.Text = cdvKind.Show(cdvKind, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
 

                // Validation
                if (string.IsNullOrEmpty(cdvKind.Text) == true)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvOperation1_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrEmpty(cdvPlant.Text) == true)
                {
                    MPCF.ShowMsgBox("Please select a Factory number.", MessageBoxButtons.OK, MSG_LEVEL.ERROR, "Information", false);
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = 'E';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_4M_OPERATION));
                in_node.AddString("KEY_2", BASE_OPERATION_CODE);
                in_node.AddString("DATA_2", cdvPlant.Tag.Equals("E1") ? "Y" : "X");
                in_node.AddString("DATA_4", cdvPlant.Tag.Equals("E2") ? "Y" : "X");

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvOperation1.Text = cdvOperation1.Show(cdvOperation1, "Code List", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_1");

                cdvOperation2.Text = "";
                cdvOperation2.Description = "";
                cdEQ.Text = "";
                cdEQ.Description = "";

                // Validation
                if (string.IsNullOrEmpty(cdvOperation1Cond.Text) == true)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvOperation2_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrEmpty(cdvPlant.Text) == true)
                {
                    MPCF.ShowMsgBox("Please select a Factory number.", MessageBoxButtons.OK, MSG_LEVEL.ERROR, "Information", false);
                    return;
                }
                // Validation
                if (string.IsNullOrEmpty(cdvOperation1.Text) == true)
                {
                    MPCF.ShowMsgBox("Please select an Operation 1.", MessageBoxButtons.OK, MSG_LEVEL.ERROR, "Information", false);
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = 'E';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_4M_OPERATION));
                in_node.AddString("KEY_2", cdvOperation1.Text);
                in_node.AddString("DATA_2", cdvPlant.Tag.Equals("E1") ? "Y" : "X");
                in_node.AddString("DATA_4", cdvPlant.Tag.Equals("E2") ? "Y" : "X");

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvOperation2.Text = cdvOperation2.Show(cdvOperation2, "Code List", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_1");

                cdEQ.Text = "";
                cdEQ.Description = "";


                // Validation
                if (string.IsNullOrEmpty(cdvOperation2.Text) == true)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvPlant_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_LOCATION));

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvPlant.Text = cdvPlant.Show(cdvPlant, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "DATA_1");
                if (cdvPlant.returnDatas != null && cdvPlant.returnDatas.Count > 0)
                {
                    cdvPlant.Tag = cdvPlant.returnDatas[0];
                }

                cdvWorkLineCond.Text = "";
                cdvWorkLineCond.Tag = "";
                cdvOperation1Cond.Text = "";
                cdvOperation1Cond.Tag = "";
                cdvOperation2Cond.Text = "";
                cdvOperation2Cond.Tag = "";
                cdvEQCond.Text = "";
                cdvEQCond.Tag = "";

                // Validation
                if (string.IsNullOrEmpty(cdvPlant.Text) == true)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvWorkLineCond_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrEmpty(cdvPlant.Text) == true)
                {
                    MPCF.ShowMsgBox("Please select a Factory number.", MessageBoxButtons.OK, MSG_LEVEL.ERROR, "Information", false);
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));
                in_node.AddString("LINE_LOCATION", cdvPlant.Tag);

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvWorkLineCond.Text = cdvWorkLineCond.Show(cdvWorkLineCond, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "DATA_1");
                if (cdvWorkLineCond.returnDatas != null && cdvWorkLineCond.returnDatas.Count > 0)
                {
                    cdvWorkLineCond.Tag = cdvWorkLineCond.returnDatas[0];
                }

                // Validation
                if (string.IsNullOrEmpty(cdvWorkLineCond.Text) == true)
                {
                    return;
                }

                return;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvOperation1Cond_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrEmpty(cdvPlant.Text) == true)
                {
                    MPCF.ShowMsgBox("Please select a Factory number.", MessageBoxButtons.OK, MSG_LEVEL.ERROR, "Information", false);
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = 'E';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_4M_OPERATION));
                in_node.AddString("KEY_2", BASE_OPERATION_CODE);
                in_node.AddString("DATA_2", cdvPlant.Tag.Equals("E1")?"Y":"X");
                in_node.AddString("DATA_4", cdvPlant.Tag.Equals("E2")?"Y":"X");

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvOperation1Cond.Text = cdvOperation1Cond.Show(cdvOperation1Cond, "Code List", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "DATA_1");
                if (cdvOperation1Cond.returnDatas != null && cdvOperation1Cond.returnDatas.Count > 0)
                {
                    cdvOperation1Cond.Tag = cdvOperation1Cond.returnDatas[0];
                }
                cdvOperation2Cond.Text = "";
                cdvOperation2Cond.Tag = "";

                // Validation
                if (string.IsNullOrEmpty(cdvOperation1Cond.Text) == true)
                {
                    return;
                } 
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvOperation2Cond_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrEmpty(cdvPlant.Text) == true)
                {
                    MPCF.ShowMsgBox("Please select a Factory number.", MessageBoxButtons.OK, MSG_LEVEL.ERROR, "Information", false);
                    return;
                }
                // Validation
                if (string.IsNullOrEmpty(cdvOperation1Cond.Text) == true)
                {
                    MPCF.ShowMsgBox("Please select an Operation 1.", MessageBoxButtons.OK, MSG_LEVEL.ERROR, "Information", false);
                    return;
                }
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = 'E';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_4M_OPERATION));
                in_node.AddString("KEY_2" , cdvOperation1Cond.Tag);
                in_node.AddString("DATA_2", cdvPlant.Tag.Equals("E1") ? "Y" : "X");
                in_node.AddString("DATA_4", cdvPlant.Tag.Equals("E2") ? "Y" : "X");


                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvOperation2Cond.Text = cdvOperation2Cond.Show(cdvOperation2Cond, "Code List", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "DATA_1");
                if (cdvOperation2Cond.returnDatas != null && cdvOperation2Cond.returnDatas.Count > 0)
                {
                    cdvOperation2Cond.Tag = cdvOperation2Cond.returnDatas[0];
                }

                cdvEQCond.Text = "";
                cdvEQCond.Tag = "";
                // Validation
                if (string.IsNullOrEmpty(cdvOperation2Cond.Text) == true)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvEQCond_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrEmpty(cdvWorkLineCond.Text) == true)
                {
                    MPCF.ShowMsgBox("Please select a Work Line.", MessageBoxButtons.OK, MSG_LEVEL.ERROR, "Information", false);
                    return;
                }
                // Validation
                if (string.IsNullOrEmpty(cdvOperation1Cond.Text) == true)
                {
                    MPCF.ShowMsgBox("Please select an Operation 1.", MessageBoxButtons.OK, MSG_LEVEL.ERROR, "Information", false);
                    return;
                }
                // Validation
                if (string.IsNullOrEmpty(cdvOperation2Cond.Text) == true)
                {
                    MPCF.ShowMsgBox("Please select an Operation 2.", MessageBoxButtons.OK, MSG_LEVEL.ERROR, "Information", false);
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = 'F';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_4M_EQ));
                in_node.AddString("KEY_1", cdvWorkLineCond.Tag);
                in_node.AddString("KEY_2", cdvOperation1Cond.Tag);
                in_node.AddString("KEY_3", cdvOperation2Cond.Tag);

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_4", "DATA_1" };

                cdvEQCond.Text = cdvEQCond.Show(cdvEQCond, "Code List", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "DATA_1");
                if (cdvEQCond.returnDatas != null && cdvEQCond.returnDatas.Count > 0)
                {
                    cdvEQCond.Tag = cdvEQCond.returnDatas[0];
                }

                // Validation
                if (string.IsNullOrEmpty(cdvEQCond.Text) == true)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdEQ_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrEmpty(cdvWorkLine.Text) == true)
                {
                    MPCF.ShowMsgBox("Please select a Work Line.", MessageBoxButtons.OK, MSG_LEVEL.ERROR, "Information", false);
                    return;
                }
                // Validation
                if (string.IsNullOrEmpty(cdvOperation1.Text) == true)
                {
                    MPCF.ShowMsgBox("Please select an Operation 1.", MessageBoxButtons.OK, MSG_LEVEL.ERROR, "Information", false);
                    return;
                }
                // Validation
                if (string.IsNullOrEmpty(cdvOperation2.Text) == true)
                {
                    MPCF.ShowMsgBox("Please select an Operation 2.", MessageBoxButtons.OK, MSG_LEVEL.ERROR, "Information", false);
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = 'F';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_4M_EQ));
                in_node.AddString("KEY_1", cdvWorkLine.Text); 
                in_node.AddString("KEY_2", cdvOperation1.Text);
                in_node.AddString("KEY_3", cdvOperation2.Text);

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_4", "DATA_1" };

                cdEQ.Text = cdEQ.Show(cdEQ, "Code List", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "KEY_4");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvKindCond_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_4M_KIND));

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvKindCond.Text = cdvKindCond.Show(cdvKindCond, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "DATA_1");
                if (cdvKindCond.returnDatas != null && cdvKindCond.returnDatas.Count > 0)
                {
                    cdvKindCond.Tag = cdvKindCond.returnDatas[0];
                }

                // Validation
                if (string.IsNullOrEmpty(cdvKindCond.Text) == true)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvDepartmentCond_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = 'E';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_DEPARTMENT));
                in_node.AddString("DATA_2", "Y");
                in_node.AddString("DATA_4", "X");

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvDepartmentCond.Text = cdvDepartmentCond.Show(cdvDepartmentCond, "Code List", "CBAS", "CBAS_View_Data_List", in_node, "LIST", display, header, "DATA_1");
                if (cdvDepartmentCond.returnDatas != null && cdvDepartmentCond.returnDatas.Count > 0)
                {
                    cdvDepartmentCond.Tag = cdvDepartmentCond.returnDatas[0];
                }

                // Validation
                if (string.IsNullOrEmpty(cdvDepartmentCond.Text) == true)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private bool CheckCondition()
        {
            try
            {
                if (MPCF.CheckValue(cdvKind, false) == false)
                {
                    cdvKind.Focus();
                    return false;
                }

                if (MPCF.CheckValue(cdvOperation1, false) == false)
                {
                    cdvOperation1.Focus();
                    return false;
                }

                if (MPCF.CheckValue(cdvOperation2, false) == false)
                {
                    cdvOperation2.Focus();
                    return false;
                }
                if (MPCF.CheckValue(cdvWorkLine, false) == false)
                {
                    cdvWorkLine.Focus();
                    return false;
                }
                if (MPCF.CheckValue(cdEQ, false) == false)
                {
                    cdEQ.Focus();
                    return false;
                }
                if (MPCF.CheckValue(txtBefore, false) == false)
                {
                    txtBefore.Focus();
                    return false;
                }
                if (MPCF.CheckValue(txtAfter, false) == false)
                {
                    txtAfter.Focus();
                    return false;
                }

                if (MPCF.CheckValue(cdvDepartment, false) == false)
                {
                    cdvDepartment.Focus();
                    return false;
                }
                if (MPCF.CheckValue(txtName, false) == false)
                {
                    txtName.Focus();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
     
    }
}
