using System;
using System.Windows.Forms;

namespace Traceability.Hook.Setting
{
    public partial class LoginDialog : Form
    {
        public bool LoginSuccessfull = false;
        public LoginDialog()
        {
            InitializeComponent();
        }

        private void LoginDialog_Load(object sender, EventArgs e)
        {
            tb_Password.Focus();
        }

        private void TryLogin()
        {
            ISettingHook setting = new SettingHook();
            var adminPassword = setting.GetAdminPassword();
            LoginSuccessfull = adminPassword.Equals(tb_Password.Text);
            if (LoginSuccessfull)
            {
                CloseDialog();
            }
            else
            {
                MessageBox.Show(@"Wrong Password", @"Wrong Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseDialog()
        {
            Close();
        }
        private void tb_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (c == 13)
            {
                TryLogin();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TryLogin();
        }

        private void LoginDialog_Shown(object sender, EventArgs e)
        {
            tb_Password.Focus();
        }
    }
}
