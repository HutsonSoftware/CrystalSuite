using System;
using System.Windows.Forms;

namespace CrystalSuite
{
    public partial class StartUpPanel : UserControl
    {
        public StartUpPanel()
        {
            InitializeComponent();
        }

        #region Common Tasks GroupBox
        private void lnkAddNewJob_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddNewJob();
        }

        private void lnkEditExistingJob_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditExistingJob();
        }

        private void lnkViewRunningJobs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewRunningJobs();
        }
        #endregion

        #region Recent Changes GroupBox
        private void dgvRecentChanges_DoubleClick(object sender, EventArgs e)
        {
            ViewRecentChangeLog();
        }        
        #endregion

        #region Methods
        private void AddNewJob()
        {
        }

        private void EditExistingJob()
        {
        }

        private void ViewRunningJobs()
        {
        }

        private void ViewRecentChangeLog()
        {
        }
        #endregion
    }
}
