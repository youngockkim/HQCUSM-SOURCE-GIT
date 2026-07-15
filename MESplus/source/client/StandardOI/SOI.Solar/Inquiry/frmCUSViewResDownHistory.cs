//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmCUSViewResDownHistory.cs
//   Description :
//
//   MES Version : 5.3.5.0
//
//   Function List
//       - 
//
//   Detail Description
//       -
//
//   Use Service Module
//      Service
//       - 
//      Query
//       - 
//       - 
//
//   History
//       - **** Do Not Modify in Site!!! ****
//
//
//   Copyright(C) 1998-2017 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
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
    public partial class frmCUSViewResDownHistory : SOIBaseForm03
    {
        public frmCUSViewResDownHistory()
        {
            InitializeComponent();
        }

        #region [Constant Definition]

        #endregion

        #region [Variable Definition]

        private frmCUSTranRepairReport frmRepairReport;

        private enum DOWN_HISTORY_LIST : int
        {
            RES_ID = 0,
            RES_DESC,
            DOWN_START_TIME,
            DOWN_END_TIME,
            DOWN_GROUP_CODE,
            DOWN_GROUP_CODE_DESC,
            DOWN_CODE,
            DOWN_CODE_DESC,
            REPAIR_START_TIME,
            REPAIR_END_TIME,
            REPAIR_INTERVAL,
            STOP_INTERVAL,
            DOWN_INTERVAL,
            TOTAL_AMOUNT,
            DOWN_REASON,
            WORK_CONENTS,
            COMMENT,
            WRITE_USER,
            FACTORY,
            DOWN_HIST_SEQ,
            DOC_CREATE_FLAG
        }

        #endregion

        #region [FormDefinition]

        private void initCtrl()
        {
            try
            {
                // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
                MPCF.ConvertCaption(this);

                MPCF.FieldClear(this);                
                this.dtpFrom.Value = DateTime.Now.AddDays(-1);
                this.dtpTo.Value = DateTime.Now;

                MPCF.ClearList(spdDownHistList, true);
                MPCF.FitColumnHeader(spdDownHistList);                

                this.btnPrintOption.Visible = false;

                SetSpreadLabel();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        #endregion

        #region [Function Definition]

        private void SetSpreadLabel()
        {
            //ORDER_DATE, ORDER_ID는 MESCaption을 사용하지 않음 -> ORDER_ID는 작업 지시로 번역됨
            spdDownHistList.ActiveSheet.Columns[(int)DOWN_HISTORY_LIST.DOWN_START_TIME].Label = "고장시작일자";
            spdDownHistList.ActiveSheet.Columns[(int)DOWN_HISTORY_LIST.DOWN_END_TIME].Label = "고장종료일자";
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case CSGC.MP_CHECK_VIEW:

                        DateTime dtpFromOut = new DateTime();
                        if (dtpFrom.Value != null)
                        {
                            if (DateTime.TryParse(dtpFrom.Value.ToString(), out dtpFromOut) == true){}
                        }
                        DateTime dtpToOut = new DateTime();
                        if (dtpTo.Value != null)
                        {
                            if (DateTime.TryParse(dtpTo.Value.ToString(), out dtpToOut) == true){}
                        }

                        if (this.dtpFrom.GetValueAsDateTime() > this.dtpTo.GetValueAsDateTime())
                        {
                            this.dtpFrom.SetValueAsDateTime(dtpToOut.AddDays(-1));
                            MPCF.ShowMsgBox(MPCF.GetMessage(371));
                        }

                        break;

                    case CSGC.MP_CHECK_CREATE:
                        break;

                    case CSGC.MP_CHECK_UPDATE:
                        break;

                    case CSGC.MP_CHECK_DELETE:
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

        private void ViewDownHistoryList()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            MPCF.ClearList(this.spdDownHistList);

            try
            {
                sViewID = "VIEW_RESOURCE_DOWN_HISTORY";

                i_cond_cnt = 4;
                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];

                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$RES_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(this.cdvRes.Text);

                ArrDVC[2].sCondtion_ID = "$FROM_DATE";
                ArrDVC[2].sCondition_Value = MPCF.Trim(this.dtpFrom.GetValueAsString(8) + "080000");

                ArrDVC[3].sCondtion_ID = "$TO_DATE";
                ArrDVC[3].sCondition_Value = DateTime.Parse(dtpTo.Value.ToString()).AddDays(1).ToString("yyyyMMdd") + "075959";

                if (TPDR.DirectViewOne(this.spdDownHistList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return;
                }

                SetSpreadLabel();

                MPCF.FitColumnHeader(spdDownHistList);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void ReportView()
        {
            if (spdDownHistList.ActiveSheet.ActiveRowIndex < 0)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(272));
                return;
            }

            if (frmRepairReport == null || string.IsNullOrEmpty(frmRepairReport.Text))
            {
                frmRepairReport = new frmCUSTranRepairReport();
            }

            frmRepairReport.gFactory = spdDownHistList.ActiveSheet.Cells[spdDownHistList.ActiveSheet.ActiveRowIndex, (int)DOWN_HISTORY_LIST.FACTORY].Value.ToString();
            frmRepairReport.gResID = spdDownHistList.ActiveSheet.Cells[spdDownHistList.ActiveSheet.ActiveRowIndex, (int)DOWN_HISTORY_LIST.RES_ID].Value.ToString();
            frmRepairReport.gDownHistSeq = spdDownHistList.ActiveSheet.Cells[spdDownHistList.ActiveSheet.ActiveRowIndex, (int)DOWN_HISTORY_LIST.DOWN_HIST_SEQ].Value.ToString();

            MenuInfoTag menuInfo = new MenuInfoTag();
            menuInfo.c_func_type = 'F';
            menuInfo.s_assembly_file = "SOI.Solar.dll";
            menuInfo.s_assembly_name = "SOI.Solar.frmCUSTranRepairReport";
            menuInfo.s_func_desc = "Repair Report";
            menuInfo.s_func_name = "";
            MPGV.gIMdiForm.OpenMenu(menuInfo, frmRepairReport);
        }

        #endregion

        #region [Event Definition]

        private void frmCUSViewResDownHistory_Load(object sender, EventArgs e)
        {
            initCtrl();
        }

        private void frmCUSViewResDownHistory_Activated(object sender, EventArgs e)
        {

        }

        private void frmCUSViewResDownHistory_Shown(object sender, EventArgs e)
        {

        }

        private void cdvRes_CodeViewButtonClick(object sender, EventArgs e)
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
                cdvRes.Text = cdvRes.Show(cdvRes, "RESID", sViewID, dvcArgu, display, header, "RES_ID", -1);

                if (cdvRes.returnDatas != null && cdvRes.returnDatas.Count > 0)
                {
                    cdvRes.Tag = cdvRes.returnDatas[0];
                    cdvRes.Text = cdvRes.returnDatas[0];
                    txtResDesc.Text = cdvRes.returnDatas[1];
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(this.spdDownHistList);

            if (CheckCondition(CSGC.MP_CHECK_VIEW) == false) { return; }

            ViewDownHistoryList();
        }

        private void spdDownHistList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                ReportView();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (spdDownHistList.ActiveSheet.ActiveRowIndex < 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(272));
                    return;
                }

                ReportView();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (spdDownHistList.ActiveSheet.RowCount < 1)
                {
                    return;
                }

                string sCond = string.Empty;

                if (MPCF.ExportToExcel(spdDownHistList, this.Text, sCond, true, true, true, -1, -1) == false)
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
