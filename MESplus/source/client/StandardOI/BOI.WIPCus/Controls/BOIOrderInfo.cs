using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOI.CliFrx;
using SOI.DNM;
using SOI.OIFrx;
using BOI.OIFrx;
using Miracom.TRSCore;

namespace BOI.WIPCus.Controls
{
    public partial class BOIOrderInfo : UserControl
    {
        #region Property

        public string WorkOrderLineId { get; set; }
        public string WorkOrderLineDesc { get; set; }

        public string OrderId 
        { 
            get
            {
                if (spdOrderInfo_Sheet1.ActiveRowIndex >= 0)
                {
                    return MPCF.Trim(spdOrderInfo_Sheet1.GetValue(spdOrderInfo_Sheet1.ActiveRowIndex, (int)BIGC.ORDER.ORDER_ID));
                }
                else
                {
                    return string.Empty;
                }
            }            
        }
        public string ResId 
        {
            get
            {
                if (spdOrderInfo_Sheet1.ActiveRowIndex >= 0)
                {
                    return MPCF.Trim(spdOrderInfo_Sheet1.GetTag(spdOrderInfo_Sheet1.ActiveRowIndex, (int)BIGC.ORDER.RES_ID));
                }
                else
                {
                    return string.Empty;
                }
            }            
        }        

        public string MatId        
        {
            get
            {
                if (spdOrderInfo_Sheet1.ActiveRowIndex >= 0)
                {
                    return MPCF.Trim(spdOrderInfo_Sheet1.GetTag(spdOrderInfo_Sheet1.ActiveRowIndex, (int)BIGC.ORDER.MAT_ID));
                }
                else
                {
                    return string.Empty;
                }
            }
            
        }

        public int MatVer
        {
            get
            {
                if (spdOrderInfo_Sheet1.ActiveRowIndex >= 0)
                {
                    return MPCF.ToInt(spdOrderInfo_Sheet1.GetValue(spdOrderInfo_Sheet1.ActiveRowIndex, (int)BIGC.ORDER.MAT_VER));
                }
                else
                {
                    return 0;
                }
            }
        }

        public string BomMatType
        {
            get
            {
                if (spdOrderInfo_Sheet1.ActiveRowIndex >= 0)
                {
                    return MPCF.Trim(spdOrderInfo_Sheet1.GetValue(spdOrderInfo_Sheet1.ActiveRowIndex, (int)BIGC.ORDER.MAT_BOM_TYPE));
                }
                else
                {
                    return string.Empty;
                }
            }

        }

        public string Flow
        {
            get
            {
                if (spdOrderInfo_Sheet1.ActiveRowIndex >= 0)
                {
                    return MPCF.Trim(spdOrderInfo_Sheet1.GetTag(spdOrderInfo_Sheet1.ActiveRowIndex, (int)BIGC.ORDER.FLOW));
                }
                else
                {
                    return string.Empty;
                }
            }

        }        

        private string _lotId = string.Empty;
        public string LotId
        {
            get
            {
                if (spdOrderInfo_Sheet1.ActiveRowIndex >= 0)
                {
                    return MPCF.Trim(spdOrderInfo_Sheet1.GetValue(spdOrderInfo_Sheet1.ActiveRowIndex, (int)BIGC.ORDER.LOT_ID));
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                _lotId = value;
                if (spdOrderInfo_Sheet1.ActiveRowIndex >= 0)
                {
                    spdOrderInfo_Sheet1.SetValue(spdOrderInfo_Sheet1.ActiveRowIndex, (int)BIGC.ORDER.LOT_ID, MPCF.Trim(_lotId));
                }
            }
        }

        private List<BIGC.ORDER> visibleColums;
        public List<BIGC.ORDER> VisibleColums
        {
            get
            {
                return visibleColums;
            }
            set
            {                
                visibleColums = value;                                                       
            }
        }

        private List<BIGC.ORDER> invisibleColums;
        public List<BIGC.ORDER> InvisibleColums
        {
            get
            {
                return invisibleColums;
            }
            set
            {
                invisibleColums = value;
            }
        }

        public string Oper { get; set; }        

        public event EventHandler WorkOrderButtonClick;
        private void OnWorkOrderButtonClick(object sender, EventArgs e)
        {
            if (WorkOrderButtonClick != null)
            {
                WorkOrderButtonClick(this, e);
            }
        }

        #endregion

        #region Constructor

        public BOIOrderInfo()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        private void BOIOrderInfo_Load(object sender, EventArgs e)
        {
            try
            {
                MPCF.ClearList(spdOrderInfo);

                InvisibleColumn();
                CustomInVisibleColumn();
                VisibleColumn();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnViewWorkOrder_Click(object sender, EventArgs e)
        {
            string sOrderId = string.Empty;
            int i = 0;

            try
            {                
                frmWIPViewWorkOrderList frm = new frmWIPViewWorkOrderList();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    BIGV.gsWorkOrderLineId = string.Empty;

                    i = frm.mspdWorkOrder.ActiveRowIndex;

                    sOrderId = frm.mspdWorkOrder.Cells[i, (int)frmWIPViewWorkOrderList.ORD.ORDER_ID].Value.ToString();
                   
                    View_Order_Info(sOrderId);

                    OnWorkOrderButtonClick(this, e);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        public void View_Order_Info(string sOrderId)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;

            try
            {
                spdOrderInfo_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "ORDER_ID";
                dvcArgu[1].sCondition_Value = sOrderId;

                dvcArgu[2].sCondtion_ID = "OPER";
                dvcArgu[2].sCondition_Value = Oper;
                


                if (TPDR.GetDataOne("", ref dt, "COM0000-010", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdOrderInfo_Sheet1.RowCount++;

                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.FACTORY].Value = dt.Rows[i]["FACTORY"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORDER_ID].Value = dt.Rows[i]["ORDER_ID"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORDER_DESC].Value = dt.Rows[i]["ORDER_DESC"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORDER_TYPE].Tag = dt.Rows[i]["ORDER_TYPE"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORDER_TYPE].Value = dt.Rows[i]["ORDER_TYPE_DESC"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.LOT_ID].Value = dt.Rows[i]["LOT_ID"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.FLOW].Value = dt.Rows[i]["FLOW_DESC"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.FLOW].Tag = dt.Rows[i]["FLOW"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.FLOW_SEQ_NUM].Value = dt.Rows[i]["FLOW_SEQ_NUM"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.OPER].Value = dt.Rows[i]["OPER_DESC"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.OPER].Tag = dt.Rows[i]["OPER"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.RES_ID].Value = dt.Rows[i]["RES_DESC"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.RES_ID].Tag = dt.Rows[i]["RES_ID"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.MAT_ID].Value = dt.Rows[i]["MAT_DESC"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.MAT_ID].Tag = dt.Rows[i]["MAT_ID"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.MAT_VER].Value = dt.Rows[i]["MAT_VER"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.MAT_BOM_TYPE].Value = dt.Rows[i]["MAT_BOM_TYPE"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORD_QTY].Value = dt.Rows[i]["ORD_QTY"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.PROD_QTY].Value = dt.Rows[i]["PROD_QTY"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.REMAIN_QTY].Value = dt.Rows[i]["REMAIN_QTY"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.LOSS_QTY].Value = dt.Rows[i]["LOSS_QTY"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.UNIT_1].Value = dt.Rows[i]["UNIT_1"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.SHOP_CODE].Value = dt.Rows[i]["SHOP_DESC"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.SHOP_CODE].Tag = dt.Rows[i]["SHOP_CODE"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.LINE_ID].Value = dt.Rows[i]["LINE_DESC"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.LINE_ID].Tag = dt.Rows[i]["LINE_ID"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.LOT_TYPE].Value = dt.Rows[i]["LOT_TYPE"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORD_DATE].Value = dt.Rows[i]["ORD_DATE"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.PLAN_DATE].Value = dt.Rows[i]["PLAN_DATE"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.PLAN_PRIORITY].Value = dt.Rows[i]["PLAN_PRIORITY"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORD_REG_DATE].Value = dt.Rows[i]["ORD_REG_DATE"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORG_PLAN_DATE].Value = dt.Rows[i]["ORG_PLAN_DATE"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORG_ORD_QTY].Value = dt.Rows[i]["ORG_ORD_QTY"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.PLAN_START_TIME].Value = dt.Rows[i]["PLAN_START_TIME"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.PLAN_END_TIME].Value = dt.Rows[i]["PLAN_END_TIME"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORD_START_TIME].Value = dt.Rows[i]["ORD_START_TIME"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORD_END_TIME].Value = dt.Rows[i]["ORD_END_TIME"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.CLOSE_TIME].Value = dt.Rows[i]["CLOSE_TIME"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.LABEL_CODE].Value = dt.Rows[i]["LABEL_CODE"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.PACK_QTY].Value = dt.Rows[i]["PACK_QTY"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.CUST_ID].Value = dt.Rows[i]["CUST_ID"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ERP_SO_NO].Value = dt.Rows[i]["ERP_SO_NO"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ERP_SO_SEQ].Value = dt.Rows[i]["ERP_SO_SEQ"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORDER_STATUS].Value = dt.Rows[i]["ORDER_STATUS"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.COMMENT_1].Value = dt.Rows[i]["COMMENT_1"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.COMMENT_2].Value = dt.Rows[i]["COMMENT_2"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.COMMENT_3].Value = dt.Rows[i]["COMMENT_3"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORD_QTY_1].Value = dt.Rows[i]["ORD_QTY_1"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORD_QTY_2].Value = dt.Rows[i]["ORD_QTY_2"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORD_QTY_3].Value = dt.Rows[i]["ORD_QTY_3"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORD_QTY_4].Value = dt.Rows[i]["ORD_QTY_4"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORD_QTY_5].Value = dt.Rows[i]["ORD_QTY_5"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORD_CMF_1].Value = dt.Rows[i]["ORD_CMF_1"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORD_CMF_2].Value = dt.Rows[i]["ORD_CMF_2"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORD_CMF_3].Value = dt.Rows[i]["ORD_CMF_3"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORD_CMF_4].Value = dt.Rows[i]["ORD_CMF_4"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORD_CMF_5].Value = dt.Rows[i]["ORD_CMF_5"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORD_CMF_6].Value = dt.Rows[i]["ORD_CMF_6"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORD_CMF_7].Value = dt.Rows[i]["ORD_CMF_7"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORD_CMF_8].Value = dt.Rows[i]["ORD_CMF_8"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORD_CMF_9].Value = dt.Rows[i]["ORD_CMF_9"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.ORD_CMF_10].Value = dt.Rows[i]["ORD_CMF_10"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.CREATE_USER_ID].Value = dt.Rows[i]["CREATE_USER_ID"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.CREATE_TIME].Value = dt.Rows[i]["CREATE_TIME"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.UPDATE_USER_ID].Value = dt.Rows[i]["UPDATE_USER_ID"].ToString();
                    spdOrderInfo_Sheet1.Cells[i, (int)BIGC.ORDER.UPDATE_TIME].Value = dt.Rows[i]["UPDATE_TIME"].ToString();
                }

                //MPCF.FitColumnHeader(spdOrderInfo);

                if (spdOrderInfo_Sheet1.RowCount > 0)
                {
                    BIGV.gsWorkOrderLineId = MPCF.Trim(spdOrderInfo_Sheet1.GetTag(0, (int)BIGC.ORDER.LINE_ID));

                    WorkOrderLineId = MPCF.Trim(spdOrderInfo_Sheet1.GetTag(0, (int)BIGC.ORDER.LINE_ID));
                    WorkOrderLineDesc = MPCF.Trim(spdOrderInfo_Sheet1.GetValue(0, (int)BIGC.ORDER.LINE_ID));
                    LotId = MPCF.Trim(spdOrderInfo_Sheet1.GetValue(0, (int)BIGC.ORDER.LOT_ID));
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }

            return;
        }

        private void InvisibleColumn()
        {
            try
            {
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.FACTORY].Visible = false;
                //ORDER_ID
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ORDER_DESC].Visible = false;
                //ORDER_TYE
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.LOT_ID].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.FLOW].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.FLOW_SEQ_NUM].Visible = false;
                //OPER
                //RES_ID
                //MAT_ID
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.MAT_VER].Visible = false;
                //MAT_BOM_TYPE
                //ORD_QTY
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.PROD_QTY].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.REMAIN_QTY].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.LOSS_QTY].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.UNIT_1].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.SHOP_CODE].Visible = false;
                //LINE_ID
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.LOT_TYPE].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ORD_DATE].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.PLAN_DATE].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.PLAN_PRIORITY].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ORD_REG_DATE].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ORG_PLAN_DATE].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ORG_ORD_QTY].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.PLAN_START_TIME].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.PLAN_END_TIME].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ORD_START_TIME].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ORD_END_TIME].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.CLOSE_TIME].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.LABEL_CODE].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.PACK_QTY].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.CUST_ID].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ERP_SO_NO].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ERP_SO_SEQ].Visible = false;
                //ORDER_STATUS
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.COMMENT_1].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.COMMENT_2].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.COMMENT_3].Visible = false;
                //ORD_QTY_1
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ORD_QTY_2].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ORD_QTY_3].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ORD_QTY_4].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ORD_QTY_5].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ORD_CMF_1].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ORD_CMF_2].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ORD_CMF_3].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ORD_CMF_4].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ORD_CMF_5].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ORD_CMF_6].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ORD_CMF_7].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ORD_CMF_8].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ORD_CMF_9].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.ORD_CMF_10].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.CREATE_USER_ID].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.CREATE_TIME].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.UPDATE_USER_ID].Visible = false;
                spdOrderInfo_Sheet1.Columns[(int)BIGC.ORDER.UPDATE_TIME].Visible = false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        public void VisibleColumn()
        {
            try
            {
                if (visibleColums != null)
                {
                    foreach (int i in visibleColums)
                    {
                        spdOrderInfo_Sheet1.Columns[i].Visible = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        public void CustomInVisibleColumn()
        {
            try
            {
                if (invisibleColums != null)
                {
                    foreach (int i in invisibleColums)
                    {
                        spdOrderInfo_Sheet1.Columns[i].Visible = false;
                    }
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
