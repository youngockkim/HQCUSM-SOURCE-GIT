/*---------------------------------------------------------------------------------------------------
 
    PROG ID     : CmnUtil
    Creator     : Park sung-hee
    Create Date : 2013.10.01
    Description : 일반적인 Util(Query,...)
 
    History     : Create Function InQuery
----------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Data;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using System.Threading;
using System.Collections;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using Miracom.TRSCore;
using Miracom.MESCore;
using Miracom.CliFrx;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Media;
using System.IO;
using System.Management;

namespace SOI.OIFrx
{
    public class CmnUtil
    {
        /// <summary>
        /// IN 쿼리문 생성. 쿼리문 전체에서 'IN (:PARAM)' 형식을 모두 'IN (SELECT * FROM TABLE(FN_SPLIT(:PARAM)))' 형식으로 변환해 준다.
        /// </summary>
        /// <param name="strQuery">전체 쿼리문</param>
        /// <returns>전체 쿼리에서 'IN (:PARAM)' 형식을 모두 'IN (SELECT * FROM TABLE(FN_SPLIT(:PARAM)))' 형식으로 변환, 전체 쿼리를 생성하여 반환한다.</returns>
        public static string InQuery(string strQuery)
        {
            string strResult = strQuery;
            //strQuery = "SELECT * FROM TB_CODE COD WHERE 1=1 AND COD.CDGRUPID = 'S0111' AND COD.CDID \nIN (:CDID) AND \n1=1 AND COD.CDID IN (:CDNM) AND 1=1";
            Regex regex = new Regex(@"IN[ ]*\([ ]*\:[A-Za-z0-9_\-]+[ ]*\)");

            MatchCollection matches = regex.Matches(strQuery);
            if (matches != null)
            {
                Regex regexPara = new Regex(@"\:[A-Za-z0-9_\-]+");
                foreach (Match match in matches)
                {
                    string strIn = strQuery.Substring(match.Index, match.Length);

                    Match matchPara = regexPara.Match(strIn);
                    string strPara = strIn.Substring(matchPara.Index, matchPara.Length);

                    strIn = "IN (SELECT * FROM TABLE(FN_SPLIT(" + strPara + ")))";

                    strResult = regex.Replace(strResult, strIn, 1);
                }
            }
            return strResult;

        }
        /// <summary>
        /// CMD Net Use Delete
        /// </summary>
        /// <returns></returns>
        public static bool SetNetDriveCmd()
        {
            bool bResult = true;

            try
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C net use * /delete /y";
                process.StartInfo = startInfo;
                Process.Start(startInfo);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.ToString());
            }

            return bResult;
        }
        /// <summary>
        /// AD Accunt
        /// </summary>
        public static string AdAccount()
        {
            string[] strTmp = null;
            string sName = string.Empty;

            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            strTmp = identity.Name.Split(new Char[] { '\\' });
            if (strTmp.Length > 0) sName = strTmp[1];
            strTmp = sName.Split(new Char[] { '@' });
            if (strTmp.Length > 0) sName = strTmp[0];

            return sName;
        }
    }

    public class MiscUtil
    {
        private StatusMessageBox StatusMessage;//= new StatusMessageBox();
        private static ManualResetEvent mevent = new ManualResetEvent(false);

        public System.Threading.Thread ProgressViewer;
        private string strMsg = string.Empty;
        private static MiscUtil mu = null;

        public UnmanagedMemoryStream sndWarning = global::SOI.OIFrx.Properties.Resources.warning;
        public UnmanagedMemoryStream sndCylen = global::SOI.OIFrx.Properties.Resources.Cylen1;
        public UnmanagedMemoryStream sndBoomp = global::SOI.OIFrx.Properties.Resources.boomp;
        public UnmanagedMemoryStream sndcombeep0 = global::SOI.OIFrx.Properties.Resources.combeep0;

        private int iMaxCnt = 6;//36초후에 자동 닫힘
        public int iMaxTime
        {
            get { return iMaxCnt; }
            set { iMaxCnt = value; }
        }
        /// <summary>
        ///  Static  - StatusMessageBox 창 띄우기( Thread)
        /// </summary>
        /// <param name="str">메시지</param>
        public static void ShowStatusMessage(string str)
        {
            if (mu != null)
            {
                mu.Close();
                mu = null;
            }
            mu = new MiscUtil(str);
        }
        /// <summary>
        /// static - StatusMessageBox 창 닫기
        /// </summary>
        public static void HideStatusMessage()
        {
            if (mu != null)
            {
                mu.Close();
            }
        }
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="sStr">메시지</param>
        public MiscUtil()
        {
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="sStr">메시지</param>
        public MiscUtil(string sStr)
        {
            //mevent.Set();
            this.strMsg = sStr;
            ProgressViewer = new System.Threading.Thread(new System.Threading.ThreadStart(Show));
            ProgressViewer.Start();
        }

        /// <summary>
        ///  StatusMessageBox 창 띄우기
        /// </summary>
        public void Show()
        {
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                StatusMessage = new StatusMessageBox();
                StatusMessage.SetMessage(this.strMsg);
                StatusMessage.iMaxTime = iMaxCnt;
                StatusMessage.ShowDialog();
                StatusMessage.Dispose();
                StatusMessage = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// StatusMessageBox 닫기
        /// </summary>
        public void Close()
        {
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;

                if (ProgressViewer != null)
                {
                    try
                    {
                        mevent.Reset();
                    }
                    catch { }
                }
                if (StatusMessage != null)
                {
                    StatusMessage.tmrWait.Stop();
                    StatusMessage.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void ThreadReset()
        {
            try
            {
                mevent.Reset();
            }
            catch { }
        }
        /// <summary>
        /// 날짜형식의 문자열을 날짜(DataTime)으로 변환하여 리턴한다.
        /// </summary>
        /// <param name="value">변경할 문자열값</param>
        /// <param name="stringFormat">문자열의 날짜형태</param>
        /// <param name="dtResult">결과를 리턴할 DateTime 변수</param>
        /// <returns>Boolean : True or False</returns>
        public Boolean StringToDateTime(string value, string stringFormat, out DateTime dtResult)
        {
            try
            {
                dtResult = DateTime.ParseExact(value, stringFormat,
                        System.Globalization.DateTimeFormatInfo.InvariantInfo,
                        System.Globalization.DateTimeStyles.AllowLeadingWhite |
                        System.Globalization.DateTimeStyles.AllowTrailingWhite);
                return true;
            }
            catch
            {
                dtResult = DateTime.MinValue;
                return false;
            }
        }

        /// <summary>
        /// DateTimePicker를 문자열값으로 변환하여 결과를 리턴한다.
        /// </summary>
        /// <param name="dtpObject">DateTimePicker Object</param>
        /// <param name="outFormat">변환할 형식(yyyy-MM-dd HH:mm:ss, yyyy/MM/dd hh:mm:ss)</param>
        /// <param name="strResult">결과를 리턴할 String 변수</param>
        /// <returns>Boolean : True or False</returns>
        public Boolean DateTimeToString(DateTimePicker dtpObject, string outFormat, out string strResult)
        {
            try
            {
                DateTime dt = DateTime.Parse(dtpObject.Text);
                strResult = dt.ToString(outFormat);
                return true;
            }
            catch
            {
                strResult = "";
                return false;
            }
        }

        /// <summary>
        /// 날짜형식의 문자열을 지정된 형식의 날짜문자열로 변환하여 리턴한다.
        /// </summary>
        /// <param name="value">날짜형식의 문자열</param>
        /// <param name="sourceFormat">vlaue가 가지는 날짜형식(yyyyMMddHHmmss,yyyyMMddhhmmss)</param>
        /// <param name="outFormat">변환할 형식(yyyy-MM-dd HH:mm:ss, yyyy/MM/dd hh:mm:ss)</param>
        /// <returns>Boolean : True or False</returns>
        public string ChangeDateTimeString(string value, string sourceFormat, string outFormat)
        {
            DateTime dt;

            try
            {
                if (StringToDateTime(value, sourceFormat, out dt) == true)
                {
                    return dt.ToString(outFormat);
                }
                else
                {
                    return value;
                }
            }
            catch
            {
                return "";
            }
        }
        /// 문자열 체크
        /// sGubun = 1 한글만 허용
        /// sGubun = 2 영문만 허용
        /// sGubun = 3 숫자만 허용
        /// sGubun = 4 특수문자 제외
        /// sGubun = 5 영문,숫자 제외
        /// sGubun = 6 영문,숫자 허용
        /// sGubun = 9 소숫점 및 숫자만 허용
        public bool Check_String(string sStr, int iGubun)
        {
            string alpha = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numeric = "1234567890";
            string Decimal = "1234567890.-,";
            string nonchar = "~`!@#$%^&*()-_=+|<>?,./;:";

            string sTemp = sStr;
            string sRegex = "";
            bool bResult;
            int i;

            switch (iGubun)
            {
                case (1): //한글만
                    {
                        sRegex = alpha + numeric + nonchar;
                        bResult = true;

                        for (i = 0; i < sTemp.Length; i++)
                        {
                            if (sRegex.IndexOf(sTemp.Substring(i, 1)) != -1)
                            {
                                bResult = false;
                                break;
                            }
                        }
                        break;
                    }
                case (2): //영문만
                    {
                        sRegex = alpha;
                        bResult = true;

                        for (i = 0; i < sRegex.Length; i++)
                        {
                            sTemp = sTemp.Replace(sRegex.Substring(i, 1), "");
                        }
                        if (sTemp != "") bResult = false;
                        break;
                    }
                case (3): //숫자만
                    {
                        sRegex = numeric;
                        bResult = true;

                        for (i = 0; i < sRegex.Length; i++)
                        {
                            sTemp = sTemp.Replace(sRegex.Substring(i, 1), "");
                        }
                        if (sTemp != "") bResult = false;
                        break;
                    }
                case (4): //특수문자만 제외
                    {
                        sRegex = nonchar;
                        bResult = true;

                        for (i = 0; i < sRegex.Length; i++)
                        {
                            sTemp = sTemp.Replace(@sRegex.Substring(i, 1), "");
                        }
                        if (sTemp != "") bResult = false;
                        break;
                    }
                case (5): //영문,숫자 제외
                    {
                        sRegex = alpha + numeric;
                        bResult = true;

                        for (i = 0; i < sRegex.Length; i++)
                        {
                            sTemp = sTemp.Replace(sRegex.Substring(i, 1), "");
                        }
                        if (sTemp != "") bResult = false;
                        break;
                    }
                case (6): //영문,숫자만 허용
                    {
                        sRegex = alpha + numeric;
                        bResult = true;

                        for (i = 0; i < sRegex.Length; i++)
                        {
                            sTemp = sTemp.Replace(sRegex.Substring(i, 1), "");
                        }
                        if (sTemp != "") bResult = false;
                        break;
                    }
                case (9): //소숫점,숫자만 허용
                    {
                        sRegex = Decimal;
                        bResult = true;

                        for (i = 0; i < sRegex.Length; i++)
                        {
                            sTemp = sTemp.Replace(sRegex.Substring(i, 1), "");
                        }
                        if (sTemp != "") bResult = false;
                        break;
                    }
                default: bResult = true; break;
            }

            return bResult;
        }
        /// <summary>
        /// 퍼센트로 줄이기
        /// </summary>
        /// <param name="imgPhoto">사진 객체</param>
        /// <param name="Percent">퍼센트</param>
        /// <returns>수정된 Image</returns>
        public static Image Scaling(Image imgPhoto, int Percent)
        {
            //퍼센트 0.8 or 0.5 ..

            float nPercent = ((float)Percent / 100);

            //넓이와 높이
            int OriginalWidth = imgPhoto.Width;
            int OriginalHeight = imgPhoto.Height;

            //소스의 처음 위치
            int OriginalX = 0;
            int OriginalY = 0;

            //움직일 위치
            int adjustX = 0;
            int adjustY = 0;

            //조절될 퍼센트 계산
            int adjustWidth = (int)(OriginalWidth * nPercent);
            int adjustHeight = (int)(OriginalHeight * nPercent);

            //비어있는 비트맵 객체 생성
            Bitmap bmPhoto = new Bitmap(adjustWidth, adjustHeight, PixelFormat.Format24bppRgb);

            //이미지를 그래픽 객체로 만든다.
            Graphics grPhoto = Graphics.FromImage(bmPhoto);

            //사각형을 그린다.

            //그릴 이미지객체 크기, 그려질 이미지객체 크기
            grPhoto.DrawImage(imgPhoto,
            new Rectangle(adjustX, adjustY, adjustWidth, adjustHeight),
            new Rectangle(OriginalX, OriginalY, OriginalWidth, OriginalHeight),
            GraphicsUnit.Pixel);
            grPhoto.Dispose();

            return bmPhoto;
        }
        /// <summary>
        /// 특정 Size 에 맞게 줄이기
        /// </summary>
        /// <param name="imgPhoto">사진 객체</param>
        /// <param name="size">변환할 사이즈</param>
        /// <returns>수정된 Image</returns>
        public static Image Scaling(Image imgPhoto, Size size)
        {

            //이미지 넓이와 높이
            int OriginalWidth = imgPhoto.Width;
            int OriginalHeight = imgPhoto.Height;

            //이미지를 적용할 객체의 넓이와 높이
            int adjustWidth = size.Width;
            int adjustHeight = size.Height;

            //소스의 처음 위치
            int OriginalX = 0;
            int OriginalY = 0;

            //움직일 위치
            int adjustX = 0;
            int adjustY = 0;

            //비어있는 비트맵 객체 생성
            Bitmap bmPhoto = new Bitmap(adjustWidth, adjustHeight, PixelFormat.Format24bppRgb);

            //이미지를 그래픽 객체로 만든다.
            Graphics grPhoto = Graphics.FromImage(bmPhoto);

            //사각형을 그린다.

            //그릴 이미지객체 크기, 그려질 이미지객체 크기
            grPhoto.DrawImage(imgPhoto
                , new Rectangle(adjustX, adjustY, adjustWidth, adjustHeight)
                , new Rectangle(OriginalX, OriginalY, OriginalWidth, OriginalHeight)
                , GraphicsUnit.Pixel);
            grPhoto.Dispose();

            return bmPhoto;
        }

        public static bool GetSoundPlay(string sSound, string sPlayType)
        {
            SoundPlayer sndPlayer = new SoundPlayer();

            if (sSound.Equals("Warning"))
            {
                sndPlayer = new SoundPlayer(global::SOI.OIFrx.Properties.Resources.warning);
            }
            else if (sSound.Equals("Cylen"))
            {
                sndPlayer = new SoundPlayer(global::SOI.OIFrx.Properties.Resources.Cylen1);
            }
            else if (sSound.Equals("Boomp"))
            {
                sndPlayer = new SoundPlayer(global::SOI.OIFrx.Properties.Resources.boomp);
            }
            else if (sSound.Equals("Combeep0"))
            {
                sndPlayer = new SoundPlayer(global::SOI.OIFrx.Properties.Resources.combeep0);
            }
            else if (sSound.Equals("success"))
            {
                sndPlayer = new SoundPlayer(global::SOI.OIFrx.Properties.Resources.success);
            }
            else if (sSound.Equals("ERROR"))
            {
                sndPlayer = new SoundPlayer(global::SOI.OIFrx.Properties.Resources.ERROR);
            }
            else if (sSound.Equals("FINISH"))
            {
                sndPlayer = new SoundPlayer(global::SOI.OIFrx.Properties.Resources.FINISH);
            }
            else if (sSound.Equals("ITEM"))
            {
                sndPlayer = new SoundPlayer(global::SOI.OIFrx.Properties.Resources.ITEM);
            }
            else if (sSound.Equals("SNP_8"))
            {
                sndPlayer = new SoundPlayer(global::SOI.OIFrx.Properties.Resources.SNP_8);
            }

            if (sPlayType.Equals("PlayLooping"))
            {
                sndPlayer.PlayLooping();
            }
            else if (sPlayType.Equals("Play"))
            {
                sndPlayer.Play();
                sndPlayer.Dispose();
            }
            return true;
        }
        public static bool GetSoundStop()
        {
            SoundPlayer sndPlayer = new SoundPlayer();

            sndPlayer.Stop();
            sndPlayer.Dispose();

            return true;
        }

    }

    public class TranUtil
    {
        private TranMessageBox TranMessage;
        private static ManualResetEvent mevent = new ManualResetEvent(false);
        private System.Windows.Forms.Label lblMessage = new System.Windows.Forms.Label();

        public System.Threading.Thread ProgressViewer;
        private string strMsg = string.Empty;
        private bool bMode = true;
        private string sLotId;
        private bool bSetValue = true;
        public bool SetValue
        {
            get { return bSetValue; }
            set { bSetValue = value; }
        }
        private static TranUtil mu = null;
        /// <summary>
        ///  Static  - StatusMessageBox 창 띄우기( Thread)
        /// </summary>
        /// <param name="str">메시지</param>
        public static void ShowStatusMessage(string sLot_Id, bool bMode)
        {
            if (mu != null)
            {
                mu.Close();
                mu = null;
            }
            mu = new TranUtil(sLot_Id, bMode);
        }
        /// <summary>
        /// static - StatusMessageBox 창 닫기
        /// </summary>
        public static void HideStatusMessage()
        {
            if (mu != null)
            {
                mu.Close();
            }
        }


        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="sStr">메시지</param>
        public TranUtil(string sLot_Id, bool bMode)
        {
            //mevent.Set();
            this.sLotId = sLot_Id;
            this.bMode = bMode;
            ProgressViewer = new System.Threading.Thread(new System.Threading.ThreadStart(Show));
            ProgressViewer.Start();
        }

        /// <summary>
        ///  StatusMessageBox 창 띄우기
        /// </summary>
        public void Show()
        {
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                Process();

                TranMessage = new TranMessageBox();
                TranMessage.SetMessage(this.lblMessage.Text);
                TranMessage.ShowDialog();
                TranMessage.Dispose();
                TranMessage = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// StatusMessageBox 닫기
        /// </summary>
        public void Close()
        {
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;

                if (ProgressViewer != null)
                {
                    try
                    {
                        mevent.Reset();
                    }
                    catch { }
                }
                if (TranMessage != null)
                {
                    TranMessage.tmrWait.Stop();
                    TranMessage.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void ThreadReset()
        {
            try
            {
                mevent.Reset();
            }
            catch { }
        }
        private bool TranEndLot(string s_lot_id)
        {
            TRSNode in_node = new TRSNode("WIP_END_LOT_IN");
            TRSNode out_node = new TRSNode("WIP_END_LOT_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.SetString("LOT_ID", MPCF.Trim(s_lot_id));
                in_node.SetString("STATUS_MSG_FLAG", "Y");

                if (MPCR.CallService("WIP", "WIP_End_Lot_For_Inv", in_node, ref out_node) == false)
                {
                    SetValue = false;
                    MPOF.ShowStatusErrorMsg(lblMessage, in_node, false);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MPOF.ShowStatusDefaultMsg(lblMessage, ex.Message, false);
                return false;
            }
            return true;
        }

        private bool TranUndoEndLot(string s_lot_id)
        {
            TRSNode out_node = new TRSNode("WIP_END_LOT_OUT");
            TRSNode in_node = new TRSNode("WIP_END_LOT_IN");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.SetChar("DELETE_FORCE", 'Y');
                in_node.SetString("LOT_ID", MPCF.Trim(s_lot_id));
                in_node.SetString("STATUS_MSG_FLAG", "Y");

                if (MPCR.CallService("WIP", "WIP_End_Lot_For_Inv", in_node, ref out_node) == false)
                {
                    MPOF.ShowStatusErrorMsg(lblMessage, in_node, false);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowStatusDefaultMsg(lblMessage, ex.Message, false);
                return false;
            }
        }

        private void Process()
        {
            try
            {
                MPOF.ShowStatusDefaultMsg(lblMessage, "", false);
                string s_lot_id = sLotId.Trim();

                if (bMode == false)
                {
                    if (TranEndLot(s_lot_id) == false)
                    {
                        SetValue = false;
                        return;
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    if (TranUndoEndLot(s_lot_id) == false)
                    {
                        SetValue = false;
                        return;
                    }
                    else
                    {
                        this.Close();
                    }
                }
                MPOF.ShowStatusDefaultSuccessMsg(lblMessage, MPCF.GetMessage(52), false);

            }
            catch (Exception ex)
            {
                MPOF.ShowStatusDefaultMsg(lblMessage, ex.Message, false);
                return;
            }
            finally { }
        }

    }

    public class MatUtil
    {
        private StatusMessageBox StatusMessage;//= new StatusMessageBox();
        private static ManualResetEvent mevent = new ManualResetEvent(false);

        public System.Threading.Thread ProgressViewer;
        private string strMsg = string.Empty;
        private static MiscUtil mu = null;
        public static int iMaxCount = 0;

        /// <summary>
        ///  Static  - StatusMessageBox 창 띄우기( Thread)
        /// </summary>
        /// <param name="str">메시지</param>
        public static void ShowStatusMessage(string str)
        {
            if (mu != null)
            {
                mu.Close();
                mu = null;
            }
            mu = new MiscUtil(str);
        }
        /// <summary>
        ///  Static  - StatusMessageBox 창 띄우기( Thread)
        /// </summary>
        /// <param name="str">메시지</param>
        public static void ShowStatusMessage(string str, int i_MaxCount)
        {
            if (mu != null)
            {
                mu.Close();
                mu = null;
            }

            MatUtil.iMaxCount = i_MaxCount;

            mu = new MiscUtil(str);
        }
        /// <summary>
        /// static - StatusMessageBox 창 닫기
        /// </summary>
        public static void HideStatusMessage()
        {
            if (mu != null)
            {
                mu.Close();
            }
        }


        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="sStr">메시지</param>
        public MatUtil(string sStr)
        {
            //mevent.Set();
            this.strMsg = sStr;
            ProgressViewer = new System.Threading.Thread(new System.Threading.ThreadStart(Show));
            ProgressViewer.Start();
        }

        /// <summary>
        ///  StatusMessageBox 창 띄우기
        /// </summary>
        public void Show()
        {
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                StatusMessage = new StatusMessageBox(iMaxCount);
                StatusMessage.SetMessage(this.strMsg);
                StatusMessage.ShowDialog();
                StatusMessage.Dispose();
                StatusMessage = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// StatusMessageBox 닫기
        /// </summary>
        public void Close()
        {
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;

                if (ProgressViewer != null)
                {
                    try
                    {
                        mevent.Reset();
                    }
                    catch { }
                }
                if (StatusMessage != null)
                {
                    StatusMessage.tmrWait.Stop();
                    StatusMessage.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void ThreadReset()
        {
            try
            {
                mevent.Reset();
            }
            catch { }
        }

    }
    public class OIUtil
    {
        private StatusMessageBoxOI StatusMessage;
        private static ManualResetEvent mevent = new ManualResetEvent(false);

        public System.Threading.Thread ProgressViewer;
        private string strMsg = string.Empty;
        private static OIUtil mu = null;
        public static int iMaxCount = 0;

        /// <summary>
        ///  Static  - StatusMessageBox 창 띄우기( Thread)
        /// </summary>
        /// <param name="str">메시지</param>
        public static void ShowStatusMessage(string str)
        {
            if (mu != null)
            {
                mu.Close();
                mu = null;
            }
            mu = new OIUtil(str);
        }
        /// <summary>
        ///  Static  - StatusMessageBox 창 띄우기( Thread)
        /// </summary>
        /// <param name="str">메시지</param>
        public static void ShowStatusMessage(string str, int i_MaxCount)
        {
            if (mu != null)
            {
                mu.Close();
                mu = null;
            }

            OIUtil.iMaxCount = i_MaxCount;

            mu = new OIUtil(str);
        }
        /// <summary>
        /// static - StatusMessageBox 창 닫기
        /// </summary>
        public static void HideStatusMessage()
        {
            if (mu != null)
            {
                mu.Close();
            }
        }


        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="sStr">메시지</param>
        public OIUtil(string sStr)
        {
            //mevent.Set();
            this.strMsg = sStr;
            ProgressViewer = new System.Threading.Thread(new System.Threading.ThreadStart(Show));
            ProgressViewer.Start();
        }

        /// <summary>
        ///  StatusMessageBox 창 띄우기
        /// </summary>
        public void Show()
        {
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                StatusMessage = new StatusMessageBoxOI(iMaxCount);
                StatusMessage.SetMessage(this.strMsg);
                StatusMessage.ShowDialog();
                StatusMessage.Dispose();
                StatusMessage = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// StatusMessageBox 닫기
        /// </summary>
        public void Close()
        {
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;

                if (ProgressViewer != null)
                {
                    try
                    {
                        mevent.Reset();
                    }
                    catch { }
                }
                if (StatusMessage != null)
                {
                    StatusMessage.tmrWait.Stop();
                    StatusMessage.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void ThreadReset()
        {
            try
            {
                mevent.Reset();
            }
            catch { }
        }

    }

    //public class UsbPort
    //{
    //    public static List<USBDeviceInfo> GetUSBDevices()
    //    {
    //        List<USBDeviceInfo> devices = new List<USBDeviceInfo>();
            
    //        ManagementObjectCollection collection;
    //        using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
    //            collection = searcher.Get();

    //        foreach (var device in collection)
    //        {
    //            devices.Add(new USBDeviceInfo(
    //            (string)device.GetPropertyValue("DeviceID"),
    //            (string)device.GetPropertyValue("PNPDeviceID"),
    //            (string)device.GetPropertyValue("Description")
    //            ));
    //        }

    //        collection.Dispose();
    //        return devices;
    //    }

    //    public class USBDeviceInfo
    //    {
    //        public USBDeviceInfo(string deviceID, string pnpDeviceID, string description)
    //        {
    //            this.DeviceID = deviceID;
    //            this.PnpDeviceID = pnpDeviceID;
    //            this.Description = description;
    //        }
    //        public string DeviceID { get; private set; }
    //        public string PnpDeviceID { get; private set; }
    //        public string Description { get; private set; }
    //    }


    //}
}
