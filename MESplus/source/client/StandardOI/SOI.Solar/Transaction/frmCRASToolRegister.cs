using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;

using SOI.DNM;
using BOI.OIFrx;

namespace SOI.Solar
{
    public partial class frmCRASToolRegister : SOIBaseForm02
    {
        #region Property

        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCRASToolRegister()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        private enum COL : int
        {
            CHK,
            TOOL_ID,
            TOOL_DESC,
            TOOL_MAT,
            TOOL_SIZE,
            TOOL_INSTALL_TIME,
            TOOL_IN_TIME,
            TOOL_COST,
            TOOL_USE_TIME,
            TOOL_USE_CNT,
            TOOL_DEFECT_CODE,
            TOOL_DEFECT_TIME,
            TOOL_TOTAL_TIME,
            TOOL_TOTAL_CNT
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
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);

            MPCF.ClearList(spdToolList);
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
        /// Resource ID CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvResID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                // Display and Header Text Setup
                string[] display = new string[] { "RES_ID", "RES_DESC" };
                string[] header = new string[] { "Res ID", "Res Desc" };

                // Show CodeView and Get Return
                cdvResID.Text = cdvResID.Show(cdvResID, "View Resource List", "RAS", "RAS_View_Resource_List", in_node, "RES_LIST", display, header, "Res ID");

                // Field Clear
                MPCF.FieldClear(this, cdvResID);

                // Validation
                if (string.IsNullOrEmpty(cdvResID.Text) == true)
                {
                    return;
                }

                // View Resource
                if (ViewResource(cdvResID.Text) == false)
                {
                    return;
                }

                // Focus
                //MPCF.SetFocus(cdvEventID);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvResID, false) == false)
                {
                    return;
                }

                // Event
                if (ToolChange('2') == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// View Resource
        /// </summary>
        /// <param name="sResId"></param>
        /// <returns></returns>
        private bool ViewResource(string sResId)
        {
            TRSNode in_node = new TRSNode("VIEW_RESOURCE_IN");
            TRSNode out_node = new TRSNode("VIEW_RESOURCE_OUT");

            try
            {
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", sResId);
                if (MPCF.CallService("RAS", "RAS_View_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Bind
                txtResDesc.Text = MPCF.Trim(out_node.GetString("RES_DESC"));
                txtLastEvent.Text = MPCF.Trim(out_node.GetString("LAST_EVENT_ID"));
                txtLastEventTime.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_EVENT_TIME"));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ViewToolInputList()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            try
            {
                MPCF.ClearList(spdToolList);
                cdvToolID.Text = "";
                txtToolDesc.Text = "";

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$RES_ID";
                dvcArgu[1].sCondition_Value = cdvResID.Text;

                if (TPDR.GetDataOne("", ref dt, "VIEW_INPUT_TOOL_LIST", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                //현재 설비에 장착되어 있는 툴리스트
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spdToolList.ActiveSheet.RowCount++;
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.CHK].Value = true;
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_ID].Value = dt.Rows[i]["TOOL_ID"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_DESC].Value = dt.Rows[i]["TOOL_DESC"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_MAT].Value = dt.Rows[i]["TOOL_MAT"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_SIZE].Value = dt.Rows[i]["TOOL_SIZE"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_INSTALL_TIME].Value = dt.Rows[i]["TOOL_INSTALL_TIME"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_IN_TIME].Value = dt.Rows[i]["TOOL_IN_TIME"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_COST].Value = dt.Rows[i]["TOOL_COST"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_USE_TIME].Value = dt.Rows[i]["TOOL_USE_TIME"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_USE_CNT].Value = dt.Rows[i]["TOOL_USE_CNT"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_DEFECT_CODE].Value = dt.Rows[i]["TOOL_DEFECT_CODE"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_DEFECT_TIME].Value = dt.Rows[i]["TOOL_DEFECT_TIME"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_TOTAL_TIME].Value = dt.Rows[i]["TOOL_TOTAL_TIME"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_TOTAL_CNT].Value = dt.Rows[i]["TOOL_TOTAL_CNT"].ToString();
                }

                MPCF.FitColumnHeader(spdToolList);
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Resource Event
        /// </summary>
        /// <param name="cProcStep"></param>
        /// <returns></returns>
        private bool ToolChange(char cProcStep)
        {
            TRSNode in_node = new TRSNode("RESOURCE_EVENT_IN");
            TRSNode out_node = new TRSNode("RESOURCE_EVENT_OUT");
            TRSNode data_list = null;
            int i_cnt = 0;

            try
            {
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = cProcStep;
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));

                for(int k =0; k < spdToolList.ActiveSheet.RowCount; k++)
                {
                    if (Convert.ToBoolean(spdToolList.ActiveSheet.Cells[k, (int)COL.CHK].Value) == true)
                    {
                        data_list = in_node.AddNode("DATA_LIST");
                        data_list.AddString("TOOL_ID", spdToolList.ActiveSheet.Cells[k, (int)COL.TOOL_ID].Text);

                        i_cnt++;
                    }
                }

                if(i_cnt == 0)
                {
                    MPCF.ShowErrorMessage("선택된 TOOL ID가 없습니다.");
                    return false;
                }

                if (MPCF.CallService("CUS", "CRAS_Tool_Management", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    MPCF.CheckContinueProc(out_node, false);
                    return false;
                }

                // Field Clear
                MPCF.FieldClear(this, cdvResID);

                // View Resource
                if (ViewResource(cdvResID.Text) == false)
                {
                    return false;
                }

                // Clear Field
                ClearField(1);

                MPCF.ShowSuccessMessage(out_node, false);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Clear Field
        /// </summary>
        /// <param name="iCase"></param>
        private void ClearField(int iCase)
        {
            switch (iCase)
            {
                case 1:

                    break;
            }
        }

        #endregion

        /// <summary>
        /// Add Loss Code to Grid
        /// </summary>
        /// <returns></returns>
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
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.CHK].Value = true;
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_ID].Value = dt.Rows[i]["TOOL_ID"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_DESC].Value = dt.Rows[i]["TOOL_DESC"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_MAT].Value = dt.Rows[i]["TOOL_MAT"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_SIZE].Value = dt.Rows[i]["TOOL_SIZE"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_IN_TIME].Value = dt.Rows[i]["TOOL_IN_TIME"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_COST].Value = dt.Rows[i]["TOOL_COST"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_USE_TIME].Value = dt.Rows[i]["TOOL_USE_TIME"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_USE_CNT].Value = dt.Rows[i]["TOOL_USE_CNT"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_DEFECT_CODE].Value = dt.Rows[i]["TOOL_DEFECT_CODE"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_DEFECT_TIME].Value = dt.Rows[i]["TOOL_DEFECT_TIME"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_TOTAL_TIME].Value = dt.Rows[i]["TOOL_TOTAL_TIME"].ToString();
                    spdToolList.ActiveSheet.Cells[spdToolList.ActiveSheet.RowCount - 1, (int)COL.TOOL_TOTAL_CNT].Value = dt.Rows[i]["TOOL_TOTAL_CNT"].ToString();
                }

                MPCF.FitColumnHeader(spdToolList);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                MPCF.ShowMessage("", MSG_LEVEL.NONE, false);

                // Res ID Check
                if (MPCF.CheckValue(cdvResID, false) == false)
                {
                    MPCF.SetFocus(cdvResID);
                    return;
                }

                for (int i = 0; i < spdToolList.ActiveSheet.RowCount; i++)
                {
                    if (spdToolList.ActiveSheet.Cells[i, (int)COL.TOOL_ID].Text == MPCF.Trim(cdvToolID.Text))
                    {
                        MPCF.ShowErrorMessage("이미 추가되어 있는 Tool 입니다.");
                        return;
                    }
                }

                if (AddToolCode() == false)
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // 데이터가 없는 경우 종료
                if (spdToolList.ActiveSheet.Rows.Count < 1)
                {
                    return;
                }

                // Row 제거
                for (int r = 0; r < spdToolList.ActiveSheet.RowCount; r++)
                {
                    if (Convert.ToBoolean(spdToolList.ActiveSheet.Cells[r, (int)COL.CHK].Value) == true)
                    {
                        spdToolList.ActiveSheet.RemoveRows(r, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

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
                        txtToolDesc.Text = cdvToolID.returnDatas[1];
                    }
                }
                else
                {
                    cdvToolID.Text = "";
                    txtToolDesc.Text = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }  
        }

        private void cdvResID_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cdvResID.Text) == false)
                {
                    ViewToolInputList();                    
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvResID, false) == false)
                {
                    MPCF.SetFocus(cdvResID);
                    return;
                }

                // Event
                if (ToolChange('1') == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            // Validation
            if (MPCF.CheckValue(cdvResID, false) == false)
            {
                MPCF.SetFocus(cdvResID);
                return;
            }

            ViewToolInputList();
        }
    }
}
