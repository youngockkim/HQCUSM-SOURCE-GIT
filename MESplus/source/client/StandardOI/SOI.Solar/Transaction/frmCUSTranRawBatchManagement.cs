//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmCUSTranRawBatchManagement.cs
//   Description :
//
//   MES Version : 5.3.5.0
//
//   Function List
//       - 
//
//   Detail Description
//       -
//
//   Use Service Module
//      Service
//       - 
//      Query
//       - 
//       - 
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2017-08-19 : Created by Sanghun Mo  
//
//
//   Copyright(C) 1998-2017 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using BOI.OIFrx;
using BOI.OIFrx.BOIBaseForm;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.DNM;
using SOI.CliFrx;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using BOI.OIFrx.BOIControls;

namespace SOI.Solar
{
    public partial class frmCUSTranRawBatchManagement : BOIBaseForm02
    {
        #region [Property]

        const int ENTER = 13;
        private double d_Lot_Qty = 0;

        #endregion

        public frmCUSTranRawBatchManagement()
        {
            InitializeComponent();
        }

        #region [Constant Definition]

        #endregion

        #region [Variable Definition]

        private bool bIsShown = false;

        private enum RAW_MAT_LIST : int
        {
            OPER = 0,
            MAT_ID,
            MAT_VER,
            MAT_DESC,
            MAT_BOX_QTY,
            MODEL,
            LOT_ID,
            LINE_ID,
            QTY,
			CREATE_TIME
        }

        private enum CELL_LOT_LIST : int
        {
            OPER = 0,
            MAT_ID,
            MAT_VER,
            MAT_DESC,
            MAT_BOX_QTY,
            MODEL,
            LOT_ID,
            LINE_ID,
            QTY,
			CREATE_TIME
        }

        private enum CELLBOX_CUSTCODE_LIST : int
        {
            CUST_BARCODE = 0,
            MAT_ID,
            MAT_VER,
            MAT_DESC,
            QTY
        }

        #endregion


        #region [FormDefinition]

        private void initCtrl()
        {
            try
            {
                // (Required) Convert Caption
                // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
                MPCF.ConvertCaption(this);

                MPCF.FieldClear(this);                

                MPCF.ClearList(this.spdRawMatList, true);
                MPCF.FitColumnHeader(spdRawMatList);
                MPCF.ClearList(this.spdCellLotList, true);
                MPCF.FitColumnHeader(spdCellLotList);
                MPCF.ClearList(this.spdCellCustCodeList, true);
                MPCF.FitColumnHeader(spdCellCustCodeList);

                this.spdRawMatList.ActiveSheet.Columns[(int)RAW_MAT_LIST.MAT_VER].Visible = false;

                this.txtMatID.Enabled = false;
                this.txtMatVer.Enabled = false;
                this.txtMatDesc.Enabled = false;
                this.txtMatDesc.Visible = false;

                this.ViewRawMatList();
                this.ViewCellLotList();

                //영문 대문자 강제
                this.txtBarcode.CharacterCasing = CharacterCasing.Upper;
                //한글 자판허용 안함
                this.txtBarcode.ImeMode = ImeMode.Disable;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        #endregion


        #region [Function Definition]

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case CSGC.MP_CHECK_VIEW:
                        break;

                    case CSGC.MP_CHECK_CREATE:


                        if (MPCF.Trim(this.txtMatID.Text) == string.Empty
                            || MPCF.Trim(this.txtMatVer.Text) == string.Empty
                            || MPCF.Trim(this.txtMatDesc.Text) == string.Empty)
                        {
                            return false;
                        }

                        for (int r = 0; r < this.spdCellCustCodeList.ActiveSheet.RowCount; r++)
                        {
                            if (MPCF.Trim(this.txtMatID.Text) != MPCF.Trim(this.spdCellCustCodeList.ActiveSheet.Cells[r, (int)CELLBOX_CUSTCODE_LIST.MAT_ID].Value)
                                || MPCF.Trim(this.txtMatVer.Text) != MPCF.Trim(this.spdCellCustCodeList.ActiveSheet.Cells[r, (int)CELLBOX_CUSTCODE_LIST.MAT_VER].Value)
                                )
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(335));
                                MPCF.FieldClear(this.grbSaveOpt);
                                return false;
                            }
                        }

                        this.txtRawMatQty.Text = MPCF.Trim(this.txtRawMatQty.Text);
                        if (string.IsNullOrEmpty(this.txtRawMatQty.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335));
                            this.txtRawMatQty.Focus();
                            this.txtRawMatQty.SelectAll();
                            return false;
                        }

                        this.txtRawMatQty.Text = MPCF.Trim(this.txtRawMatQty.Text);
                        if (MPCF.CheckNumeric(this.txtRawMatQty.Text) == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(116));
                            txtRawMatQty.Focus();
                            txtRawMatQty.SelectAll();
                            return false;
                        }

                        this.txtRawMatQty.Text = MPCF.Trim(this.txtRawMatQty.Text);
                        if (MPCF.ToDbl(MPCF.Trim(this.txtRawMatQty.Text)) < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(65));
                            txtRawMatQty.Focus();
                            txtRawMatQty.SelectAll();
                            return false;
                        }

                        if (MPCF.ToDbl(MPCF.Trim(this.txtRawMatQty.Text)) >
                            MPCF.ToDbl(MPCF.Trim(this.spdRawMatList.ActiveSheet.Cells[spdRawMatList.ActiveSheet.ActiveRowIndex, (int)RAW_MAT_LIST.QTY].Text)))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(125));
                            txtRawMatQty.Focus();
                            txtRawMatQty.SelectAll();
                            return false;
                        }

                        this.txtBarcode.Text = MPCF.Trim(this.txtBarcode.Text);
                        if (string.IsNullOrEmpty(this.txtBarcode.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335));
                            this.txtBarcode.Focus();
                            this.txtBarcode.SelectAll();
                            return false;
                        }

                        //if (MPCF.Trim(this.txtBarcode.Text).Length > 50)
                        //{
                        //    MPCF.ShowMsgBox("50 " + MPCF.GetMessage(397) + Environment.NewLine + MPCF.FindLanguage("Barcode"));
                        //    this.txtBarcode.Focus();
                        //    this.txtBarcode.SelectAll();
                        //    return false;
                        //}

                        break;

                    case CSGC.MP_CHECK_UPDATE:

                        if (utbLotList.ActiveTab.Index == 0)
                            if (this.spdCellCustCodeList.ActiveSheet.RowCount < 1)
                                return false;
                        break;

                    case CSGC.MP_CHECK_DELETE:

                        break;

                    default:
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewRawMatList()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            MPCF.ClearList(this.spdRawMatList);

            try
            {
                MPCF.FieldClear(this.grbSaveOpt);                

                sViewID = "VIEW_OPER_LOT_LIST_05";
                i_cond_cnt = 3;

				ArrDVC = new TPDR.DirectViewCond[i_cond_cnt]; ;
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$STOCK";
                ArrDVC[1].sCondition_Value = MPCF.Trim(CSGC.MP_TIV_INV_WIPOPR);

                ArrDVC[2].sCondtion_ID = "$MAT_ID";
                ArrDVC[2].sCondition_Value = MPCF.Trim(this.cdvMaterial.Text);

                if (TPDR.DirectViewOne(this.spdRawMatList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                if (spdRawMatList.ActiveSheet.RowCount > 0)
                {
                    this.spdRawMatList.ActiveSheet.Columns[(int)RAW_MAT_LIST.OPER].Visible = false;
                    //this.spdRawMatList.ActiveSheet.Columns[(int)RAW_MAT_LIST.MAT_BOX_QTY].Visible = false;
                }

                MPCF.FitColumnHeader(this.spdRawMatList);

                this.spdRawMatList.ActiveSheet.Columns[(int)RAW_MAT_LIST.MAT_VER].Visible = false;
				this.spdRawMatList.ActiveSheet.Columns[(int)RAW_MAT_LIST.MAT_DESC].Width = 200f;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return false;
            }
        }

        private bool ViewCellLotList()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            MPCF.ClearList(this.spdCellLotList);

            try
            {
                MPCF.FieldClear(this.grbSaveOpt);
                
                sViewID = "VIEW_OPER_LOT_LIST_06";
                i_cond_cnt = 3;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$STOCK";
                ArrDVC[1].sCondition_Value = MPCF.Trim(CSGC.MP_TIV_INV_WIPOPR);

                ArrDVC[2].sCondtion_ID = "$MAT_ID";
                ArrDVC[2].sCondition_Value = MPCF.Trim(this.cdvMaterial.Text);

                if (TPDR.DirectViewOne(this.spdCellLotList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                if (spdCellLotList.ActiveSheet.RowCount > 0)
                {
                    this.spdCellLotList.ActiveSheet.Columns[(int)CELL_LOT_LIST.OPER].Visible = false;                    
                }

                MPCF.FitColumnHeader(this.spdCellLotList);

                this.spdCellLotList.ActiveSheet.Columns[(int)CELLBOX_CUSTCODE_LIST.MAT_VER].Visible = false;
				this.spdCellLotList.ActiveSheet.Columns[(int)CELL_LOT_LIST.MAT_DESC].Width = 200f;

                this.lblTotalQty.Text = GetTotalQty().ToString();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return false;
            }
        }

        private bool ViewLotBatchCellList()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            MPCF.ClearList(this.spdCellCustCodeList);

            try
            {
                //MPCF.FieldClear(this.grbSaveOpt);

                sViewID = "VIEW_LOT_BATCH_CELL_LIST";
                i_cond_cnt = 2;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$LOT_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(this.spdCellLotList.ActiveSheet.Cells[this.spdCellLotList.ActiveSheet.ActiveRowIndex, (int)CELL_LOT_LIST.LOT_ID].Value);

                if (TPDR.DirectViewOne(this.spdCellCustCodeList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                MPCF.FitColumnHeader(this.spdCellCustCodeList);

				this.spdCellCustCodeList.ActiveSheet.Columns[(int)CELLBOX_CUSTCODE_LIST.MAT_VER].Visible = false;
				this.spdCellCustCodeList.ActiveSheet.Columns[(int)CELLBOX_CUSTCODE_LIST.MAT_DESC].Width = 200f;

                lblTotalQty.Text = GetTotalQty().ToString();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return false;
            }
        }

        private bool UpdateBatchCell()
        {
            try
            {
                TRSNode in_node = new TRSNode("BATCH_CELL_IN");
                TRSNode out_node = new TRSNode("BATCH_CELL_OUT");
                TRSNode Raw_Mat_List;
                double qty_1 = 0.0d;

                MPCF.SetInMsg(in_node);
                if (utbLotList.ActiveTab.Index == 0)
                {
                    in_node.ProcStep = MPGC.MP_STEP_CREATE;
                    in_node.AddString("LOT_ID", MPCF.Trim(this.spdCellCustCodeList.ActiveSheet.Cells[0, (int)CELLBOX_CUSTCODE_LIST.MAT_ID].Value));
                }
                else
                {
                    in_node.ProcStep = MPGC.MP_STEP_UPDATE;
                    in_node.AddString("LOT_ID", MPCF.Trim(this.spdCellLotList.ActiveSheet.Cells[this.spdCellLotList.ActiveSheet.ActiveRowIndex, (int)CELL_LOT_LIST.LOT_ID].Value));
                }

                if(spdCellCustCodeList.ActiveSheet.RowCount>0)
                    in_node.AddString("LOT_DESC", MPCF.Trim(this.spdCellCustCodeList.ActiveSheet.Cells[0, (int)CELLBOX_CUSTCODE_LIST.CUST_BARCODE].Value));
                
                in_node.AddString("MAT_ID", MPCF.Trim(txtMatID.Text));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddInt("MAT_VER", "1");

                for (int r = 0; r < spdCellCustCodeList.ActiveSheet.RowCount; r++)
                {
                    Raw_Mat_List = in_node.AddNode("RAW_MAT_LIST");
                    Raw_Mat_List.AddString("CUST_BARCODE", MPCF.Trim(this.spdCellCustCodeList.ActiveSheet.Cells[r, (int)CELLBOX_CUSTCODE_LIST.CUST_BARCODE].Value));
                    Raw_Mat_List.AddString("MAT_ID", MPCF.Trim(this.spdCellCustCodeList.ActiveSheet.Cells[r, (int)CELLBOX_CUSTCODE_LIST.MAT_ID].Value));
                    Raw_Mat_List.AddInt("MAT_VER", MPCF.Trim(this.spdCellCustCodeList.ActiveSheet.Cells[r, (int)CELLBOX_CUSTCODE_LIST.MAT_VER].Value));
                    Raw_Mat_List.AddDouble("INSTALL_QTY_1", MPCF.Trim(this.spdCellCustCodeList.ActiveSheet.Cells[r, (int)CELLBOX_CUSTCODE_LIST.QTY].Value));

                    qty_1 = qty_1 + MPCF.ToDbl(MPCF.Trim(this.spdCellCustCodeList.ActiveSheet.Cells[r, (int)CELLBOX_CUSTCODE_LIST.QTY].Value));
                }

                if (utbLotList.ActiveTab.Index == 0)
                    in_node.AddDouble("QTY_1", qty_1);
                else
                    in_node.AddDouble("QTY_1", d_Lot_Qty);

                if (CMNF.ShowMsgBox(CMNF.GetMessage(377), MessageBoxButtons.YesNo, SOI.CliFrx.MSG_LEVEL.INFO) != System.Windows.Forms.DialogResult.Yes)
                {
                    return false;
                }

                if (MPCF.CallService("CUS", "CTIV_Update_Batch_Cell", in_node, ref out_node) == false)
                {
                    return false;
                }

                //리스트 삭제
                spdCellCustCodeList.ActiveSheet.RowCount = 0;

                CMNF.ShowSuccessMessage(out_node, true);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return false;
            }
        }

        private int GetTotalQty()
        {
            int iTotalQty = 0;

            for (int row = 0; row < spdCellCustCodeList.ActiveSheet.RowCount; row++)
            {
                iTotalQty = iTotalQty + MPCF.ToInt(this.spdCellCustCodeList.ActiveSheet.Cells[row, (int)CELLBOX_CUSTCODE_LIST.QTY].Value);
            }

            return iTotalQty;
        }
        #endregion


        #region [Event Definition]

        private void frmCUSTranRawBatchManagement_Load(object sender, EventArgs e)
        {
            initCtrl();
        }

        private void frmCUSTranRawBatchManagement_Shown(object sender, EventArgs e)
        {

        }

        private void frmCUSTranRawBatchManagement_Activated(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {

                // (Required) 
                bIsShown = true;
            }
        }

        private void frmCUSTranRawBatchManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // Message Bar를 초기화 합니다.
                MPCF.ShowMessageClear();

                // Memory Flush
                MPCF.FlushMemory();

                //// 조회 조건 Registry에 저장
                //BICF.SaveCondition(this);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("frmCUSTranRawBatchManagement_FormClosed() \n" + ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ViewRawMatList();

            ViewCellLotList();
        }

        private void cdvMaterial_CodeViewButtonClick(object sender, EventArgs e)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

            try
            {
                sViewID = "VIEW_MAT_CELL_LIST";
                i_cond_cnt = 1;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                // CodeView Column Header Setup
                string[] header = new string[] { "Material ID", "Material Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "MAT_ID", "MAT_DESC" };

                // Show by RPTServer
                cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "Material List", sViewID, ArrDVC, display, header, "MAT_ID", -1);

                if (cdvMaterial.returnDatas != null && cdvMaterial.returnDatas.Count > 0)
                {
                    cdvMaterial.Text = cdvMaterial.returnDatas[0];
                    this.txtMaterialDesc.Text = cdvMaterial.returnDatas[1];
                }
                else
                {
                    this.txtMaterialDesc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void spdRawMatList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            try
            {
                MPCF.FieldClear(this.grbSaveOpt);

                this.btnAdd.Enabled = true;                
                this.btnRemove.Enabled = false;

                if (this.spdRawMatList.ActiveSheet.RowCount < 1) { return; }

                this.txtMatID.Text = MPCF.Trim(this.spdRawMatList.ActiveSheet.Cells[this.spdRawMatList.ActiveSheet.ActiveRowIndex, (int)RAW_MAT_LIST.MAT_ID].Value);
                this.txtMatVer.Text = MPCF.Trim(this.spdRawMatList.ActiveSheet.Cells[this.spdRawMatList.ActiveSheet.ActiveRowIndex, (int)RAW_MAT_LIST.MAT_VER].Value);
                this.txtMatDesc.Text = MPCF.Trim(this.spdRawMatList.ActiveSheet.Cells[this.spdRawMatList.ActiveSheet.ActiveRowIndex, (int)RAW_MAT_LIST.MAT_DESC].Value);
                this.txtRawMatQty.Text = MPCF.Trim(this.spdRawMatList.ActiveSheet.Cells[this.spdRawMatList.ActiveSheet.ActiveRowIndex, (int)RAW_MAT_LIST.MAT_BOX_QTY].Value);

                this.lblTotalQty.Text = GetTotalQty().ToString();

                this.txtBarcode.Focus();
                this.txtBarcode.SelectAll();
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
            }
        }

        private void spdCellLotList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            try
            {
                MPCF.FieldClear(this.grbSaveOpt);

                this.btnAdd.Enabled = true;
                this.btnRemove.Enabled = false;

                if (this.spdRawMatList.ActiveSheet.RowCount < 1) { return; }

                this.txtMatID.Text = MPCF.Trim(this.spdCellLotList.ActiveSheet.Cells[this.spdCellLotList.ActiveSheet.ActiveRowIndex, (int)CELL_LOT_LIST.MAT_ID].Value);
                this.txtMatVer.Text = MPCF.Trim(this.spdCellLotList.ActiveSheet.Cells[this.spdCellLotList.ActiveSheet.ActiveRowIndex, (int)CELL_LOT_LIST.MAT_VER].Value);
                this.txtMatDesc.Text = MPCF.Trim(this.spdCellLotList.ActiveSheet.Cells[this.spdCellLotList.ActiveSheet.ActiveRowIndex, (int)CELL_LOT_LIST.MAT_DESC].Value);
                this.txtRawMatQty.Text = MPCF.Trim(this.spdCellLotList.ActiveSheet.Cells[this.spdCellLotList.ActiveSheet.ActiveRowIndex, (int)CELL_LOT_LIST.MAT_BOX_QTY].Value);

                d_Lot_Qty = Convert.ToDouble(this.spdCellLotList.ActiveSheet.Cells[this.spdCellLotList.ActiveSheet.ActiveRowIndex, (int)CELL_LOT_LIST.QTY].Value);

                ViewLotBatchCellList();

                this.txtBarcode.Focus();
                this.txtBarcode.SelectAll();
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition(CSGC.MP_CHECK_CREATE) == false) { return; }
                
                int lastRow = 0;
                bool bUpdate = false;

                txtBarcode.Text = MPCF.ToUpper(txtBarcode.Text); // 일괄 대문자

                // 기존에 추가한 셀박스이면 수량을 변경한다.
                for (int row = 0; row < spdCellCustCodeList.ActiveSheet.RowCount; row++)
                {
                    if (MPCF.Trim(this.spdCellCustCodeList.ActiveSheet.Cells[row, (int)CELLBOX_CUSTCODE_LIST.CUST_BARCODE].Value)
                            == MPCF.Trim(this.txtBarcode.Text))
                    {
                        // 20171013-clearlim-기본 생성 되어있는 배치에 대해서 변경 중이면
                        if (utbLotList.ActiveTab.Index == 1)
                        {
                            if (Convert.ToDouble(this.spdCellCustCodeList.ActiveSheet.Cells[row, (int)CELLBOX_CUSTCODE_LIST.QTY].Value) > Convert.ToDouble(this.txtRawMatQty.Text))
                                d_Lot_Qty = d_Lot_Qty - (Convert.ToDouble(this.spdCellCustCodeList.ActiveSheet.Cells[row, (int)CELLBOX_CUSTCODE_LIST.QTY].Value) - Convert.ToDouble(this.txtRawMatQty.Text));
                            else
                                d_Lot_Qty = d_Lot_Qty + (Convert.ToDouble(this.txtRawMatQty.Text) - Convert.ToDouble(this.spdCellCustCodeList.ActiveSheet.Cells[row, (int)CELLBOX_CUSTCODE_LIST.QTY].Value));
                        }

                        this.spdCellCustCodeList.ActiveSheet.Cells[row, (int)CELLBOX_CUSTCODE_LIST.QTY].Value = MPCF.Trim(this.txtRawMatQty.Text);

                        bUpdate = true;
                        break;
                    }
                }

                // 기존에 추가한 셀박스가 아니면 셀박스를 추가한다.
                if (bUpdate == false)
                {
                    //Row 1개 추가
                    this.spdCellCustCodeList.ActiveSheet.RowCount++;
                    lastRow = this.spdCellCustCodeList.ActiveSheet.RowCount - 1;

                    this.spdCellCustCodeList.ActiveSheet.Cells[lastRow, (int)CELLBOX_CUSTCODE_LIST.CUST_BARCODE].Value = MPCF.Trim(this.txtBarcode.Text);
                    this.spdCellCustCodeList.ActiveSheet.Cells[lastRow, (int)CELLBOX_CUSTCODE_LIST.MAT_ID].Value = MPCF.Trim(this.txtMatID.Text);
                    this.spdCellCustCodeList.ActiveSheet.Cells[lastRow, (int)CELLBOX_CUSTCODE_LIST.MAT_VER].Value = MPCF.Trim(this.txtMatVer.Text);
                    this.spdCellCustCodeList.ActiveSheet.Cells[lastRow, (int)CELLBOX_CUSTCODE_LIST.MAT_DESC].Value = MPCF.Trim(this.txtMatDesc.Text);
                    this.spdCellCustCodeList.ActiveSheet.Cells[lastRow, (int)CELLBOX_CUSTCODE_LIST.QTY].Value = MPCF.Trim(this.txtRawMatQty.Text);

                    if (utbLotList.ActiveTab.Index == 1)
                        d_Lot_Qty = d_Lot_Qty + Convert.ToDouble(this.spdCellCustCodeList.ActiveSheet.Cells[lastRow, (int)CELLBOX_CUSTCODE_LIST.QTY].Value);


                    FarPoint.Win.Spread.SortInfo[] sort = new FarPoint.Win.Spread.SortInfo[2];
                    sort[0] = new FarPoint.Win.Spread.SortInfo((int)CELLBOX_CUSTCODE_LIST.CUST_BARCODE, true);
                    sort[1] = new FarPoint.Win.Spread.SortInfo((int)CELLBOX_CUSTCODE_LIST.MAT_ID, true);

                    spdCellCustCodeList.ActiveSheet.SortRows(0, spdCellCustCodeList.ActiveSheet.RowCount, sort);
                }

                MPCF.FitColumnHeader(this.spdCellCustCodeList);

				this.spdCellCustCodeList.ActiveSheet.Columns[(int)CELLBOX_CUSTCODE_LIST.MAT_DESC].Width = 200f;

                spdCellCustCodeList.ShowRow(0, spdCellCustCodeList.ActiveSheet.RowCount - 1, FarPoint.Win.Spread.VerticalPosition.Center);

                this.lblTotalQty.Text = GetTotalQty().ToString();

                this.txtBarcode.Focus();
                this.txtBarcode.SelectAll();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtRawMatQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == '.'))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (!string.IsNullOrEmpty(txtRawMatQty.Text))
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdCellCustCodeList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            try
            {
                MPCF.FieldClear(this.grbSaveOpt);

                this.btnAdd.Enabled = false;
                this.btnRemove.Enabled = true;

                if (this.spdCellCustCodeList.ActiveSheet.RowCount < 1) { return; }

                this.txtMatID.Text = MPCF.Trim(this.spdCellCustCodeList.ActiveSheet.Cells[this.spdCellCustCodeList.ActiveSheet.ActiveRowIndex, (int)CELLBOX_CUSTCODE_LIST.MAT_ID].Value);
                this.txtMatVer.Text = MPCF.Trim(this.spdCellCustCodeList.ActiveSheet.Cells[this.spdCellCustCodeList.ActiveSheet.ActiveRowIndex, (int)CELLBOX_CUSTCODE_LIST.MAT_VER].Value);
                this.txtMatDesc.Text = MPCF.Trim(this.spdCellCustCodeList.ActiveSheet.Cells[this.spdCellCustCodeList.ActiveSheet.ActiveRowIndex, (int)CELLBOX_CUSTCODE_LIST.MAT_DESC].Value);
                this.txtRawMatQty.Text = MPCF.Trim(this.spdCellCustCodeList.ActiveSheet.Cells[this.spdCellCustCodeList.ActiveSheet.ActiveRowIndex, (int)CELLBOX_CUSTCODE_LIST.QTY].Value);
                this.txtBarcode.Text = MPCF.Trim(this.spdCellCustCodeList.ActiveSheet.Cells[this.spdCellCustCodeList.ActiveSheet.ActiveRowIndex, (int)CELLBOX_CUSTCODE_LIST.CUST_BARCODE].Value);
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.spdCellCustCodeList.ActiveSheet.RowCount < 1) { return; }

                if (MPCF.Trim(this.txtBarcode.Text) == string.Empty)
                {
                    return;
                }

                if (MPCF.ShowMsgBox(MPCF.GetMessage(372), MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                for (int r = 0; r < spdCellCustCodeList.ActiveSheet.RowCount; r++)
                {
                    if (MPCF.Trim(this.txtBarcode.Text) == MPCF.Trim(this.spdCellCustCodeList.ActiveSheet.Cells[r, (int)CELLBOX_CUSTCODE_LIST.CUST_BARCODE].Value))
                    {
                        if (utbLotList.ActiveTab.Index == 1)
                            d_Lot_Qty = d_Lot_Qty - Convert.ToDouble(this.spdCellCustCodeList.ActiveSheet.Cells[r, (int)CELLBOX_CUSTCODE_LIST.QTY].Value);

                        spdCellCustCodeList.ActiveSheet.RemoveRows(r, 1);

                        break;
                    }
                }

                MPCF.FieldClear(this.grbSaveOpt);

                this.lblTotalQty.Text = GetTotalQty().ToString();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER)
                {
                    txtBarcode.Text = MPCF.ToUpper(txtBarcode.Text); // 일괄 대문자

                    if (MPCF.Trim(txtBarcode.Text) == "") { return; }

                    if (this.btnAdd.Enabled == true)
                    {
                        this.btnAdd.PerformClick();
                    }                    
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition(CSGC.MP_CHECK_UPDATE) == false) { return; }

                if (UpdateBatchCell() == true)
                {
                    this.ViewRawMatList();

                    this.ViewCellLotList();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
            }
        }

        private void utbLotList_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            try
            {
                //if (utbLotList.ActiveTab.Index == 0)
                {
                    MPCF.FieldClear(this.grbSaveOpt);
                    spdCellCustCodeList.ActiveSheet.RowCount = 0;

                    lblTotalQty.Text = GetTotalQty().ToString();

                    d_Lot_Qty = 0;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);                
            }
        }

        #endregion

        private void btnRawInstall_Click(object sender, EventArgs e)
        {
            try
            {
                //자재장착관리 화면
                BICF.OpenMenu("SOI3003");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            } 
        }

        private void cdvResID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$OPER";
                dvcArgu[1].sCondition_Value = "1320";

                // CodeView Column Header Setup
                string[] header = new string[] { "Code", "Code Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                // Show
                cdvResID.Text = cdvResID.Show(cdvResID, "Code Desc", "VIEW_INSTALL_RES_LIST", dvcArgu, display, header, "RES_ID", -1);

                if (MPCF.Trim(cdvResID.Text) != "")
                {
                    if (cdvResID.returnDatas != null && cdvResID.returnDatas.Count > 0)
                    {
                        cdvResID.Tag = cdvResID.returnDatas[0];
                        cdvResID.Text = cdvResID.returnDatas[0];
                    }
                }
                else
                {
                    cdvResID.Tag = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
    }
}
