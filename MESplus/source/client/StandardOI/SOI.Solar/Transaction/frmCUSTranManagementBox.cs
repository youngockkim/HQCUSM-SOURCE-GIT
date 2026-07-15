using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx;
using Miracom.TRSCore;
using Miracom.MESCore;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;

namespace SOI.Solar
{
    public partial class frmCUSTranManagementBox : SOIBaseForm03
    {
        #region Property

        private bool bIsShown = false;
        const int ENTER = 13;

        //private TRSNode nodeLotInfo;
        //private TRSNode ORDER;

        #endregion

        #region " Constant Definition "
        public enum TARGET_LIST
        {
            CHECK = 0,
            BARCODE,
            COL_PROD_ID,
            COL_MAT_SHORT_DESC
        }
        public enum LOT_LIST
        {
            CHECK = 0,
            BOX_BARCODE,
            LOT_BARCODE,
            COL_PROD_ID,
            COL_MAT_SHORT_DESC,
            //COL_CREATE_TIME,
            COL_BTN
        }
        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private bool check_flag = false;
        private bool b_manage = false;
        private bool b_autocreate_boxflag = false;

        #endregion

        #region Constructor

        public frmCUSTranManagementBox()
        {
            InitializeComponent();
        }

        #endregion

        #region " Control Event Definition "
        private void uteId_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int i;

                if ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122)
                {
                    e.KeyChar = (char)(Convert.ToInt32(e.KeyChar) - 32);
                }

                if ((int)e.KeyChar == ENTER)
                {

                    //scrollText.Visible = false;

                    if (MPCF.Trim(uteBoxBarcode.Text) == "")
                    {
                        if (CheckCondition("ViewBox") == true)
                        {
                            ViewLotList(uteId.Text);

                            uteId.SelectAll();
                        }
                        return;
                    }
                    else
                    {
                        if (CheckCondition("ViewLot") == true)
                        {
                            if (ViewLot(uteId.Text) == false) return;
                            uteId.SelectAll();
                        }

                        //포함된 BOX 의 수량만큼 차면 자동 BOX 완료시킴
                        if (chkManagement.Checked == false)
                        {

                            if (MPCF.ToInt(uteStandardQty.Text) == spdLotList.ActiveSheet.RowCount)
                            {
                                if (UpdateBoxLotList(MPGC.MP_STEP_UPDATE) == false)
                                    return;

                                //Pallet List Update
                                if (spdBoxList.ActiveSheet.RowCount > 1)
                                {
                                    spdBoxList.ActiveSheet.RowCount++;
                                }

                                spdBoxList.ActiveSheet.Cells[spdBoxList.ActiveSheet.RowCount - 1, (int)TARGET_LIST.CHECK].Value = false;
                                spdBoxList.ActiveSheet.Cells[spdBoxList.ActiveSheet.RowCount - 1, (int)TARGET_LIST.BARCODE].Tag = uteBoxBarcode.Tag;
                                spdBoxList.ActiveSheet.Cells[spdBoxList.ActiveSheet.RowCount - 1, (int)TARGET_LIST.BARCODE].Text = uteBoxBarcode.Text;
                                spdBoxList.ActiveSheet.Cells[spdBoxList.ActiveSheet.RowCount - 1, (int)TARGET_LIST.COL_PROD_ID].Text = uteMatId.Text;
                                spdBoxList.ActiveSheet.Cells[spdBoxList.ActiveSheet.RowCount - 1, (int)TARGET_LIST.COL_MAT_SHORT_DESC].Text = uteModel.Text;

                                //Pallet Print
                                for (i = 0; i < 3; i++)
                                {
                                    ProcPrint();
                                }

                                spdLotList.ActiveSheet.RowCount = 0;
                                uteBoxBarcode.Text = "";
                                uteBoxBarcode.Tag = "";

                                MPCF.FitColumnHeader(spdBoxList);
                            }

                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Form Load
        /// Caption Convert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCUSTranManagementBox_Load(object sender, EventArgs e)
        {
            ClearData('1');
            // Caption 변환
            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// Form Shown (Load --> Activate --> Shown)
        /// Focus control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCUSTranManagementBox_Shown(object sender, EventArgs e)
        {
            // 최초 1회 실행
            if (bIsShown == false)
            {
                // Lot ID Focus
                //MPCF.SetFocus(txtLotID);

                bIsShown = true;
            }
        }

        private void frmCUSTranManagementBox_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                b_load_flag = true;
            }

            uteId.Focus();
        }

        #endregion

        #region Function

        #region " ClearData "
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1")
        //
        private void ClearData(char ProcStep)
        {
            try
            {
                if (ProcStep == '1')
                {
                    MPCF.FieldClear(grpBOXInfo);
                    MPCF.ClearList(spdLotList);
                    //MPCF.ClearList(spdBoxList);
                    utePackQty.Text = "0";
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        #endregion

        #region " CheckCondition "

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step

        private bool CheckCondition(string FuncName)
        {

            try
            {
                switch (FuncName)
                {
                    case "UpdateBoxLotList":
                        if (uteId.Text == "")
                        {
                            //MPCF.ShowMsgBox(MPCF.GetMessage(364));
                            //uteId.Focus();
                            //return false;
                        }


                        break;
                    case "ViewBox":

                        break;
                    case "ViewLot":

                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        #endregion

        #region " ViewLotList "

        // ViewLotList()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private bool ViewLotList(string sBoxID)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_LIST_OUT");

            int i = 0;
            char c_autocreate_boxflag = 'N';


            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.SetString("BOX_ID", sBoxID);

            if (chkManagement.Checked == true)
            {
                //BOX 관리모드
                MPCF.ClearList(spdBoxList, true);
                MPCF.ClearList(spdLotList, true);
                in_node.SetChar("MANAGEMENT_FLAG", 'Y');
            }
            else
            {
                //처음 LOTID 를 읽으면 BOX 를 자동생성함.
                in_node.SetChar("AUTOCREATE_BOX_FLAG", "Y");
                c_autocreate_boxflag = 'Y';

                b_autocreate_boxflag = true;
            }

            try
            {
                if (MPCF.CallService("CUS", "CUS_View_Lot_List_By_Box", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdLotList.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList("LIST").Count; i++)
                {
                    spdLotList.ActiveSheet.RowCount++;
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.CHECK].Value = true;
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.LOT_BARCODE].Tag = out_node.GetList("LIST")[i].GetString("LOT_ID");
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.LOT_BARCODE].Text = out_node.GetList("LIST")[i].GetString("LOT_BARCODE");

                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.BOX_BARCODE].Text = out_node.GetString("BOX_BARCODE");
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.BOX_BARCODE].Tag = out_node.GetString("BOX_ID");
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.COL_PROD_ID].Text = out_node.GetString("MAT_ID");
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.COL_MAT_SHORT_DESC].Text = out_node.GetString("MAT_SHORT_DESC");

                }

                if (b_manage)
                {
                    FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType = new FarPoint.Win.Spread.CellType.ButtonCellType();
                    //buttonCellType.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                    buttonCellType.Text = "DEL";
                    spdLotList_Sheet1.ColumnCount = 6;
                    this.spdLotList_Sheet1.Columns.Get((int)LOT_LIST.COL_BTN).CellType = buttonCellType;
                    this.spdLotList_Sheet1.Columns.Get((int)LOT_LIST.COL_BTN).Label = "-";
                }

                MPCF.FitColumnHeader(spdLotList);

                uteMatId.Text = out_node.GetString("MAT_ID");
                uteMatDesc.Text = out_node.GetString("MAT_DESC");
                uteModel.Text = out_node.GetString("MAT_SHORT_DESC");
                utePartNo.Text = out_node.GetString("CUSTOMER_MAT_ID");
                uteProductPcbRevision.Text = out_node.GetString("MAT_CMF_5");
                uteBoxRevision.Text = out_node.GetString("MAT_CMF_6");
                uteBurnInTime.Text = out_node.GetString("MAT_CMF_9");
                uteBurnInTime.Text = out_node.GetString("MAT_CMF_9");
                uteStandardQty.Text = out_node.GetInt("PACK_LOT_COUNT").ToString();
                utePackQty.Text = out_node.GetDouble("QTY_1").ToString();
                uteBoxBarcode.Text = out_node.GetString("BOX_BARCODE");
                uteBoxBarcode.Tag = out_node.GetString("BOX_ID");

                //처음 LOT을 읽었을경우 LOT LIST 를 추가함
                if (c_autocreate_boxflag == 'Y')
                    ViewLot(uteId.Text);

                uteId.SelectAll();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        #endregion

        #region " ViewLot "

        // ViewLot()
        //       - View Lot
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private bool ViewLot(string sLotID)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            int i = 0;
            bool b_exist;

            FarPoint.Win.Spread.CellType.TextCellType textCellType = new FarPoint.Win.Spread.CellType.TextCellType();

            try
            {
                b_exist = false;
                for (i = 0; i < spdLotList.ActiveSheet.RowCount; i++)
                {
                    if (spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.LOT_BARCODE].Tag.ToString() == sLotID)
                    {
                        spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.CHECK].Value = true;
                        b_exist = true;
                        break;
                    }
                }

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.SetString("LOT_ID", sLotID);
                in_node.SetString("MAT_ID", uteMatId.Text);

                in_node.SetChar("_BOX_MAINT", 'Y');


                if (MPCF.CallService("CUS", "CUS_View_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }


                //for (i = 0; i < spdBoxList.ActiveSheet.RowCount; i++)
                //{

                //    //if (spdBoxList.ActiveSheet.Cells[i, (int)TARGET_LIST.BARCODE].Tag.ToString() == out_node.GetString("LOT_ID"))
                //    //{
                //    //    spdBoxList.ActiveSheet.Cells[i, (int)TARGET_LIST.CHECK].Value = true;
                //    //    spdBoxList.ActiveSheet.Rows[i].BackColor = Color.LightSalmon;
                //    //    b_exist = true;
                //    //    break;
                //    //}
                //}

                if ((b_autocreate_boxflag == true) && (out_node.GetString("BOX_ID").Trim() != string.Empty))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(366));
                    return false;
                }

                if (b_exist == false)
                {
                    i = spdLotList.ActiveSheet.RowCount;
                    spdLotList.ActiveSheet.RowCount++;
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.CHECK].Value = true;

                    if (chkManagement.Checked == false)
                    {
                        spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.BOX_BARCODE].Text = uteBoxBarcode.Text;
                        spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.BOX_BARCODE].Tag = uteBoxBarcode.Tag;
                    }
                    else
                    {
                        spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.BOX_BARCODE].Text = uteBoxBarcode.Text;
                        spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.BOX_BARCODE].Tag = uteBoxBarcode.Tag;

                        //spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.BOX_BARCODE].Text = out_node.GetString("BOX_BARCODE");
                        //spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.BOX_BARCODE].Tag = out_node.GetString("BOX_ID");
                    }
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.LOT_BARCODE].Text = out_node.GetString("LOT_BARCODE");
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.LOT_BARCODE].Tag = out_node.GetString("LOT_ID");
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.COL_PROD_ID].Text = out_node.GetString("MAT_ID");
                    spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.COL_MAT_SHORT_DESC].Text = out_node.GetString("MAT_SHORT_DESC");
                    MPCF.FitColumnHeader(spdLotList);

                    this.spdLotList_Sheet1.Columns.Get((int)LOT_LIST.LOT_BARCODE).CellType = textCellType;
                }

                uteId.SelectAll();
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        #endregion

        #region "UpdateBoxLotList"
        //
        // UpdateBoxLotList()
        //       - Create/Update/Delete Direct View
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool UpdateBoxLotList(char ProcStep)
        {
            int i = 0;
            int j = 0;

            String boxId = String.Empty;
            String boxlotId = String.Empty;

            TRSNode in_node = new TRSNode("UPDATE_BOX_LOT_LIST_IN");
            TRSNode out_node = new TRSNode("UPDATE_BOX_LOT_LIST_OUT");
            TRSNode add_node;
            TRSNode remove_node;

            bool updateFlag = false;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.UserID = udcUser.IDText;
                in_node.SetString("BOX_ID", uteBoxBarcode.Tag);
                in_node.SetString("BOX_BARCODE", uteBoxBarcode.Text);

                for (j = 0; j < spdBoxList.ActiveSheet.Rows.Count; j++)
                {
                    //BoxId, BoxLotId
                    if (spdBoxList.ActiveSheet.Cells[j, (int)TARGET_LIST.CHECK].Value != null &&
                    Convert.ToBoolean(spdBoxList.ActiveSheet.Cells[j, (int)TARGET_LIST.CHECK].Value) == true)
                    {
                        updateFlag = true;
                        remove_node = in_node.AddNode("REMOVE_LIST");
                        remove_node.SetString("BOX_ID", uteBoxBarcode.Tag);
                        remove_node.SetString("BOX_BARCODE", uteBoxBarcode.Text);
                        remove_node.SetString("LOT_ID", spdBoxList.ActiveSheet.Cells[j, (int)TARGET_LIST.BARCODE].Tag.ToString());
                        remove_node.SetString("LOT_BARCODE", spdBoxList.ActiveSheet.Cells[j, (int)TARGET_LIST.BARCODE].Text);
                    }
                }

                for (i = 0; i < spdLotList.ActiveSheet.RowCount; i++)
                {
                    //if ((bool)spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.CHECK].Value == true)
                    if (spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.CHECK].Value != null &&
                    Convert.ToBoolean(spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.CHECK].Value) == true)
                    {
                        updateFlag = true;
                        add_node = in_node.AddNode("ADD_LIST");
                        add_node.SetString("BOX_ID", spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.BOX_BARCODE].Tag.ToString());
                        add_node.SetString("BOX_BARCODE", spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.BOX_BARCODE].Text);
                        add_node.SetString("LOT_ID", spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.LOT_BARCODE].Tag.ToString());
                        add_node.SetString("LOT_BARCODE", spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.LOT_BARCODE].Text);
                    }
                }

                if ((updateFlag == true) && (chkManagement.Checked == true))
                {
                    if (CMNF.ShowMsgBox(CMNF.GetMessage(10), MessageBoxButtons.YesNo, SOI.CliFrx.MSG_LEVEL.WARNING) != System.Windows.Forms.DialogResult.Yes)
                    {
                        return false;
                    }
                }

                if (MPCF.CallService("CUS", "CUS_Adapt_Box", in_node, ref out_node) == false)
                {

                    return false;
                }

                //MPCF.ShowSuccessMsg(out_node);
                CSCF.ShowStatusMsg(scrollText, 'S', MPCF.GetMessage(52));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        #endregion

        private bool ProcPrint()
        {
            TRSNode out_node = new TRSNode("OUT_NODE");

            int i;
            int iRowCount;
            int iPrintRowCount;
            string sProdID;

            try
            {
                udcScreen.InitFlexibleScreen();
                udcScreen.ScreenID = "ViewPackingList";
                udcScreen.ScreenSpread.Tag = "ViewPackingList";
                udcScreen.ProcStep = '1';
                MenuInfoTag menuInfo = (MenuInfoTag)this.Tag;
                udcScreen.OwnerFuncName = menuInfo.s_func_name; // ex) OWIP1001, OATP2002, ...
                udcScreen.LotID = "ViewPackingList";

                if (udcScreen.LoadDesign() == false)
                {
                    //return false;
                }

                ////udcPrint.InitFlexibleScreen();
                ////udcPrint.ScreenID = "ViewPackingList";
                ////udcPrint.ScreenSpread.Tag = "ViewPackingList";
                ////udcPrint.ProcStep = '1';
                ////udcPrint.LotID = "ViewPackingList";
                ////udcPrint.LoadDesign();

                iPrintRowCount = 35;
                iRowCount = spdLotList.ActiveSheet.RowCount;

                out_node.SetString("MAT_SHORT_DESC", MPCF.Trim(spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.COL_MAT_SHORT_DESC].Value));
                out_node.SetString("BOX_ID", uteBoxBarcode.Text);

                for (i = 0; i < iRowCount; i++)
                {
                    if (spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.COL_PROD_ID].Value != null)
                    {
                        sProdID = String.Format("PROD_ID_{0}", i + 1);
                        out_node.SetString(sProdID, MPCF.Trim(spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.COL_PROD_ID].Value));
                    }
                }

                for (i = iRowCount; i < iPrintRowCount; i++)
                {
                    sProdID = String.Format("PROD_ID_{0}", i + 1);
                    out_node.SetString(sProdID, " ");
                }

                //if (udcScreen.SetDataToScreen(out_node) == false) return false;

                

                //udcScreen.ScreenSpread.ActiveSheet.PrintInfo.Printer = MPCF.Trim(cdvPrinter.Text);
                //udcScreen.ScreenSpread.PrintSheet(0);

                //PathXML = "F:\\StandardOI\\ViewPackingList\\ViewPackingList.xml";

                // 8. Clear
                //if (spdSpread.Sheets.Count > 0)
                //{
                //    spdSpread.Sheets[0].Rows.Clear();
                //}
                //udcScreen.InitFlexibleScreen();

                //// 9. Open
                ////spdSpread.Open(sPathXML);
                //udcScreen.ScreenSpread.Open(PathXML);

                //// 10. Set Theme
                //udcScreen.SetOITheme();

                if (udcScreen.SetDataToScreen(out_node) == false)
                {
                    //return false;
                }

                MPCF.PrintFlexibleScreen(this, base.printOption, udcScreen, false);


                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        #endregion

        #region " Button Event Definition "

        /// <summary>
        /// Lot을 End 처리합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("UpdateBoxLotList") == false)
                    return;

                if (UpdateBoxLotList(MPGC.MP_STEP_UPDATE) == false)
                    return;

                spdLotList.ActiveSheet.RowCount = 0;
                ViewLotList(uteBoxBarcode.Tag.ToString());
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                //sfdExcel.FileName = this.Text + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                //if (sfdExcel.ShowDialog(this) == DialogResult.Cancel) return;

                //spdLotList.ActiveSheet.Protect = false;
                //spdLotList.SaveExcel(sfdExcel.FileName, FarPoint.Excel.ExcelSaveFlags.SaveBothCustomRowAndColumnHeaders);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("UpdateBoxLotList") == true)
                {
                    UpdateBoxLotList(MPGC.MP_STEP_DELETE);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnCloseC_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            int i;
            try
            {
                if (check_flag == true)
                {
                    for (i = 0; i < spdLotList.ActiveSheet.RowCount; i++)
                    {
                        spdLotList.ActiveSheet.Cells[i, 0].Value = false;
                    }

                    check_flag = false;
                    btnCheckAll.Text = "Check All";
                }
                else
                {
                    for (i = 0; i < spdLotList.ActiveSheet.RowCount; i++)
                    {
                        spdLotList.ActiveSheet.Cells[i, 0].Value = true;
                    }

                    check_flag = true;
                    btnCheckAll.Text = "Uncheck All";
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MPCF.FieldClear(pnlMiddle, udcUser);
            MPCF.FieldClear(grpBOXInfo);
            MPCF.ClearList(spdBoxList);
            MPCF.ClearList(spdLotList);
            uteId.Focus();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < 3; i++)
            {
                ProcPrint();
            }
        }

        //private void cdvPrinter_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        //{
        //    try
        //    {
        //        //cdvPrinter.Init();

        //        //cdvPrinter.

        //        cdvPrinter.Text = e.SelectedItem.SubItems[0].Text;
        //        //cdvPrinter.DescText = e.SelectedItem.SubItems[0].Text;

        //        MPCF.SaveRegSetting(this.Name, "Settings", "SAVE_PRINT_NAME", cdvPrinter.Text);
        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMsgBox("Function : cdvPrinter_SelectedItemChanged()\n" + ex.Message);
        //    }
        //}

        private void chkManagement_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkManagement.Checked == true)
                {
                    this.uteBoxBarcode.ReadOnly = false;
                    b_manage = true;
                    FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType = new FarPoint.Win.Spread.CellType.ButtonCellType();
                    buttonCellType.Text = "DEL";
                    spdLotList_Sheet1.ColumnCount = 6;
                    this.spdLotList_Sheet1.Columns.Get((int)LOT_LIST.COL_BTN).CellType = buttonCellType;
                    this.spdLotList_Sheet1.Columns.Get((int)LOT_LIST.COL_BTN).Label = "-";
                }
                else
                {
                    this.uteBoxBarcode.ReadOnly = true;
                    b_manage = false;
                    spdLotList_Sheet1.ColumnCount = 5;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void uteBoxBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == ENTER)
                {
                    ViewLotList(uteBoxBarcode.Text);
                    uteBoxBarcode.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void spdLotList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column != (int)LOT_LIST.COL_BTN) return;

                this.spdLotList.ActiveSheet.Rows[e.Row].Remove();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        #endregion
    }
}
