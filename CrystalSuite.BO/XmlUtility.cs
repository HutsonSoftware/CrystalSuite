using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace CrystalSuite
{
    class XmlUtility
    {
        public static SettingsFile GetSettingsFile(string filePath)
        {
            SettingsFile settingsFile = new SettingsFile();

            if (File.Exists(filePath))
            {
                settingsFile.FilePath = filePath;

                XmlReader reader = XmlReader.Create(filePath);
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "LocalReportFolder":
                                if (reader.Read())
                                    settingsFile.LocalReportFolder = reader.Value.Trim().EndsWith("\\") == true ? reader.Value.Trim() : reader.Value.Trim() + "\\";
                                break;
                            case "ServerReportFolder":
                                if (reader.Read())
                                    settingsFile.ServerReportFolder = reader.Value.Trim().EndsWith("\\") == true ? reader.Value.Trim() : reader.Value.Trim() + "\\";
                                break;
                            case "DsnName":
                                if (reader.Read())
                                    settingsFile.DsnName = reader.Value.Trim();
                                break;
                            case "ServerName":
                                if (reader.Read())
                                    settingsFile.ServerName = reader.Value.Trim();
                                break;
                            case "DatabaseName":
                                if (reader.Read())
                                    settingsFile.DatabaseName = reader.Value.Trim();
                                break;
                            case "IntegratedSecurity":
                                if (reader.Read())
                                    settingsFile.IntegratedSecurity = (bool)(reader.Value.Trim() == "1" ? true : false);
                                break;
                            case "UserID":
                                if (reader.Read())
                                    settingsFile.UserID = reader.Value.Trim();
                                break;
                            case "Password":
                                if (reader.Read())
                                    settingsFile.Password = reader.Value.Trim();
                                break;
                        }
                    }
                }
                reader.Close();
                reader = null;
            }
            return settingsFile;
        }

        public static void SaveSettingsToFile(SettingsFile settings)
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings { Encoding = Encoding.UTF8, Indent = true };
            xmlWriterSettings.OmitXmlDeclaration = true;

            XmlWriter writer = XmlWriter.Create(settings.FilePath, xmlWriterSettings);
            writer.WriteStartElement("Settings");

            writer.WriteElementString("LocalReportFolder", settings.LocalReportFolder);
            writer.WriteElementString("ServerReportFolder", settings.ServerReportFolder);
            writer.WriteElementString("DsnName", settings.DsnName);
            writer.WriteElementString("ServerName", settings.ServerName);
            writer.WriteElementString("DatabaseName", settings.DatabaseName);
            writer.WriteElementString("IntegratedSecurity", (settings.IntegratedSecurity == true ? "1" : "0"));
            writer.WriteElementString("UserID", settings.UserID);
            writer.WriteElementString("Password", settings.Password);

            writer.WriteEndElement();
            writer.WriteEndDocument();

            writer.Flush();
            writer.Close();
            writer = null;
        }

        public static ReportsFile GetReportsFile(string filePath)
        {
            ReportsFile reportsFile = new ReportsFile();
            List<Report> reportList = new List<Report>();

            if (File.Exists(filePath))
            {
                reportsFile.FilePath = filePath;

                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Report");
                foreach (XmlNode node in nodes)
                {
                    Report report = new Report();
                    report.ReportID = Int32.Parse(node.SelectSingleNode("/ReportID").ToString());
                    report.FileName = node.SelectSingleNode("/FileName").ToString();
                    report.FilePath = node.SelectSingleNode("/FilePath").ToString();
                    
                    reportList.Add(report);
                }
            }
            reportsFile.ReportList = reportList;
            return reportsFile;
        }

        public static void SaveReportsToFile(ReportsFile reportsFile)
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings { Encoding = Encoding.UTF8, Indent = true };
            xmlWriterSettings.OmitXmlDeclaration = true;

            XmlWriter writer = XmlWriter.Create(reportsFile.FilePath, xmlWriterSettings);
            writer.WriteStartElement("Reports");

            foreach (Report report in reportsFile.ReportList)
            {
                writer.WriteStartElement("Report");
                writer.WriteElementString("ReportID", report.ReportID.ToString());
                writer.WriteElementString("FileName", report.FileName);
                writer.WriteElementString("FilePath", report.FilePath);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();

            writer.Flush();
            writer.Close();
            writer = null;
        }
    }
}
