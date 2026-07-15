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
using System.Collections;

using SOI.DNM;
using BOI.OIFrx;

namespace SOI.Solar
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCUSViewResourceHistory : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCUSViewResourceHistory()
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
            dtpTo.Value = DateTime.Now;

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
                // (Required) Init Focus Control
                MPCF.SetFocus(cdvResId);

                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// Resource ID CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvResId_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // CodeView Service
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                // Display and Header Text Setup
                string[] display = new string[] { "RES_ID", "RES_DESC" };
                string[] header = new string[] { "Res ID", "Res Desc" };

                // Show CodeView and Get Return
                cdvResId.Text = cdvResId.Show(cdvResId, "View Resource List", "RAS", "RAS_View_Resource_List", in_node, "RES_LIST", display, header, "Res ID");

                // Field Clear
                MPCF.FieldClear(spdHistory);

                // Validation
                if (string.IsNullOrEmpty(cdvResId.Text) == true)
                {
                    return;
                }

                // View History
                if (ViewResourceHistory(cdvResId.Text) == false)
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
        /// Include Delete History CheckBox Checked Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkIncludeDelHist_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrEmpty(cdvResId.Text) == true)
                {
                    return;
                }

                // View
                if (ViewResourceHistory(cdvResId.Text) == false)
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
        /// Excel Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvResId, false) == false || spdHistory.ActiveSheet.RowCount < 1)
                {
                    return;
                }

                string sCond = string.Empty;

                if (MPCF.ExportToExcel(spdHistory, this.Text, sCond, true, true, true, -1, -1) == false)
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
                // Validation
                if (MPCF.CheckValue(cdvResId, false) == false)
                {
                    return;
                }

                // View History
                if (ViewResourceHistory(cdvResId.Text) == false)
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
        /// View Resource History
        /// </summary>
        /// <param name="sResID"></param>
        /// <returns></returns>
        private bool ViewResourceHistory(string sResID)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[5];
            DataTable dt = null;
            string s_sql = "";

            try
            {
                spdHistory.ActiveSheet.RowCount = 0;
                txtSumQty.Text = "";

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$RES_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(cdvResId.Text);

                dvcArgu[2].sCondtion_ID = "$EVENT_ID";
                dvcArgu[2].sCondition_Value = MPCF.Trim(cdvEventID.Text);

                dvcArgu[3].sCondtion_ID = "$FROM_TIME";
                dvcArgu[3].sCondition_Value = DateTime.Parse(dtpFrom.Value.ToString()).ToString("yyyyMMddHHmmss");                

                dvcArgu[4].sCondtion_ID = "$TO_TIME";
                dvcArgu[4].sCondition_Value = DateTime.Parse(dtpTo.Value.ToString()).ToString("yyyyMMddHHmmss");

                if (TPDR.GetDataOne("", ref dt, "VIEW_RESOURCE_EVENT_LIST", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                // Bind
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spdHistory.ActiveSheet.RowCount++;
                    spdHistory.ActiveSheet.Cells[i, 0].Value = dt.Rows[i]["HIST_SEQ"].ToString();
                    spdHistory.ActiveSheet.Cells[i, 1].Value = dt.Rows[i]["TRAN_TIME"].ToString();
                    spdHistory.ActiveSheet.Cells[i, 2].Value = dt.Rows[i]["EVENT_ID"].ToString(); 
                    spdHistory.ActiveSheet.Cells[i, 3].Value = dt.Rows[i]["NEW_UP_DOWN_FLAG"].ToString();
                    spdHistory.ActiveSheet.Cells[i, 4].Value = dt.Rows[i]["NEW_PRI_STS"].ToString(); 
                    spdHistory.ActiveSheet.Cells[i, 5].Value = dt.Rows[i]["TRAN_USER_ID"].ToString(); 
                    spdHistory.ActiveSheet.Cells[i, 6].Value = dt.Rows[i]["LAST_DOWN_TIME"].ToString();
                    spdHistory.ActiveSheet.Cells[i, 7].Value = dt.Rows[i]["HIST_DEL_FLAG"].ToString();
                }

                txtSumQty.Text = dt.Rows.Count.ToString();                

                // Fit Column Header
                MPCF.FitColumnHeader(spdHistory);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion

        private void cdvEventID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Required Value
                if (MPCF.CheckValue(cdvResId, false) == false)
                {
                    return;
                }

                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_RESEVENT_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("NEXT_RES_ID", cdvResId.Text);
                in_node.AddChar("RES_TYPE", 'M');

                // Display and Header Text Setup
                string[] display = new string[] { "EVENT_ID", "EVENT_DESC" };
                string[] header = new string[] { "Event ID", "Event Desc" };

                // Show CodeView and Get Return
                cdvEventID.Text = cdvEventID.Show(cdvEventID, "View Resource Event", "RAS", "RAS_View_ResEvent_List", in_node, "EVENT_LIST", display, header, "Event ID");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }      
        }
    }
}
