using AutoMapper;
using GCrm.Application.Repositories.WriteRepository;
using MediatR;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.GCrm.Definitions.UserManagement.Users;


namespace GCrm.Application.Features.Commands.Definitions.Users.Create
{
    public class CreateUsersHandler : IRequestHandler<CreateUsersRequest, CreateUsersResponse>
    {
        readonly IUsersWriteRepository _usersWriteRepository;
        readonly IMapper _mapper;

        public CreateUsersHandler(IUsersWriteRepository usersWriteRepository, IMapper mapper)
        {

            _usersWriteRepository = usersWriteRepository;
            _mapper = mapper;
        }
        public async Task<CreateUsersResponse> Handle(CreateUsersRequest request, CancellationToken cancellationToken)
        {
            var users = _mapper.Map<T.Users>(request);

            users = await _usersWriteRepository.AddAsync(users);
            await _usersWriteRepository.SaveAsync();

            var createdResponse = _mapper.Map<CreateUsersResponse>(users);
           createdResponse.Message= CommandResponseMessage.AddedSuccess.ToString();

            return createdResponse;

        }
    }
}
