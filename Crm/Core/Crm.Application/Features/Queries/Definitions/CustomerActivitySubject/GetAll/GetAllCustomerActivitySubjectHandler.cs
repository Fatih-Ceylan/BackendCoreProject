using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivitySubject.GetAll
{
    public class GetAllCustomerActivitySubjectHandler : IRequestHandler<GetAllCustomerActivitySubjectRequest, GetAllCustomerActivitySubjectResponse>
    {
        readonly ICustomerActivitySubjectReadRepository  _customerActivitySubjectReadRepository;

        public GetAllCustomerActivitySubjectHandler(ICustomerActivitySubjectReadRepository customerActivitySubjectReadRepository)
        {
            _customerActivitySubjectReadRepository = customerActivitySubjectReadRepository;
        }

        public Task<GetAllCustomerActivitySubjectResponse> Handle(GetAllCustomerActivitySubjectRequest request, CancellationToken cancellationToken)
        {
            var query = _customerActivitySubjectReadRepository.GetAllDeletedStatusDesc(false)
         .Select(c => new CustomerActivitySubjectVM
         {
             Id = c.Id.ToString(),
             Name = c.Name,
             CreatedDate = c.CreatedDate,
         });

            var totalCount = query.Count();
            var customerActivitiySubjects = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllCustomerActivitySubjectResponse
            {
                TotalCount = totalCount,
                CustomerActivitySubjects = customerActivitiySubjects
            });
        }
    }
}
