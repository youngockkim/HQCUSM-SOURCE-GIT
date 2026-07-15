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

    public partial class frmCWIPCancelLoadingFullCellBox : SOIBaseForm02
    {
        #region Property

        // (Required)
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCWIPCancelLoadingFullCellBox()
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

        private void frmCWIPCancelLoadingFullCellBox_Load(object sender, EventArgs e)
        {
            txtCellBoxID.Focus();
            txtCellBoxID.SelectAll();

            MPCF.ConvertCaption(this);
        }

        private void frmCWIPCancelLoadingFullCellBox_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                

                txtCellBoxID.Focus();
                txtCellBoxID.SelectAll();

                // (Required) 
                bIsShown = true;
            }
        }

        private void txtCellBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                string sCellBoxID = string.Empty;

                if (txtCellBoxID.Text.Length <= 12)
                {
                    sCellBoxID = txtCellBoxID.Text;
                }
                else
                {
                    sCellBoxID = txtCellBoxID.Text.Substring(0, 12);
                }

                if (ViewCellBox(sCellBoxID) != false)
                {

                }

                txtCellBoxID.Focus();
                txtCellBoxID.SelectAll();
                return;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (CancelLoadingCellBox() != false)
                {
                    MPCF.ClearList(spdLotList);
                }

                txtCellBoxID.Focus();
                txtCellBoxID.SelectAll();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        #endregion


        #region Function

        private bool ViewCellBox(string sCellBoxID)
        {
            TRSNode in_node = new TRSNode("View_Pack_List_In");
            TRSNode out_node = new TRSNode("View_Pack_List_Out");

            ArrayList lisPackList = new ArrayList();

            try
            {
                // Clear
                MPCF.ClearList(this.spdLotList);

                // View Lot for Validation
                //ViewPackLot(sLotID);

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '4';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("CELL_BOX_ID", MPCF.Trim(sCellBoxID));
                in_node.AddChar("PACK_TYPE", 'F');

                if (MPCF.CallService("CRPT", "CRPT_View_Manage_Fullcell_Cart_Label", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdLotList.ActiveSheet.RowCount = 0;

                spdLotList.ActiveSheet.RowCount++;
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.LACK_ID].Value = out_node.GetString("CARRIER_ID"); // Cart
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.PACK_ID].Value = out_node.GetString("MAGAZINE"); // Magazine
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.CELL_BOX_ID].Value = out_node.GetString("SMALLBOX_ID");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.PACK_QTY].Value = out_node.GetInt("CNT");

                MPCF.FitColumnHeader(spdLotList);

                return true;

            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool CancelLoadingCellBox()
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';

                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("CELL_BOX_ID", MPCF.Trim(spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.CELL_BOX_ID].Text));
                in_node.AddChar("PACK_TYPE", 'F');

                if (MPCF.ShowMsgBox(MPCF.GetMessage(543), MessageBoxButtons.YesNo, MSG_LEVEL.WARNING) != System.Windows.Forms.DialogResult.Yes)
                {
                    return false;
                }

                if (MPCF.CallService("CWIP", "CWIP_Update_Cart", in_node, ref out_node) == false)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(556), MSG_LEVEL.ERROR, false);
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

        #endregion







        

    }
}