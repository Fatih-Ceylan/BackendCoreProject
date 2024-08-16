using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.VMs.Definitions;
using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.CompanyContactName.GetAll
{
    public class GetAllCompanyContactNameHandler : IRequestHandler<GetAllCompanyContactNameRequest, GetAllCompanyContactNameResponse>
    {
        readonly ICompanyContactNameReadRepository _companyContactNameReadRepository;

        public GetAllCompanyContactNameHandler(ICompanyContactNameReadRepository companyContactNameReadRepository)
        {
            _companyContactNameReadRepository = companyContactNameReadRepository;
        }

        public  Task<GetAllCompanyContactNameResponse> Handle(GetAllCompanyContactNameRequest request, CancellationToken cancellationToken)
        {
            var query = _companyContactNameReadRepository
                       .GetAllDeletedStatusDesc(false)
                       .Select(ck => new CompanyContactNameVM
                       {
                           Id = ck.Id.ToString(),
                           Name = ck.Name
                       });

            var totalCount = query.Count();
            var customerContactNames = query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList();

            return Task.FromResult(new GetAllCompanyContactNameResponse
            {
                TotalCount = totalCount,
                CompanyContactNames = customerContactNames,
            });
        }
    }
}
