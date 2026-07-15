// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Miracom.CliFrx;



// This class provides all the necessary support for communicating
//   with the Comm Port (otherwise known as the Serial Port, or
//   RS232 port).
namespace Miracom.POPCore
{
    public class Rs232
    {

        // Declare the necessary class variables, and their initial values.
        private int mhRS = -1; // Handle to Com Port, -1 의 경우 초기화 되지 않음을 표시
        private int miPort = 1; // Default is COM1
        private int miTimeout = 70; // Timeout in ms
        private int miBaudRate = 9600; // 통신 보레이트
        private DataParity meParity = 0; // 패리티 비트(하단에 열거형으로 정의함)
        private DataStopBit meStopBit = 0; // 스톱비트(하단에 열거형으로 정의함)
        private int miDataBit = 8; // 데이터비트  통신 설정 기본값은 9600/N/8/1임돠
        private int miBufferSize = 512; // Buffers size default to 512 bytes
        private byte[] mabtRxBuf; // Receive buffer는 Byte로 설정    
        private Mode meMode; // Class working mode(Overlap, NonOverlap I/O결정)    
        private bool mbWaitOnRead; // 상태 플레그
        private bool mbWaitOnWrite = false;
        private OVERLAPPED muOverlapped; // Overlapped I/O 형 변수
        private OVERLAPPED muOverlappedW;
        private byte[] mabtTmpTxBuf; // Temporary buffer used by Async Tx
        private Thread moThreadTx;
        private Thread moThreadRx;
        private int miTmpBytes2Read;

        #region "Enums"

        //---------------------------------------------------------------
        // 열거형 자료
        //---------------------------------------------------------------


        // This enumeration provides Data Parity values.
        public enum DataParity
        {
            Parity_None = 0,
            Pariti_Odd,
            Parity_Even,
            Parity_Mark
        }

        // This enumeration provides Data Stop Bit values.
        //   It is set to begin with a one, so that the enumeration values
        //   match the actual values.
        public enum DataStopBit
        {
            StopBit_1 = 1,
            StopBit_2
        }

        // This enumeration contains values used to purge the various buffers.
        private enum PurgeBuffers
        {
            RXAbort = 0x2,
            RXClear = 0x8,
            TxAbort = 0x1,
            TxClear = 0x4
        }

        // This enumeration provides values for the lines sent to the Comm Port
        // 라인컨트롤 관련 열거형 자료
        private enum Lines
        {
            SetRts = 3,
            ClearRts = 4,
            SetDtr = 5,
            ClearDtr = 6,
            ResetDev = 7, //     Reset device if possible
            SetBreak = 8, //     Set the device break line.
            ClearBreak = 9 //     Clear the device break line.
        }

        // This enumeration provides values for the Modem Status, since
        //   we'll be communicating primarily with a modem.
        // Note that the Flags() attribute is set to allow for a bitwise
        //   combination of values.
        [Flags()]
        public enum ModemStatusBits
        {
            ClearToSendOn = 0x10,
            DataSetReadyOn = 0x20,
            RingIndicatorOn = 0x40,
            CarrierDetect = 0x80
        }

        // This enumeration provides values for the Working mode
        public enum Mode
        {
            NonOverlapped,
            Overlapped
        }

        // This enumeration provides values for the Comm Masks used.
        // Note that the Flags() attribute is set to allow for a bitwise
        // combination of values.
        [Flags()]
        public enum EventMasks
        {
            RxChar = 0x1,
            RXFlag = 0x2,
            TxBufferEmpty = 0x4,
            ClearToSend = 0x8,
            DataSetReady = 0x10,
            ReceiveLine = 0x20,
            Break = 0x40,
            StatusError = 0x80,
            Ring = 0x100
        }
        #endregion

        #region "Structures"
        // This is the DCB structure used by the calls to the Windows API.
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct DCB
        {
            public int DCBlength;
            public int BaudRate;
            public int Bits1;
            public short wReserved;
            public short XonLim;
            public short XoffLim;
            public byte ByteSize;
            public byte Parity;
            public byte StopBits;
            public byte XonChar;
            public byte XoffChar;
            public byte ErrorChar;
            public byte EofChar;
            public byte EvtChar;
            public short wReserved2;
        }

        // This is the CommTimeOuts structure used by the calls to the Windows API.
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct COMMTIMEOUTS
        {
            public int ReadIntervalTimeout;
            public int ReadTotalTimeoutMultiplier;
            public int ReadTotalTimeoutConstant;
            public int WriteTotalTimeoutMultiplier;
            public int WriteTotalTimeoutConstant;
        }

        // This is the CommConfig structure used by the calls to the Windows API.
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct COMMCONFIG
        {
            public int dwSize;
            public short wVersion;
            public short wReserved;
            public DCB dcbx;
            public int dwProviderSubType;
            public int dwProviderOffset;
            public int dwProviderSize;
            public byte wcProviderData;
        }

        // This is the OverLapped structure used by the calls to the Windows API.
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct OVERLAPPED
        {
            public int Internal;
            public int InternalHigh;
            public int Offset;
            public int OffsetHigh;
            public int hEvent;
        }
        #endregion

        #region "Exceptions"

        // This class defines a customized channel exception. This exception is
        //   raised when a NACK is raised.
        public class CIOChannelException : ApplicationException
        {


            public CIOChannelException(string Message)
                : base(Message)
            {
            }
            public CIOChannelException(string Message, Exception InnerException)
                : base(Message, InnerException)
            {
            }
        }

        // This class defines a customized timeout exception.
        //Public Class IOTimeoutException : Inherits CIOChannelException

        public class IOTimeoutException : ApplicationException
        {


            public IOTimeoutException(string Message)
                : base(Message)
            {
            }
            public IOTimeoutException(string Message, Exception InnerException)
                : base(Message, InnerException)
            {
            }
        }

        #endregion

        #region "Events"
        // These events allow the program using this class to react to Comm Port
        //   events.
        public delegate void DataReceivedEventHandler(Rs232 Source, byte[] DataBuffer);
        private DataReceivedEventHandler DataReceivedEvent;

        public event DataReceivedEventHandler DataReceived
        {
            add
            {
                DataReceivedEvent = (DataReceivedEventHandler)System.Delegate.Combine(DataReceivedEvent, value);
            }
            remove
            {
                DataReceivedEvent = (DataReceivedEventHandler)System.Delegate.Remove(DataReceivedEvent, value);
            }
        }

        public delegate void TxCompletedEventHandler(Rs232 Source);
        private TxCompletedEventHandler TxCompletedEvent;

        public event TxCompletedEventHandler TxCompleted
        {
            add
            {
                TxCompletedEvent = (TxCompletedEventHandler)System.Delegate.Combine(TxCompletedEvent, value);
            }
            remove
            {
                TxCompletedEvent = (TxCompletedEventHandler)System.Delegate.Remove(TxCompletedEvent, value);
            }
        }

        public delegate void CommEventEventHandler(Rs232 Source, EventMasks Mask);
        private CommEventEventHandler CommEventEvent;

        public event CommEventEventHandler CommEvent
        {
            add
            {
                CommEventEvent = (CommEventEventHandler)System.Delegate.Combine(CommEventEvent, value);
            }
            remove
            {
                CommEventEvent = (CommEventEventHandler)System.Delegate.Remove(CommEventEvent, value);
            }
        }

        #endregion


        #region "Constants"
        // These constants are used to make the code clearer.
        private const int PURGE_RXABORT = 0x2;
        private const int PURGE_RXCLEAR = 0x8;
        private const int PURGE_TXABORT = 0x1;
        private const int PURGE_TXCLEAR = 0x4;
        private int GENERIC_READ = -2147483648;
        private const int GENERIC_WRITE = 0x40000000;
        private const int OPEN_EXISTING = 3;
        private const int INVALID_HANDLE_VALUE = -1;
        private const int IO_BUFFER_SIZE = 1024;
        private const int FILE_FLAG_OVERLAPPED = 0x40000000;
        private const int ERROR_IO_PENDING = 997;
        private const int WAIT_OBJECT_0 = 0;
        private const int ERROR_IO_INCOMPLETE = 996;
        private const int WAIT_TIMEOUT = 0x102;
        private int INFINITE = -1;


        #endregion

        #region "Properties"

        // This property gets or sets the BaudRate
        public int BaudRate
        {
            get
            {
                return miBaudRate;
            }
            set
            {
                miBaudRate = value;
            }
        }

        // This property gets or sets the BufferSize
        public int BufferSize
        {
            get
            {
                return miBufferSize;
            }
            set
            {
                miBufferSize = value;
            }
        }

        // This property gets or sets the DataBit.
        public int DataBit
        {
            get
            {
                return miDataBit;
            }
            set
            {
                miDataBit = value;
            }
        }

        // This write-only property sets or resets the DTR line.
        public bool Dtr
        {
            set
            {
                if (mhRS != -1)
                {
                    if (value)
                    {
                        EscapeCommFunction(mhRS, (int)Lines.SetDtr);
                    }
                    else
                    {
                        EscapeCommFunction(mhRS, (int)Lines.ClearDtr);
                    }
                }
            }
        }

        // This read-only property returns an array of bytes that represents
        //   the input coming into the Comm Port.
        virtual public byte[] InputStream
        {
            get
            {
                return mabtRxBuf;
            }
        }

        // This read-only property returns a string that represents
        //   the data coming into to the Comm Port.
        virtual public string InputStreamString
        {
            get
            {
                System.Text.ASCIIEncoding oEncoder = new System.Text.ASCIIEncoding();
                return oEncoder.GetString(this.InputStream);
            }
        }

        // This property returns the open status of the Comm Port.
        public bool IsOpen
        {
            get
            {
                return System.Convert.ToBoolean(mhRS != -1);
            }
        }

        // This read-only property returns the status of the modem.
        public ModemStatusBits ModemStatus
        {
            get
            {
                if (mhRS == -1)
                {
                    throw (new ApplicationException("Please initialize and open " + "port before using this method"));
                }
                else
                {
                    // Retrieve modem status
                    int lpModemStatus = 0;
                    if (!GetCommModemStatus(mhRS, ref lpModemStatus))
                    {
                        throw (new ApplicationException("Unable to get modem status"));
                    }
                    else
                    {
                        return ((ModemStatusBits)lpModemStatus);
                    }
                }
            }
        }

        // This property gets or sets the Parity
        public DataParity Parity
        {
            get
            {
                return meParity;
            }
            set
            {
                meParity = value;
            }
        }

        // This property gets or sets the Port
        public int Port
        {
            get
            {
                return miPort;
            }
            set
            {
                miPort = value;
            }
        }

        // This write-only property sets or resets the RTS line.
        public bool Rts
        {
            set
            {
                if (mhRS != -1)
                {
                    if (value)
                    {
                        EscapeCommFunction(mhRS, (int)Lines.SetRts);
                    }
                    else
                    {
                        EscapeCommFunction(mhRS, (int)Lines.ClearRts);
                    }
                }
            }
        }

        // This property gets or sets the StopBit
        public DataStopBit StopBit
        {
            get
            {
                return meStopBit;
            }
            set
            {
                meStopBit = value;
            }
        }

        // This property gets or sets the Timeout
        public virtual int Timeout
        {
            get
            {
                return miTimeout;
            }
            set
            {
                miTimeout = MPCF.ToInt(value == 0 ? 500 : value);
                // If Port is open updates it on the fly
                pSetTimeout();
            }
        }

        // This property gets or sets the working mode to overlapped
        //   or non-overlapped.
        public Mode WorkingMode
        {
            get
            {
                return meMode;
            }
            set
            {
                meMode = value;
            }
        }

        #endregion

        #region "Win32API"
        // The following functions are the required Win32 functions needed to
        //   make communication with the Comm Port possible.

        [DllImport("kernel32.dll")]
        private static extern int BuildCommDCB(string lpDef, ref DCB lpDCB);

        [DllImport("kernel32.dll")]
        private static extern int ClearCommError(int hFile, int lpErrors, int l);

        [DllImport("kernel32.dll")]
        private static extern int CloseHandle(int hObject);

        [DllImport("kernel32.dll")]
        private static extern int CreateEvent(int lpEventAttributes, int bManualReset, int bInitialState, [MarshalAs(UnmanagedType.LPStr)]string lpName);

        [DllImport("kernel32.dll")]
        private static extern int CreateFile([MarshalAs(UnmanagedType.LPStr)]string lpFileName, int dwDesiredAccess, int dwShareMode, int lpSecurityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes, int hTemplateFile);

        [DllImport("kernel32.dll")]
        private static extern bool EscapeCommFunction(int hFile, int ifunc);

        [DllImport("kernel32.dll")]
        private static extern int FormatMessage(int dwFlags, int lpSource, int dwMessageId, int dwLanguageId, [MarshalAs(UnmanagedType.LPStr)]string lpBuffer, int nSize, int Arguments);

        [DllImport("kernel32", EntryPoint = "FormatMessageA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int FormatMessage(int dwFlags, int lpSource, int dwMessageId, int dwLanguageId, StringBuilder lpBuffer, int nSize, int Arguments);

        [DllImport("kernel32.dll")]
        public static extern bool GetCommModemStatus(int hFile, ref int lpModemStatus);

        [DllImport("kernel32.dll")]
        private static extern int GetCommState(int hCommDev, ref DCB lpDCB);

        [DllImport("kernel32.dll")]
        private static extern int GetCommTimeouts(int hFile, ref COMMTIMEOUTS lpCommTimeouts);

        [DllImport("kernel32.dll")]
        private static extern int GetLastError();

        [DllImport("kernel32.dll")]
        private static extern int GetOverlappedResult(int hFile, ref OVERLAPPED lpOverlapped, ref int lpNumberOfBytesTransferred, int bWait);

        [DllImport("kernel32.dll")]
        private static extern int PurgeComm(int hFile, int dwFlags);

        [DllImport("kernel32.dll")]
        private static extern int ReadFile(int hFile, byte[] Buffer, int nNumberOfBytesToRead, ref int lpNumberOfBytesRead, ref OVERLAPPED lpOverlapped);

        [DllImport("kernel32.dll")]
        private static extern int SetCommTimeouts(int hFile, ref COMMTIMEOUTS lpCommTimeouts);

        [DllImport("kernel32.dll")]
        private static extern int SetCommState(int hCommDev, ref DCB lpDCB);

        [DllImport("kernel32.dll")]
        private static extern int SetupComm(int hFile, int dwInQueue, int dwOutQueue);

        [DllImport("kernel32.dll")]
        private static extern int SetCommMask(int hFile, int lpEvtMask);

        [DllImport("kernel32.dll")]
        private static extern int WaitCommEvent(int hFile, ref EventMasks Mask, ref OVERLAPPED lpOverlap);

        [DllImport("kernel32.dll")]
        private static extern int WaitForSingleObject(int hHandle, int dwMilliseconds);

        [DllImport("kernel32.dll")]
        private static extern int WriteFile(int hFile, byte[] Buffer, int nNumberOfBytesToWrite, ref int lpNumberOfBytesWritten, ref OVERLAPPED lpOverlapped);

        #endregion

        #region "Methods"


        //-------------------------------------------------------------------
        // 내부 처리 Method
        // Event는 여기서 발생시킨다.
        //-------------------------------------------------------------------
        //   This subroutine invokes a thread to perform an asynchronous read.
        //   This routine should not be called directly, but is used
        //   by the class.

        public void _R() //--------------(1)
        {
            Read(miTmpBytes2Read); // 읽을 바이트 수만큼 읽는다.
            //Read함수에서 읽기 완료되면 RxComplted 이벤트 발생
        }

        //   This subroutine invokes a thread to perform an asynchronous write.
        //   This routine should not be called directly, but is used
        //   by the class.
        public void _W() //--------------(2)
        {
            Write(mabtTmpTxBuf);
        }

        //  This subroutine uses another thread to read from the Comm Port. It
        //   raises RxCompleted when done. It reads an integer.
        // 수신용 Thread를 사용한다.
        // 수신 완료 되면 RxCompleted 이벤트를 발생시킨다.
        // Async Read는 Working Mode가 Overlapped일 경우  가능

        public void AsyncRead(int Bytes2Read) //-----------------(3)
        {
            if (meMode != Mode.Overlapped)
            {
                throw (new ApplicationException("Async Methods allowed only when WorkingMode=Overlapped"));
            }
            miTmpBytes2Read = Bytes2Read; // 읽을 바이트 수

            moThreadRx = new Thread(new System.Threading.ThreadStart(_R)); // Thread를 생성하고
            moThreadRx.Start();                                            // 생성된 Receive Thread를 실행한다.

        }

        // This subroutine uses another thread to write to the Comm Port. It
        //   raises TxCompleted when done. It writes an array of bytes.
        public void AsyncWrite(byte[] Buffer)
        {
            if (meMode != Mode.Overlapped)
            {
                throw (new ApplicationException("Async Methods allowed only when WorkingMode=Overlapped"));
            }
            if (mbWaitOnWrite == true)
            {
                throw (new ApplicationException("Unable to send message because of pending transmission."));
            }
            mabtTmpTxBuf = Buffer;
            moThreadTx = new Thread(new System.Threading.ThreadStart(_W));
            moThreadTx.Start();
        }

        // This subroutine uses another thread to write to the Comm Port. It
        //   raises TxCompleted when done. It writes a string.
        public void AsyncWrite(string Buffer)
        {
            System.Text.ASCIIEncoding oEncoder = new System.Text.ASCIIEncoding();
            byte[] aByte = oEncoder.GetBytes(Buffer);
            this.AsyncWrite(aByte);
        }

        // This function takes the ModemStatusBits and returns a boolean value
        //   signifying whether the Modem is active.
        public bool CheckLineStatus(ModemStatusBits Line)
        {
            return Convert.ToBoolean(ModemStatus & Line);
        }

        // This subroutine clears the input buffer.
        public void ClearInputBuffer()
        {
            if (mhRS != -1)
            {
                PurgeComm(mhRS, PURGE_RXCLEAR);
            }
        }

        // This subroutine closes the Comm Port.
        public void Close()
        {
            if (mhRS != -1)
            {
                CloseHandle(mhRS);
                mhRS = -1;
            }
        }

        // This subroutine opens and initializes the Comm Port
        // 포트 Open 함수

        public void Open()
        {
            // Get Dcb block,Update with current data
            DCB uDcb = new DCB();

            int iRc;
            // Set working mode
            int iMode = MPCF.ToInt(meMode == Mode.Overlapped ? FILE_FLAG_OVERLAPPED : 0);

            // Initializes Com Port
            if (miPort > 0)
            {
                try
                {
                    // Creates a COM Port stream handle
                    mhRS = CreateFile("COM" + miPort.ToString(), GENERIC_READ | GENERIC_WRITE, 0, 0, OPEN_EXISTING, iMode, 0);
                    if (mhRS != -1)
                    {
                        // Clear all comunication errors
                        int lpErrCode = 0;
                        iRc = ClearCommError(mhRS, lpErrCode, 0);
                        // Clears I/O buffers
                        iRc = PurgeComm(mhRS, (int)(PurgeBuffers.RXClear | PurgeBuffers.TxClear));
                        // Gets COM Settings
                        iRc = GetCommState(mhRS, ref uDcb);
                        // Updates COM Settings
                        string sParity = "NOEM";
                        sParity = sParity.Substring((int)meParity, 1);
                        // Set DCB State
                        string sDCBState = string.Format("baud={0} parity={1} data={2} stop={3}", miBaudRate, sParity, miDataBit, MPCF.ToInt(meStopBit));
                        iRc = BuildCommDCB(sDCBState, ref uDcb);
                        iRc = SetCommState(mhRS, ref uDcb);
                        if (iRc == 0)
                        {
                            string sErrTxt = pErr2Text(GetLastError());
                            throw (new CIOChannelException("Unable to set COM state0" + sErrTxt));
                        }
                        // Setup Buffers (Rx,Tx)
                        iRc = SetupComm(mhRS, miBufferSize, miBufferSize);
                        // Set Timeouts
                        pSetTimeout();
                    }
                    else
                    {
                        // Raise Initialization problems
                        throw (new CIOChannelException("Unable to open COM" + miPort.ToString()));
                    }
                }
                catch (Exception Ex)
                {
                    // Generica error
                    throw (new CIOChannelException(Ex.Message, Ex));
                }
            }
            else
            {
                // Port not defined, cannot open
                throw (new ApplicationException("COM Port not defined, " + "use Port property to set it before invoking InitPort"));
            }
        }

        // This subroutine opens and initializes the Comm Port (overloaded
        //   to support parameters).
        public void Open(int Port, int BaudRate, int DataBit, DataParity Parity, DataStopBit StopBit, int BufferSize)
        {

            this.Port = Port;
            this.BaudRate = BaudRate;
            this.DataBit = DataBit;
            this.Parity = Parity;
            this.StopBit = StopBit;
            this.BufferSize = BufferSize;
            Open();
        }

        // This function translates an API error code to text.
        private string pErr2Text(int lCode)
        {
            StringBuilder sRtrnCode = new StringBuilder(256);
            int lRet;

            lRet = FormatMessage(0x1000, 0, lCode, 0, sRtrnCode, 256, 0);
            if (lRet > 0)
            {
                return sRtrnCode.ToString();
            }
            else
            {
                return "Error not found.";
            }

        }

        // This subroutine handles overlapped reads.
        private void pHandleOverlappedRead(int Bytes2Read)
        {
            int iReadChars = 0;
            int iRc;
            int iRes;
            int iLastErr;

            muOverlapped.hEvent = CreateEvent(0, 1, 0, null);
            if (muOverlapped.hEvent == 0)
            {
                // Can't create event
                throw (new ApplicationException("Error creating event for overlapped read."));
            }
            else
            {
                // Ovellaped reading
                if (mbWaitOnRead == false)
                {
                    mabtRxBuf = new byte[Bytes2Read - 1 + 1];
                    iRc = ReadFile(mhRS, mabtRxBuf, Bytes2Read, ref iReadChars, ref muOverlapped);
                    if (iRc == 0)
                    {
                        iLastErr = GetLastError();
                        if (iLastErr != ERROR_IO_PENDING)
                        {
                            throw (new ArgumentException("Overlapped Read Error: " + pErr2Text(iLastErr)));
                        }
                        else
                        {
                            // Set Flag
                            mbWaitOnRead = true;
                        }
                    }
                    else
                    {
                        // Read completed successfully
                        if (DataReceivedEvent != null)
                            DataReceivedEvent(this, mabtRxBuf);
                    }
                }
            }
            // Wait for operation to be completed
            if (mbWaitOnRead)
            {
                iRes = WaitForSingleObject(muOverlapped.hEvent, miTimeout);
                switch (iRes)
                {
                    case WAIT_OBJECT_0:

                        // Object signaled,operation completed
                        if (GetOverlappedResult(mhRS, ref muOverlapped, ref iReadChars, 0) == 0)
                        {
                            // Operation error
                            iLastErr = GetLastError();
                            if (iLastErr == ERROR_IO_INCOMPLETE)
                            {
                                throw (new ApplicationException("Read operation incomplete"));
                            }
                            else
                            {
                                throw (new ApplicationException("Read operation error " + iLastErr.ToString()));
                            }
                        }
                        else
                        {
                            // Operation completed
                            if (DataReceivedEvent != null)
                                DataReceivedEvent(this, mabtRxBuf);
                            mbWaitOnRead = false;
                        }
                        break;

                    case WAIT_TIMEOUT: //--> Async reading시 에러는 IO Timeout임.

                        //Throw New IOTimeoutException("Timeout error")
                        throw (new ApplicationException("Overlapped I/O WAIT_TIMEOUT : Timeout error"));

                    default:

                        throw (new ApplicationException("Overlapped read error"));
                }
            }
        }

        // This subroutine handles overlapped writes.
        private bool pHandleOverlappedWrite(byte[] Buffer)
        {
            int iBytesWritten = 0;
            int iRc;
            int iLastErr;
            int iRes;
            bool bErr = false;

            muOverlappedW.hEvent = CreateEvent(0, 1, 0, null);
            if (muOverlappedW.hEvent == 0)
            {
                // Can't create event
                throw (new ApplicationException("Error creating event for overlapped write."));
            }
            else
            {
                // Overllaped write
                PurgeComm(mhRS, PURGE_RXCLEAR | PURGE_TXCLEAR);
                mbWaitOnRead = true;
                iRc = WriteFile(mhRS, Buffer, Buffer.Length, ref iBytesWritten, ref muOverlappedW);
                if (iRc == 0)
                {
                    iLastErr = GetLastError();
                    if (iLastErr != ERROR_IO_PENDING)
                    {
                        throw (new ArgumentException("Overlapped Read Error: " + pErr2Text(iLastErr)));
                    }
                    else
                    {
                        // Write is pending
                        iRes = WaitForSingleObject(muOverlappedW.hEvent, INFINITE);
                        switch (iRes)
                        {
                            case WAIT_OBJECT_0:

                                // Object signaled,operation completed
                                if (GetOverlappedResult(mhRS, ref muOverlappedW, ref iBytesWritten, 0) == 0)
                                {

                                    bErr = true;
                                }
                                else
                                {
                                    // Notifies Async tx completion,stops thread
                                    mbWaitOnRead = false;
                                    if (TxCompletedEvent != null)
                                        TxCompletedEvent(this);
                                }
                                break;
                        }
                    }
                }
                else
                {
                    // Wait operation completed immediatly
                    bErr = false;
                }
            }
            CloseHandle(muOverlappedW.hEvent);
            return bErr;
        }

        // This subroutine sets the Comm Port timeouts.
        private void pSetTimeout()
        {
            COMMTIMEOUTS uCtm;
            // Set ComTimeout
            if (mhRS == -1)
            {
                return;
            }
            else
            {
                // Changes setup on the fly
                uCtm.ReadIntervalTimeout = 0;
                uCtm.ReadTotalTimeoutMultiplier = 0;
                uCtm.ReadTotalTimeoutConstant = miTimeout;
                uCtm.WriteTotalTimeoutMultiplier = 10;
                uCtm.WriteTotalTimeoutConstant = 100;
                SetCommTimeouts(mhRS, ref uCtm);
            }
        }




        //   This function returns an integer specifying the number of bytes
        //   read from the Comm Port. It accepts a parameter specifying the number
        //   of desired bytes to read.

        public void Read(int Bytes2Read)
        {
            int iReadChars = 0;
            int iRc;

            // If Bytes2Read not specified uses Buffersize
            if (Bytes2Read == 0)
            {
                Bytes2Read = miBufferSize;
            }
            if (mhRS == -1)
            {
                throw (new ApplicationException("Please initialize and open port before using this method"));
            }
            else
            {
                // Get bytes from port
                try
                {
                    // Purge buffers
                    //PurgeComm(mhRS, PURGE_RXCLEAR Or PURGE_TXCLEAR)
                    // Creates an event for overlapped operations

                    if (meMode == Mode.Overlapped)
                    {
                        //----- overlapped I/O인 경우 동작
                        pHandleOverlappedRead(Bytes2Read);
                    }
                    else
                    {
                        Rs232.OVERLAPPED overlapped = new OVERLAPPED();
                        overlapped.hEvent = 0;

                        //------ Non overlapped mode
                        mabtRxBuf = new byte[Bytes2Read - 1 + 1];
                        iRc = ReadFile(mhRS, mabtRxBuf, Bytes2Read, ref iReadChars, ref overlapped); 

                        if (iRc == 0)
                        {
                            // Read Error
                            throw (new ApplicationException("ReadFile error " + iRc.ToString()));
                        }
                        else
                        {
                            // Handles timeout or returns input chars
                            if (iReadChars < Bytes2Read)
                            {
                                //Throw New IOTimeoutException("Timeout error:")
                                throw (new ApplicationException("Timeout error:"));
                            }
                            else
                            {
                                mbWaitOnRead = true;
                                //return (iReadChars);
                            }
                        }
                    }


                }
                catch (Exception e)
                {
                    //MessageBox.Show("ApplicationException");
                    throw (new ApplicationException("<Read Error>: Time out during Overlapped IO Reading" + e.Message, e));
                }
            }
        }

        // This subroutine writes the passed array of bytes to the
        //   Comm Port to be written.
        public void Write(byte[] Buffer)
        {
            int iBytesWritten = 0;
            int iRc;

            if (mhRS == -1)
            {
                throw (new ApplicationException("Please initialize and open port before using this method"));
            }
            else
            {
                // Transmit data to COM Port
                try
                {
                    if (meMode == Mode.Overlapped)
                    {
                        // Overlapped write
                        if (pHandleOverlappedWrite(Buffer))
                        {
                            throw (new ApplicationException("Error in overllapped write"));
                        }
                    }
                    else
                    {
                        // Clears IO buffers
                        PurgeComm(mhRS, PURGE_RXCLEAR | PURGE_TXCLEAR);
                        Rs232.OVERLAPPED overlapped = new OVERLAPPED();
                        iRc = WriteFile(mhRS, Buffer, Buffer.Length, ref iBytesWritten, ref overlapped);
                        if (iRc == 0)
                        {
                            throw (new ApplicationException("Write Error - Bytes Written " + iBytesWritten.ToString() + " of " + Buffer.Length.ToString()));
                        }
                    }
                }
                catch (Exception)
                {
                    throw (new ApplicationException("Write Error - Bytes Written " + iBytesWritten.ToString() + " of " + Buffer.Length.ToString()));

                }
            }
        }

        // This subroutine writes the passed string to the
        //   Comm Port to be written.
        public void Write(string Buffer)
        {
            System.Text.ASCIIEncoding oEncoder = new System.Text.ASCIIEncoding();
            byte[] aByte = oEncoder.GetBytes(Buffer);
            this.Write(aByte);
        }


        #endregion

    }



}
