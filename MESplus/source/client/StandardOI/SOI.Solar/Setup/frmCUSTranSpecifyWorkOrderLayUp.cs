//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmCUSTranSpecifyWorkOrderLayUp.cs
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
    public partial class frmCUSTranSpecifyWorkOrderLayUp : SOIBaseForm03
    {
        #region [Property]

        private Object CurWorkOrder = new object();
        private bool CurResID = false;

        #endregion

        public frmCUSTranSpecifyWorkOrderLayUp()
        {
            InitializeComponent();
        }

        #region [Constant Definition]

        #endregion

        #region [Variable Definition]

        private enum BOM_LIST : int
        {
            BOM_SET_ID = 0,
            MAT_ID,
            MAT_DESC,            
            BOM_TYPE,
            BOM_SET_VERSION,
            MAT_VER,
            TRANSFER_QTY,
            LOT_USE_QTY,
            MAT_BASE_QTY,
            MAT_QTY,
            OPER,
            OPER_DESC
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
                // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
                MPCF.ConvertCaption(this);

                MPCF.FieldClear(this);
                this.dtpFrom.Value = DateTime.Now.AddDays(-1);
                this.dtpTo.Value = DateTime.Now;

                MPCF.ClearList(spdOrderList, true);
                MPCF.FitColumnHeader(spdOrderList);                

                this.btnPrintOption.Visible = false;

                MPCF.SaveRegSetting(Application.ProductName, this.Name, "txtCurLine", "01");
                this.txtCurLine.Text = MPCF.GetRegSetting(Application.ProductName, this.Name, "txtCurLine", "");

                //Current Work Order Information View
                ViewWorkOrder();
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
                            if (DateTime.TryParse(dtpFrom.Value.ToString(), out dtpFromOut) == true){}
                        }

                        DateTime dtpToOut = new DateTime();
                        if (dtpTo.Value != null)
                        {
                            if (DateTime.TryParse(dtpTo.Value.ToString(), out dtpToOut) == true){}
                        }

                        if (this.dtpFrom.GetValueAsDateTime() > this.dtpTo.GetValueAsDateTime())
                        {
                            this.dtpFrom.SetValueAsDateTime(dtpToOut.AddDays(-1));
                            MPCF.ShowMsgBox(MPCF.GetMessage(371));
                        }

                        break;

                    case CSGC.MP_CHECK_UPDATE:

                        if (spdOrderList.ActiveSheet.DataSource == null)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(408));
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

        private void ViewWorkOrder()
        {
            ViewCurrentWorkOrder(LAY01);
            ViewCurrentWorkOrder(LAY02);
            ViewCurrentWorkOrder(LAY03);
            ViewCurrentWorkOrder(LAY04);
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
                sViewID = "VIEW_WORK_ORDER_LIST_05";

                i_cond_cnt = 7;
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

                ArrDVC[6].sCondtion_ID = "$ORD_END_FLAG";
                ArrDVC[6].sCondition_Value = chkOrdEnd.Checked ? "('N', 'Y')" : "('N')";

                if (TPDR.DirectViewOne(this.spdOrderList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return;
                }

                spdOrderList.ActiveSheet.Columns[(int)ORDER_LIST.MAT_VER].Visible = false;
                spdOrderList.ActiveSheet.Columns[spdOrderList.ActiveSheet.Columns.Count - 2].Visible = false;
                spdOrderList.ActiveSheet.Columns[spdOrderList.ActiveSheet.Columns.Count - 1].Visible = false;

                if (string.IsNullOrEmpty(MPCF.Trim(spdOrderList.ActiveSheet.Cells[0, 20].Text)) == false)
                {
                    txtStatus.Visible = true;
                    txtStatus.Text = "설정중";
                    cdvChangeMat.Text = MPCF.Trim(spdOrderList.ActiveSheet.Cells[0, 20].Text);
                }
                else
                {
                    txtStatus.Visible = false;
                    cdvChangeMat.Text = "";
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

                spdBomList.ActiveSheet.Columns[(int)BOM_LIST.MAT_VER].Visible = false;
                MPCF.FitColumnHeader(spdBomList);
                return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void ViewCurrentWorkOrder(object control)
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
                ArrDVC[1].sCondition_Value = MPCF.Trim(((BOI.OIFrx.BOIControls.BOICodeView)control).Name);

                if (TPDR.DirectViewOne(((BOI.OIFrx.BOIControls.BOICodeView)control), sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return;
                }

                ((BOI.OIFrx.BOIControls.BOICodeView)control).Text = dt.Rows[0]["ORDER_ID"].ToString();

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
            TRSNode node;

            try
            {
                DialogResult dr = MPCF.ShowMsgBox(MPCF.GetMessage(401), MessageBoxButtons.OKCancel, SOI.CliFrx.MSG_LEVEL.WARNING);
                if (dr != System.Windows.Forms.DialogResult.OK) return false;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("TABLE_NAME", CSGC.MP_GCM_TBL_CUR_WORK_ORDER);

                node = in_node.AddNode("DATA_LIST");
                node.AddString("KEY_1", MPCF.Trim(txtCurLine.Text));
                node.AddString("KEY_2", MPCF.Trim(lblLay1.Text));
                node.AddString("DATA_1", MPCF.Trim(LAY01.Text));
                node = in_node.AddNode("DATA_LIST");
                node.AddString("KEY_1", MPCF.Trim(txtCurLine.Text));
                node.AddString("KEY_2", MPCF.Trim(lblLay2.Text));
                node.AddString("DATA_1", MPCF.Trim(LAY02.Text));
                node = in_node.AddNode("DATA_LIST");
                node.AddString("KEY_1", MPCF.Trim(txtCurLine.Text));
                node.AddString("KEY_2", MPCF.Trim(lblLay3.Text));
                node.AddString("DATA_1", MPCF.Trim(LAY03.Text));
                node = in_node.AddNode("DATA_LIST");
                node.AddString("KEY_1", MPCF.Trim(txtCurLine.Text));
                node.AddString("KEY_2", MPCF.Trim(lblLay4.Text));
                node.AddString("DATA_1", MPCF.Trim(LAY04.Text));

                if (!MPCF.CallService("CUS", "CWIP_Update_Work_Order", in_node, ref out_node)) return false;

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

        private void frmCUSTranSpecifyWorkOrderLayUp_Load(object sender, EventArgs e)
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

        private void cdvWorkOrder_CodeViewButtonClick(object sender, EventArgs e)
        {
            if (!CheckCondition(CSGC.MP_CHECK_UPDATE)) return;

            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[6];

            try
            {
                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$FROM_DATE";
                dvcArgu[1].sCondition_Value = MPCF.Trim(this.dtpFrom.GetValueAsString(8));

                dvcArgu[2].sCondtion_ID = "$TO_DATE";
                dvcArgu[2].sCondition_Value = MPCF.Trim(this.dtpTo.GetValueAsString(8));

                dvcArgu[3].sCondtion_ID = "$MAT_ID";
                dvcArgu[3].sCondition_Value = MPCF.Trim(cdvMaterial.Text);

                dvcArgu[4].sCondtion_ID = "$LINE_ID";
                dvcArgu[4].sCondition_Value = MPCF.Trim(cdvLine.Text);

                dvcArgu[5].sCondtion_ID = "$SHIFT";
                dvcArgu[5].sCondition_Value = MPCF.Trim(cdvShift.Text);

                // CodeView Column Header Setup
                string[] header = new string[] { "ORDER_ID", "ORDER_DESC" };

                // CodeView Display Column Setup
                string[] display = new string[] { "ORDER_ID", "ORDER_DESC" };

                // Show by RPTServer
                ((BOI.OIFrx.BOIControls.BOICodeView)sender).Text = ((BOI.OIFrx.BOIControls.BOICodeView)sender).Show(((BOI.OIFrx.BOIControls.BOICodeView)sender), "WORKID", "VIEW_WORK_ORDER_ID", dvcArgu, display, header, "ORDER_ID", -1);

                if (((BOI.OIFrx.BOIControls.BOICodeView)sender).returnDatas != null && ((BOI.OIFrx.BOIControls.BOICodeView)sender).returnDatas.Count > 0)
                {
                    ((BOI.OIFrx.BOIControls.BOICodeView)sender).Tag = ((BOI.OIFrx.BOIControls.BOICodeView)sender).returnDatas[0];
                    ((BOI.OIFrx.BOIControls.BOICodeView)sender).Text = ((BOI.OIFrx.BOIControls.BOICodeView)sender).returnDatas[0];
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
            ViewWorkOrder();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (CheckCondition(CSGC.MP_CHECK_UPDATE) == false) { return; }

            UpdateWorkOrderHistory(MPGC.MP_STEP_CREATE);

            ViewOrderList();
            ViewWorkOrder();
        }

        private void spdOrderList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            ViewBomList();
        }

        private void spdOrderList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (!CurResID) return;

                string sOrderValue = string.Empty;

                if (MPCF.ToChar(spdOrderList.Sheets[0].Cells[spdOrderList.ActiveSheet.ActiveRowIndex, (int)ORDER_LIST.ORD_END_FLAG].Value) == 'Y')
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(369));
                    return;
                }

                sOrderValue = spdOrderList.ActiveSheet.Cells[spdOrderList.ActiveSheet.ActiveRowIndex, (int)ORDER_LIST.ORDER_ID].Value.ToString();

                DialogResult dr = MPCF.ShowMsgBox(string.Format(MPCF.GetMessage(386), ((BOI.OIFrx.BOIControls.BOICodeView)CurWorkOrder).Name, sOrderValue), MessageBoxButtons.OKCancel, SOI.CliFrx.MSG_LEVEL.WARNING);

                if (dr != System.Windows.Forms.DialogResult.OK) return;

                ((BOI.OIFrx.BOIControls.BOICodeView)CurWorkOrder).Text = sOrderValue;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void LAY_MouseDown(object sender, MouseEventArgs e)
        {
            CurResID = true;
            CurWorkOrder = sender;
        }

        private void chkOrdEnd_CheckedChanged(object sender, EventArgs e)
        {
            btnView.PerformClick();
        }

        #endregion

        private void soiCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(soiCheckBox1.Checked)
            {
                btnCancel.Enabled = true;
                btnSetup.Enabled = true;
                cdvChangeMat.Enabled = true;
            }
            else
            {
                cdvChangeMat.Text = "";
                btnCancel.Enabled = false;
                btnSetup.Enabled = false;
                cdvChangeMat.Enabled = false;
            }
        }

        /// <summary>
        /// Tran_Order_Material_Change
        /// </summary>
        /// <param name="sLotID"></param>
        /// <returns></returns>
        private bool Tran_Order_Material_Change(char cStep)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = cStep;
                in_node.AddString("CHANGE_MAT_ID", MPCF.Trim(cdvChangeMat.Text));
                in_node.AddString("LABEL_TYPE", MPCF.Trim(rbStatus.Items[rbStatus.CheckedIndex].DataValue.ToString()));

                if (MPCF.CallService("CUS", "CWIP_Update_Work_Order", in_node, ref out_node) == false)
                {
                    return false;
                }

                cdvChangeMat.Text = "";
                CMNF.ShowSuccessMessage(out_node, true);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(Tran_Order_Material_Change('2') == true)
            {
                btnView.PerformClick();
            }
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MPCF.Trim(cdvChangeMat.Text)) == true)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Chane MatID]"));
                MPCF.SetFocus(cdvChangeMat);
                return;
            }

            if (CMNF.ShowMsgBox("완제품 품번을 변경하시겠습니까?", MessageBoxButtons.YesNo, SOI.CliFrx.MSG_LEVEL.WARNING) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            if(Tran_Order_Material_Change('1') == true)
            {
                btnView.PerformClick();
            }
        }

        private void cdvChangeMat_CodeViewButtonClick(object sender, EventArgs e)
        {
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;

            try
            {
                sViewID = "VIEW_MAT_LIST_2";

                ArrDVC = new TPDR.DirectViewCond[2];

                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$MAT_ID";

                if(string.IsNullOrEmpty(cdvChangeMat.Text) == false)
                    ArrDVC[1].sCondition_Value = MPCF.Trim(this.cdvChangeMat.Text) + "%";
                else
                    ArrDVC[1].sCondition_Value = "%";

                // CodeView Column Header Setup
                string[] header = new string[] { "Material ID", "Material Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "MAT_ID", "MAT_DESC" };

                // Show by RPTServer
                cdvChangeMat.Text = cdvChangeMat.Show(cdvChangeMat, "Material List", sViewID, ArrDVC, display, header, "MAT_ID", -1);

                if (cdvChangeMat.returnDatas != null && cdvChangeMat.returnDatas.Count > 0)
                {
                    cdvChangeMat.Text = cdvChangeMat.returnDatas[0];
                }
                else
                {
                    cdvChangeMat.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }
    }
}
