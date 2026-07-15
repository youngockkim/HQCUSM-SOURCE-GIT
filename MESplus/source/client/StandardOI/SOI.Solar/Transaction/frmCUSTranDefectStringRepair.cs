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
using BOI.OIFrx.BOIControls;

namespace SOI.Solar
{
    public partial class frmCUSTranDefectStringRepair : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        #region [Property]

        private bool bIsShown = false;
        const int ENTER = 13;

        #endregion

        public frmCUSTranDefectStringRepair()
        {
            InitializeComponent();
        }

        #region [Constant Definition]

        public enum TRAY
        {
            STRING_SEQ,
            STRING_ID,
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
            CELL_12,
			MAT_ID
        }

        #endregion

        #region [Variable Definition]

        private int i_ng_cnt = 0;
        private int i_cng_cnt = 0;

        #endregion

        #region [FormDefinition]

        #endregion

        #region [Function Definition]

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case CSGC.MP_CHECK_UPDATE:

                        break;

                    case CSGC.MP_CHECK_CREATE:

                        if (string.IsNullOrEmpty(txtTrayNoLeft.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[NG Tray No]"));
                            MPCF.SetFocus(txtTrayNoLeft);
                            return false;
                        }

                        if (chkOutSelection.OnOffState == SOICheckBoxOnOffState.OnState && string.IsNullOrEmpty(txtTrayNoRight.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Tray ID]"));
                            MPCF.SetFocus(txtTrayNoRight);
                            return false;
                        }

                        if (string.IsNullOrEmpty(txtOkTray.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Tray ID]"));
                            MPCF.SetFocus(txtOkTray);
                            return false;
                        }

                        if(i_ng_cnt == 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(423));
                            return false;
                        }

                        if (chkOutSelection.OnOffState == SOICheckBoxOnOffState.OnState && i_cng_cnt == 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(424));
                            return false;
                        }

                        if (string.IsNullOrEmpty(cdvMaterial.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(389));
                            return false;
                        }

                        break;

                    case CSGC.MP_CHECK_VIEW:

                        if ((txtTrayNoLeft.Tag != null && txtTrayNoRight.Tag != null) && txtTrayNoLeft.Tag.ToString() == txtTrayNoRight.Tag.ToString())
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(301));
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

        private bool ExistTrayID(object sCase, string sTrayID)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            try
            {
                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TRAY_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(sTrayID);

                if (TPDR.GetDataOne("", ref dt, "VIEW_TRAY_EXIST_LIST", dvcArgu, false, false, ref s_sql) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(407));

                    if (sCase.Equals(txtTrayNoLeft))
                    {
                        txtTrayNoLeft.Tag = null;
                        txtTrayNoLeft.Text = string.Empty;
                        spdTrayListLeft_Sheet1.RowCount = 0;
                        spdTrayListLeft.Tag = null;
                        MPCF.SetFocus(txtTrayNoLeft);
                    }
                    else if (sCase.Equals(txtTrayNoRight))
                    {
                        txtTrayNoRight.Tag = null;
                        txtTrayNoRight.Text = string.Empty;
                        spdTrayListRight_Sheet1.RowCount = 0;
                        spdTrayListRight.Tag = null;
                        MPCF.SetFocus(txtTrayNoRight);
                    }
                    else if (sCase.Equals(txtOkTray))
                    {
                        txtOkTray.Tag = null;
                        txtOkTray.Text = string.Empty;
                        spdOKTray_Sheet1.RowCount = 0;
                        MPCF.SetFocus(txtOkTray);
                    }

                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool ViewTrayInfo(object sCase, string sTrayID)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];
            DataTable dt = null;
            string s_sql = "";
            string s_string_id = "";
            string s_tray_type = "";

            try
            {
                if (sCase.Equals(txtTrayNoLeft))
                {
                    i_ng_cnt = 0;
                    spdTrayListLeft_Sheet1.RowCount = 0;
                    spdCellDefect_Sheet1.RowCount = 0;
                    txtTrayNoLeft.Tag = sTrayID;
                    s_tray_type = "NG";
                }
                else if (sCase.Equals(txtTrayNoRight))
                {
                    i_cng_cnt = 0;
                    spdTrayListRight_Sheet1.RowCount = 0;
                    txtTrayNoRight.Tag = sTrayID;
                    s_tray_type = "OK";
                }
                else if (sCase.Equals(txtOkTray))
                {
                    spdOKTray_Sheet1.RowCount = 0;
                    txtOkTray.Tag = sTrayID;
                    s_tray_type = "OK";
                }

                //Tag 값 입력 후 체크로직
                if (!CheckCondition(CSGC.MP_CHECK_VIEW))
                    return false;

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TRAY_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(sTrayID);

                dvcArgu[2].sCondtion_ID = "$TRAY_TYPE";
                dvcArgu[2].sCondition_Value = MPCF.Trim(s_tray_type);

                //if (TPDR.GetDataOne("", ref dt, "VIEW_TRAY_STRING_LIST", dvcArgu, false, false, ref s_sql) == false)
                if (TPDR.GetDataOne("", ref dt, "VIEW_TRAY_STRING_LIST_01", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (sCase.Equals(txtTrayNoLeft))
                    {
                        spdTrayListRight_Sheet1.RowCount = 0;
                        MPCF.SetFocus(txtTrayNoLeft);
                    }
                    else if (sCase.Equals(txtTrayNoRight))
                    {
                        spdTrayListRight_Sheet1.RowCount = 0;
                        MPCF.SetFocus(txtTrayNoRight);
                    }

                    else if (sCase.Equals(txtOkTray))
                    {
                        spdOKTray_Sheet1.RowCount = 0;
                        MPCF.SetFocus(txtOkTray);
                    }

                    if(dt.Rows.Count == 0)
                    {
                        MPCF.ShowMessage("Data가 존재하지 않습니다.", MSG_LEVEL.INFO, false);
                    }

                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();

                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (sCase.Equals(txtTrayNoLeft))
                    {                            
                        if (i == 0)
                        {
                            s_string_id = dt.Rows[i]["STRING_ID"].ToString();

                            spdTrayListLeft.ActiveSheet.RowCount++;
                            spdTrayListLeft.ActiveSheet.Cells[i, (int)TRAY.STRING_SEQ].Value = dt.Rows[i]["STRING_SEQ"].ToString();
                            spdTrayListLeft.ActiveSheet.Cells[i, (int)TRAY.STRING_ID].Value = dt.Rows[i]["STRING_ID"].ToString();
							spdTrayListLeft.ActiveSheet.Cells[i, (int)TRAY.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                        }
                        else
                        {
                            if (s_string_id != dt.Rows[i]["STRING_ID"].ToString())
                            {
                                spdTrayListLeft.ActiveSheet.RowCount++;
                                spdTrayListLeft.ActiveSheet.Cells[spdTrayListLeft.ActiveSheet.RowCount - 1, (int)TRAY.STRING_SEQ].Value = dt.Rows[i]["STRING_SEQ"].ToString();
                                spdTrayListLeft.ActiveSheet.Cells[spdTrayListLeft.ActiveSheet.RowCount - 1, (int)TRAY.STRING_ID].Value = dt.Rows[i]["STRING_ID"].ToString();
								spdTrayListLeft.ActiveSheet.Cells[spdTrayListLeft.ActiveSheet.RowCount - 1, (int)TRAY.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();

                                s_string_id = dt.Rows[i]["STRING_ID"].ToString();
                            }                            
                        }

                        if (dt.Rows[i]["LOSS_CODE"].ToString() != " ")
                        {
                            spdTrayListLeft.ActiveSheet.Cells[spdTrayListLeft.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString()) + 1].BackColor = Color.Red;
                            spdTrayListLeft.ActiveSheet.Cells[spdTrayListLeft.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString()) + 1].Tag = dt.Rows[i]["CELL_ID"].ToString();

                            spdCellDefect.ActiveSheet.RowCount++;
                            spdCellDefect.ActiveSheet.Cells[spdCellDefect.ActiveSheet.RowCount - 1, 0].Text = dt.Rows[i]["LOSS_CODE"].ToString();
                            spdCellDefect.ActiveSheet.Cells[spdCellDefect.ActiveSheet.RowCount - 1, 1].Text = dt.Rows[i]["LOSS_CODE_DESC"].ToString();
                        }
                        else
                        {
                            spdTrayListLeft.ActiveSheet.Cells[spdTrayListLeft.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString()) + 1].BackColor = Color.LightGreen;
                            spdTrayListLeft.ActiveSheet.Cells[spdTrayListLeft.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString()) + 1].Tag = dt.Rows[i]["CELL_ID"].ToString();
                        }

                        MPCF.FitColumnHeader(spdTrayListLeft);
                        spdTrayListLeft.ActiveSheet.Columns[1].Width = 170;
                    }
                    else if (sCase.Equals(txtTrayNoRight))
                    {
                        if (i == 0)
                        {
                            s_string_id = dt.Rows[i]["STRING_ID"].ToString();

                            spdTrayListRight.ActiveSheet.RowCount++;
                            spdTrayListRight.ActiveSheet.Cells[i, (int)TRAY.STRING_SEQ].Value = dt.Rows[i]["STRING_SEQ"].ToString();
                            spdTrayListRight.ActiveSheet.Cells[i, (int)TRAY.STRING_ID].Value = dt.Rows[i]["STRING_ID"].ToString();
							spdTrayListRight.ActiveSheet.Cells[i, (int)TRAY.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                        }
                        else
                        {
                            if (s_string_id != dt.Rows[i]["STRING_ID"].ToString())
                            {
                                spdTrayListRight.ActiveSheet.RowCount++;
                                spdTrayListRight.ActiveSheet.Cells[spdTrayListRight.ActiveSheet.RowCount - 1, (int)TRAY.STRING_SEQ].Value = dt.Rows[i]["STRING_SEQ"].ToString();
                                spdTrayListRight.ActiveSheet.Cells[spdTrayListRight.ActiveSheet.RowCount - 1, (int)TRAY.STRING_ID].Value = dt.Rows[i]["STRING_ID"].ToString();
								spdTrayListRight.ActiveSheet.Cells[spdTrayListRight.ActiveSheet.RowCount - 1, (int)TRAY.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();

                                s_string_id = dt.Rows[i]["STRING_ID"].ToString();
                            }                            
                        }

                        if (dt.Rows[i]["LOSS_CODE"].ToString() == " ") // CELL 존재하는 값만 확인
                        {
                            spdTrayListRight.ActiveSheet.Cells[spdTrayListRight.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString()) + 1].BackColor = Color.LightGreen;
                            spdTrayListRight.ActiveSheet.Cells[spdTrayListRight.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString()) + 1].Tag = dt.Rows[i]["CELL_ID"].ToString();
                        }

                        MPCF.FitColumnHeader(spdTrayListRight);
                        spdTrayListRight.ActiveSheet.Columns[1].Width = 170;
                    }
                    else if (sCase.Equals(txtOkTray))
                    {
                        if (i == 0)
                        {
                            s_string_id = dt.Rows[i]["STRING_ID"].ToString();

                            spdOKTray.ActiveSheet.RowCount++;
                            spdOKTray.ActiveSheet.Cells[i, (int)TRAY.STRING_SEQ].Value = dt.Rows[i]["STRING_SEQ"].ToString();
                            spdOKTray.ActiveSheet.Cells[i, (int)TRAY.STRING_ID].Value = dt.Rows[i]["STRING_ID"].ToString();
							spdOKTray.ActiveSheet.Cells[i, (int)TRAY.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                        }
                        else
                        {
                            if (s_string_id != dt.Rows[i]["STRING_ID"].ToString())
                            {
                                spdOKTray.ActiveSheet.RowCount++;
                                spdOKTray.ActiveSheet.Cells[spdOKTray.ActiveSheet.RowCount - 1, (int)TRAY.STRING_SEQ].Value = dt.Rows[i]["STRING_SEQ"].ToString();
                                spdOKTray.ActiveSheet.Cells[spdOKTray.ActiveSheet.RowCount - 1, (int)TRAY.STRING_ID].Value = dt.Rows[i]["STRING_ID"].ToString();
								spdOKTray.ActiveSheet.Cells[spdOKTray.ActiveSheet.RowCount - 1, (int)TRAY.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();

                                s_string_id = dt.Rows[i]["STRING_ID"].ToString();
                            }
                        }

                        if (dt.Rows[i]["LOSS_CODE"].ToString() == " ") // CELL 존재하는 값만 확인
                        {
                            spdOKTray.ActiveSheet.Cells[spdOKTray.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString()) + 1].BackColor = Color.LightGreen;
                        }

                        MPCF.FitColumnHeader(spdOKTray);
                        spdOKTray.ActiveSheet.Columns[1].Width = 170;
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

        private bool Tran_String_Repair()
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");
            TRSNode list_item = null;

            int chkCellCnt = 0;
            int chkCnt = 0;
            int chkToRepairCnt = 0;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("NG_TRAY_ID", MPCF.Trim(txtTrayNoLeft.Text));
                in_node.AddString("MOVE_TRAY_ID", MPCF.Trim(txtTrayNoRight.Text));
                in_node.AddString("TRAY_ID", MPCF.Trim(txtOkTray.Text));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));

                if (chkOutSelection.OnOffState == SOICheckBoxOnOffState.OnState)
                {
                    in_node.AddInt("REPAIR_TYPE", 0); //REPAIR_TYPE(0) : 트레이

                    if(i_ng_cnt != i_cng_cnt)
                    {
                        MPCF.ShowErrorMessage(MPCF.GetMessage(419));
                        return false;    
                    }

                    //자재 트레이에서 이동할 대상 CELL
                    for (int q = 0; q < spdTrayListRight.ActiveSheet.RowCount; q++)
                    {
                        for (int w = 2; w < spdTrayListRight.ActiveSheet.Columns.Count; w++)
                        {
                            if (spdTrayListRight.ActiveSheet.Cells[q, w].Text == "√")
                            {
                                list_item = in_node.AddNode("MOVE_CELL_LIST");
                                list_item.AddString("STRING_ID", MPCF.Trim(spdTrayListRight.ActiveSheet.Cells[q, (int)TRAY.STRING_ID].Text));
                                list_item.AddString("CELL_ID", MPCF.Trim(spdTrayListRight.ActiveSheet.Cells[q, w].Tag));
                            }
                        }
                    }
                }
                else
                {
                    in_node.AddInt("REPAIR_TYPE", 1); //MOVE_TYPE(1) : 수리실

                    if(i_ng_cnt > MPCF.ToInt(spdRepairInfo.ActiveSheet.Cells[2,1].Text))
                    {
                        MPCF.ShowErrorMessage(MPCF.GetMessage(420));
                        return false;
                    }
                }

                //NG 트레이에서 선택한 CELL
                for (int q = 0; q < spdTrayListLeft.ActiveSheet.RowCount; q++)
                {
                    for(int w = 0; w < spdTrayListLeft.ActiveSheet.Columns.Count; w++)
                    {
                        if(spdTrayListLeft.ActiveSheet.Cells[q, w].Text == "√")
                        {
                            list_item = in_node.AddNode("NG_CELL_LIST");
                            list_item.AddString("STRING_ID", MPCF.Trim(spdTrayListLeft.ActiveSheet.Cells[q, (int)TRAY.STRING_ID].Text));
                            list_item.AddString("CELL_ID", MPCF.Trim(spdTrayListLeft.ActiveSheet.Cells[q, w].Tag));

                            if (spdTrayListLeft.ActiveSheet.Cells[q, w].BackColor == Color.Red) // 불량이면서 체크된 갯수
                            {
                                list_item.AddInt("ADD_CELL", 1); // 불량테이블 데이터 입력 1
                                chkCnt++;
                            }

                            if (spdTrayListLeft.ActiveSheet.Cells[q, w].BackColor == Color.LightGreen) // 양품이면서 체크된 갯수
                            {
                                list_item.AddInt("ADD_CELL", 0); // 불량테이블 데이터 미입력 수리실 QTY 수량 증가 0
                                chkToRepairCnt++;
                            }
                        }

                        if (q == 0) // 불량 스트링은 맨 위 상단만 불량 갯수 카운트 함
                        {
                            if (spdTrayListLeft.ActiveSheet.Cells[q, w].BackColor == Color.Red) // 불량 갯수
                                chkCellCnt++;
                        }
                    }
                }

                if (chkOutSelection.OnOffState == SOICheckBoxOnOffState.OnState) //트레일 경우 양품 불량 수량 나누어서 처리 / 수리실일 경우 선택된 수량만큼 처리
                    in_node.AddInt("NG_CNT", chkToRepairCnt);
                else
                    in_node.AddInt("NG_CNT", chkCnt);

                if (chkCellCnt == chkCnt) //스트링 내의 불량 수량 == 선택한 불량 Cell 갯수가 같으면 OK Tray로 이동시킨다. MOVE_TYPE(1) : 이동 / MOVE_TYPE(0) : 이동 안함
                {
                    in_node.AddInt("MOVE_TYPE", 1);
                }
                else
                {
                    in_node.AddString("MOVE_TYPE", 0);
                }

                if (MPCF.CallService("CUS", "CWIP_Tran_Defect_String_Repair", in_node, ref out_node) == false)
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

        private void SetMatInfo()
        {
            try
            {
                DataTable dt = null;
                string s_sql = "";

                if (string.IsNullOrEmpty(cdvMaterial.Text) == false)
                {
                    TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                    dvcArgu[0].sCondtion_ID = "$FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    dvcArgu[1].sCondtion_ID = "$MAT_ID";
                    dvcArgu[1].sCondition_Value = cdvMaterial.Text;

                    // CodeView Column Header Setup
                    string[] header = new string[] { "Code", "Code Desc" };

                    // CodeView Display Column Setup
                    string[] display = new string[] { "RES_ID", "RES_DESC" };

                    if (TPDR.GetDataOne("", ref dt, "VIEW_REPAIR_MAT_INFO", dvcArgu, false, false, ref s_sql) == false)
                    {
                        if (dt != null)
                            dt.Dispose();

                        GC.Collect();
                        return;
                    }

                    if (dt.Rows.Count == 1)
                    {
                        spdRepairInfo.ActiveSheet.Cells[0, 1].Text = dt.Rows[0]["MAT_ID"].ToString();
                        spdRepairInfo.ActiveSheet.Cells[0, 3].Text = dt.Rows[0]["MAT_DESC"].ToString();
                        spdRepairInfo.ActiveSheet.Cells[1, 1].Text = dt.Rows[0]["OPER"].ToString();
                        spdRepairInfo.ActiveSheet.Cells[1, 3].Text = dt.Rows[0]["OPER_DESC"].ToString();
                        spdRepairInfo.ActiveSheet.Cells[2, 1].Text = dt.Rows[0]["QTY_1"].ToString();
                        spdRepairInfo.ActiveSheet.Cells[2, 3].Text = dt.Rows[0]["UNIT_1"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region [Event Definition]

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmCUSTranDefectStringRepair_Load(object sender, EventArgs e)
        {
			InitCtrl();	
        }

        private void frmCUSTranDefectStringRepair_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                bIsShown = true;

                MPCF.SetFocus(txtTrayNoLeft);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnViewLeft))
            {
                if (txtTrayNoLeft.Text.Equals(string.Empty)) return;

                if (ExistTrayID(txtTrayNoLeft, txtTrayNoLeft.Text))
                {
                    ViewTrayInfo(txtTrayNoLeft, txtTrayNoLeft.Text);
                    MPCF.SetFocus(txtTrayNoLeft);
                }
            }
            else if (sender.Equals(btnViewRight))
            {
                if (txtTrayNoRight.Text.Equals(string.Empty)) return;

                if (ExistTrayID(txtTrayNoRight, txtTrayNoRight.Text))
                {
                    ViewTrayInfo(txtTrayNoRight, txtTrayNoRight.Text);
                    MPCF.SetFocus(txtTrayNoLeft);
                }
            }
            else if (sender.Equals(btnViewOkTray))
            {
                if (txtOkTray.Text.Equals(string.Empty)) return;

                if (ExistTrayID(txtOkTray, txtOkTray.Text))
                {
                    ViewTrayInfo(txtOkTray, txtOkTray.Text);
                    MPCF.SetFocus(txtOkTray);
                }
            }
        }

        private void txtTrayNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER)
            {
                if (sender.Equals(txtTrayNoLeft))
                {
                    if (txtTrayNoLeft.Text.Equals(string.Empty)) return;

                    txtTrayNoLeft.Text = MPCF.ToUpper(txtTrayNoLeft.Text); // 일괄 대문자

                    if (ExistTrayID(txtTrayNoLeft, txtTrayNoLeft.Text))
                    {
                        ViewTrayInfo(txtTrayNoLeft, txtTrayNoLeft.Text);
                        MPCF.SetFocus(txtTrayNoLeft);
                    }
                }
                else if (sender.Equals(txtTrayNoRight))
                {
                    if (txtTrayNoRight.Text.Equals(string.Empty)) return;

                    txtTrayNoRight.Text = MPCF.ToUpper(txtTrayNoRight.Text); // 일괄 대문자

                    if (ExistTrayID(txtTrayNoRight, txtTrayNoRight.Text))
                    {
                        ViewTrayInfo(txtTrayNoRight, txtTrayNoRight.Text);
                        MPCF.SetFocus(txtTrayNoRight);
                    }
                }
                else if (sender.Equals(txtOkTray))
                {
                    if (txtOkTray.Text.Equals(string.Empty)) return;

                    txtOkTray.Text = MPCF.ToUpper(txtOkTray.Text); // 일괄 대문자

                    if (ExistTrayID(txtOkTray, txtOkTray.Text))
                    {
                        ViewTrayInfo(txtOkTray, txtOkTray.Text);
                        MPCF.SetFocus(txtOkTray);
                    }
                }
            }
        }

        private void spdTrayListLeft_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (e.Column == 0 || e.Column == 1) return;

                if (e.Row != 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(426));
                    return;
                }

                if (spdTrayListLeft.ActiveSheet.Cells[e.Row, e.Column].BackColor != Color.LightGreen && spdTrayListLeft.ActiveSheet.Cells[e.Row, e.Column].BackColor != Color.Red) //존재 값만 조회함으로 색으로 구분
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(421));
                    return;
                }

                if (string.IsNullOrEmpty(txtTrayNoLeft.Text) == true)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Tray ID]"));
                    MPCF.SetFocus(txtTrayNoLeft);
                    return;
                }

                if (i_ng_cnt > 0 && spdTrayListLeft.Tag != spdTrayListLeft.ActiveSheet.Cells[e.Row, (int)TRAY.STRING_ID].Value)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(422));
                    return;
                }

                if (spdTrayListLeft.ActiveSheet.Cells[e.Row, e.Column].Text == "√")
                {
                    spdTrayListLeft.ActiveSheet.Cells[e.Row, e.Column].Text = "";
                    i_ng_cnt--;

                    if (i_ng_cnt == 0)
                        spdTrayListLeft.Tag = null;
                }
                else
                {
                    spdTrayListLeft.ActiveSheet.Cells[e.Row, e.Column].Text = "√";
                    i_ng_cnt++;
                    spdTrayListLeft.Tag = spdTrayListLeft.ActiveSheet.Cells[e.Row, (int)TRAY.STRING_ID].Value;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void spdTrayListRight_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (spdTrayListRight.ActiveSheet.RowCount == 0) return;

                if (e.Column == 0 || e.Column == 1) return;

                if (spdTrayListRight.ActiveSheet.Cells[e.Row, e.Column].BackColor != Color.LightGreen) //존재 값만 조회함으로 색으로 구분
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(421));
                    return;
                }

                if (spdTrayListRight.ActiveSheet.Cells[e.Row, e.Column].Text == "√")
                {
                    spdTrayListRight.ActiveSheet.Cells[e.Row, e.Column].Text = "";
                    i_cng_cnt--;

                    if (i_cng_cnt == 0)
                        spdTrayListRight.Tag = null;
                }
                else
                {
                    spdTrayListRight.ActiveSheet.Cells[e.Row, e.Column].Text = "√";
                    i_cng_cnt++;
                    spdTrayListRight.Tag = spdTrayListRight.ActiveSheet.Cells[e.Row, (int)TRAY.STRING_ID].Value;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            MPCF.ShowMessageClear();

            if (!CheckCondition(CSGC.MP_CHECK_CREATE))
                return;

            DialogResult dr = MPCF.ShowMsgBox(MPCF.GetMessage(425), MessageBoxButtons.OKCancel, SOI.CliFrx.MSG_LEVEL.WARNING);
            if (dr != System.Windows.Forms.DialogResult.OK)
                return;

            if (Tran_String_Repair() == true)
            {
                btnViewLeft.PerformClick();
                btnViewRight.PerformClick();
                btnViewOkTray.PerformClick();
                SetMatInfo();
            }
        }

        private void ViewRefairMaterial()
        {
			string sViewID = string.Empty;

			TPDR.DirectViewCond[] ArrDVC;
			DataTable dt = new DataTable();

			try
			{
				ArrDVC = new TPDR.DirectViewCond[1];
				ArrDVC[0].sCondtion_ID = "$FACTORY";
				ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                //string[] header = new string[] { "Material ID", "Material Desc", "Qty", "Cell Desc"};
                //string[] display = new string[] { "MAT_ID", "MAT_DESC", "QTY_1", "MAT_GUBN"};

                //cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "Material List", "VIEW_REPAIR_OPER_DETAIL_LIST", ArrDVC, display, header, "MAT_ID", -1);

                string[] header = new string[] { "Material ID", "Material Desc", "Qty", "Cell Desc", "Cell Efficiency", "Vender" };
                string[] display = new string[] { "MAT_ID", "MAT_DESC", "QTY_1", "MAT_GUBN", "CELL_EFFICIENCY", "VENDER" };

                cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "Material List", "VIEW_REPAIR_OPER_DETAIL_LIST_1", ArrDVC, display, header, "MAT_ID", -1);

				if (cdvMaterial.returnDatas != null && cdvMaterial.returnDatas.Count > 0)
				{
					cdvMaterial.Text = cdvMaterial.returnDatas[0];
				}
			}
			catch (Exception ex)
			{
				MPCF.ShowMsgBox(ex.Message);
				return;
			}
        }

        private void cdvMaterial_ValueChanged(object sender, EventArgs e)
        {
            SetMatInfo();
        }

        private void chkOutSelection_OnOffStateChanged(object sender, EventArgs e)
        {
            try
            {
                //MPCF.ClearList(spdTrayListRight);
                //txtTrayNoRight.Tag = null;
                //txtTrayNoRight.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnDefectCellRegister_Click(object sender, EventArgs e)
        {
            try
            {
                MenuInfoTag selectedMenuInfo;
                frmCUSTranDefectCellRegister frm = new frmCUSTranDefectCellRegister(txtTrayNoLeft.Text);
                selectedMenuInfo = new MenuInfoTag();
                selectedMenuInfo.s_func_desc = "Defect Cell Register";
                frm.Tag = selectedMenuInfo;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            } 
        }

        #endregion

		private void cdvMaterial_CodeViewButtonClick(object sender, EventArgs e)
		{
			if (sender.Equals(cdvMaterial))
			{
				ViewRefairMaterial();
			}
		}

		private void InitCtrl()
		{
			try
			{
				MPCF.ClearList(spdTrayListLeft);
				MPCF.ClearList(spdTrayListRight);
				MPCF.ClearList(spdCellDefect);
				MPCF.ClearList(spdOKTray);
			}
			catch (Exception ex)
			{
				MPCF.ShowMsgBox(ex.Message);
			}
		}

		private void ViewRawMatList(BOICodeView cdvView)
		{
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

            try
            {
                sViewID = "VIEW_MAT_CELL_LIST";
                i_cond_cnt = 1;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                // CodeView Column Header Setup
                string[] header = new string[] { "Material ID", "Material Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "MAT_ID", "MAT_DESC" };

                // Show by RPTServer
				cdvView.Text = cdvView.Show(cdvView, "Material List", sViewID, ArrDVC, display, header, "MAT_ID", -1);

				if (cdvView.returnDatas != null && cdvView.returnDatas.Count > 0)
                {
					cdvView.Text = cdvMaterial.returnDatas[0];
                }
                else
                {
					cdvView.Text = string.Empty;
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
