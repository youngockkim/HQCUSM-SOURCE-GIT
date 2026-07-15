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
    public partial class frmCUSTranResOffManagement : SOIBaseForm03
    {
        #region [Property]

        private bool gCellChk = false;

        #endregion

        public frmCUSTranResOffManagement()
        {
            InitializeComponent();
        }
        
        #region [Constant Definition]

        private enum SHUT_DOWN_LIST
        {
            CHK,                   // 체크박스
            WORK_DATE,             // 작업시간
            LINE,                  // 라인
            SHIFT,                 // 작업조
            RES_ID,                // 장비
            RES_DESC,              // 장비 설명
            START_TIME,            // 비가동 시작시간
            START_TIME_FORMAT,     // 비가동 시작시간
            END_TIME,              // 비가동 종료시간
            END_TIME_FORMAT,       // 비가동 종료시간
            NON_TIME,              // 비가동 시간
            DT_CODE,               // 비가동 코드
            DT_DESC,               // 비가동 코드 설명
            TRAN_COMMENT           // 비고사항
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
                this.dtpFrom.Value = DateTime.Now.AddDays(-1);
                this.dtpTo.Value = DateTime.Now;
                this.dtpInputWorkTIme.Value = DateTime.Now;
                this.dtpInputShutStartDay.Value = DateTime.Now;
                this.dtpInputShutEndDay.Value = DateTime.Now;

                spdShutDownList.ActiveSheet.Columns[(int)SHUT_DOWN_LIST.CHK].Visible = false;
                spdShutDownList.ActiveSheet.Columns[(int)SHUT_DOWN_LIST.START_TIME].Visible = false;
                spdShutDownList.ActiveSheet.Columns[(int)SHUT_DOWN_LIST.END_TIME].Visible = false;
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

                        if (spdShutDownList.ActiveSheet.ActiveRowIndex < 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(272));
                            return false;
                        }

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

                        if (string.IsNullOrEmpty(MPCF.Trim(dtpInputShutStartHour.Text)) || string.IsNullOrEmpty(MPCF.Trim(dtpInputShutStartMin)))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(438));
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

                if (string.IsNullOrEmpty(MPCF.Trim(cdvInputShift.Text)))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(437));
                    return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(cdvInputResID.Text)))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(410));
                    return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(dtpInputShutStartHour.Text)) || string.IsNullOrEmpty(MPCF.Trim(dtpInputShutStartMin)))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(438));
                    return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(dtpInputShutEndHour.Text)) || string.IsNullOrEmpty(MPCF.Trim(dtpInputShutEndMin)))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(439));
                    return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(dtpInputShutDownTIme.Value)))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(440));
                    return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(dtpInputShutDownCode.Text)))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(441));
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

        private bool ViewShutDownList()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] dvcArgu;
            string s_sql = "";

            DataTable dt = new DataTable();
            MPCF.ClearList(this.spdShutDownList);

            try
            {
                sViewID = "VIEW_RES_SHUT_DOWN_LIST";

                i_cond_cnt = 6;
                dvcArgu = new TPDR.DirectViewCond[i_cond_cnt];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$LINE";
                dvcArgu[1].sCondition_Value = MPCF.Trim(cdvLine.Text);

                dvcArgu[2].sCondtion_ID = "$RES_ID";
                dvcArgu[2].sCondition_Value = MPCF.Trim(cdvResID.Text);

                dvcArgu[3].sCondtion_ID = "$DT_CODE";
                dvcArgu[3].sCondition_Value = MPCF.Trim(cdvShutDownCode.Text);

                dvcArgu[4].sCondtion_ID = "$WORK_START_DATE";
                dvcArgu[4].sCondition_Value = MPCF.Trim(this.dtpFrom.GetValueAsString(8));

                dvcArgu[5].sCondtion_ID = "$WORK_END_DATE";
                dvcArgu[5].sCondition_Value = MPCF.Trim(this.dtpTo.GetValueAsString(8));

                if (TPDR.GetDataOne("", ref dt, sViewID, dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spdShutDownList.ActiveSheet.RowCount++;
                    spdShutDownList.ActiveSheet.Cells[spdShutDownList.ActiveSheet.RowCount - 1, (int)SHUT_DOWN_LIST.CHK].Value = true;
                    spdShutDownList.ActiveSheet.Cells[spdShutDownList.ActiveSheet.RowCount - 1, (int)SHUT_DOWN_LIST.WORK_DATE].Value = dt.Rows[i]["WORK_DATE"].ToString();
                    spdShutDownList.ActiveSheet.Cells[spdShutDownList.ActiveSheet.RowCount - 1, (int)SHUT_DOWN_LIST.LINE].Value = dt.Rows[i]["LINE"].ToString();
                    spdShutDownList.ActiveSheet.Cells[spdShutDownList.ActiveSheet.RowCount - 1, (int)SHUT_DOWN_LIST.SHIFT].Value = dt.Rows[i]["SHIFT"].ToString();
                    spdShutDownList.ActiveSheet.Cells[spdShutDownList.ActiveSheet.RowCount - 1, (int)SHUT_DOWN_LIST.RES_ID].Value = dt.Rows[i]["RES_ID"].ToString();
                    spdShutDownList.ActiveSheet.Cells[spdShutDownList.ActiveSheet.RowCount - 1, (int)SHUT_DOWN_LIST.RES_DESC].Value = dt.Rows[i]["RES_DESC"].ToString();
                    spdShutDownList.ActiveSheet.Cells[spdShutDownList.ActiveSheet.RowCount - 1, (int)SHUT_DOWN_LIST.START_TIME].Value = dt.Rows[i]["START_TIME"].ToString();
                    spdShutDownList.ActiveSheet.Cells[spdShutDownList.ActiveSheet.RowCount - 1, (int)SHUT_DOWN_LIST.START_TIME_FORMAT].Value = dt.Rows[i]["START_TIME_FORMAT"].ToString();
                    spdShutDownList.ActiveSheet.Cells[spdShutDownList.ActiveSheet.RowCount - 1, (int)SHUT_DOWN_LIST.END_TIME].Value = dt.Rows[i]["END_TIME"].ToString();
                    spdShutDownList.ActiveSheet.Cells[spdShutDownList.ActiveSheet.RowCount - 1, (int)SHUT_DOWN_LIST.END_TIME_FORMAT].Value = dt.Rows[i]["END_TIME_FORMAT"].ToString();
                    spdShutDownList.ActiveSheet.Cells[spdShutDownList.ActiveSheet.RowCount - 1, (int)SHUT_DOWN_LIST.NON_TIME].Value = dt.Rows[i]["NON_TIME"].ToString();
                    spdShutDownList.ActiveSheet.Cells[spdShutDownList.ActiveSheet.RowCount - 1, (int)SHUT_DOWN_LIST.DT_CODE].Value = dt.Rows[i]["DT_CODE"].ToString();
                    spdShutDownList.ActiveSheet.Cells[spdShutDownList.ActiveSheet.RowCount - 1, (int)SHUT_DOWN_LIST.DT_DESC].Value = dt.Rows[i]["DT_DESC"].ToString();
                    spdShutDownList.ActiveSheet.Cells[spdShutDownList.ActiveSheet.RowCount - 1, (int)SHUT_DOWN_LIST.TRAN_COMMENT].Value = dt.Rows[i]["TRAN_COMMENT"].ToString();
                }

                MPCF.FitColumnHeader(spdShutDownList);

                spdShutDownList.ActiveSheet.Columns[(int)SHUT_DOWN_LIST.CHK].Visible = false;
                spdShutDownList.ActiveSheet.Columns[(int)SHUT_DOWN_LIST.START_TIME].Visible = false;
                spdShutDownList.ActiveSheet.Columns[(int)SHUT_DOWN_LIST.END_TIME].Visible = false;

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

                in_node.AddString("WORK_DATE", MPCF.Trim(dtpInputWorkTIme.GetValueAsString(8)));
                in_node.AddString("OLD_WORK_DATE", MPCF.Trim(txtOldWorkdate.Text));
                in_node.AddString("OLD_RES_ID", MPCF.Trim(txtOldResID.Text));
                in_node.AddString("LINE", MPCF.Trim(cdvInputLine.Text));
                in_node.AddString("SHIFT", MPCF.Trim(cdvInputShift.Text));
                in_node.AddString("RES_ID", MPCF.Trim(cdvInputResID.Text));
                in_node.AddString("START_TIME", MPCF.Trim(dtpInputShutStartDay.GetValueAsString(8) + dtpInputShutStartHour.Text + dtpInputShutStartMin.Text) + "00");
                in_node.AddString("END_TIME", MPCF.Trim(dtpInputShutEndDay.GetValueAsString(8) + dtpInputShutEndHour.Text + dtpInputShutEndMin.Text) + "00");
                in_node.AddString("NON_TIME", MPCF.Trim(dtpInputShutDownTIme.Value));
                in_node.AddString("DT_CODE", MPCF.Trim(dtpInputShutDownCode.Text));
                in_node.AddString("DT_DESC", MPCF.Trim(txtInputShutDownCodeDesc.Text));
                in_node.AddString("TRAN_COMMENT", MPCF.Trim(txtRemarks.Text));

                if (MPCF.CallService("CUS", "CRAS_Process_Shut_Down_Info", in_node, ref out_node) == false)
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

        #endregion

        #region [Event Definition]

        private void frmCUSTranResOffManagement_Load(object sender, EventArgs e)
        {
            initCtrl();
        }

        private void frmCUSTranResOffManagement_Shown(object sender, EventArgs e)
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

        private void cdvShutDownCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                ViewShutDownCode(sender, RETURN_VALUE.KEY);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvInputShift_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                ViewShiftCode(RETURN_VALUE.KEY);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void ViewShutDownCode(object sender, RETURN_VALUE returnVal, string strKey = "")
        {
            int i_cond_cnt = 0; ;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] dvcArgu;

            DataTable dt = new DataTable();

            try
            {
                if (returnVal == RETURN_VALUE.KEY)
                {
                    sViewID = "VIEW_GCM_DATA";
                    i_cond_cnt = 2;
                }
                else if (returnVal == RETURN_VALUE.DESC)
                {
                    sViewID = "VIEW_GCM_DATA_KEY1";
                    i_cond_cnt = 3;
                }

                dvcArgu = new TPDR.DirectViewCond[i_cond_cnt];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TABLE_NAME";
                dvcArgu[1].sCondition_Value = "C@NON_DT_CODE";

                if (returnVal == RETURN_VALUE.DESC)
                {
                    dvcArgu[2].sCondtion_ID = "$KEY_1";
                    dvcArgu[2].sCondition_Value = MPCF.Trim(strKey);
                }

                // CodeView Column Header Setup
                string[] header = new string[] { "Shut Down Code", "Shut Down Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show by RPTServer

                if (sender.Equals(cdvShutDownCode))
                {
                    cdvShutDownCode.Text = cdvShutDownCode.Show(cdvShutDownCode, "KEY_1", sViewID, dvcArgu, display, header, "KEY_1", -1);

                    if (cdvShutDownCode.returnDatas != null && cdvShutDownCode.returnDatas.Count > 0)
                    {
                        cdvShutDownCode.Tag = cdvShutDownCode.returnDatas[0];
                        cdvShutDownCode.Text = cdvShutDownCode.returnDatas[0];
                    }
                }
                else
                {
                    if (returnVal == RETURN_VALUE.KEY)
                    {
                        dtpInputShutDownCode.Text = dtpInputShutDownCode.Show(dtpInputShutDownCode, "KEY_1", sViewID, dvcArgu, display, header, "KEY_1", -1);

                        if (dtpInputShutDownCode.returnDatas != null && dtpInputShutDownCode.returnDatas.Count > 0)
                        {
                            dtpInputShutDownCode.Tag = dtpInputShutDownCode.returnDatas[0];
                            dtpInputShutDownCode.Text = dtpInputShutDownCode.returnDatas[0];
                            txtInputShutDownCodeDesc.Text = dtpInputShutDownCode.returnDatas[1];
                        }
                    }
                    else if (returnVal == RETURN_VALUE.DESC)
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
                                txtInputShutDownCodeDesc.Text = dt.Rows[0]["DATA_1"].ToString();
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

        private void ViewShiftCode(RETURN_VALUE returnVal, string strKey = "")
        {
            int i_cond_cnt = 0; ;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] dvcArgu;
            DataTable dt = new DataTable();

            try
            {
                if (returnVal == RETURN_VALUE.KEY)
                {
                    sViewID = "VIEW_SHIFT";
                    i_cond_cnt = 1;
                }
                else if (returnVal == RETURN_VALUE.DESC)
                {
                    sViewID = "VIEW_SHIFT_DESC";
                    i_cond_cnt = 2;
                }

                dvcArgu = new TPDR.DirectViewCond[i_cond_cnt];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                if (returnVal == RETURN_VALUE.DESC)
                {
                    dvcArgu[1].sCondtion_ID = "$KEY_1";
                    dvcArgu[1].sCondition_Value = MPCF.Trim(strKey);
                }

                // CodeView Column Header Setup
                string[] header = new string[] { "Shift Code", "Shift Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show by RPTServer
                if (returnVal == RETURN_VALUE.KEY)
                {
                    cdvInputShift.Text = cdvInputShift.Show(cdvInputShift, "KEY_1", sViewID, dvcArgu, display, header, "KEY_1", -1);

                    if (cdvInputShift.returnDatas != null && cdvInputShift.returnDatas.Count > 0)
                    {
                        cdvInputShift.Tag = cdvInputShift.returnDatas[1];
                        cdvInputShift.Text = cdvInputShift.returnDatas[1];
                        txtInputShiftDesc.Text = cdvInputShift.returnDatas[0];
                    }
                }
                else if (returnVal == RETURN_VALUE.DESC)
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
                            txtInputShiftDesc.Text = dt.Rows[0]["DATA_1"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void spdShutDownList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (spdShutDownList.ActiveSheet.RowCount < 1)
                    return;

                dtpInputWorkTIme.Value = MPCF.ToDate(spdShutDownList.ActiveSheet.Cells[e.Row, (int)SHUT_DOWN_LIST.WORK_DATE].Value.ToString()); // 작업시간
                txtOldWorkdate.Text = spdShutDownList.ActiveSheet.Cells[e.Row, (int)SHUT_DOWN_LIST.WORK_DATE].Value.ToString();
                cdvInputLine.Text = spdShutDownList.ActiveSheet.Cells[e.Row, (int)SHUT_DOWN_LIST.LINE].Value.ToString(); // 라인
                cdvInputShift.Text = spdShutDownList.ActiveSheet.Cells[e.Row, (int)SHUT_DOWN_LIST.SHIFT].Value.ToString(); // 작업조
                cdvInputResID.Text = spdShutDownList.ActiveSheet.Cells[e.Row, (int)SHUT_DOWN_LIST.RES_ID].Value.ToString(); // 장비
                txtOldResID.Text = spdShutDownList.ActiveSheet.Cells[e.Row, (int)SHUT_DOWN_LIST.RES_ID].Value.ToString(); // 장비
                
                // 비가동 시작 시간
                gCellChk = true; // Value Change Event 차단
                dtpInputShutStartDay.Value = MPCF.ToDate(spdShutDownList.ActiveSheet.Cells[e.Row, (int)SHUT_DOWN_LIST.START_TIME].Value.ToString().Substring(0, 8));
                gCellChk = true; // Value Change Event 차단
                dtpInputShutStartHour.Text = spdShutDownList.ActiveSheet.Cells[e.Row, (int)SHUT_DOWN_LIST.START_TIME].Value.ToString().Substring(8, 2);
                gCellChk = true; // Value Change Event 차단
                dtpInputShutStartMin.Text = spdShutDownList.ActiveSheet.Cells[e.Row, (int)SHUT_DOWN_LIST.START_TIME].Value.ToString().Substring(10, 2);
                
                // 비가동 종료 시간
                gCellChk = true; // Value Change Event 차단
                dtpInputShutEndDay.Value = MPCF.ToDate(spdShutDownList.ActiveSheet.Cells[e.Row, (int)SHUT_DOWN_LIST.END_TIME].Value.ToString().Substring(0, 8));
                gCellChk = true; // Value Change Event 차단
                dtpInputShutEndHour.Text = spdShutDownList.ActiveSheet.Cells[e.Row, (int)SHUT_DOWN_LIST.END_TIME].Value.ToString().Substring(8, 2);
                gCellChk = true; // Value Change Event 차단
                dtpInputShutEndMin.Text = spdShutDownList.ActiveSheet.Cells[e.Row, (int)SHUT_DOWN_LIST.END_TIME].Value.ToString().Substring(10, 2);

                dtpInputShutDownTIme.Value = spdShutDownList.ActiveSheet.Cells[e.Row, (int)SHUT_DOWN_LIST.NON_TIME].Value.ToString(); // 비가동 시간
                dtpInputShutDownCode.Text = spdShutDownList.ActiveSheet.Cells[e.Row, (int)SHUT_DOWN_LIST.DT_CODE].Value.ToString(); // 비가동 코드
                txtRemarks.Text = spdShutDownList.ActiveSheet.Cells[e.Row, (int)SHUT_DOWN_LIST.TRAN_COMMENT].Value.ToString(); // 비고
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ViewShutDownList();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(btnCreate))
                {
                    if (CheckCondition(CSGC.MP_CHECK_CREATE) == false) return;

                    if(ProcessDownReport(MPGC.MP_STEP_CREATE))
                        ViewShutDownList();
                }
                else if (sender.Equals(btnEdit))
                {
                    if (CheckCondition(CSGC.MP_CHECK_UPDATE) == false) return;

                    if(ProcessDownReport(MPGC.MP_STEP_UPDATE))
                        ViewShutDownList();
                }
                else if (sender.Equals(btnDelete))
                {
                    if (CheckCondition(CSGC.MP_CHECK_DELETE) == false) return;

                    if (ProcessDownReport(MPGC.MP_STEP_DELETE))
                    {
                        initCtrl();
                        ViewShutDownList();
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

                if (!string.IsNullOrEmpty(dtpInputShutStartHour.Text) && !string.IsNullOrEmpty(dtpInputShutStartMin.Text)
                    && !string.IsNullOrEmpty(dtpInputShutEndHour.Text) && !string.IsNullOrEmpty(dtpInputShutEndMin.Text))
                {

                    DateTime dtNowTime;
                    DateTime dtPreTime;

                    DateTime.TryParse(MPCF.ToDate(dtpInputShutStartDay.GetValueAsString(8)).ToString("yyyy-MM-dd") + " " + dtpInputShutStartHour.Text + ":" + dtpInputShutStartMin.Text + ":" + "0", out dtNowTime);
                    DateTime.TryParse(MPCF.ToDate(dtpInputShutEndDay.GetValueAsString(8)).ToString("yyyy-MM-dd") + " " + dtpInputShutEndHour.Text + ":" + dtpInputShutEndMin.Text + ":" + "0", out dtPreTime);

                    TimeSpan timeDiff = dtNowTime - dtPreTime;

                    if (timeDiff.TotalMinutes * (-1) < 0)
                    {
                        DateTime dtpToOut = new DateTime();

                        if (dtpInputShutEndDay.Value != null)
                        {
                            if (DateTime.TryParse(dtpInputShutEndDay.Value.ToString(), out dtpToOut)) { }
                        }

                        this.dtpInputShutStartDay.SetValueAsDateTime(dtpToOut.AddDays(-1));

                        DateTime.TryParse(MPCF.ToDate(dtpInputShutStartDay.GetValueAsString(8)).ToString("yyyy-MM-dd") + " " + dtpInputShutStartHour.Text + ":" + dtpInputShutStartMin.Text + ":" + "0", out dtNowTime);
                        DateTime.TryParse(MPCF.ToDate(dtpInputShutEndDay.GetValueAsString(8)).ToString("yyyy-MM-dd") + " " + dtpInputShutEndHour.Text + ":" + dtpInputShutEndMin.Text + ":" + "0", out dtPreTime);

                        timeDiff = dtNowTime - dtPreTime;
                        dtpInputShutDownTIme.Value = timeDiff.TotalMinutes * (-1);

                        MPCF.ShowMsgBox(MPCF.GetMessage(371));
                    }
                    else
                    {
                        dtpInputShutDownTIme.Value = timeDiff.TotalMinutes * (-1);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvInput_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(cdvInputShift))
                {
                    if (!string.IsNullOrEmpty(cdvInputShift.Text))
                        ViewShiftCode(RETURN_VALUE.DESC, cdvInputShift.Text);
                }
                else if (sender.Equals(dtpInputShutDownCode))
                {
                    ViewShutDownCode(sender, RETURN_VALUE.DESC, dtpInputShutDownCode.Text);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        #endregion
    } 
}
