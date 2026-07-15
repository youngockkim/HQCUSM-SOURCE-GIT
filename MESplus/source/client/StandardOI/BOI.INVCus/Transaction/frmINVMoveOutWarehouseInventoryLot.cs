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
using SOI.DNM;
using BOI.OIFrx.BOIBaseForm;
using BOI.OIFrx;
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
    public partial class frmINVMoveOutWarehouseInventoryLot : BOIBaseForm02
    {
        #region Property

        //From 창고
        private const string _W300 = "W300";

        // (Required) 
        private bool bIsShown = false;

        private MenuInfoTag menuInfo;
        public PrintOptionModel printOption;
        private frmPrintOptionPopup frmOption;

        private string s_mat_id = string.Empty;
        private string s_mat_desc = string.Empty;
        private string s_unit = string.Empty;
        //private double d_unit_qty = 0;
        private double d_total_qty = 0;

        private bool bCheckAll = false;

        private string[] sum_mat_id = new string[50];
        private string[] sum_mat_desc = new string[50];
        private double[] sum_qty = new double[50];
        private string[] sum_oper = new string[50];
        private string[] sum_unit = new string[50];

        private Rs232 m_CommPort = new Rs232();

        private enum INV_LOT_COL
        {
            CHECK_SELECT = 0,
            INV_LOT_ID,
            MAT_DESC,
            MAT_ID,
            TO_STORE,
            TO_STORE_CODE,
            UNIT_QTY,
            TOTAL_QTY,
            UNIT,
            FROM_STORE_CODE
        }

        private enum MAT_COL
        {
            MAT_DESC = 0,
            MAT_ID,
            TO_STORE,
            QTY,
            UNIT
        }

        #endregion

        #region Constructor

        public frmINVMoveOutWarehouseInventoryLot()
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

            cdvFromFactory.Text = "";
            cdvFromFactory.Tag = "";

            cdvToStoreID.Text = "";
            cdvToStoreID.Tag = "";

            InvisibleColumn();

            MPCF.ClearList(spdInvLot);

            MPCF.ClearList(spdMatLotQty);

            btnLabelPrint.Enabled = false;

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

                txtInvLotID.Focus();
                txtInvLotID.SelectAll();
                // (Required) 
                bIsShown = true;
            }
        }

        private void cdvFromStoreID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_OPERATION_LIST_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("OPER_GRP_1", BIGC.OPER_GRP_1_M);

                // CodeView Column Header Setup
                string[] header = new string[] { "Oper", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "OPER", "OPER_SHORT_DESC" };

                // Show
                cdvFromFactory.Text = cdvFromFactory.Show(cdvFromFactory, "Store ID", "BWIP", "BWIP_View_Operation_List", in_node, "OPERATION_LIST", display, header, "OPER_SHORT_DESC");

                if (MPCF.Trim(cdvFromFactory.Text) != "")
                {
                    if (cdvFromFactory.returnDatas.Count > 0)
                    {
                        cdvFromFactory.Tag = cdvFromFactory.returnDatas[0];
                        cdvFromFactory.Text = cdvFromFactory.returnDatas[1];

                        if (cdvFromFactory.Tag.ToString() == cdvToStoreID.Tag.ToString())
                        {
                            cdvToStoreID.Text = "";
                            cdvToStoreID.Tag = "";

                            MPCF.ShowMessage(MPCF.GetMessage(370), MSG_LEVEL.WARNING, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvToStoreID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "USER_ID";
                dvcArgu[1].sCondition_Value = MPGV.gsUserID;

                // CodeView Column Header Setup
                string[] header = new string[] { "Oper", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "OPER", "OPER_SHORT_DESC" };

                // Show
                cdvToStoreID.Text = cdvToStoreID.Show(cdvToStoreID, "Oper", "COM0000-008", dvcArgu, display, header, "OPER_SHORT_DESC", -1);

                if (MPCF.Trim(cdvToStoreID.Text) != "")
                {
                    if (cdvToStoreID.returnDatas.Count > 0)
                    {
                        cdvToStoreID.Tag = cdvToStoreID.returnDatas[0];
                    }
                    else
                    {
                        cdvToStoreID.Tag = "";
                    }
                }
                else
                {
                    cdvToStoreID.Tag = "";
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
                    if (CheckCondition("VIEW_LOT") == true)
                    {
                        //tempLotId = txtInvLotID.Text.Trim();
                        //indexValue = tempLotId.IndexOf(":");

                        //txtInvLotID.Text = tempLotId.Substring(0, indexValue);
                        //d_unit_qty = MPCF.ToDbl(tempLotId.Substring(indexValue + 1));

                        if (View_Lot(txtInvLotID.Text) == false)
                        {
                            txtInvLotID.Text = "";

                            cdvToStoreID.Focus();
                            //txtInvLotID.Focus();
                            //txtInvLotID.SelectAll();
                            //d_unit_qty = 0;
                        }
                        else
                        {
                            //성공시 버튼클릭
                            btnAdd.PerformClick();

                            txtInvLotID.Focus();
                            txtInvLotID.SelectAll();
                        }
                    }
                    else
                    {
                        txtInvLotID.Text = "";
                        //d_unit_qty = 0;

                        txtInvLotID.Focus();
                        txtInvLotID.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int j = 0;
            bool mat_check = false;
            try
            {
                if (CheckCondition("ADD_ROW") == false)
                {
                    return;
                }

                spdInvLot.Sheets[0].RowCount += 1;
                spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.CHECK_SELECT].Value = true;
                spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.INV_LOT_ID].Value = txtInvLotID.Text;
                spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.MAT_ID].Value = s_mat_id;
                
                spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.MAT_DESC].Value = s_mat_desc;
                spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.TO_STORE].Value = cdvToStoreID.Text;
                spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.TO_STORE_CODE].Value = cdvToStoreID.Tag;
                spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.UNIT].Value = s_unit;
                //spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.UNIT_QTY].Value = d_unit_qty;
                spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.TOTAL_QTY].Value = d_total_qty;
                spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.FROM_STORE_CODE].Value = cdvFromFactory.Tag;

                MPCF.FitColumnHeader(spdInvLot);

                if (spdInvLot.ActiveSheet.RowCount == 1)
                {
                    cdvToStoreID.Enabled = false;
                    cdvToStoreID.ReadOnly = true;
                }

                //summary
                if (spdInvLot.ActiveSheet.RowCount == 1)
                {
                    sum_mat_id[0] = s_mat_id;
                    sum_qty[0] = d_total_qty;
                    sum_oper[0] = cdvToStoreID.Text;
                    sum_unit[0] = s_unit;
                    sum_mat_desc[0] = s_mat_desc;
                    mat_check = false;
                    j = 1;
                }
                else
                {
                    for (int i = 0; i < 50; i++)
                    {
                        if (sum_mat_id[i] == s_mat_id)
                        {
                            sum_qty[i] = sum_qty[i] + d_total_qty;
                            mat_check = true;
                            break;
                        }
                        if (sum_mat_id[i] == "" || sum_mat_id[i] == null)
                        {
                            break;
                        }
                    }
                    if (mat_check == false)
                    {
                        sum_mat_id[spdMatLotQty.ActiveSheet.RowCount] = s_mat_id;
                        sum_qty[spdMatLotQty.ActiveSheet.RowCount] = d_total_qty;
                        sum_oper[spdMatLotQty.ActiveSheet.RowCount] = cdvToStoreID.Text;
                        sum_unit[spdMatLotQty.ActiveSheet.RowCount] = s_unit;
                        sum_mat_desc[spdMatLotQty.ActiveSheet.RowCount] = s_mat_desc;
                        mat_check = false;
                    }
                }
                ViewTotalQty();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

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

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            bool mat_check = false;
            int array_count = 0;
            try
            {
                if (bCheckAll == false)
                {
                    for (int i = 0; i < spdInvLot.Sheets[0].RowCount; i++)
                    {
                        spdInvLot.Sheets[0].Cells[i, (int)INV_LOT_COL.CHECK_SELECT].Value = true;
                    }

                    bCheckAll = true;
                    btnCheckAll.Text = "Uncheck All";

                    MPCF.ConvertCaption(this);
                    
                    //초기화
                    for (int i = 0; i < 50; i++)
                    {
                        if (sum_mat_id[i] == "")
                        {
                            break;
                        }
                        sum_mat_id[i] = "";
                        sum_mat_desc[i] = "";
                        sum_unit[i] = "";
                        sum_oper[i] = "";
                        sum_qty[i] = 0.00;
                    }
                    //다시 sum
                    for (int j = 0; j < spdInvLot.ActiveSheet.RowCount; j++)
                    {
                        if (j==0)
                        {
                            sum_mat_id[0] = MPCF.Trim(spdInvLot.ActiveSheet.Cells[j,(int)INV_LOT_COL.MAT_ID].Text);
                            sum_qty[0] = MPCF.ToDbl(spdInvLot.ActiveSheet.Cells[j, (int)INV_LOT_COL.TOTAL_QTY].Value);
                            sum_oper[0] = MPCF.Trim(spdInvLot.ActiveSheet.Cells[j, (int)INV_LOT_COL.TO_STORE].Text);
                            sum_unit[0] = MPCF.Trim(spdInvLot.ActiveSheet.Cells[j, (int)INV_LOT_COL.UNIT].Text);
                            sum_mat_desc[0] = MPCF.Trim(spdInvLot.ActiveSheet.Cells[j, (int)INV_LOT_COL.MAT_DESC].Text);
                            mat_check = false;
                            array_count = 1;
                        }
                        else
                        {
                            for (int i = 0; i < 50; i++)
                            {
                                if (sum_mat_id[i] == MPCF.Trim(spdInvLot.ActiveSheet.Cells[j, (int)INV_LOT_COL.MAT_ID].Text))
                                {
                                    sum_qty[i] = sum_qty[i] + MPCF.ToDbl(spdInvLot.ActiveSheet.Cells[j, (int)INV_LOT_COL.TOTAL_QTY].Value);
                                    mat_check = true;
                                    break;
                                }
                                if (sum_mat_id[i] == "")
                                {
                                    mat_check = false;
                                    array_count++;
                                    break;
                                }
                            }
                            if (mat_check == false)
                            {
                                sum_mat_id[array_count - 1] = MPCF.Trim(spdInvLot.ActiveSheet.Cells[j, (int)INV_LOT_COL.MAT_ID].Text); ;
                                sum_qty[array_count - 1] = MPCF.ToDbl(spdInvLot.ActiveSheet.Cells[j, (int)INV_LOT_COL.TOTAL_QTY].Value);
                                sum_oper[array_count - 1] = MPCF.Trim(spdInvLot.ActiveSheet.Cells[j, (int)INV_LOT_COL.TO_STORE].Text);
                                sum_unit[array_count - 1] = MPCF.Trim(spdInvLot.ActiveSheet.Cells[j, (int)INV_LOT_COL.UNIT].Text);
                                sum_mat_desc[array_count - 1] = MPCF.Trim(spdInvLot.ActiveSheet.Cells[j, (int)INV_LOT_COL.MAT_DESC].Text);
                                mat_check = false;
                            }
                        }
                    }

                    ViewTotalQty();
                }
                else
                {
                    for (int i = 0; i < spdInvLot.Sheets[0].RowCount; i++)
                    {
                        spdInvLot.Sheets[0].Cells[i, (int)INV_LOT_COL.CHECK_SELECT].Value = false;
                    }

                    bCheckAll = false;
                    btnCheckAll.Text = "Check All";

                    MPCF.ConvertCaption(this);

                    MPCF.ClearList(spdMatLotQty);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            char cProcStep = '1';

            try
            {
                if (CheckCondition("MOVE_LOT") == true)
                {
                    if(cdvFromFactory.Tag.ToString() != MPGV.gsFactory)
                    {
                        cProcStep = '2';
                    }

                    if (Move_Lot(cProcStep) == true)
                    {
                        btnLabelPrint.Enabled = true;
                        //초기화
                        for (int i = 0; i < 50; i++)
                        {
                            if (sum_mat_id[i] == "")
                            {
                                break;
                            }
                            sum_mat_id[i] = "";
                            sum_mat_desc[i] = "";
                            sum_unit[i] = "";
                            sum_oper[i] = "";
                            sum_qty[i] = 0.00;
                        }
                        MPCF.ClearList(spdMatLotQty);
                        MPCF.ClearList(spdInvLot);
                        cdvToStoreID.Enabled = true;
                        cdvToStoreID.ReadOnly = false;
                        txtInvLotID.Focus();
                        txtInvLotID.SelectAll();
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

        private bool CheckCondition(string FuncName)
        {
            int iRow;

            try
            {
                switch (FuncName)
                {
                    case "ADD_ROW":
                        //From Store Oper
                        if (MPCF.Trim(cdvFromFactory.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvFromFactory.Focus();
                            return false;
                        }
                        //To Store Oper
                        if (MPCF.Trim(cdvToStoreID.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvToStoreID.Focus();
                            return false;
                        }

                        //Inv LotID
                        if (MPCF.Trim(txtInvLotID.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            txtInvLotID.Focus();
                            return false;
                        }

                        //같은 Lot 있는지 조회
                        for (iRow = 0; iRow < spdInvLot.Sheets[0].RowCount; iRow++)
                        {
                            if (spdInvLot.Sheets[0].Cells[iRow, (int)INV_LOT_COL.INV_LOT_ID].Value.ToString().Trim() == txtInvLotID.Text.Trim())
                            {
                                MPCF.ShowMessage(MPCF.GetMessage(368).Replace("{1}", txtInvLotID.Text.Trim()), MSG_LEVEL.WARNING, true);
                                return false;
                            }
                        }

                        if (cdvFromFactory.Tag.ToString() == cdvToStoreID.Tag.ToString())
                        {
                            cdvToStoreID.Text = "";
                            cdvToStoreID.Tag = "";

                            MPCF.ShowMessage(MPCF.GetMessage(370), MSG_LEVEL.WARNING, true);
                            return false;
                        }

                        break;

                    case "VIEW_LOT":
                        //Store Oper
                        //if (MPCF.Trim(cdvFromStoreID.Text) == "")
                        //{
                        //    MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                        //    cdvFromStoreID.Focus();
                        //    return false;
                        //}

                        break;

                    case "MOVE_LOT":
                      

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

        // Move_Lot()
        //       - Move Inv Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Move_Lot(char ProcStep)
        {
            int i = 0;

            TRSNode in_node = new TRSNode("MOVE_LOT_IN");
            TRSNode out_node = new TRSNode("MOVE_LOT_OUT");
            TRSNode list_item;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                //Ship을 위해 in_node Factory를 From Factory로 변경
                in_node.SetString("FACTORY", cdvFromFactory.Tag.ToString());

                in_node.SetString("TO_FACTORY", MPGV.gsFactory);

                for (i = 0; i < spdInvLot.Sheets[0].RowCount; i++)
                {
                    if (spdInvLot.Sheets[0].Cells[i, (int)INV_LOT_COL.CHECK_SELECT].Value != null && (bool)spdInvLot.Sheets[0].Cells[i, (int)INV_LOT_COL.CHECK_SELECT].Value == true)
                    {
                        list_item = in_node.AddNode("SKIP_LIST"); //자재 MOVE는 SKIP처리

                        //To Store Oper
                        list_item.AddString("TO_OPER", MPCF.Trim(spdInvLot.Sheets[0].Cells[i,(int)INV_LOT_COL.TO_STORE_CODE].Value));

                        //From Store Oper
                        //list_item.AddString("FROM_OPER", MPCF.Trim(spdInvLot.Sheets[0].Cells[i, (int)INV_LOT_COL.FROM_STORE_CODE].Value));

                        //자재 LotID
                        list_item.AddString("LOT_ID", MPCF.Trim(spdInvLot.Sheets[0].Cells[i, (int)INV_LOT_COL.INV_LOT_ID].Value));

                        //UNIT
                        list_item.AddString("UNIT", MPCF.Trim(spdInvLot.Sheets[0].Cells[i, (int)INV_LOT_COL.UNIT].Value));

                        //MAT_ID
                        list_item.AddString("MAT_ID", MPCF.Trim(spdInvLot.Sheets[0].Cells[i, (int)INV_LOT_COL.MAT_ID].Value));

                        //계정그룹&계정그룹상세유형
                        list_item.AddString("LOT_CMF_1", BIGC.B_INV_ACC_GRP_MOVE_INSIDE); //LOT_CMF_1 계정그룹
                        list_item.AddString("LOT_CMF_2", BIGC.B_INV_ACC_DETAIL_MOVE_STORE); //LOT_CMF_2 계정상세유형

                        //사유
                        if (ProcStep == '1')//자공장
                        {
                            list_item.AddString("LOT_CMF_7", BIGC.B_INV_RSN_GRP_RG3); //LOT_CMF_7 사유그룹
                            list_item.AddString("LOT_CMF_8", BIGC.B_INV_RSN_DTL_R32); //LOT_CMF_8 사유
                        }
                        else if (ProcStep == '2')//타공장
                        {
                            list_item.AddString("LOT_CMF_7", BIGC.B_INV_RSN_GRP_RGC); //LOT_CMF_7 사유그룹
                            list_item.AddString("LOT_CMF_8", BIGC.B_INV_RSN_DTL_RC2); //LOT_CMF_8 사유
                        }
                    }
                }

                if (in_node.GetList("SKIP_LIST").Count == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(369), MSG_LEVEL.WARNING, false);
                    return false;
                }

                if (MPCF.CallService("BINV", "BINV_Tran_Skip_Inv_Lot", in_node, ref out_node) == false) //BINV_Multi_Tran_Move_Inventory_Lot
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

        //자재별 총 수량
        private bool ViewTotalQty()
        {
            try
            {
                MPCF.ClearList(spdMatLotQty);

                for (int i = 0; i < 50; i++)
                {
                    if (sum_mat_id[i] == "" || sum_mat_id[i] == null)
                    {
                        break;
                    }
                    else
                    {
                        spdMatLotQty.Sheets[0].RowCount += 1;
                        spdMatLotQty.Sheets[0].Cells[spdMatLotQty.Sheets[0].RowCount - 1, (int)MAT_COL.MAT_ID].Value = sum_mat_id[i];
                        spdMatLotQty.Sheets[0].Cells[spdMatLotQty.Sheets[0].RowCount - 1, (int)MAT_COL.MAT_DESC].Value = sum_mat_desc[i];
                        spdMatLotQty.Sheets[0].Cells[spdMatLotQty.Sheets[0].RowCount - 1, (int)MAT_COL.TO_STORE].Value = sum_oper[i];
                        spdMatLotQty.Sheets[0].Cells[spdMatLotQty.Sheets[0].RowCount - 1, (int)MAT_COL.UNIT].Value = sum_unit[i];
                        spdMatLotQty.Sheets[0].Cells[spdMatLotQty.Sheets[0].RowCount - 1, (int)MAT_COL.QTY].Value = sum_qty[i];
                    }
                }

                //TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];
                //DataTable dt = null;
                //string sMatId = string.Empty;
                //string sOper = string.Empty;
                //string s_column = "";

                //dvcArgu[0].sCondtion_ID = "$FACTORY";
                //dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                //for (int i = 0; i < spdInvLot.Sheets[0].RowCount; i++)
                //{
                //    if (spdInvLot.Sheets[0].Cells[i, (int)INV_LOT_COL.CHECK_SELECT].Value != null && (bool)spdInvLot.Sheets[0].Cells[i, (int)INV_LOT_COL.CHECK_SELECT].Value == true)
                //    {
                //        sMatId = sMatId + "'" + spdInvLot.Sheets[0].Cells[i, (int)INV_LOT_COL.MAT_ID].Value.ToString() + "',";
                //        sOper = sOper + "'" + spdInvLot.Sheets[0].Cells[i, (int)INV_LOT_COL.TO_STORE_CODE].Value.ToString() + "',";
                //    }
                //}

                //if (sMatId == "")
                //{
                //    return false;
                //}

                //dvcArgu[1].sCondtion_ID = "$MAT_ID";
                //dvcArgu[1].sCondition_Value = sMatId.Substring(0, sMatId.Length - 1);

                //dvcArgu[2].sCondtion_ID = "$OPER";
                //dvcArgu[2].sCondition_Value = sOper.Substring(0, sOper.Length - 1);

                //if (TPDR.GetDataOne(s_column, ref dt, "BINV1000-001", dvcArgu, false, false) == false)
                //{
                //    if (dt != null)
                //        dt.Dispose();

                //    GC.Collect();
                //    return false;
                //}

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    spdMatLotQty.Sheets[0].RowCount += 1;
                //    spdMatLotQty.Sheets[0].Cells[spdMatLotQty.Sheets[0].RowCount - 1, (int)MAT_COL.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                //    spdMatLotQty.Sheets[0].Cells[spdMatLotQty.Sheets[0].RowCount - 1, (int)MAT_COL.MAT_DESC].Value = dt.Rows[i]["MAT_DESC"].ToString();
                //    spdMatLotQty.Sheets[0].Cells[spdMatLotQty.Sheets[0].RowCount - 1, (int)MAT_COL.TO_STORE].Value = dt.Rows[i]["OPER_DESC"].ToString();
                //    spdMatLotQty.Sheets[0].Cells[spdMatLotQty.Sheets[0].RowCount - 1, (int)MAT_COL.UNIT].Value = dt.Rows[i]["UNIT_1"].ToString();
                //    spdMatLotQty.Sheets[0].Cells[spdMatLotQty.Sheets[0].RowCount - 1, (int)MAT_COL.QTY].Value = dt.Rows[i]["TOTAL_QTY"].ToString();
                //}


                //MPCF.FitColumnHeader(spdMatLotQty);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        private void InvisibleColumn()
        {
            try
            {
                spdInvLot.Sheets[0].Columns[(int)INV_LOT_COL.MAT_ID].Visible = false;
                spdInvLot.Sheets[0].Columns[(int)INV_LOT_COL.TO_STORE_CODE].Visible = false;
                spdInvLot.Sheets[0].Columns[(int)INV_LOT_COL.FROM_STORE_CODE].Visible = false;
                spdInvLot.Sheets[0].Columns[(int)INV_LOT_COL.UNIT_QTY].Visible = false;

                spdMatLotQty.Sheets[0].Columns[(int)MAT_COL.MAT_ID].Visible = false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Lot
        /// </summary>
        /// <param name="sLotID"></param>
        /// <returns></returns>
        private bool View_Lot(string sLotID)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));
                //in_node.AddString("OPER", MPCF.Trim(cdvFromStoreID.Tag));

                if (MPCF.CallService("BINV", "BINV_View_Lot", in_node, ref out_node) == false) //BINV_View_Inventory_Lot
                {
                    return false;
                }

                if (out_node.GetString("OPER") == cdvToStoreID.Tag.ToString())
                {
                    MPCF.ShowMessage(MPCF.GetMessage(478), MSG_LEVEL.WARNING, true);
                    return false;
                }

                s_mat_id = out_node.GetString("MAT_ID");
                s_mat_desc = out_node.GetString("MAT_DESC");
                s_unit = out_node.GetString("UNIT_1");
                d_total_qty = out_node.GetDouble("QTY_1");

                //cdvFromFactory.Text = out_node.GetString("OPER_DESC");
                //cdvFromFactory.Tag = out_node.GetString("OPER");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private void spdInvLot_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (e.Column == (int)INV_LOT_COL.INV_LOT_ID)
                {
                    spdInvLot.Sheets[0].RemoveRows(e.Row, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        private void soiLabel2_Click(object sender, EventArgs e)
        {

        }

        private void cdvReason_ValueChanged(object sender, EventArgs e)
        {

        }

        private void soiLabel4_Click(object sender, EventArgs e)
        {

        }


        private void spdInvLot_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (spdInvLot.Sheets[0].RowCount <= 0 )
                    return;
                if (e.Column == (int)INV_LOT_COL.CHECK_SELECT)
                {
                    if (Convert.ToBoolean(spdInvLot.ActiveSheet.Cells[e.Row, (int)INV_LOT_COL.CHECK_SELECT].Value) == false)
                    {
                        for (int i = 0; i < 50; i++)
                        {
                            if (spdInvLot.ActiveSheet.Cells[e.Row, (int)INV_LOT_COL.MAT_ID].Value.ToString() == sum_mat_id[i])
                            {
                                sum_qty[i] = sum_qty[i] - MPCF.ToDbl(spdInvLot.ActiveSheet.Cells[e.Row, (int)INV_LOT_COL.TOTAL_QTY].Value);
                                break;
                            }
                            if (sum_mat_id[i] == "" || sum_mat_id[i] == null)
                            {
                                break;
                            }
                        }
                        //spdInvLot.ActiveSheet.Cells[e.Row, (int)INV_LOT_COL.CHECK_SELECT].Value = false;
                    }
                    else if (Convert.ToBoolean(spdInvLot.ActiveSheet.Cells[e.Row, (int)INV_LOT_COL.CHECK_SELECT].Value) == true)
                    {
                        for (int i = 0; i < 50; i++)
                        {
                            if (spdInvLot.ActiveSheet.Cells[e.Row, (int)INV_LOT_COL.MAT_ID].Value.ToString() == sum_mat_id[i])
                            {
                                sum_qty[i] = sum_qty[i] + MPCF.ToDbl(spdInvLot.ActiveSheet.Cells[e.Row, (int)INV_LOT_COL.TOTAL_QTY].Value);
                                break;
                            }
                            if (sum_mat_id[i] == "" || sum_mat_id[i] == null)
                            {
                                break;
                            }
                        }

                        //spdInvLot.ActiveSheet.Cells[e.Row, (int)INV_LOT_COL.CHECK_SELECT].Value = true;
                    }
                    ViewTotalQty();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnLabelPrint_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < spdInvLot.ActiveSheet.RowCount; i++)
            {
                if (Convert.ToBoolean(spdInvLot.ActiveSheet.Cells[i, (int)INV_LOT_COL.CHECK_SELECT].Value) == true)
                {
                    if (Tran_Print_Label(MPCF.Trim(spdInvLot.ActiveSheet.Cells[i, (int)INV_LOT_COL.INV_LOT_ID].Text)) == false)
                    {
                        return;
                    }
                }
            }
            btnLabelPrint.Enabled = false;
        }

        private bool Tran_Print_Label(string s_lot_id)
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
                in_node.AddString("LOT_ID", MPCF.Trim(s_lot_id));
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

        private void cdvFromFactory_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_FACTORY_IN");
                TRSNode out_node = new TRSNode("VIEW_FACTORY_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_FACTORY_LIST));

                // CodeView Column Header Setup
                string[] header = new string[] { "Factory", "Factory Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvFromFactory.Text = cdvFromFactory.Show(cdvFromFactory, "Factory List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "DATA_1");

                if (MPCF.Trim(cdvFromFactory.Text) != "")
                {
                    if (cdvFromFactory.returnDatas != null && cdvFromFactory.returnDatas.Count > 0)
                    {
                        cdvFromFactory.Tag = cdvFromFactory.returnDatas[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

    }
}
