using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BossKey
{
    public partial class PasswordForm : Form
    {
        public string Result = "";
        public PasswordForm()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        private void PasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if(txt_password.Text.Trim()==string.Empty)
            {
                MessageBox.Show(this, "密码不能为空！");
                return;
            }
            Result = txt_password.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void PasswordForm_Shown(object sender, EventArgs e)
        {
            txt_password.Text = "";
        }
    }
}
