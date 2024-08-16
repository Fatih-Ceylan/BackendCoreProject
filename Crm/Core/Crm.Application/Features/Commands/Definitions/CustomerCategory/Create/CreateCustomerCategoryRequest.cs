using MediatR;

namespace GCrm.Application.Features.Commands.Definitions.CustomerCategory.Create
{
    public class CreateCustomerCategoryRequest : IRequest<CreateCustomerCategoryResponse>
    {
        public string Name { get; set; }

    }
}
