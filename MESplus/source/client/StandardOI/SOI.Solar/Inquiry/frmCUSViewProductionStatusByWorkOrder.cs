using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx;
using Miracom.TRSCore;
using Miracom.MESCore;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using SOI.DNM;
using BOI.OIFrx;

namespace SOI.Solar
{
    public partial class frmCUSViewProductionStatusByWorkOrder : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        #region [Property]

        #endregion



        #region [Constant Definition]

        private enum LOT_COL : int
        {
            LINE,
            ORDER_ID,
            WORK_START_DATE,
            WORK_END_DATE,
            ORDER_QTY,
            LAY_UP,
            BUSSING,
            EPE,
            FRONT_EL,
            LAMI,
            INSPEC,
            FRAME,
            JB_INSTAL,
            CURING,
            REAR_EL,
            PACKING
        }

        #endregion



        #region [Variable Definition]

        #endregion



        #region [Form Definition]

        public frmCUSViewProductionStatusByWorkOrder()
        {
            InitializeComponent();
        }

        private void frmCUSViewProductionStatusByWorkOrder_Load(object sender, EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdOrderList);

                this.dtpFrom.Value = DateTime.Now.AddDays(-7);
                this.dtpTo.Value = DateTime.Now;

                cdvMaterial.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvMaterial.Tag"));
                cdvMaterial.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvMaterial.Text"));
                txtMaterialDesc.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "txtMaterialDesc.Text"));

                cdvLine.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvLine.Tag"));
                cdvLine.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvLine.Text"));
                txtLineDesc.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "txtLineDesc.Text"));
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void frmCUSViewProductionStatusByWorkOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvMaterial.Tag", MPCF.Trim(cdvMaterial.Tag));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvMaterial.Text", MPCF.Trim(cdvMaterial.Text));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "txtMaterialDesc.Text", MPCF.Trim(txtMaterialDesc.Text));

                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvLine.Tag", MPCF.Trim(cdvLine.Tag));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvLine.Text", MPCF.Trim(cdvLine.Text));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "txtLineDesc.Text", MPCF.Trim(txtLineDesc.Text));
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion



        #region [Function Definition]

        private bool View_Order_List()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[6];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;

            try
            {
                spdOrderList_Sheet1.RowCount = 0;

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
                
                dvcArgu[5].sCondtion_ID = "$ORDER_ID";
                dvcArgu[5].sCondition_Value = MPCF.Trim(cdvOrderID.Text);
                
                if (TPDR.GetDataOne("", ref dt, "VIEW_OPER_QTY_BY_WORK_ORDER_01", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdOrderList_Sheet1.RowCount++;
                    spdOrderList_Sheet1.Cells[i, (int)LOT_COL.LINE].Value = dt.Rows[i]["LINE"].ToString();
                    spdOrderList_Sheet1.Cells[i, (int)LOT_COL.ORDER_ID].Value = dt.Rows[i]["ORDER_ID"].ToString();
                    spdOrderList_Sheet1.Cells[i, (int)LOT_COL.WORK_START_DATE].Value = dt.Rows[i]["WORK_START_DATE"].ToString();
                    spdOrderList_Sheet1.Cells[i, (int)LOT_COL.WORK_END_DATE].Value = dt.Rows[i]["WORK_END_DATE"].ToString();
                    spdOrderList_Sheet1.Cells[i, (int)LOT_COL.ORDER_QTY].Value = dt.Rows[i]["ORD_QTY"].ToString();
                    spdOrderList_Sheet1.Cells[i, (int)LOT_COL.LAY_UP].Value = MPCF.ToInt(dt.Rows[i]["LAY_UP"].ToString());
                    spdOrderList_Sheet1.Cells[i, (int)LOT_COL.BUSSING].Value = MPCF.ToInt(dt.Rows[i]["BUSSING"].ToString());
                    spdOrderList_Sheet1.Cells[i, (int)LOT_COL.EPE].Value = MPCF.ToInt(dt.Rows[i]["EPE"].ToString());
                    spdOrderList_Sheet1.Cells[i, (int)LOT_COL.FRONT_EL].Value = MPCF.ToInt(dt.Rows[i]["FRONT_EL"].ToString());
                    spdOrderList_Sheet1.Cells[i, (int)LOT_COL.LAMI].Value = MPCF.ToInt(dt.Rows[i]["LAMI"].ToString());
                    spdOrderList_Sheet1.Cells[i, (int)LOT_COL.INSPEC].Value = MPCF.ToInt(dt.Rows[i]["INSPEC"].ToString());
                    spdOrderList_Sheet1.Cells[i, (int)LOT_COL.FRAME].Value = MPCF.ToInt(dt.Rows[i]["FRAME"].ToString());
                    spdOrderList_Sheet1.Cells[i, (int)LOT_COL.JB_INSTAL].Value = MPCF.ToInt(dt.Rows[i]["JB_INSTAL"].ToString());
                    spdOrderList_Sheet1.Cells[i, (int)LOT_COL.CURING].Value = MPCF.ToInt(dt.Rows[i]["CURING"].ToString());
                    spdOrderList_Sheet1.Cells[i, (int)LOT_COL.REAR_EL].Value = MPCF.ToInt(dt.Rows[i]["REAR_EL"].ToString());
                    spdOrderList_Sheet1.Cells[i, (int)LOT_COL.PACKING].Value = MPCF.ToInt(dt.Rows[i]["PACKING"].ToString());
                }

                MPCF.FitColumnHeader(spdOrderList);
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        #endregion



        #region [Event Definition]

        private void cdvMaterial_CodeViewButtonClick(object sender, EventArgs e)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;

            try
            {
                sViewID = "VIEW_MAT_LIST_BY_WORK_ORDER";
                i_cond_cnt = 3;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];

                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$FROM_DATE";
                ArrDVC[1].sCondition_Value = MPCF.Trim(this.dtpFrom.GetValueAsString(8));

                ArrDVC[2].sCondtion_ID = "$TO_DATE";
                ArrDVC[2].sCondition_Value = MPCF.Trim(this.dtpTo.GetValueAsString(8));

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

        private void cdvOrderID_CodeViewButtonClick(object sender, EventArgs e)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;

            try
            {
                sViewID = "VIEW_WORK_ORDER_LIST_06";
                i_cond_cnt = 5;

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

                // CodeView Column Header Setup
                string[] header = new string[] { "Order ID", "Order Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "ORDER_ID", "ORDER_DESC" };

                // Show by RPTServer
                cdvOrderID.Text = cdvOrderID.Show(cdvOrderID, "ORDER List", sViewID, ArrDVC, display, header, "ORDER_ID", -1);

                if (cdvOrderID.returnDatas != null && cdvOrderID.returnDatas.Count > 0)
                {
                    cdvOrderID.Tag = cdvOrderID.returnDatas[0];
                    cdvOrderID.Text = cdvOrderID.returnDatas[0];
                    this.txtOrderDesc.Text = cdvOrderID.returnDatas[1];
                }
                else
                {
                    this.txtOrderDesc.Text = string.Empty;
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
            try
            {
                View_Order_List();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion


    }
}
