using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmCORDViewWorkOrderPopup : frmPopupBase
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

        #endregion

        #region Constructor

        public frmCORDViewWorkOrderPopup(string lineID)
        {
            InitializeComponent();

            gLineID = lineID;

        }

        #endregion


        #region [Constant Definition]

        public enum ORDER_LIST
        {
            ORDER_ID = 0,
            ORDER_DESC,
            MAT_ID,
            EFFICIENCY,
            GRADE,
            ORD_QTY,
            ORD_IN_QTY,
            ORD_OUT_QTY,
            ORD_LOSS_QTY
        }

        #endregion

        #region [Variable Definition]

        private string gLineID = string.Empty;

        public string outOrderID = string.Empty;
        public string outOrderDesc = string.Empty;
        public string outMatID = string.Empty;
        public string outEfficiency = string.Empty;
        public string outGrade = string.Empty;
        public double outOrderQty = 0;
        public double outInQty = 0;
        public double outOutQty = 0;
        public double outLossQty = 0;

        #endregion


        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// - Form Activate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCORDViewWorkOrderPopup_Load(object sender, EventArgs e)
        {
            // Caption 변경
            MPCF.ConvertCaption(this);

            // (Required) Grid Initialize

            MPCF.ClearList(spdOrder);

            if (ViewOrderList('5', gLineID) == false)
            {
                Close();
            }

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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (spdOrder.ActiveSheet.RowCount <= 0)
            {
                return;
            }

            if (string.IsNullOrEmpty(outOrderID))
            {
                return;
            }

            this.Close();
        }

        private void spdOrder_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (spdOrder.ActiveSheet.RowCount <= 0)
                {
                    return;
                }

                outOrderID = spdOrder.ActiveSheet.Cells[e.Row, (int)ORDER_LIST.ORDER_ID].Text;
                outOrderDesc = spdOrder.ActiveSheet.Cells[e.Row, (int)ORDER_LIST.ORDER_DESC].Text;
                outMatID = spdOrder.ActiveSheet.Cells[e.Row, (int)ORDER_LIST.MAT_ID].Text;
                outEfficiency = spdOrder.ActiveSheet.Cells[e.Row, (int)ORDER_LIST.EFFICIENCY].Text;
                outGrade = spdOrder.ActiveSheet.Cells[e.Row, (int)ORDER_LIST.GRADE].Text;

                outOrderQty = MPCF.ToDbl(spdOrder.ActiveSheet.Cells[e.Row, (int)ORDER_LIST.ORD_QTY].Value);
                outInQty = MPCF.ToDbl(spdOrder.ActiveSheet.Cells[e.Row, (int)ORDER_LIST.ORD_IN_QTY].Value);
                outOutQty = MPCF.ToDbl(spdOrder.ActiveSheet.Cells[e.Row, (int)ORDER_LIST.ORD_OUT_QTY].Value);
                outLossQty = MPCF.ToDbl(spdOrder.ActiveSheet.Cells[e.Row, (int)ORDER_LIST.ORD_LOSS_QTY].Value);

                if (string.IsNullOrEmpty(outOrderID))
                {
                    return;
                }

                txtOrderID.Text = outOrderID;

                //this.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void spdOrder_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (spdOrder.ActiveSheet.RowCount <= 0)
                {
                    return;
                }

                outOrderID = spdOrder.ActiveSheet.Cells[e.Row, (int)ORDER_LIST.ORDER_ID].Text;
                outOrderDesc = spdOrder.ActiveSheet.Cells[e.Row, (int)ORDER_LIST.ORDER_DESC].Text;
                outMatID = spdOrder.ActiveSheet.Cells[e.Row, (int)ORDER_LIST.MAT_ID].Text;
                outEfficiency = spdOrder.ActiveSheet.Cells[e.Row, (int)ORDER_LIST.EFFICIENCY].Text;
                outGrade = spdOrder.ActiveSheet.Cells[e.Row, (int)ORDER_LIST.GRADE].Text;

                outOrderQty = MPCF.ToDbl(spdOrder.ActiveSheet.Cells[e.Row, (int)ORDER_LIST.ORD_QTY].Value);
                outInQty = MPCF.ToDbl(spdOrder.ActiveSheet.Cells[e.Row, (int)ORDER_LIST.ORD_IN_QTY].Value);
                outOutQty = MPCF.ToDbl(spdOrder.ActiveSheet.Cells[e.Row, (int)ORDER_LIST.ORD_OUT_QTY].Value);
                outLossQty = MPCF.ToDbl(spdOrder.ActiveSheet.Cells[e.Row, (int)ORDER_LIST.ORD_LOSS_QTY].Value);

                if (string.IsNullOrEmpty(outOrderID))
                {
                    return;
                }

                txtOrderID.Text = outOrderID;

                this.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void txtOrderID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    MPCF.ClearList(spdOrder);

                    if (ViewOrderList('6', gLineID) == false)
                    {
                        Close();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        #endregion


        #region Functions

        private bool ViewOrderList(char ProcStep, string sLineID)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_ORDER_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_ORDER_LIST_OUT");
                TRSNode out_list;

                int i = 0;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep; // '5': Order List by Line ID including BOM, '6': Order List by Line ID and Order ID including BOM
                in_node.AddString("LINE_ID", MPCF.Trim(sLineID));

                if (ProcStep == '6')
                {
                    in_node.AddString("ORDER_ID", MPCF.Trim(txtOrderID.Text) == String.Empty ? "%" : (MPCF.Trim(txtOrderID.Text) + "%"));
                }

                in_node.AddString("MAT_ID", "");

                if (MPCF.CallService("CORD", "CORD_View_Order_List_By_Line", in_node, ref out_node) == false)
                {
                    return false;
                }

                //MPCF.ShowSuccessMessage(out_node, false);

                spdOrder.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];

                    spdOrder.ActiveSheet.RowCount++;

                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORDER_ID].Value = out_list.GetString("ORDER_ID");
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORDER_DESC].Value = out_list.GetString("ORDER_DESC");
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.MAT_ID].Value = out_list.GetString("MAT_ID");
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.EFFICIENCY].Value = out_list.GetString("EFFICIENCY");
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.GRADE].Value = out_list.GetString("GRADE");

                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORD_QTY].Value = out_list.GetDouble("ORD_QTY");
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORD_IN_QTY].Value = out_list.GetDouble("ORD_IN_QTY");
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORD_OUT_QTY].Value = out_list.GetDouble("ORD_OUT_QTY");
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORD_LOSS_QTY].Value = out_list.GetDouble("ORD_LOSS_QTY");
                }

                MPCF.FitColumnHeader(spdOrder);

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
