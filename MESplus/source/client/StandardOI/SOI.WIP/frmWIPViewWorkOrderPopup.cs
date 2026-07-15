using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;

namespace SOI.WIP
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmWIPViewWorkOrderPopup : frmPopupBase
    {
        #region Property

        /// <summary>
        /// (Required) Show form after drawing is finished.
        /// Form 내에 있는 모든 컨트롤들의 Rendering을 완료한 이후에 Form을 표시한다.
        /// Load Event 이후에 발생하므로 Focus 등의 이벤트들은 Activated 이벤트에 할당해야 한다.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000;
                return createParams;
            }
        }

        #endregion

        #region Constructor

        public frmWIPViewWorkOrderPopup(string workOrder)
        {
            InitializeComponent();
            txtOrderID.Text = workOrder;
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// - Form Activate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIPopup_Load(object sender, EventArgs e)
        {
            // Caption 변경
            MPCF.ConvertCaption(this);

            // 활성화
            this.Activate();
            if (ViewOrder(txtOrderID.Text) == false)
            {
                Close();
            }
        }

        /// <summary>
        /// (Required) Close Button Click
        /// - Form Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // 종료
            this.Close();
        }

        #endregion

        #region "Functions"

        public bool ViewOrder(string sOrderId)
        {
            TRSNode in_node = new TRSNode("VIEW_ORDER_IN");
            TRSNode out_node = new TRSNode("VIEW_ORDER_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", sOrderId);

                if (MPCF.CallService("ORD", "ORD_View_Order", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtOrderID.Text = out_node.GetString("ORDER_ID");
                txtOrderDesc.Text = out_node.GetString("ORDER_DESC");

                txtWorkDate.Text = MPCF.MakeDateFormat(out_node.GetString("WORK_DATE"), DATE_TIME_FORMAT.DATE);
                txtMaterial.Text = MPCF.Trim(out_node.GetString("MAT_ID"));
                txtFlow.Text = MPCF.Trim(out_node.GetString("FLOW"));
                txtResID.Text = MPCF.Trim(out_node.GetString("RES_ID"));
                txtCustomerID.Text = out_node.GetString("CUSTOMER_ID");
                txtCustomerMat.Text = out_node.GetString("CUSTOMER_MAT_ID");

                txtPlanDueTime.Text = MPCF.MakeDateFormat(out_node.GetString("PLAN_DUE_TIME"));
                txtPlanStartTime.Text = MPCF.MakeDateFormat(out_node.GetString("PLAN_START_TIME"));
                txtPlanEndTime.Text = MPCF.MakeDateFormat(out_node.GetString("PLAN_END_TIME"));
                txtWorkLine.Text = out_node.GetString("ORD_CMF_1");
                txtRunSheet.Text = out_node.GetString("ORD_CMF_2");
                txtOrderStatus.Text = Convert.ToString(out_node.GetChar("ORDER_STATUS_FLAG"));

                lblOrderQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_QTY"));
                lblInQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_IN_QTY"));
                lblOutQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_OUT_QTY"));
                lblLossQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_LOSS_QTY"));
                lblReworkQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("ORD_REWORK_QTY"));

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
