using System.Collections.Generic;
namespace CrystalSuite
{
    public class SettingsFile
    {
        public string FilePath { get; set; }
        public string LocalReportFolder { get; set; }
        public string ServerReportFolder { get; set; }
        public string DsnName { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public bool IntegratedSecurity { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
    }

    public class ReportsFile
    {
        public string FilePath { get; set; }
        public List<Report> ReportList { get; set; }
    }
}
