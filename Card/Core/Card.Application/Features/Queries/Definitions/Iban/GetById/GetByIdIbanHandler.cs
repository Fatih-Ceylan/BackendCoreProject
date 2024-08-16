using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;

namespace Card.Application.Features.Queries.Definitions.Iban.GetById
{
    public class GetByIdIbanHandler : IRequestHandler<GetByIdIbanRequest, GetByIdIbanResponse>
    {
        readonly IIbanReadRepository _ibanReadRepository;

        public GetByIdIbanHandler(IIbanReadRepository ibanReadRepository)
        {
            _ibanReadRepository = ibanReadRepository;
        }

        public async Task<GetByIdIbanResponse> Handle(GetByIdIbanRequest request, CancellationToken cancellationToken)
        {
            var iban = _ibanReadRepository
                            .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                            .Select(c => new IbanVM
                            {
                                Id = c.Id.ToString(),
                                CreatedDate = c.CreatedDate,
                                IbanNo = c.IbanNo,
                                StaffId = c.Staff.Id.ToString(),
                                StaffName = $"{c.Staff.Name} {c.Staff.LastName}",
                                BranchId = c.BranchId.ToString(),
                                BranchName = c.Branch.Name,
                                CompanyId = c.CompanyId.ToString(),
                                CompanyName = c.Branch.Company.Name
                            }).FirstOrDefault();

            return new()
            {
                Iban = iban
            };
        }
    }
}
