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

namespace SOI.SMT
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmSMTCleanPCB : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmSMTCleanPCB()
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
            // Load Current User
            if (string.IsNullOrEmpty(MPGV.gsUserID) == false)
            {
                ViewUserInfo(MPGV.gsUserID);
            }

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
                if (string.IsNullOrEmpty(txtWorker.Text) == true)
                {
                    MPCF.SetFocus(txtWorker);
                }
                else
                {
                    MPCF.SetFocus(txtLotId);
                }

                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// User ID Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWorker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (MPCF.Trim(txtWorker.Text) != "")
                {
                    // Check Value
                    if (MPCF.CheckValue(txtWorker, false) == false)
                    {
                        return;
                    }

                    if (ViewUserInfo(txtWorker.Text) == false)
                    {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Lot ID Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLotId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (MPCF.Trim(txtLotId.Text) != "")
                {
                    if (ViewLotInfo() == false)
                    {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Clean Code CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvCleanCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if(MPCF.CheckValue(txtWorker, false) == false)
                {
                    return;
                }

                if(MPCF.CheckValue(txtLotId, false) == false)
                {
                    return;
                }

                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_GCM_TABLE_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "MST_PCB_CLEAN");

                // CodeView Column Header Setup
                string[] header = new string[] { "Reason", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvCleanCode.Text = cdvCleanCode.Show(cdvCleanCode, "Clean Code", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Process Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (CleanPCB() == false)
            {
                return;
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// View User Info
        /// </summary>
        /// <returns></returns>
        private bool ViewUserInfo(string userId)
        {
            try
            {
                MPCF.FieldClear(this, txtWorker);

                TRSNode in_node = new TRSNode("VIEW_USER_INFO_IN");
                TRSNode out_node = new TRSNode("VIEW_USER_INFO_OUT");

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("USER_ID", userId);

                if (MPCF.CallService("SEC", "SEC_View_User", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtWorker.Text = userId;
                lblUserDesc.Text = out_node.GetString("USER_DESC");

                MPCF.SetFocus(txtLotId);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// View Lot Info
        /// </summary>
        /// <returns></returns>
        private bool ViewLotInfo()
        {
            try
            {
                // Check Value
                if (MPCF.CheckValue(txtWorker, false) == false)
                {
                    return false;
                }
                if (MPCF.CheckValue(txtLotId, false) == false)
                {
                    return false;
                }

                MPCF.FieldClear(grbLotInfo);
                MPCF.FieldClear(tlpCleanCode);

                TRSNode in_node = new TRSNode("VIEW_LOT_INFO_IN");
                TRSNode out_node = new TRSNode("VIEW_LOT_INFO_OUT");

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", txtLotId.Text);

                if (MPCF.CallService("SMT", "SMT_View_Lot_Info", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtLotDesc.Text = out_node.GetString("LOT_DESC");
                txtOrderID.Text = out_node.GetString("ORDER_ID");
                txtOrderDesc.Text = out_node.GetString("ORDER_DESC");
                txtMatID.Text = out_node.GetString("MAT_ID");
                txtMatDesc.Text = out_node.GetString("MAT_DESC");
                txtOperID.Text = out_node.GetString("OPER");
                txtOperDesc.Text = out_node.GetString("OPER_DESC");
                txtLineID.Text = out_node.GetString("LINE_ID");
                txtResID.Text = out_node.GetString("END_RES_ID");
                txtLotQty.Text = out_node.GetDouble("QTY_1").ToString("####,##0.###");
                txtLotSts.Text = out_node.GetString("LOT_STATUS");
                

                MPCF.SetFocus(txtLotId);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Clean PCB
        /// </summary>
        /// <returns></returns>
        private bool CleanPCB()
        {
            TRSNode in_node = new TRSNode("CLEAN_PCB_IN");
            TRSNode out_node = new TRSNode("CLEAN_PCB_OUT");

            try
            {
                // Check Value
                if (MPCF.CheckValue(txtWorker, false) == false)
                {
                    return false;
                }
                if (MPCF.CheckValue(txtLotId, false) == false)
                {
                    return false;
                }
                if (MPCF.CheckValue(cdvCleanCode, false) == false)
                {
                    return false;
                }

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", txtLotId.Text);
                in_node.AddString("CLEAN_CODE", cdvCleanCode.Text);
                in_node.AddString("CLEAN_USER", txtWorker.Text);

                if (MPCF.CallService("SMT", "SMT_Clean_Pcb_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                MPCF.FieldClear(this, txtWorker, lblUserDesc, null);

                MPCF.SetFocus(txtLotId);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        #endregion
    }
}
