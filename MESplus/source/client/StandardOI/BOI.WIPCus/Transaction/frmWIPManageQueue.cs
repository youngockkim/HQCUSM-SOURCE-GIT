using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BOI.OIFrx;
using SOI.CliFrx;
using SOI.DNM;
using SOI.OIFrx;
using Miracom.TRSCore;
using SOI.MsgHandlerH101;

// 선입 선출 대기열 관리
namespace BOI.WIPCus
{
    public partial class frmWIPManageQueue : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        public frmWIPManageQueue()
        {
            InitializeComponent();
        }

        private enum QUE
        {
            SEL,
            LOAD_TIME,
            LINE,
            RES_ID,
            LOT_ID,
            MAT_ID,
            REMAIN_QTY,
            ADJ_TYPE,
            ADJ_QTY,
            ADJ_AF_QTY,
            UNIT,
            ORDER_ID,
            OPER
        }

        /// <summary>
        /// 선입선출 대기열 조회
        /// </summary>
        /// <returns></returns>
        private bool View_Queue()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;

            try
            {
                if (MPCF.CheckValue(cdvLineGroup, false) == false)
                {
                    return false;
                }

                if (MPCF.CheckValue(cdvLine, false) == false)
                {
                    return false;
                }

                spdQueue_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "LINE_GROUP";
                dvcArgu[1].sCondition_Value = MPCF.Trim(cdvLineGroup.Tag);

                dvcArgu[2].sCondtion_ID = "LINE_ID";
                dvcArgu[2].sCondition_Value = MPCF.Trim(cdvLine.Tag);

                dvcArgu[3].sCondtion_ID = "RES_ID";
                dvcArgu[3].sCondition_Value = MPCF.Trim(cdvResource.Tag);

                if (TPDR.GetDataOne("", ref dt, "CWIP2405-001", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdQueue_Sheet1.RowCount++;
                    spdQueue_Sheet1.Cells[i, (int)QUE.SEL].Value = false;
                    spdQueue_Sheet1.Cells[i, (int)QUE.LOAD_TIME].Value = MPCF.MakeDateFormat(dt.Rows[i]["LOAD_TIME"].ToString(), DATE_TIME_FORMAT.DATETIME);
                    spdQueue_Sheet1.Cells[i, (int)QUE.LOAD_TIME].Tag = dt.Rows[i]["LOAD_TIME"];
                    spdQueue_Sheet1.Cells[i, (int)QUE.LINE].Value = dt.Rows[i]["LINE_DESC"];
                    spdQueue_Sheet1.Cells[i, (int)QUE.LINE].Tag = dt.Rows[i]["LINE_ID"];
                    spdQueue_Sheet1.Cells[i, (int)QUE.RES_ID].Value = dt.Rows[i]["RES_DESC"];
                    spdQueue_Sheet1.Cells[i, (int)QUE.RES_ID].Tag = dt.Rows[i]["RES_ID"];
                    spdQueue_Sheet1.Cells[i, (int)QUE.LOT_ID].Value = dt.Rows[i]["LOT_ID"];
                    spdQueue_Sheet1.Cells[i, (int)QUE.MAT_ID].Value = dt.Rows[i]["MAT_DESC"];
                    spdQueue_Sheet1.Cells[i, (int)QUE.MAT_ID].Tag = dt.Rows[i]["MAT_ID"];
                    spdQueue_Sheet1.Cells[i, (int)QUE.REMAIN_QTY].Value = dt.Rows[i]["REMAIN_QTY"];
                    spdQueue_Sheet1.Cells[i, (int)QUE.UNIT].Value = dt.Rows[i]["UNIT_1"];
                    spdQueue_Sheet1.Cells[i, (int)QUE.ORDER_ID].Value = dt.Rows[i]["ORDER_ID"];
                    spdQueue_Sheet1.Cells[i, (int)QUE.OPER].Value = dt.Rows[i]["OPER"];
                }

                MPCF.FitColumnHeader(spdQueue);
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("View_Queue() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 데이터의 유효성 검사
        /// </summary>
        /// <returns></returns>
        private bool Check_Data()
        {
            int i = 0, i_cnt = 0;

            double d_remain_qty = 0;
            double d_adj_qty = 0;            

            try
            {
                if (spdQueue_Sheet1.RowCount == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(244), MSG_LEVEL.ERROR, false);
                    return false;
                }

                for (i = 0; i < spdQueue_Sheet1.RowCount; i++)
                {
                    if (Convert.ToBoolean(spdQueue_Sheet1.Cells[i, (int)QUE.SEL].Value))
                    {
                        i_cnt++;

                        if (spdQueue_Sheet1.Cells[i, (int)QUE.ADJ_TYPE].Text == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, false);
                            spdQueue.Focus();
                            BICF.SetPosition(spdQueue, i, (int)QUE.ADJ_TYPE);
                            return false;
                        }

                        if (spdQueue_Sheet1.Cells[i, (int)QUE.ADJ_TYPE].Text == "Loss")
                        {
                            d_remain_qty = MPCF.ToDbl(spdQueue_Sheet1.Cells[i, (int)QUE.REMAIN_QTY].Value);
                            d_adj_qty = MPCF.ToDbl(spdQueue_Sheet1.Cells[i, (int)QUE.ADJ_QTY].Value);
                            if (d_adj_qty == 0)
                            {
                                MPCF.ShowMessage(MPCF.GetMessage(114), MSG_LEVEL.ERROR, false);
                                spdQueue.Focus();
                                BICF.SetPosition(spdQueue, i, (int)QUE.ADJ_QTY);
                                return false;
                            }

                            if (d_remain_qty - d_adj_qty < 0)
                            {
                                MPCF.ShowMessage(MPCF.GetMessage(416), MSG_LEVEL.ERROR, false);
                                spdQueue.Focus();
                                BICF.SetPosition(spdQueue, i, (int)QUE.ADJ_QTY);
                                return false;
                            }
                        }
                    }
                }

                if (i_cnt == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(133), MSG_LEVEL.ERROR, false);
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("Check_Data() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 대기열을 정리한다.
        /// </summary>
        /// <returns></returns>
        private bool Manage_Queue()
        {
            TRSNode in_node = new TRSNode("Manage_Queue_In");
            TRSNode out_node = new TRSNode("Manage_Queue_Out");

            TRSNode data_list = null;

            int i = 0;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                for (i = 0; i < spdQueue_Sheet1.RowCount; i++)
                {
                    if (Convert.ToBoolean(spdQueue_Sheet1.Cells[i, (int)QUE.SEL].Value))
                    {
                        data_list = in_node.AddNode("DATA_LIST");
                        data_list.AddString("RES_ID", spdQueue_Sheet1.Cells[i, (int)QUE.RES_ID].Tag);
                        data_list.AddString("OPER", spdQueue_Sheet1.Cells[i, (int)QUE.OPER].Value);
                        data_list.AddString("LOT_ID", spdQueue_Sheet1.Cells[i, (int)QUE.LOT_ID].Value);
                        data_list.AddString("ORDER_ID", spdQueue_Sheet1.Cells[i, (int)QUE.ORDER_ID].Value);
                        data_list.AddString("LOAD_TIME", spdQueue_Sheet1.Cells[i, (int)QUE.LOAD_TIME].Tag);
                        data_list.AddString("ADJUST_TYPE", spdQueue_Sheet1.Cells[i, (int)QUE.ADJ_TYPE].Value);
                        data_list.AddDouble("ADJUST_QTY", spdQueue_Sheet1.Cells[i, (int)QUE.ADJ_QTY].Value);
                        data_list.AddDouble("ADJUST_AF_QTY", spdQueue_Sheet1.Cells[i, (int)QUE.ADJ_AF_QTY].Value);
                    }
                }

                if (MPCF.CallService("BWIP", "BWIP_Manage_Queue", in_node, ref out_node) == false)
                    return false;

                MPCF.ShowSuccessMessage(out_node, false);
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("Manage_Queue() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private void frmWIPManageQueue_Load(object sender, EventArgs e)
        {
            spdQueue_Sheet1.Columns[(int)QUE.ORDER_ID].Visible = false;
            spdQueue_Sheet1.Columns[(int)QUE.OPER].Visible = false;
        }

        private void cdvLineGroup_CodeViewButtonClick(object sender, EventArgs e)
        {
            BICF.ViewLineGroup(cdvLineGroup);
        }

        private void cdvLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            BICF.ViewLine(cdvLine, MPCF.Trim(cdvLineGroup.Tag));
        }

        private void cdvResource_CodeViewButtonClick(object sender, EventArgs e)
        {
            BICF.ViewResource(cdvResource, MPCF.Trim(cdvLineGroup.Tag), MPCF.Trim(cdvLine.Tag), "");
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (View_Queue())
                MPCF.ShowMessageClear();
        }

        private void spdQueue_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            double d_remain_qty = 0;
            double d_adj_qty = 0;
            double d_adj_af_qty = 0;

            if (e.Column == (int)QUE.ADJ_QTY)
            {
                spdQueue_Sheet1.Cells[e.Row, (int)QUE.SEL].Value = true;

                d_remain_qty = MPCF.ToDbl(spdQueue_Sheet1.Cells[e.Row, (int)QUE.REMAIN_QTY].Value);
                d_adj_qty = MPCF.ToDbl(spdQueue_Sheet1.Cells[e.Row, (int)QUE.ADJ_QTY].Value);

                d_adj_af_qty = d_remain_qty - d_adj_qty;

                if (d_adj_af_qty < 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(416), MSG_LEVEL.ERROR, false);
                }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (!Check_Data())
                return;

            if (Manage_Queue())
                View_Queue();
        }

        private void spdQueue_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            double d_remain_qty = 0;
            double d_adj_qty = 0;
            double d_adj_af_qty = 0;

            if (e.Column == (int)QUE.ADJ_TYPE)
            {
                if (spdQueue_Sheet1.Cells[e.Row, (int)QUE.ADJ_TYPE].Text == "Unload")
                {
                    spdQueue_Sheet1.Cells[e.Row, (int)QUE.ADJ_QTY].Locked = true;
                }
                else
                {
                    spdQueue_Sheet1.Cells[e.Row, (int)QUE.ADJ_QTY].Locked = false;
                }

                spdQueue_Sheet1.Cells[e.Row, (int)QUE.SEL].Value = true;
            }
            else if (e.Column == (int)QUE.ADJ_QTY)
            {
                if (spdQueue_Sheet1.Cells[e.Row, (int)QUE.ADJ_TYPE].Text == "")
                {
                    MPCF.ShowMessage(MPCF.GetMessage(417), MSG_LEVEL.ERROR, false);
                    BICF.SetPosition(spdQueue, e.Row, (int)QUE.ADJ_TYPE);
                }
                else if (spdQueue_Sheet1.Cells[e.Row, (int)QUE.ADJ_TYPE].Text == "Loss")
                {
                    d_remain_qty = MPCF.ToDbl(spdQueue_Sheet1.Cells[e.Row, (int)QUE.REMAIN_QTY].Value);
                    d_adj_qty = MPCF.ToDbl(spdQueue_Sheet1.Cells[e.Row, (int)QUE.ADJ_QTY].Value);

                    d_adj_af_qty = d_remain_qty - d_adj_qty;

                    if (d_adj_af_qty < 0)
                    {
                        MPCF.ShowMessage(MPCF.GetMessage(416), MSG_LEVEL.ERROR, false);
                        spdQueue_Sheet1.Cells[e.Row, (int)QUE.ADJ_AF_QTY].Value = "";
                        spdQueue_Sheet1.Cells[e.Row, (int)QUE.SEL].Value = false;
                    }
                    else
                    {
                        spdQueue_Sheet1.Cells[e.Row, (int)QUE.ADJ_AF_QTY].Value = d_adj_af_qty;
                        spdQueue_Sheet1.Cells[e.Row, (int)QUE.SEL].Value = true;
                    }
                }
            }
        }
    }
}
