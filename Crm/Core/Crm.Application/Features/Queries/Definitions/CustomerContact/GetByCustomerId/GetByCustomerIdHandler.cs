using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CustomerContact.GetByCustomerId
{
    public class GetByCustomerIdHandler : IRequestHandler<GetByCustomerIdRequest, GetByCustomerIdResponse>
    {
        readonly ICustomerContactReadRepository _customerContactReadRepository;

        public GetByCustomerIdHandler(ICustomerContactReadRepository customerContactReadRepository)
        {
            _customerContactReadRepository = customerContactReadRepository;
        }
        public async Task<GetByCustomerIdResponse> Handle(GetByCustomerIdRequest request, CancellationToken cancellationToken)
        {
            var customerContacts = _customerContactReadRepository
                       .GetWhere(cc => cc.CustomerId == Guid.Parse(request.Id), false)
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
                             CreatedDate = cc.CreatedDate,
                             UpdatedDate = cc.UpdatedDate
                         }).FirstOrDefault();

            return new()
            {
                CustomerContact = customerContacts
            };
        }
    }
}
