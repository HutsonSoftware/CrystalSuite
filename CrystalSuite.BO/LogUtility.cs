using System;
using System.IO;

namespace CrystalSuite
{
    internal class LogUtility : IDisposable
    {
        private string _logFile;

        public LogUtility()
        {
            GetNewLogFile();
        }

        private void GetNewLogFile()
        {
            string directory = FileUtility.GetAssemblyDirectory() + "\\Logs";

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            _logFile = directory + "\\" + DateTime.Now.ToFileTimeUtc() + ".log";
        }

        StreamWriter _log;
        public void Log(string logInfo)
        {
            if (!File.Exists(_logFile))
                _log = new StreamWriter(_logFile);
            else
                _log = File.AppendText(_logFile);

            _log.WriteLine(DateTime.Now);
            _log.WriteLine(logInfo);
            _log.WriteLine();

            _log.Close();
        }

        public void Dispose()
        {
            _log.Dispose();
        }
    }
}
