
using Miracom.CliFrx;
using System.Data;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using System.Diagnostics;
using Miracom.MsgHandler;
using Miracom.Stat;
using Miracom.MESCore;
using Miracom.TRSCore;
using Miracom.UI.Controls.MCCodeView;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinSchedule;

//#If _SPC = True Then
//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : modSPCFunctions.vb
//   Description : Common Function Definition Module
//
//   SPC Version : 1.0.0
//
//   Function List
//       - MakeErrorMsg() : Make error message
//       - FieldClear() : Control included field clear
//       - InitListView() : Clear Listview and Set Icon source
//       - InitSpread() : Set Spread Option
//       - FindListItem() : ListView?êÏÑú ?πÏ†ï Item??Ï∞æÎäî??
//       - ChangeDateFormat() : Change 8 byte DateTime format of UltraCalendarCombo
//       - ChangeTimeFormat() : Change 6 byte DateTime format of UltraDateTimeEditor
//       - MakeDateFormat() : ?ºÎ∞ò Î¨∏Ïûê?¥ÏùÑ Time Format?ºÎ°ú Î≥Ä??
//       - DestroyDateFormat() : ?†Ïßú ?ïÏãù??Î¨∏Ïûê?¥ÏùÑ ?ºÎ∞ò Î¨∏Ïûê?¥Î°ú Î≥Ä?òÌïú??
//       - GetIndexedControl() : parentControl ?ÑÏóê ?àÎäî ?ôÏùº??Prefix?¥Î¶Ñ??Í∞ÄÏß?controlÎßåÏùÑ ?¥Î¶Ñ?úÏúºÎ°??ïÎ†¨?òÏó¨ Î¶¨Ïä§?∏Î°ú ÎßåÎì†??
//       - PublishMsgTune() : Publish Message Tune
//       - ChangeFromDateFormat() : Change 14 byte DateTime format of DateTimePicker
//       - ChangeToDateFormat() : Change 14 byte DateTime format of DateTimePicker
//       - GetChildForm() : Child Form???àÎäîÏßÄ ?ïÏù∏?úÎã§
//       - GetChildMultiOnLineForm() : Set Child Multi On Line Form
//       - StartTimerProgress() : Start Timer
//       - StopTimerProgress() : Stop Timer
//       - SelectText() : Select Text of the TextBox
//       - ShowMsgBox() : Show Message Box
//       - CheckGRPCMFValue() : Check Group/Cmf Value
//       - FieldVisableStatus() : Change Field Visible
//       - CheckCMFKeyPress() : Check Cmf CodeView Key Press Event
//       - InitGRPCMFControl() : initial Group/Cmf Control
//       - ClearList() : Clear List Control
//       - SetEnumList() : Make Enum to List
//       - SetGraphList() : Set Graph Type List
//       - InitTreeView() : Init TreeView
//       - ProcGRPCMFButtonPress() : Process Group/Cmf CodeView Button Press Event
//       - FindListItemNextPartial() : Find List Item
//       - FindListItemPartial() : Find List Item
//       - SubtractString() : Subtract String
//       - SetRuleDescription() : Set Rule Description
//       - SPC_Publish_Data() : Get Scale
//       - SetDatabyGraphType() : Set Data by GraphType
//       - GetSpreadCol() : Get Spread Column
//       - ExportToExcel() : Export To Excel
//       - Client_Upgrade() : Client Upgrade
//       - GetHelpURL() : Get Help URL
//       - CheckSecurityFormControl() : Check Security Form Control
//       - CheckAvailableFunction() : Check Available Function
//       - AvailableFunctionList() : Available Function List
//       - SaveFilterKey() : Save Filter Key
//       - GetFilterKey() : Get Filter Key
//
//   Detail Description
//       -
//
//   History
//       -
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

namespace Miracom.SPCCore
{
    public sealed class modSPCFunctions
    {
        //    'Public Function GetChildOnLineForm(ByVal MDIForm As frmMDIMainCore, _
        //    '    ByVal ChartID As String, _
        //    '    Optional ByRef Chart As SPCControlChart.SPCControlChart = Nothing, _
        //    '    Optional ByRef cdvChartID As MCCodeView = Nothing) As Form
        //    '    Dim SForm As Form
        //    '    Dim iCount As Integer
        //    '    Dim i As Integer
        //    '    Try
        
        //    '        If Not (MDIForm.MdiChildren Is Nothing) Then
        //    '            For Each SForm In MDIForm.MdiChildren
        //    '                If SForm.Name.Trim.ToUpper = "frmSPCTranOnLineChart".ToUpper Then
        
        //    '                    If CType(SForm, frmSPCTranOnLineChart).cdvChartID.Text = ChartID And _
        //    '                        CType(SForm, frmSPCTranOnLineChart).btnMonitoring.Tag = "S" Then
        //    '                        'Active ???òÎäîÍ≤??òÏïÑ Î≥¥ÏûÑ
        //    '                        'SForm.Activate()
        //    '                        Return CType(SForm, frmSPCTranOnLineChart)
        
        //    '                    End If
        //    '                ElseIf SForm.Name.Trim.ToUpper = "frmSPCTranDynamicMultiChart".ToUpper Then
        //    '                    If CType(SForm, frmSPCTranDynamicMultiChart).btnMonitoring.Tag = "S" Then
        //    '                        For i = 0 To CType(SForm, frmSPCTranDynamicMultiChart).giCount - 1
        //    '                            If CType(SForm, frmSPCTranDynamicMultiChart).ChartList[i].ChartID = ChartID Then
        //    '                                Chart = CType(SForm, frmSPCTranDynamicMultiChart).ChartList[i].ChartObj
        //    '                                'Active ???òÎäîÍ≤??òÏïÑ Î≥¥ÏûÑ
        //    '                                'SForm.Activate()
        //    '                                Return CType(SForm, frmSPCTranDynamicMultiChart)
        //    '                            End If
        //    '                        Next
        //    '                    End If
        //    '                    'Í∏∞Ï°¥ Multi On-Line Chart
        //    '                    'ElseIf SForm.Name.Trim.ToUpper = "frmSPCTranMultiOnLineChart".ToUpper Then
        //    '                    '    If CType(SForm, frmSPCTranMultiOnLineChart).btnMonitoring.Tag = "S" Then
        //    '                    '        If CType(SForm, frmSPCTranMultiOnLineChart).cdvLeftTop_ChartID.Text = ChartID Then
        
        //    '                    '            cdvChartID = CType(SForm, frmSPCTranMultiOnLineChart).cdvLeftTop_ChartID
        //    '                    '            Chart = CType(SForm, frmSPCTranMultiOnLineChart).LeftTop_Chart
        //    '                    '            SForm.Activate()
        //    '                    '            Return CType(SForm, frmSPCTranMultiOnLineChart)
        
        //    '                    '        ElseIf CType(SForm, frmSPCTranMultiOnLineChart).cdvLeftBottom_ChartID.Text = ChartID Then
        
        //    '                    '            cdvChartID = CType(SForm, frmSPCTranMultiOnLineChart).cdvLeftBottom_ChartID
        //    '                    '            Chart = CType(SForm, frmSPCTranMultiOnLineChart).LeftBottom_Chart
        //    '                    '            SForm.Activate()
        //    '                    '            Return CType(SForm, frmSPCTranMultiOnLineChart)
        
        //    '                    '        ElseIf CType(SForm, frmSPCTranMultiOnLineChart).cdvRightTop_ChartID.Text = ChartID Then
        
        //    '                    '            cdvChartID = CType(SForm, frmSPCTranMultiOnLineChart).cdvRightTop_ChartID
        //    '                    '            Chart = CType(SForm, frmSPCTranMultiOnLineChart).RightTop_Chart
        //    '                    '            SForm.Activate()
        //    '                    '            Return CType(SForm, frmSPCTranMultiOnLineChart)
        
        //    '                    '        ElseIf CType(SForm, frmSPCTranMultiOnLineChart).cdvRightBottom_ChartID.Text = ChartID Then
        
        //    '                    '            cdvChartID = CType(SForm, frmSPCTranMultiOnLineChart).cdvRightBottom_ChartID
        //    '                    '            Chart = CType(SForm, frmSPCTranMultiOnLineChart).RightBottom_Chart
        //    '                    '            SForm.Activate()
        //    '                    '            Return CType(SForm, frmSPCTranMultiOnLineChart)
        
        //    '                    '        End If
        //    '                    '    End If
        //    '                End If
        
        //    '            Next SForm
        //    '        End If
        
        //    '    Catch ex As Exception
        //    '        ShowMsgBox("modSPCFunctions.SetChildMultiOnLineForm()" & vbCrLf & ex.Message)
        //    '    End Try
        
        //    '    Return Nothing
        
        //    'End Function
        
        //    ' StartTimerProgress()
        //    '       - Start Timer
        //    ' Return Value
        //    '       -
        //    ' Arguments
        //    '       -
        //    '
        
        //    ' GetHelpURL()
        //    '       - Get Help URL
        //    ' Return Value
        //    '       - Boolean : True of False
        //    ' Arguments
        //    '       -
        //    '
        //    Public Function GetHelpURL() As Boolean
        //        Dim Get_HelpURL_In As SPC_Get_HelpURL_In_Tag
        //        Dim Get_HelpURL_Out As SPC_Get_HelpURL_Out_Tag
        //        Dim sHelpURL As String
        
        //        Try
        //            Get_HelpURL_In.h_passport = gsPassport
        //            Get_HelpURL_In.h_language = gcLanguage
        //            Get_HelpURL_In.h_factory = gsFactory
        //            Get_HelpURL_In.h_user_id = gsUserID
        //            Get_HelpURL_In.h_password = gsPassWord
        //            Get_HelpURL_In.h_proc_step = '1'
        
        //            If gfrmMDI.ActiveForm.ActiveMdiChild Is Nothing Then
        //                Shell("explorer.exe D:\Document\MESplusV4_Doc\HTML\SPC_UserManual_Word\Output\WebWorks Help 5.0\SPC_UserManual_Word\index.html")
        //                Exit Function
        //            End If
        
        //            Get_HelpURL_In.func_name = gfrmMDI.ActiveMdiChild.Tag
        
        //            If SPCCaster.SPC_Get_HelpURL(Get_HelpURL_In, Get_HelpURL_Out) <> H101_SUCCESS Then
        //                ShowMsgBox(getH101Result().message)
        //                Return False
        //            End If
        //            If (Get_HelpURL_Out.h_status_value <> MP_SUCCESS_STATUS) Or (Get_HelpURL_Out.help_url = "") Then
        //                Shell("explorer.exe D:\Document\MESplusV4_Doc\HTML\SPC_UserManual_Word\Output\WebWorks Help 5.0\SPC_UserManual_Word\index.html")
        //            Else
        //                sHelpURL = "explorer.exe D:\Document\MESplusV4_Doc\HTML\SPC_UserManual_Word\Output\WebWorks Help 5.0\SPC_UserManual_Word\" & Get_HelpURL_Out.help_url
        //                Shell(sHelpURL)
        //            End If
        
        
        //        Catch ex As Exception
        //            ShowMsgBox("modSPCFunctions.GetHelpURL()" & vbCrLf & ex.Message)
        //        End Try
        
        //    End Function
        
        
        // GetIsIgnoreSpecError()
        //       - Get Ignore Spec Error Option
        // Return Value
        //       - Boolean : True of False
        // Arguments
        //        -
        //
  
        public static bool GetIsIgnoreSpecError()
        {
            
            try
            {
                return modSPCConstants.gbIgnoreSpecError;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modSPCFunctions.GetIsIgnoreSpecError()\n" + ex.Message);
                return false;
            }
            
        }
        
        // GetFilterKey()
        //       - Get Filtering Key
        // Return Value
        //       - String
        // Arguments
        //       -
        //
        public static string GetFilterKey()
        {
            
            try
            {
                string sFilterKey;
                sFilterKey = MPCF.GetRegSetting(Application.ProductName, "Filtering", "ChartID", "");
                
                return sFilterKey;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modSPCFunctions.GetFilterKey()\n" + ex.Message);
                return "";
            }
            
        }
        
        // SetEnumList()
        //       - Enum to List
        // Return Value
        //       -
        // Arguments
        //       - ByVal cboTarget As Infragistics.Win.UltraWinEditors.UltraComboEditor   :  Combo Box
        //       - ByVal enumType As Type        :  Type
        //
        public static void SetEnumList(Infragistics.Win.UltraWinEditors.UltraComboEditor cboTarget, Type enumType)
        {
            
            try
            {
                cboTarget.Items.Clear();
                string sEnumString = "";
                foreach (string tempLoopVar_sEnumString in Enum.GetNames(enumType))
                {
                    sEnumString = tempLoopVar_sEnumString;
                    cboTarget.Items.Add(sEnumString);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modSPCFunctions.SetEnumList()\n" + ex.Message);
            }
            
        }
        
        // SetGraphList()
        //       - Enum to List
        // Return Value
        //       -
        // Arguments
        //       - ByVal cboGraph As Infragistics.Win.UltraWinEditors.UltraComboEditor   :  Combo Box
        //
        public static void SetGraphList(Infragistics.Win.UltraWinEditors.UltraComboEditor cboGraph)
        {
            
            try
            {
                cboGraph.Items.Clear();
                int iGraphType;
                foreach (int tempLoopVar_iGraphType in Enum.GetValues(typeof(eGraphType)))
                {
                    iGraphType = tempLoopVar_iGraphType;
                    if (iGraphType != - 1)
                    {
                        cboGraph.Items.Add(MPCF.GetGraphType((Miracom.CliFrx.eGraphType)iGraphType, true));
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modSPCFunctions.SetGraphList()\n" + ex.Message);
            }
            
        }
        
        // SetDatabyGraphType()
        //       - Set data by graph type
        // Return Value
        //       -
        // Arguments
        //       -
        //
        public static void SetDatabyGraphType(FarPoint.Win.Spread.FpSpread spddata, eGraphType eType, int iSampleSize, int iValueCol1, int iAverageCol)
        {
            try
            {
                int i;
                switch (eType)
                {
                    case eGraphType.XBARR:
                        
                        spddata.Sheets[0].Columns[iValueCol1].Width = 60;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 60;
                        for (i = iValueCol1; i <= iValueCol1 + modSPCConstants.VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                            MPCR.SetNumberCell(spddata.Sheets[0].Columns[i]);
                        }
                        for (i = iValueCol1 + iSampleSize; i <= iValueCol1 + modSPCConstants.VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }
                        for (i = 0; i <= iSampleSize - 1; i++)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + i].Value = i + 1;
                        }
                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value", 0);
                        /*
                        if (iSampleSize == 1)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                        }
                        else
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0) + "(1 ~ " + iSampleSize.ToString() + ")";
                        }
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = MPCF.FindLanguage("Average", 0);
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = true;
                        break;
                    case eGraphType.XBARS:
                        
                        spddata.Sheets[0].Columns[iValueCol1].Width = 60;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 60;
                        for (i = iValueCol1; i <= iValueCol1 + modSPCConstants.VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                            MPCR.SetNumberCell(spddata.Sheets[0].Columns[i]);
                        }
                        for (i = iValueCol1 + iSampleSize; i <= iValueCol1 + modSPCConstants.VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }
                        for (i = 0; i <= iSampleSize - 1; i++)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + i].Value = i + 1;
                        }
                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value", 0);
                        /*
                        if (iSampleSize == 1)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                        }
                        else
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0) + "(1 ~ " + iSampleSize.ToString() + ")";
                        }
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = MPCF.FindLanguage("Average", 0);
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = true;
                        break;
                    case eGraphType.XRS:
                        
                        spddata.Sheets[0].Columns[iValueCol1].Width = 60;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 60;
                        for (i = iValueCol1; i <= iValueCol1 + modSPCConstants.VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                            MPCR.SetNumberCell(spddata.Sheets[0].Columns[i]);
                        }
                        for (i = iValueCol1 + iSampleSize; i <= iValueCol1 + modSPCConstants.VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }
                        for (i = 0; i <= iSampleSize - 1; i++)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + i].Value = i + 1;
                        }
                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "   " + MPCF.FindLanguage("Value", 0);
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = MPCF.FindLanguage("Average", 0);
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = false;
                        break;
                    case eGraphType.P:
                        
                        spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1].Value = MPCF.FindLanguage("Sample Size", 0) + " (n)";
                        spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + 1].Value = MPCF.FindLanguage("Defect Count", 0) + " (Pn)";
                        spddata.Sheets[0].Columns[iValueCol1].Width = 100;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 100;
                        for (i = iValueCol1; i <= iValueCol1 + modSPCConstants.VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                            MPCR.SetNumberCell(spddata.Sheets[0].Columns[i]);
                        }
                        for (i = iValueCol1 + 2; i <= iValueCol1 + modSPCConstants.VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }
                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value", 0);
                        /*
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = "P";
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = false;
                        break;
                    case eGraphType.PN:
                        
                        spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1].Value = MPCF.FindLanguage("Defect Count", 0) + " (Pn)";
                        spddata.Sheets[0].Columns[iValueCol1].Width = 100;
                        MPCR.SetNumberCell(spddata.Sheets[0].Columns[iValueCol1]);
                        
                        for (i = iValueCol1 + 1; i <= iValueCol1 + modSPCConstants.VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }
                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value", 0);
                        /*
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = "Pn";
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = false;
                        break;
                    case eGraphType.C:
                        
                        spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1].Value = MPCF.FindLanguage("Defect Count", 0) + " (C)";
                        spddata.Sheets[0].Columns[iValueCol1].Width = 100;
                        MPCR.SetNumberCell(spddata.Sheets[0].Columns[iValueCol1]);
                        
                        for (i = iValueCol1 + 1; i <= iValueCol1 + modSPCConstants.VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }
                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value", 0);
                        /*
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = "C";
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = false;
                        break;
                    case eGraphType.U:
                        
                        spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1].Value = MPCF.FindLanguage("Sample Size", 0) + " (n)";
                        spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + 1].Value = MPCF.FindLanguage("Defect Count", 0) + " (C)";
                        spddata.Sheets[0].Columns[iValueCol1].Width = 100;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 100;
                        MPCR.SetNumberCell(spddata.Sheets[0].Columns[iValueCol1]);
                        MPCR.SetNumberCell(spddata.Sheets[0].Columns[iValueCol1 + 1]);
                        
                        for (i = iValueCol1; i <= iValueCol1 + modSPCConstants.VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                        }
                        for (i = iValueCol1 + 2; i <= iValueCol1 + modSPCConstants.VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }
                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value", 0);
                        /*
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = "U";
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = false;
                        break;
                    case eGraphType.ZBARS:
                        
                        spddata.Sheets[0].Columns[iValueCol1].Width = 60;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 60;
                        for (i = iValueCol1; i <= iValueCol1 + modSPCConstants.VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                            MPCR.SetNumberCell(spddata.Sheets[0].Columns[i]);
                        }
                        for (i = iValueCol1 + iSampleSize; i <= iValueCol1 + modSPCConstants.VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }
                        for (i = 0; i <= iSampleSize - 1; i++)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + i].Value = i + 1;
                        }
                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = true;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = true;
                        MPCR.SetNumberCell(spddata.Sheets[0].Columns[iValueCol1 - 1]);
                        MPCR.SetNumberCell(spddata.Sheets[0].Columns[iValueCol1 - 2]);
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value", 0);
                        /*
                        if (iSampleSize == 1)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                        }
                        else
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0) + "(1 ~ " + iSampleSize.ToString() + ")";
                        }
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = true;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = MPCF.FindLanguage("Average", 0);
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol - 1].Value = MPCF.FindLanguage("Zbar", 0);
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = true;
                        break;
                    case eGraphType.DELTAS:
                        
                        spddata.Sheets[0].Columns[iValueCol1].Width = 60;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 60;
                        for (i = iValueCol1; i <= iValueCol1 + modSPCConstants.VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                            MPCR.SetNumberCell(spddata.Sheets[0].Columns[i]);
                        }
                        for (i = iValueCol1 + iSampleSize; i <= iValueCol1 + modSPCConstants.VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }
                        for (i = 0; i <= iSampleSize - 1; i++)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + i].Value = i + 1;
                        }
                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = true;
                        MPCR.SetNumberCell(spddata.Sheets[0].Columns[iValueCol1 - 2]);
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value", 0);
                        /*
                        if (iSampleSize == 1)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                        }
                        else
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0) + "(1 ~ " + iSampleSize.ToString() + ")";
                        }
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = true;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = MPCF.FindLanguage("Average", 0);
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol - 1].Value = MPCF.FindLanguage("Delta", 0);
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = true;
                        break;
                    case eGraphType.NULL:
                        
                        spddata.Sheets[0].Columns[iValueCol1].Width = 60;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 60;
                        for (i = iValueCol1; i <= iValueCol1 + modSPCConstants.VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                            MPCR.SetAsciiCell(spddata.Sheets[0].Columns[i]);
                        }
                        for (i = iValueCol1 + iSampleSize; i <= iValueCol1 + modSPCConstants.VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }
                        for (i = 0; i <= iSampleSize - 1; i++)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + i].Value = i + 1;
                        }
                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value", 0);
                        /*
                        if (iSampleSize == 1)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                        }
                        else
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0) + "(1 ~ " + iSampleSize.ToString() + ")";
                        }
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = MPCF.FindLanguage("Average", 0);
                        spddata.Sheets[0].Columns[iAverageCol].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = false;
                        break;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modSPCFunctions.SetDatabyGraphType()\n" + ex.Message);
            }
            
        }
        
        public static void SetValuePrompt(FarPoint.Win.Spread.FpSpread spddata, string sChartID, int iSampleSize, int iValueCol1)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Prompt_In");
                TRSNode out_node = new TRSNode("View_Prompt_Out");
                
                int i = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", MPCF.Trim(sChartID));

                if (MPCR.CallService("SPC", "SPC_View_Prompt", in_node, ref out_node, true) == false)
                {
                    return;
                }

                if (out_node.GetList("PRT_LIST").Count > 0)
                {
                    for (i = 0; i <= iSampleSize - 1; i++)
                    {
                        spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + i].Value = out_node.GetList("PRT_LIST")[i].GetString("PROMPT");
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modSPCFunctions.SetValuePrompt()\n" + ex.Message);
            }
            
        }
        
        // CheckAvailableFunction()
        //       - Check Available Function
        // Return Value
        //       - Boolean : True of False
        // Arguments
        //       - ByVal FuncName As String
        //
        public static bool CheckAvailableFunction(string FuncName)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Function_Detail_In");
                TRSNode out_node = new TRSNode("View_Function_Detail_Out");
                ArrayList a_list = new ArrayList();
                ArrayList aMenuList = new ArrayList();
                //int i;
                /* Updated By YJJung ±««— Check Ω√ Performance ¿ÃΩ¥∑Œ ¿Œ«ÿ, SEC_View_Function_Detail ∑Œ ∫Ø∞Ê */
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("PROGRAM_ID", MPGV.gsProgramID);
                in_node.AddString("FUNC_NAME", FuncName);

                //in_node.AddString("SEC_GRP_ID", MPGV.gsUserGroup);
                //in_node.AddString("NEXT_FUNC_NAME", "");

                if (MPCR.CallService("SEC", "SEC_View_Function_Detail", in_node, ref out_node, true) == false)
                {
                    return false;
                }
                return true;
                
                //do
                //{
                //    out_node = new TRSNode("View_Function_List_Out");
                //    if (MPCR.CallService("SEC", "SEC_View_Function_List", in_node, ref out_node) == false)
                //    {
                //        return false;
                //    }
                //    a_list.Add(out_node);
                    
                //    for (i = 0; i < out_node.GetList(0).Count; i++)
                //    {
                //        aMenuList.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("FUNC_NAME")));
                //    }
                //    in_node.SetString("NEXT_FUNC_NAME", out_node.GetString("NEXT_FUNC_NAME"));

                //} while (in_node.GetString("NEXT_FUNC_NAME") != "");

                // foreach (object obj in a_list)
                //{
                //    out_node = null;
                //    out_node = (TRSNode)obj;

                //    for (i = 0; i < out_node.GetList(0).Count; i++)
                //    {
                //        if (MPCF.Trim(out_node.GetList(0)[i].GetString("FUNC_NAME")) == MPCF.Trim(FuncName))
                //        {
                //            return true;
                //        }
                //    }
                // }
                /* Updated End */
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modSPCFunctions.CheckAvailableFunction()\n" + ex.Message);
            }
            
            return false;
            
        }
        
        // SaveFilterKey()
        //       - Save Filtering Key
        // Return Value
        //       -
        // Arguments
        //       - ByVal sFilterKey As String
        //
        public static void SaveFilterKey(string sFilterKey)
        {
            
            try
            {
                MPCF.SaveRegSetting(Application.ProductName, "Filtering", "ChartID", sFilterKey);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modSPCFunctions.SaveFilteringKey()\n" + ex.Message);
            }
            
        }
 

        // SPC_Publish_Data()
        //       -  Set Rule Description
        // Return Value
        //       -  Integer
        // Arguments
        //       - ByRef SPC_Publish_Data_In As SPC_Publish_Data_In_Tag
        //
        public static int SPC_Publish_Data(TRSNode node)
        {
            
            try
            {
                
                Form frmFindForm = null;
                MCCodeView cdvChartID = null;
                SPCControlChart.SPCControlChart Chart = null;
                udcChartInfo ctrlChartInfo = null;
                string sReceiveCode = "";

                sReceiveCode = node.GetInt("HIST_SEQ").ToString("000000") + node.GetInt("UNIT_SEQ").ToString("000") + MPCF.Trim(node.Passport) + MPCF.Trim(node.ProcStep);

                frmFindForm = GetChildOnLineForm((frmMDIMainCore)MPGV.gfrmMDI, node.GetString("CHART_ID"), sReceiveCode, ref Chart, ref cdvChartID, ref ctrlChartInfo);
                
                if (frmFindForm == null)
                {
                    return MPGC.MP_SUCCESS_STATUS;
                }
                
                if (frmFindForm is frmSPCTranOnLineChart)
                {
                    if ((node.ProcStep == MPGC.MP_STEP_CREATE && node.GetChar("BACK_FLAG") == 'Y') || node.ProcStep == MPGC.MP_STEP_DELETE || node.ProcStep == MPGC.MP_STEP_UPDATE || node.ProcStep == modSPCConstants.MP_STEP_INCLUDE_DATA)
                    {
                        if (((frmSPCTranOnLineChart) frmFindForm).ViewControlChartEvent() == false)
                        {
                            return MPGC.MP_FAIL_STATUS;
                        }
                    }
                    else
                    {

                        if (RefreshControlChart(node, ref Chart) == false)
                        {
                            return MPGC.MP_FAIL_STATUS;
                        }
                        ((frmSPCTranOnLineChart)frmFindForm).ChartRefreshEvent();
                       
                    }
                }
                else if (frmFindForm is frmSPCTranDynamicMultiChart || frmFindForm is frmSPCTranCollectLotDatabyCharacter || frmFindForm is frmSPCTranCollectResDatabyCharacter || frmFindForm is frmSPCTranCollectLotData || frmFindForm is frmSPCTranCollectResourceData )
                {
                    
                    if ((node.ProcStep == MPGC.MP_STEP_CREATE && node.GetChar("BACK_FLAG") == 'Y') || node.ProcStep == MPGC.MP_STEP_DELETE || node.ProcStep == MPGC.MP_STEP_UPDATE || node.ProcStep == modSPCConstants.MP_STEP_INCLUDE_DATA)
                    {
                        
                        if (frmFindForm is frmSPCTranDynamicMultiChart)
                        {
                            if (((frmSPCTranDynamicMultiChart) frmFindForm).ViewControlChartEvent(node.GetString("CHART_ID"), Chart) == false)
                            {
                                return MPGC.MP_FAIL_STATUS;
                            }
                        }
                        else
                        {
                            if (ctrlChartInfo.ViewControlChartEvent() == false)
                            {
                                return MPGC.MP_FAIL_STATUS;
                            }
                        }
                    }
                    else
                    {

                        if (RefreshControlChart(node, ref Chart) == false)
                        {
                            return MPGC.MP_FAIL_STATUS;
                        }
                        if (frmFindForm is frmSPCTranDynamicMultiChart)
                        {
                            ((frmSPCTranDynamicMultiChart)frmFindForm).ChartRefreshEvent(Chart);
                        }
                        else
                        {
                            ctrlChartInfo.ChartRefreshEvent();
                        }
                        
                    }
                }
                
                return MPGC.MP_SUCCESS_STATUS;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modSPCFunctions.SPC_Publish_Data()\n" + ex.Message);
                return MPGC.MP_FAIL_STATUS;
            }
            
        }
      
        
        // RefreshControlChart()
        //       -  Refresh Control Chart
        // Return Value
        //       -  Boolean : True of False
        // Arguments
        //       - ByRef SPC_Publish_Data_In As SPC_Publish_Data_In_Tag
        //       - ByRef Chart As SPCControlChart.SPCControlChart
        //
        public static bool RefreshControlChart(TRSNode node, ref SPCControlChart.SPCControlChart Chart)
        {
            
            try
            {
                string sGroupIndex;
                string sLotIndex;
                int iGroupIndex;
                int iLotIndex;
                double dUSL;
                double dLSL;
                double dUCL;
                double dCL;
                double dLCL;
                double dUCL2;
                double dCL2;
                double dLCL2;
                double dValue;
                double dXData;
                double dRdata;
                double dTarget;
                string sTranTime;
                string sXAxis;
                int i;
                
                dUSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dLSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dUCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dLCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dUCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                dCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                dLCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                dTarget = StatGlobalVariable.DOUBLE_NULL_DATA;

                if (MPCF.Trim(node.GetString("USL")) == "")
                {
                    dUSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                }
                else
                {
                    dUSL = MPCF.ToDbl(node.GetString("USL"));
                }
                if (MPCF.Trim(node.GetString("LSL")) == "")
                {
                    dLSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                }
                else
                {
                    dLSL = MPCF.ToDbl(node.GetString("LSL"));
                }
                
                if (MPCF.Trim(node.GetString("UCL")) == "")
                {
                    dUCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                }
                else
                {
                    dUCL = MPCF.ToDbl(node.GetString("UCL"));
                }
                if (MPCF.Trim(node.GetString("CL")) == "")
                {
                    dCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                }
                else
                {
                    dCL = MPCF.ToDbl(node.GetString("CL"));
                }
                if (MPCF.Trim(node.GetString("LCL")) == "")
                {
                    dLCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                }
                else
                {
                    dLCL = MPCF.ToDbl(node.GetString("LCL"));
                }
                if (MPCF.Trim(node.GetString("UCL2")) == "")
                {
                    dUCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                }
                else
                {
                    dUCL2 = MPCF.ToDbl(node.GetString("UCL2"));
                }
                if (MPCF.Trim(node.GetString("CL2")) == "")
                {
                    dCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                }
                else
                {
                    dCL2 = MPCF.ToDbl(node.GetString("CL2"));
                }
                if (MPCF.Trim(node.GetString("UCL2")) == "")
                {
                    dLCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                }
                else
                {
                    dLCL2 = MPCF.ToDbl(node.GetString("LCL2"));
                }
                
                iGroupIndex = MPCF.ToInt(Chart.ResvField2);
                iLotIndex = MPCF.ToInt(Chart.ResvField3);
                if (Chart.IsUserInputCL == true || Chart.ChartType == SPCControlChart.modEnums.GRAPH_TYPE.P || Chart.ChartType == SPCControlChart.modEnums.GRAPH_TYPE.U)
                {
                    iGroupIndex++;
                }
                sGroupIndex = "Group" + iGroupIndex.ToString("0000");
                if (Chart.ChartType != SPCControlChart.modEnums.GRAPH_TYPE.DELTAS)
                {
                    if (Chart.SetSpecLimit(sGroupIndex, dUSL, dLSL, dTarget) == false)
                    {
                        return false;
                    }
                }
                if (Chart.SetXControlLimit(sGroupIndex, dUCL, dCL, dLCL) == false)
                {
                    return false;
                }
                if (Chart.SetRControlLimit(sGroupIndex, dUCL2, dCL2, dLCL2) == false)
                {
                    return false;
                }
                
                sLotIndex = "Lot" + iLotIndex.ToString("0000");
                sTranTime = MPCF.Trim(node.GetString("TRAN_TIME"));
                if (MPCF.Trim(Chart.ResvField1) == "L")
                {
                    sXAxis = MPCF.Trim(node.GetString("LOT_ID"));
                }
                else
                {
                    sXAxis = MPCF.Trim(node.GetString("RES_ID"));
                }
                
                switch (Chart.ChartType)
                {
                    case SPCControlChart.modEnums.GRAPH_TYPE.XBARR:
                        
                        if ((MPCF.CheckNumeric(MPCF.Trim(node.GetString("AVERAGE"))) == true ? MPCF.Trim(node.GetString("AVERAGE")) : "") == "")
                        {
                            dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dXData = MPCF.ToDbl(node.GetString("AVERAGE"));
                        }
                        
                        if ((MPCF.CheckNumeric(MPCF.Trim(node.GetString("RANGE"))) == true ? MPCF.Trim(node.GetString("RANGE")) : "") == "")
                        {
                            dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dRdata = MPCF.ToDbl(node.GetString("RANGE"));
                        }
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.XBARS:
                        
                        if ((MPCF.CheckNumeric(MPCF.Trim(node.GetString("AVERAGE"))) == true ? MPCF.Trim(node.GetString("AVERAGE")) : "") == "")
                        {
                            dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dXData = MPCF.ToDbl(node.GetString("AVERAGE"));
                        }
                        
                        if ((MPCF.CheckNumeric(MPCF.Trim(node.GetString("STDDEV"))) == true ? MPCF.Trim(node.GetString("STDDEV")) : "") == "")
                        {
                            dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dRdata = MPCF.ToDbl(node.GetString("STDDEV"));
                        }
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.XRS:
                        
                        if ((MPCF.CheckNumeric(MPCF.Trim(node.GetString("AVERAGE"))) == true ? MPCF.Trim(node.GetString("AVERAGE")) : "") == "")
                        {
                            dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dXData = MPCF.ToDbl(node.GetString("AVERAGE"));
                        }
                        
                        if ((MPCF.CheckNumeric(MPCF.Trim(node.GetString("RANGE"))) == true ? MPCF.Trim(node.GetString("RANGE")) : "") == "")
                        {
                            dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dRdata = MPCF.ToDbl(node.GetString("RANGE"));
                        }
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.P:
                        
                        if ((MPCF.CheckNumeric(MPCF.Trim(node.GetString("AVERAGE"))) == true ? MPCF.Trim(node.GetString("AVERAGE")) : "") == "")
                        {
                            dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dXData = MPCF.ToDbl(node.GetString("AVERAGE"));
                        }
                        dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.PN:
                        
                        if ((MPCF.CheckNumeric(MPCF.Trim(node.GetString("AVERAGE"))) == true ? MPCF.Trim(node.GetString("AVERAGE")) : "") == "")
                        {
                            dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dXData = MPCF.ToDbl(node.GetString("AVERAGE"));
                        }
                        dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.C:
                        
                        if ((MPCF.CheckNumeric(MPCF.Trim(node.GetString("AVERAGE"))) == true ? MPCF.Trim(node.GetString("AVERAGE")) : "") == "")
                        {
                            dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dXData = MPCF.ToDbl(node.GetString("AVERAGE"));
                        }
                        dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.U:
                        
                        if ((MPCF.CheckNumeric(MPCF.Trim(node.GetString("AVERAGE"))) == true ? MPCF.Trim(node.GetString("AVERAGE")) : "") == "")
                        {
                            dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dXData = MPCF.ToDbl(node.GetString("AVERAGE"));
                        }
                        dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.ZBARS:
                        
                        if ((MPCF.CheckNumeric(MPCF.Trim(node.GetString("WEIGHT_VALUE"))) == true ? MPCF.Trim(node.GetString("WEIGHT_VALUE")) : "") == "")
                        {
                            dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dXData = MPCF.ToDbl(node.GetString("WEIGHT_VALUE"));
                        }
                        
                        if ((MPCF.CheckNumeric(MPCF.Trim(node.GetString("STDDEV"))) == true ? MPCF.Trim(node.GetString("STDDEV")) : "") == "")
                        {
                            dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dRdata = MPCF.ToDbl(node.GetString("STDDEV"));
                        }
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.DELTAS:
                        
                        if ((MPCF.CheckNumeric(MPCF.Trim(node.GetString("WEIGHT_VALUE"))) == true ? MPCF.Trim(node.GetString("WEIGHT_VALUE")) : "") == "")
                        {
                            dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dXData = MPCF.ToDbl(node.GetString("WEIGHT_VALUE"));
                        }

                        if ((MPCF.CheckNumeric(MPCF.Trim(node.GetString("STDDEV"))) == true ? MPCF.Trim(node.GetString("STDDEV")) : "") == "")
                        {
                            dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dRdata = MPCF.ToDbl(node.GetString("STDDEV"));
                        }
                        break;
                    default:
                        
                        dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                        dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                        break;
                }
                
                if (Chart.AddChartData(sGroupIndex, sLotIndex, MPCF.Trim(node.GetString("LOT_ID")), dXData, dRdata) == false)
                {
                    return false;
                }
                
                if (sTranTime != "")
                {
                    if (Chart.AddDate(sGroupIndex, sLotIndex, MPCF.ToInt(sTranTime.Substring(0, 4)), MPCF.ToInt(sTranTime.Substring(4, 2)), MPCF.ToInt(sTranTime.Substring(6, 2)), MPCF.ToInt(sTranTime.Substring(8, 2)), MPCF.ToInt(sTranTime.Substring(10, 2)), MPCF.ToInt(sTranTime.Substring(12, 2))) == false)
                    {
                        return false;
                    }
                }

                if (Chart.SetSequence(sGroupIndex, sLotIndex, node.GetInt("HIST_SEQ"), node.GetInt("UNIT_SEQ"), node.GetInt("EDC_COL_SEQ")) == false)
                {
                    return false;
                }
                
                if (MPCF.Trim(node.GetChar("OOC_TYPE")) != "" || MPCF.Trim(node.GetChar("OOC_TYPE2")) != "")
                {
                    if (Chart.SetRunTestFlag(sLotIndex, MPCF.Trim(node.GetChar("OOC_TYPE")), MPCF.Trim(node.GetChar("OOC_TYPE2"))) == false)
                    {
                        return false;
                    }
                }
                for (i = 0; i <= node.GetList(0).Count - 1; i++)
                {
                    if ((MPCF.CheckNumeric(MPCF.Trim(node.GetList(0)[i].GetString("VALUE"))) == true ? MPCF.Trim(node.GetList(0)[i].GetString("VALUE")) : "") == "")
                    {
                        dValue = StatGlobalVariable.DOUBLE_NULL_DATA;
                    }
                    else
                    {
                        dValue = MPCF.ToDbl(node.GetList(0)[i].GetString("VALUE"));
                    }
                    if (Chart.AddChartRawData(sGroupIndex, sLotIndex, sXAxis, dValue) == false)
                    {
                        return false;
                    }
                }
                
                iLotIndex++;

                Chart.ResvField2 = iGroupIndex.ToString();
                Chart.ResvField3 = iLotIndex.ToString();
                
                if (Chart.RefreshChartData() == false)
                {
                    return false;
                }
                
                //Chart.Refresh();
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modSPCFunctions.RefreshControlChart()\n" + ex.Message);
                return false;
            }
            
        }
        
        // GetChildMultiOnLineForm()
        //       -   Set Child Multi On Line Form
        // Return Value
        //       -
        // Arguments
        //       - ByVal MDIForm As frmMDIMainCore, ByVal ChartID As String
        //
        // History
        //       - Modified by JUHPETER : 20050817
        //
        public static Form GetChildOnLineForm(frmMDIMainCore MDIForm, string ChartID, string sReceiveCode, ref SPCControlChart.SPCControlChart Chart, ref MCCodeView cdvChartID, ref udcChartInfo ctrlChartInfo)
        {
            Form SForm;
            int i;
            
            try
            {
                
                if (!(MDIForm.MdiChildren == null))
                {
                    foreach (Form tempLoopVar_SForm in MDIForm.MdiChildren)
                    {
                        SForm = tempLoopVar_SForm;
                        
                        if (SForm.Name.ToUpper() == "frmSPCTranOnLineChart".ToUpper())
                        {

                            if (((frmSPCTranOnLineChart)SForm).cdvChartID.Text == ChartID && MPCF.Trim(((frmSPCTranOnLineChart)SForm).btnMonitoring.Tag) == "S" && ((frmSPCTranOnLineChart)SForm).Chart.ReceiveCode != sReceiveCode)
                            {
                                ((frmSPCTranOnLineChart) SForm).Chart.ReceiveCode = sReceiveCode;
                                Chart = ((frmSPCTranOnLineChart) SForm).Chart;
                                return ((frmSPCTranOnLineChart) SForm);
                            }
                        }
                        else if (SForm.Name.ToUpper() == "frmSPCTranDynamicMultiChart".ToUpper())
                        {
                            if (MPCF.Trim(((frmSPCTranDynamicMultiChart)SForm).btnMonitoring.Tag) == "S")
                            {
                                for (i = 0; i <= ((frmSPCTranDynamicMultiChart) SForm).giCount - 1; i++)
                                {
                                    if (((frmSPCTranDynamicMultiChart) SForm).ChartList[i].ChartID == ChartID && ((frmSPCTranDynamicMultiChart) SForm).ChartList[i].ChartObj.ReceiveCode != sReceiveCode)
                                    {
                                        ((frmSPCTranDynamicMultiChart) SForm).ChartList[i].ChartObj.ReceiveCode = sReceiveCode;
                                        Chart = ((frmSPCTranDynamicMultiChart) SForm).ChartList[i].ChartObj;
                                        return ((frmSPCTranDynamicMultiChart) SForm);
                                    }
                                }
                            }
                        }
                        else if (SForm.Name.ToUpper() == "frmSPCTranCollectLotDatabyCharacter".ToUpper())
                        {
                            Control ctl;
                            Control ctl1;
                            foreach (Control tempLoopVar_ctl in ((frmSPCTranCollectLotDatabyCharacter) SForm).tabChart.Controls)
                            {
                                ctl = tempLoopVar_ctl;
                                if (ctl is TabPage)
                                {
                                    foreach (Control tempLoopVar_ctl1 in ctl.Controls)
                                    {
                                        ctl1 = tempLoopVar_ctl1;
                                        if (ctl1 is udcChartInfo)
                                        {
                                            if (((udcChartInfo) ctl1).ChartID == ChartID && ((udcChartInfo) ctl1).Chart.ReceiveCode != sReceiveCode)
                                            {
                                                ((udcChartInfo) ctl1).Chart.ReceiveCode = sReceiveCode;
                                                ctrlChartInfo = (udcChartInfo) ctl1;
                                                Chart = ((udcChartInfo) ctl1).Chart;
                                                return ((frmSPCTranCollectLotDatabyCharacter) SForm);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (SForm.Name.ToUpper() == "frmSPCTranCollectResDatabyCharacter".ToUpper())
                        {
                            Control ctl;
                            Control ctl1;
                            foreach (Control tempLoopVar_ctl in ((frmSPCTranCollectResDatabyCharacter) SForm).tabChart.Controls)
                            {
                                ctl = tempLoopVar_ctl;
                                if (ctl is TabPage)
                                {
                                    foreach (Control tempLoopVar_ctl1 in ctl.Controls)
                                    {
                                        ctl1 = tempLoopVar_ctl1;
                                        if (ctl1 is udcChartInfo)
                                        {
                                            if (((udcChartInfo) ctl1).ChartID == ChartID && ((udcChartInfo) ctl1).Chart.ReceiveCode != sReceiveCode)
                                            {
                                                ((udcChartInfo) ctl1).Chart.ReceiveCode = sReceiveCode;
                                                ctrlChartInfo = (udcChartInfo) ctl1;
                                                Chart = ((udcChartInfo) ctl1).Chart;
                                                return ((frmSPCTranCollectResDatabyCharacter) SForm);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (SForm.Name.ToUpper() == "frmSPCTranCollectLotData".ToUpper())
                        {
                            if (((frmSPCTranCollectLotData)SForm).ctrlChartInfo.ViewChart == "Y")
                            {
                                if (((frmSPCTranCollectLotData)SForm).ctrlChartInfo.ChartID == ChartID && ((frmSPCTranCollectLotData)SForm).ctrlChartInfo.Chart.ReceiveCode != sReceiveCode)
                                {
                                    ((frmSPCTranCollectLotData)SForm).ctrlChartInfo.Chart.ReceiveCode = sReceiveCode;
                                    ctrlChartInfo = ((frmSPCTranCollectLotData)SForm).ctrlChartInfo;
                                    Chart = ((frmSPCTranCollectLotData)SForm).ctrlChartInfo.Chart;
                                    return ((frmSPCTranCollectLotData)SForm);
                                }
                            }
                        }
                        else if (SForm.Name.ToUpper() == "frmSPCTranCollectResourceData".ToUpper())
                        {
                            if (((frmSPCTranCollectResourceData) SForm).ctrlChartInfo.ChartID == ChartID && ((frmSPCTranCollectResourceData) SForm).ctrlChartInfo.Chart.ReceiveCode != sReceiveCode)
                            {
                                ((frmSPCTranCollectResourceData) SForm).ctrlChartInfo.Chart.ReceiveCode = sReceiveCode;
                                ctrlChartInfo = ((frmSPCTranCollectResourceData) SForm).ctrlChartInfo;
                                Chart = ((frmSPCTranCollectResourceData) SForm).ctrlChartInfo.Chart;
                                return ((frmSPCTranCollectResourceData) SForm);
                            }
                        }
                        
                    }
                    
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modSPCFunctions.GetChildOnLineForm()\n" + ex.Message);
            }
            
            return null;
            
        }
        
        public static string ConvertAscii(string sData)
        {
            
            try
            {
                string sReturn = "";
                int i;
                int iAsc;
                
                for (i = 0; i <= sData.Length - 1; i++)
                {
                    iAsc = (int)sData[i];
                    if (iAsc < 0)
                    {
                        sReturn += "M";
                        sReturn += ((int)(iAsc * - 1)).ToString("X");
                    }
                    else
                    {
                        sReturn += "P";
                        sReturn += iAsc.ToString("X");
                    }
                }
                
                return sReturn;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modSPCFunctions.ConvertAscii()\n" + ex.Message);
                return null;
            }
            
        }

    
        public static string ConvertCharCode(string sData)
        {
            
            try
            {
                string sReturn = "";
                string[] sArray = sData.Split('|');
                int i = 0;
                
                for (i = 0; i <= sArray.Length - 1; i++)
                {
                    sReturn += MPCF.ToChar(sArray[i]);
                }
                
                return sReturn;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("ConvertCharCode.ConvertCharCode()\n" + ex.Message);
                return null;
            }
            
        }
        
    }
    
    
    //#End If
    
}
