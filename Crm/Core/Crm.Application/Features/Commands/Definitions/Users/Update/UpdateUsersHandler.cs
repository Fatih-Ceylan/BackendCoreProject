using AutoMapper;
using GCrm.Application.Repositories.ReadRepository;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;

namespace GCrm.Application.Features.Commands.Definitions.Users.Update
{
    public class UpdateUsersHandler : IRequestHandler<UpdateUsersRequest, UpdateUsersResponse>
    {
        readonly IUsersReadRepository _usersReadRepository;
        readonly IUsersWriteRepository _usersWriteRepository;
        readonly IMapper _mapper;
        public UpdateUsersHandler(IUsersReadRepository usersReadRepository, IUsersWriteRepository usersWriteRepository, IMapper mapper)
        {
            _usersReadRepository = usersReadRepository;
            _usersWriteRepository = usersWriteRepository;
            _mapper = mapper;
        }

        public async  Task<UpdateUsersResponse> Handle(UpdateUsersRequest request, CancellationToken cancellationToken)
        {
            var user = await _usersReadRepository.GetByIdAsync(request.Id);
            user = _mapper.Map(request, user);
            await _usersWriteRepository.SaveAsync();

            var updatedResponse = _mapper.Map<UpdateUsersResponse>(user);
            updatedResponse.Message = CommandResponseMessage.UpdatedSuccess.ToString();

            return updatedResponse;
        }
    }
}
