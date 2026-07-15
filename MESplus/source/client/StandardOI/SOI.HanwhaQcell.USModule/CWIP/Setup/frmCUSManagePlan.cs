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
    public partial class frmCUSManagePlan : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        public enum PATROL_CHK
        {
            CODE,
            NAME,
            DESC
        }

        public enum DAILY_WORK_LIST
        {
            CHK,
            RES_ID,
            RES_BTN,
            RES_DESC,
            SEQ_NUM,
            OPER_POINT,
            CHECK_CODE,
            CHECK_BTN,
            CHECK_DESC,
            FE_USER,
            BE_USER
        }

        #endregion

        #region Constructor

        public frmCUSManagePlan()
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
            int tmpYear, iRow, tmpMonth;

            cboYear.Value = DateTime.Today.Year;
            cboMonth.Value = DateTime.Today.Month;

            tmpYear = MPCF.ToInt(DateTime.Now.Year.ToString());
            tmpMonth = MPCF.ToInt(DateTime.Now.Month.ToString());

            for (iRow = (tmpYear - 5); iRow < (tmpYear + 6); iRow++)
            {
                cboYear.Items.Add(iRow.ToString());
            }

            for (iRow = 1; iRow < 13; iRow++)
            {
                cboMonth.Items.Add(iRow.ToString());
            }

            cboYear.Text = tmpYear.ToString();
            cboMonth.Text = tmpMonth.ToString();

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
        /// Mat ID CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvMaterial_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_MATERIAL_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                // Display and Header Text Setup
                string[] display = new string[] { "MAT_ID", "MAT_DESC" };
                string[] header = new string[] { "Mat ID", "Mat Desc" };

                // Show CodeView and Get Return
                //cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "View Material List", "WIP", "WIP_View_Material_List", in_node, "LIST", display, header, "Mat ID");
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
                
                if (ViewDailyWorkList() == false)
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
        
        #region Functions

        /// <summary>
        /// View Productivity
        /// </summary>
        /// <returns></returns>
        private void ResetSpread()
        {
            try
            {
                spdPatrolCheckSheet.ActiveSheet.Columns.Count = 4;
                return ;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }


        /// <summary>
        /// View Productivity
        /// </summary>
        /// <returns></returns>
        private bool ViewDailyWorkList()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_DAILY_WORK_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_DAILY_WORK_LIST_OUT");
                ResetSpread();
                //  Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                DateTime dtpDateTimeOut = new DateTime();
                if (MPCF.Trim(cboMonth.Text).Length == 1)
                {
                    in_node.AddString("WORK_MONTH", cboYear.Text + "0"+ cboMonth.Text);
                }
                else
                {
                    in_node.AddString("WORK_MONTH", cboYear.Text + cboMonth.Text);
                }

                if (MPCF.CallService("CWIP", "CWIP_View_Monthly_Plan", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                int fix_col = spdPatrolCheckSheet.ActiveSheet.ColumnCount;
                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    spdPatrolCheckSheet.ActiveSheet.AddColumns(fix_col+i, 1);
                    spdPatrolCheckSheet.ActiveSheet.Columns[fix_col + i].Width = 60; 
                    spdPatrolCheckSheet.ActiveSheet.Columns[fix_col + i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;


                    spdPatrolCheckSheet.ActiveSheet.ColumnHeader.Cells[1, fix_col + i].Value = out_node.GetList(0)[i].GetString("WORK_DAY");
                    spdPatrolCheckSheet.ActiveSheet.ColumnHeader.Cells[1, fix_col + i].Tag = out_node.GetList(0)[i].GetString("WORK_DATE");
                    spdPatrolCheckSheet.ActiveSheet.Cells[0, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL01_PLAN_EL_QTY");
                    spdPatrolCheckSheet.ActiveSheet.Cells[1, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL01_PLAN_FQC_QTY");
                    spdPatrolCheckSheet.ActiveSheet.Cells[2, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL01_PLAN_FQC_MW");
                    spdPatrolCheckSheet.ActiveSheet.Cells[3, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL01_PLAN_YIELD");
                    spdPatrolCheckSheet.ActiveSheet.Cells[4, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL01_B_PLAN_EL_QTY");
                    spdPatrolCheckSheet.ActiveSheet.Cells[5, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL01_B_PLAN_FQC_QTY");
                    spdPatrolCheckSheet.ActiveSheet.Cells[6, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL01_B_PLAN_FQC_MW");
                    spdPatrolCheckSheet.ActiveSheet.Cells[7, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL01_B_PLAN_YIELD");
                    spdPatrolCheckSheet.ActiveSheet.Cells[8, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL02_PLAN_EL_QTY");
                    spdPatrolCheckSheet.ActiveSheet.Cells[9, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL02_PLAN_FQC_QTY");
                    spdPatrolCheckSheet.ActiveSheet.Cells[10, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL02_PLAN_FQC_MW");
                    spdPatrolCheckSheet.ActiveSheet.Cells[11, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL02_PLAN_YIELD");
                    spdPatrolCheckSheet.ActiveSheet.Cells[12, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL02_B_PLAN_EL_QTY");
                    spdPatrolCheckSheet.ActiveSheet.Cells[13, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL02_B_PLAN_FQC_QTY");
                    spdPatrolCheckSheet.ActiveSheet.Cells[14, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL02_B_PLAN_FQC_MW");
                    spdPatrolCheckSheet.ActiveSheet.Cells[15, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL02_B_PLAN_YIELD");
                    spdPatrolCheckSheet.ActiveSheet.Cells[16, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL03_PLAN_EL_QTY");
                    spdPatrolCheckSheet.ActiveSheet.Cells[17, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL03_PLAN_FQC_QTY");
                    spdPatrolCheckSheet.ActiveSheet.Cells[18, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL03_PLAN_FQC_MW");
                    spdPatrolCheckSheet.ActiveSheet.Cells[19, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL03_PLAN_YIELD");
                    spdPatrolCheckSheet.ActiveSheet.Cells[20, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL03_B_PLAN_EL_QTY");
                    spdPatrolCheckSheet.ActiveSheet.Cells[21, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL03_B_PLAN_FQC_QTY");
                    spdPatrolCheckSheet.ActiveSheet.Cells[22, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL03_B_PLAN_FQC_MW");
                    spdPatrolCheckSheet.ActiveSheet.Cells[23, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL03_B_PLAN_YIELD");
                    spdPatrolCheckSheet.ActiveSheet.Cells[24, fix_col + i].Value = out_node.GetList(0)[i].GetString("SUM_PLAN_EL_QTY");
                    spdPatrolCheckSheet.ActiveSheet.Cells[25, fix_col + i].Value = out_node.GetList(0)[i].GetString("SUM_PLAN_FQC_QTY");
                    spdPatrolCheckSheet.ActiveSheet.Cells[26, fix_col + i].Value = out_node.GetList(0)[i].GetString("SUM_PLAN_FQC_MW");
                    spdPatrolCheckSheet.ActiveSheet.Cells[27, fix_col + i].Value = out_node.GetList(0)[i].GetString("SUM_PLAN_YIELD");
                    spdPatrolCheckSheet.ActiveSheet.Cells[28, fix_col + i].Value = out_node.GetList(0)[i].GetString("SUM_B_PLAN_EL_QTY");
                    spdPatrolCheckSheet.ActiveSheet.Cells[29, fix_col + i].Value = out_node.GetList(0)[i].GetString("SUM_B_PLAN_FQC_QTY");
                    spdPatrolCheckSheet.ActiveSheet.Cells[30, fix_col + i].Value = out_node.GetList(0)[i].GetString("SUM_B_PLAN_FQC_MW");
                    spdPatrolCheckSheet.ActiveSheet.Cells[31, fix_col + i].Value = out_node.GetList(0)[i].GetString("SUM_B_PLAN_YIELD");
                    //if (out_node.GetList(0)[i].GetString("MDL01_PLAN_EL_QTY") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[0, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL01_PLAN_EL_QTY");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL01_PLAN_FQC_QTY") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[1, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL01_PLAN_FQC_QTY");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL01_PLAN_FQC_MW") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[2, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL01_PLAN_FQC_MW");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL01_PLAN_YIELD") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[3, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL01_PLAN_YIELD");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL01_B_PLAN_EL_QTY") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[4, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL01_B_PLAN_EL_QTY");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL01_B_PLAN_FQC_QTY") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[5, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL01_B_PLAN_FQC_QTY");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL01_B_PLAN_FQC_MW") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[6, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL01_B_PLAN_FQC_MW");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL01_B_PLAN_YIELD") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[7, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL01_B_PLAN_YIELD");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL02_PLAN_EL_QTY") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[8, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL02_PLAN_EL_QTY");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL02_PLAN_FQC_QTY") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[9, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL02_PLAN_FQC_QTY");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL02_PLAN_FQC_MW") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[10, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL02_PLAN_FQC_MW");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL02_PLAN_YIELD") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[11, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL02_PLAN_YIELD");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL02_B_PLAN_EL_QTY") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[12, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL02_B_PLAN_EL_QTY");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL02_B_PLAN_FQC_QTY") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[13, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL02_B_PLAN_FQC_QTY");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL02_B_PLAN_FQC_MW") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[14, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL02_B_PLAN_FQC_MW");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL02_B_PLAN_YIELD") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[15, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL02_B_PLAN_YIELD");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL03_PLAN_EL_QTY") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[16, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL03_PLAN_EL_QTY");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL03_PLAN_FQC_QTY") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[17, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL03_PLAN_FQC_QTY");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL03_PLAN_FQC_MW") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[18, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL03_PLAN_FQC_MW");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL03_PLAN_YIELD") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[19, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL03_PLAN_YIELD");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL03_B_PLAN_EL_QTY") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[20, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL03_B_PLAN_EL_QTY");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL03_B_PLAN_FQC_QTY") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[21, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL03_B_PLAN_FQC_QTY");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL03_B_PLAN_FQC_MW") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[22, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL03_B_PLAN_FQC_MW");
                    //}
                    //if (out_node.GetList(0)[i].GetString("MDL03_B_PLAN_YIELD") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[23, fix_col + i].Value = out_node.GetList(0)[i].GetString("MDL03_B_PLAN_YIELD");
                    //}

                    //if (out_node.GetList(0)[i].GetString("SUM_PLAN_EL_QTY") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[24, fix_col + i].Value = out_node.GetList(0)[i].GetString("SUM_PLAN_EL_QTY");
                    //}
                    //if (out_node.GetList(0)[i].GetString("SUM_PLAN_FQC_QTY") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[25, fix_col + i].Value = out_node.GetList(0)[i].GetString("SUM_PLAN_FQC_QTY");
                    //}
                    //if (out_node.GetList(0)[i].GetString("SUM_PLAN_FQC_MW") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[26, fix_col + i].Value = out_node.GetList(0)[i].GetString("SUM_PLAN_FQC_MW");
                    //}
                    //if (out_node.GetList(0)[i].GetString("SUM_PLAN_YIELD") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[27, fix_col + i].Value = out_node.GetList(0)[i].GetString("SUM_PLAN_YIELD");
                    //}

                    //if (out_node.GetList(0)[i].GetString("SUM_B_PLAN_EL_QTY") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[28, fix_col + i].Value = out_node.GetList(0)[i].GetString("SUM_B_PLAN_EL_QTY");
                    //}
                    //if (out_node.GetList(0)[i].GetString("SUM_B_PLAN_FQC_QTY") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[29, fix_col + i].Value = out_node.GetList(0)[i].GetString("SUM_B_PLAN_FQC_QTY");
                    //}
                    //if (out_node.GetList(0)[i].GetString("SUM_B_PLAN_FQC_MW") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[30, fix_col + i].Value = out_node.GetList(0)[i].GetString("SUM_B_PLAN_FQC_MW");
                    //}
                    //if (out_node.GetList(0)[i].GetString("SUM_B_PLAN_YIELD") == "0")
                    //{
                    //}
                    //else
                    //{
                    //    spdPatrolCheckSheet.ActiveSheet.Cells[31, fix_col + i].Value = out_node.GetList(0)[i].GetString("SUM_B_PLAN_YIELD");
                    //}

                    if (i == out_node.GetList(0).Count - 1)
                    {
                        spdPatrolCheckSheet.ActiveSheet.ColumnHeader.Cells[0, fix_col].ColumnSpan = out_node.GetList(0).Count;
                        spdPatrolCheckSheet.ActiveSheet.ColumnHeader.Cells[0, fix_col].Value = dtpDateTimeOut.Month;
                    }
                }

                // Fit Column Hedaer
                //MPCF.FitColumnHeader(spdPatrolCheckSheet);


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

        private bool Update_Daily_Work_List()
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");
            TRSNode work_list = null;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("TABLE_NAME", HQGC.GCM_PLANNING);
                for (int i = 0; i < spdPatrolCheckSheet.ActiveSheet.ColumnCount-4; i++)
                {
                    work_list = in_node.AddNode("WORK_LIST");
                    work_list.AddString("WORK_DATE", spdPatrolCheckSheet.ActiveSheet.ColumnHeader.Cells[1,i+4].Tag.ToString());
                    work_list.AddString("LINE_ID", "MDL01");
                    work_list.AddString("PLAN_EL_QTY", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[0, i + 4].Text));
                    work_list.AddString("PLAN_FQC_QTY", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[1, i + 4].Text));
                    work_list.AddString("PLAN_FQC_MW", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[2, i + 4].Text));
                    work_list.AddString("PLAN_YIELD", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[3, i + 4].Text));
                    work_list.AddString("B_PLAN_EL_QTY", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[4, i + 4].Text));
                    work_list.AddString("B_PLAN_FQC_QTY", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[5, i + 4].Text));
                    work_list.AddString("B_PLAN_FQC_MW", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[6, i + 4].Text));
                    work_list.AddString("B_PLAN_YIELD", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[7, i + 4].Text));

                    work_list = in_node.AddNode("WORK_LIST");
                    work_list.AddString("WORK_DATE", spdPatrolCheckSheet.ActiveSheet.ColumnHeader.Cells[1, i + 4].Tag.ToString());
                    work_list.AddString("LINE_ID", "MDL02");
                    work_list.AddString("PLAN_EL_QTY", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[8, i + 4].Text));
                    work_list.AddString("PLAN_FQC_QTY", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[9, i + 4].Text));
                    work_list.AddString("PLAN_FQC_MW", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[10, i + 4].Text));
                    work_list.AddString("PLAN_YIELD", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[11, i + 4].Text));
                    work_list.AddString("B_PLAN_EL_QTY", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[12, i + 4].Text));
                    work_list.AddString("B_PLAN_FQC_QTY", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[13, i + 4].Text));
                    work_list.AddString("B_PLAN_FQC_MW", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[14, i + 4].Text));
                    work_list.AddString("B_PLAN_YIELD", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[15, i + 4].Text));

                    work_list = in_node.AddNode("WORK_LIST");
                    work_list.AddString("WORK_DATE", spdPatrolCheckSheet.ActiveSheet.ColumnHeader.Cells[1, i + 4].Tag.ToString());
                    work_list.AddString("LINE_ID", "MDL03");
                    work_list.AddString("PLAN_EL_QTY", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[16, i + 4].Text));
                    work_list.AddString("PLAN_FQC_QTY", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[17, i + 4].Text));
                    work_list.AddString("PLAN_FQC_MW", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[18, i + 4].Text));
                    work_list.AddString("PLAN_YIELD", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[19, i + 4].Text));
                    work_list.AddString("B_PLAN_EL_QTY", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[20, i + 4].Text));
                    work_list.AddString("B_PLAN_FQC_QTY", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[21, i + 4].Text));
                    work_list.AddString("B_PLAN_FQC_MW", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[22, i + 4].Text));
                    work_list.AddString("B_PLAN_YIELD", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[23, i + 4].Text));

                       
                }

                if (MPCF.CallService("CWIP", "CWIP_Multi_Update_Plan", in_node, ref out_node) == false)
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
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (Update_Daily_Work_List() == false)
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

        private void cdvWorkLineW_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //spdDailyWorkList.ActiveSheet.RowCount = 0;

                //cdvResID.Text = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvResID_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //spdDailyWorkList.ActiveSheet.RowCount = 0;

                //btnProcess.PerformClick();
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
                if (MPCF.ExportToExcel(spdPatrolCheckSheet, this.Text, "", true, true, true, -1, -1) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        
    }
}
