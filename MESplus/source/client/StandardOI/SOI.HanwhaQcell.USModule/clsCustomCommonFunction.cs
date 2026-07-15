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
using SOI.MsgHandlerH101;
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
using BOI.OIFrx;
using Infragistics.Win.UltraWinGrid;
using System.Data;
using System.IO.Ports;
using System.IO.Compression;
using System.Management.Instrumentation;

using Miracom.MESCore;
using System.Runtime.Serialization.Formatters.Binary;
#endregion

namespace SOI.HanwhaQcell.USModule
{
   
    public class HQCF
    {

        #region " Constant Definition "

        #endregion


        #region " Function Definition "

        public static bool Publish_M_MsgTune()
        {

            try
            {
                string sPublishChannel;

                if (HQGV.gbTunePublish == false)
                    return true;

                //if (MPCF.Trim(MPGV.gsLine) == "" || MPCF.Trim(MPGV.gsTuneId) == "")
                if (MPCF.Trim(HQGV.gsPCId) == "")
                    return true;

                sPublishChannel = "/" + MPGV.gsSiteID;

                sPublishChannel += "/" + "MESCLI";

                sPublishChannel += "/" + MPGV.gsFactory;
                sPublishChannel += "/" + HQGV.gsPCId;

                //sPublishChannel = sPublishChannel.Replace("-", "");

                MPMH.registerDispatcher("MESCLI", new miracomTunerImpl());

                if (true != MPMH.tune(sPublishChannel, true, false))
                {
                    MPCF.ShowMsgBox("Message Tuning " + MPMH.StatusMessage, MessageBoxButtons.OK, MSG_LEVEL.ERROR);
                    return false;
                }
                //frmMDIMainCore frm = new frmMDIMainCore(sPublishChannel);
                //MPGV.gsMCPulblishChannel = sPublishChannel;
            }
            catch (Exception)
            {
                MPCF.ShowMsgBox("Publish_M_MsgTune() Failed.");
                return false;
            }

            return true;

        }

        public static string MakeTimeFormatHHMM(string S)
        {
            try
            {
                string sReturn = string.Empty;

                if (string.IsNullOrEmpty(S))
                {
                    return sReturn;
                }

                sReturn = S.Substring(0, 2) + ":" + S.Substring(2, 2);

                return sReturn;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        public static bool CheckNewMaterialID(String sMatId)
        {
            double result;

            if (sMatId.Length > 0 &&
                double.TryParse(sMatId.TrimStart('0'), out result) == false)
            {
                return true;
            }

            return false;
        }

        /// 지정한 Cell로 포커스 이동
        /// </summary>
        /// <param name="fps"></param>
        /// <param name="iRow"></param>
        /// <param name="iCol"></param>
        public static void SetPosition(FarPoint.Win.Spread.FpSpread fps, int iRow, int iCol)
        {
            fps.ActiveSheet.ActiveRowIndex = iRow;
            fps.ActiveSheet.ActiveColumnIndex = iCol;
            //fps.ActiveSheet.Models.Selection.SetSelection(iRow, 0, 1, fps.ActiveSheet.ColumnCount);
            fps.ShowCell(fps.GetActiveRowViewportIndex()
                            , fps.GetActiveColumnViewportIndex()
                            , iRow
                            , iCol
                            , FarPoint.Win.Spread.VerticalPosition.Center
                            , FarPoint.Win.Spread.HorizontalPosition.Left);
        }

        #region " Client & Printer Status Check "
        /// <summary>
        /// Set Client(Local) IP Address
        /// HQGV.gsClientIPAddress = (Local)IP
        /// 2023.10.03 YYK
        /// </summary>
        /// <returns>bool</returns>
        public static bool SetClientIPAddress()
        {
            IPHostEntry host;
            try
            {
                host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (IPAddress.IsLoopback(ip) == false && ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        HQGV.gsClientIPAddress = ip.ToString();
                        return true;
                    }
                }
                return true;
            }
            catch
            {
                HQGV.gsClientIPAddress = "";
                return false;
            }
        }

        public static bool SetDefaultPrinter()
        {
            HQGV.gsDefaultPrinter = "";
            System.Drawing.Printing.PrinterSettings setting = new System.Drawing.Printing.PrinterSettings();
            try
            {
                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    setting.PrinterName = printer;
                    if (setting.IsDefaultPrinter)
                    {
                        HQGV.gsDefaultPrinter = printer;
                        return true;
                    }
                }
                return true;
            }
            catch
            {
                HQGV.gsDefaultPrinter = "";
                return false;
            }
        }

        /// <summary>
        /// Printer On/Off Status 조회
        /// </summary>
        /// <returns></returns>
        public static bool SetPrinterStatus(string PrinterName)
        {
            try
            {
                string path = @"win32_printer.DeviceId='" + PrinterName + "'";
                ManagementObject printer = new ManagementObject(path);
                if (printer["WorkOffline"].ToString().ToLower().Equals("true"))
                {
                    HQGV.gsPrinterStatus = "OFF";
                    HQGV.gsPrinterStatusMsg = "Is Off Line";
                }
                else
                {
                    HQGV.gsPrinterStatus = "ON";
                    HQGV.gsPrinterStatusMsg = "";
                }

                return true;
            }
            catch (Exception ex)
            {
                HQGV.gsPrinterStatus = "ERR";
                HQGV.gsPrinterStatusMsg = ex.Message;
                return false;
            }
        }

        public static bool SendClientStatus()
        {
            TRSNode in_node = new TRSNode("CPSM_UPDATE_PROD_MONITERING_IN");
            TRSNode out_node = new TRSNode("CPSM_UPDATE_PROD_MONITERING_OUT");

            HQGV.gsPrinterStatus = "";
            HQGV.gsPrinterStatusMsg = "";

            try
            {
                if (MPCF.Trim(HQGV.gsClientIPAddress) == "")
                    SetClientIPAddress();

                //IP Address 공백 시 Error
                if (MPCF.Trim(HQGV.gsClientIPAddress) == "")
                    return false;

                if (HQGV.gbCheckPrinterFlag == true)
                {
                    //60분 단위로 Default Printer 재조회
                    if (HQGV.giPrinterCheckCount > HQGC.MESOI_SERVER_CHECK_TIME)
                    {
                        HQGV.giPrinterCheckCount = 0;
                        HQGV.gsDefaultPrinter = "";
                    }

                    HQGV.giPrinterCheckCount++;

                    if (MPCF.Trim(HQGV.gsDefaultPrinter) == "")
                        SetDefaultPrinter();

                    if (MPCF.Trim(HQGV.gsDefaultPrinter) != "")
                    {
                        SetPrinterStatus(HQGV.gsDefaultPrinter);
                    }
                }


                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.SetString("FACTORY", MPGV.gsFactory);
                in_node.SetString("CATEGORY", "MESOI");
                in_node.SetString("BASE_CODE", HQGV.gsClientIPAddress);
                //in_node.SetString("SUB_CODE", ""); OI Client는 SUB_CODE가 없음
                in_node.SetString("CLIENT_VERSION", MPGV.gsClientVersion);
                in_node.SetString("STATUS", HQGV.gsPrinterStatus);
                in_node.SetString("STATUS_MSG", HQGV.gsPrinterStatusMsg);

                if (MPCF.CallService("CPSM", "CPSM_Update_Monitoring_Status", in_node, ref out_node, false) == false)
                {
                    return false;
                }

                //Update Print Check Falg
                HQGV.gbCheckPrinterFlag = (out_node.GetChar("PRINT_CHECK") == 'Y' ? true : false);

                HQGV.gbStatusCheckFlag = (out_node.GetChar("STATUS_CHECK") == 'Y' ? true : false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        #endregion



        #endregion
    }
}
