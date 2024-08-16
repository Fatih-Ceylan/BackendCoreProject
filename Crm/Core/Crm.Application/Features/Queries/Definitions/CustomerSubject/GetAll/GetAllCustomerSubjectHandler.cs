using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerSubject.GetAll
{
    public class GetAllCustomerSubjectHandler : IRequestHandler<GetAllCustomerSubjectRequest, GetAllCustomerSubjectResponse>
    {

        readonly ICustomerSubjectReadRepository _customerSubjectReadRepository;

        public GetAllCustomerSubjectHandler(ICustomerSubjectReadRepository customerSubjectReadRepository)
        {

            _customerSubjectReadRepository= customerSubjectReadRepository;
        }
        public   Task<GetAllCustomerSubjectResponse> Handle(GetAllCustomerSubjectRequest request, CancellationToken cancellationToken)
        {
            var query = _customerSubjectReadRepository.GetAllDeletedStatusDesc(false)
               .Select(csb => new CustomerSubjectVM
               {
                   Id = csb.Id.ToString(),
                   Name = csb.Name,
                   CreatedDate = csb.CreatedDate,
               });

            var totalCount = query.Count();
            var customersubjects = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllCustomerSubjectResponse
            {
                TotalCount = totalCount,
                customerSubjectVMs = customersubjects,
            });
        }
    }
}
