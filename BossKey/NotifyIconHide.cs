using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace BossKey
{
    public class NotifyIconHide
    {
        public const int WM_USER = 0x400;

        public const int STANDARD_RIGHTS_REQUIRED = 0xF0000;
        public const int SYNCHRONIZE = 0x100000;
        public const int PROCESS_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0xFFF;


        public const int PROCESS_VM_OPERATION = 0x8;
        public const int PROCESS_VM_READ = 0x10;
        public const int PROCESS_VM_WRITE = 0x20;

        public const int MEM_RESERVE = 0x2000;
        public const int MEM_COMMIT = 0x1000;
        public const int MEM_RELEASE = 0x8000;

        public const int PAGE_READWRITE = 0x4;

        public const int TB_BUTTONCOUNT = (WM_USER + 24);
        public const int TB_HIDEBUTTON = (WM_USER + 4);
        public const int TB_GETBUTTON = (WM_USER + 23);
        public const int TB_GETBUTTONTEXT = WM_USER + 75;
        public const int TB_GETBITMAP = (WM_USER + 44);
        public const int TB_DELETEBUTTON = (WM_USER + 22);
        public const int TB_ADDBUTTONS = (WM_USER + 20);
        public const int TB_INSERTBUTTON = (WM_USER + 21);
        public const int TB_ISBUTTONHIDDEN = (WM_USER + 12);
        public const int ILD_NORMAL = 0x0;
        public const int TPM_NONOTIFY = 0x80;

        public const int WS_VISIBLE = 268435456;//窗体可见
        public const int WS_MINIMIZEBOX = 131072;//有最小化按钮
        public const int WS_MAXIMIZEBOX = 65536;//有最大化按钮
        public const int WS_BORDER = 8388608;//窗体有边框
        public const int GWL_STYLE = (-16);//窗体样式
        public const int GW_HWNDFIRST = 0;
        public const int GW_HWNDNEXT = 2;
        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;

        [DllImport("kernel32", EntryPoint = "OpenProcess")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, IntPtr bInheritHandle, IntPtr dwProcessId);

        [DllImport("kernel32", EntryPoint = "CloseHandle")]
        public static extern int CloseHandle(IntPtr hObject);

        [DllImport("user32", EntryPoint = "GetWindowThreadProcessId")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hwnd, ref IntPtr lpdwProcessId);



        [DllImport("user32", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);

        [DllImport("kernel32", EntryPoint = "ReadProcessMemory")]
        public static extern int ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref IntPtr lpBuffer, int nSize, int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory")]
        public static extern bool ReadProcessMemoryEx(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int nSize, ref uint vNumberOfBytesRead);

        [DllImport("kernel32", EntryPoint = "ReadProcessMemory")]
        public static extern int ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, int lpNumberOfBytesWritten);



        [DllImport("kernel32", EntryPoint = "VirtualAllocEx")]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, int lpAddress, int dwSize, int flAllocationType, int flProtect);

        [DllImport("kernel32", EntryPoint = "VirtualFreeEx")]
        public static extern int VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, int dwFreeType);







        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);




        public enum NotifyIconMessage : uint
        {
            NIM_ADD = 0x00000000,
            NIM_MODIFY = 0x00000001,
            NIM_DELETE = 0x00000002,
            NIM_SETFOCUS = 0x00000003,
            NIM_SETVERSION = 0x00000004,
        }
        public const int NIS_HIDDEN = 0x01;
        public const int NIS_SHAREDICON = 0x02;
        public enum NotifyFlags { Message = 0x01, Icon = 0x02, Tip = 0x04, Info = 0x10, State = 0x08 }
        [StructLayout(LayoutKind.Sequential)]
        public struct NotifyIconData
        {
            public System.Int32 cbSize; // DWORD
            public System.IntPtr hWnd; // HWND
            public System.Int32 uID; // UINT
            public NotifyFlags uFlags; // UINT
            public System.Int32 uCallbackMessage; // UINT
            public System.IntPtr hIcon; // HICON
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public System.String szTip; // char[128]
            public System.Int32 dwState; // DWORD
            public System.Int32 dwStateMask; // DWORD
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public System.String szInfo; // char[256]
            public System.Int32 uTimeoutOrVersion; // UINT
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public System.String szInfoTitle; // char[64]
            public System.Int32 dwInfoFlags; // DWORD
                                             //GUID guidItem; > IE 6
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TRAYDATA
        {
            public IntPtr hwnd;
            public uint uID;
            public uint uCallbackMessage;
            public int Reserved0;
            public int Reserved1;
            public IntPtr hIcon; //托盘图标的句柄
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct TBBUTTON32
        {
            public int iBitmap;
            public int idCommand;
            public byte fsState;
            public byte fsStyle;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] bReserved;
            public uint dwData;
            public int iString;
        }
        public struct TBBUTTON
        {
            public int iBitmap;
            public int idCommand;
            public byte fsState;
            public byte fsStyle;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] bReserved;
            public uint dwData;
            public int iString;
        }

        //Environment.Is64BitOperatingSystem;
        [DllImport("shell32.dll")]
        public static extern bool Shell_NotifyIcon(uint dwMessage, [In] ref NotifyIconData pnid);


        private static IntPtr FindNotifyIconOverflowWindow()
        {
            IntPtr hWnd = IntPtr.Zero;

            hWnd = FindWindow("NotifyIconOverflowWindow", null);
            hWnd = FindWindowEx(hWnd, IntPtr.Zero, "ToolbarWindow32", null);

            return hWnd;
        }
        //获取托盘指针
        private static IntPtr TrayToolbarWindow32()
        {
            IntPtr h = IntPtr.Zero;
            IntPtr hTemp = IntPtr.Zero;

            h = FindWindow("Shell_TrayWnd", null); //托盘容器
            h = FindWindowEx(h, IntPtr.Zero, "TrayNotifyWnd", null);//找到托盘
            h = FindWindowEx(h, IntPtr.Zero, "SysPager", null);

            hTemp = FindWindowEx(h, IntPtr.Zero, "ToolbarWindow32", null);

            return hTemp;
        }


        //获取托盘图标列表
        public static void SetNotifyIconVisiable(List<string> FilePaths, bool isShow)
        {
            var is64OS = Environment.Is64BitOperatingSystem;
            try
            {


                IntPtr pid = IntPtr.Zero;
                IntPtr ipHandle = IntPtr.Zero; //图标句柄
                IntPtr lTextAdr = IntPtr.Zero; //文本内存地址

                IntPtr ipTray = TrayToolbarWindow32();

                GetWindowThreadProcessId(ipTray, ref pid);
                if (!pid.Equals(0))
                {

                    IntPtr hProcess = OpenProcess(PROCESS_ALL_ACCESS | PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE, IntPtr.Zero, pid);
                    IntPtr lAddress = VirtualAllocEx(hProcess, 0, 4096, MEM_COMMIT, PAGE_READWRITE);

                    //得到图标个数
                    int lButton = SendMessage(ipTray, TB_BUTTONCOUNT, 0, 0);

                    for (int i = 0; i < lButton; i++)
                    {
                        SendMessage(ipTray, TB_GETBUTTON, i, lAddress);


                        //读文本地址
                        ReadProcessMemory(hProcess, lAddress + 16, ref lTextAdr, 4, 0);

                        if (!lTextAdr.Equals(-1))
                        {
                            byte[] buff = new byte[1024];

                            ReadProcessMemory(hProcess, lTextAdr + 48, buff, 1024, 0);//读文本
                            string title = System.Text.ASCIIEncoding.Unicode.GetString(buff, 0, 1024);

                            // 从字符0处截断
                            int nullindex = title.IndexOf("\0");
                            if (nullindex > 0)
                            {
                                title = title.Substring(0, nullindex);
                            }
                            if (FilePaths.Contains(title))
                            {

                                uint dwData = 0;
                                uint vNumberOfBytesRead = 0;
                                if (is64OS)
                                {
                                    var tb = new TBBUTTON();

                                    IntPtr ptb = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TBBUTTON)));

                                    Marshal.StructureToPtr(tb, ptb, true);
                                    ReadProcessMemoryEx(hProcess, lAddress, ptb, Marshal.SizeOf(typeof(TBBUTTON)), ref vNumberOfBytesRead);
                                    tb = (TBBUTTON)Marshal.PtrToStructure(ptb, typeof(TBBUTTON));
                                    Marshal.FreeHGlobal(ptb);
                                    dwData = tb.dwData;
                                }
                                else
                                {
                                    var tb = new TBBUTTON32();
                                    IntPtr ptb = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TBBUTTON32)));

                                    Marshal.StructureToPtr(tb, ptb, true);
                                    ReadProcessMemoryEx(hProcess, lAddress, ptb, Marshal.SizeOf(typeof(TBBUTTON32)), ref vNumberOfBytesRead);
                                    tb = (TBBUTTON32)Marshal.PtrToStructure(ptb, typeof(TBBUTTON32));
                                    Marshal.FreeHGlobal(ptb);
                                    dwData = tb.dwData;
                                }

                                TRAYDATA trayData = new TRAYDATA();

                                IntPtr ptrayData = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TRAYDATA)));

                                Marshal.StructureToPtr(trayData, ptrayData, true);

                                ReadProcessMemoryEx(hProcess, (IntPtr)dwData, ptrayData, Marshal.SizeOf(typeof(TRAYDATA)), ref vNumberOfBytesRead);
                                trayData = (TRAYDATA)Marshal.PtrToStructure(ptrayData, typeof(TRAYDATA));
                                Marshal.FreeHGlobal(ptrayData);
                                NotifyIconData nid = new NotifyIconData();

                                nid.cbSize = Marshal.SizeOf(typeof(NotifyIconData));
                                nid.hWnd = trayData.hwnd;
                                nid.uID = (int)trayData.uID;
                                nid.uFlags = NotifyFlags.State;
                                nid.dwState = isShow ? NIS_SHAREDICON : NIS_HIDDEN;
                                nid.dwStateMask = NIS_HIDDEN;
                                Shell_NotifyIcon((uint)NotifyIconMessage.NIM_MODIFY, ref nid);

                                /*
                                 
                                 IntPtr lngButtonID = new IntPtr(0);
                                ReadProcessMemory(hProcess, lAddress + 4, ref lngButtonID, 4, 0);
                                 if (isShow)
                                {
                                    SendMessage(ipTray, TB_HIDEBUTTON, lngButtonID.ToInt32(), 0);
                                }
                                else
                                {
                                    SendMessage(ipTray, TB_HIDEBUTTON, lngButtonID.ToInt32(), 1);
                                    //SendMessage(ipTray, TB_DELETEBUTTON, i, 0);
                                    //SendMessage(new IntPtr(HWND_BROADCAST), WM_SETTINGCHANGE, 0, 0);
                                }*/
                            }

                        }
                    }
                    VirtualFreeEx(hProcess, lAddress, 4096, MEM_RELEASE);
                    CloseHandle(hProcess);
                }
            }
            catch
            {

            }

            try
            {

                IntPtr pid = IntPtr.Zero;
                IntPtr ipHandle = IntPtr.Zero; //图标句柄
                IntPtr lTextAdr = IntPtr.Zero; //文本内存地址

                IntPtr ipTray = FindNotifyIconOverflowWindow();

                GetWindowThreadProcessId(ipTray, ref pid);
                if (!pid.Equals(0))
                {

                    IntPtr hProcess = OpenProcess(PROCESS_ALL_ACCESS | PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE, IntPtr.Zero, pid);
                    IntPtr lAddress = VirtualAllocEx(hProcess, 0, 4096, MEM_COMMIT, PAGE_READWRITE);

                    //得到图标个数
                    int lButton = SendMessage(ipTray, TB_BUTTONCOUNT, 0, 0);

                    for (int i = 0; i < lButton; i++)
                    {
                        SendMessage(ipTray, TB_GETBUTTON, i, lAddress);

                        //读文本地址
                        ReadProcessMemory(hProcess, lAddress + 16, ref lTextAdr, 4, 0);

                        if (!lTextAdr.Equals(-1))
                        {
                            byte[] buff = new byte[1024];

                            ReadProcessMemory(hProcess, lTextAdr + 48, buff, 1024, 0);//读文本
                            string title = System.Text.ASCIIEncoding.Unicode.GetString(buff, 0, 1024);

                            // 从字符0处截断
                            int nullindex = title.IndexOf("\0");
                            if (nullindex > 0)
                            {
                                title = title.Substring(0, nullindex);
                            }
                            if (FilePaths.Contains(title))
                            {

                                uint dwData = 0;
                                uint vNumberOfBytesRead = 0;
                                if (is64OS)
                                {
                                    var tb = new TBBUTTON();

                                    IntPtr ptb = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TBBUTTON)));

                                    Marshal.StructureToPtr(tb, ptb, true);
                                    ReadProcessMemoryEx(hProcess, lAddress, ptb, Marshal.SizeOf(typeof(TBBUTTON)), ref vNumberOfBytesRead);
                                    tb = (TBBUTTON)Marshal.PtrToStructure(ptb, typeof(TBBUTTON));
                                    Marshal.FreeHGlobal(ptb);
                                    dwData = tb.dwData;
                                }
                                else
                                {
                                    var tb = new TBBUTTON32();
                                    IntPtr ptb = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TBBUTTON32)));

                                    Marshal.StructureToPtr(tb, ptb, true);
                                    ReadProcessMemoryEx(hProcess, lAddress, ptb, Marshal.SizeOf(typeof(TBBUTTON32)), ref vNumberOfBytesRead);
                                    tb = (TBBUTTON32)Marshal.PtrToStructure(ptb, typeof(TBBUTTON32));
                                    Marshal.FreeHGlobal(ptb);
                                    dwData = tb.dwData;
                                }

                                TRAYDATA trayData = new TRAYDATA();

                                IntPtr ptrayData = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TRAYDATA)));

                                Marshal.StructureToPtr(trayData, ptrayData, true);

                                ReadProcessMemoryEx(hProcess, (IntPtr)dwData, ptrayData, Marshal.SizeOf(typeof(TRAYDATA)), ref vNumberOfBytesRead);
                                trayData = (TRAYDATA)Marshal.PtrToStructure(ptrayData, typeof(TRAYDATA));
                                Marshal.FreeHGlobal(ptrayData);
                                NotifyIconData nid = new NotifyIconData();

                                nid.cbSize = Marshal.SizeOf(typeof(NotifyIconData));
                                nid.hWnd = trayData.hwnd;
                                nid.uID = (int)trayData.uID;
                                nid.uFlags = NotifyFlags.State;
                                nid.dwState = isShow ? NIS_SHAREDICON : NIS_HIDDEN;
                                nid.dwStateMask = NIS_HIDDEN;
                                Shell_NotifyIcon((uint)NotifyIconMessage.NIM_MODIFY, ref nid);
                                /*
                                IntPtr lngButtonID = new IntPtr(0);
                                ReadProcessMemory(hProcess, lAddress + 4, ref lngButtonID, 4, 0);
                                 if (isShow)
                                {
                                    SendMessage(ipTray, TB_HIDEBUTTON, lngButtonID.ToInt32(), 0);
                                }
                                else
                                {
                                    SendMessage(ipTray, TB_HIDEBUTTON, lngButtonID.ToInt32(), 1);
                                    //SendMessage(ipTray, TB_DELETEBUTTON, i, 0);
                                    //SendMessage(new IntPtr(HWND_BROADCAST), WM_SETTINGCHANGE, 0, 0);
                                }*/
                            }

                        }
                    }
                    VirtualFreeEx(hProcess, lAddress, 4096, MEM_RELEASE);
                    CloseHandle(hProcess);
                }
            }
            catch
            {

            }


        }
    }
}
