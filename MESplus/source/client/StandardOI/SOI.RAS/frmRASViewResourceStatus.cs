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

namespace SOI.RAS
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmRASViewResourceStatus : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmRASViewResourceStatus()
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
                // MPCF.SetFocus(control);                

                // (Required) 
                bIsShown = true;
            }
        }

        #endregion


        private void btnProcess_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Res Id CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvResId_CodeViewButtonClick(object sender, EventArgs e)
        {
            // In Node Setup
            TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';

            // Display and Header Text Setup
            string[] display = new string[] { "RES_ID", "RES_DESC" };
            string[] header = new string[] { "Res ID", "Res Desc" };

            // Show CodeView and Get Return
            cdvResId.Text = cdvResId.Show(cdvResId, "RAS","View Resource List", "RAS_View_Resource_List", in_node, "RES_LIST", display, header, "Res ID");

            if (cdvResId == null
                || cdvResId.Text == string.Empty)
            {
                return;
            }

            if (ViewResource(cdvResId.Text) == false) return;
        }

        #region "Functions"

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
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", sResId);

                if (MPCF.CallService("RAS", "RAS_View_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtResDesc.Text = MPCF.Trim(out_node.GetString("RES_DESC"));

                if (MPCF.Trim(out_node.GetChar("RES_UP_DOWN_FLAG")) == "U")
                {
                    txtUpDown.Text = "UP";
                }
                else if (MPCF.Trim(out_node.GetChar("RES_UP_DOWN_FLAG")) == "D")
                {
                    txtUpDown.Text = "DOWN";
                }

                txtResType.Text = MPCF.Trim(out_node.GetString("RES_TYPE"));
                txtArea.Text = MPCF.Trim(out_node.GetString("AREA_ID"));
                txtSubArea.Text = MPCF.Trim(out_node.GetString("SUB_AREA_ID"));
                txtLocation.Text = MPCF.Trim(out_node.GetString("RES_LOCATION"));
                txtProcCount.Text = MPCF.Trim(out_node.GetInt("PROC_COUNT"));
                txtPriStatus.Text = MPCF.Trim(out_node.GetString("RES_PRI_STS"));

                txtLastStartTime.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_START_TIME"));
                txtLastEndTime.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_END_TIME"));
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

        #endregion
    }
}
