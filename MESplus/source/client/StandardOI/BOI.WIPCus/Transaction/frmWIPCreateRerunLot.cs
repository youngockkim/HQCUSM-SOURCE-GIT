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
using BOI.OIFrx.BOIBaseForm;
using BOI.OIFrx;

namespace BOI.WIPCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmWIPCreateRerunLot : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private string _orderId = string.Empty;

        private readonly string RERUN_CODE = "CPBL005";
        private readonly string RERUN_DESC = "[반제품] 리런";

        public string OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        private enum LOSS_COL
        {
            LOSS_CODE,
            LOSS_DESC,
            LOSS_QTY
        }

        #endregion

        #region Constructor

        public frmWIPCreateRerunLot()
        {
            InitializeComponent();
        }

        public frmWIPCreateRerunLot(string args)
        {
            InitializeComponent();
            if (args != "")
            {
                _orderId = args;
            }
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempBOIBaseForm02_Load(object sender, EventArgs e)
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
        private void frmTempBOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                                

                cdvRerunCode.Tag = RERUN_CODE;
                cdvRerunCode.Text = RERUN_DESC;

                if (_orderId != "")
                {
                    boiOrderInfo.View_Order_Info(_orderId);
                }

                cdvWorkUser.Text = MPGV.gsUserID;
                txtColSetID.Text = "";
                txtColSetID.Tag = "";

                // (Required) 
                bIsShown = true;
            }
        }

        private void cdvRerunCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            //try
            //{
            //    MenuInfoTag selectedMenuInfo;

            //    BOI.WIPCus.Popup.frmWIPSelectLossCode frm = new BOI.WIPCus.Popup.frmWIPSelectLossCode(txtColSetID.Tag.ToString() + ":" + txtColSetID.Text);

            //    selectedMenuInfo = new MenuInfoTag();
            //    selectedMenuInfo.s_func_desc = "Loss";
            //    frm.Tag = selectedMenuInfo;
            //    frm.StartPosition = FormStartPosition.CenterParent;
            //    frm.Oper = boiOrderInfo.Oper;
            //    frm.ShowDialog();

            //    cdvLossCode.Text = frm.lossDesc;
            //    cdvLossCode.Tag = frm.lossCode;
            //    txtColSetID.Text = frm.colSetDesc;
            //    txtColSetID.Tag = frm.colSetId;
            //}
            //catch (Exception ex)
            //{
            //    MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            //}

          
        }
      

        #endregion

        #region Function
        

        #endregion

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("CREATE_RERUN_LOT") == true)
                {
                    if (Create_Rerun_Lot('1') == true)
                    {
                        boiOrderInfo.View_Order_Info(_orderId);                        
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "CREATE_RERUN_LOT":                       

                        //Order ID
                        if (MPCF.Trim(boiOrderInfo.OrderId) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(422), MSG_LEVEL.WARNING, true);
                            boiOrderInfo.Focus();
                            return false;
                        }

                        //Start Res ID
                        if (MPCF.Trim(boiOrderInfo.ResId) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            return false;
                        }


                        if (MPCF.ToDbl(txtRerunQty.Value) <= 0)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(455), MSG_LEVEL.WARNING, true);
                            return false;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        // Loss_Lot()
        //       - Loss Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Create_Rerun_Lot(char ProcStep)
        {
            TRSNode in_node = new TRSNode("CREATE_RERUN_LOT_IN");
            TRSNode out_node = new TRSNode("CREATE_RERUN_LOT_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("ORDER_ID", boiOrderInfo.OrderId);
                in_node.AddString("P_MAT_ID", boiOrderInfo.MatId);
                in_node.AddChar("P_MAT_BOM_TYPE", boiOrderInfo.BomMatType);
                in_node.AddString("RES_ID", boiOrderInfo.ResId);
                in_node.AddDouble("RERUN_QTY", MPCF.ToDbl(txtRerunQty.Value));                

                in_node.AddString("LOSS_CODE_TYPE", BIGC.B_LOSS_CODE_TYPE_P);
                in_node.AddString("LOSS_CODE", RERUN_CODE);
                in_node.AddString("LOSS_CODE_DESC", RERUN_DESC);

                if (MPCF.CallService("BWIP", "BWIP_Create_Rerun_Lot", in_node, ref out_node) == false)
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
        
    }
}
