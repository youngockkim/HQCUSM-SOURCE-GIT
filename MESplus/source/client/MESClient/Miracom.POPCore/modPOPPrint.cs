
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

using System.Threading;
using Miracom.TRSCore;
using System.Drawing.Printing;


//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : modPOPPrint.vb
//   Description : Funtions About Label Print.
//
//   MES Version : 1.0.0
//
//   Function List
//       -
//       -
//
//   Detail Description
//       -
//       -
//
//   History
//       - 2005-04-27 : Created by HS Kim
//
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _POP = True Then

//Imports

namespace Miracom.POPCore
{
    public sealed class modPOPPrint
    {
        
        #region "Const About File Manage"
        
        public struct SECURITY_ATTRIBUTES
        {
            public int nLength;
            public int lpSecurityDescriptor;
            public int bInheritHandle;
        }
        
        public const int DELETE = 0x10000;
        public const int READ_CONTROL = 0x20000;
        public const int WRITE_DAC = 0x40000;
        public const int WRITE_OWNER = 0x80000;
        public const int SYNCHRONIZE = 0x100000;
        
        public const int STANDARD_RIGHTS_READ = (READ_CONTROL);
        public const int STANDARD_RIGHTS_WRITE = (READ_CONTROL);
        public const int STANDARD_RIGHTS_EXECUTE = (READ_CONTROL);
        public const int STANDARD_RIGHTS_REQUIRED = 0xF0000;
        public const int STANDARD_RIGHTS_ALL = 0x1F0000;
        
        public const int ACCESS_SYSTEM_SECURITY = 0x1000000;
        public int GENERIC_READ = -2147483648;
        public const int GENERIC_WRITE = 0x40000000;
        public const int GENERIC_EXECUTE = 0x20000000;
        public const int GENERIC_ALL = 0x10000000;
        
        //  MaximumAllowed access type
        public const int MAXIMUM_ALLOWED = 0x2000000;
        
        
        public const uint FILE_SHARE_READ = 0x1;
        public const uint FILE_SHARE_WRITE = 0x2;
        public const uint FILE_ATTRIBUTE_READONLY = 0x1;
        public const uint FILE_ATTRIBUTE_HIDDEN = 0x2;
        public const uint FILE_ATTRIBUTE_SYSTEM = 0x4;
        public const uint FILE_ATTRIBUTE_DIRECTORY = 0x10;
        public const uint FILE_ATTRIBUTE_ARCHIVE = 0x20;
        public const uint FILE_ATTRIBUTE_NORMAL = 0x80;
        public const uint FILE_ATTRIBUTE_TEMPORARY = 0x100;
        public const uint FILE_ATTRIBUTE_COMPRESSED = 0x800;
        
        public const int FILE_FLAG_OVERLAPPED = 0x40000000;

        public const uint CREATE_NEW = 1;
        public const uint CREATE_ALWAYS = 2;
        public const uint OPEN_EXISTING = 3;
        public const uint OPEN_ALWAYS = 4;
        public const uint TRUNCATE_EXISTING = 5;
        
        public const int INVALID_HANDLE_VALUE = - 1;
        //UPGRADE_WARNING: Structure SECURITY_ATTRIBUTES may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1050"'
        //[DllImport("kernel32",EntryPoint="CreateFileA", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
        //public static extern IntPtr CreateFile(string lpFileName, int dwDesiredAccess, int dwShareMode, ref SECURITY_ATTRIBUTES lpSecurityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes, int hTemplateFile);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern Microsoft.Win32.SafeHandles.SafeFileHandle CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport("kernel32",EntryPoint="CloseHandle", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
        public static extern int CloseHandle(IntPtr hObject);
        //'Public Declare Function CreateFont Lib "gdi32" Alias "CreateFontA" (ByVal H As Integer, ByVal W As Integer, ByVal E As Integer, ByVal O As Integer, ByVal W As Integer, ByVal I As Integer, ByVal u As Integer, ByVal S As Integer, ByVal C As Integer, ByVal OP As Integer, ByVal CP As Integer, ByVal Q As Integer, ByVal PAF As Integer, ByVal F As String) As Integer
        //'Public Declare Function SelectObject Lib "gdi32" Alias "SelectObject" (ByVal hdc As Integer, ByVal hObject As Integer) As Integer
        //'Public Declare Function DeleteObject Lib "gdi32" Alias "DeleteObject" (ByVal hObject As Integer) As Integer
        //'Public Declare Function TextOut Lib "gdi32" Alias "TextOutA" (ByVal hdc As Integer, ByVal x As Integer, ByVal y As Integer, ByVal lpString As String, ByVal nCount As Integer) As Integer
        //'Public Declare Function GetDC Lib "user32" Alias "GetDC" (ByVal hwnd As IntPtr) As Integer
        //'Public Declare Function ReleaseDC Lib "user32" Alias "ReleaseDC" (ByVal hwnd As IntPtr, ByVal hdc As Integer) As Integer


        
        
        
        //// Working mode
        public enum Mode
        {
            NonOverlapped,
            Overlapped
        }
        
        #endregion
        
        #region "Const Definition "

        public const string POP_PRINT_PORT_SPOOL = "SPO";
        public const string POP_BAR_FONT_DATA_MATRIX = "X";
        public const string POP_BAR_FONT_QR = "Q";
        public const string POP_PRINT_TYPE_TPCL = "TPCL";        
        
        #endregion
        
        #region "Variable Definition"

        public static string sPrinterName = "";
        
        #endregion
        
        
        //-----------------------------------------------------------------------------
        //
        // Send_Data()
        //       - Send Data to Label Printer
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        //-----------------------------------------------------------------------------
        public static bool Send_Data(string sPrintType, Rs232 aComPort, string aData)
        {
            
            byte[] aryByte = Encoding.Default.GetBytes(aData);
            
            try
            {
                
                switch (sPrintType.Substring(0, 3))
                {
                    case MPGC.POP_PRINT_PORT_LPT:


                        Microsoft.Win32.SafeHandles.SafeFileHandle hFile = null;

                        hFile = CreateFile(sPrintType, GENERIC_WRITE, FILE_SHARE_WRITE, IntPtr.Zero, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);

                        //IntPtr hFile;
                        
                        //// Create File
                        //modPOPPrint.SECURITY_ATTRIBUTES security_attributes = new SECURITY_ATTRIBUTES();

                        //hFile = CreateFile(sPrintType, GENERIC_WRITE, FILE_SHARE_WRITE, ref security_attributes, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, 0);

                        /* LPT Æ÷Æ®°¡ È°¼ºÈ­ µÇ¾î Status °¡ OK°¡ ¾Æ´Ï¸é IsInvalid°¡ true°¡ µÊ. */
                        if (hFile.IsInvalid)
                        {
                            return false;
                        }

                        //FileStream fs = new FileStream(hFile, FileAccess.Write);
                        FileStream fs = new FileStream(hFile, FileAccess.Write);
                        
                        fs.Write(aryByte, 0, aryByte.Length);
                        
                        fs.Close();
                        fs = null;
                        break;
                        
                    case MPGC.POP_PRINT_PORT_COM:
                        
                        
                        aComPort.Write(aData);
                        break;

                    case POP_PRINT_PORT_SPOOL:         //Windows Printer Spool

                        if (MPCF.Trim(sPrinterName) == "")
                        {
                            return false;
                        }
                        IntPtr ptUnmanagedData = new IntPtr(0);
                        ptUnmanagedData = Marshal.AllocCoTaskMem(aryByte.Length);
                        /* Byte Çü½ÄÀÇ Data¸¦ º¯¼ö¿¡ ³ÖÀ½ */
                        Marshal.Copy(aryByte, 0, ptUnmanagedData, aryByte.Length);

                        // Send a printer-specific to the printer.
                        if(RawPrinter.SendBytesToPrinter(sPrinterName, ptUnmanagedData, aryByte.Length) == false)
                        {
                            return false;
                        }
                        Clipboard.SetText(aData);

                        break;                                            
                }
                
                return true;
                
            }
            catch (IOException IOExcep)
            {
                MPCF.ShowMsgBox(IOExcep.Message);
                return false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }

        //-----------------------------------------------------------------------------
        //
        // Send_Data_To_Byte()
        //       - Send byte data to Label Printer
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        //-----------------------------------------------------------------------------
        public static bool Send_Data_To_Byte(string sPrintType, Rs232 aComPort, byte[] aryByte)
        {           
            try
            {

                switch (sPrintType.Substring(0, 3))
                {
                    case MPGC.POP_PRINT_PORT_LPT:


                        Microsoft.Win32.SafeHandles.SafeFileHandle hFile = null;

                        hFile = CreateFile(sPrintType, GENERIC_WRITE, FILE_SHARE_WRITE, IntPtr.Zero, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);

                        //IntPtr hFile;

                        //// Create File
                        //modPOPPrint.SECURITY_ATTRIBUTES security_attributes = new SECURITY_ATTRIBUTES();

                        //hFile = CreateFile(sPrintType, GENERIC_WRITE, FILE_SHARE_WRITE, ref security_attributes, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, 0);

                        /* LPT Æ÷Æ®°¡ È°¼ºÈ­ µÇ¾î Status °¡ OK°¡ ¾Æ´Ï¸é IsInvalid°¡ true°¡ µÊ. */
                        if (hFile.IsInvalid)
                        {
                            return false;
                        }

                        //FileStream fs = new FileStream(hFile, FileAccess.Write);
                        FileStream fs = new FileStream(hFile, FileAccess.Write);

                        fs.Write(aryByte, 0, aryByte.Length);

                        fs.Close();
                        fs = null;
                        break;

                    case MPGC.POP_PRINT_PORT_COM:


                        aComPort.Write(aryByte);
                        break;

                    case POP_PRINT_PORT_SPOOL:         //Windows Printer Spool

                        if (MPCF.Trim(sPrinterName) == "")
                        {
                            return false;
                        }
                        IntPtr ptUnmanagedData = new IntPtr(0);
                        ptUnmanagedData = Marshal.AllocCoTaskMem(aryByte.Length);
                        /* Byte Çü½ÄÀÇ Data¸¦ º¯¼ö¿¡ ³ÖÀ½ */
                        Marshal.Copy(aryByte, 0, ptUnmanagedData, aryByte.Length);

                        // Send a printer-specific to the printer.
                        if (RawPrinter.SendBytesToPrinter(sPrinterName, ptUnmanagedData, aryByte.Length) == false)
                        {
                            return false;
                        }                        

                        break;
                }

                return true;

            }
            catch (IOException IOExcep)
            {
                MPCF.ShowMsgBox(IOExcep.Message);
                return false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }
        
        //-----------------------------------------------------------------------------
        //
        // GetPrintImformation()
        //       - Get Print Data
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        //-----------------------------------------------------------------------------

        public static bool GetPrintInformation(string sLabelID, string sLotID, ref TRSNode out_node)
        {
            TRSNode in_node = new TRSNode("View_Label_Design_In");
            
            try
            {
                //ClearData('1')
                
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LABEL_ID", sLabelID.TrimEnd());
                in_node.AddString("LOT_ID", sLotID);

                if (MPCR.CallService("POP", "POP_View_Label_Design", in_node, ref out_node) == false)
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
        
        //-----------------------------------------------------------------------------
        //
        // ComPortOpen()
        //       - Com Port Open Funtion
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        //-----------------------------------------------------------------------------
        public static bool ComPortOpen(ref Rs232 aComPort, int aPort, int iBaudRate, int iParity, int iDataBit, int iStopBit)
        {
            
            try
            {
                //// Setup parameters
                Rs232 with_1 = aComPort;
                with_1.Port = aPort;
                with_1.BaudRate = iBaudRate;
                with_1.Parity = (Rs232.DataParity)iParity;
                with_1.DataBit = iDataBit;
                with_1.StopBit = (Rs232.DataStopBit)iStopBit;

                with_1.Timeout = 1500; //Timeout ¼³Á¤
                
                with_1.WorkingMode = (Rs232.Mode) Rs232.Mode.NonOverlapped;
                
                //// Initializes port
                aComPort.Open();
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                if (aComPort.IsOpen)
                    aComPort.Close();
                return false;
            }
        }
        
        //-----------------------------------------------------------------------------
        //
        // ComPortClose()
        //       - Com Port Close Funtion
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        //-----------------------------------------------------------------------------
        public static bool ComPortClose(Rs232 aComPort)
        {
            try
            {

                if (aComPort.IsOpen)
                    aComPort.Close();
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        //-----------------------------------------------------------------------------
        //
        // MakeZebraCommand()
        //       - Make Syntax of Zebra Printer
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        //-----------------------------------------------------------------------------
        public static bool MakeZebraCommand(string sPrintType, Rs232 aComPort, ref TRSNode out_node, out string[] PrintDataArray, bool PreViewFlag)//
        {
            
            int i;
            List<string> sList = new List<string>();
            string sCode;
            
            try
            {
                
                //MD : Media Darkness(-30~+30)
                //PR  : Print Speed(Default: A)
                //PO : Print Orientation(N: normal , I : Invert)
                //JM : Dots per Milimeter(Default : A)
                //LR : Label Reverse(Y or N)
                //LL : Label Length(Dots)
                //PW : Label Width(Dots)

                PrintDataArray = null;
                
                sCode = "^XA" + "^JMA";
                if (MPCF.ToDbl(out_node.GetString("RESOLUTION")) == 200)
                {
                    sCode += "^LL" + out_node.GetDouble("LABEL_HEIGHT") * MPGC.PRINT_200_DPM + "^PW" + out_node.GetDouble("LABEL_WIDTH") * MPGC.PRINT_200_DPM;
                }
                else if (MPCF.ToDbl(out_node.GetString("RESOLUTION")) == 300)
                {
                    sCode += "^LL" + out_node.GetDouble("LABEL_HEIGHT") * MPGC.PRINT_300_DPM + "^PW" + out_node.GetDouble("LABEL_WIDTH") * MPGC.PRINT_300_DPM;
                }
                sCode += "^MD" + out_node.GetInt("DARKNESS") + "^PR" + out_node.GetChar("PRINT_SPEED") + "^PO" + out_node.GetChar("INVERT") + "^LR" + out_node.GetChar("REVERSE") + "^LH" + out_node.GetDouble("ORIGIN_X") + "," + out_node.GetDouble("ORIGIN_Y");
                sList.Add(sCode);

                TRSNode item_list ;
                for(i = 0; i < out_node.GetList(0).Count; i++)
                {
                    item_list  = out_node.GetList(0)[i];

                    if (MPCF.Trim(item_list.GetChar("PRINT_FLAG")) == "Y")
                    {
                        switch (MPCF.Trim(item_list.GetString("TYPE")))
                        {
                            
                        case MPGC.POP_TYPE_TEXT:
                            sCode = "^FO" + item_list.GetInt("POSITION_X") + "," + item_list.GetInt("POSITION_Y") + "^A" + item_list.GetChar("FONT") + item_list.GetChar("ROTATE") + "," + item_list.GetInt("HEIGHT") + "," + item_list.GetInt("WIDTH");

                            if (MPCF.Trim(item_list.GetChar("REVERSE_FLAG")) == "Y")
                            {
                                sCode += "^FR";
                            }
                            sCode += "^FD" + item_list.GetString("DATA") + "^FS";
                            
                            sList.Add(sCode);
                            break;
                            
                        case MPGC.POP_TYPE_BARCODE:
                            
                            
                            sCode = "^FO" + item_list.GetInt("POSITION_X") + "," + item_list.GetInt("POSITION_Y");
                            
                            if (MPCF.Trim(item_list.GetChar("REVERSE_FLAG")) == "Y")
                            {
                                sCode += "^FR";
                            }
                            
                            switch (MPCF.Trim(item_list.GetChar("FONT")))
                            {
                            case MPGC.POP_BAR_FONT_128:

                                sCode += "^BY" + item_list.GetInt("WIDTH") + "," + item_list.GetInt("BAR_RATE") + "," + item_list.GetInt("HEIGHT") + "^BC" + item_list.GetChar("ROTATE") + "," + item_list.GetInt("HEIGHT") + "," + item_list.GetChar("BELOW_FLAG") + "," + item_list.GetChar("ABOVE_FLAG") + "," + item_list.GetChar("CHECK_DIGIT") + "^FD" + item_list.GetString("DATA") + "^FS";
                                break;
                                
                            case MPGC.POP_BAR_FONT_3OF9:

                                sCode += "^BY" + item_list.GetInt("WIDTH") + "," + item_list.GetInt("BAR_RATE") + "," + item_list.GetInt("HEIGHT") + "^B3" + item_list.GetChar("ROTATE") + "," + item_list.GetChar("CHECK_DIGIT") + "," + item_list.GetInt("HEIGHT") + "," + item_list.GetChar("BELOW_FLAG") + "," + item_list.GetChar("ABOVE_FLAG") + "^FD" + item_list.GetString("DATA") + "^FS";
                                break;
                                
                            case MPGC.POP_BAR_FONT_EAN_8:

                                sCode += "^BY" + item_list.GetInt("WIDTH") + "," + item_list.GetInt("BAR_RATE") + "," + item_list.GetInt("HEIGHT") + "^B8" + item_list.GetChar("ROTATE") + "," + item_list.GetInt("HEIGHT") + "," + item_list.GetChar("BELOW_FLAG") + "," + item_list.GetChar("ABOVE_FLAG") + "^FD" + item_list.GetString("DATA") + "^FS";
                                break;
                                
                            case MPGC.POP_BAR_FONT_UPC_E:

                                sCode += "^BY" + item_list.GetInt("WIDTH") + "," + item_list.GetInt("BAR_RATE") + "," + item_list.GetInt("HEIGHT") + "^B9" + item_list.GetChar("ROTATE") + "," + item_list.GetInt("HEIGHT") + "," + item_list.GetChar("BELOW_FLAG") + "," + item_list.GetChar("ABOVE_FLAG") + "," + item_list.GetChar("CHECK_DIGIT") + "^FD" + item_list.GetString("DATA") + "^FS";
                                break;
                                
                            case MPGC.POP_BAR_FONT_EAN_13:

                                sCode += "^BY" + item_list.GetInt("WIDTH") + "," + item_list.GetInt("BAR_RATE") + "," + item_list.GetInt("HEIGHT") + "^BE" + item_list.GetChar("ROTATE") + "," + item_list.GetInt("HEIGHT") + "," + item_list.GetChar("BELOW_FLAG") + "," + item_list.GetChar("ABOVE_FLAG") + "^FD" + item_list.GetString("DATA") + "^FS";
                                break;
                                
                            case MPGC.POP_BAR_FONT_UPC_A:

                                sCode += "^BY" + item_list.GetInt("WIDTH") + "," + item_list.GetInt("BAR_RATE") + "," + item_list.GetInt("HEIGHT") + "^BU" + item_list.GetChar("ROTATE") + "," + item_list.GetInt("HEIGHT") + "," + item_list.GetChar("BELOW_FLAG") + "," + item_list.GetChar("ABOVE_FLAG") + "," + item_list.GetChar("CHECK_DIGIT") + "^FD" + item_list.GetString("DATA") + "^FS";
                                break;
                            case MPGC.POP_BAR_FONT_PDF417:

                                sCode += "^BY" + item_list.GetInt("WIDTH") + "," + item_list.GetInt("BAR_RATE") + "," + item_list.GetInt("HEIGHT") + "^B7" + item_list.GetChar("ROTATE") + "," + item_list.GetChar("ECC_LEVEL") + "," + item_list.GetInt("COLUMN_COUNT") + "," + item_list.GetInt("ROW_COUNT") + "," + item_list.GetInt("TURN_FLAG") + "^FD" + item_list.GetString("DATA") + "^FS";
                                break;

                            case POP_BAR_FONT_DATA_MATRIX:

                                sCode += "^BX" + item_list.GetChar("ROTATE") + "," + item_list.GetInt("HEIGHT") + "," + item_list.GetInt("MAGNI_FACTOR") + "," + item_list.GetInt("COLUMN_COUNT") + "," + item_list.GetInt("ROW_COUNT") + "," + item_list.GetChar("MODEL") + "^FD" + item_list.GetString("DATA") + "^FS";
                                break;

                            //¼öÁ¤ ÇÊ¿ä Patrick
                            //case POP_BAR_FONT_QR:

                            //    sCode += "^BX" + item_list.GetChar("ROTATE") + "," + item_list.GetInt("HEIGHT") + "," + item_list.GetInt("MAGNI_FACTOR") + "," + item_list.GetInt("COLUMN_COUNT") + "," + item_list.GetInt("ROW_COUNT") + "," + item_list.GetChar("MODEL") + "^FD" + item_list.GetString("DATA") + "^FS";
                            //    break;
                            }

                            sList.Add(sCode);
                            break;
                            
                        case MPGC.POP_TYPE_IMAGE:
                            
                            sCode = "^FO" + item_list.GetInt("POSITION_X") + "," + item_list.GetInt("POSITION_Y") + "^XG" + item_list.GetString("DATA") + "," + item_list.GetInt("WIDTH") + "," + item_list.GetInt("HEIGHT") + "^FS";
                            
                            if (PreViewFlag == false)
                            {
                                if (DeleteDownloadImage(sPrintType, ref aComPort, item_list.GetString("DATA")) == false)
                                {
                                    return false;
                                }
                                if (DownloadImage(sPrintType, ref aComPort, item_list.GetString("DATA")) == false)
                                {
                                    return false;
                                }
                            }

                            sList.Add(sCode);
                            break;
                            
                        case MPGC.POP_TYPE_GRAPHIC:
                            
                            sCode = "^FO" + item_list.GetInt("POSITION_X") + "," + item_list.GetInt("POSITION_Y") + "^GB" + item_list.GetInt("WIDTH") + "," + item_list.GetInt("HEIGHT") + "," + item_list.GetInt("THICK");
                            if (MPCF.Trim(item_list.GetChar("REVERSE_FLAG")) == "Y")
                            {
                                sCode += ",W";
                            }
                            sCode += "^FS";

                            sList.Add(sCode);
                            break;
                            
                        }
                    }
                }

                sCode = "^PQ" + out_node.GetInt("PRINT_QTY") + "^XZ";
                sList.Add(sCode);
                
                PrintDataArray = new string[sList.Count];
                for(i = 0; i < sList.Count; i++)
                {
                    PrintDataArray[i] = sList[i];
                }

                return true;
            
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                PrintDataArray = null;
                return false;
            }
            
        }

        //-----------------------------------------------------------------------------
        //
        // MakeToshibaCommand()
        //       - Make Syntax of Toshiba Printer
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - string sPrintType           : type of print port
        //       - Rs232 aComPort              : comport 
        //       - ref TRSNode out_node        : out_node
        //       - out string[] PrintDataArray : array of print data
        //       - bool PreViewFlag            : flag of preview
        //
        //-----------------------------------------------------------------------------
        public static bool MakeToshibaCommand(string sPrintType, Rs232 aComPort, ref TRSNode out_node, out string[] PrintDataArray, bool PreViewFlag)//
        {

            int i;            
            //byte[] aryByte = null;
            List<byte> bList = new List<byte>();
            List<string> sList = new List<string>();
            string sCode;
            byte[] bt_buffer;
            TRSNode blob_out_node = new TRSNode("View_Image_Out");
            try
            {
                //D  : Label Definition                                          { D0508, 0760, 0468, 0820 [LF]  ( 1 is 0.1mm )
                //AX : Adjust Feed position, Cut position, Back Feed length      { AX; +020,+030,+01 |}
                //AY : Darkness                                                  { AY; -02, 0 |}                         
                
                PrintDataArray = null;
                
                sCode = "";

                if(out_node.GetString("TAG_MODE_FLAG").Equals("Y"))
                    sCode += "{ " + "D" + (out_node.GetDouble("PAGE_HEIGHT") * 10).ToString().PadLeft(4, '0') + ", " + (out_node.GetDouble("LABEL_WIDTH") * 10).ToString().PadLeft(4, '0') + ", " + (out_node.GetDouble("PAGE_WIDTH") * 10).ToString().PadLeft(4, '0');
                else
                    sCode += "{ " + "D" + (out_node.GetDouble("PAGE_HEIGHT") * 10).ToString().PadLeft(4, '0') + ", " + (out_node.GetDouble("LABEL_WIDTH") * 10).ToString().PadLeft(4, '0') + ", " + (out_node.GetDouble("LABEL_HEIGHT") * 10).ToString().PadLeft(4, '0') + ", " + (out_node.GetDouble("PAGE_WIDTH") * 10).ToString().PadLeft(4, '0');
                sCode += " |}";

                if(PreViewFlag == true)
                    sList.Add(sCode);
                else
                    bList.AddRange(Encoding.Default.GetBytes(sCode));
                
                sCode = "{ " + "AX; ";

                if (out_node.GetString("FEED_POSITION").Trim().Equals("") || out_node.GetString("FEED_POSITION").Length != 4)
                    sCode += "+000, ";
                else
                    sCode += out_node.GetString("FEED_POSITION").Substring(0, 1) + out_node.GetString("FEED_POSITION").Substring(1, out_node.GetString("FEED_POSITION").Length).PadLeft(3, '0') + ", ";

                if (out_node.GetString("CUT_POSITION").Trim().Equals("") || out_node.GetString("CUT_POSITION").Length != 4)
                    sCode += "+000, ";
                else
                    sCode += out_node.GetString("CUT_POSITION").Substring(0, 1) + out_node.GetString("CUT_POSITION").Substring(1, out_node.GetString("CUT_POSITION").Length).PadLeft(3, '0') + ", ";

                if (out_node.GetString("BACK_FEED_LENGTH").Trim().Equals("") || out_node.GetString("BACK_FEED_LENGTH").Length != 4)
                    sCode += "+00 |}";
                else
                    sCode += out_node.GetString("BACK_FEED_LENGTH").Substring(0, 1) + out_node.GetString("BACK_FEED_LENGTH").Substring(1, out_node.GetString("BACK_FEED_LENGTH").Length).PadLeft(2, '0') + " |}";
                if (PreViewFlag == true)
                    sList.Add(sCode);
                else
                    bList.AddRange(Encoding.Default.GetBytes(sCode));

                if (out_node.GetInt("DARKNESS") != 0)
                {
                    if (out_node.GetInt("DARKNESS") > 0)
                        sCode = "{ " + "AY; +" + out_node.GetInt("DARKNESS").ToString().Substring(1, 2).PadLeft(2, '0');                    
                    else
                        sCode = "{ " + "AY; -" + out_node.GetInt("DARKNESS").ToString().Substring(1, 2).PadLeft(2, '0');                    

                    //¿­Àü»ç or Á÷ºÐ»ç
                    if (out_node.GetString("PRINTER_MODE").Equals("T"))
                        sCode += " 0" + " |}";
                    else
                        sCode += " 1" + " |}";

                    if (PreViewFlag == true)
                        sList.Add(sCode);
                    else
                        bList.AddRange(Encoding.Default.GetBytes(sCode));
                }                

                sCode = "{ " + "C " + "|}";
                if (PreViewFlag == true)
                    sList.Add(sCode);
                else
                    bList.AddRange(Encoding.Default.GetBytes(sCode));

                sCode = "{ " + "T";
                if (out_node.GetString("SENSOR_TYPE").Trim().Equals("") || out_node.GetString("SENSOR_TYPE").Length != 1)
                    sCode += "11";
                else
                    sCode += out_node.GetString("SENSOR_TYPE").Trim() + "1";

                if (out_node.GetString("ISSUE_MODE").Trim().Equals("") || out_node.GetString("ISSUE_MODE").Length != 1)
                    sCode += "C";
                else
                    sCode += out_node.GetString("ISSUE_MODE").Trim();

                if (out_node.GetChar("PRINT_SPEED").ToString().Equals(""))
                    sCode += "3";
                else
                    sCode += out_node.GetChar("PRINT_SPEED");

                if (out_node.GetString("RIBON_OPTION").Trim().Equals("") || out_node.GetString("RIBON_OPTION").Length != 1)
                    sCode += "2";
                else
                    sCode += out_node.GetString("RIBON_OPTION").Trim();

                sCode += " |}";
                if (PreViewFlag == true)
                    sList.Add(sCode);
                else
                    bList.AddRange(Encoding.Default.GetBytes(sCode));

                TRSNode item_list;
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    item_list = out_node.GetList(0)[i];

                    if (MPCF.Trim(item_list.GetChar("PRINT_FLAG")) == "Y")
                    {
                        switch (MPCF.Trim(item_list.GetString("TYPE")))
                        {

                            case MPGC.POP_TYPE_TEXT:
                                sCode =  "{ " + "PV" + item_list.GetInt("SEQ_NUM").ToString().PadLeft(2, '0') + "; " + (item_list.GetInt("POSITION_X") * 10).ToString().PadLeft(4,'0') + ", ";
                                sCode += (item_list.GetInt("POSITION_Y") * 10).ToString().PadLeft(4, '0') + ", " + (item_list.GetInt("WIDTH") * 10).ToString().PadLeft(4,'0') + ", ";
                                sCode += (item_list.GetInt("HEIGHT") * 10).ToString().PadLeft(4,'0') + ", " + item_list.GetChar("FONT") + ", ";

                                if(item_list.GetChar("ROTATE").ToString().Equals(MPGC.POP_ROTATE_NORMAL))
                                    sCode += "00" + ", ";
                                else if(item_list.GetChar("ROTATE").ToString().Equals(MPGC.POP_ROTATE_ROTATED))
                                    sCode += "11" + ", ";
                                else if(item_list.GetChar("ROTATE").ToString().Equals(MPGC.POP_ROTATE_INVERTED))
                                    sCode += "22" + ", ";
                                else if(item_list.GetChar("ROTATE").ToString().Equals(MPGC.POP_ROTATE_BOTTOMUP))
                                    sCode += "33" + ", ";

                                if (MPCF.Trim(item_list.GetChar("REVERSE_FLAG")) == "Y")
                                    sCode += "W";
                                else
                                    sCode += "B";

                                sCode += "=" + item_list.GetString("DATA") + " |}";

                                if (PreViewFlag == true)
                                    sList.Add(sCode);
                                else
                                    bList.AddRange(Encoding.Default.GetBytes(sCode));
                                break;

                            case MPGC.POP_TYPE_BARCODE:

                                sCode =  "{ " + "XB" + item_list.GetInt("SEQ_NUM").ToString().PadLeft(2, '0') + "; " + (item_list.GetInt("POSITION_X") * 10).ToString().PadLeft(4,'0') + ", ";
                                sCode += (item_list.GetInt("POSITION_Y") * 10).ToString().PadLeft(4, '0') + ", ";

                                switch (MPCF.Trim(item_list.GetChar("FONT")))
                                {
                                    case MPGC.POP_BAR_FONT_128:

                                        sCode += "A, ";

                                        if(item_list.GetChar("CHECK_DIGIT").ToString().Equals("Y"))
                                            sCode += "2, ";
                                        else
                                            sCode += "1, ";

                                        if (item_list.GetString("1_CELL_WIDTH").Trim().Equals("") || item_list.GetString("1_CELL_WIDTH").Trim().Equals("0"))
                                            sCode += "03, ";
                                        else
                                            sCode += item_list.GetString("1_CELL_WIDTH").Trim().PadLeft(2, '0') + ", ";                                        

                                        if (item_list.GetChar("ROTATE").ToString().Equals(MPGC.POP_ROTATE_NORMAL))
                                            sCode += "0" + ", ";
                                        else if (item_list.GetChar("ROTATE").ToString().Equals(MPGC.POP_ROTATE_ROTATED))
                                            sCode += "1" + ", ";
                                        else if (item_list.GetChar("ROTATE").ToString().Equals(MPGC.POP_ROTATE_INVERTED))
                                            sCode += "2" + ", ";
                                        else if (item_list.GetChar("ROTATE").ToString().Equals(MPGC.POP_ROTATE_BOTTOMUP))
                                            sCode += "3" + ", ";

                                        sCode += (item_list.GetInt("HEIGHT") * 10).ToString().PadLeft(4,'0');

                                        if (item_list.GetChar("BELOW_FLAG").ToString().Equals("Y"))
                                            sCode += ", +0000000000, 1, 00, N";

                                        sCode += "=" + item_list.GetString("DATA") + " |}";
                                        break;                                        

                                    case MPGC.POP_BAR_FONT_3OF9:

                                        sCode += "3, ";

                                        if(item_list.GetChar("CHECK_DIGIT").ToString().Equals("Y"))
                                            sCode += "2, ";
                                        else
                                            sCode += "1, ";

                                        if (item_list.GetString("NAR_BAR_WIDTH").Trim().Equals("") || item_list.GetString("NAR_BAR_WIDTH").Trim().Equals("0"))
                                            sCode += "03, ";
                                        else
                                            sCode += item_list.GetString("NAR_BAR_WIDTH").Trim().PadLeft(2,'0') + ", ";

                                        if (item_list.GetString("NAR_SPACE_WIDTH").Trim().Equals("") || item_list.GetString("NAR_SPACE_WIDTH").Trim().Equals("0"))
                                            sCode += "03, ";
                                        else
                                            sCode += item_list.GetString("NAR_SPACE_WIDTH").Trim().PadLeft(2, '0') + ", ";

                                        if (item_list.GetString("WID_BAR_WIDTH").Trim().Equals("") || item_list.GetString("WID_BAR_WIDTH").Trim().Equals("0"))
                                            sCode += "08, ";
                                        else
                                            sCode += item_list.GetString("WID_BAR_WIDTH").Trim().PadLeft(2, '0') + ", ";

                                        if (item_list.GetString("WID_SPACE_WIDTH").Trim().Equals("") || item_list.GetString("WID_SPACE_WIDTH").Trim().Equals("0"))
                                            sCode += "08, ";
                                        else
                                            sCode += item_list.GetString("WID_SPACE_WIDTH").Trim().PadLeft(2, '0') + ", ";

                                        if (item_list.GetString("CHAR_SPACE_WIDTH").Trim().Equals("") || item_list.GetString("CHAR_SPACE_WIDTH").Trim().Equals("0"))
                                            sCode += "03, ";
                                        else
                                            sCode += item_list.GetString("CHAR_SPACE_WIDTH").Trim().PadLeft(2, '0') + ", ";                                        

                                        if (item_list.GetChar("ROTATE").ToString().Equals(MPGC.POP_ROTATE_NORMAL))
                                            sCode += "0" + ", ";
                                        else if (item_list.GetChar("ROTATE").ToString().Equals(MPGC.POP_ROTATE_ROTATED))
                                            sCode += "1" + ", ";
                                        else if (item_list.GetChar("ROTATE").ToString().Equals(MPGC.POP_ROTATE_INVERTED))
                                            sCode += "2" + ", ";
                                        else if (item_list.GetChar("ROTATE").ToString().Equals(MPGC.POP_ROTATE_BOTTOMUP))
                                            sCode += "3" + ", ";

                                        sCode += (item_list.GetInt("HEIGHT") * 10).ToString().PadLeft(4,'0');

                                        if (item_list.GetChar("BELOW_FLAG").ToString().Equals("Y"))
                                            sCode += ", +0000000000, 1, 00, N";

                                        sCode += "=" + item_list.GetString("DATA") + " |}";
                                        break;

                                    case POP_BAR_FONT_DATA_MATRIX:

                                        sCode += "Q, ";
                                        
                                        //ECC Type
                                        //0 : (00: ECC0)
                                        //1 : (01: ECC50)
                                        //2 : (04: ECC50)
                                        //3 : (05: ECC50)
                                        //4 : (06: ECC80)
                                        //5 : (07: ECC80)
                                        //6 : (08: ECC80)
                                        //7 : (09: ECC100)
                                        //8 : (10: ECC100)
                                        //9 : (11: ECC140)
                                        //A : (12: ECC140)
                                        //B : (13: ECC140)
                                        //C : (14: ECC140)
                                        //D : (20: ECC200)
                                        if (item_list.GetChar("ECC_LEVEL").ToString().Equals(""))
                                            sCode += "20, ";
                                        else if (item_list.GetChar("ECC_LEVEL").ToString().Equals("0"))                                        
                                            sCode += "00, ";
                                        else if (item_list.GetChar("ECC_LEVEL").ToString().Equals("1"))
                                            sCode += "01, ";
                                        else if (item_list.GetChar("ECC_LEVEL").ToString().Equals("2"))
                                            sCode += "04, ";
                                        else if (item_list.GetChar("ECC_LEVEL").ToString().Equals("3"))
                                            sCode += "05, ";
                                        else if (item_list.GetChar("ECC_LEVEL").ToString().Equals("4"))
                                            sCode += "06, ";
                                        else if (item_list.GetChar("ECC_LEVEL").ToString().Equals("5"))
                                            sCode += "07, ";
                                        else if (item_list.GetChar("ECC_LEVEL").ToString().Equals("6"))
                                            sCode += "08, ";
                                        else if (item_list.GetChar("ECC_LEVEL").ToString().Equals("7"))
                                            sCode += "09, ";
                                        else if (item_list.GetChar("ECC_LEVEL").ToString().Equals("8"))
                                            sCode += "10, ";
                                        else if (item_list.GetChar("ECC_LEVEL").ToString().Equals("9"))
                                            sCode += "11, ";
                                        else if (item_list.GetChar("ECC_LEVEL").ToString().Equals("A"))
                                            sCode += "12, ";
                                        else if (item_list.GetChar("ECC_LEVEL").ToString().Equals("B"))
                                            sCode += "13, ";
                                        else if (item_list.GetChar("ECC_LEVEL").ToString().Equals("C"))
                                            sCode += "14, ";
                                        else if (item_list.GetChar("ECC_LEVEL").ToString().Equals("D"))
                                            sCode += "20, ";

                                        if (item_list.GetString("1_CELL_WIDTH").Trim().Equals("") || item_list.GetString("1_CELL_WIDTH").Trim().Equals("0"))
                                            sCode += "03, ";
                                        else
                                            sCode += item_list.GetString("1_CELL_WIDTH").Trim().PadLeft(2, '0') + ", ";

                                        //Format ID
                                        if (item_list.GetChar("MODEL").ToString().Equals(""))
                                            sCode += "01" + ", ";
                                        else
                                            sCode += item_list.GetChar("MODEL").ToString().PadLeft(2, '0') + ", ";

                                        if (item_list.GetChar("ROTATE").ToString().Equals(MPGC.POP_ROTATE_NORMAL))
                                            sCode += "0";
                                        else if (item_list.GetChar("ROTATE").ToString().Equals(MPGC.POP_ROTATE_ROTATED))
                                            sCode += "1";
                                        else if (item_list.GetChar("ROTATE").ToString().Equals(MPGC.POP_ROTATE_INVERTED))
                                            sCode += "2";
                                        else if (item_list.GetChar("ROTATE").ToString().Equals(MPGC.POP_ROTATE_BOTTOMUP))
                                            sCode += "3";                                        

                                        sCode += "=" + item_list.GetString("DATA") + " |}";
                                        break;                                                                                

                                    case POP_BAR_FONT_QR:

                                        sCode += "T, M, ";
                                                                                
                                        if (item_list.GetString("1_CELL_WIDTH").Trim().Equals("") || item_list.GetString("1_CELL_WIDTH").Trim().Equals("0"))
                                            sCode += "03, A, ";
                                        else
                                            sCode += item_list.GetString("1_CELL_WIDTH").Trim().PadLeft(2, '0') + ", A, ";                                        

                                        if (item_list.GetChar("ROTATE").ToString().Equals(MPGC.POP_ROTATE_NORMAL))
                                            sCode += "0";
                                        else if (item_list.GetChar("ROTATE").ToString().Equals(MPGC.POP_ROTATE_ROTATED))
                                            sCode += "1";
                                        else if (item_list.GetChar("ROTATE").ToString().Equals(MPGC.POP_ROTATE_INVERTED))
                                            sCode += "2";
                                        else if (item_list.GetChar("ROTATE").ToString().Equals(MPGC.POP_ROTATE_BOTTOMUP))
                                            sCode += "3";                                        

                                        sCode += "=" + item_list.GetString("DATA") + " |}";
                                        break;           

                                    case MPGC.POP_BAR_FONT_EAN_8:
                                        
                                        break;

                                    case MPGC.POP_BAR_FONT_UPC_E:
                                        
                                        break;

                                    case MPGC.POP_BAR_FONT_EAN_13:
                                        
                                        break;

                                    case MPGC.POP_BAR_FONT_UPC_A:
                                        
                                        break;
                                    case MPGC.POP_BAR_FONT_PDF417:
                                        
                                        break;                                    
                                }

                                if (PreViewFlag == true)
                                    sList.Add(sCode);
                                else
                                    bList.AddRange(Encoding.Default.GetBytes(sCode));
                                break;

                            case MPGC.POP_TYPE_IMAGE:
                                //¼öÁ¤ ÇÊ¿ä
                                sCode = "{ " + "SG; " + (item_list.GetInt("POSITION_X") * 10).ToString().PadLeft(4, '0') + ", " + (item_list.GetInt("POSITION_Y") * 10).ToString().PadLeft(4, '0') + ", 0000, 0000, 2, ";
                                if (PreViewFlag == true)
                                {
                                    sCode += "|}";
                                    sList.Add(sCode);
                                }
                                else
                                {
                                    bList.AddRange(Encoding.Default.GetBytes(sCode));
                                }
                                                               
                                if (PreViewFlag == false)
                                {                                    
                                    if (DownloadImageForTPCL(item_list.GetString("DATA"), ref blob_out_node) == false)
                                    {
                                        return false;
                                    }

                                    // Image File                                    
                                    if ((bt_buffer = blob_out_node.GetBlob(MPGC.MP_BIN_DATA_1)) != null)
                                    {
                                        bList.AddRange(bt_buffer);
                                    }

                                    sCode = "|}";
                                    bList.AddRange(Encoding.Default.GetBytes(sCode));
                                }                                                                
                                
                                break;

                            case MPGC.POP_TYPE_GRAPHIC:
                                sCode = "{ " + "LC; " + (item_list.GetInt("POSITION_X") * 10).ToString().PadLeft(4, '0') + ", " + (item_list.GetInt("POSITION_Y") * 10).ToString().PadLeft(4, '0') + ", ";
                                sCode += (item_list.GetInt("POSITION_X") * 10 + item_list.GetInt("WIDTH") * 10).ToString().PadLeft(4, '0') + ", " + (item_list.GetInt("POSITION_Y") * 10 + item_list.GetInt("HEIGHT") * 10).ToString().PadLeft(4, '0') + ", ";

                                //If 0 is line , else retangle
                                if (item_list.GetInt("WIDTH") == 0 || item_list.GetInt("HEIGHT") == 0)
                                    sCode += "0" + ", ";
                                else
                                    sCode += "1" + ", ";

                                //0.1mm of unit 1
                                sCode += item_list.GetInt("THICK");
                                sCode += " |}";
                                if (PreViewFlag == true)
                                    sList.Add(sCode);
                                else
                                    bList.AddRange(Encoding.Default.GetBytes(sCode));
                                break;                            
                        }
                    }
                }

                sCode = "{ " + "XS; I, " + out_node.GetInt("PRINT_QTY").ToString().PadLeft(4, '0') + ", ";

                if (out_node.GetString("CUT_INTERVAL").Trim().Equals(""))
                    sCode += "001";
                else
                    sCode += out_node.GetString("CUT_INTERVAL").Trim().ToString().PadLeft(3, '0');

                if (out_node.GetString("SENSOR_TYPE").Trim().Equals(""))
                    sCode += "1";
                else
                    sCode += out_node.GetString("SENSOR_TYPE").Trim();

                if (out_node.GetString("ISSUE_MODE").Trim().Equals(""))
                    sCode += "C";
                else
                    sCode += out_node.GetString("ISSUE_MODE").Trim();

                if (out_node.GetChar("PRINT_SPEED").ToString().Equals(""))
                    sCode += "3";
                else
                    sCode += out_node.GetChar("PRINT_SPEED");

                if (out_node.GetString("RIBON_OPTION").Trim().Equals(""))
                    sCode += "2";
                else
                    sCode += out_node.GetString("RIBON_OPTION").Trim();

                if (out_node.GetString("TAG_ROTATION").Trim().Equals(""))
                    sCode += "01";
                else
                    sCode += out_node.GetString("TAG_ROTATION").Trim() + "1";

                sCode +=" |}";
                if (PreViewFlag == true)
                {
                    sList.Add(sCode);
                    PrintDataArray = new string[sList.Count];
                    for (i = 0; i < sList.Count; i++)
                    {
                        PrintDataArray[i] = sList[i];
                    }
                }
                else
                {
                    bList.AddRange(Encoding.Default.GetBytes(sCode));

                    if (Send_Data_To_Byte(sPrintType, aComPort, bList.ToArray()) == false)
                    {
                        return false;
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                PrintDataArray = null;
                return false;
            }

        }

        //-----------------------------------------------------------------------------
        //
        // ExcutePrint()
        //       - Print Barcode
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        //-----------------------------------------------------------------------------
        public static bool ExcutePrint(string sPrintType, Rs232 aComPort, ref TRSNode out_node) //
        {                        
            try
            {
                if (ExcutePrint(sPrintType, aComPort, ref out_node, "") == false)
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

        //-----------------------------------------------------------------------------
        //
        // ExcutePrint()
        //       - Print Barcode
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        //-----------------------------------------------------------------------------
        public static bool ExcutePrint(string sPrintType, Rs232 aComPort, ref TRSNode out_node, string sPrintModel) //
        {

            string[] PrintDataArray;
            string sPrintString = "";            
            int i;
            try
            {
                if (sPrintType.Substring(0, 3) == MPGC.POP_PRINT_PORT_COM)
                {
                    int iPort;

                    iPort = MPCF.ToInt(sPrintType.Substring(3, 1));

                    if (ComPortOpen(ref aComPort, iPort, 9600, 0, 8, 1) == false)
                    {
                        return false;
                    }
                }

                if (PrtStatusCheck(sPrintType, ref aComPort) == false)
                {
                    if (aComPort.IsOpen)
                        aComPort.Close();
                    return false;
                }

                //Added by patrick to tpcl(toshiba print command type)
                //In case of toshiba tpcl, else convert zebra code
                if (sPrintModel.Equals(POP_PRINT_TYPE_TPCL))
                {
                    //³»ºÎ¿¡¼­ Byte Ä¡È¯ ÇÏ¿© sending to print Ã³¸®
                    if (MakeToshibaCommand(sPrintType, aComPort, ref out_node, out PrintDataArray, false) == false)
                    {

                        return false;
                    }
                }
                else
                {
                    if (MakeZebraCommand(sPrintType, aComPort, ref out_node, out PrintDataArray, false) == false)
                    {

                        return false;
                    }                    

                    for (i = 0; i <= (PrintDataArray.Length - 1); i++)
                    {
                        sPrintString += PrintDataArray[i];
                    }

                    if (Send_Data(sPrintType, aComPort, sPrintString) == false)
                    {
                        return false;
                    }
                }                

                if (sPrintType.Substring(0, 3) == MPGC.POP_PRINT_PORT_COM)
                {

                    ComPortClose(aComPort);

                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        } 

        //-----------------------------------------------------------------------------
        //
        // ExcutePrintCommand()
        //       - Print Barcode
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        //-----------------------------------------------------------------------------
        public static bool ExcutePrintCommand(string sPrintType, Rs232 aComPort, string LabelCommand, bool bRemotePrinter, string sPrintIP, string sUser, string sPassword)
        {

            string[] PrintDataArray;
            string LabelScript = @"\LScript.txt";
            string LabelData = @"\LData.txt";
            string path = Directory.GetCurrentDirectory();

            string ScriptFileName;
            string DataFileName;
            string command;
            string sPrintString = "";

            int i;
            try
            {
                if (bRemotePrinter == true)
                {
                    ScriptFileName = path + LabelScript;
                    DataFileName = path + LabelData;

                    // Delete the file if it exists.
                    if (File.Exists(ScriptFileName))
                    {
                        File.Delete(ScriptFileName);
                    }

                    using (StreamWriter sw = new StreamWriter(ScriptFileName))
                    {
                        sw.WriteLine("open {0}", sPrintIP);
                        sw.WriteLine("{0}", sUser);
                        sw.WriteLine("{0}", sPassword);
                        sw.WriteLine("put \"{0}\"", DataFileName);
                        sw.WriteLine("bye");
                        sw.Close();
                    }

                    // Delete the file if it exists.
                    if (File.Exists(DataFileName))
                    {
                        File.Delete(DataFileName);
                    }

                    using (StreamWriter sw = new StreamWriter(DataFileName))
                    {
                        sw.WriteLine("{0}", LabelCommand);
                        sw.Close();
                    }

                    command = "ftp";

                    Process process = new Process();
                    process.EnableRaisingEvents = false;
                    process.StartInfo.CreateNoWindow = false;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.StartInfo.FileName = command;
                    process.StartInfo.Arguments = "-s:\"" + ScriptFileName + "\"";

                    if (process.Start() == false)
                    {
                        MessageBox.Show("Error send label code to remote printer.");
                    }
                }
                else
                {
                    if (sPrintType.Substring(0, 3) == MPGC.POP_PRINT_PORT_COM)
                    {
                        int iPort;

                        iPort = MPCF.ToInt(sPrintType.Substring(3, 1));

                        if (ComPortOpen(ref aComPort, iPort, 9600, 0, 8, 1) == false)
                        {
                            return false;
                        }

                    }

                    PrintDataArray = null;
                    PrintDataArray = new string[1];
                    PrintDataArray[0] = LabelCommand;

                    if (PrtStatusCheck(sPrintType, ref aComPort) == false)
                    {
                        if (aComPort.IsOpen)
                            aComPort.Close();
                        return false;
                    }
                    
                    for (i = 0; i <= (PrintDataArray.Length - 1); i++)
                    {
                        sPrintString += PrintDataArray[i];
                    }                                                        

                    if (Send_Data(sPrintType, aComPort, sPrintString) == false)
                    {
                        return false;
                    }

                    if (sPrintType.Substring(0, 3) == MPGC.POP_PRINT_PORT_COM)
                    {

                        ComPortClose(aComPort);

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

        //
        // Delete_Prev_Format()
        //       - Delete Previous Format
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public static bool Delete_Prev_Format(string sPrintType, Rs232 aComPort)
        {
            string sData;
            ////* ^EF -- Erase all previously stored formats *//
            sData = "^XA^EF^FS^XZ";
            Send_Data(sPrintType, aComPort, sData);
            
            Thread.Sleep(100);
            return true;
            
        }

        //-----------------------------------------------------------------------------
        //
        // DeleteDownloadImage()
        //       - Delete DownLoad Image In Printer
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        //-----------------------------------------------------------------------------
        public static bool DeleteDownloadImage(string sPrintType, ref Rs232 aComPort, string sImage)
        {
            string Temp_Syntax;
            
            Temp_Syntax = "^XA^IDR:" + sImage.Trim() + "^XZ";
            
            Send_Data(sPrintType, aComPort, Temp_Syntax);
            
            return true;
            
        }


        //-----------------------------------------------------------------------------
        //
        // DownloadImage()
        //       - DownLoad Image to Printer
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        //-----------------------------------------------------------------------------
        public static bool DownloadImage(string sPrintType, ref Rs232 aComPort, string sImage)
        {
            
            int i;
            int j;

            TRSNode in_node = new TRSNode("View_Image_In");
            TRSNode out_node = new TRSNode("View_Image_Out");
            TRSNode item_list;
            
            string aData = string.Empty;
            string TempData;
            int TempLen;
            bool ZeroFg;
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("IMAGE_ID", sImage.Trim());

                if (MPCR.CallService("POP", "POP_View_Image", in_node, ref out_node) == false)
                {
                    return false;
                }


                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    item_list = out_node.GetList(0)[i];
                    //Send_Data(sPrintType, aComPort, View_Image_Out.item_list[i].image_data)
                    ZeroFg = false;
                    TempData = MPCF.Trim(item_list.GetString("IMAGE_DATA"));
                    TempLen = TempData.Length;
                    
                    for (j = TempLen; j >= 1; j--)
                    {
                        
                        if (TempData.Substring(j - 1, 1) != "0")
                        {
                            if (j < TempLen)
                            {
                                TempData = TempData.Substring(0, j) + ",";
                            }
                            ZeroFg = true;
                            break;
                        }
                        
                    }
                    
                    if (ZeroFg)
                    {
                        aData = aData + TempData;
                    }
                    else
                    {
                        aData = aData + ",";
                    }
                    
                }
                
                Send_Data(sPrintType, aComPort, aData);
                
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }

        //-----------------------------------------------------------------------------
        //
        // DownloadImageForTPCL()
        //       - DownLoad Image file to Printer
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - string  : image id
        //       - TRSNode : out_node of viewing image
        //
        //-----------------------------------------------------------------------------
        public static bool DownloadImageForTPCL(string sImage, ref TRSNode out_node)
        {
            TRSNode in_node = new TRSNode("View_Image_In");            

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("IMAGE_ID", sImage.Trim());

                if (MPCR.CallService("POP", "POP_View_Image", in_node, ref out_node) == false)
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

        // ÇÁ¸°ÅÍ »óÅÂ È®ÀÎ
        public static bool PrtStatusCheck(string sPrintType, ref Rs232 aComPort)
        {
            bool returnValue;
            
            DateTime d_StartTime;
            bool b_TimeOut;
            object v_RecvMessage;
            string s_PrtErrMsg;
            string sData;

            if (sPrintType.Substring(0, 3) == MPGC.POP_PRINT_PORT_COM)
            {
                //Port·Î ºÎÅÍ Message Read Áß Timeout ¹ß»ýÇÏ¿©, ÀÓ½Ã ÁÖ¼®Ã³¸®ÇÔ(20121027 lakekim)
                return true;

                sData = "~HS" + (char)MPGC.CR;

                Send_Data(sPrintType, aComPort, sData);

                d_StartTime = DateTime.Now;
                b_TimeOut = true;
                MPGC.s_PrtStatus = "";

                // ÇÁ¸°ÅÍ»óÅÂ°ªÀÌ ¸ðµÎ µé¾î¿Ã¶§±îÁö±â´Ù¸².( TimeOut 5Sec)
                do
                {
                    //If (Format(Now - d_StartTime, "ss") <= s_TimeOut) Then
                    if (((TimeSpan)DateTime.Now.Subtract(d_StartTime)).Seconds <= MPCF.ToInt(MPGC.s_TimeOut))
                    {
                        aComPort.Read(2);
                        v_RecvMessage = aComPort.InputStreamString;
                        if (ReceMessage(MPCF.Trim(v_RecvMessage)))
                        {
                            b_TimeOut = false;
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                returnValue = false;

                if (b_TimeOut) // ì§€?°ì‹œê°?ì´ˆê³¼??
                {
                    Console.Beep();
                    MessageBox.Show("ÇÁ¸°ÅÍ°¡ ²¨Á® ÀÖ°Å³ª Åë½Å ÄÉÀÌºíÀÌ ºüÁø°Í °°½À´Ï´Ù.");

                }
                else
                {

                    s_PrtErrMsg = "";
                    if (MPGC.s_PrtStatus.Substring(5, 1) == "1") //
                    {
                        Console.Beep();
                        s_PrtErrMsg = s_PrtErrMsg + "ÇÁ¸°ÅÍ¿¡ ¿ëÁö(Label)ÀÌ ¾ø½À´Ï´Ù." + (char)MPGC.CR;
                    }

                    if (MPGC.s_PrtStatus.Substring(7, 1) == "1")
                    {
                        Console.Beep();
                        s_PrtErrMsg = s_PrtErrMsg + "ÁßÁö·¥ÇÁ(Pause-lamp)°¡ µé¾î¿Í ÀÖ½À´Ï´Ù." + (char)MPGC.CR;
                    }

                    if (MPCF.ToDbl(MPGC.s_PrtStatus.Substring(14, 3)) >= MPGC.i_BufFull)
                    {
                        Console.Beep();
                        Thread.Sleep(5000); // Receive Buffer Full ¹æÁö¿ë 5ÃÊ ½Ã°£Áö¿¬.
                    }

                    if (MPGC.s_PrtStatus.Substring(28, 1) == "1")
                    {
                        Console.Beep();
                        s_PrtErrMsg = s_PrtErrMsg + "ÇÁ¸°ÅÍ ¹öÆÛ(Buffer)°¡ °¡µæÂ÷ ÀÖ½À´Ï´Ù." + (char)MPGC.CR;
                    }
                    if (MPGC.s_PrtStatus.Substring(41, 1) == "1")
                    {
                        Console.Beep();
                        s_PrtErrMsg = s_PrtErrMsg + "ÇÁ¸°ÅÍ Çìµå(Head)°¡ ¿Ã·ÁÁ® ÀÖ½À´Ï´Ù." + (char)MPGC.CR;
                    }
                    if (MPGC.s_PrtStatus.Substring(43, 1) == "1")
                    {
                        Console.Beep();
                        s_PrtErrMsg = s_PrtErrMsg + "¸®º»(Ribbon)ÀÌ ¾ø½À´Ï´Ù." + (char)MPGC.CR;
                    }

                    if (s_PrtErrMsg.Length > 0)
                    {
                        Console.Beep();
                        MPCF.ShowMsgBox(s_PrtErrMsg);
                    }
                    else
                    {
                        returnValue = true;
                    }

                }

                return returnValue;
            }
            else if (sPrintType.Substring(0, 3) == POP_PRINT_PORT_SPOOL)
            {
                System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();

                pd.PrinterSettings.PrinterName = sPrinterName;

                if (pd.PrinterSettings.IsValid == false)
                {
                    MPCF.ShowMsgBox("Printer " + sPrinterName + "is invalid.");
                    return false;
                } 
            }

            return true;
        }

        // ÇÁ¸°ÅÍ »óÅÂ°ª ¹ÞÀ½.
        public static bool ReceMessage(string aMessage)
        {
            bool returnValue;
            
            int i;
            int Count;
            
            if (aMessage.IndexOf(Convert.ToString(MPGC.STX)) >= 0)
            {
                MPGC.b_InputSTX = true;
                MPGC.s_PrtStatus = MPGC.s_PrtStatus + aMessage;
            }
            else if (MPGC.b_InputSTX)
            {
                if (aMessage.IndexOf(Convert.ToString(MPGC.ETX)) >= 0)
                {
                    MPGC.b_InputSTX = false;
                    MPGC.s_PrtStatus = MPGC.s_PrtStatus + aMessage;
                }
                else
                {
                    MPGC.s_PrtStatus = MPGC.s_PrtStatus + aMessage;
                }
            }

            // ÇÁ¸°ÅÍ¿¡¼­ 3°³ÀÇ »óÅÂ°ªÀÌ ¸ðµÎ µé¾î¿Ô´ÂÁö È®ÀÎ ¹× ½Ã°£Áö¿¬.
            i = 0;
            Count = 0;
            returnValue = false;
            while (i >= 0)
            {
                i = MPGC.s_PrtStatus.IndexOf(Convert.ToString(MPGC.ETX), i);
                if (i >= 0)
                {
                    i++;
                    Count++;
                    if (Count == 3)
                    {
                        returnValue = true;
                        break;
                    }
                }
            }
            
            return returnValue;
        }

    }
//#End If
}
