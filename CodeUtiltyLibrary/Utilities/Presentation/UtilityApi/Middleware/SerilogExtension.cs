using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;


namespace Utilities.Presentation.UtilityApi.Middleware
{
    public static class SerilogExtension
    {

        public static Serilog.ILogger CreateLogger(IConfiguration configuration)
        {
            //    var columnOptions = new ColumnOptions();
            //    columnOptions.AdditionalColumns = new List<SqlColumn>
            //{
            //    new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "CreatedBy", DataLength = 50, AllowNull = true },
            //};

            //    var sinkOptions = new MSSqlServerSinkOptions()
            //    {
            //        TableName = "logs",
            //        AutoCreateSqlTable = true
            //    };

            //    var connectionString = configuration.GetConnectionString("SqlServer");

            //    if (string.IsNullOrEmpty(connectionString))
            //    {
            //        connectionString = $"Server={configuration.GetConnectionString("Server")};" +
            //                                    $" Database=baseproject_base; " +
            //                                    //$" Database={headerDbName?.ToLower()}_base; " +
            //                                    $"User Id={configuration.GetConnectionString("UserId")};" +
            //                                    $" Password={configuration.GetConnectionString("Password")}; TrustServerCertificate=True";
            //    }



            var logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File("logs/log.txt", rollingInterval:RollingInterval.Day)
                //.WriteTo.MSSqlServer(connectionString, sinkOptions, null, null,
                // LogEventLevel.Information, columnOptions: columnOptions)
                .Enrich.FromLogContext()
                //.Filter.ByIncludingOnly(evt => evt.MessageTemplate.Text.Contains("exception"))
                .CreateLogger();

            return logger;
        }

        public static void AddCustomHttpLogging(this IServiceCollection services)
        {
            services.AddHttpLogging(logging =>
            {
                logging.LoggingFields = HttpLoggingFields.ResponseBody;
                //logging.RequestHeaders.Add("sec-ch-ua");
                logging.MediaTypeOptions.AddText("application/javascript");
                logging.RequestBodyLogLimit = 4096;
                logging.ResponseBodyLogLimit = 4096;
            });
        }

    }
}
