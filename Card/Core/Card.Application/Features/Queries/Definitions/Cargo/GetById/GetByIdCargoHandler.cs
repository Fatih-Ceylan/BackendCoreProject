using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;

namespace Card.Application.Features.Queries.Definitions.Cargo.GetById
{
    public class GetByIdCargoHandler : IRequestHandler<GetByIdCargoRequest, GetByIdCargoResponse>
    {
        readonly ICargoReadRepository _cargoReadRepository;

        public GetByIdCargoHandler(ICargoReadRepository cargoReadRepository)
        {
            _cargoReadRepository = cargoReadRepository;
        }

        public async Task<GetByIdCargoResponse> Handle(GetByIdCargoRequest request, CancellationToken cancellationToken)
        {
            var cargo = _cargoReadRepository
                            .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                            .Select(c => new CargoVM
                            {
                                Id = c.Id.ToString(),
                                Name = c.Name,
                                CreatedDate = c.CreatedDate,
                                CargoPrice=c.CargoPrice,
                                TaxRate = c.TaxRate,
                                BranchId=c.BranchId.ToString(),
                                CompanyId=c.CompanyId.ToString(),
                                BranchName = c.Branch.Name,
                                CompanyName = c.Branch.Company.Name
                            }).FirstOrDefault();

            return new()
            {
                Cargo = cargo
            };
        }
    }
}
