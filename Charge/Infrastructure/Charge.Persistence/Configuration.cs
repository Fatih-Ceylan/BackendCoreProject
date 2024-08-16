﻿using Microsoft.Extensions.Configuration;

namespace GCharge.Persistence
{
    public static class Configuration
    {

        static public List<(string server, string database, string userId, string password)> GChargeConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory()));
                var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                configurationManager.AddJsonFile(environmentName == "Development" ? "appsettings.json" : $"appsettings.{environmentName}.json");

                List<(string server, string database, string userId, string password)> connectionDatas = new();

                connectionDatas.Add((configurationManager.GetConnectionString("Server"),
                                    configurationManager.GetConnectionString("GChargeDatabase"),
                                    configurationManager.GetConnectionString("UserId"),
                                    configurationManager.GetConnectionString("Password")));

                return connectionDatas;
            }
        }
    }
}