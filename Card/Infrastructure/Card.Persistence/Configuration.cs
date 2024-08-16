using Microsoft.Extensions.Configuration;

namespace Card.Persistence
{
    public static class Configuration
    {
        static public List<(string server, string database, string userId, string password)> CardConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory()));
                var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                configurationManager.AddJsonFile(environmentName == "Development" ? "appsettings.json" : $"appsettings.{environmentName}.json");

                List<(string server, string database, string userId, string password)> connectionDatas = new();

                connectionDatas.Add((configurationManager.GetConnectionString("Server"),
                                    configurationManager.GetConnectionString("CardDatabase"),
                                    configurationManager.GetConnectionString("UserId"),
                                    configurationManager.GetConnectionString("Password")));

                return connectionDatas;
            }
        }

        //public static List<SocialMedia> SocialMedias
        //{
        //    get
        //    {
        //        List<SocialMedia> socialMedias = new()
        //        {
        //            new SocialMedia
        //            {
        //                Name = "Twitter",
        //            },
        //            new SocialMedia
        //            {
        //               Name = "Facebook",
        //            },
        //            new SocialMedia
        //            {
        //               Name = "Linkedin",
        //            },
        //            new SocialMedia
        //            {
        //               Name = "Instagram",
        //            },
        //            new SocialMedia
        //            {
        //               Name = "Twitch",
        //            },
        //            new SocialMedia
        //            {
        //               Name = "Web Site",
        //            },
        //            new SocialMedia
        //            {
        //               Name = "TikTok",
        //            },
        //            new SocialMedia
        //            {
        //               Name = "Pinterest",
        //            }
        //        };

        //        foreach (var item in socialMedias)
        //        {
        //            item.Id = Guid.NewGuid();
        //            item.CreatedDate = DateTime.Now;
        //            item.CreatedBy = "System Configuration";
        //        }

        //        return socialMedias;
        //    }
        //}
    }
}
