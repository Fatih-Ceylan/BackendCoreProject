using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerContact.GetById
{
    public class GetByIdCustomerContactHandler : IRequestHandler<GetByIdCustomerContactRequest, GetByIdCustomerContactResponse>
    {
        readonly ICustomerContactReadRepository _customerContactReadRepository;

        public GetByIdCustomerContactHandler(ICustomerContactReadRepository customerContactReadRepository)
        {
            _customerContactReadRepository = customerContactReadRepository;
        }

        public async Task<GetByIdCustomerContactResponse> Handle(GetByIdCustomerContactRequest request, CancellationToken cancellationToken)
        {
            var customerContact = _customerContactReadRepository
                          .GetWhere(cc => cc.Id == Guid.Parse(request.Id), false)
                            .Select(cc => new CustomerContactGetByIdVM
                            {
                                Id = cc.Id.ToString(),
                                Name = cc.Name,
                                CustomerId = cc.CustomerId.ToString(),
                                CustomerName = cc.Customer.Name,
                                Title = cc.Title,
                                Department = cc.Department,
                                Phone = cc.Phone,
                                InternalNo = cc.InternalNo,
                                Mobile = cc.Mobile,
                                Email1 = cc.Email1,
                                Email2 = cc.Email2,
                                FaxNo = cc.FaxNo,
                                Description = cc.Description,
                                DecisionStatus = cc.DecisionStatus,
                                RelationCompany = cc.RelationCompany,
                                Status = cc.Status,
                                Gender = cc.Gender,
                                BirthDate = cc.BirthDate,
                                MaritalStatus = cc.MaritalStatus,
                                AssistantName = cc.AssistantName,
                                AssistantPhone = cc.AssistantPhone,
                                CardVisitImagePath = cc.CardVisitImagePath,
                                CompanyId = cc.CompanyId.ToString(),
                                CreatedDate = cc.CreatedDate
                            }).FirstOrDefault();

            return new()
            {
                CustomerContact = customerContact
            };
        }
    }
}