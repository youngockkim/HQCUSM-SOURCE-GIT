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
    public partial class frmINVOutInventoryLot : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        ArrayList CurrStoreList = new ArrayList();

        private enum COL_OUT_INVLOT_LIST
        {
            CHK = 0,
            INV_LOT_ID,
            INV_LOT_QTY,
            INV_MAT_ID,
            INV_MAT_DESC,
            INV_STORE,
            STORE_DESC,
            LOT_TYPE,
            VENDOR,
            LAST_ACTIVE_HIST_SEQ,
            INV_MAT_VER
        }

        #endregion

        #region Constructor

        public frmINVOutInventoryLot()
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
        /// Lot Id Enter Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInvLotId_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
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
        /// Target Store CodeView
        /// 대상창고를 찾습니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvOutStore_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';                
                in_node.AddChar("OPER_STORE_FLAG", 'Y');

                // Display and Header Text Setup
                string[] display = new string[] { "STORE_ID", "STORE_DESC" };
                string[] header = new string[] { "Store ID", "Store Desc" };

                // Show CodeView and Get Return
                cdvOutStore.Text = cdvOutStore.Show(cdvOutStore, "View Store List", "INV", "INV_View_Store_List", in_node, "STORE_LIST", display, header, "Store ID");
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
                in_node.AddString("INV_LOT_ID", txtInvLotId.Text);

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
                TRSNode out_node = new TRSNode("LOT_DATA");

                // Validation
                if (MPCF.CheckValue(cdvOutStore, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(txtInvLotId, false) == false)
                {
                    return;
                }
                DataTable dt = gridInvLotList.GetDataSource();
                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToString(dr[(int)COL_OUT_INVLOT_LIST.INV_LOT_ID]) == txtInvLotId.Text)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(111), MSG_LEVEL.ERROR, false);
                        MPCF.SetFocus(txtInvLotId);
                        txtInvLotId.SelectAll();
                        return;
                    }
                }
                
                // View Int Lot Store List
                if (ViewInvLotStoreList(txtInvLotId.Text) == false)
                {
                    return;
                }
                else
                {
                    // Inv Lot에 할당된 창고가 2건 이상인 경우
                    if (CurrStoreList != null)
                    {
                        if (CurrStoreList.Count > 1)
                        {
                            cdvStore_CodeViewButtonClick(null, null);
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
                    else
                    {
                        return;
                    }
                }

                if (ViewInvLotInfo(txtInvLotId.Text) == false)
                {
                    MPCF.SetFocus(txtInvLotId);
                    txtInvLotId.SelectAll();
                    return;
                }

                // 초기화
                txtInvLotId.Text = "";
                cdvStore.Text = "";
                MPCF.ShowMessage("", MSG_LEVEL.NONE, false);

                // 다음 포커스
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
                // Validation
                if (gridInvLotList.Rows.Count < 1)
                {
                    return;
                }

                if (OutInventoryLot() == false)
                {
                    return;
                }

                MPCF.SetFocus(txtInvLotId);
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
            try
            {
                // Clear
                CurrStoreList.Clear();

                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_DATA_LIST_OUT");
                List<TRSNode> lisList;

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
        /// View Inv Lot Info
        /// </summary>
        /// <param name="sInvLotId"></param>
        /// <returns></returns>
        private bool ViewInvLotInfo(string sInvLotId)
        {
            try
            {
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

                DataTable dt = gridInvLotList.GetDataSource();                
                DataRow dr = dt.NewRow();
                dr[(int)COL_OUT_INVLOT_LIST.CHK] = true;
                dr[(int)COL_OUT_INVLOT_LIST.INV_LOT_ID] = sInvLotId;
                dr[(int)COL_OUT_INVLOT_LIST.INV_LOT_QTY] = out_node.GetDouble("QTY_1");
                dr[(int)COL_OUT_INVLOT_LIST.INV_MAT_ID] =  out_node.GetString("INV_MAT_ID");
                dr[(int)COL_OUT_INVLOT_LIST.INV_MAT_DESC] =  out_node.GetString("INV_MAT_DESC");
                dr[(int)COL_OUT_INVLOT_LIST.INV_STORE] =  out_node.GetString("STORE_ID");
                dr[(int)COL_OUT_INVLOT_LIST.STORE_DESC] =  out_node.GetString("STORE_DESC");
                dr[(int)COL_OUT_INVLOT_LIST.LOT_TYPE] =  out_node.GetChar("INV_LOT_TYPE").ToString();
                dr[(int)COL_OUT_INVLOT_LIST.VENDOR] = out_node.GetString("VENDOR_ID");
                dr[(int)COL_OUT_INVLOT_LIST.LAST_ACTIVE_HIST_SEQ] = out_node.GetInt("LAST_ACTIVE_HIST_SEQ");
                dr[(int)COL_OUT_INVLOT_LIST.INV_MAT_VER] = out_node.GetInt("INV_MAT_VER");
                dt.Rows.Add(dr);
                
                // Bind
                gridInvLotList.SetDataSource(dt);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Out Inventory Lot
        /// </summary>
        /// <returns></returns>
        private bool OutInventoryLot()
        {
            TRSNode in_node = new TRSNode("INV_OUT_INV_LOT_IN");
            TRSNode out_node = new TRSNode("INV_OUT_INV_LOT_OUT");

            bool bFailed = false;
            List<int> successIndex = new List<int>();
            List<INVOutInvLotFailedModel> failedList = new List<INVOutInvLotFailedModel>();

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TO_STORE_ID", cdvOutStore.Text);

                DataTable dt = gridInvLotList.GetDataSource();

                for(int i = 0 ; i < dt.Rows.Count; i++)
                {
                    in_node.SetString("INV_LOT_ID", Convert.ToString(dt.Rows[i][(int)COL_OUT_INVLOT_LIST.INV_LOT_ID]));
                    in_node.SetString("STORE_ID", Convert.ToString(dt.Rows[i][(int)COL_OUT_INVLOT_LIST.INV_STORE]));
                    in_node.SetString("INV_MAT_ID", Convert.ToString(dt.Rows[i][(int)COL_OUT_INVLOT_LIST.INV_MAT_ID]));
                    in_node.SetInt("INV_MAT_VER", MPCF.ToInt(dt.Rows[i][(int)COL_OUT_INVLOT_LIST.INV_MAT_VER]));
                    in_node.SetDouble("QTY_1", MPCF.ToDbl(dt.Rows[i][(int)COL_OUT_INVLOT_LIST.INV_LOT_QTY]));
                    in_node.SetInt("LAST_ACTIVE_HIST_SEQ", MPCF.ToInt(dt.Rows[i][(int)COL_OUT_INVLOT_LIST.LAST_ACTIVE_HIST_SEQ]));

                    if (MPCF.CallService("INV", "INV_Out_Inv_Lot", in_node, ref out_node) == false)
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
                                INVOutInvLotFailedModel failedModel = new INVOutInvLotFailedModel();
                                failedModel.INV_LOT_ID = Convert.ToString(dt.Rows[index][(int)COL_OUT_INVLOT_LIST.INV_LOT_ID]);
                                failedModel.INV_LOT_QTY = MPCF.ToDbl(dt.Rows[index][(int)COL_OUT_INVLOT_LIST.INV_LOT_QTY]);
                                failedModel.INV_MAT_ID = Convert.ToString(dt.Rows[index][(int)COL_OUT_INVLOT_LIST.INV_MAT_ID]);
                                failedModel.INV_MAT_DESC = Convert.ToString(dt.Rows[index][(int)COL_OUT_INVLOT_LIST.INV_MAT_DESC]);
                                failedModel.INV_STORE = Convert.ToString(dt.Rows[index][(int)COL_OUT_INVLOT_LIST.INV_STORE]);
                                failedModel.STORE_DESC = Convert.ToString(dt.Rows[index][(int)COL_OUT_INVLOT_LIST.STORE_DESC]);
                                failedModel.LOT_TYPE = Convert.ToString(dt.Rows[index][(int)COL_OUT_INVLOT_LIST.LOT_TYPE]);
                                failedModel.VENDOR = Convert.ToString(dt.Rows[index][(int)COL_OUT_INVLOT_LIST.VENDOR]);
                                failedModel.LAST_ACTIVE_HIST_SEQ = MPCF.ToInt(dt.Rows[index][(int)COL_OUT_INVLOT_LIST.LAST_ACTIVE_HIST_SEQ]);
                                failedModel.INV_MAT_VER = MPCF.ToInt(dt.Rows[index][(int)COL_OUT_INVLOT_LIST.INV_MAT_VER]);
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
                    // Clear
                    MPCF.FieldClear(gridInvLotList);

                    // Out Message
                    MPCF.ShowMessage(out_node.GetString(TRSDefine.OUT_MSG), MSG_LEVEL.ERROR, false);

                    // DataTable 호출
                    dt = gridInvLotList.GetDataSource();

                    foreach (INVOutInvLotFailedModel mod in failedList)
                    {
                        DataRow dr = dt.NewRow();
                        dr[(int)COL_OUT_INVLOT_LIST.CHK] = true;
                        dr[(int)COL_OUT_INVLOT_LIST.INV_LOT_ID] = mod.INV_LOT_ID;
                        dr[(int)COL_OUT_INVLOT_LIST.INV_LOT_QTY] = mod.INV_LOT_QTY;
                        dr[(int)COL_OUT_INVLOT_LIST.INV_MAT_ID] = mod.INV_MAT_ID;
                        dr[(int)COL_OUT_INVLOT_LIST.INV_MAT_DESC] = mod.INV_MAT_DESC;
                        dr[(int)COL_OUT_INVLOT_LIST.INV_STORE] = mod.INV_STORE;
                        dr[(int)COL_OUT_INVLOT_LIST.STORE_DESC] = mod.STORE_DESC;
                        dr[(int)COL_OUT_INVLOT_LIST.LOT_TYPE] = mod.LOT_TYPE;
                        dr[(int)COL_OUT_INVLOT_LIST.VENDOR] = mod.VENDOR;
                        dr[(int)COL_OUT_INVLOT_LIST.LAST_ACTIVE_HIST_SEQ] = mod.LAST_ACTIVE_HIST_SEQ;
                        dr[(int)COL_OUT_INVLOT_LIST.INV_MAT_VER] = mod.INV_MAT_VER;
                        dt.Rows.Add(dr);
                    }

                    gridInvLotList.SetDataSource(dt);

                    return false;
                }

                // Clear
                MPCF.FieldClear(gridInvLotList);

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

    public class INVOutInvLotFailedModel
    {       
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

         private string inv_store;
        public string INV_STORE
        {
            get { return inv_store; }
            set { inv_store = value; }
        }

        private string store_desc;
        public string STORE_DESC
        {
            get { return store_desc; }
            set { store_desc = value; }
        }

         private string lot_type;
        public string LOT_TYPE
        {
            get { return lot_type; }
            set { lot_type = value; }
        }

         private string vendor;
        public string VENDOR
        {
            get { return vendor; }
            set { vendor = value; }
        }

        private int last_active_hist_seq;
        public int LAST_ACTIVE_HIST_SEQ
        {
            get { return last_active_hist_seq; }
            set { last_active_hist_seq = value; }
        }

        private int inv_mat_ver;
        public int INV_MAT_VER
        {
            get { return inv_mat_ver; }
            set { inv_mat_ver = value; }
        }
    }
}
