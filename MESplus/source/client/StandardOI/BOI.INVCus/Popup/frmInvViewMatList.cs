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
using Infragistics.Win.UltraWinGrid;
using System.Collections;
using BOI.OIFrx;
using SOI.DNM;

namespace BOI.INVCus.Popup
{
    public partial class frmInvViewMatList : frmPopupBase
    {
        private enum INV_LOT_COL
        {
            MAT_ID = 0,
            MAT_DESC,
            UNIT_1,
            MAT_GRP_1,
            MAT_GRP_2,
            MAT_GRP_3
        }
        public string OUT_MAT_ID = "";
        public string OUT_MAT_DESC = "";
        public string OUT_MAT_UNIT_1 = "";

        public frmInvViewMatList()
        {
            InitializeComponent();
        }

        public frmInvViewMatList(string sMatID, string sMatProperty)
        {
            InitializeComponent();

            txtInvMatID.Text = sMatID;

            TRSNode in_node = new TRSNode("VIEW_DATA_IN");
            TRSNode out_node = new TRSNode("VIEW_DATA_OUT");

            ViewMatTypeGroup(sMatProperty);

            if (MPCF.Trim(sMatID) == "")
            {
            }
            else
            {
                ViewMatList();
            }
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                   

                    case "CATEGORY_2":
                        //Category 1
                        if (MPCF.Trim(cdvMatType.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvMatType.Focus();
                            return false;
                        }

                        break;

                    case "CATEGORY_3":
                        //Category 1
                        if (MPCF.Trim(cdvMatType.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvMatType.Focus();
                            return false;
                        }

                        //Category 2
                        if (MPCF.Trim(cdvMatGrp1.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            cdvMatGrp1.Focus();
                            return false;
                        }

                        break;

                   
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        //View Inventory Lot History
        private bool ViewMatList()
        {
            try
            {
                MPCF.ClearList(spdInvLot);

                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[6];
                DataTable dt = null;
                string s_column = "";

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "MAT_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(txtInvMatID.Text) + "%";

                dvcArgu[2].sCondtion_ID = "MAT_DESC";
                dvcArgu[2].sCondition_Value = "%" + MPCF.Trim(txtMatDesc.Text) + "%";

                dvcArgu[3].sCondtion_ID = "MAT_TYPE";
                dvcArgu[3].sCondition_Value = "%" + MPCF.Trim(cdvMatType.Tag) + "%";

                dvcArgu[4].sCondtion_ID = "MAT_GRP_1";
                dvcArgu[4].sCondition_Value = "%" + MPCF.Trim(cdvMatGrp1.Tag) + "%";

                dvcArgu[5].sCondtion_ID = "MAT_GRP_2";
                dvcArgu[5].sCondition_Value = "%" + MPCF.Trim(cdvMatGrp2.Tag) + "%";

                if (MPCF.Trim(cdvMatTypeGrp.Tag) == BIGC.B_MAT_TYPE_GRP_P)
                {
                    if (TPDR.GetDataOne(s_column, ref dt, "BMAT_VIEW", dvcArgu, false, false) == false)
                    {
                        if (dt != null)
                            dt.Dispose();

                        GC.Collect();
                        return false;
                    }
                }
                else if (MPCF.Trim(cdvMatTypeGrp.Tag) == BIGC.B_MAT_TYPE_GRP_M)
                {
                    if (TPDR.GetDataOne(s_column, ref dt, "BINVMAT_VIEW", dvcArgu, false, false) == false)
                    {
                        if (dt != null)
                            dt.Dispose();

                        GC.Collect();
                        return false;
                    }
                }
                if (dt.Rows.Count == 1)
                {
                    spdInvLot.Sheets[0].RowCount += 1;
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.MAT_ID].Value = dt.Rows[0][0].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.MAT_DESC].Value = dt.Rows[0][1].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.MAT_GRP_1].Value = dt.Rows[0][2].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.MAT_GRP_2].Value = dt.Rows[0][3].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.MAT_GRP_3].Value = dt.Rows[0][4].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.UNIT_1].Value = dt.Rows[0][5].ToString();

                    OUT_MAT_ID = spdInvLot.ActiveSheet.Cells[0, (int)INV_LOT_COL.MAT_ID].Text;
                    OUT_MAT_DESC = spdInvLot.ActiveSheet.Cells[0, (int)INV_LOT_COL.MAT_DESC].Text;
                    OUT_MAT_UNIT_1 = spdInvLot.ActiveSheet.Cells[0, (int)INV_LOT_COL.UNIT_1].Text;
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        spdInvLot.Sheets[0].RowCount += 1;
                        spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.MAT_ID].Value = dt.Rows[i][0].ToString();
                        spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.MAT_DESC].Value = dt.Rows[i][1].ToString();
                        spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.MAT_GRP_1].Value = dt.Rows[i][2].ToString();
                        spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.MAT_GRP_2].Value = dt.Rows[i][3].ToString();
                        spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.MAT_GRP_3].Value = dt.Rows[i][4].ToString();
                        spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.UNIT_1].Value = dt.Rows[i][5].ToString();
                    }

                    MPCF.FitColumnHeader(spdInvLot);
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        //View Inventory Lot History
        private bool ViewMatTypeGroup(string sMaterialType)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
                DataTable dt = null;
                string s_column = "";

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "MAT_TYPE_GRP";
                dvcArgu[1].sCondition_Value = MPCF.Trim(sMaterialType);

                if (TPDR.GetDataOne(s_column, ref dt, "COM0000-028", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }
                cdvMatTypeGrp.Tag = dt.Rows[0][0].ToString();
                cdvMatTypeGrp.Text = dt.Rows[0][1].ToString();

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                ViewMatList();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMatDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    ViewMatList();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdInvLot_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (spdInvLot.Sheets[0].RowCount <= 0 || e.ColumnHeader == true)
                    return;
                OUT_MAT_ID = spdInvLot.ActiveSheet.Cells[e.Row, (int)INV_LOT_COL.MAT_ID].Text;
                OUT_MAT_DESC = spdInvLot.ActiveSheet.Cells[e.Row, (int)INV_LOT_COL.MAT_DESC].Text;
                OUT_MAT_UNIT_1 = spdInvLot.ActiveSheet.Cells[e.Row, (int)INV_LOT_COL.UNIT_1].Text;
                this.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvMatType_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                cdvMatGrp1.Tag = "";
                cdvMatGrp1.Text = "";

                cdvMatGrp2.Tag = "";
                cdvMatGrp2.Text = "";

                txtInvMatID.Tag = "";
                txtInvMatID.Text = "";

                txtMatDesc.Tag = "";
                txtMatDesc.Text = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvMatGrp1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                cdvMatGrp2.Tag = "";
                cdvMatGrp2.Text = "";

                txtInvMatID.Tag = "";
                txtInvMatID.Text = "";

                txtMatDesc.Tag = "";
                txtMatDesc.Text = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvMatGrp2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtInvMatID.Tag = "";
                txtInvMatID.Text = "";

                txtMatDesc.Tag = "";
                txtMatDesc.Text = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvMatType_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_DATA_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.MP_GCM_MATERIAL_TYPE));
                in_node.AddString("DATA_4", MPCF.Trim(cdvMatTypeGrp.Tag));

                // CodeView Column Header Setup
                string[] header = new string[] { "Category 1", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvMatType.Text = cdvMatType.Show(cdvMatType, "Category 1", "BCOM", "BCOM_View_Gcm_Data_List", in_node, "GCM_DATA_LIST", display, header, "DATA_1");

                if (MPCF.Trim(cdvMatType.Text) != "")
                {
                    if (cdvMatType.returnDatas.Count > 0)
                    {
                        cdvMatType.Tag = cdvMatType.returnDatas[0];
                        cdvMatType.Text = cdvMatType.returnDatas[1];
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvMatGrp1_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("CATEGORY_2") == false)
                {
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_DATA_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.MP_GCM_MATERIAL_GRP_1));
                in_node.AddString("DATA_3", cdvMatType.Tag.ToString());

                // CodeView Column Header Setup
                string[] header = new string[] { "Category 2", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvMatGrp1.Text = cdvMatGrp1.Show(cdvMatGrp1, "Category 2", "BCOM", "BCOM_View_Gcm_Data_List", in_node, "GCM_DATA_LIST", display, header, "DATA_1");

                if (MPCF.Trim(cdvMatGrp1.Text) != "")
                {
                    if (cdvMatGrp1.returnDatas.Count > 0)
                    {
                        cdvMatGrp1.Tag = cdvMatGrp1.returnDatas[0];
                        cdvMatGrp1.Text = cdvMatGrp1.returnDatas[1];
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvMatGrp2_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("CATEGORY_3") == false)
                {
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_DATA_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.MP_GCM_MATERIAL_GRP_2));
                in_node.AddString("DATA_3", cdvMatGrp1.Tag.ToString());

                // CodeView Column Header Setup
                string[] header = new string[] { "Category 3", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvMatGrp2.Text = cdvMatGrp2.Show(cdvMatGrp2, "Category 3", "BCOM", "BCOM_View_Gcm_Data_List", in_node, "GCM_DATA_LIST", display, header, "DATA_1");

                if (MPCF.Trim(cdvMatGrp2.Text) != "")
                {
                    if (cdvMatGrp2.returnDatas.Count > 0)
                    {
                        cdvMatGrp2.Tag = cdvMatGrp2.returnDatas[0];
                        cdvMatGrp2.Text = cdvMatGrp2.returnDatas[1];
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void txtInvMatID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    ViewMatList();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvMatTypeGrp_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_DATA_IN");
                TRSNode out_node = new TRSNode("VIEW_DATA_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_MAT_TYPE_GRP));

                // CodeView Column Header Setup
                string[] header = new string[] { "Category 1", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvMatTypeGrp.Text = cdvMatTypeGrp.Show(cdvMatTypeGrp, "Category 1", "BCOM", "BCOM_View_Gcm_Data_List", in_node, "GCM_DATA_LIST", display, header, "DATA_1");

                if (MPCF.Trim(cdvMatTypeGrp.Text) != "")
                {
                    if (cdvMatTypeGrp.returnDatas.Count > 0)
                    {
                        cdvMatTypeGrp.Tag = cdvMatTypeGrp.returnDatas[0];
                        cdvMatTypeGrp.Text = cdvMatTypeGrp.returnDatas[1];
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
