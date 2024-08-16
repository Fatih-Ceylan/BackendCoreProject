using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerSubject.GetById
{
    public class GetByIdCustomerSubjectHandler : IRequestHandler<GetByIdCustomerSubjectRequest, GetByIdCustomerSubjectResponse>
    {
        readonly ICustomerSubjectReadRepository _customerSubjectReadRepository;

        public GetByIdCustomerSubjectHandler(ICustomerSubjectReadRepository customerSubjectReadRepository)
        {
            _customerSubjectReadRepository = customerSubjectReadRepository;
        }

        public async Task<GetByIdCustomerSubjectResponse> Handle(GetByIdCustomerSubjectRequest request, CancellationToken cancellationToken)
        {
            var customersubject = _customerSubjectReadRepository
                          .GetWhere(csb => csb.Id == Guid.Parse(request.Id), false)
                          .Select(csb => new CustomerSubjectVM
                          {
                              Id = csb.Id.ToString(),
                              Name = csb.Name,
                                    

                              CreatedDate = csb.CreatedDate
                          }).FirstOrDefault();


            return new()
            {
                customerSubjectVM = customersubject
            };
        }
    }
}
