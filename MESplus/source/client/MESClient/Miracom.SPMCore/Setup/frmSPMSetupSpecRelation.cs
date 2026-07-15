//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmSPMSetupSpecRelation.cs
//   Description : Specification Relation Setup Form
//
//   MES Version : 5.2.0.0
//
//   Function List
//       - 
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2012-04-17 : Created by JYPARK
//
//
//   Copyright(C) 1998-2012 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;
using Miracom.BASCore;

namespace Miracom.SPMCore
{
    public partial class frmSPMSetupSpecRelation : SetupForm02
    {
        #region " Constant Definition "

        private const int KEY_1_COL = 0;
        private const int DATA_1_COL = 1;

        private enum ATTR_COL
        {
            CHECK,
            ATTR_NAME,
            ATTR_DESC,
            OLD_VALUE,
            NEW_VALUE,
            NEW_VALUE_BTN,
            NULL
        }

        #endregion

        #region " Variable Definition "

        bool bLoadFlag;
        private bool bIndexChangeFlag = false;
        private bool bIgnoreSelectFlag = false;
        private string sSelectedSpecID = String.Empty;
        private int iSelectedSpecVer = -1;
        private string sLastSelectedVersion = "";
        private string sLastSelectedCharID1 = "";
        private string sLastSelectedCharID2 = "";
        private string sLastSelectedCharID3 = "";

        private bool bUseSingleTargetAtSPM = false;

        //private bool bImgUpdateFlag = false;        // Image File Update 여부 Add by DM KIM 2013.08.27

        #endregion

        #region " Function Definition "

        public frmSPMSetupSpecRelation()
        {
            InitializeComponent();
        }

        //
        // ClearData()
        //       - Initialize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2")
        //
        private void ClearData(char ProcStep)
        {
            try
            {
                if (ProcStep == '1')
                {
                    // When Tree Node Selected
                    sSelectedSpecID = "";
                    iSelectedSpecVer = -1;
                    MPCF.InitListView(lisSpecVersion);

                    btnApproval.Enabled = btnCancelApproval.Enabled = btnRelease.Enabled = true;
                    MPCR.ChangeControlEnabled(this, btnUpdate, true);
                    MPCR.ChangeControlEnabled(this, btnDelete, true);
                }
                else if (ProcStep == '2')
                {
                    // When Version List Selected
                    // Version Tab Clear
                    chkStart.Checked = false;
                    dtpStartDate.Enabled = false;
                    dtpStartTime.Enabled = false;
                    chkEnd.Checked = false;
                    dtpEndDate.Enabled = false;
                    dtpEndTime.Enabled = false;
                    txtSpecVersion.Text = "";
                    chkApprovalFlag.Checked = false;
                    txtApprovalUser.Text = "";
                    txtApprovalTime.Text = "";
                    chkReleaseFlag.Checked = false;
                    txtReleaseUser.Text = "";
                    txtReleaseTime.Text = "";
                    txtSpecVerCreateUser.Text = "";
                    txtSpecVerCreateTime.Text = "";
                    txtSpecVerUpdateUser.Text = "";
                    txtSpecVerUpdateTime.Text = "";
                    // Assign Character Tab Clear
                    MPCF.InitListView(lisAssignedChar);
                    txtAssignedCharCount.Text = "";
                    MPCF.InitListView(lisAllChar);
                    txtAllCharCount.Text = "";
                    txtAllCharFilter.Text = "";
                    // Spec Limit Tab Clear
                    MPCF.InitListView(lisAssignedChar3);
                    MPCF.FieldClear(grpSpecLimit);
                    MPCF.ClearList(spdLimit);
                    spdLimit.ActiveSheet.ColumnHeader.Cells[0, 0, 0, spdLimit.ActiveSheet.ColumnCount - 2].Value = "";
                    MPCF.FieldClear(grpCusSpecLimit);
                    MPCF.ClearList(spdCusLimit);
                    spdCusLimit.ActiveSheet.ColumnHeader.Cells[0, 0, 0, spdCusLimit.ActiveSheet.ColumnCount - 2].Value = "";
                    tabLimit.SelectedIndex = 0;
                    AddSpecTypeItems(ref cboSpecType);
                    cboSpecType.SelectedIndex = 0;
                    AddSpecTypeItems(ref cboCusSpecType);
                    cboCusSpecType.SelectedIndex = 0;
                    chkManSpec.Checked = true;
                    // Spec Attribute Tab Clear
                    MPCF.InitListView(lisAssignedChar4);
                    MPCF.ClearList(spdAttr, true);
                    // Spec Copy Tab Clear
                    MPCF.FieldClear(grpCopy);
                    // Document Tab Clear
                    MPCF.InitListView(lisAssignedChar5);
                    MPCF.FieldClear(grpDoc);
                    MPCF.FieldClear(grpImg);
                }
                else if (ProcStep == '3')
                {
                    // When Limit Tab Character Selected
                    MPCF.FieldClear(grpSpecLimit);
                    MPCF.ClearList(spdLimit);
                    spdLimit.ActiveSheet.ColumnHeader.Cells[0, 0, 0, spdLimit.ActiveSheet.ColumnCount - 2].Value = "";
                    MPCF.FieldClear(grpCusSpecLimit);
                    MPCF.ClearList(spdCusLimit);
                    spdCusLimit.ActiveSheet.ColumnHeader.Cells[0, 0, 0, spdCusLimit.ActiveSheet.ColumnCount - 2].Value = "";
                    tabLimit.SelectedIndex = 0;
                    AddSpecTypeItems(ref cboSpecType);
                    cboSpecType.SelectedIndex = 0;
                    AddSpecTypeItems(ref cboCusSpecType);
                    cboCusSpecType.SelectedIndex = 0;
                    chkManSpec.Checked = true;
                }
                else if (ProcStep == '4')
                {
                    // When Attribute Tab Character Selected
                    MPCF.ClearList(spdAttr, true);
                }
                else if (ProcStep == '5')
                {
                    // Document Tab Clear
                    MPCF.FieldClear(grpAttachOption);
                    MPCF.FieldClear(grpDoc);
                    MPCF.FieldClear(grpImg);
                }
                else if (ProcStep == '6')
                {
                    // Copy Tab Clear
                    MPCF.FieldClear(grpCopy);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            switch (MPCF.Trim(FuncName))
            {
                case "Update_Spec":

                    switch (MPCF.ToChar(MPCF.Trim(ProcStep)))
                    {
                        case MPGC.MP_STEP_CREATE:

                            if (MPCF.CheckValue(txtSpecVersion, 1) == false)
                            {
                                tabSpec.SelectedTab = tbpVersion;
                                return false;
                            }
                            break;

                        case MPGC.MP_STEP_UPDATE:

                            if (MPCF.CheckValue(txtSpecVersion, 1) == false)
                            {
                                tabSpec.SelectedTab = tbpVersion;
                                return false;
                            }

                            // Spec Out Count Validation
                            if (MPCF.Trim(txtSpecOutCount.Text) != "")
                            {
                                if (MPCF.CheckValue(txtSpecOutCount, 2) == false)
                                {
                                    tabSpec.SelectedTab = tbpLimit;
                                    tabLimit.SelectedTab = tbpManSpec;
                                    txtSpecOutCount.Focus();
                                    txtSpecOutCount.SelectAll();
                                    return false;
                                }
                            }
                            if (MPCF.Trim(txtCusSpecOutCount.Text) != "")
                            {
                                if (MPCF.CheckValue(txtCusSpecOutCount, 2) == false)
                                {
                                    tabSpec.SelectedTab = tbpLimit;
                                    tabLimit.SelectedTab = tbpCusSpec;
                                    txtCusSpecOutCount.Focus();
                                    txtCusSpecOutCount.SelectAll();
                                    return false;
                                }
                            }

                            // When Character Type is Numeric
                            if (MPCF.Trim(tabLimit.Tag) == "N")
                            {
                                // Check Manufacturing Spec
                                if (cboSpecType.SelectedIndex == 1)
                                {
                                    if (MPCF.CheckValue(txtUpperSpecLimit, 2) == false)
                                    {
                                        tabSpec.SelectedTab = tbpLimit;
                                        tabLimit.SelectedTab = tbpManSpec;
                                        txtUpperSpecLimit.Focus();
                                        txtUpperSpecLimit.SelectAll();
                                        return false;
                                    }
                                    if (MPCF.CheckValue(txtLowerSpecLimit, 2) == false)
                                    {
                                        tabSpec.SelectedTab = tbpLimit;
                                        tabLimit.SelectedTab = tbpManSpec;
                                        txtLowerSpecLimit.Focus();
                                        txtLowerSpecLimit.SelectAll();
                                        return false;
                                    }
                                }
                                else if (cboSpecType.SelectedIndex == 2)
                                {
                                    if (MPCF.CheckValue(txtUpperSpecLimit, 2) == false)
                                    {
                                        tabSpec.SelectedTab = tbpLimit;
                                        tabLimit.SelectedTab = tbpManSpec;
                                        txtUpperSpecLimit.Focus();
                                        txtUpperSpecLimit.SelectAll();
                                        return false;
                                    }
                                }
                                else if (cboSpecType.SelectedIndex == 3)
                                {
                                    if (MPCF.CheckValue(txtLowerSpecLimit, 2) == false)
                                    {
                                        tabSpec.SelectedTab = tbpLimit;
                                        tabLimit.SelectedTab = tbpManSpec;
                                        txtLowerSpecLimit.Focus();
                                        txtLowerSpecLimit.SelectAll();
                                        return false;
                                    }
                                }
                                else if (cboSpecType.SelectedIndex == 4)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(338));
                                    tabSpec.SelectedTab = tbpLimit;
                                    tabLimit.SelectedTab = tbpManSpec;
                                    cboSpecType.Focus();
                                    return false;
                                }
                                if (MPCF.Trim(cdvTargetValue.Text) != "")
                                {
                                    if (MPCF.CheckValue(cdvTargetValue, 2) == false)
                                    {
                                        tabSpec.SelectedTab = tbpLimit;
                                        tabLimit.SelectedTab = tbpManSpec;
                                        cdvTargetValue.Focus();
                                        return false;
                                    }
                                }
                                if (txtUpperSpecLimit.Text != "" && txtLowerSpecLimit.Text != "")
                                {
                                    if (MPCF.ToDbl(txtUpperSpecLimit.Text) <= MPCF.ToDbl(txtLowerSpecLimit.Text))
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(261));
                                        tabSpec.SelectedTab = tbpLimit;
                                        tabLimit.SelectedTab = tbpManSpec;
                                        txtLowerSpecLimit.Focus();
                                        txtLowerSpecLimit.SelectAll();
                                        return false;
                                    }
                                }
                                if (txtUpperWarnLimit.Text != "" && txtLowerWarnLimit.Text != "")
                                {
                                    if (MPCF.ToDbl(txtUpperWarnLimit.Text) <= MPCF.ToDbl(txtLowerWarnLimit.Text))
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(262));
                                        tabSpec.SelectedTab = tbpLimit;
                                        tabLimit.SelectedTab = tbpManSpec;
                                        txtLowerWarnLimit.Focus();
                                        txtLowerWarnLimit.SelectAll();
                                        return false;
                                    }
                                }
                                if (txtUpperSpecLimit.Text != "" && txtUpperWarnLimit.Text != "")
                                {
                                    if (MPCF.ToDbl(txtUpperSpecLimit.Text) <= MPCF.ToDbl(txtUpperWarnLimit.Text))
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(259));
                                        tabSpec.SelectedTab = tbpLimit;
                                        tabLimit.SelectedTab = tbpManSpec;
                                        txtUpperWarnLimit.Focus();
                                        txtUpperWarnLimit.SelectAll();
                                        return false;
                                    }
                                }
                                if (txtLowerWarnLimit.Text != "" && txtLowerSpecLimit.Text != "")
                                {
                                    if (MPCF.ToDbl(txtLowerWarnLimit.Text) <= MPCF.ToDbl(txtLowerSpecLimit.Text))
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(260));
                                        tabSpec.SelectedTab = tbpLimit;
                                        tabLimit.SelectedTab = tbpManSpec;
                                        txtLowerSpecLimit.Focus();
                                        txtLowerSpecLimit.SelectAll();
                                        return false;
                                    }
                                }

                                // Check Customer Spec
                                if (cboCusSpecType.SelectedIndex == 1)
                                {
                                    if (MPCF.CheckValue(txtCusUpperSpecLimit, 2) == false)
                                    {
                                        tabSpec.SelectedTab = tbpLimit;
                                        tabLimit.SelectedTab = tbpCusSpec;
                                        txtCusUpperSpecLimit.Focus();
                                        txtCusUpperSpecLimit.SelectAll();
                                        return false;
                                    }
                                    if (MPCF.CheckValue(txtCusLowerSpecLimit, 2) == false)
                                    {
                                        tabSpec.SelectedTab = tbpLimit;
                                        tabLimit.SelectedTab = tbpCusSpec;
                                        txtCusLowerSpecLimit.Focus();
                                        txtCusLowerSpecLimit.SelectAll();
                                        return false;
                                    }
                                }
                                else if (cboCusSpecType.SelectedIndex == 2)
                                {
                                    if (MPCF.CheckValue(txtCusUpperSpecLimit, 2) == false)
                                    {
                                        tabSpec.SelectedTab = tbpLimit;
                                        tabLimit.SelectedTab = tbpCusSpec;
                                        txtCusUpperSpecLimit.Focus();
                                        txtCusUpperSpecLimit.SelectAll();
                                        return false;
                                    }
                                }
                                else if (cboCusSpecType.SelectedIndex == 3)
                                {
                                    if (MPCF.CheckValue(txtCusLowerSpecLimit, 2) == false)
                                    {
                                        tabSpec.SelectedTab = tbpLimit;
                                        tabLimit.SelectedTab = tbpCusSpec;
                                        txtCusLowerSpecLimit.Focus();
                                        txtCusLowerSpecLimit.SelectAll();
                                        return false;
                                    }
                                }
                                else if (cboCusSpecType.SelectedIndex == 4)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(338));
                                    tabSpec.SelectedTab = tbpLimit;
                                    tabLimit.SelectedTab = tbpCusSpec;
                                    cboCusSpecType.Focus();
                                    return false;
                                }
                                if (MPCF.Trim(cdvCusTargetValue.Text) != "")
                                {
                                    if (MPCF.CheckValue(cdvCusTargetValue, 2) == false)
                                    {
                                        tabSpec.SelectedTab = tbpLimit;
                                        tabLimit.SelectedTab = tbpCusSpec;
                                        cdvCusTargetValue.Focus();
                                        return false;
                                    }
                                }
                                if (txtCusUpperSpecLimit.Text != "" && txtCusLowerSpecLimit.Text != "")
                                {
                                    if (MPCF.ToDbl(txtCusUpperSpecLimit.Text) <= MPCF.ToDbl(txtCusLowerSpecLimit.Text))
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(261));
                                        tabSpec.SelectedTab = tbpLimit;
                                        tabLimit.SelectedTab = tbpCusSpec;
                                        txtCusLowerSpecLimit.Focus();
                                        txtCusLowerSpecLimit.SelectAll();
                                        return false;
                                    }
                                }
                                if (txtCusUpperWarnLimit.Text != "" && txtCusLowerWarnLimit.Text != "")
                                {
                                    if (MPCF.ToDbl(txtCusUpperWarnLimit.Text) <= MPCF.ToDbl(txtCusLowerWarnLimit.Text))
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(262));
                                        tabSpec.SelectedTab = tbpLimit;
                                        tabLimit.SelectedTab = tbpCusSpec;
                                        txtCusLowerWarnLimit.Focus();
                                        txtCusLowerWarnLimit.SelectAll();
                                        return false;
                                    }
                                }
                                if (txtCusUpperSpecLimit.Text != "" && txtCusUpperWarnLimit.Text != "")
                                {
                                    if (MPCF.ToDbl(txtCusUpperSpecLimit.Text) <= MPCF.ToDbl(txtCusUpperWarnLimit.Text))
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(259));
                                        tabSpec.SelectedTab = tbpLimit;
                                        tabLimit.SelectedTab = tbpCusSpec;
                                        txtCusUpperWarnLimit.Focus();
                                        txtCusUpperWarnLimit.SelectAll();
                                        return false;
                                    }
                                }
                                if (txtCusLowerWarnLimit.Text != "" && txtCusLowerSpecLimit.Text != "")
                                {
                                    if (MPCF.ToDbl(txtCusLowerWarnLimit.Text) <= MPCF.ToDbl(txtCusLowerSpecLimit.Text))
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(260));
                                        tabSpec.SelectedTab = tbpLimit;
                                        tabLimit.SelectedTab = tbpCusSpec;
                                        txtCusLowerSpecLimit.Focus();
                                        txtCusLowerSpecLimit.SelectAll();
                                        return false;
                                    }
                                }
                            }

                            // Spec Attribute Validation
                            bool bNullCheck = false;
                            int i, iRows = spdAttr.ActiveSheet.RowCount;
                            for (i = 0; i < iRows; i++)
                            {
                                if (Convert.ToBoolean(spdAttr.ActiveSheet.Cells[i, (int)ATTR_COL.NULL].Value) == true)
                                {
                                    bNullCheck = true;
                                    break;
                                }
                            }
                            if (bNullCheck)
                            {
                                if (MPCF.ShowMsgBox(MPCF.GetMessage(53), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                                {
                                    tabSpec.SelectedTab = tbpAttr;
                                    return false;
                                }
                            }

                            break;

                        case MPGC.MP_STEP_DELETE:

                            if (MPCF.CheckValue(txtSpecVersion, 1) == false)
                            {
                                tabSpec.SelectedTab = tbpVersion;
                                return false;
                            }
                            break;
                    }
                    break;

                case "VERSION_APPROVAL":
                case "VERSION_RELEASE":
                case "VERSION_CANCEL_APPROVAL":

                    if (MPCF.Trim(sSelectedSpecID) == "" || MPCF.ToInt(txtSpecVersion.Text) < 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        tabSpec.SelectedTab = tbpAttr;
                        tabVersion.SelectedTab = tbpAppNRel;
                        tvMFO.Focus();
                        return false;
                    }
                    break;

                case "ATTACH_ALLCHAR":

                    if (MPCF.Trim(sSelectedSpecID) == "" || MPCF.ToInt(txtSpecVersion.Text) < 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        tabSpec.SelectedTab = tbpCharacter;
                        tvMFO.Focus();
                        return false;
                    }
                    break;

                case "ATTACH_CHAR":

                    if (MPCF.Trim(sSelectedSpecID) == "" || MPCF.ToInt(txtSpecVersion.Text) < 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        tabSpec.SelectedTab = tbpCharacter;
                        tvMFO.Focus();
                        return false;
                    }
                    if (lisAllChar.SelectedItems.Count <= 0)
                    {
                        if (lisAllChar.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisAllChar.Items[0].Selected = true;
                            lisAllChar.Focus();
                        }
                        tabSpec.SelectedTab = tbpCharacter;
                        return false;
                    }
                    break;

                case "DETACH_CHAR":

                    if (MPCF.Trim(sSelectedSpecID) == "" || MPCF.ToInt(txtSpecVersion.Text) < 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        tabSpec.SelectedTab = tbpCharacter;
                        tvMFO.Focus();
                        return false;
                    }
                    if (lisAssignedChar.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisAssignedChar.Items.Count > 0)
                        {
                            lisAssignedChar.Items[0].Selected = true;
                            lisAssignedChar.Focus();
                        }
                        tabSpec.SelectedTab = tbpCharacter;
                        return false;
                    }
                    break;

                case "FILE_CHECK":

                    if (MPCF.CheckValue(txtSpecVersion, 2) == false)
                    {
                        tabSpec.SelectedTab = tbpVersion;
                        tabVersion.SelectedTab = tbpGeneral;
                        return false;
                    }
                    break;

                default:

                    MPCF.ShowMsgBox("Invalid Case");
                    return false;
            }
            return true;
        }

        //
        // SelectClear()
        //       - Clear Selected Items
        // Return Value
        //       -
        // Arguments
        //       - ByVal list As ListView : ListView
        //
        private object SelectClear(ListView list)
        {
            int i;
            for (i = 0; i <= list.Items.Count - 1; i++)
            {
                list.Items[i].Selected = false;
            }
            return null;
        }

        //
        // AddSpecTypeItems()
        //       - Add SpecType Items
        // Return Value
        //       -
        // Arguments
        //       - ByRef cboSpecType As ComboBox : ComboBox
        //
        private void AddSpecTypeItems(ref ComboBox cboSpecType)
        {
            try
            {
                cboSpecType.Items.Clear();
                cboSpecType.Items.Add(" ");                                 // Index : 0
                cboSpecType.Items.Add(MPCF.FindLanguage("Both", 0));        // Index : 1
                cboSpecType.Items.Add(MPCF.FindLanguage("Upper", 0));       // Index : 2
                cboSpecType.Items.Add(MPCF.FindLanguage("Lower", 0));       // Index : 3
                cboSpecType.Items.Add(MPCF.FindLanguage("Table", 0));       // Index : 4
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        //
        // RefreshTabStatus()
        //       - Refresh Tab Status
        // Return Value
        //       -
        // Arguments
        //       - 
        //
        private void RefreshTabStatus()
        {
            try
            {
                // Character Tab Page Refresh
                MPCF.ClearList(lisAssignedChar, true);
                if (MPCF.Trim(sSelectedSpecID) != "" && MPCF.ToInt(txtSpecVersion.Text) > 0)
                {
                    SPMLIST.ViewSpecCharacterList(lisAssignedChar, '1', sSelectedSpecID, MPCF.Trim(txtSpecVersion.Text), true);
                }
                EDCLIST.ViewEDCCharacterList(lisAllChar, '5', 'S', MPCF.Trim(txtAllCharFilter.Text));
                RefreshListCount();

                // Character Tab Page Refresh
                MPCF.ClearList(lisAssignedChar3, true);
                if (MPCF.Trim(sSelectedSpecID) != "" && MPCF.ToInt(txtSpecVersion.Text) > 0)
                {
                    SPMLIST.ViewSpecCharacterList(lisAssignedChar3, '1', sSelectedSpecID, MPCF.Trim(txtSpecVersion.Text), true);
                }

                // Attribute Tab Page Refresh
                MPCF.ClearList(lisAssignedChar4, true);
                if (MPCF.Trim(sSelectedSpecID) != "" && MPCF.ToInt(txtSpecVersion.Text) > 0)
                {
                    SPMLIST.ViewSpecCharacterList(lisAssignedChar4, '1', sSelectedSpecID, MPCF.Trim(txtSpecVersion.Text), true);
                }

                // Doc and Image Tab Page Refresh
                MPCF.ClearList(lisAssignedChar5, true);
                if (MPCF.Trim(sSelectedSpecID) != "" && MPCF.ToInt(txtSpecVersion.Text) > 0)
                {
                    SPMLIST.ViewSpecCharacterList(lisAssignedChar5, '1', sSelectedSpecID, MPCF.Trim(txtSpecVersion.Text), true);
                }

                if (lisAssignedChar3.Items.Count > 0)
                {
                    if (MPCF.Trim(sLastSelectedCharID1) != "")
                    {
                        MPCF.FindListItemNextPartial(lisAssignedChar3, sLastSelectedCharID1, true, false);
                    }
                    else
                    {
                        lisAssignedChar3.Items[0].Selected = true;
                    }
                }
                if (lisAssignedChar4.Items.Count > 0)
                {
                    if (MPCF.Trim(sLastSelectedCharID2) != "")
                    {
                        MPCF.FindListItemNextPartial(lisAssignedChar4, sLastSelectedCharID2, true, false);
                    }
                    else
                    {
                        lisAssignedChar4.Items[0].Selected = true;
                    }
                }
                if (lisAssignedChar5.Items.Count > 0)
                {
                    if (MPCF.Trim(sLastSelectedCharID3) != "")
                    {
                        MPCF.FindListItemNextPartial(lisAssignedChar5, sLastSelectedCharID3, true, false);
                    }
                    else
                    {
                        lisAssignedChar5.Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        //
        // RefreshListCount()
        //       - Refresh Assign Character List Count
        // Return Value
        //       -
        // Arguments
        //       - 
        //
        private void RefreshListCount()
        {
            txtAssignedCharCount.Text = String.Format("{0:#,##0}", lisAssignedChar.Items.Count);
            txtAllCharCount.Text = String.Format("{0:#,##0}", lisAllChar.Items.Count);
        }

        //
        // SetEnableLimit()
        //       - Specification and warning limit set enable or disable by value type
        // Return Value
        //       - 
        // Arguments
        //       - bool bNumericType : numeric type or ascii type
        //
        public void SetEnableLimit(bool bNumericType)
        {
            try
            {
                this.txtSpecOutCount.Text = "";
                this.txtUpperSpecLimit.Text = "";
                this.txtLowerSpecLimit.Text = "";
                this.txtUpperWarnLimit.Text = "";
                this.txtLowerWarnLimit.Text = "";

                this.txtCusSpecOutCount.Text = "";
                this.txtCusUpperSpecLimit.Text = "";
                this.txtCusLowerSpecLimit.Text = "";
                this.txtCusUpperWarnLimit.Text = "";
                this.txtCusLowerWarnLimit.Text = "";

                if (bNumericType == true)
                {
                    this.txtUpperSpecLimit.ReadOnly = false;
                    this.txtLowerSpecLimit.ReadOnly = false;
                    this.txtUpperWarnLimit.ReadOnly = false;
                    this.txtLowerWarnLimit.ReadOnly = false;

                    this.txtCusUpperSpecLimit.ReadOnly = false;
                    this.txtCusLowerSpecLimit.ReadOnly = false;
                    this.txtCusUpperWarnLimit.ReadOnly = false;
                    this.txtCusLowerWarnLimit.ReadOnly = false;
                }
                else
                {
                    this.txtUpperSpecLimit.ReadOnly = true;
                    this.txtLowerSpecLimit.ReadOnly = true;
                    this.txtUpperWarnLimit.ReadOnly = true;
                    this.txtLowerWarnLimit.ReadOnly = true;

                    this.txtCusUpperSpecLimit.ReadOnly = true;
                    this.txtCusLowerSpecLimit.ReadOnly = true;
                    this.txtCusUpperWarnLimit.ReadOnly = true;
                    this.txtCusLowerWarnLimit.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        //
        // Make_Column_Header()
        //       - View General Code Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool MakeColumnHeader(FarPoint.Win.Spread.FpSpread spdData, string sTableName)
        {
            TRSNode in_node = new TRSNode("VIEW_TABLE_IN");
            TRSNode out_node = new TRSNode("VIEW_TABLE_OUT");

            FarPoint.Win.Spread.CellType.TextCellType text_type;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", sTableName);
                in_node.AddChar("INCLUDE_CENTRAL_TABLE_FLAG", 'Y');

                if (MPCR.CallService("BAS", "BAS_View_Table", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdData.ActiveSheet.ColumnHeader.Cells[0, 0, 0, spdData.ActiveSheet.ColumnCount - 2].Value = "";

                if (out_node.GetString("KEY_1_PRT") != "")
                {
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].Value = " " + out_node.GetString("KEY_1_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[KEY_1_COL].Locked = true;
                    spdData.ActiveSheet.Columns[KEY_1_COL].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[KEY_1_COL].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    spdData.ActiveSheet.Columns[KEY_1_COL].CellType = text_type;
                }
                if (out_node.GetString("DATA_1_PRT") != "")
                {
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].Value = " " + out_node.GetString("DATA_1_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_1_COL].Locked = true;
                    spdData.ActiveSheet.Columns[DATA_1_COL].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_1_COL].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    spdData.ActiveSheet.Columns[DATA_1_COL].CellType = text_type;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

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
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");
            StringBuilder sb;
            ColumnHeader col;

            MPCF.InitListView(tvMFO.GetListView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            sb = new StringBuilder();

            switch (tvMFO.SelectLevel)
            {
                case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                    sb.Append("SELECT MAT_ID, MAT_VER, FLOW, OPER, SPEC_REL_ID ");
                    sb.Append("FROM MSPMRELDEF ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 ");
                    sb.Append("AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("AND REL_LEVEL = '" + tvMFO.SelectLevelChar + "' ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, FLOW ASC, OPER ASC, SPEC_REL_ID ASC");

                    if (tvMFO.GetListView.Columns.Count < 5)
                    {
                        col = new ColumnHeader();
                        col.Text = MPCF.FindLanguage("Spec. Rel ID", 0);
                        tvMFO.GetListView.Columns.Add(col);
                    }
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                    sb.Append("SELECT MAT_ID, MAT_VER, OPER, SPEC_REL_ID ");
                    sb.Append("FROM MSPMRELDEF ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 ");
                    sb.Append("AND OPER <> ' ' ");
                    sb.Append("AND REL_LEVEL = '" + tvMFO.SelectLevelChar + "' ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, OPER ASC, SPEC_REL_ID ASC");
                    if (tvMFO.GetListView.Columns.Count < 4)
                    {
                        col = new ColumnHeader();
                        col.Text = MPCF.FindLanguage("Spec. Rel ID", 0);
                        tvMFO.GetListView.Columns.Add(col);
                    }
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.M:
                    sb.Append("SELECT MAT_ID, MAT_VER, SPEC_REL_ID ");
                    sb.Append("FROM MSPMRELDEF ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 ");
                    sb.Append("AND REL_LEVEL = '" + tvMFO.SelectLevelChar + "' ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, SPEC_REL_ID ASC");
                    if (tvMFO.GetListView.Columns.Count < 3)
                    {
                        col = new ColumnHeader();
                        col.Text = MPCF.FindLanguage("Spec. Rel ID", 0);
                        tvMFO.GetListView.Columns.Add(col);
                    }
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                    sb.Append("SELECT FLOW, OPER, SPEC_REL_ID ");
                    sb.Append("FROM MSPMRELDEF ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("AND REL_LEVEL = '" + tvMFO.SelectLevelChar + "' ");
                    sb.Append("ORDER BY FLOW ASC, OPER ASC, SPEC_REL_ID ASC");
                    if (tvMFO.GetListView.Columns.Count < 3)
                    {
                        col = new ColumnHeader();
                        col.Text = MPCF.FindLanguage("Spec. Rel ID", 0);
                        tvMFO.GetListView.Columns.Add(col);
                    }
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.O:
                    sb.Append("SELECT OPER, SPEC_REL_ID ");
                    sb.Append("FROM MSPMRELDEF ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND OPER <> ' ' ");
                    sb.Append("AND REL_LEVEL = '" + tvMFO.SelectLevelChar + "' ");
                    sb.Append("ORDER BY OPER ASC, SPEC_REL_ID ASC");
                    if (tvMFO.GetListView.Columns.Count < 2)
                    {
                        col = new ColumnHeader();
                        col.Text = MPCF.FindLanguage("Spec. Rel ID", 0);
                        tvMFO.GetListView.Columns.Add(col);
                    }
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.Factory:
                    sb.Append("SELECT SPEC_REL_ID ");
                    sb.Append("FROM MSPMRELDEF ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND REL_LEVEL = '" + tvMFO.SelectLevelChar + "' ");
                    sb.Append("ORDER BY SPEC_REL_ID ASC");
                    if (tvMFO.GetListView.Columns.Count < 1)
                    {
                        col = new ColumnHeader();
                        col.Text = MPCF.FindLanguage("Spec. Rel ID", 0);
                        tvMFO.GetListView.Columns.Add(col);
                    }
                    break;
            }

            in_node.AddString("SQL", sb.ToString());

            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(tvMFO.GetListView, out_node, false, (int)SMALLICON_INDEX.IDX_MODULE, false);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (in_node.GetInt("NEXT_ROW") > 0);

            return true;
        }

        //
        // ViewSpecVersion()
        //       - View Spec Version
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewSpecVersion()
        {
            TRSNode in_node = new TRSNode("VIEW_SPEC_VERSION_IN");
            TRSNode out_node = new TRSNode("VIEW_SPEC_VERSION_OUT");

            try
            {
                ClearData('2');

                btnApproval.Enabled = btnCancelApproval.Enabled = btnRelease.Enabled = true;
                MPCR.ChangeControlEnabled(this, btnUpdate, true);
                MPCR.ChangeControlEnabled(this, btnDelete, true);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SPEC_REL_ID", sSelectedSpecID);
                in_node.AddInt("SPEC_REL_VER", iSelectedSpecVer);

                if (MPCR.CallService("SPM", "SPM_View_Spec_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtSpecVersion.Text = out_node.GetInt("SPEC_REL_VER").ToString();
                if (out_node.GetString("APPLY_START_TIME") == "")
                {
                    chkStart.Checked = dtpStartDate.Enabled = dtpStartTime.Enabled = false;
                }
                else
                {
                    chkStart.Checked = dtpStartDate.Enabled = dtpStartTime.Enabled = true;

                    if (out_node.GetString("APPLY_START_TIME") != null)
                    {
                        dtpStartDate.Value = MPCF.ToDate(out_node.GetString("APPLY_START_TIME"));
                        dtpStartTime.Value = MPCF.ToDate(out_node.GetString("APPLY_START_TIME"));
                    }
                }
                if (out_node.GetString("APPLY_END_TIME") == "")
                {
                    chkEnd.Checked = dtpEndDate.Enabled = dtpEndTime.Enabled = false;
                }
                else
                {
                    chkEnd.Checked = dtpEndDate.Enabled = dtpEndTime.Enabled = true;

                    if (out_node.GetString("APPLY_END_TIME") != null)
                    {
                        dtpEndDate.Value = MPCF.ToDate(out_node.GetString("APPLY_END_TIME"));
                        dtpEndTime.Value = MPCF.ToDate(out_node.GetString("APPLY_END_TIME"));
                    }
                }

                chkApprovalFlag.Checked = (MPCF.Trim(out_node.GetChar("APPROVAL_FLAG")) == "Y") ? true : false;
                txtApprovalUser.Text = out_node.GetString("APPROVAL_USER_ID");
                txtApprovalTime.Text = MPCF.MakeDateFormat(out_node.GetString("APPROVAL_TIME"));
                chkReleaseFlag.Checked = (MPCF.Trim(out_node.GetChar("RELEASE_FLAG")) == "Y") ? true : false;
                txtReleaseUser.Text = out_node.GetString("RELEASE_USER_ID");
                txtReleaseTime.Text = MPCF.MakeDateFormat(out_node.GetString("RELEASE_TIME"));
                txtSpecVerCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtSpecVerCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtSpecVerUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                txtSpecVerUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                if (chkApprovalFlag.Checked || chkReleaseFlag.Checked || (tabSpec.SelectedTab == tbpVersion && tabVersion.SelectedTab == tbpAppNRel))
                {
                    MPCR.ChangeControlEnabled(this, btnUpdate, false);
                    MPCR.ChangeControlEnabled(this, btnDelete, false);
                }

                if (chkReleaseFlag.Checked)
                {
                    btnApproval.Enabled = btnCancelApproval.Enabled = btnRelease.Enabled = false;
                }
                else if (chkApprovalFlag.Checked && chkReleaseFlag.Checked == false)
                {
                    btnApproval.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        //
        // ViewSpecCharacter()
        //       - View Spec Character
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewSpecCharacter(string sCharID)
        {
            TRSNode in_node = new TRSNode("VIEW_SPEC_CHARACTER_IN");
            TRSNode out_node = new TRSNode("VIEW_SPEC_CHARACTER_OUT");

            try
            {
                ClearData('3');

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SPEC_REL_ID", sSelectedSpecID);
                in_node.AddInt("SPEC_REL_VER", MPCF.ToInt(txtSpecVersion.Text));
                in_node.AddString("CHAR_ID", sCharID);

                if (MPCR.CallService("SPM", "SPM_View_Spec_Character", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetChar("SPEC_REF_TYPE") == 'M')
                {
                    tabLimit.SelectedTab = tbpManSpec;
                    chkManSpec.Checked = true;
                }
                else if (out_node.GetChar("SPEC_REF_TYPE") == 'C')
                {
                    tabLimit.SelectedTab = tbpCusSpec;
                    chkCusSpec.Checked = true;
                }

                tabLimit.Tag = out_node.GetChar("VALUE_TYPE");
                if (MPCF.Trim(tabLimit.Tag) == "N")
                    SetEnableLimit(true);
                else
                    SetEnableLimit(false);

                switch (out_node.GetChar("SPEC_TYPE"))
                {
                    case 'B': // Both
                        cboSpecType.SelectedIndex = 1;
                        break;
                    case 'U': // Upper
                        cboSpecType.SelectedIndex = 2;
                        break;
                    case 'L': // Lower
                        cboSpecType.SelectedIndex = 3;
                        break;
                    case 'T': // Table
                        cboSpecType.SelectedIndex = 4;
                        break;

                    default:
                        if (out_node.GetString("LOWER_SPEC_LIMIT") != "" && out_node.GetString("UPPER_SPEC_LIMIT") != "")
                        {
                            cboSpecType.SelectedIndex = 1; // Both
                        }
                        else if (out_node.GetString("LOWER_SPEC_LIMIT") == "" && out_node.GetString("UPPER_SPEC_LIMIT") != "")
                        {
                            cboSpecType.SelectedIndex = 2; // Upper
                        }
                        else if (out_node.GetString("LOWER_SPEC_LIMIT") != "" && out_node.GetString("UPPER_SPEC_LIMIT") == "")
                        {
                            cboSpecType.SelectedIndex = 3; // Lower
                        }
                        else if (out_node.GetString("VALID_TABLE") != "")
                        {
                            cboSpecType.SelectedIndex = 4; // Table
                        }
                        break;
                }

                cboSpecType_SelectedIndexChanged(null, null);
                txtSpecOutCount.Text = MPCF.Trim(out_node.GetInt("SPEC_OUT_COUNT"));
                cdvAlarmCode1.Text = out_node.GetString("SPEC_OUT_ALARM");
                cdvAlarmCode2.Text = out_node.GetString("WARN_OUT_ALARM");
                cdvTargetValue.Text = out_node.GetString("TARGET_VALUE");
                txtLowerSpecLimit.Text = out_node.GetString("LOWER_SPEC_LIMIT");
                txtUpperSpecLimit.Text = out_node.GetString("UPPER_SPEC_LIMIT");
                txtLowerWarnLimit.Text = out_node.GetString("LOWER_WARN_LIMIT");
                txtUpperWarnLimit.Text = out_node.GetString("UPPER_WARN_LIMIT");
                cdvValidTable.Text = out_node.GetString("VALID_TABLE");
                
                if (out_node.GetChar("SPEC_TYPE") == 'T' && bUseSingleTargetAtSPM == false)
                {
                    MakeColumnHeader(spdLimit, cdvValidTable.Text);
                    ViewGCMDataListSpread(spdLimit, cdvValidTable.Text);
                    for (int i = 0; i < spdLimit.ActiveSheet.RowCount; i++)
                    {
                        for (int j = 0; j < out_node.GetList(0).Count; j++)
                        {
                            if (MPCF.Trim(spdLimit.ActiveSheet.GetValue(i, 0)) == out_node.GetList(0)[j].GetString("VALUE"))
                            {
                                if (out_node.GetList(0)[j].GetChar("LIMIT_TYPE") == 'T')
                                {
                                    spdLimit.ActiveSheet.SetValue(i, 2, "Target");
                                }
                                else if (out_node.GetList(0)[j].GetChar("LIMIT_TYPE") == 'W')
                                {
                                    spdLimit.ActiveSheet.SetValue(i, 2, "Warn. Out");
                                }
                                else if (out_node.GetList(0)[j].GetChar("LIMIT_TYPE") == 'S')
                                {
                                    spdLimit.ActiveSheet.SetValue(i, 2, "Spec. Out");
                                }
                            }
                        }
                    }
                }

                switch (out_node.GetChar("CUST_SPEC_TYPE"))
                {
                    case 'B': // Both
                        cboCusSpecType.SelectedIndex = 1;
                        break;
                    case 'U': // Upper
                        cboCusSpecType.SelectedIndex = 2;
                        break;
                    case 'L': // Lower
                        cboCusSpecType.SelectedIndex = 3;
                        break;
                    case 'T': // Table
                        cboCusSpecType.SelectedIndex = 4;
                        break;
                    case 'F': // File
                        cboCusSpecType.SelectedIndex = 5;
                        break;

                    default:
                        if (out_node.GetString("CUST_LOWER_SPEC_LIMIT") != "" && out_node.GetString("CUST_UPPER_SPEC_LIMIT") != "")
                        {
                            cboCusSpecType.SelectedIndex = 1; // Both
                        }
                        else if (out_node.GetString("CUST_LOWER_SPEC_LIMIT") == "" && out_node.GetString("CUST_UPPER_SPEC_LIMIT") != "")
                        {
                            cboCusSpecType.SelectedIndex = 2; // Upper
                        }
                        else if (out_node.GetString("CUST_LOWER_SPEC_LIMIT") != "" && out_node.GetString("CUST_UPPER_SPEC_LIMIT") == "")
                        {
                            cboCusSpecType.SelectedIndex = 3; // Lower
                        }
                        else if (out_node.GetString("CUST_VALID_TABLE") != "")
                        {
                            cboCusSpecType.SelectedIndex = 4; // Table
                        }
                        break;
                }

                cboCusSpecType_SelectedIndexChanged(null, null);
                txtCusSpecOutCount.Text = MPCF.Trim(out_node.GetInt("CUST_SPEC_OUT_COUNT"));
                cdvCusAlarmCode1.Text = out_node.GetString("CUST_SPEC_OUT_ALARM");
                cdvCusAlarmCode2.Text = out_node.GetString("CUST_WARN_OUT_ALARM");
                cdvCusTargetValue.Text = out_node.GetString("CUST_TARGET_VALUE");
                txtCusLowerSpecLimit.Text = out_node.GetString("CUST_LOWER_SPEC_LIMIT");
                txtCusUpperSpecLimit.Text = out_node.GetString("CUST_UPPER_SPEC_LIMIT");
                txtCusLowerWarnLimit.Text = out_node.GetString("CUST_LOWER_WARN_LIMIT");
                txtCusUpperWarnLimit.Text = out_node.GetString("CUST_UPPER_WARN_LIMIT");
                cdvCusValidTable.Text = out_node.GetString("CUST_VALID_TABLE");

                if (out_node.GetChar("CUST_SPEC_TYPE") == 'T' && bUseSingleTargetAtSPM == false)
                {
                    MakeColumnHeader(spdCusLimit, cdvCusValidTable.Text);
                    ViewGCMDataListSpread(spdCusLimit, cdvCusValidTable.Text);
                    for (int i = 0; i < spdCusLimit.ActiveSheet.RowCount; i++)
                    {
                        for (int j = 0; j < out_node.GetList(0).Count; j++)
                        {
                            if (MPCF.Trim(spdCusLimit.ActiveSheet.GetValue(i, 0)) == out_node.GetList(0)[j].GetString("VALUE"))
                            {
                                if (out_node.GetList(0)[j].GetChar("LIMIT_TYPE") == 'T')
                                {
                                    spdCusLimit.ActiveSheet.SetValue(i, 2, "Target");
                                }
                                else if (out_node.GetList(0)[j].GetChar("LIMIT_TYPE") == 'W')
                                {
                                    spdCusLimit.ActiveSheet.SetValue(i, 2, "Warn. Out");
                                }
                                else if (out_node.GetList(0)[j].GetChar("LIMIT_TYPE") == 'S')
                                {
                                    spdCusLimit.ActiveSheet.SetValue(i, 2, "Spec. Out");
                                }
                            }
                        }
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

        //
        // ViewCharacterAttachOption()
        //       - View Spec Character
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        /* 2013.06.12. Aiden. Character 별 Attach File 을 설정할 수 있도록 변경 */
        private bool ViewCharacterAttachOption(string sCharID)
        {
            TRSNode in_node = new TRSNode("VIEW_SPEC_CHARACTER_IN");
            TRSNode out_node = new TRSNode("VIEW_SPEC_CHARACTER_OUT");

            try
            {
                ClearData('5');

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SPEC_REL_ID", sSelectedSpecID);
                in_node.AddInt("SPEC_REL_VER", MPCF.ToInt(txtSpecVersion.Text));
                in_node.AddString("CHAR_ID", sCharID);

                if (MPCR.CallService("SPM", "SPM_View_Spec_Character", in_node, ref out_node) == false)
                {
                    return false;
                }

                chkUseCharDir.Checked = out_node.GetChar("USE_CHAR_DIR") == 'Y' ? true : false;
                chkUseTargetToDir.Checked = out_node.GetChar("TARGET_VALUE_WITH_DIR") == 'Y' ? true : false;
                chkUseTargetToFile.Checked = out_node.GetChar("TARGET_VALUE_WITH_FILE") == 'Y' ? true : false;
                chkUseLatestFileVersion.Checked = out_node.GetChar("USE_LATEST_FILE_VER") == 'Y' ? true : false;
                txtFileExt.Text = out_node.GetString("TARGET_FILE_EXT");

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        //
        // ViewGCMDataListSpread()
        //       - View GCM Data List Spread
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewGCMDataListSpread(FarPoint.Win.Spread.FpSpread spdSpread, string table_name)
        {
            FarPoint.Win.Spread.SheetView sheetX;
            int iRow;
            int iCol;
            int i;
            System.Collections.ArrayList a_list;

            MPCF.ClearList(spdSpread);
            spdSpread.ActiveSheet.RowCount = 0;

            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node;

            a_list = new System.Collections.ArrayList();

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("TABLE_NAME", table_name);
            in_node.AddString("NEXT_KEY_1", "");
            in_node.AddString("NEXT_KEY_2", "");

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

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    sheetX = spdSpread.ActiveSheet;

                    if (sheetX.Columns.Count == 3)
                    {
                        iRow = sheetX.RowCount;
                        sheetX.RowCount++;

                        iCol = 0;

                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("KEY_1");

                        iCol++;
                        sheetX.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("DATA_1");

                        iCol++;
                    }

                }
            }

            MPCF.FitColumnHeader(spdSpread, KEY_1_COL, DATA_1_COL);

            return true;
        }

        //
        // ViewAttributeValueForUpdate()
        //       - View Attribute Value For Update
        // Return Value
        //       - boolean : True / False
        //
        private bool ViewAttributeValueForUpdate(string sCharID)
        {
            int i, i_row;
            FarPoint.Win.Spread.CellType.TextCellType txtCell;
            FarPoint.Win.Spread.CellType.NumberCellType numCell;
            FarPoint.Win.Spread.CellType.ButtonCellType btnCell;

            TRSNode in_node = new TRSNode("ATTR_IN");
            TRSNode out_node = new TRSNode("ATTR_OUT");

            ClearData('4');

            if (MPCF.Trim(sSelectedSpecID) == "")
                return false;

            if (MPCF.Trim(sCharID) == "")
                return false;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ATTR_TYPE", MPGC.MP_ATTR_TYPE_SPEC);
            in_node.AddString("SPEC_REL_ID", MPCF.Trim(sSelectedSpecID));
            in_node.AddInt("SPEC_REL_VER", MPCF.ToInt(txtSpecVersion.Text));
            in_node.AddString("CHAR_ID", MPCF.Trim(sCharID));
            //in_node.AddString("ATTR_NAME", "");
            //in_node.AddInt("ATTR_FROM", 0);
            //in_node.AddInt("ATTR_TO", 0);
            in_node.AddString("NEXT_ATTR_NAME", "");
            in_node.AddInt("NEXT_ATTR_SEQ", 0);

            do
            {
                if (MPCR.CallService("BAS", "BAS_View_Attribute_Value_Brief", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    i_row = spdAttr.ActiveSheet.RowCount;
                    spdAttr.ActiveSheet.RowCount++;

                    spdAttr.ActiveSheet.Cells[i_row, (int)ATTR_COL.ATTR_NAME].Value = out_node.GetList(0)[i].GetString("ATTR_NAME");
                    spdAttr.ActiveSheet.Cells[i_row, (int)ATTR_COL.ATTR_NAME].Tag = out_node.GetList(0)[i].GetInt("LAST_ACTIVE_HIST_SEQ");
                    spdAttr.ActiveSheet.Cells[i_row, (int)ATTR_COL.ATTR_DESC].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("ATTR_DESC"));
                    spdAttr.ActiveSheet.Cells[i_row, (int)ATTR_COL.NEW_VALUE].Tag = out_node.GetList(0)[i].GetChar("LONG_LENGTH_ATTR_VALUE_FLAG");

                    System.Globalization.CultureInfo ci_local = System.Globalization.CultureInfo.CurrentCulture;

                    switch (out_node.GetList(0)[i].GetChar("ATTR_FMT"))
                    {
                        case 'A':
                            txtCell = new FarPoint.Win.Spread.CellType.TextCellType();
                            txtCell.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Ascii;
                            txtCell.MaxLength = out_node.GetList(0)[i].GetInt("ATTR_SIZE");
                            //txtCell.WordWrap = true;

                            spdAttr.ActiveSheet.Cells[i_row, (int)ATTR_COL.NEW_VALUE].CellType = txtCell;
                            break;
                        case 'N':
                            numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                            numCell.DecimalPlaces = 0;
                            numCell.MaximumValue = 9999999999999;
                            numCell.MinimumValue = 0;

                            numCell.Separator = ci_local.NumberFormat.NumberGroupSeparator;
                            spdAttr.ActiveSheet.Cells[i_row, (int)ATTR_COL.NEW_VALUE].CellType = numCell;
                            break;
                        case 'F':
                            numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                            numCell.DecimalPlaces = 3;
                            numCell.MaximumValue = 9999999999999;
                            numCell.MinimumValue = -9999999999999;

                            numCell.Separator = ci_local.NumberFormat.NumberGroupSeparator;
                            numCell.DecimalSeparator = ci_local.NumberFormat.NumberDecimalSeparator;

                            spdAttr.ActiveSheet.Cells[i_row, (int)ATTR_COL.NEW_VALUE].CellType = numCell;
                            break;
                    }

                    if (out_node.GetList(0)[i].GetString("VALID_TBL") == "")
                    {
                        spdAttr.ActiveSheet.AddSpanCell(i_row, (int)ATTR_COL.NEW_VALUE, 1, 2);
                    }
                    else
                    {
                        if (out_node.GetList(0)[i].GetChar("VALID_TBL_TYPE") == 'A' || out_node.GetList(0)[i].GetChar("VALID_TBL_TYPE") == 'Q')
                        {
                            btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            btnCell.Text = "...";
                            spdAttr.ActiveSheet.Cells[i_row, (int)ATTR_COL.NEW_VALUE_BTN].CellType = btnCell;
                            spdAttr.ActiveSheet.Cells[i_row, (int)ATTR_COL.NEW_VALUE_BTN].Tag = out_node.GetList(0)[i].GetString("VALID_TBL");
                        }
                        else
                        {
                            spdAttr.ActiveSheet.AddSpanCell(i_row, (int)ATTR_COL.NEW_VALUE, 1, 2);
                        }

                        if (out_node.GetList(0)[i].GetChar("ALLOW_BLANK") == 'Y')
                            spdAttr.ActiveSheet.Cells[i_row, (int)ATTR_COL.OLD_VALUE].Tag = 'Y';
                    }

                    if (out_node.GetList(0)[i].GetChar("LONG_LENGTH_ATTR_VALUE_FLAG") == 'Y')
                    {
                        string value = out_node.GetList(0)[i].GetString("ATTR_VALUE");
                        out_node.GetList(0)[i].SetString("ATTR_VALUE", value += " ...");
                    }
                    if (out_node.GetList(0)[i].GetChar("NULL_FLAG") == 'Y')
                    {
                        spdAttr.ActiveSheet.Cells[i_row, (int)ATTR_COL.OLD_VALUE].Value = "[Null]";
                    }
                    else
                    {
                        spdAttr.ActiveSheet.Cells[i_row, (int)ATTR_COL.OLD_VALUE].Value = out_node.GetList(0)[i].GetString("ATTR_VALUE");
                    }

                    spdAttr.ActiveSheet.Rows[i_row].Height = spdAttr.ActiveSheet.GetPreferredRowHeight(i_row);
                }

                in_node.SetString("NEXT_ATTR_NAME", out_node.GetString("NEXT_ATTR_NAME"));
                in_node.SetInt("NEXT_ATTR_SEQ", out_node.GetInt("NEXT_ATTR_SEQ"));

            } while (in_node.GetString("NEXT_ATTR_NAME") != "" || in_node.GetInt("NEXT_ATTR_SEQ") > 0);

            return true;
        }

        //
        // ViewSpecAttachFile()
        //       - View spec attached file
        // Return Value
        //       - boolean : True / False
        //
        private bool ViewCharacterAttachFile(char c_case, string s_char_id, string s_file_name)
        {
            TRSNode in_node = new TRSNode("VIEW_SPEC_ATTACH_FILE_IN");
            TRSNode out_node = new TRSNode("VIEW_SPEC_ATTACH_FILE_OUT");
            byte[] bt_buffer;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_case;
            in_node.AddString("SPEC_REL_ID", sSelectedSpecID);
            in_node.AddInt("SPEC_REL_VER", MPCF.ToInt(txtSpecVersion.Text));
            in_node.AddString("CHAR_ID", s_char_id);
            in_node.AddString("FILE_NAME", s_file_name);

            if (MPCR.CallService("SPM", "SPM_View_Spec_Attach_File", in_node, ref out_node) == false)
            {
                return false;
            }

            if (c_case == '1' && s_file_name == "")
            {
                cdvDoc1.GetTextBox.Tag = null;
                cdvDoc2.GetTextBox.Tag = null;
                cdvDoc3.GetTextBox.Tag = null;
                cdvDoc4.GetTextBox.Tag = null;
                cdvDoc5.GetTextBox.Tag = null;

                cdvImg1.GetTextBox.Tag = null;
                cdvImg2.GetTextBox.Tag = null;
                cdvImg3.GetTextBox.Tag = null;

                cdvDoc1.Text = out_node.GetString("DOC_NAME_1");
                cdvDoc2.Text = out_node.GetString("DOC_NAME_2");
                cdvDoc3.Text = out_node.GetString("DOC_NAME_3");
                cdvDoc4.Text = out_node.GetString("DOC_NAME_4");
                cdvDoc5.Text = out_node.GetString("DOC_NAME_5");

                cdvImg1.Text = out_node.GetString("IMG_NAME_1");
                picImg1.Image = null;
                if ((bt_buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_1)) != null)
                {
                    MemoryStream ms_buffer;

                    try
                    {
                        ms_buffer = new MemoryStream();
                        ms_buffer.Write(bt_buffer, 0, bt_buffer.Length);
                        ms_buffer.Position = 0;

                        picImg1.Image = Image.FromStream(ms_buffer);
                        cdvImg1.Tag = bt_buffer;
                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMsgBox(ex.Message);
                    }
                }
                cdvImg2.Text = out_node.GetString("IMG_NAME_2");
                picImg2.Image = null;
                if ((bt_buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_2)) != null)
                {
                    MemoryStream ms_buffer;

                    try
                    {
                        ms_buffer = new MemoryStream();
                        ms_buffer.Write(bt_buffer, 0, bt_buffer.Length);
                        ms_buffer.Position = 0;

                        picImg2.Image = Image.FromStream(ms_buffer);
                        cdvImg2.Tag = bt_buffer;
                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMsgBox(ex.Message);
                    }
                }
                cdvImg3.Text = out_node.GetString("IMG_NAME_3");
                picImg3.Image = null;
                if ((bt_buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_3)) != null)
                {
                    MemoryStream ms_buffer;

                    try
                    {
                        ms_buffer = new MemoryStream();
                        ms_buffer.Write(bt_buffer, 0, bt_buffer.Length);
                        ms_buffer.Position = 0;

                        picImg3.Image = Image.FromStream(ms_buffer);
                        cdvImg3.Tag = bt_buffer;
                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMsgBox(ex.Message);
                    }
                }
            }
            else
            {
                if ((bt_buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_1)) == null)
                {
                    return false;
                }
                s_file_name = out_node.GetString("FILE_NAME");
                s_file_name = Environment.GetEnvironmentVariable("TEMP") + "\\" + s_file_name;

                try
                {
                    FileStream fs = File.Open(s_file_name, FileMode.Create);
                    BinaryWriter writer = new BinaryWriter(fs);
                    writer.Write(bt_buffer, 0, bt_buffer.Length);
                    writer.Close();
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    return false;
                }

                Process proc = new Process();
                proc.StartInfo.FileName = s_file_name;
                proc.Start();
            }

            return true;
        }

        //
        // Update_Spec()
        //       - Update Spec
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool UpdateSpec(char c_step)
        {
            TRSNode in_node = new TRSNode("UPDATE_SPEC_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            in_node.AddChar("REL_LEVEL", tvMFO.SelectLevelChar);
            in_node.AddString("MAT_ID", tvMFO.MatID);
            in_node.AddInt("MAT_VER", tvMFO.MatVersion);
            in_node.AddString("FLOW", tvMFO.Flow);
            in_node.AddString("OPER", tvMFO.Oper);

            if (MPCF.Trim(sSelectedSpecID) != "")
            {
                in_node.AddString("SPEC_REL_ID", sSelectedSpecID);
            }

            // Spec Rel Version Tab
            in_node.AddInt("SPEC_REL_VER", MPCF.ToInt(txtSpecVersion.Text));
            if (chkStart.Checked)
            {
                String s_datetime = MPCF.ToStandardTime(dtpStartDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) +
                    MPCF.ToStandardTime(dtpStartTime.Value, MPGC.MP_CONVERT_TIME_FORMAT);
                in_node.AddString("APPLY_START_TIME", s_datetime);
            }
            if (chkEnd.Checked)
            {
                String s_datetime = MPCF.ToStandardTime(dtpEndDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) +
                    MPCF.ToStandardTime(dtpEndTime.Value, MPGC.MP_CONVERT_TIME_FORMAT);
                in_node.AddString("APPLY_END_TIME", s_datetime);
            }

            if (c_step == MPGC.MP_STEP_APPROVAL)
            {
                in_node.AddChar("APPROVAL_FLAG", "Y");
            }
            else if (c_step == MPGC.MP_STEP_RELEASE)
            {
                in_node.AddChar("RELEASE_FLAG", "Y");
            }

            // Limit Info Tab
            if (c_step == MPGC.MP_STEP_UPDATE)
            {
                UpdateSpecSetLimitInfo(in_node);

                UpdateSpecSetAttribute(in_node);

                UpdateSpecSetAttachFile(in_node);
            }

            if (MPCR.CallService("SPM", "SPM_Update_Spec", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);
            return true;
        }

        //
        // UpdateSpecSetLimitInfo()
        //       - Update Spec Set Limit Information
        // Return Value
        //       - 
        // Arguments
        //       - 
        //
        private void UpdateSpecSetLimitInfo(TRSNode in_node)
        {
            TRSNode list_item;
            TRSNode list_item_sub;

            if (lisAssignedChar3.SelectedItems.Count <= 0) return;

            try
            {
                list_item = in_node.AddNode("LIMIT_LIST");
                list_item.AddString("CHAR_ID", MPCF.Trim(lisAssignedChar3.SelectedItems[0].Text));
                list_item.AddChar("NO_UPDATE_ATTACH_OPTION_FLAG", 'Y');

                if (chkManSpec.Checked)
                {
                    list_item.AddChar("SPEC_REF_TYPE", 'M');
                }
                else if (chkCusSpec.Checked)
                {
                    list_item.AddChar("SPEC_REF_TYPE", 'C');
                }

                if (cboSpecType.SelectedIndex == 1)
                {
                    list_item.AddChar("SPEC_TYPE", 'B');
                }
                else if (cboSpecType.SelectedIndex == 2)
                {
                    list_item.AddChar("SPEC_TYPE", 'U');
                }
                else if (cboSpecType.SelectedIndex == 3)
                {
                    list_item.AddChar("SPEC_TYPE", 'L');
                }
                else if (cboSpecType.SelectedIndex == 4)
                {
                    list_item.AddChar("SPEC_TYPE", 'T');
                }

                list_item.AddInt("SPEC_OUT_COUNT", MPCF.ToInt(txtSpecOutCount.Text));
                list_item.AddString("SPEC_OUT_ALARM", MPCF.Trim(cdvAlarmCode1.Text));
                list_item.AddString("WARN_OUT_ALARM", MPCF.Trim(cdvAlarmCode2.Text));

                if (cboSpecType.SelectedIndex == 4)
                {
                    list_item.AddString("VALID_TABLE", MPCF.Trim(cdvValidTable.Text));

                    if (bUseSingleTargetAtSPM == true)
                    {
                        list_item.AddString("TARGET_VALUE", MPCF.Trim(cdvTargetValue.Text));
                    }
                    else
                    {
                        for (int i = 0; i < spdLimit.ActiveSheet.RowCount; i++)
                        {
                            if (MPCF.Trim(spdLimit.ActiveSheet.GetValue(i, 2)) == "") continue;

                            list_item_sub = list_item.AddNode("VALID_TABLE_LIST");
                            list_item_sub.AddChar("SPEC_REF_TYPE", 'M');
                            list_item_sub.AddString("VALUE", spdLimit.ActiveSheet.GetValue(i, 0));
                            list_item_sub.AddChar("LIMIT_TYPE", MPCF.ToChar(MPCF.Trim(spdLimit.ActiveSheet.GetValue(i, 2)).Substring(0, 1)));
                        }
                    }
                }
                else
                {
                    list_item.AddString("TARGET_VALUE", MPCF.Trim(cdvTargetValue.Text));
                    list_item.AddString("UPPER_SPEC_LIMIT", MPCF.Trim(txtUpperSpecLimit.Text));
                    list_item.AddString("LOWER_SPEC_LIMIT", MPCF.Trim(txtLowerSpecLimit.Text));
                    list_item.AddString("UPPER_WARN_LIMIT", MPCF.Trim(txtUpperWarnLimit.Text));
                    list_item.AddString("LOWER_WARN_LIMIT", MPCF.Trim(txtLowerWarnLimit.Text));
                }

                if (cboCusSpecType.SelectedIndex == 1)
                {
                    list_item.AddChar("CUST_SPEC_TYPE", 'B');
                }
                else if (cboCusSpecType.SelectedIndex == 2)
                {
                    list_item.AddChar("CUST_SPEC_TYPE", 'U');
                }
                else if (cboCusSpecType.SelectedIndex == 3)
                {
                    list_item.AddChar("CUST_SPEC_TYPE", 'L');
                }
                else if (cboCusSpecType.SelectedIndex == 4)
                {
                    list_item.AddChar("CUST_SPEC_TYPE", 'T');
                }

                list_item.AddInt("CUST_SPEC_OUT_COUNT", MPCF.ToInt(txtCusSpecOutCount.Text));
                list_item.AddString("CUST_SPEC_OUT_ALARM", MPCF.Trim(cdvCusAlarmCode1.Text));
                list_item.AddString("CUST_WARN_OUT_ALARM", MPCF.Trim(cdvCusAlarmCode2.Text));

                if (cboCusSpecType.SelectedIndex == 4)
                {
                    list_item.AddString("CUST_VALID_TABLE", MPCF.Trim(cdvCusValidTable.Text));

                    if (bUseSingleTargetAtSPM == true)
                    {
                        list_item.AddString("CUST_TARGET_VALUE", MPCF.Trim(cdvCusTargetValue.Text));
                    }
                    else
                    {
                        for (int i = 0; i < spdCusLimit.ActiveSheet.RowCount; i++)
                        {
                            if (MPCF.Trim(spdCusLimit.ActiveSheet.GetValue(i, 2)) == "") continue;

                            list_item_sub = list_item.AddNode("VALID_TABLE_LIST");
                            list_item_sub.AddChar("SPEC_REF_TYPE", 'C');
                            list_item_sub.AddString("VALUE", spdCusLimit.ActiveSheet.GetValue(i, 0));
                            list_item_sub.AddChar("LIMIT_TYPE", MPCF.ToChar(MPCF.Trim(spdCusLimit.ActiveSheet.GetValue(i, 2)).Substring(0, 1)));
                        }
                    }
                }
                else
                {
                    list_item.AddString("CUST_TARGET_VALUE", MPCF.Trim(cdvCusTargetValue.Text));
                    list_item.AddString("CUST_UPPER_SPEC_LIMIT", MPCF.Trim(txtCusUpperSpecLimit.Text));
                    list_item.AddString("CUST_LOWER_SPEC_LIMIT", MPCF.Trim(txtCusLowerSpecLimit.Text));
                    list_item.AddString("CUST_UPPER_WARN_LIMIT", MPCF.Trim(txtCusUpperWarnLimit.Text));
                    list_item.AddString("CUST_LOWER_WARN_LIMIT", MPCF.Trim(txtCusLowerWarnLimit.Text));
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        //
        // UpdateSpecSetAttribute()
        //       - Update Spec Set Attribute
        // Return Value
        //       - 
        // Arguments
        //       - 
        //
        private void UpdateSpecSetAttribute(TRSNode in_node)
        {
            TRSNode list_item;
            TRSNode list_item_sub;
            int iChkCnt = 0;

            if (lisAssignedChar4.SelectedItems.Count <= 0) return;

            if (spdAttr.ActiveSheet.RowCount == 0) return;

            for (int i = 0; i < spdAttr.ActiveSheet.RowCount; i++)
            {
                if (spdAttr.ActiveSheet.Cells[i, (int)ATTR_COL.CHECK].Value != null)
                {
                    iChkCnt++;
                }
            }
            if (iChkCnt == 0) return;

            try
            {
                list_item = in_node.AddNode("ATTR_LIST");
                list_item.AddString("ATTR_TYPE", MPGC.MP_ATTR_TYPE_SPEC);
                list_item.AddString("CHAR_ID", MPCF.Trim(lisAssignedChar4.SelectedItems[0].Text));

                for (int i = 0; i < spdAttr.ActiveSheet.RowCount; i++)
                {
                    if (spdAttr.ActiveSheet.Cells[i, (int)ATTR_COL.CHECK].Value != null)
                    {
                        list_item_sub = list_item.AddNode("VALUE_LIST");
                        list_item_sub.AddString("ATTR_NAME", MPCF.Trim(spdAttr.ActiveSheet.Cells[i, (int)ATTR_COL.ATTR_NAME].Value));
                        if (spdAttr.ActiveSheet.Cells[i, (int)ATTR_COL.NULL].Value != null && (bool)spdAttr.ActiveSheet.Cells[i, (int)ATTR_COL.NULL].Value == true)
                        {
                            list_item_sub.AddChar("NULL_FLAG", 'Y');
                        }
                        if (spdAttr.ActiveSheet.Cells[i, (int)ATTR_COL.NEW_VALUE].Value != null)
                        {
                            if (spdAttr.ActiveSheet.Cells[i, (int)ATTR_COL.NEW_VALUE].CellType is FarPoint.Win.Spread.CellType.TextCellType == true)
                            {
                                list_item_sub.AddString("ATTR_VALUE", MPCF.Trim(spdAttr.ActiveSheet.Cells[i, (int)ATTR_COL.NEW_VALUE].Value));
                            }
                            else
                            {
                                list_item_sub.AddString("ATTR_VALUE", MPCF.Trim(MPCF.ToRegionNumber(spdAttr.ActiveSheet.Cells[i, (int)ATTR_COL.NEW_VALUE].Value)));
                            }
                        }
                        else
                        {
                            list_item_sub.AddString("ATTR_VALUE", "");
                        }

                        list_item_sub.AddInt("LAST_ACTIVE_HIST_SEQ", MPCF.ToInt(spdAttr.ActiveSheet.Cells[i, (int)ATTR_COL.ATTR_NAME].Tag));
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        //
        // UpdateSpecSetAttachFile()
        //       - Update Spec Set Attach File
        // Return Value
        //       - 
        // Arguments
        //       - 
        //
        private void UpdateSpecSetAttachFile(TRSNode in_node)
        {
            System.Collections.ArrayList cdvList;
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            byte[] file_buffer;
            int iFileCount = 1;

            try
            {
                // File (BIN_DATA_1 ~ 5)
                cdvList = MPCF.GetIndexedControl("cdvDoc", grpDoc);
                for (int i = 0; i < cdvList.Count; i++)
                {
                    if (iFileCount > 5) continue;

                    cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)cdvList[i];
                    if (MPCF.Trim(cdvTemp.GetTextBox.Tag) != "")
                    {
                        in_node.AddString(String.Format("FILE_NAME_{0}", iFileCount), MPCF.Trim(cdvTemp.Text));
                        if (cdvTemp.Tag != null)
                        {
                            file_buffer = (byte[])cdvTemp.Tag;
                            in_node.AddBlob(String.Format("__BIN_DATA_{0}", iFileCount), file_buffer);
                        }
                    }
                    iFileCount++;
                }

                // Image (BIN_DATA_6 ~ 8)
                if (MPCF.Trim(cdvImg1.GetTextBox.Tag) != "")
                {
                    in_node.AddString("FILE_NAME_6", MPCF.Trim(cdvImg1.Text));
                    if (cdvImg1.Tag != null)
                    {
                        file_buffer = (byte[])cdvImg1.Tag;
                        in_node.AddBlob(MPGC.MP_BIN_DATA_6, file_buffer);
                    }
                }
                if (MPCF.Trim(cdvImg2.GetTextBox.Tag) != "")
                {
                    in_node.AddString("FILE_NAME_7", MPCF.Trim(cdvImg2.Text));
                    if (cdvImg2.Tag != null)
                    {
                        file_buffer = (byte[])cdvImg2.Tag;
                        in_node.AddBlob(MPGC.MP_BIN_DATA_7, file_buffer);
                    }
                }
                if (MPCF.Trim(cdvImg3.GetTextBox.Tag) != "")
                {
                    in_node.AddString("FILE_NAME_8", MPCF.Trim(cdvImg3.Text));
                    if (cdvImg3.Tag != null)
                    {
                        file_buffer = (byte[])cdvImg3.Tag;
                        in_node.AddBlob(MPGC.MP_BIN_DATA_8, file_buffer);
                    }
                }

                // Modified by DM KIM 2013.08.27  Upload 파일 존재여부도 Check한다.
                if(lisAssignedChar5.SelectedItems.Count > 0)
				{
                    // Image 파일을 추가, 변경 또는 삭제 하거나 문서를 추가,변경 삭제할 경우 
                    //if (cdvDoc1.Text != "" ||
                    //    cdvDoc2.Text != "" ||
                    //    cdvDoc3.Text != "" ||
                    //    cdvDoc4.Text != "" ||
                    //    cdvDoc5.Text != "" ||
                    //    cdvImg1.Text != "" ||
                    //    cdvImg2.Text != "" ||
                    //    cdvImg3.Text != "" ||
                    //    bImgUpdateFlag == true)
                    //{
                        in_node.AddString("FILE_CHAR_ID", MPCF.Trim(lisAssignedChar5.SelectedItems[0].Text));
                    //}
				}

                in_node.AddChar("UPDATE_ATTACH_OPTION", 'Y');

                in_node.AddChar("USE_CHAR_DIR", chkUseCharDir.Checked == true ? 'Y' : ' ');
                in_node.AddChar("TARGET_VALUE_WITH_DIR", chkUseTargetToDir.Checked == true ? 'Y' : ' ');
                in_node.AddChar("TARGET_VALUE_WITH_FILE", chkUseTargetToFile.Checked == true ? 'Y' : ' ');
                in_node.AddChar("USE_LATEST_FILE_VER", chkUseLatestFileVersion.Checked == true ? 'Y' : ' ');
                in_node.AddString("TARGET_FILE_EXT", txtFileExt.Text);

                in_node.AddChar("KEEP_OLD_FILE_1", chkKeep1.Checked == true ? 'Y' : ' ');
                in_node.AddChar("KEEP_OLD_FILE_2", chkKeep2.Checked == true ? 'Y' : ' ');
                in_node.AddChar("KEEP_OLD_FILE_3", chkKeep3.Checked == true ? 'Y' : ' ');
                in_node.AddChar("KEEP_OLD_FILE_4", chkKeep4.Checked == true ? 'Y' : ' ');
                in_node.AddChar("KEEP_OLD_FILE_5", chkKeep5.Checked == true ? 'Y' : ' ');
                in_node.AddChar("KEEP_OLD_FILE_6", chkKeep6.Checked == true ? 'Y' : ' ');
                in_node.AddChar("KEEP_OLD_FILE_7", chkKeep7.Checked == true ? 'Y' : ' ');
                in_node.AddChar("KEEP_OLD_FILE_8", chkKeep8.Checked == true ? 'Y' : ' ');

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        //
        // UpdateSpecCharacter()
        //       - Create/Update/Delete Spec - Character Relation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal c_step As String         :  Process Step
        //       - ByVal sCharID As String        :  Character ID
        //
        private bool UpdateSpecCharacter(char c_step, string sCharID)
        {
            TRSNode in_node = new TRSNode("UPDATE_SPEC_CHARACTER_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("SPEC_REL_ID", sSelectedSpecID);
                in_node.AddInt("SPEC_REL_VER", MPCF.ToInt(txtSpecVersion.Text));
                in_node.AddString("CHAR_ID", sCharID);

                if (MPCR.CallService("SPM", "SPM_Update_Spec_Character", in_node, ref out_node) == false)
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

        //
        // Copy_Spec_Version()
        //       - Copy Spec Relation and it's attached character
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool CopySpecVersion(char cProcStep)
        {
            TRSNode in_node = new TRSNode("COPY_SPEC_VER_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = cProcStep;
                if (cProcStep == '1')
                {
                    // Relation Copy
                    if (MPCF.Trim(cdvToMaterial.Text) != "" && MPCF.Trim(cdvToFlow.Text) != "" && MPCF.Trim(cdvToOper.Text) != "")
                    {
                        in_node.AddChar("REL_LEVEL", '1');  // MFO
                    }
                    else if (MPCF.Trim(cdvToMaterial.Text) == "" && MPCF.Trim(cdvToFlow.Text) != "" && MPCF.Trim(cdvToOper.Text) != "")
                    {
                        in_node.AddChar("REL_LEVEL", '2');  // FO
                    }
                    else if (MPCF.Trim(cdvToMaterial.Text) == "" && MPCF.Trim(cdvToFlow.Text) == "" && MPCF.Trim(cdvToOper.Text) != "")
                    {
                        in_node.AddChar("REL_LEVEL", '3');  // O
                    }
                    else if (MPCF.Trim(cdvToMaterial.Text) != "" && MPCF.Trim(cdvToFlow.Text) == "" && MPCF.Trim(cdvToOper.Text) != "")
                    {
                        in_node.AddChar("REL_LEVEL", '4');  // MO
                    }
                    else if (MPCF.Trim(cdvToMaterial.Text) != "" && MPCF.Trim(cdvToFlow.Text) == "" && MPCF.Trim(cdvToOper.Text) == "")
                    {
                        in_node.AddChar("REL_LEVEL", '6');  // M
                    }
                    else if (MPCF.Trim(cdvToMaterial.Text) == "" && MPCF.Trim(cdvToFlow.Text) == "" && MPCF.Trim(cdvToOper.Text) == "")
                    {
                        in_node.AddChar("REL_LEVEL", '8');  // Factory
                    }

                    in_node.AddString("FROM_SPEC_REL_ID", sSelectedSpecID);
                    in_node.AddInt("FROM_SPEC_REL_VER", MPCF.ToInt(txtSpecVersion.Text));

                    in_node.AddInt("SPEC_REL_VER", MPCF.ToInt(MPCF.Trim(cdvToVer.Text)));
                    in_node.AddString("MAT_ID", MPCF.Trim(cdvToMaterial.Text));
                    in_node.AddInt("MAT_VER", cdvToMaterial.Version);
                    in_node.AddString("FLOW", MPCF.Trim(cdvToFlow.Text));
                    in_node.AddString("OPER", MPCF.Trim(cdvToOper.Text));
                }
                else
                {
                    // Version Copy
                    in_node.AddString("FROM_SPEC_REL_ID", sSelectedSpecID);
                    in_node.AddInt("FROM_SPEC_REL_VER", MPCF.ToInt(txtSpecVersion.Text));
                    in_node.AddString("SPEC_REL_ID", sSelectedSpecID);
                    in_node.AddInt("SPEC_REL_VER", MPCF.ToInt(MPCF.Trim(txtToVersion.Text)));
                }

                if (MPCR.CallService("SPM", "SPM_Copy_Spec_Version", in_node, ref out_node) == false)
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

        public virtual Control GetFirstFocusItem()
        {
            try
            {
                return this.tvMFO;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion

        private void frmSPMSetupSpecRelation_Activated(object sender, EventArgs e)
        {
            try
            {
                if (bLoadFlag == false)
                {
                    bUseSingleTargetAtSPM = MPGO.UseSingleTargetAtSPM();

                    cdvTargetValue.GetTextBox.Multiline = true;
                    cdvCusTargetValue.GetTextBox.Multiline = true;

                    bLoadFlag = true;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.InitListView(lisSpecVersion);
            ClearData('2');
            ClearData('3');

            if (tvMFO.OnlySetDataList)
            {
                ViewMFOSettingDataList();
                if (tvMFO.GetListView.Items.Count > 0)
                    MPCF.FindListItem(tvMFO.GetListView, sSelectedSpecID, tvMFO.GetListView.Columns.Count - 1, false);
            }
            else if (tvMFO.SelectLevel == Miracom.MESCore.Controls.MFOSelectLevel.Factory && tvMFO.SelectedNode.Parent == null)
            {
                string s_full_path = tvMFO.SelectedNode.FullPath;

                tvMFO.GetTreeView.SelectedNode = MPCF.FindTreeNode(tvMFO.GetTreeView, s_full_path);
                if (tvMFO.GetTreeView.SelectedNode == null)
                {
                    tvMFO.GetTreeView.SelectedNode = tvMFO.GetTreeView.TopNode.FirstNode;
                }

                tvMFO.GetTreeView.SelectedNode.EnsureVisible();

                if (SPMLIST.ViewSpecVersionListByMFO(lisSpecVersion, tvMFO.SelectLevelChar, tvMFO.MatID, tvMFO.MatVersion, tvMFO.Flow, tvMFO.Oper, null, "", ref sSelectedSpecID) == false)
                {
                    return;
                }

                if (lisSpecVersion.Items.Count > 0)
                {
                    if (lisSpecVersion.SelectedItems.Count == 0)
                    {
                        if (MPCF.Trim(sLastSelectedVersion) != "")
                        {
                            MPCF.FindListItemNextPartial(lisSpecVersion, sLastSelectedVersion, true, false);
                            sLastSelectedVersion = "";
                        }
                        else
                        {
                            lisSpecVersion.Items[0].Selected = true;
                        }
                    }
                }
                if (lisAssignedChar3.Items.Count > 0)
                {
                    if (MPCF.Trim(sLastSelectedCharID1) != "")
                    {
                        MPCF.FindListItemNextPartial(lisAssignedChar3, sLastSelectedCharID1, true, false);
                    }
                    else
                    {
                        lisAssignedChar3.Items[0].Selected = true;
                    }
                }
                if (lisAssignedChar4.Items.Count > 0)
                {
                    if (MPCF.Trim(sLastSelectedCharID2) != "")
                    {
                        MPCF.FindListItemNextPartial(lisAssignedChar4, sLastSelectedCharID2, true, false);
                    }
                    else
                    {
                        lisAssignedChar4.Items[0].Selected = true;
                    }
                }
                if (lisAssignedChar5.Items.Count > 0)
                {
                    if (MPCF.Trim(sLastSelectedCharID3) != "")
                    {
                        MPCF.FindListItemNextPartial(lisAssignedChar5, sLastSelectedCharID3, true, false);
                    }
                    else
                    {
                        lisAssignedChar5.Items[0].Selected = true;
                    }

                    // Add by DM KIM 2013.08.28 
                    //bImgUpdateFlag = false;
                }
            }
            else
            {
                tvMFO.RefreshSelectedList();
            }
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            tvMFO.GetNext(txtFind.Text);
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && MPCF.Trim(txtFind.Text) != "")
            {
                btnNext_Click(null, null);
            }
        }

        // 최상위 노드가 선택되어 리스트를 가져왔을때
        private void tvMFO_AfterGetTree(object sender, EventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(tvMFO.GetTreeView.GetNodeCount(false));
        }

        // 각 노드가 선택되었을 때
        private void tvMFO_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(tvMFO.SelectedNode.GetNodeCount(false));
        }

        // 선택 Level의 말단 노드가 선택되었을 때
        private void tvMFO_LevelItemSelect(System.Object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (e.Node.GetNodeCount(true) < 1)
            {
                ClearData('1');
                ClearData('2');
                if (SPMLIST.ViewSpecVersionListByMFO(lisSpecVersion, tvMFO.SelectLevelChar, tvMFO.MatID, tvMFO.MatVersion, tvMFO.Flow, tvMFO.Oper, null, "", ref sSelectedSpecID) == false)
                {
                    return;
                }
                if (lisSpecVersion.Items.Count > 0)
                {
                    if (MPCF.Trim(sLastSelectedVersion) != "")
                    {
                        MPCF.FindListItemNextPartial(lisSpecVersion, sLastSelectedVersion, true, false);
                        sLastSelectedVersion = "";
                    }
                    else
                    {
                        lisSpecVersion.Items[0].Selected = true;
                    }
                }
            }
        }

        private void tvMFO_GetOnlySetData(object sender, EventArgs e)
        {
            ViewMFOSettingDataList();
        }

        private void tvMFO_SetDataSelectedIndexChanged(object sender, EventArgs e)
        {
            int i_spec_id_index;

            i_spec_id_index = 0;

            switch (tvMFO.SelectLevel)
            {
                case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                    i_spec_id_index = 4;
                    break;
                case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                    i_spec_id_index = 3;
                    break;
                case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                case Miracom.MESCore.Controls.MFOSelectLevel.M:
                    i_spec_id_index = 2;
                    break;
                case Miracom.MESCore.Controls.MFOSelectLevel.O:
                    i_spec_id_index = 1;
                    break;
                case Miracom.MESCore.Controls.MFOSelectLevel.Factory:
                    i_spec_id_index = 0;
                    break;
            }
            ClearData('1');

            sSelectedSpecID = tvMFO.GetListView.SelectedItems[0].SubItems[i_spec_id_index].Text;

            SPMLIST.ViewSpecVersionList(lisSpecVersion, '1', sSelectedSpecID, -1, null, "");
            if (MPCF.Trim(sLastSelectedVersion) != "")
            {
                MPCF.FindListItemNextPartial(lisSpecVersion, sLastSelectedVersion, true, false);
                sLastSelectedVersion = "";
            }
            else
            {
                lisSpecVersion.Items[0].Selected = true;
            }
        }

        private void tvMFO_SelectLevelChanged(object sender, EventArgs e)
        {
            ClearData('1');
            ClearData('2');
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (CheckCondition("Update_Spec", MPGC.MP_STEP_CREATE))
            {
                if (UpdateSpec(MPGC.MP_STEP_CREATE))
                {
                    sLastSelectedVersion = lisSpecVersion.SelectedItems.Count > 0 ? lisSpecVersion.SelectedItems[0].Text : "";
                    sLastSelectedCharID1 = lisAssignedChar3.SelectedItems.Count > 0 ? lisAssignedChar3.SelectedItems[0].Text : "";
                    sLastSelectedCharID2 = lisAssignedChar4.SelectedItems.Count > 0 ? lisAssignedChar4.SelectedItems[0].Text : "";
                    sLastSelectedCharID3 = lisAssignedChar5.SelectedItems.Count > 0 ? lisAssignedChar5.SelectedItems[0].Text : "";
                    btnRefresh.PerformClick();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCondition("Update_Spec", MPGC.MP_STEP_UPDATE))
            {
                if (UpdateSpec(MPGC.MP_STEP_UPDATE))
                {
                    sLastSelectedVersion = lisSpecVersion.SelectedItems.Count > 0 ? lisSpecVersion.SelectedItems[0].Text : "";
                    sLastSelectedCharID1 = lisAssignedChar3.SelectedItems.Count > 0 ? lisAssignedChar3.SelectedItems[0].Text : "";
                    sLastSelectedCharID2 = lisAssignedChar4.SelectedItems.Count > 0 ? lisAssignedChar4.SelectedItems[0].Text : "";
                    sLastSelectedCharID3 = lisAssignedChar5.SelectedItems.Count > 0 ? lisAssignedChar5.SelectedItems[0].Text : "";
                    btnRefresh.PerformClick();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            if (CheckCondition("Update_Spec", MPGC.MP_STEP_DELETE))
            {
                if (UpdateSpec(MPGC.MP_STEP_DELETE))
                    btnRefresh.PerformClick();
            }
        }

        #region " Spec. Rel Version Tab Event "

        private void tabSpec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabSpec.SelectedTab == tbpVersion && tabVersion.SelectedTab == tbpAppNRel)
            {
                MPCR.ChangeControlEnabled(this, btnUpdate, false);
                MPCR.ChangeControlEnabled(this, btnDelete, false);
            }
            else if (chkApprovalFlag.Checked == false && chkReleaseFlag.Checked == false)
            {
                MPCR.ChangeControlEnabled(this, btnUpdate, true);
                MPCR.ChangeControlEnabled(this, btnDelete, true);
            }
        }

        private void lisSpecVersion_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (bIgnoreSelectFlag == false)
                {
                    bIndexChangeFlag = true;
                    if (lisSpecVersion.SelectedIndices.Count > 0)
                    {
                        iSelectedSpecVer = MPCF.ToInt(lisSpecVersion.SelectedItems[0].Text);
                        if (MPCF.Trim(sSelectedSpecID) != String.Empty)
                        {
                            if (ViewSpecVersion())
                            {
                                RefreshTabStatus();
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

        private void lisSpecVersion_Click(object sender, System.EventArgs e)
        {
            if (lisSpecVersion.SelectedIndices.Count > 0 && bIndexChangeFlag == false && bIgnoreSelectFlag == false)
            {
                if (MPCF.Trim(sSelectedSpecID) != String.Empty)
                {
                    iSelectedSpecVer = MPCF.ToInt(lisSpecVersion.SelectedItems[0].Text);
                    if (ViewSpecVersion())
                    {
                        RefreshTabStatus();
                    }
                }
            }
            bIndexChangeFlag = false;
        }

        private void txtSpecVersion_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13 || e.KeyChar == (char)8)
                {
                    return;
                }
                else if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void chkStart_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            if (chkStart.Checked)
            {
                dtpStartDate.Enabled = dtpStartTime.Enabled = true;
            }
            else
            {
                dtpStartDate.Enabled = dtpStartTime.Enabled = false;
            }
        }

        private void chkEnd_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            if (chkEnd.Checked)
            {
                dtpEndDate.Enabled = dtpEndTime.Enabled = true;
            }
            else
            {
                dtpEndDate.Enabled = dtpEndTime.Enabled = false;
            }
        }

        private void btnApproval_Click(object sender, EventArgs e)
        {
            if (CheckCondition("VERSION_APPROVAL", '1'))
            {
                if (UpdateSpec(MPGC.MP_STEP_APPROVAL))
                {
                    ViewSpecVersion();
                    RefreshTabStatus();
                }
            }
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (CheckCondition("VERSION_RELEASE", '1'))
            {
                if (UpdateSpec(MPGC.MP_STEP_RELEASE))
                {
                    ViewSpecVersion();
                    RefreshTabStatus();
                }
            }
        }

        private void btnCancelApproval_Click(object sender, EventArgs e)
        {
            if (CheckCondition("VERSION_CANCEL_APPROVAL", '1'))
            {
                if (UpdateSpec(MPGC.MP_STEP_CANCEL_APPROVAL))
                {
                    ViewSpecVersion();
                    RefreshTabStatus();
                }
            }
        }

        private void btnCopyVersion_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(txtToVersion, 2) == false)
            {
                tabSpec.SelectedTab = tbpVersion;
                tabVersion.SelectedTab = tbpCopyVer;
                return;
            }
            if (CopySpecVersion('2'))
            {
                sLastSelectedVersion = lisSpecVersion.SelectedItems.Count > 0 ? lisSpecVersion.SelectedItems[0].Text : "";
                sLastSelectedCharID1 = lisAssignedChar3.SelectedItems.Count > 0 ? lisAssignedChar3.SelectedItems[0].Text : "";
                sLastSelectedCharID2 = lisAssignedChar4.SelectedItems.Count > 0 ? lisAssignedChar4.SelectedItems[0].Text : "";
                sLastSelectedCharID3 = lisAssignedChar5.SelectedItems.Count > 0 ? lisAssignedChar5.SelectedItems[0].Text : "";
                btnRefresh.PerformClick();
                txtToVersion.Text = "";
                return;
            }
        }

        #endregion

        #region " Assign Character Tab Event "

        private void pnlCharMid_Resize(object sender, EventArgs e)
        {
            MPCF.FieldAdjust(pnlCharMid, pnlCharMidLeft, pnlCharMidRight, pnlCharMidMid, 40);
        }

        private void btnCharRefresh_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(lisAssignedChar, true);
            if (MPCF.Trim(sSelectedSpecID) != "" && MPCF.ToInt(txtSpecVersion.Text) > 0)
            {
                SPMLIST.ViewSpecCharacterList(lisAssignedChar, '1', sSelectedSpecID, MPCF.Trim(txtSpecVersion.Text), true);
                RefreshListCount();
            }
        }

        private void btnCharRefresh2_Click(object sender, EventArgs e)
        {
            EDCLIST.ViewEDCCharacterList(lisAllChar, '5', 'S', MPCF.Trim(txtAllCharFilter.Text));
            RefreshListCount();
        }

        private void btnAttachAll_Click(object sender, EventArgs e)
        {
            string sCharID;
            ListViewItem itmX;
            string[] sSelect = null;
            int i;
            int iIdx = 0;

            sSelect = new string[lisAllChar.Items.Count];
            SelectClear(lisAssignedChar);
            if (CheckCondition("ATTACH_ALLCHAR", '1') == false)
            {
                return;
            }
            for (i = 0; i <= lisAllChar.Items.Count - 1; i++)
            {
                sCharID = lisAllChar.Items[i].Text;
                if (MPCF.FindListItem(lisAssignedChar, sCharID, false) == false)
                {
                    if (UpdateSpecCharacter(MPGC.MP_STEP_CREATE, sCharID))
                    {
                        sSelect[i] = sCharID;
                        itmX = lisAssignedChar.Items.Add(sCharID, (int)SMALLICON_INDEX.IDX_CHARACTER);
                        itmX.SubItems.Add(lisAllChar.Items[i].SubItems[1].Text);
                        iIdx = lisAllChar.Items[i].Index;
                        itmX.Selected = true;
                        lisAssignedChar.Sorting = SortOrder.Ascending;
                        lisAssignedChar.Sort();
                    }
                    else
                    {
                        SelectClear(lisAllChar);
                        return;
                    }
                }
                else
                {
                    sSelect[i] = sCharID;
                    iIdx = lisAllChar.Items[i].Index;
                }
            }
            SelectClear(lisAllChar);
            if (sSelect.Length == 1)
            {
                if (iIdx < lisAllChar.Items.Count - 1)
                {
                    lisAllChar.Items[iIdx + 1].Selected = true;
                }
            }
            RefreshListCount();
        }

        private void btnAttach_Click(System.Object sender, System.EventArgs e)
        {
            string sCharID;
            ListViewItem itmX;
            string[] sSelect = null;
            int i;
            int iIdx = 0;

            sSelect = new string[lisAllChar.SelectedItems.Count];
            SelectClear(lisAssignedChar);
            if (CheckCondition("ATTACH_CHAR", '1') == false)
            {
                return;
            }
            for (i = 0; i <= lisAllChar.SelectedItems.Count - 1; i++)
            {
                sCharID = lisAllChar.SelectedItems[i].Text;
                if (MPCF.FindListItem(lisAssignedChar, sCharID, false) == false)
                {
                    if (UpdateSpecCharacter(MPGC.MP_STEP_CREATE, sCharID))
                    {
                        sSelect[i] = sCharID;
                        itmX = lisAssignedChar.Items.Add(sCharID, (int)SMALLICON_INDEX.IDX_CHARACTER);
                        itmX.SubItems.Add(lisAllChar.SelectedItems[i].SubItems[1].Text);
                        iIdx = lisAllChar.SelectedItems[i].Index;
                        itmX.Selected = true;
                        lisAssignedChar.Sorting = SortOrder.Ascending;
                        lisAssignedChar.Sort();
                    }
                    else
                    {
                        SelectClear(lisAllChar);
                        return;
                    }
                }
                else
                {
                    sSelect[i] = sCharID;
                    iIdx = lisAllChar.SelectedItems[i].Index;
                }
            }
            SelectClear(lisAllChar);
            if (sSelect.Length == 1)
            {
                if (iIdx < lisAllChar.Items.Count - 1)
                {
                    lisAllChar.Items[iIdx + 1].Selected = true;
                }
            }
            RefreshListCount();
        }

        private void btnDetach_Click(System.Object sender, System.EventArgs e)
        {
            string sCharID;
            int iIdx = 0;
            int i;
            int iCount;

            if (CheckCondition("DETACH_CHAR", '1') == false)
            {
                return;
            }
            iCount = lisAssignedChar.SelectedItems.Count;
            SelectClear(lisAllChar);
            for (i = lisAssignedChar.SelectedItems.Count - 1; i >= 0; i--)
            {
                sCharID = lisAssignedChar.SelectedItems[i].Text;
                if (UpdateSpecCharacter(MPGC.MP_STEP_DELETE, sCharID))
                {
                    iIdx = lisAssignedChar.SelectedItems[i].Index;
                    lisAssignedChar.Items.RemoveAt(iIdx);
                    MPCF.FindListItem(lisAllChar, sCharID, false);

                    if (iCount == 1)
                    {
                        if (iIdx < lisAssignedChar.Items.Count)
                        {
                            lisAssignedChar.Items[iIdx].Selected = true;
                        }
                    }
                }
            }
            RefreshListCount();
        }

        private void lisAssignedChar_DragDrop(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            string sCharID;
            ListViewItem itmX;
            string[] sSelect = null;
            int i;
            int iIdx = 0;

            sSelect = new string[lisAllChar.SelectedItems.Count];
            SelectClear(lisAssignedChar);
            if (CheckCondition("ATTACH_CHAR", '1') == false)
            {
                return;
            }
            for (i = 0; i <= lisAllChar.SelectedItems.Count - 1; i++)
            {
                sCharID = lisAllChar.SelectedItems[i].Text;
                if (MPCF.FindListItem(lisAssignedChar, sCharID, false) == false)
                {
                    if (UpdateSpecCharacter(MPGC.MP_STEP_CREATE, sCharID))
                    {
                        sSelect[i] = sCharID;
                        itmX = lisAssignedChar.Items.Add(sCharID, (int)SMALLICON_INDEX.IDX_CHARACTER);
                        itmX.SubItems.Add(lisAllChar.SelectedItems[i].SubItems[1].Text);
                        iIdx = lisAllChar.SelectedItems[i].Index;
                        itmX.Selected = true;
                        lisAssignedChar.Sorting = SortOrder.Ascending;
                        lisAssignedChar.Sort();
                    }
                    else
                    {
                        SelectClear(lisAllChar);
                        return;
                    }
                }
                else
                {
                    sSelect[i] = sCharID;
                    iIdx = lisAllChar.SelectedItems[i].Index;
                }

            }
            SelectClear(lisAllChar);
            if (sSelect.Length == 1)
            {
                if (iIdx < lisAllChar.Items.Count - 1)
                {
                    lisAllChar.Items[iIdx + 1].Selected = true;
                }
            }
            RefreshListCount();
        }

        private void lisAssignedChar_DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lisAssignedChar_ItemDrag(System.Object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            lisAssignedChar.DoDragDrop(lisAssignedChar.SelectedItems[0].Text, DragDropEffects.Move);
        }

        private void lisAssignedChar_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            lisAssignedChar.AllowDrop = false;
            lisAllChar.AllowDrop = true;
        }

        private void lisAssignedChar_Click(System.Object sender, System.EventArgs e)
        {
            SelectClear(lisAllChar);
        }

        private void lisAllChar_DragDrop(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            string sCharID;
            int iIdx = 0;
            int i;
            int iCount;

            if (CheckCondition("DETACH_CHAR", '1') == false)
            {
                return;
            }
            iCount = lisAssignedChar.SelectedItems.Count;
            SelectClear(lisAllChar);
            for (i = lisAssignedChar.SelectedItems.Count - 1; i >= 0; i--)
            {
                sCharID = lisAssignedChar.SelectedItems[i].Text;
                if (UpdateSpecCharacter(MPGC.MP_STEP_DELETE, sCharID))
                {
                    iIdx = lisAssignedChar.SelectedItems[i].Index;
                    lisAssignedChar.Items.RemoveAt(iIdx);
                    MPCF.FindListItem(lisAllChar, sCharID, false);
                    if (iCount == 1)
                    {
                        if (iIdx < lisAssignedChar.Items.Count)
                        {
                            lisAssignedChar.Items[iIdx].Selected = true;
                        }
                    }
                }
            }
            RefreshListCount();
        }

        private void lisAllChar_DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lisAllChar_ItemDrag(System.Object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            lisAllChar.DoDragDrop(lisAllChar.SelectedItems[0].Text, DragDropEffects.Copy);
        }

        private void lisAllChar_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            lisAllChar.AllowDrop = false;
            lisAssignedChar.AllowDrop = true;
        }

        private void lisAllChar_Click(System.Object sender, System.EventArgs e)
        {
            SelectClear(lisAssignedChar);
        }

        private void txtAllCharFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                EDCLIST.ViewEDCCharacterList(lisAllChar, '5', 'S', MPCF.Trim(txtAllCharFilter.Text));
                RefreshListCount();
            }
        }

        #endregion

        #region " Limit Information Tab Event "

        private void btnCharRefresh3_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(lisAssignedChar3, true);
            if (MPCF.Trim(sSelectedSpecID) != "" && MPCF.ToInt(txtSpecVersion.Text) > 0)
            {
                SPMLIST.ViewSpecCharacterList(lisAssignedChar3, '1', sSelectedSpecID, MPCF.Trim(txtSpecVersion.Text), true);
            }
        }

        private void lisAssignedChar3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisAssignedChar3.SelectedIndices.Count > 0)
            {
                string sCharID = MPCF.Trim(lisAssignedChar3.SelectedItems[0].Text);
                if (MPCF.Trim(sCharID) != String.Empty)
                {
                    sLastSelectedCharID1 = sCharID;
                    ViewSpecCharacter(sCharID);
                }
            }
        }

        private void chkManSpec_CheckedChanged(object sender, EventArgs e)
        {
            chkCusSpec.Checked = !chkManSpec.Checked;
        }

        private void chkCusSpec_CheckedChanged(object sender, EventArgs e)
        {
            chkManSpec.Checked = !chkCusSpec.Checked;
        }

        private void cboSpecType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.Trim(tabLimit.Tag) != "N")
                {
                    if (cboSpecType.SelectedIndex == 1 || cboSpecType.SelectedIndex == 2 || cboSpecType.SelectedIndex == 3)
                    {
                        cboSpecType.SelectedIndex = 0;
                    }
                }

                if (cboSpecType.SelectedIndex == 1)         // Both
                {
                    //txtUpperSpecLimit.Text = "";
                    //txtLowerSpecLimit.Text = "";
                    //txtUpperWarnLimit.Text = "";
                    //txtLowerWarnLimit.Text = "";
                    cdvTargetValue.ReadOnly = false;
                    txtUpperSpecLimit.ReadOnly = false;
                    txtLowerSpecLimit.ReadOnly = false;
                    txtUpperWarnLimit.ReadOnly = false;
                    txtLowerWarnLimit.ReadOnly = false;

                    lblValidTable.Visible = cdvValidTable.Visible = false;
                    grpSpecLimit.Height = 360;
                    spdLimit.Visible = false;
                    cdvTargetValue.VisibleButton = false;
                }
                else if (cboSpecType.SelectedIndex == 2)    // Upper
                {
                    //txtUpperSpecLimit.Text = "";
                    txtLowerSpecLimit.Text = "";
                    //txtUpperWarnLimit.Text = "";
                    txtLowerWarnLimit.Text = "";
                    cdvTargetValue.ReadOnly = false;
                    txtUpperSpecLimit.ReadOnly = false;
                    txtLowerSpecLimit.ReadOnly = true;
                    txtUpperWarnLimit.ReadOnly = false;
                    txtLowerWarnLimit.ReadOnly = true;

                    lblValidTable.Visible = cdvValidTable.Visible = false;
                    grpSpecLimit.Height = 360;
                    spdLimit.Visible = false;
                    cdvTargetValue.VisibleButton = false;
                }
                else if (cboSpecType.SelectedIndex == 3)    // Lower
                {
                    txtUpperSpecLimit.Text = "";
                    //txtLowerSpecLimit.Text = "";
                    txtUpperWarnLimit.Text = "";
                    //txtLowerWarnLimit.Text = "";
                    cdvTargetValue.ReadOnly = false;
                    txtUpperSpecLimit.ReadOnly = true;
                    txtLowerSpecLimit.ReadOnly = false;
                    txtUpperWarnLimit.ReadOnly = true;
                    txtLowerWarnLimit.ReadOnly = false;

                    lblValidTable.Visible = cdvValidTable.Visible = false;
                    grpSpecLimit.Height = 360;
                    spdLimit.Visible = false;
                    cdvTargetValue.VisibleButton = false;
                }
                else if (cboSpecType.SelectedIndex == 4)    // Table
                {
                    cdvTargetValue.Text = "";
                    txtUpperSpecLimit.Text = "";
                    txtLowerSpecLimit.Text = "";
                    txtUpperWarnLimit.Text = "";
                    txtLowerWarnLimit.Text = "";
                    cdvTargetValue.ReadOnly = true;
                    txtUpperSpecLimit.ReadOnly = true;
                    txtLowerSpecLimit.ReadOnly = true;
                    txtUpperWarnLimit.ReadOnly = true;
                    txtLowerWarnLimit.ReadOnly = true;
                    cdvAlarmCode1.Text = "";
                    cdvAlarmCode2.Text = "";

                    lblValidTable.Visible = cdvValidTable.Visible = true;

                    if (bUseSingleTargetAtSPM == true)
                    {
                        grpSpecLimit.Height = 360;
                        spdLimit.Visible = false;
                        cdvTargetValue.VisibleButton = true;
                    }
                    else
                    {
                        grpSpecLimit.Height = 170;
                        spdLimit.Visible = true;
                        cdvTargetValue.VisibleButton = false;
                    }
                }
                else if (cboSpecType.SelectedIndex == 0)    // None
                {
                    txtUpperSpecLimit.Text = "";
                    txtLowerSpecLimit.Text = "";
                    txtUpperWarnLimit.Text = "";
                    txtLowerWarnLimit.Text = "";
                    cdvTargetValue.ReadOnly = false;
                    txtUpperSpecLimit.ReadOnly = true;
                    txtLowerSpecLimit.ReadOnly = true;
                    txtUpperWarnLimit.ReadOnly = true;
                    txtLowerWarnLimit.ReadOnly = true;
                    cdvAlarmCode1.Text = "";
                    cdvAlarmCode2.Text = "";

                    lblValidTable.Visible = cdvValidTable.Visible = false;
                    grpSpecLimit.Height = 360;
                    spdLimit.Visible = false;
                    cdvTargetValue.VisibleButton = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cboCusSpecType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.Trim(tabLimit.Tag) != "N")
                {
                    if (cboCusSpecType.SelectedIndex == 1 || cboCusSpecType.SelectedIndex == 2 || cboCusSpecType.SelectedIndex == 3)
                    {
                        cboCusSpecType.SelectedIndex = 0;
                    }
                }

                if (cboCusSpecType.SelectedIndex == 1)         // Both
                {
                    //txtCusUpperSpecLimit.Text = "";
                    //txtCusLowerSpecLimit.Text = "";
                    //txtCusUpperWarnLimit.Text = "";
                    //txtCusLowerWarnLimit.Text = "";
                    cdvCusTargetValue.ReadOnly = false;
                    txtCusUpperSpecLimit.ReadOnly = false;
                    txtCusLowerSpecLimit.ReadOnly = false;
                    txtCusUpperWarnLimit.ReadOnly = false;
                    txtCusLowerWarnLimit.ReadOnly = false;

                    lblCusValidTable.Visible = cdvCusValidTable.Visible = false;
                    grpCusSpecLimit.Height = 360;
                    spdCusLimit.Visible = false;
                    cdvCusTargetValue.VisibleButton = false;
                }
                else if (cboCusSpecType.SelectedIndex == 2)    // Upper
                {
                    //txtCusUpperSpecLimit.Text = "";
                    txtCusLowerSpecLimit.Text = "";
                    //txtCusUpperWarnLimit.Text = "";
                    txtCusLowerWarnLimit.Text = "";
                    cdvCusTargetValue.ReadOnly = false;
                    txtCusUpperSpecLimit.ReadOnly = false;
                    txtCusLowerSpecLimit.ReadOnly = true;
                    txtCusUpperWarnLimit.ReadOnly = false;
                    txtCusLowerWarnLimit.ReadOnly = true;

                    lblCusValidTable.Visible = cdvCusValidTable.Visible = false;
                    grpCusSpecLimit.Height = 360;
                    spdCusLimit.Visible = false;
                    cdvCusTargetValue.VisibleButton = false;
                }
                else if (cboCusSpecType.SelectedIndex == 3)    // Lower
                {
                    txtCusUpperSpecLimit.Text = "";
                    //txtCusLowerSpecLimit.Text = "";
                    txtCusUpperWarnLimit.Text = "";
                    //txtCusLowerWarnLimit.Text = "";
                    cdvCusTargetValue.ReadOnly = false;
                    txtCusUpperSpecLimit.ReadOnly = true;
                    txtCusLowerSpecLimit.ReadOnly = false;
                    txtCusUpperWarnLimit.ReadOnly = true;
                    txtCusLowerWarnLimit.ReadOnly = false;

                    lblCusValidTable.Visible = cdvCusValidTable.Visible = false;
                    grpCusSpecLimit.Height = 360;
                    spdCusLimit.Visible = false;
                    cdvCusTargetValue.VisibleButton = false;
                }
                else if (cboCusSpecType.SelectedIndex == 4)    // Table
                {
                    cdvCusTargetValue.Text = "";
                    txtCusUpperSpecLimit.Text = "";
                    txtCusLowerSpecLimit.Text = "";
                    txtCusUpperWarnLimit.Text = "";
                    txtCusLowerWarnLimit.Text = "";
                    cdvCusTargetValue.ReadOnly = true;
                    txtCusUpperSpecLimit.ReadOnly = true;
                    txtCusLowerSpecLimit.ReadOnly = true;
                    txtCusUpperWarnLimit.ReadOnly = true;
                    txtCusLowerWarnLimit.ReadOnly = true;
                    cdvCusAlarmCode1.Text = "";
                    cdvCusAlarmCode2.Text = "";

                    lblCusValidTable.Visible = cdvCusValidTable.Visible = true;

                    if (bUseSingleTargetAtSPM == true)
                    {
                        grpCusSpecLimit.Height = 360;
                        spdCusLimit.Visible = false;
                        cdvCusTargetValue.VisibleButton = true;
                    }
                    else
                    {
                        grpCusSpecLimit.Height = 170;
                        spdCusLimit.Visible = true;
                        cdvCusTargetValue.VisibleButton = false;
                    }
                }
                else if (cboCusSpecType.SelectedIndex == 0)    // None
                {
                    txtCusUpperSpecLimit.Text = "";
                    txtCusLowerSpecLimit.Text = "";
                    txtCusUpperWarnLimit.Text = "";
                    txtCusLowerWarnLimit.Text = "";
                    cdvCusTargetValue.ReadOnly = false;
                    txtCusUpperSpecLimit.ReadOnly = true;
                    txtCusLowerSpecLimit.ReadOnly = true;
                    txtCusUpperWarnLimit.ReadOnly = true;
                    txtCusLowerWarnLimit.ReadOnly = true;
                    cdvCusAlarmCode1.Text = "";
                    cdvCusAlarmCode2.Text = "";

                    lblCusValidTable.Visible = cdvCusValidTable.Visible = false;
                    grpCusSpecLimit.Height = 360;
                    spdCusLimit.Visible = false;
                    cdvCusTargetValue.VisibleButton = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvValidTable_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
                cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

                cdvTemp.Init();
                cdvTemp.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
                cdvTemp.Columns.Add("Description", 100, HorizontalAlignment.Left);
                cdvTemp.SelectedSubItemIndex = 0;

                if (BASLIST.ViewGCMTableList(cdvTemp.GetListView, '1') == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvValidTable_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvValidTable.Text) != "")
            {
                if (bUseSingleTargetAtSPM == false)
                {
                    if (MakeColumnHeader(spdLimit, MPCF.Trim(cdvValidTable.Text)) == false) return;
                    ViewGCMDataListSpread(spdLimit, MPCF.Trim(cdvValidTable.Text));
                }
                else
                {
                    cdvTargetValue.Text = "";
                }
            }
        }

        private void cdvCusValidTable_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvCusValidTable.Text) != "")
            {
                if (bUseSingleTargetAtSPM == false)
                {
                    if (MakeColumnHeader(spdCusLimit, MPCF.Trim(cdvCusValidTable.Text)) == false) return;
                    ViewGCMDataListSpread(spdCusLimit, MPCF.Trim(cdvCusValidTable.Text));
                }
                else
                {
                    cdvCusTargetValue.Text = "";
                }
            }
        }

        private void cdvAlarmCode_ButtonPress(object sender, System.EventArgs e)
        {
            try
            {
#if _ALM
                Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
                cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

                cdvTemp.Init();
                cdvTemp.Columns.Add("Code", 50, HorizontalAlignment.Left);
                cdvTemp.Columns.Add("Description", 100, HorizontalAlignment.Left);
                cdvTemp.SelectedSubItemIndex = 0;

                if (ALMLIST.ViewAlarmMsgList(cdvTemp.GetListView, '1', ' ') == false)
                {
                    return;
                }
#endif  // _ALM
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void CheckInteger_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
                {
                    if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void CheckCharValue_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (lisAssignedChar3.SelectedItems.Count > 0 &&
                    MPCF.Trim(lisAssignedChar3.SelectedItems[0].SubItems[2].Text) != "N")
                {
                    return;
                }

                if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
                {
                    if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                    {
                        if (e.KeyChar == (char)46)
                        {
                            string sTmp = "";

                            if (sender is Miracom.UI.Controls.MCCodeView.MCCodeView)
                            {
                                sTmp = ((Miracom.UI.Controls.MCCodeView.MCCodeView)sender).Text;
                            }
                            else if (sender is TextBox)
                            {
                                sTmp = ((TextBox)sender).Text;
                            }
                            if (sTmp.IndexOf(".") >= 0)
                            {
                                e.Handled = true;
                            }
                        }
                        else if (e.KeyChar == (char)45)
                        {
                            string sTmp = "";

                            if (sender is Miracom.UI.Controls.MCCodeView.MCCodeView)
                            {
                                sTmp = ((Miracom.UI.Controls.MCCodeView.MCCodeView)sender).Text;
                            }
                            else if (sender is TextBox)
                            {
                                sTmp = ((TextBox)sender).Text;
                            }
                            if (sTmp.Length > 0)
                            {
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvTargetValue_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvValidTable.Text) != "")
            {
                cdvTargetValue.Init();
                MPCF.InitListView(cdvTargetValue.GetListView);
                cdvTargetValue.Columns.Add("Target Value", 50, HorizontalAlignment.Left);
                cdvTargetValue.Columns.Add("Description", 100, HorizontalAlignment.Left);
                cdvTargetValue.SelectedSubItemIndex = 0;

                if (BASLIST.ViewGCMDataList(cdvTargetValue.GetListView, '1', cdvValidTable.Text) == false)
                {
                    cdvTargetValue.IsPopup = false;
                    return;
                }
                cdvTargetValue.InsertEmptyRow(0, 1);
            }
        }

        private void cdvCusTargetValue_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvCusValidTable.Text) != "")
            {
                cdvCusTargetValue.Init();
                MPCF.InitListView(cdvCusTargetValue.GetListView);
                cdvCusTargetValue.Columns.Add("Target Value", 50, HorizontalAlignment.Left);
                cdvCusTargetValue.Columns.Add("Description", 100, HorizontalAlignment.Left);
                cdvCusTargetValue.SelectedSubItemIndex = 0;

                if (BASLIST.ViewGCMDataList(cdvCusTargetValue.GetListView, '1', cdvCusValidTable.Text) == false)
                {
                    cdvCusTargetValue.IsPopup = false;
                    return;
                }
                cdvCusTargetValue.InsertEmptyRow(0, 1);
            }
        }

        #endregion

        #region " Spec Attribute Tab Event "

        private void btnCharRefresh4_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(lisAssignedChar4, true);
            if (MPCF.Trim(sSelectedSpecID) != "" && MPCF.ToInt(txtSpecVersion.Text) > 0)
            {
                SPMLIST.ViewSpecCharacterList(lisAssignedChar4, '1', sSelectedSpecID, MPCF.Trim(txtSpecVersion.Text), true);
            }
        }

        private void lisAssignedChar4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisAssignedChar4.SelectedIndices.Count > 0)
            {
                string sCharID = MPCF.Trim(lisAssignedChar4.SelectedItems[0].Text);
                if (MPCF.Trim(sCharID) != String.Empty)
                {
                    sLastSelectedCharID2 = sCharID;
                    ViewAttributeValueForUpdate(sCharID);
                }
            }
        }

        private void grpAttr_Resize(object sender, EventArgs e)
        {
            MPCF.FitColumnHeader(spdAttr, (int)ATTR_COL.OLD_VALUE, (int)ATTR_COL.NEW_VALUE);
        }

        private void spdAttr_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column < (int)ATTR_COL.NEW_VALUE) return;

            spdAttr.ActiveSheet.Cells[e.Row, (int)ATTR_COL.CHECK].Value = true;
        }

        private void spdAttr_EnterCell(object sender, FarPoint.Win.Spread.EnterCellEventArgs e)
        {
            if (e.Column < (int)ATTR_COL.NEW_VALUE || e.Column == (int)ATTR_COL.CHECK) return;

            if (MPCF.Trim(sSelectedSpecID) == "" || MPCF.ToInt(txtSpecVersion.Text) == 0 || lisAssignedChar4.SelectedItems.Count == 0) return;

            if (MPCF.Trim(spdAttr.ActiveSheet.Cells[e.Row, (int)ATTR_COL.NEW_VALUE].Tag) == "Y")
            {
                Miracom.BASCore.frmBASTranAttributeDetail f = new frmBASTranAttributeDetail();
                f.AttributeKey = MPGC.MP_ATTR_TYPE_SPEC;
                f.SpecID = sSelectedSpecID;
                f.SpecVersion = MPCF.ToInt(txtSpecVersion.Text);
                f.CharID = lisAssignedChar4.SelectedItems[0].Text;
                f.AttributeName = MPCF.Trim(spdAttr.ActiveSheet.Cells[e.Row, (int)ATTR_COL.ATTR_NAME].Value);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    spdAttr.ActiveSheet.Cells[e.Row, (int)ATTR_COL.NEW_VALUE].Value = f.AttributeValue;
                    spdAttr.ActiveSheet.Cells[e.Row, (int)ATTR_COL.CHECK].Value = true;
                    spdAttr.ActiveSheet.Rows[e.Row].Height = spdAttr.ActiveSheet.GetPreferredRowHeight(e.Row);
                }

                if (f.IsDisposed == false) f.Dispose();
            }
        }

        private void spdAttr_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column == (int)ATTR_COL.NULL)
                {
                    spdAttr.ActiveSheet.Cells[e.Row, (int)ATTR_COL.CHECK].Value = true;

                    if (Convert.ToBoolean(spdAttr.ActiveSheet.Cells[e.Row, (int)ATTR_COL.NULL].Value) == true)
                    {
                        spdAttr.ActiveSheet.Cells[e.Row, (int)ATTR_COL.NEW_VALUE].Value = "[Null]";
                        spdAttr.ActiveSheet.Cells[e.Row, (int)ATTR_COL.NEW_VALUE].Locked = true;
                        spdAttr.ActiveSheet.Cells[e.Row, (int)ATTR_COL.NEW_VALUE_BTN].Locked = true;
                    }
                    else
                    {
                        spdAttr.ActiveSheet.Cells[e.Row, (int)ATTR_COL.NEW_VALUE].Value = "";
                        spdAttr.ActiveSheet.Cells[e.Row, (int)ATTR_COL.NEW_VALUE].Locked = false;
                        spdAttr.ActiveSheet.Cells[e.Row, (int)ATTR_COL.NEW_VALUE_BTN].Locked = false;
                    }
                    return;
                }

                cdvData.Init();
                cdvData.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvData.GetListView);
                cdvData.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
                cdvData.Columns.Add("Table Desc", 50, HorizontalAlignment.Left);

                BASLIST.ViewGCMDataList(cdvData.GetListView, '1', MPCF.Trim(spdAttr.ActiveSheet.Cells[e.Row, e.Column].Tag));

                if (MPCF.ToChar(spdAttr.ActiveSheet.Cells[e.Row, (int)ATTR_COL.OLD_VALUE].Tag) == 'Y')
                    cdvData.AddEmptyRow(1);

                if (cdvData.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvData_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            spdAttr.ActiveSheet.Cells[e.Row, (int)ATTR_COL.NEW_VALUE].Value = MPCF.Trim(e.SelectedItem.Text);
            spdAttr.ActiveSheet.Cells[e.Row, (int)ATTR_COL.CHECK].Value = true;
        }

        #endregion

        #region " Document and image Tab Event "

        private void btnCharRefresh5_Click(object sender, EventArgs e)
        {
            MPCF.ClearList(lisAssignedChar5, true);
            if (MPCF.Trim(sSelectedSpecID) != "" && MPCF.ToInt(txtSpecVersion.Text) > 0)
            {
                SPMLIST.ViewSpecCharacterList(lisAssignedChar5, '1', sSelectedSpecID, MPCF.Trim(txtSpecVersion.Text), true);
            }
        }

        private void lisAssignedChar5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisAssignedChar5.SelectedIndices.Count > 0)
            {
                string sCharID = MPCF.Trim(lisAssignedChar5.SelectedItems[0].Text);
                if (MPCF.Trim(sCharID) != String.Empty)
                {
                    sLastSelectedCharID3 = sCharID;
                    if (ViewCharacterAttachOption(sCharID) == false) return;
                    if (ViewCharacterAttachFile('1', sCharID, "") == false) return;

                    // Add by DM KIM 2013.08.27 
                    //bImgUpdateFlag = false;
                }
            }
        }

        private void cdvFile_TextBoxTextChanged(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;

            try
            {
                cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;
                if (MPCF.Trim(cdvTemp.Text) == "")
                {
                    cdvTemp.Tag = null;
                    cdvTemp.GetTextBox.Tag = "D";
                    if (cdvTemp.Name.StartsWith("cdvImg"))
                    {
                        if (cdvTemp.Name.EndsWith("1"))
                            picImg1.Image = null;
                        else if (cdvTemp.Name.EndsWith("2"))
                            picImg2.Image = null;
                        else if (cdvTemp.Name.EndsWith("3"))
                            picImg3.Image = null;
                    }

                    // Add by DM KIM 2013.08.27 
                    //bImgUpdateFlag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvFile_ButtonPress(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            FileInfo finfo;
            BinaryReader br;
            byte[] file_buffer;

            if (CheckCondition("FILE_CHECK", '1') == false) return;

            try
            {
                ofdFile.Filter = "All File(*.*)|*.*";
                ofdFile.FileName = "";

                if (ofdFile.ShowDialog() == DialogResult.OK)
                {
                    finfo = new FileInfo(ofdFile.FileName);
                    if (finfo.Exists == true)
                    {
                        cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

                        br = new BinaryReader(finfo.OpenRead());
                        file_buffer = br.ReadBytes((int)finfo.Length);
                        cdvTemp.Tag = file_buffer;
                        br.Close();

                        cdvTemp.GetTextBox.Tag = 'U';
                        cdvTemp.Text = finfo.Name;

                        // Add by DM KIM 2013.08.27 
                        //bImgUpdateFlag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvImg_ButtonPress(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            FileInfo finfo;
            BinaryReader br;
            byte[] file_buffer;

            if (CheckCondition("FILE_CHECK", '1') == false) return;

            try
            {
                ofdFile.Filter = "All File(*.*)|*.*";
                ofdFile.FileName = "";

                if (ofdFile.ShowDialog() == DialogResult.OK)
                {
                    finfo = new FileInfo(ofdFile.FileName);
                    if (finfo.Exists == true)
                    {
                        cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

                        if (cdvTemp.Name.EndsWith("1"))
                        {
                            picImg1.Image = Image.FromFile(ofdFile.FileName);
                        }
                        else if (cdvTemp.Name.EndsWith("2"))
                        {
                            picImg2.Image = Image.FromFile(ofdFile.FileName);
                        }
                        else if (cdvTemp.Name.EndsWith("3"))
                        {
                            picImg3.Image = Image.FromFile(ofdFile.FileName);
                        }

                        br = new BinaryReader(finfo.OpenRead());
                        file_buffer = br.ReadBytes((int)finfo.Length);
                        cdvTemp.Tag = file_buffer;
                        br.Close();

                        cdvTemp.GetTextBox.Tag = 'U';
                        cdvTemp.Text = finfo.Name;


                        // Add by DM KIM 2013.08.28 
                        //bImgUpdateFlag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            Button btnTemp = (Button)sender;
            string sFileName = "";

            if (CheckCondition("FILE_CHECK", '1') == false) return;

            if (btnTemp.Name.EndsWith("1"))
            {
                sFileName = MPCF.Trim(cdvDoc1.Text);
            }
            else if (btnTemp.Name.EndsWith("2"))
            {
                sFileName = MPCF.Trim(cdvDoc2.Text);
            }
            else if (btnTemp.Name.EndsWith("3"))
            {
                sFileName = MPCF.Trim(cdvDoc3.Text);
            }
            else if (btnTemp.Name.EndsWith("4"))
            {
                sFileName = MPCF.Trim(cdvDoc4.Text);
            }
            else if (btnTemp.Name.EndsWith("5"))
            {
                sFileName = MPCF.Trim(cdvDoc5.Text);
            }

            if (sFileName != "")
            {
                ViewCharacterAttachFile('1', sLastSelectedCharID3, sFileName);
            }
        }

        private void chkUseTargetToFile_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseTargetToFile.Checked == true)
            {
                txtFileExt.ReadOnly = false;
                chkUseLatestFileVersion.Enabled = true;
                btnViewSpecFile.Enabled = true;
            }
            else
            {
                txtFileExt.Text = "";
                chkUseLatestFileVersion.Checked = false;

                txtFileExt.ReadOnly = true;
                chkUseLatestFileVersion.Enabled = false;
                btnViewSpecFile.Enabled = false;
            }
        }

        private void btnViewSpecFile_Click(object sender, EventArgs e)
        {
            ViewCharacterAttachFile('2', sLastSelectedCharID3, "");
        }

        private void cdvFile_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
             
            try
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    e.Handled = true;
                    cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;
                    cdvTemp.Text = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        #endregion

        #region " Copy Tab Event "

        private void cdvToMaterial_MaterialButtonPress(object sender, EventArgs e)
        {
            cdvToMaterial.ListCond_StepMaterial = '1';
        }

        private void cdvToMaterial_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvToFlow.Text = "";
            cdvToOper.Text = "";
        }

        private void cdvToFlow_ButtonPress(object sender, System.EventArgs e)
        {
            if (MPCF.Trim(cdvToMaterial.Text) != "")
            {
                cdvToFlow.ListCond_Step = '2';
                cdvToFlow.ListCond_MatID = cdvToMaterial.Text;
                cdvToFlow.ListCond_MatVersion = cdvToMaterial.Version;
            }
            else
            {
                cdvToFlow.ListCond_Step = '1';
                cdvToFlow.ListCond_MatID = "";
                cdvToFlow.ListCond_MatVersion = 0;
            }
        }

        private void cdvToFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvToOper.Text = "";
        }

        private void cdvToOper_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvToFlow.Text) != "")
            {
                cdvToOper.ListCond_Step = '2';
                cdvToOper.ListCond_Flow = cdvToFlow.Text;
            }
            else
            {
                cdvToOper.ListCond_Step = '1';
                cdvToOper.ListCond_Flow = "";
            }
        }

        private void cdvToVer_ButtonPress(object sender, EventArgs e)
        {
            string sTempSpecID = "";

            cdvToVer.Init();
            MPCF.InitListView(cdvToVer.GetListView);

            if (MPCF.Trim(cdvToMaterial.Text) == "" && MPCF.Trim(cdvToFlow.Text) == "" && MPCF.Trim(cdvToOper.Text) == "") return;

            cdvToVer.Columns.Add("Version", 50, HorizontalAlignment.Left);
            cdvToVer.SelectedSubItemIndex = 0;
            SPMLIST.ViewSpecVersionListByMFO(cdvToVer.GetListView, MPCF.Trim(cdvToMaterial.Text), cdvToMaterial.Version, MPCF.Trim(cdvToFlow.Text), MPCF.Trim(cdvToOper.Text), null, "", ref sTempSpecID);
        }

        private void btnCopySpec_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvToVer, 2) == false)
            {
                tabSpec.SelectedTab = tbpCopy;
                return;
            }
            if (CopySpecVersion('1'))
            {
                sLastSelectedVersion = lisSpecVersion.SelectedItems.Count > 0 ? lisSpecVersion.SelectedItems[0].Text : "";
                sLastSelectedCharID1 = lisAssignedChar3.SelectedItems.Count > 0 ? lisAssignedChar3.SelectedItems[0].Text : "";
                sLastSelectedCharID2 = lisAssignedChar4.SelectedItems.Count > 0 ? lisAssignedChar4.SelectedItems[0].Text : "";
                sLastSelectedCharID3 = lisAssignedChar5.SelectedItems.Count > 0 ? lisAssignedChar5.SelectedItems[0].Text : "";
                btnRefresh.PerformClick();
                return;
            }
        }

        #endregion

    }
}
