using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using BOI.OIFrx;
using BOI.OIFrx.BOIBaseForm;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.DNM;
using SOI.CliFrx;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;

namespace SOI.Solar
{
    public partial class frmCUSTranBoxRecomposition : BOIBaseForm02
    {
        #region [Property]

        const int ENTER = 13;

        string sBoxID1 = string.Empty;
        string sBoxID2 = string.Empty;
        int iBoxCount1 = 0;
        int iBoxCount2 = 0;

        #endregion

        public frmCUSTranBoxRecomposition()
        {
            InitializeComponent();
        }

        private MenuInfoTag menuInfo;
        private frmPrintOptionPopup frmOption;
        public PrintOptionModel printOption;
        
        private enum COL_BOX
        {
            SELECT,
            NO,
            FG_ID,
            LOT_ID,
            MAT_ID,
            MAT_DESC,
            TRAN_TIME,
            TRAN_USER_ID
        }

        /// <summary>
        /// 사용 가능한 설비 가져오기
        /// </summary>
        /// <param name="s_resource"></param>
        /// <returns></returns>
        private bool View_Box_Lot_list_1()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;

            try
            {
                MPCF.ShowMessageClear();

                spdBoxID1.ActiveSheet.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$BOX_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(txtBoxID1.Text);

                dvcArgu[2].sCondtion_ID = "$FG_ID";
                dvcArgu[2].sCondition_Value = MPCF.Trim(txtFG_ID1.Text);

                if (TPDR.GetDataOne("", ref dt, "VIEW_BOX_LOT_LIST_1", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdBoxID1.ActiveSheet.RowCount++;
                    spdBoxID1.ActiveSheet.Cells[i, (int)COL_BOX.SELECT].Value = false;
                    spdBoxID1.ActiveSheet.Cells[i, (int)COL_BOX.NO].Value = dt.Rows[i]["NO"].ToString();
                    spdBoxID1.ActiveSheet.Cells[i, (int)COL_BOX.FG_ID].Value = dt.Rows[i]["FG_ID"].ToString();
                    spdBoxID1.ActiveSheet.Cells[i, (int)COL_BOX.LOT_ID].Value = dt.Rows[i]["LOT_ID"].ToString();
                    spdBoxID1.ActiveSheet.Cells[i, (int)COL_BOX.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    spdBoxID1.ActiveSheet.Cells[i, (int)COL_BOX.MAT_DESC].Value = dt.Rows[i]["MAT_DESC"].ToString();
                    spdBoxID1.ActiveSheet.Cells[i, (int)COL_BOX.TRAN_TIME].Value = dt.Rows[i]["CREATE_TIME"].ToString();
                    spdBoxID1.ActiveSheet.Cells[i, (int)COL_BOX.TRAN_USER_ID].Value = dt.Rows[i]["CREATE_USER_ID"].ToString();

                    if (i == 0)
                        txtBoxID1.Text = dt.Rows[i]["BOX_ID"].ToString();
                }

                MPCF.FitColumnHeader(spdBoxID1);

                if (txtBoxID1.Text == txtBoxID2.Text)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(456), MSG_LEVEL.ERROR, false);
                    txtBoxID1.Text = string.Empty;
                    spdBoxID1.ActiveSheet.RowCount = 0;
                    txtFG_ID1.Focus();
                    txtFG_ID1.SelectAll();
                    return false;
                }
                else
                {
                    sBoxID1 = MPCF.Trim(txtBoxID1.Text).Substring(0, MPCF.Trim(txtBoxID1.Text).Length - 5);
                    iBoxCount1 = MPCF.ToInt(MPCF.Trim(txtBoxID1.Text).Substring(MPCF.Trim(txtBoxID1.Text).Length - 5, 5));
                    txtBoxIDNew1.Text = MPCF.Trim(sBoxID1) + spdBoxID1.ActiveSheet.RowCount.ToString("00000");

                    txtFG_ID1.Text = string.Empty;
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
        private bool View_Box_Lot_list_2()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;

            try
            {
                MPCF.ShowMessageClear();

                spdBoxID2.ActiveSheet.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$BOX_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(txtBoxID2.Text);

                dvcArgu[2].sCondtion_ID = "$FG_ID";
                dvcArgu[2].sCondition_Value = MPCF.Trim(txtFG_ID2.Text);

                if (TPDR.GetDataOne("", ref dt, "VIEW_BOX_LOT_LIST_1", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdBoxID2.ActiveSheet.RowCount++;
                    spdBoxID2.ActiveSheet.Cells[i, (int)COL_BOX.SELECT].Value = false;
                    spdBoxID2.ActiveSheet.Cells[i, (int)COL_BOX.NO].Value = dt.Rows[i]["NO"].ToString();
                    spdBoxID2.ActiveSheet.Cells[i, (int)COL_BOX.FG_ID].Value = dt.Rows[i]["FG_ID"].ToString();
                    spdBoxID2.ActiveSheet.Cells[i, (int)COL_BOX.LOT_ID].Value = dt.Rows[i]["LOT_ID"].ToString();
                    spdBoxID2.ActiveSheet.Cells[i, (int)COL_BOX.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    spdBoxID2.ActiveSheet.Cells[i, (int)COL_BOX.MAT_DESC].Value = dt.Rows[i]["MAT_DESC"].ToString();
                    spdBoxID2.ActiveSheet.Cells[i, (int)COL_BOX.TRAN_TIME].Value = dt.Rows[i]["CREATE_TIME"].ToString();
                    spdBoxID2.ActiveSheet.Cells[i, (int)COL_BOX.TRAN_USER_ID].Value = dt.Rows[i]["CREATE_USER_ID"].ToString();

                    if (i == 0)
                        txtBoxID2.Text = dt.Rows[i]["BOX_ID"].ToString();
                }

                MPCF.FitColumnHeader(spdBoxID2);

                if (txtBoxID1.Text == txtBoxID2.Text)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(456), MSG_LEVEL.ERROR, false);
                    txtBoxID2.Text = string.Empty;
                    spdBoxID2.ActiveSheet.RowCount = 0;
                    txtFG_ID2.Focus();
                    txtFG_ID2.SelectAll();
                    return false;
                }
                else
                {
                    sBoxID2 = MPCF.Trim(txtBoxID2.Text).Substring(0, MPCF.Trim(txtBoxID2.Text).Length - 5);
                    iBoxCount2 = MPCF.ToInt(MPCF.Trim(txtBoxID2.Text).Substring(MPCF.Trim(txtBoxID2.Text).Length - 5, 5));
                    txtBoxIDNew2.Text = MPCF.Trim(sBoxID2) + spdBoxID2.ActiveSheet.RowCount.ToString("00000");

                    txtFG_ID2.Text = string.Empty;
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
        /// 데이터 유효성 검사
        /// </summary>
        /// <returns></returns>
        private bool Check_Data()
        {
            try
            {
                if (txtBoxID1.Text == "")
                {
                    MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, false);
                    txtBoxID1.Focus();
                    return false;
                }

                if (txtBoxID2.Text == "")
                {
                    MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, false);
                    txtBoxID2.Focus();
                    return false;
                }

                if(spdBoxID1.ActiveSheet.RowCount > CSGC.SOL_BOX_MAX_COUNT)
                {
                    MPCF.ShowMessage("BOX 기준 수량(" + CSGC.SOL_BOX_MAX_COUNT + ")을 초과 하였습니다.", MSG_LEVEL.ERROR, false);
                    return false;
                }

                if (spdBoxID2.ActiveSheet.RowCount > CSGC.SOL_BOX_MAX_COUNT)
                {
                    MPCF.ShowMessage("BOX 기준 수량(" + CSGC.SOL_BOX_MAX_COUNT + ")을 초과 하였습니다.", MSG_LEVEL.ERROR, false);
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
        /// 박스 재구성
        /// </summary>
        /// <returns></returns>
        private bool Update_Box_Lot(char c_Step)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");
            TRSNode box_lot_list1;
            TRSNode box_lot_list2;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = c_Step;

                txtBoxID1.Text = MPCF.Trim(txtBoxIDNew1.Text);
                txtBoxID2.Text = MPCF.Trim(txtBoxIDNew2.Text);

                in_node.AddString("BOX_ID", MPCF.Trim(txtBoxID1.Text));
                in_node.AddString("BOX_ID_2", MPCF.Trim(txtBoxID2.Text));

                for (int i = spdBoxID1.ActiveSheet.RowCount - 1; i > -1; i--)
                {
                    box_lot_list1 = in_node.AddNode("BOX_LOT_LIST1");
                    box_lot_list1.AddString("LOT_NO", MPCF.Trim(spdBoxID1.ActiveSheet.Cells[i, (int)COL_BOX.NO].Text));
                    box_lot_list1.AddString("LOT_ID", MPCF.Trim(spdBoxID1.ActiveSheet.Cells[i, (int)COL_BOX.LOT_ID].Text));
                    box_lot_list1.AddString("MAT_ID", MPCF.Trim(spdBoxID1.ActiveSheet.Cells[i, (int)COL_BOX.MAT_ID].Text));
                }

                for (int i = spdBoxID2.ActiveSheet.RowCount - 1; i > -1; i--)
                {
                    box_lot_list2 = in_node.AddNode("BOX_LOT_LIST2");
                    box_lot_list2.AddString("LOT_NO", MPCF.Trim(spdBoxID2.ActiveSheet.Cells[i, (int)COL_BOX.NO].Text));
                    box_lot_list2.AddString("LOT_ID", MPCF.Trim(spdBoxID2.ActiveSheet.Cells[i, (int)COL_BOX.LOT_ID].Text));
                    box_lot_list2.AddString("MAT_ID", MPCF.Trim(spdBoxID2.ActiveSheet.Cells[i, (int)COL_BOX.MAT_ID].Text));
                }

                if (MPCF.CallService("CUS", "CWIP_Tran_Box", in_node, ref out_node) == false)
                    return false;

                MPCF.ShowSuccessMessage(out_node, false);
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("Update_Box_Lot() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 박스 생성
        /// </summary>
        /// <returns></returns>
        private bool Create_Box(char c_Step)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = c_Step;                                

                if (MPCF.CallService("CUS", "CWIP_Tran_Box", in_node, ref out_node) == false)
                    return false;

                txtBoxID2.Text = out_node.GetString("NEW_BOX_ID") + "00000";

                sBoxID2 = MPCF.Trim(txtBoxID2.Text).Substring(0, MPCF.Trim(txtBoxID2.Text).Length - 5);
                iBoxCount2 = MPCF.ToInt(MPCF.Trim(txtBoxID2.Text).Substring(MPCF.Trim(txtBoxID2.Text).Length - 5, 5));
                txtBoxIDNew2.Text = MPCF.Trim(sBoxID2) + spdBoxID2.ActiveSheet.RowCount.ToString("00000");

                txtFG_ID2.Text = string.Empty;
                MPCF.ShowSuccessMessage(out_node, false);
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("Update_Box_Lot() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 박스 LOT 투입
        /// </summary>
        /// <returns></returns>
        private bool Tran_Box_Input(string sLotID)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '4';
                in_node.AddString("BOX_ID", MPCF.Trim(txtBoxID1.Text));
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));

                if (MPCF.CallService("CUS", "CWIP_Tran_Box", in_node, ref out_node) == false)
                    return false;

                //txtBoxID1.Text = out_node.GetString("NEW_BOX_ID");
                MPCF.ShowSuccessMessage(out_node, false);
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("Update_Box_Lot() : " + ex.Message, MSG_LEVEL.ERROR, false);
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
            MPCF.ConvertCaption(this);
            MPCF.ClearList(spdBoxID1);
            MPCF.ClearList(spdBoxID2);
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            try
            {
                string[] s_lot_id;
                int i_row = 0;
                int i_lot_count = 0;

                if (spdBoxID2_Sheet1.RowCount == 0)
                    return;

                if (txtBoxID1.Text == "")
                {
                    MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, false);
                    txtBoxID1.Focus();
                    return;
                }

                s_lot_id = new string[spdBoxID2.ActiveSheet.RowCount];

                for (int k = 0; k < spdBoxID2.ActiveSheet.RowCount; k++)
                {
                    if (Convert.ToBoolean(spdBoxID2.ActiveSheet.Cells[k, (int)COL_BOX.SELECT].Value) == true)
                    {
                        spdBoxID1.ActiveSheet.AddRows(0, 1);
                        spdBoxID1.ActiveSheet.Cells[0, (int)COL_BOX.SELECT].Value = false;
                        spdBoxID1.ActiveSheet.Cells[0, (int)COL_BOX.NO].Value = spdBoxID2.ActiveSheet.Cells[k, (int)COL_BOX.NO].Value;
                        spdBoxID1.ActiveSheet.Cells[0, (int)COL_BOX.FG_ID].Value = spdBoxID2.ActiveSheet.Cells[k, (int)COL_BOX.FG_ID].Value;
                        spdBoxID1.ActiveSheet.Cells[0, (int)COL_BOX.LOT_ID].Value = spdBoxID2.ActiveSheet.Cells[k, (int)COL_BOX.LOT_ID].Value;
                        spdBoxID1.ActiveSheet.Cells[0, (int)COL_BOX.MAT_ID].Value = spdBoxID2.ActiveSheet.Cells[k, (int)COL_BOX.MAT_ID].Value;
                        spdBoxID1.ActiveSheet.Cells[0, (int)COL_BOX.MAT_DESC].Value = spdBoxID2.ActiveSheet.Cells[k, (int)COL_BOX.MAT_DESC].Value;
                        spdBoxID1.ActiveSheet.Cells[0, (int)COL_BOX.TRAN_TIME].Value = spdBoxID2.ActiveSheet.Cells[k, (int)COL_BOX.TRAN_TIME].Value;
                        spdBoxID1.ActiveSheet.Cells[0, (int)COL_BOX.TRAN_USER_ID].Value = spdBoxID2.ActiveSheet.Cells[k, (int)COL_BOX.TRAN_USER_ID].Value;

                        s_lot_id[i_row] = spdBoxID2.ActiveSheet.Cells[k, (int)COL_BOX.LOT_ID].Text;
                        i_row++;
                    }
                }

                for (int k = 0; k < i_row; k++)
                {
                    for (int i = 0; i < spdBoxID2.ActiveSheet.RowCount; i++)
                    {
                        if (s_lot_id[k] == spdBoxID2.ActiveSheet.Cells[i, (int)COL_BOX.LOT_ID].Text)
                        {
                            spdBoxID2_Sheet1.RemoveRows(i, 1);
                            break;
                        }
                    }
                }

                for (int k = spdBoxID1.ActiveSheet.RowCount - 1; k > -1; k--)
                {
                    spdBoxID1.ActiveSheet.Cells[i_lot_count, (int)COL_BOX.NO].Value = k + 1;
                    i_lot_count++;
                }
                i_lot_count = 0;
                for (int k = spdBoxID2.ActiveSheet.RowCount - 1; k > -1; k--)
                {
                    spdBoxID2.ActiveSheet.Cells[i_lot_count, (int)COL_BOX.NO].Value = k + 1;
                    i_lot_count++;
                }
                
                txtBoxIDNew1.Text = MPCF.Trim(sBoxID1) + spdBoxID1.ActiveSheet.RowCount.ToString("00000");
                txtBoxIDNew2.Text = MPCF.Trim(sBoxID2) + spdBoxID2.ActiveSheet.RowCount.ToString("00000");
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("btnAttach() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
            
        }

        private void btnDetach_Click(object sender, EventArgs e)
        {
            try
            {
                string[] s_lot_id;
                int i_row = 0;
                int i_lot_count = 0;

                if (spdBoxID1_Sheet1.RowCount == 0)
                    return;

                if (txtBoxID2.Text == "")
                {
                    MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, false);
                    txtBoxID2.Focus();
                    return;
                }

                s_lot_id = new string[spdBoxID1.ActiveSheet.RowCount];

                for (int k = 0; k < spdBoxID1.ActiveSheet.RowCount; k++)
                {
                    if (Convert.ToBoolean(spdBoxID1.ActiveSheet.Cells[k, (int)COL_BOX.SELECT].Value) == true)
                    {
                        spdBoxID2.ActiveSheet.AddRows(0, 1);
                        spdBoxID2.ActiveSheet.Cells[0, (int)COL_BOX.SELECT].Value = false;
                        spdBoxID2.ActiveSheet.Cells[0, (int)COL_BOX.NO].Value = spdBoxID1.ActiveSheet.Cells[k, (int)COL_BOX.NO].Value;
                        spdBoxID2.ActiveSheet.Cells[0, (int)COL_BOX.FG_ID].Value = spdBoxID1.ActiveSheet.Cells[k, (int)COL_BOX.FG_ID].Value;
                        spdBoxID2.ActiveSheet.Cells[0, (int)COL_BOX.LOT_ID].Value = spdBoxID1.ActiveSheet.Cells[k, (int)COL_BOX.LOT_ID].Value;
                        spdBoxID2.ActiveSheet.Cells[0, (int)COL_BOX.MAT_ID].Value = spdBoxID1.ActiveSheet.Cells[k, (int)COL_BOX.MAT_ID].Value;
                        spdBoxID2.ActiveSheet.Cells[0, (int)COL_BOX.MAT_DESC].Value = spdBoxID1.ActiveSheet.Cells[k, (int)COL_BOX.MAT_DESC].Value;
                        spdBoxID2.ActiveSheet.Cells[0, (int)COL_BOX.TRAN_TIME].Value = spdBoxID1.ActiveSheet.Cells[k, (int)COL_BOX.TRAN_TIME].Value;
                        spdBoxID2.ActiveSheet.Cells[0, (int)COL_BOX.TRAN_USER_ID].Value = spdBoxID1.ActiveSheet.Cells[k, (int)COL_BOX.TRAN_USER_ID].Value;

                        s_lot_id[i_row] = spdBoxID1.ActiveSheet.Cells[k, (int)COL_BOX.LOT_ID].Text;
                        i_row++;
                    }
                }

                for (int k = 0; k < i_row; k++)
                {
                    for (int i = 0; i < spdBoxID1.ActiveSheet.RowCount; i++)
                    {
                        if (s_lot_id[k] == spdBoxID1.ActiveSheet.Cells[i, (int)COL_BOX.LOT_ID].Text)
                        {
                            spdBoxID1_Sheet1.RemoveRows(i, 1);
                            break;
                        }
                    }
                }

                for (int k = spdBoxID1.ActiveSheet.RowCount - 1; k > -1; k--)
                {
                    spdBoxID1.ActiveSheet.Cells[i_lot_count, (int)COL_BOX.NO].Value = k+1;
                    i_lot_count++;
                }
                i_lot_count = 0;
                for (int k = spdBoxID2.ActiveSheet.RowCount - 1; k > -1; k--)
                {
                    spdBoxID2.ActiveSheet.Cells[i_lot_count, (int)COL_BOX.NO].Value = k + 1;
                    i_lot_count++;
                }

                txtBoxIDNew1.Text = MPCF.Trim(sBoxID1) + spdBoxID1.ActiveSheet.RowCount.ToString("00000");
                txtBoxIDNew2.Text = MPCF.Trim(sBoxID2) + spdBoxID2.ActiveSheet.RowCount.ToString("00000");
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("btnAttach() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }            
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (Check_Data())
            {

            }
        }

        private void txtBoxID1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER)
                {
                    sBoxID1 = string.Empty;
                    iBoxCount1 = 0;

                    txtBoxID1.Text = MPCF.ToUpper(txtBoxID1.Text); // 일괄 대문자
                    txtFG_ID1.Text = MPCF.ToUpper(txtFG_ID1.Text); // 일괄 대문자
                    View_Box_Lot_list_1();

                    txtBoxID1.Focus();
                    txtBoxID1.SelectAll();
                }
            }
            catch (System.Exception)
            {                
                return;
            }
        }

        private void txtBoxID2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER)
                {
                    sBoxID2 = string.Empty;
                    iBoxCount2 = 0;

                    txtBoxID2.Text = MPCF.ToUpper(txtBoxID2.Text); // 일괄 대문자
                    txtFG_ID2.Text = MPCF.ToUpper(txtFG_ID2.Text); // 일괄 대문자
                    View_Box_Lot_list_2();

                    txtBoxID2.Focus();
                    txtBoxID2.SelectAll();
                }
            }
            catch (System.Exception)
            {                
                return;
            }
        }

        private void btnProcess_Click_1(object sender, EventArgs e)
        {
            try
            {
                if(Check_Data() == true)
                {
                    if(Update_Box_Lot('2') == true)
                    {
                        sBoxID1 = string.Empty;
                        iBoxCount1 = 0;

                        txtBoxID1.Text = MPCF.ToUpper(txtBoxID1.Text); // 일괄 대문자
                        txtFG_ID1.Text = MPCF.ToUpper(txtFG_ID1.Text); // 일괄 대문자
                        View_Box_Lot_list_1();

                        sBoxID2 = string.Empty;
                        iBoxCount2 = 0;

                        txtBoxID2.Text = MPCF.ToUpper(txtBoxID2.Text); // 일괄 대문자
                        txtFG_ID2.Text = MPCF.ToUpper(txtFG_ID2.Text); // 일괄 대문자
                        View_Box_Lot_list_2();

                        if(chkPrintFlag1.Checked)
                        {
                            ProcPrint('1', MPCF.ToInt(txtPrintQty1.Value));
                        }

                        if (chkPrintFlag1.Checked)
                        {
                            ProcPrint('2', MPCF.ToInt(txtPrintQty2.Value));
                        }
                    }
                }
            }
            catch (System.Exception)
            {                
                return;
            }            
        }

        private void spdBoxID1_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader && e.Column == 0)
            {
                //전체 헤더 선택
                string s_hChk = string.Empty;

                if (spdBoxID1.Sheets[0].ColumnHeader.Cells[0, 0].Text == "True")
                {
                    s_hChk = "False";
                }
                else
                {
                    s_hChk = "True";
                }

                spdBoxID1.Sheets[0].ColumnHeader.Cells[0, 0].Text = s_hChk;

                for (int i = 0; i < spdBoxID1.Sheets[0].Rows.Count; i++)
                {
                    spdBoxID1.Sheets[0].Cells[i, 0].Text = s_hChk;
                }
            }
        }

        private void spdBoxID2_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader && e.Column == 0)
            {
                //전체 헤더 선택
                string s_hChk = string.Empty;

                if (spdBoxID2.Sheets[0].ColumnHeader.Cells[0, 0].Text == "True")
                {
                    s_hChk = "False";
                }
                else
                {
                    s_hChk = "True";
                }

                spdBoxID2.Sheets[0].ColumnHeader.Cells[0, 0].Text = s_hChk;

                for (int i = 0; i < spdBoxID2.Sheets[0].Rows.Count; i++)
                {
                    spdBoxID2.Sheets[0].Cells[i, 0].Text = s_hChk;
                }
            }
        }

        private bool ProcPrint(char c_Step, int i_Print_Count)
        {
            TRSNode out_node = new TRSNode("OUT_NODE");

            int i;
            int iRowCount;
            string sProdID;

            try
            {
                udcPrint.InitFlexibleScreen();
                udcPrint.ScreenID = "ViewPackingList";
                udcPrint.ScreenSpread.Tag = "ViewPackingList";
                udcPrint.ProcStep = '1';
                MenuInfoTag menuInfo = (MenuInfoTag)this.Tag;
                udcPrint.OwnerFuncName = menuInfo.s_func_name;
                udcPrint.LotID = "ViewPackingList";

                if (udcPrint.LoadDesign() == false)
                {
                    return false;
                }

                if(c_Step == '1')
                {
                    iRowCount = spdBoxID1.ActiveSheet.RowCount;
                                        
                    out_node.SetString("BOX_ID", txtBoxID1.Text);

                    for (i = 0; i < spdBoxID1.ActiveSheet.RowCount; i++)
                    {
                        if (i == 0)
                        {
                            out_node.SetString("MAT_SHORT_DESC", MPCF.Trim(spdBoxID1.ActiveSheet.Cells[0, (int)COL_BOX.MAT_DESC].Value));
                        }
                        sProdID = String.Format("PROD_ID_{0}", MPCF.ToInt(spdBoxID1.ActiveSheet.Cells[i, (int)COL_BOX.NO].Value));
                        out_node.SetString(sProdID, MPCF.Trim(spdBoxID1.ActiveSheet.Cells[i, (int)COL_BOX.FG_ID].Value));
                    }
                }
                else
                {
                    iRowCount = spdBoxID2.ActiveSheet.RowCount;                    
                    out_node.SetString("BOX_ID", txtBoxID2.Text);

                    for (i = 0; i < spdBoxID2.ActiveSheet.RowCount; i++)
                    {
                        if (i == 0)
                        {
                            out_node.SetString("MAT_SHORT_DESC", MPCF.Trim(spdBoxID2.ActiveSheet.Cells[0, (int)COL_BOX.MAT_DESC].Value));
                        }
                        sProdID = String.Format("PROD_ID_{0}", MPCF.ToInt(spdBoxID2.ActiveSheet.Cells[i, (int)COL_BOX.NO].Value));
                        out_node.SetString(sProdID, MPCF.Trim(spdBoxID2.ActiveSheet.Cells[i, (int)COL_BOX.FG_ID].Value));
                    }
                } 

                if (udcPrint.SetDataToScreen(out_node) == false)
                {
                    return false;
                }

                udcPrint.ScreenSpread.Sheets[0].PrintInfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape;

                for (int j = 0; j < i_Print_Count; j++)
                {
                    MPCF.PrintFlexibleScreen(this, this.printOption, udcPrint, false);
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void btnPrint1_Click(object sender, EventArgs e)
        {
            if (spdBoxID1.ActiveSheet.RowCount == 0) return;

            ProcPrint('1', MPCF.ToInt(txtPrintQty1.Value));
        }

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            if (spdBoxID2.ActiveSheet.RowCount == 0) return;

            ProcPrint('2', MPCF.ToInt(txtPrintQty2.Value));
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                // Print Option Popup 생성
                if (frmOption == null)
                {
                    frmOption = new frmPrintOptionPopup();
                }

                // Print Option Popup 초기화
                frmOption.Owner = this;
                frmOption.printOption = this.printOption;
                frmOption.funcName = this.menuInfo.s_func_name;

                // Show Dialog
                if (frmOption.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.printOption = frmOption.printOption;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(spdBoxID1);
            MPCF.ClearList(spdBoxID2);

            txtBoxID1.Text = string.Empty;
            txtBoxID2.Text = string.Empty;
            txtFG_ID1.Text = string.Empty;
            txtFG_ID2.Text = string.Empty;

            txtBoxIDNew1.Text = string.Empty;
            txtBoxIDNew2.Text = string.Empty;

            txtBoxID1.Focus();
            txtBoxID1.SelectAll();
        }

        private void txtFG_ID1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER)
                {
                    sBoxID1 = string.Empty;
                    iBoxCount1 = 0;

                    txtBoxID1.Text = MPCF.ToUpper(txtBoxID1.Text); // 일괄 대문자
                    txtFG_ID1.Text = MPCF.ToUpper(txtFG_ID1.Text); // 일괄 대문자
                    View_Box_Lot_list_1();

                    txtFG_ID1.Focus();
                    txtFG_ID1.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void txtFG_ID2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER)
                {
                    sBoxID2 = string.Empty;
                    iBoxCount2 = 0;

                    txtBoxID2.Text = MPCF.ToUpper(txtBoxID2.Text); // 일괄 대문자
                    txtFG_ID2.Text = MPCF.ToUpper(txtFG_ID2.Text); // 일괄 대문자
                    View_Box_Lot_list_2();

                    txtFG_ID2.Focus();
                    txtFG_ID2.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnBoxCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBoxID1.Text != "")
                {
                    sBoxID1 = string.Empty;
                    iBoxCount1 = 0;

                    txtBoxID1.Text = MPCF.ToUpper(txtBoxID1.Text); // 일괄 대문자
                    txtFG_ID1.Text = MPCF.ToUpper(txtFG_ID1.Text); // 일괄 대문자
                    View_Box_Lot_list_1();
                }

                MPCF.ClearList(spdBoxID2);

                txtBoxID2.Text = string.Empty;
                txtFG_ID2.Text = string.Empty;

                txtBoxIDNew2.Text = string.Empty;

                txtBoxID2.Focus();
                txtBoxID2.SelectAll();

                //box생성
                if (Create_Box('3') == true)
                {
                    MPCF.SetFocus(txtBoxID2);
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
