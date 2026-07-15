using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPSetupBinGrade : SetupForm02
    {
        public frmWIPSetupBinGrade()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private string[] FormulaSyntax = new string[] {
            "CASE",
            "WHEN",
            "THEN",
            "END",
            "ABS",
            "EXP",
            "MOD",
            "POWER",
            "ROUND",
            "SQRT",
            "SIGN",
            "LN",
            "LOG",
            "TRUNC",
            "SIN",
            "COS",
            "TAN",
            "SINH",
            "COSH",
            "TANH",
            "ASIN",
            "ACOS",
            "ATAN",
            "ATAN2"
        };

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private bool b_allow_modify;

        #endregion

        #region " Function Definition "

        private void ClearData(int i_case)
        {
            switch(i_case)
            {
                case 1:
                    MPCF.FieldClear(grpBIN);
                    MPCF.FieldClear(grpTotLimit);
                    MPCF.FieldClear(grpCreateUpdate);
                    MPCF.FieldClear(grpUnitCmf);

                    MPCF.FieldClear(grpBinGrade);
                    MPCF.FieldClear(grpGradeControl);
                    MPCF.FieldClear(grpTGControl);
                    MPCF.FieldClear(grpTranAction);
                    MPCF.FieldClear(grpTGTranAction);
                    MPCF.FieldClear(grpPeriodicYield);
                    MPCF.FieldClear(grpBinGradeCmf);

                    txtFormula.Text = "";
                    txtTGFormula.Text = "";
                    SetTranControl(cdvTranCode.Text);
                    SetTGTranControl(cdvTGTranCode.Text);

                    MPCF.InitListView(lisBinList);
                    MPCF.ClearList(spdCond);
                    MPCF.ClearList(spdTGCond);
                    txtHelp.SendToBack();
                    
                    break;

                case 2:
                    MPCF.FieldClear(grpBinGrade);
                    MPCF.FieldClear(grpGradeControl);
                    MPCF.FieldClear(grpTGControl);
                    MPCF.FieldClear(grpTranAction);
                    MPCF.FieldClear(grpTGTranAction);
                    MPCF.FieldClear(grpPeriodicYield);
                    MPCF.FieldClear(grpBinGradeCmf);

                    txtFormula.Text = "";
                    txtTGFormula.Text = "";
                    SetTranControl(cdvTranCode.Text);
                    SetTGTranControl(cdvTGTranCode.Text);

                    MPCF.InitListView(lisBinList);
                    MPCF.ClearList(spdCond);
                    MPCF.ClearList(spdTGCond);
                    txtHelp.SendToBack();

                    break;

                case 3:
                    MPCF.FieldClear(grpBinGrade, cdvBinSeq);
                    MPCF.FieldClear(grpGradeControl);
                    MPCF.FieldClear(grpTGControl);
                    MPCF.FieldClear(grpTranAction);
                    MPCF.FieldClear(grpTGTranAction);
                    MPCF.FieldClear(grpPeriodicYield);
                    MPCF.FieldClear(grpBinGradeCmf);
                    MPCF.ClearList(spdCond);
                    MPCF.ClearList(spdTGCond);
                    txtHelp.SendToBack();

                    txtFormula.Text = "";
                    txtTGFormula.Text = "";
                    SetTranControl(cdvTranCode.Text);
                    SetTGTranControl(cdvTGTranCode.Text);

                    break;
            }
        }

        private bool CheckCondition(string ProcStep)
        {
            try
            {
                if (MPCF.CheckValue(txtBinID, 1) == false) return false;
                if (MPCF.CheckValue(cdvBinVersion, 1) == false) return false;
                if (MPCF.CheckValue(cdvBinUnit, 1) == false) return false;

                switch (ProcStep)
                {
                    case "UPDATE_BIN_UNIT":

                        if (MPCF.CheckValue(cdvTotalSplit, 1) == false) return false;
                        if (MPCF.CheckValue(cdvCalcType, 1) == false) return false;
                        if (MPCF.CheckValue(cdvYieldBase, 1) == false) return false;

                        if (MPCF.Trim(txtUpYield.Text) != "")
                            if (MPCF.CheckValue(txtUpYield, 2, true, false, MPCF.GetMessage(108), "", "") == false) return false;

                        if (MPCF.Trim(txtLoYield.Text) != "")
                            if (MPCF.CheckValue(txtLoYield, 2, true, false, MPCF.GetMessage(108), "", "") == false) return false;

                        if (MPCF.Trim(cdvCalcType.Text) == "%" && MPCF.ToDbl(txtUpYield.Text) != 0 && MPCF.ToDbl(txtUpYield.Text) > 100)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(189));
                            txtUpYield.Focus();
                            return false;
                        }
                        if (MPCF.Trim(cdvCalcType.Text) == "%" && MPCF.ToDbl(txtLoYield.Text) != 0 && MPCF.ToDbl(txtLoYield.Text) < 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(126));
                            txtLoYield.Focus();
                            return false;
                        }

                        if (MPCF.ToDbl(txtUpYield.Text) != 0 && MPCF.ToDbl(txtLoYield.Text) != 0 && MPCF.ToDbl(txtUpYield.Text) < MPCF.ToDbl(txtLoYield.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(146));
                            txtUpYield.Focus();
                            return false;
                        }

                        break;

                    case "DELETE_BIN_UNIT":
                        break;

                    case "UPDATE_BIN_GRADE":

                        if (MPCF.CheckValue(cdvBinSeq, 2) == false) return false;
                        if (MPCF.CheckValue(cdvBinPrompt, 1) == false) return false;
                        if (MPCF.CheckValue(cdvBinType, 1) == false) return false;

                        if (MPCF.Trim(txtValue.Text) != "")
                            if (MPCF.CheckValue(txtValue, 2, true, false, "", "", "") == false) return false;

                        if (MPCF.Trim(txtFormula.Text) == "" && (MPCF.Trim(cdvOperator.Text) != "" || MPCF.Trim(txtValue.Text) != ""))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            txtFormula.Focus();
                            return false;
                        }

                        if (MPCF.Trim(cdvOperator.Text) == "" && (MPCF.Trim(txtFormula.Text) != "" || MPCF.Trim(txtValue.Text) != ""))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            cdvOperator.Focus();
                            return false;
                        }
                        if (MPCF.Trim(txtValue.Text) == "" && (MPCF.Trim(txtFormula.Text) != "" || MPCF.Trim(cdvOperator.Text) != ""))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            txtValue.Focus();
                            return false;
                        }

                        if (MPCF.Trim(txtTGValue.Text) != "")
                            if (MPCF.CheckValue(txtTGValue, 2, true, false, "", "", "") == false) return false;

                        if (MPCF.Trim(txtTGFormula.Text) == "" && (MPCF.Trim(cdvTGOperator.Text) != "" || MPCF.Trim(txtTGValue.Text) != ""))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            txtTGFormula.Focus();
                            return false;
                        }

                        if (MPCF.Trim(cdvTGOperator.Text) == "" && (MPCF.Trim(txtTGFormula.Text) != "" || MPCF.Trim(txtTGValue.Text) != ""))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            cdvTGOperator.Focus();
                            return false;
                        }
                        if (MPCF.Trim(txtTGValue.Text) == "" && (MPCF.Trim(txtTGFormula.Text) != "" || MPCF.Trim(cdvTGOperator.Text) != ""))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            txtTGValue.Focus();
                            return false;
                        }

                        if (MPCF.Trim(txtPeriodicUpYield.Text) != "")
                            if (MPCF.CheckValue(txtPeriodicUpYield, 2, true, false, MPCF.GetMessage(108), "", "") == false) return false;

                        if (MPCF.Trim(txtPeriodicLoYield.Text) != "")
                            if (MPCF.CheckValue(txtPeriodicLoYield, 2, true, false, MPCF.GetMessage(108), "", "") == false) return false;

                        if (MPCF.ToDbl(txtPeriodicUpYield.Text) != 0 && MPCF.ToDbl(txtPeriodicLoYield.Text) != 0 && 
                            MPCF.ToDbl(txtPeriodicUpYield.Text) < MPCF.ToDbl(txtPeriodicLoYield.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(146));
                            txtPeriodicUpYield.Focus();
                            return false;
                        }

                        break;

                    case "DELETE_BIN_GRADE":

                        break;

                    default:
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

        private void SetCustomizedField()
        {
            MPCR.SetCMFItem(MPGC.MP_CMF_BIN_UNIT, "lblUnitCmf", "cdvUnitCmf", grpUnitCmf);
            MPCR.SetCMFItem(MPGC.MP_CMF_BIN_GRADE, "lblGradeCmf", "cdvGradeCmf", grpBinGradeCmf);
        }

        private bool ViewBinVersion()
        {
            TRSNode in_node = new TRSNode("VIEW_BIN_IN");
            TRSNode out_node = new TRSNode("VIEW_BIN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("BIN_ID", MPCF.Trim(txtBinID.Text));
                in_node.AddInt("BIN_VERSION", MPCF.ToInt(cdvBinVersion.Text));

                if (MPCR.CallService("WIP", "WIP_View_Bin_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtBinVerCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtBinVerCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtBinVerUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                txtBinVerUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                b_allow_modify = true;
                MPCR.ChangeControlEnabled(this, btnApproval, true);
                MPCR.ChangeControlEnabled(this, btnCancelApproval, false);
                MPCR.ChangeControlEnabled(this, btnRelease, true);

                if (tabBIN.SelectedTab == tbpBinVerAppRel)
                {
                    MPCR.ChangeControlEnabled(this, btnCreate, false);
                    MPCR.ChangeControlEnabled(this, btnUpdate, false);
                    MPCR.ChangeControlEnabled(this, btnDelete, false);
                }
                else
                {
                    MPCR.ChangeControlEnabled(this, btnCreate, true);
                    MPCR.ChangeControlEnabled(this, btnUpdate, true);
                    MPCR.ChangeControlEnabled(this, btnDelete, true);
                }

                if (out_node.GetChar("APPROVAL_FLAG") == 'Y')
                {
                    b_allow_modify = false;
                    txtAppUser.Text = out_node.GetString("APPROVAL_USER_ID");
                    txtAppTime.Text = MPCF.MakeDateFormat(out_node.GetString("APPROVAL_TIME"));

                    MPCR.ChangeControlEnabled(this, btnApproval, false);
                    MPCR.ChangeControlEnabled(this, btnCancelApproval, true);
                    MPCR.ChangeControlEnabled(this, btnRelease, true);
                    MPCR.ChangeControlEnabled(this, btnCreate, false);
                    MPCR.ChangeControlEnabled(this, btnUpdate, false);
                    MPCR.ChangeControlEnabled(this, btnDelete, false);
                }
                if (out_node.GetChar("RELEASE_FLAG") == 'Y')
                {
                    b_allow_modify = false;
                    txtRelUser.Text = out_node.GetString("RELEASE_USER_ID");
                    txtRelTime.Text = MPCF.MakeDateFormat(out_node.GetString("RELEASE_TIME"));

                    MPCR.ChangeControlEnabled(this, btnApproval, false);
                    MPCR.ChangeControlEnabled(this, btnCancelApproval, false);
                    MPCR.ChangeControlEnabled(this, btnRelease, false);
                    MPCR.ChangeControlEnabled(this, btnCreate, false);
                    MPCR.ChangeControlEnabled(this, btnUpdate, false);
                    MPCR.ChangeControlEnabled(this, btnDelete, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool UpdateBinVersion(char c_step)
        {
            TRSNode in_node = new TRSNode("UPDATE_BIN_VERSION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_UPDATE;
                in_node.AddString("BIN_ID", MPCF.Trim(txtBinID.Text));
                in_node.AddInt("BIN_VERSION", MPCF.ToInt(cdvBinVersion.Text));

                switch (c_step)
                {
                    case MPGC.MP_STEP_APPROVAL:
                        in_node.AddChar("APPROVAL_FLAG", 'Y');
                        break;
                    case MPGC.MP_STEP_CANCEL_APPROVAL:
                        in_node.AddChar("CANCEL_APPROVAL_FLAG", 'Y');
                        break;
                    case MPGC.MP_STEP_RELEASE:
                        in_node.AddChar("RELEASE_FLAG", 'Y');
                        break;
                }

                if (MPCR.CallService("WIP", "WIP_Update_Bin_Version", in_node, ref out_node) == false)
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

        private bool UpdateBinUnit(char c_step)
        {
            TRSNode in_node = new TRSNode("UPDATE_BIN_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("BIN_ID", MPCF.Trim(txtBinID.Text));
                in_node.AddInt("BIN_VERSION", MPCF.ToInt(cdvBinVersion.Text));
                in_node.AddString("BIN_UNIT", MPCF.Trim(cdvBinUnit.Text));

                in_node.AddChar("TOT_SPLIT_FLAG", MPCF.ToChar(cdvTotalSplit.Text));
                in_node.AddString("BIN_UNIT_DESC", MPCF.Trim(txtBinDescription.Text));

                in_node.AddChar("YIELD_CALC_TYPE", MPCF.Trim(cdvCalcType.Text));
                in_node.AddString("YIELD_BASE", MPCF.Trim(cdvYieldBase.Text));
                in_node.AddString("YIELD_BASE_OPER", MPCF.Trim(cdvYieldBaseOper.Text));
                in_node.AddString("UPPER_LIMIT", MPCF.Trim(txtUpYield.Text));
                in_node.AddString("LOWER_LIMIT", MPCF.Trim(txtLoYield.Text));
                in_node.AddString("ALARM_ID", MPCF.Trim(cdvAlarmID.Text));
                in_node.AddChar("USE_SPEC_LIMIT_FLAG", chkUseSpecYield.Checked == true ? 'Y' : ' ');
                in_node.AddString("USE_SPEC_CHAR_ID", MPCF.Trim(cdvSpecCharID.Text));

                in_node.AddString("BIN_UNIT_CMF_1", MPCF.Trim(cdvUnitCmf1.Text));
                in_node.AddString("BIN_UNIT_CMF_2", MPCF.Trim(cdvUnitCmf2.Text));
                in_node.AddString("BIN_UNIT_CMF_3", MPCF.Trim(cdvUnitCmf3.Text));
                in_node.AddString("BIN_UNIT_CMF_4", MPCF.Trim(cdvUnitCmf4.Text));
                in_node.AddString("BIN_UNIT_CMF_5", MPCF.Trim(cdvUnitCmf5.Text));
                in_node.AddString("BIN_UNIT_CMF_6", MPCF.Trim(cdvUnitCmf6.Text));
                in_node.AddString("BIN_UNIT_CMF_7", MPCF.Trim(cdvUnitCmf7.Text));
                in_node.AddString("BIN_UNIT_CMF_8", MPCF.Trim(cdvUnitCmf8.Text));
                in_node.AddString("BIN_UNIT_CMF_9", MPCF.Trim(cdvUnitCmf9.Text));
                in_node.AddString("BIN_UNIT_CMF_10", MPCF.Trim(cdvUnitCmf10.Text));
                in_node.AddString("BIN_UNIT_CMF_11", MPCF.Trim(cdvUnitCmf11.Text));
                in_node.AddString("BIN_UNIT_CMF_12", MPCF.Trim(cdvUnitCmf12.Text));
                in_node.AddString("BIN_UNIT_CMF_13", MPCF.Trim(cdvUnitCmf13.Text));
                in_node.AddString("BIN_UNIT_CMF_14", MPCF.Trim(cdvUnitCmf14.Text));
                in_node.AddString("BIN_UNIT_CMF_15", MPCF.Trim(cdvUnitCmf15.Text));
                in_node.AddString("BIN_UNIT_CMF_16", MPCF.Trim(cdvUnitCmf16.Text));
                in_node.AddString("BIN_UNIT_CMF_17", MPCF.Trim(cdvUnitCmf17.Text));
                in_node.AddString("BIN_UNIT_CMF_18", MPCF.Trim(cdvUnitCmf18.Text));
                in_node.AddString("BIN_UNIT_CMF_19", MPCF.Trim(cdvUnitCmf19.Text));
                in_node.AddString("BIN_UNIT_CMF_20", MPCF.Trim(cdvUnitCmf20.Text));

                if (MPCR.CallService("WIP", "WIP_Update_Bin_Unit", in_node, ref out_node) == false)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool ViewBinUnit()
        {
            TRSNode in_node = new TRSNode("VIEW_BIN_IN");
            TRSNode out_node = new TRSNode("VIEW_BIN_OUT");
            ListViewItem itmX;
            List<TRSNode> grade_list;
            int i;

            try
            {
                MPCF.InitListView(lisBinList);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("BIN_ID", MPCF.Trim(txtBinID.Text));
                in_node.AddInt("BIN_VERSION", MPCF.ToInt(cdvBinVersion.Text));
                in_node.AddString("BIN_UNIT", MPCF.Trim(cdvBinUnit.Text));

                do
                {
                    if (MPCR.CallService("WIP", "WIP_View_Bin_Unit", in_node, ref out_node, true) == false)
                    {
                        return false;
                    }

                    if (in_node.GetInt("NEXT_BIN_SEQ") < 1)
                    {
                        txtBinDescription.Text = out_node.GetString("BIN_UNIT_DESC");

                        cdvTotalSplit.Text = out_node.GetChar("TOT_SPLIT_FLAG").ToString();
                        cdvCalcType.Text = out_node.GetChar("YIELD_CALC_TYPE").ToString();
                        cdvYieldBase.Text = out_node.GetString("YIELD_BASE");
                        cdvYieldBaseOper.Text = out_node.GetString("YIELD_BASE_OPER");
                        txtUpYield.Text = out_node.GetString("UPPER_LIMIT");
                        txtLoYield.Text = out_node.GetString("LOWER_LIMIT");
                        cdvAlarmID.Text = out_node.GetString("ALARM_ID");
                        chkUseSpecYield.Checked = out_node.GetChar("USE_SPEC_LIMIT_FLAG") == 'Y' ? true : false;
                        cdvSpecCharID.Text = out_node.GetString("USE_SPEC_CHAR_ID");

                        cdvUnitCmf1.Text = out_node.GetString("BIN_UNIT_CMF_1");
                        cdvUnitCmf2.Text = out_node.GetString("BIN_UNIT_CMF_2");
                        cdvUnitCmf3.Text = out_node.GetString("BIN_UNIT_CMF_3");
                        cdvUnitCmf4.Text = out_node.GetString("BIN_UNIT_CMF_4");
                        cdvUnitCmf5.Text = out_node.GetString("BIN_UNIT_CMF_5");
                        cdvUnitCmf6.Text = out_node.GetString("BIN_UNIT_CMF_6");
                        cdvUnitCmf7.Text = out_node.GetString("BIN_UNIT_CMF_7");
                        cdvUnitCmf8.Text = out_node.GetString("BIN_UNIT_CMF_8");
                        cdvUnitCmf9.Text = out_node.GetString("BIN_UNIT_CMF_9");
                        cdvUnitCmf10.Text = out_node.GetString("BIN_UNIT_CMF_10");
                        cdvUnitCmf11.Text = out_node.GetString("BIN_UNIT_CMF_11");
                        cdvUnitCmf12.Text = out_node.GetString("BIN_UNIT_CMF_12");
                        cdvUnitCmf13.Text = out_node.GetString("BIN_UNIT_CMF_13");
                        cdvUnitCmf14.Text = out_node.GetString("BIN_UNIT_CMF_14");
                        cdvUnitCmf15.Text = out_node.GetString("BIN_UNIT_CMF_15");
                        cdvUnitCmf16.Text = out_node.GetString("BIN_UNIT_CMF_16");
                        cdvUnitCmf17.Text = out_node.GetString("BIN_UNIT_CMF_17");
                        cdvUnitCmf18.Text = out_node.GetString("BIN_UNIT_CMF_18");
                        cdvUnitCmf19.Text = out_node.GetString("BIN_UNIT_CMF_19");
                        cdvUnitCmf20.Text = out_node.GetString("BIN_UNIT_CMF_20");

                        txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                        txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                        txtUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                        txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
                    }

                    grade_list = out_node.GetList("GRADE_LIST");
                    for (i = 0; i < grade_list.Count; i++)
                    {
                        itmX = new ListViewItem(grade_list[i].GetInt("BIN_SEQ").ToString("000"), (int)SMALLICON_INDEX.IDX_MATERIAL);

                        itmX.SubItems.Add(grade_list[i].GetString("BIN_PROMPT"));
                        if (grade_list[i].GetChar("BIN_TYPE") == 'P')
                        {
                            itmX.SubItems.Add(MPCF.FindLanguage("Pass", CAPTION_TYPE.LABEL));
                        }
                        else if (grade_list[i].GetChar("BIN_TYPE") == 'F')
                        {
                            itmX.SubItems.Add(MPCF.FindLanguage("Fail", CAPTION_TYPE.LABEL));
                        }
                        else
                        {
                            itmX.SubItems.Add(grade_list[i].GetChar("BIN_TYPE").ToString());
                        }
                        itmX.SubItems.Add(grade_list[i].GetChar("LOGICAL_BIN_FLAG").ToString());
                        itmX.SubItems.Add(grade_list[i].GetChar("KEEP_LOT_FLAG").ToString());
                        if (grade_list[i].GetInt("SPLIT_BY_BIN_SEQ") > 0)
                        {
                            itmX.SubItems.Add(grade_list[i].GetInt("SPLIT_BY_BIN_SEQ").ToString("000"));
                        }
                        else
                        {
                            itmX.SubItems.Add("");
                        }
                        itmX.SubItems.Add(grade_list[i].GetString("BIN_PROMPT_DESC"));

                        lisBinList.Items.Add(itmX);
                    }

                    in_node.SetInt("NEXT_BIN_SEQ", out_node.GetInt("NEXT_BIN_SEQ"));
                } while (in_node.GetInt("NEXT_BIN_SEQ") > 0);

                MPCF.FitColumnHeader(lisBinList);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool UpdateBinGrade(char c_step)
        {
            TRSNode in_node = new TRSNode("UPDATE_BIN_GRADE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode list_item;
            int i;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                in_node.AddString("BIN_ID", MPCF.Trim(txtBinID.Text));
                in_node.AddInt("BIN_VERSION", MPCF.ToInt(cdvBinVersion.Text));
                in_node.AddString("BIN_UNIT", MPCF.Trim(cdvBinUnit.Text));

                in_node.AddInt("BIN_SEQ", MPCF.ToInt(cdvBinSeq.Text));
                in_node.AddString("BIN_PROMPT", MPCF.Trim(cdvBinPrompt.Text));
                in_node.AddString("BIN_PROMPT_DESC", MPCF.Trim(txtBinPromptDesc.Text));

                in_node.AddChar("BIN_TYPE", MPCF.ToChar(cdvBinType.Text));
                in_node.AddChar("KEEP_LOT_FLAG", MPCF.ToChar(cdvKeepLot.Text));
                in_node.AddChar("LOGICAL_BIN_FLAG", chkLogicalBinFlag.Checked == true ? 'Y' : ' ');
                in_node.AddInt("SPLIT_BY_BIN_SEQ", MPCF.ToInt(cdvSplitBy.Text));
                in_node.AddString("SPLIT_LOT_ID_RULE", MPCF.Trim(cdvSplitLotIDRule.Text));
                in_node.AddChar("KEEP_LOT_QTY_FLAG", chkKeepLotQty.Checked == true ? 'Y' : ' ');
                
                if (MPCF.ToChar(cdvBinType.Text) == 'F')
                {
                    if (chkUseBinPrompt.Checked == true)
                    {
                        in_node.AddChar("USE_BIN_PROMPT_FLAG", 'Y');
                        in_node.AddString("FAIL_REASON_CODE", MPCF.Trim(cdvBinPrompt.Text));
                    }
                    else
                    {
                        in_node.AddChar("USE_BIN_PROMPT_FLAG", ' ');
                        in_node.AddString("FAIL_REASON_CODE", MPCF.Trim(cdvFailReasonCode.Text));
                        in_node.AddString("REASON_CODE_REF_OPER", MPCF.Trim(cdvReasonCodeRefOper.Text));
                    }
                }

                in_node.AddString("CHANGE_MAT_ID", MPCF.Trim(cdvChgMaterial.Text));
                in_node.AddInt("CHANGE_MAT_VER", cdvChgMaterial.Version);
                in_node.AddString("CHANGE_FLOW", MPCF.Trim(cdvChgFlow.Text));
                in_node.AddInt("CHANGE_FLOW_SEQ_NUM", cdvChgFlow.Sequence);
                in_node.AddString("MOVE_TO_OPER", MPCF.Trim(cdvMoveToOper.Text));
                in_node.AddChar("CHANGE_LOT_TYPE", MPCF.Trim(cdvChgLotType.Text));
                in_node.AddChar("CHANGE_LOT_PRIORITY", MPCF.Trim(cboPriority.Text));
                in_node.AddString("CHANGE_CREATE_CODE", MPCF.Trim(cdvChgCreateCode.Text));
                in_node.AddString("CHANGE_OWNER_CODE", MPCF.Trim(cdvChgOwnerCode.Text));
                in_node.AddString("CHANGE_CRR_GROUP", MPCF.Trim(cdvChgCrrGrp.Text));

                in_node.AddString("TRAN_CODE", MPCF.Trim(cdvTranCode.Text));
                in_node.AddString("TRAN_KEY_REF_OPER", MPCF.Trim(cdvRefOper.Text));
                in_node.AddString("TRAN_KEY_CODE_1", MPCF.Trim(cdvReasonCode.Text));
                in_node.AddString("TRAN_KEY_CODE_2", MPCF.Trim(txtHoldPass.Text));

                in_node.AddString("TRAN_TO_MAT_ID", MPCF.Trim(cdvToMaterial.Text));
                in_node.AddInt("TRAN_TO_MAT_VER", cdvToMaterial.Version);
                in_node.AddString("TRAN_TO_FLOW", MPCF.Trim(cdvToFlow.Text));
                in_node.AddInt("TRAN_TO_FLOW_SEQ_NUM", cdvToFlow.Sequence);
                in_node.AddString("TRAN_TO_OPER", MPCF.Trim(cdvToOper.Text));
                in_node.AddString("TRAN_STOP_OPER", MPCF.Trim(cdvToStopOper.Text));
                in_node.AddString("TRAN_RET_FLOW", MPCF.Trim(cdvRetFlow.Text));
                in_node.AddInt("TRAN_RET_FLOW_SEQ_NUM", cdvRetFlow.Sequence);
                in_node.AddString("TRAN_RET_OPER", MPCF.Trim(cdvRetOper.Text));
                in_node.AddString("TRAN_RET_OPTION", MPCF.Trim(cboReturnOption.Text));
                in_node.AddString("TRAN_COMMENT", MPCF.Trim(txtTranCmt.Text));

                in_node.AddString("TG_TRAN_CODE", MPCF.Trim(cdvTGTranCode.Text));
                in_node.AddString("TG_TRAN_KEY_REF_OPER", MPCF.Trim(cdvTGRefOper.Text));
                in_node.AddString("TG_TRAN_KEY_CODE_1", MPCF.Trim(cdvTGReasonCode.Text));
                in_node.AddString("TG_TRAN_KEY_CODE_2", MPCF.Trim(txtTGHoldPass.Text));

                in_node.AddString("TG_TRAN_TO_MAT_ID", MPCF.Trim(cdvTGToMaterial.Text));
                in_node.AddInt("TG_TRAN_TO_MAT_VER", cdvTGToMaterial.Version);
                in_node.AddString("TG_TRAN_TO_FLOW", MPCF.Trim(cdvTGToFlow.Text));
                in_node.AddInt("TG_TRAN_TO_FLOW_SEQ_NUM", cdvTGToFlow.Sequence);
                in_node.AddString("TG_TRAN_TO_OPER", MPCF.Trim(cdvTGToOper.Text));
                in_node.AddString("TG_TRAN_STOP_OPER", MPCF.Trim(cdvTGToStopOper.Text));
                in_node.AddString("TG_TRAN_RET_FLOW", MPCF.Trim(cdvTGRetFlow.Text));
                in_node.AddInt("TG_TRAN_RET_FLOW_SEQ_NUM", cdvTGRetFlow.Sequence);
                in_node.AddString("TG_TRAN_RET_OPER", MPCF.Trim(cdvTGRetOper.Text));
                in_node.AddString("TG_TRAN_RET_OPTION", MPCF.Trim(cboTGRetOption.Text));
                in_node.AddString("TG_TRAN_COMMENT", MPCF.Trim(txtTGTranCmt.Text));

                for (i = 0; i < spdCond.ActiveSheet.RowCount; i++)
                {
                    list_item = in_node.AddNode("COND_LIST");
                    list_item.AddString("AND_OR", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 0].Value));
                    list_item.AddString("L_BRACKET", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 1].Value));
                    list_item.AddString("FORMULA", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 2].Value));
                    list_item.AddString("OPERATOR", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 3].Value));
                    list_item.AddString("TARGET_VALUE", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 4].Value));
                    list_item.AddString("R_BRACKET", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 5].Value));
                }

                for (i = 0; i < spdTGCond.ActiveSheet.RowCount; i++)
                {
                    list_item = in_node.AddNode("TG_COND_LIST");
                    list_item.AddString("AND_OR", MPCF.Trim(spdTGCond.ActiveSheet.Cells[i, 0].Value));
                    list_item.AddString("L_BRACKET", MPCF.Trim(spdTGCond.ActiveSheet.Cells[i, 1].Value));
                    list_item.AddString("FORMULA", MPCF.Trim(spdTGCond.ActiveSheet.Cells[i, 2].Value));
                    list_item.AddString("OPERATOR", MPCF.Trim(spdTGCond.ActiveSheet.Cells[i, 3].Value));
                    list_item.AddString("TARGET_VALUE", MPCF.Trim(spdTGCond.ActiveSheet.Cells[i, 4].Value));
                    list_item.AddString("R_BRACKET", MPCF.Trim(spdTGCond.ActiveSheet.Cells[i, 5].Value));
                }


                if (cboPeriodicPeriod.SelectedIndex > 0)
                {
                    if (cboPeriodicPeriod.SelectedIndex == 8)
                        in_node.AddInt("PY_PERIOD", cboPeriodicPeriod.SelectedIndex + 4); // 12
                    else if (cboPeriodicPeriod.SelectedIndex == 7)
                        in_node.AddInt("PY_PERIOD", cboPeriodicPeriod.SelectedIndex + 2); // 9
                    else
                        in_node.AddInt("PY_PERIOD", cboPeriodicPeriod.SelectedIndex); // 1,2,3,4,5,6

                    in_node.AddString("PY_UPPER_LIMIT", MPCF.Trim(txtPeriodicUpYield.Text));
                    in_node.AddString("PY_LOWER_LIMIT", MPCF.Trim(txtPeriodicLoYield.Text));
                    in_node.AddChar("PY_USE_SPEC_LIMIT_FLAG", chkPeriodicUseSpec.Checked == true ? 'Y' : ' ');
                    in_node.AddString("PY_USE_SPEC_CHAR_ID", MPCF.Trim(cdvPeriodicSpecCharID.Text));
                    in_node.AddString("PY_ALARM_ID", MPCF.Trim(cdvPeriodicAlarmID.Text));
                }

                in_node.AddString("BIN_GRADE_CMF_1", MPCF.Trim(cdvGradeCmf1.Text));
                in_node.AddString("BIN_GRADE_CMF_2", MPCF.Trim(cdvGradeCmf2.Text));
                in_node.AddString("BIN_GRADE_CMF_3", MPCF.Trim(cdvGradeCmf3.Text));
                in_node.AddString("BIN_GRADE_CMF_4", MPCF.Trim(cdvGradeCmf4.Text));
                in_node.AddString("BIN_GRADE_CMF_5", MPCF.Trim(cdvGradeCmf5.Text));
                in_node.AddString("BIN_GRADE_CMF_6", MPCF.Trim(cdvGradeCmf6.Text));
                in_node.AddString("BIN_GRADE_CMF_7", MPCF.Trim(cdvGradeCmf7.Text));
                in_node.AddString("BIN_GRADE_CMF_8", MPCF.Trim(cdvGradeCmf8.Text));
                in_node.AddString("BIN_GRADE_CMF_9", MPCF.Trim(cdvGradeCmf9.Text));
                in_node.AddString("BIN_GRADE_CMF_10", MPCF.Trim(cdvGradeCmf10.Text));
                in_node.AddString("BIN_GRADE_CMF_11", MPCF.Trim(cdvGradeCmf11.Text));
                in_node.AddString("BIN_GRADE_CMF_12", MPCF.Trim(cdvGradeCmf12.Text));
                in_node.AddString("BIN_GRADE_CMF_13", MPCF.Trim(cdvGradeCmf13.Text));
                in_node.AddString("BIN_GRADE_CMF_14", MPCF.Trim(cdvGradeCmf14.Text));
                in_node.AddString("BIN_GRADE_CMF_15", MPCF.Trim(cdvGradeCmf15.Text));
                in_node.AddString("BIN_GRADE_CMF_16", MPCF.Trim(cdvGradeCmf16.Text));
                in_node.AddString("BIN_GRADE_CMF_17", MPCF.Trim(cdvGradeCmf17.Text));
                in_node.AddString("BIN_GRADE_CMF_18", MPCF.Trim(cdvGradeCmf18.Text));
                in_node.AddString("BIN_GRADE_CMF_19", MPCF.Trim(cdvGradeCmf19.Text));
                in_node.AddString("BIN_GRADE_CMF_20", MPCF.Trim(cdvGradeCmf20.Text));

                if (MPCR.CallService("WIP", "WIP_Update_Bin_Grade", in_node, ref out_node) == false)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool ViewBinGrade(int i_bin_seq)
        {
            TRSNode in_node = new TRSNode("VIEW_BIN_GRADE_IN");
            TRSNode out_node = new TRSNode("VIEW_BIN_GRADE_OUT");
            List<TRSNode> list_node;
            int i;
            int i1;

            try
            {
                MPCF.ClearList(spdCond);
                MPCF.ClearList(spdTGCond);

                MPCR.SetInMsg(in_node);

                in_node.ProcStep = '1';
                in_node.AddString("BIN_ID", txtBinID.Text);
                in_node.AddInt("BIN_VERSION", MPCF.ToInt(cdvBinVersion.Text));
                in_node.AddString("BIN_UNIT", cdvBinUnit.Text);
                in_node.AddInt("BIN_SEQ", i_bin_seq);


                if (MPCR.CallService("WIP", "WIP_View_Bin_Grade", in_node, ref out_node) == false)
                {
                    return false;
                }

                cdvBinSeq.Text = out_node.GetInt("BIN_SEQ").ToString("000");
                cdvBinPrompt.Text = out_node.GetString("BIN_PROMPT");
                txtBinPromptDesc.Text = out_node.GetString("BIN_PROMPT_DESC");

                cdvBinType.Text = out_node.GetChar("BIN_TYPE").ToString();
                cdvKeepLot.Text = out_node.GetChar("KEEP_LOT_FLAG").ToString();
                chkLogicalBinFlag.Checked = out_node.GetChar("LOGICAL_BIN_FLAG") == 'Y' ? true : false;

                cdvSplitBy.Text = "";
                if (out_node.GetInt("SPLIT_BY_BIN_SEQ") > 0)
                {
                    cdvSplitBy.Text = out_node.GetInt("SPLIT_BY_BIN_SEQ").ToString("000");
                }

                cdvSplitLotIDRule.Text = out_node.GetString("SPLIT_LOT_ID_RULE");
                chkKeepLotQty.Checked = out_node.GetChar("KEEP_LOT_QTY_FLAG") == 'Y' ? true : false;
                chkUseBinPrompt.Checked = out_node.GetChar("USE_BIN_PROMPT_FLAG") == 'Y' ? true : false;

                cdvFailReasonCode.Text = "";
                cdvReasonCodeRefOper.Text = "";
                if (out_node.GetChar("BIN_TYPE") == 'F' && out_node.GetChar("USE_BIN_PROMPT_FLAG") != 'Y')
                {
                    cdvFailReasonCode.Text = out_node.GetString("FAIL_REASON_CODE");
                    cdvReasonCodeRefOper.Text = out_node.GetString("REASON_CODE_REF_OPER");
                }

                cdvChgMaterial.Text = out_node.GetString("CHANGE_MAT_ID");
                cdvChgMaterial.Version = out_node.GetInt("CHANGE_MAT_VER");
                cdvChgFlow.Text = out_node.GetString("CHANGE_FLOW");
                cdvChgFlow.Sequence = out_node.GetInt("CHANGE_FLOW_SEQ_NUM");
                cdvMoveToOper.Text = out_node.GetString("MOVE_TO_OPER");
                cdvChgLotType.Text = out_node.GetChar("CHANGE_LOT_TYPE").ToString();
                cboPriority.Text = out_node.GetChar("CHANGE_LOT_PRIORITY").ToString();
                cdvChgCreateCode.Text = out_node.GetString("CHANGE_CREATE_CODE");
                cdvChgOwnerCode.Text = out_node.GetString("CHANGE_OWNER_CODE");
                cdvChgCrrGrp.Text = out_node.GetString("CHANGE_CRR_GROUP");

                cdvTranCode.Text = out_node.GetString("TRAN_CODE");
                SetTranControl(cdvTranCode.Text);

                cdvRefOper.Text = out_node.GetString("TRAN_KEY_REF_OPER");
                cdvReasonCode.Text = out_node.GetString("TRAN_KEY_CODE_1");
                txtHoldPass.Text = out_node.GetString("TRAN_KEY_CODE_2");

                cdvToMaterial.Text = out_node.GetString("TRAN_TO_MAT_ID");
                cdvToMaterial.Version = out_node.GetInt("TRAN_TO_MAT_VER");
                cdvToFlow.Text = out_node.GetString("TRAN_TO_FLOW");
                cdvToFlow.Sequence = out_node.GetInt("TRAN_TO_FLOW_SEQ_NUM");
                cdvToOper.Text = out_node.GetString("TRAN_TO_OPER");
                cdvToStopOper.Text = out_node.GetString("TRAN_STOP_OPER");
                cdvRetFlow.Text = out_node.GetString("TRAN_RET_FLOW");
                cdvRetFlow.Sequence = out_node.GetInt("TRAN_RET_FLOW_SEQ_NUM");
                cdvRetOper.Text = out_node.GetString("TRAN_RET_OPER");
                cboReturnOption.Text = out_node.GetString("TRAN_RET_OPTION");
                txtTranCmt.Text = out_node.GetString("TRAN_COMMENT");

                cdvTGTranCode.Text = out_node.GetString("TG_TRAN_CODE");
                SetTGTranControl(cdvTGTranCode.Text);

                cdvTGRefOper.Text = out_node.GetString("TG_TRAN_KEY_REF_OPER");
                cdvTGReasonCode.Text = out_node.GetString("TG_TRAN_KEY_CODE_1");
                txtTGHoldPass.Text = out_node.GetString("TG_TRAN_KEY_CODE_2");

                cdvTGToMaterial.Text = out_node.GetString("TG_TRAN_TO_MAT_ID");
                cdvTGToMaterial.Version = out_node.GetInt("TG_TRAN_TO_MAT_VER");
                cdvTGToFlow.Text = out_node.GetString("TG_TRAN_TO_FLOW");
                cdvTGToFlow.Sequence = out_node.GetInt("TG_TRAN_TO_FLOW_SEQ_NUM");
                cdvTGToOper.Text = out_node.GetString("TG_TRAN_TO_OPER");
                cdvTGToStopOper.Text = out_node.GetString("TG_TRAN_STOP_OPER");
                cdvTGRetFlow.Text = out_node.GetString("TG_TRAN_RET_FLOW");
                cdvTGRetFlow.Sequence = out_node.GetInt("TG_TRAN_RET_FLOW_SEQ_NUM");
                cdvTGRetOper.Text = out_node.GetString("TG_TRAN_RET_OPER");
                cboTGRetOption.Text = out_node.GetString("TG_TRAN_RET_OPTION");
                txtTGTranCmt.Text = out_node.GetString("TG_TRAN_COMMENT");

                list_node = out_node.GetList("COND_LIST");
                for (i = 0; i < list_node.Count; i++)
                {
                    i1 = spdCond.ActiveSheet.RowCount;
                    spdCond.ActiveSheet.RowCount++;

                    spdCond.ActiveSheet.Cells[i1, 0].Value = list_node[i].GetString("AND_OR");
                    spdCond.ActiveSheet.Cells[i1, 1].Value = list_node[i].GetString("L_BRACKET");
                    spdCond.ActiveSheet.Cells[i1, 2].Value = list_node[i].GetString("FORMULA");
                    spdCond.ActiveSheet.Cells[i1, 3].Value = list_node[i].GetString("OPERATOR");
                    spdCond.ActiveSheet.Cells[i1, 4].Value = list_node[i].GetString("TARGET_VALUE");
                    spdCond.ActiveSheet.Cells[i1, 5].Value = list_node[i].GetString("R_BRACKET");
                }

                list_node = out_node.GetList("TG_COND_LIST");
                for (i = 0; i < list_node.Count; i++)
                {
                    i1 = spdTGCond.ActiveSheet.RowCount;
                    spdTGCond.ActiveSheet.RowCount++;

                    spdTGCond.ActiveSheet.Cells[i1, 0].Value = list_node[i].GetString("AND_OR");
                    spdTGCond.ActiveSheet.Cells[i1, 1].Value = list_node[i].GetString("L_BRACKET");
                    spdTGCond.ActiveSheet.Cells[i1, 2].Value = list_node[i].GetString("FORMULA");
                    spdTGCond.ActiveSheet.Cells[i1, 3].Value = list_node[i].GetString("OPERATOR");
                    spdTGCond.ActiveSheet.Cells[i1, 4].Value = list_node[i].GetString("TARGET_VALUE");
                    spdTGCond.ActiveSheet.Cells[i1, 5].Value = list_node[i].GetString("R_BRACKET");
                }


                cboPeriodicPeriod.SelectedIndex = 0;
                int i_periodic_period = out_node.GetInt("PY_PERIOD");
                if (i_periodic_period > 0)
                {
                    if (i_periodic_period == 12)
                        cboPeriodicPeriod.SelectedIndex = 8;
                    else if (i_periodic_period == 9)
                        cboPeriodicPeriod.SelectedIndex = 7;
                    else
                        cboPeriodicPeriod.SelectedIndex = i_periodic_period;

                    txtPeriodicUpYield.Text = out_node.GetString("PY_UPPER_LIMIT");
                    txtPeriodicLoYield.Text = out_node.GetString("PY_LOWER_LIMIT");
                    chkPeriodicUseSpec.Checked = out_node.GetChar("PY_USE_SPEC_LIMIT_FLAG") == 'Y' ? true : false;
                    cdvPeriodicSpecCharID.Text = out_node.GetString("PY_USE_SPEC_CHAR_ID");
                    cdvPeriodicAlarmID.Text = out_node.GetString("PY_ALARM_ID");
                }

                cdvGradeCmf1.Text = out_node.GetString("BIN_GRADE_CMF_1");
                cdvGradeCmf2.Text = out_node.GetString("BIN_GRADE_CMF_2");
                cdvGradeCmf3.Text = out_node.GetString("BIN_GRADE_CMF_3");
                cdvGradeCmf4.Text = out_node.GetString("BIN_GRADE_CMF_4");
                cdvGradeCmf5.Text = out_node.GetString("BIN_GRADE_CMF_5");
                cdvGradeCmf6.Text = out_node.GetString("BIN_GRADE_CMF_6");
                cdvGradeCmf7.Text = out_node.GetString("BIN_GRADE_CMF_7");
                cdvGradeCmf8.Text = out_node.GetString("BIN_GRADE_CMF_8");
                cdvGradeCmf9.Text = out_node.GetString("BIN_GRADE_CMF_9");
                cdvGradeCmf10.Text = out_node.GetString("BIN_GRADE_CMF_10");
                cdvGradeCmf11.Text = out_node.GetString("BIN_GRADE_CMF_11");
                cdvGradeCmf12.Text = out_node.GetString("BIN_GRADE_CMF_12");
                cdvGradeCmf13.Text = out_node.GetString("BIN_GRADE_CMF_13");
                cdvGradeCmf14.Text = out_node.GetString("BIN_GRADE_CMF_14");
                cdvGradeCmf15.Text = out_node.GetString("BIN_GRADE_CMF_15");
                cdvGradeCmf16.Text = out_node.GetString("BIN_GRADE_CMF_16");
                cdvGradeCmf17.Text = out_node.GetString("BIN_GRADE_CMF_17");
                cdvGradeCmf18.Text = out_node.GetString("BIN_GRADE_CMF_18");
                cdvGradeCmf19.Text = out_node.GetString("BIN_GRADE_CMF_19");
                cdvGradeCmf20.Text = out_node.GetString("BIN_GRADE_CMF_20");

                txtGradeCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtGradeCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtGradeUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                txtGradeUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                ChangeSyntaxColor(txtFormula);
                ChangeSyntaxColor(txtTGFormula);

                MakeRelationCondition('G');
                MakeRelationCondition('T');

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool SetTranControl(string sTranCode)
        {
            try
            {
                cdvRefOper.Visible = false;
                cdvRefOper.Text = "";
                cdvRefOper.Enabled = false;

                lblReasonCode.Visible = false;
                cdvReasonCode.Visible = false;
                cdvReasonCode.Text = "";
                cdvReasonCode.Enabled = false;

                lblHoldPass.Visible = false;
                txtHoldPass.Visible = false;
                txtHoldPass.Text = "";
                txtHoldPass.Enabled = false;

                cdvToMaterial.Visible = false;
                cdvToMaterial.Text = "";
                cdvToMaterial.Enabled = false;

                cdvToFlow.Visible = false;
                cdvToFlow.Text = "";
                cdvToFlow.Enabled = false;

                cdvToOper.Visible = false;
                cdvToOper.Text = "";
                cdvToOper.Enabled = false;

                cdvRetFlow.Visible = false;
                cdvRetFlow.Text = "";
                cdvRetFlow.Enabled = false;

                cdvRetOper.Visible = false;
                cdvRetOper.Text = "";
                cdvRetOper.Enabled = false;

                cdvToStopOper.Visible = false;
                cdvToStopOper.Text = "";
                cdvToStopOper.Enabled = false;

                lblReturnOption.Visible = false;
                cboReturnOption.Visible = false;
                cboReturnOption.Text = "";
                cboReturnOption.Enabled = false;

                lblTranCmt.Visible = false;
                txtTranCmt.Visible = false;

                switch (sTranCode)
                {
                    case MPGC.MP_TRAN_CODE_HOLD:

                        lblReasonCode.Text = "Hold Code";
                        lblReasonCode.Visible = true;
                        cdvReasonCode.Visible = true;
                        cdvReasonCode.Text = "";
                        cdvReasonCode.Enabled = true;

                        lblHoldPass.Visible = true;
                        txtHoldPass.Visible = true;
                        txtHoldPass.Text = "";
                        txtHoldPass.Enabled = true;

                        lblTranCmt.Visible = true;
                        txtTranCmt.Visible = true;
                        break;

                    case MPGC.MP_TRAN_CODE_REWORK:

                        lblReasonCode.Text = "Rework Code";
                        lblReasonCode.Visible = true;
                        cdvReasonCode.Visible = true;
                        cdvReasonCode.Text = "";
                        cdvReasonCode.Enabled = true;

                        cdvRefOper.Visible = true;
                        cdvRefOper.Text = "";
                        cdvRefOper.Enabled = true;

                        cdvToFlow.Visible = true;
                        cdvToFlow.Text = "";
                        cdvToFlow.Enabled = true;

                        cdvToOper.Visible = true;
                        cdvToOper.Text = "";
                        cdvToOper.Enabled = true;

                        cdvToStopOper.Visible = true;
                        cdvToStopOper.Text = "";
                        cdvToStopOper.Enabled = true;

                        cdvRetFlow.Visible = true;
                        cdvRetFlow.Text = "";
                        cdvRetFlow.Enabled = true;

                        cdvRetOper.Visible = true;
                        cdvRetOper.Text = "";
                        cdvRetOper.Enabled = true;

                        lblReturnOption.Visible = true;
                        cboReturnOption.Visible = true;
                        cboReturnOption.Text = "";
                        cboReturnOption.Enabled = true;

                        lblTranCmt.Visible = true;
                        txtTranCmt.Visible = true;

                        break;

                    case MPGC.MP_TRAN_CODE_END:
                    case MPGC.MP_TRAN_CODE_MOVE:
                    case MPGC.MP_TRAN_CODE_SKIP:

                        cdvToFlow.Visible = true;
                        cdvToFlow.Text = "";
                        cdvToFlow.Enabled = true;

                        cdvToOper.Visible = true;
                        cdvToOper.Text = "";
                        cdvToOper.Enabled = true;

                        lblTranCmt.Visible = true;
                        txtTranCmt.Visible = true;

                        break;

                    case MPGC.MP_TRAN_CODE_LOSS:

                        lblReasonCode.Text = "Loss Code";
                        lblReasonCode.Visible = true;
                        cdvReasonCode.Visible = true;
                        cdvReasonCode.Text = "";
                        cdvReasonCode.Enabled = true;

                        cdvRefOper.Visible = true;
                        cdvRefOper.Text = "";
                        cdvRefOper.Enabled = true;

                        lblTranCmt.Visible = true;
                        txtTranCmt.Visible = true;

                        break;

                    case MPGC.MP_TRAN_CODE_ADAPT:

                        cdvToMaterial.Visible = true;
                        cdvToMaterial.Text = "";
                        cdvToMaterial.Enabled = true;

                        lblTranCmt.Visible = true;
                        txtTranCmt.Visible = true;

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

        private bool SetTGTranControl(string sTranCode)
        {
            try
            {
                cdvTGRefOper.Visible = false;
                cdvTGRefOper.Text = "";
                cdvTGRefOper.Enabled = false;

                lblTGReasonCode.Visible = false;
                cdvTGReasonCode.Visible = false;
                cdvTGReasonCode.Text = "";
                cdvTGReasonCode.Enabled = false;

                lblTGHoldPass.Visible = false;
                txtTGHoldPass.Visible = false;
                txtTGHoldPass.Text = "";
                txtTGHoldPass.Enabled = false;

                cdvTGToMaterial.Visible = false;
                cdvTGToMaterial.Text = "";
                cdvTGToMaterial.Enabled = false;

                cdvTGToFlow.Visible = false;
                cdvTGToFlow.Text = "";
                cdvTGToFlow.Enabled = false;

                cdvTGToOper.Visible = false;
                cdvTGToOper.Text = "";
                cdvTGToOper.Enabled = false;

                cdvTGRetFlow.Visible = false;
                cdvTGRetFlow.Text = "";
                cdvTGRetFlow.Enabled = false;

                cdvTGRetOper.Visible = false;
                cdvTGRetOper.Text = "";
                cdvTGRetOper.Enabled = false;

                cdvTGToStopOper.Visible = false;
                cdvTGToStopOper.Text = "";
                cdvTGToStopOper.Enabled = false;

                lblTGRetOption.Visible = false;
                cboTGRetOption.Visible = false;
                cboTGRetOption.Text = "";
                cboTGRetOption.Enabled = false;

                lblTGTranCmt.Visible = false;
                txtTGTranCmt.Visible = false;

                switch (sTranCode)
                {
                    case MPGC.MP_TRAN_CODE_HOLD:

                        lblTGReasonCode.Text = "Hold Code";
                        lblTGReasonCode.Visible = true;
                        cdvTGReasonCode.Visible = true;
                        cdvTGReasonCode.Text = "";
                        cdvTGReasonCode.Enabled = true;

                        lblTGHoldPass.Visible = true;
                        txtTGHoldPass.Visible = true;
                        txtTGHoldPass.Text = "";
                        txtTGHoldPass.Enabled = true;

                        lblTGTranCmt.Visible = true;
                        txtTGTranCmt.Visible = true;
                        break;

                    case MPGC.MP_TRAN_CODE_REWORK:

                        lblTGReasonCode.Text = "Rework Code";
                        lblTGReasonCode.Visible = true;
                        cdvTGReasonCode.Visible = true;
                        cdvTGReasonCode.Text = "";
                        cdvTGReasonCode.Enabled = true;

                        cdvTGRefOper.Visible = true;
                        cdvTGRefOper.Text = "";
                        cdvTGRefOper.Enabled = true;

                        cdvTGToFlow.Visible = true;
                        cdvTGToFlow.Text = "";
                        cdvTGToFlow.Enabled = true;

                        cdvTGToOper.Visible = true;
                        cdvTGToOper.Text = "";
                        cdvTGToOper.Enabled = true;

                        cdvTGToStopOper.Visible = true;
                        cdvTGToStopOper.Text = "";
                        cdvTGToStopOper.Enabled = true;

                        cdvTGRetFlow.Visible = true;
                        cdvTGRetFlow.Text = "";
                        cdvTGRetFlow.Enabled = true;

                        cdvTGRetOper.Visible = true;
                        cdvTGRetOper.Text = "";
                        cdvTGRetOper.Enabled = true;

                        lblTGRetOption.Visible = true;
                        cboTGRetOption.Visible = true;
                        cboTGRetOption.Text = "";
                        cboTGRetOption.Enabled = true;

                        lblTGTranCmt.Visible = true;
                        txtTGTranCmt.Visible = true;

                        break;

                    case MPGC.MP_TRAN_CODE_END:
                    case MPGC.MP_TRAN_CODE_MOVE:
                    case MPGC.MP_TRAN_CODE_SKIP:

                        cdvTGToFlow.Visible = true;
                        cdvTGToFlow.Text = "";
                        cdvTGToFlow.Enabled = true;

                        cdvTGToOper.Visible = true;
                        cdvTGToOper.Text = "";
                        cdvTGToOper.Enabled = true;

                        lblTGTranCmt.Visible = true;
                        txtTGTranCmt.Visible = true;

                        break;

                    case MPGC.MP_TRAN_CODE_LOSS:

                        lblTGReasonCode.Text = "Loss Code";
                        lblTGReasonCode.Visible = true;
                        cdvTGReasonCode.Visible = true;
                        cdvTGReasonCode.Text = "";
                        cdvTGReasonCode.Enabled = true;

                        cdvTGRefOper.Visible = true;
                        cdvTGRefOper.Text = "";
                        cdvTGRefOper.Enabled = true;

                        lblTGTranCmt.Visible = true;
                        txtTGTranCmt.Visible = true;

                        break;

                    case MPGC.MP_TRAN_CODE_ADAPT:

                        cdvTGToMaterial.Visible = true;
                        cdvTGToMaterial.Text = "";
                        cdvTGToMaterial.Enabled = true;

                        lblTGTranCmt.Visible = true;
                        txtTGTranCmt.Visible = true;

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

        private string GetOperationCodeTable(string s_tran_code, string s_oper)
        {
            TRSNode in_node = new TRSNode("View_Operation_In");
            TRSNode out_node = new TRSNode("View_Operation_Out");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", s_oper);

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return "";
            }

            if (s_tran_code == MPGC.MP_TRAN_CODE_REWORK)
                return out_node.GetString("REWORK_TBL");
            else if (s_tran_code == MPGC.MP_TRAN_CODE_LOSS)
                return out_node.GetString("LOSS_TBL");

            return "";
        }

        private bool GetLotCodeList(string s_tran_code, Miracom.UI.Controls.MCCodeView.MCCodeView cdvRSCode, Miracom.MESCore.Controls.udcOperation cdvReferOper)
        {
            string s_code_table_name;

            try
            {
                s_code_table_name = MPCF.Trim(s_tran_code) + "_CODE";

                cdvRSCode.Init();
                MPCF.InitListView(cdvRSCode.GetListView);
                cdvRSCode.Columns.Add("Lot Code", 50, HorizontalAlignment.Left);
                cdvRSCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvRSCode.SelectedSubItemIndex = 0;

                if (MPCF.Trim(s_tran_code) == MPGC.MP_TRAN_CODE_REWORK || MPCF.Trim(s_tran_code) == MPGC.MP_TRAN_CODE_LOSS)
                {
                    if (MPCF.CheckValue(cdvReferOper, 1) == false) return false;
                    s_code_table_name = GetOperationCodeTable(s_tran_code, cdvReferOper.Text);
                }

                if (s_code_table_name != "")
                {
                    if (BASLIST.ViewGCMDataList(cdvRSCode.GetListView, '1', s_code_table_name) == false)
                    {
                        return false;
                    }

                    cdvRSCode.InsertEmptyRow(0, 1);
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool IsSQLSyntax(string sQuery)
        {
            for (int i = 0; i < MPGV.SqlSyntax.Length; i++)
            {
                if (MPCF.Trim(sQuery).StartsWith(FormulaSyntax[i]) == true)
                {
                    return true;
                }
            }
            return false;
        }

        private void ChangeSyntaxColor(RichTextBox txtSql)
        {
            int i_start;
            int i_length = 0;
            i_start = 0;

            if (MPCF.Trim(txtSql.Text) == "")
            {
                return;
            }

            txtSql.SelectionStart = 0;
            txtSql.SelectionLength = txtSql.Text.Length;
            txtSql.SelectionColor = System.Drawing.SystemColors.ControlText;

            while (i_length < txtSql.Text.Length)
            {
                if (txtSql.Text[i_length] == ' ' || txtSql.Text[i_length] == '\r' || txtSql.Text[i_length] == '\n' || i_length + 1 == txtSql.Text.Length)
                {
                    if (i_length + 1 == txtSql.Text.Length)
                    {
                        i_length++;
                    }

                    if (IsSQLSyntax(MPCF.ToUpper(txtSql.Text.Substring(i_start, i_length - i_start))) == true ||
                        txtSql.Text.Substring(i_start, i_length - i_start).IndexOf("$") >= 0)
                    {
                        txtSql.SelectionStart = i_start;
                        txtSql.SelectionLength = i_length - i_start;
                        txtSql.SelectionColor = System.Drawing.Color.Blue;
                        txtSql.SelectionStart = i_length;
                        txtSql.SelectionLength = 0;
                        txtSql.SelectionColor = System.Drawing.SystemColors.ControlText;
                    }
                    i_start = i_length;
                }

                i_length++;
            }

            txtSql.SelectionStart = i_length;
            txtSql.SelectionLength = 0;
            txtSql.SelectionColor = System.Drawing.SystemColors.ControlText;
        }

        private void MakeRelationCondition(char c_type)
        {
            int i;
            string s_relation;

            s_relation = "";

            if (c_type == 'G')
            {
                for (i = 0; i < spdCond.ActiveSheet.RowCount; i++)
                {
                    s_relation += MPCF.Trim(spdCond.ActiveSheet.Cells[i, 1].Value) + " " + ((int)(i + 1)).ToString() + " " + MPCF.Trim(spdCond.ActiveSheet.Cells[i, 5].Value);
                    if (i < spdCond.ActiveSheet.RowCount - 1)
                    {
                        s_relation += " " + MPCF.Trim(spdCond.ActiveSheet.Cells[i + 1, 0].Value) + " ";
                    }
                }

                txtRelation.Text = s_relation;
            }
            else if (c_type == 'T')
            {
                for (i = 0; i < spdTGCond.ActiveSheet.RowCount; i++)
                {
                    s_relation += MPCF.Trim(spdTGCond.ActiveSheet.Cells[i, 1].Value) + " " + ((int)(i + 1)).ToString() + " " + MPCF.Trim(spdTGCond.ActiveSheet.Cells[i, 5].Value);
                    if (i < spdTGCond.ActiveSheet.RowCount - 1)
                    {
                        s_relation += " " + MPCF.Trim(spdTGCond.ActiveSheet.Cells[i + 1, 0].Value) + " ";
                    }
                }

                txtTGRelation.Text = s_relation;
            }
        }

        private void spdCondCellClick(char c_type, int i_row)
        {
            if (c_type == 'G')
            {
                pnlCondList.Tag = i_row;
                txtFormula.Text = MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 2].Value);
                cdvOperator.Text = MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 3].Value);
                txtValue.Text = MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 4].Value);

                ChangeSyntaxColor(txtFormula);
            }
            else if (c_type == 'T')
            {
                pnlTGCondList.Tag = i_row;
                txtTGFormula.Text = MPCF.Trim(spdTGCond.ActiveSheet.Cells[i_row, 2].Value);
                cdvTGOperator.Text = MPCF.Trim(spdTGCond.ActiveSheet.Cells[i_row, 3].Value);
                txtTGValue.Text = MPCF.Trim(spdTGCond.ActiveSheet.Cells[i_row, 4].Value);

                ChangeSyntaxColor(txtTGFormula);
            }
        }


        #endregion

        private void frmWIPSetupBinGrade_Activated(object sender, EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    SetTranControl("");
                    SetCustomizedField();

                    lisBinList.Dock = DockStyle.Fill;
                    cboPeriodicPeriod.SelectedIndex = 0;

                    tabBIN.SelectedIndex = 0;
                    tabBIN_SelectedIndexChanged(null, null);

                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                MPCF.FindListItemPartial(lisBinDef, txtFind.Text, 0, true, false);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                MPCF.FindListItemNextPartial(lisBinDef, txtFind.Text, true, false);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                lblDataCount.Text = "";
                /* 2013.06.12. Aiden. Filter 추가 */
                if (WIPLIST.ViewBinDefList(lisBinDef, false, txtFilter.Text) == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisBinDef.Items.Count);
                    if (lisBinDef.Items.Count > 0)
                    {
                        MPCF.FindListItem(lisBinDef, txtBinID.Text, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (lisBinDef.Items.Count > 0)
                {
                    MPCF.ExportToExcel(lisBinDef, this.Text, "");
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void lisBinDef_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lisBinDef.SelectedItems.Count < 1) return;

            cdvBinVersion.Text = "";
            cdvBinUnit.Text = "";

            ClearData(1);
            MPCF.FieldClear(tbpBinVerAppRel);

            txtBinID.Text = MPCF.Trim(lisBinDef.SelectedItems[0].SubItems[0].Text);
            txtBinDesc.Text = MPCF.Trim(lisBinDef.SelectedItems[0].SubItems[1].Text);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            cdvBinUnit_SelectedItemChanged(null, null);
        }

        private void cdvBinVersion_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(txtBinID, 1) == false) return;

            cdvBinVersion.Init();
            MPCF.InitListView(cdvBinVersion.GetListView);
            cdvBinVersion.Columns.Add("BIN Version", 50, HorizontalAlignment.Left);
            cdvBinVersion.SelectedSubItemIndex = 0;

            WIPLIST.ViewBinVersionList(cdvBinVersion.GetListView, txtBinID.Text);
        }

        private void cdvBinVersion_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (txtBinID.Text != "" && cdvBinVersion.Text != "")
            {
                MPCF.FieldClear(tbpBinVerAppRel);
                if (ViewBinVersion() == false) return;
            }
            cdvBinUnit_SelectedItemChanged(null, null);
        }

        private void cdvBinUnit_ButtonPress(object sender, EventArgs e)
        {
            cdvBinUnit.Init();
            MPCF.InitListView(cdvBinUnit.GetListView);
            cdvBinUnit.Columns.Add("Unit", 50, HorizontalAlignment.Left);
            cdvBinUnit.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvBinUnit.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvBinUnit.GetListView, '1', MPGC.MP_WIP_UNIT_TABLE);
        }

        private void cdvBinUnit_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (txtBinID.Text != "" && cdvBinVersion.Text != "" && cdvBinUnit.Text != "")
            {
                ClearData(1);
                if (ViewBinUnit() == false) return;
            }
        }

        private void cdvCmf_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);
        }

        private void cdvCmf_ButtonPress(object sender, System.EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }

        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (tabBIN.SelectedTab == tbpBinGrade)
                {
                    if (CheckCondition("UPDATE_BIN_GRADE") == false) return;
                    if (UpdateBinGrade(MPGC.MP_STEP_CREATE) == false) return;

                    ViewBinUnit();
                    MPCF.FindListItem(lisBinList, cdvBinSeq.Text, false);
                }
                else
                {
                    if (CheckCondition("UPDATE_BIN_UNIT") == false) return;
                    if (UpdateBinUnit(MPGC.MP_STEP_CREATE) == false) return;
                }

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
                if (tabBIN.SelectedTab == tbpBinGrade)
                {
                    if (CheckCondition("UPDATE_BIN_GRADE") == false) return;
                    if (UpdateBinGrade(MPGC.MP_STEP_UPDATE) == false) return;
                }
                else
                {
                    if (CheckCondition("UPDATE_BIN_UNIT") == false) return;
                    if (UpdateBinUnit(MPGC.MP_STEP_UPDATE) == false) return;
                }

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
                if (tabBIN.SelectedTab == tbpBinGrade)
                {
                    if (CheckCondition("DELETE_BIN_GRADE") == false) return;
                    if (UpdateBinGrade(MPGC.MP_STEP_DELETE) == false) return;

                    ClearData(2);
                    ViewBinUnit();
                }
                else
                {
                    if (CheckCondition("DELETE_BIN_UNIT") == false) return;
                    if (UpdateBinUnit(MPGC.MP_STEP_DELETE) == false) return;

                    ClearData(1);
                    cdvBinUnit.Text = "";
                }

                MPCF.ShowMsgBox(MPCF.GetMessage(52));
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        #region " Unit General "

        private void tabBIN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (b_allow_modify == true)
            {
                if (tabBIN.SelectedTab == tbpBinVerAppRel)
                {
                    MPCR.ChangeControlEnabled(this, btnCreate, false);
                    MPCR.ChangeControlEnabled(this, btnUpdate, false);
                    MPCR.ChangeControlEnabled(this, btnDelete, false);
                }
                else
                {
                    MPCR.ChangeControlEnabled(this, btnCreate, true);
                    MPCR.ChangeControlEnabled(this, btnUpdate, true);
                    MPCR.ChangeControlEnabled(this, btnDelete, true);
                }
            }
        }

        private void cdvTotalSplit_ButtonPress(object sender, EventArgs e)
        {
            cdvTotalSplit.Init();
            MPCF.InitListView(cdvTotalSplit.GetListView);
            cdvTotalSplit.Columns.Add("YesNo", 50, HorizontalAlignment.Left);
            cdvTotalSplit.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvTotalSplit.GetListView, '1', MPGC.MP_WIP_BIN_YESNO);
        }

        private void cdvCalcType_ButtonPress(object sender, EventArgs e)
        {
            cdvCalcType.Init();
            MPCF.InitListView(cdvCalcType.GetListView);
            cdvCalcType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvCalcType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCalcType.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvCalcType.GetListView, '1', MPGC.MP_WIP_BIN_CALC_TYPE);
        }

        private void cdvYieldBaseOper_ButtonPress(object sender, EventArgs e)
        {
            cdvYieldBaseOper.Init();
            MPCF.InitListView(cdvYieldBaseOper.GetListView);
            cdvYieldBaseOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
            cdvYieldBaseOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvYieldBaseOper.SelectedSubItemIndex = 0;

            WIPLIST.ViewOperationList(cdvYieldBaseOper.GetListView, '1');
        }

        private void cdvYieldBase_ButtonPress(object sender, EventArgs e)
        {
            cdvYieldBase.Init();
            MPCF.InitListView(cdvYieldBase.GetListView);
            cdvYieldBase.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvYieldBase.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvYieldBase.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvYieldBase.GetListView, '1', MPGC.MP_WIP_BIN_YIELD_BASE);
        }

        private void cdvYieldBase_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (cdvYieldBase.Text == "OPRIN")
            {
                cdvYieldBaseOper.Enabled = true;
            }
            else
            {
                cdvYieldBaseOper.Text = "";
                cdvYieldBaseOper.Enabled = false;
            }
        }

        private void cdvAlarmID_ButtonPress(object sender, EventArgs e)
        {
            cdvAlarmID.Init();
            MPCF.InitListView(cdvAlarmID.GetListView);
            cdvAlarmID.Columns.Add("Alarm ID", 50, HorizontalAlignment.Left);
            cdvAlarmID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvAlarmID.SelectedSubItemIndex = 0;

            ALMLIST.ViewAlarmMsgList(cdvAlarmID.GetListView, '1', MPGC.MP_ALM_NORMAL);
        }

        private void cdvSpecCharID_ButtonPress(object sender, EventArgs e)
        {
            cdvSpecCharID.Init();
            cdvSpecCharID.Columns.Add("Character", 50, HorizontalAlignment.Left);
            cdvSpecCharID.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvSpecCharID.SelectedSubItemIndex = 0;
            if (EDCLIST.ViewEDCCharacterList(cdvSpecCharID.GetListView, '1', 'S') == false)
            {
                return;
            }
        }

        private void chkUseSpecYield_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseSpecYield.Checked == true)
            {
                cdvSpecCharID.Enabled = true;
                txtUpYield.Text = "";
                txtUpYield.Enabled = false;
                txtLoYield.Text = "";
                txtLoYield.Enabled = false;
            }
            else
            {
                cdvSpecCharID.Text = "";
                cdvSpecCharID.Enabled = false;
                txtUpYield.Enabled = true;
                txtLoYield.Enabled = true;
            }
        }

        #endregion

        #region " BIN Grade General "

        private void lisBinList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisBinList.SelectedItems.Count > 0)
            {
                ClearData(3);
                ViewBinGrade(MPCF.ToInt(lisBinList.SelectedItems[0].Text));
            }
        }

        private void cdvBinSeq_ButtonPress(object sender, EventArgs e)
        {
            cdvBinSeq.Init();
            MPCF.InitListView(cdvBinSeq.GetListView);
            cdvBinSeq.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvBinSeq.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvBinSeq.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvBinSeq.GetListView, '1', MPGC.MP_WIP_BIN_SEQ);
        }

        private void cdvBinSeq_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvBinSeq.Text != "")
            {
                ClearData(3);
            }
        }

        private void cdvBinPrompt_ButtonPress(object sender, EventArgs e)
        {
            cdvBinPrompt.Init();
            MPCF.InitListView(cdvBinPrompt.GetListView);
            cdvBinPrompt.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvBinPrompt.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvBinPrompt.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvBinPrompt.GetListView, '1', MPGC.MP_WIP_BIN_PROMPT);
        }

        private void cdvBinType_ButtonPress(object sender, EventArgs e)
        {
            cdvBinType.Init();
            MPCF.InitListView(cdvBinType.GetListView);
            cdvBinType.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvBinType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvBinType.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvBinType.GetListView, '1', MPGC.MP_WIP_BIN_TYPE);
        }

        private void cdvBinType_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (cdvBinType.Text == "F")
            {
                chkUseBinPrompt.Enabled = true;
                chkUseBinPrompt.Checked = true;

                chkKeepLotQty.Enabled = true;
            }
            else
            {
                chkUseBinPrompt.Checked = false;
                chkUseBinPrompt.Enabled = false;
                chkKeepLotQty.Checked = false;
                chkKeepLotQty.Enabled = false;

                cdvFailReasonCode.Text = "";
                cdvFailReasonCode.Enabled = false;
                cdvReasonCodeRefOper.Text = "";
                cdvReasonCodeRefOper.Visible = false;
            }
        }

        private void cdvKeepLot_ButtonPress(object sender, EventArgs e)
        {
            cdvKeepLot.Init();
            MPCF.InitListView(cdvKeepLot.GetListView);
            cdvKeepLot.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvKeepLot.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvKeepLot.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvKeepLot.GetListView, '1', MPGC.MP_WIP_BIN_YESNO);
        }

        private void cdvKeepLot_TextBoxTextChanged(object sender, EventArgs e)
        {
            cdvSplitLotIDRule.Text = "";
            cdvSplitLotIDRule.Enabled = cdvKeepLot.Text == "Y" ? false : true;
        }

        private void cdvSplitBy_ButtonPress(object sender, EventArgs e)
        {
            cdvSplitBy.Init();
            MPCF.InitListView(cdvSplitBy.GetListView);
            cdvSplitBy.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvSplitBy.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvSplitBy.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvSplitBy.GetListView, '1', MPGC.MP_WIP_BIN_SEQ);
        }

        private void cdvSplitLotIDRule_ButtonPress(object sender, EventArgs e)
        {
            cdvSplitLotIDRule.Init();
            MPCF.InitListView(cdvSplitLotIDRule.GetListView);
            cdvSplitLotIDRule.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvSplitLotIDRule.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvSplitLotIDRule.SelectedSubItemIndex = 0;

            WIPLIST.ViewRuleList(cdvSplitLotIDRule.GetListView, 'L', false, "");
        }

        private void cdvChgMaterial_MaterialTextChanged(object sender, EventArgs e)
        {
            cdvChgFlow.Text = "";
        }

        private void cdvChgFlow_FlowButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvChgMaterial.Text) == "")
            {
                cdvChgFlow.ListCond_Step = '1';
                cdvChgFlow.ListCond_MatID = "";
                cdvChgFlow.ListCond_MatVersion = 0;
            }
            else
            {
                cdvChgFlow.ListCond_Step = '2';
                cdvChgFlow.ListCond_MatID = cdvChgMaterial.Text;
                cdvChgFlow.ListCond_MatVersion = cdvChgMaterial.Version;
            }
        }

        private void cdvMoveToOper_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvChgFlow.Text) == "")
            {
                cdvMoveToOper.ListCond_Step = '1';
                cdvMoveToOper.ListCond_Flow = "";
            }
            else
            {
                cdvMoveToOper.ListCond_Step = '2';
                cdvMoveToOper.ListCond_Flow = cdvChgFlow.Text;
            }
        }

        private void cdvChgCreateCode_ButtonPress(object sender, EventArgs e)
        {
            cdvChgCreateCode.Init();
            MPCF.InitListView(cdvChgCreateCode.GetListView);
            cdvChgCreateCode.Columns.Add("Create Code", 50, HorizontalAlignment.Left);
            cdvChgCreateCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvChgCreateCode.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvChgCreateCode.GetListView, '1', MPGC.MP_WIP_CREATE_CODE);
        }

        private void cdvChgOwnerCode_ButtonPress(object sender, EventArgs e)
        {
            cdvChgOwnerCode.Init();
            MPCF.InitListView(cdvChgOwnerCode.GetListView);
            cdvChgOwnerCode.Columns.Add("Owner Code", 50, HorizontalAlignment.Left);
            cdvChgOwnerCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvChgOwnerCode.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvChgOwnerCode.GetListView, '1', MPGC.MP_WIP_OWNER_CODE);
        }

        private void cdvChgLotType_ButtonPress(object sender, EventArgs e)
        {
            cdvChgLotType.Init();
            MPCF.InitListView(cdvChgLotType.GetListView);
            cdvChgLotType.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvChgLotType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvChgLotType.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvChgLotType.GetListView, '1', MPGC.MP_WIP_LOT_TYPE);
        }

        private void cdvChgCrrGrp_ButtonPress(object sender, EventArgs e)
        {
            cdvChgCrrGrp.Init();
            MPCF.InitListView(cdvChgCrrGrp.GetListView);
            cdvChgCrrGrp.Columns.Add("Carrier Group", 50, HorizontalAlignment.Left);
            cdvChgCrrGrp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvChgCrrGrp.SelectedSubItemIndex = 0;

            RASLIST.ViewCarrierGroupList(cdvChgCrrGrp.GetListView);
        }

        private void chkUseBinPrompt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseBinPrompt.Checked == true)
            {
                cdvFailReasonCode.Text = "";
                cdvFailReasonCode.Enabled = false;
                cdvReasonCodeRefOper.Text = "";
                cdvReasonCodeRefOper.Visible = false;
            }
            else
            {
                cdvFailReasonCode.Enabled = true;
                cdvReasonCodeRefOper.Visible = true;
            }
        }

        private void cdvFailReasonCode_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvReasonCodeRefOper, 1) == false) return;

            cdvFailReasonCode.Init();
            MPCF.InitListView(cdvFailReasonCode.GetListView);
            cdvFailReasonCode.Columns.Add("Reason Code", 50, HorizontalAlignment.Left);
            cdvFailReasonCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvFailReasonCode.SelectedSubItemIndex = 0;

            string s_code_table_name = GetOperationCodeTable(MPGC.MP_TRAN_CODE_LOSS, cdvReasonCodeRefOper.Text);

            if (s_code_table_name != "")
            {
                if (BASLIST.ViewGCMDataList(cdvFailReasonCode.GetListView, '1', s_code_table_name) == false)
                {
                    return;
                }
            }
        }

        #endregion

        #region " Grade Control "

        private void tabBinGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabBinGrade.SelectedTab != tbpBinGradeControl && tabBinGrade.SelectedTab != tbpTotalGradeControl)
            {
                btnHelp.Text = MPCF.FindLanguage("Help", CAPTION_TYPE.BUTTON);
                btnTGHelp.Text = btnHelp.Text;
                txtHelp.SendToBack();
            }
        }

        private void cdvTranCode_ButtonPress(object sender, EventArgs e)
        {
            cdvTranCode.Init();
            MPCF.InitListView(cdvTranCode.GetListView);
            cdvTranCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvTranCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTranCode.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvTranCode.GetListView, '1', MPGC.MP_WIP_BIN_TRANS_CODE);
        }

        private void cdvTranCode_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvTranCode.Text) != "")
            {
                SetTranControl(cdvTranCode.Text);
            }
        }

        private void cdvOperator_ButtonPress(object sender, EventArgs e)
        {
            cdvOperator.Init();
            MPCF.InitListView(cdvOperator.GetListView);
            cdvOperator.Columns.Add("Operand", 50, HorizontalAlignment.Left);
            cdvOperator.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOperator.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvOperator.GetListView, '1', MPGC.MP_WIP_BIN_OPERATOR);
        }

        private void cdvRefOper_TextBoxTextChanged(object sender, EventArgs e)
        {
            cdvReasonCode.Text = "";
        }

        private void cdvReasonCode_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvTranCode, 1) == false)
            {
                cdvReasonCode.IsPopup = false;
                return;
            }
            if (GetLotCodeList(cdvTranCode.Text, cdvReasonCode, cdvRefOper) == false)
            {
                cdvReasonCode.IsPopup = false;
                return;
            }
        }

        private void cdvToFlow_FlowTextChanged(object sender, EventArgs e)
        {
            cdvToOper.Text = "";
        }

        private void cdvToOper_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvToFlow.Text) == "")
            {
                cdvToOper.ListCond_Step = '1';
                cdvToOper.ListCond_Flow = "";
            }
            else
            {
                cdvToOper.ListCond_Step = '2';
                cdvToOper.ListCond_Flow = cdvToFlow.Text;
            }
        }

        private void cdvToStopOper_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvToFlow.Text) == "")
            {
                cdvToStopOper.ListCond_Step = '1';
                cdvToStopOper.ListCond_Flow = "";
            }
            else
            {
                cdvToStopOper.ListCond_Step = '2';
                cdvToStopOper.ListCond_Flow = cdvToFlow.Text;
            }
        }

        private void cdvRetFlow_FlowTextChanged(object sender, EventArgs e)
        {
            cdvRetOper.Text = "";
        }

        private void cdvRetOper_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvRetFlow.Text) == "")
            {
                cdvRetOper.ListCond_Step = '1';
                cdvRetOper.ListCond_Flow = "";
            }
            else
            {
                cdvRetOper.ListCond_Step = '2';
                cdvRetOper.ListCond_Flow = cdvRetFlow.Text;
            }
        }

        private void spdFunctions_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string sTemp = "";

            FarPoint.Win.Spread.CellType.ButtonCellType tempBtn;
            tempBtn = (FarPoint.Win.Spread.CellType.ButtonCellType)spdFunctions.Sheets[0].Cells[e.Row, e.Column].CellType;

            if (tempBtn.Text == "BIN X")
            {
                cdvSPDBinSeq.Init();
                cdvSPDBinSeq.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvSPDBinSeq.GetListView);
                cdvSPDBinSeq.Columns.Add("Bin Seq", 50, HorizontalAlignment.Left);
                cdvSPDBinSeq.Columns.Add("Desc", 50, HorizontalAlignment.Left);
                
                BASLIST.ViewGCMDataList(cdvSPDBinSeq.GetListView, '1', MPGC.MP_WIP_BIN_SEQ);
                if (cdvSPDBinSeq.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
            }
            else if (tempBtn.Text == "BOper In")
            {
                cdvSPDOper.Init();
                cdvSPDOper.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvSPDOper.GetListView);
                cdvSPDOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvSPDOper.Columns.Add("Desc", 50, HorizontalAlignment.Left);

                WIPLIST.ViewOperationList(cdvSPDOper.GetListView, '1');
                if (cdvSPDOper.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
            }
            else if (e.Row == 1 || e.Row == 2)
            {
                if (tempBtn.Text == "LOG" || tempBtn.Text == "MOD" || tempBtn.Text == "POWER" || tempBtn.Text == "ROUND" || tempBtn.Text == "TRUNC")
                {
                    sTemp = tempBtn.Text + "( value , value )";
                }
                else
                {
                    sTemp = tempBtn.Text + "( value )";
                }
            }
            else if (tempBtn.Text == "Clear")
            {
                txtFormula.Text = "";
            }
            else if (tempBtn.Text == "Total")
            {
                sTemp = "$_TOTAL";
            }
            else if (tempBtn.Text == "Oper In")
            {
                sTemp = "$_OPERIN";
            }
            else if (tempBtn.Text == "% by CBIN QTY")
            {
                sTemp = "( $_BIN_" + cdvBinSeq.Text + " / $_TOTAL ) * 100";
            }
            else if (tempBtn.Text == "% by Grouping")
            {
                sTemp = "( ($_BIN_X + $_BIN_Y + $_BIN_Z) / $_TOTAL ) * 100";
            }
            else if (tempBtn.Text == "CASE Sample")
            {
                sTemp = "CASE WHEN operand1 > value1 THEN value2\r\n     WHEN operand2 < value3 THEN value4\r\nEND";
            }
            else if (tempBtn.Text == "Current BIN QTY")
            {
                sTemp = "$_BIN_" + cdvBinSeq.Text;
            }
            else
            {
                sTemp = tempBtn.Text;
            }


            if (sTemp != "")
            {
                if (txtFormula.SelectedText == "")
                {
                    txtFormula.Text = MPCF.LTrim(txtFormula.Text + " " + sTemp);
                }
                else
                {
                    txtFormula.SelectedText = sTemp;
                }
            }

            ChangeSyntaxColor(txtFormula);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (btnHelp.Text == MPCF.FindLanguage("Help", CAPTION_TYPE.BUTTON))
            {
                txtHelp.BringToFront();
                btnHelp.Text = MPCF.FindLanguage("Hide", CAPTION_TYPE.BUTTON);
            }
            else if (btnHelp.Text == MPCF.FindLanguage("Hide", CAPTION_TYPE.BUTTON))
            {
                txtHelp.SendToBack();
                btnHelp.Text = MPCF.FindLanguage("Help", CAPTION_TYPE.BUTTON);
            }
        }

        private void cdvSPDBinSeq_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            string sTemp;
            sTemp = "$_BIN_" + e.SelectedItem.SubItems[0].Text;

            if (txtFormula.SelectedText == "")
            {
                txtFormula.Text = MPCF.LTrim(txtFormula.Text + " " + sTemp);
            }
            else
            {
                txtFormula.SelectedText = sTemp;
            }

            ChangeSyntaxColor(txtFormula);
        }

        private void cdvSPDOper_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            string sTemp;
            sTemp = "$_BOPER_" + e.SelectedItem.SubItems[0].Text + "_$";

            if (txtFormula.SelectedText == "")
            {
                txtFormula.Text = MPCF.LTrim(txtFormula.Text + " " + sTemp);
            }
            else
            {
                txtFormula.SelectedText = sTemp;
            }

            ChangeSyntaxColor(txtFormula);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int i;

            if (MPCF.Trim(txtFormula.Text) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                txtFormula.Focus();
                return;
            }

            if (MPCF.CheckValue(cdvOperator, 1) == false) return;
            if (MPCF.CheckValue(txtValue, 1) == false) return;

            for (i = 0; i < spdCond.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 2].Value) == txtFormula.Text &&
                    MPCF.Trim(spdCond.ActiveSheet.Cells[i, 3].Value) == cdvOperator.Text &&
                    MPCF.Trim(spdCond.ActiveSheet.Cells[i, 4].Value) == txtValue.Text)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(301));
                    return;
                }
            }

            pnlCondList.Tag = spdCond.ActiveSheet.RowCount;
            spdCond.ActiveSheet.RowCount++;

            btnModify.PerformClick();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            int i_row;

            if (MPCF.Trim(txtFormula.Text) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                txtFormula.Focus();
                return;
            }

            if (MPCF.CheckValue(cdvOperator, 1) == false) return;
            if (MPCF.CheckValue(txtValue, 1) == false) return;

            for (i_row = 0; i_row < spdCond.ActiveSheet.RowCount; i_row++)
            {
                if (MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 2].Value) == txtFormula.Text &&
                    MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 3].Value) == cdvOperator.Text &&
                    MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 4].Value) == txtValue.Text)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(301));
                    return;
                }
            }

            if (MPCF.Trim(pnlCondList.Tag) != "")
            {
                i_row = MPCF.ToInt(pnlCondList.Tag);
                spdCond.ActiveSheet.Cells[i_row, 2].Value = txtFormula.Text;
                spdCond.ActiveSheet.Cells[i_row, 3].Value = cdvOperator.Text;
                spdCond.ActiveSheet.Cells[i_row, 4].Value = txtValue.Text;

                //default as AND
                if (i_row > 0 && MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 0].Value) == "")
                {
                    spdCond.ActiveSheet.Cells[i_row, 0].Value = "AND";
                }

                MakeRelationCondition('G');
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int i_row;

            if (MPCF.Trim(pnlCondList.Tag) != "")
            {
                i_row = MPCF.ToInt(pnlCondList.Tag);

                spdCond.ActiveSheet.Rows[i_row].Remove();

                txtFormula.Text = "";
                cdvOperator.Text = "";
                txtValue.Text = "";

                MakeRelationCondition('T');

                if (i_row >= spdCond.ActiveSheet.RowCount)
                {
                    i_row--;
                }

                if (i_row < 0)
                {
                    pnlCondList.Tag = null;
                }
                else
                {
                    spdCondCellClick('G', i_row);
                }
            }
        }

        private void spdCond_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader == true) return;
            if (e.RowHeader == true) return;

            spdCondCellClick('G', e.Row);
        }

        private void spdCond_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Row == 0 && e.Column == 0)
            {
                spdCond.ActiveSheet.Cells[0, 0].Value = null;
            }

            MakeRelationCondition('G');
        }



        #endregion

        #region " Total Grade Control "

        private void cdvTGTranCode_ButtonPress(object sender, EventArgs e)
        {
            cdvTGTranCode.Init();
            MPCF.InitListView(cdvTGTranCode.GetListView);
            cdvTGTranCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvTGTranCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTGTranCode.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvTGTranCode.GetListView, '1', MPGC.MP_WIP_BIN_TRANS_CODE);
        }

        private void cdvTGTranCode_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvTGTranCode.Text) != "")
            {
                SetTGTranControl(cdvTGTranCode.Text);
            }
        }

        private void cdvTGOperator_ButtonPress(object sender, EventArgs e)
        {
            cdvTGOperator.Init();
            MPCF.InitListView(cdvTGOperator.GetListView);
            cdvTGOperator.Columns.Add("Operand", 50, HorizontalAlignment.Left);
            cdvTGOperator.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTGOperator.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvTGOperator.GetListView, '1', MPGC.MP_WIP_BIN_OPERATOR);
        }

        private void cdvTGRefOper_TextBoxTextChanged(object sender, EventArgs e)
        {
            cdvTGReasonCode.Text = "";
        }

        private void cdvTGReasonCode_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvTGTranCode, 1) == false)
            {
                cdvTGReasonCode.IsPopup = false;
                return;
            }
            if (GetLotCodeList(cdvTGTranCode.Text, cdvTGReasonCode, cdvTGRefOper) == false)
            {
                cdvTGReasonCode.IsPopup = false;
                return;
            }
        }

        private void cdvTGToFlow_FlowTextChanged(object sender, EventArgs e)
        {
            cdvTGToOper.Text = "";
        }

        private void cdvTGToOper_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvTGToFlow.Text) == "")
            {
                cdvTGToOper.ListCond_Step = '1';
                cdvTGToOper.ListCond_Flow = "";
            }
            else
            {
                cdvTGToOper.ListCond_Step = '2';
                cdvTGToOper.ListCond_Flow = cdvTGToFlow.Text;
            }
        }

        private void cdvTGToStopOper_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvTGToFlow.Text) == "")
            {
                cdvTGToStopOper.ListCond_Step = '1';
                cdvTGToStopOper.ListCond_Flow = "";
            }
            else
            {
                cdvTGToStopOper.ListCond_Step = '2';
                cdvTGToStopOper.ListCond_Flow = cdvTGToFlow.Text;
            }
        }

        private void cdvTGRetFlow_FlowTextChanged(object sender, EventArgs e)
        {
            cdvTGRetOper.Text = "";
        }

        private void cdvTGRetOper_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvTGRetFlow.Text) == "")
            {
                cdvTGRetOper.ListCond_Step = '1';
                cdvTGRetOper.ListCond_Flow = "";
            }
            else
            {
                cdvTGRetOper.ListCond_Step = '2';
                cdvTGRetOper.ListCond_Flow = cdvTGRetFlow.Text;
            }
        }

        private void spdTGFunctions_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string sTemp = "";

            FarPoint.Win.Spread.CellType.ButtonCellType tempBtn;
            tempBtn = (FarPoint.Win.Spread.CellType.ButtonCellType)spdTGFunctions.Sheets[0].Cells[e.Row, e.Column].CellType;

            if (tempBtn.Text == "BIN X")
            {
                cdvTGSPDBinSeq.Init();
                cdvTGSPDBinSeq.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvTGSPDBinSeq.GetListView);
                cdvTGSPDBinSeq.Columns.Add("Bin Seq", 50, HorizontalAlignment.Left);
                cdvTGSPDBinSeq.Columns.Add("Desc", 50, HorizontalAlignment.Left);

                BASLIST.ViewGCMDataList(cdvTGSPDBinSeq.GetListView, '1', MPGC.MP_WIP_BIN_SEQ);
                if (cdvTGSPDBinSeq.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
            }
            else if (tempBtn.Text == "BOper In")
            {
                cdvTGSPDOper.Init();
                cdvTGSPDOper.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvTGSPDOper.GetListView);
                cdvTGSPDOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvTGSPDOper.Columns.Add("Desc", 50, HorizontalAlignment.Left);

                WIPLIST.ViewOperationList(cdvTGSPDOper.GetListView, '1');
                if (cdvTGSPDOper.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
            }
            else if (e.Row == 1 || e.Row == 2)
            {
                if (tempBtn.Text == "LOG" || tempBtn.Text == "MOD" || tempBtn.Text == "POWER" || tempBtn.Text == "ROUND" || tempBtn.Text == "TRUNC")
                {
                    sTemp = tempBtn.Text + "( value , value )";
                }
                else
                {
                    sTemp = tempBtn.Text + "( value )";
                }
            }
            else if (tempBtn.Text == "Clear")
            {
                txtTGFormula.Text = "";
            }
            else if (tempBtn.Text == "Total")
            {
                sTemp = "$_TOTAL";
            }
            else if (tempBtn.Text == "Oper In")
            {
                sTemp = "$_OPERIN";
            }
            else if (tempBtn.Text == "% by CBIN QTY")
            {
                sTemp = "( $_BIN_" + cdvBinSeq.Text + " / $_TOTAL ) * 100";
            }
            else if (tempBtn.Text == "% by Grouping")
            {
                sTemp = "( ($_BIN_X + $_BIN_Y + $_BIN_Z) / $_TOTAL ) * 100";
            }
            else if (tempBtn.Text == "CASE Sample")
            {
                sTemp = "CASE WHEN operand1 > value1 THEN value2\r\n     WHEN operand2 < value3 THEN value4\r\nEND";
            }
            else if (tempBtn.Text == "Current BIN QTY")
            {
                sTemp = "$_BIN_" + cdvBinSeq.Text;
            }
            else
            {
                sTemp = tempBtn.Text;
            }


            if (sTemp != "")
            {
                if (txtTGFormula.SelectedText == "")
                {
                    txtTGFormula.Text = MPCF.LTrim(txtTGFormula.Text + " " + sTemp);
                }
                else
                {
                    txtTGFormula.SelectedText = sTemp;
                }
            }

            ChangeSyntaxColor(txtTGFormula);
        }

        private void btnTGHelp_Click(object sender, EventArgs e)
        {
            if (btnTGHelp.Text == MPCF.FindLanguage("Help", CAPTION_TYPE.BUTTON))
            {
                txtHelp.BringToFront();
                btnTGHelp.Text = MPCF.FindLanguage("Hide", CAPTION_TYPE.BUTTON);
            }
            else if (btnTGHelp.Text == MPCF.FindLanguage("Hide", CAPTION_TYPE.BUTTON))
            {
                txtHelp.SendToBack();
                btnTGHelp.Text = MPCF.FindLanguage("Help", CAPTION_TYPE.BUTTON);
            }
        }

        private void cdvTGSPDBinSeq_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            string sTemp;
            sTemp = "$_BIN_" + e.SelectedItem.SubItems[0].Text;

            if (txtTGFormula.SelectedText == "")
            {
                txtTGFormula.Text = MPCF.LTrim(txtTGFormula.Text + " " + sTemp);
            }
            else
            {
                txtTGFormula.SelectedText = sTemp;
            }

            ChangeSyntaxColor(txtTGFormula);
        }

        private void cdvTGSPDOper_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            string sTemp;
            sTemp = "$_BOPER_" + e.SelectedItem.SubItems[0].Text + "_$";

            if (txtTGFormula.SelectedText == "")
            {
                txtTGFormula.Text = MPCF.LTrim(txtTGFormula.Text + " " + sTemp);
            }
            else
            {
                txtTGFormula.SelectedText = sTemp;
            }

            ChangeSyntaxColor(txtTGFormula);
        }

        private void btnTGAdd_Click(object sender, EventArgs e)
        {
            int i;

            if (MPCF.Trim(txtTGFormula.Text) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                txtTGFormula.Focus();
                return;
            }

            if (MPCF.CheckValue(cdvTGOperator, 1) == false) return;
            if (MPCF.CheckValue(txtTGValue, 1) == false) return;

            for (i = 0; i < spdTGCond.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdTGCond.ActiveSheet.Cells[i, 2].Value) == txtTGFormula.Text &&
                    MPCF.Trim(spdTGCond.ActiveSheet.Cells[i, 3].Value) == cdvTGOperator.Text &&
                    MPCF.Trim(spdTGCond.ActiveSheet.Cells[i, 4].Value) == txtTGValue.Text)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(301));
                    return;
                }
            }

            pnlTGCondList.Tag = spdTGCond.ActiveSheet.RowCount;
            spdTGCond.ActiveSheet.RowCount++;

            btnTGModify.PerformClick();
        }

        private void btnTGModify_Click(object sender, EventArgs e)
        {
            int i_row;

            if (MPCF.Trim(txtTGFormula.Text) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                txtTGFormula.Focus();
                return;
            }

            if (MPCF.CheckValue(cdvTGOperator, 1) == false) return;
            if (MPCF.CheckValue(txtTGValue, 1) == false) return;

            for (i_row = 0; i_row < spdTGCond.ActiveSheet.RowCount; i_row++)
            {
                if (MPCF.Trim(spdTGCond.ActiveSheet.Cells[i_row, 2].Value) == txtTGFormula.Text &&
                    MPCF.Trim(spdTGCond.ActiveSheet.Cells[i_row, 3].Value) == cdvTGOperator.Text &&
                    MPCF.Trim(spdTGCond.ActiveSheet.Cells[i_row, 4].Value) == txtTGValue.Text)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(301));
                    return;
                }
            }

            if (MPCF.Trim(pnlTGCondList.Tag) != "")
            {
                i_row = MPCF.ToInt(pnlTGCondList.Tag);
                spdTGCond.ActiveSheet.Cells[i_row, 2].Value = txtTGFormula.Text;
                spdTGCond.ActiveSheet.Cells[i_row, 3].Value = cdvTGOperator.Text;
                spdTGCond.ActiveSheet.Cells[i_row, 4].Value = txtTGValue.Text;

                //default as AND
                if (i_row > 0 && MPCF.Trim(spdTGCond.ActiveSheet.Cells[i_row, 0].Value) == "")
                {
                    spdTGCond.ActiveSheet.Cells[i_row, 0].Value = "AND";
                }

                MakeRelationCondition('T');
            }
        }

        private void btnTGRemove_Click(object sender, EventArgs e)
        {
            int i_row;

            if (MPCF.Trim(pnlTGCondList.Tag) != "")
            {
                i_row = MPCF.ToInt(pnlTGCondList.Tag);

                spdTGCond.ActiveSheet.Rows[i_row].Remove();

                txtTGFormula.Text = "";
                cdvTGOperator.Text = "";
                txtTGValue.Text = "";

                MakeRelationCondition('T');

                if (i_row >= spdTGCond.ActiveSheet.RowCount)
                {
                    i_row--;
                }

                if (i_row < 0)
                {
                    pnlTGCondList.Tag = null;
                }
                else
                {
                    spdCondCellClick('T', i_row);
                }
            }
        }

        private void spdTGCond_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader == true) return;
            if (e.RowHeader == true) return;

            spdCondCellClick('T', e.Row);
        }

        private void spdTGCond_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Row == 0 && e.Column == 0)
            {
                spdTGCond.ActiveSheet.Cells[0, 0].Value = null;
            }

            MakeRelationCondition('T');
        }



        #endregion

        #region " BIN Grade Periodic Yield Control "

        private void cboPeriodicPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPeriodicPeriod.SelectedIndex == 0)
            {
                chkPeriodicUseSpec.Checked = false;
                chkPeriodicUseSpec.Enabled = false;

                txtPeriodicUpYield.Text = "";
                txtPeriodicUpYield.Enabled = false;
                txtPeriodicLoYield.Text = "";
                txtPeriodicLoYield.Enabled = false;

                cdvPeriodicAlarmID.Text = "";
                cdvPeriodicAlarmID.Enabled = false;
            }
            else
            {
                chkPeriodicUseSpec.Enabled = true;

                txtPeriodicUpYield.Enabled = true;
                txtPeriodicLoYield.Enabled = true;

                cdvPeriodicAlarmID.Enabled = true;
            }
        }

        private void chkPeriodicUseSpec_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPeriodicUseSpec.Checked == true)
            {
                cdvPeriodicSpecCharID.Enabled = true;
                txtPeriodicUpYield.Text = "";
                txtPeriodicUpYield.Enabled = false;
                txtPeriodicLoYield.Text = "";
                txtPeriodicLoYield.Enabled = false;
            }
            else
            {
                cdvPeriodicSpecCharID.Text = "";
                cdvPeriodicSpecCharID.Enabled = false;
                txtPeriodicUpYield.Enabled = true;
                txtPeriodicLoYield.Enabled = true;
            }
        }

        private void cdvPeriodicAlarmID_ButtonPress(object sender, EventArgs e)
        {
            cdvPeriodicAlarmID.Init();
            MPCF.InitListView(cdvPeriodicAlarmID.GetListView);
            cdvPeriodicAlarmID.Columns.Add("Alarm ID", 50, HorizontalAlignment.Left);
            cdvPeriodicAlarmID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvPeriodicAlarmID.SelectedSubItemIndex = 0;

            ALMLIST.ViewAlarmMsgList(cdvPeriodicAlarmID.GetListView, '1', MPGC.MP_ALM_NORMAL);
        }

        private void cdvPeriodicSpecCharID_ButtonPress(object sender, EventArgs e)
        {
            cdvPeriodicSpecCharID.Init();
            cdvPeriodicSpecCharID.Columns.Add("Character", 50, HorizontalAlignment.Left);
            cdvPeriodicSpecCharID.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvPeriodicSpecCharID.SelectedSubItemIndex = 0;
            if (EDCLIST.ViewEDCCharacterList(cdvPeriodicSpecCharID.GetListView, '1', 'S') == false)
            {
                return;
            }
        }

        #endregion

        #region " BIN Version Approval and Release "

        private void btnApproval_Click(object sender, EventArgs e)
        {
            if (UpdateBinVersion(MPGC.MP_STEP_APPROVAL) == false) return;
            if (ViewBinVersion() == false) return;
        }

        private void btnCancelApproval_Click(object sender, EventArgs e)
        {
            if (UpdateBinVersion(MPGC.MP_STEP_CANCEL_APPROVAL) == false) return;
            if (ViewBinVersion() == false) return;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (UpdateBinVersion(MPGC.MP_STEP_RELEASE) == false) return;
            if (ViewBinVersion() == false) return;
        }

        #endregion

        /* 2013.06.12. Aiden. Filter 추가 */
        private void btnFilterView_Click(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        
    }
}
