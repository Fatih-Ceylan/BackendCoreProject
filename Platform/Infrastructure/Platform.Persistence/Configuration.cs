using Microsoft.Extensions.Configuration;
using Platform.Domain.Entities.Definitions;

namespace Platform.Persistence
{
    public static class Configuration
    {
        public static string PlatformConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory()));

                var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                configurationManager.AddJsonFile(environmentName == "Development" ? "appsettings.json" : $"appsettings.{environmentName}.json");

                return configurationManager.GetConnectionString("PlatformSqlServer");
            }
        }

        public static List<GModule> GModules
        {
            get
            {
                List<GModule> gModules = new()
                {
                    new GModule
                    {
                        Name = "GControl",
                    },
                    new GModule
                    {
                       Name = "Card",
                    },
                    new GModule
                    {
                       Name = "HR",
                    },
                    new GModule
                    {
                       Name = "GCrm",
                    }
                };

                foreach (var item in gModules)
                {
                    item.Id = Guid.NewGuid();
                    item.CreatedDate = DateTime.Now;
                    item.CreatedBy = "System Configuration";
                }

                return gModules;
            }
        }

        public static List<LicenseType> LicenseTypes
        {
            get
            {
                List<LicenseType> licenseTypes = new()
                {
                    new LicenseType
                    {
                        Name = "Deneme 1 ay",
                        UsageMounth = 1,
                        UserNumber = 1,
                        CompanyNumber = 1,
                    },
                    new LicenseType
                    {
                        Name = "1 Yıl",
                        UsageMounth = 12,
                        UserNumber = 3,
                        CompanyNumber = 3,
                    },
                    new LicenseType
                    {
                        Name = "2 Yıl",
                        UsageMounth = 24,
                        UserNumber = 3,
                        CompanyNumber = 3,
                    },
                    new LicenseType
                    {
                        Name = "3 Yıl",
                        UsageMounth = 36,
                        UserNumber = 3,
                        CompanyNumber = 3,
                    },
                };

                foreach (var item in licenseTypes)
                {
                    item.Id = Guid.NewGuid();
                    item.CreatedDate = DateTime.Now;
                    item.CreatedBy = "System Configuration";
                }

                return licenseTypes;
            }
        }
    }
}