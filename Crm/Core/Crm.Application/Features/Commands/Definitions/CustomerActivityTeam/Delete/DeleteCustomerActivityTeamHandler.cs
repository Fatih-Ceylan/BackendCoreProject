using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.CustomerActivityTeam.Delete
{
    public class DeleteCustomerActivityTeamHandler : IRequestHandler<DeleteCustomerActivityTeamRequest, DeleteCustomerActivityTeamResponse>
    {
        readonly ICustomerWriteRepository _customerWriteRepository;
        readonly IMapper _mapper;

        public DeleteCustomerActivityTeamHandler(ICustomerWriteRepository customerWriteRepository, IMapper mapper)
        {
            _customerWriteRepository = customerWriteRepository;
            _mapper = mapper;
        }

        public async  Task<DeleteCustomerActivityTeamResponse> Handle(DeleteCustomerActivityTeamRequest request, CancellationToken cancellationToken)
        {
            await _customerWriteRepository.SoftDeleteAsync(request.Id);
            await _customerWriteRepository.SaveAsync();

            return new()
            {
                Message = CommandResponseMessage.DeletedSuccess.ToString(),
            };
        }
    }
}
