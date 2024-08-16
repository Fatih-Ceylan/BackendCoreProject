using MediatR;
using NLLogistics.Application.Repositories.WriteRepositories.Definitions;
using Utilities.Core.UtilityApplication.Enums;
using T = BaseProject.Domain.Entities.NLLogistics.Definitions;

namespace NLLogistics.Application.Features.Commands.Definitions.Port.Create
{
    public class CreatePortHandler : IRequestHandler<CreatePortRequest, CreatePortResponse>
    {
        readonly IPortWriteRepository _portWriteRepository;

        public CreatePortHandler(IPortWriteRepository portWriteRepository)
        {
            _portWriteRepository = portWriteRepository;
        }

        public async Task<CreatePortResponse> Handle(CreatePortRequest request, CancellationToken cancellationToken)
        {
            T.Port port = new();
            port.Code = request.Code;
            port.Name = request.Name;
            port.CountryId = request.CountryId;

            port = await _portWriteRepository.AddAsync(port);
            await _portWriteRepository.SaveAsync();

            return new()
            {
                Id = port.Id.ToString(),
                Code = port.Code,
                Name = port.Name,
                Message = CommandResponseMessage.AddedSuccess.ToString()
            };
        }
    }
}
