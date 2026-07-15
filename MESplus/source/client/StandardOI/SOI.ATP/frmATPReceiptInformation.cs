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

namespace SOI.ATP
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmATPReceiptInformation : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        public ATPReceiptInformationModel model = new ATPReceiptInformationModel();

        private enum COL_INV_LOT_LIST
        {
            WORK_CENTER = 1,
            STORE_ID,
            STORE_DESC,
            INV_MAT_TYPE,
            INV_MAT_TYPE_DESC,
            INV_MAT_ID,
            INV_MAT_DESC,
            INV_LOT_ID,
            QTY
        }

        #endregion

        #region Constructor

        public frmATPReceiptInformation()
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
            // TEST DATA
            txtDeliveryNote.Text = model.DeliveryNote;
            txtDeliveryDate.Text = model.DeliveryDate;
            txtVendor.Text = model.Vendor;
            txtDeliveryStatus.Text = model.DeliveryStatusDesc;
            cdvInvMatID.Text = model.MatCode;
            txtInvMatDesc.Text = model.MatDesc;

            ViewInvLotList();

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
        /// Inventory Material CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvInvMatID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Pre-Search 
                TRSNode in_node = new TRSNode("VIEW_INV_MAT_IN");
                TRSNode out_node = new TRSNode("VIEW_INV_MAT_OUT");

                // In Node Setup                
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';

                // CodeView Column Header Setup
                string[] header = new string[] { "Inventory Material ID", "Inventory Material Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "INV_MAT_ID", "INV_MAT_DESC" };

                // Show
                cdvInvMatID.Text = cdvInvMatID.Show(cdvInvMatID, "Inventory Material", "INV", "INV_View_Inv_Material_List", in_node, "INV_MATERIAL_LIST", display, header, "INV_MAT_ID");

                // Description
                if (string.IsNullOrEmpty(cdvInvMatID.Text) == true)
                {
                    txtInvMatDesc.Text = string.Empty;
                }
                if (cdvInvMatID.returnDatas != null && cdvInvMatID.returnDatas.Count > 0)
                {
                    txtInvMatDesc.Text = cdvInvMatID.returnDatas[1];                    
                }

                // View
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
        /// CheckBox Select All / Release All
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdInvLotList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                // First Column Header Cell
                if (e.Row == 0 && e.Column == 0 && e.ColumnHeader == true)
                {
                    // Select All
                    if (spdInvLotList.Sheets[0].ColumnHeader.Cells[0, 0].Value == null
                        || ((bool)spdInvLotList.Sheets[0].ColumnHeader.Cells[0, 0].Value) == false)
                    {
                        spdInvLotList.Sheets[0].ColumnHeader.Cells[0, 0].Value = true;

                        for (int i = 0; i < spdInvLotList.Sheets[0].Rows.Count; i++)
                        {
                            spdInvLotList.Sheets[0].Cells[i, 0].Value = true;
                        }
                    }
                    // Release All
                    else
                    {
                        spdInvLotList.Sheets[0].ColumnHeader.Cells[0, 0].Value = false;

                        for (int i = 0; i < spdInvLotList.Sheets[0].Rows.Count; i++)
                        {
                            spdInvLotList.Sheets[0].Cells[i, 0].Value = false;
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
        /// View Receipt Information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
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
        /// View Inventory Lot List
        /// </summary>
        /// <returns></returns>
        private bool ViewInvLotList()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_INV_LOT_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_INV_LOT_LIST_OUT");

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("DLV_NO", model.DeliveryNote);
                in_node.AddString("MAT_ID", cdvInvMatID.Text);
                in_node.AddChar("RECIPT_FLAG", chkReceipt.Checked == true ? 'Y' : 'N');
                in_node.AddChar("NON_RECIPT_FLAG", chkNonReceipt.Checked == true ? 'Y' : 'N');

                if (MPCF.CallService("ATP", "ATP_View_Delivery_Dtl_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Spread Clear
                spdInvLotList.Sheets[0].Rows.Clear();

                // Bind
                if (out_node.GetList(0) != null)
                {
                    int iRow = 0;

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdInvLotList.Sheets[0].Rows.Count;
                        spdInvLotList.Sheets[0].RowCount++;

                        spdInvLotList.Sheets[0].Cells[iRow, 0].Value = false;
                        spdInvLotList.Sheets[0].Cells[iRow, (int)COL_INV_LOT_LIST.WORK_CENTER].Value = out_node.GetList(0)[i].GetString("PLANT_ID");
                        spdInvLotList.Sheets[0].Cells[iRow, (int)COL_INV_LOT_LIST.STORE_ID].Value = out_node.GetList(0)[i].GetString("STORE_ID");
                        spdInvLotList.Sheets[0].Cells[iRow, (int)COL_INV_LOT_LIST.STORE_DESC].Value = out_node.GetList(0)[i].GetString("STORE_DESC");
                        spdInvLotList.Sheets[0].Cells[iRow, (int)COL_INV_LOT_LIST.INV_MAT_TYPE].Value = out_node.GetList(0)[i].GetString("INV_MAT_TYPE");
                        spdInvLotList.Sheets[0].Cells[iRow, (int)COL_INV_LOT_LIST.INV_MAT_TYPE_DESC].Value = out_node.GetList(0)[i].GetString("INV_MAT_TYPE_DESC");
                        spdInvLotList.Sheets[0].Cells[iRow, (int)COL_INV_LOT_LIST.INV_MAT_ID].Value = out_node.GetList(0)[i].GetString("INV_MAT_ID");
                        spdInvLotList.Sheets[0].Cells[iRow, (int)COL_INV_LOT_LIST.INV_MAT_DESC].Value = out_node.GetList(0)[i].GetString("INV_MAT_DESC");
                        spdInvLotList.Sheets[0].Cells[iRow, (int)COL_INV_LOT_LIST.INV_LOT_ID].Value = out_node.GetList(0)[i].GetString("LABEL_ID");
                        spdInvLotList.Sheets[0].Cells[iRow, (int)COL_INV_LOT_LIST.QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("DLV_QTY"));
                    }
                }

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

    public class ATPReceiptInformationModel
    {
        private string deliveryNote;
        public string DeliveryNote
        {
            get { return deliveryNote; }
            set { deliveryNote = value; }
        }

        private string deliveryDate;
        public string DeliveryDate
        {
            get { return deliveryDate; }
            set { deliveryDate = value; }
        }

        private string vendor;
        public string Vendor
        {
            get { return vendor; }
            set { vendor = value; }
        }

        //private string customer;
        //public string Customer
        //{
        //    get { return customer; }
        //    set { customer = value; }
        //}

        private string deliveryStatus;
        public string DeliveryStatus
        {
            get { return deliveryStatus; }
            set { deliveryStatus = value; }
        }

        private string deliveryStatusDesc;
        public string DeliveryStatusDesc
        {
            get { return deliveryStatusDesc; }
            set { deliveryStatusDesc = value; }
        }

        private string matCode;
        public string MatCode
        {
            get { return matCode; }
            set { matCode = value; }
        }

        private string matDesc;
        public string MatDesc
        {
            get { return matDesc; }
            set { matDesc = value; }
        }

        private string reqQty;
        public string ReqQty
        {
            get { return reqQty; }
            set { reqQty = value; }
        }
    }
}
