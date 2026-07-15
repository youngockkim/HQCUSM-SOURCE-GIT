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
using Infragistics.Win.UltraWinGrid;
//using Miracom.CliFrx;
using Miracom.MESCore;
//using Custom.Common;

namespace SOI.HanwhaQcell.USModule
{
    public partial class frmCUSTranStartLot : SOIBaseForm02
    {
        public frmCUSTranStartLot()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        public enum ORDER_LIST : int
        {
            ORDER_ID = 0,
            MAT_ID,
            MAT_DESC,
            PLAN_START_DATE,
            PLAN_ENDT_DATE,
            ORD_QTY,
            ORD_IN_QTY,
            ORD_OUT_QTY,
            ORD_LOSS_QTY,
            ORD_RWK_QTY,
            ORD_STATUS_FLAG
        }

        //private const string CLEAR_ALL = "ALL";
        private const string CLEAR_LABEL_INIT = "CLEAR_LABEL_INIT";

        #endregion

        #region " Variable Definition "
        
        #endregion

        #region " Constant Definition "
        
        #endregion
        
        #region "Event Definition"

        private void frmCUSTranStartLot_Load(object sender, EventArgs e)
        {
            try
            {
                MPCF.ConvertCaption(this);


            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {

        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cdvLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvLine.Text = cdvLine.Show(cdvLine, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                if (cdvLine.returnDatas != null && cdvLine.returnDatas.Count > 1)
                {
                    txtLineDesc.Text = cdvLine.returnDatas[1];
                }
                else
                {
                    txtLineDesc.Text = string.Empty;
                }

                ViewOrderList();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                string[] header = new string[] { "Oper", "Description" };
                string[] display = new string[] { "OPER", "OPER_DESC" };

                cdvOper.Text = cdvOper.Show(cdvOper, "View Operation List", "WIP", "WIP_View_Operation_List", in_node, "LIST", display, header, "OPER");

                if (cdvOper.returnDatas != null && cdvOper.returnDatas.Count > 1)
                {
                    txtOperDesc.Text = cdvOper.returnDatas[1];
                }
                else
                {
                    txtOperDesc.Text = string.Empty;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvResID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("OPER", MPCF.Trim(cdvOper.Text));

                string[] header = new string[] { "Resource", "Description" };
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                cdvResID.Text = cdvResID.Show(cdvResID, "Resource ID", "RAS", "RAS_View_Resource_List", in_node, "RES_LIST", display, header, "RES_ID");
                
                if (cdvResID.returnDatas != null && cdvResID.returnDatas.Count > 1)
                {
                    txtResDesc.Text = cdvResID.returnDatas[1];
                }
                else
                {
                    txtResDesc.Text = string.Empty;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        #endregion




        #region "Function Definition"

        private bool ViewOrderList()
        {
            try
            {
                int i;
                MPCF.ClearList(spdOrder);

                TRSNode in_node = new TRSNode("VIEW_ORDER_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_ORDER_LIST_OUT");
                TRSNode order_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                //in_node.AddString("WORK_DATE", MPCF.Trim(cdvLine.Text));

                if (MPCF.CallService("ORD", "ORD_View_Order_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdOrder.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    order_list = out_node.GetList(0)[i];

                    spdOrder.ActiveSheet.RowCount++;

                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORDER_ID].Value = order_list.GetString("ORDER_ID");
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.MAT_ID].Value = order_list.GetString("MAT_ID");
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORD_QTY].Value = order_list.GetDouble("ORD_QTY");
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORD_IN_QTY].Value = order_list.GetDouble("ORD_IN_QTY");
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORD_OUT_QTY].Value = order_list.GetDouble("ORD_OUT_QTY");
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORD_LOSS_QTY].Value = order_list.GetDouble("ORD_LOSS_QTY");
                    spdOrder.ActiveSheet.Cells[i, (int)ORDER_LIST.ORD_RWK_QTY].Value = order_list.GetDouble("ORD_RWK_QTY");
                }

                MPCF.FitColumnHeader(spdOrder);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion






    }
}
