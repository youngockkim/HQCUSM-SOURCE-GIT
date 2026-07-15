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
    public partial class frmCWIPViewReworkList : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private enum COL_REWORK_LIST
        {
            MODULE_ID,
            PROD_NO,
            GRADE,
            POWER
        }

        #endregion

        #region Constructor

        public frmCWIPViewReworkList()
        {
            InitializeComponent();
            txtModuleID.Focus();
            txtModuleID.SelectAll();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWIPViewReworkList_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
            txtReModule.Text = string.Empty;
            txtOrderQty.Text = string.Empty;
            txtInQty.Text = string.Empty;
            txtRate.Text = "%";
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWIPViewReworkList_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                //MPCF.SetFocus(cdvOper);
                MPCF.SetFocus(txtModuleID);
                // (Required) 
                bIsShown = true;
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
                //if (spdHistory.ActiveSheet.RowCount < 1) return;
                //
                //if (MPCF.ExportToExcel(spdHistory, this.Text, "", true, true, true, -1, -1) == false)
                //{
                //    return;
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Functions

        /// <summary>
        /// View Lot List
        /// </summary>
        /// <param name="sOper"></param>
        /// <param name="sMatId"></param>
        /// <param name="sOrderId"></param>
        /// <returns></returns>
        private bool ViewReworkList(string sModuleId)
        {
            TRSNode in_node = new TRSNode("VIEW_REWORK_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_REWORK_LIST_OUT");
            MPCF.SetInMsg(in_node);

            try
            {
                if (sModuleId.Length < 5)
                {
                    InitList();
                    MPCF.ShowMessage("Plase Check, Not a Module to Rework.", MSG_LEVEL.WARNING, false);
                    txtReModule.Text = string.Empty;
                    txtOrderQty.Text = string.Empty;
                    txtInQty.Text = string.Empty;
                    txtRate.Text = "%";
                    return false;
                }
                // 1. Field Clear
                InitList();
                if (MPCF.Trim(sModuleId).Equals(""))
                {
                    InitList();
                    MPCF.ShowMessage("Plase Check, Not a Module to Rework.", MSG_LEVEL.WARNING, false);
                    return false;
                }

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MODULE_ID", MPCF.Trim(sModuleId));
                if (MPCF.CallService("CWIP", "CWIP_View_Rework_List", in_node, ref out_node) == false)
                {
                    txtReModule.Text = string.Empty;
                    txtOrderQty.Text = string.Empty;
                    txtInQty.Text = string.Empty;
                    txtRate.Text = "%";
                    InitList();
                    return false;
                }

                txtReModule.Text = out_node.GetString("PROD_ORDER_NO");
                txtOrderQty.Text = MPCF.ToStr(out_node.GetDouble("ORD_QTY"));
                txtInQty.Text = MPCF.ToStr(out_node.GetDouble("IN_QTY"));
                txtRate.Text = MPCF.ToStr(out_node.GetDouble("RATE")) + "%";

                // Field Clear
                InitList();
                // Data Bind
                int iRow = 0;

                lblModuleId.Text = out_node.GetList(0)[iRow].GetString("MODULE_ID");
                lblZmdl.Text = out_node.GetList(0)[iRow].GetString("PROD_NO");
                lblGrade.Text = out_node.GetList(0)[iRow].GetString("CMF_1");
                lblPower.Text = out_node.GetList(0)[iRow].GetString("CMF_2");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                MPCF.SetFocus(txtModuleID);
                return false;
            }

            txtModuleID.Text = string.Empty;
            MPCF.SetFocus(txtModuleID);
            return true;
        }

        #endregion

        private void txtModuleScan_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strFalg = string.Empty;
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtReModule.Text = string.Empty;
                txtOrderQty.Text = string.Empty;
                txtInQty.Text = string.Empty;
                txtRate.Text = "%";
                if (ViewReworkList(txtModuleID.Text) == false)
                {
                    MPCF.ShowMessage("Plase Check, Not a Module to Rework.", MSG_LEVEL.WARNING, false);
                }
            }
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            InitViews();
        }

        private void InitViews()
        {
            // Lot ID Check
            if (MPCF.CheckValue(txtModuleID, false) == false)
            {
                return;
            }

            // Module에 대한 Rework 여부를 조회한다.
            if (ViewReworkList(txtModuleID.Text) == false)
            {
                txtModuleID.SelectAll();
                return;
            }
        }

        private void txtModuleID_KeyPress(object sender, KeyPressEventArgs e)
        {
            string strFalg = string.Empty;
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtReModule.Text = string.Empty;
                txtOrderQty.Text = string.Empty;
                txtInQty.Text = string.Empty;
                txtRate.Text = "%";
                if (ViewReworkList(txtModuleID.Text) == false)
                {
                    MPCF.ShowMessage("Plase Check, Not a Module to Rework.", MSG_LEVEL.WARNING, false);
                }
            }
        }


        private void InitList()
        {
            lblPower.Text = String.Empty;
            lblGrade.Text = String.Empty;
            lblZmdl.Text = String.Empty;
            lblModuleId.Text = String.Empty;
        }
    }
}
