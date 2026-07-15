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
using Miracom.CliFrx;
using Miracom.MESCore;
using Custom.Common;

namespace Custom.HanwhaQcell.USModule
{
    public partial class frmCINVInputRawMaterial : SOIBaseForm02
    {
        public frmCINVInputRawMaterial()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private enum COL_DATA : int
        {
            COL_MAT_ID,
            COL_MAT_DESC,
            COL_RAW_MAT_NAME,
            COL_SUM_QTY,
            COL_UNIT
        }

        private enum COL_BIN_MAT : int
        {
            COL_MAT_ID,
            COL_MAT_DESC,
            COL_RAW_MAT_NAME
        }

        //private const string CLEAR_ALL = "ALL";
        private const string CLEAR_LABEL_INIT = "CLEAR_LABEL_INIT";

        #endregion

        #region " Variable Definition "
        
        #endregion

        #region " Constant Definition "
        
        #endregion
        
        #region "Event Definition"



        private void frmCINVInputRawMaterial_Load(object sender, EventArgs e)
        {
            try
            {
                MPOF.ConvertCaption(this);

                //Added by hans(2017-04-28) 
                //Plant, Shop, Line 설정
                cdvMatType.Text = MPGV.gsMatType;
                cdvMatType.Description = MPGV.gsMatTypeDesc;
                //cdvShop.Description = MOGV.gsAreaDesc;

                cdvResID.Text = MPCF.GetRegSetting(Application.ProductName, "MainOrder", "Oper");
                txtResID.Text = MPCF.GetRegSetting(Application.ProductName, "MainOrder", "OperDesc");

                cdvResID.ReadOnly = false;



                //string sWorkDate = ICCF.GetWorkDate();
                //dtpFrom.Value = new System.DateTime(MPCF.ToInt(sWorkDate.Substring(0, 4)), MPCF.ToInt(sWorkDate.Substring(4, 2)), MPCF.ToInt(sWorkDate.Substring(6, 2)), 0, 0, 0, 0);
                //dtpTo.Value = new System.DateTime(MPCF.ToInt(sWorkDate.Substring(0, 4)), MPCF.ToInt(sWorkDate.Substring(4, 2)), MPCF.ToInt(sWorkDate.Substring(6, 2)), 0, 0, 0, 0);

                DisplayMessage("", MSSAG_LEVEL.INFO);


                //iWorkGroup = MPCF.ToInt(ICCF.GetLineWorkGroup(cdvShop.Text, cdvLine.Text));

                //if (iWorkGroup == 2)
                //{
                //    spdWorkMatList.Visible = false;
                //    spdWorkMatList.Height = 0;
                //    soiSplitContainer2.SplitterDistance = 2000;
                //}

                //btnView.PerformClick();
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
                return;
            }
        }

        private void cdvMatType_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "KEY_1", "DATA_1" };

                // Show CodeView and Get Return
                cdvMatType.Text = cdvMatType.Show(cdvMatType, "Code List", "CMN_View_GCM_Data_1", new string[] { "MATERIAL_GRP_1" }, display, header, "KEY_1");
                cdvResID.Text = "";
                txtResID.Text = "";
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
                return;
            }
        }

        #endregion

        #region "Function Definition"



        private bool CheckCondition(string FuncName)
        {
            DisplayMessage("", MSSAG_LEVEL.INFO);

            switch (MPCF.Trim(FuncName))
            {

                case "VIEW_OPER":

                    if (string.IsNullOrEmpty(cdvResID.Text) == true)
                    {
                        cdvResID.Focus();
                        DisplayMessage(MPCF.GetMessage(107), MSSAG_LEVEL.ERROR);
                        return false;
                    }

                    break;

                case "VIEW_LOT":

                    if (string.IsNullOrEmpty(txtLotID.Text) == true)
                    {
                        txtLotID.Focus();
                        DisplayMessage(MPCF.GetMessage(107), MSSAG_LEVEL.ERROR);
                        return false;
                    }

                    break;

                case "SAVE":

                    if (string.IsNullOrEmpty(cdvMatType.Text) == true)
                    {
                        cdvMatType.Focus();
                        DisplayMessage(MPCF.GetMessage(107), MSSAG_LEVEL.ERROR);
                        return false;
                    }

                    if (string.IsNullOrEmpty(cdvResID.Text) == true)
                    {
                        cdvResID.Focus();
                        DisplayMessage(MPCF.GetMessage(107), MSSAG_LEVEL.ERROR);
                        return false;
                    }

                    if (string.IsNullOrEmpty(txtLotID_2.Text) == true)
                    {
                        txtLotID_2.Focus();
                        DisplayMessage(MPCF.GetMessage(107), MSSAG_LEVEL.ERROR);
                        return false;
                    }

                    if (txtIQCResult.Text == "N")
                    {
                        txtIQCResult.Focus();
                        DisplayMessage(MPCF.GetMessage(465), MSSAG_LEVEL.ERROR);
                        return false;
                    }

                    if (MPCF.ToInt(MPCF.Trim(txtShelfLife.Tag.ToString())) > 0)
                    {
                        txtShelfLife.Focus();
                        DisplayMessage(MPCF.GetMessage(466), MSSAG_LEVEL.ERROR);
                        return false;
                    }

                    break;

                case "DISAVE":

                    if (string.IsNullOrEmpty(cdvMatType.Text) == true)
                    {
                        cdvMatType.Focus();
                        DisplayMessage(MPCF.GetMessage(107), MSSAG_LEVEL.ERROR);
                        return false;
                    }

                    if (string.IsNullOrEmpty(cdvResID.Text) == true)
                    {
                        cdvResID.Focus();
                        DisplayMessage(MPCF.GetMessage(107), MSSAG_LEVEL.ERROR);
                        return false;
                    }

                    if (string.IsNullOrEmpty(txtLotID_2.Text) == true)
                    {
                        txtLotID_2.Focus();
                        DisplayMessage(MPCF.GetMessage(107), MSSAG_LEVEL.ERROR);
                        return false;
                    }


                    break;


            }

            return true;
        }


        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2", "3")
        //

        private void ClearData(string ProcStep)
        {

            try
            {

                if (ProcStep == "1")
                {

                    cdvFactory.Text = "";
                    cdvFactory.Description = "";
                    cdvMatID.Text = "";
                    cdvMatID.Description = "";
                    txtQty.Text = "";
                    txtUnit.Text = "";
                    txtLotID_2.Text = "";

                    cdvLotOper.Text = "";
                    cdvLotOper.Description = "";

                    txtShelfLife.Text = "";
                    txtShelfLife.Tag = "";
                    txtShelfLife.Appearance.ForeColor = Color.Black;
                    txtIQCResult.Text = "";

                    for (int i = 0; i < spdResStockList.ActiveSheet.RowCount; i++)
                    {
                        spdResStockList.ActiveSheet.Rows[i].BackColor = SystemColors.Control;
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
            }

        }
        
        
        // View_Res_Stock_List()
        //       투입설비 재고 조회
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String
        //
        private bool View_Res_Stock_List()
        {

            DataTable dt = null;
            FarPoint.Win.Spread.SheetView with_1 = new FarPoint.Win.Spread.SheetView();
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

            string s_column = "";
            try
            {
                //MPCF.ClearList(spdRel);
                spdResStockList.ActiveSheet.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "OPER";
                dvcArgu[1].sCondition_Value = MPCF.Trim(cdvResID.Text);


                if (TPDR.GetDataOne(s_column, ref dt, "INV5012-01", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();


                    return false;
                }
                if (dt == null || dt.Rows.Count < 1) return false;

                with_1 = spdResStockList.ActiveSheet;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int LastRow;

                    with_1.RowCount++;
                    LastRow = with_1.RowCount - 1;

                    with_1.SetValue(LastRow, (int)COL_DATA.COL_MAT_ID, MPCF.Trim(dt.Rows[i]["MAT_ID"].ToString()));


                    with_1.SetValue(LastRow, (int)COL_DATA.COL_MAT_DESC, MPCF.Trim(dt.Rows[i]["MAT_DESC"].ToString()));
                    with_1.SetValue(LastRow, (int)COL_DATA.COL_RAW_MAT_NAME, MPCF.Trim(dt.Rows[i]["RAW_MAT_NAME"].ToString()));
                    with_1.SetValue(LastRow, (int)COL_DATA.COL_SUM_QTY, MPCF.Trim(dt.Rows[i]["SUM_QTY"].ToString()));
                    with_1.SetValue(LastRow, (int)COL_DATA.COL_UNIT, MPCF.Trim(dt.Rows[i]["UNIT_1"].ToString()));

                }

                for (int k = 0; k < spdResStockList.ActiveSheet.RowCount; k++)
                {
                    if (spdResStockList.ActiveSheet.Cells[k, (int)COL_DATA.COL_MAT_ID].Text == MPCF.Trim(cdvMatID.Text))
                    {
                        spdResStockList.ActiveSheet.Rows[k].BackColor = Color.Salmon;
                    }
                }

                MPCF.FitColumnHeader(spdResStockList);

                return true;
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
                return false;
            }
        }

        // View_Res_Stock_List()
        //       투입설비 재고 조회
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String
        //
        private bool View_Lot()
        {

            DataTable dt = null;
            FarPoint.Win.Spread.SheetView with_1 = new FarPoint.Win.Spread.SheetView();
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

            string s_column = "";
            try
            {
                //MPCF.ClearList(spdRel);
                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "LOT_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(txtLotID.Text);


                if (TPDR.GetDataOne(s_column, ref dt, "INV5012-02", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();


                    return false;
                }
                if (dt == null || dt.Rows.Count < 1) return false;

                cdvFactory.Text = MPCF.Trim(dt.Rows[0]["FACTORY"].ToString());
                cdvFactory.Description = MPCF.Trim(dt.Rows[0]["FAC_DESC"].ToString());
                cdvMatID.Text = MPCF.Trim(dt.Rows[0]["MAT_ID"].ToString());

                for (int i = 0; i < spdResStockList.ActiveSheet.RowCount; i++)
                {
                    if (spdResStockList.ActiveSheet.Cells[i, (int)COL_DATA.COL_MAT_ID].Text == MPCF.Trim(cdvMatID.Text))
                    {
                        spdResStockList.ActiveSheet.Rows[i].BackColor = Color.Salmon;
                    }
                }
                cdvMatID.Description = MPCF.Trim(dt.Rows[0]["MAT_DESC"].ToString());
                txtQty.Text = MPCF.Trim(dt.Rows[0]["INV_QTY"].ToString());
                txtUnit.Text = MPCF.Trim(dt.Rows[0]["UNIT_1"].ToString());
                txtLotID_2.Text = MPCF.Trim(dt.Rows[0]["LOT_ID"].ToString());

                cdvLotOper.Text = MPCF.Trim(dt.Rows[0]["OPER"].ToString());
                cdvLotOper.Description = MPCF.Trim(dt.Rows[0]["OPER_DESC"].ToString());

                txtIQCResult.Text = MPCF.Trim(dt.Rows[0]["IQC_YN"].ToString());
                txtShelfLife.Text = MPCF.Trim(dt.Rows[0]["UNTIL_DATE"].ToString());
                txtShelfLife.Tag = MPCF.Trim(dt.Rows[0]["DATE_DIFF"].ToString());

                if (MPCF.ToDbl(MPCF.Trim(dt.Rows[0]["DATE_DIFF"].ToString())) > 0)
                {
                    txtShelfLife.Appearance.ForeColor = Color.Salmon;
                }


                return true;
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
                return false;
            }
        }

        private bool View_Insp_Bin_Mat_List()
        {

            DataTable dt = null;
            FarPoint.Win.Spread.SheetView with_1 = new FarPoint.Win.Spread.SheetView();
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];

            string s_column = "";
            try
            {
                //MPCF.ClearList(spdRel);

                spdBINMat.ActiveSheet.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;


                dvcArgu[1].sCondtion_ID = "BIN_NO";
                dvcArgu[1].sCondition_Value = MPCF.Trim(cdvResID.Text);


                dvcArgu[2].sCondtion_ID = "MAT_TYPE";
                dvcArgu[2].sCondition_Value = MPCF.Trim(cdvMatType.Text);


                if (TPDR.GetDataOne(s_column, ref dt, "INV5001-02", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();


                    return false;
                }
                if (dt == null || dt.Rows.Count < 1) return false;

                with_1 = spdBINMat.ActiveSheet;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int LastRow;

                    with_1.RowCount++;
                    LastRow = with_1.RowCount - 1;

                    with_1.SetValue(LastRow, (int)COL_BIN_MAT.COL_MAT_ID, MPCF.Trim(dt.Rows[i]["MAT_ID"].ToString()));
                    with_1.SetValue(LastRow, (int)COL_BIN_MAT.COL_MAT_DESC, MPCF.Trim(dt.Rows[i]["MAT_DESC"].ToString()));
                    with_1.SetValue(LastRow, (int)COL_BIN_MAT.COL_RAW_MAT_NAME, MPCF.Trim(dt.Rows[i]["RAW_MAT"].ToString()));
                }


                MPCF.FitColumnHeader(spdBINMat);

                return true;
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
                return false;
            }
        }

        /// <summary>
        /// 트랜젝션
        /// </summary>
        /// <param name="ProcStep"></param>
        /// <returns></returns>
        private bool Input_Raw_Material(char ProcStep)
        {

            TRSNode in_node = new TRSNode("Update_Tran_Input_Raw_Material_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.Factory = MPGV.gsFactory;
                in_node.AddString("MAT_TYPE", MPCF.Trim(cdvMatType.Text));
                in_node.AddString("LABEL_ID", MPCF.Trim(txtLotID_2.Text));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMatID.Text));
                in_node.AddDouble("LOAD_QTY", MPCF.ToDbl(MPCF.Trim(txtQty.Text)));
                in_node.AddString("LOAD_OPER", MPCF.Trim(cdvResID.Text));

                if (MPCR.CallService("CINV", "CINV_Tran_Input_Raw_Material", in_node, ref out_node, true) == false)
                {

                    DisplayMessage(out_node.Msg, MSSAG_LEVEL.ERROR);

                    return false;
                }

                DisplayMessage(out_node.Msg, MSSAG_LEVEL.SUCCESS);

            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
                return false;
            }

            return true;

        }

        #endregion

        private void cdvOper_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {

                    DataTable dtTable_2 = HQCF.MGetData("BAS_View_Oper_List_3", new string[] { MPCF.Trim(cdvMatType.Text), MPCF.Trim(cdvResID.Text) });

                    if (dtTable_2.Rows.Count > 0)
                    {
                        cdvResID.Text = dtTable_2.Rows[0][0].ToString();
                        txtResID.Text = dtTable_2.Rows[0][1].ToString();
                    }
                    else
                    {
                        cdvResID.Text = "";
                        txtResID.Text = "";
                        cdvResID.Focus();
                        cdvResID.SelectAll();
                    }

                    if (CheckCondition("VIEW_OPER") == true)
                    {

                        View_Insp_Bin_Mat_List();
                        if (View_Res_Stock_List() == false)
                        {
                            cdvResID.Focus();
                            cdvResID.SelectAll();
                        }
                        else
                        {
                            txtLotID.Focus();
                            txtLotID.SelectAll();
                        }
                    }
                    else
                    {
                        cdvResID.Focus();
                        cdvResID.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(MPCF.GetMessage(107), MSSAG_LEVEL.ERROR);
            }
        }

        private void cdvResID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {

                string[] display = new string[] { "OPER", "OPER_DESC" , "RAW_MAT_NAME" };
                string[] header = new string[] { "OPER", "OPER_DESC", "RAW_MAT_NAME" };


                //Show CodeView and Get Return
                cdvResID.Text = cdvResID.Show(cdvResID, "OPER", "BAS_View_Oper_List_12", new string[] { MPCF.Trim(cdvMatType.Text), rbResType.Value.ToString()}, display, header, "OPER");

                txtResID.Text = cdvResID.returnDatas[1];

                if (MPCF.Trim(cdvResID.Text) != "")
                {

                    View_Insp_Bin_Mat_List();
                    if (View_Res_Stock_List() == false)
                    {
                        cdvResID.Focus();
                        cdvResID.SelectAll();
                    }
                    else
                    {
                        txtLotID.Focus();
                        txtLotID.SelectAll();
                    }
                }
                else
                {
                    cdvResID.Focus();
                    cdvResID.SelectAll();
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
                return;
            }
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    ClearData("1");

                    if (CheckCondition("VIEW_LOT") == true)
                    {

                        if (View_Lot() == false)
                        {
                            txtLotID.Focus();
                            txtLotID.SelectAll();
                        }
                    }
                    else
                    {
                        txtLotID.Focus();
                        txtLotID.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(MPCF.GetMessage(107), MSSAG_LEVEL.ERROR);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
             try
            {
                if (CheckCondition("SAVE") == false) return;

                if (Input_Raw_Material('1') == false)
                {
                    return;
                }
                else
                {
                    if (View_Res_Stock_List() == false)
                        return;
                    View_Insp_Bin_Mat_List();
                }
            }
            catch (Exception ex)
             {
                 DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("DISAVE") == false) return;

                if (Input_Raw_Material('2') == false)
                {
                    return;
                }
                else
                {
                    if (View_Res_Stock_List() == false)
                        return;
                    View_Insp_Bin_Mat_List();
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MSSAG_LEVEL.ERROR);
                return;
            }
        }

    }
}
