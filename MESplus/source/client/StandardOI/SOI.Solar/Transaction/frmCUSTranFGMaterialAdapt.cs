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
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using BOI.OIFrx.BOIControls;

namespace SOI.Solar
{
    public partial class frmCUSTranFGMaterialAdapt : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        #region [Property]

        private bool bIsShown = false;
        const int ENTER = 13;

        #endregion

        public frmCUSTranFGMaterialAdapt()
        {
            InitializeComponent();
        }

        private MenuInfoTag menuInfo;
        private frmPrintOptionPopup frmOption;
        public PrintOptionModel printOption;
        private string s_Chg_flag;
        private string s_Change_Mat;

        public enum LOT_LIST
        {
            CHK,
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
            TRAN_TIME
            
        }

        /// <summary>
        /// View Lot
        /// </summary>
        /// <param name="sFgID"></param>
        /// <returns></returns>
        private bool Tran_Material_Change()
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");
            TRSNode data_list;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHG_MAT_ID", MPCF.Trim(cdvMatID.Text));
                //in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

				int iDataCount = 0;
                for(int k =0; k <spdLotList.ActiveSheet.RowCount; k++)
                {
                    if(Convert.ToBoolean(spdLotList.ActiveSheet.Cells[k, 0].Value) == true)
                    {
                        data_list = in_node.AddNode("DATA_LIST");
                        //data_list.AddString("LOT_ID", spdLotList.ActiveSheet.Cells[k, 1].Text);
						data_list.AddString("FG_ID", spdLotList.ActiveSheet.Cells[k, 1].Text);
						data_list.AddString("LOT_ID", spdLotList.ActiveSheet.Cells[k, 2].Text);
						iDataCount++;
                    }
                }

				if(iDataCount==0)
				{
					MPCF.ShowMessage("저장할 항목이 존재하지 않습니다.",MSG_LEVEL.ERROR,true);
					return false;
				}

                if (MPCF.CallService("CUS", "CWIP_Tran_FG_Material_Lot_Adapt", in_node, ref out_node) == false)
                {
                    return false;
                }


                for (int k = 0; k < spdLotList.ActiveSheet.RowCount; k++)
                {
                    if (Convert.ToBoolean(spdLotList.ActiveSheet.Cells[k, 0].Value) == true)
                    {                      
                        //ProcPrint(spdLotList.ActiveSheet.Cells[k, 1].Text);
						ProcPrint(spdLotList.ActiveSheet.Cells[k, 2].Text);
                    }
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

        private bool ProcPrint(string sLotID)
        {
            TRSNode out_node = new TRSNode("OUT_NODE");
            string sScreenID = string.Empty;
            DataTable dt = new DataTable();
            string s_Design;
            try
            {
                //해당 랏의 라벨 정보 조회
                TPDR.DirectViewCond[] ArrDVC;
                ArrDVC = new TPDR.DirectViewCond[2];

                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$LOT_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(sLotID);

				if (TPDR.DirectViewOne(null, "VIEW_SHP_LOT_INFO_1", ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();

                    return false;
                }

                txtFgID.Text = dt.Rows[0]["LOT_ID"].ToString();
                s_Design = dt.Rows[0]["DESIGN"].ToString();

                //라벨 정보 조회
                if (GetMatInfoOfLot(MPCF.Trim(this.txtFgID.Text), ref dt) == false)
                {
                    return false;
                }
                if (dt.Rows.Count < 1)
                {
                    return false;
                }

                sScreenID = s_Design;

                udcPrint.InitFlexibleScreen();
                udcPrint.ScreenID = sScreenID;
                udcPrint.ScreenSpread.Tag = sScreenID;
                udcPrint.ProcStep = '1';
                udcPrint.LotID = sScreenID;
                udcPrint.LoadDesign();

                out_node.SetString("MODEL", MPCF.Trim(dt.Rows[0]["MODEL"].ToString()));
                out_node.SetString("LCOD_PMAX", MPCF.Trim(dt.Rows[0]["LCOD_PMAX"].ToString()));
                out_node.SetString("LCOD_TOLE", MPCF.Trim(dt.Rows[0]["LCOD_TOLE"].ToString()));
                out_node.SetString("LCOD_PVOC", MPCF.Trim(dt.Rows[0]["LCOD_PVOC"].ToString()));
                out_node.SetString("LCOD_PISC", MPCF.Trim(dt.Rows[0]["LCOD_PISC"].ToString()));
                out_node.SetString("LCOD_PVMP", MPCF.Trim(dt.Rows[0]["LCOD_PVMP"].ToString()));
                out_node.SetString("LCOD_PIMP", MPCF.Trim(dt.Rows[0]["LCOD_PIMP"].ToString()));
                out_node.SetString("LCOD_TEMP", MPCF.Trim(dt.Rows[0]["LCOD_TEMP"].ToString()));
                out_node.SetString("LCOD_FUSE", MPCF.Trim(dt.Rows[0]["LCOD_FUSE"].ToString()));
                out_node.SetString("LCOD_DIME", MPCF.Trim(dt.Rows[0]["LCOD_DIME"].ToString()));
                out_node.SetString("LCOD_WEIG", MPCF.Trim(dt.Rows[0]["LCOD_WEIG"].ToString()));
                out_node.SetString("LCOD_RATI", MPCF.Trim(dt.Rows[0]["LCOD_RATI"].ToString()));
                out_node.SetString("LCOD_LOAD", MPCF.Trim(dt.Rows[0]["LCOD_LOAD"].ToString()));
                out_node.SetString("LCOD_CLAS", MPCF.Trim(dt.Rows[0]["LCOD_CLAS"].ToString()));
                out_node.SetString("LCOD_CERT", MPCF.Trim(dt.Rows[0]["LCOD_CERT"].ToString()));
                out_node.SetString("LCOD_TYPE", MPCF.Trim(dt.Rows[0]["LCOD_TYPE"].ToString()));
                out_node.SetString("LCOD_DATE", MPCF.Trim(dt.Rows[0]["LCOD_DATE"].ToString()));
                out_node.SetString("MANU_DATE", MPCF.Trim(dt.Rows[0]["MANU_DATE"].ToString()));
                out_node.SetString("PROD_CODE", MPCF.Trim(dt.Rows[0]["PROD_CODE"].ToString()));
                out_node.SetString("PROD_DESC", MPCF.Trim(dt.Rows[0]["PROD_DESC"].ToString()));
                out_node.SetString("PROD_DIS_BARCODE", MPCF.Trim(dt.Rows[0]["PROD_DIS_BARCODE"].ToString()));
                out_node.SetString("PROD_BARCODE", MPCF.Trim(dt.Rows[0]["PROD_CODE"].ToString()));

                if (udcPrint.SetDataToScreen(out_node) == false) return false;

                MPCF.PrintFlexibleScreen(this, this.printOption, udcPrint, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            finally
            {
                this.txtFgID.Focus();
                this.txtFgID.SelectAll();
            }
        }

        private bool GetMatInfoOfLot(string sLotID, ref DataTable dt)
        {
            try
            {
                string sViewID;

                TPDR.DirectViewCond[] arr;
                arr = new TPDR.DirectViewCond[2];
                sViewID = "VIEW_MAT_INFO_OF_LOT";

                arr[0].sCondtion_ID = "$FACTORY";
                arr[0].sCondition_Value = MPGV.gsFactory;

                arr[1].sCondtion_ID = "$LOT_ID";
                arr[1].sCondition_Value = MPCF.Trim(sLotID);

                if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, arr, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                if (dt.Rows.Count < 1)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewLotInfo(string sFgID)
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
                dvcArgu[1].sCondition_Value = MPCF.Trim(sFgID);

				if (TPDR.GetDataOne("", ref dt, "VIEW_LOT_INFO_OF_FG_ID", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();

                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if(dt.Rows[i]["OPER"].ToString() != "2810")
                    {
                        MPCF.ShowErrorMessage("완제품 창고에 있는 Lot을 입력해 주세요.");
                        txtFgID.Text = "";
                        return false;
                    }

                    spdLotList.ActiveSheet.RowCount++;
                    spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.CHK].Value = true;
					spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.FG_ID].Value = dt.Rows[i]["FG_ID"].ToString();
                    spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.LOT_ID].Value = dt.Rows[i]["LOT_ID"].ToString();
                    spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.OPER].Value = dt.Rows[i]["OPER"].ToString();
                    spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.OPER_DESC].Value = dt.Rows[i]["OPER_DESC"].ToString();
                    spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.MAT_DESC].Value = dt.Rows[i]["MAT_SHORT_DESC"].ToString();
                    spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.QTY_1].Value = dt.Rows[i]["QTY_1"].ToString();
                    spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.UNIT_1].Value = dt.Rows[i]["UNIT_1"].ToString();
                    spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.ORDER_ID].Value = dt.Rows[i]["ORDER_ID"].ToString();
                    spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.RES_ID].Value = dt.Rows[i]["RES_ID"].ToString();
                    spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.RES_DESC].Value = dt.Rows[i]["RES_DESC"].ToString();
                    spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.TRAN_USER_ID].Value = dt.Rows[i]["TRAN_USER_ID"].ToString();
                    spdLotList.ActiveSheet.Cells[spdLotList.ActiveSheet.RowCount - 1, (int)LOT_LIST.TRAN_TIME].Value = dt.Rows[i]["TRAN_TIME"].ToString();
                    
                }

                MPCF.FitColumnHeader(spdLotList);

                spdLotList.ActiveSheet.Columns[(int)LOT_LIST.MAT_DESC].Width = 220F;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                int i_cnt = 0;

                switch (FuncName)
                {
                    case "PROCESS":                        

                        for(int k = 0; k < spdLotList.ActiveSheet.RowCount; k ++)
                        {
                            if(Convert.ToBoolean(spdLotList.ActiveSheet.Cells[k, 0].Value) == true)
                            {
                                i_cnt++;
                            }
                        }

                        if(i_cnt ==0)
                        {
                            MPCF.ShowErrorMessage("선택된 Data가 존재하지않습니다.");
                            return false;
                        }

                        if (string.IsNullOrEmpty(cdvMatID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Mat ID]"));
                            MPCF.SetFocus(cdvMatID);
                            return false;
                        }

                        break;

                    case "VIEW":

                        if (string.IsNullOrEmpty(txtFgID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Fg ID]"));
                            MPCF.SetFocus(txtFgID);
                            return false;
                        }

                        for (int k = 0; k < spdLotList.ActiveSheet.RowCount; k++)
                        {
                            if (MPCF.Trim(txtFgID.Text) == spdLotList.ActiveSheet.Cells[k, (int)LOT_LIST.FG_ID].Text)
                            {
                                MPCF.ShowErrorMessage("동일한 FG ID가 이미 추가 되어 있습니다.");
                                txtFgID.Text = "";
                                MPCF.SetFocus(txtFgID);
                                return false;
                            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewLotInfo(txtFgID.Text) == false)
                {
                    MPCF.SetFocus(txtFgID);
                    return;
                }

                MPCF.SetFocus(txtFgID);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void frmCUSTranFGMaterialAdapt_Load(object sender, EventArgs e)
        {
            MPCF.ConvertCaption(this);

            MPCF.ClearList(spdLotList);

			SetupPrtOpt();
        }

		private void SetupPrtOpt()
		{
			this.printOption = new PrintOptionModel();
			if (MPCF.GetPrintOptionFromReg(ref this.printOption, null) == false)
			{
				return;
			}
		}

        private void txtFgID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER && MPCF.Trim(txtFgID.Text) != "")
                {
                    txtFgID.Text = MPCF.ToUpper(txtFgID.Text); // 일괄 대문자

                    if (ViewLotInfo(txtFgID.Text) == false)
                    {
                        MPCF.SetFocus(txtFgID);
                        return;
                    }

                    txtFgID.Text = "";
                    MPCF.SetFocus(txtFgID);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void frmCUSTranFGMaterialAdapt_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                bIsShown = true;

                MPCF.SetFocus(txtFgID);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("PROCESS") == false)
                    return;

                if (Tran_Material_Change() == true)
                {
                    cdvMatID.Text = "";
                    txtMatDesc.Text = "";
                    MPCF.ClearList(spdLotList);
                    MPCF.SetFocus(txtFgID);
                    txtFgID.Text = "";
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvMatID_CodeViewButtonClick(object sender, EventArgs e)
        {
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;

            try
            {
                sViewID = "VIEW_MAT_LIST_2";

                ArrDVC = new TPDR.DirectViewCond[2];

                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$MAT_ID";

                if (string.IsNullOrEmpty(cdvMatID.Text) == false)
                    ArrDVC[1].sCondition_Value = MPCF.Trim(this.cdvMatID.Text) + "%";
                else
                    ArrDVC[1].sCondition_Value = "%";

                // CodeView Column Header Setup
                string[] header = new string[] { "Material ID", "Material Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "MAT_ID", "MAT_DESC" };

                // Show by RPTServer
                cdvMatID.Text = cdvMatID.Show(cdvMatID, "Material List", sViewID, ArrDVC, display, header, "MAT_ID", -1);

                if (cdvMatID.returnDatas != null && cdvMatID.returnDatas.Count > 0)
                {
                    cdvMatID.Text = cdvMatID.returnDatas[0];
                    txtMatDesc.Text = cdvMatID.returnDatas[1];
                }
                else
                {
                    cdvMatID.Text = string.Empty;
                    txtMatDesc.Text = string.Empty;
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
            txtFgID.Text = "";
            cdvMatID.Text = "";
            //txtComment.Text = "";
            txtMatDesc.Text = "";
            MPCF.ClearList(spdLotList);
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
    }
}
