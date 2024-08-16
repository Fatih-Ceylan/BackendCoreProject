using AutoMapper;
using BaseProject.Application.Repositories.ReadRepository.Definitions;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;
using T = BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;
using TT = BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Contacts;

namespace GCrm.Application.Features.Commands.Definitions.Customer.Create
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        readonly IMapper _mapper;
        readonly ICompanyReadRepository _companyReadRepository;
        readonly ICustomerWriteRepository _customerWriteRepository;
        readonly ICustomerContactReadRepository _customerContactReadRepository;
        readonly ICustomerAddressWriteRepository _customerAddressWriteRepository;
        readonly ICustomerContactWriteRepository _customerContactWriteRepository;
        readonly ICustomerCategoryReadRepository _customerCategoryReadRepository;
        readonly ICustomerCategoryWriteRepository _customerCategoryWriteRepository;
        readonly IDistrictReadRepository _districtReadRepository;

        public CreateCustomerHandler(IDistrictReadRepository districtReadRepository, ICustomerWriteRepository customerWriteRepository, IMapper mapper, ICustomerAddressWriteRepository customerAddressWriteRepository, ICustomerContactReadRepository customerContactReadRepository, ICustomerContactWriteRepository customerContactWriteRepository, ICompanyReadRepository companyReadRepository, ICustomerCategoryWriteRepository customerCategoryWriteRepository, ICustomerCategoryReadRepository customerCategoryReadRepository)
        {
            _mapper = mapper;
            _companyReadRepository = companyReadRepository;
            _customerWriteRepository = customerWriteRepository;
            _customerContactReadRepository = customerContactReadRepository;
            _customerAddressWriteRepository = customerAddressWriteRepository;
            _customerCategoryReadRepository = customerCategoryReadRepository;
            _customerContactWriteRepository = customerContactWriteRepository;
            _customerCategoryWriteRepository = customerCategoryWriteRepository;
            _districtReadRepository= districtReadRepository;
        }

        public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            if (request.CompanyId == "SelectAll")
            {
                request.CompanyId = null;
            }
            var customer = _mapper.Map<T.Customer>(request);
            customer = await _customerWriteRepository.AddAsync(customer);
            var customerAddressList = _mapper.Map<List<T.CustomerAddress>>(request.CustomerAddress);


            //if (customerAddressList.Count>0)
            //{

            //    foreach (var customerAddress in customerAddressList)
            //    {
            //        customerAddress.District.Name = await _districtReadRepository.GetByIdAsync(customerAddress.DistrictId.Value.ToString());

            //    }
            //}

            customer.CustomerAddresses = customerAddressList;
            await _customerAddressWriteRepository.AddRangeAsync(customerAddressList);
            await _customerAddressWriteRepository.SaveAsync();

            List<TT.CustomerContact>? contactList = new();
            if (!string.IsNullOrEmpty(request.DefaultContactId))
            {
                var contact = await _customerContactReadRepository.GetByIdAsync(request.DefaultContactId);
                contact.CustomerId = customer.Id;
                contactList.Add(contact);
                await _customerContactWriteRepository.SaveAsync();
            }

            var customerCategoryList = new List<T.CustomerCategory>();
            if (request.CustomerCategory != null && request.CustomerCategory.Count > 0)
            {
                foreach (var customerCategory in request.CustomerCategory)
                {
                    var category = await _customerCategoryReadRepository.GetByIdAsync(customerCategory.Id);
                    customerCategoryList.Add(category);
                    customer.CustomerCategories.Add(category);
                }
                await _customerCategoryWriteRepository.SaveAsync();
            }
            if (string.IsNullOrEmpty(request.CompanyId) || request.CompanyId == "SelectAll")
            {
                var mainCompanyId = _companyReadRepository.GetWhere(x => x.MainCompanyId == null).FirstOrDefault().Id;
                customer.CompanyId = mainCompanyId;
            }
            await _customerWriteRepository.SaveAsync();
            var createdResponse = _mapper.Map<CreateCustomerResponse>(customer);
            createdResponse.MessageList = new();
            createdResponse.CustomerAddress = _mapper.Map<List<CustomerAddressVM>>(customerAddressList);
            createdResponse.CustomerContact = _mapper.Map<List<CustomerContactListVM>>(contactList);
            createdResponse.CustomerCategory = _mapper.Map<List<CustomerCategoryVM>>(customerCategoryList);

            //    contactList?.Select(e => new CustomerContactCreateVM
            //{
            //    Id = e.Id.ToString(),
            //    Name = e.Name,
            //    Title = e.Title,
            //    AddressType = e.AddressType,
            //}).ToList();
            createdResponse.MessageList.Add("Customer Addded Success.");

            return createdResponse;
        }
    }
}