using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CrystalSuite 
{
    public partial class ReportSchedulerSimple : ReporterBase
    {
        ReporterBO _reporterBO;
        TreeNode _oldSelectNode;
        int _reportCounter = 0;
        List<ScheduledReport> _reportList;

        public ReportSchedulerSimple(ReporterBO reporterBO)
        {
            InitializeComponent();
            _reporterBO = reporterBO;

            this.Text = base.Title + " - Report Scheduler";
        }

        private void ReportScheduler_Load(object sender, System.EventArgs e)
        {
            _reportList = _reporterBO.GetReportList();
            PopulateReportTree();
        }

        private void PopulateReportTree()
        {
            foreach (ScheduledReport report in _reportList)
            { 
                
            }
        }

        private void tvwReports_MouseUp(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            tvwReports.SelectedNode = tvwReports.GetNodeAt(p); ;
            ReportContextMenuStrip.Show(tvwReports, p);
        }

        #region Context Menus
        private void runReportNowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void lnkScheduleNewReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowNewScheduledReportPanel();
        }
    }
}
