using System.Collections.Generic;

namespace BossKey
{
    public class SystemConfig
    {
        public List<string> AppPaths;
        public string ShortcutKey_Boss;
        public string ShortcutKey_App;
        public bool AutoStart;
        public bool AutoHide;
        public bool ScanPorcess;
        public int ScanProcessInterval;
        public bool Mute;
        public bool OpenFile;
        public string OpenFilePath;
        public bool EnablePassword;
        public string Password;
        public bool EnableHook;
        public bool IdleHiden;
        public int IdleTime;
    }
}
