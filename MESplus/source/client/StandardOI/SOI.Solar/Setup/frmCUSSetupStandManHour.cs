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
using BOI.OIFrx;
using SOI.DNM;

namespace SOI.Solar
{
    public partial class frmCUSSetupStandManHour : BOIBaseForm02
    {
        #region Constructor

        public frmCUSSetupStandManHour()
        {
            InitializeComponent();
        }

        #endregion

        #region Property

        // (Required) 
        private bool bIsShown = false;

        private enum COL
        {
            CHECK = 0,
            WORK_DATE,
            LINE,
            LINE_BTN,
            STD_TIME_1,
            ADD_TIME_1,
            STD_TIME_2,
            ADD_TIME_2,
            DT_CODE_1,
            DT_CODE_BTN_1,
            DT_CODE_2,
            DT_CODE_BTN_2,
            DT_CODE_3,
            DT_CODE_BTN_3,
            DT_TIME,
            STD_MAN_HOUR
        }

        #endregion

        private bool bCheckAll = false;       

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCUSSetupStandManHour_Load(object sender, EventArgs e)
        {
            try
            {
                // (Required) Convert Caption
                // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
                MPCF.ClearList(spdStandardTime);

                int tmpYear, iRow, tmpMonth;

                cboYear.Value = DateTime.Today.Year;
                cboMonth.Value = DateTime.Today.Month;

                tmpYear = MPCF.ToInt(DateTime.Now.Year.ToString());
                tmpMonth = MPCF.ToInt(DateTime.Now.Month.ToString());

                for (iRow = (tmpYear - 2); iRow < (tmpYear + 3); iRow++)
                {
                    cboYear.Items.Add(iRow.ToString());
                }

                for (iRow = 1; iRow < 13; iRow++)
                {
                    cboMonth.Items.Add(iRow.ToString());
                }

                cboYear.Text = tmpYear.ToString();
                cboMonth.Text = tmpMonth.ToString();

                spdStandardTime.ActiveSheet.Columns[0].Visible = false;
                spdStandardTime.ActiveSheet.Columns[(int)COL.DT_CODE_1].Visible = false;
                spdStandardTime.ActiveSheet.Columns[(int)COL.DT_CODE_BTN_1].Visible = false;
                spdStandardTime.ActiveSheet.Columns[(int)COL.DT_CODE_2].Visible = false;
                spdStandardTime.ActiveSheet.Columns[(int)COL.DT_CODE_BTN_2].Visible = false;
                spdStandardTime.ActiveSheet.Columns[(int)COL.DT_CODE_3].Visible = false;
                spdStandardTime.ActiveSheet.Columns[(int)COL.DT_CODE_BTN_3].Visible = false;
                spdStandardTime.ActiveSheet.Columns[(int)COL.DT_TIME].Visible = false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCUSSetupStandManHour_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                

                // (Required) 
                bIsShown = true;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("VIEW") == true)
                {
                    MPCF.ShowMessageClear();

                    ViewOrderList();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
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

                    btnView.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        // Update_Man_Hour()
        //       - Merge Target Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Update_Man_Hour(char ProcStep)
        {
            int i = 0;

            TRSNode in_node = new TRSNode("Update_Man_Hour_IN");
            TRSNode out_node = new TRSNode("Update_Man_Hour_OUT");
            TRSNode list_item;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = 'I';

                for (i = 0; i < spdStandardTime.Sheets[0].RowCount; i++)
                {
                    if(Convert.ToBoolean(spdStandardTime.ActiveSheet.Cells[i, (int)COL.CHECK].Value) == true)
                    {
                        list_item = in_node.AddNode("DATA_LIST");
                        list_item.AddString("WORK_DATE", MPCF.Trim(spdStandardTime.ActiveSheet.Cells[i, (int)COL.WORK_DATE].Value.ToString().Replace("-","")));
                        list_item.AddString("LINE", MPCF.Trim(spdStandardTime.ActiveSheet.Cells[i, (int)COL.LINE].Value));
                        list_item.AddDouble("STD_TIME_1", MPCF.Trim(spdStandardTime.ActiveSheet.Cells[i, (int)COL.STD_TIME_1].Value));
                        list_item.AddDouble("ADD_TIME_1", MPCF.Trim(spdStandardTime.ActiveSheet.Cells[i, (int)COL.ADD_TIME_1].Value));
                        list_item.AddDouble("STD_TIME_2", MPCF.Trim(spdStandardTime.ActiveSheet.Cells[i, (int)COL.STD_TIME_2].Value));
                        list_item.AddDouble("ADD_TIME_2", MPCF.Trim(spdStandardTime.ActiveSheet.Cells[i, (int)COL.ADD_TIME_2].Value));
                        list_item.AddString("DT_CODE_1", MPCF.Trim(spdStandardTime.ActiveSheet.Cells[i, (int)COL.DT_CODE_1].Value));
                        list_item.AddString("DT_CODE_2", MPCF.Trim(spdStandardTime.ActiveSheet.Cells[i, (int)COL.DT_CODE_2].Value));
                        list_item.AddString("DT_CODE_3", MPCF.Trim(spdStandardTime.ActiveSheet.Cells[i, (int)COL.DT_CODE_3].Value));
                        list_item.AddDouble("DT_TIME", MPCF.Trim(spdStandardTime.ActiveSheet.Cells[i, (int)COL.DT_TIME].Value));
                    }
                }

                if (MPCF.CallService("CUS", "CUS_Update_Man_Hour", in_node, ref out_node) == false)
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

        //View Inventory Lot History
        private bool ViewOrderList()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;
            try
            {
                spdStandardTime_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$YEAR";
                dvcArgu[1].sCondition_Value = MPCF.Trim(cboYear.Text);

                dvcArgu[2].sCondtion_ID = "$MONTH";
                dvcArgu[2].sCondition_Value = MPCF.Trim(cboMonth.Text);

                if (TPDR.GetDataOne("", ref dt, "VIEW_STD_MAN_HOUR_LIST", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdStandardTime_Sheet1.RowCount++;
                    spdStandardTime_Sheet1.Cells[i, (int)COL.CHECK].Value = true;
                    spdStandardTime_Sheet1.Cells[i, (int)COL.WORK_DATE].Value = dt.Rows[i]["WORK_DATE"].ToString();
                    spdStandardTime_Sheet1.Cells[i, (int)COL.LINE].Value = dt.Rows[i]["LINE"].ToString();
                    spdStandardTime_Sheet1.Cells[i, (int)COL.STD_TIME_1].Value = dt.Rows[i]["STD_TOTAL_MIN_1"].ToString();
                    spdStandardTime_Sheet1.Cells[i, (int)COL.ADD_TIME_1].Value = dt.Rows[i]["ADD_TOTAL_MIN_1"].ToString();
                    spdStandardTime_Sheet1.Cells[i, (int)COL.STD_TIME_2].Value = dt.Rows[i]["STD_TOTAL_MIN_2"].ToString();
                    spdStandardTime_Sheet1.Cells[i, (int)COL.ADD_TIME_2].Value = dt.Rows[i]["ADD_TOTAL_MIN_2"].ToString();
                    spdStandardTime_Sheet1.Cells[i, (int)COL.DT_CODE_1].Value = dt.Rows[i]["NON_OP_CODE_1"].ToString();
                    spdStandardTime_Sheet1.Cells[i, (int)COL.DT_CODE_2].Value = dt.Rows[i]["NON_OP_CODE_2"].ToString();
                    spdStandardTime_Sheet1.Cells[i, (int)COL.DT_CODE_3].Value = dt.Rows[i]["NON_OP_CODE_3"].ToString();
                    spdStandardTime_Sheet1.Cells[i, (int)COL.DT_TIME].Value = dt.Rows[i]["NON_TOTAL_MIN"].ToString();
                    spdStandardTime_Sheet1.Cells[i, (int)COL.STD_MAN_HOUR].Value = dt.Rows[i]["STD_MAN_HOUR"].ToString();
                }

                MPCF.FitColumnHeader(spdStandardTime);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
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
                    case "VIEW":

                        if (MPCF.Trim(cboYear.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cboYear.Focus();
                            return false;
                        }

                        if (MPCF.Trim(cboMonth.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cboMonth.Focus();
                            return false;
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

        #endregion

        private void btnProcess_Click(object sender, EventArgs e)
        {
            MPCF.ShowMessageClear();

            if(Update_Man_Hour('1') == true)
            {
                btnView.PerformClick();
            }
        }

        private void spdStandardTime_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column == (int)COL.DT_CODE_BTN_1 || e.Column == (int)COL.DT_CODE_BTN_2 || e.Column == (int)COL.DT_CODE_BTN_3)
                {
                    TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                    dvcArgu[0].sCondtion_ID = "$FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    dvcArgu[1].sCondtion_ID = "$TABLE_NAME";
                    dvcArgu[1].sCondition_Value = "C@NON_DT_CODE";

                    // CodeView Column Header Setup
                    string[] header = new string[] { "Code", "Code Desc" };

                    // CodeView Display Column Setup
                    string[] display = new string[] { "KEY_1", "DATA_1" };

                    // Show
                    cdvData.Text = cdvData.Show(cdvData, "Code Desc", "VIEW_GCM_DATA", dvcArgu, display, header, "DATA_1", -1);

                    if (MPCF.Trim(cdvData.Text) != "")
                    {
                        if (cdvData.returnDatas != null && cdvData.returnDatas.Count > 0)
                        {
                            spdStandardTime.ActiveSheet.Cells[e.Row, e.Column - 1].Text = cdvData.returnDatas[0];
                        }
                        else
                        {
                            spdStandardTime.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = "";
                        }
                    }
                    else
                    {
                        spdStandardTime.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                    }
                }
                else if (e.Column == (int)COL.LINE_BTN)
                {
                    TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                    dvcArgu[0].sCondtion_ID = "$FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    dvcArgu[1].sCondtion_ID = "$TABLE_NAME";
                    dvcArgu[1].sCondition_Value = "AREA";

                    // CodeView Column Header Setup
                    string[] header = new string[] { "Code", "Code Desc" };

                    // CodeView Display Column Setup
                    string[] display = new string[] { "KEY_1", "DATA_1" };

                    // Show
                    cdvData.Text = cdvData.Show(cdvData, "Code Desc", "VIEW_GCM_DATA", dvcArgu, display, header, "DATA_1", -1);

                    if (MPCF.Trim(cdvData.Text) != "")
                    {
                        if (cdvData.returnDatas != null && cdvData.returnDatas.Count > 0)
                        {
                            spdStandardTime.ActiveSheet.Cells[e.Row, e.Column - 1].Text = cdvData.returnDatas[0];
                        }
                        else
                        {
                            spdStandardTime.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                        }
                    }
                    else
                    {
                        spdStandardTime.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdStandardTime_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader && e.Column == 0)
            {
                //전체 헤더 선택
                string s_hChk = string.Empty;

                if (spdStandardTime.Sheets[0].ColumnHeader.Cells[0, 0].Text == "True")
                {
                    s_hChk = "False";
                }
                else
                {
                    s_hChk = "True";
                }

                spdStandardTime.Sheets[0].ColumnHeader.Cells[0, 0].Text = s_hChk;

                for (int i = 0; i < spdStandardTime.Sheets[0].Rows.Count; i++)
                {
                    spdStandardTime.Sheets[0].Cells[i, 0].Text = s_hChk;
                }
            }
        }
    }
}
