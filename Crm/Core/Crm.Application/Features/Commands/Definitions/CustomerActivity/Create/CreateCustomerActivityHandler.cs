using AutoMapper;
using BaseProject.Application.Repositories.ReadRepository.Definitions;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.ActivitiesManagement.Activities;


namespace GCrm.Application.Features.Commands.Definitions.CustomerActivity.Create
{
    public class CreateCustomerActivityHandler : IRequestHandler<CreateCustomerActivityRequest, CreateCustomerActivityResponse>
    {
        readonly ICompanyReadRepository _companyReadRepository;
        readonly ICustomerActivityWriteRepository _customerActivityWriteRepository;
        readonly ICustomerActivityTeamReadRepository _customerActivityTeamReadRepository;
        readonly IMapper _mapper;

        public CreateCustomerActivityHandler(ICustomerActivityWriteRepository customerActivityWriteRepository, IMapper mapper, ICustomerActivityTeamReadRepository customerActivityTeamReadRepository, ICompanyReadRepository companyReadRepository)
        {
            _customerActivityWriteRepository = customerActivityWriteRepository;
            _mapper = mapper;
            _customerActivityTeamReadRepository = customerActivityTeamReadRepository;
            _companyReadRepository = companyReadRepository;
        }
        public async Task<CreateCustomerActivityResponse> Handle(CreateCustomerActivityRequest request, CancellationToken cancellationToken)
        {
            if (request.CompanyId == "SelectAll")
            {
                request.CompanyId = null;
            }

            var customeractivity = _mapper.Map<T.CustomerActivity>(request);
            if (request.CustomerActivityTeams.Count > 0)
            {
                customeractivity.CustomerActivityTeams.Clear();
                foreach (var custActTeamsId in request.CustomerActivityTeams)
                {
                    var custActTeam = await _customerActivityTeamReadRepository.GetByIdAsync(custActTeamsId.Id);

                    if (custActTeam != null)
                    {
                        customeractivity.CustomerActivityTeams.Add(custActTeam);
                    }
                }
            }
            if (string.IsNullOrEmpty(request.CompanyId) || request.CompanyId == "SelectAll")
            {
                var mainCompanyId = _companyReadRepository.GetWhere(x => x.MainCompanyId == null).FirstOrDefault().Id;
                customeractivity.CompanyId = mainCompanyId;
            }

            customeractivity = await _customerActivityWriteRepository.AddAsync(customeractivity);

            await _customerActivityWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCustomerActivityResponse>(customeractivity);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;
        }
    }
}
