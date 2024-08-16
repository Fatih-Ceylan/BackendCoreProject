using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;

namespace Card.Application.Features.Queries.Definitions.PhoneNumber.GetById
{
    public class GetByIdPhoneNumberHandler : IRequestHandler<GetByIdPhoneNumberRequest, GetByIdPhoneNumberResponse>
    {
        readonly IPhoneNumberReadRepository _phoneNumberReadRepository;

        public GetByIdPhoneNumberHandler(IPhoneNumberReadRepository phoneNumberReadRepository)
        {
            _phoneNumberReadRepository = phoneNumberReadRepository;
        }

        public async Task<GetByIdPhoneNumberResponse> Handle(GetByIdPhoneNumberRequest request, CancellationToken cancellationToken)
        {
            var iban = _phoneNumberReadRepository
                            .GetWhere(p => p.Id == Guid.Parse(request.Id), false)
                            .Select(p => new PhoneNumberVM
                            {
                                Id = p.Id.ToString(),
                                CreatedDate = p.CreatedDate,
                                StaffId = p.Staff.Id.ToString(),
                                Number = p.Number,
                                StaffName = $"{p.Staff.Name} {p.Staff.LastName}",
                                CompanyId = p.CompanyId.ToString(),
                                BranchName = p.Branch.Name,
                                BranchId = p.BranchId.ToString(),
                                CompanyName = p.Branch.Company.Name

                            }).FirstOrDefault();

            return new()
            {
                PhoneNumber = iban
            };
        }
    }
}
