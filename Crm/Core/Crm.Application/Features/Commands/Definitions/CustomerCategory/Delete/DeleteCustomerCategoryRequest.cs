using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerCategory.Delete
{
    public class DeleteCustomerCategoryRequest : IRequest<DeleteCustomerCategoryResponse>
    {
        public string Id { get; set; }
    }
}
