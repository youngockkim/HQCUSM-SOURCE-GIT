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

namespace SOI.Solar
{
    public partial class frmCUSTranDefectLotInput : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        #region [Property]

        private bool bIsShown = false;
        const int ENTER = 13;

        #endregion

        public frmCUSTranDefectLotInput()
        {
            InitializeComponent();
        }

        public enum COL
        {

        }

        /// <summary>
        /// View Lot
        /// </summary>
        /// <param name="sLotID"></param>
        /// <returns></returns>
        private bool Tran_Lot_Input(string sLotID)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));
                in_node.AddString("TO_OPER", MPCF.Trim(cdvOper.Text));

                if (MPCF.CallService("CUS", "CWIP_Tran_Defect_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                btnView.PerformClick();

                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ViewLotInfo(string sLotID)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LOT_IN");
                TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", sLotID);

                if (MPCF.CallService("CUS", "CUS_View_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (spdLotInfo.SetDataToScreen(out_node) == false)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 작업지시 조회
        /// </summary>
        /// <returns></returns>
        private bool View_Work_Order()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[8];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;

            try
            {
                //spdWorkOrder_Sheet1.RowCount = 0;

                //dvcArgu[0].sCondtion_ID = "FACTORY";
                //dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                //dvcArgu[1].sCondtion_ID = "FR_DATE";
                //dvcArgu[1].sCondition_Value = dtFrDate.GetValueAsDateTime().ToString("yyyyMMdd");

                //dvcArgu[2].sCondtion_ID = "TO_DATE";
                //dvcArgu[2].sCondition_Value = dtToDate.GetValueAsDateTime().ToString("yyyyMMdd");

                //dvcArgu[5].sCondtion_ID = "ORDER_STATUS";
                //dvcArgu[5].sCondition_Value = MPCF.Trim(rbStatus.Items[rbStatus.CheckedIndex].DataValue) == "A" ? "" : MPCF.Trim(rbStatus.Items[rbStatus.CheckedIndex].DataValue);

                //dvcArgu[6].sCondtion_ID = "MAT_ID";
                //dvcArgu[6].sCondition_Value = "";

                //if (TPDR.GetDataOne("", ref dt, "COM0000-005", dvcArgu, false, false, ref s_sql) == false)
                //{
                //    if (dt != null)
                //        dt.Dispose();

                //    GC.Collect();
                //    return false;
                //}

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    //spdWorkOrder_Sheet1.RowCount++;

                    //spdWorkOrder_Sheet1.Cells[i, (int)ORD.ORDER_DATE].Value = MPCF.MakeDateFormat(dt.Rows[i]["ORD_DATE"].ToString(), DATE_TIME_FORMAT.DATE);
                    //spdWorkOrder_Sheet1.Cells[i, (int)ORD.ORDER_ID].Value = dt.Rows[i]["ORDER_ID"].ToString();
                    //spdWorkOrder_Sheet1.Cells[i, (int)ORD.ORDER_TYPE].Value = dt.Rows[i]["ORDER_TYPE_DESC"].ToString();
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "PROCESS":

                        if (string.IsNullOrEmpty(txtLotID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Lot ID]"));
                            MPCF.SetFocus(txtLotID);
                            return false;
                        }

                        if (string.IsNullOrEmpty(cdvOper.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Oper]"));
                            MPCF.SetFocus(cdvOper);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewLotInfo(txtLotID.Text) == false)
                {
                    MPCF.SetFocus(txtLotID);
                    return;
                }

                MPCF.SetFocus(txtLotID);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void frmCUSTranDefectLotInput_Load(object sender, EventArgs e)
        {
            spdLotInfo.InitFlexibleScreen();
            spdLotInfo.ScreenSpread.Tag = "Change Cell";

            if (spdLotInfo.LoadDesign("INV_LOT_INFO") == false)
                return;

            MPCF.ConvertCaption(this);

            if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
            {
                txtLotID.Text = MPGV.gsCurrentLot_ID;
                btnView.PerformClick();
            }
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER && MPCF.Trim(txtLotID.Text) != "")
                {
                    txtLotID.Text = MPCF.ToUpper(txtLotID.Text); // 일괄 대문자

                    if (ViewLotInfo(txtLotID.Text) == false)
                    {
                        MPCF.SetFocus(txtLotID);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvLossCode_CodeViewButtonClick(object sender, EventArgs e)
        {

        }

        private void frmCUSTranDefectLotInput_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                bIsShown = true;

                MPCF.SetFocus(txtLotID);
            }
        }

        private void cdvOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[1];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                // CodeView Column Header Setup
                string[] header = new string[] { "Code", "Code Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "OPER", "OPER_DESC" };

                // Show
                cdvOper.Text = cdvOper.Show(cdvOper, "Code Desc", "VIEW_OPER_LIST", dvcArgu, display, header, "OPER", -1);

                if (MPCF.Trim(cdvOper.Text) != "")
                {
                    if (cdvOper.returnDatas != null && cdvOper.returnDatas.Count > 0)
                    {
                        cdvOper.Text = cdvOper.returnDatas[0];
                        txtOperDesc.Text = cdvOper.returnDatas[1];
                    }
                }
                else
                {
                    cdvOper.Text = "";
                    txtOperDesc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("PROCESS") == false)
                    return;

                if (Tran_Lot_Input(MPCF.Trim(spdLotInfo.ScreenSpread.ActiveSheet.Cells[0, 1].Text)) == true)
                {
                    MPCF.SetFocus(txtLotID);
                    txtLotID.Text = "";
                    //cdvOper.Text = "";
                    //cdvOper.Tag = string.Empty;
                    //txtOperDesc.Text = "";
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnLotEnd_Click(object sender, EventArgs e)
        {
            try
            {
                BICF.OpenMenu("SOI2006");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            } 
        }

        private void btnLossRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLotID.Text) == false)
                {
                    MPGV.gsCurrentLot_ID = txtLotID.Text;
                }

                //모듈내 불량자재등록 화면
                BICF.OpenMenu("SOI2022");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            } 
        }
    }
}
