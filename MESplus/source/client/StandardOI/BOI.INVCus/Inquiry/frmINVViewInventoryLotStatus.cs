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
using SOI.DNM;
using Miracom.POPCore;
using BOI.OIFrx.Popup;
using BOI.OIFrx;

namespace BOI.INVCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmINVViewInventoryLotStatus : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private Rs232 m_CommPort = new Rs232();
        private enum INV_LOT_COL
        {
            HIST_SEQ = 0,
            TRAN_TIME,
            TRAN_CODE,
            INV_ACCT,
            MAT_ID,
            MAT_DESC,
            OPER_DESC,
            QTY_1,
            UNIT_1,
            FROM_TO_FLAG,
            FROM_TO_LOT_ID,
            INV_CMF_1,
            INV_CMF_2,
            INV_CMF_3,
            INV_CMF_4,
            INV_CMF_5,
            INV_CMF_6,
            INV_CMF_7,
            INV_CMF_8
        }

        #endregion

        #region Constructor

        public frmINVViewInventoryLotStatus()
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

                // (Required) 
                bIsShown = true;
            }
        }
        private bool View_Lot(string sLotID)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            try
            {
                txtMatID.Text = "";
                txtFlow.Text = "";
                txtLotType.Text = "";
                txtOper.Text = "";
                txtQty.Text = "";
                txtUnit.Text = "";
                txtValidDate.Text = "";
                txtCreateDate.Text = "";
                txtMatDesc.Text = "";
                txtOrderID.Text = "";
                txtLine.Text = "";
                txtReqNo.Text = "";
                txtVendor.Text = "";
                chkLotDelFlag.Checked = false;
                chkRequestFlag.Checked = false;
                chkBulk.Checked = false;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));

                if (MPCF.CallService("BINV", "BINV_View_Lot", in_node, ref out_node) == false)
                {
                    txtInvLotID.Focus();
                    txtInvLotID.SelectAll();
                    return false;
                }
                if (out_node.GetChar("LOT_TYPE") == 'I')
                {
                    txtLotType.Text = "자재";
                }
                else
                {
                    txtLotType.Text = "재공품";
                }
                if (MPCF.Trim(out_node.GetString("LOT_CMF_5")) != "")
                {
                    txtCreateDate.Text = MPCF.ToDate((out_node.GetString("LOT_CMF_5"))).ToString("yyyy-MM-dd");
                }
                if (MPCF.Trim(out_node.GetString("LOT_CMF_6")) != "")
                {
                    txtValidDate.Text = MPCF.ToDate((out_node.GetString("LOT_CMF_6"))).ToString("yyyy-MM-dd");
                }
                txtOper.Text = MPCF.Trim(out_node.GetString("OPER_DESC"));
                txtUnit.Text = MPCF.Trim(out_node.GetString("MAT_UNIT"));
                txtMatID.Text = MPCF.Trim(out_node.GetString("MAT_ID"));
                txtMatDesc.Text = MPCF.Trim(out_node.GetString("MAT_DESC"));
                txtQty.Text = out_node.GetDouble("QTY_1").ToString();
                txtFlow.Text = MPCF.Trim(out_node.GetString("FLOW_DESC"));
                txtReqNo.Text = MPCF.Trim(out_node.GetString("LOT_CMF_9"));
                txtReqSeq.Text = MPCF.Trim(out_node.GetString("LOT_CMF_10"));
                txtLine.Text = MPCF.Trim(out_node.GetString("LINE_DESC"));
                txtOrderID.Text = MPCF.Trim(out_node.GetString("ORDER_ID"));

                if (MPCF.Trim(out_node.GetString("LOT_CMF_11")) == "Y")
                {
                    chkRequestFlag.Checked = true;
                }
                else
                {
                    chkRequestFlag.Checked = false;
                }

                if (out_node.GetChar("LOT_DEL_FLAG") == 'Y')
                {
                    chkLotDelFlag.Checked = true;
                }
                else
                {
                    chkLotDelFlag.Checked = false;
                }

                if (MPCF.Trim(out_node.GetString("LOT_CMF_14")) == "Y")
                {

                    chkBulk.Checked = true;
                }
                else
                {
                    chkBulk.Checked = false;
                }

                txtVendor.Text = MPCF.Trim(out_node.GetString("VENDOR_DESC"));


                txtInvLotID.Focus();
                txtInvLotID.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("VIEW_LOT") == true)
                {
                    if(View_Lot(MPCF.Trim(txtInvLotID.Text)) == false)
                    {
                        txtInvLotID.Focus();
                        txtInvLotID.SelectAll();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        private void txtInvLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //string tempLotId;
            //int indexValue;

            try
            {
                if (e.KeyChar == (char)13)
                {
                    //tempLotId = txtInvLotID.Text.Trim();
                    //indexValue = tempLotId.IndexOf(":");

                    //txtInvLotID.Text = tempLotId.Substring(0, indexValue);
                    //txtUnitQty.Value = MPCF.ToDbl(tempLotId.Substring(indexValue + 1));

                    btnView.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        private bool Tran_Print_Label()
        {
            string[] PrintDataArray;
            string sPrintString = "";

            TRSNode in_node = new TRSNode("POP_TRAN_PRINT_LABEL_IN");
            TRSNode out_node = new TRSNode("POP_TRAN_PRINT_LABEL_OUT");
            TRSNode print_node;
            TRSNode design_node;
            try
            {

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(txtInvLotID.Text));
                in_node.AddString("SCREEN_ID", BIGC.B_LABEL_LB005);
                in_node.AddChar("PRINT_HIS_FLAG", 'Y');

                if (MPCF.CallService("BWIP", "BWIP_Tran_Print_Label", in_node, ref out_node) == false)
                {
                    return false;
                }

                /* 라벨 출력 항목들을 print_node에 초기화한다. */
                print_node = out_node.GetList("PRINT_LABEL_OUT")[0];
                design_node = out_node.GetList("LABEL_DESIGN_OUT")[0];
                string printer = MPCF.GetRegSetting(Application.ProductName, "Settings", "SAVE_PRINT_NAME");
                //spool
                if (MPCF.Trim(printer) == "" || printer == null)
                {
                    System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();

                    modPOPPrint.sPrinterName = pd.PrinterSettings.PrinterName;
                    printer = pd.PrinterSettings.PrinterName;
                    MPCF.SaveRegSetting(Application.ProductName, "Settings", "SAVE_PRINT_NAME", pd.PrinterSettings.PrinterName);
                }
                else
                {
                    modPOPPrint.sPrinterName = printer;
                }

                if (modPOPPrint.MakeZebraCommand(BIGC.B_PORT_SPOOL, m_CommPort, ref design_node, out PrintDataArray, true) == false)
                {
                    return false;
                }

                if (BICF.Fill_PrintDatas(ref print_node, PrintDataArray,out sPrintString) == false)
                {
                    return false;
                }

                if (modPOPPrint.Send_Data(BIGC.B_PORT_SPOOL, m_CommPort, sPrintString) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "VIEW_LOT":
                        //INV LOT ID
                        if (MPCF.Trim(txtInvLotID.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            txtInvLotID.Focus();
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


        #endregion


        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (Tran_Print_Label() == false)
            {
                return;
            }
        }


    }
}
