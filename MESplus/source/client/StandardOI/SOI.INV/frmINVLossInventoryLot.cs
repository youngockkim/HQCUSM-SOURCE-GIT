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
    public partial class frmINVLossInventoryLot : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        
        private TRSNode LOT;

        ArrayList CurrStoreList = new ArrayList();

        #endregion

        #region Constructor

        public frmINVLossInventoryLot()
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
            LOT = new TRSNode("LOSS_INV_LOT");

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
        /// Lot Id Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInvLotID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnLotIdSearch_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Lot ID Search Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLotIdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                TRSNode out_node = new TRSNode("LOT_DATA");

                // Validation
                if (MPCF.CheckValue(txtInvLotID, false) == false)
                {
                    return;
                }

                // Init Message
                MPCF.ShowMessage("", MSG_LEVEL.NONE, false);
                
                if (ViewInvLotStoreList(txtInvLotID.Text) == false)
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
                            if (string.IsNullOrEmpty(cdvStore.Text) == false)
                            {
                                // 아무것도 하지 않음
                            }
                            // 선택되지 않은 경우
                            else
                            {
                                cdvStore_CodeViewButtonClick(null, null);
                            }
                        }
                        else if (CurrStoreList.Count == 1)
                        {
                            foreach (object obj in CurrStoreList)
                            {
                                out_node = null;
                                out_node = (TRSNode)obj;
                                cdvStore.Text = out_node.GetString("STORE_ID");
                            }
                        }
                    }
                }

                if (MPCF.Trim(txtInvLotID.Text) != "")
                {
                    if (ViewInvLotStatus(txtInvLotID.Text) == false)
                    {
                        MPCF.SetFocus(txtInvLotID);
                        txtInvLotID.SelectAll();                        
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Current Store CodeView
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
                in_node.AddString("INV_LOT_ID", txtInvLotID.Text);

                // Display and Header Text Setup
                string[] display = new string[] { "STORE_ID", "STORE_DESC" };
                string[] header = new string[] { "Store ID", "Store Desc" };

                // Show CodeView and Get Return
                cdvStore.Text = cdvStore.Show(cdvStore, "View Store List", "INV", "INV_View_Inv_Lot_Store_List", in_node, "STORE_LIST", display, header, "Store ID");
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
                MPCF.ShowMessage("", MSG_LEVEL.NONE, false);

                // Validation
                if (MPCF.CheckValue(cdvLossCode, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(txtLossQty, 0.0005, Double.MaxValue, false) == false)
                {
                    txtLossQty.Text = "";
                    return;
                }

                DataTable dt = gridLossInfo.GetDataSource();
                double dLossQtyTotal = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dLossQtyTotal += MPCF.ToDbl(dt.Rows[i]["LOSS_QTY"]);
                }
                double dLossQty = Convert.ToDouble(txtLossQty.Text);
                if (((dLossQtyTotal + dLossQty) - MPCF.ToDbl(txtInvLotQty.Text)) > 0.0005)
                {
                    txtLossQty.Text = "";
                    return;
                }

                bool bFound = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][1].ToString() == cdvLossCode.Text)
                    {
                        dt.Rows[i][3] = (Convert.ToInt32(dt.Rows[i][3]) + Convert.ToInt32(txtLossQty.Text));

                        bFound = true;
                        break;
                    }
                }

                if (bFound == false)
                {                    
                    DataRow dr = dt.NewRow();
                    dr[0] = true;
                    dr[1] = cdvLossCode.Text;
                    dr[2] = (cdvLossCode.Tag == null ? string.Empty : cdvLossCode.Tag.ToString());
                    dr[3] = txtLossQty.Text;
                    dt.Rows.Add(dr);
                }

                // Bind
                gridLossInfo.DataBind();

                txtTotalLoss.Text = (Convert.ToInt32(txtTotalLoss.Text.Replace(",", "")) + Convert.ToInt32(txtLossQty.Text.Replace(",", ""))).ToString();
                txtLotRemain.Text = (Convert.ToInt32(txtLotRemain.Text.Replace(",", "")) - Convert.ToInt32(txtLossQty.Text.Replace(",", ""))).ToString();
                
                cdvLossCode.Text = txtLossQty.Text = "";
                MPCF.SetFocus(cdvLossCode);
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
                if (gridLossInfo.Rows.Count < 1)
                {
                    return;
                }

                // Row 제거
                for (int i = gridLossInfo.Rows.Count - 1; i >= 0; i--)
                {
                    if ((bool)gridLossInfo.Rows[i].Cells[0].Value == true)
                    {
                        txtTotalLoss.Text = (Convert.ToInt32(txtTotalLoss.Text.Replace(",", "")) - Convert.ToInt32(gridLossInfo.Rows[i].Cells[3].Value)).ToString();
                        txtLotRemain.Text = (Convert.ToInt32(txtLotRemain.Text.Replace(",", "")) + Convert.ToInt32(gridLossInfo.Rows[i].Cells[3].Value)).ToString();

                        gridLossInfo.Rows[i].Delete(false);
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
                // Validation
                if (MPCF.CheckValue(txtInvLotID, false) == false)
                {
                    return;
                }

                DataTable dt = gridLossInfo.GetDataSource();
                if (dt.Rows.Count < 1)
                {
                    return;
                }

                if (LossInventoryLot() == false)
                {
                    MPCF.SetFocus(txtInvLotID);
                    txtInvLotID.SelectAll();
                    return;
                }

                dt.Rows.Clear();
                gridLossInfo.DataBind();
                MPCF.SetFocus(txtInvLotID);
                txtInvLotID.SelectAll();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Loss Qty Enter key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLossQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && MPCF.ToDbl(txtLossQty.Value) > 0.0005)
                {
                    btnAdd_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Loss Code CodeViewButtonClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvLossCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "INV_LOSS_CODE");

                // Display and Header Text Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Loss Code", "Loss Desc" };

                // Show
                cdvLossCode.Text = cdvLossCode.Show(cdvLossCode, "Loss Code", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                if (string.IsNullOrEmpty(cdvLossCode.Text) == true)
                {
                    return;
                }

                MPCF.SetFocus(txtLossQty);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// View Inv Lot Status
        /// </summary>
        /// <param name="sInvLotId"></param>
        /// <returns></returns>
        private bool ViewInvLotStatus(string sInvLotId)
        {
            try
            {
                //if (_model.VendorList == null)
                //{
                //    ViewVendorList();
                //}
                //if (_model.LotTypeList == null)
                //{
                //    ViewLotTypeList();
                //}

                txtInvMatID.Text = "";
                txtInvMatDesc.Text = "";
                txtStore.Text = "";
                txtStoreDesc.Text = "";
                txtInvLotQty.Text = "";
                txtLotType.Text = "";
                txtLotStatus.Text = "";
                txtVendor.Text = "";
                txtInDate.Text = "";
                cdvLossCode.Text = "";
                txtLossQty.Text = "";

                if (gridLossInfo.Rows.Count > 0)
                {
                    DataTable dt_temp = gridLossInfo.GetDataSource();
                    dt_temp.Clear();
                }

                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_DATA_LIST_OUT");

                MPCF.SetInMsg(in_node);

                in_node.ProcStep = '1';
                in_node.AddString("INV_LOT_ID", sInvLotId);

                if (string.IsNullOrEmpty(cdvStore.Text) == false)
                {
                    in_node.AddString("STORE_ID", cdvStore.Text);
                }

                if (MPCF.CallService("INV", "INV_View_Inv_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                //foreach (LotTypeInfo a in _model.LotTypeList)
                //{
                //    if (out_node.GetChar("INV_LOT_TYPE").ToString() == a.LotType)
                //    {
                //        out_node.AddString("INV_LOT_TYPE_DESC", a.LotTypeDesc);
                //        break;
                //    }
                //}
                //foreach (VendorInfo a in _model.VendorList)
                //{
                //    if (out_node.GetString("VENDOR_ID").ToString() == a.Vendor)
                //    {
                //        out_node.AddString("VENDOR_DESC", a.VendorDesc);
                //        break;
                //    }
                //}

                txtInvMatID.Text = out_node.GetString("INV_MAT_ID");
                txtInvMatDesc.Text = out_node.GetString("INV_MAT_DESC");
                txtStore.Text = out_node.GetString("STORE_ID");
                txtStoreDesc.Text = out_node.GetString("STORE_DESC");
                txtInvLotQty.Text = MPCF.MakeNumberFormat(out_node.GetDouble("QTY_1"));
                txtLotType.Text = out_node.GetChar("INV_LOT_TYPE").ToString();
                txtLotStatus.Text = out_node.GetString("INV_LOT_STATUS");
                txtVendor.Text = out_node.GetString("VENDOR_ID");
                txtInDate.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));

                txtLotRemain.Text = txtInvLotQty.Text;
                txtTotalLoss.Text = "0";

                LOT = out_node;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

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
        /// Loss Inventory Lot
        /// </summary>
        /// <returns></returns>
        private bool LossInventoryLot()
        {
            try
            {
                TRSNode in_node = new TRSNode("UPDATE_LIST_IN");
                TRSNode out_node = new TRSNode("UPDATE_LIST_OUT");                

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("INV_LOT_ID", txtInvLotID.Text);
                in_node.AddString("INV_MAT_ID", txtInvMatID.Text);
                in_node.AddString("STORE_ID", txtStore.Text);
                in_node.AddDouble("TOTAL_QTY_1", txtTotalLoss.Text);
                in_node.AddInt("INV_MAT_VER", 1);

                SetLossInfo(in_node);

                if (MPCF.CallService("INV", "INV_Loss_Inv_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (ViewInvLotStatus(txtInvLotID.Text) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Loss Info
        /// </summary>
        /// <param name="in_node"></param>
        /// <returns></returns>
        private bool SetLossInfo(TRSNode in_node)
        {
            try
            {
                TRSNode loss_item;

                DataTable dt = gridLossInfo.GetDataSource();
                if (dt.Rows.Count < 1)
                {
                    return true;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    loss_item = in_node.AddNode("LOSS_LIST");

                    loss_item.AddString("CODE", dt.Rows[i][1].ToString());
                    loss_item.AddDouble("QTY", MPCF.ToDbl(dt.Rows[i][3]));
                }

                gridLossInfo.InitDataSource();

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
