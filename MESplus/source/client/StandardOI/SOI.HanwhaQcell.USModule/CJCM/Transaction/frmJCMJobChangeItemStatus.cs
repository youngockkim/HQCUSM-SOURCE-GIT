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
using SOI.WIP;
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
    public partial class frmJCMJobChangeItemStatus : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

      //  private EdcDataInfo charData;

        private enum LIST : int
        {
            LINE_CODE,
            ORDER_ID,
            ORDER_DESC,
            STATUS,
            ITEM_CODE,
            ITEM_NAME,
            PLAN_START_DATE,
            PLAN_START_TIME,
            PLAN_END_DATE,
            PLAN_END_TIME,
            START_TIME,
            END_TIME,
            RESPONSIBILITY,
            DEPT_CODE
        }
        
        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        public frmJCMJobChangeItemStatus()
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
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);

            cdvReponsibility.Text = MPGV.gsUserID;

            //사용 권한자 인지 Check // GCM = '@JCM_uSER_INFO'에 등록된 사용자 인지 Check
            if (ViewUserInfo(MPGV.gsUserID) == false)
                this.Close();

            cdvReponsibility.Enabled = false;

            try
            {
                cdvWorkLine.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvWorkLine.Text"));
                cdvWorkLine.Description = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvWorkLine.Description")); 
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
        private void frmTempSOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                MPCF.SetFocus(cdvWorkLine);

                if (ViewJobChangeItem(txtDeptCode.Text, cdvWorkOrder.Text, cdvWorkLine.Text) == false)
                {
                    return;
                }
                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// Do Process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {

                if (spdData.ActiveSheet.RowCount == 0) return;

                int i_row = spdData.ActiveSheet.ActiveRowIndex;

                if (i_row < 0)  return;

                TranJobChangeItemPopup(spdData.ActiveSheet.GetValue(i_row, (int)LIST.ORDER_ID).ToString(), spdData.ActiveSheet.GetValue(i_row, (int)LIST.ITEM_CODE).ToString());

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Functions

     

        /// <summary>
        /// View User Info
        /// </summary>
        /// <returns></returns>
        private bool ViewUserInfo(string sUserID)
        {
            try
            {

                TRSNode in_node = new TRSNode("SQL_IN");
                TRSNode out_node = new TRSNode("SQL_OUT");
                StringBuilder sb;


                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                sb = new StringBuilder();

                sb.Append("SELECT DISTINCT A.KEY_1 AS USER_ID, A.DATA_1 AS USER_NAME, B.KEY_1 AS DEPT_CODE, B.DATA_1 AS DEPT_NAME ");
                sb.Append("  FROM MGCMTBLDAT A, MGCMTBLDAT B ");
                sb.Append(" WHERE A.FACTORY = B.FACTORY AND A.TABLE_NAME = '@JCM_USER_INFO' AND B.TABLE_NAME = '@DEPT_CODE' ");
                sb.Append("  AND A.DATA_2 = B.KEY_1");
                sb.Append("  AND A.FACTORY = '" + MPGV.gsFactory + "'");
                sb.Append("  AND A.KEY_1 = '" + sUserID + "' ");

                in_node.AddString("SQL", sb.ToString());

                if (MPCF.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetList("ROWS").Count > 0)
                {
                    if (out_node.GetList("ROWS")[0].GetList("COLS").Count > 0)
                    {
                        //out_node.GetList("ROWS")[0].GetList("COLS")[0].GetString("DATA");
                        cdvReponsibility.Description = out_node.GetList("ROWS")[0].GetList("COLS")[1].GetString("DATA");
                        txtDeptCode.Text = out_node.GetList("ROWS")[0].GetList("COLS")[2].GetString("DATA");
                        txtDeptName.Text = out_node.GetList("ROWS")[0].GetList("COLS")[3].GetString("DATA");
                    }
                }
                else
                {
                    MPCF.ShowMessage(MPCF.GetMessage(106), MSG_LEVEL.ERROR, true);
                    return false;
                }
                return true;                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
           
        }

        /// <summary>
        /// View Order
        /// </summary>
        /// <param name="sOrderId"></param>
        /// <returns></returns>
        private bool ViewJobChangeItem(string sDeptCode, string sOrderId, string sLineCode)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_JOB_CHANGE_ITEM_IN");
                
                List<TRSNode> out_list = new List<TRSNode>();
                string s_tmp_date = "";

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_CODE", sLineCode);
                in_node.AddString("ORDER_ID", sOrderId);
                in_node.AddString("DEPT_CODE", sDeptCode);
                in_node.AddString("STATUS", MPCF.Trim(cdvStatus.Text));
                if (chkIncludeEnd.Checked == true)
                {
                    in_node.AddChar("INCLUDE_CLOSE", 'Y');
                }
                else
                {
                    in_node.AddChar("INCLUDE_CLOSE", 'N');
                }

                do
                {
                    TRSNode out_node = new TRSNode("VIEW_JOB_CHANGE_ITEM_OUT");
                    if (MPCF.CallService("CJCM", "CJCM_View_Job_Change_Item_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                } while (out_list.Count < 1);

                FarPoint.Win.Spread.SheetView with_1 = this.spdData.ActiveSheet;
                with_1.RowCount = 0;
                int i = 0;
                foreach (TRSNode out_node in out_list)
                {
                    List<TRSNode> cams_join_list = out_node.GetList("JOB_CHANGE_ITEM_LIST");
                    foreach (TRSNode node in cams_join_list)
                    {
                        with_1.RowCount = i + 1;
                        with_1.SetValue(i, MPCF.ToInt(LIST.LINE_CODE), node.GetString("LINE_ID"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.ORDER_ID), node.GetString("ORDER_ID"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.ORDER_DESC), node.GetString("MAT_ID"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.STATUS), node.GetString("STATUS_DESC"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.ITEM_CODE), node.GetString("ITEM_CODE"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.ITEM_NAME), node.GetString("ITEM_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.PLAN_START_DATE), MPCF.MakeDateFormat(node.GetString("PLAN_START_DATE"), DATE_TIME_FORMAT.DATE));
                        with_1.SetValue(i, MPCF.ToInt(LIST.PLAN_START_TIME), node.GetString("PLAN_START_HOUR"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.PLAN_END_DATE), MPCF.MakeDateFormat(node.GetString("PLAN_END_DATE"), DATE_TIME_FORMAT.DATE));
                        with_1.SetValue(i, MPCF.ToInt(LIST.PLAN_END_TIME), node.GetString("PLAN_END_HOUR"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.RESPONSIBILITY), node.GetString("RESPONSIBILITY"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.DEPT_CODE), node.GetString("DEPT_CODE"));

                        if (MPCF.Trim(node.GetString("START_TIME")).Length == 14)
                            s_tmp_date = MPCF.MakeDateFormat(node.GetString("START_TIME"));
                        else
                            s_tmp_date = "";

                        with_1.SetValue(i, MPCF.ToInt(LIST.START_TIME), s_tmp_date);

                        if (MPCF.Trim(node.GetString("END_TIME")).Length == 14)
                            s_tmp_date = MPCF.MakeDateFormat(node.GetString("END_TIME"));
                        else
                            s_tmp_date = "";

                        with_1.SetValue(i, MPCF.ToInt(LIST.END_TIME), s_tmp_date);

                        i++;
                    }
                }

               //   txtMaterial.Text = out_node.GetString("MAT_ID") + " : " + out_node.GetString("MAT_DESC");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool TranJobChangeItemPopup(string sOrderId, string sItemCode)
        {
            try
            {

                frmJCMJobChangeItemStatusPopup _frm = new frmJCMJobChangeItemStatusPopup(sOrderId, sItemCode);
                if(_frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    ViewJobChangeItem(txtDeptCode.Text, cdvWorkOrder.Text, cdvWorkLine.Text);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion

        private void cdvWorkLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Code View Service
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Line", "Line Desc" };
                cdvWorkLine.Text = cdvWorkLine.Show(cdvWorkLine, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
                // Clear
                //MPCF.FieldClear(pnlMiddleMargin, cdvWorkLine);
                //MPCF.FieldClear(pnlMiddleMargin, cdvWorkLine, cdvReponsibility, cdvStatus);
                cdvWorkOrder.Text = "";
                cdvWorkOrder.Description = "";
                //txtMaterial.Text = "";

                // Validation
                if (string.IsNullOrEmpty(cdvWorkLine.Text) == true)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvWorkOrder_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvWorkLine, false) == false)
                {
                    return;
                }

                // CodeView Service
                TRSNode in_node = new TRSNode("View_Order_List_Detail_In");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("LINE_ID", cdvWorkLine.Text);

                string[] header = new string[] { "Order ID", "Order Desc" };
                string[] display = new string[] { "ORDER_ID", "ORDER_DESC" };

                cdvWorkOrder.Code = cdvWorkOrder.Show(cdvWorkOrder, "View Jon Order List", "CJCM", "CJCM_View_Order_List", in_node, "DATA_LIST", display, header, "ORDER_ID");
                //cdvWorkOrder.Code = cdvWorkOrder.Show(cdvWorkOrder, "View Production Order List By Line", "CORD", "CORD_View_Order_List_By_Line", in_node, "LIST", display, header, "ORDER_ID");

                // Clear
                //MPCF.FieldClear(pnlMiddleMargin, cdvWorkLine, cdvWorkOrder);
                //MPCF.FieldClear(pnlMiddleMargin, cdvWorkLine, cdvWorkOrder, cdvReponsibility, cdvDepartment, cdvStatus);

                // Validation
                if (cdvWorkOrder == null || cdvWorkOrder.Text == string.Empty)
                {
                    return;
                }
                               

                //// View job Change Item List
                if (ViewJobChangeItem(txtDeptCode.Text, cdvWorkOrder.Text, cdvWorkLine.Text) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvReponsibility_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Code View Service
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "@JCM_USER_INFO");
                in_node.AddString("DATA_2", txtDeptCode.Text);
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "User ID", "User Name" };
                cdvReponsibility.Text = cdvReponsibility.Show(cdvReponsibility, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvReponsibility.Text) == true)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvStatus_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Code View Service
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "@JCM_ITEM_STATUS");
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Code", "Desc" };
                cdvStatus.Text = cdvStatus.Show(cdvStatus, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvStatus.Text) == true)
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
            ViewJobChangeItem(txtDeptCode.Text, cdvWorkOrder.Text, cdvWorkLine.Text);
        }

        private void spdData_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {

                TranJobChangeItemPopup(spdData.ActiveSheet.GetValue(e.Row, (int)LIST.ORDER_ID).ToString(), spdData.ActiveSheet.GetValue(e.Row, (int)LIST.ITEM_CODE).ToString());

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void frmJCMJobChangeItemStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvWorkLine.Text", MPCF.Trim(cdvWorkLine.Text));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvWorkLine.Description", MPCF.Trim(cdvWorkLine.Description));
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
    }
}
