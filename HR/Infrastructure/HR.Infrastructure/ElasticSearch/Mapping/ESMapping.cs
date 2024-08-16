using BaseProject.Domain.Entities.HR.Employment;
using Nest;

namespace HR.Infrastructure.ElasticSearch.Mapping
{
    public static class ESMapping
    {
        public static CreateIndexDescriptor EmployeeMapping(this CreateIndexDescriptor descriptor)
        {
            return descriptor.Map<Employee>(m => m.Properties(p => p
            .Keyword(k => k.Name(n => n.Id))
            .Text(t => t.Name(n => n.FirstName))
            .Text(t => t.Name(n => n.LastName))
            .Text(t => t.Name(n => n.UserName))
            .Text(t => t.Name(n => n.Email))
            .Number(t => t.Name(n => n.Salary))
            .Date(t => t.Name(n => n.CreatedDate)))
            );
        }
    }
}
