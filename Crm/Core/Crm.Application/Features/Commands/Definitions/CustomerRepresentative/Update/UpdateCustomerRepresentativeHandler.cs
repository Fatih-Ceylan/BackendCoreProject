using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerRepresentative.Update
{
    public class UpdateCustomerRepresentativeHandler : IRequestHandler<UpdateCustomerRepresentativeRequest, UpdateCustomerRepresentativeResponse>
    {
        readonly ICustomerRepresentativeReadRepository _customerRepresentativeReadRepository;
        readonly ICustomerRepresentativeWriteRepository _customerRepresentativeWriteRepository;
        readonly IMapper _mapper;

        public UpdateCustomerRepresentativeHandler(ICustomerRepresentativeReadRepository customerRepresentativeReadRepository, ICustomerRepresentativeWriteRepository customerRepresentativeWriteRepository, IMapper mapper)
        {
            _customerRepresentativeReadRepository = customerRepresentativeReadRepository;
            _customerRepresentativeWriteRepository = customerRepresentativeWriteRepository;
            _mapper = mapper;
        }

        public async  Task<UpdateCustomerRepresentativeResponse> Handle(UpdateCustomerRepresentativeRequest request, CancellationToken cancellationToken)
        {
            var customerepresentative = await _customerRepresentativeReadRepository.GetByIdAsync(request.Id);
            customerepresentative = _mapper.Map(request, customerepresentative);
            await _customerRepresentativeWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCustomerRepresentativeResponse>(customerepresentative);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
