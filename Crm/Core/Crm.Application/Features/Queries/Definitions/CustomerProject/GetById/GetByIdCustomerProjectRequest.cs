using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerProject.GetById
{
    public  class GetByIdCustomerProjectRequest : IRequest<GetByIdCustomerProjectResponse>
    {
        public string Id { get; set; }
    }
}
