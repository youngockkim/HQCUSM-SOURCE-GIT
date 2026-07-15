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
    public partial class frmCUSViewLotListByOper : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        #region [Property]

        #endregion



        #region [Constant Definition]

        private enum LOT_COL : int
        {
            OPER,
            LOT_ID,
            STATUS,
            OPER_IN_TIME,
            OPER_DESC_1,
            JUDGMENT_1,
            OPER_DESC_2,
            JUDGMENT_2,
            OPER_DESC_3,
            JUDGMENT_3,
            OPER_DESC_4,
            JUDGMENT_4
        }

        #endregion



        #region [Variable Definition]

        #endregion



        #region [Form Definition]

        public frmCUSViewLotListByOper()
        {
            InitializeComponent();
        }

        private void frmCUSViewLotListByOper_Load(object sender, EventArgs e)
        {
            try
            {
                dtFrDate.Value = DateTime.Today;

                cdvLine.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvLine.Text"));
                cdvLine.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvLine.Text"));

                cdvOper.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvOper.Text"));
                cdvOper.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvOper.Text"));
                txtOperDesc.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "txtOperDesc.Text"));
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void frmCUSViewLotListByOper_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvLine.Text", MPCF.Trim(cdvLine.Text));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvLine.Tag", MPCF.Trim(cdvLine.Tag));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvOper.Text", MPCF.Trim(cdvOper.Text));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvOper.Tag", MPCF.Trim(cdvOper.Tag));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "txtOperDesc.Text", MPCF.Trim(txtOperDesc.Text));
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion



        #region [Function Definition]

        private void ClearData(string ProcStep)
        {
            try
            {
                if (ProcStep == "1")
                {
                    MPCF.ClearList(spdLotList);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private bool View_Lot_List()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;

            try
            {
                spdLotList_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$OPER";
                dvcArgu[1].sCondition_Value = MPCF.Trim(cdvOper.Text);

                dvcArgu[2].sCondtion_ID = "$FROM_DATE";
                dvcArgu[2].sCondition_Value = MPCF.Trim(this.dtFrDate.GetValueAsString(8) + "080000");

                dvcArgu[3].sCondtion_ID = "$TO_DATE";
                dvcArgu[3].sCondition_Value = DateTime.Parse(dtFrDate.Value.ToString()).AddDays(1).ToString("yyyyMMdd") + "075959";

                if (TPDR.GetDataOne("", ref dt, "VIEW_LOT_LIST_BY_OPER", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdLotList_Sheet1.RowCount++;
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.OPER].Value = dt.Rows[i]["OPER"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.LOT_ID].Value = dt.Rows[i]["LOT_ID"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.STATUS].Value = dt.Rows[i]["STATUS"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.OPER_IN_TIME].Value = dt.Rows[i]["OPER_IN_TIME"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.OPER_DESC_1].Value = dt.Rows[i]["OPER_DESC_1"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.JUDGMENT_1].Value = dt.Rows[i]["JUDGMENT_1"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.OPER_DESC_2].Value = dt.Rows[i]["OPER_DESC_2"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.JUDGMENT_2].Value = dt.Rows[i]["JUDGMENT_2"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.OPER_DESC_3].Value = dt.Rows[i]["OPER_DESC_3"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.JUDGMENT_3].Value = dt.Rows[i]["JUDGMENT_3"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.OPER_DESC_4].Value = dt.Rows[i]["OPER_DESC_4"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.JUDGMENT_4].Value = dt.Rows[i]["JUDGMENT_4"].ToString();
                }

                MPCF.FitColumnHeader(spdLotList);
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        #endregion



        #region [Event Definition]

        private void cdvLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Code View Service
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(MPGC.MP_RAS_AREA_CODE));
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Line", "Line Desc" };
                cdvLine.Text = cdvLine.Show(cdvLine, "View Line", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Line");

                // Validation
                if (string.IsNullOrEmpty(cdvLine.Text) == true)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                ClearData("1");

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
                        cdvOper.Tag = cdvOper.returnDatas[0];

                        cdvOper.Tag = cdvOper.returnDatas[0];
                        cdvOper.Text = cdvOper.returnDatas[0];
                        txtOperDesc.Text = cdvOper.returnDatas[1];
                    }
                }
                else
                {
                    cdvOper.Tag = "";
                    txtOperDesc.Text = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            View_Lot_List();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (chkAutoView.Checked == true)
                {
                    View_Lot_List();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

    }
}
