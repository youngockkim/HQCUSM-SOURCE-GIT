//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmCUSTranMaterialTransfer.cs
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
    public partial class frmCUSTranMaterialTransfer : SOIBaseForm03
    {
        #region [Property]

        DataTable dtMaterial; // 기준수량 저장

        #endregion

        public frmCUSTranMaterialTransfer()
        {
            InitializeComponent();
        }

        #region [Constant Definition]

        #endregion

        #region [Variable Definition]

        private bool bIsShown = false;
        private bool b_sel_qtysetup = false;

        private enum TRANS_ORDER_LIST : int
        {
            TRANS_ORDER_DATE = 0,
            CHK,
            TRANS_ORDER_ID,            
            TRANS_ORD_END_FLAG,
            ORDER_ID,
            MAT_ID,
            MAT_VER,
            MAT_DESC,
            ORDER_DESC,
            TRANS_ORDER_QTY,
            PRE_TRANS_QTY,
            RAW_MAT_QTY,
            TRANS_QTY
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
                this.dtpFrom.Value = DateTime.Now.AddDays(-1);
                this.dtpTo.Value = DateTime.Now;

                MPCF.ClearList(spdList, true);
                MPCF.FitColumnHeader(spdList);

                this.cdvFromOper.Text = CSGC.MP_TIV_INV_OPR;
                this.cdvFromOper.Enabled = false;
                this.cdvToOper.Text = CSGC.MP_TIV_INV_WIPOPR;
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

                        DateTime dtpFromOut = new DateTime();

                        if (dtpFrom.Value != null)
                        {
                            if (DateTime.TryParse(dtpFrom.Value.ToString(), out dtpFromOut)) {}
                        }

                        DateTime dtpToOut = new DateTime();

                        if (dtpTo.Value != null)
                        {
                            if (DateTime.TryParse(dtpTo.Value.ToString(), out dtpToOut)) {}
                        }

                        if (this.dtpFrom.GetValueAsDateTime() > this.dtpTo.GetValueAsDateTime())
                        {
                            this.dtpFrom.SetValueAsDateTime(dtpToOut.AddDays(-1));
                            MPCF.ShowMsgBox(MPCF.GetMessage(371));
                        }

                        break;

                    case CSGC.MP_CHECK_CREATE:

                        if (this.spdList.ActiveSheet.RowCount < 1) { return false; }

                        bool overFlag = false;

                        // 불출수량 > 창고자재수량 이면 작업 종료
                        for (int r = 0; r < spdList.ActiveSheet.RowCount; r++)
                        {
                            double transQty = 0.0d;
                            transQty = double.Parse(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_QTY].Value.ToString());

                            if (transQty != 0)
                            {
                                double rawMatQty = 0.0d;
                                rawMatQty = double.Parse(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.RAW_MAT_QTY].Value.ToString());

                                if (transQty > rawMatQty)
                                    overFlag = true;
                            }
                        }

                        if (overFlag)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(454));
                            return false;
                        }

                        // 불출수량 + 기존이동수량 > 불출지시수량 이면 알림 메세지 띄움
                        for (int r = 0; r < spdList.ActiveSheet.RowCount; r++)
                        {
                            double transQty = 0.0d;
                            transQty = double.Parse(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_QTY].Value.ToString());

                            if (transQty != 0)
                            {
                                double transOrderQty = 0.0d;
                                double preTransQty = 0.0d;

                                transOrderQty = double.Parse(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_ORDER_QTY].Value.ToString());
                                preTransQty = double.Parse(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.PRE_TRANS_QTY].Value.ToString());

                                if (transOrderQty < preTransQty + transQty)
                                    overFlag = true;
                            }
                        }

                        if (overFlag)
                            MPCF.ShowMsgBox(MPCF.GetMessage(417));

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
                sViewID = "VIEW_TRANSFER_ORDER_LIST";
                i_cond_cnt = 6;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$FROM_DATE";
                ArrDVC[1].sCondition_Value = MPCF.Trim(this.dtpFrom.GetValueAsString(8));

                ArrDVC[2].sCondtion_ID = "$TO_DATE";
                ArrDVC[2].sCondition_Value = MPCF.Trim(this.dtpTo.GetValueAsString(8));

                ArrDVC[3].sCondtion_ID = "$LINE_ID";
                ArrDVC[3].sCondition_Value = MPCF.Trim(this.cdvLine.Text);

                ArrDVC[4].sCondtion_ID = "$MAT_ID";
                ArrDVC[4].sCondition_Value = MPCF.Trim(this.cdvMaterial.Text);

                ArrDVC[5].sCondtion_ID = "$OPER";
                ArrDVC[5].sCondition_Value = MPCF.Trim(this.cdvFromOper.Text);

                if (TPDR.DirectViewOne(this.spdList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                dtMaterial = dt; // 기준수량 조회조건

                if (spdList.ActiveSheet.RowCount > 0)
                {
                    for (int c = 0; c < spdList.ActiveSheet.ColumnCount; c++)
                    {
                        spdList.ActiveSheet.Columns[c].Locked = true;
                    }
                    spdList.ActiveSheet.Columns[(int)TRANS_ORDER_LIST.CHK].Locked = false;
                    spdList.ActiveSheet.Columns[(int)TRANS_ORDER_LIST.TRANS_QTY].Locked = false;
                    spdList.ActiveSheet.Columns[(int)TRANS_ORDER_LIST.MAT_VER].Visible = false;

                    FarPoint.Win.Spread.CellType.CheckBoxCellType ckbxcell = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                    spdList.ActiveSheet.Columns[(int)TRANS_ORDER_LIST.CHK].CellType = ckbxcell;
                    spdList.ActiveSheet.Columns[(int)TRANS_ORDER_LIST.CHK].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    spdList.ActiveSheet.Columns[(int)TRANS_ORDER_LIST.CHK].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;                   
                    spdList.ActiveSheet.Columns[(int)TRANS_ORDER_LIST.TRANS_ORDER_ID].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;

                    string sTransOrderID = string.Empty;
                    int iSpanCnt = 0;

                    for (int r = 0; r < spdList.ActiveSheet.RowCount; r++)
                    {
                        if (sTransOrderID != MPCF.Trim(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_ORDER_ID].Text))
                        {
                            iSpanCnt = 1;
                            sTransOrderID = MPCF.Trim(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_ORDER_ID].Text);
                        }
                        else
                        {
                            iSpanCnt++;
                        }

                        spdList.ActiveSheet.Cells[(r - (iSpanCnt - 1)), (int)TRANS_ORDER_LIST.CHK].RowSpan = iSpanCnt;
                        spdList.ActiveSheet.Cells[(r - (iSpanCnt - 1)), (int)TRANS_ORDER_LIST.TRANS_ORDER_DATE].RowSpan = iSpanCnt;
                        spdList.ActiveSheet.Cells[(r - (iSpanCnt - 1)), (int)TRANS_ORDER_LIST.TRANS_ORD_END_FLAG].RowSpan = iSpanCnt;

                        if (MPCF.Trim(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_ORD_END_FLAG].Value.ToString()) != string.Empty)
                        {
                            spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.CHK].Locked = true;
                        }

                        if (!chkComplete.Checked)
                        {
                            if (double.Parse(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_ORDER_QTY].Value.ToString()) <= double.Parse(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.PRE_TRANS_QTY].Value.ToString()))
                                spdList.ActiveSheet.Rows[r].Visible = false;
                        }
                    }
                }

                MPCF.FitColumnHeader(spdList);

                spdList.ActiveSheet.Columns[(int)TRANS_ORDER_LIST.ORDER_DESC].Width = 200;
                spdList.ActiveSheet.Columns[(int)TRANS_ORDER_LIST.MAT_DESC].Width = 200;
                spdList.ActiveSheet.Columns[(int)TRANS_ORDER_LIST.MAT_VER].Visible = false;
                spdList.ActiveSheet.Columns[(int)TRANS_ORDER_LIST.ORDER_DESC].Visible = false;
                spdList.ActiveSheet.Columns[(int)TRANS_ORDER_LIST.MAT_VER].Visible = false;
                spdList.ActiveSheet.Columns[(int)TRANS_ORDER_LIST.TRANS_QTY].BackColor = Color.LightGreen;

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
                    if (Convert.ToBoolean(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.CHK].Value) == true)
                    {
                        chkFlag = false;
                        sTransOrderID = MPCF.Trim(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_ORDER_ID].Value.ToString());
                    }

                    //선택한 Trans Order ID와 같으면 실행
                    if (sTransOrderID == MPCF.Trim(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_ORDER_ID].Value.ToString()))
                    {
                        if (Convert.ToDouble(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_QTY].Value.ToString()) <= 0) { continue; }

                        Transfer_List = in_node.AddNode("TRANSFER_LIST");
                        Transfer_List.AddString("TRANS_ORDER_ID", spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_ORDER_ID].Value.ToString().Replace("-", ""));
                        Transfer_List.AddString("MAT_ID", spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.MAT_ID].Value.ToString());
                        Transfer_List.AddInt("MAT_VER", Convert.ToInt32(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.MAT_VER].Value.ToString()));
                        Transfer_List.AddString("FROM_OPER", MPCF.Trim(this.cdvFromOper.Text));  //W110
                        Transfer_List.AddString("TO_OPER", MPCF.Trim(this.cdvToOper.Text));     //W210
                        Transfer_List.AddString("ORDER_ID", spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.ORDER_ID].Value.ToString());
                        Transfer_List.AddDouble("TRANS_QTY", Convert.ToDouble(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_QTY].Value.ToString()));
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

                if (MPCF.CallService("CUS", "CTIV_Update_Transfer", in_node, ref out_node) == false)
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

        private DataTable GetMaterialList()
        {
            List<string> matList = new List<string>();

            try
            {
                DataRow[] drs = dtMaterial.DefaultView.ToTable(true, new string[] { "MAT_ID" }).Select();

                foreach (DataRow dr in drs)
                    matList.Add(dr["MAT_ID"].ToString());

                return GetMatDefQty(string.Format("('{0}')", string.Join("','", matList.ToArray())));
            }
            catch (Exception)
            {
                throw;
            }
        }

        private DataTable GetMatDefQty(string strMatList)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

            try
            {
                sViewID = "VIEW_MAT_DEF_QTY";
                i_cond_cnt = 2;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$MAT_ID";
                ArrDVC[1].sCondition_Value = strMatList;

                if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return dt;
                }

                return dt;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return dt;
            }
        }

        #endregion

        #region [Event Definition]

        private void frmCUSTranMaterialTransfer_Load(object sender, EventArgs e)
        {
            initCtrl();
        }

        private void frmCUSTranMaterialTransfer_Activated(object sender, EventArgs e)
        {

        }

        private void frmCUSTranMaterialTransfer_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                ViewTransferOrderList();

                // (Required) 
                bIsShown = true;
            }
        }

        private void cdvLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Code View Service
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(MPGC.MP_RAS_AREA_CODE));
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Line", "Line Desc" };
                cdvLine.Text = cdvLine.Show(cdvLine, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Line");

                // Validation
                if (string.IsNullOrEmpty(cdvLine.Text) == true)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
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
                sViewID = "VIEW_WORK_ORDER_MAT_LIST";
                i_cond_cnt = 2;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$MAT_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(this.cdvMaterial.Text);

                // CodeView Column Header Setup
                string[] header = new string[] { "Material ID", "Material Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "MAT_ID", "MAT_DESC" };

                // Show by RPTServer
                cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "Material List", "VIEW_WORK_ORDER_MAT_LIST", ArrDVC, display, header, "MAT_ID", -1);

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

        private void btnView_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(this.spdList);

            //조회 조건 확인
            if (CheckCondition(CSGC.MP_CHECK_VIEW) == false) { return; }

            ViewTransferOrderList();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (!CheckCondition(CSGC.MP_CHECK_CREATE))
                return;

            SaveTransfer();
            ViewTransferOrderList();
        }

        private void spdList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (e.ColumnHeader == true && e.Column == (int)TRANS_ORDER_LIST.CHK)
                {
                    if (spdList.ActiveSheet.RowCount < 1) { return; }

                    bool allChecked = (spdList.Tag == null || spdList.Tag.ToString() == "0")
                                        ? false
                                        : true;
                    if (allChecked == true) { spdList.Tag = "0"; }
                    else { spdList.Tag = "1"; }

                    string sTransOrderID = string.Empty;                    
                    for (int r = 0; r < spdList.ActiveSheet.RowCount; r++)
                    {
                        if (sTransOrderID != MPCF.Trim(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_ORDER_ID].Text))
                        {
                            if (spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.CHK].Locked == true)
                            {
                                continue;
                            }

                            spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.CHK].Value = allChecked;

                            sTransOrderID = MPCF.Trim(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_ORDER_ID].Text);
                        }
                    }
                }

                if (e.ColumnHeader == true
                    && (e.Column == (int)TRANS_ORDER_LIST.MAT_DESC || e.Column == (int)TRANS_ORDER_LIST.ORDER_DESC))
                {
                    if (spdList.ActiveSheet.RowCount < 1) { return; }

                    if (spdList.ActiveSheet.Columns[(int)TRANS_ORDER_LIST.MAT_DESC].Width == 200)
                    {
                        MPCF.FitColumnHeader(spdList);
                    }
                    else
                    {
                        spdList.ActiveSheet.Columns[(int)TRANS_ORDER_LIST.MAT_DESC].Width = 200;
                        spdList.ActiveSheet.Columns[(int)TRANS_ORDER_LIST.ORDER_DESC].Width = 200;
                    }
                }


                //if (e.ColumnHeader == true && e.Column == (int)TRANS_ORDER_LIST.TRANS_QTY)
                //{
                //    if (spdList.ActiveSheet.RowCount < 1) { return; }

                //    double ordQty = 0.0d;
                //    double tranQty = 0.0d;
                //    double tranOrdQty = 0.0d;

                //    string sTransOrderID = string.Empty;
                //    for (int r = 0; r < spdList.ActiveSheet.RowCount; r++)
                //    {
                //        if (spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.CHK].Locked == true)
                //        {
                //            continue;
                //        }

                //        Double.TryParse(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_ORDER_QTY].Value.ToString(), out ordQty);
                //        Double.TryParse(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.PRE_TRANS_QTY].Value.ToString(), out tranQty);
                //        tranOrdQty = ordQty - tranQty;
                //        if (tranOrdQty < 0) { tranOrdQty = 0; }

                //        spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_QTY].Value = tranOrdQty;

                //        if (sTransOrderID != MPCF.Trim(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_ORDER_ID].Text))
                //        {
                //            spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.CHK].Value = true;
                //            sTransOrderID = MPCF.Trim(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_ORDER_ID].Text);
                //        }
                //    }
                //}
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
                if (spdList.ActiveSheet.ActiveColumnIndex == (int)TRANS_ORDER_LIST.TRANS_QTY)
                {
                    if (spdList.ActiveSheet.RowCount < 1) { return; }

                    spdList.ActiveSheet.SetValue(spdList.ActiveSheet.ActiveRowIndex, (int)TRANS_ORDER_LIST.CHK, true);

                    if (string.IsNullOrEmpty(Convert.ToString(spdList.ActiveSheet.Cells[spdList.ActiveSheet.ActiveRowIndex, (int)TRANS_ORDER_LIST.TRANS_QTY].Value)))
                    {
                        spdList.ActiveSheet.Cells[spdList.ActiveSheet.ActiveRowIndex, (int)TRANS_ORDER_LIST.TRANS_QTY].Value = 0;
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

        private void btnQtySetUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (spdList.ActiveSheet.RowCount < 1) { return; }

                DataTable dtQty = new DataTable();

                double ordQty = 0.0f;
                double tranQty = 0.0f;
                double tranOrdQty = 0.0f;
                double modQty = 0.0f;
                double divisionQty = 0.0f;
                double defQty = 0.0f;

                if (b_sel_qtysetup == false)
                {
                    string sTransOrderID = string.Empty;

                    dtQty = GetMaterialList();

                    for (int r = 0; r < spdList.ActiveSheet.RowCount; r++)
                    {
                        if (spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.CHK].Locked == true)
                            continue;

                        if (spdList.ActiveSheet.Rows[r].Visible == false)
                            continue;

                        DataRow dr = dtQty.Select(string.Format("MAT_ID='{0}' AND MAT_VER='{1}'", spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.MAT_ID].Value.ToString(), spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.MAT_VER].Value.ToString()))[0];
                        Double.TryParse(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_ORDER_QTY].Value.ToString(), out ordQty);
                        Double.TryParse(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.PRE_TRANS_QTY].Value.ToString(), out tranQty);

                        tranOrdQty = ordQty - tranQty;
                        if (tranOrdQty < 0) { tranOrdQty = 0; }

                        defQty = double.Parse(dr["DEF_QTY_2"].ToString());
                        modQty = tranOrdQty % defQty; // 나머지 값
                        divisionQty = tranOrdQty / defQty; // 나누기 값

                        if (divisionQty < 1 || tranOrdQty <= 0 || defQty == 0) // 배수에 해당되지 않는 수량, 나누기 값이 0일 때, 과출고 일 때, 
                        {
                            if (ordQty <= tranQty)
                            {
                                spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_QTY].Value = 0;
                            }
                            else
                            {
                                spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_QTY].Value = defQty;
                            }
                        }
                        else // 배수에 해당되는 수량
                        {
                            if (modQty > 0) // 배수이며 나머지 존재 시, 배수 + 1
                            {
                                spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_QTY].Value = ((int)divisionQty + 1) * defQty;
                            }
                            else // 배수에만 해당 시
                            {
                                spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_QTY].Value = (int)divisionQty * defQty;
                            }
                        }

                        if (sTransOrderID != MPCF.Trim(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_ORDER_ID].Text))
                        {
                            spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.CHK].Value = true;
                            sTransOrderID = MPCF.Trim(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_ORDER_ID].Text);
                        }
                    }

                    b_sel_qtysetup = true;
                }
                else
                {
                    string sTransOrderID = string.Empty;
                    for (int r = 0; r < spdList.ActiveSheet.RowCount; r++)
                    {
                        if (spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.CHK].Locked == true)
                        {
                            continue;
                        }

                        spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_QTY].Value = tranOrdQty;

                        if (sTransOrderID != MPCF.Trim(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_ORDER_ID].Text))
                        {
                            spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.CHK].Value = false;
                            sTransOrderID = MPCF.Trim(spdList.ActiveSheet.Cells[r, (int)TRANS_ORDER_LIST.TRANS_ORDER_ID].Text);
                        }
                    }

                    b_sel_qtysetup = false;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void chkComplete_CheckedChanged(object sender, EventArgs e)
        {
            btnView.PerformClick();
        }

        #endregion
    }
}
