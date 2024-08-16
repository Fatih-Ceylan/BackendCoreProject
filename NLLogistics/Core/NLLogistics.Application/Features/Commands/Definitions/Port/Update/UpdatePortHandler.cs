using MediatR;
using NLLogistics.Application.Repositories.ReadRepositories.Definitions;
using NLLogistics.Application.Repositories.WriteRepositories.Definitions;
using Utilities.Core.UtilityApplication.Enums;

namespace NLLogistics.Application.Features.Commands.Definitions.Port.Update
{
    public class UpdatePortHandler : IRequestHandler<UpdatePortRequest, UpdatePortResponse>
    {
        readonly IPortReadRepository _portReadRepository;
        readonly IPortWriteRepository _portWriteRepository;

        public UpdatePortHandler(IPortReadRepository portReadRepository, IPortWriteRepository portWriteRepository)
        {
            _portReadRepository = portReadRepository;
            _portWriteRepository = portWriteRepository;
        }

        public async Task<UpdatePortResponse> Handle(UpdatePortRequest request, CancellationToken cancellationToken)
        {
            var port = await _portReadRepository.GetByIdAsync(request.Id);
            port.Code = request.Code;
            port.Name = request.Name;
            port.CountryId = request.CountryId;

            await _portWriteRepository.SaveAsync();

            return new()
            {
                Id = port.Id.ToString(),
                Code = port.Code,
                Name = port.Name,
                Message = CommandResponseMessage.UpdatedSuccess.ToString()
            };
        }
    }
}