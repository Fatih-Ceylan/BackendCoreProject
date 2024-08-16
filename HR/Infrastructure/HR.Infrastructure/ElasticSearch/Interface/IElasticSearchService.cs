using BaseProject.Domain.Entities.HR.Employment;

namespace HR.Infrastructure.ElasticSearch.Interface
{
    public interface IElasticSearchService
    {
        Task CheckIndex(string indexName);
        Task DeleteIndex(string indexName);
        Task InsertDocument(string indexName, Employee employee);
        Task InsertBulkDocument(string indexName, List<Employee> employees);
        Task<Employee> GetDocument(string indexName, string id);
        Task<List<Employee>> GetDocuments(string indexName);
    }
}
