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
    public partial class frmWIPAssignPackResource : BOIBasePopup02
    {        
        public frmWIPAssignPackResource()
        {
            InitializeComponent();
        }

        private enum AV_TANK
        {
            RES_NO,
            QTY,
            RES_DESC,
            RES_ID
        }

        private enum AS_TANK
        {
            RES_NO,
            QTY,
            RES_DESC,
            RES_ID
        }

        public string s_line_id = "";

        BOI.OIFrx.BOIControls.H101Tuner ResTuner = null;
        public delegate void ResourceReceivedHandler(TRSNode node);
        ResourceReceivedHandler resRecvHandler;

        /// <summary>
        /// 사용 가능한 설비 가져오기
        /// </summary>
        /// <param name="s_resource"></param>
        /// <returns></returns>
        private bool View_Available_Tank_List()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;

            int i = 0;

            try
            {
                spdAvailableTank_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "LINE_ID";
                dvcArgu[1].sCondition_Value = s_line_id;

                if (TPDR.GetDataOne("", ref dt, "CWIP2408-001", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdAvailableTank_Sheet1.RowCount++;

                    spdAvailableTank_Sheet1.Cells[i, (int)AV_TANK.RES_ID].Value =   dt.Rows[i]["RES_ID"];
                    spdAvailableTank_Sheet1.Cells[i, (int)AV_TANK.RES_DESC].Value =     dt.Rows[i]["RES_DESC"];
                    spdAvailableTank_Sheet1.Cells[i, (int)AV_TANK.RES_NO].Value =   dt.Rows[i]["RES_NO"];
                }

                MPCF.FitColumnHeader(spdAvailableTank);
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
        private bool View_Assigned_Tank_List()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;

            int i = 0;

            try
            {
                spdUseTank_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "RES_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(cdvResource.Tag);

                if (TPDR.GetDataOne("", ref dt, "CWIP2408-002", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdUseTank_Sheet1.RowCount++;

                    spdUseTank_Sheet1.Cells[i, (int)AS_TANK.RES_ID].Value = dt.Rows[i]["RES_ID"];
                    spdUseTank_Sheet1.Cells[i, (int)AS_TANK.RES_DESC].Value = dt.Rows[i]["RES_DESC"];
                    spdUseTank_Sheet1.Cells[i, (int)AS_TANK.RES_NO].Value = dt.Rows[i]["RES_NO"];
                }

                MPCF.FitColumnHeader(spdUseTank);
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
        private bool Assign_Tank(string sKind)
        {
            TRSNode in_node = new TRSNode("Assign_Tank_In");
            TRSNode out_node = new TRSNode("Assign_Tank_In");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.AddString("ORDER_ID", "");
                in_node.AddString("RES_ID", cdvResource.Tag);
                in_node.AddString("LINE_ID", s_line_id);

                if (sKind == "Attach")
                {
                    in_node.ProcStep = '1';
                    in_node.AddString("ATTACH_TANK_ID", spdAvailableTank_Sheet1.Cells[spdAvailableTank_Sheet1.ActiveRowIndex, (int)AV_TANK.RES_ID].Value);
                    in_node.AddDouble("INIT_QTY", spdAvailableTank_Sheet1.Cells[spdAvailableTank_Sheet1.ActiveRowIndex, (int)AV_TANK.QTY].Value);
                }
                else
                {
                    in_node.ProcStep = '2';
                    in_node.AddString("DETACH_TANK_ID", spdUseTank_Sheet1.Cells[0, (int)AS_TANK.RES_ID].Value);
                    in_node.AddDouble("ACTUAL_QTY", spdUseTank_Sheet1.Cells[0, (int)AS_TANK.QTY].Value);
                }                

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
            spdUseTank_Sheet1.Columns[(int)AS_TANK.RES_ID].Visible = false;
            spdAvailableTank_Sheet1.Columns[(int)AV_TANK.RES_ID].Visible = false;

            ResTuner = new BOI.OIFrx.BOIControls.H101Tuner();
            ResTuner.DataReceived += new BOI.OIFrx.BOIControls.H101DataReceivedEventHandler(ResTuner_DataReceived);
            resRecvHandler = new ResourceReceivedHandler(resRecvResult);
        }

        private void ResTuner_DataReceived(object sender, BOI.OIFrx.BOIControls.H101DataReceivedEventArgs e)
        {
            IAsyncResult result = BeginInvoke(resRecvHandler, e.Node);
            EndInvoke(result);
        }

        private void resRecvResult(TRSNode node)
        {
            try
            {
                View_Assigned_Tank_List();
                spdUseTank_Sheet1.Cells[0, (int)AS_TANK.QTY].Value = node.GetDouble("VALUE");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("ResTuner1_DataReceived()\n" + ex.Message);
                return;
            }
        }

        private void cdvResource_CodeViewButtonClick(object sender, EventArgs e)
        {
            BICF.ViewResource(cdvResource, "", s_line_id, "");
            if (cdvResource.Tag != null)
            {
                if (cdvResource.Tag.ToString() != "")
                {
                    View_Available_Tank_List();
                    View_Assigned_Tank_List();
                }

                if (ResTuner.isTuned)
                    ResTuner.PublishCUSMsgUnTune();

                ResTuner.Module = MPCF.Trim(cdvResource.Tag);
                ResTuner.Channel = MPCF.Trim(cdvResource.Tag);
                ResTuner.MultiCast = false;
                ResTuner.ServiceName = "BEIS_filler_to_tank_info";
                ResTuner.PublishCUSMsgTune();
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

            if (spdUseTank_Sheet1.RowCount > 0)
            {
                // CMN458 ERROR - 이미 설비가 지정되었습니다.
                MPCF.ShowMessage(MPCF.GetMessage(458), MSG_LEVEL.ERROR, true);
                return;
            }

            i_cur_row = spdAvailableTank_Sheet1.ActiveRowIndex;

            if (spdAvailableTank_Sheet1.Cells[i_cur_row, (int)AV_TANK.QTY].Value == null)
            {
                MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, true);
                spdAvailableTank.Focus();
                return;
            }

            if (MPCF.ToDbl(spdAvailableTank_Sheet1.Cells[i_cur_row, (int)AV_TANK.QTY].Value) == 0)
            {
                MPCF.ShowMessage(MPCF.GetMessage(114), MSG_LEVEL.ERROR, true);
                spdAvailableTank.Focus();
                return;
            }

            if (Assign_Tank("Attach"))
            {
                i_row = spdUseTank_Sheet1.RowCount;
                spdUseTank_Sheet1.RowCount++;

                spdUseTank_Sheet1.Cells[i_row, (int)AS_TANK.RES_ID].Value = spdAvailableTank_Sheet1.Cells[i_cur_row, (int)AV_TANK.RES_ID].Value;
                spdUseTank_Sheet1.Cells[i_row, (int)AS_TANK.RES_DESC].Value = spdAvailableTank_Sheet1.Cells[i_cur_row, (int)AV_TANK.RES_ID].Value;
                spdUseTank_Sheet1.Cells[i_row, (int)AS_TANK.RES_NO].Value = spdAvailableTank_Sheet1.Cells[i_cur_row, (int)AV_TANK.RES_NO].Value;
                spdUseTank_Sheet1.Cells[i_row, (int)AS_TANK.QTY].Value = spdAvailableTank_Sheet1.Cells[i_cur_row, (int)AV_TANK.QTY].Value;
            }            
        }

        private void btnDetach_Click(object sender, EventArgs e)
        {
            if (spdUseTank_Sheet1.RowCount == 0)
                return;

            if (spdUseTank_Sheet1.Cells[0, (int)AS_TANK.QTY].Value == null)
            {
                MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, true);
                spdUseTank.Focus();
                return;
            }

            if (MPCF.ToDbl(spdUseTank_Sheet1.Cells[0, (int)AS_TANK.QTY].Value) == 0)
            {
                MPCF.ShowMessage(MPCF.GetMessage(114), MSG_LEVEL.ERROR, true);
                spdUseTank.Focus();
                return;
            }

            if(Assign_Tank("Detach"))
                spdUseTank_Sheet1.RemoveRows(spdUseTank_Sheet1.ActiveRowIndex, 1);

        }

        private void frmWIPAssignPackResource_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.Alt == true && e.Shift == true && e.KeyCode == Keys.S)
            {
                spdUseTank_Sheet1.Columns[(int)AS_TANK.RES_ID].Visible = !spdUseTank_Sheet1.Columns[(int)AS_TANK.RES_ID].Visible;
                spdAvailableTank_Sheet1.Columns[(int)AV_TANK.RES_ID].Visible = !spdAvailableTank_Sheet1.Columns[(int)AV_TANK.RES_ID].Visible;
            }
        }

        private void frmWIPAssignPackResource_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ResTuner.isTuned)
                ResTuner.Dispose();
        }

        private void btnRequestResource_Click(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("Request_Tank_Info_In");
            TRSNode out_node = new TRSNode("Cmn_Out");

            try
            {
                if (cdvResource.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvResource.Focus();
                    return;
                }

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", s_line_id);
                in_node.AddString("RES_ID", MPCF.Trim(cdvResource.Tag));

                if (MPCF.CallService("BEIS", "BEIS_Request_Tank_Info", in_node, ref out_node) == false)
                    return;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("btnRequestResource_Click() : " + ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
    }
}
