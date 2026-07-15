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

namespace BOI.INVCus.Popup
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmInvRawmilkConfirmPopup : frmPopupBase
    {
        #region Property

        /// <summary>
        /// (Required) Show form after drawing is finished.
        /// Form 내에 있는 모든 컨트롤들의 Rendering을 완료한 이후에 Form을 표시한다.
        /// Load Event 이후에 발생하므로 Focus 등의 이벤트들은 Activated 이벤트에 할당해야 한다.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000;
                return createParams;
            }
        }

        private string s_inv_req_no;

        public string S_inv_req_no
        {
            get { return s_inv_req_no; }
            set { s_inv_req_no = value; }
        }
        private int i_inv_req_seq;

        public int I_inv_req_seq
        {
            get { return i_inv_req_seq; }
            set { i_inv_req_seq = value; }
        }

        private double d_weight_put;

        public double D_weight_put
        {
            get { return d_weight_put; }
            set { d_weight_put = value; }
        }


        #endregion

        #region Constructor

        public frmInvRawmilkConfirmPopup()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// - Form Activate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempBOIPopup_Load(object sender, EventArgs e)
        {
            // Caption 변경
            MPCF.ConvertCaption(this);

            // 활성화
            this.Activate();

            loadInventoryMasterInfo();
        }

        /// <summary>
        /// (Required) Close Button Click
        /// - Form Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // 종료
            this.Close();
        }

        #endregion

        #region Function


        private bool TranRawmilkInOut(char cprocStep)
        {
            TRSNode in_node = new TRSNode("TRAN_RAWMILK_IN");
            TRSNode out_node = new TRSNode("TRAN_RAWMILK_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = cprocStep;

                in_node.AddString("INV_REQ_NO", s_inv_req_no);
                in_node.AddInt("INV_REQ_SEQ", i_inv_req_seq);
                in_node.AddString("USER_TEAM", MPGV.gsUserTeam);
                
                if (MPCF.CallService("BINV", "BINV_Tran_Rawmilk_In_Out", in_node, ref out_node) == false)
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
        private void loadInventoryMasterInfo()
        {
            try
            {


                TRSNode in_node = new TRSNode("View_Weight_Rawmilk_In");
                TRSNode out_node;


                double dReqQty1 = 0.0d; //총물류요청량
                double dReqQty2 = 0.0d; //총량중 집유대행량
                double dReqQty3 = 0.0d; //집유량
                double dWeightPut = 0.0d; // 설비 투입량
                double dResultQty1 = 0.0d; //총수유량(수유탱크 투입 확정수량)
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INV_REQ_NO", MPCF.Trim(s_inv_req_no));
                in_node.AddInt("INV_REQ_SEQ", MPCF.ToInt(i_inv_req_seq));
                out_node = new TRSNode("View_Weight_Rawmilk_Out");

                if (MPCF.CallService("BINV", "BINV_View_Weight_Rawmilk", in_node, ref out_node) == false)
                {
                    return;
                }

                dReqQty1 = out_node.GetList(0)[0].GetDouble("REQ_QTY_1");
                dReqQty2 = out_node.GetList(0)[0].GetDouble("REQ_QTY_2");
                dReqQty3 = out_node.GetList(0)[0].GetDouble("REQ_QTY_3");
                dResultQty1 = out_node.GetList(0)[0].GetDouble("RESULT_QTY_1");
                dWeightPut = out_node.GetList(0)[0].GetDouble("WEIGHT_PUT");
                D_weight_put = dReqQty1 - dWeightPut;
                numWeightQty.Value = dReqQty1;
                numRemainQty.Value = d_weight_put;
                numInputQty.Value = dWeightPut;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }
        private bool ViewReqDetailData() {
            try
            {
                //numWeightQty
                return true;
            }
            catch (Exception ex) {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        
        }
        #endregion

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.ToDbl(numWeightQty.Value) - MPCF.ToDbl(D_weight_put) == 0.0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(442), MSG_LEVEL.ERROR, false);
                    return;
                }

                if (MPCF.ToDbl(D_weight_put) > 0.0)
                {
                    if (MPCF.ShowMsgBox(MPCF.GetMessage(432), MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                }

           
                
                if (TranRawmilkInOut('1') == true)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
