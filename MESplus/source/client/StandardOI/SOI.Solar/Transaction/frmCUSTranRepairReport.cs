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
    public partial class frmCUSTranRepairReport : SOIBaseForm03
    {
        #region [Property]

        SaveValues saveValues;

        #endregion

        public frmCUSTranRepairReport()
        {
            InitializeComponent();
        }
        
        #region [Constant Definition]

        public struct SaveValues
        {
            public string RES_ID;             // 설비
            public string DOWN_START_TIME;    // 고장일
            public string DOWN_GROUP_CODE;    // 고장원인분류
            public string DOWN_CODE;          // 고장코드
            public string REPAIR_START_TIME;  // 착수일
            public string REPAIR_END_TIME;    // 완료일
            public string REPAIR_INTERVAL;    // 소요시간
            public string STOP_INTERVAL;      // 정지시간
            public string DOWN_INTERVAL;      // 총 투입 시간
            public string TOTAL_AMOUNT;       // 자재비용
            public string REPAIR_TRAN_COMMENT;// 작업내용
            public string DOWN_TRAN_COMMENT;  // 고장원인 파악
            public string COMMENT_1;          // 특이사항
            public string DOWN_HIST_SEQ;       // 이력시퀀스
        }

        private enum DOWN_HISTORY
        {
            RES_ID,             // 설비
            DOWN_START_TIME,    // 고장일
            DOWN_GROUP_CODE,    // 고장원인분류
            DOWN_CODE,          // 고장코드
            REPAIR_START_TIME,  // 착수일
            REPAIR_END_TIME,    // 완료일
            REPAIR_INTERVAL,    // 소요시간
            STOP_INTERVAL,      // 정지시간
            DOWN_INTERVAL,      // 총 투입 시간
            TOTAL_AMOUNT,       // 자재비용
            REPAIR_TRAN_COMMENT,// 작업내용
            DOWN_TRAN_COMMENT,  // 고장원인 파악
            COMMENT_1,          // 특이사항
            DOWN_HIST_SEQ,       // 이력시퀀스
            SAVE_FLAG
        }

        private enum TOOL_LIST
        {
            CHK,        // 체크박스
            TOOL_ID,    // 품번
            TOOL_DESC,   // 품명
            STANDARD,   // 규격
            TOOL_QTY,   // 수량
            TOOL_AMOUNT // 품목비용
        }

        private enum CAUSE_TYPE
        {
            TYPE,
            CODE
        }

        #endregion

        #region [Variable Definition]

        public string gFactory { private get; set; } // LOT ID
        public string gResID { private get; set; } // LOT ID
        public string gDownHistSeq { private get; set; } // LOT ID

        #endregion

        #region [FormDefinition]

        private void initCtrl()
        {
            try
            {
                MPCF.ConvertCaption(this);
                MPCF.FieldClear(this);
                dtpDownTime.Value = DateTime.Now;
                dtpRepairStartTime.Value = DateTime.Now;
                dtpRepairEndTime.Value = DateTime.Now;

                saveValues = new SaveValues();
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

                        if (string.IsNullOrEmpty(cdvResID.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(410));
                            return false;
                        }

                        break;

                    case CSGC.MP_CHECK_UPDATE:
                    case CSGC.MP_CHECK_CREATE:

                        if (!CheckValuesEmpty())
                            return false;

                        break;

                    case CSGC.MP_CHECK_DELETE:

                        if (string.IsNullOrEmpty(MPCF.Trim(cdvResID.Text))) // 장비
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(410));
                            return false;
                        }

                        if (string.IsNullOrEmpty(MPCF.Trim(txtDownHistSeq.Text))) // 시퀀스
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(122));
                            return false;
                        }

                        if (string.IsNullOrEmpty(MPCF.Trim(cdvWorkUser.Text))) // 작성자
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(107));
                            MPCF.SetFocus(cdvWorkUser);
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
                if (string.IsNullOrEmpty(MPCF.Trim(cdvResID.Text))) // 장비
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(410));
                    return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(cdvCauseType.Text))) // 고장원인분류
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(427));
                    return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(cdvCauseCode.Text))) // 고장코드
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(428));
                    return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(txtRepInterval.Text))) // 소요시간
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(429));
                    return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(txtStopInterval.Text))) // 정지시간
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(430));
                    return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(txtDownInterval.Text))) // 총 투입시간
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(431));
                    return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(txtTotalAmount.Text))) // 자재비용
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(432));
                    return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(txtWorkContent.Text))) // 작업내용
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(433));
                    return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(txtIdentifyCause.Text))) // 고장원인파악
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(434));
                    return false;
                }

                if (string.IsNullOrEmpty(MPCF.Trim(txtIdentifyCause.Text))) // 고장원인파악
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(434));
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

        private bool ViewDownHistReport(ref DataTable repairDt)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] dvcArgu;
            string s_sql = "";

            try
            {
                sViewID = "VIEW_RESOURCE_DOWN_REPORT";

                i_cond_cnt = 4;
                dvcArgu = new TPDR.DirectViewCond[i_cond_cnt];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$RES_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(cdvResID.Text);

                dvcArgu[2].sCondtion_ID = "$DOWN_START_DATE";
                dvcArgu[2].sCondition_Value = MPCF.Trim(this.dtpDownTime.GetValueAsString(8) + "080000");

                dvcArgu[3].sCondtion_ID = "$DOWN_END_DATE";
                dvcArgu[3].sCondition_Value = DateTime.Parse(dtpDownTime.Value.ToString()).AddDays(1).ToString("yyyyMMdd") + "075959";

                if (TPDR.GetDataOne("", ref repairDt, sViewID, dvcArgu, false, false, ref s_sql) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(244));

                    if (repairDt != null)
                        repairDt.Dispose();

                    GC.Collect();
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool ViewDownHistReport(ref DataTable repairDt, string seq)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] dvcArgu;
            string s_sql = "";

            try
            {
                sViewID = "VIEW_RESOURCE_DOWN_SEQ";

                i_cond_cnt = 3;
                dvcArgu = new TPDR.DirectViewCond[i_cond_cnt];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$RES_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(cdvResID.Text);

                dvcArgu[2].sCondtion_ID = "$DOWN_HIST_SEQ";
                dvcArgu[2].sCondition_Value = MPCF.Trim(seq);

                if (TPDR.GetDataOne("", ref repairDt, sViewID, dvcArgu, false, false, ref s_sql) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(122));

                    if (repairDt != null)
                        repairDt.Dispose();

                    GC.Collect();
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private void SetRepairReport(DataTable repairDt)
        {
            try
            {
                cdvResID.Text           = repairDt.Rows[0][(int)DOWN_HISTORY.RES_ID].ToString();            // 설비
                dtpDownTime.Value       = MPCF.ToDate(repairDt.Rows[0][(int)DOWN_HISTORY.DOWN_START_TIME].ToString().Substring(0, 8));   // 고장일
                cdvCauseType.Text       = repairDt.Rows[0][(int)DOWN_HISTORY.DOWN_GROUP_CODE].ToString();   // 고장원인분류
                cdvCauseCode.Text       = repairDt.Rows[0][(int)DOWN_HISTORY.DOWN_CODE].ToString();         // 고장코드
                
                if (MPCF.Trim(repairDt.Rows[0][(int)DOWN_HISTORY.REPAIR_START_TIME].ToString()) != "")
                {
                    dtpRepairStartTime.Value = MPCF.ToDate(repairDt.Rows[0][(int)DOWN_HISTORY.REPAIR_START_TIME].ToString().Substring(0, 8)); // 착수일
                }
                if (MPCF.Trim(repairDt.Rows[0][(int)DOWN_HISTORY.REPAIR_END_TIME].ToString()) != "")
                {
                    dtpRepairEndTime.Value = MPCF.ToDate(repairDt.Rows[0][(int)DOWN_HISTORY.REPAIR_END_TIME].ToString().Substring(0, 8));   // 완료일
                }
                
                txtRepInterval.Text     = repairDt.Rows[0][(int)DOWN_HISTORY.REPAIR_INTERVAL].ToString();   // 소요시간
                txtStopInterval.Text    = repairDt.Rows[0][(int)DOWN_HISTORY.STOP_INTERVAL].ToString();     // 정지시간
                txtDownInterval.Text    = repairDt.Rows[0][(int)DOWN_HISTORY.DOWN_INTERVAL].ToString();     // 총 투입시간
                txtTotalAmount.Text     = repairDt.Rows[0][(int)DOWN_HISTORY.TOTAL_AMOUNT].ToString();      // 자재비용
                txtWorkContent.Text     = repairDt.Rows[0][(int)DOWN_HISTORY.REPAIR_TRAN_COMMENT].ToString();// 작업내용
                txtIdentifyCause.Text   = repairDt.Rows[0][(int)DOWN_HISTORY.DOWN_TRAN_COMMENT].ToString();// 고장원인 파악
                txtUniqueness.Text      = repairDt.Rows[0][(int)DOWN_HISTORY.COMMENT_1].ToString();         // 특이사항
                txtDownHistSeq.Text     = repairDt.Rows[0][(int)DOWN_HISTORY.DOWN_HIST_SEQ].ToString();         // 이력 시퀀스
                cdvType.Text = repairDt.Rows[0]["RES_GRP"].ToString();
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private bool SetRepairTool(DataTable repairDt)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] dvcArgu;
            DataTable dt = null;
            string s_sql = "";
            MPCF.ClearList(this.spdToolList);

            try
            {
                sViewID = "VIEW_RESOURCE_DOWN_REPORT_TOOL";

                i_cond_cnt = 3;
                dvcArgu = new TPDR.DirectViewCond[i_cond_cnt];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$RES_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(cdvResID.Text);

                dvcArgu[2].sCondtion_ID = "$DOWN_HIST_SEQ";
                dvcArgu[2].sCondition_Value = MPCF.Trim(repairDt.Rows[0][(int)DOWN_HISTORY.DOWN_HIST_SEQ].ToString());

                if (TPDR.GetDataOne("", ref dt, sViewID, dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                if (dt.Rows.Count > 0)
                {
                    AddTool(dt, '1');
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool ViewToolList(DataTable repairDt)
        {
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] dvcArgu;
            DataTable dt = null;
            string s_sql = "";
            MPCF.ClearList(this.spdToolList);

            try
            {
                sViewID = "VIEW_TOOL_LIST";
                dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TOOL_TYPE";
                dvcArgu[1].sCondition_Value = MPCF.Trim(cdvResID.Text);

                if (TPDR.GetDataOne("", ref dt, sViewID, dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                if (dt.Rows.Count > 0)
                {
                    AddTool(dt, '2');
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private void AddTool(DataTable toolDt, char cStep)
        {
            try
            {
                int i_total_amount = 0;

                for (int r = 0; r < toolDt.Rows.Count; r++)
                {
                    spdToolList.ActiveSheet.RowCount++;

                    if (cStep == '1')
                    {
                        spdToolList.ActiveSheet.Cells[r, (int)TOOL_LIST.TOOL_ID].Value = toolDt.Rows[r][(int)TOOL_LIST.TOOL_ID].ToString();
                        spdToolList.ActiveSheet.Cells[r, (int)TOOL_LIST.TOOL_DESC].Value = toolDt.Rows[r][(int)TOOL_LIST.TOOL_DESC].ToString();
                        spdToolList.ActiveSheet.Cells[r, (int)TOOL_LIST.STANDARD].Value = toolDt.Rows[r][(int)TOOL_LIST.STANDARD].ToString();
                        spdToolList.ActiveSheet.Cells[r, (int)TOOL_LIST.TOOL_QTY].Value = toolDt.Rows[r][(int)TOOL_LIST.TOOL_QTY].ToString();
                        spdToolList.ActiveSheet.Cells[r, (int)TOOL_LIST.TOOL_AMOUNT].Value = toolDt.Rows[r][(int)TOOL_LIST.TOOL_AMOUNT].ToString();
                        i_total_amount += MPCF.ToInt(toolDt.Rows[r][(int)TOOL_LIST.TOOL_AMOUNT].ToString());
                    }
                    else
                    {
                        spdToolList.ActiveSheet.Cells[r, (int)TOOL_LIST.TOOL_ID].Value = toolDt.Rows[r]["TOOL_ID"].ToString();
                        spdToolList.ActiveSheet.Cells[r, (int)TOOL_LIST.TOOL_DESC].Value = toolDt.Rows[r]["TOOL_DESC"].ToString();  //규격
                        spdToolList.ActiveSheet.Cells[r, (int)TOOL_LIST.STANDARD].Value = toolDt.Rows[r]["TOOL_STS_2"].ToString();  //규격
                        spdToolList.ActiveSheet.Cells[r, (int)TOOL_LIST.TOOL_QTY].Value = toolDt.Rows[r]["TOOL_STS_6"].ToString();  //수량
                        spdToolList.ActiveSheet.Cells[r, (int)TOOL_LIST.TOOL_AMOUNT].Value = toolDt.Rows[r]["TOOL_STS_4"].ToString(); //비용
                        i_total_amount += MPCF.ToInt(toolDt.Rows[r]["TOOL_STS_4"].ToString());
                    }
                }

                txtTotalAmount.Value = i_total_amount.ToString();
                spdToolList.ActiveSheet.Columns[(int)TOOL_LIST.CHK].Width = 35;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private bool ProcessDownReport(char procStep)
        {
            TRSNode in_node = new TRSNode("CUS_PROCESS_DOWN_LIST_IN");
            TRSNode out_node = new TRSNode("CUS_PROCESS_DOWN_LIST_OUT");
            TRSNode list_item;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = procStep;

                in_node.AddString("RES_ID", MPCF.Trim(saveValues.RES_ID));
                in_node.AddString("DOWN_START_TIME", MPCF.Trim(saveValues.DOWN_START_TIME));
                in_node.AddString("DOWN_GROUP_CODE", MPCF.Trim(saveValues.DOWN_GROUP_CODE));
                in_node.AddString("DOWN_CODE", MPCF.Trim(saveValues.DOWN_CODE));
                in_node.AddString("REPAIR_START_TIME", MPCF.Trim(saveValues.REPAIR_START_TIME));

                in_node.AddString("REPAIR_END_TIME", MPCF.Trim(saveValues.REPAIR_END_TIME));
                in_node.AddInt("REPAIR_INTERVAL", MPCF.Trim(saveValues.REPAIR_INTERVAL));
                in_node.AddInt("STOP_INTERVAL", MPCF.Trim(saveValues.STOP_INTERVAL));
                in_node.AddInt("DOWN_INTERVAL", MPCF.Trim(saveValues.DOWN_INTERVAL));
                in_node.AddInt("TOTAL_AMOUNT", MPCF.Trim(saveValues.TOTAL_AMOUNT));

                in_node.AddString("REPAIR_TRAN_COMMENT", MPCF.Trim(saveValues.REPAIR_TRAN_COMMENT));
                in_node.AddString("DOWN_TRAN_COMMENT", MPCF.Trim(saveValues.DOWN_TRAN_COMMENT));
                in_node.AddString("COMMENT_1", MPCF.Trim(saveValues.COMMENT_1));
                in_node.AddInt("DOWN_HIST_SEQ", MPCF.Trim(saveValues.DOWN_HIST_SEQ));
                in_node.AddString("WORK_USER", MPCF.Trim(cdvWorkUser.Text));

                for (int i = 0; i < spdToolList.ActiveSheet.RowCount; i++)
                {
                    list_item = in_node.AddNode("TOOL_LIST");
                    list_item.AddString("TOOL_ID", MPCF.Trim(spdToolList.ActiveSheet.Cells[i, (int)TOOL_LIST.TOOL_ID].Value));
                    list_item.AddString("STANDARD", MPCF.Trim(spdToolList.ActiveSheet.Cells[i, (int)TOOL_LIST.STANDARD].Value));
                    list_item.AddInt("TOOL_QTY", MPCF.Trim(spdToolList.ActiveSheet.Cells[i, (int)TOOL_LIST.TOOL_QTY].Value));
                    list_item.AddInt("TOOL_AMOUNT", MPCF.Trim(spdToolList.ActiveSheet.Cells[i, (int)TOOL_LIST.TOOL_AMOUNT].Value));
                }

                if (MPCF.CallService("CUS", "CRAS_Process_Down_Report", in_node, ref out_node) == false)
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

        private void ProcessSaveValues()
        {
            saveValues = new SaveValues();
            saveValues.RES_ID = MPCF.Trim(cdvResID.Text);
            saveValues.DOWN_START_TIME = MPCF.Trim(dtpDownTime.GetValueAsString(8));
            saveValues.DOWN_GROUP_CODE = MPCF.Trim(cdvCauseType.Text);
            saveValues.DOWN_CODE = MPCF.Trim(cdvCauseCode.Text);
            saveValues.REPAIR_START_TIME = MPCF.Trim(dtpRepairStartTime.GetValueAsString(8));
            saveValues.REPAIR_END_TIME = MPCF.Trim(dtpRepairEndTime.GetValueAsString(8));
            saveValues.REPAIR_INTERVAL = MPCF.Trim(txtRepInterval.Value);
            saveValues.STOP_INTERVAL = MPCF.Trim(txtStopInterval.Value);
            saveValues.DOWN_INTERVAL = MPCF.Trim(txtDownInterval.Value);
            saveValues.TOTAL_AMOUNT = MPCF.Trim(txtTotalAmount.Value);
            saveValues.REPAIR_TRAN_COMMENT = MPCF.Trim(txtWorkContent.Text);
            saveValues.DOWN_TRAN_COMMENT = MPCF.Trim(txtIdentifyCause.Text);
            saveValues.COMMENT_1 = MPCF.Trim(txtUniqueness.Text);
            saveValues.DOWN_HIST_SEQ = MPCF.Trim(txtDownHistSeq.Text) == "" ? "99999" : MPCF.Trim(txtDownHistSeq.Text);
        }

        private void SetDownReport()
        {
            if (!string.IsNullOrEmpty(gFactory) && !string.IsNullOrEmpty(gResID) && !string.IsNullOrEmpty(gDownHistSeq))
            {
                cdvResID.Text = gResID;

                DataTable repairDt = new DataTable();

                if (ViewDownHistReport(ref repairDt, gDownHistSeq) == true)
                {
                    SetRepairReport(repairDt);

                    //고장 수리 보고서 저장 이력이 있을경우
                    //if (repairDt.Rows[0][(int)DOWN_HISTORY.SAVE_FLAG].ToString() == "Y") // 테이블 상이함
                    //{
                        SetRepairTool(repairDt);
                    //}
                    //else
                    //{
                    //    ViewToolList(repairDt);
                    //}
                }
            }
        }

        #endregion

        #region [Event Definition]

        private void frmCUSTranRepairReport_Load(object sender, EventArgs e)
        {
            initCtrl();
            SetDownReport();
        }

        private void frmCUSTranRepairReport_Shown(object sender, EventArgs e)
        {

        }

        private void cdvType_CodeViewButtonClick(object sender, EventArgs e)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] dvcArgu;

            try
            {
                sViewID = "VIEW_RES_DOWN_TYPE";

                i_cond_cnt = 1;
                dvcArgu = new TPDR.DirectViewCond[i_cond_cnt];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                // CodeView Column Header Setup
                string[] header = new string[] { "RES_TYPE", "RES_TYPE" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show by RPTServer
                cdvType.Text = cdvType.Show(cdvType, "RESTYPE", sViewID, dvcArgu, display, header, "KEY_1", -1);

                if (cdvType.returnDatas != null && cdvType.returnDatas.Count > 0)
                {
                    cdvType.Tag = cdvType.returnDatas[0];
                    cdvType.Text = cdvType.returnDatas[0];
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvResID_CodeViewButtonClick(object sender, EventArgs e)
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
                cdvResID.Text = cdvResID.Show(cdvResID, "RESID", sViewID, dvcArgu, display, header, "RES_ID", -1);

                if (cdvResID.returnDatas != null && cdvResID.returnDatas.Count > 0)
                {
                    cdvResID.Tag = cdvResID.returnDatas[0];
                    cdvResID.Text = cdvResID.returnDatas[0];
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void SetCauseDesc(CAUSE_TYPE type)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;
            string s_sql = "";

            TPDR.DirectViewCond[] dvcArgu;
            DataTable dt = new DataTable();

            try
            {
                sViewID = "VIEW_GCM_DATA_KEY1";
                i_cond_cnt = 3;

                dvcArgu = new TPDR.DirectViewCond[i_cond_cnt];
                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TABLE_NAME";

                if (type.Equals(CAUSE_TYPE.TYPE))
                {
                    dvcArgu[1].sCondition_Value = "C@EQ_DOWNGROUP";

                    dvcArgu[2].sCondtion_ID = "$KEY_1";
                    dvcArgu[2].sCondition_Value = MPCF.Trim(cdvCauseType.Text);
                }
                else if (type.Equals(CAUSE_TYPE.CODE))
                {
                    dvcArgu[1].sCondition_Value = "C@EQ_DOWNCODE";

                    dvcArgu[2].sCondtion_ID = "$KEY_1";
                    dvcArgu[2].sCondition_Value = MPCF.Trim(cdvCauseCode.Text);
                }

                if (TPDR.GetDataOne("", ref dt, sViewID, dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return;
                }

                if (type.Equals(CAUSE_TYPE.TYPE))
                    txtCauseTypeDesc.Text = dt.Rows[0]["DATA_1"].ToString();
                else if (type.Equals(CAUSE_TYPE.CODE))
                    txtCauseCodeDesc.Text = dt.Rows[0]["DATA_1"].ToString();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private bool AddToolCode()
        {
            try
            {
                DataTable dt = null;
                string s_sql = "";

                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TOOL_ID";
                dvcArgu[1].sCondition_Value = cdvToolID.Text;

                if (TPDR.GetDataOne("", ref dt, "VIEW_TOOL_DETAIL", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();

                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spdToolList.ActiveSheet.RowCount++;
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)TOOL_LIST.CHK].Value = true;
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)TOOL_LIST.TOOL_ID].Value = dt.Rows[i]["TOOL_ID"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)TOOL_LIST.TOOL_DESC].Value = dt.Rows[i]["TOOL_DESC"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)TOOL_LIST.STANDARD].Value = dt.Rows[i]["TOOL_SIZE"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)TOOL_LIST.TOOL_QTY].Value = dt.Rows[i]["TOOL_USE_CNT"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)TOOL_LIST.TOOL_AMOUNT].Value = dt.Rows[i]["TOOL_COST"].ToString();
                }

                MPCF.FitColumnHeader(spdToolList);

                spdToolList.ActiveSheet.Columns[(int)TOOL_LIST.CHK].Width = 35;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private void cdvCauseType_CodeViewButtonClick(object sender, EventArgs e)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] dvcArgu;
            DataTable dt = new DataTable();

            try
            {
                sViewID = "VIEW_GCM_DATA";
                i_cond_cnt = 2;

                dvcArgu = new TPDR.DirectViewCond[i_cond_cnt];
                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TABLE_NAME";
                dvcArgu[1].sCondition_Value = "C@EQ_DOWNGROUP";

                // CodeView Column Header Setup
                string[] header = new string[] { "Cause Type Code", "Cause Type Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show by RPTServer
                cdvCauseType.Text = cdvCauseType.Show(cdvCauseType, "Cause Type Code", sViewID, dvcArgu, display, header, "KEY_1", -1);

                if (cdvCauseType.returnDatas != null && cdvCauseType.returnDatas.Count > 0)
                {
                    cdvCauseType.Tag = cdvCauseType.returnDatas[0];
                    cdvCauseType.Text = cdvCauseType.returnDatas[0];
                    txtCauseTypeDesc.Text = cdvCauseType.returnDatas[1];
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvCauseCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] dvcArgu;

            try
            {
                sViewID = "VIEW_GCM_DATA";

                i_cond_cnt = 2;
                dvcArgu = new TPDR.DirectViewCond[i_cond_cnt];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TABLE_NAME";
                dvcArgu[1].sCondition_Value = "C@EQ_DOWNCODE";

                // CodeView Column Header Setup
                string[] header = new string[] { "Cause Code", "Cause Code Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show by RPTServer
                cdvCauseCode.Text = cdvCauseCode.Show(cdvCauseCode, "CauseCode", sViewID, dvcArgu, display, header, "KEY_1", -1);

                if (cdvCauseCode.returnDatas != null && cdvCauseCode.returnDatas.Count > 0)
                {
                    cdvCauseCode.Tag = cdvCauseCode.returnDatas[0];
                    cdvCauseCode.Text = cdvCauseCode.returnDatas[0];
                    txtCauseCodeDesc.Text = cdvCauseCode.returnDatas[1];
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition(CSGC.MP_CHECK_VIEW) == false) return;

                DataTable repairDt = new DataTable();

                if (MPCF.ToInt(gDownHistSeq) > 0)
                {
                    if (ViewDownHistReport(ref repairDt, gDownHistSeq) == true)
                    {
                        SetRepairReport(repairDt);
                        SetRepairTool(repairDt);
                    }
                }
                else
                {
                    if (ViewDownHistReport(ref repairDt) == true)
                    {
                        SetRepairReport(repairDt);

                        //고장 수리 보고서 저장 이력이 있을경우
                        if (repairDt.Rows[0][(int)DOWN_HISTORY.SAVE_FLAG].ToString() == "Y")
                        {
                            SetRepairTool(repairDt);
                        }
                        else
                        {
                            ViewToolList(repairDt);
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

        private void btnToolAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int i_total_amount = 0;

                for(int k=0; k < spdToolList.ActiveSheet.RowCount; k++)
                {
                    if(cdvToolID.Text == spdToolList.ActiveSheet.Cells[k, (int)TOOL_LIST.TOOL_ID].Text)
                    {
                        MPCF.ShowErrorMessage("동일한 TOOL이 리스트에 존재합니다.");
                        return;
                    }
                }

                AddToolCode();

                for (int r = 0; r < spdToolList.ActiveSheet.Rows.Count; r++)
                {
                    i_total_amount += MPCF.ToInt(spdToolList.ActiveSheet.Cells[r, (int)TOOL_LIST.TOOL_AMOUNT].Text.ToString());
                }

                txtTotalAmount.Value = i_total_amount.ToString();                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }            
        }

        private void btnToolDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int i_total_amount = 0;

                for (int r = spdToolList.ActiveSheet.RowCount - 1; r >= 0; r--)
                {
                    if (Convert.ToBoolean(spdToolList.ActiveSheet.Cells[r, (int)TOOL_LIST.CHK].Value))
                    {
                        spdToolList_Sheet1.RemoveRows(r, 1);
                    }
                }

                for (int r = 0; r < spdToolList.ActiveSheet.Rows.Count; r++)
                {
                    i_total_amount += MPCF.ToInt(spdToolList.ActiveSheet.Cells[r, (int)TOOL_LIST.TOOL_AMOUNT].Text.ToString());
                }

                txtTotalAmount.Value = i_total_amount.ToString();
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

        private void btnProcess_Click(object sender, EventArgs e)
        {
            

            if (sender.Equals(btnCreate))
            {
                if (CheckCondition(CSGC.MP_CHECK_CREATE) == false) return;

                ProcessSaveValues();
                ProcessDownReport(MPGC.MP_STEP_CREATE);
            }
            else if (sender.Equals(btnEdit))
            {
                if (CheckCondition(CSGC.MP_CHECK_UPDATE) == false) return;

                ProcessSaveValues();
                ProcessDownReport(MPGC.MP_STEP_UPDATE);
            }
            else if (sender.Equals(btnDelete))
            {
                if (CheckCondition(CSGC.MP_CHECK_DELETE) == false) return;

                ProcessSaveValues();

                if(ProcessDownReport(MPGC.MP_STEP_DELETE) == true)
                    initCtrl();
            }
        }

        private void cdvCombobox_ValueChanged(object sender, EventArgs e)
        {
            if (sender.Equals(cdvCauseType))
            {
                SetCauseDesc(CAUSE_TYPE.TYPE);
            }
            else if (sender.Equals(cdvCauseCode))
            {
                SetCauseDesc(CAUSE_TYPE.CODE);
            }
        }

        #endregion

        private void cdvToolID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TOOL_TYPE";
                dvcArgu[1].sCondition_Value = MPCF.Trim(cdvResID.Text);

                // CodeView Column Header Setup
                string[] header = new string[] { "Code", "Code Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "TOOL_ID", "TOOL_DESC" };

                // Show
                cdvToolID.Text = cdvToolID.Show(cdvToolID, "Code Desc", "VIEW_TOOL_LIST", dvcArgu, display, header, "TOOL_ID", -1);

                if (MPCF.Trim(cdvToolID.Text) != "")
                {
                    if (cdvToolID.returnDatas != null && cdvToolID.returnDatas.Count > 0)
                    {
                        cdvToolID.Text = cdvToolID.returnDatas[0];
                    }
                }
                else
                {
                    cdvToolID.Text = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }  
        }

        private void cdvWorkUser_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$USER_GROUP";
                dvcArgu[1].sCondition_Value = MPCF.Trim("PROD_TEC");

                // CodeView Column Header Setup
                string[] header = new string[] { "Code", "Code Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "USER_ID", "USER_DESC" };

                // Show
                cdvWorkUser.Text = cdvWorkUser.Show(cdvWorkUser, "Code Desc", "VIEW_USER_LIST", dvcArgu, display, header, "USER_ID", -1);

                if (MPCF.Trim(cdvWorkUser.Text) != "")
                {
                    if (cdvWorkUser.returnDatas != null && cdvWorkUser.returnDatas.Count > 0)
                    {
                        cdvWorkUser.Text = cdvWorkUser.returnDatas[0];
                    }
                }
                else
                {
                    cdvWorkUser.Text = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }  
        }
    } 
}
