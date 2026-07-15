using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.IO.Ports;

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
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button\

    public partial class frmCWIPEmptyFullCellCart : SOIBaseForm02
    {
        #region Property

        // (Required)
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCWIPEmptyFullCellCart()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        public enum LOT_LIST
        {
            LACK_ID,
            PACK_ID,
            CELL_BOX_ID,
            PACK_QTY
        }

        #endregion

        #region [Variable Definition]


        #endregion

        #region Event Handler

        private void frmCWIPEmptyFullCellCart_Load(object sender, EventArgs e)
        {
            MPCF.ConvertCaption(this);

        }

        private void frmCWIPEmptyFullCellCart_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                

                txtCartID.Focus();
                txtCartID.SelectAll();

                // (Required) 
                bIsShown = true;
            }
        }        

        private void txtCartID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    txtCartID.Text = MPCF.ToUpper(txtCartID.Text);

                    if (ViewPackLotList(txtCartID.Text) != false)
                    {

                    }

                    txtCartID.Focus();
                    txtCartID.SelectAll();
                    return;

                }


            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmptyCart() != false)
                {
                    MPCF.ClearList(spdLotList);
                }

                txtCartID.Focus();
                txtCartID.SelectAll();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        #endregion


        #region Function

        private bool EmptyCart()
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("LACK_ID", MPCF.Trim(txtCartID.Text));
                in_node.AddChar("PACK_TYPE", 'F'); // 'F': Full Cell Cart
                in_node.AddString("USER_ID", MPGV.gsUserID);

                if (MPCF.ShowMsgBox(MPCF.GetMessage(542), MessageBoxButtons.YesNo, MSG_LEVEL.WARNING) != System.Windows.Forms.DialogResult.Yes)
                {
                    return false;
                }

                if (MPCF.CallService("CWIP", "CWIP_Update_Cart", in_node, ref out_node) == false)
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

        private bool ViewPackLotList(string sCartID)
        {
            TRSNode in_node = new TRSNode("View_Pack_List_In");
            TRSNode out_node = new TRSNode("View_Pack_List_Out");
            TRSNode out_list;

            ArrayList lisPackList = new ArrayList();

            try
            {
                // Clear
                MPCF.ClearList(this.spdLotList);

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("LACK_ID", MPCF.Trim(sCartID));
                in_node.AddChar("PACK_TYPE", 'F');

                if (MPCF.CallService("CRPT", "CRPT_View_Manage_Fullcell_Cart_Label", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdLotList.ActiveSheet.RowCount = 0;

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];

                    spdLotList.ActiveSheet.RowCount++;
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.LACK_ID].Value = out_list.GetString("CARRIER_ID"); // Cart
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.PACK_ID].Value = out_list.GetString("MAGAZINE"); // Magazine
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.CELL_BOX_ID].Value = out_list.GetString("SMALLBOX_ID");
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.PACK_QTY].Value = out_list.GetInt("CNT");

                }

                txtLoadCount.Text = (out_node.GetList(0).Count).ToString();


                MPCF.FitColumnHeader(spdLotList);

                return true;

            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion





        

    }
}