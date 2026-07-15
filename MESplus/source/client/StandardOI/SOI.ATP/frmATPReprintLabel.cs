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
    // SOIBaseForm03 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel, Print Option
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmATPReprintLabel : SOIBaseForm03
    {
        #region Property

        // (Required)
        private bool bIsShown = false;

        public ATPReprintLabelModel model = new ATPReprintLabelModel();

        private enum COL_INV_LOT_LIST
        {
            INV_LOT_ID = 1,
            QTY
        }

        #endregion

        #region Constructor

        public frmATPReprintLabel()
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
        private void frmTempSOIBaseForm03_Load(object sender, EventArgs e)
        {
            // TEST DATA
            txtWorkOrderID.Text = model.WorkOrderID;
            txtPackQty.Text = model.PackQty;
            txtShop.Text = model.Shop;
            txtLineCode.Text = model.LineID;
            txtLineDesc.Text = model.LineDesc;
            txtMatCode.Text = model.MatID;
            txtMatDesc.Text = model.MatDesc;
            lblOrderQty.Text = model.OrderQty;
            lblRemainQty.Text = model.RemainQty;
            lblOutQty.Text = model.OutQty;
            lblLossQty.Text = model.LossQty;

            ViewEntryResult();

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
        private void frmTempSOIBaseForm03_Shown(object sender, EventArgs e)
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
        /// View Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewEntryResult() == false)
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
        /// Print Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (PrintLabel() == false)
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
        /// View Entry Result
        /// </summary>
        /// <returns></returns>
        private bool ViewEntryResult()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_ENTRY_RESULT_IN");
                TRSNode out_node = new TRSNode("VIEW_ENTRY_RESULT_OUT");

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", txtWorkOrderID.Text);
                in_node.AddChar("OPERATION_TYPE", 'I');

                if (MPCF.CallService("ATP", "ATP_View_Wip_Lot_Entry_Result_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetList(0) == null
                    || out_node.GetList(0).Count < 1)
                {
                    return true;
                }
                else
                {
                    // Clear
                    spdLotList.Sheets[0].Rows.Clear();
                    int iRow = 0;

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        // Add To Inventory Lot List                
                        iRow = spdLotList.Sheets[0].Rows.Count;
                        spdLotList.Sheets[0].RowCount++;
                        spdLotList.Sheets[0].Cells[iRow, 0].Value = false;
                        spdLotList.Sheets[0].Cells[iRow, (int)COL_INV_LOT_LIST.INV_LOT_ID].Value = out_node.GetList(0)[i].GetString("INV_LOT_ID");
                        spdLotList.Sheets[0].Cells[iRow, (int)COL_INV_LOT_LIST.QTY].Value = MPCF.MakeNumberFormat(out_node.GetList(0)[i].GetDouble("GOOD_QTY"));
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

        /// <summary>
        /// Process Print Label
        /// </summary>
        /// <returns></returns>
        private bool PrintLabel()
        {
            try
            {
                if (spdLotList.Sheets[0].Rows.Count < 1)
                {
                    return false;
                }

                for (int i = 0; i < spdLotList.Sheets[0].Rows.Count; i++)
                {
                    if ((bool)spdLotList.Sheets[0].Cells[i, 0].Value == true)
                    {
                        // Mapping Data
                        TRSNode mappingNode = new TRSNode("MAPPING_NODE");
                        mappingNode.AddString("LABEL_ID", spdLotList.Sheets[0].Cells[i, (int)COL_INV_LOT_LIST.INV_LOT_ID].Value.ToString());

                        // Print Label
                        MPCF.PrintLabelByLabelID(this, base.printOption, "ATP_MES_OPTIONS", "INV_PRINT_LABEL_ID", mappingNode);
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

    public class ATPReprintLabelModel
    {
        private string workOrderID;
        public string WorkOrderID
        {
            get { return workOrderID; }
            set { workOrderID = value; }
        }

        private string packQty;
        public string PackQty
        {
            get { return packQty; }
            set { packQty = value; }
        }

        private string shop;
        public string Shop
        {
            get { return shop; }
            set { shop = value; }
        }

        private string lineID;
        public string LineID
        {
            get { return lineID; }
            set { lineID = value; }
        }

        private string lineDesc;
        public string LineDesc
        {
            get { return lineDesc; }
            set { lineDesc = value; }
        }

        private string matID;
        public string MatID
        {
            get { return matID; }
            set { matID = value; }
        }

        private string matDesc;
        public string MatDesc
        {
            get { return matDesc; }
            set { matDesc = value; }
        }

        private string orderQty;
        public string OrderQty
        {
            get { return orderQty; }
            set { orderQty = value; }
        }

        private string remainQty;
        public string RemainQty
        {
            get { return remainQty; }
            set { remainQty = value; }
        }

        private string outQty;
        public string OutQty
        {
            get { return outQty; }
            set { outQty = value; }
        }

        private string lossQty;
        public string LossQty
        {
            get { return lossQty; }
            set { lossQty = value; }
        }
    }
}
