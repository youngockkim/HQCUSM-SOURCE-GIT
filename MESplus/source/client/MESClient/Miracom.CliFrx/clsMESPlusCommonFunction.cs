//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : MPCF.vb
//   Description : Client Common function Module
//
//   MES Version : 4.1.0.0
//
//   Function List
//        - ByteLen() : Get byte length in String
//        - ByteMid() : Get Middle String at byte length in String
//       - ChangeDateFormat() :Change 14 byte DateTime format of DateTimePicker (YYYYMMDDHHMMSS)
//        - CheckMaxLength() : check byte text length in TextBox
//       - CheckValue() :  Check the value is correct
//        - ClearList() : Clear List Control
//       - DestroyDateFormat() : Transform Date Format to String format
//       - ExportToExcel() : Export Data of Control to Excel Application Data
//       - ExportToText() : Export Data of Control to Tab Text Data
//       - FieldClear() : Clear data of the control which is located in specified form
//       - FieldVisableStatus() : Visable or Unvisable control
//       - FindListItem() : Find Item from Listview (?뱀젙 臾몄옄?닿낵 ?꾩쟾??留ㅼ튂?섎뒗 Item??李얜뒗??)
//       - FindListItemPartial() : Listview?먯꽌 ?뱀젙 臾몄옄?대줈 ?쒖옉?섎뒗 Item??李얜뒗??
//        - FindTreeNode() : Find Tree Node
//        - FindTreeNodeIndex() : Find Tree Node Index
//        - GetIndexedControl() : parentControl???щ씪媛 ?덈뒗 ?숈씪??Prefix?대쫫??Control?ㅼ쓽 由ъ뒪?몃? 留뚮뱺??
//       - InitListView() : Initialize Listview control
//       - listViewToExcel() : Export Data of Listview Control to Excel Application Data
//       - MakeDateFormat() :Transform String Format to Date Format (YYYY/MM/DD hh:mm:ss)
//       - MakeErrorMsg() : Make Transaction Error Message
//       - ShowMsgBox() : Show Message Box by Modal
//       - SubtractString() : Subtract String
//       - FieldVisible() : Field??Control?ㅼ쓣 ?④릿??
//       - GetChildForm() : Child Form???덈뒗吏 ?뺤씤 ??李쎌쓣 ?꾩슫??
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-07 : Created by SKJIN
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;
using System.Net;
using System.Management;
using System.Security.Principal;

using Microsoft.Win32;
using Miracom.UI.Controls.MCCodeView;
using Infragistics.Shared;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinSchedule;

using System.Runtime.InteropServices;

using Miracom.TRSCore;
using FarPoint.Win.Spread.CellType;


namespace Miracom.CliFrx
{
    public sealed class MPCF
    {
        [DllImportAttribute("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);

        [DllImport("user32.dll")]
        private static extern uint GetGuiResources(IntPtr hProcess, uint uiFlags);

        public static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }

        public static int GetCurrentGDICount()
        {
            uint ui;
            Process ps = Process.GetCurrentProcess();

            ui = GetGuiResources(ps.Handle, 0);
            return Convert.ToInt32(ui);
        }

        private static clsLanguageFunction cLangFunction = new clsLanguageFunction();

        public static bool ToClientLanguage(Form l_form)
        {
            return cLangFunction.ToClientLanguage(l_form);
        }

        public static bool ToClientLanguage(Menu.MenuItemCollection mnuItems)
        {
            return cLangFunction.ToClientLanguage(mnuItems);
        }

        public static bool ConvertMessage(System.Windows.Forms.Control.ControlCollection colControl)
        {
            return cLangFunction.ConvertMessage(colControl);
        }
        public static string FindLanguage(string S, CAPTION_TYPE captionType)
        {
            return cLangFunction.FindLanguage(S, captionType);
        }
        public static string FindLanguage(string S, int iType)
        {
            return cLangFunction.FindLanguage(S, iType);
        }

        public static string GetMessage(int i)
        {
            return cLangFunction.GetMessage(i);
        }

        public static bool LoadMessageResource(string sMessageFile)
        {
            return cLangFunction.LoadMessageResource(sMessageFile);

        }

        public static bool LoadCaptionResource(string sCaptionFile)
        {
            return cLangFunction.LoadCaptionResource(sCaptionFile);
        }

        //
        // ShowMsgBox()
        //       - Show Message box by Modal
        // Return Value
        //       -
        // Arguments
        //       - ByVal S As String : Message string to show
        //       - Optional ByVal Buttons As MessageBoxButtons : Message box button type
        //       - Optional ByVal DefaultFocus As Integer : Default focused button
        //
        public static System.Windows.Forms.DialogResult ShowMsgBox(string S)
        {
            return ShowMsgBox(S, MPGV.gfrmMDI, Application.ProductName, MessageBoxButtons.OK, 1);
        }

        public static System.Windows.Forms.DialogResult ShowMsgBox(string S, MessageBoxButtons Buttons, int DefaultFocus)
        {
            return ShowMsgBox(S, MPGV.gfrmMDI, Application.ProductName, Buttons, DefaultFocus);
        }

        public static System.Windows.Forms.DialogResult ShowMsgBox(string S, string Caption, MessageBoxButtons Buttons, int DefaultFocus)
        {
            return ShowMsgBox(S, MPGV.gfrmMDI, Caption, Buttons, DefaultFocus);
        }

        public static System.Windows.Forms.DialogResult ShowMsgBox(string S, Form owner, string Caption, MessageBoxButtons Buttons, int DefaultFocus)
        {
            try
            {
                if (MPGV.gbShowMsgFlag == false)
                {
                    if (S == MPCF.GetMessage(52))
                    {
                        MPGV.gIMdiForm.SetStatusMessage(S);
                        return DialogResult.None;
                    }
                }

                System.Windows.Forms.DialogResult retValue;
                frmMessageBox frmMsg = new frmMessageBox();

                frmMsg.Owner = owner;
                retValue = frmMsg.Show(S, Caption, Buttons, DefaultFocus, owner);
                frmMsg.Owner = null;
                frmMsg = null;

                return retValue;

            }
            catch (Exception ex)
            {
                ShowMsgBox("MPCF.ShowMsgBox()\n" + ex.Message);
                return DialogResult.None;
            }
        }

        public static System.Windows.Forms.DialogResult ShowMsgBox(ReturnMessageString MsgString)
        {
            return ShowMsgBox(MsgString, MPGV.gfrmMDI, Application.ProductName, MessageBoxButtons.OK, 1);
        }

        public static System.Windows.Forms.DialogResult ShowMsgBox(ReturnMessageString MsgString, MessageBoxButtons Buttons, int DefaultFocus)
        {
            return ShowMsgBox(MsgString, MPGV.gfrmMDI, Application.ProductName, Buttons, DefaultFocus);
        }

        public static System.Windows.Forms.DialogResult ShowMsgBox(ReturnMessageString MsgString, string Caption, MessageBoxButtons Buttons, int DefaultFocus)
        {
            return ShowMsgBox(MsgString, MPGV.gfrmMDI, Caption, Buttons, DefaultFocus);
        }

        public static System.Windows.Forms.DialogResult ShowMsgBox(ReturnMessageString MsgString, Form owner, string Caption, MessageBoxButtons Buttons, int DefaultFocus)
        {
            try
            {
                frmMessageBox frmMsg = new frmMessageBox();
                System.Windows.Forms.DialogResult retValue;

                frmMsg.Owner = owner;
                retValue = frmMsg.Show(MsgString, Caption, Buttons, DefaultFocus, owner);

                MsgString = null;
                frmMsg.Owner = null;
                frmMsg = null;

                return retValue;
            }
            catch (Exception ex)
            {
                ShowMsgBox("MPCF.ShowMsgBox()\n" + ex.Message);
                return DialogResult.None;
            }
        }

        //
        // MakeErrorMsg()
        //       - Make error message
        // Return Value
        //       - clsMsgString : Return Error Message Class
        // Arguments
        //       - error_msg as String  : Error Message
        //       - db_error_msg as String : DB Error Message
        //       - key_msg1 as String : Key Message 1
        //       - key_msg2 as String : Key Message 2
        //       - key_msg3 as String : Key Message 3
        //
        public static ReturnMessageString MakeErrorMsg(TRSNode out_node)
        {
            return MakeErrorMsg(out_node.MsgCode, out_node.Msg, out_node.DBErrMsg, out_node.FieldMsg, MSGBOX_ICON_TYPE.NONE);
        }

        public static ReturnMessageString MakeErrorMsg(string Msg_Code, string error_msg, string db_error_msg, TRSNode field_msg)
        {
            return MakeErrorMsg(Msg_Code, error_msg, db_error_msg, field_msg, MSGBOX_ICON_TYPE.NONE);
        }

        public static ReturnMessageString MakeErrorMsg(string Msg_Code, string error_msg, string db_error_msg, TRSNode field_msg, MSGBOX_ICON_TYPE icon_type)
        {
            ReturnMessageString MsgString = new ReturnMessageString();

            try
            {
                MsgString.IsServerMsgFlag = true;
                MsgString.IsNodeMsgFlag = true;
                MsgString.MsgCode = MPCF.Trim(Msg_Code);
                MsgString.ErrorMsg = MPCF.Trim(error_msg);
                MsgString.DBErrorMsg = MPCF.Trim(db_error_msg);
                MsgString.MsgBoxIconType = icon_type;

                if (field_msg != null && field_msg.MemberCount > 0)
                {
                    MsgString.SetFieldMsg = field_msg;
                }
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex.Message);
            }

            return MsgString;
        }

        //********************************************************************
        //*
        //*  Function Name   :   InitListView
        //*
        //*  File Name       :   MPlusCOMN00.bas
        //*
        //*  Program ID      :   MES
        //*
        //*  Description     :   Clear Listview and Set Icon source
        //*
        //*  Input Parameter :   MyListView as ListView
        //*
        //*  Output Value    :   None
        //*
        //*  Special Logic Notes :
        //*
        //*  Modification History    :
        //*
        //*  VERSION     DATE            AUTHOR      DESCRIPTION
        //*  ---------   -------------   ----------  ---------------
        //*  V1.0.0      June 30, 2001   SK Jin      Create
        //*
        //*******************************************************************
        public static void InitListView(ListView MyListView)
        {
            MyListView.Items.Clear();
            MyListView.View = System.Windows.Forms.View.Details;
            MyListView.FullRowSelect = true;
            MyListView.HideSelection = false;
            MyListView.GridLines = MPGV.gbGridFlag;
            if (MPGV.gIMdiForm != null && MPGV.gIMdiForm.GetSmallIconList() != null)
            {
                if (MyListView.SmallImageList == null)
                {
                    MyListView.SmallImageList = MPGV.gIMdiForm.GetSmallIconList();
                    MyListView.SmallImageList.Tag = "LOADED";
                }
                else if (MPCF.Trim(MyListView.SmallImageList.Tag) != "LOADED")
                {
                    MyListView.SmallImageList = MPGV.gIMdiForm.GetSmallIconList();
                    MyListView.SmallImageList.Tag = "LOADED";
                }
            }
            else
            {
                MyListView.SmallImageList = null;
            }
        }

        public static void InitTreeView(TreeView MyTreeView)
        {
            MyTreeView.Nodes.Clear();
            MyTreeView.FullRowSelect = true;
            MyTreeView.HideSelection = false;
            if (MPGV.gIMdiForm != null && MPGV.gIMdiForm.GetSmallIconList() != null)
            {
                MyTreeView.ImageList = MPGV.gIMdiForm.GetSmallIconList();
            }
            else
            {
                MyTreeView.ImageList = null;
            }
        }

        //
        // MakeDateFormat()
        //        - 일반 문자열을 Time Format으로 변환
        // Return Value
        //       - String : Return Get Time Format
        // Arguments
        //       - ByVal Fmt As FORMAT : Format (STANDARD, SYSTEM_FORMAT)
        //       - Optional ByVal DateTimeFormat As DATE_TIME_FORMAT : Time format ("YYYYMMDDHHMMSS", "YYYYMMDD", "HHMMSS")
        //
        public static string MakeDateFormat(string S)
        {
            return MakeDateFormat(S, DATE_TIME_FORMAT.NONE);
        }
        public static string MakeDateFormat(string S, DATE_TIME_FORMAT DateTimeFormat)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            string sReturn = "";
            DateTime dt;

            try
            {
                if (string.IsNullOrEmpty(S) == true) return "";

                S = MPCF.Trim(S);
                if (S == "") return "";

                if (DateTimeFormat == DATE_TIME_FORMAT.NONE)
                {
                    DateTimeFormat = MPGV.geDateTimeFormat;
                }

                //Length Validation
                if (DateTimeFormat == DATE_TIME_FORMAT.DATETIME)
                {
                    if (S.Length < 14)
                    {
                        sReturn = "";
                        return sReturn;
                    }
                    else if (S.Length > 14)
                    {
                        S = S.Substring(0, 14);
                    }
                }

                if (DateTimeFormat == DATE_TIME_FORMAT.DATE)
                {
                    // 2007.01.16. Aiden Koo
                    // 문자열의 개수가 반드시 8일 필요는 없다.
                    if (S.Length < 8)
                    {
                        sReturn = "";
                        return sReturn;
                    }
                    else if (S.Length > 8)
                    {
                        S = S.Substring(0, 8);
                    }
                }

                if (DateTimeFormat == DATE_TIME_FORMAT.TIME)
                {
                    // 2007.01.16. Aiden Koo
                    // 문자열의 개수가 반드시 6일 필요는 없다.
                    if (S.Length < 6)
                    {
                        sReturn = "";
                        return sReturn;
                    }
                    else if (S.Length > 6)
                    {
                        S = S.Substring(0, 6);
                    }
                }

                switch (MPGV.geLanguageFormat)
                {
                    case LANG_FORMAT.STANDARD:

                        switch (DateTimeFormat)
                        {
                            case DATE_TIME_FORMAT.DATETIME: //DateTime (YYYY/MM/DD/ hh:mm:ss)

                                sReturn = S.Substring(0, 4) + MPGV.gsDateDelimiter + S.Substring(4, 2) + MPGV.gsDateDelimiter + S.Substring(6, 2) + " " + S.Substring(8, 2) + ":" + S.Substring(10, 2) + ":" + S.Substring(12, 2);
                                break;
                            case DATE_TIME_FORMAT.DATE: //Date (YYYY/MM/DD)

                                sReturn = S.Substring(0, 4) + MPGV.gsDateDelimiter + S.Substring(4, 2) + MPGV.gsDateDelimiter + S.Substring(6, 2);
                                break;
                            case DATE_TIME_FORMAT.TIME: //Time (hh:mm:ss)

                                sReturn = S.Substring(0, 2) + ":" + S.Substring(2, 2) + ":" + S.Substring(4, 2);
                                break;
                            default:

                                sReturn = "";
                                break;
                        }
                        break;

                    case LANG_FORMAT.SYSTEM:

                        dt = ToDate(S);

                        switch (DateTimeFormat)
                        {
                            case DATE_TIME_FORMAT.DATETIME:

                                sReturn = dt.ToString(ci.DateTimeFormat.ShortDatePattern) + " " + dt.ToString(ci.DateTimeFormat.LongTimePattern);
                                break;
                            case DATE_TIME_FORMAT.DATE:

                                sReturn = dt.ToString(ci.DateTimeFormat.ShortDatePattern);
                                break;
                            case DATE_TIME_FORMAT.TIME:

                                sReturn = dt.ToString(ci.DateTimeFormat.LongTimePattern);
                                break;
                            default:

                                sReturn = "";
                                break;
                        }
                        break;

                    default:
                        sReturn = S;
                        break;
                }

                return sReturn;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        /// <summary>
        /// 문자열을 시스템의 언어형태에 맞게 변경한다.
        /// </summary>
        /// <param name="S">변경할 날짜의 문자열 형태 변수 명</param>
        /// <returns>변경된 문자열</returns>
        public static string DestroyDateFormat(string S)
        {
            return DestroyDateFormat(S, DATE_TIME_FORMAT.NONE);
        }
        /// <summary>
        /// 문자열을 시스템의 언어형태에 따라 지정된 Format 형태로 변경한다
        /// </summary>
        /// <param name="S">변경할 날짜의 문자열 형태 변수 명</param>
        /// <param name="DateTimeFormat">변경할 DateTime Format</param>
        /// <returns>변경된 문자열</returns>
        public static string DestroyDateFormat(string S, DATE_TIME_FORMAT DateTimeFormat)
        {
            string sDateTime = "";
            DateTime dt;

            try
            {
                S = Trim(S);
                if (S == "")
                    return "";

                if (DateTimeFormat == DATE_TIME_FORMAT.NONE)
                {
                    DateTimeFormat = MPGV.geDateTimeFormat;
                }

                if (MPGV.geLanguageFormat == LANG_FORMAT.STANDARD || MPGV.geLanguageFormat == LANG_FORMAT.SYSTEM)
                {
                    dt = Convert.ToDateTime(S);

                    switch (DateTimeFormat)
                    {
                        case DATE_TIME_FORMAT.DATETIME:
                            sDateTime = MPCF.ToStandardTime(dt, MPGC.MP_CONVERT_DATETIME_FORMAT);
                            break;
                        case DATE_TIME_FORMAT.DATE:
                            sDateTime = MPCF.ToStandardTime(dt, MPGC.MP_CONVERT_DATE_FORMAT);
                            break;
                        case DATE_TIME_FORMAT.TIME:
                            sDateTime = MPCF.ToStandardTime(dt, MPGC.MP_CONVERT_TIME_FORMAT);
                            break;
                    }
                }
                else
                {
                    sDateTime = S;
                }

                return sDateTime;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        //********************************************************************
        //*
        //*  Function Name   :   FindListItem
        //*
        //*  File Name       :   MPlusCOMN00.bas
        //*
        //*  Program ID      :   MES
        //*
        //*  Description     :   ?뱀젙 Item??Listview?먯꽌 李얠븘?몃떎.
        //*
        //*  Input Parameter :   MyListView as ListView
        //*                      Item as String
        //*
        //*  Output Value    :   True / False
        //*
        //*  Special Logic Notes :
        //*
        //*  Modification History    :
        //*
        //*  VERSION     DATE            AUTHOR      DESCRIPTION
        //*  ---------   -------------   ----------  ---------------
        //*  V1.0.0      June 30, 2001   SK Jin      Create
        //*
        //*******************************************************************
        public static bool FindListItem(ListView MyListView, string Item, bool bUpperCase)
        {
            int index;

            if (Trim(Item) == "")
            {
                return false;
            }

            Item = Trim(Item);

            for (index = 0; index < MyListView.Items.Count; index++)
            {
                if (bUpperCase == true)
                {
                    if (Trim(MyListView.Items[index].Text).ToUpper() == Item.ToUpper())
                    {
                        MyListView.Items[index].Selected = true;
                        MyListView.Items[index].EnsureVisible();
                        return true;
                    }
                }
                else
                {
                    if (Trim(MyListView.Items[index].Text) == Item)
                    {
                        MyListView.Items[index].Selected = true;
                        MyListView.Items[index].EnsureVisible();
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool FindListItem(ListView MyListView, string Item, int i_columnIndex, bool bUpperCase)
        {
            int index;

            if (Trim(Item) == "")
            {
                return false;
            }

            Item = Trim(Item);

            for (index = 0; index < MyListView.Items.Count; index++)
            {
                if (bUpperCase == true)
                {
                    if (Trim(MyListView.Items[index].SubItems[i_columnIndex].Text).ToUpper() == Item.ToUpper())
                    {
                        MyListView.Items[index].Selected = true;
                        MyListView.Items[index].EnsureVisible();
                        return true;
                    }
                }
                else
                {
                    if (Trim(MyListView.Items[index].SubItems[i_columnIndex].Text) == Item)
                    {
                        MyListView.Items[index].Selected = true;
                        MyListView.Items[index].EnsureVisible();
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool FindListItem(ListView MyListView, string Item1, int i_columnIndex1, string Item2, int i_columnIndex2, bool bUpperCase)
        {
            int index;

            if (Trim(Item1) == "" || Trim(Item2) == "")
            {
                return false;
            }

            Item1 = Trim(Item1);
            Item2 = Trim(Item2);

            for (index = 0; index < MyListView.Items.Count; index++)
            {
                if (bUpperCase == true)
                {
                    if (Trim(MyListView.Items[index].SubItems[i_columnIndex1].Text).ToUpper() == Item1.ToUpper() &&
                        Trim(MyListView.Items[index].SubItems[i_columnIndex2].Text).ToUpper() == Item2.ToUpper())
                    {
                        MyListView.Items[index].Selected = true;
                        MyListView.Items[index].EnsureVisible();
                        return true;
                    }
                }
                else
                {
                    if (Trim(MyListView.Items[index].SubItems[i_columnIndex1].Text) == Item1 &&
                        Trim(MyListView.Items[index].SubItems[i_columnIndex2].Text) == Item2)
                    {
                        MyListView.Items[index].Selected = true;
                        MyListView.Items[index].EnsureVisible();
                        return true;
                    }
                }
            }

            return false;
        }

        public static int FindListItemIndex(ListView MyListView, string Item, bool bUpperCase)
        {
            int index;

            if (Trim(Item) == "")
            {
                return -1;
            }

            Item = Trim(Item);

            for (index = 0; index < MyListView.Items.Count; index++)
            {
                if (bUpperCase == true)
                {
                    if (Trim(MyListView.Items[index].Text).ToUpper() == Item.ToUpper())
                    {
                        return index;
                    }
                }
                else
                {
                    if (Trim(MyListView.Items[index].Text) == Item)
                    {
                        return index;
                    }
                }

            }

            return -1;
        }

        public static int FindListItemIndex(ListView MyListView, string Item, int i_columnIndex, bool bUpperCase)
        {
            int index;

            if (Trim(Item) == "")
            {
                return -1;
            }

            Item = Trim(Item);

            for (index = 0; index < MyListView.Items.Count; index++)
            {
                if (bUpperCase == true)
                {
                    if (Trim(MyListView.Items[index].SubItems[i_columnIndex].Text).ToUpper() == Item.ToUpper())
                    {
                        return index;
                    }
                }
                else
                {
                    if (Trim(MyListView.Items[index].SubItems[i_columnIndex].Text) == Item)
                    {
                        return index;
                    }
                }
            }

            return -1;
        }

        public static int FindListItemIndex(ListView MyListView, string Item1, int i_columnIndex1, string Item2, int i_columnIndex2, bool bUpperCase)
        {
            int index;

            if (Trim(Item1) == "" || Trim(Item2) == "")
            {
                return -1;
            }

            Item1 = Trim(Item1);
            Item2 = Trim(Item2);

            for (index = 0; index < MyListView.Items.Count; index++)
            {
                if (bUpperCase == true)
                {
                    if (Trim(MyListView.Items[index].SubItems[i_columnIndex1].Text).ToUpper() == Item1.ToUpper() &&
                        Trim(MyListView.Items[index].SubItems[i_columnIndex2].Text).ToUpper() == Item2.ToUpper())
                    {
                        return index;
                    }
                }
                else
                {
                    if (Trim(MyListView.Items[index].SubItems[i_columnIndex1].Text) == Item1 &&
                        Trim(MyListView.Items[index].SubItems[i_columnIndex2].Text) == Item2)
                    {
                        return index;
                    }
                }
            }

            return -1;
        }

        //********************************************************************
        //*
        //*  Function Name   :   FieldClear
        //*
        //*  File Name       :   MPlusCOMN00.bas
        //*
        //*  Program ID      :   MES
        //*
        //'*  Description     :   특정 form안의 내용을 지우고 초기화 한다.
        //*
        //*  Input Parameter :   f as Form
        //'*                      ExceptCtl1 as Control -초기화에서 제외되는 컨트롤
        //'*                      ExceptCtl2 as Control -초기화에서 제외되는 컨트롤
        //'*                      ExceptCtl3 as Control -초기화에서 제외되는 컨트롤
        //'*                      ExceptCtl4 as Control -초기화에서 제외되는 컨트롤
        //'*                      ExceptCtl5 as Control -초기화에서 제외되는 컨트롤
        //*
        //*  Output Value    :   None
        //*
        //*  Special Logic Notes :
        //*
        //*  Modification History    :
        //*
        //*  VERSION     DATE            AUTHOR      DESCRIPTION
        //*  ---------   -------------   ----------  ---------------
        //*  V1.0.0      June 30, 2001   SK Jin      Create
        //*  V1.0.1      Oct 12, 2002    CM Koo      Modify
        //*
        //*******************************************************************
        public static bool FieldClear(object ctrl)
        {
            return FieldClear(ctrl, null, null, null, null, null, false);
        }
        public static bool FieldClear(object ctrl, bool bItemsClear)
        {
            return FieldClear(ctrl, null, null, null, null, null, bItemsClear);
        }
        public static bool FieldClear(object ctrl, object ExceptCtl1)
        {
            return FieldClear(ctrl, ExceptCtl1, null, null, null, null, false);
        }
        public static bool FieldClear(object ctrl, object ExceptCtl1, bool bItemsClear)
        {
            return FieldClear(ctrl, ExceptCtl1, null, null, null, null, bItemsClear);
        }
        public static bool FieldClear(object ctrl, object ExceptCtl1, object ExceptCtl2)
        {
            return FieldClear(ctrl, ExceptCtl1, ExceptCtl2, null, null, null, false);
        }
        public static bool FieldClear(object ctrl, object ExceptCtl1, object ExceptCtl2, object ExceptCtl3)
        {
            return FieldClear(ctrl, ExceptCtl1, ExceptCtl2, ExceptCtl3, null, null, false);
        }
        public static bool FieldClear(object ctrl, object ExceptCtl1, object ExceptCtl2, object ExceptCtl3, object ExceptCtl4)
        {
            return FieldClear(ctrl, ExceptCtl1, ExceptCtl2, ExceptCtl3, ExceptCtl4, null, false);
        }
        public static bool FieldClear(object ctrl, object ExceptCtl1, object ExceptCtl2, object ExceptCtl3, object ExceptCtl4, object ExceptCtl5, bool bItemsClear)
        {
            object control;
            int i;
            bool b_except;

            control = null;

            System.Windows.Forms.Control f = (System.Windows.Forms.Control)ctrl;

            for (i = 0; i < f.Controls.Count; i++)
            {
                b_except = false;

                control = f.Controls[i];

                if (ExceptCtl1 != null)
                {
                    if (ExceptCtl1 == control)
                    {
                        b_except = true;
                    }
                    else
                    {
                        b_except = false;
                    }
                }
                if (b_except == false && ExceptCtl2 != null)
                {
                    if (ExceptCtl2 == control)
                    {
                        b_except = true;
                    }
                    else
                    {
                        b_except = false;
                    }
                }
                if (b_except == false && ExceptCtl3 != null)
                {
                    if (ExceptCtl3 == control)
                    {
                        b_except = true;
                    }
                    else
                    {
                        b_except = false;
                    }
                }

                if (b_except == false && ExceptCtl4 != null)
                {
                    if (ExceptCtl4 == control)
                    {
                        b_except = true;
                    }
                    else
                    {
                        b_except = false;
                    }
                }

                if (b_except == false && ExceptCtl5 != null)
                {
                    if (ExceptCtl5 == control)
                    {
                        b_except = true;
                    }
                    else
                    {
                        b_except = false;
                    }
                }

                if (b_except == true)
                {
                    continue;
                }
                
                if (control is Panel || control is System.Windows.Forms.GroupBox || control is TabControl || control is TabPage)
                {
                    FieldClear(control, ExceptCtl1, ExceptCtl2, ExceptCtl3, ExceptCtl4, ExceptCtl5, false);
                }
                else
                {
                    if (control is System.Windows.Forms.TextBox)
                    {
                        ((System.Windows.Forms.TextBox)control).Text = "";
                    }
                    else if (control is UltraTextEditor)
                    {
                        ((Infragistics.Win.UltraWinEditors.UltraTextEditor)control).Text = "";
                    }
                    else if (control is System.Windows.Forms.CheckBox)
                    {
                        ((System.Windows.Forms.CheckBox)control).Checked = false;
                    }
                    else if (control is UltraCheckEditor)
                    {
                        ((Infragistics.Win.UltraWinEditors.UltraCheckEditor)control).Checked = false;
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).SelectedIndex = -1;
                        if (bItemsClear == true)
                        {
                            ((ComboBox)control).Items.Clear();
                        }
                    }
                    else if (control is UltraComboEditor)
                    {
                        ((UltraComboEditor)control).SelectedIndex = -1;
                        if (bItemsClear == true)
                        {
                            ((UltraComboEditor)control).Items.Clear();
                        }
                    }
                    else if (control is RadioButton)
                    {
                        ((RadioButton)control).Checked = false;
                    }
                    else if (control is MCCodeView)
                    {
                        ((MCCodeView)control).Text = "";
                        if (bItemsClear == true)
                        {
                            ((MCCodeView)control).Items.Clear();
                        }
                    }
                    else if (control is NumericUpDown)
                    {
                        try
                        {
                            ((NumericUpDown)control).Value = 0;
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            //MPCF.ShowMsgBox(argEx.Message);
                            ((NumericUpDown)control).Value = ((NumericUpDown)control).Minimum;
                        }
                    }
                    else if (control is UltraNumericEditor)
                    {
                        if (((UltraNumericEditor)control).Nullable == true)
                        {
                            ((UltraNumericEditor)control).Value = null;
                        }
                        else
                        {
                            ((UltraNumericEditor)control).Value = 0;
                        }
                    }
                    else if (control is intCodeListControl)
                    {
                        ((intCodeListControl)control).ClearField();
                    }
                }
            }

            return true;
        }

        public static bool FieldVisible(object ctrl, bool bVisible)
        {
            return FieldVisible(ctrl, bVisible, null, null, null, null, null);
        }
        public static bool FieldVisible(object ctrl, bool bVisible, object ExceptCtl1, object ExceptCtl2, object ExceptCtl3, object ExceptCtl4, object ExceptCtl5)
        {
            object control;
            int i;
            bool b_except;

            control = null;

            System.Windows.Forms.Control f = (System.Windows.Forms.Control)ctrl;

            for (i = 0; i < f.Controls.Count; i++)
            {
                b_except = false;

                control = f.Controls[i];

                if (ExceptCtl1 != null)
                {
                    if (ExceptCtl1 == control)
                    {
                        b_except = true;
                    }
                    else
                    {
                        b_except = false;
                    }
                }
                if (b_except == false && ExceptCtl2 != null)
                {
                    if (ExceptCtl2 == control)
                    {
                        b_except = true;
                    }
                    else
                    {
                        b_except = false;
                    }
                }
                if (b_except == false && ExceptCtl3 != null)
                {
                    if (ExceptCtl3 == control)
                    {
                        b_except = true;
                    }
                    else
                    {
                        b_except = false;
                    }
                }

                if (b_except == false && ExceptCtl4 != null)
                {
                    if (ExceptCtl4 == control)
                    {
                        b_except = true;
                    }
                    else
                    {
                        b_except = false;
                    }
                }

                if (b_except == false && ExceptCtl5 != null)
                {
                    if (ExceptCtl5 == control)
                    {
                        b_except = true;
                    }
                    else
                    {
                        b_except = false;
                    }
                }

                if (b_except == true)
                {
                    continue;
                }
                
                if (control is Panel || control is System.Windows.Forms.GroupBox || control is TabControl || control is TabPage)
                {
                    FieldVisible(control, bVisible, ExceptCtl1, ExceptCtl2, ExceptCtl3, ExceptCtl4, ExceptCtl5);
                }
                else
                {
                    ((Control)control).Visible = bVisible;
                }
            }

            return true;
        }

        public static bool ChangeCursor(object ctrl, Cursor curChange)
        {
            object control;
            int i;

            control = null;

            System.Windows.Forms.Control cc = (System.Windows.Forms.Control)ctrl;

            for (i = 0; i < cc.Controls.Count; i++)
            {
                control = cc.Controls[i];
                ((Control)control).Cursor = curChange;
                ChangeCursor(control, curChange);
            }

            return true;
        }

        //********************************************************************
        //*
        //*  Function Name   :   FindListItemPartial
        //*
        //*  File Name       :   modCOMM00.vb
        //*
        //*  Program ID      :   MES
        //*
        //*  Description     :   ListView?먯꽌 臾몄옄?대줈 ?쒖옉?섎뒗 ?꾩씠?쒖씠 ?ㅼ뼱?덈뒗 ?몃뜳?ㅻ? 媛?몄삩??
        //*
        //*  Input Parameter :   list as ListView
        //*                      txt as String - 李얘퀬???섎뒗 臾몄옄??
        //*                      i_start_index as integer - ?꾩씠???띿뒪?몄쓽 ?쒖옉 ?꾩튂
        //*
        //*  Output Value    :   None
        //*
        //*  Special Logic Notes :
        //*
        //*  Modification History    :
        //*
        //*  VERSION     DATE            AUTHOR      DESCRIPTION
        //*  ---------   -------------   ----------  ---------------
        //*  V1.0.0      June 04, 2004   CM Koo      Create
        //*
        //*******************************************************************
        public static int FindListItemPartial(ListView list, string txt, int i_start_index, bool bSelect, bool bCaseSensitive)
        {
            int i;
            int i_txt_len;
            string s_item_txt;
            int i_col;

            i_col = 0;
            txt = Trim(txt);

            if (txt.Length == 0)
            {
                return -1;
            }

            if (txt[0] == '$')
            {
                int iPos;

                iPos = txt.IndexOf(':', 1);
                if (iPos > 1)
                {
                    i_col = MPCF.ToInt(txt.Substring(1, iPos - 1)) - 1;
                    txt = txt.Substring(iPos + 1);

                    if (i_col < 0) i_col = 0;
                }
            }

            i_txt_len = txt.Length;
            if (i_txt_len == 0)
            {
                return -1;
            }

            if (bCaseSensitive == false)
            {
                txt = txt.ToUpper();
            }

            for (i = i_start_index; i < list.Items.Count; i++)
            {
                s_item_txt = Trim(list.Items[i].SubItems[i_col].Text);

                if (bCaseSensitive == false)
                {
                    s_item_txt = s_item_txt.ToUpper();
                }

                if (s_item_txt.Length >= i_txt_len)
                {
                    if (s_item_txt.Substring(0, i_txt_len) == txt)
                    {
                        if (bSelect == true)
                        {
                            list.Items[i].Selected = true;
                            list.Items[i].EnsureVisible();
                        }

                        return i;
                    }
                }
            }

            return -1;
        }

        public static int FindListItemNextPartial(ListView list, string txt, bool bSelect, bool bCaseSensitive)
        {
            int i;
            int i_txt_len;
            string s_item_txt;
            int i_start_index;
            int i_col;

            i_col = 0;
            txt = Trim(txt);

            if (txt.Length == 0)
            {
                return -1;
            }

            if (txt[0] == '$')
            {
                int iPos;

                iPos = txt.IndexOf(':', 1);
                if (iPos > 1)
                {
                    i_col = MPCF.ToInt(txt.Substring(1, iPos - 1)) - 1;
                    txt = txt.Substring(iPos + 1);

                    if (i_col < 0) i_col = 0;
                }
            }

            i_txt_len = txt.Length;
            if (i_txt_len == 0)
            {
                return -1;
            }

            if (bCaseSensitive == false)
            {
                txt = txt.ToUpper();
            }

            if (list.SelectedItems.Count > 0)
            {
                i_start_index = list.SelectedItems[0].Index;
                if (i_start_index + 1 > list.Items.Count - 1)
                {
                    i_start_index = 0;
                }
                else
                {
                    i_start_index++;
                }
            }
            else
            {
                i_start_index = 0;
            }

            for (i = i_start_index; i < list.Items.Count; i++)
            {
                s_item_txt = Trim(list.Items[i].SubItems[i_col].Text);

                if (bCaseSensitive == false)
                {
                    s_item_txt = s_item_txt.ToUpper();
                }

                if (s_item_txt.Length >= i_txt_len)
                {
                    if (s_item_txt.Substring(0, i_txt_len) == txt)
                    {
                        if (bSelect == true)
                        {
                            list.Items[i].Selected = true;
                            list.Items[i].EnsureVisible();
                        }

                        return i;
                    }
                }
            }

            if (i_start_index != 0)
            {
                for (i = 0; i <= i_start_index; i++)
                {
                    s_item_txt = Trim(list.Items[i].SubItems[i_col].Text);

                    if (bCaseSensitive == false)
                    {
                        s_item_txt = s_item_txt.ToUpper();
                    }

                    if (s_item_txt.Length >= i_txt_len)
                    {
                        if (s_item_txt.Substring(0, i_txt_len) == txt)
                        {
                            if (bSelect == true)
                            {
                                list.Items[i].Selected = true;
                                list.Items[i].EnsureVisible();
                            }

                            return i;
                        }
                    }
                }
            }

            return -1;
        }

        //********************************************************************
        //*
        //*  Function Name  :   CheckValue
        //*
        //*  File Name       :   MPlusCOMN00.bas
        //*
        //*  Program ID      :   MES
        //*
        //*  Description     :   Check space of the specific control
        //*
        //*  Input Parameter :   Form_control as control - control
        //*                      Step as integer
        //*                      Not_Confirm_flag as boolean
        //*                      Not_Focus_flag as boolean
        //*                      Cond1 as string - "=", "!=", ">", "<", "Instr"
        //*                      Cond2 as String - Value to be compared
        //*
        //*  Output Value    :   None
        //*
        //*  Special Logic Notes :   ?대떦 Control??媛믪씠 ?щ컮瑜몄? Check?쒕떎.
        //*                          Step = 1 : Check Space
        //*                          Step = 2 : Check Number
        //*                          Step = 3 : Check Integral Number(?뺤닔?몄? Check)
        //*                          Confirm_Flag="Y" : MessageBox瑜?Modal濡??꾩슫??
        //*                          Focus_Flag="Y" : ?대떦 control??Focus瑜?以??
        //*
        //*  Modification History    :
        //*
        //*  VERSION     DATE            AUTHOR      DESCRIPTION
        //*  ---------   -------------   ----------  ---------------
        //*  V1.0.0      June 30, 2001   SK Jin      Create
        //*
        //*******************************************************************
        public static bool CheckValue(Control Form_control, int _Step)
        {
            return CheckValue(Form_control, _Step, false, false, "", "", "");
        }

        public static bool CheckValue(Control Form_control, int _Step, bool Not_Confirm_Flag, bool Not_Focus_Flag, string message, string Cond1, string Cond2)
        {
            bool b_valid_flag;
            b_valid_flag = false;

            if (Trim(message) == "")
            {
                if (_Step == 1)
                {
                    message = MPCF.GetMessage(108);
                }
                else if (_Step == 2 || _Step == 3)
                {
                    message = MPCF.GetMessage(110);
                }
            }

            if ((Form_control is System.Windows.Forms.TextBox) || (Form_control is System.Windows.Forms.Label))
            {
                if (_Step == 1)
                {
                    if (Trim(Form_control.Text) != "")
                    {
                        b_valid_flag = true;
                    }
                }
                else if (_Step == 2)
                {
                    if (MPCF.CheckNumeric(Form_control.Text) == true)
                    {
                        b_valid_flag = true;
                    }
                }
                else if (_Step == 3)
                {
                    if (MPCF.CheckNumeric(Form_control.Text) == true)
                    {
                        if (Form_control.Text.Contains(".") == false)
                        {
                            b_valid_flag = true;
                        }
                    }
                }
            }
            else if (Form_control is ComboBox)
            {
                if (_Step == 1)
                {
                    if (Trim(Form_control.Text) != "")
                    {
                        b_valid_flag = true;
                    }
                }
                else if (_Step == 2)
                {
                    if (MPCF.CheckNumeric(Form_control.Text) == true)
                    {
                        b_valid_flag = true;
                    }
                }
                else if (_Step == 3)
                {
                    if (MPCF.CheckNumeric(Form_control.Text) == true)
                    {
                        if (Form_control.Text.IndexOf(".") < 0)
                        {
                            b_valid_flag = true;
                        }
                    }
                }
            }
            else if (Form_control is MCCodeView)
            {
                if (_Step == 1)
                {
                    if (MPCF.Trim(((MCCodeView)Form_control).Text) != "")
                    {
                        b_valid_flag = true;
                    }
                }
                else if (_Step == 2)
                {
                    if (MPCF.CheckNumeric(((MCCodeView)Form_control).Text) == true)
                    {
                        b_valid_flag = true;
                    }
                }
                else if (_Step == 3)
                {
                    if (MPCF.CheckNumeric(((MCCodeView)Form_control).Text) == true)
                    {
                        if (((MCCodeView)Form_control).Text.IndexOf(".") < 0)
                        {
                            b_valid_flag = true;
                        }
                    }
                }
            }
            else if (Form_control is Infragistics.Win.UltraWinEditors.UltraNumericEditor)
            {
                if (_Step == 1)
                {
                    if (MPCF.Trim(((Infragistics.Win.UltraWinEditors.UltraNumericEditor)Form_control).Text) != "")
                    {
                        b_valid_flag = true;
                    }
                }
                else if (_Step == 2)
                {
                    if (MPCF.CheckNumeric(((Infragistics.Win.UltraWinEditors.UltraNumericEditor)Form_control).Text) == true)
                    {
                        b_valid_flag = true;
                    }
                }
                else if (_Step == 3)
                {
                    if (MPCF.CheckNumeric(((Infragistics.Win.UltraWinEditors.UltraNumericEditor)Form_control).Text) == true)
                    {
                        if (((Infragistics.Win.UltraWinEditors.UltraNumericEditor)Form_control).Text.IndexOf(".") < 0)
                        {
                            b_valid_flag = true;
                        }
                    }
                }
            }
            else if (Form_control is intCodeListControl)
            {
                return ((intCodeListControl)Form_control).CheckValue();
            }


            if (b_valid_flag == false)
            {
                if (Not_Confirm_Flag == false)
                {
                    ShowMsgBox(message);
                    if (Not_Focus_Flag == false)
                    {
                        if (Form_control.Visible == true && Form_control.Enabled == true)
                        {
                            Form_control.Focus();
                        }
                    }
                }
                return b_valid_flag;
            }

            b_valid_flag = true;
            return b_valid_flag;

        }

        // CheckMaxLength()
        //       - check byte text length in TextBox
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal txt As Object            : TextBox Control
        //        - ByVal iMaxLength As Integer    : Max byte length
        public static bool CheckMaxLength(object ctrl, int iMaxLength)
        {
            int i_byte_len;
            string s_text = "";

            if (iMaxLength <= 0)
            {
                if (ctrl is System.Windows.Forms.TextBox)
                {
                    iMaxLength = ((System.Windows.Forms.TextBox)ctrl).MaxLength;
                    s_text = ((System.Windows.Forms.TextBox)ctrl).Text;
                }
                else if (ctrl is MCCodeView)
                {
                    iMaxLength = ((MCCodeView)ctrl).MaxLength;
                    s_text = ((MCCodeView)ctrl).Text;
                }
            }

            if (iMaxLength == 0)
            {
                return false;
            }

            i_byte_len = ByteLen(s_text);
            if (i_byte_len > iMaxLength)
            {
                if (ctrl is System.Windows.Forms.TextBox)
                {
                    ((System.Windows.Forms.TextBox)ctrl).Text = ByteMid(s_text, 0, iMaxLength);
                    ((System.Windows.Forms.TextBox)ctrl).SelectionStart = s_text.Length;
                }
                else if (ctrl is MCCodeView)
                {
                    ((MCCodeView)ctrl).Text = ByteMid(s_text, 0, iMaxLength);
                    ((MCCodeView)ctrl).SelectionStart = s_text.Length;
                }

                return false;
            }

            return true;
        }

        // ByteLen()
        //       - Get byte length in String
        // Return Value
        //       - Integer : byte length
        // Arguments
        //       - ByVal sStr As String            : String
        public static int ByteLen(object str)
        {
            if (str == null) str = "";
            string sTemp = str.ToString();
            return System.Text.Encoding.Default.GetByteCount(sTemp);
        }

        // ByteMid()
        //       - Get Middle String at byte length in String
        // Return Value
        //       - String : Middle String
        // Arguments
        //       - ByVal sStr As String            : Source String
        //        - ByVal iStartIndex As Integer    : Start Index
        //        - ByVal iLength As Integer        : Middle String byte length
        public static string ByteMid(object str, int iStartIndex, int iLength)
        {
            System.Text.Encoding twobyte;
            string sTemp;
            byte[] bTemp;

            twobyte = System.Text.Encoding.Default;

            if (str == null) str = "";
            sTemp = str.ToString();
            bTemp = twobyte.GetBytes(sTemp);
            sTemp = "";

            if (bTemp.Length < iStartIndex + iLength)
            {
                iLength = bTemp.Length - iStartIndex;
            }

            sTemp = twobyte.GetString(bTemp, iStartIndex, iLength);

            return sTemp;

        }

        // ByteSplit()
        //       - Split String at byte length in String
        // Return Value
        //       - String : Middle String
        // Arguments
        //       - ByVal sStr As String            : Source String
        //        - ByVal iStartIndex As Integer    : Start Index
        //        - ByVal iLength As Integer        : Middle String byte length
        public static List<string> ByteSplit(object str, int i_max_length)
        {
            System.Text.Encoding twobyte;
            string sTemp;
            byte[] bTemp;
            List<string> lisSplitString;
            int i;
            int i_inc;

            twobyte = System.Text.Encoding.Default;

            lisSplitString = new List<string>();

            if (str == null) 
            {
                return lisSplitString;
            }

            sTemp = str.ToString();
            sTemp = Trim(sTemp);

            bTemp = twobyte.GetBytes(sTemp);
            sTemp = "";

            while(true)
            {
                if (bTemp.Length <= i_max_length)
                {
                    sTemp = twobyte.GetString(bTemp);
                    lisSplitString.Add(sTemp);
                    break;
                }

                i_inc = 0;
                for (i = 0; i < i_max_length;)
                {
                    if (bTemp[i] > 127)
                    {
                        i_inc = 2;
                    }
                    else
                    {
                        i_inc = 1;
                    }

                    i += i_inc;
                }
                if (i > i_max_length)
                {
                    i -= i_inc;
                }

                sTemp = twobyte.GetString(bTemp, 0, i);
                lisSplitString.Add(sTemp);

                sTemp = twobyte.GetString(bTemp, i, bTemp.Length - i);

                bTemp = twobyte.GetBytes(sTemp);
                sTemp = "";
            }

            return lisSplitString;
        }

        public static void ClearList(Control ListControl)
        {
            ClearList(ListControl, false);
        }

        // ClearList()
        //       - Clear List Control
        // Return Value
        //       -
        // Arguments
        //       - ByVal ListControl As Control
        //
        public static void ClearList(Control ListControl, bool ComboBoxSpaceAddFlag)
        {
            if (ListControl == null) return;

            if (ListControl is ListView)
            {
                if (((ListView)ListControl).Items.Count == 0) return;
                ((ListView)ListControl).Items.Clear();
            }
            else if (ListControl is ComboBox)
            {
                if (((ComboBox)ListControl).Items.Count == 0) return;
                ((ComboBox)ListControl).Items.Clear();
                if (ComboBoxSpaceAddFlag == true)
                {
                    ((ComboBox)ListControl).Items.Add("");
                }
            }
            else if (ListControl is TreeView)
            {
                if (((TreeView)ListControl).Nodes.Count == 0) return;
                ((TreeView)ListControl).Nodes.Clear();
            }
            else if (ListControl is FarPoint.Win.Spread.FpSpread)
            {
                FarPoint.Win.Spread.FpSpread spd;

                spd = ((FarPoint.Win.Spread.FpSpread)ListControl);
                spd.SuspendLayout();
                //2009.01.11. Aiden
                //아래 문장이 Spread 2.0 에서는 괜찮았는데 4.0 으로 Upgrade 이후 CPU를 굉장히 많이 잡음. 버그인지???
                //spd.ActiveSheet.ClearRange(0, 0, spd.ActiveSheet.RowCount, spd.ActiveSheet.ColumnCount, true);
                if (spd.ActiveSheet == null) return;

                spd.ActiveSheet.RowCount = 0;

                if (spd.ActiveSheet.DataSource != null)
                {
                    spd.ActiveSheet.DataSource = null;
                    spd.ActiveSheet.ColumnCount = 0;
                }

                spd.ResumeLayout();
            }
        }

        /// <summary>
        /// TreeView에서 지정한 경로의 TreeNode를 반환한다
        /// </summary>
        /// <param name="Tree">TreeView 명</param>
        /// <param name="Item">찾고자하는 Node의 Item 이름</param>
        /// <param name="Parent">찾고자하는 Node의 부모 Node의 Item 이름</param>
        /// <returns>반환할 Node</returns>
        public static TreeNode FindTreeNode(TreeView Tree, string Item, string Parent)
        {
            TreeNode FindNode;

            try
            {
                foreach (TreeNode nodeX in Tree.Nodes)
                {
                    FindNode = FindTreeNode(nodeX, Item, Parent);
                    if (FindNode != null) return FindNode;
                }
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex.Message);
            }

            return null;
        }
        /// <summary>
        /// TreeNode에서 지정한 경로의 TreeNode를 반환한다
        /// </summary>
        /// <param name="node">TreeNode 명</param>
        /// <param name="Item">찾고자하는 Node의 Item 이름</param>
        /// <param name="Parent">찾고자하는 Node의 부모 Node의 Item 이름</param>
        /// <returns>반환할 Node</returns>
        public static TreeNode FindTreeNode(TreeNode node, string Item, string Parent)
        {
            TreeNode ret_node;

            try
            {
                Item = Trim(Item);
                Parent = Trim(Parent);

                if (Trim(node.Text) == Item)
                {
                    if (Trim(Parent) == "")
                        return node;
                    else if (Trim(node.Parent.Text) == Parent)
                        return node;
                }

                foreach (TreeNode TNode in node.Nodes)
                {
                    if (Trim(TNode.Text) == Item)
                    {
                        if (Trim(Parent) == "")
                            return TNode;
                        else if (Trim(node.Parent.Text) == Parent)
                            return TNode;
                    }

                    ret_node = FindTreeNode(TNode, Item, Parent);
                    if (ret_node != null) return ret_node;
                }

            }
            catch (Exception ex)
            {
                ShowMsgBox(ex.Message);
            }

            return null;
        }

        /// <summary>
        /// TreeView에서 지정한 경로의 TreeNode를 반환한다
        /// </summary>
        /// <param name="Tree">TreeView 명</param>
        /// <param name="ItemPath">찾고자하는 Node의 Item 이름</param>
        /// <returns>반환할 Node</returns>
        public static TreeNode FindTreeNode(TreeView Tree, string ItemPath)
        {
            TreeNode FindNode;

            try
            {
                foreach (TreeNode nodeX in Tree.Nodes)
                {
                    FindNode = FindTreeNode(nodeX, ItemPath);
                    if (FindNode != null) return FindNode;
                }
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex.Message);
            }

            return null;

        }

        /// <summary>
        /// TreeNode에서 지정한 경로의 TreeNode를 반환한다
        /// </summary>
        /// <param name="node">TreeNode 명</param>
        /// <param name="ItemPath">찾고자하는 Node의 Item 이름</param>
        /// <returns>반환할 Node</returns>
        public static TreeNode FindTreeNode(TreeNode node, string ItemPath)
        {
            TreeNode ret_node;
            try
            {
                if (node.FullPath == ItemPath)
                {
                    return node;
                }

                foreach (TreeNode TNode in node.Nodes)
                {
                    if (TNode.FullPath.StartsWith(ItemPath) == true) return TNode;

                    ret_node = FindTreeNode(TNode, ItemPath);
                    if (ret_node != null) return ret_node;
                }

            }
            catch (Exception ex)
            {
                ShowMsgBox(ex.Message);
            }

            return null;

        }

        /// <summary>
        /// TreeNode에서 지정한 Node사이에 Item을 찾아서 반환한다.
        /// </summary>
        /// <param name="first_node">시작 TreeNode 명</param>
        /// <param name="cur_node">끝 TreeNode 명</param>
        /// <param name="Item">찾을 Node의 Item 명</param>
        /// <returns>발견된 TreeNode</returns>
        public static TreeNode FindTreeNodeNextPartial(TreeNode first_node, TreeNode cur_node, string Item)
        {
            TreeNode t_node_1 = first_node;
            TreeNode t_node_2 = cur_node;
            TreeNode t_node_3;

            t_node_3 = FindTreeNodeNextPartialSub01(t_node_1, ref t_node_2, Item);
            if (t_node_3 == null)
            {
                t_node_2 = null;
                t_node_3 = FindTreeNodeNextPartialSub01(t_node_1, ref t_node_2, Item);
            }

            return t_node_3;
        }
        /// <summary>
        /// TreeNode에서 지정한 Node사이에 Item을 찾아서 반환한다.
        /// </summary>
        /// <param name="first_node">시작 TreeNode 명</param>
        /// <param name="cur_node">끝 TreeNode 명</param>
        /// <param name="Item">찾을 Node의 Item 명</param>
        /// <returns>발견된 TreeNode</returns>
        private static TreeNode FindTreeNodeNextPartialSub01(TreeNode first_node, ref TreeNode cur_node, string Item)
        {
            TreeNode t_node_1;
            TreeNode t_node_2;
            try
            {
                t_node_1 = first_node;
                while (t_node_1 != null)
                {
                    if (cur_node == null)
                    {
                        if (t_node_1.Text.IndexOf(Item) >= 0) return t_node_1;
                    }
                    else
                    {
                        if (t_node_1.Equals(cur_node) == true)
                        {
                            cur_node = null;
                        }
                    }

                    if (t_node_1.GetNodeCount(true) > 0)
                    {
                        t_node_2 = FindTreeNodeNextPartialSub01(t_node_1.Nodes[0], ref cur_node, Item);
                        if (t_node_2 != null) return t_node_2;
                    }

                    t_node_1 = t_node_1.NextNode;
                }
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex.Message);
            }

            return null;
        }

        //
        // SubtractString()
        //       -  Subtract String
        // Return Value
        //       -  String :
        // Arguments
        //       - tmpS as String - Source String
        //       - FString as String - String to Find
        //       - Backward_Flag as boolean(Optional)
        //

        public static string SubtractString(string tmpS, string Fstring, bool Backword_flag, bool Include_Space)
        {
            string s_sub_string;

            int i_length;
            int i_index;

            try
            {
                s_sub_string = "";
                if (Trim(tmpS) == "")
                {
                    return "";
                }

                i_index = tmpS.IndexOf(Fstring);

                if (Backword_flag == true)
                {
                    if (i_index < 0)
                    {
                        return "";
                    }
                    else
                    {
                        i_length = tmpS.Length;
                        if (Include_Space == true)
                        {
                            s_sub_string = tmpS.Substring(i_index + Fstring.Length, i_length - i_index - Fstring.Length);
                        }
                        else
                        {
                            s_sub_string = MPCF.Trim(tmpS.Substring(i_index + Fstring.Length, i_length - i_index - Fstring.Length));
                        }
                    }
                }
                else
                {
                    if (i_index < 0)
                    {
                        if (Include_Space == true)
                        {
                            s_sub_string = tmpS;
                        }
                        else
                        {
                            s_sub_string = MPCF.Trim(tmpS);
                        }
                    }
                    else
                    {
                        if (Include_Space == true)
                        {
                            s_sub_string = tmpS.Substring(0, i_index);
                        }
                        else
                        {
                            s_sub_string = MPCF.Trim(tmpS.Substring(0, i_index));
                        }
                    }
                }

                return s_sub_string;
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex.Message);
                return "";
            }
        }

        /// <summary>
        /// Get process owner name
        /// </summary>
        /// <param name="processId">Target Process Id</param>
        /// <returns>Process Owner (Domain + User ID)</returns>
        private static string GetProcessOwner(int processId)
        {
            string query = "Select * From Win32_Process Where ProcessID = " + processId;

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection processList = searcher.Get();

            foreach (ManagementObject obj in processList)
            {
                string[] argList = new string[] { string.Empty, string.Empty };
                int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                if (returnVal == 0)
                {
                    return argList[1] + "\\" + argList[0];
                }
            }

            return "";
        }

        //
        // ExportToExcel()
        //       - Export Data of Control to Excel Application Data
        // Return Value
        //       - True or False
        // Arguments
        //       - ByRef l_control As listview
        //       - ByVal title As string
        //       - Optional ByVal Condition As string
        //       - Optional ByVal umerical As Boolean
        //       - Optional ByVal ColorFlag As Boolean
        //       - Optional ByVal bTextBase As Boolean    '
        //
        public static bool ExportToExcel(Control l_Control, string title, string Condition)
        {
            return ExportToExcel(l_Control, title, Condition, true, false, true, -1, -1);
        }
        public static bool ExportToExcel(Control l_Control, string title, string Condition, bool ColorFlag, bool bTextBase, bool bShowDate, int iStartCol, int iEndCol)
        {
            try
            {
                int i;
                System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName("Excel");

                for (i = 0; i < proc.Length; i++)
                {
                    if (proc[i].MainWindowHandle.Equals(System.IntPtr.Zero))
                    {
                        WindowsIdentity CurrentUser = WindowsIdentity.GetCurrent();
                        string ProcessOwner = GetProcessOwner(proc[i].Id);

                        if (CurrentUser.Name == ProcessOwner)
                        proc[i].Kill();
                    }
                }

                if (l_Control is ListView)
                {
                    return ListviewToExcel((ListView)l_Control, title, Condition, ColorFlag, bTextBase, bShowDate);
                }
                else if (l_Control is FarPoint.Win.Spread.FpSpread)
                {
                    return SpreadSheetToExcel(((FarPoint.Win.Spread.FpSpread)l_Control).ActiveSheet, title, Condition, ColorFlag, bTextBase, bShowDate, iStartCol, iEndCol);
                }
                else
                {
                    ShowMsgBox(MPCF.GetMessage(11));
                    return false;
                }
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex.Message);
            }

            return false;
        }

        public static void ExportExcel(FarPoint.Win.Spread.FpSpread spread, string psSheetName, Boolean pbExportWithoutHiddenColumns, string sTitle)
        {
            try
            {
                if (spread == null)
                {
                    return;
                }

                if (psSheetName == null || psSheetName.Equals(string.Empty))
                {
                    psSheetName = "Data";
                }

                StringBuilder sFileName = new StringBuilder();
                string sFunctionName = sTitle;

                sFunctionName = sFunctionName.Replace("*", string.Empty).Replace("|", string.Empty).Replace("\\", string.Empty).Replace(":", string.Empty).Replace("\"", string.Empty).Replace("<", string.Empty).Replace(">", string.Empty).Replace("?", string.Empty).Replace("/", string.Empty);
                psSheetName = psSheetName.Replace("*", string.Empty).Replace("\\", string.Empty).Replace(":", string.Empty).Replace("?", string.Empty).Replace("/", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty);

                sFileName.Append(sFunctionName); // Function Title
                sFileName.Append(string.Format("_{0}.xlsx", DateTime.Now.ToString("yyyyMMddHHmmss")));
                string localFile = Path.Combine(Path.GetTempPath(), sFileName.ToString());

                spread.Sheets[0].Protect = false;
                spread.SaveExcel(localFile, FarPoint.Excel.ExcelSaveFlags.ComboDataOnly | FarPoint.Excel.ExcelSaveFlags.UseOOXMLFormat | FarPoint.Excel.ExcelSaveFlags.SaveBothCustomRowAndColumnHeaders);
                //spread.SaveExcel(localFile,  FarPoint.Excel.ExcelSaveFlags.ComboDataOnly 
                //                            | FarPoint.Excel.ExcelSaveFlags.UseOOXMLFormat 
                //                            | FarPoint.Excel.ExcelSaveFlags.SaveBothCustomRowAndColumnHeaders
                //                            | FarPoint.Excel.ExcelSaveFlags.DataOnly
                //                            );
                spread.Sheets[0].Protect = true;

                Excel.ApplicationClass xExcel = null;
                Excel.Workbooks xWorkBooks = null;
                Excel.Workbook xWorkBook = null;
                Excel.Sheets xSheets = null;
                Excel.Worksheet xWorkSheet = null;

                try
                {
                    xExcel = new Excel.ApplicationClass();
                    xWorkBooks = xExcel.Workbooks;
                    xWorkBook = xWorkBooks.Open(localFile,
                            0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
                            true, false, 0, true, false, false);
                    xSheets = xWorkBook.Worksheets;
                    xWorkSheet = (Excel.Worksheet)(xSheets.get_Item("Sheet1"));
                    xWorkSheet.Name = psSheetName;

                    int rowCount = spread.Sheets[0].Rows.Count;
                    int colCount = spread.Sheets[0].Columns.Count;
                    
                    for (int i = 0; i < colCount; i++)
                    {
                        if (spread.Sheets[0].Columns[i].CellType is FarPoint.Win.Spread.CellType.ComboBoxCellType)
                        {
                            Excel.Range rngValue = null;

                            try
                            {
                                object[,] oComboData = new object[rowCount, 1];
                                for (int j = 0; j < spread.Sheets[0].Rows.Count; j++)
                                {
                                    oComboData[j, 0] = getValueInSpread(spread, j, i);
                                }
                                rngValue = xWorkSheet.get_Range(xWorkSheet.Cells[2, i + 2], xWorkSheet.Cells[rowCount + 1, i + 2]);
                                rngValue.Value2 = oComboData;
                            }
                            finally
                            {
                                ExcelHelper.ReleaseComObject(rngValue);
                                rngValue = null;
                            }
                        }
                        else if (spread.Sheets[0].Columns[i].CellType is FarPoint.Win.Spread.CellType.NumberCellType)
                        {
                            Excel.Range range1 = null;

                            try
                            {
                                range1 = xWorkSheet.get_Range(xWorkSheet.Cells[2, i + 2], xWorkSheet.Cells[rowCount + 1, i + 2]);
                                range1.NumberFormat = "#,##0";
                            }
                            finally
                            {
                                ExcelHelper.ReleaseComObject(range1);
                                range1 = null;
                            }
                        }
                    }

                    if (spread.Sheets[0].Columns[0].CellType is FarPoint.Win.Spread.CellType.CheckBoxCellType)
                    {
                        Excel.Range rngValue = null;

                        try
                        {
                            object[,] oComboData = new object[rowCount, 1];
                            for (int j = 0; j < spread.Sheets[0].Rows.Count; j++)
                            {
                                oComboData[j, 0] = spread.Sheets[0].Cells[j, 0].Text;
                            }

                            rngValue = xWorkSheet.get_Range(xWorkSheet.Cells[2, 2], xWorkSheet.Cells[rowCount + 1, 2]);
                            rngValue.Value2 = oComboData;
                        }
                        finally
                        {
                            ExcelHelper.ReleaseComObject(rngValue);
                            rngValue = null;
                        }
                    }

                    int iDeleteCount = 0;
                    if (pbExportWithoutHiddenColumns)
                    {
                        for (int i = colCount - 1; i >= 0; i--)
                        {
                            if (spread.Sheets[0].Columns[i].Visible == false)
                            {
                                Excel.Range sourceRange = null;
                                try
                                {
                                    sourceRange = ExcelHelper.GetRange(xWorkSheet, i + 2, i + 2, true);
                                    sourceRange.Delete(Excel.XlDirection.xlToLeft);
                                    iDeleteCount++;
                                }
                                finally
                                {
                                    ExcelHelper.ReleaseComObject(sourceRange);
                                    sourceRange = null;
                                }
                                continue;
                            }
                        }
                    }

                    Excel.Range rngRowNumber = null;
                    try
                    {
                        object[,] oRowNum = new object[rowCount, 1];
                        for (int i = 0; i < rowCount; i++)
                        {
                            oRowNum[i, 0] = i + 1;
                        }
                        rngRowNumber = xWorkSheet.get_Range(xWorkSheet.Cells[2, 1], xWorkSheet.Cells[rowCount + 1, 1]);
                        rngRowNumber.Value2 = oRowNum;
                    }
                    finally
                    {
                        ExcelHelper.ReleaseComObject(rngRowNumber);
                        rngRowNumber = null;
                    }

                    Excel.Range rngInsert = null;
                    Excel.Range rngWidth = null;
                    Excel.Range rngTitle = null;
                    Excel.Range rngDate = null;
                    Excel.Range rngAllData = null;
                    Excel.Range rngColHeader = null;
                    Excel.Range rngRowHeader = null;
                    Excel.Range rngReleasePanes = null;
                    Excel.Range rngFreezePanes = null;
                    Excel.Range rngA1 = null;
                    Excel.Range rngNormal = null;

                    try
                    {
                        rngInsert = ExcelHelper.GetRange(xWorkSheet, 1, 1, true);
                        rngInsert.Select();
                        rngInsert.Insert(Excel.XlDirection.xlToRight, Type.Missing);

                        rngWidth = xWorkSheet.get_Range(xWorkSheet.Cells[1, 1], xWorkSheet.Cells[1, 1]);
                        rngWidth.EntireColumn.ColumnWidth = 0.5;

                        rngInsert = ExcelHelper.GetRange(xWorkSheet, 1, 2, false);
                        rngInsert.Select();
                        rngInsert.Insert(Excel.XlDirection.xlDown, Type.Missing);

                        rngNormal = xWorkSheet.get_Range(xWorkSheet.Cells[1, 1], xWorkSheet.Cells[2, colCount + 2]);
                        rngNormal.Interior.Pattern = Excel.XlPattern.xlPatternNone;
                        //rngNormal.Interior.TintAndShade = 0;
                        //rngNormal.Interior.PatternTintAndShade = 0;

                        rngTitle = xWorkSheet.get_Range(xWorkSheet.Cells[1, 2], xWorkSheet.Cells[1, 2]);
                        rngTitle.VerticalAlignment = ExcelComponent.XlVAlign.xlValignCenter;
                        rngTitle.HorizontalAlignment = ExcelComponent.XlHAlign.xlHAlignLeft;
                        rngTitle.RowHeight = 30;
                        rngTitle.Font.Size = 20;
                        rngTitle.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                        rngTitle.Font.Bold = true;
                        rngTitle.Font.Name = "Arial";
                        rngTitle.Value2 = sTitle;

                        DateTimeFormatInfo dtfInfo = new CultureInfo(CultureInfo.CurrentCulture.Name).DateTimeFormat;
                        StringBuilder sDate = new StringBuilder();
                        sDate.Append("Export Date");
                        sDate.Append(" : ");
                        sDate.Append(DateTime.Now.ToString("G", dtfInfo));

                        rngDate = xWorkSheet.get_Range(xWorkSheet.Cells[2, 2], xWorkSheet.Cells[2, 2]);
                        rngDate.HorizontalAlignment = ExcelComponent.XlHAlign.xlHAlignLeft;
                        rngDate.Value2 = sDate.ToString();

                        rngAllData = xWorkSheet.get_Range(xWorkSheet.Cells[3, 2], xWorkSheet.Cells[rowCount + 3, colCount + 2 - iDeleteCount]);
                        rngAllData.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        rngAllData.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        rngAllData.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        rngAllData.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        rngAllData.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        rngAllData.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;

                        rngColHeader = xWorkSheet.get_Range(xWorkSheet.Cells[3, 2], xWorkSheet.Cells[3, colCount + 2 - iDeleteCount]);
                        rngRowHeader = xWorkSheet.get_Range(xWorkSheet.Cells[3, 2], xWorkSheet.Cells[rowCount + 3, 2]);
                        rngColHeader.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.FromArgb(200, 200, 200));
                        rngRowHeader.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.FromArgb(200, 200, 200));

                        rngReleasePanes = xWorkSheet.get_Range(xWorkSheet.Cells[4, 4], xWorkSheet.Cells[4, 4]);
                        rngFreezePanes = xWorkSheet.get_Range(xWorkSheet.Cells[4, 3], xWorkSheet.Cells[4, 3]);
                        rngA1 = xWorkSheet.get_Range(xWorkSheet.Cells[1, 1], xWorkSheet.Cells[1, 1]);
                        rngReleasePanes.Application.ActiveWindow.FreezePanes = false;
                        rngFreezePanes.Select();
                        rngFreezePanes.Application.ActiveWindow.FreezePanes = true;
                        rngA1.Select();
                    }
                    finally
                    {
                        ExcelHelper.ReleaseComObject(rngInsert, rngWidth, rngTitle, rngDate, rngAllData, rngColHeader, rngRowHeader, rngReleasePanes, rngFreezePanes, rngA1, rngNormal);

                        rngInsert = null;
                        rngWidth = null;
                        rngTitle = null;
                        rngDate = null;
                        rngAllData = null;
                        rngColHeader = null;
                        rngRowHeader = null;
                        rngReleasePanes = null;
                        rngFreezePanes = null;
                        rngA1 = null;
                        rngNormal = null;
                    }

                    xWorkBook.Save();
                    xWorkBook.Close(true, localFile, Type.Missing);
                    xWorkBooks.Close();
                    xExcel.UserControl = false;
                    xExcel.Application.Quit();
                    xExcel.Quit();

                    Process.Start(localFile);

                }
                catch (Exception ex)
                {
                    ShowMsgBox(ex.ToString());
                }
                finally
                {
                    ExcelHelper.ReleaseComObject(xWorkSheet, xSheets, xWorkBook, xWorkBooks, xExcel);
                    xWorkSheet = null;
                    xSheets = null;
                    xWorkBook = null;
                    xWorkBooks = null;
                    xExcel = null;
                }
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex.ToString());
            }
        }

        public static string getValueInSpread(FarPoint.Win.Spread.FpSpread spread, int piRow, int piCol)
        {
            string sReturnValue = string.Empty;
            DateTimeFormatInfo dtfInfo = new CultureInfo(CultureInfo.CurrentCulture.Name).DateTimeFormat;

            if (piCol.Equals(-1))
            {
                return sReturnValue;
            }

            if (spread.Sheets[0].Columns[piCol].CellType.GetType() == typeof(FarPoint.Win.Spread.CellType.CheckBoxCellType))
            {
                if (spread.Sheets[0].Cells[piRow, piCol].Value != null
                    && spread.Sheets[0].Cells[piRow, piCol].Value.ToString().Length > 0
                    && Convert.ToBoolean(spread.Sheets[0].Cells[piRow, piCol].Value) == true)
                {
                    sReturnValue = "Y";
                }
                else
                {
                    sReturnValue = "N";
                }
            }
            else
            {
                if ((spread.Sheets[0].Cells[piRow, piCol].Value == null) || (spread.Sheets[0].Cells[piRow, piCol].Value.GetType() == System.DBNull.Value.GetType()))
                {
                    sReturnValue = string.Empty;
                }
                else
                {
                    if (spread.Sheets[0].Columns[piCol].CellType.GetType() == typeof(FarPoint.Win.Spread.CellType.DateTimeCellType))
                    {
                        if (string.IsNullOrEmpty(spread.Sheets[0].Cells[piRow, piCol].Text) == true)
                        {
                            sReturnValue = string.Empty;
                        }
                        else
                        {
                            string sUserDefinedFormat = ((FarPoint.Win.Spread.CellType.DateTimeCellType)spread.Sheets[0].Columns[piCol].CellType).UserDefinedFormat;

                            if (string.Compare(sUserDefinedFormat, dtfInfo.ShortDatePattern) == 0)
                            {
                                // Date
                                //sReturnValue = ((DateTime)spread.Sheets[0].Cells[piRow, piCol].Value).ToString("d", dtfInfo); 
                                sReturnValue = ((DateTime)spread.Sheets[0].Cells[piRow, piCol].Value).ToString("yyyy-MM-dd");  
                            }
                            else if (string.Compare(sUserDefinedFormat, MPGV.gsTimePattern) == 0)
                            {
                                // Time
                                //sReturnValue = ((DateTime)spread.Sheets[0].Cells[piRow, piCol].Value).ToString("T", dtfInfo); 
                                sReturnValue = ((DateTime)spread.Sheets[0].Cells[piRow, piCol].Value).ToString("HH:mm:ss");
                            }
                            else
                            {
                                // DateTime
                                //sReturnValue = ((DateTime)spread.Sheets[0].Cells[piRow, piCol].Value).ToString("G", dtfInfo); 
                                sReturnValue = ((DateTime)spread.Sheets[0].Cells[piRow, piCol].Value).ToString("yyyy-MM-dd HH:mm:ss");  
                            }

                        }
                    }
                    else if (spread.Sheets[0].Columns[piCol].CellType.GetType() == typeof(FarPoint.Win.Spread.CellType.ComboBoxCellType))
                    {
                        sReturnValue = spread.Sheets[0].Cells[piRow, piCol].Text;
                    }
                    else
                    {
                        sReturnValue = spread.Sheets[0].Cells[piRow, piCol].Value.ToString();
                    }
                }
            }

            return sReturnValue;
        }

        //
        // ExportToText()
        //       - Export Data of Control to Tab Text Data
        // Return Value
        //       - True or False
        // Arguments
        //       - ByRef l_control as listview
        //       - ByVal title as string : Report title
        //       - Optional ByVal Condition as string
        //
        public static bool ExportToText(Control l_Control, string title, string Condition)
        {
            string s_clip_data;
            string s_file_name;
            int i;
            int k;
            SaveFileDialog SaveDialog;
            ListView lisCtl;
            ListViewItem lisItem;

            try
            {

                System.Windows.Forms.Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;

                s_file_name = title;
                s_file_name = s_file_name + "_" + MPCF.ToStandardTime(DateTime.Today, MPGC.MP_CONVERT_DATE_FORMAT);

                s_file_name = s_file_name + "_" + MPCF.ToStandardTime(DateTime.Today, MPGC.MP_CONVERT_DATE_FORMAT);
                s_file_name = s_file_name + MPCF.ToStandardTime(DateTime.Today, MPGC.MP_CONVERT_TIME_FORMAT);
                s_file_name = s_file_name + ".xls";

                SaveDialog = new SaveFileDialog();
                SaveDialog.FileName = s_file_name;
                SaveDialog.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
                if (SaveDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return false;
                }
                s_file_name = SaveDialog.FileName;
                if (s_file_name.IndexOf(".") < 0)
                {
                    s_file_name = s_file_name + ".xls";
                }

                StreamWriter TXTStream = File.CreateText(s_file_name);
                //fso = Interaction.CreateObject("Scripting.fileSystemObject", "");
                //TXTStream = ((Stream)fso).createtextfile(sFileName);

                s_clip_data = "";

                s_clip_data = title + "\r";
                if (Trim(Condition) != "")
                {
                    s_clip_data = s_clip_data + "\r" + "\r";
                    s_clip_data = s_clip_data + Condition + "\r";
                    s_clip_data = s_clip_data + "\r";
                }
                s_clip_data = s_clip_data + "\r";

                if (l_Control is ListView)
                {
                    lisCtl = (ListView)l_Control;
                    for (i = 0; i < lisCtl.Columns.Count; i++)
                    {
                        if (lisCtl.Columns[i].Width > 0)
                        {
                            //sClipData = sClipData + Strings.Replace(lisCtl.Columns[i].Text, "\r", "   ", 1, -1, 0).Replace("\n", " ") + "\t";
                            s_clip_data = s_clip_data + lisCtl.Columns[i].Text.Replace("\r", "   ").Replace("\n", " ") + "\t";
                        }
                    }
                    s_clip_data = s_clip_data + "\r";

                    for (i = 0; i < lisCtl.Items.Count; i++)
                    {
                        for (k = 0; k < lisCtl.Columns.Count; k++)
                        {
                            if (lisCtl.Columns[k].Width > 0)
                            {
                                lisItem = lisCtl.Items[i];
                                if (lisItem.SubItems[k].Text.IndexOf("<") > 0 ||
                                    lisItem.SubItems[k].Text.IndexOf(">") > 0)
                                {
                                    s_clip_data = s_clip_data + MPCF.Trim(lisItem.SubItems[k].Text).Replace(" ", "").Replace("\r", "   ").Replace("\n", "  ").Replace("\t", " ") + "\t";
                                }
                                else
                                {
                                    s_clip_data = s_clip_data + MPCF.Trim(lisItem.SubItems[k].Text).Replace("\r", "   ").Replace("\n", "  ").Replace("\t", " ") + "\t";
                                }
                            }
                        }
                        s_clip_data = s_clip_data + "\r";
                    }
                }
                else
                {
                    ShowMsgBox("Invalid Control Type.");
                    return false;
                }

                Clipboard.SetDataObject(s_clip_data);

                TXTStream.Write(s_clip_data);
                //TXTStream.WRITE(sClipData);
                //TXTStream.Close();

                //fso = null;
                TXTStream = null;

                Cursor.Current = Cursors.Default;
                return true;
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // ListViewToExcel()
        //       - Export Data of Listview Control to Excel Application Data
        // Return Value
        //       - True or False
        // Arguments
        //       - ByRef l_control As listview
        //       - ByVal title As string
        //       - Optional ByVal Condition As string
        //       - Optional ByVal ColorFlag As Boolean
        //       - Optional ByVal bTextBase As Boolean    '
        //
        public static bool ListviewToExcel(ListView l_Control, string title, string Condition, bool ColorFlag, bool bTextBase, bool bShowDate)
        {
            Excel.Application XApp = new Excel.Application();
            Excel.Workbooks XBooks = XApp.Workbooks;
            Excel.Workbook XBook = XBooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet XSheet = (Excel.Worksheet)XBook.ActiveSheet;

            int i_rest_rows;
            string s_clip_data;
            int i;
            int k;
            int i_column_count;
            string[] s_temp_str;
            int i_row_count = 0;
            ListViewItem lisItem;

            try
            {
                XApp.Visible = false;

                System.Windows.Forms.Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;

                if (Trim(title).Length > 30)
                {
                    try
                    {
                        XSheet.Name = MPCF.Trim(title).Substring(0, 30);
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    try
                    {
                        XSheet.Name = MPCF.Trim(title);
                    }
                    catch (Exception)
                    {
                    }
                }
                XApp.Visible = true;

                i_rest_rows = 3;

                Condition = MPCF.Trim(Condition);
                if (Condition.Length > 0)
                {
                    if (Condition.Substring(Condition.Length - 1, 1) == "\r")
                    {
                        Condition = Condition.Substring(0, Condition.Length - 1);
                    }
                }

                if (Trim(Condition) != "")
                {
                    s_temp_str = Condition.Split("\r".ToCharArray()[0]);
                    i_row_count = (s_temp_str.Length - 1) - 0 + 1;
                    i_rest_rows = i_rest_rows + 1 + i_row_count;
                }

                //First Column Width
                XSheet.get_Range(XSheet.Cells[1, 1], XSheet.Cells[XSheet.Rows.Count, 1]).EntireColumn.ColumnWidth = 0.5;

                XSheet.get_Range(XSheet.Cells[1, 1], XSheet.Cells[XSheet.Rows.Count, MPGC.EXCEL_MAX_COL]).Font.Size = MPGV.gfrmMDI.Font.SizeInPoints;


                //'셀서식을 TEXT로 인식하도록 한다.
                //'단, 셀 서식이 Text일 경우에는 셀 병합할 때 확인 창이 뜬다.
                if (bTextBase == true)
                {
                    XSheet.get_Range(XSheet.Cells[1, 1], XSheet.Cells[XSheet.Rows.Count, MPGC.EXCEL_MAX_COL]).NumberFormat = "@";
                }

                i_column_count = 0;
                for (i = 0; i < l_Control.Columns.Count; i++)
                {
                    if (l_Control.Columns[i].Width > 0)
                    {
                        i_column_count++;
                    }
                }

                //'Column Header에 대한 셀서식
                Excel.Range with_1 = XSheet.get_Range(XSheet.Cells[i_rest_rows, 2], XSheet.Cells[i_rest_rows, i_column_count + 1]);
                with_1.HorizontalAlignment = ExcelComponent.XlHAlign.xlHAlignCenter; //-4108
                with_1.VerticalAlignment = ExcelComponent.XlVAlign.xlValignCenter; //-4108
                with_1.RowHeight = 26;
                with_1.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.FromArgb(200, 200, 200));
                with_1.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                with_1.Font.Bold = true;
                with_1.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                with_1.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                with_1.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                with_1.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                with_1.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;

                //' List에 대한 셀서식
                if (l_Control.Items.Count > 0)
                {
                    Excel.Range with_2 = XSheet.get_Range(XSheet.Cells[i_rest_rows + 1, 2], XSheet.Cells[i_rest_rows + l_Control.Items.Count, i_column_count + 1]);
                    with_2.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    with_2.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    with_2.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    if (l_Control.Items.Count > 1)
                    {
                        with_2.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        with_2.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = ExcelComponent.XlBorderWeight.xlHairline;
                        with_2.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        with_2.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = ExcelComponent.XlBorderWeight.xlHairline;
                    }

                    if (ColorFlag == true)
                    {
                        with_2.Font.Color = System.Drawing.ColorTranslator.ToOle(l_Control.ForeColor);
                    }
                }


                s_clip_data = "";

                for (i = 0; i < l_Control.Columns.Count; i++)
                {
                    if (l_Control.Columns[i].Width > 0)
                    {
                        s_clip_data = s_clip_data + l_Control.Columns[i].Text + "\t";
                    }
                }
                s_clip_data = s_clip_data + "\r";
                Clipboard.SetDataObject(s_clip_data);
                XSheet.get_Range("B" + i_rest_rows.ToString(), Missing.Value).Select();
                XSheet._PasteSpecial(null, null, null, null, null, null);
                s_clip_data = "";

                for (i = 0; i < l_Control.Items.Count; i++)
                {
                    for (k = 0; k < l_Control.Columns.Count; k++)
                    {
                        if (l_Control.Columns[k].Width > 0)
                        {
                            if (l_Control.Items[i].SubItems[k].Text.IndexOf("<") > 0 ||
                                l_Control.Items[i].SubItems[k].Text.IndexOf(">") > 0)
                            {
                                s_clip_data = s_clip_data + MPCF.Trim(l_Control.Items[i].SubItems[k].Text).Replace(" ", "").Replace("\r", "   ").Replace("\n", "  ").Replace("\t", " ") + "\t";
                            }
                            else
                            {
                                s_clip_data = s_clip_data + MPCF.Trim(l_Control.Items[i].SubItems[k].Text).Replace("\r", "   ").Replace("\n", "  ").Replace("\t", " ") + "\t";
                            }
                        }
                    }
                    s_clip_data = s_clip_data + "\r";
                    if ((i + 1) % 100 == 0 || i == l_Control.Items.Count - 1)
                    {
                        if ((i + 1) >= 100)
                        {
                            XSheet.get_Range("B" + ((int)(i_rest_rows + 1 + 100 * ((i) / 100))).ToString(), Missing.Value).Select();
                        }
                        else
                        {
                            XSheet.get_Range("B" + ((int)(i_rest_rows + 1)).ToString(), Missing.Value).Select();
                        }

                        Clipboard.SetDataObject(s_clip_data);
                        XSheet._PasteSpecial(null, null, null, null, null, null);
                        s_clip_data = "";
                    }
                }

                XSheet.get_Range(XSheet.Cells[i_rest_rows, 2], XSheet.Cells[i_rest_rows + l_Control.Items.Count - 1, 2 + i_column_count - 1]).CurrentRegion.EntireColumn.AutoFit();
                //XSheet.Cells[iRestRows, 2].CurrentRegion.EntireColumn.AutoFit();

                //For i = 0 To l_Control.Items.Count - 1
                //    If l_Control.Items(i).ImageIndex = SMALLICON_INDEX.IDX_ORDER_DELETE Or _
                //        l_Control.Items(i).ImageIndex = SMALLICON_INDEX.IDX_HISTORY_DELETE Or _
                //        l_Control.Items(i).ImageIndex = SMALLICON_INDEX.IDX_COL_SET_DELETE Then
                //        XSheet.Range(XSheet.Cells(i + iRestRows + 1, 2), XSheet.Cells(i + iRestRows + 1, i_columnCnt + 1)).Interior.Color = RGB(255, 0, 0)
                //    End If
                //Next i

                if (ColorFlag == true)
                {
                    for (i = 0; i < l_Control.Items.Count; i++)
                    {
                        lisItem = l_Control.Items[i];
                        if (lisItem.SubItems[0].ForeColor.IsEmpty == false)
                        {
                            if (lisItem.SubItems[0].ForeColor.ToArgb() != System.Drawing.Color.Black.ToArgb())
                            {
                                XSheet.get_Range(XSheet.Cells[i + i_rest_rows + 1, 2], XSheet.Cells[i + i_rest_rows + 1, i_column_count + 1]).Font.Color = System.Drawing.ColorTranslator.ToOle(lisItem.SubItems[0].ForeColor);

                            }
                        }
                    }
                }

                //'Title 에 대한 셀 서식 지정
                Excel.Range with_3 = XSheet.get_Range(XSheet.Cells[1, 2], XSheet.Cells[1, 2]);
                with_3.VerticalAlignment = ExcelComponent.XlVAlign.xlValignCenter;
                with_3.RowHeight = 30;
                with_3.Font.Size = MPGV.gfrmMDI.Font.SizeInPoints + 5;
                with_3.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                with_3.Font.Bold = true;
                with_3.Font.Name = "Arail";

                XSheet.get_Range(XSheet.Cells[1, 2], XSheet.Cells[1, 2]).Value2 = title;

                if (bShowDate == true)
                {
                    string sNowDate;
                    sNowDate = MPCF.ToStandardTime(DateTime.Now, MPGC.MP_CONVERT_DATETIME_FORMAT);
                    XSheet.get_Range(XSheet.Cells[2, 2], XSheet.Cells[2, 2]).Value2 = "\'Export Date : " + MPCF.MakeDateFormat(sNowDate);
                }

                if (i_row_count > 0)
                {
                    Clipboard.SetDataObject(Condition);
                    XSheet.get_Range(XSheet.Cells[3, 2], XSheet.Cells[3, 2]).Select();
                    XSheet._PasteSpecial(null, null, null, null, null, null);
                }

                XSheet.get_Range(XSheet.Cells[1, 1], XSheet.Cells[1, 1]).Select();

                Cursor.Current = Cursors.Default;
                return true;
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex.Message);
                return false;
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XBooks);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XApp);
                XSheet = null;
                XBook = null;
                XBooks = null;
                XApp = null;

                GC.Collect();
                Cursor.Current = Cursors.Default;
            }
        }

        //
        // SpreadSheetToExcel()
        //       - Export Data of Spread Sheet Control to Excel Application Data
        // Return Value
        //       - True or False
        // Arguments
        //       - ByRef l_control As Spread Sheet
        //       - ByVal title As string
        //       - Optional ByVal Condition As string
        //       - Optional ByVal ColorFlag As Boolean
        //       - Optional ByVal bTextBase As Boolean    '
        //
        public static bool SpreadSheetToExcel(FarPoint.Win.Spread.SheetView sheet, string title, string Condition, bool ColorFlag, bool bTextBase, bool bShowDate, int i_start_col, int i_end_col)
        {
            Excel.Application XApp = new Excel.Application();
            Excel.Workbooks XBooks = XApp.Workbooks;
            Excel.Workbook XBook = XBooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet XSheet = (Excel.Worksheet)XBook.ActiveSheet;

            int i_rest_rows;
            string s_clip_data;
            int i;
            int k;
            int m;
            int i_column_count;
            List<int> a_columns = new List<int>();
            string[] s_temp_str;
            int i_row_count = 0;
            bool b_add_column_flag;
            int i_row_col_count;

            int iStartCol, iEndCol;

            //Excel Conversion시 특정 구간을 추출 할 경우 엑셀 배경색 적용시 컬럼 순번 초기화ㅓ
            int n;

            try
            {
                XApp.Visible = false;
                iStartCol = i_start_col;
                iEndCol = i_end_col;

                System.Windows.Forms.Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;

                if (Trim(title).Length > 30)
                {
                    try
                    {
                        XSheet.Name = MPCF.Trim(title).Substring(0, 30);
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    try
                    {
                        XSheet.Name = MPCF.Trim(title);
                    }
                    catch (Exception)
                    {
                    }
                }
                XApp.Visible = true;

                i_rest_rows = 3;

                //'지정한 컬럼만 Export 할 경우가 아닌 경우
                if (iStartCol == -1)
                {
                    iStartCol = 0;
                }

                if (iEndCol == -1)
                {
                    iEndCol = sheet.ColumnCount - 1;
                }

                Condition = MPCF.Trim(Condition);
                if (Condition.Length > 0)
                {
                    if (Condition.Substring(Condition.Length - 1, 1) == "\r")
                    {
                        Condition = Condition.Substring(0, Condition.Length - 1);
                    }
                }

                if (Trim(Condition) != "")
                {
                    s_temp_str = Condition.Split("\r".ToCharArray()[0]);
                    i_row_count = (s_temp_str.Length - 1) - 0 + 1;
                    i_rest_rows = i_rest_rows + 1 + i_row_count;
                }

                //First Column Width
                XSheet.get_Range(XSheet.Cells[1, 1], XSheet.Cells[1, 1]).EntireColumn.ColumnWidth = 0.5;

                XSheet.get_Range(XSheet.Cells[1, 1], XSheet.Cells[XSheet.Rows.Count, MPGC.EXCEL_MAX_COL]).Font.Size = MPGV.gfrmMDI.Font.SizeInPoints;

                //'셀서식을 TEXT로 인식하도록 한다.
                //'단, 셀 서식이 Text일 경우에는 셀 병합할 때 확인 창이 뜬다.
                if (bTextBase == true)
                {
                    XSheet.get_Range(XSheet.Cells[1, 1], XSheet.Cells[XSheet.Rows.Count, MPGC.EXCEL_MAX_COL]).NumberFormat = "@";
                }

                if (sheet.RowHeader.Visible == true)
                {
                    i_column_count = sheet.RowHeader.ColumnCount;
                }
                else
                {
                    i_column_count = 0;
                }

                for (i = iStartCol; i <= iEndCol; i++)
                {
                    try
                    {
                    if (sheet.Columns[i].Width > 0 && sheet.Columns[i].Visible == true)
                    {
                        b_add_column_flag = true;
                        for (k = 0; k < sheet.ColumnHeader.RowCount; k++)
                        {
                            if (sheet.ColumnHeader.Cells[k, i].CellType is FarPoint.Win.Spread.CellType.ButtonCellType)
                            {
                                b_add_column_flag = false;
                                break;
                            }
                            else if (sheet.ColumnHeader.Cells[k, i].CellType is FarPoint.Win.Spread.CellType.EmptyCellType)
                            {
                                b_add_column_flag = false;
                                break;
                            }
                            else if (sheet.ColumnHeader.Cells[k, i].CellType is FarPoint.Win.Spread.CellType.ProgressCellType)
                            {
                                b_add_column_flag = false;
                                break;
                            }
                            else if (sheet.ColumnHeader.Cells[k, i].CellType is FarPoint.Win.Spread.CellType.SliderCellType)
                            {
                                b_add_column_flag = false;
                                break;
                            }
                        }

                        if (b_add_column_flag == true)
                        {
                            a_columns.Add(i);

                            i_column_count++;

                        }
                    }
                }
                    catch (Exception ex)
                    {
                        ShowMsgBox(ex.Message);
                        return false;
                    }
                }

                if (sheet.ColumnHeader.RowCount > 0)
                {
                    //'Column Header에 대한 셀서식
                    try
                    {
                    for (m = 0; m < i_column_count; m++)
                    {
                        if (sheet.RowHeader.Visible == true && sheet.RowHeader.ColumnCount > m)
                        {
                            Excel.Range with_1 = XSheet.get_Range(XSheet.Cells[i_rest_rows, m + 2], XSheet.Cells[i_rest_rows + sheet.ColumnHeader.RowCount - 1, m + 2]);
                            with_1.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        }
                        else
                        {

                            if (sheet.RowHeader.Visible == true)
                            {
                                i = a_columns[m - sheet.RowHeader.ColumnCount];
                            }
                            else
                            {
                                i = a_columns[m];
                            }

                            for (k = 0; k < sheet.ColumnHeader.RowCount; k++)
                            {
                                if (sheet.ColumnHeader.Cells[k, i].RowSpan == 1)
                                {
                                    Excel.Range with_2 = XSheet.get_Range(XSheet.Cells[k + i_rest_rows, m + 2], XSheet.Cells[k + i_rest_rows, m + 2]);
                                    with_2.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                                }
                                else if (sheet.ColumnHeader.Cells[k, i].RowSpan > 1)
                                {
                                    Excel.Range with_3 = XSheet.get_Range(XSheet.Cells[k + i_rest_rows, m + 2], XSheet.Cells[k + i_rest_rows + sheet.ColumnHeader.Cells[k, i].RowSpan - 1, m + 2]);
                                    with_3.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                                    k += sheet.ColumnHeader.Cells[k, i].RowSpan - 1;
                                }
                            }
                        }
                    }
                    }
                    catch (Exception ex)
                    {
                        ShowMsgBox(GetMessage(61) + "\n\r" + ex.StackTrace);
                        return false;
                    }

                    for (k = 0; k < sheet.ColumnHeader.RowCount; k++)
                    {
                        s_clip_data = "";
                        for (i = 0; i < i_column_count; i++)
                        {
                            if (sheet.RowHeader.Visible == true && sheet.RowHeader.ColumnCount > i)
                            {
                                s_clip_data = s_clip_data + " " + "\t";
                            }
                            else
                            {
                                if (sheet.RowHeader.Visible == true)
                                {
                                    if (sheet.ColumnHeader.Cells[0, k].Text != "")
                                    {
                                        s_clip_data = s_clip_data + sheet.ColumnHeader.Cells[k, a_columns[i - sheet.RowHeader.ColumnCount]].Text + "\t";
                                    }
                                    else
                                    {
                                        s_clip_data = s_clip_data + sheet.ColumnHeader.Columns[i - 1].Label + "\t";
                                    }
                                }
                                else
                                {
                                    if (sheet.ColumnHeader.Cells[0, k].Text != "")
                                    {
                                        s_clip_data = s_clip_data + sheet.ColumnHeader.Cells[k, a_columns[i]].Text + "\t";
                                    }
                                    else
                                    {
                                        s_clip_data = s_clip_data + sheet.ColumnHeader.Columns[i - 1].Label + "\t";
                                    }
                                }
                                //if (sheet.ColumnHeader.Cells[j, aColumn[i]].ColumnSpan > 1)
                                //{
                                //    for (k = 0; k < sheet.ColumnHeader.Cells[j, aColumn[i]].ColumnSpan - 1; k++)
                                //    {
                                //        sClipData = sClipData + " " + "\t";
                                //    }
                                //    i += sheet.ColumnHeader.Cells[j, aColumn[i]].ColumnSpan - 1;
                                //}
                            }
                        }

                        s_clip_data = s_clip_data.Replace('\r', ' ').Replace('\n', ' ');
                        s_clip_data = s_clip_data + "\r";
                        Clipboard.SetDataObject(s_clip_data);
                        XSheet.get_Range("B" + ((int)(i_rest_rows + k)).ToString(), Missing.Value).Select();
                        XSheet._PasteSpecial(null, null, null, null, null, null);
                    }

                    XApp.DisplayAlerts = false;

                    for (k = 0; k < sheet.ColumnHeader.RowCount; k++)
                    {
                        for (m = 0; m < i_column_count; m++)
                        {
                            if (sheet.RowHeader.Visible == true && sheet.RowHeader.ColumnCount > m)
                            {
                                Excel.Range with_4 = XSheet.get_Range(XSheet.Cells[k + i_rest_rows, 2], XSheet.Cells[k + i_rest_rows, 2 + sheet.RowHeader.ColumnCount - 1]);
                                with_4.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                                m += sheet.RowHeader.ColumnCount - 1;
                            }
                            else
                            {
                                if (sheet.RowHeader.Visible == true)
                                {
                                    i = a_columns[m - sheet.RowHeader.ColumnCount];
                                }
                                else
                                {
                                    i = a_columns[m];
                                }

                                //if (sheet.ColumnHeader.Cells[j, i].ColumnSpan == 1)
                                //{
                                Excel.Range with_5 = XSheet.get_Range(XSheet.Cells[k + i_rest_rows, m + 2], XSheet.Cells[k + i_rest_rows, m + 2]);
                                with_5.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                                //}
                                //else if (sheet.ColumnHeader.Cells[j, i].ColumnSpan > 1)
                                //{
                                //    Excel.Range with_6 = XSheet.get_Range(XSheet.Cells[j + iRestRows, k + 2], XSheet.Cells[j + iRestRows, k + 2 + sheet.ColumnHeader.Cells[j, i].ColumnSpan - 1]);
                                //    with_6.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                                //    with_6.Select();
                                //    with_6.Merge(null);

                                //    k += sheet.ColumnHeader.Cells[j, i].ColumnSpan - 1;
                                //    //While aColumn(k) <= i
                                //    //    k += 1
                                //    //    If k > i_columnCnt - 1 Then Exit For
                                //    //End While
                                //    //k -= 1
                                //}
                            }
                        }
                    }


                    Excel.Range with_7 = XSheet.get_Range(XSheet.Cells[i_rest_rows, 2], XSheet.Cells[i_rest_rows + sheet.ColumnHeader.RowCount - 1, i_column_count + 1]);
                    with_7.HorizontalAlignment = ExcelComponent.XlHAlign.xlHAlignCenter; //-4108
                    with_7.VerticalAlignment = ExcelComponent.XlVAlign.xlValignCenter; //-4108
                    with_7.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.FromArgb(200, 200, 200));
                    with_7.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                    with_7.Font.Bold = true;
                    with_7.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    with_7.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    with_7.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    with_7.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;



                    i_rest_rows += sheet.ColumnHeader.RowCount;
                }
                if (sheet.RowHeader.Visible == true && sheet.RowHeader.ColumnCount > 0)
                {
                    //'Row Header 셀서식
                    for (m = 0; m < sheet.RowHeader.ColumnCount; m++)
                    {
                        for (k = 0; k < sheet.RowCount; k++)
                        {
                            if (sheet.RowHeader.Cells[k, m].RowSpan == 1)
                            {
                                Excel.Range with_8 = XSheet.get_Range(XSheet.Cells[k + i_rest_rows, m + 2], XSheet.Cells[k + i_rest_rows, m + 2]);
                                with_8.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                            }
                            else if (sheet.RowHeader.Cells[k, i].RowSpan > 1)
                            {
                                Excel.Range with_9 = XSheet.get_Range(XSheet.Cells[k + i_rest_rows, m + 2], XSheet.Cells[k + i_rest_rows + sheet.RowHeader.Cells[k, i].RowSpan - 1, m + 2]);
                                with_9.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                                k += sheet.RowHeader.Cells[k, i].RowSpan - 1;
                            }
                        }

                    }



                    for (k = 0; k < sheet.RowCount; k++)
                    {
                        for (m = 0; m < sheet.RowHeader.ColumnCount; m++)
                        {
                            if (sheet.RowHeader.Cells[k, m].ColumnSpan == 1)
                            {
                                Excel.Range with_10 = XSheet.get_Range(XSheet.Cells[k + i_rest_rows, m + 2], XSheet.Cells[k + i_rest_rows, m + 2]);
                                with_10.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                            }
                            else if (sheet.RowHeader.Cells[k, i].ColumnSpan > 1)
                            {
                                Excel.Range with_11 = XSheet.get_Range(XSheet.Cells[k + i_rest_rows, m + 2], XSheet.Cells[k + i_rest_rows, m + 2 + sheet.RowHeader.Cells[k, i].ColumnSpan - 1]);
                                with_11.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                                m += sheet.RowHeader.Cells[k, i].ColumnSpan - 1;
                            }
                        }
                    }

                    Excel.Range with_12 = XSheet.get_Range(XSheet.Cells[i_rest_rows, 2], XSheet.Cells[i_rest_rows + sheet.RowCount - 1, 2 + sheet.RowHeader.ColumnCount - 1]);
                    with_12.HorizontalAlignment = ExcelComponent.XlHAlign.xlHAlignCenter; //-4108
                    with_12.VerticalAlignment = ExcelComponent.XlVAlign.xlValignCenter; //-4108
                    //with_12.Interior.Color = Information.RGB(200, 200, 200);
                    with_12.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.FromArgb(200, 200, 200));
                    with_12.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                    with_12.Font.Bold = true;
                    with_12.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    //.Borders(modExcelComponent.XlBordersIndex.xlEdgeRight).LineStyle = modExcelComponent.XlLineStyle.xlContinuous
                    //.Borders(modExcelComponent.XlBordersIndex.xlEdgeTop).LineStyle = modExcelComponent.XlLineStyle.xlContinuous
                    //.Borders(modExcelComponent.XlBordersIndex.xlEdgeBottom).LineStyle = modExcelComponent.XlLineStyle.xlContinuous
                }
                //'List에 대한 셀서식
                if (sheet.RowCount > 0)
                {
                    Excel.Range with_13 = XSheet.get_Range(XSheet.Cells[i_rest_rows, 2 + ((sheet.RowHeader.Visible == true) ? sheet.RowHeader.ColumnCount : 0)], XSheet.Cells[i_rest_rows + sheet.RowCount - 1, i_column_count + 1]);
                    with_13.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    with_13.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    with_13.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                    if (sheet.RowCount > 1)
                    {
                        with_13.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        with_13.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = ExcelComponent.XlBorderWeight.xlHairline;
                        with_13.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = ExcelComponent.XlLineStyle.xlContinuous;
                        with_13.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = ExcelComponent.XlBorderWeight.xlHairline;
                    }
                }

                for (i = 0; i < sheet.RowCount; i++)
                {
                    s_clip_data = "";

                    for (k = 0; k < i_column_count; k++)
                    {
                        if (sheet.RowHeader.Visible == true && sheet.RowHeader.ColumnCount > k)
                        {
                            s_clip_data = s_clip_data + MPCF.Trim(sheet.RowHeader.Cells[i, k].Text).Replace(" ", "").Replace("\r", "   ").Replace("\n", "  ").Replace("\t", " ") + "\t";
                        }
                        else
                        {
                            if (sheet.RowHeader.Visible == true)
                            {
                                if (MPCF.Trim(sheet.Cells[i, a_columns[k - sheet.RowHeader.ColumnCount]].Value).IndexOf("<") > 0 ||
                                    MPCF.Trim(sheet.Cells[i, a_columns[k - sheet.RowHeader.ColumnCount]].Value).IndexOf(">") > 0)
                                {
                                    s_clip_data = s_clip_data + MPCF.Trim(sheet.Cells[i, a_columns[k - sheet.RowHeader.ColumnCount]].Value).Replace(" ", "").Replace("\r", "   ").Replace("\n", "  ").Replace("\t", " ") + "\t";
                                }
                                else
                                {
                                    s_clip_data = s_clip_data + MPCF.Trim(sheet.Cells[i, a_columns[k - sheet.RowHeader.ColumnCount]].Value).Replace("\r", "   ").Replace("\n", "  ").Replace("\t", " ") + "\t";
                                }
                            }
                            else
                            {
                                if (MPCF.Trim(sheet.Cells[i, a_columns[k]].Value).IndexOf("<") > 0 ||
                                    MPCF.Trim(sheet.Cells[i, a_columns[k]].Value).IndexOf(">") > 0)
                                {
                                    s_clip_data = s_clip_data + MPCF.Trim(sheet.Cells[i, a_columns[k]].Value).Replace(" ", "").Replace("\r", "   ").Replace("\n", "  ").Replace("\t", " ") + "\t";
                                }
                                else
                                {
                                    s_clip_data = s_clip_data + MPCF.Trim(sheet.Cells[i, a_columns[k]].Value).Replace("\r", "   ").Replace("\n", "  ").Replace("\t", " ") + "\t";
                                }
                            }
                        }
                    }

                    s_clip_data = s_clip_data.Replace('\r', ' ').Replace('\n', ' ');
                    s_clip_data = s_clip_data + "\r";
                    Clipboard.SetDataObject(s_clip_data);
                    XSheet.get_Range("B" + ((int)(i_rest_rows + i)).ToString(), Missing.Value).Select();
                    XSheet._PasteSpecial(null, null, null, null, null, null);
                }

                //XSheet.get_Range(XSheet.Cells[iRestRows - sheet.ColumnHeader.RowCount, 2], XSheet.Cells[iRestRows + sheet.RowCount - 1, 2 + i_columnCnt - 1]).Select();
                XSheet.get_Range(XSheet.Cells[i_rest_rows - sheet.ColumnHeader.RowCount, 2], XSheet.Cells[i_rest_rows + sheet.RowCount - 1, 2 + i_column_count - 1]).CurrentRegion.EntireColumn.AutoFit();
                //XSheet.get_Range(iRestRows - sheet.ColumnHeader.RowCount, 2).CurrentRegion.EntireColumn.AutoFit();

                if (ColorFlag == true)
                {
                    if (sheet.RowHeader.Visible == true)
                    {
                        i_row_col_count = sheet.RowHeader.ColumnCount;
                    }
                    else
                    {
                        i_row_col_count = 0;
                    }
                    for (i = 0; i < sheet.RowCount; i++)
                    {
                        n = iStartCol;
                        for (k = iStartCol; k <= iEndCol; k++)
                        {
                            //Column의 Width = 0 일 경우 skip
                            if (sheet.Cells[i, k].Column.Width == 0)
                            {
                                continue;
                            }
                            if (sheet.Cells[i, k].ForeColor.IsEmpty == false)
                            {
                                if (sheet.Cells[i, k].ForeColor.ToArgb() != System.Drawing.Color.Black.ToArgb())
                                {
                                    XSheet.get_Range(XSheet.Cells[i + i_rest_rows, n + 2 + i_row_col_count], XSheet.Cells[i + i_rest_rows, n + 2 + i_row_col_count]).Font.Color = System.Drawing.ColorTranslator.ToOle(sheet.Cells[i, k].ForeColor);
                                }
                            }
                            if (sheet.Cells[i, k].BackColor.IsEmpty == false)
                            {
                                if (sheet.Cells[i, k].BackColor.ToArgb() != System.Drawing.Color.White.ToArgb())
                                {
                                    XSheet.get_Range(XSheet.Cells[i + i_rest_rows, n + 2 + i_row_col_count], XSheet.Cells[i + i_rest_rows, n + 2 + i_row_col_count]).Interior.Color = System.Drawing.ColorTranslator.ToOle(sheet.Cells[i, k].BackColor);
                                }
                            }
                            n++;
                        }
                    }

                }

                //'Title 에 대한 셀 서식 지정
                Excel.Range with_14 = XSheet.get_Range(XSheet.Cells[1, 2], XSheet.Cells[1, 2]);
                with_14.VerticalAlignment = ExcelComponent.XlVAlign.xlValignCenter;
                with_14.RowHeight = 30;
                with_14.Font.Size = MPGV.gfrmMDI.Font.SizeInPoints + 5;
                with_14.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                with_14.Font.Bold = true;
                with_14.Font.Name = "Arail";

                XSheet.get_Range(XSheet.Cells[1, 2], XSheet.Cells[1, 2]).Value2 = title;

                if (bShowDate == true)
                {
                    string sNowDate;
                    sNowDate = MPCF.ToStandardTime(DateTime.Now, MPGC.MP_CONVERT_DATETIME_FORMAT);
                    XSheet.get_Range(XSheet.Cells[2, 2], XSheet.Cells[2, 2]).Value2 = "\'Export Date : " + MPCF.MakeDateFormat(sNowDate);
                }

                if (i_row_count > 0)
                {
                    Clipboard.SetDataObject(Condition);
                    XSheet.get_Range(XSheet.Cells[3, 2], XSheet.Cells[3, 2]).Select();
                    XSheet._PasteSpecial(null, null, null, null, null, null);
                }

                XApp.DisplayAlerts = true;

                XSheet.get_Range(XSheet.Cells[1, 1], XSheet.Cells[1, 1]).Select();

                Cursor.Current = Cursors.Default;
                return true;
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex.Message);
                return false;
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XBooks);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(XApp);
                XSheet = null;
                XBook = null;
                XBooks = null;
                XApp = null;

                GC.Collect();
                Cursor.Current = Cursors.Default;
            }
        }


        // GetIndexedControl()
        //       - parentControl ?꾩뿉 ?덈뒗 ?숈씪??Prefix?대쫫??媛吏?control留뚯쓣 ?대쫫?쒖쑝濡??뺣젹?섏뿬 由ъ뒪?몃줈 留뚮뱺??
        // Return Value
        //       - ArrayLiat : ?대쫫?쇰줈 ?뺣젹??control??由ъ뒪??
        // Arguments
        //       - ByVal sControlName As String : Control??Prefix?대쫫
        //        - ByVal parentControl As Control : Control?ㅼ씠 ?щ씪媛 ?덈뒗 parentControl
        public static ArrayList GetIndexedControl(string sControlName, Control parentControl)
        {
            Control control;
            ArrayList alControl = new ArrayList();
            ControlNameSort nameSort = new ControlNameSort();

            foreach (Control tempLoopVar_control in parentControl.Controls)
            {
                control = tempLoopVar_control;
                if (control.Name.Length > Trim(sControlName).Length)
                {
                    if (control.Name.ToUpper().Substring(0, Trim(sControlName).Length) == Trim(sControlName).ToUpper())
                    {
                        alControl.Add(control);
                    }
                }
            }
            alControl.Sort(nameSort);
            return alControl;
        }

        // GetChildForm()
        //       - Child Form???덈뒗吏 ?뺤씤?쒕떎
        // Return Value
        //       - True or False
        // Arguments
        //       - ByVal MDIForm As Form : MDI Parent Form
        //       - ByVal ChildForm As String : ?꾩옱 ?꾩슱 Child Form Name
        //
        public static Form GetChildForm(Form MDIForm, string ChildForm)
        {
            return GetChildForm(MDIForm, ChildForm, true);
        }
        public static Form GetChildForm(Form MDIForm, string ChildForm, bool FormActive)
        {
            return GetChildForm(MDIForm, ChildForm, FormActive, null);
        }
        public static Form GetChildForm(Form MDIForm, string ChildForm, bool FormActive, string sFuncName)
        {
            int iCount;

            iCount = GetCurrentGDICount();
            if (iCount > MPGC.MP_MAX_GDI_COUNT)
            {
                throw new Exception(GetMessage(60));
            }

            ChildForm = ToUpper(ChildForm);
            iCount = 0;

            try
            {
                if (MDIForm.ActiveMdiChild != null)
                {
                    foreach (Form SForm in MDIForm.MdiChildren)
                    {
                        //멀티폼 지원 폼
                        if (ToUpper(SForm.Name) == ChildForm)
                        {
                            if (string.IsNullOrEmpty(sFuncName) == false)
                            {
                                if (SForm.Tag.ToString() != sFuncName)
                                    continue;
                            }
                            //Modify by J.S. 2011.10.13 메뉴에 통합된 flexible inquery는 multi로 로딩가능
                            if (iCount < 9 && (ChildForm == "FRMWIPVIEWLOTSTATUS" ||
                                               ChildForm == "FRMWIPVIEWLOTHISTORY" ||
                                               ChildForm == "FRMWIPVIEWSUBLOTLIST" ||
                                               ChildForm == "FRMBASVIEWFLEXIBLEINQUIRYMENU"))
                            {
                                iCount++;
                            }
                            else
                            {
                                if (FormActive == true)
                                {
                                    SForm.Activate();
                                }
                                return SForm;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex.Message, "GetChildForm()", MessageBoxButtons.OK, 1);
            }

            return null;
        }

        // ChangeStringToDate()
        //       -   Change 14 byte DateTime format of DateTimePicker
        // Return Value
        //       - String : 14 byte DateTime
        // Arguments
        //       - ByVal dtpTime As DateTimePicker
        public static DateTime ToDate(string str)
        {
            try
            {
                string sTime = Trim(str);
                DateTime DTime;

                int year;
                int month;
                int day;
                int hour;
                int minute;
                int second;

                year = 1;
                month = 1;
                day = 1;
                hour = 0;
                minute = 0;
                second = 0;

                if (CheckNumeric(sTime) == true)
                {
                    if (sTime.Length >= 8)
                    {
                        year = MPCF.ToInt(sTime.Substring(0, 4));
                        month = MPCF.ToInt(sTime.Substring(4, 2));
                        day = MPCF.ToInt(sTime.Substring(6, 2));
                    }
                    if (sTime.Length >= 14)
                    {
                        hour = MPCF.ToInt(sTime.Substring(8, 2));
                        minute = MPCF.ToInt(sTime.Substring(10, 2));
                        second = MPCF.ToInt(sTime.Substring(12, 2));
                    }
                    if (sTime.Length == 6)
                    {
                        hour = MPCF.ToInt(sTime.Substring(0, 2));
                        minute = MPCF.ToInt(sTime.Substring(2, 2));
                        second = MPCF.ToInt(sTime.Substring(4, 2));
                    }

                    DTime = new DateTime(year, month, day, hour, minute, second);
                }
                else
                {
                    DTime = DateTime.Now;
                }

                return DTime;


            }
            catch (Exception ex)
            {
                ShowMsgBox("MPCF.ToDate()\n" + ex.Message);
                return DateTime.Now;
            }
        }

        // ToDate()
        //       -   Change 14 byte DateTime format of DateTimePicker
        // Return Value
        //       - String : 14 byte DateTime
        // Arguments
        //       - ByVal dtpTime As DateTimePicker
        public static string ToDate(DateTimePicker dtpTime)
        {
            string sDateTime = "";
            DateTime DTime;

            DTime = dtpTime.Value;

            if (MPGV.gShiftInfor.bVariableShift == false)
            {
                if (MPGV.gShiftInfor.cShift1DayFlag == 'T' || MPGV.gShiftInfor.cShift1DayFlag == 'P')
                {
                    DTime = DTime.AddDays(+1);
                }
            }
            else
            {
                DTime = DTime.AddDays(+1);
            }
            sDateTime = MPCF.ToStandardTime(DTime, MPGC.MP_CONVERT_DATE_FORMAT);
            sDateTime = sDateTime + MPGV.gShiftInfor.sShift1StartTime;

            return sDateTime;
        }

        // ToDate()
        //       -   Change 14 byte DateTime format of DateTimePicker
        // Return Value
        //       - String : 14 byte DateTime
        // Arguments
        //       - ByVal dtpTime As DateTimePicker
        //
        public static string DateToString(UltraCalendarCombo dtpTime)
        {

            try
            {
                string sDateTime = "";
                DateTime DTime;

                DTime = (DateTime)dtpTime.Value;

                if (MPGV.gShiftInfor.bVariableShift == false)
                {
                    if (MPGV.gShiftInfor.cShift1DayFlag == 'T')
                    {
                        DTime = DTime.AddDays(+1);
                    }
                }
                else
                {
                    DTime = DTime.AddDays(+1);
                }

                sDateTime = MPCF.ToStandardTime(DTime, MPGC.MP_CONVERT_DATE_FORMAT);
                sDateTime = sDateTime + MPGV.gShiftInfor.sShift1StartTime;

                return sDateTime;
            }
            catch (Exception ex)
            {
                ShowMsgBox("MPCF.DateToString()\n" + ex.Message);
                return null;
            }

        }
        // ToDate()
        //       - Change 14 byte DateTime format of object
        // Return Value
        //       - String : 14 byte DateTime
        // Arguments
        //       - ByVal objtime As object
        //
        public static string ToDate(object objtime)
        {

            string sDateTime = "";
            DateTime DTime;

            try
            {
                DTime = (DateTime)objtime;


                if (MPGV.gShiftInfor.bVariableShift == false)
                {
                    if (MPGV.gShiftInfor.cShift1DayFlag == 'T')
                    {
                        DTime = DTime.AddDays(+1);
                    }
                }
                else
                {
                    DTime = DTime.AddDays(+1);
                }
                sDateTime = MPCF.ToStandardTime(DTime, MPGC.MP_CONVERT_DATE_FORMAT);
                sDateTime = sDateTime + MPGV.gShiftInfor.sShift1StartTime;

                return sDateTime;

            }
            catch (Exception ex)
            {
                ShowMsgBox("MPCF.FromDate()\n" + ex.Message);
                return "";
            }

        }
        // <<Check>>
        public static void LoadCaptionList()
        {
            int CaptionCount = 0;
            string[] Captions = null;
            string input = "";

            try
            {
                MPGV.goCaptionList.Items.Clear();

                if (!File.Exists(MPGV.gsCaptionFileName))
                {
                    return;
                }

                StreamReader sr = new StreamReader(MPGV.gsCaptionFileName, System.Text.Encoding.Default);

                CaptionCount = 0;

                input = sr.ReadLine();

                while (input != null)
                {
                    if (input.StartsWith("\'") == false)
                    {
                        // Modified by J.H.Baek(2006.2.14)
                        //Captions = input.Split(";", 3)
                        Captions = input.Split(';');
                        if (Captions.Length == 3)
                        {
                            MPGV.goCaptionList.Items.Add(Trim(Captions[0]));
                            MPGV.goCaptionList.Items[CaptionCount].SubItems.Add(Trim(Captions[1]));
                            MPGV.goCaptionList.Items[CaptionCount].SubItems.Add(Trim(Captions[2]));
                            CaptionCount++;
                        }
                    }

                    input = sr.ReadLine();

                }

                sr.Close();

            }
            catch (Exception ex)
            {
                ShowMsgBox("MPCF.LoadCaptionList()\n" + ex.Message);
            }

        }

        public static void ChangeMyCaption(ref Form LoadingForm, string Language)
        {

            int LanguageType = 0;

            Control Ctrl;
            System.Windows.Forms.MenuItem MItem;

            //On Error Resume Next  - Cannot Convert to C#

            SubstituteCaption(LoadingForm.Text, MPCF.ToInt(MPGV.gcLanguage));

            if (LoadingForm.Menu != null)
            {
                foreach (System.Windows.Forms.MenuItem tempLoopVar_MItem in LoadingForm.Menu.MenuItems)
                {
                    MItem = tempLoopVar_MItem;
                    ChangeMyMenus(ref MItem, LanguageType);
                }
            }

            foreach (Control tempLoopVar_Ctrl in LoadingForm.Controls)
            {
                Ctrl = tempLoopVar_Ctrl;
                ChangeMyControls(Ctrl, LanguageType);
            }

        }

        private static void ChangeMyMenus(ref System.Windows.Forms.MenuItem mnu, int LanguageType)
        {
            System.Windows.Forms.MenuItem SMITEM;

            SubstituteCaption(mnu.Text, LanguageType);

            if (mnu.MenuItems != null)
            {
                foreach (System.Windows.Forms.MenuItem tempLoopVar_SMITEM in mnu.MenuItems)
                {
                    SMITEM = tempLoopVar_SMITEM;
                    ChangeMyMenus(ref SMITEM, LanguageType);
                }
            }
        }

        private static void ChangeMyControls(Control Ctrl, int LanguageType)
        {
            int I;
            int J;
            System.Windows.Forms.MenuItem MITEM;

            //On Error Resume Next  - Cannot Convert to C#

            if (Ctrl is System.Windows.Forms.TextBox)
            {
                return;
            }

            SubstituteCaption(Ctrl.Text, LanguageType);

            if (Ctrl is System.Windows.Forms.GroupBox || Ctrl is Panel)
            {
                for (I = 0; I < Ctrl.Controls.Count; I++)
                {
                    if (Ctrl.Controls[I] is System.Windows.Forms.GroupBox || Ctrl.Controls[I] is Panel || Ctrl.Controls[I] is ListView || Ctrl.Controls[I] is TabControl)
                    {
                        ChangeMyControls(Ctrl.Controls[I], LanguageType);
                    }
                    else
                    {
                        if (!(Ctrl.Controls[I] is System.Windows.Forms.TextBox))
                        {
                            SubstituteCaption(Ctrl.Controls[I].Text, LanguageType);
                            if (Ctrl.Controls[I].ContextMenu != null)
                            {
                                foreach (System.Windows.Forms.MenuItem tempLoopVar_MITEM in Ctrl.Controls[I].ContextMenu.MenuItems)
                                {
                                    MITEM = tempLoopVar_MITEM;
                                    ChangeMyMenus(ref MITEM, LanguageType);
                                }
                            }
                        }
                    }
                }

            }
            else if (Ctrl is TabControl)
            {
                TabControl Tab;
                Tab = (TabControl)Ctrl;
                for (I = 0; I < Tab.TabPages.Count; I++)
                {
                    SubstituteCaption(Tab.TabPages[I].Text, LanguageType);
                    for (J = 0; J < Tab.TabPages[I].Controls.Count; J++)
                    {
                        if (Tab.TabPages[I].Controls[J] is System.Windows.Forms.GroupBox || Tab.TabPages[I].Controls[J] is Panel || Tab.TabPages[I].Controls[J] is ListView || Tab.TabPages[I].Controls[J] is TabControl)
                        {
                            ChangeMyControls(Tab.TabPages[I].Controls[J], LanguageType);
                        }
                        else
                        {
                            if (!(Tab.TabPages[I].Controls[J] is System.Windows.Forms.TextBox))
                            {
                                SubstituteCaption(Tab.TabPages[I].Controls[J].Text, LanguageType);
                                if (Tab.TabPages[I].Controls[J].ContextMenu != null)
                                {
                                    foreach (System.Windows.Forms.MenuItem tempLoopVar_MITEM in Tab.TabPages[I].Controls[J].ContextMenu.MenuItems)
                                    {
                                        MITEM = tempLoopVar_MITEM;
                                        ChangeMyMenus(ref MITEM, LanguageType);
                                    }
                                }
                            }
                        }
                    }
                }

            }
            else if (Ctrl is ListView)
            {
                ListView List;
                List = (ListView)Ctrl;
                for (I = 0; I < List.Columns.Count; I++)
                {
                    SubstituteCaption(List.Columns[I].Text, LanguageType);
                }

            }
            else if (Ctrl is ToolBar)
            {
                ToolBar tbar;
                tbar = (ToolBar)Ctrl;
                for (I = 0; I < tbar.Buttons.Count; I++)
                {
                    SubstituteCaption(tbar.Buttons[I].Text, LanguageType);
                    SubstituteCaption(tbar.Buttons[I].ToolTipText, LanguageType);
                    if (tbar.Buttons[I].DropDownMenu != null)
                    {
                        foreach (System.Windows.Forms.MenuItem tempLoopVar_MITEM in tbar.Buttons[I].DropDownMenu.MenuItems)
                        {
                            MITEM = tempLoopVar_MITEM;
                            ChangeMyMenus(ref MITEM, LanguageType);
                        }
                    }
                }
            }

            if (Ctrl.ContextMenu != null)
            {
                foreach (System.Windows.Forms.MenuItem tempLoopVar_MITEM in Ctrl.ContextMenu.MenuItems)
                {
                    MITEM = tempLoopVar_MITEM;
                    ChangeMyMenus(ref MITEM, LanguageType);
                }
            }

        }

        /// <summary>
        /// 언어 타입에따라 캡션을 변경해주는 내부 Common Function
        /// </summary>
        /// <param name="OriginalText">변경할 문자열</param>
        /// <param name="languageType">언어 타입</param>
        private static void SubstituteCaption(string OriginalText, int languageType)
        {
            int CaptionCount;

            for (CaptionCount = 0; CaptionCount < MPGV.goCaptionList.Items.Count; CaptionCount++)
            {
                if (OriginalText == MPGV.goCaptionList.Items[CaptionCount].SubItems[0].Text)
                {
                    OriginalText = MPGV.goCaptionList.Items[CaptionCount].SubItems[languageType].Text;
                    break;
                }
            }
        }

        public static void SelectText(System.Windows.Forms.TextBox myText, bool Focus_Flag)
        {

            try
            {
                myText.SelectionStart = 0;
                myText.SelectionLength = myText.Text.Length;
                if (Focus_Flag == true)
                {
                    myText.Focus();
                }
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex.Message);
            }

        }

        public static void FieldAdjust(Control cParent, Control cLeft, Control cRight, Control cMid, int iMidSize)
        {

            int iSideSize = 0;
            int iWidth = 0;
            int iHeight = 0;
            int iLeftPad = 0;
            int iTopPad = 0;

            if (cParent is System.Windows.Forms.GroupBox)
            {
                iWidth = cParent.Width - 6;
                iHeight = cParent.Height - 20;

                iLeftPad = 3;
                iTopPad = 18;
            }
            else if (cParent is Panel)
            {
                iLeftPad = ((Panel)cParent).DockPadding.Left;
                iTopPad = ((Panel)cParent).DockPadding.Top;

                iWidth = cParent.Width - (iLeftPad + ((Panel)cParent).DockPadding.Right);
                iHeight = cParent.Height - (iTopPad + ((Panel)cParent).DockPadding.Bottom);
            }

            iSideSize = (iWidth - iMidSize) / 2;
            cLeft.Width = iSideSize;
            cRight.Width = iSideSize;

            cMid.Width = iMidSize - 2;

            if (cMid.Dock == DockStyle.None)
            {
                cMid.Left = iLeftPad + iSideSize + 1;
                cMid.Top = iTopPad + 1;
                cMid.Height = iHeight - 2;
            }
            if (cLeft.Dock == DockStyle.None)
            {
                cLeft.Height = iHeight;
                cLeft.Left = iLeftPad;
                cLeft.Top = iTopPad;
            }
            if (cRight.Dock == DockStyle.None)
            {
                cRight.Height = iHeight;
                cRight.Left = iLeftPad + iSideSize + iMidSize;
                cRight.Top = iTopPad;
            }

        }

        /// <summary>
        ///  Control의 칼럼 헤더 사이즈를 내용에 맞게 조절한다.
        /// </summary>
        /// <param name="obj">List Control</param>
        public static void FitColumnHeader(object obj)
        {
            FitColumnHeader(obj, -1, -1, -1, -1, false);
        }
        /// <summary>
        ///  Control의 칼럼 헤더 사이즈를 내용에 맞게 조절한다.
        /// </summary>
        /// <param name="obj">List Control</param>
        public static void FitColumnHeader(object obj, bool b_skip_fixed_size_header)
        {
            FitColumnHeader(obj, -1, -1, -1, -1, b_skip_fixed_size_header);
        }
        /// <summary>
        ///  Control의 칼럼 헤더 사이즈를 내용에 맞게 조절한다.
        /// </summary>
        /// <param name="obj">List Control</param>
        /// <param name="i_start_column_index">시작 컬럼</param>
        /// <param name="i_end_column_index">끝 컬럼</param>
        public static void FitColumnHeader(object obj, int i_start_column_index, int i_end_column_index)
        {
            FitColumnHeader(obj, i_start_column_index, i_end_column_index, -1, -1, false);
        }
        /// <summary>
        ///  Control의 칼럼 헤더 사이즈를 내용에 맞게 조절한다.
        /// </summary>
        /// <param name="obj">List Control</param>
        /// <param name="i_start_column_index">시작 컬럼</param>
        /// <param name="i_end_column_index">끝 컬럼</param>
        public static void FitColumnHeader(object obj, int i_start_column_index, int i_end_column_index, bool b_skip_fixed_size_header)
        {
            FitColumnHeader(obj, i_start_column_index, i_end_column_index, -1, -1, b_skip_fixed_size_header);
        }
        /// <summary>
        ///  Control의 칼럼 헤더 사이즈를 내용에 맞게 조절한다.
        /// </summary>
        /// <param name="obj">List Control</param>
        /// <param name="i_start_column_index">시작 컬럼</param>
        /// <param name="i_end_column_index">끝 컬럼</param>
        /// <param name="i_word_warp_col">Word Wrap을 사용할 컬럼 인덱스</param>
        /// <param name="i_word_wrap_max_size">Word Wrap을 사용할 컬럼의 최대 문자열 길이</param>
        public static void FitColumnHeader(object obj, int i_start_column_index, int i_end_column_index, int i_word_wrap_col, int i_word_wrap_max_size, bool b_skip_fixed_size_header)
        {
            float colWidth;
            int i;
            int j;

            try
            {
                if (obj is FarPoint.Win.Spread.FpSpread)
                {
                    FarPoint.Win.Spread.SheetView s_view = ((FarPoint.Win.Spread.FpSpread)obj).ActiveSheet;

                    if (i_start_column_index < 0)
                        i_start_column_index = 0;
                    if (i_end_column_index < 0)
                        i_end_column_index = s_view.ColumnCount - 1;
                    if (i_end_column_index > s_view.ColumnCount - 1)
                        i_end_column_index = s_view.ColumnCount - 1;

                    for (j = 0; j < s_view.ColumnHeader.RowCount; j++)
                    {
                        s_view.RowCount++;

                        for (i = 0; i < s_view.ColumnCount; i++)
                        {
                            s_view.Cells[s_view.RowCount - 1, i].Value = s_view.ColumnHeader.Cells[j, i].Text;
                            s_view.Cells[s_view.RowCount - 1, i].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                        }
                    }

                    for (i = i_start_column_index; i <= i_end_column_index; i++)
                    {
                        if (i_word_wrap_col > -1)
                        {
                            if (i_word_wrap_col == i)
                            {
                                s_view.Columns[i].CellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
                            }
                        }

                        try
                        {
                            float colHeaderWidth = s_view.ColumnHeader.Columns[i].GetPreferredWidth() + 5;
                            colWidth = s_view.Columns[i].GetPreferredWidth() + 5;

                            if (colHeaderWidth > colWidth)
                            {
                                colWidth = colHeaderWidth;
                            }

                            if (s_view.Columns[i].AllowAutoSort == true && s_view.Columns[i].ShowSortIndicator == true)
                            {
                                colWidth += 20;
                            }
                        }
                        catch (Exception)
                        {
                            colWidth = s_view.ColumnHeader.Columns[i].Width;
                        }

                        if (colWidth > MPGC.SP_MAX_COLUMN_WIDTH)
                        {
                            colWidth = MPGC.SP_MAX_COLUMN_WIDTH;
                        }
                        else if (colWidth < MPGC.SP_MIN_COLUMN_WIDTH)
                        {
                            colWidth = MPGC.SP_MIN_COLUMN_WIDTH;
                        }

                        if (b_skip_fixed_size_header == true)
                        {
                            if (s_view.Columns[i].Resizable == false)
                            {
                                colWidth = s_view.Columns[i].Width;
                            }
                        }

                        s_view.ColumnHeader.Columns[i].Width = colWidth;

                        if (i_word_wrap_col > -1)
                        {
                            if (i_word_wrap_col == i)
                            {
                                if (i_word_wrap_max_size > -1)
                                {
                                    if (colWidth > i_word_wrap_max_size)
                                    {
                                        s_view.ColumnHeader.Columns[i].Width = i_word_wrap_max_size;
                                        FarPoint.Win.Spread.CellType.TextCellType cText = new FarPoint.Win.Spread.CellType.TextCellType();
                                        cText.WordWrap = true;
                                        s_view.Columns[i].CellType = cText;
                                    }
                                }
                            }
                        }
                    }


                    if (i_word_wrap_col > -1)
                    {
                        int rowSpanCnt = 0;
                        int rowHeight = 0;

                        for (i = 0; i < s_view.RowCount; i++)
                        {
                            rowSpanCnt = s_view.Cells[i, i_word_wrap_col].RowSpan;

                            if (rowSpanCnt > 1 || s_view.Columns[i_word_wrap_col].MergePolicy == FarPoint.Win.Spread.Model.MergePolicy.None)
                            {
                                if (s_view.Rows[i].Height * s_view.Cells[i, i_word_wrap_col].RowSpan < s_view.GetPreferredRowHeight(i))
                                {
                                    rowHeight = MPCF.ToInt(s_view.GetPreferredRowHeight(i) / s_view.Cells[i, i_word_wrap_col].RowSpan);
                                    for (j = i; j < i + s_view.Cells[i, i_word_wrap_col].RowSpan; j++)
                                    {
                                        s_view.Rows[j].Height = rowHeight;
                                    }
                                }
                                i += (s_view.Cells[i, i_word_wrap_col].RowSpan - 1);
                            }
                        }
                    }

                    s_view.RowCount -= s_view.ColumnHeader.RowCount;
                }
                else if (obj is ListView)
                {
                    ListView lis = (ListView)obj;
                    Graphics g = lis.CreateGraphics();
                    ArrayList maxColWidthArray = new ArrayList();
                    ListViewItem item = null;
                    int itemWidth;
                    bool b_add_empty_row;

                    b_add_empty_row = false;

                    if (i_start_column_index < 0)
                        i_start_column_index = 0;
                    if (i_end_column_index < 0)
                        i_end_column_index = lis.Columns.Count - 1;
                    if (i_end_column_index > lis.Columns.Count - 1)
                        i_end_column_index = lis.Columns.Count - 1;

                    if (lis.Columns.Count < 1)
                    {
                        lis.Columns.Add("", 0, HorizontalAlignment.Left);
                    }

                    if (lis.Items.Count < 1)
                    {
                        string[] sSpace = new string[lis.Columns.Count];
                        for (i = 0; i < lis.Columns.Count; i++)
                        {
                            sSpace.SetValue("", i);
                        }
                        lis.Items.Add(new ListViewItem(sSpace));
                        b_add_empty_row = true;
                    }

                    if (i_end_column_index - i_start_column_index == 0)
                    {
                        maxColWidthArray.Add(MPGC.LV_MIN_COLUMN_WIDTH * 2);
                    }
                    else
                    {
                        for (i = i_start_column_index; i <= i_end_column_index; i++)
                        {
                            maxColWidthArray.Add(MPGC.LV_MIN_COLUMN_WIDTH);
                        }
                    }

                    //============================================================
                    // ListView 의 칼럼 사이즈 계산
                    //============================================================
                    for (i = 0; i < lis.Items.Count; i++)
                    {
                        item = lis.Items[i];
                        for (j = i_start_column_index; j <= i_end_column_index; j++)
                        {
                            if (j >= item.SubItems.Count)
                            {
                                break;
                            }

                            itemWidth = System.Convert.ToInt32(g.MeasureString(item.SubItems[j].Text, lis.Font).Width) + MPGC.LV_BONUS_COLUMN_WIDTH;
                            if (j == 0)
                            {
                                if (item.ImageIndex >= 0)
                                {
                                    if (lis.SmallImageList != null)
                                        itemWidth += lis.SmallImageList.ImageSize.Width + MPGC.LV_BONUS_COLUMN_WIDTH_WITH_IMAGE;
                                    else
                                        itemWidth += MPGC.LV_BONUS_COLUMN_WIDTH_WITH_IMAGE;
                                }
                                else
                                    itemWidth += MPGC.LV_BONUS_COLUMN_WIDTH_WITH_IMAGE;
                            }
                            colWidth = itemWidth;
                            if (colWidth > (int)maxColWidthArray[j])
                            {
                                if (colWidth > MPGC.LV_MAX_COLUMN_WIDTH)
                                {
                                    maxColWidthArray[j] = MPGC.LV_MAX_COLUMN_WIDTH;
                                }
                                else
                                {
                                    maxColWidthArray[j] = (int)colWidth;
                                }
                            }
                        }
                    }

                    //=================================
                    // ListView 의 칼럼 크기를 지정
                    //=================================
                    for (i = i_start_column_index; i <= i_end_column_index; i++)
                    {
                        colWidth = (int)maxColWidthArray[i] + 5;

                        /* 2013.06.12. Aiden. Column의 Width = 0 이고 Text 가 없는 경우 의도적으로 Column 을 화면에 표시하지 않는 것으로 판단하여 Width를 0으로 지정 */
                        if (b_skip_fixed_size_header == true)
                        {
                            if (lis.Columns[i].Width == 0 && lis.Columns[i].Text == "")
                            {
                                colWidth = 0;
                            }
                        }

                        lis.Columns[i].Width = (int)colWidth;
                    }

                    if (b_add_empty_row == true)
                    {
                        lis.Items[lis.Items.Count - 1].Remove();
                    }


                    /* 2010.05.17.Aiden. 아래 코드로 변경하려 했으나 속도 면에서 위 코드가 빠름. */
                    //ListView lis = (ListView)obj;

                    //if (i_start_column_index < 0)
                    //    i_start_column_index = 0;
                    //if (i_end_column_index < 0)
                    //    i_end_column_index = lis.Columns.Count - 1;
                    //if (i_end_column_index > lis.Columns.Count - 1)
                    //    i_end_column_index = lis.Columns.Count - 1;

                    //if (lis.Columns.Count < 1)
                    //{
                    //    return;
                    //}

                    //if (i_start_column_index == 0 && i_end_column_index == lis.Columns.Count - 1)
                    //{
                    //    lis.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    //}
                    //else
                    //{
                    //    for (i = i_start_column_index; i <= i_end_column_index; i++)
                    //    {
                    //        lis.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.HeaderSize);
                    //    }
                    //}
                    
                }
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex.Message);
            }
        }

        /// <summary>
        /// Lot History 스프레드 시트의 컬럼 헤더의 사이즈를 기본 사이즈로 변경한다.
        /// </summary>
        /// <param name="obj">변경할 Lot History 스프레드 시트 변수 명</param>
        public static void FitLotHistoryDefaultColumnHeader(object obj)
        {
            FitLotHistoryDefaultColumnHeader(obj, 0);
        }
        /// <summary>
        /// Lot History 스프레드 시트의 컬럼 헤더의 사이즈를 기본 사이즈로 변경한다.
        /// </summary>
        /// <param name="obj">변경할 Lot History 스프레드 시트 변수 명</param>
        /// <param name="fAdjustSize">추가할 사이즈</param>
        public static void FitLotHistoryDefaultColumnHeader(object obj, float fAdjustSize)
        {
            try
            {
                if (obj is FarPoint.Win.Spread.FpSpread)
                {
                    FarPoint.Win.Spread.SheetView s_view = ((FarPoint.Win.Spread.FpSpread)obj).ActiveSheet;

                    s_view.Columns[(int)HISTORY_COLUMN.HIST_SEQ].Width = 45 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_CODE].Width = 70 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_TIME].Width = 140 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.FACTORY].Width = 60 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.MAT_ID].Width = 100 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.MAT_VER].Width = 50 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.FLOW].Width = 70 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.FLOW_SEQ_NUM].Width = 55 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.OPER].Width = 60 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.QTY_1].Width = 50 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.QTY_2].Width = 50 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.QTY_3].Width = 50 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.CARRIER].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_TYPE].Width = 55 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.OWNER_CODE].Width = 70 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.CREATE_CODE].Width = 70 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.CREATE_TIME].Width = 120 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_PRIORITY].Width = 60 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_STATUS].Width = 70 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_DEL_TIME].Width = 120 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.HOLD_FLAG].Width = 55 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.HOLD_CODE].Width = 70 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.HOLD_PRV_GRPI_ID].Width = 90 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.OPER_IN_QTY_1].Width = 75 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.OPER_IN_QTY_2].Width = 75 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.OPER_IN_QTY_3].Width = 75 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.CREATE_QTY_1].Width = 70 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.CREATE_QTY_2].Width = 70 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.CREATE_QTY_3].Width = 70 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.START_QTY_1].Width = 60 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.START_QTY_2].Width = 60 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.START_QTY_3].Width = 60 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.INV_FLAG].Width = 85 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRANSIT_FLAG].Width = 75 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.UNIT_EXIT_FLAG].Width = 85 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.INV_UNIT].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.RWK_FLAG].Width = 70 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.RWK_CODE].Width = 75 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.RWK_COUNT].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.RWK_RET_FLOW].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.RWK_RET_FLOW_SEQ].Width = 135 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.RWK_RET_OPER].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.RWK_END_FLOW].Width = 95 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.RWK_END_FLOW_SEQ].Width = 120 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.RWK_END_OPER].Width = 100 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.RWK_RET_CLEAR_FLAG].Width = 140 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.RWK_TIME].Width = 120 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.NSTD_FLAG].Width = 65 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.NSTD_RET_FLOW].Width = 105 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.NSTD_RET_FLOW_SEQ].Width = 125 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.NSTD_RET_OPER].Width = 105 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.NSTD_TIME].Width = 120 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.REPAIR_FLAG].Width = 65 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.REPAIR_RET_OPER].Width = 105 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.START_FLAG].Width = 55 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.START_TIME].Width = 120 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.START_RESOURCE].Width = 100 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.END_FLAG].Width = 55 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.END_TIME].Width = 120 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.END_RESOURCE].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.SAMPLE_FLAG].Width = 70 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.SAMPLE_WAIT_FLAG].Width = 120 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.SAMPLE_RESULT].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.FROM_TO_FLAG].Width = 75 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.FROM_TO_LOT_ID].Width = 85 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.FROM_TO_MAT_ID].Width = 100 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.FROM_TO_MAT_VER].Width = 115 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.FROM_TO_FLOW].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.FROM_TO_FLOW_SEQ].Width = 100 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.FROM_TO_OPER].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.FROM_TO_QTY_1].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.FROM_TO_QTY_2].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.FROM_TO_QTY_3].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.FROM_TO_HIST_SEQ].Width = 95 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.SHIP_CODE].Width = 70 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.SHIP_TIME].Width = 120 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.ORG_DUE_TIME].Width = 120 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.SCH_DUE_TIME].Width = 120 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.FAC_IN_TIME].Width = 120 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.FLOW_IN_TIME].Width = 120 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.OPER_IN_TIME].Width = 120 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.RESERVER_RESOURCE].Width = 100 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.BATCH_ID].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.BATCH_SEQ].Width = 60 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.ORDER_ID].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.ADD_ORDER_ID_1].Width = 85 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.ADD_ORDER_ID_2].Width = 85 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.ADD_ORDER_ID_3].Width = 85 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_LOCATION].Width = 75 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_CMF_1].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_CMF_2].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_CMF_3].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_CMF_4].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_CMF_5].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_CMF_6].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_CMF_7].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_CMF_8].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_CMF_9].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_CMF_10].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_CMF_11].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_CMF_12].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_CMF_13].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_CMF_14].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_CMF_15].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_CMF_16].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_CMF_17].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_CMF_18].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_CMF_19].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_CMF_20].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_DEL_FLAG].Width = 85 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_DEL_CODE].Width = 90 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.BOM_SET_ID].Width = 70 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.BOM_SET_VER].Width = 100 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.BOM_ACTIVE_HIST_SEQ].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.BOM_HIST_SEQ].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.CRITICAL_RESOURCE].Width = 95 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.CRITICAL_RESOURCE_GROUP].Width = 130 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.SAVE_RESOURCE_1].Width = 95 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.SAVE_RESOURCE_2].Width = 95 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.SUB_RESOURCE].Width = 95 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_GROUP_ID_1].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_GROUP_ID_2].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LOT_GROUP_ID_3].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.RESV_FIELD_1].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.RESV_FIELD_2].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.RESV_FIELD_3].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.RESV_FIELD_4].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.RESV_FIELD_5].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.RESV_FLAG_1].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.RESV_FLAG_2].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.RESV_FLAG_3].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.RESV_FLAG_4].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.RESV_FLAG_5].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.OLD_FACTORY].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.OLD_MAT_ID].Width = 100 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.OLD_MAT_VER].Width = 90 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.OLD_FLOW].Width = 70 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.OLD_FLOW_SEQ].Width = 75 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.OLD_OPER].Width = 60 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.OLD_QTY_1].Width = 55 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.OLD_QTY_2].Width = 55 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.OLD_QTY_3].Width = 55 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.OLD_HIST_SEQ].Width = 70 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.OLD_LOT_TYPE].Width = 75 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.OLD_OWNER_CODE].Width = 90 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.OLD_CREATE_CODE].Width = 95 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.OLD_FACTORY_IN_TIME].Width = 120 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.OLD_FLOW_IN_TIME].Width = 120 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.OLD_OPER_IN_TIME].Width = 120 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_CMF_1].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_CMF_2].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_CMF_3].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_CMF_4].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_CMF_5].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_CMF_6].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_CMF_7].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_CMF_8].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_CMF_9].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_CMF_10].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_CMF_11].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_CMF_12].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_CMF_13].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_CMF_14].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_CMF_15].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_CMF_16].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_CMF_17].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_CMF_18].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_CMF_19].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_CMF_20].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_USER_ID].Width = 100 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.TRAN_COMMENT].Width = 150 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.PREV_ACTIVE_HIST_SEQ].Width = 110 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.MULTI_TR_KEY].Width = 70 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.HIST_START_SEQ].Width = 70 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.HIST_DEL_FLAG].Width = 90 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.HIST_DEL_TIME].Width = 120 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.HIST_DEL_USER_ID].Width = 105 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.HIST_DELETE_COMMENT].Width = 150 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LAST_ACTIVE_HIST_SEQ].Width = 120 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LAST_HIST_SEQ].Width = 80 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LAST_TRAN_CODE].Width = 90 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LAST_TRAN_TIME].Width = 120 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LAST_COMMENT].Width = 150 + fAdjustSize;
                    s_view.Columns[(int)HISTORY_COLUMN.LAST_SYS_TRAN_TIME].Width = 120 + fAdjustSize;
                }
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex.Message);
            }
        }

        //
        // SetEnumList()
        //       - Enum to List
        // Return Value
        //       -
        // Arguments
        //       - ByVal cboTarget As ComboBox   :  Combo Box
        //       - ByVal enumType As Type        :  Type
        //
        public static void SetEnumList(ListView cdvTarget, Type enumType)
        {

            try
            {
                string sEnumString = "";
                foreach (string tempLoopVar_sEnumString in @Enum.GetNames(enumType))
                {
                    sEnumString = tempLoopVar_sEnumString;
                    cdvTarget.Items.Add(sEnumString, (int)SMALLICON_INDEX.IDX_KEY);
                }

            }
            catch (Exception ex)
            {
                ShowMsgBox(ex.Message);
            }

        }

        // GetTextboxStyle()
        //       - Set TextBox Style
        // Return Value
        //       -
        // Arguments
        //       - ByRef colControl As System.Windows.Forms.Control.ControlCollection
        //
        public static bool SetTextboxStyle(System.Windows.Forms.Control.ControlCollection colControl)
        {

            try
            {
                Control l_Control;

                l_Control = null;

                foreach (Control tempLoopVar_l_Control in colControl)
                {
                    l_Control = tempLoopVar_l_Control;
                    if (l_Control is Panel)
                    {
                        SetTextboxStyle(l_Control.Controls);
                    }
                    else if (l_Control is System.Windows.Forms.GroupBox)
                    {
                        SetTextboxStyle(l_Control.Controls);
                    }
                    else if (l_Control is TabControl)
                    {
                        SetTextboxStyle(l_Control.Controls);
                    }
                    else if (l_Control is System.Windows.Forms.TextBox)
                    {
                        if (MPGV.gsStyleName == "FLAT")
                        {
                            ((System.Windows.Forms.TextBox)l_Control).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        }
                        else
                        {
                            ((System.Windows.Forms.TextBox)l_Control).BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                        }
                    }
                    else if (l_Control is UltraTextEditor)
                    {
                        if (MPGV.gsStyleName == "FLAT")
                        {
                            ((UltraTextEditor)l_Control).UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                        }
                        else
                        {
                            ((UltraTextEditor)l_Control).UseFlatMode = Infragistics.Win.DefaultableBoolean.False;
                        }
                    }
                    else if (l_Control is UltraNumericEditor)
                    {
                        if (MPGV.gsStyleName == "FLAT")
                        {
                            ((UltraNumericEditor)l_Control).UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                        }
                        else
                        {
                            ((UltraNumericEditor)l_Control).UseFlatMode = Infragistics.Win.DefaultableBoolean.False;
                        }
                    }
                    else if (l_Control is MCCodeView)
                    {
                        if (MPGV.gsStyleName == "FLAT")
                        {
                            ((MCCodeView)l_Control).StyleBorder = System.Windows.Forms.BorderStyle.FixedSingle;
                        }
                        else
                        {
                            ((MCCodeView)l_Control).StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
                        }
                    }
                    else if (l_Control is UltraCheckEditor)
                    {
                        if (MPGV.gsStyleName == "FLAT")
                        {
                            ((UltraCheckEditor)l_Control).UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                        }
                        else
                        {
                            ((UltraCheckEditor)l_Control).UseFlatMode = Infragistics.Win.DefaultableBoolean.False;
                        }
                    }
                    else if (l_Control is UltraComboEditor)
                    {
                        if (MPGV.gsStyleName == "FLAT")
                        {
                            ((UltraComboEditor)l_Control).UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                        }
                        else
                        {
                            ((UltraComboEditor)l_Control).UseFlatMode = Infragistics.Win.DefaultableBoolean.False;
                        }
                    }
                    else if (l_Control is UltraColorPicker)
                    {
                        if (MPGV.gsStyleName == "FLAT")
                        {
                            ((UltraColorPicker)l_Control).UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                        }
                        else
                        {
                            ((UltraColorPicker)l_Control).UseFlatMode = Infragistics.Win.DefaultableBoolean.False;
                        }
                    }
                    else if (l_Control is FarPoint.Win.Spread.FpSpread)
                    {
                        if (MPGV.gsStyleName == "FLAT")
                        {
                            ((FarPoint.Win.Spread.FpSpread)l_Control).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        }
                        else
                        {
                            ((FarPoint.Win.Spread.FpSpread)l_Control).BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                        }
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                ShowMsgBox("MPCF.SetTextboxStyle()\n" + ex.Message);
                return false;
            }

        }

        // FromDate()
        //       -   Change 14 byte DateTime format of DateTimePicker
        // Return Value
        //       - String : 14 byte DateTime
        // Arguments
        //       - ByVal dtpTime As DateTimePicker
        //
        public static string FromDate(DateTimePicker dtpTime)
        {

            string sDateTime = "";
            DateTime DTime;

            try
            {
                DTime = dtpTime.Value;


                if (MPGV.gShiftInfor.bVariableShift == false)
                {
                    if (MPGV.gShiftInfor.cShift1DayFlag == 'P')
                    {
                        DTime = DTime.AddDays(-1);
                    }
                }

                sDateTime = MPCF.ToStandardTime(DTime, MPGC.MP_CONVERT_DATE_FORMAT);
                sDateTime = sDateTime + MPGV.gShiftInfor.sShift1StartTime;

                return sDateTime;

            }
            catch (Exception ex)
            {
                ShowMsgBox("MPCF.FromDate()\n" + ex.Message);
                return "";
            }

        }
  
        // ChangeFromDateFormat()
        //       -   Change 14 byte DateTime format of UltraCalendarCombo
        // Return Value
        //       - String : 14 byte DateTime
        // Arguments
        //       - ByVal dtpTime As DateTimePicker
        //
        public static string DateFromString(UltraCalendarCombo dtpTime)
        {

            try
            {
                return MPCF.ToStandardTime(((DateTime)dtpTime.Value), MPGC.MP_CONVERT_DATETIME_FORMAT);
            }
            catch (Exception ex)
            {
                ShowMsgBox("MPCF.DateFromString()\n" + ex.Message);
                return "";
            }

        }
        // FromDateobject()
        //       - Change 14 byte DateTime format of object
        // Return Value
        //       - String : 14 byte DateTime
        // Arguments
        //       - ByVal objtime As object
        //
        public static string FromDate(object objtime)
        {

            string sDateTime = "";
            DateTime DTime;

            try
            {
                DTime = (DateTime)objtime;


                if (MPGV.gShiftInfor.bVariableShift == false)
                {
                    if (MPGV.gShiftInfor.cShift1DayFlag == 'P')
                    {
                        DTime = DTime.AddDays(-1);
                    }
                }

                sDateTime = MPCF.ToStandardTime(DTime, MPGC.MP_CONVERT_DATE_FORMAT);
                sDateTime = sDateTime + MPGV.gShiftInfor.sShift1StartTime;

                return sDateTime;

            }
            catch (Exception ex)
            {
                ShowMsgBox("MPCF.FromDate()\n" + ex.Message);
                return "";
            }

        }

        // GetSpreadCol()
        //       - Get Spread Column by Column Header
        // Return Value
        //       - Integer : Row Number
        // Arguments
        //       -
        //
        public static int GetSpreadCol(FarPoint.Win.Spread.FpSpread spdData, string sHeader, int iRow)
        {

            try
            {
                int i;
                if (spdData.ActiveSheet.ColumnHeader.RowCount - 1 < iRow)
                {
                    return -1;
                }

                sHeader = MPCF.Trim(sHeader);
                for (i = 0; i < spdData.ActiveSheet.ColumnHeader.Columns.Count; i++)
                {
                    if (MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[iRow, i].Text) == sHeader)
                    {
                        return i;
                    }
                }

                return -1;

            }
            catch (Exception ex)
            {
                ShowMsgBox("MPCF.GetSpreadCol()\n" + ex.Message);
                return -1;
            }

        }

        // SelectClear()
        //       - Clear Selected Items
        // Return Value
        //       -
        // Arguments
        //       - ByVal list As ListView : ListView
        //
        public static void SelectClear(ListView list)
        {

            try
            {
                int i;
                for (i = 0; i < list.Items.Count; i++)
                {
                    list.Items[i].Selected = false;
                }

            }
            catch (Exception ex)
            {
                ShowMsgBox("MPCF.SelectClear()\n" + ex.Message);
            }

        }


        // FieldEnalbeStatus()
        //       - Change Field Enabled Property
        // Return Value
        //       - Boolean : True / False
        // Arguments
        //       - ByRef f As Object   : object
        //       - ByVal bVisable As Boolean : Field Visible False/True
        //       - Optional ByVal ExceptCtl1 As Object = Nothing : Except Control
        //       - Optional ByVal ExceptCtl2 As Object = Nothing : Except Control
        //       - Optional ByVal ExceptCtl3 As Object = Nothing : Except Control
        //       - Optional ByVal ExceptCtl4 As Object = Nothing : Except Control
        //       - Optional ByVal ExceptCtl5 As Object = Nothing : Except Control
        //       - Optional ByVal bItemsClear As Boolean = False : clear Item Flag
        //
        public static bool FieldEnableStatus(object ctrl, bool bEnabled, object ExceptCtl1, object ExceptCtl2, object ExceptCtl3, object ExceptCtl4, object ExceptCtl5)
        {

            try
            {

                object l_Control;
                int i;
                bool bExceptFlag;

                l_Control = null;

                System.Windows.Forms.Control f = (System.Windows.Forms.Control)ctrl;

                for (i = 0; i < f.Controls.Count; i++)
                {
                    bExceptFlag = false;

                    l_Control = f.Controls[i];

                    if (l_Control is Panel || l_Control is System.Windows.Forms.GroupBox || l_Control is TabControl || l_Control is TabPage)
                    {
                        FieldEnableStatus(l_Control, bEnabled, ExceptCtl1, ExceptCtl2, ExceptCtl3, ExceptCtl4, ExceptCtl5);
                    }
                    else
                    {
                        if (ExceptCtl1 != null)
                        {
                            if (ExceptCtl1 == l_Control)
                            {
                                bExceptFlag = true;
                            }
                            else
                            {
                                bExceptFlag = false;
                            }
                        }
                        if (bExceptFlag == false && ExceptCtl2 != null)
                        {
                            if (ExceptCtl2 == l_Control)
                            {
                                bExceptFlag = true;
                            }
                            else
                            {
                                bExceptFlag = false;
                            }
                        }
                        if (bExceptFlag == false && ExceptCtl3 != null)
                        {
                            if (ExceptCtl3 == l_Control)
                            {
                                bExceptFlag = true;
                            }
                            else
                            {
                                bExceptFlag = false;
                            }
                        }

                        if (bExceptFlag == false && ExceptCtl4 != null)
                        {
                            if (ExceptCtl4 == l_Control)
                            {
                                bExceptFlag = true;
                            }
                            else
                            {
                                bExceptFlag = false;
                            }
                        }

                        if (bExceptFlag == false && ExceptCtl5 != null)
                        {
                            if (ExceptCtl5 == l_Control)
                            {
                                bExceptFlag = true;
                            }
                            else
                            {
                                bExceptFlag = false;
                            }
                        }

                        if (bExceptFlag == false)
                        {
                            if (l_Control is UltraTextEditor)
                            {
                                ((UltraTextEditor)l_Control).ReadOnly = !bEnabled;
                            }
                            else if (l_Control is UltraNumericEditor)
                            {
                                ((UltraNumericEditor)l_Control).ReadOnly = !bEnabled;
                            }
                            else if (l_Control is System.Windows.Forms.TextBox)
                            {
                                ((System.Windows.Forms.TextBox)l_Control).ReadOnly = !bEnabled;
                            }
                            else if (l_Control is MCCodeView)
                            {
                                ((MCCodeView)l_Control).Enabled = bEnabled;
                            }
                            else if (l_Control is UltraCheckEditor)
                            {
                                ((UltraCheckEditor)l_Control).Enabled = bEnabled;
                            }
                            else if (l_Control is System.Windows.Forms.CheckBox)
                            {
                                ((System.Windows.Forms.CheckBox)l_Control).Enabled = bEnabled;
                            }
                            else if (l_Control is ComboBox)
                            {
                                ((ComboBox)l_Control).Enabled = bEnabled;
                            }
                            else if (l_Control is UltraComboEditor)
                            {
                                ((UltraComboEditor)l_Control).Enabled = bEnabled;
                            }

                        }
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                ShowMsgBox("MPCF.FieldReadOnlyStatus()\n" + ex.Message);
                return false;
            }

        }

        public static string GetGraphType(eGraphType eType, bool bAddChart)
        {

            string sGraphType = "";

            try
            {
                switch (eType)
                {
                    case eGraphType.XBARR:

                        sGraphType = "Xbar-R";
                        break;
                    case eGraphType.XBARS:

                        sGraphType = "Xbar-S";
                        break;
                    case eGraphType.XRS:

                        sGraphType = "XRS";
                        break;
                    case eGraphType.P:

                        sGraphType = "P";
                        break;
                    case eGraphType.PN:

                        sGraphType = "Pn";
                        break;
                    case eGraphType.C:

                        sGraphType = "C";
                        break;
                    case eGraphType.U:

                        sGraphType = "U";
                        break;
                    case eGraphType.ZBARS:

                        sGraphType = "Zbar-S";
                        break;
                    case eGraphType.DELTAS:

                        sGraphType = "Delta-S";
                        break;
                }

            }
            catch (Exception ex)
            {
                ShowMsgBox("modGlobalEnum.GetGraphType()\n" + ex.Message);
            }

            if (sGraphType != "" && bAddChart == true)
            {
                sGraphType += " Chart";
            }

            return sGraphType;

        }

        // SetPrecision()
        //       - Set data by graph type
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sValue As String
        //       - ByVal iPrecision As Integer
        //
        public static string SetPrecision(string sValue, int iPrecision)
        {

            try
            {
                string sFormat = "0.";
                int i = 0;

                if (MPCF.Trim(sValue) == "")
                {
                    return "";
                }

                if (MPCF.CheckNumeric(sValue) != true)
                {
                    return "";
                }

                for (i = 1; i <= iPrecision; i++)
                {
                    sFormat += "0";
                }
                sValue = MPCF.ToDbl(sValue).ToString(sFormat);

                return sValue;

            }
            catch (Exception ex)
            {
                ShowMsgBox("MPCF.SetPrecision()\n" + ex.Message);
                return "";
            }

        }



        // SelectText()
        //       - Select Text of the TextBox
        // Return Value
        //       -
        // Arguments
        //       - ByVal myText As TextBox                     : TextBox
        //       - Optional ByVal Focus_Flag As Boolean = True : Focus ?щ?
        //
        public static void SelectText(UltraTextEditor myText, bool Focus_Flag)
        {

            try
            {
                myText.SelectionStart = 0;
                myText.SelectionLength = myText.Text.Length;
                if (Focus_Flag == true)
                {
                    myText.Focus();
                }

            }
            catch (Exception ex)
            {
                ShowMsgBox("MPCF.SelectText()\n" + ex.Message);
            }

        }

        public static string GetErrorMsgParse(int iMsgID, string sValue)
        {

            string sMsg = "";

            try
            {
                sMsg = "CMN";
                sMsg += iMsgID.ToString("000");
                sMsg += " ERROR - ";
                sMsg += sValue;

            }
            catch (Exception ex)
            {
                ShowMsgBox("MPCF.GetErrorMsgParse()\n" + ex.Message);
            }

            return sMsg;

        }

        // SetRuleDescription()
        //       -  Set Rule Description
        // Return Value
        //       -  String :
        // Arguments
        //       - ByVal sRuleType As String
        //
        public static string SetRuleDescription(char sRuleType)
        {

            try
            {
                string sDesc = "";

#if _PROJECT
                
                switch (sRuleType)
                {
                    case "A":
                        
                        sDesc = "Out of Spec (OOS)";
                        break;
                    case "B":
                        
                        sDesc = "1 point beyond 3 sigma (OOC)";
                        break;
                    case "C":
                        
                        sDesc = "7 consecutive points above the CL";
                        break;
                    case "D":
                        
                        sDesc = "7 consecutive points below the CL";
                        break;
                    case "E":
                        
                        sDesc = "7 consecutive points increasing";
                        break;
                    case "F":
                        
                        sDesc = "7 consecutive points decreasing";
                        break;
                    case "G":
                        
                        sDesc = "Range of fluctuation beyond 4 sigma";
                        break;
                    case "H":
                        
                        sDesc = "Range of fluctuation beyond 3 sigma";
                        break;
                    default:
                        
                        sDesc = "";
                        break;
                }
                
#else

                switch (sRuleType)
                {
                    case 'A':

                        sDesc = "Out of Spec (OOS)";
                        break;

                    case 'B':

                        sDesc = "1 point beyond 3 sigma (OOC)";
                        break;

                    case 'C':

                        sDesc = "8 consecutive points same side of average";
                        break;

                    case 'D':

                        sDesc = "14 consecutive points increasing or decreasing";
                        break;

                    case 'E':

                        sDesc = "2 out of 3 consecutive points beyond 2 sigma";
                        break;

                    case 'F':

                        sDesc = "4 out of 5 consecutive points beyond 1 sigma";
                        break;

                    case 'G':

                        sDesc = "15 consecutive points between plus 1 sigma and minus 1 sigma";
                        break;

                    case 'H':

                        sDesc = "8 consecutive points beyond plus 1 sigma and minus 1 sigma";
                        break;

                    case 'S':

                        sDesc = "Out of Spec. Limit (OOS)";
                        break;

                    case 'W':

                        sDesc = "Out of Warning Limit (OOW)";
                        break;

                    default:

                        sDesc = "";
                        break;

                }
#endif
                return sDesc;

            }
            catch (Exception ex)
            {
                ShowMsgBox("MPCF.SetRuleDescription()\n" + ex.Message);
                return "";
            }

        }

        // SetRuleDescription()
        //       -  Set Rule Description
        // Return Value
        //       -  String :
        // Arguments
        //       - ByVal sRuleType As String
        //
        public static string SetRuleDescription(char sRuleType, TRSNode out_node)
        {
            return SetRuleDescription(sRuleType, out_node, ' ');
        }
        public static string SetRuleDescription(char sRuleType, TRSNode out_node, char cXRFlag)
        {

            try
            {
                string sDesc = "";

#if _PROJECT
                
                switch (sRuleType)
                {
                    case "A":
                        
                        sDesc = "Out of Spec (OOS)";
                        break;
                    case "B":
                        
                        sDesc = "1 point beyond 3 sigma (OOC)";
                        break;
                    case "C":
                        
                        sDesc = "7 consecutive points above the CL";
                        break;
                    case "D":
                        
                        sDesc = "7 consecutive points below the CL";
                        break;
                    case "E":
                        
                        sDesc = "7 consecutive points increasing";
                        break;
                    case "F":
                        
                        sDesc = "7 consecutive points decreasing";
                        break;
                    case "G":
                        
                        sDesc = "Range of fluctuation beyond 4 sigma";
                        break;
                    case "H":
                        
                        sDesc = "Range of fluctuation beyond 3 sigma";
                        break;
                    default:
                        
                        sDesc = "";
                        break;
                }
                
#else

                switch (sRuleType)
                {
                    case 'A':
                        if (MPGV.gcLanguage == '1')
                        {
                            sDesc = "Out of Spec (OOS)";
                        }
                        if (MPGV.gcLanguage == '2')
                        {
                            sDesc = "규격한계를 벗어난 경우";
                        }
                        if (MPGV.gcLanguage == '3')
                        {
                            sDesc = "超出Spec";
                        }

                        break;

                    case 'B':
                        if (MPGV.gcLanguage == '1')
                        {
                            sDesc = "1 point beyond 3 sigma (OOC)";
                        }
                        if (MPGV.gcLanguage == '2')
                        {
                            sDesc = "점이 관리한계를 벗어난 경우(OOC)";
                        }
                        if (MPGV.gcLanguage == '3')
                        {
                            sDesc = "1点超过3 Sigma (OOC)";
                        }
                        
                        break;

                    /* Updated By YJJung 160218 For The extended rule description */
                    case 'C':
                        if (MPGV.gcLanguage == '1')
                        {
                            
                            if (cXRFlag == 'X')
                            {
                                sDesc = out_node.GetString("XRULE_3") + " consecutive points same side of average";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = out_node.GetString("RRULE_3") + " consecutive points same side of average";
                            }                            
                            else
                            {
                                sDesc = "8 consecutive points same side of average";
                            }
                        }
                        if (MPGV.gcLanguage == '2')
                        {
                            
                            if (cXRFlag == 'X')
                            {
                                sDesc = "중심선(CL)을 기준으로 위, 혹은 아래로 " + out_node.GetString("XRULE_3") + " 점 이상이 연속적으로 존재하는 경우";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = "중심선(CL)을 기준으로 위, 혹은 아래로 " + out_node.GetString("RRULE_3") + " 점 이상이 연속적으로 존재하는 경우";
                            }                            
                            else
                            {
                                //sDesc = "중심선(CL)을 기준으로 위, 혹은 아래로 8 점 이상이 연속적으로 존재하는 경우";
                                sDesc = "8 consecutive points same side of average";
                            }
                        }
                        if (MPGV.gcLanguage == '3')
                        {
                            if (cXRFlag == 'X')
                            {
                                sDesc = "连续 " + out_node.GetString("XRULE_3") + " 点在平均线一边";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = "连续 " + out_node.GetString("RRULE_3") + " 点在平均线一边";
                            }                            
                            else
                            {
                                sDesc = "8 consecutive points same side of average";
                                //sDesc = "连续 8 点在平均线一边";
                            }
                        }
                        
                        break;

                    case 'D':
                         if (MPGV.gcLanguage == '1')
                        {
                            
                            if (cXRFlag == 'X')
                            {
                                sDesc = out_node.GetString("XRULE_4") + " consecutive points increasing or decreasing";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = out_node.GetString("RRULE_4") + " consecutive points increasing or decreasing";
                            }                            
                            else
                            {
                                sDesc = "14 consecutive points increasing or decreasing";
                            }
                        }
                        if (MPGV.gcLanguage == '2')
                        {
                           
                            if (cXRFlag == 'X')
                            {
                                sDesc = out_node.GetString("XRULE_4") + " 점 이상 연속적으로 상승하거나 하강하는 경우";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = out_node.GetString("RRULE_4") + " 점 이상 연속적으로 상승하거나 하강하는 경우";
                            }                            
                            else
                            {
                                //sDesc = "14 점 이상 연속적으로 상승하거나 하강하는 경우";
                                sDesc = "14 consecutive points increasing or decreasing";
                            }
                        }
                        if (MPGV.gcLanguage == '3')
                        {
                            
                            if (cXRFlag == 'X')
                            {
                                sDesc = "连续 " + out_node.GetString("XRULE_4") + " 点升高或下降";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = "连续 " + out_node.GetString("RRULE_4") + " 点升高或下降";
                            }                            
                            else
                            {
                                // sDesc = "连续 14 点升高或下降";
                                sDesc = "14 consecutive points increasing or decreasing";
                            }
                        }
                        
                        break;

                    case 'E':
                        if (MPGV.gcLanguage == '1')
                        {
                            
                            if (cXRFlag == 'X')
                            {
                                String[] s_temp_xrule5 = out_node.GetString("XRULE_5").Split('@');
                                if (s_temp_xrule5.Length == 1 && s_temp_xrule5[0] != "")
                                {
                                    sDesc = "Among " + s_temp_xrule5[0] + ", 2 consecutive points beyond 2 sigma";
                                }
                                else if (s_temp_xrule5.Length == 2 && s_temp_xrule5[0] != "" && s_temp_xrule5[1] != "")
                                {
                                    sDesc = "Among " + s_temp_xrule5[0] + ", " + s_temp_xrule5[1] + " consecutive points beyond 2 sigma";
                                }
                            }
                            else if (cXRFlag == 'R')
                            {
                                String[] s_temp_rrule5 = out_node.GetString("RRULE_5").Split('@');
                                if (s_temp_rrule5.Length == 1 && s_temp_rrule5[0] != "")
                                {
                                    sDesc = "Among " + s_temp_rrule5[0] + ", 2 consecutive points beyond 2 sigma";
                                }
                                else if (s_temp_rrule5.Length == 2 && s_temp_rrule5[0] != "" && s_temp_rrule5[1] != "")
                                {
                                    sDesc = "Among " + s_temp_rrule5[0] + ", " + s_temp_rrule5[1] + " consecutive points beyond 2 sigma";
                                }
                            }                           
                            else
                            {
                                sDesc = "Among 3, 2 consecutive points beyond 2 sigma";
                            }
                        }
                        if (MPGV.gcLanguage == '2')
                        {
                           
                            if (cXRFlag == 'X')
                            {
                                String[] s_temp_xrule5 = out_node.GetString("XRULE_5").Split('@');
                                if (s_temp_xrule5.Length == 1 && s_temp_xrule5[0] != "")
                                {
                                    sDesc = s_temp_xrule5[0] + " 점 중, 2 점이 2시그마 이상 벗어난 경우";
                                }
                                else if (s_temp_xrule5.Length == 2 && s_temp_xrule5[0] != "" && s_temp_xrule5[1] != "")
                                {
                                    sDesc = s_temp_xrule5[0] + " 점 중, " + s_temp_xrule5[1] + " 점이 2시그마 이상 벗어난 경우";
                                }
                            }
                            else if (cXRFlag == 'R')
                            {
                                String[] s_temp_rrule5 = out_node.GetString("RRULE_5").Split('@');
                                if (s_temp_rrule5.Length == 1 && s_temp_rrule5[0] != "")
                                {
                                    sDesc = s_temp_rrule5[0] + " 점 중, 2 점이 2시그마 이상 벗어난 경우";
                                }
                                else if (s_temp_rrule5.Length == 2 && s_temp_rrule5[0] != "" && s_temp_rrule5[1] != "")
                                {
                                    sDesc = s_temp_rrule5[0] + " 점 중, " + s_temp_rrule5[1] + " 점이 2시그마 이상 벗어난 경우";
                                }
                            }                           
                            else
                            {
                                //sDesc = "3 점 중, 2 점이 2시그마 이상 벗어난 경우";
                                sDesc = "Among 3, 2 consecutive points beyond 2 sigma";
                            }
                        }
                        if (MPGV.gcLanguage == '3')
                        {
                           
                            if (cXRFlag == 'X')
                            {
                                String[] s_temp_xrule5 = out_node.GetString("XRULE_5").Split('@');
                                if (s_temp_xrule5.Length == 1 && s_temp_xrule5[0] != "")
                                {
                                    sDesc = "连续 " + s_temp_xrule5[0] + " 点中的 2 点超过 2 sigma";
                                }
                                else if (s_temp_xrule5.Length == 2 && s_temp_xrule5[0] != "" && s_temp_xrule5[1] != "")
                                {
                                    sDesc = "连续 " + s_temp_xrule5[0] + " 点中的 " + s_temp_xrule5[1] + " 点超过 2 sigma";
                                }
                            }
                            else if (cXRFlag == 'R')
                            {
                                String[] s_temp_rrule5 = out_node.GetString("RRULE_5").Split('@');
                                if (s_temp_rrule5.Length == 1 && s_temp_rrule5[0] != "")
                                {
                                    sDesc = "连续 " + s_temp_rrule5[0] + " 点中的 2 点超过 2 sigma";
                                }
                                else if (s_temp_rrule5.Length == 2 && s_temp_rrule5[0] != "" && s_temp_rrule5[1] != "")
                                {
                                    sDesc = "连续 " + s_temp_rrule5[0] + " 点中的 " + s_temp_rrule5[1] + " 点超过 2 sigma";
                                }
                            }    
                            else
                            {
                                //sDesc = "连续 3 点中的 2 点超过 2 sigma";
                                sDesc = "Among 3, 2 consecutive points beyond 2 sigma";
                            }
                        }

                        break;
                    case 'F':
                        if (MPGV.gcLanguage == '1')
                        {

                            if (cXRFlag == 'X')
                            {
                                String[] s_temp_xrule6 = out_node.GetString("XRULE_6").Split('@');
                                if (s_temp_xrule6.Length == 1 && s_temp_xrule6[0] != "")
                                {
                                    sDesc = "Among " + s_temp_xrule6[0] + ", 4 consecutive points beyond 1 sigma";
                                }
                                else if (s_temp_xrule6.Length == 2 && s_temp_xrule6[0] != "" && s_temp_xrule6[1] != "")
                                {
                                    sDesc = "Among " + s_temp_xrule6[0] + ", " + s_temp_xrule6[1] + " consecutive points beyond 1 sigma";
                                }
                            }
                            else if (cXRFlag == 'R')
                            {
                                String[] s_temp_rrule6 = out_node.GetString("RRULE_6").Split('@');
                                if (s_temp_rrule6.Length == 1 && s_temp_rrule6[0] != "")
                                {
                                    sDesc = "Among " + s_temp_rrule6[0] + ", 4 consecutive points beyond 1 sigma";
                                }
                                else if (s_temp_rrule6.Length == 2 && s_temp_rrule6[0] != "" && s_temp_rrule6[1] != "")
                                {
                                    sDesc = "Among " + s_temp_rrule6[0] + ", " + s_temp_rrule6[1] + " consecutive points beyond 1 sigma";
                                }
                            }
                            else
                            {
                                sDesc = "Among 5, 4 consecutive points beyond 1 sigma";
                            }
                        }
                        if (MPGV.gcLanguage == '2')
                        {

                            if (cXRFlag == 'X')
                            {
                                String[] s_temp_xrule6 = out_node.GetString("XRULE_6").Split('@');
                                if (s_temp_xrule6.Length == 1 && s_temp_xrule6[0] != "")
                                {
                                    sDesc = s_temp_xrule6[0] + " 점 중, 4 점이 1시그마 이상 벗어난 경우";
                                }
                                else if (s_temp_xrule6.Length == 2 && s_temp_xrule6[0] != "" && s_temp_xrule6[1] != "")
                                {
                                    sDesc = s_temp_xrule6[0] + " 점 중, " + s_temp_xrule6[1] + " 점이 1시그마 이상 벗어난 경우";
                                }
                            }
                            else if (cXRFlag == 'R')
                            {
                                String[] s_temp_rrule6 = out_node.GetString("RRULE_6").Split('@');
                                if (s_temp_rrule6.Length == 1 && s_temp_rrule6[0] != "")
                                {
                                    sDesc = s_temp_rrule6[0] + " 점 중, 4 점이 1시그마 이상 벗어난 경우";
                                }
                                else if (s_temp_rrule6.Length == 2 && s_temp_rrule6[0] != "" && s_temp_rrule6[1] != "")
                                {
                                    sDesc = s_temp_rrule6[0] + " 점 중, " + s_temp_rrule6[1] + " 점이 1시그마 이상 벗어난 경우";
                                }
                            }
                            else
                            {
                                //sDesc = "5 점 중, 4 점이 4시그마 이상 벗어난 경우";
                                sDesc = "Among 5, 4 consecutive points beyond 1 sigma";
                            }
                        }
                        if (MPGV.gcLanguage == '3')
                        {

                            if (cXRFlag == 'X')
                            {
                                String[] s_temp_xrule6 = out_node.GetString("XRULE_6").Split('@');
                                if (s_temp_xrule6.Length == 1 && s_temp_xrule6[0] != "")
                                {
                                    sDesc = "连续 " + s_temp_xrule6[0] + " 点中的 4 点超过 1 sigma";
                                }
                                else if (s_temp_xrule6.Length == 2 && s_temp_xrule6[0] != "" && s_temp_xrule6[1] != "")
                                {
                                    sDesc = "连续 " + s_temp_xrule6[0] + " 点中的 " + s_temp_xrule6[1] + " 点超过 1 sigma";
                                }
                            }
                            else if (cXRFlag == 'R')
                            {
                                String[] s_temp_rrule6 = out_node.GetString("RRULE_6").Split('@');
                                if (s_temp_rrule6.Length == 1 && s_temp_rrule6[0] != "")
                                {
                                    sDesc = "连续 " + s_temp_rrule6[0] + " 点中的 4 点超过 1 sigma";
                                }
                                else if (s_temp_rrule6.Length == 2 && s_temp_rrule6[0] != "" && s_temp_rrule6[1] != "")
                                {
                                    sDesc = "连续 " + s_temp_rrule6[0] + " 点中的 " + s_temp_rrule6[1] + " 点超过 1 sigma";
                                }
                            }
                            else
                            {
                                //sDesc = "连续 5 点中的 4 点超过 1 sigma";
                                sDesc = "Among 5, 4 consecutive points beyond 1 sigma";
                            }
                        }
                        
                        
                        break;

                    case 'G':

                            //sDesc = "4 out of 5 consecutive points beyond 1 sigma";
                        if (MPGV.gcLanguage == '1')
                        {
                           
                            if (cXRFlag == 'X')
                            {
                                sDesc = out_node.GetString("XRULE_7") + " consecutive points between plus 1 sigma and minus 1 sigma";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = out_node.GetString("RRULE_7") + " consecutive points between plus 1 sigma and minus 1 sigma";
                            }                            
                            else
                            {
                                sDesc = "15 consecutive points between plus 1 sigma and minus 1 sigma";
                            }
                        }
                        if (MPGV.gcLanguage == '2')
                        {
                            
                            if (cXRFlag == 'X')
                            {
                                sDesc = out_node.GetString("XRULE_7") + " 점 이상이 1시그마 안에 존재하는 경우";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = out_node.GetString("RRULE_7") + " 점 이상이 1시그마 안에 존재하는 경우";
                            }                            
                            else
                            {
                                //sDesc = "15 점 이상이 1시그마 안에 존재하는 경우";
                                sDesc = "15 consecutive points between plus 1 sigma and minus 1 sigma";
                            }
                        }
                        if (MPGV.gcLanguage == '3')
                        {
                            
                            if (cXRFlag == 'X')
                            {
                                sDesc = "连续 " + out_node.GetString("XRULE_7") + " 点在－1 与1 sigma之间";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = "连续 " + out_node.GetString("RRULE_7") + " 点在－1 与1 sigma之间";
                            }                            
                            else
                            {
                                //sDesc = "连续 15 点在－1 与1 sigma之间";
                                sDesc = "15 consecutive points between plus 1 sigma and minus 1 sigma";
                            }
                        }
                       
                        break;

                    case 'H':
                        if (MPGV.gcLanguage == '1')
                        {
                           
                            if (cXRFlag == 'X')
                            {
                                sDesc = out_node.GetString("XRULE_8") + " consecutive points beyond plus 1 sigma and minus 1 sigma";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = out_node.GetString("RRULE_8") + " consecutive points beyond plus 1 sigma and minus 1 sigma";
                            }                      
                            else
                            {
                                sDesc = "8 consecutive points beyond plus 1 sigma and minus 1 sigma";
                            }
                        }
                        if (MPGV.gcLanguage == '2')
                        {
                            
                            if (cXRFlag == 'X')
                            {
                                sDesc = out_node.GetString("XRULE_8") + " 점 이상이 1시그마 밖에 존재하는 경우";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = out_node.GetString("RRULE_8") + " 점 이상이 1시그마 밖에 존재하는 경우";
                            }                           
                            else
                            {
                                //sDesc = "8 점 이상이 1시그마 밖에 존재하는 경우";
                                sDesc = "8 consecutive points beyond plus 1 sigma and minus 1 sigma";
                            }
                        }
                        if (MPGV.gcLanguage == '3')
                        {
                            if (cXRFlag == 'X')
                            {
                                sDesc = "连续 " + out_node.GetString("XRULE_8") + " 点超过1 sigma或－1 sigma";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = "连续 " + out_node.GetString("RRULE_8") + " 点超过1 sigma或－1 sigma";
                            }                            
                            else
                            {
                                //sDesc = "连续 8 点超过1 sigma或－1 sigma";
                                sDesc = "8 consecutive points beyond plus 1 sigma and minus 1 sigma";
                            }
                        }
                        
                       
                        break;

                    case 'I':
                        if (MPGV.gcLanguage == '1')
                        {
                            
                            if (cXRFlag == 'X')
                            {
                                sDesc = out_node.GetString("XRULE_9") + " consecutive points above the CL";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = out_node.GetString("RRULE_9") + " consecutive points above the CL";
                            }
                            else
                            {
                                sDesc = "7 consecutive points above the CL";
                            }
                        }
                        if (MPGV.gcLanguage == '2')
                        {
                            
                            if (cXRFlag == 'X')
                            {
                                sDesc = "중심선(CL)을 기준으로 위로 연속 " + out_node.GetString("XRULE_9") + " 점 이상인 경우";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = "중심선(CL)을 기준으로 위로 연속 " + out_node.GetString("RRULE_9") + " 점 이상인 경우";
                            }
                            else
                            {
                                //sDesc = "중심선(CL)을 기준으로 위로 연속 7 점 이상인 경우";
                                sDesc = "7 consecutive points above the CL";
                            }
                        }
                        if (MPGV.gcLanguage == '3')
                        {
                            
                            if (cXRFlag == 'X')
                            {
                                sDesc = "连续 " + out_node.GetString("XRULE_9") + " 点在CL之上";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = "连续 " + out_node.GetString("RRULE_9") + " 点在CL之上";
                            }
                            else
                            {
                                //sDesc = "连续 7 点在CL之上";
                                sDesc = "7 consecutive points above the CL";
                            }
                            
                        }
                        
                       
                        break;

                    case 'J':
                        if (MPGV.gcLanguage == '1')
                        {
                            
                            if (cXRFlag == 'X')
                            {
                                sDesc = out_node.GetString("XRULE_10") + " consecutive points below the CL";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = out_node.GetString("RRULE_10") + " consecutive points below the CL";
                            }
                            else
                            {
                                sDesc = "7 consecutive points below the CL";
                            }

                        }
                        if (MPGV.gcLanguage == '2')
                        {
                            if (cXRFlag == 'X')
                            {
                                sDesc = "중심선(CL)을 기준으로 아래로 연속 " + out_node.GetString("XRULE_10") + " 점 이상인 경우";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = "중심선(CL)을 기준으로 아래로 연속 " + out_node.GetString("RRULE_10") + " 점 이상인 경우";
                            }
                            else
                            {
                                //sDesc = "중심선(CL)을 기준으로 아래로 연속 7 점 이상인 경우";
                                sDesc = "7 consecutive points below the CL";
                            }
                        }
                        if (MPGV.gcLanguage == '3')
                        {
                            if (cXRFlag == 'X')
                            {
                                sDesc = "连续 " + out_node.GetString("XRULE_10") + " 点在CL之下";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = "连续 " + out_node.GetString("RRULE_10") + " 点在CL之下";
                            }
                            else
                            {
                                //sDesc = "连续 7 点在CL之下";
                                sDesc = "7 consecutive points below the CL";
                            }
                        }
                        
                        
                        break;

                    case 'K':
                        if (MPGV.gcLanguage == '1')
                        {
                            if (cXRFlag == 'X')
                            {
                                sDesc = out_node.GetString("XRULE_11") + " consecutive points increasing";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = out_node.GetString("RRULE_11") + " consecutive points increasing";
                            }
                            else
                            {
                                sDesc = "7 consecutive points increasing";
                            }
                        }
                        if (MPGV.gcLanguage == '2')
                        {
                            if (cXRFlag == 'X')
                            {
                                sDesc = out_node.GetString("XRULE_11") + " 점 이상 연속적으로 상승하는 경우";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = out_node.GetString("RRULE_11") + " 점 이상 연속적으로 상승하는 경우";
                            }
                            else
                            {
                                //sDesc = "7 점 이상 연속적으로 상승하는 경우";
                                sDesc = "7 consecutive points increasing";
                            }
                        }
                        if (MPGV.gcLanguage == '3')
                        {
                            if (cXRFlag == 'X')
                            {
                                sDesc = "连续 " + out_node.GetString("XRULE_11") + " 点升高";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = "连续 " + out_node.GetString("RRULE_11") + " 点升高";
                            }
                            else
                            {
                                //sDesc = "连续 7 点升高";
                                sDesc = "7 consecutive points increasing";
                            }
                        }
                        
                        
                        break;

                    case 'L':
                        if (MPGV.gcLanguage == '1')
                        {
                            if (cXRFlag == 'X')
                            {
                                sDesc = out_node.GetString("XRULE_12") + " consecutive points decreasing";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = out_node.GetString("RRULE_12") + " consecutive points decreasing";
                            }
                            else
                            {
                                sDesc = "7 consecutive points decreasing";
                            }
                        }
                        if (MPGV.gcLanguage == '2')
                        {
                            if (cXRFlag == 'X')
                            {
                                sDesc = out_node.GetString("XRULE_12") + " 점 이상 연속적으로 하강하는 경우";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = out_node.GetString("RRULE_12") + " 점 이상 연속적으로 하강하는 경우";
                            }
                            else
                            {
                                //sDesc = "7 점 이상 연속적으로 하강하는 경우";
                                sDesc = "7 consecutive points decreasing";
                            }
                        }
                        if (MPGV.gcLanguage == '3')
                        {
                            if (cXRFlag == 'X')
                            {
                                sDesc = "连续 " + out_node.GetString("XRULE_12") + " 点下降";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = "连续 " + out_node.GetString("RRULE_12") + " 点下降";
                            }
                            else
                            {
                                //sDesc = "连续 7 点下降";
                                sDesc = "7 consecutive points decreasing";
                            }
                        }
                        
                        
                        break;

                    case 'M':
                        if (MPGV.gcLanguage == '1')
                        {
                            if (cXRFlag == 'X')
                            {
                                sDesc = "Range of fluctuation beyond " + out_node.GetString("XRULE_13") + " sigma";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = "Range of fluctuation beyond " + out_node.GetString("RRULE_13") + " sigma";
                            }
                            else
                            {
                                sDesc = "Range of fluctuation beyond 3 sigma";
                            }
                        }
                        if (MPGV.gcLanguage == '2')
                        {
                            if (cXRFlag == 'X')
                            {
                                sDesc = "변동폭이 " + out_node.GetString("XRULE_13") + " sigma 이상인 경우";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = "변동폭이 " + out_node.GetString("RRULE_13") + " sigma 이상인 경우";
                            }
                            else
                            {
                                //sDesc = "변동폭이 3 sigma 이상인 경우";
                                sDesc = "Range of fluctuation beyond 3 sigma";
                            }
                        }
                        if (MPGV.gcLanguage == '3')
                        {
                            if (cXRFlag == 'X')
                            {
                                sDesc = "波动范围超过 " + out_node.GetString("XRULE_13") + " sigma";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = "波动范围超过 " + out_node.GetString("RRULE_13") + " sigma";
                            }
                            else
                            {
                                //sDesc = "波动范围超过 3 sigma";
                                sDesc = "Range of fluctuation beyond 3 sigma";
                            }
                        }
                        break;

                    case 'N':
                        if (MPGV.gcLanguage == '1')
                        {
                            if (cXRFlag == 'X')
                            {
                                sDesc = out_node.GetString("XRULE_14") + " consecutive points between plus one sigma and minus one sigma or beyond";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = out_node.GetString("RRULE_14") + " consecutive points between plus one sigma and minus one sigma or beyond";
                            }
                            else
                            {
                                sDesc = "9 consecutive points between plus one sigma and minus one sigma or beyond";
                            }
                        }
                        if (MPGV.gcLanguage == '2')
                        {
                            if (cXRFlag == 'X')
                            {
                                sDesc = out_node.GetString("XRULE_14") + " 점 이상이 1시그마 안, 혹은 밖에 존재하는 경우";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = out_node.GetString("RRULE_14") + " 점 이상이 1시그마 안, 혹은 밖에 존재하는 경우";
                            }
                            else
                            {
                                //sDesc = "9 점 이상이 1시그마 안, 혹은 밖에 존재하는 경우";
                                sDesc = "9 consecutive points between plus one sigma and minus one sigma or beyond";
                            }
                        }
                        if (MPGV.gcLanguage == '3')
                        {
                            if (cXRFlag == 'X')
                            {
                                sDesc = "连续 " + out_node.GetString("XRULE_14") + " 点在－1与1 sigma之间或之外";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = "连续 " + out_node.GetString("RRULE_14") + " 点在－1与1 sigma之间或之外";
                            }
                            else
                            {
                                //sDesc = "连续 9 点在－1与1 sigma之间或之外";
                                sDesc = "9 consecutive points between plus one sigma and minus one sigma or beyond";
                            }
                        }
                        
                        
                        break;

                    case 'O':
                        if (MPGV.gcLanguage == '1')
                        {
                            if (cXRFlag == 'X')
                            {
                                sDesc = out_node.GetString("XRULE_15") + " consecutive points alternating up and down";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = out_node.GetString("RRULE_15") + " consecutive points alternating up and down";
                            }
                            else
                            {
                                sDesc = "14 consecutive points alternating up and down";
                            }
                        }
                        if (MPGV.gcLanguage == '2')
                        {
                            if (cXRFlag == 'X')
                            {
                                sDesc = out_node.GetString("XRULE_15") + " 점 이상이 계속 위아래로 변화하는 경우";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = out_node.GetString("RRULE_15") + " 점 이상이 계속 위아래로 변화하는 경우";
                            }
                            else
                            {
                                //sDesc = "14 점 이상이 계속 위아래로 변화하는 경우";
                                sDesc = "14 consecutive points alternating up and down";
                            }
                        }
                        if (MPGV.gcLanguage == '3')
                        {
                            if (cXRFlag == 'X')
                            {
                                sDesc = "连续 " + out_node.GetString("XRULE_15") + " 点上下交替";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = "连续 " + out_node.GetString("RRULE_15") + " 点上下交替";
                            }
                            else
                            {
                                //sDesc = "连续 14 点上下交替";
                                sDesc = "14 consecutive points alternating up and down";
                            }
                        }
                        
                        
                        break;

                    case 'P':
                        if (MPGV.gcLanguage == '1')
                        {
                            if (cXRFlag == 'X')
                            {
                                sDesc = out_node.GetString("XRULE_16") + " consecutive points beyond 3 sigma";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = out_node.GetString("RRULE_16") + " consecutive points beyond 3 sigma";
                            }
                            else
                            {
                                sDesc = "2 consecutive points beyond 3 sigma";
                            }
                        }
                        if (MPGV.gcLanguage == '2')
                        {
                            if (cXRFlag == 'X')
                            {
                                sDesc = out_node.GetString("XRULE_16") + " 점 이상이 3 Sigma를 벗어나는 경우";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = out_node.GetString("RRULE_16") + " 점 이상이 3 Sigma를 벗어나는 경우";
                            }
                            else
                            {
                                //sDesc = "2 점 이상이 3 Sigma를 벗어나는 경우";
                                sDesc = "2 consecutive points beyond 3 sigma";
                            }
                        }
                        if (MPGV.gcLanguage == '3')
                        {
                            if (cXRFlag == 'X')
                            {
                                sDesc = "连续 " + out_node.GetString("XRULE_16") + " 点超过3 sigma";
                            }
                            else if (cXRFlag == 'R')
                            {
                                sDesc = "连续 " + out_node.GetString("RRULE_16") + " 点超过3 sigma";
                            }
                            else
                            {
                                //sDesc = "连续 2 点超过 3 sigma";
                                sDesc = "2 consecutive points beyond 3 sigma";
                            }
                        }
                        
                        break;

                    case 'Q':
                        if (MPGV.gcLanguage == '1')
                        {
                            if (cXRFlag == 'X')
                            {
                                String[] s_temp_xrule16 = out_node.GetString("XRULE_17").Split('@');
                                if (s_temp_xrule16.Length == 1 && s_temp_xrule16[0] != "")
                                {
                                    sDesc = "Among " + s_temp_xrule16[0] + ", 16 consecutive points on one side of the CL";
                                }
                                else if (s_temp_xrule16.Length == 2 && s_temp_xrule16[0] != "" && s_temp_xrule16[1] != "")
                                {
                                    sDesc = "Among " + s_temp_xrule16[0] + ", " + s_temp_xrule16[1] + " consecutive points on one side of the CL";
                                }
                            }
                            else if (cXRFlag == 'R')
                            {
                                String[] s_temp_rrule16 = out_node.GetString("RRULE_17").Split('@');
                                if (s_temp_rrule16.Length == 1 && s_temp_rrule16[0] != "")
                                {
                                    sDesc = "Among " + s_temp_rrule16[0] + ", 16 consecutive points on one side of the CL";
                                }
                                else if (s_temp_rrule16.Length == 2 && s_temp_rrule16[0] != "" && s_temp_rrule16[1] != "")
                                {
                                    sDesc = "Among " + s_temp_rrule16[0] + ", " + s_temp_rrule16[1] + " consecutive points on one side of the CL";
                                }
                            }
                            else
                            {
                                sDesc = "Among 20, 16 consecutive points on one side of the CL";
                            }
                        }
                        if (MPGV.gcLanguage == '2')
                        {
                            if (cXRFlag == 'X')
                            {
                                String[] s_temp_xrule16 = out_node.GetString("XRULE_17").Split('@');
                                if (s_temp_xrule16.Length == 1 && s_temp_xrule16[0] != "")
                                {
                                    sDesc = s_temp_xrule16[0] + " 점 중, 16점이 중심선 기준으로 위, 혹은 아래에 몰려 있는 경우";
                                }
                                else if (s_temp_xrule16.Length == 2 && s_temp_xrule16[0] != "" && s_temp_xrule16[1] != "")
                                {
                                    sDesc = s_temp_xrule16[0] + " 점 중, " + s_temp_xrule16[1] + " 점이 중심선 기준으로 위, 혹은 아래에 몰려 있는 경우";
                                }
                            }
                            else if (cXRFlag == 'R')
                            {
                                String[] s_temp_rrule16 = out_node.GetString("RRULE_17").Split('@');
                                if (s_temp_rrule16.Length == 1 && s_temp_rrule16[0] != "")
                                {
                                    sDesc = s_temp_rrule16[0] + " 점 중, 16점이 중심선 기준으로 위, 혹은 아래에 몰려 있는 경우";
                                }
                                else if (s_temp_rrule16.Length == 2 && s_temp_rrule16[0] != "" && s_temp_rrule16[1] != "")
                                {
                                    sDesc = s_temp_rrule16[0] + " 점 중, " + s_temp_rrule16[1] + " 점이 중심선 기준으로 위, 혹은 아래에 몰려 있는 경우";
                                }
                            }
                            else
                            {
                                //sDesc = "20 점 중, 16점이 중심선 기준으로 위, 혹은 아래에 몰려 있는 경우";
                                sDesc = "Among 20, 16 consecutive points on one side of the CL";
                            }
                        }
                        if (MPGV.gcLanguage == '3')
                        {
                            if (cXRFlag == 'X')
                            {
                                String[] s_temp_xrule16 = out_node.GetString("XRULE_17").Split('@');
                                if (s_temp_xrule16.Length == 1 && s_temp_xrule16[0] != "")
                                {
                                    sDesc = "连续 " + s_temp_xrule16[0] + " 点中的 16 点在CL的一边";
                                }
                                else if (s_temp_xrule16.Length == 2 && s_temp_xrule16[0] != "" && s_temp_xrule16[1] != "")
                                {
                                    sDesc = "连续 " + s_temp_xrule16[0] + " 点中的 " + s_temp_xrule16[1] + " 点在CL的一边";
                                }
                            }
                            else if (cXRFlag == 'R')
                            {
                                String[] s_temp_rrule16 = out_node.GetString("RRULE_17").Split('@');
                                if (s_temp_rrule16.Length == 1 && s_temp_rrule16[0] != "")
                                {
                                    sDesc = "连续 " + s_temp_rrule16[0] + " 点中的 16 点在CL的一边";
                                }
                                else if (s_temp_rrule16.Length == 2 && s_temp_rrule16[0] != "" && s_temp_rrule16[1] != "")
                                {
                                    sDesc = "连续 " + s_temp_rrule16[0] + " 点中的 " + s_temp_rrule16[1] + " 点在CL的一边";
                                }
                            }
                            else
                            {
                                //sDesc = "连续 20 点中的 16 点在CL的一边";
                                sDesc = "Among 20, 16 consecutive points on one side of the CL";
                            }
                        }
                        
                        /* Updated End */
                           
                        break;

                    case 'S':

                        sDesc = "Out of Spec. Limit (OOS)";
                        break;

                    case 'W':

                        sDesc = "Out of Warning Limit (OOW)";
                        break;

                    default:

                        sDesc = "";
                        break;

                }
#endif
                return sDesc;

            }
            catch (Exception ex)
            {
                ShowMsgBox("MPCF.SetRuleDescription()\n" + ex.Message);
                return "";
            }

        }

        /// <summary>
        /// EDC 스펙 정보를 문자열 형태로 변환한다.
        /// </summary>
        /// <param name="sUSL">상위 제한</param>
        /// <param name="sLSL">하위 제한</param>
        /// <param name="sTarget">기준값</param>
        /// <returns>변환된 스펙 정보 문자열</returns>
        public static string GetSpecInfo(string sUSL, string sLSL, string sTarget)
        {

            try
            {
                string sSpec;
                sSpec = " ";
                if (MPCF.Trim(sUSL) == "" && MPCF.Trim(sLSL) == "")
                {
                    if (MPCF.Trim(sTarget) != "")
                    {
                        sSpec += sTarget;
                    }
                }
                else
                {
                    if (MPCF.Trim(sTarget) != "")
                    {
                        if (MPCF.Trim(sUSL) != "" && MPCF.Trim(sLSL) != "")
                        {
                            if (MPCF.CheckNumeric(sTarget) == true && MPCF.CheckNumeric(sUSL) == true && MPCF.CheckNumeric(sLSL) == true)
                            {
                                if (MPCF.ToDbl(sUSL) - MPCF.ToDbl(sTarget) == MPCF.ToDbl(sTarget) - MPCF.ToDbl(sLSL))
                                {
                                    sSpec += MPCF.Trim(sTarget) + " +/- " + ((double)(MPCF.ToDbl(sUSL) - MPCF.ToDbl(sTarget))).ToString("#######,##0.#####");
                                }
                                else
                                {
                                    sSpec += MPCF.Trim(sLSL) + " ~ " + MPCF.Trim(sTarget) + " ~ " + MPCF.Trim(sUSL);
                                }
                            }
                            else
                            {
                                sSpec += MPCF.Trim(sLSL) + " ~ " + MPCF.Trim(sTarget) + " ~ " + MPCF.Trim(sUSL);
                            }
                        }
                        else
                        {
                            if (MPCF.Trim(sUSL) != "")
                            {
                                if (MPCF.CheckNumeric(sUSL) == true)
                                {
                                    sSpec += MPCF.Trim(sTarget) + " + " + ((double)(MPCF.ToDbl(sUSL) - MPCF.ToDbl(sTarget))).ToString("#######,##0.#####");
                                }
                                else
                                {
                                    sSpec += MPCF.Trim(sTarget) + " ~ " + MPCF.Trim(sUSL);
                                }
                            }
                            else if (MPCF.Trim(sLSL) != "")
                            {
                                if (MPCF.CheckNumeric(sLSL) == true)
                                {
                                    sSpec += MPCF.Trim(sTarget) + " - " + ((double)(MPCF.ToDbl(sTarget) - MPCF.ToDbl(sLSL))).ToString("#######,##0.#####");
                                }
                                else
                                {
                                    sSpec += MPCF.Trim(sLSL) + " ~ " + MPCF.Trim(sTarget);
                                }
                            }
                        }
                    }
                    else
                    {
                        sSpec += MPCF.Trim(sLSL) + " ~ " + MPCF.Trim(sUSL);
                    }

                }

                return sSpec;

            }
            catch (Exception ex)
            {
                ShowMsgBox("MPCF.GetSpecInfo()\n" + ex.Message);
                return "";
            }

        }


        public static void ListViewColumnSorter(ListView lis, int i_column, SortOrder iSortOrder, bool VisibleSortIndicator, Miracom.CliFrx.ListViewItemComparer.SORTING_OPTION eSortingOption)
        {
            SortOrder iOrder;

            if (iSortOrder == SortOrder.None)
            {
                ColumnHeader colHeader;

                colHeader = lis.Columns[i_column];
                //if (Strings.Asc(colHeader.Text.Substring(0, 1)) == 30)
                if ((int)(colHeader.Text.Substring(0, 1)[0]) == 30)
                {
                    iOrder = SortOrder.Descending;
                    colHeader.Text = '\u001D' + colHeader.Text.Substring(1);
                }
                else if ((int)(colHeader.Text.Substring(0, 1)[0]) == 29)
                {
                    iOrder = SortOrder.Ascending;
                    colHeader.Text = '\u001E' + colHeader.Text.Substring(1);
                }
                else
                {
                    iOrder = SortOrder.Ascending;
                    colHeader.Text = '\u001E' + colHeader.Text;
                }
            }
            else
            {
                iOrder = iSortOrder;
            }

            if (VisibleSortIndicator == true)
            {
                ShowListViewColumnHeaderIcon(lis, i_column, (iOrder == SortOrder.Ascending ? true : false));
            }

            lis.ListViewItemSorter = new ListViewItemComparer(i_column, iOrder, eSortingOption);
            lis.Sort();
        }

        // <<Check>>사용하지 않는것으로 보임
        private static void ShowListViewColumnHeaderIcon(ListView lis, int col, bool m_bSortOrder)
        {
            IntPtr hdrHeader;
            IntPtr hdrResult;
            int i;
            frmMiscellaneousControl ff = new frmMiscellaneousControl();

            hdrHeader = MPGC.SendMessage(lis.Handle, MPGC.LVM_GETHEADER, 0, 0);
            hdrResult = MPGC.SendMessage(hdrHeader, MPGC.HDM_SETIMAGELIST, 0, MPCF.ToInt(ff.imlUpDown.Handle));

            for (i = 0; i < lis.Columns.Count; i++)
            {
                MPGC.LVCOLUMN lv = new MPGC.LVCOLUMN();

                lv.mask = MPGC.HDI_FORMAT | MPGC.HDI_IMAGE;
                if (i == col)
                {
                    lv.fmt = MPGC.HDF_IMAGE | MPGC.HDF_LEFT | MPGC.HDF_BITMAP_ON_RIGHT;
                    lv.iImage = m_bSortOrder ? 0 : 1;
                }
                else
                {
                    lv.fmt = 0;
                }

                lv.cchTextMax = 0;
                lv.cx = 0;
                lv.iOrder = 0;
                lv.iSubItem = 0;
                lv.pszText = IntPtr.Zero;
                hdrResult = MPGC.SendMessage(lis.Handle, MPGC.LVM_SETCOLUMN, i, ref lv);
            }

        }

        /// <summary>
        /// 오브젝트 타입의 변수를 자연수형으로 변환한다
        /// </summary>
        /// <param name="obj">변경할 오브젝트 타입의 변수</param>
        /// <returns>변환된 자연수형의 값</returns>
        public static decimal ToDecimal(object obj)
        {
            CultureInfo ci_local = CultureInfo.CurrentCulture;
            CultureInfo ci_inter = new CultureInfo("en-US");
            decimal result;
            object val;

            try
            {
                if (obj == null)
                {
                    return 0;
                }

                if (obj is Char)
                {
                    val = Convert.ToString(obj);
                }
                else
                {
                    val = obj;
                }

                if (CheckNumeric(val) == false)
                {
                    return 0;
                }

                try
                {
                    result = Convert.ToDecimal(val, ci_inter.NumberFormat);
                    if (val.ToString().IndexOf(ci_local.NumberFormat.NumberDecimalSeparator) >= 0)
                    {
                        result = Convert.ToDecimal(val, ci_local.NumberFormat);
                    }
                }
                catch
                {
                    result = Convert.ToDecimal(val, ci_local.NumberFormat);
                }

                return result;
            }
            catch (Exception Ex)
            {
                Debug.Print(Ex.Message + " ToDecimal");
                return 0;
            }
        }

        public static string DateToString(DateTime value)
        {
            string sSep = System.Globalization.DateTimeFormatInfo.CurrentInfo.DateSeparator;
            string sFormat = "";
            DateTime dtTemp = new DateTime(2000, 3, 4);
            string sTemp = dtTemp.ToShortDateString();

            if (sTemp.IndexOf("2") < sTemp.IndexOf("3"))
            {
                if (sTemp.IndexOf("3") < sTemp.IndexOf("4"))
                {
                    // yyyy-MM-dd
                    sFormat = "yyyy" + sSep + "MM" + sSep + "dd";
                }
                else
                {
                    // yyyy-dd-MM
                    sFormat = "yyyy" + sSep + "dd" + sSep + "MM";
                }
            }
            else
            {
                if (sTemp.IndexOf("3") < sTemp.IndexOf("4"))
                {
                    // MM-dd-yyyy
                    sFormat = "MM" + sSep + "dd" + sSep + "yyyy";
                }
                else
                {
                    // dd-MM-yyyy
                    sFormat = "dd" + sSep + "MM" + sSep + "yyyy";
                }
            }

            return value.ToString(sFormat);

        }

        /// <summary>
        /// 문자열이 DateTime형태인지 확인한다.
        /// </summary>
        /// <param name="sDate">확인할 문자열</param>
        /// <returns>true or false</returns>
        public static bool IsDateOk(string sDate)
        {
            try
            {
                DateTime dummy = Convert.ToDateTime(sDate);
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }

        // <<Check>>
        public static Icon LoadIcon(string s_icon_name)
        {

            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Stream strm = myAssembly.GetManifestResourceStream("Miracom.UI." + s_icon_name);

            Icon ic = null;
            if (!(strm == null))
            {
                ic = new System.Drawing.Icon(strm);
                strm.Close();
            }
            return ic;

        }

        // <<Check>>
        /// <summary>
        /// Source Icon과 Target Icon이 동일한 Icon인지 비교한다.
        /// </summary>
        /// <param name="source">Source Icon</param>
        /// <param name="target">Target Icon</param>
        /// <returns>True or False</returns>
        public static bool CompareIcons(Icon source, Icon target)
        {

            try
            {
                if (source == null && target == null)
                {
                    return true;
                }
                else if (source == null && !(target == null))
                {
                    return false;
                }
                else if (!(source == null) && !(target == null))
                {
                    return false;
                }

                if (source.Size.Equals(target.Size) == false)
                {
                    return false;
                }

                Bitmap bA = source.ToBitmap();
                Bitmap bB = target.ToBitmap();

                int x;
                int y;
                for (x = 0; x < bA.Width; x++)
                {
                    for (y = 0; y < bA.Height; y++)
                    {
                        if (bA.GetPixel(x, y).Equals(bB.GetPixel(x, y)) == false)
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;

        }

        // StringTrim()
        //       - Trim Space Data
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - Form
        public static string Trim(object str)
        {
            try
            {
                if (str == null)
                    return "";


                if (str is System.Windows.Forms.Form)
                {
                    System.Windows.Forms.Form f = (System.Windows.Forms.Form)str;

                    MessageBox.Show(f.Name + " Trim을 사용하고 있음. 수정 바람.");

                    if (f.Tag == null)
                    {
                        return "";
                    }
                    else
                    {
                        return f.Tag.ToString().Trim();
                    }
                }
                else
                {
                    string sTemp = Convert.ToString(str);

                    if (string.IsNullOrEmpty(sTemp) == true)
                    {
                        return "";
                    }
                    else
                    {
                        return sTemp.Trim();
                    }
                }
            }
            catch (Exception Ex)
            {
                Debug.Print(Ex.Message + " Trim");
                return "";
            }
        }

        /// <summary>
        /// 문자열의 왼쪽에서부터 공백을 삭제한다.
        /// </summary>
        /// <param name="str">변환할 문자열</param>
        /// <returns>변환된 문자열</returns>
        public static string RTrim(object str)
        {
            try
            {
                if (str == null)
                    return "";

                if (str is System.Windows.Forms.Form)
                {
                    System.Windows.Forms.Form f = (System.Windows.Forms.Form)str;

                    if (f.Tag == null)
                    {
                        return "";
                    }
                    else
                    {
                        return f.Tag.ToString().TrimEnd();
                    }
                }
                else
                {
                    string sTemp = Convert.ToString(str);

                    if (string.IsNullOrEmpty(sTemp) == true)
                    {
                        return "";
                    }
                    else
                    {
                        return sTemp.TrimEnd();
                    }
                }
            }
            catch (Exception Ex)
            {
                Debug.Print(Ex.Message + " RTrim");
                return "";
            }
        }

        // RTrimSpace()
        //       - RTrim 후 결과가 ""이면 공백 한개를 보낸다.
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - string
        // Add by J.S. 2008.12.18
        public static string RTrimSpace(object str)
        {
            try
            {
                if (str == null)
                    return " ";

                if (str is System.Windows.Forms.Form)
                {
                    System.Windows.Forms.Form f = (System.Windows.Forms.Form)str;

                    if (f.Tag == null)
                    {
                        return " ";
                    }
                    else
                    {
                        string sTemp = f.Tag.ToString().TrimEnd();

                        if (string.IsNullOrEmpty(sTemp) == true)
                            return " ";
                        else
                            return sTemp;
                    }
                }
                else
                {
                    string sTemp = Convert.ToString(str).TrimEnd();

                    if (string.IsNullOrEmpty(sTemp) == true)
                    {
                        return " ";
                    }
                    else
                    {
                        return sTemp;
                    }
                }
            }
            catch (Exception Ex)
            {
                Debug.Print(Ex.Message + " RTrimSpace");
                return "";
            }
        }

        /// <summary>
        /// 문자열의 왼쪽에서부터 공백을 삭제한다.
        /// </summary>
        /// <param name="str">변환할 문자열</param>
        /// <returns>변환된 문자열</returns>
        public static string LTrim(object str)
        {
            try
            {
                if (str == null)
                    return "";

                if (str is System.Windows.Forms.Form)
                {
                    System.Windows.Forms.Form f = (System.Windows.Forms.Form)str;

                    if (f.Tag == null)
                    {
                        return "";
                    }
                    else
                    {
                        return f.Tag.ToString().TrimStart();
                    }
                }
                else
                {
                    string sTemp = Convert.ToString(str);

                    if (string.IsNullOrEmpty(sTemp) == true)
                    {
                        return "";
                    }
                    else
                    {
                        return sTemp.TrimStart();
                    }
                }
            }
            catch (Exception Ex)
            {
                Debug.Print(Ex.Message + " LTrim");
                return "";
            }
        }

        /// <summary>
        /// 오브젝트 타입의 변수를 정수형으로 변환한다.
        /// </summary>
        /// <param name="obj">변경할 오브젝트 타입의 변수</param>
        /// <returns>변환된 정수형의 값</returns>
        public static int ToInt(object obj)
        {
            CultureInfo ci_local = CultureInfo.CurrentCulture;
            CultureInfo ci_inter = new CultureInfo("en-US");
            int result;
            object val;
            double d_val;

            try
            {
                if (obj == null)
                {
                    return 0;
                }

                if (obj is Enum)
                {
                    return (int)obj;
                }

                if (obj is Char)
                {
                    val = Convert.ToString(obj);
                }
                else
                {
                    val = obj;
                }

                if (CheckNumeric(val) == false)
                {
                    return 0;
                }

                d_val = ToDbl(val);

                try
                {
                    result = Convert.ToInt32(d_val, ci_inter.NumberFormat);
                    if (d_val.ToString().IndexOf(ci_local.NumberFormat.NumberDecimalSeparator) >= 0)
                    {
                        result = Convert.ToInt32(d_val, ci_local.NumberFormat);
                    }
                }
                catch
                {
                    result = Convert.ToInt32(d_val, ci_local.NumberFormat);
                }

                return result;
            }
            catch (Exception Ex)
            {
                Debug.Print(Ex.Message + " ToInt");
                return 0;
            }
        }

        /// <summary>
        /// 오브젝트 타입의 변수를 부동소수형으로 변환한다.
        /// </summary>
        /// <param name="obj">변경할 오브젝트 타입의 변수</param>
        /// <returns>변환된 부동소수형의 값</returns>
        public static double ToDbl(object obj)
        {
            CultureInfo ci_local = CultureInfo.CurrentCulture;
            CultureInfo ci_inter = new CultureInfo("en-US");
            double result;
            object val;

            try
            {
                if (obj == null)
                {
                    return 0;
                }

                if (obj is Char)
                {
                    val = Convert.ToString(obj);
                }
                else
                {
                    val = obj;
                }

                if (CheckNumeric(val) == false)
                {
                    return 0;
                }

                try
                {
                    result = Convert.ToDouble(val, ci_inter.NumberFormat);
                    if (val.ToString().IndexOf(ci_local.NumberFormat.NumberDecimalSeparator) >= 0)
                    {
                        result = Convert.ToDouble(val, ci_local.NumberFormat);
                    }
                }
                catch
                {
                    result = Convert.ToDouble(val, ci_local.NumberFormat);
                }

                return result;
            }
            catch (Exception Ex)
            {
                Debug.Print(Ex.Message + " ToDbl");
                return 0;
            }
        }

        // CheckNumeric()
        //       - Check Numeric Data
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - string
        public static bool CheckNumeric(object val)
        {
            double result;
            object obj;

            try
            {
                if (val == null) return false;

                if (val is Char)
                {
                    obj = Convert.ToString(val);
                }
                else
                {
                    obj = val;
                }

                result = Convert.ToDouble(obj);
                return true;
            }

            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 문자열 중 일부 문자열을 잘라 반환한다.
        /// </summary>
        /// <param name="str">잘라낼 문자열</param>
        /// <param name="i_start_index">잘라낼 시작 인덱스</param>
        /// <returns>잘라낸 문자열</returns>
        public static string Mid(object str, int i_start_index)
        {
            if (str == null) return "";

            string sTemp = Convert.ToString(str);
            if (sTemp.Length < i_start_index) return "";

            return sTemp.Substring(i_start_index);
        }
        /// <summary>
        /// 문자열 중 일부 문자열을 잘라 반환한다.
        /// </summary>
        /// <param name="str">잘라낼 문자열</param>
        /// <param name="i_start_index">잘라낼 시작 인덱스</param>
        /// <param name="i_length">잘라낼 길이</param>
        /// <returns>잘라낸 문자열</returns>
        public static string Mid(object str, int i_start_index, int i_length)
        {
            if (str == null) return "";

            string sTemp = Convert.ToString(str);
            if (sTemp.Length < i_start_index) return "";
            if (sTemp.Length < (i_start_index + i_length)) return sTemp.Substring(i_start_index);

            return sTemp.Substring(i_start_index, i_length);
        }

        /// <summary>
        /// 문자열의 모든 캐릭터를 대문자로 변경한다
        /// </summary>
        /// <param name="str">변환할 문자열</param>
        /// <returns>변환된 문자열</returns>
        public static string ToUpper(object str)
        {
            if (str == null) str = "";
            string sTmp = (string)str;
            return sTmp.ToUpper();
        }

        /// <summary>
        /// 문자열의 모든 캐릭터를 소문자로 변경한다
        /// </summary>
        /// <param name="str">변환할 문자열</param>
        /// <returns>변환된 문자열</returns>
        public static string ToLower(object str)
        {
            if (str == null) str = "";
            string sTmp = (string)str;
            return sTmp.ToLower();
        }

        public static string Format(string sFormat, object val)
        {
            if (val == null) return "";

            string sReturn = "";

            try
            {
                double dval = Convert.ToDouble(val);

                sReturn = dval.ToString(sFormat);
            }
            catch
            {
                sReturn = val.ToString();
            }

            return sReturn;
        }

        /// <summary>
        /// 변환할 오브젝트 타입의 변수를 캐릭터로 변경한다
        /// </summary>
        /// <param name="obj">변환할 변수 명</param>
        /// <returns>변환된 캐릭터 값</returns>
        public static char ToChar(object obj)
        {
            if (Trim(obj) == "")
            {
                return ' ';
            }
            else
            {
                return Trim(obj)[0];
            }
        }

        /// <summary>
        /// 레지스트리에서 값을 가져온다.
        /// </summary>
        /// <param name="AppName">Application Name</param>
        /// <param name="Section">Section</param>
        /// <param name="Key">Key</param>
        /// <returns>Registry value</returns>
        public static string GetRegSetting(string AppName, string Section, string Key)
        {
            return GetRegSetting(AppName, Section, Key, "");
        }

        /// <summary>
        /// 레지스트리에서 값을 가져온다.
        /// </summary>
        /// <param name="AppName">Application Name</param>
        /// <param name="Section">Section</param>
        /// <param name="Key">Key</param>
        /// <param name="Default">Default value</param>
        /// <returns>Registry value</returns>
        public static string GetRegSetting(string AppName, string Section, string Key, string Default)
        {
            try
            {
                RegistryKey rk = Registry.CurrentUser.CreateSubKey("Software\\VB and VBA Program Settings\\" + AppName + "\\" + Section, RegistryKeyPermissionCheck.ReadWriteSubTree);
                object dpc_value = rk.GetValue(Key);

                if (dpc_value == null)
                {
                    return Default;
                }
                else
                {
                    return MPCF.Trim(dpc_value);
                }
            }
            catch (Exception ex)
            {
                ShowMsgBox("MPCF.GetRegSetting(" + AppName + "\\" + Section + "\\" + Key + ")\n" + ex.Message);
                return "";
            }
        }

        /// <summary>
        /// 레지스트리에 값을 저장한다.
        /// </summary>
        /// <param name="AppName">Application Name</param>
        /// <param name="Section">Section</param>
        /// <param name="Key">Key</param>
        /// <param name="value">Save value</param>
        public static void SaveRegSetting(string AppName, string Section, string Key, object value)
        {
            try
            {
                RegistryKey rk = Registry.CurrentUser.CreateSubKey("Software\\VB and VBA Program Settings\\" + AppName + "\\" + Section, RegistryKeyPermissionCheck.ReadWriteSubTree);
                rk.SetValue(Key, value);
            }
            catch (Exception ex)
            {
                ShowMsgBox("MPCF.SaveRegSetting(" + AppName + "\\" + Section + "\\" + Key + ")\n" + ex.Message);
            }
        }

        /// <summary>
        /// 레지스트리에서 값을 삭제한다
        /// </summary>
        /// <param name="AppName">Application Name</param>
        /// <param name="Section">Section</param>
        /// <param name="Key">Key</param>
        public static void DeleteRegSetting(string AppName, string Section, string Key)
        {
            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\VB and VBA Program Settings\\" + AppName + "\\" + Section, true);
                if (rk != null)
                {
                    rk.DeleteValue(Key, false);
                }
            }
            catch (Exception ex)
            {
                ShowMsgBox("MPCF.DeleteRegSetting(" + AppName + "\\" + Section + "\\" + Key + ")\n" + ex.Message);
            }
        }

        /// <summary>
        /// 문자열에 속한 '.'(마침표)의 개수를 반환한다
        /// </summary>
        /// <param name="strNum">확인할 문자열</param>
        /// <returns>'.'의 개수</returns>
        public static int GetPointCount(string strNum)
        {
            try
            {
                int i, j = 1;
                for (i = strNum.Length; i > 0; i--)
                {
                    if (strNum[i - 1] == '.')
                        break;

                    j = j * 10;
                }

                if (i == 0) j = 1;

                return j;
            }
            catch (Exception ex)
            {
                ShowMsgBox("GetPointCount\n" + ex.Message);
                return 0;
            }
        }

        //
        // CheckFormat()
        //       - Check Prompt Format
        // Return Value
        //       - bool : Return true/false
        // Arguments
        //       - cFmt as char  : Mandatory Format
        //       - cdvValue as Miracom.UI.Controls.MCCodeView.MCCodeView : MCCodeView
        //       - strValue as String : Input Value
        //
        public static bool CheckFormat(char cFmt, Miracom.UI.Controls.MCCodeView.MCCodeView cdvValue)
        {
            if (CheckFormat(cFmt, cdvValue.Text) == false)
            {
                cdvValue.Focus();
                return false;
            }

            return true;
        }

        public static bool CheckFormat(char cFmt, string strValue)
        {
            bool bRet = true;
            switch (cFmt)
            {
                case 'A':
                    break;

                case 'F':
                    if (CheckNumeric(Trim(strValue)) == false)
                    {
                        ShowMsgBox(GetMessage(139));
                        bRet = false;
                    }
                    break;

                case 'N':
                    if (CheckNumeric(Trim(strValue)) == false)
                    {
                        ShowMsgBox(GetMessage(139));
                        bRet = false;
                    }
                    if (Trim(strValue).IndexOf(".") >= 0 || Trim(strValue).IndexOf("-") >= 0)
                    {
                        ShowMsgBox(GetMessage(140));
                        bRet = false;
                    }
                    break;
            }

            return bRet;
        }

        /// <summary>
        /// 문자열이 SQL 신텍스인지 확인한다.
        /// </summary>
        /// <param name="sQuery">확인할 문자열</param>
        /// <returns>true or false</returns>
        public static bool IsSQLSyntax(string sQuery)
        {
            for (int i = 0; i < MPGV.SqlSyntax.Length; i++)
            {
                if (MPCF.Trim(MPGV.SqlSyntax[i]) == MPCF.Trim(sQuery))
                {
                    return true;
                }
            }
            return false;
        }

        public static string GetHostAddress(string sHost)
        {
            //IPAddress ip;
            IPHostEntry hostinfo;
            string sAddress;
            string hostName;

            sAddress = "";

            if (sHost == MPGC.MP_LOCAL_HOST)
            {
                hostName = Dns.GetHostName();
                hostinfo = Dns.GetHostEntry(hostName);
            }
            else
            {
                hostinfo = Dns.GetHostEntry(sHost);
            }

            foreach (IPAddress ip in hostinfo.AddressList)
            {
                sAddress = ip.ToString();
            }

            return sAddress;
        }

        // 확인 필요. 로직상 ci_local이거나 ci_inter를 선택해서 써야하는것 같으나 무조건 "en-US"로 사용하고 있음
        /// <summary>
        /// 오브젝트 타입의 변수를 지역 표기형태에 따른 문자열로 변환한다.
        /// </summary>
        /// <param name="obj">변경할 오브젝트 타입의 변수</param>
        /// <returns>변환된 문자열</returns>
        public static string ToRegionNumber(object obj)
        {
            string result;
            double d_result;
            try
            {
                if (obj == null)
                {
                    return null;
                }

                if (MPCF.CheckNumeric(obj) == true)
                {
                    d_result = Convert.ToDouble(obj);
                    result = d_result.ToString(CultureInfo.CreateSpecificCulture("en-US"));
                }
                else
                {
                    result = Convert.ToString(obj, CultureInfo.CreateSpecificCulture("en-US"));
                    result = result.ToString(CultureInfo.CreateSpecificCulture("en-US"));
                }
                
                return result;
            }
            catch (Exception Ex)
            {
                Debug.Print(Ex.Message + " ToRegionNumber");
                return null;
            }
        }

        public static bool CheckDisit(char cArg)
        {
            try
            {
                if (!(Char.IsDigit(cArg)) && cArg != 8 && cArg != 46)
                {
                    return true;
                }
                return false;
            }
            catch (Exception Ex)
            {
                ShowMsgBox("CheckDisit\n" + Ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Change time format to standard time format
        /// </summary>
        /// <param name="dt_value">Target DateTime Type Value</param>
        /// <param name="sFormatType">Result Convert Type - MP_CONVERT_DATE_FORMAT, MP_CONVERT_TIME_FORMAT or MP_CONVERT_DATETIME_FORMAT.  
        /// Default result string format is 'yyyyMMddHHmmss'. Does not support other format.</param>
        /// <returns></returns>
        public static string ToStandardTime(DateTime dt_value, string sFormatType)
        {

            if (sFormatType == MPGC.MP_CONVERT_DATE_FORMAT)
            {
                return dt_value.Year.ToString("000#") + dt_value.Month.ToString("0#") + dt_value.Day.ToString("0#");
            }
            else if (sFormatType == MPGC.MP_CONVERT_HYPHENDATE_FORMAT)
            {
                return dt_value.Year.ToString("000#") + "-" + dt_value.Month.ToString("0#") + "-" + dt_value.Day.ToString("0#");
            }
            else if (sFormatType == MPGC.MP_CONVERT_SLASHDATE_FORMAT)
            {
                return dt_value.Year.ToString("000#") + "/" + dt_value.Month.ToString("0#") + "/" + dt_value.Day.ToString("0#");
            }
            if (sFormatType == MPGC.MP_CONVERT_NODAYDATE_FORMAT)
            {
                return dt_value.Year.ToString("000#") + dt_value.Month.ToString("0#");
            }
            else if (sFormatType == MPGC.MP_CONVERT_TIME_FORMAT)
            {
                return dt_value.Hour.ToString("0#") + dt_value.Minute.ToString("0#") + dt_value.Second.ToString("0#");
            }
            else if (sFormatType == MPGC.MP_CONVERT_DATETIME_FORMAT)
            {
                return dt_value.Year.ToString("000#") +
                       dt_value.Month.ToString("0#") +
                       dt_value.Day.ToString("0#") +
                       dt_value.Hour.ToString("0#") +
                       dt_value.Minute.ToString("0#") +
                       dt_value.Second.ToString("0#");
            }
            else if (sFormatType == MPGC.MP_CONVERT_YEAR_FORMAT)
            {
                return dt_value.Year.ToString("000#");
            }
            else if (sFormatType == MPGC.MP_CONVERT_MONTH_FORMAT)
            {
                return dt_value.Month.ToString("0#");
            }

            MPCF.ShowMsgBox(MPCF.GetMessage(315));
            return string.Empty;
        }
    }
}
