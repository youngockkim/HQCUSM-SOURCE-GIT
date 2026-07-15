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
    public partial class frmCUSTranModuleMaterialDefect : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        #region [Property]

        const int ENTER = 13;

        #endregion

        public frmCUSTranModuleMaterialDefect()
        {
            InitializeComponent();
        }

        #region [Constant Definition]

        public enum MAT
        {
            CHK,
            OPER,
            OPER_DESC,
            RES_ID,
            RES_DESC,
            MAT_ID,
            MAT_DESC,
            MAT_LOT_ID,
            MAT_QTY,
            UNIT_1,
            REASON_CODE,
            REASON_CODE_BTN,
            REASON_CODE_DESC,
            RESULT_CODE,
            RESULT_CODE_BTN,
            RESULT_CODE_DESC,
            CHANGE_USE_DESC,
            CHANG_USE_BTN,            
            TRAN_TIME,
            TRAN_USER_ID
        }

        private enum LOSS_COL
        {
            LOSS_CODE,
            LOSS_DESC
        }

        #endregion

        #region [Variable Definition]

        private bool bIsShown = false;

        #endregion

        #region [FormDefinition]

        #endregion

        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1")
        //
        private void ClearData(string ProcStep)
        {
            try
            {
                if (ProcStep == "1")
                {
                    MPCF.ClearList(spdUseMaterial);
                }
            }

            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "VIEW":

                        if (string.IsNullOrEmpty(txtLotID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Lot ID]"));
                            MPCF.SetFocus(txtLotID);
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

        private bool Get_Lot_ID(ref string strLot)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            try
            {
                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$INPUT";
                dvcArgu[1].sCondition_Value = MPCF.Trim(txtLotID.Text);

                if (TPDR.GetDataOne("", ref dt, "VIEW_LOT_OR_JIG", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                if (dt.Rows.Count > 0)
                {
                    strLot = dt.Rows[0]["LOT_ID"].ToString();
                    return true;
                }
                else
                    return false;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private void frmCUSTranModuleMaterialDefect_Load(object sender, EventArgs e)
        {
            MPCF.ClearList(spdUseMaterial);

            if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
            {
                txtLotID.Text = MPGV.gsCurrentLot_ID;
                btnView.PerformClick();
            }
        }

        private void frmCUSTranModuleMaterialDefect_Activated(object sender, EventArgs e)
        {

        }

        private void frmCUSTranModuleMaterialDefect_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                bIsShown = true;

                MPCF.SetFocus(txtLotID);
            }
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER && MPCF.Trim(txtLotID.Text) != "")
            {
                txtLotID.Text = MPCF.ToUpper(txtLotID.Text); // 일괄 대문자
                btnView.PerformClick();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string strLot = string.Empty;

            try
            {
                if (!CheckCondition("VIEW"))
                    return;

                ClearData("1");

                if (!Get_Lot_ID(ref strLot))
                {
                    txtLotID.Tag = null;
                    MPCF.ShowMsgBox(MPCF.GetMessage(217));
                    return;
                }

                txtLotID.Tag = strLot; // JIG or LOT 입력시 결과적으로 LOT ID만 사용한다.
                ViewUseMaterial(strLot);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            MPCF.ShowMessage("", MSG_LEVEL.NONE, false);

            if (!CheckCondition("PROCESS"))
                return;

            if (Tran_Loss_Register_Lot(txtLotID.Tag.ToString(), '2') == true)
            {
                btnView.PerformClick();
                MPCF.SetFocus(txtLotID);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool ViewUseMaterial(string sLotID)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            try
            {
                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$LOT_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(sLotID);

                if (TPDR.GetDataOne("", ref dt, "VIEW_USE_MATERIAL_LOSS", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();

                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spdUseMaterial.ActiveSheet.RowCount++;
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.OPER].Value = dt.Rows[i]["OPER"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.OPER_DESC].Value = dt.Rows[i]["OPER_DESC"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.RES_ID].Value = dt.Rows[i]["RES_ID"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.RES_DESC].Value = dt.Rows[i]["RES_DESC"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.MAT_DESC].Value = dt.Rows[i]["MAT_SHORT_DESC"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.MAT_LOT_ID].Value = dt.Rows[i]["MAT_LOT_ID"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.MAT_QTY].Value = dt.Rows[i]["QTY_1"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.UNIT_1].Value = dt.Rows[i]["UNIT_1"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.REASON_CODE].Value = dt.Rows[i]["REASON_CODE"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.REASON_CODE_DESC].Value = dt.Rows[i]["REASON_CODE_DESC"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.RESULT_CODE].Value = dt.Rows[i]["RESULT_CODE"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.RESULT_CODE_DESC].Value = dt.Rows[i]["RESULT_CODE_DESC"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.CHANGE_USE_DESC].Value = dt.Rows[i]["MAT_CHANGE"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.TRAN_TIME].Value = dt.Rows[i]["TRAN_TIME"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.TRAN_USER_ID].Value = dt.Rows[i]["TRAN_USER_ID"].ToString();
                }

                MPCF.FitColumnHeader(spdUseMaterial);

                spdUseMaterial.ActiveSheet.Columns[(int)MAT.MAT_DESC].Width = 220F;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// View Lot
        /// </summary>
        /// <param name="sLotID"></param>
        /// <returns></returns>
        private bool Tran_Loss_Register_Lot(string sLotID, char cStep)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");
            TRSNode list_item;

            string reson_code = string.Empty;

            MPCF.ShowMessageClear();

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = cStep;

                for(int k =0; k < spdUseMaterial.ActiveSheet.RowCount; k++)
                {
                    if(Convert.ToBoolean(spdUseMaterial.ActiveSheet.Cells[k, (int)MAT.CHK].Value) == true)
                    {
                        list_item = in_node.AddNode("DATA_LIST");
                        list_item.AddString("LOT_ID", MPCF.Trim(sLotID));
                        list_item.AddString("TIV_LOT_ID", MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[k, (int)MAT.MAT_LOT_ID].Value));
                        list_item.AddString("MAT_ID", MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[k, (int)MAT.MAT_ID].Value));
                        list_item.AddString("OPER", MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[k, (int)MAT.OPER].Value));

                        //등록
                        if (cStep == '2')
                        {
                            list_item.AddString("REASON_CODE_1", MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[k, (int)MAT.REASON_CODE].Value));
                        }
                        //조치
                        else if (cStep == '3')
                        {
                            if (string.IsNullOrEmpty(MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[k, (int)MAT.CHANGE_USE_DESC].Value.ToString())) == true)
                            {
                                MPCF.ShowErrorMessage("교체유형을 선택후 진행해주세요.");
                                return false;
                            }

                            if (string.IsNullOrEmpty(MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[k, (int)MAT.REASON_CODE].Value.ToString())) == true)
                            {
                                MPCF.ShowErrorMessage("불량등록 후 진행해주세요.");
                                return false;
                            }

                            list_item.AddString("RESULT_CODE_1", MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[k, (int)MAT.RESULT_CODE].Value));
                            list_item.AddString("CHANGE_TYPE", MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[k, (int)MAT.CHANGE_USE_DESC].Value));
                        }
                    }
                }

                if (MPCF.CallService("CUS", "CWIP_Tran_Defect_Register", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private void spdUseMaterial_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (spdUseMaterial.ActiveSheet.RowCount == 0) return;

                //txtMatID.Text = spdUseMaterial.ActiveSheet.Cells[e.Row, (int)MAT.MAT_ID].Text;
                //txtMatDesc.Text = spdUseMaterial.ActiveSheet.Cells[e.Row, (int)MAT.MAT_DESC].Text;
                //txtMatLotID.Text = spdUseMaterial.ActiveSheet.Cells[e.Row, (int)MAT.MAT_LOT_ID].Text;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if (spdLossList.ActiveSheet.RowCount == 5)
            //{
            //    MPCF.ShowMsgBox("불량코드는 5개 이하로 등록가능합니다.");
            //    return;
            //}

            if (AddRow() == true)
            {
                //cdvLossCode.Tag = "";
                //cdvLossCode.Text = "";
            }
        }

        private bool AddRow()
        {
            try
            {
                //if (MPCF.Trim(cdvLossCode.Text) == "" || MPCF.Trim(cdvLossCode.Tag) == "")
                //{
                //    MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                //    cdvLossCode.Focus();
                //    return false;
                //}

                //spdLossList.ActiveSheet.RowCount++;
                //spdLossList.ActiveSheet.Cells[spdLossList.ActiveSheet.RowCount - 1, (int)LOSS_COL.LOSS_CODE].Text = cdvLossCode.Tag.ToString();
                //spdLossList.ActiveSheet.Cells[spdLossList.ActiveSheet.RowCount - 1, (int)LOSS_COL.LOSS_DESC].Text = cdvLossCode.Text;

                //MPCF.FitColumnHeader(spdLossList);                

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // 데이터가 없는 경우 종료
                //if (spdLossList.ActiveSheet.Rows.Count < 1)
                //{
                //    return;
                //}

                //spdLossList.Sheets[0].Rows[spdLossList.ActiveSheet.ActiveRowIndex].Remove();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvLossCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TABLE_NAME";
                dvcArgu[1].sCondition_Value = "C@LOSS_REQUEST";

                // CodeView Column Header Setup
                string[] header = new string[] { "Code", "Code Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                //cdvLossCode.Text = cdvLossCode.Show(cdvLossCode, "Code Desc", "VIEW_GCM_DATA", dvcArgu, display, header, "DATA_1", -1);

                //if (MPCF.Trim(cdvLossCode.Text) != "")
                //{
                //    if (cdvLossCode.returnDatas != null && cdvLossCode.returnDatas.Count > 0)
                //    {
                //        cdvLossCode.Tag = cdvLossCode.returnDatas[0];
                //        cdvLossCode.Text = cdvLossCode.returnDatas[1];
                //    }
                //}
                //else
                //{
                //    cdvLossCode.Tag = "";
                //    cdvLossCode.Text = "";
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdUseMaterial_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column == (int)MAT.REASON_CODE_BTN ||e.Column == (int)MAT.RESULT_CODE_BTN)
                {
                    TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                    dvcArgu[0].sCondtion_ID = "$FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    dvcArgu[1].sCondtion_ID = "$TABLE_NAME";
                    dvcArgu[1].sCondition_Value = "C@LOSS_REQUEST";

                    // CodeView Column Header Setup
                    string[] header = new string[] { "Code", "Code Desc" };

                    // CodeView Display Column Setup
                    string[] display = new string[] { "KEY_1", "DATA_1" };

                    // Show
                    cdvDefectSoldering.Text = cdvDefectSoldering.Show(cdvDefectSoldering, "Code Desc", "VIEW_GCM_DATA", dvcArgu, display, header, "DATA_1", -1);

                    if (MPCF.Trim(cdvDefectSoldering.Text) != "")
                    {
                        if (cdvDefectSoldering.returnDatas != null && cdvDefectSoldering.returnDatas.Count > 0)
                        {
                            spdUseMaterial.ActiveSheet.Cells[e.Row, e.Column-1].Tag = cdvDefectSoldering.returnDatas[0];
                            spdUseMaterial.ActiveSheet.Cells[e.Row, e.Column-1].Text = cdvDefectSoldering.returnDatas[0];
                            spdUseMaterial.ActiveSheet.Cells[e.Row, e.Column+1].Text = cdvDefectSoldering.returnDatas[1];
                            spdUseMaterial.ActiveSheet.Cells[e.Row, (int)MAT.CHK].Value = true;
                            //spdUseMaterial.ActiveSheet.Rows[e.Row].BackColor = Color.Salmon;
                        }
                        else
                        {
                            spdUseMaterial.ActiveSheet.Cells[e.Row, e.Column-1].Tag = "";
                            spdUseMaterial.ActiveSheet.Cells[e.Row, e.Column-1].Text = "";
                            spdUseMaterial.ActiveSheet.Cells[e.Row, e.Column+1].Text = "";
                        }
                    }
                    else
                    {
                        spdUseMaterial.ActiveSheet.Cells[e.Row, e.Column -1].Tag = "";
                        spdUseMaterial.ActiveSheet.Cells[e.Row, e.Column -1].Text = "";
                        spdUseMaterial.ActiveSheet.Cells[e.Row, e.Column+1].Text = "";
                    }
                }
                else if (e.Column == (int)MAT.CHANG_USE_BTN)
                {
                    TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[0];

                    // CodeView Column Header Setup
                    string[] header = new string[] { "Code", "Code Desc" };

                    // CodeView Display Column Setup
                    string[] display = new string[] { "KEY_1", "DATA_1" };

                    // Show
                    cdvDefectSoldering.Text = cdvDefectSoldering.Show(cdvDefectSoldering, "Code Desc", "VIEW_CHANGE_TYPE", dvcArgu, display, header, "DATA_1", -1);

                    if (MPCF.Trim(cdvDefectSoldering.Text) != "")
                    {
                        if (cdvDefectSoldering.returnDatas != null && cdvDefectSoldering.returnDatas.Count > 0)
                        {
                            spdUseMaterial.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = cdvDefectSoldering.returnDatas[0];
                            spdUseMaterial.ActiveSheet.Cells[e.Row, e.Column - 1].Text = cdvDefectSoldering.returnDatas[1];
                            spdUseMaterial.ActiveSheet.Cells[e.Row, (int)MAT.CHK].Value = true;
                            //spdUseMaterial.ActiveSheet.Rows[e.Row].BackColor = Color.Salmon;
                        }
                        else
                        {
                            spdUseMaterial.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = "";
                            spdUseMaterial.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                        }
                    }
                    else
                    {
                        spdUseMaterial.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = "";
                        spdUseMaterial.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnLossProcess_Click(object sender, EventArgs e)
        {
            if (!CheckCondition("PROCESS"))
                return;

            if (Tran_Loss_Register_Lot(txtLotID.Tag.ToString(),'3') == true)
            {
                btnView.PerformClick();
                MPCF.SetFocus(txtLotID);
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

        private void btnDefectLotInput_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLotID.Text) == false)
                {
                    MPGV.gsCurrentLot_ID = txtLotID.Text;
                }

                BICF.OpenMenu("SOI2016");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            } 
        }

        private void btnModulManage_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLotID.Text) == false)
                {
                    MPGV.gsCurrentLot_ID = txtLotID.Text;
                }

                BICF.OpenMenu("SOI2017");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            } 
        }
    }
}