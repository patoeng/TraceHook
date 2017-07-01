using System;
using System.Windows.Forms;


namespace Traceability.Hook.Setting
{
    public partial class HookSetting : Form
    {
        public HookSetting()
        {
            InitializeComponent();
        }

        private ISettingHook _setting = new SettingHook();
        private bool _login;
        private void ReloadSetting()
        {
            _setting = new SettingHook();

            tb_MachineSerialNumber.Text = _setting.MachineSerialNumber();
            tb_NumberOfStation.Text = _setting.GetNumberOfStation().ToString();
            tb_UniqueIdentityLength.Text = _setting.GetUniqueIdLength().ToString();
            cb_EnableTraceability.Checked = _setting.GetEnableTraceability();
            tb_PlcIpAddress.Text = _setting.GetPlcIpAdress();

            if (_login)
            {
                tb_DbConnectionString.Text = _setting.GetDatabaseConnectionString();
                tb_AdminPassword.Text = _setting.GetAdminPassword();
            }
            else
            {
                tb_DbConnectionString.Clear();
                tb_AdminPassword.Clear();
            }
        }
        private void btn_ReloadSetting_Click(object sender, EventArgs e)
        {
            ReloadSetting();
        }

        private void MakeAllInputEditable()
        {
            tb_NumberOfStation.ReadOnly = false;
            tb_AdminPassword.ReadOnly = false;
            tb_MachineSerialNumber.ReadOnly = false;
            tb_DbConnectionString.ReadOnly = false;
            tb_UniqueIdentityLength.ReadOnly = false;
            cb_EnableTraceability.Enabled = true;
            tb_PlcIpAddress.ReadOnly = false;
            btn_Save.Visible = true;
        }
        private void MakeAllInputReadOnly()
        {
            tb_NumberOfStation.ReadOnly = true;
            tb_AdminPassword.ReadOnly = true;
            tb_MachineSerialNumber.ReadOnly = true;
            tb_DbConnectionString.ReadOnly = true;
            tb_UniqueIdentityLength.ReadOnly = true;
            cb_EnableTraceability.Enabled = false;
            tb_PlcIpAddress.ReadOnly = true;
            btn_Save.Visible = false;
        }
        private void btn_StartEdit_Click(object sender, EventArgs e)
        {
            using (var forms = new LoginDialog())
            {
                forms.ShowDialog();
                _login = forms.LoginSuccessfull;
                if (_login)
                {
                    MakeAllInputEditable();
                    ReloadSetting();
                }
                else
                {
                    MakeAllInputReadOnly();
                    ReloadSetting();
                }
            }

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool SaveAllSetting()
        {
            int numberOfStation;
            int uniqueIdLength;
            try
            {
                numberOfStation = Convert.ToInt32(tb_NumberOfStation.Text);
                uniqueIdLength = Convert.ToInt32(tb_UniqueIdentityLength.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"Menyimpan Data Bermasalah", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            try
            {
                _setting.SetNumberOfStation(numberOfStation);
                _setting.SetAdminPassword(tb_AdminPassword.Text);
                _setting.SetEnableTraceability(cb_EnableTraceability.Checked);
                _setting.SetUniqueIdLength(uniqueIdLength);
                _setting.SetDatabaseConnectionString(tb_DbConnectionString.Text);
                _setting.SetMachineSerialNumnber(tb_MachineSerialNumber.Text);
                _setting.SetPlcIpAddress(tb_PlcIpAddress.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"Menyimpan Data Bermasalah", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            var bb = SaveAllSetting();
            if (bb)
            {
                MessageBox.Show(@"Setting Saved Successfully!");
                Close();
            }
        }

        private void HookSetting_Load(object sender, EventArgs e)
        {
            ReloadSetting();
        }

        private void HookSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            _setting = null;
        }
    }
}
