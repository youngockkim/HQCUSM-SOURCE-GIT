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

namespace BOI.INVCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmINVInputInspectionRawmilk : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private MenuInfoTag menuInfo;

        private enum COL_LIST
        {
            COL_CHK = 0,
            COL_INV_REQ_NO,
            COL_INV_REQ_SEQ,
            COL_CAR_NO,
            COL_CAR_CODE,
            COL_CAR_DESC,
            COL_CAR_SEQ,
            COL_TRAN_USER_ID,
            COL_TRAN_USER_NAME,
            COL_DLV_NO,
            COL_DLV_SEQ,
            COL_ERP_REQ_NO,
            COL_ERP_REQ_SEQ,
            COL_MAT_ID,
            COL_MAT_DESC,
            COL_IQC_FLAG,
            COL_WEIGHT_REEL,
            COL_GRADE
        }

        #endregion

        #region Constructor

        public frmINVInputInspectionRawmilk()
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
        private void frmTempBOIBaseForm02_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
            menuInfo = (MenuInfoTag)this.Tag;
            //dtpFrom.Value = DateTime.Today.AddDays(-7);
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
            spdRawMilk.Sheets[0].ColumnHeader.Cells[0, 0].Value = false;

        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempBOIBaseForm02_Shown(object sender, EventArgs e)
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

        #region BTN EVENT

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (View_Raw_Milk_List() == false) return;
                CheckBox_Clear();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }

        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            try
            {
                if (Update_Raw_Milk_List('P') == false) return;
                btnView.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (Update_Raw_Milk_List('C') == false) return;
                btnView.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void spdRawMilk_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Row == 0 && e.Column == 0 && e.ColumnHeader == true)
            {
                // Select All
                if (((bool)spdRawMilk.Sheets[0].ColumnHeader.Cells[0, 0].Value) == false)
                {
                    spdRawMilk.Sheets[0].ColumnHeader.Cells[0, 0].Value = true;

                    for (int i = 0; i < spdRawMilk.Sheets[0].Rows.Count; i++)
                    {
                        spdRawMilk.Sheets[0].Cells[i, 0].Value = true;
                    }
                }
                // Release All
                else
                {
                    spdRawMilk.Sheets[0].ColumnHeader.Cells[0, 0].Value = false;

                    for (int i = 0; i < spdRawMilk.Sheets[0].Rows.Count; i++)
                    {
                        spdRawMilk.Sheets[0].Cells[i, 0].Value = false;
                    }
                }
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// View Raw Milk List
        /// </summary>
        /// <returns></returns>
        private bool View_Raw_Milk_List()
        {
            try
            {
                MPCF.ClearList(spdRawMilk);

                // From Date 설정
                DateTime dtpDateTimeOut = new DateTime();
                string sToDate = "";
                string sFromDate = "";
                if (dtpFrom.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpFrom.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        sFromDate = dtpDateTimeOut.ToString("yyyyMMdd");
                    }
                }

                // To Date 설정
                if (dtpTo.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpTo.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        sToDate = dtpDateTimeOut.ToString("yyyyMMdd");
                    }
                }


                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];
                DataTable dt = null;
                string s_column = "";

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "FROM_DATE";
                dvcArgu[1].sCondition_Value = sFromDate;

                dvcArgu[2].sCondtion_ID = "TO_DATE";
                dvcArgu[2].sCondition_Value = sToDate;

                if (TPDR.GetDataOne(s_column, ref dt, "BINV1003-001", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    spdRawMilk.Sheets[0].RowCount += 1;
                    spdRawMilk.Sheets[0].Cells[spdRawMilk.Sheets[0].RowCount - 1, (int)COL_LIST.COL_INV_REQ_NO].Value = dt.Rows[i]["INV_REQ_NO"].ToString();
                    spdRawMilk.Sheets[0].Cells[spdRawMilk.Sheets[0].RowCount - 1, (int)COL_LIST.COL_INV_REQ_SEQ].Value = dt.Rows[i]["INV_REQ_SEQ"].ToString();
                    spdRawMilk.Sheets[0].Cells[spdRawMilk.Sheets[0].RowCount - 1, (int)COL_LIST.COL_CAR_NO].Value = dt.Rows[i]["CAR_NO"].ToString();
                    spdRawMilk.Sheets[0].Cells[spdRawMilk.Sheets[0].RowCount - 1, (int)COL_LIST.COL_CAR_CODE].Value = dt.Rows[i]["CAR_CODE"].ToString();
                    spdRawMilk.Sheets[0].Cells[spdRawMilk.Sheets[0].RowCount - 1, (int)COL_LIST.COL_CAR_DESC].Value = dt.Rows[i]["CAR_DESC"].ToString();
                    spdRawMilk.Sheets[0].Cells[spdRawMilk.Sheets[0].RowCount - 1, (int)COL_LIST.COL_CAR_SEQ].Value = dt.Rows[i]["CAR_SEQ"].ToString();
                    spdRawMilk.Sheets[0].Cells[spdRawMilk.Sheets[0].RowCount - 1, (int)COL_LIST.COL_TRAN_USER_ID].Value = dt.Rows[i]["TRAN_USER_ID"].ToString();
                    spdRawMilk.Sheets[0].Cells[spdRawMilk.Sheets[0].RowCount - 1, (int)COL_LIST.COL_TRAN_USER_NAME].Value = dt.Rows[i]["TRAN_USER_NAME"].ToString();
                    spdRawMilk.Sheets[0].Cells[spdRawMilk.Sheets[0].RowCount - 1, (int)COL_LIST.COL_DLV_NO].Value = dt.Rows[i]["DLV_NO"].ToString();
                    spdRawMilk.Sheets[0].Cells[spdRawMilk.Sheets[0].RowCount - 1, (int)COL_LIST.COL_DLV_SEQ].Value = dt.Rows[i]["DLV_SEQ"].ToString();
                    spdRawMilk.Sheets[0].Cells[spdRawMilk.Sheets[0].RowCount - 1, (int)COL_LIST.COL_ERP_REQ_NO].Value = dt.Rows[i]["ERP_REQ_NO"].ToString();
                    spdRawMilk.Sheets[0].Cells[spdRawMilk.Sheets[0].RowCount - 1, (int)COL_LIST.COL_ERP_REQ_SEQ].Value = dt.Rows[i]["ERP_REQ_SEQ"].ToString();
                    spdRawMilk.Sheets[0].Cells[spdRawMilk.Sheets[0].RowCount - 1, (int)COL_LIST.COL_MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    spdRawMilk.Sheets[0].Cells[spdRawMilk.Sheets[0].RowCount - 1, (int)COL_LIST.COL_MAT_DESC].Value = dt.Rows[i]["MAT_DESC"].ToString();
                    spdRawMilk.Sheets[0].Cells[spdRawMilk.Sheets[0].RowCount - 1, (int)COL_LIST.COL_IQC_FLAG].Value = dt.Rows[i]["IQC_FLAG"].ToString();
                    spdRawMilk.Sheets[0].Cells[spdRawMilk.Sheets[0].RowCount - 1, (int)COL_LIST.COL_WEIGHT_REEL].Value = MPCF.ToDbl(dt.Rows[i]["WEIGHT_REAL"]);
                    spdRawMilk.Sheets[0].Cells[spdRawMilk.Sheets[0].RowCount - 1, (int)COL_LIST.COL_GRADE].Value = dt.Rows[i]["GRADE"].ToString();

                    /*20170426 JYD 합격되지 않은 건 색깔표시*/
                    if (dt.Rows[i]["IQC_FLAG"].ToString().Trim() == "N")
                    {
                        spdRawMilk.Sheets[0].Rows[i].BackColor = Color.Red;
                    }else if(dt.Rows[i]["IQC_FLAG"].ToString().Trim() == "")
                    {
                        spdRawMilk.Sheets[0].Rows[i].BackColor = Color.Yellow;
                    }

                }

            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        
        private bool Update_Raw_Milk_List(char cFlag)
        {
            TRSNode in_node = new TRSNode("UPDATE_RAW_LIST_IN");
            TRSNode out_node = new TRSNode("UPDATE_RAW_LIST_OUT");

            TRSNode data_list = null;
            
            try
            {
                MPCF.SetInMsg(in_node);

                bool bChecked = false;

                for(int i = 0 ; i < spdRawMilk.Sheets[0].RowCount; i++)
                {
                    if ((bool)spdRawMilk.Sheets[0].Cells[i, (int)COL_LIST.COL_CHK].Value == true)
                    {
                        bChecked = true;
                        break;
                    }
                }

                if (bChecked == false)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(133), MSG_LEVEL.ERROR, false);
                    return false;
                }

                if (cFlag == 'P')
                {
                    in_node.ProcStep = '1';  // Pass button 
                }
                else if (cFlag == 'F')
                {
                    in_node.ProcStep = '3';  // Fail button 
                }
                else
                {
                    in_node.ProcStep = '2';   // Cancel Button
                }

                for (int i = 0; i < spdRawMilk.Sheets[0].RowCount; i++)
                {
                    if ((bool)spdRawMilk.Sheets[0].Cells[i, (int)COL_LIST.COL_CHK].Value == false) continue;

                        data_list = in_node.AddNode("DATA_LIST");
                        data_list.AddString("INV_REQ_NO", spdRawMilk.Sheets[0].Cells[i, (int)COL_LIST.COL_INV_REQ_NO].Text);
                        data_list.AddInt("INV_REQ_SEQ", MPCF.ToInt(spdRawMilk.Sheets[0].Cells[i, (int)COL_LIST.COL_INV_REQ_SEQ].Text));

                        data_list.AddString("CAR_CODE", spdRawMilk.Sheets[0].Cells[i, (int)COL_LIST.COL_CAR_CODE].Text);
                        data_list.AddString("GRADE"   , spdRawMilk.Sheets[0].Cells[i, (int)COL_LIST.COL_GRADE].Text);

                }

                if (MPCF.CallService("BINV", "BINV_Multi_Tran_Rawmilk_IQC_Flag", in_node, ref out_node) == false)
                {
                    MPCF.ShowMessage(out_node.GetString("MSG"), MSG_LEVEL.ERROR, false);
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

        private void CheckBox_Clear()
        {
            try
            {
                for (int i = 0; i < spdRawMilk.Sheets[0].RowCount; i++)
                {
                    spdRawMilk.Sheets[0].Cells[i, (int)COL_LIST.COL_CHK].Value = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.WARNING, false);
                return;
            }
        }

        #endregion

        private void btnFail_Click(object sender, EventArgs e)
        {
            try
            {
                if (Update_Raw_Milk_List('F') == false) return;
                btnView.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

       
    }
}
