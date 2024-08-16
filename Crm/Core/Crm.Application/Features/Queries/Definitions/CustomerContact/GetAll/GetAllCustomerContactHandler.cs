using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerContact.GetAll
{
    public class GetAllCustomerContactHandler : IRequestHandler<GetAllCustomerContactRequest, GetAllCustomerContactResponse>
    {
        readonly ICustomerContactReadRepository _customerContactReadRepository;

        public GetAllCustomerContactHandler(ICustomerContactReadRepository customerContactReadRepository)
        {
            _customerContactReadRepository = customerContactReadRepository;
        }

        public Task<GetAllCustomerContactResponse> Handle(GetAllCustomerContactRequest request, CancellationToken cancellationToken)
        {
            var query = _customerContactReadRepository
                                    .GetAllDeletedStatusDesc(false)
                                    .Select(cc => new CustomerContactVM
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
                                        //AddressType = cc.AddressType.ToString(),

                                        DecisionStatus = cc.DecisionStatus,
                                        RelationCompany = cc.RelationCompany,
                                        Status = cc.Status,
                                        Gender = cc.Gender,
                                        BirthDate = cc.BirthDate,
                                        MaritalStatus = cc.MaritalStatus,
                                        //MarriageDate = cc.MarriageDate,
                                        AssistantName = cc.AssistantName,
                                        AssistantPhone = cc.AssistantPhone,
                                        CardVisitImagePath = cc.CardVisitImagePath,
                                        CompanyId = cc.CompanyId.ToString(),
                                        CreatedDate = cc.CreatedDate,
                                        UpdatedDate = cc.UpdatedDate
                                    });

            var totalCount = query.Count();
            if (!string.IsNullOrEmpty(request.CompanyId) && request.CompanyId != "SelectAll")
            {
                query = query.Where(b => b.CompanyId == request.CompanyId);
                totalCount = query.Count();
            }
            var customerContacts = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                  .Take(request.Size).ToList()
                                                  : query.ToList();

            return Task.FromResult(new GetAllCustomerContactResponse
            {
                TotalCount = totalCount,
                CustomerContacts = customerContacts,
            });
        }
    }
}
