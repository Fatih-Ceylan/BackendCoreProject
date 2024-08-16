using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityKind.Delete
{
    public class DeleteCustomerActivityKindHandler : IRequestHandler<DeleteCustomerActivityKindRequest, DeleteCustomerActivityKindResponse>
    {

        readonly ICustomerActivityKindWriteRepository _customerActivityKindWriteRepository;
        readonly IMapper _mapper;

        public DeleteCustomerActivityKindHandler(ICustomerActivityKindWriteRepository customerActivityKindWriteRepository, IMapper mapper)
        {

            _customerActivityKindWriteRepository = customerActivityKindWriteRepository;
            _mapper = mapper;

        }
        public async Task<DeleteCustomerActivityKindResponse> Handle(DeleteCustomerActivityKindRequest request, CancellationToken cancellationToken)
        {
            await _customerActivityKindWriteRepository.SoftDeleteAsync(request.Id);
            await _customerActivityKindWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
