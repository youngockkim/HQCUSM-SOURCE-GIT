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

namespace SOI.INV
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmINVViewInventoryLotStatus : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        ArrayList CurrStoreList = new ArrayList();

        #endregion

        #region Constructor

        public frmINVViewInventoryLotStatus()
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

        /// <summary>
        /// Inv Lot Id Key Down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInvLotId_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Validation
                    if (MPCF.CheckValue(txtInvLotId, false) == false)
                    {
                        return;
                    }
                    
                    // Search
                    btnProcess_Click(null, null);
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
        private void cdvInvStore_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(txtInvLotId, false) == false)
                {
                    return;
                }

                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INV_LOT_ID", txtInvLotId.Text);

                // Display and Header Text Setup
                string[] display = new string[] { "STORE_ID", "STORE_DESC" };
                string[] header = new string[] { "Store ID", "Store Desc" };

                // Show CodeView and Get Return
                cdvInvStore.Text = cdvInvStore.Show(cdvInvStore, "View Store List", "INV", "INV_View_Inv_Lot_Store_List", in_node, "STORE_LIST", display, header, "Store ID");

                // Field Clear
                MPCF.FieldClear(this, txtInvLotId, cdvInvStore);

                // Validation
                if (string.IsNullOrEmpty(cdvInvStore.Text) == true)
                {
                    return;
                }

                // View Inv Lot Status
                if (ViewInvLotStatus(txtInvLotId.Text, cdvInvStore.Text) == false)
                {
                    MPCF.SetFocus(txtInvLotId);
                    txtInvLotId.SelectAll();
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                TRSNode out_node = new TRSNode("LOT_DATA");

                // Validation
                if (MPCF.CheckValue(txtInvLotId, false) == false)
                {
                    return;
                }

                // Init Message
                MPCF.ShowMessage("", MSG_LEVEL.NONE, false);

                // Field Clear
                MPCF.FieldClear(this, txtInvLotId);

                // View Store
                if (ViewInvLotStoreList(txtInvLotId.Text) == false)
                {
                    return;
                }
                else
                {
                    if (CurrStoreList != null)
                    {
                        // Inv Lot에 할당된 창고가 2건 이상인 경우
                        if (CurrStoreList.Count > 1)
                        {
                            // 이미 선택된 경우
                            if (string.IsNullOrEmpty(cdvInvStore.Text) == false)
                            {
                                // 아무것도 하지 않음
                            }
                            // 선택되지 않은 경우
                            else
                            {
                                cdvInvStore_CodeViewButtonClick(null, null);
                            }
                        }
                        else if (CurrStoreList.Count == 1)
                        {
                            foreach (object obj in CurrStoreList)
                            {
                                out_node = null;
                                out_node = (TRSNode)obj;
                                cdvInvStore.Text = out_node.GetString("STORE_ID");
                            }
                        }
                    }
                }

                if (MPCF.Trim(txtInvLotId.Text) != "")
                {
                    if (ViewInvLotStatus(txtInvLotId.Text, cdvInvStore.Text) == false)
                    {
                        MPCF.SetFocus(txtInvLotId);
                        txtInvLotId.SelectAll();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
        
        #endregion

        #region Function

        /// <summary>
        /// View Store List
        /// </summary>
        private bool ViewInvLotStoreList(string sInvLotId)
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DATA_LIST_OUT");
            List<TRSNode> lisList;

            try
            {
                // Init Curr Store List
                CurrStoreList.Clear();

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INV_LOT_ID", sInvLotId);

                do
                {
                    if (MPCF.CallService("INV", "INV_View_Inv_Lot_Store_List", in_node, ref out_node) == false)
                    {
                        MPCF.ShowMessage(out_node.GetString("MSG"), MSG_LEVEL.ERROR, false);
                        return false;
                    }

                    lisList = out_node.GetList("STORE_LIST");
                    foreach (TRSNode node in lisList)
                    {
                        CurrStoreList.Add(node);
                    }

                    in_node.SetString("NEXT_STORE_ID", out_node.GetString("NEXT_STORE_ID"));
                } while (in_node.GetString("NEXT_STORE_ID") != "");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// View Inventory Lot Status
        /// </summary>
        /// <param name="sInvLotId"></param>
        /// <param name="sStoreId"></param>
        /// <returns></returns>
        private bool ViewInvLotStatus(string sInvLotId, string sStoreId)
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DATA_LIST_OUT");

            try
            {
                // Call Serivce
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INV_LOT_ID", sInvLotId);
                in_node.AddString("STORE_ID", sStoreId);
                if (MPCF.CallService("INV", "INV_View_Inv_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Field Clear
                MPCF.FieldClear(this, txtInvLotId, cdvInvStore);

                //txtInvMatID.Text = "";
                //txtInvMatDesc.Text = "";
                //txtInvStore.Text = "";
                //txtStoreDesc.Text = "";
                //txtInvLotQty.Text = "";
                //txtLotType.Text = "";
                //txtLotStatus.Text = "";
                //txtVendor.Text = "";
                //txtInDate.Text = "";

                // Bind
                txtInvMatID.Text = out_node.GetString("INV_MAT_ID");
                txtInvMatDesc.Text = out_node.GetString("INV_MAT_DESC");
                txtInvStore.Text = out_node.GetString("STORE_ID");
                txtStoreDesc.Text = out_node.GetString("STORE_DESC");
                txtInvLotQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("QTY_1"));
                txtLotType.Text = out_node.GetChar("INV_LOT_TYPE").ToString();
                txtLotStatus.Text = out_node.GetString("INV_LOT_STATUS");
                txtVendor.Text = out_node.GetString("VENDOR_ID");
                txtInDate.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));

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
