using Microsoft.Extensions.Configuration;

namespace NLLogistics.Persistence
{
    static public class Configuration
    {
        static public List<(string server, string database, string userId, string password)> BaseProjectConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();

                try
                {
                    configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..\\BaseProject.Api"));
                }
                catch (Exception)
                {
                    configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory()));
                }

                configurationManager.AddJsonFile("appsettings.json");

                List<(string server, string database, string userId, string password)> connectionDatas = new();

                connectionDatas.Add((configurationManager.GetConnectionString("Server"),
                                    configurationManager.GetConnectionString("BaseProjectDatabase"),
                                    configurationManager.GetConnectionString("UserId"),
                                    configurationManager.GetConnectionString("Password")));

                return connectionDatas;
            }
        }
    }
}