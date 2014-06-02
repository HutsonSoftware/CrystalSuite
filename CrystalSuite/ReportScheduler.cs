using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CrystalSuite 
{
    public partial class ReportScheduler : ReporterBase
    {
        ReporterBO _reporterBO;
        TreeNode _oldSelectNode;
        int _jobCounter = 0;
        List<Job> _jobList;

        public ReportScheduler(ReporterBO reporterBO)
        {
            InitializeComponent();
            _reporterBO = reporterBO;

            this.Text = base.Title + " - Report Scheduler";
        }

        private void ReportScheduler_Load(object sender, System.EventArgs e)
        {
            _jobList = _reporterBO.GetJobList();
            PopulateJobTree();
        }

        private void PopulateJobTree()
        {
            foreach (Job job in _jobList)
            { 
                
            }
        }

        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        Point p = new Point(e.X, e.Y);
                        TreeNode node = treeView1.GetNodeAt(p);

                        if (node != null)
                        {
                            _oldSelectNode = treeView1.SelectedNode;
                            treeView1.SelectedNode = node;

                            switch (Convert.ToString(node.Tag))
                            {
                                case "Jobs":
                                    JobsContextMenuStrip.Show(treeView1, p);
                                    break;
                                case "Job":
                                    JobContextMenuStrip.Show(treeView1, p);
                                    break;
                            }

                            treeView1.SelectedNode = _oldSelectNode;
                            _oldSelectNode = null;
                        }
                        break;
                    }
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        #region Context Menus
        private void newJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewJob();
        }            

        private void CreateNewJob()
        {
            NewJob newJob = new NewJob();
            newJob.ShowDialog();

            _jobCounter += 1;

            TreeNode newJobNode = new TreeNode();
            newJobNode.Name = "Job" + Convert.ToString(_jobCounter);
            newJobNode.Text = "Job" + Convert.ToString(_jobCounter);
            newJobNode.Tag = "Job";
            newJobNode.ContextMenuStrip = JobContextMenuStrip;

            treeView1.SelectedNode.Nodes.Add(newJobNode);
        }

        private void manageSchedulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageSchedules();
        }

        private void ManageSchedules()
        {
            
        }

        private void viewAllHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewAllHistory();
        }

        private void ViewAllHistory()
        {

        }

        private void viewJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewJob();
        }

        private void ViewJob()
        {
            
        }
        
        private void startJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartJob();
        }

        private void StartJob()
        {
            
        }
        
        private void stopJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopJob();
        }

        private void StopJob()
        {
            
        }

        private void viewHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewHistory();
        }

        private void ViewHistory()
        {
            
        }

        private void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableJob();
        }

        private void EnableJob()
        {
            
        }

        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableJob();
        }

        private void DisableJob()
        {
            
        }

        private void deleteJobToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteJob();
        }

        private void DeleteJob()
        {
            
        }
        #endregion
    }
}
