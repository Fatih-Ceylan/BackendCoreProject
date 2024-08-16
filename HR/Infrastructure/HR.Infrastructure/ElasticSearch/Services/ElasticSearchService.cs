using BaseProject.Domain.Entities.HR.Employment;
using HR.Infrastructure.ElasticSearch.Interface;
using HR.Infrastructure.ElasticSearch.Mapping;
using Microsoft.Extensions.Configuration;
using Nest;

namespace HR.Infrastructure.ElasticSearch.Services
{
    public class ElasticSearchService : IElasticSearchService
    {
        private readonly IConfiguration _configuration;
        private readonly IElasticClient _client;

        public ElasticSearchService(IConfiguration configuration, IElasticClient client)
        {
            _configuration = configuration;
            _client = client;
        }

        private ElasticClient CreateInstance()
        {
            string host = _configuration.GetSection("ElasticSearchServer:host").Value;
            string port = _configuration.GetSection("ElasticSearchServer:port").Value;
            string userName = _configuration.GetSection("ElasticSearchServer:userName").Value;
            string password = _configuration.GetSection("ElasticSearchServer:password").Value;

            var settings = new ConnectionSettings(new Uri(host + ":" + port));
            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
            {
                settings.BasicAuthentication(userName, password);
            }

            return new ElasticClient(settings);
        }

        public async Task CheckIndex(string indexName)
        {
            var any = await _client.Indices.ExistsAsync(indexName);
            if (any.Exists)
            {
                return;
            }

            var response = await _client.Indices.CreateAsync(indexName,
            ci => ci
            .Index(indexName)
            .EmployeeMapping()
            .Settings(s => s.NumberOfShards(3).NumberOfReplicas(1)));
        }

        public async Task DeleteIndex(string indexName)
        {
            await _client.Indices.DeleteAsync(indexName);
        }

        public async Task<Employee> GetDocument(string indexName, string id)
        {
            var response = await _client.GetAsync<Employee>(id, q => q.Index(indexName));

            return response.Source;
        }

        public Task<List<Employee>> GetDocuments(string indexName)
        {
            throw new NotImplementedException();
        }

        public Task InsertBulkDocument(string indexName, List<Employee> employees)
        {
            throw new NotImplementedException();
        }

        public Task InsertDocument(string indexName, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
