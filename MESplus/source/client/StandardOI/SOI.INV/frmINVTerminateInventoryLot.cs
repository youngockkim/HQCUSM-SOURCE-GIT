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
    public partial class frmINVTerminateInventoryLot : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private enum COL_INV_LOT_LIST
        {
            CHK = 0,
            INV_LOT_ID,
            INV_LOT_QTY,
            INV_MAT_ID,
            INV_MAT_DESC,
            INV_LOT_TYPE,
            INV_LOT_STATUS,
            VENDOR
        }

        #endregion

        #region Constructor

        public frmINVTerminateInventoryLot()
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
            gridInvLotList.InitDataSource();

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

                // Display and Header Text Setup
                string[] display = new string[] { "STORE_ID", "STORE_DESC" };
                string[] header = new string[] { "Store ID", "Store Desc" };

                // Show CodeView and Get Return
                cdvStore.Text = cdvStore.Show(cdvStore, "View Store List", "INV", "INV_View_Store_List", in_node, "STORE_LIST", display, header, "Store ID");

                // Field Clear
                MPCF.FieldClear(this, cdvStore);

                // Validation
                if (string.IsNullOrEmpty(cdvStore.Text) == true)
                {
                    return;
                }

                // Focus
                MPCF.SetFocus(cdvInvMatId);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Inventory Material CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvInvMatId_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvStore, false) == false)
                {
                    return;
                }

                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MAT_TYPE", "RM");

                // Display and Header Text Setup
                string[] display = new string[] { "INV_MAT_ID", "INV_MAT_DESC" };
                string[] header = new string[] { "Inv Mat ID", "Inv Mat Desc" };

                // Show CodeView and Get Return
                cdvInvMatId.Text = cdvInvMatId.Show(cdvInvMatId, "View Inv Material List", "INV", "INV_View_INV_Material_List", in_node, "INV_MATERIAL_LIST", display, header, "Inv Mat ID");

                // Field Clear
                MPCF.FieldClear(this, cdvStore, cdvInvMatId);

                // Validation
                if (string.IsNullOrEmpty(cdvInvMatId.Text) == true)
                {
                    return;
                }

                // View Inventory Lot List
                if (ViewInvLotList() == false)
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
        /// Inventory Lot ID Search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInvLotId_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnLotIDSearch_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Lot ID Search Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLotIDSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (gridInvLotList.Rows.Count < 1)
                {
                    return;
                }

                // Search & Scroll                
                DataTable dt = gridInvLotList.GetDataSource();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][(int)COL_INV_LOT_LIST.INV_LOT_ID].ToString() == txtInvLotId.Text)
                    {
                        dt.Rows[i][(int)COL_INV_LOT_LIST.CHK] = true;
                        MPCF.SetScrollRow(gridInvLotList, gridInvLotList.Rows[i].Cells[(int)COL_INV_LOT_LIST.INV_LOT_ID].Column.Key, txtInvLotId);
                    }
                }
                gridInvLotList.SetDataSource(dt);

                // Focus
                MPCF.SetFocus(txtInvLotId);
                txtInvLotId.SelectAll();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Select All Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (gridInvLotList.Rows.Count < 1)
                {
                    return;
                }

                // Check
                for (int i = 0; i < gridInvLotList.Rows.Count; i++)
                {
                    gridInvLotList.Rows[i].Cells[(int)COL_INV_LOT_LIST.CHK].Value = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Release All Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReleaseAll_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (gridInvLotList.Rows.Count < 1)
                {
                    return;
                }

                // UnCheck
                for (int i = 0; i < gridInvLotList.Rows.Count; i++)
                {
                    gridInvLotList.Rows[i].Cells[(int)COL_INV_LOT_LIST.CHK].Value = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Inventory Lot List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewInvLotList_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvStore, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvInvMatId, false) == false)
                {
                    return;
                }

                // View Inventory Lot List
                if (ViewInvLotList() == false)
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
        /// Process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (gridInvLotList.Rows.Count < 1)
                {
                    return;
                }
                int iCheckedCount = 0;
                for (int i = 0; i < gridInvLotList.Rows.Count; i++)
                {
                    if ((bool)gridInvLotList.Rows[i].Cells[0].Value == false)
                    {
                        continue;
                    }
                    iCheckedCount++;
                }
                if (iCheckedCount < 1)
                {
                    return;
                }

                // Terminate
                if (TerminateInventoryLot() == false)
                {
                    return;
                }

                // View Inventory Lot List
                if (ViewInvLotList() == false)
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

        #region Function

        /// <summary>
        /// View Inv Lot List by Store
        /// </summary>
        /// <returns></returns>
        private bool ViewInvLotList()
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DATA_LIST_OUT");
            ArrayList lisList = new ArrayList();

            try
            {
                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("STORE_ID", cdvStore.Text);
                in_node.AddString("INV_MAT_ID", cdvInvMatId.Text);
                do
                {
                    if (MPCF.CallService("INV", "INV_View_Inv_Lot_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    lisList.Add(out_node);
                    in_node.SetString("NEXT_INV_LOT_ID", out_node.GetString("NEXT_INV_LOT_ID"));
                } while (in_node.GetString("NEXT_INV_LOT_ID") != "");

                // Field Clear
                MPCF.FieldClear(txtInvLotId);
                MPCF.FieldClear(gridInvLotList);

                // Bind
                DataTable dt = null;
                DataRow dr = null;
                foreach (object obj in lisList)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    dt = gridInvLotList.GetDataSource();                        
                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {  
                        dr = dt.NewRow();
                        dr[(int)COL_INV_LOT_LIST.CHK] = false;
                        dr[(int)COL_INV_LOT_LIST.INV_LOT_ID] = out_node.GetList(0)[i].GetString("INV_LOT_ID");
                        dr[(int)COL_INV_LOT_LIST.INV_LOT_QTY] = out_node.GetList(0)[i].GetDouble("QTY_1");
                        dr[(int)COL_INV_LOT_LIST.INV_MAT_ID] = out_node.GetList(0)[i].GetString("INV_MAT_ID");
                        dr[(int)COL_INV_LOT_LIST.INV_MAT_DESC] = out_node.GetList(0)[i].GetString("INV_MAT_DESC");
                        dr[(int)COL_INV_LOT_LIST.INV_LOT_TYPE] = out_node.GetList(0)[i].GetChar("INV_LOT_TYPE");
                        dr[(int)COL_INV_LOT_LIST.INV_LOT_STATUS] = out_node.GetList(0)[i].GetString("INV_LOT_STATUS");
                        dr[(int)COL_INV_LOT_LIST.VENDOR] = out_node.GetList(0)[i].GetString("VENDOR_ID");
                        dt.Rows.Add(dr);
                    }

                    gridInvLotList.SetDataSource(dt);
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Terminate Inventory Lot
        /// </summary>
        /// <returns></returns>
        private bool TerminateInventoryLot()
        {
            TRSNode in_node = new TRSNode("UPDATE_LIST_IN");
            TRSNode out_node = new TRSNode("UPDATE_LIST_OUT");

            bool bFailed = false;
            List<int> successIndex = new List<int>();
            List<INVTermInvLotFailedModel> failedList = new List<INVTermInvLotFailedModel>();

            try
            {
                // Validation
                DataTable dt = gridInvLotList.GetDataSource();

                if (dt.Rows.Count < 1)
                {
                    return true;
                }

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((bool)dt.Rows[i][(int)COL_INV_LOT_LIST.CHK] == false)
                    {
                        continue;
                    }

                    in_node.SetString("INV_LOT_ID", gridInvLotList.Rows[i].Cells[1].Value);
                    in_node.SetString("STORE_ID", cdvStore.Text);
                    in_node.SetString("TERMINATE_CODE", "TERM");

                    if (MPCF.CallService("INV", "INV_Terminate_Inv_Lot", in_node, ref out_node) == false)
                    {
                        bFailed = true;

                        for (int index = 0; index < dt.Rows.Count; index++)
                        {
                            if (successIndex.Contains(index) == true)
                            {
                                continue;
                            }
                            else
                            {
                                INVTermInvLotFailedModel failedModel = new INVTermInvLotFailedModel();
                                failedModel.CHK = Convert.ToBoolean(dt.Rows[index][(int)COL_INV_LOT_LIST.CHK]);
                                failedModel.INV_LOT_ID = Convert.ToString(dt.Rows[index][(int)COL_INV_LOT_LIST.INV_LOT_ID]);
                                failedModel.INV_LOT_QTY = MPCF.ToDbl(dt.Rows[index][(int)COL_INV_LOT_LIST.INV_LOT_QTY]);
                                failedModel.INV_MAT_ID = Convert.ToString(dt.Rows[index][(int)COL_INV_LOT_LIST.INV_MAT_ID]);
                                failedModel.INV_MAT_DESC = Convert.ToString(dt.Rows[index][(int)COL_INV_LOT_LIST.INV_MAT_DESC]);
                                failedModel.INV_LOT_TYPE = Convert.ToString(dt.Rows[index][(int)COL_INV_LOT_LIST.INV_LOT_TYPE]);
                                failedModel.INV_LOT_STATUS = Convert.ToString(dt.Rows[index][(int)COL_INV_LOT_LIST.INV_LOT_STATUS]);
                                failedModel.VENDOR = Convert.ToString(dt.Rows[index][(int)COL_INV_LOT_LIST.VENDOR]);
                                failedList.Add(failedModel);
                            }
                        }

                        break;
                    }

                    successIndex.Add(i);
                }

                // 한건이라도 실패한 경우
                if (bFailed == true)
                {
                    // Field Clear
                    MPCF.FieldClear(gridInvLotList);

                    // Out Message
                    MPCF.ShowMessage(out_node.GetString(TRSDefine.OUT_MSG), MSG_LEVEL.ERROR, false);

                    // DataTable 호출
                    dt = gridInvLotList.GetDataSource();
                    
                    foreach (INVTermInvLotFailedModel mod in failedList)
                    {
                        DataRow dr = dt.NewRow();
                        dr[(int)COL_INV_LOT_LIST.CHK] = mod.CHK;
                        dr[(int)COL_INV_LOT_LIST.INV_LOT_ID] = mod.INV_LOT_ID;
                        dr[(int)COL_INV_LOT_LIST.INV_LOT_QTY] = mod.INV_LOT_QTY;
                        dr[(int)COL_INV_LOT_LIST.INV_MAT_ID] = mod.INV_MAT_ID;
                        dr[(int)COL_INV_LOT_LIST.INV_MAT_DESC] = mod.INV_MAT_DESC;
                        dr[(int)COL_INV_LOT_LIST.INV_LOT_TYPE] = mod.INV_LOT_TYPE;
                        dr[(int)COL_INV_LOT_LIST.INV_LOT_STATUS] = mod.INV_LOT_STATUS;
                        dr[(int)COL_INV_LOT_LIST.VENDOR] = mod.VENDOR;
                        dt.Rows.Add(dr);
                    }

                    gridInvLotList.SetDataSource(dt);

                    return false;
                }

                // View Lot
                if (ViewInvLotList() == false)
                {
                    return false;
                }

                // Success
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

    public class INVTermInvLotFailedModel
    {
        private bool chk;
        public bool CHK
        {
            get { return chk; }
            set { chk = value; }
        }

        private string inv_lot_id;
        public string INV_LOT_ID
        {
            get { return inv_lot_id; }
            set { inv_lot_id = value; }
        }

        private double inv_lot_qty;
        public double INV_LOT_QTY
        {
            get { return inv_lot_qty; }
            set { inv_lot_qty = value; }
        }

        private string inv_mat_id;
        public string INV_MAT_ID
        {
            get { return inv_mat_id; }
            set { inv_mat_id = value; }
        }

        private string inv_mat_desc;
        public string INV_MAT_DESC
        {
            get { return inv_mat_desc; }
            set { inv_mat_desc = value; }
        }

        private string inv_lot_type;
        public string INV_LOT_TYPE
        {
            get { return inv_lot_type; }
            set { inv_lot_type = value; }
        }

         private string inv_lot_status;
        public string INV_LOT_STATUS
        {
            get { return inv_lot_status; }
            set { inv_lot_status = value; }
        }

         private string vendor;
        public string VENDOR
        {
            get { return vendor; }
            set { vendor = value; }
        }
    }
}
