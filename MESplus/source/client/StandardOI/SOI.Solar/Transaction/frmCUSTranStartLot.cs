//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmCUSTranStartLot.cs
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
    public partial class frmCUSTranStartLot : BOIBaseForm02
    {
        #region [Property]

        const int ENTER = 13;

        #endregion

        public frmCUSTranStartLot()
        {
            InitializeComponent();
        }

        #region H101 Module

        private H101Tuner h101tuner = new H101Tuner();
        private delegate void H101DataReceived(TRSNode node);
        private H101DataReceived h101DataRecevied;

        private void h101tuner_DataReceived(object sender, H101DataReceivedEventArgs e)
        {
            IAsyncResult r = BeginInvoke(h101DataRecevied, e.Node);
            EndInvoke(r);
        }

        private void OnH101DataReceived(TRSNode node)
        {
            try
            {
                if (node.GetString("_SERVICE_NAME") == "CUS_Proc_Lot_tcp")
                {
                    if (string.IsNullOrEmpty(cdvLine.Text) == true)
                    {
                        cdvLine.Text = "01";
                    }
                    cdvOper.Text = node.GetString("OPER");
                    cdvResID.Text = node.GetString("RES_ID");
                    cdvOper.Tag = node.GetString("OPER");
                    cdvResID.Tag = node.GetString("RES_ID");
                    txtLotID.Text = node.GetString("LOT_ID");
                    txtOperDesc.Text = node.GetString("OPER_DESC");
                    txtResDesc.Text = node.GetString("RES_DESC");

                    //오더 정보 조회
                    ViewLotOrder(node.GetString("ORDER_ID"));

                    //시작 진행 LOT 리스트에 추가
                    spdLotList.ActiveSheet.AddRows(0, 1);
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.LOT_ID].Text = node.GetString("LOT_ID");
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.MAT_ID].Text = node.GetString("MAT_ID");
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.MAT_DESC].Text = node.GetString("MAT_DESC");
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.QTY_1].Text = node.GetDouble("QTY_1").ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.UNIT_1].Text = node.GetString("UNIT_1");
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.OPER].Text = node.GetString("OPER");
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.OPER_DESC].Text = node.GetString("OPER_DESC");
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.ORDER_ID].Text = node.GetString("ORDER_ID");
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.STARTUS].Text = node.GetString("LOT_STARTUS");
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.LAST_TRAN_TIME].Text = MPCF.MakeDateFormat(node.GetString("LAST_TRAN_TIME"));

                    MPCF.FitColumnHeader(spdLotList);

                    btnPrint.Visible = false;
                    chkPrintFlag.Visible = false;

					string sTmpLotID = spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.LOT_ID].Text;

					if(string.IsNullOrEmpty(sTmpLotID) == true)
					{
						return;
					}

                    if (node.GetChar("INNER_LABEL_FLAG") == 'Y')
                    {
                        btnPrint.Visible = true;
                        chkPrintFlag.Visible = true;

                        if (chkPrintFlag.Checked)
                        {
                            ProcPrint('I', "RE", sTmpLotID);
                        }
                    }
                    else if (node.GetChar("FG_LABEL_FLAG") == 'Y')
                    {
                        btnPrint.Visible = true;
                        chkPrintFlag.Visible = true;

                        s_Print_type = node.GetString("PRINT_TYPE");
                        s_Print_design = node.GetString("PRINT_DESIGN");

                        //OEM일 경우 패스
                        if (string.IsNullOrEmpty(s_Print_design) == true)
                        {
                            return;
                        }

                        if (chkPrintFlag.Checked)
                        {
							ProcPrint('0', s_Print_design, sTmpLotID);
                        }
                    }

                    MPCF.SetFocus(txtLotID);
                    txtLotID.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
            }
        }

        private void frmCUSTranStartLot_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (h101tuner.isTuned == true)
            {
                h101tuner.PublishCUSMsgUnTune();
                h101tuner.Dispose();
            }

            MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvLine.Text", MPCF.Trim(cdvLine.Text));
            MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvOper.Text", MPCF.Trim(cdvOper.Text));
            MPCF.SaveRegSetting(Application.ProductName, this.Name, "txtOperDesc.Text", MPCF.Trim(txtOperDesc.Text));
            MPCF.SaveRegSetting(Application.ProductName, this.Name, "cdvResID.Text", MPCF.Trim(cdvResID.Text));
            MPCF.SaveRegSetting(Application.ProductName, this.Name, "txtResDesc.Text", MPCF.Trim(txtResDesc.Text));
        }

        private void InitH101Tuner()
        {
            try
            {
                if (h101tuner.isTuned == true)
                {
                    return;
                }

                string module = string.Empty;
                string channel = string.Empty;

                channel = BIGV.gsResId;

                h101DataRecevied += new H101DataReceived(OnH101DataReceived);
                h101tuner.DataReceived += new H101DataReceivedEventHandler(h101tuner_DataReceived);
                h101tuner.Module = "SOL";
                h101tuner.Channel = channel;
                h101tuner.MultiCast = true;
                h101tuner.UseRandomChannel = false;
                h101tuner.PublishCUSMsgTune();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
            }
        }

        #endregion

        #region [Constant Definition]

        private enum LOT_COL : int
        {
			LAST_TRAN_TIME,
            LOT_ID,
            MAT_ID,
            MAT_DESC,
            QTY_1,
            UNIT_1,
            OPER,
            OPER_DESC,
            ORDER_ID,
            STARTUS
        } 

        #endregion

        #region [Variable Definition]
        
        private MenuInfoTag menuInfo;
        private frmPrintOptionPopup frmOption;
        public PrintOptionModel printOption;
        private char s_Print_step;
        private char s_Print_Type;
        private string s_Print_type;
        private string s_Print_design;
        private bool b_load_flag = false;
        private string s_label = string.Empty;
        private string s_label_info = string.Empty;

        #endregion

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

        /// <summary>
        /// View Lot
        /// </summary>
        /// <param name="sLotID"></param>
        /// <returns></returns>
        private bool Tran_Start_Lot(string sLotID)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("OPER", MPCF.Trim(cdvOper.Text));

                if (MPCF.CallService("CUS", "CWIP_Start_lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                if (spdLotList.ActiveSheet.RowCount > 200) MPCF.ClearList(spdLotList);

                //JIG로 스캔이 되어도 처리후 LOT ID로 변경
                txtLotID.Text = out_node.GetString("LOT_ID");

                //시작 진행 LOT 리스트에 추가
                spdLotList.ActiveSheet.AddRows(0, 1);
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
				spdLotList.ActiveSheet.Columns[(int)LOT_COL.LAST_TRAN_TIME].Width = 230;

                btnPrint.Visible = false;
                chkPrintFlag.Visible = false;

				string sTmpLotId = out_node.GetString("LOT_ID");

                //완제품 라벨 프린트할 공정일 경우
                if (out_node.GetChar("FG_LABEL_FLAG") == 'Y')
                {
                    btnPrint.Visible = true;
                    chkPrintFlag.Visible = true;

                    s_Print_type = out_node.GetString("PRINT_TYPE");
                    s_Print_design = out_node.GetString("PRINT_DESIGN");

                    //OEM일 경우 패스
                    if (string.IsNullOrEmpty(s_Print_design) == true)
                    {
                        return false;
                    }

					ProcPrint('O', s_Print_design, sTmpLotId);

                }
                else if (out_node.GetChar("INNER_LABEL_FLAG") == 'Y')
                {
                    btnPrint.Visible = true;
                    chkPrintFlag.Visible = true;

                    string s_time = out_node.GetString("CREATE_TIME");

                    s_time = s_time.Substring(0, 4) + "-" + s_time.Substring(4, 2) + "-" + s_time.Substring(6, 2) + " " + s_time.Substring(8, 2) + ":" + s_time.Substring(10, 2);

                    s_label = out_node.GetString("LOT_ID") + "[" + out_node.GetString("JIG_ID") + "] " + s_time;
                    //s_label_info = out_node.GetString("RES_ID") + "-" + out_node.GetString("MODEL") + "-" + out_node.GetString("MAT_CMF_10") + out_node.GetString("MAT_CMF_6");
					s_label_info = out_node.GetString("RES_ID") + "-" + out_node.GetString("MODEL") + "-" + out_node.GetString("MAT_CMF_6") + out_node.GetString("MAT_CMF_7") + "-" + out_node.GetString("MAT_CMF_10").PadLeft(2,'0');
                    s_label_info = s_label_info + "-" + out_node.GetString("WORK_TIME_SHIFT") + "-" + out_node.GetInt("PROD_SEQ").ToString("0000");

					ProcPrint('I', string.Empty, sTmpLotId);
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
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
				in_node.AddString("LOT_ID", MPCF.Trim(sLotID));
                in_node.AddString("OPER", MPCF.Trim(cdvOper.Text));

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
				spdLotList.ActiveSheet.Columns[(int)LOT_COL.LAST_TRAN_TIME].Width = 230;

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

                if (TPDR.DirectViewOne(null, "VIEW_PRINT_LOT_INFO", ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                //내부라벨
				if (s_Print_Type == 'I')
				{
				    txtLotID.Text = dt.Rows[0]["LOT_ID"].ToString();
					//다른 쪽에서 txtLotID.Text를 지우는 경우가 있는 듯하여 임시 저장
					string sTmpLotID = txtLotID.Text;

					if (string.IsNullOrEmpty(sTmpLotID) == true)
				    {
				        return false;
				    }

					if (ProcPrint(s_Print_Type, "RE", sTmpLotID) == true)
				    {
						Tran_PrintLot_Delete(sTmpLotID);
				    }
				}

                return false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool GetMatInfoOfLot(string sLotID, ref DataTable dt)
        {
            try
            {
                int i_cond_cnt;
                string sViewID;
                //DataTable dt = new DataTable();

                i_cond_cnt = 2;
                sViewID = "VIEW_MAT_INFO_OF_LOT";

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

        private bool View_Strart_Lot_List()
        {
            try
            {
                int i_cond_cnt;
                string sViewID;
                DataTable dt = new DataTable();

                MPCF.ClearList(spdLotList);

                i_cond_cnt = 3;
                sViewID = "VIEW_START_LOT_LIST";

                TPDR.DirectViewCond[] arr = new TPDR.DirectViewCond[i_cond_cnt];

                arr[0].sCondtion_ID = "$FACTORY";
                arr[0].sCondition_Value = MPGV.gsFactory;

                arr[1].sCondtion_ID = "$OPER";
                arr[1].sCondition_Value = MPCF.Trim(cdvOper.Text);

                arr[2].sCondtion_ID = "$TRAN_CODE";
                arr[2].sCondition_Value = MPCF.Trim("START");

                if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, arr, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                for(int k = 0; k < dt.Rows.Count; k++)
                {
                    spdLotList.ActiveSheet.AddRows(0, 1);
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.LOT_ID].Text = dt.Rows[k]["LOT_ID"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.MAT_ID].Text = dt.Rows[k]["MAT_ID"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.MAT_DESC].Text = dt.Rows[k]["MAT_DESC"].ToString(); 
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.QTY_1].Text = dt.Rows[k]["QTY_1"].ToString(); 
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.UNIT_1].Text = dt.Rows[k]["UNIT_1"].ToString(); 
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.OPER].Text = dt.Rows[k]["OPER"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.OPER_DESC].Text = dt.Rows[k]["OPER_DESC"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.ORDER_ID].Text = dt.Rows[k]["ORDER_ID"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.STARTUS].Text = dt.Rows[k]["LOT_STATUS"].ToString();
                    spdLotList.ActiveSheet.Cells[0, (int)LOT_COL.LAST_TRAN_TIME].Text = dt.Rows[k]["LAST_TRAN_TIME"].ToString(); 
                }

				spdLotList.ActiveSheet.Columns[(int)LOT_COL.MAT_DESC].Width = 250;
				spdLotList.ActiveSheet.Columns[(int)LOT_COL.LAST_TRAN_TIME].Width = 230;

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

                //내부라벨
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
						if (GetLabelInfo(MPCF.Trim(sLotID), ref dt) == false)
                        {
                            return false;
                        }

                        string s_time = dt.Rows[0]["CREATE_TIME"].ToString();
                        string s_seq = dt.Rows[0]["PROD_SEQ"].ToString();

                        out_node.SetString("LOT_ID", dt.Rows[0]["LOT_ID"].ToString());
                        s_time = s_time.Substring(0, 4) + "-" + s_time.Substring(4, 2) + "-" + s_time.Substring(6, 2) + " " + s_time.Substring(8, 2) + ":" + s_time.Substring(10, 2);

                        s_label = dt.Rows[0]["LOT_ID"].ToString() + "[" + dt.Rows[0]["JIG_ID"].ToString() + "] " + s_time;
                        //s_label_info = dt.Rows[0]["RES_ID"].ToString() + "-" + dt.Rows[0]["MODEL"].ToString() + "-" + dt.Rows[0]["MAT_CMF_10"].ToString() + dt.Rows[0]["MAT_CMF_6"].ToString();
						s_label_info = dt.Rows[0]["RES_ID"].ToString() + "-" + dt.Rows[0]["MODEL"].ToString() + "-" +
										(dt.Columns.Contains("MAT_CMF_6") == true ? dt.Rows[0]["MAT_CMF_6"].ToString() : "") +
										(dt.Columns.Contains("MAT_CMF_7") == true ? dt.Rows[0]["MAT_CMF_7"].ToString() : "") +
										"-" +
										(dt.Columns.Contains("MAT_CMF_10") == true ? dt.Rows[0]["MAT_CMF_10"].ToString().PadLeft(2,'0') : "");
						
						//dt.Rows[0]["MAT_CMF_6"].ToString() + dt.Rows[0]["MAT_CMF_7"].ToString() + "-" + dt.Rows[0]["MAT_CMF_10"].ToString();
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
                //외부라벨
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

        #endregion

        #region [Event Definition]

        private void frmCUSTranStartLot_Load(object sender, EventArgs e)
        {
            MPCF.ConvertCaption(this);

            if (BIGV.gbTunePublish == true)
            {
                InitH101Tuner();
            }

            MPCF.ClearList(spdOrderInfo);
            MPCF.ClearList(spdLotList);

            cdvLine.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvLine.Text"));
            cdvLine.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvLine.Text"));
            cdvOper.Tag = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvOper.Text"));
            cdvOper.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvOper.Text"));
            txtOperDesc.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "txtOperDesc.Text"));
            cdvResID.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvResID.Text"));
            cdvResID.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "cdvResID.Text"));
            txtResDesc.Text = MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, this.Name, "txtResDesc.Text"));

            //프린트 속성 가져오기
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

                cdvResID.Text = "";
                txtResDesc.Text = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvOper_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = null;
                string s_sql = "";

                if (string.IsNullOrEmpty(cdvOper.Text) == false)
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

                    if (dt.Rows.Count == 1)
                    {
                        cdvResID.Tag = dt.Rows[0]["RES_ID"];
                        cdvResID.Text = dt.Rows[0]["RES_ID"].ToString();
                        txtResDesc.Text = dt.Rows[0]["RES_DESC"].ToString();

                        b_load_flag = true;
                    }

                    btnPrint.Visible = false;
                    chkPrintFlag.Visible = false;

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
                        for (int k = 0; k < dt.Rows.Count; k++)
                        {
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

                                    if (dt.Rows[k]["DATA_3"].ToString() == "START")
                                    {
                                        btnPrint.Visible = true;
                                        chkPrintFlag.Visible = true;
                                    }

                                    if (BIGV.gsResId == cdvResID.Text)
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

                //해당 설비에 진행하려는 오더의 정보를 조회
                if (string.IsNullOrEmpty(cdvResID.Text) == false)
                {
                    ViewOrder();
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

                    if (Tran_Start_Lot(txtLotID.Text) == false)
                    {
                        MPCF.SetFocus(txtLotID);
                        return;
                    }

                    txtLotID.Text = "";
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
        }

        #endregion        

        private void btnPrintOption_Click(object sender, EventArgs e)
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

        private void btnReqInsp_Click(object sender, EventArgs e)
        {
            if (!CheckCondition("PROCESS"))
                return;

            if (Tran_Start_Lot(txtLotID.Text.ToUpper()) == false)
            {
                txtLotID.Text = "";
                MPCF.SetFocus(txtLotID);
                return;
            }

            txtLotID.Text = "";
            MPCF.SetFocus(txtLotID);
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
            View_Strart_Lot_List();

            MPCF.SetFocus(txtLotID);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //EL종료일 경우 완제품 라벨 발행
                if (s_Print_Type == 'I')
                {
					string sTmpLotID = txtLotID.Text;

					if (string.IsNullOrEmpty(sTmpLotID) == true)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Lot ID]"));
                        MPCF.SetFocus(txtLotID);
                        return;
                    }

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
    }
}
