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
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using Miracom.TRSCore;

namespace SOI.Solar
{
    public partial class frmCUSTranPackingFullCell : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        #region [Property]

        const int ENTER = 13;
        string sBoxID = string.Empty;

        #endregion

        public frmCUSTranPackingFullCell()
        {
            InitializeComponent();
        }

        #region [Constant Definition]

        public enum LOT_LIST
        {
            CHK,
            NO,
            FG_ID,
            LOT_ID,
            OPER,
            OPER_DESC,
            MAT_ID,
            MAT_DESC,
            QTY_1,
            UNIT_1,            
            ORDER_ID,
            RES_ID,
            RES_DESC,
			TRAN_USER_ID,
            TRAN_TIME,
			CREATE_TIME
        }

        #endregion

        #region [Variable Definition]

        private MenuInfoTag menuInfo;
        private frmPrintOptionPopup frmOption;
        public PrintOptionModel printOption;
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
                    MPCF.ClearList(spdLotList);
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

                        if (string.IsNullOrEmpty(txtFG_ID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Lot ID]"));
                            MPCF.SetFocus(txtFG_ID);
                            return false;
                        }

                        for(int k=0; k <spdLotList.ActiveSheet.RowCount; k++)
                        {
                            if(txtFG_ID.Text == spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.FG_ID].Text)
                            {
                                MPCF.ShowErrorMessage("해당LOT은 스프레드에 추가 되어 있습니다.");
                                txtFG_ID.Text = "";
                                return false;       
                            }
                        }

                        break;

                    case "PROCESS":

                        if (string.IsNullOrEmpty(txtBoxID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Box ID]"));
                            MPCF.SetFocus(txtBoxID);
                            return false;
                        }

                        if (spdLotList.ActiveSheet.RowCount == 0)
                        {
                            MPCF.ShowMsgBox("Data가 존재하지 않습니다.");
                            MPCF.SetFocus(txtFG_ID);
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

        private void frmCUSTranPackingFullCell_Load(object sender, EventArgs e)
        {
            MPCF.ClearList(spdLotList);

            SetupPrtOpt();
        }

        private void frmCUSTranPackingFullCell_Activated(object sender, EventArgs e)
        {

        }

        private void frmCUSTranPackingFullCell_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                bIsShown = true;

                MPCF.SetFocus(txtBoxID);
            }
        }

        private void txtFG_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER && MPCF.Trim(txtFG_ID.Text) != "")
            {
                txtFG_ID.Text = MPCF.ToUpper(txtFG_ID.Text); // 일괄 대문자

                if (!CheckCondition("VIEW"))
                {
                    MPCF.SetFocus(txtFG_ID);
                    return;
                }

                ViewBoxLotList(txtFG_ID.Text);

				//실행시 박스 수량 구함
                //txtBoxID.Text = MPCF.Trim(sBoxID) + spdLotList.ActiveSheet.RowCount.ToString("00000");
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCondition("VIEW"))
                    return;

                ViewBoxLotList(txtFG_ID.Text);
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

            if (Tran_Box_Lot_Input(txtFG_ID.Text, '1') == true)
            {
                ClearData("1");
                txtFG_ID.Text = string.Empty;
                //txtMatLotID.Text = "";
                MPCF.SetFocus(txtFG_ID);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void SetupPrtOpt()
        {
            this.printOption = new PrintOptionModel();
            if (MPCF.GetPrintOptionFromReg(ref this.printOption, null) == false)
            {
                return;
            }
        }

		//private bool ViewBoxLotList()
		//{
		//    TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
		//    DataTable dt = null;
		//    string s_sql = "";

		//    try
		//    {
		//        //Tag 값 입력 후 체크로직
		//        if (!CheckCondition(CSGC.MP_CHECK_VIEW))
		//            return false;

		//        dvcArgu[0].sCondtion_ID = "$FACTORY";
		//        dvcArgu[0].sCondition_Value = MPGV.gsFactory;

		//        dvcArgu[1].sCondtion_ID = "$BOX_ID";
		//        dvcArgu[1].sCondition_Value = MPCF.Trim(txtBoxID.Text);

		//        if (TPDR.GetDataOne("", ref dt, "VIEW_BOX_LOT_DETAIL", dvcArgu, false, false, ref s_sql) == false)
		//        {
		//            if (dt != null)
		//                dt.Dispose();

		//            GC.Collect();

		//            return false;
		//        }

		//        for (int i = 0; i < dt.Rows.Count; i++)
		//        {
		//            spdLotList.ActiveSheet.RowCount++;
		//            spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.CHK].Value = true;
		//            spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.FG_ID].Value = dt.Rows[i]["FG_ID"].ToString();
		//            spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.LOT_ID].Value = dt.Rows[i]["LOT_ID"].ToString();
		//            spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.OPER].Value = dt.Rows[i]["OPER"].ToString();
		//            spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.OPER_DESC].Value = dt.Rows[i]["OPER_DESC"].ToString();
		//            spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
		//            spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.MAT_DESC].Value = dt.Rows[i]["MAT_SHORT_DESC"].ToString();
		//            spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.QTY_1].Value = dt.Rows[i]["QTY_1"].ToString();
		//            spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.UNIT_1].Value = dt.Rows[i]["UNIT_1"].ToString();
		//            spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.ORDER_ID].Value = dt.Rows[i]["ORDER_ID"].ToString();
		//            spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.RES_ID].Value = dt.Rows[i]["RES_ID"].ToString();
		//            spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.RES_DESC].Value = dt.Rows[i]["RES_DESC"].ToString();
		//            spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.TRAN_TIME].Value = dt.Rows[i]["TRAN_TIME"].ToString();
		//            spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.TRAN_USER_ID].Value = dt.Rows[i]["TRAN_USER_ID"].ToString();
		//            spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.CREATE_TIME].Value = dt.Rows[i]["CREATE_TIME"].ToString();
		//        }

		//        MPCF.FitColumnHeader(spdLotList);

		//        spdLotList.ActiveSheet.Columns[(int)LOT_LIST.MAT_DESC].Width = 220F;
		//    }
		//    catch (System.Exception ex)
		//    {
		//        MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
		//        return false;
		//    }

		//    return true;
		//}

        private bool ViewBoxLotList(string sLotID)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            try
            {
                //Tag 값 입력 후 체크로직
                if (!CheckCondition(CSGC.MP_CHECK_VIEW))
                    return false;

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$FG_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(sLotID);

                if (TPDR.GetDataOne("", ref dt, "VIEW_LOT_INFO_OF_FG_ID_1", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();

                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spdLotList.ActiveSheet.AddRows(0, 1);
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.CHK].Value = false;
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.NO].Value = spdLotList.ActiveSheet.RowCount.ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.FG_ID].Value = dt.Rows[i]["FG_ID"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.LOT_ID].Value = dt.Rows[i]["LOT_ID"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.OPER].Value = dt.Rows[i]["OPER"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.OPER_DESC].Value = dt.Rows[i]["OPER_DESC"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.MAT_DESC].Value = dt.Rows[i]["MAT_SHORT_DESC"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.QTY_1].Value = dt.Rows[i]["QTY_1"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.UNIT_1].Value = dt.Rows[i]["UNIT_1"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.ORDER_ID].Value = dt.Rows[i]["ORDER_ID"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.RES_ID].Value = dt.Rows[i]["RES_ID"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.RES_DESC].Value = dt.Rows[i]["RES_DESC"].ToString();
					spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.TRAN_USER_ID].Value = dt.Rows[i]["TRAN_USER_ID"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.TRAN_TIME].Value = dt.Rows[i]["TRAN_TIME"].ToString();
					spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.CREATE_TIME].Value = dt.Rows[i]["CREATE_TIME"].ToString();
                }

                MPCF.FitColumnHeader(spdLotList);

                spdLotList.ActiveSheet.Columns[(int)LOT_LIST.MAT_DESC].Width = 220F;

                txtFG_ID.Focus();
                txtFG_ID.SelectAll();
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
        private bool Tran_Box_Lot_Input(string sLotID, char cStep)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");
            TRSNode list_item;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '4';

				int iRowCnt = 0;
				for (int i = 0; i < spdLotList.ActiveSheet.RowCount; i++)
				{
					iRowCnt++;
				}

				txtBoxID.Text = MPCF.Trim(sBoxID) + iRowCnt.ToString("00000");

                in_node.AddString("BOX_ID", MPCF.Trim(txtBoxID.Text));

                for (int k = spdLotList.ActiveSheet.RowCount - 1; k > -1; k--)
                {
                    list_item = in_node.AddNode("DATA_LIST");
                    list_item.AddString("LOT_NO", MPCF.Trim(spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.NO].Value));
                    list_item.AddString("LOT_ID", MPCF.Trim(spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.LOT_ID].Value));
                    list_item.AddString("MAT_ID", MPCF.Trim(spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.MAT_ID].Value));                      
                }

                if (MPCF.CallService("CUS", "CWIP_Tran_Box", in_node, ref out_node) == false)
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

        private void btnBoxCreate_Click(object sender, EventArgs e)
        {
            //box생성
            if (Create_Box('3') == true)
            {
                MPCF.SetFocus(txtFG_ID);
            }
        }

        /// <summary>
        /// 박스 생성
        /// </summary>
        /// <returns></returns>
        private bool Create_Box(char c_Step)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = c_Step;

                if (MPCF.CallService("CUS", "CWIP_Tran_Box", in_node, ref out_node) == false)
                    return false;

                sBoxID = txtBoxID.Text = out_node.GetString("NEW_BOX_ID");
                MPCF.ShowSuccessMessage(out_node, false);
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("Update_Box_Lot() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private void btnProcess_Click_1(object sender, EventArgs e)
        {
            if (!CheckCondition("PROCESS"))
                return;

            if (Tran_Box_Lot_Input(txtFG_ID.Text, '2') == true)
            {
                if (CMNF.ShowMsgBox("PackingList를 출력하시겠습니까?", MessageBoxButtons.YesNo, SOI.CliFrx.MSG_LEVEL.INFO) == System.Windows.Forms.DialogResult.Yes)
                {
                    ProcPrint();
                }

                ClearData("1");
                txtFG_ID.Text = string.Empty;
                txtBoxID.Text = string.Empty;
                MPCF.SetFocus(txtFG_ID);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(spdLotList);
            txtFG_ID.Text = "";
            txtBoxID.Text = "";
            MPCF.SetFocus(txtBoxID);
        }

        private void btnPrintLabel_Click(object sender, EventArgs e)
        {
            // Print Option Popup 생성
            if (frmOption == null)
            {
                frmOption = new frmPrintOptionPopup();
            }

            // Print Option Popup 초기화
            frmOption.Owner = this;
            frmOption.printOption = this.printOption;
            frmOption.funcName = this.menuInfo.s_func_name;

            // Show Dialog
            if (frmOption.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.printOption = frmOption.printOption;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!CheckCondition("PROCESS"))
                return;

            ProcPrint();
        }

        private bool ProcPrint()
        {
            TRSNode out_node = new TRSNode("OUT_NODE");

            int i;
            int iRowCount;
            string sProdID;

            try
            {
                udcPrint.InitFlexibleScreen();
                udcPrint.ScreenID = "ViewPackingList";
                udcPrint.ScreenSpread.Tag = "ViewPackingList";
                udcPrint.ProcStep = '1';
                MenuInfoTag menuInfo = (MenuInfoTag)this.Tag;
                udcPrint.OwnerFuncName = menuInfo.s_func_name;
                udcPrint.LotID = "ViewPackingList";

                if (udcPrint.LoadDesign() == false)
                {
                    return false;
                }

                iRowCount = spdLotList.ActiveSheet.RowCount;

				out_node.SetString("CREATE_TIME", MPCF.Trim(spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.CREATE_TIME].Value));
                out_node.SetString("MAT_SHORT_DESC", MPCF.Trim(spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.MAT_DESC].Value));
                out_node.SetString("BOX_ID", txtBoxID.Text);

                for (i = 0; i < spdLotList.ActiveSheet.RowCount; i++)
                {
                    sProdID = String.Format("PROD_ID_{0}", i + 1);
                    out_node.SetString(sProdID, MPCF.Trim(spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.FG_ID].Value));
                }

                if (udcPrint.SetDataToScreen(out_node) == false)
                {
                    return false;
                }

                udcPrint.ScreenSpread.Sheets[0].PrintInfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape;

                for (i = 0; i < MPCF.ToInt(txtPrintQty.Value); i++)
                {
                    MPCF.PrintFlexibleScreen(this, this.printOption, udcPrint, false);
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void txtBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if(e.KeyChar == ENTER)
                {
                    txtBoxID.Text = MPCF.ToUpper(txtBoxID.Text); // 일괄 대문자
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if(spdLotList.ActiveSheet.RowCount == 0)
			{
				MPCF.ShowErrorMessage(MPCF.GetMessage(192));
				return;
			}

			for (int i = spdLotList.ActiveSheet.RowCount-1; i >= 0; i--)
			{
				if (Convert.ToBoolean(spdLotList.ActiveSheet.Cells[i,(int)LOT_LIST.CHK].Value) == true)
				{
					spdLotList.ActiveSheet.Rows.Remove(i, 1);
				}
			}

			int iRowCount = spdLotList.ActiveSheet.RowCount;

			for (int i = 0; i < spdLotList.ActiveSheet.RowCount; i++)
			{
				spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.NO].Value = iRowCount;
				iRowCount--;
			}
		}
    }
}