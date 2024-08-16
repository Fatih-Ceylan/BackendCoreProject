using AutoMapper;
using MediatR;
using Platform.Application.Repositories.ReadRepository.Definitions;

namespace Platform.Application.Features.Queries.Definitions.Company.GetByUrlPath
{
    public class GetByUrlPathCompanyHandler : IRequestHandler<GetByUrlPathCompanyRequest, GetByUrlPathCompanyResponse>
    {
        readonly ICompanyReadRepository _companyReadRepository;
        readonly IMapper _mapper;

        public GetByUrlPathCompanyHandler(ICompanyReadRepository companyReadRepository, IMapper mapper)
        {
            _companyReadRepository = companyReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByUrlPathCompanyResponse> Handle(GetByUrlPathCompanyRequest request, CancellationToken cancellationToken)
        {
            var company = await _companyReadRepository.GetSingleAsync(x => x.UrlPath == request.UrlPath);
            var response = new GetByUrlPathCompanyResponse();

            if (company == null) {
                response.Message = "The company is not registered in the system.";
            }
            else if (company.IsDeleted == true) {
                response.Message = "Our agreement with your company has ended.";
            }
            else
            {
                response = _mapper.Map<GetByUrlPathCompanyResponse>(company);
            }

            return response;
        }
    }
}