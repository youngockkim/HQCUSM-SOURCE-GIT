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
    public partial class frmCUSLossManagement : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        public enum LOSS_LIST
        {
            NO,
            LOSS_CODE,
            LOSS_DESC,
            LOSS_QTY
        }

        #endregion

        #region Constructor

        public frmCUSLossManagement()
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

        private void cdvLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Code View Service
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "@LINE_CODE");
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Line", "Line Desc" };
                cdvLineID.Text = cdvLineID.Show(cdvLineID, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Line");

                // Validation
                if (string.IsNullOrEmpty(cdvLineID.Text) == true)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvOperID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));

                string[] header = new string[] { "Oper", "Description" };
                string[] display = new string[] { "OPER", "OPER_DESC" };

                cdvOperID.Text = cdvOperID.Show(cdvOperID, "View Operation List", "CWIP", "CWIP_View_Operation_List", in_node, "LIST", display, header, "OPER");

                if (cdvOperID.Text == null || cdvOperID.Text == string.Empty)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvEquipID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", cdvLineID.Text);
                in_node.AddString("OPER", cdvOperID.Text);

                // Display and Header Text Setup
                string[] header = new string[] { "Equip ID", "Equip Desc" };
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                // Show CodeView and Get Return
                cdvEquipID.Text = cdvEquipID.Show(cdvEquipID, "View Resource List", "CRAS", "CRAS_View_Resource_List_By_Line", in_node, "RES_LIST", display, header, "RES_ID");

                // Validation
                if (string.IsNullOrEmpty(cdvEquipID.Text) == true)
                {
                    MPCF.SetFocus(cdvEquipID);
                    return;
                }

                // Focus
                MPCF.SetFocus(cdvShiftID);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvLossCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Check Required Value
                if (MPCF.CheckValue(txtWorkOrder, false) == false)
                {
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_LOSS_IN");
                TRSNode out_node = new TRSNode("VIEW_LOSS_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("LOSS_CODE"));

                // CodeView Column Header Setup
                string[] header = new string[] { "Loss Code", "Loss Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvLossCode.Code = cdvLossCode.Show(cdvLossCode, "Loss Code", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvLossCode.Text) == true)
                {
                    MPCF.SetFocus(cdvLossCode);
                    return;
                }

                // Focus
                MPCF.SetFocus(cdvLossCode);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (AddLossCode() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (spdLossInfo.ActiveSheet.RowCount == 0)
                {
                    MPCF.ShowErrorMessage(MPCF.GetMessage(192));
                    return;
                }

                spdLossInfo.ActiveSheet.Rows.Remove(spdLossInfo.ActiveSheet.ActiveRowIndex, 1);

                int iRowCount = spdLossInfo.ActiveSheet.RowCount;

                for (int i = 0; i < spdLossInfo.ActiveSheet.RowCount; i++)
                {
                    spdLossInfo.ActiveSheet.Cells[i, (int)LOSS_LIST.NO].Value = iRowCount;
                    iRowCount--;
                }

                lblLotRemain.Text = spdLossInfo.ActiveSheet.RowCount.ToString();


            }
            catch (Exception)
            {
                throw;
            }
        }

        
        #endregion

        #region Function

        private bool AddLossCode()
        {
            try
            {
                MPCF.ShowMessage("", MSG_LEVEL.NONE, false);

                
                // Loss Code Check
                if (MPCF.CheckValue(cdvLossCode, false) == false)
                {
                    return false;
                }

                // Loss Qty Check
                if (MPCF.CheckValue(txtLossQty, 0.0005, MPCF.ToDbl(MPCF.DestroyNumberFormat(lblLotRemain.Text)), false) == false)
                {
                    txtLossQty.Text = "";
                    return false;
                }

                double dLossQty = Convert.ToDouble(txtLossQty.Text);

                spdLossInfo.ActiveSheet.AddRows(0, 1);
                spdLossInfo.ActiveSheet.Cells[0, (int)LOSS_LIST.NO].Value = spdLossInfo.ActiveSheet.RowCount.ToString();
                spdLossInfo.ActiveSheet.Cells[0, (int)LOSS_LIST.LOSS_CODE].Value = cdvLossCode.Code;
                spdLossInfo.ActiveSheet.Cells[0, (int)LOSS_LIST.LOSS_DESC].Value = cdvLossCode.Description;
                spdLossInfo.ActiveSheet.Cells[0, (int)LOSS_LIST.LOSS_QTY].Value = txtLossQty.Text;

                cdvLossCode.Text = string.Empty;
                MPCF.SetFocus(cdvLossCode);

                //return true;

                lblTotLoss.Text = spdLossInfo.ActiveSheet.RowCount.ToString();
                lblLotRemain.Text = (Convert.ToInt32(lblLotRemain.Text.Replace(",", "")) - Convert.ToInt32(txtLossQty.Text.Replace(",", ""))).ToString();

                cdvLossCode.Text = "";
                txtLossQty.Text = "0";

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
