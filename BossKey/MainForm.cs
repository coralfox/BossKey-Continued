using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BossKey
{
    public partial class MainForm : Form
    {
        string _shortcutkey_boss;
        string _shortcutkey_app;
        public SystemConfig Config = new SystemConfig();
        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);

        public delegate bool EnumThreadWindowsCallback(IntPtr hWnd, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool EnumWindows(EnumThreadWindowsCallback callback, int extraData);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int EnumChildWindows(IntPtr hWndParent, CallBack lpfn, int lParam);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);
        const uint WM_APPCOMMAND = 0x319;
        const uint APPCOMMAND_VOLUME_UP = 0x0a;
        const uint APPCOMMAND_VOLUME_DOWN = 0x09;
        const uint APPCOMMAND_VOLUME_MUTE = 0x08;


        // 创建结构体用于返回捕获时间
        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            // 设置结构体块容量
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            // 捕获的时间
            [MarshalAs(UnmanagedType.U4)]
            public uint dwTime;
        }
        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
        // 获取键盘和鼠标没有操作的时间
        private static long GetLastInputTime()
        {
            LASTINPUTINFO vLastInputInfo = new LASTINPUTINFO();
            vLastInputInfo.cbSize = Marshal.SizeOf(vLastInputInfo);
            // 捕获时间
            if (!GetLastInputInfo(ref vLastInputInfo))
                return 0;
            else
                return Environment.TickCount - vLastInputInfo.dwTime;
        }




        public delegate bool CallBack(IntPtr hwnd, int lParam);

        bool EnumChildWindowCallBack(IntPtr hWnd, int lParam)
        {
            int dwPid = 0;
            GetWindowThreadProcessId(hWnd, out dwPid); // 获得找到窗口所属的进程
            if (dwPid == lParam) // 判断是否是目标进程的窗口
            {
                if (IsWindowVisible(hWnd)) phandle.Add(hWnd);
                EnumChildWindows(hWnd, EnumChildWindowCallBack, lParam);    // 递归查找子窗口
            }
            return true;

        }

        bool EnumWindowCallBack(IntPtr hWnd, int lParam)
        {
            int dwPid = 0;
            GetWindowThreadProcessId(hWnd, out dwPid); // 获得找到窗口所属的进程
            if (dwPid == lParam) // 判断是否是目标进程的窗口
            {
                if (IsWindowVisible(hWnd)) phandle.Add(hWnd);
                //EnumChildWindows(hWnd, EnumChildWindowCallBack, lParam);    // 继续查找子窗口
            }
            return true;
        }


        [DllImport("shell32.dll")]
        public static extern int ExtractIconEx(string lpszFile, int niconIndex, IntPtr[] phiconLarge, IntPtr[] phiconSmall, int nIcons);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);
        int GetICON(string appPath)
        {
            imageList1.Images.Add(Icon.ExtractAssociatedIcon(appPath));
            return imageList1.Images.Count - 1;
        }

        private bool AutoStart = false;
        private bool AutoHide = false;
        private GlobalHook hook;
        public MainForm(string[] args)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            if (args.ToList().Contains("AutoStart")) AutoStart = true;
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
        }


        private void GetALLProcesses()
        {
            new Task(() =>
            {
                imageList1.Images.Clear();
                list_process.Items.Clear();
                //GetICON("%SystemRoot%\\system32\\shell32.dll");
                Process[] processes = Process.GetProcesses();
                list_process.BeginUpdate();
                foreach (Process p in processes.OrderBy(m => m.ProcessName))
                {
                    try
                    {
                        //var x = new ListViewItem(Text)
                        var x = new ListViewItem(p.MainModule.FileName);
                        x.ImageIndex = GetICON(p.MainModule.FileName);
                        x.SubItems.Add(p.MainWindowTitle);
                        x.SubItems.Add(p.Id.ToString());
                        //x.SubItems.Add(p.MainModule.FileName);
                        if (Config.AppPaths.Contains(p.MainModule.FileName)) x.Checked = true;
                        list_process.Items.Add(x);
                    }
                    catch
                    {
                        //if(list_process.Items.Count!=0) list_process.Items.RemoveAt(list_process.Items.Count - 1);
                    }
                }
                list_process.EndUpdate();

                if (AutoHide)
                {
                    btn_hiden_Click(null, null);
                }

            }).Start();
        }

        private void txt_bosskey_KeyDown(object sender, KeyEventArgs e)
        {
            var obj = (TextBox)sender;
            obj.Text = "";
            if (e.Alt)
            {
                obj.Text += "Alt";
            }
            if (e.Control)
            {
                if (obj.Text != "") obj.Text += " + ";
                obj.Text += "Ctrl";
            }
            if (e.Shift)
            {
                if (obj.Text != "") obj.Text += " + ";
                obj.Text += "Shift";
            }
            if (e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.Menu && e.KeyCode != Keys.ShiftKey)
            {
                if (obj.Text != "") obj.Text += " + ";
                obj.Text += e.KeyCode;
            }


            if (e.KeyCode == Keys.Escape)
            {
                switch (obj.Name)
                {
                    case "txt_bosskey": obj.Text = _shortcutkey_boss; break;
                    case "txt_appkey": obj.Text = _shortcutkey_app; break;
                }
            }
        }
        List<string> process = new List<string>();
        List<int> process_id = new List<int>();
        List<IntPtr> phandle = new List<IntPtr>();
        bool isshow = true;

        /// <summary>
        /// 是否在加载状态
        /// </summary>
        bool isload = true;

        PasswordForm pf = new PasswordForm();

        CancellationTokenSource tokenSource;
        CancellationToken token;
        private void btn_hiden_Click(object sender, EventArgs e)
        {
            try
            {
                if (isshow)
                {
                    phandle.Clear();
                    process_id.Clear();

                    for (var i = 0; i < process.Count; i++)
                    {
                        var pname = process[i];
                        pname = pname.Substring(pname.LastIndexOf('\\') + 1);
                        pname = pname.Substring(0, pname.LastIndexOf("."));
                        Process[] ps = Process.GetProcessesByName(pname);
                        foreach (var p in ps)
                        {
                            try
                            {
                                if (p.MainModule.FileName == process[i]) process_id.Add(p.Id);
                            }
                            catch
                            {

                            }
                        }
                    }
                    foreach (var id in process_id)
                    {
                        EnumWindows(EnumWindowCallBack, id);
                    }

                    foreach (var h in phandle)
                    {
                        ShowWindow(h, 0);
                    }
                    NotifyIconHide.SetNotifyIconVisiable(process, false);
                    if (Config.Mute)
                    {
                        //SendMessage(this.Handle, WM_APPCOMMAND, 0x200eb0, APPCOMMAND_VOLUME_MUTE * 0x10000);
                        for (var i = 0; i < 50; i++)
                        {
                            SendMessage(this.Handle, WM_APPCOMMAND, 0x200eb0, APPCOMMAND_VOLUME_DOWN * 0x10000);
                        }
                    }
                    if (Config.OpenFile)
                    {
                        Process.Start(Config.OpenFilePath);
                    }

                    isshow = false;
                }
                else
                {

                    foreach (var h in phandle)
                    {
                        ShowWindow(h, 1);
                    }
                    NotifyIconHide.SetNotifyIconVisiable(process, true);
                    if (Config.Mute)
                    {
                        /*SendMessage(this.Handle, WM_APPCOMMAND, 0x200eb0, APPCOMMAND_VOLUME_MUTE * 0x10000);
                        for (var i = 0; i < 50; i++)
                        {
                            SendMessage(this.Handle, WM_APPCOMMAND, 0x200eb0, APPCOMMAND_VOLUME_DOWN * 0x10000);
                        }*/
                    }
                    isshow = true;
                }
            }
            catch
            {

            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            try
            {
                if (cb_autostart.Checked == true)
                {
                    RegistryKey R_local = Registry.CurrentUser;//RegistryKey R_local = Registry.CurrentUser;
                    RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                    R_run.SetValue("BossKey", Application.ExecutablePath + " AutoStart");
                    R_run.Close();
                    R_local.Close();
                }
                else
                {
                    RegistryKey R_local = Registry.CurrentUser;//RegistryKey R_local = Registry.CurrentUser;
                    RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                    R_run.DeleteValue("BossKey", false);
                    R_run.Close();
                    R_local.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("您需要管理员权限方能修改系统启动项！", "提示");
                return;
            }


            process.Clear();

            for (var i = 0; i < list_process.CheckedItems.Count; i++)
            {
                if (list_process.CheckedItems[i].Checked)
                {
                    process.Add(list_process.CheckedItems[i].SubItems[0].Text);
                }
            }
            Config.AppPaths = process;
            Config.AutoStart = cb_autostart.Checked;
            Config.AutoHide = cb_autohide.Checked;
            Config.ScanPorcess = cb_scanprocess.Checked;
            Config.ScanProcessInterval = (int)nud_scanprocess_interval.Value;
            Config.Mute = cb_mute.Checked;
            Config.OpenFilePath = txt_filepath.Text;
            Config.OpenFile = cb_openfile.Checked;
            Config.EnablePassword = cb_password.Checked;
            Config.EnableHook = cb_hook.Checked;
            Config.IdleHiden = cb_idlehiden.Checked;
            Config.IdleTime = (int)nud_idletime.Value;
            SaveShortcutKeyConfig(txt_bosskey.Text, cb_bosskey.Checked ? txt_bosskey.Text : txt_appkey.Text);
            UnRegisterShortcutKeyConfig();
            RegisterShortcutKeyConfig();

        }


        private void RegisterHotKey(string KeyName, string Keys, int KeyId)
        {
            var x = "";
            if (Keys.IndexOf("Alt") != -1)
                x += "1";
            else
                x += "0";
            x += "|";
            if (Keys.IndexOf("Ctrl") != -1)
                x += "1";
            else
                x += "0";
            x += "|";
            if (Keys.IndexOf("Shift") != -1)
                x += "1";
            else
                x += "0";
            x += "|";
            x += Keys.Replace("Alt", "").Replace("Ctrl", "").Replace("Shift", "").Replace(" ", "").Replace("+", "");
            var keys = x.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            if (keys.Length == 4)
            {
                try
                {
                    if (keys[3].IndexOf("Mouse") == -1)
                        HotKey.RegisterHotKey(Handle, KeyId, (keys[0] == "1" ? HotKey.KeyModifiers.Alt : HotKey.KeyModifiers.None) | (keys[1] == "1" ? HotKey.KeyModifiers.Ctrl : HotKey.KeyModifiers.None) | (keys[2] == "1" ? HotKey.KeyModifiers.Shift : HotKey.KeyModifiers.None), (Keys)Enum.Parse(typeof(Keys), keys[3]));
                }
                catch
                {
                    MessageBox.Show(this, KeyName + " 注册失败！");
                }
            }
        }
        private bool RegisterHotKey(Keys KeyCode, string Keys)
        {

            bool result = false;
            System.Windows.Forms.Keys x = System.Windows.Forms.Keys.None;
            if (Keys.IndexOf("Alt") != -1)
                x |= System.Windows.Forms.Keys.Alt;
            if (Keys.IndexOf("Ctrl") != -1)
                x |= System.Windows.Forms.Keys.Control;
            if (Keys.IndexOf("Shift") != -1)
                x |= System.Windows.Forms.Keys.Shift;
            Keys = Keys.Replace("Alt", "").Replace("Ctrl", "").Replace("Shift", "").Replace(" ", "").Replace("+", "");

            try
            {
                //HotKey.RegisterHotKey(Handle, KeyId, (keys[0] == "1" ? HotKey.KeyModifiers.Alt : HotKey.KeyModifiers.None) | (keys[1] == "1" ? HotKey.KeyModifiers.Ctrl : HotKey.KeyModifiers.None) | (keys[2] == "1" ? HotKey.KeyModifiers.Shift : HotKey.KeyModifiers.None), (Keys)Enum.Parse(typeof(Keys), keys[3]));
                x |= (Keys)Enum.Parse(typeof(Keys), Keys);
                result = KeyCode == x;
            }
            catch
            {
                // MessageBox.Show(this, "快捷键 " + KeyName + " 注册失败！");
            }
            return result;
        }

        const int BaseValue = 830301;
        /// <summary>
        /// 注册热键
        /// </summary>
        private void RegisterShortcutKeyConfig()
        {
            RegisterHotKey("老板键", Config.ShortcutKey_Boss, BaseValue + 0);
            RegisterHotKey("APP键", Config.ShortcutKey_App, BaseValue + 1);
        }
        //注销热键
        private void UnRegisterShortcutKeyConfig()
        {
            HotKey.UnregisterHotKey(Handle, BaseValue + 0);
            HotKey.UnregisterHotKey(Handle, BaseValue + 1);
        }
        private void SaveShortcutKeyConfig(string ShortcutKey_Boss, string ShortcutKey_App)
        {
            Config.ShortcutKey_Boss = ShortcutKey_Boss;
            Config.ShortcutKey_App = ShortcutKey_App;
            string s = XmlUtil.Serializer(typeof(SystemConfig), Config);
            File.WriteAllText(Application.StartupPath + "\\BossKey.config", s);
        }
        protected override void WndProc(ref Message m)
        {

            const int WM_HOTKEY = 0x0312;
            //按快捷键 
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case BaseValue:
                            if (Config.ShortcutKey_App == Config.ShortcutKey_Boss)
                            {
                                if (/*this.Visible*/isshow)
                                {
                                    this.Hide();
                                    this.notifyIcon1.Visible = false;
                                }
                                else
                                {
                                    if (Config.EnablePassword)
                                    {
                                        var _show = false;
                                        ////PasswordForm pf = new PasswordForm();
                                        if (!pf.Visible && pf.ShowDialog() == DialogResult.OK)
                                        {
                                            if (Password.encrypt(pf.Result) != Config.Password)
                                            {
                                                MessageBox.Show(this, "密码不正确！");
                                            }
                                            else
                                            {
                                                _show = true;
                                            }
                                        }
                                        if (!_show) return;
                                    }
                                    this.Show();
                                    this.Activate();
                                    this.notifyIcon1.Visible = true;
                                    if (!ShowInTaskbar)
                                    {
                                        UnRegisterShortcutKeyConfig();
                                        this.ShowInTaskbar = true;
                                        RegisterShortcutKeyConfig();
                                    }
                                }
                            }
                            btn_hiden_Click(null, null);
                            break;
                        case BaseValue + 1:
                            if (/*this.Visible*/isshow)
                            {
                                this.Hide();
                                this.notifyIcon1.Visible = false;
                            }
                            else
                            {
                                if (Config.EnablePassword)
                                {
                                    var _show = false;
                                    //PasswordForm pf = new PasswordForm();
                                    if (!pf.Visible && pf.ShowDialog() == DialogResult.OK)
                                    {
                                        if (Password.encrypt(pf.Result) != Config.Password)
                                        {
                                            MessageBox.Show(this, "密码不正确！");
                                        }
                                        else
                                        {
                                            _show = true;
                                        }
                                    }
                                    if (!_show) return;
                                }
                                this.Show();
                                this.Activate();
                                this.notifyIcon1.Visible = true;
                                if (!ShowInTaskbar)
                                {
                                    UnRegisterShortcutKeyConfig();
                                    this.ShowInTaskbar = true;
                                    RegisterShortcutKeyConfig();
                                }
                            }
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            /*if (RegisterHotKey(keyData, Config.ShortcutKey_App))
            {
                if (this.Visible)
                {
                    this.Hide();
                }
                else
                {
                    this.Show();
                    this.Activate();
                }
            }*/
            return false;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            GetALLProcesses();
        }

        private void cb_bosskey_CheckedChanged(object sender, EventArgs e)
        {
            txt_appkey.Enabled = !cb_bosskey.Checked;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            llab_version.Text = $"V {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}";


            Password.cpuid = Password.GetCpuID();
            Config.AppPaths = new List<string>();
            if (File.Exists(Application.StartupPath + "\\BossKey.config"))
            {
                XmlDocument Xml = new XmlDocument();
                Xml.Load(Application.StartupPath + "\\BossKey.config");
                Config = (SystemConfig)XmlUtil.Deserialize(typeof(SystemConfig), Xml.InnerXml);


                if (Config.EnablePassword)
                {

                    var _show = false;
                    //PasswordForm pf = new PasswordForm();
                    if (!pf.Visible && pf.ShowDialog() == DialogResult.OK)
                    {
                        if (Password.encrypt(pf.Result) != Config.Password)
                        {
                            MessageBox.Show(this, "密码不正确！");
                        }
                        else
                        {
                            _show = true;
                        }
                    }
                    if (!_show)
                    {
                        Application.Exit();
                        return;
                    }


                }
                txt_appkey.Text = Config.ShortcutKey_App;
                txt_bosskey.Text = Config.ShortcutKey_Boss;
                _shortcutkey_app = Config.ShortcutKey_App;
                _shortcutkey_boss = Config.ShortcutKey_Boss;
                cb_bosskey.Checked = txt_appkey.Text == txt_bosskey.Text;
                process = Config.AppPaths;
                cb_autostart.Checked = Config.AutoStart;
                cb_autohide.Checked = Config.AutoHide;
                cb_scanprocess.Checked = Config.ScanPorcess;
                nud_scanprocess_interval.Value = Config.ScanProcessInterval == 0 ? 1000 : Config.ScanProcessInterval;


                cb_mute.Checked = Config.Mute;
                txt_filepath.Text = Config.OpenFilePath;
                cb_openfile.Checked = Config.OpenFile;
                cb_password.Checked = Config.EnablePassword;
                cb_hook.Checked = Config.EnableHook;

                cb_idlehiden.Checked = Config.IdleHiden;
                nud_idletime.Value = Config.IdleTime == 0 ? 60 : Config.IdleTime;







                new Task(async () =>
                {

                    while (true)
                    {
                        if (token.IsCancellationRequested)
                        {
                            return;
                        }
                        if (Config.IdleHiden)
                        {
                            if (GetLastInputTime() / 1000 >= Config.IdleTime)
                            {

                                this.Hide();
                                this.notifyIcon1.Visible = false;
                                phandle.Clear();
                                process_id.Clear();

                                for (var i = 0; i < process.Count; i++)
                                {
                                    var pname = process[i];
                                    pname = pname.Substring(pname.LastIndexOf('\\') + 1);
                                    pname = pname.Substring(0, pname.LastIndexOf("."));
                                    Process[] ps = Process.GetProcessesByName(pname);
                                    foreach (var p in ps)
                                    {
                                        try
                                        {
                                            if (p.MainModule.FileName == process[i]) process_id.Add(p.Id);
                                        }
                                        catch
                                        {

                                        }
                                    }
                                }
                                foreach (var id in process_id)
                                {
                                    EnumWindows(EnumWindowCallBack, id);
                                }

                                foreach (var h in phandle)
                                {
                                    ShowWindow(h, 0);
                                }
                                NotifyIconHide.SetNotifyIconVisiable(process, false);
                                if (Config.Mute)
                                {
                                    SendMessage(this.Handle, WM_APPCOMMAND, 0x200eb0, APPCOMMAND_VOLUME_MUTE * 0x10000);
                                    for (var i = 0; i < 50; i++)
                                    {
                                        SendMessage(this.Handle, WM_APPCOMMAND, 0x200eb0, APPCOMMAND_VOLUME_DOWN * 0x10000);
                                    }
                                }
                                if (Config.OpenFile)
                                {
                                    Process.Start(Config.OpenFilePath);
                                }

                                isshow = false;
                            }
                        }
                        await Task.Delay(1000);
                    }
                }, token).Start();




                new Task(async () =>
                {
                    List<int> _process_id = new List<int>();
                    while (true)
                    {
                        if (token.IsCancellationRequested)
                        {
                            return;
                        }
                        if (Config.ScanPorcess && !isshow)
                        {

                            _process_id.Clear();
                            for (var i = 0; i < process.Count; i++)
                            {
                                var pname = process[i];
                                pname = pname.Substring(pname.LastIndexOf('\\') + 1);
                                pname = pname.Substring(0, pname.LastIndexOf("."));
                                Process[] ps = Process.GetProcessesByName(pname);
                                foreach (var p in ps)
                                {
                                    try
                                    {
                                        if (p.MainModule.FileName == process[i]) _process_id.Add(p.Id);
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                            foreach (var id in _process_id)
                            {
                                EnumWindows(EnumWindowCallBack, id);
                            }

                            foreach (var h in phandle)
                            {
                                ShowWindow(h, 0);
                            }
                            NotifyIconHide.SetNotifyIconVisiable(process, false);
                        }
                        await Task.Delay(Config.ScanProcessInterval);
                    }

                }, token).Start();


                AutoHide = AutoStart && Config.AutoHide;//自动启动且自动隐藏

                if (AutoHide || AutoStart)
                {
                    this.Visible = false;
                    this.ShowInTaskbar = false;
                }
                if (AutoHide)
                {
                    this.Hide();
                    this.notifyIcon1.Visible = false;
                }
                else if (AutoStart)
                {
                    this.Hide();
                }
                RegisterShortcutKeyConfig();
            }
            if (hook == null)
            {
                hook = new GlobalHook();
                if (Config.EnableHook)
                {
                    hook.KeyDown += Hook_KeyDown;
                }
                //hook.KeyDown += new KeyEventHandler(hook_KeyDown);
                //hook.KeyPress += new KeyPressEventHandler(hook_KeyPress);
                //hook.KeyUp += new KeyEventHandler(hook_KeyUp);
                hook.OnMouseActivity += Hook_OnMouseActivity;
            }
            if (!hook.Start())
            {
                MessageBox.Show("您需要管理员权限方能启动鼠标快捷键！", "提示");
            }



            GetALLProcesses();
            isload = false;
            this.Opacity=100;
        }

        bool CheckKeys(string Keys, KeyEventArgs e)
        {
            bool result = true;



            if (Keys.IndexOf("Alt") != -1) result = result && e.Alt;
            if (Keys.IndexOf("Ctrl") != -1) result = result && e.Control;
            if (Keys.IndexOf("Shift") != -1) result = result && e.Shift;
            Keys = Keys.Replace("Alt", "").Replace("Ctrl", "").Replace("Shift", "").Replace(" ", "").Replace("+", "");

            result = result && e.KeyCode == (Keys)Enum.Parse(typeof(Keys), Keys);


            return result;
        }


        private void Hook_KeyDown(object sender, KeyEventArgs e)
        {
            if (CheckKeys(Config.ShortcutKey_Boss, e))
            {
                if (Config.ShortcutKey_App == Config.ShortcutKey_Boss)
                {
                    if (/*this.Visible*/isshow)
                    {
                        this.Hide();
                        this.notifyIcon1.Visible = false;
                    }
                    else
                    {
                        if (Config.EnablePassword)
                        {
                            var _show = false;
                            //PasswordForm pf = new PasswordForm();
                            if (!pf.Visible && pf.ShowDialog() == DialogResult.OK)
                            {
                                if (Password.encrypt(pf.Result) != Config.Password)
                                {
                                    MessageBox.Show(this, "密码不正确！");
                                }
                                else
                                {
                                    _show = true;
                                }
                            }
                            if (!_show) return;
                        }
                        this.Show();
                        this.Activate();
                        this.notifyIcon1.Visible = true;
                        if (!ShowInTaskbar)
                        {
                            //UnRegisterShortcutKeyConfig();
                            this.ShowInTaskbar = true;
                            //RegisterShortcutKeyConfig();
                        }
                    }
                }
                btn_hiden_Click(null, null);
            }
            if (Config.ShortcutKey_App != Config.ShortcutKey_Boss && CheckKeys(Config.ShortcutKey_App, e))
            {

                if (/*this.Visible*/ isshow)
                {
                    this.Hide();
                    this.notifyIcon1.Visible = false;
                }
                else
                {

                    if (Config.EnablePassword)
                    {
                        var _show = false;
                        //PasswordForm pf = new PasswordForm();
                        if (!pf.Visible && pf.ShowDialog() == DialogResult.OK)
                        {
                            if (Password.encrypt(pf.Result) != Config.Password)
                            {
                                MessageBox.Show(this, "密码不正确！");
                            }
                            else
                            {
                                _show = true;
                            }
                        }
                        if (!_show) return;
                    }
                    this.Show();
                    this.Activate();
                    this.notifyIcon1.Visible = true;
                    if (!ShowInTaskbar)
                    {
                        //UnRegisterShortcutKeyConfig();
                        this.ShowInTaskbar = true;
                        //RegisterShortcutKeyConfig();
                    }
                }

            }

        }

        private void Hook_OnMouseActivity(object sender, MouseEventArgs e)
        {
            if (Config.ShortcutKey_Boss == $"Mouse{e.Button.ToString()}")
            {
                if (Config.ShortcutKey_App == Config.ShortcutKey_Boss)
                {
                    if (/*this.Visible*/ isshow)
                    {
                        this.Hide();
                        this.notifyIcon1.Visible = false;
                    }
                    else
                    {
                        if (Config.EnablePassword)
                        {
                            var _show = false;
                            //PasswordForm pf = new PasswordForm();
                            if (!pf.Visible && pf.ShowDialog() == DialogResult.OK)
                            {
                                if (Password.encrypt(pf.Result) != Config.Password)
                                {
                                    MessageBox.Show(this, "密码不正确！");
                                }
                                else
                                {
                                    _show = true;
                                }
                            }
                            if (!_show) return;
                        }
                        this.Show();
                        this.Activate();
                        this.notifyIcon1.Visible = true;
                        if (!ShowInTaskbar)
                        {
                            UnRegisterShortcutKeyConfig();
                            this.ShowInTaskbar = true;
                            RegisterShortcutKeyConfig();
                        }
                    }
                }
                btn_hiden_Click(null, null);
            }
            if (Config.ShortcutKey_App != Config.ShortcutKey_Boss && Config.ShortcutKey_App == $"Mouse{e.Button.ToString()}")
            {

                if (/*this.Visible*/ isshow)
                {
                    this.Hide();
                    this.notifyIcon1.Visible = false;
                }
                else
                {
                    if (Config.EnablePassword)
                    {
                        var _show = false;
                        //PasswordForm pf = new PasswordForm();
                        if (!pf.Visible && pf.ShowDialog() == DialogResult.OK)
                        {
                            if (Password.encrypt(pf.Result) != Config.Password)
                            {
                                MessageBox.Show(this, "密码不正确！");
                            }
                            else
                            {
                                _show = true;
                            }
                        }
                        if (!_show) return;
                    }
                    this.Show();
                    this.Activate();
                    this.notifyIcon1.Visible = true;
                    if (!ShowInTaskbar)
                    {
                        UnRegisterShortcutKeyConfig();
                        this.ShowInTaskbar = true;
                        RegisterShortcutKeyConfig();
                    }
                }

            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isshow)
            {
                btn_hiden_Click(null, null);
            }
            if (hook != null) hook.Stop();

            UnRegisterShortcutKeyConfig();
            tokenSource.Cancel();


        }

        private void menu_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void menu_show_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
            if (!ShowInTaskbar)
            {
                UnRegisterShortcutKeyConfig();
                this.ShowInTaskbar = true;
                RegisterShortcutKeyConfig();
            }
        }

        private void txt_bosskey_Enter(object sender, EventArgs e)
        {
            UnRegisterShortcutKeyConfig();
        }
        private ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
        private void list_process_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 2)
                lvwColumnSorter.IsNumber = true;
            else
                lvwColumnSorter.IsNumber = false;
            // 检查点击的列是不是现在的排序列.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // 重新设置此列的排序方法.
                if (lvwColumnSorter.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                // 设置排序列，默认为正向排序
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            }
            list_process.ListViewItemSorter = lvwColumnSorter;
            // 用新的排序方法对ListView排序
            this.list_process.Sort();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
            if (!ShowInTaskbar)
            {
                UnRegisterShortcutKeyConfig();
                this.ShowInTaskbar = true;
                RegisterShortcutKeyConfig();
            }
        }

        private void cb_autostart_CheckedChanged(object sender, EventArgs e)
        {
            cb_autohide.Enabled = cb_autostart.Checked;
        }

        private void txt_bosskey_MouseDown(object sender, MouseEventArgs e)
        {
            var obj = (TextBox)sender;
            //obj.Text = "";
            if (e.Button == MouseButtons.Middle)
            {
                obj.Text = $"Mouse{e.Button.ToString()}";
            }
        }

        private void btn_selfile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_filepath.Text = openFileDialog1.FileName;
            }
        }


        bool password_change = false;

        private void cb_password_CheckedChanged(object sender, EventArgs e)
        {
            if (!isload)
            {
                if (!password_change)
                {
                    var ret = false;
                    if (cb_password.Checked)
                    {
                        var pass_1 = "";
                        var pass_2 = "";

                        PasswordForm pf_1 = new PasswordForm();
                        if (pf_1.ShowDialog() == DialogResult.OK)
                        {
                            pass_1 = pf_1.Result;

                            PasswordForm pf_2 = new PasswordForm();
                            pf_2.Text = "请再次输入密码";
                            if (pf_2.ShowDialog() == DialogResult.OK)
                            {
                                pass_2 = pf_2.Result;
                                if (pass_1 != pass_2)
                                {
                                    MessageBox.Show(this, "两次密码输入不一致！");
                                }
                                else
                                {
                                    Config.Password = Password.encrypt(pass_1);
                                    ret = true;
                                }
                            }
                        }

                        if (cb_password.Checked != ret)
                        {
                            if (ret) password_change = true;
                            cb_password.Checked = ret;
                        }

                    }
                    else
                    {
                        PasswordForm pf_1 = new PasswordForm();
                        if (pf_1.ShowDialog() == DialogResult.OK)
                        {
                            if (Config.Password != Password.encrypt(pf_1.Result))
                            {
                                MessageBox.Show(this, "密码不正确！");
                            }
                            else
                            {
                                ret = true;
                            }
                        }

                        if (cb_password.Checked == ret)
                        {
                            if (!ret) password_change = true;
                            cb_password.Checked = !ret;
                        }



                    }
                }
                else
                {
                    password_change = false;
                }
            }
        }

        private void cb_openfile_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_openfile.Checked)
            {
                if (txt_filepath.Text == string.Empty)
                {
                    MessageBox.Show(this, "文件不能为空！");
                    cb_openfile.Checked = false;
                }
            }
        }

        private void llab_version_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.52pojie.cn/thread-1582026-1-1.html");
        }
    }





}
