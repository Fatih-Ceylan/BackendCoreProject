using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerCategory.GetById
{
    public class GetByIdCustomerCategoryRequest : IRequest<GetByIdCustomerCategoryResponse>
    {
        public string Id { get; set; }
    }
}
