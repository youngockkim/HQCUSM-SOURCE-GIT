//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : clsCusCommonFunction.cs
//   Description : Customizing Common Function
//
//   MES Version : 5.2.0.0
//
//   Function List
//       - GetCusClientOptions() : Get Customizing Client Options
//       - ViewResourceList() : View Resource List
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//
//
//   Copyright(C) 1998-2012 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

#region " using Definition "
using Miracom.MsgHandler;
using System.Threading;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOI.CliFrx;
using System.Runtime.InteropServices;
using Miracom.TRSCore;
using SOI.OIFrx.SOIModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Reflection;
using System.Globalization;
using Infragistics.Win.UltraWinEditors;
using SOI.OIFrx.SOIControls;
using System.Management;
using System.Security.Principal;
using Infragistics.Win.UltraWinSchedule;
using System.Drawing;
using System.Net;
using FarPoint.Win.Spread;
using System.Xml.Linq;
using Infragistics.Win.Misc;
using SOI.OIFrx;
using SOI.OIFrx.SOIThemes;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIBaseForm;
using Infragistics.Win.UltraWinGrid;
using System.Data;
using System.IO.Ports;
using System.IO.Compression;


using Miracom.MESCore;
using Miracom.CliFrx;
using System.Runtime.Serialization.Formatters.Binary;
#endregion

namespace Custom.Common
{
    public class HQCF
    {

        #region " Constant Definition "

        public struct DViewCond
        {
            public string sCondtion_ID;
            public string sCondition_Type;
            public object sCondition_Value;
            public int iCondition_Value;
            public double dCondition_Value;
            public float fCondition_Value;
        }

        const string MP_SUCCESS_SOUND_FILE = "MpSuccess.wav";
        const string MP_FAIL_SOUND_FILE = "MpError.wav";
        const string MP_WARN_SOUND_FILE = "MpWarning.wav";

        public enum MP_MSG_TYPE
        {
            TYPE_INFO = 1,
            TYPE_SUCCESS = 2,
            TYPE_WARN = 3,
            TYPE_ERROR = 4
        }

        private static Boolean IsSoundSupported()
        {
            if (waveOutGetNumDevs() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public enum SpreadCellType
        {
            /// <summary>Button Cell Type</summary>
            ButtonCellType,
            /// <summary>CheckBox Cell Type</summary>
            CheckBoxCellType,
            /// <summary>ComboBox Cell Type</summary>
            ComboBoxCellType,
            /// <summary>Date Cell Type(ex. 2010-01-01)</summary>
            DateCellType,
            /// <summary>Time Cell Type(ex. 13:00:00)</summary>
            TimeCellType,
            /// <summary>DateTime Cell Type(ex. 2010-01-01 13:00:00)</summary>
            DateTimeCellType,
            /// <summary>IntCellType</summary>
            IntCellType,
            /// <summary>NumberCellType</summary>
            NumberCellType,
            /// <summary>RichTextCellType</summary>
            RichTextCellType,
            /// <summary>TextCellType</summary>
            TextCellType,
            /// <summary>ComboBox Cell Type Editable</summary>
            ComboBoxEditableCellType
        }

        // Messages        
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const int WM_CHAR = 0x105;
        const int WM_SYSKEYDOWN = 0x104;
        const int WM_SYSKEYUP = 0x105;
        const int SND_ASYNC = 0x1;

        #endregion

        #region " Function Definition "

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("winmm.dll")]
        private static extern int sndPlaySoundA(string lpszFileName, int uFlags);
        [DllImport("winmm", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        protected static extern int waveOutGetNumDevs();

        public static void ApplyTema(bool bRowHeader, bool bSort, FarPoint.Win.Spread.OperationMode operMode, FarPoint.Win.Spread.FpSpread spdData)
        {
            FarPoint.Win.Spread.SheetSkin spSkin;

            try
            {
                FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(spdData);
                spSkin = new FarPoint.Win.Spread.SheetSkin("InitSkin",
                                           System.Drawing.Color.AliceBlue,
                                           System.Drawing.Color.Empty,
                                           System.Drawing.Color.Empty,
                                           System.Drawing.Color.Gray,
                                           FarPoint.Win.Spread.GridLines.Both,
                    //System.Drawing.Color.FromArgb(42, 61, 112),
                                           System.Drawing.Color.WhiteSmoke,
                                           System.Drawing.Color.Black,
                                           System.Drawing.Color.FromArgb(192, 192, 255),
                                           System.Drawing.Color.White,
                                           System.Drawing.Color.Empty,
                                           System.Drawing.Color.White,
                    //System.Drawing.Color.FromArgb(231, 231, 255),
                    //System.Drawing.Color.FromArgb(247, 247, 222),
                                           true,
                                           true,
                                           false,
                                           true,
                                           bRowHeader);

                spdData.BorderStyle = BorderStyle.FixedSingle;
                spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
                spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
                spdData.MoveActiveOnFocus = true;

                spdData.ColumnSplitBoxAlignment = FarPoint.Win.Spread.SplitBoxAlignment.Leading;
                spdData.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.AsNeeded;

                spdData.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;

                spdData.SetCursor(FarPoint.Win.Spread.CursorType.Normal, System.Windows.Forms.Cursors.Arrow);
                spdData.BorderStyle = BorderStyle.FixedSingle;
                spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
                spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
                spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;

                for (int i = 0; i < spdData.Sheets.Count; i++)
                {
                    //"Verdana", "Tahoma", "Times New Roman", "돋움"
                    Font myFonts = new Font("Tahoma", 8F, FontStyle.Regular);

                    spSkin.Apply(spdData.Sheets[i]);

                    //this.spdMaterialList.Sheets[i].RowCount = 0;
                    //this.spdMaterialList.Sheets[i].ColumnCount = 0;
                    //this.spdMaterialList.Sheets[i].OperationMode = operMode;
                    //this.spdMaterialList.Sheets[i].Columns[-1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    //this.spdMaterialList.Sheets[i].GrayAreaBackColor = System.Drawing.Color.AliceBlue;  //System.Drawing.SystemColors.Control; // System.Drawing.Color.Silver;
                    spdData.Sheets[i].ColumnHeader.Rows[0].Height = 40;
                    spdData.Sheets[i].ColumnHeader.DefaultStyle.Font = new Font("맑은 고딕", 8.15F, System.Drawing.FontStyle.Regular);  // new Font("Tahoma", 8F, FontStyle.Bold);

                    spdData.Sheets[i].DefaultStyle.Font = myFonts;
                    spdData.Sheets[i].DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                    // Auto sort setting.
                    //this.spdMaterialList.Sheets[i].SetColumnAllowAutoSort(0, this.spdMaterialList.Sheets[i].ColumnCount, bSort);
                    spdData.Sheets[i].ColumnHeader.AutoSortIndex = 0;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AddTextShape(FarPoint.Win.Spread.FpSpread spread, string sTextShapeData, System.Drawing.Color Color, int i_XPos, int i_YPos, int i_Width, int i_Height)
        {

            if (MPCF.Trim(sTextShapeData) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                return;
            }


            FarPoint.Win.Spread.DrawingSpace.TextShape txtbox1 = new FarPoint.Win.Spread.DrawingSpace.TextShape();

            // 기존 drawing 된 TextShape 삭제. 
            spread.ActiveSheet.DrawingContainer.RemoveShape("txtBackWord");

            txtbox1.Name = "txtBackWord";
            txtbox1.Text = MPCF.Trim(sTextShapeData);     // 추후 서버에서 STRING으로 전달받거나 GENERATE 해야 하는 부분.
            txtbox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtbox1.BackColor = Color;
            txtbox1.ShapeOutlineColor = Color.Transparent;
            txtbox1.AlphaBlendBackColor = 150; //투명도 조절

            //위치 및 사이즈 설정 : 기본예시 250, 100, 160, 80 ( 현재 스프레드 디자이너에 설정된 넓이, 높이에서..)
            txtbox1.SetBounds(i_XPos, i_YPos, i_Width, i_Height);
            spread.ActiveSheet.DrawingContainer.AddShape(txtbox1);
        }

        /// <summary>
        /// 모든 컬럼에 적용 
        /// </summary>
        /// <param name="spread"></param>
        public static void AutoSort(FarPoint.Win.Spread.FpSpread spread)
        {
            for (int i = 0; i < spread.Sheets[0].Columns.Count; i++)
            {
                spread.Sheets[0].Columns[i].AllowAutoSort = true;
            }
        }


        /// <summary>
        /// ViewCaptionList()
        /// </summary>
        /// <param name="control"></param>
        /// <param name="sFilter"></param>
        /// <param name="bIncludeDeletedLine"></param>
        /// <returns></returns>

        public static bool ViewCaptionList(char cProcStep, Control control, string sCaptionType)
        {
            return ViewCaptionList(cProcStep, control, sCaptionType, "");
        }

        public static bool ViewCaptionList(Control control, string sCaptionType)
        {
            return ViewCaptionList('1', control, sCaptionType, "");
        }

        public static bool ViewCaptionList(char cProcStep, Control control, string sCaptionType, string sSearchKey)
        {
            try
            {
                int i;
                ListViewItem itmX;
                ArrayList a_list;

                TRSNode in_node = new TRSNode("In_node");
                TRSNode out_node;

                a_list = new ArrayList();

                if (control is ListView)
                {
                    MPCF.InitListView((ListView)control);
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = cProcStep;
                in_node.AddString("CAPTION_TYPE", sCaptionType);
                in_node.AddString("SEARCH_KEY", MPCF.Trim(sSearchKey));

                in_node.AddString("NEXT_CAPTION_KEY", " ");

                do
                {
                    out_node = new TRSNode("VIEW_CAPTION_OUT");

                    if (MPCR.CallService("COM", "COM_View_Caption_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    a_list.Add(out_node);

                    in_node.SetString("NEXT_CAPTION_KEY", out_node.GetString("NEXT_CAPTION_KEY"));
                } while (in_node.GetString("NEXT_CAPTION_KEY") != "");

                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (control is ListView)
                        {
                            itmX = new ListViewItem(out_node.GetList(0)[i].GetString("CAPTION_KEY"), (int)SOI.CliFrx.SMALLICON_INDEX.IDX_MESSAGE);


                            if (((ListView)control).Columns.Count > 1)
                            {
                                if (MPGV.gcLanguage == '1')
                                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CAPTION_MSG_1"));
                                else if (MPGV.gcLanguage == '2')
                                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CAPTION_MSG_2"));
                                else if (MPGV.gcLanguage == '3')
                                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CAPTION_MSG_3"));

                            }
                            ((ListView)control).Items.Add(itmX);
                        }
                        else if (control is ComboBox)
                        {
                            ((ComboBox)control).Items.Add(out_node.GetList(0)[i].GetString("CAPTION_KEY"));
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

        public static string GetQueryString(string sQueryID, string[] Argu)
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DATA_LIST_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SQL_ID_1", sQueryID);

                for (int i = 0; i < Argu.Length; i++)
                {
                    TRSNode node = in_node.AddNode("ARGU_LIST");
                    node.AddString("ARGUMENT", Argu[i]);
                }

                if (MPCR.CallService("CBAS", "CBAS_View_Query_Result", in_node, ref out_node) == false)
                {
                    return "";
                }

                string sql = out_node.GetString("SQL");
                return sql;
            }
            catch (Exception ee)
            {
                MPCF.ShowMsgBox(ee.Message);
                return "";
            }
        }

        public static string GetQueryString(string sQueryID)
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DATA_LIST_OUT");

            try
            {
                in_node.ProcStep = '1';
                in_node.AddString("SQL_ID", sQueryID);

                if (MPCR.CallService("CBAS", "CBAS_View_Sql", in_node, ref out_node) == false)
                {
                    return "";
                }

                string sqlquery = new String(Encoding.UTF8.GetChars(out_node.GetBlob(MPGC.MP_BIN_DATA_1)));
                return sqlquery;
            }
            catch (Exception ee)
            {
                MPCF.ShowMsgBox(ee.Message);
                return "";
            }
        }

        public static string PackConditionString(string s_Cond)
        {

            string s_Ret = string.Empty;

            try
            {
                s_Ret = " '" + s_Cond.Trim() + "'";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return s_Ret;
            }

            return s_Ret;
        }

        public static string PackConditionString(object ctrl)
        {
            object l_Control;

            bool b_MultiSelect = false;

            string s_Ret = string.Empty;
            string s_CondValue = string.Empty;
            string s_CondDisplay = string.Empty;

            try
            {
                l_Control = ctrl;


                #region "udcMESCondition"
                if (l_Control is Miracom.UI.Controls.MCCodeView.MCCodeView)
                {
                    s_CondValue = ((Miracom.UI.Controls.MCCodeView.MCCodeView)l_Control).Text.Trim();
                    s_CondDisplay = ((Miracom.UI.Controls.MCCodeView.MCCodeView)l_Control).DisplayText.Trim();

                    if (b_MultiSelect == false)
                    {
                        if (s_CondValue != s_CondDisplay)
                        {
                            if (string.IsNullOrEmpty(s_CondDisplay) == true || s_CondDisplay == "ALL")
                            {
                                s_Ret = "'%'";
                            }
                            else
                            {
                                s_Ret = PackConditionString(s_CondValue);
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(s_CondValue) == true || s_CondValue == "ALL")
                            {
                                s_Ret = "'%'";
                            }
                            else
                            {
                                s_Ret = PackConditionString(s_CondValue);
                            }
                        }
                    }

                }//if (l_Control is Miracom.SmartWeb.UserControls.udcMESCondition)
                #endregion

                else if (l_Control is TextBox)
                {
                    s_CondValue = ((System.Windows.Forms.TextBox)l_Control).Text.Trim();
                    if (string.IsNullOrEmpty(s_CondValue) == true)
                        s_Ret = "'%'";
                    else
                        s_Ret = PackConditionString(s_CondValue);
                }
                else if (l_Control is ComboBox)
                {
                    s_CondValue = ((System.Windows.Forms.ComboBox)l_Control).Text.Trim();
                    if (string.IsNullOrEmpty(s_CondValue) == true || s_CondValue == "ALL")
                        s_Ret = "'%'";
                    else
                        s_Ret = PackConditionString(s_CondValue);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return s_Ret;
            }

            return s_Ret;
        }

        public static bool ReplaceCondtionToString(object oCondition, ref string sQueryStatement)
        {
            //int i;

            bool bRet = false;

            string s_CondName = string.Empty;
            string s_CondValue = string.Empty;
            string s_DynamicQuery = string.Empty;
            string s_tmp = string.Empty;

            try
            {
                //object l_Control;
                //l_Control = null;
                System.Windows.Forms.Control f = (System.Windows.Forms.Control)oCondition;

                foreach (Control ctrl in f.Controls)
                {

                    if (ctrl is Panel || ctrl is GroupBox || ctrl is TabControl || ctrl is TabPage || ctrl is SplitContainer || ctrl is SplitterPanel)
                    {
                        ReplaceCondtionToString(ctrl, ref sQueryStatement);
                    }
                    else
                    {
                        s_CondValue = string.Empty;

                        s_CondName = ctrl.Name;
                        s_CondName = "$" + s_CondName.ToLower();

                        if (ctrl is Miracom.MESCore.Controls.udcFromToDate)
                        {
                            // 순서 변경 금지...
                            s_CondName = "$fromtime";
                            s_CondValue = PackConditionString(((Miracom.MESCore.Controls.udcFromToDate)ctrl).FromDateTime);
                            sQueryStatement = sQueryStatement.Replace(s_CondName, s_CondValue);

                            s_CondName = "$totime";
                            s_CondValue = PackConditionString(((Miracom.MESCore.Controls.udcFromToDate)ctrl).ToDateTime);
                            sQueryStatement = sQueryStatement.Replace(s_CondName, s_CondValue);

                            s_CondName = "$fromdate";
                            s_CondValue = PackConditionString(((Miracom.MESCore.Controls.udcFromToDate)ctrl).FromDate);
                            sQueryStatement = sQueryStatement.Replace(s_CondName, s_CondValue);

                            s_CondName = "$todate";
                            s_CondValue = PackConditionString(((Miracom.MESCore.Controls.udcFromToDate)ctrl).ToDate);
                            sQueryStatement = sQueryStatement.Replace(s_CondName, s_CondValue);
                        }
                        else
                        {
                            s_CondValue = PackConditionString(ctrl);
                            sQueryStatement = sQueryStatement.Replace(s_CondName, s_CondValue);
                        }
                    }
                }


                bRet = true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return bRet;
        }

        public static string QueryCondChange(string sql_id, string query, string[] sCondition, bool isDynamic)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(query.Trim());

            string sTmp = "'" + MPGV.gcLanguage + "'";
            sb = sb.Replace("$gsLanguage", sTmp);

            sTmp = "'" + MPGV.gsFactory + "'";
            sb = sb.Replace("$gsFactory", sTmp);

            sTmp = "'" + MPGV.gsFactory + "'";
            sb = sb.Replace("$FACTORY", sTmp);

            if (sCondition != null)
            {
                if (sCondition.Length >= 9)
                {
                    for (int i = 9; i < sCondition.Length; i++)
                    {
                        if (isDynamic == false)
                        {
                            sTmp = "'" + sCondition[i] + "'";
                        }
                        else
                        {
                            sTmp = sCondition[i];
                        }
                        sb = sb.Replace("$" + (i + 1), sTmp);
                    }
                }

                for (int i = 0; i < sCondition.Length; i++)
                {
                    if (isDynamic == false)
                    {
                        sTmp = "'" + sCondition[i] + "'";
                    }
                    else
                    {
                        sTmp = sCondition[i];
                    }
                    sb = sb.Replace("$" + (i + 1), sTmp);
                }
            }

            string[] str = new string[1];

            return sb.ToString();

        }

        /// <summary>
        /// 다이나믹 쿼리문이 존재하면 추가 치환한다.
        /// </summary>
        /// <param name="sql_id"></param>
        /// <param name="query"></param>
        /// <param name="lstCond1"></param>
        /// <param name="isDynamic"></param>
        /// <returns></returns>
        public static string QueryCondChange2(string sql_id, string query, List<string> lstCond1, bool isDynamic)
        {
            StringBuilder sbQry = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            int i_Length = 0;
            string s_DynamicQuery = string.Empty;
            string sQueryStatement = string.Empty;

            sb.Remove(0, sbQry.Length);
            sb.AppendLine(query);

            try
            {
                #region Agument Replace
                if (lstCond1 != null)
                {
                    foreach (string strKey in lstCond1)
                    {
                        i_Length = 0;

                        if (sb.ToString().IndexOf("?") < 0)
                        {
                            break;
                        }
                        i_Length = sb.ToString().IndexOf("?") + 1;
                        s_DynamicQuery = sb.ToString().Substring(0, sb.ToString().IndexOf("?"));
                        s_DynamicQuery += strKey;
                        s_DynamicQuery += sb.ToString().Substring(sb.ToString().IndexOf("?") + 1, sb.ToString().Length - i_Length);

                        sQueryStatement = s_DynamicQuery;

                        sb.Remove(0, sb.Length);
                        sb.AppendLine(s_DynamicQuery);
                    }
                    //sQueryStatement = s_DynamicQuery;
                }
                #endregion
                return sb.ToString();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return string.Empty;
            }
            finally
            {
            }
        }

        public class Thread_safe_Call
        {
            private static Thread_safe_Call myInstance = null;
            private Mutex serviceMutex = new Mutex(false, "CALL_SERVICE");

            private Thread_safe_Call()
            { }

            public bool CallService_Thread_safe(string mudule, string service, TRSNode in_node, ref TRSNode out_node)
            {
                bool is_result = false;
                serviceMutex.WaitOne(10000);
                try
                {
                    is_result = MessageCaster.CallService(mudule, service, in_node, ref out_node, "", 2500, DeliveryMode.RReply);
                }
                catch (Exception ee)
                {
                    throw ee;
                }
                finally
                {
                    serviceMutex.ReleaseMutex();
                }

                return is_result;
            }

            public bool CallService_Thread_safe(string mudule, string service, TRSNode in_node, ref TRSNode out_node, Boolean b_ingnor_message)
            {
                bool is_result = false;
                serviceMutex.WaitOne(10000);

                try
                {
                    if (MessageCaster.CallService(mudule, service, in_node, ref out_node, "", 2500, DeliveryMode.RReply) == false)
                    {
                        if (b_ingnor_message == false)
                            MPCF.ShowMsgBox(MPMH.StatusMessage);
                        else
                            out_node.SetString("MSG", MPMH.StatusMessage);

                        is_result = false;
                    }
                    else
                        is_result = true;
                }
                catch (Exception ee)
                {
                    throw ee;
                }
                finally
                {
                    serviceMutex.ReleaseMutex();
                }

                return is_result;
            }

            public bool CallService_Thread_safe(string module, string service, TRSNode in_node, string channel, int ttl, DeliveryMode mode, Boolean b_ingnor_message)
            {
                bool is_result = false;
                serviceMutex.WaitOne(10000);
                try
                {
                    if (MessageCaster.CallService(module, service, in_node, channel, ttl, mode) == false)
                    {
                        if (b_ingnor_message == false)
                            MPCF.ShowMsgBox(MPMH.StatusMessage);

                        is_result = false;
                    }
                    else
                        is_result = true;
                }
                catch (Exception ee)
                {
                    throw ee;
                }
                finally
                {
                    serviceMutex.ReleaseMutex();
                }

                return is_result;
            }

            public bool CallService_Thread_safe(string module, string service, TRSNode in_node, ref TRSNode out_node, string channel)
            {
                bool is_result = false;
                serviceMutex.WaitOne(10000);
                try
                {
                    if (MessageCaster.CallService(module, service, in_node, ref out_node, channel, 2500, DeliveryMode.RReply) == false)
                    {
                        MPCF.ShowMsgBox(MPMH.StatusMessage);

                        is_result = false;
                    }
                    else
                        is_result = true;
                }
                catch (Exception ee)
                {
                    throw ee;
                }
                finally
                {
                    serviceMutex.ReleaseMutex();
                }

                return is_result;
            }

            public static Thread_safe_Call getInstance()
            {
                if (myInstance == null)
                {
                    myInstance = new Thread_safe_Call();
                }

                return myInstance;
            }
        }


        public static DataTable MGetData(string sQueryID, object cndGrp, string[] sCondition)
        {
            return MGetData(false, sQueryID, cndGrp, sCondition, false, "");
        }

        public static DataTable MGetData(string sQueryID, string[] sCondition)
        {
            return MGetData(false, sQueryID, null, sCondition, false, "");
        }

        public static DataTable MGetData(string sQueryID, string[] sCondition, List<string> lstCond1)
        {
            return MGetData(false, sQueryID, null, sCondition, false, lstCond1, true, "");
        }

        public static DataTable MGetData(bool multiThread, string sQueryID, string[] sCondition)
        {
            return MGetData(multiThread, sQueryID, null, sCondition, false, "");
        }

        public static DataTable MGetData(string sQueryID, string[] sCondition, bool isDynamic)
        {
            return MGetData(false, sQueryID, null, sCondition, isDynamic, "");
        }

        public static DataTable MGetData(string sQueryID, object cndGrp, string[] sCondition, bool isDynamic)
        {
            return MGetData(false, sQueryID, cndGrp, sCondition, isDynamic, "");
        }

        public static bool CallService_safe(string mudule, string service, TRSNode in_node, ref TRSNode out_node)
        {
            Thread_safe_Call tc = Thread_safe_Call.getInstance();
            return tc.CallService_Thread_safe(mudule, service, in_node, ref out_node);
        }

        public static bool CallService_safe(string mudule, string service, TRSNode in_node, ref TRSNode out_node, Boolean ingnor_message)
        {
            Thread_safe_Call tc = Thread_safe_Call.getInstance();
            return tc.CallService_Thread_safe(mudule, service, in_node, ref out_node, ingnor_message);
        }

        public static bool CallService_safe(string module, string service, TRSNode in_node, string channel, int ttl, DeliveryMode mode, Boolean ingnor_message)
        {
            Thread_safe_Call tc = Thread_safe_Call.getInstance();
            return tc.CallService_Thread_safe(module, service, in_node, channel, ttl, mode, ingnor_message);
        }

        public static bool CallService_safe(string module, string service, TRSNode in_node, ref TRSNode out_node, string channel)
        {
            Thread_safe_Call tc = Thread_safe_Call.getInstance();
            return tc.CallService_Thread_safe(module, service, in_node, ref out_node, channel);
        }

        public static DataTable MGetData(bool multi_Thread, string sQueryID, object cndGrp, string[] sCondition, bool isDynamic, string channel)
        {

            TRSNode view_in_node = new TRSNode("sql_view_in_node");
            TRSNode view_out_node = new TRSNode("sql_view_out_node");
            bool first_flag = false;
            DataTable _dt = new DataTable();
            string made_query = string.Empty;

            try
            {
                string sqlquery = GetQueryString(sQueryID, sCondition);
                if (string.IsNullOrEmpty(sqlquery) == true)
                {
                    return null;
                }

                if (cndGrp != null)
                {
                    ReplaceCondtionToString(cndGrp, ref sqlquery);
                }

                made_query = QueryCondChange(sQueryID, sqlquery, sCondition, isDynamic);

                MPCR.SetInMsg(view_in_node);
                view_in_node.ProcStep = '1';
                view_in_node.SetString("STATUS_MSG_FLAG", "Y");

                byte[] bsq = System.Text.Encoding.UTF8.GetBytes(made_query.ToString());
                view_in_node.AddBlob(MPGC.MP_BIN_DATA_1, bsq);
                //view_in_node.AddString("SQL", made_query.ToString());

                do
                {
                    if (multi_Thread == true)
                    {
                        if (CallService_safe("BAS", "BAS_SQL_Query", view_in_node, ref view_out_node) == false)
                        {
                            return null;
                        }
                    }
                    else
                    {
                        if (MPCR.CallService("BAS", "BAS_SQL_Query", view_in_node, ref view_out_node) == false)
                        {
                            return null;
                        }
                    }

                    if (first_flag == true)
                    {

                        _dt = MPCR.ConvertToDataTable(_dt, view_out_node);
                    }
                    else
                    {
                        if (MPCR.ConvertToDataTable(view_out_node) == null)
                        {
                            break;
                        }

                        _dt = MPCR.ConvertToDataTable(view_out_node);
                    }

                    first_flag = true;
                    view_in_node.SetInt("NEXT_ROW", view_out_node.GetInt("NEXT_ROW"));

                } while (view_in_node.GetInt("NEXT_ROW") > 0);

                return _dt;
            }
            catch (Exception ee)
            {
                MPCF.ShowMsgBox(ee.Message);
                return null;
            }
            //finally
            //{
            //    string sQueryStatement = string.Empty;
            //    StringBuilder sbSqlLog = new StringBuilder();
            //    sbSqlLog.Append(made_query.ToString());
            //    sbSqlLog.AppendLine(";"); //쿼리 끝 지점
            //    System.Diagnostics.Trace.WriteLine(sbSqlLog.ToString());
            //    sQueryStatement = sbSqlLog.ToString();
            //    MPGV.gsQueryStatementLong = MPGV.gsQueryStatementLong + "DGetData" + "\r\n" + sQueryStatement + "\r\n"; // 다중 Query문 저장
            //}
        }
        /// <summary>
        /// 다이나믹 쿼리 적용
        /// </summary>
        /// <param name="multi_Thread"></param>
        /// <param name="sQueryID"></param>
        /// <param name="cndGrp"></param>
        /// <param name="sCondition"></param>
        /// <param name="isDynamic"></param>
        /// <param name="lstCond1">다이나믹 쿼리문</param>
        /// <param name="isDynamic2">적용여부 default true</param>
        /// <param name="channel"></param>
        /// <returns></returns>
        public static DataTable MGetData(bool multi_Thread, string sQueryID, object cndGrp, string[] sCondition, bool isDynamic, List<string> lstCond1, bool isDynamic2, string channel)
        {
            TRSNode view_in_node = new TRSNode("sql_view_in_node");
            TRSNode view_out_node = new TRSNode("sql_view_out_node");
            bool first_flag = false;
            DataTable _dt = new DataTable();
            string made_query = string.Empty;

            try
            {
                string sqlquery = GetQueryString(sQueryID, sCondition);
                if (string.IsNullOrEmpty(sqlquery) == true)
                {
                    return null;
                }

                if (cndGrp != null)
                {
                    ReplaceCondtionToString(cndGrp, ref sqlquery);
                }

                made_query = QueryCondChange(sQueryID, sqlquery, sCondition, isDynamic);
                //다이나믹 쿼리문이 존재하면 추가 치환한다.
                if (lstCond1 != null)
                {
                    if (lstCond1.Count > 0)
                    {
                        made_query = QueryCondChange2(sQueryID, made_query, lstCond1, isDynamic2);
                    }
                }

                MPCR.SetInMsg(view_in_node);
                view_in_node.ProcStep = '1';
                view_in_node.SetString("STATUS_MSG_FLAG", "Y");

                byte[] bsq = System.Text.Encoding.UTF8.GetBytes(made_query.ToString());
                view_in_node.AddBlob(MPGC.MP_BIN_DATA_1, bsq);
                //view_in_node.AddString("SQL", made_query.ToString());

                do
                {
                    if (multi_Thread == true)
                    {
                        if (CallService_safe("BAS", "BAS_SQL_Query", view_in_node, ref view_out_node) == false)
                        {
                            return null;
                        }
                    }
                    else
                    {
                        if (MPCR.CallService("BAS", "BAS_SQL_Query", view_in_node, ref view_out_node) == false)
                        {
                            return null;
                        }
                    }

                    if (first_flag == true)
                    {

                        _dt = MPCR.ConvertToDataTable(_dt, view_out_node);
                    }
                    else
                    {
                        if (MPCR.ConvertToDataTable(view_out_node) == null)
                        {
                            break;
                        }

                        _dt = MPCR.ConvertToDataTable(view_out_node);
                    }

                    first_flag = true;
                    view_in_node.SetInt("NEXT_ROW", view_out_node.GetInt("NEXT_ROW"));

                } while (view_in_node.GetInt("NEXT_ROW") > 0);

                return _dt;
            }
            catch (Exception ee)
            {
                MPCF.ShowMsgBox(ee.Message);
                return null;
            }
            //finally
            //{
            //    string sQueryStatement = string.Empty;
            //    StringBuilder sbSqlLog = new StringBuilder();
            //    sbSqlLog.Append(made_query.ToString());
            //    sbSqlLog.AppendLine(";"); //쿼리 끝 지점
            //    System.Diagnostics.Trace.WriteLine(sbSqlLog.ToString());
            //    sQueryStatement = sbSqlLog.ToString();
            //    MPGV.gsQueryStatementLong = MPGV.gsQueryStatementLong + "MGetData" + "\r\n" + sQueryStatement + "\r\n"; // 다중 Query문 저장
            //}
        }

        // 시간형식의 문자열을 형식을 제외한 문자열로 변환 리턴.
        public static string DateTimeToString(string s_datetime)
        {
            try
            {
                s_datetime = s_datetime.Replace("-", "");
                s_datetime = s_datetime.Replace(":", "");
                s_datetime = s_datetime.Replace(" ", "");
                s_datetime = s_datetime.Replace("~", "");

                return s_datetime;
            }
            catch (Exception ee)
            {
                MPCF.ShowMsgBox(ee.Message);
                return "";
            }
        }

        public static bool MFillData(object list, bool fit_column_header, string sQueryID, object cndGrp, string[] sCondition, bool isDynamic)
        {
            return MFillData(list, sQueryID, cndGrp, sCondition, -1, fit_column_header, isDynamic, "");
        }
        public static bool MFillData(object list, bool fit_column_header, string sQueryID, object cndGrp, string[] sCondition, int icon_idx, bool isDynamic)
        {
            return MFillData(list, sQueryID, cndGrp, sCondition, icon_idx, fit_column_header, isDynamic, "");
        }

        public static bool MFillData(object list, bool fit_column_header, string sQueryID, object cndGrp, string[] sCondition)
        {
            return MFillData(list, sQueryID, cndGrp, sCondition, -1, fit_column_header, false, "");
        }
        public static bool MFillData(object list, bool fit_column_header, string sQueryID, object cndGrp, string[] sCondition, int icon_idx)
        {
            return MFillData(list, sQueryID, cndGrp, sCondition, icon_idx, fit_column_header, false, "");
        }

        public static bool MFillData(object list, bool fit_column_header, string sQueryID, string[] sCondition, bool isDynamic)
        {
            return MFillData(list, sQueryID, null, sCondition, -1, fit_column_header, isDynamic, "");
        }
        public static bool MFillData(object list, bool fit_column_header, string sQueryID, string[] sCondition, int icon_idx, bool isDynamic)
        {
            return MFillData(list, sQueryID, null, sCondition, icon_idx, fit_column_header, isDynamic, "");
        }

        public static bool MFillData(object list, bool fit_column_header, string sQueryID, string[] sCondition)
        {
            return MFillData(list, sQueryID, null, sCondition, -1, fit_column_header, false, "");
        }
        public static bool MFillData(object list, bool fit_column_header, string sQueryID, string[] sCondition, int icon_idx)
        {
            return MFillData(list, sQueryID, null, sCondition, icon_idx, fit_column_header, false, "");
        }


        //fit header
        public static bool MFillData(object list, string sQueryID, object cndGrp, string[] sCondition, bool isDynamic)
        {
            return MFillData(list, sQueryID, cndGrp, sCondition, -1, false, isDynamic, "");
        }
        public static bool MFillData(object list, string sQueryID, object cndGrp, string[] sCondition, int icon_idx, bool isDynamic)
        {
            return MFillData(list, sQueryID, cndGrp, sCondition, icon_idx, false, isDynamic, "");
        }

        public static bool MFillData(object list, string sQueryID, object cndGrp, string[] sCondition)
        {
            return MFillData(list, sQueryID, cndGrp, sCondition, -1, false, false, "");
        }
        public static bool MFillData(object list, string sQueryID, object cndGrp, string[] sCondition, int icon_idx)
        {
            return MFillData(list, sQueryID, cndGrp, sCondition, icon_idx, false, false, "");
        }

        public static bool MFillData(object list, string sQueryID, string[] sCondition, bool isDynamic)
        {
            return MFillData(list, sQueryID, null, sCondition, -1, false, isDynamic, "");
        }
        public static bool MFillData(object list, string sQueryID, string[] sCondition, int icon_idx, bool isDynamic)
        {
            return MFillData(list, sQueryID, null, sCondition, icon_idx, false, isDynamic, "");
        }

        public static bool MFillData(object list, string sQueryID, string[] sCondition)
        {
            return MFillData(list, sQueryID, null, sCondition, -1, false, false, "");
        }
        public static bool MFillData(object list, string sQueryID, string[] sCondition, int icon_idx)
        {
            return MFillData(list, sQueryID, null, sCondition, icon_idx, false, false, "");
        }

        public static bool MFillData(object list, string sQueryID, object cndGrp, string[] sCondition, int icon_idx, bool fit_column_header, bool isDynamic, string channel)
        {

            TRSNode view_in_node = new TRSNode("sql_view_in_node");
            TRSNode view_out_node = new TRSNode("sql_view_out_node");
            DataTable _dt = new DataTable();

            try
            {
                string sqlquery = GetQueryString(sQueryID);
                if (string.IsNullOrEmpty(sqlquery) == true)
                {
                    return false;
                }

                if (cndGrp != null)
                {
                    ReplaceCondtionToString(cndGrp, ref sqlquery);
                }

                string made_query = QueryCondChange(sQueryID, sqlquery, sCondition, isDynamic);

                MPCR.SetInMsg(view_in_node);
                view_in_node.ProcStep = '1';
                view_in_node.SetString("STATUS_MSG_FLAG", "Y");

                byte[] bsq = System.Text.Encoding.UTF8.GetBytes(made_query.ToString());
                view_in_node.AddBlob(MPGC.MP_BIN_DATA_1, bsq);

                do
                {
                    if (MPCR.CallService("BAS", "BAS_SQL_Query", view_in_node, ref view_out_node) == false)
                    {
                        return false;
                    }

                    MPCR.FillDataView(list, view_out_node, fit_column_header, icon_idx, false);

                    view_in_node.SetInt("NEXT_ROW", view_out_node.GetInt("NEXT_ROW"));

                } while (view_in_node.GetInt("NEXT_ROW") > 0);

                return true;
            }
            catch (Exception ee)
            {
                MPCF.ShowMsgBox(ee.Message);
                return false;
            }

        }

        public static void SetCellType(FarPoint.Win.Spread.FpSpread spread, int iCol, SpreadCellType cellType, float width, bool pbVisible,
            bool isLocked, FarPoint.Win.Spread.CellHorizontalAlignment cellHorizontalAlignment)
        {
            // 변수 초기화
            FarPoint.Win.Spread.CellType.BaseCellType celltype = null;

            // Date Time Format 설정 (로컬컴퓨터 설정에 따라)
            DateTimeFormatInfo dtfInfo = new CultureInfo(CultureInfo.CurrentCulture.Name).DateTimeFormat;

            //Column Width 적용
            spread.Sheets[0].Columns[iCol].Width = width;

            #region 1. Cell Type 설정

            // Cell Type에 대하여(Display Type)
            switch (cellType)
            {
                // Button인 경우
                case SpreadCellType.ButtonCellType:
                    celltype = new FarPoint.Win.Spread.CellType.ButtonCellType();
                    ((FarPoint.Win.Spread.CellType.ButtonCellType)celltype).ButtonColor = Color.LightGray;
                    ((FarPoint.Win.Spread.CellType.ButtonCellType)celltype).Text = "...";
                    break;
                // Check Box인 경우
                case SpreadCellType.CheckBoxCellType:
                    celltype = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                    break;
                // ComboBox인 경우
                case SpreadCellType.ComboBoxCellType:
                    celltype = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    break;
                // ComboBox (수정가능 )인 경우
                case SpreadCellType.ComboBoxEditableCellType:
                    celltype = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    ((FarPoint.Win.Spread.CellType.ComboBoxCellType)celltype).Editable = true;
                    break;
                // Dete 인 경우
                case SpreadCellType.DateCellType:
                    celltype = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                    ((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
                    ((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).UserDefinedFormat = "yyyy-MM-dd"; // "yyyy-MM-dd";
                    ((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).SpinButton = true;
                    break;
                // Time인 경우
                case SpreadCellType.TimeCellType:
                    celltype = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                    ((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
                    ((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).UserDefinedFormat = dtfInfo.LongTimePattern;  // "HH:mm:ss";
                    //((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).UserDefinedFormat = APSGV.gsTimePattern;  // "HH:mm:ss";
                    //((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).UserDefinedFormat = APSGV.gsTimePattern;  // "HH:mm:ss";
                    ((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).SpinButton = true;
                    break;
                // Date Time인 경우
                case SpreadCellType.DateTimeCellType:
                    celltype = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                    //((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
                    ((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
                    ((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).UserDefinedFormat = dtfInfo.ShortDatePattern + " " + dtfInfo.LongTimePattern;    // "yyyy-MM-dd HH:mm:ss";
                    //((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).UserDefinedFormat =
                    //    dtfInfo.ShortDatePattern + " " + dtfInfo.ShortTimePattern;    // "yyyy-MM-dd HH:mm:ss";
                    ((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).SpinButton = true;
                    break;
                // Int인 경우
                case SpreadCellType.IntCellType:
                    celltype = new FarPoint.Win.Spread.CellType.NumberCellType();
                    ((FarPoint.Win.Spread.CellType.NumberCellType)celltype).DecimalPlaces = 0;
                    ((FarPoint.Win.Spread.CellType.NumberCellType)celltype).ShowSeparator = true;
                    ((FarPoint.Win.Spread.CellType.NumberCellType)celltype).MinimumValue = Int32.MinValue;
                    ((FarPoint.Win.Spread.CellType.NumberCellType)celltype).MaximumValue = Int32.MaxValue;
                    break;
                // 소수점 3자리 실수(Number)인 경우
                case SpreadCellType.NumberCellType:
                    celltype = new FarPoint.Win.Spread.CellType.NumberCellType();
                    ((FarPoint.Win.Spread.CellType.NumberCellType)celltype).DecimalPlaces = 3;
                    ((FarPoint.Win.Spread.CellType.NumberCellType)celltype).ShowSeparator = true;
                    break;
                // Text인 경우
                case SpreadCellType.TextCellType:
                // 기타 경우는 Text로 설정
                default:
                    celltype = new FarPoint.Win.Spread.CellType.TextCellType();
                    break;
            }

            #endregion

            // Cell Type 적용
            spread.Sheets[0].Columns[iCol].CellType = celltype;

            // Column Width 적용
            spread.Sheets[0].Columns[iCol].Width = width;

            // column lock 적용
            spread.Sheets[0].Columns[iCol].Locked = isLocked;

            // column visible 적용
            spread.Sheets[0].Columns[iCol].Visible = pbVisible;

            // Horizaontal Align 적용
            spread.Sheets[0].Columns[iCol].HorizontalAlignment = cellHorizontalAlignment;
        }

        public static bool deserializeFromBinary(byte[] _BinaryData, ref DataTable dt)
        {
            BinaryFormatter binFormatter = null;
            MemoryStream memStm = null;
            try
            {
                binFormatter = new BinaryFormatter();
                memStm = new MemoryStream(_BinaryData);
                if (memStm.Length == 0)
                {
                    return false;
                }
                //if (memStm.Length > 134217728)
                //{
                //    MPCF.ShowMsgBox(MPCF.GetMessage(202));
                //    return false;
                //}
                dt = (DataTable)binFormatter.Deserialize(memStm);
                memStm.Dispose();

                // GC.Collect();
                GC.GetTotalMemory(true);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                // GC.Collect();
                GC.GetTotalMemory(true);
                return false;
            }
            finally
            {
                binFormatter = null;
                if (memStm != null)
                {

                    memStm.Dispose();
                    memStm = null;
                }
            }
        }

        public static void DataDecompress(byte[] _BinaryDataZip, ref byte[] _BinaryData, int _BinaryDataLength)
        {
            MemoryStream ms = null;
            GZipStream zipStream = null;
            try
            {
                // Use the newly created memory stream for the decompressed data.
                ms = new MemoryStream(_BinaryDataZip);
                zipStream = new GZipStream(ms, CompressionMode.Decompress);
                _BinaryData = new byte[_BinaryDataLength];
                zipStream.Read(_BinaryData, 0, _BinaryDataLength);
                zipStream.Close();
                ms.Close();
                zipStream.Dispose();
                ms.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
                //MessageBox.Show(ex.Message);
                ////MPCF.ShowMsgBox(ex.Message);
                //return;
            }
            finally
            {
                if (zipStream != null) { zipStream.Close(); zipStream.Dispose(); zipStream = null; }
                if (ms != null) { ms.Close(); ms.Dispose(); ms = null; }
            }
        }

        private static string SetParamType(object sParamValue)
        {
            string sTypeName;

            sTypeName = sParamValue.GetType().Name;

            if (sTypeName == "Int16" || sTypeName == "Int32" || sTypeName == "Int64")
                return "INT";
            else if (sTypeName == "Double")
                return "DOUBLE";
            else if (sTypeName == "Single")
                return "FLOAT";
            else
                return "STRING";
        }

        public static DataTable DGetData(string ViewID, DViewCond[] Cond)
        {
            RPT_SQL_Query_In_Tag _In = new RPT_SQL_Query_In_Tag();
            RPT_SQL_Query_DataTable_Result_Out_Tag _Out = new RPT_SQL_Query_DataTable_Result_Out_Tag();
            DataTable dt = null;
            DataTable dt2 = null;
            byte[] BinaryData = null;
            byte[] BinaryDataZip = null;
            int i = 0;

            string channel = "";
            string sSql = "";
            string[] str = new string[1];
            string s_tmp = "";


            try
            {
                channel = "/" + MPGV.gsSiteID + "/RPTServer";

                if (TPDR.giMaxDataConut > 0)
                {
                    _In.data_1 = TPDR.giMaxDataConut.ToString();
                }
                else
                {
                    _In.data_1 = TPDR.DEFAULT_MAX_DATA_COUNT.ToString();
                }
                _In.view_id = ViewID;
                _In.user_id = MPGV.gsUserID;
                //_In.user_id = "ADMIN";
                _In.h_factory = MPGV.gsFactory;

                if (Cond != null)
                {
                    _In._size_cond_tbl = Cond.Length;
                    _In.cond_tbl = new RPT_SQL_Query_In_Tag_cond_tbl[_In._size_cond_tbl];

                    for (i = 0; i < Cond.Length; i++)
                    {
                        _In.cond_tbl[i] = new RPT_SQL_Query_In_Tag_cond_tbl();
                        _In.cond_tbl[i].cond_id = Cond[i].sCondtion_ID;
                        if (Cond[i].sCondition_Type == "" || Cond[i].sCondition_Type == null)
                        {
                            s_tmp = SetParamType(Cond[i].sCondition_Value);
                            _In.cond_tbl[i].cond_type = s_tmp;
                            if (s_tmp == "STRING")
                                _In.cond_tbl[i].cond = Cond[i].sCondition_Value.ToString();
                            else if (s_tmp == "INT")
                                _In.cond_tbl[i].cond_int = MPCF.ToInt(Cond[i].sCondition_Value);
                            else if (s_tmp == "DOUBLE")
                                _In.cond_tbl[i].cond_dbl = MPCF.ToDbl(Cond[i].sCondition_Value);
                            else
                                _In.cond_tbl[i].cond_float = Convert.ToSingle(Cond[i].sCondition_Value);
                        }
                        else if (Cond[i].sCondition_Type == "TEXT")
                        {
                            _In.cond_tbl[i].cond_type = Cond[i].sCondition_Type;
                            _In.cond_tbl[i].cond = Cond[i].sCondition_Value.ToString();
                            //_In.cond_tbl[i].cond_int = Cond[i].iCondition_Value;
                            //_In.cond_tbl[i].cond_dbl = Cond[i].dCondition_Value;
                            //_In.cond_tbl[i].cond_float = Cond[i].fCondition_Value;
                        }
                        else if (Cond[i].sCondition_Type == "INT")
                        {
                            _In.cond_tbl[i].cond_type = Cond[i].sCondition_Type;
                            _In.cond_tbl[i].cond_int = Cond[i].iCondition_Value;
                            //_In.cond_tbl[i].cond_dbl = Cond[i].dCondition_Value;
                            //_In.cond_tbl[i].cond_float = Cond[i].fCondition_Value;
                        }
                        else if (Cond[i].sCondition_Type == "DOUBLE")
                        {
                            _In.cond_tbl[i].cond_type = Cond[i].sCondition_Type;
                            //_In.cond_tbl[i].cond_int = Cond[i].iCondition_Value;
                            _In.cond_tbl[i].cond_dbl = Cond[i].dCondition_Value;
                            //_In.cond_tbl[i].cond_float = Cond[i].fCondition_Value;
                        }
                        else if (Cond[i].sCondition_Type == "FLOAT")
                        {
                            _In.cond_tbl[i].cond_type = Cond[i].sCondition_Type;
                            //_In.cond_tbl[i].cond_int = Cond[i].iCondition_Value;
                            //_In.cond_tbl[i].cond_dbl = Cond[i].dCondition_Value;
                            _In.cond_tbl[i].cond_float = Cond[i].fCondition_Value;
                        }

                    }
                }
                if (TPDRCaster.RPT_View_Dynamic(_In, ref _Out, channel) == false)
                {
                    //RPTV.gbConnected = false;
                    // Report 서버 죽었을때, 메세지 added by BS CHO 2010.11.15
                    if (MPMH.StatusMessage == "Invalid Channel")
                        throw new Exception("You can't select Report Data. Because Report Server has some Problem. \n Please Contact to MES System Manager.");
                    else
                        throw new Exception(MPMH.StatusMessage);
                }

                //if (MPGV.gsQueryStatementLOGCount >= 30)
                //{
                //    str[0] = "------------------------------------------------------------------------------------------------------";
                //    tmp = MPGV.gsQueryStatementLOG.Split(str, StringSplitOptions.None);

                //    MPGV.gsQueryStatementLOG = "";
                //    for (int k = 2; k < tmp.Length; k++)
                //    {
                //        MPGV.gsQueryStatementLOG += "------------------------------------------------------------------------------------------------------" + tmp[k];
                //    }

                //    MPGV.gsQueryStatementLOG = MPGV.gsQueryStatementLOG + GetSeparatorString(ViewID) + _Out.s_sql_data + "\n\n\n"; // 다중 Query문 저장
                //    MPGV.gsQueryStatementLOGCount = 30;
                //}
                //else
                //{
                //    MPGV.gsQueryStatementLOG = MPGV.gsQueryStatementLOG + GetSeparatorString(ViewID) + _Out.s_sql_data + "\n\n\n"; // 다중 Query문 저장
                //    MPGV.gsQueryStatementLOGCount++;
                //}

                sSql = _Out.s_sql_data;

                // 2017. 04. 24 jhlee add > 쿼리 변수에 변수값 replace 함.
                // 추가 로직이라 문제 발생 시, 삭제해도 관계없음.
                if (Cond != null)
                {
                    for (int k = 0; k < Cond.Length; k++)
                    {
                        if (sSql.Contains(":" + Cond[k].sCondtion_ID) == true)
                        {
                            if (Cond[k].sCondition_Type == "" || Cond[k].sCondition_Type == null || Cond[k].sCondition_Type == "STRING")
                            {
                                sSql = sSql.Replace(":" + Cond[k].sCondtion_ID, "'" + Cond[k].sCondition_Value.ToString() + "'");
                            }
                            else if (Cond[k].sCondition_Type == "Int16" || Cond[k].sCondition_Type == "Int32" || Cond[k].sCondition_Type == "Int64")
                            {
                                sSql = sSql.Replace(":" + Cond[k].sCondtion_ID, Cond[k].iCondition_Value.ToString());
                            }
                            else
                            {
                                sSql = sSql.Replace(":" + Cond[k].sCondtion_ID, Cond[k].sCondition_Value.ToString());
                            }
                        }
                    }
                }

                if (_Out.h_status_value != '0')
                {
                    if (string.IsNullOrEmpty(MPCF.Trim(_Out.h_db_err_msg)))
                    {
                        MPCF.ShowMsgBox(_Out.h_msg);
                    }
                    else
                    {
                        // 2011-11-03 일 변경
                        // 내용 : Transaction(Insert, Delete, Update) 시 영향받는 Row가 0 일때 "SQL_NOT_FOUND" Message 창 Show
                        //        임시로 제거 했음.
                        ////////////////////////////////////////////////////////
                        // 기존 Code===========================================>
                        //MessageBox.Show(_Out.h_db_err_msg);
                        // ====================================================>

                        // 변경 Code===========================================>
                        if (_Out.h_db_err_msg != "SQL_NOT_FOUND")
                        {
                            MPCF.ShowMsgBox(_Out.h_db_err_msg);
                        }
                        // ====================================================>
                    }
                    return dt;
                }
                BinaryDataZip = new byte[_Out.data_count];
                for (i = 0; i < _Out.data_count; i++)
                {
                    BinaryDataZip[i] = (byte)_Out.data_tbl[i].data;
                }

                DataDecompress(BinaryDataZip, ref BinaryData, _Out.binary_length);

                if (deserializeFromBinary(BinaryData, ref dt) == false)
                    return dt;
                // GC.Collect();
                GC.GetTotalMemory(true);
                if (dt == null || dt.Rows.Count <= 0) return dt;
                #region " Next Row - 10000건 이상인 경우 일단 주석처리 필요 시 수정"
                //if (_Out.next_row > 0)
                //{
                //    // Next row 적용 : 데이터가 10000건 이상인 경우 10000건씩 끊어서 가져옴.
                //    // 데이터가 너무 많은 경우 OutOfMemory에러로 인해 데이터를 가져올 수 없음*.
                //    dt2 = null;
                //    _In.next_row = _Out.next_row;
                //    do
                //    {
                //        if (BinaryData != null) { BinaryData.Initialize(); BinaryData = null; }
                //        if (BinaryDataZip != null) { BinaryDataZip.Initialize(); BinaryDataZip = null; }
                //        _Out = new RPT_SQL_Query_DataTable_Result_Out_Tag();
                //        if (TPDRCaster.RPT_SQL_Query_DataTable_Result(_In, ref _Out, channel) == false)
                //        {
                //            MPCF.ShowMsgBox(MPMH.StatusMessage);
                //            return dt2;
                //        }
                //        //2011.02.22 Blocked by BSCHO, 만건이상 조회시 에러 발생되는것 막음
                //        //if (_Out.h_status_value != '0')
                //        //{
                //        //    MessageBox.Show(_Out.h_msg);
                //        //    return null;
                //        //}
                //        BinaryDataZip = new byte[_Out.data_count];
                //        for (i = 0; i < _Out.data_count; i++)
                //        {
                //            BinaryDataZip[i] = (byte)_Out.data_tbl[i].data;
                //        }

                //        DataDecompress(BinaryDataZip, ref BinaryData, _Out.binary_length);

                //        if (deserializeFromBinary(BinaryData, ref dt) == false)
                //        {
                //            return dt2;
                //        }
                //        // GC.Collect();
                //        GC.GetTotalMemory(true);
                //        foreach (DataRow dr in dt2.Rows)
                //        {
                //            dt.Rows.Add(dr.ItemArray);
                //        }
                //        _In.next_row = _Out.next_row;
                //        if (dt2 != null) { dt2.Clear(); dt2.Dispose(); dt2 = null; }
                //    } while (_Out.next_row > 0);
                //}

                _Out.data_tbl = null;
                _Out = null;
                // GC.Collect();
                GC.GetTotalMemory(true);
                return dt;
                #endregion
            }
            catch (Exception ex)
            {
                _Out.data_tbl = null;
                _Out = null;
                // GC.Collect();
                GC.GetTotalMemory(true);
                throw ex;
                //return false;
            }
            finally
            {
                if (BinaryData != null) { BinaryData.Initialize(); BinaryData = null; }
                if (BinaryDataZip != null) { BinaryDataZip.Initialize(); BinaryDataZip = null; }
                if (dt2 != null) { dt2.Dispose(); dt2 = null; }
                TPDR.giMaxDataConut = TPDR.DEFAULT_MAX_DATA_COUNT;
                // GC.Collect();
                GC.GetTotalMemory(true);

                // view query
                //string sQueryStatement = string.Empty;
                //StringBuilder sbSqlLog = new StringBuilder();
                //sbSqlLog.Append(sSql.ToString());
                //sbSqlLog.AppendLine(";"); //쿼리 끝 지점
                //System.Diagnostics.Trace.WriteLine(sbSqlLog.ToString());
                //sQueryStatement = sbSqlLog.ToString();
                //MPGV.gsQueryStatementLong = MPGV.gsQueryStatementLong + "DGetData" + "\r\n" + sQueryStatement + "\r\n"; // 다중 Query문 저장
            }

        }

        public static string ViewLineDesc(string sLine)
        {
            try
            {
                string sDesc = string.Empty;
                TRSNode in_node = new TRSNode("Sql_In");
                TRSNode out_node = new TRSNode("Sql_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                string sql = "SELECT LINE_DESC FROM CWIPLINDEF";
                sql += " WHERE FACTORY = '" + MPGV.gsFactory + "'";
                sql += "   AND LINE_CODE = '" + sLine + "'";

                in_node.AddString("SQL", sql);

                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return string.Empty;
                }

                if (out_node.ListCount > 0)
                {
                    sDesc = MPCF.Trim(out_node.GetList("ROWS")[0].GetList("COLS")[0].GetString("DATA"));
                }

                return sDesc;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return string.Empty;
            }
        }

        public static string ViewShopDesc(string sShop)
        {
            try
            {
                string sDesc = string.Empty;
                TRSNode in_node = new TRSNode("Sql_In");
                TRSNode out_node = new TRSNode("Sql_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                string sql = "SELECT SHOP_DESC FROM CWIPSHPDEF";
                sql += " WHERE FACTORY = '" + MPGV.gsFactory + "'";
                sql += "   AND SHOP_CODE = '" + sShop + "'";

                in_node.AddString("SQL", sql);

                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return string.Empty;
                }

                if (out_node.ListCount > 0)
                {
                    sDesc = MPCF.Trim(out_node.GetList("ROWS")[0].GetList("COLS")[0].GetString("DATA"));
                }

                return sDesc;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// View Work Date
        /// </summary>
        /// <param name="sMatID"> </param>
        /// <returns></returns>
        public static string GetWorkDate()
        {
            try
            {
                string sWorkDate = string.Empty;

                TRSNode in_node = new TRSNode("Sql_In");
                TRSNode out_node = new TRSNode("Sql_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                string sql = "SELECT TO_CHAR(SYSDATE - (SUBSTR(SHIFT_1_START,1,2) / 24) - (SUBSTR(SHIFT_1_START,3,2) / 24 / 60), 'YYYYMMDD') AS WORK_DATE FROM MWIPFACDEF";
                sql += " WHERE FACTORY = '" + MPGV.gsFactory + "'";


                in_node.AddString("SQL", sql);

                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return sWorkDate;
                }

                if (out_node.ListCount > 0)
                {
                    sWorkDate = MPCF.Trim(out_node.GetList("ROWS")[0].GetList("COLS")[0].GetString("DATA"));
                }

                return sWorkDate;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return string.Empty;
            }
        }

        /// <summary>  날짜사이의시간간격의숫자를반환합니다.
        /// </summary>
        /// <param name="Interval">y-m-d h:n:s:ms</param>
        /// <param name="Date1"></param>
        /// <param name="Date2"></param>
        /// <returns></returns>
        public static double GetDateDiff(string Interval, DateTime Date1, DateTime Date2)
        {
            double diff = 0;
            TimeSpan ts = Date2 - Date1;

            switch (Interval.ToLower())
            {
                case "y":
                    ts = DateTime.Parse(Date2.ToString("yyyy-01-01")) - DateTime.Parse(Date1.ToString("yyyy-01-01"));
                    diff = Convert.ToDouble(ts.TotalDays / 365);
                    break;
                case "m":
                    ts = DateTime.Parse(Date2.ToString("yyyy-MM-01")) - DateTime.Parse(Date1.ToString("yyyy-MM-01"));
                    diff = Convert.ToDouble((ts.TotalDays / 365) * 12);
                    break;
                case "d":
                    ts = DateTime.Parse(Date2.ToString("yyyy-MM-dd")) - DateTime.Parse(Date1.ToString("yyyy-MM-dd"));
                    diff = ts.Days;
                    break;
                case "h":
                    ts = DateTime.Parse(Date2.ToString("yyyy-MM-dd HH:00:00")) - DateTime.Parse(Date1.ToString("yyyy-MM-dd HH:00:00"));
                    diff = ts.TotalHours;
                    break;
                case "n":
                    ts = DateTime.Parse(Date2.ToString("yyyy-MM-dd HH:mm:00")) - DateTime.Parse(Date1.ToString("yyyy-MM-dd HH:mm:00"));
                    diff = ts.TotalMinutes;
                    break;
                case "s":
                    ts = DateTime.Parse(Date2.ToString("yyyy-MM-dd HH:mm:ss")) - DateTime.Parse(Date1.ToString("yyyy-MM-dd HH:mm:ss"));
                    diff = ts.TotalSeconds;
                    break;
                case "ms":
                    diff = ts.TotalMilliseconds;
                    break;
            }
            return diff;
        }

        /// <summary>
        /// GCM Data View
        /// </summary>
        /// <param name="sTableName">GCM Table Name</param>
        /// <param name="Data Value">  View Data Value</param>
        /// <param name="sKey1~10">  GCM Key Value</param>
        /// <returns></returns>

        public static string ViewGCMDesc(string sTableName, int iData_Value, string s_Key1)
        {
            return ViewGCMDesc(sTableName, iData_Value, s_Key1, "");
        }
        public static string ViewGCMDesc(string sTableName, int iData_Value, string s_Key1, string s_Key2)
        {
            return ViewGCMDesc(sTableName, iData_Value, s_Key1, s_Key2, "");
        }
        public static string ViewGCMDesc(string sTableName, int iData_Value, string s_Key1, string s_Key2, string s_Key3)
        {
            return ViewGCMDesc(sTableName, iData_Value, s_Key1, s_Key2, s_Key3, "");
        }
        public static string ViewGCMDesc(string sTableName, int iData_Value, string s_Key1, string s_Key2, string s_Key3, string s_Key4)
        {
            return ViewGCMDesc(sTableName, iData_Value, s_Key1, s_Key2, s_Key3, s_Key4, "");
        }
        public static string ViewGCMDesc(string sTableName, int iData_Value, string s_Key1, string s_Key2, string s_Key3, string s_Key4, string s_Key5)
        {
            return ViewGCMDesc(sTableName, iData_Value, s_Key1, s_Key2, s_Key3, s_Key4, s_Key5, "");
        }
        public static string ViewGCMDesc(string sTableName, int iData_Value, string s_Key1, string s_Key2, string s_Key3, string s_Key4, string s_Key5, string s_Key6)
        {
            return ViewGCMDesc(sTableName, iData_Value, s_Key1, s_Key2, s_Key3, s_Key4, s_Key5, s_Key6, "");
        }
        public static string ViewGCMDesc(string sTableName, int iData_Value, string s_Key1, string s_Key2, string s_Key3, string s_Key4, string s_Key5, string s_Key6, string s_Key7)
        {
            return ViewGCMDesc(sTableName, iData_Value, s_Key1, s_Key2, s_Key3, s_Key4, s_Key5, s_Key6, s_Key7, "");
        }
        public static string ViewGCMDesc(string sTableName, int iData_Value, string s_Key1, string s_Key2, string s_Key3, string s_Key4, string s_Key5, string s_Key6, string s_Key7, string s_Key8)
        {
            return ViewGCMDesc(sTableName, iData_Value, s_Key1, s_Key2, s_Key3, s_Key4, s_Key5, s_Key6, s_Key7, s_Key8, "");
        }
        public static string ViewGCMDesc(string sTableName, int iData_Value, string s_Key1, string s_Key2, string s_Key3, string s_Key4, string s_Key5, string s_Key6, string s_Key7, string s_Key8, string s_Key9)
        {
            return ViewGCMDesc(sTableName, iData_Value, s_Key1, s_Key2, s_Key3, s_Key4, s_Key5, s_Key6, s_Key7, s_Key8, s_Key9, "");
        }
        public static string ViewGCMDesc(string sTableName, int iData_Value, string s_Key1, string s_key2, string s_Key3, string s_Key4, string s_Key5, string s_Key6, string s_Key7, string s_Key8, string s_Key9, string s_Key10)
        {
            try
            {

                string sDesc = string.Empty;
                TRSNode in_node = new TRSNode("BAS_View_Data_In");
                TRSNode out_node = new TRSNode("BAS_View_Data_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(sTableName));
                in_node.AddString("KEY_1", MPCF.Trim(s_Key1));
                in_node.AddString("KEY_2", MPCF.Trim(s_key2));
                in_node.AddString("KEY_3", MPCF.Trim(s_Key3));
                in_node.AddString("KEY_4", MPCF.Trim(s_Key4));
                in_node.AddString("KEY_5", MPCF.Trim(s_Key5));
                in_node.AddString("KEY_6", MPCF.Trim(s_Key6));
                in_node.AddString("KEY_7", MPCF.Trim(s_Key7));
                in_node.AddString("KEY_8", MPCF.Trim(s_Key8));
                in_node.AddString("KEY_9", MPCF.Trim(s_Key9));
                in_node.AddString("KEY_10", MPCF.Trim(s_Key10));

                if (MPCR.CallService("BAS", "BAS_View_Data", in_node, ref out_node) == false)
                {
                    return string.Empty;
                }

                switch (iData_Value)
                {
                    case 1:
                        sDesc = out_node.GetString("DATA_1");

                        break;

                    case 2:
                        sDesc = out_node.GetString("DATA_2");

                        break;

                    case 3:
                        sDesc = out_node.GetString("DATA_3");

                        break;

                    case 4:
                        sDesc = out_node.GetString("DATA_4");

                        break;

                    case 5:
                        sDesc = out_node.GetString("DATA_5");

                        break;

                    case 6:
                        sDesc = out_node.GetString("DATA_6");

                        break;

                    case 7:
                        sDesc = out_node.GetString("DATA_7");

                        break;

                    case 8:
                        sDesc = out_node.GetString("DATA_8");

                        break;

                    case 9:
                        sDesc = out_node.GetString("DATA_9");

                        break;

                    case 10:
                        sDesc = out_node.GetString("DATA_10");
                        break;
                }

                return sDesc;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return string.Empty;
            }
        }


        public static string FindLanguage(string sKey)
        {
            string sRtnString = sKey;

            try
            {
                if (string.IsNullOrEmpty(sKey)) return sKey;

                sRtnString = MPCF.FindLanguage(sKey, 0);
                return sRtnString;
            }

            catch
            {
                return sRtnString;
            }
        }

        /// <summary>
        /// Form에 있는 모든 컨트롤의 언어를 변경합니다.
        /// </summary>
        /// <param name="control"></param>
        public static void ConvertCaption(Control ctrl)
        {
            // form에 해당하는 전체 컨트롤의 수
            int i_child_count = ctrl.Controls.Count;

            // 해당 컨트롤 다국어 변경            
            if (ConvertControlCaption(ctrl) == false)
            {
                // 해당 컨트롤의 Child Control에 다국어를 적용하지 않는 경우
                return;
            }

            for (int i = 0; i < i_child_count; i++)
            {
                Control childControl = ctrl.Controls[i];

                if (childControl.Controls.Count > 0)
                {
                    // 재귀함수
                    ConvertCaption(childControl);
                }
                else
                {
                    // 변경
                    ConvertControlCaption(childControl);
                }
            }
        }


        /// <summary>
        /// Convert Control Caption
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private static bool ConvertControlCaption(Control control)
        {
            try
            {
                if (control is Label)
                {
                    ((Label)control).Text = FindLanguage(((Label)control).Text);
                }
                else if (control is Button)
                {
                    ((Button)control).Text = FindLanguage(((Button)control).Text);
                }
                else if (control is RadioButton)
                {
                    ((RadioButton)control).Text = FindLanguage(((RadioButton)control).Text);
                }
                else if (control is CheckBox)
                {
                    ((CheckBox)control).Text = FindLanguage(((CheckBox)control).Text);
                }
                else if (control is GroupBox)
                {
                    ((GroupBox)control).Text = FindLanguage(((GroupBox)control).Text);
                }
                else if (control is TabPage)
                {
                    control.Text = FindLanguage(control.Text);
                }
                else if (control is SOIButton)
                {
                    ((SOIButton)control).Text = FindLanguage(((SOIButton)control).Text);
                }
                else if (control is SOIButtonImage)
                {
                    ((SOIButtonImage)control).Text = FindLanguage(((SOIButtonImage)control).Text);
                }
                else if (control is SOICheckBox)
                {
                    ((SOICheckBox)control).Text = FindLanguage(((SOICheckBox)control).Text);
                }
                else if (control is SOICheckBoxOnOff)
                {
                    if (((SOICheckBoxOnOff)control)._UseConvertLanguage == true)
                    {
                        ((SOICheckBoxOnOff)control).OnStateText = FindLanguage(((SOICheckBoxOnOff)control).OnStateText);
                        ((SOICheckBoxOnOff)control).OffStateText = FindLanguage(((SOICheckBoxOnOff)control).OffStateText);
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (control is SOIRadioButton)
                {
                    if (((SOIRadioButton)control)._UseConvertLanguage == true)
                    {
                        if (((SOIRadioButton)control).Items.Count > 0)
                        {
                            for (int i = 0; i < ((SOIRadioButton)control).Items.Count; i++)
                            {
                                ((SOIRadioButton)control).Items[i].DisplayText = FindLanguage(((SOIRadioButton)control).Items[i].DisplayText);
                            }

                        }
                    }
                }
                else if (control is SOILabel)
                {
                    if (((SOILabel)control)._UseConvertLanguage == true)
                    {
                        ((SOILabel)control).Text = FindLanguage(((SOILabel)control).Text);
                    }
                }
                else if (control is SOITextBoxValue)
                {
                    if (((SOITextBoxValue)control)._UseConvertLanguage == true)
                    {
                        ((SOITextBoxValue)control).Text = FindLanguage(((SOITextBoxValue)control).Text);
                    }
                }
                else if (control is SOICodeViewDescription)
                {
                    if (((SOICodeViewDescription)control)._UseConvertLanguageCode == true)
                    {
                        ((SOICodeViewDescription)control).Code = FindLanguage(((SOICodeViewDescription)control).Code);
                    }
                    if (((SOICodeViewDescription)control)._UseConvertLanguageDesc == true)
                    {
                        ((SOICodeViewDescription)control).Description = FindLanguage(((SOICodeViewDescription)control).Description);
                    }
                }
                //else if (control is SOIListBox)
                //{
                //    if (((SOIListBox)control)._UseConvertLanguage == true)
                //    {
                //        if (((SOIListBox)control).Rows.Count > 0)
                //        {
                //            if (((SOIListBox)control).DisplayLayout != null
                //                && ((SOIListBox)control).DisplayLayout.Bands.Count > 0
                //                && ((SOIListBox)control).DisplayLayout.Bands[0] != null
                //                && ((SOIListBox)control).DisplayLayout.Bands[0].Columns != null
                //                && ((SOIListBox)control).DisplayLayout.Bands[0].Columns.Count > 0)
                //            {
                //                for (int i = 0; i < ((SOIListBox)control).DisplayLayout.Bands[0].Columns.Count; i++)
                //                {
                //                    if (((SOIListBox)control).DisplayLayout.Bands[0].Columns[i].DataType == typeof(string))
                //                    {
                //                        for (int j = 0; j < ((SOIListBox)control).Rows.Count; j++)
                //                        {
                //                            if (((SOIListBox)control).Rows[j].Cells[i].Value != null)
                //                            {
                //                                ((SOIListBox)control).Rows[j].Cells[i].Value = FindLanguage(((SOIListBox)control).Rows[j].Cells[i].Value.ToString());
                //                            }
                //                        }
                //                    }
                //                }
                //            }
                //        }
                //    }
                //}
                else if (control is SOIGroupBox)
                {
                    ((SOIGroupBox)control).Text = FindLanguage(((SOIGroupBox)control).Text); // Header Title
                }
                else if (control is SOITabControl)
                {
                    if (((SOITabControl)control)._UseConvertLanguage == true)
                    {
                        if (((SOITabControl)control).Tabs.Count > 0)
                        {
                            for (int i = 0; i < ((SOITabControl)control).Tabs.Count; i++)
                            {
                                ((SOITabControl)control).Tabs[i].Text = FindLanguage(((SOITabControl)control).Tabs[i].Text);

                                //// Tabs 아이템의 한글 Font가 자동으로 "굴림"체로 변경되는 문제점을 수정하기 위한 구문
                                //((SOITabControl)control).Tabs[i].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                                //((SOITabControl)control).Tabs[i].Appearance.FontData.Name = "Malgun Gothic";
                            }
                        }
                    }
                }
                else if (control is SOIButtonImageViewer)
                {
                    ((SOIButtonImageViewer)control).Text = FindLanguage(((SOIButtonImageViewer)control).Text);
                }
                else if (control is SOIButtonPDFView)
                {
                    ((SOIButtonPDFView)control).Text = FindLanguage(((SOIButtonPDFView)control).Text);
                }
                else if (control is SOIButtonImportExcel)
                {
                    ((SOIButtonImportExcel)control).Text = FindLanguage(((SOIButtonImportExcel)control).Text);
                }
                else if (control is SOIButtonExportExcel)
                {
                    ((SOIButtonExportExcel)control).Text = FindLanguage(((SOIButtonExportExcel)control).Text);
                }
                else if (control is SOIButtonPrintOption)
                {
                    ((SOIButtonPrintOption)control).Text = FindLanguage(((SOIButtonPrintOption)control).Text);
                }
                //else if (control is SOIGrid)
                //{
                //    if (((SOIGrid)control).DisplayLayout.Bands[0].Columns.Count > 0)
                //    {
                //        for (int i = 0; i < ((SOIGrid)control).DisplayLayout.Bands[0].Columns.Count; i++)
                //        {
                //            ((SOIGrid)control).DisplayLayout.Bands[0].Columns[i].Header.Caption = FindLanguage(((SOIGrid)control).DisplayLayout.Bands[0].Columns[i].Header.Caption);
                //        }
                //    }
                //}
                else if (control is FpSpread || control is SOISpread)
                {
                    if (((FpSpread)control).Tag != null)
                    {
                        // No Converting
                        if (CMNF.Trim(((FpSpread)control).Tag) == "Header No Change")
                        {
                            return true;
                        }
                        // Only Cell Change
                        else if (CMNF.Trim(((FpSpread)control).Tag) == "Change Cell")
                        {
                            for (int j = 0; j < ((FpSpread)control).ActiveSheet.RowCount; j++)
                            {
                                for (int i = 0; i < ((FpSpread)control).ActiveSheet.ColumnCount; i++)
                                {
                                    if (CMNF.Trim(((FpSpread)control).ActiveSheet.Cells[j, i].Value) != "")
                                    {
                                        ((FpSpread)control).ActiveSheet.Cells[j, i].Value = FindLanguage(CMNF.Trim(((FpSpread)control).ActiveSheet.Cells[j, i].Value));
                                    }
                                }
                            }
                        }
                    }
                    // Header Change
                    else
                    {
                        for (int j = 0; j < ((FpSpread)control).ActiveSheet.ColumnHeader.RowCount; j++)
                        {
                            for (int i = 0; i < ((FpSpread)control).ActiveSheet.ColumnHeader.Columns.Count; i++)
                            {
                                if (CMNF.Trim(((FpSpread)control).ActiveSheet.ColumnHeader.Cells[j, i].Value) != "")
                                {
                                    ((FpSpread)control).ActiveSheet.ColumnHeader.Cells[j, i].Value = FindLanguage(CMNF.Trim(((FpSpread)control).ActiveSheet.ColumnHeader.Cells[j, i].Value));
                                }
                            }
                        }
                        for (int j = 0; j < ((FpSpread)control).ActiveSheet.RowHeader.Rows.Count; j++)
                        {
                            for (int i = 0; i < ((FpSpread)control).ActiveSheet.RowHeader.ColumnCount; i++)
                            {
                                if (CMNF.Trim(((FpSpread)control).ActiveSheet.RowHeader.Cells[j, i].Value) != "")
                                {
                                    ((FpSpread)control).ActiveSheet.RowHeader.Cells[j, i].Value = FindLanguage(CMNF.Trim(((FpSpread)control).ActiveSheet.RowHeader.Cells[j, i].Value));
                                }
                            }
                        }
                    }
                }
                //else if (control is SOIChart)
                //{
                //    if (((SOIChart)control).GetDataSource() != null)
                //    {
                //        foreach (DataColumn dc in ((SOIChart)control).GetDataSource().Columns)
                //        {
                //            dc.ColumnName = FindLanguage(dc.ColumnName);
                //        }
                //    }
                //}

                return true;
            }
            catch (Exception ex)
            {
                ShowMessage("ConvertCaption()\n" + ex.Message, MSSAG_LEVEL.ERROR, true);
                return false;
            }
        }

        public static void ShowMessage(string message, MSSAG_LEVEL msgLevel, bool IsPopup)
        {
            // Popup 창인 경우
            if (IsPopup)
            {
                ShowMsgBox(message, MessageBoxButtons.OK, msgLevel, "");
            }
            else
            {

            }
        }

        /// <summary>
        /// Message Box를 표시합니다.
        /// Message Bar에는 메시지를 표시하지 않습니다.
        /// Error 메시지로 표현하고 OK버튼만 가지고 있습니다.
        /// 주로, 사용자에게 에러 상태를 표현할 때 사용합니다.
        /// </summary>
        /// <param name="message"></param>
        public new static DialogResult ShowMsgBox(string message)
        {
            return ShowMsgBox(message, MessageBoxButtons.OK, MSSAG_LEVEL.ERROR, "");
        }

        /// <summary>
        /// Message Box를 표시합니다.
        /// Message Bar에는 메시지를 표시하지 않습니다.
        /// 제목이 없는 None 메시지로 표현하고 버튼을 할당할 수 있습니다.
        /// 주로,  사용자에게 묻는 메시지(Yes/No, Ok/Cancel)를 표현할 때 사용합니다.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="button"></param>
        public new static DialogResult ShowMsgBox(string message, MessageBoxButtons button)
        {
            return ShowMsgBox(message, button, MSSAG_LEVEL.NONE, "");
        }

        /// <summary>
        /// Message Box를 표시합니다.
        /// Message Bar에는 메시지를 표시하지 않습니다.
        /// 메시지 레벨을 직접 설정하고 버튼을 직접 할당합니다.
        /// 필요에 따라 사용합니다.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="msgLevel"></param>
        /// <param name="caption"></param>
        /// <param name="button"></param>
        /// <returns></returns>
        public new static DialogResult ShowMsgBox(string message, MessageBoxButtons button, MSSAG_LEVEL msgLevel)
        {
            return ShowMsgBox(message, button, msgLevel, "");
        }

        public static DialogResult ShowMsgBox(string message, MessageBoxButtons button, MSSAG_LEVEL msgLevel, string caption)
        {
            SOI.OIFrx.frmMessageBox frm = new SOI.OIFrx.frmMessageBox();

            frm.SetButtonType(button);
            frm.SetMsgLevel(msgLevel, caption);
            frm.SetMessage(message);

            frm.Left = (MPGV.gfrmMDI.Left + (MPGV.gfrmMDI.Width / 2) - (frm.Width / 2));
            frm.Top = (MPGV.gfrmMDI.Top + (MPGV.gfrmMDI.Height / 2) - (frm.Height / 2));

            //this.StartPosition = FormStartPosition.CenterParent;

            return frm.ShowDialog();
        }

        /// <summary>
        /// Message Box를 표시합니다.
        /// Message Bar에는 메시지를 표시하지 않습니다.
        /// 메시지 레벨, 버튼, 제목을 직접 할당합니다.
        /// Message Box를 Show로 실행합니다. 메시지 박스가 종료되지 않더라도 프로그램이 실행됩니다.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="msgLevel"></param>
        /// <param name="caption"></param>
        /// <param name="button"></param>
        /// <returns></returns>
        public static void ShowMsgBox(string message, MessageBoxButtons button, MSSAG_LEVEL msgLevel, string caption, bool show)
        {
            SOI.OIFrx.frmMessageBox frm = new SOI.OIFrx.frmMessageBox();

            frm.SetButtonType(button);
            frm.SetMsgLevel(msgLevel, caption);
            frm.SetMessage(message);

            frm.Show();
        }

        public new static string Trim(object str)
        {
            try
            {
                // null인 경우
                if (str == null)
                {
                    return "";
                }

                string sTemp = Convert.ToString(str);

                // Empty인 경우
                if (string.IsNullOrEmpty(sTemp) == true)
                {
                    return "";
                }
                else
                {
                    return sTemp.Trim();
                }
            }
            catch (Exception Ex)
            {
                MPOF.ShowErrorMessage(Ex.Message + " Trim");
                return "";
            }
        }

        /// <summary>
        /// Control에 한영키및 대문자 Casting
        /// </summary>
        /// <param name="control"></param>
        public static void ImeMode(Control control, ImeMode immode, CharacterCasing charcasing)
        {
            if (control is SOI.OIFrx.SOIControls.SOITextBox)
            {
                ((SOITextBox)control).ImeMode = immode;
                ((SOITextBox)control).CharacterCasing = charcasing;
            }
            else if (control is TextBox)
            {
                ((TextBox)control).ImeMode = immode;
                ((TextBox)control).CharacterCasing = charcasing;
            }
        }

        /// <summary>
        ///  Valid FIFO
        /// </summary>
        /// <param name="sLabelID">Input Label Id</param>
        /// <param name="sInvAcct"> 문류계정</param>
        /// <returns></returns>
        public static string Valid_FIFO(char cStep, string sLabelId, string sInvAcct)
        {
            try
            {
                string sPreLabelID = string.Empty;
                TRSNode in_node = new TRSNode("VALID_FIFO_In");
                TRSNode out_node = new TRSNode("VALID_FIFO_Out");

                /// cStep = 1 : FIFO Check
                /// cStep = 2 : FIFO Uncheck

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = cStep;
                in_node.AddString("LABEL_ID", MPCF.Trim(sLabelId));
                in_node.AddString("INV_ACCT", MPCF.Trim(sInvAcct));
                if (MPCR.CallService("IWIP", "IWIP_Valid_FIFO", in_node, ref out_node) == false)
                {
                    sPreLabelID = out_node.GetString("RECV_DATE") + "/" + out_node.GetString("PRE_LABEL_ID");
                    return sPreLabelID;
                }

                return sPreLabelID;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return string.Empty;
            }
        }


        // 6자리 문자열을 date 형태로 변환 리턴
        public static string Convstr6ToDateTime(String lsStr8)
        {
            lsStr8 = (lsStr8.Substring(0, 4) + "-" +
                lsStr8.Substring(4, 2));

            return lsStr8;
        }

        // 8자리 문자열을 date 형태로 변환 리턴
        public static string Convstr8ToDateTime(String lsStr8)
        {
            lsStr8 = (lsStr8.Substring(0, 4) + "-" +
                lsStr8.Substring(4, 2) + "-" +
                lsStr8.Substring(6, 2));

            return lsStr8;
        }

        // 12자리 문자열을 datetime 형태로 변환 리턴
        public static string Convstr12ToDateTime(String lsStr12)
        {
            lsStr12 = (lsStr12.Substring(0, 4) + "-" +
                lsStr12.Substring(4, 2) + "-" +
                lsStr12.Substring(6, 2) + " " +
                lsStr12.Substring(8, 2) + ":" +
                lsStr12.Substring(10, 2));

            return lsStr12;
        }

        // 14자리 문자열을 datetime 형태로 변환 리턴
        public static string Convstr14ToDateTime(String lsStr14)
        {
            lsStr14 = (lsStr14.Substring(0, 4) + "-" +
                lsStr14.Substring(4, 2) + "-" +
                lsStr14.Substring(6, 2) + " " +
                lsStr14.Substring(8, 2) + ":" +
                lsStr14.Substring(10, 2) + ":" +
                lsStr14.Substring(12, 2));

            return lsStr14;
        }

        // PlaySound()
        //       - Choice sound type and sound sync
        // Return Value
        //       - 
        // Arguments
        //       - ByVal iSoundType As int : sound type : MP_MSG_TYPE
        //       - ByVal uFlags As int : SND_SYNC = 0x0 / SND_ASYNC = 0x1
        //
        // PlaySound()
        //       - Choice sound type and sound sync
        // Return Value
        //       - 
        // Arguments
        //       - ByVal iSoundType As int : sound type : MP_MSG_TYPE
        //
        public static void PlaySound(int iSoundType)
        {
            int uFlags = SND_ASYNC;
            int intCtr;
            string sSoundPath = "";

            if (iSoundType == (int)MP_MSG_TYPE.TYPE_INFO)
            {
                return;
            }

            if (IsSoundSupported())
            {
                if (iSoundType == (int)MP_MSG_TYPE.TYPE_SUCCESS)
                {
                    sSoundPath = MP_SUCCESS_SOUND_FILE;
                }
                else if (iSoundType == (int)MP_MSG_TYPE.TYPE_ERROR)
                {
                    sSoundPath = MP_FAIL_SOUND_FILE;
                }
                else if (iSoundType == (int)MP_MSG_TYPE.TYPE_WARN)
                {
                    sSoundPath = MP_WARN_SOUND_FILE;
                }

                if (!System.IO.File.Exists(Application.StartupPath + "\\" + sSoundPath))
                {
                    return;
                }

                sndPlaySoundA(sSoundPath, uFlags);

            }
            else
            {
                for (intCtr = 0; intCtr < 2; intCtr++)
                {
                    Console.Beep();
                }
            }
        }

        // PlaySound()
        //       - Choice sound type and sound sync
        // Return Value
        //       - 
        // Arguments
        //       - ByVal iSoundType As int : sound type : MP_MSG_TYPE
        //       - ByVal uFlags As int : SND_SYNC = 0x0 / SND_ASYNC = 0x1
        //
        public static void PlaySound(int iSoundType, int uFlags)
        {
            int intCtr;
            string sSoundPath = "";

            if (iSoundType == (int)MP_MSG_TYPE.TYPE_INFO)
            {
                return;
            }

            if (IsSoundSupported())
            {
                if (iSoundType == (int)MP_MSG_TYPE.TYPE_SUCCESS)
                {
                    sSoundPath = MP_SUCCESS_SOUND_FILE;
                }
                else if (iSoundType == (int)MP_MSG_TYPE.TYPE_ERROR)
                {
                    sSoundPath = MP_FAIL_SOUND_FILE;
                }
                else if (iSoundType == (int)MP_MSG_TYPE.TYPE_WARN)
                {
                    sSoundPath = MP_WARN_SOUND_FILE;
                }

                if (!System.IO.File.Exists(Application.StartupPath + "\\" + sSoundPath))
                {
                    return;
                }

                sndPlaySoundA(sSoundPath, uFlags);

            }
            else
            {
                for (intCtr = 0; intCtr < 2; intCtr++)
                {
                    Console.Beep();
                }
            }
        }

        // GetShopDesc()
        //       - Choice sound type and sound sync
        // Return Value
        //       - 
        // Arguments
        //       - string : Shop
        //
        public static string GetShopDesc(string sShop)
        {
            try
            {
                DataTable _dt = new DataTable();

                _dt = HQCF.MGetData("BAS_View_Shop_List", new string[] { MPCF.Trim(sShop) });
                if (_dt.Rows.Count < 0.5)
                {
                    return "";
                }

                return _dt.Rows[0]["SHOP_DESC"].ToString();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return "";
            }
            
        }

        // GetLineDesc()
        //       - Choice sound type and sound sync
        // Return Value
        //       - 
        // Arguments
        //       - string : Shop
        //
        public static string GetLineDesc(string sShop, string sLine)
        {
            try
            {
                DataTable _dt = new DataTable();

                _dt = HQCF.MGetData("BAS_View_Line_List", new string[] {MPCF.Trim(sLine) , MPCF.Trim(sShop)});
                if (_dt.Rows.Count < 0.5)
                {
                    return "";
                }

                return _dt.Rows[0]["LINE_DESC"].ToString();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return "";
            }

        }

        // GetLineWorkGroup()
        //       - Choice sound type and sound sync
        // Return Value
        //       - 
        // Arguments
        //       - string : Shop
        //
        public static string GetLineWorkGroup(string sShop, string sLine)
        {
            try
            {
                DataTable _dt = new DataTable();

                _dt = HQCF.MGetData("BAS_View_Line_List", new string[] { MPCF.Trim(sLine), MPCF.Trim(sShop) });
                if (_dt.Rows.Count < 0.5)
                {
                    return "";
                }

                return _dt.Rows[0]["WORK_GROUP"].ToString();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return "";
            }

        }

        // ViewMixDocument()
        //       - View Mix Document
        // Return Value
        //       - 
        // Arguments
        //       - string : sBatchQty
        //       - string : sSerialNo
        public static bool ViewMixDocument(string sBatchQty, string sSerialNo)
        {
            try
            {
                string sTitle = null;
                string sURL1 = null;
                string sURL2 = null;
                string sURL3 = null;

                if (string.IsNullOrEmpty(MPGV.gsFactory) || string.IsNullOrEmpty(sBatchQty) || string.IsNullOrEmpty(sSerialNo))
                    return false;

                // 1. get interface path of mix document
                DataTable dt = HQCF.MGetData("ICOM0000-35", new string[] { MPGV.gsFactory, "CCOM_IF_URL", "MIX_DOC" });

                if (dt.Rows.Count <= 0)
                {
                    sURL1 = string.Empty;
                    sURL2 = string.Empty;
                    sURL3 = string.Empty;
                    return false;
                }

                sTitle = dt.Rows[0][0].ToString();
                sURL1 = dt.Rows[0][1].ToString();
                sURL2 = dt.Rows[0][2].ToString();
                sURL3 = dt.Rows[0][3].ToString();

                // 2. call web client
                using (WebClient webClient = new WebClient())
                {
                    System.Diagnostics.Process.Start(sURL1 + "?NO=" + sSerialNo + "&KG=" + sBatchQty);
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        // ViewMixDocumentByMatID()
        //       - View Mix Document By Material ID
        // Return Value
        //       - 
        // Arguments
        //       - string : sFactory
        //       - string : sMatID
        public static bool ViewMixDocumentByMatID(string sFactory, string sMatID)
        {
            try
            {
                string sTitle = null;
                string sURL1 = null;
                string sURL2 = null;
                string sURL3 = null;
                string sSerialNo = string.Empty;
                string sBatchQty = string.Empty;

                if (string.IsNullOrEmpty(MPGV.gsFactory) || string.IsNullOrEmpty(sFactory) || string.IsNullOrEmpty(sMatID))
                    return false;

                // 1. get interface path of mix document
                DataTable dt = HQCF.MGetData("ICOM0000-35", new string[] { MPGV.gsFactory, "CCOM_IF_URL", "MIX_DOC" });

                if (dt.Rows.Count <= 0)
                {
                    sURL1 = string.Empty;
                    sURL2 = string.Empty;
                    sURL3 = string.Empty;
                    return false;
                }

                sTitle = dt.Rows[0][0].ToString();
                sURL1 = dt.Rows[0][1].ToString();
                sURL2 = dt.Rows[0][2].ToString();
                sURL3 = dt.Rows[0][3].ToString();

                // 2. get Serial No & Batch Qty
                DataTable dt2 = null;
                string s_column = "";
                TPDR.DirectViewCond[] args = new TPDR.DirectViewCond[2];
                args[0].sCondtion_ID = "FACTORY";
                args[0].sCondition_Value = sFactory;
                args[1].sCondtion_ID = "MAT_ID";
                args[1].sCondition_Value = sMatID;

                if (TPDR.GetDataOne(s_column, ref dt2, "CBOM2001-02", args, false, false) == false)
                {
                    if (dt2 != null)
                        dt2.Dispose();

                    GC.Collect();

                    return false;
                }

                if (dt2 == null || dt2.Rows.Count < 1) return false;

                sSerialNo = dt2.Rows[0][0].ToString();
                sBatchQty = dt2.Rows[0][1].ToString();
                 
                // 3. call web client
                using (WebClient webClient = new WebClient())
                {
                    System.Diagnostics.Process.Start(sURL1 + "?NO=" + sSerialNo + "&KG=" + sBatchQty);
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }


        // ViewProductDrawing()
        //       - View Product Drawing
        // Return Value
        //       - 
        // Arguments
        //       - string : sFactory
        //       - string : sMatID
        public static bool ViewProductDrawing(string sFactory, string sMatID)
        {
            try
            {
                string sTitle = null;
                string sURL1 = null;
                string sURL2 = null;
                string sURL3 = null;
                string sDownloadPath = null;

                if (string.IsNullOrEmpty(MPGV.gsFactory) || string.IsNullOrEmpty(sFactory) || string.IsNullOrEmpty(sMatID))
                    return false;

                // 1. get interface path of drawing
                DataTable dt = HQCF.MGetData("ICOM0000-35", new string[] { MPGV.gsFactory, "CCOM_IF_URL", "DRAWING" });

                if (dt.Rows.Count <= 0)
                {
                    sURL1 = string.Empty;
                    sURL2 = string.Empty;
                    sURL3 = string.Empty;
                    return false;
                }

                sTitle = dt.Rows[0][0].ToString();
                sURL1 = dt.Rows[0][1].ToString();
                sURL2 = dt.Rows[0][2].ToString();
                sURL3 = dt.Rows[0][3].ToString();
                sDownloadPath = dt.Rows[0][4].ToString();

                // 2. download product drawing
                using (WebClient webClient = new WebClient())
                {
                    //webClient.DownloadFile(sURL1 + "drawingApproval.do?method=view&drawingCode=" + sFactory + "_" + sMatID + "&drawingType=02", sDownloadPath);
                    webClient.DownloadFile(sURL1 + sURL2 + sFactory + "_" + sMatID + sURL3, sDownloadPath);
                    System.Diagnostics.Process.Start(sDownloadPath);

                }

                // 2. call web client
                /*
                using (WebClient webClient = new WebClient())
                {
                    System.Diagnostics.Process.Start(sURL1 + sURL2 + sFactory + "_" + sMatID + sURL3);
                }
                */

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        // ViewStandardWorkDocument()
        //       - View Standard Work Document
        // Return Value
        //       - 
        // Arguments
        //       - string : sFactory
        //       - string : sRegNo
        public static bool ViewStandardWorkDocument(string sFactory, string sFileOID)
        {
            try
            {
                string sTitle = null;
                string sURL1 = null;
                string sURL2 = null;
                string sURL3 = null;
                string sDownloadPath = null;

                if (string.IsNullOrEmpty(MPGV.gsFactory) || string.IsNullOrEmpty(sFactory) || string.IsNullOrEmpty(sFileOID))
                    return false;

                // 1. get interface path of standard work document
                DataTable dt = HQCF.MGetData("ICOM0000-35", new string[] { MPGV.gsFactory, "CCOM_IF_URL", "STD_WORK_DOCUMENT" });

                if (dt.Rows.Count <= 0)
                {
                    sURL1 = string.Empty;
                    sURL2 = string.Empty;
                    sURL3 = string.Empty;
                    return false;
                }

                sTitle = dt.Rows[0][0].ToString();
                sURL1 = dt.Rows[0][1].ToString();
                sURL2 = dt.Rows[0][2].ToString();
                sURL3 = dt.Rows[0][3].ToString();
                sDownloadPath = dt.Rows[0][4].ToString();

                // 2. call web client
                using (WebClient webClient = new WebClient())
                {
                    System.Diagnostics.Process.Start(sURL1 + sURL2 + sFileOID);
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        public static bool ViewWorkOrderDocument(string sOrderID, string sDocType)
        {
            TRSNode in_node = new TRSNode("VIEW_WORK_ORDER_DOC_IN");
            TRSNode out_node = new TRSNode("VIEW_WORK_ORDER_DOC_OUT");

            string s_arg = string.Empty;
            byte[] bt_buffer;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MES_ORDER", MPCF.Trim(sOrderID));
                in_node.AddChar("DOC_TYPE", MPCF.Trim(sDocType)); // 1: 작업지시, 2:주간성형계획

                if (MPCR.CallService("CWIP", "CWIP_View_Work_Order_Document", in_node, ref out_node, true) == false)
                {
                    return false;
                }

                //MPCR.ShowSuccessMsg(out_node);

                for (int i = 0; i < out_node.GetList("LIST").Count; i++)
                {
                    s_arg = "__BIN_DATA_";
                    s_arg = s_arg + (i + 1).ToString();

                    if ((bt_buffer = out_node.GetBlob(s_arg)) != null)
                    {

                        try
                        {
                            FileStream fs = File.Open(MPCF.Trim(out_node.GetList(0)[i].GetString("FILE_NAME")), FileMode.Create);
                            BinaryWriter writer = new BinaryWriter(fs);
                            writer.Write(bt_buffer, 0, bt_buffer.Length);
                            writer.Close();
                        }
                        catch (Exception ex)
                        {
                            MPCF.ShowMsgBox(ex.Message);
                            return false;
                        }

                        Process process = new Process();
                        process.StartInfo.FileName = MPCF.Trim(out_node.GetList(0)[i].GetString("FILE_NAME"));
                        process.Start();


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

        public static string GenCaptionText(string sOrgText)
        {
            int j;
            int iTotal;
            string sTemp = string.Empty;
            string sTarget = string.Empty;

            bool bSpace;

            try
            {
                if (MPCF.Trim(sOrgText) == "")
                    return " ";

                sTemp = MPCF.Trim(sOrgText);
                sTemp = sTemp.Replace("_", " ");
                sTemp = MPCF.ToLower(sTemp);

                iTotal = sTemp.Length;

                sTarget = MPCF.ToUpper(sTemp.Substring(0, 1));
                bSpace = false;

                for (j = 1; j < iTotal; j++)
                {
                    if (sTemp.Substring(j, 1) == " ")
                    {
                        sTarget = sTarget + " ";
                        bSpace = true;
                        continue;
                    }

                    if (bSpace == true)
                    {
                        sTarget = sTarget + MPCF.ToUpper(sTemp.Substring(j, 1));
                        bSpace = false;
                    }
                    else
                        sTarget = sTarget + sTemp.Substring(j, 1);
                }
                sTarget = sTarget.Replace(" Id ", " ID ");
                if (sTarget.Length > 3)
                {
                    if (sTarget.Substring(sTarget.Length - 3, 3) == " Id")
                        sTarget = sTarget.Substring(0, sTarget.Length - 3) + " ID";
                }

                sTarget = MPCF.FindLanguage(sTarget, Miracom.CliFrx.CAPTION_TYPE.LABEL);

                return sTarget;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return sTarget;
            }
        }

        /// <summary>
        /// 한글&영문 문자수 MaxLength 체크
        /// </summary>
        /// <param name="sText"></param>  String Data
        /// <param name="iMaxLength"></param> Check Max Length
        /// <param name="sNLSLang"></param> Check NLS_LANG
        public static bool CheckStrMaxLength(string sText, int iMaxLength, string sNLSLang)
        {
            int i_byte_len;

            if (iMaxLength == 0)
            {
                return false;
            }

            byte[] bArray_ = Encoding.Default.GetBytes(sText);
            i_byte_len = 0;

            switch (MPCF.Trim(sNLSLang))
            {
                case "UTF-32":

                    byte[] u32Array_ = Encoding.Convert(Encoding.Default, Encoding.UTF32, bArray_);
                    i_byte_len = u32Array_.Length;

                    break;

                case "UTF-7":
                    byte[] u7Array_ = Encoding.Convert(Encoding.Default, Encoding.UTF7, bArray_);
                    i_byte_len = u7Array_.Length;
                    break;

                case "UTF-8":

                    byte[] u8Array_ = Encoding.Convert(Encoding.Default, Encoding.UTF8, bArray_);
                    i_byte_len = u8Array_.Length;

                    break;

                case "UNICODE":

                    byte[] uUArray_ = Encoding.Convert(Encoding.Default, Encoding.Unicode, bArray_);
                    i_byte_len = uUArray_.Length;

                    break;

                case "ASCII":

                    byte[] uAArray_ = Encoding.Convert(Encoding.Default, Encoding.ASCII, bArray_);
                    i_byte_len = uAArray_.Length;

                    break;

            }

            if (iMaxLength < i_byte_len)
            {
                return false;
            }

            return true;
        }

        public static void SpreadAddColumn(FarPoint.Win.Spread.FpSpread spread, string headerText, float width, SpreadCellType cellType, bool pbVisible,
            bool isLocked, bool isSort, FarPoint.Win.Spread.CellHorizontalAlignment cellHorizontalAlignment)
        {
            // Spread에 Column +1
            spread.Sheets[0].ColumnCount++;

            spread.Sheets[0].Columns[spread.Sheets[0].ColumnCount - 1].Width = width;

            // Spread Column Header에 값 입력
            spread.Sheets[0].ColumnHeader.Cells.Get(0, spread.Sheets[0].ColumnCount - 1).Value = GenCaptionText(headerText);

            spread.Sheets[0].Columns.Get(spread.Sheets[0].ColumnCount - 1).Tag = MPCF.ToUpper(headerText);

            // 변수 초기화
            FarPoint.Win.Spread.CellType.BaseCellType celltype = null;

            // Date Time Format 설정 (로컬컴퓨터 설정에 따라)
            DateTimeFormatInfo dtfInfo = new CultureInfo(CultureInfo.CurrentCulture.Name).DateTimeFormat;

            #region 1. Cell Type 설정

            // Cell Type에 대하여(Display Type)
            switch (cellType)
            {
                // Button인 경우
                case SpreadCellType.ButtonCellType:
                    celltype = new FarPoint.Win.Spread.CellType.ButtonCellType();
                    ((FarPoint.Win.Spread.CellType.ButtonCellType)celltype).Text = "...";

                    break;
                // Check Box인 경우
                case SpreadCellType.CheckBoxCellType:
                    celltype = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                    break;
                // ComboBox인 경우
                case SpreadCellType.ComboBoxCellType:
                    celltype = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    break;
                // ComboBox (수정가능 )인 경우
                case SpreadCellType.ComboBoxEditableCellType:
                    celltype = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    ((FarPoint.Win.Spread.CellType.ComboBoxCellType)celltype).Editable = true;
                    break;
                // Dete 인 경우
                case SpreadCellType.DateCellType:
                    celltype = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                    ((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
                    ((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).UserDefinedFormat = "yyyy-MM-dd"; // "yyyy-MM-dd";
                    ((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).SpinButton = true;
                    break;
                // Time인 경우
                case SpreadCellType.TimeCellType:
                    celltype = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                    ((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
                    ((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).UserDefinedFormat = "HH:mm:ss";
                    //((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).UserDefinedFormat = APSGV.gsTimePattern;  // "HH:mm:ss";
                    //((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).UserDefinedFormat = APSGV.gsTimePattern;  // "HH:mm:ss";
                    ((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).SpinButton = true;
                    break;
                // Date Time인 경우
                case SpreadCellType.DateTimeCellType:
                    celltype = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                    //((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
                    ((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
                    ((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).UserDefinedFormat = "yyyy-MM-dd HH:mm:ss";
                    //((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).UserDefinedFormat =
                    //    dtfInfo.ShortDatePattern + " " + dtfInfo.ShortTimePattern;    // "yyyy-MM-dd HH:mm:ss";
                    ((FarPoint.Win.Spread.CellType.DateTimeCellType)celltype).SpinButton = true;
                    break;
                // Int인 경우
                case SpreadCellType.IntCellType:
                    celltype = new FarPoint.Win.Spread.CellType.NumberCellType();
                    ((FarPoint.Win.Spread.CellType.NumberCellType)celltype).DecimalPlaces = 0;
                    ((FarPoint.Win.Spread.CellType.NumberCellType)celltype).ShowSeparator = true;
                    ((FarPoint.Win.Spread.CellType.NumberCellType)celltype).MinimumValue = Int32.MinValue;
                    ((FarPoint.Win.Spread.CellType.NumberCellType)celltype).MaximumValue = Int32.MaxValue;
                    break;
                // 소수점 3자리 실수(Number)인 경우
                case SpreadCellType.NumberCellType:
                    celltype = new FarPoint.Win.Spread.CellType.NumberCellType();
                    ((FarPoint.Win.Spread.CellType.NumberCellType)celltype).DecimalPlaces = 3;
                    ((FarPoint.Win.Spread.CellType.NumberCellType)celltype).ShowSeparator = true;
                    break;
                // Text인 경우
                case SpreadCellType.TextCellType:
                // 기타 경우는 Text로 설정
                default:
                    celltype = new FarPoint.Win.Spread.CellType.TextCellType();
                    break;
            }

            #endregion

            // Cell Type 적용
            spread.Sheets[0].Columns[spread.Sheets[0].ColumnCount - 1].CellType = celltype;

            // column lock 적용
            spread.Sheets[0].Columns[spread.Sheets[0].ColumnCount - 1].Locked = isLocked;

            // column visible 적용
            spread.Sheets[0].Columns[spread.Sheets[0].ColumnCount - 1].Visible = pbVisible;

            //auto sort 적용
            spread.Sheets[0].Columns[spread.Sheets[0].ColumnCount - 1].AllowAutoSort = isSort;

            // Horizaontal Align 적용
            spread.Sheets[0].Columns[spread.Sheets[0].ColumnCount - 1].HorizontalAlignment = cellHorizontalAlignment;

            //VerticalAlignment Align 적용
            spread.Sheets[0].Columns[spread.Sheets[0].ColumnCount - 1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
        }

        //public static void SpreadAddColumn(FarPoint.Win.Spread.FpSpread spread, string headerText)
        //{
        //    // Spread에 Column +1
        //    spread.Sheets[0].ColumnCount++;

        //    // Spread Column Header에 값 입력
        //    spread.Sheets[0].ColumnHeader.Cells.Get(0, spread.Sheets[0].ColumnCount - 1).Value = GenCaptionText(headerText);

        //    spread.Sheets[0].Columns.Get(spread.Sheets[0].ColumnCount - 1).Tag = MPCF.ToUpper(headerText);
        //}

        //2023.04.04 YYK - 계측기 교정 기관 조회 추가 
        public static bool ViewCalibrationInstituteList(Control control, char c_step, char cCaliDiv, char cUseFlag)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("CMMS_VIEW_CALIBRATION_INSTITUTE_LIST_IN");
            TRSNode out_node;

            a_list = new ArrayList();

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }


            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            in_node.AddChar("CALI_DIV", cCaliDiv);
            in_node.AddChar("USE_FLAG", cUseFlag);
            do
            {
                out_node = new TRSNode("CMMS_VIEW_CALIBRATION_INSTITUTE_LIST_OUT");

                if (MPCR.CallService("CMMS", "CMMS_View_Calibration_Institute_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

            } while (a_list.Count < 1);


            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("INSTI_CODE"));

                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("INSTI_NAME"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode("[" + out_node.GetList(0)[i].GetString("INSTI_CODE") + "]" + out_node.GetList(0)[i].GetString("INSTI_NAME"), 0, 0);

                        ((TreeView)control).Nodes.Add(nodeX);
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).Items.Add("[" + out_node.GetList(0)[i].GetString("INSTI_CODE") + "]" + out_node.GetList(0)[i].GetString("INSTI_NAME"));
                    }
                }
            }

            return true;

        }

        //2023.04.04 YYK - 계측기 교정자 조회 추가 
        public static bool ViewCalibrationUserList(Control control, char c_step, char cUseFlag)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("CMMS_VIEW_CALIBRATION_USER_LIST_IN");
            TRSNode out_node;

            a_list = new ArrayList();

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }


            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddChar("USE_FLAG", cUseFlag);
            do
            {
                out_node = new TRSNode("CMMS_VIEW_CALIBRATION_USER_LIST_OUT");

                if (MPCR.CallService("CMMS", "CMMS_View_Calibration_user_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

            } while (a_list.Count < 1);


            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("USER_ID"));

                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("USER_NAME"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode("[" + out_node.GetList(0)[i].GetString("USER_ID") + "]" + out_node.GetList(0)[i].GetString("USER_NAME"), 0, 0);

                        ((TreeView)control).Nodes.Add(nodeX);
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).Items.Add("[" + out_node.GetList(0)[i].GetString("USER_ID") + "]" + out_node.GetList(0)[i].GetString("USER_NAME"));
                    }
                }
            }

            return true;

        }

        //2023.04.05 YYK - 기준 계측기 목록 조회 추가 
        public static bool ViewStandardEquipmentList(Control control, char c_step, char c_standard_flag, string sEquipType)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("CMMS_VIEW_EQUIPMENT_LIST_IN");
            TRSNode out_node;

            a_list = new ArrayList();

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }


            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddString("EQUIP_TYPE", sEquipType);
            in_node.AddChar("STANDARD_FLAG", c_standard_flag);
            do
            {
                out_node = new TRSNode("CMMS_VIEW_EQUIPMENT_LIST_OUT");

                if (MPCR.CallService("CMMS", "CMMS_View_Equipment_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

            } while (a_list.Count < 1);


            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("EQUIP_ID"));

                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("EQUIP_NAME"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode("[" + out_node.GetList(0)[i].GetString("EQUIP_ID") + "]" + out_node.GetList(0)[i].GetString("EQUIP_NAME"), 0, 0);

                        ((TreeView)control).Nodes.Add(nodeX);
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).Items.Add("[" + out_node.GetList(0)[i].GetString("EQUIP_ID") + "]" + out_node.GetList(0)[i].GetString("EQUIP_NAME"));
                    }
                }
            }

            return true;

        }

        //2023.04.11 YYK - 계측기 ITEM 조회 추가 
        public static bool ViewEquipmentItemList(Control control, string sEquipCode, char cAnaDiv)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("CMMS_VIEW_EQUIPMENT_ITEM_LIST_IN");
            TRSNode out_node = new TRSNode("CMMS_VIEW_EQUIPMENT_ITEM_LIST_OUT");
            a_list = new ArrayList();

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '4';
            in_node.AddString("EQUIP_ID", sEquipCode);
            in_node.AddChar("ANA_DIV", cAnaDiv);
            do
            {
                if (MPCR.CallService("CMMS", "CMMS_View_Equipment_Item_List", in_node, ref out_node) == false)
                {
                    return false;
                }
                a_list.Add(out_node);

            } while (a_list.Count < 1);

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("ITEM_CODE"));

                        if (((ListView)control).Columns.Count > 1)
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ITEM_NAME"));
                        if (((ListView)control).Columns.Count > 2)
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetDouble("LSL").ToString());
                        if (((ListView)control).Columns.Count > 3)
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetDouble("USL").ToString());
                        if (((ListView)control).Columns.Count > 4)
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("UNIT_CODE"));
                        if (((ListView)control).Columns.Count > 5)
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("DECIMAL_PLACE").ToString());

                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode("[" + out_node.GetList(0)[i].GetString("ITEM_CODE") + "]" + out_node.GetList(0)[i].GetString("ITEM_NAME"), 0, 0);

                        ((TreeView)control).Nodes.Add(nodeX);
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).Items.Add("[" + out_node.GetList(0)[i].GetString("ITEM_CODE") + "]" + out_node.GetList(0)[i].GetString("ITEM_NAME"));
                    }
                }
            }
            return true;
        }

        //2023.04.11 YYK - 계측기 Sample 조회 추가 
        public static bool ViewMMSSampleList(Control control)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("CMMS_VIEW_SAMPLE_LIST_IN");
            TRSNode out_node = new TRSNode("CMMS_VIEW_SAMPLE_LIST_OUT");

            a_list = new ArrayList();

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }


            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '3';
            in_node.AddChar("USE_FLAG", 'Y');
            do
            {


                if (MPCR.CallService("CMMS", "CMMS_View_Sample_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

            } while (a_list.Count < 1);


            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("SAMPLE_CODE"));

                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SAMPLE_NAME"));
                        }
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode("[" + out_node.GetList(0)[i].GetString("SAMPLE_CODE") + "]" + out_node.GetList(0)[i].GetString("SAMPLE_NAME"), 0, 0);

                        ((TreeView)control).Nodes.Add(nodeX);
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).Items.Add("[" + out_node.GetList(0)[i].GetString("SAMPLE_CODE") + "]" + out_node.GetList(0)[i].GetString("SAMPLE_NAME"));
                    }
                }
            }

            return true;

        }

        //2023.04.11 YYK - Job Change Item List 조회 추가 
        public static bool ViewJCMItemList(Control control)
        {

            int i;
            ListViewItem itmX;
            TreeNode nodeX;
            ArrayList a_list;

            TRSNode in_node = new TRSNode("CJCM_VIEW_SETUP_JOB_CHANGE_ITEM_LIST_IN");
            TRSNode out_node = new TRSNode("CJCM_VIEW_SETUP_JOB_CHANGE_ITEM_LIST_OUT");

            a_list = new ArrayList();

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }


            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            do
            {
                if (MPCR.CallService("CJCM", "CJCM_View_Setup_Job_Change_Item_List", in_node, ref out_node) == false)
                {
                    return false;
                }
                a_list.Add(out_node);

            } while (a_list.Count < 1);


            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("ITEM_CODE"));

                        if (((ListView)control).Columns.Count > 1)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ITEM_NAME"));
                        }
                        if (((ListView)control).Columns.Count > 2)
                        {
                            itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DEPT_CODE"));
                        }
                        //if (((ListView)control).Columns.Count > 3)
                        //{
                        //    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("AUTO_FLAG"));
                        //}
                        //if (((ListView)control).Columns.Count > 4)
                        //{
                        //    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ALARM_CODE"));
                        //}
                        ((ListView)control).Items.Add(itmX);
                    }
                    else if (control is TreeView)
                    {
                        nodeX = new TreeNode("[" + out_node.GetList(0)[i].GetString("ITEM_CODE") + "]" + out_node.GetList(0)[i].GetString("ITEM_NAME"), 0, 0);

                        ((TreeView)control).Nodes.Add(nodeX);
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).Items.Add("[" + out_node.GetList(0)[i].GetString("ITEM_CODE") + "]" + out_node.GetList(0)[i].GetString("ITEM_NAME"));
                    }
                }
            }

            return true;


        }

        public static void OpenAttachedFile(Miracom.UI.Controls.MCCodeView.MCCodeView control)
        {

            byte[] bt_buffer;

            try
            {
                if (control.Tag == null)
                {
                    return;
                }

                bt_buffer = (byte[])control.Tag;

                string s_file_name = control.Text;
                s_file_name = Environment.GetEnvironmentVariable("TEMP") + "\\" + s_file_name;

                try
                {
                    System.IO.FileStream fs = System.IO.File.Open(s_file_name, System.IO.FileMode.Create);
                    System.IO.BinaryWriter writer = new System.IO.BinaryWriter(fs);
                    writer.Write(bt_buffer, 0, bt_buffer.Length);
                    writer.Close();
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    return;
                }

                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = s_file_name;
                proc.Start();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        public static void SetAttachedFile(Miracom.UI.Controls.MCCodeView.MCCodeView control, byte[] bt_buffer, string sNewFlag)
        {
            MemoryStream ms_buffer;

            try
            {
                ms_buffer = new MemoryStream();
                ms_buffer.Write(bt_buffer, 0, bt_buffer.Length);
                ms_buffer.Position = 0;
                control.Tag = bt_buffer;
                control.GetTextBox.Tag = sNewFlag;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        public static void SetAttachedFile(Miracom.UI.Controls.MCCodeView.MCCodeView control, System.IO.FileInfo finfo, string sNewFlag)
        {
            System.IO.BinaryReader br;
            byte[] file_buffer;
            try
            {
                if (finfo.Exists == true)
                {
                    br = new System.IO.BinaryReader(finfo.OpenRead());
                    file_buffer = br.ReadBytes((int)finfo.Length);
                    control.Tag = file_buffer;
                    br.Close();

                    control.GetTextBox.Tag = 'U';
                    control.Text = finfo.Name;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

		#endregion
	}
}
