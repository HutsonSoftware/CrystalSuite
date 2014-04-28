using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CrystalSuite
{
    public partial class ReportSelector : ReporterBase
    {
        ReporterBO _reporterBO;
        List<Report> _reportList;

        public ReportSelector(ReporterBO reporterBO)
        {
            InitializeComponent();
            _reporterBO = reporterBO;
            
            this.Text = base.Title + " - Report Selector";
        }

        private void ReportSelector_Load(object sender, EventArgs e)
        {
            _reportList = _reporterBO.ReportsFile.ReportList;
            CreateGrid();
        }

        private void CreateGrid()
        {
            dgvAvailableReports.AutoGenerateColumns = false;
            dgvAvailableReports.AllowUserToAddRows = false;
            dgvAvailableReports.DataSource = _reportList;

            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.Name = "FileName";
            column1.HeaderText = "File Name";
            column1.DataPropertyName = "FileName";
            dgvAvailableReports.Columns.Add(column1);

            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.Name = "FilePath";
            column2.HeaderText = "File Path";
            column2.DataPropertyName = "FilePath";
            dgvAvailableReports.Columns.Add(column2);
        }

        private void btnAddReport_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    FileInfo file = new FileInfo(openFileDialog1.FileName);
                    Report newReport = new Report(file.Name, file.DirectoryName);
                    _reportList.Add(newReport);
                    RefreshReportGrid();
                }
            }
            catch (Exception ex)
            {
                _reporterBO.Log(ex.ToString());
            }
        }
        
        private void RefreshReportGrid()
        {
            dgvAvailableReports.Refresh();
        }

        private void btnRemoveReport_Click(object sender, EventArgs e)
        {
            
        }

        //private void lstAvailableReports_DoubleClick(object sender, EventArgs e)
        //{
        //    ViewReport();
        //}

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            ViewReport();
        }

        private void ViewReport()
        {
            ReportViewer rv = null;
            try
            {
                //this.UseWaitCursor = true;
                //if (lstAvailableReports.SelectedIndices.Count > 0)
                //{
                //    string reportPath = lstAvailableReports.SelectedItems[0].SubItems[1].Text;
                //    _reporterBO.SetSelectedReportByReportPath(reportPath);
                //    rv = new ReportViewer(_reporterBO);
                //    rv.ShowDialog(this);
                //}
            }
            catch (Exception ex)
            {
                _reporterBO.Log(ex.ToString());
            }
            finally
            {
                if (rv != null)
                    rv.Dispose();

                this.UseWaitCursor = false;
            }
        }

        private void ReportSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_reportList != _reporterBO.ReportsFile.ReportList)
                _reporterBO.ReportsFile.ReportList = _reportList;
        }

        //private void mnuFileConfig_Click(object sender, EventArgs e)
        //{
        //    ViewConfig();
        //}

        //private void ViewConfig()
        //{
        //    SettingsEditor editor = new SettingsEditor(_reporterBO.SettingsFile);
        //    editor.ShowDialog();

        //    if (editor.IsDirty)
        //    {
        //        _reporterBO.SettingsFile = editor.Settings;
        //        LoadReportFiles();
        //    }

        //    editor.Dispose();
        //}

        //private void lstAvailableReports_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    btnRemoveReport.Enabled = (lstAvailableReports.SelectedItems.Count > 0);
        //    btnViewReport.Enabled = (lstAvailableReports.SelectedItems.Count > 0);
        //}
    }
}
