using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerActivitySubject.GetById
{
    public class GetByIdCustomerActivitySubjectHandler : IRequestHandler<GetByIdCustomerActivitySubjectRequest, GetByIdCustomerActivitySubjectResponse>
    {
        readonly ICustomerActivitySubjectReadRepository _customerActivitySubjectReadRepository;

        public GetByIdCustomerActivitySubjectHandler(ICustomerActivitySubjectReadRepository customerActivitySubjectReadRepository)
        {
            _customerActivitySubjectReadRepository = customerActivitySubjectReadRepository;
        }

        public async Task<GetByIdCustomerActivitySubjectResponse> Handle(GetByIdCustomerActivitySubjectRequest request, CancellationToken cancellationToken)
        {
            var customeractivitysubjects = _customerActivitySubjectReadRepository
                        .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                        .Select(c => new CustomerActivitySubjectVM
                        {
                            Id = c.Id.ToString(),
                            Name = c.Name,
                            CreatedDate = c.CreatedDate
                        }).FirstOrDefault();



            return new()
            {
                CustomerActivitySubject = customeractivitysubjects
            };
        }
    }
}
