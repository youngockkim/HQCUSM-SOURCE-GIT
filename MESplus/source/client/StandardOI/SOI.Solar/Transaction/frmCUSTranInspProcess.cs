//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmCUSTranInspProcess.cs
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
    public partial class frmCUSTranInspProcess : BOIBaseForm02
    {
        #region [Property]

        const int ENTER = 13;

        #endregion

        public frmCUSTranInspProcess()
        {
            InitializeComponent();
        }

        #region [Constant Definition]

        private enum LOT_COL : int
        {
            LOT_ID,
            MAT_ID,
            MAT_DESC
        }

        #endregion

        #region [Variable Definition]
        
        private bool bIsShown = false;
        private MenuInfoTag menuInfo;
        private frmPrintOptionPopup frmOption;
        public PrintOptionModel printOption;
        private int i_view_ng_cnt = 0;
        private string s_Chg_flag;
        private string s_Change_Mat;
        private string s_Print_design;

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
                    MPCF.ClearList(spdResult);
                    txtLotID.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        /// <summary>
        /// View Lot
        /// </summary>
        /// <param name="sLotID"></param>
        /// <returns></returns>
        private bool Tran_Process(string sLotID, char cstep)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");
            TRSNode list_item;
            int i_ng_cnt = 0;

            try
            {
                MPCF.SetInMsg(in_node);
                //cstep : 2(결과수정) 3(수리실로 이동) 4(공정이동)
                in_node.ProcStep = cstep;
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));

                if(cstep == '4')
                {
                    in_node.AddString("TO_OPER", MPCF.Trim(cdvOper.Text));
                }

                for (int i = 0; i < spdResult.Sheets[0].RowCount; i++)
                {
                    list_item = in_node.AddNode("DATA_LIST");
                    list_item.AddString("OPER", MPCF.Trim(spdResult.ActiveSheet.Cells[i, 0].Text));                                         
                    list_item.AddString("RESULT", MPCF.Trim(spdResult.ActiveSheet.Cells[i, 2].Text));        
                    
                    if(spdResult.ActiveSheet.Cells[i, 2].Text == "NG")
                    {
                        i_ng_cnt++;
                    }
                }

                //조회시 NG이력이 있고 변경시 다 OK일경우
                if (i_ng_cnt == 0 && i_view_ng_cnt > 0)
                {
                    in_node.AddChar("OK_FLAG", 'Y');    
                }

                if (MPCF.CallService("CUS", "CWIP_Tran_FQC_Process", in_node, ref out_node) == false)
                {
                    return false;
                }

                //라벨 발행이 필요한 케이스 경우
                if(out_node.GetChar("FG_LABEL_FLAG") == 'Y')
                {
                    s_Print_design = out_node.GetString("PRINT_DESIGN");
                    s_Chg_flag = out_node.GetString("CHG_FLAG");
                    s_Change_Mat = out_node.GetString("CHG_MAT_ID");

                    ProcPrint(s_Print_design);
                }

                MPCF.ShowSuccessMessage(out_node, false);

                cdvOper.Text = "";
                txtFGLotID.Text = "";
                txtLotID.Text = "";
                txtOperDesc.Text = "";
                MPCF.ClearList(spdResult);
                MPCF.SetFocus(txtLotID);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool ProcPrint(string sDesign)
        {
            TRSNode out_node = new TRSNode("OUT_NODE");
            string sScreenID = string.Empty;
            DataTable dt = new DataTable();

            try
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

        private bool GetMatInfoOfLot(string sLotID, ref DataTable dt)
        {
            try
            {
                string sViewID;

                TPDR.DirectViewCond[] arr;

                if (s_Chg_flag == "Y")
                {
                    arr = new TPDR.DirectViewCond[3];
                    sViewID = "VIEW_FG_LABEL_INFO";

                    arr[0].sCondtion_ID = "$FACTORY";
                    arr[0].sCondition_Value = MPGV.gsFactory;

                    arr[1].sCondtion_ID = "$LOT_ID";
                    arr[1].sCondition_Value = MPCF.Trim(sLotID);

                    arr[2].sCondtion_ID = "$MAT_ID";
                    arr[2].sCondition_Value = MPCF.Trim(s_Change_Mat);

                    if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, arr, true) == false)
                    {
                        if (dt != null) { dt.Dispose(); }
                        GC.Collect();
                        return false;
                    }
                }
                else
                {
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

        private bool ViewLotInfo(string sLotID, char cStep)
        {
            try
            {
                MPCF.ShowMessageClear();
                MPCF.ClearList(spdResult);
                TPDR.DirectViewCond[] ArrDVC;
                DataTable dt = new DataTable();
                string s_view_id = string.Empty;
                
                i_view_ng_cnt = 0;

                ArrDVC = new TPDR.DirectViewCond[2];

                //검사 공장 NG 체크
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$LOT_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(sLotID);

                if (cStep == '1')
                {                   
                    s_view_id = "VIEW_LOT_INSP_RESULT";
                }
                else
                {
                    s_view_id = "VIEW_FGLOT_INSP_RESULT";
                }

                if (TPDR.DirectViewOne(null, s_view_id, ref dt, ArrDVC) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                for(int k = 0; k < dt.Rows.Count; k++)
                {
                    spdResult.ActiveSheet.RowCount++;
                    spdResult_Sheet1.RowHeader.Cells.Get(k, 0).Value = dt.Rows[k]["OPER_DESC"].ToString();
                    spdResult.ActiveSheet.Cells[k, 0].Text = dt.Rows[k]["OPER"].ToString();
                    spdResult.ActiveSheet.Cells[k, 1].Text = dt.Rows[k]["TRAN_TIME"].ToString();
                    spdResult.ActiveSheet.Cells[k, 2].Text = dt.Rows[k]["RESULT"].ToString();

                    if(dt.Rows[k]["RESULT"].ToString() != "OK")
                    {
                        spdResult.ActiveSheet.Cells[k, 2].ForeColor = Color.Red;

                        i_view_ng_cnt++;
                    }
                    else
                    {
                        spdResult.ActiveSheet.Cells[k, 2].ForeColor = Color.Blue;
                    }
                }
                
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        #region [Event Definition]

        private void frmCUSTranInspProcess_Load(object sender, EventArgs e)
        {
            MPCF.ConvertCaption(this);

            MPCF.ClearList(spdResult);
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER && MPCF.Trim(txtLotID.Text) != "")
                {
                    txtFGLotID.Text = "";
                    txtLotID.Text = MPCF.ToUpper(txtLotID.Text); // 일괄 대문자

                    if (ViewLotInfo(txtLotID.Text, '1') == false)
                    {
                        MPCF.SetFocus(txtLotID);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (txtLotID.Text == "" && txtFGLotID.Text == "")
            {
                MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, false);
                txtLotID.Focus();
                return;
            }

			if(spdResult.ActiveSheet.RowCount == 0)
			{
				MPCF.ShowMessage(MPCF.GetMessage(107), MSG_LEVEL.ERROR, false);
				MPCF.SetFocus(txtLotID);
				return;
			}

            if (Tran_Process(txtLotID.Text, '2') == false)
            {
                MPCF.SetFocus(txtLotID);
                return;
            }
        }

        private void txtFGLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER && MPCF.Trim(txtFGLotID.Text) != "")
                {
                    txtLotID.Text = "";
                    txtFGLotID.Text = MPCF.ToUpper(txtFGLotID.Text); // 일괄 대문자

                    if (ViewLotInfo(txtFGLotID.Text, '2') == false)
                    {
                        MPCF.SetFocus(txtFGLotID);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdResult_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column == 3)
                {
                    TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                    dvcArgu[0].sCondtion_ID = "$FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    dvcArgu[1].sCondtion_ID = "$TABLE_NAME";
                    dvcArgu[1].sCondition_Value = "OKNG";

                    // CodeView Column Header Setup
                    string[] header = new string[] { "Code" };

                    // CodeView Display Column Setup
                    string[] display = new string[] { "KEY_1" };

                    // Show
                    cdvResult.Text = cdvResult.Show(cdvResult, "Code Desc", "VIEW_GCM_DATA", dvcArgu, display, header, "KEY_1", -1);

                    if (MPCF.Trim(cdvResult.Text) != "")
                    {
                        if (cdvResult.returnDatas != null && cdvResult.returnDatas.Count > 0)
                        {
                            spdResult.ActiveSheet.Cells[e.Row, e.Column - 1].Text = cdvResult.returnDatas[0];
                            //spdUseMaterial.ActiveSheet.Rows[e.Row].BackColor = Color.Salmon;

                            if (cdvResult.returnDatas[0].ToString() == "NG")
                            {
                                spdResult.ActiveSheet.Cells[e.Row, e.Column - 1].ForeColor = Color.Red;
                            }
                            else
                            {
                                spdResult.ActiveSheet.Cells[e.Row, e.Column - 1].ForeColor = Color.Blue;
                            }
                        }
                        else
                        {
                            spdResult.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                        }
                    }
                    else
                    {
                        spdResult.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
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

        private void frmCUSTranInspProcess_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                bIsShown = true;

                MPCF.SetFocus(txtLotID);
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            if (txtLotID.Text == "" && txtFGLotID.Text == "")
            {
                MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, false);
                txtLotID.Focus();
                return;
            }

            if (Tran_Process(txtLotID.Text, '3') == false)
            {
                MPCF.SetFocus(txtLotID);
                return;
            }
        }

        private void cdvOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
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
                        cdvOper.Text = cdvOper.returnDatas[0];
                        txtOperDesc.Text = cdvOper.returnDatas[1];
                    }
                }
                else
                {
                    cdvOper.Text = "";
                    txtOperDesc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnOper_Click(object sender, EventArgs e)
        {
            if (txtLotID.Text == "" && txtFGLotID.Text == "")
            {
                MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, false);
                txtLotID.Focus();
                return;
            }

            if (cdvOper.Text == "")
            {
                MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.ERROR, false);
                txtLotID.Focus();
                return;
            }

            if (Tran_Process(txtLotID.Text, '4') == false)
            {
                MPCF.SetFocus(txtLotID);
                return;
            }           
        }
    }
}
