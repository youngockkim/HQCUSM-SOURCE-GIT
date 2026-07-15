//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmCUSTranResRawManagement.cs
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
//       - 2017-08-19 : Created by Sanghun Mo  
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
    public partial class frmCUSTranResRawManagement :  BOIBaseForm02
    {
        #region [Property]

        const int ENTER = 13;

        #endregion

        public frmCUSTranResRawManagement()
        {
            InitializeComponent();
        }

        #region [Constant Definition]

        #endregion


        #region [Variable Definition]

        private bool bIsShown = false;
        private MenuInfoTag menuInfo;
        private frmPrintOptionPopup frmOption;
        private frmCUSTranLossLot frmLossLot;
        public PrintOptionModel printOption;
        private string s_Print_type;
        private string s_Print_design;
        private bool b_load_flag = false;
        private string s_label = string.Empty;
        private string s_label_info = string.Empty;

        private enum RAW_MAT_LIST : int
        {
            OPER = 0,
            MAT_ID,
            MAT_VER,
            MAT_DESC,
            MAT_BOX_QTY,
            MODEL,
            LOT_ID,
            LOT_DESC,
            LINE_ID,
            QTY,
            MAT_TYPE
        }

        private enum INSTALL_RAW_LIST : int
        {
            CHK = 0,
            RES_ID,
            POS_ID,
            SET_ID,
            LOT_ID,
            LOT_DESC,
            MAT_ID,
            MAT_VER,
            MAT_DESC,
            INSTALL_QTY,
            USE_QTY,
            QTY,            
            INSTALL_TIME,
            CREATE_USER_ID,
            MAT_TYPE
        }

		private enum DELETE_OPTION : int
		{
			UNINSTALL = 0,
			REMOVE
		}

        #endregion


        #region [FormDefinition]

        private void initCtrl()
        {
            try
            {
                // (Required) Convert Caption
                // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
                MPCF.ConvertCaption(this);

                MPCF.FieldClear(this);
                this.dtpPackDate.Value = DateTime.Now;

                MPCF.ClearList(this.spdRawMatList, true);
                MPCF.FitColumnHeader(spdRawMatList);
                MPCF.ClearList(this.spdInstallRawMatList, true);
                MPCF.FitColumnHeader(spdInstallRawMatList);

                this.txtMatID.Enabled = false;
                this.txtMatVer.Enabled = false;
                this.txtLotID.Enabled = false;
                this.cdvSetID.Enabled = false;
                this.txtInstallTime.Visible = false;
                this.txtMatType.Visible = false;
				this.btnUninstall.Enabled = false;
				this.btnRemove.Enabled = false;

                //영문 대문자 강제
                this.txtBarcode.CharacterCasing = CharacterCasing.Upper;
                //한글 자판허용 안함
                this.txtBarcode.ImeMode = ImeMode.Disable;

                this.cdvLine.Tag = CMNF.GetRegSetting(Application.ProductName, this.Name, this.cdvLine.Name, "");
                this.cdvLine.Text = CMNF.GetRegSetting(Application.ProductName, this.Name, this.cdvLine.Name, "");
                this.cdvOper.Tag = CMNF.GetRegSetting(Application.ProductName, this.Name, this.cdvOper.Name, "");
                this.cdvOper.Text = CMNF.GetRegSetting(Application.ProductName, this.Name, this.cdvOper.Name, "");
                this.txtOperDesc.Text = CMNF.GetRegSetting(Application.ProductName, this.Name, this.txtOperDesc.Name, "");
                this.cdvResID.Tag = CMNF.GetRegSetting(Application.ProductName, this.Name, this.cdvResID.Name, "");
                this.cdvResID.Text = CMNF.GetRegSetting(Application.ProductName, this.Name, this.cdvResID.Name, "");
                this.txtResDesc.Text = CMNF.GetRegSetting(Application.ProductName, this.Name, this.txtResDesc.Name, "");
                if (CMNF.GetRegSetting(Application.ProductName, this.Name, this.chkPrintFlag.Name, "") == "Y") { this.chkPrintFlag.Checked = true; }
                else { this.chkPrintFlag.Checked = false; }                

                if (string.IsNullOrEmpty(MPCF.Trim(this.cdvLine.Text)) == false )
                {
                    ViewRawMatList("CLR");
                }

                if (string.IsNullOrEmpty(MPCF.Trim(this.cdvResID.Text)) == false)
                {
                    ViewRawMatInstall("CLR");
                }

                SetPosID();

                SetupPrtOpt();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void SetPosID()
        {
            try
            {
                TRSNode out_node = new TRSNode("VIEW_DATA_OUT");

                if (CSCR.ViewGCMDataList('1', MPCF.Trim(CSGC.MP_GCM_RES_POSITION_LIST), ref out_node, " ", false, null) == false)
                {
                    return;
                }

                if (out_node.GetList(0).Count <= 0)
                {
                    return;
                }

                cdvPosID.Tag = MPCF.Trim(out_node.GetList(0)[0].GetString("KEY_1"));
                cdvPosID.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("KEY_1"));
                txtPosDesc.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("DATA_1"));
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
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
                        break;

                    case CSGC.MP_CHECK_CREATE:

                        this.cdvLine.Text = MPCF.Trim(this.cdvLine.Text);
                        if (string.IsNullOrEmpty(this.cdvLine.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("Line"));
                            this.cdvLine.Focus();
                            return false;
                        }

                        this.cdvOper.Text = MPCF.Trim(this.cdvOper.Text);
                        if (string.IsNullOrEmpty(this.cdvOper.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("Oper"));
                            this.cdvOper.Focus();
                            return false;
                        }

                        this.cdvResID.Text = MPCF.Trim(this.cdvResID.Text);
                        if (string.IsNullOrEmpty(this.cdvResID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("Res ID"));
                            this.cdvResID.Focus();
                            return false;
                        }

                        if (chkRepairMat.Checked)
                        {
                            this.cdvMaterial.Text = MPCF.Trim(this.cdvMaterial.Text);
                            if (string.IsNullOrEmpty(this.cdvMaterial.Text) == true)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("Mat ID"));
                                MPCF.SetFocus(cdvMaterial);
                                return false;
                            }
                        }
                        else 
                        {
                            this.txtMatID.Text = MPCF.Trim(this.txtMatID.Text);
                            if (string.IsNullOrEmpty(this.txtMatID.Text) == true)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("Mat ID"));
                                MPCF.SetFocus(txtMatID);
                                return false;
                            }

                            this.txtLotID.Text = MPCF.Trim(this.txtLotID.Text);
                            if (string.IsNullOrEmpty(this.txtLotID.Text) == true)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("Lot ID"));
                                return false;
                            }
                        }                        

                        this.txtRawMatQty.Text = MPCF.Trim(this.txtRawMatQty.Text);
                        if (string.IsNullOrEmpty(this.txtRawMatQty.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335));
                            this.txtRawMatQty.Focus();
                            this.txtRawMatQty.SelectAll();
                            return false;
                        }

                        this.txtRawMatQty.Text = MPCF.Trim(this.txtRawMatQty.Text);
                        if (MPCF.CheckNumeric(this.txtRawMatQty.Text) == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(116));                            
                            txtRawMatQty.Focus();
                            txtRawMatQty.SelectAll();
                            return false;
                        }

                        this.txtRawMatQty.Text = MPCF.Trim(this.txtRawMatQty.Text);
                        if (MPCF.ToDbl(MPCF.Trim(this.txtRawMatQty.Text)) <= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(65));                            
                            txtRawMatQty.Focus();
                            txtRawMatQty.SelectAll();
                            return false;
                        }

                        if (MPCF.ToDbl(MPCF.Trim(this.txtRawMatQty.Text)) >
                            MPCF.ToDbl(MPCF.Trim(this.spdRawMatList.ActiveSheet.Cells[spdRawMatList.ActiveSheet.ActiveRowIndex, (int)RAW_MAT_LIST.QTY].Text)))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(125));
                            txtRawMatQty.Focus();
                            txtRawMatQty.SelectAll();
                            return false;
                        }

                        this.cdvPosID.Text = MPCF.Trim(this.cdvPosID.Text);
                        if (string.IsNullOrEmpty(this.cdvPosID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("Pos ID"));
                            this.cdvPosID.Focus();
                            return false;
                        }


                        if ((MPCF.Trim(this.cdvResID.Text).Substring(0, 3) == "TAB"
                                && MPCF.Trim(this.txtMatType.Text) == "RBN")                 //TABBING 설비 Ribbon Material
                            || (MPCF.Trim(this.cdvResID.Text).Substring(0, 3) == "FRM"
                                && MPCF.Trim(this.txtMatType.Text) == "FRM"))               //FRAME 설비 Frame Material
                        {
                            if (string.IsNullOrEmpty(this.cdvSetID.Text) == true)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("Set ID"));
                                this.cdvSetID.Focus();
                                return false;
                            }
                        }

                        this.txtBarcode.Text = MPCF.Trim(this.txtBarcode.Text);
                        if (string.IsNullOrEmpty(this.txtBarcode.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335));                            
                            this.txtBarcode.Focus();
                            this.txtBarcode.SelectAll();
                            return false;
                        }

                        if (MPCF.Trim(this.txtBarcode.Text).Length > 50)
                        {
                            MPCF.ShowMsgBox("50 " + MPCF.GetMessage(397) + Environment.NewLine + MPCF.FindLanguage("Barcode"));
                            this.txtBarcode.Focus();
                            this.txtBarcode.SelectAll();
                            return false;
                        }

                        break;

                    case CSGC.MP_CHECK_UPDATE:
                        break;

                    case CSGC.MP_CHECK_DELETE:

                        int i_cnt = 0;

                        for(int k =0; k < spdInstallRawMatList.ActiveSheet.RowCount; k++)
                        {
                           if(Convert.ToBoolean(spdInstallRawMatList.ActiveSheet.Cells[k, (int)INSTALL_RAW_LIST.CHK].Value) == true)
                           {
                               i_cnt++;    
                           }
                        }

                        if(i_cnt == 0)
                        {
                            this.txtMatID.Text = MPCF.Trim(this.txtMatID.Text);
                            if (string.IsNullOrEmpty(this.txtMatID.Text) == true)
                            {
                                MPCF.ShowMsgBox("[Mat ID] " + MPCF.GetMessage(335));
                                return false;
                            }

                            this.txtLotID.Text = MPCF.Trim(this.txtLotID.Text);
                            if (string.IsNullOrEmpty(this.txtLotID.Text) == true)
                            {
                                MPCF.ShowMsgBox("[Lot ID] " + MPCF.GetMessage(335));
                                return false;
                            }

                            this.txtRawMatQty.Text = MPCF.Trim(this.txtRawMatQty.Text);
                            if (string.IsNullOrEmpty(this.txtRawMatQty.Text) == true)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(335));
                                this.txtRawMatQty.Focus();
                                this.txtRawMatQty.SelectAll();
                                return false;
                            }

                            this.txtRawMatQty.Text = MPCF.Trim(this.txtRawMatQty.Text);
                            if (MPCF.ToDbl(MPCF.Trim(this.txtRawMatQty.Text)) < 0)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(398));
                                txtRawMatQty.Focus();
                                txtRawMatQty.SelectAll();
                                return false;
                            }

                            this.txtRawMatQty.Text = MPCF.Trim(this.txtRawMatQty.Text);
                            if (MPCF.CheckNumeric(this.txtRawMatQty.Text) == false)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                txtRawMatQty.Focus();
                                txtRawMatQty.SelectAll();
                                return false;
                            }
                        }                        

                        break;

                    case CSGC.MP_CHECK_CANCEL:

                        this.txtMatID.Text = MPCF.Trim(this.txtMatID.Text);
                        if (string.IsNullOrEmpty(this.txtMatID.Text) == true)
                        {
                            MPCF.ShowMsgBox("[Mat ID] " + MPCF.GetMessage(335));
                            return false;
                        }

                        this.txtLotID.Text = MPCF.Trim(this.txtLotID.Text);
                        if (string.IsNullOrEmpty(this.txtLotID.Text) == true)
                        {
                            MPCF.ShowMsgBox("[Lot ID] " + MPCF.GetMessage(335));
                            return false;
                        }

                        this.txtRawMatQty.Text = MPCF.Trim(this.txtRawMatQty.Text);
                        if (string.IsNullOrEmpty(this.txtRawMatQty.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335));
                            this.txtRawMatQty.Focus();
                            this.txtRawMatQty.SelectAll();
                            return false;
                        }

                        this.txtRawMatQty.Text = MPCF.Trim(this.txtRawMatQty.Text);
                        if (MPCF.ToDbl(MPCF.Trim(this.txtRawMatQty.Text)) < 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(398));
                            txtRawMatQty.Focus();
                            txtRawMatQty.SelectAll();
                            return false;
                        }

                        this.txtRawMatQty.Text = MPCF.Trim(this.txtRawMatQty.Text);
                        if (MPCF.CheckNumeric(this.txtRawMatQty.Text) == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(116));
                            txtRawMatQty.Focus();
                            txtRawMatQty.SelectAll();
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

        private bool ViewRawMatList(string sClearOpt)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;
            char s_eqmagFlag = 'N';
            char c_tabbing_flag = 'N';

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();            

            int iTopRow = spdRawMatList.GetViewportTopRow(0);       
            MPCF.ClearList(this.spdRawMatList);
            
            try
            {
                if (sClearOpt == "CLR")
                    MPCF.FieldClear(this.grbSaveOpt, this.cdvPosID, this.txtPosDesc, this.cdvSetID);

                this.dtpPackDate.Value = DateTime.Now;


                if (MPCF.Trim(cdvResID.Text) != "")  
                {
                    //GCM TABLE "C@EQ_MAT 에 값이 셋팅되어 있으면 해당 값에 셋팅된 자재만 보여줌 
                    //JUHYEON.JUNG 2017.10.1
                    if (GetEQMatCount(cdvResID.Text) > 0)
                        s_eqmagFlag = 'Y';
                }

                if (s_eqmagFlag == 'Y')
                {
                    //배치작업 설비 정보 추가로 조회
                    if (cdvOper.Text == "1320")
                    {
                        c_tabbing_flag = 'Y';
                        sViewID = "VIEW_OPER_LOT_LIST_01";
                    }
                    else
                    {
                        sViewID = "VIEW_OPER_LOT_LIST_07";
                    }
                    i_cond_cnt = 5;
                }
                else
                {
                    sViewID = "VIEW_OPER_LOT_LIST_04";
                    i_cond_cnt = 4;

                }
                
                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$LINE_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(this.cdvLine.Text);

                ArrDVC[2].sCondtion_ID = "$OPER";
                ArrDVC[2].sCondition_Value = MPCF.Trim(this.cdvOper.Text);

                ArrDVC[3].sCondtion_ID = "$STOCK";
                ArrDVC[3].sCondition_Value = MPCF.Trim(CSGC.MP_TIV_INV_WIPOPR);

                if (s_eqmagFlag == 'Y')
                {
                    ArrDVC[4].sCondtion_ID = "$RES_ID";
                    ArrDVC[4].sCondition_Value = MPCF.Trim(cdvResID.Text);
                }

               
                
                if(c_tabbing_flag == 'Y')
                {
                    if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, ArrDVC, true) == false)
                    {
                        if (dt != null) { dt.Dispose(); }
                        GC.Collect();
                        return false;
                    }

                    spdRawMatList.ActiveSheet.ColumnCount = dt.Columns.Count;

                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        if (chkAllRes.Checked == false && dt.Rows[k]["MAT_TYPE"].ToString() != "RBN")
                        {
                            if (dt.Rows[k]["BATCH_RES_ID"].ToString() != cdvResID.Text)
                            {
                                continue;
                            }
                        }

                        spdRawMatList.ActiveSheet.RowCount++;
                        spdRawMatList.ActiveSheet.Cells[spdRawMatList.ActiveSheet.RowCount-1, 0].Text = dt.Rows[k]["OPER"].ToString();
                        spdRawMatList.ActiveSheet.Cells[spdRawMatList.ActiveSheet.RowCount - 1, 1].Text = dt.Rows[k]["MAT_ID"].ToString();
                        spdRawMatList.ActiveSheet.Cells[spdRawMatList.ActiveSheet.RowCount - 1, 2].Text = dt.Rows[k]["MAT_VER"].ToString();
                        spdRawMatList.ActiveSheet.Cells[spdRawMatList.ActiveSheet.RowCount - 1, 3].Text = dt.Rows[k]["MAT_DESC"].ToString();
                        spdRawMatList.ActiveSheet.Cells[spdRawMatList.ActiveSheet.RowCount - 1, 4].Text = dt.Rows[k]["MAT_BOX_QTY"].ToString();
                        spdRawMatList.ActiveSheet.Cells[spdRawMatList.ActiveSheet.RowCount - 1, 5].Text = dt.Rows[k]["MODEL"].ToString();
                        spdRawMatList.ActiveSheet.Cells[spdRawMatList.ActiveSheet.RowCount - 1, 6].Text = dt.Rows[k]["LOT_ID"].ToString();
                        spdRawMatList.ActiveSheet.Cells[spdRawMatList.ActiveSheet.RowCount - 1, 7].Text = dt.Rows[k]["LOT_DESC"].ToString();
                        spdRawMatList.ActiveSheet.Cells[spdRawMatList.ActiveSheet.RowCount - 1, 8].Text = dt.Rows[k]["LINE"].ToString();
                        spdRawMatList.ActiveSheet.Cells[spdRawMatList.ActiveSheet.RowCount - 1, 9].Text = dt.Rows[k]["QTY"].ToString();
                        spdRawMatList.ActiveSheet.Cells[spdRawMatList.ActiveSheet.RowCount - 1, 10].Text = dt.Rows[k]["MAT_TYPE"].ToString();
                        spdRawMatList.ActiveSheet.Cells[spdRawMatList.ActiveSheet.RowCount - 1, 11].Text = dt.Rows[k]["LAST_TRAN_TIME"].ToString();
                        spdRawMatList.ActiveSheet.Cells[spdRawMatList.ActiveSheet.RowCount - 1, 12].Text = dt.Rows[k]["BATCH_RES_ID"].ToString();

                        
                    }
                }           
                else
                {
                     if (TPDR.DirectViewOne(this.spdRawMatList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }
                }

                if (spdRawMatList.ActiveSheet.RowCount > 0)
                {
                    this.spdRawMatList.ActiveSheet.Columns[(int)RAW_MAT_LIST.OPER].Visible = false;
                    //this.spdRawMatList.ActiveSheet.Columns[(int)RAW_MAT_LIST.MAT_TYPE].Visible = false;
                }               


                MPCF.FitColumnHeader(this.spdRawMatList);

                this.spdRawMatList.ActiveSheet.Columns[(int)RAW_MAT_LIST.MAT_VER].Visible = false;
				this.spdRawMatList.ActiveSheet.Columns[(int)RAW_MAT_LIST.MAT_DESC].Width = 200f;
				this.spdRawMatList.ActiveSheet.Columns[(int)RAW_MAT_LIST.LOT_DESC].Width = 150f;

                spdRawMatList.SetViewportTopRow(0, iTopRow +1);
                spdRawMatList.Sheets[0].ActiveRowIndex = iTopRow +1;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return false;
            }
        }

        private bool ViewRawMatInstall(string sClearOpt)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;
            string s_sql = "";

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();         
            
            if (sClearOpt == "CLR")
                MPCF.ClearList(this.spdInstallRawMatList);

            try
            {
                MPCF.FieldClear(this.grbSaveOpt, this.cdvPosID, this.txtPosDesc, this.cdvSetID);
                this.dtpPackDate.Value = DateTime.Now;

                sViewID = "VIEW_RAW_MAT_LIST_IN_RES_01";
                i_cond_cnt = 4;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$LINE_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(this.cdvLine.Text);

                ArrDVC[2].sCondtion_ID = "$OPER";
                ArrDVC[2].sCondition_Value = MPCF.Trim(this.cdvOper.Text);

                ArrDVC[3].sCondtion_ID = "$RES_ID";
                ArrDVC[3].sCondition_Value = MPCF.Trim(this.cdvResID.Text);

                //if (TPDR.DirectViewOne(this.spdInstallRawMatList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                //{
                //    if (dt != null) { dt.Dispose(); }
                //    GC.Collect();
                //    return false;
                //}

                if (TPDR.GetDataOne("", ref dt, sViewID, ArrDVC, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spdInstallRawMatList.ActiveSheet.RowCount++;
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.CHK].Value = false;
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.RES_ID].Value = dt.Rows[i]["RES_ID"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.POS_ID].Value = dt.Rows[i]["POS_ID"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.SET_ID].Value = dt.Rows[i]["SET_ID"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.LOT_ID].Value = dt.Rows[i]["LOT_ID"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.LOT_DESC].Value = dt.Rows[i]["LOT_DESC"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.MAT_VER].Value = dt.Rows[i]["MAT_VER"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.MAT_DESC].Value = dt.Rows[i]["MAT_DESC"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.INSTALL_QTY].Value = dt.Rows[i]["INSTALL_QTY"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.USE_QTY].Value = dt.Rows[i]["USE_QTY"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.QTY].Value = dt.Rows[i]["QTY"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.INSTALL_TIME].Value = dt.Rows[i]["INSTALL_TIME"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.CREATE_USER_ID].Value = dt.Rows[i]["CREATE_USER_ID"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.MAT_TYPE].Value = dt.Rows[i]["MAT_TYPE"].ToString();
                }

                MPCF.FitColumnHeader(this.spdInstallRawMatList);

                spdInstallRawMatList_Sheet1.Columns.Get((int)INSTALL_RAW_LIST.CHK).Width = 40F;
                spdInstallRawMatList_Sheet1.Columns.Get((int)INSTALL_RAW_LIST.MAT_DESC).Width = 200F;
                spdInstallRawMatList_Sheet1.Columns.Get((int)INSTALL_RAW_LIST.LOT_DESC).Width = 150F;                

                this.spdInstallRawMatList.ActiveSheet.Columns[(int)INSTALL_RAW_LIST.MAT_VER].Visible = false;   

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return false;
            }
        }

        private bool ViewSelectRawMatInstall(string sClearOpt, string sMatID)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;
            string s_sql = "";

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            if (sClearOpt == "CLR")
                MPCF.ClearList(this.spdInstallRawMatList);

            try
            {
                MPCF.FieldClear(this.grbSaveOpt, this.cdvPosID, this.txtPosDesc, this.cdvSetID);
                this.dtpPackDate.Value = DateTime.Now;

                sViewID = "VIEW_RAW_MAT_LIST_IN_RES_02";
                i_cond_cnt = 5;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$LINE_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(this.cdvLine.Text);

                ArrDVC[2].sCondtion_ID = "$OPER";
                ArrDVC[2].sCondition_Value = MPCF.Trim(this.cdvOper.Text);

                ArrDVC[3].sCondtion_ID = "$RES_ID";
                ArrDVC[3].sCondition_Value = MPCF.Trim(this.cdvResID.Text);

                ArrDVC[4].sCondtion_ID = "$MAT_ID";
                ArrDVC[4].sCondition_Value = MPCF.Trim(sMatID);

                //if (TPDR.DirectViewOne(this.spdInstallRawMatList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                //{
                //    if (dt != null) { dt.Dispose(); }
                //    GC.Collect();
                //    return false;
                //}

                if (TPDR.GetDataOne("", ref dt, sViewID, ArrDVC, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spdInstallRawMatList.ActiveSheet.RowCount++;
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.CHK].Value = false;
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.RES_ID].Value = dt.Rows[i]["RES_ID"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.POS_ID].Value = dt.Rows[i]["POS_ID"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.SET_ID].Value = dt.Rows[i]["SET_ID"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.LOT_ID].Value = dt.Rows[i]["LOT_ID"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.LOT_DESC].Value = dt.Rows[i]["LOT_DESC"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.MAT_VER].Value = dt.Rows[i]["MAT_VER"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.MAT_DESC].Value = dt.Rows[i]["MAT_DESC"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.INSTALL_QTY].Value = dt.Rows[i]["INSTALL_QTY"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.USE_QTY].Value = dt.Rows[i]["USE_QTY"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.QTY].Value = dt.Rows[i]["QTY"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.INSTALL_TIME].Value = dt.Rows[i]["INSTALL_TIME"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.CREATE_USER_ID].Value = dt.Rows[i]["CREATE_USER_ID"].ToString();
                    spdInstallRawMatList.ActiveSheet.Cells[i, (int)INSTALL_RAW_LIST.MAT_TYPE].Value = dt.Rows[i]["MAT_TYPE"].ToString();
                }

                MPCF.FitColumnHeader(this.spdInstallRawMatList);

                spdInstallRawMatList_Sheet1.Columns.Get((int)INSTALL_RAW_LIST.CHK).Width = 40F;
                spdInstallRawMatList_Sheet1.Columns.Get((int)INSTALL_RAW_LIST.MAT_DESC).Width = 200F;
                spdInstallRawMatList_Sheet1.Columns.Get((int)INSTALL_RAW_LIST.LOT_DESC).Width = 150F;

                this.spdInstallRawMatList.ActiveSheet.Columns[(int)INSTALL_RAW_LIST.MAT_VER].Visible = false;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return false;
            }
        }

        private bool UpdateRawMatInstall()
        {
            try
            {
                TRSNode in_node = new TRSNode("ATTACH_RAW_MATERIAL_IN");
                TRSNode out_node = new TRSNode("ATTACH_RAW_MATERIAL_OUT");
                TRSNode Raw_Mat_List;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_CREATE;
                in_node.AddString("LINE_NO", MPCF.Trim(this.cdvLine.Text));
                in_node.AddString("OPER", MPCF.Trim(this.cdvOper.Text));
                in_node.AddString("RES_ID", MPCF.Trim(this.cdvResID.Text));
                in_node.AddString("POS_ID", MPCF.Trim(this.cdvPosID.Text));
                in_node.AddString("SET_ID", MPCF.Trim(this.cdvSetID.Text));

                if(chkRepairMat.Checked)
                {
                    in_node.AddChar("REPAIR_MAT_FLAG", 'Y');
                    in_node.AddDouble("MOVE_QTY", MPCF.ToDbl(MPCF.Trim(this.txtRawMatQty.Text)));
                    txtMatID.Text = cdvMaterial.Text;
                }

                Raw_Mat_List = in_node.AddNode("RAW_MAT_LIST");
                Raw_Mat_List.AddString("LOT_ID", MPCF.Trim(this.txtLotID.Text));
                Raw_Mat_List.AddString("LOT_DESC", MPCF.Trim(this.txtBarcode.Text));
                Raw_Mat_List.AddString("MAT_ID", MPCF.Trim(this.txtMatID.Text));
                Raw_Mat_List.AddInt("MAT_VER", MPCF.Trim(this.txtMatVer.Text));
                Raw_Mat_List.AddDouble("INSTALL_QTY_1", MPCF.ToDbl(MPCF.Trim(this.txtRawMatQty.Text)));
                Raw_Mat_List.AddString("TYPE", MPCF.Trim(this.txtMatType.Text) == string.Empty ? " " : MPCF.Trim(this.txtMatType.Text));
                Raw_Mat_List.AddString("PACK_DATE", MPCF.Trim(this.dtpPackDate.GetValueAsString(8)));                
                Raw_Mat_List.AddString("SAVE_TYPE", MPCF.Trim(this.txtLotID.Text) != MPCF.Trim(this.txtMatID.Text) ? "TIV_LOT" : "MAT_LOT");

                if (CMNF.ShowMsgBox(CMNF.GetMessage(377), MessageBoxButtons.YesNo, SOI.CliFrx.MSG_LEVEL.INFO) != System.Windows.Forms.DialogResult.Yes)
                {
                    return false;
                }

                if (MPCF.CallService("CUS", "CTIV_Update_Raw_Mat_Install", in_node, ref out_node) == false)
                {
                    return false;
                }

                CMNF.ShowSuccessMessage(out_node, true);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return false;
            }
        }

        private bool UpdateRawMatRemove(DELETE_OPTION enumDelOpt)
        {
            try
            {
                TRSNode in_node = new TRSNode("ATTACH_RAW_MATERIAL_IN");
                TRSNode out_node = new TRSNode("ATTACH_RAW_MATERIAL_OUT");
                TRSNode Raw_Mat_List;
                int i_cnt = 0;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_DELETE;
                in_node.AddString("LINE_NO", MPCF.Trim(this.cdvLine.Text));
                in_node.AddString("OPER", MPCF.Trim(this.cdvOper.Text));
                in_node.AddString("RES_ID", MPCF.Trim(this.cdvResID.Text));

                for(int k = 0; k < spdInstallRawMatList.ActiveSheet.RowCount; k++)
                {
                    if (Convert.ToBoolean(spdInstallRawMatList.ActiveSheet.Cells[k, (int)INSTALL_RAW_LIST.CHK].Value) == true)
                    {
                        Raw_Mat_List = in_node.AddNode("RAW_MAT_LIST");
                        Raw_Mat_List.AddString("LOT_ID", MPCF.Trim(spdInstallRawMatList.ActiveSheet.Cells[k, (int)INSTALL_RAW_LIST.LOT_ID].Text));
                        Raw_Mat_List.AddString("POS_ID", MPCF.Trim(spdInstallRawMatList.ActiveSheet.Cells[k, (int)INSTALL_RAW_LIST.POS_ID].Text));
                        txtInstallTime.Text = MPCF.Trim(spdInstallRawMatList.ActiveSheet.Cells[k, (int)INSTALL_RAW_LIST.INSTALL_TIME].Text);
                        txtInstallTime.Text = txtInstallTime.Text.Replace(" ", "").Replace("-", "").Replace(":", "").Replace(".", "");
                        Raw_Mat_List.AddString("INSTALL_TIME", MPCF.Trim(txtInstallTime.Text));
                        Raw_Mat_List.AddString("MAT_ID", MPCF.Trim(spdInstallRawMatList.ActiveSheet.Cells[k, (int)INSTALL_RAW_LIST.MAT_ID].Text));
                        Raw_Mat_List.AddInt("MAT_VER", MPCF.Trim(spdInstallRawMatList.ActiveSheet.Cells[k, (int)INSTALL_RAW_LIST.MAT_VER].Text));
                        Raw_Mat_List.AddDouble("REMOVE_QTY_1", MPCF.ToDbl(MPCF.Trim(this.txtRawMatQty.Text)));

                        i_cnt++;
                    }
                }

                //체크가 된 row가 없을경우 선택된 랏 해제한다.
                if (i_cnt == 0)
                {
                    Raw_Mat_List = in_node.AddNode("RAW_MAT_LIST");
                    Raw_Mat_List.AddString("POS_ID", MPCF.Trim(this.cdvPosID.Text));
                    Raw_Mat_List.AddString("LOT_ID", MPCF.Trim(this.txtLotID.Text));
                    Raw_Mat_List.AddString("INSTALL_TIME", MPCF.Trim(this.txtInstallTime.Text));
                    Raw_Mat_List.AddString("MAT_ID", MPCF.Trim(this.txtMatID.Text));
                    Raw_Mat_List.AddInt("MAT_VER", MPCF.Trim(this.txtMatVer.Text));
                    Raw_Mat_List.AddDouble("REMOVE_QTY_1", MPCF.ToDbl(MPCF.Trim(this.txtRawMatQty.Text)));
                }

				if (enumDelOpt == DELETE_OPTION.REMOVE)
				{
					if (CMNF.ShowMsgBox(CMNF.GetMessage(457), MessageBoxButtons.YesNo, SOI.CliFrx.MSG_LEVEL.INFO) != System.Windows.Forms.DialogResult.Yes)
					{
						return false;
					}

					//제거 시 수량을 0으로 변경하여 제거.  장착 해제는 있는 수량 유지 장착만 해제
					this.txtRawMatQty.Text = "0";
					List<TRSNode>  rawMatList = in_node.GetList("RAW_MAT_LIST");

					for (int i = 0; i < rawMatList.Count; i++)
					{
						rawMatList[i].SetDouble("REMOVE_QTY_1",0.0);
					}
				}
				else if (enumDelOpt == DELETE_OPTION.UNINSTALL)
				{
					if (CMNF.ShowMsgBox(CMNF.GetMessage(377), MessageBoxButtons.YesNo, SOI.CliFrx.MSG_LEVEL.INFO) != System.Windows.Forms.DialogResult.Yes)
					{
						return false;
					}
				}

                if (MPCF.CallService("CUS", "CTIV_Update_Raw_Mat_Install", in_node, ref out_node) == false)
                {
                    return false;
                }

                //자동 라벨 프린팅
                if (this.chkPrintFlag.Checked == true)
                {
                    for (int k = 0; k < spdInstallRawMatList.ActiveSheet.RowCount; k++)
                    {
                        if (Convert.ToBoolean(spdInstallRawMatList.ActiveSheet.Cells[k, (int)INSTALL_RAW_LIST.CHK].Value) == true)
                        {
                            txtLotID.Text = MPCF.Trim(spdInstallRawMatList.ActiveSheet.Cells[k, (int)INSTALL_RAW_LIST.LOT_ID].Text);

                            if (MPCF.ToDbl(MPCF.Trim(this.txtRawMatQty.Text)) > 0)
                                ProcPrint();
                        }
                    }

                    if (i_cnt == 0)
                    {
                        if (MPCF.ToDbl(MPCF.Trim(this.txtRawMatQty.Text)) > 0)
                            ProcPrint();
                    }
                }

                CMNF.ShowSuccessMessage(out_node, true);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return false;
            }
        }

        private bool UpdateRawMatCancel()
        {
            try
            {
                TRSNode in_node = new TRSNode("ATTACH_RAW_MATERIAL_IN");
                TRSNode out_node = new TRSNode("ATTACH_RAW_MATERIAL_OUT");
                TRSNode Raw_Mat_List;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_CANCEL_APPROVAL;
                in_node.AddString("LINE_NO", MPCF.Trim(this.cdvLine.Text));
                in_node.AddString("OPER", MPCF.Trim(this.cdvOper.Text));
                in_node.AddString("RES_ID", MPCF.Trim(this.cdvResID.Text));
                in_node.AddString("POS_ID", MPCF.Trim(this.cdvPosID.Text));

                Raw_Mat_List = in_node.AddNode("RAW_MAT_LIST");
                Raw_Mat_List.AddString("LOT_ID", MPCF.Trim(this.txtLotID.Text));
                Raw_Mat_List.AddString("INSTALL_TIME", MPCF.Trim(this.txtInstallTime.Text));
                Raw_Mat_List.AddString("MAT_ID", MPCF.Trim(this.txtMatID.Text));
                Raw_Mat_List.AddInt("MAT_VER", MPCF.Trim(this.txtMatVer.Text));
                Raw_Mat_List.AddDouble("REMOVE_QTY_1", MPCF.ToDbl(MPCF.Trim(this.txtRawMatQty.Text)));

                if (CMNF.ShowMsgBox(CMNF.GetMessage(377), MessageBoxButtons.YesNo, SOI.CliFrx.MSG_LEVEL.INFO) != System.Windows.Forms.DialogResult.Yes)
                {
                    return false;
                }

                if (MPCF.CallService("CUS", "CTIV_Update_Raw_Mat_Install", in_node, ref out_node) == false)
                {
                    return false;
                }

                CMNF.ShowSuccessMessage(out_node, true);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return false;
            }
        }

        private int GetEQMatCount(string sEQID)
        {
            try
            {
                int i_cond_cnt;
                string sViewID;
                DataTable dt = new DataTable();

                i_cond_cnt = 3;
                sViewID = "VIEW_GCM_DATA_KEY1";

                TPDR.DirectViewCond[] arr = new TPDR.DirectViewCond[i_cond_cnt];

                arr[0].sCondtion_ID = "$FACTORY";
                arr[0].sCondition_Value = MPGV.gsFactory;

                arr[1].sCondtion_ID = "$TABLE_NAME";
                arr[1].sCondition_Value ="C@EQ_MAT";

                arr[2].sCondtion_ID = "$KEY_1";
                arr[2].sCondition_Value = MPCF.Trim(sEQID);

                if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, arr, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return 0;
                }

                if (dt.Rows.Count < 1)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return 0;
                }

                if (dt != null) { dt.Dispose(); }
                GC.Collect();
                return 1;
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
                return 0;
            }
        }

        private bool GetMatInfoOfRaw(string sLotID, ref DataTable dt)
        {
            try
            {
                int i_cond_cnt;
                string sViewID;
                //DataTable dt = new DataTable();

                i_cond_cnt = 2;
                sViewID = "VIEW_MAT_INFO_OF_TIVLOT";

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

        private bool ProcPrint()
        {
            TRSNode out_node = new TRSNode("OUT_NODE");
            string sScreenID = string.Empty;
            DataTable dt = new DataTable();

            try
            {
                if (GetMatInfoOfRaw(MPCF.Trim(this.txtLotID.Text), ref dt) == false)
                {
                    return false;
                }
                if (dt.Rows.Count < 1)
                {
                    return false;
                }

                udcPrint.InitFlexibleScreen();
                udcPrint.ScreenID = "RawMaterialLabel3";
                udcPrint.ScreenSpread.Tag = sScreenID;
                udcPrint.ProcStep = '1';
                udcPrint.LotID = sScreenID;
                udcPrint.LoadDesign();

                out_node.SetString("LOT_ID", MPCF.Trim(dt.Rows[0]["LOT_ID"].ToString()));
                out_node.SetString("TYPE", MPCF.Trim(dt.Rows[0]["TYPE"].ToString()));
                out_node.SetString("TYPE_DESC", MPCF.Trim(dt.Rows[0]["TYPE_DESC"].ToString()));
                out_node.SetString("MAT_ID", MPCF.Trim(dt.Rows[0]["MAT_ID"].ToString()));
                out_node.SetString("EFFECT", MPCF.Trim(dt.Rows[0]["EFFECT"].ToString()));
                out_node.SetString("CUST_CD", MPCF.Trim(dt.Rows[0]["CUST_CD"].ToString()));
                out_node.SetString("VENDOR_ID", MPCF.Trim(dt.Rows[0]["VENDOR_ID"].ToString()));
                out_node.SetString("VENDOR_DESC", MPCF.Trim(dt.Rows[0]["VENDOR_DESC"].ToString()));
                out_node.SetString("QTY", MPCF.Trim(dt.Rows[0]["QTY"].ToString()));
                out_node.SetString("UNIT", MPCF.Trim(dt.Rows[0]["UNIT"].ToString()));
                out_node.SetString("INSTALL_DATE", MPCF.Trim(dt.Rows[0]["WIP_IN_TIME"].ToString()));
                out_node.SetString("RETURN_DATE", MPCF.Trim(dt.Rows[0]["WIP_OUT_TIME"].ToString()));
                out_node.SetString("ORDER_ID", MPCF.Trim(dt.Rows[0]["ORDER_ID"].ToString()));
                out_node.SetString("WORKER", MPCF.Trim(dt.Rows[0]["USER_ID"].ToString()));
                
                if (udcPrint.SetDataToScreen(out_node) == false) return false;

                MPCF.PrintFlexibleScreen(this, this.printOption, udcPrint, true);

                CSCR.CheckServer();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
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

        //private void TranLossLotClosed()
        //{
        //    frmLossLot.TranLossLotClosed -= new frmCUSTranLossLot.TranLossLotClosedHandler(TranLossLotClosed);
        //    frmLossLot.Close();
        //}

        #endregion

        #region [Event Definition]

        private void frmCUSTranResRawManagement_Load(object sender, EventArgs e)
        {
            initCtrl();
        }

        private void frmCUSTranResRawManagement_Shown(object sender, EventArgs e)
        {

        }

        private void frmCUSTranResRawManagement_Activated(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {

                // (Required) 
                bIsShown = true;
            }
        }

        private void frmCUSTranResRawManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                // Message Bar를 초기화 합니다.
                MPCF.ShowMessageClear();

                // Memory Flush
                MPCF.FlushMemory();

                //// 조회 조건 Registry에 저장
                //BICF.SaveCondition(this);

                CMNF.SaveRegSetting(Application.ProductName, this.Name, this.cdvLine.Name, MPCF.Trim(this.cdvLine.Text));
                CMNF.SaveRegSetting(Application.ProductName, this.Name, this.cdvOper.Name, MPCF.Trim(this.cdvOper.Text));
                CMNF.SaveRegSetting(Application.ProductName, this.Name, this.txtOperDesc.Name, MPCF.Trim(this.txtOperDesc.Text));
                CMNF.SaveRegSetting(Application.ProductName, this.Name, this.cdvResID.Name, MPCF.Trim(this.cdvResID.Text));
                CMNF.SaveRegSetting(Application.ProductName, this.Name, this.txtResDesc.Name, MPCF.Trim(this.txtResDesc.Text));
                CMNF.SaveRegSetting(Application.ProductName, this.Name, this.chkPrintFlag.Name, (this.chkPrintFlag.Checked == true ? "Y" : "N"));
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("frmCUSTranResRawManagement_FormClosed() \n" + ex.Message, MSG_LEVEL.ERROR, false);
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
                cdvLine.Tag = cdvLine.Text;

                // Validation
                if (string.IsNullOrEmpty(cdvLine.Text) == true)
                {
                    return;
                }

                // 조회 조건 Registry에 저장
                CMNF.SaveRegSetting(Application.ProductName, this.Name, this.cdvLine.Name, MPCF.Trim(this.cdvLine.Text));
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
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
                cdvOper.Text = cdvOper.Show(cdvOper, "Code Desc", "VIEW_OPER_LIST_02", dvcArgu, display, header, "OPER", -1);

                if (MPCF.Trim(cdvOper.Text) != "")
                {
                    if (cdvOper.returnDatas != null && cdvOper.returnDatas.Count > 0)
                    {
                        cdvOper.Tag = cdvOper.returnDatas[0];
                        cdvOper.Text = cdvOper.returnDatas[0];
                        txtOperDesc.Text = cdvOper.returnDatas[1];

                        ViewRawMatList("CLR");
                        MPCF.ClearList(this.spdInstallRawMatList);
                    }
                }
                else
                {
                    cdvOper.Tag = "";
                    txtOperDesc.Text = string.Empty;
                }

                cdvResID.Text = "";
                txtResDesc.Text = "";

                SetPosID();

                // 조회 조건 Registry에 저장
                CMNF.SaveRegSetting(Application.ProductName, this.Name, this.cdvOper.Name, MPCF.Trim(this.cdvOper.Text));
                CMNF.SaveRegSetting(Application.ProductName, this.Name, this.txtOperDesc.Name, MPCF.Trim(this.txtOperDesc.Text));

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
                cdvResID.Text = cdvResID.Show(cdvResID, "Code Desc", "VIEW_INSTALL_RES_LIST", dvcArgu, display, header, "RES_ID", -1);

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
                    ViewRawMatInstall("CLR");
                }

                // 조회 조건 Registry에 저장
                CMNF.SaveRegSetting(Application.ProductName, this.Name, this.cdvResID.Name, MPCF.Trim(this.cdvResID.Text));
                CMNF.SaveRegSetting(Application.ProductName, this.Name, this.txtResDesc.Name, MPCF.Trim(this.txtResDesc.Text));

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void txtRawMatQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == '.'))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (!string.IsNullOrEmpty(txtRawMatQty.Text))
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            if (CheckCondition(CSGC.MP_CHECK_CREATE) == false) { return; }

            if (UpdateRawMatInstall() == true)
            {
                ViewRawMatList("NONE");
                ViewRawMatInstall("CLR");                
            }
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            if (CheckCondition(CSGC.MP_CHECK_DELETE) == false) { return; }

            if (UpdateRawMatRemove(DELETE_OPTION.UNINSTALL) == true)
            {
                ViewRawMatList("CLR");
                ViewRawMatInstall("CLR");
            }            
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER)
                {
                    txtBarcode.Text = MPCF.ToUpper(txtBarcode.Text); // 일괄 대문자

                    if (MPCF.Trim(txtBarcode.Text) == "") { return; }

                    if (this.btnInstall.Enabled == true)
                    {
                        this.btnInstall.PerformClick();
                    }
                    else //if (this.btnRemove.Enabled == true)
                    {
                        this.btnUninstall.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
            }
        }

        private void cdvPosID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Code View Service
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(CSGC.MP_GCM_RES_POSITION_LIST));
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Position", "Position Desc" };
                cdvPosID.Text = cdvPosID.Show(cdvPosID, "View Resource Position", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Position");
                cdvPosID.Tag = cdvPosID.Text;

                if (MPCF.Trim(cdvPosID.Text) != "")
                {
                    if (cdvPosID.returnDatas != null && cdvPosID.returnDatas.Count > 0)
                    {
                        cdvPosID.Tag = cdvPosID.returnDatas[0];
                        cdvPosID.Text = cdvPosID.returnDatas[0];
                        txtPosDesc.Text = cdvPosID.returnDatas[1];
                    }
                }
                else
                {
                    cdvPosID.Tag = "";
                    txtPosDesc.Text = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdRawMatList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            try
            {
                MPCF.FieldClear(this.grbSaveOpt, this.cdvPosID, this.txtPosDesc, this.cdvSetID);
                //this.dtpPackDate.Value = DateTime.Now;

                this.btnInstall.Enabled = true;
                this.dtpPackDate.Enabled = true;
                this.btnUninstall.Enabled = false;
				this.btnRemove.Enabled = false;

                if (this.spdRawMatList.ActiveSheet.RowCount < 1) { return; }

                this.txtMatID.Text = MPCF.Trim(this.spdRawMatList.ActiveSheet.Cells[this.spdRawMatList.ActiveSheet.ActiveRowIndex, (int)RAW_MAT_LIST.MAT_ID].Value);
                this.txtMatVer.Text = MPCF.Trim(this.spdRawMatList.ActiveSheet.Cells[this.spdRawMatList.ActiveSheet.ActiveRowIndex, (int)RAW_MAT_LIST.MAT_VER].Value);
                this.txtLotID.Text = MPCF.Trim(this.spdRawMatList.ActiveSheet.Cells[this.spdRawMatList.ActiveSheet.ActiveRowIndex, (int)RAW_MAT_LIST.LOT_ID].Value);
                this.txtRawMatQty.Text = MPCF.Trim(this.spdRawMatList.ActiveSheet.Cells[this.spdRawMatList.ActiveSheet.ActiveRowIndex, (int)RAW_MAT_LIST.MAT_BOX_QTY].Value);
                this.txtMatType.Text = MPCF.Trim(this.spdRawMatList.ActiveSheet.Cells[this.spdRawMatList.ActiveSheet.ActiveRowIndex, (int)RAW_MAT_LIST.MAT_TYPE].Value);

                //서로 같지 않을 경우는 이미 자재LOT을 생셩한 경우이므로 수량을 변경하지 못하게 한다.
                if (MPCF.Trim(this.txtMatID.Text) != MPCF.Trim(this.txtLotID.Text))
                {
                    this.txtRawMatQty.Enabled = false;
                }
                else
                {
                    this.txtRawMatQty.Enabled = true;
                }

                this.txtBarcode.Focus();
                this.txtBarcode.SelectAll();

                if (MPCF.Trim(this.txtMatID.Text) != MPCF.Trim(this.txtLotID.Text))
                {
                    this.txtRawMatQty.Text = MPCF.Trim(this.spdRawMatList.ActiveSheet.Cells[this.spdRawMatList.ActiveSheet.ActiveRowIndex, (int)RAW_MAT_LIST.QTY].Value);
                    this.txtBarcode.Text = MPCF.Trim(this.spdRawMatList.ActiveSheet.Cells[this.spdRawMatList.ActiveSheet.ActiveRowIndex, (int)RAW_MAT_LIST.LOT_DESC].Value);
                    this.txtBarcode.Focus();
                }

                if (MPCF.Trim(this.cdvResID.Text).Equals(""))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(410));
                    return;
                }

                if (MPCF.Trim(this.cdvResID.Text).Substring(0, 3) == "TAB"
                    && MPCF.Trim(this.txtMatType.Text) == "RBN")
                {
                    this.cdvSetID.Enabled = true;
                }
                else if (MPCF.Trim(this.cdvResID.Text).Substring(0, 3) == "FRM"
                        && MPCF.Trim(this.txtMatType.Text) == "FRM")
                {
                    this.cdvSetID.Enabled = true;
                }
                else
                {
                    this.cdvSetID.Text = string.Empty;
                    this.cdvSetID.Tag = "";
                    this.cdvSetID.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
            }
        }

        private void spdInstallRawMatList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            try
            {
                MPCF.FieldClear(this.grbSaveOpt, this.cdvPosID, this.txtPosDesc, this.cdvSetID);
                //this.dtpPackDate.Value = DateTime.Now;

                this.btnInstall.Enabled = false;
                this.dtpPackDate.Enabled = false;
                this.btnUninstall.Enabled = true;
                this.txtRawMatQty.Enabled = true;
				this.btnRemove.Enabled = true;

                if (this.spdInstallRawMatList.ActiveSheet.RowCount < 1) { return; }

                this.txtMatID.Text = MPCF.Trim(this.spdInstallRawMatList.ActiveSheet.Cells[this.spdInstallRawMatList.ActiveSheet.ActiveRowIndex, (int)INSTALL_RAW_LIST.MAT_ID].Value);
                this.txtMatVer.Text = MPCF.Trim(this.spdInstallRawMatList.ActiveSheet.Cells[this.spdInstallRawMatList.ActiveSheet.ActiveRowIndex, (int)INSTALL_RAW_LIST.MAT_VER].Value);
                this.txtLotID.Text = MPCF.Trim(this.spdInstallRawMatList.ActiveSheet.Cells[this.spdInstallRawMatList.ActiveSheet.ActiveRowIndex, (int)INSTALL_RAW_LIST.LOT_ID].Value);
                this.txtRawMatQty.Text = MPCF.Trim(this.spdInstallRawMatList.ActiveSheet.Cells[this.spdInstallRawMatList.ActiveSheet.ActiveRowIndex, (int)INSTALL_RAW_LIST.QTY].Value);
                this.txtInstallTime.Text = MPCF.Trim(this.spdInstallRawMatList.ActiveSheet.Cells[this.spdInstallRawMatList.ActiveSheet.ActiveRowIndex, (int)INSTALL_RAW_LIST.INSTALL_TIME].Value);
                this.cdvPosID.Text = MPCF.Trim(this.spdInstallRawMatList.ActiveSheet.Cells[this.spdInstallRawMatList.ActiveSheet.ActiveRowIndex, (int)INSTALL_RAW_LIST.POS_ID].Value);

                this.txtInstallTime.Text = this.txtInstallTime.Text.Replace(" ", "").Replace("-", "").Replace(":", "").Replace(".", "");

                if (MPCF.Trim(this.cdvResID.Text).Substring(0, 3) == "TAB"
                    && MPCF.Trim(this.txtMatType.Text) == "RBN")
                {
                    this.cdvSetID.Enabled = true;
                }
                else if (MPCF.Trim(this.cdvResID.Text).Substring(0, 3) == "FRM"
                        && MPCF.Trim(this.txtMatType.Text) == "FRM")
                {
                    this.cdvSetID.Enabled = true;
                }
                else
                {
                    this.cdvSetID.Text = string.Empty;
                    this.cdvSetID.Tag = "";
                    this.cdvSetID.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
            }
        }

        private void btnPrintLabel_Click(object sender, EventArgs e)
        {
            ProcPrint();
        }

        private void cdvResID_ValueChanged(object sender, EventArgs e)
        {
            ViewRawMatList("CLR");
            ViewRawMatInstall("CLR");
        }

        private void cdvSetID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                string sTableName = string.Empty;

                if (MPCF.Trim(this.cdvResID.Text) == string.Empty) {return;}
                if (MPCF.Trim(this.txtMatType.Text) == string.Empty) { return; }

                if (MPCF.Trim(this.cdvResID.Text).Substring(0, 3) == "TAB"
                    && MPCF.Trim(this.txtMatType.Text) == "RBN")
                {
                    sTableName = MPCF.Trim(CSGC.MP_GCM_RES_SETID_TAB_LIST);
                }
                else if (MPCF.Trim(this.cdvResID.Text).Substring(0, 3) == "FRM"
                        && MPCF.Trim(this.txtMatType.Text) == "FRM")
                {
                    sTableName = MPCF.Trim(CSGC.MP_GCM_RES_SETID_FRM_LIST);
                }
                else
                {
                    sTableName = MPCF.Trim(CSGC.MP_GCM_RES_SETID_TAB_LIST);
                }

                // Code View Service
                TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", sTableName);
                string[] display = new string[] { "KEY_1", "DATA_1" };
                string[] header = new string[] { "Set ID", "Set Desc" };
                cdvSetID.Text = cdvSetID.Show(cdvSetID, "View Resource Set ID", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "Set ID");
                cdvSetID.Tag = cdvSetID.Text;

                if (MPCF.Trim(cdvSetID.Text) != "")
                {
                    if (cdvSetID.returnDatas != null && cdvSetID.returnDatas.Count > 0)
                    {
                        cdvSetID.Tag = cdvSetID.returnDatas[0];
                        cdvSetID.Text = cdvSetID.returnDatas[0];
                    }
                }
                else
                {
                    cdvSetID.Tag = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ProcPrint();
        }

        private void btnPrintOpt_Click(object sender, EventArgs e)
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

        private void btnView1_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(spdRawMatList);
            MPCF.ClearList(spdInstallRawMatList);

            this.ViewRawMatList("CLR");

            this.ViewRawMatInstall("CLR");
        }

        private void btnView2_Click(object sender, EventArgs e)
        {
            this.ViewRawMatInstall("CLR");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (CheckCondition(CSGC.MP_CHECK_CANCEL) == false) { return; }

            if (UpdateRawMatCancel() == true)
            {
                ViewRawMatList("CLR");
                ViewRawMatInstall("CLR");                
            }
        }

        private void chkRepairMat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRepairMat.Checked)
            {
                txtRawMatQty.Value = "0";
                txtBarcode.Text = "REPAIR_MAT";
                cdvMaterial.Text = "";
                cdvMaterial.Visible = true;
                txtMatID.Visible = false;
                txtRawMatQty.Enabled = true;
                txtLotID.Text = "";
            }
            else
            {
                txtBarcode.Text = "";
                cdvMaterial.Visible = false;
                txtMatID.Visible = true;
            }
        }

        private void btnMatLossLot_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (spdInstallRawMatList.ActiveSheet.ActiveRowIndex < 0)
            //    {
            //        MPCF.ShowMsgBox(MPCF.GetMessage(199));
            //        return;
            //    }

            //    if (frmLossLot == null || string.IsNullOrEmpty(frmLossLot.Text))
            //    {
            //        frmLossLot = new frmCUSTranLossLot();
            //    }

            //    frmLossLot.gLotID = spdInstallRawMatList.ActiveSheet.Cells[spdInstallRawMatList.ActiveSheet.ActiveRowIndex, (int)INSTALL_RAW_LIST.LOT_ID].Value.ToString();

            //    MenuInfoTag menuInfo = new MenuInfoTag();
            //    menuInfo.c_func_type = 'F';
            //    menuInfo.s_assembly_file = "SOI.Solar.dll";
            //    menuInfo.s_assembly_name = "SOI.Solar.frmCUSTranLossLot";
            //    menuInfo.s_func_desc = "Raw Material Loss Lot";
            //    menuInfo.s_func_name = "";
            //    MPGV.gIMdiForm.OpenMenu(menuInfo, frmLossLot);
            //}
            //catch (Exception ex)
            //{
            //    MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            //}
        }

        #endregion

        private void cdvMaterial_CodeViewButtonClick(object sender, EventArgs e)
        {
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            try
            {
                ArrDVC = new TPDR.DirectViewCond[2];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$OPER";
                ArrDVC[1].sCondition_Value = MPCF.Trim("W410");

                string[] header = new string[] { "Material ID", "Material Desc", "Qty" };
                string[] display = new string[] { "MAT_ID", "MAT_DESC", "QTY" };

                cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "Material List", "VIEW_REPAIR_OPER_MAT_LIST", ArrDVC, display, header, "MAT_ID", -1);

                if (cdvMaterial.returnDatas != null && cdvMaterial.returnDatas.Count > 0)
                {
                    cdvMaterial.Text = cdvMaterial.returnDatas[0];
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnCellBatch_Click(object sender, EventArgs e)
        {
            try
            {
                //셀배치작업 화면
                BICF.OpenMenu("SOI3004");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            } 
        }

        private void btnLossLot_Click(object sender, EventArgs e)
        {
            try
            {
                MPGV.gsCurrentLot_ID = txtLotID.Text;
				MPGV.gsCurrentOperID = cdvOper.Text;

                //모듈내 불량자재등록 화면
                BICF.OpenMenu("SOI2012");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            } 
        }

        private void spdRawMatList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (spdRawMatList.ActiveSheet.RowCount == 0) return;

                ViewSelectRawMatInstall("CLR", spdRawMatList.ActiveSheet.Cells[e.Row, (int)RAW_MAT_LIST.MAT_ID].Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
            }
        }

        private void spdInstallRawMatList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader && e.Column == 0)
            {
                //전체 헤더 선택
                string s_hChk = string.Empty;

                if (spdInstallRawMatList.Sheets[0].ColumnHeader.Cells[0, 0].Text == "True")
                {
                    s_hChk = "False";
                }
                else
                {
                    s_hChk = "True";
                }

                spdInstallRawMatList.Sheets[0].ColumnHeader.Cells[0, 0].Text = s_hChk;

                for (int i = 0; i < spdInstallRawMatList.Sheets[0].Rows.Count; i++)
                {
                    spdInstallRawMatList.Sheets[0].Cells[i, 0].Text = s_hChk;
                }
            }
        }

		private void btnRemove_Click(object sender, EventArgs e)
		{
			if (CheckCondition(CSGC.MP_CHECK_DELETE) == false) { return; }

			if (UpdateRawMatRemove(DELETE_OPTION.REMOVE) == true)
			{
				ViewRawMatList("CLR");
				ViewRawMatInstall("CLR");
			}  
		}

    }
}
