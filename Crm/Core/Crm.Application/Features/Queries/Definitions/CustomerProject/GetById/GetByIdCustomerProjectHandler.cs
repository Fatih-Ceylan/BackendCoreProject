using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerProject.GetById
{
    public class GetByIdCustomerProjectHandler : IRequestHandler<GetByIdCustomerProjectRequest, GetByIdCustomerProjectResponse>
    {

        readonly ICustomerProjectReadRepository _customerProjectReadRepository;

        public GetByIdCustomerProjectHandler(ICustomerProjectReadRepository customerProjectReadRepository)
        {
            _customerProjectReadRepository = customerProjectReadRepository;
        }

        public async  Task<GetByIdCustomerProjectResponse> Handle(GetByIdCustomerProjectRequest request, CancellationToken cancellationToken)
        {
            var customerproject = _customerProjectReadRepository
                            .GetWhere(cp => cp.Id == Guid.Parse(request.Id), false)
                            .Select(cp => new CustomerProjectVM
                            {
                                Id = cp.Id.ToString(),
                                Name = cp.Name,
                              
                           
                              

                                CreatedDate = cp.CreatedDate
                            }).FirstOrDefault();



            return new()
            {
                customerProjectVM = customerproject
            };
        }
    }
}
