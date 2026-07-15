using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Data;
using System.Threading;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Printing;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx;
using Miracom.TRSCore;
using SOI.CliFrx;
using SOI.MsgHandlerH101;
//using System.Windows.Forms.DataVisualization.Charting;

//using Miracom.CliFrx;
//using Miracom.MESCore;
//using Miracom.TRSCore;
//using Miracom.POPCore;
//using Miracom.DNMCore;
//using Miracom.MsgHandler;
//using Miracom.UI.Controls.SOICodeView;

using FarPoint.Win.Spread;
using Infragistics.Shared;
using Infragistics.Win.UltraWinEditors;
using SOI.OIFrx.SOIControls;
using Miracom.POPCore;

namespace SOI.Solar
{
    public enum Formatter { Number, Double1, Double2, Double3, Long, String, Percent, PercentDouble, PercentDouble2, Image, ChkType, Button, ShortDateTime, LongDateTime, PlusNumber, PlusDouble3 };
    
    public sealed class CSCF
    {
        #region " ShowStatusMsg "

        public static bool ShowStatusMsg(Label lblStatus, char c_step, string sMessage)
        {
            try
            {
                if (c_step == 'S')
                {
                    lblStatus.BackColor = Color.Green;
                }
                else if (c_step == 'R')
                {
                    sMessage = "";
                    lblStatus.BackColor = SystemColors.Control;
                }
                else if (c_step == 'E')
                {
                    lblStatus.BackColor = Color.Red;
                }

                lblStatus.Text = sMessage;

                return true;
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
                return false;
            }
        }

        public static bool ShowStatusMsg(SOI.Solar.Controls.udcScrollingTextCtrl lblStatus, char c_step, string sMessage)
        {
            return ShowStatusMsg(lblStatus, c_step, sMessage, false);
        }
        public static bool ShowStatusMsg(SOI.Solar.Controls.udcScrollingTextCtrl lblStatus, char c_step, string sMessage, bool bShowMsgBox)
        {
            try
            {
                if (bShowMsgBox == true)
                {
                    MPCF.ShowMsgBox(sMessage);
                }
                else
                {
                    if (lblStatus != null)
                    {
                        lblStatus.Stop();
                        lblStatus.Visible = false;
                        lblStatus.DougScrollingTextColor1 = Color.Navy;
                        lblStatus.DougScrollingTextColor2 = Color.Navy;

                        if (c_step == 'S')
                        {
                            lblStatus.BackColor = Color.FromArgb(233, 234, 237);
                        }
                        else if (c_step == 'R')
                        {
                            sMessage = "";
                            lblStatus.Visible = false;
                        }
                        else if (c_step == 'E')
                        {
                            lblStatus.BackColor = Color.FromArgb(247, 151, 178);
                        }

                        lblStatus.SCROLLTEXT = sMessage;

                        if (c_step != 'R')
                        {
                            lblStatus.Start();
                            lblStatus.Visible = true;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
                return false;
            }
        }

        public static bool ShowStatusMsg2(SOI.Solar.Controls.udcScrollingTextCtrl lblStatus, char c_step, string sMessage)
        {
            try
            {
                lblStatus.Stop();
                lblStatus.Visible = false;
                lblStatus.DougScrollingTextColor1 = Color.Navy;
                lblStatus.DougScrollingTextColor2 = Color.Navy;

                if (c_step == 'S')
                {
                    //lblStatus.BackColor = Color.FromArgb(233, 234, 237);
                }
                else if (c_step == 'R')
                {
                    sMessage = "";
                    lblStatus.Visible = false;
                }
                else if (c_step == 'E')
                {
                    //lblStatus.BackColor = Color.FromArgb(238, 30, 89);
                }

                lblStatus.SCROLLTEXT = sMessage;

                if (c_step != 'R')
                {
                    lblStatus.Start();
                    lblStatus.Visible = true;
                }

                return true;
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
                return false;
            }
        }
        #endregion

        #region " CheckContinueProcMB "

        public static bool CheckContinueProcMB(TRSNode node, Label lblStatus)
        {
            //frmMessageBox frmMsg;
            //ReturnMessageString retMsg;

            try
            {
                if (node.GetMember(TRSDefine.OUT_STATUSVALUE) == null)
                {
                    return false;
                }

                ShowStatusMsg(lblStatus, 'R', "");

                if (node.StatusValue == MPGC.MP_SUCCESS_STATUS && node.MsgCate == MPGC.MP_MSG_CATE_WARN)
                {
                    //retMsg = new ReturnMessageString();
                    //retMsg.IsServerMsgFlag = true;
                    //retMsg.IsNodeMsgFlag = true;
                    //retMsg.MsgCode = node.GetString(TRSDefine.OUT_MSGCODE);
                    //retMsg.ErrorMsg = node.GetString(TRSDefine.OUT_MSG);
                    //retMsg.DBErrorMsg = node.GetString(TRSDefine.OUT_DBERRMSG);
                    //if (node.GetList(TRSDefine.OUT_FIELDMSG).Count > 0)
                    //{
                    //    retMsg.SetFieldMsg = node.GetList(TRSDefine.OUT_FIELDMSG)[0];
                    //}

                    //MPGV.gaWarningMsg.Add(retMsg);

                    ShowStatusMsg(lblStatus, 'E', node.GetString(TRSDefine.OUT_MSG));
                }
                else if (node.StatusValue == MPGC.MP_WARN_STATUS)
                {
                    //retMsg = new ReturnMessageString();
                    //retMsg.IsServerMsgFlag = true;
                    //retMsg.IsNodeMsgFlag = true;
                    //retMsg.MsgCode = node.GetString(TRSDefine.OUT_MSGCODE);
                    //retMsg.ErrorMsg = node.GetString(TRSDefine.OUT_MSG);
                    //retMsg.DBErrorMsg = node.GetString(TRSDefine.OUT_DBERRMSG);
                    //if (node.GetList(TRSDefine.OUT_FIELDMSG).Count > 0)
                    //{
                    //    retMsg.SetFieldMsg = node.GetList(TRSDefine.OUT_FIELDMSG)[0];
                    //}

                    //frmMsg = new frmMessageBox();
                    //frmMsg.Show(retMsg, Application.ProductName, MessageBoxButtons.OK, 1, MPGV.gfrmMDI);

                    //retMsg = null;
                    //frmMsg.Owner = null;
                    //frmMsg = null;

                    ShowStatusMsg(lblStatus, 'E', node.GetString(TRSDefine.OUT_MSG));
                }

                if (node.StatusValue == MPGC.MP_SUCCESS_STATUS || node.StatusValue == MPGC.MP_WARN_STATUS)
                {
                    ShowStatusMsg(lblStatus, 'S', node.GetString(TRSDefine.OUT_MSG));
                    return true;
                }

                //retMsg = new ReturnMessageString();
                //retMsg.IsServerMsgFlag = true;
                //retMsg.IsNodeMsgFlag = true;
                //retMsg.MsgCode = node.GetString(TRSDefine.OUT_MSGCODE);
                //retMsg.ErrorMsg = node.GetString(TRSDefine.OUT_MSG);
                //retMsg.DBErrorMsg = node.GetString(TRSDefine.OUT_DBERRMSG);
                //if (node.GetList(TRSDefine.OUT_FIELDMSG).Count > 0)
                //{
                //    retMsg.SetFieldMsg = node.GetList(TRSDefine.OUT_FIELDMSG)[0];
                //}

                //frmMsg = new frmMessageBox();
                //frmMsg.Show(retMsg, Application.ProductName, MessageBoxButtons.OK, 1, MPGV.gfrmMDI);

                //retMsg = null;
                //frmMsg.Owner = null;
                //frmMsg = null;

                ShowStatusMsg(lblStatus, 'E', node.GetString(TRSDefine.OUT_MSG));

                MPGV.gaWarningMsg.Clear();

                return false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("MPCR.CheckContinueProc()\n" + ex.Message);
                ShowStatusMsg(lblStatus, '2', "MPCR.CheckContinueProc()\n" + ex.Message);
                return false;
            }
        }

        public static bool CheckContinueProcMB(TRSNode node, SOI.Solar.Controls.udcScrollingTextCtrl lblStatus)
        {
            //frmMessageBox frmMsg;
            //ReturnMessageString retMsg;

            string sMsg = string.Empty;

            try
            {
                if (node.GetMember(TRSDefine.OUT_STATUSVALUE) == null)
                {
                    return false;
                }

                ShowStatusMsg(lblStatus, 'R', "");

                if (node.StatusValue == MPGC.MP_SUCCESS_STATUS && node.MsgCate == MPGC.MP_MSG_CATE_WARN)
                {
                    //retMsg = new ReturnMessageString();
                    //retMsg.IsServerMsgFlag = true;
                    //retMsg.IsNodeMsgFlag = true;
                    //retMsg.MsgCode = node.GetString(TRSDefine.OUT_MSGCODE);
                    //retMsg.ErrorMsg = node.GetString(TRSDefine.OUT_MSG);
                    //retMsg.DBErrorMsg = node.GetString(TRSDefine.OUT_DBERRMSG);
                    //if (node.GetList(TRSDefine.OUT_FIELDMSG).Count > 0)
                    //{
                    //    retMsg.SetFieldMsg = node.GetList(TRSDefine.OUT_FIELDMSG)[0];
                    //}

                    //MPGV.gaWarningMsg.Add(retMsg);
                    sMsg = node.GetString(TRSDefine.OUT_MSG);
                    if (node.GetList(TRSDefine.OUT_FIELDMSG).Count > 0)
                    {
                        sMsg += "  " + node.GetList(TRSDefine.OUT_FIELDMSG)[0].GetMember(0).Name +
                              " = [" + node.GetList(TRSDefine.OUT_FIELDMSG)[0].GetMember(0).Value + "]";
                    }
                    ShowStatusMsg(lblStatus, 'E', sMsg);
                }
                else if (node.StatusValue == MPGC.MP_WARN_STATUS)
                {
                    //retMsg = new ReturnMessageString();
                    //retMsg.IsServerMsgFlag = true;
                    //retMsg.IsNodeMsgFlag = true;
                    //retMsg.MsgCode = node.GetString(TRSDefine.OUT_MSGCODE);
                    //retMsg.ErrorMsg = node.GetString(TRSDefine.OUT_MSG);
                    //retMsg.DBErrorMsg = node.GetString(TRSDefine.OUT_DBERRMSG);
                    //if (node.GetList(TRSDefine.OUT_FIELDMSG).Count > 0)
                    //{
                    //    retMsg.SetFieldMsg = node.GetList(TRSDefine.OUT_FIELDMSG)[0];
                    //}

                    //frmMsg = new frmMessageBox();
                    //frmMsg.Show(retMsg, Application.ProductName, MessageBoxButtons.OK, 1, MPGV.gfrmMDI);

                    //retMsg = null;
                    //frmMsg.Owner = null;
                    //frmMsg = null;

                    sMsg = node.GetString(TRSDefine.OUT_MSG);
                    if (node.GetList(TRSDefine.OUT_FIELDMSG).Count > 0)
                    {
                        sMsg += "  " + node.GetList(TRSDefine.OUT_FIELDMSG)[0].GetMember(0).Name +
                              " = [" + node.GetList(TRSDefine.OUT_FIELDMSG)[0].GetMember(0).Value + "]";
                    }

                    ShowStatusMsg(lblStatus, 'E', sMsg);
                }

                if (node.StatusValue == MPGC.MP_SUCCESS_STATUS || node.StatusValue == MPGC.MP_WARN_STATUS)
                {
                    ShowStatusMsg(lblStatus, 'S', node.GetString(TRSDefine.OUT_MSG));
                    return true;
                }

                //retMsg = new ReturnMessageString();
                //retMsg.IsServerMsgFlag = true;
                //retMsg.IsNodeMsgFlag = true;
                //retMsg.MsgCode = node.GetString(TRSDefine.OUT_MSGCODE);
                //retMsg.ErrorMsg = node.GetString(TRSDefine.OUT_MSG);
                //retMsg.DBErrorMsg = node.GetString(TRSDefine.OUT_DBERRMSG);
                //if (node.GetList(TRSDefine.OUT_FIELDMSG).Count > 0)
                //{
                //    retMsg.SetFieldMsg = node.GetList(TRSDefine.OUT_FIELDMSG)[0];
                //}

                //frmMsg = new frmMessageBox();
                //frmMsg.Show(retMsg, Application.ProductName, MessageBoxButtons.OK, 1, MPGV.gfrmMDI);

                //retMsg = null;
                //frmMsg.Owner = null;
                //frmMsg = null;

                sMsg = node.GetString(TRSDefine.OUT_MSG);
                if (node.GetList(TRSDefine.OUT_FIELDMSG).Count > 0)
                {
                    sMsg += "  " + node.GetList(TRSDefine.OUT_FIELDMSG)[0].GetMember(0).Name +
                              " = [" + node.GetList(TRSDefine.OUT_FIELDMSG)[0].GetMember(0).Value + "]";
                }

                ShowStatusMsg(lblStatus, 'E', sMsg);

                MPGV.gaWarningMsg.Clear();

                return false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("MPCR.CheckContinueProc()\n" + ex.Message);
                ShowStatusMsg(lblStatus, '2', "MPCR.CheckContinueProc()\n" + ex.Message);
                return false;
            }
        }

        #endregion

        #region " CheckValueNoMBox "

        public static bool CheckValueNoMBox(Control Form_control, int _Step, Label lblStatus)
        {
            return CheckValueNoMBox(Form_control, _Step, lblStatus, false, false, "", "", "");
        }

        public static bool CheckValueNoMBox(Control Form_control, int _Step, Label lblStatus, bool Not_Confirm_Flag, bool Not_Focus_Flag, string message, string Cond1, string Cond2)
        {
            bool b_valid_flag;
            b_valid_flag = false;

            if (MPCF.Trim(message) == "")
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
                    if (MPCF.Trim(Form_control.Text) != "")
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
                    if (MPCF.Trim(Form_control.Text) != "")
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
            else if (Form_control is SOICodeView)
            {
                if (_Step == 1)
                {
                    if (MPCF.Trim(((SOICodeView)Form_control).Text) != "")
                    {
                        b_valid_flag = true;
                    }
                }
                else if (_Step == 2)
                {
                    if (MPCF.CheckNumeric(((SOICodeView)Form_control).Text) == true)
                    {
                        b_valid_flag = true;
                    }
                }
                else if (_Step == 3)
                {
                    if (MPCF.CheckNumeric(((SOICodeView)Form_control).Text) == true)
                    {
                        if (((SOICodeView)Form_control).Text.IndexOf(".") < 0)
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
            //else if (Form_control is intCodeListControl)
            //{
            //    return ((intCodeListControl)Form_control).CheckValue();
            //}


            if (b_valid_flag == false)
            {
                if (Not_Confirm_Flag == false)
                {
                    ShowStatusMsg(lblStatus, 'E', message);

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

        public static bool CheckValueNoMBox(Control Form_control, int _Step, SOI.Solar.Controls.udcScrollingTextCtrl lblStatus, string Cond1)
        {
            return CheckValueNoMBox(Form_control, _Step, lblStatus, false, false, "", Cond1, "", false);
        }

        public static bool CheckValueNoMBox(Control Form_control, int _Step, SOI.Solar.Controls.udcScrollingTextCtrl lblStatus, string Cond1, bool bShowMsgBox)
        {
            return CheckValueNoMBox(Form_control, _Step, lblStatus, false, false, "", Cond1, "", bShowMsgBox);
        }

        public static bool CheckValueNoMBox(Control Form_control, int _Step, SOI.Solar.Controls.udcScrollingTextCtrl lblStatus, bool Not_Confirm_Flag, bool Not_Focus_Flag, string message, string Cond1, string Cond2, bool bShowMsgBox)
        {
            bool b_valid_flag;
            b_valid_flag = false;

            if (MPCF.Trim(message) == "")
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

            if ((Form_control is System.Windows.Forms.TextBox) || (Form_control is System.Windows.Forms.Label) ||
                (Form_control is Infragistics.Win.UltraWinEditors.UltraTextEditor))
            {
                if (_Step == 1)
                {
                    if (MPCF.Trim(Form_control.Text) != "")
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
                    if (MPCF.Trim(Form_control.Text) != "")
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
            else if (Form_control is SOICodeView)
            {
                if (_Step == 1)
                {
                    if (MPCF.Trim(((SOICodeView)Form_control).Text) != "")
                    {
                        b_valid_flag = true;
                    }
                }
                else if (_Step == 2)
                {
                    if (MPCF.CheckNumeric(((SOICodeView)Form_control).Text) == true)
                    {
                        b_valid_flag = true;
                    }
                }
                else if (_Step == 3)
                {
                    if (MPCF.CheckNumeric(((SOICodeView)Form_control).Text) == true)
                    {
                        if (((SOICodeView)Form_control).Text.IndexOf(".") < 0)
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
            //else if (Form_control is intCodeListControl)
            //{
            //    return ((intCodeListControl)Form_control).CheckValue();
            //}

            if (MPCF.Trim(Cond1) != "")
            {
                message += Cond1;
            }

            if (b_valid_flag == false)
            {
                if (Not_Confirm_Flag == false)
                {
                    ShowStatusMsg(lblStatus, 'E', message, bShowMsgBox);

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

        #region " MakeDateFormatMB "

        //
        // MakeDateFormatMB()
        //        - 일반 문자열을 Time Format으로 변환
        // Return Value
        //       - String : Return Get Time Format
        // Arguments
        //       - ByVal Fmt As FORMAT : Format (STANDARD, SYSTEM_FORMAT)
        //       - Optional ByVal DateTimeFormat As DATE_TIME_FORMAT : Time format ("YYYYMMDDHHMMSS", "YYYYMMDD", "HHMMSS")
        //
        public static string MakeDateFormatMB(string S)
        {
            return MakeDateFormatMB(S, DATE_TIME_FORMAT.NONE);
        }
        public static string MakeDateFormatMB(string S, DATE_TIME_FORMAT DateTimeFormat)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            string sReturn = "";
            DateTime dt;

            try
            {
                if (string.IsNullOrEmpty(S) == true) return "";

                S = MPCF.Trim(S);
                if (S == "") return "";

                //if (DateTimeFormat == DATE_TIME_FORMAT.NONE)
                //{
                //    DateTimeFormat = MPGV.geDateTimeFormat;
                //}

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

                                sReturn = S.Substring(2, 2) + MPGV.gsDateDelimiter + S.Substring(4, 2) + MPGV.gsDateDelimiter + S.Substring(6, 2) + " " + S.Substring(8, 2) + ":" + S.Substring(10, 2);
                                break;
                        }
                        break;

                    case LANG_FORMAT.SYSTEM:

                        dt = MPCF.ToDate(S);

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

                                sReturn = S.Substring(2, 2) + MPGV.gsDateDelimiter + S.Substring(4, 2) + MPGV.gsDateDelimiter + S.Substring(6, 2) + " " + S.Substring(8, 2) + ":" + S.Substring(10, 2);
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

        #endregion

        #region " Find_Index_on_Spread "

        public static int Find_Index_on_Spread(ref string Msg_Code, ref FarPoint.Win.Spread.FpSpread spdData, int iKeyCol1, string sKey1, bool bFirst)
        {
            return Find_Index_on_Spread(ref Msg_Code, ref spdData, iKeyCol1, sKey1, -1, "", -1, "", -1, "", -1, "", bFirst);
        }
        public static int Find_Index_on_Spread(ref string Msg_Code, ref FarPoint.Win.Spread.FpSpread spdData, int iKeyCol1, string sKey1, int iKeyCol2, string sKey2, bool bFirst)
        {
            return Find_Index_on_Spread(ref Msg_Code, ref spdData, iKeyCol1, sKey1, iKeyCol2, sKey2, -1, "", -1, "", -1, "", bFirst);
        }
        public static int Find_Index_on_Spread(ref string Msg_Code, ref FarPoint.Win.Spread.FpSpread spdData, int iKeyCol1, string sKey1, int iKeyCol2, string sKey2, int iKeyCol3, string sKey3, bool bFirst)
        {
            return Find_Index_on_Spread(ref Msg_Code, ref spdData, iKeyCol1, sKey1, iKeyCol2, sKey2, iKeyCol3, sKey3, -1, "", -1, "", bFirst);
        }
        public static int Find_Index_on_Spread(ref string Msg_Code, ref FarPoint.Win.Spread.FpSpread spdData, int iKeyCol1, string sKey1, int iKeyCol2, string sKey2, int iKeyCol3, string sKey3, int iKeyCol4, string sKey4, bool bFirst)
        {
            return Find_Index_on_Spread(ref Msg_Code, ref spdData, iKeyCol1, sKey1, iKeyCol2, sKey2, iKeyCol3, sKey3, iKeyCol4, sKey4, -1, "", bFirst);
        }
        public static int Find_Index_on_Spread(ref string Msg_Code, ref FarPoint.Win.Spread.FpSpread spdData,
                                                  int iKeyCol1, string sKey1, int iKeyCol2, string sKey2, int iKeyCol3, string sKey3,
                                                  int iKeyCol4, string sKey4, int iKeyCol5, string sKey5, bool bFirst)
        {
            int i;

            try
            {
                if (bFirst)
                {
                    for (i = 0; i < spdData.Sheets[0].RowCount; i++)
                    {
                        if (MPCF.Trim(Convert.ToString(spdData.Sheets[0].Cells[i, iKeyCol1].Value)) == sKey1.Trim())
                        {
                            if (iKeyCol2 == -1)
                                return i;
                            else if (MPCF.Trim(Convert.ToString(spdData.Sheets[0].Cells[i, iKeyCol2].Value)) == sKey2.Trim())
                            {
                                if (iKeyCol3 == -1)
                                    return i;
                                else if (MPCF.Trim(Convert.ToString(spdData.Sheets[0].Cells[i, iKeyCol3].Value)) == sKey3.Trim())
                                {
                                    if (iKeyCol4 == -1)
                                        return i;
                                    else if (MPCF.Trim(Convert.ToString(spdData.Sheets[0].Cells[i, iKeyCol4].Value)) == sKey4.Trim())
                                    {
                                        if (iKeyCol5 == -1)
                                            return i;
                                        else if (MPCF.Trim(Convert.ToString(spdData.Sheets[0].Cells[i, iKeyCol5].Value)) == sKey5.Trim())
                                        {
                                            return i;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (i = spdData.Sheets[0].RowCount - 1; i >= 0; i--)
                    {
                        if (MPCF.Trim(Convert.ToString(spdData.Sheets[0].Cells[i, iKeyCol1].Value)) == sKey1.Trim())
                        {
                            if (iKeyCol2 == -1)
                                return i;
                            else if (MPCF.Trim(Convert.ToString(spdData.Sheets[0].Cells[i, iKeyCol2].Value)) == sKey2.Trim())
                            {
                                if (iKeyCol3 == -1)
                                    return i;
                                else if (MPCF.Trim(Convert.ToString(spdData.Sheets[0].Cells[i, iKeyCol3].Value)) == sKey3.Trim())
                                {
                                    if (iKeyCol4 == -1)
                                        return i;
                                    else if (MPCF.Trim(Convert.ToString(spdData.Sheets[0].Cells[i, iKeyCol4].Value)) == sKey4.Trim())
                                    {
                                        if (iKeyCol5 == -1)
                                            return i;
                                        else if (MPCF.Trim(Convert.ToString(spdData.Sheets[0].Cells[i, iKeyCol5].Value)) == sKey5.Trim())
                                        {
                                            return i;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


                return -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region " Find_Index_in_DataTable "

        public static int Find_Index_in_DataTable(ref string Msg_Code, ref DataTable dt, int iKeyCol1, string sKey1)
        {
            return Find_Index_in_DataTable(ref Msg_Code, ref dt, iKeyCol1, sKey1, -1, "", -1, "", -1, "", -1, "");
        }
        public static int Find_Index_in_DataTable(ref string Msg_Code, ref DataTable dt, int iKeyCol1, string sKey1, int iKeyCol2, string sKey2)
        {
            return Find_Index_in_DataTable(ref Msg_Code, ref dt, iKeyCol1, sKey1, iKeyCol2, sKey2, -1, "", -1, "", -1, "");
        }
        public static int Find_Index_in_DataTable(ref string Msg_Code, ref DataTable dt, int iKeyCol1, string sKey1, int iKeyCol2, string sKey2, int iKeyCol3, string sKey3)
        {
            return Find_Index_in_DataTable(ref Msg_Code, ref dt, iKeyCol1, sKey1, iKeyCol2, sKey2, iKeyCol3, sKey3, -1, "", -1, "");
        }
        public static int Find_Index_in_DataTable(ref string Msg_Code, ref DataTable dt, int iKeyCol1, string sKey1, int iKeyCol2, string sKey2, int iKeyCol3, string sKey3, int iKeyCol4, string sKey4)
        {
            return Find_Index_in_DataTable(ref Msg_Code, ref dt, iKeyCol1, sKey1, iKeyCol2, sKey2, iKeyCol3, sKey3, iKeyCol4, sKey4, -1, "");
        }
        public static int Find_Index_in_DataTable(ref string Msg_Code, ref DataTable dt,
                                                  int iKeyCol1, string sKey1, int iKeyCol2, string sKey2, int iKeyCol3, string sKey3,
                                                  int iKeyCol4, string sKey4, int iKeyCol5, string sKey5)
        {
            int i;

            try
            {
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][iKeyCol1].ToString().Trim() == sKey1.Trim())
                    {
                        if (iKeyCol2 == -1)
                            return i;
                        else if (dt.Rows[i][iKeyCol2].ToString().Trim() == sKey2.Trim())
                        {
                            if (iKeyCol3 == -1)
                                return i;
                            else if (dt.Rows[i][iKeyCol3].ToString().Trim() == sKey3.Trim())
                            {
                                if (iKeyCol4 == -1)
                                    return i;
                                else if (dt.Rows[i][iKeyCol4].ToString().Trim() == sKey4.Trim())
                                {
                                    if (iKeyCol5 == -1)
                                        return i;
                                    else if (dt.Rows[i][iKeyCol5].ToString().Trim() == sKey5.Trim())
                                    {
                                        return i;
                                    }
                                }
                            }
                        }
                    }
                }

                return -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region " CountNumOfStr "

        public static int CountNumOfStr(string sData, string sKeyStr)
        {
            int iCount = 0;
            int iCurIdx = -1;

            try
            {
                while ((iCurIdx = sData.IndexOf(sKeyStr, iCurIdx + 1)) >= 0)
                {
                    iCount++;
                }

                return iCount;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return -1;
            }
        }

        #endregion

        #region " GetIPAddress "

        public static string GetIPAddress()
        {
            IPHostEntry host;
            string localIP = "";

            //if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == false)
            //{
            //    return "ERROR : NO NETWORK CONNECTION";
            //}

            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (IPAddress.IsLoopback(ip) == false && ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    return localIP;
                }
            }
            return localIP;

            //int i;
            //IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            //IPAddress[] addr = ipEntry.AddressList;

            //for (i = 0; i < addr.Length; i++)
            //{
            //    if (addr[i].ToString() != "" && addr[i].ToString().Length == 15) break;

            //}
            //return addr[i].ToString();
        }


        #endregion

        #region " CopySheet "

        public static FarPoint.Win.Spread.SheetView CopySheet(FarPoint.Win.Spread.SheetView sheet)
        {
            FarPoint.Win.Spread.SheetView newSheet = null;
            if (sheet != null)
            {
                newSheet = (FarPoint.Win.Spread.SheetView)FarPoint.Win.Serializer.LoadObjectXml(sheet.GetType(), FarPoint.Win.Serializer.GetObjectXml(sheet, "CopySheet"), "CopySheet");
            }
            return newSheet;
        }

        #endregion

        #region " ProcPrint "

        //
        // ProcPrint()
        //       - View General Code Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        //public static bool ProcPrint(string sPort, string sLabelCode, ref string[] sRepStr, ref string sRepLabelCode)
        //{          
        //    try
        //    {
        //        if (CSCR.ReplaceLabelData('3', sLabelCode, ref sRepLabelCode, sRepStr) == false)
        //            return false;

        //        // Print Label                                
        //        //if (SendPrintCmd(sPort, sRepLabelCode) == false)
        //        //{
        //        //    MPCF.ShowMsgBox(MPCF.GetMessage(400));
        //        //    return false;
        //        //}

        //        return true;

        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMsgBox(ex.Message);
        //        return false;
        //    }
        //}

        //
        // ProcPrint()
        //       - View General Code Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public static bool ProcPrint(string sPort, ref TRSNode in_node, string sUsbPrinter, ref string sRepLabelCode, bool bPrint)
        {
            return ProcPrint(sPort, ref in_node, sUsbPrinter, ref sRepLabelCode, bPrint, 1);
        }
        public static bool ProcPrint(string sPort, ref TRSNode in_node, string sUsbPrinter, ref string sRepLabelCode, bool bPrint, int iPrintQty)
        {
            int i;

            try
            {
                if (CSCR.ReplaceLabelData(ref in_node, ref sRepLabelCode) == false)
                    return false;

                // Print Label
                if (bPrint == true)
                {
                    for (i = 0; i < iPrintQty; i++)
                    {
                        if (SendPrintCmd(sPort, sRepLabelCode, sUsbPrinter) == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(421));
                            return false;
                        }
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


        #endregion

        #region " SendPrintCmd "

        public static bool SendPrintCmd(string sPrintType, string sLabelCmd, string sUsbPrinter)
        {
            Rs232 m_CommPort = new Rs232();

            try
            {
                //if (modPOPPrint.ExcutePrintCommand(sPrintType, m_CommPort, sLabelCmd, false, "", "", "", sUsbPrinter) == false)
                if (modPOPPrint.ExcutePrintCommand(sPrintType, m_CommPort, sLabelCmd, false, "", "", "") == false)
                {
                    return false;
                }

                return true;
            }
            catch (IOException IOEx)
            {
                MPCF.ShowMsgBox(IOEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        #region " GenCaptionText "

        public static string GenCaptionText(string sOrgText)
        {
            int j;
            int iTotal;
            string sTemp = string.Empty;
            string sTarget = string.Empty;

            bool bSpace;

            try
            {

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

                sTarget = FindLanguage(sTarget, CAPTION_TYPE.LABEL);

                return sTarget;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return sTarget;
            }
        }

        public static string FindLanguage(string S, CAPTION_TYPE captionType)
        {
            return clsLanguageFunction.FindLanguage(S, captionType);
        }

        #endregion

        #region " FitColumnHeaderExt "

        public static void FitColumnHeaderExt(object obj)
        {
            int[] iSkipCols = null;

            FitColumnHeaderExt(obj, -1, -1, -1, -1, false, ref iSkipCols);
        }
        /// <summary>
        ///  Control의 칼럼 헤더 사이즈를 내용에 맞게 조절한다.
        /// </summary>
        /// <param name="obj">List Control</param>
        public static void FitColumnHeaderExt(object obj, ref int[] iSkipCols)
        {
            FitColumnHeaderExt(obj, -1, -1, -1, -1, false, ref iSkipCols);
        }
        /// <summary>
        ///  Control의 칼럼 헤더 사이즈를 내용에 맞게 조절한다.
        /// </summary>
        /// <param name="obj">List Control</param>
        public static void FitColumnHeaderExt(object obj, bool b_skip_fixed_size_header, ref int[] iSkipCols)
        {
            FitColumnHeaderExt(obj, -1, -1, -1, -1, b_skip_fixed_size_header, ref iSkipCols);
        }
        /// <summary>
        ///  Control의 칼럼 헤더 사이즈를 내용에 맞게 조절한다.
        /// </summary>
        /// <param name="obj">List Control</param>
        /// <param name="i_start_column_index">시작 컬럼</param>
        /// <param name="i_end_column_index">끝 컬럼</param>
        public static void FitColumnHeaderExt(object obj, int i_start_column_index, int i_end_column_index, ref int[] iSkipCols)
        {
            FitColumnHeaderExt(obj, i_start_column_index, i_end_column_index, -1, -1, false, ref iSkipCols);
        }
        /// <summary>
        ///  Control의 칼럼 헤더 사이즈를 내용에 맞게 조절한다.
        /// </summary>
        /// <param name="obj">List Control</param>
        /// <param name="i_start_column_index">시작 컬럼</param>
        /// <param name="i_end_column_index">끝 컬럼</param>
        public static void FitColumnHeaderExt(object obj, int i_start_column_index, int i_end_column_index, bool b_skip_fixed_size_header, ref int[] iSkipCols)
        {
            FitColumnHeaderExt(obj, i_start_column_index, i_end_column_index, -1, -1, b_skip_fixed_size_header, ref iSkipCols);
        }
        /// <summary>
        ///  Control의 칼럼 헤더 사이즈를 내용에 맞게 조절한다.
        /// </summary>
        /// <param name="obj">List Control</param>
        /// <param name="i_start_column_index">시작 컬럼</param>
        /// <param name="i_end_column_index">끝 컬럼</param>
        /// <param name="i_word_warp_col">Word Wrap을 사용할 컬럼 인덱스</param>
        /// <param name="i_word_wrap_max_size">Word Wrap을 사용할 컬럼의 최대 문자열 길이</param>
        public static void FitColumnHeaderExt(object obj, int i_start_column_index, int i_end_column_index, int i_word_wrap_col, int i_word_wrap_max_size,
                  bool b_skip_fixed_size_header, ref int[] iSkipCols)
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
                        if (IsSkipCol(i, ref iSkipCols) == true)
                            continue;

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
                else if (obj is FarPoint.Win.Spread.SheetView)
                {
                    FarPoint.Win.Spread.SheetView s_view = (FarPoint.Win.Spread.SheetView)obj;

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
                        if (IsSkipCol(i, ref iSkipCols) == true)
                            continue;

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
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }


        }

        private static bool IsSkipCol(int iCol, ref int[] iSkipCols)
        {
            int i;

            if (iSkipCols == null)
                return false;

            for (i = 0; i < iSkipCols.Length; i++)
            {
                if (iSkipCols[i] == iCol)
                    return true;
            }

            return false;
        }

        #endregion

        #region " CheckVendor "

        //
        // CheckVendor()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step

        public static bool CheckVendor(FarPoint.Win.Spread.FpSpread spdList, int iRow, string sVendor, ref bool bValid, bool bIgnoreError)
        {
            FarPoint.Win.Spread.SheetView sheetX = spdList.ActiveSheet;

            try
            {
                if (MPCF.Trim(sVendor) == "")
                {
                    if (!bIgnoreError)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(428));
                    }
                    return false;
                }

                //if ((MPCF.Trim(sheetX.Cells[iRow, (int)CSGC.INV_SET.MAKER_1].Text) == "") &&
                //    (MPCF.Trim(sheetX.Cells[iRow, (int)CSGC.INV_SET.MAKER_2].Text) == "") &&
                //    (MPCF.Trim(sheetX.Cells[iRow, (int)CSGC.INV_SET.MAKER_3].Text) == "") &&
                //    (MPCF.Trim(sheetX.Cells[iRow, (int)CSGC.INV_SET.MAKER_4].Text) == ""))
                //{
                //    return true;
                //}

                bValid = false;

                //if (MPCF.Trim(sheetX.Cells[iRow, (int)CSGC.INV_SET.MAKER_1].Text).Equals(sVendor) == true)
                //{
                //    bValid = true;
                //}

                //if (bValid == false)
                //{
                //    if (MPCF.Trim(sheetX.Cells[iRow, (int)CSGC.INV_SET.MAKER_2].Text).Equals(sVendor) == true)
                //        bValid = true;
                //}

                //if (bValid == false)
                //{
                //    if (MPCF.Trim(sheetX.Cells[iRow, (int)CSGC.INV_SET.MAKER_3].Text).Equals(sVendor) == true)
                //        bValid = true;
                //}

                //if (bValid == false)
                //{
                //    if (MPCF.Trim(sheetX.Cells[iRow, (int)CSGC.INV_SET.MAKER_4].Text).Equals(sVendor) == true)
                //        bValid = true;
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        #endregion

        #region " AddSpreadSort "
        //-----------------------------------------------------------------------------
        //
        // AddSpreadSort()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        //-----------------------------------------------------------------------------
        public static bool AddSpreadSort(FarPoint.Win.Spread.FpSpread spdData)
        {
            int i = 0;

            FarPoint.Win.Spread.SheetView sheetX = null;

            try
            {
                sheetX = spdData.ActiveSheet;

                for (i = 0; i < sheetX.ColumnCount; i++)
                {
                    sheetX.Columns[i].AllowAutoSort = true;
                    //sheetX.Columns[i].SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
                    //sheetX.Columns[i].ShowSortIndicator = false;
                    //sheetX.SetColumnShowSortIndicator(i, false);
                    sheetX.Columns[i].Width += 15;
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

        #region " GenSeqString "

        //
        // GenSeqString()
        //       - View General Code Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public static bool GenSeqString(int iSeq, int iSeqSize, ref string sSeqConvStr)
        {
            int iSeqLen;
            int iFirst2;

            string sSeqString = string.Empty;

            try
            {
                sSeqString = iSeq.ToString();
                iSeqLen = sSeqString.Length;

                if (iSeqLen <= iSeqSize)
                {
                    sSeqConvStr = iSeq.ToString("D" + iSeqSize.ToString());
                }
                else
                {
                    iFirst2 = MPCF.ToInt(sSeqString.Substring(0, 2));

                    if (iFirst2 >= 18 && iFirst2 <= 22)
                        iFirst2 += 1;
                    else if (iFirst2 >= 23)
                        iFirst2 += 2;

                    sSeqConvStr = ((char)(55 + iFirst2)).ToString();

                    sSeqConvStr = sSeqConvStr + sSeqString.Substring(2);
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

        #region " GenSeqFromSeqString "

        //
        // GenSeqFromSeqString()
        //       - View General Code Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public static bool GenSeqFromSeqString(string sSeqStr, ref int iSeq)
        {
            int iTemp;

            string sSeqTemp = string.Empty;

            try
            {
                iSeq = -1;

                if (MPCF.CheckNumeric(sSeqStr) == true)
                {
                    iSeq = MPCF.ToInt(sSeqStr);
                }
                else
                {
                    if (sSeqStr[0] == 'I' || sSeqStr[0] == 'O')
                    {
                        return false;
                    }

                    iTemp = (int)sSeqStr[0] - 55;

                    if (iTemp >= 19 && iTemp <= 23)
                        iTemp -= 1;
                    else if (iTemp >= 25)
                        iTemp -= 2;

                    sSeqTemp = iTemp.ToString() + sSeqStr.Substring(1);

                    iSeq = MPCF.ToInt(sSeqTemp);
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

        public static bool GetGCMAttributData(TRSNode attr_node, string s_attr_type, string s_attr_key)
        {
            TRSNode in_node = new TRSNode("VIEW_ATTRIBUTE_VALUE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_ATTRIBUTE_VALUE_LIST_OUT");
            int i;
            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.SetString("FACTORY", "HTT1");
                in_node.SetString("ATTR_TYPE", s_attr_type);
                in_node.SetString("ATTR_KEY", s_attr_key);

                if (MPCF.CallService("BAS", "BAS_View_Attribute_Value", in_node, ref out_node, false) == false)
                {
                    return false;
                }
                for (i = 0; i < out_node.GetList("VALUE_LIST").Count; i++)
                {
                    attr_node.SetString(out_node.GetList("VALUE_LIST")[i].GetString("ATTR_NAME"), out_node.GetList("VALUE_LIST")[i].GetString("ATTR_VALUE"));
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }


        #region " Query setup Functions "

        public static bool viewQueryLog()
        {
            //frmQueryLogBase queryLog = new frmQueryLogBase();

            //UcQueryViewer viewer = new UcQueryViewer();
            //viewer.Dock = DockStyle.Fill;
            //queryLog.Controls.Add(viewer);
            ////viewer.Text = MPGV.gsQueryStatementLOG;
            //viewer.BringToFront();
            //queryLog.Show();

            return true;

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
            string[] tmp;

            //if (MPGV.gsQueryStatementLOGCount >= 30)
            //{
            //    str[0] = "------------------------------------------------------------------------------------------------------";
            //    tmp = MPGV.gsQueryStatementLOG.Split(str, StringSplitOptions.None);

            //    MPGV.gsQueryStatementLOG = "";
            //    for (int i = 2; i < tmp.Length; i++)
            //    {
            //        MPGV.gsQueryStatementLOG += "------------------------------------------------------------------------------------------------------" + tmp[i];
            //    }

            //    MPGV.gsQueryStatementLOG = MPGV.gsQueryStatementLOG + GetSeparatorString(sql_id) + sb.ToString() + "\n\n\n"; // 다중 Query문 저장
            //    MPGV.gsQueryStatementLOGCount = 30;
            //}
            //else
            //{
            //    MPGV.gsQueryStatementLOG = MPGV.gsQueryStatementLOG + GetSeparatorString(sql_id) + sb.ToString() + "\n\n\n"; // 다중 Query문 저장
            //    MPGV.gsQueryStatementLOGCount++;
            //}

            return sb.ToString();

        }

        public static string GetSeparatorString(string queryID)
        {
            string results = Environment.NewLine + Environment.NewLine
                + "------------------------------------------------------------------------------------------------------\r\n";

            if (!String.IsNullOrEmpty(queryID))
            {
                results += String.Format("/* {0} */\r\n", queryID);
                results += "----------------------------------------------------------------------------------------------------";
            }

            return results + Environment.NewLine + Environment.NewLine;
        }

        public static string GetQueryString(string sQueryID)
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DATA_LIST_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("SQL_ID", sQueryID);

                if (MPCF.CallService("CUS", "CBAS_View_Sql", in_node, ref out_node) == false)
                {
                    return "";
                }

                byte[] buffer;
                buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_1);

                string sqlquery = Encoding.Default.GetString(buffer);
                return sqlquery;
            }
            catch (Exception ee)
            {
                MPCF.ShowMsgBox(ee.Message);
                return "";
            }
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
                //System.Windows.Forms.Control f = (System.Windows.Forms.Control)oCondition;

                //foreach (Control ctrl in f.Controls)
                //{

                //    if (ctrl is Panel || ctrl is GroupBox || ctrl is TabControl || ctrl is TabPage || ctrl is SplitContainer || ctrl is SplitterPanel)
                //    {
                //        ReplaceCondtionToString(ctrl, ref sQueryStatement);
                //    }
                //    else
                //    {
                //        s_CondValue = string.Empty;

                //        s_CondName = ctrl.Name;
                //        s_CondName = "$" + s_CondName.ToLower();

                //        if (ctrl is Miracom.MESCore.Controls.udcFromToDate)
                //        {
                //            // 순서 변경 금지...
                //            s_CondName = "$fromtime";
                //            s_CondValue = PackConditionString(((Miracom.MESCore.Controls.udcFromToDate)ctrl).FromDateTime);
                //            sQueryStatement = sQueryStatement.Replace(s_CondName, s_CondValue);

                //            s_CondName = "$totime";
                //            s_CondValue = PackConditionString(((Miracom.MESCore.Controls.udcFromToDate)ctrl).ToDateTime);
                //            sQueryStatement = sQueryStatement.Replace(s_CondName, s_CondValue);

                //            s_CondName = "$fromdate";
                //            s_CondValue = PackConditionString(((Miracom.MESCore.Controls.udcFromToDate)ctrl).FromDate);
                //            sQueryStatement = sQueryStatement.Replace(s_CondName, s_CondValue);

                //            s_CondName = "$todate";
                //            s_CondValue = PackConditionString(((Miracom.MESCore.Controls.udcFromToDate)ctrl).ToDate);
                //            sQueryStatement = sQueryStatement.Replace(s_CondName, s_CondValue);
                //        }
                //        else
                //        {
                //            s_CondValue = PackConditionString(ctrl);
                //            sQueryStatement = sQueryStatement.Replace(s_CondName, s_CondValue);
                //        }
                //    }
                //}


                bRet = true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return bRet;
        }

        public static string PackConditionString(object ctrl)
        {
            object l_Control;

            string s_Ret = string.Empty;
            string s_CondValue = string.Empty;
            string s_CondDisplay = string.Empty;

            try
            {
                l_Control = ctrl;

                if (l_Control is TextBox)
                {
                    s_CondValue = ((System.Windows.Forms.TextBox)l_Control).Text.Trim();
                    s_Ret = PackConditionString(s_CondValue);
                }
                else if (l_Control is ComboBox)
                {
                    s_CondValue = ((System.Windows.Forms.ComboBox)l_Control).Text.Trim();
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

        public static TRSNode ConvertNodeToDataTable(DataTable _dt)
        {
            TRSNode out_node = new TRSNode("CONVERT");

            try
            {
                if (_dt == null) return null;

                for (int i = 0; i < _dt.Columns.Count; i++)
                {
                    out_node.SetString(MPCF.Trim(_dt.Columns[i].Caption), MPCF.Trim(_dt.Rows[0][i]));
                }

                return out_node;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region " CheckDuplication "

        public static bool CheckDuplication(ListView MyListView, string sItem)
        {
            int index = 0;

            if (MPCF.Trim(sItem) == "")
            {
                return false;
            }

            for (index = 0; index < MyListView.Items.Count; index++)
            {
                if (MPCF.Trim(MyListView.Items[index].Text) == MPCF.Trim(sItem))
                {
                    return true;
                }
            }

            return false;

        }


        #endregion

        #region " UploadFileViaFtp "

        #region " MES FTPClient "

        //public static bool UploadFileViaFtp(ListView lisAttachFiles,
        //                                    string sFileGroup, string sFileKey1, string sFileKey2, string sFileKey3,
        //                                    string sFtpAddress,
        //                                    int iFtpPort,
        //                                    string sUserID,
        //                                    string sPassword,
        //                                    string sFtpRootDir,
        //                                    string[] fileList)
        //{
        //    TRSNode in_node = new TRSNode("UPDATE_IN");
        //    TRSNode out_node = new TRSNode("CMN_OUT");

        //    FTPClient.FTPConnection mFTP = null;
        //    string sWorkDate = string.Empty;
        //    string sShift = string.Empty;

        //    string sFtpDir = string.Empty;
        //    string sFileName = string.Empty;

        //    ListViewItem itmx;

        //    int i;

        //    try
        //    {
        //        if (CSCR.GetWorkDate('1', ref sWorkDate, ref sShift) == false)
        //        {
        //            sWorkDate = DateTime.Now.ToString("yyyyMMdd");
        //        }

        //        if (sFtpRootDir.Substring(0, 1) != "/")
        //        {
        //            sFtpRootDir = "/" + sFtpRootDir;
        //        }

        //        sFtpDir = sFtpRootDir + "/" + sWorkDate;

        //        mFTP = new FTPClient.FTPConnection();
        //        mFTP.Open(sFtpAddress, iFtpPort, sUserID, sPassword, FTPClient.FTPMode.Passive);

        //        if (FTPMakeDirectory(mFTP, sFtpRootDir, sFtpDir) == false)
        //            return false;

        //        mFTP.ChangeDirectory(sFtpDir);

        //        MPCF.SetInMsg(in_node);
        //        in_node.ProcStep = '1';
        //        in_node.AddString("FILE_GROUP", sFileGroup);


        //        for (i = 0; i < fileList.Length; i++)
        //        {
        //            sFileName = fileList[i].Substring(fileList[i].LastIndexOf("\\") + 1);

        //            if (FileExists(mFTP, fileList[i]) == true)
        //            {
        //                continue;
        //            }

        //            mFTP.SendFile(fileList[i], FTPClient.FTPFileTransferType.Binary);

        //            in_node.SetString("FILE_KEY_1", sFileKey1);
        //            in_node.SetString("FILE_KEY_2", sFileKey2);
        //            in_node.SetString("FILE_KEY_3", sFileKey3);
        //            in_node.SetString("FILE_NAME", sFileName);
        //            in_node.SetString("LOCATION", sFtpDir);

        //            if (MPCF.CallService("CUS", "CUS_Update_Attached_File_Info", in_node, ref out_node) == false)
        //            {
        //                return false;
        //            }

        //            itmx = new ListViewItem(sFileName, (int)SMALLICON_INDEX.IDX_CODE_DATA);
        //            itmx.SubItems.Add(sFtpDir);
        //            lisAttachFiles.Items.Add(itmx);
        //        }

        //        mFTP.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMsgBox(ex.Message);
        //        mFTP.Close();
        //        return false;
        //    }

        //    return false;

        //}

        #endregion

        public static bool UploadFileViaFtp(ListView lisAttachFiles,
                                            string sFileGroup, string sFileKey1, string sFileKey2, string sFileKey3,
                                            string sFtpAddress,
                                            int iFtpPort,
                                            string sUserID,
                                            string sPassword,
                                            string sFtpRootDir,
                                            string[] fileList)
        {
            TRSNode in_node = new TRSNode("UPDATE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            FtpClient ftp = null;
            string sWorkDate = string.Empty;
            string sShift = string.Empty;

            string sFtpDir = string.Empty;
            string sFileName = string.Empty;

            ListViewItem itmx;

            int i;

            try
            {
                if (CSCR.GetWorkDate('1', ref sWorkDate, ref sShift) == false)
                {
                    sWorkDate = DateTime.Now.ToString("yyyyMMdd");
                }

                if (sFtpRootDir.Substring(0, 1) != "/")
                {
                    sFtpRootDir = "/" + sFtpRootDir;
                }

                sFtpDir = sFtpRootDir + "/" + sWorkDate;

                if (MPCF.Trim(sFileKey1) != "")
                    sFtpDir += "/" + sFileKey1;
                if (MPCF.Trim(sFileKey2) != "")
                    sFtpDir += "/" + sFileKey2;
                if (MPCF.Trim(sFileKey3) != "")
                    sFtpDir += "/" + sFileKey3;

                ftp = new FtpClient(sFtpAddress, sUserID, sPassword, 10, iFtpPort);
                ftp.RemotePath = sFtpRootDir;

                ftp.Login();

                if (FTPMakeDirectory(ftp, sFtpRootDir, sFtpDir) == false)
                    return false;

                ftp.ChangeDir(sFtpDir);

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FILE_GROUP", sFileGroup);


                for (i = 0; i < fileList.Length; i++)
                {
                    sFileName = fileList[i].Substring(fileList[i].LastIndexOf("\\") + 1);

                    if (ftp.FileExists(sFileName) == true)
                    {
                        continue;
                    }

                    ftp.Upload(fileList[i]);

                    in_node.SetString("FILE_KEY_1", sFileKey1);
                    in_node.SetString("FILE_KEY_2", sFileKey2);
                    in_node.SetString("FILE_KEY_3", sFileKey3);
                    in_node.SetString("FILE_NAME", sFileName);
                    in_node.SetString("LOCATION", sFtpDir);

                    if (MPCF.CallService("CUS", "CUS_Update_Attached_File_Info", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    itmx = new ListViewItem(sFileName, (int)SMALLICON_INDEX.IDX_CODE_DATA);
                    itmx.SubItems.Add(sFtpDir);
                    lisAttachFiles.Items.Add(itmx);
                }

                ftp.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                ftp.Close();
                return false;
            }

            return false;

        }

        #endregion

        #region " DownLoadFileViaFtp "

        public static bool DownLoadFileViaFtp(ListView lisAttachFiles,
                                            string sFtpAddress,
                                            int iFtpPort,
                                            string sUserID,
                                            string sPassword,
                                            string sFtpRootDir,
                                            string sDownDir)
        {
            FtpClient ftp = null;

            string sFtpDir = string.Empty;
            string sFileName = string.Empty;

            string sFTPPath = string.Empty;
            string sLocalPath = string.Empty;

            ListViewItem itmx;

            int i, k;

            try
            {
                if (sFtpRootDir.Substring(0, 1) != "/")
                {
                    sFtpRootDir = "/" + sFtpRootDir;
                }

                ftp = new FtpClient(sFtpAddress, sUserID, sPassword, 10, iFtpPort);
                ftp.RemotePath = sFtpRootDir;

                ftp.Login();

                k = 0;
                for (i = lisAttachFiles.Items.Count - 1; i >= 0; i--)
                {
                    if (lisAttachFiles.Items[i].Checked == true)
                    {
                        sFileName = MPCF.Trim(lisAttachFiles.Items[i].Text);
                        sFtpDir = MPCF.Trim(lisAttachFiles.Items[i].SubItems[1].Text);

                        sLocalPath = sDownDir + "\\" + sFileName;
                        sFTPPath = sFtpDir + "/" + sFileName;

                        ftp.Download(sFTPPath, sLocalPath);

                        k++;
                    }
                }

                ftp.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                ftp.Close();
                return false;
            }

            return true;

        }

        #endregion

        #region " DeleteFileOnFtp "

        public static bool DeleteFileOnFtp(ListView lisAttachFiles,
                                            string sFileGroup, string sFileKey1, string sFileKey2, string sFileKey3,
                                            string sFtpAddress,
                                            int iFtpPort,
                                            string sUserID,
                                            string sPassword,
                                            string sFtpRootDir)
        {
            TRSNode in_node = new TRSNode("UPDATE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            FtpClient ftp = null;
            string sWorkDate = string.Empty;
            string sShift = string.Empty;

            string sFtpDir = string.Empty;
            string sFileName = string.Empty;

            ListViewItem itmx;

            int i, k;

            try
            {
                if (sFtpRootDir.Substring(0, 1) != "/")
                {
                    sFtpRootDir = "/" + sFtpRootDir;
                }

                ftp = new FtpClient(sFtpAddress, sUserID, sPassword, 10, iFtpPort);
                ftp.RemotePath = sFtpRootDir;

                ftp.Login();

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("FILE_GROUP", sFileGroup);

                k = 0;
                for (i = lisAttachFiles.Items.Count - 1; i >= 0; i--)
                {
                    if (lisAttachFiles.Items[i].Checked == true)
                    {
                        sFileName = MPCF.Trim(lisAttachFiles.Items[i].Text);
                        sFtpDir = MPCF.Trim(lisAttachFiles.Items[i].SubItems[1].Text);

                        ftp.DeleteFile(sFtpDir + "/" + sFileName);

                        in_node.SetString("FILE_KEY_1", sFileKey1);
                        in_node.SetString("FILE_KEY_2", sFileKey2);
                        in_node.SetString("FILE_KEY_3", sFileKey3);
                        in_node.SetString("FILE_NAME", sFileName);

                        if (MPCF.CallService("CUS", "CUS_Update_Attached_File_Info", in_node, ref out_node) == false)
                        {
                            return false;
                        }

                        lisAttachFiles.Items[i].Remove();

                        k++;
                    }
                }

                ftp.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                ftp.Close();
                return false;
            }

            return false;

        }

        #endregion

        #region  " FileExists "

        //private static bool FileExists(FTPClient.FTPConnection mftp, string fileName)
        //{
        //    try
        //    {
        //        mftp.GetFileSize(fileName);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        #endregion

        #region " FTPMakeDirectory "

        #region " MES FTPClient "
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="command"></param>
        //private static bool FTPMakeDirectory(FTPClient.FTPConnection mftp, string sFtpRootDir, string sFtpDir)
        //{
        //    string[] split;
        //    string tmp = "";
        //    string path = "";

        //    try
        //    {
        //        if (sFtpDir.Substring(0, 1) != "/")
        //        {
        //            tmp = "/" + sFtpDir;
        //        }
        //        else
        //        {
        //            tmp = sFtpDir;
        //        }

        //        split = tmp.Split(new char[] { '/' });


        //        for (int i = 0; i < split.Length; i++)
        //        {
        //            if (i == 0)
        //            {
        //                path = "/";
        //                continue;
        //            }

        //            if (split[i].Trim() == "")
        //                continue;

        //            if (path == "/")
        //            {
        //                path = path + split[i];
        //            }
        //            else
        //            {
        //                path = path + "/" + split[i];
        //            }

        //            try
        //            {
        //                mftp.ChangeDirectory(path);
        //            }
        //            catch (Exception ex)
        //            {
        //                mftp.MakeDir(path);
        //            }
        //        }

        //        mftp.ChangeDirectory(sFtpRootDir);

        //    }
        //    catch (Exception ex)
        //    {
        //        //Cmn_Out.h_status_value = modGlobalConstant.MP_FAIL_STATUS;
        //        //Cmn_Out.h_msg = ex.Message;
        //        ////modGlobalVariable.gLog.AddLog("MakeDirectory.", ex.Message);
        //        return false;
        //    }
        //    return true;
        //}

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        private static bool FTPMakeDirectory(FtpClient ftp, string sFtpRootDir, string sFtpDir)
        {
            string[] split;
            string tmp = "";
            string path = "";

            try
            {
                if (sFtpDir.Substring(0, 1) != "/")
                {
                    tmp = "/" + sFtpDir;
                }
                else
                {
                    tmp = sFtpDir;
                }

                split = tmp.Split(new char[] { '/' });


                for (int i = 0; i < split.Length; i++)
                {
                    if (i == 0)
                    {
                        path = "/";
                        continue;
                    }

                    if (split[i].Trim() == "")
                        continue;

                    if (path == "/")
                    {
                        path = path + split[i];
                    }
                    else
                    {
                        path = path + "/" + split[i];
                    }

                    try
                    {
                        ftp.ChangeDir(path);
                    }
                    catch (Exception ex)
                    {
                        ftp.MakeDir(path);
                    }
                }

                ftp.ChangeDir(sFtpRootDir);

            }
            catch (Exception ex)
            {
                //Cmn_Out.h_status_value = modGlobalConstant.MP_FAIL_STATUS;
                //Cmn_Out.h_msg = ex.Message;
                ////modGlobalVariable.gLog.AddLog("MakeDirectory.", ex.Message);
                return false;
            }
            return true;
        }



        #endregion

        #region " InitNumberCell "

        // InitNumberCell()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1")
        //
        public static bool InitNumberCell(FarPoint.Win.Spread.FpSpread spdData, int i_col,
                                     int i_decm_places, bool b_fixed_point, bool b_show_separator)
        {
            FarPoint.Win.Spread.CellType.NumberCellType numCellType;

            try
            {
                numCellType = new FarPoint.Win.Spread.CellType.NumberCellType();
                numCellType.FixedPoint = b_fixed_point;
                numCellType.ShowSeparator = b_show_separator;
                numCellType.DecimalPlaces = i_decm_places;
                numCellType.MinimumValue = int.MinValue;
                numCellType.MaximumValue = int.MaxValue;

                spdData.Sheets[0].Columns[i_col].CellType = numCellType;

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        public static bool InitDateCell(FarPoint.Win.Spread.FpSpread spdData, int i_col, FarPoint.Win.Spread.CellType.DateTimeFormat dateTimeFormat)
        {
            FarPoint.Win.Spread.CellType.DateTimeCellType dateCellType;

            try
            {
                dateCellType = new FarPoint.Win.Spread.CellType.DateTimeCellType();

                if (dateTimeFormat == FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDate)
                {
                    dateCellType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;

                    if (MPGV.geLanguageFormat.Equals(LANG_FORMAT.STANDARD) == true)
                    {
                        dateCellType.UserDefinedFormat = "yyyy-MM-dd";
                    }
                    else
                    {
                        dateCellType.UserDefinedFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    }
                }
                else if (dateTimeFormat == FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime)
                {
                    // dt.ToString(ci.DateTimeFormat.ShortDatePattern) + " " + dt.ToString(ci.DateTimeFormat.LongTimePattern);
                    dateCellType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;

                    if (MPGV.geLanguageFormat.Equals(LANG_FORMAT.STANDARD) == true)
                    {
                        dateCellType.UserDefinedFormat = "yyyy-MM-dd HH:mm:ss";
                    }
                    else
                    {
                        dateCellType.UserDefinedFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + " " + CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern;
                    }
                }
                else if (dateTimeFormat == FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined)
                {
                    dateCellType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
                    dateCellType.UserDefinedFormat = "yyyy-MM-dd HH:mm:ss";
                }
                else
                {
                    dateCellType.DateTimeFormat = dateTimeFormat;
                }

                spdData.Sheets[0].Columns[i_col].CellType = dateCellType;

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        public static bool GetGlobalOption(string s_option_name, ref string s_value)
        {
            string sValue2 = string.Empty;
            string sValue3 = string.Empty;
            string sValue4 = string.Empty;
            string sValue5 = string.Empty;

            return GetGlobalOption(s_option_name, ref s_value, ref sValue2, ref sValue3, ref sValue4, ref sValue5, "");
        }

        public static bool GetGlobalOption(string s_option_name, ref string s_value, string Ext_Factory)
        {
            string sValue2 = string.Empty;
            string sValue3 = string.Empty;
            string sValue4 = string.Empty;
            string sValue5 = string.Empty;

            return GetGlobalOption(s_option_name, ref s_value, ref sValue2, ref sValue3, ref sValue4, ref sValue5, Ext_Factory);
        }

        public static bool GetGlobalOption(string s_option_name,
                                            ref string s_value_1, ref string s_value_2, ref string s_value_3, ref string s_value_4, ref string s_value_5, string Ext_Factory)
        {
            TRSNode in_node = new TRSNode("VIEW_GLOBAL_OPTION_IN");
            TRSNode out_node = new TRSNode("VIEW_GLOBAL_OPTION_OUT");

            try
            {
                MPCF.SetInMsg(in_node);

                if (MPCF.Trim(Ext_Factory) != "")
                {
                    in_node.SetString("FACTORY", MPCF.Trim(Ext_Factory));
                }

                in_node.ProcStep = '1';
                in_node.AddString("OPTION_NAME", s_option_name);

                if (MPCF.CallService("BAS", "BAS_View_Global_Option", in_node, ref out_node, true) == false)
                {
                    return false;
                }

                s_value_1 = out_node.GetString("VALUE_1");
                s_value_2 = out_node.GetString("VALUE_2");
                s_value_3 = out_node.GetString("VALUE_3");
                s_value_4 = out_node.GetString("VALUE_4");
                s_value_5 = out_node.GetString("VALUE_5");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        public static bool DownloadFiles(char c_step, string s_file_name, string s_full_file_name, string s_file_type)
        {
            return DownloadFiles(c_step, s_file_name, s_full_file_name, ".xls", s_file_type);
        }

        public static bool DownloadFiles(char c_step, string s_file_name, string s_full_file_name, string s_format, string s_file_type)
        {
            TRSNode in_node = new TRSNode("VIEW_FILE_IN");
            TRSNode out_node = new TRSNode("VIEW_FILE_OUT");

            string sPathZip;
            string sCreateTime;

            long iFileSize;
            DateTime create_time;

            if (c_step == '2')
            {
                s_format = "";
                if (MPCF.Trim(s_file_name) == "not_found")
                    return true;
            }

            try
            {
                if (s_file_name == null || s_file_name == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(313));
                    return false;
                }

                FileInfo fi = new FileInfo(s_full_file_name);

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("FILE_TYPE", s_file_type);
                in_node.AddString("FILE_NAME", s_file_name);

                if (fi.Exists == false)
                {
                    in_node.AddString("CREATION_TIME", "19011231010000");
                    in_node.AddInt("FILE_SIZE", 0);
                    in_node.AddString("LOCATION", "..\\MESplusV5 EE\\MESClient");
                }
                else
                {
                    if (fi.CreationTime == null || fi.CreationTime.Year < 1900)
                    {
                        sCreateTime = "19011231010000";
                    }
                    else
                    {
                        create_time = fi.CreationTime;
                        sCreateTime = MPCF.ToStandardTime(create_time, MPGC.MP_CONVERT_DATETIME_FORMAT);
                    }

                    iFileSize = fi.Length;

                    in_node.AddString("CREATION_TIME", sCreateTime);
                    in_node.AddInt("FILE_SIZE", iFileSize);
                    in_node.AddString("LOCATION", Application.StartupPath);
                }


                if (MPCF.CallService("CUS", "CUS_View_File", in_node, ref out_node) == false)
                {
                    return false;
                }

                // b_upgraded = false;
                if (out_node.GetChar("NEED_UPDATE") == 'Y')
                {
                    UpdateFile(out_node, s_full_file_name);
                    // b_upgraded = true;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        public static bool UpdateFile(TRSNode out_node, string s_full_file_name)
        {
            try
            {
                FileStream fs = File.Open(s_full_file_name, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                byte[] buffer;
                DateTime dt_create_time;

                fs.Flush();
                buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_1);
                bw.Write(buffer);

                bw.Close();
                fs.Close();

                dt_create_time = MPCF.ToDate(out_node.GetString("CREATION_TIME"));
                File.SetCreationTime(s_full_file_name, dt_create_time);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #region "Spread Function "

        public static bool ColumnSet(FarPoint.Win.Spread.FpSpread fps, int header_row, int iColumn, string sLabel, int iWidth, bool bLocked, bool bVisible, FarPoint.Win.Spread.CellHorizontalAlignment align, Formatter format)
        {
            return ColumnSet(fps, header_row, iColumn, sLabel, iWidth, bLocked, bVisible, align, format, false);
        }

        public static bool ColumnSet(FarPoint.Win.Spread.FpSpread fps, int header_row, int iColumn, string sLabel, int iWidth, bool bLocked, bool bVisible, FarPoint.Win.Spread.CellHorizontalAlignment align, Formatter format, bool sorting)
        {
            if (sorting == false)
            {
                fps.Sheets[0].Columns[iColumn].Width = iWidth + 20;
            }
            else
            {
                fps.Sheets[0].Columns[iColumn].Width = iWidth;
            }

            //fps.Sheets[0].Columns[iColumn].Label = sLabel;
            fps.Sheets[0].Columns[iColumn].Locked = bLocked;
            fps.Sheets[0].Columns[iColumn].HorizontalAlignment = align;
            fps.Sheets[0].Columns[iColumn].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            fps.Sheets[0].Columns[iColumn].Visible = bVisible;
            //fps.Sheets[0].ColumnHeader.Columns[iColumn].ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(0)))), ((int)(((byte)(165)))));
            fps.Sheets[0].SetColumnAllowAutoSort(iColumn, fps.Sheets[0].ColumnCount, sorting);
            fps.Sheets[0].ColumnHeader.Rows[0].Height = 30;
            //Font myFonts = new Font("Tahoma", 8F, FontStyle.Regular);
            Font myFonts = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular);
            fps.Sheets[0].ColumnHeader.Columns[iColumn].Font = myFonts;

            Font myFonts2 = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular);
            //Font myFonts2 = new Font("Tahoma", 8F, FontStyle.Regular);
            fps.Sheets[0].DefaultStyle.Font = myFonts2;

            fps.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            fps.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;

            int rowPos = header_row;

            // row 사이즈가 현재 사이즈 보다 큰경우 row 사이즈 증가
            if (rowPos >= fps.ActiveSheet.ColumnHeader.Rows.Count)
                fps.ActiveSheet.ColumnHeader.Rows.Count = rowPos + 1;

            fps.ActiveSheet.ColumnHeader.Cells.Get(rowPos, iColumn).Text = sLabel;

            if (format == Formatter.String)
            {
                FarPoint.Win.Spread.CellType.TextCellType txt = new FarPoint.Win.Spread.CellType.TextCellType();
                fps.Sheets[0].Columns[iColumn].CellType = txt;
            }
            else if (format == Formatter.PlusNumber)
            {
                FarPoint.Win.Spread.CellType.NumberCellType num = new FarPoint.Win.Spread.CellType.NumberCellType();

                num = new FarPoint.Win.Spread.CellType.NumberCellType();
                num.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
                //num.DecimalPlaces = 0;
                num.DropDownButton = false;
                num.FixedPoint = false;
                //num.MaximumValue = double.MaxValue;
                // num.MinimumValue = 0;
                //num.LeadingZero = FarPoint.Win.Spread.CellType.LeadingZero.No;
                //num.Separator = ",";
                num.ShowSeparator = true;
                num.NegativeRed = true;

                fps.Sheets[0].Columns[iColumn].CellType = num;
            }
            else if (format == Formatter.Number)
            {
                FarPoint.Win.Spread.CellType.NumberCellType num = new FarPoint.Win.Spread.CellType.NumberCellType();

                num = new FarPoint.Win.Spread.CellType.NumberCellType();
                num.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
                //num.DecimalPlaces = 0;
                num.DropDownButton = false;
                num.FixedPoint = false;
                num.MaximumValue = 9999999999;
                num.MinimumValue = -9999999999;
                //num.MaximumValue = double.MaxValue;//9999999999;
                //num.MinimumValue = double.MinValue;//-9999999999;
                //num.LeadingZero = FarPoint.Win.Spread.CellType.LeadingZero.No;
                //num.Separator = ",";
                num.ShowSeparator = true;
                num.NegativeRed = true;

                fps.Sheets[0].Columns[iColumn].CellType = num;
            }
            else if (format == Formatter.ChkType)
            {
                FarPoint.Win.Spread.CellType.CheckBoxCellType chk = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                fps.Sheets[0].Columns[iColumn].CellType = chk;
            }
            else if (format == Formatter.Button)
            {
                FarPoint.Win.Spread.CellType.ButtonCellType btn = new FarPoint.Win.Spread.CellType.ButtonCellType();
                btn.Text = "...";
                fps.Sheets[0].Columns[iColumn].CellType = btn;
            }
            else if (format == Formatter.Double1)
            {
                FarPoint.Win.Spread.CellType.NumberCellType _double1 = new FarPoint.Win.Spread.CellType.NumberCellType();

                _double1 = new FarPoint.Win.Spread.CellType.NumberCellType();
                _double1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
                //_double1.DecimalPlaces = 1;
                _double1.DropDownButton = false;
                //_double1.MaximumValue = double.MaxValue;
                //_double1.MinimumValue = double.MinValue;
                _double1.FixedPoint = true;
                //_double1.Separator = ",";
                _double1.ShowSeparator = true;
                _double1.NegativeRed = true;

                fps.Sheets[0].Columns[iColumn].CellType = _double1;
            }
            else if (format == Formatter.Double2)
            {
                FarPoint.Win.Spread.CellType.NumberCellType _double2 = new FarPoint.Win.Spread.CellType.NumberCellType();

                _double2 = new FarPoint.Win.Spread.CellType.NumberCellType();
                _double2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
                //_double2.DecimalPlaces = 2;
                _double2.FixedPoint = true;
                _double2.DropDownButton = false;
                //_double2.MaximumValue = double.MaxValue;
                //_double2.MinimumValue =double.MinValue;
                //_double2.Separator = ",";
                _double2.ShowSeparator = true;
                _double2.NegativeRed = true;

                fps.Sheets[0].Columns[iColumn].CellType = _double2;
            }
            else if (format == Formatter.Double3)
            {
                FarPoint.Win.Spread.CellType.NumberCellType _double2 = new FarPoint.Win.Spread.CellType.NumberCellType();

                _double2 = new FarPoint.Win.Spread.CellType.NumberCellType();
                _double2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
                //_double2.DecimalPlaces = 3;
                _double2.DropDownButton = false;
                _double2.FixedPoint = true;
                //_double2.MaximumValue = double.MaxValue;
                //_double2.MinimumValue = double.MinValue;
                //_double2.Separator = ",";
                _double2.ShowSeparator = true;
                _double2.NegativeRed = true;

                fps.Sheets[0].Columns[iColumn].CellType = _double2;
            }
            else if (format == Formatter.PlusDouble3)
            {
                FarPoint.Win.Spread.CellType.NumberCellType _double2 = new FarPoint.Win.Spread.CellType.NumberCellType();

                _double2 = new FarPoint.Win.Spread.CellType.NumberCellType();
                _double2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
                //_double2.DecimalPlaces = 3;
                _double2.DropDownButton = false;
                _double2.FixedPoint = true;
                //_double2.MaximumValue = double.MaxValue;
                //_double2.MinimumValue = 0;
                //_double2.Separator = ",";
                _double2.ShowSeparator = true;
                _double2.NegativeRed = true;

                fps.Sheets[0].Columns[iColumn].CellType = _double2;
            }
            else if (format == Formatter.Image)
            {
                FarPoint.Win.Spread.CellType.ImageCellType imgCellTye = new FarPoint.Win.Spread.CellType.ImageCellType();
                fps.Sheets[0].Columns[iColumn].CellType = imgCellTye;
            }
            else if (format == Formatter.LongDateTime)
            {
                FarPoint.Win.Spread.CellType.DateTimeCellType dateType = new FarPoint.Win.Spread.CellType.DateTimeCellType();

                dateType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDateWithTime;

                fps.Sheets[0].Columns[iColumn].CellType = dateType;
            }
            else if (format == Formatter.ShortDateTime)
            {
                FarPoint.Win.Spread.CellType.DateTimeCellType dateType = new FarPoint.Win.Spread.CellType.DateTimeCellType();

                dateType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.ShortDate;

                fps.Sheets[0].Columns[iColumn].CellType = dateType;
            }

            return true;
        }

        public static bool Codeview_ButtonPress(SOICodeView cdvValue, string query_id, string[] agrs, int display_idx, bool insertEmptyRow)
        {
            return Codeview_ButtonPress(cdvValue, query_id, agrs, display_idx, (int)SMALLICON_INDEX.IDX_CODE_DATA, insertEmptyRow);
        }

        public static bool Codeview_ButtonPress(SOICodeView cdvValue, string query_id, string[] agrs, int display_idx)
        {
            return Codeview_ButtonPress(cdvValue, query_id, agrs, display_idx, (int)SMALLICON_INDEX.IDX_CODE_DATA, true);
        }

        public static bool Codeview_ButtonPress(SOICodeView cdvValue, string query_id, string[] agrs, int display_idx, int img_idx)
        {
            return Codeview_ButtonPress(cdvValue, query_id, agrs, display_idx, img_idx, true);
        }

        public static bool Codeview_ButtonPress(SOICodeView cdvValue, string query_id, string[] agrs, int display_idx, int img_idx, bool insertEmptyRow)
        {
            try
            {
                //ListViewItem itmX = null;
                //cdvValue.Init();
                //MPCF.InitListView(cdvValue.GetListView);

                //cdvValue.Columns.Add("CODE", 20, System.Windows.Forms.HorizontalAlignment.Left);
                //cdvValue.Columns.Add("DESC", 200, System.Windows.Forms.HorizontalAlignment.Left);
                //cdvValue.SelectedSubItemIndex = 0;
                //cdvValue.DisplaySubItemIndex = display_idx;
                //cdvValue.SelectedDescIndex = 1;

                //DataTable dt = CSCF.MGetData(query_id, agrs);

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    itmX = new ListViewItem(dt.Rows[i][0].ToString(), img_idx);
                //    itmX.SubItems.Add(dt.Rows[i][1].ToString());
                //    cdvValue.Items.Add(itmX);
                //}

                //if (insertEmptyRow == true)
                //{
                //    cdvValue.InsertEmptyRow(0, 1);
                //}

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        public static void SetBackColorColumn(FarPoint.Win.Spread.FpSpread fpSpd, int keys)
        {
            try
            {
                fpSpd.ActiveSheet.Columns[keys].BackColor = Color.LightGreen;
                return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }

        }

        /// <summary>
        /// 자동으로 Columns Width값 조정
        /// </summary>
        /// <param name="bIgnoreHeaders"></param>
        public void ColumnAutoFit(bool bIgnoreHeaders)
        {
            FarPoint.Win.Spread.CellType.TextCellType txtType = new FarPoint.Win.Spread.CellType.TextCellType();

            FarPoint.Win.Spread.FpSpread fps = new FarPoint.Win.Spread.FpSpread();

            fps.ActiveSheet.RowCount += 1;

            for (int i = 0; i < fps.ActiveSheet.Columns.Count; i++)
            {
                fps.ActiveSheet.Cells[fps.ActiveSheet.RowCount - 1, i].CellType = txtType;
                if (fps.ActiveSheet.ColumnHeader.Cells[fps.ActiveSheet.ColumnHeader.RowCount - 1, i].Text.Trim() != "")
                    fps.ActiveSheet.Cells[fps.ActiveSheet.RowCount - 1, i].Text = fps.ActiveSheet.ColumnHeader.Cells[fps.ActiveSheet.ColumnHeader.RowCount - 1, i].Text;
                else
                    fps.ActiveSheet.Cells[fps.ActiveSheet.RowCount - 1, i].Text = fps.ActiveSheet.ColumnHeader.Columns[i].Label;
                fps.ActiveSheet.Cells[fps.ActiveSheet.RowCount - 1, i].Font = new Font("Tahoma", 8F, FontStyle.Bold);
            }

            for (int i = 0; i < fps.ActiveSheet.Columns.Count; i++)
            {
                float width_max = fps.ActiveSheet.GetPreferredColumnWidth(i, bIgnoreHeaders);

                //if (this.ActiveSheet.ColumnHeader.Columns[i].Width < width_max)
                //{
                fps.ActiveSheet.Columns[i].Width = width_max + 15;
                //}
            }
            fps.ActiveSheet.Rows[fps.ActiveSheet.RowCount - 1].Remove();
        }

        /// <summary>
        /// 스프레드 엑셀로 출력
        /// </summary>
        /// <param name="bIgnoreHeaders"></param>
        /// 
        public static void exportToExcel(FarPoint.Win.Spread.FpSpread spdData)
        {
            exportToExcel(spdData, "");
        }

        /// <summary>
        /// 스프레드 엑셀로 출력
        /// </summary>
        /// <param name="bIgnoreHeaders"></param>
        /// 
        public static void exportToExcel(FarPoint.Win.Spread.FpSpread spdData, string fileName)
        {
            if (spdData.Sheets[0].Rows.Count == 0)
            {
                return;
            }

            SaveFileDialog mDlg = new SaveFileDialog();
            mDlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            mDlg.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            mDlg.FilterIndex = 1;
            mDlg.FileName = fileName;
            if (mDlg.ShowDialog() == DialogResult.OK)
            {
                spdData.Sheets[0].Protect = false;
                //if (spdData.SaveExcel(mDlg.FileName, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders) == true)
                //{

                //    MPCF.ShowMsgBox(MPCF.GetMessage(52));
                //}
                spdData.Sheets[0].Protect = true;
            }
        }


        /// <summary>
        /// Sheet 컬럼 마지막 row에 Sum한 수량 보여주기.
        /// </summary>
        /// <param name="spdData"></param>
        /// <param name="iQtyIndex"></param>
        public static void GetSum(FarPoint.Win.Spread.FpSpread spdData, List<int> iQtyIndex)
        {
            if (spdData.ActiveSheet.RowCount == 0)
                return;

            spdData.ActiveSheet.RowCount++;
            spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, 1].Value = "SUM";
            spdData.ActiveSheet.Rows[spdData.ActiveSheet.RowCount - 1].BackColor = System.Drawing.Color.FromArgb(196, 255, 190);
            spdData.ActiveSheet.Rows[spdData.ActiveSheet.RowCount - 1].Font = new Font("MS Sans Serif", 8, FontStyle.Bold);

            for (int i = 0; i < spdData.ActiveSheet.RowCount - 1; i++)
            {
                for (int j = 0; j < iQtyIndex.Count; j++)
                {
                    if (iQtyIndex[j] != 0)
                    {
                        spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, iQtyIndex[j]].Value =
                            (MPCF.ToDbl(spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, iQtyIndex[j]].Value) +
                            MPCF.ToDbl(spdData.ActiveSheet.Cells[i, iQtyIndex[j]].Value)).ToString();
                    }
                }
            }
        }

        public static void SetBackColorRow(FarPoint.Win.Spread.FpSpread fps, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            for (int i = 0; i < fps.ActiveSheet.RowCount; i++)
            {
                if (i == e.Row)
                    fps.ActiveSheet.Rows[i].BackColor = Color.LightSteelBlue;
                else if (i == 0 || i % 2 == 0)
                    fps.ActiveSheet.Rows[i].BackColor = Color.White;
                else
                    fps.ActiveSheet.Rows[i].BackColor = Color.WhiteSmoke;
            }
        }

        #endregion

        #region " InitLabelInfo "

        // InitLabelInfo()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1")
        //
        public static bool InitLabelInfo(char sStep, FarPoint.Win.Spread.FpSpread spdList)
        {
            int i, k;
            string sTag = string.Empty;

            try
            {
                for (i = 0; i < spdList.Sheets[0].RowCount; i++)
                {
                    for (k = 0; k < spdList.Sheets[0].ColumnCount; k++)
                    {
                        sTag = MPCF.Trim(spdList.Sheets[0].Cells[i, k].Tag);

                        if (sTag.StartsWith("$") == true)
                        {
                            spdList.Sheets[0].Cells[i, k].Text = sTag;
                        }
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

        #endregion

        #region " SetLabelNode "

        public static bool SetLabelNode(char cStep, string sOper,
                              ref TRSNode out_node, ref TRSNode label_node)
        {
            int i, k, iRow;

            bool bFirst = false;
            int i_oper_count;
            int i_route_cur_oper_idx;

            try
            {
                label_node = null;
                label_node = new TRSNode("LABEL_NODE");

                label_node.AddString("MAT_ID", out_node.GetString("MAT_ID"));
                label_node.AddString("MAT_SHORT_DESC", out_node.GetString("MAT_SHORT_DESC"));
                label_node.AddString("CUST_MAT_ID", out_node.GetString("MAT_SHORT_DESC"));

                label_node.AddString("MAT_DESC", out_node.GetString("MAT_DESC"));
                label_node.SetString("MAT_OLD_NEW_ID", out_node.GetString("MAT_SHORT_DESC") + " (" + out_node.GetString("MAT_ID") + ")");
                label_node.SetString("MAT_ID_W_CL", "(" + out_node.GetString("MAT_ID") + ")");

                label_node.SetString("RUB_MAT_ID", " ");
                label_node.SetString("RUB_CREATE_DATE", " ");

                label_node.SetString("R1_OPER", " ");
                label_node.SetString("R2_OPER", " ");
                label_node.SetString("R3_OPER", " ");
                label_node.SetString("R1_QTY", " ");
                label_node.SetString("R2_QTY", " ");
                label_node.SetString("R3_QTY", " ");
                label_node.SetString("R1_WORK_DATE", " ");
                label_node.SetString("R2_WORK_DATE", " ");
                label_node.SetString("R3_WORK_DATE", " ");
                label_node.SetString("R1_EXP_DATE", " ");
                label_node.SetString("R2_EXP_DATE", " ");
                label_node.SetString("R3_EXP_DATE", " ");
                label_node.SetString("R1_USER_DESC", " ");
                label_node.SetString("R2_USER_DESC", " ");
                label_node.SetString("R3_USER_DESC", " ");

                label_node.SetString("USE_FACTORY", " ");
                label_node.SetString("USE_FACTORY_DESC", " ");

                label_node.SetString("VENDOR_ID", " ");
                label_node.SetString("VENDOR_DESC", " ");
                label_node.SetString("QTY", " ");
                label_node.SetString("DLV_NOTE_ID", " ");
                label_node.SetString("EXP_DATE", " ");


                label_node.SetString("PALLET_DESC", " ");
                label_node.SetString("QTY", " ");
                label_node.SetString("USER_DESC", " ");
                label_node.SetString("CREATE_DATE", " ");

                if (MPCF.Trim(sOper) != "")
                {
                    bFirst = false;
                    i_oper_count = 0;
                    i_route_cur_oper_idx = -1;

                    for (i = 0; i < out_node.GetList("LIST_ITEM").Count; i++)
                    {
                        if (i_oper_count >= 3)
                            break;

                        if (sOper.Equals(MPCF.Trim(out_node.GetList("LIST_ITEM")[i].GetString("OPER"))) == true)
                        {
                            i_route_cur_oper_idx = i;
                            bFirst = true;
                        }

                        if (i_route_cur_oper_idx >= 0)
                        {
                            if (bFirst == true ||
                                out_node.GetList("LIST_ITEM")[i].GetString("CONTROL_KEY").Equals("YP01") == true)
                            {
                                i_oper_count++;

                                label_node.SetString("R" + i_oper_count.ToString() + "_OPER", out_node.GetList("LIST_ITEM")[i].GetString("OPER_DESC"));
                            }

                            bFirst = false;
                        }
                    }
                }
                else
                {
                    i_oper_count = 0;

                    for (i = 0; i < out_node.GetList("LIST_ITEM").Count; i++)
                    {
                        if (i_oper_count >= 3)
                            break;

                        if (i == 0)
                        {
                            bFirst = true;
                        }

                        if (bFirst == true ||
                             out_node.GetList("LIST_ITEM")[i].GetString("CONTROL_KEY").Equals("YP01") == true)
                        {
                            i_oper_count++;

                            label_node.SetString("R" + i_oper_count.ToString() + "_OPER", out_node.GetList("LIST_ITEM")[i].GetString("OPER_DESC"));
                            bFirst = false;
                        }
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

        #endregion

        #region " WGetData "
        //public static DataTable WGetData(string ViewID, string[] sArgu)
        //{
        //    string s_column = "";
        //    DataTable dt = null;
        //    int i = 0;

        //    try
        //    {
        //        int i_sArgCnt = 0;

        //        if (sArgu != null)
        //        {

        //            i_sArgCnt = sArgu.ToList().Count();
        //        }

        //        TPDR.DirectViewCond[] Cond = new TPDR.DirectViewCond[i_sArgCnt + 1];

        //        for (i = 0; i < i_sArgCnt; i++)
        //        {
        //            Cond[i].sCondtion_ID = "$" + (i + 1).ToString();
        //            Cond[i].sCondition_Value = sArgu[i];
        //        }

        //        Cond[i].sCondtion_ID = "$FACTORY";
        //        Cond[i].sCondition_Value = MPGV.gsFactory;


        //        //Get Data from server. 
        //        //Currently no meanning for sql. it work with 'View ID'
        //        if (TPDR.GetDataOne(s_column, ref dt, ViewID, Cond, false, false, true) == false)
        //        {
        //            return dt;
        //        }

        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMsgBox(ex.Message);
        //        dt = null;
        //        return dt;
        //    }

        //}

        //public static DataTable WGetData2(string ViewID, TPDR.DirectViewCond[] sArgu)
        //{
        //    string s_column = "";
        //    DataTable dt = null;
        //    int i = 0;

        //    try
        //    {
        //        int i_sArgCnt = 0;

        //        if (sArgu != null)
        //        {
        //            i_sArgCnt = sArgu.ToList().Count();
        //        }

        //        //TPDR.DirectViewCond[] Cond = new TPDR.DirectViewCond[i_sArgCnt + 1];

        //        //for (i = 0; i < i_sArgCnt; i++)
        //        //{
        //        //    Cond[i].sCondtion_ID = "$" + (i + 1).ToString();
        //        //    Cond[i].sCondition_Value = sArgu[i];
        //        //}

        //        //Cond[i].sCondtion_ID = "$FACTORY";
        //        //Cond[i].sCondition_Value = MPGV.gsFactory;


        //        //Get Data from server. 
        //        //Currently no meanning for sql. it work with 'View ID'
        //        if (TPDR.GetDataOne(s_column, ref dt, ViewID, sArgu, false, false, true) == false)
        //        {
        //            return dt;
        //        }

        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMsgBox(ex.Message);
        //        dt = null;
        //        return dt;
        //    }

        //}

        //public static bool Codeview_W_ButtonPress_AddColums(SOICodeView cdvValue, string query_id, string[] agrs, int display_idx, int columCnt)
        //{
        //    return Codeview_W_ButtonPress(cdvValue, query_id, agrs, display_idx, (int)SMALLICON_INDEX.IDX_CODE_DATA, true, columCnt);
        //}

        //public static bool Codeview_W_ButtonPress(SOICodeView cdvValue, string query_id, string[] agrs, int display_idx, bool insertEmptyRow)
        //{
        //    return Codeview_W_ButtonPress(cdvValue, query_id, agrs, display_idx, (int)SMALLICON_INDEX.IDX_CODE_DATA, insertEmptyRow, 2);
        //}

        //public static bool Codeview_W_ButtonPress(SOICodeView cdvValue, string query_id, string[] agrs, int display_idx)
        //{
        //    return Codeview_W_ButtonPress(cdvValue, query_id, agrs, display_idx, (int)SMALLICON_INDEX.IDX_CODE_DATA, true, 2);
        //}

        //public static bool Codeview_W_ButtonPress(SOICodeView cdvValue, string query_id, string[] agrs, int display_idx, int img_idx)
        //{
        //    return Codeview_W_ButtonPress(cdvValue, query_id, agrs, display_idx, img_idx, true, 2);
        //}

        //public static bool Codeview_W_ButtonPress(SOICodeView cdvValue, string query_id, string[] agrs, int display_idx, int img_idx, bool insertEmptyRow, int columCnt)
        //{
        //    try
        //    {
        //        ListViewItem itmX = null;
        //        cdvValue.Init();
        //        MPCF.InitListView(cdvValue.GetListView);

        //        cdvValue.Columns.Add("CODE", 20, System.Windows.Forms.HorizontalAlignment.Left);
        //        cdvValue.Columns.Add("DESC", 200, System.Windows.Forms.HorizontalAlignment.Left);
        //        if (columCnt > 2)
        //        {
        //            for (int i = 2; i < columCnt; i++)
        //            {
        //                cdvValue.Columns.Add("DESC_" + i, 50, System.Windows.Forms.HorizontalAlignment.Left);
        //            }
        //        }
        //        cdvValue.SelectedSubItemIndex = 0;
        //        cdvValue.DisplaySubItemIndex = display_idx;
        //        cdvValue.SelectedDescIndex = 1;

        //        DataTable dt = CSCF.WGetData(query_id, agrs);

        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {

        //            if (MPCF.Trim(dt.Columns[0].ColumnName) == "CODE" || MPCF.Trim(dt.Columns[0].ColumnName) == "CODE_DESC")
        //            {
        //                itmX = new ListViewItem(dt.Rows[i]["CODE"].ToString(), img_idx);
        //                itmX.SubItems.Add(dt.Rows[i]["CODE_DESC"].ToString());
        //                if (dt.Columns.Count > 2)
        //                {
        //                    for (int j = 2; j < dt.Columns.Count; j++)
        //                    {
        //                        itmX.SubItems.Add(dt.Rows[i]["CODE_DESC_" + (j - 1)].ToString());
        //                    }
        //                }
        //                cdvValue.Items.Add(itmX);
        //            }
        //            else
        //            {
        //                itmX = new ListViewItem(dt.Rows[i][0].ToString(), img_idx);
        //                itmX.SubItems.Add(dt.Rows[i][1].ToString());
        //                if (dt.Columns.Count > 2)
        //                {
        //                    for (int j = 2; j < dt.Columns.Count; j++)
        //                    {
        //                        itmX.SubItems.Add(dt.Rows[i][j].ToString());
        //                    }
        //                }
        //                cdvValue.Items.Add(itmX);
        //            }
        //        }

        //        if (insertEmptyRow == true)
        //        {
        //            cdvValue.InsertEmptyRow(0, 1);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMsgBox(ex.Message);
        //        return false;
        //    }
        //}

        #endregion

        #region "Zebra Print Function"
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        /// <summary>
        /// 지정 된 프린터 이름으로 데이터 Bytes 전송 ( Default : ZEBRA)
        /// </summary>
        /// <param name="szPrinterName"></param>
        /// <param name="szString"></param>
        /// <returns></returns>
        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            MPCF.FlushMemory();

            IntPtr pBytes;
            Int32 dwCount;

            szString = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(szString));

            //제브라 인쇄시 프린터 나왔다 다시 들어가는 행위를 바꾸기 위해 
            //ZPL 명령어 옵션 ^MMRN 리와인드 기능을 꺼준다.
            szString = szString.Replace("^MMT", "^MMRN").Replace("^MMC", "^MMRN");

            dwCount = (szString.Length + 1) * Marshal.SystemMaxDBCSCharSize;
            //dwCount = szString.Length;// + 1) * Marshal.SystemMaxDBCSCharSize;

            pBytes = Marshal.StringToCoTaskMemAnsi(szString); // ANSI
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);

            return true;
        }

        /// <summary>
        /// 지정 된 프린터 이름으로 데이터 Bytes 전송 ( Default : ZEBRA)
        /// </summary>
        /// <param name="szPrinterName"></param>
        /// <param name="szString"></param>
        /// <returns></returns>
        public static bool SendStringToPrinter(string szPrinterName, string szString, bool rewindFlag)
        {
            MPCF.FlushMemory();

            IntPtr pBytes;
            Int32 dwCount;


            if (rewindFlag == false)
            {
                //제브라 인쇄시 프린터 나왔다 다시 들어가는 행위를 바꾸기 위해 
                //ZPL 명령어 옵션 ^MMRN 리와인드 기능을 꺼준다.
                szString = szString.Replace("^MMT", "^MMRN").Replace("^MMC", "^MMRN");
            }

            dwCount = (szString.Length + 1) * Marshal.SystemMaxDBCSCharSize;

            pBytes = Marshal.StringToCoTaskMemAnsi(szString); // ANSI
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);

            return true;
        }

        /// <summary>
        /// 프린트 포트와 상관없이 프린터 이름으로 찾아서
        /// 인쇄
        /// </summary>
        /// <param name="szPrinterName"></param>
        /// <param name="pBytes"></param>
        /// <param name="dwCount"></param>
        /// <returns></returns>
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.
            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            //마지막 에러 체크
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        /// <summary>
        /// 선언후 
        ///  Dictionary<string, string> dictionary = new Dictionary<string, int>();
        ///    dictionary.Add("$BAR_CODE", "실제 치환하여 바꾸어질 값");
        ///    
        /// 인쇄
        /// </summary>
        /// <param name="printZebraCode"></param>
        /// <param name="sqlId"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static bool printZebraCode(string printerName, string sqlId, Dictionary<string, string> dictionary, bool rewindFlag)
        {
            string sPrintData = string.Empty;

            sPrintData = GetQueryString(sqlId);

            if (MPCF.Trim(sPrintData) == "")
            {
                return false;
            }

            foreach (KeyValuePair<string, string> kvp in dictionary)
            {
                sPrintData = sPrintData.Replace(kvp.Key, kvp.Value);
            }

            if (SendStringToPrinter(printerName, sPrintData, rewindFlag) == false)
            {
                return false;
            }

            return true;
        }

        public static string GetDefaultPrinter()
        {
            PrinterSettings settings = new PrinterSettings();

            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)
                {
                    return printer;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 선언후 
        ///  Dictionary<string, string> dictionary = new Dictionary<string, int>();
        ///    dictionary.Add("$BAR_CODE", "실제 치환하여 바꾸어질 값");
        ///    원격 프린터의 아이피와 포트 값을 던져 해당 프린터 출력
        /// 인쇄
        /// </summary>
        /// <param name="printZebraCodeByIpAddress"></param>
        /// <param name="sqlId"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static bool printZebraCodeByIpAddress(string printerName, string sqlId, Dictionary<string, string> dictionary, string ipAdress, int port, bool rewindFlag)
        {
            try
            {
                string sPrintData = string.Empty;

                sPrintData = GetQueryString(sqlId);

                if (MPCF.Trim(sPrintData) == "")
                {
                    return false;
                }

                foreach (KeyValuePair<string, string> kvp in dictionary)
                {
                    sPrintData = sPrintData.Replace(kvp.Key, kvp.Value);
                }

                if (rewindFlag == false)
                {
                    //제브라 인쇄시 프린터 나왔다 다시 들어가는 행위를 바꾸기 위해 
                    //ZPL 명령어 옵션 ^MMRN 리와인드 기능을 꺼준다.
                    sPrintData = sPrintData.Replace("^MMT", "^MMRN").Replace("^MMC", "^MMRN");
                }

                // Open connection
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
                client.Connect(ipAdress, port);

                // Write ZPL String to connection
                System.IO.StreamWriter writer =
                new System.IO.StreamWriter(client.GetStream());
                writer.Write(sPrintData);
                writer.Flush();

                // Close Connection
                writer.Close();
                client.Close();


            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }


            return true;
        }


        #endregion

        //public static void ViewMaterialAttributeList(SOICodeView cdvControl, string sMaterialType, string sKeyColumn, string sDescColumn)
        //{
        //    ViewMaterialAttributeList(cdvControl, sMaterialType, sKeyColumn, sDescColumn,"","", "", "");
        //}
        //public static void ViewMaterialAttributeList(SOICodeView cdvControl, string sMaterialType, string sKeyColumn, string sDescColumn, string sFilterColumn1, string sFilterValue1)
        //{
        //    ViewMaterialAttributeList(cdvControl, sMaterialType, sKeyColumn, sDescColumn, sFilterColumn1, sFilterValue1, "", "");
        //}
        //public static void ViewMaterialAttributeList(SOICodeView cdvControl, string sMaterialType, string sKeyColumn, string sDescColumn, string sFilterColumn1, string sFilterValue1, string sFilterColumn2, string sFilterValue2)
        //{

        //    int i_cond_cnt;
        //    string sViewID;
        //    Boolean bIcon = true;
        //    TPDR.DirectViewCond[] a;
        //    DataTable dt = new DataTable();

        //    try
        //    {

        //        cdvControl.Init();
        //        cdvControl.Columns.Add("CODE", 50, HorizontalAlignment.Left);
        //        cdvControl.Columns.Add("DESC", 100, HorizontalAlignment.Left);
        //        cdvControl.SelectedSubItemIndex = 0;

        //        sViewID = "COM0001-002";
        //        i_cond_cnt = 6;
        //        a = new TPDR.DirectViewCond[i_cond_cnt];

        //        a[0].sCondtion_ID = "$FACTORY";
        //        a[0].sCondition_Value = MPGV.gsFactory;

        //        a[1].sCondtion_ID = "$MAT_TYPE";
        //        a[1].sCondition_Value = sMaterialType;

        //        a[2].sCondtion_ID = "$KEY_COLUMN";
        //        a[2].sCondition_Value = sKeyColumn;

        //        a[3].sCondtion_ID = "$DESC_COLUMN";
        //        a[3].sCondition_Value = sDescColumn;

        //        a[4].sCondtion_ID = "$FILTER";
        //        if (sFilterColumn1 == "")
        //            a[4].sCondition_Value = "";
        //        else
        //            a[4].sCondition_Value = " AND " + sFilterColumn1+"='"+sFilterValue1+"' ";

        //        if (sFilterColumn2 != "")
        //            a[4].sCondition_Value += " AND " + sFilterColumn2 + "='" + sFilterValue2 + "' ";

        //        a[5].sCondtion_ID = "IINT";
        //        a[5].iCondition_Value = 1;

        //        if (TPDR.DirectViewOne(cdvControl.GetListView, sViewID, ref dt, bIcon, bIcon, a) == false)
        //        {
        //            if (dt != null) { dt.Dispose(); }
        //            GC.Collect();
        //            return;
        //        }
                


        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMsgBox(ex.Message);
        //        return;
        //    }
        //}

        /// <summary>
        /// Spread 초기화
        /// </summary>
        /// <param name="bRowHeader">Row Header를 보여줄지 여부</param>
        /// <param name="bSort">Column Sort 여부</param>
        /// <param name="operMode">Operation Mode 설정</param>
        ///
        public static void ApplyTema(FarPoint.Win.Spread.FpSpread fpSpd, bool bRowHeader, bool bSort, FarPoint.Win.Spread.OperationMode operMode)
        {
            ApplyTema(fpSpd, bRowHeader, bSort, operMode, false);
        }

        public static void ApplyTema(FarPoint.Win.Spread.FpSpread fpSpd, bool bRowHeader, bool bSort, FarPoint.Win.Spread.OperationMode operMode, bool bPKGClient, bool bEditFlag = true)
        {
            ApplyTema(fpSpd, bRowHeader, bSort, operMode, bPKGClient, bEditFlag, false);
        }

        public static void ApplyTema(FarPoint.Win.Spread.FpSpread fpSpd, bool bRowHeader, bool bSort, FarPoint.Win.Spread.OperationMode operMode, bool bPKGClient, bool bEditFlag, bool bSkipCellClieckEvnet = false)
        {
            FarPoint.Win.Spread.SheetSkin spSkin;

            try
            {
                //this.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(spd_CellDoubleClick);
                // 2016.12.03 by yh Kim - Function Overloading because Skip the Cell Click Event
                if (bSkipCellClieckEvnet == false)
                {
                    //fpSpd.CellClick += new CellClickEventHandler(udcFarpoint_CellClick);
                }

                FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(fpSpd);
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

                fpSpd.BorderStyle = BorderStyle.FixedSingle;
                fpSpd.BackColor = System.Drawing.Color.Silver;  //System.Drawing.SystemColors.Control; // System.Drawing.Color.Silver;
                fpSpd.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
                fpSpd.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
                fpSpd.MoveActiveOnFocus = true;

                fpSpd.ColumnSplitBoxAlignment = FarPoint.Win.Spread.SplitBoxAlignment.Leading;
                fpSpd.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.AsNeeded;

                fpSpd.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;

                fpSpd.SetCursor(FarPoint.Win.Spread.CursorType.Normal, System.Windows.Forms.Cursors.Arrow);
                fpSpd.BorderStyle = BorderStyle.FixedSingle;
                fpSpd.VerticalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
                fpSpd.HorizontalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
                fpSpd.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;

                //fpSpd.SubEditorOpening -= new SubEditorOpeningEventHandler(spd_SubEditorOpening);

                //fpSpd.SubEditorOpening += new SubEditorOpeningEventHandler(spd_SubEditorOpening);

                for (int i = 0; i < fpSpd.Sheets.Count; i++)
                {
                    //"Verdana", "Tahoma", "Times New Roman", "돋움"
                    Font myFonts = new Font("Tahoma", 8F, FontStyle.Regular);

                    spSkin.Apply(fpSpd.Sheets[i]);

                    //fpSpd.Sheets[i].RowCount = 1;
                    fpSpd.Sheets[i].ColumnCount = 0;
                    fpSpd.Sheets[i].FrozenColumnCount = 0;
                    fpSpd.Sheets[i].OperationMode = operMode;
                    fpSpd.Sheets[i].Columns[-1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                    fpSpd.Sheets[i].ColumnHeader.DefaultStyle.Font = new Font("Microsoft Sans Serif", 8.15F, System.Drawing.FontStyle.Regular);  // new Font("Tahoma", 8F, FontStyle.Bold);

                    if (bPKGClient)
                    {

                        if (bEditFlag)
                        {
                            fpSpd.Sheets[i].ColumnHeader.Rows[0].Height = 60F;
                            fpSpd.Sheets[i].Rows.Default.Height = 50F;

                            fpSpd.Sheets[i].DefaultStyle.Font = new Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular);
                            fpSpd.Sheets[i].ColumnHeader.DefaultStyle.Font = new Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular);  // new Font("Tahoma", 8F, FontStyle.Bold);
                        }
                        else
                        {
                            fpSpd.Sheets[i].ColumnHeader.Rows[0].Height = 40F;
                            fpSpd.Sheets[i].Rows.Default.Height = 30F;

                            fpSpd.Sheets[i].DefaultStyle.Font = new Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular);
                            fpSpd.Sheets[i].ColumnHeader.DefaultStyle.Font = new Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular);  // new Font("Tahoma", 8F, FontStyle.Bold);
                        }
                    }
                    else
                    {
                        if (bEditFlag)
                        {
                            fpSpd.Sheets[i].ColumnHeader.Rows[0].Height = 45F;
                            fpSpd.Sheets[i].Rows.Default.Height = 35F;
                            fpSpd.Sheets[i].DefaultStyle.Font = new Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular);
                            fpSpd.Sheets[i].ColumnHeader.DefaultStyle.Font = new Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular);  // new Font("Tahoma", 8F, FontStyle.Bold);
                        }
                        else
                        {
                            fpSpd.Sheets[i].ColumnHeader.Rows[0].Height = 35F;
                            fpSpd.Sheets[i].Rows.Default.Height = 25F;
                            fpSpd.Sheets[i].DefaultStyle.Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular);
                            fpSpd.Sheets[i].ColumnHeader.DefaultStyle.Font = new Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);  // new Font("Tahoma", 8F, FontStyle.Bold);
                        }
                    }

                    fpSpd.Sheets[i].DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                    // Auto sort setting.
                    fpSpd.Sheets[i].SetColumnAllowAutoSort(0, fpSpd.Sheets[i].ColumnCount, bSort);
                    fpSpd.Sheets[i].ColumnHeader.AutoSortIndex = 0;


                    //Auto Fit Column
                    //fpSpd.Sheets[i].CellChanged += new SheetViewEventHandler(ActiveSheet_CellChanged);

                    FarPoint.Win.Spread.CellType.ColumnHeaderRenderer ch =
                        (FarPoint.Win.Spread.CellType.ColumnHeaderRenderer)fpSpd.Sheets[i].ColumnHeader.DefaultStyle.Renderer;

                    if (ch == null)
                    {
                        ch = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
                    }

                    //if(ch == null)
                    ch.WordWrap = false;
                    fpSpd.Sheets[i].ColumnHeader.DefaultStyle.Renderer = ch;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public sealed class CPGV
    {
        #region "Global Variables"
        public static string gsShift;
        public static string gsShiftDesc;
        //public static ACC_INFO gsAccInfo;
        public static string gsQueryStatementLOG = "";
        public static int gsQueryStatementLOGCount = 0;

        public static string s_WavePath = @"Error.wav";
        public static string s_SuccessPath = @"Success.wav";

        public static Color DefaultBackColor = Color.Black;
        public static Color DefaultForeColor = Color.Yellow;
        public static Color ErrorBackColor = Color.Black;
        public static Color ErrorForeColor = Color.Yellow;
        public static Color SuccessBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(115)))), ((int)(((byte)(192)))));
        public static Color SuccessForeColor = Color.White;

        public static bool PublishYN = false; //Publish 여부를 설정 true상태이면 라벨이 깜빡이도록 false이면 깜빡이지 않도록 

        #endregion

        #region "Interface"

        #endregion

        #region "Field Constant"
        public static string gsQueryStatementLong = string.Empty; // 다중 쿼리사용시 Statement
        #endregion
        [DllImport("winspool.drv")]
        public static extern bool SetDefaultPrinter(string name);

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

    public sealed class ListviewItemComparer : IComparer
    {
        private int col;
        public string sort = "ASC";
        public ListviewItemComparer()
        {
            col = 0;
        }

        public ListviewItemComparer(int column, string sort)
        {
            col = column;
            this.sort = MPCF.ToUpper(sort);
        }

        public int Compare(object x, object y)
        {
            if (sort == "ASC")
            {
                return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }
            else
            {
                return String.Compare(((ListViewItem)y).SubItems[col].Text, ((ListViewItem)x).SubItems[col].Text);
            }
        }
        
    }
}
