using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityTeam.Create
{
    public class CreateCustomerActivityTeamHandler : IRequestHandler<CreateCustomerActivityTeamRequest, CreateCustomerActivityTeamResponse>
    {
        readonly ICustomerActivityTeamWriteRepository _customerActivityTeamWriteRepository;
        readonly IMapper _mapper;
        public CreateCustomerActivityTeamHandler(ICustomerActivityTeamWriteRepository customerActivityTeamWriteRepository, IMapper mapper)
        {
            _customerActivityTeamWriteRepository = customerActivityTeamWriteRepository;
            _mapper = mapper;

        }

        public async Task<CreateCustomerActivityTeamResponse> Handle(CreateCustomerActivityTeamRequest request, CancellationToken cancellationToken)
        {
            var customeractivityteam = _mapper.Map<T.ActivitiesManagement.Activities.CustomerActivityTeam>(request);
            customeractivityteam = await _customerActivityTeamWriteRepository.AddAsync(customeractivityteam);
            await _customerActivityTeamWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateCustomerActivityTeamResponse>(customeractivityteam);
            createdResponse.Message = CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;

        }
    }
}
