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
    public partial class frmCUSTranDefectCellRegister : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        #region [Property]

        const int ENTER = 13;

        #endregion

        public frmCUSTranDefectCellRegister(string sTrayID)
        {
            InitializeComponent();

            MPCF.ConvertCaption(this);
            MPCF.FieldClear(this);

            txtTrayID.Text = sTrayID;

            cdvDefectCode.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvDefectCode.Text"));
            cdvDefectCode.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvDefectCode.Tag"));
            txtDefectCodeDesc.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvLine.Text"));

            if (ExistTrayID(txtTrayID.Text))
            {
                ViewTrayInfo(txtTrayID.Text);
            }
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
            CELL_12
        }

        #endregion

        private bool bIsShown = false;

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case CSGC.MP_CHECK_UPDATE:

                        break;

                    case CSGC.MP_CHECK_CREATE:

                        break;

                    case CSGC.MP_CHECK_VIEW:

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

        private bool ExistTrayID(string sTrayID)
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
                    txtTrayID.Tag = null;
                    txtTrayID.Text = string.Empty;
                    spdTrayList_Sheet1.RowCount = 0;
                    spdTrayList.Tag = null;
                    MPCF.SetFocus(txtTrayID);

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

        private bool ViewTrayInfo(string sTrayID)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];
            DataTable dt = null;
            string s_sql = "";
            string s_string_id = "";
            string s_tray_type = "";

            try
            {
                spdTrayList_Sheet1.RowCount = 0;
                txtTrayID.Tag = sTrayID;
                s_tray_type = "NG";

                //Tag 값 입력 후 체크로직
                if (!CheckCondition(CSGC.MP_CHECK_VIEW))
                    return false;

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TRAY_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(sTrayID);

                dvcArgu[2].sCondtion_ID = "$TRAY_TYPE";
                dvcArgu[2].sCondition_Value = MPCF.Trim(s_tray_type);

                if (TPDR.GetDataOne("", ref dt, "VIEW_TRAY_STRING_LIST", dvcArgu, false, false, ref s_sql) == false)
                {
                    MPCF.SetFocus(txtTrayID);

                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();

                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        s_string_id = dt.Rows[i]["STRING_ID"].ToString();

                        spdTrayList.ActiveSheet.RowCount++;
                        spdTrayList.ActiveSheet.Cells[i, (int)TRAY.STRING_SEQ].Value = dt.Rows[i]["STRING_SEQ"].ToString();
                        spdTrayList.ActiveSheet.Cells[i, (int)TRAY.STRING_ID].Value = dt.Rows[i]["STRING_ID"].ToString();
                    }
                    else
                    {
                        if (s_string_id != dt.Rows[i]["STRING_ID"].ToString())
                        {
                            spdTrayList.ActiveSheet.RowCount++;
                            spdTrayList.ActiveSheet.Cells[spdTrayList.ActiveSheet.RowCount - 1, (int)TRAY.STRING_SEQ].Value = dt.Rows[i]["STRING_SEQ"].ToString();
                            spdTrayList.ActiveSheet.Cells[spdTrayList.ActiveSheet.RowCount - 1, (int)TRAY.STRING_ID].Value = dt.Rows[i]["STRING_ID"].ToString();

                            s_string_id = dt.Rows[i]["STRING_ID"].ToString();
                        }
                    }

                    if (dt.Rows[i]["LOSS_CODE"].ToString() != " ")
                    {
                        spdTrayList.ActiveSheet.Cells[spdTrayList.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString()) + 1].BackColor = Color.Red;
                        spdTrayList.ActiveSheet.Cells[spdTrayList.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString()) + 1].Tag = dt.Rows[i]["CELL_ID"].ToString();
                    }
                    else
                    {
                        spdTrayList.ActiveSheet.Cells[spdTrayList.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString()) + 1].BackColor = Color.LightGreen;
                        spdTrayList.ActiveSheet.Cells[spdTrayList.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString()) + 1].Tag = dt.Rows[i]["CELL_ID"].ToString();
                    }

                    MPCF.FitColumnHeader(spdTrayList);
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool Tran_Defect_Cell_Register()
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");
            TRSNode list_item = null;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_UPDATE;

                for (int r = 0; r < spdTrayList.ActiveSheet.RowCount; r++)
                {
                    for (int c = 2; c < spdTrayList.ActiveSheet.Columns.Count; c++)
                    {
                        if (spdTrayList.ActiveSheet.Cells[r, c].Text == "√")
                        {
                            list_item = in_node.AddNode("CELL_LIST");
                            list_item.AddString("STRING_ID", MPCF.Trim(spdTrayList.ActiveSheet.Cells[r, (int)TRAY.STRING_ID].Text));
                            list_item.AddString("CELL_ID", MPCF.Trim(spdTrayList.ActiveSheet.Cells[r, c].Tag));
                            list_item.AddString("LOSS_CODE", MPCF.Trim(spdTrayList.ActiveSheet.Cells[r, c].Note));
                        }
                    }
                }

                if (MPCF.CallService("CUS", "CWIP_Tran_Defect_Cell_Register", in_node, ref out_node) == false)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (ExistTrayID(txtTrayID.Text))
            {
                ViewTrayInfo(txtTrayID.Text);
                MPCF.SetFocus(txtTrayID);
            }
        }

        private void frmCUSTranDefectCellRegister_Load(object sender, EventArgs e)
        {
            btnView.PerformClick();
        }

        private void txtTrayID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER)
            {
                txtTrayID.Text = MPCF.ToUpper(txtTrayID.Text); // 일괄 대문자

                MPCF.ShowMessage("", MSG_LEVEL.NONE, false);

                if (txtTrayID.Text.Equals(string.Empty)) return;

                btnView.PerformClick();
            }
        }

        private void frmCUSTranDefectCellRegister_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                bIsShown = true;

                MPCF.SetFocus(txtTrayID);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(spdTrayList);
            cdvDefectCode.Text = string.Empty;
            txtDefectCodeDesc.Text = string.Empty;

            ViewTrayInfo(txtTrayID.Text);
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            MPCF.ShowMessageClear();

            if (!CheckCondition("PROCESS"))
                return;

            if (Tran_Defect_Cell_Register() == true)
            {
                btnView.PerformClick();
            }
        }

        private void cdvDefectCode_CodeViewButtonClick(object sender, EventArgs e)
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
                cdvDefectCode.Text = cdvDefectCode.Show(cdvDefectCode, "Code Desc", "VIEW_GCM_DATA", dvcArgu, display, header, "DATA_1", -1);

                if (cdvDefectCode.returnDatas != null && cdvDefectCode.returnDatas.Count > 0)
                {
                    cdvDefectCode.Text = cdvDefectCode.returnDatas[0];
                    cdvDefectCode.Tag = cdvDefectCode.returnDatas[0];
                    txtDefectCodeDesc.Text = cdvDefectCode.returnDatas[1];
                }
                else
                {
                    cdvDefectCode.Text = string.Empty;
                    cdvDefectCode.Tag = string.Empty;
                    txtDefectCodeDesc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdTrayList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                string s_row_header;
                string s_column_header;

                if (e.Column == 0 || e.Column == 1) return;

                if (string.IsNullOrEmpty(cdvDefectCode.Text) == true)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(450));
                    MPCF.SetFocus(cdvDefectCode);
                    return;
                }

                s_column_header = spdTrayList.ActiveSheet.ColumnHeader.Columns[e.Column].Label;
                s_row_header = spdTrayList.ActiveSheet.RowHeader.Rows[e.Row].Label + s_column_header;

                if (spdTrayList.ActiveSheet.Cells[e.Row, e.Column].Text == "√")
                {
                    spdTrayList.ActiveSheet.Cells[e.Row, e.Column].Text = "";
                    spdTrayList.ActiveSheet.Cells[e.Row, e.Column].Note = null;
                    spdTrayList.ActiveSheet.Cells[e.Row, e.Column].BackColor = Color.LightGreen;

                    return;
                }

                spdTrayList.ActiveSheet.Cells[e.Row, e.Column].BackColor = Color.Red;
                spdTrayList.ActiveSheet.Cells[e.Row, e.Column].Text = "√";
                spdTrayList.ActiveSheet.Cells[e.Row, e.Column].Note = cdvDefectCode.Text;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }     
        }

        private void frmCUSTranDefectCellRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvDefectCode.Text", MPCF.Trim(cdvDefectCode.Text));
            MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvDefectCode.Tag", MPCF.Trim(cdvDefectCode.Tag));
            MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvLine.Text", MPCF.Trim(txtDefectCodeDesc.Text));

        }

    }
}
