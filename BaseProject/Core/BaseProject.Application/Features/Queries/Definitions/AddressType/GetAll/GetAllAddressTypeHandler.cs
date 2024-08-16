using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions.AddressType;
using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.AddressType.GetAll
{
    public class GetAllAddressTypeHandler : IRequestHandler<GetAllAddressTypeRequest, GetAllAddressTypeResponse>
    {
        readonly IAddressTypeReadRepository _addressTypeReadRepository;

        public GetAllAddressTypeHandler(IAddressTypeReadRepository addressTypeReadRepository)
        {
            _addressTypeReadRepository = addressTypeReadRepository;
        }

        public async Task<GetAllAddressTypeResponse> Handle(GetAllAddressTypeRequest request, CancellationToken cancellationToken)
        {
            var query = _addressTypeReadRepository
                        .GetAllDeletedStatusDesc(false, request.IsDeleted)
                        .Select(at => new AddressTypeVM
                        {
                            Id = at.Id.ToString(),
                            Name = at.Name,
                            CreatedDate = at.CreatedDate
                        });

            var totalCount = query.Count();
            var addressTypes = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                           .Take(request.Size).ToList()
                                                     : query.ToList();

            return new()
            {
                TotalCount = totalCount,
                AddressTypes = addressTypes,
            };
        }
    }
}