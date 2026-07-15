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

namespace SOI.INV
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmINVInInventoryLot : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmINVInInventoryLot()
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
                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// Inv Lot ID Enter Key Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInvLotId_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && MPCF.Trim(txtInvLotId.Text) != "")
                {
                    // Validation
                    if (MPCF.CheckValue(cdvStore, false) == false)
                    {
                        return;
                    }
                    if (MPCF.CheckValue(cdvInvMatID, false) == false)
                    {
                        return;
                    }
                    if (MPCF.CheckValue(cdvVendor, false) == false)
                    {
                        return;
                    }
                    if (MPCF.CheckValue(cdvLotType, false) == false)
                    {
                        return;
                    }
                    if (MPCF.CheckValue(txtInvLotId, false) == false)
                    {
                        return;
                    }

                    // 중복 입력 체크
                    DataTable dt = gridInvLotList.GetDataSource();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["INV_LOT_ID"].ToString() == txtInvLotId.Text)
                        {
                            // The data is duplicated.
                            MPCF.ShowMessage(MPCF.GetMessage(111) + " : " + txtInvLotId.Text, MSG_LEVEL.ERROR, false);
                            return;
                        }
                    }

                    if (MPCF.ToInt(txtInvLotQty.Value) < 1)
                    {
                        MPCF.SetFocus(txtInvLotQty);
                    }
                    else
                    {
                        btnAdd_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Inv Lot Qty Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInvLotQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (MPCF.ToInt(txtInvLotQty.Value) < 1)
                    {
                        return;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtInvLotId.Text) == false)
                        {
                            btnAdd_Click(null, null);
                        }
                        else
                        {
                            MPCF.SetFocus(txtInvLotId);
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Store CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvStore_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';                
                in_node.AddChar("OPER_STORE_FLAG", 'N');
                in_node.AddChar("NG_STORE_FLAG", 'N');
                in_node.AddChar("IN_OUT_STORE_FLAG", 'I');

                // Display and Header Text Setup
                string[] display = new string[] { "STORE_ID", "STORE_DESC" };
                string[] header = new string[] { "Store ID", "Store Desc" };

                // Show CodeView and Get Return
                cdvStore.Text = cdvStore.Show(cdvStore, "View Store List", "INV", "INV_View_Store_List", in_node, "STORE_LIST", display, header, "Store ID");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Vendor CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvVendor_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "INV_VENDOR");

                // Display and Header Text Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Vendor ID", "Vendor Desc" };

                // Show CodeView and Get Return
                cdvVendor.Text = cdvVendor.Show(cdvVendor, "BAS", "View Vendor List", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Vendor ID");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Inv Mat ID CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvInvMatID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MAT_TYPE", "RM");

                // Display and Header Text Setup
                string[] display = new string[] { "INV_MAT_ID", "INV_MAT_DESC" };
                string[] header = new string[] { "Inv Mat ID", "Inv Mat Desc" };

                // Show CodeView and Get Return
                cdvInvMatID.Text = cdvInvMatID.Show(cdvInvMatID, "View Inv Material List", "INV", "INV_View_INV_Material_List", in_node, "INV_MATERIAL_LIST", display, header, "Inv Mat ID");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Lot Type CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvLotType_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "INV_LOT_TYPE");

                // Display and Header Text Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Lot Type", "Lot Type Desc" };

                // Show CodeView and Get Return
                cdvLotType.Text = cdvLotType.Show(cdvLotType, "BAS", "View Lot Type", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Lot Type");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Add Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LOT_IN");
                TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

                //Validation
                if (MPCF.CheckValue(cdvStore, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvInvMatID, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvVendor, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvLotType, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(txtInvLotId, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(txtInvLotQty, 0.0005, Double.MaxValue, false) == false)
                {
                    return;
                }

                // 중복입력 체크
                DataTable dt = gridInvLotList.GetDataSource();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["INV_LOT_ID"].ToString() == txtInvLotId.Text)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(111) + " : " + txtInvLotId.Text, MSG_LEVEL.ERROR, false);
                        return;
                    }
                }

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INV_MAT_ID", MPCF.Trim(cdvInvMatID.Text));
                in_node.AddInt("INV_MAT_VER", 1);
                if (MPCF.CallService("INV", "INV_View_Inv_Material", in_node, ref out_node) == false)
                {
                    return;
                }

                // Data Bind
                DataRow dr = dt.NewRow();
                dr["chk"] = true;
                dr["INV_LOT_ID"] = txtInvLotId.Text;
                dr["INV_LOT_QTY"] = txtInvLotQty.Text;
                dr["INV_STORE"] = cdvStore.Text;
                dr["INV_MAT_ID"] = cdvInvMatID.Text;
                dr["INV_MAT_DESC"] = out_node.GetString("INV_MAT_DESC");
                dr["LOT_TYPE"] = cdvLotType.Text;
                dr["VENDOR"] = cdvVendor.Text;
                dt.Rows.Add(dr);
                gridInvLotList.SetDataSource(dt);

                txtInvLotId.Text = "";
                txtInvLotQty.Text = "";
                MPCF.SetFocus(txtInvLotId);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Del Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // 데이터가 없는 경우 종료
                if (gridInvLotList.Rows.Count < 1)
                {
                    return;
                }

                // Row 제거
                for (int i = gridInvLotList.Rows.Count - 1; i >= 0; i--)
                {
                    if ((bool)gridInvLotList.Rows[i].Cells[0].Value == true)
                    {
                        gridInvLotList.Rows[i].Delete(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
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
                //Validation
                if (MPCF.CheckValue(cdvStore, false) == false)
                {
                    return;
                }
                DataTable dt = gridInvLotList.GetDataSource();
                if (dt.Rows.Count < 1)
                {
                    return;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {                    
                    if (MPCF.Trim(dt.Rows[i]["INV_STORE"]) == "")
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(107), MSG_LEVEL.ERROR, false);
                        return;
                    }
                }

                // IN INV
                if (CreateInventoryLot() == false)
                {
                    return;
                }

                txtInvLotId.Text = "";
                txtInvLotQty.Text = "";
                MPCF.SetFocus(txtInvLotId);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function Definition

        /// <summary>
        /// Create Inventory Lot
        /// </summary>
        /// <returns></returns>
        private bool CreateInventoryLot()
        {
            TRSNode in_node = new TRSNode("UPDATE_LIST_IN");
            TRSNode out_node = new TRSNode("UPDATE_LIST_OUT");
            TRSNode node;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddChar("OPERATION_TYPE_FLAG", 'L');
                
                DataTable dt = gridInvLotList.GetDataSource();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    node = in_node.AddNode("LIST");
                    node.AddString("INV_LOT_ID", dt.Rows[i]["INV_LOT_ID"]);
                    node.AddString("STORE_ID", dt.Rows[i]["INV_STORE"]);
                    node.AddChar("INV_LOT_TYPE", dt.Rows[i]["LOT_TYPE"]);
                    node.AddString("INV_MAT_ID", dt.Rows[i]["INV_MAT_ID"]);
                    node.AddDouble("QTY_1", dt.Rows[i]["INV_LOT_QTY"]);
                    node.AddChar("INV_LOT_PRIORITY", '5');
                    node.AddString("VENDOR_ID", dt.Rows[i]["VENDOR"]);
                    node.AddString("INV_MAT_VER", 1);
                }

                if (MPCF.CallService("INV", "INV_Create_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                dt.Clear();
                gridInvLotList.InitDataSource();

                MPCF.ShowSuccessMessage(out_node, false);

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
