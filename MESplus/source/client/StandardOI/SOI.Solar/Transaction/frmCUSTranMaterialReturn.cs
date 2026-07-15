//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmCUSTranMaterialReturn.cs
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
//       - 2017-07-19 : Created by Sanghun Mo  
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
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using SOI.DNM;

namespace SOI.Solar
{
    public partial class frmCUSTranMaterialReturn : SOIBaseForm03
    {
        public frmCUSTranMaterialReturn()
        {
            InitializeComponent();
        }

        #region [Constant Definition]

        #endregion

        #region [Variable Definition]

        const int ENTER = 13;

        private bool bIsShown = false;

        private enum RETURN_MAT_LIST : int
        {
            CHK = 0,
            MAT_ID,
            MAT_VER,
            MAT_DESC,
            LOT_ID,
            OPER,
            QTY,
            RETURN_QTY
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
                MPCF.ClearList(spdList, true);
                MPCF.FitColumnHeader(spdList);

                this.cdvFromOper.Text = CSGC.MP_TIV_INV_WIPOPR;
                this.cdvFromOper.Enabled = false;
                this.cdvToOper.Text = CSGC.MP_TIV_INV_OPR;
                this.cdvToOper.Enabled = false;

                this.btnPrintOption.Visible = false;
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
                        break;

                    case CSGC.MP_CHECK_UPDATE:
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

        private bool ViewTransferOrderList()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            MPCF.ClearList(this.spdList);

            try
            {
                // 20171015-clearlim-Lot ID 추가
                //sViewID = "VIEW_OPER_LOT_LIST";
                sViewID = "VIEW_OPER_LOT";
                i_cond_cnt = 4;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$OPER";
                ArrDVC[1].sCondition_Value = MPCF.Trim(CSGC.MP_TIV_INV_WIPOPR);

                ArrDVC[2].sCondtion_ID = "$MAT_ID";
                ArrDVC[2].sCondition_Value = MPCF.Trim(this.cdvMaterial.Text);

                ArrDVC[3].sCondtion_ID = "$LOT_ID";
                ArrDVC[3].sCondition_Value = MPCF.Trim(this.txtLotID.Text);

                if (TPDR.DirectViewOne(this.spdList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                if (spdList.ActiveSheet.RowCount > 0)
                {
                    for (int c = 0; c < spdList.ActiveSheet.ColumnCount; c++)
                    {
                        spdList.ActiveSheet.Columns[c].Locked = true;
                    }
                    spdList.ActiveSheet.Columns[(int)RETURN_MAT_LIST.CHK].Locked = false;
                    spdList.ActiveSheet.Columns[(int)RETURN_MAT_LIST.RETURN_QTY].Locked = false;

                    spdList.ActiveSheet.Columns[(int)RETURN_MAT_LIST.MAT_DESC].Width = 200;

                    FarPoint.Win.Spread.CellType.CheckBoxCellType ckbxcell = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                    spdList.ActiveSheet.Columns[(int)RETURN_MAT_LIST.CHK].CellType = ckbxcell;
                    spdList.ActiveSheet.Columns[(int)RETURN_MAT_LIST.CHK].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    spdList.ActiveSheet.Columns[(int)RETURN_MAT_LIST.CHK].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

                    for (int r = 0; r < spdList.ActiveSheet.RowCount; r++)
                    {
                        if (MPCF.Trim(spdList.ActiveSheet.Cells[r, (int)RETURN_MAT_LIST.QTY].Value.ToString()) == string.Empty
                            || MPCF.Trim(spdList.ActiveSheet.Cells[r, (int)RETURN_MAT_LIST.QTY].Value.ToString()) == "0")
                        {
                            spdList.ActiveSheet.Cells[r, (int)RETURN_MAT_LIST.CHK].Locked = true;
                        }
                    }

                }

                MPCF.FitColumnHeader(spdList);

                spdList.ActiveSheet.Columns[(int)RETURN_MAT_LIST.MAT_VER].Visible = false;
                spdList.ActiveSheet.Columns[(int)RETURN_MAT_LIST.MAT_DESC].Width = 200;
                spdList.ActiveSheet.Columns[(int)RETURN_MAT_LIST.RETURN_QTY].BackColor = Color.LightGreen;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool SaveTransfer()
        {
            bool chkFlag = true;

            try
            {
                string sTransOrderID = string.Empty;
                TRSNode in_node = new TRSNode("TRANSFER_IN");
                TRSNode out_node = new TRSNode("TRANSFER_OUT");
                TRSNode Transfer_List;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_CREATE;

                for (int r = 0; r < this.spdList.ActiveSheet.RowCount; r++)
                {
                    //선택여부 확인하여 Trans Order ID 가져오기
                    if (Convert.ToBoolean(spdList.ActiveSheet.Cells[r, (int)RETURN_MAT_LIST.CHK].Value) == true)
                    {
                        chkFlag = false;
                        Transfer_List = in_node.AddNode("TRANSFER_LIST");
                        Transfer_List.AddString("LOT_ID", spdList.ActiveSheet.Cells[r, (int)RETURN_MAT_LIST.LOT_ID].Value.ToString());
                        Transfer_List.AddString("MAT_ID", spdList.ActiveSheet.Cells[r, (int)RETURN_MAT_LIST.MAT_ID].Value.ToString());
                        Transfer_List.AddInt("MAT_VER", Convert.ToInt32(spdList.ActiveSheet.Cells[r, (int)RETURN_MAT_LIST.MAT_VER].Value.ToString()));
                        Transfer_List.AddString("FROM_OPER", MPCF.Trim(this.cdvFromOper.Text));     //W210  
                        Transfer_List.AddString("TO_OPER", MPCF.Trim(this.cdvToOper.Text));        //W110                        
                        Transfer_List.AddDouble("TRANS_QTY", Convert.ToDouble(spdList.ActiveSheet.Cells[r, (int)RETURN_MAT_LIST.RETURN_QTY].Value.ToString()));
                    }
                }

                //Chk Item Validation
                if (chkFlag)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    return false;
                }

                if (CMNF.ShowMsgBox(CMNF.GetMessage(377), MessageBoxButtons.YesNo, SOI.CliFrx.MSG_LEVEL.INFO) != System.Windows.Forms.DialogResult.Yes)
                {
                    return false;
                }

                if (MPCF.CallService("CUS", "CTIV_Update_Return", in_node, ref out_node) == false)
                {
                    return false;
                }

                CMNF.ShowSuccessMessage(out_node, true);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        #region [Event Definition]

        private void frmCUSTranMaterialReturn_Load(object sender, EventArgs e)
        {
            initCtrl();
        }

        private void frmCUSTranMaterialReturn_Activated(object sender, EventArgs e)
        {

        }

        private void frmCUSTranMaterialReturn_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                //ViewTransferOrderList();

                // (Required) 
                bIsShown = true;
            }
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
                sViewID = "VIEW_OPER_MAT_LIST";
                i_cond_cnt = 3;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$OPER";
                ArrDVC[1].sCondition_Value = MPCF.Trim(CSGC.MP_TIV_INV_WIPOPR);

                ArrDVC[2].sCondtion_ID = "$MAT_ID";
                ArrDVC[2].sCondition_Value = MPCF.Trim(this.cdvMaterial.Text);

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

                this.txtLotID.Text = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(this.spdList);

            //조회 조건 확인
            if (CheckCondition(CSGC.MP_CHECK_VIEW) == false) { return; }

            ViewTransferOrderList();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (this.spdList.ActiveSheet.RowCount < 1) { return; }

            SaveTransfer();
            ViewTransferOrderList();

            this.txtLotID.Focus();
            this.txtLotID.SelectAll();
        }

        private void spdList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (e.ColumnHeader == true && e.Column == (int)RETURN_MAT_LIST.CHK)
                {
                    if (spdList.ActiveSheet.RowCount < 1) { return; }

                    bool allChecked = (spdList.Tag == null || spdList.Tag.ToString() == "0")
                                        ? false
                                        : true;
                    if (allChecked == true) { spdList.Tag = "0"; }
                    else { spdList.Tag = "1"; }
                                    
                    for (int r = 0; r < spdList.ActiveSheet.RowCount; r++)
                    {
                        if (spdList.ActiveSheet.Cells[r, (int)RETURN_MAT_LIST.CHK].Locked == true)
                        {
                            continue;
                        }

                        spdList.ActiveSheet.Cells[r, (int)RETURN_MAT_LIST.CHK].Value = allChecked;
                    }
                }

                if (e.ColumnHeader == true
                    && (e.Column == (int)RETURN_MAT_LIST.MAT_DESC || e.Column == (int)RETURN_MAT_LIST.MAT_DESC))
                {
                    if (spdList.ActiveSheet.RowCount < 1) { return; }

                    if (spdList.ActiveSheet.Columns[(int)RETURN_MAT_LIST.MAT_DESC].Width == 200)
                    {
                        MPCF.FitColumnHeader(spdList);
                    }
                    else
                    {
                        spdList.ActiveSheet.Columns[(int)RETURN_MAT_LIST.MAT_DESC].Width = 200;                        
                    }
                }
                
                if (e.ColumnHeader == true && e.Column == (int)RETURN_MAT_LIST.RETURN_QTY)
                {
                    if (spdList.ActiveSheet.RowCount < 1) { return; }

                    double Qty = 0.0d;
                                        
                    for (int r = 0; r < spdList.ActiveSheet.RowCount; r++)
                    {
                        if (spdList.ActiveSheet.Cells[r, (int)RETURN_MAT_LIST.CHK].Locked == true)
                        {
                            continue;
                        }

                        Double.TryParse(spdList.ActiveSheet.Cells[r, (int)RETURN_MAT_LIST.QTY].Value.ToString(), out Qty);

                        spdList.ActiveSheet.Cells[r, (int)RETURN_MAT_LIST.CHK].Value = true;
                        spdList.ActiveSheet.Cells[r, (int)RETURN_MAT_LIST.RETURN_QTY].Value = Qty;

                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdList_EditModeOff(object sender, EventArgs e)
        {
            try
            {
                if (spdList.ActiveSheet.ActiveColumnIndex == (int)RETURN_MAT_LIST.RETURN_QTY)
                {
                    if (spdList.ActiveSheet.RowCount < 1) { return; }

                    spdList.ActiveSheet.SetValue(spdList.ActiveSheet.ActiveRowIndex, (int)RETURN_MAT_LIST.CHK, true);

                    if (string.IsNullOrEmpty(Convert.ToString(spdList.ActiveSheet.Cells[spdList.ActiveSheet.ActiveRowIndex, (int)RETURN_MAT_LIST.RETURN_QTY].Value)))
                    {
                        spdList.ActiveSheet.Cells[spdList.ActiveSheet.ActiveRowIndex, (int)RETURN_MAT_LIST.RETURN_QTY].Value = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvFromOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Code View Service
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(CSGC.MP_GCM_TBL_INV_OPER));
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Oper", "Oper Desc" };
                cdvFromOper.Text = cdvFromOper.Show(cdvFromOper, "View Oper", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Oper");

                // Validation
                if (string.IsNullOrEmpty(cdvFromOper.Text) == true)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvToOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Code View Service
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(CSGC.MP_GCM_TBL_INV_OPER));
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Oper", "Oper Desc" };
                cdvToOper.Text = cdvToOper.Show(cdvToOper, "View Oper", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Oper");

                // Validation
                if (string.IsNullOrEmpty(cdvToOper.Text) == true)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER && MPCF.Trim(txtLotID.Text) != "")
                {
                    txtLotID.Text = MPCF.ToUpper(txtLotID.Text); // 일괄 대문자

                    MPCF.ClearList(this.spdList);

                    //조회 조건 확인
                    if (CheckCondition(CSGC.MP_CHECK_VIEW) == false) { return; }

                    ViewTransferOrderList();

                    this.txtLotID.Focus();
                    this.txtLotID.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        #endregion

    }
}
