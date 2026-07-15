using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Management;

namespace SOI.OIFrx
{
    public class clsPrinter
    {
        #region " Variables "

        private PPrinter pPrinter;
        private NPrinter nPrinter;

        #endregion

        // 현재 Local PC에 등록되어 있는 Com 포트 리스트를 반환
        public static List<string> GetPortList()
        {
            List<string> list = new List<string>();

            try
            {
                //foreach (string portName in SerialPort.GetPortNames())
                //{
                //    list.Add(portName);
                //}
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\WMI",
                    "SELECT * FROM MSSerial_PortName");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("MSSerial_PortName instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("InstanceName: {0}", queryObj["InstanceName"]);

                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("MSSerial_PortName instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("PortName: {0}", queryObj["PortName"]);

                    list.Add(queryObj["PortName"].ToString());

                    //If the serial port's instance name contains USB 
                    //it must be a USB to serial device
                    if (queryObj["InstanceName"].ToString().Contains("USB"))
                    {
                        Console.WriteLine(queryObj["PortName"] + "is a USB to SERIAL adapter/converter");
                    }
                }

                return list;
            }
            catch (ManagementException e)
            {
                Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
                return null;
            }
        }

        // 현재 Local PC에 등록되어 있는 프린터 리스트를 반환
        // Printer 변수에는 해당 프린터의 모든 정보가 있음, 다른 정보가 필요할 경우, 응용 가능              
        public static List<string> GetPrinterList()
        {
            List<string> list = new List<string>();

            try
            {
                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    list.Add(printer);
                }

                //string query = string.Format("SELECT * from Win32_Printer");

                //ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                //ManagementObjectCollection PrinterList = searcher.Get();

                //foreach (ManagementObject Printer in PrinterList)
                //{
                //    list.Add((string)Printer.GetPropertyValue("DeviceID"));
                //}

                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Label Print
        /// </summary>
        /// <param name="printerName">사용할 프린터 이름</param>
        /// <param name="code">출력할 바코드 정보</param>
        /// <param name="copy">출력할 장수</param>
        /// <returns></returns>
        public bool Print(string printerName,
                          string printerPort,
                          string remoteAddress,
                          string userName,
                          string password,
                          string code,
                          int copy,
                          List<string> imageData)
        {
            if (printerName != null && printerName != "")
            {
                return PrintByName(printerName, code, copy, imageData);
            }
            else if (printerPort != null && printerPort != "")
            {
                return PrintByPort(printerPort, code, copy, imageData);
            }
            //else if (remoteAddress != null && remoteAddress != "")
            //{
            //    return PrintByIp(remoteAddress, userName, password, code, copy);
            //}
            else
            {
                throw new SystemException("Does not support print type. Please check the print options.");
            }
        }

        /// <summary>
        /// OS에 설치된 프린터의 이름으로 라벨을 출력
        /// </summary>
        /// <param name="printerName">사용할 프린터 이름</param>
        /// <param name="code">출력할 바코드 코드</param>
        /// <param name="copy">출력할 장수</param>
        /// <param name="imageData">이미지 데이터 - Base64로 인코딩된 문자열 리스트</param>
        /// <returns></returns>
        public bool PrintByName(string printerName, string code, int copy, List<string> imageData)
        {
            if (nPrinter == null) nPrinter = new NPrinter();

            try
            {
                if (nPrinter.Print(printerName, code, copy, imageData) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetPortOption(string port, int baudRate, Parity parity, int dataBits, StopBits stopBits, Handshake handshake)
        {
            if (pPrinter == null) pPrinter = new PPrinter();

            pPrinter.SetComMode(port, baudRate, parity, dataBits, stopBits, handshake);
        }

        /// <summary>
        /// COM 포트를 통해 연결된 프린터로 라벨을 출력
        /// </summary>
        /// <param name="printPort">사용할 프린터 포트</param>
        /// <param name="code">출력할 바코드 코드</param>
        /// <param name="copy">출력할 장수</param>
        /// <param name="imageData">이미지 데이터 - Base64로 인코딩된 문자열 리스트</param>
        /// <returns></returns>
        public bool PrintByPort(string printerPort, string code, int copy, List<string> imageData)
        {
            if (pPrinter == null) pPrinter = new PPrinter();

            try
            {
                if (pPrinter.Print(printerPort, code, copy, imageData) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Label Print
        /// </summary>
        /// <param name="remoteAddress">사용할 프린터 IP</param>
        /// <param name="userName">IP의 사용자 이름</param>
        /// <param name="password">IP의 사용자 비밀번호</param>
        /// <param name="code">출력할 바코드 정보</param>
        /// <param name="copy">출력할 장수</param>
        /// <returns></returns>
        //public bool PrintByIp(string remoteAddress, string userName, string password, string code, int copy)
        //{
        //    try
        //    {
        //        do
        //        {
        //            if (PPrinter.SendPrintCommandByIp(remoteAddress, userName, password, code) == false)
        //            {
        //                return false;
        //            }
        //            copy--;
        //        } while (copy > 0);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }

    // Printer by Port
    public sealed class PPrinter
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

        public const int INVALID_HANDLE_VALUE = -1;
        //UPGRADE_WARNING: Structure SECURITY_ATTRIBUTES may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1050"'
        //[DllImport("kernel32",EntryPoint="CreateFileA", ExactSpelling=true, CharSet=CharSet.Ansi, SetLastError=true)]
        //public static extern IntPtr CreateFile(string lpFileName, int dwDesiredAccess, int dwShareMode, ref SECURITY_ATTRIBUTES lpSecurityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes, int hTemplateFile);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern Microsoft.Win32.SafeHandles.SafeFileHandle CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport("kernel32", EntryPoint = "CloseHandle", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
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

        private const int RECONNECT_LIMIT = 100;

        #endregion

        #region "Variable Definition"

        private static SerialPort rsComPort;
        private static int i_reconnect = 0;
        private static bool b_isSetComMode = false;

        #endregion

        public bool Print(string printerPort, string code, int copy, List<string> imageData)
        {
            try
            {
                if (imageData != null && imageData.Count > 0)
                {
                    foreach (string image in imageData)
                    {
                        if (SendImage(printerPort, image) == false)
                        {
                            return false;
                        }
                    }
                }

                do
                {
                    if (SendCommand(printerPort, code) == false)
                    {
                        break;
                    }
                    copy--;
                } while (copy > 0);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetComMode(string port, int baudRate, Parity parity, int dataBits, StopBits stopBits, Handshake handshake)
        {
            rsComPort = new SerialPort();
            rsComPort.PortName = port;
            rsComPort.BaudRate = baudRate;
            rsComPort.Parity = parity;
            rsComPort.DataBits = dataBits;
            rsComPort.StopBits = stopBits;

            rsComPort.ReadTimeout = 500;
            rsComPort.WriteTimeout = 500;
            rsComPort.Handshake = Handshake.XOnXOff;

            b_isSetComMode = true;
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
        private bool ComPortOpen()
        {
            try
            {
                //// Initializes port
                while (!rsComPort.IsOpen)
                {
                    try
                    {
                        rsComPort.Open();
                    }
                    catch (ApplicationException)
                    {
                        Thread.Sleep(100);
                        if (i_reconnect++ > RECONNECT_LIMIT)
                            break;
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ComPortOpen(string aPort, int iBaudRate, int iParity, int iDataBit, int iStopBit)
        {

            try
            {
                rsComPort.PortName = aPort;
                rsComPort.BaudRate = iBaudRate;
                rsComPort.Parity = (Parity)iParity;
                rsComPort.DataBits = iDataBit;
                rsComPort.StopBits = (StopBits)iStopBit;

                rsComPort.ReadTimeout = 500;
                rsComPort.WriteTimeout = 500;
                rsComPort.Handshake = Handshake.XOnXOff;

                //// Initializes port
                while (!rsComPort.IsOpen)
                {
                    try
                    {
                        rsComPort.Open();
                    }
                    catch (ApplicationException)
                    {
                        Thread.Sleep(100);
                        if (i_reconnect++ > RECONNECT_LIMIT)
                            break;
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
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
        private bool ComPortClose()
        {
            try
            {
                rsComPort.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

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
        private bool Send_Data(string sPrintPort, string aData)
        {
            return Send_Data(sPrintPort, aData, false);
        }

        private bool Send_Data(string sPrintPort, string aData, bool bCheck)
        {

            byte[] aryByte = Encoding.Default.GetBytes(aData);

            try
            {
                switch (sPrintPort.Substring(0, 3))
                {
                    case lblConst.LBL_PRINT_PORT_LPT:
                        Microsoft.Win32.SafeHandles.SafeFileHandle hFile = null;

                        hFile = CreateFile(sPrintPort, GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

                        if (hFile.IsInvalid)
                        {
                            return false;
                        }

                        FileStream fs = new FileStream(hFile, FileAccess.ReadWrite);

                        fs.Write(aryByte, 0, aryByte.Length);

                        fs.Close();
                        fs = null;
                        break;

                    case lblConst.POP_PRINT_PORT_COM:
                        if (rsComPort == null)
                        {
                            rsComPort = new SerialPort();
                        }

                        if (rsComPort.IsOpen == false)
                        {
                            if (b_isSetComMode == true)
                            {
                                if (ComPortOpen() == false)
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                if (ComPortOpen(sPrintPort, 9600, 0, 8, 1) == false)
                                {
                                    return false;
                                }
                            }
                        }

                        // PrtStatusCheck의 경우 Zebra Printer에 한정된 기능으로 만들어져 있어서 제외시킴.
                        //if (bCheck == false)
                        //{
                        //    PrtStatusCheck(sPrintPort);
                        //}

                        rsComPort.WriteLine(aData);

                        if (bCheck == false)
                        {
                            ComPortClose();
                        }

                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                if (rsComPort != null && rsComPort.IsOpen == true)
                {
                    ComPortClose();
                }
                throw ex;
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
        private bool SendCommand(string PrintPort, string LabelCommand)
        {
            if (Send_Data(PrintPort, LabelCommand) == false)
            {
                return false;
            }

            return true;
        }

        //private bool SendPrintCommandByIp(string sPrintIP, string sUser, string sPassword, string LabelCommand)
        //{

        //    string LabelScript = @"\LScript.txt";
        //    string LabelData = @"\LData.txt";
        //    string path = Directory.GetCurrentDirectory();

        //    string ScriptFileName;
        //    string DataFileName;
        //    string command;

        //    try
        //    {
        //        ScriptFileName = path + LabelScript;
        //        DataFileName = path + LabelData;

        //        // Delete the file if it exists.
        //        if (File.Exists(ScriptFileName))
        //        {
        //            File.Delete(ScriptFileName);
        //        }

        //        using (StreamWriter sw = new StreamWriter(ScriptFileName))
        //        {
        //            sw.WriteLine("open {0}", sPrintIP);
        //            sw.WriteLine("{0}", sUser);
        //            sw.WriteLine("{0}", sPassword);
        //            sw.WriteLine("put \"{0}\"", DataFileName);
        //            sw.WriteLine("bye");
        //            sw.Close();
        //        }

        //        // Delete the file if it exists.
        //        if (File.Exists(DataFileName))
        //        {
        //            File.Delete(DataFileName);
        //        }

        //        using (StreamWriter sw = new StreamWriter(DataFileName))
        //        {
        //            sw.WriteLine("{0}", LabelCommand);
        //            sw.Close();
        //        }

        //        command = "ftp";

        //        Process process = new Process();
        //        process.EnableRaisingEvents = false;
        //        process.StartInfo.CreateNoWindow = false;
        //        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        //        process.StartInfo.FileName = command;
        //        process.StartInfo.Arguments = "-s:\"" + ScriptFileName + "\"";

        //        if (process.Start() == false)
        //        {
        //            throw new Exception("Error send label code to remote printer.");
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //
        // Delete_Prev_Format()
        //       - Delete Previous Format
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        //public static bool Delete_Prev_Format(string sPrintType, ref Rs232 aComPort)
        //{
        //    string sData;
        //    ////* ^EF -- Erase all previously stored formats *//
        //    sData = "^XA^EF^FS^XZ";
        //    Send_Data(sPrintType, sData, false);

        //    Thread.Sleep(100);
        //    return true;
        //}
        private bool Delete_Prev_Format(string sPrintPort)
        {
            string sData;
            ////* ^EF -- Erase all previously stored formats *//
            sData = "^XA^EF^FS^XZ";
            Send_Data(sPrintPort, sData);

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
        //public static bool DeleteDownloadImage(string sPrintType, ref Rs232 aComPort, string sImage)
        //{
        //    string Temp_Syntax;

        //    Temp_Syntax = "^XA^IDR:" + sImage.Trim() + "^XZ";

        //    Send_Data(sPrintType, Temp_Syntax, false);

        //    return true;
        //}
        private bool DeleteImage(string sPrintPort, string sImage)
        {
            string Temp_Syntax;

            Temp_Syntax = "^XA^IDR:" + sImage.Trim() + "^XZ";

            Send_Data(sPrintPort, Temp_Syntax);

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
        private bool SendImage(string sPrintPort, string sImage)
        {
            try
            {
                Send_Data(sPrintPort, Common.DecodeFrom64(sImage));

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void rsComPort_PrtCheckDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;

            int iRecSize = sp.BytesToRead; // 수신된 데이터 갯수
            string s_PrtErrMsg;

            if (iRecSize != 0) // 수신된 데이터의 수가 0이 아닐때만 처리하자
            {
                byte[] buff = new byte[iRecSize];

                sp.Read(buff, 0, iRecSize);

                s_PrtErrMsg = "";
                if (buff[5] == 49)
                {
                    s_PrtErrMsg = s_PrtErrMsg + "No paper." + (char)lblConst.CR;
                }
                if (buff[7] == 49)
                {
                    s_PrtErrMsg = s_PrtErrMsg + "Printer is on pause." + (char)lblConst.CR;
                }

                byte[] bufFull = new byte[3];
                bufFull[0] = buff[14];
                bufFull[1] = buff[15];
                bufFull[2] = buff[16];
                if (Convert.ToInt32(System.Text.Encoding.ASCII.GetString(bufFull)) >= 50)
                {
                    Thread.Sleep(5000); // Receive Buffer Full 방지용 5초 시간지연.
                }
                if (buff[28] == 49)
                {
                    s_PrtErrMsg = s_PrtErrMsg + "Buffer is full." + (char)lblConst.CR;
                }
                if (buff[43] == 49)
                {
                    s_PrtErrMsg = s_PrtErrMsg + "Head is left open." + (char)lblConst.CR;
                }
                if (buff[45] == 49)
                {
                    s_PrtErrMsg = s_PrtErrMsg + "No ribbon." + (char)lblConst.CR;
                }

                if (s_PrtErrMsg.Length > 0)
                {
                    Console.Beep();
                    throw new Exception(s_PrtErrMsg);
                }
            }
        }

        // 프린터 상태 확인
        private void PrtStatusCheck(string sPrintType)
        {
            string sData;

            sData = "~HS" + (char)lblConst.CR;
            rsComPort.DataReceived += new SerialDataReceivedEventHandler(rsComPort_PrtCheckDataReceived);

            try
            {
                Send_Data(sPrintType, sData, true);
            }
            catch (Exception e)
            {
                ComPortClose();
                throw e;
            }
        }

        private bool ReceMessageByte(byte[] aMessage)
        {
            bool returnValue;

            int i_LF_Count;

            try
            {
                foreach (byte msg in aMessage)
                {
                    lblConst.bl_PrtStatus.Add(msg);

                    if (msg == 2) // STX
                    {
                        lblConst.b_InputSTX = true;
                    }
                    else if (lblConst.b_InputSTX)
                    {
                        if (msg == 10)  // LF
                        {
                            lblConst.b_InputSTX = false;
                        }
                    }
                }

                // 프린터에서 3개의 상태값이 모두 들어왔는지 확인 및 시간지연.
                i_LF_Count = 0;
                returnValue = false;

                foreach (byte msg in lblConst.bl_PrtStatus)
                {
                    if (msg == 10) // LF
                    {
                        i_LF_Count++;
                        if (i_LF_Count == 3)
                        {
                            returnValue = true;
                            break;
                        }
                    }
                }

                return returnValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    // Printer by Name
    public class NPrinter
    {
        #region " winspool.drv에서 제공하는 Api 사용을 위한 static function 선언부 "

        /// <summary>
        /// 라벨 프린트를 위한 Structure 선언. Api를 사용하므로 별도의 Structure 형태 사용이 필요
        /// </summary>
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

        [StructLayout(LayoutKind.Sequential)]
        public struct PRINTER_DEFAULTS
        {
            public IntPtr pDatatype;
            public IntPtr pDevMode;
            public int DesiredAccess;
        }

        /// <summary>
        /// 라벨 프린터의 상태 정보 Structure
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct PRINTER_INFO_2
        {
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pServerName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pPrinterName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pShareName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pPortName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pDriverName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pComment;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pLocation;
            public IntPtr pDevMode;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pSepFile;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pPrintProcessor;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pDatatype;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pParameters;
            public IntPtr pSecurityDescriptor;
            public uint Attributes;
            public uint Priority;
            public uint DefaultPriority;
            public uint StartTime;
            public uint UntilTime;
            public uint Status;
            public uint cJobs;
            public uint AveragePPM;
        }

        //The printer is busy.
        private const Int32 PRINTER_STATUS_BUSY = 0x00000200;
        //The door on the printer is open.
        private const Int32 PRINTER_STATUS_DOOR_OPEN = 0x00400000;
        //An error has occured.
        private const Int32 PRINTER_STATUS_ERROR = 0x00000002;
        //The printer is initializing.
        private const Int32 PRINTER_STATUS_INITIALIZING = 0x00008000;
        //I/O with the printer is active.
        private const Int32 PRINTER_STATUS_IO_ACTIVE = 0x00000100;
        //The printer is loading paper using manual feed.
        private const Int32 PRINTER_STATUS_MANUAL_FEED = 0x0000020;
        //The printer is out of toner.
        private const Int32 PRINTER_STATUS_NO_TONER = 0x00040000;
        //The printer is not available.
        private const Int32 PRINTER_STATUS_NOT_AVAILABLE = 0x00001000;
        //The printer is offline.
        private const Int32 PRINTER_STATUS_OFFLINE = 0x00000080;
        //The printer is out of memory.
        private const Int32 PRINTER_STATUS_OUT_OF_MEMORY = 0x00200000;
        //The printer's output bin is full.
        private const Int32 PRINTER_STATUS_OUTPUT_BIN_FULL = 0x00000800;
        //The printer has aborted printing the current page because it is too complex to handle.
        private const Int32 PRINTER_STATUS_PAGE_PUNT = 0x00080000;
        //The printer's paper has jammed.
        private const Int32 PRINTER_STATUS_PAPER_JAM = 0x00000008;
        //The printer is out of paper.
        private const Int32 PRINTER_STATUS_PAPER_OUT = 0x00000010;
        //There is a problem with the paper in the printer.
        private const Int32 PRINTER_STATUS_PAPER_PROBLEM = 0x00000040;
        //The printer is paused.
        private const Int32 PRINTER_STATUS_PAUSED = 0x00000001;
        //A document in the print queue is pending deletion.
        private const Int32 PRINTER_STATUS_PENDING_DELETION = 0x00000004;
        //The printer is printing.
        private const Int32 PRINTER_STATUS_PRINTING = 0x00000400;
        //The printer is processing information.
        private const Int32 PRINTER_STATUS_PROCESSING = 0x00004000;
        //The printer is low on toner.
        private const Int32 PRINTER_STATUS_TONER_LOW = 0x00020000;
        //The user has intervened in printer operations.
        private const Int32 PRINTER_STATUS_USER_INTERVENTION = 0x00100000;
        //The printer is waiting.
        private const Int32 PRINTER_STATUS_WAITING = 0x00002000;
        //The printer is warming up.
        private const Int32 PRINTER_STATUS_WARMING_UP = 0x00010000;


        [DllImport("winspool.drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        [DllImport("winspool.drv", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool GetPrinter(IntPtr hPrinter, Int32 dwLevel, IntPtr pPrinter, Int32 dwBuf, out Int32 dwNeeded);

        #endregion

        #region " Variable Definition "
        private static bool b_isPrinterOpen;
        private static IntPtr p_handle;
        #endregion " Variable Definition "

        public bool Print(string printerName, string code, int copy, List<string> imageData)
        {
            try
            {
                if (imageData != null && imageData.Count > 0)
                {
                    if (SendImage(printerName, imageData) == false)
                    {
                        return false;
                    }
                }

                if (SendCommand(printerName, code, copy) == false)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Open(string name)
        {
            if (b_isPrinterOpen == true)
            {
                return;
            }

            if (OpenPrinter(name.Normalize(), out p_handle, IntPtr.Zero) == false)
            {
                throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        private void Close()
        {
            if (p_handle != null && b_isPrinterOpen == true)
            {
                if (ClosePrinter(p_handle) == false)
                {
                    throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
                }

                b_isPrinterOpen = false;
            }
        }

        public bool SendCommand(string name, string command, int copy)
        {
            if (b_isPrinterOpen == false)
            {
                Open(name);
                b_isPrinterOpen = true;
            }

            if (!CheckPrinterStatus(p_handle))
            {
                return false;
            }

            DOCINFOA di = new DOCINFOA();
            di.pDocName = "My Document";
            di.pDataType = "RAW";

            bool status = false;
            if (StartDocPrinter(p_handle, 1, di))
            {
                IntPtr pBytes = Marshal.StringToCoTaskMemAnsi(command);
                Int32 dwWriiten = 0;
                do
                {
                    status = WritePrinter(p_handle, pBytes, command.Length, out dwWriiten);
                    copy--;
                } while (copy > 0);
                Marshal.FreeCoTaskMem(pBytes);

                if (!status)
                {
                    Close();
                    return false;
                }

                EndDocPrinter(p_handle);
            }

            Close();
            return true;
        }

        public bool SendImage(string name, List<string> imageString)
        {
            bool status = false;

            try
            {
                if (b_isPrinterOpen == false)
                {
                    Open(name);
                    b_isPrinterOpen = true;
                }

                if (!CheckPrinterStatus(p_handle))
                {
                    return false;
                }

                DOCINFOA di = new DOCINFOA();
                di.pDocName = "My Document";
                di.pDataType = "RAW";

                if (StartDocPrinter(p_handle, 1, di))
                {
                    string code = null;
                    IntPtr pBytes;
                    Int32 dwWriiten = 0;
                    foreach (string image in imageString)
                    {
                        code = Common.DecodeFrom64(image);
                        pBytes = Marshal.StringToCoTaskMemAnsi(code);
                        dwWriiten = 0;
                        status = WritePrinter(p_handle, pBytes, code.Length, out dwWriiten);
                        Marshal.FreeCoTaskMem(pBytes);
                        if (!status)
                        {
                            Close();
                            return false;
                        }
                    }

                    EndDocPrinter(p_handle);
                }

                Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool CheckPrinterStatus(IntPtr hPrinter)
        {
            int cbNeeded = 0;
            PRINTER_INFO_2 PI2 = new PRINTER_INFO_2();

            bool bRet = GetPrinter(hPrinter, 2, IntPtr.Zero, 0, out cbNeeded);

            if (cbNeeded > 0)
            {
                IntPtr pAddr = Marshal.AllocHGlobal((int)cbNeeded);

                bRet = GetPrinter(hPrinter, 2, pAddr, cbNeeded, out cbNeeded);

                if (bRet)
                {
                    PI2 = (PRINTER_INFO_2)Marshal.PtrToStructure(pAddr, typeof(PRINTER_INFO_2));
                }

                Marshal.FreeHGlobal(pAddr);
                if (PI2.Status == 0)
                    return true;
            }
            return false;
        }
    }

    class lblConst
    {
        public const string LBL_PRINT_PORT_LPT = "LPT";
        public const string POP_PRINT_PORT_COM = "COM";
        public const int CR = 13;
        public const int ETX = 3;
        public const int EXCEL_MAX_COL = 255;
        public const int HDF_BITMAP = 8192;
        public const int HDF_BITMAP_ON_RIGHT = 4096;
        public const int HDF_CENTER = 2;
        public const int HDF_IMAGE = 2048;
        public const int HDF_JUSTIFYMASK = 3;
        public const int HDF_LEFT = 0;
        public const int HDF_OWNERDRAW = 32768;
        public const int HDF_RIGHT = 1;
        public const int HDF_RTLREADING = 4;
        public const int HDF_SORTDOWN = 512;
        public const int HDF_SORTUP = 1024;
        public const int HDF_STRING = 16384;
        public const int HDI_FORMAT = 1;
        public const int HDI_IMAGE = 16;
        public const int HDM_FIRST = 4608;
        public const int HDM_SETIMAGELIST = 4616;
        public const int HDM_SETITEM = 4612;
        public const int HT = 9;
        public const int i_BufFull = 50;
        public const int LF = 10;
        public const int LV_BONUS_COLUMN_WIDTH = 4;
        public const int LV_BONUS_COLUMN_WIDTH_WITH_IMAGE = 2;
        public const int LV_BONUS_LISTVIEW_HEIGHT = 2;
        public const int LV_MAX_COLUMN_WIDTH = 500;
        public const int LV_MAX_LIST_COUNT = 20;
        public const int LV_MIN_COLUMN_WIDTH = 50;
        public const int LVM_FIRST = 4096;
        public const int LVM_GETHEADER = 4127;
        public const int LVM_SETCOLUMN = 4122;
        public const string s_TimeOut = "05";
        public const int STX = 2;

        public static bool b_InputSTX;
        public static List<byte> bl_PrtStatus = new List<byte>();
    }

    class Common
    {
        public static string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes
                = System.Convert.FromBase64String(encodedData);
            string returnValue =
               System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;
        }
    }
}
