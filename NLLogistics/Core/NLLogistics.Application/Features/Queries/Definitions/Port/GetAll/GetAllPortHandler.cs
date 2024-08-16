using MediatR;
using NLLogistics.Application.Repositories.ReadRepositories.Definitions;
using NLLogistics.Application.VMs.Definitions.Port;

namespace NLLogistics.Application.Features.Queries.Definitions.Port.GetAll
{
    public class GetAllPortHandler : IRequestHandler<GetAllPortRequest, GetAllPortResponse>
    {
        readonly IPortReadRepository _portReadRepository;

        public GetAllPortHandler(IPortReadRepository portReadRepository)
        {
            _portReadRepository = portReadRepository;
        }

        public async Task<GetAllPortResponse> Handle(GetAllPortRequest request, CancellationToken cancellationToken)
        {
            var query = _portReadRepository.GetAllDeletedStatusDesc(false, request.IsDeleted)
                                              .Select(p => new PortVM
                                              {
                                                  Id = p.Id.ToString(),
                                                  CreatedDate = p.CreatedDate,
                                                  Code = p.Code,
                                                  Name = p.Name,
                                                  CountryId = p.CountryId,
                                                  CountryName = p.Country != null ? p.Country.Name : null

                                              });
            var totalCount = query.Count();
            var ports = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                       .Take(request.Size)
                                                       .ToList()
                                             : query.ToList();

            return new()
            {
                TotalCount = totalCount,
                Ports = ports
            };
        }
    }
}