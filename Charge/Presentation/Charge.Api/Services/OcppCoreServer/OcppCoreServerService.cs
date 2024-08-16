using GCharge.Api.Services.OcppCoreServer.Models.Transaction.RemoteStartTransaction;
using GCharge.Api.Services.OcppCoreServer.Models.Transaction.RemoteStopTransaction;
using GCharge.Application.Repositories.ReadRepository.Definitions;
using GCharge.Persistence.Contexts;
using Newtonsoft.Json;
using System.Text;
using Utilities.Core.UtilityApplication.Abstractions.Services.CurrentUser;

namespace GCharge.Api.Services.OcppCoreServer
{
    public class OcppCoreServerService : IOcppCoreServerService
    {
        readonly IConfiguration _configuration;
        readonly GChargeDbContext _dbContext;
        readonly ICurrentUserService _currentUserService;
        readonly ITransactionReadRepository _transactionReadRepository;
        readonly IHttpContextAccessor _httpContextAccessor;
        public OcppCoreServerService(IConfiguration configuration, ICurrentUserService currentUserService, GChargeDbContext dbContext, ITransactionReadRepository transactionReadRepository, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _currentUserService = currentUserService;
            _dbContext = dbContext;
            _transactionReadRepository = transactionReadRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<RemoteStartTransactionResponse> RemoteStartTransaction(RemoteStartTransactionRequest request)
        {
            var currentUser = await _currentUserService.GetCurrentUser();

            RemoteStartTransactionResponse remoteStartTransactionResponse = new();

            string serverApiUrl = _configuration["OcppCore:ServerApiUrl"];
            string apiKeyConfig = _configuration["OcppCore:ApiKey"];
            string routeName = _httpContextAccessor?.HttpContext?.Request?.Headers?["Route-Name"];

            if (string.IsNullOrEmpty(serverApiUrl))
            {
                // Logger.LogError("OCPPApiError: Server API URL is not configured.");
                throw new Exception("Server API URL is not configured.");
            }
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, 0, 10);

                    if (!serverApiUrl.EndsWith('/'))
                    {
                        serverApiUrl += "/";
                    }

                    Uri uri = new Uri(serverApiUrl);
                    uri = new Uri(uri, $"RemoteStartTransaction/{request.ChargePointId}");

                    RemoteStartTransactionModel remoteStartTransaction = new();
                    remoteStartTransaction.ConnectorId = request.ConnectorId;
                    remoteStartTransaction.IdTag = currentUser.IdTag;
                    string jsonData = JsonConvert.SerializeObject(remoteStartTransaction);
                    var jsonContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    if (string.IsNullOrWhiteSpace(apiKeyConfig))
                    {
                        throw new Exception("X-API-Key is empty");
                    }

                    if (string.IsNullOrWhiteSpace(routeName))
                    {
                        throw new Exception("Route-Name header is empty");
                    }

                    httpClient.DefaultRequestHeaders.Add("X-API-Key", apiKeyConfig);
                    httpClient.DefaultRequestHeaders.Add("Route-Name", routeName);

                    HttpResponseMessage response = await httpClient.PostAsync(uri, jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResult = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(jsonResult))
                        {
                            remoteStartTransactionResponse = JsonConvert.DeserializeObject<RemoteStartTransactionResponse>(jsonResult);
                        }
                        else
                        {
                            throw new Exception(response.StatusCode.ToString());
                        }
                    }
                    else
                    {
                        throw new Exception(response.StatusCode.ToString());
                    }
                }
            }
            catch (Exception exp)
            {
                throw new Exception("", exp);
            }
            return remoteStartTransactionResponse;
        }

        public async Task<RemoteStopTransactionResponse> RemoteStopTransaction(RemoteStopTransactionRequest request)
        {
            string routeName = _httpContextAccessor?.HttpContext?.Request?.Headers?["Route-Name"];

            var user = await _currentUserService?.GetCurrentUser();

            RemoteStopTransactionResponse remoteStopTransactionResponse = new RemoteStopTransactionResponse();

            string serverApiUrl = _configuration["OcppCore:ServerApiUrl"];
            string apiKeyConfig = _configuration["OcppCore:ApiKey"];

            if (string.IsNullOrEmpty(serverApiUrl))
            {
                throw new Exception("Server API URL is not configured.");
            }

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, 0, 10);

                    if (!serverApiUrl.EndsWith('/'))
                    {
                        serverApiUrl += "/";
                    }

                    Uri uri = new Uri(serverApiUrl);
                    uri = new Uri(uri, $"RemoteStopTransaction/{request.ChargePointId}");
                    string jsonData;


                    var transaction = _transactionReadRepository.GetWhere(t => t.ChargePointId == request.ChargePointId &&
                                                           t.ConnectorId == request.ConnectorId &&
                                                           t.StartTime >= DateTime.UtcNow.AddHours(-8) &&
                                                           t.StopTime == null).OrderByDescending(t => t.TransactionId).FirstOrDefault();


                    if (transaction != null)
                    {
                        int transactionId = transaction.TransactionId;
                        var transactionData = new { transactionId = transactionId };
                        jsonData = JsonConvert.SerializeObject(transactionData);
                    }
                    else
                    {
                        throw new Exception("Transaction not found");
                    }

                    var jsonContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    if (string.IsNullOrWhiteSpace(apiKeyConfig))
                    {
                        throw new Exception("X-API-Key is empty");
                    }

                    if (string.IsNullOrWhiteSpace(routeName))
                    {
                        throw new Exception("Route-Name header is empty");
                    }

                    httpClient.DefaultRequestHeaders.Add("X-API-Key", apiKeyConfig);
                    httpClient.DefaultRequestHeaders.Add("Route-Name", routeName);

                    HttpResponseMessage response = await httpClient.PostAsync(uri, jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResult = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(jsonResult))
                        {
                            remoteStopTransactionResponse = JsonConvert.DeserializeObject<RemoteStopTransactionResponse>(jsonResult);
                        }
                        else
                        {
                            throw new Exception("Empty response content");
                        }
                    }
                    else
                    {
                        throw new Exception($"API request failed with status code: {response.StatusCode}");
                    }
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
            return remoteStopTransactionResponse;
        }

    }
}
