using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace CrystalSuite
{
    public class ReporterDA
    {
        private SettingsFile _settings;

        internal ReporterDA(SettingsFile settings)
        {
            _settings = settings;
        }

        private string GetConnectionString()
        {
            return string.Format("Server={0};Database={1};Uid={2};Pwd={3}", _settings.ServerName, _settings.DatabaseName, _settings.UserID, _settings.Password);
        }

        private void AddSqlParameter(SqlCommand cmd, string parameterName, SqlDbType sqlDbType, object parameterValue)
        {
            SqlParameter param = cmd.Parameters.Add(parameterName, sqlDbType);
            param.Value = parameterValue;
        }

        private void AddSqlParameter(SqlCommand cmd, string parameterName, SqlDbType sqlDbType, int size, object parameterValue)
        {
            SqlParameter param = cmd.Parameters.Add(parameterName, sqlDbType, size);
            param.Value = parameterValue;
        }

        internal Report GetReportByFileName(string fileName)
        {
            Report report = new Report();

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlDataReader dr = null;

                SqlCommand cmd = new SqlCommand("usp_GetReportByFileName", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "FileName", SqlDbType.VarChar, 8000, Path.GetFileName(fileName));

                connection.Open();
                dr = cmd.ExecuteReader();
                cmd.Dispose();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        report.ReportID = (int)dr["ReportID"];
                        report.FileName = dr["FileName"].ToString();
                        break;
                    }
                }
                else
                {
                    Report newReport = new Report();
                    newReport.FileName = fileName;

                    newReport.ReportID = InsertReport(newReport);
                    report = GetReportByFileName(fileName);
                }
            }

            return report;
        }

        internal List<ParameterSet> GetParameterSetsByReportID(int reportID)
        {
            List<ParameterSet> parameterSets = new List<ParameterSet>();

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlDataReader dr = null;

                SqlCommand cmd = new SqlCommand("usp_GetParameterSetsByReportID", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "ReportID", SqlDbType.Int, reportID);

                connection.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ParameterSet parameterSet = new ParameterSet();

                    parameterSet.ParameterSetID = (int)dr["ParameterSetID"];
                    parameterSet.ReportID = (int)dr["ReportID"];
                    parameterSet.ParameterSetName = dr["ParameterSetName"].ToString();
                    parameterSet.ParameterSetDescription = dr["ParameterSetDescription"].ToString();

                    parameterSet.Parameters = GetParametersByParameterSetID(parameterSet.ParameterSetID);

                    parameterSets.Add(parameterSet);
                }
                cmd.Dispose();
            }

            return parameterSets;
        }

        internal ParameterSet GetParameterSetByReportIDParameterSetName(int reportID, string parameterSetName)
        {
            ParameterSet parameterSet = new ParameterSet();

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlDataReader dr = null;

                SqlCommand cmd = new SqlCommand("usp_GetParameterSetByReportIDParameterSetName", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "ReportID", SqlDbType.Int, reportID);
                AddSqlParameter(cmd, "ParameterSetName", SqlDbType.VarChar, 45, parameterSetName);

                connection.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    parameterSet.ParameterSetID = (int)dr["ParameterSetID"];
                    parameterSet.ReportID = (int)dr["ReportID"];
                    parameterSet.ParameterSetName = dr["ParameterSetName"].ToString();
                    parameterSet.ParameterSetDescription = dr["ParameterSetDescription"].ToString();

                    parameterSet.Parameters = GetParametersByParameterSetID(parameterSet.ParameterSetID);

                    break;
                }
                cmd.Dispose();
            }
            return parameterSet;
        }

        internal List<Parameter> GetParametersByParameterSetID(int parameterSetID)
        {
            List<Parameter> parameters = new List<Parameter>();

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlDataReader dr = null;

                SqlCommand cmd = new SqlCommand("usp_GetParametersByParameterSetID", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "ParameterSetID", SqlDbType.Int, parameterSetID);

                connection.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Parameter parameter = new Parameter();
                    parameter.ParameterID = (int)dr["ParameterID"];
                    parameter.ParameterSetID = (int)dr["ParameterSetID"];
                    parameter.ParameterName = dr["ParameterName"].ToString();
                    parameter.ParameterValue = dr["ParameterValue"].ToString();

                    parameters.Add(parameter);
                }
                cmd.Dispose();
            }

            return parameters;
        }

        internal int InsertReport(Report report)
        {
            int reportID = 0;

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertReport", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "FileName", SqlDbType.VarChar, 4000, report.FileName);

                connection.Open();

                reportID = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
            }

            return reportID;
        }

        internal ParameterSet InsertParameterSet(ParameterSet parameterSet)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertParameterSet", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "ReportID", SqlDbType.Int, parameterSet.ReportID);
                AddSqlParameter(cmd, "ParameterSetName", SqlDbType.VarChar, 4000, parameterSet.ParameterSetName);
                AddSqlParameter(cmd, "ParameterSetDescription", SqlDbType.VarChar, 4000, parameterSet.ParameterSetDescription);

                connection.Open();

                parameterSet.ParameterSetID = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
            }

            for (int i = 0; i < parameterSet.Parameters.Count; i++)
            {
                parameterSet.Parameters[i].ParameterSetID = parameterSet.ParameterSetID;
                parameterSet.Parameters[i] = InsertParameter(parameterSet.Parameters[i]);
            }

            return parameterSet;
        }

        internal Parameter InsertParameter(Parameter parameter)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertParameter", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "ParameterSetID", SqlDbType.Int, parameter.ParameterSetID);
                AddSqlParameter(cmd, "ParameterName", SqlDbType.VarChar, 4000, parameter.ParameterName);
                AddSqlParameter(cmd, "ParameterValue", SqlDbType.VarChar, 4000, parameter.ParameterValue);

                connection.Open();

                parameter.ParameterID = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
            }

            return parameter;
        }

        internal Report UpdateReport(Report report)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateReport", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "ReportID", SqlDbType.Int, report.ReportID);
                AddSqlParameter(cmd, "FileName", SqlDbType.VarChar, 4000, report.FileName);

                connection.Open();

                cmd.ExecuteScalar();
                cmd.Dispose();
            }
            return report;
        }

        internal ParameterSet UpdateParameterSet(ParameterSet parameterSet)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateParameterSet", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "ParameterSetID", SqlDbType.Int, parameterSet.ParameterSetID);
                AddSqlParameter(cmd, "ReportID", SqlDbType.Int, parameterSet.ReportID);
                AddSqlParameter(cmd, "ParameterSetName", SqlDbType.VarChar, 4000, parameterSet.ParameterSetName);
                AddSqlParameter(cmd, "ParameterSetDescription", SqlDbType.VarChar, 4000, parameterSet.ParameterSetDescription);

                connection.Open();

                cmd.ExecuteScalar();
                cmd.Dispose();
            }
            for (int i = 0; i < parameterSet.Parameters.Count; i++)
            {
                parameterSet.Parameters[i].ParameterSetID = parameterSet.ParameterSetID;
                if (parameterSet.Parameters[i].ParameterID == 0)
                    parameterSet.Parameters[i] = InsertParameter(parameterSet.Parameters[i]);
                else
                    parameterSet.Parameters[i] = UpdateParameter(parameterSet.Parameters[i]);

            }

            return parameterSet;
        }

        internal Parameter UpdateParameter(Parameter parameter)
        {
            int result = 0;

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateParameter", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "ParameterID", SqlDbType.Int, parameter.ParameterID);
                AddSqlParameter(cmd, "ParameterSetID", SqlDbType.Int, parameter.ParameterSetID);
                AddSqlParameter(cmd, "ParameterName", SqlDbType.VarChar, 4000, parameter.ParameterName);
                AddSqlParameter(cmd, "ParameterValue", SqlDbType.VarChar, 4000, parameter.ParameterValue);

                connection.Open();

                result = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
            }
            return parameter;
        }

        internal void DeleteReport(Report report)
        {
            int result = 0;

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteReport", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "ReportID", SqlDbType.Int, report.ReportID);

                connection.Open();

                result = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
            }
        }

        internal void DeleteParameterSet(ParameterSet parameterSet)
        {
            int result = 0;

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteParameterSet", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "ParameterSetID", SqlDbType.Int, parameterSet.ParameterSetID);

                connection.Open();

                result = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
            }
        }

        internal void DeleteParameter(Parameter parameter)
        {
            int result = 0;

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteParameter", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "ParameterID", SqlDbType.Int, parameter.ParameterID);

                connection.Open();

                result = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
            }
        }

        internal bool IsDuplicateFileName(string fileName)
        {
            bool result = false;

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("usp_IsDuplicateFileName", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "FileName", SqlDbType.VarChar, 4000, fileName);

                connection.Open();

                result = Convert.ToBoolean(cmd.ExecuteScalar());
                cmd.Dispose();
            }

            return result;
        }

        internal DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlDataReader dr = null;

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;

                connection.Open();
                dr = cmd.ExecuteReader();

                dt.Columns.Clear();
                DataTable schema = dr.GetSchemaTable();
                foreach (DataRowView row in schema.DefaultView)
                {
                    string columnName = (string)row["ColumnName"];
                    Type type = (Type)row["DataType"];
                    dt.Columns.Add(columnName, type);
                }

                dt.Load(dr);

                cmd.Dispose();
            }

            return dt;
        }
    }
}
