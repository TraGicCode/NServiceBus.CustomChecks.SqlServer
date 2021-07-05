using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using NServiceBus.Logging;

namespace NServiceBus.CustomChecks.SqlServer
{
    public abstract class SqlServerCustomCheck : CustomCheck
    {
        private readonly string _connectionString;
        private static readonly ILog Log = LogManager.GetLogger<SqlServerCustomCheck>();

        protected SqlServerCustomCheck(string connectionString, TimeSpan? repeatAfter) : base("Monitor Sql", "Database", repeatAfter)
        {
            _connectionString = connectionString;
        }
        public override Task<CheckResult> PerformCheck()
        {
            var start = Stopwatch.StartNew();
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    Log.Info($"Succeeded in contacting {connection.Database}");
                    return CheckResult.Pass;
                }
                catch (SqlException exception)
                {
                    var error = $"Failed to contact '{connection.Database}'. Duration: {start.Elapsed} Error: {exception.Message}";
                    Log.Error(error);
                    return CheckResult.Failed(error);
                }
            }
        }
    }
}