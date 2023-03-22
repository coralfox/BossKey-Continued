using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace BossKey
{
    internal static class Program
    {


        public static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            foreach (Process process in processes)
            {
                if (process.Id != current.Id)
                {
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        return process;
                    }
                }
            }
            return null;
        }

        public static void HandleRunningInstance(Process Instance)
        {
            //ShowWindowAsync(Instance.MainWindowHandle, 3);
            //SetForegroundWindow(Instance.MainWindowHandle);
        }


        /// <summary>
        /// 应用程序的主入口点。
        /// 默认同时只能开一套程序
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Process Instance = RunningInstance();
            if (Instance == null)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm(args));
            }
            else
            {
                HandleRunningInstance(Instance);
            }
        }
    }
}
