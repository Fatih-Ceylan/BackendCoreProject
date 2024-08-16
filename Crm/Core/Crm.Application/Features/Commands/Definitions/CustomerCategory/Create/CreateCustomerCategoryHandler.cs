using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions;

namespace GCrm.Application.Features.Commands.Definitions.CustomerCategory.Create
{
    public class CreateCustomerCategoryHandler : IRequestHandler<CreateCustomerCategoryRequest, CreateCustomerCategoryResponse>
    {
        readonly ICustomerCategoryWriteRepository _customerCategoryWriteRepository;
        readonly IMapper _mapper;
        public CreateCustomerCategoryHandler(ICustomerCategoryWriteRepository customerCategoryWriteRepository, IMapper mapper)
        {
            _customerCategoryWriteRepository = customerCategoryWriteRepository;
            _mapper = mapper;
        }
        public async Task<CreateCustomerCategoryResponse> Handle(CreateCustomerCategoryRequest request, CancellationToken cancellationToken)
        {

            var customerCategory = _mapper.Map<T.CustomerManagement.Customers.CustomerCategory>(request);

            await _customerCategoryWriteRepository.AddAsync(customerCategory);
            await _customerCategoryWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCustomerCategoryResponse>(customerCategory);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
