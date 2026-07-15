//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmCUSTranEndLot.cs
//   Description :
//
//   MES Version : 5.3.5.0
//
//   Function List
//       - 
//
//   Detail Description
//       -
//
//   Use Service Module
//      Service
//       - 
//      Query
//       - 
//       - 
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2017-08-09 : Created by bkwoo
//
//
//   Copyright(C) 1998-2017 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using BOI.OIFrx;
using BOI.OIFrx.BOIBaseForm;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.DNM;
using SOI.CliFrx;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using BOI.OIFrx.BOIControls;

namespace SOI.Solar
{
    public partial class frmCUSTranEndLot : BOIBaseForm02
    {
        #region [Property]

        const int ENTER = 13;

        #endregion

        public frmCUSTranEndLot()
        {
            InitializeComponent();
        }

        #region [Constant Definition]

        private enum LOT_COL : int
        {
			LAST_TRAN_TIME,
			FG_ID,
            LOT_ID,
            MAT_ID,
            MAT_DESC,
            QTY_1,
            UNIT_1,
            OPER,
            OPER_DESC,
            ORDER_ID,
            STARTUS,
        }

        #endregion

        #region [Variable Definition]

        private MenuInfoTag menuInfo;
        private frmPrintOptionPopup frmOption;
        public PrintOptionModel printOption;
        private bool c_plc_flag;
        private char s_Print_Type;
        private char s_Print_step;
        private int  i_ng_cnt;
        private string s_Print_design;
        private bool b_load_flag = false;
        private string s_label = string.Empty;
        private string s_label_info = string.Empty;

        #endregion

        private void frmCUSTranEndLot_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvLine.Tag", MPCF.Trim(cdvLine.Tag));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvLine.Text", MPCF.Trim(cdvLine.Text));

                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvOper.Tag", MPCF.Trim(cdvOper.Tag));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvOper.Text", MPCF.Trim(cdvOper.Text));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "txtOperDesc.Text", MPCF.Trim(txtOperDesc.Text));

                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvResID.Tag", MPCF.Trim(cdvResID.Tag));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvResID.Text", MPCF.Trim(cdvResID.Text));
                MPCF.SaveRegSetting(Application.ProductName, this.Name, "txtResDesc.Text", MPCF.Trim(txtResDesc.Text));
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
            }
        }

        #region [FormDefinition]


        #endregion

        #region [Function Definition]

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
                    MPCF.ClearList(spdOrderInfo);
                    MPCF.ClearList(spdLotList);
                    txtLotID.Text = string.Empty;
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
                    case "PROCESS":

                        if (string.IsNullOrEmpty(cdvOper.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Oper]"));
                            MPCF.SetFocus(cdvOper);
                            return false;
                        }

                        if (string.IsNullOrEmpty(cdvResID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Res ID]"));
                            MPCF.SetFocus(cdvResID);
                            return false;
                        }
                       
                        if (string.IsNullOrEmpty(txtLotID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Lot ID]"));
                            MPCF.SetFocus(txtLotID);
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

        /// <summary>
        /// View Lot
        /// </summary>
        /// <param name="sLotID"></param>
        /// <returns></returns>
        private bool Tran_End_Lot(string sLotID)
        {
            s_Print_design = string.Empty;

            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("OPER", MPCF.Trim(cdvOper.Text));

                if (c_plc_flag == true)
                {
                    in_node.AddChar("PLC_FLAG", 'Y');

                    if (rdbOK.Checked)
                        in_node.AddString("RESULT", "OK");
                    else if (rdbNG.Checked)
                        in_node.AddString("RESULT", "NG");
                }

                if (MPCF.CallService("CUS", "CWIP_End_lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                if (spdLotList.ActiveSheet.RowCount > 200) MPCF.ClearList(spdLotList);

                //JIG로 스캔이 되어도 처리후 LOT ID로 변경
                txtLotID.Text = out_node.GetString("LOT_ID");

                //종료 진행 LOT 리스트에 추가
                spdLotList.ActiveSheet.AddRows(0, 1);
                spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.FG_ID].Text = out_node.GetString("PROD_LOT_ID");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.LOT_ID].Text = out_node.GetString("LOT_ID");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.MAT_ID].Text = out_node.GetString("MAT_ID");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.MAT_DESC].Text = out_node.GetString("MAT_DESC");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.QTY_1].Text = out_node.GetDouble("QTY_1").ToString();
                spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.UNIT_1].Text = out_node.GetString("UNIT_1");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.OPER].Text = out_node.GetString("OPER");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.OPER_DESC].Text = out_node.GetString("OPER_DESC");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.ORDER_ID].Text = out_node.GetString("ORDER_ID");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.STARTUS].Text = out_node.GetString("LOT_STATUS");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.LAST_TRAN_TIME].Text = MPCF.MakeDateFormat(out_node.GetString("LAST_TRAN_TIME"));                

                MPCF.FitColumnHeader(spdLotList);

                spdLotList.ActiveSheet.Columns[(int)LOT_COL.MAT_DESC].Width = 250;

                btnPrint.Visible = false;
                chkPrintFlag.Visible = false;

                //완제품 라벨 프린트할 공정일 경우
                if (out_node.GetChar("FG_LABEL_FLAG") == 'Y')
                {
                    btnPrint.Visible = true;
                    chkPrintFlag.Visible = true;

                    s_Print_design = out_node.GetString("PRINT_DESIGN");

                    //OEM일 경우 패스
                    if (string.IsNullOrEmpty(s_Print_design) == true)
                    {
                        return false;
                    }

					ProcPrint('O', s_Print_design, sLotID);
                }
                else if (out_node.GetChar("INNER_LABEL_FLAG") == 'Y')
                {
                    btnPrint.Visible = true;
                    chkPrintFlag.Visible = true;

                    string s_time = out_node.GetString("CREATE_TIME");

                    s_time = s_time.Substring(0, 4) + "-" + s_time.Substring(4, 2) + "-" + s_time.Substring(6, 2) + " " + s_time.Substring(8, 2) + ":" + s_time.Substring(10, 2);

                    s_label = out_node.GetString("LOT_ID") + "[" + out_node.GetString("JIG_ID") + "] " + s_time;
                    s_label_info = out_node.GetString("RES_ID") + "-" + out_node.GetString("MODEL") + "-" + out_node.GetString("MAT_CMF_10") + out_node.GetString("MAT_CMF_6");
                    s_label_info = s_label_info + "-" + out_node.GetString("WORK_TIME_SHIFT") + "-" + out_node.GetInt("PROD_SEQ").ToString("0000");

					ProcPrint('I', string.Empty, sLotID);
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
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

        private bool GetLabelInfo(string sLotID, ref DataTable dt)
        {
            try
            {
                int i_cond_cnt;
                string sViewID;
                //DataTable dt = new DataTable();

                i_cond_cnt = 2;
                sViewID = "VIEW_INNER_LABEL";

                TPDR.DirectViewCond[] arr = new TPDR.DirectViewCond[i_cond_cnt];

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

        private bool ProcPrint(char cStep, string sDesign, string sLotID)
        {
            TRSNode out_node = new TRSNode("OUT_NODE");
            string sScreenID = string.Empty;
            DataTable dt = new DataTable();

            try
            {
                s_Print_step = cStep;

                if (cStep == 'I')
                {
                    udcPrint.InitFlexibleScreen();
                    udcPrint.ScreenID = "CWIPProcessLabel_05";
                    udcPrint.ScreenSpread.Tag = "CWIPProcessLabel_05";
                    udcPrint.ProcStep = '1';
                    udcPrint.LotID = "CWIPProcessLabel_05";
                    udcPrint.LoadDesign();

                    //out_node.SetString("LOT_ID", txtLotID.Text);
					out_node.SetString("LOT_ID", sLotID);

                    //재발행일경우
                    if (sDesign == "RE")
                    {
                        //if (GetLabelInfo(MPCF.Trim(this.txtLotID.Text), ref dt) == false)
						if (GetLabelInfo(MPCF.Trim(sLotID), ref dt) == false)
                        {
                            return false;
                        }

                        string s_time = dt.Rows[0]["CREATE_TIME"].ToString();
                        string s_seq = dt.Rows[0]["PROD_SEQ"].ToString();

                        out_node.SetString("LOT_ID", dt.Rows[0]["LOT_ID"].ToString());
                        s_time = s_time.Substring(0, 4) + "-" + s_time.Substring(4, 2) + "-" + s_time.Substring(6, 2) + " " + s_time.Substring(8, 2) + ":" + s_time.Substring(10, 2);

                        s_label = dt.Rows[0]["LOT_ID"].ToString() + "[" + dt.Rows[0]["JIG_ID"].ToString() + "] " + s_time;
                        s_label_info = dt.Rows[0]["RES_ID"].ToString() + "-" + dt.Rows[0]["MODEL"].ToString() + "-" + dt.Rows[0]["MAT_CMF_10"].ToString() + dt.Rows[0]["MAT_CMF_6"].ToString();
                        s_label_info = s_label_info + "-" + dt.Rows[0]["WORK_TIME_SHIFT"].ToString() + "-" + s_seq.PadLeft(4, '0');

                        out_node.SetString("LOT_ID_TIME", s_label);
                        out_node.SetString("LOT_INFO", s_label_info);
                    }
                    else
                    {
                        out_node.SetString("LOT_ID_TIME", s_label);
                        out_node.SetString("LOT_INFO", s_label_info);
                    }

                    if (udcPrint.SetDataToScreen(out_node) == false) return false;

                    MPCF.PrintFlexibleScreen(this, this.printOption, udcPrint, true);
                }
                else if (cStep == 'O')
                {
                    if (GetMatInfoOfLot(MPCF.Trim(this.txtLotID.Text), ref dt) == false)
                    {
                        return false;
                    }
                    if (dt.Rows.Count < 1)
                    {
                        return false;
                    }

                    sScreenID = sDesign;

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
                }                

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            finally
            {
                this.txtLotID.Focus();
                this.txtLotID.SelectAll();
            }
        }

        /// <summary>
        /// View Order
        /// </summary>
        /// <returns></returns>
        private bool ViewOrder()
        {
            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            MPCF.ClearList(spdOrderInfo);

            try
            {
                ArrDVC = new TPDR.DirectViewCond[2];

                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$RES_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(cdvResID.Text);

                if (TPDR.DirectViewOne(this.spdOrderInfo, "VIEW_ORDER_INFO", ref dt, ArrDVC) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }
                MPCF.FitColumnHeader(spdOrderInfo);

                return false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// View Order
        /// </summary>
        /// <returns></returns>
        private bool ViewLotLabel()
        {
            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            MPCF.ClearList(spdOrderInfo);

            try
            {
                ArrDVC = new TPDR.DirectViewCond[2];

                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$OPER";
                ArrDVC[1].sCondition_Value = MPCF.Trim(cdvOper.Text);

                //내부라벨
                if (s_Print_Type == 'I')
                {
                    if (TPDR.DirectViewOne(null, "VIEW_PRINT_LOT_INFO", ref dt, false, false, ArrDVC, true) == false)
                    {
                        if (dt != null) { dt.Dispose(); }
                        GC.Collect();

                        return false;
                    }
                
                    txtLotID.Text = dt.Rows[0]["LOT_ID"].ToString();
					string sTmpLotID = txtLotID.Text;

                    //if (string.IsNullOrEmpty(txtLotID.Text) == true)
					if (string.IsNullOrEmpty(sTmpLotID) == true)
                    {
                        return false;
                    }

					if (ProcPrint(s_Print_Type, "RE", sTmpLotID) == true)
                    {
						Tran_PrintLot_Delete(sTmpLotID);
                    }
                }
                //외부라벨
                else if (s_Print_Type == 'O')
                {
                    if (TPDR.DirectViewOne(null, "VIEW_PRINT_LOT_INFO_3", ref dt, false, false, ArrDVC, true) == false)
                    {
                        if (dt != null) { dt.Dispose(); }
                        GC.Collect();

                        return false;
                    }

					txtLotID.Text = dt.Rows[0]["LOT_ID"].ToString();
					string sTmpLotID = txtLotID.Text;
                    s_Print_design = dt.Rows[0]["DESIGN"].ToString();

                    if (string.IsNullOrEmpty(txtLotID.Text) == true)
                    {
                        return false;
                    }

                    i_ng_cnt = 0;

                    //검사 공장 NG 체크
                    ArrDVC[0].sCondtion_ID = "$FACTORY";
                    ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                    ArrDVC[1].sCondtion_ID = "$LOT_ID";
                    ArrDVC[1].sCondition_Value = MPCF.Trim(txtLotID.Text);

                    if (TPDR.DirectViewOne(null, "VIEW_LOT_NG_CHECK", ref dt, ArrDVC) == false)
                    {
                        if (dt != null) { dt.Dispose(); }
                        GC.Collect();
                        return false;
                    }

                    i_ng_cnt = MPCF.ToInt(dt.Rows[0]["NG_CNT"].ToString());

                    if (i_ng_cnt > 0)
                    {
						Tran_PrintLot_Delete(sTmpLotID);
                        MPCF.ShowMessage("해당 Lot은 NG검사 결과가 존재합니다.", MSG_LEVEL.ERROR, false);
                         return true;
                    }

                    //OEM일 경우 패스
                    if (string.IsNullOrEmpty(s_Print_design) == true)
                    {
                        return false;
                    }

					Tran_PrintLot_Delete(sTmpLotID);
                    
                }

                return false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool Tran_PrintLot_Delete(string sLotID)
        {
            try
            {
                string sTransOrderID = string.Empty;
                TRSNode in_node = new TRSNode("TRANSFER_IN");
                TRSNode out_node = new TRSNode("TRANSFER_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                //in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
				in_node.AddString("LOT_ID", MPCF.Trim(sLotID));
                in_node.AddString("OPER", MPCF.Trim(cdvOper.Text));
				in_node.AddString("OKNG", i_ng_cnt == 0 ? "Y" : "N");

                if (MPCF.CallService("CUS", "CWIP_Tran_Label_Matching", in_node, ref out_node) == false)
                {
                    return false;
                }

				//최신 이력은 20개 까지만 유지
				int spdLotListMaxRowCnt = 20;
				if (spdLotList.ActiveSheet.RowCount > spdLotListMaxRowCnt)
				{
					for (int i = spdLotList.ActiveSheet.RowCount - 1; i >= spdLotListMaxRowCnt; i--)
					{
						spdLotList.ActiveSheet.Rows[i].Remove();
					}
				}

                spdLotList.ActiveSheet.AddRows(0, 1);
				spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.LAST_TRAN_TIME].Text = MPCF.MakeDateFormat(out_node.GetString("LAST_TRAN_TIME"));
				spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.FG_ID].Text = out_node.GetString("FG_ID");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.LOT_ID].Text = out_node.GetString("LOT_ID");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.MAT_ID].Text = out_node.GetString("MAT_ID");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.MAT_DESC].Text = out_node.GetString("MAT_DESC");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.QTY_1].Text = out_node.GetDouble("QTY_1").ToString();
                spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.UNIT_1].Text = out_node.GetString("UNIT_1");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.OPER].Text = out_node.GetString("OPER");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.OPER_DESC].Text = out_node.GetString("OPER_DESC");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.ORDER_ID].Text = out_node.GetString("ORDER_ID");
                spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.STARTUS].Text = out_node.GetString("LOT_STATUS");

                MPCF.FitColumnHeader(spdLotList);

                spdLotList.ActiveSheet.Columns[(int)LOT_COL.MAT_DESC].Width = 200f;

                if (s_Print_Type == 'O' && out_node.GetChar("PRINT_FLAG") == 'Y' && i_ng_cnt == 0)
                {
					ProcPrint(s_Print_Type, s_Print_design, sLotID);
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }


        /// <summary>
        /// View Order
        /// </summary>
        /// <returns></returns>
        private bool ViewLotInfo()
        {
            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            try
            {
                ArrDVC = new TPDR.DirectViewCond[2];

                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$LOT_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(txtLotID.Text);

                if (TPDR.DirectViewOne(null, "VIEW_LOT_ORDER", ref dt, ArrDVC) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }


                if (dt.Rows.Count > 0)
                {
                    s_Print_design = dt.Rows[0]["DESIGN"].ToString();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// View Order
        /// </summary>
        /// <returns></returns>
        private bool ViewLotOrder(string sOrderID)
        {
            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            MPCF.ClearList(spdOrderInfo);

            try
            {
                ArrDVC = new TPDR.DirectViewCond[2];

                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$ORDER_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(sOrderID);

                if (TPDR.DirectViewOne(this.spdOrderInfo, "VIEW_ORDER_INFO_02", ref dt, ArrDVC) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }
                MPCF.FitColumnHeader(spdOrderInfo);

                return false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

		private void View_End_Lot_List()
		{
			try
			{
				int i_cond_cnt;
				string sViewID;
				DataTable dt = new DataTable();

				MPCF.ClearList(spdLotList);

				i_cond_cnt = 3;
				sViewID = "VIEW_END_LOT_LIST";

				TPDR.DirectViewCond[] arr = new TPDR.DirectViewCond[i_cond_cnt];

				arr[0].sCondtion_ID = "$FACTORY";
				arr[0].sCondition_Value = MPGV.gsFactory;

				arr[1].sCondtion_ID = "$OPER";
				arr[1].sCondition_Value = MPCF.Trim(cdvOper.Text);

				arr[2].sCondtion_ID = "$TRAN_CODE";
				arr[2].sCondition_Value = MPCF.Trim("END");

				if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, arr, true) == false)
				{
					if (dt != null) { dt.Dispose(); }
					GC.Collect();
				}

				for (int k = 0; k < dt.Rows.Count; k++)
				{
					spdLotList.ActiveSheet.AddRows(0, 1);
					spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.LAST_TRAN_TIME].Text = MPCF.MakeDateFormat(dt.Rows[k]["LAST_TRAN_TIME"].ToString());
					spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.FG_ID].Text = dt.Rows[k]["FG_ID"].ToString();
					spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.LOT_ID].Text = dt.Rows[k]["LOT_ID"].ToString();
					spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.MAT_ID].Text = dt.Rows[k]["MAT_ID"].ToString();
					spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.MAT_DESC].Text = dt.Rows[k]["MAT_DESC"].ToString();
					spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.QTY_1].Text = dt.Rows[k]["QTY_1"].ToString();
					spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.UNIT_1].Text = dt.Rows[k]["UNIT_1"].ToString();
					spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.OPER].Text = dt.Rows[k]["OPER"].ToString();
					spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.OPER_DESC].Text = dt.Rows[k]["OPER_DESC"].ToString();
					spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.ORDER_ID].Text = dt.Rows[k]["ORDER_ID"].ToString();
					spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.STARTUS].Text = dt.Rows[k]["LOT_STATUS"].ToString();
				}

				MPCF.FitColumnHeader(spdLotList);

				spdLotList.ActiveSheet.Columns[(int)LOT_COL.MAT_DESC].Width = 200f;
			}
			catch (Exception ex)
			{
				MPCF.ShowMsgBox(ex.Message);
			}
		}

        #endregion

        #region [Event Definition]

        private void frmCUSTranEndLot_Load(object sender, EventArgs e)
        {
            try
            {
                MPCF.ConvertCaption(this);

                MPCF.ClearList(spdOrderInfo);
                MPCF.ClearList(spdLotList);

                cdvLine.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvLine.Text"));
                cdvLine.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvLine.Text"));
                cdvOper.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvOper.Text"));
                cdvOper.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvOper.Text"));
                txtOperDesc.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "txtOperDesc.Text"));
                cdvResID.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvResID.Tag"));
                cdvResID.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvResID.Text"));
                txtResDesc.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "txtResDesc.Text"));

                SetupPrtOpt();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
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
                    txtOperDesc.Text = string.Empty;
                }

                if (b_load_flag == false)
                {
                    cdvResID.Text = "";
                    txtResDesc.Text = "";
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvResID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                ClearData("1");                

                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$OPER";
                dvcArgu[1].sCondition_Value = cdvOper.Tag;

                // CodeView Column Header Setup
                string[] header = new string[] { "Code", "Code Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                // Show
                cdvResID.Text = cdvResID.Show(cdvResID, "Code Desc", "VIEW_MFO_RES_LIST", dvcArgu, display, header, "RES_ID", -1);

                if (MPCF.Trim(cdvResID.Text) != "")
                {
                    if (cdvResID.returnDatas != null && cdvResID.returnDatas.Count > 0)
                    {
                        cdvResID.Tag = cdvResID.returnDatas[0];
                        cdvResID.Text = cdvResID.returnDatas[0];
                        txtResDesc.Text = cdvResID.returnDatas[1];
                    }
                }
                else
                {
                    cdvResID.Tag = "";
                    txtResDesc.Text = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

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

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER && MPCF.Trim(txtLotID.Text) != "")
                {
                    txtLotID.Text = MPCF.ToUpper(txtLotID.Text); // 일괄 대문자

                    if (Tran_End_Lot(txtLotID.Text.ToUpper()) == false)
                    {
                        txtLotID.Text = "";
                        MPCF.SetFocus(txtLotID);
                        return;
                    }

                    txtLotID.Text = "";
                    MPCF.SetFocus(txtLotID);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(spdLotList);
            txtLotID.Text = string.Empty;
            MPCF.SetFocus(txtLotID);
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

        #endregion        

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (!CheckCondition("PROCESS"))
                return;

            if (Tran_End_Lot(txtLotID.Text.ToUpper()) == false)
            {
                txtLotID.Text = "";
                MPCF.SetFocus(txtLotID);
                return;
            }            

            txtLotID.Text = "";
            MPCF.SetFocus(txtLotID);
        }

        private void cdvOper_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = null;
                string s_sql = "";

                if(string.IsNullOrEmpty(cdvOper.Text) == false)
                {
                    TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                    dvcArgu[0].sCondtion_ID = "$FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    dvcArgu[1].sCondtion_ID = "$OPER";
                    dvcArgu[1].sCondition_Value = cdvOper.Text;

                    // CodeView Column Header Setup
                    string[] header = new string[] { "Code", "Code Desc" };

                    // CodeView Display Column Setup
                    string[] display = new string[] { "RES_ID", "RES_DESC" };

                    if (TPDR.GetDataOne("", ref dt, "VIEW_MFO_RES_LIST", dvcArgu, false, false, ref s_sql) == false)
                    {
                        if (dt != null)
                            dt.Dispose();

                        GC.Collect();
                        return;
                    }

                    b_load_flag = false;

                    if(dt.Rows.Count == 1)
                    {
                        cdvResID.Tag = dt.Rows[0]["RES_ID"];
                        cdvResID.Text = dt.Rows[0]["RES_ID"].ToString();
                        txtResDesc.Text = dt.Rows[0]["RES_DESC"].ToString();

                        b_load_flag = true;
                    }

                    btnPrint.Visible = false;
                    chkPrintFlag.Visible = false;
                    rdbOK.Visible = false;
                    rdbNG.Visible = false;
                    c_plc_flag = false;
                    trmPrint.Stop();

                    //해당 공정의 옵션 내용 조회
                    if (TPDR.GetDataOne("", ref dt, "VIEW_OPTION_LIST", dvcArgu, false, false, ref s_sql) == false)
                    {
                        if (dt != null)
                            dt.Dispose();

                        GC.Collect();
                        return;
                    }

                    if (dt.Rows.Count > 0)
                    {
                        for(int k =0; k< dt.Rows.Count; k ++)
                        {
                            if (dt.Rows[k]["OPTION_NAME"].ToString() == "SEM_OPTION")
                            {
                                //PLC OK/NG 신호로 처리 되는 공정일 경우
                                if (dt.Rows[k]["DATA_2"].ToString() == "Y")
                                {
                                    c_plc_flag = true;
                                    rdbOK.Text = "OK";
                                    rdbOK.Visible = true;
                                    rdbNG.Visible = true;
                                }
                            }

                            if (dt.Rows[k]["OPTION_NAME"].ToString() == "PRINT_OPTION")
                            {
                                //내부라벨이나 외부라벨 프린트하는 공정일 경우
                                if (dt.Rows[k]["DATA_1"].ToString() == "Y" || dt.Rows[k]["DATA_2"].ToString() == "Y")
                                {
                                    if (dt.Rows[k]["DATA_1"].ToString() == "Y")
                                    {
                                        //내부라벨
                                        s_Print_Type = 'I';
                                    }
                                    else if (dt.Rows[k]["DATA_2"].ToString() == "Y")
                                    {
                                        //외부라벨
                                        s_Print_Type = 'O';
                                    }

                                    if (dt.Rows[k]["DATA_3"].ToString() == "END")
                                    {
                                        btnPrint.Visible = true;
                                        chkPrintFlag.Visible = true;
                                    }

									if(cdvResID.Text == BIGV.gsResId)
									{
										trmPrint.Start();
									}
                                }
                            }
                        }                        
                    }                    
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
				string sTmpLotID = txtLotID.Text;

                //EL종료일 경우 완제품 라벨 발행
                if (s_Print_Type == 'O')
                {
					if (string.IsNullOrEmpty(sTmpLotID) == false)
                    {
                        ViewLotInfo();
                    }

                    //OEM일 경우 패스
                    if (string.IsNullOrEmpty(s_Print_design) == true)
                    {
                        return;
                    }

					ProcPrint(s_Print_Type, s_Print_design, sTmpLotID);
                }
                else if (s_Print_Type == 'I')
                {
					ProcPrint(s_Print_Type, "RE", sTmpLotID);
                }

				txtLotID.Text = "";
                MPCF.SetFocus(txtLotID);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdLotList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (spdLotList.ActiveSheet.RowCount == 0) return;

                txtLotID.Text = spdLotList.ActiveSheet.Cells[e.Row, (int)LOT_COL.LOT_ID].Text;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void SetupPrtOpt()
        {
            this.printOption = new PrintOptionModel();
            if (MPCF.GetPrintOptionFromReg(ref this.printOption, null) == false)
            {
                return;
            }
        }

        private void btnLossRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLotID.Text) == false)
                {
                    MPGV.gsCurrentLot_ID = txtLotID.Text;
                }

                BICF.OpenMenu("SOI2022");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }            
        }

        private void btnDefectLotInput_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLotID.Text) == false)
                {
                    MPGV.gsCurrentLot_ID = txtLotID.Text;
                }

                BICF.OpenMenu("SOI2016");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            } 
        }

        private void trmPrint_Tick(object sender, EventArgs e)
        {
            if (chkPrintFlag.Checked)
            {
                if (string.IsNullOrEmpty(cdvOper.Text) == true)
                {
                    return;
                }

                if (string.IsNullOrEmpty(cdvResID.Text) == true)
                {
                    return;
                }

                txtLotID.Text = "";

				trmPrint.Stop();

                ViewLotLabel();

				trmPrint.Start();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            View_End_Lot_List();
			txtLotID.Text = "";

			MPCF.SetFocus(txtLotID);
        }
    }
}
