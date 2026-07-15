//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPSetupMFOOption.vb
//   Description : MFO Option Prompt/Definition Setup/View
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - ViewOptionPrompt() : View table which is included in one factory
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2007-11-27 : Created by Kenneth
//       - 2008-01-16 : Modified by W.Y.Choi
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPSetupMFOOption : Miracom.MESCore.SetupForm01
    {
        public frmWIPSetupMFOOption()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private const int KEY_MAX_LENGTH = 30;
        private const int DATA_MAX_LENGTH = 50;

        #endregion

        #region " Variable Definition "

        private bool bLoadFlag;
        private FarPoint.Win.Spread.FpSpread lspdTable;

        public struct OptionDefFormat
        {
            public char cFmt;
            public char cOpt;
        };

        OptionDefFormat[] KeyChr = new OptionDefFormat[5];
        OptionDefFormat[] DataChr = new OptionDefFormat[20];

        #endregion

        #region " Function Definition "

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal Proc_step As String : Process Step
        //
        private bool CheckCondition(char c_step)
        {
            int i;
            int j;

            switch (c_step)
            {
                case MPGC.MP_STEP_CREATE:
                case MPGC.MP_STEP_UPDATE:
                    switch (tabOption.SelectedIndex)
                    {
                        case 0:
                            if (MPCF.CheckValue(txtOptionName, 1) == false) return false;

                            for (i = 0; i < 5; i++)
                            {
                                if ( !((MPCF.Trim(spdKey.ActiveSheet.GetValue(i, 0)) == "" && MPCF.Trim(spdKey.ActiveSheet.GetValue(i, 1)) == "" && MPCF.Trim(spdKey.ActiveSheet.GetValue(i, 2)) == "") ||
                                       (MPCF.Trim(spdKey.ActiveSheet.GetValue(i, 0)) != "" && MPCF.Trim(spdKey.ActiveSheet.GetValue(i, 1)) != "" && MPCF.Trim(spdKey.ActiveSheet.GetValue(i, 2)) != "")) )
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(256));
                                    spdKey.ActiveSheet.SetActiveCell(i, 0);
                                    return false;
                                }
                            }

                            for (i = 0; i < 20; i++)
                            {
                                if ( !((MPCF.Trim(spdData.ActiveSheet.GetValue(i, 0)) == "" && MPCF.Trim(spdData.ActiveSheet.GetValue(i, 1)) == "" && MPCF.Trim(spdData.ActiveSheet.GetValue(i, 2)) == "") ||
                                       (MPCF.Trim(spdData.ActiveSheet.GetValue(i, 0)) != "" && MPCF.Trim(spdData.ActiveSheet.GetValue(i, 1)) != "" && MPCF.Trim(spdData.ActiveSheet.GetValue(i, 2)) != "")))
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(257));
                                    spdData.ActiveSheet.SetActiveCell(i, 0);
                                    return false;
                                }
                            }
                            break;

                        case 1:

                            if (MPCF.CheckValue(cdvOptionName, 1) == false) return false;

                            switch (tabMFO_RES.SelectedIndex)
                            {
                                case 0:
                                    if (tvMFO.SelectedItem == Miracom.MESCore.Controls.TreeSelectedItem.None)
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(264));
                                        return false;
                                    }
                                    break;
                                case 1:
                                    if (tvRes.SelectedItem == Miracom.MESCore.Controls.TreeSelectedItem.None)
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                                        return false;
                                    }
                                    else
                                    {
                                        if (MPCF.Trim(tvRes.Resource) == "" && MPCF.Trim(tvRes.ResourceGroup) == "" && MPCF.Trim(tvRes.ResourceType) == "")
                                        {
                                            MPCF.ShowMsgBox(MPCF.GetMessage(274));
                                            return false;
                                        }
                                    }
                                    break;
                            }

                            for (i = 0; i < 5; i++)
                            {
                                if (CheckAllKeyOptFmt(i, KeyChr[i].cOpt, KeyChr[i].cFmt) == false) return false;
                            }

                            for (i = 0; i < 20; i++)
                            {
                                if (CheckAllDataOptFmt(i, DataChr[i].cOpt, DataChr[i].cFmt) == false) return false;
                            }

                            break;

                        case 2:

                            bool bCheck = false;
                            
                            for (i = 0; i < spdOptionList.ActiveSheet.RowCount; i++)
                            {
                                if (spdOptionList.ActiveSheet.GetValue(i, 0).Equals(true))
                                {
                                    for (j = 4; j <= 52; j += 2)
                                    {
                                        if (MPCF.Trim(spdOptionList.ActiveSheet.GetTag(i, j)) == "Y")
                                        {
                                            if (MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, j)) == "")
                                            {
                                                if (j < 14)
                                                    MPCF.ShowMsgBox(MPCF.GetMessage(108) + " - KEY_" + ((int)((j / 2) - 1)).ToString());
                                                else
                                                    MPCF.ShowMsgBox(MPCF.GetMessage(108) + " - DATA_" + ((int)((j / 2) - 6)).ToString());

                                                spdOptionList.ActiveSheet.SetActiveCell(i, j);
                                                spdOptionList.Focus();
                                                return false;
                                            }
                                        }
                                    }

                                    bCheck = true;
                                }
                            }

                            if (!bCheck)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(133));
                                return false;
                            }

                            break;
                    }
                    break;

                case MPGC.MP_STEP_DELETE:
                    switch (tabOption.SelectedIndex)
                    {
                        case 0:
                            if (MPCF.CheckValue(txtOptionName, 1) == false)
                                return false;
                            break;
                        case 1:
                            switch (tabMFO_RES.SelectedIndex)
                            {
                                case 0:
                                    if (tvMFO.SelectedItem == Miracom.MESCore.Controls.TreeSelectedItem.None)
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(264));
                                        return false;
                                    }
                                    break;
                                case 1:
                                    if (tvRes.SelectedItem == Miracom.MESCore.Controls.TreeSelectedItem.None)
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                                        return false;
                                    }
                                    else
                                    {
                                        if (MPCF.Trim(tvRes.Resource) == "" && MPCF.Trim(tvRes.ResourceGroup) == "" && MPCF.Trim(tvRes.ResourceType) == "")
                                        {
                                            MPCF.ShowMsgBox(MPCF.GetMessage(274));
                                            return false;
                                        }
                                    }
                                    break;
                            }
                            break;
                        case 2:
                            bool bCheck = false;

                            for (i = 0; i < spdOptionList.ActiveSheet.RowCount; i++)
                            {
                                if (spdOptionList.ActiveSheet.GetValue(i, 0).Equals(true))
                                {
                                    bCheck = true;
                                }
                            }

                            if (!bCheck)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(133));
                                return false;
                            }

                            break;
                    }
                    break;
            }
            return true;
        }

        private void ClearData(char cType)
        {
            switch (cType)
            {
                case '1':   // TAB 0
                    txtOptionName.Text = txtOptionDescPrompt.Text = "";
                    txtPMTCreateUser.Text = txtPMTCreateTime.Text = "";
                    txtPMTUpdateUser.Text = txtPMTUpdateTime.Text = "";
                    cdvGCMTableList.Text = "";
                    spdKey.ActiveSheet.ClearRange(0, 0, 5, 4, true);
                    spdData.ActiveSheet.ClearRange(0, 0, 20, 4, true);
                    break;
                case '2':   // TAB 1
                    nudOptionSeq.Value = 0;
                    cdvOptionName.Text = txtOptionDescDefinition.Text = "";
                    txtDEFCreateUser.Text = txtDEFCreateTime.Text = "";
                    txtDEFUpdateUser.Text = txtDEFUpdateTime.Text = "";
                    cdvKey1.Text = cdvKey2.Text = cdvKey3.Text = cdvKey4.Text = cdvKey5.Text = "";
                    cdvData1.Text = cdvData11.Text = cdvData2.Text = cdvData12.Text = "";
                    cdvData3.Text = cdvData13.Text = cdvData4.Text = cdvData14.Text = "";
                    cdvData5.Text = cdvData15.Text = cdvData6.Text = cdvData16.Text = "";
                    cdvData7.Text = cdvData17.Text = cdvData8.Text = cdvData18.Text = "";
                    cdvData9.Text = cdvData19.Text = cdvData10.Text = cdvData20.Text = "";

                    lblKey1.Visible = cdvKey1.Visible = lblKey2.Visible = cdvKey2.Visible = false;
                    lblKey3.Visible = cdvKey3.Visible = lblKey4.Visible = cdvKey4.Visible = false;
                    lblKey5.Visible = cdvKey5.Visible = false;
                    lblData1.Visible = cdvData1.Visible = lblData2.Visible = cdvData2.Visible = false;
                    lblData3.Visible = cdvData3.Visible = lblData4.Visible = cdvData4.Visible = false;
                    lblData5.Visible = cdvData5.Visible = lblData6.Visible = cdvData6.Visible = false;
                    lblData7.Visible = cdvData7.Visible = lblData8.Visible = cdvData8.Visible = false;
                    lblData9.Visible = cdvData9.Visible = lblData10.Visible = cdvData10.Visible = false;
                    lblData11.Visible = cdvData11.Visible = lblData12.Visible = cdvData12.Visible = false;
                    lblData13.Visible = cdvData13.Visible = lblData14.Visible = cdvData14.Visible = false;
                    lblData15.Visible = cdvData15.Visible = lblData16.Visible = cdvData16.Visible = false;
                    lblData17.Visible = cdvData17.Visible = lblData18.Visible = cdvData18.Visible = false;
                    lblData19.Visible = cdvData19.Visible = lblData20.Visible = cdvData20.Visible = false;

                    lblKey1.Font = lblKey2.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblKey3.Font = lblKey4.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblKey5.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblData1.Font = lblData2.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblData3.Font = lblData4.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblData5.Font = lblData6.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblData7.Font = lblData8.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblData9.Font = lblData10.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblData11.Font = lblData12.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblData13.Font = lblData14.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblData15.Font = lblData16.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblData17.Font = lblData18.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblData19.Font = lblData20.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);

                    break;
                case '3':   // TAB 0
                    MPCF.InitListView((ListView)lisOption);
                    break;
                case '4':   // TAB 1
                    MPCF.ClearList(tvMFO.GetTreeView);
                    break;
                case '5':   // TAB 1
                    lblKey1.Visible = cdvKey1.Visible = lblKey2.Visible = cdvKey2.Visible = false;
                    lblKey3.Visible = cdvKey3.Visible = lblKey4.Visible = cdvKey4.Visible = false;
                    lblKey5.Visible = cdvKey5.Visible = false;
                    lblData1.Visible = cdvData1.Visible = lblData2.Visible = cdvData2.Visible = false;
                    lblData3.Visible = cdvData3.Visible = lblData4.Visible = cdvData4.Visible = false;
                    lblData5.Visible = cdvData5.Visible = lblData6.Visible = cdvData6.Visible = false;
                    lblData7.Visible = cdvData7.Visible = lblData8.Visible = cdvData8.Visible = false;
                    lblData9.Visible = cdvData9.Visible = lblData10.Visible = cdvData10.Visible = false;
                    lblData11.Visible = cdvData11.Visible = lblData12.Visible = cdvData12.Visible = false;
                    lblData13.Visible = cdvData13.Visible = lblData14.Visible = cdvData14.Visible = false;
                    lblData15.Visible = cdvData15.Visible = lblData16.Visible = cdvData16.Visible = false;
                    lblData17.Visible = cdvData17.Visible = lblData18.Visible = cdvData18.Visible = false;
                    lblData19.Visible = cdvData19.Visible = lblData20.Visible = cdvData20.Visible = false;
                    break;
                case '6':   // TAB 2
                    MPCF.ClearList(tvMFOList.GetListView);
                    MPCF.ClearList(spdOptionList);
                    break;
                case '7':   // TAB 1
                    nudOptionSeq.Value = 0;
                    txtDEFCreateUser.Text = txtDEFCreateTime.Text = "";
                    txtDEFUpdateUser.Text = txtDEFUpdateTime.Text = "";

                    lblKey1.Text = "Key 1";
                    lblKey2.Text = "Key 2";
                    lblKey3.Text = "Key 3";
                    lblKey4.Text = "Key 4";
                    lblKey5.Text = "Key 5";
                    lblData1.Text = "Data 1";
                    lblData2.Text = "Data 2";
                    lblData3.Text = "Data 3";
                    lblData4.Text = "Data 4";
                    lblData5.Text = "Data 5";
                    lblData6.Text = "Data 6";
                    lblData7.Text = "Data 7";
                    lblData8.Text = "Data 8";
                    lblData9.Text = "Data 9";
                    lblData10.Text = "Data 10";
                    lblData11.Text = "Data 11";
                    lblData12.Text = "Data 12";
                    lblData13.Text = "Data 13";
                    lblData14.Text = "Data 14";
                    lblData15.Text = "Data 15";
                    lblData16.Text = "Data 16";
                    lblData17.Text = "Data 17";
                    lblData18.Text = "Data 18";
                    lblData19.Text = "Data 19";
                    lblData20.Text = "Data 20";

                    cdvKey1.Text = cdvKey2.Text = cdvKey3.Text = cdvKey4.Text = cdvKey5.Text = "";
                    cdvData1.Text = cdvData11.Text = cdvData2.Text = cdvData12.Text = "";
                    cdvData3.Text = cdvData13.Text = cdvData4.Text = cdvData14.Text = "";
                    cdvData5.Text = cdvData15.Text = cdvData6.Text = cdvData16.Text = "";
                    cdvData7.Text = cdvData17.Text = cdvData8.Text = cdvData18.Text = "";
                    cdvData9.Text = cdvData19.Text = cdvData10.Text = cdvData20.Text = "";

                    cdvKey1.VisibleButton = cdvKey2.VisibleButton = cdvKey3.VisibleButton = false;
                    cdvKey4.VisibleButton = cdvKey5.VisibleButton = false;
                    cdvData1.VisibleButton = cdvData2.VisibleButton = cdvData3.VisibleButton = false;
                    cdvData4.VisibleButton = cdvData5.VisibleButton = cdvData6.VisibleButton = false;
                    cdvData7.VisibleButton = cdvData8.VisibleButton = cdvData9.VisibleButton = false;
                    cdvData10.VisibleButton = cdvData11.VisibleButton = cdvData12.VisibleButton = false;
                    cdvData13.VisibleButton = cdvData14.VisibleButton = cdvData15.VisibleButton = false;
                    cdvData16.VisibleButton = cdvData17.VisibleButton = cdvData18.VisibleButton = false;
                    cdvData19.VisibleButton = cdvData20.VisibleButton = false;

                    cdvKey1.ReadOnly = cdvKey2.ReadOnly = cdvKey3.ReadOnly = false;
                    cdvKey4.ReadOnly = cdvKey5.ReadOnly = false;
                    cdvData1.ReadOnly = cdvData2.ReadOnly = cdvData3.ReadOnly = false;
                    cdvData4.ReadOnly = cdvData5.ReadOnly = cdvData6.ReadOnly = false;
                    cdvData7.ReadOnly = cdvData8.ReadOnly = cdvData9.ReadOnly = false;
                    cdvData10.ReadOnly = cdvData11.ReadOnly = cdvData12.ReadOnly = false;
                    cdvData13.ReadOnly = cdvData14.ReadOnly = cdvData15.ReadOnly = false;
                    cdvData16.ReadOnly = cdvData17.ReadOnly = cdvData18.ReadOnly = false;
                    cdvData19.ReadOnly = cdvData20.ReadOnly = false;

                    cdvKey1.Tag = cdvKey2.Tag = cdvKey3.Tag = "";
                    cdvKey4.Tag = cdvKey5.Tag = "";
                    cdvData1.Tag = cdvData2.Tag = cdvData3.Tag = "";
                    cdvData4.Tag = cdvData5.Tag = cdvData6.Tag = "";
                    cdvData7.Tag = cdvData8.Tag = cdvData9.Tag = "";
                    cdvData10.Tag = cdvData11.Tag = cdvData12.Tag = "";
                    cdvData13.Tag = cdvData14.Tag = cdvData15.Tag = "";
                    cdvData16.Tag = cdvData17.Tag = cdvData18.Tag = "";
                    cdvData19.Tag = cdvData20.Tag = "";

                    lblKey1.Visible = cdvKey1.Visible = lblKey2.Visible = cdvKey2.Visible = true;
                    lblKey3.Visible = cdvKey3.Visible = lblKey4.Visible = cdvKey4.Visible = true;
                    lblKey5.Visible = cdvKey5.Visible = true;
                    lblData1.Visible = cdvData1.Visible = lblData2.Visible = cdvData2.Visible = true;
                    lblData3.Visible = cdvData3.Visible = lblData4.Visible = cdvData4.Visible = true;
                    lblData5.Visible = cdvData5.Visible = lblData6.Visible = cdvData6.Visible = true;
                    lblData7.Visible = cdvData7.Visible = lblData8.Visible = cdvData8.Visible = true;
                    lblData9.Visible = cdvData9.Visible = lblData10.Visible = cdvData10.Visible = true;
                    lblData11.Visible = cdvData11.Visible = lblData12.Visible = cdvData12.Visible = true;
                    lblData13.Visible = cdvData13.Visible = lblData14.Visible = cdvData14.Visible = true;
                    lblData15.Visible = cdvData15.Visible = lblData16.Visible = cdvData16.Visible = true;
                    lblData17.Visible = cdvData17.Visible = lblData18.Visible = cdvData18.Visible = true;
                    lblData19.Visible = cdvData19.Visible = lblData20.Visible = cdvData20.Visible = true;

                    lblKey1.Font = lblKey2.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblKey3.Font = lblKey4.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblKey5.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblData1.Font = lblData2.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblData3.Font = lblData4.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblData5.Font = lblData6.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblData7.Font = lblData8.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblData9.Font = lblData10.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblData11.Font = lblData12.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblData13.Font = lblData14.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblData15.Font = lblData16.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblData17.Font = lblData18.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblData19.Font = lblData20.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);

                    for (int i = 0; i < 5; i++)
                    {
                        KeyChr[i].cFmt = ' ';
                        KeyChr[i].cOpt = ' ';
                    }

                    for (int i = 0; i < 20; i++)
                    {
                        DataChr[i].cFmt = ' ';
                        DataChr[i].cOpt = ' ';
                    }

                    break;
            }
        }

        private void SetKeyOption(int iKey, TRSNode key_item)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvKey = null;
            Label lblKey = null;
            string strTableName = key_item.GetString("KEY_TBL");

            switch (iKey)
            {
                case 0: 
                    lblKey = lblKey1; 
                    cdvKey = cdvKey1; 
                    break;

                case 1: 
                    lblKey = lblKey2; 
                    cdvKey = cdvKey2; 
                    break;

                case 2: 
                    lblKey = lblKey3; 
                    cdvKey = cdvKey3; 
                    break;

                case 3: 
                    lblKey = lblKey4; 
                    cdvKey = cdvKey4; 
                    break;

                case 4: 
                    lblKey = lblKey5; 
                    cdvKey = cdvKey5; 
                    break;
            }

            lblKey.Text = key_item.GetString("KEY_PMT");

            if (key_item.GetChar("KEY_OPT") == 'Y')
            {
                lblKey.Font = new System.Drawing.Font(lblKey.Font, System.Drawing.FontStyle.Bold);
            }

            lblKey.Visible = cdvKey.Visible = true;
            cdvKey.Tag = key_item.GetChar("KEY_FMT") + strTableName;
            cdvKey.VisibleButton = (strTableName == "") ? false : true;

            if (cdvKey.VisibleButton == true)
                cdvKey.ReadOnly = true;
            else
                cdvKey.ReadOnly = false;

        }

        private void SetDataOption(int iData, TRSNode data_item)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvData = null;
            Label lblData = null;
            string strTableName = data_item.GetString("DATA_TBL");

            switch (iData)
            {
                case 0: 
                    lblData = lblData1; 
                    cdvData = cdvData1; 
                    break;

                case 1: 
                    lblData = lblData2; 
                    cdvData = cdvData2; 
                    break;

                case 2: 
                    lblData = lblData3; 
                    cdvData = cdvData3; 
                    break;

                case 3: 
                    lblData = lblData4; 
                    cdvData = cdvData4; 
                    break;

                case 4: 
                    lblData = lblData5; 
                    cdvData = cdvData5; 
                    break;

                case 5: 
                    lblData = lblData6; 
                    cdvData = cdvData6; 
                    break;

                case 6: 
                    lblData = lblData7; 
                    cdvData = cdvData7; 
                    break;

                case 7: 
                    lblData = lblData8; 
                    cdvData = cdvData8; 
                    break;

                case 8: 
                    lblData = lblData9; 
                    cdvData = cdvData9; 
                    break;

                case 9: 
                    lblData = lblData10; 
                    cdvData = cdvData10; 
                    break;

                case 10: 
                    lblData = lblData11; 
                    cdvData = cdvData11; 
                    break;

                case 11: 
                    lblData = lblData12; 
                    cdvData = cdvData12; 
                    break;

                case 12: 
                    lblData = lblData13; 
                    cdvData = cdvData13; 
                    break;

                case 13: 
                    lblData = lblData14; 
                    cdvData = cdvData14; 
                    break;

                case 14: 
                    lblData = lblData15; 
                    cdvData = cdvData15; 
                    break;

                case 15: 
                    lblData = lblData16; 
                    cdvData = cdvData16; 
                    break
                        ;
                case 16: 
                    lblData = lblData17; 
                    cdvData = cdvData17; 
                    break;

                case 17: 
                    lblData = lblData18; 
                    cdvData = cdvData18; 
                    break;

                case 18: 
                    lblData = lblData19; 
                    cdvData = cdvData19; 
                    break;

                case 19: 
                    lblData = lblData20; 
                    cdvData = cdvData20; 
                    break;
            }

            lblData.Text = data_item.GetString("DATA_PMT");
            if (data_item.GetChar("DATA_OPT") == 'Y')  
                lblData.Font = new System.Drawing.Font(lblData.Font, System.Drawing.FontStyle.Bold);

            lblData.Visible = cdvData.Visible = true;
            cdvData.Tag = data_item.GetChar("DATA_FMT") + strTableName;
            cdvData.VisibleButton = (strTableName == "") ? false : true;

            if (cdvData.VisibleButton == true)
                cdvData.ReadOnly = true;
            else
                cdvData.ReadOnly = false;

        }

        private bool CheckAllKeyOptFmt(int i, char cOpt, char cFmt)
        {
            if (cOpt == 'Y')
            {
                switch (i)
                {
                    case 0: if (MPCF.CheckValue(cdvKey1, 1) == false) return false; break;
                    case 1: if (MPCF.CheckValue(cdvKey2, 1) == false) return false; break;
                    case 2: if (MPCF.CheckValue(cdvKey3, 1) == false) return false; break;
                    case 3: if (MPCF.CheckValue(cdvKey4, 1) == false) return false; break;
                    case 4: if (MPCF.CheckValue(cdvKey5, 1) == false) return false; break;
                }
            }
            if (cFmt == 'N' || cFmt == 'F')
            {
                switch (i)
                {
                    case 0: if (MPCF.CheckFormat(KeyChr[i].cFmt, cdvKey1) == false) return false; break;
                    case 1: if (MPCF.CheckFormat(KeyChr[i].cFmt, cdvKey2) == false) return false; break;
                    case 2: if (MPCF.CheckFormat(KeyChr[i].cFmt, cdvKey3) == false) return false; break;
                    case 3: if (MPCF.CheckFormat(KeyChr[i].cFmt, cdvKey4) == false) return false; break;
                    case 4: if (MPCF.CheckFormat(KeyChr[i].cFmt, cdvKey5) == false) return false; break;
                }
            }
            return true;
        }

        private bool CheckAllDataOptFmt(int i, char cOpt, char cFmt)
        {
             if (cOpt == 'Y')
            {
                switch (i)
                {
                    case 0: if (MPCF.CheckValue(cdvData1, 1) == false) return false; break;
                    case 1: if (MPCF.CheckValue(cdvData2, 1) == false) return false; break;
                    case 2: if (MPCF.CheckValue(cdvData3, 1) == false) return false; break;
                    case 3: if (MPCF.CheckValue(cdvData4, 1) == false) return false; break;
                    case 4: if (MPCF.CheckValue(cdvData5, 1) == false) return false; break;
                    case 5: if (MPCF.CheckValue(cdvData6, 1) == false) return false; break;
                    case 6: if (MPCF.CheckValue(cdvData7, 1) == false) return false; break;
                    case 7: if (MPCF.CheckValue(cdvData8, 1) == false) return false; break;
                    case 8: if (MPCF.CheckValue(cdvData9, 1) == false) return false; break;
                    case 9: if (MPCF.CheckValue(cdvData10, 1) == false) return false; break;
                    case 10: if (MPCF.CheckValue(cdvData11, 1) == false) return false; break;
                    case 11: if (MPCF.CheckValue(cdvData12, 1) == false) return false; break;
                    case 12: if (MPCF.CheckValue(cdvData13, 1) == false) return false; break;
                    case 13: if (MPCF.CheckValue(cdvData14, 1) == false) return false; break;
                    case 14: if (MPCF.CheckValue(cdvData15, 1) == false) return false; break;
                    case 15: if (MPCF.CheckValue(cdvData16, 1) == false) return false; break;
                    case 16: if (MPCF.CheckValue(cdvData17, 1) == false) return false; break;
                    case 17: if (MPCF.CheckValue(cdvData18, 1) == false) return false; break;
                    case 18: if (MPCF.CheckValue(cdvData19, 1) == false) return false; break;
                    case 19: if (MPCF.CheckValue(cdvData20, 1) == false) return false; break;
                }
            }

            if (cFmt == 'N' || cFmt == 'F')
            {
                switch (i)
                {
                    case 0: if (MPCF.CheckFormat(DataChr[i].cFmt, cdvData1) == false) return false; break;
                    case 1: if (MPCF.CheckFormat(DataChr[i].cFmt, cdvData2) == false) return false; break;
                    case 2: if (MPCF.CheckFormat(DataChr[i].cFmt, cdvData3) == false) return false; break;
                    case 3: if (MPCF.CheckFormat(DataChr[i].cFmt, cdvData4) == false) return false; break;
                    case 4: if (MPCF.CheckFormat(DataChr[i].cFmt, cdvData5) == false) return false; break;
                    case 5: if (MPCF.CheckFormat(DataChr[i].cFmt, cdvData6) == false) return false; break;
                    case 6: if (MPCF.CheckFormat(DataChr[i].cFmt, cdvData7) == false) return false; break;
                    case 7: if (MPCF.CheckFormat(DataChr[i].cFmt, cdvData8) == false) return false; break;
                    case 8: if (MPCF.CheckFormat(DataChr[i].cFmt, cdvData9) == false) return false; break;
                    case 9: if (MPCF.CheckFormat(DataChr[i].cFmt, cdvData10) == false) return false; break;
                    case 10: if (MPCF.CheckFormat(DataChr[i].cFmt, cdvData11) == false) return false; break;
                    case 11: if (MPCF.CheckFormat(DataChr[i].cFmt, cdvData12) == false) return false; break;
                    case 12: if (MPCF.CheckFormat(DataChr[i].cFmt, cdvData13) == false) return false; break;
                    case 13: if (MPCF.CheckFormat(DataChr[i].cFmt, cdvData14) == false) return false; break;
                    case 14: if (MPCF.CheckFormat(DataChr[i].cFmt, cdvData15) == false) return false; break;
                    case 15: if (MPCF.CheckFormat(DataChr[i].cFmt, cdvData16) == false) return false; break;
                    case 16: if (MPCF.CheckFormat(DataChr[i].cFmt, cdvData17) == false) return false; break;
                    case 17: if (MPCF.CheckFormat(DataChr[i].cFmt, cdvData18) == false) return false; break;
                    case 18: if (MPCF.CheckFormat(DataChr[i].cFmt, cdvData19) == false) return false; break;
                    case 19: if (MPCF.CheckFormat(DataChr[i].cFmt, cdvData20) == false) return false; break;
                }
            }
            return true;
       }

        //
        // View_Table()
        //       - View General Code Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewOptionPrompt(char c_step, string strOptionName)
        {
            TRSNode in_node = new TRSNode("VIEW_MFO_OPTION_PROMPT_IN");
            TRSNode out_node = new TRSNode("VIEW_MFO_OPTION_PROMPT_OUT");
            List<TRSNode> node_list;
            int i;

            try
            {
                ClearData(c_step);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("OPTION_NAME", MPCF.Trim(strOptionName));

                if (MPCR.CallService("WIP", "WIP_View_MFO_Option_Prompt", in_node, ref out_node, true) == false)
                {
                    if (c_step == '2' && out_node.MsgCode == "WIP-0334")
                    {
                        ClearData('7');
                        return true;
                    }

                    MPCR.CheckContinueProc(out_node);
                    return false;
                }


                switch (c_step)
                {
                    case '1':
                        txtOptionName.Text = out_node.GetString("OPTION_NAME");
                        txtOptionDescPrompt.Text = out_node.GetString("OPTION_DESC");
                        chkSysPmtFlag.Checked = (out_node.GetChar("SYS_PMT_FLAG") == 'Y' ? true : false);
                        txtPMTCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                        txtPMTCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                        txtPMTUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                        txtPMTUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                        node_list = out_node.GetList("KEY_LIST");
                        for (i = 0; i < node_list.Count; i++)
                        {
                            spdKey.ActiveSheet.SetValue(i, 0, node_list[i].GetString("KEY_PMT"));
                            spdKey.ActiveSheet.SetValue(i, 1, node_list[i].GetChar("KEY_OPT"));
                            switch (node_list[i].GetChar("KEY_FMT"))
                            {
                                case 'A':
                                    spdKey.ActiveSheet.SetValue(i, 2, "Ascii");
                                    break;
                                case 'N':
                                    spdKey.ActiveSheet.SetValue(i, 2, "Number");
                                    break;
                                case 'F':
                                    spdKey.ActiveSheet.SetValue(i, 2, "Float");
                                    break;
                            }

                            spdKey.ActiveSheet.SetValue(i, 3, node_list[i].GetString("KEY_TBL"));
                        }

                        node_list = out_node.GetList("DATA_LIST");
                        for (i = 0; i < node_list.Count; i++)
                        {
                            spdData.ActiveSheet.SetValue(i, 0, node_list[i].GetString("DATA_PMT"));
                            spdData.ActiveSheet.SetValue(i, 1, node_list[i].GetChar("DATA_OPT"));
                            switch (node_list[i].GetChar("DATA_FMT"))
                            {
                                case 'A':
                                    spdData.ActiveSheet.SetValue(i, 2, "Ascii");
                                    break;
                                case 'N':
                                    spdData.ActiveSheet.SetValue(i, 2, "Number");
                                    break;
                                case 'F':
                                    spdData.ActiveSheet.SetValue(i, 2, "Float");
                                    break;
                            }

                            spdData.ActiveSheet.SetValue(i, 3, node_list[i].GetString("DATA_TBL"));
                        }
                        break;

                    case '2':

                        cdvOptionName.Text = out_node.GetString("OPTION_NAME");
                        txtOptionDescDefinition.Text = out_node.GetString("OPTION_DESC");

                        
                        ClearData('5');

                        node_list = out_node.GetList("KEY_LIST");
                        for (i = 0; i < node_list.Count; i++)
                        {
                            if (node_list[i].GetString("KEY_PMT") != "" && 
                                node_list[i].GetChar("KEY_OPT") != ' ' && 
                                node_list[i].GetChar("KEY_FMT") != ' ')
                                SetKeyOption(i, node_list[i]);

                            KeyChr[i].cFmt = node_list[i].GetChar("KEY_FMT");
                            KeyChr[i].cOpt = node_list[i].GetChar("KEY_OPT");
                        }

                        node_list = out_node.GetList("DATA_LIST");
                        for (i = 0; i < node_list.Count; i++)
                        {
                            if (node_list[i].GetString("DATA_PMT") != "" &&
                                node_list[i].GetChar("DATA_OPT") != ' ' &&
                                node_list[i].GetChar("DATA_FMT") != ' ')
                                SetDataOption(i, node_list[i]);

                            DataChr[i].cFmt = node_list[i].GetChar("DATA_FMT");
                            DataChr[i].cOpt = node_list[i].GetChar("DATA_OPT");
                        }
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

        //
        // View_Table()
        //       - View General Code Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewOptionDefinition(char c_step, string strSeqNumber, string strOptionName)
        {
            TRSNode in_node = new TRSNode("VIEW_MFO_OPTION_DEFINITION_IN");
            TRSNode out_node = new TRSNode("VIEW_MFO_OPTION_DEFINITION_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("OPTION_NAME", strOptionName);
                in_node.AddInt("OPTION_SEQ", MPCF.ToInt(strSeqNumber));
                if (tabMFO_RES.SelectedTab.Equals(tbpOptionMFO))
                {
                    in_node.AddChar("REL_LEVEL", tvMFO.SelectLevelChar);
                    in_node.AddString("MAT_ID", tvMFO.MatID);
                    in_node.AddInt("MAT_VER", tvMFO.MatVersion);
                    in_node.AddString("FLOW", tvMFO.Flow);
                    in_node.AddString("OPER", tvMFO.Oper);
                }
                else if (tabMFO_RES.SelectedTab.Equals(tbpOptionRes))
                {
                    in_node.AddChar("REL_LEVEL", tvRes.SelectLevelChar);
                    in_node.AddString("RES_ID", tvRes.Resource);
                    in_node.AddString("RESG_ID", tvRes.ResourceGroup);
                    in_node.AddString("RES_TYPE", tvRes.ResourceType);
                }

                if (MPCR.CallService("WIP", "WIP_View_MFO_Option_Definition", in_node, ref out_node) == false)
                {
                    return false;
                }

                cdvOptionName.Text = out_node.GetString("OPTION_NAME");
                nudOptionSeq.Value = out_node.GetInt("OPTION_SEQ");
                txtOptionDescDefinition.Text = out_node.GetString("OPTION_DESC");
                txtDEFCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtDEFCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtDEFUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                txtDEFUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                cdvKey1.Text = out_node.GetString("KEY_1");
                cdvKey2.Text = out_node.GetString("KEY_2");
                cdvKey3.Text = out_node.GetString("KEY_3");
                cdvKey4.Text = out_node.GetString("KEY_4");
                cdvKey5.Text = out_node.GetString("KEY_5");

                cdvData1.Text = out_node.GetString("DATA_1");
                cdvData2.Text = out_node.GetString("DATA_2");
                cdvData3.Text = out_node.GetString("DATA_3");
                cdvData4.Text = out_node.GetString("DATA_4");
                cdvData5.Text = out_node.GetString("DATA_5");
                cdvData6.Text = out_node.GetString("DATA_6");
                cdvData7.Text = out_node.GetString("DATA_7");
                cdvData8.Text = out_node.GetString("DATA_8");
                cdvData9.Text = out_node.GetString("DATA_9");
                cdvData10.Text = out_node.GetString("DATA_10");
                cdvData11.Text = out_node.GetString("DATA_11");
                cdvData12.Text = out_node.GetString("DATA_12");
                cdvData13.Text = out_node.GetString("DATA_13");
                cdvData14.Text = out_node.GetString("DATA_14");
                cdvData15.Text = out_node.GetString("DATA_15");
                cdvData16.Text = out_node.GetString("DATA_16");
                cdvData17.Text = out_node.GetString("DATA_17");
                cdvData18.Text = out_node.GetString("DATA_18");
                cdvData19.Text = out_node.GetString("DATA_19");
                cdvData20.Text = out_node.GetString("DATA_20");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }


        private bool UpdateOptionPrompt(char c_step)
        {
            TRSNode in_node = new TRSNode("OPTION_PROMPT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode list_item;

            int i, iKey = spdKey.ActiveSheet.RowCount, iData = spdData.ActiveSheet.RowCount;
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                in_node.AddString("OPTION_NAME", MPCF.Trim(txtOptionName.Text));
                in_node.AddString("OPTION_DESC", MPCF.Trim(txtOptionDescPrompt.Text));
                in_node.AddChar("SYS_PMT_FLAG", (chkSysPmtFlag.Checked == true ? 'Y' : ' '));


                if (c_step != MPGC.MP_STEP_DELETE)
                {
                    for (i = 0; i < iKey; i++)
                    {
                        list_item = in_node.AddNode("KEY_LIST");

                        list_item.AddString("KEY_PMT", MPCF.Trim(spdKey.ActiveSheet.GetValue(i, 0)));
                        if (MPCF.Trim(spdKey.ActiveSheet.GetValue(i, 0)) != "")
                        {
                            list_item.AddChar("KEY_OPT", MPCF.ToChar(spdKey.ActiveSheet.GetValue(i, 1)));
                            list_item.AddChar("KEY_FMT", MPCF.ToChar(spdKey.ActiveSheet.GetValue(i, 2)));
                            list_item.AddString("KEY_TBL", MPCF.Trim(spdKey.ActiveSheet.GetValue(i, 3)));
                        }
                    }

                    for (i = 0; i < iData; i++)
                    {
                        list_item = in_node.AddNode("DATA_LIST");

                        list_item.AddString("DATA_PMT", MPCF.Trim(spdData.ActiveSheet.GetValue(i, 0)));
                        if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, 0)) != "")
                        {
                            list_item.AddChar("DATA_OPT", MPCF.ToChar(spdData.ActiveSheet.GetValue(i, 1)));
                            list_item.AddChar("DATA_FMT", MPCF.ToChar(spdData.ActiveSheet.GetValue(i, 2)));
                            list_item.AddString("DATA_TBL", MPCF.Trim(spdData.ActiveSheet.GetValue(i, 3)));
                        }
                    }
                }

                if (MPCR.CallService("WIP", "WIP_Update_MFO_Option_Prompt", in_node, ref out_node) == false)
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

        //
        // ViewOptionPromptList()
        //       - View Option Prompt List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - c_step 1: General ListView/TreeView
        //       - c_step 2: MCCodeView
        //       - c_step 3: Short Type ListView/TreeView
        //
        private static bool ViewOptionPromptList(Control ctrlView)
        {
            short i;
            TRSNode in_node = new TRSNode("LIST_IN");
            TRSNode out_node = new TRSNode("LIST_OUT");
            ListViewItem itmX;

            if (ctrlView is ListView)
            {
                MPCF.InitListView((ListView)ctrlView);
            }
            else if (!(ctrlView is TreeView))
            {
                MPCF.ClearList(ctrlView, true);
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            if (MPCR.CallService("WIP", "WIP_View_MFO_Option_Prompt_List", in_node, ref out_node) == false)
            {
                return false;
            }

            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                if (ctrlView is ListView)
                {
                    itmX = new ListViewItem(new string[] { out_node.GetList(0)[i].GetString("OPTION_NAME"),
                                                           out_node.GetList(0)[i].GetString("OPTION_DESC") }, (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL);

                    if (out_node.GetList(0)[i].GetChar("SYS_PMT_FLAG") == 'Y')
                    {
                        itmX.ForeColor = Color.Blue;
                    }
                    
                    ((ListView)ctrlView).Items.Add(itmX);
                }
            }

            MPCF.FitColumnHeader(ctrlView);

            return true;
        }

        //
        // ViewOptionDefinitionList()
        //       - View Option Prompt Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - c_step 1: General ListView/TreeView
        //       - c_step 2: MCCodeView
        //       - c_step 3: Short Type ListView/TreeView
        //
        private bool ViewOptionDefinitionList(Control ctrlView, 
                                               char c_step, 
                                               char c_rel_level, 
                                               string s_mat_id, 
                                               int i_mat_ver, 
                                               string s_flow, 
                                               string s_oper, 
                                               string s_res_id,
                                               string s_resg_id,
                                               string s_res_type,
                                               TreeNode parentNode)
        {
            FarPoint.Win.Spread.CellType.TextCellType txtCell;
            FarPoint.Win.Spread.CellType.NumberCellType numCell;
            FarPoint.Win.Spread.CellType.ButtonCellType btnCell;

            TRSNode in_node = new TRSNode("LIST_IN");
            TRSNode out_node = new TRSNode("LIST_OUT");
            TRSNode def_item;
            TRSNode list_item;
            int i;


            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            in_node.AddChar("REL_LEVEL", c_rel_level);
            in_node.AddString("MAT_ID", s_mat_id);
            in_node.AddInt("MAT_VER", i_mat_ver);
            in_node.AddString("FLOW", s_flow);
            in_node.AddString("OPER", s_oper);
            in_node.AddString("RES_ID", s_res_id);
            in_node.AddString("RESG_ID", s_resg_id);
            in_node.AddString("RES_TYPE", s_res_type);

            try
            {
                if (MPCR.CallService("WIP", "WIP_View_MFO_Option_Definition_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (ctrlView is TreeView)
                {
                    TreeNode nodeX;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        nodeX = new TreeNode(out_node.GetList(0)[i].GetInt("OPTION_SEQ").ToString() + " : " + 
                                             out_node.GetList(0)[i].GetString("OPTION_NAME"), 
                                             (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL, 
                                             (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL);
                        parentNode.Nodes.Add(nodeX);
                    }
                }
                else if (ctrlView is ListView)
                {
                    MPCF.InitListView((ListView)ctrlView);

                    ListViewItem itmX;
                    switch (c_step)
                    {
                        case '0':
                            break;
                        case '1':
                            for (i = 0; i < out_node.GetList(0).Count; i++)
                            {
                                itmX = new ListViewItem(new string[] { out_node.GetList(0)[i].GetString("MAT_ID"), 
                                                                       out_node.GetList(0)[i].GetInt("MAT_VER").ToString(), 
                                                                       out_node.GetList(0)[i].GetString("FLOW"), 
                                                                       out_node.GetList(0)[i].GetString("OPER") },
                                                                      (int)SMALLICON_INDEX.IDX_MATERIAL);
                                ((ListView)ctrlView).Items.Add(itmX);
                            }
                            break;
                        case '2':
                            for (i = 0; i < out_node.GetList(0).Count; i++)
                            {
                                itmX = new ListViewItem(new string[] { out_node.GetList(0)[i].GetString("FLOW"), 
                                                                       out_node.GetList(0)[i].GetString("OPER") },
                                                                     (int)SMALLICON_INDEX.IDX_FLOW);
                                ((ListView)ctrlView).Items.Add(itmX);
                            }
                            break;
                        case '3':
                            for (i = 0; i < out_node.GetList(0).Count; i++)
                            {
                                itmX = new ListViewItem(new string[] { out_node.GetList(0)[i].GetString("OPER") },
                                                                     (int)SMALLICON_INDEX.IDX_OPER);
                                ((ListView)ctrlView).Items.Add(itmX);
                            }
                            break;
                        case '4':
                            for (i = 0; i < out_node.GetList(0).Count; i++)
                            {
                                itmX = new ListViewItem(new string[] { out_node.GetList(0)[i].GetString("MAT_ID"), 
                                                                       out_node.GetList(0)[i].GetInt("MAT_VER").ToString(), 
                                                                       out_node.GetList(0)[i].GetString("OPER") },
                                                                     (int)SMALLICON_INDEX.IDX_MATERIAL);
                                ((ListView)ctrlView).Items.Add(itmX);
                            }
                            break;
                        case '5':
                            for (i = 0; i < out_node.GetList(0).Count; i++)
                            {
                                itmX = new ListViewItem(new string[] { out_node.GetList(0)[i].GetString("MAT_ID"), 
                                                                       out_node.GetList(0)[i].GetInt("MAT_VER").ToString(), 
                                                                       out_node.GetList(0)[i].GetString("FLOW") },
                                                                     (int)SMALLICON_INDEX.IDX_MATERIAL);
                                ((ListView)ctrlView).Items.Add(itmX);
                            }
                            break;
                        case '6':
                            for (i = 0; i < out_node.GetList(0).Count; i++)
                            {
                                itmX = new ListViewItem(new string[] { out_node.GetList(0)[i].GetString("MAT_ID"), 
                                                                       out_node.GetList(0)[i].GetInt("MAT_VER").ToString() },
                                                                     (int)SMALLICON_INDEX.IDX_MATERIAL);
                                ((ListView)ctrlView).Items.Add(itmX);
                            }
                            break;
                        case '7':
                            for (i = 0; i < out_node.GetList(0).Count; i++)
                            {
                                itmX = new ListViewItem(new string[] { out_node.GetList(0)[i].GetString("FLOW") },
                                                                     (int)SMALLICON_INDEX.IDX_FLOW);
                                ((ListView)ctrlView).Items.Add(itmX);
                            }
                            break;
                        case '8':
                            for (i = 0; i < out_node.GetList(0).Count; i++)
                            {
                                itmX = new ListViewItem(new string[] { out_node.GetList(0)[i].GetString("FACTORY") },
                                                                     (int)SMALLICON_INDEX.IDX_FACTORY);
                                ((ListView)ctrlView).Items.Add(itmX);
                            }
                            break;
                        case 'R':
                            for (i = 0; i < out_node.GetList(0).Count; i++)
                            {
                                itmX = new ListViewItem(new string[] { out_node.GetList(0)[i].GetString("RES_ID") },
                                                                     (int)SMALLICON_INDEX.IDX_RESOURCE);
                                ((ListView)ctrlView).Items.Add(itmX);
                            }
                            break;
                        case 'G':
                            for (i = 0; i < out_node.GetList(0).Count; i++)
                            {
                                itmX = new ListViewItem(new string[] { out_node.GetList(0)[i].GetString("RESG_ID"), 
                                                                       out_node.GetList(0)[i].GetString("RES_ID") },
                                                                     (int)SMALLICON_INDEX.IDX_RESOURCE_GROUP);
                                ((ListView)ctrlView).Items.Add(itmX);
                            }
                            break;
                        case 'T':
                            for (i = 0; i < out_node.GetList(0).Count; i++)
                            {
                                itmX = new ListViewItem(new string[] { out_node.GetList(0)[i].GetString("RES_TYPE"), 
                                                                       out_node.GetList(0)[i].GetString("RES_ID") },
                                                                       (int)SMALLICON_INDEX.IDX_CODE_DATA);
                                ((ListView)ctrlView).Items.Add(itmX);
                            }
                            break;
                    }

                    lblDataCount.Text = ((ListView)ctrlView).Items.Count.ToString();
                }
                else
                {
                    int j;
                    int iIndexTextCol;
                    MPCF.ClearList(spdOptionList);
                    spdOptionList.ActiveSheet.RowCount = out_node.GetList(0).Count;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        def_item = out_node.GetList(0)[i];

                        spdOptionList.ActiveSheet.SetValue(i, 0, false);
                        spdOptionList.ActiveSheet.SetValue(i, 1, def_item.GetString("OPTION_NAME"));
                        spdOptionList.ActiveSheet.SetValue(i, 2, def_item.GetInt("OPTION_SEQ"));
                        spdOptionList.ActiveSheet.SetValue(i, 3, def_item.GetString("OPTION_DESC"));

                        iIndexTextCol = 4;

                        for (j = 0; j < def_item.GetList("KEY_LIST").Count; j++)
                        {
                            list_item = def_item.GetList("KEY_LIST")[j];

                            switch (list_item.GetChar("KEY_FMT"))
                            {
                                case 'A':
                                    txtCell = new FarPoint.Win.Spread.CellType.TextCellType();
                                    txtCell.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Ascii;
                                    txtCell.MaxLength = KEY_MAX_LENGTH;

                                    spdOptionList.ActiveSheet.Cells[i, iIndexTextCol].CellType = txtCell;
                                    break;
                                case 'N':
                                    numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                                    numCell.DecimalPlaces = 0;
                                    numCell.MaximumValue = 9999999999999;
                                    numCell.MinimumValue = -9999999999999;

                                    spdOptionList.ActiveSheet.Cells[i, iIndexTextCol].CellType = numCell;
                                    break;
                                case 'F':
                                    numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                                    numCell.DecimalPlaces = 3;
                                    numCell.MaximumValue = 9999999999999;
                                    numCell.MinimumValue = -9999999999999;

                                    spdOptionList.ActiveSheet.Cells[i, iIndexTextCol].CellType = numCell;
                                    break;
                            }

                            spdOptionList.ActiveSheet.SetValue(i, iIndexTextCol, list_item.GetString("KEY"));

                            if (list_item.GetChar("KEY_FMT") == ' ' && list_item.GetChar("KEY_OPT") == ' ')
                            {
                                spdOptionList.ActiveSheet.Cells[i, iIndexTextCol].Locked = true;
                                spdOptionList.ActiveSheet.Cells[i, iIndexTextCol].BackColor = System.Drawing.Color.Gainsboro;
                            }
                            else
                            {
                                spdOptionList.ActiveSheet.Cells[i, iIndexTextCol].Locked = false;
                                spdOptionList.ActiveSheet.Cells[i, iIndexTextCol].BackColor = System.Drawing.Color.White;
                            }

                            spdOptionList.ActiveSheet.SetTag(i, iIndexTextCol, list_item.GetChar("KEY_OPT"));

                            if (list_item.GetString("KEY_TBL") == "")
                            {
                                spdOptionList.ActiveSheet.AddSpanCell(i, iIndexTextCol, 1, 2);
                            }
                            else
                            {
                                spdOptionList.ActiveSheet.Cells[i, iIndexTextCol].Locked = true;

                                btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                                btnCell.Text = "...";
                                spdOptionList.ActiveSheet.Cells[i, iIndexTextCol + 1].CellType = btnCell;
                                spdOptionList.ActiveSheet.Cells[i, iIndexTextCol + 1].Tag = list_item.GetString("KEY_TBL");
                            }

                            iIndexTextCol += 2;
                        }

                        iIndexTextCol = 14;

                        for (j = 0; j < def_item.GetList("DATA_LIST").Count; j++)
                        {
                            list_item = def_item.GetList("DATA_LIST")[j];

                            switch (list_item.GetChar("DATA_FMT"))
                            {
                                case 'A':
                                    txtCell = new FarPoint.Win.Spread.CellType.TextCellType();
                                    txtCell.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Ascii;
                                    txtCell.MaxLength = DATA_MAX_LENGTH;

                                    spdOptionList.ActiveSheet.Cells[i, iIndexTextCol].CellType = txtCell;
                                    break;
                                case 'N':
                                    numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                                    numCell.DecimalPlaces = 0;
                                    numCell.MaximumValue = 9999999999999;
                                    numCell.MinimumValue = -9999999999999;

                                    spdOptionList.ActiveSheet.Cells[i, iIndexTextCol].CellType = numCell;
                                    break;
                                case 'F':
                                    numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                                    numCell.DecimalPlaces = 3;
                                    numCell.MaximumValue = 9999999999999;
                                    numCell.MinimumValue = -9999999999999;

                                    spdOptionList.ActiveSheet.Cells[i, iIndexTextCol].CellType = numCell;
                                    break;
                            }

                            spdOptionList.ActiveSheet.SetValue(i, iIndexTextCol, list_item.GetString("DATA"));

                            if (list_item.GetChar("DATA_FMT") == ' ' && list_item.GetChar("DATA_OPT") == ' ')
                            {
                                spdOptionList.ActiveSheet.Cells[i, iIndexTextCol].Locked = true;
                                spdOptionList.ActiveSheet.Cells[i, iIndexTextCol].BackColor = System.Drawing.Color.Gainsboro;
                            }
                            else
                            {
                                spdOptionList.ActiveSheet.Cells[i, iIndexTextCol].Locked = false;
                                spdOptionList.ActiveSheet.Cells[i, iIndexTextCol].BackColor = System.Drawing.Color.White;
                            }

                            spdOptionList.ActiveSheet.SetTag(i, iIndexTextCol, list_item.GetChar("DATA_OPT"));

                            if (list_item.GetString("DATA_TBL") == "")
                            {
                                spdOptionList.ActiveSheet.AddSpanCell(i, iIndexTextCol, 1, 2);
                            }
                            else
                            {
                                spdOptionList.ActiveSheet.Cells[i, iIndexTextCol].Locked = true;
                                btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                                btnCell.Text = "...";
                                spdOptionList.ActiveSheet.Cells[i, iIndexTextCol + 1].CellType = btnCell;
                                spdOptionList.ActiveSheet.Cells[i, iIndexTextCol + 1].Tag = list_item.GetString("DATA_TBL");
                            }

                            iIndexTextCol += 2;
                        }

                        spdOptionList.ActiveSheet.SetValue(i, 54, def_item.GetString("CREATE_USER_ID"));
                        spdOptionList.ActiveSheet.SetValue(i, 55, MPCF.MakeDateFormat(def_item.GetString("CREATE_TIME")));
                        spdOptionList.ActiveSheet.SetValue(i, 56, def_item.GetString("UPDATE_USER_ID"));
                        spdOptionList.ActiveSheet.SetValue(i, 57, MPCF.MakeDateFormat(def_item.GetString("UPDATE_TIME")));
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

        private bool UpdateOptionDefinition(char c_step)
        {
            TRSNode in_node = new TRSNode("OPTION_DEFINITION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                in_node.AddString("OPTION_NAME", MPCF.Trim(cdvOptionName.Text));
                in_node.AddInt("OPTION_SEQ", (int)nudOptionSeq.Value);
                in_node.AddString("OPTION_DESC", MPCF.Trim(txtOptionDescDefinition.Text));

                switch (tabMFO_RES.SelectedIndex)
                {
                    case 0:
                        in_node.AddChar("REL_LEVEL", tvMFO.SelectLevelChar);
                        in_node.AddString("MAT_ID", tvMFO.MatID);
                        in_node.AddInt("MAT_VER", tvMFO.MatVersion);
                        in_node.AddString("FLOW", tvMFO.Flow);
                        in_node.AddString("OPER", tvMFO.Oper);
                        break;
                    case 1:
                        in_node.AddChar("REL_LEVEL", tvRes.SelectLevelChar);
                        in_node.AddString("RES_ID", tvRes.Resource);
                        in_node.AddString("RESG_ID", tvRes.ResourceGroup);
                        in_node.AddString("RES_TYPE", tvRes.ResourceType);
                        break;
                }


                if (c_step != MPGC.MP_STEP_DELETE)
                {
                    in_node.AddString("KEY_1", MPCF.Trim(cdvKey1.Text));
                    in_node.AddString("KEY_2", MPCF.Trim(cdvKey2.Text));
                    in_node.AddString("KEY_3", MPCF.Trim(cdvKey3.Text));
                    in_node.AddString("KEY_4", MPCF.Trim(cdvKey4.Text));
                    in_node.AddString("KEY_5", MPCF.Trim(cdvKey5.Text));

                    in_node.AddString("DATA_1", MPCF.Trim(cdvData1.Text));
                    in_node.AddString("DATA_2", MPCF.Trim(cdvData2.Text));
                    in_node.AddString("DATA_3", MPCF.Trim(cdvData3.Text));
                    in_node.AddString("DATA_4", MPCF.Trim(cdvData4.Text));
                    in_node.AddString("DATA_5", MPCF.Trim(cdvData5.Text));
                    in_node.AddString("DATA_6", MPCF.Trim(cdvData6.Text));
                    in_node.AddString("DATA_7", MPCF.Trim(cdvData7.Text));
                    in_node.AddString("DATA_8", MPCF.Trim(cdvData8.Text));
                    in_node.AddString("DATA_9", MPCF.Trim(cdvData9.Text));
                    in_node.AddString("DATA_10", MPCF.Trim(cdvData10.Text));
                    in_node.AddString("DATA_11", MPCF.Trim(cdvData11.Text));
                    in_node.AddString("DATA_12", MPCF.Trim(cdvData12.Text));
                    in_node.AddString("DATA_13", MPCF.Trim(cdvData13.Text));
                    in_node.AddString("DATA_14", MPCF.Trim(cdvData14.Text));
                    in_node.AddString("DATA_15", MPCF.Trim(cdvData15.Text));
                    in_node.AddString("DATA_16", MPCF.Trim(cdvData16.Text));
                    in_node.AddString("DATA_17", MPCF.Trim(cdvData17.Text));
                    in_node.AddString("DATA_18", MPCF.Trim(cdvData18.Text));
                    in_node.AddString("DATA_19", MPCF.Trim(cdvData19.Text));
                    in_node.AddString("DATA_20", MPCF.Trim(cdvData20.Text));
                }

                if (MPCR.CallService("WIP", "WIP_Update_MFO_Option_Definition", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (c_step == MPGC.MP_STEP_CREATE) tvMFO.RefreshSelectedList();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool UpdateViewOptionList(char c_step)
        {
            TRSNode in_node = new TRSNode("OPTION_DEFINITION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            int i;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                switch (tabList.SelectedIndex)
                {
                    case 0:
                        in_node.AddChar("REL_LEVEL", tvMFOList.SelectLevelChar);
                        in_node.AddString("MAT_ID", tvMFOList.MatID);
                        in_node.AddInt("MAT_VER", tvMFOList.MatVersion);
                        in_node.AddString("FLOW", tvMFOList.Flow);
                        in_node.AddString("OPER", tvMFOList.Oper);
                        break;

                    case 1:
                        in_node.AddChar("REL_LEVEL", tvResList.SelectLevelChar);
                        in_node.AddString("RES_ID", tvResList.Resource);
                        in_node.AddString("RESG_ID", tvResList.ResourceGroup);
                        in_node.AddString("RES_TYPE", tvResList.ResourceType);
                        break;
                }

                for (i = 0; i < spdOptionList.ActiveSheet.RowCount; i++)
                {
                    if (spdOptionList.ActiveSheet.GetValue(i, 0).Equals(true))
                    {
                        in_node.SetString("OPTION_NAME", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 1)));
                        in_node.SetInt("OPTION_SEQ", MPCF.ToInt(spdOptionList.ActiveSheet.GetValue(i, 2)));

                        if (c_step != MPGC.MP_STEP_DELETE)
                        {
                            in_node.SetString("KEY_1", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 4)));
                            in_node.SetString("KEY_2", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 6)));
                            in_node.SetString("KEY_3", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 8)));
                            in_node.SetString("KEY_4", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 10)));
                            in_node.SetString("KEY_5", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 12)));
                            in_node.SetString("DATA_1", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 14)));
                            in_node.SetString("DATA_2", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 16)));
                            in_node.SetString("DATA_3", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 18)));
                            in_node.SetString("DATA_4", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 20)));
                            in_node.SetString("DATA_5", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 22)));
                            in_node.SetString("DATA_6", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 24)));
                            in_node.SetString("DATA_7", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 26)));
                            in_node.SetString("DATA_8", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 28)));
                            in_node.SetString("DATA_9", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 30)));
                            in_node.SetString("DATA_10", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 32)));
                            in_node.SetString("DATA_11", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 34)));
                            in_node.SetString("DATA_12", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 36)));
                            in_node.SetString("DATA_13", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 38)));
                            in_node.SetString("DATA_14", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 40)));
                            in_node.SetString("DATA_15", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 42)));
                            in_node.SetString("DATA_16", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 44)));
                            in_node.SetString("DATA_17", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 46)));
                            in_node.SetString("DATA_18", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 48)));
                            in_node.SetString("DATA_19", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 50)));
                            in_node.SetString("DATA_20", MPCF.Trim(spdOptionList.ActiveSheet.GetValue(i, 52)));
                        }
                        if (MPCR.CallService("WIP", "WIP_Update_MFO_Option_Definition", in_node, ref out_node) == false)
                        {
                            return false;
                        }

                        spdOptionList.ActiveSheet.SetValue(i, 0, false);
                    }
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

        private bool UpdateMFOOption(char c_step)
        {
            bool bRet = true;
            switch (tabOption.SelectedIndex)
            {
                case 0:
                    bRet = UpdateOptionPrompt(c_step);
                    break;
                case 1:
                    bRet = UpdateOptionDefinition(c_step);
                    break;
                case 2:
                    bRet = UpdateViewOptionList(c_step);
                    break;
            }

            return bRet;
        }

        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.cdvOptionName;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion

        private void frmWIPSetupMFOOption_Load(object sender, EventArgs e)
        {
            tabOption.SelectedTab = tbpOption;
            if (MPGV.gsFactory == MPGV.gsCentralFactory)
            {
                chkSysPmtFlag.Enabled = true;
            }
            else
            {
                chkSysPmtFlag.Enabled = false;
            }

            //Modify by J.S. 2011.12.05 베이스 폼보다 더 큰 폼을 사용하면 control의 위치가 강제로 바뀌는 경우 때문에
            //넣어 놓았던 코딩 원복(가끔 버턴이 사라지는 경우 발생), 폼을 베이스 폼에 맞추어 놓고 필요한 크기로
            //load, active시에 처리하는 것으로 수정
            this.Width = 945;
            this.Height = 640;
        }

        private void frmWIPSetupMFOOption_Activated(object sender, EventArgs e)
        {
            try
            {
                if (bLoadFlag == false)
                {
                    frmWIPSetupMFOOption_Resize(null, null);

                    tvMFOList.OnlySetDataList = true;
                    tvResList.OnlySetDataList = true;

                    MPCF.InitListView(lisOption);
                    MPCF.ClearList(spdOptionList);
                    ClearData('2');

                    bLoadFlag = true;
                }

                //Modify by J.S. 2011.12.05 베이스 폼보다 더 큰 폼을 사용하면 control의 위치가 강제로 바뀌는 경우 때문에
                //넣어 놓았던 코딩 원복(가끔 버턴이 사라지는 경우 발생), 폼을 베이스 폼에 맞추어 놓고 필요한 크기로
                //load, active시에 처리하는 것으로 수정
                if (this.Width < 945)
                {
                    this.Width = 945;
                }
                if (this.Height < 640)
                {
                    this.Height = 640;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void frmWIPSetupMFOOption_Resize(object sender, EventArgs e)
        {
            //Modify by J.S. 2011.12.05 베이스 폼보다 더 큰 폼을 사용하면 control의 위치가 강제로 바뀌는 경우 때문에
            //넣어 놓았던 코딩 원복(가끔 버턴이 사라지는 경우 발생), 폼을 베이스 폼에 맞추어 놓고 필요한 크기로
            //load, active시에 처리하는 것으로 수정
            //btnClose.Location = new Point(this.Width - 111, btnClose.Location.Y);
            //btnDelete.Location = new Point(this.Width - 202, btnClose.Location.Y);
            //btnUpdate.Location = new Point(this.Width - 293, btnClose.Location.Y);
            //btnCreate.Location = new Point(this.Width - 384, btnClose.Location.Y);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition(MPGC.MP_STEP_CREATE) == true)
                {
                    if (UpdateMFOOption(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int i_select_index;

            try
            {
                if (CheckCondition(MPGC.MP_STEP_UPDATE) == true)
                {
                    if (UpdateMFOOption(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        switch (tabOption.SelectedIndex)
                        {
                            case 0:
                                i_select_index = MPCF.FindListItemIndex(lisOption, txtOptionName.Text, false);
                                if (i_select_index >= 0)
                                {
                                    lisOption.Items[i_select_index].SubItems[1].Text = txtOptionDescPrompt.Text;
                                }
                                break;
                            case 1:
                                break;
                            case 2:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                    return;
                
                if (CheckCondition(MPGC.MP_STEP_DELETE) == true)
                {
                    if (UpdateMFOOption(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdKey_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            cdvGCMTableList.Init();
            cdvGCMTableList.ViewPosition = Control.MousePosition;
            MPCF.InitListView(cdvGCMTableList.GetListView);
            cdvGCMTableList.Columns.Add("Table", 30, HorizontalAlignment.Left);
            cdvGCMTableList.Columns.Add("Desc", 80, HorizontalAlignment.Left);
            cdvGCMTableList.ViewPosition = new Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y);
            BASLIST.ViewGCMTableList(cdvGCMTableList.GetListView, '1');
            cdvGCMTableList.InsertEmptyRow(0, 1);
            cdvGCMTableList.ShowPopUp(e.Row, e.Column - 1);
            lspdTable = spdKey;
        }

        private void spdData_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            cdvGCMTableList.Init();
            cdvGCMTableList.ViewPosition = Control.MousePosition;
            MPCF.InitListView(cdvGCMTableList.GetListView);
            cdvGCMTableList.Columns.Add("Table", 30, HorizontalAlignment.Left);
            cdvGCMTableList.Columns.Add("Desc", 80, HorizontalAlignment.Left);
            cdvGCMTableList.ViewPosition = new Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y);
            BASLIST.ViewGCMTableList(cdvGCMTableList.GetListView, '1');
            cdvGCMTableList.InsertEmptyRow(0, 1);
            cdvGCMTableList.ShowPopUp(e.Row, e.Column - 1);
            lspdTable = spdData;
        }

        private void spdOptionList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (!(e.Column == 0))
            {
                cdvGCMTableList.Init();
                cdvGCMTableList.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvGCMTableList.GetListView);
                cdvGCMTableList.Columns.Add("Data", 30, HorizontalAlignment.Left);
                cdvGCMTableList.Columns.Add("Desc", 80, HorizontalAlignment.Left);
                cdvGCMTableList.ViewPosition = new Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y);
                BASLIST.ViewGCMDataList(cdvGCMTableList.GetListView, '1', (string)spdOptionList.ActiveSheet.GetTag(e.Row, e.Column));

                if (MPCF.Trim(spdOptionList.ActiveSheet.Cells[e.Row, e.Column - 1].Tag) != "Y")
                {
                    cdvGCMTableList.InsertEmptyRow(0, 1);
                }

                cdvGCMTableList.ShowPopUp(e.Row, e.Column - 1);
                lspdTable = spdOptionList;
            }
        }

        private void spdOptionList_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            FarPoint.Win.Spread.SheetView sheet = new FarPoint.Win.Spread.SheetView();
            sheet = ((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet;
            sheet.Cells[e.Row, 0].Value = true;
        }

        private void spdKey_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {
            if (MPCF.Trim(spdKey.ActiveSheet.Cells[e.Row, 0].Text) == "") spdKey.ActiveSheet.ClearRange(e.Row, 0, 1, 4, true);
        }

        private void spdData_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {
            if (MPCF.Trim(spdData.ActiveSheet.Cells[e.Row, 0].Text) == "") spdData.ActiveSheet.ClearRange(e.Row, 0, 1, 4, true);
        }

        private void cdvGCMTableList_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            lspdTable.ActiveSheet.Cells[e.Row, e.Col].Value = e.SelectedItem.SubItems[0].Text;

            if (tabOption.SelectedTab.Equals(tbpList))
            {
                lspdTable.ActiveSheet.Cells[e.Row, 0].Value = true;
            }
        }

        private void lisOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisOption.SelectedItems.Count < 1) return;

            ViewOptionPrompt('1', lisOption.SelectedItems[0].Text);
        }

        private void cdvOptionName_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvOptionName.Text) == "")
            {
                ClearData('2');
            }
            else
            {
                ViewOptionPrompt('2', cdvOptionName.Text);
            }
        }

        private void tabOption_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    if (MPCF.Trim(lisOption.Tag) == "")
                    {
                        ViewOptionPromptList(lisOption);
                        lisOption.Tag = "READED";
                    }

                    //Item Count
                    if (lisOption.Items.Count > 0)
                    {
                        lblDataCount.Text = lisOption.Items.Count.ToString();
                    }
                    else
                    {
                        lblDataCount.Text = "0";
                    }

                    btnCreate.Visible = true;
                    break;

                case 1:
                    cdvOptionName.Init();
                    MPCF.InitListView(cdvOptionName.GetListView);
                    cdvOptionName.Columns.Add("Option", 30, HorizontalAlignment.Left);
                    cdvOptionName.Columns.Add("Desc", 80, HorizontalAlignment.Left);
                    cdvOptionName.SelectedSubItemIndex = 0;
                    ViewOptionPromptList(cdvOptionName.GetListView);

                    switch (tabMFO_RES.SelectedIndex)
                    {
                        case 0:
                            if (!(tvMFO.SelectedNode == null))
                            {
                                lblDataCount.Text = MPCF.Trim(tvMFO.SelectedNode.GetNodeCount(false));
                            }
                            else
                            {
                                if (tvMFO.ListCount > 0)
                                {
                                    lblDataCount.Text = tvMFO.ListCount.ToString();
                                }
                                else
                                {
                                    lblDataCount.Text = "0";
                                }
                            }
                            break;

                        case 1:
                            if (!(tvRes.SelectedNode == null))
                            {
                                lblDataCount.Text = MPCF.Trim(tvRes.SelectedNode.GetNodeCount(false));
                            }
                            else
                            {
                                if (tvMFO.ListCount > 0)
                                {
                                    lblDataCount.Text = tvRes.ListCount.ToString();
                                }
                                else
                                {
                                    lblDataCount.Text = "0";
                                }
                            }
                            break;
                    }

                    btnCreate.Visible = true;
                    break;

                case 2:
                    switch (tabList.SelectedIndex)
                    {
                        case 0:
                            lblDataCount.Text = MPCF.Trim(tvMFOList.GetListView.Items.Count);
                            break;

                        case 1:
                            lblDataCount.Text = MPCF.Trim(tvResList.GetListView.Items.Count);
                            break;
                    }

                    btnCreate.Visible = false;
                    break;
            }
        }

        private void tabList_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    lblDataCount.Text = MPCF.Trim(tvMFOList.GetListView.Items.Count);
                    break;

                case 1:
                    lblDataCount.Text = MPCF.Trim(tvResList.GetListView.Items.Count);
                    break;
            }

            spdOptionList.ActiveSheet.RowCount = 0;
        }

        private void tabMFO_RES_Selected(object sender, TabControlEventArgs e)
        {
            ClearData('2');

            switch (e.TabPageIndex)
            {
                case 0:
                    if (!(tvMFO.SelectedNode == null))
                    {
                        lblDataCount.Text = MPCF.Trim(tvMFO.SelectedNode.GetNodeCount(false));
                    }
                    else
                    {
                        if (tvMFO.ListCount > 0)
                        {
                            lblDataCount.Text = tvMFO.ListCount.ToString();
                        }
                        else
                        {
                            lblDataCount.Text = "0";
                        }
                    }
                    break;

                case 1:
                    if (!(tvRes.SelectedNode == null))
                    {
                        lblDataCount.Text = MPCF.Trim(tvRes.SelectedNode.GetNodeCount(false));
                    }
                    else
                    {
                        if (tvMFO.ListCount > 0)
                        {
                            lblDataCount.Text = tvRes.ListCount.ToString();
                        }
                        else
                        {
                            lblDataCount.Text = "0";
                        }
                    }
                    break;
            }
        }

        private void tvMFO_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(tvMFO.SelectedNode.GetNodeCount(false));

            if (tvMFO.SelectedItem == Miracom.MESCore.Controls.TreeSelectedItem.Another)
            {
                ViewOptionPrompt('2', MPCF.SubtractString(e.Node.Text, ":", true, false));
                ViewOptionDefinition('2', MPCF.SubtractString(e.Node.Text, ":", false, false), MPCF.SubtractString(e.Node.Text, ":", true, false));
            }
            else
            {
                ClearData('2');
            }
        }

        private void tvMFO_AfterGetTree(object sender, EventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(tvMFO.GetTreeView.GetNodeCount(false));
        }

        private void tvMFO_LevelItemSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.GetNodeCount(true) < 1)
            {
                ViewOptionDefinitionList(tvMFO.GetTreeView, '0', tvMFO.SelectLevelChar, tvMFO.MatID, tvMFO.MatVersion, tvMFO.Flow, tvMFO.Oper, "", "", "", e.Node);
            }
        }

        private void tvRes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblDataCount.Text = tvRes.SelectedNode.GetNodeCount(false).ToString();

            if (tvRes.SelectedItem == Miracom.MESCore.Controls.TreeSelectedItem.Another)
            {
                ViewOptionPrompt('2', MPCF.SubtractString(e.Node.Text, ":", true, false));
                ViewOptionDefinition('2', MPCF.SubtractString(e.Node.Text, ":", false, false), MPCF.SubtractString(e.Node.Text, ":", true, false));
            }
            else
            {
                ClearData('2');
            }
        }

        private void tvRes_AfterGetTree(object sender, EventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(tvRes.GetTreeView.GetNodeCount(false));
        }

        private void tvRes_LevelItemSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.GetNodeCount(true) < 1)
            {
                ViewOptionDefinitionList(tvRes.GetTreeView, '0', tvRes.SelectLevelChar, "", 0, "", "", tvRes.Resource, tvRes.ResourceGroup, tvRes.ResourceType, e.Node);
            }
        }

        private void tvMFOList_GetOnlySetData(object sender, EventArgs e)
        {
            ViewOptionDefinitionList(tvMFOList.GetListView, tvMFOList.SelectLevelChar, tvMFOList.SelectLevelChar, tvMFOList.MatID, tvMFOList.MatVersion, tvMFOList.Flow, tvMFOList.Oper, "", "", "", null);
            spdOptionList.ActiveSheet.RowCount = 0;
        }

        private void tvMFOList_SetDataSelectedIndexChanged(object sender, EventArgs e)
        {
            ViewOptionDefinitionList(spdOptionList, 'Z', tvMFOList.SelectLevelChar, tvMFOList.MatID, tvMFOList.MatVersion, tvMFOList.Flow, tvMFOList.Oper, "", "", "", null);
        }

        private void tvResList_GetOnlySetData(object sender, EventArgs e)
        {
            ViewOptionDefinitionList(tvResList.GetListView, tvResList.SelectLevelChar, tvResList.SelectLevelChar, "", 0, "", "", tvResList.Resource, tvResList.ResourceGroup, tvResList.ResourceType, null);
            spdOptionList.ActiveSheet.RowCount = 0;
        }

        private void tvResList_SetDataSelectedIndexChanged(object sender, EventArgs e)
        {
            ViewOptionDefinitionList(spdOptionList, 'Z', tvResList.SelectLevelChar, "", 0, "", "", tvResList.Resource, tvResList.ResourceGroup, tvResList.ResourceType, null);
        }

        private void cdvKeyData_ButtonPress(object sender, System.EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            int i;
            bool b_add_empty_row;

            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;
            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("Code", 150, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            MPCR.ProcGRPCMFButtonPress(cdvTemp);

            b_add_empty_row = false;
            if (cdvTemp.Name.StartsWith("cdvKey") == true)
            {
                i = MPCF.ToInt(cdvTemp.Name.Substring(6));
                if (KeyChr[i - 1].cOpt != 'Y')
                    b_add_empty_row = true;
            }
            else
            {
                i = MPCF.ToInt(cdvTemp.Name.Substring(7));
                if (DataChr[i - 1].cOpt != 'Y')
                    b_add_empty_row = true;
            }

            if (b_add_empty_row == true)
            {
                cdvTemp.InsertEmptyRow(0, 1);
            }
        }

        private void cdvKeyData_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            char cFormat;

            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            if ((MPCF.Trim(cdvTemp.Tag) != ""))
            {
                cFormat = MPCF.Trim(cdvTemp.Tag)[0];
                if (cFormat == 'N' || cFormat == 'F')
                {
                    if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                    {
                        if (!(e.KeyChar == (char)43 || e.KeyChar == (char)45 || e.KeyChar == (char)8))
                        {
                            if (cFormat == 'F')
                            {
                                if (cdvTemp.Text.IndexOf((char)46) > -1)
                                {
                                    e.Handled = true;
                                }

                                if (!(e.KeyChar == (char)46))
                                {
                                    e.Handled = true;
                                }
                            }
                            else
                            {
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (e.KeyChar == (char)43 || e.KeyChar == (char)45)
                            {
                                if (MPCF.Trim(cdvTemp.Text) != "")
                                {
                                    e.Handled = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            switch (tabOption.SelectedIndex)
            {
                case 0:
                    MPCF.FindListItemNextPartial(lisOption, txtFind.Text, true, false);
                    break;
                case 1:
                    switch (tabMFO_RES.SelectedIndex)
                    {
                        case 0:
                            tvMFO.GetNext(txtFind.Text);
                            break;
                        case 1:
                            tvRes.GetNext(txtFind.Text);
                            break;
                    }
                    break;
                case 2:
                    switch (tabList.SelectedIndex)
                    {
                        case 0:
                            tvMFOList.GetNext(txtFind.Text);
                            break;
                        case 1:
                            tvResList.GetNext(txtFind.Text);
                            break;
                    }
                    break;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            switch (tabOption.SelectedIndex)
            {
                case 0:
                    MPCF.ExportToExcel(lisOption, this.Text, "");
                    break;
                case 1:
                    switch (tabMFO_RES.SelectedIndex)
                    {
                        case 0:
                            MPCF.ExportToExcel(tvMFO.GetListView, this.Text, "");
                            break;
                        case 1:
                            MPCF.ExportToExcel(tvRes.GetListView, this.Text, "");
                            break;
                    }
                    break;
                case 2:
                    switch (tabList.SelectedIndex)
                    {
                        case 0:
                            MPCF.ExportToExcel(tvMFOList.GetListView, this.Text, "");
                            break;
                        case 1:
                            MPCF.ExportToExcel(tvResList.GetListView, this.Text, "");
                            break;
                    }
                    break;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            switch (tabOption.SelectedIndex)
            {
                case 0:
                    ViewOptionPromptList(lisOption);
                    //Item Count
                    if (lisOption.Items.Count > 0)
                    {
                        if (MPCF.FindListItem(lisOption, txtOptionName.Text, false) == false)
                        {
                            lisOption.Items[0].Selected = true;
                        }

                        lblDataCount.Text = lisOption.Items.Count.ToString();
                    }
                    else
                    {
                        ClearData('1');
                        lblDataCount.Text = "0";
                    }
                    break;
                case 1:
                    string strOptionString;
                    strOptionString = nudOptionSeq.Value + " : " + cdvOptionName.Text;

                    switch (tabMFO_RES.SelectedIndex)
                    {
                        case 0:
                            if (tvMFO.SelectedItem == Miracom.MESCore.Controls.TreeSelectedItem.Another)
                            {
                                tvMFO.GetTreeView.SelectedNode = tvMFO.GetTreeView.SelectedNode.Parent;
                                tvMFO.SelectedItem = Miracom.MESCore.Controls.TreeSelectedItem.Oper;
                            }

                            tvMFO.RefreshSelectedList();
                            //tvMFO.GetNext(strOptionString);
                            break;
                        case 1:
                            if (tvRes.SelectedItem == Miracom.MESCore.Controls.TreeSelectedItem.Another)
                            {
                                tvRes.GetTreeView.SelectedNode = tvRes.GetTreeView.SelectedNode.Parent;
                                tvRes.SelectedItem = Miracom.MESCore.Controls.TreeSelectedItem.Oper;
                            }

                            tvRes.RefreshSelectedList();
                            //tvRes.GetNext(strOptionString);
                            break;
                    }
                    break;
                case 2:
                    switch (tabList.SelectedIndex)
                    {
                        case 0:
                            tvMFOList.RefreshSelectedList();
                            break;
                        case 1:
                            tvResList.RefreshSelectedList();
                            break;
                    }
                    break;
            }
        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            switch (tabOption.SelectedIndex)
            {
                case 0:
                    MPCF.FindListItemPartial(lisOption, txtFind.Text, 0, true, false);
                    break;

                default:
                    btnNext.PerformClick();
                    break;
            }
        }

        private void txtOptionName_Leave(object sender, EventArgs e)
        {
            if (MPGV.gsFactory != MPGV.gsCentralFactory)
            {
                if (lisOption.SelectedItems.Count > 0)
                {
                    if (txtOptionName.Text != "")
                    {
                        if (MPCF.Trim(lisOption.SelectedItems[0].Text) != txtOptionName.Text)
                        {
                            chkSysPmtFlag.Checked = false;
                        }
                    }
                }
                else if (txtOptionName.Text != "")
                {
                    chkSysPmtFlag.Checked = false;
                }
            }

        }

        private void cdvOptionName_TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == false && ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)))
            {
                ClearData('7');
            }
        }


    }
}
