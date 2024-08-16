using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerKind.Update
{
    public class UpdateCustomerKindHandler : IRequestHandler<UpdateCustomerKindRequest, UpdateCustomerKindResponse>
    {
        readonly ICustomerKindWriteRepository _customerKindWriteRepository;
        readonly ICustomerKindReadRepository _customerKindReadRepository;
        readonly IMapper _mapper;

        public UpdateCustomerKindHandler(ICustomerKindWriteRepository customerKindWriteRepository, ICustomerKindReadRepository customerKindReadRepository, IMapper mapper)
        {
            _customerKindWriteRepository = customerKindWriteRepository;
            _customerKindReadRepository = customerKindReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCustomerKindResponse> Handle(UpdateCustomerKindRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerKindReadRepository.GetByIdAsync(request.Id);
            customer = _mapper.Map(request, customer);
            await _customerKindWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCustomerKindResponse>(customer);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
