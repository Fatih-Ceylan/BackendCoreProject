using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions.AddressType;
using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.AddressType.GetById
{
    public class GetByIdAddressTypeHandler : IRequestHandler<GetByIdAddressTypeRequest, GetByIdAddressTypeResponse>
    {
        readonly IAddressTypeReadRepository _addressTypeReadRepository;

        public GetByIdAddressTypeHandler(IAddressTypeReadRepository addressTypeReadRepository)
        {
            _addressTypeReadRepository = addressTypeReadRepository;
        }

        public async Task<GetByIdAddressTypeResponse> Handle(GetByIdAddressTypeRequest request, CancellationToken cancellationToken)
        {
            var AddressType = _addressTypeReadRepository
                              .GetWhere(at => at.Id == Guid.Parse(request.Id))
                              .Select(at => new AddressTypeVM
                              {
                                  Id = at.Id.ToString(),
                                  Name = at.Name,
                                  CreatedDate = at.CreatedDate
                              }).FirstOrDefault();

            return new()
            {
                AddressType = AddressType
            };
        }
    }
}