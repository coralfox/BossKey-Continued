using System;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace BossKey
{
    class Password
    {
        public static string cpuid = "";
        public static string GetCpuID()
        {
            try
            {
                string cpuInfo = "";//cpu序列号
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                }
                moc = null;
                mc = null;
                return cpuInfo;
            }
            catch
            {
                return "unknow";
            }

            finally { }
        }

        public static string encrypt(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes($"{cpuid}{str}"));
            return BitConverter.ToString(s).Replace("-", "").ToLower();
        }

    }
}
