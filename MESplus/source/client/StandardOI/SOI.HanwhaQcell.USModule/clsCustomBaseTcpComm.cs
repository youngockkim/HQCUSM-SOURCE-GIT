using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Reflection;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace SOI.HanwhaQcell.USModule
{
    public enum CONNECTED_STATUS
    {
        DISCONNECTED,
        CONNECTED,
    }

    [Serializable]
    public enum SERVER_CLIENT
    {
        Unknown,
        Server,
        Client,
    }

    [Serializable]
    public enum IORESULT
    {
        FAILED,
        SUCCEEDED,
        TIMEOUT,
    }


    public class clsCustomBaseTcpComm
    {
        public delegate void degCONNECTEDSTATUS(CONNECTED_STATUS connectedStatus);
        private Socket _socket = null;
        private SERVER_CLIENT _serverClient = SERVER_CLIENT.Unknown;
        private StringBuilder _receiveStringValue = new StringBuilder();
        private bool _isConnected = false;
        private string _ip = string.Empty;
        private string _port = string.Empty;

        private string _name = string.Empty;
        private Socket _serverSocket = null;
        private CONNECTED_STATUS _connectedStatus = CONNECTED_STATUS.DISCONNECTED;

        public degCONNECTEDSTATUS CONNECTEDSTATUS = null;

        private Ping _ping = new Ping();
        private PingOptions _pingOptions = new PingOptions();
        private string _pingData = string.Empty;
        private byte[] _pingBuffer;
        private int _pingTimeOut;

        public bool IsStructure = false;
        public bool IsLog = false;
        public bool IsPing = true;
        public bool IsReceiveString = true;
        private TcpClient _client = null;
        private NetworkStream _clientStream = null;
        private Queue<byte[]> _queReceive = new Queue<byte[]>();
        private TcpListener _serverSocketStructure = null;
        public bool IsExit = false;
        private Stopwatch _stopWatch = new Stopwatch();
        public clsCustomBaseTcpComm()
        {
            _pingOptions.DontFragment = true;
        }

        public CONNECTED_STATUS Connected_Status()
        {
            return _connectedStatus;
        }

        public void Exit()
        {
            IsExit = true;
        }

        public IORESULT DeInitialize()
        {
            try
            {
                _isConnected = false;
                _connectedStatus = CONNECTED_STATUS.DISCONNECTED;
                if (IsStructure == false)
                {
                    if (_socket != null)
                    {
                        lock (_socket)
                        {
                            _socket.Shutdown(SocketShutdown.Both);

                            _socket.Close();
                            _socket = null;

                            if (_checkConnected != null)
                            {
                                _checkConnected.Abort();
                                _checkConnected = null;
                            }
                        }
                    }
                }
                else
                {
                    if (_clientStream != null)
                    {
                        _clientStream.Close();
                        _clientStream = null;
                    }

                    if (_client != null)
                    {
                        _client.Close();
                        _client = null;
                    }

                    if (_checkConnected != null)
                    {
                        _checkConnected.Abort();
                        _checkConnected = null;
                    }
                }

            }
            catch (Exception ex)
            {
                if (_checkConnected != null)
                {
                    _checkConnected.Abort();
                    _checkConnected = null;
                }
             //   ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
             //   ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.StackTrace);
                return IORESULT.FAILED;
            }
            return IORESULT.SUCCEEDED;
        }

        private void TcpConnectTh()
        {
            while (true)
            {
                if (IsExit == true)
                {
                    return;
                }
                if (_isConnected == false)
                {
                    if (_serverClient == SERVER_CLIENT.Server)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        //ConsoleEx.WriteLine("[Info]->" + _name + "  Waiting for Client");
                        Console.ForegroundColor = ConsoleColor.White;
                        if (IsStructure == true)
                        {
                            if (_serverSocketStructure == null)
                            {
                                _serverSocketStructure = new TcpListener(IPAddress.Any, int.Parse(_port));
                                _client = default(TcpClient);
                                _serverSocketStructure.Start();
                                _client = _serverSocketStructure.AcceptTcpClient();
                            }
                        }
                        else
                        {
                            _connectedStatus = CONNECTED_STATUS.DISCONNECTED;
                            if (_serverSocket == null)
                            {
                                _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                                _serverSocket.Bind(new IPEndPoint(IPAddress.Any, int.Parse(_port)));
                                _serverSocket.Listen(1);
                            }
                            _socket = _serverSocket.Accept();
                            _receiveStringValue.Clear();
                            _connectedStatus = CONNECTED_STATUS.CONNECTED;
                            if (CONNECTEDSTATUS != null)
                            {
                                CONNECTEDSTATUS(_connectedStatus);
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        //ConsoleEx.WriteLine("[Info]->" + _name + "  Connected to " + _socket.RemoteEndPoint.ToString());
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (_serverClient == SERVER_CLIENT.Client)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        //ConsoleEx.WriteLine("[Info]->" + _name + " Trying to connect to Server");
                        Console.ForegroundColor = ConsoleColor.White;
                        if (IsStructure == true)
                        {
                            while (true)
                            {
                                try
                                {
                                    _client = new TcpClient(_ip, int.Parse(_port));
                                    _clientStream = _client.GetStream();
                                    //      _clientStream.ReadTimeout = 10;
                                    _connectedStatus = CONNECTED_STATUS.CONNECTED;
                                    if (CONNECTEDSTATUS != null)
                                    {
                                        CONNECTEDSTATUS(_connectedStatus);
                                    }
                                    break;
                                }
                                catch (SocketException)
                                {
                                    if (_client != null)
                                    {
                                        _client.Close();
                                        _client = null;
                                    }
                                    Thread.Sleep(TimeSpan.FromMilliseconds(200));
                                    continue;
                                }
                            }
                        }
                        else
                        {

                            _socket = new Socket(AddressFamily.InterNetwork,
                                                          SocketType.Stream, ProtocolType.Tcp);
                            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(_ip), int.Parse(_port));
                            while (true)
                            {
                                try
                                {
                                    _connectedStatus = CONNECTED_STATUS.DISCONNECTED;
                                    lock (_socket)
                                    {
                                        if (_socket != null)
                                        {
                                            _socket.Connect(iep);
                                            _receiveStringValue.Clear();
                                            _connectedStatus = CONNECTED_STATUS.CONNECTED;
                                            if (CONNECTEDSTATUS != null)
                                            {
                                                CONNECTEDSTATUS(_connectedStatus);
                                            }
                                        }
                                        else
                                        {
                                            _socket = new Socket(AddressFamily.InterNetwork,
                                                              SocketType.Stream, ProtocolType.Tcp);
                                            iep = new IPEndPoint(IPAddress.Parse(_ip), int.Parse(_port));
                                        }
                                    }
                                }
                                catch (SocketException soketEx)
                                {
                                    //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + soketEx.Message);
                                    Thread.Sleep(TimeSpan.FromMilliseconds(200));
                                    continue;
                                }
                                catch (Exception ex)
                                {
                                    //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                                    Thread.Sleep(TimeSpan.FromMilliseconds(200));
                                    continue;
                                }
                                break;
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        //ConsoleEx.WriteLine("[Info]->" + _name + " Connected to " + _ip);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (IsStructure == true)
                    {
                        if (_isConnected == false)
                        {
                            Thread receiveTh = new Thread(new ThreadStart(ReceiveStructure));
                            receiveTh.Start();
                            _isConnected = true;
                        }
                    }
                    else
                    {
                        if (_isConnected == false)
                        {
                            Thread receiveTh = new Thread(new ThreadStart(Receive));
                            receiveTh.Start();
                            _isConnected = true;
                        }
                    }
                }
                else
                {
                    if (IsStructure == false)
                    {

                            if (_socket != null)
                            {
                            lock (_socket)
                            {
                                try
                                {
                                    bool part1 = _socket.Poll(1000, SelectMode.SelectRead);
                                    bool part2 = (_socket.Available == 0);
                                    if (part1 & part2)
                                    {
                                        _isConnected = false;
                                        if (IsStructure == true)
                                        {
                                        }
                                        else
                                        {
                                            SocketClose();
                                        }
                                        _connectedStatus = CONNECTED_STATUS.DISCONNECTED;
                                        if (CONNECTEDSTATUS != null)
                                        {
                                            CONNECTEDSTATUS(_connectedStatus);
                                        }
                                    }
                                    else
                                    {
                                        if (IsPing == true)
                                        {
                                            PingReply reply = _ping.Send(_ip, _pingTimeOut, _pingBuffer, _pingOptions);
                                            if (reply.Status != IPStatus.Success)
                                            {
                                                _isConnected = false;
                                                if (IsStructure == true)
                                                {
                                                }
                                                else
                                                {
                                                    SocketClose();
                                                }
                                                _connectedStatus = CONNECTED_STATUS.DISCONNECTED;
                                                if (CONNECTEDSTATUS != null)
                                                {
                                                    CONNECTEDSTATUS(_connectedStatus);
                                                }
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                //ConsoleEx.WriteLine("{0} ip = {0} => Not reached, Ping Error", _name, _ip);
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }
                                        }
                                        Thread.Sleep(TimeSpan.FromMilliseconds(1000));
                                    }
                                }
                                catch (Exception ex)
                                {
                                    //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                                    //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.StackTrace);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (_client != null)
                        {
                            if (_client.Client.Poll(0, SelectMode.SelectRead))
                            {
                                if (!_client.Connected)
                                {
                                    try
                                    {
                                        _connectedStatus = CONNECTED_STATUS.DISCONNECTED;
                                        if (CONNECTEDSTATUS != null)
                                        {
                                            CONNECTEDSTATUS(_connectedStatus);
                                        }
                                        _isConnected = false;
                                        if (_clientStream != null)
                                        {
                                            _clientStream.Close();
                                            _clientStream = null;
                                        }

                                        if (_client != null)
                                        {
                                            _client.Close();
                                            _client = null;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                                        //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.StackTrace);
                                    }
                                }
                                else
                                {
                                    byte[] b = new byte[1];
                                    try
                                    {
                                        if (_client.Client.Receive(b, SocketFlags.Peek) == 0)
                                        {
                                            _connectedStatus = CONNECTED_STATUS.DISCONNECTED;
                                            if (CONNECTEDSTATUS != null)
                                            {
                                                CONNECTEDSTATUS(_connectedStatus);
                                            }
                                            _isConnected = false;

                                            if (_clientStream != null)
                                            {
                                                _clientStream.Close();
                                                _clientStream = null;
                                            }

                                            if (_client != null)
                                            {
                                                _client.Close();
                                                _client = null;
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                                        _connectedStatus = CONNECTED_STATUS.DISCONNECTED;
                                        if (CONNECTEDSTATUS != null)
                                        {
                                            CONNECTEDSTATUS(_connectedStatus);
                                        }
                                        _isConnected = false;

                                        if (_clientStream != null)
                                        {
                                            _clientStream.Close();
                                            _clientStream = null;
                                        }

                                        if (_client != null)
                                        {
                                            _client.Close();
                                            _client = null;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
            }

        }
        Thread _checkConnected = null;
        public IORESULT Initialize(string ip, string port, SERVER_CLIENT serverClient, short timeOut)
        {
            try
            {
                _name = AppDomain.CurrentDomain.FriendlyName;
                _serverClient = serverClient;
                _ip = ip;
                _port = port;
                if (_checkConnected == null)
                {
                    _checkConnected = new Thread(new ThreadStart(TcpConnectTh));
                    _checkConnected.SetApartmentState(ApartmentState.STA);
                    _checkConnected.Start();
                }
                _pingData = string.Format("name = {0}, ip = {1}, port = {2}", _name, _ip, _port);
                _pingBuffer = Encoding.ASCII.GetBytes(_pingData);
                _pingTimeOut = timeOut;

            }
            catch (Exception ex)
            {
                //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.StackTrace);
                return IORESULT.FAILED;
            }
            return IORESULT.SUCCEEDED;
        }

        public IORESULT Receive(ref string receive, short timeOut)
        {
            if (_socket == null || _connectedStatus == CONNECTED_STATUS.DISCONNECTED)
                return IORESULT.FAILED;
            try
            {
                if (_stopWatch.IsRunning == true)
                {
                    _stopWatch.Stop();
                }
                _stopWatch.Reset();
                _stopWatch.Start();
                while (true)
                {
                    if (_receiveStringValue.Length > 0)
                    {
                        lock (_receiveStringValue)
                        {
                            receive = _receiveStringValue.ToString();
                            _receiveStringValue.Clear();
                        }
                        return IORESULT.SUCCEEDED;
                    }

                    if (_stopWatch.Elapsed.Seconds >= timeOut)
                    {
                        if (_stopWatch.IsRunning == true)
                        {
                            _stopWatch.Stop();
                        }
                        return IORESULT.TIMEOUT;
                    }

                    if (_socket == null || _connectedStatus == CONNECTED_STATUS.DISCONNECTED)
                    {
                        if (_stopWatch.IsRunning == true)
                        {
                            _stopWatch.Stop();
                        }
                        return IORESULT.FAILED;
                    }

                    Thread.Sleep(TimeSpan.FromMilliseconds(10));
                }
            }
            catch (Exception ex)
            {
                lock (_receiveStringValue)
                {
                    _receiveStringValue.Clear();
                }
                if (_stopWatch.IsRunning == true)
                {
                    _stopWatch.Stop();
                }
                Console.WriteLine(string.Format("{0},{1}", ex.Message, ex.StackTrace));
                return IORESULT.FAILED;
            }
        }
        char[] _endchar = new char[1];
        string _temp = string.Empty;
        public IORESULT Receive(ref string receive, byte end, short timeOut)
        {
            if (_socket == null || _connectedStatus == CONNECTED_STATUS.DISCONNECTED)
                return IORESULT.FAILED;

            try
            {
                if (_stopWatch.IsRunning == true)
                {
                    _stopWatch.Stop();
                }
                _stopWatch.Reset();
                _stopWatch.Start();

                _endchar[0] = (char)end;
                while (true)
                {
                    lock (_receiveStringValue)
                    {
                        if (_receiveStringValue.Length > 0)
                        {
                            if (end != 0)
                            {
                                if (_receiveStringValue.ToString().Contains(_endchar[0]) == true)
                                {
                                    try
                                    {
                                        _temp = _receiveStringValue.ToString();
                                        int index = _temp.IndexOfAny(_endchar);
                                        receive = _temp.Substring(0, index);
                                        _receiveStringValue.Remove(0, index + 1);
                                    }
                                    catch (Exception ex)
                                    {
                                        if (_stopWatch.IsRunning == true)
                                        {
                                            _stopWatch.Stop();
                                        }
                                        _receiveStringValue.Clear();
                                        Console.WriteLine(string.Format("{0},{1}", ex.Message, ex.StackTrace));
                                        //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                                        //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.StackTrace);
                                        return IORESULT.FAILED;
                                    }

                                    return IORESULT.SUCCEEDED;
                                }
                            }
                            else
                            {
                                receive = _receiveStringValue.ToString();
                                return IORESULT.SUCCEEDED;
                            }
                        }
                    }
                    if (_stopWatch.Elapsed.Seconds >= timeOut)
                    {
                        if (_stopWatch.IsRunning == true)
                        {
                            _stopWatch.Stop();
                        }
                        return IORESULT.TIMEOUT;
                    }

                    if (_socket == null || _connectedStatus == CONNECTED_STATUS.DISCONNECTED)
                    {
                        if (_stopWatch.IsRunning == true)
                        {
                            _stopWatch.Stop();
                        }
                        return IORESULT.FAILED;
                    }

                    Thread.Sleep(TimeSpan.FromMilliseconds(10));
                }
            }
            catch (Exception ex)
            {
                lock (_receiveStringValue)
                {
                    _receiveStringValue.Clear();
                }
                Console.WriteLine(string.Format("{0},{1}", ex.Message, ex.StackTrace));
                //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.StackTrace);
                return IORESULT.FAILED;
            }

        }

        public void ReceiveClear(byte end)
        {
            try
            {
                if (_receiveStringValue.Length > 0)
                {
                    lock (_receiveStringValue)
                    {
                        _endchar[0] = (char)end;
                        _temp = string.Empty;
                        _temp = _receiveStringValue.ToString();
                        int index = _temp.IndexOfAny(_endchar);
                        _receiveStringValue.Remove(0, index + 1);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ReceiveClear {0}", ex.Message);
            }
        }

        public void ReceiveAllClear()
        {
            try
            {
                if (_receiveStringValue.Length > 0)
                {
                    lock (_receiveStringValue)
                    {
                        _receiveStringValue.Clear();
                    }
                }


                if (_queReceive.Count > 0)
                {
                    lock (_queReceive)
                    {
                        _queReceive.Clear();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("ReceiveClear {0}", ex.Message);
            }
        }

        public void ReceiveClear(string end)
        {
            try
            {
                if (_receiveStringValue.Length > 0)
                {
                    lock (_receiveStringValue)
                    {
                        _temp = string.Empty;
                        _temp = _receiveStringValue.ToString();
                        int index = _temp.IndexOfAny(end.ToArray());
                        _receiveStringValue.Remove(0, index + end.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ReceiveClear {0}", ex.Message);
            }
        }

        public IORESULT Receive(ref string receive, string end, short timeOut)
        {
            if (_socket == null || _connectedStatus == CONNECTED_STATUS.DISCONNECTED)
                return IORESULT.FAILED;

            try
            {
                if (_stopWatch.IsRunning == true)
                {
                    _stopWatch.Stop();
                }
                _stopWatch.Reset();
                _stopWatch.Start();
                while (true)
                {
                    if (string.IsNullOrEmpty(end) == false)
                    {
                        lock (_receiveStringValue)
                        {
                            if (_receiveStringValue.ToString().Length > 0)
                            {
                                if (_receiveStringValue.ToString().Contains(end) == true)
                                {
                                    try
                                    {
                                        _temp = string.Empty;
                                        lock (_receiveStringValue)
                                        {
                                            _temp = _receiveStringValue.ToString();
                                        }
                                        int index = _temp.IndexOfAny(end.ToArray());
                                        receive = _temp.Substring(0, index);
                                        lock (_receiveStringValue)
                                        {
                                            _receiveStringValue.Remove(0, index + end.Length);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        lock (_receiveStringValue)
                                        {
                                            _receiveStringValue.Clear();
                                        }
                                        if (_stopWatch.IsRunning == true)
                                        {
                                            _stopWatch.Stop();
                                        }
                                        //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                                        //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.StackTrace);
                                        return IORESULT.FAILED;
                                    }

                                    return IORESULT.SUCCEEDED;
                                }
                            }
                        }
                    }
                    else
                    {
                        return IORESULT.SUCCEEDED;
                    }

                    if (_stopWatch.Elapsed.Seconds >= timeOut)
                    {
                        if (_stopWatch.IsRunning == true)
                        {
                            _stopWatch.Stop();
                        }
                        return IORESULT.TIMEOUT;
                    }

                    if (_socket == null || _connectedStatus == CONNECTED_STATUS.DISCONNECTED)
                    {
                        if (_stopWatch.IsRunning == true)
                        {
                            _stopWatch.Stop();
                        }
                        return IORESULT.FAILED;
                    }
                    Thread.Sleep(TimeSpan.FromMilliseconds(10));
                }
            }
            catch (Exception ex)
            {
                lock (_receiveStringValue)
                {
                    _receiveStringValue.Clear();
                }
                if (_stopWatch.IsRunning == true)
                {
                    _stopWatch.Stop();
                }
                //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.StackTrace);
                return IORESULT.FAILED;
            }

        }

        public IORESULT Send(string send, short timeOut)
        {
            IORESULT result = IORESULT.SUCCEEDED;

            if (_socket == null || _connectedStatus == CONNECTED_STATUS.DISCONNECTED)
                return IORESULT.FAILED;
            try
            {
                result = Send(Encoding.ASCII.GetBytes(send), 0, send.Length, timeOut);
            }
            catch (Exception ex)
            {
                //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.StackTrace);
                return IORESULT.FAILED;
            }

            return result;
        }
        Stopwatch swh = new Stopwatch();
        public IORESULT Send(string send, ref string receive, string end, short timeOut)
        {
            IORESULT result = IORESULT.SUCCEEDED;
            if (_socket == null || _connectedStatus == CONNECTED_STATUS.DISCONNECTED)
                return IORESULT.FAILED;

            try
            {
                swh.Restart();
                result = Send(Encoding.ASCII.GetBytes(send), 0, send.Length, timeOut);
                //Console.WriteLine("1.Send =========================================================================={0}", swh.ElapsedMilliseconds.ToString());
                if (result == IORESULT.SUCCEEDED)
                {
                    if (_stopWatch.IsRunning == true)
                    {
                        _stopWatch.Stop();
                    }
                    _stopWatch.Reset();
                    _stopWatch.Start();
                    while (true)
                    {
                        int length = 0;
                        lock (_receiveStringValue)
                        {
                            length = _receiveStringValue.ToString().Length;
                        }
                        if (length > 0)
                        {
                            if (string.IsNullOrEmpty(end) == false)
                            {
                                string temp = string.Empty;
                                lock (_receiveStringValue)
                                {
                                    temp = _receiveStringValue.ToString();
                                }
                                if (temp.Contains(end) == true)
                                {
                                    //Console.WriteLine("2.Receive =========================================================================={0}", swh.ElapsedMilliseconds.ToString());

                                    try
                                    {
                                        int index = temp.IndexOfAny(end.ToArray());
                                        receive = temp.Substring(0, index);
                                        lock (_receiveStringValue)
                                        {
                                            _receiveStringValue.Remove(0, index + end.Length);
                                        }
                                        //Console.WriteLine("3.Receive =========================================================================={0}", swh.ElapsedMilliseconds.ToString());
                                    }
                                    catch (Exception ex)
                                    {
                                        if (_stopWatch.IsRunning == true)
                                        {
                                            _stopWatch.Stop();
                                        }
                                        lock (_receiveStringValue)
                                        {
                                            _receiveStringValue.Clear();
                                        }
                                        //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                                        //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.StackTrace);
                                        result = IORESULT.FAILED;
                                    }
                                    //Console.WriteLine("4.Receive =========================================================================={0}", swh.ElapsedMilliseconds.ToString());
                                    return IORESULT.SUCCEEDED;
                                }
                            }
                            else
                            {
                                if (_stopWatch.IsRunning == true)
                                {
                                    _stopWatch.Stop();
                                }
                                lock (_receiveStringValue)
                                {
                                    receive = _receiveStringValue.ToString();
                                }
                                return IORESULT.SUCCEEDED;
                            }

                        }
                        else if (result == IORESULT.FAILED)
                        {
                            if (_stopWatch.IsRunning == true)
                            {
                                _stopWatch.Stop();
                            }
                            return IORESULT.FAILED;
                        }

                        if (_stopWatch.Elapsed.Seconds >= timeOut)
                        {
                            if (_stopWatch.IsRunning == true)
                            {
                                _stopWatch.Stop();
                            }
                            return IORESULT.TIMEOUT;
                        }

                        if (_socket == null || _connectedStatus == CONNECTED_STATUS.DISCONNECTED)
                        {
                            if (_stopWatch.IsRunning == true)
                            {
                                _stopWatch.Stop();
                            }
                            return IORESULT.FAILED;
                        }

                        Thread.Sleep(TimeSpan.FromMilliseconds(10));
                    }
                }
                else if (result == IORESULT.TIMEOUT)
                {
                    return IORESULT.TIMEOUT;
                }
            }
            catch (Exception ex)
            {
                lock (_receiveStringValue)
                {
                    _receiveStringValue.Clear();
                }
                //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.StackTrace);
                return IORESULT.FAILED;
            }

            return IORESULT.FAILED;
        }

        public IORESULT Send(string send, ref string receive, byte end, short timeOut)
        {
            IORESULT result = IORESULT.SUCCEEDED;

            if (_socket == null || _connectedStatus == CONNECTED_STATUS.DISCONNECTED)
                return IORESULT.FAILED;

            try
            {
                _endchar[0] = (char)end;
                result = Send(Encoding.ASCII.GetBytes(send), 0, send.Length, timeOut);
                if (result == IORESULT.SUCCEEDED)
                {
                    if (_stopWatch.IsRunning == true)
                    {
                        _stopWatch.Stop();
                    }
                    _stopWatch.Reset();
                    _stopWatch.Start();
                    while (true)
                    {
                        if (_receiveStringValue.ToString().Length > 0)
                        {
                            if (_receiveStringValue.ToString().Contains(_endchar[0]) == true)
                            {
                                try
                                {
                                    lock (_receiveStringValue)
                                    {
                                        _temp = string.Empty;
                                        _temp = _receiveStringValue.ToString();
                                        int index = _temp.IndexOfAny(_endchar);
                                        receive = _temp.Substring(0, index);
                                        _receiveStringValue.Remove(0, index + 1);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    if (_stopWatch.IsRunning == true)
                                    {
                                        _stopWatch.Stop();
                                    }
                                    lock (_receiveStringValue)
                                    {
                                        _receiveStringValue.Clear();
                                    }
                                    //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                                    //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.StackTrace);
                                    result = IORESULT.FAILED;
                                }

                                return IORESULT.SUCCEEDED;

                            }
                            else
                            {
                                if (_stopWatch.IsRunning == true)
                                {
                                    _stopWatch.Stop();
                                }
                                lock (_receiveStringValue)
                                {
                                    receive = _receiveStringValue.ToString();
                                }
                                return IORESULT.SUCCEEDED;
                            }
                        }
                        else if (result == IORESULT.FAILED)
                        {
                            if (_stopWatch.IsRunning == true)
                            {
                                _stopWatch.Stop();
                            }
                            return IORESULT.FAILED;
                        }
                        if (_stopWatch.Elapsed.Seconds >= timeOut)
                        {
                            if (_stopWatch.IsRunning == true)
                            {
                                _stopWatch.Stop();
                            }
                            return IORESULT.TIMEOUT;
                        }

                        if (_socket == null || _connectedStatus == CONNECTED_STATUS.DISCONNECTED)
                        {
                            if (_stopWatch.IsRunning == true)
                            {
                                _stopWatch.Stop();
                            }
                            return IORESULT.FAILED;
                        }

                        Thread.Sleep(TimeSpan.FromMilliseconds(10));
                    }
                }
                else if (result == IORESULT.TIMEOUT)
                {
                    return IORESULT.TIMEOUT;
                }
            }
            catch (Exception ex)
            {
                _receiveStringValue.Clear();
                //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.StackTrace);
                return IORESULT.FAILED;
            }
            return IORESULT.FAILED;
        }

        private IORESULT Send(byte[] buffer, int offset, int size, int timeout)
        {
            if (_stopWatch.IsRunning == true)
            {
                _stopWatch.Stop();
            }
            _stopWatch.Reset();
            _stopWatch.Start();
            //lock (_socket)
            //{
            int sent = 0;
            try
            {
                do
                {
                    try
                    {
                        sent += _socket.Send(buffer, offset + sent, size - sent, SocketFlags.None);
                    }
                    catch (SocketException ex)
                    {
                        if (ex.SocketErrorCode == SocketError.WouldBlock ||
                            ex.SocketErrorCode == SocketError.IOPending ||
                            ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                        {
                            Thread.Sleep(30);
                        }
                        else
                        {
                            if (_stopWatch.IsRunning == true)
                            {
                                _stopWatch.Stop();
                            }
                            SocketClose();
                            _isConnected = false;
                            //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                            //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.StackTrace);
                            return IORESULT.FAILED;
                        }
                    }
                    if (_stopWatch.Elapsed.Seconds >= timeout)
                    {
                        if (_stopWatch.IsRunning == true)
                        {
                            _stopWatch.Stop();
                        }
                        return IORESULT.TIMEOUT;
                    }
                } while (sent < size);
            }
            catch (Exception ex)
            {
                if (_stopWatch.IsRunning == true)
                {
                    _stopWatch.Stop();
                }
                //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.StackTrace);
                return IORESULT.FAILED;
            }
            // }
            return IORESULT.SUCCEEDED;
        }

        public IORESULT Send(byte[] sendData,int timeOut = 0)
        {
            try
            {
                if (IsStructure == true)
                {
                    if (_clientStream == null || _connectedStatus == CONNECTED_STATUS.DISCONNECTED)
                        return IORESULT.FAILED;

                    if (_clientStream.CanWrite)
                    {
                        _clientStream.Write(sendData, 0, sendData.Length);
                    }
                    else return IORESULT.FAILED;
                }
                else
                {
                    IORESULT result = Send(sendData, 0, sendData.Length, timeOut);
                    if (result == IORESULT.SUCCEEDED)
                    {
                    }
                    else
                    {
                        return IORESULT.FAILED;
                    }
                }
            }
            catch (SocketException ex)
            {
                //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.StackTrace);
                return IORESULT.FAILED;
            }
            return IORESULT.SUCCEEDED;
        }

        public IORESULT Receive(ref byte[] receiveData, short timeOut)
        {
            try
            {
                if (_stopWatch.IsRunning == true)
                {
                    _stopWatch.Stop();
                }
                _stopWatch.Reset();
                _stopWatch.Start();
                while (true)
                {
                    lock (_queReceive)
                    {
                        if (_queReceive.Count > 0)
                        {
                            receiveData = _queReceive.Dequeue();
                            return IORESULT.SUCCEEDED;
                        }
                    }
                    if (_stopWatch.Elapsed.Seconds >= timeOut)
                    {
                        if (_stopWatch.IsRunning == true)
                        {
                            _stopWatch.Stop();
                        }
                        return IORESULT.TIMEOUT;
                    }

                    if (_connectedStatus == CONNECTED_STATUS.DISCONNECTED)
                    {
                        if (_stopWatch.IsRunning == true)
                        {
                            _stopWatch.Stop();
                        }
                        return IORESULT.FAILED;
                    }

                    Thread.Sleep(TimeSpan.FromMilliseconds(10));
                }
            }
            catch (Exception ex)
            {
                if (_stopWatch.IsRunning == true)
                {
                    _stopWatch.Stop();
                }
                //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.StackTrace);
                return IORESULT.FAILED;
            }
        }
        public IORESULT Receive(ref byte[] receiveData)
        {
            try
            {
                lock (_queReceive)
                {
                    if (_queReceive.Count > 0)
                    {
                        receiveData = _queReceive.Dequeue();
                    }
                    else
                    {
                        return IORESULT.FAILED;
                    }
                }
            }
            catch (SocketException ex)
            {
                //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.StackTrace);
                return IORESULT.FAILED;
            }
            return IORESULT.SUCCEEDED;
        }

        private void ReceiveStructure()
        {
            byte[] buffer = new byte[700000];
            int receiveLength = 0;
            while (true)
            {
                try
                {
                    if (_client != null && _isConnected == true)
                    {
                        if (_clientStream != null)
                        {
                            if (_clientStream.CanRead)
                            {
                                try
                                {
                                    do
                                    {
                                        receiveLength = _clientStream.Read(buffer, 0, buffer.Length);
                                        if (receiveLength > 0)
                                        {
                                            lock (_queReceive)
                                            {
                                                _queReceive.Enqueue(buffer);
                                            }
                                        }
                                    } while (_clientStream.DataAvailable == true);
                                }
                                catch (Exception ex)
                                {
                                    //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                                }
                            }
                        }
                    }
                }
                catch (SocketException ex)
                {
                    //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                    return;
                }
                  Thread.Sleep(TimeSpan.FromMilliseconds(10));
            }
        }

        private void Receive()
        {
            int receiveLenth = 0;
            byte[] buffer = new byte[8096];
            while (true)
            {
                try
                {
                    if (_socket != null && _isConnected == true)
                    {
                        receiveLenth = 0;
                        receiveLenth += _socket.Receive(buffer);
                        if (receiveLenth > 0)
                        {
                            string str = Encoding.UTF8.GetString(buffer, 0, receiveLenth);
                            if (IsLog == true)
                            {
                                Console.WriteLine("1.========> Receive Data : {0}", str.ToString());
                            }
                            if (str.Length > 0)
                            {
                                if (IsReceiveString == true)
                                {
                                    lock (_receiveStringValue)
                                    {
                                        _receiveStringValue.Append(str);
                                    }
                                }
                                else
                                {
                                    lock (_queReceive)
                                    {
                                        _queReceive.Enqueue(buffer);
                                    }
                                }
                                if (IsLog == true)
                                {
                                    Console.WriteLine("2.========> Receive Data : {0}", _receiveStringValue.ToString());
                                }
                            }
                        }

                        if (receiveLenth == 0 && _isConnected == false)
                            return;
                    }
                }
                catch (SocketException ex)
                {
                    if (_socket != null)
                    {
                        lock (_socket)
                        {
                            //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                            SocketClose();
                            _isConnected = false;
                        }
                    }
                    return;
                }
                Thread.Sleep(TimeSpan.FromMilliseconds(10));
            }
        }

        private void SocketClose()
        {
            try
            {
                if (_socket != null)
                {
                    lock (_socket)
                    {
                        _connectedStatus = CONNECTED_STATUS.DISCONNECTED;
                        if (_serverClient == SERVER_CLIENT.Server)
                        {
                            _socket.Shutdown(SocketShutdown.Both);
                        }
                        _socket.Close();
                        _socket = null;
                        //ConsoleEx.WriteLine("[Info]-> Close Socket");
                    }
                }
            }
            catch (Exception ex)
            {
                //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.Message);
                //ConsoleEx.WriteLineToConsoleAndFile("[Exception]->" + ex.StackTrace);
            }
        }
    }
}
