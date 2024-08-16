using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivity.Update
{
    public class UpdateCustomerActivityHandler : IRequestHandler<UpdateCustomerActivityRequest, UpdateCustomerActivityResponse>
    {
        readonly ICustomerActivityReadRepository _customerActivityReadRepository;
        readonly ICustomerActivityWriteRepository _customerActivityWriteRepository;
        readonly ICustomerActivityTeamReadRepository _customerActivityTeamReadRepository;
        readonly IMapper _mapper;
        public UpdateCustomerActivityHandler(ICustomerActivityReadRepository customerActivityReadRepository, ICustomerActivityWriteRepository customerActivityWriteRepository, IMapper mapper, ICustomerActivityTeamReadRepository customerActivityTeamReadRepository)
        {
            _customerActivityReadRepository = customerActivityReadRepository;
            _customerActivityWriteRepository = customerActivityWriteRepository;
            _mapper = mapper;
            _customerActivityTeamReadRepository = customerActivityTeamReadRepository;
        }
        public async Task<UpdateCustomerActivityResponse> Handle(UpdateCustomerActivityRequest request, CancellationToken cancellationToken)
        {
            var customeractivity = await _customerActivityReadRepository.GetByIdAsyncIncluding([e => e.CustomerActivityTeams], request.Id);
            customeractivity = _mapper.Map(request, customeractivity);

            if (request.CustomerActivityTeams != null && request.CustomerActivityTeams.Count > 0)
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

            if (string.IsNullOrEmpty(request.ActivityDate.ToString()))
            {
                customeractivity.ActivityDate = null;
            }
            if (string.IsNullOrEmpty(request.ReminderDate.ToString()))
            {
                customeractivity.ReminderDate = null;
            }

            await _customerActivityWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCustomerActivityResponse>(customeractivity);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
