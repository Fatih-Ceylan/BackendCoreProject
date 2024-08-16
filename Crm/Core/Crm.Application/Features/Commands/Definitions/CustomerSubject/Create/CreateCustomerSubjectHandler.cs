using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions;

namespace GCrm.Application.Features.Commands.Definitions.CustomerSubject.Create
{
    public class CreateCustomerSubjectHandler : IRequestHandler<CreateCustomerSubjectRequest, CreateCustomerSubjectResponse>
    {
        readonly ICustomerSubjectWriteRepository _customerSubjectWriteRepository;
        readonly IMapper _mapper;

        public CreateCustomerSubjectHandler(ICustomerSubjectWriteRepository customerSubjectWriteRepository, IMapper mapper)
        {
            _customerSubjectWriteRepository = customerSubjectWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateCustomerSubjectResponse> Handle(CreateCustomerSubjectRequest request, CancellationToken cancellationToken)
        {
            var customerSubject = _mapper.Map<T.CustomerManagement.Customers.CustomerSubject>(request);

            customerSubject = await _customerSubjectWriteRepository.AddAsync(customerSubject);
            await _customerSubjectWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCustomerSubjectResponse>(customerSubject);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
