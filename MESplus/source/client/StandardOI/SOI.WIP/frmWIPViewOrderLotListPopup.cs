using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using System.Collections;

namespace SOI.WIP
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmWIPViewOrderLotListPopup : frmPopupBase
    {
        #region Property

        public string _orderID = string.Empty;

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

        #endregion

        #region Constructor

        public frmWIPViewOrderLotListPopup()
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
        private void frmWIPViewOrderLotListPopup_Load(object sender, EventArgs e)
        {
            // Grid Init
            gridOrderLotList.InitDataSource();

            // Caption 변경
            MPCF.ConvertCaption(this);

            // View Data
            ViewLotListByOrder(_orderID);

            // 활성화
            this.Activate();
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

        #region Functions

        /// <summary>
        /// View Order
        /// </summary>
        /// <param name="sOrderId"></param>
        /// <returns></returns>
        private bool ViewOrder(string sOrderId)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_ORDER_IN");
                TRSNode out_node = new TRSNode("VIEW_ORDER_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", sOrderId);

                if (MPCF.CallService("ORD", "ORD_View_Order", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtOrderID.Text = out_node.GetString("ORDER_ID");
                txtOrderDesc.Text = out_node.GetString("ORDER_DESC");

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// View Lot List By Order
        /// </summary>
        /// <param name="sOrderId"></param>
        /// <returns></returns>
        public bool ViewLotListByOrder(string sOrderId)
        {
            try
            {
                if (ViewOrder(sOrderId) == false)
                {
                    return false;
                }

                TRSNode in_node = new TRSNode("VIEW_LOT_LIST_BY_ORDER_IN");
                TRSNode out_node = new TRSNode("VIEW_LOT_LIST_BY_ORDER_OUT");
                ArrayList lislist = new ArrayList();

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", sOrderId);

                do
                {
                    if (MPCF.CallService("ORD", "ORD_View_Lot_List_By_Order", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    lislist.Add(out_node);

                    in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
                } while (in_node.GetString("NEXT_LOT_ID") != "");

                foreach (object obj in lislist)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        DataTable dt = this.gridOrderLotList.GetDataSource();

                        // 2) New Row
                        DataRow dr = dt.NewRow();

                        // 3) Data Insert
                        //dr["SEQ"] = (i + 1).ToString();
                        dr["IN_TIME"] = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME"));
                        dr["LOT_ID"] = out_node.GetList(0)[i].GetString("LOT_ID");
                        dr["MAT_ID"] = out_node.GetList(0)[i].GetString("MAT_ID");
                        dr["FLOW"] = out_node.GetList(0)[i].GetString("FLOW");
                        dr["OPER"] = out_node.GetList(0)[i].GetString("OPER");
                        dr["QTY_1"] = out_node.GetList(0)[i].GetDouble("QTY_1");
                        dr["LOT_STATUS"] = out_node.GetList(0)[i].GetString("LOT_STATUS");
                        dr["ORDER_ID"] = out_node.GetList(0)[i].GetString("ORDER_ID");
                        dr["HOLD_FLAG"] = out_node.GetList(0)[i].GetChar("HOLD_FLAG");
                        dr["HOLD_CODE"] = out_node.GetList(0)[i].GetString("HOLD_CODE");
                        dr["START_FLAG"] = out_node.GetList(0)[i].GetChar("START_FLAG");
                        dr["START_TIME"] = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("START_TIME"));
                        dr["START_RES_ID"] = out_node.GetList(0)[i].GetString("START_RES_ID");
                        dr["END_FLAG"] = out_node.GetList(0)[i].GetChar("END_FLAG");
                        dr["END_TIME"] = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("END_TIME"));
                        dr["END_RES_ID"] = out_node.GetList(0)[i].GetString("END_RES_ID");

                        dr["OPER_IN_TIME"] = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("OPER_IN_TIME"));

                        // 4) New Row Add
                        dt.Rows.Add(dr);
                    }
                }

                // 5) Bind
                gridOrderLotList.DataBind();

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
