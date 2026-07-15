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
using System.Collections;
using BOI.OIFrx;
using SOI.DNM;
using Miracom.POPCore;

namespace BOI.INVCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmINVCreateInventoryLot : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private Rs232 m_CommPort = new Rs232();
        private MenuInfoTag menuInfo;
        public PrintOptionModel printOption;
        private frmPrintOptionPopup frmOption;

        #endregion

        #region Constructor

        public frmINVCreateInventoryLot()
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

            btnLabelPrint.Enabled = false;

            dtpDate.SetValueAsDateTime(DateTime.Now);
            dtpLife.SetValueAsDateTime(DateTime.Now.AddMonths(1));

            // Menu 정보 로드
            menuInfo = (MenuInfoTag)this.Tag;

            // Print Option 할당
            if (printOption == null)
            {
                printOption = new PrintOptionModel();
            }

            // Print Option 정보 호출
            MPCF.GetPrintOptionFromReg(ref this.printOption, this.menuInfo.s_func_name);
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

        private void cdvStoreID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "USER_ID";
                dvcArgu[1].sCondition_Value = MPGV.gsUserID;

                dvcArgu[2].sCondtion_ID = "FLOW";
                dvcArgu[2].sCondition_Value = "";

                dvcArgu[3].sCondtion_ID = "OPER_CMF_3";
                dvcArgu[3].sCondition_Value = "";

                // CodeView Column Header Setup
                string[] header = new string[] { "Oper", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "OPER", "OPER_SHORT_DESC" };

                // Show
                cdvStoreID.Text = cdvStoreID.Show(cdvStoreID, "Oper", "COM0000-007", dvcArgu, display, header, "OPER_SHORT_DESC", -1);

                if (MPCF.Trim(cdvStoreID.Text) != "")
                {
                    if (cdvStoreID.returnDatas != null && cdvStoreID.returnDatas.Count > 0)
                    {
                        cdvStoreID.Tag = cdvStoreID.returnDatas[0];
                    }
                    else
                    {
                        //cdvStoreID.Tag = "";
                    }
                }
                else
                {
                    cdvStoreID.Tag = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        //private void txtUnitQty_ValueChanged(object sender, EventArgs e)
        //{
        //    Double iShare;
        //    Double iRest;
        //    try
        //    {
        //        iShare = MPCF.ToDbl(txtTotalQty.Value) / MPCF.ToDbl(txtUnitQty.Value);
        //        iRest = MPCF.ToDbl(txtTotalQty.Value) % MPCF.ToDbl(txtUnitQty.Value);

        //        if (iRest > 0)
        //        {
        //            iShare += 1;
        //        }

        //        txtPrintQty.Value = Math.Truncate(iShare);
        //        txtPrintQty.Tag = iRest;
        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
        //    }
        //}

        private void btnPrintSetup_Click(object sender, EventArgs e)
        {
            try
            {
                // Print Option Popup 생성
                if (frmOption == null)
                {
                    frmOption = new frmPrintOptionPopup();
                }

                // Print Option Popup 초기화
                frmOption.Owner = this;
                frmOption.printOption = this.printOption;
                frmOption.funcName = this.menuInfo.s_func_name;

                // Show Dialog
                if (frmOption.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.printOption = frmOption.printOption;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("CREATE_LOT") == true)
                {
                    if (Create_Lot('1') == true)
                    {
                        btnLabelPrint.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        private void cdvInputType_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_DATA_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_INV_RSN_DETAIL));
                in_node.AddString("DATA_2", BIGC.B_INV_RSN_GRP_RG1);

                // CodeView Column Header Setup
                string[] header = new string[] { "Reason", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvCreateReason.Text = cdvCreateReason.Show(cdvCreateReason, "Reason", "BCOM", "BCOM_View_Gcm_Data_List", in_node, "GCM_DATA_LIST", display, header, "DATA_1");

                if (MPCF.Trim(cdvCreateReason.Text) != "")
                {
                    if (cdvCreateReason.returnDatas.Count > 0)
                    {
                        cdvCreateReason.Tag = cdvCreateReason.returnDatas[0];
                        cdvCreateReason.Text = cdvCreateReason.returnDatas[1];
                    }
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

                if (BICF.Fill_PrintDatas(ref print_node, PrintDataArray, out sPrintString) == false)
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
                    case "CREATE_LOT":
                        //Oper
                        if (MPCF.Trim(cdvStoreID.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvStoreID.Focus();
                            return false;
                        }
                        ////Material Type
                        //if (MPCF.Trim(cdvMatType.Text) == "")
                        //{
                        //    MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                        //    cdvMatType.Focus();
                        //    return false;
                        //}
                        ////Material Grp 1
                        //if (MPCF.Trim(cdvMatGrp1.Text) == "")
                        //{
                        //    MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                        //    cdvMatGrp1.Focus();
                        //    return false;
                        //}
                        ////Material Grp 2
                        //if (MPCF.Trim(cdvMatGrp2.Text) == "")
                        //{
                        //    MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                        //    cdvMatGrp2.Focus();
                        //    return false;
                        //}
                        //Material ID
                        if (MPCF.Trim(cdvMatID.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvMatID.Focus();
                            return false;
                        }
                        //Total Qty
                        if (MPCF.Trim(txtTotalQty.Value) == "0")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(114), MSG_LEVEL.WARNING, true);
                            txtTotalQty.Focus();
                            return false;
                        }
                        //Unit Qty
                        //if (MPCF.Trim(txtUnitQty.Value) == "0")
                        //{
                        //    MPCF.ShowMessage(MPCF.GetMessage(114), MSG_LEVEL.WARNING, true);
                        //    txtUnitQty.Focus();
                        //    return false;
                        //}
                        //else if (MPCF.ToInt(MPCF.Trim(txtUnitQty.Value)) > MPCF.ToInt(MPCF.Trim(txtTotalQty.Value)))
                        //{
                        //    MPCF.ShowMessage(MPCF.GetMessage(366), MSG_LEVEL.WARNING, true);
                        //    txtUnitQty.Focus();
                        //    return false;
                        //}
                        //Input Type
                        if (MPCF.Trim(cdvCreateReason.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvCreateReason.Focus();
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

        // Create_Lot()
        //       - Create New Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Create_Lot(char ProcStep)
        {
            TRSNode in_node = new TRSNode("CREATE_LOT_IN");
            TRSNode out_node = new TRSNode("CREATE_LOT_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                //자재Lot
                in_node.AddString("LOT_DESC", "");

                //자재품번
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMatID.Text));
                in_node.AddInt("MAT_VER", 1);

                //FLOW
                in_node.AddString("FLOW", MPCF.Trim(BIGC.B_FLOW_FF100));

                //창고
                in_node.AddString("OPER", MPCF.Trim(cdvStoreID.Tag));

                //총수량
                if (txtTotalQty.Value.ToString() != "0")
                {
                    in_node.AddDouble("QTY_1", MPCF.ToDbl(txtTotalQty.Value));
                }
                else
                {
                    in_node.AddDouble("QTY_1", 0);
                }

                //LOT_TYPE
                in_node.AddChar("LOT_TYPE", BIGC.B_LOT_TYPE_I);
                
                //OWNER_CODE
                in_node.AddString("OWNER_CODE", BIGC.B_OWNER_CODE_PROD);

                //CREATE_CODE
                in_node.AddString("CREATE_CODE", BIGC.B_CREATE_CODE_PROD);

                //DUE_TIME
                in_node.AddString("DUE_TIME", DateTime.Now.ToShortDateString().ToString().Replace("-",""));

                //계정그룹&계정그룹상세유형
                in_node.AddString("LOT_CMF_1", BIGC.B_INV_ACC_GRP_RECV_ETC); //LOT_CMF_1 계정그룹
                in_node.AddString("LOT_CMF_2", BIGC.B_INV_ACC_DETAIL_RECV_ETC); //LOT_CMF_2 계정상세유형

                //유통기한&제조일
                in_node.AddString("LOT_CMF_5", dtpDate.GetValueAsString(8)); //LOT_CMF_5 제조일자
                in_node.AddString("LOT_CMF_6", dtpLife.GetValueAsString(8)); //LOT_CMF_6 유통기한

                //생성사유
                in_node.AddString("LOT_CMF_7", BIGC.B_INV_RSN_GRP_RG1); //LOT_CMF_7 사유그룹
                in_node.AddString("LOT_CMF_8", cdvCreateReason.Tag); //LOT_CMF_8 사유

                //Unit
                in_node.AddString("INV_UNIT", MPCF.Trim(txtUnit.Text)); //INV_UNIT

                //Bulk 자재 여부
                if (chkBulk.Checked == true)
                {
                    in_node.AddChar("BULK_FLAG", 'Y');
                }
                else
                {
                    in_node.AddChar("BULK_FLAG", 'N');
                }

                if (MPCF.CallService("BINV", "BINV_Tran_Create_Lot", in_node, ref out_node) == false) //BINV_Tran_Create_Inventory_Lot
                {
                    return false;
                }

                txtInvLotID.Text = out_node.GetString("LOT_ID");
                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }
        private void cdvMatID_CodeViewButtonClick_1(object sender, EventArgs e)
        {
            try
            {
                MenuInfoTag selectedMenuInfo;

                BOI.INVCus.Popup.frmInvViewMatList frm = new BOI.INVCus.Popup.frmInvViewMatList(MPCF.Trim(cdvMatID.Text), BIGC.B_MAT_TYPE_GRP_M);

                selectedMenuInfo = new MenuInfoTag();
                selectedMenuInfo.s_func_desc = "View Inv Mat List";
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

                    BOI.INVCus.Popup.frmInvViewMatList frm = new BOI.INVCus.Popup.frmInvViewMatList(MPCF.Trim(cdvMatID.Text), BIGC.B_MAT_TYPE_GRP_M);

                    selectedMenuInfo = new MenuInfoTag();
                    selectedMenuInfo.s_func_desc = "View Inv Mat List";
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
        private void btnLabelPrint_Click(object sender, EventArgs e)
        {
            if (Tran_Print_Label() == false)
            {
                return;
            }
            btnLabelPrint.Enabled = false;
        }
        #endregion

        

        
    }
}
