using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerProject.GetAll
{
    public class GetAllCustomerProjectHandler : IRequestHandler<GetAllCustomerProjectRequest, GetAllCustomerProjectResponse>
    {
        readonly ICustomerProjectReadRepository _customerProjectReadRepository;

        public GetAllCustomerProjectHandler(ICustomerProjectReadRepository customerProjectReadRepository)
        {
            _customerProjectReadRepository = customerProjectReadRepository;
        }

        public  Task<GetAllCustomerProjectResponse> Handle(GetAllCustomerProjectRequest request, CancellationToken cancellationToken)
        {
            var query = _customerProjectReadRepository.GetAllDeletedStatusDesc(false)
              .Select(cp => new CustomerProjectVM
              {
                  Id = cp.Id.ToString(),
                  Name = cp.Name,
                  CreatedDate = cp.CreatedDate,
              });

            var totalCount = query.Count();
            var customerprojects = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllCustomerProjectResponse
            {
                TotalCount = totalCount,
                customerProjectVM = customerprojects,
            });
        }
    }
}
