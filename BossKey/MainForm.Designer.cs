namespace BossKey
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_bosskey = new System.Windows.Forms.TextBox();
            this.btn_hiden = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cb_hook = new System.Windows.Forms.CheckBox();
            this.cb_password = new System.Windows.Forms.CheckBox();
            this.btn_selfile = new System.Windows.Forms.Button();
            this.txt_filepath = new System.Windows.Forms.TextBox();
            this.cb_openfile = new System.Windows.Forms.CheckBox();
            this.cb_mute = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nud_idletime = new System.Windows.Forms.NumericUpDown();
            this.cb_idlehiden = new System.Windows.Forms.CheckBox();
            this.nud_scanprocess_interval = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_scanprocess = new System.Windows.Forms.CheckBox();
            this.cb_autohide = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_autostart = new System.Windows.Forms.CheckBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.cb_bosskey = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_appkey = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.list_process = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu_show = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.llab_version = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_idletime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_scanprocess_interval)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "老板键";
            // 
            // txt_bosskey
            // 
            this.txt_bosskey.BackColor = System.Drawing.Color.White;
            this.txt_bosskey.Location = new System.Drawing.Point(262, 6);
            this.txt_bosskey.Name = "txt_bosskey";
            this.txt_bosskey.ReadOnly = true;
            this.txt_bosskey.Size = new System.Drawing.Size(111, 21);
            this.txt_bosskey.TabIndex = 2;
            this.txt_bosskey.Enter += new System.EventHandler(this.txt_bosskey_Enter);
            this.txt_bosskey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_bosskey_KeyDown);
            this.txt_bosskey.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_bosskey_MouseDown);
            // 
            // btn_hiden
            // 
            this.btn_hiden.Location = new System.Drawing.Point(305, 61);
            this.btn_hiden.Name = "btn_hiden";
            this.btn_hiden.Size = new System.Drawing.Size(120, 33);
            this.btn_hiden.TabIndex = 6;
            this.btn_hiden.Text = "隐藏/显示（测试）";
            this.btn_hiden.UseVisualStyleBackColor = true;
            this.btn_hiden.Click += new System.EventHandler(this.btn_hiden_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(211, 61);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(88, 33);
            this.btn_save.TabIndex = 5;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.llab_version);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.cb_autohide);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.btn_refresh);
            this.panel1.Controls.Add(this.cb_bosskey);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_appkey);
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_hiden);
            this.panel1.Controls.Add(this.txt_bosskey);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 422);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1219, 106);
            this.panel1.TabIndex = 6;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cb_hook);
            this.groupBox4.Controls.Add(this.cb_password);
            this.groupBox4.Controls.Add(this.btn_selfile);
            this.groupBox4.Controls.Add(this.txt_filepath);
            this.groupBox4.Controls.Add(this.cb_openfile);
            this.groupBox4.Controls.Add(this.cb_mute);
            this.groupBox4.Location = new System.Drawing.Point(930, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(277, 88);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "隐藏选项";
            // 
            // cb_hook
            // 
            this.cb_hook.AutoSize = true;
            this.cb_hook.Location = new System.Drawing.Point(120, 16);
            this.cb_hook.Name = "cb_hook";
            this.cb_hook.Size = new System.Drawing.Size(72, 16);
            this.cb_hook.TabIndex = 1;
            this.cb_hook.Text = "启用HOOK";
            this.cb_hook.UseVisualStyleBackColor = true;
            // 
            // cb_password
            // 
            this.cb_password.AutoSize = true;
            this.cb_password.Location = new System.Drawing.Point(6, 37);
            this.cb_password.Name = "cb_password";
            this.cb_password.Size = new System.Drawing.Size(108, 16);
            this.cb_password.TabIndex = 2;
            this.cb_password.Text = "显示时启用密码\r\n";
            this.cb_password.UseVisualStyleBackColor = true;
            this.cb_password.CheckedChanged += new System.EventHandler(this.cb_password_CheckedChanged);
            // 
            // btn_selfile
            // 
            this.btn_selfile.Location = new System.Drawing.Point(241, 56);
            this.btn_selfile.Name = "btn_selfile";
            this.btn_selfile.Size = new System.Drawing.Size(33, 23);
            this.btn_selfile.TabIndex = 5;
            this.btn_selfile.Text = "...";
            this.btn_selfile.UseVisualStyleBackColor = true;
            this.btn_selfile.Click += new System.EventHandler(this.btn_selfile_Click);
            // 
            // txt_filepath
            // 
            this.txt_filepath.Location = new System.Drawing.Point(120, 56);
            this.txt_filepath.Name = "txt_filepath";
            this.txt_filepath.Size = new System.Drawing.Size(115, 21);
            this.txt_filepath.TabIndex = 4;
            // 
            // cb_openfile
            // 
            this.cb_openfile.AutoSize = true;
            this.cb_openfile.Location = new System.Drawing.Point(6, 59);
            this.cb_openfile.Name = "cb_openfile";
            this.cb_openfile.Size = new System.Drawing.Size(108, 16);
            this.cb_openfile.TabIndex = 3;
            this.cb_openfile.Text = "隐藏时打开文件";
            this.cb_openfile.UseVisualStyleBackColor = true;
            this.cb_openfile.CheckedChanged += new System.EventHandler(this.cb_openfile_CheckedChanged);
            // 
            // cb_mute
            // 
            this.cb_mute.AutoSize = true;
            this.cb_mute.Location = new System.Drawing.Point(6, 16);
            this.cb_mute.Name = "cb_mute";
            this.cb_mute.Size = new System.Drawing.Size(84, 16);
            this.cb_mute.TabIndex = 0;
            this.cb_mute.Text = "隐藏时静音";
            this.cb_mute.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nud_idletime);
            this.groupBox3.Controls.Add(this.cb_idlehiden);
            this.groupBox3.Controls.Add(this.nud_scanprocess_interval);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cb_scanprocess);
            this.groupBox3.Location = new System.Drawing.Point(672, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(252, 88);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "自动隐藏";
            // 
            // nud_idletime
            // 
            this.nud_idletime.Location = new System.Drawing.Point(171, 57);
            this.nud_idletime.Maximum = new decimal(new int[] {
            3600000,
            0,
            0,
            0});
            this.nud_idletime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_idletime.Name = "nud_idletime";
            this.nud_idletime.Size = new System.Drawing.Size(75, 21);
            this.nud_idletime.TabIndex = 4;
            this.nud_idletime.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // cb_idlehiden
            // 
            this.cb_idlehiden.AutoSize = true;
            this.cb_idlehiden.Location = new System.Drawing.Point(6, 59);
            this.cb_idlehiden.Name = "cb_idlehiden";
            this.cb_idlehiden.Size = new System.Drawing.Size(156, 16);
            this.cb_idlehiden.TabIndex = 3;
            this.cb_idlehiden.Text = "系统空闲自动隐藏（秒）";
            this.cb_idlehiden.UseVisualStyleBackColor = true;
            // 
            // nud_scanprocess_interval
            // 
            this.nud_scanprocess_interval.Location = new System.Drawing.Point(137, 35);
            this.nud_scanprocess_interval.Maximum = new decimal(new int[] {
            3600000,
            0,
            0,
            0});
            this.nud_scanprocess_interval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_scanprocess_interval.Name = "nud_scanprocess_interval";
            this.nud_scanprocess_interval.Size = new System.Drawing.Size(109, 21);
            this.nud_scanprocess_interval.TabIndex = 2;
            this.nud_scanprocess_interval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "进程扫描时间（毫秒）";
            // 
            // cb_scanprocess
            // 
            this.cb_scanprocess.AutoSize = true;
            this.cb_scanprocess.Location = new System.Drawing.Point(6, 16);
            this.cb_scanprocess.Name = "cb_scanprocess";
            this.cb_scanprocess.Size = new System.Drawing.Size(228, 16);
            this.cb_scanprocess.TabIndex = 0;
            this.cb_scanprocess.Text = "开启隐藏后，自动隐藏同名新启动进程";
            this.cb_scanprocess.UseVisualStyleBackColor = true;
            // 
            // cb_autohide
            // 
            this.cb_autohide.AutoSize = true;
            this.cb_autohide.Enabled = false;
            this.cb_autohide.Location = new System.Drawing.Point(477, 44);
            this.cb_autohide.Name = "cb_autohide";
            this.cb_autohide.Size = new System.Drawing.Size(180, 16);
            this.cb_autohide.TabIndex = 1;
            this.cb_autohide.Text = "启动后自动隐藏进程及本程序";
            this.cb_autohide.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_autostart);
            this.groupBox2.Location = new System.Drawing.Point(471, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 92);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "系统启动选项";
            // 
            // cb_autostart
            // 
            this.cb_autostart.AutoSize = true;
            this.cb_autostart.Location = new System.Drawing.Point(6, 20);
            this.cb_autostart.Name = "cb_autostart";
            this.cb_autostart.Size = new System.Drawing.Size(132, 16);
            this.cb_autostart.TabIndex = 0;
            this.cb_autostart.Text = "随操作系统自动启动";
            this.cb_autostart.UseVisualStyleBackColor = true;
            this.cb_autostart.CheckedChanged += new System.EventHandler(this.cb_autostart_CheckedChanged);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(3, 3);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(88, 33);
            this.btn_refresh.TabIndex = 1;
            this.btn_refresh.Text = "刷新进程列表";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // cb_bosskey
            // 
            this.cb_bosskey.AutoSize = true;
            this.cb_bosskey.Location = new System.Drawing.Point(393, 35);
            this.cb_bosskey.Name = "cb_bosskey";
            this.cb_bosskey.Size = new System.Drawing.Size(72, 16);
            this.cb_bosskey.TabIndex = 4;
            this.cb_bosskey.Text = "同老板键";
            this.cb_bosskey.UseVisualStyleBackColor = true;
            this.cb_bosskey.CheckedChanged += new System.EventHandler(this.cb_bosskey_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "程序本身隐藏快捷键";
            // 
            // txt_appkey
            // 
            this.txt_appkey.BackColor = System.Drawing.Color.White;
            this.txt_appkey.Location = new System.Drawing.Point(262, 33);
            this.txt_appkey.Name = "txt_appkey";
            this.txt_appkey.ReadOnly = true;
            this.txt_appkey.Size = new System.Drawing.Size(111, 21);
            this.txt_appkey.TabIndex = 3;
            this.txt_appkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_bosskey_KeyDown);
            this.txt_appkey.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_bosskey_MouseDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.list_process);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1219, 422);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "进程列表";
            // 
            // list_process
            // 
            this.list_process.CheckBoxes = true;
            this.list_process.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.list_process.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_process.FullRowSelect = true;
            this.list_process.GridLines = true;
            this.list_process.HideSelection = false;
            this.list_process.Location = new System.Drawing.Point(3, 17);
            this.list_process.Margin = new System.Windows.Forms.Padding(2);
            this.list_process.Name = "list_process";
            this.list_process.Size = new System.Drawing.Size(1213, 402);
            this.list_process.SmallImageList = this.imageList1;
            this.list_process.TabIndex = 7;
            this.list_process.UseCompatibleStateImageBehavior = false;
            this.list_process.View = System.Windows.Forms.View.Details;
            this.list_process.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.list_process_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "进程";
            this.columnHeader1.Width = 600;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "窗体名称";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "PID";
            this.columnHeader3.Width = 70;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "老板来了[吾爱破解]";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_show,
            this.toolStripMenuItem1,
            this.menu_exit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 54);
            // 
            // menu_show
            // 
            this.menu_show.Name = "menu_show";
            this.menu_show.Size = new System.Drawing.Size(136, 22);
            this.menu_show.Text = "显示主屏幕";
            this.menu_show.Click += new System.EventHandler(this.menu_show_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 6);
            // 
            // menu_exit
            // 
            this.menu_exit.Name = "menu_exit";
            this.menu_exit.Size = new System.Drawing.Size(136, 22);
            this.menu_exit.Text = "退出";
            this.menu_exit.Click += new System.EventHandler(this.menu_exit_Click);
            // 
            // llab_version
            // 
            this.llab_version.AutoSize = true;
            this.llab_version.Location = new System.Drawing.Point(12, 85);
            this.llab_version.Name = "llab_version";
            this.llab_version.Size = new System.Drawing.Size(0, 12);
            this.llab_version.TabIndex = 10;
            this.llab_version.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llab_version_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1219, 528);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "老板来了[吾爱破解]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_idletime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_scanprocess_interval)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_bosskey;
        private System.Windows.Forms.Button btn_hiden;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_bosskey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_appkey;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_show;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menu_exit;
        private System.Windows.Forms.ListView list_process;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nud_scanprocess_interval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cb_scanprocess;
        private System.Windows.Forms.CheckBox cb_autohide;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cb_autostart;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cb_password;
        private System.Windows.Forms.Button btn_selfile;
        private System.Windows.Forms.TextBox txt_filepath;
        private System.Windows.Forms.CheckBox cb_openfile;
        private System.Windows.Forms.CheckBox cb_mute;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox cb_hook;
        private System.Windows.Forms.NumericUpDown nud_idletime;
        private System.Windows.Forms.CheckBox cb_idlehiden;
        private System.Windows.Forms.LinkLabel llab_version;
    }
}

