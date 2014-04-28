using System;

namespace CrystalSuite
{
    public partial class SettingsEditor : ReporterBase
    {
        SettingsFile _settings;
        public SettingsFile Settings { get { return _settings; } }

        public SettingsEditor(SettingsFile settings)
        {
            _settings = settings;
            InitializeComponent();
        }

        private void SettingsEditor_Load(object sender, EventArgs e)
        {
            txtLocalReportsFolder.Text = _settings.LocalReportFolder;
            txtServerReportsFolder.Text = _settings.ServerReportFolder;
            txtServerName.Text = _settings.ServerName;
            txtDatabaseName.Text = _settings.DatabaseName;
            chkIntegratedSecurity.Checked = _settings.IntegratedSecurity;
            txtUserID.Text = _settings.UserID;
            txtPassword.Text = _settings.Password;
        }

        private void chkIntegratedSecurity_CheckStateChanged(object sender, EventArgs e)
        {
            IsIntegratedSecurity();
        }

        private void IsIntegratedSecurity()
        {
            txtUserID.Enabled = (!chkIntegratedSecurity.Checked);
            txtPassword.Enabled = (!chkIntegratedSecurity.Checked);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }

        private void SaveSettings()
        {
            if (_settings.LocalReportFolder != txtLocalReportsFolder.Text)
            {
                _settings.LocalReportFolder = txtLocalReportsFolder.Text;
                _isDirty = true;
            }
            if (_settings.ServerReportFolder != txtServerReportsFolder.Text)
            {
                _settings.ServerReportFolder = txtServerReportsFolder.Text;
                _isDirty = true;
            }
            if (_settings.ServerName != txtServerName.Text)
            {
                _settings.ServerName = txtServerName.Text;
                _isDirty = true;
            }
            if (_settings.DatabaseName != txtDatabaseName.Text)
            {
                _settings.DatabaseName = txtDatabaseName.Text;
                _isDirty = true;
            }
            if (_settings.IntegratedSecurity != chkIntegratedSecurity.Checked)
            {
                _settings.IntegratedSecurity = chkIntegratedSecurity.Checked;
                _isDirty = true;
            }
            if (_settings.UserID != txtUserID.Text)
            {
                _settings.UserID = txtUserID.Text;
                _isDirty = true;
            }
            if (_settings.Password != txtPassword.Text)
            {
                _settings.Password = txtPassword.Text;
                _isDirty = true;
            }
        }

        private bool _isDirty = false;
        public bool IsDirty { get { return _isDirty; } }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
