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
using BOI.OIFrx.BOIBaseForm;
using BOI.INVCus;
using BOI.OIFrx;
using SOI.DNM;

// 포장 설비 지정
namespace BOI.WIPCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmWIPSetupPackResource : BOIBasePopup02
    {        
        public frmWIPSetupPackResource()
        {
            InitializeComponent();
        }

        private enum ORD
        {
            ORDER_ID,
            ORD_DATE,
            MAT_ID,
            MAT_DESC,
            BOM_TYPE,
            ORD_QTY,
            RLT_QTY,
            UNIT,
            LINE,
            RES_ID
        }
        
        private enum AV_TANK
        {
            RES_ID,
            RES_NO,
            MAT_ID,
            MAT_DESC,
            QTY
        }

        private enum AS_TANK
        {
            RES_ID,
            RES_NO,
            MAT_ID,
            MAT_DESC,
            QTY
        }

        public List<string> s_order_list;

        private bool View_Order(List<string> s_order_list)
        {
            TRSNode in_node = new TRSNode("View_Order_In");
            TRSNode out_node = new TRSNode("View_Order_Out");

            int i = 0;
            int i_row = 0;

            try
            {
                for (i = 0; i < s_order_list.Count; i++)
                {
                    in_node.Init();
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '2';
                    in_node.AddString("ORDER_ID", s_order_list[i]);

                    if (MPCF.CallService("BWIP", "BWIP_View_Order_List", in_node, ref out_node) == false)
                        return false;

                    i_row = spdWorkOrder_Sheet1.RowCount;
                    spdWorkOrder_Sheet1.RowCount++;

                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.ORDER_ID].Value = out_node.GetString("ORDER_ID");
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.ORD_DATE].Value = MPCF.MakeDateFormat(out_node.GetString("ORD_DATE"), DATE_TIME_FORMAT.DATE);
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.MAT_ID].Value = out_node.GetString("MAT_ID");
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.MAT_DESC].Value = out_node.GetString("MAT_DESC");
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.BOM_TYPE].Value = out_node.GetChar("MAT_BOM_TYPE");
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.ORD_QTY].Value = out_node.GetDouble("ORD_QTY");
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.RLT_QTY].Value = out_node.GetDouble("PROD_QTY");
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.UNIT].Value = out_node.GetString("UNIT_1");
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.LINE].Value = out_node.GetString("LINE_DESC");
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.LINE].Tag = out_node.GetString("LINE_ID");
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.RES_ID].Value = out_node.GetString("RES_DESC");
                    spdWorkOrder_Sheet1.Cells[0, (int)ORD.RES_ID].Tag = out_node.GetString("RES_ID");
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 사용 가능한 설비 가져오기
        /// </summary>
        /// <param name="s_resource"></param>
        /// <returns></returns>
        private bool View_Available_Tank_List(string s_line, string s_resource)
        {
            TRSNode in_node = new TRSNode("View_Availabe_Tank_List_In");
            TRSNode out_node = new TRSNode("View_Available_Tank_List_Out");

            int i = 0;

            try
            {
                spdAvailableTank_Sheet1.RowCount = 0;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", s_line);
                in_node.AddString("RES_ID", s_resource);

                if (MPCF.CallService("BRAS", "BRAS_View_Available_Tank_List", in_node, ref out_node) == false)
                    return false;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    spdAvailableTank_Sheet1.RowCount++;

                    spdAvailableTank_Sheet1.Cells[i, (int)AV_TANK.RES_ID].Value = out_node.GetList(0)[i].GetString("RES_DESC");
                    spdAvailableTank_Sheet1.Cells[i, (int)AV_TANK.RES_ID].Tag = out_node.GetList(0)[i].GetString("RES_ID");
                    spdAvailableTank_Sheet1.Cells[i, (int)AV_TANK.RES_NO].Value = out_node.GetList(0)[i].GetString("RES_NO");
                    spdAvailableTank_Sheet1.Cells[i, (int)AV_TANK.MAT_ID].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                    spdAvailableTank_Sheet1.Cells[i, (int)AV_TANK.MAT_DESC].Value = out_node.GetList(0)[i].GetString("MAT_DESC");
                    spdAvailableTank_Sheet1.Cells[i, (int)AV_TANK.QTY].Value = out_node.GetList(0)[i].GetDouble("QTY");
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("View_Available_Tank_List() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 충진기에 연결된 설비 조회
        /// </summary>
        /// <param name="s_resource"></param>
        /// <returns></returns>
        private bool View_Assigned_Tank_List(string s_line, string s_resource)
        {
            TRSNode in_node = new TRSNode("View_Assigned_Tank_List_In");
            TRSNode out_node = new TRSNode("View_Assigned_Tank_List_Out");

            int i = 0;

            try
            {
                spdUseTank_Sheet1.RowCount = 0;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", s_line);
                in_node.AddString("RES_ID", s_resource);

                if (MPCF.CallService("BRAS", "BRAS_View_Assigned_Tank_List", in_node, ref out_node) == false)
                    return false;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    spdUseTank_Sheet1.RowCount++;

                    spdUseTank_Sheet1.Cells[i, (int)AS_TANK.RES_ID].Value = out_node.GetList(0)[i].GetString("RES_DESC");
                    spdUseTank_Sheet1.Cells[i, (int)AS_TANK.RES_ID].Tag = out_node.GetList(0)[i].GetString("RES_ID");
                    spdUseTank_Sheet1.Cells[i, (int)AS_TANK.RES_NO].Value = out_node.GetList(0)[i].GetString("RES_NO");
                    spdUseTank_Sheet1.Cells[i, (int)AS_TANK.MAT_ID].Value = out_node.GetList(0)[i].GetString("MAT_ID");
                    spdUseTank_Sheet1.Cells[i, (int)AS_TANK.MAT_DESC].Value = out_node.GetList(0)[i].GetString("MAT_DESC");
                    spdUseTank_Sheet1.Cells[i, (int)AS_TANK.QTY].Value = out_node.GetList(0)[i].GetDouble("QTY");
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("View_Assigned_Tank_List() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return false;
        }

        /// <summary>
        /// 데이터 유효성 검사
        /// </summary>
        /// <returns></returns>
        private bool Check_Data()
        {
            try
            {
                if (spdWorkOrder.ActiveSheet.RowCount == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(410), MSG_LEVEL.ERROR, false);
                    return false;
                }

                if (cdvResource.Text == "")
                {
                    MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, false);
                    cdvResource.Focus();
                    return false;
                }

                if (spdUseTank_Sheet1.RowCount == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(441), MSG_LEVEL.ERROR, false);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("Check_Data() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 충진기에 Tank를 지정한다.
        /// </summary>
        /// <returns></returns>
        private bool Assign_Tank()
        {
            TRSNode in_node = new TRSNode("Assign_Tank_In");
            TRSNode out_node = new TRSNode("Assign_Tank_In");

            string s_order_id = "";
            string s_line_id = "";

            int i_cur_row = 0;

            try
            {
                i_cur_row = spdWorkOrder.ActiveSheet.ActiveRowIndex;
                s_order_id = spdWorkOrder.ActiveSheet.Cells[i_cur_row, (int)ORD.ORDER_ID].Text;
                s_line_id = MPCF.Trim(spdWorkOrder.ActiveSheet.Cells[i_cur_row, (int)ORD.LINE].Tag);

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ORDER_ID", s_order_id);
                in_node.AddString("LINE_ID", s_line_id);
                in_node.AddString("RES_ID", cdvResource.Tag);
                in_node.AddString("TANK_ID", spdUseTank_Sheet1.Cells[0, (int)AV_TANK.RES_ID].Tag);

                if (MPCF.CallService("BRAS", "BRAS_Assign_Tank_To_Filler", in_node, ref out_node) == false)
                    return false;

                MPCF.ShowSuccessMessage(out_node, false);
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("Assign_Tank() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempBOIBaseForm02_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);

            View_Order(s_order_list);
        }

        private void cdvResource_CodeViewButtonClick(object sender, EventArgs e)
        {
            int i_row = 0;
            string s_order_id = "";

            if (spdWorkOrder.ActiveSheet.RowCount == 0)
            {
                MPCF.ShowMessage(MPCF.GetMessage(410), MSG_LEVEL.ERROR, false);
                return;
            }

            i_row = spdWorkOrder.ActiveSheet.ActiveRowIndex = 0;

            s_order_id = MPCF.Trim(spdWorkOrder.ActiveSheet.Cells[i_row, (int)ORD.LINE].Tag);

            BICF.ViewResource(cdvResource, "", s_order_id, "");
            if (cdvResource.Tag != null)
            {
                if (cdvResource.Tag.ToString() != "")
                {
                    View_Available_Tank_List(s_order_id, MPCF.Trim(cdvResource.Tag));
                    View_Assigned_Tank_List(s_order_id, MPCF.Trim(cdvResource.Tag));
                }
            }
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            int i_row = 0;
            int i_cur_row = 0;

            if (spdAvailableTank_Sheet1.RowCount == 0)
                return;

            if (spdUseTank_Sheet1.RowCount > 0)
            {
                MPCF.ShowMessage(MPCF.GetMessage(444), MSG_LEVEL.ERROR, false);
                return;
            }

            i_cur_row = spdAvailableTank_Sheet1.ActiveRowIndex;
            i_row = spdUseTank_Sheet1.RowCount;
            spdUseTank_Sheet1.RowCount++;

            spdUseTank_Sheet1.Cells[i_row, (int)AS_TANK.RES_ID].Value = spdAvailableTank_Sheet1.Cells[i_cur_row, (int)AV_TANK.RES_ID].Value;
            spdUseTank_Sheet1.Cells[i_row, (int)AS_TANK.RES_ID].Tag = spdAvailableTank_Sheet1.Cells[i_cur_row, (int)AV_TANK.RES_ID].Tag;
            spdUseTank_Sheet1.Cells[i_row, (int)AS_TANK.RES_NO].Value = spdAvailableTank_Sheet1.Cells[i_cur_row, (int)AV_TANK.RES_NO].Value;
            spdUseTank_Sheet1.Cells[i_row, (int)AS_TANK.MAT_ID].Value = spdAvailableTank_Sheet1.Cells[i_cur_row, (int)AV_TANK.MAT_ID].Value;
            spdUseTank_Sheet1.Cells[i_row, (int)AS_TANK.MAT_DESC].Value = spdAvailableTank_Sheet1.Cells[i_cur_row, (int)AV_TANK.MAT_DESC].Value;
            spdUseTank_Sheet1.Cells[i_row, (int)AS_TANK.QTY].Value = spdAvailableTank_Sheet1.Cells[i_cur_row, (int)AV_TANK.QTY].Value;
        }

        private void btnDetach_Click(object sender, EventArgs e)
        {
            if (spdUseTank_Sheet1.RowCount == 0)
                return;

            spdUseTank_Sheet1.RemoveRows(spdUseTank_Sheet1.ActiveRowIndex, 1);
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (Check_Data())
            {
                Assign_Tank();
            }
        }
    }
}
