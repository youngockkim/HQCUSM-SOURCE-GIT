#if _H101
using SOI.MsgHandlerH101;
#endif
#if _Http
using SOI.MsgHandlerHTTP;
#endif
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
using SOI.OIFrx.SOIThemes;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIBaseForm;
using Infragistics.Win.UltraWinGrid;
using System.Data;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using Infragistics.Win.UltraWinTabControl;
using System.IO.Ports;
using System.IO.Compression;

namespace SOI.OIFrx
{
    public class MPCF : CMNF
    {
        #region Property

        [DllImport("user32.dll")]
        private static extern uint GetGuiResources(IntPtr hProcess, uint uiFlags);

        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int nIndex);

        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(String sClassName, String sAppName);

        public static int iFieldSeq;
        private const int VALUE_START_COL = 19;
        private const int VALUE_END_COL = 1018;

        #endregion

        #region Form / Application / Process

        /// <summary>
        /// Get Child Form
        /// </summary>
        /// <param name="MDIForm"></param>
        /// <param name="ChildForm"></param>
        /// <returns></returns>
        public static Form GetChildForm(Form MDIForm, string ChildForm)
        {
            return GetChildForm(MDIForm, ChildForm, true);
        }

        /// <summary>
        /// Get Child Form
        /// </summary>
        /// <param name="MDIForm"></param>
        /// <param name="ChildForm"></param>
        /// <param name="FormActive"></param>
        /// <returns></returns>
        public static Form GetChildForm(Form MDIForm, string ChildForm, bool FormActive)
        {
            return GetChildForm(MDIForm, ChildForm, FormActive, null);
        }

        /// <summary>
        /// Get Child Form
        /// </summary>
        /// <param name="MDIForm"></param>
        /// <param name="ChildForm"></param>
        /// <param name="FormActive"></param>
        /// <param name="sFuncName"></param>
        /// <returns></returns>
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
                        if (ToUpper(SForm.Name) == ChildForm
                            || ToUpper(SForm.Text) == ChildForm)
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
            catch (Exception ex)
            {
                MPCF.ShowErrorMessage(ex.Message);
            }

            return null;
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

        /// <summary>
        /// Get Host Address
        /// </summary>
        /// <param name="sHost"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Font를 변경합니다.
        /// </summary>
        /// <param name="ctrl"></param>
        public static void ChangeFormFont(Control ctrl, SOIBaseFormStyle style)
        {
            // form에 해당하는 전체 컨트롤의 수
            int i_child_count = ctrl.Controls.Count;

            ChangeFont(ctrl, style);

            for (int i = 0; i < i_child_count; i++)
            {
                Control childControl = ctrl.Controls[i];

                if (childControl.Controls.Count > 0)
                {
                    // 재귀함수
                    ChangeFormFont(childControl, style);
                }
                else
                {
                    // 변경
                    ChangeFont(childControl, style);
                }
            }
        }

        /// <summary>
        /// 해당 컨트롤의 Font를 변경합니다.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private static void ChangeFont(Control control, SOIBaseFormStyle style)
        {
            bool bBold = false;

            if (control is SOIPanel
                || control is Panel
                || control is SOIButton
                || control is SOIButtonImage
                || control is SOIButtonImageViewer
                || control is SOIButtonPDFView
                || control is SOIButtonImportExcel
                || control is SOIButtonExportExcel
                || control is SOIButtonPrintOption
                || control is SOITextBox
                || control is SOICodeView
                || control is SOICodeViewDescription
                || control is SOICodeViewMultiSelect
                || control is SOIComboBox
                || control is SOICheckBox
                || control is SOICheckBoxOnOff
                || control is SOIRadioButton
                || control is SOILabel
                || control is SOIPasswordBox
                || control is SOITextBoxNumber
                || control is SOITextBoxValue
                || control is SOIDateTime
                || control is SOIListBox
                || control is SOITabControl
                || control is SOITreeView
                || control is SOISplitContainer
                //|| control is SOIChart
                || control is SOIGrid)
            {
                if (style == SOIBaseFormStyle.OI_Style)
                {
                    bBold = control.Font.Bold;
                    control.Font = new System.Drawing.Font(MPGV.gbffFormFontType, MPGV.gbffFormFontOISize, bBold == true ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                }
                else if (style == SOIBaseFormStyle.UI_Style)
                {
                    bBold = control.Font.Bold;
                    control.Font = new System.Drawing.Font(MPGV.gbffFormFontType, MPGV.gbffFormFontUISize, bBold == true ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                }
            }
            else if (control is SOIGroupBox)
            {
                if (style == SOIBaseFormStyle.OI_Style)
                {
                    bBold = control.Font.Bold;
                    control.Font = new System.Drawing.Font(MPGV.gbffFormFontType, MPGV.gbffFormFontOISize, bBold == true ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                    ((SOIGroupBox)control).HeaderAppearance.FontData.SizeInPoints = MPGV.gbffGroupBoxFontOISize;
                }
                else if (style == SOIBaseFormStyle.UI_Style)
                {
                    bBold = control.Font.Bold;
                    control.Font = new System.Drawing.Font(MPGV.gbffFormFontType, MPGV.gbffFormFontUISize, bBold == true ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                    ((SOIGroupBox)control).HeaderAppearance.FontData.SizeInPoints = MPGV.gbffGroupBoxFontUISize;
                }
            }
            else if (control is SOISpread)
            {
                if (style == SOIBaseFormStyle.OI_Style)
                {
                    bBold = control.Font.Bold;
                    control.Font = new System.Drawing.Font(MPGV.gbffFormFontType, MPGV.gbffFormFontOISize, bBold == true ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                    SOISpread spread = (SOISpread)control;
                    if (spread.Sheets.Count > 0)
                    {
                        spread.Sheets[0].ColumnHeader.DefaultStyle.Font = new System.Drawing.Font(spread.Font.FontFamily, spread.Font.Size, System.Drawing.FontStyle.Bold);
                        spread.Sheets[0].RowHeader.DefaultStyle.Font = new System.Drawing.Font(spread.Font.FontFamily, spread.Font.Size, System.Drawing.FontStyle.Bold);
                        spread.Sheets[0].SheetCorner.DefaultStyle.Font = new System.Drawing.Font(spread.Font.FontFamily, spread.Font.Size, System.Drawing.FontStyle.Bold);
                        spread.Sheets[0].DefaultStyle.Font = new System.Drawing.Font(spread.Font.FontFamily, spread.Font.Size, System.Drawing.FontStyle.Bold);
                    }
                }
                else if (style == SOIBaseFormStyle.UI_Style)
                {
                    bBold = control.Font.Bold;
                    control.Font = new System.Drawing.Font(MPGV.gbffFormFontType, MPGV.gbffFormFontUISize, bBold == true ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                    SOISpread spread = (SOISpread)control;
                    if (spread.Sheets.Count > 0)
                    {
                        spread.Sheets[0].ColumnHeader.DefaultStyle.Font = new System.Drawing.Font(spread.Font.FontFamily, spread.Font.Size, System.Drawing.FontStyle.Bold);
                        spread.Sheets[0].RowHeader.DefaultStyle.Font = new System.Drawing.Font(spread.Font.FontFamily, spread.Font.Size, System.Drawing.FontStyle.Bold);
                        spread.Sheets[0].SheetCorner.DefaultStyle.Font = new System.Drawing.Font(spread.Font.FontFamily, spread.Font.Size, System.Drawing.FontStyle.Bold);
                        spread.Sheets[0].DefaultStyle.Font = new System.Drawing.Font(spread.Font.FontFamily, spread.Font.Size, System.Drawing.FontStyle.Bold);
                    }
                }
            }
        }

        #endregion

        #region Theme

        /// <summary>
        /// Theme Set을 초기화 합니다.
        /// </summary>
        public static void InitThemeSet()
        {
            MPGV.glThemeSet = new List<string>();

            MPGV.glThemeSet.Add(MPGC.THEME_NAME_LIGHT);
            MPGV.glThemeSet.Add(MPGC.THEME_NAME_DARK);
        }

        /// <summary>
        /// Theme 이름에 따라 테마파일을 로드합니다.
        /// </summary>
        /// <param name="sThemeName"></param>
        public static void LoadTheme()
        {
            if (MPGV.gsThemeName == MPGC.THEME_NAME_DARK)
            {
                MPGV.gTheme = new clsDarkColors();
            }
            else if (MPGV.gsThemeName == MPGC.THEME_NAME_LIGHT)
            {
                MPGV.gTheme = new clsLightColors();
            }
            // 최초 적용되는 경우: Default
            else
            {
                if (MPGV.gsDefaultThemeName == MPGC.THEME_NAME_DARK)
                {
                    MPGV.gTheme = new clsDarkColors();
                    MPGV.gsThemeName = MPGC.THEME_NAME_DARK;
                }
                else if (MPGV.gsDefaultThemeName == MPGC.THEME_NAME_LIGHT)
                {
                    MPGV.gTheme = new clsLightColors();
                    MPGV.gsThemeName = MPGC.THEME_NAME_LIGHT;
                }
            }
        }

        /// <summary>
        /// 화면의 모든 컨트롤에 대해 테마를 적용합니다.
        /// SOI Control인 경우에만 해당합니다.
        /// 일부 Framework 화면은 이 함수를 사용하고 화면내에 함수가 구현되어 있습니다.
        ///  ex) Login 화면, Menu 화면 등.
        /// </summary>
        /// <param name="ctrl"></param>
        public static void LoadControlTheme(Control ctrl)
        {
            // form에 해당하는 전체 컨트롤의 수
            int i_child_count = ctrl.Controls.Count;

            ConvertControlTheme(ctrl);

            for (int i = 0; i < i_child_count; i++)
            {
                Control childControl = ctrl.Controls[i];

                if (childControl.Controls.Count > 0)
                {
                    // 재귀함수
                    LoadControlTheme(childControl);
                }
                else
                {
                    // 변경
                    ConvertControlTheme(childControl);
                }
            }
        }

        /// <summary>
        /// 해당 컨트롤에 대해 테마 색을 적용합니다.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private static bool ConvertControlTheme(Control control)
        {
            try
            {
                if (control is frmPopupBase)
                {
                    ((frmPopupBase)control).SetOITheme();
                }
                else if (control is frmModalessPopupBase)
                {
                    ((frmModalessPopupBase)control).SetOITheme();
                }
                else if (control is frmKeyPad)
                {
                    ((frmKeyPad)control).SetOITheme();
                }
                else if (control is SOIBaseForm01)
                {
                    ((SOIBaseForm01)control).SetOITheme();
                }
                else if (control is SOIBaseForm11)
                {
                    ((SOIBaseForm11)control).SetOITheme();
                }
                else if (control is SOIButton)
                {
                    ((SOIButton)control).SetOITheme();
                }
                else if (control is SOIButtonImage)
                {
                    ((SOIButtonImage)control).SetOITheme();
                }
                else if (control is SOIComboBox)
                {
                    ((SOIComboBox)control).SetOITheme();
                }
                else if (control is SOICodeView)
                {
                    ((SOICodeView)control).SetOITheme();
                }
                else if (control is SOICodeViewDescription)
                {
                    ((SOICodeViewDescription)control).SetOITheme();
                }
                else if (control is SOICodeViewMultiSelect)
                {
                    ((SOICodeViewMultiSelect)control).SetOITheme();
                }
                else if (control is SOICheckBox)
                {
                    ((SOICheckBox)control).SetOITheme();
                }
                else if (control is SOICheckBoxOnOff)
                {
                    ((SOICheckBoxOnOff)control).SetOITheme();
                }
                else if (control is SOIRadioButton)
                {
                    ((SOIRadioButton)control).SetOITheme();
                }
                else if (control is SOILabel)
                {
                    ((SOILabel)control).SetOITheme();
                }
                else if (control is SOITextBox)
                {
                    ((SOITextBox)control).SetOITheme();
                }
                else if (control is SOIPasswordBox)
                {
                    ((SOIPasswordBox)control).SetOITheme();
                }
                else if (control is SOITextBoxNumber)
                {
                    ((SOITextBoxNumber)control).SetOITheme();
                }
                else if (control is SOITextBoxValue)
                {
                    ((SOITextBoxValue)control).SetOITheme();
                }
                else if (control is SOIDateTime)
                {
                    ((SOIDateTime)control).SetOITheme();
                }
                else if (control is SOIDateTimeComboBox)
                {
                    ((SOIDateTimeComboBox)control).SetOITheme();
                }
                else if (control is SOIListBox)
                {
                    ((SOIListBox)control).SetOITheme();
                }
                else if (control is SOIGroupBox)
                {
                    ((SOIGroupBox)control).SetOITheme();
                }
                else if (control is SOITabControl)
                {
                    ((SOITabControl)control).SetOITheme();
                }
                else if (control is SOIButtonImageViewer)
                {
                    ((SOIButtonImageViewer)control).SetOITheme();
                }
                else if (control is SOIButtonPDFView)
                {
                    ((SOIButtonPDFView)control).SetOITheme();
                }
                else if (control is SOIButtonImportExcel)
                {
                    ((SOIButtonImportExcel)control).SetOITheme();
                }
                else if (control is SOIButtonExportExcel)
                {
                    ((SOIButtonExportExcel)control).SetOITheme();
                }
                else if (control is SOIButtonPrintOption)
                {
                    ((SOIButtonPrintOption)control).SetOITheme();
                }
                else if (control is SOITreeView)
                {
                    ((SOITreeView)control).SetOITheme();
                }
                else if (control is SOIPanel)
                {
                    ((SOIPanel)control).SetOITheme();
                }
                else if (control is SOISplitContainer)
                {
                    ((SOISplitContainer)control).SetOITheme();
                }
                else if (control is SOIGrid)
                {
                    ((SOIGrid)control).SetOITheme();
                }
                else if (control is SOIChart)
                {
                    ((SOIChart)control).SetOITheme();
                }
                else if (control is SOISpread)
                {
                    ((SOISpread)control).SetOITheme();
                }
                else if (control is SOIFlexibleScreen)
                {
                    ((SOIFlexibleScreen)control).SetOITheme();
                }

                return true;
            }
            catch (Exception ex)
            {
                ShowMessage("ConvertControlTheme : " + ex.Message, MSG_LEVEL.ERROR, true);
                return false;
            }
        }

        #endregion

        #region MES Service

        /// <summary>
        /// IN Node를 초기설정 합니다.
        /// </summary>
        /// <param name="in_node"></param>
        public static void SetInMsg(TRSNode in_node)
        {
            try
            {
                // Factory
                if (MPGV.gsFactory != null) in_node.Factory = MPGV.gsFactory;
                // Language
                if (MPGV.gcLanguage != 0) in_node.Language = MPGV.gcLanguage;
                // Passport
                if (MPGV.gsPassport != null) in_node.Passport = MPGV.gsPassport;
                // Password
                if (MPGV.gsPassword != null) in_node.Password = MPGV.gsPassword;
                // User ID
                if (MPGV.gsUserID != null) in_node.UserID = MPGV.gsUserID;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// Continue 여부를 체크한다.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static bool CheckContinueProc(TRSNode node, bool b_is_popup_message)
        {
            ErrorModel errMsg;

            try
            {
                if (node.GetMember(TRSDefine.OUT_STATUSVALUE) == null)
                {
                    return false;
                }

                if (node.StatusValue == MPGC.MP_SUCCESS_STATUS && node.MsgCate == MPGC.MP_MSG_CATE_WARN)
                {
                    ShowMessage(node.GetString(TRSDefine.OUT_MSG), MSG_LEVEL.WARNING, b_is_popup_message);
                }
                else if (node.StatusValue == MPGC.MP_WARN_STATUS)
                {
                    ShowMessage(node.GetString(TRSDefine.OUT_MSG), MSG_LEVEL.WARNING, b_is_popup_message);
                }

                if (node.StatusValue == MPGC.MP_SUCCESS_STATUS || node.StatusValue == MPGC.MP_WARN_STATUS)
                {
                    return true;
                }

                // 에러 메세지를 전역 리스트에 저장
                // 에러 메세지를 전역 리스트에 저장하고, 메인화면에서 상세 메세지를 확인할 수 있도록 한다.
                errMsg = new ErrorModel();
                errMsg.MsgCate = node.GetChar(TRSDefine.OUT_MSGCATE);
                errMsg.StatusValue = node.GetChar(TRSDefine.OUT_STATUSVALUE);
                errMsg.MsgCode = node.GetString(TRSDefine.OUT_MSGCODE);
                errMsg.ErrorMsg = node.GetString(TRSDefine.OUT_MSG);
                errMsg.DBErrorMsg = node.GetString(TRSDefine.OUT_DBERRMSG);
                errMsg.IssueDate = MakeDateFormat(DateTime.Now.ToString("yyyyMMddhhmmss"));

                // 필드 메세지가 있다면, 해당 메시지를 추가
                foreach (TRSNode sub in node.GetList(TRSDefine.OUT_FIELDMSG))
                {
                    if (errMsg.FieldMsg == null) errMsg.FieldMsg = new List<FieldMsg>();
                    foreach (TRSNode fieldSub in sub.Members)
                    {
                        errMsg.FieldMsg.Add(new FieldMsg()
                        {
                            Name = fieldSub.Name,
                            Type = fieldSub.ValueType.ToString(),
                            Text = fieldSub.Value
                        });
                    }
                }

                // 전역 변수 확인
                if (MPGV.glErrorMessageList == null)
                {
                    MPGV.glErrorMessageList = new List<ErrorModel>();
                }

                //  메시지 초과 시 첫번째 메시지 제거
                if (MPGV.glErrorMessageList.Count == MPGC.MP_ERROR_MSG_MAX_COUNT)
                {
                    MPGV.glErrorMessageList.RemoveAt(0);
                }

                // 메시지 등록
                MPGV.glErrorMessageList.Add(errMsg);

                ShowMessage(node.GetString(TRSDefine.OUT_MSG), MSG_LEVEL.ERROR, b_is_popup_message);
                return false;
            }
            catch (Exception ex)
            {
                ShowMessage("CheckContinueProc()\n" + ex.Message, MSG_LEVEL.ERROR, true);
                return false;
            }
        }

        /// <summary>
        /// System Error Report Alarm
        /// </summary>
        /// <param name="s_error_msg"></param>
        /// <param name="s_service_name"></param>
        /// <param name="s_in_xml"></param>
        /// <returns></returns>
        private static bool SendSystemErrorReportAlarm(string s_error_msg, string s_service_name, string s_in_xml)
        {
            /* 2013.06.12. Aiden. Middleware 가 사용가능한지 확인 */
            if (MPIF.gInit.IsAvailableSendMessage == false)
            {
                return true;
            }

            TRSNode in_node = new TRSNode("RAISE_ALARM_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            List<string> xml_list;

            xml_list = ByteSplit(s_in_xml, 800);

            try
            {
                SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.Factory = MPGV.gsCentralFactory;
                in_node.AddString("ALARM_ID", "SysErrReportAlarm");
                in_node.AddString("ALARM_MSG", s_error_msg);
                in_node.AddString("LOT_ID", MPGV.gsCurrentLot_ID);
                in_node.AddString("RES_ID", MPGV.gsCurrentRes_ID);
                in_node.AddString("SOURCE_ID_1", MPGV.gsProgramID);
                in_node.AddString("SOURCE_DESC_1", s_service_name);
                in_node.AddString("SOURCE_ID_2", "TTL:" + MPGV.giTimeOut);
                in_node.AddString("SOURCE_DESC_2", "SiteID:" + MPGV.gsSiteID);
                in_node.AddString("SOURCE_ID_3", MPGV.gsUserID);

                if (xml_list.Count > 0)
                {
                    in_node.AddString("ALARM_COMMENT_1", xml_list[0]);
                }
                if (xml_list.Count > 1)
                {
                    in_node.AddString("ALARM_COMMENT_2", xml_list[1]);
                }
                if (xml_list.Count > 2)
                {
                    in_node.AddString("ALARM_COMMENT_3", xml_list[2]);
                }
                if (xml_list.Count > 3)
                {
                    in_node.AddString("ALARM_COMMENT_4", xml_list[3]);
                }
                if (xml_list.Count > 4)
                {
                    in_node.AddString("ALARM_COMMENT_5", xml_list[4]);
                }

                if (MessageCaster.CallService("ALM", "ALM_Raise_Alarm", in_node, ref out_node) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                return false;
            }
        }

#if _Http
        /// <summary>
        /// In Node에 File 관련 부분을 설정합니다.
        /// </summary>
        /// <param name="in_node"></param>
        /// <param name="data"></param>
        /// <param name="file_name"></param>
        public static void SetInFile(ref TRSNode in_node, string filePath, string file_name)
        {
            byte[] data;

            try
            {
                // Validation
                if (string.IsNullOrEmpty(filePath) == true)
                {
                    data = null;
                }
                else if (File.Exists(filePath) == false)
                {
                    data = null;
                }
                else
                {
                    data = File.ReadAllBytes(filePath);
                }
                in_node.AddBlob(MPGC.MP_BIN_DATA_1, data);
                in_node.AddString(MPGC.MP_BIN_DATA_FILE_NAME, file_name);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// In Node에 File 관련 부분을 설정합니다.
        /// </summary>
        /// <param name="in_node"></param>
        /// <param name="data"></param>
        /// <param name="file_name"></param>
        public static void SetInFile(ref TRSNode in_node, byte[] data, string file_name)
        {
            try
            {
                in_node.AddBlob(MPGC.MP_BIN_DATA_1, data);
                in_node.AddString(MPGC.MP_BIN_DATA_FILE_NAME, file_name);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <param name="out_node"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node)
        {
            return CallService(s_module_name, s_service_name, in_node, ref out_node, "", 0, DeliveryMode.RReply, false, false);
        }

        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <param name="out_node"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node, DeliveryMode mode)
        {
            return CallService(s_module_name, s_service_name, in_node, ref out_node, "", 0, mode, false, false);
        }

        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <param name="out_node"></param>
        /// <param name="mode"></param>
        /// <param name="b_ignore_message"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node, DeliveryMode mode, bool b_ignore_message)
        {
            return CallService(s_module_name, s_service_name, in_node, ref out_node, "", 0, mode, b_ignore_message, false);
        }

        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <param name="out_node"></param>
        /// <param name="b_ignore_message"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node, bool b_ignore_message)
        {
            return CallService(s_module_name, s_service_name, in_node, ref out_node, "", 0, DeliveryMode.RReply, b_ignore_message, false);
        }

        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <param name="out_node"></param>
        /// <param name="channel"></param>
        /// <param name="b_ignore_message"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node, string channel, bool b_ignore_message)
        {
            return CallService(s_module_name, s_service_name, in_node, ref out_node, channel, 0, DeliveryMode.RReply, b_ignore_message, false);
        }

        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <param name="out_node"></param>
        /// <param name="channel"></param>
        /// <param name="ttl"></param>
        /// <param name="mode"></param>
        /// <param name="b_ignore_message"></param>
        /// <param name="b_is_popup_message"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node, string channel, int ttl, DeliveryMode mode, bool b_ignore_message, bool b_is_popup_message)
        {
            try
            {
                // Message 클리어                
                ShowMessage("", MSG_LEVEL.NONE, false);

                // Loading 화면 시작
                MPGV.gIMdiForm.ShowLoadingScreen(true);

                if (MessageCaster.CallService(s_module_name, s_service_name, in_node, ref out_node, channel, ttl, mode) == false)
                {
                    // Loading 화면 종료
                    MPGV.gIMdiForm.ShowLoadingScreen(false);

                    // Error Message Show
                    ShowMessage(MPMH.StatusMessage, MSG_LEVEL.ERROR, true);

                    // Report
                    SendSystemErrorReportAlarm(MPMH.StatusMessage, s_service_name, MessageCaster.InXmlString);

                    return false;
                }

                // Loading 화면 종료
                MPGV.gIMdiForm.ShowLoadingScreen(false);

                if (b_ignore_message == false)
                {
                    if (CheckContinueProc(out_node, b_is_popup_message) == false)
                    {
                        return false;
                    }
                }
                else
                {
                    if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                if (b_ignore_message == false)
                {
                    ShowMessage("CallService() : " + ex.Message, MSG_LEVEL.ERROR, true);
                }

                return false;
            }
        }

        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node)
        {
            return CallService(s_module_name, s_service_name, in_node, "", 0, DeliveryMode.Multicast, false);
        }

        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <param name="b_ignore_message"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, bool b_ignore_message)
        {
            return CallService(s_module_name, s_service_name, in_node, "", 0, DeliveryMode.Multicast, b_ignore_message);
        }

        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, DeliveryMode mode)
        {
            return CallService(s_module_name, s_service_name, in_node, "", 0, mode, false);
        }

        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, string channel)
        {
            return CallService(s_module_name, s_service_name, in_node, channel, 0, DeliveryMode.Multicast, false);
        }

        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <param name="mode"></param>
        /// <param name="b_ignore_message"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, DeliveryMode mode, bool b_ignore_message)
        {
            return CallService(s_module_name, s_service_name, in_node, "", 0, mode, b_ignore_message);
        }

        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <param name="channel"></param>
        /// <param name="ttl"></param>
        /// <param name="mode"></param>
        /// <param name="b_ignore_message"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, string channel, int ttl, DeliveryMode mode, bool b_ignore_message)
        {
            try
            {
                // Message 클리어                
                ShowMessage("", MSG_LEVEL.NONE, false);

                // Loading 화면 시작
                MPGV.gIMdiForm.ShowLoadingScreen(true);

                if (MessageCaster.CallService(s_module_name, s_service_name, in_node, channel, ttl, mode) == false)
                {
                    // Loading 화면 종료
                    MPGV.gIMdiForm.ShowLoadingScreen(false);

                    // Error Message Show
                    ShowMessage(MPMH.StatusMessage, MSG_LEVEL.ERROR, true);

                    // Report
                    SendSystemErrorReportAlarm(MPMH.StatusMessage, s_service_name, MessageCaster.InXmlString);

                    return false;
                }

                // Loading 화면 종료
                MPGV.gIMdiForm.ShowLoadingScreen(false);

                return true;
            }
            catch (Exception ex)
            {
                if (b_ignore_message == false)
                {
                    ShowMessage("CallService() : " + ex.Message, MSG_LEVEL.ERROR, true);
                }

                return false;
            }
        }

        /// <summary>
        /// File을 다운로드 합니다.
        /// </summary>
        /// <param name="s_file_id"></param>
        /// <param name="out_bytes"></param>
        /// <returns></returns>
        public static bool CallDownloadService(string s_file_id, ref byte[] out_bytes)
        {
            TRSNode in_node = new TRSNode("NONE");
            SetInMsg(in_node);
            in_node.ProcStep = '1';

            return MessageCaster.CallDownloadService(s_file_id, in_node, ref out_bytes);
        }

#else
        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <param name="out_node"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node)
        {
            return CallService(s_module_name, s_service_name, in_node, ref out_node, "", 0, DeliveryMode.RReply, false);
        }

        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <param name="out_node"></param>
        /// <param name="b_ignore_message"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node, bool b_ignore_message)
        {
            return CallService(s_module_name, s_service_name, in_node, ref out_node, "", 0, DeliveryMode.RReply, b_ignore_message);
        }

        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <param name="out_node"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node, DeliveryMode mode)
        {
            return CallService(s_module_name, s_service_name, in_node, ref out_node, "", 0, mode, false);
        }

        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <param name="out_node"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node, string channel)
        {
            return CallService(s_module_name, s_service_name, in_node, ref out_node, channel, 0, DeliveryMode.RReply, false);
        }
        
        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <param name="out_node"></param>
        /// <param name="mode"></param>
        /// <param name="b_ignore_message"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node, DeliveryMode mode, bool b_ignore_message)
        {
            return CallService(s_module_name, s_service_name, in_node, ref out_node, "", 0, mode, b_ignore_message);
        }

        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <param name="out_node"></param>
        /// <param name="channel"></param>
        /// <param name="ttl"></param>
        /// <param name="mode"></param>
        /// <param name="b_ignore_message"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, ref TRSNode out_node, string channel, int ttl, DeliveryMode mode, bool b_ignore_message)
        {
            try
            {
                // Message 클리어                
                ShowMessage("", MSG_LEVEL.NONE, false);

                // Loading 화면 시작
                MPGV.gIMdiForm.ShowLoadingScreen(true);

                if (MessageCaster.CallService(s_module_name, s_service_name, in_node, ref out_node, channel, ttl, mode) == false)
                {
                    // Loading 화면 종료
                    MPGV.gIMdiForm.ShowLoadingScreen(false);

                    // Error Message Show
                    ShowMessage(MPMH.StatusMessage, MSG_LEVEL.ERROR, true);

                    // Report
                    SendSystemErrorReportAlarm(MPMH.StatusMessage, s_service_name, MessageCaster.InXmlString);

                    return false;
                }

                // Loading 화면 종료
                MPGV.gIMdiForm.ShowLoadingScreen(false);

                if (b_ignore_message == false)
                {
                    if (CheckContinueProc(out_node, false) == false)
                    {
                        return false;
                    }
                }
                else
                {
                    if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                if (b_ignore_message == false)
                {
                    ShowMessage("CallService() : " + ex.Message, MSG_LEVEL.ERROR, true);
                }

                return false;
            }
        }

        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node)
        {
            return CallService(s_module_name, s_service_name, in_node, "", 0, DeliveryMode.Multicast, false);
        }

        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <param name="b_ignore_message"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, bool b_ignore_message)
        {
            return CallService(s_module_name, s_service_name, in_node, "", 0, DeliveryMode.Multicast, b_ignore_message);
        }

        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, DeliveryMode mode)
        {
            return CallService(s_module_name, s_service_name, in_node, "", 0, mode, false);
        }

        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, string channel)
        {
            return CallService(s_module_name, s_service_name, in_node, channel, 0, DeliveryMode.Multicast, false);
        }

        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <param name="mode"></param>
        /// <param name="b_ignore_message"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, DeliveryMode mode, bool b_ignore_message)
        {
            return CallService(s_module_name, s_service_name, in_node, "", 0, mode, b_ignore_message);
        }

        /// <summary>
        /// Service를 실행합니다.
        /// </summary>
        /// <param name="s_module_name"></param>
        /// <param name="s_service_name"></param>
        /// <param name="in_node"></param>
        /// <param name="channel"></param>
        /// <param name="ttl"></param>
        /// <param name="mode"></param>
        /// <param name="b_ignore_message"></param>
        /// <returns></returns>
        public static bool CallService(string s_module_name, string s_service_name, TRSNode in_node, string channel, int ttl, DeliveryMode mode, bool b_ignore_message)
        {
            try
            {
                // Message 클리어                
                ShowMessage("", MSG_LEVEL.NONE, false);

                // Loading 화면 시작
                MPGV.gIMdiForm.ShowLoadingScreen(true);

                if (MessageCaster.CallService(s_module_name, s_service_name, in_node, channel, ttl, mode) == false)
                {
                    // Loading 화면 종료
                    MPGV.gIMdiForm.ShowLoadingScreen(false);

                    // Error Message Show
                    ShowMessage(MPMH.StatusMessage, MSG_LEVEL.ERROR, true);

                    // Report
                    SendSystemErrorReportAlarm(MPMH.StatusMessage, s_service_name, MessageCaster.InXmlString);

                    return false;
                }

                // Loading 화면 종료
                MPGV.gIMdiForm.ShowLoadingScreen(false);

                return true;
            }
            catch (Exception ex)
            {
                if (b_ignore_message == false)
                {
                    ShowMessage("CallService() : " + ex.Message, MSG_LEVEL.ERROR, true);
                }

                return false;
            }
        }
#endif

        #endregion

        #region Module Service

        #region BAS

        /// <summary>
        /// Client Upgrade
        /// </summary>
        /// <param name="iStep"></param>
        /// <returns></returns>
        public static int Client_Upgrade(int iStep)
        {
            TRSNode in_node = new TRSNode("CHECK_VERSION_IN");
            TRSNode out_node = new TRSNode("CHECK_VERSION_OUT");
            FileVersionInfo UpgradeExe;
            string UpgradeVersion;
            FTPClient.FTPConnection ftp = null;

            try
            {
                // Retern Value : -1 -> Occur error
                //                 0 -> version same
                //                 1 -> Client upgrade

                // Check Server Connected
                if (MPIF.gInit.IsAvailableSendMessage == false)
                {
                    return 0;
                }

                // Get Version Info
                SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("PROGRAM_ID", Application.ProductName);
                if (MessageCaster.CallService("BAS", "BAS_Check_Version", in_node, ref out_node) == false)
                {
                    return -1;
                }

                // Fail to check version
                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    CheckContinueProc(out_node, false);
                    return -1;
                }

                // Get version 
                // For SE : "UPGRADE_OPTION_6" GCM table data_2
                MPGV.gsServerVersion = out_node.GetString("SERVER_VERSION");

                // Check Same Version
                if (iStep == 1 && MPGV.gsServerVersion == MPGV.gsClientVersion)
                {
                    return 0;
                }

                // Check Continue
                if (iStep == 1)
                {
                    // The client currently uses old version system. Do you wish to upgrade to new version?
                    if (MPCF.ShowMsgBox(MPCF.GetMessage(9), MessageBoxButtons.YesNo, MSG_LEVEL.NONE, "") == DialogResult.No)
                    {
                        return 0;
                    }
                }

                // MESSAGE UPGRAGE
                if (out_node.GetString("UPGRADE_METHOD") == "MSG")
                {
#if _H101
                    // 1. Upgrade File Setting
                    MPGV.gsUpgradeFile = "SOIUpgradeMsg.exe";

                    // 2. Get Upgrade File Version
                    if (File.Exists(Application.StartupPath + "\\" + MPGV.gsUpgradeFile) == true)
                    {
                        // Assembly File Version
                        UpgradeExe = System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\" + MPGV.gsUpgradeFile);
                        UpgradeVersion = UpgradeExe.FileVersion;
                    }
                    else
                    {
                        UpgradeVersion = "0.0.0.0";
                    }

                    // 3. Delete Old Upgrade File
                    if (File.Exists(Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old") == true)
                    {
                        File.Delete(Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old");
                    }

                    // 4. Current Upgrade File to Old File
                    if (UpgradeVersion == "0.0.0.0")
                    {
                    }
                    else if (UpgradeVersion != out_node.GetString("UPGRADE_VERSION"))
                    {
                        File.Copy(Application.StartupPath + "\\" + MPGV.gsUpgradeFile, Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old", true);
                        File.Delete(Application.StartupPath + "\\" + MPGV.gsUpgradeFile);
                    }

                    // 5. Download New Upgrade File
                    if (UpgradeVersion == "0.0.0.0" ||
                        UpgradeVersion != out_node.GetString("UPGRADE_VERSION"))
                    {
                        TRSNode min_node = new TRSNode("UPGRADE_MSG_IN");
                        TRSNode mout_node = new TRSNode("UPGRADE_MSG_OUT");
                        SetInMsg(min_node);
                        min_node.ProcStep = '1';
                        min_node.AddString("FILE_NAME", MPGV.gsUpgradeFile);
                        if (CallService("BAS", "BAS_Upgrade_Msg", min_node, ref mout_node, DeliveryMode.RReply, true) == false)
                        {                            
                            ShowMessage(mout_node.GetString("MSG"), MSG_LEVEL.ERROR, true);
                            return -1;
                        }
                        if (mout_node.StatusValue == MPGC.MP_FAIL_STATUS)
                        {
                            return -1;
                        }
                        FileStream fs = File.Open(Application.StartupPath + "\\" + MPGV.gsUpgradeFile, FileMode.Create);
                        BinaryWriter bw = new BinaryWriter(fs);
                        byte[] buffer;
                        fs.Flush();
                        buffer = mout_node.GetBlob(MPGC.MP_BIN_DATA_2);
                        bw.Write(buffer);
                        bw.Close();
                        fs.Close();
                    }

                    // 6. New Upgrade Folder
                    String upgradePath = Application.StartupPath + "\\_upgrade";
                    if (Directory.Exists(upgradePath) == false)
                    {
                        Directory.CreateDirectory(upgradePath);
                    }
                    File.Copy(Application.StartupPath + "\\" + MPGV.gsUpgradeFile, upgradePath + "\\" + MPGV.gsUpgradeFile, true);
                    File.Copy(Application.StartupPath + "\\" + "ICSharpCode.SharpZipLib.dll", upgradePath + "\\" + "ICSharpCode.SharpZipLib.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "Miracom.TRSConvertor.dll", upgradePath + "\\" + "Miracom.TRSConvertor.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "Miracom.TRSCore.dll", upgradePath + "\\" + "Miracom.TRSCore.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "SOI.MsgHandlerH101.dll", upgradePath + "\\" + "SOI.MsgHandlerH101.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "SOI.MsgHandlerHTTP.dll", upgradePath + "\\" + "SOI.MsgHandlerHTTP.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "SOI.CliFrx.dll", upgradePath + "\\" + "SOI.CliFrx.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "SOI.OIFrx.dll", upgradePath + "\\" + "SOI.OIFrx.dll", true);
                    if (MPIF.gInit.getMiddleware == "H101")
                    {
                        File.Copy(Application.StartupPath + "\\" + "transceiverxnet.dll", upgradePath + "\\" + "transceiverxnet.dll", true);
                    }

                    // 7. Start Upgrade File
                    ProcessStartInfo StartInfo = new ProcessStartInfo();
                    StartInfo.FileName = Application.StartupPath + "\\_upgrade" + "\\" + MPGV.gsUpgradeFile;
                    // Args[0] : Connection String = Address
                    // Args[1] : Site ID
                    // Args[2] : Download File List = "SOIDownloadFile.xml"
                    StartInfo.Arguments = MPGV.gsRemoteAddress + " " 
                        + MPGV.gsSiteID + " " 
                        + MPGV.gsDownloadFileList + " " 
                        + MPGV.gsRvService + " " 
                        + MPGV.gsRvNetwork;
                    System.Diagnostics.Process.Start(StartInfo);
#endif
#if _Http
                    // 1. Upgrade File Setting
                    MPGV.gsUpgradeFile = "SOIUpgradeMsg.exe";

                    // 2. Get Upgrade File Version
                    if (File.Exists(Application.StartupPath + "\\" + MPGV.gsUpgradeFile) == true)
                    {
                        // Assembly File Version
                        UpgradeExe = System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\" + MPGV.gsUpgradeFile);
                        UpgradeVersion = UpgradeExe.FileVersion;
                    }
                    else
                    {
                        UpgradeVersion = "0.0.0.0";
                    }

                    // 3. Delete Old Upgrade File
                    if (File.Exists(Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old") == true)
                    {
                        File.Delete(Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old");
                    }

                    // 4. Current Upgrade File to Old File
                    if (UpgradeVersion == "0.0.0.0")
                    {
                    }
                    else if (UpgradeVersion != out_node.GetString("UPGRADE_VERSION"))
                    {
                        //File.Copy(Application.StartupPath + "\\" + MPGV.gsUpgradeFile, Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old", true);
                        //File.Delete(Application.StartupPath + "\\" + MPGV.gsUpgradeFile);
                    }

                    // 5. Download New Upgrade File
                    if (UpgradeVersion == "0.0.0.0" ||
                        UpgradeVersion != out_node.GetString("UPGRADE_VERSION"))
                    {
                        //TRSNode min_node = new TRSNode("UPGRADE_MSG_IN");
                        //TRSNode mout_node = new TRSNode("UPGRADE_MSG_OUT");
                        //SetInMsg(min_node);
                        //min_node.ProcStep = '1';
                        //min_node.AddString("FILE_NAME", MPGV.gsUpgradeFile);
                        //if (CallService("BAS", "BAS_Upgrade_Msg", min_node, ref mout_node, DeliveryMode.RReply, true) == false)
                        //{
                        //    ShowMessage(mout_node.GetString("MSG"), MSG_LEVEL.ERROR, true);
                        //    return -1;
                        //}
                        //if (mout_node.StatusValue == MPGC.MP_FAIL_STATUS)
                        //{
                        //    return -1;
                        //}
                        //FileStream fs = File.Open(Application.StartupPath + "\\" + MPGV.gsUpgradeFile, FileMode.Create);
                        //BinaryWriter bw = new BinaryWriter(fs);
                        //byte[] buffer;
                        //fs.Flush();
                        //buffer = mout_node.GetBlob(MPGC.MP_BIN_DATA_2);
                        //bw.Write(buffer);
                        //bw.Close();
                        //fs.Close();
                    }

                    // 6. New Upgrade Folder
                    String upgradePath = Application.StartupPath + "\\_upgrade";
                    if (Directory.Exists(upgradePath) == false)
                    {
                        Directory.CreateDirectory(upgradePath);
                    }
                    File.Copy(Application.StartupPath + "\\" + MPGV.gsUpgradeFile, upgradePath + "\\" + MPGV.gsUpgradeFile, true);
                    File.Copy(Application.StartupPath + "\\" + "ICSharpCode.SharpZipLib.dll", upgradePath + "\\" + "ICSharpCode.SharpZipLib.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "Miracom.TRSConvertor.dll", upgradePath + "\\" + "Miracom.TRSConvertor.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "Miracom.TRSCore.dll", upgradePath + "\\" + "Miracom.TRSCore.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "SOI.MsgHandlerH101.dll", upgradePath + "\\" + "SOI.MsgHandlerH101.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "SOI.MsgHandlerHTTP.dll", upgradePath + "\\" + "SOI.MsgHandlerHTTP.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "SOI.CliFrx.dll", upgradePath + "\\" + "SOI.CliFrx.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "SOI.OIFrx.dll", upgradePath + "\\" + "SOI.OIFrx.dll", true);
                    if (MPIF.gInit.getMiddleware == "H101")
                    {
                        File.Copy(Application.StartupPath + "\\" + "transceiverxnet.dll", upgradePath + "\\" + "transceiverxnet.dll", true);
                    }

                    // 7. Start Upgrade File
                    ProcessStartInfo StartInfo = new ProcessStartInfo();
                    StartInfo.FileName = Application.StartupPath + "\\_upgrade" + "\\" + MPGV.gsUpgradeFile;
                    // Args[0] : Connection String = Address
                    // Args[1] : File ID of UPGRADE_OPTION_6
                    // Args[2] : USER ID@FACTORY
                    // Args[3] : PASSWORD
                    //StartInfo.Arguments = MPGV.gsRemoteAddress + " "
                    //    + out_node.GetString("UPGRADE_FILE_ID") + " "
                    //    + "StandardOI.exe";                        
                    StartInfo.Arguments = MPGV.gsRemoteAddress + " "
                    + out_node.GetString("UPGRADE_FILE_ID") + " "
                    + MPGV.gsUserID + "@" + MPGV.gsFactory + " " 
                    + MPGV.gsPassword;     
                    System.Diagnostics.Process.Start(StartInfo);
#endif
                }
                // FTP UPGRADE
                else
                {
                    // 1. Upgrade File Setting
                    MPGV.gsUpgradeFile = "SOIUpgradeFtp.exe";

                    // 2. Get Upgrade File Version
                    if (File.Exists(Application.StartupPath + "\\" + MPGV.gsUpgradeFile) == true)
                    {
                        // Assembly File Version
                        UpgradeExe = System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\" + MPGV.gsUpgradeFile);
                        UpgradeVersion = UpgradeExe.FileVersion;
                    }
                    else
                    {
                        UpgradeVersion = "0.0.0.0";
                    }

                    // 3. Delete Old Upgrade File
                    if (File.Exists(Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old") == true)
                    {
                        File.Delete(Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old");
                    }

                    // 5. Download New Upgrade File
                    if (UpgradeVersion == "0.0.0.0")
                    {
                        ftp = new FTPClient.FTPConnection();
                        ftp.Open(out_node.GetString("UPGRADE_ADDRESS"), 21, out_node.GetString("UPGRADE_USER_ID"), out_node.GetString("UPGRADE_PASSWORD"), FTPClient.FTPMode.Passive);
                        ftp.ChangeDirectory(out_node.GetString("UPGRADE_DIRECTORY"));
                        ftp.GetFile(MPGV.gsUpgradeFile, FTPClient.FTPFileTransferType.Binary);
                        ftp.Close();
                    }
                    else if (UpgradeVersion != out_node.GetString("UPGRADE_VERSION"))
                    {
                        // 4. Current upgrade file to old upgrade file
                        File.Copy(Application.StartupPath + "\\" + MPGV.gsUpgradeFile, Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old", true);
                        File.Delete(Application.StartupPath + "\\" + MPGV.gsUpgradeFile);

                        ftp = new FTPClient.FTPConnection();
                        ftp.Open(out_node.GetString("UPGRADE_ADDRESS"), 21, out_node.GetString("UPGRADE_USER_ID"), out_node.GetString("UPGRADE_PASSWORD"), FTPClient.FTPMode.Passive);
                        ftp.ChangeDirectory(out_node.GetString("UPGRADE_DIRECTORY"));
                        ftp.GetFile(MPGV.gsUpgradeFile, FTPClient.FTPFileTransferType.Binary);
                        ftp.Close();
                    }

                    // 7. Start Upgrade File
                    ProcessStartInfo StartInfo = new ProcessStartInfo();
                    StartInfo.FileName = Application.StartupPath + "\\" + MPGV.gsUpgradeFile;
                    // Args[1] : FTP IP = Upgrade Address in config file.
                    // Args[2] : User Name = User Name in config file.
                    // Args[3] : Password = Password in config file.
                    // Args[4] : Server Path = Upgrade Dir in config file.
                    // Args[5] : Download File List = "SOIDownloadFile.xml"
                    StartInfo.Arguments = out_node.GetString("UPGRADE_ADDRESS") + " " 
                        + out_node.GetString("UPGRADE_USER_ID") + " " 
                        + out_node.GetString("UPGRADE_PASSWORD") + " " 
                        + out_node.GetString("UPGRADE_DIRECTORY") + " " 
                        + MPGV.gsDownloadFileList;
                    System.Diagnostics.Process.Start(StartInfo);                    
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// Client Upgrade Force
        /// </summary>
        /// <param name="iStep"></param>
        /// <returns></returns>
        public static int Client_Upgrade_Force()
        {
            TRSNode in_node = new TRSNode("CHECK_VERSION_IN");
            TRSNode out_node = new TRSNode("CHECK_VERSION_OUT");
            FileVersionInfo UpgradeExe;
            string UpgradeVersion;
            FTPClient.FTPConnection ftp = null;

            try
            {
                // Retern Value : -1 -> Occur error
                //                 0 -> version same
                //                 1 -> Client upgrade

                // Check Server Connected
                if (MPIF.gInit.IsAvailableSendMessage == false)
                {
                    return 0;
                }

                // Get Version Info
                SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("PROGRAM_ID", Application.ProductName);
                if (MessageCaster.CallService("BAS", "BAS_Check_Version", in_node, ref out_node) == false)
                {
                    return -1;
                }

                // Fail to check version
                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    CheckContinueProc(out_node, false);
                    return -1;
                }

                // Get version 
                // For SE : "UPGRADE_OPTION_6" GCM table data_2
                MPGV.gsServerVersion = out_node.GetString("SERVER_VERSION");

                // Do you wish to download the latest version?
                if (MPCF.ShowMsgBox(MPCF.GetMessage(11), MessageBoxButtons.YesNo, MSG_LEVEL.NONE, "") == DialogResult.No)
                {
                    return 0;
                }

                // MESSAGE UPGRAGE
                if (out_node.GetString("UPGRADE_METHOD") == "MSG")
                {
#if _H101
                    // 1. Upgrade File Setting
                    MPGV.gsUpgradeFile = "SOIUpgradeMsg.exe";

                    // 2. Get Upgrade File Version
                    if (File.Exists(Application.StartupPath + "\\" + MPGV.gsUpgradeFile) == true)
                    {
                        // Assembly File Version
                        UpgradeExe = System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\" + MPGV.gsUpgradeFile);
                        UpgradeVersion = UpgradeExe.FileVersion;
                    }
                    else
                    {
                        UpgradeVersion = "0.0.0.0";
                    }

                    // 3. Delete Old Upgrade File
                    if (File.Exists(Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old") == true)
                    {
                        File.Delete(Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old");
                    }

                    // 4. Current Upgrade File to Old File
                    if (UpgradeVersion == "0.0.0.0")
                    {
                    }
                    else if (UpgradeVersion != out_node.GetString("UPGRADE_VERSION"))
                    {
                        File.Copy(Application.StartupPath + "\\" + MPGV.gsUpgradeFile, Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old", true);
                        File.Delete(Application.StartupPath + "\\" + MPGV.gsUpgradeFile);
                    }

                    // 5. Download New Upgrade File
                    if (UpgradeVersion == "0.0.0.0" ||
                        UpgradeVersion != out_node.GetString("UPGRADE_VERSION"))
                    {
                        TRSNode min_node = new TRSNode("UPGRADE_MSG_IN");
                        TRSNode mout_node = new TRSNode("UPGRADE_MSG_OUT");
                        SetInMsg(min_node);
                        min_node.ProcStep = '1';
                        min_node.AddString("FILE_NAME", MPGV.gsUpgradeFile);
                        if (CallService("BAS", "BAS_Upgrade_Msg", min_node, ref mout_node, DeliveryMode.RReply, true) == false)
                        {
                            ShowMessage(mout_node.GetString("MSG"), MSG_LEVEL.ERROR, true);
                            return -1;
                        }
                        if (mout_node.StatusValue == MPGC.MP_FAIL_STATUS)
                        {
                            return -1;
                        }
                        FileStream fs = File.Open(Application.StartupPath + "\\" + MPGV.gsUpgradeFile, FileMode.Create);
                        BinaryWriter bw = new BinaryWriter(fs);
                        byte[] buffer;
                        fs.Flush();
                        buffer = mout_node.GetBlob(MPGC.MP_BIN_DATA_2);
                        bw.Write(buffer);
                        bw.Close();
                        fs.Close();
                    }

                    // 6. New Upgrade Folder
                    String upgradePath = Application.StartupPath + "\\_upgrade";
                    if (Directory.Exists(upgradePath) == false)
                    {
                        Directory.CreateDirectory(upgradePath);
                    }
                    File.Copy(Application.StartupPath + "\\" + MPGV.gsUpgradeFile, upgradePath + "\\" + MPGV.gsUpgradeFile, true);
                    File.Copy(Application.StartupPath + "\\" + "ICSharpCode.SharpZipLib.dll", upgradePath + "\\" + "ICSharpCode.SharpZipLib.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "Miracom.TRSConvertor.dll", upgradePath + "\\" + "Miracom.TRSConvertor.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "Miracom.TRSCore.dll", upgradePath + "\\" + "Miracom.TRSCore.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "SOI.MsgHandlerH101.dll", upgradePath + "\\" + "SOI.MsgHandlerH101.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "SOI.MsgHandlerHTTP.dll", upgradePath + "\\" + "SOI.MsgHandlerHTTP.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "SOI.CliFrx.dll", upgradePath + "\\" + "SOI.CliFrx.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "SOI.OIFrx.dll", upgradePath + "\\" + "SOI.OIFrx.dll", true);
                    if (MPIF.gInit.getMiddleware == "H101")
                    {
                        File.Copy(Application.StartupPath + "\\" + "transceiverxnet.dll", upgradePath + "\\" + "transceiverxnet.dll", true);
                    }

                    // 7. Start Upgrade File
                    ProcessStartInfo StartInfo = new ProcessStartInfo();
                    StartInfo.FileName = Application.StartupPath + "\\_upgrade" + "\\" + MPGV.gsUpgradeFile;
                    // Args[0] : Connection String = Address
                    // Args[1] : Site ID
                    // Args[2] : Download File List = "SOIDownloadFile.xml"
                    StartInfo.Arguments = MPGV.gsRemoteAddress + " "
                        + MPGV.gsSiteID + " "
                        + MPGV.gsDownloadFileList + " "
                        + MPGV.gsRvService + " "
                        + MPGV.gsRvNetwork;
                    System.Diagnostics.Process.Start(StartInfo);
#endif
#if _Http
                    // 1. Upgrade File Setting
                    MPGV.gsUpgradeFile = "SOIUpgradeMsg.exe";

                    // 2. Get Upgrade File Version
                    if (File.Exists(Application.StartupPath + "\\" + MPGV.gsUpgradeFile) == true)
                    {
                        // Assembly File Version
                        UpgradeExe = System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\" + MPGV.gsUpgradeFile);
                        UpgradeVersion = UpgradeExe.FileVersion;
                    }
                    else
                    {
                        UpgradeVersion = "0.0.0.0";
                    }

                    // 3. Delete Old Upgrade File
                    if (File.Exists(Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old") == true)
                    {
                        File.Delete(Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old");
                    }

                    // 4. Current Upgrade File to Old File
                    if (UpgradeVersion == "0.0.0.0")
                    {
                    }
                    else if (UpgradeVersion != out_node.GetString("UPGRADE_VERSION"))
                    {
                        //File.Copy(Application.StartupPath + "\\" + MPGV.gsUpgradeFile, Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old", true);
                        //File.Delete(Application.StartupPath + "\\" + MPGV.gsUpgradeFile);
                    }

                    // 5. Download New Upgrade File
                    if (UpgradeVersion == "0.0.0.0" ||
                        UpgradeVersion != out_node.GetString("UPGRADE_VERSION"))
                    {
                        //TRSNode min_node = new TRSNode("UPGRADE_MSG_IN");
                        //TRSNode mout_node = new TRSNode("UPGRADE_MSG_OUT");
                        //SetInMsg(min_node);
                        //min_node.ProcStep = '1';
                        //min_node.AddString("FILE_NAME", MPGV.gsUpgradeFile);
                        //if (CallService("BAS", "BAS_Upgrade_Msg", min_node, ref mout_node, DeliveryMode.RReply, true) == false)
                        //{
                        //    ShowMessage(mout_node.GetString("MSG"), MSG_LEVEL.ERROR, true);
                        //    return -1;
                        //}
                        //if (mout_node.StatusValue == MPGC.MP_FAIL_STATUS)
                        //{
                        //    return -1;
                        //}
                        //FileStream fs = File.Open(Application.StartupPath + "\\" + MPGV.gsUpgradeFile, FileMode.Create);
                        //BinaryWriter bw = new BinaryWriter(fs);
                        //byte[] buffer;
                        //fs.Flush();
                        //buffer = mout_node.GetBlob(MPGC.MP_BIN_DATA_2);
                        //bw.Write(buffer);
                        //bw.Close();
                        //fs.Close();
                    }

                    // 6. New Upgrade Folder
                    String upgradePath = Application.StartupPath + "\\_upgrade";
                    if (Directory.Exists(upgradePath) == false)
                    {
                        Directory.CreateDirectory(upgradePath);
                    }
                    File.Copy(Application.StartupPath + "\\" + MPGV.gsUpgradeFile, upgradePath + "\\" + MPGV.gsUpgradeFile, true);
                    File.Copy(Application.StartupPath + "\\" + "ICSharpCode.SharpZipLib.dll", upgradePath + "\\" + "ICSharpCode.SharpZipLib.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "Miracom.TRSConvertor.dll", upgradePath + "\\" + "Miracom.TRSConvertor.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "Miracom.TRSCore.dll", upgradePath + "\\" + "Miracom.TRSCore.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "SOI.MsgHandlerH101.dll", upgradePath + "\\" + "SOI.MsgHandlerH101.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "SOI.MsgHandlerHTTP.dll", upgradePath + "\\" + "SOI.MsgHandlerHTTP.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "SOI.CliFrx.dll", upgradePath + "\\" + "SOI.CliFrx.dll", true);
                    File.Copy(Application.StartupPath + "\\" + "SOI.OIFrx.dll", upgradePath + "\\" + "SOI.OIFrx.dll", true);
                    if (MPIF.gInit.getMiddleware == "H101")
                    {
                        File.Copy(Application.StartupPath + "\\" + "transceiverxnet.dll", upgradePath + "\\" + "transceiverxnet.dll", true);
                    }

                    // 7. Start Upgrade File
                    ProcessStartInfo StartInfo = new ProcessStartInfo();
                    StartInfo.FileName = Application.StartupPath + "\\_upgrade" + "\\" + MPGV.gsUpgradeFile;
                    // Args[0] : Connection String = Address
                    // Args[1] : File ID of UPGRADE_OPTION_6
                    // Args[2] : USER ID@FACTORY
                    // Args[3] : PASSWORD
                    //StartInfo.Arguments = MPGV.gsRemoteAddress + " "
                    //    + out_node.GetString("UPGRADE_FILE_ID") + " "
                    //    + "StandardOI.exe";                        
                    StartInfo.Arguments = MPGV.gsRemoteAddress + " "
                    + out_node.GetString("UPGRADE_FILE_ID") + " "
                    + MPGV.gsUserID + "@" + MPGV.gsFactory + " " 
                    + MPGV.gsPassword;     
                    System.Diagnostics.Process.Start(StartInfo);
#endif
                }
                // FTP UPGRADE
                else
                {
                    // 1. Upgrade File Setting
                    MPGV.gsUpgradeFile = "SOIUpgradeFtp.exe";

                    // 2. Get Upgrade File Version
                    if (File.Exists(Application.StartupPath + "\\" + MPGV.gsUpgradeFile) == true)
                    {
                        // Assembly File Version
                        UpgradeExe = System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\" + MPGV.gsUpgradeFile);
                        UpgradeVersion = UpgradeExe.FileVersion;
                    }
                    else
                    {
                        UpgradeVersion = "0.0.0.0";
                    }

                    // 3. Delete Old Upgrade File
                    if (File.Exists(Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old") == true)
                    {
                        File.Delete(Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old");
                    }

                    // 5. Download New Upgrade File
                    if (UpgradeVersion == "0.0.0.0")
                    {
                        ftp = new FTPClient.FTPConnection();
                        ftp.Open(out_node.GetString("UPGRADE_ADDRESS"), 21, out_node.GetString("UPGRADE_USER_ID"), out_node.GetString("UPGRADE_PASSWORD"), FTPClient.FTPMode.Passive);
                        ftp.ChangeDirectory(out_node.GetString("UPGRADE_DIRECTORY"));
                        ftp.GetFile(MPGV.gsUpgradeFile, FTPClient.FTPFileTransferType.Binary);
                        ftp.Close();
                    }
                    else if (UpgradeVersion != out_node.GetString("UPGRADE_VERSION"))
                    {
                        // 4. Current upgrade file to old upgrade file
                        File.Copy(Application.StartupPath + "\\" + MPGV.gsUpgradeFile, Application.StartupPath + "\\" + MPGV.gsUpgradeFile + ".old", true);
                        File.Delete(Application.StartupPath + "\\" + MPGV.gsUpgradeFile);

                        ftp = new FTPClient.FTPConnection();
                        ftp.Open(out_node.GetString("UPGRADE_ADDRESS"), 21, out_node.GetString("UPGRADE_USER_ID"), out_node.GetString("UPGRADE_PASSWORD"), FTPClient.FTPMode.Passive);
                        ftp.ChangeDirectory(out_node.GetString("UPGRADE_DIRECTORY"));
                        ftp.GetFile(MPGV.gsUpgradeFile, FTPClient.FTPFileTransferType.Binary);
                        ftp.Close();
                    }

                    // 7. Start Upgrade File
                    ProcessStartInfo StartInfo = new ProcessStartInfo();
                    StartInfo.FileName = Application.StartupPath + "\\" + MPGV.gsUpgradeFile;
                    // Args[1] : FTP IP = Upgrade Address in config file.
                    // Args[2] : User Name = User Name in config file.
                    // Args[3] : Password = Password in config file.
                    // Args[4] : Server Path = Upgrade Dir in config file.
                    // Args[5] : Download File List = "SOIDownloadFile.xml"
                    StartInfo.Arguments = out_node.GetString("UPGRADE_ADDRESS") + " "
                        + out_node.GetString("UPGRADE_USER_ID") + " "
                        + out_node.GetString("UPGRADE_PASSWORD") + " "
                        + out_node.GetString("UPGRADE_DIRECTORY") + " "
                        + MPGV.gsDownloadFileList;
                    System.Diagnostics.Process.Start(StartInfo);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// Flexible Screen 출력 이력을 저장한다.
        /// </summary>
        /// <param name="printId"></param>
        /// <param name="printType"></param>
        /// <param name="screenId"></param>
        /// <param name="serviceName"></param>
        /// <param name="printParams"></param>
        /// <param name="matId"></param>
        /// <param name="matVer"></param>
        /// <param name="flow"></param>
        /// <param name="oper"></param>
        /// <param name="resId"></param>
        /// <param name="funcName"></param>
        /// <param name="orderId"></param>
        /// <param name="lotId"></param>
        /// <returns></returns>
        public static bool UpdatePrintScreenHistory(SOIFlexibleScreen target, string printId, string serviceName)
        {
            return UpdatePrintScreenHistory(target, printId, serviceName, null);
        }

        /// <summary>
        /// Flexible Screen 출력 이력을 저장한다.
        /// Innode에 필요한 CMF값을 추가한다.
        /// </summary>
        /// <param name="printId"></param>
        /// <param name="printType"></param>
        /// <param name="screenId"></param>
        /// <param name="serviceName"></param>
        /// <param name="printParams"></param>
        /// <param name="matId"></param>
        /// <param name="matVer"></param>
        /// <param name="flow"></param>
        /// <param name="oper"></param>
        /// <param name="resId"></param>
        /// <param name="funcName"></param>
        /// <param name="orderId"></param>
        /// <param name="lotId"></param>
        /// <returns></returns>
        public static bool UpdatePrintScreenHistory(SOIFlexibleScreen target, string printId, string serviceName, TRSNode inNode)
        {
            TRSNode in_node = new TRSNode("UPDATE_PRINT_SCREEN_IN");
            TRSNode out_node = new TRSNode("UPDATE_PRINT_SCREEN_OUT");

            try
            {
                if (inNode != null)
                {
                    in_node = inNode;
                }
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = target.ProcStep;
                in_node.AddString("PRINT_ID", printId);
                in_node.AddString("PRINT_TYPE", target.PrintType);
                in_node.AddString("SCREEN_ID", target.ScreenID);
                in_node.AddString("SERVICE_NAME", serviceName);
                in_node.AddString("PRINT_PARAMS", target.PrintParamsXml);
                in_node.AddString("MAT_ID", target.MatID);
                in_node.AddInt("MAT_VER", target.MatVer);
                in_node.AddString("FLOW", target.Flow);
                in_node.AddString("OPER", target.Oper);
                in_node.AddString("RES_ID", target.ResID);
                in_node.AddString("RESG_ID", target.ResGroup);
                in_node.AddString("CUSTOMER_ID", target.CustomerId);
                in_node.AddString("FUNC_NAME", target.OwnerFuncName);
                in_node.AddString("ORDER_ID", target.OrderId);
                in_node.AddString("LOT_ID", target.LotID);
                if (MPCF.CallService("BAS", "BAS_Print_Screen", in_node, ref out_node) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion

        #region WIP

        /// <summary>
        /// Get Factory Shit Information
        /// </summary>
        /// <returns></returns>
        public static bool GetFactoryShiftInfor()
        {
            TRSNode in_node = new TRSNode("VIEW_FACTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_FACTORY_OUT");

            try
            {
                SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (CallService("WIP", "WIP_View_Factory", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPGV.gShiftInfor.bVariableShift = out_node.GetChar("VARIABLE_SHIFT_FLAG") == 'Y' ? true : false;

                if (MPGV.gShiftInfor.bVariableShift == false)
                {
                    if (out_node.GetString("SHIFT_1_START") != "")
                    {
                        MPGV.gShiftInfor.cShift1DayFlag = out_node.GetChar("SHIFT_1_DAY_FLAG");
                        MPGV.gShiftInfor.sShift1StartTime = out_node.GetString("SHIFT_1_START") + "00";
                    }
                    if (out_node.GetString("SHIFT_2_START") != "")
                    {
                        MPGV.gShiftInfor.cShift2DayFlag = out_node.GetChar("SHIFT_2_DAY_FLAG");
                        MPGV.gShiftInfor.sShift2StartTime = out_node.GetString("SHIFT_2_START") + "00";
                    }
                    if (out_node.GetString("SHIFT_3_START") != "")
                    {
                        MPGV.gShiftInfor.cShift3DayFlag = out_node.GetChar("SHIFT_3_DAY_FLAG");
                        MPGV.gShiftInfor.sShift3StartTime = out_node.GetString("SHIFT_3_START") + "00";
                    }
                    if (out_node.GetString("SHIFT_4_START") != "")
                    {
                        MPGV.gShiftInfor.cShift4DayFlag = out_node.GetChar("SHIFT_4_DAY_FLAG");
                        MPGV.gShiftInfor.sShift4StartTime = out_node.GetString("SHIFT_4_START") + "00";
                    }

                    if (MPGV.gShiftInfor.sShift1StartTime != "")
                    {
                        MPGV.gShiftInfor.iShiftCount = 1;
                    }
                    if (MPGV.gShiftInfor.sShift2StartTime != "")
                    {
                        MPGV.gShiftInfor.iShiftCount = 2;
                    }
                    if (MPGV.gShiftInfor.sShift3StartTime != "")
                    {
                        MPGV.gShiftInfor.iShiftCount = 3;
                    }
                    if (MPGV.gShiftInfor.sShift4StartTime != "")
                    {
                        MPGV.gShiftInfor.iShiftCount = 4;
                    }
                }
                else
                {
                    MPGV.gShiftInfor.iShiftCount = 0;
                    MPGV.gShiftInfor.sShift1StartTime = "000000";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("GetFactoryShiftInfor() Failed.\n" + ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Ext Code to Table Name
        /// </summary>
        /// <param name="s_lot_id"></param>
        /// <param name="s_option_name"></param>
        /// <returns></returns>
        public static string GetExtCodeTable(string s_lot_id, string s_option_name)
        {
            TRSNode in_node = new TRSNode("TBL_IN");
            TRSNode out_node = new TRSNode("TBL_OUT");

            SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", s_lot_id);
            in_node.AddString("OPTION_NAME", s_option_name);

            if (CallService("WIP", "WIP_View_Ext_Code_Table", in_node, ref out_node) == false)
            {
                return "";
            }

            return out_node.GetString("TABLE_NAME");
        }

        #endregion

        #region SEC

        /// <summary>
        /// Login 정보를 조회한다.
        /// </summary>
        /// <param name="UpgradeFlag"></param>
        /// <returns></returns>
        public static bool SEC_Login_Ext(ref bool UpgradeFlag)
        {
            TRSNode in_node = new TRSNode("LOGIN_EXT_IN");
            TRSNode out_node = new TRSNode("LOGIN_EXT_OUT");

            try
            {
                // IN 
                UpgradeFlag = false;
                SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("PROGRAM_ID", Application.ProductName);

                // Call 
                if (MessageCaster.CallService("SEC", "SEC_Login_Ext", in_node, ref out_node) == false)
                {
                    ShowMessage(MPMH.StatusMessage, MSG_LEVEL.ERROR, true);
                    return false;
                }

                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    CheckContinueProc(out_node, true);

                    //ShowMessage(out_node.GetString(TRSDefine.OUT_MSG), MSG_LEVEL.ERROR, true);
                    return false;
                }

                // OUT
                MPGV.gsUserGroup = out_node.GetString("SEC_GRP_ID");
                if (out_node.GetChar("AUTO_UPGRADE_FLAG") == '2')
                {
                    MPGV.gcAutoUpgrade = '2';
                }
                else if (out_node.GetChar("AUTO_UPGRADE_FLAG") == '3')
                {
                    MPGV.gcAutoUpgrade = '3';
                }
                else
                {
                    MPGV.gcAutoUpgrade = '1';
                }

                if (out_node.GetChar("USE_SAMLL_LETTER_FLAG") == 'Y')
                {
                    MPGV.gbUseSmallLetter = true;
                }
                else
                {
                    MPGV.gbUseSmallLetter = false;
                }

                if (out_node.GetChar("CASE_SENSITIVE_FLAG") == 'Y')
                {
                    TRSNodeTool.IsCaseSensitiveName = true;
                }
                else
                {
                    TRSNodeTool.IsCaseSensitiveName = false;
                }

                MPGV.gcChangePassword = out_node.GetChar("PASSWORD_CHANGE_FLAG");
                MPGV.gsServerVersion = out_node.GetString("SERVER_VERSION");

#if _Http
                if (out_node.GetString("MESSAGING_LOCATION") != "")
                {
                    int i = 0;

                    // Cometd Server Location
                    MPGV.gsMessagingLocation = out_node.GetString("MESSAGING_LOCATION");

                    // Alarm push service channel
                    TRSNode list = out_node.GetArray("ALM_CHANNELS");

                    if (list != null)
                    {
                        for (i = 0; i < list.MemberCount; i++)
                        {
                            MPGV.gaALMChannel.Add(list.GetString(i.ToString()));
                        }
                    }

                    // Util push service channel
                    list = out_node.GetArray("UTL_CHANNELS");
                    if (list != null)
                    {
                        for (i = 0; i < list.MemberCount; i++)
                        {
                            MPGV.gaUTLChannel.Add(list.GetString(i.ToString()));
                        }
                    }
                }

                MPGV.gsChannelPrefix = out_node.GetString("SITE_ID");
#endif
                if (MPGV.gsServerVersion == MPGV.gsClientVersion)
                {
                    return true;
                }
                else
                {
                    if (MPGV.gcAutoUpgrade == '1')
                    {
                        if (MPCF.ShowMsgBox(MPCF.GetMessage(9), MessageBoxButtons.YesNo, MSG_LEVEL.NONE, "") == DialogResult.No)
                        {
                            return true;
                        }
                    }
                    else if (MPGV.gcAutoUpgrade == '2')
                    {

                    }
                    else if (MPGV.gcAutoUpgrade == '3')
                    {
                        return true;
                    }
                }

                if (Client_Upgrade(2) != 1)
                {
                    return false;
                }

                UpgradeFlag = true;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }


        }

        /// <summary>
        /// Security를 확인합니다.
        /// </summary>
        /// <param name="frm"></param>
        /// <returns></returns>
        public static bool CheckSecurityFormControl(Form frm)
        {
            TRSNode in_node = new TRSNode("VIEW_FUNCTION_DETAIL_IN");
            TRSNode out_node = new TRSNode("VIEW_FUNCTION_DETAIL_OUT");
            string sFuncName;
            FuncCtrlList[] CtrlList = new FuncCtrlList[10];

            try
            {
                // Form Tag가 없는 경우
                if (MPCF.Trim(frm.Tag) == "")
                {
                    return false;
                }
                else
                {
                    sFuncName = ((MenuInfoTag)frm.Tag).s_func_name;
                }

                SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("PROGRAM_ID", MPGV.gsProgramID);
                in_node.AddString("FUNC_NAME", sFuncName);

                if (CallService("SEC", "SEC_View_Function_Detail", in_node, ref out_node) == false)
                {
                    return false;
                }

                CtrlList[0].ctrlName = out_node.GetString("CTL_NAME_1");
                CtrlList[0].ctrlValue = out_node.GetChar("CTL_EN_FLAG_1").ToString();
                CtrlList[1].ctrlName = out_node.GetString("CTL_NAME_2");
                CtrlList[1].ctrlValue = out_node.GetChar("CTL_EN_FLAG_2").ToString();
                CtrlList[2].ctrlName = out_node.GetString("CTL_NAME_3");
                CtrlList[2].ctrlValue = out_node.GetChar("CTL_EN_FLAG_3").ToString();
                CtrlList[3].ctrlName = out_node.GetString("CTL_NAME_4");
                CtrlList[3].ctrlValue = out_node.GetChar("CTL_EN_FLAG_4").ToString();
                CtrlList[4].ctrlName = out_node.GetString("CTL_NAME_5");
                CtrlList[4].ctrlValue = out_node.GetChar("CTL_EN_FLAG_5").ToString();
                CtrlList[5].ctrlName = out_node.GetString("CTL_NAME_6");
                CtrlList[5].ctrlValue = out_node.GetChar("CTL_EN_FLAG_6").ToString();
                CtrlList[6].ctrlName = out_node.GetString("CTL_NAME_7");
                CtrlList[6].ctrlValue = out_node.GetChar("CTL_EN_FLAG_7").ToString();
                CtrlList[7].ctrlName = out_node.GetString("CTL_NAME_8");
                CtrlList[7].ctrlValue = out_node.GetChar("CTL_EN_FLAG_8").ToString();
                CtrlList[8].ctrlName = out_node.GetString("CTL_NAME_9");
                CtrlList[8].ctrlValue = out_node.GetChar("CTL_EN_FLAG_9").ToString();
                CtrlList[9].ctrlName = out_node.GetString("CTL_NAME_10");
                CtrlList[9].ctrlValue = out_node.GetChar("CTL_EN_FLAG_10").ToString();
                CheckSecurityFormControlSub(frm, "BUTTON", CtrlList);
                CheckSecurityFormControlSub(frm, "CHECK", CtrlList);

                CtrlList[0].ctrlName = out_node.GetString("TAB_NAME_1");
                CtrlList[0].ctrlValue = out_node.GetChar("TAB_DS_FLAG_1").ToString();
                CtrlList[1].ctrlName = out_node.GetString("TAB_NAME_2");
                CtrlList[1].ctrlValue = out_node.GetChar("TAB_DS_FLAG_2").ToString();
                CtrlList[2].ctrlName = out_node.GetString("TAB_NAME_3");
                CtrlList[2].ctrlValue = out_node.GetChar("TAB_DS_FLAG_3").ToString();
                CtrlList[3].ctrlName = out_node.GetString("TAB_NAME_4");
                CtrlList[3].ctrlValue = out_node.GetChar("TAB_DS_FLAG_4").ToString();
                CtrlList[4].ctrlName = out_node.GetString("TAB_NAME_5");
                CtrlList[4].ctrlValue = out_node.GetChar("TAB_DS_FLAG_5").ToString();
                CtrlList[5].ctrlName = out_node.GetString("TAB_NAME_6");
                CtrlList[5].ctrlValue = out_node.GetChar("TAB_DS_FLAG_6").ToString();
                CtrlList[6].ctrlName = out_node.GetString("TAB_NAME_7");
                CtrlList[6].ctrlValue = out_node.GetChar("TAB_DS_FLAG_7").ToString();
                CtrlList[7].ctrlName = out_node.GetString("TAB_NAME_8");
                CtrlList[7].ctrlValue = out_node.GetChar("TAB_DS_FLAG_8").ToString();
                CtrlList[8].ctrlName = out_node.GetString("TAB_NAME_9");
                CtrlList[8].ctrlValue = out_node.GetChar("TAB_DS_FLAG_9").ToString();
                CtrlList[9].ctrlName = out_node.GetString("TAB_NAME_10");
                CtrlList[9].ctrlValue = out_node.GetChar("TAB_DS_FLAG_10").ToString();
                CheckSecurityFormControlTabpage(frm, CtrlList);

                CtrlList[0].ctrlName = out_node.GetString("OPT_NAME_1");
                CtrlList[0].ctrlValue = out_node.GetString("OPT_VALUE_1");
                CtrlList[1].ctrlName = out_node.GetString("OPT_NAME_2");
                CtrlList[1].ctrlValue = out_node.GetString("OPT_VALUE_2");
                CtrlList[2].ctrlName = out_node.GetString("OPT_NAME_3");
                CtrlList[2].ctrlValue = out_node.GetString("OPT_VALUE_3");
                CtrlList[3].ctrlName = out_node.GetString("OPT_NAME_4");
                CtrlList[3].ctrlValue = out_node.GetString("OPT_VALUE_4");
                CtrlList[4].ctrlName = out_node.GetString("OPT_NAME_5");
                CtrlList[4].ctrlValue = out_node.GetString("OPT_VALUE_5");
                CtrlList[5].ctrlName = out_node.GetString("OPT_NAME_6");
                CtrlList[5].ctrlValue = out_node.GetString("OPT_VALUE_6");
                CtrlList[6].ctrlName = out_node.GetString("OPT_NAME_7");
                CtrlList[6].ctrlValue = out_node.GetString("OPT_VALUE_7");
                CtrlList[7].ctrlName = out_node.GetString("OPT_NAME_8");
                CtrlList[7].ctrlValue = out_node.GetString("OPT_VALUE_8");
                CtrlList[8].ctrlName = out_node.GetString("OPT_NAME_9");
                CtrlList[8].ctrlValue = out_node.GetString("OPT_VALUE_9");
                CtrlList[9].ctrlName = out_node.GetString("OPT_NAME_10");
                CtrlList[9].ctrlValue = out_node.GetString("OPT_VALUE_10");
                CheckSecurityFormControlSub(frm, "OPTION", CtrlList);

                //Delete by ICBAE 2012.06.08 - Field Mask 기능 삭제
                //만약필드컨트롤하고모든필드사용이아니면필드컨트롤루틴으로들어간다.
                //if (out_node.GetChar("FLD_EN_MASK_USE_FLAG") == 'Y' && out_node.GetChar("FLD_EN_ALL_FLAG") == ' ')
                //{
                //    iFieldSeq = 1;
                //    CheckSecurityFormControlField(frm, out_node.GetString("FLD_EN_MASK"));
                //}

                SetDisableFormControls(frm, out_node);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 정의된 버튼을 Enable, Disable 한다.
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="ctrlType"></param>
        /// <param name="ctrlList"></param>
        private static void CheckSecurityFormControlSub(Control ctrl, string ctrlType, params FuncCtrlList[] ctrlList)
        {
            Control control;
            bool bFindControl;
            string ctrlValue = "";

            foreach (Control tempLoopVar_control in ctrl.Controls)
            {
                control = tempLoopVar_control;

                if (control is Panel || 
                    control is GroupBox || 
                    control is TabControl || 
                    control is TabPage ||
                    control is SplitContainer ||
                    control is SOIPanel ||
                    control is SOIGroupBox ||
                    control is SOITabControl ||
                    control is SOISplitContainer ||
                    control is SOITableLayoutPanel)
                {
                    CheckSecurityFormControlSub(control, ctrlType, ctrlList);
                }
                else
                {
                    bFindControl = false;
                    switch (ctrlType)
                    {
                        case "BUTTON":

                            //if (!(control is Button))
                            //{
                            //    goto NextControl;
                            //}
                            if (!(control is SOIButton))
                            {
                                goto NextControl;
                            }
                            break;
                        case "CHECK":

                            //if (!(control is CheckBox))
                            //{
                            //    goto NextControl;
                            //}
                            if (!(control is SOICheckBox))
                            {
                                goto NextControl;
                            }
                            break;
                        case "OPTION":

                            // Do nothing
                            break;

                    }

                    for (int i = 0; i < 10; i++)
                    {
                        if (ctrlList[i].ctrlName == null)
                            ctrlList[i].ctrlName = "";
                    }

                    if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[0].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[0].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[1].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[1].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[2].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[2].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[3].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[3].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[4].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[4].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[5].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[5].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[6].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[6].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[7].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[7].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[8].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[8].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[9].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[9].ctrlValue;
                    }

                    if (control.Name == "btnClose")
                    {
                        // Close Button is always enabled.
                    }
                    else if (bFindControl == true)
                    {
                        switch (ctrlType)
                        {
                            case "BUTTON":

                                if (ctrlValue == "Y")
                                {
                                    //Load에서 처리 함으로 Disable될것만 처리한다
                                    //control.Enabled = True
                                }
                                else
                                {
                                    control.Enabled = false;
                                }
                                break;
                            case "CHECK":

                                if (ctrlValue == "Y")
                                {
                                    //Load에서 처리 함으로 Disable될것만 처리한다
                                    //control.Enabled = True
                                }
                                else
                                {
                                    control.Enabled = false;
                                }
                                break;

                            case "OPTION":

                                if (ctrlValue == "Y")
                                {
                                    control.Enabled = false;
                                }
                                break;

                        }
                    }
                }
            NextControl:
                1.GetHashCode(); //nop
            }

        }

        /// <summary>
        /// Tab Page를 Enable, Disable 한다.
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="ctrlList"></param>
        private static void CheckSecurityFormControlTabpage(Control ctrl, params FuncCtrlList[] ctrlList)
        {
            Control control;
            bool bFindControl;
            string ctrlValue = "";

            foreach (Control tempLoopVar_control in ctrl.Controls)
            {
                control = tempLoopVar_control;

                if (!(control is TabPage))
                {
                    if (control is Panel || control is GroupBox || control is TabControl)
                    {
                        CheckSecurityFormControlTabpage(control, ctrlList);
                    }
                }
                else if (control is TabPage)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (ctrlList[i].ctrlName == null)
                            ctrlList[i].ctrlName = "";
                    }

                    bFindControl = false;

                    if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[0].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[0].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[1].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[1].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[2].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[2].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[3].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[3].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[4].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[4].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[5].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[5].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[6].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[6].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[7].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[7].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[8].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[8].ctrlValue;
                    }
                    else if (MPCF.ToUpper(control.Name) == MPCF.ToUpper(ctrlList[9].ctrlName))
                    {
                        bFindControl = true;
                        ctrlValue = ctrlList[9].ctrlValue;
                    }

                    if (bFindControl == true)
                    {
                        if (ctrlValue == "Y")
                        {
                            CheckSecurityFormControlTabpageField(control);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// TabPage 안에 포함된 모든 필드를 Disable 한다.
        /// </summary>
        /// <param name="ctrl"></param>
        private static void CheckSecurityFormControlTabpageField(Control ctrl)
        {
            Control control;

            try
            {
                foreach (Control tempLoopVar_control in ctrl.Controls)
                {
                    control = tempLoopVar_control;

                    if (control is Panel || control is GroupBox || control is TabControl || control is TabPage)
                    {
                        CheckSecurityFormControlTabpageField(control);
                    }
                    else
                    {
                        if (control is TextBox || control is ComboBox ||
                            //control is Miracom.UI.Controls.MCCodeView.MCCodeView || 
                            control is FarPoint.Win.Spread.FpSpread || control is CheckBox || control is Infragistics.Win.UltraWinEditors.UltraTextEditor ||
                            control is NumericUpDown || control is RadioButton || control is DateTimePicker || control is ListView ||
                            control is Button || control is TreeView)
                        {
                            control.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(iFieldSeq + ":" + "ERROR" + ex.Message);
            }
        }

        /// <summary>
        /// Disable 부분을 설정한다.
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="out_node"></param>
        private static void SetDisableFormControls(Form frm, TRSNode out_node)
        {
            ArrayList disabled_controls;
            MemberInfo[] members = frm.GetType().GetMember("DisabledFormControls", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            if (members.Length < 1)
            {
                return;
            }

            disabled_controls = (ArrayList)(frm.GetType().InvokeMember("DisabledFormControls", BindingFlags.GetField | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, frm, null));

            if (disabled_controls != null)
            {
                for (int i = 1; i <= 10; i++)
                {
                    if (out_node.GetChar("CTL_EN_FLAG_" + i.ToString()) != 'Y')
                    {
                        disabled_controls.Add(out_node.GetString("CTL_NAME_" + i.ToString()));
                    }
                }
            }
        }

        #endregion
        
        #region SPC
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
        // Find_Spec_Version()
        //       - Find Spec Version
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public static bool Find_Spec_Version(char c_step, string sChartID, ref int iSpecVer, bool bIgnoreError)
        {

            try
            {
                TRSNode in_node = new TRSNode("View_Event_In");
                TRSNode out_node = new TRSNode("View_Event_Out");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("CHART_ID", sChartID);

                if (MPCF.CallService("SPC", "SPC_Find_Spec_Version", in_node, ref out_node, bIgnoreError) == false)
                {
                    return false;
                }

                iSpecVer = out_node.GetInt("VERSION");

                if (iSpecVer < 1)
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
        public static void SetNumberCell(FarPoint.Win.Spread.Column Column)
        {
            //Localization 지원 되지 않음
            //FarPoint.Win.Spread.CellType.NumberCellType typeNumber = new FarPoint.Win.Spread.CellType.NumberCellType();

            try
            {
                /*
                typeNumber.DecimalPlaces = 10;
                typeNumber.FixedPoint = false;
                typeNumber.MaximumValue = 9999999999;
                typeNumber.MinimumValue = - 9999999999;
                typeNumber.Separator = ",";
                typeNumber.ShowSeparator = true;
                
                cell.CellType = typeNumber;
                 */

                Column.HorizontalAlignment = CellHorizontalAlignment.Right;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }
        public static void SetAsciiCell(FarPoint.Win.Spread.Column Column)
        {

            //FarPoint.Win.Spread.CellType.TextCellType typeAscii = new FarPoint.Win.Spread.CellType.TextCellType();

            try
            {
                //cell.CellType = typeAscii;
                Column.HorizontalAlignment = CellHorizontalAlignment.Left;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }
        // ViewSPCEDCData()
        //       - View Chart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public static bool ViewSPCEDCData(FarPoint.Win.Spread.FpSpread spdData, char c_step, string sChartID, string sFromTime, string sToTime, int iPrecision, int iAverageCol, int iUnitCount, char sUseUnit, string sValueType, int iHistSeq, int iUnitSeq, bool bShowTotal, char sShowExcludeData)
        {
            TRSNode in_node = new TRSNode("View_EDC_Data_In");
            TRSNode out_node;
            FarPoint.Win.Spread.SheetView sheet;
            ArrayList a_list = new ArrayList();
            int i;
            int j;
            int k;
            int result;
            int iRow;
            int iCol;
            int iLastCol = 0;
            int iNominalCol = 0;
            double dAverage;
            double dSigma;
            double dRange;
            double dMin;
            double dMax;
            double dValue;
            double dWeightValue = 0.0;
            int iOOCType = 0;
            int iOOCType2 = 0;
            int iCount = 0;
            int iWeightValueCount = 0;
            int iAverageCount = 0;
            int iSigmaCount = 0;
            int iRangeCount = 0;
            int iValueCount = 0;
            int iMaxCol = 0;

            try
            {
                FarPoint.Win.BevelBorder BevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
                dValue = 0;
                dAverage = 0;
                dSigma = 0;
                dRange = 0;
                dMin = double.MaxValue;
                dMax = 0;

                if (iUnitCount < 1) iUnitCount = 1;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("CHART_ID", sChartID);
                in_node.AddString("FROM_TIME", sFromTime);
                in_node.AddString("TO_TIME", sToTime);
                in_node.AddChar("INCLUDE_FLAG", sShowExcludeData);

                if (iHistSeq == -1)
                {
                    in_node.AddInt("NEXT_HIST_SEQ", int.MaxValue);
                }
                else
                {
                    in_node.AddInt("NEXT_HIST_SEQ", iHistSeq);
                }

                if (iUnitSeq == -1)
                {
                    in_node.AddInt("NEXT_UNIT_SEQ", int.MaxValue);
                }
                else
                {
                    in_node.AddInt("NEXT_UNIT_SEQ", iUnitSeq);
                }

                in_node.AddInt("NEXT_VALUE_SEQ", 0);

                MPCF.ClearList(spdData, true);

                sheet = spdData.ActiveSheet;
                do
                {
                    out_node = new TRSNode("View_EDC_Data_Out");
                    if (MessageCaster.CallService("SPC", "SPC_View_EDC_Data", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                    {
                        //MPCF.CheckContinueProc(out_node);
                        return false;
                    }

                    a_list.Add(out_node);

                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                    in_node.SetInt("NEXT_UNIT_SEQ", out_node.GetInt("NEXT_UNIT_SEQ"));
                    in_node.SetInt("NEXT_VALUE_SEQ", out_node.GetInt("NEXT_VALUE_SEQ"));

                } while (in_node.GetInt("NEXT_HIST_SEQ") > 0 || in_node.GetInt("NEXT_UNIT_SEQ") > 0 || in_node.GetInt("NEXT_VALUE_SEQ") > 0);

                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = sheet.RowCount;
                        sheet.RowCount++;
                        iCol = 0;

                        sheet.Cells[iRow, iCol].Value = sChartID;
                        iCol++;

                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("HIST_SEQ");
                        iCol++;

                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("UNIT_SEQ");
                        iCol++;

                        sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("LOT_RES_FLAG");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_ID");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("MAT_ID");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("MAT_DESC");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("MAT_VER");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("FLOW");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OPER");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("PROC_OPER");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RES_ID");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBRES_ID");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("PROC_RES_ID");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("EVENT_ID");

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UNIT_ID"));

                        iCol++;
                        iNominalCol = iCol;
                        if (sheet.Columns[iCol].Visible == true)
                        {
                            sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("NOMINAL")), iPrecision);
                        }
                        iCol++;

                        if (sheet.Columns[iCol].Visible == true)
                        {
                            sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("PROCESS_SIGMA")), iPrecision);
                        }
                        iCol++;

                        iValueCount = i + Math.DivRem((out_node.GetList(0)[i].GetInt("CAL_VAL_CNT") - 1), 25, out result);
                        for (j = i; j <= iValueCount; j++)
                        {
                            for (k = 0; k <= out_node.GetList(0)[j].GetInt("VALUE_COUNT") - 1; k++)
                            {
                                if (MPCF.Trim(out_node.GetList(0)[j].GetList(0)[k].GetString("VALUE")) != "")
                                {
                                    sheet.Cells[iRow, iCol].Value = MPCF.ToDbl(out_node.GetList(0)[j].GetList(0)[k].GetString("VALUE"));
                                }

                                iCol++;

                                if (MPCF.Trim(out_node.GetList(0)[j].GetList(0)[k].GetString("VALUE")) != "")
                                {
                                    dValue += MPCF.ToDbl(out_node.GetList(0)[j].GetList(0)[k].GetString("VALUE"));
                                    iCount++;
                                }

                            }
                        }
                        if (iMaxCol < iCol)
                        {
                            iMaxCol = iCol;
                        }

                        iLastCol = iCol - 1;
                        iCol = iAverageCol - 1;


                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("WEIGHT_VALUE")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("RANGE")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("MAX_VALUE")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("MIN_VALUE")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("USL")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("TARGET")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("LSL")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("UCL")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("CL")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("LCL")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("UCL2")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("CL2")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("LCL2")), iPrecision);

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("OOC_TYPE"));

                        iCol++;
                        sheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("OOC_TYPE2"));


                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("WEIGHT_VALUE")) != "")
                        {
                            dWeightValue += MPCF.ToDbl(out_node.GetList(0)[i].GetString("WEIGHT_VALUE"));
                            iWeightValueCount++;
                        }
                        if (MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")), iPrecision) != "")
                        {
                            dAverage += MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                            iAverageCount++;
                        }
                        if (MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV")), iPrecision) != "")
                        {
                            dSigma += MPCF.ToDbl(out_node.GetList(0)[i].GetString("STDDEV"));
                            iSigmaCount++;
                        }
                        if (MPCF.SetPrecision(MPCF.Trim(out_node.GetList(0)[i].GetString("RANGE")), iPrecision) != "")
                        {
                            dRange += MPCF.ToDbl(out_node.GetList(0)[i].GetString("RANGE"));
                            iRangeCount++;
                        }

                        if (dMin > MPCF.ToDbl(out_node.GetList(0)[i].GetString("MIN_VALUE")))
                        {
                            dMin = MPCF.ToDbl(out_node.GetList(0)[i].GetString("MIN_VALUE"));
                        }
                        if (dMax < MPCF.ToDbl(out_node.GetList(0)[i].GetString("MAX_VALUE")))
                        {
                            dMax = MPCF.ToDbl(out_node.GetList(0)[i].GetString("MAX_VALUE"));
                        }

                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("OOC_TYPE")) != "")
                        {
                            iOOCType++;
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("OOC_TYPE2")) != "")
                        {
                            iOOCType2++;
                        }

                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("EXCLUDE_FLAG")) == "Y")
                        {
                            sheet.Cells[iRow, 0, iRow, sheet.ColumnCount - 1].ForeColor = Color.Magenta;
                        }

                        i += Math.DivRem((out_node.GetList(0)[i].GetInt("CAL_VAL_CNT") - 1), 25, out result);
                    }
                }

                if (sUseUnit != 'Y')
                {
                    for (i = 0; i < spdData.ActiveSheet.RowCount; i += iUnitCount)
                    {
                        for (j = iAverageCol - 1; j < iAverageCol + 16; j++)
                        {
                            spdData.ActiveSheet.Cells[i, j].RowSpan = iUnitCount;
                        }
                        spdData.ActiveSheet.Cells[i, iNominalCol].RowSpan = iUnitCount;
                        spdData.ActiveSheet.Cells[i, iNominalCol + 1].RowSpan = iUnitCount;
                    }
                }

                if (sheet.RowCount > 0)
                {
                    for (i = VALUE_START_COL; i < iMaxCol; i++)
                    {
                        spdData.ActiveSheet.Columns[i].Visible = true;
                    }
                    for (i = iMaxCol; i <= VALUE_END_COL; i++)
                    {
                        spdData.ActiveSheet.Columns[i].Visible = false;
                    }

                    //if (sValueType == "N")
                    //{
                    //    dWeightValue /= iWeightValueCount;
                    //    dAverage /= iAverageCount;
                    //    dSigma /= iSigmaCount;
                    //    dRange /= iRangeCount;

                    //    if (bShowTotal == true)
                    //    {
                    //        if (sheet.RowCount != 0)
                    //        {
                    //            iRow = sheet.RowCount;
                    //            sheet.RowCount++;
                    //            sheet.Cells[iRow, iLastCol].Value = MPCF.SetPrecision(Convert.ToString(dValue / iCount), iPrecision);
                    //            sheet.Cells[iRow, iAverageCol - 1].Value = MPCF.SetPrecision(Convert.ToString(dWeightValue), iPrecision);
                    //            sheet.Cells[iRow, iAverageCol].Value = MPCF.SetPrecision(Convert.ToString(dAverage), iPrecision);

                    //            sheet.Cells[iRow, iAverageCol + 1].Value = MPCF.SetPrecision(Convert.ToString(dSigma), iPrecision);
                    //            sheet.Cells[iRow, iAverageCol + 2].Value = MPCF.SetPrecision(Convert.ToString(dRange), iPrecision);
                    //            sheet.Cells[iRow, iAverageCol + 3].Value = MPCF.SetPrecision(Convert.ToString(dMax), iPrecision);
                    //            sheet.Cells[iRow, iAverageCol + 4].Value = MPCF.SetPrecision(Convert.ToString(dMin), iPrecision);
                    //            if (sUseUnit == 'Y')
                    //            {
                    //                sheet.Cells[iRow, iAverageCol + 13].Value = iOOCType;
                    //                sheet.Cells[iRow, iAverageCol + 14].Value = iOOCType2;
                    //            }
                    //            else
                    //            {
                    //                sheet.Cells[iRow, iAverageCol + 13].Value = iOOCType / iUnitCount;
                    //                sheet.Cells[iRow, iAverageCol + 14].Value = iOOCType2 / iUnitCount;
                    //            }
                    //            sheet.Rows[iRow].BackColor = SystemColors.Control;
                    //            sheet.Rows[iRow].Border = BevelBorder1;

                    //        }
                    //    }
                    //}
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modListRoutine.ViewEDCData()\n" + ex.Message);
                return false;
            }

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

        #endregion

        #endregion

        #region Language

        /// <summary>
        /// Language 파일을 로드합니다.
        /// </summary>
        /// <returns></returns>
        public static bool LoadResourceFile()
        {
            if (LoadMessageResource(MPGC.MP_MESSAGE_FILE) == false)
            {
                return false;
            }
            if (LoadCaptionResource(MPGC.MP_CAPTION_FILE) == false)
            {
                return false;
            }
            //if (LoadIcons() == false)
            //{
            //    return false;
            //}

            return true;
        }

        /// <summary>
        /// 서버에서 다국어 값을 가져와 전역 해시 테이블에 추가한다
        /// </summary>
        /// <returns></returns>
        public static bool LoadMultiLangList()
        {
            TRSNode in_node = new TRSNode("VIEW_MULTI_LANG_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_MULTI_LANG_LIST_OUT");

            try
            {
                in_node.Factory = MPGV.gsFactory;
                in_node.Passport = MPGV.gsPassport;
                in_node.Password = MPGV.gsPassword;
                in_node.UserID = MPGV.gsUserID;

                in_node.ProcStep = '1';
                //if (MPGV.gcLanguage == '1')
                //{
                //    in_node.AddString("LANGUAGE", "en");
                //}
                //else if (MPGV.gcLanguage == '2')
                //{
                //    in_node.AddString("LANGUAGE", "ko");
                //}
                //else if (MPGV.gcLanguage == '3')
                //{
                //    in_node.AddString("LANGUAGE", "zh_CN");
                //}
                //in_node.AddString("TYPE", "message");
                in_node.AddString("USECASE", "client");

                // Service
                if (MessageCaster.CallService("BAS", "BAS_View_Multilang_All_List", in_node, ref out_node) == false)
                {
                    ShowMessage(MPMH.StatusMessage, MSG_LEVEL.ERROR, true);
                    return false;
                }

                // Failed
                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    CheckContinueProc(out_node, true);

                    return false;
                }

                // Bind
                List<TRSNode> list = out_node.GetList(0);
                string code = string.Empty;
                string contents = string.Empty;
                int removeIndex = 0;
                string skey = string.Empty;

                for (int i = 0; i < list.Count; i++)
                {
                    code = list[i].GetString("CODE");
                    contents = list[i].GetString("CONTENTS");                    

                    // 메시지인 경우
                    if (code.ToUpper().StartsWith("MESSAGE") == true)
                    {
                        removeIndex = code.IndexOf('.');
                        skey = code.Substring(removeIndex + 1);

                        if (MPGV.ghtMessageData.ContainsKey(skey) == false)
                        {
                            MPGV.ghtMessageData.Add(skey, contents);
                        }
                    }
                    // 캡션인 경우
                    else if(code.ToUpper().StartsWith("CAPTION") == true)
                    {
                        removeIndex = code.LastIndexOf('.');
                        skey = code.Substring(removeIndex + 1);

                        if (MPGV.ghtCaptionData.ContainsKey(skey) == false)
                        {
                            MPGV.ghtCaptionData.Add(skey, contents);
                        }
                    }
                }

                //foreach (TRSNode lang in out_node.GetList(0))
                //{
                //    int key = ToInt(lang.GetString("CODE").Substring(lang.GetString("CODE").IndexOf('.') + 1));

                //    if (MPGV.ghtMessageData.ContainsKey(key) == false)
                //    {
                //        MPGV.ghtMessageData.Add(key, lang.GetString("CONTENTS"));
                //    }
                //}

                //// Add Caption
                //out_node = new TRSNode("VIEW_MULTI_LANG_LIST_OUT");
                //in_node.SetString("TYPE", "caption");

                //if (MessageCaster.CallService("BAS", "BAS_View_Multilang_List", in_node, ref out_node) == false)
                //{
                //    ShowMessage(MPMH.StatusMessage, MSG_LEVEL.ERROR, true);
                //    return false;
                //}

                //if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                //{
                //    CheckContinueProc(out_node, true);

                //    return false;
                //}

                //foreach (TRSNode lang in out_node.GetList(0))
                //{
                //    string key = lang.GetString("CODE").Substring(lang.GetString("CODE").LastIndexOf('.') + 1);
                //    if (MPGV.ghtCaptionData.ContainsKey(key) == false)
                //    {
                //        MPGV.ghtCaptionData.Add(key, lang.GetString("CONTENTS"));
                //    }
                //}

                return true;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
                return false;
            }
        }

        /// <summary>
        /// Load Caption List
        /// </summary>
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
                ShowErrorMessage("MPCF.LoadCaptionList()\n" + ex.Message);
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
                //else if (control is UltraTabPageControl)
                //{
                //    ((UltraTabPageControl)control).Text = FindLanguage(((UltraTabPageControl)control).Text);
                //}
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
                else if (control is SOIListBox)
                {
                    if (((SOIListBox)control)._UseConvertLanguage == true)
                    {
                        if (((SOIListBox)control).Rows.Count > 0)
                        {
                            if (((SOIListBox)control).DisplayLayout != null
                                && ((SOIListBox)control).DisplayLayout.Bands.Count > 0
                                && ((SOIListBox)control).DisplayLayout.Bands[0] != null
                                && ((SOIListBox)control).DisplayLayout.Bands[0].Columns != null
                                && ((SOIListBox)control).DisplayLayout.Bands[0].Columns.Count > 0)
                            {
                                for (int i = 0; i < ((SOIListBox)control).DisplayLayout.Bands[0].Columns.Count; i++)
                                {
                                    if (((SOIListBox)control).DisplayLayout.Bands[0].Columns[i].DataType == typeof(string))
                                    {
                                        for (int j = 0; j < ((SOIListBox)control).Rows.Count; j++)
                                        {
                                            if (((SOIListBox)control).Rows[j].Cells[i].Value != null)
                                            {
                                                ((SOIListBox)control).Rows[j].Cells[i].Value = FindLanguage(((SOIListBox)control).Rows[j].Cells[i].Value.ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
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
                else if (control is SOIGrid)
                {
                    if (((SOIGrid)control).DisplayLayout.Bands[0].Columns.Count > 0)
                    {
                        for (int i = 0; i < ((SOIGrid)control).DisplayLayout.Bands[0].Columns.Count; i++)
                        {
                            ((SOIGrid)control).DisplayLayout.Bands[0].Columns[i].Header.Caption = FindLanguage(((SOIGrid)control).DisplayLayout.Bands[0].Columns[i].Header.Caption);
                        }
                    }
                }
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
                else if (control is SOIChart)
                {
                    if (((SOIChart)control).GetDataSource() != null)
                    {
                        foreach (DataColumn dc in ((SOIChart)control).GetDataSource().Columns)
                        {
                            dc.ColumnName = FindLanguage(dc.ColumnName);
                        }
                    }
                }
                else if (control is UltraTabControl)
                {
                    if (((UltraTabControl)control).Tabs.Count > 0)
                    {
                        for (int i = 0; i < ((UltraTabControl)control).Tabs.Count; i++)
                        {
                            ((UltraTabControl)control).Tabs[i].Text = FindLanguage(((UltraTabControl)control).Tabs[i].Text);

                            //// Tabs 아이템의 한글 Font가 자동으로 "굴림"체로 변경되는 문제점을 수정하기 위한 구문
                            //((SOITabControl)control).Tabs[i].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            //((SOITabControl)control).Tabs[i].Appearance.FontData.Name = "Malgun Gothic";
                        }
                    }                    
                }

                return true;
            }
            catch (Exception ex)
            {
                ShowMessage("ConvertCaption()\n" + ex.Message, MSG_LEVEL.ERROR, true);
                return false;
            }
        }

        /// <summary>
        /// Lanugauge를 찾습니다.
        /// </summary>
        /// <param name="sCaption"></param>
        /// <returns></returns>
        public static string FindLanguage(string sCaption)
        {
            // 변수 선언
            string sSearchText = string.Empty;
            string sRightSpace = string.Empty;
            string sLeftSpace = string.Empty;
            int i;

            try
            {
                // Caption이 null인 경우
                if (sCaption.Trim() == "")
                {
                    return sCaption;
                }

                // Caption 데이터가 존재하는 경우
                if (CMNV.ghtCaptionData == null || CMNV.ghtCaptionData.Count < 1)
                {
                    Debug.WriteLine(string.Format("   <Text Key=\"{0}\"><L>{0}</L><L>{0}</L><L>{0}</L></Text>", sCaption));
                    return sCaption;
                }

                sSearchText = sCaption;
                for (i = sSearchText.Length - 1; i >= 0; i--)
                {
                    if (sSearchText[i] != ' ')
                    {
                        break;
                    }
                }

                sRightSpace = sSearchText.Substring(i + 1);
                sSearchText = sSearchText.Substring(0, i + 1);

                for (i = 0; i < sSearchText.Length; i++)
                {
                    if (sSearchText[i] != ' ')
                    {
                        break;
                    }
                }

                sLeftSpace = sSearchText.Substring(0, i);
                sSearchText = sSearchText.Substring(i);

                if (sSearchText[sSearchText.Length - 1] == ':')
                {
                    for (i = sSearchText.Length - 2; i >= 0; i--)
                    {
                        if (sSearchText[i] != ' ')
                        {
                            break;
                        }
                    }

                    sRightSpace = sSearchText.Substring(i + 1) + sRightSpace;
                    sSearchText = sSearchText.Substring(0, i + 1);
                }

                if (CMNV.ghtCaptionData.Contains(sSearchText) == false)
                {
                    if (sSearchText.Length > 1)
                    {
                        Debug.WriteLine(string.Format("   <Text Key=\"{0}\"><L>{0}</L><L>{0}</L><L>{0}</L></Text>", sSearchText));
                    }

                    return sCaption;
                }

                sCaption = string.Format("{0}{1}{2}", sLeftSpace, CMNV.ghtCaptionData[sSearchText], sRightSpace);
                return sCaption;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
                return sCaption;
            }
        }

        /// <summary>
        /// Spread 내의 Cell값 다국어 변환 합니다.
        /// Data가 입력되기 전에 실행해야 합니다.
        /// </summary>
        /// <param name="spread"></param>
        /// <returns></returns>
        public static bool ConvertCaptionSpreadCell(SOISpread spread)
        {
            try
            {
                object oData = null;

                // Validation
                if (spread == null)
                {
                    return false;
                }
                if (spread.Sheets.Count < 1)
                {
                    return false;
                }
                
                // Convert by Cell
                for (int i = 0; i < spread.Sheets[0].Columns.Count; i++)
                {
                    for (int j = 0; j < spread.Sheets[0].Rows.Count; j++)
                    {
                        oData = spread.Sheets[0].Cells[j, i].Value;

                        if (oData != null)
                        {
                            if (string.IsNullOrEmpty(oData.ToString()) == false)
                            {
                                spread.Sheets[0].Cells[j,i].Value = FindLanguage(oData.ToString());
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion

        #region Validation

        /// <summary>
        /// 입력 컨트롤의 값을 체크하고 결과를 리턴합니다.
        /// Step 1을 사용합니다. (문자)
        /// 값이 비어 있는지 체크합니다.
        /// </summary>
        /// <param name="Form_control"></param>
        /// <param name="_Step"></param>
        /// <returns></returns>
        public static bool CheckValue(Control Form_control, bool b_is_poup)
        {
            return CheckValue(Form_control, 1, 0, 0, false, false, "", b_is_poup);
        }

        /// <summary>
        /// 입력 컨트롤의 값을 체크하고 결과를 리턴합니다.
        /// Step 1인 경우, 값이 비어있는지 체크합니다.
        /// Step 2인 경우, 숫자타입인지 체크합니다.
        /// Step 3인 경우, 숫자타입이며 정수형인지 체크합니다.
        /// 팝업화면으로 보여주지 않습니다.
        /// </summary>
        /// <param name="Form_control"></param>
        /// <param name="_Step"></param>
        /// <returns></returns>
        public static bool CheckValue(Control Form_control, int _Step)
        {
            return CheckValue(Form_control, _Step, 0, 0, false, false, "", false);
        }

        /// <summary>
        /// 입력 컨트롤의 값을 체크하고 결과를 리턴합니다.
        /// Step 1인 경우, 값이 비어있는지 체크합니다.
        /// Step 2인 경우, 숫자타입인지 체크합니다.
        /// Step 3인 경우, 숫자타입이며 정수형인지 체크합니다.
        /// </summary>
        /// <param name="Form_control"></param>
        /// <param name="_Step"></param>
        /// <returns></returns>
        public static bool CheckValue(Control Form_control, int _Step, bool b_is_popup)
        {
            return CheckValue(Form_control, _Step, 0, 0, false, false, "", b_is_popup);
        }

        /// <summary>
        /// 입력 컨트롤의 값을 체크하고 결과를 리턴합니다.
        /// Step 2를 사용합니다. (숫자)
        /// 해당 Min, Max 범위에 값이 존재하는지 확인하고 결과를 리턴합니다.
        /// </summary>
        /// <param name="Form_control"></param>
        /// <param name="d_min"></param>
        /// <param name="d_max"></param>
        /// <param name="b_is_popup"></param>
        /// <returns></returns>
        public static bool CheckValue(Control Form_control, double d_min, double d_max, bool b_is_popup)
        {
            return CheckValue(Form_control, 4, d_min, d_max, false, false, "", b_is_popup);
        }

        /// <summary>
        /// 입력 컨트롤의 값을 체크하고 결과를 리턴합니다.
        /// Step 1인 경우, 값이 비어있는지 체크합니다.
        /// Step 2인 경우, 숫자타입인지 체크합니다.
        /// Step 3인 경우, 숫자타입이며 정수형인지 체크합니다.
        /// </summary>
        /// <param name="Form_control"></param>
        /// <param name="_Step"></param>
        /// <returns></returns>
        public static bool CheckValue(Control Form_control, int _Step, double d_min, double d_max, bool Not_Confirm_Flag, bool Not_Focus_Flag, string message, bool b_is_popup)
        {
            // Initialize
            bool b_valid_flag = false;
            object d_value = null;

            // Return Message Setup
            if (Trim(message) == "")
            {
                if (_Step == 1)
                {
                    // Required field. Please enter a value.
                    message = MPCF.GetMessage(108);
                }
                else if (_Step == 2 || _Step == 3)
                {
                    // Invalid data format. Please input valid data format.
                    message = MPCF.GetMessage(110);
                }
                else if (_Step == 4)
                {
                    // The data is not valid.
                    message = MPCF.GetMessage(74);
                }
            }

            // Value 추출
            if (Form_control is TextBox)
            {
                d_value = ((TextBox)Form_control).Text;
            }
            else if (Form_control is Label)
            {
                d_value = ((Label)Form_control).Text;
            }
            else if (Form_control is ComboBox)
            {
                d_value = ((ComboBox)Form_control).Text;
            }
            else if (Form_control is SOIComboBox)
            {
                d_value = ((SOIComboBox)Form_control).Text;
            }
            else if (Form_control is SOICodeView)
            {
                d_value = ((SOICodeView)Form_control).Text;
            }
            else if (Form_control is SOICodeViewDescription)
            {
                d_value = ((SOICodeViewDescription)Form_control).Code;
            }
            else if (Form_control is SOICodeViewMultiSelect)
            {
                d_value = ((SOICodeViewMultiSelect)Form_control).Text;
            }
            else if (Form_control is SOILabel)
            {
                d_value = ((SOILabel)Form_control).Text;
            }
            else if (Form_control is SOITextBox)
            {
                d_value = ((SOITextBox)Form_control).Text;
            }
            else if (Form_control is SOIPasswordBox)
            {
                d_value = ((SOIPasswordBox)Form_control).Text;
            }
            else if (Form_control is SOITextBoxNumber)
            {
                d_value = ((SOITextBoxNumber)Form_control).Value;
            }
            else if (Form_control is SOIDateTime)
            {
                d_value = ((SOIDateTime)Form_control).Value;
            }
            else if (Form_control is SOIDateTimeComboBox)
            {
                d_value = ((SOIDateTimeComboBox)Form_control).Value;
            }

            // Check Step 1 : empty value
            if (_Step == 1)
            {
                if (Trim(d_value) != "")
                {
                    b_valid_flag = true;
                }
            }
            // Check Step 2 : double qty min&max
            else if (_Step == 2)
            {
                if (CheckNumeric(d_value) == true)
                {
                    if (d_min != 0 && d_max != 0)
                    {
                        double d = Convert.ToDouble(d_value);

                        if (d >= d_min && d <= d_max)
                        {
                            b_valid_flag = true;
                        }
                    }
                    else
                    {
                        b_valid_flag = true;
                    }
                }
            }
            // Check Step 3 : double type check
            else if (_Step == 3)
            {
                if (CheckNumeric(d_value) == true)
                {
                    if (d_value.ToString().Contains(".") == false)
                    {
                        b_valid_flag = true;
                    }
                }
            }           
            // Check Step 4 : double qty min&max
            else if (_Step == 4)
            {
                if (CheckNumeric(d_value) == true)
                {
                    double d = Convert.ToDouble(d_value);

                    if (d >= d_min && d <= d_max)
                    {
                        b_valid_flag = true;
                    }
                }
            }

            if (b_valid_flag == false)
            {
                if (Not_Confirm_Flag == false)
                {
                    if (Form_control is SOIComboBox)
                    {
                        ((SOIComboBox)Form_control).SetValidation();
                    }
                    else if (Form_control is SOITextBox)
                    {
                        ((SOITextBox)Form_control).SetValidation();
                    }
                    else if (Form_control is SOICodeView)
                    {
                        ((SOICodeView)Form_control).SetValidation();
                    }
                    else if (Form_control is SOICodeViewDescription)
                    {
                        ((SOICodeViewDescription)Form_control).SetValidation();
                    }
                    else if (Form_control is SOICodeViewMultiSelect)
                    {
                        ((SOICodeViewMultiSelect)Form_control).SetValidation();
                    }
                    else if (Form_control is SOIDateTime)
                    {
                        ((SOIDateTime)Form_control).SetValidation();
                    }
                    else if (Form_control is SOIDateTimeComboBox)
                    {
                        ((SOIDateTimeComboBox)Form_control).SetValidation();
                    }

                    MPCF.ShowMessage(message, MSG_LEVEL.ERROR, b_is_popup);

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

        #endregion

        #region Control

        /// <summary>
        /// Shortcut Key를 등록합니다.
        /// </summary>
        /// <param name="menuInfo"></param>
        /// <param name="shortcutKey"></param>
        /// <returns></returns>
        public static bool AddShortcutKey(MenuInfoTag menuInfo, Keys shortcutKey)
        {
            return MPGV.gIMdiForm.AddShortcutKey(menuInfo, shortcutKey);
        }

        /// <summary>
        /// Shortcut Key를 삭제합니다.
        /// </summary>
        /// <param name="menuInfo"></param>
        /// <returns></returns>
        public static bool RemoveShortcutKey(MenuInfoTag menuInfo)
        {
            return MPGV.gIMdiForm.RemoveShortcutKey(menuInfo);
        }

        /// <summary>
        /// 현재 Tablet PC인지 여부를 Return 합니다.
        /// </summary>
        /// <returns></returns>
        public static bool IsTabletPC()
        {
            return (GetSystemMetrics(MPGC.SM_TABLETPC) != 0);
        }

        /// <summary>
        /// Touch Keyboard를 보여주거나 감춥니다.
        /// </summary>
        /// <param name="use"></param>
        public static void ShowTouchKeyboard(bool use)
        {
            // Table PC가 아닌경우 제외
            if (MPCF.IsTabletPC() == false)
            {
                return;
            }

            // Keyboard를 사용하지 않는 경우
            if (MPGV.gbTouchKeyboardUse == false)
            {
                return;
            }

            // Show인 경우
            if (use == true)
            {
                string onScreenKeyboardPath = @"C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe";
                Process.Start(onScreenKeyboardPath);
            }
            // Hide인 경우
            else
            {
                var nullIntPtr = new IntPtr(0);
                uint WM_SYSCOMMAND = 0x0112;
                var scClose = new IntPtr(0xF060);
                var KeyboardWnd = FindWindow("IPTip_Main_Window", null);
                if (KeyboardWnd != nullIntPtr)
                {
                    SendMessage(KeyboardWnd, WM_SYSCOMMAND, scClose, nullIntPtr);
                }
            }
        }

        /// <summary>
        /// Control에 Focus를 줍니다.
        /// </summary>
        /// <param name="control"></param>
        public static void SetFocus(Control control)
        {
            if (control is SOITextBox)
            {
                ((SOITextBox)control).Focus();
                ((SOITextBox)control).SelectionStart = ((SOITextBox)control).Text.Length;
                ((SOITextBox)control).SelectionLength = 0;
            }
            else
            {
                control.Focus();
            }
        }

        /// <summary>
        /// SOIText의 Text를 전체선택하며 Focus 를 줍니다.
        /// </summary>
        /// <param name="control"></param>
        public static void SetFocusAndSelectAll(SOITextBox control)
        {
            control.Focus();
            control.SelectAll();
        }

        /// <summary>
        /// Field Clear
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public static bool FieldClear(object ctrl)
        {
            return FieldClear(ctrl, null, null, null, null, null, false);
        }

        /// <summary>
        /// Field Clear
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public static bool FieldClear(object ctrl, bool bItemsClear)
        {
            return FieldClear(ctrl, null, null, null, null, null, bItemsClear);
        }

        /// <summary>
        /// Field Clear
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public static bool FieldClear(object ctrl, object ExceptCtl1)
        {
            return FieldClear(ctrl, ExceptCtl1, null, null, null, null, false);
        }

        /// <summary>
        /// Field Clear
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public static bool FieldClear(object ctrl, object ExceptCtl1, bool bItemsClear)
        {
            return FieldClear(ctrl, ExceptCtl1, null, null, null, null, bItemsClear);
        }

        /// <summary>
        /// Field Clear
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public static bool FieldClear(object ctrl, object ExceptCtl1, object ExceptCtl2)
        {
            return FieldClear(ctrl, ExceptCtl1, ExceptCtl2, null, null, null, false);
        }

        /// <summary>
        /// Field Clear
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public static bool FieldClear(object ctrl, object ExceptCtl1, object ExceptCtl2, object ExceptCtl3)
        {
            return FieldClear(ctrl, ExceptCtl1, ExceptCtl2, ExceptCtl3, null, null, false);
        }

        /// <summary>
        /// Field Clear
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public static bool FieldClear(object ctrl, object ExceptCtl1, object ExceptCtl2, object ExceptCtl3, object ExceptCtl4)
        {
            return FieldClear(ctrl, ExceptCtl1, ExceptCtl2, ExceptCtl3, ExceptCtl4, null, false);
        }

        /// <summary>
        /// Field Clear
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public static bool FieldClear(object ctrl, object ExceptCtl1, object ExceptCtl2, object ExceptCtl3, object ExceptCtl4, object ExceptCtl5, bool bItemsClear)
        {
            object control;
            int i;
            bool b_except;

            FieldClearControl(ctrl, bItemsClear);

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

                if (control is Panel
                    || control is System.Windows.Forms.GroupBox
                    || control is TabControl
                    || control is TabPage
                    || control is SOIPanel
                    || control is SOIGroupBox
                    || control is SOITabControl
                    || control is SOISplitContainer
                    || control is SOITableLayoutPanel
                    || control is SOIFlexibleScreen)
                {
                    FieldClear(control, ExceptCtl1, ExceptCtl2, ExceptCtl3, ExceptCtl4, ExceptCtl5, bItemsClear);
                }
                else
                {
                    FieldClearControl(control, bItemsClear);
                }
            }
          
            return true;
        }

        /// <summary>
        /// Field Clear를 Control 별로 실행합니다.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="bItemsClear"></param>
        /// <returns></returns>
        private static bool FieldClearControl(object control, bool bItemsClear)
        {
            if (control is SOITextBox)
            {
                ((SOITextBox)control).Text = string.Empty;
            }
            else if (control is SOIPasswordBox)
            {
                ((SOIPasswordBox)control).Text = string.Empty;
            }
            else if (control is SOITextBoxNumber)
            {
                ((SOITextBoxNumber)control).Value = 0;
            }
            else if (control is SOITextBoxValue)
            {
                ((SOITextBoxValue)control).Text = string.Empty;
            }
            else if (control is SOIPictureBox)
            {
                if (((SOIPictureBox)control)._UseLotStatusStyle != SOIPictureBoxStyle.None)
                {
                    ((SOIPictureBox)control).LotStatus = false;
                }
            }
            else if (control is SOICodeView)
            {
                ((SOICodeView)control).Text = string.Empty;
            }
            else if (control is SOICodeViewDescription)
            {
                ((SOICodeViewDescription)control).Code = string.Empty;
                ((SOICodeViewDescription)control).Description = string.Empty;
            }
            else if (control is SOICodeViewMultiSelect)
            {
                ((SOICodeViewMultiSelect)control).Text = string.Empty;
            }
            else if (control is SOIComboBox)
            {
                ((SOIComboBox)control).SelectedIndex = -1;
                if (bItemsClear == true)
                {
                    ((SOIComboBox)control).Items.Clear();
                }
            }
            else if (control is SOILabel)
            {
                if (((SOILabel)control)._UseStyle == SOILabelStyle.ValueStyle)
                {
                    ((SOILabel)control).Text = string.Empty;
                }
            }
            else if (control is SOICheckBox)
            {
                ((SOICheckBox)control).Checked = false;
            }
            else if (control is SOICheckBoxOnOff)
            {
                ((SOICheckBoxOnOff)control).OnOffState = SOICheckBoxOnOffState.OnState;
            }
            else if (control is SOIRadioButton)
            {
                ((SOIRadioButton)control).CheckedIndex = 0;
            }
            else if (control is SOIListBox)
            {
                if (((SOIListBox)control).Rows.Count > 0)
                {
                    DataTable dt = ((SOIListBox)control).GetDataSource();

                    if (dt.Rows.Count > 0)
                    {
                        dt.Rows.Clear();
                    }

                    ((SOIListBox)control).SetDataSource(dt);
                }
            }
            else if (control is SOIGrid)
            {
                if (((SOIGrid)control).Rows.Count > 0)
                {
                    DataTable dt = ((SOIGrid)control).GetDataSource();

                    if (dt.Rows.Count > 0)
                    {
                        dt.Rows.Clear();
                    }

                    ((SOIGrid)control).SetDataSource(dt);
                }
            }
            else if (control is SOISpread)
            {
                if (((SOISpread)control).Sheets.Count > 0)
                {
                    if (((SOISpread)control).Sheets[0].Rows.Count > 0)
                    {
                        ((SOISpread)control).Sheets[0].Rows.Clear();
                    }
                }
            }
            else if (control is SOIChart)
            {
                ((SOIChart)control).ClearDataSource();
            }
            else if (control is System.Windows.Forms.TextBox)
            {
                ((System.Windows.Forms.TextBox)control).Text = "";
            }
            //else if (control is System.Windows.Forms.CheckBox)
            //{
            //    ((System.Windows.Forms.CheckBox)control).Checked = false;
            //}
            //else if (control is ComboBox)
            //{
            //    ((ComboBox)control).SelectedIndex = -1;
            //    if (bItemsClear == true)
            //    {
            //        ((ComboBox)control).Items.Clear();
            //    }
            //}
            //else if (control is RadioButton)
            //{
            //    ((RadioButton)control).Checked = false;
            //}
            //else if (control is NumericUpDown)
            //{
            //    try
            //    {
            //        ((NumericUpDown)control).Value = 0;
            //    }
            //    catch (ArgumentOutOfRangeException)
            //    {
            //        ((NumericUpDown)control).Value = ((NumericUpDown)control).Minimum;
            //    }
            //}

            return true;
        }

        /// <summary>
        /// Field Visible
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="bVisible"></param>
        /// <returns></returns>
        public static bool FieldVisible(object ctrl, bool bVisible)
        {
            return FieldVisible(ctrl, bVisible, null, null, null, null, null);
        }

        /// <summary>
        /// Field Visible
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="bVisible"></param>
        /// <returns></returns>
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

                if (control is Panel
                    || control is System.Windows.Forms.GroupBox
                    || control is TabControl
                    || control is TabPage
                    || control is SOIPanel
                    || control is SOIGroupBox
                    || control is SOITabControl
                    || control is SOISplitContainer
                    || control is SOITableLayoutPanel)
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

        /// <summary>
        /// Change Cursor
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="curChange"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Check byte text length in TextBox
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="iMaxLength"></param>
        /// <returns></returns>
        public static bool CheckMaxLength(object ctrl, int iMaxLength)
        {
            int i_byte_len;
            string s_text = "";

            if (iMaxLength <= 0)
            {
                if (ctrl is SOITextBox)
                {
                    iMaxLength = ((SOITextBox)ctrl).MaxLength;
                    s_text = ((SOITextBox)ctrl).Text;
                }
                else if (ctrl is System.Windows.Forms.TextBox)
                {
                    iMaxLength = ((System.Windows.Forms.TextBox)ctrl).MaxLength;
                    s_text = ((System.Windows.Forms.TextBox)ctrl).Text;
                }
            }

            if (iMaxLength == 0)
            {
                return false;
            }

            i_byte_len = ByteLen(s_text);
            if (i_byte_len > iMaxLength)
            {
                if (ctrl is SOITextBox)
                {
                    ((SOITextBox)ctrl).Text = ByteMid(s_text, 0, iMaxLength);
                    ((SOITextBox)ctrl).SelectionStart = s_text.Length;
                }
                else if (ctrl is System.Windows.Forms.TextBox)
                {
                    ((System.Windows.Forms.TextBox)ctrl).Text = ByteMid(s_text, 0, iMaxLength);
                    ((System.Windows.Forms.TextBox)ctrl).SelectionStart = s_text.Length;
                }

                return false;
            }

            return true;
        }

        /// <summary>
        /// Get Indexed Control
        /// </summary>
        /// <param name="sControlName"></param>
        /// <param name="parentControl"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Select Text
        /// </summary>
        /// <param name="myText"></param>
        /// <param name="Focus_Flag"></param>
        public static void SelectText(SOITextBox myText, bool Focus_Flag)
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
                ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// SOIButtonImageViewer에 Image Source를 등록합니다.
        /// </summary>
        /// <param name="targetButton"></param>
        /// <param name="imgSource"></param>
        /// <returns></returns>
        public static bool AddImageToImageViewer(SOIButtonImageViewer targetButton, Image imgSource)
        {
            try
            {
                targetButton.TargetImage = imgSource;

                return true;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Image Viewer를 실행합니다.
        /// Image View Popup 화면을 생성하고 사용한 뒤 종료합니다.
        /// </summary>
        /// <param name="imgSource"></param>
        /// <returns></returns>
        public static bool RunImageViewer(Image imgSource, bool help)
        {
            try
            {
                using (frmImageViewerPopup frmImage = new frmImageViewerPopup())
                {
                    frmImage.SetImageSource(imgSource);

                    if(help == true)
                    {
                        frmImage.ViewerTitle = "Help";
                    }

                    frmImage.ShowDialog();
                }

                return true;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Image Viewer를 실행합니다.
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static bool RunImageViewer(Image img)
        {
            return RunImageViewer(img, false);
        }

        /// <summary>
        /// Standard Operation View를 실행합니다.
        /// Show() 메소드로 실행합니다.
        /// Material ID, Flow ID, Operation ID를 매개변수로 받습니다.
        /// </summary>
        /// <param name="matId"></param>
        /// <param name="flow"></param>
        /// <param name="oper"></param>
        /// <returns></returns>
        public static bool RunStandardOperationView(string matId, int i_mat_ver, string flow, string oper, string resId)
        {
            try
            {
#if _H101
                return false;
#endif
#if _Http
                // Get File List
                List<DownloadFileInfo> infoList = GetOperationStandard(matId, i_mat_ver, flow, oper, resId);

                // Error or No Data
                if (infoList == null
                    || infoList.Count < 1)
                {
                    return false;
                }
                // More than 2 File
                else if(infoList.Count > 1)
                {
                    // Select Popup Show
                    frmStdOperSelectPopup frmSelect = new frmStdOperSelectPopup();
                    frmSelect.Owner = MPGV.gfrmMDI;
                    if (frmSelect.ShowDialog(ref infoList) == DialogResult.Cancel)
                    {
                        return false;
                    }
                }

                foreach (DownloadFileInfo info in infoList)
                {
                    // Validation
                    if (info.fileId == null || info.fileId == "")
                    {
                        continue;
                    }

                    // File Download
                    byte[] infoBytes = null;
                    if (MPCF.CallDownloadService(info.fileId, ref infoBytes) == false)
                    {
                        return false;
                    }

                    // Image Show...
                    if (info.fileType.ToUpper().Equals("PNG") == true
                        || info.fileType.ToUpper().Equals("JPG") == true
                        || info.fileType.ToUpper().Equals("BMP") == true)
                    {
                        frmStandardOperationView frm = new frmStandardOperationView();
                        frm.SetImageSource(ByteArrayToImage(infoBytes));
                        frm.Owner = MPGV.gfrmMDI;
                        frm.Show();
                    }
                    // Others Show...
                    else
                    {
                        string path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + "." + info.fileType;
                        File.WriteAllBytes(path, infoBytes);

                        using (Process process = new Process())
                        {
                            process.StartInfo.FileName = path;
                            process.Start();
                        }
                    }
                }

                return true;
#endif
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Get Current GDI Count
        /// </summary>
        /// <returns></returns>
        public static int GetCurrentGDICount()
        {
            uint ui;
            Process ps = Process.GetCurrentProcess();

            ui = GetGuiResources(ps.Handle, 0);
            return Convert.ToInt32(ui);
        }

        /// <summary>
        /// ListBox의 해당 Column에 값을 추가합니다.
        ///  - Text Column이 1개인 경우
        /// </summary>
        /// <param name="control"></param>
        /// <param name="value"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        public static bool SetSOIListBoxAddRow(SOIListBox control, int rowSeq, bool rowCheck, string rowText)
        {
            try
            {
                // 1) Data Source 추출
                DataTable dt = control.GetDataSource();

                // 2) New Row 생성
                DataRow dr = dt.NewRow();

                // 3) 최초 String Type Column에 값을 추가.
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (i == 0)
                    {
                        if (dt.Columns[0].DataType == typeof(int))
                        {
                            dr[0] = rowSeq;
                        }
                    }

                    if (dt.Columns[i].DataType == typeof(bool))
                    {
                        dr[i] = rowCheck;
                    }
                    else if (dt.Columns[i].DataType == typeof(string))
                    {
                        dr[i] = rowText;
                        break;
                    }
                }

                // 4) DataRow를 Data Source에 추가
                dt.Rows.Add(dr);

                // 5) SOIListBox에 DataBind
                control.DataBind();

                return true;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

#if _Http
        /// <summary>
        /// Standard Operation File을 다운로드 합니다.
        /// </summary>
        /// <param name="s_mat_id"></param>
        /// <param name="s_flow"></param>
        /// <param name="s_oper"></param>
        /// <returns></returns>
        public static List<DownloadFileInfo> GetOperationStandard(string s_mat_id, int i_mat_ver, string s_flow, string s_oper, string s_res_id)
        {
            TRSNode in_node = new TRSNode("GET_WORK_INSTRUCTION_IN");
            TRSNode out_node = new TRSNode("GET_WORK_INSTRUCTION_OUT");

            try
            {
                
                List<DownloadFileInfo> returnList = new List<DownloadFileInfo>();

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MAT_ID", s_mat_id);
                in_node.AddInt("MAT_VER", i_mat_ver);
                in_node.AddString("FLOW", s_flow);
                in_node.AddString("OPER", s_oper);
                in_node.AddString("RES_ID", s_res_id);

                if (MPCF.CallService("WIP", "WIP_GET_WORK_INSTRUCTION", in_node, ref out_node) == false)
                {
                    return null;
                }

                // No Data
                if (string.IsNullOrEmpty(out_node.GetString("FILE_ID")) == true)
                {
                    return null;
                }                
                else
                {                    
                    DownloadFileInfo info = new DownloadFileInfo();
                    info.fileId = out_node.GetString("FILE_ID");
                    string fileName = out_node.GetString("FILE_NAME");
                    string extension = string.Empty;
                    if (string.IsNullOrEmpty(fileName) == false
                        && fileName.Contains('.') == true)
                    {
                        extension = fileName.Remove(0, fileName.LastIndexOf('.') - 1);
                    }
                    info.fileType = extension;
                    
                    returnList.Add(info);
                }

                return returnList;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return null;
            }
        }
#endif

        #region SOISpread & SOIGrid

        /// <summary>
        /// Spread에 Button Cell Type을 지정할 때 사용합니다.
        /// 테마에 따라 Button Cell의 색이 변경됩니다.
        /// </summary>
        /// <returns></returns>
        public static FarPoint.Win.Spread.CellType.ButtonCellType GetSpreadButtonCellType()
        {
            FarPoint.Win.Spread.CellType.ButtonCellType btnCellType = new FarPoint.Win.Spread.CellType.ButtonCellType();
            btnCellType.ButtonColor = MPGV.gTheme.ButtonDefaultBackground;
            btnCellType.ButtonColor2 = MPGV.gTheme.ButtonDefaultBackground;
            btnCellType.DarkColor = MPGV.gTheme.ButtonDefaultBackground;
            btnCellType.LightColor = MPGV.gTheme.ButtonDefaultBackground;

            return btnCellType;
        }

        /// <summary>
        /// Get Spread Column by Column Header
        /// </summary>
        /// <param name="spdData"></param>
        /// <param name="sHeader"></param>
        /// <param name="iRow"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get Spread Row Index by findData in column Index
        /// 지정된 컬럼에서 string data를 찾은 후, 
        /// 값이 있는 경우 해당 Row Index를 return합니다.
        /// 값이 없는 경우 -1을 return 합니다.
        /// </summary>
        /// <param name="spread"></param>
        /// <param name="columnIndex"></param>
        /// <param name="findData"></param>
        /// <returns></returns>
        public static int GetSpreadRowIndex(FarPoint.Win.Spread.FpSpread spread, int columnIndex, string findData)
        {
            try
            {
                int iReturn = -1;

                for (int i = 0; i < spread.Sheets[0].Rows.Count; i++)
                {
                    if (spread.Sheets[0].Cells[i, columnIndex].Value != null
                        && spread.Sheets[0].Cells[i, columnIndex].Value.ToString() == findData)
                    {
                        iReturn = i;
                        break;
                    }
                }

                return iReturn;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return -1;
            }
        }

        /// <summary>
        /// FindData를 가지는 가장 처음의 Row를 찾아 Scroll 합니다.
        /// FindData가 없는 경우 Grid의 첫번째 Row를 Scroll 합니다.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="columnKey"></param>
        /// <param name="findData"></param>
        /// <returns></returns>
        public static bool SetScrollRow(SOIGrid control, string columnKey, object findData)
        {
            try
            {
                if (control == null || control.Rows.Count < 0)
                {
                    return false;
                }

                if (string.IsNullOrEmpty(columnKey) == true || findData == null || string.IsNullOrEmpty(findData.ToString()) == true)
                {
                    control.PerformAction(UltraGridAction.FirstRowInGrid);
                    return true;
                }

                DataTable dt = control.GetDataSource();

                if (dt.Columns[columnKey] == null)
                {
                    return false;
                }

                DataColumn dc = dt.Columns[columnKey];

                bool bFound = false;
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    if (findData.ToString().Equals(dr[dc]))
                    {
                        bFound = true;
                        break;
                    }

                    i++;
                }

                if (bFound == true)
                {
                    control.Rows[i].Selected = true;
                    control.ActiveRow = control.Rows[i];
                }
                else
                {
                    //control.Rows[0].Selected = true;
                    control.ActiveRow = control.Rows[0];
                }

                control.PerformAction(UltraGridAction.ActivateCell);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("SetScrollRow() : " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// SOISpread의 Column Header Size를 내용에 맞게 조절한다.
        /// </summary>
        /// <param name="spread"></param>
        public static void FitColumnHeader(FpSpread spread)
        {
            FitColumnHeader(spread, -1, -1, -1, -1, false);
        }

        /// <summary>
        /// SOISpread의 Column Header Size를 내용에 맞게 조절한다.
        /// Resizable이 false인 컬럼은 변경하지 않는다.
        /// </summary>
        /// <param name="spread"></param>
        /// <param name="b_skip_fixed_size_header"></param>
        public static void FitColumnHeader(FpSpread spread, bool b_skip_fixed_size_header)
        {
            FitColumnHeader(spread, -1, -1, -1, -1, b_skip_fixed_size_header);
        }

        /// <summary>
        /// SOISpread의 Column Header Size를 내용에 맞게 조절한다.
        /// Size를 조절할 컬럼의 시작 및 끝 index를 설정한다.
        /// </summary>
        /// <param name="spread"></param>
        /// <param name="i_start_column_index"></param>
        /// <param name="i_end_column_index"></param>
        public static void FitColumnHeader(FpSpread spread, int i_start_column_index, int i_end_column_index)
        {
            FitColumnHeader(spread, i_start_column_index, i_end_column_index, -1, -1, false);
        }

        /// <summary>
        /// SOISpread의 Column Header Size를 내용에 맞게 조절한다.
        /// Resizable이 false인 컬럼은 변경하지 않는다.
        /// Size를 조절할 컬럼의 시작 및 끝 index를 설정한다.
        /// </summary>
        /// <param name="spread"></param>
        /// <param name="i_start_column_index"></param>
        /// <param name="i_end_column_index"></param>
        /// <param name="b_skip_fixed_size_header"></param>
        public static void FitColumnHeader(FpSpread spread, int i_start_column_index, int i_end_column_index, bool b_skip_fixed_size_header)
        {
            FitColumnHeader(spread, i_start_column_index, i_end_column_index, -1, -1, b_skip_fixed_size_header);

            /// <param name="i_word_warp_col">Word Wrap을 사용할 컬럼 인덱스</param>
            /// <param name="i_word_wrap_max_size">Word Wrap을 사용할 컬럼의 최대 문자열 길이</param>
        }

        /// <summary>
        /// SOISpread의 Column Header Size를 내용에 맞게 조절한다.
        /// Resizable이 false인 컬럼은 변경하지 않는다.
        /// Size를 조절할 컬럼의 시작 및 끝 index를 설정한다.
        /// Word Wrap을 사용할 컬럼 Index를 지정하고 최대 문자열 길이를 지정한다.
        /// </summary>
        /// <param name="spread"></param>
        /// <param name="i_start_column_index"></param>
        /// <param name="i_end_column_index"></param>
        /// <param name="i_word_wrap_col"></param>
        /// <param name="i_word_wrap_max_size"></param>
        /// <param name="b_skip_fixed_size_header"></param>
        public static void FitColumnHeader(FpSpread spread, int i_start_column_index, int i_end_column_index, int i_word_wrap_col, int i_word_wrap_max_size, bool b_skip_fixed_size_header)
        {
            float colWidth;
            int i;
            int j;

            try
            {
                FarPoint.Win.Spread.SheetView s_view = spread.ActiveSheet;

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
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// SOIGrid의 Column Header Size를 내용에 맞게 조절한다.
        /// </summary>
        /// <param name="grid"></param>
        public static void FitColumnHeader(SOIGrid grid)
        {
            grid.DisplayLayout.PerformAutoResizeColumns(false, PerformAutoSizeType.VisibleRows);
        }

        /// <summary>
        /// 특정한 하나의 Row에 Selection을 줍니다.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="rowIndex"></param>
        public static void SOISpreadSetSelectionSingleRow(SOISpread target, int rowIndex)
        {
            try
            {
                // Validation
                if (target == null)
                {
                    return;
                }
                if (target.Sheets.Count < 1)
                {
                    return;
                }
                if (target.Sheets[0].Rows.Count < 1)
                {
                    return;
                }

                target.Sheets[0].ActiveRowIndex = rowIndex;
                target.Sheets[0].AddSelection(rowIndex, 0, 1, target.Sheets[0].Columns.Count);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);                
            }
        }

        /// <summary>
        /// SOISpread의 지정된 checkbox column에 대해, 몇개의 Row가 체크되었는지 확인합니다.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="checkBoxColumnIndex"></param>
        /// <returns></returns>
        public static int SOISpreadGetCheckedCount(SOISpread target, int checkBoxColumnIndex)
        {
            int iReturn = 0;

            try
            {
                // Validation
                if (target == null)
                {
                    return iReturn;
                }
                if (target.Sheets.Count < 1)
                {
                    return iReturn;
                }
                if (target.Sheets[0].Rows.Count < 1)
                {
                    return iReturn;
                }
                if (target.Sheets[0].Columns.Count - 1 < checkBoxColumnIndex
                    || checkBoxColumnIndex < 0)
                {
                    return iReturn;
                }

                // Check
                for (int i = 0; i < target.Sheets[0].Rows.Count; i++)
                {
                    if ((bool)target.Sheets[0].Cells[i, checkBoxColumnIndex].Value == true)
                    {
                        iReturn++;
                    }
                }

                return iReturn;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return -1;
            }
        }

        /// <summary>
        /// 해당 Row Index의 CheckBox Column에 체크 합니다.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="checkBoxColumnIndex"></param>
        /// <param name="rowIndex"></param>
        public static void SOISpreadSetCheckBox(SOISpread target, int checkBoxColumnIndex, int rowIndex)
        {
            try
            {
                // Validation
                if (target == null)
                {
                    return;
                }
                if (target.Sheets.Count < 1)
                {
                    return;
                }
                if (target.Sheets[0].Rows.Count < 1)
                {
                    return;
                }
                if (target.Sheets[0].Columns.Count - 1 < checkBoxColumnIndex
                    || checkBoxColumnIndex < 0)
                {
                    return;
                }
                if (rowIndex < 0)
                {
                    return;
                }

                // Check
                if (((bool)target.Sheets[0].Cells[rowIndex, checkBoxColumnIndex].Value) == false)
                {
                    target.Sheets[0].Cells[rowIndex, checkBoxColumnIndex].Value = true;
                }
                // Uncheck
                else
                {
                    target.Sheets[0].Cells[rowIndex, checkBoxColumnIndex].Value = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// CheckBox Column에 대해 모든 Row에 체크 합니다.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="checkBoxColumnIndex"></param>
        /// <returns></returns>
        public static void SOISpreadSelectAll(SOISpread target, int checkBoxColumnIndex)
        {
            try
            {
                // Validation
                if (target == null)
                {
                    return;
                }
                if (target.Sheets.Count < 1)
                {
                    return;
                }
                if (target.Sheets[0].Rows.Count < 1)
                {
                    return;
                }
                if (target.Sheets[0].Columns.Count - 1 < checkBoxColumnIndex
                    || checkBoxColumnIndex < 0)
                {
                    return;
                }

                // Select All
                for (int i = 0; i < target.Sheets[0].Rows.Count; i++)
                {
                    target.Sheets[0].Cells[i, checkBoxColumnIndex].Value = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// CheckBox Column에 대해 모든 Row에 체크해제 합니다.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="checkBoxColumnIndex"></param>
        /// <returns></returns>
        public static void SOISpreadReleaseAll(SOISpread target, int checkBoxColumnIndex)
        {
            try
            {
                // Validation
                if (target == null)
                {
                    return;
                }
                if (target.Sheets.Count < 1)
                {
                    return;
                }
                if (target.Sheets[0].Rows.Count < 1)
                {
                    return;
                }
                if (target.Sheets[0].Columns.Count - 1 < checkBoxColumnIndex
                    || checkBoxColumnIndex < 0)
                {
                    return;
                }

                // Release All
                for (int i = 0; i < target.Sheets[0].Rows.Count; i++)
                {
                    target.Sheets[0].Cells[i, checkBoxColumnIndex].Value = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// SOIGrid에 out node의 List를 Bind합니다.
        /// SOIGrid에 동일한 이름의 key가 설정되어 있어야 합니다.
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <returns></returns>
        public static bool BindSOIGridFromNodeList(SOIGrid targetGrid, List<TRSNode> outList)
        {
            try
            {
                // Check Null
                if (targetGrid == null
                    || outList == null)
                {
                    return false;
                }

                // Check List
                if (outList.Count < 1)
                {
                    return true;
                }

                DataTable dt = targetGrid.GetDataSource();

                // Check Grid
                if (dt == null
                    || dt.Columns.Count < 1)
                {
                    return false;
                }

                // Check Key and Type                
                TRSNode memberExist = new TRSNode("ExistData");
                DataRow dr;
                bool bFound = false;
                foreach (TRSNode data in outList)
                {
                    bFound = false;
                    dr = dt.NewRow();

                    foreach (DataColumn dc in dt.Columns)
                    {
                        memberExist = data.GetMember(dc.ColumnName);

                        if (memberExist != null)
                        {
                            bFound = true;
                            if (dc.DataType == typeof(string))
                            {
                                dr[dc.ColumnName] = memberExist.Value;
                            }
                            //else if(dc.DataType == typeof(bool))
                            //{
                            //    dr[dc.ColumnName] = Convert.ToBoolean(memberExist.Value);
                            //}
                            //else if(dc.DataType == typeof(char))
                            //{
                            //    dr[dc.ColumnName] = Convert.ToChar(memberExist.Value);
                            //}
                            ////else if(dc.DataType == typeof(DateTime))
                            ////{
                            ////    dr[dc.ColumnName] = DateTime.Parse(MPCF.DestroyDateFormat(memberExist.Value));
                            ////}
                            //else if(dc.DataType == typeof(double))
                            //{
                            //    dr[dc.ColumnName] = Convert.ToDouble(memberExist.Value);
                            //}
                            //else if(dc.DataType == typeof(int))
                            //{
                            //    dr[dc.ColumnName] = Convert.ToInt32(memberExist.Value);
                            //}
                            //else
                            //{
                            //    dr[dc.ColumnName] = memberExist.Value;
                            //}
                        }
                    }

                    if (bFound == true)
                    {
                        dt.Rows.Add(dr);
                    }
                }

                targetGrid.DataBind();

                FitColumnHeader(targetGrid);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("BindSOIGridFromNodeList(): " + ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion

        #endregion

        #region Convert

        /// <summary>
        /// Get byte length in String
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ByteLen(object str)
        {
            if (str == null)
            {
                str = "";
            }

            string sTemp = str.ToString();

            return System.Text.Encoding.Default.GetByteCount(sTemp);
        }

        /// <summary>
        /// Get Middle String at byte length in String
        /// </summary>
        /// <param name="str"></param>
        /// <param name="iStartIndex"></param>
        /// <param name="iLength"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Split String at byte length in String
        /// </summary>
        /// <param name="str"></param>
        /// <param name="i_max_length"></param>
        /// <returns></returns>
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

            while (true)
            {
                if (bTemp.Length <= i_max_length)
                {
                    sTemp = twobyte.GetString(bTemp);
                    lisSplitString.Add(sTemp);
                    break;
                }

                i_inc = 0;
                for (i = 0; i < i_max_length; )
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

        /// <summary>
        /// File 경로 -----> File -----> Byte[]
        /// </summary>
        /// <param name="sFilePath"></param>
        /// <returns></returns>
        public static byte[] FileToByteArray(string sFilePath)
        {
            byte[] data = null;

            using (FileStream stream = new FileStream(sFilePath, FileMode.Open))
            {
                data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
            }

            return data;
        }

        /// <summary>
        /// Byte[] -----> Image
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public static Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null)
            {
                return null;
            }

            Image img = null;

            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                img = Image.FromStream(ms);
            }

            return img;
        }

        /// <summary>
        /// 엑셀 형식의 Byte Array를 임시파일 경로에 저장한다.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ByteArrayToExcelFile(byte[] data, SAVE_FILE_TYPE fileType)
        {
            try
            {
                string sReturnValue = string.Empty;

                // Check Data
                if (data == null)
                {
                    return string.Empty;
                }

                // Create "_temp" Directory
                String upgradePath = Application.StartupPath + "\\_temp";
                if (Directory.Exists(upgradePath) == false)
                {
                    Directory.CreateDirectory(upgradePath);
                }

                // Create File
                if (fileType == SAVE_FILE_TYPE.xlsx)
                {
                    String fileName = "MESOItempImportFile.xlsx";

                    if (File.Exists(upgradePath + "\\" + fileName) == true)
                    {
                        File.Delete(upgradePath + "\\" + fileName);
                    }

                    sReturnValue = upgradePath + "\\" + fileName;

                    using (FileStream fs = File.Create(sReturnValue))
                    {
                    }
                }
                else
                {
                    return string.Empty;
                }

                File.WriteAllBytes(sReturnValue, data);

                return sReturnValue;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return string.Empty;
            }
        }

        /// <summary>
        /// Subtract String
        /// </summary>
        /// <param name="tmpS"></param>
        /// <param name="Fstring"></param>
        /// <param name="Backword_flag"></param>
        /// <param name="Include_Space"></param>
        /// <returns></returns>
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
                MPCF.ShowErrorMessage(ex.Message);
                return "";
            }
        }

        /// <summary>
        /// Check Lower Convertable
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static bool IsConvertable(string str)
        {
            foreach (char c in str)
            {
                if (Char.IsLower(c)) return true;
            }

            return false;
        }

        /// <summary>
        /// Camel String to Underbar String
        /// </summary>
        /// <param name="underscore"></param>
        /// <returns></returns>
        public static string CamelToUnderscore(string underscore)
        {
            // 들어온 문자열에 소문자가 하나도 없다면 변환할 내용이 없으므로 그대로 보낸다.
            if (IsConvertable(underscore) == false) return underscore;

            StringBuilder result = new StringBuilder();

            StringBuilder sub = new StringBuilder();
            bool isNumber = false;
            foreach (char c in underscore)
            {
                if (Char.IsUpper(c))
                {
                    if (result.Length == 0)
                    {
                        result.Append(sub);
                    }
                    else
                    {
                        result.Append("_").Append(sub);
                    }

                    sub = new StringBuilder();
                    sub.Append(c);
                    isNumber = false;
                }
                else if (Char.IsNumber(c))
                {
                    if (isNumber == false && sub.Length > 0)
                    {
                        if (result.Length == 0)
                        {
                            result.Append(sub);
                        }
                        else
                        {
                            result.Append("_").Append(sub);
                        }
                        sub = new StringBuilder();
                    }
                    isNumber = true;
                    sub.Append(c);
                }
                else
                {
                    sub.Append(c);
                }
            }

            if (sub.Length > 0)
            {
                if (result.Length == 0)
                {
                    result.Append(sub);
                }
                else
                {
                    result.Append("_").Append(sub);
                }
            }

            return result.ToString().ToUpper();
        }

        /// <summary>
        /// String to Barcode String
        /// Code39
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string StringToBarcodeString(string str)
        {
            return StringToBarcodeString(str, BARCODE_FONT_TYPE.CODE39);
        }

        /// <summary>
        /// String to Barcode String
        /// Code39
        /// </summary>
        /// <param name="str"></param>
        /// <param name="fontType"></param>
        /// <returns></returns>
        private static string StringToBarcodeString(string str, BARCODE_FONT_TYPE fontType)
        {
            switch (fontType)
            {
                case BARCODE_FONT_TYPE.CODE39:
                    str = String.Format("*{0}*", str);
                    break;
                default:
                    break;
            }
            return str;
        }

        /// <summary>
        /// Set data by graph type
        /// </summary>
        /// <param name="sValue"></param>
        /// <param name="iPrecision"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Check Format
        /// </summary>
        /// <param name="cFmt"></param>
        /// <param name="strValue"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 숫자로 구성된 문자열에 각 국가별 숫자Format을 적용하고 반환한다.
        /// 숫자로 변경되지 못하는 경우, 입력문자열을 그대로 반환한다.
        /// 유효숫자는 0이다.
        /// 유효숫자 이하는 반올림한다.
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public static string MakeNumberFormat(string S)
        {
            return MakeNumberFormat(S, 0);
        }

        /// <summary>
        /// 숫자로 구성된 문자열에 각 국가별 숫자Format을 적용하고 반환한다.
        /// 숫자로 변경되지 못하는 경우, 입력문자열을 그대로 반환한다.
        /// 유효숫자를 입력받는다.
        /// 유효숫자 이하는 반올림한다.
        /// </summary>
        /// <param name="S"></param>
        /// <param name="DateTimeFormat"></param>
        /// <returns></returns>
        public static string MakeNumberFormat(string S, int digit)
        {
            try
            {
                string sReturn = S;
                double dTemp = 0;

                try
                {
                    if (string.IsNullOrEmpty(S) == false)
                    {
                        dTemp = Convert.ToDouble(S, CultureInfo.CurrentCulture.NumberFormat);
                    }
                }
                catch (Exception)
                {
                    return S;
                }

                sReturn = dTemp.ToString("N" + digit, CultureInfo.CurrentCulture);          

                return sReturn;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return S;
            }
        }

        /// <summary>
        /// double형에 각 국가별 숫자Format을 적용하고 문자열로 반환한다.        
        /// 유효숫자는 0이다.
        /// 유효숫자 이하는 반올림한다.
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public static string MakeNumberFormat(double number)
        {
            return MakeNumberFormat(number, 0);
        }

        /// <summary>
        /// double형에 각 국가별 숫자Format을 적용하고 문자열로 반환한다.        
        /// 유효숫자를 입력받는다.
        /// 유효숫자 이하는 반올림한다.
        /// </summary>
        /// <param name="S"></param>
        /// <param name="DateTimeFormat"></param>
        /// <returns></returns>
        public static string MakeNumberFormat(double number, int digit)
        {
            try
            {
                return number.ToString("N" + digit, CultureInfo.CurrentCulture);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return string.Empty;
            }
        }

        /// <summary>
        /// 숫자Format이 적용된 문자열에 Format을 제거한다.
        /// Format이 적용되지 않은 문자열은 그대로 반환한다.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string DestroyNumberFormat(string text)
        {
            try
            {
                string sReturn = string.Empty;
                double dTemp = 0;

                try
                {
                    dTemp = Convert.ToDouble(text, CultureInfo.CurrentCulture.NumberFormat);
                }
                catch (Exception)
                {
                    return text;
                }

                sReturn = dTemp.ToString();

                return sReturn;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return text;
            }
        }

        /// <summary>
        /// Check Digit
        /// </summary>
        /// <param name="cArg"></param>
        /// <returns></returns>
        public static bool CheckDigit(char cArg)
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
        /// 지정된 digit에서 반올림합니다.
        /// </summary>
        /// <param name="dValue"></param>
        /// <param name="iDigits"></param>
        /// <returns></returns>
        public static double ToHalfAdjust(double dValue, int iDigits)
        {
            double dCoef = System.Math.Pow(10, iDigits);
            return dValue > 0 ? System.Math.Floor((dValue * dCoef) + 0.5) / dCoef :
                System.Math.Ceiling((dValue * dCoef) - 0.5) / dCoef;
        }

        /// <summary>
        /// 더블형의 수치값을 입력된 소숫점 자리까지 표현하는 문자열로 변경합니다
        /// </summary>
        /// <param name="dValue">변경할 더블값</param>
        /// <param name="iDigits">소숫점 자리</param>
        /// <returns></returns>
        public static string DoubleToString(double dValue, int iDigits)
        {
            string format = "###,###,##0";
            if (iDigits > 0)
            {
                format = format + ".";
                for (int i = 0; i < iDigits - 1; i++)
                {
                    format = format + "#";
                }
                format = format + "0";
            }

            return dValue.ToString(format);
        }

        /// <summary>
        /// File compress to use GZip library
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool ZipCompress(string path)
        {
            try
            {
                // 1. 파일 확장자를 xml로 지정
                string sFileName = path + ".xml";

                // 2. 파일 존재여부 확인
                if (File.Exists(sFileName) == false)
                {
                    // Failed to load resource.  Check if resource file exists.
                    MPCF.ShowMessage(MPCF.GetMessage(69), MSG_LEVEL.ERROR, false);
                    return false;
                }

                // 3. 파일과 연결
                FileStream fs = new FileStream(sFileName, FileMode.Open);

                // 4. 파일 데이터를 Byte 배열에 저장
                byte[] input = new byte[fs.Length];
                fs.Read(input, 0, input.Length);
                fs.Close();

                // 5. 신규 gzip파일 생성
                FileStream fsOutput = new FileStream(path + ".gzip", FileMode.Create, FileAccess.Write);

                // 6. Byte 배열을 gzip 파일로 압축.
                GZipStream zip = new GZipStream(fsOutput, CompressionMode.Compress);
                zip.Write(input, 0, input.Length);
                zip.Close();
                fsOutput.Close();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// File decompress to use GZip library
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool ZipDecompress(string path)
        {
            try
            {
                // 1. File Open
                FileStream fs = new FileStream(path + ".gzip", FileMode.Open);

                // 2. New XML File Create
                FileStream fsOutput = new FileStream(path + ".xml", FileMode.Create, FileAccess.Write);

                // 3. GZip Decompress
                GZipStream zip = new GZipStream(fs, CompressionMode.Decompress, true);
                byte[] buffer = new byte[4096];
                int bytesRead;
                bool continueLoop = true;
                while (continueLoop)
                {
                    bytesRead = zip.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        break;
                    }
                    fsOutput.Write(buffer, 0, bytesRead);
                }
                zip.Close();
                fsOutput.Close();
                fs.Close();

                return true;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion

        #region Excel

        /// <summary>
        /// 템플릿 엑셀 파일에 TRSNode의 아이템을 바인딩 시킵니다.
        /// </summary>
        /// <param name="sheet">템플릿 엑셀 파일 시트</param>
        /// <param name="bindingItem">바인딩할 아이템이 있는 TRSNode</param>
        /// <returns></returns>
        public static Excel.Worksheet TemplateBindingFromExcel(Excel.Worksheet sheet, TRSNode bindingItem)
        {
            int iTotalColumn = sheet.Cells.Find("*", Type.Missing, Type.Missing, Type.Missing, Excel.XlSearchOrder.xlByColumns, Excel.XlSearchDirection.xlPrevious, Type.Missing, Type.Missing, Type.Missing).Column;
            int iTotalRow = sheet.Cells.Find("*", Type.Missing, Type.Missing, Type.Missing, Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlPrevious, Type.Missing, Type.Missing, Type.Missing).Row;
            bool isBarcode = false;

            // 현재 로우 개수
            int currentTotalRow = 0;
            for (int row = 1; row <= iTotalRow; row++)
            {
                currentTotalRow = iTotalRow;
                for (int col = 1; col <= iTotalColumn; col++)
                {
                    string cellValue = Convert.ToString((sheet.Cells[row, col] as Excel.Range).Value);

                    if (cellValue is string)
                    {                        
                        if (cellValue.StartsWith("$") && cellValue.EndsWith("}"))
                        {
                            if (cellValue.StartsWith("$B"))
                            {
                                isBarcode = true;
                                cellValue = ((string)cellValue).Substring(2);
                            }
                            else
                            {
                                isBarcode = false;

                            }

                            cellValue = ((string)cellValue).Trim(new Char[] { '$', '{', '}' });

                            string value = "";
                            // 리스트 아이템인경우
                            if (cellValue.Contains("["))
                            {
                                String[] keyValue = ((string)cellValue).Split(new char[] { '[', ']' });
                                String key = CamelToUnderscore(keyValue[0]);
                                String valueMember = CamelToUnderscore(keyValue[2].Substring(1));
                                int listIndex = ToInt(keyValue[1]);

                                TRSNode valueNode = null;

                                try
                                {
                                    valueNode = bindingItem.GetList(key)[listIndex];
                                }
                                catch (Exception)
                                {
                                    (sheet.Cells[row, col] as Excel.Range).Value = value;
                                    continue;
                                }

                                if (valueNode.GetMember(valueMember) != null)
                                    value = valueNode.GetMember(valueMember).Value;
                                (sheet.Cells[row, col] as Excel.Range).Value = value;
                            }
                            else
                            {
                                String key = CamelToUnderscore(((string)cellValue));
                                if (bindingItem.GetMember(key) != null)
                                    value = bindingItem.GetMember(key).Value;
                            }

                            if (value != "" && isBarcode == true)
                            {
                                value = StringToBarcodeString(value);
                            }
                            (sheet.Cells[row, col] as Excel.Range).Value = value;
                        }
                    }
                }
            }

            return sheet;
        }

        /// <summary>
        /// Import를 실행합니다.
        /// Open File Dialog를 사용합니다.
        /// Import한 데이터를 Spread에 Bind 합니다.
        /// </summary>
        /// <param name="spread"></param>
        public static void ExcelImportFromFile(SOISpread spread)
        {
            ExcelImportFromFile(string.Empty, spread);
        }

        /// <summary>
        /// Import를 실행합니다.
        /// File 경로를 지정합니다.
        /// Import한 데이터를 spread에 Bind 합니다.
        /// </summary>
        public static void ExcelImportFromFile(string sExcelFilePath, SOISpread spread)
        {
            // 설정하지 않은 경우
            if (string.IsNullOrEmpty(sExcelFilePath) == true)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    spread.OpenExcel(openFileDialog1.FileName, FarPoint.Excel.ExcelOpenFlags.RowAndColumnHeaders);
                }
            }
            // 설정한 경우
            else
            {
                spread.OpenExcel(sExcelFilePath);
            }
        }

        /// <summary>
        /// Export를 실행합니다.
        /// Save File Dialog를 사용합니다.
        /// 지정된 Spread의 내용을 Excel File로 Export 합니다.
        /// </summary>
        /// <param name="spread"></param>
        public static void ExcelExportToFile(SOISpread spread)
        {
            ExcelExportToFile(spread, string.Empty);
        }

        /// <summary>
        /// Export를 실행합니다.
        /// 임시로 Application root의 temp folder를 생성하고 excel파일을 생성합니다.(xlsx)
        /// 지정된 Spread의 내용을 임시 Excel File로 Export 합니다.
        /// 생성된 파일 path를 return합니다.
        /// </summary>
        /// <param name="spread"></param>
        /// <returns></returns>
        public static string ExcelExportToFile(SOISpread spread, SAVE_FILE_TYPE fileType)
        {
            try
            {
                string sReturnValue = string.Empty;

                // Create "_temp" Directory
                String upgradePath = Application.StartupPath + "\\_temp";
                if (Directory.Exists(upgradePath) == false)
                {
                    Directory.CreateDirectory(upgradePath);
                }

                // Create File
                if(fileType == SAVE_FILE_TYPE.xlsx)
                {
                    String fileName = "savedInputShipData.xlsx";

                    if (File.Exists(upgradePath + "\\" + fileName) == true)
                    {
                        File.Delete(upgradePath + "\\" + fileName);
                    }

                    sReturnValue = upgradePath + "\\" + fileName;

                    using (FileStream fs = File.Create(sReturnValue))
                    {
                    }
                }
                else
                {
                    return string.Empty;
                }

                // Save File
                if (ExcelExportToFile(spread, sReturnValue) == false)
                {
                    return string.Empty;
                }

                return sReturnValue;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return string.Empty;
            }
        }

        /// <summary>
        /// Export를 실행합니다.
        /// File 경로를 지정합니다.
        /// 지정된 Spread의 내용을 Excel File로 Export 합니다.
        /// </summary>
        /// <param name="spread"></param>
        public static bool ExcelExportToFile(SOISpread spread, string sExcelFilePath)
        {
            try
            {
                // 경로가 지정되지 않은 경우
                if (string.IsNullOrEmpty(sExcelFilePath) == true)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.DefaultExt = "xlsx";
                    saveFileDialog1.FileName = "Export Excel";
                    saveFileDialog1.Filter = "Excel Document (*.xlsx) | *.xlsx | Excel 97-2003 Document (*.xls) | *.xls";
                    if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (Path.GetExtension(saveFileDialog1.FileName) == ".xls")
                        {
                            spread.SaveExcel(saveFileDialog1.FileName, FarPoint.Excel.ExcelSaveFlags.SaveAsViewed);
                        }
                        else if (Path.GetExtension(saveFileDialog1.FileName) == ".xlsx")
                        {
                            spread.SaveExcel(saveFileDialog1.FileName, FarPoint.Excel.ExcelSaveFlags.UseOOXMLFormat);
                        }

                        MPCF.ShowMessage(MPCF.GetMessage(15), CliFrx.MSG_LEVEL.INFO, false);
                    }
                }
                // 경로가 지정된 경우
                else
                {
                    if (Path.GetExtension(sExcelFilePath) == ".xls")
                    {
                        spread.SaveExcel(sExcelFilePath, FarPoint.Excel.ExcelSaveFlags.SaveAsViewed);
                    }
                    else if (Path.GetExtension(sExcelFilePath) == ".xlsx")
                    {
                        spread.SaveExcel(sExcelFilePath, FarPoint.Excel.ExcelSaveFlags.UseOOXMLFormat);
                    }

                    MPCF.ShowMessage(MPCF.GetMessage(15), CliFrx.MSG_LEVEL.INFO, false);
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Export를 실행합니다.
        /// Save File Dialog를 사용합니다.
        /// 지정된 Grid의 내용을 Excel File로 Export 합니다.
        /// </summary>
        /// <param name="spread"></param>
        public static void ExcelExportToFile(SOIGrid grid)
        {
            ExcelExportToFile(string.Empty, grid);
        }

        /// <summary>
        /// Export를 실행합니다.
        /// File 경로를 지정합니다.
        /// 지정된 Grid의 내용을 Excel File로 Export 합니다.
        /// </summary>
        /// <param name="spread"></param>
        public static void ExcelExportToFile(string sExcelFilePath, SOIGrid grid)
        {
            UltraGridExcelExporter ultraGridExcelExporter1 = new UltraGridExcelExporter();

            // 경로가 지정되지 않은 경우
            if (string.IsNullOrEmpty(sExcelFilePath) == true)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.DefaultExt = "xlsx";
                saveFileDialog1.FileName = "Export Excel";
                saveFileDialog1.Filter = "Excel Document (*.xlsx) | *.xlsx | Excel 97-2003 Document (*.xls) | *.xls";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ultraGridExcelExporter1.Export(grid, saveFileDialog1.FileName);

                    MPCF.ShowMessage(MPCF.GetMessage(15), CliFrx.MSG_LEVEL.INFO, false);
                }
            }
            // 경로가 지정된 경우
            else
            {
                ultraGridExcelExporter1.Export(grid, sExcelFilePath);

                MPCF.ShowMessage(MPCF.GetMessage(15), CliFrx.MSG_LEVEL.INFO, false);
            }
        }
        
        /// <summary>
        /// ExportToExcel()
        ///       - Export Data of Control to Excel Application Data
        /// Return Value
        ///       - True or False
        /// Arguments
        ///       - ByRef l_control As listview
        ///       - ByVal title As string
        ///       - Optional ByVal Condition As string
        ///       - Optional ByVal umerical As Boolean
        ///       - Optional ByVal ColorFlag As Boolean
        ///       - Optional ByVal bTextBase As Boolean 
        /// </summary>
        /// <param name="l_Control"></param>
        /// <param name="title"></param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public static bool ExportToExcel(Control l_Control, string title, string Condition)
        {
            return ExportToExcel(l_Control, title, Condition, true, false, true, -1, -1);
        }

        /// <summary>
        /// ExportToExcel()
        ///       - Export Data of Control to Excel Application Data
        /// </summary>
        /// <param name="l_Control"></param>
        /// <param name="title"></param>
        /// <param name="Condition"></param>
        /// <param name="ColorFlag"></param>
        /// <param name="bTextBase"></param>
        /// <param name="bShowDate"></param>
        /// <param name="iStartCol"></param>
        /// <param name="iEndCol"></param>
        /// <returns></returns>
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

                //if (l_Control is ListView)
                //{
                //    return ListviewToExcel((ListView)l_Control, title, Condition, ColorFlag, bTextBase, bShowDate);
                //}
                if (l_Control is FarPoint.Win.Spread.FpSpread)
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

        /// <summary>
        /// 엑셀 파일로 저장합니다.
        /// </summary>
        public static void ExportToExcel(FarPoint.Win.Spread.SheetView sheet, string fileName, bool bUsingSheetName = false)
        {
            try
            {
                FarPoint.Win.Spread.FpSpread spread = new FarPoint.Win.Spread.FpSpread();

                if (!bUsingSheetName)
                    sheet.SheetName = "Sheet1";

                sheet.Protect = false;
                spread.Sheets.Add(sheet);

                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Excel File|*.xlsx";

                if (!String.IsNullOrEmpty(fileName))
                    dlg.FileName = fileName + "_";

                foreach (char ch in Path.GetInvalidFileNameChars())
                    dlg.FileName = dlg.FileName.Replace(ch, 'A');

                dlg.FileName += DateTime.Now.ToString("yyyyMMddHHmmss");

                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;

                bool saveSuccess = spread.SaveExcel(dlg.FileName,
                    FarPoint.Excel.ExcelSaveFlags.SaveBothCustomRowAndColumnHeaders |
                    FarPoint.Excel.ExcelSaveFlags.SaveAlternatingRowStyles |
                    FarPoint.Excel.ExcelSaveFlags.UseOOXMLFormat);

                if (!saveSuccess)
                    return;

                if (saveSuccess)
                    System.Diagnostics.Process.Start(dlg.FileName);
            }
            catch { }
        }
        
        /// <summary>
        /// SpreadSheetToExcel()
        ///       - Export Data of Spread Sheet Control to Excel Application Data
        /// Return Value
        ///       - True or False
        /// Arguments
        ///       - ByRef l_control As Spread Sheet
        ///       - ByVal title As string
        ///       - Optional ByVal Condition As string
        ///       - Optional ByVal ColorFlag As Boolean
        ///       - Optional ByVal bTextBase As Boolean
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="title"></param>
        /// <param name="Condition"></param>
        /// <param name="ColorFlag"></param>
        /// <param name="bTextBase"></param>
        /// <param name="bShowDate"></param>
        /// <param name="i_start_col"></param>
        /// <param name="i_end_col"></param>
        /// <returns></returns>
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

        #endregion

        #region Print

        /// <summary>
        /// FpSpread의 Print Info에 대한 기본값을 설정합니다.
        /// </summary>
        /// <param name="spread"></param>
        public static bool SetSpreadPrintDefaultInfo(FpSpread spread)
        {
            try
            {
                // Validation
                if (spread.Sheets.Count < 1)
                {
                    return false;
                }

                // Set Print Info
                if (spread.Sheets[0].PrintInfo == null)
                {
                    spread.Sheets[0].PrintInfo = new PrintInfo();
                }

                // Set Use Max
                // 빈 Row 또는 빈 Column도 프린트 하도록 설정합니다.
                spread.Sheets[0].PrintInfo.UseMax = false;

                // Set Smart Rule
                // 용지의 방향을 자동 설정하도록 합니다.
                // 전체내용이 용지보다 큰 경우 최소 원래크기의 60%까지 줄여 용지내에 포함될 수 있는지 확인하고,
                // 60%를 줄여도 용지에 모두 포함되지 않으면 원래크기로 출력합니다.
                SmartPrintRulesCollection prules = new SmartPrintRulesCollection();
                prules.Add(new FarPoint.Win.Spread.LandscapeRule(FarPoint.Win.Spread.ResetOption.None));
                prules.Add(new FarPoint.Win.Spread.ScaleRule(FarPoint.Win.Spread.ResetOption.None, 1.0F, 0.6F, 0.1F));
                spread.Sheets[0].PrintInfo.SmartPrintRules = prules;

                // Set Smart Rule Use
                // Smart Print를 사용합니다.
                spread.Sheets[0].PrintInfo.UseSmartPrint = true;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// 레지스트리에서 각 화면별로 설정된 Print Option을 가져옵니다.
        /// </summary>
        /// <param name="printOption"></param>
        /// <returns></returns>
        public static bool GetPrintOptionFromReg(ref PrintOptionModel printOption, string funcName)
        {
            try
            {
                if (printOption == null)
                {
                    printOption = new PrintOptionModel();
                }

                System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();                

                printOption.Document.PrinterName = MPCF.GetRegSetting(Application.ProductName, "PrintOptionDoc" + funcName, "PrinterName", pd.PrinterSettings.PrinterName);
                printOption.Label.ConnectionType = MPCF.GetRegSetting(Application.ProductName, "PrintOptionLabel" + funcName, "ConnectType", "Driver");
                printOption.Label.PrinterName = MPCF.GetRegSetting(Application.ProductName, "PrintOptionLabel" + funcName, "PrinterName", pd.PrinterSettings.PrinterName);
                printOption.Label.Port = MPCF.GetRegSetting(Application.ProductName, "PrintOptionLabel" + funcName, "Port", "");
                printOption.Label.BaudRate = MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "PrintOptionLabel" + funcName, "BaudRate", ""));
                printOption.Label.DataBit = MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "PrintOptionLabel" + funcName, "DataBit", ""));
                string regParity = MPCF.GetRegSetting(Application.ProductName, "PrintOptionLabel" + funcName, "Parity", "");
                printOption.Label.Parity = (regParity == "" ? Parity.None : (Parity)Enum.Parse(typeof(Parity), regParity));
                string regStopBit = MPCF.GetRegSetting(Application.ProductName, "PrintOptionLabel" + funcName, "StopBits", "");
                printOption.Label.StopBits = (regStopBit == "" ? StopBits.None : (StopBits)Enum.Parse(typeof(StopBits), regStopBit)); 
                string regHandshake = MPCF.GetRegSetting(Application.ProductName, "PrintOptionLabel" + funcName, "Handshake", "");
                printOption.Label.Handshake = (regHandshake == "" ? Handshake.None : (Handshake)Enum.Parse(typeof(Handshake), regHandshake));

                return true;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// 화면별 Print Option 내용을 저장합니다.
        /// </summary>
        /// <param name="printOption"></param>
        /// <param name="funcName"></param>
        /// <returns></returns>
        public static bool SetPrintOptionToReg(PrintOptionModel printOption, string funcName)
        {
            try
            {
                if (printOption == null)
                {
                    return false;
                }

                MPCF.SaveRegSetting(Application.ProductName, "PrintOptionDoc" + funcName, "PrinterName", printOption.Document.PrinterName);
                MPCF.SaveRegSetting(Application.ProductName, "PrintOptionLabel" + funcName, "ConnectType", printOption.Label.ConnectionType);
                MPCF.SaveRegSetting(Application.ProductName, "PrintOptionLabel" + funcName, "PrinterName", printOption.Label.PrinterName);
                MPCF.SaveRegSetting(Application.ProductName, "PrintOptionLabel" + funcName, "Port", printOption.Label.Port);
                MPCF.SaveRegSetting(Application.ProductName, "PrintOptionLabel" + funcName, "BaudRate", printOption.Label.BaudRate);
                MPCF.SaveRegSetting(Application.ProductName, "PrintOptionLabel" + funcName, "DataBit", printOption.Label.DataBit);
                MPCF.SaveRegSetting(Application.ProductName, "PrintOptionLabel" + funcName, "Parity", printOption.Label.Parity);
                MPCF.SaveRegSetting(Application.ProductName, "PrintOptionLabel" + funcName, "StopBits", printOption.Label.StopBits);
                MPCF.SaveRegSetting(Application.ProductName, "PrintOptionLabel" + funcName, "Handshake", printOption.Label.Handshake);

                return true;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Print Option 화면을 엽니다.
        /// 적용할 값을 입력해야 합니다.
        /// 화면별로 레지스트리에 저장되므로 화면명을 입력해야 합니다.
        /// 화면이 닫힌 이후 설정된 값을 다시 반환합니다.
        /// </summary>
        /// <param name="printOption"></param>
        /// <param name="funcName"></param>
        /// <returns></returns>
        public static PrintOptionModel ShowPrintOption(Form owner, string funcName)
        {
            try
            {
                frmPrintOptionPopup frmOption = new frmPrintOptionPopup();

                // Print Option Popup 초기화
                frmOption.Owner = owner;
                frmOption.funcName = funcName;

                // Show Dialog
                if (frmOption.ShowDialog() == DialogResult.OK)
                {
                    return frmOption.printOption;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return null;
            }
        }

        /// <summary>
        /// Spread를 프린트 합니다.
        /// </summary>
        /// <param name="printOption"></param>
        /// <param name="targetSpread"></param>
        /// <returns></returns>
        public static bool PrintSpread(Form frm, PrintOptionModel printOption, SOISpread targetSpread)
        {
            try
            {
                clsPrinter printer = new clsPrinter();
                PrintOptionModel checkOption;

                // Option Check
                if (string.IsNullOrEmpty(printOption.Document.PrinterName) == true)
                {
                    checkOption = ShowPrintOption(frm, ((MenuInfoTag)frm.Tag).s_func_name);

                    if (checkOption == null)
                    {
                        return false;
                    }
                    else
                    {
                        printOption = checkOption;
                    }
                }

                // Start Print
                MPGV.gIMdiForm.ShowLoadingScreen(true);
                ShowMessage(GetMessage(16), MSG_LEVEL.INFO, false);

                SOISpread copySpread = new SOISpread();
                FarPoint.Win.Spread.SheetView sheetToPrint = new SheetView();
                sheetToPrint = targetSpread.Sheets[0];
                copySpread.Sheets.Add(sheetToPrint);

                copySpread.Sheets[0].PrintInfo.Printer = printOption.Document.PrinterName;
                copySpread.PrintSheet(0); 

                // Start Print
                MPGV.gIMdiForm.ShowLoadingScreen(false);
                ShowMessage(GetMessage(17), MSG_LEVEL.INFO, false);

                return true;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Flexible Screen을 프린트 합니다.
        /// Label 출력을 하거나 또는 문서로 출력합니다.
        /// </summary>
        /// <returns></returns>
        public static bool PrintFlexibleScreen(Form frm, PrintOptionModel printOption, SOIFlexibleScreen targetScreen, bool isLabel)
        {
            try
            {
                clsPrinter printer = new clsPrinter();
                PrintOptionModel checkOption;

                // Label 출력인 경우
                if (isLabel == true)
                {
                    // Check Printer Setting
                    if (string.IsNullOrEmpty(printOption.Label.PrinterName) == true)
                    {
                        checkOption = ShowPrintOption(frm, ((MenuInfoTag)frm.Tag).s_func_name);

                        if (checkOption == null)
                        {
                            return false;
                        }
                        else
                        {
                            printOption = checkOption;
                        }
                    }

                    if (printOption.Label.ConnectionType.Equals("COM"))
                    {
                        ShowMessage(GetMessage(18), MSG_LEVEL.ERROR, false);
                        return false;
                    }

                    // Start Print
                    MPGV.gIMdiForm.ShowLoadingScreen(true);
                    ShowMessage(GetMessage(16), MSG_LEVEL.INFO, false);

                    SOISpread copySpread = new SOISpread();
                    FarPoint.Win.Spread.SheetView sheetToPrint = new SheetView();
                    sheetToPrint = targetScreen.ScreenSpread.Sheets[0];
                    copySpread.Sheets.Add(sheetToPrint);

                    copySpread.Sheets[0].PrintInfo.Printer = printOption.Label.PrinterName;
                    copySpread.PrintSheet(0);

                    // Start Print
                    MPGV.gIMdiForm.ShowLoadingScreen(false);
                    ShowMessage(GetMessage(17), MSG_LEVEL.INFO, false);

                }
                // 문서 출력인 경우
                else
                {
                    // Check Printer Setting
                    if (string.IsNullOrEmpty(printOption.Document.PrinterName) == true)
                    {
                        checkOption = ShowPrintOption(frm, ((MenuInfoTag)frm.Tag).s_func_name);

                        if (checkOption == null)
                        {
                            return false;
                        }
                        else
                        {
                            printOption = checkOption;
                        }
                    }

                    // Start Print
                    MPGV.gIMdiForm.ShowLoadingScreen(true);
                    ShowMessage(GetMessage(16), MSG_LEVEL.INFO, false);

                    SOISpread copySpread = new SOISpread();
                    FarPoint.Win.Spread.SheetView sheetToPrint = new SheetView();
                    sheetToPrint = targetScreen.ScreenSpread.Sheets[0];
                    copySpread.Sheets.Add(sheetToPrint);

                    copySpread.Sheets[0].PrintInfo.Printer = printOption.Document.PrinterName;
                    copySpread.PrintSheet(0);

                    // Start Print
                    MPGV.gIMdiForm.ShowLoadingScreen(false);
                    ShowMessage(GetMessage(17), MSG_LEVEL.INFO, false);
                }

                return true;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Grid를 프린트 합니다.
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="printOption"></param>
        /// <param name="targetGrid"></param>
        /// <returns></returns>
        public static bool PrintGrid(Form frm, PrintOptionModel printOption, SOIGrid targetGrid)
        {
            try
            {
                clsPrinter printer = new clsPrinter();
                PrintOptionModel checkOption;

                // Option Check
                if (string.IsNullOrEmpty(printOption.Document.PrinterName) == true)
                {
                    checkOption = ShowPrintOption(frm, ((MenuInfoTag)frm.Tag).s_func_name);

                    if (checkOption == null)
                    {
                        return false;
                    }
                    else
                    {
                        printOption = checkOption;
                    }
                }

                ShowMessage(GetMessage(16), MSG_LEVEL.INFO, false);

                targetGrid.Print();

                ShowMessage(GetMessage(17), MSG_LEVEL.INFO, false);

                return true;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// 설정에 따라 Label을 Print 합니다.
        /// Label ID를 GCM Table에서 검색하여 Label Command를 가져온 후, Mapping한 이후에 발행합니다.
        /// </summary>
        /// <param name="printOption"></param>
        /// <param name="command"></param>
        /// <param name="copy"></param>
        /// <param name="imageData"></param>
        /// <returns></returns>
        public static bool PrintLabelByLabelID(Form owner, PrintOptionModel printOption, string labelIDGCMTable, string labelIDKey, TRSNode mappingNode)
        {
            try
            {
                TRSNode in_node = new TRSNode("PRINT_LABEL_COMMON_IN");
                TRSNode out_node = new TRSNode("PRINT_LABEL_COMMON_OUT");
                string sLabelID = string.Empty;
                string sLabelCommand = string.Empty;

                // Check Print Setting
                if (string.IsNullOrEmpty(printOption.Label.PrinterName) == true)
                {
                    printOption = ShowPrintOption(owner, ((MenuInfoTag)owner.Tag).s_func_name);

                    if (printOption == null
                        || string.IsNullOrEmpty(printOption.Label.PrinterName) == true)
                    {
                        return false;
                    }
                }

                // 1. Get Label ID (from GCM Table)
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", labelIDGCMTable);
                in_node.AddString("KEY_1", labelIDKey);
                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                {
                    return false;
                }
                if (out_node.GetList(0) == null || out_node.GetList(0).Count < 1)
                {
                    // Label ID or Label Command does not exist.
                    MPCF.ShowMessage(MPCF.GetMessage(75), MSG_LEVEL.ERROR, false);
                    return false;
                }
                List<TRSNode> labelIDList = out_node.GetList(0);
                foreach (TRSNode node in labelIDList)
                {
                    sLabelID = node.GetString("DATA_2");
                    break;
                }
                if (sLabelID == string.Empty)
                {
                    // Label ID or Label Command does not exist.
                    MPCF.ShowMessage(MPCF.GetMessage(75), MSG_LEVEL.ERROR, false);
                    return false;
                }

                // 2. Get Label Command
                in_node.Init();
                out_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LABEL_ID", sLabelID);
                if (MPCF.CallService("LBL", "LBL_View_Label", in_node, ref out_node) == false)
                {
                    return false;
                }
                sLabelCommand = out_node.GetString("PRINT_COMMAND");
                if (string.IsNullOrEmpty(sLabelCommand) == true)
                {
                    // Label ID or Label Command does not exist.
                    MPCF.ShowMessage(MPCF.GetMessage(75), MSG_LEVEL.ERROR, false);
                    return false;
                }

                // 3. Command Transfer
                for (int i = 0; i < mappingNode.MemberCount; i++)
                {
                    sLabelCommand = sLabelCommand.Replace("$" + mappingNode.GetMember(i).Name + "$", mappingNode.GetMember(i).Value);
                }

                // 4. Print 
                if (PrintLabelByCommand(owner, printOption, sLabelCommand, 1, null) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// 설정에 따라 Label을 Print 합니다.
        /// Lot ID를 검색하여 지정된 라벨 커맨드를 프린트 합니다.
        /// </summary>
        /// <param name="printOption"></param>
        /// <param name="command"></param>
        /// <param name="copy"></param>
        /// <param name="imageData"></param>
        /// <returns></returns>
        public static bool PrintLabelByLotID(Form owner, PrintOptionModel printOption, string psLotID)
        {
            try
            {
                // Check Print Setting
                if (string.IsNullOrEmpty(printOption.Label.PrinterName) == true)
                {
                    printOption = ShowPrintOption(owner, ((MenuInfoTag)owner.Tag).s_func_name);

                    if (printOption == null
                        || string.IsNullOrEmpty(printOption.Label.PrinterName) == true)
                    {
                        return false;
                    }
                }

                TRSNode in_node = new TRSNode("PRINT_LABEL_COMMON_IN");
                TRSNode out_node = new TRSNode("PRINT_LABEL_COMMON_OUT");
                string sLabelID = string.Empty;
                string sLabelCommand = string.Empty;

                // 1. Check Validation
                // Nothing to check

                // 2. Get Label ID 
                // when "LBL_View_Label" service is used.

                // 3. Get Label Command
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", psLotID);
                if (MPCF.CallService("LBL", "LBL_Get_Label_Print_Command", in_node, ref out_node) == false)
                {
                    return false;
                }
                if (out_node.GetList(0).Count > 0)
                {
                    sLabelID = out_node.GetList(0)[0].GetString("LABEL_ID");
                    foreach (TRSNode node in out_node.GetList(0)[0].GetList("CMD_LIST"))
                    {
                        sLabelCommand = node.GetString("CMD_1");
                    }
                }
                if (string.IsNullOrEmpty(sLabelCommand) == true)
                {
                    // Label ID or Label Command does not exist.
                    MPCF.ShowMessage(MPCF.GetMessage(75), MSG_LEVEL.ERROR, false);
                    return false;
                }

                // 4. Command Transfer 
                // when "LBL_View_Label" service is used.

                // 5. Print
                if (PrintLabelByCommand(owner, printOption, sLabelCommand, 1, null) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// 설정에 따라 Label을 Print 합니다.
        /// COM 또는 DRIVER 설정에 따라 프린트 합니다.
        /// </summary>
        /// <param name="printOption"></param>
        /// <param name="command"></param>
        /// <param name="copy"></param>
        /// <param name="imageData"></param>
        /// <returns></returns>
        public static bool PrintLabelByCommand(Form owner, PrintOptionModel printOption, string command, int copy, List<string> imageData)
        {
            try
            {
                // Printer
                clsPrinter printer = new clsPrinter();

                // Check Print Setting
                if (string.IsNullOrEmpty(printOption.Label.PrinterName) == true)
                {
                    printOption = ShowPrintOption(owner, ((MenuInfoTag)owner.Tag).s_func_name);

                    if (printOption == null)
                    {
                        return false;
                    }
                }

                // COM Print
                if (printOption.Label.ConnectionType.Equals("COM"))
                {
                    printer.SetPortOption(printOption.Label.Port,
                        printOption.Label.BaudRate,
                        printOption.Label.Parity,
                        printOption.Label.DataBit,
                        printOption.Label.StopBits,
                        printOption.Label.Handshake);

                    ShowMessage(GetMessage(16), MSG_LEVEL.INFO, false);

                    if (printer.PrintByPort(printOption.Label.Port, command, copy, imageData) == false)
                    {
                        ShowMessage(GetMessage(18), MSG_LEVEL.WARNING, false);
                        return false;
                    }

                    ShowMessage(GetMessage(17), MSG_LEVEL.INFO, false);
                }
                // DRIVER Print
                else if(printOption.Label.ConnectionType.Equals("Driver"))
                {
                    ShowMessage(GetMessage(16), MSG_LEVEL.INFO, false);

                    if (printer.PrintByName(printOption.Label.PrinterName, command, copy, imageData) == false)
                    {
                        ShowMessage(GetMessage(18), MSG_LEVEL.WARNING, false);
                        return false;
                    }

                    ShowMessage(GetMessage(17), MSG_LEVEL.INFO, false);
                }

                return true;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// 설정에 따라 Runsheet를 Document Print 합니다.
        /// Lot ID와 Material ID를 필요로 합니다.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="printOption"></param>
        /// <param name="data"></param>
        /// <param name="mappingNode"></param>
        /// <returns></returns>
        public static bool PrintRunsheet(Form owner, PrintOptionModel printOption, string psLotID, string psMatID, TRSNode orderNode)
        {
            try
            {
                // Check Print Setting
                if (string.IsNullOrEmpty(printOption.Document.PrinterName) == true)
                {
                    printOption = ShowPrintOption(owner, ((MenuInfoTag)owner.Tag).s_func_name);

                    if (printOption == null
                        || string.IsNullOrEmpty(printOption.Document.PrinterName) == true)
                    {
                        return false;
                    }
                }

                TRSNode in_node = new TRSNode("PRINT_RUNSHEET_COMMON_IN");
                TRSNode out_node = new TRSNode("PRINT_RUNSHEET_COMMON_OUT");

                // 1. Get Runsheet (Common runsheet)
                MPCF.SetInMsg(in_node);
                if (MPCF.CallService("WIP", "WIP_View_Runsheet", in_node, ref out_node) == false)
                {
                    return false;
                }
                byte[] runsheet = out_node.GetBlob(MPGC.MP_BIN_DATA_1);

                // 2. Get Operation List for Mapping
                in_node.Init();
                out_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("MAT_ID", psMatID);
                if (MPCF.CallService("WIP", "WIP_View_Operation_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Loading 화면 시작
                MPGV.gIMdiForm.ShowLoadingScreen(true);

                // 3. Mapping Node Generation
                TRSNode mappingNode = new TRSNode("OUT");
                CopyTRSNodeMember(mappingNode, orderNode);
                mappingNode.AddString("LOT_ID", psLotID);
                foreach (TRSNode node in out_node.GetList(0))
                {
                    TRSNode oper = mappingNode.AddNode("OPER_LIST");
                    oper.AddString("OPER", node.GetString("OPER"));
                    oper.AddString("OPER_DESC", node.GetString("OPER_DESC"));
                }

                // 4. Excel Setup
                string path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".xlsx";
                File.WriteAllBytes(path, runsheet);

                Excel.Application ExcelApp = new Excel.Application();
                ExcelApp.Visible = false;
                ExcelApp.DisplayAlerts = false;
                Excel.Workbook WBook = ExcelApp.Workbooks.Open(path, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, 
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                Excel.Worksheet sheet = (Excel.Worksheet) WBook.ActiveSheet;

                // 5. Mapping
                sheet = TemplateBindingFromExcel(sheet, mappingNode);
                ShowMessage(GetMessage(16), MSG_LEVEL.INFO, false);

                // 6. Print
                WBook.PrintOut(Missing.Value, Missing.Value, Missing.Value, Missing.Value, 
                    printOption.Document.PrinterName, Missing.Value, Missing.Value, Missing.Value);
                WBook.Close(false, Missing.Value, Missing.Value);
                ExcelApp.Quit();
                File.Delete(path);
                ShowMessage(GetMessage(17), MSG_LEVEL.INFO, false);

                // Loading 화면 시작
                MPGV.gIMdiForm.ShowLoadingScreen(false);

                return true;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion

        #region Date Format

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

        /// <summary>
        /// 일반 문자열을 Time Format으로 변환
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public static string MakeDateFormat(string S)
        {
            return MakeDateFormat(S, DATE_TIME_FORMAT.NONE);
        }

        /// <summary>
        /// 일반 문자열을 Time Format으로 변환
        /// </summary>
        /// <param name="S"></param>
        /// <param name="DateTimeFormat"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Change 14 byte DateTime format of DateTimePicker
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
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
                ShowErrorMessage("MPCF.ToDate()\n" + ex.Message);
                return DateTime.Now;
            }
        }

        /// <summary>
        /// Change 14 byte DateTime format of DateTimePicker
        /// </summary>
        /// <param name="dtpTime"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Change 14 byte DateTime format of DateTimePicker
        /// </summary>
        /// <param name="dtpTime"></param>
        /// <returns></returns>
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
                ShowErrorMessage("MPCF.DateToString()\n" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Change 14 byte DateTime format of object
        /// </summary>
        /// <param name="objtime"></param>
        /// <returns></returns>
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
                ShowErrorMessage("MPCF.FromDate()\n" + ex.Message);
                return "";
            }

        }

        // FromDate()
        //       -   Change 14 byte DateTime format of DateTimePicker
        // Return Value
        //       - String : 14 byte DateTime
        // Arguments
        //       - ByVal dtpTime As DateTimePicker
        //
        public static string FromDate(SOIDateTime dtpTime)
        {

            string sDateTime = "";
            DateTime DTime;

            try
            {
                DTime = MPCF.ToDate(dtpTime.Text);


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
  
        #endregion

        #region Message

        /// <summary>
        /// Get Error Message Parse
        /// </summary>
        /// <param name="iMsgID"></param>
        /// <param name="sValue"></param>
        /// <returns></returns>
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

        #endregion

        #region TRSNode

        /// <summary>
        /// Source TRSNode를 Destination TRSNode로 복사합니다.
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="src"></param>
        public static void CopyTRSNodeMember(TRSNode dest, TRSNode src)
        {
            int i;

            if (src == null)
            {
                dest = null;
                return;
            }
            if (dest == null)
            {
                return;
            }

            for (i = 0; i < src.MemberCount; i++)
            {
                switch (src.Members[i].ValueType)
                {
                    case TRSDataType.String:
                        dest.SetString(src.Members[i].Name, src.GetString(src.Members[i].Name));
                        break;
                    case TRSDataType.Char:
                        dest.SetChar(src.Members[i].Name, src.GetChar(src.Members[i].Name));
                        break;
                    case TRSDataType.Binary:
                        dest.SetBinary(src.Members[i].Name, src.GetBinary(src.Members[i].Name));
                        break;
                    case TRSDataType.Boolean:
                        dest.SetBoolean(src.Members[i].Name, src.GetBoolean(src.Members[i].Name));
                        break;
                    case TRSDataType.UByte:
                        dest.SetUByte(src.Members[i].Name, src.GetUByte(src.Members[i].Name));
                        break;
                    case TRSDataType.UShort:
                        dest.SetUShort(src.Members[i].Name, src.GetUShort(src.Members[i].Name));
                        break;
                    case TRSDataType.UInt:
                        dest.SetUInt(src.Members[i].Name, src.GetUInt(src.Members[i].Name));
                        break;
                    case TRSDataType.ULong:
                        dest.SetULong(src.Members[i].Name, src.GetULong(src.Members[i].Name));
                        break;
                    case TRSDataType.Float:
                        dest.SetFloat(src.Members[i].Name, src.GetFloat(src.Members[i].Name));
                        break;
                    case TRSDataType.Double:
                        dest.SetDouble(src.Members[i].Name, src.GetDouble(src.Members[i].Name));
                        break;
                    case TRSDataType.Byte:
                        dest.SetByte(src.Members[i].Name, src.GetByte(src.Members[i].Name));
                        break;
                    case TRSDataType.Short:
                        dest.SetShort(src.Members[i].Name, src.GetShort(src.Members[i].Name));
                        break;
                    case TRSDataType.Int:
                        dest.SetInt(src.Members[i].Name, src.GetInt(src.Members[i].Name));
                        break;
                    case TRSDataType.Long:
                        dest.SetLong(src.Members[i].Name, src.GetLong(src.Members[i].Name));
                        break;
                    case TRSDataType.Datetime:
                        if (src.Members[i].DateTimeFormat != "")
                            dest.SetDatetime(src.Members[i].Name, src.GetDatetime(src.Members[i].Name) as string, src.Members[i].DateTimeFormat);
                        else
                            dest.SetDatetime(src.Members[i].Name, src.GetDatetime(src.Members[i].Name));
                        break;
                    case TRSDataType.Blob:
                        dest.SetBlob(src.Members[i].Name, src.GetBlob(src.Members[i].Name));
                        break;
                    case TRSDataType.Object:
                        dest.SetObject(src.Members[i].Name, src.GetObject(src.Members[i].Name));
                        break;
                    default:
                        break;
                }
            }

            for (i = 0; i < src.ListCount; i++)
            {
                string srcName = src.Lists[i].name;
                TRSNode node = new TRSNode(srcName);

                CopyTRSNodeMember(node, src.GetList(srcName)[i]);

                dest.AddNode(node);
            }
        }

        #endregion
    }
}
