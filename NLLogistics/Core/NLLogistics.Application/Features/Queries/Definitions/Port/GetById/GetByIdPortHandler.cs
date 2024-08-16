using MediatR;
using NLLogistics.Application.Repositories.ReadRepositories.Definitions;
using NLLogistics.Application.VMs.Definitions.Port;

namespace NLLogistics.Application.Features.Queries.Definitions.Port.GetById
{
    public class GetByIdPortHandler : IRequestHandler<GetByIdPortRequest, GetByIdPortResponse>
    {
        readonly IPortReadRepository _portReadRepository;

        public GetByIdPortHandler(IPortReadRepository portReadRepository)
        {
            _portReadRepository = portReadRepository;
        }

        public async Task<GetByIdPortResponse> Handle(GetByIdPortRequest request, CancellationToken cancellationToken)
        {
            var port = _portReadRepository.GetWhere(x => x.Id == Guid.Parse(request.Id))
                                           .Select(p => new PortVM
                                            {
                                                 Id = p.Id.ToString(),
                                                 CreatedDate = p.CreatedDate,
                                                 Code = p.Code,
                                                 Name = p.Name,
                                                 CountryId = p.CountryId,
                                                 CountryName = p.Country != null ? p.Country.Name : null

                                           }).FirstOrDefault();
            return new()
            {
                Port = port
            };
        }
    }
}