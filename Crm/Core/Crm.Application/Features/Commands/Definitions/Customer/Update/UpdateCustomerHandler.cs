using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;
using System.Data;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Contacts;
using TT = BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;


namespace GCrm.Application.Features.Commands.Definitions.Customer.Update
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
    {
        readonly ICustomerReadRepository _customerReadRepository;
        readonly ICustomerWriteRepository _customerWriteRepository;
        readonly ICustomerAddressWriteRepository _customerAddressWriteRepository;
        readonly ICustomerContactWriteRepository _customerContactWriteRepository;
        readonly ICustomerContactReadRepository _customerContactReadRepository;
        readonly ICustomerCategoryWriteRepository _customerCategoryWriteRepository;
        readonly ICustomerCategoryReadRepository _customerCategoryReadRepository;
        readonly IMapper _mapper;

        public UpdateCustomerHandler(ICustomerReadRepository customerReadRepository, ICustomerAddressWriteRepository customerAddressWriteRepository,
            ICustomerContactWriteRepository customerContactWriteRepository, ICustomerCategoryWriteRepository customerCategoryWriteRepository, IMapper mapper, ICustomerContactReadRepository customerContactReadRepository, ICustomerCategoryReadRepository customerCategoryReadRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _customerReadRepository = customerReadRepository;
            _customerAddressWriteRepository = customerAddressWriteRepository;
            _customerContactWriteRepository = customerContactWriteRepository;
            _customerContactReadRepository = customerContactReadRepository;
            _customerCategoryWriteRepository = customerCategoryWriteRepository;
            _customerCategoryReadRepository = customerCategoryReadRepository;
            _customerWriteRepository = customerWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCustomerResponse> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerReadRepository.GetByIdAsyncIncluding([customer => customer.CustomerAddresses, customer => customer.CustomerContacts, customer => customer.CustomerCategories], request.Id);
            customer = _mapper.Map(request, customer);

            if (request.CustomerCategory != null && request.CustomerCategory.Count > 0)
            {
                var customercategoryList = _mapper.Map<List<TT.CustomerCategory>>(request.CustomerCategory);
                customer.CustomerCategories.Clear();

                foreach (var customerCategory in request.CustomerCategory)
                {
                    var category = await _customerCategoryReadRepository.GetByIdAsync(customerCategory.Id);

                    if (category != null)
                    {
                        customer.CustomerCategories.Add(category);
                    }
                }

                await _customerCategoryWriteRepository.SaveAsync();
            }

            if (request.CustomerAddress != null && request.CustomerAddress.Count > 0)
            {
                _customerAddressWriteRepository.HardDeleteRange(customer.CustomerAddresses.ToList());

                var customeradressList = _mapper.Map<List<TT.CustomerAddress>>(request.CustomerAddress);
                customer.CustomerAddresses.Clear();
                customer.CustomerAddresses = customeradressList;
                await _customerAddressWriteRepository.AddRangeAsync(customeradressList);
                await _customerAddressWriteRepository.SaveAsync();
            }

            //if (request.CustomerContact != null)
            //{
            //    _customerContactWriteRepository.RemoveRange(customer.CustomerContacts.ToList());
            //    var customerContactList = _mapper.Map<List<T.CustomerContact>>(request.CustomerContact);

            //    if (!string.IsNullOrEmpty(request.DefaultContactId))
            //    {
            //        customer.DefaultContactId = Guid.Parse(request.DefaultContactId);
            //    }
            //    customer.CustomerContacts = customerContactList;
            //    var aa = await _customerContactWriteRepository.SaveAsync();
            //}

            List<T.CustomerContact>? contactList = new();
            if (!string.IsNullOrEmpty(request.DefaultContactId))
            {
                var contact = await _customerContactReadRepository.GetByIdAsync(request.DefaultContactId);
                contact.CustomerId = customer.Id;
                contactList.Add(contact);
                customer.DefaultContactId = contact.Id;
                //await _customerContactWriteRepository.SaveAsync();
            }

            await _customerWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCustomerResponse>(customer);
            updatedResponse.CustomerAddress = _mapper.Map<List<CustomerAddressCreateVM>>(customer.CustomerAddresses);
            updatedResponse.CustomerContact = _mapper.Map<List<CustomerContactListVM>>(contactList.Count > 0 ? contactList : customer.CustomerContacts);
            updatedResponse.CustomerCategory = customer.CustomerCategories.Select(e => new CustomerCategoryCreateVM
            {
                Id = e.Id.ToString(),
                Name = e.Name,
            }).ToList();
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}