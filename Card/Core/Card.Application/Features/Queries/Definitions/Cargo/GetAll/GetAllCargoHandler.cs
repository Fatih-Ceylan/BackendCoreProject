using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Card.Application.Features.Queries.Definitions.Cargo.GetAll
{
    public class GetAllCargoHandler : IRequestHandler<GetAllCargoRequest, GetAllCargoResponse>
    {
        readonly ICargoReadRepository _cargoReadRepository; 

        public GetAllCargoHandler(ICargoReadRepository cargoReadRepository)
        {
            _cargoReadRepository = cargoReadRepository; 
        }

        public async Task<GetAllCargoResponse> Handle(GetAllCargoRequest request, CancellationToken cancellationToken)
        {
            var cargoQuery = _cargoReadRepository.GetAllDeletedStatusDesc(false); 

            if (request.BranchId == "SelectAll" && request.CompanyId != "SelectAll")
            {
                cargoQuery = cargoQuery.Where(b => b.CompanyId == Guid.Parse(request.CompanyId));
            }
            else if (request.BranchId != "SelectAll" && request.CompanyId != "SelectAll")
            {
                cargoQuery = cargoQuery.Where(b => b.CompanyId == Guid.Parse(request.CompanyId) && b.BranchId == Guid.Parse(request.BranchId));
            }

            var cargos = await cargoQuery.Select(c => new CargoVM
            {
                Id = c.Id.ToString(),
                Name = c.Name,
                CreatedDate = c.CreatedDate,
                CargoPrice = c.CargoPrice,
                TaxRate = c.TaxRate,
                CompanyId = c.CompanyId.ToString(),
                BranchId = c.BranchId.ToString(),
                CompanyName = c.Branch.Company.Name,
                BranchName = c.Branch.Name,
            }).ToListAsync(cancellationToken); 

            var totalCount = cargos.Count;

            var response = cargos.Skip(request.Page * request.Size).Take(request.Size).ToList();

            return new GetAllCargoResponse
            {
                TotalCount = totalCount,
                Cargos = response
            };
        }
    }
}
