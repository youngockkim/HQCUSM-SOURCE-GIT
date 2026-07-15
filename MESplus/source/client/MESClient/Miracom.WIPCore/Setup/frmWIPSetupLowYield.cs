//-----------------------------------------------------------------------------
//
//   System      : MES   
//   File Name   : frmWIPSetupLowYield.cs
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - View_Alarm_Msg() : View Lot Alarm Message
//       - View_Event() : View Event
//       - UpdateAlarmMsg() : Create/Update/Delete Lot Alarm Message
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2007-12-13 : Created by No Aiden, Who made?
//
//
//   Copyright(C) 1998-2007 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using FarPoint.Win.Spread;

using Miracom.UI.Controls;
using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;
using Miracom.BASCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPSetupLowYield : Miracom.MESCore.SetupForm02
    {
        public frmWIPSetupLowYield()
        {
            InitializeComponent();
        }

        #region " Enum Definition"

        private enum LOT_CMF_COL
        {
            Desc,
            Cmf1,
            Cmf2,
            Cmf3,
            Cmf4,
            Cmf5,
            Cmf6,
            Cmf7,
            Cmf8,
            Cmf9,
            Cmf10,
            Cmf11,
            Cmf12,
            Cmf13,
            Cmf14,
            Cmf15,
            Cmf16,
            Cmf17,
            Cmf18,
            Cmf19,
            Cmf20,
            Key_Code,
            YIELD_TYPE,
            UNIT
        }

        private enum YIELD_CONTROL
        {
            Code,
            Btn_Code,
            Calc_Unit_Type,
            btn_Unit_Type,
            AQL_Type,
            btn_AQL_Type,
            Upper_Yield,
            Lower_Yield,
            Check_Range,
            Check_Before_Day,
            Affect_Range_Before,
            Affect_range_After,
            Alarm_Id,
            Btn_Alarm_Id,
            Protect_end_Flag,
            Desc
        }
        #endregion

        #region " Constant Definition"

        private string s_loss_table = "LOSS_CODE";
        private FarPoint.Win.Spread.FpSpread lspd_table;

        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
        private const int CHECK_COL = 0;
        private const int KEY_1_COL = 1;
        private const int KEY_1_BTN = 2;
        private const int KEY_2_COL = 3;
        private const int KEY_2_BTN = 4;
        private const int KEY_3_COL = 5;
        private const int KEY_3_BTN = 6;
        private const int KEY_4_COL = 7;
        private const int KEY_4_BTN = 8;
        private const int KEY_5_COL = 9;
        private const int KEY_5_BTN = 10;
        private const int KEY_6_COL = 11;
        private const int KEY_6_BTN = 12;
        private const int KEY_7_COL = 13;
        private const int KEY_7_BTN = 14;
        private const int KEY_8_COL = 15;
        private const int KEY_8_BTN = 16;
        private const int KEY_9_COL = 17;
        private const int KEY_9_BTN = 18;
        private const int KEY_10_COL = 19;
        private const int KEY_10_BTN = 20;
        private const int DATA_1_COL = 21;
        private const int DATA_1_BTN = 22;
        private const int DATA_2_COL = 23;
        private const int DATA_2_BTN = 24;
        private const int DATA_3_COL = 25;
        private const int DATA_3_BTN = 26;
        private const int DATA_4_COL = 27;
        private const int DATA_4_BTN = 28;
        private const int DATA_5_COL = 29;
        private const int DATA_5_BTN = 30;
        private const int DATA_6_COL = 31;
        private const int DATA_6_BTN = 32;
        private const int DATA_7_COL = 33;
        private const int DATA_7_BTN = 34;
        private const int DATA_8_COL = 35;
        private const int DATA_8_BTN = 36;
        private const int DATA_9_COL = 37;
        private const int DATA_9_BTN = 38;
        private const int DATA_10_COL = 39;
        private const int DATA_10_BTN = 40;

        private const string COLUMN_DATA = "DATA";
        private const string COLUMN_KEY = "KEY";
        private const string GCM_TBL_DAT = "MGCMTBLDAT";
        private const string GCM_TBL_LAG = "MGCMLAGDAT";

        public struct Format
        {
            public string Col_Fmt;
            public int Col_Size;
        };
        private Format[] FormatTbl = new Format[41];

        #endregion

        #region " Variable Definition "

        private bool bLoadFlag;
        private string sMatID ="";
        private int iMatVersion = 0;
        private string sFlow = "";
        private int iFlowSeqNum = 0;
        private string sOper = "";
        private string sResID = "";
        private string sSubResID = "";

        private TRSNode TABLE;

        private int i_last_selected_idx;
        private int i_last_selected_desc_idx;

        #endregion

        #region " Function Definition "

        #region " Clear Data "
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
                    MPCF.FieldClear(grpCreateInfo);
                    MPCF.FieldClear(grpYieldInfo);
                    MPCF.FieldClear(grpCrtCmf);
                    MPCF.FieldClear(grpCodeBaseYield);
                    MPCF.FieldClear(pnlDes);
                    MPCF.FieldClear(grpActionInfo);
                    MPCF.FieldClear(grpCmf);

                    MPCF.ClearList(spdLowCmfList, true);
                    MPCF.ClearList(spdYieldList, true);

                    txtCreateUser.Text = "";
                    txtCreateTime.Text = "";
                    txtUpdateUser.Text = "";
                    txtUpdateTime.Text = "";
                }
                if (ProcStep == "2")
                {
                    MPCF.FieldClear(grpCreateInfo);
                    MPCF.FieldClear(grpYieldInfo);
                    MPCF.FieldClear(grpCrtCmf);
                    MPCF.FieldClear(grpCodeBaseYield);
                    MPCF.FieldClear(pnlDes);
                    MPCF.FieldClear(grpActionInfo);
                    MPCF.FieldClear(grpCmf);

                    MPCF.ClearList(spdYieldList, true);

                    txtCreateUser.Text = "";
                    txtCreateTime.Text = "";
                    txtUpdateUser.Text = "";
                    txtUpdateTime.Text = "";

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        #endregion

        #region " Check Condition "
        // CheckCondition()
        //       - check Create/Update/Delete condition
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String      : Function Name
        //       - Optional ByVal ProcStep As String		: Create/Update/Delete 구분??
        //
        private bool CheckCondition(char ProcStep)
        {
            switch (ProcStep)
            {

                case MPGC.MP_STEP_CREATE:

                    if (CheckCMFItemValue() == false)
                    {
                        tabLowYieldinfo.SelectedTab = tabCMF;
                        return false;
                    }
                    if (MPCF.CheckValue(cdvLowYieldType, 1) == false)
                    {
                        cdvLowYieldType.Focus();
                        return false;
                    }
                    if (MPCF.CheckValue(cdvCalUnit, 1) == false)
                    {
                        cdvCalUnit.Focus();
                        return false;
                    }
                    if (MPCF.CheckValue(cdvCalUnitType, 1) == false)
                    {
                        cdvCalUnitType.Focus();
                        return false;
                    }
                    if (MPCF.CheckValue(cdvYieldBase, 1) == false)
                    {
                        cdvYieldBase.Focus();
                        return false;
                    }
                    if (cdvYieldBase.Text == "4")
                    {
                        if (MPCF.CheckValue(cdvYieldBaseOper, 1) == false)
                        {
                            cdvYieldBaseOper.Focus();
                            return false;
                        }
                    }
                    if (MPCF.CheckValue(cdvCheckTrans, 1) == false)
                    {
                        cdvCheckTrans.Focus();
                        return false;
                    }
                    if ((cdvYieldBase.Text == MPGC.MP_LYD_BASE_OPER_IN || cdvYieldBase.Text == MPGC.MP_LYD_BASE_OPER_START ||
                        cdvYieldBase.Text == MPGC.MP_LYD_BASE_OPER_OUT) && MPCF.Trim(cdvYieldBaseOper.Text)=="")
                    {
                        cdvYieldBaseOper.Focus();
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        return false;
                    }
                    else if ((cdvYieldBase.Text == MPGC.MP_LYD_BASE_LOT_STS || cdvYieldBase.Text == MPGC.MP_LYD_BASE_LOT_EXT) && 
                        MPCF.Trim(cdvLotStatus.Text)=="")
                    {
                        cdvYieldBaseOper.Focus();
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        return false;
                    }
                  break;

                case MPGC.MP_STEP_UPDATE:

                    if (CheckCMFItemValue() == false)
                    {
                        tabLowYieldinfo.SelectedTab = tabCMF;
                        return false;
                    }
                    if (MPCF.CheckValue(cdvLowYieldType, 1) == false)
                    {
                        cdvLowYieldType.Focus();
                        return false;
                    }
                    if (MPCF.CheckValue(cdvCalUnit, 1) == false)
                    {
                        cdvCalUnit.Focus();
                        return false;
                    }
                    if (MPCF.CheckValue(cdvCalUnitType, 1) == false)
                    {
                        cdvCalUnitType.Focus();
                        return false;
                    }
                    if (MPCF.CheckValue(cdvYieldBase, 1) == false)
                    {
                        cdvYieldBase.Focus();
                        return false;
                    }
                    if (cdvYieldBase.Text == "4")
                    {
                        if (MPCF.CheckValue(cdvYieldBaseOper, 1) == false)
                        {
                            cdvYieldBaseOper.Focus();
                            return false;
                        }
                    }
                    if (MPCF.CheckValue(cdvCheckTrans, 1) == false)
                    {
                        cdvCheckTrans.Focus();
                        return false;
                    }
                    if ((cdvYieldBase.Text == MPGC.MP_LYD_BASE_OPER_IN || cdvYieldBase.Text == MPGC.MP_LYD_BASE_OPER_START ||
                       cdvYieldBase.Text == MPGC.MP_LYD_BASE_OPER_OUT) && MPCF.Trim(cdvYieldBaseOper.Text) == "")
                    {
                        cdvYieldBaseOper.Focus();
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        return false;
                    }
                    else if ((cdvYieldBase.Text == MPGC.MP_LYD_BASE_LOT_STS || cdvYieldBase.Text == MPGC.MP_LYD_BASE_LOT_EXT) &&
                        MPCF.Trim(cdvLotStatus.Text) == "")
                    {
                        cdvYieldBaseOper.Focus();
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        return false;
                    }
                    break;

                case MPGC.MP_STEP_DELETE:

                     if (CheckCMFItemValue() == false)
                    {
                        tabLowYieldinfo.SelectedTab = tabCMF;
                        return false;
                    }
                    if (MPCF.CheckValue(cdvLowYieldType, 1) == false)
                    {
                        cdvLowYieldType.Focus();
                        return false;
                    }
                    if (MPCF.CheckValue(cdvCalUnit, 1) == false)
                    {
                        cdvCalUnit.Focus();
                        return false;
                    }
                    if (MPCF.CheckValue(cdvCalUnitType, 1) == false)
                    {
                        cdvCalUnitType.Focus();
                        return false;
                    }
                    if (MPCF.CheckValue(cdvYieldBase, 1) == false)
                    {
                        cdvYieldBase.Focus();
                        return false;
                    }
                    if (cdvYieldBase.Text == "4")
                    {
                        if (MPCF.CheckValue(cdvYieldBaseOper, 1) == false)
                        {
                            cdvYieldBaseOper.Focus();
                            return false;
                        }
                    }
                    if (MPCF.CheckValue(cdvCheckTrans, 1) == false)
                    {
                        cdvCheckTrans.Focus();
                        return false;
                    }
                    break;
            }
            return true;
        }
        #endregion

        #region " View MFO Setting Data List "
        //
        // ViewMFOSettingDataList()
        //       - Get setting data list
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool ViewMFOSettingDataList()
        {
            TRSNode in_node = new TRSNode("Sql_In");
            TRSNode out_node = new TRSNode("Sql_Out");
            StringBuilder sb;

            MPCF.InitListView(tvMFO.GetListView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("NEXT_ROW", 0);

            sb = new StringBuilder();

            switch (tvMFO.SelectLevel)
            {
                case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                    sb.Append("SELECT MAT_ID, MAT_VER, FLOW, OPER FROM MWIPQTMDEF ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND MAT_ID <> ' ' ");
                    sb.Append("AND MAT_VER > 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, FLOW, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                    sb.Append("SELECT FLOW, OPER FROM MWIPQTMDEF ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND MAT_ID = ' ' ");
                    sb.Append("AND MAT_VER = 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY FLOW, OPER ");
                    sb.Append("ORDER BY FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.O:
                    sb.Append("SELECT OPER FROM MWIPQTMDEF ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND MAT_ID = ' ' ");
                    sb.Append("AND MAT_VER = 0 AND FLOW = ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY OPER ");
                    sb.Append("ORDER BY OPER ASC");
                    break;

            }

            in_node.AddString("SQL", sb.ToString());

            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }
                if (out_node.StatusValue != MPGC.MP_SUCCESS_STATUS)
                {
                    MPCF.ShowMsgBox(MPCF.MakeErrorMsg(out_node.MsgCode, out_node.Msg, out_node.DBErrMsg, out_node.FieldMsg));
                    return false;
                }

                MPCR.FillDataView(tvMFO.GetListView, out_node, false, (int)SMALLICON_INDEX.IDX_MODULE, false);

                
                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));

            } while (in_node.GetInt("NEXT_ROW") > 0);  // (Sql_In.next_row > 0);

            return true;
        }
        #endregion

        #region " Update Low Yield Setup "

        private bool UpdateLowYieldSetup(char c_step)
        {
            TRSNode in_node = new TRSNode("Low_Yield_Setup_In");
            TRSNode out_node = new TRSNode("Low_Yield_Setup_Out");
            string s_temp;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("MAT_ID", MPCF.Trim(sMatID));
                in_node.AddInt("MAT_VER", MPCF.ToInt(iMatVersion));
                in_node.AddString("FLOW", MPCF.Trim(sFlow));
                in_node.AddInt("FLOW_SEQ_NUM", MPCF.Trim(iFlowSeqNum));
                in_node.AddString("OPER", MPCF.Trim(sOper));
                in_node.AddString("RES_ID", MPCF.Trim(sResID));
                in_node.AddString("SUBRES_ID", MPCF.Trim(sSubResID));

                if (MPCF.Trim(cboCVType.Text).Length > 2)
                {
                    in_node.AddString("CV_TYPE", MPCF.Trim(cboCVType.Text).Substring(0,2));
                }

                s_temp = MPCF.Trim(cdvLowYieldType.Text) + ":" + in_node.GetString("CV_TYPE") + ":" + MPCF.Trim(cdvCalUnit.Text) + ":" + MPCF.Trim(cdvCalUnitType.Text);
                s_temp = s_temp + ":" + MPCF.Trim(cdvYieldBase.Text) + ":" + MPCF.Trim(cdvYieldBaseOper.Text) + ":" + MPCF.Trim(cdvCheckTrans.Text);
                in_node.AddString("KEY_CODE", s_temp);

                in_node.AddString("YIELD_TYPE", MPCF.Trim(cdvLowYieldType.Text));
                in_node.AddString("UNIT", MPCF.Trim(cdvCalUnit.Text));
                in_node.AddString("UNIT_TYPE", MPCF.Trim(cdvCalUnitType.Text));
                in_node.AddString("AQL_TYPE", MPCF.Trim(cdvAQLType.Text));
                in_node.AddString("YIELD_BASE", MPCF.Trim(cdvYieldBase.Text));
                in_node.AddString("BASE_OPER", MPCF.Trim(cdvYieldBaseOper.Text));
                in_node.AddString("BASE_COLUMN", MPCF.Trim(cdvLotStatus.Text));
                in_node.AddDouble("TOT_UPPER_YIELD", MPCF.ToDbl(txtTotalUpper.Text));
                in_node.AddDouble("TOT_LOWER_YIELD", MPCF.ToDbl(txtTotalLower.Text));
                in_node.AddString("CHECK_TYPE", MPCF.Trim(cdvCheckTrans.Text));

                if (spdYieldList.ActiveSheet.RowCount > 0)
                {
                    SetYieldControl(ref in_node);
                }

                if (chkProtect.Checked == true)
                    in_node.AddChar("PROTECT_END_FLAG", "Y");
                else
                {
                    in_node.AddChar("PROTECT_END_FLAG", "N");
                    in_node.AddString("ALARM_ID", MPCF.Trim(cdvAlarmID.Text));
                }

                in_node.AddString("LOT_CMF_1", MPCF.Trim(cdvCrtCmf1.Text));
                in_node.AddString("LOT_CMF_2", MPCF.Trim(cdvCrtCmf2.Text));
                in_node.AddString("LOT_CMF_3", MPCF.Trim(cdvCrtCmf3.Text));
                in_node.AddString("LOT_CMF_4", MPCF.Trim(cdvCrtCmf4.Text));
                in_node.AddString("LOT_CMF_5", MPCF.Trim(cdvCrtCmf5.Text));
                in_node.AddString("LOT_CMF_6", MPCF.Trim(cdvCrtCmf6.Text));
                in_node.AddString("LOT_CMF_7", MPCF.Trim(cdvCrtCmf7.Text));
                in_node.AddString("LOT_CMF_8", MPCF.Trim(cdvCrtCmf8.Text));
                in_node.AddString("LOT_CMF_9", MPCF.Trim(cdvCrtCmf9.Text));
                in_node.AddString("LOT_CMF_10", MPCF.Trim(cdvCrtCmf10.Text));
                in_node.AddString("LOT_CMF_11", MPCF.Trim(cdvCrtCmf11.Text));
                in_node.AddString("LOT_CMF_12", MPCF.Trim(cdvCrtCmf12.Text));
                in_node.AddString("LOT_CMF_13", MPCF.Trim(cdvCrtCmf13.Text));
                in_node.AddString("LOT_CMF_14", MPCF.Trim(cdvCrtCmf14.Text));
                in_node.AddString("LOT_CMF_15", MPCF.Trim(cdvCrtCmf15.Text));
                in_node.AddString("LOT_CMF_16", MPCF.Trim(cdvCrtCmf16.Text));
                in_node.AddString("LOT_CMF_17", MPCF.Trim(cdvCrtCmf17.Text));
                in_node.AddString("LOT_CMF_18", MPCF.Trim(cdvCrtCmf18.Text));
                in_node.AddString("LOT_CMF_19", MPCF.Trim(cdvCrtCmf19.Text));
                in_node.AddString("LOT_CMF_20", MPCF.Trim(cdvCrtCmf20.Text));

                in_node.AddString("LOW_YIELD_CMF_1", MPCF.Trim(cdvCmf1.Text));
                in_node.AddString("LOW_YIELD_CMF_2", MPCF.Trim(cdvCmf2.Text));
                in_node.AddString("LOW_YIELD_CMF_3", MPCF.Trim(cdvCmf3.Text));
                in_node.AddString("LOW_YIELD_CMF_4", MPCF.Trim(cdvCmf4.Text));
                in_node.AddString("LOW_YIELD_CMF_5", MPCF.Trim(cdvCmf5.Text));
                in_node.AddString("LOW_YIELD_CMF_6", MPCF.Trim(cdvCmf6.Text));
                in_node.AddString("LOW_YIELD_CMF_7", MPCF.Trim(cdvCmf7.Text));
                in_node.AddString("LOW_YIELD_CMF_8", MPCF.Trim(cdvCmf8.Text));
                in_node.AddString("LOW_YIELD_CMF_9", MPCF.Trim(cdvCmf9.Text));
                in_node.AddString("LOW_YIELD_CMF_10", MPCF.Trim(cdvCmf10.Text));
                in_node.AddString("LOW_YIELD_CMF_11", MPCF.Trim(cdvCmf11.Text));
                in_node.AddString("LOW_YIELD_CMF_12", MPCF.Trim(cdvCmf12.Text));
                in_node.AddString("LOW_YIELD_CMF_13", MPCF.Trim(cdvCmf13.Text));
                in_node.AddString("LOW_YIELD_CMF_14", MPCF.Trim(cdvCmf14.Text));
                in_node.AddString("LOW_YIELD_CMF_15", MPCF.Trim(cdvCmf15.Text));
                in_node.AddString("LOW_YIELD_CMF_16", MPCF.Trim(cdvCmf16.Text));
                in_node.AddString("LOW_YIELD_CMF_17", MPCF.Trim(cdvCmf17.Text));
                in_node.AddString("LOW_YIELD_CMF_18", MPCF.Trim(cdvCmf18.Text));
                in_node.AddString("LOW_YIELD_CMF_19", MPCF.Trim(cdvCmf19.Text));
                in_node.AddString("LOW_YIELD_CMF_20", MPCF.Trim(cdvCmf20.Text));

                in_node.AddString("DESCRIPTION", txtDesciption.Text);
                in_node.AddString("CREATE_USER", MPGV.gsUserID);
                in_node.AddString("UPDATE_USER", MPGV.gsUserID);

                if (MPCR.CallService("WIP", "WIP_Update_Low_Yield", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.StatusValue != MPGC.MP_SUCCESS_STATUS)
                {
                    MPCF.ShowMsgBox(MPCF.MakeErrorMsg(out_node.MsgCode, out_node.Msg, out_node.DBErrMsg, out_node.FieldMsg));
                    return false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return true;
        }

        #endregion

        #region " View Low Yield Setup "

        private bool ViewLowYieldSetup(char c_step, int iRow)
        {
            TRSNode in_node = new TRSNode("Updae_tView_Low_Yield_Setup_In");
            TRSNode out_node = new TRSNode("Update_View_Low_Yield_Setup_Out");

            int i = 0;
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("MAT_ID", MPCF.Trim(sMatID));
                in_node.AddInt("MAT_VER", MPCF.ToInt(iMatVersion));
                in_node.AddString("FLOW", MPCF.Trim(sFlow));
                in_node.AddInt("FLOW_SEQ_NUM", MPCF.Trim(iFlowSeqNum));
                in_node.AddString("OPER", MPCF.Trim(sOper));
                in_node.AddString("RES_ID", MPCF.Trim(sResID));
                in_node.AddString("SUBRES_ID", MPCF.Trim(sSubResID));

                in_node.AddString("LOT_CMF_1", spdLowCmfList.ActiveSheet.Cells[iRow, (int)LOT_CMF_COL.Cmf1].Value);
                in_node.AddString("LOT_CMF_2", spdLowCmfList.ActiveSheet.Cells[iRow, (int)LOT_CMF_COL.Cmf2].Value);
                in_node.AddString("LOT_CMF_3", spdLowCmfList.ActiveSheet.Cells[iRow, (int)LOT_CMF_COL.Cmf3].Value);
                in_node.AddString("LOT_CMF_4", spdLowCmfList.ActiveSheet.Cells[iRow, (int)LOT_CMF_COL.Cmf4].Value);
                in_node.AddString("LOT_CMF_5", spdLowCmfList.ActiveSheet.Cells[iRow, (int)LOT_CMF_COL.Cmf5].Value);
                in_node.AddString("LOT_CMF_6", spdLowCmfList.ActiveSheet.Cells[iRow, (int)LOT_CMF_COL.Cmf6].Value);
                in_node.AddString("LOT_CMF_7", spdLowCmfList.ActiveSheet.Cells[iRow, (int)LOT_CMF_COL.Cmf7].Value);
                in_node.AddString("LOT_CMF_8", spdLowCmfList.ActiveSheet.Cells[iRow, (int)LOT_CMF_COL.Cmf8].Value);
                in_node.AddString("LOT_CMF_9", spdLowCmfList.ActiveSheet.Cells[iRow, (int)LOT_CMF_COL.Cmf9].Value);
                in_node.AddString("LOT_CMF_10", spdLowCmfList.ActiveSheet.Cells[iRow, (int)LOT_CMF_COL.Cmf10].Value);
                in_node.AddString("LOT_CMF_11", spdLowCmfList.ActiveSheet.Cells[iRow, (int)LOT_CMF_COL.Cmf11].Value);
                in_node.AddString("LOT_CMF_12", spdLowCmfList.ActiveSheet.Cells[iRow, (int)LOT_CMF_COL.Cmf12].Value);
                in_node.AddString("LOT_CMF_13", spdLowCmfList.ActiveSheet.Cells[iRow, (int)LOT_CMF_COL.Cmf13].Value);
                in_node.AddString("LOT_CMF_14", spdLowCmfList.ActiveSheet.Cells[iRow, (int)LOT_CMF_COL.Cmf14].Value);
                in_node.AddString("LOT_CMF_15", spdLowCmfList.ActiveSheet.Cells[iRow, (int)LOT_CMF_COL.Cmf15].Value);
                in_node.AddString("LOT_CMF_16", spdLowCmfList.ActiveSheet.Cells[iRow, (int)LOT_CMF_COL.Cmf16].Value);
                in_node.AddString("LOT_CMF_17", spdLowCmfList.ActiveSheet.Cells[iRow, (int)LOT_CMF_COL.Cmf17].Value);
                in_node.AddString("LOT_CMF_18", spdLowCmfList.ActiveSheet.Cells[iRow, (int)LOT_CMF_COL.Cmf18].Value);
                in_node.AddString("LOT_CMF_19", spdLowCmfList.ActiveSheet.Cells[iRow, (int)LOT_CMF_COL.Cmf19].Value);
                in_node.AddString("LOT_CMF_20", spdLowCmfList.ActiveSheet.Cells[iRow, (int)LOT_CMF_COL.Cmf20].Value);

                in_node.AddString("KEY_CODE", spdLowCmfList.ActiveSheet.Cells[iRow, (int)LOT_CMF_COL.Key_Code].Value);

                if (MPCR.CallService("WIP", "WIP_View_Low_Yield", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.StatusValue != MPGC.MP_SUCCESS_STATUS)
                {
                    MPCF.ShowMsgBox(MPCF.MakeErrorMsg(out_node.MsgCode, out_node.Msg, out_node.DBErrMsg, out_node.FieldMsg));
                    return false;
                }

                cdvLowYieldType.Text = MPCF.Trim(out_node.GetString("YIELD_TYPE"));

                cboCVType.SelectedIndex = 0;
                for (i = 0; i < cboCVType.Items.Count; i++)
                {
                    if (MPCF.Trim(cboCVType.Items[i]).Length > 2)
                    {
                        if (MPCF.Trim(cboCVType.Items[i]).Substring(0, 2) == out_node.GetString("CV_TYPE"))
                        {
                            cboCVType.SelectedIndex = i;
                            break;
                        }
                    }
                }

                cdvCalUnit.Text = MPCF.Trim(out_node.GetString("UNIT"));
                cdvCalUnitType.Text = MPCF.Trim(out_node.GetString("UNIT_TYPE"));
                cdvAQLType.Text = MPCF.Trim(out_node.GetString("AQL_TYPE"));
                cdvYieldBase.Text = out_node.GetString("YIELD_BASE");
                cdvYieldBaseOper.Text = out_node.GetString("BASE_OPER");
                cdvLotStatus.Text = out_node.GetString("BASE_COLUMN");
                txtTotalUpper.Text = MPCF.Trim(out_node.GetDouble("TOT_UPPER_YIELD"));
                txtTotalLower.Text = MPCF.Trim(out_node.GetDouble("TOT_LOWER_YIELD"));
                cdvCheckTrans.Text = out_node.GetString("CHECK_TYPE");
                cdvAlarmID.Text = out_node.GetString("ALARM_ID");
                txtDesciption.Text = out_node.GetString("DESCRIPTION");
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtCreateUser.Text = out_node.GetString("CREATE_USER");
                txtUpdateUser.Text = out_node.GetString("UPDATE_USER");
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                if (out_node.GetChar("PROTECT_END_FLAG") == 'Y')
                {
                    chkProtect.Checked = true;
                    cdvAlarmID.Enabled = false;
                }
                else
                {
                    chkProtect.Checked = false;
                    cdvAlarmID.Enabled = true;
                }

                cdvCrtCmf1.Text = out_node.GetString("LOT_CMF_1");
                cdvCrtCmf2.Text = out_node.GetString("LOT_CMF_2");
                cdvCrtCmf3.Text = out_node.GetString("LOT_CMF_3");
                cdvCrtCmf4.Text = out_node.GetString("LOT_CMF_4");
                cdvCrtCmf5.Text = out_node.GetString("LOT_CMF_5");
                cdvCrtCmf6.Text = out_node.GetString("LOT_CMF_6");
                cdvCrtCmf7.Text = out_node.GetString("LOT_CMF_7");
                cdvCrtCmf8.Text = out_node.GetString("LOT_CMF_8");
                cdvCrtCmf9.Text = out_node.GetString("LOT_CMF_9");
                cdvCrtCmf10.Text = out_node.GetString("LOT_CMF_10");
                cdvCrtCmf11.Text = out_node.GetString("LOT_CMF_11");
                cdvCrtCmf12.Text = out_node.GetString("LOT_CMF_12");
                cdvCrtCmf13.Text = out_node.GetString("LOT_CMF_13");
                cdvCrtCmf14.Text = out_node.GetString("LOT_CMF_14");
                cdvCrtCmf15.Text = out_node.GetString("LOT_CMF_15");
                cdvCrtCmf16.Text = out_node.GetString("LOT_CMF_16");
                cdvCrtCmf17.Text = out_node.GetString("LOT_CMF_17");
                cdvCrtCmf18.Text = out_node.GetString("LOT_CMF_18");
                cdvCrtCmf19.Text = out_node.GetString("LOT_CMF_19");
                cdvCrtCmf20.Text = out_node.GetString("LOT_CMF_20");

                cdvCmf1.Text = out_node.GetString("LOW_YIELD_CMF_1");
                cdvCmf2.Text = out_node.GetString("LOW_YIELD_CMF_2");
                cdvCmf3.Text = out_node.GetString("LOW_YIELD_CMF_3");
                cdvCmf4.Text = out_node.GetString("LOW_YIELD_CMF_4");
                cdvCmf5.Text = out_node.GetString("LOW_YIELD_CMF_5");
                cdvCmf6.Text = out_node.GetString("LOW_YIELD_CMF_6");
                cdvCmf7.Text = out_node.GetString("LOW_YIELD_CMF_7");
                cdvCmf8.Text = out_node.GetString("LOW_YIELD_CMF_8");
                cdvCmf9.Text = out_node.GetString("LOW_YIELD_CMF_9");
                cdvCmf10.Text = out_node.GetString("LOW_YIELD_CMF_10");
                cdvCmf11.Text = out_node.GetString("LOW_YIELD_CMF_11");
                cdvCmf12.Text = out_node.GetString("LOW_YIELD_CMF_12");
                cdvCmf13.Text = out_node.GetString("LOW_YIELD_CMF_13");
                cdvCmf14.Text = out_node.GetString("LOW_YIELD_CMF_14");
                cdvCmf15.Text = out_node.GetString("LOW_YIELD_CMF_15");
                cdvCmf16.Text = out_node.GetString("LOW_YIELD_CMF_16");
                cdvCmf17.Text = out_node.GetString("LOW_YIELD_CMF_17");
                cdvCmf18.Text = out_node.GetString("LOW_YIELD_CMF_18");
                cdvCmf19.Text = out_node.GetString("LOW_YIELD_CMF_19");
                cdvCmf20.Text = out_node.GetString("LOW_YIELD_CMF_20");

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    FarPoint.Win.Spread.SheetView with_3 = spdYieldList.Sheets[0];
                    with_3 = spdYieldList.Sheets[0];
                    with_3.RowCount++;

                    with_3.Cells[i, (int)YIELD_CONTROL.Code].Value = out_node.GetList("LIST")[i].GetString("CODE");
                    with_3.Cells[i, (int)YIELD_CONTROL.Upper_Yield].Value = out_node.GetList("LIST")[i].GetDouble("CODE_UPPER_YIELD");
                    with_3.Cells[i, (int)YIELD_CONTROL.Lower_Yield].Value = out_node.GetList("LIST")[i].GetDouble("CODE_LOW_YIELD");
                    with_3.Cells[i, (int)YIELD_CONTROL.Calc_Unit_Type].Value = out_node.GetList("LIST")[i].GetString("CODE_UNIT_TYPE");
                    with_3.Cells[i, (int)YIELD_CONTROL.AQL_Type].Value = out_node.GetList("LIST")[i].GetString("CODE_AQL_TYPE");
                    with_3.Cells[i, (int)YIELD_CONTROL.Check_Range].Value = out_node.GetList("LIST")[i].GetInt("CHECK_RANGE");
                    with_3.Cells[i, (int)YIELD_CONTROL.Check_Before_Day].Value = out_node.GetList("LIST")[i].GetInt("CHECK_BEFORE_DAY");
                    with_3.Cells[i, (int)YIELD_CONTROL.Affect_range_After].Value = out_node.GetList("LIST")[i].GetInt("AFFECT_RANGE_AFTER");
                    with_3.Cells[i, (int)YIELD_CONTROL.Affect_Range_Before].Value = out_node.GetList("LIST")[i].GetInt("AFFECT_RANGE_BEFORE");
                    with_3.Cells[i, (int)YIELD_CONTROL.Alarm_Id].Value = out_node.GetList("LIST")[i].GetString("ALARM_ID");

                    if (out_node.GetList("LIST")[i].GetChar("PROTECT_END_FLAG") == 'Y')
                        with_3.Cells[i, (int)YIELD_CONTROL.Protect_end_Flag].Value = true;
                    else
                        with_3.Cells[i, (int)YIELD_CONTROL.Protect_end_Flag].Value = false;

                    with_3.Cells[i, (int)YIELD_CONTROL.Desc].Value = out_node.GetList("LIST")[i].GetString("DESCRIPTION");
                }

                spdYieldList.ActiveSheet.RowCount++;
                spdYieldList.ActiveSheet.Cells[spdYieldList.ActiveSheet.RowCount - 1, (int)YIELD_CONTROL.Protect_end_Flag].Value = false;
                MPCF.FitColumnHeader(spdYieldList,true);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return true;
        }

        #endregion

        #region " View Low Yield Setup List "
        private bool ViewLowYieldSetupList(char c_step)
        {
            TRSNode in_node = new TRSNode("View_Low_Yield_Setup_List_In");
            TRSNode out_node = new TRSNode("View_Low_Yield_Setup_List_Out");

            MPCF.ClearList(spdLowCmfList, true);
            int iRow;
            FarPoint.Win.Spread.SheetView with_3 = new FarPoint.Win.Spread.SheetView();

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                in_node.AddString("MAT_ID", sMatID);
                in_node.AddInt("MAT_VER", iMatVersion);
                in_node.AddString("FLOW", sFlow);
                in_node.AddInt("FLOW_SEQ_NUM", iFlowSeqNum);
                in_node.AddString("OPER", sOper);
                in_node.AddString("RES_ID", sResID);
                in_node.AddString("SUBRES_ID", sSubResID);

                with_3 = spdLowCmfList.ActiveSheet;

                ClearData("1");

                do
                {
                    if (MPCR.CallService("WIP", "WIP_View_Low_Yield_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    if (out_node.StatusValue != MPGC.MP_SUCCESS_STATUS)
                    {
                        MPCF.ShowMsgBox(MPCF.MakeErrorMsg(out_node.MsgCode, out_node.Msg, out_node.DBErrMsg, out_node.FieldMsg));
                        return false;
                    }

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        with_3 = spdLowCmfList.Sheets[0];
                        iRow = with_3.RowCount;
                        with_3.RowCount++;

                        with_3.Cells[iRow, (int)LOT_CMF_COL.Desc].Value = out_node.GetList("LIST")[i].GetString("DESCRIPTION");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.Cmf1].Value = out_node.GetList("LIST")[i].GetString("LOT_CMF_1");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.Cmf2].Value = out_node.GetList("LIST")[i].GetString("LOT_CMF_2");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.Cmf3].Value = out_node.GetList("LIST")[i].GetString("LOT_CMF_3");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.Cmf4].Value = out_node.GetList("LIST")[i].GetString("LOT_CMF_4");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.Cmf5].Value = out_node.GetList("LIST")[i].GetString("LOT_CMF_5");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.Cmf6].Value = out_node.GetList("LIST")[i].GetString("LOT_CMF_6");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.Cmf7].Value = out_node.GetList("LIST")[i].GetString("LOT_CMF_7");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.Cmf8].Value = out_node.GetList("LIST")[i].GetString("LOT_CMF_8");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.Cmf9].Value = out_node.GetList("LIST")[i].GetString("LOT_CMF_9");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.Cmf10].Value = out_node.GetList("LIST")[i].GetString("LOT_CMF_10");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.Cmf11].Value = out_node.GetList("LIST")[i].GetString("LOT_CMF_11");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.Cmf12].Value = out_node.GetList("LIST")[i].GetString("LOT_CMF_12");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.Cmf13].Value = out_node.GetList("LIST")[i].GetString("LOT_CMF_13");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.Cmf14].Value = out_node.GetList("LIST")[i].GetString("LOT_CMF_14");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.Cmf15].Value = out_node.GetList("LIST")[i].GetString("LOT_CMF_15");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.Cmf16].Value = out_node.GetList("LIST")[i].GetString("LOT_CMF_16");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.Cmf17].Value = out_node.GetList("LIST")[i].GetString("LOT_CMF_17");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.Cmf18].Value = out_node.GetList("LIST")[i].GetString("LOT_CMF_18");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.Cmf19].Value = out_node.GetList("LIST")[i].GetString("LOT_CMF_19");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.Cmf20].Value = out_node.GetList("LIST")[i].GetString("LOT_CMF_20");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.Key_Code].Text = out_node.GetList("LIST")[i].GetString("KEY_CODE");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.YIELD_TYPE].Text = out_node.GetList("LIST")[i].GetString("YIELD_TYPE");
                        with_3.Cells[iRow, (int)LOT_CMF_COL.UNIT].Value = out_node.GetList("LIST")[i].GetString("UNIT");

                    }
                    in_node.SetString("NEXT_LOW_YIELD", out_node.GetString("NEXT_LOW_YIELD"));
                } while (in_node.GetString("NEXT_LOW_YIELD") != "");
                spdLowCmfList.Refresh();
                MPCF.FitColumnHeader(spdLowCmfList);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            return true;
        }
        #endregion

        #region " View_Sub_Resource "
        //
        // View_Sub_Resource()
        //       -  View Sub Resource
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Sub_Resource()
        {
            TRSNode in_node = new TRSNode("View_Sub_Resource_In");
            TRSNode out_node = new TRSNode("View_Sub_Resource_Out");

            TreeNode nodeX = new TreeNode();

            try
            {
                MPCF.FieldClear(this.pnlRight);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SUBRES_ID", MPCF.SubtractString(tvResource.SelectedNode.Text, ":", false, false));

                nodeX = tvResource.SelectedNode;
                do
                {
                    nodeX = nodeX.Parent;
                } while (nodeX.ImageIndex != (int)SMALLICON_INDEX.IDX_RESOURCE &&
                         nodeX.ImageIndex != (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN);

                in_node.AddString("RES_ID", MPCF.SubtractString(nodeX.Text, ":", false, false));

                if (MPCR.CallService("RAS", "RAS_View_Sub_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.StatusValue != MPGC.MP_SUCCESS_STATUS)
                {
                    MPCF.ShowMsgBox(MPCF.MakeErrorMsg(out_node.MsgCode, out_node.Msg, out_node.DBErrMsg, out_node.FieldMsg));
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
        #endregion

        #region " FindResourceID "
        // FindResourceID()
        //       - Find Resource ID
        // Return Value
        //       - Resource ID : String
        // Arguments
        //       - ByVal Tree As TreeView
        //		- ByVal Item As String
        //		- ByVal Parent As String
        public string FindResourceID(TreeView Tree, TreeNode StartNode)
        {
            string returnValue;
            int i;
            TreeNode FindNode;
            TreeNode TempNode;

            returnValue = "";
            TempNode = StartNode;

            if (TempNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE || TempNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN)
            {
                returnValue = MPCF.SubtractString(TempNode.Text, ":", false, false);
                return returnValue;
            }

            for (i = 0; i <= Tree.GetNodeCount(true); i++)
            {
                FindNode = TempNode.Parent;
                if (FindNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE || FindNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN)
                {
                    returnValue = MPCF.SubtractString(FindNode.Text, ":", false, false);
                    return returnValue;
                }

                if (FindNode.Parent == null)
                {
                    return "";
                }
                TempNode = FindNode;
            }
            return returnValue;
        }
        public string FindResourceID_MFO(Miracom.MESCore.Controls.udcMFOTreeList Tree, TreeNode StartNode)
        {
            string returnValue;
            int i;
            TreeNode FindNode;
            TreeNode TempNode;

            returnValue = "";
            TempNode = StartNode;

            if (TempNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE || TempNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN)
            {
                returnValue = MPCF.SubtractString(TempNode.Text, ":", false, false);
                return returnValue;
            }

            for (i = 0; i <= Tree.ListCount; i++)
            {
                FindNode = TempNode.Parent;
                if (FindNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE || FindNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN)
                {
                    returnValue = MPCF.SubtractString(FindNode.Text, ":", false, false);
                    return returnValue;
                }

                if (FindNode.Parent == null)
                {
                    return "";
                }

                TempNode = FindNode;
            }
            return returnValue;
        }
        #endregion

        #region " SetCMFItem "
        private void SetCMFItem(string p)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion

        #region " CheckCMFItemValue "
        private bool CheckCMFItemValue()
        {
            return MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCmf);
        }
        #endregion

        #region " AddSpace "
        private string AddSpace(string sStr, int iSize)
        {
            try
            {
                if (sStr.Length < iSize)
                {
                    for (int i = 0; i < iSize; i++)
                    {
                        if (sStr.Length <= iSize)
                        {
                            sStr = sStr + " ";
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return "";
            }

            return sStr;
        }
        #endregion
        
        #region " SetYieldControl "
        private void SetYieldControl(ref TRSNode Low_Yield)
        {
            int i;
            TRSNode Yield_item;

            for (i = 0; i <= spdYieldList.ActiveSheet.RowCount - 1; i++)
            {
                if (MPCF.Trim(spdYieldList.ActiveSheet.Cells[i, (int)YIELD_CONTROL.Code].Value) != "")
                {
                    Yield_item = Low_Yield.AddNode("YIELD_CONTROL");

                    Yield_item.AddString("CODE", MPCF.Trim(spdYieldList.ActiveSheet.Cells[i, (int)YIELD_CONTROL.Code].Value));
                    Yield_item.AddString("CODE_UNIT_TYPE", MPCF.Trim(spdYieldList.ActiveSheet.Cells[i, (int)YIELD_CONTROL.Calc_Unit_Type].Value));
                    Yield_item.AddString("CODE_AQL_TYPE", MPCF.Trim(spdYieldList.ActiveSheet.Cells[i, (int)YIELD_CONTROL.AQL_Type].Value));
                    Yield_item.AddDouble("CODE_UPPER_YIELD", MPCF.ToDbl(spdYieldList.ActiveSheet.Cells[i, (int)YIELD_CONTROL.Upper_Yield].Value));
                    Yield_item.AddDouble("CODE_LOW_YIELD", MPCF.ToDbl(spdYieldList.ActiveSheet.Cells[i, (int)YIELD_CONTROL.Lower_Yield].Value));
                    Yield_item.AddInt("CHECK_RANGE", MPCF.ToDbl(spdYieldList.ActiveSheet.Cells[i, (int)YIELD_CONTROL.Check_Range].Value));
                    Yield_item.AddInt("CHECK_BEFORE_DAY", MPCF.ToDbl(spdYieldList.ActiveSheet.Cells[i, (int)YIELD_CONTROL.Check_Before_Day].Value));
                    Yield_item.AddInt("AFFECT_RANGE_BEFORE", MPCF.ToDbl(spdYieldList.ActiveSheet.Cells[i, (int)YIELD_CONTROL.Affect_Range_Before].Value));
                    Yield_item.AddInt("AFFECT_RANGE_AFTER", MPCF.ToDbl(spdYieldList.ActiveSheet.Cells[i, (int)YIELD_CONTROL.Affect_range_After].Value));
                    Yield_item.AddString("ALARM_ID", MPCF.Trim(spdYieldList.ActiveSheet.Cells[i, (int)YIELD_CONTROL.Alarm_Id].Text));

                    if((bool)spdYieldList.ActiveSheet.Cells[i, (int)YIELD_CONTROL.Protect_end_Flag].Value==true)
                        Yield_item.AddChar("PROTECT_END_FLAG", 'Y');
                    else
                        Yield_item.AddChar("PROTECT_END_FLAG", 'N');


                    Yield_item.AddString("DESCRIPTION", MPCF.Trim(spdYieldList.ActiveSheet.Cells[i, (int)YIELD_CONTROL.Desc].Value));
                }
            }
        }
        #endregion

        #region " Spread CMF Setting Function "
        private bool SetSpreadCMF()
        {           
            TRSNode in_node = new TRSNode("Factory_Cmf_Item_In");
            TRSNode out_node = new TRSNode("Factory_Cmf_Item_Out");
            int i;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ITEM_NAME", "CMF_LOT");

                FarPoint.Win.Spread.SheetView with_3 = spdLowCmfList.Sheets[0];

                if (MPCR.CallService("WIP", "WIP_View_Factory_Cmf_Item", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.StatusValue != MPGC.MP_SUCCESS_STATUS)
                {
                    MPCF.ShowMsgBox(MPCF.MakeErrorMsg(out_node.MsgCode, out_node.Msg, out_node.DBErrMsg, null));
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {

                    // Lot Customized Field 1 
                    if (i == 0)
                    {
                        if (out_node.GetList(0)[i].GetString("PROMPT") != null && out_node.GetList(0)[i].GetString("PROMPT") != "")
                        {
                            with_3.Columns[(int)LOT_CMF_COL.Cmf1].Visible = true;
                            with_3.Columns[(int)LOT_CMF_COL.Cmf1].Label = out_node.GetList(0)[i].GetString("PROMPT");
                        }

                        else
                            with_3.Columns[(int)LOT_CMF_COL.Cmf1].Visible = false;
                    }

                    // Lot Customized Field 2
                    if (i == 1)
                    {
                        if (out_node.GetList(0)[i].GetString("PROMPT") != null && out_node.GetList(0)[i].GetString("PROMPT") != "")
                        {
                            with_3.Columns[(int)LOT_CMF_COL.Cmf2].Visible = true;
                            with_3.Columns[(int)LOT_CMF_COL.Cmf2].Label = out_node.GetList(0)[i].GetString("PROMPT");
                        }
                        else
                            with_3.Columns[(int)LOT_CMF_COL.Cmf2].Visible = false;
                    }

                    // Lot Customized Field 3
                    if (i == 2)
                    {
                        if (out_node.GetList(0)[i].GetString("PROMPT") != null && out_node.GetList(0)[i].GetString("PROMPT") != "")
                        {
                            with_3.Columns[(int)LOT_CMF_COL.Cmf3].Visible = true;
                            with_3.Columns[(int)LOT_CMF_COL.Cmf3].Label = out_node.GetList(0)[i].GetString("PROMPT");
                        }
                        else
                            with_3.Columns[(int)LOT_CMF_COL.Cmf3].Visible = false;
                    }

                    // Lot Customized Field 4
                    if (i == 3)
                    {
                        if (out_node.GetList(0)[i].GetString("PROMPT") != null && out_node.GetList(0)[i].GetString("PROMPT") != "")
                        {
                            with_3.Columns[(int)LOT_CMF_COL.Cmf4].Visible = true;
                            with_3.Columns[(int)LOT_CMF_COL.Cmf4].Label = out_node.GetList(0)[i].GetString("PROMPT");
                        }
                        else
                            with_3.Columns[(int)LOT_CMF_COL.Cmf4].Visible = false;
                    }

                    // Lot Customized Field 5
                    if (i == 4)
                    {
                        if (out_node.GetList(0)[i].GetString("PROMPT") != null && out_node.GetList(0)[i].GetString("PROMPT") != "")
                        {
                            with_3.Columns[(int)LOT_CMF_COL.Cmf5].Label = out_node.GetList(0)[i].GetString("PROMPT");
                            with_3.Columns[(int)LOT_CMF_COL.Cmf5].Visible = true;
                        }
                        else
                            with_3.Columns[(int)LOT_CMF_COL.Cmf5].Visible = false;
                    }

                    // Lot Customized Field 6
                    if (i == 5)
                    {
                        if (out_node.GetList(0)[i].GetString("PROMPT") != null && out_node.GetList(0)[i].GetString("PROMPT") != "")
                        {
                            with_3.Columns[(int)LOT_CMF_COL.Cmf6].Visible = true;
                            with_3.Columns[(int)LOT_CMF_COL.Cmf6].Label = out_node.GetList(0)[i].GetString("PROMPT");
                        }
                        else
                            with_3.Columns[(int)LOT_CMF_COL.Cmf6].Visible = false;
                    }

                    // Lot Customized Field 7
                    if (i == 6)
                    {
                        if (out_node.GetList(0)[i].GetString("PROMPT") != null && out_node.GetList(0)[i].GetString("PROMPT") != "")
                        {
                            with_3.Columns[(int)LOT_CMF_COL.Cmf7].Visible = true;
                            with_3.Columns[(int)LOT_CMF_COL.Cmf7].Label = out_node.GetList(0)[i].GetString("PROMPT");
                        }
                        else
                            with_3.Columns[(int)LOT_CMF_COL.Cmf7].Visible = false;
                    }

                    // Lot Customized Field 8
                    if (i == 7)
                    {
                        if (out_node.GetList(0)[i].GetString("PROMPT") != null && out_node.GetList(0)[i].GetString("PROMPT") != "")
                        {
                            with_3.Columns[(int)LOT_CMF_COL.Cmf8].Visible = true;
                            with_3.Columns[(int)LOT_CMF_COL.Cmf8].Label = out_node.GetList(0)[i].GetString("PROMPT");
                        }
                        else
                            with_3.Columns[(int)LOT_CMF_COL.Cmf8].Visible = false;
                    }

                    // Lot Customized Field 9
                    if (i == 8)
                    {
                        if (out_node.GetList(0)[i].GetString("PROMPT") != null && out_node.GetList(0)[i].GetString("PROMPT") != "")
                        {
                            with_3.Columns[(int)LOT_CMF_COL.Cmf9].Visible = true;
                            with_3.Columns[(int)LOT_CMF_COL.Cmf9].Label = out_node.GetList(0)[i].GetString("PROMPT");
                        }
                        else
                            with_3.Columns[(int)LOT_CMF_COL.Cmf9].Visible = false;
                    }

                    // Lot Customized Field 10
                    if (i == 9)
                    {
                        if (out_node.GetList(0)[i].GetString("PROMPT") != null && out_node.GetList(0)[i].GetString("PROMPT") != "")
                        {
                            with_3.Columns[(int)LOT_CMF_COL.Cmf10].Visible = true;
                            with_3.Columns[(int)LOT_CMF_COL.Cmf10].Label = out_node.GetList(0)[i].GetString("PROMPT");
                        }
                        else
                            with_3.Columns[(int)LOT_CMF_COL.Cmf10].Visible = false;
                    }


                    // Lot Customized Field 11
                    if (i == 10)
                    {
                        if (out_node.GetList(0)[i].GetString("PROMPT") != null && out_node.GetList(0)[i].GetString("PROMPT") != "")
                        {
                            with_3.Columns[(int)LOT_CMF_COL.Cmf11].Visible = true;
                            with_3.Columns[(int)LOT_CMF_COL.Cmf11].Label = out_node.GetList(0)[i].GetString("PROMPT");
                        }
                        else
                            with_3.Columns[(int)LOT_CMF_COL.Cmf11].Visible = false;
                    }

                    // Lot Customized Field 12
                    if (i == 11)
                    {
                        if (out_node.GetList(0)[i].GetString("PROMPT") != null && out_node.GetList(0)[i].GetString("PROMPT") != "")
                        {
                            with_3.Columns[(int)LOT_CMF_COL.Cmf12].Visible = true;
                            with_3.Columns[(int)LOT_CMF_COL.Cmf12].Label = out_node.GetList(0)[i].GetString("PROMPT");
                        }
                        else
                            with_3.Columns[(int)LOT_CMF_COL.Cmf12].Visible = false;
                    }

                    // Lot Customized Field 13
                    if (i ==12)
                    {
                        if (out_node.GetList(0)[i].GetString("PROMPT") != null && out_node.GetList(0)[i].GetString("PROMPT") != "")
                        {
                            with_3.Columns[(int)LOT_CMF_COL.Cmf13].Visible = true;
                            with_3.Columns[(int)LOT_CMF_COL.Cmf13].Label = out_node.GetList(0)[i].GetString("PROMPT");
                        }
                        else
                            with_3.Columns[(int)LOT_CMF_COL.Cmf13].Visible = false;
                    }

                    // Lot Customized Field 14
                    if (i == 13)
                    {
                        if (out_node.GetList(0)[i].GetString("PROMPT") != null && out_node.GetList(0)[i].GetString("PROMPT") != "")
                        {
                            with_3.Columns[(int)LOT_CMF_COL.Cmf14].Visible = true;
                            with_3.Columns[(int)LOT_CMF_COL.Cmf14].Label = out_node.GetList(0)[i].GetString("PROMPT");
                        }
                        else
                            with_3.Columns[(int)LOT_CMF_COL.Cmf14].Visible = false;
                    }

                    // Lot Customized Field 15
                    if (i == 14)
                    {
                        if (out_node.GetList(0)[i].GetString("PROMPT") != null && out_node.GetList(0)[i].GetString("PROMPT") != "")
                        {
                            with_3.Columns[(int)LOT_CMF_COL.Cmf15].Visible = true;
                            with_3.Columns[(int)LOT_CMF_COL.Cmf15].Label = out_node.GetList(0)[i].GetString("PROMPT");
                        }
                        else
                            with_3.Columns[(int)LOT_CMF_COL.Cmf15].Visible = false;
                    }
                    
                    // Lot Customized Field 16
                    if (i == 15)
                    {
                        if (out_node.GetList(0)[i].GetString("PROMPT") != null && out_node.GetList(0)[i].GetString("PROMPT") != "")
                        {
                            with_3.Columns[(int)LOT_CMF_COL.Cmf16].Visible = true;
                            with_3.Columns[(int)LOT_CMF_COL.Cmf16].Label = out_node.GetList(0)[i].GetString("PROMPT");
                        }
                        else
                            with_3.Columns[(int)LOT_CMF_COL.Cmf16].Visible = false;
                    }

                    // Lot Customized Field 17
                    if (i == 16)
                    {
                        if (out_node.GetList(0)[i].GetString("PROMPT") != null && out_node.GetList(0)[i].GetString("PROMPT") != "")
                        {
                            with_3.Columns[(int)LOT_CMF_COL.Cmf17].Visible = true;
                            with_3.Columns[(int)LOT_CMF_COL.Cmf17].Label = out_node.GetList(0)[i].GetString("PROMPT");
                        }
                        else
                            with_3.Columns[(int)LOT_CMF_COL.Cmf17].Visible = false;
                    }
                        
                    // Lot Customized Field 18
                    if (i == 17)
                    {
                        if (out_node.GetList(0)[i].GetString("PROMPT") != null && out_node.GetList(0)[i].GetString("PROMPT") != "")
                        {
                            with_3.Columns[(int)LOT_CMF_COL.Cmf18].Visible = true;
                            with_3.Columns[(int)LOT_CMF_COL.Cmf18].Label = out_node.GetList(0)[i].GetString("PROMPT");
                        }
                        else
                            with_3.Columns[(int)LOT_CMF_COL.Cmf18].Visible = false;
                    }

                    // Lot Customized Field 19
                    if (i == 18)
                    {
                        if (out_node.GetList(0)[i].GetString("PROMPT") != null && out_node.GetList(0)[i].GetString("PROMPT") != "")
                        {
                            with_3.Columns[(int)LOT_CMF_COL.Cmf19].Visible = true;
                            with_3.Columns[(int)LOT_CMF_COL.Cmf19].Label = out_node.GetList(0)[i].GetString("PROMPT");
                        }
                        else
                            with_3.Columns[(int)LOT_CMF_COL.Cmf19].Visible = false;
                    }

                    // Lot Customized Field 20
                    if (i == 19)
                    {
                        if (out_node.GetList(0)[i].GetString("PROMPT") != null && out_node.GetList(0)[i].GetString("PROMPT") != "")
                        {
                            with_3.Columns[(int)LOT_CMF_COL.Cmf20].Visible = true;
                            with_3.Columns[(int)LOT_CMF_COL.Cmf20].Label = out_node.GetList(0)[i].GetString("PROMPT");
                        }
                        else
                            with_3.Columns[(int)LOT_CMF_COL.Cmf20].Visible = false;
                    }
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

        #endregion

        private bool ViewTable()
        {
            TRSNode in_node = new TRSNode("VIEW_TABLE_IN");

            try
            {
                if (TABLE == null)
                {
                    TABLE = new TRSNode("VIEW_TABLE_OUT");
                }

                TABLE.Init();

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", "LYD_AQL_TBL");
                in_node.AddString("KEY_1", cdvAQLType.Text);

                if (MPCR.CallService("BAS", "BAS_View_Table", in_node, ref TABLE) == false)
                {
                    return false;
                }

                ViewDataList(null);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        //
        // View_Data_List()
        //       - View All General Code Data list which is included in one General Code Table
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewDataList(string[] sArgu)
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node;

            DataTable dt = null;
            ArrayList a_list = new ArrayList();
            FarPoint.Win.Spread.FpSpread spd;

            try
            {
                
                spd = spdData;
                
                MPCF.ClearList(spd);
                spd.SuspendLayout();
                spd.ActiveSheet.ColumnCount = 0;
                spd.ResumeLayout();


                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPGC.MP_LYD_AQL_TBL_TBL_DEF);
                in_node.AddString("KEY_1", cdvAQLType.Text);

                spd.SuspendLayout();

                do
                {
                    out_node = new TRSNode("VIEW_DATA_LIST_OUT");

                    if (MPCR.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    a_list.Add(out_node);

                    in_node.SetString("NEXT_KEY_1", out_node.GetString("NEXT_KEY_1"));
                    in_node.SetString("NEXT_KEY_2", out_node.GetString("NEXT_KEY_2"));
                    in_node.SetString("NEXT_KEY_3", out_node.GetString("NEXT_KEY_3"));
                    in_node.SetString("NEXT_KEY_4", out_node.GetString("NEXT_KEY_4"));
                    in_node.SetString("NEXT_KEY_5", out_node.GetString("NEXT_KEY_5"));
                    in_node.SetString("NEXT_KEY_6", out_node.GetString("NEXT_KEY_6"));
                    in_node.SetString("NEXT_KEY_7", out_node.GetString("NEXT_KEY_7"));
                    in_node.SetString("NEXT_KEY_8", out_node.GetString("NEXT_KEY_8"));
                    in_node.SetString("NEXT_KEY_9", out_node.GetString("NEXT_KEY_9"));
                    in_node.SetString("NEXT_KEY_10", out_node.GetString("NEXT_KEY_10"));
                    in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));


                } while (in_node.GetString("NEXT_KEY_1") != "" ||
                         in_node.GetString("NEXT_KEY_2") != "" ||
                         in_node.GetString("NEXT_KEY_3") != "" ||
                         in_node.GetString("NEXT_KEY_4") != "" ||
                         in_node.GetString("NEXT_KEY_5") != "" ||
                         in_node.GetString("NEXT_KEY_6") != "" ||
                         in_node.GetString("NEXT_KEY_7") != "" ||
                         in_node.GetString("NEXT_KEY_8") != "" ||
                         in_node.GetString("NEXT_KEY_9") != "" ||
                         in_node.GetString("NEXT_KEY_10") != "" ||
                         in_node.GetInt("NEXT_ROW") > 0);

                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    
                        dt = FillDataTable(dt, out_node);
                }

                spd.DataSource = dt;
                
                MakeColumnHeader();
                
                spd.ResumeLayout();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        private DataTable FillDataTable(DataTable dt, TRSNode out_node)
        {
            int c;
            int r;
            DataColumn dc;
            DataRow dr;
            List<TRSNode> data_list;

            /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
            data_list = out_node.GetList("DATA_LIST");
            if (dt == null)
            {
                if (data_list.Count < 1) return null;
                dt = new DataTable("DataTable");
                for (c = 0; c < 40; c++)
                {
                    dc = new DataColumn();
                    dc.DataType = System.Type.GetType("System.String");
                    dc.DefaultValue = "";

                    dt.Columns.Add(dc);
                }
            }

            for (r = 0; r < data_list.Count; r++)
            {
                dr = dt.NewRow();

                dr[0] = data_list[r].GetString("KEY_1");
                dr[1] = "";
                dr[2] = data_list[r].GetString("KEY_2");
                dr[3] = "";
                dr[4] = data_list[r].GetString("KEY_3");
                dr[5] = "";
                dr[6] = data_list[r].GetString("KEY_4");
                dr[7] = "";
                dr[8] = data_list[r].GetString("KEY_5");
                dr[9] = "";
                dr[10] = data_list[r].GetString("KEY_6");
                dr[11] = "";
                dr[12] = data_list[r].GetString("KEY_7");
                dr[13] = "";
                dr[14] = data_list[r].GetString("KEY_8");
                dr[15] = "";
                dr[16] = data_list[r].GetString("KEY_9");
                dr[17] = "";
                dr[18] = data_list[r].GetString("KEY_10");
                dr[19] = "";

                dr[20] = data_list[r].GetString("DATA_1");
                dr[21] = "";
                dr[22] = data_list[r].GetString("DATA_2");
                dr[23] = "";
                dr[24] = data_list[r].GetString("DATA_3");
                dr[25] = "";
                dr[26] = data_list[r].GetString("DATA_4");
                dr[27] = "";
                dr[28] = data_list[r].GetString("DATA_5");
                dr[29] = "";
                dr[30] = data_list[r].GetString("DATA_6");
                dr[31] = "";
                dr[32] = data_list[r].GetString("DATA_7");
                dr[33] = "";
                dr[34] = data_list[r].GetString("DATA_8");
                dr[35] = "";
                dr[36] = data_list[r].GetString("DATA_9");
                dr[37] = "";
                dr[38] = data_list[r].GetString("DATA_10");
                dr[39] = "";

                dt.Rows.Add(dr);
            }
            /*** End of Modification (2012.04.04) ***/

            return dt;
        }

        //
        // Make_Column_Header()
        //       - View General Code Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool MakeColumnHeader()
        {
            FarPoint.Win.Spread.CellType.TextCellType text_type;
            /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
            FarPoint.Win.Spread.CellType.ButtonCellType button_type;
            /*** End of Add (2012.04.04) ***/
            int i;

            try
            {
                

                /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                if (spdData.ActiveSheet.Columns.Count > 0)
                {
                    spdData.ActiveSheet.Columns.Add(0, 1);
                }
                else
                {
                    spdData.ActiveSheet.ColumnCount = 41;
                }

                for (i = 1; i <= 40; i++)
                {
                    //spdData.ActiveSheet.ColumnHeader.Columns[i].Visible = false;
                    spdData.ActiveSheet.ColumnHeader.Columns[i].Width = 0;
                    spdData.ActiveSheet.ColumnHeader.Columns[i].Resizable = false;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, i].Value = "";

                    FormatTbl[i].Col_Fmt = "";
                    FormatTbl[i].Col_Size = 0;
                }


                spdData.ActiveSheet.ColumnHeader.Cells[0, 0].Value = "Sel";
                spdData.ActiveSheet.Columns.Get(0).CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                spdData.ActiveSheet.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                spdData.ActiveSheet.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                spdData.ActiveSheet.Columns.Get(0).Width = 30;


                if (TABLE.GetString("KEY_1_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 100;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].Value = " " + TABLE.GetString("KEY_1_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[KEY_1_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[KEY_1_COL].Visible = true;

                    spdData.ActiveSheet.Columns[KEY_1_COL].Locked = true;
                    spdData.ActiveSheet.Columns[KEY_1_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[KEY_1_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[KEY_1_COL].CellType = text_type;

                    FormatTbl[KEY_1_COL].Col_Fmt = TABLE.GetChar("KEY_1_FMT").ToString();
                    FormatTbl[KEY_1_COL].Col_Size = TABLE.GetInt("KEY_1_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].Tag = COLUMN_KEY;
                    if (TABLE.GetString("KEY_1_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[KEY_1_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_1_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[KEY_1_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_1_TBL"), TABLE.GetString("KEY_1_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].ColumnSpan = 2;
                    }
                }

                if (TABLE.GetString("KEY_2_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 100;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].Value = " " + TABLE.GetString("KEY_2_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[KEY_2_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[KEY_2_COL].Visible = true;

                    spdData.ActiveSheet.Columns[KEY_2_COL].Locked = true;
                    spdData.ActiveSheet.Columns[KEY_2_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[KEY_2_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[KEY_2_COL].CellType = text_type;

                    FormatTbl[KEY_2_COL].Col_Fmt = TABLE.GetChar("KEY_2_FMT").ToString();
                    FormatTbl[KEY_2_COL].Col_Size = TABLE.GetInt("KEY_2_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].Tag = COLUMN_KEY;
                    if (TABLE.GetString("KEY_2_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[KEY_2_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_2_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[KEY_2_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_2_TBL"), TABLE.GetString("KEY_2_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].ColumnSpan = 2;
                    }
                }

                if (TABLE.GetChar("TABLE_TYPE") == 'E' || TABLE.GetChar("TABLE_TYPE") == 'L')
                {
                    if (TABLE.GetString("KEY_3_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_3_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_3_COL].Value = " " + TABLE.GetString("KEY_3_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_3_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_3_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_3_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_3_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_3_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_3_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_3_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_3_COL].CellType = text_type;

                        FormatTbl[KEY_3_COL].Col_Fmt = TABLE.GetChar("KEY_3_FMT").ToString();
                        FormatTbl[KEY_3_COL].Col_Size = TABLE.GetInt("KEY_3_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_3_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_3_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_3_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_3_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_3_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_3_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_3_TBL"), TABLE.GetString("KEY_3_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_3_COL].ColumnSpan = 2;
                        }
                    }
                    if (TABLE.GetString("KEY_4_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_4_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_4_COL].Value = " " + TABLE.GetString("KEY_4_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_4_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_4_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_4_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_4_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_4_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_4_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_4_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_4_COL].CellType = text_type;

                        FormatTbl[KEY_4_COL].Col_Fmt = TABLE.GetString("KEY_4_FMT");
                        FormatTbl[KEY_4_COL].Col_Size = TABLE.GetInt("KEY_4_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_4_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_4_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_4_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_4_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_4_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_4_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_4_TBL"), TABLE.GetString("KEY_4_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_4_COL].ColumnSpan = 2;
                        }
                    }
                    if (TABLE.GetString("KEY_5_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_5_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_5_COL].Value = " " + TABLE.GetString("KEY_5_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_5_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_5_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_5_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_5_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_5_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_5_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_5_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_5_COL].CellType = text_type;

                        FormatTbl[KEY_5_COL].Col_Fmt = TABLE.GetChar("KEY_5_FMT").ToString();
                        FormatTbl[KEY_5_COL].Col_Size = TABLE.GetInt("KEY_5_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_5_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_5_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_5_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_5_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_5_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_5_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_5_TBL"), TABLE.GetString("KEY_5_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_5_COL].ColumnSpan = 2;
                        }
                    }
                    if (TABLE.GetString("KEY_6_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_6_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_6_COL].Value = " " + TABLE.GetString("KEY_6_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_6_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_6_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_6_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_6_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_6_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_6_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_6_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_6_COL].CellType = text_type;

                        FormatTbl[KEY_6_COL].Col_Fmt = TABLE.GetChar("KEY_6_FMT").ToString();
                        FormatTbl[KEY_6_COL].Col_Size = TABLE.GetInt("KEY_6_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_6_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_6_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_6_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_6_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_6_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_6_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_6_TBL"), TABLE.GetString("KEY_6_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_6_COL].ColumnSpan = 2;
                        }
                    }
                    if (TABLE.GetString("KEY_7_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_7_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_7_COL].Value = " " + TABLE.GetString("KEY_7_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_7_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_7_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_7_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_7_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_7_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_7_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_7_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_7_COL].CellType = text_type;

                        FormatTbl[KEY_7_COL].Col_Fmt = TABLE.GetChar("KEY_7_FMT").ToString();
                        FormatTbl[KEY_7_COL].Col_Size = TABLE.GetInt("KEY_7_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_7_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_7_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_7_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_7_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_7_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_7_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_7_TBL"), TABLE.GetString("KEY_7_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_7_COL].ColumnSpan = 2;
                        }
                    }
                    if (TABLE.GetString("KEY_8_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_8_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_8_COL].Value = " " + TABLE.GetString("KEY_8_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_8_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_8_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_8_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_8_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_8_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_8_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_8_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_8_COL].CellType = text_type;

                        FormatTbl[KEY_8_COL].Col_Fmt = TABLE.GetChar("KEY_8_FMT").ToString();
                        FormatTbl[KEY_8_COL].Col_Size = TABLE.GetInt("KEY_8_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_8_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_8_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_8_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_8_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_8_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_8_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_8_TBL"), TABLE.GetString("KEY_8_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_8_COL].ColumnSpan = 2;
                        }
                    }
                    if (TABLE.GetString("KEY_9_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_9_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_9_COL].Value = " " + TABLE.GetString("KEY_9_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_9_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_9_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_9_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_9_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_9_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_9_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_9_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_9_COL].CellType = text_type;

                        FormatTbl[KEY_9_COL].Col_Fmt = TABLE.GetChar("KEY_9_FMT").ToString();
                        FormatTbl[KEY_9_COL].Col_Size = TABLE.GetInt("KEY_9_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_9_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_9_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_9_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_9_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_9_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_9_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_9_TBL"), TABLE.GetString("KEY_9_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_9_COL].ColumnSpan = 2;
                        }
                    }
                    if (TABLE.GetString("KEY_10_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_10_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_10_COL].Value = " " + TABLE.GetString("KEY_10_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_10_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_10_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_10_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_10_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_10_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_10_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_10_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_10_COL].CellType = text_type;

                        FormatTbl[KEY_10_COL].Col_Fmt = TABLE.GetChar("KEY_10_FMT").ToString();
                        FormatTbl[KEY_10_COL].Col_Size = TABLE.GetInt("KEY_10_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_10_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_10_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_10_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_10_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_10_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_10_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_10_TBL"), TABLE.GetString("KEY_10_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_10_COL].ColumnSpan = 2;
                        }
                    }
                }

                if (TABLE.GetString("DATA_1_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].Value = " " + TABLE.GetString("DATA_1_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_1_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_1_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_1_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_1_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_1_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_1_COL].CellType = text_type;

                    FormatTbl[DATA_1_COL].Col_Fmt = TABLE.GetChar("DATA_1_FMT").ToString();
                    FormatTbl[DATA_1_COL].Col_Size = TABLE.GetInt("DATA_1_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_1_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_1_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_1_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_1_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_1_TBL"), TABLE.GetString("DATA_1_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_2_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].Value = " " + TABLE.GetString("DATA_2_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_2_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_2_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_2_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_2_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_2_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_2_COL].CellType = text_type;

                    FormatTbl[DATA_2_COL].Col_Fmt = TABLE.GetChar("DATA_2_FMT").ToString();
                    FormatTbl[DATA_2_COL].Col_Size = TABLE.GetInt("DATA_2_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_2_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_2_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_2_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_2_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_2_TBL"), TABLE.GetString("DATA_2_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_3_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].Value = " " + TABLE.GetString("DATA_3_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_3_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_3_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_3_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_3_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_3_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_3_COL].CellType = text_type;

                    FormatTbl[DATA_3_COL].Col_Fmt = TABLE.GetChar("DATA_3_FMT").ToString();
                    FormatTbl[DATA_3_COL].Col_Size = TABLE.GetInt("DATA_3_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_3_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_3_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_3_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_3_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_3_TBL"), TABLE.GetString("DATA_3_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_4_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_4_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_4_COL].Value = " " + TABLE.GetString("DATA_4_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_4_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_4_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_4_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_4_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_4_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_4_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_4_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_4_COL].CellType = text_type;

                    FormatTbl[DATA_4_COL].Col_Fmt = TABLE.GetChar("DATA_4_FMT").ToString();
                    FormatTbl[DATA_4_COL].Col_Size = TABLE.GetInt("DATA_4_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_4_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_4_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_4_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_4_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_4_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_4_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_4_TBL"), TABLE.GetString("DATA_4_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_4_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_5_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_5_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_5_COL].Value = " " + TABLE.GetString("DATA_5_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_5_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_5_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_5_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_5_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_5_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_5_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_5_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_5_COL].CellType = text_type;

                    FormatTbl[DATA_5_COL].Col_Fmt = TABLE.GetChar("DATA_5_FMT").ToString();
                    FormatTbl[DATA_5_COL].Col_Size = TABLE.GetInt("DATA_5_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_5_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_5_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_5_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_5_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_5_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_5_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_5_TBL"), TABLE.GetString("DATA_5_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_5_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_6_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_6_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_6_COL].Value = " " + TABLE.GetString("DATA_6_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_6_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_6_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_6_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_6_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_6_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_6_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_6_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_6_COL].CellType = text_type;

                    FormatTbl[DATA_6_COL].Col_Fmt = TABLE.GetChar("DATA_6_FMT").ToString();
                    FormatTbl[DATA_6_COL].Col_Size = TABLE.GetInt("DATA_6_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_6_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_6_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_6_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_6_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_6_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_6_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_6_TBL"), TABLE.GetString("DATA_6_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_6_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_7_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_7_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_7_COL].Value = " " + TABLE.GetString("DATA_7_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_7_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_7_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_7_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_7_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_7_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_7_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_7_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_7_COL].CellType = text_type;

                    FormatTbl[DATA_7_COL].Col_Fmt = TABLE.GetChar("DATA_7_FMT").ToString();
                    FormatTbl[DATA_7_COL].Col_Size = TABLE.GetInt("DATA_7_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_7_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_7_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_7_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_7_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_7_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_7_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_7_TBL"), TABLE.GetString("DATA_7_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_7_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_8_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_8_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_8_COL].Value = " " + TABLE.GetString("DATA_8_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_8_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_8_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_8_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_8_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_8_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_8_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_8_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_8_COL].CellType = text_type;

                    FormatTbl[DATA_8_COL].Col_Fmt = TABLE.GetChar("DATA_8_FMT").ToString();
                    FormatTbl[DATA_8_COL].Col_Size = TABLE.GetInt("DATA_8_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_8_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_8_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_8_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_8_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_8_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_8_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_8_TBL"), TABLE.GetString("DATA_8_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_8_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_9_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_9_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_9_COL].Value = " " + TABLE.GetString("DATA_9_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_9_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_9_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_9_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_9_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_9_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_9_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_9_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_9_COL].CellType = text_type;

                    FormatTbl[DATA_9_COL].Col_Fmt = TABLE.GetChar("DATA_9_FMT").ToString();
                    FormatTbl[DATA_9_COL].Col_Size = TABLE.GetInt("DATA_9_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_9_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_9_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_9_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_9_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_9_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_9_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_9_TBL"), TABLE.GetString("DATA_9_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_9_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_10_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_10_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_10_COL].Value = " " + TABLE.GetString("DATA_10_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_10_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_10_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_10_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_10_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_10_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_10_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_10_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_10_COL].CellType = text_type;

                    FormatTbl[DATA_10_COL].Col_Fmt = TABLE.GetChar("DATA_10_FMT").ToString();
                    FormatTbl[DATA_10_COL].Col_Size = TABLE.GetInt("DATA_10_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_10_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_10_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_10_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_10_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_10_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_10_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_10_TBL"), TABLE.GetString("DATA_10_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_10_COL].ColumnSpan = 2;
                    }
                }

                if (AutoCalWidth() == false)
                {
                    return false;
                }

                spdData.ActiveSheet.ColumnHeader.Rows[0].Height = spdData.ActiveSheet.ColumnHeader.Rows[0].GetPreferredHeight();
                spdData.ActiveSheet.SetColumnAllowAutoSort(1, 40, true);
                spdData.ActiveSheet.SetColumnAllowFilter(1, 40, true);

                spdData.ActiveSheet.RowCount++;
                for (i = 1; i <= 40; i++)
                {
                    if (MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, i].Tag) == COLUMN_KEY)
                    {
                        spdData.ActiveSheet.Columns[i].BackColor = System.Drawing.Color.Lavender;
                        spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].BackColor = System.Drawing.Color.WhiteSmoke;
                        spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].Locked = false;
                    }
                    else if (MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, i].Tag) == COLUMN_DATA)
                    {
                        spdData.ActiveSheet.Columns[i].BackColor = System.Drawing.Color.White;
                    }
                }
                /*** End of Modification (2012.04.04) ***/
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        //
        // AutoCalWidth()
        //       - Auto Calculation Spread Column Width
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool AutoCalWidth()
        {
            int i = 0;
            int iSpreadWidth = 0;
            int iColumnWidth = 0;
            int iColumnCount = 0;

            float iColumnHeaderWidth = 0;
            float iRowHeaderWidth = 0;

            /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
            
            if (spdData.ActiveSheet.ColumnHeader.Columns.Count > 0)
                iColumnHeaderWidth = spdData.ActiveSheet.ColumnHeader.Columns[0].Width;

            if (spdData.ActiveSheet.RowHeader.Columns.Count > 0)
                iRowHeaderWidth = spdData.ActiveSheet.RowHeader.Columns[0].Width;

            iSpreadWidth = (int)(spdData.Width - iColumnHeaderWidth - iRowHeaderWidth - 25);

            if (iSpreadWidth <= 0)
            {
                return false;
            }
            for (i = 1; i < spdData.ActiveSheet.ColumnCount; i++)
            {
                if (spdData.ActiveSheet.ColumnHeader.Columns[i].Width > 0)
                {
                    iColumnCount++;
                }
            }

            if (iColumnCount > 0)
                iColumnWidth = iSpreadWidth / iColumnCount;
            else
                iColumnCount = iSpreadWidth;

            if (iColumnWidth < 120)
            {
                iColumnWidth = 120;
            }
            for (i = 1; i < spdData.ActiveSheet.ColumnCount; i++)
            {
                if (spdData.ActiveSheet.ColumnHeader.Columns[i].Width > 0)
                {
                    if (MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, i].Tag) == COLUMN_KEY ||
                        MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, i].Tag) == COLUMN_DATA)
                    {
                        spdData.ActiveSheet.ColumnHeader.Columns[i].Width = iColumnWidth;
                        spdData.ActiveSheet.ColumnHeader.Columns[i].Resizable = true;
                    }
                }
            }
            
            /*** End of Modification (2012.04.04) ***/

            return true;

        }

        //
        // Update_Data_List()
        //       - Create/Update/Delete General Code Data List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool UpdateDataList(char ProcStep)
        {
            int i = 0;
            TRSNode in_node = new TRSNode("UPDATE_DATA_LIST_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode node;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("TABLE_NAME", MPGC.MP_LYD_AQL_TBL_TBL_DEF);

                for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                {
                    if (spdData.ActiveSheet.Cells[i, 0].Value != null)
                    {
                        if (Convert.ToBoolean(spdData.ActiveSheet.Cells[i, 0].Value) == true)
                        {
                            node = in_node.AddNode("DATA_LIST");

                            if (FormatTbl[KEY_1_COL].Col_Fmt != "")
                            {
                                if (FormatTbl[KEY_1_COL].Col_Fmt != "A")
                                    node.AddString("KEY_1", MPCF.Trim(MPCF.ToRegionNumber(spdData.ActiveSheet.Cells[i, KEY_1_COL].Value)));
                                else
                                    node.AddString("KEY_1", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_1_COL].Value));
                            }
                            if (FormatTbl[KEY_2_COL].Col_Fmt != "")
                            {
                                if (FormatTbl[KEY_2_COL].Col_Fmt != "A")
                                    node.AddString("KEY_2", MPCF.Trim(MPCF.ToRegionNumber(spdData.ActiveSheet.Cells[i, KEY_2_COL].Value)));
                                else
                                    node.AddString("KEY_2", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_2_COL].Value));
                            }
                            if (FormatTbl[KEY_3_COL].Col_Fmt != "")
                            {
                                if (FormatTbl[KEY_3_COL].Col_Fmt != "A")
                                    node.AddString("KEY_3", MPCF.Trim(MPCF.ToRegionNumber(spdData.ActiveSheet.Cells[i, KEY_3_COL].Value)));
                                else
                                    node.AddString("KEY_3", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_3_COL].Value));
                            }
                            if (FormatTbl[KEY_4_COL].Col_Fmt != "")
                            {
                                if (FormatTbl[KEY_4_COL].Col_Fmt != "A")
                                    node.AddString("KEY_4", MPCF.Trim(MPCF.ToRegionNumber(spdData.ActiveSheet.Cells[i, KEY_4_COL].Value)));
                                else
                                    node.AddString("KEY_4", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_4_COL].Value));
                            }
                            if (FormatTbl[KEY_5_COL].Col_Fmt != "")
                            {
                                if (FormatTbl[KEY_5_COL].Col_Fmt != "A")
                                    node.AddString("KEY_5", MPCF.Trim(MPCF.ToRegionNumber(spdData.ActiveSheet.Cells[i, KEY_5_COL].Value)));
                                else
                                    node.AddString("KEY_5", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_5_COL].Value));
                            }
                            if (FormatTbl[KEY_6_COL].Col_Fmt != "")
                            {
                                if (FormatTbl[KEY_6_COL].Col_Fmt != "A")
                                    node.AddString("KEY_6", MPCF.Trim(MPCF.ToRegionNumber(spdData.ActiveSheet.Cells[i, KEY_6_COL].Value)));
                                else
                                    node.AddString("KEY_6", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_6_COL].Value));
                            }
                            if (FormatTbl[KEY_7_COL].Col_Fmt != "")
                            {
                                if (FormatTbl[KEY_7_COL].Col_Fmt != "A")
                                    node.AddString("KEY_7", MPCF.Trim(MPCF.ToRegionNumber(spdData.ActiveSheet.Cells[i, KEY_7_COL].Value)));
                                else
                                    node.AddString("KEY_7", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_7_COL].Value));
                            }
                            if (FormatTbl[KEY_8_COL].Col_Fmt != "")
                            {
                                if (FormatTbl[KEY_8_COL].Col_Fmt != "A")
                                    node.AddString("KEY_8", MPCF.Trim(MPCF.ToRegionNumber(spdData.ActiveSheet.Cells[i, KEY_8_COL].Value)));
                                else
                                    node.AddString("KEY_8", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_8_COL].Value));
                            }
                            if (FormatTbl[KEY_9_COL].Col_Fmt != "")
                            {
                                if (FormatTbl[KEY_9_COL].Col_Fmt != "A")
                                    node.AddString("KEY_9", MPCF.Trim(MPCF.ToRegionNumber(spdData.ActiveSheet.Cells[i, KEY_9_COL].Value)));
                                else
                                    node.AddString("KEY_9", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_9_COL].Value));
                            }
                            if (FormatTbl[KEY_10_COL].Col_Fmt != "")
                            {
                                if (FormatTbl[KEY_10_COL].Col_Fmt != "A")
                                    node.AddString("KEY_10", MPCF.Trim(MPCF.ToRegionNumber(spdData.ActiveSheet.Cells[i, KEY_10_COL].Value)));
                                else
                                    node.AddString("KEY_10", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_10_COL].Value));
                            }

                            if (FormatTbl[DATA_1_COL].Col_Fmt != "")
                            {
                                if (FormatTbl[DATA_1_COL].Col_Fmt != "A")
                                    node.AddString("DATA_1", MPCF.Trim(MPCF.ToRegionNumber(spdData.ActiveSheet.Cells[i, DATA_1_COL].Value)));
                                else
                                    node.AddString("DATA_1", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_1_COL].Value));
                            }
                            if (FormatTbl[DATA_2_COL].Col_Fmt != "")
                            {
                                if (FormatTbl[DATA_2_COL].Col_Fmt != "A")
                                    node.AddString("DATA_2", MPCF.Trim(MPCF.ToRegionNumber(spdData.ActiveSheet.Cells[i, DATA_2_COL].Value)));
                                else
                                    node.AddString("DATA_2", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_2_COL].Value));
                            }
                            if (FormatTbl[DATA_3_COL].Col_Fmt != "")
                            {
                                if (FormatTbl[DATA_3_COL].Col_Fmt != "A")
                                    node.AddString("DATA_3", MPCF.Trim(MPCF.ToRegionNumber(spdData.ActiveSheet.Cells[i, DATA_3_COL].Value)));
                                else
                                    node.AddString("DATA_3", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_3_COL].Value));
                            }
                            if (FormatTbl[DATA_4_COL].Col_Fmt != "")
                            {
                                if (FormatTbl[DATA_4_COL].Col_Fmt != "A")
                                    node.AddString("DATA_4", MPCF.Trim(MPCF.ToRegionNumber(spdData.ActiveSheet.Cells[i, DATA_4_COL].Value)));
                                else
                                    node.AddString("DATA_4", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_4_COL].Value));
                            }
                            if (FormatTbl[DATA_5_COL].Col_Fmt != "")
                            {
                                if (FormatTbl[DATA_5_COL].Col_Fmt != "A")
                                    node.AddString("DATA_5", MPCF.Trim(MPCF.ToRegionNumber(spdData.ActiveSheet.Cells[i, DATA_5_COL].Value)));
                                else
                                    node.AddString("DATA_5", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_5_COL].Value));
                            }
                            if (FormatTbl[DATA_6_COL].Col_Fmt != "")
                            {
                                if (FormatTbl[DATA_6_COL].Col_Fmt != "A")
                                    node.AddString("DATA_6", MPCF.Trim(MPCF.ToRegionNumber(spdData.ActiveSheet.Cells[i, DATA_6_COL].Value)));
                                else
                                    node.AddString("DATA_6", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_6_COL].Value));
                            }
                            if (FormatTbl[DATA_7_COL].Col_Fmt != "")
                            {
                                if (FormatTbl[DATA_7_COL].Col_Fmt != "A")
                                    node.AddString("DATA_7", MPCF.Trim(MPCF.ToRegionNumber(spdData.ActiveSheet.Cells[i, DATA_7_COL].Value)));
                                else
                                    node.AddString("DATA_7", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_7_COL].Value));
                            }
                            if (FormatTbl[DATA_8_COL].Col_Fmt != "")
                            {
                                if (FormatTbl[DATA_8_COL].Col_Fmt != "A")
                                    node.AddString("DATA_8", MPCF.Trim(MPCF.ToRegionNumber(spdData.ActiveSheet.Cells[i, DATA_8_COL].Value)));
                                else
                                    node.AddString("DATA_8", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_8_COL].Value));
                            }
                            if (FormatTbl[DATA_9_COL].Col_Fmt != "")
                            {
                                if (FormatTbl[DATA_9_COL].Col_Fmt != "A")
                                    node.AddString("DATA_9", MPCF.Trim(MPCF.ToRegionNumber(spdData.ActiveSheet.Cells[i, DATA_9_COL].Value)));
                                else
                                    node.AddString("DATA_9", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_9_COL].Value));
                            }
                            if (FormatTbl[DATA_10_COL].Col_Fmt != "")
                            {
                                if (FormatTbl[DATA_10_COL].Col_Fmt != "A")
                                    node.AddString("DATA_10", MPCF.Trim(MPCF.ToRegionNumber(spdData.ActiveSheet.Cells[i, DATA_10_COL].Value)));
                                else
                                    node.AddString("DATA_10", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_10_COL].Value));
                            }
                        }
                    }
                }

                if (MPCR.CallService("BAS", "BAS_Update_Data_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        private bool CheckGCMTable(string sTableName, out string sQuery, out string dTable)
        {
            TRSNode in_node = new TRSNode("VIEW_TABLE_IN");
            TRSNode out_node = new TRSNode("VIEW_TABLE_OUT");

            sQuery = String.Empty;
            dTable = String.Empty;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", sTableName);

                if (MPCR.CallService("BAS", "BAS_View_Table", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetChar("USE_SQL_FLAG") == 'Y')
                {
                    sQuery = out_node.GetString("SQL_1") + out_node.GetString("SQL_2") + out_node.GetString("SQL_3")
                             + out_node.GetString("SQL_4") + out_node.GetString("SQL_5");
                }

                if (out_node.GetChar("TABLE_TYPE") == 'L')
                    dTable = GCM_TBL_LAG;
                else
                    dTable = GCM_TBL_DAT;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool GetQueryArgument(string sQuery, out string[] sArgu)
        {
            int i, j, i_count;
            string[] sWord = null;
            bool b_exist_flag = false;

            sArgu = null;

            if (MPCF.Trim(sQuery) != "")
            {
                frmBASSubSetupTable form = new frmBASSubSetupTable();

                sWord = sQuery.Split(new Char[] { ' ', '\n', '\r' });
                i_count = 0;
                for (i = 0; i < sWord.Length; i++)
                {
                    if (sWord[i].IndexOf("$") >= 0)
                    {
                        if (MPCF.Trim(sWord[i]) != "$FACTORY")
                        {
                            i_count++;
                        }
                    }
                }
                if (i_count > 0)
                {
                    sArgu = new string[i_count];
                }

                i_count = 0;
                for (i = 0; i < sWord.Length; i++)
                {
                    if (sWord[i].IndexOf("$") >= 0)
                    {
                        b_exist_flag = false;
                        if (MPCF.Trim(sWord[i]) != "$FACTORY")
                        {
                            for (j = 0; j < sArgu.Length; j++)
                            {
                                if (sArgu[j] == sWord[i])
                                {
                                    b_exist_flag = true;
                                }
                            }
                            if (b_exist_flag == false)
                            {
                                sArgu[i_count] = sWord[i];
                                i_count++;
                            }
                        }
                    }
                }
                if (i_count > 0)
                {
                    form.ViewQueryArgument(sArgu, i_count);
                    if (form.ShowDialog(this) != DialogResult.OK)
                    {
                        if (form.IsDisposed == false) form.Dispose();
                        return false;
                    }
                    sArgu = new string[i_count];
                    for (i = 0; i < sArgu.Length; i++)
                    {
                        sArgu[i] = form.ArgValue[i, 1];
                    }
                }
            }

            return true;
        }

        //
        // ViewGCMDataListExt()
        //       - View General Code Data list Extension (ListView Add "KEY_2" Column, use in this screen only)
        // Return Value
        //       - boolean : True / False
        // Arguments
        //
        private bool ViewGCMDataListExt(ListView lisList, string table_name, string[] Argu)
        {
            ListViewItem itmX;
            int i;
            int j;
            string s_col_name;
            ArrayList a_list;
            List<TRSNode> data_list;

            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node;

            a_list = new ArrayList();

            MPCF.InitListView(lisList);

            if (lisList is Miracom.UI.Controls.MCCodeView.MCCodeDropList)
            {
                ((Miracom.UI.Controls.MCCodeView.MCCodeDropList)lisList).GCMTableName = table_name;
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("TABLE_NAME", table_name);
            in_node.AddString("NEXT_KEY_1", "");
            in_node.AddString("NEXT_KEY_2", "");

            if (Argu != null)
            {
                for (i = 0; i < Argu.Length; i++)
                {
                    TRSNode node = in_node.AddNode("ARGU_LIST");
                    node.AddString("ARGUMENT", Argu[i]);
                }
            }

            do
            {
                out_node = new TRSNode("VIEW_DATA_LIST_OUT");

                if (MPCR.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_KEY_1", out_node.GetString("NEXT_KEY_1"));
                in_node.SetString("NEXT_KEY_2", out_node.GetString("NEXT_KEY_2"));
                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));

            } while (in_node.GetString("NEXT_KEY_1") != "" || in_node.GetString("NEXT_KEY_2") != "" || in_node.GetInt("NEXT_ROW") > 0);

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                data_list = out_node.GetList("DATA_LIST");
                for (i = 0; i < data_list.Count; i++)
                {
                    s_col_name = lisList.Columns[0].Text;

                    itmX = new ListViewItem();
                    itmX.Text = data_list[i].GetString(s_col_name);
                    itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_CODE_DATA;
                    for (j = 1; j < lisList.Columns.Count; j++)
                    {
                        s_col_name = lisList.Columns[j].Text;
                        itmX.SubItems.Add(data_list[i].GetString(s_col_name));
                    }
                    lisList.Items.Add(itmX);
                }
            }

            return true;
        }

        //To List all Column names from the table
        private bool ViewTableColumnList(ListView listView, string tableName)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            MPCF.InitListView(listView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("SQL", "SELECT COLUMN_NAME AS COLUMN_NAME " +
                                     "       FROM USER_TAB_COLUMNS " +
                                     "       WHERE TABLE_NAME = '" + tableName + "' " +
                                     "       ORDER BY COLUMN_NAME");
            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(listView, out_node);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (out_node.GetInt("NEXT_ROW") > 0);

            return true;
        }

        #region " ButtonPress Event"

        private void cdvLowYieldType_ButtonPress(object sender, EventArgs e)
        {
            cdvLowYieldType.Init();
            MPCF.InitListView(cdvLowYieldType.GetListView);
            cdvLowYieldType.Columns.Add("Yield Type", 50, HorizontalAlignment.Left);
            cdvLowYieldType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvLowYieldType.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvLowYieldType.GetListView, '1', MPGC.MP_LYD_TYPE_TBL_DEF);
        }

        private void cdvCalUnit_ButtonPress(object sender, EventArgs e)
        {
            cdvCalUnit.Init();
            MPCF.InitListView(cdvCalUnit.GetListView);
            cdvCalUnit.Columns.Add("Yield Unit", 50, HorizontalAlignment.Left);
            cdvCalUnit.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCalUnit.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvCalUnit.GetListView, '1', MPGC.MP_LYD_UNIT_TBL_DEF);
        }

        private void cdvCalUnitType_ButtonPress(object sender, EventArgs e)
        {
            cdvCalUnitType.Init();
            MPCF.InitListView(cdvCalUnitType.GetListView);
            cdvCalUnitType.Columns.Add("Yield Unit Type", 50, HorizontalAlignment.Left);
            cdvCalUnitType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCalUnitType.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvCalUnitType.GetListView, '1', MPGC.MP_LYD_UNIT_TYPE_TBL_DEF);
        }

        private void cdvYieldBase_ButtonPress(object sender, EventArgs e)
        {
            cdvYieldBase.Init();
            MPCF.InitListView(cdvYieldBase.GetListView);
            cdvYieldBase.Columns.Add("Yield Base", 50, HorizontalAlignment.Left);
            cdvYieldBase.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvYieldBase.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvYieldBase.GetListView, '1', MPGC.MP_LYD_BASE_TBL_DEF);
        }

        private void cdvYieldBaseOper_ButtonPress(object sender, EventArgs e)
        {
            cdvYieldBaseOper.Init();
            MPCF.InitListView(cdvYieldBaseOper.GetListView);
            cdvYieldBaseOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
            cdvYieldBaseOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvYieldBaseOper.SelectedSubItemIndex = 0;
            WIPLIST.ViewOperationList(cdvYieldBaseOper.GetListView, '1', "", 0, "", "", null, "");
        }

        private void cdvCheckTrans_ButtonPress(object sender, EventArgs e)
        {
            cdvCheckTrans.Init();
            MPCF.InitListView(cdvCheckTrans.GetListView);
            cdvCheckTrans.Columns.Add("Yield Base", 50, HorizontalAlignment.Left);
            cdvCheckTrans.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCheckTrans.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvCheckTrans.GetListView, '1', MPGC.MP_LYD_CHECK_TRANS_TBL_DEF);
        }

        private void cdvAlarmID_ButtonPress(object sender, EventArgs e)
        {
            cdvAlarmID.Init();
            MPCF.InitListView(cdvAlarmID.GetListView);
            cdvAlarmID.Columns.Add("Alarm Code", 50, HorizontalAlignment.Left);
            cdvAlarmID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvAlarmID.SelectedSubItemIndex = 0;
            if (ALMLIST.ViewAlarmMsgList(cdvAlarmID.GetListView, '1', MPGC.MP_ALM_NORMAL) == false)
            {
                return;
            }
        }

        private void cdvCrtCmf_ButtonPress(object sender, System.EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }

        #endregion

        #region " Click Event"

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            tvMFO.GetNext(txtFind.Text);
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            tvMFO.RefreshSelectedList();
        }

        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition(MPGC.MP_STEP_CREATE) == false) return;

                if (UpdateLowYieldSetup(MPGC.MP_STEP_CREATE) == false) return;
                ViewLowYieldSetupList('1');
                
                MPCF.ShowMsgBox(MPCF.GetMessage(52));

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition(MPGC.MP_STEP_UPDATE) == false) return;

                if (UpdateLowYieldSetup(MPGC.MP_STEP_UPDATE) == false) return;
                ViewLowYieldSetupList('1');
                
                MPCF.ShowMsgBox(MPCF.GetMessage(52));
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;
                if (CheckCondition(MPGC.MP_STEP_DELETE) == false) return;

                if (UpdateLowYieldSetup(MPGC.MP_STEP_DELETE) == false) return;
                ViewLowYieldSetupList('1');
                
                MPCF.ShowMsgBox(MPCF.GetMessage(52));
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void spdLowCmfList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            ClearData("2");
            ViewLowYieldSetup('2', e.Row);
        }

        private void spdYieldList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == (int)YIELD_CONTROL.Btn_Code)
            {
                cdvCode.Init();
                cdvCode.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvCode.GetListView);
                cdvCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
                cdvCode.Columns.Add("Desc", 50, HorizontalAlignment.Left);

                if (cdvLowYieldType.Text.Length > 0)
                {
                    if (s_loss_table != "")
                    {
                        BASLIST.ViewGCMDataList(cdvCode.GetListView, '1', s_loss_table);
                        cdvCode.InsertEmptyRow(0, 1);
                    }

                    if (cdvCode.ShowPopupList(e.Row, e.Column) == false)
                    {
                        return;
                    }
                    lspd_table = spdYieldList;
                }
            }

            else if (e.Column == (int)YIELD_CONTROL.btn_Unit_Type)
            {
                cdvCode.Init();
                cdvCode.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvCode.GetListView);
                cdvCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
                cdvCode.Columns.Add("Desc", 50, HorizontalAlignment.Left);

                BASLIST.ViewGCMDataList(cdvCode.GetListView, '1', MPGC.MP_LYD_UNIT_TYPE_TBL_DEF);
                cdvCode.InsertEmptyRow(0, 1);

                if (cdvCode.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
                lspd_table = spdYieldList;
            }
            else if (e.Column == (int)YIELD_CONTROL.btn_AQL_Type)
            {
                cdvCode.Init();
                cdvCode.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvCode.GetListView);
                cdvCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
                cdvCode.Columns.Add("Desc", 50, HorizontalAlignment.Left);

                BASLIST.ViewGCMDataList(cdvCode.GetListView, '1', MPGC.MP_LYD_AQL_TYPE_TBL_DEF);
                cdvCode.InsertEmptyRow(0, 1);

                if (cdvCode.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
                lspd_table = spdYieldList;
            }

            else if (e.Column == (int)YIELD_CONTROL.Btn_Alarm_Id)
            {
                cdvCode.Init();
                cdvCode.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvCode.GetListView);
                cdvCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
                cdvCode.Columns.Add("Desc", 50, HorizontalAlignment.Left);

                ALMLIST.ViewAlarmMsgList(cdvCode.GetListView, '1', MPGC.MP_ALM_NORMAL);
                cdvCode.InsertEmptyRow(0, 1);

                if (cdvCode.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
                lspd_table = spdYieldList;
            }
        }

        #endregion

        private void frmWIPSetupLowYield_Load(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView mcTemp;

            tabLowYieldinfo.TabPages.Remove(this.tabCrtCMF);
            tabLowYieldinfo.Controls.Add(this.tabCrtCMF);

            tabLowYieldinfo.TabPages.Remove(this.tabCMF);
            tabLowYieldinfo.Controls.Add(this.tabCMF);

            MPCR.SetCMFItem(MPGC.MP_CMF_LOT, "lblCrtCmf", "cdvCrtCmf", grpCrtCmf);
            MPCR.SetCMFItem(MPGC.MP_CMF_LOW_YIELD, "lblCmf", "cdvCmf", grpCmf);

            foreach (Control ctrTemp in grpCrtCmf.Controls)
            {
                if (ctrTemp is Miracom.UI.Controls.MCCodeView.MCCodeView)
                {
                    mcTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)ctrTemp;
                    mcTemp.Enabled = true;
                    mcTemp.ReadOnly = false;
                }
                if (ctrTemp is Label)
                {
                    ctrTemp.Font = new Font(ctrTemp.Font, FontStyle.Regular);
                }
            }

            MPCF.InitTreeView(tvResource);
            SetSpreadCMF();
        }

        private void frmWIPSetupLowYield_Activated(object sender, EventArgs e)
        {
            TreeNode node;
            try
            {
                if (bLoadFlag == false)
                {
                    tvResource.ShowRootLines = true;
                    node = tvResource.Nodes.Add(MPGV.gsFactory);
                    node.ImageIndex = (int)SMALLICON_INDEX.IDX_FACTORY;
                    node.SelectedImageIndex = (int)SMALLICON_INDEX.IDX_FACTORY;
                    node.Expand();

                    MPCF.ClearList(spdLowCmfList);
                    MPCF.ClearList(spdYieldList);

                    lblLotStatus.Visible = false;
                    cdvLotStatus.Visible = false;
                    cdvLotStatus.Text = "";

                    lblYeldbaseOper.Visible = false;
                    cdvYieldBaseOper.Visible = false;
                    cdvYieldBaseOper.Text = "";

                    bLoadFlag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && MPCF.Trim(txtFind.Text) != "")
            {
                btnNext_Click(null, null);
            }
        }

        private void cdvCrtCmf_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);
        }

        private void txtMatID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(0);
        }       

        private void tvMFO_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int iListCount = 0;

            try
            {
                if (tvMFO.SelectedNode == null)
                {
                    return;
                }

                if (tvMFO.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_MATERIAL)
                {
                    ClearData("1");
                    sFlow = "";
                    iFlowSeqNum = 0;
                    sOper = "";
                    sResID = "";
                    sSubResID = "";

                }
                else if (tvMFO.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_FLOW)
                {
                    ClearData("1");

                    sOper = "";
                    sResID = "";
                    sSubResID = "";
                }
                else if (tvMFO.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_OPER)
                {
                    tvMFO.SelectedNode.Nodes.Clear();
                    if (RASLIST.ViewResourceList(tvMFO, '1', "", "", "", "", tvMFO.MatID, tvMFO.MatVersion, tvMFO.Flow, tvMFO.Oper, 'R', "", false, tvMFO.SelectedNode, "", false) == true)
                    {
                        if (iListCount > 0)
                        {
                            tvMFO.SelectedNode.EnsureVisible();
                            tvMFO.SelectedNode.Expand();
                        }
                    }

                    sResID = "";
                    sSubResID = "";
                }
                else if (tvMFO.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE || tvMFO.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN)
                {
                    sResID = MPCF.SubtractString(tvMFO.SelectedNode.Text, ":", false, false);
                    tvMFO.SelectedNode.Nodes.Clear();

                    if (RASLIST.ViewSubResourceList(tvMFO, '1', sResID, MPGV.gsFactory, "", "", false, tvMFO.SelectedNode, ref iListCount) == true)
                    {
                        if (iListCount > 0)
                        {
                            tvMFO.SelectedNode.EnsureVisible();
                            tvMFO.SelectedNode.Expand();
                        }
                    }
                    sSubResID = "";
                }
                else if (tvMFO.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_SUB_EQUIP)
                {
                    sResID = FindResourceID_MFO(tvMFO, tvMFO.SelectedNode);
                    sSubResID = MPCF.SubtractString(tvMFO.SelectedNode.Text, ":", false, false);
                }

                sMatID = tvMFO.MatID;
                iMatVersion = tvMFO.MatVersion;
                sFlow = tvMFO.Flow;
                iFlowSeqNum = tvMFO.FlowSeqNum;
                sOper = tvMFO.Oper;

                if (tvMFO.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_OPER)
                {
                    ViewLowYieldSetupList('1');
                    //SetSpreadCMF();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void tvResource_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int iListCount = 0;

            if (tvResource.SelectedNode == null)
            {
                return;
            }

            if (tvResource.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_FACTORY)
            {
                tvResource.TopNode.Nodes.Clear();
                if (RASLIST.ViewResourceList(tvResource, '1', "", "", "", "", "", 0, "", "", ' ', "", false, tvResource.TopNode, "") == true)
                {
                    lblDataCount.Text = MPCF.Trim(tvResource.GetNodeCount(false));
                    if (tvResource.GetNodeCount(false) > 0)
                    {
                        tvResource.SelectedNode = tvResource.TopNode.FirstNode;
                    }
                }
            }
            else if (tvResource.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE || tvResource.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN)
            {
                MPCF.FieldClear(this.pnlRight);
                sResID = MPCF.SubtractString(tvResource.SelectedNode.Text, ":", false, false);
                tvResource.SelectedNode.Nodes.Clear();

                sSubResID = "";

                if (RASLIST.ViewSubResourceList(tvResource, '1', sResID, MPGV.gsFactory, "", "", false, tvResource.SelectedNode, ref iListCount) == true)
                {
                    lblDataCount.Text = MPCF.Trim(iListCount);
                    if (iListCount > 0)
                    {
                        tvResource.SelectedNode.EnsureVisible();
                        tvResource.SelectedNode.Expand();
                    }
                }
            }
            else if (tvResource.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_SUB_EQUIP)
            {
                if (View_Sub_Resource() == true)
                {
                    sResID = FindResourceID(tvResource, tvResource.SelectedNode);
                    sSubResID = MPCF.SubtractString(tvResource.SelectedNode.Text, ":", false, false);
                }
            }
        }

        private void tabMFO_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearData("1");
        }

        private void tvMFO_SelectLevelChanged(object sender, EventArgs e)
        {
            ClearData("1");
        }

        private void cdvCode_SelectedItemChanged(System.Object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            lspd_table.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.Text;

            if (e.Col == (int)YIELD_CONTROL.btn_Unit_Type)
            {
                if (spdYieldList.ActiveSheet.Cells[e.Row, e.Col-1].Text == MPGC.MP_LYD_UNIT_TYPE_AQL)
                {
                    spdYieldList.ActiveSheet.Cells[e.Row, (int)YIELD_CONTROL.AQL_Type].Locked = false;
                    spdYieldList.ActiveSheet.Cells[e.Row, (int)YIELD_CONTROL.btn_AQL_Type].Locked = false;
                }
                else
                {
                    spdYieldList.ActiveSheet.Cells[e.Row, (int)YIELD_CONTROL.AQL_Type].Text = "";
                    spdYieldList.ActiveSheet.Cells[e.Row, (int)YIELD_CONTROL.AQL_Type].Locked = true;
                    spdYieldList.ActiveSheet.Cells[e.Row, (int)YIELD_CONTROL.btn_AQL_Type].Locked = true;
                }
            }
        }

        private void chkProtect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProtect.Checked == true)
            {
                cdvAlarmID.Enabled = false;
            }
            else
            {
                cdvAlarmID.Enabled = true;
            }
        }

        private void spdYieldList_EditModeOff(object sender, EventArgs e)
        {
            int i_row;

            i_row = spdYieldList.ActiveSheet.ActiveRowIndex;

            if (i_row == spdYieldList.ActiveSheet.RowCount - 1)
            {
                spdYieldList.ActiveSheet.RowCount++;
                spdYieldList.ActiveSheet.Cells[spdYieldList.ActiveSheet.RowCount-1, (int)YIELD_CONTROL.Protect_end_Flag].Value = false;
            }
        }

        private void spdYieldList_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            if (e.Column == (int)YIELD_CONTROL.Code)
            { 
               if( MPCF.Trim(spdYieldList.ActiveSheet.Cells[e.Row,(int)YIELD_CONTROL.Code].Value) == "")
                {
                    spdYieldList.ActiveSheet.RemoveRows(e.Row,1);
                }
            }
        }

        private void spdYieldList_TextChanged(object sender, EventArgs e)
        {
            int row_index;
            int col_index;
            row_index = spdYieldList.ActiveSheet.ActiveRowIndex;
            col_index = spdYieldList.ActiveSheet.ActiveColumnIndex;

            if (MPCF.Trim(spdYieldList.ActiveSheet.Cells[row_index, (int)YIELD_CONTROL.Code].Value) == "")
            {
                spdYieldList.ActiveSheet.RemoveRows(row_index, 1);
            }
        }

        private void cdvYieldBase_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {   
            //if (cdvYieldBase.Text == MPGC.MP_LYD_BASE_OPER_IN || cdvYieldBase.Text == MPGC.MP_LYD_BASE_OPER_START ||
            //    cdvYieldBase.Text == MPGC.MP_LYD_BASE_OPER_OUT)
            //{
            //    lblYeldbaseOper.Enabled = true;
            //    cdvYieldBaseOper.Enabled = true;
            //    cdvYieldBaseOper.Text = "";
            //}
            //else
            //{
            //    cdvYieldBaseOper.Enabled = false;
            //    cdvYieldBaseOper.Enabled = false;
            //    cdvYieldBaseOper.Text = "";
            //}

        }

        private void cdvAQLType_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvAQLType.Text) == "")
            {
                txtTotalUpper.Text = "";
                txtTotalLower.Text = "";
                txtTotalUpper.Enabled = true;
                txtTotalLower.Enabled = true;
                lblTotalUpper.Enabled = true;
                lblTotalLow.Enabled = true;
            }
            else
            {
                txtTotalUpper.Text = "";
                txtTotalLower.Text = "";
                txtTotalUpper.Enabled = false;
                txtTotalLower.Enabled = false;
                lblTotalUpper.Enabled = false;
                lblTotalLow.Enabled = false;
            }
        }

        private void cdvAQLType_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvAQLType.Text) == "")
            {
                txtTotalUpper.Text = "";
                txtTotalLower.Text = "";
                txtTotalUpper.Enabled = true;
                txtTotalLower.Enabled = true;
                lblTotalUpper.Enabled = true;
                lblTotalLow.Enabled = true;
            }
            else
            {
                txtTotalUpper.Text = "";
                txtTotalLower.Text = "";
                txtTotalUpper.Enabled = false;
                txtTotalLower.Enabled = false;
                lblTotalUpper.Enabled = false;
                lblTotalLow.Enabled = false;
            }
        }

        private void btnTableUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateDataList(MPGC.MP_STEP_UPDATE) == false)
            {
                return;
            }
            ViewDataList(null);
        }

        private void btnAQLTable_Click(object sender, EventArgs e)
        {
            ViewTable();
            pnlControl.SendToBack();
        }

        private void cdvAQLType_ButtonPress(object sender, EventArgs e)
        {
            cdvAQLType.Init();
            MPCF.InitListView(cdvAQLType.GetListView);
            cdvAQLType.Columns.Add("AQL Type", 50, HorizontalAlignment.Left);
            cdvAQLType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvAQLType.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvAQLType.GetListView, '1', MPGC.MP_LYD_AQL_TYPE_TBL_DEF);
        }

        private void btnTableClose_Click(object sender, EventArgs e)
        {
            pnlControl.BringToFront();
        }

        private void spdData_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            ListView lisTmp = new ListView();
            string[] sTmp = null;
            string[] sArgu = null;
            string sQuery = "";
            string dTable = null;
            i_last_selected_idx = 0;
            i_last_selected_desc_idx = -1;

            try
            {
                if (e.Column == KEY_1_BTN || e.Column == KEY_2_BTN || e.Column == KEY_3_BTN || e.Column == KEY_4_BTN || e.Column == KEY_5_BTN ||
                    e.Column == KEY_6_BTN || e.Column == KEY_7_BTN || e.Column == KEY_8_BTN || e.Column == KEY_9_BTN || e.Column == KEY_10_BTN ||
                    e.Column == DATA_1_BTN || e.Column == DATA_2_BTN || e.Column == DATA_3_BTN || e.Column == DATA_4_BTN || e.Column == DATA_5_BTN ||
                    e.Column == DATA_6_BTN || e.Column == DATA_7_BTN || e.Column == DATA_8_BTN || e.Column == DATA_9_BTN || e.Column == DATA_10_BTN)
                {
                    if (MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Tag) == "") return;

                    sTmp = MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Tag).Split(':');
                    lisTmp.Columns.Add("COLUMN");
                    lisTmp.Columns.Add("PROMPT");

                    cdvDataList.Init();
                    cdvDataList.ViewPosition = Control.MousePosition;
                    MPCF.InitListView(cdvDataList.GetListView);

                    if (CheckGCMTable(sTmp[0], out sQuery, out dTable))
                    {
                        if (sTmp.Length == 3)
                        {
                            int iPos = MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Tag).LastIndexOf(":");
                            spdData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Tag = MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Tag).Remove(iPos) + ":" + sQuery;
                        }
                        else
                        {
                            if (MPCF.Trim(sQuery) != "")
                                spdData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Tag += ":" + sQuery;
                        }
                        sTmp = MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Tag).Split(':');
                    }
                    if (sTmp.Length == 3)
                    {
                        if (GetQueryArgument(sQuery, out sArgu) == false)
                        {
                            return;
                        }

                        BASLIST.ViewGCMTablePromptList(lisTmp, sTmp[0], true, true);
                        for (int i = 0; i < lisTmp.Items.Count; i++)
                        {
                            if (lisTmp.Items[i].Text == sTmp[1])
                                i_last_selected_idx = i;

                            if (lisTmp.Items[i].Text == "DATA_1")
                                i_last_selected_desc_idx = i;

                            cdvDataList.Columns.Add(lisTmp.Items[i].Text, 50, HorizontalAlignment.Left);
                        }
                    }
                    else
                    {
                        BASLIST.ViewGCMTablePromptList(lisTmp, sTmp[0], true, true);
                        for (int i = 0; i < lisTmp.Items.Count; i++)
                        {
                            if (lisTmp.Items[i].Text == sTmp[1])
                                i_last_selected_idx = i;

                            if (lisTmp.Items[i].Text == "DATA_1")
                                i_last_selected_desc_idx = i;

                            cdvDataList.Columns.Add(lisTmp.Items[i].Text, 50, HorizontalAlignment.Left);
                        }
                    }
                    ViewGCMDataListExt(cdvDataList.GetListView, sTmp[0], sArgu);
                    if (cdvDataList.Items.Count > 0)
                    {
                        cdvDataList.InsertEmptyRow(0, 1);
                        if (cdvDataList.ShowPopupList(e.Row, e.Column) == false)
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvDataList_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            try
            {
                if (MPCF.Trim(spdData.ActiveSheet.Cells[e.Row, e.Col - 1].Value) != e.SelectedItem.SubItems[i_last_selected_idx].Text)
                {
                    spdData.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[i_last_selected_idx].Text;
                    if (e.SelectedItem.SubItems.Count > 1)
                    {
                        int iDescCol = -1;
                        for (int i = e.Col; i < spdData.ActiveSheet.ColumnCount; i++)
                        {
                            if (MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, i].Tag) == COLUMN_DATA &&
                                spdData.ActiveSheet.Columns[i].Visible == true &&
                                i < spdData.ActiveSheet.ColumnCount - 1)
                            {
                                // 2 column has same reference GCM table, fill description
                                string[] sTmp1 = MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, e.Col].Tag).Split(':');
                                string[] sTmp2 = MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, i + 1].Tag).Split(':');

                                if (sTmp1[0] == sTmp2[0] && sTmp1[1] != sTmp2[1] && i_last_selected_desc_idx >= 0)
                                {
                                    iDescCol = i;
                                    spdData.ActiveSheet.Cells[e.Row, iDescCol].Value = e.SelectedItem.SubItems[i_last_selected_desc_idx].Text;
                                    return;
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdData_EditModeOff(object sender, EventArgs e)
        {
            string sValue;
            int i_col;
            int i_row;

            try
            {
                i_col = spdData.ActiveSheet.ActiveColumnIndex;
                i_row = spdData.ActiveSheet.ActiveRowIndex;

                if (i_col < 1) return;

                spdData.ActiveSheet.SetValue(i_row, 0, true);

                sValue = MPCF.Trim(spdData.ActiveSheet.Cells[i_row, i_col].Value);

                if (MPCF.ByteLen(sValue) > FormatTbl[i_col].Col_Size)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(153));
                    spdData.ActiveSheet.SetValue(i_row, i_col, "");
                    spdData.ActiveSheet.SetActiveCell(i_row, i_col);
                    return;
                }

                switch (FormatTbl[i_col].Col_Fmt)
                {
                    case "F":

                        if (MPCF.CheckNumeric(sValue) == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(139));
                            spdData.ActiveSheet.SetValue(i_row, i_col, "");
                            spdData.ActiveSheet.SetActiveCell(i_row, i_col);
                            return;
                        }
                        break;

                    case "N":

                        if (MPCF.CheckNumeric(sValue) == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(139));
                            spdData.ActiveSheet.SetValue(i_row, i_col, "");
                            spdData.ActiveSheet.SetActiveCell(i_row, i_col);
                            return;
                        }
                        if (sValue.IndexOf(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) >= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(140));
                            spdData.ActiveSheet.SetValue(i_row, i_col, "");
                            spdData.ActiveSheet.SetActiveCell(i_row, i_col);
                            return;
                        }
                        break;
                }

                //Add 1 Row
                if (spdData.ActiveSheet.Columns[KEY_1_COL].Visible == false)
                {
                    return;
                }

                if (i_row == spdData.ActiveSheet.RowCount - 1)
                {
                    if (MPCF.Trim(spdData.ActiveSheet.Cells[i_row, KEY_1_COL].Value) != "")
                    {
                        spdData.ActiveSheet.RowCount++;
                        int i = 0;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        for (i = 1; i <= 20; i++)
                        {
                            spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].BackColor = System.Drawing.Color.WhiteSmoke;
                            spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].Locked = false;
                        }
                        /*** End of Modification (2012.04.04) ***/
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdData_EnterCell(object sender, EnterCellEventArgs e)
        {
            try
            {
                if (spdData.ActiveSheet.Columns[KEY_1_COL].Visible == false)
                {
                    return;
                }
                if (e.Row == spdData.ActiveSheet.RowCount - 1)
                {
                    if (MPCF.Trim(spdData.ActiveSheet.Cells[e.Row, KEY_1_COL].Value) != "")
                    {
                        spdData.ActiveSheet.RowCount++;
                        int i = 0;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        for (i = 1; i <= 20; i++)
                        {
                            spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].BackColor = System.Drawing.Color.WhiteSmoke;
                            spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].Locked = false;
                        }
                        /*** End of Modification (2012.04.04) ***/
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnTableDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            if (UpdateDataList(MPGC.MP_STEP_DELETE) == false)
            {
                return;
            }

            ViewDataList(null);

        }

        private void cdvYieldBase_TextBoxTextChanged(object sender, EventArgs e)
        {
            if(MPCF.Trim(cdvYieldBase.Text)=="")
                return;

            if (cdvYieldBase.Text == MPGC.MP_LYD_BASE_OPER_IN || cdvYieldBase.Text == MPGC.MP_LYD_BASE_OPER_START ||
                cdvYieldBase.Text == MPGC.MP_LYD_BASE_OPER_OUT)
            {

                lblYeldbaseOper.Visible = true;
                cdvYieldBaseOper.Visible = true;
                cdvYieldBaseOper.Text = "";

                lblLotStatus.Visible = false;
                cdvLotStatus.Visible = false;
                cdvLotStatus.Text = "";
            }
            else if (cdvYieldBase.Text == MPGC.MP_LYD_BASE_LOT_STS || cdvYieldBase.Text == MPGC.MP_LYD_BASE_LOT_EXT)
            {

                lblYeldbaseOper.Visible = false;
                cdvYieldBaseOper.Visible = false;
                cdvYieldBaseOper.Text = "";

                lblLotStatus.Visible = true;
                cdvLotStatus.Visible = true;
                cdvLotStatus.Text = "";
            }
            else
            {
                lblLotStatus.Visible = false;
                cdvLotStatus.Visible = false;
                cdvLotStatus.Text = "";

                lblYeldbaseOper.Visible = false;
                cdvYieldBaseOper.Visible = false;
                cdvYieldBaseOper.Text = "";
            }
        }

        private void cdvCalUnitType_TextBoxTextChanged(object sender, EventArgs e)
        {
            
        }

        private void cdvLowYieldType_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
            {
            if (cdvLowYieldType.Text == MPGC.MP_LYD_TYPE_ALL || cdvLowYieldType.Text == MPGC.MP_LYD_TYPE_BC ||
                cdvLowYieldType.Text == MPGC.MP_LYD_TYPE_LC || cdvLowYieldType.Text == MPGC.MP_LYD_TYPE_OC)
            {
                lblCVType.Enabled = true;
                cboCVType.Enabled = true;
                cboCVType.Text = "";
            }
            else
            {
                lblCVType.Enabled = false;
                cboCVType.Enabled = false;
                cboCVType.Text = "";
            }
        }
                
        private void cdvLowYieldType_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (cdvLowYieldType.Text == MPGC.MP_LYD_TYPE_ALL || cdvLowYieldType.Text == MPGC.MP_LYD_TYPE_BC ||
                cdvLowYieldType.Text == MPGC.MP_LYD_TYPE_LC || cdvLowYieldType.Text == MPGC.MP_LYD_TYPE_OC)
            {
                lblCVType.Enabled = true;
                cboCVType.Enabled = true;
                cboCVType.Text = "";
            }
            else
            {
                lblCVType.Enabled = false;
                cboCVType.Enabled = false;
                cboCVType.Text = "";
            }
        }

        private void cdvLotStatus_ButtonPress(object sender, EventArgs e)
        {
            cdvLotStatus.Init();
            MPCF.InitListView(cdvLotStatus.GetListView);
            cdvLotStatus.Columns.Add("Column", 150, HorizontalAlignment.Left);
            cdvLotStatus.SelectedSubItemIndex = 0;

            if (MPCF.Trim(cdvYieldBase.Text)==MPGC.MP_LYD_BASE_LOT_STS)
                ViewTableColumnList(cdvLotStatus.GetListView, "MWIPLOTSTS");
            else if (MPCF.Trim(cdvYieldBase.Text) == MPGC.MP_LYD_BASE_LOT_EXT)
                ViewTableColumnList(cdvLotStatus.GetListView, "MWIPELTSTS");
        }

    }
}