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
using Miracom.CliFrx;
using Custom.Common;
using Infragistics.Win.UltraWinGrid;

namespace Custom.HanwhaQcell.USModule.CTST.Transaction
{
    // (Required) Inherit Base Form
    // SOIBaseForm03 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel, Print Option
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCUSTranPackingHalfCell : SOIBaseForm03
    {
     #region [Property]

        const int ENTER = 13;
        string sBoxID = string.Empty;

        #endregion

        public frmCUSTranPackingHalfCell()
        {
            InitializeComponent();
        }

        #region [Constant Definition]

        public enum LOT_LIST
        {
            CHK,
            NO,
            LACK_ID,
            PACK_ID,
            FLOW,
            OPER,
            OPER_DESC,
            MAT_ID,
            MAT_DESC,
            PACK_QTY,
            UNIT_ID,            
            ORDER_ID
        }

        #endregion

        #region [Variable Definition]

  //      private MenuInfoTag menuInfo;
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
                    MPOF.ClearList(spdLotList);
                }
            }

            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
            }
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "VIEW":

                        if (string.IsNullOrEmpty(txtPackID.Text) == true)
                        {
                            MPOF.ShowMsgBox(MPOF.GetMessage(335) + Environment.NewLine + MPOF.FindLanguage("[PACK ID]"));
                            MPOF.SetFocus(txtPackID);
                            return false;
                        }

                        for(int k=0; k <spdLotList.ActiveSheet.RowCount; k++)
                        {
                            if(txtPackID.Text == spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.PACK_ID].Text)
                            {
                                MPOF.ShowErrorMessage("해당LOT은 스프레드에 추가 되어 있습니다.");
                                txtPackID.Text = "";
                                return false;       
                            }
                        }

                        break;

                    case "PROCESS":

                        if (string.IsNullOrEmpty(txtLackID.Text) == true)
                        {
                            MPOF.ShowMsgBox(MPOF.GetMessage(335) + Environment.NewLine + MPOF.FindLanguage("[LACK ID]"));
                            MPOF.SetFocus(txtLackID);
                            return false;
                        }

                        if (spdLotList.ActiveSheet.RowCount == 0)
                        {
                            MPOF.ShowMsgBox("Data가 존재하지 않습니다.");
                            MPOF.SetFocus(txtPackID);
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
                MPOF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void frmCUSTranPackingHalfCell_Load(object sender, EventArgs e)
        {
            MPOF.ClearList(spdLotList);

            SetupPrtOpt();
        }

        private void frmCUSTranPackingHalfCell_Activated(object sender, EventArgs e)
        {

        }

        private void frmCUSTranPackingHalfCell_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                bIsShown = true;

                MPOF.SetFocus(txtLackID);
            }
        }
 
        private void SetupPrtOpt()
        {
            this.printOption = new PrintOptionModel();
            if (MPOF.GetPrintOptionFromReg(ref this.printOption, null) == false)
            {
                return;
            }
        }

        private bool ViewPackLotList(string sLotID)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            string s_sql = "";

             try
            {
                MPCF.ClearList(spdLotList);

                string[] sArgu = new string[1];
                sArgu[0] = MPCF.Trim(txtLackID.Text);

                DataTable dtLackList = HQCF.MGetData("View_Cart_Magazine_List", sArgu);
                
                 if (dtLackList.Rows.Count == 0)
                 {
                    txtPackID.Focus();
                    txtPackID.SelectAll();
                     return true;
                 }

                spdLotList.ActiveSheet.RowCount = 0;

                //for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                //{
                //    spdLotList.ActiveSheet.RowCount++;

                //    spdLotList.ActiveSheet.Cells[iRow, (int)LOT_LIST.ORDER_ID].Value = dt.Rows[iRow]["ORDER_ID"].ToString();
                //}

                //MPCF.FitColumnHeader(spdLotList);
                 
                for (int i = 0; i < dtLackList.Rows.Count; i++)
                {
                    spdLotList.ActiveSheet.AddRows(0, 1);
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.CHK].Value = false;
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.NO].Value = spdLotList.ActiveSheet.RowCount.ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.LACK_ID].Value = dtLackList.Rows[i]["LACK_ID"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.PACK_ID].Value = dtLackList.Rows[i]["PACK_ID"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.OPER].Value = dtLackList.Rows[i]["OPER"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.OPER_DESC].Value = dtLackList.Rows[i]["OPER_DESC"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.MAT_ID].Value = dtLackList.Rows[i]["MAT_ID"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.MAT_DESC].Value = dtLackList.Rows[i]["MAT_SHORT_DESC"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.PACK_QTY].Value = dtLackList.Rows[i]["PACK_QTY"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.UNIT_ID].Value = dtLackList.Rows[i]["UNIT_ID"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.ORDER_ID].Value = dtLackList.Rows[i]["ORDER_ID"].ToString();
                }

                MPOF.FitColumnHeader(spdLotList);

                spdLotList.ActiveSheet.Columns[(int)LOT_LIST.MAT_DESC].Width = 220F;

                txtPackID.Focus();
                txtPackID.SelectAll();

                return true;
            }
            catch (System.Exception ex)
            {
                MPOF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool ViewLackInfo(string sLotID)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[1];
            DataTable dt = null;
            string s_sql = "";

            try
            {
                string[] sArgu = new string[1];
                sArgu[0] = MPOF.Trim(sLotID);

                 DataTable dtLackInfo = HQCF.MGetData("VIEW_LACK_INFO", sArgu);

                if (dtLackInfo.Rows.Count == 0)
                {
                    MPOF.ShowMsgBox("대차 정보가 존재하지 않습니다.");
                    return false;
                }
                
                txtLoadCount.Text = dtLackInfo.Rows[0]["USAGE_COUNT"].ToString();
                txtLimitCount.Text = dtLackInfo.Rows[0]["CRR_SIZE"].ToString();

                txtPackID.Focus();
                txtPackID.SelectAll();
            }
            catch (System.Exception ex)
            {
                MPOF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool PackLotListAdd(string sLotID)
        {
             try
            {

                spdLotList.ActiveSheet.AddRows(0, 1);
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.CHK].Value = false;
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.NO].Value = spdLotList.ActiveSheet.RowCount.ToString();
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.LACK_ID].Value = txtLackID.Text;
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.PACK_ID].Value = sLotID.ToString();
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.OPER].Value = "";
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.OPER_DESC].Value = "";
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.MAT_ID].Value = "";
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.MAT_DESC].Value = "";
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.PACK_QTY].Value = "";
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.UNIT_ID].Value = "";
                spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.ORDER_ID].Value = "";

                txtPackID.Text = string.Empty;
                //txtMatLotID.Text = "";
                MPOF.SetFocus(txtPackID);

                return true;
            }
            catch (System.Exception ex)
            {
                MPOF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }


        private void txtPack_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!CheckCondition("VIEW"))
                return;

            if (e.KeyChar == (char)13)
            {
                ViewPackLotList(txtPackID.Text);
            }
                       
        }

        /// <summary>
        /// View Lot
        /// </summary>
        /// <param name="sLotID"></param>
        /// <returns></returns>
        private bool Tran_Pack_Lot_Input(string sLotID, char cStep)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");
            TRSNode list_item;

            try
            {
                MPOF.SetInMsg(in_node);
                in_node.ProcStep = '4';

				int iRowCnt = 0;
				for (int i = 0; i < spdLotList.ActiveSheet.RowCount; i++)
				{
					iRowCnt++;
				}

                for (int k = spdLotList.ActiveSheet.RowCount - 1; k > -1; k--)
                {
                    list_item = in_node.AddNode("DATA_LIST");
                    list_item.AddString("LOT_NO", MPOF.Trim(spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.NO].Value));
                    list_item.AddString("LACK_ID", MPOF.Trim(spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.LACK_ID].Value));
                    list_item.AddString("PACK_ID", MPOF.Trim(spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.PACK_ID].Value));                 
                }

                if (HQCF.CallService_safe("CUS", "CWIP_Tran_Packing_HalfCell", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPOF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        //private void btnBoxCreate_Click(object sender, EventArgs e)
        //{
        //    //box생성
        //    if (Create_Box('3') == true)
        //    {
        //        MPOF.SetFocus(txtPackID);
        //    }
        //}

        ///// <summary>
        ///// 박스 생성
        ///// </summary>
        ///// <returns></returns>
        //private bool Create_Box(char c_Step)
        //{
        //    TRSNode in_node = new TRSNode("TRAN_IN");
        //    TRSNode out_node = new TRSNode("TRAN_OUT");

        //    try
        //    {
        //        MPOF.SetInMsg(in_node);
        //        in_node.ProcStep = c_Step;

        //        if (HQCF.CallService_safe("CUS", "CWIP_Tran_Box", in_node, ref out_node) == false)
        //            return false;

        //        sBoxID = txtLackID.Text = out_node.GetString("NEW_BOX_ID");
        //        MPOF.ShowSuccessMessage(out_node, false);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MPOF.ShowMessage("Update_Box_Lot() : " + ex.Message, MSG_LEVEL.ERROR, false);
        //        return false;
        //    }

        //    return true;
        //}

               private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCondition("VIEW"))
                    return;

                ViewPackLotList(txtPackID.Text);
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (!CheckCondition("PROCESS"))
                return;

            if (Tran_Pack_Lot_Input(txtPackID.Text, '1') == true)
            {
                ClearData("1");
                txtPackID.Text = string.Empty;
                //txtMatLotID.Text = "";
                MPOF.SetFocus(txtPackID);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        
        private void btnProcess_Click_1(object sender, EventArgs e)
        {
            if (!CheckCondition("PROCESS"))
                return;

            if (Tran_Pack_Lot_Input(txtPackID.Text, '2') == true)
            {
                if (CMNF.ShowMsgBox("PackingList를 출력하시겠습니까?", MessageBoxButtons.YesNo, SOI.CliFrx.MSG_LEVEL.INFO) == System.Windows.Forms.DialogResult.Yes)
                {
                    ProcPrint();
                }

                ClearData("1");
                txtPackID.Text = string.Empty;
                txtLackID.Text = string.Empty;
                MPOF.SetFocus(txtPackID);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MPOF.ClearList(spdLotList);
            txtPackID.Text = "";
            txtLackID.Text = "";
            MPOF.SetFocus(txtLackID);
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
//            frmOption.funcName = this.menuInfo.s_func_name;

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
            SOIFlexibleScreen udcPrinit = new SOIFlexibleScreen();

            int i;
            int iRowCount;
            string sProdID;

            try
            {
                udcPrinit.InitFlexibleScreen();
                udcPrinit.ScreenID = "ViewPackingList";
                udcPrinit.ScreenSpread.Tag = "ViewPackingList";
                udcPrinit.ProcStep = '1';
   //             MenuInfoTag menuInfo = (MenuInfoTag)this.Tag;
  //              udcPrinit.OwnerFuncName = menuInfo.s_func_name;
                udcPrinit.LotID = "ViewPackingList";

                if (udcPrinit.LoadDesign() == false)
                {
                    return false;
                }

                iRowCount = spdLotList.ActiveSheet.RowCount;

                out_node.SetString("MAT_SHORT_DESC", MPOF.Trim(spdLotList.ActiveSheet.Cells[0, (int)LOT_LIST.MAT_DESC].Value));
                out_node.SetString("LACK_ID", txtLackID.Text);

                for (i = 0; i < spdLotList.ActiveSheet.RowCount; i++)
                {
                    sProdID = String.Format("PROD_ID_{0}", i + 1);
                    out_node.SetString(sProdID, MPOF.Trim(spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.LACK_ID].Value));
                }

                if (udcPrinit.SetDataToScreen(out_node) == false)
                {
                    return false;
                }

                udcPrinit.ScreenSpread.Sheets[0].PrintInfo.Orientation = FarPoint.Win.Spread.PrintOrientation.Landscape;

                for (i = 0; i < MPOF.ToInt(txtPrintQty.Value); i++)
                {
                    MPOF.PrintFlexibleScreen(this, this.printOption, udcPrinit, false);
                }

                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void txtLackID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER && MPOF.Trim(txtLackID.Text) != "")
            {
                txtLackID.Text = MPOF.ToUpper(txtLackID.Text); // 일괄 대문자

                if (!CheckCondition("VIEW"))
                {
                    MPOF.SetFocus(txtLackID);
                    return;
                }

                ViewLackInfo(txtLackID.Text);
            }
        }

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if(spdLotList.ActiveSheet.RowCount == 0)
			{
				MPOF.ShowErrorMessage(MPOF.GetMessage(192));
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
