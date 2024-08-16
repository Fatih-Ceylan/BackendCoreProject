using BaseProject.Domain.Entities.GControl.Definitions;
using GControl.Application.Abstractions.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using Utilities.Core.UtilityApplication.Exceptions;

namespace GControl.Infrastructure.Services
{
    public class BaseProjectService : IBaseProjectService
    {
        IConfiguration _configuration;

        public BaseProjectService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<DepartmentResponse> GetDepartments(string accessToken, string routeName)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var bPDeployedUrl = _configuration["BaseProject:DeployedUrl"];
                    string[] parts;

                    if (accessToken != null)
                    {
                        parts = accessToken.Split(' ');
                    }
                    else
                    {
                        throw new TokenNotFoundException("Access token not found!");
                    }
                    string token = parts.Length > 1 ? parts[1] : parts[0];
                    // Now parts[0] contains "Bearer" and parts[1] contains the token
                    //string token = parts[1];

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    client.DefaultRequestHeaders.Add("Route-Name", routeName);

                    string getDepartmentURL = $"{bPDeployedUrl}Department/GetAll";
                    HttpResponseMessage response = await client.GetAsync(getDepartmentURL);

                    if (response.IsSuccessStatusCode)
                    {
                        string departmentJson = await response.Content.ReadAsStringAsync();
                        JObject json = JObject.Parse(departmentJson);
                        DepartmentResponse departmentResponseModel = JsonConvert.DeserializeObject<DepartmentResponse>(departmentJson);

                        return departmentResponseModel;
                    }

                    else
                    {
                        throw new Exception(response.StatusCode.ToString());
                    }
                }
                
                catch (Exception ex)
                {
                    throw InnerException.GetOriginalException(ex);
                }
            }
        }
    }
}
