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
    public partial class frmCUSTranTrayStringChange : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        #region [Property]

        private bool bIsShown = false;
        const int ENTER = 13;

        #endregion

        public frmCUSTranTrayStringChange()
        {
            InitializeComponent();
        }

        #region [Constant Definition]

        public enum TRAY
        {
            STRING_SEQ,
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
            CELL_12,
            TRAY_ID,
            TRAY_TYPE,
			MAT_ID
        }

        public enum ATTACH_CASE
        {
            LEFT_TO_RIGHT,
            RIGHT_TO_LEFT
        }

        #endregion

        #region [Variable Definition]

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

                        if (txtTrayNoLeft.Tag == null || txtTrayNoRight.Tag == null)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(404));
                            return false;
                        }

                        if (spdTrayListRight.ActiveSheet.RowCount != 0 && spdTrayListLeft.ActiveSheet.RowCount != 0 && !spdTrayListRight.ActiveSheet.Cells[0, (int)TRAY.TRAY_TYPE].Value.Equals(spdTrayListLeft.ActiveSheet.Cells[0, (int)TRAY.TRAY_TYPE].Value))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(406));
                            return false;
                        }

                        break;

                    case CSGC.MP_CHECK_CREATE:

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
                        MPCF.SetFocus(txtTrayNoLeft);
                    }
                    else if (sCase.Equals(txtTrayNoRight))
                    {
                        txtTrayNoRight.Tag = null;
                        txtTrayNoRight.Text = string.Empty;
                        spdTrayListRight_Sheet1.RowCount = 0;
                        MPCF.SetFocus(txtTrayNoRight);
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
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";
            string strStringID = string.Empty;

            try
            {
                if (sCase.Equals(txtTrayNoLeft))
                {
                    spdTrayListLeft_Sheet1.RowCount = 0;
                    txtTrayNoLeft.Tag = sTrayID;
                }
                else if (sCase.Equals(txtTrayNoRight))
                {
                    spdTrayListRight_Sheet1.RowCount = 0;
                    txtTrayNoRight.Tag = sTrayID;
                }
                //Tag 값 입력 후 체크로직
                if (!CheckCondition(CSGC.MP_CHECK_VIEW))
                    return false;

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TRAY_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(sTrayID);

                //if (TPDR.GetDataOne("", ref dt, "VIEW_TRAY_STRING_CASE_LIST", dvcArgu, false, false, ref s_sql) == false)
                if (TPDR.GetDataOne("", ref dt, "VIEW_TRAY_STRING_CASE_LIST_01", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (sCase.Equals(txtTrayNoLeft))
                    {
                        spdTrayListLeft_Sheet1.RowCount = 0;
                        MPCF.SetFocus(txtTrayNoLeft);
                    }
                    else if (sCase.Equals(txtTrayNoRight))
                    {
                        spdTrayListRight_Sheet1.RowCount = 0;
                        MPCF.SetFocus(txtTrayNoRight);
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
                            strStringID = dt.Rows[i]["STRING_ID"].ToString();
                            spdTrayListLeft.ActiveSheet.RowCount++;
                            spdTrayListLeft.ActiveSheet.Cells[i, (int)TRAY.TRAY_ID].Value = dt.Rows[i]["TRAY_ID"].ToString();
                            spdTrayListLeft.ActiveSheet.Cells[i, (int)TRAY.STRING].Value = dt.Rows[i]["STRING_ID"].ToString();
                            spdTrayListLeft.ActiveSheet.Cells[i, (int)TRAY.STRING_SEQ].Value = dt.Rows[i]["STRING_SEQ"].ToString();
                            spdTrayListLeft.ActiveSheet.Cells[i, (int)TRAY.TRAY_TYPE].Value = dt.Rows[i]["TRAY_TYPE"].ToString();
							spdTrayListLeft.ActiveSheet.Cells[i, (int)TRAY.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                        }
                        else 
                        {
                            if (strStringID != dt.Rows[i]["STRING_ID"].ToString())
                            {
                                strStringID = dt.Rows[i]["STRING_ID"].ToString();
                                spdTrayListLeft.ActiveSheet.RowCount++;
                                spdTrayListLeft.ActiveSheet.Cells[spdTrayListLeft.ActiveSheet.RowCount - 1, (int)TRAY.TRAY_ID].Value = dt.Rows[i]["TRAY_ID"].ToString();
                                spdTrayListLeft.ActiveSheet.Cells[spdTrayListLeft.ActiveSheet.RowCount - 1, (int)TRAY.STRING].Value = dt.Rows[i]["STRING_ID"].ToString();
                                spdTrayListLeft.ActiveSheet.Cells[spdTrayListLeft.ActiveSheet.RowCount - 1, (int)TRAY.STRING_SEQ].Value = dt.Rows[i]["STRING_SEQ"].ToString();
                                spdTrayListLeft.ActiveSheet.Cells[spdTrayListLeft.ActiveSheet.RowCount - 1, (int)TRAY.TRAY_TYPE].Value = dt.Rows[i]["TRAY_TYPE"].ToString();
								spdTrayListLeft.ActiveSheet.Cells[spdTrayListLeft.ActiveSheet.RowCount - 1, (int)TRAY.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                            }
                        }

                        if (dt.Rows[i]["LOSS_CODE"].ToString() != " ")
                        {
                            spdTrayListLeft.ActiveSheet.Cells[spdTrayListLeft.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString()) + 1].Text = "√";
                            spdTrayListLeft.ActiveSheet.Cells[spdTrayListLeft.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString()) + 1].BackColor = Color.Red;
                        }
                        else
                        {
                            spdTrayListLeft.ActiveSheet.Cells[spdTrayListLeft.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString()) + 1].BackColor = Color.LightGreen;
                        }

                        MPCF.FitColumnHeader(spdTrayListLeft);
                    }
                    else if (sCase.Equals(txtTrayNoRight))
                    {
                        if (i == 0)
                        {
                            strStringID = dt.Rows[i]["STRING_ID"].ToString();
                            spdTrayListRight.ActiveSheet.RowCount++;
                            spdTrayListRight.ActiveSheet.Cells[i, (int)TRAY.TRAY_ID].Value = dt.Rows[i]["TRAY_ID"].ToString();
                            spdTrayListRight.ActiveSheet.Cells[i, (int)TRAY.STRING].Value = dt.Rows[i]["STRING_ID"].ToString();
                            spdTrayListRight.ActiveSheet.Cells[i, (int)TRAY.STRING_SEQ].Value = dt.Rows[i]["STRING_SEQ"].ToString();
                            spdTrayListRight.ActiveSheet.Cells[i, (int)TRAY.TRAY_TYPE].Value = dt.Rows[i]["TRAY_TYPE"].ToString();
							spdTrayListRight.ActiveSheet.Cells[i, (int)TRAY.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                        }
                        else
                        {
                            if (strStringID != dt.Rows[i]["STRING_ID"].ToString())
                            {
                                strStringID = dt.Rows[i]["STRING_ID"].ToString();
                                spdTrayListRight.ActiveSheet.RowCount++;
                                spdTrayListRight.ActiveSheet.Cells[spdTrayListRight.ActiveSheet.RowCount - 1, (int)TRAY.TRAY_ID].Value = dt.Rows[i]["TRAY_ID"].ToString();
                                spdTrayListRight.ActiveSheet.Cells[spdTrayListRight.ActiveSheet.RowCount - 1, (int)TRAY.STRING].Value = dt.Rows[i]["STRING_ID"].ToString();
                                spdTrayListRight.ActiveSheet.Cells[spdTrayListRight.ActiveSheet.RowCount - 1, (int)TRAY.STRING_SEQ].Value = dt.Rows[i]["STRING_SEQ"].ToString();
                                spdTrayListRight.ActiveSheet.Cells[spdTrayListRight.ActiveSheet.RowCount - 1, (int)TRAY.TRAY_TYPE].Value = dt.Rows[i]["TRAY_TYPE"].ToString();
								spdTrayListRight.ActiveSheet.Cells[spdTrayListRight.ActiveSheet.RowCount - 1, (int)TRAY.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                            }
                        }

                        if (dt.Rows[i]["LOSS_CODE"].ToString() != " ")
                        {
                            spdTrayListRight.ActiveSheet.Cells[spdTrayListRight.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString()) + 1].Text = "√";
                            spdTrayListRight.ActiveSheet.Cells[spdTrayListRight.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString()) + 1].BackColor = Color.Red;
                        }
                        else
                        {
                            spdTrayListRight.ActiveSheet.Cells[spdTrayListRight.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString()) + 1].BackColor = Color.LightGreen;
                        }

                        MPCF.FitColumnHeader(spdTrayListRight);
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

        private bool UpdateStringID(ATTACH_CASE attachCase)
        {
            TRSNode in_node = new TRSNode("CUS_CREATE_TRAYLIST_IN");
            TRSNode out_node = new TRSNode("CUS_CREATE_TRAYLIST_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_UPDATE;

                if (attachCase.Equals(ATTACH_CASE.RIGHT_TO_LEFT))
                {
                    in_node.AddString("TRAY_ID_START", MPCF.Trim(spdTrayListRight.ActiveSheet.Cells[0, (int)TRAY.TRAY_ID].Value));

                    //스트링 값이 없는 곳으로 이동시 TAG 값 참조
                    if (spdTrayListLeft.ActiveSheet.RowCount == 0)
                        in_node.AddString("TRAY_ID_DEST", MPCF.Trim(txtTrayNoLeft.Tag.ToString()));
                    else
                        in_node.AddString("TRAY_ID_DEST", MPCF.Trim(spdTrayListLeft.ActiveSheet.Cells[0, (int)TRAY.TRAY_ID].Value));

                    in_node.AddString("STRING_ID", MPCF.Trim(spdTrayListRight.ActiveSheet.Cells[0, (int)TRAY.STRING].Value));
                    in_node.AddString("STRING_SEQ", MPCF.Trim(spdTrayListRight.ActiveSheet.Cells[0, (int)TRAY.STRING_SEQ].Value));
                    in_node.AddString("TRAY_TYPE", MPCF.Trim(spdTrayListRight.ActiveSheet.Cells[0, (int)TRAY.TRAY_TYPE].Value));
                }
                else if (attachCase.Equals(ATTACH_CASE.LEFT_TO_RIGHT))
                {
                    in_node.AddString("TRAY_ID_START", MPCF.Trim(spdTrayListLeft.ActiveSheet.Cells[0, (int)TRAY.TRAY_ID].Value));

                    //스트링 값이 없는 곳으로 이동시 TAG 값 참조
                    if (spdTrayListRight.ActiveSheet.RowCount == 0)
                        in_node.AddString("TRAY_ID_DEST", MPCF.Trim(txtTrayNoRight.Tag.ToString()));
                    else
                        in_node.AddString("TRAY_ID_DEST", MPCF.Trim(spdTrayListRight.ActiveSheet.Cells[0, (int)TRAY.TRAY_ID].Value));

                    in_node.AddString("STRING_ID", MPCF.Trim(spdTrayListLeft.ActiveSheet.Cells[0, (int)TRAY.STRING].Value));
                    in_node.AddString("STRING_SEQ", MPCF.Trim(spdTrayListLeft.ActiveSheet.Cells[0, (int)TRAY.STRING_SEQ].Value));
                    in_node.AddString("TRAY_TYPE", MPCF.Trim(spdTrayListLeft.ActiveSheet.Cells[0, (int)TRAY.TRAY_TYPE].Value));
                }

                if (MPCF.CallService("CUS", "CWIP_Tran_String_Update", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, true);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        #region [Event Definition]

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmCUSTranTrayStringChange_Load(object sender, EventArgs e)
        {
            MPCF.ClearList(spdTrayListLeft);
            MPCF.ClearList(spdTrayListRight);
        }

        private void frmCUSTranTrayStringChange_Shown(object sender, EventArgs e)
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
                if (txtTrayNoLeft.Text.Equals(string.Empty))
                {
                    MPCF.SetFocus(txtTrayNoLeft);
                    return;
                }

                if (ExistTrayID(txtTrayNoLeft, txtTrayNoLeft.Text))
                {
                    ViewTrayInfo(txtTrayNoLeft, txtTrayNoLeft.Text);
                    MPCF.SetFocus(txtTrayNoRight);
                }
            }
            else if (sender.Equals(btnViewRight))
            {
                if (txtTrayNoRight.Text.Equals(string.Empty))
                {
                    MPCF.SetFocus(txtTrayNoRight);
                    return;
                }

                if (ExistTrayID(txtTrayNoRight, txtTrayNoRight.Text))
                {
                    ViewTrayInfo(txtTrayNoRight, txtTrayNoRight.Text);
                    MPCF.SetFocus(txtTrayNoLeft);
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
                        MPCF.SetFocus(txtTrayNoRight);
                    }
                }
                else if (sender.Equals(txtTrayNoRight))
                {
                    if (txtTrayNoRight.Text.Equals(string.Empty)) return;

                    txtTrayNoRight.Text = MPCF.ToUpper(txtTrayNoRight.Text); // 일괄 대문자

                    if (ExistTrayID(txtTrayNoRight, txtTrayNoRight.Text))
                    {
                        ViewTrayInfo(txtTrayNoRight, txtTrayNoRight.Text);
                        MPCF.SetFocus(txtTrayNoLeft);
                    }
                }
            }
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            if (!CheckCondition(CSGC.MP_CHECK_UPDATE)) // Tray 조회여부
                return;

            if (sender.Equals(btnRightToLeft))
            {
                if (spdTrayListRight_Sheet1.RowCount == 0) // 이동할 Tray 존재여부
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(405));
                    return;
                }

                if (UpdateStringID(ATTACH_CASE.RIGHT_TO_LEFT))
                {
                    ViewTrayInfo(txtTrayNoLeft, txtTrayNoLeft.Tag.ToString());
                    ViewTrayInfo(txtTrayNoRight, txtTrayNoRight.Tag.ToString());
                }
            }

            if (sender.Equals(btnLeftToRight))
            {
                if (spdTrayListLeft_Sheet1.RowCount == 0) // 이동할 Tray 존재여부
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(405));
                    return;
                }

                if (UpdateStringID(ATTACH_CASE.LEFT_TO_RIGHT))
                {
                    ViewTrayInfo(txtTrayNoLeft, txtTrayNoLeft.Tag.ToString());
                    ViewTrayInfo(txtTrayNoRight, txtTrayNoRight.Tag.ToString());
                }
            }
        }

        private void btnCellBatch_Click(object sender, EventArgs e)
        {
            try
            {
                //셀배치작업 화면
                BICF.OpenMenu("SOI3004");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            } 
        }

        private void btnRawInstall_Click(object sender, EventArgs e)
        {
            try
            {
                //자재장착관리 화면
                BICF.OpenMenu("SOI3003");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            } 
        }

        private void btnTrayStringCreate_Click(object sender, EventArgs e)
        {
            try
            {
                //스트레이 스트링 생성 화면
                BICF.OpenMenu("SOI2020");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            } 
        }

        #endregion

    }
}
