using System;
using CrystalDecisions.CrystalReports.Engine;

namespace CrystalSuite
{
    public partial class ReportViewer : ReporterBase
    {
        private ReportDocument _reportDocument;
        private string _reportPath;
        private ReporterBO _reporterBO;

        public ReportViewer(ReporterBO reporterBO)
        {
            InitializeComponent();

            _reporterBO = reporterBO;
            _reportPath = reporterBO.SelectedReportPath;

            this.Text = base.Title + " - Report Viewer";
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                _reportDocument = new ReportDocument();
                _reportDocument.Load(_reportPath);
                _reporterBO.SetCrystalReportLogon(_reportDocument);

                if (_reporterBO.HasParameterSetNameArg)
                    _reporterBO.CreateParameterCollection(_reportDocument.ParameterFields);
                else
                    GetParametersFromUser();

                this.crystalReportViewer.ReportSource = _reportDocument;
            }
            catch (Exception ex)
            {
                _reporterBO.Log(ex.ToString());
            }
        }

        private void GetParametersFromUser()
        {
            if (_reportDocument.ParameterFields.Count > 0)
            {
                ReportParameterSelector form = new ReportParameterSelector(_reportDocument, _reporterBO);
                form.ShowDialog(this);
                form.Dispose();
            }
        }
    }
}
