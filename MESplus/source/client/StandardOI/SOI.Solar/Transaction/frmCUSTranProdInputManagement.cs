using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using SOI.DNM;

namespace SOI.Solar
{
    public partial class frmCUSTranProdInputManagement : SOIBaseForm03
    {
        #region [Property]

        private bool gCellChk = false;

        #endregion

        public frmCUSTranProdInputManagement()
        {
            InitializeComponent();
        }
        
        #region [Constant Definition]

        private enum PROD_INPUT_LIST
        {
            CHK,                   // 체크박스
            WORK_DATE,             // 작업시간
            LINE,                  // 라인
            LINE_DESC,             // 라인 설명
            RES_ID,                // 장비
            RES_DESC,              // 장비 설명
            COMPANY,               // 회사
            WORKER,               // 작업자
            STD_START_TIME,        // 표준 근무 시간 (분)
            ADD_START_TIME,        // 추가 근무 (분)
            EXCEPT_CODE,           // 유실 코드
            NON_START_TIME,        // 유실 시작 시간
            NON_END_TIME,          // 유실 종료 시간
            EXCEPT_TIME,           // 유실 시간 (분)
            WORK_TYPE
        }

        private enum RETURN_VALUE
        {
            KEY,
            DESC
        }

        #endregion

        #region [Variable Definition]

        #endregion

        #region [FormDefinition]

        private void initCtrl()
        {
            try
            {
                MPCF.ConvertCaption(this);
                MPCF.FieldClear(this);
                this.dtpWorkDate.Value = DateTime.Now;
                this.dtpInputWorkTIme.Value = DateTime.Now;

                spdProdInputUser.ActiveSheet.Columns[(int)PROD_INPUT_LIST.CHK].Visible = false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        #endregion

        #region [Function Definition]

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case CSGC.MP_CHECK_VIEW:

                        break;

                    case CSGC.MP_CHECK_UPDATE:
                    case CSGC.MP_CHECK_CREATE:

                        if (!CheckValuesEmpty())
                            return false;

                        break;

                    case CSGC.MP_CHECK_DELETE:

                        if (spdProdInputUser.ActiveSheet.ActiveRowIndex < 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(272));
                            return false;
                        }

                        if (string.IsNullOrEmpty(MPCF.Trim(cdvInputLine.Text)))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(411));
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

        private bool CheckValuesEmpty()
        {
            try
            {
                if (string.IsNullOrEmpty(MPCF.Trim(cdvInputLine.Text)))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(411));
                    return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(cdvInputResID.Text)))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(410));
                    return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(cdvInputCompany.Text)))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(442));
                    return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(cdvInputWorker.Text)))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(443));
                    return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(dtpInputStandardTIme.Text)))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(444));
                    return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(dtpInputExtraTIme.Text)))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(445));
                    return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(cdvInputMissingCode.Text)))
                {
                    //MPCF.ShowMsgBox(MPCF.GetMessage(446));
                    //return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(dtpInputMissingStartHour.Text)) || string.IsNullOrEmpty(MPCF.Trim(dtpInputMissingStartMin.Text)))
                {
                    //MPCF.ShowMsgBox(MPCF.GetMessage(447));
                    //return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(dtpInputMissingEndHour.Text)) || string.IsNullOrEmpty(MPCF.Trim(dtpInputMissingEndMin.Text)))
                {
                    //MPCF.ShowMsgBox(MPCF.GetMessage(448));
                    //return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(cdvInputWorkTypeCode.Text)))
                {
                    //MPCF.ShowMsgBox(MPCF.GetMessage(449));
                    //return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewProdInputUserList()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] dvcArgu;
            string s_sql = "";

            DataTable dt = new DataTable();
            MPCF.ClearList(this.spdProdInputUser);

            try
            {
                sViewID = "VIEW_PROD_INPUT_USER_LIST";

                i_cond_cnt = 5;
                dvcArgu = new TPDR.DirectViewCond[i_cond_cnt];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$WORK_DATE";
                dvcArgu[1].sCondition_Value = MPCF.Trim(this.dtpWorkDate.GetValueAsString(8));

                dvcArgu[2].sCondtion_ID = "$LINE";
                dvcArgu[2].sCondition_Value = MPCF.Trim(cdvLine.Text);

                dvcArgu[3].sCondtion_ID = "$COMPANY";
                dvcArgu[3].sCondition_Value = MPCF.Trim(cdvCompany.Text);

                dvcArgu[4].sCondtion_ID = "$RES_ID";
                dvcArgu[4].sCondition_Value = MPCF.Trim(cdvResID.Text);

                if (TPDR.GetDataOne("", ref dt, sViewID, dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spdProdInputUser.ActiveSheet.RowCount++;
                    spdProdInputUser.ActiveSheet.Cells[spdProdInputUser.ActiveSheet.RowCount - 1, (int)PROD_INPUT_LIST.CHK].Value = true;
                    spdProdInputUser.ActiveSheet.Cells[spdProdInputUser.ActiveSheet.RowCount - 1, (int)PROD_INPUT_LIST.WORK_DATE].Value = dt.Rows[i]["WORK_DATE"].ToString();           // 작업시간
                    spdProdInputUser.ActiveSheet.Cells[spdProdInputUser.ActiveSheet.RowCount - 1, (int)PROD_INPUT_LIST.LINE].Value = dt.Rows[i]["LINE"].ToString();                     // 라인
                    spdProdInputUser.ActiveSheet.Cells[spdProdInputUser.ActiveSheet.RowCount - 1, (int)PROD_INPUT_LIST.LINE_DESC].Value = dt.Rows[i]["LINE_DESC"].ToString();           // 라인 설명
                    spdProdInputUser.ActiveSheet.Cells[spdProdInputUser.ActiveSheet.RowCount - 1, (int)PROD_INPUT_LIST.RES_ID].Value = dt.Rows[i]["RES_ID"].ToString();                 // 장비
                    spdProdInputUser.ActiveSheet.Cells[spdProdInputUser.ActiveSheet.RowCount - 1, (int)PROD_INPUT_LIST.RES_DESC].Value = dt.Rows[i]["RES_DESC"].ToString();             // 장비 설명
                    spdProdInputUser.ActiveSheet.Cells[spdProdInputUser.ActiveSheet.RowCount - 1, (int)PROD_INPUT_LIST.COMPANY].Value = dt.Rows[i]["COMPANY"].ToString();               // 회사
                    spdProdInputUser.ActiveSheet.Cells[spdProdInputUser.ActiveSheet.RowCount - 1, (int)PROD_INPUT_LIST.WORKER].Value = dt.Rows[i]["TRAN_USER_ID"].ToString();               // 작업자
                    spdProdInputUser.ActiveSheet.Cells[spdProdInputUser.ActiveSheet.RowCount - 1, (int)PROD_INPUT_LIST.STD_START_TIME].Value = dt.Rows[i]["STD_START_TIME_1"].ToString(); // 표준 근무 시간 (분)
                    spdProdInputUser.ActiveSheet.Cells[spdProdInputUser.ActiveSheet.RowCount - 1, (int)PROD_INPUT_LIST.ADD_START_TIME].Value = dt.Rows[i]["ADD_START_TIME_1"].ToString(); // 추가 근무 (분)
                    spdProdInputUser.ActiveSheet.Cells[spdProdInputUser.ActiveSheet.RowCount - 1, (int)PROD_INPUT_LIST.EXCEPT_CODE].Value = dt.Rows[i]["EXCEPT_CODE"].ToString();       // 유실 코드
                    spdProdInputUser.ActiveSheet.Cells[spdProdInputUser.ActiveSheet.RowCount - 1, (int)PROD_INPUT_LIST.NON_START_TIME].Value = dt.Rows[i]["NON_START_TIME"].ToString(); // 유실 시작 시간
                    spdProdInputUser.ActiveSheet.Cells[spdProdInputUser.ActiveSheet.RowCount - 1, (int)PROD_INPUT_LIST.NON_END_TIME].Value = dt.Rows[i]["NON_END_TIME"].ToString();     // 유실 종료 시간
                    spdProdInputUser.ActiveSheet.Cells[spdProdInputUser.ActiveSheet.RowCount - 1, (int)PROD_INPUT_LIST.EXCEPT_TIME].Value = dt.Rows[i]["EXCEPT_TIME"].ToString();       // 유실 시간 (분)
                    spdProdInputUser.ActiveSheet.Cells[spdProdInputUser.ActiveSheet.RowCount - 1, (int)PROD_INPUT_LIST.WORK_TYPE].Value = dt.Rows[i]["WORK_TYPE"].ToString();           // 구분 유형
                }

                MPCF.FitColumnHeader(spdProdInputUser);

                spdProdInputUser.ActiveSheet.Columns[(int)PROD_INPUT_LIST.CHK].Visible = false;

                return true;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ProcessDownReport(char procStep)
        {
            TRSNode in_node = new TRSNode("CUS_PROCESS_DOWN_LIST_IN");
            TRSNode out_node = new TRSNode("CUS_PROCESS_DOWN_LIST_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = procStep;

                in_node.AddString("WORK_DATE", MPCF.Trim(dtpInputWorkTIme.GetValueAsString(8)));    // 작업시간
                in_node.AddString("LINE", MPCF.Trim(cdvInputLine.Text));    // 라인
                in_node.AddString("RES_ID", MPCF.Trim(cdvInputResID.Text));     // 장비
                in_node.AddString("COMPANY", MPCF.Trim(cdvInputCompany.Text));     // 회사
                in_node.AddString("TRAN_USER_ID", MPCF.Trim(cdvInputWorker.Text));     // 작업자

                in_node.AddString("STD_START_TIME", MPCF.Trim(dtpInputStandardTIme.Text));     // 표준 근무 시간 (분)
                in_node.AddString("ADD_START_TIME", MPCF.Trim(dtpInputExtraTIme.Text));     // 추가 근무 (분)
                in_node.AddString("EXCEPT_CODE", MPCF.Trim(cdvInputMissingCode.Text));      // 유실 코드

                in_node.AddString("NON_START_TIME", MPCF.Trim(dtpInputMissingStartHour.Text + dtpInputMissingStartMin.Text));  // 유실 시작 시간
                in_node.AddString("NON_END_TIME", MPCF.Trim(dtpInputMissingEndHour.Text + dtpInputMissingEndMin.Text));  // 유실 종료 시간
                in_node.AddInt("EXCEPT_TIME", MPCF.Trim(txtInputMissingTIme.Value));     // 유실 시간 (분)
                in_node.AddString("WORK_TYPE", MPCF.Trim(cdvInputWorkTypeCode.Text));     // 구분 유형

                if (MPCF.CallService("CUS", "CRAS_Process_Prod_Input_Info", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, true);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void GetGcmCode(object sender, string sTableName, string sHeader, string sHeaderDesc, RETURN_VALUE returnValue, string sKey = "")
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] dvcArgu;
            DataTable dt = new DataTable();

            try
            {
                if (returnValue == RETURN_VALUE.KEY)
                {
                    sViewID = "VIEW_GCM_DATA";
                    i_cond_cnt = 2;
                }
                else
                {
                    sViewID = "VIEW_GCM_DATA_KEY1";
                    i_cond_cnt = 3;
                }

                dvcArgu = new TPDR.DirectViewCond[i_cond_cnt];
                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TABLE_NAME";
                dvcArgu[1].sCondition_Value = sTableName;

                if (returnValue == RETURN_VALUE.DESC)
                {
                    dvcArgu[2].sCondtion_ID = "$KEY_1";
                    dvcArgu[2].sCondition_Value = MPCF.Trim(sKey);
                }

                // CodeView Column Header Setup
                string[] header = new string[] { sHeader, sHeaderDesc };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show by RPTServer

                if (sender.Equals(cdvInputCompany)) //회사
                {
                    if (returnValue == RETURN_VALUE.KEY)
                    {
                        cdvInputCompany.Text = cdvInputCompany.Show(cdvInputCompany, sHeader, sViewID, dvcArgu, display, header, "KEY_1", -1);

                        if (cdvInputCompany.returnDatas != null && cdvInputCompany.returnDatas.Count > 0)
                        {
                            cdvInputCompany.Tag = cdvInputCompany.returnDatas[0];
                            cdvInputCompany.Text = cdvInputCompany.returnDatas[0];
                            cdvInputCompanyDesc.Text = cdvInputCompany.returnDatas[1];
                        }
                    }
                    else
                    {
                        if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, dvcArgu, true) == false)
                        {
                            if (dt != null) { dt.Dispose(); }
                            GC.Collect();
                            return;
                        }
                        else
                        {
                            if (dt.Rows.Count > 0)
                                cdvInputCompanyDesc.Text = dt.Rows[0]["DATA_1"].ToString();
                        }
                    }
                }
                else if (sender.Equals(cdvCompany)) //조회조건 회사
                {
                    cdvCompany.Text = cdvCompany.Show(cdvInputCompany, sHeader, sViewID, dvcArgu, display, header, "KEY_1", -1);

                    if (cdvCompany.returnDatas != null && cdvCompany.returnDatas.Count > 0)
                    {
                        cdvCompany.Tag = cdvCompany.returnDatas[0];
                        cdvCompany.Text = cdvCompany.returnDatas[0];
                    }
                }
                else if (sender.Equals(cdvInputMissingCode)) //유실
                {
                    if (returnValue == RETURN_VALUE.KEY)
                    {
                        cdvInputMissingCode.Text = cdvInputMissingCode.Show(cdvInputMissingCode, sHeader, sViewID, dvcArgu, display, header, "KEY_1", -1);

                        if (cdvInputMissingCode.returnDatas != null && cdvInputMissingCode.returnDatas.Count > 0)
                        {
                            cdvInputMissingCode.Tag = cdvInputMissingCode.returnDatas[0];
                            cdvInputMissingCode.Text = cdvInputMissingCode.returnDatas[0];
                            txtInputMissingCodeDesc.Text = cdvInputMissingCode.returnDatas[1];
                        }
                    }
                    else
                    {
                        if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, dvcArgu, true) == false)
                        {
                            if (dt != null) { dt.Dispose(); }
                            GC.Collect();
                            return;
                        }
                        else
                        {
                            if (dt.Rows.Count > 0)
                                txtInputMissingCodeDesc.Text = dt.Rows[0]["DATA_1"].ToString();
                        }
                    }
                }
                else if (sender.Equals(cdvInputWorkTypeCode)) // 구분
                {
                    if (returnValue == RETURN_VALUE.KEY)
                    {
                        cdvInputWorkTypeCode.Text = cdvInputWorkTypeCode.Show(cdvInputWorkTypeCode, sHeader, sViewID, dvcArgu, display, header, "KEY_1", -1);

                        if (cdvInputWorkTypeCode.returnDatas != null && cdvInputWorkTypeCode.returnDatas.Count > 0)
                        {
                            cdvInputWorkTypeCode.Tag = cdvInputWorkTypeCode.returnDatas[0];
                            cdvInputWorkTypeCode.Text = cdvInputWorkTypeCode.returnDatas[0];
                            txtInputWorkTypeDesc.Text = cdvInputWorkTypeCode.returnDatas[1];
                        }
                    }
                    else
                    {
                        if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, dvcArgu, true) == false)
                        {
                            if (dt != null) { dt.Dispose(); }
                            GC.Collect();
                            return;
                        }
                        else
                        {
                            if (dt.Rows.Count > 0)
                                txtInputWorkTypeDesc.Text = dt.Rows[0]["DATA_1"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        #endregion

        #region [Event Definition]

        private void frmCUSTranProdInputManagement_Load(object sender, EventArgs e)
        {
            initCtrl();
        }

        private void frmCUSTranProdInputManagement_Shown(object sender, EventArgs e)
        {

        }

        private void cdvLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Code View Service
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);

                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(MPGC.MP_RAS_AREA_CODE));

                string[] display = new string[] { "KEY_1", "DATA_1" };

                string[] header = new string[] { "Line", "Line Desc" };

                if(sender.Equals(cdvLine))
                {
                    cdvLine.Text = cdvLine.Show(cdvLine, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Line");

                    if (cdvLine.returnDatas != null && cdvLine.returnDatas.Count > 0)
                    {
                        cdvLine.Tag = cdvLine.returnDatas[0];
                        cdvLine.Text = cdvLine.returnDatas[0];
                    }
                }
                else
                {
                    cdvInputLine.Text = cdvInputLine.Show(cdvInputLine, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Line");

                    if (cdvInputLine.returnDatas != null && cdvInputLine.returnDatas.Count > 0)
                    {
                        cdvInputLine.Tag = cdvInputLine.returnDatas[0];
                        cdvInputLine.Text = cdvInputLine.returnDatas[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvInputResID_CodeViewButtonClick(object sender, EventArgs e)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] dvcArgu;

            try
            {
                sViewID = "VIEW_RESOURCE_LIST";

                i_cond_cnt = 1;
                dvcArgu = new TPDR.DirectViewCond[i_cond_cnt];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                // CodeView Column Header Setup
                string[] header = new string[] { "RES_ID", "RES_DESC" };

                // CodeView Display Column Setup
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                // Show by RPTServer
                if (sender.Equals(cdvResID))
                {
                    cdvResID.Text = cdvResID.Show(cdvResID, "RESID", sViewID, dvcArgu, display, header, "RES_ID", -1);

                    if (cdvResID.returnDatas != null && cdvResID.returnDatas.Count > 0)
                    {
                        cdvResID.Tag = cdvResID.returnDatas[0];
                        cdvResID.Text = cdvResID.returnDatas[0];
                    }
                }
                else
                {
                    cdvInputResID.Text = cdvInputResID.Show(cdvInputResID, "RESID", sViewID, dvcArgu, display, header, "RES_ID", -1);

                    if (cdvInputResID.returnDatas != null && cdvInputResID.returnDatas.Count > 0)
                    {
                        cdvInputResID.Tag = cdvInputResID.returnDatas[0];
                        cdvInputResID.Text = cdvInputResID.returnDatas[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void ViewWorkerID(RETURN_VALUE returnValue)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] dvcArgu;
            DataTable dt = new DataTable();

            try
            {
                sViewID = "VIEW_WORKER_LIST";

                i_cond_cnt = 1;
                dvcArgu = new TPDR.DirectViewCond[i_cond_cnt];

                dvcArgu[0].sCondtion_ID = "$WORKER_ID";
                dvcArgu[0].sCondition_Value = MPCF.Trim(cdvInputWorker.Text);

                // CodeView Column Header Setup
                string[] header = new string[] { "Worker ID", "Worker Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "WORKER_ID", "WORKER_DESC" };

                // Show by RPTServer
                if (returnValue == RETURN_VALUE.KEY)
                {
                    cdvInputWorker.Text = cdvInputWorker.Show(cdvInputWorker, "WORKER_ID", sViewID, dvcArgu, display, header, "WORKER_ID", -1);

                    if (cdvInputWorker.returnDatas != null && cdvInputWorker.returnDatas.Count > 0)
                    {
                        cdvInputWorker.Tag = cdvInputWorker.returnDatas[0];
                        cdvInputWorker.Text = cdvInputWorker.returnDatas[0];
                        txtInputWorkerDesc.Text = cdvInputWorker.returnDatas[1];
                    }
                }
                else
                {
                    if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, dvcArgu, true) == false)
                    {
                        if (dt != null) { dt.Dispose(); }
                        GC.Collect();
                        return;
                    }
                    else
                    {
                        if (dt.Rows.Count > 0)
                            txtInputWorkerDesc.Text = dt.Rows[0]["WORKER_DESC"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvInputWorker_CodeViewButtonClick(object sender, EventArgs e)
        {
            ViewWorkerID(RETURN_VALUE.KEY);
        }

        private void spdProdInputUserList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (spdProdInputUser.ActiveSheet.RowCount < 1)
                    return;

                dtpInputWorkTIme.Value = MPCF.ToDate(spdProdInputUser.ActiveSheet.Cells[e.Row, (int)PROD_INPUT_LIST.WORK_DATE].Value.ToString()); // 작업시간
                cdvInputLine.Text = spdProdInputUser.ActiveSheet.Cells[e.Row, (int)PROD_INPUT_LIST.LINE].Value.ToString(); // 라인
                cdvInputResID.Text = spdProdInputUser.ActiveSheet.Cells[e.Row, (int)PROD_INPUT_LIST.RES_ID].Value.ToString(); // 장비
                cdvInputCompany.Text = spdProdInputUser.ActiveSheet.Cells[e.Row, (int)PROD_INPUT_LIST.COMPANY].Value.ToString(); // 회사
                cdvInputWorker.Text = spdProdInputUser.ActiveSheet.Cells[e.Row, (int)PROD_INPUT_LIST.WORKER].Value.ToString(); // 작업자
                dtpInputStandardTIme.Value = spdProdInputUser.ActiveSheet.Cells[e.Row, (int)PROD_INPUT_LIST.STD_START_TIME].Value.ToString(); // 표준 근무 시간 (분)
                dtpInputExtraTIme.Value = spdProdInputUser.ActiveSheet.Cells[e.Row, (int)PROD_INPUT_LIST.ADD_START_TIME].Value.ToString(); // 추가 근무 (분)
                cdvInputMissingCode.Text = spdProdInputUser.ActiveSheet.Cells[e.Row, (int)PROD_INPUT_LIST.EXCEPT_CODE].Value.ToString(); // 유실 코드

                // 유실 시작 시간
                if (MPCF.Trim(spdProdInputUser.ActiveSheet.Cells[e.Row, (int)PROD_INPUT_LIST.NON_START_TIME].Text) != "")
                {
                    gCellChk = true; // Value Change Event 차단
                    dtpInputMissingStartHour.Text = spdProdInputUser.ActiveSheet.Cells[e.Row, (int)PROD_INPUT_LIST.NON_START_TIME].Value.ToString().Substring(0, 2);
                    gCellChk = true; // Value Change Event 차단
                    dtpInputMissingStartMin.Text = spdProdInputUser.ActiveSheet.Cells[e.Row, (int)PROD_INPUT_LIST.NON_START_TIME].Value.ToString().Substring(2, 2);
                }

                // 유실 종료 시간
                if (MPCF.Trim(spdProdInputUser.ActiveSheet.Cells[e.Row, (int)PROD_INPUT_LIST.NON_END_TIME].Text) != "")
                {
                    gCellChk = true; // Value Change Event 차단
                    dtpInputMissingEndHour.Text = spdProdInputUser.ActiveSheet.Cells[e.Row, (int)PROD_INPUT_LIST.NON_END_TIME].Value.ToString().Substring(0, 2);
                    gCellChk = true; // Value Change Event 차단
                    dtpInputMissingEndMin.Text = spdProdInputUser.ActiveSheet.Cells[e.Row, (int)PROD_INPUT_LIST.NON_END_TIME].Value.ToString().Substring(2, 2);
                }

                txtInputMissingTIme.Value = spdProdInputUser.ActiveSheet.Cells[e.Row, (int)PROD_INPUT_LIST.EXCEPT_TIME].Value.ToString(); // 유실 시간 (분)
                cdvInputWorkTypeCode.Text = spdProdInputUser.ActiveSheet.Cells[e.Row, (int)PROD_INPUT_LIST.WORK_TYPE].Value.ToString();  // 구분 유형
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ViewProdInputUserList();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(btnCreate))
                {
                    if (CheckCondition(CSGC.MP_CHECK_CREATE) == false) return;

                    if(ProcessDownReport(MPGC.MP_STEP_CREATE))
                        ViewProdInputUserList();
                }
                else if (sender.Equals(btnEdit))
                {
                    if (CheckCondition(CSGC.MP_CHECK_UPDATE) == false) return;

                    if(ProcessDownReport(MPGC.MP_STEP_UPDATE))
                        ViewProdInputUserList();
                }
                else if (sender.Equals(btnDelete))
                {
                    if (CheckCondition(CSGC.MP_CHECK_DELETE) == false) return;

                    if (ProcessDownReport(MPGC.MP_STEP_DELETE))
                    {
                        initCtrl();
                        ViewProdInputUserList();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            initCtrl();
        }

        private void dtpShutDownTIme_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (gCellChk)
                {
                    gCellChk = false;
                    return;
                }

                if (!string.IsNullOrEmpty(dtpInputMissingStartHour.Text) && !string.IsNullOrEmpty(dtpInputMissingStartMin.Text)
                    && !string.IsNullOrEmpty(dtpInputMissingEndHour.Text) && !string.IsNullOrEmpty(dtpInputMissingEndMin.Text))
                {

                    DateTime dtNowTime;
                    DateTime dtPreTime;

                    DateTime.TryParse(dtpInputMissingStartHour.Text + ":" + dtpInputMissingStartMin.Text + ":" + "0", out dtNowTime);
                    DateTime.TryParse(dtpInputMissingEndHour.Text + ":" + dtpInputMissingEndMin.Text + ":" + "0", out dtPreTime);

                    TimeSpan timeDiff = dtNowTime - dtPreTime;

                    if (timeDiff.TotalMinutes * (-1) < 0)
                    {
                        dtpInputMissingStartHour.SelectedIndex = 0;
                        dtpInputMissingStartMin.SelectedIndex = 0;

                        MPCF.ShowMsgBox(MPCF.GetMessage(371));
                    }
                    else
                    {
                        txtInputMissingTIme.Value = timeDiff.TotalMinutes * (-1);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvInputValue_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(cdvInputCompany)) //회사
                {
                    GetGcmCode(sender, "C@COMPANY", "Company Code", "Company Desc", RETURN_VALUE.KEY);
                }
                else if (sender.Equals(cdvCompany)) //조회조건 회사
                {
                    GetGcmCode(sender, "C@COMPANY", "Company Code", "Company Desc", RETURN_VALUE.KEY);
                }
                else if (sender.Equals(cdvInputMissingCode)) //유실
                {
                    GetGcmCode(sender, "C@EXCEPT_CODE", "Except Code", "Except Desc", RETURN_VALUE.KEY);
                }
                else if (sender.Equals(cdvInputWorkTypeCode)) // 구분
                {
                    GetGcmCode(sender, "C@WORK_TYPE", "Work Type Code", "Work Type Desc", RETURN_VALUE.KEY);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvInputWorker_ValueChanged(object sender, EventArgs e)
        {
            ViewWorkerID(RETURN_VALUE.DESC);
        }

        private void cdvInputValue_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(cdvInputCompany)) //회사
                {
                    GetGcmCode(sender, "C@COMPANY", "Company Code", "Company Desc", RETURN_VALUE.DESC, cdvInputCompany.Text);
                }
                else if (sender.Equals(cdvCompany)) //조회조건 회사
                {
                    GetGcmCode(sender, "C@COMPANY", "Company Code", "Company Desc", RETURN_VALUE.DESC, cdvCompany.Text);
                }
                else if (sender.Equals(cdvInputMissingCode)) //유실
                {
                    GetGcmCode(sender, "C@EXCEPT_CODE", "Except Code", "Except Desc", RETURN_VALUE.DESC, cdvInputMissingCode.Text);
                }
                else if (sender.Equals(cdvInputWorkTypeCode)) // 구분
                {
                    GetGcmCode(sender, "C@WORK_TYPE", "Work Type Code", "Work Type Desc", RETURN_VALUE.DESC, cdvInputWorkTypeCode.Text);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        #endregion
    } 
}
