//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmCUSTranSpecifyWorkOrderList.cs
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
    public partial class frmCUSTranSpecifyWorkOrderList : SOIBaseForm03
    {
        public frmCUSTranSpecifyWorkOrderList()
        {
            InitializeComponent();
        }

        #region [Constant Definition]

        #endregion

        #region [Variable Definition]

        private enum TRANS_ORDER_LIST : int
        {
            TRANS_ORDER_DATE = 0,
            CHK,
            TRANS_ORDER_ID,            
            MAT_ID,
            MAT_VER,
            MAT_DESC,
            ORDER_ID,
            ORDER_DESC,
            TRANS_ORDER_QTY,
            PRE_TRANS_QTY,
            TRANS_QTY
        }

        private enum ORDER_LIST : int
        {
            ORDER_ID = 0,
            WORK_START_DATE,
            WORK_END_DATE,
            ORDER_DESC,
            PLAN_ID,
            MAT_ID,
            MAT_VER,
            BOM_SET_ID,
            BOM_TYPE,
            BOM_SET_VERSION,
            AREA_ID,
            SHIFT,
            ORD_QTY,
            ORD_END_FLAG,
            ORD_END_TIME,
            CREATE_USER_ID,
            CREATE_TIME,
            UPDATE_USER_ID,
            UPDATE_TIME
        }

        #endregion

        #region [FormDefinition]

        private void initCtrl()
        {
            try
            {
                //Label Color
                lblOrderID.Appearance.ForeColor = Color.FromArgb(43, 127, 189);

                //reg 등록값으로 고정값 사용
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "txtCurLine", "01");
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "txtCurResID", "JIG01");

                //reg의 값으로 세팅하기
                this.txtCurLine.Text = MPCF.GetRegSetting(Application.ProductName, this.Name, "txtCurLine", "");
                this.txtCurResID.Text = MPCF.GetRegSetting(Application.ProductName, this.Name, "txtCurResID", "");

                // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
                MPCF.ConvertCaption(this);

                MPCF.FieldClear(this);                
                this.dtpFrom.Value = DateTime.Now.AddDays(-1);
                this.dtpTo.Value = DateTime.Now;

                MPCF.ClearList(spdOrderList, true);
                MPCF.FitColumnHeader(spdOrderList);                

                this.btnPrintOption.Visible = false;

                //Current Work Order Information View
                ViewCurrentWorkOrder();
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
                            if (DateTime.TryParse(dtpFrom.Value.ToString(), out dtpFromOut) == true)
                            {
                                //dtpFrom.SetValueAsString(dtpFromOut.ToString("yyyy-MM-dd"));                                
                            }
                        }

                        DateTime dtpToOut = new DateTime();
                        if (dtpTo.Value != null)
                        {
                            if (DateTime.TryParse(dtpTo.Value.ToString(), out dtpToOut) == true)
                            {
                                //dtpTo.SetValueAsString(dtpToOut.ToString("yyyy-MM-dd"));         
                            }
                        }

                        //from 값은 to값보다 작게 한다.
                        if (this.dtpFrom.GetValueAsDateTime() > this.dtpTo.GetValueAsDateTime())
                        {
                            this.dtpFrom.SetValueAsDateTime(dtpToOut.AddDays(-1));
                            MPCF.ShowMsgBox(MPCF.GetMessage(371));
                        }

                        break;

                    case CSGC.MP_CHECK_UPDATE:
                        if (spdOrderList.ActiveSheet.DataSource == null) return false;
                        if (MPCF.ToChar(spdOrderList.Sheets[0].Cells[spdOrderList.ActiveSheet.ActiveRowIndex, (int)ORDER_LIST.ORD_END_FLAG].Value) == 'Y')
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(369));
                            return false;
                        }
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

        private void ViewOrderList()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            MPCF.ClearList(this.spdOrderList);

            try
            {
                sViewID = "VIEW_WORK_ORDER_LIST_03";

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

                ArrDVC[5].sCondtion_ID = "$SHIFT";
                ArrDVC[5].sCondition_Value = MPCF.Trim(this.cdvShift.Text);

                if (TPDR.DirectViewOne(this.spdOrderList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return;
                }

                MPCF.FitColumnHeader(spdOrderList);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void ViewBomList()
        {
            int iRow;
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            MPCF.ClearList(spdBomList);

            iRow = spdOrderList.ActiveSheet.ActiveRowIndex;
            if (iRow < 0) return;

            try
            {
                sViewID = "VIEW_BOM_LIST_BY_ORDER";

                i_cond_cnt = 2;
                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];

                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$ORDER_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(spdOrderList.ActiveSheet.Cells[iRow, (int)ORDER_LIST.ORDER_ID].Value);

                if (TPDR.DirectViewOne(this.spdBomList, sViewID, ref dt, ArrDVC) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return;
                }
                MPCF.FitColumnHeader(spdBomList);

                return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void ViewCurrentWorkOrder()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            try
            {
                sViewID = "VIEW_WORK_ORDER_LIST_04";

                i_cond_cnt = 2;
                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];

                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$RES_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(txtCurResID.Text);

                if (TPDR.DirectViewOne(txtOrderID, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return;
                }

                txtOrderID.Text = dt.Rows[0]["ORDER_ID"].ToString();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private bool UpdateWorkOrderHistory(char ProcStep)
        {
            string sOrderValue = string.Empty;

            TRSNode in_node = new TRSNode("UPDATE_DATA_LIST_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_CREATE;
                in_node.AddString("TABLE_NAME", CSGC.MP_GCM_TBL_CUR_WORK_ORDER);

                if (this.spdOrderList.ActiveSheet.Cells[this.spdOrderList.ActiveSheet.ActiveRowIndex, 0].Value == null) return false;

                sOrderValue = spdOrderList.ActiveSheet.Cells[spdOrderList.ActiveSheet.ActiveRowIndex, (int)ORDER_LIST.ORDER_ID].Value.ToString();

                DialogResult dr = MPCF.ShowMsgBox(string.Format(MPCF.GetMessage(386), txtCurResID.Text, sOrderValue), MessageBoxButtons.OKCancel, SOI.CliFrx.MSG_LEVEL.WARNING);

                if (dr != System.Windows.Forms.DialogResult.OK) return false;

                in_node.AddString("KEY_1", MPCF.Trim(txtCurLine.Text));
                in_node.AddString("KEY_2", MPCF.Trim(txtCurResID.Text));
                in_node.AddString("DATA_1", MPCF.Trim(sOrderValue));

                if (MPCF.CallService("CUS", "CWIP_Update_Work_Order", in_node, ref out_node) == false) return false;

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

        private void frmCUSTranSpecifyWorkOrderList_Load(object sender, EventArgs e)
        {
            initCtrl();
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

                // CodeView Column Header Setup
                string[] header = new string[] { "Line", "Line Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };
                
                cdvLine.Text = cdvLine.Show(cdvLine, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                if (cdvLine.returnDatas != null && cdvLine.returnDatas.Count > 0)
                {
                    cdvLine.Tag = cdvLine.returnDatas[0];
                    cdvLine.Text = cdvLine.returnDatas[0];
                    txtLineDesc.Text = cdvLine.returnDatas[1];
                }
                else
                {
                    txtLineDesc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvShift_CodeViewButtonClick(object sender, EventArgs e)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;

            try
            {
                sViewID = "VIEW_SHIFT";

                i_cond_cnt = 1;
                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];

                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                // CodeView Column Header Setup
                string[] header = new string[] { "Shift", "Shift Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show by RPTServer
                cdvShift.Text = cdvShift.Show(cdvShift, "Shift", sViewID, ArrDVC, display, header, "DATA_1", -1);

                if (cdvShift.returnDatas != null && cdvShift.returnDatas.Count > 0)
                {
                    cdvShift.Tag = cdvShift.returnDatas[1];
                    cdvShift.Text = cdvShift.returnDatas[1];
                    txtShiftDesc.Text = cdvShift.returnDatas[0];
                }
                else
                {
                    txtShiftDesc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvMaterial_CodeViewButtonClick(object sender, EventArgs e)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;

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
                cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "Material List", sViewID, ArrDVC, display, header, "MAT_ID", -1);

                if (cdvMaterial.returnDatas != null && cdvMaterial.returnDatas.Count > 0)
                {
                    cdvMaterial.Tag = cdvMaterial.returnDatas[0];
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
            MPCF.ClearList(this.spdOrderList);
            MPCF.ClearList(spdBomList);

            if (CheckCondition(CSGC.MP_CHECK_VIEW) == false) { return; }

            ViewOrderList();
            ViewCurrentWorkOrder();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (CheckCondition(CSGC.MP_CHECK_UPDATE) == false) { return; }

            UpdateWorkOrderHistory(MPGC.MP_STEP_CREATE);

            ViewOrderList();
            ViewCurrentWorkOrder();
        }

        private void spdOrderList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            ViewBomList();
        }

        #endregion
    }
}
