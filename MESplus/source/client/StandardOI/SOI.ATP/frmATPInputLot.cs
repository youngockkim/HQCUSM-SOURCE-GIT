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
using System.IO;

namespace SOI.ATP
{
    // (Required) Inherit Base Form
    // SOIBaseForm03 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel, Print Option
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmATPInputLot : SOIBaseForm03
    {
        #region Property

        // (Required)
        private bool bIsShown = false;
        private string sLotIDGenRuldID = string.Empty;

        private TRSNode _orderNode = new TRSNode("ORDER_INFO");

        public ATPInputLotModel model = new ATPInputLotModel();

        #endregion

        #region Constructor

        public frmATPInputLot()
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
            // Init Value
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

            // Get Runsheet
            if (ViewOrder(txtWorkOrderID.Text) == false)
            {
                return;
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
        /// Operation CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvInOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Field Clear
                MPCF.FieldClear(txtLotID);
                txtLotID.ReadOnly = false;
                btnGen.Enabled = false;

                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                //in_node.AddString("FLOW", model.Flow);

                // Display and Header Text Setup
                string[] display = new string[] { "OPER", "OPER_DESC" };
                string[] header = new string[] { "Oper", "Oper Desc" };

                // Show CodeView and Get Return
                cdvInOper.Text = cdvInOper.Show(cdvInOper, "View Operation List", "WIP", "WIP_View_Operation_List", in_node, "LIST", display, header, "Oper");

                // Set Generation Rule
                if (cdvInOper == null || cdvInOper.Text == string.Empty)
                {
                    return;
                }                

                if (GetLotIdGenerationRule(cdvInOper.Text) == false)
                {
                    txtLotID.ReadOnly = false;
                    btnGen.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false); 
            }
        }

        /// <summary>
        /// Generation ID Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGen_Click(object sender, EventArgs e)
        {
            try
            {
                // CheckValue
                if (MPCF.CheckValue(cdvInOper, false) == false)
                {
                    return;
                }

                // Generate Lot ID
                if (GenLotID() == false)
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
        /// Process Create Lot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (MPCF.CheckValue(cdvInOper, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(txtInQty, false) == false)
                {
                    return;
                }
                if (MPCF.ToDbl(txtInQty.Value) == 0)
                {
                    MPCF.SetFocus(txtInQty);
                    return;
                }
                if (txtLotID.ReadOnly == false)
                {
                    if (MPCF.CheckValue(txtLotID, false) == false)
                    {
                        return;
                    }
                }
                
                // Input Lot
                if (InputLot() == false)
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
        /// View Order
        /// </summary>
        /// <param name="sOrderId"></param>
        /// <returns></returns>
        private bool ViewOrder(string sOrderId)
        {
            try
            {
                _orderNode.Init();

                TRSNode in_node = new TRSNode("VIEW_ORDER_IN");
                TRSNode out_node = new TRSNode("VIEW_ORDER_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", sOrderId);

                if (MPCF.CallService("ORD", "ORD_View_Order", in_node, ref _orderNode) == false)
                {
                    return false;
                }

                txtRunsheet.Text = _orderNode.GetString("ORD_CMF_2");

                lblOrderQty.Text = MPCF.MakeNumberFormat(_orderNode.GetDouble("ORD_QTY"));
                lblRemainQty.Text = MPCF.MakeNumberFormat(_orderNode.GetDouble("ORD_QTY") - _orderNode.GetDouble("ORD_IN_QTY"));
                lblOutQty.Text = MPCF.MakeNumberFormat(_orderNode.GetDouble("ORD_IN_QTY"));
                lblLossQty.Text = MPCF.MakeNumberFormat(_orderNode.GetDouble("ORD_LOSS_QTY"));

                txtInQty.Value = _orderNode.GetDouble("QTY");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Lot ID 발번
        /// </summary>
        /// <returns></returns>
        private bool GenLotID()
        {
            TRSNode in_node = new TRSNode("GENERATE_IN");
            TRSNode out_node = new TRSNode("GENERATE_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("MAT_ID", _orderNode.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", _orderNode.GetInt("MAT_VER"));
                in_node.AddString("RULE_ID", sLotIDGenRuldID);

                if (MPCF.CallService("WIP", "WIP_Generate_ID", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtLotID.Text = out_node.GetString("GEN_ID");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Lot ID 발번 규칙
        /// </summary>
        /// <param name="sOper"></param>
        /// <returns></returns>
        private bool GetLotIdGenerationRule(string sOper)
        {
            TRSNode in_node = new TRSNode("RULE_LIST_IN");
            TRSNode out_node = new TRSNode("RULE_LIST_OUT");
            string sRuleId = "";

            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddChar("REL_LEVEL", '3');
            in_node.AddString("OPER", sOper);
            in_node.AddString("NEXT_TRAN_CODE", "CREATE");

            if (MPCF.CallService("WIP", "WIP_View_Rule_Relation_List", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetList("LIST").Count > 0)
            {
                sRuleId = out_node.GetList("LIST")[0].GetString("RULE_ID");
            }

            sLotIDGenRuldID = sRuleId;

            if (sRuleId == "")
            {
                txtLotID.ReadOnly = false;
                btnGen.Enabled = false;
            }
            else
            {
                txtLotID.ReadOnly = true;
                btnGen.Enabled = true;
            }

            return true;
        }

        /// <summary>
        /// Process Input Lot
        /// </summary>
        /// <returns></returns>
        private bool InputLot()
        {
            try
            {
                TRSNode in_node = new TRSNode("INPUT_LOT_IN");
                TRSNode out_node = new TRSNode("INPUT_LOT_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", txtLotID.Text);                
                in_node.AddString("MAT_ID", txtMatCode.Text);
                in_node.AddInt("MAT_VER", 1);
                in_node.AddInt("FLOW_SEQ_NUM", 1);
                in_node.AddString("FLOW", _orderNode.GetString("FLOW"));
                in_node.AddString("OPER", cdvInOper.Text);
                in_node.AddDouble("QTY_1", MPCF.ToDbl(txtInQty.Value));
                in_node.AddChar("LOT_TYPE", _orderNode.GetChar("LOT_TYPE"));
                in_node.AddString("CREATE_CODE", _orderNode.GetString("CREATE_CODE"));
                in_node.AddString("OWNER_CODE", _orderNode.GetString("OWNER_CODE"));
                in_node.AddChar("LOT_PRIORITY", _orderNode.GetChar("LOT_PRIORITY"));
                in_node.AddString("DUE_TIME", _orderNode.GetString("ORG_DUE_TIME"));                
                in_node.AddChar("IN_CASE", '1');                
                in_node.AddString("ORDER_ID", txtWorkOrderID.Text);

                if (MPCF.CallService("ATP", "Atp_Inputlot_Wip_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Print Label
                if (chkPrintLabel.Checked == true)
                {
                    // Mapping Data
                    TRSNode mappingNode = new TRSNode("MAPPING_NODE");
                    mappingNode.AddString("LOT_ID", txtLotID.Text);

                    if (MPCF.PrintLabelByLabelID(this, base.printOption, "ATP_MES_OPTIONS", "WIP_PRINT_LOT_LABEL_ID", mappingNode) == false)
                    {
                        return false;
                    }
                }

                // Print Runsheet
                if (string.IsNullOrEmpty(txtRunsheet.Text) == false)
                {
                    if (MPCF.PrintRunsheet(this, base.printOption, txtLotID.Text, txtMatCode.Text, _orderNode) == false)
                    {
                        return false;
                    }
                }

                // View Order
                if (ViewOrder(txtWorkOrderID.Text) == false)
                {
                    return false;
                }
                
                // Success Message
                MPCF.ShowSuccessMessage(out_node, false);

                // Field Clear
                MPCF.FieldClear(txtLotID);
                MPCF.SetFocus(txtLotID);

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

    public class ATPInputLotModel
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

        private int matVer;
        public int MatVer
        {
            get { return matVer; }
            set { matVer = value; }
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

        private string flow;
        public string Flow
        {
            get { return flow; }
            set { flow = value; }
        }
    }
}
