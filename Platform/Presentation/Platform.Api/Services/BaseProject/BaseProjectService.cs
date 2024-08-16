using BaseProject.Application.DTOs.Identity.AppUser;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace Platform.Api.Services.BaseProject
{
    public class BaseProjectService : IBaseProjectService
    {
        IConfiguration _configuration;

        public BaseProjectService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> AddUser(CreateUserRequestDTO user, string accessToken, string routeName)
        {

            using (var client = new HttpClient())
            {
                var baseProjectDeployedUrl = _configuration["BaseProject:DeployedUrl"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Add("Route-Name", routeName);

                string createUserUrl = $"{baseProjectDeployedUrl}user/create-from-platform";

                HttpResponseMessage userCreateResponse = await client.PostAsJsonAsync(createUserUrl, user);

                if (userCreateResponse.IsSuccessStatusCode)
                {
                    return "user added success";
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public async Task<string> SoftDeleteAllUsers(string accessToken, string routeName)
        {
            using (var client = new HttpClient())
            {
                var baseProjectDeployedUrl = _configuration["BaseProject:DeployedUrl"];
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Add("Route-Name", "samet");

                string getAllUserUrl = $"{baseProjectDeployedUrl}user/getall";
                HttpResponseMessage getAllUserResponse = await client.GetAsync(getAllUserUrl);

                if (getAllUserResponse.IsSuccessStatusCode)
                {
                    string usersJson = await getAllUserResponse.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(usersJson);
                    int totalCount = (int)json["totalCount"];
                    
                    if (totalCount > 0)
                    {
                        JArray usersArray = (JArray)json["appUsers"];
                        List<string> userIds = new();

                        foreach (var user in usersArray)
                        {
                            string userId = (string)user["id"];
                            userIds.Add(userId);
                        }

                        string deleteUserUrl = $"{baseProjectDeployedUrl}user/delete";
                        HttpResponseMessage deleteUserResponse = new();

                        foreach (var item in userIds)
                        {
                            deleteUserResponse = await client.DeleteAsync($"{deleteUserUrl}/{item}");

                            if (!deleteUserResponse.IsSuccessStatusCode)
                            {
                                throw new Exception($"Some users can not deleted.Please check {routeName}_base database AspnetUsers table!");
                            }
                        }

                        return "Users deleted success";
                    }
                    else
                    {
                        throw new Exception("There are no registered users.");
                    }

                }
                else
                {
                    throw new Exception($"Please check database.{routeName} database may not have been created!");
                }
            }
        }
    }
}