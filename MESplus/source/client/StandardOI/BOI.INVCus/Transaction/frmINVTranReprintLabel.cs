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
    public partial class frmINVTranReprintLabel : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        private Rs232 m_CommPort = new Rs232();
        private string s_lot_id = "";
        private string s_screen_id = "";
        private string s_print_time = "";
        private enum LABEL_HIS
        {
            LOT_ID = 0,
            PRINT_TIME,
            LABEL_DESC,
            MAT_ID,
            MAT_DESC,
            LOT_QTY,
            PRINT_NUM
        }

        #endregion

        #region Constructor

        public frmINVTranReprintLabel()
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
            dtpFromDate.Value = DateTime.Now.AddDays(-1);
            dtpToDate.Value = DateTime.Now;
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
        
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("VIEW_LOT") == true)
                {
                    if (ViewLabelHis(MPCF.Trim(txtInvLotID.Text)) == false)
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

        //View Inventory Lot History
        private bool ViewLabelHis(string sLotID)
        {
            try
            {
                MPCF.ClearList(spdInvLot);

                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[6];
                DataTable dt = null;
                string s_column = "";

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "LOT_ID";
                dvcArgu[1].sCondition_Value = "%" + MPCF.Trim(txtInvLotID.Text) + "%";
                
                dvcArgu[2].sCondtion_ID = "FROM_DATE";
                dvcArgu[2].sCondition_Value = dtpFromDate.GetValueAsDateTime().ToString("yyyyMMdd");

                dvcArgu[3].sCondtion_ID = "TO_DATE";
                dvcArgu[3].sCondition_Value = dtpToDate.GetValueAsDateTime().ToString("yyyyMMdd");
                
                dvcArgu[4].sCondtion_ID = "SCREEN_ID";
                dvcArgu[4].sCondition_Value = MPCF.Trim(rbStatus.Items[rbStatus.CheckedIndex].DataValue.ToString());

                dvcArgu[5].sCondtion_ID = "MAT_ID";
                if (MPCF.Trim(cdvMatID.Text) == "")
                {
                    dvcArgu[5].sCondition_Value = "%";
                }
                else
                {
                    dvcArgu[5].sCondition_Value = MPCF.Trim(cdvMatID.Text);
                }

                if (TPDR.GetDataOne(s_column, ref dt, "OINV2219-001", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spdInvLot.Sheets[0].RowCount += 1;
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)LABEL_HIS.LOT_ID].Value = dt.Rows[i]["LOT_ID"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)LABEL_HIS.PRINT_TIME].Tag = MPCF.Trim(dt.Rows[i]["PRINT_TIME"].ToString());
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)LABEL_HIS.PRINT_TIME].Value = MPCF.MakeDateFormat(dt.Rows[i]["PRINT_TIME"].ToString());
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)LABEL_HIS.LABEL_DESC].Tag = dt.Rows[i]["SCREEN_ID"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)LABEL_HIS.LABEL_DESC].Value = dt.Rows[i]["LABEL_DESC"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)LABEL_HIS.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)LABEL_HIS.MAT_DESC].Value = dt.Rows[i]["MAT_DESC"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)LABEL_HIS.LOT_QTY].Value = dt.Rows[i]["QTY_1"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)LABEL_HIS.PRINT_NUM].Value = dt.Rows[i]["PRINT_NUM"].ToString();
                }

                MPCF.FitColumnHeader(spdInvLot);
                s_lot_id = MPCF.Trim(spdInvLot.ActiveSheet.Cells[0, (int)LABEL_HIS.LOT_ID].Text);
                s_screen_id = MPCF.Trim(spdInvLot.ActiveSheet.Cells[0, (int)LABEL_HIS.LABEL_DESC].Tag);
                s_print_time = MPCF.Trim(spdInvLot.ActiveSheet.Cells[0, (int)LABEL_HIS.PRINT_TIME].Tag);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

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
                in_node.AddString("LOT_ID", MPCF.Trim(s_lot_id));
                in_node.AddString("SCREEN_ID", MPCF.Trim(s_screen_id));
                in_node.AddString("PRINT_TIME", MPCF.Trim(s_print_time));
                if (MPCF.Trim(s_screen_id) == BIGC.B_LABEL_LB001)
                {
                    in_node.ProcStep = '6';
                }
                else if(MPCF.Trim(s_screen_id) == BIGC.B_LABEL_LB002)
                {
                    in_node.ProcStep = '7';
                }
                else if (MPCF.Trim(s_screen_id) == BIGC.B_LABEL_LB005)
                {
                    in_node.ProcStep = '9';
                }
                else if (MPCF.Trim(s_screen_id) == BIGC.B_LABEL_LB003)
                {
                    in_node.ProcStep = '8';
                }
                else if (MPCF.Trim(s_screen_id) == BIGC.B_LABEL_LB004)
                {
                    in_node.ProcStep = '4';
                }
                in_node.AddChar("PRINT_HIS_FLAG", 'N');

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
                        //if (MPCF.Trim(txtInvLotID.Text) == "")
                        //{
                        //    MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                        //    txtInvLotID.Focus();
                        //    return false;
                        //}

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


        private void cdvMatID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                MenuInfoTag selectedMenuInfo;

                BOI.INVCus.Popup.frmInvViewMatList frm = new BOI.INVCus.Popup.frmInvViewMatList(MPCF.Trim(cdvMatID.Text), BIGC.B_MAT_TYPE_GRP_P);

                selectedMenuInfo = new MenuInfoTag();
                selectedMenuInfo.s_func_desc = "View Mat List";
                frm.Tag = selectedMenuInfo;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                txtMatDesc.Text = frm.OUT_MAT_DESC;
                cdvMatID.Text = frm.OUT_MAT_ID;
                txtMatUnit.Text = frm.OUT_MAT_UNIT_1;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvMatID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    MenuInfoTag selectedMenuInfo;

                    BOI.INVCus.Popup.frmInvViewMatList frm = new BOI.INVCus.Popup.frmInvViewMatList(MPCF.Trim(cdvMatID.Text), BIGC.B_MAT_TYPE_GRP_P);

                    selectedMenuInfo = new MenuInfoTag();
                    selectedMenuInfo.s_func_desc = "View Mat List";
                    frm.Tag = selectedMenuInfo;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    if (MPCF.Trim(frm.OUT_MAT_ID) == "")
                    {
                        frm.ShowDialog();
                    }
                    txtMatDesc.Text = frm.OUT_MAT_DESC;
                    cdvMatID.Text = frm.OUT_MAT_ID;
                    txtMatUnit.Text = frm.OUT_MAT_UNIT_1;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdInvLot_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                s_lot_id = MPCF.Trim(spdInvLot.ActiveSheet.Cells[e.Row, (int)LABEL_HIS.LOT_ID].Text);
                s_screen_id = MPCF.Trim(spdInvLot.ActiveSheet.Cells[e.Row, (int)LABEL_HIS.LABEL_DESC].Tag);
                s_print_time = MPCF.Trim(spdInvLot.ActiveSheet.Cells[e.Row, (int)LABEL_HIS.PRINT_TIME].Tag);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }




    }
}
