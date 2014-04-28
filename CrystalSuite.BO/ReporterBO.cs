using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace CrystalSuite
{
    public class ReporterBO : IDisposable
    {
        public ReporterBO()
        {
            InitializeSettings();
            InitializeReports();
            InitializeDataAccess();
        }

        private SettingsFile _settingsFile;
        private ReportsFile _reportsFile;

        public SettingsFile SettingsFile
        {
            get { return _settingsFile; }
            set { XmlUtility.SaveSettingsToFile(value); }
        }

        public ReportsFile ReportsFile
        {
            get { return _reportsFile; }
            set { XmlUtility.SaveReportsToFile(value); }
        }

        private void InitializeSettings()
        {
            if (_settingsFile == null)
            {
                GetSettings();
            }
        }

        private void InitializeReports()
        {
            if (_reportsFile == null)
            {
                GetReports();
            }
        }

        private void GetSettings()
        {
            string filePath = FileUtility.GetAssemblyDirectory() + "\\Settings.xml";

            if (!File.Exists(filePath))
                CreateSettingsFile(filePath);

            _settingsFile = XmlUtility.GetSettingsFile(filePath);
        }

        private void GetReports()
        {
            string filePath = FileUtility.GetAssemblyDirectory() + "\\Reports.xml";

            if (!File.Exists(filePath))
                CreateReportsFile(filePath);

            _reportsFile = XmlUtility.GetReportsFile(filePath);
        }

        private void CreateSettingsFile(string filePath)
        {
            Assembly assembly = this.GetType().Assembly;
            BinaryReader reader = new BinaryReader(assembly.GetManifestResourceStream("CrystalSuite.Settings.xml"));
            FileStream stream = new FileStream(filePath, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(stream);
            try
            {
                byte[] buffer = new byte[64 * 1024];
                int numread = reader.Read(buffer, 0, buffer.Length);

                while (numread > 0)
                {
                    writer.Write(buffer, 0, numread);
                    numread = reader.Read(buffer, 0, buffer.Length);
                }

                writer.Flush();
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
                if (reader != null)
                    reader.Close();
            }
        }

        private void CreateReportsFile(string filePath)
        {
            Assembly assembly = this.GetType().Assembly;
            BinaryReader reader = new BinaryReader(assembly.GetManifestResourceStream("CrystalSuite.Reports.xml"));
            FileStream stream = new FileStream(filePath, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(stream);
            try
            {
                byte[] buffer = new byte[64 * 1024];
                int numread = reader.Read(buffer, 0, buffer.Length);

                while (numread > 0)
                {
                    writer.Write(buffer, 0, numread);
                    numread = reader.Read(buffer, 0, buffer.Length);
                }

                writer.Flush();
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
                if (reader != null)
                    reader.Close();
            }
        }

        public string ExportReportToPdf(string reportName, string parameterSetName)
        {
            string pdfFile = string.Empty;

            if (parameterSetName.Equals(string.Empty))
                Log("ExportReportToPDF - Param [parameterSetName] must have a value.");
            else
            {
                SetParameterSetNameArg(parameterSetName);
                pdfFile = ExportReportToPdf(reportName);
            }

            return pdfFile;
        }

        public string ExportReportToPdf(string reportName)
        {
            string pdfFile = string.Empty;

            if (reportName.Equals(string.Empty))
            {
                Log("ExportReportToPDF - Param [reportName] must have a value.");
            }
            else
            {
                ReportDocument reportDocument = new ReportDocument();
                try
                {
                    reportDocument.Load(SettingsFile.LocalReportFolder + reportName);
                    SetCrystalReportLogon(reportDocument);

                    pdfFile = GetNewPdfFileName();

                    if (HasParameterSetNameArg)
                        CreateParameterCollection(reportDocument.ParameterFields);

                    reportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, pdfFile);
                }
                catch (Exception ex)
                {
                    Log(ex.ToString());
                }
                finally
                {
                    reportDocument.Dispose();
                }
            }

            return pdfFile;
        }

        private string GetNewPdfFileName()
        {
            string directory = FileUtility.GetAssemblyDirectory() + "\\Exports";

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string pdfFile = directory + "\\" + DateTime.Now.ToFileTimeUtc() + ".pdf";

            return pdfFile;
        }

        private LogUtility _log;
        public void Log(string logInfo)
        {
            if (_log == null)
                _log = new LogUtility();

            _log.Log(logInfo);
        }

        public void SetCrystalReportLogon(ReportDocument reportDocument)
        {
            try
            {
                ConnectionInfo connectionInfo = new ConnectionInfo();
                connectionInfo.ServerName = SettingsFile.ServerName;
                connectionInfo.DatabaseName = SettingsFile.DatabaseName;
                connectionInfo.IntegratedSecurity = SettingsFile.IntegratedSecurity;
                connectionInfo.UserID = SettingsFile.UserID;
                connectionInfo.Password = SettingsFile.Password;

                foreach (Table table in reportDocument.Database.Tables)
                {
                    TableLogOnInfo tableLogOnInfo = table.LogOnInfo;
                    tableLogOnInfo.ConnectionInfo = connectionInfo;
                    table.ApplyLogOnInfo(tableLogOnInfo);
                }

                foreach (ReportDocument subReportDocument in reportDocument.Subreports)
                {
                    foreach (Table table in subReportDocument.Database.Tables)
                    {
                        TableLogOnInfo tableLogOnInfo = table.LogOnInfo;
                        tableLogOnInfo.ConnectionInfo = connectionInfo;
                        table.ApplyLogOnInfo(tableLogOnInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }
        }

        private ReporterDA _reporterDA;

        public Report SelectedReport { get; set; }
        public string SelectedReportPath { get; set; }

        public List<ParameterSet> AvailableParameterSets
        {
            get { return _reporterDA.GetParameterSetsByReportID(SelectedReport.ReportID); }
        }

        private void InitializeDataAccess()
        {
            _reporterDA = new ReporterDA(_settingsFile);
        }

        public void SetSelectedReportByReportPath(string reportPath)
        {
            SelectedReportPath = reportPath;

            SelectedReport = null;
            SelectedReport = _reporterDA.GetReportByFileName(Path.GetFileName(reportPath));
        }

        public ParameterSet SaveParameterSet(ParameterSet parameterSet)
        {
            if (parameterSet.ParameterSetID == 0)
                parameterSet = _reporterDA.InsertParameterSet(parameterSet);
            else
                parameterSet = _reporterDA.UpdateParameterSet(parameterSet);

            return parameterSet;
        }

        public void DeleteParameterSet(ParameterSet parameterSet)
        {
            _reporterDA.DeleteParameterSet(parameterSet);
        }

        public bool HasParameterSetNameArg { get; set; }
        private ParameterSet _parameterSetArg;

        public void SetParameterSetNameArg(string parameterSetName)
        {
            _parameterSetArg = _reporterDA.GetParameterSetByReportIDParameterSetName(SelectedReport.ReportID, parameterSetName);

            HasParameterSetNameArg = true;
        }

        public void CreateParameterCollection(ParameterFields parameterFields)
        {
            Dictionary<string, string> paramValuesDictionary = new Dictionary<string, string>();
            foreach (Parameter parameter in _parameterSetArg.Parameters)
            {
                paramValuesDictionary.Add(parameter.ParameterName, parameter.ParameterValue);
            }

            CreateParameterCollection(parameterFields, paramValuesDictionary);
        }

        public void CreateParameterCollection(ParameterFields parameterFields, Dictionary<string, string> paramValuesdictionary)
        {
            ParameterValues parameterValues;
            ParameterDiscreteValue parameterDiscreteValue;
            ParameterField parameterField;

            foreach (KeyValuePair<string, string> keyValuePair in paramValuesdictionary)
            {
                parameterValues = parameterFields[keyValuePair.Key].CurrentValues;
                string parameterSubText = keyValuePair.Value;

                if (parameterFields[keyValuePair.Key].DiscreteOrRangeKind == DiscreteOrRangeKind.RangeValue
                    && (parameterFields[keyValuePair.Key].ParameterValueType == ParameterValueKind.DateParameter
                        || parameterFields[keyValuePair.Key].ParameterValueType == ParameterValueKind.DateTimeParameter)
                    )
                {
                    ParameterRangeValue parameterRangeValue = new ParameterRangeValue();
                    int position = parameterSubText.IndexOf(" - ");

                    parameterRangeValue.EndValue = parameterSubText.Substring(position, parameterSubText.Length - position);
                    if (parameterRangeValue.EndValue.ToString() == "and up")
                    {
                        parameterRangeValue.EndValue = DateTime.Today;
                        parameterRangeValue.UpperBoundType = RangeBoundType.BoundInclusive;
                    }
                    else
                    {
                        parameterRangeValue.EndValue = Convert.ToDateTime(parameterRangeValue.EndValue);
                        parameterRangeValue.UpperBoundType = RangeBoundType.BoundInclusive;
                    }

                    parameterRangeValue.StartValue = parameterSubText.Substring(0, position - 1);
                    if (parameterRangeValue.StartValue.ToString() == "up to")
                    {
                        parameterRangeValue.StartValue = DateTime.Today;
                        parameterRangeValue.UpperBoundType = RangeBoundType.NoBound;
                    }
                    else
                    {
                        parameterRangeValue.StartValue = Convert.ToDateTime(parameterRangeValue.StartValue);
                        parameterRangeValue.UpperBoundType = RangeBoundType.BoundInclusive;
                    }

                    parameterValues.Add(parameterRangeValue);
                }
                else
                {
                    if (parameterFields[keyValuePair.Key].EnableAllowMultipleValue &&
                        keyValuePair.Value.Trim() != "All")
                    {
                        bool valid = true;
                        int position = 0;
                        int startPosition = 1;

                        if (parameterFields[keyValuePair.Key].ReportParameterType == ParameterType.StoreProcedureParameter)
                        {
                            string commaDelimList = string.Empty;
                            while (valid)
                            {
                                position = keyValuePair.Value.ToString().IndexOf(";", startPosition);
                                if (position == 0)
                                {
                                    parameterDiscreteValue = new ParameterDiscreteValue();
                                    commaDelimList += keyValuePair.Value.Substring(startPosition, keyValuePair.Value.Length);
                                    parameterDiscreteValue.Value = commaDelimList;

                                    parameterValues.Add(parameterDiscreteValue);
                                    return;
                                }
                                else
                                {
                                    commaDelimList += keyValuePair.Value.Substring(startPosition, position - startPosition) + ",";
                                    startPosition = position + 1;
                                }
                            }
                        }
                        else
                        {
                            while (valid)
                            {
                                position = keyValuePair.Value.ToString().IndexOf(";", startPosition);
                                if (position == 0)
                                {
                                    parameterDiscreteValue = new ParameterDiscreteValue();
                                    parameterDiscreteValue.Value = keyValuePair.Value.Substring(startPosition, keyValuePair.Value.Length);

                                    parameterValues.Add(parameterDiscreteValue);
                                    return;
                                }
                                else
                                {
                                    parameterDiscreteValue = new ParameterDiscreteValue();
                                    parameterDiscreteValue.Value = keyValuePair.Value.Substring(startPosition, position - startPosition);

                                    parameterValues.Add(parameterDiscreteValue);
                                    startPosition = position + 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        parameterField = parameterFields[keyValuePair.Key];
                        parameterValues = parameterField.CurrentValues;
                        parameterDiscreteValue = new ParameterDiscreteValue();

                        if (
                            (parameterFields[keyValuePair.Key].ParameterValueType == ParameterValueKind.DateParameter ||
                            parameterFields[keyValuePair.Key].ParameterValueType == ParameterValueKind.DateTimeParameter)
                            &&
                            (parameterSubText == "up to" || parameterSubText == "and up")
                            )
                        {
                            parameterDiscreteValue.Value = "1/1/1900";
                        }
                        else
                        {
                            parameterDiscreteValue.Value = parameterSubText;
                        }

                        parameterValues.Add(parameterDiscreteValue);
                    }
                }
            }
        }

        public bool IsDuplicateReportName(string reportName)
        {
            return _reporterDA.IsDuplicateFileName(reportName);
        }

        private bool _disposed = false;

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }


        ~ReporterBO()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_log != null)
                    _log.Dispose();
            }
        }

        protected void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        public List<Job> GetJobList()
        {
            throw new NotImplementedException();
        }
    }
}
