using System.Collections.Generic;

namespace CrystalSuite
{
    public class Report
    {
        public Report()
        {
            ReportID = 0;
            FileName = string.Empty;
            FilePath = string.Empty;
        }
        public Report(string fileName, string filePath)
        {
            ReportID = 0;
            FileName = fileName;
            FilePath = filePath;
        }
        public int ReportID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }

    public class ParameterSet
    {
        public ParameterSet()
        {
            ParameterSetID = 0;
            Parameters = new List<Parameter>();
        }
        public int ParameterSetID { get; set; }
        public int ReportID { get; set; }
        public string ParameterSetName { get; set; }
        public string ParameterSetDescription { get; set; }
        public List<Parameter> Parameters { get; set; }
    }

    public class Parameter
    {
        public Parameter() { ParameterID = 0; }
        public int ParameterID { get; set; }
        public int ParameterSetID { get; set; }
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
    }

    public class JobBase
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public string Created { get; set; }
        public string Modified { get; set; }
    }

    public class Job : JobBase
    {
        public string Owner { get; set; }
        public List<JobStep> Steps { get; set; }
        public JobSchedule Schedule { get; set; }
        public int StartStep { get; set; }
        public string LastExecuted { get; set; }
    }

    public class JobStep : JobBase
    {
        public int Number { get; set; }
        public eJobAction OnSuccess { get; set; }
        public eJobAction OnFailure { get; set; }
        public int RetryAttempts { get; set; }
        public int RetryIntervalMinutes { get; set; }
    }

    public class JobSchedule : JobBase
    {
        public eJobFrequency Frequency { get; set; }
        public int RecursEveryN { get; set; }
        public string OccursOnceAtTime { get; set; }
        public string OccursEveryN { get; set; }
        public string OccursEveryUnits { get; set; }
        public string OccursEveryStartTime { get; set; }
        public string OccursEveryEndTime { get; set; }
        public int DaysBitwise { get; set; }
        public int DayN { get; set; }
        public int EveryNMonths { get; set; }
        public eFrequencyN TheBlank { get; set; }
        public eFrequencyDays TheBlankWhat { get; set; }
        public int TheBlankWhatofNMonths { get; set; }
        public string StartDate { get; set; }
        public bool HasEndDate { get; set; }
        public string EndDate { get; set; }
        public string WeeklyFrequency { get; set; }
        public string DailyFrequency { get; set; }
    }

    public enum eJobFrequency { Daily, Weekly, Monthly }
    public enum eJobAction { GoToNextStep, QuitReportingSuccess, QuitReportingFailure }
    public enum eFrequencyN { first, second, third, fourth, last }
    public enum eFrequencyDays { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday, day, weekday, weekendday }

}
