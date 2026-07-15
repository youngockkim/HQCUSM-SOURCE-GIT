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
    public partial class frmCUSTranModuleDeactivate : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        #region [Property]

        const int ENTER = 13;

        #endregion

        public frmCUSTranModuleDeactivate()
        {
            InitializeComponent();
        }

        #region [Constant Definition]

        public enum TRAY
        {
            STRING,
            CELL_1,
            CELL_2,
            CELL_3,
            CELL_4,
            CELL_5,
            CELL_6,
            CELL_7,
            CELL_8,
            CELL_9,
            CELL_10,
            CELL_11,
            CELL_12
        }

        public enum MAT
        {
            OPER,
            OPER_DESC,            
            MAT_ID,
            MAT_DESC,            
            MAT_QTY,
            UNIT_1,
            REQUEST_CODE,
            REQUEST_DESC,
            RESULT_CODE,
            RESULT_CODE_BTN,
            PROCESS_CODE,
            PROCESS_BTN,
            MAT_LOT_ID,
            RES_ID,
            RES_DESC,
            TRAN_TIME,
            TRAN_USER_ID
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
                    MPCF.ClearList(spdModuleInfo);
                    MPCF.ClearList(spdUseMaterial);
                }
                else if (ProcStep == "2")
                {
                    MPCF.ClearList(spdModuleInfo);
                    MPCF.ClearList(spdUseMaterial);
                    MPCF.ClearList(spdOkTray);
                    MPCF.ClearList(spdNgTray);
                    txtLotID.Text = string.Empty;
                    cdvTerminate.Text = string.Empty;
                    cdvTerminate.Tag = string.Empty;
                    txtCodeDesc.Text = string.Empty;
                    txtNGTray.Text = string.Empty;
                    txtOkTray.Text = string.Empty;
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

                    case "PROCESS" :

                        if (string.IsNullOrEmpty(txtOkTray.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Tray ID]"));
                            MPCF.SetFocus(txtOkTray);
                            return false;
                        }

                        if (string.IsNullOrEmpty(txtNGTray.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Tray ID]"));
                            MPCF.SetFocus(txtNGTray);
                            return false;
                        }

                        if (string.IsNullOrEmpty(cdvTerminate.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Terminate COde]"));
                            MPCF.SetFocus(cdvTerminate);
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

        private void frmCUSTranModuleDeactivate_Load(object sender, EventArgs e)
        {
            MPCF.ClearList(spdUseMaterial);
        }

        private void frmCUSTranModuleDeactivate_Activated(object sender, EventArgs e)
        {

        }

        private void frmCUSTranModuleDeactivate_Shown(object sender, EventArgs e)
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
            try
            {
                MPCF.ShowMessageClear();

                if (!CheckCondition("VIEW"))
                    return;

                ClearData("1");

                View_Lot_Info();

                ViewUseMaterial(txtLotID.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (!CheckCondition("PROCESS"))
                return;

            if (Tran_Terminate_Lot(txtLotID.Text) == true)
            {
                ClearData("2");
                
                MPCF.SetFocus(txtLotID);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 작업지시 조회
        /// </summary>
        /// <returns></returns>
        private bool View_Lot_Info()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            int i_string_cnt ;
            int i_cell_cnt;

            try
            {
                MPCF.ClearList(spdModuleInfo);

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$LOT_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(txtLotID.Text);

                if (TPDR.GetDataOne("", ref dt, "VIEW_LOT_STRING_INFO", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                i_cell_cnt = MPCF.ToInt(dt.Rows[0]["CELL_CNT"].ToString());
                i_string_cnt = MPCF.ToInt(dt.Rows[0]["STRING_CNT"].ToString());

                //spdModuleInfo.ActiveSheet.RowCount = i_string_cnt;
                spdModuleInfo.ActiveSheet.Columns.Count = i_cell_cnt + 1;

                string s_string_line = string.Empty;
                int i_col_seq = 0;
                spdModuleInfo.ActiveSheet.Columns[0].BackColor = System.Drawing.Color.PowderBlue;

                for(int a =0; a <dt.Rows.Count; a++)
                {
                    i_col_seq = MPCF.ToInt(dt.Rows[a]["CELL_SEQ"].ToString());

                    //STRING ID 추가
                    if (a == 0 || s_string_line != dt.Rows[a]["STRING_LINE"].ToString())
                    {
                        spdModuleInfo.ActiveSheet.RowCount++;
                        spdModuleInfo.ActiveSheet.RowHeader.Cells[spdModuleInfo.ActiveSheet.RowCount - 1, 0].Text = dt.Rows[a]["STRING_LINE"].ToString();
                        spdModuleInfo.ActiveSheet.Cells[spdModuleInfo.ActiveSheet.RowCount - 1, 0].Value = dt.Rows[a]["STRING_ID"].ToString();

                        s_string_line = dt.Rows[a]["STRING_LINE"].ToString();
                    }
                    
                    if(MPCF.Trim(dt.Rows[a]["CELL_LOSS_CODE"].ToString()) != "")
                    {
                        spdModuleInfo.ActiveSheet.Cells[spdModuleInfo.ActiveSheet.RowCount - 1, i_col_seq].BackColor = Color.Red;
                        spdModuleInfo.ActiveSheet.Rows[spdModuleInfo.ActiveSheet.RowCount - 1].Tag = "NG";
                    }
                }

                MPCF.FitColumnHeader(spdModuleInfo);
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool ViewUseMaterial(string sLotID)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            try
            {
                MPCF.ClearList(spdUseMaterial);

                //Tag 값 입력 후 체크로직
                if (!CheckCondition(CSGC.MP_CHECK_VIEW))
                    return false;

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
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.MAT_DESC].Value = dt.Rows[i]["MAT_SHORT_DESC"].ToString();                    
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.MAT_QTY].Value = dt.Rows[i]["QTY_1"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.UNIT_1].Value = dt.Rows[i]["UNIT_1"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.REQUEST_CODE].Value = dt.Rows[i]["REASON_CODE"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.REQUEST_DESC].Value = dt.Rows[i]["REASON_CODE_DESC"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.MAT_LOT_ID].Value = dt.Rows[i]["MAT_LOT_ID"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.RES_ID].Value = dt.Rows[i]["RES_ID"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.RES_DESC].Value = dt.Rows[i]["RES_DESC"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.TRAN_TIME].Value = dt.Rows[i]["TRAN_TIME"].ToString();
                    spdUseMaterial.ActiveSheet.Cells[i, (int)MAT.TRAN_USER_ID].Value = dt.Rows[i]["TRAN_USER_ID"].ToString();

                    //불량 등록이 있는데 결과가 없을경우
                    if(MPCF.Trim(dt.Rows[i]["REASON_CODE"].ToString()) != "" && MPCF.Trim(dt.Rows[i]["RESULT_CODE"].ToString()) =="")
                    {
                        spdUseMaterial.ActiveSheet.Rows[i].BackColor = Color.PaleVioletRed;
                        spdUseMaterial.ActiveSheet.Rows[i].Tag = "Y";
                    }
                }

                MPCF.FitColumnHeader(spdUseMaterial);

                spdUseMaterial.ActiveSheet.Columns[(int)MAT.OPER_DESC].Width = 130F;
                spdUseMaterial.ActiveSheet.Columns[(int)MAT.MAT_DESC].Width = 220F;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool View_Tray_Info( string sTray, string sTray_Type)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];
            DataTable dt = null;
            string s_sql = "";

            string s_string_id = "";
            int i = 0;

            try
            {
                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TRAY_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(sTray);

                dvcArgu[2].sCondtion_ID = "$TRAY_TYPE";
                dvcArgu[2].sCondition_Value = MPCF.Trim(sTray_Type);

                if (TPDR.GetDataOne("", ref dt, "VIEW_TRAY_STRING_LIST", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    if (sTray_Type == "OK")
                    {
                        if (i == 0)
                        {
                            s_string_id = dt.Rows[i]["STRING_ID"].ToString();

                            spdOkTray.ActiveSheet.RowCount++;
                            spdOkTray.ActiveSheet.Cells[i, (int)TRAY.STRING].Value = dt.Rows[i]["STRING_ID"].ToString();
                            spdOkTray_Sheet1.RowHeader.Cells.Get(i, 0).Value = dt.Rows[i]["STRING_SEQ"].ToString();

                            spdOkTray.ActiveSheet.Cells[i, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString())].BackColor = Color.LightGreen;
                        }
                        else
                        {
                            if (s_string_id != dt.Rows[i]["STRING_ID"].ToString())
                            {
                                spdOkTray.ActiveSheet.RowCount++;
                                spdOkTray.ActiveSheet.Cells[spdOkTray.ActiveSheet.RowCount - 1, (int)TRAY.STRING].Value = dt.Rows[i]["STRING_ID"].ToString();
                                spdOkTray_Sheet1.RowHeader.Cells.Get(spdOkTray.ActiveSheet.RowCount - 1, 0).Value = dt.Rows[i]["STRING_SEQ"].ToString();

                                s_string_id = dt.Rows[i]["STRING_ID"].ToString();
                            }

                            spdOkTray.ActiveSheet.Cells[spdOkTray.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString())].BackColor = Color.LightGreen;

                        }

                        MPCF.FitColumnHeader(spdOkTray);
                    }
                    else
                    {
                        if (i == 0)
                        {
                            s_string_id = dt.Rows[i]["STRING_ID"].ToString();

                            spdNgTray.ActiveSheet.RowCount++;
                            spdNgTray.ActiveSheet.Cells[i, (int)TRAY.STRING].Value = dt.Rows[i]["STRING_ID"].ToString();
                            spdNgTray.ActiveSheet.Cells[i, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString())].BackColor = Color.LightGreen;
                            spdNgTray_Sheet1.RowHeader.Cells.Get(i, 0).Value = dt.Rows[i]["STRING_SEQ"].ToString();
                        }
                        else
                        {
                            if (s_string_id != dt.Rows[i]["STRING_ID"].ToString())
                            {
                                spdNgTray.ActiveSheet.RowCount++;
                                spdNgTray.ActiveSheet.Cells[spdNgTray.ActiveSheet.RowCount - 1, (int)TRAY.STRING].Value = dt.Rows[i]["STRING_ID"].ToString();
                                spdNgTray_Sheet1.RowHeader.Cells.Get(spdNgTray.ActiveSheet.RowCount - 1, 0).Value = dt.Rows[i]["STRING_SEQ"].ToString();

                                s_string_id = dt.Rows[i]["STRING_ID"].ToString();
                            }

                            spdNgTray.ActiveSheet.Cells[spdNgTray.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString())].BackColor = Color.LightGreen;
                        }

                        if (dt.Rows[i]["LOSS_CODE"].ToString() != " ")
                        {
                            spdNgTray.ActiveSheet.Cells[spdNgTray.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString())].Text = "√";
                            spdNgTray.ActiveSheet.Cells[spdNgTray.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString())].BackColor = Color.Red;
                        }

                        MPCF.FitColumnHeader(spdNgTray);
                    }
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
        /// View Lot
        /// </summary>
        /// <param name="sLotID"></param>
        /// <returns></returns>
        private bool Tran_Terminate_Lot(string sLotID)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");
            TRSNode data_list = null;
            TRSNode inv_list = null;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));
                in_node.AddString("TERMINATE_CODE", MPCF.Trim(cdvTerminate.Text));
                in_node.AddString("OK_TRAY_ID", MPCF.Trim(txtOkTray.Text));
                in_node.AddString("NG_TRAY_ID", MPCF.Trim(txtNGTray.Text));

                for(int k =0; k < spdModuleInfo.ActiveSheet.RowCount; k++)
                {
                    data_list = in_node.AddNode("DATA_LIST");
                    data_list.AddString("STRING_ID", MPCF.Trim(spdModuleInfo.ActiveSheet.Cells[k, 0].Text));

                    if (MPCF.Trim(spdModuleInfo.ActiveSheet.Rows[k].Tag) == "NG")
                    {
                        data_list.AddString("STRING_TYPE", MPCF.Trim("NG"));    
                    }
                    else
                    {
                        data_list.AddString("STRING_TYPE", MPCF.Trim("OK"));    
                    }
                }

                for (int k = 0; k < spdUseMaterial.ActiveSheet.RowCount; k++)
                {
                    inv_list = in_node.AddNode("INV_LIST");
                    inv_list.AddString("MAT_LOT_ID", MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[k, (int)MAT.MAT_LOT_ID].Text));
                    inv_list.AddString("MAT_ID", MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[k, (int)MAT.MAT_ID].Text));
                    
                    //결과 코드가 필요한 자재일경우
                    if(spdUseMaterial.ActiveSheet.Rows[k].Tag == "Y")
                    {
                        inv_list.AddString("REASON_CODE", MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[k, (int)MAT.RESULT_CODE].Text));

                        if(MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[k, (int)MAT.RESULT_CODE].Text) == "")
                        {
                            MPCF.ShowErrorMessage("결과 코드를 선택후 진행해주세요.");
                            return false;
                        }

                        if (MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[k, (int)MAT.PROCESS_CODE].Text) == "")
                        {
                            MPCF.ShowErrorMessage("처리 코드를 선택후 진행해주세요.");
                            return false;
                        }
                    }
                    
                    //QC의뢰
                    if(MPCF.Trim(spdUseMaterial.ActiveSheet.Cells[k, (int)MAT.PROCESS_CODE].Text) == "QC")
                    {
                        inv_list.AddChar("QC_FLAG", 'Y');    
                    }
                }

                if (MPCF.CallService("CUS", "CWIP_Tran_Terminate_Lot", in_node, ref out_node) == false)
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

        private void txtTrayID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER)
            {
                txtOkTray.Text = MPCF.ToUpper(txtOkTray.Text); // 일괄 대문자
                MPCF.ClearList(spdOkTray);
                View_Tray_Info(txtOkTray.Text, "OK");
            }
        }

        private void txtNGTrayID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER)
            {
                txtNGTray.Text = MPCF.ToUpper(txtNGTray.Text); // 일괄 대문자
                MPCF.ClearList(spdNgTray);
                View_Tray_Info(txtNGTray.Text, "NG");
            }        
        }

        private void cdvTerminate_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TABLE_NAME";
                dvcArgu[1].sCondition_Value = "TERMINATE_CODE";

                // CodeView Column Header Setup
                string[] header = new string[] { "Code", "Code Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvTerminate.Text = cdvTerminate.Show(cdvTerminate, "Code Desc", "VIEW_GCM_DATA", dvcArgu, display, header, "KEY_1", -1);

                if (MPCF.Trim(cdvTerminate.Text) != "")
                {
                    if (cdvTerminate.returnDatas != null && cdvTerminate.returnDatas.Count > 0)
                    {
                        cdvTerminate.Tag = cdvTerminate.returnDatas[0];
                        cdvTerminate.Text = cdvTerminate.returnDatas[0];
                        txtCodeDesc.Text = cdvTerminate.returnDatas[1];
                    }
                }
                else
                {
                    cdvTerminate.Tag = "";
                    txtCodeDesc.Text = "";
                }
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

        private void spdUseMaterial_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column == (int)MAT.RESULT_CODE_BTN)
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
                            spdUseMaterial.ActiveSheet.Cells[e.Row, e.Column - 1].Text = cdvDefectSoldering.returnDatas[0];
                        }
                        else
                        {
                            spdUseMaterial.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                        }
                    }
                    else
                    {
                        spdUseMaterial.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                    }
                }
                else if (e.Column == (int)MAT.PROCESS_BTN)
                {
                    TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[0];

                    // CodeView Column Header Setup
                    string[] header = new string[] { "Code", "Code Desc" };

                    // CodeView Display Column Setup
                    string[] display = new string[] { "KEY_1", "DATA_1" };

                    // Show
                    cdvDefectSoldering.Text = cdvDefectSoldering.Show(cdvDefectSoldering, "Code Desc", "VIEW_PROCESS_TYPE", dvcArgu, display, header, "DATA_1", -1);

                    if (MPCF.Trim(cdvDefectSoldering.Text) != "")
                    {
                        if (cdvDefectSoldering.returnDatas != null && cdvDefectSoldering.returnDatas.Count > 0)
                        {
                            spdUseMaterial.ActiveSheet.Cells[e.Row, e.Column - 1].Text = cdvDefectSoldering.returnDatas[0];                            
                        }
                        else
                        {
                            spdUseMaterial.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                        }
                    }
                    else
                    {
                        spdUseMaterial.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }        
    }
}