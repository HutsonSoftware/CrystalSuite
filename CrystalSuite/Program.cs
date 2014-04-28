using System;
using System.IO;
using System.Windows.Forms;

namespace CrystalSuite
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ReporterBO reporterBO = new ReporterBO();
            
            Application.Run(new ReportScheduler(reporterBO));

            //CommandLineParser parser = new CommandLineParser(args);
            //string reportName = parser["reportName"];

            //if (reportName != null)
            //{
            //    string localReportPath = reporterBO.SettingsFile.LocalReportFolder + reportName;

            //    if (File.Exists(localReportPath))
            //    {
            //        reporterBO.SetSelectedReportByReportPath(localReportPath);
            //        reporterBO.SetParameterSetNameArg(parser["parameterSetName"]);

            //        Application.Run(new ReportViewer(reporterBO));
            //    }
            //    else
            //        Application.Run(new ReportSelector(reporterBO));
            //}
            //else
            //    Application.Run(new ReportSelector(reporterBO));

            //parser = null;
            reporterBO.Dispose();
        }
    }
}
