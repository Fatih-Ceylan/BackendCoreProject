using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerSource.Update
{
    public class UpdateCustomerSourceHandler : IRequestHandler<UpdateCustomerSourceRequest, UpdateCustomerSourceResponse>
    {
        readonly ICustomerSourceWriteRepository _customerSourceWriteRepository;
        readonly ICustomerSourceReadRepository _customerSourceReadRepository;
        readonly IMapper _mapper;

        public UpdateCustomerSourceHandler(ICustomerSourceWriteRepository customerSourceWriteRepository, ICustomerSourceReadRepository customerSourceReadRepository, IMapper mapper)
        {
            _customerSourceWriteRepository = customerSourceWriteRepository;
            _customerSourceReadRepository = customerSourceReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCustomerSourceResponse> Handle(UpdateCustomerSourceRequest request, CancellationToken cancellationToken)
        {
            var customerSource = await _customerSourceReadRepository.GetByIdAsync(request.Id);
            customerSource = _mapper.Map(request, customerSource);
            await _customerSourceWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCustomerSourceResponse>(customerSource);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
