using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerStatus.Update
{
    public class UpdateCustomerStatusHandler : IRequestHandler<UpdateCustomerStatusRequest, UpdateCustomerStatusResponse>
    {
        readonly ICustomerStatusWriteRepository _customerStatusWriteRepository;
        readonly ICustomerStatusReadRepository _customerStatusReadRepository;
        readonly IMapper _mapper;

        public UpdateCustomerStatusHandler(ICustomerStatusWriteRepository customerStatusWriteRepository, ICustomerStatusReadRepository customerStatusReadRepository, IMapper mapper)
        {
            _customerStatusWriteRepository = customerStatusWriteRepository;
            _customerStatusReadRepository = customerStatusReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCustomerStatusResponse> Handle(UpdateCustomerStatusRequest request, CancellationToken cancellationToken)
        {
            var customerStatus = await _customerStatusReadRepository.GetByIdAsync(request.Id);
            customerStatus = _mapper.Map(request, customerStatus);
            await _customerStatusWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCustomerStatusResponse>(customerStatus);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
