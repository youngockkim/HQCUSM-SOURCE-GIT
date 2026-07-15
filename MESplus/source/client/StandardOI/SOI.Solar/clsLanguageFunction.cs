//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : modLanguageFunction.vb
//   Description : Collection of Common functions that related with Language'
//   MES Version : 4.1.0.0
//
//   Function List
//       - GetMessage() : Find Message data among the loaded message resource
//       - LoadMessagResource() : Load message resource data
//       - LoadCaptionResource() : Load Text Data
//       - ToClientLanguage() : Change Language of the form' Text to Client Language
//       - ConvertMessage() : Change Language of the form' Control' Text to Client Language
//       - FindLanguage() : Find Client Language of source string
//
//
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-10 : Created by W.Y Choi
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Import

using System;
using System.IO;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;

using FarPoint.Win.Spread;
using Infragistics.Win.UltraWinEditors;
using SOI.CliFrx;
using SOI.OIFrx;
using SOI.OIFrx.SOIControls;

#region Function Setup Output Test
//using Miracom.MESCore;
//using Miracom.TRSCore;
#endregion

namespace SOI.Solar
{
    public class clsLanguageFunction
    {
        
        //
        // ToClientLanuage()
        //       -  Change Language of the form' Text to Client Language
        // Return Value
        //       -  True / False
        // Arguments
        //       -  ByVal l_form As Form :
        //       -
        
        public bool ToClientLanguage(Form l_form)
        {
            
            try
            {
                l_form.Text = FindLanguage(l_form.Text, 2);
                if (ConvertMessage(l_form.Controls) == false)
                {
                    return false;
                }

                #region Function Setup Output Test
                //registeredControl(l_form);
                //AllArrList.Clear();
                //registeredArrList.Clear(); 
                #endregion
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("ToClientLanguage() is Failed.\n" + ex.Message);
                return false;
            }
            
            return true;
            
        }

        // ToClientLanuage()
        //       -  Change Language of the form' Text to Client Language
        // Return Value
        //       -  True / False
        // Arguments
        //       -  ByVal mnuItems As Menu.MenuItemCollection
        //
        public bool ToClientLanguage(Menu.MenuItemCollection mnuItems)
        {

            try
            {
                foreach (MenuItem mnuItem in mnuItems)
                {
                    if (mnuItem.Text != "")
                    {
                        mnuItem.Text = FindLanguage(mnuItem.Text, 2);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("ToClientLanguage() is Failed.\n" + ex.Message);
                return false;
            }

            return true;

        }

        //
        // ConvertMessage()
        //       -  Change Language of the form' Control' Text to Client Language
        // Return Value
        //       -  True / False
        // Arguments
        //       -  ByRef colControl As System.Windows.Forms.Control.ControlCollection : Form's Controls
        //       -
        public bool ConvertMessage(System.Windows.Forms.Control.ControlCollection colControl)
        {
            int i;
            int j;
            Control l_Control;
            string s_text;
            
            try
            {
                l_Control = null;
                
                foreach (Control tempLoopVar_l_Control in colControl)
                {
                    l_Control = tempLoopVar_l_Control;
                    if (l_Control is Panel)
                    {
                        if (l_Control is TabPage)
                        {
                            s_text = MPCF.Trim(((TabPage)l_Control).Text);
                            if (s_text != "")
                            {
                                ((TabPage)l_Control).Text = FindLanguage(s_text, 0);

                                #region Function Setup Output Test
                                //TabPage
                                //AllControl(((TabPage)l_Control).Name, 1); 
                                #endregion
                            
                            }
                        }
                        ConvertMessage(l_Control.Controls);
                    }
                    else if (l_Control is GroupBox)
                    {
                        s_text = MPCF.Trim(((GroupBox)l_Control).Text);
                        if ( s_text != "")
                        {
                            ((GroupBox)l_Control).Text = FindLanguage(s_text, 0);
                        }
                        ConvertMessage(l_Control.Controls);
                    }
                    else if (l_Control is TabControl)
                    {
                        ConvertMessage(l_Control.Controls);
                    }
                    else if (l_Control is Label)
                    {
                        ((Label) l_Control).Text = FindLanguage(((Label) l_Control).Text, 0);
                    }
                    else if (l_Control is RadioButton)
                    {
                        ((RadioButton) l_Control).Text = FindLanguage(((RadioButton) l_Control).Text, 0);

                        #region Function Setup Output Test
                        //Options
                        //if (((RadioButton)l_Control).Visible == true)
                        //{
                        //    AllControl(((RadioButton)l_Control).Name, 2);
                        //}
                        #endregion
                    
                    }
                    else if (l_Control is Button)
                    {
                        ((Button) l_Control).Text = FindLanguage(((Button) l_Control).Text, 1);

                        #region Function Setup Output Test
                        //Control             
                        //if (((Button)l_Control).Visible == true)
                        //{
                        //    AllControl(((Button)l_Control).Name, 0);
                        //}
                        #endregion
                    
                    }
                    else if (l_Control is CheckBox)
                    {
                        ((CheckBox) l_Control).Text = FindLanguage(((CheckBox) l_Control).Text, 0);

                        #region Function Setup Output Test
                        //Options
                        //if (((CheckBox)l_Control).Visible == true)
                        //{
                        //    AllControl(((CheckBox)l_Control).Name, 2);
                        //}
                        #endregion

                    }
                    else if (l_Control is UltraCheckEditor)
                    {
                        ((UltraCheckEditor) l_Control).Text = FindLanguage(((UltraCheckEditor) l_Control).Text, 0);
                    }
                    else if (l_Control is ListView)
                    {
                        for (i = 0; i < ((ListView)l_Control).Columns.Count; i++)
                        {
                            s_text = MPCF.Trim(((ListView)l_Control).Columns[i].Text);
                            if (s_text != "")
                            {
                                ((ListView)l_Control).Columns[i].Text = FindLanguage(s_text, 0);
                            }
                        }
                    }
                    else if (l_Control is FpSpread)
                    {
                        if (((FpSpread)l_Control).Tag != null)
                        {
                            s_text = MPCF.Trim(((FpSpread)l_Control).Tag);
                            if (s_text == "Header No Change")
                            {
                                return true;
                            }
                            else if (s_text == "Change Cell")
                            {
                                for (j = 0; j < ((FpSpread)l_Control).ActiveSheet.RowCount; j++)
                                {
                                    for (i = 0; i < ((FpSpread)l_Control).ActiveSheet.ColumnCount; i++)
                                    {
                                        s_text = MPCF.Trim(((FpSpread)l_Control).ActiveSheet.Cells[j, i].Value);
                                        if(s_text != "")
                                        {
                                            ((FpSpread)l_Control).ActiveSheet.Cells[j, i].Value = FindLanguage(s_text, 0);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                for (j = 0; j < ((FpSpread)l_Control).ActiveSheet.ColumnHeader.RowCount; j++)
                                {
                                    for (i = 0; i < ((FpSpread)l_Control).ActiveSheet.ColumnHeader.Columns.Count; i++)
                                    {
                                        s_text = MPCF.Trim(((FpSpread)l_Control).ActiveSheet.ColumnHeader.Cells[j, i].Value);
                                        if (s_text != "")
                                        {
                                            ((FpSpread)l_Control).ActiveSheet.ColumnHeader.Cells[j, i].Value = FindLanguage(s_text, 0);
                                        }
                                    }
                                }
                                for (j = 0; j < ((FpSpread)l_Control).ActiveSheet.RowHeader.Rows.Count; j++)
                                {
                                    for (i = 0; i < ((FpSpread)l_Control).ActiveSheet.RowHeader.ColumnCount; i++)
                                    {
                                        s_text = MPCF.Trim(((FpSpread)l_Control).ActiveSheet.RowHeader.Cells[j, i].Value);
                                        if (s_text != "")
                                        {
                                            ((FpSpread)l_Control).ActiveSheet.RowHeader.Cells[j, i].Value = FindLanguage(s_text, 0);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (j = 0; j < ((FpSpread)l_Control).ActiveSheet.ColumnHeader.RowCount; j++)
                            {
                                for (i = 0; i < ((FpSpread)l_Control).ActiveSheet.ColumnHeader.Columns.Count; i++)
                                {
                                    s_text = MPCF.Trim(((FpSpread)l_Control).ActiveSheet.ColumnHeader.Cells[j, i].Value);
                                    if (s_text != "")
                                    {
                                        ((FpSpread)l_Control).ActiveSheet.ColumnHeader.Cells[j, i].Value = FindLanguage(s_text, 0);
                                    }
                                }
                            }
                            for (j = 0; j < ((FpSpread)l_Control).ActiveSheet.RowHeader.Rows.Count; j++)
                            {
                                for (i = 0; i < ((FpSpread)l_Control).ActiveSheet.RowHeader.ColumnCount; i++)
                                {
                                    s_text = MPCF.Trim(((FpSpread)l_Control).ActiveSheet.RowHeader.Cells[j, i].Value);
                                    if (s_text != "")
                                    {
                                        ((FpSpread)l_Control).ActiveSheet.RowHeader.Cells[j, i].Value = FindLanguage(s_text, 0);
                                    }
                                }
                            }
                        }
                    }
                    else if (l_Control is SplitContainer)
                    {
                        ConvertMessage(l_Control.Controls);
                    }
                    else if (l_Control is UserControl)
                    {
                        if (!(l_Control is SOICodeView))
                        {
                            ConvertMessage(l_Control.Controls);
                        }
                    }

                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modLanguageFunction.ConvertMessage()\n" + ex.Message);
                return false;
            }
            
        }

        #region Function Setup Output Test


        //저장해 놓고 비교할 ArrayList
        //private ArrayList registeredArrList = new ArrayList();
        //private ArrayList AllArrList = new ArrayList();
        //private ArrayList DoRegist = new ArrayList();


        //////화면상 모든 컨트롤출력
        //public void AllControl(string S, int iType)
        //{
        //    //화면상 존재하는 콘트롤이 저장될 ArrayList
        //    ArrayList ControlArray = new ArrayList();

        //    try
        //    {
        //        switch (iType)
        //        {
        //            //Button
        //            case 0:
        //                ControlArray.Add("1.Control " + S);
        //                break;

        //            //TabPage
        //            case 1:
        //                ControlArray.Add("2.Tab " + S);
        //                break;

        //            //RadioButton & CheckBox
        //            case 2:
        //                ControlArray.Add("3.Options " + S);
        //                break;
        //        }

        //        foreach (String s in ControlArray)
        //        {
        //            //화면상에 존재하는 모든 콘트롤을 불러옵니다.
        //            //Debug.WriteLine("All : " +s);
        //            if (!AllArrList.Contains(s))
        //            {
        //                AllArrList.Add(s);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMsgBox(ex.Message);
        //    }
        //}

        //public struct FuncCtrlList
        //{
        //    public string ctrlName;
        //    public string ctrlValue;
        //}

        ////SEC에 등록된 컨트롤만 출력
        //public bool registeredControl(Form frm)
        //{
        //    TRSNode in_node = new TRSNode("VIEW_FUNCTION_DETAIL_IN");
        //    TRSNode in_node_two = new TRSNode("VIEW_FUNCTION_DETAIL_IN");
        //    TRSNode out_node = new TRSNode("VIEW_FUNCTION_DETAIL_OUT");
        //    FuncCtrlList[] CtrlList = new FuncCtrlList[10];
        //    ArrayList CtrlArrList = new ArrayList();

        //    int i;
        //    //등록할 Function Count
        //    int count_control, count_tabcontrol, count_option;
        //    //등록되어 있는 Function Count
        //    int count_ctl, count_tbp, count_opt;

        //    String ctl_update, tbp_update, opt_update;

        //    ArrayList ctl_Array = new ArrayList();
        //    ArrayList tbp_Array = new ArrayList();
        //    ArrayList opt_Array = new ArrayList();
        //    try
        //    {
        //        if (MPCF.Trim(frm.Tag) == "")
        //        {
        //            return true;
        //        }

        //        MPCF.SetInMsg(in_node);
        //        in_node.ProcStep = '1';
        //        in_node.AddString("PROGRAM_ID", MPGV.gsProgramID);
        //        in_node.AddString("FUNC_NAME", MPCF.Trim(frm.Tag));


        //        if (MPCF.CallService("SEC", "SEC_View_Function_Detail", in_node, ref out_node) == false)
        //        {
        //            return false;
        //        }

        //        //등록된 콘트롤Count 초기화
        //        count_ctl = 0;
        //        count_tbp = 0;
        //        count_opt = 0;

        //        for (i = 0; i < 10; i++)
        //        {
        //            //CTL_NAME_NUM
        //            CtrlList[i].ctrlName = out_node.GetString("CTL_NAME_" + (i + 1));

        //            if (CtrlList[i].ctrlName != "")
        //            {
        //                CtrlArrList.Add("1.Control " + CtrlList[i].ctrlName);
        //                count_ctl++;
        //            }
        //            else
        //            {
        //            }
        //        }

        //        for (i = 0; i < 10; i++)
        //        {
        //            //TAB_NAME_NUM
        //            CtrlList[i].ctrlName = out_node.GetString("TAB_NAME_" + (i + 1));

        //            if (CtrlList[i].ctrlName != "")
        //            {
        //                CtrlArrList.Add("2.Tab " + CtrlList[i].ctrlName);
        //                count_tbp++;
        //            }
        //            else
        //            {
        //            }
        //        }

        //        for (i = 0; i < 10; i++)
        //        {
        //            //OPT_NAME_NUM
        //            CtrlList[i].ctrlName = out_node.GetString("OPT_NAME_" + (i + 1));

        //            if (CtrlList[i].ctrlName != "")
        //            {
        //                CtrlArrList.Add("3.Options " + CtrlList[i].ctrlName);
        //                count_opt++;
        //            }
        //            else
        //            {
        //            }
        //        }


        //        //컨트롤 등록되는거 나오는것
        //        foreach (String s in CtrlArrList)
        //        {
        //            //등록되어 있는 콘트롤을 불러올때
        //            //Debug.WriteLine("등록된 거 : " + s);
        //            registeredArrList.Add(s);
        //        }

        //        //모든 컨트롤 - 등록된 컨트롤
        //        DoRegist = AllArrList;

        //        foreach (String s in registeredArrList)
        //        {
        //            DoRegist.Remove(s);
        //        }

        //        DoRegist.Sort();

        //        count_control = 0;
        //        count_tabcontrol = 0;
        //        count_option = 0;

        //        foreach (String ss in DoRegist)
        //        {
        //            //Debug.WriteLine(ss);
        //            String temp = ss.Substring(0, 1);
        //            String[] temp_Array = ss.Split(' ');

        //            if (!(temp_Array[1].Contains("btnClose") || temp_Array[1].Contains("btnNext")))
        //            {
        //                if (temp.Equals("1"))
        //                {
        //                    //등록할 버튼
        //                    count_control++;
        //                    ctl_Array.Add(temp_Array[1].Trim());
        //                }
        //                else if (temp.Equals("2"))
        //                {
        //                    //등록할 탭
        //                    count_tabcontrol++;
        //                    tbp_Array.Add(temp_Array[1].Trim());
        //                }
        //                else if (temp.Equals("3"))
        //                {
        //                    //등록할 옵션
        //                    count_option++;
        //                    opt_Array.Add(temp_Array[1].Trim());
        //                }
        //            }
        //            else
        //            {
        //            }
        //        }
        //        //Update MSECFUNDEF SET CTL_NAME_2='btnExcel', OPT_NAME_1='chkIncludeDelHistory' where FUNC_NAME='WIP3029';

        //        Debug.WriteLine(count_control + count_ctl);
        //        if (count_control + count_ctl <= 10)
        //        {
        //            for (int for_i = count_ctl; for_i < count_control + count_ctl; for_i++)
        //            {
        //                ctl_update = "UPDATE MSECFUNDEF SET CTL_NAME_" + (for_i + 1) + " = '" + ctl_Array[for_i - count_ctl] + "' WHERE FUNC_NAME = '" + out_node.GetString("FUNC_NAME") + "'";
        //                Debug.WriteLine(ctl_update);

        //            }
        //        }

        //        Debug.WriteLine(count_tabcontrol + count_tbp);
        //        if (count_tabcontrol + count_tbp <= 10)
        //        {
        //            for (int for_i = count_tbp; for_i < count_tabcontrol + count_tbp; for_i++)
        //            {
        //                tbp_update = "UPDATE MSECFUNDEF SET TAB_NAME_" + (for_i + 1) + " = '" + tbp_Array[for_i - count_tbp] + "' WHERE FUNC_NAME = '" + out_node.GetString("FUNC_NAME") + "'";
        //                Debug.WriteLine(tbp_update);

        //            }
        //        }

        //        Debug.WriteLine(count_option + count_opt);

        //        if (count_option + count_opt <= 10)
        //        {
        //            for (int for_i = count_opt; for_i < count_option + count_opt; for_i++)
        //            {
        //                opt_update = "UPDATE MSECFUNDEF SET OPT_NAME_" + (for_i + 1) + " = '" + opt_Array[for_i - count_opt] + "' WHERE FUNC_NAME = '" + out_node.GetString("FUNC_NAME") + "'";
        //                Debug.WriteLine(opt_update);
        //            }
        //        }

        //        DoRegist.Clear();
        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMsgBox(ex.Message);
        //        return false;
        //    }
        //    return true;
        //}

        #endregion
        
        
        //
        // FindLanguage()
        //       -  Find Client Language of source string
        // Return Value
        //       -  True / False
        // Arguments
        //       -  ByVal S As String :
        //       -
        //
        public class CaptionBinarySearch : IComparer
        {
            public int Compare(object lang, object txt)
            {
                LanguageDataTag l;

                l = (LanguageDataTag)lang;
                
                return new CaseInsensitiveComparer().Compare(l.Key, txt);
            }
        }

        public static string FindLanguage(string S, CAPTION_TYPE captionType)
        {
            return FindLanguage(S, (int)captionType);
        }
        public static string FindLanguage(string S, int iType)
        {
            LanguageDataTag lang;
            ArrayList langArray = new ArrayList();
            CaptionBinarySearch langCompare;
            string stxt = string.Empty;
            string sRight = string.Empty;
            string sLeft = string.Empty;
            int i;
            
            try
            {
                if (S.Trim() == "")
                {
                    return S;
                }
                
                switch (iType)
                {
                    case 0:
                        langArray = MPGV.gaTextLanguage;
                        break;
                    case 1:
                        langArray = MPGV.gaButtonLanguage;
                        break;
                    case 2:
                        langArray = MPGV.gaMenuLanguage;
                        break;
                }
                if (langArray.Count < 1)
                {
                    return S;
                }
                
                stxt = S;
                for (i = stxt.Length - 1; i >= 0; i--)
                {
                    if (stxt[i] != ' ')
                    {
                        break;
                    }
                }
                sRight = stxt.Substring(i + 1);
                stxt = stxt.Substring(0, i + 1);
                
                for (i = 0; i < stxt.Length; i++)
                {
                    if (stxt[i] != ' ')
                    {
                        break;
                    }
                }
                sLeft = stxt.Substring(0, i);
                stxt = stxt.Substring(i);
                
                if (stxt[stxt.Length - 1] == ':')
                {
                    for (i = stxt.Length - 2; i >= 0; i--)
                    {
                        if (stxt[i] != ' ')
                        {
                            break;
                        }
                    }

                    sRight = stxt.Substring(i + 1) + sRight;
                    stxt = stxt.Substring(0, i + 1);
                }
                
                langCompare = new CaptionBinarySearch();
                i = langArray.BinarySearch(stxt.ToUpper(), langCompare);
                
                if (i < 0)
                {
                    if (stxt.Length > 1)
                    {
                        switch (iType)
                        {
                            case 0:
                                Debug.Write("Other");
                                break;
                            case 1:
                                Debug.Write("Button");
                                break;
                            case 2:
                                Debug.Write("Menu");
                                break;
                        }
                        Debug.WriteLine("   <Text Key=\"" + stxt + "\"><L>" + stxt + "</L><L>" + stxt + "</L><L>" + stxt + "</L></Text>");
                    }
                    
                    return S;
                }

                lang = (LanguageDataTag)langArray[i];
                
                switch (MPGV.gcLanguage)
                {
                    case '1':
                        S = sLeft + lang.Lang_1 + sRight;
                        break;
                    case '2':
                        S = sLeft + lang.Lang_2 + sRight;
                        break;
                    case '3':
                        S = sLeft + lang.Lang_3 + sRight;
                        break;
                }
                
                return S;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return S;
            }
            
        }
        
        
        //
        // GetMessage()
        //       -  Find desired Message data
        // Return Value
        //       -  string : Return Message
        // Arguments
        //       -  i as integer : Message index
        //       -
        //
        public string GetMessage(int i)
        {
            string returnValue;
            try
            {
                if (MPGV.giMaxMessageData < i)
                {
                    returnValue = "No Error Message";
                }
                else
                {
                    if (MPGV.gcLanguage == '2')
                    {
                        if (CSGV.gsMessageData[1, i] == null)
                        {
                            returnValue = "No Error Message";
                        }
                        else
                        {
                            returnValue = CSGV.gsMessageData[1, i];
                        }
                        
                    }
                    else if (MPGV.gcLanguage == '3')
                    {
                        if (CSGV.gsMessageData[2, i] == null)
                        {
                            returnValue = "No Error Message";
                        }
                        else
                        {
                            returnValue = CSGV.gsMessageData[2, i];
                        }
                        
                    }
                    else
                    {
                        if (CSGV.gsMessageData[0, i] == null)
                        {
                            returnValue = "No Error Message";
                        }
                        else
                        {
                            returnValue = CSGV.gsMessageData[0, i];
                        }
                    }
                }
                return returnValue;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return "";
                
            }
        }
        
        //
        // LoadMessageResource()
        //       -  Load message resource data
        // Return Value
        //       -  True / False
        // Arguments
        //       -
        //       -
        //
        public bool LoadMessageResource(string sMessageFile)
        {
            
            System.IO.FileStream fs = null;
            System.Xml.XmlTextReader xtr = null;
            
            string[] sTemp = new string[3];
            int i;
            int j;
            CSGV.gsMessageData = new string[3, MPGV.giMaxMessageData];
            try
            {
                
                // Open XML File
                if (File.Exists(Application.StartupPath + "\\" + sMessageFile) == false)
                {
                    return true;
                }

                fs = new System.IO.FileStream(Application.StartupPath + "\\" + sMessageFile, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
                
                // Set xmlReader
                xtr = new XmlTextReader(fs);
                
                while (xtr.Read())
                {
                    switch (xtr.NodeType)
                    {
                        case XmlNodeType.Element:
                            
                            switch (xtr.Name.ToUpper())
                            {
                                case "TEXT":
                                    
                                    xtr.MoveToAttribute("Key");
                                    j = MPCF.ToInt(xtr.Value);
                                    
                                    i = 0;
                                    while (xtr.Read())
                                    {
                                        if (xtr.NodeType == XmlNodeType.Text)
                                        {
                                            sTemp[i] = xtr.Value.Trim();
                                            i++;
                                        }
                                        else if (xtr.NodeType == XmlNodeType.EndElement && xtr.Name.ToUpper() == "TEXT")
                                        {
                                            break;
                                        }
                                    }

                                    CSGV.gsMessageData[0, j] = sTemp[0];
                                    CSGV.gsMessageData[1, j] = sTemp[1];
                                    CSGV.gsMessageData[2, j] = sTemp[2];
                                    break;
                            }
                            break;
                            
                    }
                }
                
            }
            catch (Exception)
            {
                if (!(xtr == null))
                {
                    MPCF.ShowMsgBox("Occured error in read message xml file.\n" + "\'" + xtr.Name + xtr.Value + "\'");
                }
            }
            finally
            {
                // Close XML File
                if (!(xtr == null))
                {
                    xtr.Close();
                }
                if (!(fs == null))
                {
                    fs.Close();
                }
            }
            
            return true;
            
        }
        
        //
        // LoadCaptionResource()
        //       -  Load Text Data
        // Return Value
        //       -  True / False
        // Arguments
        //       -
        //       -
        //
        public class CaptionLangSort : IComparer
        {
            
            public int Compare(object l1, object l2)
            {
                LanguageDataTag lang1;
                LanguageDataTag lang2;

                lang1 = (LanguageDataTag)l1;
                lang2 = (LanguageDataTag)l2;
                
                return new CaseInsensitiveComparer().Compare(lang1.Key, lang2.Key);
            }
        }
        
        public bool LoadCaptionResource(string sCaptionFile)
        {

            const int MENU_TYPE = 0;
            const int BUTTON_TYPE = 1;
            const int OTHER_TYPE = 2;

            System.IO.FileStream fs = null;
            System.Xml.XmlTextReader xtr = null;

            LanguageDataTag lang;
            int iCapType = 0;
            string[] sTemp = new string[3];
            int i;
            CaptionLangSort langSort;

            try
            {
                MPGV.gaButtonLanguage.Clear();
                MPGV.gaMenuLanguage.Clear();
                MPGV.gaTextLanguage.Clear();

                // Open XML File
                if (File.Exists(Application.StartupPath + "\\" + sCaptionFile) == false)
                {
                    return true;
                }

                fs = new System.IO.FileStream(Application.StartupPath + "\\" + sCaptionFile, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);

                // Set xmlReader
                xtr = new XmlTextReader(fs);

                while (xtr.Read())
                {
                    switch (xtr.NodeType)
                    {
                        case XmlNodeType.Element:

                            switch (xtr.Name.ToUpper())
                            {
                                case "BUTTON":

                                    iCapType = BUTTON_TYPE;
                                    break;
                                case "MENU":

                                    iCapType = MENU_TYPE;
                                    break;
                                case "OTHER":

                                    iCapType = OTHER_TYPE;
                                    break;
                                case "TEXT":

                                    xtr.MoveToAttribute("Key");
                                    lang.Key = xtr.Value.Trim().ToUpper();

                                    i = 0;
                                    while (xtr.Read())
                                    {
                                        if (xtr.NodeType == XmlNodeType.Text)
                                        {
                                            sTemp[i] = xtr.Value.Trim();
                                            i++;
                                        }
                                        else if (xtr.NodeType == XmlNodeType.EndElement && xtr.Name.ToUpper() == "TEXT")
                                        {
                                            break;
                                        }
                                    }
                                    lang.Lang_1 = sTemp[0];
                                    lang.Lang_2 = sTemp[1];
                                    lang.Lang_3 = sTemp[2];

                                    switch (iCapType)
                                    {
                                        case BUTTON_TYPE:

                                            MPGV.gaButtonLanguage.Add(lang);
                                            break;
                                        case MENU_TYPE:

                                            MPGV.gaMenuLanguage.Add(lang);
                                            break;
                                        case OTHER_TYPE:

                                            MPGV.gaTextLanguage.Add(lang);
                                            break;
                                    }
                                    break;
                            }
                            break;

                    }
                }

                langSort = new CaptionLangSort();
                MPGV.gaButtonLanguage.Sort(langSort);
                MPGV.gaMenuLanguage.Sort(langSort);
                MPGV.gaTextLanguage.Sort(langSort);

            }
            catch (Exception)
            {
                if (!(xtr == null))
                {
                    //MPCF.ShowMsgBox(GetMessage(8) + "\n" + "\'" + xtr.Name + xtr.Value + "\'", "Read Caption Xml", MessageBoxButtons.OK, MPCF.ToInt(MessageBoxIcon.Warning));
                }
            }
            finally
            {
                // Close XML File
                if (!(xtr == null))
                {
                    xtr.Close();
                }
                if (!(fs == null))
                {
                    fs.Close();
                }
            }

            return true;

        }
    }
    
}
