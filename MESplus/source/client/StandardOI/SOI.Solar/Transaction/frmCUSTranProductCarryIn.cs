using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using SOI.DNM;

namespace SOI.Solar
{
    public partial class frmCUSTranProductCarryIn : SOIBaseForm03
    {
        #region [Property]

        private bool bIsShown = false;

        const int ENTER = 13;

        const string CARRY_IN_ID = "Carry In ID";
        const string MES_LOT_ID = "MES Lot ID";
        const string SHIP_LOT_ID = "SHIP Lot ID";
        const string SHIP_ID = "SHIP ID";
        const string ORDER_DATE = "Order Date";
        const string ORDER_ID = "Order ID";
        const string APP_NUM = "App Num";
        const string ORDER_SEQ = "Order Seq";
        const string CONTRACT_NO = "Contract No";
        const string MAT_ID = "Mat ID";
        const string CUSTOMER_ID = "Customer ID";

        #endregion

        public frmCUSTranProductCarryIn()
        {
            InitializeComponent();
        }
        
        #region [Constant Definition]

        private enum PALLET_SHIP_LIST
        {
            CHK,
            CARRY_IN_ID,
            MES_LOT_ID,
            SHIP_LOT_ID,
            SHIP_ID,
            ORDER_DATE,
            ORDER_ID,
            APP_NUM,
            ORDER_SEQ,
            CONTRACT_NO,
            MAT_ID,
            CUSTOMER_ID
        }

        private enum FG_SHIP_LIST
        {
            CHK,
            MES_LOT_ID,
            SHIP_LOT_ID,
            SHIP_ID,
            ORDER_DATE,
            ORDER_ID,
            APP_NUM,
            ORDER_SEQ,
            CONTRACT_NO,
            MAT_ID,
            CUSTOMER_ID
        }

        #endregion

        #region [Variable Definition]

        #endregion

        #region [FormDefinition]

        private void initCtrl()
        {
            try
            {
                MPCF.ConvertCaption(this);
                MPCF.FieldClear(this);
                SetPalletSpread();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        #endregion

        #region [Function Definition]

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case CSGC.MP_CHECK_VIEW:

                        for (int j = 0; j < spdCarryList.ActiveSheet.RowCount; j++)
                        {
                            if (rdbPallet.Checked)
                            {
                                if (txtCarryInID.Text.Equals(spdCarryList.ActiveSheet.Cells[j, (int)PALLET_SHIP_LIST.CARRY_IN_ID].Value))
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(390));
                                    return false;
                                }
                            }
                            else if (rdbFG.Checked)
                            {
                                if (txtCarryInID.Text.Equals(spdCarryList.ActiveSheet.Cells[j, (int)FG_SHIP_LIST.SHIP_LOT_ID].Value))
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(164));
                                    return false;
                                }
                            }
                        }

                        break;

                    case CSGC.MP_CHECK_CREATE:

                        break;

                    case CSGC.MP_CHECK_UPDATE:
                    case CSGC.MP_CHECK_DELETE:

                        if (spdCarryList.ActiveSheet.RowCount == 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(122));
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

        private bool SaveProductCarryIn()
        {
            TRSNode in_node = new TRSNode("CUS_UPDATE_CARRY_INFO_IN");
            TRSNode out_node = new TRSNode("CUS_UPDATE_CARRY_INFO_OUT");
            TRSNode list_item;

            try
            {
                DialogResult dr = MPCF.ShowMsgBox(MPCF.GetMessage(400), MessageBoxButtons.OKCancel, SOI.CliFrx.MSG_LEVEL.WARNING);
                if (dr != System.Windows.Forms.DialogResult.OK) return false;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_CREATE;
                in_node.AddString("CARRY_IN_DESC", MPCF.Trim(txtCarryInDesc.Text));

                for (int i = 0; i < spdCarryList.ActiveSheet.RowCount; i++)
                {
                    list_item = in_node.AddNode("LOT_LIST");

                    if (rdbPallet.Checked)
                    {
                        list_item.AddString("BOX_ID", MPCF.Trim(spdCarryList.ActiveSheet.Cells[i, (int)PALLET_SHIP_LIST.CARRY_IN_ID].Value));
                        list_item.AddString("LOT_ID", MPCF.Trim(spdCarryList.ActiveSheet.Cells[i, (int)PALLET_SHIP_LIST.MES_LOT_ID].Value));
                        list_item.AddString("SHIP_ID", MPCF.Trim(spdCarryList.ActiveSheet.Cells[i, (int)PALLET_SHIP_LIST.SHIP_ID].Value));
                        list_item.AddString("ORDER_DATE", MPCF.Trim(spdCarryList.ActiveSheet.Cells[i, (int)PALLET_SHIP_LIST.ORDER_DATE].Value));
                        list_item.AddString("ORDER_ID", MPCF.Trim(spdCarryList.ActiveSheet.Cells[i, (int)PALLET_SHIP_LIST.ORDER_ID].Value));
                        list_item.AddInt("APP_NUM", MPCF.Trim(spdCarryList.ActiveSheet.Cells[i, (int)PALLET_SHIP_LIST.APP_NUM].Value));
                        list_item.AddInt("ORDER_SEQ", MPCF.Trim(spdCarryList.ActiveSheet.Cells[i, (int)PALLET_SHIP_LIST.ORDER_SEQ].Value));
                        list_item.AddString("CONTRACT_NO", MPCF.Trim(spdCarryList.ActiveSheet.Cells[i, (int)PALLET_SHIP_LIST.CONTRACT_NO].Value));
                        list_item.AddString("MAT_ID", MPCF.Trim(spdCarryList.ActiveSheet.Cells[i, (int)PALLET_SHIP_LIST.MAT_ID].Value));
                        list_item.AddString("CUSTOMER_ID", MPCF.Trim(spdCarryList.ActiveSheet.Cells[i, (int)PALLET_SHIP_LIST.CUSTOMER_ID].Value));
                    }
                    else if (rdbFG.Checked)
                    {
                        list_item.AddString("LOT_ID", MPCF.Trim(spdCarryList.ActiveSheet.Cells[i, (int)FG_SHIP_LIST.MES_LOT_ID].Value));
                        list_item.AddString("SHIP_ID", MPCF.Trim(spdCarryList.ActiveSheet.Cells[i, (int)FG_SHIP_LIST.SHIP_ID].Value));
                        list_item.AddString("ORDER_DATE", MPCF.Trim(spdCarryList.ActiveSheet.Cells[i, (int)FG_SHIP_LIST.ORDER_DATE].Value));
                        list_item.AddString("ORDER_ID", MPCF.Trim(spdCarryList.ActiveSheet.Cells[i, (int)FG_SHIP_LIST.ORDER_ID].Value));
                        list_item.AddInt("APP_NUM", MPCF.Trim(spdCarryList.ActiveSheet.Cells[i, (int)FG_SHIP_LIST.APP_NUM].Value));
                        list_item.AddInt("ORDER_SEQ", MPCF.Trim(spdCarryList.ActiveSheet.Cells[i, (int)FG_SHIP_LIST.ORDER_SEQ].Value));
                        list_item.AddString("CONTRACT_NO", MPCF.Trim(spdCarryList.ActiveSheet.Cells[i, (int)FG_SHIP_LIST.CONTRACT_NO].Value));
                        list_item.AddString("MAT_ID", MPCF.Trim(spdCarryList.ActiveSheet.Cells[i, (int)FG_SHIP_LIST.MAT_ID].Value));
                        list_item.AddString("CUSTOMER_ID", MPCF.Trim(spdCarryList.ActiveSheet.Cells[i, (int)FG_SHIP_LIST.CUSTOMER_ID].Value));
                    }

                    list_item.AddString("RGPM_DATE", DateTime.Now.ToString("yyyyMMdd"));
                }

                if (MPCF.CallService("CUS", "CSHP_Update_Return_Carry_In", in_node, ref out_node) == false)
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

        private void SetPalletSpread()
        {
            MPCF.ClearList(this.spdCarryList);

            spdCarryList.ActiveSheet.ColumnCount = 12;
            spdCarryList.ActiveSheet.ColumnHeader.Columns[1].Label = CARRY_IN_ID;
            spdCarryList.ActiveSheet.ColumnHeader.Columns[2].Label = MES_LOT_ID;
            spdCarryList.ActiveSheet.ColumnHeader.Columns[3].Label = SHIP_LOT_ID;
            spdCarryList.ActiveSheet.ColumnHeader.Columns[4].Label = SHIP_ID;
            spdCarryList.ActiveSheet.ColumnHeader.Columns[5].Label = ORDER_DATE;
            spdCarryList.ActiveSheet.ColumnHeader.Columns[6].Label = ORDER_ID;
            spdCarryList.ActiveSheet.ColumnHeader.Columns[7].Label = APP_NUM;
            spdCarryList.ActiveSheet.ColumnHeader.Columns[8].Label = ORDER_SEQ;
            spdCarryList.ActiveSheet.ColumnHeader.Columns[9].Label = CONTRACT_NO;
            spdCarryList.ActiveSheet.ColumnHeader.Columns[10].Label = MAT_ID;
            spdCarryList.ActiveSheet.ColumnHeader.Columns[11].Label = CUSTOMER_ID;

            SetPalletVisible();

            MPCF.ConvertCaption(spdCarryList);
        }

        private void SetFGSpread()
        {
            MPCF.ClearList(this.spdCarryList);

            spdCarryList.ActiveSheet.ColumnCount = 11;
            spdCarryList.ActiveSheet.ColumnHeader.Columns[1].Label = MES_LOT_ID;
            spdCarryList.ActiveSheet.ColumnHeader.Columns[2].Label = SHIP_LOT_ID;
            spdCarryList.ActiveSheet.ColumnHeader.Columns[3].Label = SHIP_ID;
            spdCarryList.ActiveSheet.ColumnHeader.Columns[4].Label = ORDER_DATE;
            spdCarryList.ActiveSheet.ColumnHeader.Columns[5].Label = ORDER_ID;
            spdCarryList.ActiveSheet.ColumnHeader.Columns[6].Label = APP_NUM;
            spdCarryList.ActiveSheet.ColumnHeader.Columns[7].Label = ORDER_SEQ;
            spdCarryList.ActiveSheet.ColumnHeader.Columns[8].Label = CONTRACT_NO;
            spdCarryList.ActiveSheet.ColumnHeader.Columns[9].Label = MAT_ID;
            spdCarryList.ActiveSheet.ColumnHeader.Columns[10].Label = CUSTOMER_ID;

            SetFGVisible();

            MPCF.ConvertCaption(spdCarryList);
        }

        private void SetPalletVisible()
        {
            spdCarryList.ActiveSheet.Columns[(int)PALLET_SHIP_LIST.SHIP_LOT_ID].Visible = true;
            spdCarryList.ActiveSheet.Columns[(int)PALLET_SHIP_LIST.SHIP_ID].Visible = false;
            spdCarryList.ActiveSheet.Columns[(int)PALLET_SHIP_LIST.ORDER_DATE].Visible = false;
            spdCarryList.ActiveSheet.Columns[(int)PALLET_SHIP_LIST.ORDER_ID].Visible = false;
            spdCarryList.ActiveSheet.Columns[(int)PALLET_SHIP_LIST.APP_NUM].Visible = false;
            spdCarryList.ActiveSheet.Columns[(int)PALLET_SHIP_LIST.ORDER_SEQ].Visible = false;
            spdCarryList.ActiveSheet.Columns[(int)PALLET_SHIP_LIST.CONTRACT_NO].Visible = false;
            spdCarryList.ActiveSheet.Columns[(int)PALLET_SHIP_LIST.MAT_ID].Visible = false;
            spdCarryList.ActiveSheet.Columns[(int)PALLET_SHIP_LIST.CUSTOMER_ID].Visible = false;
        }

        private void SetFGVisible()
        {
            spdCarryList.ActiveSheet.Columns[(int)FG_SHIP_LIST.SHIP_ID].Visible = false;
            spdCarryList.ActiveSheet.Columns[(int)FG_SHIP_LIST.ORDER_DATE].Visible = false;
            spdCarryList.ActiveSheet.Columns[(int)FG_SHIP_LIST.ORDER_ID].Visible = false;
            spdCarryList.ActiveSheet.Columns[(int)FG_SHIP_LIST.APP_NUM].Visible = false;
            spdCarryList.ActiveSheet.Columns[(int)FG_SHIP_LIST.ORDER_SEQ].Visible = false;
            spdCarryList.ActiveSheet.Columns[(int)FG_SHIP_LIST.CONTRACT_NO].Visible = false;
            spdCarryList.ActiveSheet.Columns[(int)FG_SHIP_LIST.MAT_ID].Visible = false;
            spdCarryList.ActiveSheet.Columns[(int)FG_SHIP_LIST.CUSTOMER_ID].Visible = false;
        }

        private bool AddPalletList()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            try
            {
                if (rdbPallet.Checked)
                    sViewID = "VIEW_CARRY_IN_PALLET";
                else if (rdbFG.Checked)
                    sViewID = "VIEW_CARRY_IN_FG";

                i_cond_cnt = 1;
                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];

                ArrDVC[0].sCondtion_ID = "$INPUT";
                ArrDVC[0].sCondition_Value = txtCarryInID.Text;

                if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(154));

                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                foreach (DataRow dr in dt.Rows)
                {
                    spdCarryList.ActiveSheet.RowCount++;

                    if (rdbPallet.Checked)
                    {
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)PALLET_SHIP_LIST.CHK].Value = false;
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)PALLET_SHIP_LIST.CARRY_IN_ID].Value = dr["BOX_ID"];
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)PALLET_SHIP_LIST.MES_LOT_ID].Value = dr["MES_LOT_ID"];
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)PALLET_SHIP_LIST.SHIP_LOT_ID].Value = dr["SHIP_LOT_ID"];
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)PALLET_SHIP_LIST.SHIP_ID].Value = dr["SHIP_ID"];
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)PALLET_SHIP_LIST.ORDER_DATE].Value = dr["ORDER_DATE"];
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)PALLET_SHIP_LIST.ORDER_ID].Value = dr["ORDER_ID"];
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)PALLET_SHIP_LIST.APP_NUM].Value = dr["APP_NUM"];
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)PALLET_SHIP_LIST.ORDER_SEQ].Value = dr["ORDER_SEQ"];
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)PALLET_SHIP_LIST.CONTRACT_NO].Value = dr["CONTRACT_NO"];
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)PALLET_SHIP_LIST.MAT_ID].Value = dr["MAT_ID"];
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)PALLET_SHIP_LIST.CUSTOMER_ID].Value = dr["CUSTOMER_ID"];

                        SetPalletVisible();
                    }
                    else if (rdbFG.Checked)
                    {
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)FG_SHIP_LIST.CHK].Value = false;
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)FG_SHIP_LIST.MES_LOT_ID].Value = dr["MES_LOT_ID"];
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)FG_SHIP_LIST.SHIP_LOT_ID].Value = dr["SHIP_LOT_ID"];
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)FG_SHIP_LIST.SHIP_ID].Value = dr["SHIP_ID"];
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)FG_SHIP_LIST.ORDER_DATE].Value = dr["ORDER_DATE"];
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)FG_SHIP_LIST.ORDER_ID].Value = dr["ORDER_ID"];
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)FG_SHIP_LIST.APP_NUM].Value = dr["APP_NUM"];
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)FG_SHIP_LIST.ORDER_SEQ].Value = dr["ORDER_SEQ"];
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)FG_SHIP_LIST.CONTRACT_NO].Value = dr["CONTRACT_NO"];
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)FG_SHIP_LIST.MAT_ID].Value = dr["MAT_ID"];
                        spdCarryList.ActiveSheet.Cells[spdCarryList.ActiveSheet.RowCount - 1, (int)FG_SHIP_LIST.CUSTOMER_ID].Value = dr["CUSTOMER_ID"];

                        SetFGVisible();
                    }
                }

                MPCF.FitColumnHeader(spdCarryList);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void DeletePallet()
        {
            try
            {
                for (int i = spdCarryList.ActiveSheet.RowCount - 1; i >= 0; i--)
                {
                    if (Convert.ToBoolean(spdCarryList.ActiveSheet.Cells[i, (int)PALLET_SHIP_LIST.CHK].Value))
                    {
                        spdCarryList_Sheet1.RemoveRows(i, 1);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        #endregion

        #region [Event Definition]

        private void frmCUSTranProductCarryIn_Load(object sender, EventArgs e)
        {
            initCtrl();
        }

        private void frmCUSTranProductCarryIn_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                bIsShown = true;

                MPCF.SetFocus(txtCarryInID);
            }
        }

        private void txtCarryInID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER)
            {
                txtCarryInID.Text = MPCF.ToUpper(txtCarryInID.Text); // 일괄 대문자

                if (CheckCondition(CSGC.MP_CHECK_VIEW))
                {
                    AddPalletList();
                }

                txtCarryInID.Text = string.Empty;
                MPCF.SetFocus(txtCarryInID);
            }
        }

        private void rdbButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPallet.Checked)
                SetPalletSpread();
            else if (rdbFG.Checked)
                SetFGSpread();

            MPCF.FieldClear(txtCarryInDesc);
            MPCF.SetFocus(txtCarryInID);
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (!CheckCondition(CSGC.MP_CHECK_UPDATE)) 
            {
                MPCF.SetFocus(txtCarryInID);
                return; 
            }

            if (!SaveProductCarryIn())
            {
                MPCF.SetFocus(txtCarryInID);
                return;
            }
            
            rdbButton_CheckedChanged(null, null);
        }

        private void spdCarryList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader == true && e.Column == (int)PALLET_SHIP_LIST.CHK)
            {
                if (spdCarryList.ActiveSheet.RowCount < 1) return;

                bool allChecked = (spdCarryList.Tag == null || spdCarryList.Tag.ToString() == "0") ? false : true;

                if (allChecked == true) spdCarryList.Tag = "0";
                else spdCarryList.Tag = "1";

                for (int r = 0; r < spdCarryList.ActiveSheet.RowCount; r++)
                    spdCarryList.ActiveSheet.Cells[r, e.Column].Value = allChecked;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!CheckCondition(CSGC.MP_CHECK_DELETE)) 
            {
                MPCF.SetFocus(txtCarryInID);
                return; 
            }

            DeletePallet();
            MPCF.SetFocus(txtCarryInID);
        }

        #endregion        
    } 
}
