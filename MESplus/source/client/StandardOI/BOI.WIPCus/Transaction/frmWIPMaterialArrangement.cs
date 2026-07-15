using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOI.CliFrx;
using SOI.DNM;
using SOI.OIFrx;
using BOI.OIFrx;

using Miracom.TRSCore;

// 선입선출 자재 정리
namespace BOI.WIPCus
{
    public partial class frmWIPMaterialArrangement : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        public frmWIPMaterialArrangement()
        {
            InitializeComponent();
        }

        private enum TARGET
        {
            SEL,
            LINE_GROUP_DESC,
            LINE_ID_DESC,
            RES_ID_DESC,
            LOT_ID,
            MAT_ID,
            MAT_ID_DESC,
            ADJ_QTY,
            UNIT,
            LINE_GROUP,
            LINE_ID,
            RES_ID,
            LOAD_TIME,
            LAST_ARRANGE_TIME,
            HIST_SEQ,
            SEQ_NUM
        }

        private enum DISTRIBUTE
        {
            LOT_ID,
            INV_MAT_ID,
            INV_MAT_DESC,
            ORDER_ID,
            MAT_ID,
            MAT_DESC,
            PROD_QTY,
            LOSS_QTY,
            DIST_RATE,
            ADJ_QTY,
            ROW_NUM,
            ROW_CNT,
            LOSS_RATE_CUM,
            LOSS_QTY_CUM,
            RES_ID,
            HIST_SEQ,
            SEQ_NUM
        }

        /// <summary>
        /// 정리대상 자재 목록 조회
        /// </summary>
        /// <returns></returns>
        private bool View_Material_To_Be_Arrange()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[6];
            DataTable dt = null;
            
            FarPoint.Win.Spread.CellType.CheckBoxCellType cbctSel = null;

            string s_sql = "";
            int i = 0;

            try
            {
                spdTarget_Sheet1.RowCount = 0;
                spdDistribute_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "FR_DATE";
                dvcArgu[1].sCondition_Value = dtFrDate.GetValueAsDateTime().ToString("yyyyMMdd");

                dvcArgu[2].sCondtion_ID = "TO_DATE";
                dvcArgu[2].sCondition_Value = dtToDate.GetValueAsDateTime().ToString("yyyyMMdd");

                dvcArgu[3].sCondtion_ID = "LINE_GROUP";
                dvcArgu[3].sCondition_Value = MPCF.Trim(cdvLineGroup.Tag);

                dvcArgu[4].sCondtion_ID = "LINE_ID";
                dvcArgu[4].sCondition_Value = MPCF.Trim(cdvLine.Tag);

                dvcArgu[5].sCondtion_ID = "RES_ID";
                dvcArgu[5].sCondition_Value = MPCF.Trim(cdvResource.Tag);

                if (TPDR.DirectViewOne(spdTarget, "CWIP2406-001", ref dt, false, false, dvcArgu, true, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                cbctSel = new FarPoint.Win.Spread.CellType.CheckBoxCellType();

                spdTarget_Sheet1.Columns.Add(0, 1);

                spdTarget_Sheet1.ColumnHeader.Cells[0, (int)TARGET.SEL].CellType = cbctSel;

                spdTarget_Sheet1.Columns[(int)TARGET.SEL].Width = 48;
                spdTarget_Sheet1.Columns[(int)TARGET.SEL].CellType = cbctSel;

                spdTarget_Sheet1.Columns[(int)TARGET.SEL].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                spdTarget_Sheet1.Columns[(int)TARGET.SEL].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                for (i = 1; i < spdTarget_Sheet1.ColumnCount; i++)
                {
                    spdTarget_Sheet1.Columns[i].Locked = true;
                    spdTarget_Sheet1.Columns[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                    spdTarget_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                }

                spdTarget_Sheet1.Columns[(int)TARGET.LOT_ID].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                spdTarget_Sheet1.Columns[(int)TARGET.ADJ_QTY].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                spdTarget_Sheet1.Columns[(int)TARGET.UNIT].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

                spdTarget_Sheet1.Columns[(int)TARGET.LINE_GROUP_DESC].Visible = false;
                spdTarget_Sheet1.Columns[(int)TARGET.LINE_GROUP].Visible = false;
                spdTarget_Sheet1.Columns[(int)TARGET.LINE_ID].Visible = false;
                spdTarget_Sheet1.Columns[(int)TARGET.RES_ID].Visible = false;
                spdTarget_Sheet1.Columns[(int)TARGET.LOAD_TIME].Visible = false;
                spdTarget_Sheet1.Columns[(int)TARGET.LAST_ARRANGE_TIME].Visible = false;
                spdTarget_Sheet1.Columns[(int)TARGET.HIST_SEQ].Visible = false;
                spdTarget_Sheet1.Columns[(int)TARGET.SEQ_NUM].Visible = false;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("View_Material_To_Be_Arrange() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 데이터의 유효성 검사
        /// </summary>
        /// <returns></returns>
        private bool Check_Data(string sKind)
        {
            int i = 0, j = 0, i_cnt = 0;
            int i_start_row = 0, i_end_row = 0, i_row_cnt = 0;
            double d_ajt_qty = 0, d_loss_sum = 0;

            try
            {
                if (spdTarget_Sheet1.RowCount == 0)
                {
                    // 정리대상 자재가 없습니다. 
                    MPCF.ShowMessage(MPCF.GetMessage(420), MSG_LEVEL.ERROR, false);
                    return false;
                }

                for (i = 0; i < spdTarget_Sheet1.RowCount; i++)
                {
                    if(spdTarget_Sheet1.Cells[i, (int)TARGET.SEL].Value != null)
                        if(Convert.ToBoolean(spdTarget_Sheet1.Cells[i, (int)TARGET.SEL].Value))
                            i_cnt++;
                }

                if (i_cnt == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(133), MSG_LEVEL.ERROR, false);
                    return false;
                }

                i = 0;

                if (sKind == "Process")
                {
                    while (true)
                    {
                        i_row_cnt = MPCF.ToInt(spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.ROW_CNT].Value);

                        i_start_row = i;
                        i_end_row = i + i_row_cnt;
                        d_ajt_qty = MPCF.ToDbl(spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.ADJ_QTY].Value);

                        d_loss_sum = 0;

                        for (j = i_start_row; j < i_end_row; j++)
                        {
                            d_loss_sum += MPCF.ToDbl(spdDistribute_Sheet1.Cells[j, (int)DISTRIBUTE.LOSS_QTY].Value);
                        }

                        if (d_ajt_qty != d_loss_sum)
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(425), MSG_LEVEL.ERROR, false);
                            BICF.SetPosition(spdDistribute, i_start_row, (int)DISTRIBUTE.LOSS_QTY);
                            return false;
                        }

                        if (i_end_row == spdDistribute_Sheet1.RowCount)
                        {
                            break;
                        }
                        else
                        {
                            i += i_row_cnt;
                        }
                    }
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
        /// 배부율 적용
        /// </summary>
        /// <returns></returns>
        private bool Apply_Distribution_Rate()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];
            DataTable dt = null;

            int i = 0, j = 0, i_row = 0;
            int i_row_cnt = 0;
            string s_sql = "";

            try
            {
                spdDistribute_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                for (i = 0; i < spdTarget_Sheet1.RowCount; i++)
                {
                    if (spdTarget_Sheet1.Cells[i, (int)TARGET.SEL].Text == "True")
                    {
                        dvcArgu[1].sCondtion_ID = "ASS_LOT_ID";
                        dvcArgu[1].sCondition_Value = spdTarget_Sheet1.Cells[i, (int)TARGET.LOT_ID].Text;

                        dvcArgu[2].sCondtion_ID = "TRAN_TIME";
                        dvcArgu[2].sCondition_Value = spdTarget_Sheet1.Cells[i, (int)TARGET.LAST_ARRANGE_TIME].Text;

                        dvcArgu[3].sCondtion_ID = "ADJ_QTY";
                        dvcArgu[3].sCondition_Value = spdTarget_Sheet1.Cells[i, (int)TARGET.ADJ_QTY].Text;

                        if (TPDR.GetDataOne("", ref dt, "CWIP2406-002", dvcArgu, false, false, ref s_sql) == false)
                        {
                            if (dt != null)
                                dt.Dispose();

                            GC.Collect();
                            return false;
                        }

                        i_row_cnt = dt.Rows.Count;

                        for (j = 0; j < dt.Rows.Count; j++)
                        {
                            i_row = spdDistribute_Sheet1.RowCount;
                            spdDistribute_Sheet1.RowCount++;

                            spdDistribute_Sheet1.Cells[i_row, (int)DISTRIBUTE.LOT_ID].Value = dt.Rows[j]["ASS_LOT_ID"];
                            spdDistribute_Sheet1.Cells[i_row, (int)DISTRIBUTE.INV_MAT_ID].Value = dt.Rows[j]["C_MAT_ID"];
                            spdDistribute_Sheet1.Cells[i_row, (int)DISTRIBUTE.INV_MAT_DESC].Value = dt.Rows[j]["C_MAT_DESC"];

                            spdDistribute_Sheet1.Cells[i_row, (int)DISTRIBUTE.LOT_ID].Tag = dt.Rows[j]["ASS_LOT_ID"];
                            spdDistribute_Sheet1.Cells[i_row, (int)DISTRIBUTE.ORDER_ID].Value = dt.Rows[j]["ORDER_ID"];
                            spdDistribute_Sheet1.Cells[i_row, (int)DISTRIBUTE.MAT_ID].Value = dt.Rows[j]["P_MAT_ID"];
                            spdDistribute_Sheet1.Cells[i_row, (int)DISTRIBUTE.MAT_DESC].Value = dt.Rows[j]["P_MAT_DESC"];
                            spdDistribute_Sheet1.Cells[i_row, (int)DISTRIBUTE.PROD_QTY].Value = dt.Rows[j]["PROD_QTY"];
                            spdDistribute_Sheet1.Cells[i_row, (int)DISTRIBUTE.LOSS_QTY].Value = dt.Rows[j]["LOSS_QTY"];
                            spdDistribute_Sheet1.Cells[i_row, (int)DISTRIBUTE.LOSS_QTY].Tag = dt.Rows[j]["LOSS_QTY"];
                            spdDistribute_Sheet1.Cells[i_row, (int)DISTRIBUTE.DIST_RATE].Value = dt.Rows[j]["DISTIBUTE_RATE"];

                            spdDistribute_Sheet1.Cells[i_row, (int)DISTRIBUTE.ADJ_QTY].Value = spdTarget_Sheet1.Cells[i, (int)TARGET.ADJ_QTY].Value;
                            spdDistribute_Sheet1.Cells[i_row, (int)DISTRIBUTE.ROW_CNT].Value = i_row_cnt;
                            spdDistribute_Sheet1.Cells[i_row, (int)DISTRIBUTE.ROW_NUM].Value = j;
                            spdDistribute_Sheet1.Cells[i_row, (int)DISTRIBUTE.RES_ID].Value = spdTarget_Sheet1.Cells[i, (int)TARGET.RES_ID].Value;
                            spdDistribute_Sheet1.Cells[i_row, (int)DISTRIBUTE.HIST_SEQ].Value = spdTarget_Sheet1.Cells[i, (int)TARGET.HIST_SEQ].Value;
                            spdDistribute_Sheet1.Cells[i_row, (int)DISTRIBUTE.SEQ_NUM].Value = spdTarget_Sheet1.Cells[i, (int)TARGET.SEQ_NUM].Value;
                        }

                        MPCF.FitColumnHeader(spdDistribute);
                    }
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("Apply_Distribution_Rate() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 선입 선출 자재 정리
        /// </summary>
        /// <returns></returns>
        private bool Arrange_Material()
        {
            TRSNode in_node = new TRSNode("Arrange_Material_In");
            TRSNode out_node = new TRSNode("Arrange_Material_Out");
            TRSNode mat_list;
            TRSNode dist_list;

            int i = 0, j = 0;
            int i_row_cnt = 0;
            int i_start_row = 0, i_end_row = 0;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                while (true)
                {
                    i_row_cnt = MPCF.ToInt(spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.ROW_CNT].Value);

                    i_start_row = i;
                    i_end_row = i + i_row_cnt;

                    mat_list = in_node.AddNode("MAT_LIST");
                    mat_list.AddString("INV_MAT_ID", spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.MAT_ID].Value);
                    mat_list.AddDouble("ADJ_QTY", spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.ADJ_QTY].Value);
                    mat_list.AddString("RES_ID", spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.RES_ID].Value);
                    mat_list.AddString("LOT_ID", spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.LOT_ID].Text);
                    mat_list.AddInt("HIST_SEQ", spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.HIST_SEQ].Text);
                    mat_list.AddInt("SEQ_NUM", spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.SEQ_NUM].Text);

                    i_start_row = i;

                    for (j = i_start_row; j < i_end_row; j++)
                    {
                        dist_list = mat_list.AddNode("DIST_LIST");
                        dist_list.AddString("ORDER_ID", spdDistribute_Sheet1.Cells[j, (int)DISTRIBUTE.ORDER_ID].Value);
                        dist_list.AddString("MAT_ID", spdDistribute_Sheet1.Cells[j, (int)DISTRIBUTE.MAT_ID].Value);
                        dist_list.AddDouble("DIST_QTY", spdDistribute_Sheet1.Cells[j, (int)DISTRIBUTE.LOSS_QTY].Value);
                        dist_list.AddDouble("DIST_RATE", spdDistribute_Sheet1.Cells[j, (int)DISTRIBUTE.DIST_RATE].Value);
                    }

                    if (i_end_row == spdDistribute_Sheet1.RowCount)
                        break;
                    else
                        i += i_row_cnt;
                }

                if (MPCF.CallService("BWIP", "BWIP_Arrange_Material_Of_Resource", in_node, ref out_node) == false)
                    return false;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("Arrange_Material() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 배부율 적용 목록에서 선택한 자재의 배부수량을 집계하여 화면에 표시한다.
        /// </summary>
        private void Summary_Distribute_Qty()
        {
            int i = 0;
            int i_row = 0;
            int i_start_row = 0;
            int i_end_row = 0;
            int i_row_cnt = 0;
            double d_loss_sum = 0;

            if (spdDistribute_Sheet1.RowCount > 0)
            {
                i_row = spdDistribute_Sheet1.ActiveRowIndex;
                i_start_row = MPCF.ToInt(spdDistribute_Sheet1.Cells[i_row, (int)DISTRIBUTE.ROW_NUM].Value);
                i_row_cnt = MPCF.ToInt(spdDistribute_Sheet1.Cells[i_row, (int)DISTRIBUTE.ROW_CNT].Value);
                i_start_row = i_row - i_start_row;

                i_end_row = i_start_row + i_row_cnt;

                for (i = i_start_row; i < i_end_row; i++)
                    d_loss_sum += MPCF.ToDbl(spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.LOSS_QTY].Value);

                lblSum.Text = d_loss_sum.ToString("#,0.00");
            }
            else
            {
                lblSum.Text = "";
            }
        }

        private void frmWIPMaterialArrangement_Load(object sender, EventArgs e)
        {
            dtFrDate.Value = DateTime.Now.AddDays(-6);
            dtToDate.Value = DateTime.Now;

            spdTarget_Sheet1.Columns[(int)TARGET.LINE_GROUP].Visible = false;
            spdTarget_Sheet1.Columns[(int)TARGET.LINE_ID].Visible = false;
            spdTarget_Sheet1.Columns[(int)TARGET.RES_ID].Visible = false;
            spdTarget_Sheet1.Columns[(int)TARGET.LOAD_TIME].Visible = false;
            spdTarget_Sheet1.Columns[(int)TARGET.LAST_ARRANGE_TIME].Visible = false;
            spdTarget_Sheet1.Columns[(int)TARGET.HIST_SEQ].Visible = false;
            spdTarget_Sheet1.Columns[(int)TARGET.SEQ_NUM].Visible = false;
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
            lblSum.Text = "";
            View_Material_To_Be_Arrange();
            MPCF.ShowMessageClear();
        }

        private void spdTarget_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            int i_row = 0, i_col = 0;

            if (e.Column == (int)TARGET.SEL)
            {
                while (true)
                {
                    if (spdTarget_Sheet1.Cells[e.Row, e.Column].Text == "False")
                    {
                        spdDistribute.Search(0, spdTarget_Sheet1.Cells[e.Row, (int)TARGET.LOT_ID].Text, true, true, false, false, 0, (int)DISTRIBUTE.LOT_ID, ref i_row, ref i_col);
                        if (i_row > -1)
                            spdDistribute_Sheet1.Rows[i_row].Remove();
                        else
                            break;
                    }
                    else
                        break;
                }
            }
        }

        private void spdTarget_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader && e.Column == (int)TARGET.SEL)
            {
                BICF.CheckSpreadCell(spdTarget, 0, (int)TARGET.SEL, true);

                int i = 0;
                FarPoint.Win.FpCheckBox chk = new FarPoint.Win.FpCheckBox();
                for (i = 0; i < spdTarget_Sheet1.RowCount; i++)
                {
                    
                    chk = ((FarPoint.Win.FpCheckBox)spdTarget_Sheet1.Cells[i, 0].CellType);
                    spdTarget_ButtonClicked(sender, new FarPoint.Win.Spread.EditorNotifyEventArgs(e.View, null, i, 0));
                }
            }
        }

        private void btnDistribute_Click(object sender, EventArgs e)
        {
            lblSum.Text = "";
            if (!Check_Data("Distribute"))
                return;

            if (!Apply_Distribution_Rate())
                return;

            Summary_Distribute_Qty();

            MPCF.ShowMessageClear();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (!Check_Data("Process"))
                return;

            if (!Arrange_Material())
                return;

            if (!View_Material_To_Be_Arrange())
                return;

            MPCF.ShowMessageClear();
        }

        private void spdDistribute_EditModeOff(object sender, EventArgs e)
        {
            int i = 0;
            int i_row = 0;
            int i_start_row = 0, i_end_row = 0;
            double d_adj_qty = 0;
            double d_loss_rate = 0;
            double d_loss_qty_cum = 0;
            double d_loss_rate_cum = 0;

            try
            {
                i_row = spdDistribute_Sheet1.ActiveRowIndex;
                i_start_row = MPCF.ToInt(spdDistribute_Sheet1.Cells[i_row, (int)DISTRIBUTE.ROW_NUM].Value);
                //i_end_row = MPCF.ToInt(spdDistribute_Sheet1.Cells[i_row, (int)DISTRIBUTE.END_ROW].Value);
                d_adj_qty = MPCF.ToDbl(spdDistribute_Sheet1.Cells[i_row, (int)DISTRIBUTE.ADJ_QTY].Value);

                for (i = i_start_row; i < i_end_row + 1; i++)
                {
                    d_loss_rate = Math.Round(MPCF.ToDbl(spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.LOSS_QTY].Value) / d_adj_qty * 100, 3);
                    if (d_loss_rate_cum < 100)
                        d_loss_rate_cum += d_loss_rate;
                    
                    if (d_loss_qty_cum < d_adj_qty)
                        d_loss_qty_cum += MPCF.ToDbl(spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.LOSS_QTY].Value);

                    spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.DIST_RATE].Value = d_loss_rate;
                    spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.LOSS_QTY_CUM].Value = d_loss_qty_cum;
                    spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.LOSS_RATE_CUM].Value = d_loss_rate_cum;

                    if ((i_end_row - i_start_row) > 0)
                    {
                        if (d_loss_rate_cum > 100)
                        {
                            spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.DIST_RATE].Value = 100 - MPCF.ToDbl(spdDistribute_Sheet1.Cells[i - 1, (int)DISTRIBUTE.LOSS_RATE_CUM].Value);
                            spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.LOSS_RATE_CUM].Value = 100;
                            d_loss_rate_cum = 100;
                        }
                        else if (d_loss_rate_cum < 100 && i == i_end_row)
                        {
                            spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.DIST_RATE].Value = 100 - MPCF.ToDbl(spdDistribute_Sheet1.Cells[i - 1, (int)DISTRIBUTE.LOSS_RATE_CUM].Value);
                            spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.LOSS_RATE_CUM].Value = 100;
                            d_loss_rate_cum = 100;
                        }

                        if (d_loss_qty_cum > d_adj_qty)
                        {
                            spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.LOSS_QTY].Value = d_adj_qty - MPCF.ToDbl(spdDistribute_Sheet1.Cells[i - 1, (int)DISTRIBUTE.LOSS_QTY_CUM].Value);
                            spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.LOSS_QTY_CUM].Value = d_adj_qty;
                            d_loss_qty_cum = d_adj_qty;
                        }
                        else if (d_loss_qty_cum < d_adj_qty && i == i_end_row)
                        {
                            spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.LOSS_QTY].Value = d_adj_qty - MPCF.ToDbl(spdDistribute_Sheet1.Cells[i - 1, (int)DISTRIBUTE.LOSS_QTY_CUM].Value);
                            spdDistribute_Sheet1.Cells[i, (int)DISTRIBUTE.LOSS_QTY_CUM].Value = d_adj_qty;
                            d_loss_qty_cum = d_adj_qty;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("spdDistribute_EditModeOff() : " + ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdDistribute_EnterCell(object sender, FarPoint.Win.Spread.EnterCellEventArgs e)
        {
            // 배부율 집계
            Summary_Distribute_Qty();
        }
    }
}
