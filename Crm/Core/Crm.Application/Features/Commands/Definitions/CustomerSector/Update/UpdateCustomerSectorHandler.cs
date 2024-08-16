using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerSector.Update
{
    public class UpdateCustomerSectorHandler : IRequestHandler<UpdateCustomerSectorRequest, UpdateCustomerSectorResponse>
    {
        readonly ICustomerSectorWriteRepository _customerSectorWriteRepository;
        readonly ICustomerSectorReadRepository _customerSectorReadRepository;
        readonly IMapper _mapper;

        public UpdateCustomerSectorHandler(ICustomerSectorWriteRepository customerSectorWriteRepository, ICustomerSectorReadRepository customerSectorReadRepository, IMapper mapper)
        {
            _customerSectorWriteRepository = customerSectorWriteRepository;
            _customerSectorReadRepository = customerSectorReadRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCustomerSectorResponse> Handle(UpdateCustomerSectorRequest request, CancellationToken cancellationToken)
        {
            var customerSector = await _customerSectorReadRepository.GetByIdAsync(request.Id);
            customerSector = _mapper.Map(request, customerSector);
            await _customerSectorWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCustomerSectorResponse>(customerSector);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}