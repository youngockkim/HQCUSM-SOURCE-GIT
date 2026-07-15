using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Miracom.MESCore
{
    public class NetConnection
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        //[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NETRESOURCE
        {
            public uint dwScope;
            public uint dwType;
            public uint dwDisplayType;
            public uint dwUsage;
            public string lpLocalName;
            public string lpRemoteName;
            public string lpComment;
            public string lpProvider;
        }

        [DllImport("mpr.dll", CharSet = CharSet.Auto)]
        //[DllImport("mpr.dll", CharSet = CharSet.Ansi)]
        public static extern int WNetUseConnection(
                    IntPtr hwndOwner,
                    [MarshalAs(UnmanagedType.Struct)] ref NETRESOURCE lpNetResource,
                    string lpPassword,
                    string lpUserID,
                    uint dwFlags,
                    StringBuilder lpAccessName,
                    ref int lpBufferSize,
                    out uint lpResult);

        [DllImport("mpr.dll", EntryPoint="WNetCancelConnection2",CharSet=CharSet.Auto)]
        //[DllImport("mpr.dll", EntryPoint = "WNetCancelConnection2", CharSet = CharSet.Ansi)]
        public static extern int WNetCancelConnection2A(string lpName, int dwFlag, int fForce);

        public static void ConnectNetDrive(string sharePath, string userID, string passWord)
        {
            int capacity = 64;
            uint resultFlags = 0;
            uint flags = 0;
            System.Text.StringBuilder sb = new System.Text.StringBuilder(capacity);
            NETRESOURCE ns = new NETRESOURCE();
            ns.dwType = 1;           // 공유 디스크
            ns.lpLocalName = null;   // 로컬 드라이브 지정하지 않음, null
            ns.lpRemoteName = sharePath;
            ns.lpProvider = null;

            int result = WNetUseConnection(IntPtr.Zero, ref ns, passWord, userID, flags, sb, ref capacity, out resultFlags);

            switch (result)
            {
                case 0: //연결 OK 
                    break;
                case 5:
                    throw new Exception("엑세스가 거부되었습니다.");
                case 53:
                    throw new Exception("네트웍크 경로를 찾을수 없습니다.");
                case 58:
                    throw new Exception("The specified server cannot perform the requested operation.");
                case 85:
                    throw new Exception("지정한 로컬드라이브는 사용중입니다.");
                case 86:
                    throw new Exception("The specified network password is not correct.");
                case 87:
                    throw new Exception("매개변수가 틀립니다.");
                case 1200:
                    throw new Exception("지정한 장치 이름이 올바르지 않습니다.");
                case 1203:
                    throw new Exception("공유폴더 경로에러.");
                case 1326:
                    throw new Exception("사용자ID/Password 에러.");
                case 234:
                    throw new Exception("공유폴더의 경로를 담을 크기가 적습니다. (capacity)");
                case 1237:
                    throw new Exception("작업을 마치지 못했습니다. 다시시도하십시오");
                case 1219:
                    throw new Exception("동일한 사용자가 둘 이상의 사용자 이름으로 공유 리소스에 다중 연결할 수 없습니다.");
                default:
                    throw new Exception("에러가 발생하였습니다." + result);
            }
        }
    }
}
