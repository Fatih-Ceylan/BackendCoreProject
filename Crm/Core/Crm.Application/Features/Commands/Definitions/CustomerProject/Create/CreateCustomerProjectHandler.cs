using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;

namespace GCrm.Application.Features.Commands.Definitions.CustomerProject.Create
{
    public class CreateCustomerProjectHandler : IRequestHandler<CreateCustomerProjectRequest, CreateCustomerProjectResponse>
    {
        readonly ICustomerProjectWriteRepository _customerProjectWriteRepository;
        readonly IMapper _mapper;
        public CreateCustomerProjectHandler(ICustomerProjectWriteRepository customerProjectWriteRepository, IMapper mapper)
        {
            _customerProjectWriteRepository = customerProjectWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateCustomerProjectResponse> Handle(CreateCustomerProjectRequest request, CancellationToken cancellationToken)
        {
            var customerProject = _mapper.Map<T.CustomerProject>(request);
            await _customerProjectWriteRepository.AddAsync(customerProject);
            await _customerProjectWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCustomerProjectResponse>(customerProject);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;

        }
    }
}
