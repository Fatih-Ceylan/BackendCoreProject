using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityTeam.Update
{
    public class UpdateCustomerActivityTeamHandler : IRequestHandler<UpdateCustomerActivityTeamRequest, UpdateCustomerActivityTeamResponse>
    {
        readonly ICustomerActivityTeamReadRepository _customerActivityTeamReadRepository;
        readonly ICustomerActivityTeamWriteRepository _customerActivityTeamWriteRepository;
        readonly IMapper _mapper;

        public UpdateCustomerActivityTeamHandler(ICustomerActivityTeamReadRepository customerActivityTeamReadRepository, ICustomerActivityTeamWriteRepository customerActivityTeamWriteRepository, IMapper mapper)
        {
            _customerActivityTeamReadRepository = customerActivityTeamReadRepository;
            _customerActivityTeamWriteRepository = customerActivityTeamWriteRepository;
            _mapper = mapper;


        }
        public async Task<UpdateCustomerActivityTeamResponse> Handle(UpdateCustomerActivityTeamRequest request, CancellationToken cancellationToken)
        {
            var customeractivityteams = await _customerActivityTeamReadRepository.GetByIdAsync(request.Id);
            customeractivityteams = _mapper.Map(request, customeractivityteams);
            await _customerActivityTeamWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateCustomerActivityTeamResponse>(customeractivityteams);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
