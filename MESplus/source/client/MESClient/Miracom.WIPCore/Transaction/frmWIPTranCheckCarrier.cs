using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPTranCheckCarrier : Form
    {
        public frmWIPTranCheckCarrier()
        {
            InitializeComponent();
        }


        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;

        #endregion

        #region " Function Definition "

        // ViewLotInfo()
        //       -   View Lot Information
        // Return Value
        //       -
        // Arguments
        //       -
        protected bool ViewLotInfo(string s_lot_id)
        {
            TRSNode in_node = new TRSNode("View_Lot_In");
            TRSNode out_node = new TRSNode("View_Lot_Out");

            MPCR.SetInMsg(in_node);

            in_node.ProcStep = '3';
            in_node.AddString("LOT_ID", MPCF.Trim(s_lot_id));

            if (MPCR.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
            {
                return false;
            }

            txtMaterial.Text = out_node.GetString("MAT_ID");
            txtFlow.Text = out_node.GetString("FLOW");
            txtOper.Text = out_node.GetString("OPER");

            txtQty1.Text = out_node.GetDouble("QTY_1").ToString("########,##0.###");
            txtQty2.Text = out_node.GetDouble("QTY_2").ToString("########,##0.###");
            txtQty3.Text = out_node.GetDouble("QTY_3").ToString("########,##0.###");

#if _CRR
            ViewLotCarrierList(out_node.GetString("LOT_ID"));
#endif
            return true;
        }

        private bool ViewLotCarrierList(string s_lot_id)
        {
#if _CRR
            int i;
            int i_row;

            TRSNode in_node = new TRSNode("VIEW_CARRIER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_CARRIER_LIST_OUT");

            MPCF.ClearList(spdCarrier);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", s_lot_id);

            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Carrier_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    i_row = spdCarrier.ActiveSheet.RowCount;
                    spdCarrier.ActiveSheet.RowCount++;

                    spdCarrier.ActiveSheet.Cells[i_row, 0].Value = out_node.GetList(0)[i].GetString("CRR_ID");
                    spdCarrier.ActiveSheet.Cells[i_row, 2].Value = out_node.GetList(0)[i].GetDouble("QTY_1");
                }

                in_node.SetString("NEXT_CRR_ID", out_node.GetString("NEXT_CRR_ID"));

            } while (in_node.GetString("NEXT_CRR_ID") != "");

            return true;
#endif
        }

        #endregion

        private void frmWIPTranCheckCarrier_Load(object sender, EventArgs e)
        {
            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
            }
        }

        private void frmWIPTranCheckCarrier_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                {
                    txtLotID.Text = MPGV.gsCurrentLot_ID;
                    ViewLotInfo(txtLotID.Text);
                    txtCrrID.Focus();
                }

                b_load_flag = true;
            }
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && MPCF.Trim(txtLotID.Text) != "")
            {
                ViewLotInfo(MPCF.Trim(txtLotID.Text));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int i;

            for (i = 0; i < spdCarrier.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdCarrier.ActiveSheet.Cells[i, 1].Value) != "V")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(331));
                    txtCrrID.Focus();
                    return;
                }
            }

            btnClose.PerformClick();
        }

        private void txtCrrID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && MPCF.Trim(txtCrrID.Text) != "")
            {
                if (spdCarrier.ActiveSheet.RowCount < 1) return;

                string s_crr_id;
                int i;

                for (i = 0; i < spdCarrier.ActiveSheet.RowCount; i++)
                {
                    s_crr_id = MPCF.Trim(spdCarrier.ActiveSheet.Cells[i, 0].Value);
                    if (s_crr_id == MPCF.Trim(txtCrrID.Text))
                    {
                        spdCarrier.ActiveSheet.Cells[i, 1].Value = "V";
                        break;
                    }
                }

                if (i >= spdCarrier.ActiveSheet.RowCount)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(255));
                }

                txtCrrID.Text = "";
                txtCrrID.Focus();
            }
        }


    }
}
