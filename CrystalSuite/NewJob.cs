using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CrystalSuite
{
    public partial class NewJob : ReporterBase
    {
        JobGeneralPanel _generalPanel = new JobGeneralPanel();
        JobStepsPanel _stepsPanel = new JobStepsPanel();
        JobSchedulesPanel _schedulePanel = new JobSchedulesPanel();
        JobNotificationPanel _notificationPanel = new JobNotificationPanel();
        
        public NewJob()
        {
            InitializeComponent();

            lstPanelSelection.MultiSelect = false;
            lstPanelSelection.HideSelection = false;

            foreach (ePanels panel in (ePanels[]) Enum.GetValues(typeof(ePanels)))
            {
                ListViewItem item = new ListViewItem(panel.ToString());
                lstPanelSelection.Items.Add(item);
            }
            
            splitContainer2.Panel2.Controls.Add(_generalPanel);
            splitContainer2.Panel2.Controls.Add(_stepsPanel);
            splitContainer2.Panel2.Controls.Add(_schedulePanel);
            splitContainer2.Panel2.Controls.Add(_notificationPanel);

            _generalPanel.Dock = DockStyle.Fill;
            _stepsPanel.Dock = DockStyle.Fill;
            _schedulePanel.Dock = DockStyle.Fill;
            _notificationPanel.Dock = DockStyle.Fill;

            lstPanelSelection.Focus();
            lstPanelSelection.Items[0].Selected = true;
        }

        private enum ePanels { General, Steps, Schedule, Notifications };

        private void ShowPanel(ePanels whichPanel)
        {
            _generalPanel.Hide();
            _stepsPanel.Hide();
            _schedulePanel.Hide();
            _notificationPanel.Hide();

            switch (whichPanel)
            {
                case ePanels.General:
                    _generalPanel.Show();
                    break;
                case ePanels.Steps:
                    _stepsPanel.Show();
                    break;
                case ePanels.Schedule:
                    _schedulePanel.Show();
                    break;
                case ePanels.Notifications:
                    _notificationPanel.Show();
                    break;
                default:
                    break;
            }
        }

        private void lstPanelSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPanelSelection.SelectedItems.Count == 1)
            {
                ePanels panelSelected = (ePanels)Enum.Parse(typeof(ePanels), lstPanelSelection.SelectedItems[0].Text);
                ShowPanel(panelSelected);
            }
        }
    }
}
