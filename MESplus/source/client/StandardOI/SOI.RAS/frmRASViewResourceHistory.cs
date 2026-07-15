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

namespace SOI.RAS
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmRASViewResourceHistory : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmRASViewResourceHistory()
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
            dtpFrom.Value = DateTime.Today.AddYears(-1);

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
            TRSNode in_node = new TRSNode("View_Resource_History_In");
            TRSNode out_node;
            ArrayList lisHist = new ArrayList();

            try
            {
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", MPCF.Trim(sResID));
                in_node.AddString("FROM_TIME", "20000101");
                in_node.AddString("TO_TIME", "29991231");
                in_node.AddInt("NEXT_HIST_SEQ", int.MaxValue);
                in_node.AddChar("INCLUDE_DEL_HIST", chkIncludeDelHist.Checked == true ? 'Y' : ' ');

                do
                {
                    out_node = new TRSNode("View_Resource_History_Out");

                    if (MPCF.CallService("RAS", "RAS_View_Resource_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    lisHist.Add(out_node);

                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                } while (in_node.GetInt("NEXT_HIST_SEQ") > 0);

                // Field Clear
                MPCF.ClearList(this.spdHistory);

                // Bind
                foreach (object obj in lisHist)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;
                    spdHistory.ActiveSheet.RowCount = out_node.GetList(0).Count;
                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        spdHistory.ActiveSheet.Cells[i, 0].Value = out_node.GetList(0)[i].GetInt("HIST_SEQ");
                        spdHistory.ActiveSheet.Cells[i, 1].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));
                        spdHistory.ActiveSheet.Cells[i, 2].Value = out_node.GetList(0)[i].GetString("EVENT_ID");
                        spdHistory.ActiveSheet.Cells[i, 3].Value = out_node.GetList(0)[i].GetChar("NEW_UP_DOWN_FLAG") == 'U' ? "UP" : "DOWN";
                        spdHistory.ActiveSheet.Cells[i, 4].Value = out_node.GetList(0)[i].GetString("NEW_PRI_STS");
                        spdHistory.ActiveSheet.Cells[i, 5].Value = out_node.GetList(0)[i].GetString("TRAN_USER_ID");
                        spdHistory.ActiveSheet.Cells[i, 6].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LAST_DOWN_TIME"));
                        spdHistory.ActiveSheet.Cells[i, 7].Value = out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG");
                    }
                }

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
    }
}
