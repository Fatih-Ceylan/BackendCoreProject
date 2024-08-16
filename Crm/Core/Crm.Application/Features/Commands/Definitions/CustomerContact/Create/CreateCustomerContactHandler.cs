using AutoMapper;
using BaseProject.Application.Repositories.ReadRepository.Definitions;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Contacts;


namespace GCrm.Application.Features.Commands.Definitions.CustomerContact.Create
{
    public class CreateCustomerContactHandler : IRequestHandler<CreateCustomerContactRequest, CreateCustomerContactResponse>
    {
        readonly ICustomerContactWriteRepository _customerContactWriteRepository;
        readonly ICustomerReadRepository _customerReadRepository;
        readonly ICompanyReadRepository _companyReadRepository;
        readonly IMapper _mapper;
        public CreateCustomerContactHandler(ICustomerContactWriteRepository customercontactWriteRepository, IMapper mapper, ICompanyReadRepository companyReadRepository, ICustomerReadRepository customerReadRepository)
        {
            _customerContactWriteRepository = customercontactWriteRepository;
            _mapper = mapper;
            _companyReadRepository = companyReadRepository;
            _customerReadRepository = customerReadRepository;
        }

        public async Task<CreateCustomerContactResponse> Handle(CreateCustomerContactRequest request, CancellationToken cancellationToken)
        {
            if (request.CompanyId == "SelectAll")
            {
                request.CompanyId = null;
            }
            var customerContact = _mapper.Map<T.CustomerContact>(request);
            if (string.IsNullOrEmpty(request.CompanyId) || request.CompanyId == "SelectAll")
            {
                var mainCompanyId = _companyReadRepository.GetWhere(x => x.MainCompanyId == null).FirstOrDefault().Id;
                customerContact.CompanyId = mainCompanyId;
            }

            if (!string.IsNullOrEmpty(request.CustomerId))
            {
                var customer = await _customerReadRepository.GetByIdAsync(request.CustomerId);
                if (string.IsNullOrEmpty(customer.DefaultContactId.ToString()))
                {
                    customer.DefaultContactId = customerContact.Id;
                }
            }

            customerContact = await _customerContactWriteRepository.AddAsync(customerContact);
            await _customerContactWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCustomerContactResponse>(customerContact);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}

